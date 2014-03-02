Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables

Module Settings


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
