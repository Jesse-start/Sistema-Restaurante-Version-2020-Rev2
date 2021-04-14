<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_facturacion_electronica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_facturacion_electronica))
        Me.dg_factura = New System.Windows.Forms.DataGridView()
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_impuestos = New System.Windows.Forms.TextBox()
        Me.tb_retenciones = New System.Windows.Forms.TextBox()
        Me.cb_pago_forma = New System.Windows.Forms.ComboBox()
        Me.cb_pago_metodo = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_pago_condiciones = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tb_pago_cuenta = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tb_ticket_alone = New System.Windows.Forms.TextBox()
        Me.rb_ticket_alone = New System.Windows.Forms.RadioButton()
        Me.btn_agregar_doc = New System.Windows.Forms.Button()
        Me.gp_agregar = New System.Windows.Forms.GroupBox()
        Me.chb_codigo = New System.Windows.Forms.CheckBox()
        Me.btn_bucar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.gb_listado = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_total_paginas = New System.Windows.Forms.Label()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.lbl_buscar = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cb_cliente_busqueda = New System.Windows.Forms.ComboBox()
        Me.lst_facturas = New System.Windows.Forms.ListView()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_timbrar = New System.Windows.Forms.Button()
        Me.btn_enviar = New System.Windows.Forms.Button()
        Me.btn_xml = New System.Windows.Forms.Button()
        Me.btn_pdf = New System.Windows.Forms.Button()
        Me.tb_numero_factura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_domicilio = New System.Windows.Forms.TextBox()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.btn_nuevo_cliente = New System.Windows.Forms.Button()
        Me.lbl_estatus_timbrado = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_aviso_cancelado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_empleado = New System.Windows.Forms.TextBox()
        Me.tb_fecha = New System.Windows.Forms.DateTimePicker()
        Me.gb_factura = New System.Windows.Forms.GroupBox()
        Me.tb_tipo_cambio = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.gb_relacion = New System.Windows.Forms.GroupBox()
        Me.lst_documentos = New System.Windows.Forms.ListView()
        Me.cb_folio_fiscal = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_eliminar_doc = New System.Windows.Forms.Button()
        Me.btn_agregar_folio = New System.Windows.Forms.Button()
        Me.cb_tipo_relacion = New System.Windows.Forms.ComboBox()
        Me.cb_moneda = New System.Windows.Forms.ComboBox()
        Me.cb_uso_cfdi = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dg_factura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gp_agregar.SuspendLayout()
        Me.gb_listado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gb_factura.SuspendLayout()
        Me.gb_relacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_factura
        '
        Me.dg_factura.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dg_factura.Location = New System.Drawing.Point(7, 321)
        Me.dg_factura.Name = "dg_factura"
        Me.dg_factura.Size = New System.Drawing.Size(695, 247)
        Me.dg_factura.TabIndex = 30
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(350, 30)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(35, 42)
        Me.QrCodeImgControl1.TabIndex = 26
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        Me.QrCodeImgControl1.Visible = False
        '
        'tb_total
        '
        Me.tb_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(595, 17)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(92, 24)
        Me.tb_total.TabIndex = 0
        Me.tb_total.TabStop = False
        Me.tb_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_total)
        Me.GroupBox1.Controls.Add(Me.tb_subtotal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_impuestos)
        Me.GroupBox1.Controls.Add(Me.tb_retenciones)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 573)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(693, 49)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'tb_subtotal
        '
        Me.tb_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_subtotal.Location = New System.Drawing.Point(64, 21)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.ReadOnly = True
        Me.tb_subtotal.Size = New System.Drawing.Size(92, 24)
        Me.tb_subtotal.TabIndex = 0
        Me.tb_subtotal.TabStop = False
        Me.tb_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Subtotal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(554, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Total:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(375, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "IVA Ret."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(167, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Impuestos:"
        '
        'tb_impuestos
        '
        Me.tb_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_impuestos.Location = New System.Drawing.Point(243, 21)
        Me.tb_impuestos.Name = "tb_impuestos"
        Me.tb_impuestos.ReadOnly = True
        Me.tb_impuestos.Size = New System.Drawing.Size(92, 24)
        Me.tb_impuestos.TabIndex = 0
        Me.tb_impuestos.TabStop = False
        Me.tb_impuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_retenciones
        '
        Me.tb_retenciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_retenciones.Location = New System.Drawing.Point(446, 21)
        Me.tb_retenciones.Name = "tb_retenciones"
        Me.tb_retenciones.ReadOnly = True
        Me.tb_retenciones.Size = New System.Drawing.Size(92, 24)
        Me.tb_retenciones.TabIndex = 0
        Me.tb_retenciones.TabStop = False
        Me.tb_retenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cb_pago_forma
        '
        Me.cb_pago_forma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_pago_forma.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pago_forma.FormattingEnabled = True
        Me.cb_pago_forma.Location = New System.Drawing.Point(482, 65)
        Me.cb_pago_forma.Name = "cb_pago_forma"
        Me.cb_pago_forma.Size = New System.Drawing.Size(220, 24)
        Me.cb_pago_forma.TabIndex = 40
        '
        'cb_pago_metodo
        '
        Me.cb_pago_metodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_pago_metodo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pago_metodo.FormattingEnabled = True
        Me.cb_pago_metodo.Location = New System.Drawing.Point(482, 39)
        Me.cb_pago_metodo.Name = "cb_pago_metodo"
        Me.cb_pago_metodo.Size = New System.Drawing.Size(220, 24)
        Me.cb_pago_metodo.TabIndex = 40
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(392, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 16)
        Me.Label17.TabIndex = 39
        Me.Label17.Text = "Forma:"
        '
        'tb_pago_condiciones
        '
        Me.tb_pago_condiciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_pago_condiciones.Location = New System.Drawing.Point(482, 144)
        Me.tb_pago_condiciones.Name = "tb_pago_condiciones"
        Me.tb_pago_condiciones.Size = New System.Drawing.Size(220, 22)
        Me.tb_pago_condiciones.TabIndex = 38
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(392, 147)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 16)
        Me.Label18.TabIndex = 37
        Me.Label18.Text = "Condiciones:"
        '
        'tb_pago_cuenta
        '
        Me.tb_pago_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_pago_cuenta.Location = New System.Drawing.Point(482, 119)
        Me.tb_pago_cuenta.Name = "tb_pago_cuenta"
        Me.tb_pago_cuenta.Size = New System.Drawing.Size(220, 22)
        Me.tb_pago_cuenta.TabIndex = 38
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(392, 125)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 16)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Cuenta:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(392, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 16)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Metodo:"
        '
        'tb_ticket_alone
        '
        Me.tb_ticket_alone.Location = New System.Drawing.Point(127, 134)
        Me.tb_ticket_alone.Name = "tb_ticket_alone"
        Me.tb_ticket_alone.Size = New System.Drawing.Size(102, 22)
        Me.tb_ticket_alone.TabIndex = 18
        '
        'rb_ticket_alone
        '
        Me.rb_ticket_alone.AutoSize = True
        Me.rb_ticket_alone.Checked = True
        Me.rb_ticket_alone.Location = New System.Drawing.Point(12, 136)
        Me.rb_ticket_alone.Name = "rb_ticket_alone"
        Me.rb_ticket_alone.Size = New System.Drawing.Size(109, 20)
        Me.rb_ticket_alone.TabIndex = 17
        Me.rb_ticket_alone.TabStop = True
        Me.rb_ticket_alone.Text = "Nota de venta"
        Me.rb_ticket_alone.UseVisualStyleBackColor = True
        '
        'btn_agregar_doc
        '
        Me.btn_agregar_doc.Location = New System.Drawing.Point(245, 132)
        Me.btn_agregar_doc.Name = "btn_agregar_doc"
        Me.btn_agregar_doc.Size = New System.Drawing.Size(109, 27)
        Me.btn_agregar_doc.TabIndex = 3
        Me.btn_agregar_doc.Text = "Agregar"
        Me.btn_agregar_doc.UseVisualStyleBackColor = True
        '
        'gp_agregar
        '
        Me.gp_agregar.Controls.Add(Me.chb_codigo)
        Me.gp_agregar.Controls.Add(Me.btn_bucar)
        Me.gp_agregar.Controls.Add(Me.btn_agregar)
        Me.gp_agregar.Controls.Add(Me.tb_codigo)
        Me.gp_agregar.Controls.Add(Me.Label12)
        Me.gp_agregar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gp_agregar.Location = New System.Drawing.Point(11, 160)
        Me.gp_agregar.Name = "gp_agregar"
        Me.gp_agregar.Size = New System.Drawing.Size(354, 52)
        Me.gp_agregar.TabIndex = 14
        Me.gp_agregar.TabStop = False
        Me.gp_agregar.Text = "    Producto"
        '
        'chb_codigo
        '
        Me.chb_codigo.AutoSize = True
        Me.chb_codigo.Location = New System.Drawing.Point(5, 24)
        Me.chb_codigo.Name = "chb_codigo"
        Me.chb_codigo.Size = New System.Drawing.Size(15, 14)
        Me.chb_codigo.TabIndex = 21
        Me.chb_codigo.UseVisualStyleBackColor = True
        '
        'btn_bucar
        '
        Me.btn_bucar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_bucar.Image = CType(resources.GetObject("btn_bucar.Image"), System.Drawing.Image)
        Me.btn_bucar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bucar.Location = New System.Drawing.Point(260, 19)
        Me.btn_bucar.Name = "btn_bucar"
        Me.btn_bucar.Size = New System.Drawing.Size(83, 27)
        Me.btn_bucar.TabIndex = 20
        Me.btn_bucar.Text = "      Buscar"
        Me.btn_bucar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Location = New System.Drawing.Point(181, 18)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(73, 28)
        Me.btn_agregar.TabIndex = 15
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'tb_codigo
        '
        Me.tb_codigo.Location = New System.Drawing.Point(92, 19)
        Me.tb_codigo.MaxLength = 15
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(71, 22)
        Me.tb_codigo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 16)
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
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(390, 11)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(63, 74)
        Me.btn_nuevo.TabIndex = 17
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(991, 11)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(55, 74)
        Me.btn_salir.TabIndex = 22
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'gb_listado
        '
        Me.gb_listado.Controls.Add(Me.Panel2)
        Me.gb_listado.Controls.Add(Me.FlowLayoutPanel1)
        Me.gb_listado.Controls.Add(Me.tb_buscar)
        Me.gb_listado.Controls.Add(Me.lbl_buscar)
        Me.gb_listado.Controls.Add(Me.Label19)
        Me.gb_listado.Controls.Add(Me.cb_cliente_busqueda)
        Me.gb_listado.Controls.Add(Me.lst_facturas)
        Me.gb_listado.Controls.Add(Me.btn_buscar)
        Me.gb_listado.Location = New System.Drawing.Point(3, 1)
        Me.gb_listado.Name = "gb_listado"
        Me.gb_listado.Size = New System.Drawing.Size(375, 711)
        Me.gb_listado.TabIndex = 23
        Me.gb_listado.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_total_paginas)
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Location = New System.Drawing.Point(14, 662)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(355, 39)
        Me.Panel2.TabIndex = 104
        '
        'lb_total_paginas
        '
        Me.lb_total_paginas.AutoSize = True
        Me.lb_total_paginas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_paginas.Location = New System.Drawing.Point(289, 10)
        Me.lb_total_paginas.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_total_paginas.Name = "lb_total_paginas"
        Me.lb_total_paginas.Size = New System.Drawing.Size(25, 21)
        Me.lb_total_paginas.TabIndex = 16
        Me.lb_total_paginas.Text = "/x"
        '
        'lb_pagina_actual
        '
        Me.lb_pagina_actual.AutoSize = True
        Me.lb_pagina_actual.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_pagina_actual.Location = New System.Drawing.Point(16, 6)
        Me.lb_pagina_actual.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_pagina_actual.Name = "lb_pagina_actual"
        Me.lb_pagina_actual.Size = New System.Drawing.Size(149, 21)
        Me.lb_pagina_actual.TabIndex = 15
        Me.lb_pagina_actual.Text = "lb_pagina_actual"
        '
        'pb_anterior
        '
        Me.pb_anterior.BackgroundImage = CType(resources.GetObject("pb_anterior.BackgroundImage"), System.Drawing.Image)
        Me.pb_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_anterior.Location = New System.Drawing.Point(218, 4)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(30, 30)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImage = CType(resources.GetObject("pb_siguiente.BackgroundImage"), System.Drawing.Image)
        Me.pb_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_siguiente.Location = New System.Drawing.Point(322, 3)
        Me.pb_siguiente.Name = "pb_siguiente"
        Me.pb_siguiente.Size = New System.Drawing.Size(30, 30)
        Me.pb_siguiente.TabIndex = 2
        Me.pb_siguiente.TabStop = False
        '
        'tb_pagina
        '
        Me.tb_pagina.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_pagina.Location = New System.Drawing.Point(254, 4)
        Me.tb_pagina.Name = "tb_pagina"
        Me.tb_pagina.Size = New System.Drawing.Size(32, 27)
        Me.tb_pagina.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.tb_resultados)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(14, 627)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 30)
        Me.FlowLayoutPanel1.TabIndex = 103
        '
        'tb_resultados
        '
        Me.tb_resultados.AutoSize = True
        Me.tb_resultados.BackColor = System.Drawing.Color.Transparent
        Me.tb_resultados.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_resultados.Location = New System.Drawing.Point(72, 5)
        Me.tb_resultados.Margin = New System.Windows.Forms.Padding(0)
        Me.tb_resultados.Name = "tb_resultados"
        Me.tb_resultados.Size = New System.Drawing.Size(109, 19)
        Me.tb_resultados.TabIndex = 12
        Me.tb_resultados.Text = "tb_resultados"
        '
        'tb_buscar
        '
        Me.tb_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_buscar.Location = New System.Drawing.Point(87, 62)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(216, 22)
        Me.tb_buscar.TabIndex = 15
        '
        'lbl_buscar
        '
        Me.lbl_buscar.AutoSize = True
        Me.lbl_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_buscar.Location = New System.Drawing.Point(11, 65)
        Me.lbl_buscar.Name = "lbl_buscar"
        Me.lbl_buscar.Size = New System.Drawing.Size(50, 16)
        Me.lbl_buscar.TabIndex = 13
        Me.lbl_buscar.Text = "Buscar:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(11, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 16)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Cliente:"
        '
        'cb_cliente_busqueda
        '
        Me.cb_cliente_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_cliente_busqueda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_cliente_busqueda.FormattingEnabled = True
        Me.cb_cliente_busqueda.Location = New System.Drawing.Point(87, 19)
        Me.cb_cliente_busqueda.Name = "cb_cliente_busqueda"
        Me.cb_cliente_busqueda.Size = New System.Drawing.Size(216, 25)
        Me.cb_cliente_busqueda.TabIndex = 14
        '
        'lst_facturas
        '
        Me.lst_facturas.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lst_facturas.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_facturas.GridLines = True
        Me.lst_facturas.HoverSelection = True
        Me.lst_facturas.Location = New System.Drawing.Point(14, 99)
        Me.lst_facturas.MultiSelect = False
        Me.lst_facturas.Name = "lst_facturas"
        Me.lst_facturas.Size = New System.Drawing.Size(357, 515)
        Me.lst_facturas.TabIndex = 0
        Me.lst_facturas.UseCompatibleStateImageBehavior = False
        Me.lst_facturas.View = System.Windows.Forms.View.Details
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(307, 13)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(64, 80)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(454, 11)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(68, 74)
        Me.btn_guardar.TabIndex = 18
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(662, 11)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(72, 74)
        Me.btn_cancelar.TabIndex = 21
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_deshacer
        '
        Me.btn_deshacer.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deshacer.Image = CType(resources.GetObject("btn_deshacer.Image"), System.Drawing.Image)
        Me.btn_deshacer.Location = New System.Drawing.Point(524, 11)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(72, 74)
        Me.btn_deshacer.TabIndex = 19
        Me.btn_deshacer.Text = "Deshacer"
        Me.btn_deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_deshacer.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Location = New System.Drawing.Point(597, 11)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(65, 74)
        Me.btn_editar.TabIndex = 20
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'btn_timbrar
        '
        Me.btn_timbrar.Enabled = False
        Me.btn_timbrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_timbrar.Image = CType(resources.GetObject("btn_timbrar.Image"), System.Drawing.Image)
        Me.btn_timbrar.Location = New System.Drawing.Point(736, 11)
        Me.btn_timbrar.Name = "btn_timbrar"
        Me.btn_timbrar.Size = New System.Drawing.Size(65, 74)
        Me.btn_timbrar.TabIndex = 22
        Me.btn_timbrar.Text = "Timbrar"
        Me.btn_timbrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_timbrar.UseVisualStyleBackColor = True
        '
        'btn_enviar
        '
        Me.btn_enviar.Enabled = False
        Me.btn_enviar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar.Image = CType(resources.GetObject("btn_enviar.Image"), System.Drawing.Image)
        Me.btn_enviar.Location = New System.Drawing.Point(801, 11)
        Me.btn_enviar.Name = "btn_enviar"
        Me.btn_enviar.Size = New System.Drawing.Size(64, 74)
        Me.btn_enviar.TabIndex = 22
        Me.btn_enviar.Text = "Enviar"
        Me.btn_enviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_enviar.UseVisualStyleBackColor = True
        '
        'btn_xml
        '
        Me.btn_xml.Enabled = False
        Me.btn_xml.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xml.Image = CType(resources.GetObject("btn_xml.Image"), System.Drawing.Image)
        Me.btn_xml.Location = New System.Drawing.Point(867, 11)
        Me.btn_xml.Name = "btn_xml"
        Me.btn_xml.Size = New System.Drawing.Size(60, 74)
        Me.btn_xml.TabIndex = 22
        Me.btn_xml.Text = "XML"
        Me.btn_xml.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_xml.UseVisualStyleBackColor = True
        '
        'btn_pdf
        '
        Me.btn_pdf.Enabled = False
        Me.btn_pdf.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pdf.Image = CType(resources.GetObject("btn_pdf.Image"), System.Drawing.Image)
        Me.btn_pdf.Location = New System.Drawing.Point(929, 11)
        Me.btn_pdf.Name = "btn_pdf"
        Me.btn_pdf.Size = New System.Drawing.Size(61, 74)
        Me.btn_pdf.TabIndex = 22
        Me.btn_pdf.Text = "PDF"
        Me.btn_pdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_pdf.UseVisualStyleBackColor = True
        '
        'tb_numero_factura
        '
        Me.tb_numero_factura.Location = New System.Drawing.Point(73, 22)
        Me.tb_numero_factura.Name = "tb_numero_factura"
        Me.tb_numero_factura.ReadOnly = True
        Me.tb_numero_factura.Size = New System.Drawing.Size(101, 22)
        Me.tb_numero_factura.TabIndex = 3
        Me.tb_numero_factura.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Número:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Receptor:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Domicilio:"
        '
        'tb_domicilio
        '
        Me.tb_domicilio.Location = New System.Drawing.Point(73, 108)
        Me.tb_domicilio.Name = "tb_domicilio"
        Me.tb_domicilio.ReadOnly = True
        Me.tb_domicilio.Size = New System.Drawing.Size(271, 22)
        Me.tb_domicilio.TabIndex = 1
        Me.tb_domicilio.TabStop = False
        '
        'cb_cliente
        '
        Me.cb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(73, 79)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(271, 24)
        Me.cb_cliente.TabIndex = 25
        '
        'btn_nuevo_cliente
        '
        Me.btn_nuevo_cliente.Location = New System.Drawing.Point(350, 79)
        Me.btn_nuevo_cliente.Name = "btn_nuevo_cliente"
        Me.btn_nuevo_cliente.Size = New System.Drawing.Size(33, 26)
        Me.btn_nuevo_cliente.TabIndex = 35
        Me.btn_nuevo_cliente.Text = "Nuevo Cliente"
        Me.btn_nuevo_cliente.UseVisualStyleBackColor = True
        Me.btn_nuevo_cliente.Visible = False
        '
        'lbl_estatus_timbrado
        '
        Me.lbl_estatus_timbrado.AutoSize = True
        Me.lbl_estatus_timbrado.BackColor = System.Drawing.Color.Ivory
        Me.lbl_estatus_timbrado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estatus_timbrado.ForeColor = System.Drawing.Color.White
        Me.lbl_estatus_timbrado.Location = New System.Drawing.Point(350, 11)
        Me.lbl_estatus_timbrado.MaximumSize = New System.Drawing.Size(250, 25)
        Me.lbl_estatus_timbrado.MinimumSize = New System.Drawing.Size(250, 25)
        Me.lbl_estatus_timbrado.Name = "lbl_estatus_timbrado"
        Me.lbl_estatus_timbrado.Size = New System.Drawing.Size(250, 25)
        Me.lbl_estatus_timbrado.TabIndex = 36
        Me.lbl_estatus_timbrado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lbl_estatus_timbrado.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Elaboró:"
        '
        'tb_aviso_cancelado
        '
        Me.tb_aviso_cancelado.AutoSize = True
        Me.tb_aviso_cancelado.BackColor = System.Drawing.Color.DarkRed
        Me.tb_aviso_cancelado.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_aviso_cancelado.ForeColor = System.Drawing.Color.White
        Me.tb_aviso_cancelado.Location = New System.Drawing.Point(454, 11)
        Me.tb_aviso_cancelado.MaximumSize = New System.Drawing.Size(200, 25)
        Me.tb_aviso_cancelado.MinimumSize = New System.Drawing.Size(200, 25)
        Me.tb_aviso_cancelado.Name = "tb_aviso_cancelado"
        Me.tb_aviso_cancelado.Size = New System.Drawing.Size(200, 25)
        Me.tb_aviso_cancelado.TabIndex = 36
        Me.tb_aviso_cancelado.Text = "C ANCELADA"
        Me.tb_aviso_cancelado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tb_aviso_cancelado.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(193, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Fecha:"
        '
        'tb_empleado
        '
        Me.tb_empleado.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_empleado.Location = New System.Drawing.Point(73, 50)
        Me.tb_empleado.Name = "tb_empleado"
        Me.tb_empleado.ReadOnly = True
        Me.tb_empleado.Size = New System.Drawing.Size(271, 22)
        Me.tb_empleado.TabIndex = 14
        Me.tb_empleado.TabStop = False
        '
        'tb_fecha
        '
        Me.tb_fecha.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tb_fecha.Location = New System.Drawing.Point(249, 22)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(95, 22)
        Me.tb_fecha.TabIndex = 5
        '
        'gb_factura
        '
        Me.gb_factura.Controls.Add(Me.tb_tipo_cambio)
        Me.gb_factura.Controls.Add(Me.Label20)
        Me.gb_factura.Controls.Add(Me.gb_relacion)
        Me.gb_factura.Controls.Add(Me.GroupBox1)
        Me.gb_factura.Controls.Add(Me.QrCodeImgControl1)
        Me.gb_factura.Controls.Add(Me.dg_factura)
        Me.gb_factura.Controls.Add(Me.tb_ticket_alone)
        Me.gb_factura.Controls.Add(Me.btn_agregar_doc)
        Me.gb_factura.Controls.Add(Me.gp_agregar)
        Me.gb_factura.Controls.Add(Me.tb_pago_condiciones)
        Me.gb_factura.Controls.Add(Me.rb_ticket_alone)
        Me.gb_factura.Controls.Add(Me.cb_moneda)
        Me.gb_factura.Controls.Add(Me.cb_uso_cfdi)
        Me.gb_factura.Controls.Add(Me.Label15)
        Me.gb_factura.Controls.Add(Me.cb_pago_forma)
        Me.gb_factura.Controls.Add(Me.Label6)
        Me.gb_factura.Controls.Add(Me.Label18)
        Me.gb_factura.Controls.Add(Me.Label17)
        Me.gb_factura.Controls.Add(Me.tb_pago_cuenta)
        Me.gb_factura.Controls.Add(Me.btn_nuevo_cliente)
        Me.gb_factura.Controls.Add(Me.Label16)
        Me.gb_factura.Controls.Add(Me.cb_pago_metodo)
        Me.gb_factura.Controls.Add(Me.tb_fecha)
        Me.gb_factura.Controls.Add(Me.tb_empleado)
        Me.gb_factura.Controls.Add(Me.cb_cliente)
        Me.gb_factura.Controls.Add(Me.tb_domicilio)
        Me.gb_factura.Controls.Add(Me.Label9)
        Me.gb_factura.Controls.Add(Me.Label14)
        Me.gb_factura.Controls.Add(Me.tb_aviso_cancelado)
        Me.gb_factura.Controls.Add(Me.Label8)
        Me.gb_factura.Controls.Add(Me.Label10)
        Me.gb_factura.Controls.Add(Me.Label5)
        Me.gb_factura.Controls.Add(Me.Label4)
        Me.gb_factura.Controls.Add(Me.lbl_estatus_timbrado)
        Me.gb_factura.Controls.Add(Me.tb_numero_factura)
        Me.gb_factura.Enabled = False
        Me.gb_factura.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_factura.Location = New System.Drawing.Point(380, 90)
        Me.gb_factura.Name = "gb_factura"
        Me.gb_factura.Size = New System.Drawing.Size(708, 638)
        Me.gb_factura.TabIndex = 24
        Me.gb_factura.TabStop = False
        Me.gb_factura.Text = "Información"
        '
        'tb_tipo_cambio
        '
        Me.tb_tipo_cambio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_tipo_cambio.Location = New System.Drawing.Point(482, 200)
        Me.tb_tipo_cambio.Name = "tb_tipo_cambio"
        Me.tb_tipo_cambio.Size = New System.Drawing.Size(220, 22)
        Me.tb_tipo_cambio.TabIndex = 44
        Me.tb_tipo_cambio.Text = "1"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(392, 200)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(86, 16)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Tipo Cambio:"
        '
        'gb_relacion
        '
        Me.gb_relacion.Controls.Add(Me.lst_documentos)
        Me.gb_relacion.Controls.Add(Me.cb_folio_fiscal)
        Me.gb_relacion.Controls.Add(Me.Label13)
        Me.gb_relacion.Controls.Add(Me.Label11)
        Me.gb_relacion.Controls.Add(Me.btn_eliminar_doc)
        Me.gb_relacion.Controls.Add(Me.btn_agregar_folio)
        Me.gb_relacion.Controls.Add(Me.cb_tipo_relacion)
        Me.gb_relacion.Location = New System.Drawing.Point(5, 217)
        Me.gb_relacion.Margin = New System.Windows.Forms.Padding(2)
        Me.gb_relacion.Name = "gb_relacion"
        Me.gb_relacion.Padding = New System.Windows.Forms.Padding(2)
        Me.gb_relacion.Size = New System.Drawing.Size(698, 102)
        Me.gb_relacion.TabIndex = 42
        Me.gb_relacion.TabStop = False
        Me.gb_relacion.Text = "Documentos Relacionados"
        '
        'lst_documentos
        '
        Me.lst_documentos.Location = New System.Drawing.Point(350, 17)
        Me.lst_documentos.Margin = New System.Windows.Forms.Padding(2)
        Me.lst_documentos.Name = "lst_documentos"
        Me.lst_documentos.Size = New System.Drawing.Size(344, 80)
        Me.lst_documentos.TabIndex = 43
        Me.lst_documentos.UseCompatibleStateImageBehavior = False
        Me.lst_documentos.View = System.Windows.Forms.View.Details
        '
        'cb_folio_fiscal
        '
        Me.cb_folio_fiscal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_folio_fiscal.FormattingEnabled = True
        Me.cb_folio_fiscal.Location = New System.Drawing.Point(121, 46)
        Me.cb_folio_fiscal.Name = "cb_folio_fiscal"
        Me.cb_folio_fiscal.Size = New System.Drawing.Size(218, 24)
        Me.cb_folio_fiscal.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Documento (UUID):"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Tipo de Relación:"
        '
        'btn_eliminar_doc
        '
        Me.btn_eliminar_doc.Location = New System.Drawing.Point(277, 73)
        Me.btn_eliminar_doc.Name = "btn_eliminar_doc"
        Me.btn_eliminar_doc.Size = New System.Drawing.Size(61, 24)
        Me.btn_eliminar_doc.TabIndex = 15
        Me.btn_eliminar_doc.Text = "Eliminar"
        Me.btn_eliminar_doc.UseVisualStyleBackColor = True
        '
        'btn_agregar_folio
        '
        Me.btn_agregar_folio.Location = New System.Drawing.Point(212, 73)
        Me.btn_agregar_folio.Name = "btn_agregar_folio"
        Me.btn_agregar_folio.Size = New System.Drawing.Size(61, 24)
        Me.btn_agregar_folio.TabIndex = 15
        Me.btn_agregar_folio.Text = "Agregar"
        Me.btn_agregar_folio.UseVisualStyleBackColor = True
        '
        'cb_tipo_relacion
        '
        Me.cb_tipo_relacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tipo_relacion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipo_relacion.FormattingEnabled = True
        Me.cb_tipo_relacion.Location = New System.Drawing.Point(121, 20)
        Me.cb_tipo_relacion.Name = "cb_tipo_relacion"
        Me.cb_tipo_relacion.Size = New System.Drawing.Size(218, 24)
        Me.cb_tipo_relacion.TabIndex = 40
        '
        'cb_moneda
        '
        Me.cb_moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_moneda.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_moneda.FormattingEnabled = True
        Me.cb_moneda.Location = New System.Drawing.Point(482, 169)
        Me.cb_moneda.Name = "cb_moneda"
        Me.cb_moneda.Size = New System.Drawing.Size(220, 24)
        Me.cb_moneda.TabIndex = 40
        '
        'cb_uso_cfdi
        '
        Me.cb_uso_cfdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_uso_cfdi.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_uso_cfdi.FormattingEnabled = True
        Me.cb_uso_cfdi.Location = New System.Drawing.Point(482, 91)
        Me.cb_uso_cfdi.Name = "cb_uso_cfdi"
        Me.cb_uso_cfdi.Size = New System.Drawing.Size(220, 24)
        Me.cb_uso_cfdi.TabIndex = 40
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(392, 177)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 16)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Moneda:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(392, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Uso:"
        '
        'frm_facturacion_electronica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1097, 730)
        Me.Controls.Add(Me.gb_factura)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.btn_pdf)
        Me.Controls.Add(Me.btn_xml)
        Me.Controls.Add(Me.btn_enviar)
        Me.Controls.Add(Me.btn_timbrar)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.gb_listado)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_deshacer)
        Me.Controls.Add(Me.btn_editar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1023, 508)
        Me.Name = "frm_facturacion_electronica"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturación Electronica"
        CType(Me.dg_factura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gp_agregar.ResumeLayout(False)
        Me.gp_agregar.PerformLayout()
        Me.gb_listado.ResumeLayout(False)
        Me.gb_listado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.gb_factura.ResumeLayout(False)
        Me.gb_factura.PerformLayout()
        Me.gb_relacion.ResumeLayout(False)
        Me.gb_relacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg_factura As System.Windows.Forms.DataGridView
    Friend WithEvents gp_agregar As System.Windows.Forms.GroupBox
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_bucar As System.Windows.Forms.Button
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents chb_codigo As System.Windows.Forms.CheckBox
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_pago_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cb_pago_forma As System.Windows.Forms.ComboBox
    Friend WithEvents cb_pago_metodo As System.Windows.Forms.ComboBox
    Friend WithEvents tb_ticket_alone As System.Windows.Forms.TextBox
    Friend WithEvents rb_ticket_alone As System.Windows.Forms.RadioButton
    Friend WithEvents btn_agregar_doc As System.Windows.Forms.Button
    Friend WithEvents tb_pago_condiciones As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents gb_listado As System.Windows.Forms.GroupBox
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_buscar As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cb_cliente_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents lst_facturas As System.Windows.Forms.ListView
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_timbrar As System.Windows.Forms.Button
    Friend WithEvents btn_enviar As System.Windows.Forms.Button
    Friend WithEvents btn_xml As System.Windows.Forms.Button
    Friend WithEvents btn_pdf As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_numero_factura As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_domicilio As System.Windows.Forms.TextBox
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents btn_nuevo_cliente As System.Windows.Forms.Button
    Private WithEvents lbl_estatus_timbrado As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents tb_aviso_cancelado As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_empleado As System.Windows.Forms.TextBox
    Friend WithEvents tb_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents gb_factura As System.Windows.Forms.GroupBox
    Friend WithEvents cb_uso_cfdi As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_retenciones As System.Windows.Forms.TextBox
    Friend WithEvents gb_relacion As System.Windows.Forms.GroupBox
    Friend WithEvents lst_documentos As System.Windows.Forms.ListView
    Friend WithEvents cb_folio_fiscal As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar_doc As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_folio As System.Windows.Forms.Button
    Friend WithEvents cb_tipo_relacion As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lb_total_paginas As System.Windows.Forms.Label
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents tb_tipo_cambio As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cb_moneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
