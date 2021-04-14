<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reenviar_email
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
        Me.btn_reenviar_email = New System.Windows.Forms.Button()
        Me.gb_cortes = New System.Windows.Forms.GroupBox()
        Me.cb_documentos = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.gb_cortes.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_reenviar_email
        '
        Me.btn_reenviar_email.Location = New System.Drawing.Point(84, 119)
        Me.btn_reenviar_email.Name = "btn_reenviar_email"
        Me.btn_reenviar_email.Size = New System.Drawing.Size(122, 52)
        Me.btn_reenviar_email.TabIndex = 2
        Me.btn_reenviar_email.Text = "Reenviar correo"
        Me.btn_reenviar_email.UseVisualStyleBackColor = True
        '
        'gb_cortes
        '
        Me.gb_cortes.Controls.Add(Me.cb_documentos)
        Me.gb_cortes.Controls.Add(Me.dtp_fecha)
        Me.gb_cortes.Location = New System.Drawing.Point(12, 12)
        Me.gb_cortes.Name = "gb_cortes"
        Me.gb_cortes.Size = New System.Drawing.Size(282, 101)
        Me.gb_cortes.TabIndex = 3
        Me.gb_cortes.TabStop = False
        Me.gb_cortes.Text = "Cortes de caja"
        '
        'cb_documentos
        '
        Me.cb_documentos.FormattingEnabled = True
        Me.cb_documentos.Location = New System.Drawing.Point(18, 54)
        Me.cb_documentos.Name = "cb_documentos"
        Me.cb_documentos.Size = New System.Drawing.Size(243, 21)
        Me.cb_documentos.TabIndex = 3
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Location = New System.Drawing.Point(18, 28)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(243, 20)
        Me.dtp_fecha.TabIndex = 2
        '
        'frm_reenviar_email
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 192)
        Me.Controls.Add(Me.gb_cortes)
        Me.Controls.Add(Me.btn_reenviar_email)
        Me.Name = "frm_reenviar_email"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reenviar correo"
        Me.gb_cortes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_reenviar_email As System.Windows.Forms.Button
    Friend WithEvents gb_cortes As System.Windows.Forms.GroupBox
    Friend WithEvents cb_documentos As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
End Class
