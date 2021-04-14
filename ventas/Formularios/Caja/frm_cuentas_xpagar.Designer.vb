<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cuentas_xpagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cuentas_xpagar))
        Me.dgv_proveedores = New System.Windows.Forms.DataGridView()
        Me.gb_proveedor = New System.Windows.Forms.GroupBox()
        Me.gb_remisiones = New System.Windows.Forms.GroupBox()
        Me.dgv_remision = New System.Windows.Forms.DataGridView()
        Me.btn_pagar = New System.Windows.Forms.Button()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.tb_total = New System.Windows.Forms.Label()
        Me.lbl_proveedor = New System.Windows.Forms.Label()
        Me.tb_proveedor = New System.Windows.Forms.Label()
        Me.lbl_abonos = New System.Windows.Forms.Label()
        Me.tb_abonos = New System.Windows.Forms.Label()
        Me.lbl_saldo = New System.Windows.Forms.Label()
        Me.tb_saldo = New System.Windows.Forms.Label()
        Me.btn_salir = New System.Windows.Forms.Button()
        Me.lst_ticket = New System.Windows.Forms.ListView()
        CType(Me.dgv_proveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_proveedor.SuspendLayout()
        Me.gb_remisiones.SuspendLayout()
        CType(Me.dgv_remision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_proveedores
        '
        Me.dgv_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_proveedores.Location = New System.Drawing.Point(5, 21)
        Me.dgv_proveedores.MultiSelect = False
        Me.dgv_proveedores.Name = "dgv_proveedores"
        Me.dgv_proveedores.ReadOnly = True
        Me.dgv_proveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_proveedores.Size = New System.Drawing.Size(313, 391)
        Me.dgv_proveedores.TabIndex = 0
        '
        'gb_proveedor
        '
        Me.gb_proveedor.Controls.Add(Me.dgv_proveedores)
        Me.gb_proveedor.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_proveedor.Location = New System.Drawing.Point(3, 4)
        Me.gb_proveedor.Name = "gb_proveedor"
        Me.gb_proveedor.Size = New System.Drawing.Size(326, 422)
        Me.gb_proveedor.TabIndex = 1
        Me.gb_proveedor.TabStop = False
        Me.gb_proveedor.Text = "Proveedores"
        '
        'gb_remisiones
        '
        Me.gb_remisiones.Controls.Add(Me.dgv_remision)
        Me.gb_remisiones.Controls.Add(Me.btn_pagar)
        Me.gb_remisiones.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_remisiones.Location = New System.Drawing.Point(359, 4)
        Me.gb_remisiones.Name = "gb_remisiones"
        Me.gb_remisiones.Size = New System.Drawing.Size(454, 342)
        Me.gb_remisiones.TabIndex = 2
        Me.gb_remisiones.TabStop = False
        Me.gb_remisiones.Text = "Remisiones"
        '
        'dgv_remision
        '
        Me.dgv_remision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_remision.Location = New System.Drawing.Point(5, 21)
        Me.dgv_remision.MultiSelect = False
        Me.dgv_remision.Name = "dgv_remision"
        Me.dgv_remision.ReadOnly = True
        Me.dgv_remision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_remision.Size = New System.Drawing.Size(439, 254)
        Me.dgv_remision.TabIndex = 0
        '
        'btn_pagar
        '
        Me.btn_pagar.BackColor = System.Drawing.Color.White
        Me.btn_pagar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_pagar.Image = CType(resources.GetObject("btn_pagar.Image"), System.Drawing.Image)
        Me.btn_pagar.Location = New System.Drawing.Point(6, 281)
        Me.btn_pagar.Name = "btn_pagar"
        Me.btn_pagar.Size = New System.Drawing.Size(182, 55)
        Me.btn_pagar.TabIndex = 97
        Me.btn_pagar.Text = "Pagar Remision"
        Me.btn_pagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_pagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_pagar.UseVisualStyleBackColor = False
        '
        'lbl_total
        '
        Me.lbl_total.AutoSize = True
        Me.lbl_total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.Location = New System.Drawing.Point(12, 525)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(111, 21)
        Me.lbl_total.TabIndex = 98
        Me.lbl_total.Text = "Total Deuda:"
        '
        'tb_total
        '
        Me.tb_total.AutoSize = True
        Me.tb_total.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_total.Location = New System.Drawing.Point(134, 527)
        Me.tb_total.MaximumSize = New System.Drawing.Size(100, 0)
        Me.tb_total.MinimumSize = New System.Drawing.Size(100, 0)
        Me.tb_total.Name = "tb_total"
        Me.tb_total.Size = New System.Drawing.Size(100, 19)
        Me.tb_total.TabIndex = 98
        Me.tb_total.Text = "--"
        '
        'lbl_proveedor
        '
        Me.lbl_proveedor.AutoSize = True
        Me.lbl_proveedor.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_proveedor.Location = New System.Drawing.Point(12, 438)
        Me.lbl_proveedor.Name = "lbl_proveedor"
        Me.lbl_proveedor.Size = New System.Drawing.Size(94, 21)
        Me.lbl_proveedor.TabIndex = 98
        Me.lbl_proveedor.Text = "Proveedor:"
        '
        'tb_proveedor
        '
        Me.tb_proveedor.AutoSize = True
        Me.tb_proveedor.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_proveedor.Location = New System.Drawing.Point(134, 439)
        Me.tb_proveedor.MaximumSize = New System.Drawing.Size(220, 80)
        Me.tb_proveedor.MinimumSize = New System.Drawing.Size(220, 80)
        Me.tb_proveedor.Name = "tb_proveedor"
        Me.tb_proveedor.Size = New System.Drawing.Size(220, 80)
        Me.tb_proveedor.TabIndex = 98
        Me.tb_proveedor.Text = "--"
        '
        'lbl_abonos
        '
        Me.lbl_abonos.AutoSize = True
        Me.lbl_abonos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_abonos.Location = New System.Drawing.Point(12, 553)
        Me.lbl_abonos.Name = "lbl_abonos"
        Me.lbl_abonos.Size = New System.Drawing.Size(57, 21)
        Me.lbl_abonos.TabIndex = 98
        Me.lbl_abonos.Text = "Pagos"
        '
        'tb_abonos
        '
        Me.tb_abonos.AutoSize = True
        Me.tb_abonos.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_abonos.Location = New System.Drawing.Point(134, 555)
        Me.tb_abonos.MaximumSize = New System.Drawing.Size(100, 0)
        Me.tb_abonos.MinimumSize = New System.Drawing.Size(100, 0)
        Me.tb_abonos.Name = "tb_abonos"
        Me.tb_abonos.Size = New System.Drawing.Size(100, 19)
        Me.tb_abonos.TabIndex = 98
        Me.tb_abonos.Text = "--"
        '
        'lbl_saldo
        '
        Me.lbl_saldo.AutoSize = True
        Me.lbl_saldo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo.Location = New System.Drawing.Point(12, 581)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.Size = New System.Drawing.Size(91, 21)
        Me.lbl_saldo.TabIndex = 98
        Me.lbl_saldo.Text = "Por pagar:"
        '
        'tb_saldo
        '
        Me.tb_saldo.AutoSize = True
        Me.tb_saldo.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_saldo.Location = New System.Drawing.Point(134, 583)
        Me.tb_saldo.MaximumSize = New System.Drawing.Size(100, 0)
        Me.tb_saldo.MinimumSize = New System.Drawing.Size(100, 0)
        Me.tb_saldo.Name = "tb_saldo"
        Me.tb_saldo.Size = New System.Drawing.Size(100, 19)
        Me.tb_saldo.TabIndex = 98
        Me.tb_saldo.Text = "--"
        '
        'btn_salir
        '
        Me.btn_salir.BackColor = System.Drawing.Color.White
        Me.btn_salir.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salir.Image = CType(resources.GetObject("btn_salir.Image"), System.Drawing.Image)
        Me.btn_salir.Location = New System.Drawing.Point(360, 583)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(97, 56)
        Me.btn_salir.TabIndex = 98
        Me.btn_salir.Text = "Salir"
        Me.btn_salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_salir.UseVisualStyleBackColor = False
        '
        'lst_ticket
        '
        Me.lst_ticket.Location = New System.Drawing.Point(360, 352)
        Me.lst_ticket.Name = "lst_ticket"
        Me.lst_ticket.Size = New System.Drawing.Size(443, 222)
        Me.lst_ticket.TabIndex = 99
        Me.lst_ticket.UseCompatibleStateImageBehavior = False
        Me.lst_ticket.View = System.Windows.Forms.View.Details
        '
        'frm_cuentas_xpagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 646)
        Me.Controls.Add(Me.lst_ticket)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.tb_proveedor)
        Me.Controls.Add(Me.tb_saldo)
        Me.Controls.Add(Me.tb_abonos)
        Me.Controls.Add(Me.tb_total)
        Me.Controls.Add(Me.lbl_saldo)
        Me.Controls.Add(Me.lbl_abonos)
        Me.Controls.Add(Me.lbl_proveedor)
        Me.Controls.Add(Me.lbl_total)
        Me.Controls.Add(Me.gb_remisiones)
        Me.Controls.Add(Me.gb_proveedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_cuentas_xpagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por pagar"
        CType(Me.dgv_proveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_proveedor.ResumeLayout(False)
        Me.gb_remisiones.ResumeLayout(False)
        CType(Me.dgv_remision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_proveedores As System.Windows.Forms.DataGridView
    Friend WithEvents gb_proveedor As System.Windows.Forms.GroupBox
    Friend WithEvents gb_remisiones As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_remision As System.Windows.Forms.DataGridView
    Friend WithEvents btn_pagar As System.Windows.Forms.Button
    Friend WithEvents lbl_total As System.Windows.Forms.Label
    Friend WithEvents tb_total As System.Windows.Forms.Label
    Friend WithEvents lbl_proveedor As System.Windows.Forms.Label
    Friend WithEvents tb_proveedor As System.Windows.Forms.Label
    Friend WithEvents lbl_abonos As System.Windows.Forms.Label
    Friend WithEvents tb_abonos As System.Windows.Forms.Label
    Friend WithEvents lbl_saldo As System.Windows.Forms.Label
    Friend WithEvents tb_saldo As System.Windows.Forms.Label
    Friend WithEvents btn_salir As System.Windows.Forms.Button
    Friend WithEvents lst_ticket As System.Windows.Forms.ListView
End Class
