<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cotizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cotizacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_empleado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tb_puesto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_numero_cotizacion = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_tipo_precio = New System.Windows.Forms.ComboBox()
        Me.pb_url = New System.Windows.Forms.PictureBox()
        Me.cb_telefono = New System.Windows.Forms.ComboBox()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.tb_email = New System.Windows.Forms.TextBox()
        Me.tb_domicilio = New System.Windows.Forms.TextBox()
        Me.lb_email = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_otros_impuestos = New System.Windows.Forms.TextBox()
        Me.tb_iva = New System.Windows.Forms.TextBox()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.menu_principal = New System.Windows.Forms.ToolStrip()
        Me.m_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.m_abrir = New System.Windows.Forms.ToolStripButton()
        Me.m_guardar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.m_exportar = New System.Windows.Forms.ToolStripButton()
        Me.btn_generar_cotizacion_pdf = New System.Windows.Forms.ToolStripButton()
        Me.dg_cotizacion = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.tb_despedida = New System.Windows.Forms.TextBox()
        Me.tb_mensaje = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gp_agregar = New System.Windows.Forms.GroupBox()
        Me.btn_bucar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_url, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.menu_principal.SuspendLayout()
        CType(Me.dg_cotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gp_agregar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tb_empleado)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tb_puesto)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.tb_fecha)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.tb_numero_cotizacion)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(358, 100)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cotización"
        '
        'tb_empleado
        '
        Me.tb_empleado.Location = New System.Drawing.Point(76, 45)
        Me.tb_empleado.Name = "tb_empleado"
        Me.tb_empleado.ReadOnly = True
        Me.tb_empleado.Size = New System.Drawing.Size(276, 20)
        Me.tb_empleado.TabIndex = 14
        Me.tb_empleado.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Puesto:"
        '
        'tb_puesto
        '
        Me.tb_puesto.Location = New System.Drawing.Point(76, 71)
        Me.tb_puesto.Name = "tb_puesto"
        Me.tb_puesto.ReadOnly = True
        Me.tb_puesto.Size = New System.Drawing.Size(276, 20)
        Me.tb_puesto.TabIndex = 1
        Me.tb_puesto.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Empleado:"
        '
        'tb_fecha
        '
        Me.tb_fecha.CustomFormat = "dd-MM-yyyy"
        Me.tb_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tb_fecha.Location = New System.Drawing.Point(252, 15)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(100, 20)
        Me.tb_fecha.TabIndex = 5
        Me.tb_fecha.Value = New Date(2013, 8, 17, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(206, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Número:"
        '
        'tb_numero_cotizacion
        '
        Me.tb_numero_cotizacion.Location = New System.Drawing.Point(76, 16)
        Me.tb_numero_cotizacion.Name = "tb_numero_cotizacion"
        Me.tb_numero_cotizacion.ReadOnly = True
        Me.tb_numero_cotizacion.Size = New System.Drawing.Size(90, 20)
        Me.tb_numero_cotizacion.TabIndex = 3
        Me.tb_numero_cotizacion.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cb_tipo_precio)
        Me.GroupBox2.Controls.Add(Me.pb_url)
        Me.GroupBox2.Controls.Add(Me.cb_telefono)
        Me.GroupBox2.Controls.Add(Me.cb_cliente)
        Me.GroupBox2.Controls.Add(Me.tb_email)
        Me.GroupBox2.Controls.Add(Me.tb_domicilio)
        Me.GroupBox2.Controls.Add(Me.lb_email)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(367, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(473, 124)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Tipo de precio:"
        '
        'cb_tipo_precio
        '
        Me.cb_tipo_precio.FormattingEnabled = True
        Me.cb_tipo_precio.Location = New System.Drawing.Point(92, 97)
        Me.cb_tipo_precio.Name = "cb_tipo_precio"
        Me.cb_tipo_precio.Size = New System.Drawing.Size(121, 21)
        Me.cb_tipo_precio.TabIndex = 31
        '
        'pb_url
        '
        Me.pb_url.BackgroundImage = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.pb_url.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_url.Location = New System.Drawing.Point(66, 71)
        Me.pb_url.Name = "pb_url"
        Me.pb_url.Size = New System.Drawing.Size(20, 20)
        Me.pb_url.TabIndex = 15
        Me.pb_url.TabStop = False
        '
        'cb_telefono
        '
        Me.cb_telefono.FormattingEnabled = True
        Me.cb_telefono.Location = New System.Drawing.Point(323, 71)
        Me.cb_telefono.Name = "cb_telefono"
        Me.cb_telefono.Size = New System.Drawing.Size(142, 21)
        Me.cb_telefono.TabIndex = 30
        '
        'cb_cliente
        '
        Me.cb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(92, 16)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(373, 21)
        Me.cb_cliente.TabIndex = 25
        '
        'tb_email
        '
        Me.tb_email.Location = New System.Drawing.Point(92, 71)
        Me.tb_email.Name = "tb_email"
        Me.tb_email.ReadOnly = True
        Me.tb_email.Size = New System.Drawing.Size(159, 20)
        Me.tb_email.TabIndex = 1
        Me.tb_email.TabStop = False
        '
        'tb_domicilio
        '
        Me.tb_domicilio.Location = New System.Drawing.Point(92, 45)
        Me.tb_domicilio.Name = "tb_domicilio"
        Me.tb_domicilio.ReadOnly = True
        Me.tb_domicilio.Size = New System.Drawing.Size(373, 20)
        Me.tb_domicilio.TabIndex = 1
        Me.tb_domicilio.TabStop = False
        '
        'lb_email
        '
        Me.lb_email.AutoSize = True
        Me.lb_email.Location = New System.Drawing.Point(31, 74)
        Me.lb_email.Name = "lb_email"
        Me.lb_email.Size = New System.Drawing.Size(35, 13)
        Me.lb_email.TabIndex = 0
        Me.lb_email.Text = "Email:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(31, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Domicilio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Telefono:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nombre:"
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
        'menu_principal
        '
        Me.menu_principal.BackColor = System.Drawing.SystemColors.Control
        Me.menu_principal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_nuevo, Me.m_abrir, Me.m_guardar, Me.toolStripSeparator, Me.m_exportar, Me.btn_generar_cotizacion_pdf})
        Me.menu_principal.Location = New System.Drawing.Point(5, 0)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(882, 25)
        Me.menu_principal.TabIndex = 12
        Me.menu_principal.Text = "ToolStrip1"
        '
        'm_nuevo
        '
        Me.m_nuevo.AutoToolTip = False
        Me.m_nuevo.Image = CType(resources.GetObject("m_nuevo.Image"), System.Drawing.Image)
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
        Me.m_exportar.Visible = False
        '
        'btn_generar_cotizacion_pdf
        '
        Me.btn_generar_cotizacion_pdf.Image = CType(resources.GetObject("btn_generar_cotizacion_pdf.Image"), System.Drawing.Image)
        Me.btn_generar_cotizacion_pdf.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_generar_cotizacion_pdf.Name = "btn_generar_cotizacion_pdf"
        Me.btn_generar_cotizacion_pdf.Size = New System.Drawing.Size(89, 22)
        Me.btn_generar_cotizacion_pdf.Text = "Generar pdf"
        Me.btn_generar_cotizacion_pdf.Visible = False
        '
        'dg_cotizacion
        '
        Me.dg_cotizacion.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cotizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_cotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_cotizacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_cotizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_cotizacion.Location = New System.Drawing.Point(0, 227)
        Me.dg_cotizacion.Name = "dg_cotizacion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cotizacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg_cotizacion.Size = New System.Drawing.Size(678, 316)
        Me.dg_cotizacion.TabIndex = 30
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dg_cotizacion)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 543)
        Me.Panel1.TabIndex = 14
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(678, 227)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(204, 316)
        Me.Panel7.TabIndex = 27
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 6)
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
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.GroupBox6)
        Me.Panel6.Controls.Add(Me.GroupBox3)
        Me.Panel6.Controls.Add(Me.GroupBox2)
        Me.Panel6.Controls.Add(Me.gp_agregar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(882, 227)
        Me.Panel6.TabIndex = 23
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tb_despedida)
        Me.GroupBox6.Controls.Add(Me.tb_mensaje)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Location = New System.Drawing.Point(367, 134)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(473, 88)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Mensajes"
        '
        'tb_despedida
        '
        Me.tb_despedida.Location = New System.Drawing.Point(82, 50)
        Me.tb_despedida.Multiline = True
        Me.tb_despedida.Name = "tb_despedida"
        Me.tb_despedida.Size = New System.Drawing.Size(383, 31)
        Me.tb_despedida.TabIndex = 21
        '
        'tb_mensaje
        '
        Me.tb_mensaje.Location = New System.Drawing.Point(82, 13)
        Me.tb_mensaje.Multiline = True
        Me.tb_mensaje.Name = "tb_mensaje"
        Me.tb_mensaje.Size = New System.Drawing.Size(383, 32)
        Me.tb_mensaje.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Despedida:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Mensaje:"
        '
        'gp_agregar
        '
        Me.gp_agregar.Controls.Add(Me.btn_bucar)
        Me.gp_agregar.Controls.Add(Me.btn_agregar)
        Me.gp_agregar.Controls.Add(Me.tb_codigo)
        Me.gp_agregar.Controls.Add(Me.Label12)
        Me.gp_agregar.Location = New System.Drawing.Point(3, 109)
        Me.gp_agregar.Name = "gp_agregar"
        Me.gp_agregar.Size = New System.Drawing.Size(358, 54)
        Me.gp_agregar.TabIndex = 14
        Me.gp_agregar.TabStop = False
        Me.gp_agregar.Text = "Producto"
        '
        'btn_bucar
        '
        Me.btn_bucar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_bucar.Image = CType(resources.GetObject("btn_bucar.Image"), System.Drawing.Image)
        Me.btn_bucar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bucar.Location = New System.Drawing.Point(253, 19)
        Me.btn_bucar.Name = "btn_bucar"
        Me.btn_bucar.Size = New System.Drawing.Size(75, 25)
        Me.btn_bucar.TabIndex = 20
        Me.btn_bucar.Text = "      Buscar"
        Me.btn_bucar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Location = New System.Drawing.Point(172, 19)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(75, 25)
        Me.btn_agregar.TabIndex = 15
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'tb_codigo
        '
        Me.tb_codigo.Location = New System.Drawing.Point(97, 22)
        Me.tb_codigo.MaxLength = 15
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(69, 20)
        Me.tb_codigo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(45, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Código:"
        '
        'frm_cotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 573)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.menu_principal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "frm_cotizacion"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cotización"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_url, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        CType(Me.dg_cotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.gp_agregar.ResumeLayout(False)
        Me.gp_agregar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_numero_cotizacion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents tb_email As System.Windows.Forms.TextBox
    Friend WithEvents tb_domicilio As System.Windows.Forms.TextBox
    Friend WithEvents lb_email As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents tb_iva As System.Windows.Forms.TextBox
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents menu_principal As System.Windows.Forms.ToolStrip
    Friend WithEvents m_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_abrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dg_cotizacion As System.Windows.Forms.DataGridView
    Friend WithEvents cb_telefono As System.Windows.Forms.ComboBox
    Friend WithEvents tb_empleado As System.Windows.Forms.TextBox
    Friend WithEvents tb_puesto As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gp_agregar As System.Windows.Forms.GroupBox
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_bucar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tb_otros_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents pb_url As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btn_generar_cotizacion_pdf As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_despedida As System.Windows.Forms.TextBox
    Friend WithEvents tb_mensaje As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents m_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_tipo_precio As System.Windows.Forms.ComboBox
End Class
