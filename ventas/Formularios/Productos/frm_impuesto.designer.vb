<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_impuesto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_impuesto))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.tb_porcentaje = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_alias = New System.Windows.Forms.TextBox()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.tb_categoria = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.arbolCategorias = New System.Windows.Forms.TreeView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dg_impuesto = New System.Windows.Forms.DataGrid()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.toolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.m_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.m_guardar = New System.Windows.Forms.ToolStripButton()
        Me.m_editar = New System.Windows.Forms.ToolStripButton()
        Me.m_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.m_cancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_impuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.toolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ToolStrip1)
        Me.GroupBox2.Controls.Add(Me.tb_porcentaje)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tb_alias)
        Me.GroupBox2.Controls.Add(Me.tb_nombre)
        Me.GroupBox2.Location = New System.Drawing.Point(335, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 167)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agregar impuesto"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.SaveToolStripButton, Me.toolStripSeparator})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(294, 25)
        Me.ToolStrip1.TabIndex = 27
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'tb_porcentaje
        '
        Me.tb_porcentaje.Location = New System.Drawing.Point(86, 130)
        Me.tb_porcentaje.Name = "tb_porcentaje"
        Me.tb_porcentaje.Size = New System.Drawing.Size(195, 20)
        Me.tb_porcentaje.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Alias"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Porcentaje"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Nombre"
        '
        'tb_alias
        '
        Me.tb_alias.Location = New System.Drawing.Point(86, 91)
        Me.tb_alias.Name = "tb_alias"
        Me.tb_alias.Size = New System.Drawing.Size(195, 20)
        Me.tb_alias.TabIndex = 2
        '
        'tb_nombre
        '
        Me.tb_nombre.Location = New System.Drawing.Point(86, 54)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(195, 20)
        Me.tb_nombre.TabIndex = 1
        '
        'tb_categoria
        '
        Me.tb_categoria.Location = New System.Drawing.Point(17, 357)
        Me.tb_categoria.Name = "tb_categoria"
        Me.tb_categoria.Size = New System.Drawing.Size(272, 20)
        Me.tb_categoria.TabIndex = 11
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(119, 396)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Actualizar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'arbolCategorias
        '
        Me.arbolCategorias.Location = New System.Drawing.Point(17, 55)
        Me.arbolCategorias.Name = "arbolCategorias"
        Me.arbolCategorias.Size = New System.Drawing.Size(272, 283)
        Me.arbolCategorias.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(193, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 22)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Contraer"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Expandir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.dg_impuesto)
        Me.GroupBox3.Location = New System.Drawing.Point(335, 213)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(300, 260)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Impuestos"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(171, 223)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "Quitar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dg_impuesto
        '
        Me.dg_impuesto.DataMember = ""
        Me.dg_impuesto.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_impuesto.Location = New System.Drawing.Point(12, 19)
        Me.dg_impuesto.Name = "dg_impuesto"
        Me.dg_impuesto.Size = New System.Drawing.Size(269, 185)
        Me.dg_impuesto.TabIndex = 22
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(17, 396)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 13
        Me.Button8.Text = "Agregar"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Controls.Add(Me.arbolCategorias)
        Me.GroupBox4.Controls.Add(Me.tb_categoria)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(312, 433)
        Me.GroupBox4.TabIndex = 22
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Categoria"
        '
        'toolStrip2
        '
        Me.toolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.m_nuevo, Me.m_guardar, Me.m_editar, Me.m_eliminar, Me.m_cancelar})
        Me.toolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip2.Name = "toolStrip2"
        Me.toolStrip2.Size = New System.Drawing.Size(647, 25)
        Me.toolStrip2.TabIndex = 24
        Me.toolStrip2.Text = "toolStrip2"
        '
        'm_nuevo
        '
        Me.m_nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.m_nuevo.Image = CType(resources.GetObject("m_nuevo.Image"), System.Drawing.Image)
        Me.m_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_nuevo.Name = "m_nuevo"
        Me.m_nuevo.Size = New System.Drawing.Size(23, 22)
        Me.m_nuevo.Text = "&New"
        '
        'm_guardar
        '
        Me.m_guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.m_guardar.Enabled = False
        Me.m_guardar.Image = CType(resources.GetObject("m_guardar.Image"), System.Drawing.Image)
        Me.m_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_guardar.Name = "m_guardar"
        Me.m_guardar.Size = New System.Drawing.Size(23, 22)
        Me.m_guardar.Text = "&Save"
        '
        'm_editar
        '
        Me.m_editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.m_editar.Image = CType(resources.GetObject("m_editar.Image"), System.Drawing.Image)
        Me.m_editar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_editar.Name = "m_editar"
        Me.m_editar.Size = New System.Drawing.Size(41, 22)
        Me.m_editar.Text = "editar"
        '
        'm_eliminar
        '
        Me.m_eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.m_eliminar.Image = CType(resources.GetObject("m_eliminar.Image"), System.Drawing.Image)
        Me.m_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_eliminar.Name = "m_eliminar"
        Me.m_eliminar.Size = New System.Drawing.Size(54, 22)
        Me.m_eliminar.Text = "eliminar"
        '
        'm_cancelar
        '
        Me.m_cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.m_cancelar.Image = CType(resources.GetObject("m_cancelar.Image"), System.Drawing.Image)
        Me.m_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_cancelar.Name = "m_cancelar"
        Me.m_cancelar.Size = New System.Drawing.Size(55, 22)
        Me.m_cancelar.Text = "cancelar"
        Me.m_cancelar.Visible = False
        '
        'frm_impuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 535)
        Me.Controls.Add(Me.toolStrip2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frm_impuesto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impuestos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dg_impuesto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.toolStrip2.ResumeLayout(False)
        Me.toolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tb_categoria As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents arbolCategorias As System.Windows.Forms.TreeView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_alias As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dg_impuesto As System.Windows.Forms.DataGrid
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_porcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents toolStrip2 As System.Windows.Forms.ToolStrip
    Private WithEvents m_nuevo As System.Windows.Forms.ToolStripButton
    Private WithEvents m_guardar As System.Windows.Forms.ToolStripButton
    Private WithEvents m_editar As System.Windows.Forms.ToolStripButton
    Private WithEvents m_eliminar As System.Windows.Forms.ToolStripButton
    Private WithEvents m_cancelar As System.Windows.Forms.ToolStripButton
End Class
