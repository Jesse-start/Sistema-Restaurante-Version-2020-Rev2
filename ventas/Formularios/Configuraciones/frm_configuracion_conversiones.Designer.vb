<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_configuracion_conversiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_configuracion_conversiones))
        Me.gb_detalle = New System.Windows.Forms.GroupBox()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cb_producto_origen = New System.Windows.Forms.ComboBox()
        Me.tb_cantidad_origen = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_producto_salida = New System.Windows.Forms.ComboBox()
        Me.tb_cantidad_destino = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gb_tabla = New System.Windows.Forms.GroupBox()
        Me.btn_quitar = New System.Windows.Forms.Button()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.dg_conversiones = New System.Windows.Forms.DataGrid()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.gb_detalle.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gb_tabla.SuspendLayout()
        CType(Me.dg_conversiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb_detalle
        '
        Me.gb_detalle.Controls.Add(Me.btn_cancelar)
        Me.gb_detalle.Controls.Add(Me.btn_aceptar)
        Me.gb_detalle.Controls.Add(Me.GroupBox3)
        Me.gb_detalle.Controls.Add(Me.GroupBox2)
        Me.gb_detalle.Enabled = False
        Me.gb_detalle.Location = New System.Drawing.Point(7, 307)
        Me.gb_detalle.Name = "gb_detalle"
        Me.gb_detalle.Size = New System.Drawing.Size(542, 125)
        Me.gb_detalle.TabIndex = 8
        Me.gb_detalle.TabStop = False
        Me.gb_detalle.Text = "Nueva Conversion"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(438, 83)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_cancelar.TabIndex = 20
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(438, 38)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_aceptar.TabIndex = 19
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cb_producto_origen)
        Me.GroupBox3.Controls.Add(Me.tb_cantidad_origen)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(412, 46)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Producto Entrada"
        '
        'cb_producto_origen
        '
        Me.cb_producto_origen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_producto_origen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_producto_origen.FormattingEnabled = True
        Me.cb_producto_origen.Location = New System.Drawing.Point(211, 19)
        Me.cb_producto_origen.Name = "cb_producto_origen"
        Me.cb_producto_origen.Size = New System.Drawing.Size(195, 21)
        Me.cb_producto_origen.TabIndex = 18
        '
        'tb_cantidad_origen
        '
        Me.tb_cantidad_origen.Location = New System.Drawing.Point(66, 20)
        Me.tb_cantidad_origen.Name = "tb_cantidad_origen"
        Me.tb_cantidad_origen.Size = New System.Drawing.Size(54, 20)
        Me.tb_cantidad_origen.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(123, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Producto origen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Cantidad:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb_producto_salida)
        Me.GroupBox2.Controls.Add(Me.tb_cantidad_destino)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(412, 48)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto Salida"
        '
        'cb_producto_salida
        '
        Me.cb_producto_salida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_producto_salida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_producto_salida.FormattingEnabled = True
        Me.cb_producto_salida.Location = New System.Drawing.Point(211, 14)
        Me.cb_producto_salida.Name = "cb_producto_salida"
        Me.cb_producto_salida.Size = New System.Drawing.Size(195, 21)
        Me.cb_producto_salida.TabIndex = 19
        '
        'tb_cantidad_destino
        '
        Me.tb_cantidad_destino.Location = New System.Drawing.Point(63, 17)
        Me.tb_cantidad_destino.Name = "tb_cantidad_destino"
        Me.tb_cantidad_destino.Size = New System.Drawing.Size(54, 20)
        Me.tb_cantidad_destino.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(123, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Producto Salida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Cantidad:"
        '
        'gb_tabla
        '
        Me.gb_tabla.Controls.Add(Me.btn_quitar)
        Me.gb_tabla.Controls.Add(Me.btn_agregar)
        Me.gb_tabla.Controls.Add(Me.dg_conversiones)
        Me.gb_tabla.Location = New System.Drawing.Point(7, 12)
        Me.gb_tabla.Name = "gb_tabla"
        Me.gb_tabla.Size = New System.Drawing.Size(542, 293)
        Me.gb_tabla.TabIndex = 9
        Me.gb_tabla.TabStop = False
        Me.gb_tabla.Text = "GroupBox1"
        '
        'btn_quitar
        '
        Me.btn_quitar.Location = New System.Drawing.Point(470, 251)
        Me.btn_quitar.Name = "btn_quitar"
        Me.btn_quitar.Size = New System.Drawing.Size(64, 23)
        Me.btn_quitar.TabIndex = 22
        Me.btn_quitar.Text = "Quitar"
        Me.btn_quitar.UseVisualStyleBackColor = True
        '
        'btn_agregar
        '
        Me.btn_agregar.Location = New System.Drawing.Point(389, 251)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(64, 23)
        Me.btn_agregar.TabIndex = 21
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'dg_conversiones
        '
        Me.dg_conversiones.DataMember = ""
        Me.dg_conversiones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg_conversiones.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg_conversiones.Location = New System.Drawing.Point(4, 19)
        Me.dg_conversiones.Name = "dg_conversiones"
        Me.dg_conversiones.Size = New System.Drawing.Size(532, 226)
        Me.dg_conversiones.TabIndex = 20
        '
        'btn_guardar
        '
        Me.btn_guardar.Location = New System.Drawing.Point(11, 438)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(96, 35)
        Me.btn_guardar.TabIndex = 10
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'frm_configuracion_conversiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 479)
        Me.Controls.Add(Me.btn_guardar)
        Me.Controls.Add(Me.gb_tabla)
        Me.Controls.Add(Me.gb_detalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_configuracion_conversiones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de conversiones"
        Me.gb_detalle.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gb_tabla.ResumeLayout(False)
        CType(Me.dg_conversiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gb_detalle As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_producto_origen As System.Windows.Forms.ComboBox
    Friend WithEvents tb_cantidad_origen As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_producto_salida As System.Windows.Forms.ComboBox
    Friend WithEvents tb_cantidad_destino As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents gb_tabla As System.Windows.Forms.GroupBox
    Friend WithEvents btn_quitar As System.Windows.Forms.Button
    Friend WithEvents btn_agregar As System.Windows.Forms.Button
    Friend WithEvents dg_conversiones As System.Windows.Forms.DataGrid
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
End Class
