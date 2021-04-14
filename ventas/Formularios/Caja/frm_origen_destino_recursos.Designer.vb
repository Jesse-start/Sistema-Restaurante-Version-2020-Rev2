<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_origen_destino_recursos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_origen_destino_recursos))
        Me.btn_no_afectar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_afectar_caja = New System.Windows.Forms.Button()
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.gb_origen_destino = New System.Windows.Forms.GroupBox()
        Me.tb_total_caja = New System.Windows.Forms.Label()
        Me.gb_origen_destino.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_no_afectar
        '
        Me.btn_no_afectar.Enabled = False
        Me.btn_no_afectar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_no_afectar.Image = CType(resources.GetObject("btn_no_afectar.Image"), System.Drawing.Image)
        Me.btn_no_afectar.Location = New System.Drawing.Point(116, 47)
        Me.btn_no_afectar.Name = "btn_no_afectar"
        Me.btn_no_afectar.Size = New System.Drawing.Size(104, 98)
        Me.btn_no_afectar.TabIndex = 0
        Me.btn_no_afectar.Text = "SOLO REGISTRAR"
        Me.btn_no_afectar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_no_afectar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancelar.Location = New System.Drawing.Point(226, 47)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(104, 98)
        Me.btn_cancelar.TabIndex = 0
        Me.btn_cancelar.Text = "CANCELAR"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_afectar_caja
        '
        Me.btn_afectar_caja.Enabled = False
        Me.btn_afectar_caja.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_afectar_caja.Image = CType(resources.GetObject("btn_afectar_caja.Image"), System.Drawing.Image)
        Me.btn_afectar_caja.Location = New System.Drawing.Point(6, 47)
        Me.btn_afectar_caja.Name = "btn_afectar_caja"
        Me.btn_afectar_caja.Size = New System.Drawing.Size(104, 98)
        Me.btn_afectar_caja.TabIndex = 0
        Me.btn_afectar_caja.Text = "AFECTAR EN CAJA"
        Me.btn_afectar_caja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_afectar_caja.UseVisualStyleBackColor = True
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(61, 13)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(26, 23)
        Me.lbl_titulo.TabIndex = 1
        Me.lbl_titulo.Text = "--"
        '
        'gb_origen_destino
        '
        Me.gb_origen_destino.Controls.Add(Me.btn_afectar_caja)
        Me.gb_origen_destino.Controls.Add(Me.tb_total_caja)
        Me.gb_origen_destino.Controls.Add(Me.lbl_titulo)
        Me.gb_origen_destino.Controls.Add(Me.btn_no_afectar)
        Me.gb_origen_destino.Controls.Add(Me.btn_cancelar)
        Me.gb_origen_destino.Location = New System.Drawing.Point(8, 4)
        Me.gb_origen_destino.Name = "gb_origen_destino"
        Me.gb_origen_destino.Size = New System.Drawing.Size(344, 196)
        Me.gb_origen_destino.TabIndex = 2
        Me.gb_origen_destino.TabStop = False
        '
        'tb_total_caja
        '
        Me.tb_total_caja.AutoSize = True
        Me.tb_total_caja.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total_caja.Location = New System.Drawing.Point(61, 161)
        Me.tb_total_caja.Name = "tb_total_caja"
        Me.tb_total_caja.Size = New System.Drawing.Size(26, 23)
        Me.tb_total_caja.TabIndex = 1
        Me.tb_total_caja.Text = "--"
        '
        'frm_origen_destino_recursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 212)
        Me.Controls.Add(Me.gb_origen_destino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_origen_destino_recursos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_origen_destino_recursos"
        Me.gb_origen_destino.ResumeLayout(False)
        Me.gb_origen_destino.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_afectar_caja As System.Windows.Forms.Button
    Friend WithEvents btn_no_afectar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents lbl_titulo As System.Windows.Forms.Label
    Friend WithEvents gb_origen_destino As System.Windows.Forms.GroupBox
    Friend WithEvents tb_total_caja As System.Windows.Forms.Label
End Class
