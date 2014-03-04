Imports System.Collections.Specialized
Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO
Imports System.Threading

Public Class OutputTables
    Implements DotNetTableEvents

    Dim TableControl As NewTable
    Dim OutputTable As DotNetTable

    Delegate Sub UpdateDelegate(DelTable As DotNetTable)

    Public Sub changed(EventTable As DotNetTable) Implements DotNetTableEvents.changed
        OutputTable = EventTable
        If DriversStation.ParameterTable.InvokeRequired Then
            DriversStation.ParameterTable.Logs(EventTable)
            DriversStation.ParameterTable.Invoke(New UpdateDelegate(AddressOf changed), EventTable)
        Else
            SubscribeOutputTables()
        End If
    End Sub

    Public Sub SubscribeOutputTables()
        For Each table In OutputTable.Keys
            TableControl = New NewTable
            TableControl.TableNameTxt.Text = table
            TableControl.Subscribed()
        Next
    End Sub

    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale

    End Sub
End Class
