<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cuentas_banco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cuentas_banco))
        Me.menu_principal = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_editar = New System.Windows.Forms.ToolStripButton()
        Me.btn_guardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_cancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_cuenta = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.label44 = New System.Windows.Forms.Label()
        Me.cb_banco = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha_apertura = New System.Windows.Forms.DateTimePicker()
        Me.tb_saldo = New System.Windows.Forms.TextBox()
        Me.tb_num_cheque = New System.Windows.Forms.TextBox()
        Me.tb_nip_audiomatico = New System.Windows.Forms.TextBox()
        Me.tb_nip_fiscal = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.tb_sucursal = New System.Windows.Forms.TextBox()
        Me.tb_contrato = New System.Windows.Forms.TextBox()
        Me.tb_num_cliente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.menu_principal.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menu_principal
        '
        Me.menu_principal.BackColor = System.Drawing.SystemColors.Control
        Me.menu_principal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevo, Me.btn_editar, Me.btn_guardar, Me.btn_eliminar, Me.ToolStripSeparator1, Me.btn_cancelar})
        Me.menu_principal.Location = New System.Drawing.Point(0, 0)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(435, 25)
        Me.menu_principal.TabIndex = 31
        Me.menu_principal.Text = "ToolStrip1"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.AutoToolTip = False
        Me.btn_nuevo.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(62, 22)
        Me.btn_nuevo.Text = "&Nuevo"
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(57, 22)
        Me.btn_editar.Text = "Editar"
        '
        'btn_guardar
        '
        Me.btn_guardar.AutoToolTip = False
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(69, 22)
        Me.btn_guardar.Text = "&Guardar"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.AutoToolTip = False
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(70, 22)
        Me.btn_eliminar.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btn_cancelar
        '
        Me.btn_cancelar.AutoToolTip = False
        Me.btn_cancelar.Enabled = False
        Me.btn_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(57, 22)
        Me.btn_cancelar.Text = "Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_cuenta)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.label44)
        Me.GroupBox1.Controls.Add(Me.cb_banco)
        Me.GroupBox1.Controls.Add(Me.dtp_fecha_apertura)
        Me.GroupBox1.Controls.Add(Me.tb_saldo)
        Me.GroupBox1.Controls.Add(Me.tb_num_cheque)
        Me.GroupBox1.Controls.Add(Me.tb_nip_audiomatico)
        Me.GroupBox1.Controls.Add(Me.tb_nip_fiscal)
        Me.GroupBox1.Controls.Add(Me.TextBox9)
        Me.GroupBox1.Controls.Add(Me.tb_sucursal)
        Me.GroupBox1.Controls.Add(Me.tb_contrato)
        Me.GroupBox1.Controls.Add(Me.tb_num_cliente)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 407)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cuentas Bancarias"
        '
        'cb_cuenta
        '
        Me.cb_cuenta.FormattingEnabled = True
        Me.cb_cuenta.Location = New System.Drawing.Point(118, 30)
        Me.cb_cuenta.Name = "cb_cuenta"
        Me.cb_cuenta.Size = New System.Drawing.Size(252, 21)
        Me.cb_cuenta.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(6, 247)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 20)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(6, 270)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 20)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(6, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 20)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(6, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 20)
        Me.Label11.TabIndex = 47
        Me.Label11.Text = "*"
        '
        'label44
        '
        Me.label44.AutoSize = True
        Me.label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.label44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label44.Location = New System.Drawing.Point(6, 36)
        Me.label44.Name = "label44"
        Me.label44.Size = New System.Drawing.Size(15, 20)
        Me.label44.TabIndex = 47
        Me.label44.Text = "*"
        '
        'cb_banco
        '
        Me.cb_banco.FormattingEnabled = True
        Me.cb_banco.Location = New System.Drawing.Point(118, 57)
        Me.cb_banco.Name = "cb_banco"
        Me.cb_banco.Size = New System.Drawing.Size(252, 21)
        Me.cb_banco.TabIndex = 3
        '
        'dtp_fecha_apertura
        '
        Me.dtp_fecha_apertura.Location = New System.Drawing.Point(118, 164)
        Me.dtp_fecha_apertura.Name = "dtp_fecha_apertura"
        Me.dtp_fecha_apertura.Size = New System.Drawing.Size(251, 20)
        Me.dtp_fecha_apertura.TabIndex = 2
        '
        'tb_saldo
        '
        Me.tb_saldo.Location = New System.Drawing.Point(116, 268)
        Me.tb_saldo.Name = "tb_saldo"
        Me.tb_saldo.Size = New System.Drawing.Size(252, 20)
        Me.tb_saldo.TabIndex = 1
        '
        'tb_num_cheque
        '
        Me.tb_num_cheque.Location = New System.Drawing.Point(116, 242)
        Me.tb_num_cheque.Name = "tb_num_cheque"
        Me.tb_num_cheque.Size = New System.Drawing.Size(252, 20)
        Me.tb_num_cheque.TabIndex = 1
        '
        'tb_nip_audiomatico
        '
        Me.tb_nip_audiomatico.Location = New System.Drawing.Point(116, 190)
        Me.tb_nip_audiomatico.Name = "tb_nip_audiomatico"
        Me.tb_nip_audiomatico.Size = New System.Drawing.Size(252, 20)
        Me.tb_nip_audiomatico.TabIndex = 1
        '
        'tb_nip_fiscal
        '
        Me.tb_nip_fiscal.Location = New System.Drawing.Point(117, 216)
        Me.tb_nip_fiscal.Name = "tb_nip_fiscal"
        Me.tb_nip_fiscal.Size = New System.Drawing.Size(252, 20)
        Me.tb_nip_fiscal.TabIndex = 1
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(117, 190)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(252, 20)
        Me.TextBox9.TabIndex = 1
        '
        'tb_sucursal
        '
        Me.tb_sucursal.Location = New System.Drawing.Point(118, 136)
        Me.tb_sucursal.Name = "tb_sucursal"
        Me.tb_sucursal.Size = New System.Drawing.Size(252, 20)
        Me.tb_sucursal.TabIndex = 1
        '
        'tb_contrato
        '
        Me.tb_contrato.Location = New System.Drawing.Point(118, 84)
        Me.tb_contrato.Name = "tb_contrato"
        Me.tb_contrato.Size = New System.Drawing.Size(252, 20)
        Me.tb_contrato.TabIndex = 1
        '
        'tb_num_cliente
        '
        Me.tb_num_cliente.Location = New System.Drawing.Point(118, 110)
        Me.tb_num_cliente.Name = "tb_num_cliente"
        Me.tb_num_cliente.Size = New System.Drawing.Size(252, 20)
        Me.tb_num_cliente.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 275)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Saldo:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 252)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Nº Cheque:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 223)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "NIP Fiscal:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "NIP Audiomatico:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha de Apertura:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sucursal:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Número de Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Contrato:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Banco:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta:"
        '
        'frm_cuentas_banco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 458)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.menu_principal)
        Me.Name = "frm_cuentas_banco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas bancarias"
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menu_principal As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_editar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btn_cancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_banco As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_fecha_apertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_saldo As System.Windows.Forms.TextBox
    Friend WithEvents tb_num_cheque As System.Windows.Forms.TextBox
    Friend WithEvents tb_nip_audiomatico As System.Windows.Forms.TextBox
    Friend WithEvents tb_nip_fiscal As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents tb_sucursal As System.Windows.Forms.TextBox
    Friend WithEvents tb_contrato As System.Windows.Forms.TextBox
    Friend WithEvents tb_num_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents label44 As System.Windows.Forms.Label
    Friend WithEvents cb_cuenta As System.Windows.Forms.ComboBox
End Class
