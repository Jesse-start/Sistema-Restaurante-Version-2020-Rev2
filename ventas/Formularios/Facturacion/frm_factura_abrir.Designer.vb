<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_factura_abrir
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("")
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_fecha2 = New System.Windows.Forms.DateTimePicker()
        Me.tb_fecha1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.cb_tipo = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tb_anio = New System.Windows.Forms.NumericUpDown()
        Me.tb_numero = New System.Windows.Forms.TextBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.iconos = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lista_factura = New System.Windows.Forms.ListView()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.tb_anio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(337, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Mostrar:"
        '
        'lb_pagina_actual
        '
        Me.lb_pagina_actual.AutoSize = True
        Me.lb_pagina_actual.Location = New System.Drawing.Point(3, 6)
        Me.lb_pagina_actual.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_pagina_actual.Name = "lb_pagina_actual"
        Me.lb_pagina_actual.Size = New System.Drawing.Size(88, 13)
        Me.lb_pagina_actual.TabIndex = 15
        Me.lb_pagina_actual.Text = "lb_pagina_actual"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Location = New System.Drawing.Point(12, 461)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 25)
        Me.Panel2.TabIndex = 25
        '
        'pb_anterior
        '
        Me.pb_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_anterior.Location = New System.Drawing.Point(222, 5)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(13, 16)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_siguiente.Location = New System.Drawing.Point(291, 5)
        Me.pb_siguiente.Name = "pb_siguiente"
        Me.pb_siguiente.Size = New System.Drawing.Size(13, 16)
        Me.pb_siguiente.TabIndex = 2
        Me.pb_siguiente.TabStop = False
        '
        'tb_pagina
        '
        Me.tb_pagina.Location = New System.Drawing.Point(241, 3)
        Me.tb_pagina.Name = "tb_pagina"
        Me.tb_pagina.Size = New System.Drawing.Size(44, 20)
        Me.tb_pagina.TabIndex = 0
        '
        'tb_resultados
        '
        Me.tb_resultados.AutoSize = True
        Me.tb_resultados.BackColor = System.Drawing.SystemColors.Control
        Me.tb_resultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_resultados.Location = New System.Drawing.Point(103, 5)
        Me.tb_resultados.Margin = New System.Windows.Forms.Padding(0)
        Me.tb_resultados.Name = "tb_resultados"
        Me.tb_resultados.Size = New System.Drawing.Size(83, 13)
        Me.tb_resultados.TabIndex = 12
        Me.tb_resultados.Text = "tb_resultados"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.tb_fecha2)
        Me.Panel1.Controls.Add(Me.tb_fecha1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cb_cliente)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 77)
        Me.Panel1.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cliente:"
        '
        'tb_fecha2
        '
        Me.tb_fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tb_fecha2.Location = New System.Drawing.Point(169, 3)
        Me.tb_fecha2.Name = "tb_fecha2"
        Me.tb_fecha2.Size = New System.Drawing.Size(87, 20)
        Me.tb_fecha2.TabIndex = 2
        '
        'tb_fecha1
        '
        Me.tb_fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tb_fecha1.Location = New System.Drawing.Point(55, 3)
        Me.tb_fecha1.Name = "tb_fecha1"
        Me.tb_fecha1.Size = New System.Drawing.Size(87, 20)
        Me.tb_fecha1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(148, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "al"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Periodo:"
        '
        'cb_cliente
        '
        Me.cb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_cliente.Location = New System.Drawing.Point(55, 29)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(262, 21)
        Me.cb_cliente.TabIndex = 5
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.tb_resultados)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(141, -32)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 21)
        Me.FlowLayoutPanel1.TabIndex = 27
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(380, 461)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 26)
        Me.btn_aceptar.TabIndex = 19
        Me.btn_aceptar.Text = "Abrir"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'cb_tipo
        '
        Me.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tipo.FormattingEnabled = True
        Me.cb_tipo.Location = New System.Drawing.Point(402, 41)
        Me.cb_tipo.Name = "cb_tipo"
        Me.cb_tipo.Size = New System.Drawing.Size(131, 21)
        Me.cb_tipo.TabIndex = 28
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(67, 141)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(407, 48)
        Me.TextBox1.TabIndex = 26
        Me.TextBox1.Visible = False
        '
        'tb_anio
        '
        Me.tb_anio.Location = New System.Drawing.Point(402, 15)
        Me.tb_anio.Name = "tb_anio"
        Me.tb_anio.Size = New System.Drawing.Size(53, 20)
        Me.tb_anio.TabIndex = 23
        '
        'tb_numero
        '
        Me.tb_numero.Location = New System.Drawing.Point(461, 15)
        Me.tb_numero.Name = "tb_numero"
        Me.tb_numero.Size = New System.Drawing.Size(73, 20)
        Me.tb_numero.TabIndex = 22
        '
        'btn_cancelar
        '
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.Location = New System.Drawing.Point(459, 461)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 26)
        Me.btn_cancelar.TabIndex = 20
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'iconos
        '
        Me.iconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.iconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.iconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(337, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Factura:"
        '
        'lista_factura
        '
        Me.lista_factura.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lista_factura.HideSelection = False
        Me.lista_factura.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lista_factura.LargeImageList = Me.iconos
        Me.lista_factura.Location = New System.Drawing.Point(12, 95)
        Me.lista_factura.MultiSelect = False
        Me.lista_factura.Name = "lista_factura"
        Me.lista_factura.Size = New System.Drawing.Size(522, 360)
        Me.lista_factura.TabIndex = 18
        Me.lista_factura.UseCompatibleStateImageBehavior = False
        '
        'frm_factura_abrir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 517)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.cb_tipo)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.tb_anio)
        Me.Controls.Add(Me.tb_numero)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lista_factura)
        Me.Name = "frm_factura_abrir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abrir factura"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.tb_anio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents cb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents tb_anio As System.Windows.Forms.NumericUpDown
    Friend WithEvents tb_numero As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents iconos As System.Windows.Forms.ImageList
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lista_factura As System.Windows.Forms.ListView
End Class
