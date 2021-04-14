<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_devoluciones))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_folio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_hora = New System.Windows.Forms.Label()
        Me.tb_fecha = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_forma_pago = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_cliente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.Label()
        Me.tb_iva = New System.Windows.Forms.Label()
        Me.tb_subtotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_salir = New System.Windows.Forms.Button()
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
        Me.gb_devoluciones = New System.Windows.Forms.GroupBox()
        Me.btn_devolver = New System.Windows.Forms.Button()
        Me.lbl_devolver = New System.Windows.Forms.Label()
        Me.lbl_devolver_total = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rb_no_devolver_almacen = New System.Windows.Forms.RadioButton()
        Me.rb_devolver_almacen = New System.Windows.Forms.RadioButton()
        Me.rb_devolucion_importe = New System.Windows.Forms.RadioButton()
        Me.rb_intercambio_producto = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dg_devoluciones = New System.Windows.Forms.DataGridView()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.tb_folio = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gb_devoluciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio:"
        '
        'GroupBox1
        '
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
        Me.GroupBox1.Controls.Add(Me.gb_devoluciones)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.tb_folio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(970, 649)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingrese el folio del ticket"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbl_folio)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.tb_hora)
        Me.Panel2.Controls.Add(Me.tb_fecha)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.tb_forma_pago)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.tb_cliente)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tb_total)
        Me.Panel2.Controls.Add(Me.tb_iva)
        Me.Panel2.Controls.Add(Me.tb_subtotal)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(6, 425)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(693, 186)
        Me.Panel2.TabIndex = 97
        '
        'lbl_folio
        '
        Me.lbl_folio.AutoSize = True
        Me.lbl_folio.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_folio.Location = New System.Drawing.Point(91, 19)
        Me.lbl_folio.Name = "lbl_folio"
        Me.lbl_folio.Size = New System.Drawing.Size(20, 18)
        Me.lbl_folio.TabIndex = 115
        Me.lbl_folio.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 20)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "FOLIO:"
        '
        'tb_hora
        '
        Me.tb_hora.AutoSize = True
        Me.tb_hora.Location = New System.Drawing.Point(94, 136)
        Me.tb_hora.Name = "tb_hora"
        Me.tb_hora.Size = New System.Drawing.Size(19, 20)
        Me.tb_hora.TabIndex = 111
        Me.tb_hora.Text = "--"
        '
        'tb_fecha
        '
        Me.tb_fecha.AutoSize = True
        Me.tb_fecha.Location = New System.Drawing.Point(94, 105)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(19, 20)
        Me.tb_fecha.TabIndex = 109
        Me.tb_fecha.Text = "--"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(29, 136)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 20)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Hora:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 20)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Fecha:"
        '
        'tb_forma_pago
        '
        Me.tb_forma_pago.AutoSize = True
        Me.tb_forma_pago.Location = New System.Drawing.Point(155, 156)
        Me.tb_forma_pago.Name = "tb_forma_pago"
        Me.tb_forma_pago.Size = New System.Drawing.Size(19, 20)
        Me.tb_forma_pago.TabIndex = 103
        Me.tb_forma_pago.Text = "--"
        Me.tb_forma_pago.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 20)
        Me.Label8.TabIndex = 101
        Me.Label8.Text = "Forma de pago:"
        Me.Label8.Visible = False
        '
        'tb_cliente
        '
        Me.tb_cliente.AutoSize = True
        Me.tb_cliente.Location = New System.Drawing.Point(100, 51)
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
        Me.Label4.Location = New System.Drawing.Point(384, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 30)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "TOTAL:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(383, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 21)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "IVA:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(383, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 21)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "SUBTOTAL:"
        '
        'tb_total
        '
        Me.tb_total.AutoSize = True
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(471, 90)
        Me.tb_total.MinimumSize = New System.Drawing.Size(198, 0)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.Size = New System.Drawing.Size(198, 41)
        Me.tb_total.TabIndex = 85
        Me.tb_total.Text = "$00.00"
        Me.tb_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_iva
        '
        Me.tb_iva.AutoSize = True
        Me.tb_iva.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_iva.Location = New System.Drawing.Point(514, 40)
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
        Me.tb_subtotal.Location = New System.Drawing.Point(514, 11)
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
        Me.Label2.Location = New System.Drawing.Point(29, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Cliente:"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(787, 581)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(124, 62)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Enabled = False
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(838, 188)
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
        Me.Button14.Location = New System.Drawing.Point(890, 134)
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
        Me.btn3.Location = New System.Drawing.Point(838, 136)
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
        Me.Button10.Location = New System.Drawing.Point(890, 83)
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
        Me.btn6.Location = New System.Drawing.Point(838, 83)
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
        Me.btn2.Location = New System.Drawing.Point(787, 136)
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
        Me.btn7.Location = New System.Drawing.Point(735, 32)
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
        Me.Button6.Location = New System.Drawing.Point(890, 32)
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
        Me.btn8.Location = New System.Drawing.Point(787, 32)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 81
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(735, 189)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(102, 50)
        Me.btn0.TabIndex = 80
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(735, 83)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 83
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(787, 83)
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
        Me.btn9.Location = New System.Drawing.Point(838, 32)
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
        Me.btn1.Location = New System.Drawing.Point(735, 136)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 84
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'gb_devoluciones
        '
        Me.gb_devoluciones.Controls.Add(Me.btn_devolver)
        Me.gb_devoluciones.Controls.Add(Me.lbl_devolver)
        Me.gb_devoluciones.Controls.Add(Me.lbl_devolver_total)
        Me.gb_devoluciones.Controls.Add(Me.Panel1)
        Me.gb_devoluciones.Controls.Add(Me.rb_devolucion_importe)
        Me.gb_devoluciones.Controls.Add(Me.rb_intercambio_producto)
        Me.gb_devoluciones.Location = New System.Drawing.Point(705, 246)
        Me.gb_devoluciones.Name = "gb_devoluciones"
        Me.gb_devoluciones.Size = New System.Drawing.Size(252, 329)
        Me.gb_devoluciones.TabIndex = 7
        Me.gb_devoluciones.TabStop = False
        Me.gb_devoluciones.Text = "Devoluciones"
        '
        'btn_devolver
        '
        Me.btn_devolver.BackColor = System.Drawing.Color.White
        Me.btn_devolver.Enabled = False
        Me.btn_devolver.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_devolver.Image = CType(resources.GetObject("btn_devolver.Image"), System.Drawing.Image)
        Me.btn_devolver.Location = New System.Drawing.Point(37, 188)
        Me.btn_devolver.Name = "btn_devolver"
        Me.btn_devolver.Size = New System.Drawing.Size(171, 65)
        Me.btn_devolver.TabIndex = 57
        Me.btn_devolver.Text = "Aplicar devolución"
        Me.btn_devolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_devolver.UseVisualStyleBackColor = False
        '
        'lbl_devolver
        '
        Me.lbl_devolver.AutoSize = True
        Me.lbl_devolver.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_devolver.Location = New System.Drawing.Point(27, 256)
        Me.lbl_devolver.Name = "lbl_devolver"
        Me.lbl_devolver.Size = New System.Drawing.Size(181, 30)
        Me.lbl_devolver.TabIndex = 56
        Me.lbl_devolver.Text = "DEVOLUCIÓN:"
        Me.lbl_devolver.Visible = False
        '
        'lbl_devolver_total
        '
        Me.lbl_devolver_total.AutoSize = True
        Me.lbl_devolver_total.Font = New System.Drawing.Font("Century Gothic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_devolver_total.Location = New System.Drawing.Point(23, 282)
        Me.lbl_devolver_total.MinimumSize = New System.Drawing.Size(198, 0)
        Me.lbl_devolver_total.Name = "lbl_devolver_total"
        Me.lbl_devolver_total.Size = New System.Drawing.Size(198, 41)
        Me.lbl_devolver_total.TabIndex = 55
        Me.lbl_devolver_total.Text = "$00.00"
        Me.lbl_devolver_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_devolver_total.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rb_no_devolver_almacen)
        Me.Panel1.Controls.Add(Me.rb_devolver_almacen)
        Me.Panel1.Location = New System.Drawing.Point(6, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 69)
        Me.Panel1.TabIndex = 4
        '
        'rb_no_devolver_almacen
        '
        Me.rb_no_devolver_almacen.AutoSize = True
        Me.rb_no_devolver_almacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_no_devolver_almacen.Location = New System.Drawing.Point(3, 40)
        Me.rb_no_devolver_almacen.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_no_devolver_almacen.MinimumSize = New System.Drawing.Size(0, 20)
        Me.rb_no_devolver_almacen.Name = "rb_no_devolver_almacen"
        Me.rb_no_devolver_almacen.Size = New System.Drawing.Size(184, 21)
        Me.rb_no_devolver_almacen.TabIndex = 4
        Me.rb_no_devolver_almacen.Text = "No devolver al almacén"
        Me.rb_no_devolver_almacen.UseVisualStyleBackColor = True
        '
        'rb_devolver_almacen
        '
        Me.rb_devolver_almacen.AutoSize = True
        Me.rb_devolver_almacen.Checked = True
        Me.rb_devolver_almacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_devolver_almacen.Location = New System.Drawing.Point(4, 2)
        Me.rb_devolver_almacen.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_devolver_almacen.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_devolver_almacen.Name = "rb_devolver_almacen"
        Me.rb_devolver_almacen.Size = New System.Drawing.Size(230, 40)
        Me.rb_devolver_almacen.TabIndex = 3
        Me.rb_devolver_almacen.TabStop = True
        Me.rb_devolver_almacen.Text = "Devolucion de producto al almacén"
        Me.rb_devolver_almacen.UseVisualStyleBackColor = True
        '
        'rb_devolucion_importe
        '
        Me.rb_devolucion_importe.AutoSize = True
        Me.rb_devolucion_importe.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_devolucion_importe.Location = New System.Drawing.Point(11, 67)
        Me.rb_devolucion_importe.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_devolucion_importe.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_devolucion_importe.Name = "rb_devolucion_importe"
        Me.rb_devolucion_importe.Size = New System.Drawing.Size(230, 40)
        Me.rb_devolucion_importe.TabIndex = 3
        Me.rb_devolucion_importe.TabStop = True
        Me.rb_devolucion_importe.Text = "Devolucion en efectivo del importe de los productos"
        Me.rb_devolucion_importe.UseVisualStyleBackColor = True
        '
        'rb_intercambio_producto
        '
        Me.rb_intercambio_producto.AutoSize = True
        Me.rb_intercambio_producto.Checked = True
        Me.rb_intercambio_producto.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_intercambio_producto.Location = New System.Drawing.Point(12, 27)
        Me.rb_intercambio_producto.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_intercambio_producto.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_intercambio_producto.Name = "rb_intercambio_producto"
        Me.rb_intercambio_producto.Size = New System.Drawing.Size(230, 40)
        Me.rb_intercambio_producto.TabIndex = 0
        Me.rb_intercambio_producto.TabStop = True
        Me.rb_intercambio_producto.Text = "Cambio de producto de la misma presentación."
        Me.rb_intercambio_producto.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(19, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(680, 345)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'dg_devoluciones
        '
        Me.dg_devoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_devoluciones.Location = New System.Drawing.Point(6, 15)
        Me.dg_devoluciones.Name = "dg_devoluciones"
        Me.dg_devoluciones.Size = New System.Drawing.Size(668, 320)
        Me.dg_devoluciones.TabIndex = 5
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.White
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(197, 18)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(137, 58)
        Me.btn_buscar.TabIndex = 5
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'tb_folio
        '
        Me.tb_folio.Location = New System.Drawing.Point(67, 32)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.Size = New System.Drawing.Size(100, 26)
        Me.tb_folio.TabIndex = 1
        '
        'frm_devoluciones
        '
        Me.AcceptButton = Me.btn_buscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(994, 661)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_devoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gb_devoluciones.ResumeLayout(False)
        Me.gb_devoluciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_folio As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_devoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents gb_devoluciones As System.Windows.Forms.GroupBox
    Friend WithEvents rb_devolucion_importe As System.Windows.Forms.RadioButton
    Friend WithEvents rb_intercambio_producto As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rb_no_devolver_almacen As System.Windows.Forms.RadioButton
    Friend WithEvents rb_devolver_almacen As System.Windows.Forms.RadioButton
    Friend WithEvents btn_devolver As System.Windows.Forms.Button
    Friend WithEvents lbl_devolver As System.Windows.Forms.Label
    Friend WithEvents lbl_devolver_total As System.Windows.Forms.Label
    Friend WithEvents btn_punto As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
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
End Class
