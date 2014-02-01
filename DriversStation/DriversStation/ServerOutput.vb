Imports System.Threading
Imports DotNetTables

Public Class ServerOutput

    Private Trd As Thread
    Private _update As Boolean

    Dim GetClientTable As DotNetTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim MyClient As New Client
        Trd = New Thread(AddressOf MyClient.run)
        Trd.IsBackground = True
        Trd.Start()
        _update = True
        StartBtn.Text = "Update"

    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click

        GetClientTable = DotNetTables.DotNetTables.findTable("FromServer")
        ServerDGV.DataSource = GetClientTable._data.ToArray

        'ServerDGV.Update()

    End Sub





    Private Sub StopBtn_Click(sender As Object, e As EventArgs) Handles StopBtn.Click
        Me.Close()
    End Sub
End Class
