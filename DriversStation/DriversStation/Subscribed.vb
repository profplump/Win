Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO

Public Class Subscribed
    Implements DotNetTableEvents

    Public Table As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

    
    Public Sub New(TableName As String)
        ' This call is required by the designer.
        InitializeComponent()

        'subscribe to a table
        Table = DotNetTables.DotNetTables.subscribe(TableName) 'read only

        'register for updates from the subscribed table
        Table.onChange(Me)
    End Sub

    Private Sub Subscribed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Subscribed to " & Table.name
    End Sub

    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            UpdateForm()
        End If
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        Throw New InvalidOperationException("Not supported yet")
    End Sub

    Private Sub UpdateForm()
        Dim MyArray As Array
        MyArray = Table._data.ToArray
        SubscribedDGV.DataSource = MyArray

        Me.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & Table.getInterval
        Me.ToolStripStatusLabelLast.Text = "Last Update: " & Table.lastUpdate

        'Logs(MyArray)
    End Sub

    Private Sub Subscribed_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        DotNetTables.DotNetTables.drop(Table.name())
    End Sub

    Private Sub Logs(TableArray() As String)
        Dim FileName As String = Application.StartupPath & "\NetworkTables.txt"
        IO.File.WriteAllLines(FileName, TableArray)
    End Sub

End Class
