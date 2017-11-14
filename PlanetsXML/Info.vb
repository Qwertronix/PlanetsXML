Imports System.Xml.Serialization

Public Class Info

    <Serializable,
     ComponentModel.DesignerCategory("planets"),
     XmlType(AnonymousType:=True),
     XmlRoot("planets", IsNullable:=False)>
    Partial Public Class Planets

        Private planetField() As Planet

        Public Property planet() As Planet

    End Class

    <Serializable,
     ComponentModel.DesignerCategory("planet"),
     XmlType(AnonymousType:=True)>
    Partial Public Class Planet

        Property id() As String

        Property orbitRadius() As Decimal

        Property orbitEccentricity() As Decimal

        Property orbitInclination() As Decimal

        Property mass() As Decimal

        Property radius() As Decimal

        Property density() As UShort

        Property dayLength() As Decimal

        Property tilt() As Decimal

        Property [class]() As String

        Property volcanism() As Byte

        Property tectonics() As Byte

        Property pressureAtm() As Decimal

        Property atmMass() As Decimal

        Property albedo() As Decimal

        Property greenhouse() As Decimal

        Property habitability() As Byte

        Property pop() As Byte

        Property government() As String

        Property controlRating() As Byte

        Property icon() As String

    End Class

End Class
