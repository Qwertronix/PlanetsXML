Imports System.Xml.Serialization

<Serializable,
 ComponentModel.DesignerCategory("planets"),
 XmlType(AnonymousType:=True),
 XmlRoot("planets", IsNullable:=False)>
Partial Public Class Planets

    Private planetField() As Planet

    <XmlElement("planet")>
    Public Property planet() As Planet()

End Class

<Serializable,
 ComponentModel.DesignerCategory("planet"),
 XmlType(AnonymousType:=True),
 XmlRoot("planet", IsNullable:=False)>
Partial Public Class Planet

    <XmlElement("name")>
    Public Property name() As String

    <XmlElement("xcood")>
    Public Property xcood() As Decimal?

    <XmlElement("ycood")>
    Public Property ycood() As Decimal?

    <XmlElement("spectralClass")>
    Public Property spectralClass() As String

    <XmlElement("subtype")>
    Public Property subtype() As Integer?

    <XmlElement("luminosity")>
    Public Property luminosity() As String

    <XmlElement("spectralType")>
    Public Property spectralType() As String

    <XmlIgnore>
    Public Property type() As String
    <XmlIgnore()>
    Public Property mass() As Decimal
    <XmlIgnore()>
    Public Property lum() As Decimal
    <XmlIgnore()>
    Public Property innerLife() As Decimal
    <XmlIgnore()>
    Public Property outerLife() As Decimal
    <XmlIgnore()>
    Public Property slot1() As Decimal
    <XmlIgnore()>
    Public Property slot2() As Decimal
    <XmlIgnore()>
    Public Property slot3() As Decimal
    <XmlIgnore()>
    Public Property slot4() As Decimal
    <XmlIgnore()>
    Public Property slot5() As Decimal
    <XmlIgnore()>
    Public Property slot6() As Decimal
    <XmlIgnore()>
    Public Property slot7() As Decimal
    <XmlIgnore()>
    Public Property slot8() As Decimal
    <XmlIgnore()>
    Public Property slot9() As Decimal
    <XmlIgnore()>
    Public Property slot10() As Decimal
    <XmlIgnore()>
    Public Property slot11() As Decimal
    <XmlIgnore()>
    Public Property slot12() As Decimal
    <XmlIgnore()>
    Public Property slot13() As Decimal
    <XmlIgnore()>
    Public Property slot14() As Decimal
    <XmlIgnore()>
    Public Property slot15() As Decimal
    <XmlIgnore()>
    Public Property diameter() As Decimal
    <XmlIgnore()>
    Public Property pMass() As Decimal
    <XmlIgnore()>
    Public Property volume() As Decimal
    <XmlIgnore()>
    Public Property density() As Decimal
    <XmlIgnore()>
    Public Property escapeV() As Decimal
    <XmlIgnore()>
    Public Property axis() As String
    <XmlIgnore()>
    Public Property orbit() As String
    <XmlIgnore()>
    Public Property rings() As Boolean
    <XmlIgnore()>
    Public Property lore() As Boolean
    <XmlIgnore()>
    Public Property AC() As String
    <XmlIgnore()>
    Public Property SF() As String
    <XmlIgnore()>
    Public Property population() As Long
    <XmlIgnore()>
    Public Property tech() As Integer
    <XmlIgnore()>
    Public Property development() As Integer
    <XmlIgnore()>
    Public Property material() As Integer
    <XmlIgnore()>
    Public Property output() As Integer
    <XmlIgnore()>
    Public Property agricultural() As Integer

    <XmlElement("nadirCharge")>
    Public Property nadirCharge() As String

    Public Function ShouldSerializenadirCharge() As Boolean

        Return Not (nadirCharge() Is Nothing)

    End Function

    <XmlElement("zenithCharge")>
    Public Property zenithCharge() As String

    Public Function ShouldSerializezenithCharge() As Boolean

        Return Not (zenithCharge() Is Nothing)

    End Function

    <XmlElement("sysPos")>
    Public Property sysPos() As Integer?

    <XmlElement("pressure")>
    Public Property pressure() As Integer?

    Public Function ShouldSerializepressure() As Boolean

        Return Not (pressure() Is Nothing)

    End Function

    <XmlElement("gravity")>
    Public Property gravity() As Decimal?

    Public Function ShouldSerializegravity() As Boolean

        Return Not (gravity() Is Nothing)

    End Function

    <XmlElement("lifeForm")>
    Public Property lifeForm() As Integer?

    Public Function ShouldSerializelifeForm() As Boolean

        Return Not (lifeForm() Is Nothing)

    End Function

    <XmlElement("climate")>
    Public Property climate() As String

    Public Function ShouldSerializeclimate() As Boolean

        Return Not (climate() Is Nothing)

    End Function

    <XmlElement("percentWater")>
    Public Property percentWater() As Integer?

    Public Function ShouldSerializepercentWater() As Boolean

        Return Not (percentWater() Is Nothing)

    End Function

    <XmlElement("temperature")>
    Public Property temperature() As Integer?

    Public Function ShouldSerializetemperature() As Boolean

        Return Not (temperature() Is Nothing)

    End Function

    <XmlElement("socioIndustrial")>
    Public Property socioIndustrial() As String

    <XmlElement("satellite")>
    Public Property satellite() As String()

    <XmlElement("landMass")>
    Public Property landMass() As String()

    <XmlElement("hpg")>
    Public Property hpg() As String

    Public Function ShouldSerializehpg() As Boolean

        Return Not (hpg() Is Nothing)

    End Function

    <XmlElement("faction")>
    Public Property faction() As String

    <XmlElement("factionChange")>
    Public Property factionChange() As factionChange()

    <XmlElement("desc")>
    Public Property desc() As String

End Class

<Serializable,
 ComponentModel.DesignerCategory("factionChange"),
 XmlType(AnonymousType:=True),
 XmlRoot("factionChange", IsNullable:=False)>
Partial Public Class factionChange

    Private dateField As Date

    Private factionField As String

    <XmlElement(DataType:="date")>
    Public Property [date]() As Date

    <XmlElement("faction")>
    Public Property faction() As String

End Class
