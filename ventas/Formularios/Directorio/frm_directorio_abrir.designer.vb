<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_directorio_abrir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_directorio_abrir))
        Me.lista_cotizacion = New System.Windows.Forms.ListView()
        Me.iconos = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.tb_buscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_resultados = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lb_pagina_actual = New System.Windows.Forms.Label()
        Me.pb_anterior = New System.Windows.Forms.PictureBox()
        Me.pb_siguiente = New System.Windows.Forms.PictureBox()
        Me.tb_pagina = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cb_tipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gb_clase = New System.Windows.Forms.GroupBox()
        Me.rb_proveedor = New System.Windows.Forms.RadioButton()
        Me.rb_empleado = New System.Windows.Forms.RadioButton()
        Me.rb_cliente = New System.Windows.Forms.RadioButton()
        Me.rb_fisica = New System.Windows.Forms.RadioButton()
        Me.rb_moral = New System.Windows.Forms.RadioButton()
        Me.gb_tipo = New System.Windows.Forms.GroupBox()
        Me.Panel2.SuspendLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.gb_clase.SuspendLayout()
        Me.gb_tipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lista_cotizacion
        '
        Me.lista_cotizacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lista_cotizacion.HideSelection = False
        Me.lista_cotizacion.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lista_cotizacion.LargeImageList = Me.iconos
        Me.lista_cotizacion.Location = New System.Drawing.Point(12, 121)
        Me.lista_cotizacion.MultiSelect = False
        Me.lista_cotizacion.Name = "lista_cotizacion"
        Me.lista_cotizacion.Size = New System.Drawing.Size(522, 313)
        Me.lista_cotizacion.TabIndex = 0
        Me.lista_cotizacion.UseCompatibleStateImageBehavior = False
        '
        'iconos
        '
        Me.iconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.iconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.iconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(380, 440)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 26)
        Me.btn_aceptar.TabIndex = 1
        Me.btn_aceptar.Text = "Abrir"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_cancelar.Location = New System.Drawing.Point(459, 440)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 26)
        Me.btn_cancelar.TabIndex = 1
        Me.btn_cancelar.Text = "Cerrar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'tb_buscar
        '
        Me.tb_buscar.Location = New System.Drawing.Point(58, 67)
        Me.tb_buscar.Multiline = True
        Me.tb_buscar.Name = "tb_buscar"
        Me.tb_buscar.Size = New System.Drawing.Size(280, 38)
        Me.tb_buscar.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Buscar:"
        '
        'tb_resultados
        '
        Me.tb_resultados.AutoSize = True
        Me.tb_resultados.BackColor = System.Drawing.SystemColors.Control
        Me.tb_resultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_resultados.Location = New System.Drawing.Point(100, 4)
        Me.tb_resultados.Margin = New System.Windows.Forms.Padding(3, 4, 3, 0)
        Me.tb_resultados.Name = "tb_resultados"
        Me.tb_resultados.Size = New System.Drawing.Size(83, 13)
        Me.tb_resultados.TabIndex = 12
        Me.tb_resultados.Text = "tb_resultados"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lb_pagina_actual)
        Me.Panel2.Controls.Add(Me.pb_anterior)
        Me.Panel2.Controls.Add(Me.pb_siguiente)
        Me.Panel2.Controls.Add(Me.tb_pagina)
        Me.Panel2.Location = New System.Drawing.Point(12, 440)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(360, 25)
        Me.Panel2.TabIndex = 13
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
        'pb_anterior
        '
        Me.pb_anterior.BackgroundImage = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.pb_anterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_anterior.Location = New System.Drawing.Point(222, 5)
        Me.pb_anterior.Name = "pb_anterior"
        Me.pb_anterior.Size = New System.Drawing.Size(13, 16)
        Me.pb_anterior.TabIndex = 2
        Me.pb_anterior.TabStop = False
        '
        'pb_siguiente
        '
        Me.pb_siguiente.BackgroundImage = Global.ventas.My.Resources.Resources._50CENTAVOS
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.tb_resultados)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(347, 94)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(186, 21)
        Me.FlowLayoutPanel1.TabIndex = 15
        '
        'cb_tipo
        '
        Me.cb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tipo.FormattingEnabled = True
        Me.cb_tipo.Location = New System.Drawing.Point(403, 67)
        Me.cb_tipo.Name = "cb_tipo"
        Me.cb_tipo.Size = New System.Drawing.Size(131, 21)
        Me.cb_tipo.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(352, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Mostrar:"
        '
        'gb_clase
        '
        Me.gb_clase.Controls.Add(Me.rb_proveedor)
        Me.gb_clase.Controls.Add(Me.rb_empleado)
        Me.gb_clase.Controls.Add(Me.rb_cliente)
        Me.gb_clase.Location = New System.Drawing.Point(12, 15)
        Me.gb_clase.Name = "gb_clase"
        Me.gb_clase.Size = New System.Drawing.Size(326, 46)
        Me.gb_clase.TabIndex = 9
        Me.gb_clase.TabStop = False
        Me.gb_clase.Text = "Seleccionar tipo de persona"
        '
        'rb_proveedor
        '
        Me.rb_proveedor.AutoSize = True
        Me.rb_proveedor.Location = New System.Drawing.Point(125, 22)
        Me.rb_proveedor.Name = "rb_proveedor"
        Me.rb_proveedor.Size = New System.Drawing.Size(74, 17)
        Me.rb_proveedor.TabIndex = 2
        Me.rb_proveedor.Text = "Proveedor"
        Me.rb_proveedor.UseVisualStyleBackColor = True
        '
        'rb_empleado
        '
        Me.rb_empleado.AutoSize = True
        Me.rb_empleado.Checked = True
        Me.rb_empleado.Location = New System.Drawing.Point(241, 22)
        Me.rb_empleado.Name = "rb_empleado"
        Me.rb_empleado.Size = New System.Drawing.Size(72, 17)
        Me.rb_empleado.TabIndex = 1
        Me.rb_empleado.TabStop = True
        Me.rb_empleado.Text = "Empleado"
        Me.rb_empleado.UseVisualStyleBackColor = True
        '
        'rb_cliente
        '
        Me.rb_cliente.AutoSize = True
        Me.rb_cliente.Location = New System.Drawing.Point(15, 22)
        Me.rb_cliente.Name = "rb_cliente"
        Me.rb_cliente.Size = New System.Drawing.Size(57, 17)
        Me.rb_cliente.TabIndex = 0
        Me.rb_cliente.Text = "Cliente"
        Me.rb_cliente.UseVisualStyleBackColor = True
        '
        'rb_fisica
        '
        Me.rb_fisica.AutoSize = True
        Me.rb_fisica.Location = New System.Drawing.Point(84, 20)
        Me.rb_fisica.Name = "rb_fisica"
        Me.rb_fisica.Size = New System.Drawing.Size(54, 17)
        Me.rb_fisica.TabIndex = 4
        Me.rb_fisica.Text = "Física"
        Me.rb_fisica.UseVisualStyleBackColor = True
        '
        'rb_moral
        '
        Me.rb_moral.AutoSize = True
        Me.rb_moral.Location = New System.Drawing.Point(15, 20)
        Me.rb_moral.Name = "rb_moral"
        Me.rb_moral.Size = New System.Drawing.Size(51, 17)
        Me.rb_moral.TabIndex = 3
        Me.rb_moral.Text = "Moral"
        Me.rb_moral.UseVisualStyleBackColor = True
        '
        'gb_tipo
        '
        Me.gb_tipo.Controls.Add(Me.rb_moral)
        Me.gb_tipo.Controls.Add(Me.rb_fisica)
        Me.gb_tipo.Location = New System.Drawing.Point(348, 15)
        Me.gb_tipo.Name = "gb_tipo"
        Me.gb_tipo.Size = New System.Drawing.Size(186, 43)
        Me.gb_tipo.TabIndex = 10
        Me.gb_tipo.TabStop = False
        Me.gb_tipo.Text = "Tipo"
        '
        'frm_directorio_abrir
        '
        Me.AcceptButton = Me.btn_aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_cancelar
        Me.ClientSize = New System.Drawing.Size(545, 471)
        Me.Controls.Add(Me.gb_clase)
        Me.Controls.Add(Me.tb_buscar)
        Me.Controls.Add(Me.gb_tipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cb_tipo)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.lista_cotizacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_directorio_abrir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Directorio"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pb_anterior, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_siguiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.gb_clase.ResumeLayout(False)
        Me.gb_clase.PerformLayout()
        Me.gb_tipo.ResumeLayout(False)
        Me.gb_tipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lista_cotizacion As System.Windows.Forms.ListView
    Friend WithEvents iconos As System.Windows.Forms.ImageList
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents tb_resultados As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb_siguiente As System.Windows.Forms.PictureBox
    Friend WithEvents tb_pagina As System.Windows.Forms.TextBox
    Friend WithEvents pb_anterior As System.Windows.Forms.PictureBox
    Friend WithEvents lb_pagina_actual As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cb_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_buscar As System.Windows.Forms.TextBox
    Friend WithEvents gb_clase As System.Windows.Forms.GroupBox
    Friend WithEvents rb_proveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rb_empleado As System.Windows.Forms.RadioButton
    Friend WithEvents rb_cliente As System.Windows.Forms.RadioButton
    Friend WithEvents rb_fisica As System.Windows.Forms.RadioButton
    Friend WithEvents rb_moral As System.Windows.Forms.RadioButton
    Friend WithEvents gb_tipo As System.Windows.Forms.GroupBox
End Class
