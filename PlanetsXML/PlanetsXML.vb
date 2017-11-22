Imports System.Xml

Public Class PlanetsXML

    Private Sub PlanetsXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbPlanets.Items.Clear()
        Dim xr As XmlReader = XmlReader.Create(My.Application.Info.DirectoryPath & "\Planets\planetsTemplate.xml")
        Do While xr.Read()

            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "name" Then

                cbPlanets.Items.Add(xr.ReadElementContentAsString)
                cbPlanets.Sorted = True
                cbPlanets.SelectedIndex = 0

            Else

                xr.Read()

            End If

        Loop
        xr.Close()

    End Sub

    Private Sub btnGen_Click(sender As Object, e As EventArgs) Handles btnWrite.Click

        Dim objectPlanets As New ObjPlanets

    End Sub

    Private Sub cbPlanets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPlanets.SelectedIndexChanged

        'match combo-box text to name of planet and then populate the text boxes

    End Sub

End Class
