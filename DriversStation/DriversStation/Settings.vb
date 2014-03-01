Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables

Module Settings


    'load or save the robot inputs from/to settings
    Public Sub SendOrSaveTable(Send As Boolean)
        Dim Temp As New ListDictionary
        If Send = True Then
            Temp = My.Settings.RobotInputTable
            Try
                For Each key In Temp.Keys
                    DriversStation.RobotInputs.setValue(key.ToString, Temp.Item(key.ToString).ToString)
                Next
            Catch ex As NullReferenceException

            End Try
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

    Public Sub SubscribeOutputTables()
        For Each table In DriversStation.OutputTables.Keys
            DriversStation.OpenTables = New NewTable
            DriversStation.OpenTables.TableNameTxt.Text = table
            DriversStation.OpenTables.Subscribed()
        Next
    End Sub


#Region "User Stuff"

    'saves all user subscribed tables names to the settings
    Public Sub UserVisibleStatus(table As DotNetTable)
        If table.iswritable Then
            My.Settings.PubTables.Add(table.name)
        Else
            My.Settings.SubTables.Add(table.name)
        End If
        My.Settings.Save()
    End Sub

    'opens table viewer windows for all user subscribed/published table names saved in settings
    Public Sub LoadUserTables()
            Dim TablesNames As New StringCollection
            DriversStation.OpenTables = New NewTable
        Try
            TablesNames = My.Settings.SubTables
            For Each table In TablesNames
                DriversStation.OpenTables.TableNameTxt.Text = table
                DriversStation.OpenTables.Subscribed()
            Next
        Catch ex As NullReferenceException

        End Try

        Try
            TablesNames = My.Settings.PubTables
            For Each table In TablesNames
                DriversStation.OpenTables.TableNameTxt.Text = table
                DriversStation.OpenTables.Publish()
            Next
        Catch ex As NullReferenceException

        End Try
    End Sub

#End Region
End Module
