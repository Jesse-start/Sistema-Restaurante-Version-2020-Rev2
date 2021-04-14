Public Class frm_cuentas_xpagar

    Private Sub frm_cuentas_xcobrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        global_frm_cuentasxpagar = 0
    End Sub

    Private Sub gb_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_cuentasxpagar = 1
        estilo_cuentasxpagar_proveedores(dgv_proveedores)
        estilo_cuentasxpagar_remisiones(dgv_remision)
        cargar_proveedores()
        cargar_remisiones_proveedores()
        aplicar_colores()
        With lst_ticket
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("CANT.", 55) ' 0 
            .Columns.Add("UNID.", 40) ' 0 
            .Columns.Add("PRODUCT.", 200, HorizontalAlignment.Left) ' 1
            .Columns.Add("P.U.", 60, HorizontalAlignment.Right) '2
            .Columns.Add("IMPORTE.", 70, HorizontalAlignment.Right) '3
            .Font = New Font("Helvetica", 9, FontStyle.Bold) ' 4
        End With
    End Sub

    Private Sub agregar_ticket(ByVal index As Integer, ByVal cantidad As Decimal, ByVal unidad As String, ByVal producto As String, ByVal precio As String, ByVal importe As String)
        Dim str(5) As String
        str(0) = cantidad
        str(1) = unidad
        str(2) = producto
        str(3) = FormatCurrency(precio)
        str(4) = FormatCurrency(importe)
        lst_ticket.Items.Add(New ListViewItem(str, 0))
        'lst_productos.Items(index).Tag = id_tabla ' id_producto
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_proveedor.ForeColor = Color.FromArgb(conf_colores(2))
        gb_remisiones.ForeColor = Color.FromArgb(conf_colores(2))


        btn_pagar.BackColor = Color.FromArgb(conf_colores(8))
        btn_pagar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

        lbl_proveedor.ForeColor = Color.FromArgb(conf_colores(13))
        tb_proveedor.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_total.ForeColor = Color.FromArgb(conf_colores(13))
        tb_total.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_abonos.ForeColor = Color.FromArgb(conf_colores(13))
        tb_abonos.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_saldo.ForeColor = Color.FromArgb(conf_colores(13))
        tb_saldo.ForeColor = Color.FromArgb(conf_colores(13))

    End Sub

    Private Sub cargar_proveedores()
        tabla_cuentasxpagar_proveedores.Clear()
        'Conectar()
        rs.Open("SELECT DISTINCT CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre, CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS razon_social, proveedor.id_proveedor " & _
                "FROM proveedor " & _
                "JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor " & _
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                "WHERE factura_compra.status='ACTIVO'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_cuentasxpagar_proveedores(rs.Fields("id_proveedor").Value, rs.Fields("nombre").Value, rs.Fields("razon_social").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub dgv_proveedores_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_proveedores.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_proveedores.Columns.Count - 1
            If dgv_proveedores.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_proveedores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_proveedores.Click
        If dgv_proveedores.Rows.Count > 0 Then
            cargar_remisiones_proveedores()
        End If
    End Sub

    Private Sub btn_cobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        If dgv_remision.RowCount > 0 Then
            If dgv_remision.SelectedRows.Count > 0 Then
                frm_formas_pago.id_factura_compra = dgv_remision.Rows(dgv_remision.CurrentRow.Index).Cells("id_factura_compra").Value
                frm_formas_pago.ShowDialog()
            Else
                MsgBox("Seleccione una remisión de la lista", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Else
            MsgBox("Este cliente ya no remisiones tickets pendientes de pago", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub
    Private Sub dgv_remisiones_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_remision.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_remision.Columns.Count - 1
            If dgv_remision.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Public Sub cargar_detalle_recepcion(ByVal id_factura_compra)
        Dim i As Integer = 0
        lst_ticket.Items.Clear()
        'Conectar()
        rs.Open("SELECT cantidad,unidad,descripcion,precio_unitario,(precio_unitario*cantidad) AS importe FROM factura_compra_detalle WHERE id_factura_compra='" & id_factura_compra & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_ticket(0, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("descripcion").Value, rs.Fields("precio_unitario").Value, rs.Fields("importe").Value)
                i = i + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Public Sub cargar_remisiones_proveedores()
        If dgv_proveedores.RowCount > 0 Then
            If dgv_proveedores.SelectedRows.Count > 0 Then
                tabla_cuentasxpagar_remisiones.Clear()
                'cargamos las ventas pendientes del cliente seleccionado
                tb_proveedor.Text = dgv_proveedores.Rows(dgv_proveedores.CurrentRow.Index).Cells("razon_social").Value
                Dim fecha As Date
                'Conectar()
                rs.Open("SELECT fc.id_factura_compra,fc.fecha,fc.folio,fc.total, CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS  nombre_empleado " & _
                        "FROM factura_compra fc " & _
                        "JOIN empleado e ON e.id_empleado=fc.id_empleado_captura " & _
                        "JOIN persona p ON p.id_persona=e.id_persona " & _
                        "WHERE fc.id_proveedor='" & dgv_proveedores.Rows(dgv_proveedores.CurrentRow.Index).Cells("id_proveedor").Value & "' AND fc.status='ACTIVO'", conn)
                If rs.RecordCount > 0 Then

                    fecha = rs.Fields("fecha").Value
                    While Not rs.EOF
                        agregar_cuentasxpagar_remisiones(rs.Fields("id_factura_compra").Value, Format(fecha, "dd/MM/yyyy"), rs.Fields("folio").Value, rs.Fields("total").Value, rs.Fields("nombre_empleado").Value)
                        rs.MoveNext()
                    End While

                End If
                Dim total_deuda As Decimal = 0
                Dim total_pagos As Decimal = 0

                rs.Close()
                rs.Open("SELECT CASE WHEN ISNULL(SUM(total)) THEN 0 ELSE SUM(total) END AS total_deuda FROM factura_compra WHERE id_proveedor='" & dgv_proveedores.Rows(dgv_proveedores.CurrentRow.Index).Cells("id_proveedor").Value & "' AND status='ACTIVO'", conn)
                If rs.RecordCount > 0 Then
                    total_deuda = rs.Fields("total_deuda").Value
                End If
                rs.Close()
                rs.Open("SELECT CASE WHEN ISNULL(SUM(pc.importe)) THEN 0 ELSE SUM(pc.importe) END  AS total_pagado FROM pagos_compras pc " & _
                        "JOIN factura_compra fc ON fc.id_factura_compra=pc.id_factura_compra " & _
                        "WHERE fc.id_proveedor='" & dgv_proveedores.Rows(dgv_proveedores.CurrentRow.Index).Cells("id_proveedor").Value & "' AND fc.status='ACTIVO' AND pc.status='ACTIVO'", conn)
                If rs.RecordCount > 0 Then
                    total_pagos = rs.Fields("total_pagado").Value
                End If
                rs.Close()
                tb_total.Text = FormatCurrency(total_deuda)
                tb_abonos.Text = FormatCurrency(total_pagos)
                tb_saldo.Text = FormatCurrency(total_deuda - total_pagos)
                'conn.close()
                'conn = Nothing
                If dgv_remision.Rows.Count > 0 Then
                    cargar_detalle_recepcion(dgv_remision.Rows(dgv_remision.CurrentRow.Index).Cells("id_factura_compra").Value)
                End If
            End If
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub dgv_remision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_remision.Click
        If dgv_remision.Rows.Count > 0 Then
            cargar_detalle_recepcion(dgv_remision.Rows(dgv_remision.CurrentRow.Index).Cells("id_factura_compra").Value)
        End If
    End Sub
End Class