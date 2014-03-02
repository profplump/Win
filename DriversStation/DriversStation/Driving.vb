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

        Select Case EventTable.name
            Case My.Settings.RobotInputDefault
                DriversStation.ParameterTable1.UpdateInputKeys()
            Case My.Settings.RobotInput
                DriversStation.ParameterTable1.UpdateInputValues()
            Case My.Settings.OutputTables
                SubscribeOutputTables()
            Case Else
                'main dispatch
        End Select

        UpdateLabels()
    End Sub

    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        DriversStation.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & Table.getInterval
        DriversStation.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(Table.lastUpdate)
        DriversStation.ToolStripStatusStale.Text = ""
    End Sub


    Public Sub Logs(TableData As DotNetTable)
        Dim OutputString As String = ""
        For Each item As String In TableData.Keys
            OutputString = OutputString & item & "|" & TableData.getValue(item) & Environment.NewLine
        Next
        Dim FileName As String = Application.StartupPath & "\" & Table.name & ".txt"
        File.AppendAllText(FileName, Environment.NewLine & Now & Environment.NewLine)
        File.AppendAllText(FileName, OutputString)
    End Sub
#End Region


#Region "Published"
    Private Sub TableDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles TableDGV.CellEndEdit
        Dim Key As String
        Dim Value As String

        If IsDBNull(TableDGV.CurrentRow.Cells("Key").Value) Then
            Key = ""
        Else
            Key = TableDGV.CurrentRow.Cells("Key").Value
        End If
        If IsDBNull(TableDGV.CurrentRow.Cells("Value").Value) Then
            Value = ""
        Else
            Value = TableDGV.CurrentRow.Cells("Value").Value
        End If


        If Key <> "" Then
            If Table.exists(Key) = True Then
                For Each row As DataGridViewRow In TableDGV.Rows
                    If row.Index <> TableDGV.CurrentRow.Index Then
                        Dim CheckRow As String
                        If IsDBNull(row.Cells("Key").Value) Then
                            CheckRow = ""
                        Else
                            CheckRow = row.Cells("Key").Value
                        End If
                        If CheckRow = Key Then
                            MsgBox("This key alredy exists.", MsgBoxStyle.Exclamation, "Duplicate Key")
                            TableDGV.Rows.Remove(TableDGV.CurrentRow)
                            Exit Sub
                        End If
                    End If
                Next
            End If

            Table.setValue(Key, Value)
            SendData(Table)
        End If
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
