<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_bitacora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_bitacora))
        Me.gb_mantenimiento = New System.Windows.Forms.GroupBox()
        Me.lst_mantenimientos = New System.Windows.Forms.ListView()
        Me.gb_operaciones = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_modificar_1folio = New System.Windows.Forms.Button()
        Me.btn_eliminar_manto = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btn_reimpresion_folios = New System.Windows.Forms.Button()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.gb_mantenimiento.SuspendLayout()
        Me.gb_operaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_mantenimiento
        '
        Me.gb_mantenimiento.Controls.Add(Me.lst_mantenimientos)
        Me.gb_mantenimiento.Controls.Add(Me.gb_operaciones)
        Me.gb_mantenimiento.Location = New System.Drawing.Point(6, 0)
        Me.gb_mantenimiento.Name = "gb_mantenimiento"
        Me.gb_mantenimiento.Size = New System.Drawing.Size(1024, 768)
        Me.gb_mantenimiento.TabIndex = 0
        Me.gb_mantenimiento.TabStop = False
        '
        'lst_mantenimientos
        '
        Me.lst_mantenimientos.Location = New System.Drawing.Point(6, 176)
        Me.lst_mantenimientos.Name = "lst_mantenimientos"
        Me.lst_mantenimientos.Size = New System.Drawing.Size(1018, 574)
        Me.lst_mantenimientos.TabIndex = 1
        Me.lst_mantenimientos.UseCompatibleStateImageBehavior = False
        Me.lst_mantenimientos.View = System.Windows.Forms.View.Details
        '
        'gb_operaciones
        '
        Me.gb_operaciones.Controls.Add(Me.Button1)
        Me.gb_operaciones.Controls.Add(Me.btn_modificar_1folio)
        Me.gb_operaciones.Controls.Add(Me.btn_eliminar_manto)
        Me.gb_operaciones.Controls.Add(Me.Button3)
        Me.gb_operaciones.Controls.Add(Me.btn_reimpresion_folios)
        Me.gb_operaciones.Controls.Add(Me.btn_nuevo)
        Me.gb_operaciones.Controls.Add(Me.btn_salir)
        Me.gb_operaciones.Location = New System.Drawing.Point(6, 12)
        Me.gb_operaciones.Name = "gb_operaciones"
        Me.gb_operaciones.Size = New System.Drawing.Size(1012, 151)
        Me.gb_operaciones.TabIndex = 0
        Me.gb_operaciones.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(126, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 86)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Eliminacion masiva de productos y folios"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_modificar_1folio
        '
        Me.btn_modificar_1folio.Enabled = False
        Me.btn_modificar_1folio.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar_1folio.Image = CType(resources.GetObject("btn_modificar_1folio.Image"), System.Drawing.Image)
        Me.btn_modificar_1folio.Location = New System.Drawing.Point(10, 16)
        Me.btn_modificar_1folio.Name = "btn_modificar_1folio"
        Me.btn_modificar_1folio.Size = New System.Drawing.Size(110, 86)
        Me.btn_modificar_1folio.TabIndex = 18
        Me.btn_modificar_1folio.Text = "Modificar 1 folio"
        Me.btn_modificar_1folio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_modificar_1folio.UseVisualStyleBackColor = True
        '
        'btn_eliminar_manto
        '
        Me.btn_eliminar_manto.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar_manto.Image = CType(resources.GetObject("btn_eliminar_manto.Image"), System.Drawing.Image)
        Me.btn_eliminar_manto.Location = New System.Drawing.Point(493, 16)
        Me.btn_eliminar_manto.Name = "btn_eliminar_manto"
        Me.btn_eliminar_manto.Size = New System.Drawing.Size(110, 86)
        Me.btn_eliminar_manto.TabIndex = 11
        Me.btn_eliminar_manto.Text = "Eliminar Manto."
        Me.btn_eliminar_manto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_eliminar_manto.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(377, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 86)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "Impresion de corte caja z"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btn_reimpresion_folios
        '
        Me.btn_reimpresion_folios.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimpresion_folios.Image = CType(resources.GetObject("btn_reimpresion_folios.Image"), System.Drawing.Image)
        Me.btn_reimpresion_folios.Location = New System.Drawing.Point(261, 16)
        Me.btn_reimpresion_folios.Name = "btn_reimpresion_folios"
        Me.btn_reimpresion_folios.Size = New System.Drawing.Size(110, 86)
        Me.btn_reimpresion_folios.TabIndex = 11
        Me.btn_reimpresion_folios.Text = "Reimpresion de Folios"
        Me.btn_reimpresion_folios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_reimpresion_folios.UseVisualStyleBackColor = True
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(783, 16)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(110, 86)
        Me.btn_nuevo.TabIndex = 11
        Me.btn_nuevo.Text = "Exportar Excel"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(899, 16)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(104, 86)
        Me.btn_salir.TabIndex = 17
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'frm_bitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 790)
        Me.Controls.Add(Me.gb_mantenimiento)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_bitacora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bitácora de mantenimientos"
        Me.gb_mantenimiento.ResumeLayout(False)
        Me.gb_operaciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_mantenimiento As System.Windows.Forms.GroupBox
    Friend WithEvents gb_operaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents lst_mantenimientos As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_modificar_1folio As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btn_reimpresion_folios As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar_manto As System.Windows.Forms.Button

End Class
