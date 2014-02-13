Imports DotNetTables
Imports DotNetTables.DotNetTable
Imports DotNetTables.DotNetTables
Imports System.IO


Public Class Client
    Implements DotNetTableEvents


    Public PassedDel As ServerOutput.UpdateDelegate

    Public Sub run(del As ServerOutput.UpdateDelegate)
        'Start NetworktTables
        PassedDel = del

        Try
            DotNetTables.DotNetTables.startClient("127.0.0.1")
        Catch ex As IOException
            'do a log
            'Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
            Exit Sub
        End Try

        'Publish and subscribe a table
        'Dim client As DotNetTable = DotNetTables.DotNetTables.publish("FromClient") 'write only
        Dim server As DotNetTable = DotNetTables.DotNetTables.subscribe("FromServer") 'read only

        'register for updates from the subscribed table
        server.onChange(Me)

        'put new data into our published table every second
        'Dim i As Integer = 0
        'While True
        '    Try
        '        Threading.Thread.Sleep(1000)
        '    Catch ex As Exception
        '        'do a log
        '        'Logger.getLogger(Client.class.getName()).log(Level.SEVERE, null, ex);
        '    End Try

        '    If i Mod 10 = 0 Then
        '        client.clear()
        '    End If

        '    client.setValue("ClientKey-" & i, "ClientVal-" & i)
        '    client.send()
        '    i += 2

        'End While
    End Sub

    Public Sub changed(table As DotNetTable) Implements DotNetTableEvents.changed
        PassedDel.Invoke()
    End Sub


    Public Sub stale(table As DotNetTable) Implements DotNetTableEvents.stale
        Throw New InvalidOperationException("Not supported yet")
    End Sub



End Class