<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_agentes_pedidos
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
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.gb_agentes = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg_agentes_pedidos = New System.Windows.Forms.DataGrid()
        Me.gb_detalle = New System.Windows.Forms.GroupBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.cb_empleado = New System.Windows.Forms.ComboBox()
        Me.rb_puesto = New System.Windows.Forms.RadioButton()
        Me.cb_puesto = New System.Windows.Forms.ComboBox()
        Me.rb_todos = New System.Windows.Forms.RadioButton()
        Me.cb_moviles = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gb_agentes.SuspendLayout()
        CType(Me.dg_agentes_pedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_detalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(513, 353)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(88, 50)
        Me.btn_guardar.TabIndex = 40
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'gb_agentes
        '
        Me.gb_agentes.Controls.Add(Me.Button4)
        Me.gb_agentes.Controls.Add(Me.Button3)
        Me.gb_agentes.Controls.Add(Me.Label1)
        Me.gb_agentes.Controls.Add(Me.dg_agentes_pedidos)
        Me.gb_agentes.Location = New System.Drawing.Point(12, 12)
        Me.gb_agentes.Name = "gb_agentes"
        Me.gb_agentes.Size = New System.Drawing.Size(608, 317)
        Me.gb_agentes.TabIndex = 39
        Me.gb_agentes.TabStop = False
        Me.gb_agentes.Text = "Agentes"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(528, 21)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 23)
        Me.Button4.TabIndex = 39
        Me.Button4.Text = "Quitar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(447, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(61, 23)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Agregar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Agentes de pedidos."
        '
        'dg_agentes_pedidos
        '
        Me.dg_agentes_pedidos.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.dg_agentes_pedidos.CaptionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dg_agentes_pedidos.CaptionForeColor = System.Drawing.Color.Black
        Me.dg_agentes_pedidos.DataMember = ""
        Me.dg_agentes_pedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_agentes_pedidos.Location = New System.Drawing.Point(8, 50)
        Me.dg_agentes_pedidos.Name = "dg_agentes_pedidos"
        Me.dg_agentes_pedidos.Size = New System.Drawing.Size(581, 259)
        Me.dg_agentes_pedidos.TabIndex = 36
        '
        'gb_detalle
        '
        Me.gb_detalle.Controls.Add(Me.btn_cancelar)
        Me.gb_detalle.Controls.Add(Me.btn_aceptar)
        Me.gb_detalle.Controls.Add(Me.cb_empleado)
        Me.gb_detalle.Controls.Add(Me.rb_puesto)
        Me.gb_detalle.Controls.Add(Me.cb_puesto)
        Me.gb_detalle.Controls.Add(Me.rb_todos)
        Me.gb_detalle.Controls.Add(Me.cb_moviles)
        Me.gb_detalle.Controls.Add(Me.Label10)
        Me.gb_detalle.Controls.Add(Me.Label7)
        Me.gb_detalle.Enabled = False
        Me.gb_detalle.Location = New System.Drawing.Point(12, 335)
        Me.gb_detalle.Name = "gb_detalle"
        Me.gb_detalle.Size = New System.Drawing.Size(426, 137)
        Me.gb_detalle.TabIndex = 38
        Me.gb_detalle.TabStop = False
        Me.gb_detalle.Text = "GroupBox1"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(213, 108)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 46
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(113, 108)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 45
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cb_empleado
        '
        Me.cb_empleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_empleado.FormattingEnabled = True
        Me.cb_empleado.Location = New System.Drawing.Point(96, 47)
        Me.cb_empleado.Name = "cb_empleado"
        Me.cb_empleado.Size = New System.Drawing.Size(254, 21)
        Me.cb_empleado.TabIndex = 44
        '
        'rb_puesto
        '
        Me.rb_puesto.AutoSize = True
        Me.rb_puesto.Location = New System.Drawing.Point(162, 21)
        Me.rb_puesto.Name = "rb_puesto"
        Me.rb_puesto.Size = New System.Drawing.Size(61, 17)
        Me.rb_puesto.TabIndex = 43
        Me.rb_puesto.Text = "Puesto:"
        Me.rb_puesto.UseVisualStyleBackColor = True
        '
        'cb_puesto
        '
        Me.cb_puesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_puesto.Enabled = False
        Me.cb_puesto.FormattingEnabled = True
        Me.cb_puesto.Location = New System.Drawing.Point(229, 18)
        Me.cb_puesto.Name = "cb_puesto"
        Me.cb_puesto.Size = New System.Drawing.Size(121, 21)
        Me.cb_puesto.TabIndex = 41
        '
        'rb_todos
        '
        Me.rb_todos.AutoSize = True
        Me.rb_todos.Checked = True
        Me.rb_todos.Location = New System.Drawing.Point(95, 21)
        Me.rb_todos.Name = "rb_todos"
        Me.rb_todos.Size = New System.Drawing.Size(55, 17)
        Me.rb_todos.TabIndex = 40
        Me.rb_todos.TabStop = True
        Me.rb_todos.Text = "Todos"
        Me.rb_todos.UseVisualStyleBackColor = True
        '
        'cb_moviles
        '
        Me.cb_moviles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_moviles.FormattingEnabled = True
        Me.cb_moviles.Location = New System.Drawing.Point(96, 74)
        Me.cb_moviles.Name = "cb_moviles"
        Me.cb_moviles.Size = New System.Drawing.Size(255, 21)
        Me.cb_moviles.TabIndex = 39
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Colaborador:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Vehiculo:"
        '
        'frm_agentes_pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 488)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.gb_agentes)
        Me.Controls.Add(Me.gb_detalle)
        Me.Name = "frm_agentes_pedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agentes de entrega"
        Me.gb_agentes.ResumeLayout(False)
        Me.gb_agentes.PerformLayout()
        CType(Me.dg_agentes_pedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_detalle.ResumeLayout(False)
        Me.gb_detalle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents gb_agentes As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dg_agentes_pedidos As System.Windows.Forms.DataGrid
    Friend WithEvents gb_detalle As System.Windows.Forms.GroupBox
    Friend WithEvents cb_moviles As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rb_puesto As System.Windows.Forms.RadioButton
    Friend WithEvents cb_puesto As System.Windows.Forms.ComboBox
    Friend WithEvents rb_todos As System.Windows.Forms.RadioButton
    Friend WithEvents cb_empleado As System.Windows.Forms.ComboBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
End Class
