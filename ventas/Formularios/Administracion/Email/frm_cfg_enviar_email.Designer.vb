<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cfg_enviar_email
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_comprobar_cfg = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chb_enviar_email_generado = New System.Windows.Forms.CheckBox()
        Me.gb_cfg_pdf = New System.Windows.Forms.GroupBox()
        Me.chb_proteger_pdf = New System.Windows.Forms.CheckBox()
        Me.tb_password_confirm = New System.Windows.Forms.TextBox()
        Me.tb_password = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb_tipo_documento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gb_servidor_f = New System.Windows.Forms.GroupBox()
        Me.chb_habilitar_ssl = New System.Windows.Forms.CheckBox()
        Me.tb_puerto_smtp = New System.Windows.Forms.TextBox()
        Me.tb_password_smtp = New System.Windows.Forms.TextBox()
        Me.tb_correo_smtp = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cb_servidor_smtp = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_mensaje = New System.Windows.Forms.TextBox()
        Me.tb_asunto = New System.Windows.Forms.TextBox()
        Me.tb_email_dest = New System.Windows.Forms.TextBox()
        Me.tb_nombre_dest = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gb_cfg_pdf.SuspendLayout()
        Me.gb_servidor_f.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_comprobar_cfg)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.gb_servidor_f)
        Me.GroupBox1.Controls.Add(Me.tb_mensaje)
        Me.GroupBox1.Controls.Add(Me.tb_asunto)
        Me.GroupBox1.Controls.Add(Me.tb_email_dest)
        Me.GroupBox1.Controls.Add(Me.tb_nombre_dest)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(471, 554)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuracin."
        '
        'btn_comprobar_cfg
        '
        Me.btn_comprobar_cfg.Location = New System.Drawing.Point(259, 505)
        Me.btn_comprobar_cfg.Name = "btn_comprobar_cfg"
        Me.btn_comprobar_cfg.Size = New System.Drawing.Size(99, 43)
        Me.btn_comprobar_cfg.TabIndex = 5
        Me.btn_comprobar_cfg.Text = "Comprobar configuración"
        Me.btn_comprobar_cfg.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(119, 506)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(105, 42)
        Me.btn_guardar.TabIndex = 1
        Me.btn_guardar.Text = "Guardar cambios"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.gb_cfg_pdf)
        Me.GroupBox2.Controls.Add(Me.cb_tipo_documento)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 289)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(446, 210)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Adjuntar información"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chb_enviar_email_generado)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(405, 43)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Configuración de envio"
        '
        'chb_enviar_email_generado
        '
        Me.chb_enviar_email_generado.AutoSize = True
        Me.chb_enviar_email_generado.Location = New System.Drawing.Point(7, 18)
        Me.chb_enviar_email_generado.Name = "chb_enviar_email_generado"
        Me.chb_enviar_email_generado.Size = New System.Drawing.Size(203, 17)
        Me.chb_enviar_email_generado.TabIndex = 0
        Me.chb_enviar_email_generado.Text = "Enviar e-mail al generar el documento"
        Me.chb_enviar_email_generado.UseVisualStyleBackColor = True
        '
        'gb_cfg_pdf
        '
        Me.gb_cfg_pdf.Controls.Add(Me.chb_proteger_pdf)
        Me.gb_cfg_pdf.Controls.Add(Me.tb_password_confirm)
        Me.gb_cfg_pdf.Controls.Add(Me.tb_password)
        Me.gb_cfg_pdf.Controls.Add(Me.Label7)
        Me.gb_cfg_pdf.Controls.Add(Me.Label6)
        Me.gb_cfg_pdf.Enabled = False
        Me.gb_cfg_pdf.Location = New System.Drawing.Point(123, 46)
        Me.gb_cfg_pdf.Name = "gb_cfg_pdf"
        Me.gb_cfg_pdf.Size = New System.Drawing.Size(292, 103)
        Me.gb_cfg_pdf.TabIndex = 9
        Me.gb_cfg_pdf.TabStop = False
        Me.gb_cfg_pdf.Text = "Seguridad en  PDF"
        '
        'chb_proteger_pdf
        '
        Me.chb_proteger_pdf.AutoSize = True
        Me.chb_proteger_pdf.Location = New System.Drawing.Point(54, 20)
        Me.chb_proteger_pdf.Name = "chb_proteger_pdf"
        Me.chb_proteger_pdf.Size = New System.Drawing.Size(143, 17)
        Me.chb_proteger_pdf.TabIndex = 4
        Me.chb_proteger_pdf.Text = "Proteger con contraseña"
        Me.chb_proteger_pdf.UseVisualStyleBackColor = True
        '
        'tb_password_confirm
        '
        Me.tb_password_confirm.Enabled = False
        Me.tb_password_confirm.Location = New System.Drawing.Point(122, 74)
        Me.tb_password_confirm.Name = "tb_password_confirm"
        Me.tb_password_confirm.Size = New System.Drawing.Size(146, 20)
        Me.tb_password_confirm.TabIndex = 3
        Me.tb_password_confirm.UseSystemPasswordChar = True
        '
        'tb_password
        '
        Me.tb_password.Enabled = False
        Me.tb_password.Location = New System.Drawing.Point(122, 47)
        Me.tb_password.Name = "tb_password"
        Me.tb_password.Size = New System.Drawing.Size(146, 20)
        Me.tb_password.TabIndex = 3
        Me.tb_password.UseSystemPasswordChar = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Repetir contraseña:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Contraseña:"
        '
        'cb_tipo_documento
        '
        Me.cb_tipo_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tipo_documento.FormattingEnabled = True
        Me.cb_tipo_documento.Location = New System.Drawing.Point(132, 19)
        Me.cb_tipo_documento.Name = "cb_tipo_documento"
        Me.cb_tipo_documento.Size = New System.Drawing.Size(283, 21)
        Me.cb_tipo_documento.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Adjuntar información de:"
        '
        'gb_servidor_f
        '
        Me.gb_servidor_f.Controls.Add(Me.chb_habilitar_ssl)
        Me.gb_servidor_f.Controls.Add(Me.tb_puerto_smtp)
        Me.gb_servidor_f.Controls.Add(Me.tb_password_smtp)
        Me.gb_servidor_f.Controls.Add(Me.tb_correo_smtp)
        Me.gb_servidor_f.Controls.Add(Me.Label11)
        Me.gb_servidor_f.Controls.Add(Me.Label10)
        Me.gb_servidor_f.Controls.Add(Me.Label9)
        Me.gb_servidor_f.Controls.Add(Me.cb_servidor_smtp)
        Me.gb_servidor_f.Controls.Add(Me.Label8)
        Me.gb_servidor_f.Location = New System.Drawing.Point(14, 179)
        Me.gb_servidor_f.Name = "gb_servidor_f"
        Me.gb_servidor_f.Size = New System.Drawing.Size(446, 104)
        Me.gb_servidor_f.TabIndex = 2
        Me.gb_servidor_f.TabStop = False
        Me.gb_servidor_f.Text = "Servidor smtp"
        '
        'chb_habilitar_ssl
        '
        Me.chb_habilitar_ssl.AutoSize = True
        Me.chb_habilitar_ssl.Checked = True
        Me.chb_habilitar_ssl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_habilitar_ssl.Location = New System.Drawing.Point(303, 48)
        Me.chb_habilitar_ssl.Name = "chb_habilitar_ssl"
        Me.chb_habilitar_ssl.Size = New System.Drawing.Size(136, 17)
        Me.chb_habilitar_ssl.TabIndex = 4
        Me.chb_habilitar_ssl.Text = "Habilitar seguridad SSL"
        Me.chb_habilitar_ssl.UseVisualStyleBackColor = True
        '
        'tb_puerto_smtp
        '
        Me.tb_puerto_smtp.Location = New System.Drawing.Point(345, 19)
        Me.tb_puerto_smtp.Name = "tb_puerto_smtp"
        Me.tb_puerto_smtp.Size = New System.Drawing.Size(78, 20)
        Me.tb_puerto_smtp.TabIndex = 3
        '
        'tb_password_smtp
        '
        Me.tb_password_smtp.Location = New System.Drawing.Point(105, 73)
        Me.tb_password_smtp.Name = "tb_password_smtp"
        Me.tb_password_smtp.Size = New System.Drawing.Size(176, 20)
        Me.tb_password_smtp.TabIndex = 3
        Me.tb_password_smtp.UseSystemPasswordChar = True
        '
        'tb_correo_smtp
        '
        Me.tb_correo_smtp.Location = New System.Drawing.Point(105, 48)
        Me.tb_correo_smtp.Name = "tb_correo_smtp"
        Me.tb_correo_smtp.Size = New System.Drawing.Size(176, 20)
        Me.tb_correo_smtp.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(303, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Puerto:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Contraseña:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Correo electronico:"
        '
        'cb_servidor_smtp
        '
        Me.cb_servidor_smtp.FormattingEnabled = True
        Me.cb_servidor_smtp.Location = New System.Drawing.Point(83, 19)
        Me.cb_servidor_smtp.Name = "cb_servidor_smtp"
        Me.cb_servidor_smtp.Size = New System.Drawing.Size(198, 21)
        Me.cb_servidor_smtp.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Servidor smtp:"
        '
        'tb_mensaje
        '
        Me.tb_mensaje.Location = New System.Drawing.Point(131, 103)
        Me.tb_mensaje.Multiline = True
        Me.tb_mensaje.Name = "tb_mensaje"
        Me.tb_mensaje.Size = New System.Drawing.Size(306, 70)
        Me.tb_mensaje.TabIndex = 3
        '
        'tb_asunto
        '
        Me.tb_asunto.Location = New System.Drawing.Point(131, 74)
        Me.tb_asunto.Name = "tb_asunto"
        Me.tb_asunto.Size = New System.Drawing.Size(306, 20)
        Me.tb_asunto.TabIndex = 3
        '
        'tb_email_dest
        '
        Me.tb_email_dest.Location = New System.Drawing.Point(131, 48)
        Me.tb_email_dest.Name = "tb_email_dest"
        Me.tb_email_dest.Size = New System.Drawing.Size(306, 20)
        Me.tb_email_dest.TabIndex = 3
        '
        'tb_nombre_dest
        '
        Me.tb_nombre_dest.Location = New System.Drawing.Point(131, 22)
        Me.tb_nombre_dest.Name = "tb_nombre_dest"
        Me.tb_nombre_dest.Size = New System.Drawing.Size(306, 20)
        Me.tb_nombre_dest.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(80, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Mensaje:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Asunto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "E-mail:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre destinatario:"
        '
        'frm_cfg_enviar_email
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 566)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_cfg_enviar_email"
        Me.Text = "Configuracion de envio de e-mail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gb_cfg_pdf.ResumeLayout(False)
        Me.gb_cfg_pdf.PerformLayout()
        Me.gb_servidor_f.ResumeLayout(False)
        Me.gb_servidor_f.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_mensaje As System.Windows.Forms.TextBox
    Friend WithEvents tb_asunto As System.Windows.Forms.TextBox
    Friend WithEvents tb_email_dest As System.Windows.Forms.TextBox
    Friend WithEvents tb_nombre_dest As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents gb_servidor_f As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cb_servidor_smtp As System.Windows.Forms.ComboBox
    Friend WithEvents tb_password_smtp As System.Windows.Forms.TextBox
    Friend WithEvents tb_correo_smtp As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chb_habilitar_ssl As System.Windows.Forms.CheckBox
    Friend WithEvents tb_puerto_smtp As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chb_enviar_email_generado As System.Windows.Forms.CheckBox
    Friend WithEvents gb_cfg_pdf As System.Windows.Forms.GroupBox
    Friend WithEvents tb_password_confirm As System.Windows.Forms.TextBox
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cb_tipo_documento As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chb_proteger_pdf As System.Windows.Forms.CheckBox
    Friend WithEvents btn_comprobar_cfg As System.Windows.Forms.Button
End Class
