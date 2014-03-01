﻿Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO


Public Class DriversStation
    Public OpenTables As NewTable
    Public MainControl As New Driving

    'pre-determined tables
    Public OutputTables As DotNetTable
    Public RobotInputDefaults As DotNetTable
    Public RobotInputs As DotNetTable

    Private Sub DriversStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ModeSelect As New OpenControl
        Me.FillPanel(ModeSelect)
    End Sub

    Public Sub FillPanel(x As UserControl, Optional UserMsg As String = "Ready")
        If Me.MainPanel.HasChildren Then
            Me.MainPanel.Controls.Clear()
        End If

        Me.MainPanel.Controls.Add(x)
        x.Dock = DockStyle.Fill
        Me.ToolStripStatus.Text = UserMsg
    End Sub

    Public Sub main()
        Dim Mode As String
        If My.Settings.ServerMode Then
            Mode = "Server Mode"
        Else
            Mode = "Client Mode"
        End If

        'subscribe and publish to defaults
        GetTables()
        'display main output control
        Me.FillPanel(MainControl, "Drivers Station in" & Mode)
    End Sub

    Public Sub GetTables()
        'publish tables to robot
        RobotInputs = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)
        'load existing table if any
        SendOrSaveTable(True)
        RobotInputs.onChange(MainControl)

        'Subscribe to robot tables
        'debug tables
        OutputTables = DotNetTables.DotNetTables.subscribe(My.Settings.OutputTables)
        OutputTables.onChange(MainControl)
        OutputTables.onStale(MainControl)

        'input defaults
        RobotInputDefaults = DotNetTables.DotNetTables.subscribe(My.Settings.RobotInputDefault)
        RobotInputDefaults.onChange(MainControl)
        RobotInputDefaults.onStale(MainControl)
    End Sub

    Private Sub OpenDebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDebugToolStripMenuItem.Click
        If OpenTables Is Nothing Then
            OpenTables = New NewTable
        End If
        OpenTables.Show()
    End Sub

    Private Sub DriversStation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

End Class