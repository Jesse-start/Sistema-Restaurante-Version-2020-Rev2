<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cuentas_xpagar_anterior
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gb_pago = New System.Windows.Forms.GroupBox()
        Me.dtp_fecha_pago = New System.Windows.Forms.DateTimePicker()
        Me.lbl_cantidad = New System.Windows.Forms.Label()
        Me.label11 = New System.Windows.Forms.Label()
        Me.tb_cantidad = New System.Windows.Forms.TextBox()
        Me.Pagos = New System.Windows.Forms.Panel()
        Me.tc_pagos = New System.Windows.Forms.TabControl()
        Me.Seleccion_pago = New System.Windows.Forms.TabPage()
        Me.btn_pagar = New System.Windows.Forms.Button()
        Me.dtp_fac_vencidas = New System.Windows.Forms.DateTimePicker()
        Me.rb_fact_vencidas = New System.Windows.Forms.RadioButton()
        Me.dgv_pagos = New System.Windows.Forms.DataGridView()
        Me.rb_todas = New System.Windows.Forms.RadioButton()
        Me.lbl_nombre = New System.Windows.Forms.Label()
        Me.cb_proveedor = New System.Windows.Forms.ComboBox()
        Me.gb_pago.SuspendLayout()
        Me.Pagos.SuspendLayout()
        Me.tc_pagos.SuspendLayout()
        Me.Seleccion_pago.SuspendLayout()
        CType(Me.dgv_pagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_pago
        '
        Me.gb_pago.Controls.Add(Me.dtp_fecha_pago)
        Me.gb_pago.Controls.Add(Me.lbl_cantidad)
        Me.gb_pago.Controls.Add(Me.label11)
        Me.gb_pago.Controls.Add(Me.tb_cantidad)
        Me.gb_pago.Location = New System.Drawing.Point(732, 26)
        Me.gb_pago.Name = "gb_pago"
        Me.gb_pago.Size = New System.Drawing.Size(181, 81)
        Me.gb_pago.TabIndex = 44
        Me.gb_pago.TabStop = False
        Me.gb_pago.Text = "Método de Pago:"
        Me.gb_pago.Visible = False
        '
        'dtp_fecha_pago
        '
        Me.dtp_fecha_pago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_pago.Location = New System.Drawing.Point(74, 22)
        Me.dtp_fecha_pago.Name = "dtp_fecha_pago"
        Me.dtp_fecha_pago.Size = New System.Drawing.Size(98, 23)
        Me.dtp_fecha_pago.TabIndex = 41
        '
        'lbl_cantidad
        '
        Me.lbl_cantidad.AutoSize = True
        Me.lbl_cantidad.Location = New System.Drawing.Point(6, 54)
        Me.lbl_cantidad.Name = "lbl_cantidad"
        Me.lbl_cantidad.Size = New System.Drawing.Size(86, 17)
        Me.lbl_cantidad.TabIndex = 38
        Me.lbl_cantidad.Text = "Cantidad $:"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(14, 25)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(51, 17)
        Me.label11.TabIndex = 40
        Me.label11.Text = "Fecha:"
        '
        'tb_cantidad
        '
        Me.tb_cantidad.Location = New System.Drawing.Point(98, 48)
        Me.tb_cantidad.Name = "tb_cantidad"
        Me.tb_cantidad.Size = New System.Drawing.Size(74, 23)
        Me.tb_cantidad.TabIndex = 39
        Me.tb_cantidad.Text = "0.00"
        '
        'Pagos
        '
        Me.Pagos.Controls.Add(Me.tc_pagos)
        Me.Pagos.Location = New System.Drawing.Point(12, 53)
        Me.Pagos.Name = "Pagos"
        Me.Pagos.Size = New System.Drawing.Size(968, 483)
        Me.Pagos.TabIndex = 43
        '
        'tc_pagos
        '
        Me.tc_pagos.Controls.Add(Me.Seleccion_pago)
        Me.tc_pagos.Location = New System.Drawing.Point(12, 8)
        Me.tc_pagos.Name = "tc_pagos"
        Me.tc_pagos.SelectedIndex = 0
        Me.tc_pagos.Size = New System.Drawing.Size(953, 472)
        Me.tc_pagos.TabIndex = 15
        '
        'Seleccion_pago
        '
        Me.Seleccion_pago.BackColor = System.Drawing.Color.Transparent
        Me.Seleccion_pago.Controls.Add(Me.btn_pagar)
        Me.Seleccion_pago.Controls.Add(Me.dtp_fac_vencidas)
        Me.Seleccion_pago.Controls.Add(Me.gb_pago)
        Me.Seleccion_pago.Controls.Add(Me.rb_fact_vencidas)
        Me.Seleccion_pago.Controls.Add(Me.dgv_pagos)
        Me.Seleccion_pago.Controls.Add(Me.rb_todas)
        Me.Seleccion_pago.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seleccion_pago.Location = New System.Drawing.Point(4, 22)
        Me.Seleccion_pago.Name = "Seleccion_pago"
        Me.Seleccion_pago.Padding = New System.Windows.Forms.Padding(3)
        Me.Seleccion_pago.Size = New System.Drawing.Size(945, 446)
        Me.Seleccion_pago.TabIndex = 0
        Me.Seleccion_pago.Text = "Selección de Pago"
        '
        'btn_pagar
        '
        Me.btn_pagar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pagar.Location = New System.Drawing.Point(809, 382)
        Me.btn_pagar.Name = "btn_pagar"
        Me.btn_pagar.Size = New System.Drawing.Size(113, 58)
        Me.btn_pagar.TabIndex = 20
        Me.btn_pagar.Text = "PAGAR"
        Me.btn_pagar.UseVisualStyleBackColor = True
        '
        'dtp_fac_vencidas
        '
        Me.dtp_fac_vencidas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fac_vencidas.Location = New System.Drawing.Point(264, 420)
        Me.dtp_fac_vencidas.Name = "dtp_fac_vencidas"
        Me.dtp_fac_vencidas.Size = New System.Drawing.Size(110, 23)
        Me.dtp_fac_vencidas.TabIndex = 19
        Me.dtp_fac_vencidas.Visible = False
        '
        'rb_fact_vencidas
        '
        Me.rb_fact_vencidas.AutoSize = True
        Me.rb_fact_vencidas.Location = New System.Drawing.Point(147, 423)
        Me.rb_fact_vencidas.Name = "rb_fact_vencidas"
        Me.rb_fact_vencidas.Size = New System.Drawing.Size(143, 21)
        Me.rb_fact_vencidas.TabIndex = 17
        Me.rb_fact_vencidas.Text = "Vencidas a fecha:"
        Me.rb_fact_vencidas.UseVisualStyleBackColor = True
        Me.rb_fact_vencidas.Visible = False
        '
        'dgv_pagos
        '
        Me.dgv_pagos.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_pagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_pagos.Location = New System.Drawing.Point(22, 7)
        Me.dgv_pagos.Name = "dgv_pagos"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_pagos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_pagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_pagos.Size = New System.Drawing.Size(917, 369)
        Me.dgv_pagos.TabIndex = 1
        '
        'rb_todas
        '
        Me.rb_todas.AutoSize = True
        Me.rb_todas.Location = New System.Drawing.Point(44, 423)
        Me.rb_todas.Name = "rb_todas"
        Me.rb_todas.Size = New System.Drawing.Size(63, 21)
        Me.rb_todas.TabIndex = 16
        Me.rb_todas.Text = "Todas"
        Me.rb_todas.UseVisualStyleBackColor = True
        Me.rb_todas.Visible = False
        '
        'lbl_nombre
        '
        Me.lbl_nombre.AutoSize = True
        Me.lbl_nombre.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre.Location = New System.Drawing.Point(23, 22)
        Me.lbl_nombre.Name = "lbl_nombre"
        Me.lbl_nombre.Size = New System.Drawing.Size(92, 20)
        Me.lbl_nombre.TabIndex = 45
        Me.lbl_nombre.Text = "Proveedor:"
        '
        'cb_proveedor
        '
        Me.cb_proveedor.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_proveedor.FormattingEnabled = True
        Me.cb_proveedor.Location = New System.Drawing.Point(121, 19)
        Me.cb_proveedor.Name = "cb_proveedor"
        Me.cb_proveedor.Size = New System.Drawing.Size(665, 28)
        Me.cb_proveedor.TabIndex = 46
        '
        'frm_cuentas_xpagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 548)
        Me.Controls.Add(Me.cb_proveedor)
        Me.Controls.Add(Me.lbl_nombre)
        Me.Controls.Add(Me.Pagos)
        Me.Name = "frm_cuentas_xpagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por pagar"
        Me.gb_pago.ResumeLayout(False)
        Me.gb_pago.PerformLayout()
        Me.Pagos.ResumeLayout(False)
        Me.tc_pagos.ResumeLayout(False)
        Me.Seleccion_pago.ResumeLayout(False)
        Me.Seleccion_pago.PerformLayout()
        CType(Me.dgv_pagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents gb_pago As System.Windows.Forms.GroupBox
    Private WithEvents dtp_fecha_pago As System.Windows.Forms.DateTimePicker
    Private WithEvents lbl_cantidad As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents tb_cantidad As System.Windows.Forms.TextBox
    Private WithEvents Pagos As System.Windows.Forms.Panel
    Private WithEvents tc_pagos As System.Windows.Forms.TabControl
    Private WithEvents Seleccion_pago As System.Windows.Forms.TabPage
    Private WithEvents dtp_fac_vencidas As System.Windows.Forms.DateTimePicker
    Private WithEvents rb_fact_vencidas As System.Windows.Forms.RadioButton
    Private WithEvents dgv_pagos As System.Windows.Forms.DataGridView
    Private WithEvents rb_todas As System.Windows.Forms.RadioButton
    Private WithEvents lbl_nombre As System.Windows.Forms.Label
    Friend WithEvents cb_proveedor As System.Windows.Forms.ComboBox
    Friend WithEvents btn_pagar As System.Windows.Forms.Button
End Class
