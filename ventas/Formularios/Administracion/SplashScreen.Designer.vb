<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Me.lbl_alias = New System.Windows.Forms.Label()
        Me.lbl_razon = New System.Windows.Forms.Label()
        Me.lbl_rfc = New System.Windows.Forms.Label()
        Me.Pb_logo = New System.Windows.Forms.PictureBox()
        CType(Me.Pb_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_alias
        '
        Me.lbl_alias.AutoSize = True
        Me.lbl_alias.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_alias.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_alias.Location = New System.Drawing.Point(23, 122)
        Me.lbl_alias.MaximumSize = New System.Drawing.Size(450, 0)
        Me.lbl_alias.MinimumSize = New System.Drawing.Size(450, 0)
        Me.lbl_alias.Name = "lbl_alias"
        Me.lbl_alias.Size = New System.Drawing.Size(450, 22)
        Me.lbl_alias.TabIndex = 1
        Me.lbl_alias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_razon
        '
        Me.lbl_razon.AutoSize = True
        Me.lbl_razon.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_razon.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_razon.Location = New System.Drawing.Point(23, 155)
        Me.lbl_razon.MaximumSize = New System.Drawing.Size(450, 0)
        Me.lbl_razon.MinimumSize = New System.Drawing.Size(450, 0)
        Me.lbl_razon.Name = "lbl_razon"
        Me.lbl_razon.Size = New System.Drawing.Size(450, 22)
        Me.lbl_razon.TabIndex = 1
        Me.lbl_razon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_rfc
        '
        Me.lbl_rfc.AutoSize = True
        Me.lbl_rfc.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_rfc.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_rfc.Location = New System.Drawing.Point(23, 187)
        Me.lbl_rfc.MaximumSize = New System.Drawing.Size(450, 0)
        Me.lbl_rfc.MinimumSize = New System.Drawing.Size(450, 0)
        Me.lbl_rfc.Name = "lbl_rfc"
        Me.lbl_rfc.Size = New System.Drawing.Size(450, 22)
        Me.lbl_rfc.TabIndex = 1
        Me.lbl_rfc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pb_logo
        '
        Me.Pb_logo.BackColor = System.Drawing.Color.Transparent
        Me.Pb_logo.Location = New System.Drawing.Point(12, 12)
        Me.Pb_logo.Name = "Pb_logo"
        Me.Pb_logo.Size = New System.Drawing.Size(200, 100)
        Me.Pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pb_logo.TabIndex = 0
        Me.Pb_logo.TabStop = False
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_rfc)
        Me.Controls.Add(Me.lbl_razon)
        Me.Controls.Add(Me.lbl_alias)
        Me.Controls.Add(Me.Pb_logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.Pb_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pb_logo As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_alias As System.Windows.Forms.Label
    Friend WithEvents lbl_razon As System.Windows.Forms.Label
    Friend WithEvents lbl_rfc As System.Windows.Forms.Label

End Class
