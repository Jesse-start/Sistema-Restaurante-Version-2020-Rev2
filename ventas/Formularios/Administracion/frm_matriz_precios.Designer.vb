<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_matriz_precios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_matriz_precios))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.dgv_matriz_precios = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_marca = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_categoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_total_paginas = New System.Windows.Forms.Label()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_matriz_precios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.btn_guardar)
        Me.Panel1.Controls.Add(Me.btn_salir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 561)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 125)
        Me.Panel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(206, 47)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 66)
        Me.Button1.TabIndex = 106
        Me.Button1.Text = "Eliminar seleccionados"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(9, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(176, 71)
        Me.Button2.TabIndex = 105
        Me.Button2.Text = "Invertir Seleccion"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_guardar
        '
        Me.btn_guardar.BackColor = System.Drawing.Color.White
        Me.btn_guardar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(683, 43)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(124, 70)
        Me.btn_guardar.TabIndex = 104
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(813, 43)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(124, 70)
        Me.btn_salir.TabIndex = 104
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'dgv_matriz_precios
        '
        Me.dgv_matriz_precios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_matriz_precios.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_matriz_precios.Location = New System.Drawing.Point(0, 124)
        Me.dgv_matriz_precios.Name = "dgv_matriz_precios"
        Me.dgv_matriz_precios.Size = New System.Drawing.Size(946, 437)
        Me.dgv_matriz_precios.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(58, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 21)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Marca:"
        '
        'cb_marca
        '
        Me.cb_marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_marca.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_marca.FormattingEnabled = True
        Me.cb_marca.Location = New System.Drawing.Point(159, 84)
        Me.cb_marca.Name = "cb_marca"
        Me.cb_marca.Size = New System.Drawing.Size(336, 29)
        Me.cb_marca.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(58, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 21)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Categoria:"
        '
        'cb_categoria
        '
        Me.cb_categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_categoria.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_categoria.FormattingEnabled = True
        Me.cb_categoria.Location = New System.Drawing.Point(159, 50)
        Me.cb_categoria.Name = "cb_categoria"
        Me.cb_categoria.Size = New System.Drawing.Size(336, 29)
        Me.cb_categoria.TabIndex = 100
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 21)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Buscar Producto:"
        '
        'tb_buscar
        '
        Me.tb_buscar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_buscar.Location = New System.Drawing.Point(159, 17)
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(336, 27)
        Me.tb_buscar.TabIndex = 105
        '
        'btn_buscar
        '
        Me.btn_buscar.BackColor = System.Drawing.Color.White
        Me.btn_buscar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(517, 12)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(141, 67)
        Me.btn_buscar.TabIndex = 104
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_total_paginas)
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Location = New System.Drawing.Point(228, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(579, 39)
        Me.Panel2.TabIndex = 108
        '
        'lb_total_paginas
        '
        Me.lb_total_paginas.AutoSize = True
        Me.lb_total_paginas.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_total_paginas.Location = New System.Drawing.Point(325, 6)
        Me.lb_total_paginas.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_total_paginas.Name = "lb_total_paginas"
        Me.lb_total_paginas.Size = New System.Drawing.Size(25, 21)
        Me.lb_total_paginas.TabIndex = 17
        Me.lb_total_paginas.Text = "/x"
        '
        'lb_pagina_actual
        '
        Me.lb_pagina_actual.AutoSize = True
        Me.lb_pagina_actual.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_pagina_actual.Location = New System.Drawing.Point(6, 5)
        Me.lb_pagina_actual.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_pagina_actual.Name = "lb_pagina_actual"
        Me.lb_pagina_actual.Size = New System.Drawing.Size(149, 21)
        Me.lb_pagina_actual.TabIndex = 15
        Me.lb_pagina_actual.Text = "lb_pagina_actual"
        '
        'pb_anterior
        '
        Me.pb_anterior.BackgroundImage = CType(resources.GetObject("pb_anterior.BackgroundImage"), System.Drawing.Image)
        Me.pb_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_anterior.Location = New System.Drawing.Point(229, 0)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(30, 30)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImage = CType(resources.GetObject("pb_siguiente.BackgroundImage"), System.Drawing.Image)
        Me.pb_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb_siguiente.Location = New System.Drawing.Point(379, 0)
        Me.pb_siguiente.Name = "pb_siguiente"
        Me.pb_siguiente.Size = New System.Drawing.Size(30, 30)
        Me.pb_siguiente.TabIndex = 2
        Me.pb_siguiente.TabStop = False
        '
        'tb_pagina
        '
        Me.tb_pagina.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_pagina.Location = New System.Drawing.Point(278, 3)
        Me.tb_pagina.Name = "tb_pagina"
        Me.tb_pagina.Size = New System.Drawing.Size(44, 27)
        Me.tb_pagina.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.tb_resultados)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 6)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 30)
        Me.FlowLayoutPanel1.TabIndex = 107
        '
        'tb_resultados
        '
        Me.tb_resultados.AutoSize = True
        Me.tb_resultados.BackColor = System.Drawing.Color.Transparent
        Me.tb_resultados.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_resultados.Location = New System.Drawing.Point(72, 5)
        Me.tb_resultados.Margin = New System.Windows.Forms.Padding(0)
        Me.tb_resultados.Name = "tb_resultados"
        Me.tb_resultados.Size = New System.Drawing.Size(109, 19)
        Me.tb_resultados.TabIndex = 12
        Me.tb_resultados.Text = "tb_resultados"
        '
        'frm_matriz_precios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 686)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.tb_buscar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cb_marca)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb_categoria)
        Me.Controls.Add(Me.dgv_matriz_precios)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_matriz_precios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios de los productos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgv_matriz_precios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv_matriz_precios As System.Windows.Forms.DataGridView
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_marca As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_categoria As System.Windows.Forms.ComboBox
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lb_total_paginas As System.Windows.Forms.Label
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
End Class
