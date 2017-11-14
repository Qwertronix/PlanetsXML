Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Class objPlanets

    Const G As Decimal = 6.67 * (10 ^ -11)

    Private nt As DataTable = NameTable.nameTable()
    Private vt As DataTable = StarTable.vacuumTable()
    Private tt As DataTable = StarTable.traceTable()
    Private tht As DataTable = StarTable.thinTable()
    Private st As DataTable = StarTable.standardTable()
    Private ht As DataTable = StarTable.highTable()
    Private vht As DataTable = StarTable.veryhighTable()

    Private Shared ReadOnly r As New Random()

    Private Sub serialPlanets()

        Dim serial As New XmlSerializer(GetType(Planets))
        Dim infoserial As New XmlSerializer(GetType(Info.Planet))
        Dim p As New Planets
        Dim info As New Info
        Dim reader As XmlReader = XmlReader.Create(My.Application.Info.DirectoryPath & "\Planets\planetsTemplate.xml")
        While reader.Read()

            p = serial.Deserialize(reader)

        End While
        reader.Close()
        Dim Wsettings As XmlWriterSettings = New XmlWriterSettings()
        Wsettings.Indent = True
        Wsettings.IndentChars = (ControlChars.Tab)
        Wsettings.ConformanceLevel = ConformanceLevel.Document
        Wsettings.WriteEndDocumentOnClose = True
        Dim iterator As Integer = 0

        For Each planet In p.planet()

            iterator += 1
            Dim filepath As String
            Dim iPlanet As New Info.Planet
            iPlanet.id = planet.name()
            filepath = "\Planets\" & String.Format("{0:0000}", iterator) & "_" & iPlanet.id() & ".xml"
            Console.WriteLine(filepath)
            'If planet already has lore
            If String.IsNullOrEmpty(planet.desc()) = False Then
                Console.WriteLine(planet.name() & " has lore")
                planet.lore = True

            Else
                Console.WriteLine(planet.name() & " does not have lore")
                planet.lore = False

            End If
            'If class empty but type is not
            If String.IsNullOrEmpty(planet.spectralClass()) = True AndAlso String.IsNullOrEmpty(planet.spectralType()) = False Then

                planet.spectralClass = planet.spectralType().Substring(0, 1)
                Console.WriteLine(planet.name() & " star class= " & planet.spectralClass() & " type was defined")

            Else

            End If
            'If class and type are empty
            If String.IsNullOrEmpty(planet.spectralClass()) = True AndAlso String.IsNullOrEmpty(planet.spectralType()) = True Then

                planet.spectralClass = getSC()
                Console.WriteLine(planet.name() & " star class= " & planet.spectralClass() & " generated")

            Else
                Console.WriteLine(planet.name() & " star class= " & planet.spectralClass())
            End If
            'If subtype is empty but type is not
            If (planet.subtype() Is Nothing) AndAlso String.IsNullOrEmpty(planet.spectralType()) = False Then

                planet.subtype = planet.spectralType().Substring(1, 1)
                Console.WriteLine(planet.name() & " star subtype= " & planet.subtype() & " type was defined")

            Else

            End If
            'If subtype and type are empty
            If (planet.subtype() Is Nothing) AndAlso String.IsNullOrEmpty(planet.spectralType()) = True Then

                planet.subtype = getST()
                Console.WriteLine(planet.name() & " star subtype= " & planet.subtype() & " generated")

            Else
                Console.WriteLine(planet.name() & " star subtype= " & planet.subtype())
            End If
            'If luminosity is empty but type is not
            If String.IsNullOrEmpty(planet.luminosity()) = True AndAlso String.IsNullOrEmpty(planet.spectralType()) = False Then

                planet.luminosity = planet.spectralType().Substring(2, 2)
                Console.WriteLine(planet.name() & " star luminosity= " & planet.luminosity() & " type was defined")

            Else

            End If
            'If luminosity and type are empty
            If String.IsNullOrEmpty(planet.luminosity()) = True AndAlso String.IsNullOrEmpty(planet.spectralType()) = True Then

                planet.luminosity = getL(planet)
                Console.WriteLine(planet.name() & " star luminosity= " & planet.luminosity() & " generated")

            Else
                Console.WriteLine(planet.name() & " star luminosity= " & planet.luminosity())
            End If
            'If type is empty
            If String.IsNullOrEmpty(planet.spectralType()) = True Then

                planet.spectralType = planet.spectralClass() & planet.subtype() & planet.luminosity()
                Console.WriteLine(planet.name() & " star type= " & planet.spectralType() & " generated")

            Else
                Console.WriteLine(planet.name() & " star type= " & planet.spectralType())
            End If
            'Determine planet's diam, mass, escapeV, and gravity
            If planet.name() = "Terra" Then

                planet.diameter = 1.2756 * (10 ^ 7) 'km
                planet.pMass = 5.98 * (10 ^ 24) 'kg
                planet.volume = 1.08678 * (10 ^ 27) 'cubic centimeters
                planet.density = 5.502487061 'g per cubic centimeter
                planet.escapeV = 1.12 * (10 ^ 4) 'km per second

            ElseIf planet.type() = "spacestation" Then

            ElseIf planet.gravity() Is Nothing Then

                planet.diameter = getDiameter()
                planet.pMass = getMass()
                planet.volume = ((4 / 3) * Math.PI * ((planet.diameter() / 2) ^ 3)) * (10 ^ 6) 'cubic centimeters
                planet.density = (planet.pMass() * (10 ^ 3)) / planet.volume() 'g per cubic centimeter
                planet.escapeV = getEscapeV(planet)
                planet.gravity = getGravity(planet)
                Console.WriteLine(planet.name() & " Gravity= " & planet.gravity() & " generated")

            ElseIf planet.gravity() IsNot Nothing Then

                planet.pMass = getMass()
                planet.diameter = Math.Sqrt((G * planet.pMass()) / (planet.gravity() * 9.81)) * 2
                planet.volume = ((4 / 3) * Math.PI * ((planet.diameter() / 2) ^ 3)) * (10 ^ 6) 'cubic centimeters
                planet.density = (planet.pMass() * (10 ^ 3)) / planet.volume() 'g per cubic centimeter
                planet.escapeV = getEscapeV(planet)
                Console.WriteLine(planet.name() & " Gravity= " & planet.gravity())

            Else
                iPlanet.mass = planet.pMass()
                iPlanet.radius = (planet.diameter() / 2) / (6.378 * (10 ^ 6)) 'radius compared to Earth
                iPlanet.density = planet.density() * (10 ^ 3) 'g per cubic meter
            End If
            'Determine a planet's pressure
            If planet.type() = "spacestation" Then

            ElseIf Planet.type() = "asteroidfield" Then

                planet.pressure = 0

            ElseIf planet.pressure() Is Nothing AndAlso planet.lore() = False Then

                planet.pressure = getPressure(planet)
                Console.WriteLine(planet.name() & " Atmosphere= " & planet.pressure() & " generated")

            ElseIf planet.pressure() Is Nothing AndAlso planet.lore() = True Then

                planet.pressure = 3
                Console.WriteLine(planet.name() & " Atmosphere= " & planet.pressure() & " generated")
            Else
                Console.WriteLine(planet.name() & " Atmosphere= " & planet.pressure())
            End If
            iPlanet.pressureAtm = planet.pressure() / 3
            'Determine system position based on atmosphere
            If planet.sysPos() Is Nothing Then

                planet.sysPos = getSP(planet)
                Console.WriteLine(planet.name() & " SysPos= " & planet.sysPos() & " generated")

            ElseIf planet.sysPos() IsNot Nothing AndAlso planet.temperature() Is Nothing Then

                planet.sysPos = getSP(planet)
                Console.WriteLine(planet.name() & " SysPos= " & planet.sysPos() & " generated to find AU from star")

            Else
                Console.WriteLine(planet.name() & " SysPos= " & planet.sysPos())
            End If
            'Determine planet's temp from system position and atmosphere
            If planet.type() = "spacestation" Then

            ElseIf planet.temperature() Is Nothing Then

                planet.temperature = getTemp(planet)
                Console.WriteLine(planet.name() & " Temp= " & planet.temperature() & " generated")

            Else
                Console.WriteLine(planet.name() & " Temp= " & planet.temperature())
            End If
            'Determine planet's highest life form
            If planet.type() = "spacestation" OrElse planet.type() = "asteroidfield" Then

            ElseIf planet.lifeForm() Is Nothing AndAlso planet.pressure() >= 2 Then

                planet.lifeForm = getLF(planet)
                Console.WriteLine(planet.name() & " life form= " & planet.lifeForm() & " generated")

            ElseIf planet.lifeForm() Is Nothing AndAlso planet.pressure() < 2 Then

                planet.lifeForm = 0
                Console.WriteLine(planet.name() & " life form= " & planet.lifeForm() & " generated")

            Else
                Console.WriteLine(planet.name() & " life form= " & planet.lifeForm())
            End If
            'Determine planet's percent water coverage
            If planet.type() = "spacestation" Then

            ElseIf planet.percentWater() Is Nothing AndAlso planet.pressure() >= 2 Then

                planet.percentWater = getPW(planet)
                Console.WriteLine(planet.name() & " percent water= " & planet.percentWater() & " generated")

            ElseIf planet.percentWater() Is Nothing AndAlso planet.pressure() < 2 Then
                planet.percentWater = 0
                Console.WriteLine(planet.name() & " percent water= " & planet.percentWater() & " generated")

            Else
                Console.WriteLine(planet.name() & " percent water= " & planet.percentWater())
            End If
            'Determine planet's climate off temperature
            If planet.type() = "spacestation" OrElse planet.type() = "asteroidfield" Then

            ElseIf String.IsNullOrEmpty(planet.climate()) = True Then

                planet.climate = getClimate(planet)
                Console.WriteLine(planet.name() & " climate= " & planet.climate() & " generated")

            Else
                Console.WriteLine(planet.name() & " climate= " & planet.climate())
            End If
            'Determine if axis tilt is enough to cause seasons
            If planet.type() = "spacestation" OrElse planet.type() = "asteroidfield" Then

            ElseIf String.IsNullOrEmpty(planet.axis()) = True Then

                planet.axis = getAxis()
                Console.WriteLine(planet.name() & " Axis= " & planet.axis() & " generated")

            Else

            End If
            'Determine if elliptical orbit is enough to cause seasons
            If planet.type() = "spacestation" OrElse planet.type() = "asteroidfield" Then

            ElseIf String.IsNullOrEmpty(planet.orbit()) = True Then

                planet.orbit = getOrbit()
                Console.WriteLine(planet.name() & " Orbit= " & planet.orbit() & " generated")

            Else

            End If
            'Determine planet's moons / rings
            If planet.type() = "spacestation" OrElse planet.type() = "asteroidfield" Then

            ElseIf planet.satellite() Is Nothing AndAlso planet.landMass() IsNot Nothing Then

            ElseIf planet.satellite() Is Nothing Then

                Dim s As Integer = getMoons(planet)
                If s > 0 AndAlso planet.rings() = False Then

                    For i = 0 To (s - 1)

                        ReDim Preserve planet.satellite(i + 1)
                        Dim name As String = getMoonsName(planet)
                        While planet.satellite().Contains(name) = True

                            name = getMoonsName(planet)

                        End While
                        planet.satellite(i) = name
                        Console.WriteLine(planet.name() & " satellite= " & planet.satellite(i) & " generated")

                    Next

                ElseIf s > 0 AndAlso planet.rings() = True Then

                    ReDim Preserve planet.satellite(1)
                    planet.satellite(0) = "Ring System"

                    For i = 1 To (s)

                        ReDim Preserve planet.satellite(i + 1)
                        Dim name As String = getMoonsName(planet)
                        While planet.satellite().Contains(name) = True

                            name = getMoonsName(planet)

                        End While
                        planet.satellite(i) = name
                        Console.WriteLine(planet.name() & " satellite= " & planet.satellite(i) & " generated")

                    Next

                Else

                End If

            Else
                Console.WriteLine(planet.name() & " satellite(s) already defined")
            End If
            'Determine planet's land masses
            If planet.type() = "spacestation" OrElse planet.type() = "asteroidfield" Then

            ElseIf planet.landMass() Is Nothing Then

                Dim lm As Integer = getLM(planet)
                If lm > 0 Then

                    For i = 0 To (lm - 1)

                        ReDim Preserve planet.landMass(i + 1)
                        Dim name As String = getLMName(planet)
                        While planet.landMass().Contains(name) = True

                            name = getLMName(planet)

                        End While
                        planet.landMass(i) = name
                        Console.WriteLine(planet.name() & " land mass= " & planet.landMass(i) & " generated")

                    Next

                End If

            Else
                Console.WriteLine(planet.name() & " land mass(es) already defined")
            End If
            'If faction is empty then it's undiscovered
            If String.IsNullOrEmpty(planet.faction()) = True Then

                planet.faction = "UND"
                Console.WriteLine(planet.name() & " Faction= " & planet.faction() & " generated")

            Else

            End If
            'Determine planet's atmospheric composition
            If planet.lore() = False AndAlso planet.pressure() >= 2 Then

                planet.AC = getAC(planet)
                Console.WriteLine(planet.name() & planet.AC() & " generated")
            ElseIf planet.lore() = False AndAlso planet.pressure() < 2 Then

                planet.AC = " has none / a toxic atmosphere"
                Console.WriteLine(planet.name() & planet.AC() & " generated")

            ElseIf planet.lore() = True AndAlso planet.pressure() >= 2 Then

                planet.AC = " has a breathable atmosphere"
                Console.WriteLine(planet.name() & planet.AC() & " generated")
            ElseIf planet.lore() = True AndAlso planet.pressure() < 2 Then

                planet.AC = " has none / a toxic atmosphere"
                Console.WriteLine(planet.name() & planet.AC() & " generated")
            Else

            End If
            'Determine a planet's special features & occupancy
            If planet.type() = "spacestation" Then

            ElseIf planet.lore() = True Then

            Else

                Dim a As String = planet.AC()
                Dim sf As String = getSF(planet)
                planet.SF = sf
                Console.WriteLine(planet.name() & planet.SF() & " generated")
                If sf = " experiences intense volcanic activity" AndAlso a = " has a breathable atmosphere" Then
                    planet.AC = " has a tainted atmosphere"
                    Console.WriteLine(planet.name() & " volcanic activity changes atmosphere to tainted")

                Else

                End If

            End If
            'Determine a planet's population
            planet.population = getPop(planet)
            Console.WriteLine(planet.name() & " initial population= " & String.Format("{0:n0}", planet.population()) & " generated")
            planet.population = getPopMod(planet)
            Console.WriteLine(planet.name() & " modified population= " & String.Format("{0:n0}", planet.population()) & " generated")
            'Determine a planet's USILR scores and codes
            If String.IsNullOrEmpty(planet.socioIndustrial()) = True Then

                planet.tech = getTech(planet)
                Console.WriteLine(planet.name() & " tech score= " & planet.tech() & " generated")
                planet.development = getDev(planet)
                Console.WriteLine(planet.name() & " development score= " & planet.development() & " generated")
                planet.output = getOutput(planet)
                Console.WriteLine(planet.name() & " output score= " & planet.output() & " generated")
                planet.material = getMaterial(planet)
                Console.WriteLine(planet.name() & " material score= " & planet.material() & " generated")
                planet.agricultural = getAgricultural(planet)
                Console.WriteLine(planet.name() & " agricultural score= " & planet.agricultural() & " generated")
                planet.socioIndustrial = getUSILR(planet.tech()) & "-" & getUSILR(planet.development()) & "-" & getUSILR(planet.material()) & "-" _
                    & getUSILR(planet.output()) & "-" & getUSILR(planet.agricultural())
                Console.WriteLine(planet.name() & " USILR= " & planet.socioIndustrial() & " generated")

            ElseIf String.IsNullOrEmpty(planet.socioIndustrial()) = False Then

                Dim tcode As String = planet.socioIndustrial().Substring(0, 1)
                Dim tscore As Integer = getScore(tcode)
                Dim dcode As String = planet.socioIndustrial().Substring(2, 1)
                Dim dscore As Integer = getScore(dcode)
                Dim ocode As String = planet.socioIndustrial().Substring(4, 1)
                Dim oscore As Integer = getScore(ocode)
                Dim mcode As String = planet.socioIndustrial().Substring(6, 1)
                Dim mscore As Integer = getScore(mcode)
                Dim acode As String = planet.socioIndustrial().Substring(8, 1)
                Dim ascore As Integer = getScore(acode)
                planet.tech = tscore
                Console.WriteLine(planet.name() & " tech score= " & planet.tech() & " generated")
                planet.development = dscore
                Console.WriteLine(planet.name() & " development score= " & planet.development() & " generated")
                planet.output = oscore
                Console.WriteLine(planet.name() & " output score= " & planet.output() & " generated")
                planet.material = mscore
                Console.WriteLine(planet.name() & " material score= " & planet.material() & " generated")
                planet.agricultural = ascore
                Console.WriteLine(planet.name() & " agricultural score= " & planet.agricultural() & " generated")

            End If
            'Populate planet's description
            If String.Compare(planet.name(), "Terra", True) = 0 Then

                Dim di As Decimal = planet.diameter()
                Dim sdi As Decimal = 1.2756 * (10 ^ 7)
                Dim v As Decimal = planet.volume()
                Dim sv As Decimal = 1.08678 * (10 ^ 27)
                Dim dn As Decimal = planet.density()
                Dim sdn As Decimal = 5.502487061
                Dim ev As Decimal = planet.escapeV()
                Dim ax As String = " has seasons due to an axial tilt"
                Dim ob As String = " has a circular orbit"
                Dim ac As String = " has a breathable atmosphere"
                Dim po As Long = 12350000000
                planet.tech = 0
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim ad As String = getAdesc(planet)
                Dim de As String = planet.desc()

                planet.desc = planet.name() & " has a diameter of " & String.Format("{0:n0}", (di / 1000)) & "km(" & String.Format("{0:n2}", di / sdi) & " of standard), has a density of " & String.Format("{0:n3}", dn) & "g/cm3(" & String.Format("{0:n2}", dn / sdn) & " of standard), and has an escape velocity of " & String.Format("{0:n3}", (ev / 1000)) & "km/s" & "." _
                    & Environment.NewLine & Environment.NewLine & planet.name() & ax & "," & ob & "," & ac & ", and has a population of " & String.Format("{0:n0}", po) & "." _
                    & Environment.NewLine & Environment.NewLine & planet.name() & td & " world," & dd & "," & md & "," & od & ", and" & ad & " world." _
                    & Environment.NewLine & Environment.NewLine & de

            ElseIf planet.type() = "spacestation" AndAlso planet.lore() = False Then

                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)

                planet.desc = planet.name() & " has a population of " & String.Format("{0:n0}", po) & "," & td & " space station," & dd & "," & md & ", and" & od & ".(Non-Canon)"

            ElseIf planet.type() = "spacestation" AndAlso planet.lore() = True Then

                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim de As String = planet.desc()

                planet.desc = planet.name() & " has a population of " & String.Format("{0:n0}", po) & "," & td & " space station," & dd & "," & md & ", and" & od & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & de

            ElseIf planet.type() = "asteroidfield" AndAlso String.IsNullOrEmpty(planet.SF()) = True AndAlso planet.lore() = False Then

                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)

                planet.desc = planet.name() & " has a population of " & String.Format("{0:n0}", po) & "," & td & " asteroid field," & dd & "," & md & ", and" & od & ".(Non-Canon)"

            ElseIf planet.type() = "asteroidfield" AndAlso String.IsNullOrEmpty(planet.SF()) = True AndAlso planet.lore() = True Then

                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim de As String = planet.desc()

                planet.desc = planet.name() & " has a population of " & String.Format("{0:n0}", po) & "," & td & " asteroid field," & dd & "," & md & ", and" & od & ".(Non-Canon)" _
                        & Environment.NewLine & Environment.NewLine & de

            ElseIf planet.type() = "asteroidfield" AndAlso String.IsNullOrEmpty(planet.SF()) = False AndAlso planet.lore() = False Then

                Dim sf As String = planet.SF()
                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)

                planet.desc = planet.name() & " has a population of " & String.Format("{0:n0}", po) & "," & sf & "," & td & " asteroid field," & dd & "," & md & ", and" & od & ".(Non-Canon)"

            ElseIf planet.type() = "asteroidfield" AndAlso String.IsNullOrEmpty(planet.SF()) = False AndAlso planet.lore() = True Then

                Dim sf As String = planet.SF()
                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim de As String = planet.desc()

                planet.desc = planet.name() & " has a population of " & String.Format("{0:n0}", po) & "," & sf & "," & td & " asteroid field," & dd & "," & md & ", and" & od & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & de

            ElseIf String.IsNullOrEmpty(planet.SF()) = True AndAlso planet.lore() = False Then

                Dim di As Decimal = planet.diameter()
                Dim sdi As Decimal = 1.2756 * (10 ^ 7)
                Dim v As Decimal = planet.volume()
                Dim sv As Decimal = 1.08678 * (10 ^ 27)
                Dim dn As Decimal = planet.density()
                Dim sdn As Decimal = 5.502487061
                Dim ev As Decimal = planet.escapeV()
                Dim ax As String = planet.axis()
                Dim ob As String = planet.orbit()
                Dim ac As String = planet.AC()
                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim ad As String = getAdesc(planet)

                planet.desc = planet.name() & " has a diameter of " & String.Format("{0:n0}", (di / 1000)) & "km(" & String.Format("{0:n2}", di / sdi) & " of standard), has a density of " & String.Format("{0:n3}", dn) & "g/cm3(" & String.Format("{0:n2}", dn / sdn) & " of standard), and has an escape velocity of " & String.Format("{0:n3}", (ev / 1000)) & "km/s" & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & ax & "," & ob & "," & ac & ", and has a population of " & String.Format("{0:n0}", po) & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & td & " world," & dd & "," & md & "," & od & ", and" & ad & " world.(Non-Canon)"

            ElseIf String.IsNullOrEmpty(planet.SF()) = True AndAlso planet.lore() = True Then

                Dim di As Decimal = planet.diameter()
                Dim sdi As Decimal = 1.2756 * (10 ^ 7)
                Dim v As Decimal = planet.volume()
                Dim sv As Decimal = 1.08678 * (10 ^ 27)
                Dim dn As Decimal = planet.density()
                Dim sdn As Decimal = 5.502487061
                Dim ev As Decimal = planet.escapeV()
                Dim ax As String = planet.axis()
                Dim ob As String = planet.orbit()
                Dim ac As String = planet.AC()
                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim ad As String = getAdesc(planet)
                Dim de As String = planet.desc()

                planet.desc = planet.name() & " has a diameter of " & String.Format("{0:n0}", (di / 1000)) & "km(" & String.Format("{0:n2}", di / sdi) & " of standard), has a density of " & String.Format("{0:n3}", dn) & "g/cm3(" & String.Format("{0:n2}", dn / sdn) & " of standard), and has an escape velocity of " & String.Format("{0:n3}", (ev / 1000)) & "km/s" & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & ax & "," & ob & "," & ac & ", and has a population of " & String.Format("{0:n0}", po) & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & td & " world," & dd & "," & md & "," & od & ", and" & ad & " world.(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & de

            ElseIf String.IsNullOrEmpty(planet.SF()) = False AndAlso planet.lore() = False Then

                Dim di As Decimal = planet.diameter()
                Dim sdi As Decimal = 1.2756 * (10 ^ 7)
                Dim v As Decimal = planet.volume()
                Dim sv As Decimal = 1.08678 * (10 ^ 27)
                Dim dn As Decimal = planet.density()
                Dim sdn As Decimal = 5.502487061
                Dim ev As Decimal = planet.escapeV()
                Dim ax As String = planet.axis()
                Dim ob As String = planet.orbit()
                Dim ac As String = planet.AC()
                Dim sf As String = planet.SF()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim ad As String = getAdesc(planet)
                Dim po As Long = planet.population()

                planet.desc = planet.name() & " has a diameter of " & String.Format("{0:n0}", (di / 1000)) & "km(" & String.Format("{0:n2}", di / sdi) & " of standard), has a density of " & String.Format("{0:n3}", dn) & "g/cm3(" & String.Format("{0:n2}", dn / sdn) & " of standard), and has an escape velocity of " & String.Format("{0:n3}", (ev / 1000)) & "km/s" & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & ax & "," & ob & "," & ac & "," & sf & ", and has a population of " & String.Format("{0:n0}", po) & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & td & " world," & dd & "," & md & "," & od & ", and" & ad & " world.(Non-Canon)"

            Else

                Dim di As Decimal = planet.diameter()
                Dim sdi As Decimal = 1.2756 * (10 ^ 7)
                Dim v As Decimal = planet.volume()
                Dim sv As Decimal = 1.08678 * (10 ^ 27)
                Dim dn As Decimal = planet.density()
                Dim sdn As Decimal = 5.502487061
                Dim ev As Decimal = planet.escapeV()
                Dim ax As String = planet.axis()
                Dim ob As String = planet.orbit()
                Dim ac As String = planet.AC()
                Dim sf As String = planet.SF()
                Dim po As Long = planet.population()
                Dim td As String = getTdesc(planet)
                Dim dd As String = getDdesc(planet)
                Dim md As String = getMdesc(planet)
                Dim od As String = getOdesc(planet)
                Dim ad As String = getAdesc(planet)
                Dim de As String = planet.desc()

                planet.desc = planet.name() & " has a diameter of " & String.Format("{0:n0}", (di / 1000)) & "km(" & String.Format("{0:n2}", di / sdi) & " of standard), has a density of " & String.Format("{0:n3}", dn) & "g/cm3(" & String.Format("{0:n2}", dn / sdn) & " of standard), and has an escape velocity of " & String.Format("{0:n3}", (ev / 1000)) & "km/s" & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & ax & "," & ob & "," & ac & "," & sf & ", and has a population of " & String.Format("{0:n0}", po) & ".(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & planet.name() & td & " world," & dd & "," & md & "," & od & ", and" & ad & " world.(Non-Canon)" _
                    & Environment.NewLine & Environment.NewLine & de

            End If

            Application.DoEvents()
            Dim infowriter As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & filepath, Wsettings)
            infoserial.Serialize(infowriter, iPlanet)
            infowriter.Flush()
            infowriter.Close()

        Next

        Dim writer As XmlWriter = XmlWriter.Create(My.Application.Info.DirectoryPath & "\Planets\planets.xml", Wsettings)
        serial.Serialize(writer, p)
        writer.Flush()
        writer.Close()

    End Sub

    Private Function getSC() As String

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2 To 4

                Return "M"

            Case 5 To 6

                Return "K"

            Case 7 To 8

                Return "G"

            Case 9 To 11

                Return "F"

            Case 12

                Return getHotStars()

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getHotStars() As String

        Dim r As Integer = roll2D6()

        If r >= 7 Then

            Return "F"

        Else

            Dim rr As Integer = roll2D6()
            Select Case rr

                Case 2 To 3

                    Return "B"

                Case 4 To 10

                    Return "A"

                Case 11

                    Return "B"

                Case 12

                    Return "F"

                Case Else

                    Return "Error"

            End Select

        End If

    End Function

    Private Function getST() As Integer

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2, 12

                Return 9

            Case 3

                Return 7

            Case 4

                Return 5

            Case 5

                Return 3

            Case 6

                Return 1

            Case 7

                Return 0

            Case 8

                Return 2

            Case 9

                Return 4

            Case 10

                Return 6

            Case 11

                Return 8

            Case Else

                Return 99

        End Select

    End Function

    Private Function getL(planet) As String

        Dim r As Integer = roll2D6()

        If String.Compare(planet.SpectralClass(), "M", True) = 0 AndAlso (r = 2 OrElse r = 4) Then

            While r = 2 OrElse r = 4
                r = roll2D6()
            End While

        ElseIf String.Compare(planet.SpectralClass(), "K", True) = 0 AndAlso planet.subtype() >= 4 AndAlso r = 4 Then

            While r = 4
                r = roll2D6()
            End While

        Else

        End If

        Select Case r

            Case 2

                Return "VII"

            Case 3

                Return "VI"

            Case 4

                Return "IV"

            Case 5 To 8

                Return "V"

            Case 9

                Return "III"

            Case 10

                Return "II"

            Case 11

                Return "Ib"

            Case 12

                Return "Ia"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getDiameter() As Decimal

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2
                '75% Earth
                Return 9.567 * (10 ^ 6)

            Case 3

                Return 1.02048 * (10 ^ 7)

            Case 4

                Return 1.08426 * (10 ^ 7)

            Case 5

                Return 1.114804 * (10 ^ 7)

            Case 6

                Return 1.21182 * (10 ^ 7)

            Case 7
                'Earth in meters
                Return 1.2756 * (10 ^ 7)

            Case 8

                Return 1.33938 * (10 ^ 7)

            Case 9

                Return 1.40316 * (10 ^ 7)

            Case 10

                Return 1.46694 * (10 ^ 7)

            Case 11

                Return 1.53072 * (10 ^ 7)

            Case 12
                '125% Earth
                Return 1.5945 * (10 ^ 7)

            Case Else

                Return 0

        End Select

    End Function

    Private Function getMass() As Decimal

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2
                '75% Earth
                Return 4.485 * (10 ^ 24)

            Case 3

                Return 4.784 * (10 ^ 24)

            Case 4

                Return 5.083 * (10 ^ 24)

            Case 5

                Return 5.382 * (10 ^ 24)

            Case 6

                Return 5.681 * (10 ^ 24)

            Case 7
                'Earth in kg
                Return 5.98 * (10 ^ 24)

            Case 8

                Return 6.279 * (10 ^ 24)

            Case 9

                Return 6.578 * (10 ^ 24)

            Case 10

                Return 6.877 * (10 ^ 24)

            Case 11

                Return 7.176 * (10 ^ 24)

            Case 12
                '125% Earth
                Return 7.475 * (10 ^ 24)

            Case Else

                Return 0

        End Select

    End Function

    Private Function getEscapeV(planet) As Decimal
        'In meters / sec
        Return ((2 * G * planet.pMass()) / (planet.diameter() / 2)) ^ (1 / 2)

    End Function

    Private Function getGravity(planet) As Decimal

        Dim accel As Decimal = (G * planet.pMass()) / ((planet.diameter() / 2) ^ 2)
        Return Math.Round(accel / 9.81, 2, MidpointRounding.AwayFromZero)

    End Function

    Private Function getPressure(planet) As Integer

        Dim r As Integer = roll2D6()
        Dim EV As Decimal = planet.escapeV()
        Dim V As Decimal = 1.12 * (10 ^ 4) 'meters / sec
        Dim rM As Integer = Math.Round((EV / V) * r, 0, MidpointRounding.AwayFromZero)
        Select Case rM

            Case <= 3
                'Vacuum
                Return 0

            Case 4
                'Trace
                Return 1

            Case 5 To 6
                'Thin
                Return 2

            Case 7 To 8
                'Standard
                Return 3

            Case 9 To 10
                'High
                Return 4

            Case >= 11
                'Very High
                Return 5

            Case Else

                Return 99

        End Select

    End Function

    Private Function getSP(planet) As Integer

        Dim table As DataTable = getStarTable(planet.pressure())
        Dim expression As String = "[Spectral Type] = " & "'" & planet.spectralType() & "'"
        Dim selectRow As DataRow()
        selectRow = table.Select(expression)
        Dim mass As Decimal = selectRow(0)(1)
        planet.mass = mass
        Dim innerLife As Decimal = selectRow(0)(3)
        planet.innerLife = innerLife
        Dim outerLife As Decimal = selectRow(0)(4)
        planet.outerLife = outerLife
        getOrbitals(planet, table, mass, innerLife, outerLife)
        Dim arraySlots() As Decimal = {planet.slot1(), planet.slot2(), planet.slot3(), planet.slot4(), planet.slot5(), planet.slot6(), planet.slot7(),
            planet.slot8(), planet.slot9(), planet.slot10(), planet.slot11(), planet.slot12(), planet.slot13(), planet.slot14(), planet.slot15()}
        Dim rollSlots() As Decimal = getSlots(planet)
        For i = 0 To arraySlots.Length - 1

            arraySlots(i) = rollSlots(i)

        Next

        Dim checkLife As Decimal = Array.Find(arraySlots, Function(slot)

                                                              Return slot >= innerLife AndAlso slot <= outerLife

                                                          End Function)

        If checkLife = 0 Then

            While checkLife = 0

                rollSlots = getSlots(planet)
                For i = 0 To arraySlots.Length - 1

                    arraySlots(i) = rollSlots(i)

                Next
                checkLife = Array.Find(arraySlots, Function(slot)

                                                       Return slot >= innerLife AndAlso slot <= outerLife

                                                   End Function)

            End While

        Else

        End If

        planet.slot1 = arraySlots(0)
        planet.slot2 = arraySlots(1)
        planet.slot3 = arraySlots(2)
        planet.slot4 = arraySlots(3)
        planet.slot5 = arraySlots(4)
        planet.slot6 = arraySlots(5)
        planet.slot7 = arraySlots(6)
        planet.slot8 = arraySlots(7)
        planet.slot9 = arraySlots(8)
        planet.slot10 = arraySlots(9)
        planet.slot11 = arraySlots(10)
        planet.slot12 = arraySlots(11)
        planet.slot13 = arraySlots(12)
        planet.slot14 = arraySlots(13)
        planet.slot15 = arraySlots(14)

        Dim p As Integer = getRandom15()
        Dim distance As Decimal = arraySlots(p - 1)
        If distance < innerLife OrElse distance > outerLife Then

            While distance < innerLife OrElse distance > outerLife

                p = getRandom15()

                distance = arraySlots(p - 1)

            End While

        Else

        End If

        Return p

    End Function

    Private Function getStarTable(pressure As Integer)

        Select Case pressure

            Case 0

                Return vt

            Case 1

                Return tt

            Case 2

                Return tht

            Case 3

                Return st

            Case 4

                Return ht

            Case 5

                Return vht

            Case Else

                Return 99

        End Select

    End Function

    Private Sub getOrbitals(ByRef planet As Object, ByVal table As DataTable, ByRef mass As Decimal, ByRef innerLife As Decimal, ByRef outerLife As Decimal)

        Dim expression As String
        Dim selectRow As DataRow()



        If ((((4 / 3) ^ 2) ^ (1 / 3) * mass) * 0.25) > outerLife Then

            While ((((4 / 3) ^ 2) ^ (1 / 3) * mass) * 0.25) > outerLife

                planet.spectralClass = getSC()
                planet.subtype = getST()
                planet.luminosity = getL(planet)
                planet.spectralType = planet.spectralClass() & planet.subtype() & planet.luminosity()
                expression = "[Spectral Type] = " & "'" & planet.spectralType() & "'"
                selectRow = table.Select(expression)
                mass = selectRow(0)(1)
                innerLife = selectRow(0)(3)
                outerLife = selectRow(0)(4)
                planet.mass = mass
                planet.innerLife = innerLife
                planet.outerLife = outerLife

            End While

        Else

        End If

    End Sub

    Private Function getResonance() As Decimal

        Dim r As Integer = roll1D10()
        Select Case r

            Case 1

                Return ((4 / 3) ^ 2) ^ (1 / 3)

            Case 2

                Return ((3 / 2) ^ 2) ^ (1 / 3)

            Case 3

                Return ((8 / 5) ^ 2) ^ (1 / 3)

            Case 4

                Return ((5 / 3) ^ 2) ^ (1 / 3)

            Case 5

                Return ((7 / 4) ^ 2) ^ (1 / 3)

            Case 6

                Return ((9 / 5) ^ 2) ^ (1 / 3)

            Case 7

                Return ((2 / 1) ^ 2) ^ (1 / 3)

            Case 8

                Return ((7 / 3) ^ 2) ^ (1 / 3)

            Case 9

                Return ((5 / 2) ^ 2) ^ (1 / 3)

            Case 10

                Return ((3 / 1) ^ 2) ^ (1 / 3)

            Case Else

                Return 0

        End Select

    End Function

    Private Function getSlots(planet) As Array

        Dim Slots(14) As Decimal

        For i = 0 To Slots.Length - 1

            If i = 0 Then

                Slots(0) = getResonance() * planet.mass() * 0.25

            Else

                Slots(i) = getResonance() * Slots(i - 1)

            End If

        Next

        Return Slots

    End Function

    Private Function getRandom15() As Integer

        Return r.Next(1, 16)

    End Function

    Private Function getTemp(planet) As Integer

        Dim table As DataTable = getStarTable(planet.pressure())
        Dim expression As String = "[Spectral Type] = " & "'" & planet.spectralType() & "'"
        Dim selectRow As DataRow()
        selectRow = table.Select(expression)
        Dim lum As Decimal = selectRow(0)(2)
        planet.lum = lum
        Dim arraySlots() As Decimal = {planet.slot1(), planet.slot2(), planet.slot3(), planet.slot4(), planet.slot5(), planet.slot6(), planet.slot7(),
            planet.slot8(), planet.slot9(), planet.slot10(), planet.slot11(), planet.slot12(), planet.slot13(), planet.slot14(), planet.slot15()}
        Dim posIndex As Integer = planet.sysPos() - 1
        Dim distance As Decimal = arraySlots(posIndex)
        Dim solarOutput As Double = (3.864 * (10 ^ 26)) * lum * getAlbedo(planet.pressure())
        Dim divisor As Decimal = ((16 * Math.PI) * ((distance * 149597870700) ^ 2) * (5.670373 * (10 ^ -8)))
        Return Math.Round(((solarOutput / divisor) ^ 0.25) - 273, 0, MidpointRounding.AwayFromZero)

    End Function

    Private Function getAlbedo(pressure As Integer) As Decimal

        Select Case pressure

            Case 0

                Return 1

            Case 1

                Return 1.125

            Case 2

                Return 1.25

            Case 3

                Return 1.375

            Case 4

                Return 1.5

            Case 5

                Return 1.625

            Case Else

                Return 0

        End Select

    End Function

    Private Function getLF(planet) As Integer

        Dim r As Integer = roll2D6()
        Dim hm As Integer
        Dim table As DataTable = StarTable.standardTable()
        Dim expression As String = "[Spectral Type] = " & "'" & planet.spectralType() & "'"
        Dim selectRow As DataRow()
        selectRow = table.Select(expression)
        hm = selectRow(0)(5)
        Select Case (r + hm)

            Case Is < 0
                'None
                Return 0

            Case 0
                'Microbes
                Return 1

            Case 1
                'Plants
                Return 2

            Case 2
                'Insects
                Return 3

            Case 3 To 4
                'Fish
                Return 4

            Case 5 To 6
                'Amphibians
                Return 5

            Case 7 To 8
                'Reptiles
                Return 6

            Case 9 To 10
                'Birds
                Return 7

            Case Is >= 11
                'Mammals
                Return 8

            Case Else

                Return 99

        End Select

    End Function

    Private Function getPW(planet) As Integer

        Dim r As Integer = roll2D6()
        Dim EV As Decimal = planet.escapeV()
        Dim V As Decimal = 1.12 * (10 ^ 4)
        Dim inner As Decimal
        Dim outer As Decimal
        Dim arraySlots() As Decimal = {planet.slot1(), planet.slot2(), planet.slot3(), planet.slot4(), planet.slot5(), planet.slot6(), planet.slot7(),
            planet.slot8(), planet.slot9(), planet.slot10(), planet.slot11(), planet.slot12(), planet.slot13(), planet.slot14(), planet.slot15()}
        Dim slotIndex As Integer = planet.sysPos() - 1
        Dim pos As Decimal = arraySlots(slotIndex)
        Dim lzpm As Decimal
        Dim table As DataTable = getStarTable(planet.pressure())
        Dim expression As String = "[Spectral Type] = " & "'" & planet.spectralType() & "'"
        Dim selectRow As DataRow()
        selectRow = table.Select(expression)
        inner = selectRow(0)(3)
        outer = selectRow(0)(4)
        lzpm = (pos - inner) / (outer - inner)
        Dim rM As Integer = Math.Round(r * lzpm * (EV / V), 0, MidpointRounding.AwayFromZero)
        Select Case rM

            Case Is < 0

                Return 0

            Case 0

                Return 5

            Case 1

                Return 10

            Case 2

                Return 20

            Case 3

                Return 30

            Case 4

                Return 40

            Case 5

                Return 40

            Case 6

                Return 50

            Case 7

                Return 50

            Case 8

                Return 60

            Case 9

                Return 70

            Case 10

                Return 80

            Case 11

                Return 90

            Case Is >= 12

                Return 99

            Case Else

                Return 999

        End Select

    End Function

    Private Function getAC(planet) As String

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2 To 6

                Return " has a tainted atmosphere"

            Case Is >= 7

                Return " has a breathable atmosphere"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getClimate(planet) As String

        Dim t As Integer = planet.temperature()
        Select Case t

            Case Is < -5

                Return "ARCTIC"

            Case -5 To 4

                Return "BOREAL"

            Case 5 To 14

                Return "TEMPERATE"

            Case 15 To 24

                Return "WARM"

            Case 25 To 34

                Return "TROPICAL"

            Case 35 To 44

                Return "SUPERTROPCIAL"

            Case Is > 44

                Return "HELL"

            Case Else

                Return "NA"

        End Select

    End Function

    Private Function getAxis() As String

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2 To 6

                Return " has seasons due to an axial tilt"

            Case 7 To 12

                Return " has minimal or no axial tilt"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getOrbit() As String

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2 To 6

                Return " has short summers and long winters due to an elliptical orbit"

            Case 7 To 12

                Return " has a circular orbit"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getLM(planet) As Integer

        Dim r As Integer = roll1D6()
        Dim d As Decimal = planet.diameter() / 1000
        Dim w As Integer = planet.percentWater()
        Dim lm As Decimal
        If d < 9000 Then

            lm = r / 2

        ElseIf d >= 9000 AndAlso d <= 15000 Then

            lm = r

        ElseIf d > 15000 Then

            lm = r * 1.5

        Else

            lm = 0

        End If

        If w < 30 Then

            lm = (lm / 2)

        ElseIf w > 60 Then

            lm = (lm * 1.5)

        End If

        Return Math.Round(lm, 0, MidpointRounding.AwayFromZero)

    End Function

    Private Function getLMName(planet) As String

        Dim l As Integer = getLanguage(planet)
        Dim expression As String = "Language = " & l
        Dim selectRows As DataRow()
        selectRows = nt.Select(expression)
        Dim r As Integer = rollX(selectRows.Length - 1)
        Dim name As String = selectRows(r)(0)
        name = getSuf(l, name)
        Dim pre As String = getPre(l, name)
        If String.IsNullOrEmpty(pre) = True Then

        ElseIf String.IsNullOrEmpty(pre) = False Then

            name = pre

        Else

        End If

        Return name

    End Function

    Private Function getLanguage(planet) As Integer

        Dim d As String

        If planet.factionChange() Is Nothing Then

            d = planet.faction()

        Else

            d = planet.factionChange(0).faction()

        End If

        Select Case d

            Case "CC", "FR", "NCR", "NIOPS"

                Return getCCLanguage()

            Case "SLIE", "CBS", "CB", "CCC", "CCO", "CDS", "CFM", "CGB", "CGS", "CHH", "CIH", "CJF", "CMG", "CNC", "CSJ", "CSR", "CSA", "CSV", "CWI", "CW", "CWOV"

                Return getClanLanguage()

            Case "DC"

                Return getDCLanguage()

            Case "FRR", "EF", "JF"

                Return getFRRLanguage()

            Case "FS", "THW", "TC", "OA", "CDP", "TD", "FOR", "MM"

                Return getFSLanguage()

            Case "FWL", "MOC", "IP", "LL", "MH"

                Return getFWLLanguage()

            Case "LA", "RWR", "CIR", "GV", "HL", "MV", "BoS", "OC", "RIM", "RCM", "RT", "TB"

                Return getLALanguage()

            Case Else

                Return rollX(31) + 1

        End Select

    End Function

    Private Function getCCLanguage() As Integer

        Dim r As Integer = rollX(44)
        Select Case r

            Case 0 To 9

                Return 1

            Case 10 To 24

                Return 12

            Case 25 To 44

                Return 20

            Case Else

                Return 0

        End Select

    End Function

    Private Function getClanLanguage() As Integer

        Dim r As Integer = rollX(59)
        Select Case r

            Case 0 To 14

                Return 1

            Case 15 To 24

                Return 9

            Case 25 To 44

                Return 19

            Case 45 To 59

                Return 20

            Case Else

                Return 0

        End Select

    End Function

    Private Function getDCLanguage() As Integer

        Dim r As Integer = rollX(54)
        Select Case r

            Case 0 To 9

                Return 1

            Case 10 To 24

                Return 7

            Case 25 To 34

                Return 22

            Case 35 To 54

                Return 26

            Case Else

                Return 0

        End Select

    End Function

    Private Function getFRRLanguage() As Integer

        Dim r As Integer = rollX(74)
        Select Case r

            Case 0 To 9

                Return 1

            Case 10 To 24

                Return 5

            Case 25 To 54

                Return 7

            Case 55 To 74

                Return 26

            Case Else

                Return 0

        End Select

    End Function

    Private Function getFSLanguage() As Integer

        Dim r As Integer = rollX(84)
        Select Case r

            Case 0 To 9

                Return 1

            Case 10 To 29

                Return 2

            Case 30 To 44

                Return 3

            Case 45 To 59

                Return 4

            Case 60 To 69

                Return 8

            Case 70 To 84

                Return 25

            Case Else

                Return 0

        End Select

    End Function

    Private Function getFWLLanguage() As Integer

        Dim r As Integer = rollX(144)
        Select Case r

            Case 0 To 9

                Return 1

            Case 10 To 29

                Return 9

            Case 30 To 44

                Return 10

            Case 45 To 54

                Return 13

            Case 55 To 64

                Return 14

            Case 65 To 74

                Return 15

            Case 75 To 84

                Return 18

            Case 85 To 104

                Return 19

            Case 105 To 114

                Return 20

            Case 115 To 124

                Return 24

            Case 125 To 144

                Return 25

            Case Else

                Return 0

        End Select

    End Function

    Private Function getLALanguage() As Integer

        Dim r As Integer = rollX(79)
        Select Case r

            Case 0 To 9

                Return 1

            Case 10 To 24

                Return 3

            Case 25 To 39

                Return 4

            Case 40 To 59

                Return 5

            Case 60 To 79

                Return 7

            Case Else

                Return 0

        End Select

    End Function

    Private Function getNew(l As Integer, name As String) As String

        Select Case l

            Case 1 To 3

                Return "New " & name

            Case 4

                Return name & " Nua"

            Case 5

                Return "Neues " & name

            Case 6

                Return "Nieuw " & name

            Case 7

                Return "Nytt " & name

            Case 8

                Return "Nouvelle " & name

            Case 9

                Return name & " Nuova"

            Case 10

                Return "Nueva " & name

            Case 11

                Return "Nova " & name

            Case 12

                Return "Novaya " & name

            Case 13

                Return "Nová " & name

            Case 14

                Return "Nowy " & name

            Case 15

                Return name & " Nou"

            Case 16

                Return "Uusi " & name

            Case 17

                Return name & " i Ri"

            Case 18

                Return "Novo " & name

            Case 19

                Return "Néo " & name

            Case 20

                Return "Yeni " & name

            Case 21

                Return "Nor " & name

            Case 22

                Return name & " jadid"

            Case 23

                Return "Nuwe " & name

            Case 24

                Return "Nayee " & name

            Case 25

                Return "Navāṁ " & name

            Case 26

                Return "Atarashī " & name

            Case 27

                Return "Saeloun " & name

            Case 28

                Return "Xīn " & name

            Case 29

                Return name & " Mới"

            Case 30

                Return name & " Baru"

            Case 31

                Return name & " Fou"

            Case 32

                Return "Bagong " & name

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getOld(l As Integer, name As String) As String

        Select Case l

            Case 1 To 3

                Return "Old " & name

            Case 4

                Return "Sean-" & name

            Case 5

                Return "Altes " & name

            Case 6

                Return "Oud " & name

            Case 7

                Return "Gammalt " & name

            Case 8

                Return "vieille " & name

            Case 9

                Return "Vecchia " & name

            Case 10

                Return name & " Vieja"

            Case 11

                Return name & " Velha"

            Case 12

                Return "Staraya " & name

            Case 13

                Return "Stará " & name

            Case 14

                Return "Starej " & name

            Case 15

                Return name & " Vechi"

            Case 16

                Return "Vanha " & name

            Case 17

                Return name & " I Vjetër"

            Case 18

                Return "Staro " & name

            Case 19

                Return "Paliá " & name

            Case 20

                Return "Eski " & name

            Case 21

                Return "Hin " & name

            Case 22

                Return name & " Alqadim"

            Case 23

                Return "Ou " & name

            Case 24

                Return "Puraanee " & name

            Case 25

                Return "Purāṇī " & name

            Case 26

                Return "Furui " & name

            Case 27

                Return "Olaedoen " & name

            Case 28

                Return "Lǎo " & name

            Case 29

                Return name & " Cũ"

            Case 30

                Return name & " Tua"

            Case 31

                Return name & " Tuai"

            Case 32

                Return "Lumang " & name

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getPre(l As Integer, name As String) As String

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2 To 4

                Return getOld(l, name)

            Case 5 To 6

                Return getNew(l, name)

            Case 7 To 12

                Return ""

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getLand(l As Integer, name As String) As String

        Dim first As String = name.Substring(0, 1)
        Dim last As String = name.Substring(name.Length() - 1, 1)
        Dim land As String
        Dim lFirst As String

        Select Case l

            Case 1 To 3, 5 To 7, 23

                land = "land"

            Case 4

                land = "lainn"

            Case 8

                land = "lande"

            Case 9 To 10, 14, 21, 30

                land = "landia"

            Case 11

                land = "lândia"

            Case 12

                land = "andiya"

            Case 13

                land = "sko"

            Case 15, 20, 22, 32

                land = "landa"

            Case 16

                land = "lanti"

            Case 17

                land = "landë"


            Case 18

                land = "ska"

            Case 19

                land = "landía"

            Case 24

                land = "alaind"

            Case 25

                land = "alainda"

            Case 26

                land = "rando"

            Case 27

                land = "landeu"

            Case 28

                land = "lán"

            Case 29

                land = " Lan"

            Case 31

                land = "lani"

            Case Else

                land = "Error"

        End Select

        lFirst = land.Substring(0, 1)
        If String.Compare(last, lFirst, True) = 0 Then

            Return name & land.Remove(0, 1)

        Else

            Return name & land

        End If

    End Function

    Private Function getEnd(l As Integer, name As String) As String

        If name.Length() <= 2 Then

            Return name

        Else

        End If

        Dim last As String = name.Substring(name.Length() - 1, 1)
        Dim ll As String = name.Substring(name.Length() - 2, 2)

        If last = "a" Then

            Return name.Insert(name.Length(), "n")

        ElseIf ll = "ae" Then


            Return name.Insert(name.Length(), "n")

        ElseIf last = "e" Then


            Return name.Insert(name.Length(), "a")

        ElseIf ll = "ai" Then

            Return name.Insert(name.Length(), "n")

        ElseIf last = "i" Then

            Return name.Insert(name.Length(), "a")

        ElseIf last = "o" OrElse last = "u" OrElse last = "y" Then


            Return name

        Else

            Return name

        End If

    End Function

    Private Function getSuf(l As Integer, name As String) As String

        Dim r As Integer = roll2D6()
        Select Case r

            Case 2 To 4

                Return name

            Case 5 To 6

                Return getLand(l, name)

            Case 7 To 12

                Return getEnd(l, name)

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getMoons(planet) As Integer

        Dim r As Integer = roll1D6()

        Select Case r

            Case 1 To 2

                Dim rr As Integer = roll1D6()
                Return rr - 5

            Case 3 To 4

                Dim rr As Integer = roll1D6()
                Dim rrr As Integer = roll1D6()
                Return (rr - 3) + (rrr - 3)

            Case 5 To 6

                Dim rr As Integer = roll2D6()
                Dim ring As Integer = roll1D6()
                If ring = 1 Then

                    planet.rings = True

                Else

                    planet.rings = False

                End If
                Return (rr - 4)

            Case Else

                Return 99

        End Select

    End Function

    Private Function getMoonsName(planet) As String

        Dim l As Integer = getLanguage(planet)
        Dim expression As String = "Language = " & l
        Dim selectRows As DataRow()
        selectRows = nt.Select(expression)
        Dim r As Integer = rollX(selectRows.Length - 1)
        Dim name As String
        name = selectRows(r)(0)

        Return name

    End Function

    Private Function getSF(planet) As String

        Dim r As Integer = roll2D6()
        Dim hm As Integer
        Dim expression As String = "[Spectral Type] = " & "'" & planet.spectralType() & "'"
        Dim selectRow As DataRow()
        selectRow = st.Select(expression)
        hm = selectRow(0)(5)
        Select Case r

            Case 2 To 7

                Return String.Empty

            Case 8 To 12

                Return getFeature(planet, hm)

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getFeature(planet As Object, hm As Integer) As String

        Dim r As Integer = roll2D6()
        Dim mr As Integer = r + hm
        Dim p As Integer = planet.pressure()

        If p <= 1 AndAlso mr >= 6 AndAlso mr <> 9 Then

            While p <= 1 AndAlso mr >= 6 AndAlso mr <> 9

                r = roll2D6()
                mr = r + hm

            End While

        End If

        If mr <= 1 Then

            Return ""

        End If

        Select Case mr

            Case 2

                Return ""

            Case 3

                Return " has suffered a natural disaster"

            Case 4

                Return " experiences intense volcanic activity"

            Case 5

                Return " experiences intense seismic activity"

            Case 6

                Return " is afflicted with a disease / virus (fatal to humans)"

            Case 7

                Return " has incompatible biochemistry (for humans)"

            Case 8

                Return " is home to a hostile life form"

            Case 9

                Return " harbors a Star League facility (abandoned)"

            Case 10

                Return " harbors a Star League facility (occupied)"

            Case 11

                Return " harbors a colony (" & getColony(p) & ")"

            Case r >= 12

                Return " harbors a lost colony (occupied)"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getColony(p) As String

        Dim r As Integer = roll1D6()

        If p <= 1 Then

            Return "abandoned"

        End If

        Select Case r

                Case 1 To 3

                    Return "occupied"

                Case 4 To 6

                    Return "abandoned"

                Case Else

                    Return "error"

            End Select

    End Function

    Private Function getPop(planet) As Long

        Dim d As Date = planet.factionchange(0).date()
        Dim f As String = planet.factionchange(0).faction()
        Dim clan As Boolean = checkCC(f)
        Dim x As Decimal = planet.xcood()
        Dim y As Decimal = planet.ycood()
        Dim dist As Decimal = Math.Sqrt((x ^ 2) + (y ^ 2))
        Dim pop As Long

        If clan = True Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 4
                    Dim rr As Integer = roll3D6()
                    pop = (10 ^ 3) * rr

                Case 5 To 6
                    Dim rr As Integer = roll3D6()
                    pop = 5 * (10 ^ 4) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso dist < 500 Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = 5 * (10 ^ 7) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = 5 * (10 ^ 8) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso dist < 500 Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = (10 ^ 4) * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = (10 ^ 5) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso (dist >= 500 AndAlso dist < 601) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = (10 ^ 7) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = (10 ^ 8) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso (dist >= 500 AndAlso dist < 601) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = 2 * (10 ^ 6) * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = 2 * (10 ^ 7) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso (dist >= 601 AndAlso dist < 751) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = 2.5 * (10 ^ 6) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = 2.5 * (10 ^ 7) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso (dist >= 601 AndAlso dist < 751) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = 5 * (10 ^ 4) * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = (10 ^ 6) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso (dist >= 751 AndAlso dist < 1001) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = 5 * (10 ^ 5) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = 5 * (10 ^ 6) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso (dist >= 751 AndAlso dist < 1001) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = 2 * (10 ^ 4) * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = 2 * (10 ^ 5) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso (dist >= 1001 AndAlso dist < 1251) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = (10 ^ 5) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = (10 ^ 6) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso (dist >= 1001 AndAlso dist < 1251) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = 5 * (10 ^ 3) * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = 5 * (10 ^ 4) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso (dist >= 1251 AndAlso dist < 2001) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = (10 ^ 4) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = 2 * (10 ^ 5) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso (dist >= 1251 AndAlso dist < 2001) Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = 500 * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = (10 ^ 4) * rr

            End Select

        ElseIf d.Year <= 2780 AndAlso dist >= 2001 Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll4D6()
                    pop = 2.5 * (10 ^ 3) * rr

                Case 6
                    Dim rr As Integer = roll4D6()
                    pop = 5 * (10 ^ 4) * rr

            End Select

        ElseIf d.Year > 2780 AndAlso dist >= 2001 Then

            Dim r As Integer = roll1D6()
            Select Case r

                Case 1 To 5
                    Dim rr As Integer = roll2D6()
                    pop = 100 * rr

                Case 6
                    Dim rr As Integer = roll2D6()
                    pop = 2.5 * (10 ^ 3) * rr

            End Select

        Else

        End If

        Return pop

    End Function

    Private Function checkCC(f As String) As Boolean

        Dim clans() As String = {"SLIE", "CBS", "CB", "CCC", "CCO", "CDS", "CFM", "CGB", "CGS", "CHH", "CIH", "CJF", "CMG", "CNC", "CSJ", "CSR", "CSA", "CSV", "CWI", "CW", "CWOV"}
        If clans.Contains(f) = True Then

            Return True

        Else

            Return False

        End If

    End Function

    Private Function getPopMod(planet) As Long

        Dim p As Decimal
        Dim a As String
        Dim t As Integer
        Dim g As Decimal
        Dim w As Integer
        Dim pop As Long = planet.population()

        If planet.pressure() Is Nothing Then

            p = 0

        Else

            p = planet.pressure()

        End If

        If String.IsNullOrEmpty(planet.AC()) = True Then

            a = " has none / a toxic atmosphere"

        Else

            a = planet.AC()

        End If

        If planet.temperature() Is Nothing Then

            t = 0

        Else

            t = planet.temperature()

        End If

        If planet.gravity() Is Nothing Then

            g = 0

        Else

            g = planet.gravity()

        End If

        If planet.percentWater() Is Nothing Then

            w = 0

        Else

            w = planet.percentWater()

        End If

        If p < 2 OrElse p = 5 Then

            pop = pop * 0.05

        End If

        If String.Compare(a, " has a tainted atmosphere") = 0 Then

            pop = pop * 0.8

        End If

        If t >= 44 Then

            pop = pop * 0.8

        End If

        If g < 0.8 OrElse (g > 1.2 AndAlso g <= 1.5) Then

            pop = pop * 0.8

        End If

        If g > 1.5 Then

            pop = pop * 0.5

        End If

        If w <= 40 Then

            pop = pop * 0.8

        End If

        Return pop

    End Function

    Private Function getTech(planet) As Integer

        Dim index As Integer = 0
        For i = 0 To planet.factionChange().Length - 1

            If planet.factionChange(i).date().Year <= 3025 Then

                index = i

            End If

        Next

        Dim f As String = planet.factionChange(index).faction()
        Dim d As Integer = planet.factionchange(0).date().Year
        Dim p As Long = planet.population()
        Dim clan As Boolean = checkCC(f)
        Dim tech As Integer = 3

        If d <= 2780 Then

            tech = tech - 1

        End If

        If p >= (10 ^ 9) Then

            tech = tech - 1

        End If

        If clan = True Then

            tech = tech - 1

        End If

        If f = "ABN" OrElse f = "IND" OrElse f = "UND" OrElse f = "OMA" OrElse f = "MERC" OrElse f = "NONE" OrElse f = "PIR" OrElse f = "REB" OrElse f = "IE" Then

            tech = tech + 1

        End If

        If p < (10 ^ 8) Then

            tech = tech + 1

        End If

        If p < (10 ^ 6) Then

            tech = tech + 1

        End If

        Return tech

    End Function

    Private Function getTdesc(planet) As String

        Dim t As Integer = planet.tech()
        Select Case t

            Case Is < 1

                Return " is an ultra-tech"

            Case 1

                Return " is a high-tech"

            Case 2

                Return " is an advanced"

            Case 3

                Return " is a moderately advanced"

            Case 4

                Return " is a lower-tech"

            Case 5

                Return " is a primitive"

            Case Is > 5

                Return " is a technologically regressed"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getDev(planet) As Integer

        Dim p As Long = planet.population()
        Dim tech As Integer = planet.tech()
        Dim dev As Integer = 4

        If p >= (10 ^ 9) Then

            dev = dev - 1

        End If

        If p >= 4 * (10 ^ 9) Then

            dev = dev - 1

        End If

        If tech <= 2 Then

            dev = dev - 1

        End If

        If p <= (10 ^ 8) Then

            dev = dev + 1

        End If

        If p <= (10 ^ 6) Then

            dev = dev + 1

        End If

        If tech >= 5 Then

            dev = dev + 1

        End If

        Return dev

    End Function

    Private Function getDdesc(planet) As String

        Dim d As Integer = planet.development()
        Select Case d

            Case Is <= 1

                Return " is heavily industrialized"

            Case 2

                Return " is moderately industrialized"

            Case 3

                Return " has basic heavy industry"

            Case 4

                Return " has low industrialization"

            Case Is >= 5

                Return " has no industrialization"

            Case Else

                Return " Error"

        End Select

    End Function

    Private Function getOutput(planet) As Integer

        Dim p As Long = planet.population()
        Dim tech As Integer = planet.tech()
        Dim dev As Integer = planet.development()
        Dim output As Integer = 3

        If p >= (10 ^ 9) Then

            output = output - 1

        End If

        If tech <= 1 Then

            output = output - 1

        End If

        If dev <= 2 Then

            output = output - 1

        End If

        If tech = 4 OrElse tech = 5 Then

            output = output + 1

        End If

        If tech > 5 Then

            output = output + 1

        End If

        If dev >= 4 Then

            output = output + 1

        End If

        Return output

    End Function

    Private Function getOdesc(planet) As String

        Dim o As Integer = planet.output()
        Select Case o

            Case <= 1

                Return " has high industrial output"

            Case 2

                Return " has good industrial output"

            Case 3

                Return " has limited industrial output"

            Case 4

                Return " has negligible industrial output"

            Case >= 5

                Return " has no industrial output"

            Case Else

                Return " Error"

        End Select

    End Function

    Private Function getMaterial(planet) As Integer

        Dim tech As Integer = planet.tech()
        Dim den As Double
        Dim p As Long = planet.population()
        Dim output As Integer = planet.output()
        Dim d As Integer = planet.factionChange(0).date().year
        Dim material As Integer = 2

        If planet.density() Is Nothing Then

            den = 0

        Else

            den = planet.density()

        End If

        If tech < 1 Then

            material = material - 1

        End If

        If tech >= 1 AndAlso tech <= 3 Then

            material = material - 1

        End If

        If den >= 5.5 Then

            material = material - 1

        End If

        If p >= (3 * (10 ^ 9)) Then

            material = material + 1

        End If

        If output <= 2 Then

            material = material + 1

        End If

        If (3025 - d) >= 250 Then

            material = material + 1

        End If

        If den <= 4 Then

            material = material + 1

        End If

        Return material

    End Function

    Private Function getMdesc(planet) As String

        Dim m As Integer = planet.material()
        Select Case m

            Case <= 1

                Return " is fully self-sufficient on materials"

            Case 2

                Return " is mostly self-sufficient on materials"

            Case 3

                Return " is self-sustaining on materials"

            Case 4

                Return " is dependent on imported materials"

            Case >= 5

                Return " is heavily dependent on imported materials"

            Case Else

                Return " Error"

        End Select

    End Function

    Private Function getAgricultural(planet) As Integer

        Dim tech As Integer = planet.tech()
        Dim dev As Integer = planet.development()
        Dim p As Long = planet.population()
        Dim w As Integer
        Dim ac As String
        Dim agr As Integer = 3

        If planet.percentWater() Is Nothing Then

            w = 0

        Else

            w = planet.percentWater()

        End If

        If String.IsNullOrEmpty(planet.AC()) = True Then

            ac = " has none / a toxic atmosphere"

        Else

            ac = planet.ac()

        End If

        If tech <= 2 Then

            agr = agr - 1

        End If

        If tech = 3 Then

            agr = agr - 1

        End If

        If dev <= 3 Then

            agr = agr - 1

        End If

        If tech >= 5 Then

            agr = agr + 1

        End If

        If p >= (10 ^ 9) Then

            agr = agr + 1

        End If

        If p >= (5 * (10 ^ 9)) Then

            agr = agr + 1

        End If

        If w < 50 Then

            agr = agr + 1

        End If

        If String.Compare(ac, " has a tainted atmosphere") = 0 Then

            agr = agr + 1

        End If

        If String.Compare(ac, " has none / a toxic atmosphere") = 0 Then

            agr = agr + 2

        End If

        Return agr

    End Function

    Private Function getAdesc(planet) As String

        Dim a As Integer = planet.agricultural()
        Select Case a

            Case <= 1

                Return " is an agricultural breadbasket"

            Case 2

                Return " is an agriculturally abundant"

            Case 3

                Return " is a modest agriculture"

            Case 4

                Return " is a poor agriculture"

            Case >= 5

                Return " is an agriculturally barren"

            Case Else

                Return " Error"

        End Select

    End Function

    Private Function getUSILR(score As Integer) As String

        Select Case score

            Case Is > 5

                Return "F"

            Case 5

                Return "F"

            Case 4

                Return "D"

            Case 3

                Return "C"

            Case 2

                Return "B"

            Case 1

                Return "A"

            Case Is < 1

                Return "A"

            Case Else

                Return "Error"

        End Select

    End Function

    Private Function getScore(code As String) As Integer

        Select Case code

            Case "A"

                Return 1

            Case "B"

                Return 2

            Case "C"

                Return 3

            Case "D"

                Return 4

            Case "F"

                Return 5

            Case Else

                Return vbNull

        End Select

    End Function

    Private Function rollX(length As Integer) As Integer

        Return r.Next(0, length)

    End Function

    Shared Function roll1D10() As Integer

        Return r.Next(1, 11)

    End Function

    Shared Function roll1D6() As Integer

        Return r.Next(1, 7)

    End Function

    Shared Function roll2D6() As Integer

        Return r.Next(1, 7) + r.Next(1, 7)

    End Function

    Shared Function roll3D6() As Integer

        Return r.Next(1, 7) + r.Next(1, 7) + r.Next(1, 7)

    End Function

    Shared Function roll4D6() As Integer

        Return r.Next(1, 7) + r.Next(1, 7) + r.Next(1, 7) + r.Next(1, 7)

    End Function

    Public Sub New()

        serialPlanets()

    End Sub

End Class