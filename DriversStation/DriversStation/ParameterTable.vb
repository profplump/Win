﻿Imports System.Collections.Specialized
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
        If DriversStation.MainControl.InvokeRequired Then
            DriversStation.MainControl.Logs(EventTable)
            DriversStation.MainControl.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
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
        Dim spareKeys As List(Of String)
        spareKeys = Me.table.Keys

        For Each key In DriversStation.RobotInputDefaults.Keys
            'set new value or add new key
            If table.exists(key) Then
                table.setValue(key, table.getValue(key))
            Else
                table.setValue(key, "")
            End If
            'delete row from temp table
            spareKeys.Remove(key)
        Next

        'delete remaining temp rows from parameter table. they weren't in new list of default keys
        For Each key In spareKeys
            table.remove(key)
        Next

        SendOrSaveTable(False)
        SendOrSaveTable(True)
        ThreadPool.QueueUserWorkItem(AddressOf SendData, table)
    End Sub

    'on change for RobotInputs
    Public Sub UpdateInputValues()
        SendOrSaveTable(False)
    End Sub

    Private Sub SendData(SendTable As DotNetTable)
        SendTable.send()
        DriversStation.MainControl.Logs(SendTable)
    End Sub

    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        DriversStation.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & table.getInterval
        DriversStation.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(table.lastUpdate)
        DriversStation.ToolStripStatusStale.Text = ""
    End Sub

    'load or save the robot inputs from/to settings
    Public Sub SendOrSaveTable(Send As Boolean)
        Dim Temp As New ListDictionary
        If Send = True Then
            'update the robot-inputs table based on the current values
            Temp = My.Settings.RobotInputTable
            DriversStation.RobotInputs.clear() 'clear all existing values in table
            Try
                're-add based on saved values
                For Each key In Temp.Keys
                    DriversStation.RobotInputs.setValue(key.ToString, Temp.Item(key.ToString).ToString)
                Next
            Catch ex As NullReferenceException

            End Try
            DriversStation.RobotInputs.send()
        Else
            'save the robot-inputs values to settings
            For Each key In DriversStation.RobotInputs.Keys
                If Temp.Contains(key) = False Then
                    Temp.Add(key, DriversStation.RobotInputs.getValue(key))
                Else
                    Temp.Item(key) = DriversStation.RobotInputs.getValue(key)
                End If
            Next
            My.Settings.RobotInputTable = Temp
            My.Settings.Save()
        End If
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale

    End Sub
End Class