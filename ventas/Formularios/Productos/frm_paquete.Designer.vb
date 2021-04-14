<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_paquete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_paquete))
        Me.dgv_paquete_seleccion = New System.Windows.Forms.DataGridView()
        Me.dgv_paquete_modificador = New System.Windows.Forms.DataGridView()
        Me.tb_nombre_modificador = New System.Windows.Forms.Label()
        Me.tb_nombre_paquete = New System.Windows.Forms.Label()
        Me.btn_anterior = New System.Windows.Forms.Button()
        Me.btn_siguiente = New System.Windows.Forms.Button()
        Me.pb_paquete = New System.Windows.Forms.PictureBox()
        Me.tb_unidad = New System.Windows.Forms.Label()
        Me.tb_cantidad = New System.Windows.Forms.Label()
        CType(Me.dgv_paquete_seleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_paquete_modificador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_paquete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_paquete_seleccion
        '
        Me.dgv_paquete_seleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_paquete_seleccion.Location = New System.Drawing.Point(16, 85)
        Me.dgv_paquete_seleccion.Name = "dgv_paquete_seleccion"
        Me.dgv_paquete_seleccion.Size = New System.Drawing.Size(419, 398)
        Me.dgv_paquete_seleccion.TabIndex = 0
        '
        'dgv_paquete_modificador
        '
        Me.dgv_paquete_modificador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_paquete_modificador.Location = New System.Drawing.Point(494, 85)
        Me.dgv_paquete_modificador.MultiSelect = False
        Me.dgv_paquete_modificador.Name = "dgv_paquete_modificador"
        Me.dgv_paquete_modificador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_paquete_modificador.Size = New System.Drawing.Size(431, 398)
        Me.dgv_paquete_modificador.TabIndex = 1
        '
        'tb_nombre_modificador
        '
        Me.tb_nombre_modificador.AutoSize = True
        Me.tb_nombre_modificador.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre_modificador.Location = New System.Drawing.Point(490, 45)
        Me.tb_nombre_modificador.Name = "tb_nombre_modificador"
        Me.tb_nombre_modificador.Size = New System.Drawing.Size(264, 24)
        Me.tb_nombre_modificador.TabIndex = 2
        Me.tb_nombre_modificador.Text = "Nombre del modificador"
        '
        'tb_nombre_paquete
        '
        Me.tb_nombre_paquete.AutoSize = True
        Me.tb_nombre_paquete.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre_paquete.Location = New System.Drawing.Point(92, 58)
        Me.tb_nombre_paquete.Name = "tb_nombre_paquete"
        Me.tb_nombre_paquete.Size = New System.Drawing.Size(227, 24)
        Me.tb_nombre_paquete.TabIndex = 2
        Me.tb_nombre_paquete.Text = "nombre del paquete"
        '
        'btn_anterior
        '
        Me.btn_anterior.Font = New System.Drawing.Font("Wingdings 3", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_anterior.ForeColor = System.Drawing.Color.Black
        Me.btn_anterior.Location = New System.Drawing.Point(441, 79)
        Me.btn_anterior.Name = "btn_anterior"
        Me.btn_anterior.Size = New System.Drawing.Size(47, 398)
        Me.btn_anterior.TabIndex = 3
        Me.btn_anterior.Text = "t"
        Me.btn_anterior.UseVisualStyleBackColor = True
        '
        'btn_siguiente
        '
        Me.btn_siguiente.Font = New System.Drawing.Font("Wingdings 3", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btn_siguiente.ForeColor = System.Drawing.Color.Black
        Me.btn_siguiente.Location = New System.Drawing.Point(931, 79)
        Me.btn_siguiente.Name = "btn_siguiente"
        Me.btn_siguiente.Size = New System.Drawing.Size(43, 398)
        Me.btn_siguiente.TabIndex = 3
        Me.btn_siguiente.Text = "u"
        Me.btn_siguiente.UseVisualStyleBackColor = True
        '
        'pb_paquete
        '
        Me.pb_paquete.Location = New System.Drawing.Point(16, 9)
        Me.pb_paquete.Name = "pb_paquete"
        Me.pb_paquete.Size = New System.Drawing.Size(60, 60)
        Me.pb_paquete.TabIndex = 4
        Me.pb_paquete.TabStop = False
        '
        'tb_unidad
        '
        Me.tb_unidad.AutoSize = True
        Me.tb_unidad.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_unidad.Location = New System.Drawing.Point(92, 32)
        Me.tb_unidad.Name = "tb_unidad"
        Me.tb_unidad.Size = New System.Drawing.Size(81, 24)
        Me.tb_unidad.TabIndex = 2
        Me.tb_unidad.Text = "Unidad"
        '
        'tb_cantidad
        '
        Me.tb_cantidad.AutoSize = True
        Me.tb_cantidad.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cantidad.Location = New System.Drawing.Point(92, 4)
        Me.tb_cantidad.Name = "tb_cantidad"
        Me.tb_cantidad.Size = New System.Drawing.Size(106, 24)
        Me.tb_cantidad.TabIndex = 2
        Me.tb_cantidad.Text = "Cantidad"
        '
        'frm_paquete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 503)
        Me.Controls.Add(Me.pb_paquete)
        Me.Controls.Add(Me.btn_siguiente)
        Me.Controls.Add(Me.btn_anterior)
        Me.Controls.Add(Me.tb_cantidad)
        Me.Controls.Add(Me.tb_unidad)
        Me.Controls.Add(Me.tb_nombre_paquete)
        Me.Controls.Add(Me.tb_nombre_modificador)
        Me.Controls.Add(Me.dgv_paquete_modificador)
        Me.Controls.Add(Me.dgv_paquete_seleccion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_paquete"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar paquete"
        CType(Me.dgv_paquete_seleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_paquete_modificador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_paquete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_paquete_seleccion As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_paquete_modificador As System.Windows.Forms.DataGridView
    Friend WithEvents tb_nombre_modificador As System.Windows.Forms.Label
    Friend WithEvents tb_nombre_paquete As System.Windows.Forms.Label
    Friend WithEvents btn_anterior As System.Windows.Forms.Button
    Friend WithEvents btn_siguiente As System.Windows.Forms.Button
    Friend WithEvents pb_paquete As System.Windows.Forms.PictureBox
    Friend WithEvents tb_unidad As System.Windows.Forms.Label
    Friend WithEvents tb_cantidad As System.Windows.Forms.Label
End Class
