Imports System.Xml.Serialization
Imports PlanetsXML

<Serializable,
 ComponentModel.DesignerCategory("planets"),
 XmlType(AnonymousType:=True),
 XmlRoot("planets", IsNullable:=False)>
Partial Public Class Planets

    <XmlElement("planet")>
    Public Property planet() As Planet()

End Class

<Serializable,
 ComponentModel.DesignerCategory("planet"),
 XmlType(AnonymousType:=True),
 XmlRoot("planet", IsNullable:=False)>
Partial Public Class Planet
    Implements IComparable, IEquatable(Of Planet)

    Public Overloads Function CompareTo(ByVal obj As Object) As Integer _
        Implements IComparable.CompareTo

        If obj Is Nothing Then Return 1

        Dim otherPlanet As Planet = TryCast(obj, Planet)
        If otherPlanet IsNot Nothing Then
            Return Me.name.CompareTo(otherPlanet.name)
        Else
            Throw New ArgumentException("Object is not a Planet")
        End If
    End Function

    <XmlElement("name")>
    Public Property name() As String

    <XmlIgnore()>
    Public Property id() As String
    'Only if planet is a spacestation or asteroidfield
    <XmlElement("className")>
    Public Property cName() As String

    Public Function ShouldSerializecName() As Boolean

        Return Not (cName() Is Nothing)

    End Function

    <XmlElement("xcood")>
    Public Property x() As Single?

    <XmlElement("ycood")>
    Public Property y() As Single?

    <XmlElement("spectralClass")>
    Public Property sClass() As String

    <XmlElement("subtype")>
    Public Property subT() As Single?

    <XmlElement("luminosity")>
    Public Property luminosity() As String

    <XmlElement("spectralType")>
    Public Property sType() As String
    'Habitability modifier of the star
    <XmlElement("habitability")>
    Public Property habitability() As Short?
    'Star mass compared to Sol
    <XmlIgnore()>
    Public Property mass() As Single
    'Star luminosity compared to Sol
    <XmlIgnore()>
    Public Property lum() As Single

    <XmlElement("nadirCharge")>
    Public Property nc() As Boolean?

    Public Function ShouldSerializenc() As Boolean

        Return Not (nc() Is Nothing)

    End Function

    <XmlElement("zenithCharge")>
    Public Property zc() As Boolean?

    Public Function ShouldSerializezc() As Boolean

        Return Not (zc() Is Nothing)

    End Function
    'Star inner rock zone edge in AU
    <XmlIgnore()>
    Public Property Irock() As Single
    'Star outer rock zone edge in AU
    <XmlIgnore()>
    Public Property Orock() As Single
    'Star inner water zone edge in AU
    <XmlIgnore()>
    Public Property Iwater() As Single
    'Star outer water zone edge in AU
    <XmlIgnore()>
    Public Property Owater() As Single
    'Orbital slot distances in AU from 1-15
    <XmlIgnore()>
    Public Property slot1() As Single
    <XmlIgnore()>
    Public Property slot2() As Single
    <XmlIgnore()>
    Public Property slot3() As Single
    <XmlIgnore()>
    Public Property slot4() As Single
    <XmlIgnore()>
    Public Property slot5() As Single
    <XmlIgnore()>
    Public Property slot6() As Single
    <XmlIgnore()>
    Public Property slot7() As Single
    <XmlIgnore()>
    Public Property slot8() As Single
    <XmlIgnore()>
    Public Property slot9() As Single
    <XmlIgnore()>
    Public Property slot10() As Single
    <XmlIgnore()>
    Public Property slot11() As Single
    <XmlIgnore()>
    Public Property slot12() As Single
    <XmlIgnore()>
    Public Property slot13() As Single
    <XmlIgnore()>
    Public Property slot14() As Single
    <XmlIgnore()>
    Public Property slot15() As Single

    <XmlElement("sysPos")>
    Public Property sysPos() As Short?
    'Distance in AU from star
    <XmlElement("orbitRadius")>
    Public Property orbitR As Single?
    'Planet orbit's deviation from a perfect circle 0.0 - 1.0
    <XmlElement("orbitEccentricity")>
    Public Property orbitE As Single?
    'Planet orbit's inclination to perpendicular of the system's angular momentum vector 0.0 - 90.0
    <XmlElement("orbitInclination")>
    Public Property orbitI As Single?
    'Planet's axis tilt 0.0 - 90.0
    <XmlElement("tilt")>
    Public Property tilt() As Short?

    Public Function ShouldSerializetilt() As Boolean

        Return Not (tilt() Is Nothing)

    End Function
    'Planet mass compare to Earth
    <XmlElement("mass")>
    Public Property Pmass() As Single?

    Public Function ShouldSerializePmass() As Boolean

        Return Not (Pmass() Is Nothing)

    End Function
    'Planet radius compared to Earth
    <XmlElement("radius")>
    Public Property radius() As Single?

    Public Function ShouldSerializeradius() As Boolean

        Return Not (radius() Is Nothing)

    End Function
    'Planet volume in m3
    <XmlIgnore()>
    Public Property volume() As Single
    'Planet density in kg/m3
    <XmlElement("density")>
    Public Property density() As Single?

    Public Function ShouldSerializedensity() As Boolean

        Return Not (density() Is Nothing)

    End Function
    'Planet escape velocity in m/s
    <XmlIgnore()>
    Public Property escapeV() As Single

    <XmlElement("gravity")>
    Public Property gravity() As Single?

    Public Function ShouldSerializegravity() As Boolean

        Return Not (gravity() Is Nothing)

    End Function

    <XmlElement("dayLength")>
    Public Property dayL() As Single?

    Public Function ShouldSerializedayL() As Boolean

        Return Not (dayL() Is Nothing)

    End Function
    'Planet's atmosphere type vacuum(0) - very high(5)
    <XmlElement("pressure")>
    Public Property pressure() As Short?

    Public Function ShouldSerializepressure() As Boolean

        Return Not (pressure() Is Nothing)

    End Function
    'Planet's atmospheric pressure compared to Earth
    <XmlElement("pressureAtm")>
    Public Property pAtm() As Single?

    Public Function ShouldSerializepAtm() As Boolean

        Return Not (pAtm() Is Nothing)

    End Function
    'Text description of planet's atmosphere
    <XmlElement("atmosphere")>
    Public Property atmosphere() As String

    Public Function ShouldSerializeatmosphere() As Boolean

        Return Not (atmosphere() Is Nothing)

    End Function
    'Planet's mass of the atmosphere compared to Earth
    <XmlElement("atmMass")>
    Public Property Amass() As Single?

    Public Function ShouldSerializeAmass() As Boolean

        Return Not (Amass() Is Nothing)

    End Function
    'Amount of starlight reflected by the planet 0.0 - 1.0
    <XmlElement("albedo")>
    Public Property albedo() As Single?

    Public Function ShouldSerializealbedo() As Boolean

        Return Not (albedo() Is Nothing)

    End Function
    'Strength of planet's greenhouse effect
    <XmlElement("greenhouse")>
    Public Property greenhouse() As Single?

    Public Function ShouldSerializegreenhouse() As Boolean

        Return Not (greenhouse() Is Nothing)

    End Function

    <XmlElement("temperature")>
    Public Property temperature() As Short?

    Public Function ShouldSerializetemperature() As Boolean

        Return Not (temperature() Is Nothing)

    End Function
    'Planet's climate type (HQ specific) ARCTIC(0) - HELL(5)
    <XmlElement("climate")>
    Public Property climate() As String

    Public Function ShouldSerializeclimate() As Boolean

        Return Not (climate() Is Nothing)

    End Function
    'Planets volcanic activity 0-6
    <XmlElement("volcanism")>
    Public Property volcanism() As Short?

    Public Function ShouldSerializevolcanism() As Boolean

        Return Not (volcanism() Is Nothing)

    End Function
    'Planets tectonic activity 0-6
    <XmlElement("tectonics")>
    Public Property tectonics() As Short?

    Public Function ShouldSerializetectonics() As Boolean

        Return Not (tectonics() Is Nothing)

    End Function

    <XmlElement("percentWater")>
    Public Property percentWater() As Short?

    Public Function ShouldSerializepercentWater() As Boolean

        Return Not (percentWater() Is Nothing)

    End Function
    'Highest life form on planet NONE(0) - MAMMAL(8)
    <XmlElement("lifeForm")>
    Public Property lifeForm() As String

    Public Function ShouldSerializelifeForm() As Boolean

        Return Not (lifeForm() Is Nothing)

    End Function
    'Number of satellites
    <XmlElement("satellites")>
    Public Property satellites() As Short?

    Public Function ShouldSerializesatellites() As Boolean

        Return Not (satellites() Is Nothing)

    End Function
    'Array of satellite(s)
    <XmlElement("satellite")>
    Public Property satellite() As String()

    Public Function ShouldSerializesatellite() As Boolean

        Return Not (satellite() Is Nothing)

    End Function
    'If planet has a ring system
    <XmlIgnore()>
    Public Property rings() As Boolean

    <XmlElement("landMass")>
    Public Property landMass() As String()

    Public Function ShouldSerializelandMass() As Boolean

        Return Not (landMass() Is Nothing)

    End Function
    'Planets number of human occupants
    <XmlIgnore()>
    Public Property population() As Long
    'Planet's population rating "no population"(-1) - "trillions"(12) 
    <XmlElement("pop")>
    Public Property pop() As Short?
    'Text description of planet's government
    <XmlElement("government")>
    Public Property government() As String

    Public Function ShouldSerializegovernment() As Boolean

        Return Not (government() Is Nothing)

    End Function
    'Planet government's control over the population anarchy(-1) - enslaved(7)
    <XmlElement("controlRating")>
    Public Property cRating() As Short?

    Public Function ShouldSerializecRating() As Boolean

        Return Not (cRating() Is Nothing)

    End Function
    'Planet's SI scores
    <XmlIgnore()>
    Public Property tech() As Short
    <XmlIgnore()>
    Public Property development() As Short
    <XmlIgnore()>
    Public Property material() As Short
    <XmlIgnore()>
    Public Property output() As Short
    <XmlIgnore()>
    Public Property agricultural() As Short

    <XmlElement("socioIndustrial")>
    Public Property socioIndustrial() As String

    <XmlElement("hpg")>
    Public Property hpg() As String

    Public Function ShouldSerializehpg() As Boolean

        Return Not (hpg() Is Nothing)

    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Planet))
    End Function

    Public Overloads Function Equals(other As Planet) As Boolean Implements IEquatable(Of Planet).Equals
        Return other IsNot Nothing AndAlso
               name = other.name AndAlso
               id = other.id
    End Function

    <XmlElement("faction")>
    Public Property faction() As String

    <XmlElement("icon")>
    Public Property icon() As String
    'If the planet already has a description
    <XmlIgnore()>
    Public Property lore() As Boolean
    'Special features & occupancy 
    <XmlIgnore()>
    Public Property SFO() As String

    <XmlElement("desc")>
    Public Property desc() As String

    <XmlElement("event")>
    Public Property Pevent() As Pevent()

    Public Shared Operator =(planet1 As Planet, planet2 As Planet) As Boolean
        Return EqualityComparer(Of Planet).Default.Equals(planet1, planet2)
    End Operator

    Public Shared Operator <>(planet1 As Planet, planet2 As Planet) As Boolean
        Return Not planet1 = planet2
    End Operator

    Public Shared Narrowing Operator CType(obj As Planet) As EPlanet
        Return New EPlanet With {
            .id = obj.name,
            .event = obj.Pevent.Cast(Of Eevent).ToArray()
        }
    End Operator
End Class

<Serializable,
 ComponentModel.DesignerCategory("event"),
 XmlType(AnonymousType:=True),
 XmlRoot("event", IsNullable:=False)>
Partial Public Class Pevent

    <XmlElement(DataType:="date")>
    Public Property [date]() As Date

    <XmlElement("faction")>
    Public Property faction() As String

    Public Shared Widening Operator CType(obj As Pevent) As Eevent
        Return New Eevent With {
            .date = obj.date,
            .faction = obj.faction
        }
    End Operator

End Class
