<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_apartado_detalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_apartado_detalle))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btn_enviar_apartado = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.cb_agente_entrega = New System.Windows.Forms.ComboBox()
        Me.lbl_agente = New System.Windows.Forms.Label()
        Me.btn_generar_nota_venta = New System.Windows.Forms.Button()
        Me.lbl_error_surtir = New System.Windows.Forms.Label()
        Me.lbl_error_surtir_detalle = New System.Windows.Forms.Label()
        Me.btn_entregar = New System.Windows.Forms.Button()
        Me.cb_almacenes = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gb_botones = New System.Windows.Forms.GroupBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.lbl_total = New System.Windows.Forms.TextBox()
        Me.lbl_otros = New System.Windows.Forms.TextBox()
        Me.lbl_iva = New System.Windows.Forms.TextBox()
        Me.lbl_subtotal = New System.Windows.Forms.TextBox()
        Me.lbl_fecha_hora = New System.Windows.Forms.TextBox()
        Me.lbl_entregado = New System.Windows.Forms.TextBox()
        Me.lbl_dias_faltantes = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_num_apartado = New System.Windows.Forms.Label()
        Me.gb_productos = New System.Windows.Forms.GroupBox()
        Me.tb_opciones = New System.Windows.Forms.TabControl()
        Me.tab_productos = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_comentarios = New System.Windows.Forms.TextBox()
        Me.btn_guardar_observaciones = New System.Windows.Forms.Button()
        Me.dg_productos = New System.Windows.Forms.DataGridView()
        Me.tab_almacenes = New System.Windows.Forms.TabPage()
        Me.tab_pagos = New System.Windows.Forms.TabPage()
        Me.lbl_saldo = New System.Windows.Forms.TextBox()
        Me.lbl_cobros = New System.Windows.Forms.TextBox()
        Me.btn_imprimir_abono = New System.Windows.Forms.Button()
        Me.btn_cancelar_pago = New System.Windows.Forms.Button()
        Me.btn_cobrar = New System.Windows.Forms.Button()
        Me.dgv_abonos = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tb_vendedor = New System.Windows.Forms.TextBox()
        Me.lbl_telefono = New System.Windows.Forms.TextBox()
        Me.lbl_direccion = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_nombre = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_aviso_cancelado = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gb_botones.SuspendLayout()
        Me.gb_productos.SuspendLayout()
        Me.tb_opciones.SuspendLayout()
        Me.tab_productos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_almacenes.SuspendLayout()
        Me.tab_pagos.SuspendLayout()
        CType(Me.dgv_abonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_enviar_apartado
        '
        Me.btn_enviar_apartado.BackColor = System.Drawing.Color.White
        Me.btn_enviar_apartado.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar_apartado.Location = New System.Drawing.Point(509, 197)
        Me.btn_enviar_apartado.Name = "btn_enviar_apartado"
        Me.btn_enviar_apartado.Size = New System.Drawing.Size(126, 46)
        Me.btn_enviar_apartado.TabIndex = 3
        Me.btn_enviar_apartado.Text = "Enviar a domicilio"
        Me.btn_enviar_apartado.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.White
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(118, 12)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(94, 105)
        Me.btn_cancelar.TabIndex = 20
        Me.btn_cancelar.Text = "Cancelar Apartado"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'cb_agente_entrega
        '
        Me.cb_agente_entrega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_agente_entrega.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_agente_entrega.FormattingEnabled = True
        Me.cb_agente_entrega.Location = New System.Drawing.Point(92, 203)
        Me.cb_agente_entrega.Name = "cb_agente_entrega"
        Me.cb_agente_entrega.Size = New System.Drawing.Size(252, 25)
        Me.cb_agente_entrega.TabIndex = 2
        '
        'lbl_agente
        '
        Me.lbl_agente.AutoSize = True
        Me.lbl_agente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_agente.Location = New System.Drawing.Point(12, 206)
        Me.lbl_agente.Name = "lbl_agente"
        Me.lbl_agente.Size = New System.Drawing.Size(59, 17)
        Me.lbl_agente.TabIndex = 1
        Me.lbl_agente.Text = "Agente:"
        '
        'btn_generar_nota_venta
        '
        Me.btn_generar_nota_venta.BackColor = System.Drawing.Color.White
        Me.btn_generar_nota_venta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar_nota_venta.Image = CType(resources.GetObject("btn_generar_nota_venta.Image"), System.Drawing.Image)
        Me.btn_generar_nota_venta.Location = New System.Drawing.Point(6, 12)
        Me.btn_generar_nota_venta.Name = "btn_generar_nota_venta"
        Me.btn_generar_nota_venta.Size = New System.Drawing.Size(106, 107)
        Me.btn_generar_nota_venta.TabIndex = 19
        Me.btn_generar_nota_venta.Text = "Generar nota de venta"
        Me.btn_generar_nota_venta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_generar_nota_venta.UseVisualStyleBackColor = False
        '
        'lbl_error_surtir
        '
        Me.lbl_error_surtir.AutoSize = True
        Me.lbl_error_surtir.BackColor = System.Drawing.Color.DarkRed
        Me.lbl_error_surtir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_error_surtir.ForeColor = System.Drawing.Color.White
        Me.lbl_error_surtir.Location = New System.Drawing.Point(7, 45)
        Me.lbl_error_surtir.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lbl_error_surtir.MinimumSize = New System.Drawing.Size(600, 0)
        Me.lbl_error_surtir.Name = "lbl_error_surtir"
        Me.lbl_error_surtir.Size = New System.Drawing.Size(600, 13)
        Me.lbl_error_surtir.TabIndex = 6
        Me.lbl_error_surtir.Text = "NO SE PUEDE ENTREGAR ESTE APARTADO. FALTAN LOS SIGUIENTES PRODUCTOS:"
        Me.lbl_error_surtir.Visible = False
        '
        'lbl_error_surtir_detalle
        '
        Me.lbl_error_surtir_detalle.AutoSize = True
        Me.lbl_error_surtir_detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_error_surtir_detalle.Location = New System.Drawing.Point(7, 67)
        Me.lbl_error_surtir_detalle.MaximumSize = New System.Drawing.Size(620, 100)
        Me.lbl_error_surtir_detalle.MinimumSize = New System.Drawing.Size(620, 100)
        Me.lbl_error_surtir_detalle.Name = "lbl_error_surtir_detalle"
        Me.lbl_error_surtir_detalle.Size = New System.Drawing.Size(620, 100)
        Me.lbl_error_surtir_detalle.TabIndex = 7
        Me.lbl_error_surtir_detalle.Text = "--"
        Me.lbl_error_surtir_detalle.Visible = False
        '
        'btn_entregar
        '
        Me.btn_entregar.BackColor = System.Drawing.Color.White
        Me.btn_entregar.Enabled = False
        Me.btn_entregar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_entregar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_entregar.Location = New System.Drawing.Point(378, 197)
        Me.btn_entregar.Name = "btn_entregar"
        Me.btn_entregar.Size = New System.Drawing.Size(125, 46)
        Me.btn_entregar.TabIndex = 5
        Me.btn_entregar.Text = "Entregar producto"
        Me.btn_entregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_entregar.UseVisualStyleBackColor = False
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
        Me.GroupBox1.Controls.Add(Me.gb_botones)
        Me.GroupBox1.Controls.Add(Me.lbl_total)
        Me.GroupBox1.Controls.Add(Me.lbl_otros)
        Me.GroupBox1.Controls.Add(Me.lbl_iva)
        Me.GroupBox1.Controls.Add(Me.lbl_subtotal)
        Me.GroupBox1.Controls.Add(Me.lbl_fecha_hora)
        Me.GroupBox1.Controls.Add(Me.lbl_entregado)
        Me.GroupBox1.Controls.Add(Me.lbl_dias_faltantes)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl_num_apartado)
        Me.GroupBox1.Controls.Add(Me.gb_productos)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 640)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'gb_botones
        '
        Me.gb_botones.Controls.Add(Me.btn_salir)
        Me.gb_botones.Controls.Add(Me.btn_generar_nota_venta)
        Me.gb_botones.Controls.Add(Me.btn_cancelar)
        Me.gb_botones.Location = New System.Drawing.Point(284, 517)
        Me.gb_botones.Name = "gb_botones"
        Me.gb_botones.Size = New System.Drawing.Size(388, 119)
        Me.gb_botones.TabIndex = 77
        Me.gb_botones.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(218, 13)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(89, 103)
        Me.btn_salir.TabIndex = 74
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'lbl_total
        '
        Me.lbl_total.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(122, 600)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.ReadOnly = True
        Me.lbl_total.Size = New System.Drawing.Size(136, 33)
        Me.lbl_total.TabIndex = 76
        Me.lbl_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_otros
        '
        Me.lbl_otros.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_otros.Location = New System.Drawing.Point(122, 574)
        Me.lbl_otros.Name = "lbl_otros"
        Me.lbl_otros.ReadOnly = True
        Me.lbl_otros.Size = New System.Drawing.Size(136, 23)
        Me.lbl_otros.TabIndex = 76
        Me.lbl_otros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_iva
        '
        Me.lbl_iva.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_iva.Location = New System.Drawing.Point(122, 547)
        Me.lbl_iva.Name = "lbl_iva"
        Me.lbl_iva.ReadOnly = True
        Me.lbl_iva.Size = New System.Drawing.Size(136, 23)
        Me.lbl_iva.TabIndex = 76
        Me.lbl_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_subtotal
        '
        Me.lbl_subtotal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_subtotal.Location = New System.Drawing.Point(122, 520)
        Me.lbl_subtotal.Name = "lbl_subtotal"
        Me.lbl_subtotal.ReadOnly = True
        Me.lbl_subtotal.Size = New System.Drawing.Size(136, 23)
        Me.lbl_subtotal.TabIndex = 76
        Me.lbl_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_fecha_hora
        '
        Me.lbl_fecha_hora.Location = New System.Drawing.Point(189, 57)
        Me.lbl_fecha_hora.Name = "lbl_fecha_hora"
        Me.lbl_fecha_hora.ReadOnly = True
        Me.lbl_fecha_hora.Size = New System.Drawing.Size(469, 27)
        Me.lbl_fecha_hora.TabIndex = 12
        '
        'lbl_entregado
        '
        Me.lbl_entregado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_entregado.Location = New System.Drawing.Point(454, 25)
        Me.lbl_entregado.Name = "lbl_entregado"
        Me.lbl_entregado.ReadOnly = True
        Me.lbl_entregado.Size = New System.Drawing.Size(204, 26)
        Me.lbl_entregado.TabIndex = 75
        Me.lbl_entregado.Text = "--"
        Me.lbl_entregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_dias_faltantes
        '
        Me.lbl_dias_faltantes.AutoSize = True
        Me.lbl_dias_faltantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dias_faltantes.ForeColor = System.Drawing.Color.Black
        Me.lbl_dias_faltantes.Location = New System.Drawing.Point(268, 23)
        Me.lbl_dias_faltantes.Name = "lbl_dias_faltantes"
        Me.lbl_dias_faltantes.Size = New System.Drawing.Size(21, 20)
        Me.lbl_dias_faltantes.TabIndex = 10
        Me.lbl_dias_faltantes.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 608)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Total:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 580)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 17)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Total otros:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 553)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 17)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Total IVA:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(35, 523)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Subtotal:"
        '
        'lbl_num_apartado
        '
        Me.lbl_num_apartado.AutoSize = True
        Me.lbl_num_apartado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_num_apartado.Location = New System.Drawing.Point(108, 19)
        Me.lbl_num_apartado.Name = "lbl_num_apartado"
        Me.lbl_num_apartado.Size = New System.Drawing.Size(28, 25)
        Me.lbl_num_apartado.TabIndex = 8
        Me.lbl_num_apartado.Text = "--"
        '
        'gb_productos
        '
        Me.gb_productos.Controls.Add(Me.tb_opciones)
        Me.gb_productos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_productos.Location = New System.Drawing.Point(9, 205)
        Me.gb_productos.Name = "gb_productos"
        Me.gb_productos.Size = New System.Drawing.Size(663, 309)
        Me.gb_productos.TabIndex = 7
        Me.gb_productos.TabStop = False
        Me.gb_productos.Text = "Productos"
        '
        'tb_opciones
        '
        Me.tb_opciones.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tb_opciones.Controls.Add(Me.tab_productos)
        Me.tb_opciones.Controls.Add(Me.tab_almacenes)
        Me.tb_opciones.Controls.Add(Me.tab_pagos)
        Me.tb_opciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_opciones.Location = New System.Drawing.Point(8, 21)
        Me.tb_opciones.Name = "tb_opciones"
        Me.tb_opciones.SelectedIndex = 0
        Me.tb_opciones.Size = New System.Drawing.Size(649, 285)
        Me.tb_opciones.TabIndex = 18
        '
        'tab_productos
        '
        Me.tab_productos.BackColor = System.Drawing.Color.White
        Me.tab_productos.Controls.Add(Me.GroupBox3)
        Me.tab_productos.Controls.Add(Me.dg_productos)
        Me.tab_productos.Location = New System.Drawing.Point(4, 29)
        Me.tab_productos.Name = "tab_productos"
        Me.tab_productos.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_productos.Size = New System.Drawing.Size(641, 252)
        Me.tab_productos.TabIndex = 0
        Me.tab_productos.Text = "Productos"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tb_comentarios)
        Me.GroupBox3.Controls.Add(Me.btn_guardar_observaciones)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 166)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(627, 82)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Observaciones:"
        '
        'tb_comentarios
        '
        Me.tb_comentarios.Location = New System.Drawing.Point(8, 19)
        Me.tb_comentarios.Multiline = True
        Me.tb_comentarios.Name = "tb_comentarios"
        Me.tb_comentarios.Size = New System.Drawing.Size(478, 57)
        Me.tb_comentarios.TabIndex = 21
        '
        'btn_guardar_observaciones
        '
        Me.btn_guardar_observaciones.BackColor = System.Drawing.Color.White
        Me.btn_guardar_observaciones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_observaciones.Image = CType(resources.GetObject("btn_guardar_observaciones.Image"), System.Drawing.Image)
        Me.btn_guardar_observaciones.Location = New System.Drawing.Point(502, 19)
        Me.btn_guardar_observaciones.Name = "btn_guardar_observaciones"
        Me.btn_guardar_observaciones.Size = New System.Drawing.Size(119, 57)
        Me.btn_guardar_observaciones.TabIndex = 20
        Me.btn_guardar_observaciones.Text = "Guardar"
        Me.btn_guardar_observaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_guardar_observaciones.UseVisualStyleBackColor = False
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
        Me.dg_productos.Location = New System.Drawing.Point(6, 6)
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
        Me.dg_productos.Size = New System.Drawing.Size(629, 158)
        Me.dg_productos.TabIndex = 2
        '
        'tab_almacenes
        '
        Me.tab_almacenes.BackColor = System.Drawing.Color.White
        Me.tab_almacenes.Controls.Add(Me.lbl_error_surtir)
        Me.tab_almacenes.Controls.Add(Me.Label9)
        Me.tab_almacenes.Controls.Add(Me.cb_agente_entrega)
        Me.tab_almacenes.Controls.Add(Me.btn_enviar_apartado)
        Me.tab_almacenes.Controls.Add(Me.lbl_agente)
        Me.tab_almacenes.Controls.Add(Me.lbl_error_surtir_detalle)
        Me.tab_almacenes.Controls.Add(Me.cb_almacenes)
        Me.tab_almacenes.Controls.Add(Me.btn_entregar)
        Me.tab_almacenes.Location = New System.Drawing.Point(4, 29)
        Me.tab_almacenes.Name = "tab_almacenes"
        Me.tab_almacenes.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_almacenes.Size = New System.Drawing.Size(641, 252)
        Me.tab_almacenes.TabIndex = 1
        Me.tab_almacenes.Text = "Almacenes"
        '
        'tab_pagos
        '
        Me.tab_pagos.Controls.Add(Me.lbl_saldo)
        Me.tab_pagos.Controls.Add(Me.lbl_cobros)
        Me.tab_pagos.Controls.Add(Me.btn_imprimir_abono)
        Me.tab_pagos.Controls.Add(Me.btn_cancelar_pago)
        Me.tab_pagos.Controls.Add(Me.btn_cobrar)
        Me.tab_pagos.Controls.Add(Me.dgv_abonos)
        Me.tab_pagos.Controls.Add(Me.Label12)
        Me.tab_pagos.Controls.Add(Me.Label11)
        Me.tab_pagos.Location = New System.Drawing.Point(4, 29)
        Me.tab_pagos.Name = "tab_pagos"
        Me.tab_pagos.Size = New System.Drawing.Size(641, 252)
        Me.tab_pagos.TabIndex = 2
        Me.tab_pagos.Text = "Pagos"
        Me.tab_pagos.UseVisualStyleBackColor = True
        '
        'lbl_saldo
        '
        Me.lbl_saldo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo.Location = New System.Drawing.Point(524, 218)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.ReadOnly = True
        Me.lbl_saldo.Size = New System.Drawing.Size(101, 27)
        Me.lbl_saldo.TabIndex = 10
        Me.lbl_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_cobros
        '
        Me.lbl_cobros.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cobros.Location = New System.Drawing.Point(524, 185)
        Me.lbl_cobros.Name = "lbl_cobros"
        Me.lbl_cobros.ReadOnly = True
        Me.lbl_cobros.Size = New System.Drawing.Size(101, 27)
        Me.lbl_cobros.TabIndex = 10
        Me.lbl_cobros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_imprimir_abono
        '
        Me.btn_imprimir_abono.BackColor = System.Drawing.Color.White
        Me.btn_imprimir_abono.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_abono.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_imprimir_abono.Location = New System.Drawing.Point(141, 185)
        Me.btn_imprimir_abono.Name = "btn_imprimir_abono"
        Me.btn_imprimir_abono.Size = New System.Drawing.Size(127, 60)
        Me.btn_imprimir_abono.TabIndex = 20
        Me.btn_imprimir_abono.Text = "Imprimir comprobante"
        Me.btn_imprimir_abono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_imprimir_abono.UseVisualStyleBackColor = False
        '
        'btn_cancelar_pago
        '
        Me.btn_cancelar_pago.BackColor = System.Drawing.Color.White
        Me.btn_cancelar_pago.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_pago.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cancelar_pago.Location = New System.Drawing.Point(274, 185)
        Me.btn_cancelar_pago.Name = "btn_cancelar_pago"
        Me.btn_cancelar_pago.Size = New System.Drawing.Size(127, 60)
        Me.btn_cancelar_pago.TabIndex = 20
        Me.btn_cancelar_pago.Text = "Cancelar pago"
        Me.btn_cancelar_pago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar_pago.UseVisualStyleBackColor = False
        '
        'btn_cobrar
        '
        Me.btn_cobrar.BackColor = System.Drawing.Color.White
        Me.btn_cobrar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cobrar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cobrar.Location = New System.Drawing.Point(11, 186)
        Me.btn_cobrar.Name = "btn_cobrar"
        Me.btn_cobrar.Size = New System.Drawing.Size(127, 60)
        Me.btn_cobrar.TabIndex = 20
        Me.btn_cobrar.Text = "Registrar pago"
        Me.btn_cobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cobrar.UseVisualStyleBackColor = False
        '
        'dgv_abonos
        '
        Me.dgv_abonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_abonos.Location = New System.Drawing.Point(11, 8)
        Me.dgv_abonos.MultiSelect = False
        Me.dgv_abonos.Name = "dgv_abonos"
        Me.dgv_abonos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_abonos.Size = New System.Drawing.Size(614, 172)
        Me.dgv_abonos.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(410, 191)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 21)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Totol cobros:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(461, 224)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 21)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Saldo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tb_vendedor)
        Me.GroupBox2.Controls.Add(Me.lbl_telefono)
        Me.GroupBox2.Controls.Add(Me.lbl_direccion)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lbl_nombre)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(666, 114)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'tb_vendedor
        '
        Me.tb_vendedor.Location = New System.Drawing.Point(396, 79)
        Me.tb_vendedor.Name = "tb_vendedor"
        Me.tb_vendedor.ReadOnly = True
        Me.tb_vendedor.Size = New System.Drawing.Size(260, 26)
        Me.tb_vendedor.TabIndex = 12
        '
        'lbl_telefono
        '
        Me.lbl_telefono.Location = New System.Drawing.Point(92, 79)
        Me.lbl_telefono.Name = "lbl_telefono"
        Me.lbl_telefono.ReadOnly = True
        Me.lbl_telefono.Size = New System.Drawing.Size(191, 26)
        Me.lbl_telefono.TabIndex = 12
        '
        'lbl_direccion
        '
        Me.lbl_direccion.Location = New System.Drawing.Point(92, 47)
        Me.lbl_direccion.Name = "lbl_direccion"
        Me.lbl_direccion.ReadOnly = True
        Me.lbl_direccion.Size = New System.Drawing.Size(564, 26)
        Me.lbl_direccion.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(302, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Vendedor:"
        '
        'lbl_nombre
        '
        Me.lbl_nombre.Location = New System.Drawing.Point(92, 16)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.ReadOnly = True
        Me.lbl_nombre.Size = New System.Drawing.Size(564, 26)
        Me.lbl_nombre.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 20)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Telefono:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Direccion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha -Hora de Entrega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Apartado:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_aviso_cancelado
        '
        Me.tb_aviso_cancelado.AutoSize = True
        Me.tb_aviso_cancelado.BackColor = System.Drawing.Color.DarkRed
        Me.tb_aviso_cancelado.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_aviso_cancelado.ForeColor = System.Drawing.Color.White
        Me.tb_aviso_cancelado.Location = New System.Drawing.Point(12, 9)
        Me.tb_aviso_cancelado.MaximumSize = New System.Drawing.Size(660, 25)
        Me.tb_aviso_cancelado.MinimumSize = New System.Drawing.Size(660, 25)
        Me.tb_aviso_cancelado.Name = "tb_aviso_cancelado"
        Me.tb_aviso_cancelado.Size = New System.Drawing.Size(660, 25)
        Me.tb_aviso_cancelado.TabIndex = 18
        Me.tb_aviso_cancelado.Text = "C ANCELADO"
        Me.tb_aviso_cancelado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tb_aviso_cancelado.Visible = False
        '
        'frm_apartado_detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(690, 671)
        Me.Controls.Add(Me.tb_aviso_cancelado)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_apartado_detalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apartado producto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_botones.ResumeLayout(False)
        Me.gb_productos.ResumeLayout(False)
        Me.tb_opciones.ResumeLayout(False)
        Me.tab_productos.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_almacenes.ResumeLayout(False)
        Me.tab_almacenes.PerformLayout()
        Me.tab_pagos.ResumeLayout(False)
        Me.tab_pagos.PerformLayout()
        CType(Me.dgv_abonos, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents gb_productos As System.Windows.Forms.GroupBox
    Private WithEvents dg_productos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_num_apartado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_generar_nota_venta As System.Windows.Forms.Button
    Friend WithEvents lbl_error_surtir_detalle As System.Windows.Forms.Label
    Friend WithEvents lbl_error_surtir As System.Windows.Forms.Label
    Friend WithEvents btn_entregar As System.Windows.Forms.Button
    Friend WithEvents cb_almacenes As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_dias_faltantes As System.Windows.Forms.Label
    Friend WithEvents cb_agente_entrega As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_agente As System.Windows.Forms.Label
    Friend WithEvents btn_enviar_apartado As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents lbl_entregado As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tab_productos As System.Windows.Forms.TabPage
    Friend WithEvents tab_almacenes As System.Windows.Forms.TabPage
    Private WithEvents tb_opciones As System.Windows.Forms.TabControl
    Friend WithEvents btn_cobrar As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbl_nombre As System.Windows.Forms.TextBox
    Friend WithEvents lbl_fecha_hora As System.Windows.Forms.TextBox
    Friend WithEvents lbl_telefono As System.Windows.Forms.TextBox
    Friend WithEvents lbl_direccion As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar_observaciones As System.Windows.Forms.Button
    Friend WithEvents tab_pagos As System.Windows.Forms.TabPage
    Friend WithEvents lbl_saldo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_cobros As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar_pago As System.Windows.Forms.Button
    Friend WithEvents dgv_abonos As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_total As System.Windows.Forms.TextBox
    Friend WithEvents lbl_otros As System.Windows.Forms.TextBox
    Friend WithEvents lbl_iva As System.Windows.Forms.TextBox
    Friend WithEvents lbl_subtotal As System.Windows.Forms.TextBox
    Private WithEvents tb_aviso_cancelado As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents gb_botones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_imprimir_abono As System.Windows.Forms.Button
    Friend WithEvents tb_vendedor As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
