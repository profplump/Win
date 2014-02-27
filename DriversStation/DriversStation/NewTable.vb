Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO


Public Class NewTable

    Private Sub PublishBtn_Click(sender As Object, e As EventArgs) Handles PublishBtn.Click, PublishToolStripMenuItem.Click
        Publish()
    End Sub

    Protected Friend Sub Publish()
        Dim PublishedTable As New Tables(TableNameTxt.Text, True)
        PublishedTable.Show()
        TableNameTxt.Text = ""
    End Sub

    Private Sub SubscribeBtn_Click(sender As Object, e As EventArgs) Handles SubscribeBtn.Click, SubscribeToolStripMenuItem.Click
        Subscribed()
    End Sub

    Protected Friend Sub Subscribed()
        Dim SubscribedTable As New Tables(TableNameTxt.Text, False)
        SubscribedTable.Show()
        TableNameTxt.Text = ""
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class