<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporteador
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_creditos = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rb_desc = New System.Windows.Forms.RadioButton()
        Me.rb_asc = New System.Windows.Forms.RadioButton()
        Me.cb_ordenar = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_inventario = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_usuario = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_reporte_pdf = New System.Windows.Forms.Button()
        Me.btn_reporte = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_ventas_cliente = New System.Windows.Forms.Button()
        Me.rb_fecha = New System.Windows.Forms.RadioButton()
        Me.rb_todos = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cb_cliente = New System.Windows.Forms.ComboBox()
        Me.dtp_clientes = New System.Windows.Forms.DateTimePicker()
        Me.gb_ajuste_inventario = New System.Windows.Forms.GroupBox()
        Me.btn_ajuste_inventario = New System.Windows.Forms.Button()
        Me.rb_xfecha_ajuste_inventario = New System.Windows.Forms.RadioButton()
        Me.rb_all_ajuste_inventario = New System.Windows.Forms.RadioButton()
        Me.dtp_ajuste_inventario = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rb_asistencia_periodo = New System.Windows.Forms.RadioButton()
        Me.cb_usuario_asistencia = New System.Windows.Forms.ComboBox()
        Me.dtp_asistencia_termino = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtp_asistencia_inicio = New System.Windows.Forms.DateTimePicker()
        Me.btn_reporte_asistencia = New System.Windows.Forms.Button()
        Me.rb_xfecha_asistencia = New System.Windows.Forms.RadioButton()
        Me.rb_all_asistencia = New System.Windows.Forms.RadioButton()
        Me.dtp_fecha_asistencia = New System.Windows.Forms.DateTimePicker()
        Me.gb_reporte_utilidad = New System.Windows.Forms.GroupBox()
        Me.rb_periodo = New System.Windows.Forms.RadioButton()
        Me.dtp_fecha_termino_utilidad = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio_utilidad = New System.Windows.Forms.DateTimePicker()
        Me.btn_utilidad = New System.Windows.Forms.Button()
        Me.rb_xfecha_utilidad = New System.Windows.Forms.RadioButton()
        Me.rb_all_utilidad = New System.Windows.Forms.RadioButton()
        Me.dtp_fecha_utilidad = New System.Windows.Forms.DateTimePicker()
        Me.gb_ingresos = New System.Windows.Forms.GroupBox()
        Me.rb_ingresos_periodo = New System.Windows.Forms.RadioButton()
        Me.dtp_ingresos_fecha_fin = New System.Windows.Forms.DateTimePicker()
        Me.dtp_ingreso_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.btn_reporte_ingreso = New System.Windows.Forms.Button()
        Me.rb_ingresos_fecha = New System.Windows.Forms.RadioButton()
        Me.rb_todos_ingresos = New System.Windows.Forms.RadioButton()
        Me.dtp_ingresos_fecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gb_ajuste_inventario.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gb_reporte_utilidad.SuspendLayout()
        Me.gb_ingresos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btn_creditos)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 71)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(242, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Todos las venta y pedidos actualmente en credito"
        '
        'btn_creditos
        '
        Me.btn_creditos.Location = New System.Drawing.Point(281, 14)
        Me.btn_creditos.Name = "btn_creditos"
        Me.btn_creditos.Size = New System.Drawing.Size(69, 50)
        Me.btn_creditos.TabIndex = 8
        Me.btn_creditos.Text = "Todos los creditos"
        Me.btn_creditos.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.cb_ordenar)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btn_inventario)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 100)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Ordenar por:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rb_desc)
        Me.Panel1.Controls.Add(Me.rb_asc)
        Me.Panel1.Location = New System.Drawing.Point(20, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(211, 29)
        Me.Panel1.TabIndex = 12
        '
        'rb_desc
        '
        Me.rb_desc.AutoSize = True
        Me.rb_desc.Location = New System.Drawing.Point(106, 6)
        Me.rb_desc.Name = "rb_desc"
        Me.rb_desc.Size = New System.Drawing.Size(89, 17)
        Me.rb_desc.TabIndex = 12
        Me.rb_desc.Text = "Descendente"
        Me.rb_desc.UseVisualStyleBackColor = True
        '
        'rb_asc
        '
        Me.rb_asc.AutoSize = True
        Me.rb_asc.Checked = True
        Me.rb_asc.Location = New System.Drawing.Point(16, 6)
        Me.rb_asc.Name = "rb_asc"
        Me.rb_asc.Size = New System.Drawing.Size(82, 17)
        Me.rb_asc.TabIndex = 11
        Me.rb_asc.TabStop = True
        Me.rb_asc.Text = "Ascendente"
        Me.rb_asc.UseVisualStyleBackColor = True
        '
        'cb_ordenar
        '
        Me.cb_ordenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ordenar.FormattingEnabled = True
        Me.cb_ordenar.Items.AddRange(New Object() {"Cantidad", "Codigo", "Producto"})
        Me.cb_ordenar.Location = New System.Drawing.Point(110, 30)
        Me.cb_ordenar.Name = "cb_ordenar"
        Me.cb_ordenar.Size = New System.Drawing.Size(121, 21)
        Me.cb_ordenar.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Ver todo el inventario actual"
        '
        'btn_inventario
        '
        Me.btn_inventario.Enabled = False
        Me.btn_inventario.Location = New System.Drawing.Point(283, 25)
        Me.btn_inventario.Name = "btn_inventario"
        Me.btn_inventario.Size = New System.Drawing.Size(69, 54)
        Me.btn_inventario.TabIndex = 8
        Me.btn_inventario.Text = "Inventario"
        Me.btn_inventario.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cb_usuario)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.dtp_fecha)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.btn_reporte_pdf)
        Me.GroupBox3.Controls.Add(Me.btn_reporte)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(365, 94)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(273, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Generar reporte de ventas,regalias,cancelaciones,retiros"
        '
        'cb_usuario
        '
        Me.cb_usuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_usuario.FormattingEnabled = True
        Me.cb_usuario.Location = New System.Drawing.Point(57, 64)
        Me.cb_usuario.Name = "cb_usuario"
        Me.cb_usuario.Size = New System.Drawing.Size(215, 21)
        Me.cb_usuario.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Usuario:"
        '
        'dtp_fecha
        '
        Me.dtp_fecha.Location = New System.Drawing.Point(57, 33)
        Me.dtp_fecha.Name = "dtp_fecha"
        Me.dtp_fecha.Size = New System.Drawing.Size(215, 20)
        Me.dtp_fecha.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Fecha:"
        '
        'btn_reporte_pdf
        '
        Me.btn_reporte_pdf.Enabled = False
        Me.btn_reporte_pdf.Location = New System.Drawing.Point(371, 31)
        Me.btn_reporte_pdf.Name = "btn_reporte_pdf"
        Me.btn_reporte_pdf.Size = New System.Drawing.Size(58, 54)
        Me.btn_reporte_pdf.TabIndex = 8
        Me.btn_reporte_pdf.Text = "Generar reporte PDF"
        Me.btn_reporte_pdf.UseVisualStyleBackColor = True
        '
        'btn_reporte
        '
        Me.btn_reporte.Enabled = False
        Me.btn_reporte.Location = New System.Drawing.Point(287, 31)
        Me.btn_reporte.Name = "btn_reporte"
        Me.btn_reporte.Size = New System.Drawing.Size(63, 54)
        Me.btn_reporte.TabIndex = 8
        Me.btn_reporte.Text = "Generar Reporte"
        Me.btn_reporte.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_ventas_cliente)
        Me.GroupBox4.Controls.Add(Me.rb_fecha)
        Me.GroupBox4.Controls.Add(Me.rb_todos)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.cb_cliente)
        Me.GroupBox4.Controls.Add(Me.dtp_clientes)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 280)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(365, 106)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Registro de ventas por cliente"
        '
        'btn_ventas_cliente
        '
        Me.btn_ventas_cliente.Enabled = False
        Me.btn_ventas_cliente.Location = New System.Drawing.Point(281, 29)
        Me.btn_ventas_cliente.Name = "btn_ventas_cliente"
        Me.btn_ventas_cliente.Size = New System.Drawing.Size(69, 51)
        Me.btn_ventas_cliente.TabIndex = 14
        Me.btn_ventas_cliente.Text = "Ventas por cliente"
        Me.btn_ventas_cliente.UseVisualStyleBackColor = True
        '
        'rb_fecha
        '
        Me.rb_fecha.AutoSize = True
        Me.rb_fecha.Location = New System.Drawing.Point(13, 42)
        Me.rb_fecha.Name = "rb_fecha"
        Me.rb_fecha.Size = New System.Drawing.Size(58, 17)
        Me.rb_fecha.TabIndex = 13
        Me.rb_fecha.TabStop = True
        Me.rb_fecha.Text = "Fecha:"
        Me.rb_fecha.UseVisualStyleBackColor = True
        '
        'rb_todos
        '
        Me.rb_todos.AutoSize = True
        Me.rb_todos.Checked = True
        Me.rb_todos.Location = New System.Drawing.Point(13, 19)
        Me.rb_todos.Name = "rb_todos"
        Me.rb_todos.Size = New System.Drawing.Size(113, 17)
        Me.rb_todos.TabIndex = 13
        Me.rb_todos.TabStop = True
        Me.rb_todos.Text = "Todos los registros"
        Me.rb_todos.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Cliente:"
        '
        'cb_cliente
        '
        Me.cb_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_cliente.FormattingEnabled = True
        Me.cb_cliente.Location = New System.Drawing.Point(59, 74)
        Me.cb_cliente.Name = "cb_cliente"
        Me.cb_cliente.Size = New System.Drawing.Size(198, 21)
        Me.cb_cliente.TabIndex = 12
        '
        'dtp_clientes
        '
        Me.dtp_clientes.Location = New System.Drawing.Point(68, 42)
        Me.dtp_clientes.Name = "dtp_clientes"
        Me.dtp_clientes.Size = New System.Drawing.Size(204, 20)
        Me.dtp_clientes.TabIndex = 10
        '
        'gb_ajuste_inventario
        '
        Me.gb_ajuste_inventario.Controls.Add(Me.btn_ajuste_inventario)
        Me.gb_ajuste_inventario.Controls.Add(Me.rb_xfecha_ajuste_inventario)
        Me.gb_ajuste_inventario.Controls.Add(Me.rb_all_ajuste_inventario)
        Me.gb_ajuste_inventario.Controls.Add(Me.dtp_ajuste_inventario)
        Me.gb_ajuste_inventario.Location = New System.Drawing.Point(375, 4)
        Me.gb_ajuste_inventario.Name = "gb_ajuste_inventario"
        Me.gb_ajuste_inventario.Size = New System.Drawing.Size(375, 93)
        Me.gb_ajuste_inventario.TabIndex = 12
        Me.gb_ajuste_inventario.TabStop = False
        Me.gb_ajuste_inventario.Text = "Ajuste de inventario"
        Me.gb_ajuste_inventario.UseCompatibleTextRendering = True
        '
        'btn_ajuste_inventario
        '
        Me.btn_ajuste_inventario.Location = New System.Drawing.Point(299, 20)
        Me.btn_ajuste_inventario.Name = "btn_ajuste_inventario"
        Me.btn_ajuste_inventario.Size = New System.Drawing.Size(63, 54)
        Me.btn_ajuste_inventario.TabIndex = 14
        Me.btn_ajuste_inventario.Text = "Ajuste de inventario"
        Me.btn_ajuste_inventario.UseVisualStyleBackColor = True
        '
        'rb_xfecha_ajuste_inventario
        '
        Me.rb_xfecha_ajuste_inventario.AutoSize = True
        Me.rb_xfecha_ajuste_inventario.Location = New System.Drawing.Point(13, 42)
        Me.rb_xfecha_ajuste_inventario.Name = "rb_xfecha_ajuste_inventario"
        Me.rb_xfecha_ajuste_inventario.Size = New System.Drawing.Size(58, 17)
        Me.rb_xfecha_ajuste_inventario.TabIndex = 13
        Me.rb_xfecha_ajuste_inventario.TabStop = True
        Me.rb_xfecha_ajuste_inventario.Text = "Fecha:"
        Me.rb_xfecha_ajuste_inventario.UseVisualStyleBackColor = True
        '
        'rb_all_ajuste_inventario
        '
        Me.rb_all_ajuste_inventario.AutoSize = True
        Me.rb_all_ajuste_inventario.Checked = True
        Me.rb_all_ajuste_inventario.Location = New System.Drawing.Point(13, 19)
        Me.rb_all_ajuste_inventario.Name = "rb_all_ajuste_inventario"
        Me.rb_all_ajuste_inventario.Size = New System.Drawing.Size(113, 17)
        Me.rb_all_ajuste_inventario.TabIndex = 13
        Me.rb_all_ajuste_inventario.TabStop = True
        Me.rb_all_ajuste_inventario.Text = "Todos los registros"
        Me.rb_all_ajuste_inventario.UseVisualStyleBackColor = True
        '
        'dtp_ajuste_inventario
        '
        Me.dtp_ajuste_inventario.Location = New System.Drawing.Point(68, 39)
        Me.dtp_ajuste_inventario.Name = "dtp_ajuste_inventario"
        Me.dtp_ajuste_inventario.Size = New System.Drawing.Size(215, 20)
        Me.dtp_ajuste_inventario.TabIndex = 10
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rb_asistencia_periodo)
        Me.GroupBox5.Controls.Add(Me.cb_usuario_asistencia)
        Me.GroupBox5.Controls.Add(Me.dtp_asistencia_termino)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.dtp_asistencia_inicio)
        Me.GroupBox5.Controls.Add(Me.btn_reporte_asistencia)
        Me.GroupBox5.Controls.Add(Me.rb_xfecha_asistencia)
        Me.GroupBox5.Controls.Add(Me.rb_all_asistencia)
        Me.GroupBox5.Controls.Add(Me.dtp_fecha_asistencia)
        Me.GroupBox5.Location = New System.Drawing.Point(375, 103)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(375, 134)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Control de asistencia"
        Me.GroupBox5.UseCompatibleTextRendering = True
        '
        'rb_asistencia_periodo
        '
        Me.rb_asistencia_periodo.AutoSize = True
        Me.rb_asistencia_periodo.Location = New System.Drawing.Point(13, 68)
        Me.rb_asistencia_periodo.Name = "rb_asistencia_periodo"
        Me.rb_asistencia_periodo.Size = New System.Drawing.Size(73, 17)
        Me.rb_asistencia_periodo.TabIndex = 15
        Me.rb_asistencia_periodo.TabStop = True
        Me.rb_asistencia_periodo.Text = "Perido de:"
        Me.rb_asistencia_periodo.UseVisualStyleBackColor = True
        '
        'cb_usuario_asistencia
        '
        Me.cb_usuario_asistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_usuario_asistencia.FormattingEnabled = True
        Me.cb_usuario_asistencia.Location = New System.Drawing.Point(68, 100)
        Me.cb_usuario_asistencia.Name = "cb_usuario_asistencia"
        Me.cb_usuario_asistencia.Size = New System.Drawing.Size(215, 21)
        Me.cb_usuario_asistencia.TabIndex = 16
        '
        'dtp_asistencia_termino
        '
        Me.dtp_asistencia_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_asistencia_termino.Location = New System.Drawing.Point(195, 66)
        Me.dtp_asistencia_termino.Name = "dtp_asistencia_termino"
        Me.dtp_asistencia_termino.Size = New System.Drawing.Size(88, 20)
        Me.dtp_asistencia_termino.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Usuario:"
        '
        'dtp_asistencia_inicio
        '
        Me.dtp_asistencia_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_asistencia_inicio.Location = New System.Drawing.Point(92, 66)
        Me.dtp_asistencia_inicio.Name = "dtp_asistencia_inicio"
        Me.dtp_asistencia_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_asistencia_inicio.TabIndex = 14
        '
        'btn_reporte_asistencia
        '
        Me.btn_reporte_asistencia.Location = New System.Drawing.Point(299, 20)
        Me.btn_reporte_asistencia.Name = "btn_reporte_asistencia"
        Me.btn_reporte_asistencia.Size = New System.Drawing.Size(63, 54)
        Me.btn_reporte_asistencia.TabIndex = 14
        Me.btn_reporte_asistencia.Text = "Generar Reporte"
        Me.btn_reporte_asistencia.UseVisualStyleBackColor = True
        '
        'rb_xfecha_asistencia
        '
        Me.rb_xfecha_asistencia.AutoSize = True
        Me.rb_xfecha_asistencia.Location = New System.Drawing.Point(13, 42)
        Me.rb_xfecha_asistencia.Name = "rb_xfecha_asistencia"
        Me.rb_xfecha_asistencia.Size = New System.Drawing.Size(58, 17)
        Me.rb_xfecha_asistencia.TabIndex = 13
        Me.rb_xfecha_asistencia.TabStop = True
        Me.rb_xfecha_asistencia.Text = "Fecha:"
        Me.rb_xfecha_asistencia.UseVisualStyleBackColor = True
        '
        'rb_all_asistencia
        '
        Me.rb_all_asistencia.AutoSize = True
        Me.rb_all_asistencia.Checked = True
        Me.rb_all_asistencia.Location = New System.Drawing.Point(13, 19)
        Me.rb_all_asistencia.Name = "rb_all_asistencia"
        Me.rb_all_asistencia.Size = New System.Drawing.Size(113, 17)
        Me.rb_all_asistencia.TabIndex = 13
        Me.rb_all_asistencia.TabStop = True
        Me.rb_all_asistencia.Text = "Todos los registros"
        Me.rb_all_asistencia.UseVisualStyleBackColor = True
        '
        'dtp_fecha_asistencia
        '
        Me.dtp_fecha_asistencia.Location = New System.Drawing.Point(68, 39)
        Me.dtp_fecha_asistencia.Name = "dtp_fecha_asistencia"
        Me.dtp_fecha_asistencia.Size = New System.Drawing.Size(215, 20)
        Me.dtp_fecha_asistencia.TabIndex = 10
        '
        'gb_reporte_utilidad
        '
        Me.gb_reporte_utilidad.Controls.Add(Me.rb_periodo)
        Me.gb_reporte_utilidad.Controls.Add(Me.dtp_fecha_termino_utilidad)
        Me.gb_reporte_utilidad.Controls.Add(Me.dtp_fecha_inicio_utilidad)
        Me.gb_reporte_utilidad.Controls.Add(Me.btn_utilidad)
        Me.gb_reporte_utilidad.Controls.Add(Me.rb_xfecha_utilidad)
        Me.gb_reporte_utilidad.Controls.Add(Me.rb_all_utilidad)
        Me.gb_reporte_utilidad.Controls.Add(Me.dtp_fecha_utilidad)
        Me.gb_reporte_utilidad.Location = New System.Drawing.Point(375, 247)
        Me.gb_reporte_utilidad.Name = "gb_reporte_utilidad"
        Me.gb_reporte_utilidad.Size = New System.Drawing.Size(375, 152)
        Me.gb_reporte_utilidad.TabIndex = 12
        Me.gb_reporte_utilidad.TabStop = False
        Me.gb_reporte_utilidad.Text = "Utilidad"
        Me.gb_reporte_utilidad.UseCompatibleTextRendering = True
        '
        'rb_periodo
        '
        Me.rb_periodo.AutoSize = True
        Me.rb_periodo.Location = New System.Drawing.Point(13, 73)
        Me.rb_periodo.Name = "rb_periodo"
        Me.rb_periodo.Size = New System.Drawing.Size(73, 17)
        Me.rb_periodo.TabIndex = 15
        Me.rb_periodo.TabStop = True
        Me.rb_periodo.Text = "Perido de:"
        Me.rb_periodo.UseVisualStyleBackColor = True
        '
        'dtp_fecha_termino_utilidad
        '
        Me.dtp_fecha_termino_utilidad.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino_utilidad.Location = New System.Drawing.Point(195, 71)
        Me.dtp_fecha_termino_utilidad.Name = "dtp_fecha_termino_utilidad"
        Me.dtp_fecha_termino_utilidad.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_termino_utilidad.TabIndex = 14
        '
        'dtp_fecha_inicio_utilidad
        '
        Me.dtp_fecha_inicio_utilidad.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio_utilidad.Location = New System.Drawing.Point(92, 71)
        Me.dtp_fecha_inicio_utilidad.Name = "dtp_fecha_inicio_utilidad"
        Me.dtp_fecha_inicio_utilidad.Size = New System.Drawing.Size(88, 20)
        Me.dtp_fecha_inicio_utilidad.TabIndex = 14
        '
        'btn_utilidad
        '
        Me.btn_utilidad.Location = New System.Drawing.Point(299, 20)
        Me.btn_utilidad.Name = "btn_utilidad"
        Me.btn_utilidad.Size = New System.Drawing.Size(63, 54)
        Me.btn_utilidad.TabIndex = 14
        Me.btn_utilidad.Text = "Reporte Utilidad"
        Me.btn_utilidad.UseVisualStyleBackColor = True
        '
        'rb_xfecha_utilidad
        '
        Me.rb_xfecha_utilidad.AutoSize = True
        Me.rb_xfecha_utilidad.Location = New System.Drawing.Point(13, 42)
        Me.rb_xfecha_utilidad.Name = "rb_xfecha_utilidad"
        Me.rb_xfecha_utilidad.Size = New System.Drawing.Size(58, 17)
        Me.rb_xfecha_utilidad.TabIndex = 13
        Me.rb_xfecha_utilidad.TabStop = True
        Me.rb_xfecha_utilidad.Text = "Fecha:"
        Me.rb_xfecha_utilidad.UseVisualStyleBackColor = True
        '
        'rb_all_utilidad
        '
        Me.rb_all_utilidad.AutoSize = True
        Me.rb_all_utilidad.Checked = True
        Me.rb_all_utilidad.Location = New System.Drawing.Point(13, 19)
        Me.rb_all_utilidad.Name = "rb_all_utilidad"
        Me.rb_all_utilidad.Size = New System.Drawing.Size(113, 17)
        Me.rb_all_utilidad.TabIndex = 13
        Me.rb_all_utilidad.TabStop = True
        Me.rb_all_utilidad.Text = "Todos los registros"
        Me.rb_all_utilidad.UseVisualStyleBackColor = True
        '
        'dtp_fecha_utilidad
        '
        Me.dtp_fecha_utilidad.Location = New System.Drawing.Point(92, 39)
        Me.dtp_fecha_utilidad.Name = "dtp_fecha_utilidad"
        Me.dtp_fecha_utilidad.Size = New System.Drawing.Size(191, 20)
        Me.dtp_fecha_utilidad.TabIndex = 10
        '
        'gb_ingresos
        '
        Me.gb_ingresos.Controls.Add(Me.rb_ingresos_periodo)
        Me.gb_ingresos.Controls.Add(Me.dtp_ingresos_fecha_fin)
        Me.gb_ingresos.Controls.Add(Me.dtp_ingreso_fecha_inicio)
        Me.gb_ingresos.Controls.Add(Me.btn_reporte_ingreso)
        Me.gb_ingresos.Controls.Add(Me.rb_ingresos_fecha)
        Me.gb_ingresos.Controls.Add(Me.rb_todos_ingresos)
        Me.gb_ingresos.Controls.Add(Me.dtp_ingresos_fecha)
        Me.gb_ingresos.Location = New System.Drawing.Point(4, 398)
        Me.gb_ingresos.Name = "gb_ingresos"
        Me.gb_ingresos.Size = New System.Drawing.Size(365, 113)
        Me.gb_ingresos.TabIndex = 12
        Me.gb_ingresos.TabStop = False
        Me.gb_ingresos.Text = "Reporte Ingresos"
        Me.gb_ingresos.UseCompatibleTextRendering = True
        '
        'rb_ingresos_periodo
        '
        Me.rb_ingresos_periodo.AutoSize = True
        Me.rb_ingresos_periodo.Location = New System.Drawing.Point(13, 73)
        Me.rb_ingresos_periodo.Name = "rb_ingresos_periodo"
        Me.rb_ingresos_periodo.Size = New System.Drawing.Size(73, 17)
        Me.rb_ingresos_periodo.TabIndex = 15
        Me.rb_ingresos_periodo.TabStop = True
        Me.rb_ingresos_periodo.Text = "Perido de:"
        Me.rb_ingresos_periodo.UseVisualStyleBackColor = True
        '
        'dtp_ingresos_fecha_fin
        '
        Me.dtp_ingresos_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ingresos_fecha_fin.Location = New System.Drawing.Point(195, 71)
        Me.dtp_ingresos_fecha_fin.Name = "dtp_ingresos_fecha_fin"
        Me.dtp_ingresos_fecha_fin.Size = New System.Drawing.Size(88, 20)
        Me.dtp_ingresos_fecha_fin.TabIndex = 14
        '
        'dtp_ingreso_fecha_inicio
        '
        Me.dtp_ingreso_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_ingreso_fecha_inicio.Location = New System.Drawing.Point(92, 71)
        Me.dtp_ingreso_fecha_inicio.Name = "dtp_ingreso_fecha_inicio"
        Me.dtp_ingreso_fecha_inicio.Size = New System.Drawing.Size(88, 20)
        Me.dtp_ingreso_fecha_inicio.TabIndex = 14
        '
        'btn_reporte_ingreso
        '
        Me.btn_reporte_ingreso.Location = New System.Drawing.Point(290, 20)
        Me.btn_reporte_ingreso.Name = "btn_reporte_ingreso"
        Me.btn_reporte_ingreso.Size = New System.Drawing.Size(63, 54)
        Me.btn_reporte_ingreso.TabIndex = 14
        Me.btn_reporte_ingreso.Text = "Generar Reporte"
        Me.btn_reporte_ingreso.UseVisualStyleBackColor = True
        '
        'rb_ingresos_fecha
        '
        Me.rb_ingresos_fecha.AutoSize = True
        Me.rb_ingresos_fecha.Location = New System.Drawing.Point(13, 42)
        Me.rb_ingresos_fecha.Name = "rb_ingresos_fecha"
        Me.rb_ingresos_fecha.Size = New System.Drawing.Size(58, 17)
        Me.rb_ingresos_fecha.TabIndex = 13
        Me.rb_ingresos_fecha.TabStop = True
        Me.rb_ingresos_fecha.Text = "Fecha:"
        Me.rb_ingresos_fecha.UseVisualStyleBackColor = True
        '
        'rb_todos_ingresos
        '
        Me.rb_todos_ingresos.AutoSize = True
        Me.rb_todos_ingresos.Checked = True
        Me.rb_todos_ingresos.Location = New System.Drawing.Point(13, 19)
        Me.rb_todos_ingresos.Name = "rb_todos_ingresos"
        Me.rb_todos_ingresos.Size = New System.Drawing.Size(113, 17)
        Me.rb_todos_ingresos.TabIndex = 13
        Me.rb_todos_ingresos.TabStop = True
        Me.rb_todos_ingresos.Text = "Todos los registros"
        Me.rb_todos_ingresos.UseVisualStyleBackColor = True
        '
        'dtp_ingresos_fecha
        '
        Me.dtp_ingresos_fecha.Location = New System.Drawing.Point(92, 39)
        Me.dtp_ingresos_fecha.Name = "dtp_ingresos_fecha"
        Me.dtp_ingresos_fecha.Size = New System.Drawing.Size(191, 20)
        Me.dtp_ingresos_fecha.TabIndex = 10
        '
        'frm_reporteador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 618)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.gb_ingresos)
        Me.Controls.Add(Me.gb_reporte_utilidad)
        Me.Controls.Add(Me.gb_ajuste_inventario)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frm_reporteador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporteador"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gb_ajuste_inventario.ResumeLayout(False)
        Me.gb_ajuste_inventario.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.gb_reporte_utilidad.ResumeLayout(False)
        Me.gb_reporte_utilidad.PerformLayout()
        Me.gb_ingresos.ResumeLayout(False)
        Me.gb_ingresos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_creditos As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_inventario As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cb_usuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_reporte As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rb_desc As System.Windows.Forms.RadioButton
    Friend WithEvents rb_asc As System.Windows.Forms.RadioButton
    Friend WithEvents cb_ordenar As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents btn_ventas_cliente As System.Windows.Forms.Button
    Friend WithEvents rb_fecha As System.Windows.Forms.RadioButton
    Friend WithEvents rb_todos As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_clientes As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_reporte_pdf As System.Windows.Forms.Button
    Friend WithEvents gb_ajuste_inventario As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ajuste_inventario As System.Windows.Forms.Button
    Friend WithEvents rb_xfecha_ajuste_inventario As System.Windows.Forms.RadioButton
    Friend WithEvents rb_all_ajuste_inventario As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_ajuste_inventario As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_reporte_asistencia As System.Windows.Forms.Button
    Friend WithEvents rb_xfecha_asistencia As System.Windows.Forms.RadioButton
    Friend WithEvents rb_all_asistencia As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_fecha_asistencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_usuario_asistencia As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gb_reporte_utilidad As System.Windows.Forms.GroupBox
    Friend WithEvents btn_utilidad As System.Windows.Forms.Button
    Friend WithEvents rb_xfecha_utilidad As System.Windows.Forms.RadioButton
    Friend WithEvents rb_all_utilidad As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_fecha_utilidad As System.Windows.Forms.DateTimePicker
    Friend WithEvents rb_periodo As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_fecha_termino_utilidad As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio_utilidad As System.Windows.Forms.DateTimePicker
    Friend WithEvents rb_asistencia_periodo As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_asistencia_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_asistencia_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents gb_ingresos As System.Windows.Forms.GroupBox
    Friend WithEvents rb_ingresos_periodo As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_ingresos_fecha_fin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_ingreso_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_reporte_ingreso As System.Windows.Forms.Button
    Friend WithEvents rb_ingresos_fecha As System.Windows.Forms.RadioButton
    Friend WithEvents rb_todos_ingresos As System.Windows.Forms.RadioButton
    Friend WithEvents dtp_ingresos_fecha As System.Windows.Forms.DateTimePicker
End Class
