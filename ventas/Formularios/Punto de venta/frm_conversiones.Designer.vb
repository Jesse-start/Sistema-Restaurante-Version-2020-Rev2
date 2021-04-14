<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_conversiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_conversiones))
        Me.gb_conversion = New System.Windows.Forms.GroupBox()
        Me.tb_cantidad_destino = New System.Windows.Forms.TextBox()
        Me.tb_cantidad_origen = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btn_convertir = New System.Windows.Forms.Button()
        Me.lbl_existencia_destino = New System.Windows.Forms.Label()
        Me.lbl_existencia_origen = New System.Windows.Forms.Label()
        Me.lbl_producto_destino = New System.Windows.Forms.Label()
        Me.lbl_producto_origen = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_producto = New System.Windows.Forms.ComboBox()
        Me.pb_producto_destino = New System.Windows.Forms.PictureBox()
        Me.pb_producto_origen = New System.Windows.Forms.PictureBox()
        Me.cb_almacenes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gb_paquetes = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dg_paquetes = New System.Windows.Forms.DataGrid()
        Me.cb_paquete_cantidad = New System.Windows.Forms.NumericUpDown()
        Me.lbl_paquete_cantidad = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_generar_paquetes = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_paquete_existencias = New System.Windows.Forms.Label()
        Me.lbl_paquete_nombre = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cb_paquete = New System.Windows.Forms.ComboBox()
        Me.pb_paquete = New System.Windows.Forms.PictureBox()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gb_conversion.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_producto_destino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_producto_origen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_paquetes.SuspendLayout()
        CType(Me.dg_paquetes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_paquete_cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_paquete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gb_conversion
        '
        Me.gb_conversion.Controls.Add(Me.tb_cantidad_destino)
        Me.gb_conversion.Controls.Add(Me.tb_cantidad_origen)
        Me.gb_conversion.Controls.Add(Me.PictureBox3)
        Me.gb_conversion.Controls.Add(Me.btn_convertir)
        Me.gb_conversion.Controls.Add(Me.lbl_existencia_destino)
        Me.gb_conversion.Controls.Add(Me.lbl_existencia_origen)
        Me.gb_conversion.Controls.Add(Me.lbl_producto_destino)
        Me.gb_conversion.Controls.Add(Me.lbl_producto_origen)
        Me.gb_conversion.Controls.Add(Me.Label1)
        Me.gb_conversion.Controls.Add(Me.cb_producto)
        Me.gb_conversion.Controls.Add(Me.pb_producto_destino)
        Me.gb_conversion.Controls.Add(Me.pb_producto_origen)
        Me.gb_conversion.Enabled = False
        Me.gb_conversion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_conversion.Location = New System.Drawing.Point(6, 11)
        Me.gb_conversion.Name = "gb_conversion"
        Me.gb_conversion.Size = New System.Drawing.Size(651, 319)
        Me.gb_conversion.TabIndex = 3
        Me.gb_conversion.TabStop = False
        Me.gb_conversion.Text = "Seleccione los productos a convertir"
        '
        'tb_cantidad_destino
        '
        Me.tb_cantidad_destino.Location = New System.Drawing.Point(434, 93)
        Me.tb_cantidad_destino.Name = "tb_cantidad_destino"
        Me.tb_cantidad_destino.Size = New System.Drawing.Size(64, 27)
        Me.tb_cantidad_destino.TabIndex = 45
        '
        'tb_cantidad_origen
        '
        Me.tb_cantidad_origen.Location = New System.Drawing.Point(157, 93)
        Me.tb_cantidad_origen.Name = "tb_cantidad_origen"
        Me.tb_cantidad_origen.Size = New System.Drawing.Size(64, 27)
        Me.tb_cantidad_origen.TabIndex = 45
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox3.ErrorImage = Nothing
        Me.PictureBox3.Location = New System.Drawing.Point(291, 93)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(81, 71)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'btn_convertir
        '
        Me.btn_convertir.BackColor = System.Drawing.Color.White
        Me.btn_convertir.Enabled = False
        Me.btn_convertir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_convertir.Image = CType(resources.GetObject("btn_convertir.Image"), System.Drawing.Image)
        Me.btn_convertir.Location = New System.Drawing.Point(236, 246)
        Me.btn_convertir.Name = "btn_convertir"
        Me.btn_convertir.Size = New System.Drawing.Size(169, 67)
        Me.btn_convertir.TabIndex = 7
        Me.btn_convertir.Text = "Convertir"
        Me.btn_convertir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_convertir.UseVisualStyleBackColor = False
        '
        'lbl_existencia_destino
        '
        Me.lbl_existencia_destino.AutoSize = True
        Me.lbl_existencia_destino.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_existencia_destino.Location = New System.Drawing.Point(399, 207)
        Me.lbl_existencia_destino.MaximumSize = New System.Drawing.Size(170, 0)
        Me.lbl_existencia_destino.MinimumSize = New System.Drawing.Size(170, 0)
        Me.lbl_existencia_destino.Name = "lbl_existencia_destino"
        Me.lbl_existencia_destino.Size = New System.Drawing.Size(170, 19)
        Me.lbl_existencia_destino.TabIndex = 4
        Me.lbl_existencia_destino.Text = "--"
        Me.lbl_existencia_destino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_existencia_origen
        '
        Me.lbl_existencia_origen.AutoSize = True
        Me.lbl_existencia_origen.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_existencia_origen.Location = New System.Drawing.Point(82, 207)
        Me.lbl_existencia_origen.MaximumSize = New System.Drawing.Size(170, 0)
        Me.lbl_existencia_origen.MinimumSize = New System.Drawing.Size(170, 0)
        Me.lbl_existencia_origen.Name = "lbl_existencia_origen"
        Me.lbl_existencia_origen.Size = New System.Drawing.Size(170, 19)
        Me.lbl_existencia_origen.TabIndex = 4
        Me.lbl_existencia_origen.Text = "--"
        Me.lbl_existencia_origen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_producto_destino
        '
        Me.lbl_producto_destino.AutoSize = True
        Me.lbl_producto_destino.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_producto_destino.Location = New System.Drawing.Point(399, 170)
        Me.lbl_producto_destino.MaximumSize = New System.Drawing.Size(170, 0)
        Me.lbl_producto_destino.MinimumSize = New System.Drawing.Size(170, 0)
        Me.lbl_producto_destino.Name = "lbl_producto_destino"
        Me.lbl_producto_destino.Size = New System.Drawing.Size(170, 19)
        Me.lbl_producto_destino.TabIndex = 3
        Me.lbl_producto_destino.Text = "--"
        Me.lbl_producto_destino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_producto_origen
        '
        Me.lbl_producto_origen.AutoSize = True
        Me.lbl_producto_origen.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_producto_origen.Location = New System.Drawing.Point(82, 170)
        Me.lbl_producto_origen.MaximumSize = New System.Drawing.Size(170, 0)
        Me.lbl_producto_origen.MinimumSize = New System.Drawing.Size(170, 0)
        Me.lbl_producto_origen.Name = "lbl_producto_origen"
        Me.lbl_producto_origen.Size = New System.Drawing.Size(170, 19)
        Me.lbl_producto_origen.TabIndex = 3
        Me.lbl_producto_origen.Text = "--"
        Me.lbl_producto_origen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Producto:"
        '
        'cb_producto
        '
        Me.cb_producto.FormattingEnabled = True
        Me.cb_producto.Location = New System.Drawing.Point(86, 26)
        Me.cb_producto.Name = "cb_producto"
        Me.cb_producto.Size = New System.Drawing.Size(286, 27)
        Me.cb_producto.TabIndex = 1
        '
        'pb_producto_destino
        '
        Me.pb_producto_destino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_producto_destino.Location = New System.Drawing.Point(504, 68)
        Me.pb_producto_destino.Name = "pb_producto_destino"
        Me.pb_producto_destino.Size = New System.Drawing.Size(70, 70)
        Me.pb_producto_destino.TabIndex = 0
        Me.pb_producto_destino.TabStop = False
        '
        'pb_producto_origen
        '
        Me.pb_producto_origen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_producto_origen.Location = New System.Drawing.Point(71, 68)
        Me.pb_producto_origen.Name = "pb_producto_origen"
        Me.pb_producto_origen.Size = New System.Drawing.Size(70, 70)
        Me.pb_producto_origen.TabIndex = 0
        Me.pb_producto_origen.TabStop = False
        '
        'cb_almacenes
        '
        Me.cb_almacenes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_almacenes.FormattingEnabled = True
        Me.cb_almacenes.Location = New System.Drawing.Point(189, 9)
        Me.cb_almacenes.Name = "cb_almacenes"
        Me.cb_almacenes.Size = New System.Drawing.Size(224, 29)
        Me.cb_almacenes.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Seleccione Almacen:"
        '
        'gb_paquetes
        '
        Me.gb_paquetes.Controls.Add(Me.Button1)
        Me.gb_paquetes.Controls.Add(Me.Button2)
        Me.gb_paquetes.Controls.Add(Me.dg_paquetes)
        Me.gb_paquetes.Controls.Add(Me.cb_paquete_cantidad)
        Me.gb_paquetes.Controls.Add(Me.lbl_paquete_cantidad)
        Me.gb_paquetes.Controls.Add(Me.PictureBox1)
        Me.gb_paquetes.Controls.Add(Me.btn_generar_paquetes)
        Me.gb_paquetes.Controls.Add(Me.Label5)
        Me.gb_paquetes.Controls.Add(Me.lbl_paquete_existencias)
        Me.gb_paquetes.Controls.Add(Me.lbl_paquete_nombre)
        Me.gb_paquetes.Controls.Add(Me.Label11)
        Me.gb_paquetes.Controls.Add(Me.cb_paquete)
        Me.gb_paquetes.Controls.Add(Me.pb_paquete)
        Me.gb_paquetes.Enabled = False
        Me.gb_paquetes.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_paquetes.Location = New System.Drawing.Point(6, 6)
        Me.gb_paquetes.Name = "gb_paquetes"
        Me.gb_paquetes.Size = New System.Drawing.Size(651, 324)
        Me.gb_paquetes.TabIndex = 3
        Me.gb_paquetes.TabStop = False
        Me.gb_paquetes.Text = "Generador de paquetes"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(584, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 39)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "-"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(527, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(51, 39)
        Me.Button2.TabIndex = 43
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'dg_paquetes
        '
        Me.dg_paquetes.AllowDrop = True
        Me.dg_paquetes.AllowNavigation = False
        Me.dg_paquetes.AllowSorting = False
        Me.dg_paquetes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.dg_paquetes.CaptionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dg_paquetes.CaptionForeColor = System.Drawing.Color.White
        Me.dg_paquetes.DataMember = ""
        Me.dg_paquetes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_paquetes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_paquetes.Location = New System.Drawing.Point(180, 62)
        Me.dg_paquetes.Name = "dg_paquetes"
        Me.dg_paquetes.ReadOnly = True
        Me.dg_paquetes.Size = New System.Drawing.Size(455, 173)
        Me.dg_paquetes.TabIndex = 39
        '
        'cb_paquete_cantidad
        '
        Me.cb_paquete_cantidad.DecimalPlaces = 2
        Me.cb_paquete_cantidad.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_paquete_cantidad.Location = New System.Drawing.Point(448, 25)
        Me.cb_paquete_cantidad.Name = "cb_paquete_cantidad"
        Me.cb_paquete_cantidad.Size = New System.Drawing.Size(64, 31)
        Me.cb_paquete_cantidad.TabIndex = 38
        '
        'lbl_paquete_cantidad
        '
        Me.lbl_paquete_cantidad.AutoSize = True
        Me.lbl_paquete_cantidad.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_paquete_cantidad.Location = New System.Drawing.Point(10, 100)
        Me.lbl_paquete_cantidad.Name = "lbl_paquete_cantidad"
        Me.lbl_paquete_cantidad.Size = New System.Drawing.Size(20, 18)
        Me.lbl_paquete_cantidad.TabIndex = 9
        Me.lbl_paquete_cantidad.Text = "--"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ventas.My.Resources.Resources._50CENTAVOS
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(151, 100)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 18)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'btn_generar_paquetes
        '
        Me.btn_generar_paquetes.BackColor = System.Drawing.Color.White
        Me.btn_generar_paquetes.Enabled = False
        Me.btn_generar_paquetes.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_generar_paquetes.Image = CType(resources.GetObject("btn_generar_paquetes.Image"), System.Drawing.Image)
        Me.btn_generar_paquetes.Location = New System.Drawing.Point(251, 241)
        Me.btn_generar_paquetes.Name = "btn_generar_paquetes"
        Me.btn_generar_paquetes.Size = New System.Drawing.Size(176, 77)
        Me.btn_generar_paquetes.TabIndex = 7
        Me.btn_generar_paquetes.Text = "Generar Paquetes"
        Me.btn_generar_paquetes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_generar_paquetes.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(361, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Cantidad:"
        '
        'lbl_paquete_existencias
        '
        Me.lbl_paquete_existencias.AutoSize = True
        Me.lbl_paquete_existencias.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_paquete_existencias.Location = New System.Drawing.Point(15, 185)
        Me.lbl_paquete_existencias.MaximumSize = New System.Drawing.Size(170, 0)
        Me.lbl_paquete_existencias.MinimumSize = New System.Drawing.Size(170, 0)
        Me.lbl_paquete_existencias.Name = "lbl_paquete_existencias"
        Me.lbl_paquete_existencias.Size = New System.Drawing.Size(170, 16)
        Me.lbl_paquete_existencias.TabIndex = 4
        Me.lbl_paquete_existencias.Text = "--"
        Me.lbl_paquete_existencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_paquete_nombre
        '
        Me.lbl_paquete_nombre.AutoSize = True
        Me.lbl_paquete_nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_paquete_nombre.Location = New System.Drawing.Point(15, 148)
        Me.lbl_paquete_nombre.MaximumSize = New System.Drawing.Size(170, 0)
        Me.lbl_paquete_nombre.MinimumSize = New System.Drawing.Size(170, 0)
        Me.lbl_paquete_nombre.Name = "lbl_paquete_nombre"
        Me.lbl_paquete_nombre.Size = New System.Drawing.Size(170, 16)
        Me.lbl_paquete_nombre.TabIndex = 3
        Me.lbl_paquete_nombre.Text = "--"
        Me.lbl_paquete_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 18)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Paquete:"
        '
        'cb_paquete
        '
        Me.cb_paquete.FormattingEnabled = True
        Me.cb_paquete.Location = New System.Drawing.Point(89, 25)
        Me.cb_paquete.Name = "cb_paquete"
        Me.cb_paquete.Size = New System.Drawing.Size(266, 27)
        Me.cb_paquete.TabIndex = 1
        '
        'pb_paquete
        '
        Me.pb_paquete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pb_paquete.Location = New System.Drawing.Point(65, 75)
        Me.pb_paquete.Name = "pb_paquete"
        Me.pb_paquete.Size = New System.Drawing.Size(70, 70)
        Me.pb_paquete.TabIndex = 0
        Me.pb_paquete.TabStop = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(541, 423)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(137, 54)
        Me.btn_salir.TabIndex = 77
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(7, 47)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(676, 370)
        Me.TabControl1.TabIndex = 78
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gb_conversion)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(668, 336)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Conversiones"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gb_paquetes)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(668, 336)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Generador de paquetes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frm_conversiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(691, 489)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.cb_almacenes)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_conversiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conversiones"
        Me.gb_conversion.ResumeLayout(False)
        Me.gb_conversion.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_producto_destino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_producto_origen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_paquetes.ResumeLayout(False)
        Me.gb_paquetes.PerformLayout()
        CType(Me.dg_paquetes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_paquete_cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_paquete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gb_conversion As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_convertir As System.Windows.Forms.Button
    Friend WithEvents lbl_existencia_destino As System.Windows.Forms.Label
    Friend WithEvents lbl_existencia_origen As System.Windows.Forms.Label
    Friend WithEvents lbl_producto_destino As System.Windows.Forms.Label
    Friend WithEvents lbl_producto_origen As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_producto As System.Windows.Forms.ComboBox
    Friend WithEvents pb_producto_destino As System.Windows.Forms.PictureBox
    Friend WithEvents pb_producto_origen As System.Windows.Forms.PictureBox
    Friend WithEvents cb_almacenes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gb_paquetes As System.Windows.Forms.GroupBox
    Friend WithEvents cb_paquete_cantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl_paquete_cantidad As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_generar_paquetes As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_paquete_existencias As System.Windows.Forms.Label
    Friend WithEvents lbl_paquete_nombre As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_paquete As System.Windows.Forms.ComboBox
    Friend WithEvents pb_paquete As System.Windows.Forms.PictureBox
    Friend WithEvents dg_paquetes As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents tb_cantidad_destino As System.Windows.Forms.TextBox
    Friend WithEvents tb_cantidad_origen As System.Windows.Forms.TextBox
End Class
