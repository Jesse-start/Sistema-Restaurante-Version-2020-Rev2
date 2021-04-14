Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Module Funciones_imprimir_v3

    Public Sub imprimir_corte_caja_v3(ByVal id_corte As Integer)

        EncabezadoConcepto = ""
        Dim folio_inicial As Integer = 0
        Dim fecha As DateTime
        Dim folio_final As Integer = 0
        Dim total_ventas As Decimal = 0
        Dim total_cobros As Decimal = 0
        Dim total_cobros_efectivo As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim fondo_caja As Decimal = 0
        Dim total_depositos As Decimal = 0
        Dim total_retiros As Decimal = 0
        Dim total_devoluciones As Decimal = 0
        Dim total_caja_sinfondo As Decimal = 0
        Dim total_pago_proveedores As Decimal = 0
        Dim total_caja As Decimal = 0
        Dim nombre_empleado As String = ""
        Dim id_empleado As Integer = 0
        Dim b As ticket = New ticket
        Dim declaraciom_total_efectivo As Decimal = 0
        Dim declaraciom_total_tarjeta As Decimal = 0
        Dim declaraciom_total_trasnferencia As Decimal = 0
        Dim declaraciom_total_cheque As Decimal = 0
        Dim declaraciom_total_nota As Decimal = 0


        '=====================OBTEMOS LOS DETALLES DEL CORTE=====================
        rs.Open("SELECT fecha,id_empleado_caja,nombre_empleado FROM cortes WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            nombre_empleado = rs.Fields("nombre_empleado").Value
            id_empleado = rs.Fields("id_empleado_caja").Value
        End If
        rs.Close()

        rs.Open("SELECT MIN(id_venta) As folio_inicio,MAX(id_venta) As folio_termino FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("folio_inicio").Value) Then
                folio_inicial = rs.Fields("folio_inicio").Value
                folio_final = rs.Fields("folio_termino").Value
            End If
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(cantidad) IS NULL THEN 0 ELSE SUM(cantidad)  END  as total from retiros WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_retiros = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fondo_caja = rs.Fields("saldo_inicial").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  as total from depositos WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_depositos = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_compras.importe)) THEN 0 ELSE SUM(pagos_compras.importe) END AS total FROM pagos_compras WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            total_pago_proveedores = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
              "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
              "JOIN venta ON venta.id_venta=pagos_ventas.id_venta " &
              "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_cobros_efectivo = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT * FROM corte_declaracion WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            declaraciom_total_efectivo = rs.Fields("total_efectivo").Value
            declaraciom_total_tarjeta = rs.Fields("total_tarjeta").Value
            declaraciom_total_trasnferencia = rs.Fields("total_transferencia").Value
            declaraciom_total_cheque = rs.Fields("total_cheque").Value
            declaraciom_total_nota = rs.Fields("total_nota").Value
        End If

        rs.Close()
        '======================================================================

        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next


        b.AnadirLineaSubcabeza("         CIERRE DE VENTAS")
        b.AnadirLineaSubcabeza("Caja # 1")
        b.AnadirLineaSubcabeza("Usuario:" & nombre_empleado & "")
        b.AnadirLineaSubcabeza("Del folio " & folio_inicial & " al " & folio_final & "")
        b.AnadirLineaSubcabeza("Clientes Atendidos: " & folio_final - folio_inicial + 1 & "")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString)
        b.AnadirLineaSubcabeza("Hora: " & fecha.ToLongTimeString)


        If conf_pv(17) = 1 Then ' IMPRESION DE PRODUCTOS DE PUBLICO EN GENERAL
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza(centrar_texto("PRODUCTOS VENDIDOS", cfg_longitud_maxima_ticket, " "))
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza(" CANT.    UNID.  P.UNITARIO  IMPORTE")

            Dim rw, ry As New ADODB.Recordset
            rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta_detalle vd " & _
               "JOIN venta v ON vd.id_venta=v.id_venta " & _
               "JOIN producto p ON p.id_producto=vd.id_producto " & _
               "WHERE v.id_corte='" & id_corte & " '", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " & _
                                       "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                               "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND  v.id_corte='" & id_corte & "'", conn)
                    If rw.RecordCount > 0 Then
                        While Not rw.EOF
                            ry.Open("SELECT SUM(vd.cantidad) AS cantidad_vendido FROM venta_detalle vd " & _
                           "JOIN venta v ON v.id_venta=vd.id_venta " & _
                   "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND v.id_corte='" & id_corte & "' ORDER BY vd.cantidad DESC", conn)
                            If ry.RecordCount > 0 Then
                                While Not ry.EOF
                                    b.AnadirLineaSubcabeza(" " & rellenar_texto_derecha(ry.Fields("cantidad_vendido").Value, 8) & "   " & rellenar_texto_derecha(rs.Fields("unidad").Value, 5) & "  " & FormatCurrency(rw.Fields("precio").Value) & " " & FormatCurrency(ry.Fields("cantidad_vendido").Value * rw.Fields("precio").Value) & "")
                                    b.AnadirLineaSubcabeza(" " & rs.Fields("descripcion").Value)
                                    b.AnadirLineaSubcabeza("----------------------------------")
                                    ry.MoveNext()
                                End While
                            End If
                            ry.Close()
                            rw.MoveNext()
                        End While
                    End If
                    rw.Close()
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End If

        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND venta.id_corte='" & id_corte & "') AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA'AND venta.id_corte='" & id_corte & "'),venta_detalle.precio) AS puntero " & _
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
"WHERE venta.status='REGALIA' AND venta.id_corte='" & id_corte & "' GROUP BY puntero " & _
"ORDER BY cantidad_vendido DESC", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza("        REGALIAS")
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()

        '----agregar_creditos
        Dim badera_titulo_cuentas_cobrar As Boolean = False
        rs.Open("SELECT venta.id_venta,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
                "FROM cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
                "WHERE venta.status='PENDIENTE' AND venta.id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza(centrar_texto("CUENTAS X COBRAR", cfg_longitud_maxima_ticket, " "))
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            badera_titulo_cuentas_cobrar = True
            While Not rs.EOF
                b.AnadirLineaSubcabeza("N.:" & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT venta.id_venta,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
"FROM cliente " & _
"LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
"LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
"JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
"WHERE venta.status='CERRADA' AND credito='1' AND venta.id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            If badera_titulo_cuentas_cobrar = False Then
                b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
                b.AnadirLineaSubcabeza(centrar_texto("CUENTAS X COBRAR", cfg_longitud_maxima_ticket, " "))
                b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            End If
            While Not rs.EOF
                b.AnadirLineaSubcabeza("N.:" & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        b.AnadirLineaSubcabeza("")

        Dim abonos(4) As Decimal

        For x = 0 To 4
            abonos(x) = 0
        Next
        'Conectar()
        'rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & id_empleado & "' AND pagos_ventas.es_abono='1' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='" & id_corte & "' GROUP BY forma_pago.nombre", conn)
        'If rs.RecordCount > 0 Then
        'b.AnadirLineaSubcabeza("══════════════════════════════════")
        'b.AnadirLineaSubcabeza("         COBROS CREDITOS     ")
        'b.AnadirLineaSubcabeza("══════════════════════════════════")
        'While Not rs.EOF
        'Dim i As Integer = rs.Fields("id_forma_pago").Value
        'abonos(i) += rs.Fields("total").Value
        'rs.MoveNext()
        'End While
        'End If
        'rs.Close()
        'conn.close()
        'conn = Nothing
        'For x = 0 To 4
        'If abonos(x) <> 0 Then
        'b.AnadirLineaSubcabeza("" & nombre_forma_pago(x) & "   " & FormatCurrency(abonos(x)) & "")
        'End If
        'Next
        'b.AnadirLineaSubcabeza("-----------------------------------")

        rs.Open("SELECT pagos_ventas.importe,pagos_ventas.id_venta,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " &
                 "FROM cliente " &
                 "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " &
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                "JOIN venta ON venta.id_cliente=cliente.id_cliente " &
                "JOIN pagos_ventas ON pagos_ventas.id_venta=venta.id_venta " &
                "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
                "WHERE pagos_ventas.id_empleado_caja='" & id_empleado & "' AND pagos_ventas.es_abono='1' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza(centrar_texto("COBROS CREDITOS", cfg_longitud_maxima_ticket, " "))
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                b.AnadirLineaSubcabeza("N.:" & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("importe").Value) & "")
                'objWriter.WriteLine("" & rellenar_texto_izquierda(FormatCurrency(rs.Fields("importe").Value), 9) & " N.Venta" & rellenar_texto_izquierda(rs.Fields("id_venta").Value, 6) & " " & rs.Fields("nombre").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'limpiar_abonos()
        'Conectar()
        Dim rx As New ADODB.Recordset

        rs.Open("SELECT pagos_compras.importe,factura_compra.id_proveedor " & _
        " FROM pagos_compras " & _
        "JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  " & _
        "WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'")
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza(centrar_texto("CUENTAS X PAGAR", cfg_longitud_maxima_ticket, " "))
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))

            While Not rs.EOF
                Dim nombre_proveedor As String = ""
                rx.Open("SELECT  CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
                "FROM proveedor " & _
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                "WHERE proveedor.id_proveedor='" & rs.Fields("id_proveedor").Value & "'", conn)
                If rx.RecordCount > 0 Then
                    nombre_proveedor = rx.Fields("nombre").Value
                End If
                rx.Close()
                b.AnadirLineaSubcabeza("" & rellenar_texto_izquierda(FormatCurrency(rs.Fields("importe").Value), 9) & "   " & nombre_proveedor)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        b.AnadirLineaSubcabeza("")


        'limpiar_abonos()
        Dim devoluciones_encontrado As Boolean = False
        'Conectar()
        rs.Open("SELECT devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones.bandera_corte_caja='" & id_corte & "' AND devoluciones.id_empleado='" & id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) AND devoluciones_detalle.id_producto=id) AS cantidad, CONCAT(devoluciones_detalle.unidad,' ',devoluciones_detalle.descripcion) AS producto " & _
                " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion " & _
                "WHERE devoluciones.bandera_corte_caja='" & id_corte & "' GROUP BY id_producto", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza("" & centrar_texto("DEVOLUCIONES (EFECTIVO)", cfg_longitud_maxima_ticket, " ") & "")
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            devoluciones_encontrado = True
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & rs.Fields("cantidad").Value & " " & rs.Fields("producto").Value & " " & FormatCurrency(rs.Fields("precio_unitario").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'b.AnadirLineaSubcabeza("")
        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_impuestos) IS NULL THEN 0 ELSE SUM(total_impuestos)  END  AS total_impuestos,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            'b.AnadirLineaSubcabeza("    SUBTOTAL      " & FormatCurrency(rs.Fields("subtotal").Value) & "")
            'b.AnadirLineaSubcabeza("    TOTAL-IVA     " & FormatCurrency(rs.Fields("total_iva").Value) & "")
            'b.AnadirLineaSubcabeza("    OTROS-IMP.    " & FormatCurrency(rs.Fields("total_otros").Value) & "")
            'b.AnadirLineaSubcabeza("                     ---------")
            If devoluciones_encontrado = True Then
                b.AnadirLineaSubcabeza(" TOTAL-DEVOL. " & FormatCurrency(rs.Fields("total").Value) & "")
                total_devoluciones = rs.Fields("total").Value
            End If

        End If
        rs.Close()

        rs.Open("SELECT importe,descripcion FROM depositos WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza("" & centrar_texto("DEPOSITOS", cfg_longitud_maxima_ticket, " ") & "")
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                b.AnadirLineaSubcabeza(rellenar_texto_izquierda(FormatCurrency(rs.Fields("importe").Value), 9) & " " & rs.Fields("descripcion").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT cantidad,descripcion FROM retiros WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza("" & centrar_texto("RETIROS", cfg_longitud_maxima_ticket, " ") & "")
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                b.AnadirLineaSubcabeza(rellenar_texto_izquierda(FormatCurrency(rs.Fields("cantidad").Value), 9) & " " & rs.Fields("descripcion").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        'conn = Nothing
        'b.AnadirLineaSubcabeza("")
        'b.AnadirLineaSubcabeza("-----------------------------------")
        b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
        b.AnadirLineaSubcabeza(centrar_texto("TOTAL VENTAS POR CATEGORIAS", cfg_longitud_maxima_ticket, " "))
        b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
        b.AnadirLineaSubcabeza("*impuestos incluidos")
        'Conectar()
        rs.Open("SELECT categoria.nombre,SUM(venta_detalle.importe) AS total,SUM(venta_detalle.total_impuestos) AS total_impuestos FROM venta_detalle " & _
                "JOIN producto on producto.id_producto=venta_detalle.id_producto " & _
                "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                "JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
                "WHERE venta.id_corte='" & id_corte & "' GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("", "" & UCase(rs.Fields("nombre").Value) & "", "" & FormatCurrency(rs.Fields("total").Value) & "", "" & FormatCurrency(rs.Fields("total_impuestos").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        'b.AnadirElemento("", "------------", "---------", "---------")

        'Conectar()

        rs.Open("SELECT (CASE WHEN ISNULL(sum(total)) THEN 0 ELSE sum(total) END)as total FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas = total_ventas + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        Dim total_ventas_cobradas As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_ventas.importe)) THEN 0 ELSE SUM(pagos_ventas.importe) END AS total FROM pagos_ventas " & _
                "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas_cobradas = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        b.AnadirTotal("", "")
        b.AnadirTotal("", "------------")
        b.AnadirTotal("TOTAL-VENTAS", "" & FormatCurrency(total_ventas) & "")
        b.AnadirTotal("TOTAL-COBROS", "" & FormatCurrency(total_ventas_cobradas) & "")
        b.AnadirTotal("", "------------")
        b.AnadirTotal("", "")
        b.AnadirTotal("COBROS-EFECTIVO", "" & FormatCurrency(total_cobros_efectivo) & "")
        'Agregamos la suma de impuestos
        rs.Open("SELECT (CASE WHEN ISNULL(sum(total_impuestos)) THEN 0 ELSE sum(total_impuestos) END)as total_impuestos FROM venta WHERE  status='CERRADA' AND id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirTotal("TOTAL-IMPUESTOS", "" & rs.Fields("total_impuestos").Value & "")
        End If
        rs.Close()
        'conn.close()
        '-----------------------------
        total_caja = fondo_caja + total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones
        total_caja_sinfondo = total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones

        b.AnadirTotal("FONDO-CAJA", FormatCurrency(fondo_caja))
        b.AnadirTotal("+TOTAL-DEPOSITOS", FormatCurrency(total_depositos))
        b.AnadirTotal("-TOTAL-RETIROS", FormatCurrency(total_retiros))
        b.AnadirTotal("-DEVOLUCIONES", FormatCurrency(total_devoluciones))

        b.AnadirTotal("-PAGO_PROVEDOR", FormatCurrency(total_pago_proveedores))
        b.AnadirTotal("T.-CAJA(SIN_FONDO)", "" & FormatCurrency(total_caja_sinfondo))
        b.AnadirTotal("", "")

        b.AnadirTotal("TOTAL-CAJA", "" & FormatCurrency(total_caja), 1)
        b.AnadirTotal("", "")


        b.AnadirTotal("======FORMAS-DE-PAGO =======", "")
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
               "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
               "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirTotal("" & UCase(rs.Fields("nombre").Value) & "", "" & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        b.AnadirTotal(" ", "")

        rs.Open("SELECT * FROM corte_detalle WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            '===========================================================      

            b.AnadirTotal("======DECLARACIONES-CAJERO=======", "")
            b.AnadirTotal("Efectivo", "" & FormatCurrency(declaraciom_total_efectivo) & "")
            b.AnadirTotal("->Billete-20", "" & rs.Fields("billete_20").Value & "")
            b.AnadirTotal("->Billete-50", "" & rs.Fields("billete_50").Value & "")
            b.AnadirTotal("->Billete-100", "" & rs.Fields("billete_100").Value & "")
            b.AnadirTotal("->Billete-200", "" & rs.Fields("billete_200").Value & "")
            b.AnadirTotal("->Billete-500", "" & rs.Fields("billete_500").Value & "")
            b.AnadirTotal("->Billete-1000", "" & rs.Fields("billete_1000").Value & "")
            b.AnadirTotal("->Moneda--50c", "" & rs.Fields("moneda_50c").Value & "")
            b.AnadirTotal("->Moneda--1", "" & rs.Fields("moneda_1").Value & "")
            b.AnadirTotal("->Moneda--2", "" & rs.Fields("moneda_2").Value & "")
            b.AnadirTotal("->Moneda--5", "" & rs.Fields("moneda_5").Value & "")
            b.AnadirTotal("->Moneda--10", "" & rs.Fields("moneda_10").Value & "")
            b.AnadirTotal("Tarjeta", "" & FormatCurrency(declaraciom_total_tarjeta) & "")
            b.AnadirTotal("->Visa", "" & rs.Fields("tarjeta_visa").Value & "")
            b.AnadirTotal("->Master-Card", "" & rs.Fields("tarjeta_master_card").Value & "")
            b.AnadirTotal("->American-Express", "" & rs.Fields("tarjeta_american_express").Value & "")
            b.AnadirTotal("Transferencia", "" & FormatCurrency(declaraciom_total_trasnferencia) & "", )
            b.AnadirTotal("Cheque", "" & FormatCurrency(declaraciom_total_cheque) & "", )
            b.AnadirTotal("Nota-Credito", "" & FormatCurrency(declaraciom_total_nota) & "", )
            b.AnadirTotal("", "")
            b.AnadirTotal("Diferencia(+)sobrante(-)faltante", "")
            b.AnadirTotal("DIFERENCIA:", "" & FormatCurrency((declaraciom_total_efectivo - total_caja)) & "", 1)
            '===========================================================

        End If
        rs.Close()

        For x = 0 To 3
            b.AnadirTotal("", "")
        Next
        b.AnadeLineaAlPie("  _______________  ______________")
        b.AnadeLineaAlPie("    CAJERA GRAL.   CAJERA LINEA.")
        '//El metodo AddFooterLine funciona igual que la cabecera
        ' b.AnadeLineaAlPie("PIE DE PAGINA...............")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Public Sub imprimir_corte_x_pantalla(ByVal id_corte As Integer)
        Dim folio_inicial As Integer = 0
        Dim fecha As DateTime
        Dim folio_final As Integer = 0
        Dim total_ventas As Decimal = 0
        Dim total_cobros As Decimal = 0
        Dim total_cobros_efectivo As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim fondo_caja As Decimal = 0
        Dim total_depositos As Decimal = 0
        Dim total_retiros As Decimal = 0
        Dim total_devoluciones As Decimal = 0
        Dim total_caja_sinfondo As Decimal = 0
        Dim total_pago_proveedores As Decimal = 0
        Dim total_caja As Decimal = 0
        Dim nombre_empleado As String = ""
        Dim id_empleado As Integer = 0
        Dim declaraciom_total_efectivo As Decimal = 0
        Dim declaraciom_total_tarjeta As Decimal = 0
        Dim declaraciom_total_trasnferencia As Decimal = 0
        Dim declaraciom_total_cheque As Decimal = 0
        Dim declaraciom_total_nota As Decimal = 0

        '=====================OBTEMOS LOS DETALLES DEL CORTE=====================
        rs.Open("SELECT fecha,id_empleado_caja,nombre_empleado FROM cortes WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            nombre_empleado = rs.Fields("nombre_empleado").Value
            id_empleado = rs.Fields("id_empleado_caja").Value
        End If
        rs.Close()

        rs.Open("SELECT MIN(id_venta) As folio_inicio,MAX(id_venta) As folio_termino FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("folio_inicio").Value) Then
                folio_inicial = rs.Fields("folio_inicio").Value
                folio_final = rs.Fields("folio_termino").Value
            End If
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(cantidad) IS NULL THEN 0 ELSE SUM(cantidad)  END  as total from retiros WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_retiros = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fondo_caja = rs.Fields("saldo_inicial").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  as total from depositos WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_depositos = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_compras.importe)) THEN 0 ELSE SUM(pagos_compras.importe) END AS total FROM pagos_compras WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            total_pago_proveedores = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
              "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
              "JOIN venta ON venta.id_venta=pagos_ventas.id_venta " &
              "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)

        'rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " & _
        '  "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " & _
        '   "JOIN venta ON venta.id_venta=pagos_ventas.id_venta " & _
        '    "WHERE DATE(pagos_ventas.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)

        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_cobros_efectivo = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        rs.Open("SELECT * FROM corte_declaracion WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            declaraciom_total_efectivo = rs.Fields("total_efectivo").Value
            declaraciom_total_tarjeta = rs.Fields("total_tarjeta").Value
            declaraciom_total_trasnferencia = rs.Fields("total_transferencia").Value
            declaraciom_total_cheque = rs.Fields("total_cheque").Value
            declaraciom_total_nota = rs.Fields("total_nota").Value
        End If

        rs.Close()
        '======================================================================
        Dim archivo_corte_x As String = System.IO.Directory.GetCurrentDirectory() & "\cortes\corte-" & id_corte & "-" & fecha.Day & "-" & fecha.Month & "-" & fecha.Year & ".txt"
        If Not Directory.Exists(System.IO.Directory.GetCurrentDirectory() & "\cortes\") Then
            System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() & "\cortes\")
        End If

        Dim objWriter As New System.IO.StreamWriter(archivo_corte_x, False)

        'objWriter.Close()
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                objWriter.WriteLine(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        objWriter.WriteLine(centrar_texto("CIERRE DE VENTAS", cfg_longitud_maxima_ticket, " "))
        objWriter.WriteLine("Caja # 1")
        objWriter.WriteLine("Usuario:" & nombre_empleado & "")
        objWriter.WriteLine("Del folio " & folio_inicial & " al " & folio_final & "")
        objWriter.WriteLine("Clientes Atendidos: " & folio_final - folio_inicial + 1 & "")
        objWriter.WriteLine("" & fecha.ToLongDateString)
        objWriter.WriteLine("Hora: " & fecha.ToLongTimeString)


        If conf_pv(17) = 1 Then ' IMPRESION DE PRODUCTOS DE PUBLICO EN GENERAL
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("PRODUCTOS VENDIDOS", cfg_longitud_maxima_ticket, " "))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(" CANT.    UNID.  P.UNITARIO  IMPORTE")

            Dim rw, ry As New ADODB.Recordset
            rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta_detalle vd " & _
               "JOIN venta v ON vd.id_venta=v.id_venta " & _
               "JOIN producto p ON p.id_producto=vd.id_producto " & _
               "WHERE v.id_corte='" & id_corte & " '", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " & _
                                       "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                               "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND  v.id_corte='" & id_corte & "'", conn)
                    If rw.RecordCount > 0 Then
                        While Not rw.EOF
                            ry.Open("SELECT SUM(vd.cantidad) AS cantidad_vendido FROM venta_detalle vd " & _
                           "JOIN venta v ON v.id_venta=vd.id_venta " & _
                   "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND v.id_corte='" & id_corte & "' ORDER BY vd.cantidad DESC", conn)
                            If ry.RecordCount > 0 Then
                                While Not ry.EOF
                                    objWriter.WriteLine(" " & rellenar_texto_derecha(ry.Fields("cantidad_vendido").Value, 8) & "   " & rellenar_texto_derecha(rs.Fields("unidad").Value, 5) & "  " & FormatCurrency(rw.Fields("precio").Value) & " " & FormatCurrency(ry.Fields("cantidad_vendido").Value * rw.Fields("precio").Value) & "")
                                    objWriter.WriteLine(" " & rs.Fields("descripcion").Value)
                                    objWriter.WriteLine("----------------------------------")
                                    ry.MoveNext()
                                End While
                            End If
                            ry.Close()
                            rw.MoveNext()
                        End While
                    End If
                    rw.Close()
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End If

        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND venta.id_corte='" & id_corte & "') AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA'AND venta.id_corte='" & id_corte & "'),venta_detalle.precio) AS puntero " & _
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
"WHERE venta.status='REGALIA' AND venta.id_corte='" & id_corte & "' GROUP BY puntero " & _
"ORDER BY cantidad_vendido DESC", conn)
        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("REGALÍAS", cfg_longitud_maxima_ticket, " "))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                objWriter.WriteLine("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()

        '----agregar_creditos
        Dim badera_titulo_cuentas_cobrar As Boolean = False
        rs.Open("SELECT venta.id_venta,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
                "FROM cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
                "WHERE venta.status='PENDIENTE' AND venta.id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("CUENTAS X COBRAR", cfg_longitud_maxima_ticket, " "))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            badera_titulo_cuentas_cobrar = True
            While Not rs.EOF
                objWriter.WriteLine("N.:" & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT venta.id_venta,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
        "FROM cliente " & _
        "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
        "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
        "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
        "WHERE venta.status='CERRADA' AND credito='1' AND venta.id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            If badera_titulo_cuentas_cobrar = False Then
                objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
                objWriter.WriteLine(centrar_texto("CUENTAS X COBRAR", cfg_longitud_maxima_ticket, "="))
                objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            End If
            While Not rs.EOF
                objWriter.WriteLine("N.:" & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()

        objWriter.WriteLine("")

        Dim abonos(4) As Decimal

        For x = 0 To 4
            abonos(x) = 0
        Next



        'Conectar()
        ' rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & id_empleado & "' AND pagos_ventas.es_abono='1' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='" & id_corte & "' GROUP BY forma_pago.nombre", conn)
        'If rs.RecordCount > 0 Then
        '    objWriter.WriteLine("══════════════════════════════════")
        '    objWriter.WriteLine("         COBROS CREDITOS     ")
        '    objWriter.WriteLine("══════════════════════════════════")
        '    While Not rs.EOF
        '        Dim i As Integer = rs.Fields("id_forma_pago").Value
        '       abonos(i) += rs.Fields("total").Value
        '       rs.MoveNext()
        '   End While
        '   End If
        ' rs.Close()
        'conn.close()
        'conn = Nothing
        '  For x = 0 To 4
        '     If abonos(x) <> 0 Then
        '         objWriter.WriteLine("" & nombre_forma_pago(x) & "   " & FormatCurrency(abonos(x)) & "")
        '     End If
        '  Next
        'b.AnadirLineaSubcabeza("-----------------------------------")

        'limpiar_abonos()
        'Conectar()
        '   Dim rx As New ADODB.Recordset


        rs.Open("SELECT pagos_ventas.importe,pagos_ventas.id_venta,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " &
                 "FROM cliente " &
                 "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " &
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                "JOIN venta ON venta.id_cliente=cliente.id_cliente " &
                "JOIN pagos_ventas ON pagos_ventas.id_venta=venta.id_venta " &
                "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
                "WHERE pagos_ventas.id_empleado_caja='" & id_empleado & "' AND pagos_ventas.es_abono='1' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='" & id_corte & "'", conn)

        'rs.Open("SELECT pagos_ventas.importe,pagos_ventas.id_venta,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
        '         "FROM cliente " & _
        '         "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
        '        "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
        '       "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
        '       "JOIN pagos_ventas ON pagos_ventas.id_venta=venta.id_venta " & _
        '      "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " & _
        '       "WHERE DATE(pagos_ventas.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & id_empleado & "' AND pagos_ventas.es_abono='1' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='" & id_corte & "'", conn)


        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("COBROS CREDITOS", cfg_longitud_maxima_ticket, " "))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                objWriter.WriteLine("N.:" & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("importe").Value) & "")
                'objWriter.WriteLine("" & rellenar_texto_izquierda(FormatCurrency(rs.Fields("importe").Value), 9) & " N.Venta" & rellenar_texto_izquierda(rs.Fields("id_venta").Value, 6) & " " & rs.Fields("nombre").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
            'conn.close()
            'conn = Nothing
        'limpiar_abonos()
        'Conectar()


        Dim rx As New ADODB.Recordset

        rs.Open("SELECT pagos_compras.importe,factura_compra.id_proveedor " & _
        " FROM pagos_compras " & _
        "JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  " & _
        "WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'")
        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("CUENTAS X PAGAR", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))

            While Not rs.EOF
                Dim nombre_proveedor As String = ""
                rx.Open("SELECT  CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
                "FROM proveedor " & _
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                "WHERE proveedor.id_proveedor='" & rs.Fields("id_proveedor").Value & "'", conn)
                If rx.RecordCount > 0 Then
                    nombre_proveedor = rx.Fields("nombre").Value
                    End If
                rx.Close()
                objWriter.WriteLine("" & rellenar_texto_izquierda(FormatCurrency(rs.Fields("importe").Value), 9) & "   " & nombre_proveedor)
                rs.MoveNext()
                End While
            End If
        rs.Close()

        objWriter.WriteLine("")
            'b.AnadirLineaSubcabeza("-----------------------------------")

            'limpiar_abonos()
        Dim devoluciones_encontrado As Boolean = False
            'Conectar()
        rs.Open("SELECT devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones.bandera_corte_caja='" & id_corte & "' AND devoluciones.id_empleado='" & id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) AND devoluciones_detalle.id_producto=id) AS cantidad, CONCAT(devoluciones_detalle.unidad,' ',devoluciones_detalle.descripcion) AS producto " & _
                " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion " & _
                "WHERE devoluciones.bandera_corte_caja='" & id_corte & "' GROUP BY id_producto", conn)
        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("DEVOLUCIONES (EFECTIVO)", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            devoluciones_encontrado = True
            While Not rs.EOF
                objWriter.WriteLine("" & rs.Fields("cantidad").Value & " " & rs.Fields("producto").Value & " " & FormatCurrency(rs.Fields("precio_unitario").Value) & "")
                rs.MoveNext()
                End While
            End If
        rs.Close()
            'b.AnadirLineaSubcabeza("")
        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_impuestos) IS NULL THEN 0 ELSE SUM(total_impuestos)  END  AS total_impuestos,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
                'b.AnadirLineaSubcabeza("    SUBTOTAL      " & FormatCurrency(rs.Fields("subtotal").Value) & "")
                'b.AnadirLineaSubcabeza("    TOTAL-IVA     " & FormatCurrency(rs.Fields("total_iva").Value) & "")
                'b.AnadirLineaSubcabeza("    OTROS-IMP.    " & FormatCurrency(rs.Fields("total_otros").Value) & "")
                'b.AnadirLineaSubcabeza("                     ---------")
            If devoluciones_encontrado = True Then
                objWriter.WriteLine(" TOTAL-DEVOL. " & FormatCurrency(rs.Fields("total").Value) & "")
                total_devoluciones = rs.Fields("total").Value
                End If

            End If
        rs.Close()
            'conn.close()
            'conn = Nothing
        rs.Open("SELECT importe,descripcion FROM depositos WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("DEPOSITOS", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                objWriter.WriteLine(rellenar_texto_izquierda(FormatCurrency(rs.Fields("importe").Value), 9) & " " & rs.Fields("descripcion").Value)
                rs.MoveNext()
                End While
            End If
        rs.Close()

        rs.Open("SELECT cantidad,descripcion FROM retiros WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("RETIROS", cfg_longitud_maxima_ticket, "="))
            objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            While Not rs.EOF
                objWriter.WriteLine(rellenar_texto_izquierda(FormatCurrency(rs.Fields("cantidad").Value), 9) & " " & rs.Fields("descripcion").Value)
                rs.MoveNext()
                End While
            End If
        rs.Close()

        'b.AnadirLineaSubcabeza("")
        'b.AnadirLineaSubcabeza("-----------------------------------")
        objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
        objWriter.WriteLine(centrar_texto("VENTAS X CATEGORIA", cfg_longitud_maxima_ticket, " "))
        objWriter.WriteLine(centrar_texto("", cfg_longitud_maxima_ticket, "="))
        objWriter.WriteLine("*impuestos incluidos")
            'Conectar()
        rs.Open("SELECT categoria.nombre,SUM(venta_detalle.importe) AS total,SUM(venta_detalle.total_impuestos) AS impuesto FROM venta_detalle " & _
                "JOIN producto on producto.id_producto=venta_detalle.id_producto " & _
                "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                "JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
                "WHERE venta.id_corte='" & id_corte & "' GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                objWriter.WriteLine(UCase(rs.Fields("nombre").Value) & " " & FormatCurrency(rs.Fields("total").Value) & " " & FormatCurrency(rs.Fields("impuesto").Value) & "")
                rs.MoveNext()
                End While
            End If
        rs.Close()
            'conn.close()
            'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            'b.AnadirElemento("", "------------", "---------", "---------")

            'Conectar()

        rs.Open("SELECT (CASE WHEN ISNULL(sum(total)) THEN 0 ELSE sum(total) END)as total FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas = total_ventas + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
                End While
            End If
        rs.Close()
        Dim total_ventas_cobradas As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_ventas.importe)) THEN 0 ELSE SUM(pagos_ventas.importe) END AS total FROM pagos_ventas " & _
                "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas_cobradas = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
                End While
            End If
        rs.Close()

        objWriter.WriteLine("")
        objWriter.WriteLine("    ------------")
        objWriter.WriteLine("TOTAL-VENTAS:          " & FormatCurrency(total_ventas) & "")
        objWriter.WriteLine("TOTAL-COBROS:          " & FormatCurrency(total_ventas_cobradas) & "")
        objWriter.WriteLine("    ------------")
        objWriter.WriteLine("")
        objWriter.WriteLine("COBROS EFECTIVO        " & FormatCurrency(total_cobros_efectivo) & "")
            'Agregamos la suma de impuestos
        rs.Open("SELECT (CASE WHEN ISNULL(sum(total_impuestos)) THEN 0 ELSE sum(total_impuestos) END)as total_impuestos FROM venta WHERE  status='CERRADA' AND id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            objWriter.WriteLine("TOTAL-IMPUESTOS:         " & rs.Fields("total_impuestos").Value & "")

            End If
        rs.Close()
            'conn.close()
            '-----------------------------
        total_caja = fondo_caja + total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones
        total_caja_sinfondo = total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones

        objWriter.WriteLine("FONDO-CAJA:             " & FormatCurrency(fondo_caja))
        objWriter.WriteLine("+TOTAL-DEPOSITOS:       " & FormatCurrency(total_depositos))
        objWriter.WriteLine("-TOTAL-RETIROS:         " & FormatCurrency(total_retiros))
        objWriter.WriteLine("-DEVOLUCIONES:          " & FormatCurrency(total_devoluciones))

        objWriter.WriteLine("-PAGO_PROVEDOR:         " & FormatCurrency(total_pago_proveedores))
        objWriter.WriteLine("T.-CAJA(SIN_FONDO):  " & "" & FormatCurrency(total_caja_sinfondo))
        objWriter.WriteLine("", "")

        objWriter.WriteLine("TOTAL-CAJA: " & FormatCurrency(total_caja))
        objWriter.WriteLine("")


        objWriter.WriteLine("======FORMAS-DE-PAGO =======", "")
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
                 "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
                 "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                objWriter.WriteLine(UCase(rs.Fields("nombre").Value) & " " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
                End While
            End If
        rs.Close()
        objWriter.WriteLine("")

        rs.Open("SELECT * FROM corte_detalle WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
                '===========================================================      

            objWriter.WriteLine("======DECLARACIONES-CAJERO=======", "")
            objWriter.WriteLine("Efectivo:      " & FormatCurrency(declaraciom_total_efectivo))
            objWriter.WriteLine("->Billete-20   " & rs.Fields("billete_20").Value)
            objWriter.WriteLine("->Billete-50   " & rs.Fields("billete_50").Value)
            objWriter.WriteLine("->Billete-100  " & rs.Fields("billete_100").Value)
            objWriter.WriteLine("->Billete-200  " & rs.Fields("billete_200").Value)
            objWriter.WriteLine("->Billete-500  " & rs.Fields("billete_500").Value)
            objWriter.WriteLine("->Billete-1000 " & rs.Fields("billete_1000").Value)
            objWriter.WriteLine("->Moneda--50c  " & rs.Fields("moneda_50c").Value)
            objWriter.WriteLine("->Moneda--1    " & rs.Fields("moneda_1").Value)
            objWriter.WriteLine("->Moneda--2    " & rs.Fields("moneda_2").Value)
            objWriter.WriteLine("->Moneda--5    " & rs.Fields("moneda_5").Value)
            objWriter.WriteLine("->Moneda--10   " & rs.Fields("moneda_10").Value)
            objWriter.WriteLine("Tarjeta        " & FormatCurrency(declaraciom_total_tarjeta))
            objWriter.WriteLine("->Visa         " & rs.Fields("tarjeta_visa").Value & "")
            objWriter.WriteLine("->Master-Card  " & rs.Fields("tarjeta_master_card").Value)
            objWriter.WriteLine("->American-E.  " & rs.Fields("tarjeta_american_express").Value)
            objWriter.WriteLine("Transferencia  " & FormatCurrency(declaraciom_total_trasnferencia))
            objWriter.WriteLine("Cheque         " & FormatCurrency(declaraciom_total_cheque))
            objWriter.WriteLine("Nota-Credito   " & FormatCurrency(declaraciom_total_nota))
            objWriter.WriteLine("")
            objWriter.WriteLine("Diferencia(+)sobrante(-)faltante", "")
            objWriter.WriteLine("DIFERENCIA:    " & FormatCurrency((declaraciom_total_efectivo - total_caja)))
                '===========================================================

            End If
        rs.Close()


        For x = 0 To 3
            objWriter.WriteLine("")
        Next
        objWriter.WriteLine("  _______________  ______________")
        objWriter.WriteLine("    CAJERA GRAL.   CAJERA LINEA.")
            '//El metodo AddFooterLine funciona igual que la cabecera
            ' b.AnadeLineaAlPie("PIE DE PAGINA...............")
        objWriter.Close()

        Process.Start(archivo_corte_x)
    End Sub
    Public Sub imprimir_corte_x_excel(ByVal id_corte As Integer, nombre_archivo As String)

        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0

        Dim folio_inicial As Integer = 0
        Dim fecha As DateTime
        Dim folio_final As Integer = 0
        Dim total_ventas As Decimal = 0
        Dim total_cobros As Decimal = 0
        Dim total_cobros_efectivo As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim fondo_caja As Decimal = 0
        Dim total_depositos As Decimal = 0
        Dim total_retiros As Decimal = 0
        Dim total_devoluciones As Decimal = 0
        Dim total_caja_sinfondo As Decimal = 0
        Dim total_pago_proveedores As Decimal = 0
        Dim total_caja As Decimal = 0
        Dim nombre_empleado As String = ""
        Dim id_empleado As Integer = 0
        Dim declaraciom_total_efectivo As Decimal = 0
        Dim declaraciom_total_tarjeta As Decimal = 0
        Dim declaraciom_total_trasnferencia As Decimal = 0
        Dim declaraciom_total_cheque As Decimal = 0
        Dim declaraciom_total_nota As Decimal = 0

        '=====================OBTEMOS LOS DETALLES DEL CORTE=====================
        rs.Open("SELECT fecha,id_empleado_caja,nombre_empleado FROM cortes WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            nombre_empleado = rs.Fields("nombre_empleado").Value
            id_empleado = rs.Fields("id_empleado_caja").Value
        End If
        rs.Close()

        rs.Open("SELECT MIN(id_venta) As folio_inicio,MAX(id_venta) As folio_termino FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("folio_inicio").Value) Then
                folio_inicial = rs.Fields("folio_inicio").Value
                folio_final = rs.Fields("folio_termino").Value
            End If
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(cantidad) IS NULL THEN 0 ELSE SUM(cantidad)  END  as total from retiros WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_retiros = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fondo_caja = rs.Fields("saldo_inicial").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  as total from depositos WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_depositos = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_compras.importe)) THEN 0 ELSE SUM(pagos_compras.importe) END AS total FROM pagos_compras WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            total_pago_proveedores = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
              "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
              "JOIN venta ON venta.id_venta=pagos_ventas.id_venta " &
              "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_cobros_efectivo = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT * FROM corte_declaracion WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            declaraciom_total_efectivo = rs.Fields("total_efectivo").Value
            declaraciom_total_tarjeta = rs.Fields("total_tarjeta").Value
            declaraciom_total_trasnferencia = rs.Fields("total_transferencia").Value
            declaraciom_total_cheque = rs.Fields("total_cheque").Value
            declaraciom_total_nota = rs.Fields("total_nota").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_impuestos) IS NULL THEN 0 ELSE SUM(total_impuestos)  END  AS total_impuestos,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_devoluciones = rs.Fields("total").Value
        End If
        rs.Close()
        '======================================================================



        wBook = excel_app.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        wSheet.PageSetup.TopMargin = 1
        wSheet.PageSetup.BottomMargin = 1
        wSheet.PageSetup.LeftMargin = 1
        wSheet.PageSetup.RightMargin = 1

        wSheet.Name = "corte_x"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
    CType(False, Microsoft.Office.Core.MsoTriState),
    CType(True, Microsoft.Office.Core.MsoTriState), 30, 2, 150, 75)

        excel_app.Cells(2, 7) = lineas_reporte(0)
        Rango = wSheet.Range(excel_app.Cells(2, 7), excel_app.Cells(2, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(3, 7) = lineas_reporte(1)
        Rango = wSheet.Range(excel_app.Cells(3, 7), excel_app.Cells(3, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = False
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(4, 7) = lineas_reporte(2)
        Rango = wSheet.Range(excel_app.Cells(4, 7), excel_app.Cells(4, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = False
        Rango.Font.Size = 10
        Rango.Merge()
        excel_app.Cells(5, 7) = lineas_reporte(3)
        Rango = wSheet.Range(excel_app.Cells(5, 7), excel_app.Cells(5, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = False
        Rango.Font.Size = 10
        Rango.Merge()
        '  excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        '  Rango = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = False
        ' Rango.Font.Size = 10
        'Rango.Merge()
        excel_app.Cells(8, 7) = UCase("REPORTE ELABORADO: " & Date.Today.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        'excel_app.Cells(8, 10) = "Colaborador: " & cb_usuario.Text
        'Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()
        Dim titulo_reporte As String = ""
        titulo_reporte = "Cierre de Ventas X" & fecha.ToLongDateString & " " & fecha.ToLongTimeString

        excel_app.Cells(10, 3) = titulo_reporte
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "COLABORADOR(A) CAJA: "
        Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 4))
        celda_pbk(excel_app.Cells(12, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(12, 5) = nombre_empleado
        Rango = wSheet.Range(excel_app.Cells(12, 5), excel_app.Cells(12, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()


        excel_app.Cells(13, 2) = "FOLIO INICIAL: "
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 4))
        celda_pbk(excel_app.Cells(13, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(13, 5) = folio_inicial
        Rango = wSheet.Range(excel_app.Cells(13, 5), excel_app.Cells(13, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(14, 2) = "FOLIO FINAL: "
        Rango = wSheet.Range(excel_app.Cells(14, 2), excel_app.Cells(14, 4))
        celda_pbk(excel_app.Cells(14, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(14, 5) = folio_final
        Rango = wSheet.Range(excel_app.Cells(14, 5), excel_app.Cells(14, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(15, 2) = "FECHA: "
        Rango = wSheet.Range(excel_app.Cells(15, 2), excel_app.Cells(15, 4))
        celda_pbk(excel_app.Cells(15, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(15, 5) = fecha.ToLongDateString
        Rango = wSheet.Range(excel_app.Cells(15, 5), excel_app.Cells(15, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(16, 2) = "HORA: "
        Rango = wSheet.Range(excel_app.Cells(16, 2), excel_app.Cells(16, 4))
        celda_pbk(excel_app.Cells(16, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(16, 5) = fecha.ToLongTimeString
        Rango = wSheet.Range(excel_app.Cells(16, 5), excel_app.Cells(16, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = 18

        'row = 14

        rs.Open("SELECT pv.id_venta,pv.importe,fp.nombre AS forma_pago,pv.fecha_cobro,pv.afecta_caja,CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS empleado_caja,v.id_cliente,v.status AS estatus_venta FROM pagos_ventas pv " &
                    "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
                    "JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                    "JOIN persona p ON p.id_persona=e.id_persona " &
                    "JOIN venta v ON v.id_venta=pv.id_venta " &
                    "WHERE v.status<>'CANCELADA' AND pv.status='ACTIVO' AND pv.id_corte='" & id_corte & "'")
        If rs.RecordCount > 0 Then

            excel_app.Cells(row, 2) = "COBROS REALIZADOS"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 29))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "FOLIO NOTA VENTA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "TIPO DE MOVIMIENTO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 8) = "IMPORTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 10) = "FORMA DE PAGO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 12) = "FECHA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 14) = "CAJERO(A)"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 18) = "VENDEDOR"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 22) = "ESTADO DE ENTREGA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 25) = "CLIENTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 28) = "AFECTA CAJA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 28), excel_app.Cells(row, 29))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1
            While Not rs.EOF

                Dim rw As New ADODB.Recordset
                Dim vendedor As String = ""
                Dim nombre_cliente As String = ""
                Dim tipo_movimiento As String = ""
                Dim estatus_entrega As String = ""

                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    nombre_cliente = rw.Fields("cliente").Value
                End If
                rw.Close()
                rw.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor FROM empleado e " &
                            "JOIN persona p ON p.id_persona=e.id_persona " &
                            "JOIN venta v ON v.id_empleado=e.id_empleado WHERE v.id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    vendedor = rw.Fields("vendedor").Value
                End If
                rw.Close()

                Dim id_apartado As Integer = 0
                Dim id_pedido As Integer = 0

                rw.Open("SELECT id_apartado,total,entregado FROM apartado WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    id_apartado = rw.Fields("id_apartado").Value
                    If rs.Fields("importe").Value < rw.Fields("total").Value Then
                        tipo_movimiento = "ABONO AL APARTADO FOLIO " & rw.Fields("id_apartado").Value
                    ElseIf rs.Fields("importe").Value = rw.Fields("total").Value Then
                        tipo_movimiento = "APARTADO FOLIO " & rw.Fields("id_apartado").Value
                    End If
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                End If
                rw.Close()

                rw.Open("SELECT id_pedido,total,entregado FROM pedido_clientes WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    id_pedido = rw.Fields("id_pedido").Value
                    If rs.Fields("importe").Value < rw.Fields("total").Value Then
                        tipo_movimiento = "ABONO AL PEDIDO FOLIO " & rw.Fields("id_pedido").Value
                    ElseIf rs.Fields("importe").Value = rw.Fields("total").Value Then
                        tipo_movimiento = "PEDIDO FOLIO " & rw.Fields("id_apartado").Value
                    End If
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                End If
                rw.Close()

                If id_pedido = 0 And id_apartado = 0 Then

                    rw.Open("SELECT total FROM venta WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                    If rw.RecordCount > 0 Then
                        If rs.Fields("importe").Value < rw.Fields("total").Value Then
                            tipo_movimiento = "ABONO A LA VENTA FOLIO " & rs.Fields("id_venta").Value
                        ElseIf rs.Fields("importe").Value = rw.Fields("total").Value Then
                            tipo_movimiento = "VENTA FOLIO " & rs.Fields("id_venta").Value
                        End If
                        estatus_entrega = "ENTREGADO"
                    End If
                    rw.Close()
                End If

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = tipo_movimiento
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(rs.Fields("importe").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("forma_pago").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("fecha_cobro").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = rs.Fields("empleado_caja").Value
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 18) = vendedor
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 22) = estatus_entrega
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 25) = nombre_cliente
                Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                Dim afecta_caja As String = ""
                If rs.Fields("afecta_caja").Value = 1 Then
                    afecta_caja = "SI"
                Else
                    afecta_caja = "NO"
                End If

                excel_app.Cells(row, 28) = afecta_caja
                Rango = wSheet.Range(excel_app.Cells(row, 28), excel_app.Cells(row, 29))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()
        row = row + 1

        Dim bandera_titulo_cuentas_cobrar As Boolean = False

        rs.Open("SELECT v.id_venta,v.total,CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor,v.id_cliente,v.status FROM venta v " &
                   "JOIN empleado e ON e.id_empleado=v.id_empleado " &
                   "JOIN persona p ON p.id_persona=e.id_persona " &
                   "WHERE v.status='PENDIENTE' AND v.id_corte='" & id_corte & "'")
        If rs.RecordCount > 0 Then
            bandera_titulo_cuentas_cobrar = True
            excel_app.Cells(row, 2) = "CUENTAS POR COBRAR"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 28))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "FOLIO NOTA VENTA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "TIPO DE MOVIMIENTO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 8) = "TOTAL"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 10) = "TOTAL PAGADO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 12) = "SALDO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 14) = "CAJERO(A)"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 18) = "VENDEDOR"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 22) = "ESTADO DE ENTREGA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 25) = "CLIENTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1
            While Not rs.EOF

                Dim rw As New ADODB.Recordset
                Dim empleado_caja As String = ""
                Dim nombre_cliente As String = ""
                Dim tipo_movimiento As String = ""
                Dim estatus_entrega As String = ""
                Dim total_venta As Decimal = rs.Fields("total").Value
                Dim total_cobrado_venta As Decimal = 0

                rw.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_ventas WHERE id_venta='" & rs.Fields("id_venta").Value & "' AND status='ACTIVO' ", conn)
                If rw.RecordCount > 0 Then
                    total_cobrado_venta = CDbl(rw.Fields("total").Value)
                End If
                rw.Close()


                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    nombre_cliente = rw.Fields("cliente").Value
                End If
                rw.Close()

                rw.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor FROM empleado e " &
                        "JOIN persona p ON p.id_persona=e.id_persona " &
                        "JOIN venta v ON v.id_empleado_caja=e.id_empleado WHERE v.id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    empleado_caja = rw.Fields("vendedor").Value
                End If
                rw.Close()

                Dim id_apartado As Integer = 0
                Dim id_pedido As Integer = 0

                rw.Open("SELECT id_apartado,total,entregado FROM apartado WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    id_apartado = rw.Fields("id_apartado").Value
                    tipo_movimiento = "APARTADO FOLIO " & rw.Fields("id_apartado").Value
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                End If
                rw.Close()

                rw.Open("SELECT id_pedido,total,entregado FROM pedido_clientes WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    id_pedido = rw.Fields("id_pedido").Value
                    tipo_movimiento = "PEDIDO FOLIO " & rw.Fields("id_pedido").Value
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                End If
                rw.Close()

                If id_pedido = 0 And id_apartado = 0 Then

                    rw.Open("SELECT total FROM venta WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                    If rw.RecordCount > 0 Then
                        tipo_movimiento = "VENTA FOLIO " & rs.Fields("id_venta").Value
                        estatus_entrega = "ENTREGADO"
                    End If
                    rw.Close()
                End If

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = tipo_movimiento
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(total_venta)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = FormatCurrency(total_cobrado_venta)
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(total_venta - total_cobrado_venta)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = empleado_caja
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 18) = rs.Fields("vendedor").Value
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 22) = estatus_entrega
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 25) = nombre_cliente
                Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()


        rs.Open("SELECT v.id_venta,v.total,CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor,v.id_cliente,v.status FROM venta v " &
         "JOIN empleado e ON e.id_empleado=v.id_empleado " &
         "JOIN persona p ON p.id_persona=e.id_persona " &
         "WHERE v.status='CERRADA' AND credito='1' AND v.id_corte='" & id_corte & "'")
        If rs.RecordCount > 0 Then
            If bandera_titulo_cuentas_cobrar = False Then
                excel_app.Cells(row, 2) = "CUENTAS POR COBRAR"
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 28))
                celda_pbk(excel_app.Cells(row, 2))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                Rango.Font.Bold = True
                Rango.Font.Size = 10
                Rango.Merge()

                row = row + 1

                excel_app.Cells(row, 2) = "FOLIO NOTA VENTA"
                'celda_pbk(excel_app.Cells(13, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "TIPO DE MOVIMIENTO"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 8) = "TOTAL"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "TOTAL PAGADO"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 12) = "SALDO"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 14) = "CAJERO(A)"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 18) = "VENDEDOR"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 22) = "ESTADO DE ENTREGA"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 25) = "CLIENTE"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row = row + 1
            End If

            While Not rs.EOF

                Dim rw As New ADODB.Recordset
                Dim empleado_caja As String = ""
                Dim nombre_cliente As String = ""
                Dim tipo_movimiento As String = ""
                Dim estatus_entrega As String = ""
                Dim total_venta As Decimal = rs.Fields("total").Value
                Dim total_cobrado_venta As Decimal = 0

                rw.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_ventas WHERE id_venta='" & rs.Fields("id_venta").Value & "' AND status='ACTIVO' ", conn)
                If rw.RecordCount > 0 Then
                    total_cobrado_venta = CDbl(rw.Fields("total").Value)
                End If
                rw.Close()


                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    nombre_cliente = rw.Fields("cliente").Value
                End If
                rw.Close()

                rw.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor FROM empleado e " &
                        "JOIN persona p ON p.id_persona=e.id_persona " &
                        "JOIN venta v ON v.id_empleado_caja=e.id_empleado WHERE v.id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    empleado_caja = rw.Fields("vendedor").Value
                End If
                rw.Close()

                Dim id_apartado As Integer = 0
                Dim id_pedido As Integer = 0

                rw.Open("SELECT id_apartado,total,entregado FROM apartado WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    id_apartado = rw.Fields("id_apartado").Value
                    tipo_movimiento = "APARTADO FOLIO " & rw.Fields("id_apartado").Value
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                End If
                rw.Close()

                rw.Open("SELECT id_pedido,total,entregado FROM pedido_clientes WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    id_pedido = rw.Fields("id_pedido").Value
                    tipo_movimiento = "PEDIDO FOLIO " & rw.Fields("id_pedido").Value
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                End If
                rw.Close()

                If id_pedido = 0 And id_apartado = 0 Then

                    rw.Open("SELECT total FROM venta WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                    If rw.RecordCount > 0 Then
                        tipo_movimiento = "VENTA FOLIO " & rs.Fields("id_venta").Value
                        estatus_entrega = "ENTREGADO"
                    End If
                    rw.Close()
                End If

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = tipo_movimiento
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(total_venta)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = FormatCurrency(total_cobrado_venta)
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(total_venta - total_cobrado_venta)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = empleado_caja
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 18) = rs.Fields("vendedor").Value
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 22) = estatus_entrega
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 25) = nombre_cliente
                Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()
        row = row + 1

        rs.Open("SELECT v.id_venta,v.id_cliente,vd.cantidad, vd.unidad,vd.precio,vd.descripcion,CONCAT(pc.nombre,' ',pc.ap_paterno,' ',pc.ap_materno) AS empleado_caja,CONCAT(pv.nombre,' ',pv.ap_paterno,' ',pv.ap_materno) AS empleado_validacion FROM venta_detalle vd " &
                    "JOIN venta v ON  v.id_venta=vd.id_venta " &
                    "JOIN empleado ec ON ec.id_empleado=v.id_empleado_caja " &
                    "JOIN persona pc ON pc.id_persona=ec.id_persona " &
                    "JOIN empleado ev ON ev.id_empleado=v.id_empleado_validacion " &
                    "JOIN persona pv ON pv.id_persona=ev.id_persona " &
                    "WHERE v.status='REGALIA' AND v.id_corte='" & id_corte & "'")
        If rs.RecordCount > 0 Then
            excel_app.Cells(row, 2) = "REGALIAS"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 24))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "FOLIO NOTA VENTA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "DESCRIPCION"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 8) = "CANTIDAD"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 10) = "UNIDAD"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 12) = "PRECIO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 14) = "COLABORADOR EN CAJA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 18) = "PERSONA QUE AUTORIZÓ"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 22) = "CLIENTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 25))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1
            While Not rs.EOF

                Dim rw As New ADODB.Recordset
                Dim cliente_regalia As String = ""

                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    cliente_regalia = rw.Fields("cliente").Value
                End If
                rw.Close()

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("precio").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = rs.Fields("empleado_caja").Value
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 18) = rs.Fields("empleado_validacion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 22) = cliente_regalia
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 25))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()

        row = row + 1



        rs.Open("SELECT v.id_venta,v.id_cliente,vd.cantidad, vd.unidad,vd.precio,vd.descripcion,CONCAT(pc.nombre,' ',pc.ap_paterno,' ',pc.ap_materno) AS empleado_caja,CONCAT(pv.nombre,' ',pv.ap_paterno,' ',pv.ap_materno) AS empleado_validacion FROM venta_detalle vd " &
                    "JOIN venta v ON  v.id_venta=vd.id_venta " &
                    "JOIN empleado ec ON ec.id_empleado=v.id_empleado_caja " &
                    "JOIN persona pc ON pc.id_persona=ec.id_persona " &
                    "JOIN empleado ev ON ev.id_empleado=v.id_empleado_validacion " &
                    "JOIN persona pv ON pv.id_persona=ev.id_persona " &
                    "WHERE v.status='CANCELADA' AND v.id_corte='" & id_corte & "'")
        If rs.RecordCount > 0 Then
            excel_app.Cells(row, 2) = "CANCELACIONES"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 24))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "FOLIO NOTA VENTA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "DESCRIPCION"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 8) = "CANTIDAD"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 10) = "UNIDAD"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 12) = "PRECIO"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 14) = "COLABORADOR EN CAJA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 18) = "PERSONA QUE AUTORIZÓ"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 22) = "CLIENTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 25))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1
            While Not rs.EOF

                Dim rw As New ADODB.Recordset
                Dim cliente_cancelacion As String = ""

                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    cliente_cancelacion = rw.Fields("cliente").Value
                End If
                rw.Close()

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("precio").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = rs.Fields("empleado_caja").Value
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 18) = rs.Fields("empleado_validacion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 22) = cliente_cancelacion
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 25))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()


        rs.Open("SELECT d.id_venta,dd.descripcion,dd.unidad,dd.cantidad,dd.importe,d.tipo_devolucion,v.id_cliente FROM devoluciones d " &
"JOIN devoluciones_detalle dd ON d.id_devolucion=dd.id_devolucion " &
"JOIN venta v ON v.id_venta=d.id_venta " &
"WHERE d.bandera_corte_caja='" & id_corte & "' AND (d.tipo_devolucion=3 OR d.tipo_devolucion=4)")

        If rs.RecordCount > 0 Then



            excel_app.Cells(row, 2) = "DEVOLUCIONES"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 24))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "FOLIO NOTA VENTA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "DESCRIPCION"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 8) = "CANTIDAD"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 10) = "UNIDAD"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 12) = "IMPORTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 14) = "CLIENTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 18))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 19) = "TIPO DEVOLUCION"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 19), excel_app.Cells(row, 26))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1
            While Not rs.EOF

                Dim cliente_devolucion As String = ""
                Dim rw As New ADODB.Recordset

                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    cliente_devolucion = rw.Fields("cliente").Value
                End If
                rw.Close()

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("importe").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = cliente_devolucion
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 18))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                Dim tipo_devolucion As String = ""

                If rs.Fields("tipo_devolucion").Value = 3 Then
                    tipo_devolucion = "Devolución de efectivo con ingreso de producto al almacen"
                End If

                If rs.Fields("tipo_devolucion").Value = 3 Then
                    tipo_devolucion = "Devolución de efectivo sin ingreso de producto al almacen"
                End If

                excel_app.Cells(row, 19) = tipo_devolucion
                Rango = wSheet.Range(excel_app.Cells(row, 19), excel_app.Cells(row, 26))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()


        rs.Open("SELECT fecha,importe,descripcion FROM depositos WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then

            excel_app.Cells(row, 2) = "DEPOSITOS"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 24))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "HORA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "IMPORTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 6) = "DESCRIPCION"
            'celda_pbk(excel_app.Cells(13, 3))5), excel_app.Cells(row, 9))
            Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1

            While Not rs.EOF
                Dim fecha_deposito As DateTime = rs.Fields("fecha").Value

                excel_app.Cells(row, 2) = fecha_deposito.ToLongTimeString
                'celda_pbk(excel_app.Cells(13, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = FormatCurrency(rs.Fields("importe").Value)
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = UCase(rs.Fields("descripcion").Value)
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                row = row + 1

                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT fecha,cantidad,descripcion FROM retiros WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then

            excel_app.Cells(row, 2) = "RETIROS"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 24))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "HORA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "IMPORTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 6) = "DESCRIPCION"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 11))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1

            While Not rs.EOF
                Dim fecha_retiro As DateTime = rs.Fields("fecha").Value

                excel_app.Cells(row, 2) = fecha_retiro.ToLongTimeString
                'celda_pbk(excel_app.Cells(13, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = FormatCurrency(rs.Fields("cantidad").Value)
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = UCase(rs.Fields("descripcion").Value)
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                row = row + 1

                rs.MoveNext()
            End While
        End If
        rs.Close()

        row = row + 1


        rs.Open("SELECT pagos_compras.fecha,pagos_compras.importe,factura_compra.id_proveedor,factura_compra.id_factura_compra,factura_compra.folio" &
        " FROM pagos_compras " &
        "JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  " &
        "WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'")
        If rs.RecordCount > 0 Then
            excel_app.Cells(row, 2) = "PAGO A PROVEEDORES"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 24))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 1

            excel_app.Cells(row, 2) = "HORA"
            'celda_pbk(excel_app.Cells(13, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 4) = "FOLIO RECEPCION"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 6) = "FOLIO NOTA/FACTURA"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 8) = "IMPORTE"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 10))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            excel_app.Cells(row, 11) = "PROVEEDOR"
            'celda_pbk(excel_app.Cells(13, 3))
            Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Merge()

            row = row + 1
            While Not rs.EOF

                Dim rw As New ADODB.Recordset
                Dim nombre_proveedor As String = ""
                Dim fecha_pago As DateTime = rs.Fields("fecha").Value

                rw.Open("SELECT  CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " &
                "FROM proveedor " &
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " &
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " &
                "WHERE proveedor.id_proveedor='" & rs.Fields("id_proveedor").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    nombre_proveedor = rw.Fields("nombre").Value
                End If
                rw.Close()

                excel_app.Cells(row, 2) = fecha_pago.ToLongTimeString
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("id_factura_compra").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 6) = rs.Fields("folio").Value
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(rs.Fields("importe").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 10))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 11) = nombre_proveedor
                Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 14))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()
        row = row + 2

        '=====TOTALES POR CATEGORIA
        excel_app.Cells(row, 2) = "TOTALES POR CATEGORIA"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 9))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "CATEGORIA"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 5) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 7) = "IMPUESTO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 7), excel_app.Cells(row, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        row += 1


        rs.Open("SELECT categoria.nombre,SUM(venta_detalle.importe) AS total,SUM(venta_detalle.total_impuestos) AS total_impuesto FROM venta_detalle " &
                   "JOIN producto on producto.id_producto=venta_detalle.id_producto " &
                   "JOIN categoria ON categoria.id_categoria=producto.id_categoria " &
                   "JOIN venta ON venta.id_venta=venta_detalle.id_venta " &
                   "WHERE venta.id_corte='" & id_corte & "' GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF

                excel_app.Cells(row, 2) = UCase(rs.Fields("nombre").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 5) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 7) = FormatCurrency(rs.Fields("total_impuesto").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 7), excel_app.Cells(row, 8))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()
                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While

        End If
        rs.Close()

        row += 2

        rs.Open("SELECT (CASE WHEN ISNULL(sum(total)) THEN 0 ELSE sum(total) END)as total FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas = total_ventas + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        Dim total_ventas_cobradas As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_ventas.importe)) THEN 0 ELSE SUM(pagos_ventas.importe) END AS total FROM pagos_ventas " &
                    "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas_cobradas = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        '=====FORMAS DE PAGO
        excel_app.Cells(row, 2) = "FORMAS DE PAGOS"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 9))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "FORMA DE PAGO"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 5) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()


        row += 1

        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
                                     "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
                                     "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)

        If rs.RecordCount > 0 Then
            While Not rs.EOF

                excel_app.Cells(row, 2) = UCase(rs.Fields("nombre").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 5) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                Rango.Merge()
                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While

        End If
        rs.Close()

        row += 2
        Dim fila_inicio_declaracion As Integer = row

        excel_app.Cells(row, 2) = "TOTAL VENTAS: "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_ventas)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "TOTAL COBROS: "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_ventas_cobradas)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "COBROS EFECTIVO: "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_cobros_efectivo)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2



        rs.Open("SELECT (CASE WHEN ISNULL(sum(total_impuestos)) THEN 0 ELSE sum(total_impuestos) END)as total_impuestos FROM venta WHERE  status='CERRADA' AND id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            excel_app.Cells(row, 2) = "TOTAL IMPUESTOS: "
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
            celda_pbk(excel_app.Cells(row, 2))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(row, 6) = FormatCurrency(rs.Fields("total_impuestos").Value)
            Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            row = row + 2

        End If
        rs.Close()
        'conn.close()
        '-----------------------------
        total_caja = fondo_caja + total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones
        total_caja_sinfondo = total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones

        excel_app.Cells(row, 2) = "FONDO CAJA:"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(fondo_caja)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "+ TOTAL DEPOSITOS: "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_depositos)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "-TOTAL RETIROS: "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_retiros)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "- TOTAL DEVOLUCIONES "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_devoluciones)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "-PAGO PROVEEDORES:"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_pago_proveedores)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "TOTAL CAJA (SIN FONDO):"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_caja_sinfondo)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        row = row + 2

        excel_app.Cells(row, 2) = "TOTAL CAJA: "
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(row, 6) = FormatCurrency(total_caja)
        Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()




        rs.Open("SELECT * FROM corte_detalle WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            '===========================================================      

            'objWriter.WriteLine("======DECLARACIONES-CAJERO=======", "")

            excel_app.Cells(fila_inicio_declaracion, 9) = "DECLARACIONES DEL CAJERO(A)"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 14))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "Efectivo:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(declaraciom_total_efectivo)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Billete-20:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("billete_20").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Billete-50:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("billete_50").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Billete-100:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("billete_100").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Billete-200:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("billete_200").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Billete-500:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("billete_500").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Billete-1000:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("billete_1000").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Moneda--50c:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("moneda_50c").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Moneda--1:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("moneda_1").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Moneda--2:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("moneda_2").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Moneda--5:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("moneda_5").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1


            excel_app.Cells(fila_inicio_declaracion, 9) = "->Moneda--10:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = rs.Fields("moneda_10").Value
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "Tarjeta:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(declaraciom_total_tarjeta)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1


            excel_app.Cells(fila_inicio_declaracion, 9) = "->Visa"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(rs.Fields("tarjeta_visa").Value)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->Master-Card"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(rs.Fields("tarjeta_master_card").Value)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "->American-E."
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(rs.Fields("tarjeta_american_express").Value)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "Transferencia:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(declaraciom_total_trasnferencia)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "Cheque:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(declaraciom_total_cheque)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "Nota de Credito:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency(declaraciom_total_nota)
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 2

            excel_app.Cells(fila_inicio_declaracion, 9) = "Diferencia: (+)sobrante  (-)faltante"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 14))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

            excel_app.Cells(fila_inicio_declaracion, 9) = "Diferencia:"
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 9), excel_app.Cells(fila_inicio_declaracion, 12))
            celda_pbk(excel_app.Cells(fila_inicio_declaracion, 9))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            excel_app.Cells(fila_inicio_declaracion, 13) = FormatCurrency((declaraciom_total_efectivo - total_caja))
            Rango = wSheet.Range(excel_app.Cells(fila_inicio_declaracion, 13), excel_app.Cells(fila_inicio_declaracion, 14))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()

            fila_inicio_declaracion = fila_inicio_declaracion + 1

        End If
        rs.Close()


        Dim archivo_corte_x As String = nombre_archivo
        'Dim archivo_corte_x As String = System.IO.Directory.GetCurrentDirectory() & "\cortes\corte-" & id_corte & "-" & fecha.Day & "-" & fecha.Month & "-" & fecha.Year & ".xls"
        ' If Not Directory.Exists(System.IO.Directory.GetCurrentDirectory() & "\cortes\") Then
        'System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() & "\cortes\")
        ' End If

        Dim strFileName As String = archivo_corte_x
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                System.IO.File.Delete(strFileName)
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & "Se encuentra abiero un archivo con el mismo nombre, cierre el archivo e intentelo nuevamente")
            End Try
        End If

        Try
            wBook.SaveAs(strFileName)
            excel_app.Workbooks.Open(strFileName)
            excel_app.Visible = True
            wBook.Close()

            releaseObject(wBook)
            releaseObject(wSheet)
            releaseObject(excel_app)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub celda_pbk(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.SteelBlue
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub
    Private Sub celda_total(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.DarkGreen
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub
    Private Sub celda_atencion(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.DarkRed
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub
End Module
