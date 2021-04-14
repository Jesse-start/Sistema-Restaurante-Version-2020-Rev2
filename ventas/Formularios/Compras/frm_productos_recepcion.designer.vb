<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_productos_recepcion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_productos_recepcion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.tb_subtotal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tb_otros_impuestos = New System.Windows.Forms.TextBox()
        Me.tb_iva = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.tb_total = New System.Windows.Forms.TextBox()
        Me.dgv_recepcion = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_punto = New System.Windows.Forms.Button()
        Me.chb_teclado = New System.Windows.Forms.CheckBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.m_guardar = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.m_abrir = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.m_nuevo = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.gb_proveedor = New System.Windows.Forms.GroupBox()
        Me.cb_proveedor = New System.Windows.Forms.ComboBox()
        Me.dtp_fecha_remision = New System.Windows.Forms.DateTimePicker()
        Me.tb_NFactura = New System.Windows.Forms.TextBox()
        Me.lblFechaProveedor = New System.Windows.Forms.Label()
        Me.lblFacturaProveedor = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.gb_recepcion = New System.Windows.Forms.GroupBox()
        Me.cb_nombreReceptor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombrePersona = New System.Windows.Forms.Label()
        Me.cb_almacen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha_recepcion = New System.Windows.Forms.DateTimePicker()
        Me.tb_folio = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblFechaRecepcion = New System.Windows.Forms.Label()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.gb_producto = New System.Windows.Forms.GroupBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.tb_codigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgv_recepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.gb_proveedor.SuspendLayout()
        Me.gb_recepcion.SuspendLayout()
        Me.gb_producto.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.dgv_recepcion)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.gb_producto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(879, 693)
        Me.Panel1.TabIndex = 16
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 633)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(770, 60)
        Me.FlowLayoutPanel1.TabIndex = 25
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tb_subtotal)
        Me.GroupBox4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(195, 53)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Subtotal"
        '
        'tb_subtotal
        '
        Me.tb_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_subtotal.Location = New System.Drawing.Point(23, 18)
        Me.tb_subtotal.Name = "tb_subtotal"
        Me.tb_subtotal.ReadOnly = True
        Me.tb_subtotal.Size = New System.Drawing.Size(163, 24)
        Me.tb_subtotal.TabIndex = 0
        Me.tb_subtotal.TabStop = False
        Me.tb_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb_otros_impuestos)
        Me.GroupBox1.Controls.Add(Me.tb_iva)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(209, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 54)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Impuestos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(199, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 21)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Otros:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "I.V.A.:"
        '
        'tb_otros_impuestos
        '
        Me.tb_otros_impuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_otros_impuestos.Location = New System.Drawing.Point(261, 21)
        Me.tb_otros_impuestos.Name = "tb_otros_impuestos"
        Me.tb_otros_impuestos.ReadOnly = True
        Me.tb_otros_impuestos.Size = New System.Drawing.Size(113, 24)
        Me.tb_otros_impuestos.TabIndex = 0
        Me.tb_otros_impuestos.TabStop = False
        Me.tb_otros_impuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tb_iva
        '
        Me.tb_iva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_iva.Location = New System.Drawing.Point(67, 21)
        Me.tb_iva.Name = "tb_iva"
        Me.tb_iva.ReadOnly = True
        Me.tb_iva.Size = New System.Drawing.Size(117, 24)
        Me.tb_iva.TabIndex = 0
        Me.tb_iva.TabStop = False
        Me.tb_iva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tb_total)
        Me.GroupBox5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(609, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(156, 53)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total"
        '
        'tb_total
        '
        Me.tb_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(9, 20)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.ReadOnly = True
        Me.tb_total.Size = New System.Drawing.Size(142, 26)
        Me.tb_total.TabIndex = 0
        Me.tb_total.TabStop = False
        Me.tb_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_recepcion
        '
        Me.dgv_recepcion.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_recepcion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_recepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_recepcion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_recepcion.Location = New System.Drawing.Point(0, 365)
        Me.dgv_recepcion.Name = "dgv_recepcion"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_recepcion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_recepcion.Size = New System.Drawing.Size(776, 265)
        Me.dgv_recepcion.TabIndex = 33
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.btn_reset)
        Me.Panel6.Controls.Add(Me.btn_punto)
        Me.Panel6.Controls.Add(Me.chb_teclado)
        Me.Panel6.Controls.Add(Me.Button14)
        Me.Panel6.Controls.Add(Me.btn_imprimir)
        Me.Panel6.Controls.Add(Me.btn3)
        Me.Panel6.Controls.Add(Me.m_guardar)
        Me.Panel6.Controls.Add(Me.Button10)
        Me.Panel6.Controls.Add(Me.m_abrir)
        Me.Panel6.Controls.Add(Me.btn6)
        Me.Panel6.Controls.Add(Me.m_nuevo)
        Me.Panel6.Controls.Add(Me.btn2)
        Me.Panel6.Controls.Add(Me.btn_salir)
        Me.Panel6.Controls.Add(Me.Button6)
        Me.Panel6.Controls.Add(Me.gb_proveedor)
        Me.Panel6.Controls.Add(Me.btn0)
        Me.Panel6.Controls.Add(Me.gb_recepcion)
        Me.Panel6.Controls.Add(Me.btn5)
        Me.Panel6.Controls.Add(Me.btn1)
        Me.Panel6.Controls.Add(Me.btn9)
        Me.Panel6.Controls.Add(Me.btn4)
        Me.Panel6.Controls.Add(Me.btn7)
        Me.Panel6.Controls.Add(Me.btn8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(879, 290)
        Me.Panel6.TabIndex = 23
        '
        'btn_reset
        '
        Me.btn_reset.BackColor = System.Drawing.Color.White
        Me.btn_reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_reset.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reset.Image = CType(resources.GetObject("btn_reset.Image"), System.Drawing.Image)
        Me.btn_reset.Location = New System.Drawing.Point(731, 215)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(136, 58)
        Me.btn_reset.TabIndex = 20
        Me.btn_reset.Text = "Cant. Cero"
        Me.btn_reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reset.UseVisualStyleBackColor = False
        '
        'btn_punto
        '
        Me.btn_punto.BackColor = System.Drawing.Color.White
        Me.btn_punto.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_punto.Location = New System.Drawing.Point(650, 158)
        Me.btn_punto.Name = "btn_punto"
        Me.btn_punto.Size = New System.Drawing.Size(50, 50)
        Me.btn_punto.TabIndex = 60
        Me.btn_punto.Text = "."
        Me.btn_punto.UseVisualStyleBackColor = False
        '
        'chb_teclado
        '
        Me.chb_teclado.AutoSize = True
        Me.chb_teclado.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_teclado.Location = New System.Drawing.Point(548, 214)
        Me.chb_teclado.MaximumSize = New System.Drawing.Size(200, 50)
        Me.chb_teclado.MinimumSize = New System.Drawing.Size(200, 50)
        Me.chb_teclado.Name = "chb_teclado"
        Me.chb_teclado.Size = New System.Drawing.Size(200, 50)
        Me.chb_teclado.TabIndex = 97
        Me.chb_teclado.Text = "Mostrar teclado numerico al indicar cantidades"
        Me.chb_teclado.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.White
        Me.Button14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(701, 106)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(49, 102)
        Me.Button14.TabIndex = 59
        Me.Button14.Text = "OK"
        Me.Button14.UseVisualStyleBackColor = False
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.White
        Me.btn_imprimir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_imprimir.Image = CType(resources.GetObject("btn_imprimir.Image"), System.Drawing.Image)
        Me.btn_imprimir.Location = New System.Drawing.Point(286, 6)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(89, 87)
        Me.btn_imprimir.TabIndex = 96
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(650, 107)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(50, 50)
        Me.btn3.TabIndex = 58
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'm_guardar
        '
        Me.m_guardar.BackColor = System.Drawing.Color.White
        Me.m_guardar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_guardar.Image = CType(resources.GetObject("m_guardar.Image"), System.Drawing.Image)
        Me.m_guardar.Location = New System.Drawing.Point(195, 6)
        Me.m_guardar.Name = "m_guardar"
        Me.m_guardar.Size = New System.Drawing.Size(85, 87)
        Me.m_guardar.TabIndex = 96
        Me.m_guardar.Text = "Guardar"
        Me.m_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.m_guardar.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(701, 54)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(49, 50)
        Me.Button10.TabIndex = 61
        Me.Button10.Text = "CA"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'm_abrir
        '
        Me.m_abrir.BackColor = System.Drawing.Color.White
        Me.m_abrir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_abrir.Image = CType(resources.GetObject("m_abrir.Image"), System.Drawing.Image)
        Me.m_abrir.Location = New System.Drawing.Point(104, 6)
        Me.m_abrir.Name = "m_abrir"
        Me.m_abrir.Size = New System.Drawing.Size(83, 87)
        Me.m_abrir.TabIndex = 96
        Me.m_abrir.Text = "Abrir"
        Me.m_abrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.m_abrir.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(650, 55)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(50, 50)
        Me.btn6.TabIndex = 64
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'm_nuevo
        '
        Me.m_nuevo.BackColor = System.Drawing.Color.White
        Me.m_nuevo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_nuevo.Image = CType(resources.GetObject("m_nuevo.Image"), System.Drawing.Image)
        Me.m_nuevo.Location = New System.Drawing.Point(15, 6)
        Me.m_nuevo.Name = "m_nuevo"
        Me.m_nuevo.Size = New System.Drawing.Size(83, 87)
        Me.m_nuevo.TabIndex = 96
        Me.m_nuevo.Text = "Nuevo"
        Me.m_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.m_nuevo.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(599, 108)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(50, 50)
        Me.btn2.TabIndex = 63
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(380, 6)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(75, 87)
        Me.btn_salir.TabIndex = 96
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(701, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(49, 50)
        Me.Button6.TabIndex = 62
        Me.Button6.Text = "C"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'gb_proveedor
        '
        Me.gb_proveedor.Controls.Add(Me.cb_proveedor)
        Me.gb_proveedor.Controls.Add(Me.dtp_fecha_remision)
        Me.gb_proveedor.Controls.Add(Me.tb_NFactura)
        Me.gb_proveedor.Controls.Add(Me.lblFechaProveedor)
        Me.gb_proveedor.Controls.Add(Me.lblFacturaProveedor)
        Me.gb_proveedor.Controls.Add(Me.Label18)
        Me.gb_proveedor.Controls.Add(Me.Label21)
        Me.gb_proveedor.Controls.Add(Me.lblProveedor)
        Me.gb_proveedor.Enabled = False
        Me.gb_proveedor.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_proveedor.Location = New System.Drawing.Point(3, 185)
        Me.gb_proveedor.Name = "gb_proveedor"
        Me.gb_proveedor.Size = New System.Drawing.Size(523, 99)
        Me.gb_proveedor.TabIndex = 27
        Me.gb_proveedor.TabStop = False
        Me.gb_proveedor.Text = "Datos Factura"
        '
        'cb_proveedor
        '
        Me.cb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_proveedor.FormattingEnabled = True
        Me.cb_proveedor.Location = New System.Drawing.Point(130, 15)
        Me.cb_proveedor.Name = "cb_proveedor"
        Me.cb_proveedor.Size = New System.Drawing.Size(385, 28)
        Me.cb_proveedor.TabIndex = 43
        '
        'dtp_fecha_remision
        '
        Me.dtp_fecha_remision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_remision.Location = New System.Drawing.Point(390, 49)
        Me.dtp_fecha_remision.Name = "dtp_fecha_remision"
        Me.dtp_fecha_remision.Size = New System.Drawing.Size(124, 26)
        Me.dtp_fecha_remision.TabIndex = 38
        '
        'tb_NFactura
        '
        Me.tb_NFactura.Location = New System.Drawing.Point(130, 49)
        Me.tb_NFactura.Name = "tb_NFactura"
        Me.tb_NFactura.Size = New System.Drawing.Size(112, 26)
        Me.tb_NFactura.TabIndex = 37
        '
        'lblFechaProveedor
        '
        Me.lblFechaProveedor.AutoSize = True
        Me.lblFechaProveedor.Location = New System.Drawing.Point(258, 53)
        Me.lblFechaProveedor.Name = "lblFechaProveedor"
        Me.lblFechaProveedor.Size = New System.Drawing.Size(126, 20)
        Me.lblFechaProveedor.TabIndex = 36
        Me.lblFechaProveedor.Text = "Fecha Remisión:"
        '
        'lblFacturaProveedor
        '
        Me.lblFacturaProveedor.AutoSize = True
        Me.lblFacturaProveedor.Location = New System.Drawing.Point(24, 53)
        Me.lblFacturaProveedor.Name = "lblFacturaProveedor"
        Me.lblFacturaProveedor.Size = New System.Drawing.Size(76, 20)
        Me.lblFacturaProveedor.TabIndex = 35
        Me.lblFacturaProveedor.Text = "Remisión:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(13, 52)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(15, 20)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "*"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(14, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(15, 20)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "*"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(25, 23)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(92, 20)
        Me.lblProveedor.TabIndex = 0
        Me.lblProveedor.Text = "Proveedor:"
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(548, 158)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(101, 50)
        Me.btn0.TabIndex = 53
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'gb_recepcion
        '
        Me.gb_recepcion.Controls.Add(Me.cb_nombreReceptor)
        Me.gb_recepcion.Controls.Add(Me.Label7)
        Me.gb_recepcion.Controls.Add(Me.lblNombrePersona)
        Me.gb_recepcion.Controls.Add(Me.cb_almacen)
        Me.gb_recepcion.Controls.Add(Me.Label2)
        Me.gb_recepcion.Controls.Add(Me.dtp_fecha_recepcion)
        Me.gb_recepcion.Controls.Add(Me.tb_folio)
        Me.gb_recepcion.Controls.Add(Me.label3)
        Me.gb_recepcion.Controls.Add(Me.Label19)
        Me.gb_recepcion.Controls.Add(Me.Label16)
        Me.gb_recepcion.Controls.Add(Me.lblFechaRecepcion)
        Me.gb_recepcion.Enabled = False
        Me.gb_recepcion.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_recepcion.Location = New System.Drawing.Point(3, 99)
        Me.gb_recepcion.Name = "gb_recepcion"
        Me.gb_recepcion.Size = New System.Drawing.Size(523, 85)
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
        Me.cb_nombreReceptor.Location = New System.Drawing.Point(191, 48)
        Me.cb_nombreReceptor.Name = "cb_nombreReceptor"
        Me.cb_nombreReceptor.Size = New System.Drawing.Size(323, 29)
        Me.cb_nombreReceptor.TabIndex = 31
        Me.cb_nombreReceptor.Text = "Seleccione"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 21)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "*"
        '
        'lblNombrePersona
        '
        Me.lblNombrePersona.AutoSize = True
        Me.lblNombrePersona.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePersona.Location = New System.Drawing.Point(21, 53)
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
        Me.cb_almacen.Size = New System.Drawing.Size(52, 28)
        Me.cb_almacen.TabIndex = 28
        Me.cb_almacen.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(378, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "*"
        '
        'dtp_fecha_recepcion
        '
        Me.dtp_fecha_recepcion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_recepcion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_recepcion.Location = New System.Drawing.Point(192, 15)
        Me.dtp_fecha_recepcion.Name = "dtp_fecha_recepcion"
        Me.dtp_fecha_recepcion.Size = New System.Drawing.Size(116, 27)
        Me.dtp_fecha_recepcion.TabIndex = 23
        '
        'tb_folio
        '
        Me.tb_folio.AutoSize = True
        Me.tb_folio.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_folio.Location = New System.Drawing.Point(399, 13)
        Me.tb_folio.Name = "tb_folio"
        Me.tb_folio.Size = New System.Drawing.Size(96, 25)
        Me.tb_folio.TabIndex = 52
        Me.tb_folio.Text = "0000000"
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
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(323, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 24)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "FOLIO:"
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
        Me.lblFechaRecepcion.Location = New System.Drawing.Point(20, 24)
        Me.lblFechaRecepcion.Name = "lblFechaRecepcion"
        Me.lblFechaRecepcion.Size = New System.Drawing.Size(151, 21)
        Me.lblFechaRecepcion.TabIndex = 0
        Me.lblFechaRecepcion.Text = "Fecha Recepcion:"
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(599, 56)
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
        Me.btn1.Location = New System.Drawing.Point(548, 108)
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
        Me.btn9.Location = New System.Drawing.Point(650, 4)
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
        Me.btn4.Location = New System.Drawing.Point(548, 56)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(50, 50)
        Me.btn4.TabIndex = 57
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(548, 5)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(50, 50)
        Me.btn7.TabIndex = 55
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(599, 5)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(50, 50)
        Me.btn8.TabIndex = 56
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'gb_producto
        '
        Me.gb_producto.Controls.Add(Me.btn_buscar)
        Me.gb_producto.Controls.Add(Me.btn_agregar)
        Me.gb_producto.Controls.Add(Me.tb_codigo)
        Me.gb_producto.Controls.Add(Me.Label12)
        Me.gb_producto.Enabled = False
        Me.gb_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_producto.Location = New System.Drawing.Point(356, 297)
        Me.gb_producto.Name = "gb_producto"
        Me.gb_producto.Size = New System.Drawing.Size(429, 72)
        Me.gb_producto.TabIndex = 14
        Me.gb_producto.TabStop = False
        Me.gb_producto.Text = "Producto"
        '
        'btn_buscar
        '
        Me.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(295, 6)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(125, 60)
        Me.btn_buscar.TabIndex = 20
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregar.Location = New System.Drawing.Point(209, 11)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(84, 55)
        Me.btn_agregar.TabIndex = 15
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'tb_codigo
        '
        Me.tb_codigo.Location = New System.Drawing.Point(76, 19)
        Me.tb_codigo.MaxLength = 15
        Me.tb_codigo.Name = "tb_codigo"
        Me.tb_codigo.Size = New System.Drawing.Size(127, 24)
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
        'frm_productos_recepcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 693)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_productos_recepcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recepcion de productos"
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgv_recepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.gb_proveedor.ResumeLayout(False)
        Me.gb_proveedor.PerformLayout()
        Me.gb_recepcion.ResumeLayout(False)
        Me.gb_recepcion.PerformLayout()
        Me.gb_producto.ResumeLayout(False)
        Me.gb_producto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgv_recepcion As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btn_punto As System.Windows.Forms.Button
    Friend WithEvents chb_teclado As System.Windows.Forms.CheckBox
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents btn_imprimir As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents m_guardar As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents m_abrir As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button
    Friend WithEvents m_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Private WithEvents gb_proveedor As System.Windows.Forms.GroupBox
    Friend WithEvents cb_proveedor As System.Windows.Forms.ComboBox
    Private WithEvents dtp_fecha_remision As System.Windows.Forms.DateTimePicker
    Private WithEvents tb_NFactura As System.Windows.Forms.TextBox
    Private WithEvents lblFechaProveedor As System.Windows.Forms.Label
    Private WithEvents lblFacturaProveedor As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents btn0 As System.Windows.Forms.Button
    Private WithEvents gb_recepcion As System.Windows.Forms.GroupBox
    Private WithEvents cb_nombreReceptor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents lblNombrePersona As System.Windows.Forms.Label
    Friend WithEvents cb_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents dtp_fecha_recepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents tb_folio As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents lblFechaRecepcion As System.Windows.Forms.Label
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents gb_producto As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents tb_codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btn9 As System.Windows.Forms.Button
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn7 As System.Windows.Forms.Button
    Friend WithEvents btn8 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_otros_impuestos As System.Windows.Forms.TextBox
    Friend WithEvents tb_iva As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_total As System.Windows.Forms.TextBox
    Friend WithEvents btn_reset As System.Windows.Forms.Button
End Class
