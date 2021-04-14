<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_apartados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_apartados))
        Me.dgv_apartado = New System.Windows.Forms.DataGridView()
        Me.btn_ver_pedido = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.lbl_estatus_pago = New System.Windows.Forms.Label()
        Me.cb_estatus_pago = New System.Windows.Forms.ComboBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_repartidor = New System.Windows.Forms.ComboBox()
        Me.rb_fecha = New System.Windows.Forms.RadioButton()
        Me.rb_todos = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_vendedor = New System.Windows.Forms.ComboBox()
        CType(Me.dgv_apartado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_apartado
        '
        Me.dgv_apartado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_apartado.Location = New System.Drawing.Point(11, 142)
        Me.dgv_apartado.MultiSelect = False
        Me.dgv_apartado.Name = "dgv_apartado"
        Me.dgv_apartado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_apartado.Size = New System.Drawing.Size(960, 437)
        Me.dgv_apartado.TabIndex = 0
        '
        'btn_ver_pedido
        '
        Me.btn_ver_pedido.BackColor = System.Drawing.Color.White
        Me.btn_ver_pedido.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ver_pedido.Image = CType(resources.GetObject("btn_ver_pedido.Image"), System.Drawing.Image)
        Me.btn_ver_pedido.Location = New System.Drawing.Point(623, 585)
        Me.btn_ver_pedido.Name = "btn_ver_pedido"
        Me.btn_ver_pedido.Size = New System.Drawing.Size(157, 76)
        Me.btn_ver_pedido.TabIndex = 1
        Me.btn_ver_pedido.Text = "Ver Apartado"
        Me.btn_ver_pedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_ver_pedido.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(789, 585)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(122, 76)
        Me.btn_salir.TabIndex = 75
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 21)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Buscar:"
        '
        'tb_buscar
        '
        Me.tb_buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_buscar.Location = New System.Drawing.Point(103, 10)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(377, 27)
        Me.tb_buscar.TabIndex = 77
        '
        'lbl_estatus_pago
        '
        Me.lbl_estatus_pago.AutoSize = True
        Me.lbl_estatus_pago.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estatus_pago.Location = New System.Drawing.Point(491, 13)
        Me.lbl_estatus_pago.Name = "lbl_estatus_pago"
        Me.lbl_estatus_pago.Size = New System.Drawing.Size(117, 21)
        Me.lbl_estatus_pago.TabIndex = 76
        Me.lbl_estatus_pago.Text = "Estatus pago:"
        '
        'cb_estatus_pago
        '
        Me.cb_estatus_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_estatus_pago.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_estatus_pago.FormattingEnabled = True
        Me.cb_estatus_pago.Location = New System.Drawing.Point(609, 8)
        Me.cb_estatus_pago.Name = "cb_estatus_pago"
        Me.cb_estatus_pago.Size = New System.Drawing.Size(288, 29)
        Me.cb_estatus_pago.TabIndex = 78
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.White
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_buscar.Location = New System.Drawing.Point(103, 78)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(113, 58)
        Me.btn_buscar.TabIndex = 79
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = False
        Me.btn_buscar.Visible = False
        '
        'dtp_fecha
        '
        Me.dtp_fecha.CalendarFont = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha.Location = New System.Drawing.Point(345, 45)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(137, 27)
        Me.dtp_fecha.TabIndex = 80
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(510, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 21)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Repartidor:"
        '
        'cb_repartidor
        '
        Me.cb_repartidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_repartidor.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_repartidor.FormattingEnabled = True
        Me.cb_repartidor.Location = New System.Drawing.Point(609, 43)
        Me.cb_repartidor.Name = "cb_repartidor"
        Me.cb_repartidor.Size = New System.Drawing.Size(288, 29)
        Me.cb_repartidor.TabIndex = 78
        '
        'rb_fecha
        '
        Me.rb_fecha.AutoSize = True
        Me.rb_fecha.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_fecha.Location = New System.Drawing.Point(263, 47)
        Me.rb_fecha.Name = "rb_fecha"
        Me.rb_fecha.Size = New System.Drawing.Size(81, 25)
        Me.rb_fecha.TabIndex = 81
        Me.rb_fecha.Text = "Fecha:"
        Me.rb_fecha.UseVisualStyleBackColor = True
        '
        'rb_todos
        '
        Me.rb_todos.AutoSize = True
        Me.rb_todos.Checked = True
        Me.rb_todos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb_todos.Location = New System.Drawing.Point(103, 47)
        Me.rb_todos.Name = "rb_todos"
        Me.rb_todos.Size = New System.Drawing.Size(154, 25)
        Me.rb_todos.TabIndex = 82
        Me.rb_todos.TabStop = True
        Me.rb_todos.Text = "Cualquier fecha"
        Me.rb_todos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(510, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 21)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Vendedor:"
        '
        'cb_vendedor
        '
        Me.cb_vendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_vendedor.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_vendedor.FormattingEnabled = True
        Me.cb_vendedor.Location = New System.Drawing.Point(609, 78)
        Me.cb_vendedor.Name = "cb_vendedor"
        Me.cb_vendedor.Size = New System.Drawing.Size(288, 29)
        Me.cb_vendedor.TabIndex = 78
        '
        'frm_apartados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 673)
        Me.Controls.Add(Me.rb_todos)
        Me.Controls.Add(Me.rb_fecha)
        Me.Controls.Add(Me.dtp_fecha)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.cb_vendedor)
        Me.Controls.Add(Me.cb_repartidor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb_estatus_pago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_estatus_pago)
        Me.Controls.Add(Me.tb_buscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_ver_pedido)
        Me.Controls.Add(Me.dgv_apartado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_apartados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apartados"
        CType(Me.dgv_apartado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_apartado As System.Windows.Forms.DataGridView
    Friend WithEvents btn_ver_pedido As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents lbl_estatus_pago As System.Windows.Forms.Label
    Friend WithEvents cb_estatus_pago As System.Windows.Forms.ComboBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_repartidor As System.Windows.Forms.ComboBox
    Friend WithEvents rb_fecha As System.Windows.Forms.RadioButton
    Friend WithEvents rb_todos As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_vendedor As System.Windows.Forms.ComboBox
End Class
