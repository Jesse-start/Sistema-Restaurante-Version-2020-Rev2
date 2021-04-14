<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_cancelaciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_cancelaciones))
        Me.gb_busqueda = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_busqueda = New System.Windows.Forms.DataGridView()
        Me.cb_opciones_busqueda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_cliente_busqueda = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_termino = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_busqueda = New System.Windows.Forms.DateTimePicker()
        Me.tb_folio_busqueda = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_buscar_folio = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gb_opciones_doc = New System.Windows.Forms.GroupBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_cancelar_documento = New System.Windows.Forms.Button()
        Me.btn_imprimir_orden = New System.Windows.Forms.Button()
        Me.btn_reimprimir_documento = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.gb_traspaso_recepcion = New System.Windows.Forms.GroupBox()
        Me.tb_estatus_traspaso_recepcion = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tb_recibio_traspaso = New System.Windows.Forms.TextBox()
        Me.tb_sucursal_origen_traspaso = New System.Windows.Forms.TextBox()
        Me.gb_traspaso_envio = New System.Windows.Forms.GroupBox()
        Me.tb_estatus_traspaso_envio = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tb_empleado_traspaso_envio = New System.Windows.Forms.TextBox()
        Me.tb_sucursal_destino_traspaso = New System.Windows.Forms.TextBox()
        Me.gb_datos_compra = New System.Windows.Forms.GroupBox()
        Me.tb_estatus_compra = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tb_remision = New System.Windows.Forms.TextBox()
        Me.tb_proveedor = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_remision = New System.Windows.Forms.DateTimePicker()
        Me.tb_persona_recibe = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gb_datos_clientes = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_cliente = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_direccion = New System.Windows.Forms.TextBox()
        Me.tb_estatus = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tb_vendedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_tipo_movimiento = New System.Windows.Forms.Label()
        Me.tb_aviso_cancelado = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.dtp_hora = New System.Windows.Forms.DateTimePicker()
        Me.tb_folio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tab_opciones = New System.Windows.Forms.TabControl()
        Me.tab_productos = New System.Windows.Forms.TabPage()
        Me.dgv_producto_cancelacion = New System.Windows.Forms.DataGridView()
        Me.tab_pagos = New System.Windows.Forms.TabPage()
        Me.lbl_saldo = New System.Windows.Forms.TextBox()
        Me.gb_opciones_pagos = New System.Windows.Forms.GroupBox()
        Me.btn_imprimir_abono = New System.Windows.Forms.Button()
        Me.btn_cancelar_abono = New System.Windows.Forms.Button()
        Me.lbl_cobros = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgv_abonos = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_impuestos = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_descuento = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.rb_buscar_traspaso_recep = New System.Windows.Forms.RadioButton()
        Me.rb_buscar_traspaso_env = New System.Windows.Forms.RadioButton()
        Me.rb_buscar_compra = New System.Windows.Forms.RadioButton()
        Me.rb_buscar_credito = New System.Windows.Forms.RadioButton()
        Me.rb_buscar_apartado = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rb_buscar_pedido = New System.Windows.Forms.RadioButton()
        Me.rb_buscar_nota = New System.Windows.Forms.RadioButton()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.gb_busqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gb_opciones_doc.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gb_traspaso_recepcion.SuspendLayout()
        Me.gb_traspaso_envio.SuspendLayout()
        Me.gb_datos_compra.SuspendLayout()
        Me.gb_datos_clientes.SuspendLayout()
        Me.tab_opciones.SuspendLayout()
        Me.tab_productos.SuspendLayout()
        CType(Me.dgv_producto_cancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_pagos.SuspendLayout()
        Me.gb_opciones_pagos.SuspendLayout()
        CType(Me.dgv_abonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_busqueda
        '
        Me.gb_busqueda.Controls.Add(Me.GroupBox1)
        Me.gb_busqueda.Controls.Add(Me.cb_opciones_busqueda)
        Me.gb_busqueda.Controls.Add(Me.Label4)
        Me.gb_busqueda.Controls.Add(Me.Label3)
        Me.gb_busqueda.Controls.Add(Me.tb_cliente_busqueda)
        Me.gb_busqueda.Controls.Add(Me.Label2)
        Me.gb_busqueda.Controls.Add(Me.Label1)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_termino)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_inicio)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_busqueda)
        Me.gb_busqueda.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_busqueda.Location = New System.Drawing.Point(8, 129)
        Me.gb_busqueda.Name = "gb_busqueda"
        Me.gb_busqueda.Size = New System.Drawing.Size(374, 547)
        Me.gb_busqueda.TabIndex = 2
        Me.gb_busqueda.TabStop = False
        Me.gb_busqueda.Text = "Busqueda"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_busqueda)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 422)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'dgv_busqueda
        '
        Me.dgv_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_busqueda.Location = New System.Drawing.Point(4, 21)
        Me.dgv_busqueda.MultiSelect = False
        Me.dgv_busqueda.Name = "dgv_busqueda"
        Me.dgv_busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_busqueda.Size = New System.Drawing.Size(347, 395)
        Me.dgv_busqueda.TabIndex = 8
        '
        'cb_opciones_busqueda
        '
        Me.cb_opciones_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_opciones_busqueda.FormattingEnabled = True
        Me.cb_opciones_busqueda.Location = New System.Drawing.Point(87, 61)
        Me.cb_opciones_busqueda.Name = "cb_opciones_busqueda"
        Me.cb_opciones_busqueda.Size = New System.Drawing.Size(134, 28)
        Me.cb_opciones_busqueda.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mostrar:"
        '
        'tb_cliente_busqueda
        '
        Me.tb_cliente_busqueda.Location = New System.Drawing.Point(87, 25)
        Me.tb_cliente_busqueda.Name = "tb_cliente_busqueda"
        Me.tb_cliente_busqueda.Size = New System.Drawing.Size(276, 26)
        Me.tb_cliente_busqueda.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "a:"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "De:"
        Me.Label1.Visible = False
        '
        'dtp_fecha_termino
        '
        Me.dtp_fecha_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino.Location = New System.Drawing.Point(240, 101)
        Me.dtp_fecha_termino.Name = "dtp_fecha_termino"
        Me.dtp_fecha_termino.Size = New System.Drawing.Size(123, 26)
        Me.dtp_fecha_termino.TabIndex = 3
        Me.dtp_fecha_termino.Visible = False
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(86, 99)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(119, 26)
        Me.dtp_fecha_inicio.TabIndex = 3
        Me.dtp_fecha_inicio.Visible = False
        '
        'dtp_fecha_busqueda
        '
        Me.dtp_fecha_busqueda.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_busqueda.Location = New System.Drawing.Point(240, 61)
        Me.dtp_fecha_busqueda.Name = "dtp_fecha_busqueda"
        Me.dtp_fecha_busqueda.Size = New System.Drawing.Size(123, 26)
        Me.dtp_fecha_busqueda.TabIndex = 3
        Me.dtp_fecha_busqueda.Visible = False
        '
        'tb_folio_busqueda
        '
        Me.tb_folio_busqueda.Location = New System.Drawing.Point(83, 30)
        Me.tb_folio_busqueda.Name = "tb_folio_busqueda"
        Me.tb_folio_busqueda.Size = New System.Drawing.Size(63, 26)
        Me.tb_folio_busqueda.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_buscar_folio)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_traspaso_recep)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_traspaso_env)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_compra)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_credito)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_apartado)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_pedido)
        Me.GroupBox2.Controls.Add(Me.rb_buscar_nota)
        Me.GroupBox2.Controls.Add(Me.gb_busqueda)
        Me.GroupBox2.Controls.Add(Me.tb_folio_busqueda)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(988, 682)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'btn_buscar_folio
        '
        Me.btn_buscar_folio.Image = CType(resources.GetObject("btn_buscar_folio.Image"), System.Drawing.Image)
        Me.btn_buscar_folio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar_folio.Location = New System.Drawing.Point(177, 12)
        Me.btn_buscar_folio.Name = "btn_buscar_folio"
        Me.btn_buscar_folio.Size = New System.Drawing.Size(156, 62)
        Me.btn_buscar_folio.TabIndex = 7
        Me.btn_buscar_folio.Text = "Buscar folio"
        Me.btn_buscar_folio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar_folio.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gb_opciones_doc)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.tab_opciones)
        Me.GroupBox3.Controls.Add(Me.tb_total)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.tb_impuestos)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.tb_descuento)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.tb_subtotal)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(388, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(594, 657)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informacion"
        '
        'gb_opciones_doc
        '
        Me.gb_opciones_doc.Controls.Add(Me.btn_salir)
        Me.gb_opciones_doc.Controls.Add(Me.btn_cancelar_documento)
        Me.gb_opciones_doc.Controls.Add(Me.btn_imprimir_orden)
        Me.gb_opciones_doc.Controls.Add(Me.btn_reimprimir_documento)
        Me.gb_opciones_doc.Location = New System.Drawing.Point(0, 495)
        Me.gb_opciones_doc.Name = "gb_opciones_doc"
        Me.gb_opciones_doc.Size = New System.Drawing.Size(345, 159)
        Me.gb_opciones_doc.TabIndex = 9
        Me.gb_opciones_doc.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.Location = New System.Drawing.Point(192, 91)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(143, 62)
        Me.btn_salir.TabIndex = 10
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_cancelar_documento
        '
        Me.btn_cancelar_documento.BackColor = System.Drawing.Color.White
        Me.btn_cancelar_documento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_documento.Image = CType(resources.GetObject("btn_cancelar_documento.Image"), System.Drawing.Image)
        Me.btn_cancelar_documento.Location = New System.Drawing.Point(192, 15)
        Me.btn_cancelar_documento.Name = "btn_cancelar_documento"
        Me.btn_cancelar_documento.Size = New System.Drawing.Size(143, 72)
        Me.btn_cancelar_documento.TabIndex = 5
        Me.btn_cancelar_documento.Text = "Cancelar operacion"
        Me.btn_cancelar_documento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar_documento.UseVisualStyleBackColor = False
        '
        'btn_imprimir_orden
        '
        Me.btn_imprimir_orden.BackColor = System.Drawing.Color.White
        Me.btn_imprimir_orden.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_orden.Image = CType(resources.GetObject("btn_imprimir_orden.Image"), System.Drawing.Image)
        Me.btn_imprimir_orden.Location = New System.Drawing.Point(6, 88)
        Me.btn_imprimir_orden.Name = "btn_imprimir_orden"
        Me.btn_imprimir_orden.Size = New System.Drawing.Size(180, 68)
        Me.btn_imprimir_orden.TabIndex = 5
        Me.btn_imprimir_orden.Text = "Imprimir orden de entrega"
        Me.btn_imprimir_orden.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_imprimir_orden.UseVisualStyleBackColor = False
        '
        'btn_reimprimir_documento
        '
        Me.btn_reimprimir_documento.BackColor = System.Drawing.Color.White
        Me.btn_reimprimir_documento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimprimir_documento.Image = CType(resources.GetObject("btn_reimprimir_documento.Image"), System.Drawing.Image)
        Me.btn_reimprimir_documento.Location = New System.Drawing.Point(6, 13)
        Me.btn_reimprimir_documento.Name = "btn_reimprimir_documento"
        Me.btn_reimprimir_documento.Size = New System.Drawing.Size(180, 72)
        Me.btn_reimprimir_documento.TabIndex = 5
        Me.btn_reimprimir_documento.Text = "Imprimir documento"
        Me.btn_reimprimir_documento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reimprimir_documento.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.gb_traspaso_recepcion)
        Me.GroupBox5.Controls.Add(Me.gb_traspaso_envio)
        Me.GroupBox5.Controls.Add(Me.gb_datos_compra)
        Me.GroupBox5.Controls.Add(Me.gb_datos_clientes)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.tb_tipo_movimiento)
        Me.GroupBox5.Controls.Add(Me.tb_aviso_cancelado)
        Me.GroupBox5.Controls.Add(Me.dtp_fecha)
        Me.GroupBox5.Controls.Add(Me.dtp_hora)
        Me.GroupBox5.Controls.Add(Me.tb_folio)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(582, 194)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'gb_traspaso_recepcion
        '
        Me.gb_traspaso_recepcion.Controls.Add(Me.tb_estatus_traspaso_recepcion)
        Me.gb_traspaso_recepcion.Controls.Add(Me.Label25)
        Me.gb_traspaso_recepcion.Controls.Add(Me.Label28)
        Me.gb_traspaso_recepcion.Controls.Add(Me.Label26)
        Me.gb_traspaso_recepcion.Controls.Add(Me.tb_recibio_traspaso)
        Me.gb_traspaso_recepcion.Controls.Add(Me.tb_sucursal_origen_traspaso)
        Me.gb_traspaso_recepcion.Location = New System.Drawing.Point(4, 82)
        Me.gb_traspaso_recepcion.Name = "gb_traspaso_recepcion"
        Me.gb_traspaso_recepcion.Size = New System.Drawing.Size(570, 106)
        Me.gb_traspaso_recepcion.TabIndex = 5
        Me.gb_traspaso_recepcion.TabStop = False
        '
        'tb_estatus_traspaso_recepcion
        '
        Me.tb_estatus_traspaso_recepcion.Location = New System.Drawing.Point(120, 72)
        Me.tb_estatus_traspaso_recepcion.Name = "tb_estatus_traspaso_recepcion"
        Me.tb_estatus_traspaso_recepcion.ReadOnly = True
        Me.tb_estatus_traspaso_recepcion.Size = New System.Drawing.Size(222, 23)
        Me.tb_estatus_traspaso_recepcion.TabIndex = 7
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(54, 75)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 17)
        Me.Label25.TabIndex = 8
        Me.Label25.Text = "Estatus:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(54, 49)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 17)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "Recibío:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(6, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(108, 17)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Sucursal origen:"
        '
        'tb_recibio_traspaso
        '
        Me.tb_recibio_traspaso.Location = New System.Drawing.Point(121, 43)
        Me.tb_recibio_traspaso.Name = "tb_recibio_traspaso"
        Me.tb_recibio_traspaso.ReadOnly = True
        Me.tb_recibio_traspaso.Size = New System.Drawing.Size(436, 23)
        Me.tb_recibio_traspaso.TabIndex = 3
        '
        'tb_sucursal_origen_traspaso
        '
        Me.tb_sucursal_origen_traspaso.Location = New System.Drawing.Point(120, 15)
        Me.tb_sucursal_origen_traspaso.Name = "tb_sucursal_origen_traspaso"
        Me.tb_sucursal_origen_traspaso.ReadOnly = True
        Me.tb_sucursal_origen_traspaso.Size = New System.Drawing.Size(437, 23)
        Me.tb_sucursal_origen_traspaso.TabIndex = 3
        '
        'gb_traspaso_envio
        '
        Me.gb_traspaso_envio.Controls.Add(Me.tb_estatus_traspaso_envio)
        Me.gb_traspaso_envio.Controls.Add(Me.Label24)
        Me.gb_traspaso_envio.Controls.Add(Me.Label29)
        Me.gb_traspaso_envio.Controls.Add(Me.Label27)
        Me.gb_traspaso_envio.Controls.Add(Me.tb_empleado_traspaso_envio)
        Me.gb_traspaso_envio.Controls.Add(Me.tb_sucursal_destino_traspaso)
        Me.gb_traspaso_envio.Location = New System.Drawing.Point(7, 78)
        Me.gb_traspaso_envio.Name = "gb_traspaso_envio"
        Me.gb_traspaso_envio.Size = New System.Drawing.Size(570, 129)
        Me.gb_traspaso_envio.TabIndex = 5
        Me.gb_traspaso_envio.TabStop = False
        '
        'tb_estatus_traspaso_envio
        '
        Me.tb_estatus_traspaso_envio.Location = New System.Drawing.Point(122, 73)
        Me.tb_estatus_traspaso_envio.Name = "tb_estatus_traspaso_envio"
        Me.tb_estatus_traspaso_envio.ReadOnly = True
        Me.tb_estatus_traspaso_envio.Size = New System.Drawing.Size(222, 23)
        Me.tb_estatus_traspaso_envio.TabIndex = 7
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(64, 75)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 17)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "Estatus:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(61, 45)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 17)
        Me.Label29.TabIndex = 6
        Me.Label29.Text = "Realizó:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(114, 17)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "Sucursal destino:"
        '
        'tb_empleado_traspaso_envio
        '
        Me.tb_empleado_traspaso_envio.Location = New System.Drawing.Point(122, 42)
        Me.tb_empleado_traspaso_envio.Name = "tb_empleado_traspaso_envio"
        Me.tb_empleado_traspaso_envio.ReadOnly = True
        Me.tb_empleado_traspaso_envio.Size = New System.Drawing.Size(435, 23)
        Me.tb_empleado_traspaso_envio.TabIndex = 3
        '
        'tb_sucursal_destino_traspaso
        '
        Me.tb_sucursal_destino_traspaso.Location = New System.Drawing.Point(122, 15)
        Me.tb_sucursal_destino_traspaso.Name = "tb_sucursal_destino_traspaso"
        Me.tb_sucursal_destino_traspaso.ReadOnly = True
        Me.tb_sucursal_destino_traspaso.Size = New System.Drawing.Size(435, 23)
        Me.tb_sucursal_destino_traspaso.TabIndex = 3
        '
        'gb_datos_compra
        '
        Me.gb_datos_compra.Controls.Add(Me.tb_estatus_compra)
        Me.gb_datos_compra.Controls.Add(Me.Label23)
        Me.gb_datos_compra.Controls.Add(Me.Label21)
        Me.gb_datos_compra.Controls.Add(Me.Label20)
        Me.gb_datos_compra.Controls.Add(Me.Label19)
        Me.gb_datos_compra.Controls.Add(Me.tb_remision)
        Me.gb_datos_compra.Controls.Add(Me.tb_proveedor)
        Me.gb_datos_compra.Controls.Add(Me.dtp_fecha_remision)
        Me.gb_datos_compra.Controls.Add(Me.tb_persona_recibe)
        Me.gb_datos_compra.Controls.Add(Me.Label22)
        Me.gb_datos_compra.Location = New System.Drawing.Point(7, 78)
        Me.gb_datos_compra.Name = "gb_datos_compra"
        Me.gb_datos_compra.Size = New System.Drawing.Size(570, 129)
        Me.gb_datos_compra.TabIndex = 5
        Me.gb_datos_compra.TabStop = False
        '
        'tb_estatus_compra
        '
        Me.tb_estatus_compra.Location = New System.Drawing.Point(335, 102)
        Me.tb_estatus_compra.Name = "tb_estatus_compra"
        Me.tb_estatus_compra.ReadOnly = True
        Me.tb_estatus_compra.Size = New System.Drawing.Size(222, 23)
        Me.tb_estatus_compra.TabIndex = 7
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(269, 105)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(52, 17)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "Estatus"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 79)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 17)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Remisión:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 46)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(79, 17)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Proveedor:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 17)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Recibió:"
        '
        'tb_remision
        '
        Me.tb_remision.Location = New System.Drawing.Point(91, 73)
        Me.tb_remision.Name = "tb_remision"
        Me.tb_remision.ReadOnly = True
        Me.tb_remision.Size = New System.Drawing.Size(114, 23)
        Me.tb_remision.TabIndex = 3
        '
        'tb_proveedor
        '
        Me.tb_proveedor.Location = New System.Drawing.Point(91, 44)
        Me.tb_proveedor.Name = "tb_proveedor"
        Me.tb_proveedor.ReadOnly = True
        Me.tb_proveedor.Size = New System.Drawing.Size(466, 23)
        Me.tb_proveedor.TabIndex = 3
        '
        'dtp_fecha_remision
        '
        Me.dtp_fecha_remision.Enabled = False
        Me.dtp_fecha_remision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_remision.Location = New System.Drawing.Point(335, 73)
        Me.dtp_fecha_remision.Name = "dtp_fecha_remision"
        Me.dtp_fecha_remision.Size = New System.Drawing.Size(222, 23)
        Me.dtp_fecha_remision.TabIndex = 3
        '
        'tb_persona_recibe
        '
        Me.tb_persona_recibe.Location = New System.Drawing.Point(91, 15)
        Me.tb_persona_recibe.Name = "tb_persona_recibe"
        Me.tb_persona_recibe.ReadOnly = True
        Me.tb_persona_recibe.Size = New System.Drawing.Size(466, 23)
        Me.tb_persona_recibe.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(221, 76)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(108, 17)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Fecha remisión:"
        '
        'gb_datos_clientes
        '
        Me.gb_datos_clientes.Controls.Add(Me.Label6)
        Me.gb_datos_clientes.Controls.Add(Me.tb_cliente)
        Me.gb_datos_clientes.Controls.Add(Me.Label14)
        Me.gb_datos_clientes.Controls.Add(Me.Label7)
        Me.gb_datos_clientes.Controls.Add(Me.tb_direccion)
        Me.gb_datos_clientes.Controls.Add(Me.tb_estatus)
        Me.gb_datos_clientes.Controls.Add(Me.Label15)
        Me.gb_datos_clientes.Controls.Add(Me.tb_vendedor)
        Me.gb_datos_clientes.Location = New System.Drawing.Point(8, 80)
        Me.gb_datos_clientes.Name = "gb_datos_clientes"
        Me.gb_datos_clientes.Size = New System.Drawing.Size(568, 123)
        Me.gb_datos_clientes.TabIndex = 9
        Me.gb_datos_clientes.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Cliente:"
        '
        'tb_cliente
        '
        Me.tb_cliente.Location = New System.Drawing.Point(78, 13)
        Me.tb_cliente.Name = "tb_cliente"
        Me.tb_cliente.ReadOnly = True
        Me.tb_cliente.Size = New System.Drawing.Size(483, 23)
        Me.tb_cliente.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(0, 95)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 17)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Vendedor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Direccion:"
        '
        'tb_direccion
        '
        Me.tb_direccion.Location = New System.Drawing.Point(78, 40)
        Me.tb_direccion.Multiline = True
        Me.tb_direccion.Name = "tb_direccion"
        Me.tb_direccion.ReadOnly = True
        Me.tb_direccion.Size = New System.Drawing.Size(483, 48)
        Me.tb_direccion.TabIndex = 3
        '
        'tb_estatus
        '
        Me.tb_estatus.Location = New System.Drawing.Point(429, 93)
        Me.tb_estatus.Name = "tb_estatus"
        Me.tb_estatus.ReadOnly = True
        Me.tb_estatus.Size = New System.Drawing.Size(132, 23)
        Me.tb_estatus.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(363, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 17)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Estatus"
        '
        'tb_vendedor
        '
        Me.tb_vendedor.Location = New System.Drawing.Point(78, 94)
        Me.tb_vendedor.Name = "tb_vendedor"
        Me.tb_vendedor.ReadOnly = True
        Me.tb_vendedor.Size = New System.Drawing.Size(279, 23)
        Me.tb_vendedor.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 17)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Folio:"
        '
        'tb_tipo_movimiento
        '
        Me.tb_tipo_movimiento.AutoSize = True
        Me.tb_tipo_movimiento.BackColor = System.Drawing.Color.Transparent
        Me.tb_tipo_movimiento.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_tipo_movimiento.ForeColor = System.Drawing.Color.Black
        Me.tb_tipo_movimiento.Location = New System.Drawing.Point(11, 19)
        Me.tb_tipo_movimiento.MaximumSize = New System.Drawing.Size(250, 25)
        Me.tb_tipo_movimiento.MinimumSize = New System.Drawing.Size(250, 25)
        Me.tb_tipo_movimiento.Name = "tb_tipo_movimiento"
        Me.tb_tipo_movimiento.Size = New System.Drawing.Size(250, 25)
        Me.tb_tipo_movimiento.TabIndex = 8
        Me.tb_tipo_movimiento.Text = "--"
        Me.tb_tipo_movimiento.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tb_aviso_cancelado
        '
        Me.tb_aviso_cancelado.AutoSize = True
        Me.tb_aviso_cancelado.BackColor = System.Drawing.Color.DarkRed
        Me.tb_aviso_cancelado.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_aviso_cancelado.ForeColor = System.Drawing.Color.White
        Me.tb_aviso_cancelado.Location = New System.Drawing.Point(272, 19)
        Me.tb_aviso_cancelado.MaximumSize = New System.Drawing.Size(300, 25)
        Me.tb_aviso_cancelado.MinimumSize = New System.Drawing.Size(300, 25)
        Me.tb_aviso_cancelado.Name = "tb_aviso_cancelado"
        Me.tb_aviso_cancelado.Size = New System.Drawing.Size(300, 25)
        Me.tb_aviso_cancelado.TabIndex = 8
        Me.tb_aviso_cancelado.Text = "C ANCELADO"
        Me.tb_aviso_cancelado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tb_aviso_cancelado.Visible = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Enabled = False
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(267, 56)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(123, 23)
        Me.dtp_fecha.TabIndex = 3
        '
        'dtp_hora
        '
        Me.dtp_hora.Enabled = False
        Me.dtp_hora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_hora.Location = New System.Drawing.Point(444, 53)
        Me.dtp_hora.Name = "dtp_hora"
        Me.dtp_hora.Size = New System.Drawing.Size(123, 23)
        Me.dtp_hora.TabIndex = 3
        '
        'tb_folio
        '
        Me.tb_folio.Location = New System.Drawing.Point(84, 56)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.ReadOnly = True
        Me.tb_folio.Size = New System.Drawing.Size(107, 23)
        Me.tb_folio.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(210, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 17)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Fecha:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(400, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 17)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Hora:"
        '
        'tab_opciones
        '
        Me.tab_opciones.Controls.Add(Me.tab_productos)
        Me.tab_opciones.Controls.Add(Me.tab_pagos)
        Me.tab_opciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_opciones.Location = New System.Drawing.Point(9, 216)
        Me.tab_opciones.Name = "tab_opciones"
        Me.tab_opciones.SelectedIndex = 0
        Me.tab_opciones.Size = New System.Drawing.Size(576, 273)
        Me.tab_opciones.TabIndex = 7
        '
        'tab_productos
        '
        Me.tab_productos.Controls.Add(Me.dgv_producto_cancelacion)
        Me.tab_productos.Location = New System.Drawing.Point(4, 26)
        Me.tab_productos.Name = "tab_productos"
        Me.tab_productos.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_productos.Size = New System.Drawing.Size(568, 243)
        Me.tab_productos.TabIndex = 0
        Me.tab_productos.Text = "Productos"
        Me.tab_productos.UseVisualStyleBackColor = True
        '
        'dgv_producto_cancelacion
        '
        Me.dgv_producto_cancelacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_producto_cancelacion.Location = New System.Drawing.Point(4, 6)
        Me.dgv_producto_cancelacion.MultiSelect = False
        Me.dgv_producto_cancelacion.Name = "dgv_producto_cancelacion"
        Me.dgv_producto_cancelacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_producto_cancelacion.Size = New System.Drawing.Size(558, 227)
        Me.dgv_producto_cancelacion.TabIndex = 0
        '
        'tab_pagos
        '
        Me.tab_pagos.Controls.Add(Me.lbl_saldo)
        Me.tab_pagos.Controls.Add(Me.gb_opciones_pagos)
        Me.tab_pagos.Controls.Add(Me.lbl_cobros)
        Me.tab_pagos.Controls.Add(Me.Label17)
        Me.tab_pagos.Controls.Add(Me.dgv_abonos)
        Me.tab_pagos.Controls.Add(Me.Label18)
        Me.tab_pagos.Location = New System.Drawing.Point(4, 26)
        Me.tab_pagos.Name = "tab_pagos"
        Me.tab_pagos.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_pagos.Size = New System.Drawing.Size(568, 243)
        Me.tab_pagos.TabIndex = 1
        Me.tab_pagos.Text = "Pagos"
        Me.tab_pagos.UseVisualStyleBackColor = True
        '
        'lbl_saldo
        '
        Me.lbl_saldo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo.Location = New System.Drawing.Point(461, 205)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.ReadOnly = True
        Me.lbl_saldo.Size = New System.Drawing.Size(101, 27)
        Me.lbl_saldo.TabIndex = 13
        Me.lbl_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gb_opciones_pagos
        '
        Me.gb_opciones_pagos.Controls.Add(Me.btn_imprimir_abono)
        Me.gb_opciones_pagos.Controls.Add(Me.btn_cancelar_abono)
        Me.gb_opciones_pagos.Location = New System.Drawing.Point(6, 173)
        Me.gb_opciones_pagos.Name = "gb_opciones_pagos"
        Me.gb_opciones_pagos.Size = New System.Drawing.Size(315, 63)
        Me.gb_opciones_pagos.TabIndex = 10
        Me.gb_opciones_pagos.TabStop = False
        '
        'btn_imprimir_abono
        '
        Me.btn_imprimir_abono.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_abono.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_imprimir_abono.Location = New System.Drawing.Point(6, 15)
        Me.btn_imprimir_abono.Name = "btn_imprimir_abono"
        Me.btn_imprimir_abono.Size = New System.Drawing.Size(138, 39)
        Me.btn_imprimir_abono.TabIndex = 9
        Me.btn_imprimir_abono.Text = "Imprimir recibo"
        Me.btn_imprimir_abono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_imprimir_abono.UseVisualStyleBackColor = True
        '
        'btn_cancelar_abono
        '
        Me.btn_cancelar_abono.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_abono.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cancelar_abono.Location = New System.Drawing.Point(150, 15)
        Me.btn_cancelar_abono.Name = "btn_cancelar_abono"
        Me.btn_cancelar_abono.Size = New System.Drawing.Size(141, 39)
        Me.btn_cancelar_abono.TabIndex = 9
        Me.btn_cancelar_abono.Text = "Cancelar pago"
        Me.btn_cancelar_abono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar_abono.UseVisualStyleBackColor = True
        '
        'lbl_cobros
        '
        Me.lbl_cobros.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cobros.Location = New System.Drawing.Point(461, 172)
        Me.lbl_cobros.Name = "lbl_cobros"
        Me.lbl_cobros.ReadOnly = True
        Me.lbl_cobros.Size = New System.Drawing.Size(101, 27)
        Me.lbl_cobros.TabIndex = 14
        Me.lbl_cobros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(347, 178)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 21)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Totol pagos:"
        '
        'dgv_abonos
        '
        Me.dgv_abonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_abonos.Location = New System.Drawing.Point(6, 6)
        Me.dgv_abonos.MultiSelect = False
        Me.dgv_abonos.Name = "dgv_abonos"
        Me.dgv_abonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_abonos.Size = New System.Drawing.Size(556, 161)
        Me.dgv_abonos.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(398, 211)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(57, 21)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Saldo:"
        '
        'tb_total
        '
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(438, 586)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(140, 31)
        Me.tb_total.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(376, 594)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 23)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Total:"
        '
        'tb_impuestos
        '
        Me.tb_impuestos.Location = New System.Drawing.Point(438, 559)
        Me.tb_impuestos.Name = "tb_impuestos"
        Me.tb_impuestos.ReadOnly = True
        Me.tb_impuestos.Size = New System.Drawing.Size(140, 23)
        Me.tb_impuestos.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(357, 564)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 17)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Impuestos:"
        '
        'tb_descuento
        '
        Me.tb_descuento.Location = New System.Drawing.Point(438, 531)
        Me.tb_descuento.Name = "tb_descuento"
        Me.tb_descuento.ReadOnly = True
        Me.tb_descuento.Size = New System.Drawing.Size(140, 23)
        Me.tb_descuento.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(351, 537)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 17)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "- Decuento:"
        '
        'tb_subtotal
        '
        Me.tb_subtotal.Location = New System.Drawing.Point(438, 503)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.ReadOnly = True
        Me.tb_subtotal.Size = New System.Drawing.Size(140, 23)
        Me.tb_subtotal.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(369, 509)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 17)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Subtotal:"
        '
        'rb_buscar_traspaso_recep
        '
        Me.rb_buscar_traspaso_recep.AutoSize = True
        Me.rb_buscar_traspaso_recep.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_traspaso_recep.Location = New System.Drawing.Point(237, 101)
        Me.rb_buscar_traspaso_recep.Name = "rb_buscar_traspaso_recep"
        Me.rb_buscar_traspaso_recep.Size = New System.Drawing.Size(135, 21)
        Me.rb_buscar_traspaso_recep.TabIndex = 4
        Me.rb_buscar_traspaso_recep.Text = "Traspaso (Recep)"
        Me.rb_buscar_traspaso_recep.UseVisualStyleBackColor = True
        '
        'rb_buscar_traspaso_env
        '
        Me.rb_buscar_traspaso_env.AutoSize = True
        Me.rb_buscar_traspaso_env.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_traspaso_env.Location = New System.Drawing.Point(99, 102)
        Me.rb_buscar_traspaso_env.Name = "rb_buscar_traspaso_env"
        Me.rb_buscar_traspaso_env.Size = New System.Drawing.Size(130, 21)
        Me.rb_buscar_traspaso_env.TabIndex = 4
        Me.rb_buscar_traspaso_env.Text = "Traspaso (envío)"
        Me.rb_buscar_traspaso_env.UseVisualStyleBackColor = True
        '
        'rb_buscar_compra
        '
        Me.rb_buscar_compra.AutoSize = True
        Me.rb_buscar_compra.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_compra.Location = New System.Drawing.Point(10, 102)
        Me.rb_buscar_compra.Name = "rb_buscar_compra"
        Me.rb_buscar_compra.Size = New System.Drawing.Size(86, 21)
        Me.rb_buscar_compra.TabIndex = 4
        Me.rb_buscar_compra.Text = "Compras"
        Me.rb_buscar_compra.UseVisualStyleBackColor = True
        '
        'rb_buscar_credito
        '
        Me.rb_buscar_credito.AutoSize = True
        Me.rb_buscar_credito.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_credito.Location = New System.Drawing.Point(272, 74)
        Me.rb_buscar_credito.Name = "rb_buscar_credito"
        Me.rb_buscar_credito.Size = New System.Drawing.Size(80, 21)
        Me.rb_buscar_credito.TabIndex = 4
        Me.rb_buscar_credito.Text = "Creditos"
        Me.rb_buscar_credito.UseVisualStyleBackColor = True
        '
        'rb_buscar_apartado
        '
        Me.rb_buscar_apartado.AutoSize = True
        Me.rb_buscar_apartado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_apartado.Location = New System.Drawing.Point(177, 75)
        Me.rb_buscar_apartado.Name = "rb_buscar_apartado"
        Me.rb_buscar_apartado.Size = New System.Drawing.Size(89, 21)
        Me.rb_buscar_apartado.TabIndex = 4
        Me.rb_buscar_apartado.Text = "Apartado"
        Me.rb_buscar_apartado.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 20)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Folio"
        '
        'rb_buscar_pedido
        '
        Me.rb_buscar_pedido.AutoSize = True
        Me.rb_buscar_pedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_pedido.Location = New System.Drawing.Point(99, 75)
        Me.rb_buscar_pedido.Name = "rb_buscar_pedido"
        Me.rb_buscar_pedido.Size = New System.Drawing.Size(72, 21)
        Me.rb_buscar_pedido.TabIndex = 4
        Me.rb_buscar_pedido.Text = "Pedido"
        Me.rb_buscar_pedido.UseVisualStyleBackColor = True
        '
        'rb_buscar_nota
        '
        Me.rb_buscar_nota.AutoSize = True
        Me.rb_buscar_nota.Checked = True
        Me.rb_buscar_nota.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_buscar_nota.Location = New System.Drawing.Point(10, 72)
        Me.rb_buscar_nota.MinimumSize = New System.Drawing.Size(100, 30)
        Me.rb_buscar_nota.Name = "rb_buscar_nota"
        Me.rb_buscar_nota.Size = New System.Drawing.Size(100, 30)
        Me.rb_buscar_nota.TabIndex = 4
        Me.rb_buscar_nota.TabStop = True
        Me.rb_buscar_nota.Text = "Ventas"
        Me.rb_buscar_nota.UseVisualStyleBackColor = True
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'Frm_cancelaciones
        '
        Me.AcceptButton = Me.btn_buscar_folio
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 687)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_cancelaciones"
        Me.Text = "Cancelaciones"
        Me.gb_busqueda.ResumeLayout(False)
        Me.gb_busqueda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gb_opciones_doc.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gb_traspaso_recepcion.ResumeLayout(False)
        Me.gb_traspaso_recepcion.PerformLayout()
        Me.gb_traspaso_envio.ResumeLayout(False)
        Me.gb_traspaso_envio.PerformLayout()
        Me.gb_datos_compra.ResumeLayout(False)
        Me.gb_datos_compra.PerformLayout()
        Me.gb_datos_clientes.ResumeLayout(False)
        Me.gb_datos_clientes.PerformLayout()
        Me.tab_opciones.ResumeLayout(False)
        Me.tab_productos.ResumeLayout(False)
        CType(Me.dgv_producto_cancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_pagos.ResumeLayout(False)
        Me.tab_pagos.PerformLayout()
        Me.gb_opciones_pagos.ResumeLayout(False)
        CType(Me.dgv_abonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_busqueda As System.Windows.Forms.GroupBox
    Friend WithEvents cb_opciones_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_busqueda As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_folio_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_busqueda As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_cliente_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_direccion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_folio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_cancelar_documento As System.Windows.Forms.Button
    Friend WithEvents btn_reimprimir_documento As System.Windows.Forms.Button
    Friend WithEvents rb_buscar_apartado As System.Windows.Forms.RadioButton
    Friend WithEvents rb_buscar_pedido As System.Windows.Forms.RadioButton
    Friend WithEvents rb_buscar_nota As System.Windows.Forms.RadioButton
    Friend WithEvents tab_opciones As System.Windows.Forms.TabControl
    Friend WithEvents tab_productos As System.Windows.Forms.TabPage
    Friend WithEvents tab_pagos As System.Windows.Forms.TabPage
    Friend WithEvents gb_opciones_pagos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir_abono As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar_abono As System.Windows.Forms.Button
    Friend WithEvents dgv_abonos As System.Windows.Forms.DataGridView
    Friend WithEvents tb_descuento As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_hora As System.Windows.Forms.DateTimePicker
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tb_estatus As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents tb_aviso_cancelado As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir_orden As System.Windows.Forms.Button
    Friend WithEvents btn_buscar_folio As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents tb_tipo_movimiento As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents lbl_saldo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cobros As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dgv_producto_cancelacion As System.Windows.Forms.DataGridView
    Friend WithEvents rb_buscar_traspaso_env As System.Windows.Forms.RadioButton
    Friend WithEvents rb_buscar_compra As System.Windows.Forms.RadioButton
    Friend WithEvents rb_buscar_traspaso_recep As System.Windows.Forms.RadioButton
    Friend WithEvents gb_datos_clientes As System.Windows.Forms.GroupBox
    Friend WithEvents gb_datos_compra As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tb_proveedor As System.Windows.Forms.TextBox
    Friend WithEvents tb_persona_recibe As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_remision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tb_remision As System.Windows.Forms.TextBox
    Friend WithEvents tb_estatus_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents rb_buscar_credito As System.Windows.Forms.RadioButton
    Friend WithEvents gb_traspaso_recepcion As System.Windows.Forms.GroupBox
    Friend WithEvents tb_estatus_traspaso_recepcion As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tb_recibio_traspaso As System.Windows.Forms.TextBox
    Friend WithEvents tb_sucursal_origen_traspaso As System.Windows.Forms.TextBox
    Friend WithEvents gb_traspaso_envio As System.Windows.Forms.GroupBox
    Friend WithEvents tb_estatus_traspaso_envio As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tb_sucursal_destino_traspaso As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tb_empleado_traspaso_envio As System.Windows.Forms.TextBox
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents gb_opciones_doc As GroupBox
End Class
