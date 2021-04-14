<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_perfiles
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_pos_x = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg_campos = New System.Windows.Forms.DataGrid()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_nombre_campo = New System.Windows.Forms.TextBox()
        Me.tb_pos_y = New System.Windows.Forms.TextBox()
        Me.lb_quitar_perfil = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.menu_perfil = New System.Windows.Forms.MenuStrip()
        Me.m_archivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_nuevo_perfil = New System.Windows.Forms.ToolStripMenuItem()
        Me.m_cerrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_quitar_perfil = New System.Windows.Forms.Button()
        Me.dg_perfiles = New System.Windows.Forms.DataGrid()
        Me.m_nuevo_campo = New System.Windows.Forms.ToolStripButton()
        Me.btn_agregar_perfil = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.menu_campo = New System.Windows.Forms.ToolStrip()
        Me.tb_alto = New System.Windows.Forms.TextBox()
        Me.gb_perfil = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_max_productos = New System.Windows.Forms.TextBox()
        Me.chb_max_lineas = New System.Windows.Forms.CheckBox()
        Me.chb_ajuste = New System.Windows.Forms.CheckBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.tb_ajuste_y = New System.Windows.Forms.TextBox()
        Me.tb_ajuste_x = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cb_documento = New System.Windows.Forms.ComboBox()
        Me.img_ancho = New System.Windows.Forms.PictureBox()
        Me.img_alto = New System.Windows.Forms.PictureBox()
        Me.tb_ancho = New System.Windows.Forms.TextBox()
        Me.tb_nombre_perfil = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_quitar_campo = New System.Windows.Forms.Label()
        Me.gb_campos = New System.Windows.Forms.GroupBox()
        Me.tb_campos = New System.Windows.Forms.ComboBox()
        Me.btn_quitar_campo = New System.Windows.Forms.Button()
        Me.btn_agregar_campo = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dg_campos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu_perfil.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_perfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu_campo.SuspendLayout()
        Me.gb_perfil.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_ancho, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.img_alto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_campos.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nombre:"
        '
        'tb_pos_x
        '
        Me.tb_pos_x.Location = New System.Drawing.Point(293, 31)
        Me.tb_pos_x.Name = "tb_pos_x"
        Me.tb_pos_x.Size = New System.Drawing.Size(80, 20)
        Me.tb_pos_x.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Alto:"
        '
        'dg_campos
        '
        Me.dg_campos.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dg_campos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_campos.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.dg_campos.DataMember = ""
        Me.dg_campos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dg_campos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_campos.Location = New System.Drawing.Point(3, 83)
        Me.dg_campos.Name = "dg_campos"
        Me.dg_campos.ReadOnly = True
        Me.dg_campos.Size = New System.Drawing.Size(406, 225)
        Me.dg_campos.TabIndex = 130
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(379, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "cm."
        '
        'tb_nombre_campo
        '
        Me.tb_nombre_campo.Location = New System.Drawing.Point(17, 55)
        Me.tb_nombre_campo.Name = "tb_nombre_campo"
        Me.tb_nombre_campo.Size = New System.Drawing.Size(39, 20)
        Me.tb_nombre_campo.TabIndex = 105
        Me.tb_nombre_campo.Visible = False
        '
        'tb_pos_y
        '
        Me.tb_pos_y.Location = New System.Drawing.Point(293, 59)
        Me.tb_pos_y.Name = "tb_pos_y"
        Me.tb_pos_y.Size = New System.Drawing.Size(80, 20)
        Me.tb_pos_y.TabIndex = 115
        '
        'lb_quitar_perfil
        '
        Me.lb_quitar_perfil.AutoSize = True
        Me.lb_quitar_perfil.BackColor = System.Drawing.SystemColors.Control
        Me.lb_quitar_perfil.Location = New System.Drawing.Point(23, 18)
        Me.lb_quitar_perfil.Name = "lb_quitar_perfil"
        Me.lb_quitar_perfil.Size = New System.Drawing.Size(103, 13)
        Me.lb_quitar_perfil.TabIndex = 13
        Me.lb_quitar_perfil.Text = "Quitar Seleccionado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(379, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "cm."
        '
        'menu_perfil
        '
        Me.menu_perfil.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_archivo})
        Me.menu_perfil.Location = New System.Drawing.Point(0, 0)
        Me.menu_perfil.Name = "menu_perfil"
        Me.menu_perfil.Size = New System.Drawing.Size(686, 24)
        Me.menu_perfil.TabIndex = 101
        Me.menu_perfil.Text = "MenuStrip1"
        '
        'm_archivo
        '
        Me.m_archivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_nuevo_perfil, Me.m_cerrar})
        Me.m_archivo.Name = "m_archivo"
        Me.m_archivo.Size = New System.Drawing.Size(60, 20)
        Me.m_archivo.Text = "&Archivo"
        '
        'm_nuevo_perfil
        '
        Me.m_nuevo_perfil.Name = "m_nuevo_perfil"
        Me.m_nuevo_perfil.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.m_nuevo_perfil.Size = New System.Drawing.Size(182, 22)
        Me.m_nuevo_perfil.Text = "&Nuevo Perfil"
        '
        'm_cerrar
        '
        Me.m_cerrar.Name = "m_cerrar"
        Me.m_cerrar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.m_cerrar.Size = New System.Drawing.Size(182, 22)
        Me.m_cerrar.Text = "&Cerrar"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lb_quitar_perfil)
        Me.GroupBox3.Controls.Add(Me.btn_quitar_perfil)
        Me.GroupBox3.Controls.Add(Me.dg_perfiles)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(242, 448)
        Me.GroupBox3.TabIndex = 102
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Perfiles"
        '
        'btn_quitar_perfil
        '
        Me.btn_quitar_perfil.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_quitar_perfil.Location = New System.Drawing.Point(3, 16)
        Me.btn_quitar_perfil.Name = "btn_quitar_perfil"
        Me.btn_quitar_perfil.Size = New System.Drawing.Size(17, 17)
        Me.btn_quitar_perfil.TabIndex = 15
        Me.btn_quitar_perfil.UseVisualStyleBackColor = True
        '
        'dg_perfiles
        '
        Me.dg_perfiles.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dg_perfiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg_perfiles.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.dg_perfiles.DataMember = ""
        Me.dg_perfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_perfiles.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_perfiles.Location = New System.Drawing.Point(3, 16)
        Me.dg_perfiles.Name = "dg_perfiles"
        Me.dg_perfiles.ReadOnly = True
        Me.dg_perfiles.Size = New System.Drawing.Size(236, 429)
        Me.dg_perfiles.TabIndex = 20
        '
        'm_nuevo_campo
        '
        Me.m_nuevo_campo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m_nuevo_campo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_nuevo_campo.Name = "m_nuevo_campo"
        Me.m_nuevo_campo.Size = New System.Drawing.Size(88, 24)
        Me.m_nuevo_campo.Text = "Nuevo Campo"
        '
        'btn_agregar_perfil
        '
        Me.btn_agregar_perfil.Location = New System.Drawing.Point(293, 111)
        Me.btn_agregar_perfil.Name = "btn_agregar_perfil"
        Me.btn_agregar_perfil.Size = New System.Drawing.Size(80, 23)
        Me.btn_agregar_perfil.TabIndex = 70
        Me.btn_agregar_perfil.Text = "Agregar"
        Me.btn_agregar_perfil.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Nombre desl Perfil:"
        '
        'menu_campo
        '
        Me.menu_campo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_campo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_nuevo_campo})
        Me.menu_campo.Location = New System.Drawing.Point(3, 16)
        Me.menu_campo.Name = "menu_campo"
        Me.menu_campo.Size = New System.Drawing.Size(406, 27)
        Me.menu_campo.TabIndex = 9
        Me.menu_campo.Text = "ToolStrip1"
        Me.menu_campo.Visible = False
        '
        'tb_alto
        '
        Me.tb_alto.Location = New System.Drawing.Point(115, 76)
        Me.tb_alto.Name = "tb_alto"
        Me.tb_alto.Size = New System.Drawing.Size(60, 20)
        Me.tb_alto.TabIndex = 60
        '
        'gb_perfil
        '
        Me.gb_perfil.Controls.Add(Me.GroupBox1)
        Me.gb_perfil.Controls.Add(Me.Label9)
        Me.gb_perfil.Controls.Add(Me.cb_documento)
        Me.gb_perfil.Controls.Add(Me.btn_agregar_perfil)
        Me.gb_perfil.Controls.Add(Me.img_ancho)
        Me.gb_perfil.Controls.Add(Me.Label8)
        Me.gb_perfil.Controls.Add(Me.tb_alto)
        Me.gb_perfil.Controls.Add(Me.img_alto)
        Me.gb_perfil.Controls.Add(Me.tb_ancho)
        Me.gb_perfil.Controls.Add(Me.tb_nombre_perfil)
        Me.gb_perfil.Controls.Add(Me.Label4)
        Me.gb_perfil.Controls.Add(Me.Label3)
        Me.gb_perfil.Controls.Add(Me.Label1)
        Me.gb_perfil.Controls.Add(Me.Label2)
        Me.gb_perfil.Location = New System.Drawing.Point(260, 29)
        Me.gb_perfil.Name = "gb_perfil"
        Me.gb_perfil.Size = New System.Drawing.Size(414, 227)
        Me.gb_perfil.TabIndex = 103
        Me.gb_perfil.TabStop = False
        Me.gb_perfil.Text = "Propiedades del Perfil"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_max_productos)
        Me.GroupBox1.Controls.Add(Me.chb_max_lineas)
        Me.GroupBox1.Controls.Add(Me.chb_ajuste)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.tb_ajuste_y)
        Me.GroupBox1.Controls.Add(Me.tb_ajuste_x)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 142)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 72)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ajuste de impresion"
        '
        'tb_max_productos
        '
        Me.tb_max_productos.Enabled = False
        Me.tb_max_productos.Location = New System.Drawing.Point(215, 43)
        Me.tb_max_productos.Name = "tb_max_productos"
        Me.tb_max_productos.Size = New System.Drawing.Size(54, 20)
        Me.tb_max_productos.TabIndex = 118
        '
        'chb_max_lineas
        '
        Me.chb_max_lineas.AutoSize = True
        Me.chb_max_lineas.Location = New System.Drawing.Point(7, 45)
        Me.chb_max_lineas.Name = "chb_max_lineas"
        Me.chb_max_lineas.Size = New System.Drawing.Size(121, 17)
        Me.chb_max_lineas.TabIndex = 117
        Me.chb_max_lineas.Text = "Limite de productos:"
        Me.chb_max_lineas.UseVisualStyleBackColor = True
        '
        'chb_ajuste
        '
        Me.chb_ajuste.AutoSize = True
        Me.chb_ajuste.Location = New System.Drawing.Point(7, 18)
        Me.chb_ajuste.Name = "chb_ajuste"
        Me.chb_ajuste.Size = New System.Drawing.Size(178, 17)
        Me.chb_ajuste.TabIndex = 116
        Me.chb_ajuste.Text = "Reducir margenes  de impresora"
        Me.chb_ajuste.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.PictureBox4.Location = New System.Drawing.Point(301, 16)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 22)
        Me.PictureBox4.TabIndex = 8
        Me.PictureBox4.TabStop = False
        '
        'tb_ajuste_y
        '
        Me.tb_ajuste_y.Enabled = False
        Me.tb_ajuste_y.Location = New System.Drawing.Point(323, 18)
        Me.tb_ajuste_y.Name = "tb_ajuste_y"
        Me.tb_ajuste_y.Size = New System.Drawing.Size(50, 20)
        Me.tb_ajuste_y.TabIndex = 115
        '
        'tb_ajuste_x
        '
        Me.tb_ajuste_x.Enabled = False
        Me.tb_ajuste_x.Location = New System.Drawing.Point(215, 16)
        Me.tb_ajuste_x.Name = "tb_ajuste_x"
        Me.tb_ajuste_x.Size = New System.Drawing.Size(54, 20)
        Me.tb_ajuste_x.TabIndex = 110
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.PictureBox3.Location = New System.Drawing.Point(187, 20)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(22, 16)
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(271, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "cm."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(379, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "cm."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 114)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Documento:"
        '
        'cb_documento
        '
        Me.cb_documento.Enabled = False
        Me.cb_documento.FormattingEnabled = True
        Me.cb_documento.Location = New System.Drawing.Point(85, 111)
        Me.cb_documento.Name = "cb_documento"
        Me.cb_documento.Size = New System.Drawing.Size(162, 21)
        Me.cb_documento.TabIndex = 71
        '
        'img_ancho
        '
        Me.img_ancho.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.img_ancho.Location = New System.Drawing.Point(234, 66)
        Me.img_ancho.Name = "img_ancho"
        Me.img_ancho.Size = New System.Drawing.Size(26, 38)
        Me.img_ancho.TabIndex = 1
        Me.img_ancho.TabStop = False
        '
        'img_alto
        '
        Me.img_alto.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.img_alto.Location = New System.Drawing.Point(41, 68)
        Me.img_alto.Name = "img_alto"
        Me.img_alto.Size = New System.Drawing.Size(34, 30)
        Me.img_alto.TabIndex = 0
        Me.img_alto.TabStop = False
        '
        'tb_ancho
        '
        Me.tb_ancho.Location = New System.Drawing.Point(313, 76)
        Me.tb_ancho.Name = "tb_ancho"
        Me.tb_ancho.Size = New System.Drawing.Size(60, 20)
        Me.tb_ancho.TabIndex = 65
        '
        'tb_nombre_perfil
        '
        Me.tb_nombre_perfil.Location = New System.Drawing.Point(114, 31)
        Me.tb_nombre_perfil.Name = "tb_nombre_perfil"
        Me.tb_nombre_perfil.Size = New System.Drawing.Size(259, 20)
        Me.tb_nombre_perfil.TabIndex = 55
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(379, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "cm."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "cm."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ancho:"
        '
        'lb_quitar_campo
        '
        Me.lb_quitar_campo.AutoSize = True
        Me.lb_quitar_campo.BackColor = System.Drawing.SystemColors.Control
        Me.lb_quitar_campo.Location = New System.Drawing.Point(23, 83)
        Me.lb_quitar_campo.Name = "lb_quitar_campo"
        Me.lb_quitar_campo.Size = New System.Drawing.Size(103, 13)
        Me.lb_quitar_campo.TabIndex = 11
        Me.lb_quitar_campo.Text = "Quitar Seleccionado"
        '
        'gb_campos
        '
        Me.gb_campos.Controls.Add(Me.tb_campos)
        Me.gb_campos.Controls.Add(Me.lb_quitar_campo)
        Me.gb_campos.Controls.Add(Me.btn_quitar_campo)
        Me.gb_campos.Controls.Add(Me.btn_agregar_campo)
        Me.gb_campos.Controls.Add(Me.PictureBox2)
        Me.gb_campos.Controls.Add(Me.Label5)
        Me.gb_campos.Controls.Add(Me.PictureBox1)
        Me.gb_campos.Controls.Add(Me.tb_pos_x)
        Me.gb_campos.Controls.Add(Me.dg_campos)
        Me.gb_campos.Controls.Add(Me.Label7)
        Me.gb_campos.Controls.Add(Me.tb_nombre_campo)
        Me.gb_campos.Controls.Add(Me.tb_pos_y)
        Me.gb_campos.Controls.Add(Me.Label6)
        Me.gb_campos.Controls.Add(Me.menu_campo)
        Me.gb_campos.Location = New System.Drawing.Point(260, 255)
        Me.gb_campos.Name = "gb_campos"
        Me.gb_campos.Size = New System.Drawing.Size(412, 311)
        Me.gb_campos.TabIndex = 104
        Me.gb_campos.TabStop = False
        Me.gb_campos.Text = "Campos"
        '
        'tb_campos
        '
        Me.tb_campos.FormattingEnabled = True
        Me.tb_campos.Location = New System.Drawing.Point(84, 30)
        Me.tb_campos.Name = "tb_campos"
        Me.tb_campos.Size = New System.Drawing.Size(163, 21)
        Me.tb_campos.TabIndex = 131
        '
        'btn_quitar_campo
        '
        Me.btn_quitar_campo.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_quitar_campo.Location = New System.Drawing.Point(3, 81)
        Me.btn_quitar_campo.Name = "btn_quitar_campo"
        Me.btn_quitar_campo.Size = New System.Drawing.Size(17, 17)
        Me.btn_quitar_campo.TabIndex = 125
        Me.btn_quitar_campo.UseVisualStyleBackColor = True
        '
        'btn_agregar_campo
        '
        Me.btn_agregar_campo.Location = New System.Drawing.Point(167, 59)
        Me.btn_agregar_campo.Name = "btn_agregar_campo"
        Me.btn_agregar_campo.Size = New System.Drawing.Size(80, 23)
        Me.btn_agregar_campo.TabIndex = 120
        Me.btn_agregar_campo.Text = "Agregar"
        Me.btn_agregar_campo.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.PictureBox2.Location = New System.Drawing.Point(271, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 22)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.PictureBox1.Location = New System.Drawing.Point(265, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 16)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'frm_perfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 578)
        Me.Controls.Add(Me.menu_perfil)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gb_perfil)
        Me.Controls.Add(Me.gb_campos)
        Me.Name = "frm_perfiles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Perfiles de impresión"
        CType(Me.dg_campos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu_perfil.ResumeLayout(False)
        Me.menu_perfil.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_perfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu_campo.ResumeLayout(False)
        Me.menu_campo.PerformLayout()
        Me.gb_perfil.ResumeLayout(False)
        Me.gb_perfil.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_ancho, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.img_alto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_campos.ResumeLayout(False)
        Me.gb_campos.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pos_x As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dg_campos As System.Windows.Forms.DataGrid
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre_campo As System.Windows.Forms.TextBox
    Friend WithEvents tb_pos_y As System.Windows.Forms.TextBox
    Friend WithEvents lb_quitar_perfil As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents menu_perfil As System.Windows.Forms.MenuStrip
    Friend WithEvents m_archivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_nuevo_perfil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents m_cerrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_quitar_perfil As System.Windows.Forms.Button
    Friend WithEvents dg_perfiles As System.Windows.Forms.DataGrid
    Friend WithEvents m_nuevo_campo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_agregar_perfil As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents menu_campo As System.Windows.Forms.ToolStrip
    Friend WithEvents img_ancho As System.Windows.Forms.PictureBox
    Friend WithEvents tb_alto As System.Windows.Forms.TextBox
    Friend WithEvents gb_perfil As System.Windows.Forms.GroupBox
    Friend WithEvents img_alto As System.Windows.Forms.PictureBox
    Friend WithEvents tb_ancho As System.Windows.Forms.TextBox
    Friend WithEvents tb_nombre_perfil As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lb_quitar_campo As System.Windows.Forms.Label
    Friend WithEvents gb_campos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_quitar_campo As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_campo As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cb_documento As System.Windows.Forms.ComboBox
    Friend WithEvents tb_campos As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_max_productos As System.Windows.Forms.TextBox
    Friend WithEvents chb_max_lineas As System.Windows.Forms.CheckBox
    Friend WithEvents chb_ajuste As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents tb_ajuste_y As System.Windows.Forms.TextBox
    Friend WithEvents tb_ajuste_x As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
