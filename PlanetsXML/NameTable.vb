Imports System.IO

Public Class NameTable

    Shared Function nameTable() As DataTable

        Dim table As New DataTable
        Dim sr As New StreamReader(My.Application.Info.DirectoryPath & "\Names\names.txt")
        Dim line As String = sr.ReadLine()
        Dim row As DataRow

        table.Columns.Add("Name", GetType(String))
        table.Columns.Add("Language", GetType(Short))

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
