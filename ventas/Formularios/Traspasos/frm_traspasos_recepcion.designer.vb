<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_traspasos_recepcion
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dg_cotizacion = New System.Windows.Forms.DataGridView()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btn_punto = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.tsb_imprimir = New System.Windows.Forms.Button()
        Me.m_guardar = New System.Windows.Forms.Button()
        Me.m_abrir = New System.Windows.Forms.Button()
        Me.m_nuevo = New System.Windows.Forms.Button()
        Me.gb_sucursal = New System.Windows.Forms.GroupBox()
        Me.cb_sucursales = New System.Windows.Forms.ComboBox()
        Me.lbl_sucursal = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblFacturaProveedor = New System.Windows.Forms.Label()
        Me.tb_folio_traspaso = New System.Windows.Forms.TextBox()
        Me.label43 = New System.Windows.Forms.Label()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.tb_folio = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gb_recepcion = New System.Windows.Forms.GroupBox()
        Me.cb_nombreReceptor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombrePersona = New System.Windows.Forms.Label()
        Me.cb_almacen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_recepcion = New System.Windows.Forms.DateTimePicker()
        Me.label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblFechaRecepcion = New System.Windows.Forms.Label()
        Me.gb_producto = New System.Windows.Forms.GroupBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dg_cotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.gb_sucursal.SuspendLayout()
        Me.gb_recepcion.SuspendLayout()
        Me.gb_producto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dg_cotizacion)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(923, 537)
        Me.Panel1.TabIndex = 16
        '
        'dg_cotizacion
        '
        Me.dg_cotizacion.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cotizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dg_cotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_cotizacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dg_cotizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg_cotizacion.Location = New System.Drawing.Point(0, 238)
        Me.dg_cotizacion.Name = "dg_cotizacion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg_cotizacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dg_cotizacion.Size = New System.Drawing.Size(677, 299)
        Me.dg_cotizacion.TabIndex = 33
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.btn_punto)
        Me.Panel7.Controls.Add(Me.Button14)
        Me.Panel7.Controls.Add(Me.btn3)
        Me.Panel7.Controls.Add(Me.Button10)
        Me.Panel7.Controls.Add(Me.btn6)
        Me.Panel7.Controls.Add(Me.btn2)
        Me.Panel7.Controls.Add(Me.Button6)
        Me.Panel7.Controls.Add(Me.btn0)
        Me.Panel7.Controls.Add(Me.btn5)
        Me.Panel7.Controls.Add(Me.btn1)
        Me.Panel7.Controls.Add(Me.btn9)
        Me.Panel7.Controls.Add(Me.btn4)
        Me.Panel7.Controls.Add(Me.btn8)
        Me.Panel7.Controls.Add(Me.btn7)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(677, 238)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(246, 299)
        Me.Panel7.TabIndex = 27
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(130, 177)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(50, 50)
        Me.btn_punto.TabIndex = 60
        Me.btn_punto.Text = "."
        Me.btn_punto.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(181, 125)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(49, 102)
        Me.Button14.TabIndex = 59
        Me.Button14.Text = "OK"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(130, 126)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 50)
        Me.btn3.TabIndex = 58
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(181, 73)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(49, 50)
        Me.Button10.TabIndex = 61
        Me.Button10.Text = "CA"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(130, 74)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 50)
        Me.btn6.TabIndex = 64
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(79, 127)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 50)
        Me.btn2.TabIndex = 63
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(181, 23)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(49, 50)
        Me.Button6.TabIndex = 62
        Me.Button6.Text = "C"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(28, 177)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(101, 50)
        Me.btn0.TabIndex = 53
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(79, 75)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(50, 50)
        Me.btn5.TabIndex = 52
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(28, 127)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(50, 50)
        Me.btn1.TabIndex = 51
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(130, 23)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(50, 50)
        Me.btn9.TabIndex = 54
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(28, 75)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 57
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(79, 24)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 56
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(28, 24)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 50)
        Me.btn7.TabIndex = 55
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.tsb_imprimir)
        Me.Panel6.Controls.Add(Me.m_guardar)
        Me.Panel6.Controls.Add(Me.m_abrir)
        Me.Panel6.Controls.Add(Me.m_nuevo)
        Me.Panel6.Controls.Add(Me.gb_sucursal)
        Me.Panel6.Controls.Add(Me.btn_salir)
        Me.Panel6.Controls.Add(Me.tb_folio)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.gb_recepcion)
        Me.Panel6.Controls.Add(Me.gb_producto)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(923, 238)
        Me.Panel6.TabIndex = 23
        '
        'tsb_imprimir
        '
        Me.tsb_imprimir.BackColor = System.Drawing.Color.White
        Me.tsb_imprimir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsb_imprimir.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.tsb_imprimir.Location = New System.Drawing.Point(289, 5)
        Me.tsb_imprimir.Name = "tsb_imprimir"
        Me.tsb_imprimir.Size = New System.Drawing.Size(104, 51)
        Me.tsb_imprimir.TabIndex = 105
        Me.tsb_imprimir.Text = "Imprimir"
        Me.tsb_imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsb_imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.tsb_imprimir.UseVisualStyleBackColor = False
        '
        'm_guardar
        '
        Me.m_guardar.BackColor = System.Drawing.Color.White
        Me.m_guardar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_guardar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.m_guardar.Location = New System.Drawing.Point(182, 5)
        Me.m_guardar.Name = "m_guardar"
        Me.m_guardar.Size = New System.Drawing.Size(104, 51)
        Me.m_guardar.TabIndex = 106
        Me.m_guardar.Text = "Guardar"
        Me.m_guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.m_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.m_guardar.UseVisualStyleBackColor = False
        '
        'm_abrir
        '
        Me.m_abrir.BackColor = System.Drawing.Color.White
        Me.m_abrir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_abrir.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.m_abrir.Location = New System.Drawing.Point(98, 5)
        Me.m_abrir.Name = "m_abrir"
        Me.m_abrir.Size = New System.Drawing.Size(83, 51)
        Me.m_abrir.TabIndex = 104
        Me.m_abrir.Text = "Abrir"
        Me.m_abrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.m_abrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.m_abrir.UseVisualStyleBackColor = False
        '
        'm_nuevo
        '
        Me.m_nuevo.BackColor = System.Drawing.Color.White
        Me.m_nuevo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_nuevo.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.m_nuevo.Location = New System.Drawing.Point(6, 5)
        Me.m_nuevo.Name = "m_nuevo"
        Me.m_nuevo.Size = New System.Drawing.Size(91, 51)
        Me.m_nuevo.TabIndex = 103
        Me.m_nuevo.Text = "Nuevo"
        Me.m_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.m_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.m_nuevo.UseVisualStyleBackColor = False
        '
        'gb_sucursal
        '
        Me.gb_sucursal.Controls.Add(Me.cb_sucursales)
        Me.gb_sucursal.Controls.Add(Me.lbl_sucursal)
        Me.gb_sucursal.Controls.Add(Me.Label23)
        Me.gb_sucursal.Controls.Add(Me.lblFacturaProveedor)
        Me.gb_sucursal.Controls.Add(Me.tb_folio_traspaso)
        Me.gb_sucursal.Controls.Add(Me.label43)
        Me.gb_sucursal.Enabled = False
        Me.gb_sucursal.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_sucursal.Location = New System.Drawing.Point(10, 114)
        Me.gb_sucursal.Name = "gb_sucursal"
        Me.gb_sucursal.Size = New System.Drawing.Size(865, 59)
        Me.gb_sucursal.TabIndex = 97
        Me.gb_sucursal.TabStop = False
        Me.gb_sucursal.Text = "Sucursal de Origen"
        '
        'cb_sucursales
        '
        Me.cb_sucursales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_sucursales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_sucursales.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sucursales.FormattingEnabled = True
        Me.cb_sucursales.Location = New System.Drawing.Point(144, 22)
        Me.cb_sucursales.Name = "cb_sucursales"
        Me.cb_sucursales.Size = New System.Drawing.Size(357, 29)
        Me.cb_sucursales.TabIndex = 31
        Me.cb_sucursales.Text = "Seleccione"
        '
        'lbl_sucursal
        '
        Me.lbl_sucursal.AutoSize = True
        Me.lbl_sucursal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sucursal.Location = New System.Drawing.Point(26, 25)
        Me.lbl_sucursal.Name = "lbl_sucursal"
        Me.lbl_sucursal.Size = New System.Drawing.Size(73, 21)
        Me.lbl_sucursal.TabIndex = 29
        Me.lbl_sucursal.Text = "Sucursal"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(12, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(15, 20)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "*"
        '
        'lblFacturaProveedor
        '
        Me.lblFacturaProveedor.AutoSize = True
        Me.lblFacturaProveedor.Location = New System.Drawing.Point(537, 22)
        Me.lblFacturaProveedor.Name = "lblFacturaProveedor"
        Me.lblFacturaProveedor.Size = New System.Drawing.Size(132, 20)
        Me.lblFacturaProveedor.TabIndex = 35
        Me.lblFacturaProveedor.Text = "Folio de Traspaso"
        '
        'tb_folio_traspaso
        '
        Me.tb_folio_traspaso.Location = New System.Drawing.Point(682, 18)
        Me.tb_folio_traspaso.Name = "tb_folio_traspaso"
        Me.tb_folio_traspaso.Size = New System.Drawing.Size(143, 26)
        Me.tb_folio_traspaso.TabIndex = 37
        '
        'label43
        '
        Me.label43.AutoSize = True
        Me.label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.label43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.label43.Location = New System.Drawing.Point(526, 19)
        Me.label43.Name = "label43"
        Me.label43.Size = New System.Drawing.Size(15, 20)
        Me.label43.TabIndex = 41
        Me.label43.Text = "*"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_salir.Location = New System.Drawing.Point(787, 5)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(124, 51)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'tb_folio
        '
        Me.tb_folio.AutoSize = True
        Me.tb_folio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_folio.Location = New System.Drawing.Point(683, 197)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.Size = New System.Drawing.Size(30, 25)
        Me.tb_folio.TabIndex = 52
        Me.tb_folio.Text = "--"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(446, 198)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(230, 24)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "FOLIO DE RECEPCIÓN"
        '
        'gb_recepcion
        '
        Me.gb_recepcion.Controls.Add(Me.cb_nombreReceptor)
        Me.gb_recepcion.Controls.Add(Me.Label7)
        Me.gb_recepcion.Controls.Add(Me.lblNombrePersona)
        Me.gb_recepcion.Controls.Add(Me.cb_almacen)
        Me.gb_recepcion.Controls.Add(Me.Label2)
        Me.gb_recepcion.Controls.Add(Me.dtp_recepcion)
        Me.gb_recepcion.Controls.Add(Me.label3)
        Me.gb_recepcion.Controls.Add(Me.Label16)
        Me.gb_recepcion.Controls.Add(Me.lblFechaRecepcion)
        Me.gb_recepcion.Enabled = False
        Me.gb_recepcion.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_recepcion.Location = New System.Drawing.Point(10, 58)
        Me.gb_recepcion.Name = "gb_recepcion"
        Me.gb_recepcion.Size = New System.Drawing.Size(766, 50)
        Me.gb_recepcion.TabIndex = 26
        Me.gb_recepcion.TabStop = False
        Me.gb_recepcion.Text = " Recepcion"
        '
        'cb_nombreReceptor
        '
        Me.cb_nombreReceptor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_nombreReceptor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_nombreReceptor.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_nombreReceptor.FormattingEnabled = True
        Me.cb_nombreReceptor.Location = New System.Drawing.Point(491, 14)
        Me.cb_nombreReceptor.Name = "cb_nombreReceptor"
        Me.cb_nombreReceptor.Size = New System.Drawing.Size(258, 29)
        Me.cb_nombreReceptor.TabIndex = 31
        Me.cb_nombreReceptor.Text = "Seleccione"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(308, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 21)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "*"
        '
        'lblNombrePersona
        '
        Me.lblNombrePersona.AutoSize = True
        Me.lblNombrePersona.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePersona.Location = New System.Drawing.Point(321, 19)
        Me.lblNombrePersona.Name = "lblNombrePersona"
        Me.lblNombrePersona.Size = New System.Drawing.Size(163, 21)
        Me.lblNombrePersona.TabIndex = 29
        Me.lblNombrePersona.Text = "Persona que recibe:"
        '
        'cb_almacen
        '
        Me.cb_almacen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_almacen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_almacen.FormattingEnabled = True
        Me.cb_almacen.Location = New System.Drawing.Point(905, 15)
        Me.cb_almacen.Name = "cb_almacen"
        Me.cb_almacen.Size = New System.Drawing.Size(89, 28)
        Me.cb_almacen.TabIndex = 28
        Me.cb_almacen.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(657, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "*"
        '
        'dtp_recepcion
        '
        Me.dtp_recepcion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_recepcion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_recepcion.Location = New System.Drawing.Point(172, 15)
        Me.dtp_recepcion.Name = "dtp_recepcion"
        Me.dtp_recepcion.Size = New System.Drawing.Size(116, 27)
        Me.dtp_recepcion.TabIndex = 23
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(829, 21)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(79, 20)
        Me.label3.TabIndex = 24
        Me.label3.Text = "Almacen:"
        Me.label3.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(9, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 20)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "*"
        '
        'lblFechaRecepcion
        '
        Me.lblFechaRecepcion.AutoSize = True
        Me.lblFechaRecepcion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaRecepcion.Location = New System.Drawing.Point(20, 19)
        Me.lblFechaRecepcion.Name = "lblFechaRecepcion"
        Me.lblFechaRecepcion.Size = New System.Drawing.Size(151, 21)
        Me.lblFechaRecepcion.TabIndex = 0
        Me.lblFechaRecepcion.Text = "Fecha Recepcion:"
        '
        'gb_producto
        '
        Me.gb_producto.Controls.Add(Me.btn_buscar)
        Me.gb_producto.Controls.Add(Me.btn_agregar)
        Me.gb_producto.Controls.Add(Me.tb_codigo)
        Me.gb_producto.Controls.Add(Me.Label12)
        Me.gb_producto.Enabled = False
        Me.gb_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_producto.Location = New System.Drawing.Point(10, 179)
        Me.gb_producto.Name = "gb_producto"
        Me.gb_producto.Size = New System.Drawing.Size(429, 53)
        Me.gb_producto.TabIndex = 14
        Me.gb_producto.TabStop = False
        Me.gb_producto.Text = "Producto"
        '
        'btn_buscar
        '
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.btn_buscar.Location = New System.Drawing.Point(312, 10)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(105, 36)
        Me.btn_buscar.TabIndex = 20
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Location = New System.Drawing.Point(208, 10)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(98, 36)
        Me.btn_agregar.TabIndex = 15
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'tb_codigo
        '
        Me.tb_codigo.Location = New System.Drawing.Point(76, 19)
        Me.tb_codigo.MaxLength = 15
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(126, 24)
        Me.tb_codigo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 20)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Código:"
        '
        'frm_traspasos_recepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_salir
        Me.ClientSize = New System.Drawing.Size(923, 537)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_traspasos_recepcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspasos ( Recepcion de productos)"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dg_cotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.gb_sucursal.ResumeLayout(False)
        Me.gb_sucursal.PerformLayout()
        Me.gb_recepcion.ResumeLayout(False)
        Me.gb_recepcion.PerformLayout()
        Me.gb_producto.ResumeLayout(False)
        Me.gb_producto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dg_cotizacion As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btn_punto As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents gb_sucursal As System.Windows.Forms.GroupBox
    Private WithEvents cb_sucursales As System.Windows.Forms.ComboBox
    Private WithEvents lbl_sucursal As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Private WithEvents lblFacturaProveedor As System.Windows.Forms.Label
    Private WithEvents tb_folio_traspaso As System.Windows.Forms.TextBox
    Friend WithEvents label43 As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents tb_folio As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents gb_recepcion As System.Windows.Forms.GroupBox
    Private WithEvents cb_nombreReceptor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents lblNombrePersona As System.Windows.Forms.Label
    Friend WithEvents cb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents dtp_recepcion As System.Windows.Forms.DateTimePicker
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents lblFechaRecepcion As System.Windows.Forms.Label
    Friend WithEvents gb_producto As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tsb_imprimir As System.Windows.Forms.Button
    Friend WithEvents m_guardar As System.Windows.Forms.Button
    Friend WithEvents m_abrir As System.Windows.Forms.Button
    Friend WithEvents m_nuevo As System.Windows.Forms.Button
End Class
