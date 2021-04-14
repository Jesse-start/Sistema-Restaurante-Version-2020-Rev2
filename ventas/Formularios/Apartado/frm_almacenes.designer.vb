<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_almacenes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_almacenes))
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_principal = New System.Windows.Forms.ToolStrip()
        Me.btn_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.btn_editar = New System.Windows.Forms.ToolStripButton()
        Me.btn_guardar = New System.Windows.Forms.ToolStripButton()
        Me.btn_eliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btn_cancelar = New System.Windows.Forms.ToolStripButton()
        Me.gb_datos_almacenes = New System.Windows.Forms.GroupBox()
        Me.chb_default = New System.Windows.Forms.CheckBox()
        Me.tb_nombre = New System.Windows.Forms.ComboBox()
        Me.tb_responsable = New System.Windows.Forms.TextBox()
        Me.tb_telefono = New System.Windows.Forms.TextBox()
        Me.tb_localidad = New System.Windows.Forms.TextBox()
        Me.tb_colonia = New System.Windows.Forms.TextBox()
        Me.tb_calle = New System.Windows.Forms.TextBox()
        Me.lblresponsable = New System.Windows.Forms.Label()
        Me.lbltelefono = New System.Windows.Forms.Label()
        Me.lbllocalidad = New System.Windows.Forms.Label()
        Me.lblcolonia = New System.Windows.Forms.Label()
        Me.lblcalle = New System.Windows.Forms.Label()
        Me.lblnombre = New System.Windows.Forms.Label()
        Me.m_nuevo = New System.Windows.Forms.ToolStripButton()
        Me.m_abrir = New System.Windows.Forms.ToolStripButton()
        Me.m_guardar = New System.Windows.Forms.ToolStripButton()
        Me.menu_principal.SuspendLayout()
        Me.gb_datos_almacenes.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'menu_principal
        '
        Me.menu_principal.BackColor = System.Drawing.SystemColors.Control
        Me.menu_principal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.menu_principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_nuevo, Me.btn_editar, Me.btn_guardar, Me.btn_eliminar, Me.ToolStripSeparator1, Me.btn_cancelar})
        Me.menu_principal.Location = New System.Drawing.Point(0, 0)
        Me.menu_principal.Name = "menu_principal"
        Me.menu_principal.Size = New System.Drawing.Size(331, 25)
        Me.menu_principal.TabIndex = 30
        Me.menu_principal.Text = "ToolStrip1"
        '
        'btn_nuevo
        '
        Me.btn_nuevo.AutoToolTip = False
        Me.btn_nuevo.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(58, 22)
        Me.btn_nuevo.Text = "&Nuevo"
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_editar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(55, 22)
        Me.btn_editar.Text = "Editar"
        '
        'btn_guardar
        '
        Me.btn_guardar.AutoToolTip = False
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(66, 22)
        Me.btn_guardar.Text = "&Guardar"
        '
        'btn_eliminar
        '
        Me.btn_eliminar.AutoToolTip = False
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_eliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(63, 22)
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
        Me.btn_cancelar.Size = New System.Drawing.Size(53, 22)
        Me.btn_cancelar.Text = "Cancelar"
        '
        'gb_datos_almacenes
        '
        Me.gb_datos_almacenes.Controls.Add(Me.chb_default)
        Me.gb_datos_almacenes.Controls.Add(Me.tb_nombre)
        Me.gb_datos_almacenes.Controls.Add(Me.tb_responsable)
        Me.gb_datos_almacenes.Controls.Add(Me.tb_telefono)
        Me.gb_datos_almacenes.Controls.Add(Me.tb_localidad)
        Me.gb_datos_almacenes.Controls.Add(Me.tb_colonia)
        Me.gb_datos_almacenes.Controls.Add(Me.tb_calle)
        Me.gb_datos_almacenes.Controls.Add(Me.lblresponsable)
        Me.gb_datos_almacenes.Controls.Add(Me.lbltelefono)
        Me.gb_datos_almacenes.Controls.Add(Me.lbllocalidad)
        Me.gb_datos_almacenes.Controls.Add(Me.lblcolonia)
        Me.gb_datos_almacenes.Controls.Add(Me.lblcalle)
        Me.gb_datos_almacenes.Controls.Add(Me.lblnombre)
        Me.gb_datos_almacenes.Location = New System.Drawing.Point(6, 28)
        Me.gb_datos_almacenes.Name = "gb_datos_almacenes"
        Me.gb_datos_almacenes.Size = New System.Drawing.Size(310, 211)
        Me.gb_datos_almacenes.TabIndex = 31
        Me.gb_datos_almacenes.TabStop = False
        Me.gb_datos_almacenes.Text = "Datos de Almacenes"
        '
        'chb_default
        '
        Me.chb_default.AutoSize = True
        Me.chb_default.Location = New System.Drawing.Point(76, 178)
        Me.chb_default.Name = "chb_default"
        Me.chb_default.Size = New System.Drawing.Size(236, 17)
        Me.chb_default.TabIndex = 7
        Me.chb_default.Text = "Hacer este almacen por default para ventas."
        Me.chb_default.UseVisualStyleBackColor = True
        '
        'tb_nombre
        '
        Me.tb_nombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tb_nombre.FormattingEnabled = True
        Me.tb_nombre.Location = New System.Drawing.Point(76, 19)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(224, 21)
        Me.tb_nombre.TabIndex = 6
        '
        'tb_responsable
        '
        Me.tb_responsable.Location = New System.Drawing.Point(76, 152)
        Me.tb_responsable.Name = "tb_responsable"
        Me.tb_responsable.Size = New System.Drawing.Size(223, 20)
        Me.tb_responsable.TabIndex = 5
        '
        'tb_telefono
        '
        Me.tb_telefono.Location = New System.Drawing.Point(77, 126)
        Me.tb_telefono.Name = "tb_telefono"
        Me.tb_telefono.Size = New System.Drawing.Size(223, 20)
        Me.tb_telefono.TabIndex = 4
        '
        'tb_localidad
        '
        Me.tb_localidad.Location = New System.Drawing.Point(77, 100)
        Me.tb_localidad.Name = "tb_localidad"
        Me.tb_localidad.Size = New System.Drawing.Size(223, 20)
        Me.tb_localidad.TabIndex = 3
        '
        'tb_colonia
        '
        Me.tb_colonia.Location = New System.Drawing.Point(77, 74)
        Me.tb_colonia.Name = "tb_colonia"
        Me.tb_colonia.Size = New System.Drawing.Size(223, 20)
        Me.tb_colonia.TabIndex = 2
        '
        'tb_calle
        '
        Me.tb_calle.Location = New System.Drawing.Point(77, 48)
        Me.tb_calle.Name = "tb_calle"
        Me.tb_calle.Size = New System.Drawing.Size(223, 20)
        Me.tb_calle.TabIndex = 1
        '
        'lblresponsable
        '
        Me.lblresponsable.AutoSize = True
        Me.lblresponsable.Location = New System.Drawing.Point(6, 155)
        Me.lblresponsable.Name = "lblresponsable"
        Me.lblresponsable.Size = New System.Drawing.Size(72, 13)
        Me.lblresponsable.TabIndex = 0
        Me.lblresponsable.Text = "Responsable:"
        '
        'lbltelefono
        '
        Me.lbltelefono.AutoSize = True
        Me.lbltelefono.Location = New System.Drawing.Point(6, 129)
        Me.lbltelefono.Name = "lbltelefono"
        Me.lbltelefono.Size = New System.Drawing.Size(52, 13)
        Me.lbltelefono.TabIndex = 0
        Me.lbltelefono.Text = "Telefono:"
        '
        'lbllocalidad
        '
        Me.lbllocalidad.AutoSize = True
        Me.lbllocalidad.Location = New System.Drawing.Point(6, 103)
        Me.lbllocalidad.Name = "lbllocalidad"
        Me.lbllocalidad.Size = New System.Drawing.Size(56, 13)
        Me.lbllocalidad.TabIndex = 0
        Me.lbllocalidad.Text = "Localidad:"
        '
        'lblcolonia
        '
        Me.lblcolonia.AutoSize = True
        Me.lblcolonia.Location = New System.Drawing.Point(6, 77)
        Me.lblcolonia.Name = "lblcolonia"
        Me.lblcolonia.Size = New System.Drawing.Size(45, 13)
        Me.lblcolonia.TabIndex = 0
        Me.lblcolonia.Text = "Colonia:"
        '
        'lblcalle
        '
        Me.lblcalle.AutoSize = True
        Me.lblcalle.Location = New System.Drawing.Point(6, 51)
        Me.lblcalle.Name = "lblcalle"
        Me.lblcalle.Size = New System.Drawing.Size(33, 13)
        Me.lblcalle.TabIndex = 0
        Me.lblcalle.Text = "Calle:"
        '
        'lblnombre
        '
        Me.lblnombre.AutoSize = True
        Me.lblnombre.Location = New System.Drawing.Point(6, 24)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(47, 13)
        Me.lblnombre.TabIndex = 0
        Me.lblnombre.Text = "Nombre:"
        '
        'm_nuevo
        '
        Me.m_nuevo.AutoToolTip = False
        Me.m_nuevo.Image = CType(resources.GetObject("m_nuevo.Image"), System.Drawing.Image)
        Me.m_nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_nuevo.Name = "m_nuevo"
        Me.m_nuevo.Size = New System.Drawing.Size(58, 22)
        Me.m_nuevo.Text = "&Nuevo"
        '
        'm_abrir
        '
        Me.m_abrir.AutoToolTip = False
        Me.m_abrir.Image = CType(resources.GetObject("m_abrir.Image"), System.Drawing.Image)
        Me.m_abrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_abrir.Name = "m_abrir"
        Me.m_abrir.Size = New System.Drawing.Size(50, 22)
        Me.m_abrir.Text = "&Abrir"
        '
        'm_guardar
        '
        Me.m_guardar.AutoToolTip = False
        Me.m_guardar.Image = CType(resources.GetObject("m_guardar.Image"), System.Drawing.Image)
        Me.m_guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.m_guardar.Name = "m_guardar"
        Me.m_guardar.Size = New System.Drawing.Size(66, 22)
        Me.m_guardar.Text = "&Guardar"
        '
        'frm_almacenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 251)
        Me.Controls.Add(Me.gb_datos_almacenes)
        Me.Controls.Add(Me.menu_principal)
        Me.Name = "frm_almacenes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Almacenes"
        Me.menu_principal.ResumeLayout(False)
        Me.menu_principal.PerformLayout()
        Me.gb_datos_almacenes.ResumeLayout(False)
        Me.gb_datos_almacenes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents m_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_abrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents m_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_principal As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_nuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_eliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_guardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents btn_cancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents gb_datos_almacenes As System.Windows.Forms.GroupBox
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents tb_responsable As System.Windows.Forms.TextBox
    Friend WithEvents tb_telefono As System.Windows.Forms.TextBox
    Friend WithEvents tb_localidad As System.Windows.Forms.TextBox
    Friend WithEvents tb_colonia As System.Windows.Forms.TextBox
    Friend WithEvents tb_calle As System.Windows.Forms.TextBox
    Friend WithEvents lblresponsable As System.Windows.Forms.Label
    Friend WithEvents lbltelefono As System.Windows.Forms.Label
    Friend WithEvents lbllocalidad As System.Windows.Forms.Label
    Friend WithEvents lblcolonia As System.Windows.Forms.Label
    Friend WithEvents lblcalle As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.ComboBox
    Friend WithEvents btn_editar As System.Windows.Forms.ToolStripButton
    Friend WithEvents chb_default As System.Windows.Forms.CheckBox
End Class
