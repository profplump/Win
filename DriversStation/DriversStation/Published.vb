Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables

Public Class Published
    Implements DotNetTableEvents

    Dim GetPublishedTable As DotNetTable
    Delegate Sub UpdateDelegate()
    Public Del As UpdateDelegate

    Public PubTable As DotNetTable
    Private TableName As String

    Public Sub New(Table As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TableName = Table
        subscribe(TableName)
    End Sub
    Private Sub Published_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Published " & TableName

        Del = AddressOf Me.UpdateTable
        Publish(TableName)

        UpdateForm()
    End Sub

    Public Sub Publish(TableName As String)
        'subscribe to a table
        PubTable = DotNetTables.DotNetTables.publish(TableName) 'read only

        'register for updates from the subscribed table
        PubTable.onChange(Me)
        PubTable.onStale(Me)
    End Sub

    Public Sub changed(table As DotNetTable) Implements DotNetTableEvents.changed
        Del.Invoke()
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        Throw New InvalidOperationException("Not supported yet")
    End Sub


    Public Sub UpdateTable()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDelegate(AddressOf UpdateTable))
        Else
            GetPublishedTable = DotNetTables.DotNetTables.findTable("FromServer")
            PublishedDGV.DataSource = GetPublishedTable._data.ToArray
        End If
    End Sub

    Private Sub UpdateForm()
        GetPublishedTable = DotNetTables.DotNetTables.findTable(TableName)
        Me.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & GetPublishedTable.getInterval
        Me.ToolStripStatusLabelLast.Text = "Last Update: " & GetPublishedTable.lastUpdate
    End Sub

    Private Sub IntervalBtn_Click(sender As Object, e As EventArgs) Handles IntervalBtn.Click
        Dim i As Integer
        GetPublishedTable = DotNetTables.DotNetTables.findTable(TableName)
        Integer.TryParse(IntervalTxt.Text, i)
        GetPublishedTable.setInterval(i)
        IntervalTxt.Text = ""
        UpdateForm()
    End Sub

    Private Sub StopBtn_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

  

End Class