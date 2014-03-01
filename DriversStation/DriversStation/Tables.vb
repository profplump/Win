﻿Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Threading

Public Class Tables
    Implements DotNetTableEvents

    Public Table As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)
    Dim DisplayName As String

    Public Sub New(TableName As String, IsPublished As Boolean)
        ' This call is required by the designer.
        InitializeComponent()

        If IsPublished = True Then
            'publish to a table
            Table = DotNetTables.DotNetTables.publish(TableName) 'read only
        Else
            'subscribe to a table
            Table = DotNetTables.DotNetTables.subscribe(TableName) 'read only
            'register for the onStale event for subscribed tables
            Table.onStale(Me)
            'register for updates from the table
            Table.onChange(Me)
        End If
    End Sub

    Private Sub Subscribed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DriversStation.OutputTables.exists(Table.name) Then
            DisplayName = DriversStation.OutputTables.getValue(Table.name)
        Else
            DisplayName = Table.name
        End If

        If Table.iswritable = True Then
            Me.Text = "Published " & DisplayName
            'add to settings 
            If My.Settings.PubTables.Contains(Table.name) = False Then
                My.Settings.PubTables.Add(Table.name)
            End If
            'show published controls 'hiding for now
            Label1.Visible = False
            IntervalBtn.Visible = False
            IntervalTxt.Visible = False

            'add column headers
            Dim Key As New DataGridViewTextBoxColumn
            Key.Name = "Key"
            Key.HeaderText = "Key"
            Key.DataPropertyName = "Key"
            Dim Value As New DataGridViewTextBoxColumn
            Value.Name = "Value"
            Value.HeaderText = "Value"
            Value.DataPropertyName = "Value"
            TableDGV.Columns.Add(Key)
            TableDGV.Columns.Add(Value)

            'enable editing
            TableDGV.ReadOnly = False
        Else
            Me.Text = "Subscribed to " & DisplayName
            'add to settings
            If My.Settings.SubTables.Contains(Table.name) = False Then
                My.Settings.SubTables.Add(Table.name)
            End If
            'hide published controls
            Label1.Visible = False
            IntervalBtn.Visible = False
            IntervalTxt.Visible = False
            'disable editing
            TableDGV.ReadOnly = True
        End If

        'update settings

    End Sub

    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        If Me.InvokeRequired Then
            Logs(EventTable)
            Me.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            UpdateForm()
        End If
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        Me.ToolStripStatusStale.Text = "Table is stale."
    End Sub

    Private Sub UpdateForm()
        Dim MyArray As Array
        MyArray = Table._data.ToArray
        TableDGV.DataSource = MyArray
        UpdateLabels()
    End Sub


    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        Me.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & Table.getInterval
        Me.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(Table.lastUpdate)
        Me.ToolStripStatusStale.Text = ""
    End Sub

    Private Sub Logs(TableData As DotNetTable)
        Dim OutputString As String = ""
        For Each item As String In TableData.Keys
            OutputString = OutputString & item & "|" & TableData.getValue(item) & Environment.NewLine
        Next
        Dim FileName As String = Application.StartupPath & "\" & DisplayName & ".txt"
        File.AppendAllText(FileName, Environment.NewLine & Now & Environment.NewLine)
        File.AppendAllText(FileName, OutputString)
    End Sub

    Private Sub TableDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles TableDGV.CellEndEdit
        Dim Key As String
        Dim Value As String

        Key = TableDGV.CurrentRow.Cells("Key").Value
        Value = TableDGV.CurrentRow.Cells("Value").Value

        If Key <> "" Then
            If Table.exists(Key) = True Then
                For Each row As DataGridViewRow In TableDGV.Rows
                    If row.Index <> TableDGV.CurrentRow.Index Then
                        If row.Cells("Key").Value = Key Then
                            MsgBox("This key alredy exists.", MsgBoxStyle.Exclamation, "Duplicate Key")
                            TableDGV.Rows.Remove(TableDGV.CurrentRow)
                            Exit Sub
                        End If
                    End If
                Next
            End If

            Table.setValue(Key, Value)
            SendData()
        End If
    End Sub

    Private Sub SendData()
        Table.send()
        UpdateLabels()
        Logs(Table)
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        'remove rows
        For Each row In TableDGV.SelectedRows
            Try
                Table.remove(row.Cells("Key").Value.ToString)
            Catch ex As Exception
            Finally
                'want to remove row from dgv anyway
                Try
                    TableDGV.Rows.Remove(row)
                Catch ex As Exception
                    'do nothing if it fails
                End Try
            End Try
        Next
    End Sub

    Private Sub IntervalBtn_Click(sender As Object, e As EventArgs) Handles IntervalBtn.Click
        Dim UpdateInterval As String
        UpdateInterval = IntervalTxt.Text
        If IsNumeric(UpdateInterval) Then
            Table.setInterval(UpdateInterval)
        Else
            MsgBox("Update Interval must be numeric.", MsgBoxStyle.Exclamation, "Invalid Input")
        End If
    End Sub

    Private Sub NewTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTableToolStripMenuItem.Click
        If DriversStation.OpenTables Is Nothing Then
            DriversStation.OpenTables = New NewTable
        End If
        DriversStation.OpenTables.Show()
    End Sub

    Private Sub Tables_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'update settings

    End Sub

End Class
