<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_devoluciones_proveedor
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gb_devolucion = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_folio = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tb_hora = New System.Windows.Forms.Label()
        Me.tb_fecha = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_proveedor = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.Label()
        Me.tb_otros = New System.Windows.Forms.Label()
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
        Me.rb_descontar_inventario = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dg_devoluciones = New System.Windows.Forms.DataGridView()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.tb_folio = New System.Windows.Forms.TextBox()
        Me.lbl_total_devolucion = New System.Windows.Forms.Label()
        Me.tb_total_despues_devolucion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gb_devolucion.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gb_devoluciones.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(710, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio:"
        '
        'gb_devolucion
        '
        Me.gb_devolucion.Controls.Add(Me.Panel2)
        Me.gb_devolucion.Controls.Add(Me.btn_salir)
        Me.gb_devolucion.Controls.Add(Me.btn_punto)
        Me.gb_devolucion.Controls.Add(Me.Button14)
        Me.gb_devolucion.Controls.Add(Me.btn3)
        Me.gb_devolucion.Controls.Add(Me.Button10)
        Me.gb_devolucion.Controls.Add(Me.btn6)
        Me.gb_devolucion.Controls.Add(Me.btn2)
        Me.gb_devolucion.Controls.Add(Me.btn7)
        Me.gb_devolucion.Controls.Add(Me.Button6)
        Me.gb_devolucion.Controls.Add(Me.btn8)
        Me.gb_devolucion.Controls.Add(Me.btn0)
        Me.gb_devolucion.Controls.Add(Me.btn4)
        Me.gb_devolucion.Controls.Add(Me.btn5)
        Me.gb_devolucion.Controls.Add(Me.btn9)
        Me.gb_devolucion.Controls.Add(Me.btn1)
        Me.gb_devolucion.Controls.Add(Me.gb_devoluciones)
        Me.gb_devolucion.Controls.Add(Me.GroupBox2)
        Me.gb_devolucion.Controls.Add(Me.btn_buscar)
        Me.gb_devolucion.Controls.Add(Me.tb_folio)
        Me.gb_devolucion.Controls.Add(Me.Label1)
        Me.gb_devolucion.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_devolucion.Location = New System.Drawing.Point(12, 10)
        Me.gb_devolucion.Name = "gb_devolucion"
        Me.gb_devolucion.Size = New System.Drawing.Size(970, 584)
        Me.gb_devolucion.TabIndex = 1
        Me.gb_devolucion.TabStop = False
        Me.gb_devolucion.Text = "Devolucion proveedor"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lbl_folio)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.tb_hora)
        Me.Panel2.Controls.Add(Me.tb_fecha)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.tb_proveedor)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tb_total_despues_devolucion)
        Me.Panel2.Controls.Add(Me.tb_total)
        Me.Panel2.Controls.Add(Me.tb_otros)
        Me.Panel2.Controls.Add(Me.tb_iva)
        Me.Panel2.Controls.Add(Me.tb_subtotal)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(6, 376)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(680, 186)
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
        Me.Label7.Location = New System.Drawing.Point(35, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 20)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "FOLIO:"
        '
        'tb_hora
        '
        Me.tb_hora.AutoSize = True
        Me.tb_hora.Location = New System.Drawing.Point(100, 130)
        Me.tb_hora.Name = "tb_hora"
        Me.tb_hora.Size = New System.Drawing.Size(19, 20)
        Me.tb_hora.TabIndex = 111
        Me.tb_hora.Text = "--"
        '
        'tb_fecha
        '
        Me.tb_fecha.AutoSize = True
        Me.tb_fecha.Location = New System.Drawing.Point(100, 99)
        Me.tb_fecha.Name = "tb_fecha"
        Me.tb_fecha.Size = New System.Drawing.Size(19, 20)
        Me.tb_fecha.TabIndex = 109
        Me.tb_fecha.Text = "--"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(46, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 20)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Hora:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(35, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 20)
        Me.Label10.TabIndex = 105
        Me.Label10.Text = "Fecha:"
        '
        'tb_proveedor
        '
        Me.tb_proveedor.AutoSize = True
        Me.tb_proveedor.Location = New System.Drawing.Point(100, 51)
        Me.tb_proveedor.MaximumSize = New System.Drawing.Size(240, 0)
        Me.tb_proveedor.Name = "tb_proveedor"
        Me.tb_proveedor.Size = New System.Drawing.Size(19, 20)
        Me.tb_proveedor.TabIndex = 99
        Me.tb_proveedor.Text = "--"
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(383, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 21)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "OTROS:"
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
        'tb_otros
        '
        Me.tb_otros.AutoSize = True
        Me.tb_otros.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_otros.Location = New System.Drawing.Point(514, 69)
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
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Proveedor:"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_salir.Location = New System.Drawing.Point(757, 533)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(124, 51)
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
        Me.btn_punto.Location = New System.Drawing.Point(812, 244)
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
        Me.Button14.Location = New System.Drawing.Point(864, 190)
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
        Me.btn3.Location = New System.Drawing.Point(812, 192)
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
        Me.Button10.Location = New System.Drawing.Point(864, 139)
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
        Me.btn6.Location = New System.Drawing.Point(812, 139)
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
        Me.btn2.Location = New System.Drawing.Point(761, 192)
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
        Me.btn7.Location = New System.Drawing.Point(709, 88)
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
        Me.Button6.Location = New System.Drawing.Point(864, 88)
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
        Me.btn8.Location = New System.Drawing.Point(761, 88)
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
        Me.btn0.Location = New System.Drawing.Point(709, 245)
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
        Me.btn4.Location = New System.Drawing.Point(709, 139)
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
        Me.btn5.Location = New System.Drawing.Point(761, 139)
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
        Me.btn9.Location = New System.Drawing.Point(812, 88)
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
        Me.btn1.Location = New System.Drawing.Point(709, 192)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 84
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'gb_devoluciones
        '
        Me.gb_devoluciones.Controls.Add(Me.lbl_total_devolucion)
        Me.gb_devoluciones.Controls.Add(Me.btn_devolver)
        Me.gb_devoluciones.Controls.Add(Me.rb_descontar_inventario)
        Me.gb_devoluciones.Location = New System.Drawing.Point(705, 378)
        Me.gb_devoluciones.Name = "gb_devoluciones"
        Me.gb_devoluciones.Size = New System.Drawing.Size(259, 149)
        Me.gb_devoluciones.TabIndex = 7
        Me.gb_devoluciones.TabStop = False
        Me.gb_devoluciones.Text = "Devoluciones"
        '
        'btn_devolver
        '
        Me.btn_devolver.BackColor = System.Drawing.Color.White
        Me.btn_devolver.Enabled = False
        Me.btn_devolver.Location = New System.Drawing.Point(57, 111)
        Me.btn_devolver.Name = "btn_devolver"
        Me.btn_devolver.Size = New System.Drawing.Size(108, 32)
        Me.btn_devolver.TabIndex = 57
        Me.btn_devolver.Text = "Devolver"
        Me.btn_devolver.UseVisualStyleBackColor = False
        '
        'rb_descontar_inventario
        '
        Me.rb_descontar_inventario.AutoSize = True
        Me.rb_descontar_inventario.Checked = True
        Me.rb_descontar_inventario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_descontar_inventario.Location = New System.Drawing.Point(9, 65)
        Me.rb_descontar_inventario.MaximumSize = New System.Drawing.Size(230, 50)
        Me.rb_descontar_inventario.MinimumSize = New System.Drawing.Size(0, 40)
        Me.rb_descontar_inventario.Name = "rb_descontar_inventario"
        Me.rb_descontar_inventario.Size = New System.Drawing.Size(230, 40)
        Me.rb_descontar_inventario.TabIndex = 0
        Me.rb_descontar_inventario.TabStop = True
        Me.rb_descontar_inventario.Text = "Descontar productos del almacen"
        Me.rb_descontar_inventario.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dg_devoluciones)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 25)
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
        Me.btn_buscar.Location = New System.Drawing.Point(709, 301)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(210, 45)
        Me.btn_buscar.TabIndex = 5
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'tb_folio
        '
        Me.tb_folio.Location = New System.Drawing.Point(762, 40)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.Size = New System.Drawing.Size(157, 26)
        Me.tb_folio.TabIndex = 1
        '
        'lbl_total_devolucion
        '
        Me.lbl_total_devolucion.AutoSize = True
        Me.lbl_total_devolucion.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total_devolucion.Location = New System.Drawing.Point(70, 22)
        Me.lbl_total_devolucion.Name = "lbl_total_devolucion"
        Me.lbl_total_devolucion.Size = New System.Drawing.Size(72, 30)
        Me.lbl_total_devolucion.TabIndex = 58
        Me.lbl_total_devolucion.Text = "$0.00"
        '
        'tb_total_despues_devolucion
        '
        Me.tb_total_despues_devolucion.AutoSize = True
        Me.tb_total_despues_devolucion.Font = New System.Drawing.Font("Century Gothic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total_despues_devolucion.Location = New System.Drawing.Point(470, 131)
        Me.tb_total_despues_devolucion.MinimumSize = New System.Drawing.Size(198, 0)
        Me.tb_total_despues_devolucion.Name = "tb_total_despues_devolucion"
        Me.tb_total_despues_devolucion.Size = New System.Drawing.Size(198, 41)
        Me.tb_total_despues_devolucion.TabIndex = 85
        Me.tb_total_despues_devolucion.Text = "$00.00"
        Me.tb_total_despues_devolucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(265, 130)
        Me.Label9.MaximumSize = New System.Drawing.Size(200, 50)
        Me.Label9.MinimumSize = New System.Drawing.Size(200, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 50)
        Me.Label9.TabIndex = 91
        Me.Label9.Text = "TOTAL DESPUES DE LA DEVOLUCIÓN:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frm_devoluciones_proveedor
        '
        Me.AcceptButton = Me.btn_buscar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(994, 632)
        Me.Controls.Add(Me.gb_devolucion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_devoluciones_proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones"
        Me.gb_devolucion.ResumeLayout(False)
        Me.gb_devolucion.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gb_devoluciones.ResumeLayout(False)
        Me.gb_devoluciones.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dg_devoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gb_devolucion As System.Windows.Forms.GroupBox
    Friend WithEvents tb_folio As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_devoluciones As System.Windows.Forms.DataGridView
    Friend WithEvents gb_devoluciones As System.Windows.Forms.GroupBox
    Friend WithEvents rb_descontar_inventario As System.Windows.Forms.RadioButton
    Friend WithEvents btn_devolver As System.Windows.Forms.Button
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
    Friend WithEvents tb_proveedor As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_total As System.Windows.Forms.Label
    Friend WithEvents tb_otros As System.Windows.Forms.Label
    Friend WithEvents tb_iva As System.Windows.Forms.Label
    Friend WithEvents tb_subtotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_total_devolucion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_total_despues_devolucion As System.Windows.Forms.Label
End Class
