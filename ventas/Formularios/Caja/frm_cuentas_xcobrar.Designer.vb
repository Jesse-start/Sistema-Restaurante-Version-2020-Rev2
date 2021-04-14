<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cuentas_xcobrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cuentas_xcobrar))
        Me.dgv_clientes = New System.Windows.Forms.DataGridView()
        Me.gb_cliente = New System.Windows.Forms.GroupBox()
        Me.gb_ticktes = New System.Windows.Forms.GroupBox()
        Me.dgv_tickets = New System.Windows.Forms.DataGridView()
        Me.btn_imprimir_pagare = New System.Windows.Forms.Button()
        Me.btn_imprimir_listado_tickets = New System.Windows.Forms.Button()
        Me.btn_imprimir_ticket = New System.Windows.Forms.Button()
        Me.btn_prefactura = New System.Windows.Forms.Button()
        Me.btn_cobrar = New System.Windows.Forms.Button()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.Label()
        Me.lbl_cliente = New System.Windows.Forms.Label()
        Me.tb_cliente = New System.Windows.Forms.Label()
        Me.lbl_abonos = New System.Windows.Forms.Label()
        Me.tb_abonos = New System.Windows.Forms.Label()
        Me.lbl_saldo = New System.Windows.Forms.Label()
        Me.tb_saldo = New System.Windows.Forms.Label()
        Me.gb_prefactura = New System.Windows.Forms.GroupBox()
        Me.dgv_prefactura = New System.Windows.Forms.DataGridView()
        Me.btn_cobrar_factura = New System.Windows.Forms.Button()
        Me.btn_imprimir_listado = New System.Windows.Forms.Button()
        Me.btn_ver_prefactura = New System.Windows.Forms.Button()
        Me.lbl_buscar = New System.Windows.Forms.Label()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.cb_tipo_cuentas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tab_cuentas_xcobrar = New System.Windows.Forms.TabControl()
        Me.tab_ticket = New System.Windows.Forms.TabPage()
        Me.tab_prefactura = New System.Windows.Forms.TabPage()
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_cliente.SuspendLayout()
        Me.gb_ticktes.SuspendLayout()
        CType(Me.dgv_tickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_prefactura.SuspendLayout()
        CType(Me.dgv_prefactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_cuentas_xcobrar.SuspendLayout()
        Me.tab_ticket.SuspendLayout()
        Me.tab_prefactura.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_clientes
        '
        Me.dgv_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_clientes.Location = New System.Drawing.Point(6, 21)
        Me.dgv_clientes.MultiSelect = False
        Me.dgv_clientes.Name = "dgv_clientes"
        Me.dgv_clientes.ReadOnly = True
        Me.dgv_clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_clientes.Size = New System.Drawing.Size(369, 314)
        Me.dgv_clientes.TabIndex = 0
        '
        'gb_cliente
        '
        Me.gb_cliente.Controls.Add(Me.dgv_clientes)
        Me.gb_cliente.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_cliente.Location = New System.Drawing.Point(1, 79)
        Me.gb_cliente.Name = "gb_cliente"
        Me.gb_cliente.Size = New System.Drawing.Size(381, 343)
        Me.gb_cliente.TabIndex = 1
        Me.gb_cliente.TabStop = False
        Me.gb_cliente.Text = "Cliente"
        '
        'gb_ticktes
        '
        Me.gb_ticktes.Controls.Add(Me.dgv_tickets)
        Me.gb_ticktes.Controls.Add(Me.btn_imprimir_pagare)
        Me.gb_ticktes.Controls.Add(Me.btn_imprimir_listado_tickets)
        Me.gb_ticktes.Controls.Add(Me.btn_imprimir_ticket)
        Me.gb_ticktes.Controls.Add(Me.btn_prefactura)
        Me.gb_ticktes.Controls.Add(Me.btn_cobrar)
        Me.gb_ticktes.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_ticktes.Location = New System.Drawing.Point(6, 6)
        Me.gb_ticktes.Name = "gb_ticktes"
        Me.gb_ticktes.Size = New System.Drawing.Size(471, 525)
        Me.gb_ticktes.TabIndex = 2
        Me.gb_ticktes.TabStop = False
        Me.gb_ticktes.Text = "Tickets"
        '
        'dgv_tickets
        '
        Me.dgv_tickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_tickets.Location = New System.Drawing.Point(6, 25)
        Me.dgv_tickets.Name = "dgv_tickets"
        Me.dgv_tickets.ReadOnly = True
        Me.dgv_tickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_tickets.Size = New System.Drawing.Size(448, 386)
        Me.dgv_tickets.TabIndex = 0
        '
        'btn_imprimir_pagare
        '
        Me.btn_imprimir_pagare.BackColor = System.Drawing.Color.White
        Me.btn_imprimir_pagare.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_pagare.Image = CType(resources.GetObject("btn_imprimir_pagare.Image"), System.Drawing.Image)
        Me.btn_imprimir_pagare.Location = New System.Drawing.Point(250, 417)
        Me.btn_imprimir_pagare.Name = "btn_imprimir_pagare"
        Me.btn_imprimir_pagare.Size = New System.Drawing.Size(76, 102)
        Me.btn_imprimir_pagare.TabIndex = 97
        Me.btn_imprimir_pagare.Text = "Imprimir Pagaré"
        Me.btn_imprimir_pagare.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir_pagare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir_pagare.UseVisualStyleBackColor = False
        '
        'btn_imprimir_listado_tickets
        '
        Me.btn_imprimir_listado_tickets.BackColor = System.Drawing.Color.White
        Me.btn_imprimir_listado_tickets.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_listado_tickets.Image = CType(resources.GetObject("btn_imprimir_listado_tickets.Image"), System.Drawing.Image)
        Me.btn_imprimir_listado_tickets.Location = New System.Drawing.Point(331, 418)
        Me.btn_imprimir_listado_tickets.Name = "btn_imprimir_listado_tickets"
        Me.btn_imprimir_listado_tickets.Size = New System.Drawing.Size(78, 101)
        Me.btn_imprimir_listado_tickets.TabIndex = 97
        Me.btn_imprimir_listado_tickets.Text = "Imprimir listado"
        Me.btn_imprimir_listado_tickets.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir_listado_tickets.UseVisualStyleBackColor = False
        '
        'btn_imprimir_ticket
        '
        Me.btn_imprimir_ticket.BackColor = System.Drawing.Color.White
        Me.btn_imprimir_ticket.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_ticket.Image = CType(resources.GetObject("btn_imprimir_ticket.Image"), System.Drawing.Image)
        Me.btn_imprimir_ticket.Location = New System.Drawing.Point(166, 418)
        Me.btn_imprimir_ticket.Name = "btn_imprimir_ticket"
        Me.btn_imprimir_ticket.Size = New System.Drawing.Size(80, 101)
        Me.btn_imprimir_ticket.TabIndex = 97
        Me.btn_imprimir_ticket.Text = "Imprimir Ticket"
        Me.btn_imprimir_ticket.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_imprimir_ticket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir_ticket.UseVisualStyleBackColor = False
        '
        'btn_prefactura
        '
        Me.btn_prefactura.BackColor = System.Drawing.Color.White
        Me.btn_prefactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_prefactura.Image = CType(resources.GetObject("btn_prefactura.Image"), System.Drawing.Image)
        Me.btn_prefactura.Location = New System.Drawing.Point(87, 418)
        Me.btn_prefactura.Name = "btn_prefactura"
        Me.btn_prefactura.Size = New System.Drawing.Size(73, 101)
        Me.btn_prefactura.TabIndex = 97
        Me.btn_prefactura.Text = "Realizar Factura"
        Me.btn_prefactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_prefactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_prefactura.UseVisualStyleBackColor = False
        '
        'btn_cobrar
        '
        Me.btn_cobrar.BackColor = System.Drawing.Color.White
        Me.btn_cobrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cobrar.Image = CType(resources.GetObject("btn_cobrar.Image"), System.Drawing.Image)
        Me.btn_cobrar.Location = New System.Drawing.Point(6, 417)
        Me.btn_cobrar.Name = "btn_cobrar"
        Me.btn_cobrar.Size = New System.Drawing.Size(75, 102)
        Me.btn_cobrar.TabIndex = 97
        Me.btn_cobrar.Text = "Cobrar Ticket"
        Me.btn_cobrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cobrar.UseVisualStyleBackColor = False
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(10, 527)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(172, 21)
        Me.lbl_total.TabIndex = 98
        Me.lbl_total.Text = "Total Credito Tickets:"
        '
        'tb_total
        '
        Me.tb_total.AutoSize = True
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(190, 529)
        Me.tb_total.MaximumSize = New System.Drawing.Size(100, 0)
        Me.tb_total.MinimumSize = New System.Drawing.Size(100, 0)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.Size = New System.Drawing.Size(100, 19)
        Me.tb_total.TabIndex = 98
        Me.tb_total.Text = "--"
        '
        'lbl_cliente
        '
        Me.lbl_cliente.AutoSize = True
        Me.lbl_cliente.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cliente.Location = New System.Drawing.Point(10, 431)
        Me.lbl_cliente.Name = "lbl_cliente"
        Me.lbl_cliente.Size = New System.Drawing.Size(70, 21)
        Me.lbl_cliente.TabIndex = 98
        Me.lbl_cliente.Text = "Cliente:"
        '
        'tb_cliente
        '
        Me.tb_cliente.AutoSize = True
        Me.tb_cliente.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cliente.Location = New System.Drawing.Point(145, 433)
        Me.tb_cliente.MaximumSize = New System.Drawing.Size(220, 80)
        Me.tb_cliente.MinimumSize = New System.Drawing.Size(220, 80)
        Me.tb_cliente.Name = "tb_cliente"
        Me.tb_cliente.Size = New System.Drawing.Size(220, 80)
        Me.tb_cliente.TabIndex = 98
        Me.tb_cliente.Text = "--"
        '
        'lbl_abonos
        '
        Me.lbl_abonos.AutoSize = True
        Me.lbl_abonos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_abonos.Location = New System.Drawing.Point(10, 555)
        Me.lbl_abonos.Name = "lbl_abonos"
        Me.lbl_abonos.Size = New System.Drawing.Size(57, 21)
        Me.lbl_abonos.TabIndex = 98
        Me.lbl_abonos.Text = "Pagos"
        '
        'tb_abonos
        '
        Me.tb_abonos.AutoSize = True
        Me.tb_abonos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_abonos.Location = New System.Drawing.Point(190, 556)
        Me.tb_abonos.MaximumSize = New System.Drawing.Size(100, 0)
        Me.tb_abonos.MinimumSize = New System.Drawing.Size(100, 0)
        Me.tb_abonos.Name = "tb_abonos"
        Me.tb_abonos.Size = New System.Drawing.Size(100, 19)
        Me.tb_abonos.TabIndex = 98
        Me.tb_abonos.Text = "--"
        '
        'lbl_saldo
        '
        Me.lbl_saldo.AutoSize = True
        Me.lbl_saldo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo.Location = New System.Drawing.Point(10, 594)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.Size = New System.Drawing.Size(94, 21)
        Me.lbl_saldo.TabIndex = 98
        Me.lbl_saldo.Text = "Por cobrar:"
        '
        'tb_saldo
        '
        Me.tb_saldo.AutoSize = True
        Me.tb_saldo.Font = New System.Drawing.Font("Century Gothic", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_saldo.Location = New System.Drawing.Point(186, 595)
        Me.tb_saldo.MaximumSize = New System.Drawing.Size(200, 0)
        Me.tb_saldo.MinimumSize = New System.Drawing.Size(200, 0)
        Me.tb_saldo.Name = "tb_saldo"
        Me.tb_saldo.Size = New System.Drawing.Size(200, 44)
        Me.tb_saldo.TabIndex = 98
        Me.tb_saldo.Text = "--"
        '
        'gb_prefactura
        '
        Me.gb_prefactura.Controls.Add(Me.dgv_prefactura)
        Me.gb_prefactura.Controls.Add(Me.btn_cobrar_factura)
        Me.gb_prefactura.Controls.Add(Me.btn_imprimir_listado)
        Me.gb_prefactura.Controls.Add(Me.btn_ver_prefactura)
        Me.gb_prefactura.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_prefactura.Location = New System.Drawing.Point(6, 11)
        Me.gb_prefactura.Name = "gb_prefactura"
        Me.gb_prefactura.Size = New System.Drawing.Size(471, 502)
        Me.gb_prefactura.TabIndex = 2
        Me.gb_prefactura.TabStop = False
        Me.gb_prefactura.Text = "Prefactura"
        '
        'dgv_prefactura
        '
        Me.dgv_prefactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_prefactura.Location = New System.Drawing.Point(12, 25)
        Me.dgv_prefactura.MultiSelect = False
        Me.dgv_prefactura.Name = "dgv_prefactura"
        Me.dgv_prefactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_prefactura.Size = New System.Drawing.Size(453, 385)
        Me.dgv_prefactura.TabIndex = 0
        '
        'btn_cobrar_factura
        '
        Me.btn_cobrar_factura.BackColor = System.Drawing.Color.White
        Me.btn_cobrar_factura.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cobrar_factura.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cobrar_factura.Location = New System.Drawing.Point(90, 415)
        Me.btn_cobrar_factura.Name = "btn_cobrar_factura"
        Me.btn_cobrar_factura.Size = New System.Drawing.Size(90, 78)
        Me.btn_cobrar_factura.TabIndex = 97
        Me.btn_cobrar_factura.Text = "Cobrar Factura"
        Me.btn_cobrar_factura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cobrar_factura.UseVisualStyleBackColor = False
        '
        'btn_imprimir_listado
        '
        Me.btn_imprimir_listado.BackColor = System.Drawing.Color.White
        Me.btn_imprimir_listado.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir_listado.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_imprimir_listado.Location = New System.Drawing.Point(186, 415)
        Me.btn_imprimir_listado.Name = "btn_imprimir_listado"
        Me.btn_imprimir_listado.Size = New System.Drawing.Size(67, 78)
        Me.btn_imprimir_listado.TabIndex = 97
        Me.btn_imprimir_listado.Text = "Imprimir listado"
        Me.btn_imprimir_listado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir_listado.UseVisualStyleBackColor = False
        '
        'btn_ver_prefactura
        '
        Me.btn_ver_prefactura.BackColor = System.Drawing.Color.White
        Me.btn_ver_prefactura.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ver_prefactura.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_ver_prefactura.Location = New System.Drawing.Point(6, 416)
        Me.btn_ver_prefactura.Name = "btn_ver_prefactura"
        Me.btn_ver_prefactura.Size = New System.Drawing.Size(83, 78)
        Me.btn_ver_prefactura.TabIndex = 97
        Me.btn_ver_prefactura.Text = "Ver Factura"
        Me.btn_ver_prefactura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ver_prefactura.UseVisualStyleBackColor = False
        '
        'lbl_buscar
        '
        Me.lbl_buscar.AutoSize = True
        Me.lbl_buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_buscar.Location = New System.Drawing.Point(7, 11)
        Me.lbl_buscar.Name = "lbl_buscar"
        Me.lbl_buscar.Size = New System.Drawing.Size(70, 21)
        Me.lbl_buscar.TabIndex = 98
        Me.lbl_buscar.Text = "Cliente:"
        '
        'tb_buscar
        '
        Me.tb_buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_buscar.Location = New System.Drawing.Point(78, 5)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(231, 27)
        Me.tb_buscar.TabIndex = 99
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Location = New System.Drawing.Point(214, 38)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(95, 35)
        Me.btn_buscar.TabIndex = 100
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(761, 578)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(108, 61)
        Me.btn_salir.TabIndex = 98
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'cb_tipo_cuentas
        '
        Me.cb_tipo_cuentas.FormattingEnabled = True
        Me.cb_tipo_cuentas.Location = New System.Drawing.Point(78, 45)
        Me.cb_tipo_cuentas.Name = "cb_tipo_cuentas"
        Me.cb_tipo_cuentas.Size = New System.Drawing.Size(130, 21)
        Me.cb_tipo_cuentas.TabIndex = 101
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 21)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Mostrar"
        '
        'tab_cuentas_xcobrar
        '
        Me.tab_cuentas_xcobrar.Controls.Add(Me.tab_ticket)
        Me.tab_cuentas_xcobrar.Controls.Add(Me.tab_prefactura)
        Me.tab_cuentas_xcobrar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_cuentas_xcobrar.Location = New System.Drawing.Point(388, 5)
        Me.tab_cuentas_xcobrar.Name = "tab_cuentas_xcobrar"
        Me.tab_cuentas_xcobrar.SelectedIndex = 0
        Me.tab_cuentas_xcobrar.Size = New System.Drawing.Size(491, 571)
        Me.tab_cuentas_xcobrar.TabIndex = 98
        '
        'tab_ticket
        '
        Me.tab_ticket.Controls.Add(Me.gb_ticktes)
        Me.tab_ticket.Location = New System.Drawing.Point(4, 30)
        Me.tab_ticket.Name = "tab_ticket"
        Me.tab_ticket.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_ticket.Size = New System.Drawing.Size(483, 537)
        Me.tab_ticket.TabIndex = 0
        Me.tab_ticket.Text = "Tickets"
        Me.tab_ticket.UseVisualStyleBackColor = True
        '
        'tab_prefactura
        '
        Me.tab_prefactura.Controls.Add(Me.gb_prefactura)
        Me.tab_prefactura.Location = New System.Drawing.Point(4, 30)
        Me.tab_prefactura.Name = "tab_prefactura"
        Me.tab_prefactura.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_prefactura.Size = New System.Drawing.Size(483, 519)
        Me.tab_prefactura.TabIndex = 1
        Me.tab_prefactura.Text = "Facturas"
        Me.tab_prefactura.UseVisualStyleBackColor = True
        '
        'frm_cuentas_xcobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 646)
        Me.Controls.Add(Me.tab_cuentas_xcobrar)
        Me.Controls.Add(Me.cb_tipo_cuentas)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.tb_buscar)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.tb_cliente)
        Me.Controls.Add(Me.tb_saldo)
        Me.Controls.Add(Me.tb_abonos)
        Me.Controls.Add(Me.tb_total)
        Me.Controls.Add(Me.lbl_saldo)
        Me.Controls.Add(Me.lbl_abonos)
        Me.Controls.Add(Me.lbl_cliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_buscar)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.gb_cliente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_cuentas_xcobrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por cobrar"
        CType(Me.dgv_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_cliente.ResumeLayout(False)
        Me.gb_ticktes.ResumeLayout(False)
        CType(Me.dgv_tickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_prefactura.ResumeLayout(False)
        CType(Me.dgv_prefactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_cuentas_xcobrar.ResumeLayout(False)
        Me.tab_ticket.ResumeLayout(False)
        Me.tab_prefactura.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents gb_cliente As System.Windows.Forms.GroupBox
    Friend WithEvents gb_ticktes As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_tickets As System.Windows.Forms.DataGridView
    Friend WithEvents btn_cobrar As System.Windows.Forms.Button
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents tb_total As System.Windows.Forms.Label
    Friend WithEvents lbl_cliente As System.Windows.Forms.Label
    Friend WithEvents tb_cliente As System.Windows.Forms.Label
    Friend WithEvents lbl_abonos As System.Windows.Forms.Label
    Friend WithEvents tb_abonos As System.Windows.Forms.Label
    Friend WithEvents lbl_saldo As System.Windows.Forms.Label
    Friend WithEvents tb_saldo As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents gb_prefactura As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_prefactura As System.Windows.Forms.DataGridView
    Friend WithEvents btn_ver_prefactura As System.Windows.Forms.Button
    Friend WithEvents btn_prefactura As System.Windows.Forms.Button
    Friend WithEvents btn_cobrar_factura As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir_pagare As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir_ticket As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir_listado As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir_listado_tickets As System.Windows.Forms.Button
    Friend WithEvents lbl_buscar As System.Windows.Forms.Label
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents cb_tipo_cuentas As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tab_cuentas_xcobrar As System.Windows.Forms.TabControl
    Friend WithEvents tab_ticket As System.Windows.Forms.TabPage
    Friend WithEvents tab_prefactura As System.Windows.Forms.TabPage
End Class
