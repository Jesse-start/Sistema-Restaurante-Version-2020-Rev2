<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_producto_cantidad
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_producto_cantidad))
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.tb_cantidad = New System.Windows.Forms.TextBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.btn_bascula = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_punto = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.lbl_codigo = New System.Windows.Forms.Label()
        Me.sp_bascula = New System.IO.Ports.SerialPort(Me.components)
        Me.trm_verificar_bascula = New System.Windows.Forms.Timer(Me.components)
        Me.trm_enviar_dato = New System.Windows.Forms.Timer(Me.components)
        Me.trm_cerrar_puerto = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.groupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox3
        '
        Me.groupBox3.BackColor = System.Drawing.Color.Transparent
        Me.groupBox3.Controls.Add(Me.tb_cantidad)
        Me.groupBox3.Controls.Add(Me.btn_ok)
        Me.groupBox3.Controls.Add(Me.btn_bascula)
        Me.groupBox3.Controls.Add(Me.btn_cancelar)
        Me.groupBox3.Controls.Add(Me.btn_punto)
        Me.groupBox3.Controls.Add(Me.btn0)
        Me.groupBox3.Controls.Add(Me.btn3)
        Me.groupBox3.Controls.Add(Me.btn2)
        Me.groupBox3.Controls.Add(Me.btn1)
        Me.groupBox3.Controls.Add(Me.btn_clear)
        Me.groupBox3.Controls.Add(Me.btn6)
        Me.groupBox3.Controls.Add(Me.label2)
        Me.groupBox3.Controls.Add(Me.btn5)
        Me.groupBox3.Controls.Add(Me.btn4)
        Me.groupBox3.Controls.Add(Me.btn_delete)
        Me.groupBox3.Controls.Add(Me.btn9)
        Me.groupBox3.Controls.Add(Me.btn8)
        Me.groupBox3.Controls.Add(Me.btn7)
        Me.groupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox3.ForeColor = System.Drawing.Color.Black
        Me.groupBox3.Location = New System.Drawing.Point(4, 5)
        Me.groupBox3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.groupBox3.Size = New System.Drawing.Size(273, 480)
        Me.groupBox3.TabIndex = 3
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Introduzca la cantidad."
        '
        'tb_cantidad
        '
        Me.tb_cantidad.BackColor = System.Drawing.Color.White
        Me.tb_cantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cantidad.Location = New System.Drawing.Point(16, 24)
        Me.tb_cantidad.Name = "tb_cantidad"
        Me.tb_cantidad.Size = New System.Drawing.Size(240, 38)
        Me.tb_cantidad.TabIndex = 4
        Me.tb_cantidad.Text = "1"
        Me.tb_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_ok
        '
        Me.btn_ok.BackColor = System.Drawing.Color.White
        Me.btn_ok.BackgroundImage = CType(resources.GetObject("btn_ok.BackgroundImage"), System.Drawing.Image)
        Me.btn_ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_ok.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Location = New System.Drawing.Point(206, 201)
        Me.btn_ok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(60, 124)
        Me.btn_ok.TabIndex = 31
        Me.btn_ok.UseVisualStyleBackColor = False
        '
        'btn_bascula
        '
        Me.btn_bascula.BackColor = System.Drawing.Color.White
        Me.btn_bascula.Enabled = False
        Me.btn_bascula.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bascula.Image = CType(resources.GetObject("btn_bascula.Image"), System.Drawing.Image)
        Me.btn_bascula.Location = New System.Drawing.Point(9, 327)
        Me.btn_bascula.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_bascula.Name = "btn_bascula"
        Me.btn_bascula.Size = New System.Drawing.Size(256, 74)
        Me.btn_bascula.TabIndex = 38
        Me.btn_bascula.Text = "Obtener de bascula"
        Me.btn_bascula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_bascula.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.White
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(8, 405)
        Me.btn_cancelar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(256, 69)
        Me.btn_cancelar.TabIndex = 30
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(140, 265)
        Me.btn_punto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(60, 60)
        Me.btn_punto.TabIndex = 30
        Me.btn_punto.Text = "."
        Me.btn_punto.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(8, 265)
        Me.btn0.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(126, 60)
        Me.btn0.TabIndex = 29
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(140, 201)
        Me.btn3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(60, 60)
        Me.btn3.TabIndex = 28
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(74, 201)
        Me.btn2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(60, 60)
        Me.btn2.TabIndex = 27
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(8, 201)
        Me.btn1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(60, 60)
        Me.btn1.TabIndex = 26
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.White
        Me.btn_clear.BackgroundImage = CType(resources.GetObject("btn_clear.BackgroundImage"), System.Drawing.Image)
        Me.btn_clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_clear.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.Location = New System.Drawing.Point(206, 137)
        Me.btn_clear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(60, 60)
        Me.btn_clear.TabIndex = 25
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(140, 137)
        Me.btn6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(60, 60)
        Me.btn6.TabIndex = 24
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Red
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(6, 24)
        Me.label2.Margin = New System.Windows.Forms.Padding(2)
        Me.label2.MaximumSize = New System.Drawing.Size(260, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(0, 18)
        Me.label2.TabIndex = 36
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(74, 137)
        Me.btn5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(60, 60)
        Me.btn5.TabIndex = 23
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(8, 137)
        Me.btn4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(60, 60)
        Me.btn4.TabIndex = 22
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.White
        Me.btn_delete.BackgroundImage = CType(resources.GetObject("btn_delete.BackgroundImage"), System.Drawing.Image)
        Me.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_delete.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete.Location = New System.Drawing.Point(206, 73)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(60, 60)
        Me.btn_delete.TabIndex = 21
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(140, 73)
        Me.btn9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(60, 60)
        Me.btn9.TabIndex = 20
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(74, 73)
        Me.btn8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(60, 60)
        Me.btn8.TabIndex = 19
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.Font = New System.Drawing.Font("Century Gothic", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(8, 73)
        Me.btn7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(60, 60)
        Me.btn7.TabIndex = 18
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'lbl_codigo
        '
        Me.lbl_codigo.BackColor = System.Drawing.SystemColors.Menu
        Me.lbl_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_codigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbl_codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_codigo.Location = New System.Drawing.Point(7, 17)
        Me.lbl_codigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_codigo.Name = "lbl_codigo"
        Me.lbl_codigo.Size = New System.Drawing.Size(258, 38)
        Me.lbl_codigo.TabIndex = 0
        '
        'sp_bascula
        '
        Me.sp_bascula.ReadTimeout = 3000
        Me.sp_bascula.ReceivedBytesThreshold = 10
        Me.sp_bascula.WriteTimeout = 3000
        '
        'trm_verificar_bascula
        '
        Me.trm_verificar_bascula.Interval = 1000
        '
        'trm_enviar_dato
        '
        Me.trm_enviar_dato.Interval = 1
        '
        'trm_cerrar_puerto
        '
        Me.trm_cerrar_puerto.Interval = 1
        '
        'SerialPort1
        '
        Me.SerialPort1.StopBits = System.IO.Ports.StopBits.Two
        '
        'frm_producto_cantidad
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(283, 489)
        Me.Controls.Add(Me.groupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_producto_cantidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cantidad"
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents btn_ok As System.Windows.Forms.Button
    Private WithEvents btn_bascula As System.Windows.Forms.Button
    Private WithEvents btn_punto As System.Windows.Forms.Button
    Private WithEvents btn0 As System.Windows.Forms.Button
    Private WithEvents btn3 As System.Windows.Forms.Button
    Private WithEvents btn2 As System.Windows.Forms.Button
    Private WithEvents btn1 As System.Windows.Forms.Button
    Private WithEvents btn_clear As System.Windows.Forms.Button
    Private WithEvents btn6 As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btn5 As System.Windows.Forms.Button
    Private WithEvents btn4 As System.Windows.Forms.Button
    Private WithEvents btn_delete As System.Windows.Forms.Button
    Private WithEvents btn9 As System.Windows.Forms.Button
    Private WithEvents btn8 As System.Windows.Forms.Button
    Private WithEvents btn7 As System.Windows.Forms.Button
    Private WithEvents lbl_codigo As System.Windows.Forms.Label
    Friend WithEvents tb_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents sp_bascula As System.IO.Ports.SerialPort
    Friend WithEvents trm_verificar_bascula As System.Windows.Forms.Timer
    Friend WithEvents trm_enviar_dato As System.Windows.Forms.Timer
    Friend WithEvents trm_cerrar_puerto As System.Windows.Forms.Timer
    Private WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
End Class
