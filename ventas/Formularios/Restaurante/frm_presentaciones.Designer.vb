<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_presentaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_presentaciones))
        Me.lst_presentaciones = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gb_insumo = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_buscar_insumo = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tb_clave = New System.Windows.Forms.TextBox()
        Me.cb_proveedor = New System.Windows.Forms.ComboBox()
        Me.cb_unidad_medida = New System.Windows.Forms.ComboBox()
        Me.cb_grupo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_impuesto = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_descripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_stock_maximo = New System.Windows.Forms.TextBox()
        Me.tb_stock_minimo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tb_unidad_rendimiento = New System.Windows.Forms.TextBox()
        Me.tb_rendimiento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tb_insumo_base = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_costo_impuesto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tb_ultimo_costo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_costo_estandar = New System.Windows.Forms.TextBox()
        Me.tb_costo_promedio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cb_grupo_busqueda = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gb_insumo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lst_presentaciones
        '
        Me.lst_presentaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_presentaciones.GridLines = True
        Me.lst_presentaciones.Location = New System.Drawing.Point(12, 49)
        Me.lst_presentaciones.MultiSelect = False
        Me.lst_presentaciones.Name = "lst_presentaciones"
        Me.lst_presentaciones.Size = New System.Drawing.Size(381, 443)
        Me.lst_presentaciones.TabIndex = 0
        Me.lst_presentaciones.UseCompatibleStateImageBehavior = False
        Me.lst_presentaciones.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_eliminar)
        Me.GroupBox1.Controls.Add(Me.btn_deshacer)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.btn_editar)
        Me.GroupBox1.Location = New System.Drawing.Point(409, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(582, 103)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(6, 19)
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
        Me.btn_salir.Location = New System.Drawing.Point(491, 19)
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
        Me.btn_guardar.Location = New System.Drawing.Point(87, 19)
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
        Me.btn_eliminar.Location = New System.Drawing.Point(409, 19)
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
        Me.btn_deshacer.Location = New System.Drawing.Point(166, 19)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(76, 74)
        Me.btn_deshacer.TabIndex = 5
        Me.btn_deshacer.Text = "Deshacer"
        Me.btn_deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_deshacer.UseVisualStyleBackColor = True
        '
        'btn_buscar
        '
        Me.btn_buscar.Enabled = False
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(329, 19)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(76, 74)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Location = New System.Drawing.Point(248, 19)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(76, 74)
        Me.btn_editar.TabIndex = 6
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gb_insumo)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(399, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(621, 378)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información"
        '
        'gb_insumo
        '
        Me.gb_insumo.Controls.Add(Me.Button3)
        Me.gb_insumo.Controls.Add(Me.Label1)
        Me.gb_insumo.Controls.Add(Me.Button2)
        Me.gb_insumo.Controls.Add(Me.Label2)
        Me.gb_insumo.Controls.Add(Me.btn_buscar_insumo)
        Me.gb_insumo.Controls.Add(Me.Button5)
        Me.gb_insumo.Controls.Add(Me.Button1)
        Me.gb_insumo.Controls.Add(Me.tb_clave)
        Me.gb_insumo.Controls.Add(Me.cb_proveedor)
        Me.gb_insumo.Controls.Add(Me.cb_unidad_medida)
        Me.gb_insumo.Controls.Add(Me.cb_grupo)
        Me.gb_insumo.Controls.Add(Me.Label3)
        Me.gb_insumo.Controls.Add(Me.cb_impuesto)
        Me.gb_insumo.Controls.Add(Me.Label16)
        Me.gb_insumo.Controls.Add(Me.tb_descripcion)
        Me.gb_insumo.Controls.Add(Me.Label4)
        Me.gb_insumo.Controls.Add(Me.Label5)
        Me.gb_insumo.Controls.Add(Me.tb_stock_maximo)
        Me.gb_insumo.Controls.Add(Me.tb_stock_minimo)
        Me.gb_insumo.Controls.Add(Me.Label15)
        Me.gb_insumo.Controls.Add(Me.tb_unidad_rendimiento)
        Me.gb_insumo.Controls.Add(Me.tb_rendimiento)
        Me.gb_insumo.Controls.Add(Me.Label14)
        Me.gb_insumo.Controls.Add(Me.tb_insumo_base)
        Me.gb_insumo.Controls.Add(Me.Label13)
        Me.gb_insumo.Controls.Add(Me.tb_costo_impuesto)
        Me.gb_insumo.Controls.Add(Me.Label12)
        Me.gb_insumo.Controls.Add(Me.tb_ultimo_costo)
        Me.gb_insumo.Controls.Add(Me.Label8)
        Me.gb_insumo.Controls.Add(Me.Label9)
        Me.gb_insumo.Controls.Add(Me.Label6)
        Me.gb_insumo.Controls.Add(Me.Label7)
        Me.gb_insumo.Controls.Add(Me.tb_costo_estandar)
        Me.gb_insumo.Controls.Add(Me.tb_costo_promedio)
        Me.gb_insumo.Enabled = False
        Me.gb_insumo.Location = New System.Drawing.Point(6, 18)
        Me.gb_insumo.Name = "gb_insumo"
        Me.gb_insumo.Size = New System.Drawing.Size(608, 352)
        Me.gb_insumo.TabIndex = 25
        Me.gb_insumo.TabStop = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Green
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(560, 104)
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
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Grupo:"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Clave:"
        '
        'btn_buscar_insumo
        '
        Me.btn_buscar_insumo.BackColor = System.Drawing.Color.White
        Me.btn_buscar_insumo.BackgroundImage = CType(resources.GetObject("btn_buscar_insumo.BackgroundImage"), System.Drawing.Image)
        Me.btn_buscar_insumo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_buscar_insumo.ForeColor = System.Drawing.Color.White
        Me.btn_buscar_insumo.Location = New System.Drawing.Point(308, 169)
        Me.btn_buscar_insumo.Name = "btn_buscar_insumo"
        Me.btn_buscar_insumo.Size = New System.Drawing.Size(32, 30)
        Me.btn_buscar_insumo.TabIndex = 24
        Me.btn_buscar_insumo.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Green
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(308, 139)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 27)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "+"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(308, 107)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 27)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'tb_clave
        '
        Me.tb_clave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_clave.Location = New System.Drawing.Point(130, 52)
        Me.tb_clave.Name = "tb_clave"
        Me.tb_clave.Size = New System.Drawing.Size(209, 23)
        Me.tb_clave.TabIndex = 10
        '
        'cb_proveedor
        '
        Me.cb_proveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_proveedor.FormattingEnabled = True
        Me.cb_proveedor.Location = New System.Drawing.Point(130, 139)
        Me.cb_proveedor.Name = "cb_proveedor"
        Me.cb_proveedor.Size = New System.Drawing.Size(172, 26)
        Me.cb_proveedor.TabIndex = 23
        '
        'cb_unidad_medida
        '
        Me.cb_unidad_medida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_unidad_medida.FormattingEnabled = True
        Me.cb_unidad_medida.Location = New System.Drawing.Point(130, 107)
        Me.cb_unidad_medida.Name = "cb_unidad_medida"
        Me.cb_unidad_medida.Size = New System.Drawing.Size(172, 26)
        Me.cb_unidad_medida.TabIndex = 23
        '
        'cb_grupo
        '
        Me.cb_grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_grupo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_grupo.FormattingEnabled = True
        Me.cb_grupo.Location = New System.Drawing.Point(130, 22)
        Me.cb_grupo.Name = "cb_grupo"
        Me.cb_grupo.Size = New System.Drawing.Size(172, 25)
        Me.cb_grupo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Descripción:"
        '
        'cb_impuesto
        '
        Me.cb_impuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_impuesto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_impuesto.FormattingEnabled = True
        Me.cb_impuesto.Location = New System.Drawing.Point(483, 105)
        Me.cb_impuesto.Name = "cb_impuesto"
        Me.cb_impuesto.Size = New System.Drawing.Size(72, 25)
        Me.cb_impuesto.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 146)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 16)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Proveedor:"
        '
        'tb_descripcion
        '
        Me.tb_descripcion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_descripcion.Location = New System.Drawing.Point(130, 79)
        Me.tb_descripcion.Name = "tb_descripcion"
        Me.tb_descripcion.Size = New System.Drawing.Size(209, 23)
        Me.tb_descripcion.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Unidad:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(356, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Ultimo Costo:"
        '
        'tb_stock_maximo
        '
        Me.tb_stock_maximo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_stock_maximo.Location = New System.Drawing.Point(130, 256)
        Me.tb_stock_maximo.Name = "tb_stock_maximo"
        Me.tb_stock_maximo.Size = New System.Drawing.Size(106, 23)
        Me.tb_stock_maximo.TabIndex = 15
        '
        'tb_stock_minimo
        '
        Me.tb_stock_minimo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_stock_minimo.Location = New System.Drawing.Point(130, 227)
        Me.tb_stock_minimo.Name = "tb_stock_minimo"
        Me.tb_stock_minimo.Size = New System.Drawing.Size(106, 23)
        Me.tb_stock_minimo.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 259)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 16)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Stock Máx. Gral."
        '
        'tb_unidad_rendimiento
        '
        Me.tb_unidad_rendimiento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_unidad_rendimiento.Location = New System.Drawing.Point(242, 198)
        Me.tb_unidad_rendimiento.Name = "tb_unidad_rendimiento"
        Me.tb_unidad_rendimiento.ReadOnly = True
        Me.tb_unidad_rendimiento.Size = New System.Drawing.Size(85, 23)
        Me.tb_unidad_rendimiento.TabIndex = 15
        '
        'tb_rendimiento
        '
        Me.tb_rendimiento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_rendimiento.Location = New System.Drawing.Point(130, 198)
        Me.tb_rendimiento.Name = "tb_rendimiento"
        Me.tb_rendimiento.Size = New System.Drawing.Size(106, 23)
        Me.tb_rendimiento.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 230)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Stock Mín. Gral."
        '
        'tb_insumo_base
        '
        Me.tb_insumo_base.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_insumo_base.Location = New System.Drawing.Point(130, 169)
        Me.tb_insumo_base.Name = "tb_insumo_base"
        Me.tb_insumo_base.ReadOnly = True
        Me.tb_insumo_base.Size = New System.Drawing.Size(172, 23)
        Me.tb_insumo_base.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 16)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Rendimiento:"
        '
        'tb_costo_impuesto
        '
        Me.tb_costo_impuesto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_costo_impuesto.Location = New System.Drawing.Point(483, 138)
        Me.tb_costo_impuesto.Name = "tb_costo_impuesto"
        Me.tb_costo_impuesto.Size = New System.Drawing.Size(106, 23)
        Me.tb_costo_impuesto.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 172)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Insumo Base:"
        '
        'tb_ultimo_costo
        '
        Me.tb_ultimo_costo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_ultimo_costo.Location = New System.Drawing.Point(480, 17)
        Me.tb_ultimo_costo.Name = "tb_ultimo_costo"
        Me.tb_ultimo_costo.Size = New System.Drawing.Size(106, 23)
        Me.tb_ultimo_costo.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(359, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Costo c/ Impuestos:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(356, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 16)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Costo estándar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(356, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Costo Promedio:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(359, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Impuesto"
        '
        'tb_costo_estandar
        '
        Me.tb_costo_estandar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_costo_estandar.Location = New System.Drawing.Point(480, 75)
        Me.tb_costo_estandar.Name = "tb_costo_estandar"
        Me.tb_costo_estandar.Size = New System.Drawing.Size(106, 23)
        Me.tb_costo_estandar.TabIndex = 15
        '
        'tb_costo_promedio
        '
        Me.tb_costo_promedio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_costo_promedio.Location = New System.Drawing.Point(480, 46)
        Me.tb_costo_promedio.Name = "tb_costo_promedio"
        Me.tb_costo_promedio.Size = New System.Drawing.Size(106, 23)
        Me.tb_costo_promedio.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(549, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 16)
        Me.Label10.TabIndex = 20
        '
        'cb_grupo_busqueda
        '
        Me.cb_grupo_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_grupo_busqueda.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_grupo_busqueda.FormattingEnabled = True
        Me.cb_grupo_busqueda.Location = New System.Drawing.Point(66, 18)
        Me.cb_grupo_busqueda.Name = "cb_grupo_busqueda"
        Me.cb_grupo_busqueda.Size = New System.Drawing.Size(327, 25)
        Me.cb_grupo_busqueda.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Grupo:"
        '
        'frm_presentaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 504)
        Me.Controls.Add(Me.cb_grupo_busqueda)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lst_presentaciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_presentaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Presentaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gb_insumo.ResumeLayout(False)
        Me.gb_insumo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lst_presentaciones As System.Windows.Forms.ListView
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_clave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_grupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_costo_impuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_costo_promedio As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_ultimo_costo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_descripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cb_grupo_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_impuesto As System.Windows.Forms.ComboBox
    Friend WithEvents cb_unidad_medida As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents gb_insumo As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_buscar_insumo As System.Windows.Forms.Button
    Friend WithEvents tb_rendimiento As System.Windows.Forms.TextBox
    Friend WithEvents tb_insumo_base As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_costo_estandar As System.Windows.Forms.TextBox
    Friend WithEvents tb_stock_maximo As System.Windows.Forms.TextBox
    Friend WithEvents tb_stock_minimo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_unidad_rendimiento As System.Windows.Forms.TextBox
End Class
