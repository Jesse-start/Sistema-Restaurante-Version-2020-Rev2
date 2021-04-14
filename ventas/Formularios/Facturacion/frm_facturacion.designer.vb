<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_facturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_facturacion))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_empleado = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tb_puesto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_numero_factura = New System.Windows.Forms.TextBox()
        Me.dg_factura = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
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
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo_cliente = New System.Windows.Forms.Button()
        Me.tb_cp = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pb_url = New System.Windows.Forms.PictureBox()
        Me.cb_telefono = New System.Windows.Forms.ComboBox()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.tb_email = New System.Windows.Forms.TextBox()
        Me.tb_ciudad = New System.Windows.Forms.TextBox()
        Me.tb_domicilio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lb_email = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_generalizar = New System.Windows.Forms.TextBox()
        Me.chb_generalizar = New System.Windows.Forms.CheckBox()
        Me.gb_tickets = New System.Windows.Forms.GroupBox()
        Me.tb_ticket_alone = New System.Windows.Forms.TextBox()
        Me.rb_ticket_alone = New System.Windows.Forms.RadioButton()
        Me.rb_cotizacion = New System.Windows.Forms.RadioButton()
        Me.btn_agregar_doc = New System.Windows.Forms.Button()
        Me.btn_abrir_cotizacion = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rb_ticket = New System.Windows.Forms.RadioButton()
        Me.rb_pedido = New System.Windows.Forms.RadioButton()
        Me.cb_ticket_termino = New System.Windows.Forms.ComboBox()
        Me.cb_ticket_inicio = New System.Windows.Forms.ComboBox()
        Me.cb_pedidos = New System.Windows.Forms.ComboBox()
        Me.gp_agregar = New System.Windows.Forms.GroupBox()
        Me.chb_codigo = New System.Windows.Forms.CheckBox()
        Me.btn_bucar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_principal = New System.Windows.Forms.ToolStrip()
        Me.m_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.m_abrir = New System.Windows.Forms.ToolStripButton()
        Me.m_guardar = New System.Windows.Forms.ToolStripButton()
        Me.m_exportar = New System.Windows.Forms.ToolStripButton()
        Me.tsb_imprimir = New System.Windows.Forms.ToolStripButton()
        Me.btn_generar_factura = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar_factura = New System.Windows.Forms.ToolStripButton()
        Me.btn_generar_xml = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_factura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pb_url, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_tickets.SuspendLayout()
        Me.gp_agregar.SuspendLayout()
        Me.menu_principal.SuspendLayout()
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
        Me.GroupBox3.Controls.Add(Me.tb_numero_factura)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 116)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Recibo de prefactura"
        '
        'tb_empleado
        '
        Me.tb_empleado.Location = New System.Drawing.Point(99, 51)
        Me.tb_empleado.Name = "tb_empleado"
        Me.tb_empleado.ReadOnly = True
        Me.tb_empleado.Size = New System.Drawing.Size(296, 24)
        Me.tb_empleado.TabIndex = 14
        Me.tb_empleado.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 18)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Puesto:"
        '
        'tb_puesto
        '
        Me.tb_puesto.Location = New System.Drawing.Point(99, 81)
        Me.tb_puesto.Name = "tb_puesto"
        Me.tb_puesto.ReadOnly = True
        Me.tb_puesto.Size = New System.Drawing.Size(296, 24)
        Me.tb_puesto.TabIndex = 1
        Me.tb_puesto.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 18)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Empleado:"
        '
        'tb_fecha
        '
        Me.tb_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tb_fecha.Location = New System.Drawing.Point(261, 16)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(134, 24)
        Me.tb_fecha.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(196, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Número:"
        '
        'tb_numero_factura
        '
        Me.tb_numero_factura.Location = New System.Drawing.Point(99, 19)
        Me.tb_numero_factura.Name = "tb_numero_factura"
        Me.tb_numero_factura.ReadOnly = True
        Me.tb_numero_factura.Size = New System.Drawing.Size(90, 24)
        Me.tb_numero_factura.TabIndex = 3
        Me.tb_numero_factura.TabStop = False
        '
        'dg_factura
        '
        Me.dg_factura.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dg_factura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_factura.Location = New System.Drawing.Point(0, 274)
        Me.dg_factura.Name = "dg_factura"
        Me.dg_factura.Size = New System.Drawing.Size(773, 331)
        Me.dg_factura.TabIndex = 30
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dg_factura)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1018, 605)
        Me.Panel1.TabIndex = 14
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(773, 274)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(245, 331)
        Me.Panel7.TabIndex = 27
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 6)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(229, 205)
        Me.FlowLayoutPanel1.TabIndex = 25
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tb_total)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 152)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(212, 50)
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
        Me.tb_total.Size = New System.Drawing.Size(145, 24)
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
        Me.GroupBox1.Size = New System.Drawing.Size(212, 82)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impuestos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 18)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Otros:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "I.V.A.:"
        '
        'tb_otros_impuestos
        '
        Me.tb_otros_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_otros_impuestos.Location = New System.Drawing.Point(64, 49)
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
        Me.tb_iva.Location = New System.Drawing.Point(64, 19)
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
        Me.GroupBox4.Size = New System.Drawing.Size(212, 48)
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
        Me.tb_subtotal.Size = New System.Drawing.Size(142, 24)
        Me.tb_subtotal.TabIndex = 0
        Me.tb_subtotal.TabStop = False
        Me.tb_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.GroupBox2)
        Me.Panel6.Controls.Add(Me.tb_generalizar)
        Me.Panel6.Controls.Add(Me.chb_generalizar)
        Me.Panel6.Controls.Add(Me.gb_tickets)
        Me.Panel6.Controls.Add(Me.GroupBox3)
        Me.Panel6.Controls.Add(Me.gp_agregar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1018, 274)
        Me.Panel6.TabIndex = 23
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_nuevo_cliente)
        Me.GroupBox2.Controls.Add(Me.tb_cp)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.pb_url)
        Me.GroupBox2.Controls.Add(Me.cb_telefono)
        Me.GroupBox2.Controls.Add(Me.cb_cliente)
        Me.GroupBox2.Controls.Add(Me.tb_email)
        Me.GroupBox2.Controls.Add(Me.tb_ciudad)
        Me.GroupBox2.Controls.Add(Me.tb_domicilio)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lb_email)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(410, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(622, 140)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'btn_nuevo_cliente
        '
        Me.btn_nuevo_cliente.Location = New System.Drawing.Point(87, 107)
        Me.btn_nuevo_cliente.Name = "btn_nuevo_cliente"
        Me.btn_nuevo_cliente.Size = New System.Drawing.Size(154, 29)
        Me.btn_nuevo_cliente.TabIndex = 35
        Me.btn_nuevo_cliente.Text = "Nuevo Cliente"
        Me.btn_nuevo_cliente.UseVisualStyleBackColor = True
        Me.btn_nuevo_cliente.Visible = False
        '
        'tb_cp
        '
        Me.tb_cp.Enabled = False
        Me.tb_cp.Location = New System.Drawing.Point(450, 75)
        Me.tb_cp.Name = "tb_cp"
        Me.tb_cp.Size = New System.Drawing.Size(136, 24)
        Me.tb_cp.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(375, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 18)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "C.P."
        '
        'pb_url
        '
        Me.pb_url.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_url.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.pb_url.Location = New System.Drawing.Point(424, 18)
        Me.pb_url.Name = "pb_url"
        Me.pb_url.Size = New System.Drawing.Size(20, 20)
        Me.pb_url.TabIndex = 15
        Me.pb_url.TabStop = False
        '
        'cb_telefono
        '
        Me.cb_telefono.FormattingEnabled = True
        Me.cb_telefono.Location = New System.Drawing.Point(450, 43)
        Me.cb_telefono.Name = "cb_telefono"
        Me.cb_telefono.Size = New System.Drawing.Size(136, 26)
        Me.cb_telefono.TabIndex = 30
        '
        'cb_cliente
        '
        Me.cb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(89, 14)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(271, 26)
        Me.cb_cliente.TabIndex = 25
        '
        'tb_email
        '
        Me.tb_email.Location = New System.Drawing.Point(450, 12)
        Me.tb_email.Name = "tb_email"
        Me.tb_email.ReadOnly = True
        Me.tb_email.Size = New System.Drawing.Size(136, 24)
        Me.tb_email.TabIndex = 1
        Me.tb_email.TabStop = False
        '
        'tb_ciudad
        '
        Me.tb_ciudad.Location = New System.Drawing.Point(89, 75)
        Me.tb_ciudad.Name = "tb_ciudad"
        Me.tb_ciudad.ReadOnly = True
        Me.tb_ciudad.Size = New System.Drawing.Size(271, 24)
        Me.tb_ciudad.TabIndex = 1
        Me.tb_ciudad.TabStop = False
        '
        'tb_domicilio
        '
        Me.tb_domicilio.Location = New System.Drawing.Point(89, 45)
        Me.tb_domicilio.Name = "tb_domicilio"
        Me.tb_domicilio.ReadOnly = True
        Me.tb_domicilio.Size = New System.Drawing.Size(271, 24)
        Me.tb_domicilio.TabIndex = 1
        Me.tb_domicilio.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Ciudad:"
        '
        'lb_email
        '
        Me.lb_email.AutoSize = True
        Me.lb_email.Location = New System.Drawing.Point(368, 16)
        Me.lb_email.Name = "lb_email"
        Me.lb_email.Size = New System.Drawing.Size(49, 18)
        Me.lb_email.TabIndex = 0
        Me.lb_email.Text = "Email:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Domicilio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(369, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Telefono:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nombre:"
        '
        'tb_generalizar
        '
        Me.tb_generalizar.Enabled = False
        Me.tb_generalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_generalizar.Location = New System.Drawing.Point(662, 232)
        Me.tb_generalizar.Name = "tb_generalizar"
        Me.tb_generalizar.Size = New System.Drawing.Size(355, 24)
        Me.tb_generalizar.TabIndex = 18
        '
        'chb_generalizar
        '
        Me.chb_generalizar.AutoSize = True
        Me.chb_generalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_generalizar.Location = New System.Drawing.Point(499, 232)
        Me.chb_generalizar.Name = "chb_generalizar"
        Me.chb_generalizar.Size = New System.Drawing.Size(150, 22)
        Me.chb_generalizar.TabIndex = 17
        Me.chb_generalizar.Text = "Facturar todo por :"
        Me.chb_generalizar.UseVisualStyleBackColor = True
        '
        'gb_tickets
        '
        Me.gb_tickets.Controls.Add(Me.tb_ticket_alone)
        Me.gb_tickets.Controls.Add(Me.rb_ticket_alone)
        Me.gb_tickets.Controls.Add(Me.rb_cotizacion)
        Me.gb_tickets.Controls.Add(Me.btn_agregar_doc)
        Me.gb_tickets.Controls.Add(Me.btn_abrir_cotizacion)
        Me.gb_tickets.Controls.Add(Me.Label3)
        Me.gb_tickets.Controls.Add(Me.Label2)
        Me.gb_tickets.Controls.Add(Me.rb_ticket)
        Me.gb_tickets.Controls.Add(Me.rb_pedido)
        Me.gb_tickets.Controls.Add(Me.cb_ticket_termino)
        Me.gb_tickets.Controls.Add(Me.cb_ticket_inicio)
        Me.gb_tickets.Controls.Add(Me.cb_pedidos)
        Me.gb_tickets.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_tickets.Location = New System.Drawing.Point(3, 138)
        Me.gb_tickets.Name = "gb_tickets"
        Me.gb_tickets.Size = New System.Drawing.Size(488, 143)
        Me.gb_tickets.TabIndex = 16
        Me.gb_tickets.TabStop = False
        Me.gb_tickets.Text = "Facturacio de tickets y pedidos"
        '
        'tb_ticket_alone
        '
        Me.tb_ticket_alone.Location = New System.Drawing.Point(299, 100)
        Me.tb_ticket_alone.Name = "tb_ticket_alone"
        Me.tb_ticket_alone.Size = New System.Drawing.Size(73, 24)
        Me.tb_ticket_alone.TabIndex = 18
        '
        'rb_ticket_alone
        '
        Me.rb_ticket_alone.AutoSize = True
        Me.rb_ticket_alone.Checked = True
        Me.rb_ticket_alone.Location = New System.Drawing.Point(225, 102)
        Me.rb_ticket_alone.Name = "rb_ticket_alone"
        Me.rb_ticket_alone.Size = New System.Drawing.Size(61, 22)
        Me.rb_ticket_alone.TabIndex = 17
        Me.rb_ticket_alone.TabStop = True
        Me.rb_ticket_alone.Text = "ticket"
        Me.rb_ticket_alone.UseVisualStyleBackColor = True
        '
        'rb_cotizacion
        '
        Me.rb_cotizacion.AutoSize = True
        Me.rb_cotizacion.Location = New System.Drawing.Point(13, 100)
        Me.rb_cotizacion.Name = "rb_cotizacion"
        Me.rb_cotizacion.Size = New System.Drawing.Size(97, 22)
        Me.rb_cotizacion.TabIndex = 16
        Me.rb_cotizacion.Text = "Cotizacion"
        Me.rb_cotizacion.UseVisualStyleBackColor = True
        '
        'btn_agregar_doc
        '
        Me.btn_agregar_doc.Location = New System.Drawing.Point(378, 94)
        Me.btn_agregar_doc.Name = "btn_agregar_doc"
        Me.btn_agregar_doc.Size = New System.Drawing.Size(83, 36)
        Me.btn_agregar_doc.TabIndex = 3
        Me.btn_agregar_doc.Text = "Agregar"
        Me.btn_agregar_doc.UseVisualStyleBackColor = True
        '
        'btn_abrir_cotizacion
        '
        Me.btn_abrir_cotizacion.Enabled = False
        Me.btn_abrir_cotizacion.Location = New System.Drawing.Point(124, 94)
        Me.btn_abrir_cotizacion.Name = "btn_abrir_cotizacion"
        Me.btn_abrir_cotizacion.Size = New System.Drawing.Size(95, 36)
        Me.btn_abrir_cotizacion.TabIndex = 15
        Me.btn_abrir_cotizacion.Text = "cotización"
        Me.btn_abrir_cotizacion.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(284, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Al:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Del:"
        '
        'rb_ticket
        '
        Me.rb_ticket.AutoSize = True
        Me.rb_ticket.Location = New System.Drawing.Point(13, 64)
        Me.rb_ticket.Name = "rb_ticket"
        Me.rb_ticket.Size = New System.Drawing.Size(69, 22)
        Me.rb_ticket.TabIndex = 1
        Me.rb_ticket.Text = "tickets"
        Me.rb_ticket.UseVisualStyleBackColor = True
        '
        'rb_pedido
        '
        Me.rb_pedido.AutoSize = True
        Me.rb_pedido.Location = New System.Drawing.Point(13, 34)
        Me.rb_pedido.Name = "rb_pedido"
        Me.rb_pedido.Size = New System.Drawing.Size(72, 22)
        Me.rb_pedido.TabIndex = 1
        Me.rb_pedido.Text = "Pedido"
        Me.rb_pedido.UseVisualStyleBackColor = True
        '
        'cb_ticket_termino
        '
        Me.cb_ticket_termino.Enabled = False
        Me.cb_ticket_termino.FormattingEnabled = True
        Me.cb_ticket_termino.Location = New System.Drawing.Point(317, 59)
        Me.cb_ticket_termino.Name = "cb_ticket_termino"
        Me.cb_ticket_termino.Size = New System.Drawing.Size(144, 26)
        Me.cb_ticket_termino.TabIndex = 0
        '
        'cb_ticket_inicio
        '
        Me.cb_ticket_inicio.Enabled = False
        Me.cb_ticket_inicio.FormattingEnabled = True
        Me.cb_ticket_inicio.Location = New System.Drawing.Point(142, 60)
        Me.cb_ticket_inicio.Name = "cb_ticket_inicio"
        Me.cb_ticket_inicio.Size = New System.Drawing.Size(131, 26)
        Me.cb_ticket_inicio.TabIndex = 0
        '
        'cb_pedidos
        '
        Me.cb_pedidos.Enabled = False
        Me.cb_pedidos.FormattingEnabled = True
        Me.cb_pedidos.Location = New System.Drawing.Point(115, 28)
        Me.cb_pedidos.Name = "cb_pedidos"
        Me.cb_pedidos.Size = New System.Drawing.Size(346, 26)
        Me.cb_pedidos.TabIndex = 0
        '
        'gp_agregar
        '
        Me.gp_agregar.Controls.Add(Me.chb_codigo)
        Me.gp_agregar.Controls.Add(Me.btn_bucar)
        Me.gp_agregar.Controls.Add(Me.btn_agregar)
        Me.gp_agregar.Controls.Add(Me.tb_codigo)
        Me.gp_agregar.Controls.Add(Me.Label12)
        Me.gp_agregar.Enabled = False
        Me.gp_agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gp_agregar.Location = New System.Drawing.Point(494, 172)
        Me.gp_agregar.Name = "gp_agregar"
        Me.gp_agregar.Size = New System.Drawing.Size(532, 62)
        Me.gp_agregar.TabIndex = 14
        Me.gp_agregar.TabStop = False
        Me.gp_agregar.Text = "    Producto"
        '
        'chb_codigo
        '
        Me.chb_codigo.AutoSize = True
        Me.chb_codigo.Enabled = False
        Me.chb_codigo.Location = New System.Drawing.Point(6, 29)
        Me.chb_codigo.Name = "chb_codigo"
        Me.chb_codigo.Size = New System.Drawing.Size(15, 14)
        Me.chb_codigo.TabIndex = 21
        Me.chb_codigo.UseVisualStyleBackColor = True
        '
        'btn_bucar
        '
        Me.btn_bucar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_bucar.Enabled = False
        Me.btn_bucar.Image = CType(resources.GetObject("btn_bucar.Image"), System.Drawing.Image)
        Me.btn_bucar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bucar.Location = New System.Drawing.Point(396, 21)
        Me.btn_bucar.Name = "btn_bucar"
        Me.btn_bucar.Size = New System.Drawing.Size(106, 33)
        Me.btn_bucar.TabIndex = 20
        Me.btn_bucar.Text = "      Buscar"
        Me.btn_bucar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Enabled = False
        Me.btn_agregar.Location = New System.Drawing.Point(300, 19)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(90, 34)
        Me.btn_agregar.TabIndex = 15
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'tb_codigo
        '
        Me.tb_codigo.Enabled = False
        Me.tb_codigo.Location = New System.Drawing.Point(99, 24)
        Me.tb_codigo.MaxLength = 15
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(195, 24)
        Me.tb_codigo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(25, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 18)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Código:"
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 35)
        '
        'menu_principal
        '
        Me.menu_principal.BackColor = System.Drawing.SystemColors.Control
        Me.menu_principal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.menu_principal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_nuevo, Me.m_abrir, Me.m_guardar, Me.toolStripSeparator, Me.m_exportar, Me.tsb_imprimir, Me.btn_generar_factura, Me.btn_eliminar_factura, Me.btn_generar_xml})
        Me.menu_principal.Location = New System.Drawing.Point(5, 0)
        Me.menu_principal.MinimumSize = New System.Drawing.Size(0, 35)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(1018, 35)
        Me.menu_principal.TabIndex = 12
        Me.menu_principal.Text = "ToolStrip1"
        '
        'm_nuevo
        '
        Me.m_nuevo.AutoToolTip = False
        Me.m_nuevo.Image = CType(resources.GetObject("m_nuevo.Image"), System.Drawing.Image)
        Me.m_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_nuevo.Name = "m_nuevo"
        Me.m_nuevo.Size = New System.Drawing.Size(79, 32)
        Me.m_nuevo.Text = "&Nuevo"
        '
        'm_abrir
        '
        Me.m_abrir.AutoToolTip = False
        Me.m_abrir.Image = CType(resources.GetObject("m_abrir.Image"), System.Drawing.Image)
        Me.m_abrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_abrir.Name = "m_abrir"
        Me.m_abrir.Size = New System.Drawing.Size(67, 32)
        Me.m_abrir.Text = "&Abrir"
        '
        'm_guardar
        '
        Me.m_guardar.AutoToolTip = False
        Me.m_guardar.Image = CType(resources.GetObject("m_guardar.Image"), System.Drawing.Image)
        Me.m_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_guardar.Name = "m_guardar"
        Me.m_guardar.Size = New System.Drawing.Size(95, 32)
        Me.m_guardar.Text = "&Guardar"
        '
        'm_exportar
        '
        Me.m_exportar.AutoToolTip = False
        Me.m_exportar.Image = CType(resources.GetObject("m_exportar.Image"), System.Drawing.Image)
        Me.m_exportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.m_exportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_exportar.Name = "m_exportar"
        Me.m_exportar.Size = New System.Drawing.Size(97, 32)
        Me.m_exportar.Text = "&Exportar"
        Me.m_exportar.Visible = False
        '
        'tsb_imprimir
        '
        Me.tsb_imprimir.Image = CType(resources.GetObject("tsb_imprimir.Image"), System.Drawing.Image)
        Me.tsb_imprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsb_imprimir.Name = "tsb_imprimir"
        Me.tsb_imprimir.Size = New System.Drawing.Size(93, 32)
        Me.tsb_imprimir.Text = "Imprimir"
        Me.tsb_imprimir.Visible = False
        '
        'btn_generar_factura
        '
        Me.btn_generar_factura.Image = CType(resources.GetObject("btn_generar_factura.Image"), System.Drawing.Image)
        Me.btn_generar_factura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_generar_factura.Name = "btn_generar_factura"
        Me.btn_generar_factura.Size = New System.Drawing.Size(227, 32)
        Me.btn_generar_factura.Text = "Generar Factura en PDF"
        Me.btn_generar_factura.ToolTipText = "Generar PDF"
        Me.btn_generar_factura.Visible = False
        '
        'btn_eliminar_factura
        '
        Me.btn_eliminar_factura.Image = CType(resources.GetObject("btn_eliminar_factura.Image"), System.Drawing.Image)
        Me.btn_eliminar_factura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar_factura.Name = "btn_eliminar_factura"
        Me.btn_eliminar_factura.Size = New System.Drawing.Size(160, 32)
        Me.btn_eliminar_factura.Text = "Eliminar Factura"
        '
        'btn_generar_xml
        '
        Me.btn_generar_xml.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_generar_xml.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_generar_xml.Name = "btn_generar_xml"
        Me.btn_generar_xml.Size = New System.Drawing.Size(136, 32)
        Me.btn_generar_xml.Text = "Generar XML"
        Me.btn_generar_xml.ToolTipText = "Generar XML"
        '
        'frm_facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 645)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.menu_principal)
        Me.MinimumSize = New System.Drawing.Size(900, 509)
        Me.Name = "frm_facturacion"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prefacturación"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_factura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pb_url, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_tickets.ResumeLayout(False)
        Me.gb_tickets.PerformLayout()
        Me.gp_agregar.ResumeLayout(False)
        Me.gp_agregar.PerformLayout()
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_numero_factura As System.Windows.Forms.TextBox
    Friend WithEvents dg_factura As System.Windows.Forms.DataGridView
    Friend WithEvents tb_empleado As System.Windows.Forms.TextBox
    Friend WithEvents tb_puesto As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gp_agregar As System.Windows.Forms.GroupBox
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_bucar As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents gb_tickets As System.Windows.Forms.GroupBox
    Friend WithEvents rb_pedido As System.Windows.Forms.RadioButton
    Friend WithEvents cb_pedidos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rb_ticket As System.Windows.Forms.RadioButton
    Friend WithEvents cb_ticket_termino As System.Windows.Forms.ComboBox
    Friend WithEvents cb_ticket_inicio As System.Windows.Forms.ComboBox
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
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents tb_ticket_alone As System.Windows.Forms.TextBox
    Friend WithEvents rb_ticket_alone As System.Windows.Forms.RadioButton
    Friend WithEvents rb_cotizacion As System.Windows.Forms.RadioButton
    Friend WithEvents btn_agregar_doc As System.Windows.Forms.Button
    Friend WithEvents btn_abrir_cotizacion As System.Windows.Forms.Button
    Friend WithEvents chb_codigo As System.Windows.Forms.CheckBox
    Friend WithEvents tb_generalizar As System.Windows.Forms.TextBox
    Friend WithEvents chb_generalizar As System.Windows.Forms.CheckBox
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents m_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_abrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents m_exportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsb_imprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents menu_principal As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_generar_factura As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_cp As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pb_url As System.Windows.Forms.PictureBox
    Friend WithEvents cb_telefono As System.Windows.Forms.ComboBox
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents tb_email As System.Windows.Forms.TextBox
    Friend WithEvents tb_ciudad As System.Windows.Forms.TextBox
    Friend WithEvents tb_domicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lb_email As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_nuevo_cliente As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_factura As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_generar_xml As System.Windows.Forms.ToolStripButton
End Class
