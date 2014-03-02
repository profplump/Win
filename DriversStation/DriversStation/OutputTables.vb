Module OutputTables
    Public Sub SubscribeOutputTables()
        For Each table In DriversStation.OutputTables.Keys
            DriversStation.OpenTables = New NewTable
            DriversStation.OpenTables.TableNameTxt.Text = table
            DriversStation.OpenTables.Subscribed()
        Next
    End Sub
End Module
