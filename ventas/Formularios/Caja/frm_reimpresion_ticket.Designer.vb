<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reimpresion_ticket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reimpresion_ticket))
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_reimprimir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tb_status = New System.Windows.Forms.Label()
        Me.lbl_folio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_hora = New System.Windows.Forms.Label()
        Me.tb_fecha = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_empleado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_forma_pago = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_cliente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.Label()
        Me.tb_otros = New System.Windows.Forms.Label()
        Me.tb_iva = New System.Windows.Forms.Label()
        Me.tb_subtotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_punto = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.dg_devoluciones = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.tb_folio = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lst_Pagos = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(783, 537)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(131, 66)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_reimprimir
        '
        Me.btn_reimprimir.BackColor = System.Drawing.Color.White
        Me.btn_reimprimir.Enabled = False
        Me.btn_reimprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimprimir.Image = CType(resources.GetObject("btn_reimprimir.Image"), System.Drawing.Image)
        Me.btn_reimprimir.Location = New System.Drawing.Point(639, 537)
        Me.btn_reimprimir.Name = "btn_reimprimir"
        Me.btn_reimprimir.Size = New System.Drawing.Size(138, 68)
        Me.btn_reimprimir.TabIndex = 57
        Me.btn_reimprimir.Text = "Reimprimir Ticket"
        Me.btn_reimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reimprimir.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tb_status)
        Me.Panel2.Controls.Add(Me.lbl_folio)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.tb_hora)
        Me.Panel2.Controls.Add(Me.tb_fecha)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.tb_empleado)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.tb_forma_pago)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.tb_cliente)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tb_total)
        Me.Panel2.Controls.Add(Me.tb_otros)
        Me.Panel2.Controls.Add(Me.tb_iva)
        Me.Panel2.Controls.Add(Me.tb_subtotal)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(6, 354)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(627, 235)
        Me.Panel2.TabIndex = 97
        '
        'tb_status
        '
        Me.tb_status.AutoSize = True
        Me.tb_status.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_status.Location = New System.Drawing.Point(319, 185)
        Me.tb_status.Name = "tb_status"
        Me.tb_status.Size = New System.Drawing.Size(32, 28)
        Me.tb_status.TabIndex = 115
        Me.tb_status.Text = "--"
        '
        'lbl_folio
        '
        Me.lbl_folio.AutoSize = True
        Me.lbl_folio.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_folio.Location = New System.Drawing.Point(73, 14)
        Me.lbl_folio.Name = "lbl_folio"
        Me.lbl_folio.Size = New System.Drawing.Size(20, 18)
        Me.lbl_folio.TabIndex = 115
        Me.lbl_folio.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 20)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "FOLIO:"
        '
        'tb_hora
        '
        Me.tb_hora.AutoSize = True
        Me.tb_hora.Location = New System.Drawing.Point(77, 121)
        Me.tb_hora.Name = "tb_hora"
        Me.tb_hora.Size = New System.Drawing.Size(19, 20)
        Me.tb_hora.TabIndex = 111
        Me.tb_hora.Text = "--"
        '
        'tb_fecha
        '
        Me.tb_fecha.AutoSize = True
        Me.tb_fecha.Location = New System.Drawing.Point(77, 92)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(19, 20)
        Me.tb_fecha.TabIndex = 109
        Me.tb_fecha.Text = "--"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 20)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Hora:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 20)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Fecha:"
        '
        'tb_empleado
        '
        Me.tb_empleado.AutoSize = True
        Me.tb_empleado.Location = New System.Drawing.Point(89, 184)
        Me.tb_empleado.Name = "tb_empleado"
        Me.tb_empleado.Size = New System.Drawing.Size(19, 20)
        Me.tb_empleado.TabIndex = 103
        Me.tb_empleado.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 20)
        Me.Label9.TabIndex = 101
        Me.Label9.Text = "Atendio:"
        '
        'tb_forma_pago
        '
        Me.tb_forma_pago.AutoSize = True
        Me.tb_forma_pago.Location = New System.Drawing.Point(149, 149)
        Me.tb_forma_pago.Name = "tb_forma_pago"
        Me.tb_forma_pago.Size = New System.Drawing.Size(19, 20)
        Me.tb_forma_pago.TabIndex = 103
        Me.tb_forma_pago.Text = "--"
        Me.tb_forma_pago.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 20)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Forma de pago:"
        Me.Label8.Visible = False
        '
        'tb_cliente
        '
        Me.tb_cliente.AutoSize = True
        Me.tb_cliente.Location = New System.Drawing.Point(82, 46)
        Me.tb_cliente.MaximumSize = New System.Drawing.Size(240, 0)
        Me.tb_cliente.Name = "tb_cliente"
        Me.tb_cliente.Size = New System.Drawing.Size(19, 20)
        Me.tb_cliente.TabIndex = 99
        Me.tb_cliente.Text = "--"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(319, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 30)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "TOTAL:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(318, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 21)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Descuento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(318, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 21)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Total Impuestos:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(318, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 21)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "SUBTOTAL:"
        '
        'tb_total
        '
        Me.tb_total.AutoSize = True
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(406, 91)
        Me.tb_total.MinimumSize = New System.Drawing.Size(198, 0)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.Size = New System.Drawing.Size(198, 41)
        Me.tb_total.TabIndex = 85
        Me.tb_total.Text = "$00.00"
        Me.tb_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_otros
        '
        Me.tb_otros.AutoSize = True
        Me.tb_otros.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_otros.Location = New System.Drawing.Point(449, 70)
        Me.tb_otros.MinimumSize = New System.Drawing.Size(151, 0)
        Me.tb_otros.Name = "tb_otros"
        Me.tb_otros.Size = New System.Drawing.Size(151, 19)
        Me.tb_otros.TabIndex = 82
        Me.tb_otros.Text = "$00.00"
        Me.tb_otros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_iva
        '
        Me.tb_iva.AutoSize = True
        Me.tb_iva.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_iva.Location = New System.Drawing.Point(449, 41)
        Me.tb_iva.MinimumSize = New System.Drawing.Size(151, 0)
        Me.tb_iva.Name = "tb_iva"
        Me.tb_iva.Size = New System.Drawing.Size(151, 19)
        Me.tb_iva.TabIndex = 86
        Me.tb_iva.Text = "$00.00"
        Me.tb_iva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_subtotal
        '
        Me.tb_subtotal.AutoSize = True
        Me.tb_subtotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_subtotal.Location = New System.Drawing.Point(449, 12)
        Me.tb_subtotal.MinimumSize = New System.Drawing.Size(151, 0)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.Size = New System.Drawing.Size(151, 19)
        Me.tb_subtotal.TabIndex = 88
        Me.tb_subtotal.Text = "$00.00"
        Me.tb_subtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Cliente:"
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Enabled = False
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(777, 262)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(50, 50)
        Me.btn_punto.TabIndex = 89
        Me.btn_punto.Text = "."
        Me.btn_punto.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(829, 208)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(55, 104)
        Me.Button14.TabIndex = 88
        Me.Button14.Text = "OK"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(777, 210)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 50)
        Me.btn3.TabIndex = 87
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(829, 157)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(55, 50)
        Me.Button10.TabIndex = 90
        Me.Button10.Text = "CA"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(777, 157)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 50)
        Me.btn6.TabIndex = 93
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(726, 210)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 50)
        Me.btn2.TabIndex = 92
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(674, 106)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 50)
        Me.btn7.TabIndex = 91
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(829, 106)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(55, 50)
        Me.Button6.TabIndex = 82
        Me.Button6.Text = "C"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(726, 106)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 81
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(674, 157)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 83
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(674, 263)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(102, 50)
        Me.btn0.TabIndex = 80
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(726, 157)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(50, 50)
        Me.btn5.TabIndex = 86
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(777, 106)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(50, 50)
        Me.btn9.TabIndex = 85
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(674, 210)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 84
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'dg_devoluciones
        '
        Me.dg_devoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_devoluciones.Location = New System.Drawing.Point(6, 15)
        Me.dg_devoluciones.Name = "dg_devoluciones"
        Me.dg_devoluciones.Size = New System.Drawing.Size(612, 303)
        Me.dg_devoluciones.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(627, 327)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.White
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(803, 25)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(111, 64)
        Me.btn_buscar.TabIndex = 5
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'tb_folio
        '
        Me.tb_folio.Location = New System.Drawing.Point(697, 45)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.Size = New System.Drawing.Size(100, 26)
        Me.tb_folio.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lst_Pagos)
        Me.GroupBox1.Controls.Add(Me.btn_reimprimir)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
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
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.tb_folio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(938, 610)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingrese el folio del ticket"
        '
        'lst_Pagos
        '
        Me.lst_Pagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_Pagos.FullRowSelect = True
        Me.lst_Pagos.HideSelection = False
        Me.lst_Pagos.Location = New System.Drawing.Point(649, 346)
        Me.lst_Pagos.Name = "lst_Pagos"
        Me.lst_Pagos.ShowItemToolTips = True
        Me.lst_Pagos.Size = New System.Drawing.Size(272, 177)
        Me.lst_Pagos.TabIndex = 98
        Me.lst_Pagos.UseCompatibleStateImageBehavior = False
        Me.lst_Pagos.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(645, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio:"
        '
        'frm_reimpresion_ticket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 618)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reimpresion_ticket"
        Me.Text = "Reimpresión de Ticket"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_reimprimir As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_folio As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tb_hora As System.Windows.Forms.Label
    Friend WithEvents tb_fecha As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_forma_pago As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_cliente As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_total As System.Windows.Forms.Label
    Friend WithEvents tb_iva As System.Windows.Forms.Label
    Friend WithEvents tb_subtotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_punto As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents dg_devoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents tb_folio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lst_Pagos As System.Windows.Forms.ListView
    Friend WithEvents tb_status As System.Windows.Forms.Label
    Friend WithEvents tb_empleado As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tb_otros As System.Windows.Forms.Label
End Class
