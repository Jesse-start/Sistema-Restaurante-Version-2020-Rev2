<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cambio_precio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cambio_precio))
        Me.lbl_precio = New System.Windows.Forms.Label()
        Me.cb_precio = New System.Windows.Forms.ComboBox()
        Me.dgv_cambio_precio = New System.Windows.Forms.DataGridView()
        Me.btn_aplicar_precios = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        CType(Me.dgv_cambio_precio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_precio
        '
        Me.lbl_precio.AutoSize = True
        Me.lbl_precio.Location = New System.Drawing.Point(7, 10)
        Me.lbl_precio.Name = "lbl_precio"
        Me.lbl_precio.Size = New System.Drawing.Size(40, 13)
        Me.lbl_precio.TabIndex = 0
        Me.lbl_precio.Text = "Precio:"
        '
        'cb_precio
        '
        Me.cb_precio.FormattingEnabled = True
        Me.cb_precio.Location = New System.Drawing.Point(65, 7)
        Me.cb_precio.Name = "cb_precio"
        Me.cb_precio.Size = New System.Drawing.Size(221, 21)
        Me.cb_precio.TabIndex = 1
        '
        'dgv_cambio_precio
        '
        Me.dgv_cambio_precio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_cambio_precio.Location = New System.Drawing.Point(3, 34)
        Me.dgv_cambio_precio.Name = "dgv_cambio_precio"
        Me.dgv_cambio_precio.Size = New System.Drawing.Size(732, 365)
        Me.dgv_cambio_precio.TabIndex = 2
        '
        'btn_aplicar_precios
        '
        Me.btn_aplicar_precios.Enabled = False
        Me.btn_aplicar_precios.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplicar_precios.Image = CType(resources.GetObject("btn_aplicar_precios.Image"), System.Drawing.Image)
        Me.btn_aplicar_precios.Location = New System.Drawing.Point(307, 417)
        Me.btn_aplicar_precios.Name = "btn_aplicar_precios"
        Me.btn_aplicar_precios.Size = New System.Drawing.Size(76, 74)
        Me.btn_aplicar_precios.TabIndex = 14
        Me.btn_aplicar_precios.Text = "Aplicar"
        Me.btn_aplicar_precios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_aplicar_precios.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(389, 417)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(76, 74)
        Me.btn_cancelar.TabIndex = 15
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'frm_cambio_precio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 506)
        Me.Controls.Add(Me.btn_aplicar_precios)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.dgv_cambio_precio)
        Me.Controls.Add(Me.cb_precio)
        Me.Controls.Add(Me.lbl_precio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_cambio_precio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Precio"
        CType(Me.dgv_cambio_precio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_precio As System.Windows.Forms.Label
    Friend WithEvents cb_precio As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_cambio_precio As System.Windows.Forms.DataGridView
    Friend WithEvents btn_aplicar_precios As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
End Class
