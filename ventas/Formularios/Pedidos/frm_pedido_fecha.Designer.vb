<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pedido_fecha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pedido_fecha))
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.gb_fecha_entrega = New System.Windows.Forms.GroupBox()
        Me.btn_down = New System.Windows.Forms.Button()
        Me.btn_up = New System.Windows.Forms.Button()
        Me.dtp_fecha_entrega = New System.Windows.Forms.DateTimePicker()
        Me.dtp_hora_entrega = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb_comentarios = New System.Windows.Forms.TextBox()
        Me.lbl_tipo_operacion = New System.Windows.Forms.Label()
        Me.gb_fecha_entrega.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_aceptar
        '
        Me.btn_aceptar.BackColor = System.Drawing.Color.White
        Me.btn_aceptar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_aceptar.Image = CType(resources.GetObject("btn_aceptar.Image"), System.Drawing.Image)
        Me.btn_aceptar.Location = New System.Drawing.Point(92, 295)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(148, 71)
        Me.btn_aceptar.TabIndex = 98
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_aceptar.UseVisualStyleBackColor = False
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(246, 295)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(125, 71)
        Me.btn_salir.TabIndex = 97
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'gb_fecha_entrega
        '
        Me.gb_fecha_entrega.Controls.Add(Me.btn_down)
        Me.gb_fecha_entrega.Controls.Add(Me.btn_up)
        Me.gb_fecha_entrega.Controls.Add(Me.dtp_fecha_entrega)
        Me.gb_fecha_entrega.Controls.Add(Me.dtp_hora_entrega)
        Me.gb_fecha_entrega.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_fecha_entrega.Location = New System.Drawing.Point(13, 47)
        Me.gb_fecha_entrega.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.gb_fecha_entrega.Name = "gb_fecha_entrega"
        Me.gb_fecha_entrega.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.gb_fecha_entrega.Size = New System.Drawing.Size(459, 100)
        Me.gb_fecha_entrega.TabIndex = 99
        Me.gb_fecha_entrega.TabStop = False
        Me.gb_fecha_entrega.Text = "Fecha,Hora Entrega"
        '
        'btn_down
        '
        Me.btn_down.BackColor = System.Drawing.Color.White
        Me.btn_down.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_down.Location = New System.Drawing.Point(391, 26)
        Me.btn_down.Name = "btn_down"
        Me.btn_down.Size = New System.Drawing.Size(61, 59)
        Me.btn_down.TabIndex = 42
        Me.btn_down.Text = "-"
        Me.btn_down.UseVisualStyleBackColor = False
        '
        'btn_up
        '
        Me.btn_up.BackColor = System.Drawing.Color.White
        Me.btn_up.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_up.Location = New System.Drawing.Point(323, 25)
        Me.btn_up.Name = "btn_up"
        Me.btn_up.Size = New System.Drawing.Size(64, 60)
        Me.btn_up.TabIndex = 42
        Me.btn_up.Text = "+"
        Me.btn_up.UseVisualStyleBackColor = False
        '
        'dtp_fecha_entrega
        '
        Me.dtp_fecha_entrega.CalendarFont = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_entrega.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.dtp_fecha_entrega.CustomFormat = "dddd ,  dd  MMMM yyyy "
        Me.dtp_fecha_entrega.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_entrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fecha_entrega.Location = New System.Drawing.Point(8, 23)
        Me.dtp_fecha_entrega.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_fecha_entrega.Name = "dtp_fecha_entrega"
        Me.dtp_fecha_entrega.Size = New System.Drawing.Size(305, 27)
        Me.dtp_fecha_entrega.TabIndex = 41
        Me.dtp_fecha_entrega.Value = New Date(2011, 12, 15, 0, 0, 0, 0)
        '
        'dtp_hora_entrega
        '
        Me.dtp_hora_entrega.AllowDrop = True
        Me.dtp_hora_entrega.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp_hora_entrega.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.dtp_hora_entrega.CustomFormat = "HH:MM:ss"
        Me.dtp_hora_entrega.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_hora_entrega.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_hora_entrega.Location = New System.Drawing.Point(8, 56)
        Me.dtp_hora_entrega.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dtp_hora_entrega.Name = "dtp_hora_entrega"
        Me.dtp_hora_entrega.ShowUpDown = True
        Me.dtp_hora_entrega.Size = New System.Drawing.Size(304, 37)
        Me.dtp_hora_entrega.TabIndex = 40
        Me.dtp_hora_entrega.Value = New Date(2012, 1, 17, 12, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tb_comentarios)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 153)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(460, 136)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comentarios"
        '
        'tb_comentarios
        '
        Me.tb_comentarios.Location = New System.Drawing.Point(8, 26)
        Me.tb_comentarios.Multiline = True
        Me.tb_comentarios.Name = "tb_comentarios"
        Me.tb_comentarios.Size = New System.Drawing.Size(445, 104)
        Me.tb_comentarios.TabIndex = 101
        '
        'lbl_tipo_operacion
        '
        Me.lbl_tipo_operacion.AutoSize = True
        Me.lbl_tipo_operacion.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tipo_operacion.Location = New System.Drawing.Point(17, 9)
        Me.lbl_tipo_operacion.Name = "lbl_tipo_operacion"
        Me.lbl_tipo_operacion.Size = New System.Drawing.Size(23, 19)
        Me.lbl_tipo_operacion.TabIndex = 101
        Me.lbl_tipo_operacion.Text = "--"
        '
        'frm_pedido_fecha
        '
        Me.AcceptButton = Me.btn_aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_salir
        Me.ClientSize = New System.Drawing.Size(485, 386)
        Me.Controls.Add(Me.lbl_tipo_operacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gb_fecha_entrega)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.btn_salir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_pedido_fecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha y hora de entrega"
        Me.gb_fecha_entrega.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Private WithEvents gb_fecha_entrega As System.Windows.Forms.GroupBox
    Friend WithEvents btn_down As System.Windows.Forms.Button
    Friend WithEvents btn_up As System.Windows.Forms.Button
    Private WithEvents dtp_fecha_entrega As System.Windows.Forms.DateTimePicker
    Private WithEvents dtp_hora_entrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_comentarios As System.Windows.Forms.TextBox
    Friend WithEvents lbl_tipo_operacion As System.Windows.Forms.Label
End Class
