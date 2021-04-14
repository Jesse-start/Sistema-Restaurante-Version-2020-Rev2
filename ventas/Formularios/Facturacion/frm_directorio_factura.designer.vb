<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_directorio_factura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_directorio_factura))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.gb_tipo = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cb_clasificacion = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rb_fisica = New System.Windows.Forms.RadioButton()
        Me.rb_moral = New System.Windows.Forms.RadioButton()
        Me.gb_persona = New System.Windows.Forms.GroupBox()
        Me.tb_curp = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tb_alias_fisica = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.tb_rfcF = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tb_emailF = New System.Windows.Forms.TextBox()
        Me.tb_apellidoM = New System.Windows.Forms.TextBox()
        Me.tb_apellidoP = New System.Windows.Forms.TextBox()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gb_empresa = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.tb_rfcM = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tb_emailM = New System.Windows.Forms.TextBox()
        Me.tb_url = New System.Windows.Forms.TextBox()
        Me.tb_alias = New System.Windows.Forms.TextBox()
        Me.tb_razon = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tb_municipio = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_calle = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tb_pais = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_estado = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_poblacion = New System.Windows.Forms.TextBox()
        Me.tb_cp = New System.Windows.Forms.TextBox()
        Me.tb_colonia = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gb_clase = New System.Windows.Forms.GroupBox()
        Me.rb_cliente = New System.Windows.Forms.RadioButton()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.tb_salir = New System.Windows.Forms.ToolStripButton()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gb_tipo.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.gb_persona.SuspendLayout()
        Me.gb_empresa.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gb_clase.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.gb_tipo)
        Me.FlowLayoutPanel1.Controls.Add(Me.gb_persona)
        Me.FlowLayoutPanel1.Controls.Add(Me.gb_empresa)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(409, 558)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'gb_tipo
        '
        Me.gb_tipo.Controls.Add(Me.Panel7)
        Me.gb_tipo.Controls.Add(Me.Panel6)
        Me.gb_tipo.Location = New System.Drawing.Point(3, 3)
        Me.gb_tipo.Name = "gb_tipo"
        Me.gb_tipo.Size = New System.Drawing.Size(400, 103)
        Me.gb_tipo.TabIndex = 4
        Me.gb_tipo.TabStop = False
        Me.gb_tipo.Text = "Tipo"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.cb_clasificacion)
        Me.Panel7.Controls.Add(Me.Label26)
        Me.Panel7.Location = New System.Drawing.Point(6, 54)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(387, 42)
        Me.Panel7.TabIndex = 8
        '
        'cb_clasificacion
        '
        Me.cb_clasificacion.FormattingEnabled = True
        Me.cb_clasificacion.Location = New System.Drawing.Point(195, 3)
        Me.cb_clasificacion.Name = "cb_clasificacion"
        Me.cb_clasificacion.Size = New System.Drawing.Size(189, 28)
        Me.cb_clasificacion.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(5, 6)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(184, 20)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Clasificacion del cliente"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.rb_fisica)
        Me.Panel6.Controls.Add(Me.rb_moral)
        Me.Panel6.Location = New System.Drawing.Point(90, 14)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(186, 31)
        Me.Panel6.TabIndex = 7
        '
        'rb_fisica
        '
        Me.rb_fisica.AutoSize = True
        Me.rb_fisica.Checked = True
        Me.rb_fisica.Location = New System.Drawing.Point(3, 3)
        Me.rb_fisica.Name = "rb_fisica"
        Me.rb_fisica.Size = New System.Drawing.Size(66, 24)
        Me.rb_fisica.TabIndex = 2
        Me.rb_fisica.TabStop = True
        Me.rb_fisica.Text = "Fisica"
        Me.rb_fisica.UseVisualStyleBackColor = True
        '
        'rb_moral
        '
        Me.rb_moral.AutoSize = True
        Me.rb_moral.Location = New System.Drawing.Point(113, 2)
        Me.rb_moral.Name = "rb_moral"
        Me.rb_moral.Size = New System.Drawing.Size(70, 24)
        Me.rb_moral.TabIndex = 3
        Me.rb_moral.Text = "Moral"
        Me.rb_moral.UseVisualStyleBackColor = True
        '
        'gb_persona
        '
        Me.gb_persona.Controls.Add(Me.tb_curp)
        Me.gb_persona.Controls.Add(Me.Label35)
        Me.gb_persona.Controls.Add(Me.tb_alias_fisica)
        Me.gb_persona.Controls.Add(Me.Label42)
        Me.gb_persona.Controls.Add(Me.Label40)
        Me.gb_persona.Controls.Add(Me.tb_rfcF)
        Me.gb_persona.Controls.Add(Me.Label53)
        Me.gb_persona.Controls.Add(Me.Label28)
        Me.gb_persona.Controls.Add(Me.Label27)
        Me.gb_persona.Controls.Add(Me.tb_emailF)
        Me.gb_persona.Controls.Add(Me.tb_apellidoM)
        Me.gb_persona.Controls.Add(Me.tb_apellidoP)
        Me.gb_persona.Controls.Add(Me.tb_nombre)
        Me.gb_persona.Controls.Add(Me.Label7)
        Me.gb_persona.Controls.Add(Me.Label6)
        Me.gb_persona.Controls.Add(Me.Label5)
        Me.gb_persona.Controls.Add(Me.Label52)
        Me.gb_persona.Controls.Add(Me.Label4)
        Me.gb_persona.Location = New System.Drawing.Point(3, 112)
        Me.gb_persona.Name = "gb_persona"
        Me.gb_persona.Size = New System.Drawing.Size(400, 235)
        Me.gb_persona.TabIndex = 1
        Me.gb_persona.TabStop = False
        Me.gb_persona.Text = "Datos del cliente"
        '
        'tb_curp
        '
        Me.tb_curp.Location = New System.Drawing.Point(160, 191)
        Me.tb_curp.Name = "tb_curp"
        Me.tb_curp.Size = New System.Drawing.Size(233, 26)
        Me.tb_curp.TabIndex = 30
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(24, 190)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(45, 20)
        Me.Label35.TabIndex = 31
        Me.Label35.Text = "Curp"
        '
        'tb_alias_fisica
        '
        Me.tb_alias_fisica.Location = New System.Drawing.Point(160, 19)
        Me.tb_alias_fisica.Name = "tb_alias_fisica"
        Me.tb_alias_fisica.Size = New System.Drawing.Size(234, 26)
        Me.tb_alias_fisica.TabIndex = 2
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(16, 156)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(15, 20)
        Me.Label42.TabIndex = 29
        Me.Label42.Text = "*"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(31, 160)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(37, 20)
        Me.Label40.TabIndex = 26
        Me.Label40.Text = "RFC"
        '
        'tb_rfcF
        '
        Me.tb_rfcF.Location = New System.Drawing.Point(160, 161)
        Me.tb_rfcF.Name = "tb_rfcF"
        Me.tb_rfcF.Size = New System.Drawing.Size(234, 26)
        Me.tb_rfcF.TabIndex = 6
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(11, 21)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(15, 20)
        Me.Label53.TabIndex = 21
        Me.Label53.Text = "*"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(11, 50)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(15, 20)
        Me.Label28.TabIndex = 21
        Me.Label28.Text = "*"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(11, 76)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(15, 20)
        Me.Label27.TabIndex = 20
        Me.Label27.Text = "*"
        '
        'tb_emailF
        '
        Me.tb_emailF.Location = New System.Drawing.Point(160, 133)
        Me.tb_emailF.Name = "tb_emailF"
        Me.tb_emailF.Size = New System.Drawing.Size(234, 26)
        Me.tb_emailF.TabIndex = 6
        '
        'tb_apellidoM
        '
        Me.tb_apellidoM.Location = New System.Drawing.Point(160, 104)
        Me.tb_apellidoM.Name = "tb_apellidoM"
        Me.tb_apellidoM.Size = New System.Drawing.Size(234, 26)
        Me.tb_apellidoM.TabIndex = 4
        '
        'tb_apellidoP
        '
        Me.tb_apellidoP.Location = New System.Drawing.Point(160, 76)
        Me.tb_apellidoP.Name = "tb_apellidoP"
        Me.tb_apellidoP.Size = New System.Drawing.Size(234, 26)
        Me.tb_apellidoP.TabIndex = 3
        '
        'tb_nombre
        '
        Me.tb_nombre.Location = New System.Drawing.Point(160, 48)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(234, 26)
        Me.tb_nombre.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "E-mail"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Apellido Materno"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Apellido Paterno"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(24, 22)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(46, 20)
        Me.Label52.TabIndex = 0
        Me.Label52.Text = "Alias:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nombre"
        '
        'gb_empresa
        '
        Me.gb_empresa.Controls.Add(Me.Label43)
        Me.gb_empresa.Controls.Add(Me.Label41)
        Me.gb_empresa.Controls.Add(Me.tb_rfcM)
        Me.gb_empresa.Controls.Add(Me.Label23)
        Me.gb_empresa.Controls.Add(Me.Label22)
        Me.gb_empresa.Controls.Add(Me.tb_emailM)
        Me.gb_empresa.Controls.Add(Me.tb_url)
        Me.gb_empresa.Controls.Add(Me.tb_alias)
        Me.gb_empresa.Controls.Add(Me.tb_razon)
        Me.gb_empresa.Controls.Add(Me.Label8)
        Me.gb_empresa.Controls.Add(Me.Label3)
        Me.gb_empresa.Controls.Add(Me.Label2)
        Me.gb_empresa.Controls.Add(Me.Label1)
        Me.gb_empresa.Location = New System.Drawing.Point(3, 353)
        Me.gb_empresa.Name = "gb_empresa"
        Me.gb_empresa.Size = New System.Drawing.Size(393, 166)
        Me.gb_empresa.TabIndex = 0
        Me.gb_empresa.TabStop = False
        Me.gb_empresa.Text = "Datos del cliente"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(11, 133)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(15, 20)
        Me.Label43.TabIndex = 29
        Me.Label43.Text = "*"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(24, 133)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(37, 20)
        Me.Label41.TabIndex = 28
        Me.Label41.Text = "RFC"
        '
        'tb_rfcM
        '
        Me.tb_rfcM.Location = New System.Drawing.Point(133, 127)
        Me.tb_rfcM.Name = "tb_rfcM"
        Me.tb_rfcM.Size = New System.Drawing.Size(234, 26)
        Me.tb_rfcM.TabIndex = 13
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(11, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(15, 20)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "*"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(11, 49)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(15, 20)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "*"
        '
        'tb_emailM
        '
        Me.tb_emailM.Location = New System.Drawing.Point(133, 99)
        Me.tb_emailM.Name = "tb_emailM"
        Me.tb_emailM.Size = New System.Drawing.Size(234, 26)
        Me.tb_emailM.TabIndex = 12
        '
        'tb_url
        '
        Me.tb_url.Location = New System.Drawing.Point(133, 71)
        Me.tb_url.Name = "tb_url"
        Me.tb_url.Size = New System.Drawing.Size(234, 26)
        Me.tb_url.TabIndex = 11
        '
        'tb_alias
        '
        Me.tb_alias.Location = New System.Drawing.Point(133, 43)
        Me.tb_alias.Name = "tb_alias"
        Me.tb_alias.Size = New System.Drawing.Size(234, 26)
        Me.tb_alias.TabIndex = 10
        '
        'tb_razon
        '
        Me.tb_razon.Location = New System.Drawing.Point(133, 16)
        Me.tb_razon.Name = "tb_razon"
        Me.tb_razon.Size = New System.Drawing.Size(234, 26)
        Me.tb_razon.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 20)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "E-mail"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "URL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Alias"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Razon Social"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(438, 30)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(411, 392)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(403, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Dirección"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.tb_municipio)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.tb_calle)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.tb_pais)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.tb_estado)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.tb_poblacion)
        Me.Panel3.Controls.Add(Me.tb_cp)
        Me.Panel3.Controls.Add(Me.tb_colonia)
        Me.Panel3.Controls.Add(Me.Label34)
        Me.Panel3.Controls.Add(Me.Label32)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Location = New System.Drawing.Point(6, 13)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(391, 260)
        Me.Panel3.TabIndex = 8
        '
        'tb_municipio
        '
        Me.tb_municipio.Location = New System.Drawing.Point(109, 77)
        Me.tb_municipio.Name = "tb_municipio"
        Me.tb_municipio.Size = New System.Drawing.Size(274, 26)
        Me.tb_municipio.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 20)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Calle"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(29, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 20)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Colonia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 20)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Municipio"
        '
        'tb_calle
        '
        Me.tb_calle.Location = New System.Drawing.Point(109, 10)
        Me.tb_calle.Name = "tb_calle"
        Me.tb_calle.Size = New System.Drawing.Size(274, 26)
        Me.tb_calle.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 113)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 20)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "C.P."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 145)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 20)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Ciudad"
        '
        'tb_pais
        '
        Me.tb_pais.Location = New System.Drawing.Point(109, 206)
        Me.tb_pais.Name = "tb_pais"
        Me.tb_pais.Size = New System.Drawing.Size(220, 26)
        Me.tb_pais.TabIndex = 22
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(30, 177)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 20)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Estado"
        '
        'tb_estado
        '
        Me.tb_estado.Location = New System.Drawing.Point(109, 174)
        Me.tb_estado.Name = "tb_estado"
        Me.tb_estado.Size = New System.Drawing.Size(220, 26)
        Me.tb_estado.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(30, 209)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 20)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Pais"
        '
        'tb_poblacion
        '
        Me.tb_poblacion.Location = New System.Drawing.Point(109, 142)
        Me.tb_poblacion.Name = "tb_poblacion"
        Me.tb_poblacion.Size = New System.Drawing.Size(274, 26)
        Me.tb_poblacion.TabIndex = 2
        '
        'tb_cp
        '
        Me.tb_cp.Location = New System.Drawing.Point(109, 110)
        Me.tb_cp.Name = "tb_cp"
        Me.tb_cp.Size = New System.Drawing.Size(65, 26)
        Me.tb_cp.TabIndex = 19
        '
        'tb_colonia
        '
        Me.tb_colonia.Location = New System.Drawing.Point(108, 43)
        Me.tb_colonia.Name = "tb_colonia"
        Me.tb_colonia.Size = New System.Drawing.Size(275, 26)
        Me.tb_colonia.TabIndex = 17
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(16, 13)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(15, 20)
        Me.Label34.TabIndex = 59
        Me.Label34.Text = "*"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(15, 43)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(15, 20)
        Me.Label32.TabIndex = 57
        Me.Label32.Text = "*"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(16, 77)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(15, 20)
        Me.Label31.TabIndex = 56
        Me.Label31.Text = "*"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(16, 113)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(15, 20)
        Me.Label30.TabIndex = 55
        Me.Label30.Text = "*"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(16, 142)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(15, 20)
        Me.Label29.TabIndex = 54
        Me.Label29.Text = "*"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.SaveToolStripButton, Me.toolStripSeparator, Me.btn_eliminar, Me.tb_salir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(858, 29)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 29)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(4, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(428, 573)
        Me.Panel1.TabIndex = 6
        '
        'gb_clase
        '
        Me.gb_clase.Controls.Add(Me.rb_cliente)
        Me.gb_clase.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_clase.Location = New System.Drawing.Point(10, 28)
        Me.gb_clase.Name = "gb_clase"
        Me.gb_clase.Size = New System.Drawing.Size(367, 49)
        Me.gb_clase.TabIndex = 7
        Me.gb_clase.TabStop = False
        Me.gb_clase.Text = "Seleccionar tipo de persona"
        '
        'rb_cliente
        '
        Me.rb_cliente.AutoSize = True
        Me.rb_cliente.Checked = True
        Me.rb_cliente.Location = New System.Drawing.Point(15, 22)
        Me.rb_cliente.Name = "rb_cliente"
        Me.rb_cliente.Size = New System.Drawing.Size(79, 24)
        Me.rb_cliente.TabIndex = 0
        Me.rb_cliente.TabStop = True
        Me.rb_cliente.Text = "Cliente"
        Me.rb_cliente.UseVisualStyleBackColor = True
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(93, 26)
        Me.NewToolStripButton.Text = "&Nuevo"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(110, 26)
        Me.SaveToolStripButton.Text = "&Guardar"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(97, 26)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'tb_salir
        '
        Me.tb_salir.Image = CType(resources.GetObject("tb_salir.Image"), System.Drawing.Image)
        Me.tb_salir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tb_salir.Name = "tb_salir"
        Me.tb_salir.Size = New System.Drawing.Size(64, 26)
        Me.tb_salir.Text = "Salir"
        '
        'frm_directorio_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 447)
        Me.Controls.Add(Me.gb_clase)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_directorio_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Directorio"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.gb_tipo.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.gb_persona.ResumeLayout(False)
        Me.gb_persona.PerformLayout()
        Me.gb_empresa.ResumeLayout(False)
        Me.gb_empresa.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gb_clase.ResumeLayout(False)
        Me.gb_clase.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rb_fisica As System.Windows.Forms.RadioButton
    Friend WithEvents rb_moral As System.Windows.Forms.RadioButton
    Friend WithEvents gb_tipo As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents gb_empresa As System.Windows.Forms.GroupBox
    Friend WithEvents gb_persona As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_emailM As System.Windows.Forms.TextBox
    Friend WithEvents tb_url As System.Windows.Forms.TextBox
    Friend WithEvents tb_alias As System.Windows.Forms.TextBox
    Friend WithEvents tb_razon As System.Windows.Forms.TextBox
    Friend WithEvents tb_emailF As System.Windows.Forms.TextBox
    Friend WithEvents tb_apellidoM As System.Windows.Forms.TextBox
    Friend WithEvents tb_apellidoP As System.Windows.Forms.TextBox
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tb_calle As System.Windows.Forms.TextBox
    Friend WithEvents tb_pais As System.Windows.Forms.TextBox
    Friend WithEvents tb_estado As System.Windows.Forms.TextBox
    Friend WithEvents tb_poblacion As System.Windows.Forms.TextBox
    Friend WithEvents tb_cp As System.Windows.Forms.TextBox
    Friend WithEvents tb_municipio As System.Windows.Forms.TextBox
    Friend WithEvents tb_colonia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cb_clasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents gb_clase As System.Windows.Forms.GroupBox
    Friend WithEvents rb_cliente As System.Windows.Forms.RadioButton
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents tb_rfcM As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents tb_rfcF As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents ofd_foto As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents tb_alias_fisica As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tb_curp As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tb_salir As System.Windows.Forms.ToolStripButton
End Class
