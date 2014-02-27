Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Collections.Specialized


Public Class DriversStation
    Public OpenTables As NewTable
    Public PublishedTables() As DotNetTable
    Public SubscribedTables() As DotNetTable
    Public ParametersTable As DotNetTable

    Private Sub DriversStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ModeSelect As New OpenControl
        Me.FillPanel(ModeSelect)
    End Sub

    Public Sub FillPanel(x As UserControl, Optional UserMsg As String = "Ready")
        If Me.MainPanel.HasChildren Then
            Me.MainPanel.Controls.Clear()
        End If

        Me.MainPanel.Controls.Add(x)
        x.Dock = DockStyle.Fill
        Me.ToolStripStatus.Text = UserMsg
    End Sub

    Public Sub main()
        Dim Mode As String
        If My.Settings.ServerMode Then
            Mode = "Server Mode"
        Else
            Mode = "Client Mode"
        End If

        Dim MainControl As New Driving
        Me.FillPanel(MainControl, "Drivers Station in" & Mode)
    End Sub


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'subscribe to variable table from robot code
        SubTable = DotNetTables.DotNetTables.subscribe(My.Settings.RobotTable) 'read only
        'register for the onStale event for subscribed tables
        SubTable.onStale(Me)
        'register for updates from the table
        SubTable.onChange(Me)


        'Publish all tables 
        For Each TableName In My.Settings.PubTables
            DotNetTables.DotNetTables.publish(TableName)
        Next

        LoadVariableNames()
    End Sub

    Private Sub LoadVariableNames()
        Table = DotNetTables.DotNetTables.findTable("don't know yet")
        For Each key In SubTable.Keys
            Table.setValue(key, "")
        Next
        SendData(Table)
    End Sub

    Public Sub SaveTableNames()
        Dim TablesNames As New StringCollection
        For Each table In SubscribedTables
            TablesNames.Add(table.name)
        Next
        My.Settings.SubTables = TablesNames

        For Each table In PublishedTables
            TablesNames.Add(table.name)
        Next
        My.Settings.PubTables = TablesNames
        My.Settings.Save()
    End Sub

    Public Sub LoadTables()
        Dim TablesNames As New StringCollection
        OpenTables = New NewTable

        TablesNames = My.Settings.SubTables
        For Each table In TablesNames
            OpenTables.TableNameTxt.Text = table
            OpenTables.Subscribed()
        Next

        TablesNames = My.Settings.PubTables
        For Each table In TablesNames
            OpenTables.TableNameTxt.Text = table
            OpenTables.Publish()
        Next
    End Sub

    Private Sub OpenDebugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDebugToolStripMenuItem.Click
        If OpenTables Is Nothing Then
            OpenTables = New NewTable
        End If
        OpenTables.Show()
    End Sub
End Class