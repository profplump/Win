Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Collections.Specialized


Public Class DriversStation
    Public OpenTables As NewTable

    'pre-determined tables
    Public OutputTables As DotNetTable
    Public RobotInputDefaults As DotNetTable
    Public RobotInputs As DotNetTable

    'user added tables
    Public PublishedTables() As DotNetTable
    Public SubscribedTables() As DotNetTable

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

        Dim MainControl As New Driving
        Me.FillPanel(MainControl, "Drivers Station in" & Mode)
    End Sub

    Public Sub GetTables()
        'publish tables to robot
        RobotInputs = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)
        'load existing table if any
        LoadOrSaveTable(True)
        RobotInputs.onChange(Me)

        'Subscribe to robot tables
        'debug tables
        OutputTables = DotNetTables.DotNetTables.subscribe(My.Settings.OutputTables)
        OutputTables.onChange(Me)
        OutputTables.onStale(Me)
        SaveOutputTableNames()

        'input defaults
        RobotInputDefaults = DotNetTables.DotNetTables.subscribe(My.Settings.RobotInputDefault)
        RobotInputDefaults.onChange(Me)
        RobotInputDefaults.onStale(Me)

        'publish/subscribe all debug tables and last user session
        LoadUserTables()
        LoadOutputTables()
    End Sub

    Private Sub OpenDebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDebugToolStripMenuItem.Click
        If OpenTables Is Nothing Then
            OpenTables = New NewTable
        End If
        OpenTables.Show()
    End Sub
End Class