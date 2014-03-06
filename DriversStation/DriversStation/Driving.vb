Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Threading


Public Class Driving
    Implements DotNetTableEvents

    Public RI As DotNetTable
    Public RID As DotNetTable
    Public Indicators As DotNetTable
    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

    Const DriverFeedbackKey As String = "_DRIVER_FEEDBACK_KEY"
    Const RobotFeedbackKey As String = "_ROBOT_FEEDBACK_KEY"
    Const OutofDate As Integer = 2
    Public FeedbackValue As Integer = 0
    Public FeedbackStale As Boolean

#Region "Load"
    Private Sub Driving_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RID = DotNetTables.DotNetTables.subscribe(My.Settings.RobotInputDefault)
        RI = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)

        'Indicators = findTable("")
        'Indicators.onChange(Me)

        UpdateDGV()
    End Sub

#End Region


#Region "On Change"
    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        RID = DotNetTables.DotNetTables.subscribe(My.Settings.RobotInputDefault)
        RI = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)

        If Me.InvokeRequired Then
            Logs(EventTable)
            Me.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
                UpdateInputKeys()
        End If
    End Sub

    'on change for indicators
    'Public Sub UpdateIndicators()
    '    If Indicators.exists("Left Turret") Then
    '        Dim LeftVal As String = Indicators.getValue("Left Turret")
    '        If LeftVal = "something" Then
    '            LeftTurret.BackColor = Color.MistyRose
    '        Else
    '            LeftTurret.BackColor = Color.PaleGreen
    '        End If
    '    End If

    '    If Indicators.exists("Left Turret") Then
    '        Dim LeftVal As String = Indicators.getValue("Left Turret")
    '        If LeftVal = "something" Then
    '            LeftTurret.BackColor = Color.MistyRose
    '        Else
    '            LeftTurret.BackColor = Color.PaleGreen
    '        End If
    '    End If

    'End Sub


    'on change for RobotInputsDefaults
    Public Sub UpdateInputKeys()
        RID = DotNetTables.DotNetTables.subscribe(My.Settings.RobotInputDefault)
        RI = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)
        Dim DGVChanged As Boolean = False

        Dim spareKeys As List(Of String)
        spareKeys = RI.Keys

        For Each key In RID.Keys
            'set new value or add new key
            If Not RI.exists(key) Then
                RI.setValue(key, RID.getValue(key))
                DGVChanged = True
            End If
            'delete row from temp table
            spareKeys.Remove(key)
        Next

        'delete remaining temp rows from parameter table. they weren't in new list of default keys
        For Each key In spareKeys
            RI.remove(key)
            DGVChanged = True
        Next

        'check for feedback loop key/value
        If RID.exists(RobotFeedbackKey) Then
            RI.setValue(RobotFeedbackKey, RID.getValue(RobotFeedbackKey))
        End If

        If RID.exists(DriverFeedbackKey) Then
            If FeedbackValue - RID.getValue(DriverFeedbackKey) > OutofDate Then 'constant
                'out of date
                FeedbackStale = True
            Else
                FeedbackStale = False
            End If
        Else
            FeedbackStale = True
        End If


        'save table values to settings
        SaveToSettings()
        ThreadPool.QueueUserWorkItem(AddressOf SendData, RI)

        DisplayStaleState(RI)

        'update grid control
        If DGVChanged Then
            UpdateDGV()
        End If

    End Sub

    Public Sub UpdateDGV()
        'Display data
        TableDGV.DataSource = RI._data

        'Enable editing of values
        TableDGV.ReadOnly = False
        TableDGV.Columns(KEY_COLUMN).ReadOnly = True
        TableDGV.AllowUserToAddRows = False
        TableDGV.AllowUserToDeleteRows = False

        'Disable editing of special keys
        For Each row As DataGridViewRow In TableDGV.Rows
            Dim key As String = row.Cells(KEY_COLUMN).Value
            If key.StartsWith("_") Then
                row.ReadOnly = True
            End If
        Next

        Me.Refresh()
    End Sub


    'save the robot inputs to settings
    Public Sub SaveToSettings()
        RI = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)
        Dim Temp As New DataTable
        Dim FilePath As String = My.Application.Info.DirectoryPath & "\" & RI.name & ".xml"
        Temp = RI._data
        Temp.TableName = "Temp"
        Try
            Temp.WriteXml(FilePath, System.Data.XmlWriteMode.WriteSchema)
        Catch
        End Try
    End Sub

    'load the robot inputs to the table from settings
    Public Sub LoadFromSettings()
        Dim temp As New DataTable
        temp.TableName = "Temp"
        RI = findTable(My.Settings.RobotInput)
        Dim FilePath As String = My.Application.Info.DirectoryPath & "\" & RI.name & ".xml"

        Try
            'check that file exist and correct type
            temp.ReadXml(FilePath)
        Catch ex As Exception
            Exit Sub
        End Try

        'check for correct column names
        If temp.Columns.Count = 2 Then
            If temp.Columns(0).ColumnName = KEY_COLUMN And temp.Columns(1).ColumnName = VALUE_COLUMN Then
                RI._data = temp
            End If
        End If
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        DisplayStaleState(table)
    End Sub

    Private Sub UpdateLabels()
        Dim StartDate As New DateTime(1970, 1, 1)
        DriversStation.ToolStripStatusLabelInterval.Text = "UpdateInterval: " & RID.getInterval & " |"
        DriversStation.ToolStripStatusLabelLast.Text = "Last Update: " & StartDate.AddMilliseconds(RID.lastUpdate) & " |"
    End Sub

    Public Sub DisplayStaleState(table As DotNetTable)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDelegate(AddressOf DisplayStaleState), table)
        Else
            If FeedbackStale = True Or table.isStale = True Then
                DriversStation.ToolStripStatusStale.Text = "Table is stale."
                TableDGV.BackgroundColor = Color.MistyRose
            Else
                DriversStation.ToolStripStatusStale.Text = ""
                TableDGV.BackgroundColor = Color.FromKnownColor(KnownColor.AppWorkspace)
            End If
        End If
    End Sub

    Public Sub Logs(TableData As DotNetTable)
        Dim OutputString As String = ""
        For Each item As String In TableData.Keys
            OutputString = OutputString & item & "|" & TableData.getValue(item) & Environment.NewLine
        Next
        Dim FileName As String = Application.StartupPath & "\" & TableData.name & ".txt"
        File.AppendAllText(FileName, Environment.NewLine & Now & Environment.NewLine)
        File.AppendAllText(FileName, OutputString)
    End Sub
#End Region


#Region "User Changes"

    Private Sub TableDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles TableDGV.CellEndEdit
        Dim Key As String = Nothing
        Dim Value As String = Nothing

        If TableDGV.CurrentRow Is Nothing Then
            Exit Sub
        End If

        If Not IsDBNull(TableDGV.CurrentRow.Cells(KEY_COLUMN).Value) Then
            Key = TableDGV.CurrentRow.Cells(KEY_COLUMN).Value
        End If
        If Not IsDBNull(TableDGV.CurrentRow.Cells(VALUE_COLUMN).Value) Then
            Value = TableDGV.CurrentRow.Cells(VALUE_COLUMN).Value
        End If

        If Key Is Nothing Or Value Is Nothing Then
            Exit Sub
        End If

        RI.setValue(Key, Value)
        SendData(RI)
        SaveToSettings() 'save updated values to settings
    End Sub


    Private Sub SendData(SendTable As DotNetTable)
        FeedbackLoop()
        SendTable.send()
        UpdateLabels()
        Logs(SendTable)
    End Sub

    Public Sub FeedbackLoop()
        RI = DotNetTables.DotNetTables.publish(My.Settings.RobotInput)

        FeedbackValue += 1
        RI.setValue(DriverFeedbackKey, FeedbackValue)
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'remove rows
        For Each row In TableDGV.SelectedRows
            Try
                RI.remove(row.Cells("Key").Value.ToString)
            Catch ex As Exception
            Finally
                'want to remove row from dgv anyway
                Try
                    TableDGV.Rows.Remove(row)
                Catch ex As Exception
                    'do nothing if it fails
                End Try
            End Try
        Next
        SendData(RI)
    End Sub

#End Region

 
  
End Class
