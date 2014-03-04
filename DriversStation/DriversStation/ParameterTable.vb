Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Threading

Public Class ParameterTable
    Implements DotNetTableEvents

    Dim table As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)


    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        table = EventTable
        If DriversStation.ParameterTable.InvokeRequired Then
            DriversStation.ParameterTable.Logs(EventTable)
            DriversStation.ParameterTable.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            UpdateDispatch()
        End If
    End Sub

    Public Sub UpdateDispatch()
        Select Case table.name
            Case My.Settings.RobotInputDefault
                UpdateInputKeys()
            Case My.Settings.RobotInput
                UpdateInputValues()
        End Select
    End Sub

    'on change for RobotInputsDefaults
    Public Sub UpdateInputKeys()
        Dim RID As DotNetTable = findTable(My.Settings.RobotInputDefault)
        Dim RI As DotNetTable = findTable(My.Settings.RobotInput)
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
            DriversStation.ParameterTable.TableDGV.DataSource = RI._data
            DriversStation.ParameterTable.Refresh()
        End If
    End Sub

    'on change for RobotInputs
    Public Sub UpdateInputValues()
        SaveToSettings() 'save updated values to settings
    End Sub

    Private Sub SendData(SendTable As DotNetTable)
        SendTable.send()
        DriversStation.ParameterTable.Logs(SendTable)
    End Sub

    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        DriversStation.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & table.getInterval & " |"
        DriversStation.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(table.lastUpdate) & " |"
        DriversStation.ToolStripStatusStale.Text = ""
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
End Class