<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_opciones_favoritos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_opciones_favoritos))
        Me.dgv_opciones = New System.Windows.Forms.DataGridView()
        Me.dgv_opciones_favoritos = New System.Windows.Forms.DataGridView()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_quitar = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.lb_url = New System.Windows.Forms.Label()
        Me.tb_url = New System.Windows.Forms.TextBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        CType(Me.dgv_opciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_opciones_favoritos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_opciones
        '
        Me.dgv_opciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_opciones.Location = New System.Drawing.Point(12, 12)
        Me.dgv_opciones.MultiSelect = False
        Me.dgv_opciones.Name = "dgv_opciones"
        Me.dgv_opciones.ReadOnly = True
        Me.dgv_opciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_opciones.Size = New System.Drawing.Size(369, 480)
        Me.dgv_opciones.TabIndex = 0
        '
        'dgv_opciones_favoritos
        '
        Me.dgv_opciones_favoritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_opciones_favoritos.Location = New System.Drawing.Point(542, 12)
        Me.dgv_opciones_favoritos.MultiSelect = False
        Me.dgv_opciones_favoritos.Name = "dgv_opciones_favoritos"
        Me.dgv_opciones_favoritos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_opciones_favoritos.Size = New System.Drawing.Size(342, 502)
        Me.dgv_opciones_favoritos.TabIndex = 0
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.White
        Me.btn_agregar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_agregar.Location = New System.Drawing.Point(393, 80)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(137, 70)
        Me.btn_agregar.TabIndex = 3
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_agregar.UseVisualStyleBackColor = False
        '
        'btn_quitar
        '
        Me.btn_quitar.BackColor = System.Drawing.Color.White
        Me.btn_quitar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_quitar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitar.Image = CType(resources.GetObject("btn_quitar.Image"), System.Drawing.Image)
        Me.btn_quitar.Location = New System.Drawing.Point(393, 156)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(137, 70)
        Me.btn_quitar.TabIndex = 2
        Me.btn_quitar.Text = "Quitar"
        Me.btn_quitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_quitar.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.White
        Me.btn_guardar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(393, 232)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(137, 70)
        Me.btn_guardar.TabIndex = 2
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'lb_url
        '
        Me.lb_url.AutoSize = True
        Me.lb_url.Location = New System.Drawing.Point(12, 501)
        Me.lb_url.Name = "lb_url"
        Me.lb_url.Size = New System.Drawing.Size(32, 13)
        Me.lb_url.TabIndex = 4
        Me.lb_url.Text = "URL:"
        Me.lb_url.Visible = False
        '
        'tb_url
        '
        Me.tb_url.Location = New System.Drawing.Point(50, 498)
        Me.tb_url.Name = "tb_url"
        Me.tb_url.Size = New System.Drawing.Size(331, 20)
        Me.tb_url.TabIndex = 5
        Me.tb_url.Visible = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(393, 308)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(137, 70)
        Me.btn_salir.TabIndex = 6
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'frm_opciones_favoritos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 532)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.tb_url)
        Me.Controls.Add(Me.lb_url)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.btn_quitar)
        Me.Controls.Add(Me.dgv_opciones_favoritos)
        Me.Controls.Add(Me.dgv_opciones)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_opciones_favoritos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de botones favoritos"
        CType(Me.dgv_opciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_opciones_favoritos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_opciones As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_opciones_favoritos As System.Windows.Forms.DataGridView
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_quitar As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents lb_url As System.Windows.Forms.Label
    Friend WithEvents tb_url As System.Windows.Forms.TextBox
    Friend WithEvents btn_salir As Button
End Class
