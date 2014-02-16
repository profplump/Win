Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO

Public Class Subscribed
    Implements DotNetTableEvents

    Dim GetSubscribedTable As DotNetTable
    Delegate Sub UpdateDelegate()
   
    Private TableName As String

    Private Sub Subscribed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TableName = Main.TableNameTxt.Text
        Me.Text = "Subscribed to " & TableName

        Subscribe(TableName)
    End Sub

    Public Sub Subscribe(TableName As String)
        'subscribe to a table
        Dim SubTable As DotNetTable = DotNetTables.DotNetTables.subscribe(TableName) 'read only

        'register for updates from the subscribed table
        SubTable.onChange(Me)
        'SubTable.onStale(Me)
    End Sub

    Public Sub changed(table As DotNetTable) Implements DotNetTableEvents.changed
        UpdateTable()
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        Throw New InvalidOperationException("Not supported yet")
    End Sub


    Public Sub UpdateTable()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDelegate(AddressOf UpdateTable))
        Else
            Dim MyArray As Array
            GetSubscribedTable = DotNetTables.DotNetTables.findTable(TableName)
            MyArray = GetSubscribedTable._data.ToArray
            SubscribedDGV.DataSource = MyArray

            UpdateForm()
            Logs(MyArray)
        End If
    End Sub

    Private Sub UpdateForm()
        GetSubscribedTable = DotNetTables.DotNetTables.findTable(TableName)
        Me.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & GetSubscribedTable.getInterval
        Me.ToolStripStatusLabelLast.Text = "Last Update: " & GetSubscribedTable.lastUpdate
    End Sub

    Private Sub Subscribed_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        DotNetTables.DotNetTables.drop(TableName)
    End Sub

    Public Sub Logs(TableArray() As String)
        Dim FileName As String = Application.StartupPath & "\NetworkTables.txt"
        IO.File.WriteAllLines(FileName, TableArray)
    End Sub


End Class
