Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO


Public Class DriversStation

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
        Me.ToolStripStatusLabel1.Text = UserMsg
    End Sub

    Public Sub main()
        Dim Mode As String
        If My.Settings.ServerMode Then
            Mode = "Server Mode"
        Else
            Mode = "Client Mode"
        End If

        Dim MainControl As New
        Me.FillPanel(maincontrol, "Drivers Station in" & mode )_
    End Sub
End Class