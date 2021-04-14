<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_productos_codigos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_productos_codigos))
        Me.dgv_codigos = New System.Windows.Forms.DataGridView()
        Me.chb_categoria = New System.Windows.Forms.CheckBox()
        Me.tb_categoria = New System.Windows.Forms.Label()
        Me.chb_descripcion = New System.Windows.Forms.CheckBox()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.btn_cerrar = New System.Windows.Forms.Button()
        CType(Me.dgv_codigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_codigos
        '
        Me.dgv_codigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_codigos.Location = New System.Drawing.Point(20, 75)
        Me.dgv_codigos.Name = "dgv_codigos"
        Me.dgv_codigos.Size = New System.Drawing.Size(432, 481)
        Me.dgv_codigos.TabIndex = 0
        '
        'chb_categoria
        '
        Me.chb_categoria.AutoSize = True
        Me.chb_categoria.Checked = True
        Me.chb_categoria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_categoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_categoria.Location = New System.Drawing.Point(39, 12)
        Me.chb_categoria.Name = "chb_categoria"
        Me.chb_categoria.Size = New System.Drawing.Size(89, 20)
        Me.chb_categoria.TabIndex = 1
        Me.chb_categoria.Text = "Categoria:"
        Me.chb_categoria.UseVisualStyleBackColor = True
        '
        'tb_categoria
        '
        Me.tb_categoria.AutoSize = True
        Me.tb_categoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_categoria.Location = New System.Drawing.Point(122, 14)
        Me.tb_categoria.Name = "tb_categoria"
        Me.tb_categoria.Size = New System.Drawing.Size(150, 16)
        Me.tb_categoria.TabIndex = 2
        Me.tb_categoria.Text = "Nombre de la categoria"
        '
        'chb_descripcion
        '
        Me.chb_descripcion.AutoSize = True
        Me.chb_descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_descripcion.Location = New System.Drawing.Point(39, 39)
        Me.chb_descripcion.Name = "chb_descripcion"
        Me.chb_descripcion.Size = New System.Drawing.Size(79, 20)
        Me.chb_descripcion.TabIndex = 1
        Me.chb_descripcion.Text = "Nombre:"
        Me.chb_descripcion.UseVisualStyleBackColor = True
        '
        'tb_nombre
        '
        Me.tb_nombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre.Location = New System.Drawing.Point(124, 39)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(266, 22)
        Me.tb_nombre.TabIndex = 3
        '
        'btn_cerrar
        '
        Me.btn_cerrar.BackColor = System.Drawing.Color.White
        Me.btn_cerrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cerrar.Image = CType(resources.GetObject("btn_cerrar.Image"), System.Drawing.Image)
        Me.btn_cerrar.Location = New System.Drawing.Point(189, 562)
        Me.btn_cerrar.Name = "btn_cerrar"
        Me.btn_cerrar.Size = New System.Drawing.Size(158, 62)
        Me.btn_cerrar.TabIndex = 4
        Me.btn_cerrar.Text = "Salir"
        Me.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cerrar.UseVisualStyleBackColor = False
        '
        'frm_productos_codigos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 629)
        Me.Controls.Add(Me.btn_cerrar)
        Me.Controls.Add(Me.tb_nombre)
        Me.Controls.Add(Me.tb_categoria)
        Me.Controls.Add(Me.chb_descripcion)
        Me.Controls.Add(Me.chb_categoria)
        Me.Controls.Add(Me.dgv_codigos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_productos_codigos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ver códigos de productos"
        CType(Me.dgv_codigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_codigos As System.Windows.Forms.DataGridView
    Friend WithEvents chb_categoria As System.Windows.Forms.CheckBox
    Friend WithEvents tb_categoria As System.Windows.Forms.Label
    Friend WithEvents chb_descripcion As System.Windows.Forms.CheckBox
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents btn_cerrar As System.Windows.Forms.Button
End Class
