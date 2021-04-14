<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pedidos_detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pedidos_detalle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.lbl_error_surtir = New System.Windows.Forms.Label()
        Me.lbl_error_surtir_detalle = New System.Windows.Forms.Label()
        Me.btn_surtir = New System.Windows.Forms.Button()
        Me.cb_almacenes = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_total = New System.Windows.Forms.TextBox()
        Me.lbl_otros = New System.Windows.Forms.TextBox()
        Me.lbl_iva = New System.Windows.Forms.TextBox()
        Me.lbl_subtotal = New System.Windows.Forms.TextBox()
        Me.btn_Imprimir = New System.Windows.Forms.Button()
        Me.lbl_fecha_hora = New System.Windows.Forms.TextBox()
        Me.lbl_surtido = New System.Windows.Forms.TextBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.lbl_dias_faltantes = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_num_pedido = New System.Windows.Forms.Label()
        Me.gb_productos = New System.Windows.Forms.GroupBox()
        Me.tb_opciones = New System.Windows.Forms.TabControl()
        Me.tab_productos = New System.Windows.Forms.TabPage()
        Me.dg_productos = New System.Windows.Forms.DataGridView()
        Me.tab_almacenes = New System.Windows.Forms.TabPage()
        Me.tab_repartidor = New System.Windows.Forms.TabPage()
        Me.btn_enviar_pedido = New System.Windows.Forms.Button()
        Me.btn_retiro = New System.Windows.Forms.Button()
        Me.btn_recibir_pago = New System.Windows.Forms.Button()
        Me.btn_recibir_nota = New System.Windows.Forms.Button()
        Me.btn_calcular = New System.Windows.Forms.Button()
        Me.lbl_diferencia = New System.Windows.Forms.Label()
        Me.tb_diferencia = New System.Windows.Forms.TextBox()
        Me.tb_total_recibir = New System.Windows.Forms.TextBox()
        Me.cb_agente_entrega = New System.Windows.Forms.ComboBox()
        Me.lbl_agente = New System.Windows.Forms.Label()
        Me.lbl_total_para = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_telefono = New System.Windows.Forms.TextBox()
        Me.lbl_direccion = New System.Windows.Forms.TextBox()
        Me.lbl_nombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_aviso_cancelado = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gb_productos.SuspendLayout()
        Me.tb_opciones.SuspendLayout()
        Me.tab_productos.SuspendLayout()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_almacenes.SuspendLayout()
        Me.tab_repartidor.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.White
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(152, 520)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(145, 69)
        Me.btn_cancelar.TabIndex = 20
        Me.btn_cancelar.Text = "Cancelar Pedido"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_modificar
        '
        Me.btn_modificar.BackColor = System.Drawing.Color.White
        Me.btn_modificar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Location = New System.Drawing.Point(6, 593)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(104, 46)
        Me.btn_modificar.TabIndex = 19
        Me.btn_modificar.Text = "Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = False
        Me.btn_modificar.Visible = False
        '
        'lbl_error_surtir
        '
        Me.lbl_error_surtir.AutoSize = True
        Me.lbl_error_surtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_error_surtir.Location = New System.Drawing.Point(7, 45)
        Me.lbl_error_surtir.MaximumSize = New System.Drawing.Size(400, 0)
        Me.lbl_error_surtir.MinimumSize = New System.Drawing.Size(400, 0)
        Me.lbl_error_surtir.Name = "lbl_error_surtir"
        Me.lbl_error_surtir.Size = New System.Drawing.Size(400, 13)
        Me.lbl_error_surtir.TabIndex = 6
        Me.lbl_error_surtir.Text = "NO SE PUEDE SURTIR. FALTAN LOS SIGUIENTES PRODUCTOS:"
        Me.lbl_error_surtir.Visible = False
        '
        'lbl_error_surtir_detalle
        '
        Me.lbl_error_surtir_detalle.AutoSize = True
        Me.lbl_error_surtir_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_error_surtir_detalle.Location = New System.Drawing.Point(7, 65)
        Me.lbl_error_surtir_detalle.MaximumSize = New System.Drawing.Size(420, 70)
        Me.lbl_error_surtir_detalle.MinimumSize = New System.Drawing.Size(420, 70)
        Me.lbl_error_surtir_detalle.Name = "lbl_error_surtir_detalle"
        Me.lbl_error_surtir_detalle.Size = New System.Drawing.Size(420, 70)
        Me.lbl_error_surtir_detalle.TabIndex = 7
        Me.lbl_error_surtir_detalle.Text = "--"
        Me.lbl_error_surtir_detalle.Visible = False
        '
        'btn_surtir
        '
        Me.btn_surtir.BackColor = System.Drawing.Color.White
        Me.btn_surtir.Enabled = False
        Me.btn_surtir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_surtir.Image = CType(resources.GetObject("btn_surtir.Image"), System.Drawing.Image)
        Me.btn_surtir.Location = New System.Drawing.Point(9, 153)
        Me.btn_surtir.Name = "btn_surtir"
        Me.btn_surtir.Size = New System.Drawing.Size(131, 81)
        Me.btn_surtir.TabIndex = 5
        Me.btn_surtir.Text = "Surtir Pedido"
        Me.btn_surtir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_surtir.UseVisualStyleBackColor = False
        '
        'cb_almacenes
        '
        Me.cb_almacenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_almacenes.FormattingEnabled = True
        Me.cb_almacenes.Location = New System.Drawing.Point(169, 8)
        Me.cb_almacenes.Name = "cb_almacenes"
        Me.cb_almacenes.Size = New System.Drawing.Size(264, 28)
        Me.cb_almacenes.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(163, 17)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Seleccione un almacén:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_total)
        Me.GroupBox1.Controls.Add(Me.lbl_otros)
        Me.GroupBox1.Controls.Add(Me.lbl_iva)
        Me.GroupBox1.Controls.Add(Me.lbl_subtotal)
        Me.GroupBox1.Controls.Add(Me.btn_Imprimir)
        Me.GroupBox1.Controls.Add(Me.btn_modificar)
        Me.GroupBox1.Controls.Add(Me.btn_cancelar)
        Me.GroupBox1.Controls.Add(Me.lbl_fecha_hora)
        Me.GroupBox1.Controls.Add(Me.lbl_surtido)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.lbl_dias_faltantes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl_num_pedido)
        Me.GroupBox1.Controls.Add(Me.gb_productos)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 639)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de Pedido"
        '
        'lbl_total
        '
        Me.lbl_total.Location = New System.Drawing.Point(522, 603)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.ReadOnly = True
        Me.lbl_total.Size = New System.Drawing.Size(150, 24)
        Me.lbl_total.TabIndex = 76
        '
        'lbl_otros
        '
        Me.lbl_otros.Location = New System.Drawing.Point(521, 573)
        Me.lbl_otros.Name = "lbl_otros"
        Me.lbl_otros.ReadOnly = True
        Me.lbl_otros.Size = New System.Drawing.Size(150, 24)
        Me.lbl_otros.TabIndex = 76
        '
        'lbl_iva
        '
        Me.lbl_iva.Location = New System.Drawing.Point(521, 543)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.ReadOnly = True
        Me.lbl_iva.Size = New System.Drawing.Size(150, 24)
        Me.lbl_iva.TabIndex = 76
        '
        'lbl_subtotal
        '
        Me.lbl_subtotal.Location = New System.Drawing.Point(521, 514)
        Me.lbl_subtotal.Name = "lbl_subtotal"
        Me.lbl_subtotal.ReadOnly = True
        Me.lbl_subtotal.Size = New System.Drawing.Size(150, 24)
        Me.lbl_subtotal.TabIndex = 76
        '
        'btn_Imprimir
        '
        Me.btn_Imprimir.BackColor = System.Drawing.Color.White
        Me.btn_Imprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Imprimir.Image = CType(resources.GetObject("btn_Imprimir.Image"), System.Drawing.Image)
        Me.btn_Imprimir.Location = New System.Drawing.Point(6, 520)
        Me.btn_Imprimir.Name = "btn_Imprimir"
        Me.btn_Imprimir.Size = New System.Drawing.Size(140, 69)
        Me.btn_Imprimir.TabIndex = 19
        Me.btn_Imprimir.Text = "Imprimir Pedido"
        Me.btn_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Imprimir.UseVisualStyleBackColor = False
        '
        'lbl_fecha_hora
        '
        Me.lbl_fecha_hora.Location = New System.Drawing.Point(189, 63)
        Me.lbl_fecha_hora.Name = "lbl_fecha_hora"
        Me.lbl_fecha_hora.ReadOnly = True
        Me.lbl_fecha_hora.Size = New System.Drawing.Size(473, 24)
        Me.lbl_fecha_hora.TabIndex = 12
        '
        'lbl_surtido
        '
        Me.lbl_surtido.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_surtido.Location = New System.Drawing.Point(522, 16)
        Me.lbl_surtido.Name = "lbl_surtido"
        Me.lbl_surtido.Size = New System.Drawing.Size(140, 41)
        Me.lbl_surtido.TabIndex = 75
        Me.lbl_surtido.Text = "--"
        Me.lbl_surtido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(303, 520)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(129, 69)
        Me.btn_salir.TabIndex = 74
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'lbl_dias_faltantes
        '
        Me.lbl_dias_faltantes.AutoSize = True
        Me.lbl_dias_faltantes.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dias_faltantes.ForeColor = System.Drawing.Color.Black
        Me.lbl_dias_faltantes.Location = New System.Drawing.Point(359, 20)
        Me.lbl_dias_faltantes.Name = "lbl_dias_faltantes"
        Me.lbl_dias_faltantes.Size = New System.Drawing.Size(37, 32)
        Me.lbl_dias_faltantes.TabIndex = 10
        Me.lbl_dias_faltantes.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(449, 604)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Total:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(437, 578)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 18)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Total otros:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(446, 547)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Total IVA:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(449, 517)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Subtotal:"
        '
        'lbl_num_pedido
        '
        Me.lbl_num_pedido.AutoSize = True
        Me.lbl_num_pedido.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_num_pedido.Location = New System.Drawing.Point(209, 20)
        Me.lbl_num_pedido.Name = "lbl_num_pedido"
        Me.lbl_num_pedido.Size = New System.Drawing.Size(37, 32)
        Me.lbl_num_pedido.TabIndex = 8
        Me.lbl_num_pedido.Text = "--"
        '
        'gb_productos
        '
        Me.gb_productos.Controls.Add(Me.tb_opciones)
        Me.gb_productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_productos.Location = New System.Drawing.Point(5, 214)
        Me.gb_productos.Name = "gb_productos"
        Me.gb_productos.Size = New System.Drawing.Size(667, 296)
        Me.gb_productos.TabIndex = 7
        Me.gb_productos.TabStop = False
        Me.gb_productos.Text = "Detalles"
        '
        'tb_opciones
        '
        Me.tb_opciones.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tb_opciones.Controls.Add(Me.tab_productos)
        Me.tb_opciones.Controls.Add(Me.tab_almacenes)
        Me.tb_opciones.Controls.Add(Me.tab_repartidor)
        Me.tb_opciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_opciones.Location = New System.Drawing.Point(7, 18)
        Me.tb_opciones.Name = "tb_opciones"
        Me.tb_opciones.SelectedIndex = 0
        Me.tb_opciones.Size = New System.Drawing.Size(655, 273)
        Me.tb_opciones.TabIndex = 18
        '
        'tab_productos
        '
        Me.tab_productos.Controls.Add(Me.dg_productos)
        Me.tab_productos.Location = New System.Drawing.Point(4, 29)
        Me.tab_productos.Name = "tab_productos"
        Me.tab_productos.Size = New System.Drawing.Size(647, 240)
        Me.tab_productos.TabIndex = 2
        Me.tab_productos.Text = "productos"
        Me.tab_productos.UseVisualStyleBackColor = True
        '
        'dg_productos
        '
        Me.dg_productos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_productos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_productos.Location = New System.Drawing.Point(15, 10)
        Me.dg_productos.MultiSelect = False
        Me.dg_productos.Name = "dg_productos"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_productos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dg_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg_productos.Size = New System.Drawing.Size(629, 223)
        Me.dg_productos.TabIndex = 2
        '
        'tab_almacenes
        '
        Me.tab_almacenes.BackColor = System.Drawing.Color.White
        Me.tab_almacenes.Controls.Add(Me.lbl_error_surtir)
        Me.tab_almacenes.Controls.Add(Me.Label9)
        Me.tab_almacenes.Controls.Add(Me.btn_surtir)
        Me.tab_almacenes.Controls.Add(Me.lbl_error_surtir_detalle)
        Me.tab_almacenes.Controls.Add(Me.cb_almacenes)
        Me.tab_almacenes.Location = New System.Drawing.Point(4, 29)
        Me.tab_almacenes.Name = "tab_almacenes"
        Me.tab_almacenes.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_almacenes.Size = New System.Drawing.Size(647, 240)
        Me.tab_almacenes.TabIndex = 1
        Me.tab_almacenes.Text = "Almacenes"
        '
        'tab_repartidor
        '
        Me.tab_repartidor.BackColor = System.Drawing.Color.White
        Me.tab_repartidor.Controls.Add(Me.btn_enviar_pedido)
        Me.tab_repartidor.Controls.Add(Me.btn_retiro)
        Me.tab_repartidor.Controls.Add(Me.btn_recibir_pago)
        Me.tab_repartidor.Controls.Add(Me.btn_recibir_nota)
        Me.tab_repartidor.Controls.Add(Me.btn_calcular)
        Me.tab_repartidor.Controls.Add(Me.lbl_diferencia)
        Me.tab_repartidor.Controls.Add(Me.tb_diferencia)
        Me.tab_repartidor.Controls.Add(Me.tb_total_recibir)
        Me.tab_repartidor.Controls.Add(Me.cb_agente_entrega)
        Me.tab_repartidor.Controls.Add(Me.lbl_agente)
        Me.tab_repartidor.Controls.Add(Me.lbl_total_para)
        Me.tab_repartidor.Location = New System.Drawing.Point(4, 29)
        Me.tab_repartidor.Name = "tab_repartidor"
        Me.tab_repartidor.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_repartidor.Size = New System.Drawing.Size(647, 240)
        Me.tab_repartidor.TabIndex = 0
        Me.tab_repartidor.Text = "Agente de entrega"
        '
        'btn_enviar_pedido
        '
        Me.btn_enviar_pedido.BackColor = System.Drawing.Color.White
        Me.btn_enviar_pedido.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar_pedido.Image = CType(resources.GetObject("btn_enviar_pedido.Image"), System.Drawing.Image)
        Me.btn_enviar_pedido.Location = New System.Drawing.Point(311, 107)
        Me.btn_enviar_pedido.Name = "btn_enviar_pedido"
        Me.btn_enviar_pedido.Size = New System.Drawing.Size(136, 69)
        Me.btn_enviar_pedido.TabIndex = 20
        Me.btn_enviar_pedido.Text = "Enviar Pedido"
        Me.btn_enviar_pedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_enviar_pedido.UseVisualStyleBackColor = False
        '
        'btn_retiro
        '
        Me.btn_retiro.Location = New System.Drawing.Point(311, 38)
        Me.btn_retiro.Name = "btn_retiro"
        Me.btn_retiro.Size = New System.Drawing.Size(112, 33)
        Me.btn_retiro.TabIndex = 14
        Me.btn_retiro.Text = "Realizar retiro"
        Me.btn_retiro.UseVisualStyleBackColor = True
        '
        'btn_recibir_pago
        '
        Me.btn_recibir_pago.BackColor = System.Drawing.Color.White
        Me.btn_recibir_pago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_recibir_pago.Image = CType(resources.GetObject("btn_recibir_pago.Image"), System.Drawing.Image)
        Me.btn_recibir_pago.Location = New System.Drawing.Point(173, 107)
        Me.btn_recibir_pago.Name = "btn_recibir_pago"
        Me.btn_recibir_pago.Size = New System.Drawing.Size(119, 69)
        Me.btn_recibir_pago.TabIndex = 19
        Me.btn_recibir_pago.Text = "Recibir Efectivo"
        Me.btn_recibir_pago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_recibir_pago.UseVisualStyleBackColor = False
        '
        'btn_recibir_nota
        '
        Me.btn_recibir_nota.BackColor = System.Drawing.Color.White
        Me.btn_recibir_nota.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_recibir_nota.Image = CType(resources.GetObject("btn_recibir_nota.Image"), System.Drawing.Image)
        Me.btn_recibir_nota.Location = New System.Drawing.Point(9, 107)
        Me.btn_recibir_nota.Name = "btn_recibir_nota"
        Me.btn_recibir_nota.Size = New System.Drawing.Size(148, 69)
        Me.btn_recibir_nota.TabIndex = 19
        Me.btn_recibir_nota.Text = "Recibi Nota"
        Me.btn_recibir_nota.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_recibir_nota.UseVisualStyleBackColor = False
        '
        'btn_calcular
        '
        Me.btn_calcular.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_calcular.Location = New System.Drawing.Point(193, 38)
        Me.btn_calcular.Name = "btn_calcular"
        Me.btn_calcular.Size = New System.Drawing.Size(112, 33)
        Me.btn_calcular.TabIndex = 13
        Me.btn_calcular.Text = "Calcular"
        Me.btn_calcular.UseVisualStyleBackColor = True
        '
        'lbl_diferencia
        '
        Me.lbl_diferencia.AutoSize = True
        Me.lbl_diferencia.Location = New System.Drawing.Point(6, 75)
        Me.lbl_diferencia.Name = "lbl_diferencia"
        Me.lbl_diferencia.Size = New System.Drawing.Size(73, 17)
        Me.lbl_diferencia.TabIndex = 11
        Me.lbl_diferencia.Text = "Diferencia"
        '
        'tb_diferencia
        '
        Me.tb_diferencia.Location = New System.Drawing.Point(90, 69)
        Me.tb_diferencia.Name = "tb_diferencia"
        Me.tb_diferencia.Size = New System.Drawing.Size(97, 23)
        Me.tb_diferencia.TabIndex = 10
        Me.tb_diferencia.Text = "0"
        '
        'tb_total_recibir
        '
        Me.tb_total_recibir.Location = New System.Drawing.Point(90, 38)
        Me.tb_total_recibir.Name = "tb_total_recibir"
        Me.tb_total_recibir.Size = New System.Drawing.Size(97, 23)
        Me.tb_total_recibir.TabIndex = 10
        Me.tb_total_recibir.Text = "0"
        '
        'cb_agente_entrega
        '
        Me.cb_agente_entrega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_agente_entrega.FormattingEnabled = True
        Me.cb_agente_entrega.Location = New System.Drawing.Point(90, 9)
        Me.cb_agente_entrega.Name = "cb_agente_entrega"
        Me.cb_agente_entrega.Size = New System.Drawing.Size(333, 25)
        Me.cb_agente_entrega.TabIndex = 2
        '
        'lbl_agente
        '
        Me.lbl_agente.AutoSize = True
        Me.lbl_agente.Location = New System.Drawing.Point(6, 9)
        Me.lbl_agente.Name = "lbl_agente"
        Me.lbl_agente.Size = New System.Drawing.Size(59, 17)
        Me.lbl_agente.TabIndex = 1
        Me.lbl_agente.Text = "Agente:"
        '
        'lbl_total_para
        '
        Me.lbl_total_para.AutoSize = True
        Me.lbl_total_para.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_para.Location = New System.Drawing.Point(6, 43)
        Me.lbl_total_para.Name = "lbl_total_para"
        Me.lbl_total_para.Size = New System.Drawing.Size(78, 18)
        Me.lbl_total_para.TabIndex = 9
        Me.lbl_total_para.Text = "Total para:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_telefono)
        Me.GroupBox2.Controls.Add(Me.lbl_direccion)
        Me.GroupBox2.Controls.Add(Me.lbl_nombre)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(666, 114)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Cliente"
        '
        'lbl_telefono
        '
        Me.lbl_telefono.Location = New System.Drawing.Point(87, 83)
        Me.lbl_telefono.Name = "lbl_telefono"
        Me.lbl_telefono.ReadOnly = True
        Me.lbl_telefono.Size = New System.Drawing.Size(535, 24)
        Me.lbl_telefono.TabIndex = 12
        '
        'lbl_direccion
        '
        Me.lbl_direccion.Location = New System.Drawing.Point(87, 53)
        Me.lbl_direccion.Name = "lbl_direccion"
        Me.lbl_direccion.ReadOnly = True
        Me.lbl_direccion.Size = New System.Drawing.Size(535, 24)
        Me.lbl_direccion.TabIndex = 12
        '
        'lbl_nombre
        '
        Me.lbl_nombre.Location = New System.Drawing.Point(87, 23)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.ReadOnly = True
        Me.lbl_nombre.Size = New System.Drawing.Size(535, 24)
        Me.lbl_nombre.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 18)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Telefono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Direccion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 18)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha -Hora de Entrega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No de pedido:"
        '
        'tb_aviso_cancelado
        '
        Me.tb_aviso_cancelado.AutoSize = True
        Me.tb_aviso_cancelado.BackColor = System.Drawing.Color.DarkRed
        Me.tb_aviso_cancelado.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_aviso_cancelado.ForeColor = System.Drawing.Color.White
        Me.tb_aviso_cancelado.Location = New System.Drawing.Point(19, 3)
        Me.tb_aviso_cancelado.MaximumSize = New System.Drawing.Size(660, 25)
        Me.tb_aviso_cancelado.MinimumSize = New System.Drawing.Size(660, 25)
        Me.tb_aviso_cancelado.Name = "tb_aviso_cancelado"
        Me.tb_aviso_cancelado.Size = New System.Drawing.Size(660, 25)
        Me.tb_aviso_cancelado.TabIndex = 19
        Me.tb_aviso_cancelado.Text = "C ANCELADO"
        Me.tb_aviso_cancelado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tb_aviso_cancelado.Visible = False
        '
        'frm_pedidos_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(698, 672)
        Me.Controls.Add(Me.tb_aviso_cancelado)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_pedidos_detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_productos.ResumeLayout(False)
        Me.tb_opciones.ResumeLayout(False)
        Me.tab_productos.ResumeLayout(False)
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_almacenes.ResumeLayout(False)
        Me.tab_almacenes.PerformLayout()
        Me.tab_repartidor.ResumeLayout(False)
        Me.tab_repartidor.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents dg_productos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_num_pedido As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_modificar As System.Windows.Forms.Button
    Friend WithEvents lbl_error_surtir_detalle As System.Windows.Forms.Label
    Friend WithEvents lbl_error_surtir As System.Windows.Forms.Label
    Friend WithEvents btn_surtir As System.Windows.Forms.Button
    Friend WithEvents cb_almacenes As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_dias_faltantes As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents lbl_surtido As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tab_repartidor As System.Windows.Forms.TabPage
    Friend WithEvents tab_almacenes As System.Windows.Forms.TabPage
    Private WithEvents tb_opciones As System.Windows.Forms.TabControl
    Friend WithEvents tab_productos As System.Windows.Forms.TabPage
    Friend WithEvents gb_productos As System.Windows.Forms.GroupBox
    Friend WithEvents btn_enviar_pedido As System.Windows.Forms.Button
    Friend WithEvents btn_retiro As System.Windows.Forms.Button
    Friend WithEvents btn_recibir_pago As System.Windows.Forms.Button
    Friend WithEvents btn_recibir_nota As System.Windows.Forms.Button
    Friend WithEvents btn_calcular As System.Windows.Forms.Button
    Friend WithEvents lbl_diferencia As System.Windows.Forms.Label
    Friend WithEvents tb_diferencia As System.Windows.Forms.TextBox
    Friend WithEvents tb_total_recibir As System.Windows.Forms.TextBox
    Friend WithEvents cb_agente_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_agente As System.Windows.Forms.Label
    Friend WithEvents lbl_total_para As System.Windows.Forms.Label
    Friend WithEvents lbl_fecha_hora As System.Windows.Forms.TextBox
    Friend WithEvents lbl_telefono As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccion As System.Windows.Forms.TextBox
    Friend WithEvents lbl_nombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_total As System.Windows.Forms.TextBox
    Friend WithEvents lbl_otros As System.Windows.Forms.TextBox
    Friend WithEvents lbl_iva As System.Windows.Forms.TextBox
    Friend WithEvents lbl_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents btn_Imprimir As System.Windows.Forms.Button
    Private WithEvents tb_aviso_cancelado As System.Windows.Forms.Label
End Class
