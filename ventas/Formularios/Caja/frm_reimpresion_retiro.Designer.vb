<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reimpresion_retiro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_reimpresion_retiro))
        Me.dgv_reimpresion_retiros = New System.Windows.Forms.DataGridView()
        Me.cb_colaborador = New System.Windows.Forms.ComboBox()
        Me.lbl_colaborador = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.lbl_fecha_termino = New System.Windows.Forms.Label()
        Me.dtp_fecha_termino = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_reimprimir = New System.Windows.Forms.Button()
        CType(Me.dgv_reimpresion_retiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_reimpresion_retiros
        '
        Me.dgv_reimpresion_retiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_reimpresion_retiros.Location = New System.Drawing.Point(12, 92)
        Me.dgv_reimpresion_retiros.MultiSelect = False
        Me.dgv_reimpresion_retiros.Name = "dgv_reimpresion_retiros"
        Me.dgv_reimpresion_retiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_reimpresion_retiros.Size = New System.Drawing.Size(704, 338)
        Me.dgv_reimpresion_retiros.TabIndex = 0
        '
        'cb_colaborador
        '
        Me.cb_colaborador.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_colaborador.FormattingEnabled = True
        Me.cb_colaborador.Location = New System.Drawing.Point(132, 12)
        Me.cb_colaborador.Name = "cb_colaborador"
        Me.cb_colaborador.Size = New System.Drawing.Size(327, 29)
        Me.cb_colaborador.TabIndex = 1
        '
        'lbl_colaborador
        '
        Me.lbl_colaborador.AutoSize = True
        Me.lbl_colaborador.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_colaborador.Location = New System.Drawing.Point(6, 15)
        Me.lbl_colaborador.Name = "lbl_colaborador"
        Me.lbl_colaborador.Size = New System.Drawing.Size(114, 21)
        Me.lbl_colaborador.TabIndex = 2
        Me.lbl_colaborador.Text = "Colaborador:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha Inicio:"
        '
        'dtp_fecha_inicio
        '
        Me.dtp_fecha_inicio.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_inicio.Location = New System.Drawing.Point(132, 53)
        Me.dtp_fecha_inicio.Name = "dtp_fecha_inicio"
        Me.dtp_fecha_inicio.Size = New System.Drawing.Size(148, 27)
        Me.dtp_fecha_inicio.TabIndex = 4
        '
        'lbl_fecha_termino
        '
        Me.lbl_fecha_termino.AutoSize = True
        Me.lbl_fecha_termino.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fecha_termino.Location = New System.Drawing.Point(306, 56)
        Me.lbl_fecha_termino.Name = "lbl_fecha_termino"
        Me.lbl_fecha_termino.Size = New System.Drawing.Size(128, 21)
        Me.lbl_fecha_termino.TabIndex = 3
        Me.lbl_fecha_termino.Text = "Fecha Termino:"
        '
        'dtp_fecha_termino
        '
        Me.dtp_fecha_termino.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_fecha_termino.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_fecha_termino.Location = New System.Drawing.Point(440, 53)
        Me.dtp_fecha_termino.Name = "dtp_fecha_termino"
        Me.dtp_fecha_termino.Size = New System.Drawing.Size(143, 27)
        Me.dtp_fecha_termino.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(595, 436)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 81)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btn_reimprimir
        '
        Me.btn_reimprimir.BackColor = System.Drawing.Color.White
        Me.btn_reimprimir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reimprimir.Image = CType(resources.GetObject("btn_reimprimir.Image"), System.Drawing.Image)
        Me.btn_reimprimir.Location = New System.Drawing.Point(441, 436)
        Me.btn_reimprimir.Name = "btn_reimprimir"
        Me.btn_reimprimir.Size = New System.Drawing.Size(148, 81)
        Me.btn_reimprimir.TabIndex = 76
        Me.btn_reimprimir.Text = "Imprimir"
        Me.btn_reimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_reimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reimprimir.UseVisualStyleBackColor = False
        '
        'frm_reimpresion_retiro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 529)
        Me.Controls.Add(Me.btn_reimprimir)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtp_fecha_termino)
        Me.Controls.Add(Me.lbl_fecha_termino)
        Me.Controls.Add(Me.dtp_fecha_inicio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_colaborador)
        Me.Controls.Add(Me.cb_colaborador)
        Me.Controls.Add(Me.dgv_reimpresion_retiros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_reimpresion_retiro"
        Me.Text = "Reimpresión de retiro de caja"
        CType(Me.dgv_reimpresion_retiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_reimpresion_retiros As System.Windows.Forms.DataGridView
    Friend WithEvents cb_colaborador As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_colaborador As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_fecha_termino As System.Windows.Forms.Label
    Friend WithEvents dtp_fecha_termino As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_reimprimir As System.Windows.Forms.Button
End Class
