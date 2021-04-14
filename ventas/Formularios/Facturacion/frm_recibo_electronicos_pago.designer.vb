<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_recibo_pagos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_recibo_pagos))
        Me.dg_recibo = New System.Windows.Forms.DataGridView()
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
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
        Me.lst_recibos = New System.Windows.Forms.ListView()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_timbrar = New System.Windows.Forms.Button()
        Me.btn_enviar = New System.Windows.Forms.Button()
        Me.btn_xml = New System.Windows.Forms.Button()
        Me.btn_pdf = New System.Windows.Forms.Button()
        Me.tb_numero_recibo = New System.Windows.Forms.TextBox()
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
        Me.gb_recibo = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tb_cuenta_beneficiario = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_rfc_beneficiario = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_cuenta_ordenante = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_nombre_ordenante = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_rfc_ordenante = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_num_operacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_hora_pago = New System.Windows.Forms.DateTimePicker()
        Me.cb_pago_forma = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb_moneda_pago = New System.Windows.Forms.ComboBox()
        Me.tb_total_pago = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.gb_relacion = New System.Windows.Forms.GroupBox()
        Me.btn_agregar_factura = New System.Windows.Forms.Button()
        Me.cb_folio_fiscal = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.dg_recibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_listado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gb_recibo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gb_relacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg_recibo
        '
        Me.dg_recibo.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dg_recibo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_recibo.Location = New System.Drawing.Point(7, 427)
        Me.dg_recibo.Name = "dg_recibo"
        Me.dg_recibo.Size = New System.Drawing.Size(695, 205)
        Me.dg_recibo.TabIndex = 30
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(661, 11)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(35, 42)
        Me.QrCodeImgControl1.TabIndex = 26
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        Me.QrCodeImgControl1.Visible = False
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
        Me.gb_listado.Controls.Add(Me.lst_recibos)
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
        'lst_recibos
        '
        Me.lst_recibos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lst_recibos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_recibos.GridLines = True
        Me.lst_recibos.HoverSelection = True
        Me.lst_recibos.Location = New System.Drawing.Point(14, 99)
        Me.lst_recibos.MultiSelect = False
        Me.lst_recibos.Name = "lst_recibos"
        Me.lst_recibos.Size = New System.Drawing.Size(357, 515)
        Me.lst_recibos.TabIndex = 0
        Me.lst_recibos.UseCompatibleStateImageBehavior = False
        Me.lst_recibos.View = System.Windows.Forms.View.Details
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
        'tb_numero_recibo
        '
        Me.tb_numero_recibo.Location = New System.Drawing.Point(83, 21)
        Me.tb_numero_recibo.Name = "tb_numero_recibo"
        Me.tb_numero_recibo.ReadOnly = True
        Me.tb_numero_recibo.Size = New System.Drawing.Size(101, 22)
        Me.tb_numero_recibo.TabIndex = 3
        Me.tb_numero_recibo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Número:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha y hora del pago:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(364, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Domicilio:"
        '
        'tb_domicilio
        '
        Me.tb_domicilio.Location = New System.Drawing.Point(431, 49)
        Me.tb_domicilio.Multiline = True
        Me.tb_domicilio.Name = "tb_domicilio"
        Me.tb_domicilio.ReadOnly = True
        Me.tb_domicilio.Size = New System.Drawing.Size(271, 52)
        Me.tb_domicilio.TabIndex = 1
        Me.tb_domicilio.TabStop = False
        '
        'cb_cliente
        '
        Me.cb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(83, 77)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(271, 24)
        Me.cb_cliente.TabIndex = 25
        '
        'btn_nuevo_cliente
        '
        Me.btn_nuevo_cliente.Location = New System.Drawing.Point(360, 77)
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
        Me.lbl_estatus_timbrado.Location = New System.Drawing.Point(360, 10)
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
        Me.Label10.Location = New System.Drawing.Point(17, 55)
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
        Me.Label9.Location = New System.Drawing.Point(203, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Fecha:"
        '
        'tb_empleado
        '
        Me.tb_empleado.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_empleado.Location = New System.Drawing.Point(83, 49)
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
        Me.tb_fecha.Location = New System.Drawing.Point(259, 21)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(95, 22)
        Me.tb_fecha.TabIndex = 5
        '
        'gb_recibo
        '
        Me.gb_recibo.Controls.Add(Me.GroupBox2)
        Me.gb_recibo.Controls.Add(Me.gb_relacion)
        Me.gb_recibo.Controls.Add(Me.QrCodeImgControl1)
        Me.gb_recibo.Controls.Add(Me.dg_recibo)
        Me.gb_recibo.Controls.Add(Me.btn_nuevo_cliente)
        Me.gb_recibo.Controls.Add(Me.tb_fecha)
        Me.gb_recibo.Controls.Add(Me.tb_empleado)
        Me.gb_recibo.Controls.Add(Me.cb_cliente)
        Me.gb_recibo.Controls.Add(Me.tb_domicilio)
        Me.gb_recibo.Controls.Add(Me.Label9)
        Me.gb_recibo.Controls.Add(Me.tb_aviso_cancelado)
        Me.gb_recibo.Controls.Add(Me.Label8)
        Me.gb_recibo.Controls.Add(Me.Label10)
        Me.gb_recibo.Controls.Add(Me.Label12)
        Me.gb_recibo.Controls.Add(Me.Label4)
        Me.gb_recibo.Controls.Add(Me.lbl_estatus_timbrado)
        Me.gb_recibo.Controls.Add(Me.tb_numero_recibo)
        Me.gb_recibo.Enabled = False
        Me.gb_recibo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_recibo.Location = New System.Drawing.Point(380, 90)
        Me.gb_recibo.Name = "gb_recibo"
        Me.gb_recibo.Size = New System.Drawing.Size(708, 638)
        Me.gb_recibo.TabIndex = 24
        Me.gb_recibo.TabStop = False
        Me.gb_recibo.Text = "Información"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tb_cuenta_beneficiario)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.tb_rfc_beneficiario)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.tb_cuenta_ordenante)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.tb_nombre_ordenante)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tb_rfc_ordenante)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.tb_num_operacion)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtp_fecha_hora_pago)
        Me.GroupBox2.Controls.Add(Me.cb_pago_forma)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cb_moneda_pago)
        Me.GroupBox2.Controls.Add(Me.tb_total_pago)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(693, 212)
        Me.GroupBox2.TabIndex = 44
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información del pago"
        '
        'tb_cuenta_beneficiario
        '
        Me.tb_cuenta_beneficiario.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cuenta_beneficiario.Location = New System.Drawing.Point(504, 121)
        Me.tb_cuenta_beneficiario.Name = "tb_cuenta_beneficiario"
        Me.tb_cuenta_beneficiario.Size = New System.Drawing.Size(180, 22)
        Me.tb_cuenta_beneficiario.TabIndex = 57
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(354, 124)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 16)
        Me.Label16.TabIndex = 56
        Me.Label16.Text = "Cuenta Destino:"
        '
        'tb_rfc_beneficiario
        '
        Me.tb_rfc_beneficiario.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_rfc_beneficiario.Location = New System.Drawing.Point(504, 93)
        Me.tb_rfc_beneficiario.Name = "tb_rfc_beneficiario"
        Me.tb_rfc_beneficiario.Size = New System.Drawing.Size(180, 22)
        Me.tb_rfc_beneficiario.TabIndex = 55
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(355, 99)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 16)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "RFC Entidad Destino:"
        '
        'tb_cuenta_ordenante
        '
        Me.tb_cuenta_ordenante.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cuenta_ordenante.Location = New System.Drawing.Point(160, 180)
        Me.tb_cuenta_ordenante.Name = "tb_cuenta_ordenante"
        Me.tb_cuenta_ordenante.Size = New System.Drawing.Size(180, 22)
        Me.tb_cuenta_ordenante.TabIndex = 51
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 16)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Cuenta Ordenante:"
        '
        'tb_nombre_ordenante
        '
        Me.tb_nombre_ordenante.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre_ordenante.Location = New System.Drawing.Point(160, 152)
        Me.tb_nombre_ordenante.Name = "tb_nombre_ordenante"
        Me.tb_nombre_ordenante.Size = New System.Drawing.Size(180, 22)
        Me.tb_nombre_ordenante.TabIndex = 49
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Nombre Banco Ord."
        '
        'tb_rfc_ordenante
        '
        Me.tb_rfc_ordenante.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_rfc_ordenante.Location = New System.Drawing.Point(160, 124)
        Me.tb_rfc_ordenante.Name = "tb_rfc_ordenante"
        Me.tb_rfc_ordenante.Size = New System.Drawing.Size(180, 22)
        Me.tb_rfc_ordenante.TabIndex = 47
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 16)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "RFC Entidad Emisora"
        '
        'tb_num_operacion
        '
        Me.tb_num_operacion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_num_operacion.Location = New System.Drawing.Point(160, 96)
        Me.tb_num_operacion.Name = "tb_num_operacion"
        Me.tb_num_operacion.Size = New System.Drawing.Size(180, 22)
        Me.tb_num_operacion.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 16)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Número Operación:"
        '
        'dtp_fecha_hora_pago
        '
        Me.dtp_fecha_hora_pago.CustomFormat = "dd/MM/yyyy - hh:mm:ss tt"
        Me.dtp_fecha_hora_pago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_hora_pago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_hora_pago.Location = New System.Drawing.Point(160, 24)
        Me.dtp_fecha_hora_pago.Name = "dtp_fecha_hora_pago"
        Me.dtp_fecha_hora_pago.Size = New System.Drawing.Size(184, 22)
        Me.dtp_fecha_hora_pago.TabIndex = 43
        '
        'cb_pago_forma
        '
        Me.cb_pago_forma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_pago_forma.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pago_forma.FormattingEnabled = True
        Me.cb_pago_forma.Location = New System.Drawing.Point(504, 24)
        Me.cb_pago_forma.Name = "cb_pago_forma"
        Me.cb_pago_forma.Size = New System.Drawing.Size(165, 24)
        Me.cb_pago_forma.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(353, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Forma de pago:"
        '
        'cb_moneda_pago
        '
        Me.cb_moneda_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_moneda_pago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_moneda_pago.FormattingEnabled = True
        Me.cb_moneda_pago.Location = New System.Drawing.Point(160, 52)
        Me.cb_moneda_pago.Name = "cb_moneda_pago"
        Me.cb_moneda_pago.Size = New System.Drawing.Size(184, 24)
        Me.cb_moneda_pago.TabIndex = 40
        '
        'tb_total_pago
        '
        Me.tb_total_pago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total_pago.Location = New System.Drawing.Point(504, 52)
        Me.tb_total_pago.Name = "tb_total_pago"
        Me.tb_total_pago.Size = New System.Drawing.Size(165, 22)
        Me.tb_total_pago.TabIndex = 38
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Moneda"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(353, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Monto:"
        '
        'gb_relacion
        '
        Me.gb_relacion.Controls.Add(Me.btn_agregar_factura)
        Me.gb_relacion.Controls.Add(Me.cb_folio_fiscal)
        Me.gb_relacion.Controls.Add(Me.Label13)
        Me.gb_relacion.Location = New System.Drawing.Point(5, 338)
        Me.gb_relacion.Margin = New System.Windows.Forms.Padding(2)
        Me.gb_relacion.Name = "gb_relacion"
        Me.gb_relacion.Padding = New System.Windows.Forms.Padding(2)
        Me.gb_relacion.Size = New System.Drawing.Size(698, 84)
        Me.gb_relacion.TabIndex = 42
        Me.gb_relacion.TabStop = False
        Me.gb_relacion.Text = "Documento(s) pagado(s)"
        '
        'btn_agregar_factura
        '
        Me.btn_agregar_factura.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_factura.Image = CType(resources.GetObject("btn_agregar_factura.Image"), System.Drawing.Image)
        Me.btn_agregar_factura.Location = New System.Drawing.Point(555, 20)
        Me.btn_agregar_factura.Name = "btn_agregar_factura"
        Me.btn_agregar_factura.Size = New System.Drawing.Size(134, 59)
        Me.btn_agregar_factura.TabIndex = 43
        Me.btn_agregar_factura.Text = "Agregar"
        Me.btn_agregar_factura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_agregar_factura.UseVisualStyleBackColor = True
        '
        'cb_folio_fiscal
        '
        Me.cb_folio_fiscal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_folio_fiscal.FormattingEnabled = True
        Me.cb_folio_fiscal.Location = New System.Drawing.Point(127, 37)
        Me.cb_folio_fiscal.Name = "cb_folio_fiscal"
        Me.cb_folio_fiscal.Size = New System.Drawing.Size(413, 24)
        Me.cb_folio_fiscal.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Documento (UUID):"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Receptor:"
        '
        'frm_recibo_pagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 730)
        Me.Controls.Add(Me.gb_recibo)
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
        Me.Name = "frm_recibo_pagos"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Recibo de Pago"
        CType(Me.dg_recibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_listado.ResumeLayout(False)
        Me.gb_listado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.gb_recibo.ResumeLayout(False)
        Me.gb_recibo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gb_relacion.ResumeLayout(False)
        Me.gb_relacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dg_recibo As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents gb_listado As System.Windows.Forms.GroupBox
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_buscar As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cb_cliente_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents lst_recibos As System.Windows.Forms.ListView
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_timbrar As System.Windows.Forms.Button
    Friend WithEvents btn_enviar As System.Windows.Forms.Button
    Friend WithEvents btn_xml As System.Windows.Forms.Button
    Friend WithEvents btn_pdf As System.Windows.Forms.Button
    Friend WithEvents tb_numero_recibo As System.Windows.Forms.TextBox
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
    Friend WithEvents gb_recibo As System.Windows.Forms.GroupBox
    Friend WithEvents gb_relacion As System.Windows.Forms.GroupBox
    Friend WithEvents cb_folio_fiscal As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lb_total_paginas As System.Windows.Forms.Label
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_hora_pago As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_moneda_pago As System.Windows.Forms.ComboBox
    Friend WithEvents cb_pago_forma As System.Windows.Forms.ComboBox
    Friend WithEvents tb_total_pago As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn_agregar_factura As System.Windows.Forms.Button
    Friend WithEvents tb_cuenta_beneficiario As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_rfc_beneficiario As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_cuenta_ordenante As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre_ordenante As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_rfc_ordenante As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_num_operacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
