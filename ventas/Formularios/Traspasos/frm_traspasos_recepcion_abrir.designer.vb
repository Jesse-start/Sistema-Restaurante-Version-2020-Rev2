<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_traspasos_recepcion_abrir
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
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.cb_tipo = New System.Windows.Forms.ComboBox()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSucursales = New System.Windows.Forms.Label()
        Me.tb_fecha2 = New System.Windows.Forms.DateTimePicker()
        Me.tb_fecha1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_sucursales = New System.Windows.Forms.ComboBox()
        Me.tb_numero = New System.Windows.Forms.TextBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.iconos = New System.Windows.Forms.ImageList(Me.components)
        Me.lista_traspasos = New System.Windows.Forms.ListView()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb_pagina_actual
        '
        Me.lb_pagina_actual.AutoSize = True
        Me.lb_pagina_actual.Location = New System.Drawing.Point(4, 11)
        Me.lb_pagina_actual.Margin = New System.Windows.Forms.Padding(0)
        Me.lb_pagina_actual.Name = "lb_pagina_actual"
        Me.lb_pagina_actual.Size = New System.Drawing.Size(137, 20)
        Me.lb_pagina_actual.TabIndex = 15
        Me.lb_pagina_actual.Text = "lb_pagina_actual"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(420, 9)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(100, 20)
        Me.label3.TabIndex = 28
        Me.label3.Text = "No Traspaso:"
        '
        'tb_resultados
        '
        Me.tb_resultados.AutoSize = True
        Me.tb_resultados.BackColor = System.Drawing.Color.Transparent
        Me.tb_resultados.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_resultados.Location = New System.Drawing.Point(133, 5)
        Me.tb_resultados.Margin = New System.Windows.Forms.Padding(0)
        Me.tb_resultados.Name = "tb_resultados"
        Me.tb_resultados.Size = New System.Drawing.Size(106, 20)
        Me.tb_resultados.TabIndex = 12
        Me.tb_resultados.Text = "tb_resultados"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(16, 444)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 43)
        Me.Panel2.TabIndex = 24
        '
        'pb_anterior
        '
        Me.pb_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_anterior.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.pb_anterior.Location = New System.Drawing.Point(202, 17)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(15, 13)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_siguiente.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.pb_siguiente.Location = New System.Drawing.Point(311, 15)
        Me.pb_siguiente.Name = "pb_siguiente"
        Me.pb_siguiente.Size = New System.Drawing.Size(18, 14)
        Me.pb_siguiente.TabIndex = 2
        Me.pb_siguiente.TabStop = False
        '
        'tb_pagina
        '
        Me.tb_pagina.Location = New System.Drawing.Point(238, 11)
        Me.tb_pagina.Name = "tb_pagina"
        Me.tb_pagina.Size = New System.Drawing.Size(56, 26)
        Me.tb_pagina.TabIndex = 0
        '
        'cb_tipo
        '
        Me.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tipo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipo.FormattingEnabled = True
        Me.cb_tipo.Location = New System.Drawing.Point(529, 38)
        Me.cb_tipo.Name = "cb_tipo"
        Me.cb_tipo.Size = New System.Drawing.Size(131, 28)
        Me.cb_tipo.TabIndex = 26
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Location = New System.Drawing.Point(421, 449)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(119, 38)
        Me.btn_aceptar.TabIndex = 21
        Me.btn_aceptar.Text = "Abrir"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(417, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 20)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Mostrar:"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.tb_resultados)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(421, 72)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(239, 35)
        Me.FlowLayoutPanel1.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblSucursales)
        Me.Panel1.Controls.Add(Me.tb_fecha2)
        Me.Panel1.Controls.Add(Me.tb_fecha1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cb_sucursales)
        Me.Panel1.Location = New System.Drawing.Point(14, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 95)
        Me.Panel1.TabIndex = 23
        '
        'lblSucursales
        '
        Me.lblSucursales.AutoSize = True
        Me.lblSucursales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursales.Location = New System.Drawing.Point(6, 63)
        Me.lblSucursales.Name = "lblSucursales"
        Me.lblSucursales.Size = New System.Drawing.Size(88, 20)
        Me.lblSucursales.TabIndex = 6
        Me.lblSucursales.Text = "Sucursales:"
        '
        'tb_fecha2
        '
        Me.tb_fecha2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tb_fecha2.Location = New System.Drawing.Point(266, 23)
        Me.tb_fecha2.Name = "tb_fecha2"
        Me.tb_fecha2.Size = New System.Drawing.Size(119, 26)
        Me.tb_fecha2.TabIndex = 2
        '
        'tb_fecha1
        '
        Me.tb_fecha1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tb_fecha1.Location = New System.Drawing.Point(104, 23)
        Me.tb_fecha1.Name = "tb_fecha1"
        Me.tb_fecha1.Size = New System.Drawing.Size(115, 26)
        Me.tb_fecha1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(225, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "al"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Periodo:"
        '
        'cb_sucursales
        '
        Me.cb_sucursales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_sucursales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_sucursales.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sucursales.Location = New System.Drawing.Point(105, 60)
        Me.cb_sucursales.Name = "cb_sucursales"
        Me.cb_sucursales.Size = New System.Drawing.Size(289, 28)
        Me.cb_sucursales.TabIndex = 5
        '
        'tb_numero
        '
        Me.tb_numero.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_numero.Location = New System.Drawing.Point(529, 6)
        Me.tb_numero.Name = "tb_numero"
        Me.tb_numero.Size = New System.Drawing.Size(131, 26)
        Me.tb_numero.TabIndex = 22
        '
        'btn_cancelar
        '
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Location = New System.Drawing.Point(546, 449)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(116, 38)
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
        'lista_traspasos
        '
        Me.lista_traspasos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lista_traspasos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lista_traspasos.HideSelection = False
        Me.lista_traspasos.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lista_traspasos.LargeImageList = Me.iconos
        Me.lista_traspasos.Location = New System.Drawing.Point(14, 113)
        Me.lista_traspasos.MultiSelect = False
        Me.lista_traspasos.Name = "lista_traspasos"
        Me.lista_traspasos.Size = New System.Drawing.Size(646, 325)
        Me.lista_traspasos.TabIndex = 19
        Me.lista_traspasos.UseCompatibleStateImageBehavior = False
        '
        'frm_traspasos_recepcion_abrir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 493)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cb_tipo)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tb_numero)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.lista_traspasos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_traspasos_recepcion_abrir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abrir Traspaso(recepción)"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents cb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSucursales As System.Windows.Forms.Label
    Friend WithEvents tb_fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_sucursales As System.Windows.Forms.ComboBox
    Friend WithEvents tb_numero As System.Windows.Forms.TextBox
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents iconos As System.Windows.Forms.ImageList
    Friend WithEvents lista_traspasos As System.Windows.Forms.ListView
End Class
