Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables

Module Settings


    'load or save the robot inputs from/to settings
    Public Sub LoadOrSaveTable(Load As Boolean)
        Dim Temp As New ListDictionary
        If Load = True Then
            Temp = My.Settings.RobotInputTable
            For Each key In Temp.Keys
                DriversStation.RobotInputs.setValue(key.ToString, Temp.Item(key.ToString).ToString)
            Next
            DriversStation.RobotInputs.send()
        Else
            'save the values
            For Each key In DriversStation.RobotInputs.Keys
                If Temp.Contains(key) = False Then
                    Temp.Add(key, DriversStation.RobotInputs.getValue(key))
                Else
                    Temp.Item(key) = DriversStation.RobotInputs.getValue(key)
                End If
            Next
            My.Settings.RobotInputTable = Temp
            My.Settings.Save()
        End If
    End Sub

    Public Sub SaveOutputTableNames()
        Dim TableNames As New ListDictionary
        For Each key In DriversStation.OutputTables.Keys
            If TableNames.Contains(key) = False Then
                TableNames.Add(key, DriversStation.OutputTables.getValue(key))
            Else
                TableNames.Item(key) = DriversStation.OutputTables.getValue(key)
            End If
        Next
        My.Settings.OutputTablesList = TableNames
        My.Settings.Save()
    End Sub

    Public Sub LoadOutputTables()
        Dim TablesNames As New ListDictionary
        DriversStation.OpenTables = New NewTable

        TablesNames = My.Settings.OutputTablesList
        For Each table In TablesNames.Keys
            DriversStation.OpenTables.TableNameTxt.Text = table
            DriversStation.OpenTables.Subscribed()
        Next
    End Sub


#Region "User Stuff"

    'saves all user subscribed tables names to the settings
    Public Sub SaveUserTableNames()
        Dim TablesNames As New StringCollection
        For Each table In DriversStation.SubscribedTables
            TablesNames.Add(table.name)
        Next
        My.Settings.SubTables = TablesNames

        For Each table In DriversStation.PublishedTables
            TablesNames.Add(table.name)
        Next
        My.Settings.PubTables = TablesNames
        My.Settings.Save()
    End Sub

    'opens table viewer windows for all user subscribed/published table names saved in settings
    Public Sub LoadUserTables()
            Dim TablesNames As New StringCollection
            DriversStation.OpenTables = New NewTable

            TablesNames = My.Settings.SubTables
            For Each table In TablesNames
                DriversStation.OpenTables.TableNameTxt.Text = table
                DriversStation.OpenTables.Subscribed()
            Next

            TablesNames = My.Settings.PubTables
            For Each table In TablesNames
                DriversStation.OpenTables.TableNameTxt.Text = table
                DriversStation.OpenTables.Publish()
            Next
    End Sub

#End Region
End Module
