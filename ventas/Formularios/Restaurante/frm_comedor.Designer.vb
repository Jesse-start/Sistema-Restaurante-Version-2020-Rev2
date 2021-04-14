<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_comedor
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
        Me.btn_general = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_busqueda = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.tb_impuestos = New System.Windows.Forms.TextBox()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lst_productos = New System.Windows.Forms.ListView()
        Me.tb_apertura = New System.Windows.Forms.TextBox()
        Me.tb_cierre = New System.Windows.Forms.TextBox()
        Me.tb_orden = New System.Windows.Forms.TextBox()
        Me.tb_folio = New System.Windows.Forms.TextBox()
        Me.tb_mesero = New System.Windows.Forms.TextBox()
        Me.tb_personas = New System.Windows.Forms.TextBox()
        Me.tb_area = New System.Windows.Forms.TextBox()
        Me.tb_cuenta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_reabrir_cuenta = New System.Windows.Forms.Button()
        Me.btn_pagar_cuenta = New System.Windows.Forms.Button()
        Me.btn_traspaso_producto = New System.Windows.Forms.Button()
        Me.btn_cambio_mesero = New System.Windows.Forms.Button()
        Me.btn_captura = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_imprimir_cuenta = New System.Windows.Forms.Button()
        Me.btn_dividir_cuenta = New System.Windows.Forms.Button()
        Me.btn_juntar_cuentas = New System.Windows.Forms.Button()
        Me.btn_cambio_cuenta = New System.Windows.Forms.Button()
        Me.btn_abrir_cuenta = New System.Windows.Forms.Button()
        Me.btn_cancela_producto = New System.Windows.Forms.Button()
        Me.gb_comedor = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gb_comedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_general
        '
        Me.btn_general.Location = New System.Drawing.Point(17, 19)
        Me.btn_general.Name = "btn_general"
        Me.btn_general.Size = New System.Drawing.Size(100, 32)
        Me.btn_general.TabIndex = 0
        Me.btn_general.Text = "General"
        Me.btn_general.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_general)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 66)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Areas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.dgv_busqueda)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 518)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mesas"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(223, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Ocupada"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(53, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Disponible"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel2.Location = New System.Drawing.Point(187, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(24, 19)
        Me.Panel2.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel1.Location = New System.Drawing.Point(17, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(24, 19)
        Me.Panel1.TabIndex = 12
        '
        'dgv_busqueda
        '
        Me.dgv_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_busqueda.Location = New System.Drawing.Point(6, 51)
        Me.dgv_busqueda.MultiSelect = False
        Me.dgv_busqueda.Name = "dgv_busqueda"
        Me.dgv_busqueda.RowTemplate.Height = 50
        Me.dgv_busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_busqueda.Size = New System.Drawing.Size(335, 451)
        Me.dgv_busqueda.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tb_total)
        Me.GroupBox3.Controls.Add(Me.tb_impuestos)
        Me.GroupBox3.Controls.Add(Me.tb_subtotal)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.lst_productos)
        Me.GroupBox3.Controls.Add(Me.tb_apertura)
        Me.GroupBox3.Controls.Add(Me.tb_cierre)
        Me.GroupBox3.Controls.Add(Me.tb_orden)
        Me.GroupBox3.Controls.Add(Me.tb_folio)
        Me.GroupBox3.Controls.Add(Me.tb_mesero)
        Me.GroupBox3.Controls.Add(Me.tb_personas)
        Me.GroupBox3.Controls.Add(Me.tb_area)
        Me.GroupBox3.Controls.Add(Me.tb_cuenta)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(373, 217)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(626, 417)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cuenta"
        '
        'tb_total
        '
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(490, 381)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(113, 23)
        Me.tb_total.TabIndex = 20
        '
        'tb_impuestos
        '
        Me.tb_impuestos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_impuestos.Location = New System.Drawing.Point(490, 356)
        Me.tb_impuestos.Name = "tb_impuestos"
        Me.tb_impuestos.ReadOnly = True
        Me.tb_impuestos.Size = New System.Drawing.Size(113, 23)
        Me.tb_impuestos.TabIndex = 21
        '
        'tb_subtotal
        '
        Me.tb_subtotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_subtotal.Location = New System.Drawing.Point(490, 328)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.ReadOnly = True
        Me.tb_subtotal.Size = New System.Drawing.Size(113, 23)
        Me.tb_subtotal.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(408, 384)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 16)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Total:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(409, 359)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 16)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Impuestos:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(409, 332)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Subtotal:"
        '
        'lst_productos
        '
        Me.lst_productos.Location = New System.Drawing.Point(6, 92)
        Me.lst_productos.MultiSelect = False
        Me.lst_productos.Name = "lst_productos"
        Me.lst_productos.Size = New System.Drawing.Size(614, 225)
        Me.lst_productos.TabIndex = 16
        Me.lst_productos.UseCompatibleStateImageBehavior = False
        Me.lst_productos.View = System.Windows.Forms.View.Details
        '
        'tb_apertura
        '
        Me.tb_apertura.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_apertura.Location = New System.Drawing.Point(79, 64)
        Me.tb_apertura.Name = "tb_apertura"
        Me.tb_apertura.ReadOnly = True
        Me.tb_apertura.Size = New System.Drawing.Size(163, 22)
        Me.tb_apertura.TabIndex = 15
        '
        'tb_cierre
        '
        Me.tb_cierre.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cierre.Location = New System.Drawing.Point(334, 61)
        Me.tb_cierre.Name = "tb_cierre"
        Me.tb_cierre.ReadOnly = True
        Me.tb_cierre.Size = New System.Drawing.Size(140, 22)
        Me.tb_cierre.TabIndex = 14
        '
        'tb_orden
        '
        Me.tb_orden.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_orden.Location = New System.Drawing.Point(538, 41)
        Me.tb_orden.Name = "tb_orden"
        Me.tb_orden.ReadOnly = True
        Me.tb_orden.Size = New System.Drawing.Size(65, 22)
        Me.tb_orden.TabIndex = 13
        '
        'tb_folio
        '
        Me.tb_folio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_folio.Location = New System.Drawing.Point(538, 11)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.ReadOnly = True
        Me.tb_folio.Size = New System.Drawing.Size(65, 22)
        Me.tb_folio.TabIndex = 12
        '
        'tb_mesero
        '
        Me.tb_mesero.AcceptsReturn = True
        Me.tb_mesero.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_mesero.Location = New System.Drawing.Point(334, 10)
        Me.tb_mesero.Name = "tb_mesero"
        Me.tb_mesero.ReadOnly = True
        Me.tb_mesero.Size = New System.Drawing.Size(140, 22)
        Me.tb_mesero.TabIndex = 11
        '
        'tb_personas
        '
        Me.tb_personas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_personas.Location = New System.Drawing.Point(334, 35)
        Me.tb_personas.Name = "tb_personas"
        Me.tb_personas.ReadOnly = True
        Me.tb_personas.Size = New System.Drawing.Size(140, 22)
        Me.tb_personas.TabIndex = 10
        '
        'tb_area
        '
        Me.tb_area.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_area.Location = New System.Drawing.Point(79, 38)
        Me.tb_area.Name = "tb_area"
        Me.tb_area.ReadOnly = True
        Me.tb_area.Size = New System.Drawing.Size(163, 22)
        Me.tb_area.TabIndex = 9
        '
        'tb_cuenta
        '
        Me.tb_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cuenta.Location = New System.Drawing.Point(79, 13)
        Me.tb_cuenta.Name = "tb_cuenta"
        Me.tb_cuenta.ReadOnly = True
        Me.tb_cuenta.Size = New System.Drawing.Size(163, 22)
        Me.tb_cuenta.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(265, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Cierre:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Apertura:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(487, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Orden:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(487, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Folio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(265, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Mesero:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(265, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Personas:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Area:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_reabrir_cuenta)
        Me.GroupBox4.Controls.Add(Me.btn_pagar_cuenta)
        Me.GroupBox4.Controls.Add(Me.btn_traspaso_producto)
        Me.GroupBox4.Controls.Add(Me.btn_cambio_mesero)
        Me.GroupBox4.Controls.Add(Me.btn_captura)
        Me.GroupBox4.Controls.Add(Me.btn_salir)
        Me.GroupBox4.Controls.Add(Me.btn_imprimir_cuenta)
        Me.GroupBox4.Controls.Add(Me.btn_dividir_cuenta)
        Me.GroupBox4.Controls.Add(Me.btn_juntar_cuentas)
        Me.GroupBox4.Controls.Add(Me.btn_cambio_cuenta)
        Me.GroupBox4.Controls.Add(Me.btn_abrir_cuenta)
        Me.GroupBox4.Controls.Add(Me.btn_cancela_producto)
        Me.GroupBox4.Location = New System.Drawing.Point(379, 9)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(626, 202)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cuenta"
        '
        'btn_reabrir_cuenta
        '
        Me.btn_reabrir_cuenta.Enabled = False
        Me.btn_reabrir_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reabrir_cuenta.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_reabrir_cuenta.Location = New System.Drawing.Point(506, 108)
        Me.btn_reabrir_cuenta.Name = "btn_reabrir_cuenta"
        Me.btn_reabrir_cuenta.Size = New System.Drawing.Size(95, 85)
        Me.btn_reabrir_cuenta.TabIndex = 14
        Me.btn_reabrir_cuenta.Text = "Reabrir Cuenta"
        Me.btn_reabrir_cuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_reabrir_cuenta.UseVisualStyleBackColor = True
        '
        'btn_pagar_cuenta
        '
        Me.btn_pagar_cuenta.Enabled = False
        Me.btn_pagar_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pagar_cuenta.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_pagar_cuenta.Location = New System.Drawing.Point(406, 107)
        Me.btn_pagar_cuenta.Name = "btn_pagar_cuenta"
        Me.btn_pagar_cuenta.Size = New System.Drawing.Size(95, 85)
        Me.btn_pagar_cuenta.TabIndex = 13
        Me.btn_pagar_cuenta.Text = "Pagar Cuenta"
        Me.btn_pagar_cuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_pagar_cuenta.UseVisualStyleBackColor = True
        '
        'btn_traspaso_producto
        '
        Me.btn_traspaso_producto.Enabled = False
        Me.btn_traspaso_producto.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_traspaso_producto.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_traspaso_producto.Location = New System.Drawing.Point(207, 107)
        Me.btn_traspaso_producto.Name = "btn_traspaso_producto"
        Me.btn_traspaso_producto.Size = New System.Drawing.Size(95, 85)
        Me.btn_traspaso_producto.TabIndex = 12
        Me.btn_traspaso_producto.Text = "Trasp. Producto"
        Me.btn_traspaso_producto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_traspaso_producto.UseVisualStyleBackColor = True
        '
        'btn_cambio_mesero
        '
        Me.btn_cambio_mesero.Enabled = False
        Me.btn_cambio_mesero.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cambio_mesero.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cambio_mesero.Location = New System.Drawing.Point(108, 108)
        Me.btn_cambio_mesero.Name = "btn_cambio_mesero"
        Me.btn_cambio_mesero.Size = New System.Drawing.Size(95, 85)
        Me.btn_cambio_mesero.TabIndex = 11
        Me.btn_cambio_mesero.Text = "Camb. Mesero"
        Me.btn_cambio_mesero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cambio_mesero.UseVisualStyleBackColor = True
        '
        'btn_captura
        '
        Me.btn_captura.Enabled = False
        Me.btn_captura.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_captura.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_captura.Location = New System.Drawing.Point(10, 108)
        Me.btn_captura.Name = "btn_captura"
        Me.btn_captura.Size = New System.Drawing.Size(95, 85)
        Me.btn_captura.TabIndex = 10
        Me.btn_captura.Text = "Captura"
        Me.btn_captura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_captura.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_salir.Location = New System.Drawing.Point(506, 19)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(95, 85)
        Me.btn_salir.TabIndex = 9
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_imprimir_cuenta
        '
        Me.btn_imprimir_cuenta.Enabled = False
        Me.btn_imprimir_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_cuenta.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_imprimir_cuenta.Location = New System.Drawing.Point(308, 107)
        Me.btn_imprimir_cuenta.Name = "btn_imprimir_cuenta"
        Me.btn_imprimir_cuenta.Size = New System.Drawing.Size(95, 85)
        Me.btn_imprimir_cuenta.TabIndex = 8
        Me.btn_imprimir_cuenta.Text = "Imp. Cuenta"
        Me.btn_imprimir_cuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir_cuenta.UseVisualStyleBackColor = True
        '
        'btn_dividir_cuenta
        '
        Me.btn_dividir_cuenta.Enabled = False
        Me.btn_dividir_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_dividir_cuenta.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_dividir_cuenta.Location = New System.Drawing.Point(406, 19)
        Me.btn_dividir_cuenta.Name = "btn_dividir_cuenta"
        Me.btn_dividir_cuenta.Size = New System.Drawing.Size(95, 85)
        Me.btn_dividir_cuenta.TabIndex = 7
        Me.btn_dividir_cuenta.Text = "Dividir Cuenta"
        Me.btn_dividir_cuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_dividir_cuenta.UseVisualStyleBackColor = True
        '
        'btn_juntar_cuentas
        '
        Me.btn_juntar_cuentas.Enabled = False
        Me.btn_juntar_cuentas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_juntar_cuentas.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_juntar_cuentas.Location = New System.Drawing.Point(306, 19)
        Me.btn_juntar_cuentas.Name = "btn_juntar_cuentas"
        Me.btn_juntar_cuentas.Size = New System.Drawing.Size(95, 85)
        Me.btn_juntar_cuentas.TabIndex = 6
        Me.btn_juntar_cuentas.Text = "Juntar Mesas"
        Me.btn_juntar_cuentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_juntar_cuentas.UseVisualStyleBackColor = True
        '
        'btn_cambio_cuenta
        '
        Me.btn_cambio_cuenta.Enabled = False
        Me.btn_cambio_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cambio_cuenta.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cambio_cuenta.Location = New System.Drawing.Point(207, 19)
        Me.btn_cambio_cuenta.Name = "btn_cambio_cuenta"
        Me.btn_cambio_cuenta.Size = New System.Drawing.Size(95, 85)
        Me.btn_cambio_cuenta.TabIndex = 5
        Me.btn_cambio_cuenta.Text = "Cambiar Cuenta"
        Me.btn_cambio_cuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cambio_cuenta.UseVisualStyleBackColor = True
        '
        'btn_abrir_cuenta
        '
        Me.btn_abrir_cuenta.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_abrir_cuenta.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_abrir_cuenta.Location = New System.Drawing.Point(10, 19)
        Me.btn_abrir_cuenta.Name = "btn_abrir_cuenta"
        Me.btn_abrir_cuenta.Size = New System.Drawing.Size(95, 85)
        Me.btn_abrir_cuenta.TabIndex = 3
        Me.btn_abrir_cuenta.Text = "Abrir Cuenta"
        Me.btn_abrir_cuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_abrir_cuenta.UseVisualStyleBackColor = True
        '
        'btn_cancela_producto
        '
        Me.btn_cancela_producto.Enabled = False
        Me.btn_cancela_producto.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancela_producto.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cancela_producto.Location = New System.Drawing.Point(108, 19)
        Me.btn_cancela_producto.Name = "btn_cancela_producto"
        Me.btn_cancela_producto.Size = New System.Drawing.Size(95, 85)
        Me.btn_cancela_producto.TabIndex = 4
        Me.btn_cancela_producto.Text = "Canc. Producto"
        Me.btn_cancela_producto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancela_producto.UseVisualStyleBackColor = True
        '
        'gb_comedor
        '
        Me.gb_comedor.Controls.Add(Me.GroupBox2)
        Me.gb_comedor.Controls.Add(Me.GroupBox4)
        Me.gb_comedor.Controls.Add(Me.GroupBox1)
        Me.gb_comedor.Controls.Add(Me.GroupBox3)
        Me.gb_comedor.Location = New System.Drawing.Point(7, 3)
        Me.gb_comedor.Name = "gb_comedor"
        Me.gb_comedor.Size = New System.Drawing.Size(1006, 644)
        Me.gb_comedor.TabIndex = 6
        Me.gb_comedor.TabStop = False
        '
        'frm_comedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 655)
        Me.Controls.Add(Me.gb_comedor)
        Me.Name = "frm_comedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_comedor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.gb_comedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_general As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_abrir_cuenta As System.Windows.Forms.Button
    Friend WithEvents btn_cancela_producto As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_reabrir_cuenta As System.Windows.Forms.Button
    Friend WithEvents btn_pagar_cuenta As System.Windows.Forms.Button
    Friend WithEvents btn_traspaso_producto As System.Windows.Forms.Button
    Friend WithEvents btn_cambio_mesero As System.Windows.Forms.Button
    Friend WithEvents btn_captura As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir_cuenta As System.Windows.Forms.Button
    Friend WithEvents btn_dividir_cuenta As System.Windows.Forms.Button
    Friend WithEvents btn_juntar_cuentas As System.Windows.Forms.Button
    Friend WithEvents btn_cambio_cuenta As System.Windows.Forms.Button
    Friend WithEvents lst_productos As System.Windows.Forms.ListView
    Friend WithEvents tb_apertura As System.Windows.Forms.TextBox
    Friend WithEvents tb_cierre As System.Windows.Forms.TextBox
    Friend WithEvents tb_orden As System.Windows.Forms.TextBox
    Friend WithEvents tb_folio As System.Windows.Forms.TextBox
    Friend WithEvents tb_mesero As System.Windows.Forms.TextBox
    Friend WithEvents tb_personas As System.Windows.Forms.TextBox
    Friend WithEvents tb_area As System.Windows.Forms.TextBox
    Friend WithEvents tb_cuenta As System.Windows.Forms.TextBox
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents tb_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgv_busqueda As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gb_comedor As System.Windows.Forms.GroupBox
End Class
