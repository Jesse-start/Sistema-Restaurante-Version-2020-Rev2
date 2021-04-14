<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_corte_x
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_corte_x))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_tipo_reporte = New System.Windows.Forms.ComboBox()
        Me.cb_turno = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_enviar_email = New System.Windows.Forms.Button()
        Me.btn_excel = New System.Windows.Forms.Button()
        Me.btn_impresora = New System.Windows.Forms.Button()
        Me.btn_pantalla = New System.Windows.Forms.Button()
        Me.sfd_excel = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha.Location = New System.Drawing.Point(81, 12)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(124, 27)
        Me.dtp_fecha.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tipo:"
        '
        'cb_tipo_reporte
        '
        Me.cb_tipo_reporte.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipo_reporte.FormattingEnabled = True
        Me.cb_tipo_reporte.Location = New System.Drawing.Point(81, 89)
        Me.cb_tipo_reporte.Name = "cb_tipo_reporte"
        Me.cb_tipo_reporte.Size = New System.Drawing.Size(312, 29)
        Me.cb_tipo_reporte.TabIndex = 3
        '
        'cb_turno
        '
        Me.cb_turno.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_turno.FormattingEnabled = True
        Me.cb_turno.Location = New System.Drawing.Point(81, 49)
        Me.cb_turno.Name = "cb_turno"
        Me.cb_turno.Size = New System.Drawing.Size(312, 29)
        Me.cb_turno.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Turno:"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(162, 210)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(108, 91)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Salir"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btn_enviar_email
        '
        Me.btn_enviar_email.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_enviar_email.Image = CType(resources.GetObject("btn_enviar_email.Image"), System.Drawing.Image)
        Me.btn_enviar_email.Location = New System.Drawing.Point(16, 210)
        Me.btn_enviar_email.Name = "btn_enviar_email"
        Me.btn_enviar_email.Size = New System.Drawing.Size(104, 91)
        Me.btn_enviar_email.TabIndex = 2
        Me.btn_enviar_email.Text = "Enviar e-mail"
        Me.btn_enviar_email.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_enviar_email.UseVisualStyleBackColor = True
        '
        'btn_excel
        '
        Me.btn_excel.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_excel.Image = CType(resources.GetObject("btn_excel.Image"), System.Drawing.Image)
        Me.btn_excel.Location = New System.Drawing.Point(295, 124)
        Me.btn_excel.Name = "btn_excel"
        Me.btn_excel.Size = New System.Drawing.Size(98, 80)
        Me.btn_excel.TabIndex = 2
        Me.btn_excel.Text = "En excel"
        Me.btn_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_excel.UseVisualStyleBackColor = True
        '
        'btn_impresora
        '
        Me.btn_impresora.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_impresora.Image = CType(resources.GetObject("btn_impresora.Image"), System.Drawing.Image)
        Me.btn_impresora.Location = New System.Drawing.Point(162, 124)
        Me.btn_impresora.Name = "btn_impresora"
        Me.btn_impresora.Size = New System.Drawing.Size(108, 80)
        Me.btn_impresora.TabIndex = 2
        Me.btn_impresora.Text = "En impresora"
        Me.btn_impresora.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_impresora.UseVisualStyleBackColor = True
        '
        'btn_pantalla
        '
        Me.btn_pantalla.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pantalla.Image = CType(resources.GetObject("btn_pantalla.Image"), System.Drawing.Image)
        Me.btn_pantalla.Location = New System.Drawing.Point(16, 124)
        Me.btn_pantalla.Name = "btn_pantalla"
        Me.btn_pantalla.Size = New System.Drawing.Size(104, 80)
        Me.btn_pantalla.TabIndex = 2
        Me.btn_pantalla.Text = "En pantalla"
        Me.btn_pantalla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_pantalla.UseVisualStyleBackColor = True
        '
        'frm_corte_x
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 339)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cb_turno)
        Me.Controls.Add(Me.cb_tipo_reporte)
        Me.Controls.Add(Me.btn_enviar_email)
        Me.Controls.Add(Me.btn_excel)
        Me.Controls.Add(Me.btn_impresora)
        Me.Controls.Add(Me.btn_pantalla)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_corte_x"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de turno"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_pantalla As System.Windows.Forms.Button
    Friend WithEvents btn_impresora As System.Windows.Forms.Button
    Friend WithEvents btn_excel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_tipo_reporte As System.Windows.Forms.ComboBox
    Friend WithEvents cb_turno As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_enviar_email As System.Windows.Forms.Button
    Friend WithEvents sfd_excel As SaveFileDialog
End Class
