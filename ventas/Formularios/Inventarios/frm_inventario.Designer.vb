<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_inventario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_inventario))
        Me.gb_inventario = New System.Windows.Forms.GroupBox()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.chb_imprimir_codigos = New System.Windows.Forms.CheckBox()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.dgv_inventario = New System.Windows.Forms.DataGridView()
        Me.tb_error = New System.Windows.Forms.Label()
        Me.cb_almacen = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_marca = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_categoria = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_sucursal = New System.Windows.Forms.ComboBox()
        Me.gb_inventario.SuspendLayout()
        CType(Me.dgv_inventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_inventario
        '
        Me.gb_inventario.Controls.Add(Me.tb_buscar)
        Me.gb_inventario.Controls.Add(Me.chb_imprimir_codigos)
        Me.gb_inventario.Controls.Add(Me.btn_imprimir)
        Me.gb_inventario.Controls.Add(Me.btn_salir)
        Me.gb_inventario.Controls.Add(Me.dgv_inventario)
        Me.gb_inventario.Controls.Add(Me.tb_error)
        Me.gb_inventario.Controls.Add(Me.cb_almacen)
        Me.gb_inventario.Controls.Add(Me.Label3)
        Me.gb_inventario.Controls.Add(Me.Label2)
        Me.gb_inventario.Controls.Add(Me.Label4)
        Me.gb_inventario.Controls.Add(Me.cb_marca)
        Me.gb_inventario.Controls.Add(Me.Label5)
        Me.gb_inventario.Controls.Add(Me.cb_categoria)
        Me.gb_inventario.Controls.Add(Me.Label1)
        Me.gb_inventario.Controls.Add(Me.cb_sucursal)
        Me.gb_inventario.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_inventario.Location = New System.Drawing.Point(8, 6)
        Me.gb_inventario.Name = "gb_inventario"
        Me.gb_inventario.Size = New System.Drawing.Size(850, 661)
        Me.gb_inventario.TabIndex = 0
        Me.gb_inventario.TabStop = False
        Me.gb_inventario.Text = "Seleccione Sucursal-Almacen"
        '
        'tb_buscar
        '
        Me.tb_buscar.Location = New System.Drawing.Point(158, 106)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(336, 27)
        Me.tb_buscar.TabIndex = 98
        '
        'chb_imprimir_codigos
        '
        Me.chb_imprimir_codigos.AutoSize = True
        Me.chb_imprimir_codigos.Location = New System.Drawing.Point(235, 609)
        Me.chb_imprimir_codigos.Name = "chb_imprimir_codigos"
        Me.chb_imprimir_codigos.Size = New System.Drawing.Size(320, 25)
        Me.chb_imprimir_codigos.TabIndex = 97
        Me.chb_imprimir_codigos.Text = "Imprimir codigos en lugar de nombres"
        Me.chb_imprimir_codigos.UseVisualStyleBackColor = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.White
        Me.btn_imprimir.Enabled = False
        Me.btn_imprimir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.Location = New System.Drawing.Point(577, 596)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(137, 59)
        Me.btn_imprimir.TabIndex = 96
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(720, 596)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(124, 59)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'dgv_inventario
        '
        Me.dgv_inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_inventario.Location = New System.Drawing.Point(6, 171)
        Me.dgv_inventario.Name = "dgv_inventario"
        Me.dgv_inventario.Size = New System.Drawing.Size(838, 419)
        Me.dgv_inventario.TabIndex = 6
        '
        'tb_error
        '
        Me.tb_error.AutoSize = True
        Me.tb_error.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_error.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tb_error.Location = New System.Drawing.Point(11, 146)
        Me.tb_error.Name = "tb_error"
        Me.tb_error.Size = New System.Drawing.Size(19, 20)
        Me.tb_error.TabIndex = 5
        Me.tb_error.Text = "--"
        Me.tb_error.Visible = False
        '
        'cb_almacen
        '
        Me.cb_almacen.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_almacen.FormattingEnabled = True
        Me.cb_almacen.Location = New System.Drawing.Point(94, 61)
        Me.cb_almacen.Name = "cb_almacen"
        Me.cb_almacen.Size = New System.Drawing.Size(269, 29)
        Me.cb_almacen.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Buscar Producto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Almacen:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(388, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Marca:"
        '
        'cb_marca
        '
        Me.cb_marca.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_marca.FormattingEnabled = True
        Me.cb_marca.Location = New System.Drawing.Point(489, 63)
        Me.cb_marca.Name = "cb_marca"
        Me.cb_marca.Size = New System.Drawing.Size(263, 29)
        Me.cb_marca.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(388, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Categoria:"
        '
        'cb_categoria
        '
        Me.cb_categoria.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_categoria.FormattingEnabled = True
        Me.cb_categoria.Location = New System.Drawing.Point(489, 29)
        Me.cb_categoria.Name = "cb_categoria"
        Me.cb_categoria.Size = New System.Drawing.Size(263, 29)
        Me.cb_categoria.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sucursal:"
        '
        'cb_sucursal
        '
        Me.cb_sucursal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sucursal.FormattingEnabled = True
        Me.cb_sucursal.Location = New System.Drawing.Point(94, 26)
        Me.cb_sucursal.Name = "cb_sucursal"
        Me.cb_sucursal.Size = New System.Drawing.Size(269, 29)
        Me.cb_sucursal.TabIndex = 0
        '
        'frm_inventario
        '
        Me.AcceptButton = Me.btn_imprimir
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btn_salir
        Me.ClientSize = New System.Drawing.Size(870, 679)
        Me.Controls.Add(Me.gb_inventario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_inventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario"
        Me.TopMost = True
        Me.gb_inventario.ResumeLayout(False)
        Me.gb_inventario.PerformLayout()
        CType(Me.dgv_inventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_inventario As System.Windows.Forms.GroupBox
    Friend WithEvents cb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents tb_error As System.Windows.Forms.Label
    Friend WithEvents dgv_inventario As System.Windows.Forms.DataGridView
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents chb_imprimir_codigos As System.Windows.Forms.CheckBox
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_categoria As System.Windows.Forms.ComboBox
End Class
