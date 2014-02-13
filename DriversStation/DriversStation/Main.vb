Public Class Main

  

    Private Sub PublishBtn_Click(sender As Object, e As EventArgs) Handles PublishBtn.Click
        Dim PublishedTable As New Published
        PublishedTable.Show()

    End Sub

    Private Sub SubscribeBtn_Click(sender As Object, e As EventArgs) Handles SubscribeBtn.Click
        Dim SubscribedTable As New Subscribed
        SubscribedTable.Show()
    End Sub
End Class