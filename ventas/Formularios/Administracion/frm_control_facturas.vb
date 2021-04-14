Public Class frm_control_de_facturas
    Private Sub frm_control_de_facturas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        global_frm_control_facturas = 0
    End Sub
    Public Sub frm_control_de_facturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        global_frm_control_facturas = 1
        estilo_control_facturas(dgv_facturas)
        obtener_facturas(0, tb_busqueda.Text)
        With lst_tickets
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("folio", 60)
            .Columns.Add("Fecha", 80)
            .Columns.Add("Total", 70, HorizontalAlignment.Right)
            .Columns.Add("Estatus", 80, HorizontalAlignment.Right)
        End With
        cb_filtro.Items.Add(New myItem(0, "TODAS LAS FACTURAS"))
        cb_filtro.Items.Add(New myItem(1, "PAGADAS"))
        cb_filtro.Items.Add(New myItem(2, "PENDIENTES DE PAGO"))
    End Sub
    Private Sub obtener_facturas(ByVal id_tipo As Integer, Optional ByVal busqueda As String = "")
        tabla_control_facturas.Clear()
        Dim filtro As String = ""
        If id_tipo = 0 Then
            If Trim(busqueda) = "" Then
                filtro = ""
            Else
                filtro = " WHERE 1 AND (persona.alias like '%" & Trim(busqueda) & "%' OR empresa.alias like '%" & Trim(busqueda) & "%' OR factura.numero like '%" & Trim(busqueda) & "%')"
            End If
        ElseIf id_tipo = 1 Then
            If Trim(busqueda) = "" Then
                filtro = " WHERE factura.estatus='PAGADO'"
            Else
                filtro = " WHERE 1 AND (persona.alias like '%" & Trim(busqueda) & "%' OR empresa.alias like '%" & Trim(busqueda) & "%' OR factura.numero like '%" & Trim(busqueda) & "%') AND factura.estatus='PAGADO'"
            End If
        ElseIf id_tipo = 2 Then
            If Trim(busqueda) = "" Then
                filtro = " WHERE factura.estatus='PENDIENTE'"
            Else
                filtro = " WHERE 1 AND (persona.alias like '%" & Trim(busqueda) & "%' OR empresa.alias like '%" & Trim(busqueda) & "%' OR factura.numero like '%" & Trim(busqueda) & "%') AND factura.estatus='PENDIENTE'"
            End If
        End If
        Dim rx As New ADODB.Recordset
        'Conectar()
        rs.Open("SELECT factura.id_factura,factura.fecha,factura.numero,factura.total,factura.estatus,cliente.id_cliente, " & _
                "CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre FROM cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "JOIN factura ON factura.id_cliente=cliente.id_cliente " & filtro & " ORDER BY factura.numero DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF

                Dim fecha_larga As Date = rs.Fields("fecha").Value
                Dim razon_social As String = ""
                rx.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE trim(Concat(persona.ap_paterno,' ',persona.ap_materno,' ',persona.nombre)) END AS razon_social FROM cliente " & _
               "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
               "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
               "JOIN factura ON factura.id_cliente=cliente.id_cliente WHERE factura.id_factura=" & rs.Fields("id_factura").Value, conn)
                If rx.RecordCount > 0 Then
                    razon_social = rx.Fields("razon_social").Value
                End If
                rx.Close()

                agregar_control_facturas(rs.Fields("id_factura").Value, rs.Fields("numero").Value, rs.Fields("nombre").Value, fecha_larga.ToLongDateString, rs.Fields("total").Value, rs.Fields("fecha").Value, rs.Fields("estatus").Value, razon_social)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub cargar_tickets(ByVal id_factura As Integer)
        lst_tickets.Items.Clear()
        Dim i As Integer = 0
        'Conectar()
        rs.Open("SELECT id_venta,fecha,total,status from venta WHERE id_factura='" & id_factura & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("id_venta").Value
                str(1) = Format(rs.Fields("fecha").Value, "dd/MM/yyyy")
                str(2) = "$ " & FormatNumber(rs.Fields("total").Value, 2)
                str(3) = rs.Fields("status").Value

                lst_tickets.Items.Add(New ListViewItem(str, 0))
                lst_tickets.Items(i).Tag = rs.Fields("id_venta").Value
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()

        rs.Open("SELECT venta.id_venta,venta.fecha,venta.total,venta.status FROM venta JOIN pedido_clientes ON pedido_clientes.id_venta=venta.id_venta WHERE pedido_clientes.id_factura='" & id_factura & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("id_venta").Value
                str(1) = rs.Fields("fecha").Value
                str(2) = "$ " & FormatNumber(rs.Fields("total").Value, 2)
                str(3) = rs.Fields("status").Value

                lst_tickets.Items.Add(New ListViewItem(str, 0))
                lst_tickets.Items(i).Tag = rs.Fields("id_venta").Value
                rs.MoveNext()
                i = i + 1
            End While

        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub dgv_facturas_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_facturas.CellFormatting
        e.CellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        For x = 0 To dgv_facturas.Columns.Count - 1
            If dgv_facturas.Columns(e.ColumnIndex).Index = x Then

                If dgv_facturas.Columns(e.ColumnIndex).Index = 6 Then '9 id_estatus
                    e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                    If e.Value = "PAGADO" Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkOliveGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = "PENDIENTE" Then
                        e.CellStyle.BackColor = Color.DarkOrange
                        e.CellStyle.ForeColor = Color.White
                    End If
                Else
                    e.CellStyle.BackColor = Color.White
                    e.CellStyle.ForeColor = Color.Black
                    e.CellStyle.SelectionBackColor = Color.Black
                    e.CellStyle.SelectionForeColor = Color.White
                End If
            End If

        Next
    End Sub
    Private Sub dgv_facturas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_facturas.Click
        If dgv_facturas.SelectedRows.Count > 0 Then
            cargar_tickets(dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("id_factura").Value)
        End If
    End Sub
    Private Sub cb_filtro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_filtro.SelectedIndexChanged
        obtener_facturas(CType(cb_filtro.SelectedItem, myItem).Value, tb_busqueda.Text)
    End Sub

    Private Sub dgv_facturas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_facturas.CellContentClick

    End Sub

    Private Sub btn_pagar_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagar_ticket.Click
        If lst_tickets.SelectedItems.Count > 0 Then
            If lst_tickets.SelectedItems.Item(0).SubItems(3).Text = "PENDIENTE" Then
                pagar_ticket(lst_tickets.SelectedItems.Item(0).Tag)
            Else
                MsgBox("No se puede pagar este ticket", MsgBoxStyle.Information, "Aviso")
            End If
        Else
            MsgBox("Seleccione un ticket para pagar", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub
    Private Sub pagar_ticket(ByVal id_venta As Integer)
        frm_formas_pago_ventas.id_venta = id_venta
        frm_formas_pago_ventas.credito = 1
        frm_formas_pago_ventas.nombre_cliente = dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("razon_social").Value
        frm_formas_pago_ventas.cliente_alias = dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("cliente").Value
        frm_formas_pago_ventas.empleado_venta = global_nombre
        frm_formas_pago_ventas.credito_asignado = False
        frm_formas_pago_ventas.ShowDialog()

    End Sub
    Public Sub actualizar_estatus_factura()
        Dim importe_total_tickets As Decimal = 0
        'Conectar()
        rs.Open("SELECT total from venta WHERE id_factura='" & dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("id_factura").Value & "' AND status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                importe_total_tickets += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT venta.total FROM venta JOIN pedido_clientes ON pedido_clientes.id_venta=venta.id_venta WHERE pedido_clientes.id_factura='" & dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("id_factura").Value & "' AND venta.status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                importe_total_tickets += rs.Fields("total").Value
                rs.MoveNext()
            End While

        End If
        rs.Close()

        If CDec(dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("total").Value) = importe_total_tickets Then
            conn.Execute("UPDATE factura SET estatus='PAGADO' WHERE id_factura=" & dgv_facturas.Rows(dgv_facturas.CurrentRow.Index).Cells("id_factura").Value)
        End If
        'Conectar()
    End Sub
    Private Sub btn_buscar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If cb_filtro.SelectedIndex = -1 Then
            obtener_facturas(0, tb_busqueda.Text)
        Else
            obtener_facturas(CType(cb_filtro.SelectedItem, myItem).Value, tb_busqueda.Text)
        End If

    End Sub
End Class