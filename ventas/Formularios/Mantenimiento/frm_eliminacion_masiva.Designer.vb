<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_eliminacion_masiva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_eliminacion_masiva))
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp_fecha_termino = New System.Windows.Forms.DateTimePicker()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.gb_eliminacion = New System.Windows.Forms.GroupBox()
        Me.tb_porcentaje_diferencia = New System.Windows.Forms.TextBox()
        Me.tb_importe_diferencia = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tb_importe_nuevo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tb_importe_anterior = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tb_cuentas_modificar = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tb_cuentas_total = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lst_mantenimientos = New System.Windows.Forms.ListView()
        Me.tb_importe_objetivo = New System.Windows.Forms.TextBox()
        Me.tb_porcentaje_objetivo = New System.Windows.Forms.TextBox()
        Me.tb_importe_eliminar = New System.Windows.Forms.TextBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cb_tipo_eliminacion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_aplicar = New System.Windows.Forms.Button()
        Me.gb_eliminacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(415, 18)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(98, 23)
        Me.dtp_fecha_inicio.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(293, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(292, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Termino"
        '
        'dtp_fecha_termino
        '
        Me.dtp_fecha_termino.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino.Location = New System.Drawing.Point(415, 48)
        Me.dtp_fecha_termino.Name = "dtp_fecha_termino"
        Me.dtp_fecha_termino.Size = New System.Drawing.Size(98, 23)
        Me.dtp_fecha_termino.TabIndex = 3
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(932, 11)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(85, 87)
        Me.btn_nuevo.TabIndex = 12
        Me.btn_nuevo.Text = "Buscar"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'gb_eliminacion
        '
        Me.gb_eliminacion.Controls.Add(Me.tb_porcentaje_diferencia)
        Me.gb_eliminacion.Controls.Add(Me.tb_importe_diferencia)
        Me.gb_eliminacion.Controls.Add(Me.Label11)
        Me.gb_eliminacion.Controls.Add(Me.tb_importe_nuevo)
        Me.gb_eliminacion.Controls.Add(Me.Label10)
        Me.gb_eliminacion.Controls.Add(Me.tb_importe_anterior)
        Me.gb_eliminacion.Controls.Add(Me.Label9)
        Me.gb_eliminacion.Controls.Add(Me.tb_cuentas_modificar)
        Me.gb_eliminacion.Controls.Add(Me.Label8)
        Me.gb_eliminacion.Controls.Add(Me.tb_cuentas_total)
        Me.gb_eliminacion.Controls.Add(Me.Label7)
        Me.gb_eliminacion.Controls.Add(Me.lst_mantenimientos)
        Me.gb_eliminacion.Controls.Add(Me.tb_importe_objetivo)
        Me.gb_eliminacion.Controls.Add(Me.tb_porcentaje_objetivo)
        Me.gb_eliminacion.Controls.Add(Me.tb_importe_eliminar)
        Me.gb_eliminacion.Controls.Add(Me.CheckBox4)
        Me.gb_eliminacion.Controls.Add(Me.CheckBox3)
        Me.gb_eliminacion.Controls.Add(Me.Label6)
        Me.gb_eliminacion.Controls.Add(Me.CheckBox2)
        Me.gb_eliminacion.Controls.Add(Me.Label5)
        Me.gb_eliminacion.Controls.Add(Me.CheckBox1)
        Me.gb_eliminacion.Controls.Add(Me.Label4)
        Me.gb_eliminacion.Controls.Add(Me.cb_tipo_eliminacion)
        Me.gb_eliminacion.Controls.Add(Me.Label3)
        Me.gb_eliminacion.Controls.Add(Me.Label1)
        Me.gb_eliminacion.Controls.Add(Me.btn_cancelar)
        Me.gb_eliminacion.Controls.Add(Me.btn_aplicar)
        Me.gb_eliminacion.Controls.Add(Me.btn_nuevo)
        Me.gb_eliminacion.Controls.Add(Me.Label2)
        Me.gb_eliminacion.Controls.Add(Me.dtp_fecha_termino)
        Me.gb_eliminacion.Controls.Add(Me.dtp_fecha_inicio)
        Me.gb_eliminacion.Location = New System.Drawing.Point(8, 4)
        Me.gb_eliminacion.Name = "gb_eliminacion"
        Me.gb_eliminacion.Size = New System.Drawing.Size(1024, 768)
        Me.gb_eliminacion.TabIndex = 13
        Me.gb_eliminacion.TabStop = False
        '
        'tb_porcentaje_diferencia
        '
        Me.tb_porcentaje_diferencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_porcentaje_diferencia.Location = New System.Drawing.Point(521, 730)
        Me.tb_porcentaje_diferencia.Name = "tb_porcentaje_diferencia"
        Me.tb_porcentaje_diferencia.Size = New System.Drawing.Size(60, 23)
        Me.tb_porcentaje_diferencia.TabIndex = 18
        '
        'tb_importe_diferencia
        '
        Me.tb_importe_diferencia.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_diferencia.Location = New System.Drawing.Point(415, 730)
        Me.tb_importe_diferencia.Name = "tb_importe_diferencia"
        Me.tb_importe_diferencia.Size = New System.Drawing.Size(100, 23)
        Me.tb_importe_diferencia.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(322, 736)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 17)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Diferencia:"
        '
        'tb_importe_nuevo
        '
        Me.tb_importe_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_nuevo.Location = New System.Drawing.Point(415, 703)
        Me.tb_importe_nuevo.Name = "tb_importe_nuevo"
        Me.tb_importe_nuevo.Size = New System.Drawing.Size(100, 23)
        Me.tb_importe_nuevo.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(289, 706)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 17)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Importe Nuevo:"
        '
        'tb_importe_anterior
        '
        Me.tb_importe_anterior.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_anterior.Location = New System.Drawing.Point(415, 676)
        Me.tb_importe_anterior.Name = "tb_importe_anterior"
        Me.tb_importe_anterior.Size = New System.Drawing.Size(100, 23)
        Me.tb_importe_anterior.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(282, 679)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Importe Anterior:"
        '
        'tb_cuentas_modificar
        '
        Me.tb_cuentas_modificar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cuentas_modificar.Location = New System.Drawing.Point(159, 712)
        Me.tb_cuentas_modificar.Name = "tb_cuentas_modificar"
        Me.tb_cuentas_modificar.Size = New System.Drawing.Size(100, 23)
        Me.tb_cuentas_modificar.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 715)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "No. Cuentas  Modif."
        '
        'tb_cuentas_total
        '
        Me.tb_cuentas_total.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_cuentas_total.Location = New System.Drawing.Point(159, 685)
        Me.tb_cuentas_total.Name = "tb_cuentas_total"
        Me.tb_cuentas_total.Size = New System.Drawing.Size(100, 23)
        Me.tb_cuentas_total.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 688)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "No. Cuentas  Total:"
        '
        'lst_mantenimientos
        '
        Me.lst_mantenimientos.Location = New System.Drawing.Point(6, 109)
        Me.lst_mantenimientos.Name = "lst_mantenimientos"
        Me.lst_mantenimientos.Size = New System.Drawing.Size(1011, 562)
        Me.lst_mantenimientos.TabIndex = 16
        Me.lst_mantenimientos.UseCompatibleStateImageBehavior = False
        Me.lst_mantenimientos.View = System.Windows.Forms.View.Details
        '
        'tb_importe_objetivo
        '
        Me.tb_importe_objetivo.Enabled = False
        Me.tb_importe_objetivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_objetivo.Location = New System.Drawing.Point(415, 78)
        Me.tb_importe_objetivo.Name = "tb_importe_objetivo"
        Me.tb_importe_objetivo.Size = New System.Drawing.Size(100, 23)
        Me.tb_importe_objetivo.TabIndex = 15
        '
        'tb_porcentaje_objetivo
        '
        Me.tb_porcentaje_objetivo.Enabled = False
        Me.tb_porcentaje_objetivo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_porcentaje_objetivo.Location = New System.Drawing.Point(175, 78)
        Me.tb_porcentaje_objetivo.Name = "tb_porcentaje_objetivo"
        Me.tb_porcentaje_objetivo.Size = New System.Drawing.Size(100, 23)
        Me.tb_porcentaje_objetivo.TabIndex = 15
        '
        'tb_importe_eliminar
        '
        Me.tb_importe_eliminar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_importe_eliminar.Location = New System.Drawing.Point(175, 50)
        Me.tb_importe_eliminar.Name = "tb_importe_eliminar"
        Me.tb_importe_eliminar.Size = New System.Drawing.Size(100, 23)
        Me.tb_importe_eliminar.TabIndex = 15
        Me.tb_importe_eliminar.Text = "0"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox4.Location = New System.Drawing.Point(531, 81)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(259, 21)
        Me.CheckBox4.TabIndex = 14
        Me.CheckBox4.Text = "Incluir ventas que fueron facturadas"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(531, 60)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(371, 21)
        Me.CheckBox3.TabIndex = 14
        Me.CheckBox3.Text = "Incluir ventas pagadas a credito (cuentas por pagar)"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(292, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Importe objetivo"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(531, 40)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(295, 21)
        Me.CheckBox2.TabIndex = 14
        Me.CheckBox2.Text = "Incluir ventas pagadas con transferencias"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 17)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "% objetivo a descontar"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(531, 20)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(250, 21)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Incluir ventas pagadas con tarjeta"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Cuentas mayores a:"
        '
        'cb_tipo_eliminacion
        '
        Me.cb_tipo_eliminacion.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipo_eliminacion.FormattingEnabled = True
        Me.cb_tipo_eliminacion.Location = New System.Drawing.Point(176, 16)
        Me.cb_tipo_eliminacion.Name = "cb_tipo_eliminacion"
        Me.cb_tipo_eliminacion.Size = New System.Drawing.Size(99, 25)
        Me.cb_tipo_eliminacion.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo de eliminación:"
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancelar.Image = CType(resources.GetObject("btn_cancelar.Image"), System.Drawing.Image)
        Me.btn_cancelar.Location = New System.Drawing.Point(888, 675)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(85, 87)
        Me.btn_cancelar.TabIndex = 12
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_aplicar
        '
        Me.btn_aplicar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aplicar.Image = CType(resources.GetObject("btn_aplicar.Image"), System.Drawing.Image)
        Me.btn_aplicar.Location = New System.Drawing.Point(782, 675)
        Me.btn_aplicar.Name = "btn_aplicar"
        Me.btn_aplicar.Size = New System.Drawing.Size(85, 87)
        Me.btn_aplicar.TabIndex = 12
        Me.btn_aplicar.Text = "Aplicar"
        Me.btn_aplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_aplicar.UseVisualStyleBackColor = True
        '
        'frm_eliminacion_masiva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 781)
        Me.Controls.Add(Me.gb_eliminacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_eliminacion_masiva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Eliminacion masiva de folios y productos"
        Me.gb_eliminacion.ResumeLayout(False)
        Me.gb_eliminacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents gb_eliminacion As System.Windows.Forms.GroupBox
    Friend WithEvents tb_importe_objetivo As System.Windows.Forms.TextBox
    Friend WithEvents tb_porcentaje_objetivo As System.Windows.Forms.TextBox
    Friend WithEvents tb_importe_eliminar As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cb_tipo_eliminacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_porcentaje_diferencia As System.Windows.Forms.TextBox
    Friend WithEvents tb_importe_diferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_importe_nuevo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tb_importe_anterior As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tb_cuentas_modificar As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tb_cuentas_total As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lst_mantenimientos As System.Windows.Forms.ListView
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents btn_aplicar As System.Windows.Forms.Button
End Class
