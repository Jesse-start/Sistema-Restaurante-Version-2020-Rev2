<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_formas_pago_factura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_formas_pago_factura))
        Me.tb_num_notacredito = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbcontrolPagos = New System.Windows.Forms.TabControl()
        Me.tab_efectivo = New System.Windows.Forms.TabPage()
        Me.fecha_pago_efectivo = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.tb_efectivo = New System.Windows.Forms.TextBox()
        Me.tab_transferencia = New System.Windows.Forms.TabPage()
        Me.tb_num_referencia = New System.Windows.Forms.TextBox()
        Me.lbl_num_referencia = New System.Windows.Forms.Label()
        Me.fecha_pago_transferencia = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_saldo_cuenta_transf = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.tb_transferencia_importe = New System.Windows.Forms.TextBox()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.cb_cuenta_destino = New System.Windows.Forms.ComboBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.cb_BancoTransferenciaR = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_banco_cuenta = New System.Windows.Forms.ComboBox()
        Me.label24 = New System.Windows.Forms.Label()
        Me.cb_BancoTransferencia = New System.Windows.Forms.ComboBox()
        Me.label23 = New System.Windows.Forms.Label()
        Me.tab_cheques = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tb_nombre_cheque = New System.Windows.Forms.TextBox()
        Me.cb_cuenta_cheques = New System.Windows.Forms.ComboBox()
        Me.fecha_pago_cheque = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.tb_cheque_importe = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.tb_num_cheque = New System.Windows.Forms.TextBox()
        Me.CBbancoCheques = New System.Windows.Forms.ComboBox()
        Me.label16 = New System.Windows.Forms.Label()
        Me.tab_ncredito = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tb_nombre_notacredito = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tb_importe_nota_credito = New System.Windows.Forms.TextBox()
        Me.dtp_fecha_notacredito = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tab_tarjeta = New System.Windows.Forms.TabPage()
        Me.tb_importe_tarjeta = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tb_numero_tarjeta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cb_bancos_tarjeta = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.fecha_pago_tarjeta = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.btn_guardar_cambios = New System.Windows.Forms.Button()
        Me.tb_importe = New System.Windows.Forms.TextBox()
        Me.btn_punto = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_teclado = New System.Windows.Forms.Button()
        Me.tbcontrolPagos.SuspendLayout()
        Me.tab_efectivo.SuspendLayout()
        Me.tab_transferencia.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.tab_cheques.SuspendLayout()
        Me.tab_ncredito.SuspendLayout()
        Me.tab_tarjeta.SuspendLayout()
        Me.SuspendLayout()
        '
        'tb_num_notacredito
        '
        Me.tb_num_notacredito.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_num_notacredito.Location = New System.Drawing.Point(161, 66)
        Me.tb_num_notacredito.Name = "tb_num_notacredito"
        Me.tb_num_notacredito.Size = New System.Drawing.Size(70, 26)
        Me.tb_num_notacredito.TabIndex = 55
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(72, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(74, 20)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "No Nota:"
        '
        'tbcontrolPagos
        '
        Me.tbcontrolPagos.Controls.Add(Me.tab_efectivo)
        Me.tbcontrolPagos.Controls.Add(Me.tab_transferencia)
        Me.tbcontrolPagos.Controls.Add(Me.tab_cheques)
        Me.tbcontrolPagos.Controls.Add(Me.tab_ncredito)
        Me.tbcontrolPagos.Controls.Add(Me.tab_tarjeta)
        Me.tbcontrolPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcontrolPagos.ItemSize = New System.Drawing.Size(51, 35)
        Me.tbcontrolPagos.Location = New System.Drawing.Point(12, 12)
        Me.tbcontrolPagos.Name = "tbcontrolPagos"
        Me.tbcontrolPagos.SelectedIndex = 0
        Me.tbcontrolPagos.Size = New System.Drawing.Size(517, 253)
        Me.tbcontrolPagos.TabIndex = 54
        '
        'tab_efectivo
        '
        Me.tab_efectivo.BackColor = System.Drawing.Color.Transparent
        Me.tab_efectivo.Controls.Add(Me.fecha_pago_efectivo)
        Me.tab_efectivo.Controls.Add(Me.Label17)
        Me.tab_efectivo.Controls.Add(Me.label10)
        Me.tab_efectivo.Controls.Add(Me.tb_efectivo)
        Me.tab_efectivo.Location = New System.Drawing.Point(4, 39)
        Me.tab_efectivo.Name = "tab_efectivo"
        Me.tab_efectivo.Size = New System.Drawing.Size(509, 210)
        Me.tab_efectivo.TabIndex = 6
        Me.tab_efectivo.Text = "Efectivo"
        '
        'fecha_pago_efectivo
        '
        Me.fecha_pago_efectivo.CalendarFont = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_pago_efectivo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_pago_efectivo.Location = New System.Drawing.Point(131, 10)
        Me.fecha_pago_efectivo.Name = "fecha_pago_efectivo"
        Me.fecha_pago_efectivo.Size = New System.Drawing.Size(293, 26)
        Me.fecha_pago_efectivo.TabIndex = 49
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 20)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "Fecha de pago:"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(97, 102)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(103, 22)
        Me.label10.TabIndex = 45
        Me.label10.Text = "Importe $:"
        '
        'tb_efectivo
        '
        Me.tb_efectivo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_efectivo.Location = New System.Drawing.Point(206, 99)
        Me.tb_efectivo.Name = "tb_efectivo"
        Me.tb_efectivo.Size = New System.Drawing.Size(109, 31)
        Me.tb_efectivo.TabIndex = 44
        Me.tb_efectivo.Text = "0.00"
        '
        'tab_transferencia
        '
        Me.tab_transferencia.BackColor = System.Drawing.Color.Transparent
        Me.tab_transferencia.Controls.Add(Me.tb_num_referencia)
        Me.tab_transferencia.Controls.Add(Me.lbl_num_referencia)
        Me.tab_transferencia.Controls.Add(Me.fecha_pago_transferencia)
        Me.tab_transferencia.Controls.Add(Me.Label18)
        Me.tab_transferencia.Controls.Add(Me.lbl_saldo_cuenta_transf)
        Me.tab_transferencia.Controls.Add(Me.Label13)
        Me.tab_transferencia.Controls.Add(Me.label8)
        Me.tab_transferencia.Controls.Add(Me.tb_transferencia_importe)
        Me.tab_transferencia.Controls.Add(Me.groupBox3)
        Me.tab_transferencia.Controls.Add(Me.groupBox2)
        Me.tab_transferencia.Location = New System.Drawing.Point(4, 39)
        Me.tab_transferencia.Name = "tab_transferencia"
        Me.tab_transferencia.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_transferencia.Size = New System.Drawing.Size(509, 210)
        Me.tab_transferencia.TabIndex = 1
        Me.tab_transferencia.Text = "Transferencia Bancaria"
        '
        'tb_num_referencia
        '
        Me.tb_num_referencia.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_num_referencia.Location = New System.Drawing.Point(205, 166)
        Me.tb_num_referencia.Name = "tb_num_referencia"
        Me.tb_num_referencia.Size = New System.Drawing.Size(224, 26)
        Me.tb_num_referencia.TabIndex = 49
        '
        'lbl_num_referencia
        '
        Me.lbl_num_referencia.AutoSize = True
        Me.lbl_num_referencia.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_num_referencia.Location = New System.Drawing.Point(6, 166)
        Me.lbl_num_referencia.Name = "lbl_num_referencia"
        Me.lbl_num_referencia.Size = New System.Drawing.Size(180, 20)
        Me.lbl_num_referencia.TabIndex = 48
        Me.lbl_num_referencia.Text = "Número de Referencia:"
        '
        'fecha_pago_transferencia
        '
        Me.fecha_pago_transferencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_pago_transferencia.Location = New System.Drawing.Point(107, 14)
        Me.fecha_pago_transferencia.Name = "fecha_pago_transferencia"
        Me.fecha_pago_transferencia.Size = New System.Drawing.Size(309, 23)
        Me.fecha_pago_transferencia.TabIndex = 47
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(17, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 17)
        Me.Label18.TabIndex = 46
        Me.Label18.Text = "Realizada:"
        '
        'lbl_saldo_cuenta_transf
        '
        Me.lbl_saldo_cuenta_transf.AutoSize = True
        Me.lbl_saldo_cuenta_transf.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo_cuenta_transf.Location = New System.Drawing.Point(204, 229)
        Me.lbl_saldo_cuenta_transf.Name = "lbl_saldo_cuenta_transf"
        Me.lbl_saldo_cuenta_transf.Size = New System.Drawing.Size(45, 20)
        Me.lbl_saldo_cuenta_transf.TabIndex = 43
        Me.lbl_saldo_cuenta_transf.Text = "00.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 232)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(153, 20)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Saldo de la Cuenta:"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label8.Location = New System.Drawing.Point(83, 198)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(103, 22)
        Me.label8.TabIndex = 41
        Me.label8.Text = "Importe $:"
        '
        'tb_transferencia_importe
        '
        Me.tb_transferencia_importe.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_transferencia_importe.Location = New System.Drawing.Point(205, 195)
        Me.tb_transferencia_importe.Name = "tb_transferencia_importe"
        Me.tb_transferencia_importe.Size = New System.Drawing.Size(165, 31)
        Me.tb_transferencia_importe.TabIndex = 40
        Me.tb_transferencia_importe.Text = "0.00"
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.cb_cuenta_destino)
        Me.groupBox3.Controls.Add(Me.label6)
        Me.groupBox3.Controls.Add(Me.cb_BancoTransferenciaR)
        Me.groupBox3.Controls.Add(Me.label7)
        Me.groupBox3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox3.Location = New System.Drawing.Point(1, 99)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(425, 58)
        Me.groupBox3.TabIndex = 1
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Su cuenta"
        '
        'cb_cuenta_destino
        '
        Me.cb_cuenta_destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_cuenta_destino.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_cuenta_destino.FormattingEnabled = True
        Me.cb_cuenta_destino.Location = New System.Drawing.Point(280, 22)
        Me.cb_cuenta_destino.Name = "cb_cuenta_destino"
        Me.cb_cuenta_destino.Size = New System.Drawing.Size(135, 24)
        Me.cb_cuenta_destino.TabIndex = 47
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(211, 22)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(61, 17)
        Me.label6.TabIndex = 45
        Me.label6.Text = "Cuenta:"
        '
        'cb_BancoTransferenciaR
        '
        Me.cb_BancoTransferenciaR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_BancoTransferenciaR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_BancoTransferenciaR.FormattingEnabled = True
        Me.cb_BancoTransferenciaR.Location = New System.Drawing.Point(65, 19)
        Me.cb_BancoTransferenciaR.Name = "cb_BancoTransferenciaR"
        Me.cb_BancoTransferenciaR.Size = New System.Drawing.Size(135, 24)
        Me.cb_BancoTransferenciaR.TabIndex = 44
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(6, 22)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(53, 17)
        Me.label7.TabIndex = 43
        Me.label7.Text = "Banco:"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.cb_banco_cuenta)
        Me.groupBox2.Controls.Add(Me.label24)
        Me.groupBox2.Controls.Add(Me.cb_BancoTransferencia)
        Me.groupBox2.Controls.Add(Me.label23)
        Me.groupBox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(4, 43)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(422, 53)
        Me.groupBox2.TabIndex = 0
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Cuenta del Cliente"
        '
        'cb_banco_cuenta
        '
        Me.cb_banco_cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_banco_cuenta.FormattingEnabled = True
        Me.cb_banco_cuenta.Location = New System.Drawing.Point(277, 18)
        Me.cb_banco_cuenta.Name = "cb_banco_cuenta"
        Me.cb_banco_cuenta.Size = New System.Drawing.Size(135, 24)
        Me.cb_banco_cuenta.TabIndex = 44
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Location = New System.Drawing.Point(211, 22)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(61, 17)
        Me.label24.TabIndex = 37
        Me.label24.Text = "Cuenta:"
        '
        'cb_BancoTransferencia
        '
        Me.cb_BancoTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_BancoTransferencia.FormattingEnabled = True
        Me.cb_BancoTransferencia.Location = New System.Drawing.Point(65, 18)
        Me.cb_BancoTransferencia.Name = "cb_BancoTransferencia"
        Me.cb_BancoTransferencia.Size = New System.Drawing.Size(135, 24)
        Me.cb_BancoTransferencia.TabIndex = 36
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(6, 22)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(53, 17)
        Me.label23.TabIndex = 0
        Me.label23.Text = "Banco:"
        '
        'tab_cheques
        '
        Me.tab_cheques.BackColor = System.Drawing.SystemColors.Control
        Me.tab_cheques.Controls.Add(Me.Label19)
        Me.tab_cheques.Controls.Add(Me.tb_nombre_cheque)
        Me.tab_cheques.Controls.Add(Me.cb_cuenta_cheques)
        Me.tab_cheques.Controls.Add(Me.fecha_pago_cheque)
        Me.tab_cheques.Controls.Add(Me.Label5)
        Me.tab_cheques.Controls.Add(Me.label9)
        Me.tab_cheques.Controls.Add(Me.tb_cheque_importe)
        Me.tab_cheques.Controls.Add(Me.label4)
        Me.tab_cheques.Controls.Add(Me.label3)
        Me.tab_cheques.Controls.Add(Me.tb_num_cheque)
        Me.tab_cheques.Controls.Add(Me.CBbancoCheques)
        Me.tab_cheques.Controls.Add(Me.label16)
        Me.tab_cheques.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_cheques.Location = New System.Drawing.Point(4, 39)
        Me.tab_cheques.Name = "tab_cheques"
        Me.tab_cheques.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_cheques.Size = New System.Drawing.Size(509, 210)
        Me.tab_cheques.TabIndex = 4
        Me.tab_cheques.Text = "Cheques"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(53, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 20)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "A Favor de :"
        '
        'tb_nombre_cheque
        '
        Me.tb_nombre_cheque.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre_cheque.Location = New System.Drawing.Point(157, 114)
        Me.tb_nombre_cheque.Name = "tb_nombre_cheque"
        Me.tb_nombre_cheque.Size = New System.Drawing.Size(227, 26)
        Me.tb_nombre_cheque.TabIndex = 61
        '
        'cb_cuenta_cheques
        '
        Me.cb_cuenta_cheques.Enabled = False
        Me.cb_cuenta_cheques.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_cuenta_cheques.FormattingEnabled = True
        Me.cb_cuenta_cheques.Location = New System.Drawing.Point(157, 221)
        Me.cb_cuenta_cheques.Name = "cb_cuenta_cheques"
        Me.cb_cuenta_cheques.Size = New System.Drawing.Size(209, 28)
        Me.cb_cuenta_cheques.TabIndex = 60
        Me.cb_cuenta_cheques.Visible = False
        '
        'fecha_pago_cheque
        '
        Me.fecha_pago_cheque.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_pago_cheque.Location = New System.Drawing.Point(111, 19)
        Me.fecha_pago_cheque.Name = "fecha_pago_cheque"
        Me.fecha_pago_cheque.Size = New System.Drawing.Size(301, 26)
        Me.fecha_pago_cheque.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 20)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Expedición:"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(48, 156)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(103, 22)
        Me.label9.TabIndex = 57
        Me.label9.Text = "Importe $:"
        '
        'tb_cheque_importe
        '
        Me.tb_cheque_importe.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cheque_importe.Location = New System.Drawing.Point(157, 153)
        Me.tb_cheque_importe.Name = "tb_cheque_importe"
        Me.tb_cheque_importe.Size = New System.Drawing.Size(158, 31)
        Me.tb_cheque_importe.TabIndex = 56
        Me.tb_cheque_importe.Text = "0.00"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Enabled = False
        Me.label4.Location = New System.Drawing.Point(58, 226)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(93, 20)
        Me.label4.TabIndex = 55
        Me.label4.Text = "No Cuenta:"
        Me.label4.Visible = False
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(29, 91)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(122, 20)
        Me.label3.TabIndex = 54
        Me.label3.Text = "No de Cheque:"
        '
        'tb_num_cheque
        '
        Me.tb_num_cheque.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_num_cheque.Location = New System.Drawing.Point(157, 85)
        Me.tb_num_cheque.Name = "tb_num_cheque"
        Me.tb_num_cheque.Size = New System.Drawing.Size(209, 26)
        Me.tb_num_cheque.TabIndex = 53
        '
        'CBbancoCheques
        '
        Me.CBbancoCheques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBbancoCheques.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBbancoCheques.FormattingEnabled = True
        Me.CBbancoCheques.Location = New System.Drawing.Point(157, 53)
        Me.CBbancoCheques.Name = "CBbancoCheques"
        Me.CBbancoCheques.Size = New System.Drawing.Size(209, 28)
        Me.CBbancoCheques.TabIndex = 52
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(90, 60)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(61, 20)
        Me.label16.TabIndex = 51
        Me.label16.Text = "Banco:"
        '
        'tab_ncredito
        '
        Me.tab_ncredito.BackColor = System.Drawing.Color.Transparent
        Me.tab_ncredito.Controls.Add(Me.tb_num_notacredito)
        Me.tab_ncredito.Controls.Add(Me.Label25)
        Me.tab_ncredito.Controls.Add(Me.Label21)
        Me.tab_ncredito.Controls.Add(Me.tb_nombre_notacredito)
        Me.tab_ncredito.Controls.Add(Me.Label22)
        Me.tab_ncredito.Controls.Add(Me.tb_importe_nota_credito)
        Me.tab_ncredito.Controls.Add(Me.dtp_fecha_notacredito)
        Me.tab_ncredito.Controls.Add(Me.Label20)
        Me.tab_ncredito.Location = New System.Drawing.Point(4, 39)
        Me.tab_ncredito.Name = "tab_ncredito"
        Me.tab_ncredito.Size = New System.Drawing.Size(509, 210)
        Me.tab_ncredito.TabIndex = 5
        Me.tab_ncredito.Text = "Nota de Crédito"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(46, 101)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(98, 20)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "A Favor de :"
        '
        'tb_nombre_notacredito
        '
        Me.tb_nombre_notacredito.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre_notacredito.Location = New System.Drawing.Point(161, 98)
        Me.tb_nombre_notacredito.Name = "tb_nombre_notacredito"
        Me.tb_nombre_notacredito.Size = New System.Drawing.Size(219, 26)
        Me.tb_nombre_notacredito.TabIndex = 53
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(52, 153)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 22)
        Me.Label22.TabIndex = 52
        Me.Label22.Text = "Importe $:"
        '
        'tb_importe_nota_credito
        '
        Me.tb_importe_nota_credito.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_nota_credito.Location = New System.Drawing.Point(161, 144)
        Me.tb_importe_nota_credito.Name = "tb_importe_nota_credito"
        Me.tb_importe_nota_credito.Size = New System.Drawing.Size(144, 31)
        Me.tb_importe_nota_credito.TabIndex = 51
        Me.tb_importe_nota_credito.Text = "0.00"
        '
        'dtp_fecha_notacredito
        '
        Me.dtp_fecha_notacredito.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_notacredito.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_notacredito.Location = New System.Drawing.Point(105, 22)
        Me.dtp_fecha_notacredito.Name = "dtp_fecha_notacredito"
        Me.dtp_fecha_notacredito.Size = New System.Drawing.Size(309, 26)
        Me.dtp_fecha_notacredito.TabIndex = 47
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 20)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Expedición:"
        '
        'tab_tarjeta
        '
        Me.tab_tarjeta.Controls.Add(Me.tb_importe_tarjeta)
        Me.tab_tarjeta.Controls.Add(Me.Label15)
        Me.tab_tarjeta.Controls.Add(Me.tb_numero_tarjeta)
        Me.tab_tarjeta.Controls.Add(Me.Label14)
        Me.tab_tarjeta.Controls.Add(Me.cb_bancos_tarjeta)
        Me.tab_tarjeta.Controls.Add(Me.Label12)
        Me.tab_tarjeta.Controls.Add(Me.fecha_pago_tarjeta)
        Me.tab_tarjeta.Controls.Add(Me.Label11)
        Me.tab_tarjeta.Location = New System.Drawing.Point(4, 39)
        Me.tab_tarjeta.Name = "tab_tarjeta"
        Me.tab_tarjeta.Size = New System.Drawing.Size(509, 210)
        Me.tab_tarjeta.TabIndex = 7
        Me.tab_tarjeta.Text = "Tarjeta Bancaria"
        Me.tab_tarjeta.UseVisualStyleBackColor = True
        '
        'tb_importe_tarjeta
        '
        Me.tb_importe_tarjeta.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_tarjeta.Location = New System.Drawing.Point(199, 151)
        Me.tb_importe_tarjeta.Name = "tb_importe_tarjeta"
        Me.tb_importe_tarjeta.Size = New System.Drawing.Size(141, 31)
        Me.tb_importe_tarjeta.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(90, 157)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(103, 22)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Importe: $"
        '
        'tb_numero_tarjeta
        '
        Me.tb_numero_tarjeta.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_numero_tarjeta.Location = New System.Drawing.Point(174, 97)
        Me.tb_numero_tarjeta.Name = "tb_numero_tarjeta"
        Me.tb_numero_tarjeta.Size = New System.Drawing.Size(154, 26)
        Me.tb_numero_tarjeta.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(38, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 20)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "No Referencia:"
        '
        'cb_bancos_tarjeta
        '
        Me.cb_bancos_tarjeta.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_bancos_tarjeta.FormattingEnabled = True
        Me.cb_bancos_tarjeta.Location = New System.Drawing.Point(174, 61)
        Me.cb_bancos_tarjeta.Name = "cb_bancos_tarjeta"
        Me.cb_bancos_tarjeta.Size = New System.Drawing.Size(154, 28)
        Me.cb_bancos_tarjeta.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(86, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 20)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Banco:"
        '
        'fecha_pago_tarjeta
        '
        Me.fecha_pago_tarjeta.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha_pago_tarjeta.Location = New System.Drawing.Point(137, 21)
        Me.fecha_pago_tarjeta.Name = "fecha_pago_tarjeta"
        Me.fecha_pago_tarjeta.Size = New System.Drawing.Size(292, 26)
        Me.fecha_pago_tarjeta.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 20)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Fecha de pago:"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.White
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.Location = New System.Drawing.Point(601, 352)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(140, 60)
        Me.btn_aceptar.TabIndex = 62
        Me.btn_aceptar.Text = "Guardar"
        Me.btn_aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(272, 434)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(67, 20)
        Me.label2.TabIndex = 60
        Me.label2.Text = "Importe"
        '
        'btn_guardar_cambios
        '
        Me.btn_guardar_cambios.BackColor = System.Drawing.Color.White
        Me.btn_guardar_cambios.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar_cambios.Location = New System.Drawing.Point(601, 475)
        Me.btn_guardar_cambios.Name = "btn_guardar_cambios"
        Me.btn_guardar_cambios.Size = New System.Drawing.Size(140, 51)
        Me.btn_guardar_cambios.TabIndex = 55
        Me.btn_guardar_cambios.Text = "Guardar Cambios"
        Me.btn_guardar_cambios.UseVisualStyleBackColor = False
        Me.btn_guardar_cambios.Visible = False
        '
        'tb_importe
        '
        Me.tb_importe.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe.Location = New System.Drawing.Point(350, 434)
        Me.tb_importe.Name = "tb_importe"
        Me.tb_importe.Size = New System.Drawing.Size(179, 26)
        Me.tb_importe.TabIndex = 59
        '
        'btn_punto
        '
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(657, 215)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(50, 50)
        Me.btn_punto.TabIndex = 73
        Me.btn_punto.Text = "."
        Me.btn_punto.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(713, 159)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(50, 106)
        Me.Button14.TabIndex = 72
        Me.Button14.Text = "OK"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(657, 159)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 50)
        Me.btn3.TabIndex = 71
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(713, 103)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(50, 50)
        Me.Button10.TabIndex = 76
        Me.Button10.Text = "CA"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(657, 103)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 50)
        Me.btn6.TabIndex = 75
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(601, 159)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 50)
        Me.btn2.TabIndex = 74
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(713, 47)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 50)
        Me.Button6.TabIndex = 70
        Me.Button6.Text = "C"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btn0
        '
        Me.btn0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(545, 215)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(106, 50)
        Me.btn0.TabIndex = 66
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(601, 103)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(50, 50)
        Me.btn5.TabIndex = 65
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn9
        '
        Me.btn9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(657, 47)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(50, 50)
        Me.btn9.TabIndex = 64
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = True
        '
        'btn4
        '
        Me.btn4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(545, 103)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 69
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn8
        '
        Me.btn8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(601, 47)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 68
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = True
        '
        'btn7
        '
        Me.btn7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(545, 47)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 50)
        Me.btn7.TabIndex = 67
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(545, 159)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 77
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(601, 416)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(140, 56)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_teclado
        '
        Me.btn_teclado.BackColor = System.Drawing.Color.White
        Me.btn_teclado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_teclado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_teclado.Image = CType(resources.GetObject("btn_teclado.Image"), System.Drawing.Image)
        Me.btn_teclado.Location = New System.Drawing.Point(601, 293)
        Me.btn_teclado.Name = "btn_teclado"
        Me.btn_teclado.Size = New System.Drawing.Size(140, 53)
        Me.btn_teclado.TabIndex = 51
        Me.btn_teclado.Text = "Teclado"
        Me.btn_teclado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_teclado.UseVisualStyleBackColor = False
        '
        'frm_formas_pago_factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 525)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_teclado)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btn_punto)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btn0)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.btn9)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn8)
        Me.Controls.Add(Me.btn7)
        Me.Controls.Add(Me.tbcontrolPagos)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.btn_guardar_cambios)
        Me.Controls.Add(Me.tb_importe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_formas_pago_factura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formas de pago"
        Me.tbcontrolPagos.ResumeLayout(False)
        Me.tab_efectivo.ResumeLayout(False)
        Me.tab_efectivo.PerformLayout()
        Me.tab_transferencia.ResumeLayout(False)
        Me.tab_transferencia.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.tab_cheques.ResumeLayout(False)
        Me.tab_cheques.PerformLayout()
        Me.tab_ncredito.ResumeLayout(False)
        Me.tab_ncredito.PerformLayout()
        Me.tab_tarjeta.ResumeLayout(False)
        Me.tab_tarjeta.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tb_num_notacredito As System.Windows.Forms.TextBox
    Private WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents tbcontrolPagos As System.Windows.Forms.TabControl
    Private WithEvents tab_efectivo As System.Windows.Forms.TabPage
    Friend WithEvents fecha_pago_efectivo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents tb_efectivo As System.Windows.Forms.TextBox
    Private WithEvents tab_transferencia As System.Windows.Forms.TabPage
    Friend WithEvents tb_num_referencia As System.Windows.Forms.TextBox
    Friend WithEvents lbl_num_referencia As System.Windows.Forms.Label
    Friend WithEvents fecha_pago_transferencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents tb_transferencia_importe As System.Windows.Forms.TextBox
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_cuenta_destino As System.Windows.Forms.ComboBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents cb_BancoTransferenciaR As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_banco_cuenta As System.Windows.Forms.ComboBox
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents cb_BancoTransferencia As System.Windows.Forms.ComboBox
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents tab_cheques As System.Windows.Forms.TabPage
    Private WithEvents tab_ncredito As System.Windows.Forms.TabPage
    Private WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents tb_nombre_notacredito As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents tb_importe_nota_credito As System.Windows.Forms.TextBox
    Friend WithEvents dtp_fecha_notacredito As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents btn_aceptar As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btn_guardar_cambios As System.Windows.Forms.Button
    Private WithEvents tb_importe As System.Windows.Forms.TextBox
    Friend WithEvents lbl_saldo_cuenta_transf As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tab_tarjeta As System.Windows.Forms.TabPage
    Friend WithEvents fecha_pago_tarjeta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_bancos_tarjeta As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tb_numero_tarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tb_importe_tarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btn_punto As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn_teclado As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Private WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents tb_nombre_cheque As System.Windows.Forms.TextBox
    Friend WithEvents cb_cuenta_cheques As System.Windows.Forms.ComboBox
    Friend WithEvents fecha_pago_cheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents tb_cheque_importe As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents tb_num_cheque As System.Windows.Forms.TextBox
    Private WithEvents CBbancoCheques As System.Windows.Forms.ComboBox
    Private WithEvents label16 As System.Windows.Forms.Label
End Class
