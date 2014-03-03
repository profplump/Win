Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO


Public Class DriversStation
    Public OpenTables As NewTable
    Public MainControl As New Driving
    Public ParameterTable1 As New ParameterTable
    Public OutputTables1 As New OutputTables

    'pre-determined tables
    Public OutputTables As DotNetTable
    Public RobotInputDefaults As DotNetTable
    Public RobotInputs As DotNetTable

    Private Sub DriversStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ModeSelect As New OpenControl
        My.Settings.IP = "127.0.0.1"
        ModeSelect.StartButton(False, My.Settings.IP)
    End Sub

    Public Sub FillPanel(x As UserControl, Optional UserMsg As String = "Ready")
        If Me.MainPanel.HasChildren Then
            Me.MainPanel.Controls.Clear()
        End If

        Me.MainPanel.Controls.Add(x)
        x.Dock = DockStyle.Fill
        Me.ToolStripStatus.Text = UserMsg
    End Sub

    Public Sub FillMenuList()

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
        Me.FillPanel(MainControl, "Drivers Station in " & Mode)
    End Sub

    Public Sub GetTables()
        'publish tables to robot
        RobotInputs = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)
        'load existing table if any
        ParameterTable1.SendOrSaveTable(True)

        'Subscribe to robot tables
        'debug tables
        OutputTables = DotNetTables.DotNetTables.subscribe(My.Settings.OutputTables)
        OutputTables.onChange(OutputTables1)
        OutputTables.onStale(OutputTables1)

        'input defaults
        RobotInputDefaults = DotNetTables.DotNetTables.subscribe(My.Settings.RobotInputDefault)
        RobotInputDefaults.onChange(ParameterTable1)
        RobotInputDefaults.onStale(ParameterTable1)
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