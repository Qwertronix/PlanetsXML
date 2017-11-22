Imports System.Xml.Serialization

<Serializable,
ComponentModel.DesignerCategory("planets"),
XmlType(AnonymousType:=True),
XmlRoot("planets", IsNullable:=False)>
Partial Public Class EPlanets

    <XmlElement("planet")>
    Public Property EPlanet() As EPlanet()

End Class

<Serializable,
ComponentModel.DesignerCategory("planet"),
XmlType(AnonymousType:=True),
XmlRoot("planet", IsNullable:=False)>
Partial Public Class EPlanet
    Implements IComparable

    Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo

        If obj Is Nothing Then Return 1

        Dim otherPlanet As EPlanet = TryCast(obj, EPlanet)
        If otherPlanet IsNot Nothing Then
            Return Me.id.CompareTo(otherPlanet.id)
        Else
            Throw New ArgumentException("Object is not a Planet")
        End If
    End Function

    <XmlElement("id")>
    Public Property id() As String

    <XmlElement("event")>
    Public Property [event]() As Eevent()

End Class

<Serializable,
ComponentModel.DesignerCategory("event"),
XmlType(AnonymousType:=True),
XmlRoot("event", IsNullable:=False)>
Partial Public Class Eevent
    Implements IComparable

    Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo

        If obj Is Nothing Then Return 1

        Dim otherEvent As Eevent = TryCast(obj, Eevent)
        If otherEvent IsNot Nothing Then
            Return Me.[date].CompareTo(otherEvent.[date])
        Else
            Throw New ArgumentException("Object is not an Event")
        End If
    End Function

    <XmlElement(DataType:="date")>
    Public Property [date]() As Date

    <XmlElement("climate")>
    Public Property climate() As Short?

    Public Function ShouldSerializeclimate() As Boolean

        Return Not (climate() Is Nothing)

    End Function

    <XmlElement("faction")>
    Public Property faction() As String

    Public Function ShouldSerializefaction() As Boolean

        Return Not (faction() Is Nothing)

    End Function

    <XmlElement("hpg")>
    Public Property hpg() As String

    Public Function ShouldSerializehpg() As Boolean

        Return Not (hpg() Is Nothing)

    End Function

    <XmlElement("message")>
    Public Property message() As String

    Public Function ShouldSerializemessage() As Boolean

        Return Not (message() Is Nothing)

    End Function

    <XmlElement("nadirCharge")>
    Public Property nc() As Boolean?

    Public Function ShouldSerializenc() As Boolean

        Return Not (nc() Is Nothing)

    End Function

    <XmlElement("pop")>
    Public Property pop() As Short?

    Public Function ShouldSerializepop() As Boolean

        Return Not (pop() Is Nothing)

    End Function

    <XmlElement("socioIndustrial")>
    Public Property socioIndustrial() As String

    Public Function ShouldSerializesocioIndustrial() As Boolean

        Return Not (socioIndustrial() Is Nothing)

    End Function

    <XmlElement("temperature")>
    Public Property temperature() As Short?

    Public Function ShouldSerializetemperature() As Boolean

        Return Not (temperature() Is Nothing)

    End Function

    <XmlElement("zenithCharge")>
    Public Property zc() As Boolean?

    Public Function ShouldSerializezc() As Boolean

        Return Not (zc() Is Nothing)

    End Function

End Class