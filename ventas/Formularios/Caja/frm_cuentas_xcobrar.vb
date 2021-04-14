Public Class frm_cuentas_xcobrar

    Private Sub frm_cuentas_xcobrar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        global_frm_cuentasxcobrar = 0
    End Sub

    Private Sub gb_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_cuentasxcobrar = 1
        estilo_cuentasxcobrar_clientes(dgv_clientes)
        estilo_cuentasxcobrar_tickets(dgv_tickets)
        estilo_cuentasxcobrar_factura(dgv_prefactura)
        cb_tipo_cuentas.Items.Add("PENDIENTES")
        cb_tipo_cuentas.Items.Add("PAGADAS")
        cb_tipo_cuentas.SelectedIndex = 0
        cargar_clientes(tb_buscar.Text)
        cargar_tickets_cliente()
        cargar_facturas_cliente()
        aplicar_colores()
    End Sub
    Private Sub cargar_facturas_cliente()
        If dgv_clientes.RowCount > 0 Then
            If dgv_clientes.SelectedRows.Count > 0 Then
                tabla_cuentasxcobrar_factura.Clear()
                'cargamos las ventas pendientes del cliente seleccionado
                Dim filtro As String = ""
                If cb_tipo_cuentas.SelectedIndex = 0 Then
                    filtro = "AND estatus='PENDIENTE'"
                Else
                    filtro = "AND estatus='PAGADO'"
                End If
                Dim fecha As Date
                'Conectar()
                rs.Open("SELECT id_factura_electronica,fecha,total,serie FROM factura_electronica WHERE id_cliente='" & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value & "' " & filtro & "", conn)
                If rs.RecordCount > 0 Then

                    While Not rs.EOF
                        fecha = rs.Fields("fecha").Value
                        agregar_cuentasxcobrar_factura(rs.Fields("id_factura_electronica").Value, Format(fecha, "dd/MM/yyyy"), rs.Fields("id_factura_electronica").Value & " " & rs.Fields("serie").Value, rs.Fields("total").Value, "0")
                        rs.MoveNext()
                    End While

                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
            End If
        End If

    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        tab_ticket.BackColor = Color.FromArgb(conf_colores(1))
        tab_prefactura.BackColor = Color.FromArgb(conf_colores(1))

        gb_cliente.ForeColor = Color.FromArgb(conf_colores(2))
        gb_ticktes.ForeColor = Color.FromArgb(conf_colores(2))


        btn_cobrar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cobrar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

        lbl_cliente.ForeColor = Color.FromArgb(conf_colores(13))
        tb_cliente.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_total.ForeColor = Color.FromArgb(conf_colores(13))
        tb_total.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_abonos.ForeColor = Color.FromArgb(conf_colores(13))
        tb_abonos.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_saldo.ForeColor = Color.FromArgb(conf_colores(13))
        tb_saldo.ForeColor = Color.FromArgb(conf_colores(13))

    End Sub

    Public Sub cargar_clientes(ByVal busqueda As String)
        tabla_cuentasxcobrar_clientes.Clear()
        Dim filtro As String = ""
        If busqueda <> "" Then
            filtro = " AND (empresa.alias LIKE '%" & busqueda & "%'" & _
                        " OR empresa.razon_social LIKE '%" & busqueda & "%'" & _
                        " OR persona.alias LIKE '%" & busqueda & "%'" & _
                        " OR persona.nombre LIKE '%" & busqueda & "%'" & _
                        " OR persona.ap_paterno LIKE '%" & busqueda & "%'" & _
                        " OR persona.ap_materno LIKE '%" & busqueda & "%')"
        End If
        Dim filtro2 As String = ""
        If cb_tipo_cuentas.SelectedIndex = 0 Then
            filtro2 = " AND venta.status='PENDIENTE'"
        Else
            filtro2 = " AND venta.status='CERRADA'"
        End If

        Dim filtro3 As String = ""
        If cb_tipo_cuentas.SelectedIndex = 0 Then
            filtro3 = " AND factura.estatus='PENDIENTE'"
        Else
            filtro3 = " AND factura.estatus='PAGADO'"
        End If
        'Conectar()
        rs.Open("SELECT DISTINCT CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre, CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS razon_social, cliente.id_cliente,cliente_credito.credito " & _
                "FROM cliente " & _
                "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
                "JOIN cliente_credito ON cliente_credito.id_cliente=cliente.id_cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "WHERE 1 " & filtro & filtro2 & "", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_cuentasxcobrar_clientes(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value, rs.Fields("credito").Value, rs.Fields("razon_social").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        rs.Open("SELECT DISTINCT CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre, CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS razon_social, cliente.id_cliente,cliente_credito.credito " & _
               "FROM cliente " & _
               "JOIN factura ON factura.id_cliente=cliente.id_cliente " & _
               "JOIN cliente_credito ON cliente_credito.id_cliente=cliente.id_cliente " & _
               "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
               "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
               "WHERE 1 " & filtro & " " & filtro3 & " AND factura.id_cliente NOT IN (SELECT DISTINCT id_cliente FROM venta WHERE 1 " & filtro2 & ")", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_cuentasxcobrar_clientes(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value, rs.Fields("credito").Value, rs.Fields("razon_social").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub dgv_clientes_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_clientes.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        For x = 0 To dgv_clientes.Columns.Count - 1
            If dgv_clientes.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_clientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_clientes.Click
        cargar_tickets_cliente()
        cargar_facturas_cliente()
    End Sub

    Private Sub btn_cobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cobrar.Click
        If dgv_tickets.RowCount > 0 Then
            If dgv_tickets.SelectedRows.Count > 0 Then
                frm_formas_pago_ventas.id_venta = dgv_tickets.Rows(dgv_tickets.CurrentRow.Index).Cells("id_venta").Value
                frm_formas_pago_ventas.credito = dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("credito").Value
                frm_formas_pago_ventas.nombre_cliente = tb_cliente.Text
                frm_formas_pago_ventas.empleado_venta = dgv_tickets.Rows(dgv_tickets.CurrentRow.Index).Cells("nombre_empleado").Value
                frm_formas_pago_ventas.credito_asignado = True
                frm_formas_pago_ventas.ShowDialog()
            Else
                MsgBox("Seleccione un ticket de la lista", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Else
            MsgBox("Este cliente ya no tiene tickets pendientes de cobro", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub
    Private Sub dgv_tickets_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_tickets.CellFormatting, dgv_prefactura.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        For x = 0 To dgv_tickets.Columns.Count - 1
            If dgv_tickets.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Public Sub cargar_tickets_cliente()
        Dim filtro As String = ""
        If cb_tipo_cuentas.SelectedIndex = 0 Then
            filtro = "AND v.status='PENDIENTE' "
        Else
            filtro = "AND v.status='CERRADA' "
        End If
        If dgv_clientes.RowCount > 0 Then
            If dgv_clientes.SelectedRows.Count > 0 Then
                tabla_cuentasxcobrar_tickets.Clear()
                'cargamos las ventas pendientes del cliente seleccionado
                tb_cliente.Text = dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("razon_social").Value
                Dim fecha As Date
                'Conectar()
                Dim rw As New ADODB.Recordset
                Dim total_cobrado As Decimal
                Dim saldo As Decimal = 0
                rs.Open("SELECT v.id_venta,v.fecha,v.total, CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS  nombre_empleado " & _
                        "FROM venta v " & _
                        "JOIN empleado e ON e.id_empleado=v.id_empleado " & _
                        "JOIN persona p ON p.id_persona=e.id_persona " & _
                        "WHERE v.id_cliente='" & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value & "' " & filtro & "", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        fecha = rs.Fields("fecha").Value

                        rw.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total_cobrado FROM pagos_ventas WHERE id_venta='" & rs.Fields("id_venta").Value & "' AND status='ACTIVO'", conn)
                        If rw.RecordCount > 0 Then
                            total_cobrado = rw.Fields("total_cobrado").Value
                        End If
                        rw.close()

                        saldo = CDec(rs.Fields("total").Value) - total_cobrado

                        agregar_cuentasxcobrar_tickets(rs.Fields("id_venta").Value, Format(fecha, "dd/MM/yyyy"), rs.Fields("id_venta").Value, rs.Fields("total").Value, total_cobrado, saldo, rs.Fields("nombre_empleado").Value)
                        rs.MoveNext()
                    End While

                End If
                Dim total_credito As Decimal = 0
                Dim total_pagos As Decimal = 0

                rs.Close()
                rs.Open("SELECT CASE WHEN ISNULL(SUM(total)) THEN 0 ELSE SUM(total) END AS total_credito FROM venta WHERE id_cliente='" & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value & "' AND status='PENDIENTE'", conn)
                If rs.RecordCount > 0 Then
                    total_credito = rs.Fields("total_credito").Value
                End If
                rs.Close()
                rs.Open("SELECT CASE WHEN ISNULL(SUM(pv.importe)) THEN 0 ELSE SUM(pv.importe) END  AS total_pagado FROM pagos_ventas pv " & _
                        "JOIN venta v ON v.id_venta=pv.id_venta " & _
                        "WHERE v.id_cliente='" & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value & "' AND v.status='PENDIENTE' AND pv.status='ACTIVO' ", conn)
                If rs.RecordCount > 0 Then
                    total_pagos = rs.Fields("total_pagado").Value
                End If
                rs.Close()
                tb_total.Text = FormatCurrency(total_credito)
                tb_abonos.Text = FormatCurrency(total_pagos)
                tb_saldo.Text = FormatCurrency(total_credito - total_pagos)
                'conn.close()
                'conn = Nothing

            End If
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_prefactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prefactura.Click
        If dgv_tickets.RowCount > 0 Then
            If dgv_tickets.SelectedRows.Count > 0 Then
                frm_facturacion_electronica.Show()
                For x = 0 To dgv_tickets.Rows.Count - 1
                    If dgv_tickets.Rows(x).Selected = True Then
                        frm_facturacion_electronica.rb_ticket_alone.Checked = True
                        frm_facturacion_electronica.tb_ticket_alone.Text = dgv_tickets.Item("id_venta", x).Value
                        frm_facturacion_electronica.btn_agregar_doc_Click(sender, e)
                    End If
                Next
                frm_facturacion_electronica.Show()
            End If
        Else
            MsgBox("Seleccione los tickets que desee prefacturar", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_ver_prefactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ver_prefactura.Click
        If dgv_prefactura.RowCount > 0 Then
            If dgv_prefactura.SelectedRows.Count > 0 Then
                frm_facturacion_electronica.Show()
                frm_facturacion_electronica.cargar_factura(dgv_prefactura.Rows(dgv_prefactura.CurrentRow.Index).Cells("id_factura").Value)
            Else
                MsgBox("Seleccione la prefactura que desee abrir", MsgBoxStyle.Exclamation, "Aviso")
            End If
        End If
    End Sub

    Private Sub btn_imprimir_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_ticket.Click
        If dgv_tickets.RowCount > 0 Then
            If dgv_tickets.SelectedRows.Count > 0 Then
                For x = 0 To dgv_tickets.Rows.Count - 1
                    If dgv_tickets.Rows(x).Selected = True Then
                        For k = 0 To conf_pv(5)
                            'Conectar()
                            Dim subtotal As Decimal = 0
                            Dim total_iva As Decimal = 0
                            Dim total_otros As Decimal = 0
                            Dim total As Decimal = 0
                            Dim empleado As String = ""
                            rs.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado,v.subtotal,v.total_iva,v.total_otros,v.total FROM venta v JOIN empleado e ON e.id_empleado=v.id_empleado JOIN persona p ON p.id_persona=e.id_persona WHERE v.id_venta='" & dgv_tickets.Item("id_venta", x).Value & "'", conn)
                            If rs.RecordCount > 0 Then
                                subtotal = rs.Fields("subtotal").Value
                                total_iva = rs.Fields("total_iva").Value
                                total_otros = rs.Fields("total_otros").Value
                                total = rs.Fields("total").Value
                                empleado = rs.Fields("empleado").Value
                            End If
                            rs.Close()
                            'conn.close()
                            'conn = Nothing
                            imprimir_ticket_venta(dgv_tickets.Item("id_venta", x).Value, dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("razon_social").Value, dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("cliente").Value, dgv_tickets.Item("id_venta", x).Value, subtotal, total_iva, total_otros, total, "$0.00", "$0.00", empleado, "Credito", k, conf_pv(5))
                        Next
                    End If
                Next
            End If
        Else
            MsgBox("Seleccione los tickets que desee imprimir", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_imprimir_pagare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_pagare.Click
        If dgv_tickets.RowCount > 0 Then
            If dgv_tickets.SelectedRows.Count > 0 Then
                For x = 0 To dgv_tickets.Rows.Count - 1
                    If dgv_tickets.Rows(x).Selected = True Then
                        For k = 0 To conf_pv(5)
                            'Conectar()
                            Dim subtotal As Decimal = 0
                            Dim total_iva As Decimal = 0
                            Dim total_otros As Decimal = 0
                            Dim total As Decimal = 0
                            Dim empleado As String = ""
                            rs.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado,v.subtotal,v.total_iva,v.total_otros,v.total FROM venta v JOIN empleado e ON e.id_empleado=v.id_empleado JOIN persona p ON p.id_persona=e.id_persona WHERE v.id_venta='" & dgv_tickets.Item("id_venta", x).Value & "'", conn)
                            If rs.RecordCount > 0 Then
                                subtotal = rs.Fields("subtotal").Value
                                total_iva = rs.Fields("total_iva").Value
                                total_otros = rs.Fields("total_otros").Value
                                total = rs.Fields("total").Value
                                empleado = rs.Fields("empleado").Value
                            End If
                            rs.Close()
                            'conn.close()
                            'conn = Nothing
                            imprimir_ticket_credito2("pagare", dgv_tickets.Item("id_venta", x).Value, dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("razon_social").Value, dgv_tickets.Item("id_venta", x).Value, total, empleado, k)
                        Next
                    End If
                Next
            End If
        Else
            MsgBox("Seleccione los tickets que desee imprimir", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Public Sub imprimir_listado_prefactura()
        Dim S As ticket = New ticket

        S.HeaderImage = global_logotipo
        S.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                S.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), 39, " "))
            Else
                Exit For
            End If
        Next

        S.AnadirLineaCLiente("" & centrar_texto("FACTURAS POR COBRAR", 27, " ") & "")
        S.AnadirLineaCLiente("")
        S.AnadirLineaCLiente("" & centrar_texto(dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("cliente").Value, 27, " ") & "")


        S.AnadirLineaSubcabeza("")

        S.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        S.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        S.AnadirLineaSubcabeza("Cliente :" & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("razon_social").Value)

        S.AnadirLineaSubcabeza("")
        S.AnadirLineaSubcabeza("FECHA    FACTURA   TOTAL FACTURA")

        ' S.AnadirLineaSubcabeza(" CODIGO  UNIDAD  EXISTENCIAS")
        S.AnadirLineaSubcabeza("")
        Dim total As Decimal = 0

        For x = 0 To tabla_cuentasxcobrar_factura.Rows.Count - 1
            total = total + CDec(dgv_prefactura.Rows(x).Cells("total").Value)
            S.AnadirLineaSubcabeza("" & dgv_prefactura.Rows(x).Cells("fecha").Value & "  " & rellenar_texto_derecha(dgv_prefactura.Rows(x).Cells("folio").Value, 6) & "  " & rellenar_texto_izquierda(FormatCurrency(dgv_prefactura.Rows(x).Cells("total").Value), 9) & " " & rellenar_texto_izquierda(dgv_prefactura.Rows(x).Cells("folio_real").Value, 6))
            S.AnadirLineaSubcabeza("_____________________________________")
        Next
        S.AnadirLineaSubcabeza("")
        S.AnadirLineaSubcabeza("")
        S.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)

        S.ImprimeTicket(conf_impresoras(0))
       
    End Sub
    Public Sub imprimir_tickets_credito()
        Dim S As ticket = New ticket

        S.HeaderImage = global_logotipo
        S.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                S.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), 39, " "))
            Else
                Exit For
            End If
        Next

        S.AnadirLineaCLiente("" & centrar_texto("TICKETS POR COBRAR", 27, " ") & "")
        S.AnadirLineaCLiente("")
        S.AnadirLineaCLiente("" & centrar_texto(dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("cliente").Value, 27, " ") & "")


        S.AnadirLineaSubcabeza("")

        S.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        S.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        S.AnadirLineaSubcabeza("Cliente :" & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("razon_social").Value)

        S.AnadirLineaSubcabeza("")
        S.AnadirLineaSubcabeza("FECHA       FOLIO     TOTAL  ")

        ' S.AnadirLineaSubcabeza(" CODIGO  UNIDAD  EXISTENCIAS")
        S.AnadirLineaSubcabeza("")
        Dim total As Decimal = 0

        For x = 0 To tabla_cuentasxcobrar_tickets.Rows.Count - 1
            total = total + CDec(dgv_tickets.Rows(x).Cells("importe").Value)
            S.AnadirLineaSubcabeza("" & dgv_tickets.Rows(x).Cells("fecha").Value & "  " & rellenar_texto_derecha(dgv_tickets.Rows(x).Cells("id_venta").Value, 6) & "  " & rellenar_texto_izquierda(FormatCurrency(dgv_tickets.Rows(x).Cells("importe").Value), 9))
            S.AnadirLineaSubcabeza("_____________________________________")
        Next
        S.AnadirLineaSubcabeza("")
        S.AnadirLineaSubcabeza("")
        S.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)

        S.ImprimeTicket(conf_impresoras(0))

    End Sub

    Private Sub btn_imprimir_listado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_listado.Click
        imprimir_listado_prefactura()
    End Sub
    Private Sub btn_imprimir_listado_tickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_listado_tickets.Click
        imprimir_tickets_credito()
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        tabla_cuentasxcobrar_tickets.Clear()
        tabla_cuentasxcobrar_factura.Clear()
        cargar_clientes(tb_buscar.Text)
        cargar_tickets_cliente()
        cargar_facturas_cliente()
    End Sub

    Private Sub btn_cobrar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cobrar_factura.Click
        If dgv_prefactura.RowCount > 0 Then
            If dgv_prefactura.SelectedRows.Count > 0 Then
                frm_formas_pago_factura.id_factura = dgv_prefactura.Rows(dgv_prefactura.CurrentRow.Index).Cells("id_factura").Value
                frm_formas_pago_factura.nombre_cliente = tb_cliente.Text
                frm_formas_pago_factura.empleado_venta = global_usuario_nombre
                frm_formas_pago_factura.ShowDialog()
            Else
                MsgBox("Seleccione una factura de la lista", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Else
            MsgBox("No se encontraron facturas por cobrar", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub dgv_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_clientes.CellContentClick

    End Sub
End Class