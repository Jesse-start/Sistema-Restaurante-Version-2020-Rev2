<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_caja
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_caja))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tiempo_inactivo = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_forma_pago = New System.Windows.Forms.Label()
        Me.gb_efectivo = New System.Windows.Forms.GroupBox()
        Me.btn_20 = New System.Windows.Forms.Button()
        Me.btn_100 = New System.Windows.Forms.Button()
        Me.btn_1 = New System.Windows.Forms.Button()
        Me.btn_1000 = New System.Windows.Forms.Button()
        Me.btn_50c = New System.Windows.Forms.Button()
        Me.btn_200 = New System.Windows.Forms.Button()
        Me.btn_500 = New System.Windows.Forms.Button()
        Me.btn_5 = New System.Windows.Forms.Button()
        Me.btn_50 = New System.Windows.Forms.Button()
        Me.btn_2 = New System.Windows.Forms.Button()
        Me.btn_10 = New System.Windows.Forms.Button()
        Me.dgv_pagos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gb_tarjeta = New System.Windows.Forms.GroupBox()
        Me.lb_tarjeta = New System.Windows.Forms.Label()
        Me.tb_referencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tb_pago = New System.Windows.Forms.TextBox()
        Me.tb_cambio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tb_importe = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_punto = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn_cobrar = New System.Windows.Forms.Button()
        Me.btn_reabrir_venta = New System.Windows.Forms.Button()
        Me.btn_cupones = New System.Windows.Forms.Button()
        Me.btn_credito = New System.Windows.Forms.Button()
        Me.btn_cancelar_venta = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_regalias = New System.Windows.Forms.Button()
        Me.btn_tarjeta_credito = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_efectivo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lb_nombre = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pb_foto = New System.Windows.Forms.PictureBox()
        Me.lb_puesto = New System.Windows.Forms.Label()
        Me.btn_tarjeta_debito = New System.Windows.Forms.Button()
        Me.cb_forma_pago = New System.Windows.Forms.ComboBox()
        Me.gb_efectivo.SuspendLayout()
        CType(Me.dgv_pagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gb_tarjeta.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pb_foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tiempo_inactivo
        '
        Me.tiempo_inactivo.Interval = 7000
        '
        'lbl_forma_pago
        '
        Me.lbl_forma_pago.AutoSize = True
        Me.lbl_forma_pago.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_forma_pago.Location = New System.Drawing.Point(8, 413)
        Me.lbl_forma_pago.Name = "lbl_forma_pago"
        Me.lbl_forma_pago.Size = New System.Drawing.Size(257, 32)
        Me.lbl_forma_pago.TabIndex = 24
        Me.lbl_forma_pago.Text = "FORMA DE PAGO: "
        '
        'gb_efectivo
        '
        Me.gb_efectivo.Controls.Add(Me.btn_20)
        Me.gb_efectivo.Controls.Add(Me.btn_100)
        Me.gb_efectivo.Controls.Add(Me.btn_1)
        Me.gb_efectivo.Controls.Add(Me.btn_1000)
        Me.gb_efectivo.Controls.Add(Me.btn_50c)
        Me.gb_efectivo.Controls.Add(Me.btn_200)
        Me.gb_efectivo.Controls.Add(Me.btn_500)
        Me.gb_efectivo.Controls.Add(Me.btn_5)
        Me.gb_efectivo.Controls.Add(Me.btn_50)
        Me.gb_efectivo.Controls.Add(Me.btn_2)
        Me.gb_efectivo.Controls.Add(Me.btn_10)
        Me.gb_efectivo.Location = New System.Drawing.Point(744, 6)
        Me.gb_efectivo.Name = "gb_efectivo"
        Me.gb_efectivo.Size = New System.Drawing.Size(250, 406)
        Me.gb_efectivo.TabIndex = 131
        Me.gb_efectivo.TabStop = False
        '
        'btn_20
        '
        Me.btn_20.BackgroundImage = CType(resources.GetObject("btn_20.BackgroundImage"), System.Drawing.Image)
        Me.btn_20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_20.Location = New System.Drawing.Point(4, 16)
        Me.btn_20.Name = "btn_20"
        Me.btn_20.Size = New System.Drawing.Size(121, 77)
        Me.btn_20.TabIndex = 120
        Me.btn_20.UseVisualStyleBackColor = True
        '
        'btn_100
        '
        Me.btn_100.BackgroundImage = CType(resources.GetObject("btn_100.BackgroundImage"), System.Drawing.Image)
        Me.btn_100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_100.Location = New System.Drawing.Point(5, 93)
        Me.btn_100.Name = "btn_100"
        Me.btn_100.Size = New System.Drawing.Size(121, 72)
        Me.btn_100.TabIndex = 119
        Me.btn_100.UseVisualStyleBackColor = True
        '
        'btn_1
        '
        Me.btn_1.BackgroundImage = CType(resources.GetObject("btn_1.BackgroundImage"), System.Drawing.Image)
        Me.btn_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_1.Location = New System.Drawing.Point(3, 320)
        Me.btn_1.Name = "btn_1"
        Me.btn_1.Size = New System.Drawing.Size(80, 80)
        Me.btn_1.TabIndex = 127
        Me.btn_1.UseVisualStyleBackColor = True
        '
        'btn_1000
        '
        Me.btn_1000.BackgroundImage = CType(resources.GetObject("btn_1000.BackgroundImage"), System.Drawing.Image)
        Me.btn_1000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_1000.Location = New System.Drawing.Point(127, 166)
        Me.btn_1000.Name = "btn_1000"
        Me.btn_1000.Size = New System.Drawing.Size(121, 72)
        Me.btn_1000.TabIndex = 125
        Me.btn_1000.UseVisualStyleBackColor = True
        '
        'btn_50c
        '
        Me.btn_50c.BackgroundImage = CType(resources.GetObject("btn_50c.BackgroundImage"), System.Drawing.Image)
        Me.btn_50c.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_50c.Location = New System.Drawing.Point(83, 320)
        Me.btn_50c.Name = "btn_50c"
        Me.btn_50c.Size = New System.Drawing.Size(80, 80)
        Me.btn_50c.TabIndex = 126
        Me.btn_50c.UseVisualStyleBackColor = True
        '
        'btn_200
        '
        Me.btn_200.BackgroundImage = CType(resources.GetObject("btn_200.BackgroundImage"), System.Drawing.Image)
        Me.btn_200.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_200.Location = New System.Drawing.Point(127, 93)
        Me.btn_200.Name = "btn_200"
        Me.btn_200.Size = New System.Drawing.Size(121, 72)
        Me.btn_200.TabIndex = 117
        Me.btn_200.UseVisualStyleBackColor = True
        '
        'btn_500
        '
        Me.btn_500.BackgroundImage = CType(resources.GetObject("btn_500.BackgroundImage"), System.Drawing.Image)
        Me.btn_500.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_500.Location = New System.Drawing.Point(5, 166)
        Me.btn_500.Name = "btn_500"
        Me.btn_500.Size = New System.Drawing.Size(121, 72)
        Me.btn_500.TabIndex = 118
        Me.btn_500.UseVisualStyleBackColor = True
        '
        'btn_5
        '
        Me.btn_5.BackgroundImage = CType(resources.GetObject("btn_5.BackgroundImage"), System.Drawing.Image)
        Me.btn_5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_5.Location = New System.Drawing.Point(83, 239)
        Me.btn_5.Name = "btn_5"
        Me.btn_5.Size = New System.Drawing.Size(80, 80)
        Me.btn_5.TabIndex = 122
        Me.btn_5.UseVisualStyleBackColor = True
        '
        'btn_50
        '
        Me.btn_50.BackgroundImage = CType(resources.GetObject("btn_50.BackgroundImage"), System.Drawing.Image)
        Me.btn_50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_50.Location = New System.Drawing.Point(126, 16)
        Me.btn_50.Name = "btn_50"
        Me.btn_50.Size = New System.Drawing.Size(121, 77)
        Me.btn_50.TabIndex = 121
        Me.btn_50.UseVisualStyleBackColor = True
        '
        'btn_2
        '
        Me.btn_2.BackgroundImage = CType(resources.GetObject("btn_2.BackgroundImage"), System.Drawing.Image)
        Me.btn_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_2.Location = New System.Drawing.Point(170, 239)
        Me.btn_2.Name = "btn_2"
        Me.btn_2.Size = New System.Drawing.Size(80, 80)
        Me.btn_2.TabIndex = 124
        Me.btn_2.UseVisualStyleBackColor = True
        '
        'btn_10
        '
        Me.btn_10.BackgroundImage = CType(resources.GetObject("btn_10.BackgroundImage"), System.Drawing.Image)
        Me.btn_10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_10.Location = New System.Drawing.Point(3, 239)
        Me.btn_10.Name = "btn_10"
        Me.btn_10.Size = New System.Drawing.Size(80, 80)
        Me.btn_10.TabIndex = 123
        Me.btn_10.UseVisualStyleBackColor = True
        '
        'dgv_pagos
        '
        Me.dgv_pagos.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pagos.Location = New System.Drawing.Point(8, 163)
        Me.dgv_pagos.MultiSelect = False
        Me.dgv_pagos.Name = "dgv_pagos"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pagos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_pagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_pagos.Size = New System.Drawing.Size(713, 244)
        Me.dgv_pagos.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gb_tarjeta)
        Me.GroupBox1.Controls.Add(Me.tb_buscar)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_punto)
        Me.GroupBox1.Controls.Add(Me.Button14)
        Me.GroupBox1.Controls.Add(Me.btn3)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.btn6)
        Me.GroupBox1.Controls.Add(Me.btn2)
        Me.GroupBox1.Controls.Add(Me.btn7)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.btn8)
        Me.GroupBox1.Controls.Add(Me.btn0)
        Me.GroupBox1.Controls.Add(Me.btn4)
        Me.GroupBox1.Controls.Add(Me.btn5)
        Me.GroupBox1.Controls.Add(Me.btn9)
        Me.GroupBox1.Controls.Add(Me.btn1)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 448)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 237)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pago"
        '
        'gb_tarjeta
        '
        Me.gb_tarjeta.Controls.Add(Me.lb_tarjeta)
        Me.gb_tarjeta.Controls.Add(Me.tb_referencia)
        Me.gb_tarjeta.Controls.Add(Me.Label6)
        Me.gb_tarjeta.Location = New System.Drawing.Point(8, 153)
        Me.gb_tarjeta.Name = "gb_tarjeta"
        Me.gb_tarjeta.Size = New System.Drawing.Size(390, 69)
        Me.gb_tarjeta.TabIndex = 78
        Me.gb_tarjeta.TabStop = False
        Me.gb_tarjeta.Text = "Tarjeta"
        Me.gb_tarjeta.Visible = False
        '
        'lb_tarjeta
        '
        Me.lb_tarjeta.AutoSize = True
        Me.lb_tarjeta.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_tarjeta.Location = New System.Drawing.Point(200, 18)
        Me.lb_tarjeta.MaximumSize = New System.Drawing.Size(180, 40)
        Me.lb_tarjeta.MinimumSize = New System.Drawing.Size(180, 40)
        Me.lb_tarjeta.Name = "lb_tarjeta"
        Me.lb_tarjeta.Size = New System.Drawing.Size(180, 40)
        Me.lb_tarjeta.TabIndex = 20
        Me.lb_tarjeta.Text = "--"
        Me.lb_tarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_referencia
        '
        Me.tb_referencia.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_referencia.Location = New System.Drawing.Point(116, 20)
        Me.tb_referencia.Name = "tb_referencia"
        Me.tb_referencia.Size = New System.Drawing.Size(80, 33)
        Me.tb_referencia.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 21)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Autorización:"
        '
        'tb_buscar
        '
        Me.tb_buscar.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_buscar.Location = New System.Drawing.Point(122, 33)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(256, 33)
        Me.tb_buscar.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tb_pago)
        Me.Panel2.Controls.Add(Me.tb_cambio)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tb_importe)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(8, 73)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(496, 79)
        Me.Panel2.TabIndex = 77
        '
        'tb_pago
        '
        Me.tb_pago.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_pago.Location = New System.Drawing.Point(181, 32)
        Me.tb_pago.Name = "tb_pago"
        Me.tb_pago.Size = New System.Drawing.Size(132, 41)
        Me.tb_pago.TabIndex = 28
        Me.tb_pago.Text = "0.00"
        Me.tb_pago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tb_cambio
        '
        Me.tb_cambio.AutoSize = True
        Me.tb_cambio.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cambio.Location = New System.Drawing.Point(347, 36)
        Me.tb_cambio.MinimumSize = New System.Drawing.Size(132, 33)
        Me.tb_cambio.Name = "tb_cambio"
        Me.tb_cambio.Size = New System.Drawing.Size(132, 33)
        Me.tb_cambio.TabIndex = 78
        Me.tb_cambio.Text = "0.00"
        Me.tb_cambio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(380, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 21)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Cambio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(232, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 21)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Pago"
        '
        'tb_importe
        '
        Me.tb_importe.AutoSize = True
        Me.tb_importe.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe.Location = New System.Drawing.Point(27, 29)
        Me.tb_importe.Name = "tb_importe"
        Me.tb_importe.Size = New System.Drawing.Size(116, 38)
        Me.tb_importe.TabIndex = 24
        Me.tb_importe.Text = "$00.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Importe"
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.White
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.ForeColor = System.Drawing.Color.Black
        Me.btn_buscar.Location = New System.Drawing.Point(400, 32)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(99, 35)
        Me.btn_buscar.TabIndex = 50
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 21)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Buscar folio:"
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(615, 172)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(50, 50)
        Me.btn_punto.TabIndex = 50
        Me.btn_punto.Text = "."
        Me.btn_punto.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(667, 118)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(55, 104)
        Me.Button14.TabIndex = 30
        Me.Button14.Text = "OK"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(615, 120)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 50)
        Me.btn3.TabIndex = 50
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(667, 67)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(55, 50)
        Me.Button10.TabIndex = 50
        Me.Button10.Text = "CA"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(615, 67)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 50)
        Me.btn6.TabIndex = 50
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(564, 120)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 50)
        Me.btn2.TabIndex = 50
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(512, 16)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 50)
        Me.btn7.TabIndex = 50
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(667, 16)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(55, 50)
        Me.Button6.TabIndex = 50
        Me.Button6.Text = "C"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(564, 16)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 50
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(512, 173)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(102, 50)
        Me.btn0.TabIndex = 50
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(512, 67)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 50
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(564, 67)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(50, 50)
        Me.btn5.TabIndex = 50
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(615, 16)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(50, 50)
        Me.btn9.TabIndex = 50
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(512, 120)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 50
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn_cobrar
        '
        Me.btn_cobrar.BackColor = System.Drawing.Color.White
        Me.btn_cobrar.Enabled = False
        Me.btn_cobrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cobrar.Image = CType(resources.GetObject("btn_cobrar.Image"), System.Drawing.Image)
        Me.btn_cobrar.Location = New System.Drawing.Point(95, 72)
        Me.btn_cobrar.Name = "btn_cobrar"
        Me.btn_cobrar.Size = New System.Drawing.Size(107, 85)
        Me.btn_cobrar.TabIndex = 54
        Me.btn_cobrar.Text = "+ Forma Pago"
        Me.btn_cobrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cobrar.UseVisualStyleBackColor = False
        Me.btn_cobrar.Visible = False
        '
        'btn_reabrir_venta
        '
        Me.btn_reabrir_venta.BackColor = System.Drawing.Color.White
        Me.btn_reabrir_venta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reabrir_venta.Image = CType(resources.GetObject("btn_reabrir_venta.Image"), System.Drawing.Image)
        Me.btn_reabrir_venta.Location = New System.Drawing.Point(8, 72)
        Me.btn_reabrir_venta.Name = "btn_reabrir_venta"
        Me.btn_reabrir_venta.Size = New System.Drawing.Size(84, 85)
        Me.btn_reabrir_venta.TabIndex = 54
        Me.btn_reabrir_venta.Text = "Reabrir"
        Me.btn_reabrir_venta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_reabrir_venta.UseVisualStyleBackColor = False
        '
        'btn_cupones
        '
        Me.btn_cupones.BackColor = System.Drawing.Color.White
        Me.btn_cupones.Enabled = False
        Me.btn_cupones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cupones.Image = CType(resources.GetObject("btn_cupones.Image"), System.Drawing.Image)
        Me.btn_cupones.Location = New System.Drawing.Point(208, 72)
        Me.btn_cupones.Name = "btn_cupones"
        Me.btn_cupones.Size = New System.Drawing.Size(94, 85)
        Me.btn_cupones.TabIndex = 53
        Me.btn_cupones.Text = "Combinado"
        Me.btn_cupones.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cupones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cupones.UseVisualStyleBackColor = False
        '
        'btn_credito
        '
        Me.btn_credito.BackColor = System.Drawing.Color.White
        Me.btn_credito.Enabled = False
        Me.btn_credito.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_credito.Image = CType(resources.GetObject("btn_credito.Image"), System.Drawing.Image)
        Me.btn_credito.Location = New System.Drawing.Point(308, 72)
        Me.btn_credito.Name = "btn_credito"
        Me.btn_credito.Size = New System.Drawing.Size(75, 85)
        Me.btn_credito.TabIndex = 55
        Me.btn_credito.Text = "Credito"
        Me.btn_credito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_credito.UseVisualStyleBackColor = False
        '
        'btn_cancelar_venta
        '
        Me.btn_cancelar_venta.BackColor = System.Drawing.Color.White
        Me.btn_cancelar_venta.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_venta.Image = CType(resources.GetObject("btn_cancelar_venta.Image"), System.Drawing.Image)
        Me.btn_cancelar_venta.Location = New System.Drawing.Point(389, 72)
        Me.btn_cancelar_venta.Name = "btn_cancelar_venta"
        Me.btn_cancelar_venta.Size = New System.Drawing.Size(82, 84)
        Me.btn_cancelar_venta.TabIndex = 56
        Me.btn_cancelar_venta.Text = "Cancelar"
        Me.btn_cancelar_venta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar_venta.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(566, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 84)
        Me.Button1.TabIndex = 58
        Me.Button1.Text = "Actualizar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_regalias
        '
        Me.btn_regalias.BackColor = System.Drawing.Color.White
        Me.btn_regalias.Enabled = False
        Me.btn_regalias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_regalias.ForeColor = System.Drawing.Color.Black
        Me.btn_regalias.Image = CType(resources.GetObject("btn_regalias.Image"), System.Drawing.Image)
        Me.btn_regalias.Location = New System.Drawing.Point(477, 72)
        Me.btn_regalias.Name = "btn_regalias"
        Me.btn_regalias.Size = New System.Drawing.Size(83, 85)
        Me.btn_regalias.TabIndex = 57
        Me.btn_regalias.Text = "Regalia"
        Me.btn_regalias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_regalias.UseVisualStyleBackColor = False
        '
        'btn_tarjeta_credito
        '
        Me.btn_tarjeta_credito.BackColor = System.Drawing.Color.White
        Me.btn_tarjeta_credito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_tarjeta_credito.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tarjeta_credito.Image = CType(resources.GetObject("btn_tarjeta_credito.Image"), System.Drawing.Image)
        Me.btn_tarjeta_credito.Location = New System.Drawing.Point(843, 419)
        Me.btn_tarjeta_credito.Name = "btn_tarjeta_credito"
        Me.btn_tarjeta_credito.Size = New System.Drawing.Size(75, 99)
        Me.btn_tarjeta_credito.TabIndex = 128
        Me.btn_tarjeta_credito.Text = "Tarjeta crédito"
        Me.btn_tarjeta_credito.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_tarjeta_credito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_tarjeta_credito.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(659, 74)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(71, 83)
        Me.btn_salir.TabIndex = 76
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_efectivo
        '
        Me.btn_efectivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_efectivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_efectivo.Image = CType(resources.GetObject("btn_efectivo.Image"), System.Drawing.Image)
        Me.btn_efectivo.Location = New System.Drawing.Point(744, 418)
        Me.btn_efectivo.Name = "btn_efectivo"
        Me.btn_efectivo.Size = New System.Drawing.Size(93, 100)
        Me.btn_efectivo.TabIndex = 130
        Me.btn_efectivo.Text = "Efectivo"
        Me.btn_efectivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_efectivo.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lb_nombre)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.pb_foto)
        Me.Panel1.Controls.Add(Me.lb_puesto)
        Me.Panel1.Location = New System.Drawing.Point(8, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(422, 60)
        Me.Panel1.TabIndex = 24
        '
        'lb_nombre
        '
        Me.lb_nombre.ActiveLinkColor = System.Drawing.Color.Black
        Me.lb_nombre.AutoSize = True
        Me.lb_nombre.BackColor = System.Drawing.Color.Transparent
        Me.lb_nombre.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_nombre.LinkColor = System.Drawing.Color.Black
        Me.lb_nombre.Location = New System.Drawing.Point(212, 10)
        Me.lb_nombre.Name = "lb_nombre"
        Me.lb_nombre.Size = New System.Drawing.Size(94, 19)
        Me.lb_nombre.TabIndex = 8
        Me.lb_nombre.TabStop = True
        Me.lb_nombre.Text = "lb_nombre"
        Me.lb_nombre.VisitedLinkColor = System.Drawing.Color.Black
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Bienvenido(a) ,"
        '
        'pb_foto
        '
        Me.pb_foto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_foto.Location = New System.Drawing.Point(7, 6)
        Me.pb_foto.Name = "pb_foto"
        Me.pb_foto.Size = New System.Drawing.Size(51, 48)
        Me.pb_foto.TabIndex = 3
        Me.pb_foto.TabStop = False
        '
        'lb_puesto
        '
        Me.lb_puesto.AutoSize = True
        Me.lb_puesto.BackColor = System.Drawing.Color.Transparent
        Me.lb_puesto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_puesto.Location = New System.Drawing.Point(84, 28)
        Me.lb_puesto.Name = "lb_puesto"
        Me.lb_puesto.Size = New System.Drawing.Size(83, 19)
        Me.lb_puesto.TabIndex = 7
        Me.lb_puesto.Text = "lb_puesto"
        '
        'btn_tarjeta_debito
        '
        Me.btn_tarjeta_debito.BackColor = System.Drawing.Color.White
        Me.btn_tarjeta_debito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_tarjeta_debito.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tarjeta_debito.Image = CType(resources.GetObject("btn_tarjeta_debito.Image"), System.Drawing.Image)
        Me.btn_tarjeta_debito.Location = New System.Drawing.Point(924, 419)
        Me.btn_tarjeta_debito.Name = "btn_tarjeta_debito"
        Me.btn_tarjeta_debito.Size = New System.Drawing.Size(75, 99)
        Me.btn_tarjeta_debito.TabIndex = 128
        Me.btn_tarjeta_debito.Text = "Tarjeta débito"
        Me.btn_tarjeta_debito.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_tarjeta_debito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_tarjeta_debito.UseVisualStyleBackColor = False
        '
        'cb_forma_pago
        '
        Me.cb_forma_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_forma_pago.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_forma_pago.FormattingEnabled = True
        Me.cb_forma_pago.Location = New System.Drawing.Point(252, 413)
        Me.cb_forma_pago.Name = "cb_forma_pago"
        Me.cb_forma_pago.Size = New System.Drawing.Size(469, 33)
        Me.cb_forma_pago.TabIndex = 132
        '
        'frm_caja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btn_salir
        Me.ClientSize = New System.Drawing.Size(1006, 683)
        Me.Controls.Add(Me.cb_forma_pago)
        Me.Controls.Add(Me.btn_efectivo)
        Me.Controls.Add(Me.btn_tarjeta_debito)
        Me.Controls.Add(Me.btn_tarjeta_credito)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.lbl_forma_pago)
        Me.Controls.Add(Me.gb_efectivo)
        Me.Controls.Add(Me.dgv_pagos)
        Me.Controls.Add(Me.btn_reabrir_venta)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_regalias)
        Me.Controls.Add(Me.btn_cobrar)
        Me.Controls.Add(Me.btn_cupones)
        Me.Controls.Add(Me.btn_cancelar_venta)
        Me.Controls.Add(Me.btn_credito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_caja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caja"
        Me.gb_efectivo.ResumeLayout(False)
        CType(Me.dgv_pagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gb_tarjeta.ResumeLayout(False)
        Me.gb_tarjeta.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pb_foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tiempo_inactivo As System.Windows.Forms.Timer
    Friend WithEvents btn_efectivo As Button
    Friend WithEvents btn_salir As Button
    Friend WithEvents btn_tarjeta_credito As Button
    Friend WithEvents btn_regalias As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btn_cancelar_venta As Button
    Friend WithEvents btn_credito As Button
    Friend WithEvents btn_cupones As Button
    Friend WithEvents btn_reabrir_venta As Button
    Friend WithEvents btn_cobrar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents gb_tarjeta As GroupBox
    Friend WithEvents lb_tarjeta As Label
    Friend WithEvents tb_referencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tb_buscar As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tb_pago As TextBox
    Friend WithEvents tb_cambio As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_importe As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_punto As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn1 As Button
    Private WithEvents dgv_pagos As DataGridView
    Friend WithEvents gb_efectivo As GroupBox
    Friend WithEvents btn_20 As Button
    Friend WithEvents btn_100 As Button
    Friend WithEvents btn_1 As Button
    Friend WithEvents btn_1000 As Button
    Friend WithEvents btn_50c As Button
    Friend WithEvents btn_200 As Button
    Friend WithEvents btn_500 As Button
    Friend WithEvents btn_5 As Button
    Friend WithEvents btn_50 As Button
    Friend WithEvents btn_2 As Button
    Friend WithEvents btn_10 As Button
    Friend WithEvents lbl_forma_pago As Label
    Private WithEvents Panel1 As Panel
    Friend WithEvents lb_nombre As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents pb_foto As PictureBox
    Friend WithEvents lb_puesto As Label
    Friend WithEvents btn_tarjeta_debito As Button
    Friend WithEvents cb_forma_pago As ComboBox
End Class
