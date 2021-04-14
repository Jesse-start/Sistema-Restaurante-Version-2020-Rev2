Public Class frm_eliminacion_masiva
    Dim numero_cuentas_total As Integer = 0
    Dim numero_cuentas_modificadas As Integer = 0
    Dim total_importe_anterior As Decimal = 0
    Dim total_importe_nuevo As Decimal = 0
    Dim diferencia_importe As Decimal = 0
    Dim diferencia_porcentaje As Integer = 0

    Private Sub frm_eliminacion_masiva_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        configuracion_listas()
        rellenar_combo_tipo_eliminacion()
    End Sub
    Private Sub rellenar_combo_tipo_eliminacion()
        cb_tipo_eliminacion.Items.Clear()
        cb_tipo_eliminacion.SelectedText = ""
        cb_tipo_eliminacion.Items.Add(New myItem(0, "Folio", 0, 0))
        cb_tipo_eliminacion.Items.Add(New myItem(1, "Productos", 0, 0))
        cb_tipo_eliminacion.SelectedIndex = 0
    End Sub

    Private Sub configuracion_listas()
        With lst_mantenimientos
            .CheckBoxes = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Folio", 80)
            .Columns.Add("Fecha", 150)
            .Columns.Add("Cliente", 200)
            .Columns.Add("Cancelado", 120)
            .Columns.Add("Facturado", 120)
            .Columns.Add("Total", 120)
            .Columns.Add("Forma de pago", 100)
            .Columns.Add("Eliminar", 100)
        End With

       
    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        buscar_folios(CType(cb_tipo_eliminacion.SelectedItem, myItem).Value, dtp_fecha_inicio.Value, dtp_fecha_termino.Value)
    End Sub
    Private Sub buscar_folios(tipo_busqueda As Integer, fecha_inicio As Date, fecha_termino As Date)
        lst_mantenimientos.Items.Clear()
        Dim rw As New ADODB.Recordset
        Dim i As Integer = 0
        Dim forma_pago As String = ""


        rs.Open("SELECT v.id_venta,v.fecha,v.id_forma_pago,v.total,v.id_factura,v.status," & _
                "CASE WHEN c.id_persona = 0 THEN  e.razon_social ELSE CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) END AS nombre " & _
                "FROM venta v " & _
               "JOIN cliente c ON v.id_cliente=c.id_cliente " & _
                "LEFT OUTER JOIN persona p ON p.id_persona = c.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
                "WHERE v.id_cliente=1 AND v.status='CERRADA' AND DATE(v.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "'", conn)
        If rs.RecordCount > 0 Then

            rw.Open("SELECT fp.descripcion AS forma_pago FROM pagos_ventas pv JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago WHERE pv.id_venta='" & rs.Fields("id_venta").Value & "'", conn)
            If rw.RecordCount > 0 Then
                forma_pago = ""
                While Not rw.EOF
                    forma_pago &= " " & rw.Fields("forma_pago").Value
                    rw.MoveNext()
                End While
            End If
            rw.Close()

            While Not rs.EOF
                Dim str(6) As String
                str(0) = rs.Fields("id_venta").Value
                str(1) = rs.Fields("fecha").Value
                str(2) = rs.Fields("nombre").Value
                str(3) = rs.Fields("status").Value
                str(4) = rs.Fields("id_factura").Value
                str(5) = FormatCurrency(rs.Fields("total").Value)
                str(6) = forma_pago


                lst_mantenimientos.Items.Add(New ListViewItem(str, 0))
                lst_mantenimientos.Items(i).Tag = rs.Fields("id_venta").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()
        buscar_cuentas_eliminar()
        calcular_totales()

    End Sub
    Private Sub buscar_cuentas_eliminar()
        Dim importe_eliminar As Decimal = CDec(tb_importe_eliminar.Text)


        For count = 0 To lst_mantenimientos.Items.Count - 1

            Dim importe_cuenta As Decimal = CDec(lst_mantenimientos.Items(count).SubItems(5).Text())

            If importe_cuenta > importe_eliminar Then
                lst_mantenimientos.Items(count).Checked = True
                lst_mantenimientos.Items(count).BackColor = Color.Coral
            Else
                lst_mantenimientos.Items(count).Checked = False
                lst_mantenimientos.Items(count).BackColor = Color.White
            End If
            'Dim diferencia_porcentaje As Integer = 0
        Next
    End Sub

    Private Sub calcular_totales()
        numero_cuentas_total = 0
        numero_cuentas_modificadas = 0
        total_importe_anterior = 0
        total_importe_nuevo = 0
        diferencia_importe = 0

        numero_cuentas_total = lst_mantenimientos.Items.Count

        For count = 0 To lst_mantenimientos.Items.Count - 1
            total_importe_anterior += lst_mantenimientos.Items(count).SubItems(5).Text()

            If lst_mantenimientos.Items(count).Checked = True Then
                numero_cuentas_modificadas += 1
            Else
                total_importe_nuevo += lst_mantenimientos.Items(count).SubItems(5).Text()
            End If


            'Dim diferencia_porcentaje As Integer = 0
        Next
        diferencia_importe = total_importe_anterior - total_importe_nuevo
        tb_cuentas_total.Text = numero_cuentas_total
        tb_cuentas_modificar.Text = numero_cuentas_modificadas
        tb_importe_anterior.Text = FormatCurrency(total_importe_anterior)
        tb_importe_nuevo.Text = FormatCurrency(total_importe_nuevo)
        tb_importe_diferencia.Text = FormatCurrency(diferencia_importe)

    End Sub
    Private Sub lst_mantenimientos_Click(sender As Object, e As System.EventArgs) Handles lst_mantenimientos.Click
        For count = 0 To lst_mantenimientos.Items.Count - 1
            If lst_mantenimientos.Items(count).Checked = True Then
                lst_mantenimientos.Items(count).BackColor = Color.Coral
            Else
                lst_mantenimientos.Items(count).BackColor = Color.White
                ' frm_inventario_fisico.agregar_categoria_inventario(lst_grupo_insumos.Items(count).Tag(), CType(cb_almacen.SelectedItem, myItem).Value)
                '  MsgBox(lst_grupo_insumos.Items(count).Tag() & " " & lst_grupo_insumos.Items(count).SubItems(1).Text())
            End If
        Next
        calcular_totales()
    End Sub
    Private Sub btn_cancelar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btn_aplicar_Click(sender As System.Object, e As System.EventArgs) Handles btn_aplicar.Click
        If MsgBox("Esta seguro que desea guardar este mantenimiento", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
            Dim id_bitacora As Integer = 0
            conn.Execute("INSERT INTO manto_bitacora(fecha_proceso,fecha_inicial,fecha_final,total_cuentas,total_cuentas_modificadas,importe_anterior,importe_nuevo,diferencia,tipo_eliminacion) " & _
                         " VALUES(NOW(),'" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "','" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "','" & numero_cuentas_total & "','" & numero_cuentas_modificadas & "','" & total_importe_anterior & "','" & total_importe_nuevo & "','" & diferencia_importe & "','" & cb_tipo_eliminacion.Text & "')")

            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            id_bitacora = rs.Fields(0).Value
            rs.Close()

            Dim id_venta As Integer = 0

            rs.Open("SELECT IF(MAX(id_venta) IS NULL,1,MAX(id_venta)+1) numero FROM manto_venta", conn)
            If rs.RecordCount > 0 Then
                id_venta = rs.Fields("numero").Value
            End If
            rs.Close()

            For count = 0 To lst_mantenimientos.Items.Count - 1
                If lst_mantenimientos.Items(count).Checked = False Then
                    Dim id_manto_venta As Integer = 0
                    Dim id_manto_venta_detalle As Integer = 0
                    Dim id_manto_cobro As Integer = 0
                    Dim rw As New ADODB.Recordset

                    '=======copias filas de tabla venta==============
                    conn.Execute("INSERT INTO manto_venta(fecha,id_sucursal,id_empleado,id_empleado_caja,id_empleado_validacion,id_cliente,cliente_publico_alias,num_ticket,id_forma_pago,subtotal,total_iva,total_otros,total_descuento,total,codigo,id_factura,id_corte,desc_global_porcent,desc_global_importe,fecha_salida_almacen,credito,status) SELECT fecha,id_sucursal,id_empleado,id_empleado_caja,id_empleado_validacion,id_cliente,cliente_publico_alias,num_ticket,id_forma_pago,subtotal,total_iva,total_otros,total_descuento,total,codigo,id_factura,id_corte,desc_global_porcent,desc_global_importe,fecha_salida_almacen,credito,status FROM venta WHERE id_venta='" & lst_mantenimientos.Items(count).SubItems(0).Text() & "'")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_manto_venta = rs.Fields(0).Value
                    rs.Close()
                    conn.Execute("UPDATE manto_venta SET id_venta='" & id_venta & "',id_bitacora='" & id_bitacora & "' WHERE id_manto_venta='" & id_manto_venta & "'")

                    '=======copias filas de tabla venta1_detalle==============
                    rs.Open("SELECT id_venta_detalle FROM venta_detalle WHERE id_venta='" & lst_mantenimientos.Items(count).SubItems(0).Text() & "'")
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            conn.Execute("INSERT INTO manto_venta_detalle(id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,descuento,importe,modificador,id_producto_modificador) SELECT id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,descuento,importe,modificador,id_producto_modificador FROM venta_detalle WHERE id_venta_detalle='" & rs.Fields("id_venta_detalle").Value & "'")
                            rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_manto_venta_detalle = rw.Fields(0).Value
                            rw.Close()
                            conn.Execute("UPDATE manto_venta_detalle SET id_venta='" & id_venta & "' WHERE id_manto_venta_detalle='" & id_manto_venta_detalle & "'")
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()


                    '=======copias filas de tabla pagos_ventas==============

                    rs.Open("SELECT id_pago_ventas FROM pagos_ventas WHERE id_venta='" & lst_mantenimientos.Items(count).SubItems(0).Text() & "'")
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            conn.Execute("INSERT INTO manto_pagos_ventas(importe,cobro,cambio,id_forma_pago,fecha,fecha_cobro,fecha_cancelacion,id_cuenta_receptor,banco_cliente,cuenta_cliente,banco_receptor,cuenta_receptor,num_referencia,num_cheque,num_tarjeta,nombre_cheque,status_cheque,num_notacredito,nombre_notacredito,id_empleado_caja,id_empleado_validacion,status,afecta_caja,es_abono,id_corte) SELECT importe,cobro,cambio,id_forma_pago,fecha,fecha_cobro,fecha_cancelacion,id_cuenta_receptor,banco_cliente,cuenta_cliente,banco_receptor,cuenta_receptor,num_referencia,num_cheque,num_tarjeta,nombre_cheque,status_cheque,num_notacredito,nombre_notacredito,id_empleado_caja,id_empleado_validacion,status,afecta_caja,es_abono,id_corte FROM pagos_ventas WHERE id_pago_ventas='" & rs.Fields("id_pago_ventas").Value & "'")
                            rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_manto_cobro = rw.Fields(0).Value
                            rw.Close()
                            conn.Execute("UPDATE manto_pagos_ventas SET id_venta='" & id_venta & "' WHERE id_manto_cobro='" & id_manto_cobro & "'")
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()

                    id_venta += 1

                End If
            Next
            frm_bitacora.cargar_bitacora()
            Me.Close()

        End If

    End Sub
End Class