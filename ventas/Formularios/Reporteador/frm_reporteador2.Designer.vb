<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporteador2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reporteador2))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_tipo_reporte = New System.Windows.Forms.ComboBox()
        Me.lbl_inicio = New System.Windows.Forms.Label()
        Me.dtp_termino = New System.Windows.Forms.DateTimePicker()
        Me.lbl_termino = New System.Windows.Forms.Label()
        Me.cb_colaborador = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb_descendente = New System.Windows.Forms.RadioButton()
        Me.rb_ascendente = New System.Windows.Forms.RadioButton()
        Me.dtp_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_genera_reporte_excel = New System.Windows.Forms.Button()
        Me.cb_ordenado = New System.Windows.Forms.ComboBox()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sfd_excel = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tipo de reporte:"
        '
        'cb_tipo_reporte
        '
        Me.cb_tipo_reporte.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipo_reporte.FormattingEnabled = True
        Me.cb_tipo_reporte.Location = New System.Drawing.Point(162, 22)
        Me.cb_tipo_reporte.Name = "cb_tipo_reporte"
        Me.cb_tipo_reporte.Size = New System.Drawing.Size(361, 25)
        Me.cb_tipo_reporte.TabIndex = 2
        '
        'lbl_inicio
        '
        Me.lbl_inicio.AutoSize = True
        Me.lbl_inicio.Enabled = False
        Me.lbl_inicio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_inicio.Location = New System.Drawing.Point(110, 62)
        Me.lbl_inicio.Name = "lbl_inicio"
        Me.lbl_inicio.Size = New System.Drawing.Size(46, 17)
        Me.lbl_inicio.TabIndex = 7
        Me.lbl_inicio.Text = "Inicio:"
        '
        'dtp_termino
        '
        Me.dtp_termino.CalendarFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_termino.Enabled = False
        Me.dtp_termino.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_termino.Location = New System.Drawing.Point(386, 57)
        Me.dtp_termino.Name = "dtp_termino"
        Me.dtp_termino.Size = New System.Drawing.Size(137, 23)
        Me.dtp_termino.TabIndex = 11
        '
        'lbl_termino
        '
        Me.lbl_termino.AutoSize = True
        Me.lbl_termino.Enabled = False
        Me.lbl_termino.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_termino.Location = New System.Drawing.Point(307, 57)
        Me.lbl_termino.Name = "lbl_termino"
        Me.lbl_termino.Size = New System.Drawing.Size(62, 17)
        Me.lbl_termino.TabIndex = 10
        Me.lbl_termino.Text = "Termino:"
        '
        'cb_colaborador
        '
        Me.cb_colaborador.Enabled = False
        Me.cb_colaborador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_colaborador.FormattingEnabled = True
        Me.cb_colaborador.Location = New System.Drawing.Point(162, 85)
        Me.cb_colaborador.Name = "cb_colaborador"
        Me.cb_colaborador.Size = New System.Drawing.Size(361, 25)
        Me.cb_colaborador.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(59, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Colaborador:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb_descendente)
        Me.GroupBox1.Controls.Add(Me.rb_ascendente)
        Me.GroupBox1.Controls.Add(Me.dtp_inicio)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btn_genera_reporte_excel)
        Me.GroupBox1.Controls.Add(Me.cb_tipo_reporte)
        Me.GroupBox1.Controls.Add(Me.cb_ordenado)
        Me.GroupBox1.Controls.Add(Me.cb_cliente)
        Me.GroupBox1.Controls.Add(Me.cb_colaborador)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbl_inicio)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl_termino)
        Me.GroupBox1.Controls.Add(Me.dtp_termino)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(538, 288)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuracion de reporte"
        '
        'rb_descendente
        '
        Me.rb_descendente.AutoSize = True
        Me.rb_descendente.Enabled = False
        Me.rb_descendente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_descendente.Location = New System.Drawing.Point(412, 147)
        Me.rb_descendente.Name = "rb_descendente"
        Me.rb_descendente.Size = New System.Drawing.Size(111, 21)
        Me.rb_descendente.TabIndex = 25
        Me.rb_descendente.Text = "Descendente"
        Me.rb_descendente.UseVisualStyleBackColor = True
        '
        'rb_ascendente
        '
        Me.rb_ascendente.AutoSize = True
        Me.rb_ascendente.Checked = True
        Me.rb_ascendente.Enabled = False
        Me.rb_ascendente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_ascendente.Location = New System.Drawing.Point(307, 148)
        Me.rb_ascendente.Name = "rb_ascendente"
        Me.rb_ascendente.Size = New System.Drawing.Size(102, 21)
        Me.rb_ascendente.TabIndex = 25
        Me.rb_ascendente.TabStop = True
        Me.rb_ascendente.Text = "Ascendente"
        Me.rb_ascendente.UseVisualStyleBackColor = True
        '
        'dtp_inicio
        '
        Me.dtp_inicio.CalendarFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicio.Enabled = False
        Me.dtp_inicio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_inicio.Location = New System.Drawing.Point(162, 55)
        Me.dtp_inicio.Name = "dtp_inicio"
        Me.dtp_inicio.Size = New System.Drawing.Size(139, 23)
        Me.dtp_inicio.TabIndex = 21
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(353, 194)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(103, 86)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Graficas"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(262, 194)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(85, 86)
        Me.btn_salir.TabIndex = 23
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_genera_reporte_excel
        '
        Me.btn_genera_reporte_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_genera_reporte_excel.Image = CType(resources.GetObject("btn_genera_reporte_excel.Image"), System.Drawing.Image)
        Me.btn_genera_reporte_excel.Location = New System.Drawing.Point(169, 194)
        Me.btn_genera_reporte_excel.Name = "btn_genera_reporte_excel"
        Me.btn_genera_reporte_excel.Size = New System.Drawing.Size(87, 86)
        Me.btn_genera_reporte_excel.TabIndex = 22
        Me.btn_genera_reporte_excel.Text = "Excel"
        Me.btn_genera_reporte_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_genera_reporte_excel.UseVisualStyleBackColor = True
        '
        'cb_ordenado
        '
        Me.cb_ordenado.Enabled = False
        Me.cb_ordenado.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ordenado.FormattingEnabled = True
        Me.cb_ordenado.Location = New System.Drawing.Point(162, 147)
        Me.cb_ordenado.Name = "cb_ordenado"
        Me.cb_ordenado.Size = New System.Drawing.Size(139, 25)
        Me.cb_ordenado.TabIndex = 16
        '
        'cb_cliente
        '
        Me.cb_cliente.Enabled = False
        Me.cb_cliente.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(162, 116)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(361, 25)
        Me.cb_cliente.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Ordenar por:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(92, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Cliente:"
        '
        'frm_reporteador2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 303)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reporteador2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporteador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_tipo_reporte As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_inicio As System.Windows.Forms.Label
    Friend WithEvents dtp_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_termino As System.Windows.Forms.Label
    Friend WithEvents cb_colaborador As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_genera_reporte_excel As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dtp_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_ordenado As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rb_ascendente As System.Windows.Forms.RadioButton
    Friend WithEvents rb_descendente As System.Windows.Forms.RadioButton
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sfd_excel As SaveFileDialog
End Class
