Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO


Public Class NewTable

    Private Sub PublishBtn_Click(sender As Object, e As EventArgs) Handles PublishBtn.Click, PublishToolStripMenuItem.Click
        Publish(True)
    End Sub

    Protected Friend Sub Publish(Optional Override As Boolean = False)
        Dim PublishedTable As New Tables(TableNameTxt.Text, True)
        If My.Settings.DebugMode = True Or Override = True Then
            PublishedTable.Show()
        End If
        TableNameTxt.Text = ""
    End Sub

    Private Sub SubscribeBtn_Click(sender As Object, e As EventArgs) Handles SubscribeBtn.Click, SubscribeToolStripMenuItem.Click
        Subscribed(True)
    End Sub

    Protected Friend Sub Subscribed(Optional Override As Boolean = False)
        Dim SubscribedTable As New Tables(TableNameTxt.Text, False)
        If My.Settings.DebugMode = True Or Override = True Then
            SubscribedTable.Show()
        End If
        TableNameTxt.Text = ""
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class