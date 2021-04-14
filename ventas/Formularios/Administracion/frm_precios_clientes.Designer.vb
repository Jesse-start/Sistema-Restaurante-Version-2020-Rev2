<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_precios_clientes
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_precios = New System.Windows.Forms.ComboBox()
        Me.dgv_cliente_catalogo = New System.Windows.Forms.DataGridView()
        Me.dgv_precio_cliente_catalogo = New System.Windows.Forms.DataGridView()
        CType(Me.dgv_cliente_catalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_precio_cliente_catalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Precio :"
        '
        'cb_precios
        '
        Me.cb_precios.FormattingEnabled = True
        Me.cb_precios.Location = New System.Drawing.Point(61, 18)
        Me.cb_precios.Name = "cb_precios"
        Me.cb_precios.Size = New System.Drawing.Size(210, 21)
        Me.cb_precios.TabIndex = 1
        '
        'dgv_cliente_catalogo
        '
        Me.dgv_cliente_catalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_cliente_catalogo.Location = New System.Drawing.Point(15, 56)
        Me.dgv_cliente_catalogo.Name = "dgv_cliente_catalogo"
        Me.dgv_cliente_catalogo.Size = New System.Drawing.Size(322, 427)
        Me.dgv_cliente_catalogo.TabIndex = 2
        '
        'dgv_precio_cliente_catalogo
        '
        Me.dgv_precio_cliente_catalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_precio_cliente_catalogo.Location = New System.Drawing.Point(369, 56)
        Me.dgv_precio_cliente_catalogo.Name = "dgv_precio_cliente_catalogo"
        Me.dgv_precio_cliente_catalogo.Size = New System.Drawing.Size(335, 427)
        Me.dgv_precio_cliente_catalogo.TabIndex = 2
        '
        'frm_precios_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 562)
        Me.Controls.Add(Me.dgv_precio_cliente_catalogo)
        Me.Controls.Add(Me.dgv_cliente_catalogo)
        Me.Controls.Add(Me.cb_precios)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_precios_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de clientes por precio"
        CType(Me.dgv_cliente_catalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_precio_cliente_catalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_precios As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_cliente_catalogo As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_precio_cliente_catalogo As System.Windows.Forms.DataGridView
End Class
