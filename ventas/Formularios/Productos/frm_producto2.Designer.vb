<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_producto2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_producto2))
        Me.lst_productos = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.cb_categoria_busqueda = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tab_producto = New System.Windows.Forms.TabControl()
        Me.tab_informacion = New System.Windows.Forms.TabPage()
        Me.gb_insumo = New System.Windows.Forms.GroupBox()
        Me.cb_clavesat = New System.Windows.Forms.ComboBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtp_final_oferta = New System.Windows.Forms.DateTimePicker()
        Me.dtp_inicial_oferta = New System.Windows.Forms.DateTimePicker()
        Me.tb_especial = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.chb_venta_peso = New System.Windows.Forms.CheckBox()
        Me.pb_imagen = New System.Windows.Forms.PictureBox()
        Me.btn_eliminar_imagen = New System.Windows.Forms.Button()
        Me.btn_agregar_imagen = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cb_color = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_talla = New System.Windows.Forms.ComboBox()
        Me.cb_marca = New System.Windows.Forms.ComboBox()
        Me.cb_modelo = New System.Windows.Forms.ComboBox()
        Me.cb_almacen = New System.Windows.Forms.ComboBox()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.cb_unidad = New System.Windows.Forms.ComboBox()
        Me.cb_categoria = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_impuesto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_descripcion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.tb_stock_maximo = New System.Windows.Forms.TextBox()
        Me.tb_precio_venta = New System.Windows.Forms.TextBox()
        Me.tb_precio_compra = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_stock_minimo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tab_precios = New System.Windows.Forms.TabPage()
        Me.dgv_precios = New System.Windows.Forms.DataGridView()
        Me.tab_compuesto = New System.Windows.Forms.TabPage()
        Me.btn_eliminar_modificador = New System.Windows.Forms.Button()
        Me.btn_eliminar_prdct_modificador = New System.Windows.Forms.Button()
        Me.btn_agregar_prdct_modificador = New System.Windows.Forms.Button()
        Me.btn_agregar_modificador = New System.Windows.Forms.Button()
        Me.dgv_productos_modificadores = New System.Windows.Forms.DataGridView()
        Me.dgv_modificadores = New System.Windows.Forms.DataGridView()
        Me.tab_conversiones = New System.Windows.Forms.TabPage()
        Me.ofd_foto = New System.Windows.Forms.OpenFileDialog()
        Me.gb_productos = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_total_paginas = New System.Windows.Forms.Label()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.tab_producto.SuspendLayout()
        Me.tab_informacion.SuspendLayout()
        Me.gb_insumo.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_precios.SuspendLayout()
        CType(Me.dgv_precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_compuesto.SuspendLayout()
        CType(Me.dgv_productos_modificadores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_modificadores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_productos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lst_productos
        '
        Me.lst_productos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lst_productos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_productos.GridLines = True
        Me.lst_productos.HoverSelection = True
        Me.lst_productos.Location = New System.Drawing.Point(4, 94)
        Me.lst_productos.MultiSelect = False
        Me.lst_productos.Name = "lst_productos"
        Me.lst_productos.Size = New System.Drawing.Size(413, 477)
        Me.lst_productos.TabIndex = 0
        Me.lst_productos.UseCompatibleStateImageBehavior = False
        Me.lst_productos.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_eliminar)
        Me.GroupBox1.Controls.Add(Me.btn_deshacer)
        Me.GroupBox1.Controls.Add(Me.btn_editar)
        Me.GroupBox1.Location = New System.Drawing.Point(434, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(466, 103)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(4, 19)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(76, 74)
        Me.btn_nuevo.TabIndex = 4
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Enabled = False
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(384, 19)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(76, 74)
        Me.btn_salir.TabIndex = 10
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(81, 19)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(76, 74)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.Location = New System.Drawing.Point(309, 19)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(76, 74)
        Me.btn_eliminar.TabIndex = 6
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_deshacer
        '
        Me.btn_deshacer.Enabled = False
        Me.btn_deshacer.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deshacer.Image = CType(resources.GetObject("btn_deshacer.Image"), System.Drawing.Image)
        Me.btn_deshacer.Location = New System.Drawing.Point(157, 19)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(76, 74)
        Me.btn_deshacer.TabIndex = 5
        Me.btn_deshacer.Text = "Deshacer"
        Me.btn_deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_deshacer.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Location = New System.Drawing.Point(234, 19)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(76, 74)
        Me.btn_editar.TabIndex = 6
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'cb_categoria_busqueda
        '
        Me.cb_categoria_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_categoria_busqueda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_categoria_busqueda.FormattingEnabled = True
        Me.cb_categoria_busqueda.Location = New System.Drawing.Point(86, 22)
        Me.cb_categoria_busqueda.Name = "cb_categoria_busqueda"
        Me.cb_categoria_busqueda.Size = New System.Drawing.Size(249, 25)
        Me.cb_categoria_busqueda.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Categoria:"
        '
        'tab_producto
        '
        Me.tab_producto.Controls.Add(Me.tab_informacion)
        Me.tab_producto.Controls.Add(Me.tab_precios)
        Me.tab_producto.Controls.Add(Me.tab_compuesto)
        Me.tab_producto.Controls.Add(Me.tab_conversiones)
        Me.tab_producto.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_producto.Location = New System.Drawing.Point(435, 114)
        Me.tab_producto.Name = "tab_producto"
        Me.tab_producto.SelectedIndex = 0
        Me.tab_producto.Size = New System.Drawing.Size(567, 550)
        Me.tab_producto.TabIndex = 15
        '
        'tab_informacion
        '
        Me.tab_informacion.Controls.Add(Me.gb_insumo)
        Me.tab_informacion.Location = New System.Drawing.Point(4, 25)
        Me.tab_informacion.Name = "tab_informacion"
        Me.tab_informacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_informacion.Size = New System.Drawing.Size(559, 521)
        Me.tab_informacion.TabIndex = 0
        Me.tab_informacion.Text = "Información General"
        Me.tab_informacion.UseVisualStyleBackColor = True
        '
        'gb_insumo
        '
        Me.gb_insumo.Controls.Add(Me.cb_clavesat)
        Me.gb_insumo.Controls.Add(Me.GroupBox9)
        Me.gb_insumo.Controls.Add(Me.chb_venta_peso)
        Me.gb_insumo.Controls.Add(Me.pb_imagen)
        Me.gb_insumo.Controls.Add(Me.btn_eliminar_imagen)
        Me.gb_insumo.Controls.Add(Me.btn_agregar_imagen)
        Me.gb_insumo.Controls.Add(Me.Button8)
        Me.gb_insumo.Controls.Add(Me.Button4)
        Me.gb_insumo.Controls.Add(Me.Button3)
        Me.gb_insumo.Controls.Add(Me.Label1)
        Me.gb_insumo.Controls.Add(Me.Button2)
        Me.gb_insumo.Controls.Add(Me.cb_color)
        Me.gb_insumo.Controls.Add(Me.Label2)
        Me.gb_insumo.Controls.Add(Me.cb_talla)
        Me.gb_insumo.Controls.Add(Me.cb_marca)
        Me.gb_insumo.Controls.Add(Me.cb_modelo)
        Me.gb_insumo.Controls.Add(Me.cb_almacen)
        Me.gb_insumo.Controls.Add(Me.tb_codigo)
        Me.gb_insumo.Controls.Add(Me.cb_unidad)
        Me.gb_insumo.Controls.Add(Me.cb_categoria)
        Me.gb_insumo.Controls.Add(Me.Label17)
        Me.gb_insumo.Controls.Add(Me.Label12)
        Me.gb_insumo.Controls.Add(Me.Label3)
        Me.gb_insumo.Controls.Add(Me.Label9)
        Me.gb_insumo.Controls.Add(Me.Label4)
        Me.gb_insumo.Controls.Add(Me.cb_impuesto)
        Me.gb_insumo.Controls.Add(Me.Label8)
        Me.gb_insumo.Controls.Add(Me.Label5)
        Me.gb_insumo.Controls.Add(Me.tb_descripcion)
        Me.gb_insumo.Controls.Add(Me.Label6)
        Me.gb_insumo.Controls.Add(Me.tb_nombre)
        Me.gb_insumo.Controls.Add(Me.tb_stock_maximo)
        Me.gb_insumo.Controls.Add(Me.tb_precio_venta)
        Me.gb_insumo.Controls.Add(Me.tb_precio_compra)
        Me.gb_insumo.Controls.Add(Me.Label21)
        Me.gb_insumo.Controls.Add(Me.Label10)
        Me.gb_insumo.Controls.Add(Me.Label16)
        Me.gb_insumo.Controls.Add(Me.tb_stock_minimo)
        Me.gb_insumo.Controls.Add(Me.Label15)
        Me.gb_insumo.Controls.Add(Me.Label14)
        Me.gb_insumo.Controls.Add(Me.Label7)
        Me.gb_insumo.Enabled = False
        Me.gb_insumo.Location = New System.Drawing.Point(6, 3)
        Me.gb_insumo.Name = "gb_insumo"
        Me.gb_insumo.Size = New System.Drawing.Size(547, 514)
        Me.gb_insumo.TabIndex = 26
        Me.gb_insumo.TabStop = False
        '
        'cb_clavesat
        '
        Me.cb_clavesat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_clavesat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_clavesat.FormattingEnabled = True
        Me.cb_clavesat.Location = New System.Drawing.Point(153, 182)
        Me.cb_clavesat.Name = "cb_clavesat"
        Me.cb_clavesat.Size = New System.Drawing.Size(149, 24)
        Me.cb_clavesat.TabIndex = 29
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label13)
        Me.GroupBox9.Controls.Add(Me.Label18)
        Me.GroupBox9.Controls.Add(Me.dtp_final_oferta)
        Me.GroupBox9.Controls.Add(Me.dtp_inicial_oferta)
        Me.GroupBox9.Controls.Add(Me.tb_especial)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 428)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(366, 79)
        Me.GroupBox9.TabIndex = 28
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Óferta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(230, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(19, 16)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "al"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(19, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(27, 16)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Del"
        '
        'dtp_final_oferta
        '
        Me.dtp_final_oferta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_final_oferta.Location = New System.Drawing.Point(255, 45)
        Me.dtp_final_oferta.Name = "dtp_final_oferta"
        Me.dtp_final_oferta.Size = New System.Drawing.Size(101, 22)
        Me.dtp_final_oferta.TabIndex = 20
        '
        'dtp_inicial_oferta
        '
        Me.dtp_inicial_oferta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicial_oferta.Location = New System.Drawing.Point(124, 45)
        Me.dtp_inicial_oferta.Name = "dtp_inicial_oferta"
        Me.dtp_inicial_oferta.Size = New System.Drawing.Size(100, 22)
        Me.dtp_inicial_oferta.TabIndex = 19
        '
        'tb_especial
        '
        Me.tb_especial.Location = New System.Drawing.Point(124, 15)
        Me.tb_especial.MaxLength = 10
        Me.tb_especial.Name = "tb_especial"
        Me.tb_especial.Size = New System.Drawing.Size(101, 22)
        Me.tb_especial.TabIndex = 18
        Me.tb_especial.Text = "0.00"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(19, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 16)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Precio"
        '
        'chb_venta_peso
        '
        Me.chb_venta_peso.AutoSize = True
        Me.chb_venta_peso.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_venta_peso.Location = New System.Drawing.Point(413, 168)
        Me.chb_venta_peso.Name = "chb_venta_peso"
        Me.chb_venta_peso.Size = New System.Drawing.Size(137, 20)
        Me.chb_venta_peso.TabIndex = 27
        Me.chb_venta_peso.Text = "Se vende por peso"
        Me.chb_venta_peso.UseVisualStyleBackColor = True
        '
        'pb_imagen
        '
        Me.pb_imagen.BackgroundImage = CType(resources.GetObject("pb_imagen.BackgroundImage"), System.Drawing.Image)
        Me.pb_imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pb_imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_imagen.Location = New System.Drawing.Point(343, 194)
        Me.pb_imagen.Name = "pb_imagen"
        Me.pb_imagen.Size = New System.Drawing.Size(190, 190)
        Me.pb_imagen.TabIndex = 26
        Me.pb_imagen.TabStop = False
        '
        'btn_eliminar_imagen
        '
        Me.btn_eliminar_imagen.BackColor = System.Drawing.Color.Red
        Me.btn_eliminar_imagen.ForeColor = System.Drawing.Color.White
        Me.btn_eliminar_imagen.Location = New System.Drawing.Point(446, 390)
        Me.btn_eliminar_imagen.Name = "btn_eliminar_imagen"
        Me.btn_eliminar_imagen.Size = New System.Drawing.Size(36, 31)
        Me.btn_eliminar_imagen.TabIndex = 25
        Me.btn_eliminar_imagen.Text = "X"
        Me.btn_eliminar_imagen.UseVisualStyleBackColor = False
        '
        'btn_agregar_imagen
        '
        Me.btn_agregar_imagen.BackColor = System.Drawing.Color.Green
        Me.btn_agregar_imagen.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_imagen.ForeColor = System.Drawing.Color.White
        Me.btn_agregar_imagen.Location = New System.Drawing.Point(488, 390)
        Me.btn_agregar_imagen.Name = "btn_agregar_imagen"
        Me.btn_agregar_imagen.Size = New System.Drawing.Size(36, 31)
        Me.btn_agregar_imagen.TabIndex = 25
        Me.btn_agregar_imagen.Text = "+"
        Me.btn_agregar_imagen.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Green
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(308, 254)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(26, 28)
        Me.Button8.TabIndex = 25
        Me.Button8.Text = "+"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Green
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(308, 218)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(26, 28)
        Me.Button4.TabIndex = 25
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Green
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(308, 285)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(26, 28)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "+"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Categoría:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Green
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(308, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 27)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cb_color
        '
        Me.cb_color.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_color.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_color.FormattingEnabled = True
        Me.cb_color.Location = New System.Drawing.Point(413, 125)
        Me.cb_color.Name = "cb_color"
        Me.cb_color.Size = New System.Drawing.Size(120, 24)
        Me.cb_color.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Codigo de Barras:"
        '
        'cb_talla
        '
        Me.cb_talla.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_talla.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_talla.FormattingEnabled = True
        Me.cb_talla.Location = New System.Drawing.Point(413, 91)
        Me.cb_talla.Name = "cb_talla"
        Me.cb_talla.Size = New System.Drawing.Size(120, 24)
        Me.cb_talla.TabIndex = 23
        '
        'cb_marca
        '
        Me.cb_marca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_marca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_marca.FormattingEnabled = True
        Me.cb_marca.Location = New System.Drawing.Point(413, 22)
        Me.cb_marca.Name = "cb_marca"
        Me.cb_marca.Size = New System.Drawing.Size(120, 24)
        Me.cb_marca.TabIndex = 23
        '
        'cb_modelo
        '
        Me.cb_modelo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_modelo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_modelo.FormattingEnabled = True
        Me.cb_modelo.Location = New System.Drawing.Point(413, 57)
        Me.cb_modelo.Name = "cb_modelo"
        Me.cb_modelo.Size = New System.Drawing.Size(120, 24)
        Me.cb_modelo.TabIndex = 23
        '
        'cb_almacen
        '
        Me.cb_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_almacen.FormattingEnabled = True
        Me.cb_almacen.Location = New System.Drawing.Point(130, 254)
        Me.cb_almacen.Name = "cb_almacen"
        Me.cb_almacen.Size = New System.Drawing.Size(172, 24)
        Me.cb_almacen.TabIndex = 23
        '
        'tb_codigo
        '
        Me.tb_codigo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_codigo.Location = New System.Drawing.Point(130, 52)
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(172, 23)
        Me.tb_codigo.TabIndex = 10
        '
        'cb_unidad
        '
        Me.cb_unidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_unidad.FormattingEnabled = True
        Me.cb_unidad.Location = New System.Drawing.Point(130, 220)
        Me.cb_unidad.Name = "cb_unidad"
        Me.cb_unidad.Size = New System.Drawing.Size(172, 24)
        Me.cb_unidad.TabIndex = 23
        '
        'cb_categoria
        '
        Me.cb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_categoria.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_categoria.FormattingEnabled = True
        Me.cb_categoria.Location = New System.Drawing.Point(130, 22)
        Me.cb_categoria.Name = "cb_categoria"
        Me.cb_categoria.Size = New System.Drawing.Size(172, 25)
        Me.cb_categoria.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 132)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 16)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Descripción:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(356, 135)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Color:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nombre:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(352, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Talla:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(352, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Marca:"
        '
        'cb_impuesto
        '
        Me.cb_impuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_impuesto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_impuesto.FormattingEnabled = True
        Me.cb_impuesto.Location = New System.Drawing.Point(130, 288)
        Me.cb_impuesto.Name = "cb_impuesto"
        Me.cb_impuesto.Size = New System.Drawing.Size(172, 25)
        Me.cb_impuesto.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(352, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Modelo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 260)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Almacén:"
        '
        'tb_descripcion
        '
        Me.tb_descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_descripcion.Location = New System.Drawing.Point(130, 125)
        Me.tb_descripcion.Multiline = True
        Me.tb_descripcion.Name = "tb_descripcion"
        Me.tb_descripcion.Size = New System.Drawing.Size(172, 49)
        Me.tb_descripcion.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Unidad:"
        '
        'tb_nombre
        '
        Me.tb_nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre.Location = New System.Drawing.Point(130, 79)
        Me.tb_nombre.Multiline = True
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(172, 40)
        Me.tb_nombre.TabIndex = 13
        '
        'tb_stock_maximo
        '
        Me.tb_stock_maximo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_stock_maximo.Location = New System.Drawing.Point(283, 390)
        Me.tb_stock_maximo.Name = "tb_stock_maximo"
        Me.tb_stock_maximo.Size = New System.Drawing.Size(57, 23)
        Me.tb_stock_maximo.TabIndex = 15
        '
        'tb_precio_venta
        '
        Me.tb_precio_venta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_precio_venta.Location = New System.Drawing.Point(130, 349)
        Me.tb_precio_venta.Name = "tb_precio_venta"
        Me.tb_precio_venta.Size = New System.Drawing.Size(195, 23)
        Me.tb_precio_venta.TabIndex = 15
        '
        'tb_precio_compra
        '
        Me.tb_precio_compra.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_precio_compra.Location = New System.Drawing.Point(129, 320)
        Me.tb_precio_compra.Name = "tb_precio_compra"
        Me.tb_precio_compra.Size = New System.Drawing.Size(196, 23)
        Me.tb_precio_compra.TabIndex = 15
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 185)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 16)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Clave producto (SAT)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 356)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Precio Venta:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 327)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Precio Compra:"
        '
        'tb_stock_minimo
        '
        Me.tb_stock_minimo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_stock_minimo.Location = New System.Drawing.Point(130, 390)
        Me.tb_stock_minimo.Name = "tb_stock_minimo"
        Me.tb_stock_minimo.Size = New System.Drawing.Size(57, 23)
        Me.tb_stock_minimo.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(202, 393)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Stock Máx.:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(14, 393)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Stock Mín.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 297)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Impuesto:"
        '
        'tab_precios
        '
        Me.tab_precios.Controls.Add(Me.dgv_precios)
        Me.tab_precios.Location = New System.Drawing.Point(4, 25)
        Me.tab_precios.Name = "tab_precios"
        Me.tab_precios.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_precios.Size = New System.Drawing.Size(559, 521)
        Me.tab_precios.TabIndex = 3
        Me.tab_precios.Text = "Precios de Venta"
        Me.tab_precios.UseVisualStyleBackColor = True
        '
        'dgv_precios
        '
        Me.dgv_precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_precios.Location = New System.Drawing.Point(6, 12)
        Me.dgv_precios.MultiSelect = False
        Me.dgv_precios.Name = "dgv_precios"
        Me.dgv_precios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_precios.Size = New System.Drawing.Size(546, 264)
        Me.dgv_precios.TabIndex = 10
        '
        'tab_compuesto
        '
        Me.tab_compuesto.Controls.Add(Me.btn_eliminar_modificador)
        Me.tab_compuesto.Controls.Add(Me.btn_eliminar_prdct_modificador)
        Me.tab_compuesto.Controls.Add(Me.btn_agregar_prdct_modificador)
        Me.tab_compuesto.Controls.Add(Me.btn_agregar_modificador)
        Me.tab_compuesto.Controls.Add(Me.dgv_productos_modificadores)
        Me.tab_compuesto.Controls.Add(Me.dgv_modificadores)
        Me.tab_compuesto.Location = New System.Drawing.Point(4, 25)
        Me.tab_compuesto.Name = "tab_compuesto"
        Me.tab_compuesto.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_compuesto.Size = New System.Drawing.Size(559, 521)
        Me.tab_compuesto.TabIndex = 1
        Me.tab_compuesto.Text = "Producto Compuesto"
        Me.tab_compuesto.UseVisualStyleBackColor = True
        '
        'btn_eliminar_modificador
        '
        Me.btn_eliminar_modificador.Location = New System.Drawing.Point(142, 10)
        Me.btn_eliminar_modificador.Name = "btn_eliminar_modificador"
        Me.btn_eliminar_modificador.Size = New System.Drawing.Size(124, 28)
        Me.btn_eliminar_modificador.TabIndex = 10
        Me.btn_eliminar_modificador.Text = "Eliminar Modificador"
        Me.btn_eliminar_modificador.UseVisualStyleBackColor = True
        '
        'btn_eliminar_prdct_modificador
        '
        Me.btn_eliminar_prdct_modificador.Enabled = False
        Me.btn_eliminar_prdct_modificador.Location = New System.Drawing.Point(142, 245)
        Me.btn_eliminar_prdct_modificador.Name = "btn_eliminar_prdct_modificador"
        Me.btn_eliminar_prdct_modificador.Size = New System.Drawing.Size(124, 28)
        Me.btn_eliminar_prdct_modificador.TabIndex = 12
        Me.btn_eliminar_prdct_modificador.Text = "Eliminar Producto"
        Me.btn_eliminar_prdct_modificador.UseVisualStyleBackColor = True
        '
        'btn_agregar_prdct_modificador
        '
        Me.btn_agregar_prdct_modificador.Location = New System.Drawing.Point(15, 244)
        Me.btn_agregar_prdct_modificador.Name = "btn_agregar_prdct_modificador"
        Me.btn_agregar_prdct_modificador.Size = New System.Drawing.Size(124, 28)
        Me.btn_agregar_prdct_modificador.TabIndex = 13
        Me.btn_agregar_prdct_modificador.Text = "Agregar Producto"
        Me.btn_agregar_prdct_modificador.UseVisualStyleBackColor = True
        '
        'btn_agregar_modificador
        '
        Me.btn_agregar_modificador.Location = New System.Drawing.Point(12, 10)
        Me.btn_agregar_modificador.Name = "btn_agregar_modificador"
        Me.btn_agregar_modificador.Size = New System.Drawing.Size(124, 28)
        Me.btn_agregar_modificador.TabIndex = 11
        Me.btn_agregar_modificador.Text = "Agregar Modificador"
        Me.btn_agregar_modificador.UseVisualStyleBackColor = True
        '
        'dgv_productos_modificadores
        '
        Me.dgv_productos_modificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos_modificadores.Location = New System.Drawing.Point(12, 288)
        Me.dgv_productos_modificadores.MultiSelect = False
        Me.dgv_productos_modificadores.Name = "dgv_productos_modificadores"
        Me.dgv_productos_modificadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_productos_modificadores.Size = New System.Drawing.Size(541, 185)
        Me.dgv_productos_modificadores.TabIndex = 8
        '
        'dgv_modificadores
        '
        Me.dgv_modificadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_modificadores.Location = New System.Drawing.Point(17, 44)
        Me.dgv_modificadores.MultiSelect = False
        Me.dgv_modificadores.Name = "dgv_modificadores"
        Me.dgv_modificadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_modificadores.Size = New System.Drawing.Size(535, 182)
        Me.dgv_modificadores.TabIndex = 9
        '
        'tab_conversiones
        '
        Me.tab_conversiones.Location = New System.Drawing.Point(4, 25)
        Me.tab_conversiones.Name = "tab_conversiones"
        Me.tab_conversiones.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_conversiones.Size = New System.Drawing.Size(559, 521)
        Me.tab_conversiones.TabIndex = 2
        Me.tab_conversiones.Text = "Conversiones"
        Me.tab_conversiones.UseVisualStyleBackColor = True
        '
        'ofd_foto
        '
        Me.ofd_foto.FileName = "OpenFileDialog1"
        '
        'gb_productos
        '
        Me.gb_productos.Controls.Add(Me.Panel2)
        Me.gb_productos.Controls.Add(Me.FlowLayoutPanel1)
        Me.gb_productos.Controls.Add(Me.tb_buscar)
        Me.gb_productos.Controls.Add(Me.Label20)
        Me.gb_productos.Controls.Add(Me.Label11)
        Me.gb_productos.Controls.Add(Me.cb_categoria_busqueda)
        Me.gb_productos.Controls.Add(Me.lst_productos)
        Me.gb_productos.Controls.Add(Me.btn_buscar)
        Me.gb_productos.Location = New System.Drawing.Point(12, 12)
        Me.gb_productos.Name = "gb_productos"
        Me.gb_productos.Size = New System.Drawing.Size(420, 665)
        Me.gb_productos.TabIndex = 16
        Me.gb_productos.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_total_paginas)
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Location = New System.Drawing.Point(4, 612)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(410, 39)
        Me.Panel2.TabIndex = 102
        '
        'lb_total_paginas
        '
        Me.lb_total_paginas.AutoSize = True
        Me.lb_total_paginas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_paginas.Location = New System.Drawing.Point(300, 6)
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
        Me.lb_pagina_actual.Location = New System.Drawing.Point(6, 5)
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
        Me.pb_anterior.Location = New System.Drawing.Point(229, 0)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(30, 30)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImage = CType(resources.GetObject("pb_siguiente.BackgroundImage"), System.Drawing.Image)
        Me.pb_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_siguiente.Location = New System.Drawing.Point(351, 0)
        Me.pb_siguiente.Name = "pb_siguiente"
        Me.pb_siguiente.Size = New System.Drawing.Size(30, 30)
        Me.pb_siguiente.TabIndex = 2
        Me.pb_siguiente.TabStop = False
        '
        'tb_pagina
        '
        Me.tb_pagina.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_pagina.Location = New System.Drawing.Point(265, 3)
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(4, 577)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 30)
        Me.FlowLayoutPanel1.TabIndex = 101
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
        Me.tb_buscar.Location = New System.Drawing.Point(86, 59)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(249, 22)
        Me.tb_buscar.TabIndex = 15
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(10, 63)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 16)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Buscar:"
        '
        'btn_buscar
        '
        Me.btn_buscar.Enabled = False
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(341, 19)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(76, 74)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'frm_producto2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 676)
        Me.Controls.Add(Me.gb_productos)
        Me.Controls.Add(Me.tab_producto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_producto2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos"
        Me.GroupBox1.ResumeLayout(False)
        Me.tab_producto.ResumeLayout(False)
        Me.tab_informacion.ResumeLayout(False)
        Me.gb_insumo.ResumeLayout(False)
        Me.gb_insumo.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_precios.ResumeLayout(False)
        CType(Me.dgv_precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_compuesto.ResumeLayout(False)
        CType(Me.dgv_productos_modificadores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_modificadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_productos.ResumeLayout(False)
        Me.gb_productos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lst_productos As System.Windows.Forms.ListView
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_categoria_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tab_producto As System.Windows.Forms.TabControl
    Friend WithEvents tab_informacion As System.Windows.Forms.TabPage
    Friend WithEvents gb_insumo As System.Windows.Forms.GroupBox
    Friend WithEvents chb_venta_peso As System.Windows.Forms.CheckBox
    Friend WithEvents pb_imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cb_color As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_talla As System.Windows.Forms.ComboBox
    Friend WithEvents cb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents cb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents cb_unidad As System.Windows.Forms.ComboBox
    Friend WithEvents cb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_impuesto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tb_stock_maximo As System.Windows.Forms.TextBox
    Friend WithEvents tb_stock_minimo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tab_compuesto As System.Windows.Forms.TabPage
    Friend WithEvents tab_conversiones As System.Windows.Forms.TabPage
    Friend WithEvents btn_eliminar_modificador As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_prdct_modificador As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_prdct_modificador As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_modificador As System.Windows.Forms.Button
    Friend WithEvents dgv_productos_modificadores As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_modificadores As System.Windows.Forms.DataGridView
    Friend WithEvents btn_eliminar_imagen As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_imagen As System.Windows.Forms.Button
    Friend WithEvents tb_precio_venta As System.Windows.Forms.TextBox
    Friend WithEvents tb_precio_compra As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dtp_final_oferta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_inicial_oferta As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_especial As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tab_precios As System.Windows.Forms.TabPage
    Friend WithEvents cb_modelo As System.Windows.Forms.ComboBox
    Friend WithEvents ofd_foto As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gb_productos As System.Windows.Forms.GroupBox
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dgv_precios As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cb_clavesat As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents lb_total_paginas As System.Windows.Forms.Label
End Class
