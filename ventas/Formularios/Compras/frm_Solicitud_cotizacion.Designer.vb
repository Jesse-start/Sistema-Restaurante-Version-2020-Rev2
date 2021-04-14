<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Solicitud_cotizacion
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
        Me.btn_buscar_folio = New System.Windows.Forms.Button()
        Me.gb_opciones_doc = New System.Windows.Forms.GroupBox()
        Me.btn_cancelar_documento = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_reimprimir_documento = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.gb_busqueda = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_busqueda = New System.Windows.Forms.DataGridView()
        Me.cb_opciones_busqueda = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_cliente_busqueda = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_termino = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fecha_busqueda = New System.Windows.Forms.DateTimePicker()
        Me.tb_folio_busqueda = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgv_solicitud_cotizacion = New System.Windows.Forms.DataGridView()
        Me.gb_opciones_doc.SuspendLayout()
        Me.gb_busqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_solicitud_cotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_buscar_folio
        '
        Me.btn_buscar_folio.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar_folio.Location = New System.Drawing.Point(183, 21)
        Me.btn_buscar_folio.Name = "btn_buscar_folio"
        Me.btn_buscar_folio.Size = New System.Drawing.Size(112, 27)
        Me.btn_buscar_folio.TabIndex = 19
        Me.btn_buscar_folio.Text = "Buscar folio"
        Me.btn_buscar_folio.UseVisualStyleBackColor = True
        '
        'gb_opciones_doc
        '
        Me.gb_opciones_doc.Controls.Add(Me.btn_cancelar_documento)
        Me.gb_opciones_doc.Controls.Add(Me.Button1)
        Me.gb_opciones_doc.Controls.Add(Me.Button3)
        Me.gb_opciones_doc.Controls.Add(Me.Button2)
        Me.gb_opciones_doc.Controls.Add(Me.btn_reimprimir_documento)
        Me.gb_opciones_doc.Location = New System.Drawing.Point(362, -5)
        Me.gb_opciones_doc.Name = "gb_opciones_doc"
        Me.gb_opciones_doc.Size = New System.Drawing.Size(500, 66)
        Me.gb_opciones_doc.TabIndex = 9
        Me.gb_opciones_doc.TabStop = False
        '
        'btn_cancelar_documento
        '
        Me.btn_cancelar_documento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar_documento.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_cancelar_documento.Location = New System.Drawing.Point(392, 16)
        Me.btn_cancelar_documento.Name = "btn_cancelar_documento"
        Me.btn_cancelar_documento.Size = New System.Drawing.Size(95, 43)
        Me.btn_cancelar_documento.TabIndex = 5
        Me.btn_cancelar_documento.Text = "Cancelar"
        Me.btn_cancelar_documento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_cancelar_documento.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.Button1.Location = New System.Drawing.Point(19, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 43)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Nuevo"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.Button3.Location = New System.Drawing.Point(207, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(91, 43)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Editar"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.Button2.Location = New System.Drawing.Point(110, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 43)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Guardar"
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_reimprimir_documento
        '
        Me.btn_reimprimir_documento.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimprimir_documento.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_reimprimir_documento.Location = New System.Drawing.Point(301, 16)
        Me.btn_reimprimir_documento.Name = "btn_reimprimir_documento"
        Me.btn_reimprimir_documento.Size = New System.Drawing.Size(85, 43)
        Me.btn_reimprimir_documento.TabIndex = 5
        Me.btn_reimprimir_documento.Text = "Imprimir"
        Me.btn_reimprimir_documento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reimprimir_documento.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(25, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 21)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Folio"
        '
        'gb_busqueda
        '
        Me.gb_busqueda.Controls.Add(Me.GroupBox1)
        Me.gb_busqueda.Controls.Add(Me.cb_opciones_busqueda)
        Me.gb_busqueda.Controls.Add(Me.Label4)
        Me.gb_busqueda.Controls.Add(Me.Label3)
        Me.gb_busqueda.Controls.Add(Me.tb_cliente_busqueda)
        Me.gb_busqueda.Controls.Add(Me.Label2)
        Me.gb_busqueda.Controls.Add(Me.Label1)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_termino)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_inicio)
        Me.gb_busqueda.Controls.Add(Me.dtp_fecha_busqueda)
        Me.gb_busqueda.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_busqueda.Location = New System.Drawing.Point(12, 70)
        Me.gb_busqueda.Name = "gb_busqueda"
        Me.gb_busqueda.Size = New System.Drawing.Size(344, 587)
        Me.gb_busqueda.TabIndex = 8
        Me.gb_busqueda.TabStop = False
        Me.gb_busqueda.Text = "Busqueda"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_busqueda)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(332, 456)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'dgv_busqueda
        '
        Me.dgv_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_busqueda.Location = New System.Drawing.Point(6, 11)
        Me.dgv_busqueda.MultiSelect = False
        Me.dgv_busqueda.Name = "dgv_busqueda"
        Me.dgv_busqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_busqueda.Size = New System.Drawing.Size(317, 439)
        Me.dgv_busqueda.TabIndex = 8
        '
        'cb_opciones_busqueda
        '
        Me.cb_opciones_busqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_opciones_busqueda.FormattingEnabled = True
        Me.cb_opciones_busqueda.Location = New System.Drawing.Point(87, 61)
        Me.cb_opciones_busqueda.Name = "cb_opciones_busqueda"
        Me.cb_opciones_busqueda.Size = New System.Drawing.Size(136, 28)
        Me.cb_opciones_busqueda.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mostrar:"
        '
        'tb_cliente_busqueda
        '
        Me.tb_cliente_busqueda.Location = New System.Drawing.Point(87, 25)
        Me.tb_cliente_busqueda.Name = "tb_cliente_busqueda"
        Me.tb_cliente_busqueda.Size = New System.Drawing.Size(247, 26)
        Me.tb_cliente_busqueda.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "a:"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "De:"
        Me.Label1.Visible = False
        '
        'dtp_fecha_termino
        '
        Me.dtp_fecha_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino.Location = New System.Drawing.Point(229, 99)
        Me.dtp_fecha_termino.Name = "dtp_fecha_termino"
        Me.dtp_fecha_termino.Size = New System.Drawing.Size(105, 26)
        Me.dtp_fecha_termino.TabIndex = 3
        Me.dtp_fecha_termino.Visible = False
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(86, 99)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(110, 26)
        Me.dtp_fecha_inicio.TabIndex = 3
        Me.dtp_fecha_inicio.Visible = False
        '
        'dtp_fecha_busqueda
        '
        Me.dtp_fecha_busqueda.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_busqueda.Location = New System.Drawing.Point(229, 61)
        Me.dtp_fecha_busqueda.Name = "dtp_fecha_busqueda"
        Me.dtp_fecha_busqueda.Size = New System.Drawing.Size(105, 26)
        Me.dtp_fecha_busqueda.TabIndex = 3
        Me.dtp_fecha_busqueda.Visible = False
        '
        'tb_folio_busqueda
        '
        Me.tb_folio_busqueda.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_folio_busqueda.Location = New System.Drawing.Point(96, 21)
        Me.tb_folio_busqueda.Name = "tb_folio_busqueda"
        Me.tb_folio_busqueda.Size = New System.Drawing.Size(63, 27)
        Me.tb_folio_busqueda.TabIndex = 9
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(363, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(611, 601)
        Me.TabControl1.TabIndex = 20
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(603, 575)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Solicitud de Cotizacion"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ComboBox7)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.ComboBox6)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.ComboBox5)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        Me.GroupBox6.Controls.Add(Me.TabControl2)
        Me.GroupBox6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(594, 558)
        Me.GroupBox6.TabIndex = 19
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Informacion"
        '
        'ComboBox7
        '
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(397, 200)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(188, 25)
        Me.ComboBox7.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(307, 205)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 17)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Proveedor 3"
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(397, 169)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(188, 25)
        Me.ComboBox6.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(307, 174)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 17)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Proveedor 2"
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(397, 138)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(188, 25)
        Me.ComboBox5.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(307, 146)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 17)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Proveedor 1"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label19)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox7.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox7.Controls.Add(Me.TextBox4)
        Me.GroupBox7.Controls.Add(Me.TextBox5)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 15)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(582, 116)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(11, 90)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 17)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Elaboró:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(36, 121)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(0, 17)
        Me.Label20.TabIndex = 6
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(42, 17)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Folio:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.DarkRed
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(14, 16)
        Me.Label22.MaximumSize = New System.Drawing.Size(550, 25)
        Me.Label22.MinimumSize = New System.Drawing.Size(550, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(550, 25)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "C ANCELADO"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label22.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(267, 51)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(123, 23)
        Me.DateTimePicker1.TabIndex = 3
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Enabled = False
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker2.Location = New System.Drawing.Point(444, 48)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(123, 23)
        Me.DateTimePicker2.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(84, 84)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(306, 23)
        Me.TextBox4.TabIndex = 3
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(84, 51)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(107, 23)
        Me.TextBox5.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(210, 54)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 17)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Fecha:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(400, 54)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 17)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "Hora:"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(14, 210)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(576, 312)
        Me.TabControl2.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv_solicitud_cotizacion)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(568, 282)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgv_solicitud_cotizacion
        '
        Me.dgv_solicitud_cotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_solicitud_cotizacion.Location = New System.Drawing.Point(4, 6)
        Me.dgv_solicitud_cotizacion.MultiSelect = False
        Me.dgv_solicitud_cotizacion.Name = "dgv_solicitud_cotizacion"
        Me.dgv_solicitud_cotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_solicitud_cotizacion.Size = New System.Drawing.Size(558, 268)
        Me.dgv_solicitud_cotizacion.TabIndex = 0
        '
        'frm_Solicitud_cotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 669)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gb_opciones_doc)
        Me.Controls.Add(Me.btn_buscar_folio)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.gb_busqueda)
        Me.Controls.Add(Me.tb_folio_busqueda)
        Me.Name = "frm_Solicitud_cotizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud Cotizacion"
        Me.gb_opciones_doc.ResumeLayout(False)
        Me.gb_busqueda.ResumeLayout(False)
        Me.gb_busqueda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv_solicitud_cotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_buscar_folio As System.Windows.Forms.Button
    Friend WithEvents gb_opciones_doc As System.Windows.Forms.GroupBox
    Friend WithEvents btn_cancelar_documento As System.Windows.Forms.Button
    Friend WithEvents btn_reimprimir_documento As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gb_busqueda As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_busqueda As System.Windows.Forms.DataGridView
    Friend WithEvents cb_opciones_busqueda As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_cliente_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fecha_busqueda As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_folio_busqueda As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgv_solicitud_cotizacion As System.Windows.Forms.DataGridView
End Class
