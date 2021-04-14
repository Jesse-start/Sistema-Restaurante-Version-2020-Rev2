<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_godmode
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_eliminar_todas_ventas = New System.Windows.Forms.Button()
        Me.btn_eliminar_clientes = New System.Windows.Forms.Button()
        Me.dgv_clientes = New System.Windows.Forms.DataGridView()
        Me.btn_seleccionar_archivo = New System.Windows.Forms.Button()
        Me.lbl_archivo = New System.Windows.Forms.Label()
        Me.btn_agregar_clientes = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab_opciones = New System.Windows.Forms.TabPage()
        Me.btn_restaurar_bd = New System.Windows.Forms.Button()
        Me.btn_enviar_base = New System.Windows.Forms.Button()
        Me.btn_respaldar_bd = New System.Windows.Forms.Button()
        Me.btn_establecer_costos = New System.Windows.Forms.Button()
        Me.btn_eliminar_catalogo_precios = New System.Windows.Forms.Button()
        Me.btn_eliminar_apartados = New System.Windows.Forms.Button()
        Me.btn_inicializar_stock = New System.Windows.Forms.Button()
        Me.btn_eliminar_productos = New System.Windows.Forms.Button()
        Me.btn_eliminar_cotizaciones = New System.Windows.Forms.Button()
        Me.btn_eliminar_facturas = New System.Windows.Forms.Button()
        Me.btn_eliminar_traspasos = New System.Windows.Forms.Button()
        Me.btn_eliminar_compras = New System.Windows.Forms.Button()
        Me.btn_eliminar_pedidos = New System.Windows.Forms.Button()
        Me.btn_eliminar_proveedores = New System.Windows.Forms.Button()
        Me.tab_importar_clientes = New System.Windows.Forms.TabPage()
        Me.tab_importar_productos = New System.Windows.Forms.TabPage()
        Me.btn_examinar_productos = New System.Windows.Forms.Button()
        Me.btn_agregar_productos = New System.Windows.Forms.Button()
        Me.dgv_productos = New System.Windows.Forms.DataGridView()
        Me.lbl_archivo_productos = New System.Windows.Forms.Label()
        Me.tab_importar_proveedores = New System.Windows.Forms.TabPage()
        Me.btn_examinar_proveedores = New System.Windows.Forms.Button()
        Me.btn_agregar_proveedores = New System.Windows.Forms.Button()
        Me.dgv_proveedores = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pb_avance = New System.Windows.Forms.ProgressBar()
        Me.lbl_avance = New System.Windows.Forms.Label()
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tab_opciones.SuspendLayout()
        Me.tab_importar_clientes.SuspendLayout()
        Me.tab_importar_productos.SuspendLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_importar_proveedores.SuspendLayout()
        CType(Me.dgv_proveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(175, 38)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Restablecer db a valores de inicio"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_eliminar_todas_ventas
        '
        Me.btn_eliminar_todas_ventas.Location = New System.Drawing.Point(6, 50)
        Me.btn_eliminar_todas_ventas.Name = "btn_eliminar_todas_ventas"
        Me.btn_eliminar_todas_ventas.Size = New System.Drawing.Size(175, 42)
        Me.btn_eliminar_todas_ventas.TabIndex = 1
        Me.btn_eliminar_todas_ventas.Text = "Eliminar todos los registro de ventas"
        Me.btn_eliminar_todas_ventas.UseVisualStyleBackColor = True
        '
        'btn_eliminar_clientes
        '
        Me.btn_eliminar_clientes.Location = New System.Drawing.Point(6, 98)
        Me.btn_eliminar_clientes.Name = "btn_eliminar_clientes"
        Me.btn_eliminar_clientes.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_clientes.TabIndex = 2
        Me.btn_eliminar_clientes.Text = "Eliminar todos los clientes"
        Me.btn_eliminar_clientes.UseVisualStyleBackColor = True
        '
        'dgv_clientes
        '
        Me.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_clientes.Location = New System.Drawing.Point(6, 40)
        Me.dgv_clientes.Name = "dgv_clientes"
        Me.dgv_clientes.Size = New System.Drawing.Size(586, 318)
        Me.dgv_clientes.TabIndex = 3
        '
        'btn_seleccionar_archivo
        '
        Me.btn_seleccionar_archivo.Location = New System.Drawing.Point(7, 6)
        Me.btn_seleccionar_archivo.Name = "btn_seleccionar_archivo"
        Me.btn_seleccionar_archivo.Size = New System.Drawing.Size(92, 32)
        Me.btn_seleccionar_archivo.TabIndex = 4
        Me.btn_seleccionar_archivo.Text = "Examinar"
        Me.btn_seleccionar_archivo.UseVisualStyleBackColor = True
        '
        'lbl_archivo
        '
        Me.lbl_archivo.AutoSize = True
        Me.lbl_archivo.Location = New System.Drawing.Point(113, 20)
        Me.lbl_archivo.Name = "lbl_archivo"
        Me.lbl_archivo.Size = New System.Drawing.Size(124, 13)
        Me.lbl_archivo.TabIndex = 5
        Me.lbl_archivo.Text = "Seleccione lista de excel"
        '
        'btn_agregar_clientes
        '
        Me.btn_agregar_clientes.Location = New System.Drawing.Point(422, 6)
        Me.btn_agregar_clientes.Name = "btn_agregar_clientes"
        Me.btn_agregar_clientes.Size = New System.Drawing.Size(168, 32)
        Me.btn_agregar_clientes.TabIndex = 6
        Me.btn_agregar_clientes.Text = "Agregar Clientes"
        Me.btn_agregar_clientes.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab_opciones)
        Me.TabControl1.Controls.Add(Me.tab_importar_clientes)
        Me.TabControl1.Controls.Add(Me.tab_importar_productos)
        Me.TabControl1.Controls.Add(Me.tab_importar_proveedores)
        Me.TabControl1.Location = New System.Drawing.Point(3, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(606, 395)
        Me.TabControl1.TabIndex = 7
        '
        'tab_opciones
        '
        Me.tab_opciones.Controls.Add(Me.btn_restaurar_bd)
        Me.tab_opciones.Controls.Add(Me.btn_enviar_base)
        Me.tab_opciones.Controls.Add(Me.btn_respaldar_bd)
        Me.tab_opciones.Controls.Add(Me.btn_establecer_costos)
        Me.tab_opciones.Controls.Add(Me.Button1)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_todas_ventas)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_catalogo_precios)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_apartados)
        Me.tab_opciones.Controls.Add(Me.btn_inicializar_stock)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_productos)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_cotizaciones)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_facturas)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_traspasos)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_compras)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_pedidos)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_proveedores)
        Me.tab_opciones.Controls.Add(Me.btn_eliminar_clientes)
        Me.tab_opciones.Location = New System.Drawing.Point(4, 22)
        Me.tab_opciones.Name = "tab_opciones"
        Me.tab_opciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_opciones.Size = New System.Drawing.Size(598, 369)
        Me.tab_opciones.TabIndex = 0
        Me.tab_opciones.Text = "Opciones Avanzadas"
        Me.tab_opciones.UseVisualStyleBackColor = True
        '
        'btn_restaurar_bd
        '
        Me.btn_restaurar_bd.Location = New System.Drawing.Point(413, 314)
        Me.btn_restaurar_bd.Name = "btn_restaurar_bd"
        Me.btn_restaurar_bd.Size = New System.Drawing.Size(175, 46)
        Me.btn_restaurar_bd.TabIndex = 4
        Me.btn_restaurar_bd.Text = "Restaurar base de datos"
        Me.btn_restaurar_bd.UseVisualStyleBackColor = True
        '
        'btn_enviar_base
        '
        Me.btn_enviar_base.Location = New System.Drawing.Point(413, 90)
        Me.btn_enviar_base.Name = "btn_enviar_base"
        Me.btn_enviar_base.Size = New System.Drawing.Size(175, 46)
        Me.btn_enviar_base.TabIndex = 4
        Me.btn_enviar_base.Text = "Enviar base de datos"
        Me.btn_enviar_base.UseVisualStyleBackColor = True
        '
        'btn_respaldar_bd
        '
        Me.btn_respaldar_bd.Location = New System.Drawing.Point(413, 262)
        Me.btn_respaldar_bd.Name = "btn_respaldar_bd"
        Me.btn_respaldar_bd.Size = New System.Drawing.Size(175, 46)
        Me.btn_respaldar_bd.TabIndex = 4
        Me.btn_respaldar_bd.Text = "Respaldar base de datos"
        Me.btn_respaldar_bd.UseVisualStyleBackColor = True
        '
        'btn_establecer_costos
        '
        Me.btn_establecer_costos.Location = New System.Drawing.Point(202, 6)
        Me.btn_establecer_costos.Name = "btn_establecer_costos"
        Me.btn_establecer_costos.Size = New System.Drawing.Size(175, 35)
        Me.btn_establecer_costos.TabIndex = 3
        Me.btn_establecer_costos.Text = "Establer costos  de productos"
        Me.btn_establecer_costos.UseVisualStyleBackColor = True
        '
        'btn_eliminar_catalogo_precios
        '
        Me.btn_eliminar_catalogo_precios.Location = New System.Drawing.Point(202, 47)
        Me.btn_eliminar_catalogo_precios.Name = "btn_eliminar_catalogo_precios"
        Me.btn_eliminar_catalogo_precios.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_catalogo_precios.TabIndex = 2
        Me.btn_eliminar_catalogo_precios.Text = "Eliminar Catalogo de Precios"
        Me.btn_eliminar_catalogo_precios.UseVisualStyleBackColor = True
        '
        'btn_eliminar_apartados
        '
        Me.btn_eliminar_apartados.Location = New System.Drawing.Point(202, 234)
        Me.btn_eliminar_apartados.Name = "btn_eliminar_apartados"
        Me.btn_eliminar_apartados.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_apartados.TabIndex = 2
        Me.btn_eliminar_apartados.Text = "Eliminar todos los apartados"
        Me.btn_eliminar_apartados.UseVisualStyleBackColor = True
        '
        'btn_inicializar_stock
        '
        Me.btn_inicializar_stock.Location = New System.Drawing.Point(202, 190)
        Me.btn_inicializar_stock.Name = "btn_inicializar_stock"
        Me.btn_inicializar_stock.Size = New System.Drawing.Size(175, 38)
        Me.btn_inicializar_stock.TabIndex = 2
        Me.btn_inicializar_stock.Text = "Inicializar existencias en almacen"
        Me.btn_inicializar_stock.UseVisualStyleBackColor = True
        '
        'btn_eliminar_productos
        '
        Me.btn_eliminar_productos.Location = New System.Drawing.Point(202, 142)
        Me.btn_eliminar_productos.Name = "btn_eliminar_productos"
        Me.btn_eliminar_productos.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_productos.TabIndex = 2
        Me.btn_eliminar_productos.Text = "Eliminar todos los productos"
        Me.btn_eliminar_productos.UseVisualStyleBackColor = True
        '
        'btn_eliminar_cotizaciones
        '
        Me.btn_eliminar_cotizaciones.Location = New System.Drawing.Point(6, 318)
        Me.btn_eliminar_cotizaciones.Name = "btn_eliminar_cotizaciones"
        Me.btn_eliminar_cotizaciones.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_cotizaciones.TabIndex = 2
        Me.btn_eliminar_cotizaciones.Text = "Eliminar cotizaciones"
        Me.btn_eliminar_cotizaciones.UseVisualStyleBackColor = True
        '
        'btn_eliminar_facturas
        '
        Me.btn_eliminar_facturas.Location = New System.Drawing.Point(6, 274)
        Me.btn_eliminar_facturas.Name = "btn_eliminar_facturas"
        Me.btn_eliminar_facturas.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_facturas.TabIndex = 2
        Me.btn_eliminar_facturas.Text = "Eliminar Facturas"
        Me.btn_eliminar_facturas.UseVisualStyleBackColor = True
        '
        'btn_eliminar_traspasos
        '
        Me.btn_eliminar_traspasos.Location = New System.Drawing.Point(6, 230)
        Me.btn_eliminar_traspasos.Name = "btn_eliminar_traspasos"
        Me.btn_eliminar_traspasos.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_traspasos.TabIndex = 2
        Me.btn_eliminar_traspasos.Text = "Eliminar traspasos"
        Me.btn_eliminar_traspasos.UseVisualStyleBackColor = True
        '
        'btn_eliminar_compras
        '
        Me.btn_eliminar_compras.Location = New System.Drawing.Point(6, 186)
        Me.btn_eliminar_compras.Name = "btn_eliminar_compras"
        Me.btn_eliminar_compras.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_compras.TabIndex = 2
        Me.btn_eliminar_compras.Text = "Eliminar todas las compras"
        Me.btn_eliminar_compras.UseVisualStyleBackColor = True
        '
        'btn_eliminar_pedidos
        '
        Me.btn_eliminar_pedidos.Location = New System.Drawing.Point(6, 142)
        Me.btn_eliminar_pedidos.Name = "btn_eliminar_pedidos"
        Me.btn_eliminar_pedidos.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_pedidos.TabIndex = 2
        Me.btn_eliminar_pedidos.Text = "Eliminar todos los pedidos"
        Me.btn_eliminar_pedidos.UseVisualStyleBackColor = True
        '
        'btn_eliminar_proveedores
        '
        Me.btn_eliminar_proveedores.Location = New System.Drawing.Point(202, 98)
        Me.btn_eliminar_proveedores.Name = "btn_eliminar_proveedores"
        Me.btn_eliminar_proveedores.Size = New System.Drawing.Size(175, 38)
        Me.btn_eliminar_proveedores.TabIndex = 2
        Me.btn_eliminar_proveedores.Text = "Eliminar todos los proveedores"
        Me.btn_eliminar_proveedores.UseVisualStyleBackColor = True
        '
        'tab_importar_clientes
        '
        Me.tab_importar_clientes.Controls.Add(Me.btn_seleccionar_archivo)
        Me.tab_importar_clientes.Controls.Add(Me.btn_agregar_clientes)
        Me.tab_importar_clientes.Controls.Add(Me.dgv_clientes)
        Me.tab_importar_clientes.Controls.Add(Me.lbl_archivo)
        Me.tab_importar_clientes.Location = New System.Drawing.Point(4, 22)
        Me.tab_importar_clientes.Name = "tab_importar_clientes"
        Me.tab_importar_clientes.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_importar_clientes.Size = New System.Drawing.Size(598, 369)
        Me.tab_importar_clientes.TabIndex = 1
        Me.tab_importar_clientes.Text = "Importar clientes"
        Me.tab_importar_clientes.UseVisualStyleBackColor = True
        '
        'tab_importar_productos
        '
        Me.tab_importar_productos.Controls.Add(Me.btn_examinar_productos)
        Me.tab_importar_productos.Controls.Add(Me.btn_agregar_productos)
        Me.tab_importar_productos.Controls.Add(Me.dgv_productos)
        Me.tab_importar_productos.Controls.Add(Me.lbl_archivo_productos)
        Me.tab_importar_productos.Location = New System.Drawing.Point(4, 22)
        Me.tab_importar_productos.Name = "tab_importar_productos"
        Me.tab_importar_productos.Size = New System.Drawing.Size(598, 369)
        Me.tab_importar_productos.TabIndex = 2
        Me.tab_importar_productos.Text = "Importar productos"
        Me.tab_importar_productos.UseVisualStyleBackColor = True
        '
        'btn_examinar_productos
        '
        Me.btn_examinar_productos.Location = New System.Drawing.Point(7, 8)
        Me.btn_examinar_productos.Name = "btn_examinar_productos"
        Me.btn_examinar_productos.Size = New System.Drawing.Size(92, 32)
        Me.btn_examinar_productos.TabIndex = 8
        Me.btn_examinar_productos.Text = "Examinar"
        Me.btn_examinar_productos.UseVisualStyleBackColor = True
        '
        'btn_agregar_productos
        '
        Me.btn_agregar_productos.Location = New System.Drawing.Point(422, 8)
        Me.btn_agregar_productos.Name = "btn_agregar_productos"
        Me.btn_agregar_productos.Size = New System.Drawing.Size(168, 32)
        Me.btn_agregar_productos.TabIndex = 10
        Me.btn_agregar_productos.Text = "Agregar Productos"
        Me.btn_agregar_productos.UseVisualStyleBackColor = True
        '
        'dgv_productos
        '
        Me.dgv_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_productos.Location = New System.Drawing.Point(6, 42)
        Me.dgv_productos.Name = "dgv_productos"
        Me.dgv_productos.Size = New System.Drawing.Size(586, 318)
        Me.dgv_productos.TabIndex = 7
        '
        'lbl_archivo_productos
        '
        Me.lbl_archivo_productos.AutoSize = True
        Me.lbl_archivo_productos.Location = New System.Drawing.Point(113, 22)
        Me.lbl_archivo_productos.Name = "lbl_archivo_productos"
        Me.lbl_archivo_productos.Size = New System.Drawing.Size(124, 13)
        Me.lbl_archivo_productos.TabIndex = 9
        Me.lbl_archivo_productos.Text = "Seleccione lista de excel"
        '
        'tab_importar_proveedores
        '
        Me.tab_importar_proveedores.Controls.Add(Me.btn_examinar_proveedores)
        Me.tab_importar_proveedores.Controls.Add(Me.btn_agregar_proveedores)
        Me.tab_importar_proveedores.Controls.Add(Me.dgv_proveedores)
        Me.tab_importar_proveedores.Controls.Add(Me.Label1)
        Me.tab_importar_proveedores.Location = New System.Drawing.Point(4, 22)
        Me.tab_importar_proveedores.Name = "tab_importar_proveedores"
        Me.tab_importar_proveedores.Size = New System.Drawing.Size(598, 369)
        Me.tab_importar_proveedores.TabIndex = 3
        Me.tab_importar_proveedores.Text = "Importar proveedores"
        Me.tab_importar_proveedores.UseVisualStyleBackColor = True
        '
        'btn_examinar_proveedores
        '
        Me.btn_examinar_proveedores.Location = New System.Drawing.Point(7, 8)
        Me.btn_examinar_proveedores.Name = "btn_examinar_proveedores"
        Me.btn_examinar_proveedores.Size = New System.Drawing.Size(92, 32)
        Me.btn_examinar_proveedores.TabIndex = 12
        Me.btn_examinar_proveedores.Text = "Examinar"
        Me.btn_examinar_proveedores.UseVisualStyleBackColor = True
        '
        'btn_agregar_proveedores
        '
        Me.btn_agregar_proveedores.Location = New System.Drawing.Point(422, 8)
        Me.btn_agregar_proveedores.Name = "btn_agregar_proveedores"
        Me.btn_agregar_proveedores.Size = New System.Drawing.Size(168, 32)
        Me.btn_agregar_proveedores.TabIndex = 14
        Me.btn_agregar_proveedores.Text = "Agregar proveedores"
        Me.btn_agregar_proveedores.UseVisualStyleBackColor = True
        '
        'dgv_proveedores
        '
        Me.dgv_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_proveedores.Location = New System.Drawing.Point(6, 42)
        Me.dgv_proveedores.Name = "dgv_proveedores"
        Me.dgv_proveedores.Size = New System.Drawing.Size(586, 318)
        Me.dgv_proveedores.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Seleccione lista de excel"
        '
        'pb_avance
        '
        Me.pb_avance.Location = New System.Drawing.Point(7, 420)
        Me.pb_avance.Name = "pb_avance"
        Me.pb_avance.Size = New System.Drawing.Size(588, 23)
        Me.pb_avance.TabIndex = 8
        '
        'lbl_avance
        '
        Me.lbl_avance.AutoSize = True
        Me.lbl_avance.Location = New System.Drawing.Point(12, 404)
        Me.lbl_avance.Name = "lbl_avance"
        Me.lbl_avance.Size = New System.Drawing.Size(108, 13)
        Me.lbl_avance.TabIndex = 9
        Me.lbl_avance.Text = "Registros ingresados:"
        '
        'frm_godmode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 455)
        Me.Controls.Add(Me.lbl_avance)
        Me.Controls.Add(Me.pb_avance)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frm_godmode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuraciones avanzadas"
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tab_opciones.ResumeLayout(False)
        Me.tab_importar_clientes.ResumeLayout(False)
        Me.tab_importar_clientes.PerformLayout()
        Me.tab_importar_productos.ResumeLayout(False)
        Me.tab_importar_productos.PerformLayout()
        CType(Me.dgv_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_importar_proveedores.ResumeLayout(False)
        Me.tab_importar_proveedores.PerformLayout()
        CType(Me.dgv_proveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_todas_ventas As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_clientes As System.Windows.Forms.Button
    Friend WithEvents dgv_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents btn_seleccionar_archivo As System.Windows.Forms.Button
    Friend WithEvents lbl_archivo As System.Windows.Forms.Label
    Friend WithEvents btn_agregar_clientes As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab_opciones As System.Windows.Forms.TabPage
    Friend WithEvents tab_importar_clientes As System.Windows.Forms.TabPage
    Friend WithEvents btn_establecer_costos As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_pedidos As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_compras As System.Windows.Forms.Button
    Friend WithEvents tab_importar_productos As System.Windows.Forms.TabPage
    Friend WithEvents btn_examinar_productos As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_productos As System.Windows.Forms.Button
    Friend WithEvents dgv_productos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_archivo_productos As System.Windows.Forms.Label
    Friend WithEvents btn_eliminar_productos As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_traspasos As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_facturas As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_cotizaciones As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_catalogo_precios As System.Windows.Forms.Button
    Friend WithEvents btn_respaldar_bd As System.Windows.Forms.Button
    Friend WithEvents btn_restaurar_bd As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_proveedores As System.Windows.Forms.Button
    Friend WithEvents tab_importar_proveedores As System.Windows.Forms.TabPage
    Friend WithEvents btn_examinar_proveedores As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_proveedores As System.Windows.Forms.Button
    Friend WithEvents dgv_proveedores As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_inicializar_stock As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_apartados As System.Windows.Forms.Button
    Friend WithEvents btn_enviar_base As System.Windows.Forms.Button
    Friend WithEvents pb_avance As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_avance As System.Windows.Forms.Label
End Class
