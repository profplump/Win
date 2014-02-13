Imports DotNetTables

Public Class Subscribed

    Dim GetClientTable As DotNetTable
    Delegate Sub UpdateDelegate()
    Public Del As UpdateDelegate

    Private TableName As String

    Private Sub Subscribed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Subscribed to " & TableName
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        Dim MyClient As New Client
        Del = AddressOf Me.UpdateTable
        MyClient.run(Del)
    End Sub

    Public Sub UpdateTable()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDelegate(AddressOf UpdateTable))
        Else
            GetClientTable = DotNetTables.DotNetTables.findTable(TableName)
            ServerDGV.DataSource = GetClientTable._data.ToArray
        End If
    End Sub

    Private Sub StopBtn_Click(sender As Object, e As EventArgs) Handles StopBtn.Click
        Me.Close()
    End Sub

 
End Class
