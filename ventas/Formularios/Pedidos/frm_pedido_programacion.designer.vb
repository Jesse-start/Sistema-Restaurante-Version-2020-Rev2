<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pedido_programacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pedido_programacion))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.menu_principal = New System.Windows.Forms.ToolStrip()
        Me.m_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.m_abrir = New System.Windows.Forms.ToolStripButton()
        Me.m_guardar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.m_exportar = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dg_cotizacion = New System.Windows.Forms.DataGridView()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_otros_impuestos = New System.Windows.Forms.TextBox()
        Me.tb_iva = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.panel_precio = New System.Windows.Forms.FlowLayoutPanel()
        Me.panel_precio_especial = New System.Windows.Forms.Panel()
        Me.tb_precio_especial = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.panel_lista_precio = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cb_precio = New System.Windows.Forms.ListBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbl_fecha3 = New System.Windows.Forms.Label()
        Me.lbl_fecha2 = New System.Windows.Forms.Label()
        Me.lbl_fecha1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gb_programacion = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtp_hora = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_dia = New System.Windows.Forms.ComboBox()
        Me.cb_dia_semana = New System.Windows.Forms.ComboBox()
        Me.cb_periodicidad = New System.Windows.Forms.ComboBox()
        Me.tb_periodo = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_nombre_prog = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tb_empleado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tb_puesto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_numero_programacion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pb_url = New System.Windows.Forms.PictureBox()
        Me.cb_telefono = New System.Windows.Forms.ComboBox()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.tb_email = New System.Windows.Forms.TextBox()
        Me.tb_domicilio = New System.Windows.Forms.TextBox()
        Me.lb_email = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gp_agregar = New System.Windows.Forms.GroupBox()
        Me.btn_bucar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.menu_principal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dg_cotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.panel_precio.SuspendLayout()
        Me.panel_precio_especial.SuspendLayout()
        Me.panel_lista_precio.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.gb_programacion.SuspendLayout()
        CType(Me.tb_periodo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_url, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gp_agregar.SuspendLayout()
        Me.SuspendLayout()
        '
        'menu_principal
        '
        Me.menu_principal.BackColor = System.Drawing.SystemColors.Control
        Me.menu_principal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_nuevo, Me.m_abrir, Me.m_guardar, Me.toolStripSeparator, Me.m_exportar})
        Me.menu_principal.Location = New System.Drawing.Point(5, 0)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(882, 25)
        Me.menu_principal.TabIndex = 12
        Me.menu_principal.Text = "ToolStrip1"
        '
        'm_nuevo
        '
        Me.m_nuevo.AutoToolTip = False
        Me.m_nuevo.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.m_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_nuevo.Name = "m_nuevo"
        Me.m_nuevo.Size = New System.Drawing.Size(62, 22)
        Me.m_nuevo.Text = "&Nuevo"
        '
        'm_abrir
        '
        Me.m_abrir.AutoToolTip = False
        Me.m_abrir.Image = CType(resources.GetObject("m_abrir.Image"), System.Drawing.Image)
        Me.m_abrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_abrir.Name = "m_abrir"
        Me.m_abrir.Size = New System.Drawing.Size(53, 22)
        Me.m_abrir.Text = "&Abrir"
        '
        'm_guardar
        '
        Me.m_guardar.AutoToolTip = False
        Me.m_guardar.Image = CType(resources.GetObject("m_guardar.Image"), System.Drawing.Image)
        Me.m_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_guardar.Name = "m_guardar"
        Me.m_guardar.Size = New System.Drawing.Size(69, 22)
        Me.m_guardar.Text = "&Guardar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'm_exportar
        '
        Me.m_exportar.AutoToolTip = False
        Me.m_exportar.Image = CType(resources.GetObject("m_exportar.Image"), System.Drawing.Image)
        Me.m_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_exportar.Name = "m_exportar"
        Me.m_exportar.Size = New System.Drawing.Size(71, 22)
        Me.m_exportar.Text = "&Exportar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dg_cotizacion)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 531)
        Me.Panel1.TabIndex = 14
        '
        'dg_cotizacion
        '
        Me.dg_cotizacion.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cotizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dg_cotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_cotizacion.DefaultCellStyle = DataGridViewCellStyle5
        Me.dg_cotizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_cotizacion.Location = New System.Drawing.Point(0, 183)
        Me.dg_cotizacion.Name = "dg_cotizacion"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cotizacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dg_cotizacion.Size = New System.Drawing.Size(678, 348)
        Me.dg_cotizacion.TabIndex = 31
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel7.Controls.Add(Me.panel_precio)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(678, 183)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(204, 348)
        Me.Panel7.TabIndex = 27
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(204, 205)
        Me.FlowLayoutPanel1.TabIndex = 25
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tb_total)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 152)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(190, 50)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total"
        '
        'tb_total
        '
        Me.tb_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(48, 18)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(129, 24)
        Me.tb_total.TabIndex = 0
        Me.tb_total.TabStop = False
        Me.tb_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_otros_impuestos)
        Me.GroupBox1.Controls.Add(Me.tb_iva)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 82)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impuestos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Otros:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "I.V.A.:"
        '
        'tb_otros_impuestos
        '
        Me.tb_otros_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_otros_impuestos.Location = New System.Drawing.Point(48, 49)
        Me.tb_otros_impuestos.Name = "tb_otros_impuestos"
        Me.tb_otros_impuestos.ReadOnly = True
        Me.tb_otros_impuestos.Size = New System.Drawing.Size(129, 24)
        Me.tb_otros_impuestos.TabIndex = 0
        Me.tb_otros_impuestos.TabStop = False
        Me.tb_otros_impuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_iva
        '
        Me.tb_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_iva.Location = New System.Drawing.Point(48, 19)
        Me.tb_iva.Name = "tb_iva"
        Me.tb_iva.ReadOnly = True
        Me.tb_iva.Size = New System.Drawing.Size(129, 24)
        Me.tb_iva.TabIndex = 0
        Me.tb_iva.TabStop = False
        Me.tb_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tb_subtotal)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(190, 48)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Subtotal"
        '
        'tb_subtotal
        '
        Me.tb_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_subtotal.Location = New System.Drawing.Point(48, 18)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.ReadOnly = True
        Me.tb_subtotal.Size = New System.Drawing.Size(129, 24)
        Me.tb_subtotal.TabIndex = 0
        Me.tb_subtotal.TabStop = False
        Me.tb_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'panel_precio
        '
        Me.panel_precio.Controls.Add(Me.panel_precio_especial)
        Me.panel_precio.Controls.Add(Me.panel_lista_precio)
        Me.panel_precio.Location = New System.Drawing.Point(5, 212)
        Me.panel_precio.Name = "panel_precio"
        Me.panel_precio.Size = New System.Drawing.Size(196, 191)
        Me.panel_precio.TabIndex = 16
        '
        'panel_precio_especial
        '
        Me.panel_precio_especial.Controls.Add(Me.tb_precio_especial)
        Me.panel_precio_especial.Controls.Add(Me.Label14)
        Me.panel_precio_especial.Location = New System.Drawing.Point(3, 3)
        Me.panel_precio_especial.Name = "panel_precio_especial"
        Me.panel_precio_especial.Size = New System.Drawing.Size(190, 96)
        Me.panel_precio_especial.TabIndex = 6
        '
        'tb_precio_especial
        '
        Me.tb_precio_especial.BackColor = System.Drawing.SystemColors.Control
        Me.tb_precio_especial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tb_precio_especial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_precio_especial.Location = New System.Drawing.Point(6, 21)
        Me.tb_precio_especial.Name = "tb_precio_especial"
        Me.tb_precio_especial.Size = New System.Drawing.Size(184, 19)
        Me.tb_precio_especial.TabIndex = 1
        Me.tb_precio_especial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(178, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "El Producto tiene un precio Especial"
        '
        'panel_lista_precio
        '
        Me.panel_lista_precio.Controls.Add(Me.Label13)
        Me.panel_lista_precio.Controls.Add(Me.cb_precio)
        Me.panel_lista_precio.Location = New System.Drawing.Point(3, 105)
        Me.panel_lista_precio.Name = "panel_lista_precio"
        Me.panel_lista_precio.Size = New System.Drawing.Size(190, 122)
        Me.panel_lista_precio.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(102, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Precios Disponibles:"
        '
        'cb_precio
        '
        Me.cb_precio.FormattingEnabled = True
        Me.cb_precio.Location = New System.Drawing.Point(25, 21)
        Me.cb_precio.Name = "cb_precio"
        Me.cb_precio.Size = New System.Drawing.Size(144, 95)
        Me.cb_precio.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lbl_fecha3)
        Me.Panel6.Controls.Add(Me.lbl_fecha2)
        Me.Panel6.Controls.Add(Me.lbl_fecha1)
        Me.Panel6.Controls.Add(Me.Label16)
        Me.Panel6.Controls.Add(Me.gb_programacion)
        Me.Panel6.Controls.Add(Me.GroupBox3)
        Me.Panel6.Controls.Add(Me.GroupBox2)
        Me.Panel6.Controls.Add(Me.gp_agregar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(882, 183)
        Me.Panel6.TabIndex = 23
        '
        'lbl_fecha3
        '
        Me.lbl_fecha3.AutoSize = True
        Me.lbl_fecha3.Location = New System.Drawing.Point(528, 162)
        Me.lbl_fecha3.Name = "lbl_fecha3"
        Me.lbl_fecha3.Size = New System.Drawing.Size(10, 13)
        Me.lbl_fecha3.TabIndex = 17
        Me.lbl_fecha3.Text = "-"
        '
        'lbl_fecha2
        '
        Me.lbl_fecha2.AutoSize = True
        Me.lbl_fecha2.Location = New System.Drawing.Point(528, 145)
        Me.lbl_fecha2.Name = "lbl_fecha2"
        Me.lbl_fecha2.Size = New System.Drawing.Size(10, 13)
        Me.lbl_fecha2.TabIndex = 17
        Me.lbl_fecha2.Text = "-"
        '
        'lbl_fecha1
        '
        Me.lbl_fecha1.AutoSize = True
        Me.lbl_fecha1.Location = New System.Drawing.Point(528, 127)
        Me.lbl_fecha1.Name = "lbl_fecha1"
        Me.lbl_fecha1.Size = New System.Drawing.Size(13, 13)
        Me.lbl_fecha1.TabIndex = 17
        Me.lbl_fecha1.Text = "--"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(361, 135)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(155, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Proximas entregas a programar:"
        '
        'gb_programacion
        '
        Me.gb_programacion.Controls.Add(Me.Label18)
        Me.gb_programacion.Controls.Add(Me.Label17)
        Me.gb_programacion.Controls.Add(Me.Label7)
        Me.gb_programacion.Controls.Add(Me.dtp_hora)
        Me.gb_programacion.Controls.Add(Me.Label3)
        Me.gb_programacion.Controls.Add(Me.cb_dia)
        Me.gb_programacion.Controls.Add(Me.cb_dia_semana)
        Me.gb_programacion.Controls.Add(Me.cb_periodicidad)
        Me.gb_programacion.Controls.Add(Me.tb_periodo)
        Me.gb_programacion.Controls.Add(Me.Label2)
        Me.gb_programacion.Location = New System.Drawing.Point(297, 3)
        Me.gb_programacion.Name = "gb_programacion"
        Me.gb_programacion.Size = New System.Drawing.Size(268, 122)
        Me.gb_programacion.TabIndex = 15
        Me.gb_programacion.TabStop = False
        Me.gb_programacion.Text = "Programacion de obra"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(146, 100)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 13)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "dia:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 71)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "Dia de la semana:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Periodicidad:"
        '
        'dtp_hora
        '
        Me.dtp_hora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_hora.Location = New System.Drawing.Point(44, 94)
        Me.dtp_hora.Name = "dtp_hora"
        Me.dtp_hora.ShowUpDown = True
        Me.dtp_hora.Size = New System.Drawing.Size(96, 20)
        Me.dtp_hora.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Hora:"
        '
        'cb_dia
        '
        Me.cb_dia.Enabled = False
        Me.cb_dia.FormattingEnabled = True
        Me.cb_dia.Location = New System.Drawing.Point(176, 93)
        Me.cb_dia.Name = "cb_dia"
        Me.cb_dia.Size = New System.Drawing.Size(84, 21)
        Me.cb_dia.TabIndex = 40
        '
        'cb_dia_semana
        '
        Me.cb_dia_semana.Enabled = False
        Me.cb_dia_semana.FormattingEnabled = True
        Me.cb_dia_semana.Location = New System.Drawing.Point(104, 67)
        Me.cb_dia_semana.Name = "cb_dia_semana"
        Me.cb_dia_semana.Size = New System.Drawing.Size(156, 21)
        Me.cb_dia_semana.TabIndex = 40
        '
        'cb_periodicidad
        '
        Me.cb_periodicidad.FormattingEnabled = True
        Me.cb_periodicidad.Location = New System.Drawing.Point(104, 41)
        Me.cb_periodicidad.Name = "cb_periodicidad"
        Me.cb_periodicidad.Size = New System.Drawing.Size(156, 21)
        Me.cb_periodicidad.TabIndex = 40
        '
        'tb_periodo
        '
        Me.tb_periodo.Location = New System.Drawing.Point(104, 16)
        Me.tb_periodo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tb_periodo.Name = "tb_periodo"
        Me.tb_periodo.Size = New System.Drawing.Size(66, 20)
        Me.tb_periodo.TabIndex = 39
        Me.tb_periodo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cada:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tb_nombre_prog)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.tb_empleado)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tb_puesto)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.tb_numero_programacion)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 122)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Programación de pedido"
        '
        'tb_nombre_prog
        '
        Me.tb_nombre_prog.Location = New System.Drawing.Point(69, 16)
        Me.tb_nombre_prog.Name = "tb_nombre_prog"
        Me.tb_nombre_prog.Size = New System.Drawing.Size(213, 20)
        Me.tb_nombre_prog.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 44
        Me.Label19.Text = "Nombre:"
        '
        'tb_empleado
        '
        Me.tb_empleado.Location = New System.Drawing.Point(69, 67)
        Me.tb_empleado.Name = "tb_empleado"
        Me.tb_empleado.ReadOnly = True
        Me.tb_empleado.Size = New System.Drawing.Size(213, 20)
        Me.tb_empleado.TabIndex = 14
        Me.tb_empleado.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Puesto:"
        '
        'tb_puesto
        '
        Me.tb_puesto.Location = New System.Drawing.Point(69, 93)
        Me.tb_puesto.Name = "tb_puesto"
        Me.tb_puesto.ReadOnly = True
        Me.tb_puesto.Size = New System.Drawing.Size(213, 20)
        Me.tb_puesto.TabIndex = 1
        Me.tb_puesto.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Empleado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Número:"
        '
        'tb_numero_programacion
        '
        Me.tb_numero_programacion.Location = New System.Drawing.Point(69, 42)
        Me.tb_numero_programacion.Name = "tb_numero_programacion"
        Me.tb_numero_programacion.ReadOnly = True
        Me.tb_numero_programacion.Size = New System.Drawing.Size(213, 20)
        Me.tb_numero_programacion.TabIndex = 3
        Me.tb_numero_programacion.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.pb_url)
        Me.GroupBox2.Controls.Add(Me.cb_telefono)
        Me.GroupBox2.Controls.Add(Me.cb_cliente)
        Me.GroupBox2.Controls.Add(Me.tb_email)
        Me.GroupBox2.Controls.Add(Me.tb_domicilio)
        Me.GroupBox2.Controls.Add(Me.lb_email)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(571, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 122)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'pb_url
        '
        Me.pb_url.BackgroundImage = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.pb_url.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_url.Location = New System.Drawing.Point(44, 67)
        Me.pb_url.Name = "pb_url"
        Me.pb_url.Size = New System.Drawing.Size(20, 20)
        Me.pb_url.TabIndex = 15
        Me.pb_url.TabStop = False
        '
        'cb_telefono
        '
        Me.cb_telefono.FormattingEnabled = True
        Me.cb_telefono.Location = New System.Drawing.Point(70, 93)
        Me.cb_telefono.Name = "cb_telefono"
        Me.cb_telefono.Size = New System.Drawing.Size(221, 21)
        Me.cb_telefono.TabIndex = 30
        '
        'cb_cliente
        '
        Me.cb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(70, 16)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(221, 21)
        Me.cb_cliente.TabIndex = 25
        '
        'tb_email
        '
        Me.tb_email.Location = New System.Drawing.Point(70, 67)
        Me.tb_email.Name = "tb_email"
        Me.tb_email.ReadOnly = True
        Me.tb_email.Size = New System.Drawing.Size(221, 20)
        Me.tb_email.TabIndex = 1
        Me.tb_email.TabStop = False
        '
        'tb_domicilio
        '
        Me.tb_domicilio.Location = New System.Drawing.Point(70, 41)
        Me.tb_domicilio.Name = "tb_domicilio"
        Me.tb_domicilio.ReadOnly = True
        Me.tb_domicilio.Size = New System.Drawing.Size(221, 20)
        Me.tb_domicilio.TabIndex = 1
        Me.tb_domicilio.TabStop = False
        '
        'lb_email
        '
        Me.lb_email.AutoSize = True
        Me.lb_email.Location = New System.Drawing.Point(9, 71)
        Me.lb_email.Name = "lb_email"
        Me.lb_email.Size = New System.Drawing.Size(35, 13)
        Me.lb_email.TabIndex = 0
        Me.lb_email.Text = "Email:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Domicilio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Telefono:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nombre:"
        '
        'gp_agregar
        '
        Me.gp_agregar.Controls.Add(Me.btn_bucar)
        Me.gp_agregar.Controls.Add(Me.btn_agregar)
        Me.gp_agregar.Controls.Add(Me.tb_codigo)
        Me.gp_agregar.Controls.Add(Me.Label12)
        Me.gp_agregar.Location = New System.Drawing.Point(3, 125)
        Me.gp_agregar.Name = "gp_agregar"
        Me.gp_agregar.Size = New System.Drawing.Size(352, 50)
        Me.gp_agregar.TabIndex = 14
        Me.gp_agregar.TabStop = False
        Me.gp_agregar.Text = "Producto"
        '
        'btn_bucar
        '
        Me.btn_bucar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_bucar.Image = CType(resources.GetObject("btn_bucar.Image"), System.Drawing.Image)
        Me.btn_bucar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bucar.Location = New System.Drawing.Point(266, 16)
        Me.btn_bucar.Name = "btn_bucar"
        Me.btn_bucar.Size = New System.Drawing.Size(75, 25)
        Me.btn_bucar.TabIndex = 20
        Me.btn_bucar.Text = "      Buscar"
        Me.btn_bucar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Location = New System.Drawing.Point(185, 16)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(75, 25)
        Me.btn_agregar.TabIndex = 15
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'tb_codigo
        '
        Me.tb_codigo.Location = New System.Drawing.Point(76, 19)
        Me.tb_codigo.MaxLength = 15
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(103, 20)
        Me.tb_codigo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Código:"
        '
        'frm_pedido_programacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 561)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.menu_principal)
        Me.MinimumSize = New System.Drawing.Size(900, 500)
        Me.Name = "frm_pedido_programacion"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Programación de Pedido"
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dg_cotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.panel_precio.ResumeLayout(False)
        Me.panel_precio_especial.ResumeLayout(False)
        Me.panel_precio_especial.PerformLayout()
        Me.panel_lista_precio.ResumeLayout(False)
        Me.panel_lista_precio.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.gb_programacion.ResumeLayout(False)
        Me.gb_programacion.PerformLayout()
        CType(Me.tb_periodo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_url, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gp_agregar.ResumeLayout(False)
        Me.gp_agregar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menu_principal As System.Windows.Forms.ToolStrip
    Friend WithEvents m_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_abrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dg_cotizacion As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_otros_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents tb_iva As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents panel_precio As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents panel_lista_precio As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents panel_precio_especial As System.Windows.Forms.Panel
    Friend WithEvents tb_precio_especial As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cb_precio As System.Windows.Forms.ListBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_empleado As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_puesto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_numero_programacion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pb_url As System.Windows.Forms.PictureBox
    Friend WithEvents cb_telefono As System.Windows.Forms.ComboBox
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents tb_email As System.Windows.Forms.TextBox
    Friend WithEvents tb_domicilio As System.Windows.Forms.TextBox
    Friend WithEvents lb_email As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gp_agregar As System.Windows.Forms.GroupBox
    Friend WithEvents btn_bucar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gb_programacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_periodicidad As System.Windows.Forms.ComboBox
    Friend WithEvents tb_periodo As System.Windows.Forms.NumericUpDown
    Friend WithEvents dtp_hora As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_proximo_programar As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cb_dia_semana As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cb_dia As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_fecha2 As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha1 As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre_prog As System.Windows.Forms.TextBox
End Class
