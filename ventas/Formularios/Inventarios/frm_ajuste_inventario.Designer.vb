<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ajuste_inventario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ajuste_inventario))
        Me.gb_inventario = New System.Windows.Forms.GroupBox()
        Me.tb_num_espacio = New System.Windows.Forms.NumericUpDown()
        Me.chb_habilitar_espaciado = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_marca = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_categoria = New System.Windows.Forms.ComboBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.chb_teclado = New System.Windows.Forms.CheckBox()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.gb_log = New System.Windows.Forms.GroupBox()
        Me.tb_log = New System.Windows.Forms.TextBox()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.btn_aplicar_merma = New System.Windows.Forms.Button()
        Me.dgv_inventario = New System.Windows.Forms.DataGridView()
        Me.cb_almacen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_sucursal = New System.Windows.Forms.ComboBox()
        Me.gb_listado = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_total_paginas = New System.Windows.Forms.Label()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_buscar = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cb_cliente_busqueda = New System.Windows.Forms.ComboBox()
        Me.lst_facturas = New System.Windows.Forms.ListView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.gb_inventario.SuspendLayout()
        CType(Me.tb_num_espacio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_log.SuspendLayout()
        CType(Me.dgv_inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_listado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_inventario
        '
        Me.gb_inventario.Controls.Add(Me.tb_num_espacio)
        Me.gb_inventario.Controls.Add(Me.chb_habilitar_espaciado)
        Me.gb_inventario.Controls.Add(Me.Label4)
        Me.gb_inventario.Controls.Add(Me.cb_marca)
        Me.gb_inventario.Controls.Add(Me.Label5)
        Me.gb_inventario.Controls.Add(Me.cb_categoria)
        Me.gb_inventario.Controls.Add(Me.btn_buscar)
        Me.gb_inventario.Controls.Add(Me.chb_teclado)
        Me.gb_inventario.Controls.Add(Me.tb_buscar)
        Me.gb_inventario.Controls.Add(Me.gb_log)
        Me.gb_inventario.Controls.Add(Me.dgv_inventario)
        Me.gb_inventario.Controls.Add(Me.cb_almacen)
        Me.gb_inventario.Controls.Add(Me.Label2)
        Me.gb_inventario.Controls.Add(Me.Label3)
        Me.gb_inventario.Controls.Add(Me.Label1)
        Me.gb_inventario.Controls.Add(Me.cb_sucursal)
        Me.gb_inventario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_inventario.Location = New System.Drawing.Point(391, 104)
        Me.gb_inventario.Name = "gb_inventario"
        Me.gb_inventario.Size = New System.Drawing.Size(979, 606)
        Me.gb_inventario.TabIndex = 0
        Me.gb_inventario.TabStop = False
        Me.gb_inventario.Text = " "
        '
        'tb_num_espacio
        '
        Me.tb_num_espacio.Location = New System.Drawing.Point(320, 72)
        Me.tb_num_espacio.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.tb_num_espacio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tb_num_espacio.Name = "tb_num_espacio"
        Me.tb_num_espacio.Size = New System.Drawing.Size(37, 23)
        Me.tb_num_espacio.TabIndex = 85
        Me.tb_num_espacio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'chb_habilitar_espaciado
        '
        Me.chb_habilitar_espaciado.AutoSize = True
        Me.chb_habilitar_espaciado.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_habilitar_espaciado.Location = New System.Drawing.Point(100, 74)
        Me.chb_habilitar_espaciado.Name = "chb_habilitar_espaciado"
        Me.chb_habilitar_espaciado.Size = New System.Drawing.Size(223, 20)
        Me.chb_habilitar_espaciado.TabIndex = 84
        Me.chb_habilitar_espaciado.Text = "Imprimir con espacio entre producto"
        Me.chb_habilitar_espaciado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(373, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Marca:"
        '
        'cb_marca
        '
        Me.cb_marca.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_marca.FormattingEnabled = True
        Me.cb_marca.Location = New System.Drawing.Point(457, 74)
        Me.cb_marca.Name = "cb_marca"
        Me.cb_marca.Size = New System.Drawing.Size(225, 24)
        Me.cb_marca.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(373, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 16)
        Me.Label5.TabIndex = 83
        Me.Label5.Text = "Categoria:"
        '
        'cb_categoria
        '
        Me.cb_categoria.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_categoria.FormattingEnabled = True
        Me.cb_categoria.Location = New System.Drawing.Point(457, 44)
        Me.cb_categoria.Name = "cb_categoria"
        Me.cb_categoria.Size = New System.Drawing.Size(225, 24)
        Me.cb_categoria.TabIndex = 80
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.White
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(688, 17)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(116, 63)
        Me.btn_buscar.TabIndex = 79
        Me.btn_buscar.Text = "Filtrar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = False
        Me.btn_buscar.Visible = False
        '
        'chb_teclado
        '
        Me.chb_teclado.AutoSize = True
        Me.chb_teclado.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_teclado.Location = New System.Drawing.Point(12, 529)
        Me.chb_teclado.Name = "chb_teclado"
        Me.chb_teclado.Size = New System.Drawing.Size(404, 25)
        Me.chb_teclado.TabIndex = 78
        Me.chb_teclado.Text = "Mostrar teclado  numerico al indicar cantidades"
        Me.chb_teclado.UseVisualStyleBackColor = True
        '
        'tb_buscar
        '
        Me.tb_buscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_buscar.Location = New System.Drawing.Point(457, 17)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(225, 23)
        Me.tb_buscar.TabIndex = 77
        '
        'gb_log
        '
        Me.gb_log.Controls.Add(Me.tb_log)
        Me.gb_log.Location = New System.Drawing.Point(20, 556)
        Me.gb_log.Name = "gb_log"
        Me.gb_log.Size = New System.Drawing.Size(912, 44)
        Me.gb_log.TabIndex = 76
        Me.gb_log.TabStop = False
        Me.gb_log.Text = "Log"
        '
        'tb_log
        '
        Me.tb_log.BackColor = System.Drawing.Color.White
        Me.tb_log.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tb_log.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_log.Location = New System.Drawing.Point(13, 18)
        Me.tb_log.Name = "tb_log"
        Me.tb_log.Size = New System.Drawing.Size(878, 19)
        Me.tb_log.TabIndex = 0
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.White
        Me.btn_imprimir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.Location = New System.Drawing.Point(677, 17)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(66, 86)
        Me.btn_imprimir.TabIndex = 75
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'btn_aplicar_merma
        '
        Me.btn_aplicar_merma.BackColor = System.Drawing.Color.White
        Me.btn_aplicar_merma.Enabled = False
        Me.btn_aplicar_merma.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplicar_merma.Image = CType(resources.GetObject("btn_aplicar_merma.Image"), System.Drawing.Image)
        Me.btn_aplicar_merma.Location = New System.Drawing.Point(753, 18)
        Me.btn_aplicar_merma.Name = "btn_aplicar_merma"
        Me.btn_aplicar_merma.Size = New System.Drawing.Size(72, 84)
        Me.btn_aplicar_merma.TabIndex = 7
        Me.btn_aplicar_merma.Text = "Merma"
        Me.btn_aplicar_merma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_aplicar_merma.UseVisualStyleBackColor = False
        '
        'dgv_inventario
        '
        Me.dgv_inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_inventario.Location = New System.Drawing.Point(12, 120)
        Me.dgv_inventario.Name = "dgv_inventario"
        Me.dgv_inventario.Size = New System.Drawing.Size(953, 403)
        Me.dgv_inventario.TabIndex = 6
        '
        'cb_almacen
        '
        Me.cb_almacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_almacen.FormattingEnabled = True
        Me.cb_almacen.Location = New System.Drawing.Point(100, 44)
        Me.cb_almacen.Name = "cb_almacen"
        Me.cb_almacen.Size = New System.Drawing.Size(257, 24)
        Me.cb_almacen.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Almacen:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(373, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Filtro:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sucursal:"
        '
        'cb_sucursal
        '
        Me.cb_sucursal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sucursal.FormattingEnabled = True
        Me.cb_sucursal.Location = New System.Drawing.Point(100, 16)
        Me.cb_sucursal.Name = "cb_sucursal"
        Me.cb_sucursal.Size = New System.Drawing.Size(257, 24)
        Me.cb_sucursal.TabIndex = 0
        '
        'gb_listado
        '
        Me.gb_listado.Controls.Add(Me.Panel2)
        Me.gb_listado.Controls.Add(Me.FlowLayoutPanel1)
        Me.gb_listado.Controls.Add(Me.TextBox1)
        Me.gb_listado.Controls.Add(Me.lbl_buscar)
        Me.gb_listado.Controls.Add(Me.Label19)
        Me.gb_listado.Controls.Add(Me.cb_cliente_busqueda)
        Me.gb_listado.Controls.Add(Me.lst_facturas)
        Me.gb_listado.Controls.Add(Me.Button1)
        Me.gb_listado.Location = New System.Drawing.Point(10, 10)
        Me.gb_listado.Name = "gb_listado"
        Me.gb_listado.Size = New System.Drawing.Size(375, 711)
        Me.gb_listado.TabIndex = 24
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
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(87, 62)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 22)
        Me.TextBox1.TabIndex = 15
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
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(307, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 80)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Buscar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(391, 17)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(62, 86)
        Me.btn_nuevo.TabIndex = 25
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(913, 18)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(82, 85)
        Me.btn_salir.TabIndex = 34
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(458, 17)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(68, 86)
        Me.btn_guardar.TabIndex = 26
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(831, 17)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(76, 86)
        Me.btn_cancelar.TabIndex = 29
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_deshacer
        '
        Me.btn_deshacer.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deshacer.Image = CType(resources.GetObject("btn_deshacer.Image"), System.Drawing.Image)
        Me.btn_deshacer.Location = New System.Drawing.Point(530, 17)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(72, 85)
        Me.btn_deshacer.TabIndex = 27
        Me.btn_deshacer.Text = "Deshacer"
        Me.btn_deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_deshacer.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Location = New System.Drawing.Point(606, 17)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(65, 86)
        Me.btn_editar.TabIndex = 28
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'frm_ajuste_inventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1411, 729)
        Me.Controls.Add(Me.btn_nuevo)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_deshacer)
        Me.Controls.Add(Me.btn_editar)
        Me.Controls.Add(Me.gb_listado)
        Me.Controls.Add(Me.gb_inventario)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.btn_aplicar_merma)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ajuste_inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste de Inventario"
        Me.TopMost = True
        Me.gb_inventario.ResumeLayout(False)
        Me.gb_inventario.PerformLayout()
        CType(Me.tb_num_espacio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_log.ResumeLayout(False)
        Me.gb_log.PerformLayout()
        CType(Me.dgv_inventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_listado.ResumeLayout(False)
        Me.gb_listado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_inventario As System.Windows.Forms.GroupBox
    Friend WithEvents cb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_inventario As System.Windows.Forms.DataGridView
    Friend WithEvents btn_aplicar_merma As System.Windows.Forms.Button
    Friend WithEvents gb_log As System.Windows.Forms.GroupBox
    Friend WithEvents tb_log As System.Windows.Forms.TextBox
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chb_teclado As System.Windows.Forms.CheckBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents chb_habilitar_espaciado As System.Windows.Forms.CheckBox
    Friend WithEvents tb_num_espacio As System.Windows.Forms.NumericUpDown
    Friend WithEvents gb_listado As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lb_total_paginas As Label
    Friend WithEvents lb_pagina_actual As Label
    Friend WithEvents pb_anterior As PictureBox
    Friend WithEvents pb_siguiente As PictureBox
    Friend WithEvents tb_pagina As TextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents tb_resultados As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbl_buscar As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents cb_cliente_busqueda As ComboBox
    Friend WithEvents lst_facturas As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_guardar As Button
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_deshacer As Button
    Friend WithEvents btn_editar As Button
End Class
