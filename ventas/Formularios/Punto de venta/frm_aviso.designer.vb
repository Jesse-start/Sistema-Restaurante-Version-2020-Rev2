<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_aviso
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_aviso))
        Me.Lbl_aviso = New System.Windows.Forms.Label()
        Me.Temporizador = New System.Windows.Forms.Timer(Me.components)
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Lbl_aviso
        '
        Me.Lbl_aviso.AutoSize = True
        Me.Lbl_aviso.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_aviso.ForeColor = System.Drawing.Color.Black
        Me.Lbl_aviso.Location = New System.Drawing.Point(12, 26)
        Me.Lbl_aviso.MaximumSize = New System.Drawing.Size(550, 70)
        Me.Lbl_aviso.MinimumSize = New System.Drawing.Size(600, 70)
        Me.Lbl_aviso.Name = "Lbl_aviso"
        Me.Lbl_aviso.Size = New System.Drawing.Size(600, 70)
        Me.Lbl_aviso.TabIndex = 0
        Me.Lbl_aviso.Text = "NO SE ENCONTRARÓN COINCIDENCIAS"
        Me.Lbl_aviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Temporizador
        '
        Me.Temporizador.Enabled = True
        Me.Temporizador.Interval = 200
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Image = CType(resources.GetObject("btn_ok.Image"), System.Drawing.Image)
        Me.btn_ok.Location = New System.Drawing.Point(618, 26)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(150, 70)
        Me.btn_ok.TabIndex = 1
        Me.btn_ok.Text = "Aceptar"
        Me.btn_ok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'frm_aviso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(804, 118)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.Lbl_aviso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_aviso"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aviso"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_aviso As System.Windows.Forms.Label
    Friend WithEvents Temporizador As System.Windows.Forms.Timer
    Friend WithEvents btn_ok As System.Windows.Forms.Button
End Class
