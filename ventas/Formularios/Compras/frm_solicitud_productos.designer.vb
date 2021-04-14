<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_solicitud_productos
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
        Me.btn_generar_orden = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gb_insumos = New System.Windows.Forms.GroupBox()
        Me.btn_eliminar_seleccion = New System.Windows.Forms.Button()
        Me.dgv_solicitud_productos = New System.Windows.Forms.DataGridView()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.tb_impuestos = New System.Windows.Forms.TextBox()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_aviso_cancelado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_partida = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.dtp_hora = New System.Windows.Forms.DateTimePicker()
        Me.tb_persona_elabora = New System.Windows.Forms.TextBox()
        Me.tb_estatus = New System.Windows.Forms.TextBox()
        Me.tb_folio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_solicitud = New System.Windows.Forms.TabControl()
        Me.tab_solicitud = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_solicitudes = New System.Windows.Forms.DataGridView()
        Me.cb_opciones_busqueda_sol = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtp_fecha_termino_sol = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio_sol = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_busqueda_sol = New System.Windows.Forms.DateTimePicker()
        Me.btn_buscar_solicitud = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_folio_busqueda = New System.Windows.Forms.TextBox()
        Me.tab_origen = New System.Windows.Forms.TabPage()
        Me.gb_busqueda = New System.Windows.Forms.GroupBox()
        Me.dgv_busqueda = New System.Windows.Forms.DataGridView()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.cb_opciones_busqueda = New System.Windows.Forms.ComboBox()
        Me.lbl_origen = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_termino = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_busqueda = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_ocultar = New System.Windows.Forms.Button()
        Me.btn_mostrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gb_insumos.SuspendLayout()
        CType(Me.dgv_solicitud_productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.tb_solicitud.SuspendLayout()
        Me.tab_solicitud.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_solicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_origen.SuspendLayout()
        Me.gb_busqueda.SuspendLayout()
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_generar_orden
        '
        Me.btn_generar_orden.Location = New System.Drawing.Point(0, 0)
        Me.btn_generar_orden.Name = "btn_generar_orden"
        Me.btn_generar_orden.Size = New System.Drawing.Size(75, 23)
        Me.btn_generar_orden.TabIndex = 0
        '
        'btn_deshacer
        '
        Me.btn_deshacer.Location = New System.Drawing.Point(0, 0)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(75, 23)
        Me.btn_deshacer.TabIndex = 0
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(0, 0)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 0
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Location = New System.Drawing.Point(0, 0)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(75, 23)
        Me.btn_nuevo.TabIndex = 0
        '
        'btn_editar
        '
        Me.btn_editar.Location = New System.Drawing.Point(0, 0)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(75, 23)
        Me.btn_editar.TabIndex = 0
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(0, 0)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(75, 23)
        Me.btn_guardar.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TabControl1.Location = New System.Drawing.Point(12, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1012, 547)
        Me.TabControl1.TabIndex = 32
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1004, 521)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Solicitud de productos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gb_insumos)
        Me.GroupBox3.Controls.Add(Me.tb_total)
        Me.GroupBox3.Controls.Add(Me.tb_impuestos)
        Me.GroupBox3.Controls.Add(Me.tb_subtotal)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(-2, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1000, 517)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informacion"
        '
        'gb_insumos
        '
        Me.gb_insumos.Controls.Add(Me.btn_eliminar_seleccion)
        Me.gb_insumos.Controls.Add(Me.dgv_solicitud_productos)
        Me.gb_insumos.Location = New System.Drawing.Point(6, 104)
        Me.gb_insumos.Name = "gb_insumos"
        Me.gb_insumos.Size = New System.Drawing.Size(988, 333)
        Me.gb_insumos.TabIndex = 31
        Me.gb_insumos.TabStop = False
        Me.gb_insumos.Text = "Insumos"
        '
        'btn_eliminar_seleccion
        '
        Me.btn_eliminar_seleccion.Location = New System.Drawing.Point(6, 299)
        Me.btn_eliminar_seleccion.Name = "btn_eliminar_seleccion"
        Me.btn_eliminar_seleccion.Size = New System.Drawing.Size(150, 23)
        Me.btn_eliminar_seleccion.TabIndex = 30
        Me.btn_eliminar_seleccion.Text = "Eliminar Seleccionados"
        Me.btn_eliminar_seleccion.UseVisualStyleBackColor = True
        '
        'dgv_solicitud_productos
        '
        Me.dgv_solicitud_productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_solicitud_productos.Location = New System.Drawing.Point(6, 16)
        Me.dgv_solicitud_productos.MultiSelect = False
        Me.dgv_solicitud_productos.Name = "dgv_solicitud_productos"
        Me.dgv_solicitud_productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_solicitud_productos.Size = New System.Drawing.Size(976, 279)
        Me.dgv_solicitud_productos.TabIndex = 1
        '
        'tb_total
        '
        Me.tb_total.Location = New System.Drawing.Point(78, 491)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(113, 20)
        Me.tb_total.TabIndex = 3
        '
        'tb_impuestos
        '
        Me.tb_impuestos.Location = New System.Drawing.Point(78, 468)
        Me.tb_impuestos.Name = "tb_impuestos"
        Me.tb_impuestos.ReadOnly = True
        Me.tb_impuestos.Size = New System.Drawing.Size(113, 20)
        Me.tb_impuestos.TabIndex = 3
        '
        'tb_subtotal
        '
        Me.tb_subtotal.Location = New System.Drawing.Point(78, 443)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.ReadOnly = True
        Me.tb_subtotal.Size = New System.Drawing.Size(113, 20)
        Me.tb_subtotal.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(38, 494)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Total:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 469)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Impuestos:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 446)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Subtotal:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LinkLabel1)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.tb_aviso_cancelado)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.cb_partida)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.dtp_fecha)
        Me.GroupBox5.Controls.Add(Me.dtp_hora)
        Me.GroupBox5.Controls.Add(Me.tb_persona_elabora)
        Me.GroupBox5.Controls.Add(Me.tb_estatus)
        Me.GroupBox5.Controls.Add(Me.tb_folio)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(780, 88)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(327, 66)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(43, 13)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "000001"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(218, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Ordenes de compra:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(596, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Estatus:"
        '
        'tb_aviso_cancelado
        '
        Me.tb_aviso_cancelado.AutoSize = True
        Me.tb_aviso_cancelado.BackColor = System.Drawing.Color.DarkRed
        Me.tb_aviso_cancelado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_aviso_cancelado.ForeColor = System.Drawing.Color.White
        Me.tb_aviso_cancelado.Location = New System.Drawing.Point(411, 39)
        Me.tb_aviso_cancelado.MaximumSize = New System.Drawing.Size(350, 20)
        Me.tb_aviso_cancelado.MinimumSize = New System.Drawing.Size(350, 20)
        Me.tb_aviso_cancelado.Name = "tb_aviso_cancelado"
        Me.tb_aviso_cancelado.Size = New System.Drawing.Size(350, 20)
        Me.tb_aviso_cancelado.TabIndex = 8
        Me.tb_aviso_cancelado.Text = "C ANCELADO"
        Me.tb_aviso_cancelado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tb_aviso_cancelado.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Filtrar:"
        '
        'cb_partida
        '
        Me.cb_partida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_partida.FormattingEnabled = True
        Me.cb_partida.Location = New System.Drawing.Point(84, 63)
        Me.cb_partida.Name = "cb_partida"
        Me.cb_partida.Size = New System.Drawing.Size(85, 21)
        Me.cb_partida.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Elaboró:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Folio:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Enabled = False
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(269, 13)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(123, 20)
        Me.dtp_fecha.TabIndex = 3
        '
        'dtp_hora
        '
        Me.dtp_hora.Enabled = False
        Me.dtp_hora.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_hora.Location = New System.Drawing.Point(456, 14)
        Me.dtp_hora.Name = "dtp_hora"
        Me.dtp_hora.Size = New System.Drawing.Size(123, 20)
        Me.dtp_hora.TabIndex = 3
        '
        'tb_persona_elabora
        '
        Me.tb_persona_elabora.Location = New System.Drawing.Point(84, 37)
        Me.tb_persona_elabora.Name = "tb_persona_elabora"
        Me.tb_persona_elabora.ReadOnly = True
        Me.tb_persona_elabora.Size = New System.Drawing.Size(222, 20)
        Me.tb_persona_elabora.TabIndex = 3
        '
        'tb_estatus
        '
        Me.tb_estatus.Location = New System.Drawing.Point(647, 14)
        Me.tb_estatus.Name = "tb_estatus"
        Me.tb_estatus.ReadOnly = True
        Me.tb_estatus.Size = New System.Drawing.Size(114, 20)
        Me.tb_estatus.TabIndex = 3
        '
        'tb_folio
        '
        Me.tb_folio.Location = New System.Drawing.Point(84, 13)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.ReadOnly = True
        Me.tb_folio.Size = New System.Drawing.Size(107, 20)
        Me.tb_folio.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(218, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Fecha:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(417, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Hora:"
        '
        'tb_solicitud
        '
        Me.tb_solicitud.Controls.Add(Me.tab_solicitud)
        Me.tb_solicitud.Controls.Add(Me.tab_origen)
        Me.tb_solicitud.Location = New System.Drawing.Point(5, 6)
        Me.tb_solicitud.Name = "tb_solicitud"
        Me.tb_solicitud.SelectedIndex = 0
        Me.tb_solicitud.Size = New System.Drawing.Size(317, 545)
        Me.tb_solicitud.TabIndex = 2
        '
        'tab_solicitud
        '
        Me.tab_solicitud.Controls.Add(Me.GroupBox1)
        Me.tab_solicitud.Controls.Add(Me.btn_buscar_solicitud)
        Me.tab_solicitud.Controls.Add(Me.Label16)
        Me.tab_solicitud.Controls.Add(Me.tb_folio_busqueda)
        Me.tab_solicitud.Location = New System.Drawing.Point(4, 22)
        Me.tab_solicitud.Name = "tab_solicitud"
        Me.tab_solicitud.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_solicitud.Size = New System.Drawing.Size(309, 519)
        Me.tab_solicitud.TabIndex = 0
        Me.tab_solicitud.Text = "Solicitudes"
        Me.tab_solicitud.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_solicitudes)
        Me.GroupBox1.Controls.Add(Me.cb_opciones_busqueda_sol)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_termino_sol)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_inicio_sol)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_busqueda_sol)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(299, 477)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'dgv_solicitudes
        '
        Me.dgv_solicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_solicitudes.Location = New System.Drawing.Point(10, 72)
        Me.dgv_solicitudes.Name = "dgv_solicitudes"
        Me.dgv_solicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_solicitudes.Size = New System.Drawing.Size(285, 399)
        Me.dgv_solicitudes.TabIndex = 8
        '
        'cb_opciones_busqueda_sol
        '
        Me.cb_opciones_busqueda_sol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_opciones_busqueda_sol.FormattingEnabled = True
        Me.cb_opciones_busqueda_sol.Location = New System.Drawing.Point(80, 17)
        Me.cb_opciones_busqueda_sol.Name = "cb_opciones_busqueda_sol"
        Me.cb_opciones_busqueda_sol.Size = New System.Drawing.Size(107, 21)
        Me.cb_opciones_busqueda_sol.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(5, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Mostrar:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(171, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "a:"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "De:"
        Me.Label12.Visible = False
        '
        'dtp_fecha_termino_sol
        '
        Me.dtp_fecha_termino_sol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino_sol.Location = New System.Drawing.Point(193, 46)
        Me.dtp_fecha_termino_sol.Name = "dtp_fecha_termino_sol"
        Me.dtp_fecha_termino_sol.Size = New System.Drawing.Size(102, 20)
        Me.dtp_fecha_termino_sol.TabIndex = 3
        Me.dtp_fecha_termino_sol.Visible = False
        '
        'dtp_fecha_inicio_sol
        '
        Me.dtp_fecha_inicio_sol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_sol.Location = New System.Drawing.Point(50, 46)
        Me.dtp_fecha_inicio_sol.Name = "dtp_fecha_inicio_sol"
        Me.dtp_fecha_inicio_sol.Size = New System.Drawing.Size(99, 20)
        Me.dtp_fecha_inicio_sol.TabIndex = 3
        Me.dtp_fecha_inicio_sol.Visible = False
        '
        'dtp_fecha_busqueda_sol
        '
        Me.dtp_fecha_busqueda_sol.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_busqueda_sol.Location = New System.Drawing.Point(193, 20)
        Me.dtp_fecha_busqueda_sol.Name = "dtp_fecha_busqueda_sol"
        Me.dtp_fecha_busqueda_sol.Size = New System.Drawing.Size(102, 20)
        Me.dtp_fecha_busqueda_sol.TabIndex = 3
        Me.dtp_fecha_busqueda_sol.Visible = False
        '
        'btn_buscar_solicitud
        '
        Me.btn_buscar_solicitud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btn_buscar_solicitud.Location = New System.Drawing.Point(165, 6)
        Me.btn_buscar_solicitud.Name = "btn_buscar_solicitud"
        Me.btn_buscar_solicitud.Size = New System.Drawing.Size(106, 27)
        Me.btn_buscar_solicitud.TabIndex = 34
        Me.btn_buscar_solicitud.Text = "Buscar folio"
        Me.btn_buscar_solicitud.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label16.Location = New System.Drawing.Point(25, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Folio"
        '
        'tb_folio_busqueda
        '
        Me.tb_folio_busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tb_folio_busqueda.Location = New System.Drawing.Point(96, 10)
        Me.tb_folio_busqueda.Name = "tb_folio_busqueda"
        Me.tb_folio_busqueda.Size = New System.Drawing.Size(63, 20)
        Me.tb_folio_busqueda.TabIndex = 32
        '
        'tab_origen
        '
        Me.tab_origen.Controls.Add(Me.gb_busqueda)
        Me.tab_origen.Location = New System.Drawing.Point(4, 22)
        Me.tab_origen.Name = "tab_origen"
        Me.tab_origen.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_origen.Size = New System.Drawing.Size(309, 519)
        Me.tab_origen.TabIndex = 1
        Me.tab_origen.Text = "Origen de Solicitud"
        Me.tab_origen.UseVisualStyleBackColor = True
        '
        'gb_busqueda
        '
        Me.gb_busqueda.Controls.Add(Me.dgv_busqueda)
        Me.gb_busqueda.Controls.Add(Me.ComboBox9)
        Me.gb_busqueda.Controls.Add(Me.ComboBox3)
        Me.gb_busqueda.Controls.Add(Me.ComboBox2)
        Me.gb_busqueda.Controls.Add(Me.Label21)
        Me.gb_busqueda.Controls.Add(Me.ComboBox1)
        Me.gb_busqueda.Controls.Add(Me.Label20)
        Me.gb_busqueda.Controls.Add(Me.cb_opciones_busqueda)
        Me.gb_busqueda.Controls.Add(Me.Label19)
        Me.gb_busqueda.Controls.Add(Me.lbl_origen)
        Me.gb_busqueda.Controls.Add(Me.Label3)
        Me.gb_busqueda.Controls.Add(Me.Label2)
        Me.gb_busqueda.Controls.Add(Me.Label1)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_termino)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_inicio)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_busqueda)
        Me.gb_busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.gb_busqueda.Location = New System.Drawing.Point(7, 4)
        Me.gb_busqueda.Name = "gb_busqueda"
        Me.gb_busqueda.Size = New System.Drawing.Size(299, 588)
        Me.gb_busqueda.TabIndex = 28
        Me.gb_busqueda.TabStop = False
        Me.gb_busqueda.Text = "Busqueda"
        '
        'dgv_busqueda
        '
        Me.dgv_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_busqueda.Location = New System.Drawing.Point(6, 193)
        Me.dgv_busqueda.Name = "dgv_busqueda"
        Me.dgv_busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_busqueda.Size = New System.Drawing.Size(285, 319)
        Me.dgv_busqueda.TabIndex = 8
        '
        'ComboBox9
        '
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(80, 17)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(215, 21)
        Me.ComboBox9.TabIndex = 10
        '
        'cb_opciones_busqueda
        '
        Me.cb_opciones_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_opciones_busqueda.FormattingEnabled = True
        Me.cb_opciones_busqueda.Location = New System.Drawing.Point(80, 44)
        Me.cb_opciones_busqueda.Name = "cb_opciones_busqueda"
        Me.cb_opciones_busqueda.Size = New System.Drawing.Size(107, 21)
        Me.cb_opciones_busqueda.TabIndex = 7
        '
        'lbl_origen
        '
        Me.lbl_origen.AutoSize = True
        Me.lbl_origen.Location = New System.Drawing.Point(9, 22)
        Me.lbl_origen.Name = "lbl_origen"
        Me.lbl_origen.Size = New System.Drawing.Size(41, 13)
        Me.lbl_origen.TabIndex = 6
        Me.lbl_origen.Text = "Origen:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mostrar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "a:"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "De:"
        Me.Label1.Visible = False
        '
        'dtp_fecha_termino
        '
        Me.dtp_fecha_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino.Location = New System.Drawing.Point(193, 73)
        Me.dtp_fecha_termino.Name = "dtp_fecha_termino"
        Me.dtp_fecha_termino.Size = New System.Drawing.Size(102, 20)
        Me.dtp_fecha_termino.TabIndex = 3
        Me.dtp_fecha_termino.Visible = False
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(50, 73)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(99, 20)
        Me.dtp_fecha_inicio.TabIndex = 3
        Me.dtp_fecha_inicio.Visible = False
        '
        'dtp_fecha_busqueda
        '
        Me.dtp_fecha_busqueda.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_busqueda.Location = New System.Drawing.Point(193, 47)
        Me.dtp_fecha_busqueda.Name = "dtp_fecha_busqueda"
        Me.dtp_fecha_busqueda.Size = New System.Drawing.Size(102, 20)
        Me.dtp_fecha_busqueda.TabIndex = 3
        Me.dtp_fecha_busqueda.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tb_solicitud)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 554)
        Me.Panel1.TabIndex = 36
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_ocultar)
        Me.Panel3.Controls.Add(Me.btn_mostrar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(322, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(17, 554)
        Me.Panel3.TabIndex = 109
        '
        'btn_ocultar
        '
        Me.btn_ocultar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_ocultar.Location = New System.Drawing.Point(0, 265)
        Me.btn_ocultar.Name = "btn_ocultar"
        Me.btn_ocultar.Size = New System.Drawing.Size(17, 100)
        Me.btn_ocultar.TabIndex = 13
        Me.btn_ocultar.UseVisualStyleBackColor = True
        '
        'btn_mostrar
        '
        Me.btn_mostrar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_mostrar.Location = New System.Drawing.Point(0, 163)
        Me.btn_mostrar.Name = "btn_mostrar"
        Me.btn_mostrar.Size = New System.Drawing.Size(17, 100)
        Me.btn_mostrar.TabIndex = 12
        Me.btn_mostrar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(339, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1032, 554)
        Me.Panel2.TabIndex = 110
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(5, 102)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Categoria:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(80, 99)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(107, 21)
        Me.ComboBox1.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(5, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Marca:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(80, 126)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(107, 21)
        Me.ComboBox2.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(5, 156)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Modelo:"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(80, 153)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(107, 21)
        Me.ComboBox3.TabIndex = 7
        '
        'frm_solicitud_productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1375, 554)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_solicitud_productos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Solicitud de Productos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gb_insumos.ResumeLayout(False)
        CType(Me.dgv_solicitud_productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tb_solicitud.ResumeLayout(False)
        Me.tab_solicitud.ResumeLayout(False)
        Me.tab_solicitud.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_solicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_origen.ResumeLayout(False)
        Me.gb_busqueda.ResumeLayout(False)
        Me.gb_busqueda.PerformLayout()
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_opciones_doc As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_partida As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents tb_aviso_cancelado As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_hora As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_persona_elabora As System.Windows.Forms.TextBox
    Friend WithEvents tb_folio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_solicitud As System.Windows.Forms.TabControl
    Friend WithEvents tab_solicitud As System.Windows.Forms.TabPage
    Friend WithEvents tab_origen As System.Windows.Forms.TabPage
    Friend WithEvents gb_busqueda As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_busqueda As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents cb_opciones_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_origen As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_busqueda As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_solicitudes As System.Windows.Forms.DataGridView
    Friend WithEvents cb_opciones_busqueda_sol As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_termino_sol As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio_sol As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_busqueda_sol As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_buscar_solicitud As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_folio_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents tb_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_estatus As System.Windows.Forms.TextBox
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_generar_orden As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btn_ocultar As System.Windows.Forms.Button
    Friend WithEvents btn_mostrar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btn_eliminar_seleccion As System.Windows.Forms.Button
    Friend WithEvents gb_insumos As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_solicitud_productos As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
