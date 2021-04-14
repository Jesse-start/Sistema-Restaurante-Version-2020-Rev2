<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_descuentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_descuentos))
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.Label()
        Me.tb_descuento_total = New System.Windows.Forms.Label()
        Me.tb_iva = New System.Windows.Forms.Label()
        Me.tb_subtotal = New System.Windows.Forms.Label()
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
        Me.rb_descuento_global = New System.Windows.Forms.RadioButton()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.dgv_descuentos = New System.Windows.Forms.DataGridView()
        Me.rb_descuento_producto = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tb_importe = New System.Windows.Forms.TextBox()
        Me.tb_descuento = New System.Windows.Forms.TextBox()
        Me.rb_descuento_global_importe = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_porciento = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_informacion = New System.Windows.Forms.Label()
        Me.tb_descuento_producto = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_descuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(528, 390)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(132, 73)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.White
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.Location = New System.Drawing.Point(345, 390)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(161, 73)
        Me.btn_aceptar.TabIndex = 57
        Me.btn_aceptar.Text = "Aplicar Descuento"
        Me.btn_aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tb_total)
        Me.Panel2.Controls.Add(Me.tb_descuento_total)
        Me.Panel2.Controls.Add(Me.tb_iva)
        Me.Panel2.Controls.Add(Me.tb_subtotal)
        Me.Panel2.Location = New System.Drawing.Point(0, 379)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(317, 154)
        Me.Panel2.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 30)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "TOTAL:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 21)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "DESCUENTO:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 21)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "IVA:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 21)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "SUBTOTAL:"
        '
        'tb_total
        '
        Me.tb_total.AutoSize = True
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(110, 102)
        Me.tb_total.MinimumSize = New System.Drawing.Size(198, 0)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.Size = New System.Drawing.Size(198, 41)
        Me.tb_total.TabIndex = 85
        Me.tb_total.Text = "$00.00"
        Me.tb_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_descuento_total
        '
        Me.tb_descuento_total.AutoSize = True
        Me.tb_descuento_total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_descuento_total.Location = New System.Drawing.Point(140, 65)
        Me.tb_descuento_total.MinimumSize = New System.Drawing.Size(151, 0)
        Me.tb_descuento_total.Name = "tb_descuento_total"
        Me.tb_descuento_total.Size = New System.Drawing.Size(151, 19)
        Me.tb_descuento_total.TabIndex = 82
        Me.tb_descuento_total.Text = "$00.00"
        Me.tb_descuento_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tb_iva
        '
        Me.tb_iva.AutoSize = True
        Me.tb_iva.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_iva.Location = New System.Drawing.Point(140, 36)
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
        Me.tb_subtotal.Location = New System.Drawing.Point(140, 7)
        Me.tb_subtotal.MinimumSize = New System.Drawing.Size(151, 0)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.Size = New System.Drawing.Size(151, 19)
        Me.tb_subtotal.TabIndex = 88
        Me.tb_subtotal.Text = "$00.00"
        Me.tb_subtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(871, 219)
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
        Me.Button14.Location = New System.Drawing.Point(923, 165)
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
        Me.btn3.Location = New System.Drawing.Point(871, 167)
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
        Me.Button10.Location = New System.Drawing.Point(923, 114)
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
        Me.btn6.Location = New System.Drawing.Point(871, 114)
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
        Me.btn2.Location = New System.Drawing.Point(820, 167)
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
        Me.btn7.Location = New System.Drawing.Point(768, 63)
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
        Me.Button6.Location = New System.Drawing.Point(923, 63)
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
        Me.btn8.Location = New System.Drawing.Point(820, 63)
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
        Me.btn4.Location = New System.Drawing.Point(768, 114)
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
        Me.btn0.Location = New System.Drawing.Point(768, 220)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(102, 50)
        Me.btn0.TabIndex = 80
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'rb_descuento_global
        '
        Me.rb_descuento_global.AutoSize = True
        Me.rb_descuento_global.Checked = True
        Me.rb_descuento_global.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_descuento_global.Location = New System.Drawing.Point(10, 14)
        Me.rb_descuento_global.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_descuento_global.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_descuento_global.Name = "rb_descuento_global"
        Me.rb_descuento_global.Size = New System.Drawing.Size(163, 40)
        Me.rb_descuento_global.TabIndex = 0
        Me.rb_descuento_global.TabStop = True
        Me.rb_descuento_global.Text = "Descuento global"
        Me.rb_descuento_global.UseVisualStyleBackColor = True
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(820, 114)
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
        Me.btn9.Location = New System.Drawing.Point(871, 63)
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
        Me.btn1.Location = New System.Drawing.Point(768, 167)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 84
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'dgv_descuentos
        '
        Me.dgv_descuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_descuentos.Location = New System.Drawing.Point(6, 97)
        Me.dgv_descuentos.Name = "dgv_descuentos"
        Me.dgv_descuentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_descuentos.Size = New System.Drawing.Size(746, 243)
        Me.dgv_descuentos.TabIndex = 5
        '
        'rb_descuento_producto
        '
        Me.rb_descuento_producto.AutoSize = True
        Me.rb_descuento_producto.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_descuento_producto.Location = New System.Drawing.Point(339, 17)
        Me.rb_descuento_producto.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_descuento_producto.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_descuento_producto.Name = "rb_descuento_producto"
        Me.rb_descuento_producto.Size = New System.Drawing.Size(213, 40)
        Me.rb_descuento_producto.TabIndex = 3
        Me.rb_descuento_producto.Text = "Descuento por producto"
        Me.rb_descuento_producto.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tb_importe)
        Me.GroupBox2.Controls.Add(Me.tb_descuento)
        Me.GroupBox2.Controls.Add(Me.dgv_descuentos)
        Me.GroupBox2.Controls.Add(Me.rb_descuento_global_importe)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.rb_descuento_global)
        Me.GroupBox2.Controls.Add(Me.lb_porciento)
        Me.GroupBox2.Controls.Add(Me.rb_descuento_producto)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(758, 355)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'tb_importe
        '
        Me.tb_importe.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe.Location = New System.Drawing.Point(191, 58)
        Me.tb_importe.Name = "tb_importe"
        Me.tb_importe.Size = New System.Drawing.Size(100, 27)
        Me.tb_importe.TabIndex = 98
        '
        'tb_descuento
        '
        Me.tb_descuento.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_descuento.Location = New System.Drawing.Point(191, 21)
        Me.tb_descuento.Name = "tb_descuento"
        Me.tb_descuento.Size = New System.Drawing.Size(100, 27)
        Me.tb_descuento.TabIndex = 98
        '
        'rb_descuento_global_importe
        '
        Me.rb_descuento_global_importe.AutoSize = True
        Me.rb_descuento_global_importe.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_descuento_global_importe.Location = New System.Drawing.Point(10, 51)
        Me.rb_descuento_global_importe.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_descuento_global_importe.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_descuento_global_importe.Name = "rb_descuento_global_importe"
        Me.rb_descuento_global_importe.Size = New System.Drawing.Size(163, 40)
        Me.rb_descuento_global_importe.TabIndex = 0
        Me.rb_descuento_global_importe.Text = "Descuento global"
        Me.rb_descuento_global_importe.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(169, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 21)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "$"
        '
        'lb_porciento
        '
        Me.lb_porciento.AutoSize = True
        Me.lb_porciento.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_porciento.Location = New System.Drawing.Point(297, 27)
        Me.lb_porciento.Name = "lb_porciento"
        Me.lb_porciento.Size = New System.Drawing.Size(22, 21)
        Me.lb_porciento.TabIndex = 97
        Me.lb_porciento.Text = "%"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lb_informacion)
        Me.GroupBox1.Controls.Add(Me.tb_descuento_producto)
        Me.GroupBox1.Controls.Add(Me.btn_aceptar)
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
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 555)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingrese el folio del ticket"
        '
        'lb_informacion
        '
        Me.lb_informacion.AutoSize = True
        Me.lb_informacion.Font = New System.Drawing.Font("Century Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_informacion.Location = New System.Drawing.Point(774, 275)
        Me.lb_informacion.MaximumSize = New System.Drawing.Size(210, 150)
        Me.lb_informacion.MinimumSize = New System.Drawing.Size(210, 150)
        Me.lb_informacion.Name = "lb_informacion"
        Me.lb_informacion.Size = New System.Drawing.Size(210, 150)
        Me.lb_informacion.TabIndex = 99
        Me.lb_informacion.Text = "--"
        '
        'tb_descuento_producto
        '
        Me.tb_descuento_producto.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_descuento_producto.Location = New System.Drawing.Point(770, 24)
        Me.tb_descuento_producto.Name = "tb_descuento_producto"
        Me.tb_descuento_producto.Size = New System.Drawing.Size(208, 33)
        Me.tb_descuento_producto.TabIndex = 98
        Me.tb_descuento_producto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frm_descuentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 582)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_descuentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplicar descuentos"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_descuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_total As System.Windows.Forms.Label
    Friend WithEvents tb_descuento_total As System.Windows.Forms.Label
    Friend WithEvents tb_iva As System.Windows.Forms.Label
    Friend WithEvents tb_subtotal As System.Windows.Forms.Label
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
    Friend WithEvents rb_descuento_global As System.Windows.Forms.RadioButton
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents dgv_descuentos As System.Windows.Forms.DataGridView
    Friend WithEvents rb_descuento_producto As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_descuento As System.Windows.Forms.TextBox
    Friend WithEvents lb_porciento As System.Windows.Forms.Label
    Friend WithEvents tb_descuento_producto As System.Windows.Forms.TextBox
    Friend WithEvents lb_informacion As System.Windows.Forms.Label
    Friend WithEvents tb_importe As System.Windows.Forms.TextBox
    Friend WithEvents rb_descuento_global_importe As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
