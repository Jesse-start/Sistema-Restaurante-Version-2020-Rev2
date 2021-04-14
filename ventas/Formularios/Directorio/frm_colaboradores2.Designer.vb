<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_colaboradores2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_colaboradores2))
        Me.lst_colaboradores = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.Tab_colaboradores = New System.Windows.Forms.TabControl()
        Me.Tab_generales = New System.Windows.Forms.TabPage()
        Me.linea_estado = New System.Windows.Forms.Label()
        Me.accion = New System.Windows.Forms.Label()
        Me.btn_detener_lector = New System.Windows.Forms.Button()
        Me.btn_activar_lector = New System.Windows.Forms.Button()
        Me.huella_digital = New System.Windows.Forms.PictureBox()
        Me.pb_imagen = New System.Windows.Forms.PictureBox()
        Me.btn_eliminar_imagen = New System.Windows.Forms.Button()
        Me.btn_agregar_imagen = New System.Windows.Forms.Button()
        Me.gb_unidad = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_confirmar = New System.Windows.Forms.TextBox()
        Me.tb_usuario = New System.Windows.Forms.TextBox()
        Me.tb_password = New System.Windows.Forms.TextBox()
        Me.tb_whatsapp = New System.Windows.Forms.TextBox()
        Me.tb_tel_cel = New System.Windows.Forms.TextBox()
        Me.tb_tel_fijo = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.cb_perfil = New System.Windows.Forms.ComboBox()
        Me.tb_curp = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.tb_alias = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.tb_rfcF = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tb_emailF = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.tb_apellidoM = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_apellidoP = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tab_domicilio = New System.Windows.Forms.TabPage()
        Me.chb_domicilio = New System.Windows.Forms.CheckBox()
        Me.panel_domicilio = New System.Windows.Forms.Panel()
        Me.tb_municipio = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tb_calle = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tb_pais = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tb_estado = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tb_poblacion = New System.Windows.Forms.TextBox()
        Me.tb_cp = New System.Windows.Forms.TextBox()
        Me.tb_num_int = New System.Windows.Forms.TextBox()
        Me.tb_num_ext = New System.Windows.Forms.TextBox()
        Me.tb_colonia = New System.Windows.Forms.TextBox()
        Me.Tab_horario = New System.Windows.Forms.TabPage()
        Me.tb_minutos_tolerancia = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtp_hora_salida = New System.Windows.Forms.DateTimePicker()
        Me.dtp_hora_entrada = New System.Windows.Forms.DateTimePicker()
        Me.ofd_foto = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.Tab_colaboradores.SuspendLayout()
        Me.Tab_generales.SuspendLayout()
        CType(Me.huella_digital, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_unidad.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Tab_domicilio.SuspendLayout()
        Me.panel_domicilio.SuspendLayout()
        Me.Tab_horario.SuspendLayout()
        CType(Me.tb_minutos_tolerancia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lst_colaboradores
        '
        Me.lst_colaboradores.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_colaboradores.GridLines = True
        Me.lst_colaboradores.Location = New System.Drawing.Point(12, 23)
        Me.lst_colaboradores.MultiSelect = False
        Me.lst_colaboradores.Name = "lst_colaboradores"
        Me.lst_colaboradores.Size = New System.Drawing.Size(350, 559)
        Me.lst_colaboradores.TabIndex = 0
        Me.lst_colaboradores.UseCompatibleStateImageBehavior = False
        Me.lst_colaboradores.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_eliminar)
        Me.GroupBox1.Controls.Add(Me.btn_deshacer)
        Me.GroupBox1.Controls.Add(Me.btn_editar)
        Me.GroupBox1.Location = New System.Drawing.Point(368, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 92)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(3, 11)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(59, 74)
        Me.btn_nuevo.TabIndex = 11
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Enabled = False
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(357, 11)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(76, 74)
        Me.btn_salir.TabIndex = 16
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(65, 11)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(68, 74)
        Me.btn_guardar.TabIndex = 13
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.Location = New System.Drawing.Point(277, 11)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(77, 74)
        Me.btn_eliminar.TabIndex = 15
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_deshacer
        '
        Me.btn_deshacer.Enabled = False
        Me.btn_deshacer.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deshacer.Image = CType(resources.GetObject("btn_deshacer.Image"), System.Drawing.Image)
        Me.btn_deshacer.Location = New System.Drawing.Point(135, 11)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(76, 74)
        Me.btn_deshacer.TabIndex = 12
        Me.btn_deshacer.Text = "Deshacer"
        Me.btn_deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_deshacer.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Location = New System.Drawing.Point(213, 11)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(61, 74)
        Me.btn_editar.TabIndex = 14
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'Tab_colaboradores
        '
        Me.Tab_colaboradores.Controls.Add(Me.Tab_generales)
        Me.Tab_colaboradores.Controls.Add(Me.Tab_domicilio)
        Me.Tab_colaboradores.Controls.Add(Me.Tab_horario)
        Me.Tab_colaboradores.Location = New System.Drawing.Point(371, 116)
        Me.Tab_colaboradores.Name = "Tab_colaboradores"
        Me.Tab_colaboradores.SelectedIndex = 0
        Me.Tab_colaboradores.Size = New System.Drawing.Size(545, 542)
        Me.Tab_colaboradores.TabIndex = 13
        '
        'Tab_generales
        '
        Me.Tab_generales.Controls.Add(Me.linea_estado)
        Me.Tab_generales.Controls.Add(Me.accion)
        Me.Tab_generales.Controls.Add(Me.btn_detener_lector)
        Me.Tab_generales.Controls.Add(Me.btn_activar_lector)
        Me.Tab_generales.Controls.Add(Me.huella_digital)
        Me.Tab_generales.Controls.Add(Me.pb_imagen)
        Me.Tab_generales.Controls.Add(Me.btn_eliminar_imagen)
        Me.Tab_generales.Controls.Add(Me.btn_agregar_imagen)
        Me.Tab_generales.Controls.Add(Me.gb_unidad)
        Me.Tab_generales.Location = New System.Drawing.Point(4, 22)
        Me.Tab_generales.Name = "Tab_generales"
        Me.Tab_generales.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_generales.Size = New System.Drawing.Size(537, 516)
        Me.Tab_generales.TabIndex = 0
        Me.Tab_generales.Text = "Generales"
        Me.Tab_generales.UseVisualStyleBackColor = True
        '
        'linea_estado
        '
        Me.linea_estado.AutoSize = True
        Me.linea_estado.Location = New System.Drawing.Point(381, 385)
        Me.linea_estado.Name = "linea_estado"
        Me.linea_estado.Size = New System.Drawing.Size(55, 13)
        Me.linea_estado.TabIndex = 34
        Me.linea_estado.Text = "En espera"
        Me.linea_estado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'accion
        '
        Me.accion.AutoSize = True
        Me.accion.Location = New System.Drawing.Point(381, 368)
        Me.accion.Name = "accion"
        Me.accion.Size = New System.Drawing.Size(102, 13)
        Me.accion.TabIndex = 33
        Me.accion.Text = "Inicializar dispositivo"
        '
        'btn_detener_lector
        '
        Me.btn_detener_lector.Location = New System.Drawing.Point(451, 408)
        Me.btn_detener_lector.Name = "btn_detener_lector"
        Me.btn_detener_lector.Size = New System.Drawing.Size(70, 36)
        Me.btn_detener_lector.TabIndex = 32
        Me.btn_detener_lector.Text = "Detener"
        Me.btn_detener_lector.UseVisualStyleBackColor = True
        '
        'btn_activar_lector
        '
        Me.btn_activar_lector.Location = New System.Drawing.Point(384, 408)
        Me.btn_activar_lector.Name = "btn_activar_lector"
        Me.btn_activar_lector.Size = New System.Drawing.Size(61, 36)
        Me.btn_activar_lector.TabIndex = 31
        Me.btn_activar_lector.Text = "Activar "
        Me.btn_activar_lector.UseVisualStyleBackColor = True
        '
        'huella_digital
        '
        Me.huella_digital.Location = New System.Drawing.Point(381, 221)
        Me.huella_digital.Name = "huella_digital"
        Me.huella_digital.Size = New System.Drawing.Size(140, 140)
        Me.huella_digital.TabIndex = 30
        Me.huella_digital.TabStop = False
        '
        'pb_imagen
        '
        Me.pb_imagen.BackgroundImage = CType(resources.GetObject("pb_imagen.BackgroundImage"), System.Drawing.Image)
        Me.pb_imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pb_imagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_imagen.Location = New System.Drawing.Point(381, 6)
        Me.pb_imagen.Name = "pb_imagen"
        Me.pb_imagen.Size = New System.Drawing.Size(140, 140)
        Me.pb_imagen.TabIndex = 29
        Me.pb_imagen.TabStop = False
        '
        'btn_eliminar_imagen
        '
        Me.btn_eliminar_imagen.BackColor = System.Drawing.Color.Red
        Me.btn_eliminar_imagen.ForeColor = System.Drawing.Color.White
        Me.btn_eliminar_imagen.Location = New System.Drawing.Point(455, 152)
        Me.btn_eliminar_imagen.Name = "btn_eliminar_imagen"
        Me.btn_eliminar_imagen.Size = New System.Drawing.Size(30, 28)
        Me.btn_eliminar_imagen.TabIndex = 28
        Me.btn_eliminar_imagen.Text = "X"
        Me.btn_eliminar_imagen.UseVisualStyleBackColor = False
        '
        'btn_agregar_imagen
        '
        Me.btn_agregar_imagen.BackColor = System.Drawing.Color.Green
        Me.btn_agregar_imagen.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar_imagen.ForeColor = System.Drawing.Color.White
        Me.btn_agregar_imagen.Location = New System.Drawing.Point(491, 152)
        Me.btn_agregar_imagen.Name = "btn_agregar_imagen"
        Me.btn_agregar_imagen.Size = New System.Drawing.Size(30, 28)
        Me.btn_agregar_imagen.TabIndex = 27
        Me.btn_agregar_imagen.Text = "+"
        Me.btn_agregar_imagen.UseVisualStyleBackColor = False
        '
        'gb_unidad
        '
        Me.gb_unidad.Controls.Add(Me.GroupBox2)
        Me.gb_unidad.Controls.Add(Me.tb_whatsapp)
        Me.gb_unidad.Controls.Add(Me.tb_tel_cel)
        Me.gb_unidad.Controls.Add(Me.tb_tel_fijo)
        Me.gb_unidad.Controls.Add(Me.Label57)
        Me.gb_unidad.Controls.Add(Me.Label56)
        Me.gb_unidad.Controls.Add(Me.Label55)
        Me.gb_unidad.Controls.Add(Me.cb_perfil)
        Me.gb_unidad.Controls.Add(Me.tb_curp)
        Me.gb_unidad.Controls.Add(Me.Label39)
        Me.gb_unidad.Controls.Add(Me.tb_alias)
        Me.gb_unidad.Controls.Add(Me.Label35)
        Me.gb_unidad.Controls.Add(Me.Label40)
        Me.gb_unidad.Controls.Add(Me.tb_nombre)
        Me.gb_unidad.Controls.Add(Me.tb_rfcF)
        Me.gb_unidad.Controls.Add(Me.Label4)
        Me.gb_unidad.Controls.Add(Me.tb_emailF)
        Me.gb_unidad.Controls.Add(Me.Label52)
        Me.gb_unidad.Controls.Add(Me.tb_apellidoM)
        Me.gb_unidad.Controls.Add(Me.Label5)
        Me.gb_unidad.Controls.Add(Me.tb_apellidoP)
        Me.gb_unidad.Controls.Add(Me.Label6)
        Me.gb_unidad.Controls.Add(Me.Label7)
        Me.gb_unidad.Enabled = False
        Me.gb_unidad.Location = New System.Drawing.Point(6, 3)
        Me.gb_unidad.Name = "gb_unidad"
        Me.gb_unidad.Size = New System.Drawing.Size(369, 492)
        Me.gb_unidad.TabIndex = 26
        Me.gb_unidad.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tb_confirmar)
        Me.GroupBox2.Controls.Add(Me.tb_usuario)
        Me.GroupBox2.Controls.Add(Me.tb_password)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 373)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(356, 113)
        Me.GroupBox2.TabIndex = 51
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Inicio Sesión"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Confirmar:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(52, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Usuario:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Contraseña:"
        '
        'tb_confirmar
        '
        Me.tb_confirmar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_confirmar.Location = New System.Drawing.Point(116, 84)
        Me.tb_confirmar.Name = "tb_confirmar"
        Me.tb_confirmar.Size = New System.Drawing.Size(234, 23)
        Me.tb_confirmar.TabIndex = 42
        Me.tb_confirmar.UseSystemPasswordChar = True
        '
        'tb_usuario
        '
        Me.tb_usuario.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_usuario.Location = New System.Drawing.Point(116, 19)
        Me.tb_usuario.Name = "tb_usuario"
        Me.tb_usuario.Size = New System.Drawing.Size(234, 23)
        Me.tb_usuario.TabIndex = 41
        '
        'tb_password
        '
        Me.tb_password.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_password.Location = New System.Drawing.Point(116, 52)
        Me.tb_password.Name = "tb_password"
        Me.tb_password.Size = New System.Drawing.Size(234, 23)
        Me.tb_password.TabIndex = 43
        Me.tb_password.UseSystemPasswordChar = True
        '
        'tb_whatsapp
        '
        Me.tb_whatsapp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_whatsapp.Location = New System.Drawing.Point(122, 331)
        Me.tb_whatsapp.Name = "tb_whatsapp"
        Me.tb_whatsapp.Size = New System.Drawing.Size(230, 22)
        Me.tb_whatsapp.TabIndex = 47
        '
        'tb_tel_cel
        '
        Me.tb_tel_cel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_tel_cel.Location = New System.Drawing.Point(122, 300)
        Me.tb_tel_cel.Name = "tb_tel_cel"
        Me.tb_tel_cel.Size = New System.Drawing.Size(230, 22)
        Me.tb_tel_cel.TabIndex = 46
        '
        'tb_tel_fijo
        '
        Me.tb_tel_fijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_tel_fijo.Location = New System.Drawing.Point(122, 268)
        Me.tb_tel_fijo.Name = "tb_tel_fijo"
        Me.tb_tel_fijo.Size = New System.Drawing.Size(234, 22)
        Me.tb_tel_fijo.TabIndex = 45
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(43, 335)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(70, 16)
        Me.Label57.TabIndex = 50
        Me.Label57.Text = "WhatsApp:"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(43, 304)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(66, 16)
        Me.Label56.TabIndex = 49
        Me.Label56.Text = "Tel. Movil:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(43, 272)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(63, 16)
        Me.Label55.TabIndex = 48
        Me.Label55.Text = "Tel Local:"
        '
        'cb_perfil
        '
        Me.cb_perfil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_perfil.FormattingEnabled = True
        Me.cb_perfil.Location = New System.Drawing.Point(122, 233)
        Me.cb_perfil.Name = "cb_perfil"
        Me.cb_perfil.Size = New System.Drawing.Size(234, 25)
        Me.cb_perfil.TabIndex = 14
        '
        'tb_curp
        '
        Me.tb_curp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_curp.Location = New System.Drawing.Point(122, 200)
        Me.tb_curp.Name = "tb_curp"
        Me.tb_curp.Size = New System.Drawing.Size(234, 23)
        Me.tb_curp.TabIndex = 13
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(73, 242)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(39, 16)
        Me.Label39.TabIndex = 24
        Me.Label39.Text = "Perfil:"
        '
        'tb_alias
        '
        Me.tb_alias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_alias.Location = New System.Drawing.Point(122, 16)
        Me.tb_alias.Name = "tb_alias"
        Me.tb_alias.Size = New System.Drawing.Size(234, 23)
        Me.tb_alias.TabIndex = 34
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(73, 203)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(42, 16)
        Me.Label35.TabIndex = 22
        Me.Label35.Text = "CURP:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(82, 174)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(33, 16)
        Me.Label40.TabIndex = 40
        Me.Label40.Text = "RFC:"
        '
        'tb_nombre
        '
        Me.tb_nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre.Location = New System.Drawing.Point(122, 45)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(234, 23)
        Me.tb_nombre.TabIndex = 35
        '
        'tb_rfcF
        '
        Me.tb_rfcF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_rfcF.Location = New System.Drawing.Point(122, 171)
        Me.tb_rfcF.Name = "tb_rfcF"
        Me.tb_rfcF.Size = New System.Drawing.Size(234, 23)
        Me.tb_rfcF.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Nombre:"
        '
        'tb_emailF
        '
        Me.tb_emailF.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_emailF.Location = New System.Drawing.Point(122, 135)
        Me.tb_emailF.Name = "tb_emailF"
        Me.tb_emailF.Size = New System.Drawing.Size(234, 23)
        Me.tb_emailF.TabIndex = 38
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(76, 23)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(39, 16)
        Me.Label52.TabIndex = 29
        Me.Label52.Text = "Alias:"
        '
        'tb_apellidoM
        '
        Me.tb_apellidoM.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_apellidoM.Location = New System.Drawing.Point(122, 103)
        Me.tb_apellidoM.Name = "tb_apellidoM"
        Me.tb_apellidoM.Size = New System.Drawing.Size(234, 23)
        Me.tb_apellidoM.TabIndex = 37
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Apellido Paterno:"
        '
        'tb_apellidoP
        '
        Me.tb_apellidoP.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_apellidoP.Location = New System.Drawing.Point(122, 74)
        Me.tb_apellidoP.Name = "tb_apellidoP"
        Me.tb_apellidoP.Size = New System.Drawing.Size(234, 23)
        Me.tb_apellidoP.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 16)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Apellido Materno:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(68, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "E-mail:"
        '
        'Tab_domicilio
        '
        Me.Tab_domicilio.Controls.Add(Me.chb_domicilio)
        Me.Tab_domicilio.Controls.Add(Me.panel_domicilio)
        Me.Tab_domicilio.Location = New System.Drawing.Point(4, 22)
        Me.Tab_domicilio.Name = "Tab_domicilio"
        Me.Tab_domicilio.Size = New System.Drawing.Size(537, 516)
        Me.Tab_domicilio.TabIndex = 2
        Me.Tab_domicilio.Text = "Domicilio"
        Me.Tab_domicilio.UseVisualStyleBackColor = True
        '
        'chb_domicilio
        '
        Me.chb_domicilio.AutoSize = True
        Me.chb_domicilio.Location = New System.Drawing.Point(20, 17)
        Me.chb_domicilio.Name = "chb_domicilio"
        Me.chb_domicilio.Size = New System.Drawing.Size(68, 17)
        Me.chb_domicilio.TabIndex = 10
        Me.chb_domicilio.Text = "Domicilio"
        Me.chb_domicilio.UseVisualStyleBackColor = True
        '
        'panel_domicilio
        '
        Me.panel_domicilio.Controls.Add(Me.tb_municipio)
        Me.panel_domicilio.Controls.Add(Me.Label9)
        Me.panel_domicilio.Controls.Add(Me.Label61)
        Me.panel_domicilio.Controls.Add(Me.Label59)
        Me.panel_domicilio.Controls.Add(Me.Label12)
        Me.panel_domicilio.Controls.Add(Me.Label13)
        Me.panel_domicilio.Controls.Add(Me.tb_calle)
        Me.panel_domicilio.Controls.Add(Me.Label14)
        Me.panel_domicilio.Controls.Add(Me.Label15)
        Me.panel_domicilio.Controls.Add(Me.tb_pais)
        Me.panel_domicilio.Controls.Add(Me.Label16)
        Me.panel_domicilio.Controls.Add(Me.tb_estado)
        Me.panel_domicilio.Controls.Add(Me.Label17)
        Me.panel_domicilio.Controls.Add(Me.tb_poblacion)
        Me.panel_domicilio.Controls.Add(Me.tb_cp)
        Me.panel_domicilio.Controls.Add(Me.tb_num_int)
        Me.panel_domicilio.Controls.Add(Me.tb_num_ext)
        Me.panel_domicilio.Controls.Add(Me.tb_colonia)
        Me.panel_domicilio.Location = New System.Drawing.Point(15, 40)
        Me.panel_domicilio.Name = "panel_domicilio"
        Me.panel_domicilio.Size = New System.Drawing.Size(378, 264)
        Me.panel_domicilio.TabIndex = 9
        '
        'tb_municipio
        '
        Me.tb_municipio.Location = New System.Drawing.Point(109, 110)
        Me.tb_municipio.Name = "tb_municipio"
        Me.tb_municipio.Size = New System.Drawing.Size(233, 20)
        Me.tb_municipio.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "Calle"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(212, 49)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(50, 13)
        Me.Label61.TabIndex = 39
        Me.Label61.Text = "Num. Int."
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(30, 47)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(65, 13)
        Me.Label59.TabIndex = 39
        Me.Label59.Text = "Numero Ext."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Colonia"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(30, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Municipio"
        '
        'tb_calle
        '
        Me.tb_calle.Location = New System.Drawing.Point(109, 18)
        Me.tb_calle.Name = "tb_calle"
        Me.tb_calle.Size = New System.Drawing.Size(233, 20)
        Me.tb_calle.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(30, 141)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "C.P."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(30, 169)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "Ciudad"
        '
        'tb_pais
        '
        Me.tb_pais.Location = New System.Drawing.Point(109, 226)
        Me.tb_pais.Name = "tb_pais"
        Me.tb_pais.Size = New System.Drawing.Size(135, 20)
        Me.tb_pais.TabIndex = 22
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(30, 197)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Estado"
        '
        'tb_estado
        '
        Me.tb_estado.Location = New System.Drawing.Point(109, 194)
        Me.tb_estado.Name = "tb_estado"
        Me.tb_estado.Size = New System.Drawing.Size(135, 20)
        Me.tb_estado.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(30, 229)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 44
        Me.Label17.Text = "Pais"
        '
        'tb_poblacion
        '
        Me.tb_poblacion.Location = New System.Drawing.Point(109, 166)
        Me.tb_poblacion.Name = "tb_poblacion"
        Me.tb_poblacion.Size = New System.Drawing.Size(233, 20)
        Me.tb_poblacion.TabIndex = 20
        '
        'tb_cp
        '
        Me.tb_cp.Location = New System.Drawing.Point(109, 138)
        Me.tb_cp.Name = "tb_cp"
        Me.tb_cp.Size = New System.Drawing.Size(65, 20)
        Me.tb_cp.TabIndex = 19
        '
        'tb_num_int
        '
        Me.tb_num_int.Location = New System.Drawing.Point(268, 46)
        Me.tb_num_int.Name = "tb_num_int"
        Me.tb_num_int.Size = New System.Drawing.Size(74, 20)
        Me.tb_num_int.TabIndex = 17
        '
        'tb_num_ext
        '
        Me.tb_num_ext.Location = New System.Drawing.Point(109, 44)
        Me.tb_num_ext.Name = "tb_num_ext"
        Me.tb_num_ext.Size = New System.Drawing.Size(82, 20)
        Me.tb_num_ext.TabIndex = 17
        '
        'tb_colonia
        '
        Me.tb_colonia.Location = New System.Drawing.Point(109, 82)
        Me.tb_colonia.Name = "tb_colonia"
        Me.tb_colonia.Size = New System.Drawing.Size(233, 20)
        Me.tb_colonia.TabIndex = 17
        '
        'Tab_horario
        '
        Me.Tab_horario.Controls.Add(Me.tb_minutos_tolerancia)
        Me.Tab_horario.Controls.Add(Me.Label33)
        Me.Tab_horario.Controls.Add(Me.Label11)
        Me.Tab_horario.Controls.Add(Me.Label10)
        Me.Tab_horario.Controls.Add(Me.dtp_hora_salida)
        Me.Tab_horario.Controls.Add(Me.dtp_hora_entrada)
        Me.Tab_horario.Location = New System.Drawing.Point(4, 22)
        Me.Tab_horario.Name = "Tab_horario"
        Me.Tab_horario.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_horario.Size = New System.Drawing.Size(537, 516)
        Me.Tab_horario.TabIndex = 1
        Me.Tab_horario.Text = "Horario"
        Me.Tab_horario.UseVisualStyleBackColor = True
        '
        'tb_minutos_tolerancia
        '
        Me.tb_minutos_tolerancia.Location = New System.Drawing.Point(123, 83)
        Me.tb_minutos_tolerancia.Name = "tb_minutos_tolerancia"
        Me.tb_minutos_tolerancia.Size = New System.Drawing.Size(65, 20)
        Me.tb_minutos_tolerancia.TabIndex = 8
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 85)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(111, 13)
        Me.Label33.TabIndex = 6
        Me.Label33.Text = "Minutos de tolerancia:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Hora de salida:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Hora de entrada:"
        '
        'dtp_hora_salida
        '
        Me.dtp_hora_salida.CustomFormat = ""
        Me.dtp_hora_salida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hora_salida.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_hora_salida.Location = New System.Drawing.Point(123, 51)
        Me.dtp_hora_salida.Name = "dtp_hora_salida"
        Me.dtp_hora_salida.ShowUpDown = True
        Me.dtp_hora_salida.Size = New System.Drawing.Size(107, 22)
        Me.dtp_hora_salida.TabIndex = 3
        '
        'dtp_hora_entrada
        '
        Me.dtp_hora_entrada.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hora_entrada.CustomFormat = ""
        Me.dtp_hora_entrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hora_entrada.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_hora_entrada.Location = New System.Drawing.Point(123, 18)
        Me.dtp_hora_entrada.Name = "dtp_hora_entrada"
        Me.dtp_hora_entrada.ShowUpDown = True
        Me.dtp_hora_entrada.Size = New System.Drawing.Size(107, 22)
        Me.dtp_hora_entrada.TabIndex = 4
        '
        'ofd_foto
        '
        Me.ofd_foto.FileName = "OpenFileDialog1"
        '
        'frm_colaboradores2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 645)
        Me.Controls.Add(Me.Tab_colaboradores)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lst_colaboradores)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_colaboradores2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colaboradores"
        Me.GroupBox1.ResumeLayout(False)
        Me.Tab_colaboradores.ResumeLayout(False)
        Me.Tab_generales.ResumeLayout(False)
        Me.Tab_generales.PerformLayout()
        CType(Me.huella_digital, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_unidad.ResumeLayout(False)
        Me.gb_unidad.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Tab_domicilio.ResumeLayout(False)
        Me.Tab_domicilio.PerformLayout()
        Me.panel_domicilio.ResumeLayout(False)
        Me.panel_domicilio.PerformLayout()
        Me.Tab_horario.ResumeLayout(False)
        Me.Tab_horario.PerformLayout()
        CType(Me.tb_minutos_tolerancia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lst_colaboradores As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents Tab_colaboradores As System.Windows.Forms.TabControl
    Friend WithEvents Tab_generales As System.Windows.Forms.TabPage
    Friend WithEvents gb_unidad As System.Windows.Forms.GroupBox
    Friend WithEvents cb_perfil As System.Windows.Forms.ComboBox
    Friend WithEvents tb_curp As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents tb_alias As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents tb_rfcF As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_emailF As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents tb_apellidoM As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tb_apellidoP As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tab_horario As System.Windows.Forms.TabPage
    Friend WithEvents tb_minutos_tolerancia As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtp_hora_salida As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_hora_entrada As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tab_domicilio As System.Windows.Forms.TabPage
    Friend WithEvents chb_domicilio As System.Windows.Forms.CheckBox
    Friend WithEvents panel_domicilio As System.Windows.Forms.Panel
    Friend WithEvents tb_municipio As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tb_calle As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tb_pais As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents tb_estado As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tb_poblacion As System.Windows.Forms.TextBox
    Friend WithEvents tb_cp As System.Windows.Forms.TextBox
    Friend WithEvents tb_num_int As System.Windows.Forms.TextBox
    Friend WithEvents tb_num_ext As System.Windows.Forms.TextBox
    Friend WithEvents tb_colonia As System.Windows.Forms.TextBox
    Friend WithEvents pb_imagen As System.Windows.Forms.PictureBox
    Friend WithEvents btn_eliminar_imagen As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_imagen As System.Windows.Forms.Button
    Friend WithEvents linea_estado As System.Windows.Forms.Label
    Friend WithEvents accion As System.Windows.Forms.Label
    Friend WithEvents btn_detener_lector As System.Windows.Forms.Button
    Friend WithEvents btn_activar_lector As System.Windows.Forms.Button
    Friend WithEvents huella_digital As System.Windows.Forms.PictureBox
    Friend WithEvents tb_whatsapp As System.Windows.Forms.TextBox
    Friend WithEvents tb_tel_cel As System.Windows.Forms.TextBox
    Friend WithEvents tb_tel_fijo As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_confirmar As System.Windows.Forms.TextBox
    Friend WithEvents tb_usuario As System.Windows.Forms.TextBox
    Friend WithEvents tb_password As System.Windows.Forms.TextBox
    Friend WithEvents ofd_foto As System.Windows.Forms.OpenFileDialog
End Class
