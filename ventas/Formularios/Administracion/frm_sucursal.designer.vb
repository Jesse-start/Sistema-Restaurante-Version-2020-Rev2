<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sucursal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_sucursal))
        Me.gb_sucursal = New System.Windows.Forms.GroupBox()
        Me.pn_sucursal = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_repetir_contraseña = New System.Windows.Forms.TextBox()
        Me.tb_servidor_contraseña = New System.Windows.Forms.TextBox()
        Me.tb_servidor_usuario = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_servidor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_servidor = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.cb_alias = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.menu_principal = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_editar = New System.Windows.Forms.ToolStripButton()
        Me.btn_guardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_cancelar = New System.Windows.Forms.ToolStripButton()
        Me.gb_telefonos = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.dg_telefonos = New System.Windows.Forms.DataGrid()
        Me.gb_datos_telefono = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.tb_telefono = New System.Windows.Forms.TextBox()
        Me.Tb_lada = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.gb_sucursal.SuspendLayout()
        Me.pn_sucursal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.menu_principal.SuspendLayout()
        Me.gb_telefonos.SuspendLayout()
        CType(Me.dg_telefonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_datos_telefono.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_sucursal
        '
        Me.gb_sucursal.Controls.Add(Me.pn_sucursal)
        Me.gb_sucursal.Controls.Add(Me.cb_alias)
        Me.gb_sucursal.Controls.Add(Me.Label22)
        Me.gb_sucursal.Controls.Add(Me.Label2)
        Me.gb_sucursal.Location = New System.Drawing.Point(7, 29)
        Me.gb_sucursal.Name = "gb_sucursal"
        Me.gb_sucursal.Size = New System.Drawing.Size(367, 399)
        Me.gb_sucursal.TabIndex = 1
        Me.gb_sucursal.TabStop = False
        Me.gb_sucursal.Text = "Datos de la sucursal"
        '
        'pn_sucursal
        '
        Me.pn_sucursal.Controls.Add(Me.GroupBox1)
        Me.pn_sucursal.Controls.Add(Me.tb_municipio)
        Me.pn_sucursal.Controls.Add(Me.Label9)
        Me.pn_sucursal.Controls.Add(Me.Label12)
        Me.pn_sucursal.Controls.Add(Me.Label13)
        Me.pn_sucursal.Controls.Add(Me.tb_calle)
        Me.pn_sucursal.Controls.Add(Me.Label14)
        Me.pn_sucursal.Controls.Add(Me.Label15)
        Me.pn_sucursal.Controls.Add(Me.tb_pais)
        Me.pn_sucursal.Controls.Add(Me.Label16)
        Me.pn_sucursal.Controls.Add(Me.tb_estado)
        Me.pn_sucursal.Controls.Add(Me.Label17)
        Me.pn_sucursal.Controls.Add(Me.tb_poblacion)
        Me.pn_sucursal.Controls.Add(Me.tb_cp)
        Me.pn_sucursal.Controls.Add(Me.tb_colonia)
        Me.pn_sucursal.Controls.Add(Me.Label34)
        Me.pn_sucursal.Controls.Add(Me.Label32)
        Me.pn_sucursal.Controls.Add(Me.Label31)
        Me.pn_sucursal.Controls.Add(Me.Label30)
        Me.pn_sucursal.Controls.Add(Me.Label29)
        Me.pn_sucursal.Location = New System.Drawing.Point(6, 38)
        Me.pn_sucursal.Name = "pn_sucursal"
        Me.pn_sucursal.Size = New System.Drawing.Size(353, 361)
        Me.pn_sucursal.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_repetir_contraseña)
        Me.GroupBox1.Controls.Add(Me.tb_servidor_contraseña)
        Me.GroupBox1.Controls.Add(Me.tb_servidor_usuario)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tb_servidor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lbl_servidor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 127)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuracion para conexion remota"
        '
        'tb_repetir_contraseña
        '
        Me.tb_repetir_contraseña.Location = New System.Drawing.Point(135, 94)
        Me.tb_repetir_contraseña.Name = "tb_repetir_contraseña"
        Me.tb_repetir_contraseña.Size = New System.Drawing.Size(135, 20)
        Me.tb_repetir_contraseña.TabIndex = 82
        Me.tb_repetir_contraseña.UseSystemPasswordChar = True
        '
        'tb_servidor_contraseña
        '
        Me.tb_servidor_contraseña.Location = New System.Drawing.Point(135, 68)
        Me.tb_servidor_contraseña.Name = "tb_servidor_contraseña"
        Me.tb_servidor_contraseña.Size = New System.Drawing.Size(135, 20)
        Me.tb_servidor_contraseña.TabIndex = 83
        Me.tb_servidor_contraseña.UseSystemPasswordChar = True
        '
        'tb_servidor_usuario
        '
        Me.tb_servidor_usuario.Location = New System.Drawing.Point(135, 42)
        Me.tb_servidor_usuario.Name = "tb_servidor_usuario"
        Me.tb_servidor_usuario.Size = New System.Drawing.Size(135, 20)
        Me.tb_servidor_usuario.TabIndex = 81
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(56, 94)
        Me.Label8.MaximumSize = New System.Drawing.Size(100, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 26)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Contraseña (repetir):"
        '
        'tb_servidor
        '
        Me.tb_servidor.Location = New System.Drawing.Point(135, 16)
        Me.tb_servidor.Name = "tb_servidor"
        Me.tb_servidor.Size = New System.Drawing.Size(135, 20)
        Me.tb_servidor.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Contraseña:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Usuario:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(42, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 20)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "*"
        '
        'lbl_servidor
        '
        Me.lbl_servidor.AutoSize = True
        Me.lbl_servidor.Location = New System.Drawing.Point(56, 18)
        Me.lbl_servidor.Name = "lbl_servidor"
        Me.lbl_servidor.Size = New System.Drawing.Size(49, 13)
        Me.lbl_servidor.TabIndex = 72
        Me.lbl_servidor.Text = "Servidor:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(42, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 20)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(42, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 20)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(42, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 20)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "*"
        '
        'tb_municipio
        '
        Me.tb_municipio.Location = New System.Drawing.Point(109, 70)
        Me.tb_municipio.Name = "tb_municipio"
        Me.tb_municipio.Size = New System.Drawing.Size(233, 20)
        Me.tb_municipio.TabIndex = 47
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Calle"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Colonia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Municipio"
        '
        'tb_calle
        '
        Me.tb_calle.Location = New System.Drawing.Point(109, 10)
        Me.tb_calle.Name = "tb_calle"
        Me.tb_calle.Size = New System.Drawing.Size(233, 20)
        Me.tb_calle.TabIndex = 53
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "C.P."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Población"
        '
        'tb_pais
        '
        Me.tb_pais.Location = New System.Drawing.Point(109, 180)
        Me.tb_pais.Name = "tb_pais"
        Me.tb_pais.Size = New System.Drawing.Size(135, 20)
        Me.tb_pais.TabIndex = 51
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(30, 156)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Estado"
        '
        'tb_estado
        '
        Me.tb_estado.Location = New System.Drawing.Point(109, 153)
        Me.tb_estado.Name = "tb_estado"
        Me.tb_estado.Size = New System.Drawing.Size(135, 20)
        Me.tb_estado.TabIndex = 50
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(33, 180)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Pais"
        '
        'tb_poblacion
        '
        Me.tb_poblacion.Location = New System.Drawing.Point(109, 126)
        Me.tb_poblacion.Name = "tb_poblacion"
        Me.tb_poblacion.Size = New System.Drawing.Size(233, 20)
        Me.tb_poblacion.TabIndex = 49
        '
        'tb_cp
        '
        Me.tb_cp.Location = New System.Drawing.Point(109, 98)
        Me.tb_cp.Name = "tb_cp"
        Me.tb_cp.Size = New System.Drawing.Size(65, 20)
        Me.tb_cp.TabIndex = 48
        '
        'tb_colonia
        '
        Me.tb_colonia.Location = New System.Drawing.Point(109, 42)
        Me.tb_colonia.Name = "tb_colonia"
        Me.tb_colonia.Size = New System.Drawing.Size(233, 20)
        Me.tb_colonia.TabIndex = 46
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
        Me.Label32.Location = New System.Drawing.Point(16, 42)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(15, 20)
        Me.Label32.TabIndex = 57
        Me.Label32.Text = "*"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(16, 70)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(15, 20)
        Me.Label31.TabIndex = 56
        Me.Label31.Text = "*"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(16, 101)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(15, 20)
        Me.Label30.TabIndex = 55
        Me.Label30.Text = "*"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(16, 126)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(15, 20)
        Me.Label29.TabIndex = 54
        Me.Label29.Text = "*"
        '
        'cb_alias
        '
        Me.cb_alias.FormattingEnabled = True
        Me.cb_alias.Location = New System.Drawing.Point(115, 15)
        Me.cb_alias.Name = "cb_alias"
        Me.cb_alias.Size = New System.Drawing.Size(233, 21)
        Me.cb_alias.TabIndex = 21
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(23, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(15, 20)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Alias"
        '
        'menu_principal
        '
        Me.menu_principal.BackColor = System.Drawing.SystemColors.Control
        Me.menu_principal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevo, Me.btn_editar, Me.btn_guardar, Me.btn_eliminar, Me.ToolStripSeparator1, Me.btn_cancelar})
        Me.menu_principal.Location = New System.Drawing.Point(0, 0)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(732, 25)
        Me.menu_principal.TabIndex = 31
        Me.menu_principal.Text = "ToolStrip1"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.AutoToolTip = False
        Me.btn_nuevo.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(58, 22)
        Me.btn_nuevo.Text = "&Nuevo"
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(55, 22)
        Me.btn_editar.Text = "Editar"
        '
        'btn_guardar
        '
        Me.btn_guardar.AutoToolTip = False
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(66, 22)
        Me.btn_guardar.Text = "&Guardar"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.AutoToolTip = False
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(63, 22)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btn_cancelar
        '
        Me.btn_cancelar.AutoToolTip = False
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(53, 22)
        Me.btn_cancelar.Text = "Cancelar"
        '
        'gb_telefonos
        '
        Me.gb_telefonos.Controls.Add(Me.Button5)
        Me.gb_telefonos.Controls.Add(Me.Button6)
        Me.gb_telefonos.Controls.Add(Me.dg_telefonos)
        Me.gb_telefonos.Enabled = False
        Me.gb_telefonos.Location = New System.Drawing.Point(385, 31)
        Me.gb_telefonos.Name = "gb_telefonos"
        Me.gb_telefonos.Size = New System.Drawing.Size(343, 178)
        Me.gb_telefonos.TabIndex = 24
        Me.gb_telefonos.TabStop = False
        Me.gb_telefonos.Text = "Telefonos"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(209, 148)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "Quitar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(86, 148)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 1
        Me.Button6.Text = "Agregar"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'dg_telefonos
        '
        Me.dg_telefonos.DataMember = ""
        Me.dg_telefonos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_telefonos.Location = New System.Drawing.Point(4, 16)
        Me.dg_telefonos.Name = "dg_telefonos"
        Me.dg_telefonos.Size = New System.Drawing.Size(333, 126)
        Me.dg_telefonos.TabIndex = 0
        '
        'gb_datos_telefono
        '
        Me.gb_datos_telefono.Controls.Add(Me.Button7)
        Me.gb_datos_telefono.Controls.Add(Me.Button8)
        Me.gb_datos_telefono.Controls.Add(Me.tb_telefono)
        Me.gb_datos_telefono.Controls.Add(Me.Tb_lada)
        Me.gb_datos_telefono.Controls.Add(Me.Label24)
        Me.gb_datos_telefono.Controls.Add(Me.Label25)
        Me.gb_datos_telefono.Enabled = False
        Me.gb_datos_telefono.Location = New System.Drawing.Point(385, 215)
        Me.gb_datos_telefono.Name = "gb_datos_telefono"
        Me.gb_datos_telefono.Size = New System.Drawing.Size(343, 165)
        Me.gb_datos_telefono.TabIndex = 25
        Me.gb_datos_telefono.TabStop = False
        Me.gb_datos_telefono.Text = "Telefono de la sucursal"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(86, 84)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "Aceptar"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(209, 84)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 9
        Me.Button8.Text = "Cancelar"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'tb_telefono
        '
        Me.tb_telefono.Location = New System.Drawing.Point(173, 47)
        Me.tb_telefono.Name = "tb_telefono"
        Me.tb_telefono.Size = New System.Drawing.Size(127, 20)
        Me.tb_telefono.TabIndex = 5
        '
        'Tb_lada
        '
        Me.Tb_lada.Location = New System.Drawing.Point(173, 19)
        Me.Tb_lada.Name = "Tb_lada"
        Me.Tb_lada.Size = New System.Drawing.Size(65, 20)
        Me.Tb_lada.TabIndex = 4
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(76, 50)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Telefono"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(76, 22)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(31, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Lada"
        '
        'frm_sucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 431)
        Me.Controls.Add(Me.gb_telefonos)
        Me.Controls.Add(Me.gb_datos_telefono)
        Me.Controls.Add(Me.menu_principal)
        Me.Controls.Add(Me.gb_sucursal)
        Me.Name = "frm_sucursal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursales"
        Me.gb_sucursal.ResumeLayout(False)
        Me.gb_sucursal.PerformLayout()
        Me.pn_sucursal.ResumeLayout(False)
        Me.pn_sucursal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        Me.gb_telefonos.ResumeLayout(False)
        CType(Me.dg_telefonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_datos_telefono.ResumeLayout(False)
        Me.gb_datos_telefono.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb_sucursal As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_alias As System.Windows.Forms.ComboBox
    Friend WithEvents menu_principal As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_editar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btn_cancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents pn_sucursal As System.Windows.Forms.Panel
    Friend WithEvents tb_municipio As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb_calle As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tb_pais As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_estado As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_poblacion As System.Windows.Forms.TextBox
    Friend WithEvents tb_cp As System.Windows.Forms.TextBox
    Friend WithEvents tb_colonia As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents gb_telefonos As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents dg_telefonos As System.Windows.Forms.DataGrid
    Friend WithEvents gb_datos_telefono As System.Windows.Forms.GroupBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents tb_telefono As System.Windows.Forms.TextBox
    Friend WithEvents Tb_lada As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_repetir_contraseña As System.Windows.Forms.TextBox
    Friend WithEvents tb_servidor_contraseña As System.Windows.Forms.TextBox
    Friend WithEvents tb_servidor_usuario As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_servidor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_servidor As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
