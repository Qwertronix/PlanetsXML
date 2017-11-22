<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlanetsXML
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.txtAxis = New System.Windows.Forms.TextBox()
        Me.cbPlanets = New System.Windows.Forms.ComboBox()
        Me.txtOrbit = New System.Windows.Forms.TextBox()
        Me.txtMoon = New System.Windows.Forms.TextBox()
        Me.txtGravity = New System.Windows.Forms.TextBox()
        Me.txtAtmosphere = New System.Windows.Forms.TextBox()
        Me.txtEQTemp = New System.Windows.Forms.TextBox()
        Me.txtWater = New System.Windows.Forms.TextBox()
        Me.lblAxis = New System.Windows.Forms.Label()
        Me.lblOrbit = New System.Windows.Forms.Label()
        Me.lblAtmosphere = New System.Windows.Forms.Label()
        Me.lblGravity = New System.Windows.Forms.Label()
        Me.lblpercentWater = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblMoon = New System.Windows.Forms.Label()
        Me.btnGen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnWrite
        '
        Me.btnWrite.Location = New System.Drawing.Point(118, 398)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(100, 25)
        Me.btnWrite.TabIndex = 0
        Me.btnWrite.Text = "&Write"
        Me.btnWrite.UseVisualStyleBackColor = True
        '
        'txtAxis
        '
        Me.txtAxis.Location = New System.Drawing.Point(13, 12)
        Me.txtAxis.Name = "txtAxis"
        Me.txtAxis.ReadOnly = True
        Me.txtAxis.Size = New System.Drawing.Size(200, 22)
        Me.txtAxis.TabIndex = 1
        '
        'cbPlanets
        '
        Me.cbPlanets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPlanets.FormattingEnabled = True
        Me.cbPlanets.Location = New System.Drawing.Point(13, 368)
        Me.cbPlanets.Name = "cbPlanets"
        Me.cbPlanets.Size = New System.Drawing.Size(597, 24)
        Me.cbPlanets.TabIndex = 2
        '
        'txtOrbit
        '
        Me.txtOrbit.Location = New System.Drawing.Point(12, 40)
        Me.txtOrbit.Name = "txtOrbit"
        Me.txtOrbit.ReadOnly = True
        Me.txtOrbit.Size = New System.Drawing.Size(200, 22)
        Me.txtOrbit.TabIndex = 3
        '
        'txtMoon
        '
        Me.txtMoon.Location = New System.Drawing.Point(13, 180)
        Me.txtMoon.Name = "txtMoon"
        Me.txtMoon.ReadOnly = True
        Me.txtMoon.Size = New System.Drawing.Size(200, 22)
        Me.txtMoon.TabIndex = 4
        '
        'txtGravity
        '
        Me.txtGravity.Location = New System.Drawing.Point(12, 96)
        Me.txtGravity.Name = "txtGravity"
        Me.txtGravity.ReadOnly = True
        Me.txtGravity.Size = New System.Drawing.Size(200, 22)
        Me.txtGravity.TabIndex = 5
        '
        'txtAtmosphere
        '
        Me.txtAtmosphere.Location = New System.Drawing.Point(12, 68)
        Me.txtAtmosphere.Name = "txtAtmosphere"
        Me.txtAtmosphere.ReadOnly = True
        Me.txtAtmosphere.Size = New System.Drawing.Size(200, 22)
        Me.txtAtmosphere.TabIndex = 6
        '
        'txtEQTemp
        '
        Me.txtEQTemp.Location = New System.Drawing.Point(12, 152)
        Me.txtEQTemp.Name = "txtEQTemp"
        Me.txtEQTemp.ReadOnly = True
        Me.txtEQTemp.Size = New System.Drawing.Size(200, 22)
        Me.txtEQTemp.TabIndex = 7
        '
        'txtWater
        '
        Me.txtWater.Location = New System.Drawing.Point(12, 124)
        Me.txtWater.Name = "txtWater"
        Me.txtWater.ReadOnly = True
        Me.txtWater.Size = New System.Drawing.Size(200, 22)
        Me.txtWater.TabIndex = 8
        '
        'lblAxis
        '
        Me.lblAxis.AutoSize = True
        Me.lblAxis.Location = New System.Drawing.Point(219, 15)
        Me.lblAxis.Name = "lblAxis"
        Me.lblAxis.Size = New System.Drawing.Size(33, 17)
        Me.lblAxis.TabIndex = 9
        Me.lblAxis.Text = "Axis"
        '
        'lblOrbit
        '
        Me.lblOrbit.AutoSize = True
        Me.lblOrbit.Location = New System.Drawing.Point(218, 43)
        Me.lblOrbit.Name = "lblOrbit"
        Me.lblOrbit.Size = New System.Drawing.Size(39, 17)
        Me.lblOrbit.TabIndex = 10
        Me.lblOrbit.Text = "Orbit"
        '
        'lblAtmosphere
        '
        Me.lblAtmosphere.AutoSize = True
        Me.lblAtmosphere.Location = New System.Drawing.Point(218, 71)
        Me.lblAtmosphere.Name = "lblAtmosphere"
        Me.lblAtmosphere.Size = New System.Drawing.Size(84, 17)
        Me.lblAtmosphere.TabIndex = 11
        Me.lblAtmosphere.Text = "Atmosphere"
        '
        'lblGravity
        '
        Me.lblGravity.AutoSize = True
        Me.lblGravity.Location = New System.Drawing.Point(218, 99)
        Me.lblGravity.Name = "lblGravity"
        Me.lblGravity.Size = New System.Drawing.Size(53, 17)
        Me.lblGravity.TabIndex = 12
        Me.lblGravity.Text = "Gravity"
        '
        'lblpercentWater
        '
        Me.lblpercentWater.AutoSize = True
        Me.lblpercentWater.Location = New System.Drawing.Point(219, 127)
        Me.lblpercentWater.Name = "lblpercentWater"
        Me.lblpercentWater.Size = New System.Drawing.Size(58, 17)
        Me.lblpercentWater.TabIndex = 13
        Me.lblpercentWater.Text = "Water%"
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Location = New System.Drawing.Point(218, 155)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(64, 17)
        Me.lblTemperature.TabIndex = 14
        Me.lblTemperature.Text = "EQTemp"
        '
        'lblMoon
        '
        Me.lblMoon.AutoSize = True
        Me.lblMoon.Location = New System.Drawing.Point(218, 183)
        Me.lblMoon.Name = "lblMoon"
        Me.lblMoon.Size = New System.Drawing.Size(60, 17)
        Me.lblMoon.TabIndex = 15
        Me.lblMoon.Text = "Moon(s)"
        '
        'btnGen
        '
        Me.btnGen.Location = New System.Drawing.Point(12, 398)
        Me.btnGen.Name = "btnGen"
        Me.btnGen.Size = New System.Drawing.Size(100, 25)
        Me.btnGen.TabIndex = 16
        Me.btnGen.Text = "&Generate"
        Me.btnGen.UseVisualStyleBackColor = True
        '
        'PlanetsXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 433)
        Me.Controls.Add(Me.btnGen)
        Me.Controls.Add(Me.lblMoon)
        Me.Controls.Add(Me.lblTemperature)
        Me.Controls.Add(Me.lblpercentWater)
        Me.Controls.Add(Me.lblGravity)
        Me.Controls.Add(Me.lblAtmosphere)
        Me.Controls.Add(Me.lblOrbit)
        Me.Controls.Add(Me.lblAxis)
        Me.Controls.Add(Me.txtWater)
        Me.Controls.Add(Me.txtEQTemp)
        Me.Controls.Add(Me.txtAtmosphere)
        Me.Controls.Add(Me.txtGravity)
        Me.Controls.Add(Me.txtMoon)
        Me.Controls.Add(Me.txtOrbit)
        Me.Controls.Add(Me.cbPlanets)
        Me.Controls.Add(Me.txtAxis)
        Me.Controls.Add(Me.btnWrite)
        Me.Name = "PlanetsXML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PlanetsXML"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnWrite As Button
    Friend WithEvents txtAxis As TextBox
    Friend WithEvents cbPlanets As ComboBox
    Friend WithEvents txtOrbit As TextBox
    Friend WithEvents txtMoon As TextBox
    Friend WithEvents txtGravity As TextBox
    Friend WithEvents txtAtmosphere As TextBox
    Friend WithEvents txtEQTemp As TextBox
    Friend WithEvents txtWater As TextBox
    Friend WithEvents lblAxis As Label
    Friend WithEvents lblOrbit As Label
    Friend WithEvents lblAtmosphere As Label
    Friend WithEvents lblGravity As Label
    Friend WithEvents lblpercentWater As Label
    Friend WithEvents lblTemperature As Label
    Friend WithEvents lblMoon As Label
    Friend WithEvents btnGen As Button
End Class
