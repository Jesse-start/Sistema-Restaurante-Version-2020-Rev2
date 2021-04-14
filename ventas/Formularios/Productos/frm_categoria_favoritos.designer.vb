<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_categoria_favoritos
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_categoria_favoritos))
        Me.lista_cotizacion = New System.Windows.Forms.ListView()
        Me.iconos = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_quitar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_total_paginas = New System.Windows.Forms.Label()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_categoria = New System.Windows.Forms.ComboBox()
        Me.dgv_favoritos = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_favoritos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lista_cotizacion
        '
        Me.lista_cotizacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lista_cotizacion.HideSelection = False
        Me.lista_cotizacion.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lista_cotizacion.Location = New System.Drawing.Point(22, 133)
        Me.lista_cotizacion.Margin = New System.Windows.Forms.Padding(4)
        Me.lista_cotizacion.MultiSelect = False
        Me.lista_cotizacion.Name = "lista_cotizacion"
        Me.lista_cotizacion.Size = New System.Drawing.Size(377, 400)
        Me.lista_cotizacion.TabIndex = 0
        Me.lista_cotizacion.UseCompatibleStateImageBehavior = False
        Me.lista_cotizacion.View = System.Windows.Forms.View.Details
        '
        'iconos
        '
        Me.iconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.iconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.iconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_agregar
        '
        Me.btn_agregar.BackColor = System.Drawing.Color.White
        Me.btn_agregar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Image = CType(resources.GetObject("btn_agregar.Image"), System.Drawing.Image)
        Me.btn_agregar.Location = New System.Drawing.Point(407, 224)
        Me.btn_agregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(140, 60)
        Me.btn_agregar.TabIndex = 1
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
        Me.btn_quitar.Location = New System.Drawing.Point(407, 292)
        Me.btn_quitar.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(140, 60)
        Me.btn_quitar.TabIndex = 1
        Me.btn_quitar.Text = "Quitar"
        Me.btn_quitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_quitar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tb_buscar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(14, 50)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 76)
        Me.Panel1.TabIndex = 11
        '
        'tb_buscar
        '
        Me.tb_buscar.Location = New System.Drawing.Point(62, 16)
        Me.tb_buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_buscar.Multiline = True
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(323, 48)
        Me.tb_buscar.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Buscar:"
        '
        'tb_resultados
        '
        Me.tb_resultados.AutoSize = True
        Me.tb_resultados.BackColor = System.Drawing.SystemColors.Control
        Me.tb_resultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_resultados.Location = New System.Drawing.Point(17, 49)
        Me.tb_resultados.Margin = New System.Windows.Forms.Padding(0)
        Me.tb_resultados.Name = "tb_resultados"
        Me.tb_resultados.Size = New System.Drawing.Size(83, 13)
        Me.tb_resultados.TabIndex = 12
        Me.tb_resultados.Text = "tb_resultados"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tb_resultados)
        Me.Panel2.Controls.Add(Me.lb_total_paginas)
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Location = New System.Drawing.Point(25, 541)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(374, 77)
        Me.Panel2.TabIndex = 13
        '
        'lb_total_paginas
        '
        Me.lb_total_paginas.AutoSize = True
        Me.lb_total_paginas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_paginas.Location = New System.Drawing.Point(298, 8)
        Me.lb_total_paginas.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_total_paginas.Name = "lb_total_paginas"
        Me.lb_total_paginas.Size = New System.Drawing.Size(25, 21)
        Me.lb_total_paginas.TabIndex = 16
        Me.lb_total_paginas.Text = "/x"
        '
        'lb_pagina_actual
        '
        Me.lb_pagina_actual.AutoSize = True
        Me.lb_pagina_actual.Location = New System.Drawing.Point(17, 9)
        Me.lb_pagina_actual.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_pagina_actual.Name = "lb_pagina_actual"
        Me.lb_pagina_actual.Size = New System.Drawing.Size(112, 17)
        Me.lb_pagina_actual.TabIndex = 15
        Me.lb_pagina_actual.Text = "lb_pagina_actual"
        '
        'pb_anterior
        '
        Me.pb_anterior.BackgroundImage = CType(resources.GetObject("pb_anterior.BackgroundImage"), System.Drawing.Image)
        Me.pb_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_anterior.Location = New System.Drawing.Point(198, 4)
        Me.pb_anterior.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(30, 30)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImage = CType(resources.GetObject("pb_siguiente.BackgroundImage"), System.Drawing.Image)
        Me.pb_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_siguiente.Location = New System.Drawing.Point(339, 4)
        Me.pb_siguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.pb_siguiente.Name = "pb_siguiente"
        Me.pb_siguiente.Size = New System.Drawing.Size(30, 30)
        Me.pb_siguiente.TabIndex = 2
        Me.pb_siguiente.TabStop = False
        '
        'tb_pagina
        '
        Me.tb_pagina.Location = New System.Drawing.Point(241, 7)
        Me.tb_pagina.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_pagina.Name = "tb_pagina"
        Me.tb_pagina.Size = New System.Drawing.Size(50, 22)
        Me.tb_pagina.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Categoria:"
        '
        'cb_categoria
        '
        Me.cb_categoria.FormattingEnabled = True
        Me.cb_categoria.Location = New System.Drawing.Point(97, 14)
        Me.cb_categoria.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_categoria.Name = "cb_categoria"
        Me.cb_categoria.Size = New System.Drawing.Size(302, 25)
        Me.cb_categoria.TabIndex = 19
        '
        'dgv_favoritos
        '
        Me.dgv_favoritos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_favoritos.Location = New System.Drawing.Point(7, 22)
        Me.dgv_favoritos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgv_favoritos.Name = "dgv_favoritos"
        Me.dgv_favoritos.Size = New System.Drawing.Size(354, 600)
        Me.dgv_favoritos.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(407, 360)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 60)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Guardar Cambios"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_favoritos)
        Me.GroupBox1.Location = New System.Drawing.Point(554, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 642)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Favoritos de la categoría"
        '
        'frm_categoria_favoritos
        '
        Me.AcceptButton = Me.btn_agregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_quitar
        Me.ClientSize = New System.Drawing.Size(933, 661)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cb_categoria)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_quitar)
        Me.Controls.Add(Me.lista_cotizacion)
        Me.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_categoria_favoritos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de favoritos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_favoritos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lista_cotizacion As System.Windows.Forms.ListView
    Friend WithEvents iconos As System.Windows.Forms.ImageList
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents btn_quitar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_favoritos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lb_total_paginas As Label
End Class
