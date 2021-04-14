<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_navegador
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_ir = New System.Windows.Forms.Button()
        Me.tb_direccion = New System.Windows.Forms.TextBox()
        Me.btn_actualizar = New System.Windows.Forms.Button()
        Me.btn_adelante = New System.Windows.Forms.Button()
        Me.btn_atras = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.navegador = New Skybound.Gecko.GeckoWebBrowser()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_ir)
        Me.GroupBox1.Controls.Add(Me.tb_direccion)
        Me.GroupBox1.Controls.Add(Me.btn_actualizar)
        Me.GroupBox1.Controls.Add(Me.btn_adelante)
        Me.GroupBox1.Controls.Add(Me.btn_atras)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 45)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dirección:"
        '
        'btn_ir
        '
        Me.btn_ir.Location = New System.Drawing.Point(914, 15)
        Me.btn_ir.Name = "btn_ir"
        Me.btn_ir.Size = New System.Drawing.Size(64, 23)
        Me.btn_ir.TabIndex = 4
        Me.btn_ir.Text = "Ir"
        Me.btn_ir.UseVisualStyleBackColor = True
        '
        'tb_direccion
        '
        Me.tb_direccion.Location = New System.Drawing.Point(237, 18)
        Me.tb_direccion.Name = "tb_direccion"
        Me.tb_direccion.Size = New System.Drawing.Size(671, 20)
        Me.tb_direccion.TabIndex = 3
        Me.tb_direccion.Text = "www.google.com"
        '
        'btn_actualizar
        '
        Me.btn_actualizar.Location = New System.Drawing.Point(156, 16)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(75, 23)
        Me.btn_actualizar.TabIndex = 2
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.UseVisualStyleBackColor = True
        '
        'btn_adelante
        '
        Me.btn_adelante.Location = New System.Drawing.Point(81, 16)
        Me.btn_adelante.Name = "btn_adelante"
        Me.btn_adelante.Size = New System.Drawing.Size(69, 23)
        Me.btn_adelante.TabIndex = 1
        Me.btn_adelante.Text = "Adelante"
        Me.btn_adelante.UseVisualStyleBackColor = True
        '
        'btn_atras
        '
        Me.btn_atras.Location = New System.Drawing.Point(6, 16)
        Me.btn_atras.Name = "btn_atras"
        Me.btn_atras.Size = New System.Drawing.Size(69, 23)
        Me.btn_atras.TabIndex = 1
        Me.btn_atras.Text = "Atras"
        Me.btn_atras.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.navegador)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1008, 673)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'navegador
        '
        Me.navegador.Location = New System.Drawing.Point(6, 19)
        Me.navegador.Name = "navegador"
        Me.navegador.Size = New System.Drawing.Size(996, 648)
        Me.navegador.TabIndex = 1
        '
        'frm_navegador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_navegador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Navegador web"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ir As System.Windows.Forms.Button
    Friend WithEvents tb_direccion As System.Windows.Forms.TextBox
    Friend WithEvents btn_actualizar As System.Windows.Forms.Button
    Friend WithEvents btn_adelante As System.Windows.Forms.Button
    Friend WithEvents btn_atras As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents navegador As Skybound.Gecko.GeckoWebBrowser
End Class
