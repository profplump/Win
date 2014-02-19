Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO

Public Class Tables
    Implements DotNetTableEvents

    Public Table As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

    Public Sub New(TableName As String, IsPublished As Boolean)
        ' This call is required by the designer.
        InitializeComponent()

        If IsPublished = True Then
            'publish to a table
            Table = DotNetTables.DotNetTables.publish(TableName) 'read only
        Else
            'subscribe to a table
            Table = DotNetTables.DotNetTables.subscribe(TableName) 'read only
        End If

        'register for updates from the subscribed table
        Table.onChange(Me)
    End Sub

    Private Sub Subscribed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Table.iswritable = True Then
            Me.Text = "Published " & Table.name
            'show published controls
            Label1.Visible = True
            IntervalBtn.Visible = True
            IntervalTxt.Visible = True
            'add column headers
            Dim Key As New DataGridViewTextBoxColumn
            key.Name = "Key"
            key.HeaderText = "Key"
            key.DataPropertyName = "Key"
            Dim Value As New DataGridViewTextBoxColumn
            Value.Name = "Value"
            Value.HeaderText = "Value"
            Value.DataPropertyName = "Value"
            TableDGV.Columns.Add(Key)
            TableDGV.Columns.Add(Value)
            'enable editing
            TableDGV.ReadOnly = False
        Else
            Me.Text = "Subscribed to " & Table.name
            'hide published controls
            Label1.Visible = False
            IntervalBtn.Visible = False
            IntervalTxt.Visible = False
            'disable editing
            TableDGV.ReadOnly = True
        End If
    End Sub

    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            UpdateForm()
        End If
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        Throw New InvalidOperationException("Not supported yet")
    End Sub

    Private Sub UpdateForm()
        Dim MyArray As Array
        MyArray = Table._data.ToArray
        TableDGV.DataSource = MyArray

        Me.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & Table.getInterval
        Me.ToolStripStatusLabelLast.Text = "Last Update: " & Table.lastUpdate

        'Logs(MyArray)
    End Sub

    Private Sub Subscribed_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        DotNetTables.DotNetTables.drop(Table.name())
    End Sub

    Private Sub Logs(TableArray() As String)
        Dim FileName As String = Application.StartupPath & "\NetworkTables.txt"
        IO.File.WriteAllLines(FileName, TableArray)
    End Sub

    Private Sub TableDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles TableDGV.CellEndEdit
        Dim Key As String
        Dim Value As String

        Key = TableDGV.CurrentRow.Cells("Key").Value
        Value = TableDGV.CurrentRow.Cells("Value").Value

        If Key <> "" Then
            Table.setValue(Key, Value)
        End If
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        'remove rows
        For Each row In TableDGV.SelectedRows
            Table.remove(row.Cells("Key").Value.ToString)
            TableDGV.Rows.Remove(row)
        Next
    End Sub

End Class
