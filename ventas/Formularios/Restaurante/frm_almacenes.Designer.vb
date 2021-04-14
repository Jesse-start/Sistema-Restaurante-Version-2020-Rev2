<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_almacenes2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_almacenes2))
        Me.lst_almacenes = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_nuevo = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_deshacer = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.btn_editar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gb_almacen = New System.Windows.Forms.GroupBox()
        Me.btn_agregar_sucursal = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_agregar_tipo_almacen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_agregar_responsable = New System.Windows.Forms.Button()
        Me.tb_clave = New System.Windows.Forms.TextBox()
        Me.cb_responsable = New System.Windows.Forms.ComboBox()
        Me.cb_tipo_almacen = New System.Windows.Forms.ComboBox()
        Me.chb_defecto_ventas = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_sucursal = New System.Windows.Forms.ComboBox()
        Me.tb_nombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tb_domicilio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cb_busqueda_tipo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gb_almacen.SuspendLayout()
        Me.SuspendLayout()
        '
        'lst_almacenes
        '
        Me.lst_almacenes.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst_almacenes.GridLines = True
        Me.lst_almacenes.Location = New System.Drawing.Point(12, 49)
        Me.lst_almacenes.MultiSelect = False
        Me.lst_almacenes.Name = "lst_almacenes"
        Me.lst_almacenes.Size = New System.Drawing.Size(308, 317)
        Me.lst_almacenes.TabIndex = 0
        Me.lst_almacenes.UseCompatibleStateImageBehavior = False
        Me.lst_almacenes.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_nuevo)
        Me.GroupBox1.Controls.Add(Me.btn_salir)
        Me.GroupBox1.Controls.Add(Me.btn_guardar)
        Me.GroupBox1.Controls.Add(Me.btn_eliminar)
        Me.GroupBox1.Controls.Add(Me.btn_deshacer)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.btn_editar)
        Me.GroupBox1.Location = New System.Drawing.Point(326, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(580, 103)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'btn_nuevo
        '
        Me.btn_nuevo.Enabled = False
        Me.btn_nuevo.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_nuevo.Image = CType(resources.GetObject("btn_nuevo.Image"), System.Drawing.Image)
        Me.btn_nuevo.Location = New System.Drawing.Point(6, 19)
        Me.btn_nuevo.Name = "btn_nuevo"
        Me.btn_nuevo.Size = New System.Drawing.Size(76, 74)
        Me.btn_nuevo.TabIndex = 4
        Me.btn_nuevo.Text = "Nuevo"
        Me.btn_nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_nuevo.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Enabled = False
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(491, 19)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(76, 74)
        Me.btn_salir.TabIndex = 10
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'btn_guardar
        '
        Me.btn_guardar.Enabled = False
        Me.btn_guardar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.Image = CType(resources.GetObject("btn_guardar.Image"), System.Drawing.Image)
        Me.btn_guardar.Location = New System.Drawing.Point(87, 19)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(76, 74)
        Me.btn_guardar.TabIndex = 5
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_guardar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Enabled = False
        Me.btn_eliminar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_eliminar.Image = CType(resources.GetObject("btn_eliminar.Image"), System.Drawing.Image)
        Me.btn_eliminar.Location = New System.Drawing.Point(409, 19)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(76, 74)
        Me.btn_eliminar.TabIndex = 6
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_deshacer
        '
        Me.btn_deshacer.Enabled = False
        Me.btn_deshacer.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deshacer.Image = CType(resources.GetObject("btn_deshacer.Image"), System.Drawing.Image)
        Me.btn_deshacer.Location = New System.Drawing.Point(166, 19)
        Me.btn_deshacer.Name = "btn_deshacer"
        Me.btn_deshacer.Size = New System.Drawing.Size(76, 74)
        Me.btn_deshacer.TabIndex = 5
        Me.btn_deshacer.Text = "Deshacer"
        Me.btn_deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_deshacer.UseVisualStyleBackColor = True
        '
        'btn_buscar
        '
        Me.btn_buscar.Enabled = False
        Me.btn_buscar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = CType(resources.GetObject("btn_buscar.Image"), System.Drawing.Image)
        Me.btn_buscar.Location = New System.Drawing.Point(329, 19)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(76, 74)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'btn_editar
        '
        Me.btn_editar.Enabled = False
        Me.btn_editar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Location = New System.Drawing.Point(248, 19)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Size = New System.Drawing.Size(76, 74)
        Me.btn_editar.TabIndex = 6
        Me.btn_editar.Text = "Editar"
        Me.btn_editar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_editar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gb_almacen)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(326, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(567, 244)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información"
        '
        'gb_almacen
        '
        Me.gb_almacen.Controls.Add(Me.btn_agregar_sucursal)
        Me.gb_almacen.Controls.Add(Me.Label1)
        Me.gb_almacen.Controls.Add(Me.btn_agregar_tipo_almacen)
        Me.gb_almacen.Controls.Add(Me.Label2)
        Me.gb_almacen.Controls.Add(Me.btn_agregar_responsable)
        Me.gb_almacen.Controls.Add(Me.tb_clave)
        Me.gb_almacen.Controls.Add(Me.cb_responsable)
        Me.gb_almacen.Controls.Add(Me.cb_tipo_almacen)
        Me.gb_almacen.Controls.Add(Me.chb_defecto_ventas)
        Me.gb_almacen.Controls.Add(Me.Label3)
        Me.gb_almacen.Controls.Add(Me.cb_sucursal)
        Me.gb_almacen.Controls.Add(Me.tb_nombre)
        Me.gb_almacen.Controls.Add(Me.Label4)
        Me.gb_almacen.Controls.Add(Me.Label5)
        Me.gb_almacen.Controls.Add(Me.tb_domicilio)
        Me.gb_almacen.Controls.Add(Me.Label7)
        Me.gb_almacen.Enabled = False
        Me.gb_almacen.Location = New System.Drawing.Point(6, 18)
        Me.gb_almacen.Name = "gb_almacen"
        Me.gb_almacen.Size = New System.Drawing.Size(550, 215)
        Me.gb_almacen.TabIndex = 25
        Me.gb_almacen.TabStop = False
        '
        'btn_agregar_sucursal
        '
        Me.btn_agregar_sucursal.BackColor = System.Drawing.Color.Green
        Me.btn_agregar_sucursal.ForeColor = System.Drawing.Color.White
        Me.btn_agregar_sucursal.Location = New System.Drawing.Point(347, 172)
        Me.btn_agregar_sucursal.Name = "btn_agregar_sucursal"
        Me.btn_agregar_sucursal.Size = New System.Drawing.Size(31, 28)
        Me.btn_agregar_sucursal.TabIndex = 25
        Me.btn_agregar_sucursal.Text = "+"
        Me.btn_agregar_sucursal.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tipo Almacen"
        '
        'btn_agregar_tipo_almacen
        '
        Me.btn_agregar_tipo_almacen.BackColor = System.Drawing.Color.Green
        Me.btn_agregar_tipo_almacen.ForeColor = System.Drawing.Color.White
        Me.btn_agregar_tipo_almacen.Location = New System.Drawing.Point(346, 20)
        Me.btn_agregar_tipo_almacen.Name = "btn_agregar_tipo_almacen"
        Me.btn_agregar_tipo_almacen.Size = New System.Drawing.Size(32, 27)
        Me.btn_agregar_tipo_almacen.TabIndex = 24
        Me.btn_agregar_tipo_almacen.Text = "+"
        Me.btn_agregar_tipo_almacen.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Clave:"
        '
        'btn_agregar_responsable
        '
        Me.btn_agregar_responsable.BackColor = System.Drawing.Color.Green
        Me.btn_agregar_responsable.ForeColor = System.Drawing.Color.White
        Me.btn_agregar_responsable.Location = New System.Drawing.Point(346, 109)
        Me.btn_agregar_responsable.Name = "btn_agregar_responsable"
        Me.btn_agregar_responsable.Size = New System.Drawing.Size(32, 27)
        Me.btn_agregar_responsable.TabIndex = 24
        Me.btn_agregar_responsable.Text = "+"
        Me.btn_agregar_responsable.UseVisualStyleBackColor = False
        '
        'tb_clave
        '
        Me.tb_clave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_clave.Location = New System.Drawing.Point(130, 53)
        Me.tb_clave.Name = "tb_clave"
        Me.tb_clave.Size = New System.Drawing.Size(99, 23)
        Me.tb_clave.TabIndex = 10
        '
        'cb_responsable
        '
        Me.cb_responsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_responsable.FormattingEnabled = True
        Me.cb_responsable.Location = New System.Drawing.Point(130, 110)
        Me.cb_responsable.Name = "cb_responsable"
        Me.cb_responsable.Size = New System.Drawing.Size(210, 26)
        Me.cb_responsable.TabIndex = 23
        '
        'cb_tipo_almacen
        '
        Me.cb_tipo_almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_tipo_almacen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipo_almacen.FormattingEnabled = True
        Me.cb_tipo_almacen.Location = New System.Drawing.Point(130, 22)
        Me.cb_tipo_almacen.Name = "cb_tipo_almacen"
        Me.cb_tipo_almacen.Size = New System.Drawing.Size(210, 25)
        Me.cb_tipo_almacen.TabIndex = 11
        '
        'chb_defecto_ventas
        '
        Me.chb_defecto_ventas.AutoSize = True
        Me.chb_defecto_ventas.Enabled = False
        Me.chb_defecto_ventas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chb_defecto_ventas.Location = New System.Drawing.Point(407, 24)
        Me.chb_defecto_ventas.Name = "chb_defecto_ventas"
        Me.chb_defecto_ventas.Size = New System.Drawing.Size(136, 20)
        Me.chb_defecto_ventas.TabIndex = 22
        Me.chb_defecto_ventas.Text = "Por defecto ventas"
        Me.chb_defecto_ventas.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nombre:"
        '
        'cb_sucursal
        '
        Me.cb_sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_sucursal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sucursal.FormattingEnabled = True
        Me.cb_sucursal.Location = New System.Drawing.Point(131, 175)
        Me.cb_sucursal.Name = "cb_sucursal"
        Me.cb_sucursal.Size = New System.Drawing.Size(209, 25)
        Me.cb_sucursal.TabIndex = 21
        '
        'tb_nombre
        '
        Me.tb_nombre.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_nombre.Location = New System.Drawing.Point(131, 81)
        Me.tb_nombre.Name = "tb_nombre"
        Me.tb_nombre.Size = New System.Drawing.Size(209, 23)
        Me.tb_nombre.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Responsable:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Domicilio"
        '
        'tb_domicilio
        '
        Me.tb_domicilio.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_domicilio.Location = New System.Drawing.Point(130, 142)
        Me.tb_domicilio.Name = "tb_domicilio"
        Me.tb_domicilio.Size = New System.Drawing.Size(210, 23)
        Me.tb_domicilio.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Sucursal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(549, 78)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 16)
        Me.Label10.TabIndex = 20
        '
        'cb_busqueda_tipo
        '
        Me.cb_busqueda_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_busqueda_tipo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_busqueda_tipo.FormattingEnabled = True
        Me.cb_busqueda_tipo.Location = New System.Drawing.Point(51, 18)
        Me.cb_busqueda_tipo.Name = "cb_busqueda_tipo"
        Me.cb_busqueda_tipo.Size = New System.Drawing.Size(269, 25)
        Me.cb_busqueda_tipo.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Tipo"
        '
        'frm_almacenes2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 373)
        Me.Controls.Add(Me.cb_busqueda_tipo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lst_almacenes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_almacenes2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Almacenes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gb_almacen.ResumeLayout(False)
        Me.gb_almacen.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lst_almacenes As System.Windows.Forms.ListView
    Friend WithEvents btn_nuevo As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btn_eliminar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents btn_editar As System.Windows.Forms.Button
    Friend WithEvents btn_deshacer As System.Windows.Forms.Button
    Friend WithEvents btn_guardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_clave As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_tipo_almacen As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_domicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tb_nombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cb_busqueda_tipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chb_defecto_ventas As System.Windows.Forms.CheckBox
    Friend WithEvents cb_responsable As System.Windows.Forms.ComboBox
    Friend WithEvents btn_agregar_responsable As System.Windows.Forms.Button
    Friend WithEvents btn_agregar_tipo_almacen As System.Windows.Forms.Button
    Friend WithEvents gb_almacen As System.Windows.Forms.GroupBox
    Friend WithEvents btn_agregar_sucursal As System.Windows.Forms.Button
    Friend WithEvents cb_sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
