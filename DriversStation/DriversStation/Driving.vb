Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Threading


Public Class Driving
    Implements DotNetTableEvents

    Public RI As DotNetTable
    Public RID As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

#Region "Load"

    Private Sub Driving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim RID As DotNetTable = findTable(My.Settings.RobotInputDefault)
        Dim RI As DotNetTable = findTable(My.Settings.RobotInput)

        'display data
        TableDGV.DataSource = RID._data
        'enable editing
        TableDGV.ReadOnly = False
        TableDGV.Columns(KEY_COLUMN).ReadOnly = True
        TableDGV.AllowUserToAddRows = False
    End Sub

#End Region


#Region "On Change"
    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        If Me.InvokeRequired Then
            Logs(EventTable)
            Me.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            UpdateDispatch(EventTable)
        End If
    End Sub

    Public Sub UpdateDispatch(EventTable As DotNetTable)
        Select Case EventTable.name
            Case My.Settings.RobotInputDefault
                UpdateInputKeys()
            Case My.Settings.RobotInput
                UpdateInputValues()
        End Select
    End Sub

    'on change for RobotInputsDefaults
    Public Sub UpdateInputKeys()

        Dim DGVChanged As Boolean = False

        Dim spareKeys As List(Of String)
        spareKeys = RI.Keys

        For Each key In RID.Keys
            'set new value or add new key
            If Not RI.exists(key) Then
                RI.setValue(key, RID.getValue(key))
                DGVChanged = True
            End If
            'delete row from temp table
            spareKeys.Remove(key)
        Next

        'delete remaining temp rows from parameter table. they weren't in new list of default keys
        For Each key In spareKeys
            RI.remove(key)
            DGVChanged = True
        Next

        'save table values to settings
        SaveToSettings()
        ThreadPool.QueueUserWorkItem(AddressOf SendData, RI)

        'update grid control
        If DGVChanged Then
            TableDGV.DataSource = RI._data
            Me.Refresh()
        End If
    End Sub

    'on change for RobotInputs
    Public Sub UpdateInputValues()
        SaveToSettings() 'save updated values to settings
    End Sub

    'save the robot inputs to settings
    Public Sub SaveToSettings()
        Dim RI As DotNetTable = findTable(My.Settings.RobotInput)
        Dim Temp As New ListDictionary

        'save the robot-inputs values to settings
        For Each key In RI.Keys
            If Temp.Contains(key) = False Then
                Temp.Add(key, RI.getValue(key))
            Else
                Temp.Item(key) = RI.getValue(key)
            End If
        Next
        My.Settings.RobotInputTable = Temp
        My.Settings.Save()
    End Sub

    'load the robot inputs to the table from settings
    Public Sub LoadFromSettings()
        Dim RI As DotNetTable = findTable(My.Settings.RobotInput)
        Dim Temp As New ListDictionary

        'update the robot-inputs table based on the current values
        Temp = My.Settings.RobotInputTable
        Try
            'update based on saved values
            For Each key In Temp.Keys
                If RI.exists(key) Then
                    RI.setValue(key.ToString, Temp.Item(key.ToString).ToString)
                End If
            Next
        Catch ex As NullReferenceException

        End Try
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale

    End Sub

    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        DriversStation.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & RID.getInterval & " |"
        DriversStation.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(RID.lastUpdate) & " |"
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


#Region "User Changes"

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

        RI.setValue(Key, Value)
        SendData(RI)

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
                RI.remove(row.Cells("Key").Value.ToString)
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
        SendData(RI)
    End Sub

#End Region

End Class
