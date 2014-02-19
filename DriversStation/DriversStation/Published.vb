Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables

Public Class Published
    Inherits Subscribed
    Implements DotNetTableEvents


    Public Table As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

    Public Sub New(Table As String)

        MyBase.New(Table)
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub Published_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Subscribed to " & Table.name
    End Sub



End Class