Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Threading

Public Class Driving
    Implements DotNetTableEvents

    Public Table As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

#Region "Load"

    Private Sub Driving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Table = DriversStation.RobotInputs

        'display data
        TableDGV.DataSource = Table._data
        'enable editing
        TableDGV.ReadOnly = False
        TableDGV.Columns(KEY_COLUMN).ReadOnly = True
        TableDGV.AllowUserToAddRows = False
    End Sub

#End Region


#Region "Subscribed"

    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        If Me.InvokeRequired Then
            Logs(EventTable)
            Me.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            UpdateDispatch(EventTable)
        End If
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        DriversStation.ToolStripStatusStale.Text = "Table is stale."
    End Sub

    Private Sub UpdateDispatch(EventTable As DotNetTable)



        UpdateLabels()
    End Sub

    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        DriversStation.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & Table.getInterval & " |"
        DriversStation.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(Table.lastUpdate) & " |"
        DriversStation.ToolStripStatusStale.Text = ""
    End Sub


    Public Sub Logs(TableData As DotNetTable)
        Dim OutputString As String = ""
        For Each item As String In TableData.Keys
            OutputString = OutputString & item & "|" & TableData.getValue(item) & Environment.NewLine
        Next
        Dim FileName As String = Application.StartupPath & "\" & TableData.name & ".txt"
        File.AppendAllText(FileName, Environment.NewLine & Now & Environment.NewLine)
        File.AppendAllText(FileName, OutputString)
    End Sub
#End Region


#Region "Published"

    Private Sub TableDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles TableDGV.CellEndEdit
        Dim Key As String = Nothing
        Dim Value As String = Nothing

        If TableDGV.CurrentRow Is Nothing Then
            Exit Sub
        End If

        If Not IsDBNull(TableDGV.CurrentRow.Cells(KEY_COLUMN).Value) Then
            Key = TableDGV.CurrentRow.Cells(KEY_COLUMN).Value
        End If
        If Not IsDBNull(TableDGV.CurrentRow.Cells(VALUE_COLUMN).Value) Then
            Value = TableDGV.CurrentRow.Cells(VALUE_COLUMN).Value
        End If

        If Key Is Nothing Or Value Is Nothing Then
            Exit Sub
        End If

        Table.setValue(Key, Value)
        SendData(Table)

    End Sub


    Private Sub SendData(SendTable As DotNetTable)
        SendTable.send()
        UpdateLabels()
        Logs(SendTable)
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
        SendData(Table)
    End Sub




    'Private Sub IntervalBtn_Click(sender As Object, e As EventArgs) Handles IntervalBtn.Click
    '    Dim UpdateInterval As String
    '    UpdateInterval = IntervalTxt.Text
    '    If IsNumeric(UpdateInterval) Then
    '        Table.setInterval(UpdateInterval)
    '    Else
    '        MsgBox("Update Interval must be numeric.", MsgBoxStyle.Exclamation, "Invalid Input")
    '    End If
    'End Sub
#End Region






End Class
