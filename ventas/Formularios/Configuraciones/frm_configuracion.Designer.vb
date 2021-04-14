<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_configuracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_configuracion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_servidor = New System.Windows.Forms.TextBox()
        Me.tb_usuario = New System.Windows.Forms.TextBox()
        Me.tb_password = New System.Windows.Forms.TextBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.tooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button33 = New System.Windows.Forms.Button()
        Me.btn_barra = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.Button31 = New System.Windows.Forms.Button()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button30 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button29 = New System.Windows.Forms.Button()
        Me.Button40 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button39 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button38 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button37 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button36 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button35 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button34 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button32 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Password:"
        '
        'tb_servidor
        '
        Me.tb_servidor.Location = New System.Drawing.Point(95, 45)
        Me.tb_servidor.Name = "tb_servidor"
        Me.tb_servidor.Size = New System.Drawing.Size(181, 22)
        Me.tb_servidor.TabIndex = 20
        Me.tooltip.SetToolTip(Me.tb_servidor, "Nombre o IP del Servidor")
        '
        'tb_usuario
        '
        Me.tb_usuario.Location = New System.Drawing.Point(95, 71)
        Me.tb_usuario.Name = "tb_usuario"
        Me.tb_usuario.Size = New System.Drawing.Size(181, 22)
        Me.tb_usuario.TabIndex = 25
        Me.tooltip.SetToolTip(Me.tb_usuario, "Usuario de la Base de Datos")
        '
        'tb_password
        '
        Me.tb_password.Location = New System.Drawing.Point(95, 97)
        Me.tb_password.Name = "tb_password"
        Me.tb_password.Size = New System.Drawing.Size(181, 22)
        Me.tb_password.TabIndex = 30
        Me.tb_password.UseSystemPasswordChar = True
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.White
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(317, 44)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(139, 72)
        Me.btn_guardar.TabIndex = 35
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_cancelar
        '
        Me.btn_cancelar.BackColor = System.Drawing.Color.White
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(464, 44)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(153, 72)
        Me.btn_cancelar.TabIndex = 40
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tb_password)
        Me.GroupBox1.Controls.Add(Me.tb_servidor)
        Me.GroupBox1.Controls.Add(Me.tb_nombre)
        Me.GroupBox1.Controls.Add(Me.tb_usuario)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 133)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles de la Base de Datos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Nombre:"
        '
        'tb_nombre
        '
        Me.tb_nombre.Location = New System.Drawing.Point(95, 19)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(181, 22)
        Me.tb_nombre.TabIndex = 15
        Me.tooltip.SetToolTip(Me.tb_nombre, "Nombre de la Base de Datos")
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(43, 302)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 50)
        Me.Button3.TabIndex = 105
        Me.Button3.Text = "z"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button33
        '
        Me.Button33.BackColor = System.Drawing.Color.White
        Me.Button33.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button33.Location = New System.Drawing.Point(92, 302)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(50, 50)
        Me.Button33.TabIndex = 109
        Me.Button33.Text = "x"
        Me.Button33.UseVisualStyleBackColor = False
        '
        'btn_barra
        '
        Me.btn_barra.BackColor = System.Drawing.Color.White
        Me.btn_barra.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_barra.Location = New System.Drawing.Point(111, 352)
        Me.btn_barra.Name = "btn_barra"
        Me.btn_barra.Size = New System.Drawing.Size(354, 50)
        Me.btn_barra.TabIndex = 108
        Me.btn_barra.Text = " "
        Me.btn_barra.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(22, 251)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(50, 50)
        Me.Button2.TabIndex = 102
        Me.Button2.Text = "a"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.White
        Me.Button22.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.Location = New System.Drawing.Point(514, 251)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(122, 50)
        Me.Button22.TabIndex = 101
        Me.Button22.Text = "Limpiar"
        Me.Button22.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.White
        Me.btn_clear.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.Location = New System.Drawing.Point(505, 201)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(128, 50)
        Me.btn_clear.TabIndex = 104
        Me.btn_clear.Text = "<-------------"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'Button31
        '
        Me.Button31.BackColor = System.Drawing.Color.White
        Me.Button31.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button31.Location = New System.Drawing.Point(436, 302)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(50, 50)
        Me.Button31.TabIndex = 103
        Me.Button31.Text = "."
        Me.Button31.UseVisualStyleBackColor = False
        '
        'Button42
        '
        Me.Button42.BackColor = System.Drawing.Color.White
        Me.Button42.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button42.Location = New System.Drawing.Point(455, 150)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(50, 50)
        Me.Button42.TabIndex = 111
        Me.Button42.Text = "0"
        Me.Button42.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(455, 201)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(50, 50)
        Me.Button12.TabIndex = 110
        Me.Button12.Text = "p"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.White
        Me.Button21.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button21.Location = New System.Drawing.Point(415, 251)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(50, 50)
        Me.Button21.TabIndex = 118
        Me.Button21.Text = "l"
        Me.Button21.UseVisualStyleBackColor = False
        '
        'Button30
        '
        Me.Button30.BackColor = System.Drawing.Color.White
        Me.Button30.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button30.Location = New System.Drawing.Point(239, 302)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(50, 50)
        Me.Button30.TabIndex = 117
        Me.Button30.Text = "b"
        Me.Button30.UseVisualStyleBackColor = False
        '
        'Button41
        '
        Me.Button41.BackColor = System.Drawing.Color.White
        Me.Button41.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button41.Location = New System.Drawing.Point(357, 150)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(50, 50)
        Me.Button41.TabIndex = 121
        Me.Button41.Text = "8"
        Me.Button41.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(357, 201)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(50, 50)
        Me.Button10.TabIndex = 120
        Me.Button10.Text = "i"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.White
        Me.Button20.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button20.Location = New System.Drawing.Point(218, 251)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(50, 50)
        Me.Button20.TabIndex = 119
        Me.Button20.Text = "g"
        Me.Button20.UseVisualStyleBackColor = False
        '
        'Button29
        '
        Me.Button29.BackColor = System.Drawing.Color.White
        Me.Button29.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button29.Location = New System.Drawing.Point(485, 302)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(50, 50)
        Me.Button29.TabIndex = 114
        Me.Button29.Text = "-"
        Me.Button29.UseVisualStyleBackColor = False
        '
        'Button40
        '
        Me.Button40.BackColor = System.Drawing.Color.White
        Me.Button40.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button40.Location = New System.Drawing.Point(160, 150)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(50, 50)
        Me.Button40.TabIndex = 113
        Me.Button40.Text = "4"
        Me.Button40.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(160, 201)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(50, 50)
        Me.Button6.TabIndex = 112
        Me.Button6.Text = "r"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.White
        Me.Button19.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button19.Location = New System.Drawing.Point(464, 251)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(50, 50)
        Me.Button19.TabIndex = 116
        Me.Button19.Text = "ñ"
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Button28
        '
        Me.Button28.BackColor = System.Drawing.Color.White
        Me.Button28.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button28.Location = New System.Drawing.Point(387, 302)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(50, 50)
        Me.Button28.TabIndex = 115
        Me.Button28.Text = ","
        Me.Button28.UseVisualStyleBackColor = False
        '
        'Button39
        '
        Me.Button39.BackColor = System.Drawing.Color.White
        Me.Button39.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button39.Location = New System.Drawing.Point(406, 150)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(50, 50)
        Me.Button39.TabIndex = 107
        Me.Button39.Text = "9"
        Me.Button39.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.White
        Me.Button11.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(406, 201)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(50, 50)
        Me.Button11.TabIndex = 106
        Me.Button11.Text = "o"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.Color.White
        Me.Button18.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.Location = New System.Drawing.Point(366, 251)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(50, 50)
        Me.Button18.TabIndex = 83
        Me.Button18.Text = "k"
        Me.Button18.UseVisualStyleBackColor = False
        '
        'Button27
        '
        Me.Button27.BackColor = System.Drawing.Color.White
        Me.Button27.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button27.Location = New System.Drawing.Point(338, 302)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(50, 50)
        Me.Button27.TabIndex = 88
        Me.Button27.Text = "m"
        Me.Button27.UseVisualStyleBackColor = False
        '
        'Button38
        '
        Me.Button38.BackColor = System.Drawing.Color.White
        Me.Button38.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button38.Location = New System.Drawing.Point(308, 150)
        Me.Button38.Name = "Button38"
        Me.Button38.Size = New System.Drawing.Size(50, 50)
        Me.Button38.TabIndex = 87
        Me.Button38.Text = "7"
        Me.Button38.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(308, 201)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(50, 50)
        Me.Button9.TabIndex = 86
        Me.Button9.Text = "u"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.White
        Me.Button17.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.Location = New System.Drawing.Point(317, 251)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(50, 50)
        Me.Button17.TabIndex = 79
        Me.Button17.Text = "j"
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button26
        '
        Me.Button26.BackColor = System.Drawing.Color.White
        Me.Button26.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.Location = New System.Drawing.Point(190, 302)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(50, 50)
        Me.Button26.TabIndex = 78
        Me.Button26.Text = "v"
        Me.Button26.UseVisualStyleBackColor = False
        '
        'Button37
        '
        Me.Button37.BackColor = System.Drawing.Color.White
        Me.Button37.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button37.Location = New System.Drawing.Point(259, 150)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(50, 50)
        Me.Button37.TabIndex = 82
        Me.Button37.Text = "6"
        Me.Button37.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.White
        Me.Button8.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(259, 201)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(50, 50)
        Me.Button8.TabIndex = 81
        Me.Button8.Text = "y"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.White
        Me.Button16.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.Location = New System.Drawing.Point(169, 251)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(50, 50)
        Me.Button16.TabIndex = 80
        Me.Button16.Text = "f"
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.White
        Me.Button25.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.Location = New System.Drawing.Point(289, 302)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(50, 50)
        Me.Button25.TabIndex = 89
        Me.Button25.Text = "n"
        Me.Button25.UseVisualStyleBackColor = False
        '
        'Button36
        '
        Me.Button36.BackColor = System.Drawing.Color.White
        Me.Button36.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button36.Location = New System.Drawing.Point(111, 150)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(50, 50)
        Me.Button36.TabIndex = 96
        Me.Button36.Text = "3"
        Me.Button36.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(111, 201)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(50, 50)
        Me.Button5.TabIndex = 97
        Me.Button5.Text = "e"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.Location = New System.Drawing.Point(268, 251)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(50, 50)
        Me.Button15.TabIndex = 95
        Me.Button15.Text = "h"
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button35
        '
        Me.Button35.BackColor = System.Drawing.Color.White
        Me.Button35.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button35.Location = New System.Drawing.Point(210, 150)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(50, 50)
        Me.Button35.TabIndex = 99
        Me.Button35.Text = "5"
        Me.Button35.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(210, 201)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(50, 50)
        Me.Button7.TabIndex = 98
        Me.Button7.Text = "t"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.Color.White
        Me.Button23.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.Location = New System.Drawing.Point(141, 302)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(50, 50)
        Me.Button23.TabIndex = 91
        Me.Button23.Text = "c"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(120, 251)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(50, 50)
        Me.Button14.TabIndex = 90
        Me.Button14.Text = "d"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(71, 251)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(50, 50)
        Me.Button13.TabIndex = 94
        Me.Button13.Text = "s"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button34
        '
        Me.Button34.BackColor = System.Drawing.Color.White
        Me.Button34.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button34.Location = New System.Drawing.Point(62, 150)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(50, 50)
        Me.Button34.TabIndex = 92
        Me.Button34.Text = "2"
        Me.Button34.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(62, 201)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 50)
        Me.Button4.TabIndex = 93
        Me.Button4.Text = "w"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button32
        '
        Me.Button32.BackColor = System.Drawing.Color.White
        Me.Button32.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button32.Location = New System.Drawing.Point(13, 150)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(50, 50)
        Me.Button32.TabIndex = 85
        Me.Button32.Text = "1"
        Me.Button32.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(13, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 50)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "q"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frm_configuracion
        '
        Me.AcceptButton = Me.btn_guardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btn_cancelar
        Me.ClientSize = New System.Drawing.Size(646, 408)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button33)
        Me.Controls.Add(Me.btn_barra)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.btn_clear)
        Me.Controls.Add(Me.Button31)
        Me.Controls.Add(Me.Button42)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button21)
        Me.Controls.Add(Me.Button30)
        Me.Controls.Add(Me.Button41)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.Button29)
        Me.Controls.Add(Me.Button40)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button28)
        Me.Controls.Add(Me.Button39)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Button27)
        Me.Controls.Add(Me.Button38)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button26)
        Me.Controls.Add(Me.Button37)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button25)
        Me.Controls.Add(Me.Button36)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button35)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button23)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button34)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button32)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_guardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_configuracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_servidor As System.Windows.Forms.TextBox
    Friend WithEvents tb_usuario As System.Windows.Forms.TextBox
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tooltip As System.Windows.Forms.ToolTip
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button33 As System.Windows.Forms.Button
    Friend WithEvents btn_barra As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents btn_clear As System.Windows.Forms.Button
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents Button42 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button41 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button40 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button39 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents Button38 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button37 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button36 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button35 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button34 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button32 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
