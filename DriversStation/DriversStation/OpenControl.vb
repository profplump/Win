Imports System.Text.RegularExpressions
Imports System.IO

Public Class OpenControl
    Dim DoValidation As Boolean = False
    Dim ServerMode As Boolean

    Private Sub OpenControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IPTxt.Text = My.Settings.IP
        ServerRB.Checked = My.Settings.ServerMode
        ClientRB.Checked = Not My.Settings.ServerMode
    End Sub

    Private Sub ServerRB_CheckedChanged(sender As Object, e As EventArgs) Handles ServerRB.CheckedChanged
        IPTxt.Enabled = ClientRB.Checked
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        DoValidation = True
        If ValidateChildren() = True Then
            My.Settings.ServerMode = ServerRB.Checked
            My.Settings.IP = IPTxt.Text
            My.Settings.Save()

            ServerMode = My.Settings.ServerMode
            If ServerMode = True Then
                Me.Text = "Server Mode"
            Else
                Me.Text = "Client Mode"
            End If

            If Start() Then
                DriversStation.Main()
            End If
        End If
    End Sub

    Public Sub StartButton(ServerMode As Boolean, IP As String)
        My.Settings.ServerMode = ServerMode
        My.Settings.IP = IP
        My.Settings.Save()

        ServerMode = My.Settings.ServerMode
        If ServerMode = True Then
            Me.Text = "Server Mode"
        Else
            Me.Text = "Client Mode"
        End If

        If Start() Then
            DriversStation.main()
        End If

    End Sub

    Public Function Start() As Boolean
        'Start NetworkTables
        Try
            If ServerMode = True Then
                DotNetTables.DotNetTables.startServer()
            Else
                DotNetTables.DotNetTables.startClient(My.Settings.IP)
            End If
        Catch ex As IOException
            MsgBox("Not able to start. " & ex.Message, MsgBoxStyle.Critical, "Failed to Start")
            Start = False
            Exit Function
        End Try
        Start = True
    End Function

    Private Sub IPTxt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles IPTxt.Validating
        If DoValidation = True Then
            If IPTxt.Enabled = True Then
                If Regex.Match(IPTxt.Text, "^(?:\d{1,3}.){3}\d{1,3}$").Success Or Regex.Match(IPTxt.Text, "^\d{4}$").Success Then
                    ErrorProvider1.SetError(IPTxt, "")
                Else
                    ErrorProvider1.SetError(IPTxt, "Please enter a team number or valid IP address.")
                    e.Cancel = True
                End If
            Else
                ErrorProvider1.SetError(IPTxt, "")
            End If
        End If
    End Sub


End Class
