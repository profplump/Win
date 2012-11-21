Public Class Demo

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim MyTextBoxText As String

        MyTextBoxText = TextBox1.Text & " My extra text"

        MsgBox(MyTextBoxText, MsgBoxStyle.Question, "hi")
    End Sub

  
End Class
