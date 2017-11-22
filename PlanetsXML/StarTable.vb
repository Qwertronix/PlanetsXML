Imports System.IO

Public Class StarTable

    Shared Function rockTable() As DataTable

        Dim table As New DataTable
        Dim sr As New StreamReader(My.Application.Info.DirectoryPath & "\Primary Stats\rock.txt")
        Dim line As String = sr.ReadLine()
        Dim row As DataRow

        table.Columns.Add("Spectral Type", GetType(String))
        table.Columns.Add("Mass", GetType(Single))
        table.Columns.Add("Luminosity", GetType(Single))
        table.Columns.Add("Inner Life Distance", GetType(Single))
        table.Columns.Add("Outer Life Distance", GetType(Single))
        table.Columns.Add("Habitability", GetType(Short))

        Do

            line = sr.ReadLine()
            While String.IsNullOrEmpty(line) = False AndAlso line.StartsWith("#") = True

                line = sr.ReadLine()

            End While
            row = table.NewRow()
            row.ItemArray = Split(line, ", ")
            table.Rows.Add(row)

        Loop While Not line = String.Empty

        Return table

    End Function

    Shared Function waterTable() As DataTable

        Dim table As New DataTable
        Dim sr As New StreamReader(My.Application.Info.DirectoryPath & "\Primary Stats\water.txt")
        Dim line As String = sr.ReadLine()
        Dim row As DataRow

        table.Columns.Add("Spectral Type", GetType(String))
        table.Columns.Add("Inner Life Distance", GetType(Single))
        table.Columns.Add("Outer Life Distance", GetType(Single))

        Do

            line = sr.ReadLine()
            While String.IsNullOrEmpty(line) = False AndAlso line.StartsWith("#") = True

                line = sr.ReadLine()

            End While
            row = table.NewRow()
            row.ItemArray = Split(line, ", ")
            table.Rows.Add(row)

        Loop While Not line = String.Empty

        Return table

    End Function

End Class
