<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_modificadores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_modificadores))
        Me.Cerrar = New System.Windows.Forms.Button()
        Me.btn_actualizar_perspectiva = New System.Windows.Forms.Button()
        Me.tb_nombre_modificador = New System.Windows.Forms.TextBox()
        Me.btn_agregar_modificador = New System.Windows.Forms.Button()
        Me.tb_nombre_perspectiva_nuevo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_modificadores = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.panel_perspectiva = New System.Windows.Forms.Panel()
        Me.btn_borrar_perspectiva = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.panel_perspectiva.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cerrar
        '
        Me.Cerrar.BackColor = System.Drawing.Color.White
        Me.Cerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cerrar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cerrar.Image = CType(resources.GetObject("Cerrar.Image"), System.Drawing.Image)
        Me.Cerrar.Location = New System.Drawing.Point(299, 396)
        Me.Cerrar.Name = "Cerrar"
        Me.Cerrar.Size = New System.Drawing.Size(129, 72)
        Me.Cerrar.TabIndex = 27
        Me.Cerrar.Text = "Cerrar"
        Me.Cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Cerrar.UseVisualStyleBackColor = False
        '
        'btn_actualizar_perspectiva
        '
        Me.btn_actualizar_perspectiva.BackColor = System.Drawing.Color.White
        Me.btn_actualizar_perspectiva.Enabled = False
        Me.btn_actualizar_perspectiva.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar_perspectiva.Image = CType(resources.GetObject("btn_actualizar_perspectiva.Image"), System.Drawing.Image)
        Me.btn_actualizar_perspectiva.Location = New System.Drawing.Point(260, 6)
        Me.btn_actualizar_perspectiva.Name = "btn_actualizar_perspectiva"
        Me.btn_actualizar_perspectiva.Size = New System.Drawing.Size(154, 76)
        Me.btn_actualizar_perspectiva.TabIndex = 6
        Me.btn_actualizar_perspectiva.Text = "Actualizar"
        Me.btn_actualizar_perspectiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_actualizar_perspectiva.UseVisualStyleBackColor = False
        '
        'tb_nombre_modificador
        '
        Me.tb_nombre_modificador.Location = New System.Drawing.Point(60, 30)
        Me.tb_nombre_modificador.Name = "tb_nombre_modificador"
        Me.tb_nombre_modificador.Size = New System.Drawing.Size(249, 20)
        Me.tb_nombre_modificador.TabIndex = 29
        '
        'btn_agregar_modificador
        '
        Me.btn_agregar_modificador.BackColor = System.Drawing.Color.White
        Me.btn_agregar_modificador.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_modificador.Image = CType(resources.GetObject("btn_agregar_modificador.Image"), System.Drawing.Image)
        Me.btn_agregar_modificador.Location = New System.Drawing.Point(326, 9)
        Me.btn_agregar_modificador.Name = "btn_agregar_modificador"
        Me.btn_agregar_modificador.Size = New System.Drawing.Size(130, 60)
        Me.btn_agregar_modificador.TabIndex = 30
        Me.btn_agregar_modificador.Text = "Agregar"
        Me.btn_agregar_modificador.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_agregar_modificador.UseVisualStyleBackColor = False
        '
        'tb_nombre_perspectiva_nuevo
        '
        Me.tb_nombre_perspectiva_nuevo.Enabled = False
        Me.tb_nombre_perspectiva_nuevo.Location = New System.Drawing.Point(3, 34)
        Me.tb_nombre_perspectiva_nuevo.Name = "tb_nombre_perspectiva_nuevo"
        Me.tb_nombre_perspectiva_nuevo.Size = New System.Drawing.Size(250, 20)
        Me.tb_nombre_perspectiva_nuevo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Nuevo:"
        '
        'cb_modificadores
        '
        Me.cb_modificadores.BackColor = System.Drawing.Color.White
        Me.cb_modificadores.FormattingEnabled = True
        Me.cb_modificadores.Location = New System.Drawing.Point(8, 18)
        Me.cb_modificadores.Name = "cb_modificadores"
        Me.cb_modificadores.Size = New System.Drawing.Size(550, 199)
        Me.cb_modificadores.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cb_modificadores)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(577, 223)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modificadores"
        '
        'panel_perspectiva
        '
        Me.panel_perspectiva.Controls.Add(Me.btn_borrar_perspectiva)
        Me.panel_perspectiva.Controls.Add(Me.btn_actualizar_perspectiva)
        Me.panel_perspectiva.Controls.Add(Me.tb_nombre_perspectiva_nuevo)
        Me.panel_perspectiva.Location = New System.Drawing.Point(14, 299)
        Me.panel_perspectiva.Name = "panel_perspectiva"
        Me.panel_perspectiva.Size = New System.Drawing.Size(575, 91)
        Me.panel_perspectiva.TabIndex = 32
        '
        'btn_borrar_perspectiva
        '
        Me.btn_borrar_perspectiva.BackColor = System.Drawing.Color.White
        Me.btn_borrar_perspectiva.Enabled = False
        Me.btn_borrar_perspectiva.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_borrar_perspectiva.Image = CType(resources.GetObject("btn_borrar_perspectiva.Image"), System.Drawing.Image)
        Me.btn_borrar_perspectiva.Location = New System.Drawing.Point(420, 5)
        Me.btn_borrar_perspectiva.Name = "btn_borrar_perspectiva"
        Me.btn_borrar_perspectiva.Size = New System.Drawing.Size(148, 77)
        Me.btn_borrar_perspectiva.TabIndex = 7
        Me.btn_borrar_perspectiva.Text = "Borrar"
        Me.btn_borrar_perspectiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_borrar_perspectiva.UseVisualStyleBackColor = False
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.White
        Me.btn_aceptar.Enabled = False
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.Location = New System.Drawing.Point(164, 396)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(129, 72)
        Me.btn_aceptar.TabIndex = 27
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'frm_modificadores
        '
        Me.AcceptButton = Me.btn_aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cerrar
        Me.ClientSize = New System.Drawing.Size(601, 478)
        Me.Controls.Add(Me.tb_nombre_modificador)
        Me.Controls.Add(Me.panel_perspectiva)
        Me.Controls.Add(Me.btn_agregar_modificador)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.Cerrar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_modificadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificadores"
        Me.GroupBox1.ResumeLayout(False)
        Me.panel_perspectiva.ResumeLayout(False)
        Me.panel_perspectiva.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cerrar As System.Windows.Forms.Button
    Friend WithEvents btn_actualizar_perspectiva As System.Windows.Forms.Button
    Friend WithEvents tb_nombre_modificador As System.Windows.Forms.TextBox
    Friend WithEvents btn_agregar_modificador As System.Windows.Forms.Button
    Friend WithEvents tb_nombre_perspectiva_nuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_modificadores As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents panel_perspectiva As System.Windows.Forms.Panel
    Friend WithEvents btn_borrar_perspectiva As System.Windows.Forms.Button
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
End Class
