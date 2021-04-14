Module funciones_imprimir
    Dim abonos(4) As Decimal
    Public lineas_ticket_cabeza(25) As String
    Public lineas_ticket_pie(25) As String
    Public Sub limpiar_lineas_ticket()
        For x = 0 To 25
            lineas_ticket_cabeza(x) = Nothing
            lineas_ticket_pie(x) = Nothing
        Next
    End Sub
    Public Sub imprimir_ticket_venta(ByVal id_venta As Integer, ByVal cliente As String, ByVal cliente_alias As String, ByVal folio As Integer, ByVal subtotal As Decimal, ByVal total_iva As Decimal, ByVal total As Decimal, ByVal pago As String, ByVal cambio As String, ByVal empleado As String, ByVal tipo_pago As String, ByVal num_copia As Integer, ByVal total_copias As Integer, Optional ByVal pago_express As Boolean = False, Optional ByVal express_efectivo As Decimal = 0, Optional ByVal express_trajeta As Decimal = 0, Optional ByVal express_cupones As Decimal = 0)
        Dim id_cliente As Integer = 0
        Dim desc_global_porcent As Decimal = 0
        Dim fecha As DateTime
        'Conectar()
        rs.Open("SELECT fecha,id_cliente,desc_global_porcent FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            desc_global_porcent = rs.Fields("desc_global_porcent").Value
            fecha = rs.Fields("fecha").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Dim aplicar_redondeo As Boolean = obtener_aplicar_redondeo(id_cliente)
        Dim texto_copia As String = ""
        If total_copias > 0 Then
            If num_copia = 0 Then
                texto_copia = "----Cliente----"
            ElseIf num_copia = 1 Then
                texto_copia = "----Establecimiento----"
            Else
                texto_copia = "----Establecimiento " & num_copia & "----"
            End If
        End If

        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("FOLIO: " & folio, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(cliente_alias, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Le atendió: " & empleado & "")
        b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & fecha.ToShortTimeString())
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        Dim imprime_precios As Boolean = True
        rs.Open("SELECT pc.mostrar_precios FROM cliente_precio pc JOIN venta v ON v.id_cliente=pc.id_cliente WHERE v.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("mostrar_precios").Value = 0 Then
                imprime_precios = False
            End If
        End If
        rs.Close()
        If imprime_precios = True Then
            EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Else
            EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
        End If

        Dim bandera_descuento As Boolean = False
        'Conectar()
        rs.Open("SELECT venta_detalle.descripcion AS nombre,cantidad,unidad.nombre as unidad,venta_detalle.precio FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim importe As Decimal = CDec(rs.Fields("cantidad").Value) * CDec(rs.Fields("precio").Value)
                Dim importe_cadena As String = ""
                If aplicar_redondeo Then
                    importe_cadena = FormatCurrency(redondear(FormatNumber(importe, 2)))
                Else
                    importe_cadena = FormatCurrency(FormatNumber(importe, 2))
                End If
                If imprime_precios = True Then
                    b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & importe_cadena & "")
                Else
                    b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "", "")
                End If

                'If rs.Fields("descuento").Value > 0 Then
                'b.AnadirElemento("", " *Producto con " & devolver_enteros(rs.Fields("descuento").Value) & " % desc.", "", "")
                'bandera_descuento = True
                'End If
                rs.MoveNext()
            End While

        End If
        rs.Close()
        'conn.close()
        If desc_global_porcent > 0 Then
            b.AnadirElemento("", " ", "", "")
            b.AnadirElemento("", desc_global_porcent & " % Descuento aplicado", "", "")
            bandera_descuento = True
        End If
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        b.AnadirTotal("", "-----------")
        If bandera_descuento Then
            b.AnadirTotal("DESCUENTO", "" & FormatCurrency(obtener_total_desc_venta(id_venta)) & "")
        End If
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio
        If pago_express = True Then
            b.AnadirTotal("COBROS:", "")
            If express_efectivo > 0 Then
                b.AnadirTotal("*Efectivo:", "" & FormatCurrency(express_efectivo) & "")
            End If
            If express_trajeta > 0 Then
                b.AnadirTotal("*Tarjeta:", "" & FormatCurrency(express_trajeta) & "")
            End If
            If express_cupones > 0 Then
                b.AnadirTotal("*Cupones:", "" & FormatCurrency(express_cupones) & "")
            End If
            b.AnadirTotal("", "")
        End If

        b.AnadirTotal("RECIBIDO-EFECT.", "" & pago & "")
        b.AnadirTotal("CAMBIO-EFECT.", "" & cambio & "")

        b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(" " & centrar_texto("SUCURSAL: " & global_nombre_sucursal, cfg_longitud_maxima_ticket, " ") & "")
        b.AnadeLineaAlPie("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_pie(x)) Then
                b.AnadeLineaAlPie(centrar_texto(lineas_ticket_pie(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & centrar_texto(texto_copia, cfg_longitud_maxima_ticket, " ") & "")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Public Sub reimprimir_ticket_venta(ByVal id_venta As Integer, ByVal cliente As String, ByVal cliente_alias As String, ByVal folio As Integer, ByVal subtotal As Decimal, ByVal total_iva As Decimal, ByVal total_otros As Decimal, ByVal total As Decimal, ByVal pago As String, ByVal cambio As String, ByVal empleado As String, ByVal tipo_pago As String, ByVal fecha As String, ByVal hora As String, ByVal num_copia As Integer, ByVal total_copias As Integer)
        Dim id_cliente As Integer = 0
        Dim desc_global_porcent As Decimal = 0
        'Conectar()
        rs.Open("SELECT id_cliente,desc_global_porcent FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            desc_global_porcent = rs.Fields("desc_global_porcent").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Dim aplicar_redondeo As Boolean = obtener_aplicar_redondeo(id_cliente)

        Dim texto_copia As String = ""
        If total_copias > 0 Then
            If num_copia = 0 Then
                texto_copia = "----Cliente----"
            ElseIf num_copia = 1 Then
                texto_copia = "----Establecimiento----"
            Else
                texto_copia = "----Establecimiento " & num_copia & "----"
            End If
        End If
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("FOLIO: " & folio, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(cliente_alias, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Le atendió: " & empleado & "")
        b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        b.AnadirLineaSubcabeza(fecha)
        b.AnadirLineaSubcabeza("Hora: " & hora)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        Dim bandera_descuento As Boolean = False
        'Conectar()
        rs.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad,venta_detalle.precio,venta_detalle.descuento FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim importe As Decimal = CDec(rs.Fields("cantidad").Value) * CDec(rs.Fields("precio").Value)
                Dim importe_cadena As String = ""
                If aplicar_redondeo Then
                    importe_cadena = FormatCurrency(redondear(FormatNumber(importe, 2)))
                Else
                    importe_cadena = FormatCurrency(FormatNumber(importe, 2))
                End If

                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & importe_cadena & "")
                If rs.Fields("descuento").Value > 0 Then
                    b.AnadirElemento("", " *Producto con " & devolver_enteros(rs.Fields("descuento").Value) & " % desc.", "", "")
                    bandera_descuento = True
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        If desc_global_porcent > 0 Then
            b.AnadirElemento("", " ", "", "")
            b.AnadirElemento("", desc_global_porcent & " % Descuento aplicado", "", "")
            bandera_descuento = True
        End If
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        b.AnadirTotal("", "-----------")
        If bandera_descuento Then
            b.AnadirTotal("DESCUENTO", "" & FormatCurrency(obtener_total_desc_venta(id_venta)) & "")
        End If
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio
        b.AnadirTotal("RECIBIDO", "" & pago & "")
        b.AnadirTotal("CAMBIO", "" & cambio & "")
        b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(" " & centrar_texto("SUCURSAL: " & global_nombre_sucursal, cfg_longitud_maxima_ticket, " ") & "")
        b.AnadeLineaAlPie("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_pie(x)) Then
                b.AnadeLineaAlPie(centrar_texto(lineas_ticket_pie(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & centrar_texto(texto_copia, cfg_longitud_maxima_ticket, " ") & "")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub

    Public Sub reimprimir_ticket_venta_manto(ByVal id_venta As Integer, ByVal cliente As String, ByVal cliente_alias As String, ByVal folio As Integer, ByVal subtotal As Decimal, ByVal total_iva As Decimal, ByVal total_otros As Decimal, ByVal total As Decimal, ByVal pago As String, ByVal cambio As String, ByVal empleado As String, ByVal tipo_pago As String, ByVal fecha As String, ByVal hora As String, ByVal num_copia As Integer, ByVal total_copias As Integer)
        Dim id_cliente As Integer = 0
        Dim desc_global_porcent As Decimal = 0
        Dim rx As New ADODB.Recordset
        'Conectar()
        rx.Open("SELECT id_cliente,desc_global_porcent FROM manto_venta WHERE id_venta=" & id_venta, conn)
        If rx.RecordCount > 0 Then
            id_cliente = rx.Fields("id_cliente").Value
            desc_global_porcent = rx.Fields("desc_global_porcent").Value
        End If
        rx.Close()
        'conn.close()
        'conn = Nothing
        Dim aplicar_redondeo As Boolean = obtener_aplicar_redondeo(id_cliente)

        Dim texto_copia As String = ""
        If total_copias > 0 Then
            If num_copia = 0 Then
                texto_copia = "----Cliente----"
            ElseIf num_copia = 1 Then
                texto_copia = "----Establecimiento----"
            Else
                texto_copia = "----Establecimiento " & num_copia & "----"
            End If
        End If
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("FOLIO: " & global_serie & folio, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(cliente_alias, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Le atendió: " & empleado & "")
        b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        b.AnadirLineaSubcabeza(fecha)
        b.AnadirLineaSubcabeza("Hora: " & hora)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        Dim bandera_descuento As Boolean = False
        'Conectar()
        rx.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad,manto_venta_detalle.precio,manto_venta_detalle.descuento FROM manto_venta_detalle JOIN producto ON producto.id_producto=manto_venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE manto_venta_detalle.id_venta='" & id_venta & "'", conn)
        If rx.RecordCount > 0 Then
            While Not rx.EOF
                Dim importe As Decimal = CDec(rx.Fields("cantidad").Value) * CDec(rx.Fields("precio").Value)
                Dim importe_cadena As String = ""
                If aplicar_redondeo Then
                    importe_cadena = FormatCurrency(redondear(FormatNumber(importe, 2)))
                Else
                    importe_cadena = FormatCurrency(FormatNumber(importe, 2))
                End If

                b.AnadirElemento("" & devolver_enteros(rx.Fields("cantidad").Value) & "", "" & centrar_texto(rx.Fields("unidad").Value, 5, " ") & " " & rx.Fields("nombre").Value & "", "" & FormatCurrency(rx.Fields("precio").Value) & "", "" & importe_cadena & "")
                If rx.Fields("descuento").Value > 0 Then
                    b.AnadirElemento("", " *Producto con " & devolver_enteros(rx.Fields("descuento").Value) & " % desc.", "", "")
                    bandera_descuento = True
                End If
                rx.MoveNext()
            End While
        End If
        rx.Close()
        'conn.close()
        If desc_global_porcent > 0 Then
            b.AnadirElemento("", " ", "", "")
            b.AnadirElemento("", desc_global_porcent & " % Descuento aplicado", "", "")
            bandera_descuento = True
        End If
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        b.AnadirTotal("", "-----------")
        If bandera_descuento Then
            b.AnadirTotal("DESCUENTO", "" & FormatCurrency(obtener_total_desc_venta(id_venta)) & "")
        End If
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio
        b.AnadirTotal("RECIBIDO", "" & pago & "")
        b.AnadirTotal("CAMBIO", "" & cambio & "")
        b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(" " & centrar_texto("SUCURSAL: " & global_nombre_sucursal, cfg_longitud_maxima_ticket, " ") & "")
        b.AnadeLineaAlPie("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_pie(x)) Then
                b.AnadeLineaAlPie(centrar_texto(lineas_ticket_pie(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & centrar_texto(texto_copia, cfg_longitud_maxima_ticket, " ") & "")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Public Sub imprimir_recibo_pago_proveedor(ByVal id_compra As Integer, ByVal proveedor As String, ByVal folio As Integer, ByVal pago As String, ByVal deuda As String, ByVal tipo_pago As String, ByVal i As Integer)
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaCLiente("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        Dim letra As String = "(" & Letras(CDbl(pago)) & ")"
        b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        b.AnadirLineaSubcabeza("Recibí de " & global_razon_social & " la cantidad de " & FormatCurrency(pago) & " " + letra + " como pago a la compra  con folio " & id_compra & " del proveedor: " & proveedor & "")
        b.AnadirLineaSubcabeza("Saldo: " & deuda & "")
        'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        b.AnadirLineaSubcabeza("         COMPRA CON FOLIO " & id_compra & " " + vbCrLf + "------------------------------------")
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        'Conectar()
        rs.Open("SELECT descripcion,unidad,precio_unitario,cantidad,(cantidad*precio_unitario) as importe FROM factura_compra_detalle WHERE id_factura_compra='" & id_compra & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("descripcion").Value & "", "" & rs.Fields("precio_unitario").Value & "", "" & FormatCurrency(rs.Fields("importe").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadeLineaAlPie("        Nombre y firma ")
        For x = 0 To 4
            b.AnadeLineaAlPie("")
        Next
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("     _______________________")
        b.AnadeLineaAlPie("           Proveedor ")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        For x = 0 To 3
            b.AnadeLineaAlPie("")
        Next
    End Sub
    Public Sub imprimir_ticket_credito(ByVal tipo As String, ByVal id_venta As Integer, ByVal cliente As String, ByVal folio As Integer, ByVal total As String, ByVal pago As String, ByVal deuda As String, ByVal empleado As String, ByVal tipo_pago As String, ByVal i As Integer)
        Dim id_cliente As Integer = 0

        'Conectar()
        rs.Open("SELECT id_cliente FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Dim aplicar_redondeo As Boolean = obtener_aplicar_redondeo(id_cliente)

        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If
        If tipo = "recibo" Then
            Dim b As ticket = New ticket
            b.HeaderImage = global_logotipo
            b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
            b.AnadirLineaCabeza("")
            For x = 0 To 25
                If Not IsNothing(lineas_ticket_cabeza(x)) Then
                    b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
                Else
                    Exit For
                End If
            Next
            b.AnadirLineaCLiente("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
            b.AnadirLineaCLiente("")
            'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
            'de que al final de cada linea agrega una linea punteada "=========="
            Dim letra As String = "(" & Letras(CDbl(pago)) & ")"
            b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
            b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
            b.AnadirLineaSubcabeza("Recibí de " & cliente & " la cantidad de " & FormatCurrency(pago) & " " + letra + " como abono a la nota de venta " & id_venta & " ")
            b.AnadirLineaSubcabeza("Saldo: " & deuda & "")
            b.AnadirLineaSubcabeza("")
            'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
            'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
            b.AnadirLineaSubcabeza("         NOTA DE VENTA " & id_venta & " " + vbCrLf + "------------------------------------")
            ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
            'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
            'del producto y el tercero es el precio
            Dim imprime_precios As Boolean = True
            rs.Open("SELECT pc.mostrar_precios FROM cliente_precio pc JOIN venta v ON v.id_cliente=pc.id_cliente WHERE v.id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                If rs.Fields("mostrar_precios").Value = 0 Then
                    imprime_precios = False
                End If
            End If
            rs.Close()
            If imprime_precios = True Then
                EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
            Else
                EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
            End If

            Dim bandera_descuento As Boolean = False
            'Conectar()
            rs.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad,venta_detalle.precio,venta_detalle.descuento FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim importe As Decimal = CDec(rs.Fields("cantidad").Value) * CDec(rs.Fields("precio").Value)
                    Dim importe_cadena As String = ""
                    If aplicar_redondeo Then
                        importe_cadena = FormatCurrency(redondear(FormatNumber(importe, 2)))
                    Else
                        importe_cadena = FormatCurrency(FormatNumber(importe, 2))
                    End If
                    If imprime_precios = True Then
                        b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "" & rs.Fields("precio").Value & "", "" & importe_cadena & "")
                    Else
                        b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "", "")
                    End If

                    If rs.Fields("descuento").Value > 0 Then
                        b.AnadirElemento("", " *Producto con " & devolver_enteros(rs.Fields("descuento").Value) & " % desc.", "", "")
                        bandera_descuento = True
                    End If
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            If bandera_descuento Then
                b.AnadirTotal("DESCUENTO", "" & FormatCurrency(obtener_total_desc_venta(id_venta)) & "", 1)
                b.AnadirTotal("", "")
            End If
            b.AnadirTotal("TOTAL", "" & total & "", 1)
            For x = 0 To 2
                b.AnadirTotal("", "")
            Next
            'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            b.AnadeLineaAlPie("        Nombre y firma ")
            For x = 0 To 4
                b.AnadeLineaAlPie("")
            Next
            'b.AnadirTotal("USTED-AHORRO", "0.00")
            '//El metodo AddFooterLine funciona igual que la cabecera
            b.AnadeLineaAlPie("     _______________________")
            b.AnadeLineaAlPie("           Cajero(a) ")
            b.AnadeLineaAlPie("Recibe: " & empleado)
            b.AnadeLineaAlPie("" & no_copia & "")
            b.ImprimeTicket(conf_impresoras(0))
            For x = 0 To 3
                b.AnadeLineaAlPie("")
            Next
        ElseIf tipo = "pagare" Then
            Dim b As ticket = New ticket
            'b.AnadirLineaCabeza("          PAGARE")
            b.HeaderImage = global_logotipo
            b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, " ") & "")
            b.AnadirLineaCabeza("")
            For x = 0 To 25
                If Not IsNothing(lineas_ticket_cabeza(x)) Then
                    b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
                Else
                    Exit For
                End If
            Next

            b.AnadirLineaCLiente("" & centrar_texto("PAGARE", cfg_longitud_titulo, " ") & "")
            b.AnadirLineaCLiente("")
            b.AnadirLineaCLiente("" & centrar_texto("CLIENTE: " & cliente, cfg_longitud_titulo, " ") & "")

            'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
            'de que al final de cada linea agrega una linea punteada "=========="
            b.AnadirLineaSubcabeza("")
            Dim letra As String = "(" & Letras(CDbl(total)) & ")"
            b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
            b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("Por el presente PAGARÉ me obligo  a pagar incondicionalmente  en esta plaza a orden de " & global_razon_social & " el dia ___ de ______________ de 20____la cantidad de " & FormatCurrency(total) & " " + letra + " . Asi como, en caso de no ser cubierta arriba mencionada me comprometo a pagar intereses moratorios al ___% mensual, asi como todos los gastos judiciales y extrajudiciales que erogen para el cobro desde la fecha en que debio ser pagada hasta la total liquidación del adeudo.")
            'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
            'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & 
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("         NOTA DE VENTA " & id_venta & " " + vbCrLf + "------------------------------------")
            ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
            'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
            'del producto y el tercero es el precio
            Dim imprime_precios As Boolean = True
            rs.Open("SELECT pc.mostrar_precios FROM cliente_precio pc JOIN venta v ON v.id_cliente=pc.id_cliente WHERE v.id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                If rs.Fields("mostrar_precios").Value = 0 Then
                    imprime_precios = False
                End If
            End If
            rs.Close()
            If imprime_precios = True Then
                EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
            Else
                EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
            End If

            Dim bandera_descuento As Boolean = False
            'Conectar()
            rs.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad,venta_detalle.precio,venta_detalle.importe " & _
                    "FROM venta_detalle " & _
                    "JOIN producto ON producto.id_producto=venta_detalle.id_producto " & _
                    "JOIN unidad ON unidad.id_unidad=producto.id_unidad " & _
                    "WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim importe As Decimal = rs.Fields("importe").Value
                    Dim importe_cadena As String = ""
                    importe_cadena = FormatCurrency(importe, 2)
                

                    If imprime_precios = True Then
                        b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "" & rs.Fields("precio").Value & "", "" & importe_cadena & "")
                    Else
                        b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "", "")
                    End If
                    rs.MoveNext()
                End While
            End If
            rs.Close()


            b.AnadirTotal("", "")

            b.AnadirTotal("TOTAL", "" & total & "", 1)
            For x = 0 To 2
                b.AnadirTotal("", "")
            Next
            b.AnadeLineaAlPie("        Nombre y firma ")
            For x = 0 To 4
                b.AnadeLineaAlPie("")
            Next
            'b.AnadirTotal("USTED-AHORRO", "0.00")
            '//El metodo AddFooterLine funciona igual que la cabecera
            b.AnadeLineaAlPie("     _______________________")
            b.AnadeLineaAlPie("           Cliente ")
            b.AnadeLineaAlPie("")
            b.AnadeLineaAlPie("" & no_copia & "")
            b.ImprimeTicket(conf_impresoras(0))
            For x = 0 To 3
                b.AnadeLineaAlPie("")
            Next
        End If

    End Sub
    Public Sub imprimir_ticket_cobro_factura(ByVal tipo As String, ByVal id_factura As Integer, ByVal cliente As String, ByVal empleado As String, ByVal tipo_pago As String, ByVal i As Integer)
        Dim id_cliente As Integer = 0
        Dim num_factura As String = ""
        Dim subtotal As Decimal = 0
        Dim iva As Decimal = 0
        Dim otros As Decimal = 0
        Dim total As Decimal = 0
        'Conectar()
        rs.Open("SELECT id_factura_electronica,id_cliente,subtotal,iva,total FROM factura_electronica WHERE id_factura_electronica=" & id_factura, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            num_factura = rs.Fields("id_factura_electronica").Value
            subtotal = rs.Fields("subtotal").Value
            iva = rs.Fields("iva").Value
            ' otros = rs.Fields("otros").Value
            total = rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Dim aplicar_redondeo As Boolean = obtener_aplicar_redondeo(id_cliente)

        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If
        If tipo = "recibo" Then
            Dim b As ticket = New ticket
            b.HeaderImage = global_logotipo
            b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
            b.AnadirLineaCabeza("")
            For x = 0 To 25
                If Not IsNothing(lineas_ticket_cabeza(x)) Then
                    b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
                Else
                    Exit For
                End If
            Next
            b.AnadirLineaCLiente("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
            b.AnadirLineaCLiente("")
            'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
            'de que al final de cada linea agrega una linea punteada "=========="
            Dim letra As String = "(" & Letras(CDbl(total)) & ")"
            b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
            b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
            b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago)
            b.AnadirLineaSubcabeza("Recibí de " & cliente & " la cantidad de " & FormatCurrency(total) & " " + letra + " como pago a la factura con folio " & num_factura & " ")
            b.AnadirLineaSubcabeza("")
            'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
            'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")

            'Conectar()
            rs.Open("SELECT fed.cantidad,p.nombre as descripcion,u.nombre AS unidad,fed.precio,fed.importe, p.codigo " & _
                    "FROM factura_electronica_detalle fed " & _
                    "JOIN producto p ON p.id_producto=fed.id_producto " & _
                    "JOIN unidad u ON  u.id_unidad=p.id_unidad " & _
                    "WHERE fed.id_factura_electronica=" & id_factura, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    'rs.Fields("codigo").Value
                    b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("descripcion").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & FormatCurrency(rs.Fields("importe").Value) & "")
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing

            'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
            b.AnadirTotal("I.V.A.", "" & FormatCurrency(iva) & "")
            b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
            b.AnadirTotal("", "-----------")
            For x = 0 To 2
                b.AnadirTotal("", "")
            Next
            'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            b.AnadeLineaAlPie("        Nombre y firma ")
            For x = 0 To 4
                b.AnadeLineaAlPie("")
            Next
            'b.AnadirTotal("USTED-AHORRO", "0.00")
            '//El metodo AddFooterLine funciona igual que la cabecera
            b.AnadeLineaAlPie("     _______________________")
            b.AnadeLineaAlPie("           Cajero(a) ")
            b.AnadeLineaAlPie("Recibe: " & empleado)
            b.AnadeLineaAlPie("" & no_copia & "")
            b.ImprimeTicket(conf_impresoras(0))
            For x = 0 To 3
                b.AnadeLineaAlPie("")
            Next

        End If

    End Sub
    Public Sub imprimir_corte_caja(Optional ByVal cajero_efectivo As Decimal = 0, Optional ByVal cajero_tarjeta As Decimal = 0, Optional ByVal cajero_transferencia As Decimal = 0, Optional ByVal cajero_cheque As Decimal = 0, Optional ByVal cajero_nota As Decimal = 0, Optional ByVal billete_20 As Decimal = 0, Optional ByVal billete_50 As Decimal = 0, Optional ByVal billete_100 As Decimal = 0, Optional ByVal billete_200 As Decimal = 0, Optional ByVal billete_500 As Decimal = 0, Optional ByVal billete_1000 As Decimal = 0, Optional ByVal moneda_1 As Decimal = 0, Optional ByVal moneda_2 As Decimal = 0, Optional ByVal moneda_5 As Decimal = 0, Optional ByVal moneda_10 As Decimal = 0, Optional ByVal moneda_50c As Decimal = 0, Optional ByVal tarjeta_visa_cajero As Decimal = 0, Optional ByVal tarjeta_mc_cajero As Decimal = 0, Optional ByVal tarjeta_ae_cajero As Decimal = 0)
        EncabezadoConcepto = "    CATEGORIA      TOTAL*     IMPUESTO"
        Dim total_devoluciones As Decimal = 0
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, ""))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaSubcabeza("         CIERRE DE VENTAS")
        b.AnadirLineaSubcabeza("Caja # 1")
        b.AnadirLineaSubcabeza("Usuario:" & global_nombre & "")
        'Conectar()
        'Conectar()
        rs.Open("SELECT MIN(num_ticket) As folio_inicio,MAX(num_ticket) As folio_termino FROM venta WHERE date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("Del folio " & global_serie & rs.Fields("folio_inicio").Value & " al " & global_serie & rs.Fields("folio_termino").Value & "")
        End If
        rs.Close()


        b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio

        If conf_pv(17) = 1 Then ' IMPRESION DE PRODUCTOS DE PUBLICO EN GENERAL
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            b.AnadirLineaSubcabeza(" PRODUCTOS PUBLICO EN GENERAL")
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            b.AnadirLineaSubcabeza(" CANT.    UNID.  P.UNITARIO  IMPORTE")
            'rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1) AS cantidad_vendido,(SELECT SUM(importe) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1) AS importe_producto,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1),venta_detalle.precio) AS puntero " & _
            '"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
            '"WHERE venta.status='CERRADA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1 GROUP BY puntero " & _
            '"ORDER BY cantidad_vendido DESC", conn)
            Dim rw, ry As New ADODB.Recordset
            rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta_detalle vd " & _
               "JOIN venta v ON vd.id_venta=v.id_venta " & _
               "JOIN producto p ON p.id_producto=vd.id_producto " & _
               "WHERE v.status='CERRADA' AND DATE(v.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND v.id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND v.id_cliente='1' ", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " & _
                                       "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                               "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND v.status='CERRADA' AND DATE(v.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND v.id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND v.id_cliente='1' ", conn)
                    If rw.RecordCount > 0 Then
                        While Not rw.EOF
                            ry.Open("SELECT SUM(vd.cantidad) AS cantidad_vendido FROM venta_detalle vd " & _
                           "JOIN venta v ON v.id_venta=vd.id_venta " & _
                   "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND v.status='CERRADA' AND DATE(v.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND v.id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND v.id_cliente='1' ORDER BY vd.cantidad DESC", conn)
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

            'b.AnadirLineaSubcabeza("----------------------------------")
        End If


        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & "),venta_detalle.precio) AS puntero " & _
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
"WHERE venta.status='REGALIA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " GROUP BY puntero " & _
"ORDER BY cantidad_vendido DESC", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            b.AnadirLineaSubcabeza("        REGALIAS")
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'b.AnadirLineaSubcabeza("-----------------------------------")
        '----agregar_creditos

        rs.Open("SELECT venta.id_venta,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
                "FROM cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
                "WHERE venta.status='PENDIENTE' and date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_empleado_caja='" & global_id_empleado & "' AND venta.id_corte=0", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            b.AnadirLineaSubcabeza("         CUENTAS POR COBRAR     ")
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            While Not rs.EOF
                b.AnadirLineaSubcabeza("FOLIO:" & global_serie & rs.Fields("id_venta").Value & " " & rs.Fields("nombre").Value & " " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        b.AnadirLineaSubcabeza("")

        limpiar_abonos()
        'Conectar()
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='0' AND pagos_ventas.es_abono='1'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            b.AnadirLineaSubcabeza("         COBROS CREDITOS     ")
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            While Not rs.EOF
                Dim i As Integer = rs.Fields("id_forma_pago").Value
                abonos(i) += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        'conn = Nothing
        For x = 0 To 22
            If abonos(x) <> 0 Then
                b.AnadirLineaSubcabeza("" & nombre_forma_pago(x) & "   " & FormatCurrency(abonos(x)) & "")
            End If
        Next
        'b.AnadirLineaSubcabeza("-----------------------------------")

        'limpiar_abonos()
        'Conectar()
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_compras.importe)AS total FROM pagos_compras JOIN forma_pago ON forma_pago.id_forma_pago=pagos_compras.id_forma_pago JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  WHERE DATE(pagos_compras.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_compras.id_empleado_pago='" & global_id_empleado & "' AND pagos_compras.afecta_caja='1'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            b.AnadirLineaSubcabeza("         PAGO A PROVEEDORES")
            b.AnadirLineaSubcabeza("══════════════════════════════════")
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & UCase(rs.Fields("descripcion").Value) & "   " & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        b.AnadirLineaSubcabeza("")
        'b.AnadirLineaSubcabeza("-----------------------------------")

        'limpiar_abonos()
        Dim devoluciones_encontrado As Boolean = False
        'Conectar()
        rs.Open("SELECT devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones.bandera_corte_caja='0' AND DATE(devoluciones.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND devoluciones.id_empleado='" & global_id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) AND devoluciones_detalle.id_producto=id) AS cantidad, CONCAT(devoluciones_detalle.unidad,' ',devoluciones_detalle.descripcion) AS producto " & _
                " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion " & _
                "WHERE devoluciones.bandera_corte_caja='0' AND DATE(devoluciones.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND devoluciones.id_empleado='" & global_id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) GROUP BY id_producto", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            b.AnadirLineaSubcabeza("" & centrar_texto("DEVOLUCIONES (Solo en efectivo)", cfg_longitud_maxima_ticket, "") & "")
            b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
            devoluciones_encontrado = True
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & rs.Fields("cantidad").Value & " " & rs.Fields("producto").Value & " " & FormatCurrency(rs.Fields("precio_unitario").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'b.AnadirLineaSubcabeza("")
        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_iva) IS NULL THEN 0 ELSE SUM(total_iva)  END  AS total_iva,CASE WHEN SUM(total_otros) IS NULL THEN 0 ELSE SUM(total_otros)  END  AS total_otros,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_empleado='" & global_id_empleado & "' AND (tipo_devolucion=3 OR  tipo_devolucion=4) AND bandera_corte_caja=0", conn)
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
        'conn.close()
        'conn = Nothing
        'b.AnadirLineaSubcabeza("")
        'b.AnadirLineaSubcabeza("-----------------------------------")
        b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
        b.AnadirLineaSubcabeza(centrar_texto("TOTAL VENTAS POR CATEGORIAS", cfg_longitud_maxima_ticket, " "))
        b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "="))
        b.AnadirLineaSubcabeza("*impuestos incluidos")
        'Conectar()
        rs.Open("SELECT categoria.nombre,(SUM(((venta_detalle.importe)-(((venta_detalle.importe)*venta_detalle.descuento)/100))+venta_detalle.impuesto))AS total,SUM(venta_detalle.impuesto) AS impuesto FROM venta_detalle " & _
                "JOIN producto on producto.id_producto=venta_detalle.id_producto " & _
                "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                "JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
                "WHERE date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_empleado='" & global_id_empleado & "' AND venta.id_corte='0' AND (venta.status='CERRADA' OR venta.status='PENDIENTE' OR venta.status='APARTADO' OR venta.status='PEDIDO') GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("", "" & UCase(rs.Fields("nombre").Value) & "", "" & FormatCurrency(rs.Fields("total").Value) & "", "" & FormatCurrency(rs.Fields("impuesto").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        'b.AnadirElemento("", "------------", "---------", "---------")

        'Conectar()

        Dim total_ventas As Double = 0
        rs.Open("SELECT (CASE WHEN ISNULL(sum(total)) THEN 0 ELSE sum(total) END)as total FROM venta WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_empleado='" & global_id_empleado & "' AND (status='CERRADA' OR status='PENDIENTE' OR status='APARTADO' or status='PEDIDO') AND id_corte=0", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas = total_ventas + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        Dim total_ventas_cobradas As Double = 0
        rs.Open("SELECT  CASE WHEN ISNULL(SUM(pagos_ventas.importe)) THEN 0 ELSE SUM(pagos_ventas.importe) END AS total FROM pagos_ventas " & _
                "JOIN venta ON venta.id_venta=pagos_ventas.id_venta  " & _
                "WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_ventas.id_corte='0' AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1' ", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas_cobradas = total_ventas_cobradas + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        b.AnadirTotal("", "")
        b.AnadirTotal("", "------------")
        b.AnadirTotal("TOTAL-VENTAS", "" & FormatCurrency(total_ventas) & "")
        b.AnadirTotal("TOTAL-COBROS", "" & FormatCurrency(total_ventas_cobradas) & "")
        'Agregamos la suma de impuestos
        rs.Open("SELECT (CASE WHEN ISNULL(sum(total_iva)) THEN 0 ELSE sum(total_iva) END)as total_iva ,(CASE WHEN ISNULL(sum(total_otros)) THEN 0 ELSE sum(total_otros) END) AS total_otros from venta WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_empleado_caja=" & global_id_empleado & " AND status='CERRADA' AND id_corte=0", conn)
        If rs.RecordCount > 0 Then
            b.AnadirTotal("TOTAL-IVA", "" & rs.Fields("total_iva").Value & "")
            b.AnadirTotal("OTROS-IMPS.", "" & rs.Fields("total_otros").Value & "")
        End If
        rs.Close()
        'conn.close()
        '-----------------------------

        b.AnadirTotal("FONDO-CAJA", "" & FormatCurrency(fondo_caja_inicial()) & "")
        b.AnadirTotal("+TOTAL-DEPOSITOS", "" & FormatCurrency(depositos()) & "")
        b.AnadirTotal("-TOTAL-RETIROS", "" & FormatCurrency(retiros()) & "")
        b.AnadirTotal("-DEVOLUCIONES", "" & FormatCurrency(total_devoluciones) & "")
        b.AnadirTotal("TOTAL-CAJA(SIN_FONDO)", "" & FormatCurrency(saldo_caja() - fondo_caja_inicial()) & "", )
        b.AnadirTotal("", "")
        b.AnadirTotal("TOTAL-CAJA", "" & FormatCurrency(saldo_caja()) & "", 1)
        b.AnadirTotal("", "")


        b.AnadirTotal("======FORMAS-DE-PAGO =======", "")
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
               "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
               "JOIN venta ON venta.id_venta=pagos_ventas.id_venta  " &
               "WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirTotal("" & UCase(rs.Fields("descripcion").Value) & "", "" & FormatCurrency(rs.Fields("total").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        b.AnadirTotal(" ", "")
        '===========================================================        b.AnadirTotal("", "")
        b.AnadirTotal("======DECLARACIONES-CAJERO=======", "")
        b.AnadirTotal("Efectivo", "" & FormatCurrency(cajero_efectivo) & "")
        b.AnadirTotal("->Billete-20", "" & billete_20 & "")
        b.AnadirTotal("->Billete-50", "" & billete_50 & "")
        b.AnadirTotal("->Billete-100", "" & billete_100 & "")
        b.AnadirTotal("->Billete-200", "" & billete_200 & "")
        b.AnadirTotal("->Billete-500", "" & billete_500 & "")
        b.AnadirTotal("->Billete-1000", "" & billete_1000 & "")
        b.AnadirTotal("->Moneda--50c", "" & moneda_50c & "")
        b.AnadirTotal("->Moneda--1", "" & moneda_1 & "")
        b.AnadirTotal("->Moneda--2", "" & moneda_2 & "")
        b.AnadirTotal("->Moneda--5", "" & moneda_5 & "")
        b.AnadirTotal("->Moneda--10", "" & moneda_10 & "")
        b.AnadirTotal("Tarjeta", "" & FormatCurrency(cajero_tarjeta) & "")
        b.AnadirTotal("->Visa", "" & tarjeta_visa_cajero & "")
        b.AnadirTotal("->Master-Card", "" & tarjeta_mc_cajero & "")
        b.AnadirTotal("->American-Express", "" & tarjeta_ae_cajero & "")
        b.AnadirTotal("Transferencia", "" & FormatCurrency(cajero_transferencia) & "", )
        b.AnadirTotal("Cheque", "" & FormatCurrency(cajero_cheque) & "", )
        b.AnadirTotal("Nota-Credito", "" & FormatCurrency(cajero_nota) & "", )
        b.AnadirTotal("", "")
        b.AnadirTotal("Diferencia(+)sobrante(-)faltante", "")
        b.AnadirTotal("DIFERENCIA:", "" & FormatCurrency((cajero_efectivo - saldo_caja())) & "", 1)
        '===========================================================

        For x = 0 To 3
            b.AnadirTotal("", "")
        Next
        b.AnadeLineaAlPie("  _______________  ______________")
        b.AnadeLineaAlPie("    CAJERA GRAL.   CAJERA LINEA.")
        '//El metodo AddFooterLine funciona igual que la cabecera
        ' b.AnadeLineaAlPie("PIE DE PAGINA...............")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Private Sub limpiar_abonos()
        For x = 0 To 4
            abonos(x) = 0
        Next
    End Sub
    Public Sub imprimir_compra_producto(ByVal id_compra As Integer, Optional ByVal i As Integer = 0)
        Dim subtotal As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim total As Decimal = 0
        Dim fecha As Date
        Dim hora As DateTime
        Dim receptor As String = ""
        Dim proveedor As String = ""
        Dim proveedor_alias As String = ""
        Dim no_copia As String = ""
        Dim id_proveedor As Integer = 0
        Dim folio_factura As String = ""
        'Conectar()
        rs.Open("SELECT factura_compra.folio,factura_compra.id_proveedor,date(factura_compra.fecha) as fecha, time(factura_compra.fecha) as hora,factura_compra.subtotal, factura_compra.iva,factura_compra.otros,factura_compra.total,(SELECT CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE factura_compra.id_factura_compra=" & id_compra & ") as proveedor, CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) As receptor " & _
        "FROM empleado JOIN persona on persona.id_persona=empleado.id_persona JOIN  producto_recepcion ON producto_recepcion.id_empleado=empleado.id_empleado JOIN factura_compra ON factura_compra.id_factura_compra=producto_recepcion.id_factura_compra " & _
        "WHERE factura_compra.id_factura_compra=" & id_compra, conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            hora = rs.Fields("hora").Value
            subtotal = rs.Fields("subtotal").Value
            total_iva = rs.Fields("iva").Value
            total_otros = rs.Fields("otros").Value
            total = rs.Fields("total").Value
            proveedor = rs.Fields("proveedor").Value
            receptor = rs.Fields("receptor").Value
            id_proveedor = rs.Fields("id_proveedor").Value
            folio_factura = rs.Fields("folio").Value
        End If
        rs.Close()
        rs.Open("SELECT proveedor.id_persona, CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS proveedor_alias" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE proveedor.id_proveedor=" & id_proveedor, conn)
        If rs.RecordCount > 0 Then
            proveedor_alias = rs.Fields("proveedor_alias").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
        Dim b As ticket = New ticket
        If i = 0 Then
            no_copia = "Original"
        Else
            no_copia = "Copia"
        End If
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("RECEPCION DE PRODUCTO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("--------------------------")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("Folio:  " & Format(id_compra), cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(proveedor_alias, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("Folio:  " & Format(id_compra, "000000") & "")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString)
        b.AnadirLineaSubcabeza("Hora: " & hora.ToLongTimeString)
        b.AnadirLineaSubcabeza("Proveedor: " & proveedor)
        b.AnadirLineaSubcabeza("Remision del proveedor:" & folio_factura)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        'Conectar()
        rs.Open("SELECT CONCAT(unidad,' ',descripcion) as producto , cantidad,precio_unitario,(precio_unitario*cantidad) as importe FROM factura_compra_detalle WHERE id_factura_compra=" & id_compra, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & rs.Fields("producto").Value & "", "", "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        b.AnadirTotal("", "-----------")
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

        b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("Recibe:" & receptor & " ")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("  Recibí producto      proveedor")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("  ______________     ______________")
        b.AnadeLineaAlPie("")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("" & no_copia & "")
        Imprimir_recepcion_producto = 1
        b.ImprimeTicket(conf_impresoras(2))
        Imprimir_recepcion_producto = 0
    End Sub
    Public Sub imprimir_devolucion_proveedor(ByVal id_devolucion_proveedor As Integer, Optional ByVal i As Integer = 0)
        Dim subtotal As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim total As Decimal = 0
        Dim fecha As Date
        Dim hora As DateTime
        Dim empleado As String = ""
        Dim proveedor As String = ""
        Dim proveedor_alias As String = ""
        Dim no_copia As String = ""
        Dim id_proveedor As Integer = 0
        Dim id_factura_compra As Integer = 0

        'Conectar()
        rs.Open("SELECT fc.id_proveedor, dp.id_factura_compra,DATE(dp.fecha) AS fecha, TIME(dp.fecha) AS hora,dp.subtotal,dp.total_iva,dp.total_otros,dp.total,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) as empleado " & _
                "FROM devoluciones_proveedor dp " & _
                "JOIN empleado e On e.id_empleado=dp.id_empleado " & _
                "JOIN factura_compra fc On fc.id_factura_compra=dp.id_factura_compra " & _
                "JOIN persona p ON p.id_persona=e.id_persona WHERE dp.id_devolucion='" & id_devolucion_proveedor & "'", conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            hora = rs.Fields("hora").Value
            subtotal = rs.Fields("subtotal").Value
            total_iva = rs.Fields("total_iva").Value
            total_otros = rs.Fields("total_otros").Value
            total = rs.Fields("total").Value
            empleado = rs.Fields("empleado").Value
            id_proveedor = rs.Fields("id_proveedor").Value
            id_factura_compra = rs.Fields("id_factura_compra").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre " & _
"FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
"LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
"JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE factura_compra.id_factura_compra='" & id_factura_compra & "'")
        If rs.RecordCount > 0 Then
            proveedor = rs.Fields("nombre").Value
        End If
        rs.Close()

        rs.Open("SELECT proveedor.id_persona, CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS proveedor_alias" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE proveedor.id_proveedor=" & id_proveedor, conn)
        If rs.RecordCount > 0 Then
            proveedor_alias = rs.Fields("proveedor_alias").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        EncabezadoConcepto = "PRODUCTOS DEVUELTOS"
        EncabezadoConcepto = "======================"
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
        Dim b As ticket = New ticket
        If i = 0 Then
            no_copia = "Original"
        Else
            no_copia = "Copia"
        End If
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("DEVOLUCION A  PROVEEDOR", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("--------------------------")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("Folio Recepción:  " & Format(id_factura_compra), cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(proveedor_alias, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("Folio:  " & Format(id_compra, "000000") & "")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString)
        b.AnadirLineaSubcabeza("Hora: " & hora.ToLongTimeString)
        b.AnadirLineaSubcabeza("Proveedor: " & proveedor)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        'Conectar()
        rs.Open("SELECT CONCAT(unidad,' ',descripcion) as producto , cantidad,precio_unitario,(precio_unitario*cantidad) as importe FROM devoluciones_proveedor_detalle WHERE id_devolucion_proveedor=" & id_devolucion_proveedor, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & rs.Fields("producto").Value & "", "", "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        b.AnadirTotal("", "-----------")
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

        b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("Entregó :" & empleado & " ")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("  Colaborador      Proveedor")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("  ______________     ______________")
        b.AnadeLineaAlPie("")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("" & no_copia & "")
        Imprimir_recepcion_producto = 1
        b.ImprimeTicket(conf_impresoras(2))
        Imprimir_recepcion_producto = 0
    End Sub
    Public Sub imprimir_traspaso_recep(ByVal id_traspaso_recep As Integer, Optional ByVal i As Integer = 0)
        Dim folio_origen As Integer
        Dim fecha As Date
        Dim hora As DateTime
        Dim receptor As String = ""
        Dim sucursal As String = ""
        Dim no_copia As String = ""
        'Conectar()
        rs.Open("SELECT date(fecha_registro) as fecha, time(fecha_registro) as hora,folio_origen,empleado_recep,sucursal_origen FROM traspaso_recep WHERE id_traspaso_recep=" & id_traspaso_recep, conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            hora = rs.Fields("hora").Value
            receptor = rs.Fields("empleado_recep").Value
            sucursal = rs.Fields("sucursal_origen").Value
            folio_origen = rs.Fields("folio_origen").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        EncabezadoConcepto = "CANT   CODIGO     UNIDAD DESCRIP."
        Dim b As ticket = New ticket
        If i = 0 Then
            no_copia = "Original"
        Else
            no_copia = "Copia"
        End If
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("TRASPASO DE PRODUCTO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("FOLIO RECEP:  " & Format(id_traspaso_recep), cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("--------------------------")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("FOLIO ENVÍO: " & folio_origen, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("ORIGEN:" & sucursal, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("Folio:  " & Format(id_compra, "000000") & "")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString)
        b.AnadirLineaSubcabeza("Hora: " & hora.ToLongTimeString)
        'b.AnadirLineaSubcabeza("Proveedor: " & proveedor)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        'Conectar()
        rs.Open("SELECT CONCAT(' ',traspaso_recep_detalle.unidad,' ',traspaso_recep_detalle.descripcion) as producto,traspaso_recep_detalle.cantidad,producto.codigo FROM traspaso_recep_detalle JOIN producto ON producto.id_producto=traspaso_recep_detalle.id_producto WHERE id_traspaso_recep=" & id_traspaso_recep, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", " " & rs.Fields("codigo").Value & "  " & rs.Fields("producto").Value & "", "", "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        'b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        ''.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        'b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        'b.AnadirTotal("", "-----------")
        'b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        'b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

        'b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        'b.AnadeLineaAlPie("Recibe:" & receptor & " ")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & centrar_texto("RECIBÍ PRODUCTO", 36, " ") & "")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("" & centrar_texto("_________________", 36, " ") & "")
        b.AnadeLineaAlPie("" & centrar_texto(receptor, 36, " ") & "")
        b.AnadeLineaAlPie("")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("" & centrar_texto("SUCURSAL: " & global_nombre_sucursal, 36, " ") & "")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & no_copia & "")
        Imprimir_recepcion_producto = 1
        b.ImprimeTicket(conf_impresoras(2))
        Imprimir_recepcion_producto = 0
    End Sub
    Public Sub imprimir_traspaso_env(ByVal id_traspaso_env As Integer, Optional ByVal i As Integer = 0)
        Dim fecha As Date
        Dim hora As DateTime
        Dim empleado As String = ""
        Dim sucursal As String = ""
        Dim no_copia As String = ""
        'Conectar()
        rs.Open("SELECT date(fecha) as fecha, time(fecha) as hora,nombre_empleado,sucursal_destino FROM traspaso_env WHERE id_traspaso_env=" & id_traspaso_env, conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            hora = rs.Fields("hora").Value
            empleado = rs.Fields("nombre_empleado").Value
            sucursal = rs.Fields("sucursal_destino").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        EncabezadoConcepto = "CANT   CODIGO     UNIDAD DESCRIP."
        Dim b As ticket = New ticket
        If i = 0 Then
            no_copia = "Original"
        Else
            no_copia = "Copia"
        End If
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaCLiente("" & centrar_texto("TRASPASO DE PRODUCTO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("FOLIO ENVÍO:  " & Format(id_traspaso_env), cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("--------------------------")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("DE:" & global_nombre_sucursal, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("PARA:" & sucursal, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("Folio:  " & Format(id_compra, "000000") & "")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString)
        b.AnadirLineaSubcabeza("Hora: " & hora.ToLongTimeString)
        'b.AnadirLineaSubcabeza("Proveedor: " & proveedor)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        'Conectar()
        rs.Open("SELECT CONCAT(' ',traspaso_env_detalle.unidad,' ',traspaso_env_detalle.descripcion) as producto,traspaso_env_detalle.cantidad,producto.codigo FROM traspaso_env_detalle JOIN producto ON producto.id_producto=traspaso_env_detalle.id_producto WHERE id_traspaso_env=" & id_traspaso_env, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", " " & rs.Fields("codigo").Value & "  " & rs.Fields("producto").Value & "", "", "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        'b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        ''.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        'b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        'b.AnadirTotal("", "-----------")
        'b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        'b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

        'b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        'b.AnadeLineaAlPie("Recibe:" & receptor & " ")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & centrar_texto("FIRMA DE SALIDA", 36, " ") & "")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("" & centrar_texto("_________________", 36, " ") & "")
        b.AnadeLineaAlPie("" & centrar_texto(empleado, 36, " ") & "")
        b.AnadeLineaAlPie("")
        For x = 0 To 2
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("" & centrar_texto("SUCURSAL: " & global_nombre_sucursal, 36, " ") & "")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & no_copia & "")
        Imprimir_recepcion_producto = 1
        b.ImprimeTicket(conf_impresoras(0))
        Imprimir_recepcion_producto = 0
    End Sub
    Public Sub imprimir_ticket_pedido_pagare(ByVal id_pedido As Integer, Optional ByVal i As Integer = 0)
        Dim subtotal As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim total As Decimal = 0
        Dim fecha As Date
        Dim hora As DateTime
        Dim agente_entrega As String = ""
        Dim no_copia As String = ""
        Dim cliente As String = ""
        Dim cliente_alias As String = ""
        Dim id_venta As Integer = 0
        Dim id_cliente As Integer = 0
        Dim aplicar_redondeo As Boolean = True
        'Conectar()
        rs.Open("SELECT pedido_clientes.id_cliente,pedido_clientes.fecha_entrega,pedido_clientes.num_ticket,pedido_clientes.subtotal,pedido_clientes.iva,pedido_clientes.otros_impuestos,pedido_clientes.total,pedido_clientes.id_venta,(SELECT CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) FROM persona JOIN empleado ON empleado.id_persona=persona.id_persona JOIN pedido_clientes ON pedido_clientes.id_empleado_entrega=empleado.id_empleado WHERE pedido_clientes.id_pedido=" & id_pedido & ") AS agente_entrega, CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN pedido_clientes ON pedido_clientes.id_cliente=cliente.id_cliente WHERE pedido_clientes.id_pedido=" & id_pedido, conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha_entrega").Value
            hora = rs.Fields("fecha_entrega").Value
            subtotal = rs.Fields("subtotal").Value
            total_iva = rs.Fields("iva").Value
            total_otros = rs.Fields("otros_impuestos").Value
            total = rs.Fields("total").Value
            agente_entrega = rs.Fields("agente_entrega").Value
            cliente = rs.Fields("cliente").Value
            cliente_alias = rs.Fields("cliente_alias").Value
            id_venta = rs.Fields("id_venta").Value
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '     EncabezadoConcepto = "CANT UNIDAD   DESCRIP.   P.UNIT. IMPORTE"
        '     Dim b As ticket = New ticket
        If i = 0 Then
            no_copia = "Original"
        Else
            no_copia = "Copia"
        End If
        aplicar_redondeo = obtener_aplicar_redondeo(id_cliente)
        '      b.HeaderImage = logo
        '       b.AnadirLineaCabeza("   ARCELIA CASTELLANOS HERNANDEZ")
        '      b.AnadirLineaCabeza("MORELOS S/N LOCALES 26 Y 32 CENTRO          OAXACA.OAX CP.68000")
        '      b.AnadirLineaCabeza("          RFC:CAHA840519CQ8")
        '      b.AnadirLineaCabeza("        TEL/FAX (951)132 4181")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        '      b.AnadirLineaCLiente("" & centrar_texto("ENTREGA DE PRODUCTO", cfg_longitud_titulo) & "")
        '      b.AnadirLineaCLiente("--------------------------")
        '       b.AnadirLineaCLiente("")
        '      b.AnadirLineaCLiente("" & centrar_texto("PEDIDO :  " & Format(id_pedido), cfg_longitud_titulo) & "")
        '      b.AnadirLineaCLiente("")
        '      b.AnadirLineaCLiente("" & centrar_texto(cliente, cfg_longitud_titulo) & "")
        'b.AnadirLineaSubcabeza("Folio:  " & Format(id_compra, "000000") & "")
        '      b.AnadirLineaSubcabeza("" & fecha.ToLongDateString)
        '      b.AnadirLineaSubcabeza("Hora: " & hora.ToLongTimeString)
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        '   'Conectar()
        '   rs.Open("SELECT CONCAT(unidad,'  ',descripcion) as producto , cantidad,precio,(precio*cantidad) as importe FROM detalle_pedido WHERE id_pedido=" & id_pedido, conn)
        '   If rs.RecordCount > 0 Then
        '       While Not rs.EOF
        ''          b.AnadirElemento("" & rs.Fields("cantidad").Value & "", " " & rs.Fields("producto").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & FormatCurrency(rs.Fields("importe").Value) & "")
        'rs.MoveNext()
        '      End While
        '     End If
        '     rs.Close()
        '     'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        '     b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        '     b.AnadirTotal("TOTAL-IVA", "" & FormatCurrency(total_iva) & "")
        '     b.AnadirTotal("TOTAL-OTROS", "" & FormatCurrency(total_otros) & "")
        '     b.AnadirTotal("", "-----------")
        '     b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        '     b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

        '     b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        '     b.AnadeLineaAlPie("Entrega: " & agente_entrega & "")
        '     b.AnadeLineaAlPie("")
        '     b.AnadeLineaAlPie("  Recibí producto     Repartidor")
        '      For x = 0 To 2
        '          b.AnadeLineaAlPie("")
        '      Next
        '      b.AnadeLineaAlPie("   ______________     ____________")
        '      b.AnadeLineaAlPie("")
        '      For x = 0 To 2
        '          b.AnadeLineaAlPie("")
        '      Next
        '      b.AnadeLineaAlPie("" & no_copia & "")
        '      b.ImprimeTicket("")
        '--------
        Dim c As ticket = New ticket
        'b.AnadirLineaCabeza("          PAGARE")

        c.HeaderImage = global_logotipo
        c.AnadirLineaCabeza("" & centrar_texto("----------" & no_copia & "----------", cfg_longitud_maxima_ticket, " ") & "")
        c.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                c.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next

        c.AnadirLineaCLiente("" & centrar_texto("PAGARE", cfg_longitud_titulo, " ") & "")
        c.AnadirLineaCLiente("")
        c.AnadirLineaCLiente("" & centrar_texto("CLIENTE: " & cliente, cfg_longitud_titulo, " ") & "")

        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        c.AnadirLineaSubcabeza("")
        Dim letra As String = "(" & Letras(CDbl(total)) & ")"
        c.AnadirLineaSubcabeza("Cliente(alias): " & cliente_alias & "")
        c.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        c.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        c.AnadirLineaSubcabeza("")
        c.AnadirLineaSubcabeza("Por el presente PAGARÉ me obligo  a pagar incondicionalmente  en esta plaza a orden de " & global_razon_social & " el dia ___ de ______________ de 20____la cantidad de " & FormatCurrency(total) & " " + letra + " . Asi como, en caso de no ser cubierta arriba mencionada me comprometo a pagar intereses moratorios al ___% mensual, asi como todos los gastos judiciales y extrajudiciales que erogen para el cobro desde la fecha en que debio ser pagada hasta la total liquidación del adeudo.")
        'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & 
        c.AnadirLineaSubcabeza("")
        c.AnadirLineaSubcabeza("")
        c.AnadirLineaSubcabeza("        NOTA DE VENTA " & id_venta & " " + vbCrLf + "------------------------------------")
        c.AnadirLineaSubcabeza("")
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio
        'Conectar()
        rs.Open("SELECT CONCAT(unidad,'  ',descripcion) as producto , cantidad,precio,(precio*cantidad) as importe FROM venta_detalle WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim importe As String = ""
                If aplicar_redondeo Then
                    importe = FormatCurrency(redondear(FormatNumber(rs.Fields("importe").Value, 2)))
                Else
                    importe = FormatCurrency(FormatNumber(rs.Fields("importe").Value, 2))
                End If
                c.AnadirElemento("" & rs.Fields("cantidad").Value & "", " " & rs.Fields("producto").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & importe & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        c.AnadirTotal("", "")
        c.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        For x = 0 To 2
            c.AnadirTotal("", "")
        Next
        c.AnadeLineaAlPie("Entregó: " & agente_entrega & "")
        c.AnadeLineaAlPie("")
        c.AnadeLineaAlPie("        Nombre y firma ")
        For x = 0 To 4
            c.AnadeLineaAlPie("")
        Next
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        c.AnadeLineaAlPie("     _______________________")
        c.AnadeLineaAlPie("           Cliente ")
        c.AnadeLineaAlPie("")
        c.AnadeLineaAlPie("" & no_copia & "")
        c.ImprimeTicket(conf_impresoras(1))
    End Sub
    Public Sub imprimir_ticket_pedido2(ByVal id_pedido As Integer, Optional ByVal i As Integer = 0)
        Dim subtotal As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim total As Decimal = 0
        Dim fecha As Date
        Dim hora As DateTime
        Dim agente_entrega As String = ""
        Dim no_copia As String = ""
        Dim cliente As String = ""
        Dim cliente_alias As String = ""
        Dim id_venta As Integer = 0
        Dim id_cliente As Integer = 0
        Dim aplicar_redondeo As Boolean = True
        Dim comentarios As String = ""

        rs.Open("SELECT pedido_clientes.id_cliente,pedido_clientes.fecha_entrega,pedido_clientes.num_ticket,pedido_clientes.subtotal,pedido_clientes.iva,pedido_clientes.otros_impuestos,pedido_clientes.total,pedido_clientes.id_venta,pedido_clientes.comentarios,pedido_clientes.id_venta, " & _
                "CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente, " & _
                "CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias " & _
                "FROM cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "JOIN pedido_clientes ON pedido_clientes.id_cliente=cliente.id_cliente " & _
                "WHERE pedido_clientes.id_pedido=" & id_pedido, conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha_entrega").Value
            fecha = rs.Fields("fecha_entrega").Value
            hora = rs.Fields("fecha_entrega").Value
            subtotal = rs.Fields("subtotal").Value
            total_iva = rs.Fields("iva").Value
            total_otros = rs.Fields("otros_impuestos").Value
            total = rs.Fields("total").Value
            cliente = rs.Fields("cliente").Value
            cliente_alias = rs.Fields("cliente_alias").Value
            id_venta = rs.Fields("id_venta").Value
            id_cliente = rs.Fields("id_cliente").Value
            comentarios = rs.Fields("comentarios").Value
        End If
        rs.Close()
       
        EncabezadoConcepto = ""
        '    
        If i = 0 Then
            no_copia = "Original"
        Else
            no_copia = "Copia"
        End If
        aplicar_redondeo = obtener_aplicar_redondeo(id_cliente)
        '--------
        Dim c As ticket = New ticket

        c.AnadirLineaCabeza("" & centrar_texto(fecha.ToLongDateString(), cfg_longitud_titulo, " ") & "")
        c.AnadirLineaCabeza("" & centrar_texto(hora.ToShortTimeString(), cfg_longitud_titulo, " ") & "")

        c.AnadirLineaCLiente("" & centrar_texto("PEDIDO " & id_pedido, cfg_longitud_titulo, " ") & "")
        c.AnadirLineaCLiente("")
        c.AnadirLineaCLiente("")
        c.AnadirLineaCLiente("" & centrar_texto("PARA: " & cliente_alias, cfg_longitud_titulo, " ") & "")
        c.AnadirLineaCLiente("")
        c.AnadirLineaCLiente("")
        c.AnadirLineaCLiente(" CANTIDAD    CODIGO")
        c.AnadirLineaCLiente("")
        rs.Open("SELECT vd.cantidad,p.codigo FROM venta_detalle vd  JOIN producto p ON p.id_producto=vd.id_producto WHERE vd.id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                c.AnadirLineaCLiente(rellenar_texto_derecha(rs.Fields("cantidad").Value, 4) & "   " & rellenar_texto_izquierda(rs.Fields("codigo").Value, 9))
                c.AnadirLineaCLiente("")
                rs.MoveNext()
            End While
        End If
        rs.Close()

        If Trim(comentarios) <> "" Then
            c.AnadeLineaAlPie("═════════ COMENTARIOS ════════════")
            c.AnadeLineaAlPie(comentarios)
            c.AnadeLineaAlPie("══════════════════════════════════")
        End If
        c.AnadeLineaAlPie("" & no_copia & "")
        globa_eliminar_imagen_ticket = True
        c.ImprimeTicket(conf_impresoras(1))
        globa_eliminar_imagen_ticket = False
    End Sub
    Public Sub imprimir_recibo_retiro_termica(ByVal usuario_caja As String, ByVal cantidad_retirada As Decimal, ByVal concepto As String, ByVal i As Integer)
        EncabezadoConcepto = ""
        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto("----------" & no_copia & "----------", cfg_longitud_maxima_ticket, " ") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaCLiente("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        Dim letra As String = "(" & Letras(CDbl(cantidad_retirada)) & ")"
        b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        b.AnadirLineaSubcabeza("Recibí de " & usuario_caja & " la cantidad de " & FormatCurrency(cantidad_retirada) & " " + letra + " por concepto de " & concepto & ". ")
        b.AnadirLineaSubcabeza("")
        'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        For x = 0 To 4
            b.AnadeLineaAlPie("")
        Next
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("     _______________________")
        b.AnadeLineaAlPie("         Nombre y firma ")
        b.AnadeLineaAlPie("")
        ' b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        For x = 0 To 3
            b.AnadeLineaAlPie("")
        Next
    End Sub
    Public Sub imprimir_recibo_retiro_matriz(ByVal usuario_caja As String, ByVal cantidad_retirada As Decimal, ByVal concepto As String, ByVal i As Integer)
        EncabezadoConcepto = ""
        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto("----------" & no_copia & "----------", cfg_longitud_maxima_ticket, " ") & "")
        'b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza("")
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaSubcabeza("")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        Dim letra As String = "(" & Letras(CDbl(cantidad_retirada)) & ")"
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Recibí de " & usuario_caja & "")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("la cantidad de " & FormatCurrency(cantidad_retirada))
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(letra)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("por concepto de " & concepto & ". ")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("     _______________________")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("         Nombre y firma ")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(no_copia)

        ' b.AnadeLineaAlPie("" & no_copia & "")

        ' For x = 0 To 3
        'b.AnadeLineaAlPie("")
        ' Next
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Public Sub reimprimir_recibo_retiro(ByVal id_retiro As Integer, ByVal i As Integer)
        EncabezadoConcepto = ""
        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If
        'obtenemos los datos del retiro---------------------
        Dim cantidad_retirada As Decimal = 0
        Dim concepto As String = 0
        Dim usuario_caja As String = 0
        Dim fecha_retiro As DateTime
        'Conectar()
        rs.Open("SELECT r.*,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado FROM retiros r " & _
                "JOIN empleado e ON e.id_empleado=r.id_empleado JOIN persona p ON p.id_persona=e.id_persona " & _
                "WHERE id_retiro='" & id_retiro & "'", conn)
        If rs.RecordCount > 0 Then
            cantidad_retirada = rs.Fields("cantidad").Value
            concepto = rs.Fields("descripcion").Value
            usuario_caja = rs.Fields("empleado").Value
            fecha_retiro = rs.Fields("fecha").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        '----------------------------------------------------
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto("----------" & no_copia & "----------", cfg_longitud_maxima_ticket, " ") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaCLiente("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        Dim letra As String = "(" & Letras(CDbl(cantidad_retirada)) & ")"
        b.AnadirLineaSubcabeza("" & fecha_retiro.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & fecha_retiro.ToShortTimeString())
        b.AnadirLineaSubcabeza("Recibí de " & usuario_caja & " la cantidad de " & FormatCurrency(cantidad_retirada) & " " + letra + " por concepto de " & concepto & ". ")
        b.AnadirLineaSubcabeza("")
        'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        For x = 0 To 4
            b.AnadeLineaAlPie("")
        Next
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("     _______________________")
        b.AnadeLineaAlPie("         Nombre y firma ")
        b.AnadeLineaAlPie("")
        ' b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        For x = 0 To 3
            b.AnadeLineaAlPie("")
        Next
    End Sub
    Public Function devolver_enteros(ByVal cantidad As Decimal) As Object
        Dim cant As String = cantidad.ToString
        Dim s As String = cantidad.ToString
        s = Right(s, 3)
        If s = "000" Then
            Dim longitud As Integer = Len(cantidad.ToString)
            cant = Mid(cant, 1, longitud - 4)
        End If
        Return cant
    End Function
    Public Function centrar_texto(ByVal cadena As String, ByVal valor_maximo As Integer, simbolo As String) As String
        Dim center_string As String = cadena
        Dim longitud_cadena As Integer = Len(cadena)
        Dim espacios As String = ""
        Dim x As Integer
        If longitud_cadena < valor_maximo Then
            Dim len As Integer = CInt((valor_maximo - longitud_cadena) / 2)
            For x = 1 To len
                espacios += simbolo
            Next
            center_string = espacios & cadena & espacios
        End If
        Return center_string
    End Function
    Public Function rellenar_texto_derecha(ByVal cadena As String, ByVal valor_maximo As Integer) As String
        Dim center_string As String = cadena
        Dim longitud_cadena As Integer = Len(cadena)
        Dim espacios As String = ""
        Dim x As Integer
        If longitud_cadena < valor_maximo Then
            Dim len As Integer = CInt((valor_maximo - longitud_cadena))
            For x = 1 To len
                espacios += " "
            Next
            center_string = cadena & espacios
        Else
            center_string = cadena.Substring(0, valor_maximo)
        End If
        Return center_string
    End Function
    Public Function rellenar_texto_izquierda(ByVal cadena As String, ByVal valor_maximo As Integer) As String
        Dim center_string As String = cadena
        Dim longitud_cadena As Integer = Len(cadena)
        Dim espacios As String = ""
        Dim x As Integer
        If longitud_cadena < valor_maximo Then
            Dim len As Integer = CInt((valor_maximo - longitud_cadena))
            For x = 1 To len
                espacios += " "
            Next
            center_string = espacios & cadena
        End If
        Return center_string
    End Function
    Public Sub imprimir_ticket_venta(ByVal id_venta As Integer, ByVal num_copia As Integer, ByVal total_copias As Integer)
        Dim texto_copia As String = ""

        Dim cliente_alias As String = ""
        Dim cliente As String = ""

        Dim empleado As String = ""
        Dim subtotal As Decimal = 0
        Dim total_impuestos As Decimal = 0
        Dim total As Decimal = 0
        Dim fecha_venta As DateTime

        Dim pago As Decimal = 0
        Dim cambio As Decimal = 0
        Dim tipo_pago As String = ""



        If total_copias > 0 Then
            If num_copia = 0 Then
                texto_copia = "----Cliente----"
            ElseIf num_copia = 1 Then
                texto_copia = "----Establecimiento----"
            Else
                texto_copia = "----Establecimiento " & num_copia & "----"
            End If
        End If
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next

        rs.Open("SELECT CONCAT(pp.nombre,' ',pp.ap_paterno) AS empleado,v.fecha,v.subtotal,v.total_impuestos,v.total,v.cliente_publico_alias,CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente " & _
                "FROM cliente c LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
                "JOIN venta v ON v.id_cliente=c.id_cliente " & _
                "JOIN empleado em ON em.id_empleado=v.id_empleado " & _
                "JOIN persona pp ON pp.id_persona=em.id_persona " & _
                "WHERE v.id_venta=" & id_venta, conn)

        If rs.RecordCount > 0 Then
            While Not rs.EOF
                empleado = rs.Fields("empleado").Value
                fecha_venta = rs.Fields("fecha").Value
                subtotal = rs.Fields("subtotal").Value
                total_impuestos = rs.Fields("total_impuestos").Value
                total = rs.Fields("total").Value
                cliente_alias = rs.Fields("cliente_publico_alias").Value
                cliente = rs.Fields("cliente").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT fp.descripcion AS forma, pv.cobro,pv.cambio FROM pagos_ventas pv " &
                "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
                "WHERE PV.id_venta = " & id_venta, conn)

        If rs.RecordCount > 0 Then
            While Not rs.EOF
                tipo_pago = rs.Fields("forma").Value
                pago = rs.Fields("cobro").Value
                cambio = rs.Fields("cambio").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()




        b.AnadirLineaCLiente("" & centrar_texto("FOLIO: " & global_serie & id_venta, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(cliente_alias, cfg_longitud_titulo, " ") & "")

        b.AnadirLineaSubcabeza("Le atendió: " & empleado & "")
        b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
        b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & "")
        b.AnadirLineaSubcabeza("" & fecha_venta.ToShortDateString & " " & fecha_venta.ToShortTimeString())


        Dim imprime_precios As Boolean = True
        rs.Open("SELECT pc.mostrar_precios FROM cliente_precio pc JOIN venta v ON v.id_cliente=pc.id_cliente WHERE v.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("mostrar_precios").Value = 0 Then
                imprime_precios = False
            End If
        End If
        rs.Close()

        Dim encabezado_productos As String = ""

        If imprime_precios = True Then
            encabezado_productos = centrar_texto("CANTIDAD PRODUCTO IMPORTE", cfg_longitud_maxima_ticket, " ")
        Else
            encabezado_productos = centrar_texto("CANTIDAD PRODUCTO", cfg_longitud_maxima_ticket, " ")
        End If

        b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "-"))
        b.AnadirLineaSubcabeza(encabezado_productos)
        b.AnadirLineaSubcabeza(centrar_texto("", cfg_longitud_maxima_ticket, "-"))

        Dim bandera_descuento As Boolean = False

        rs.Open("Select cantidad, unidad, descripcion, precio, importe " & _
                "FROM venta_detalle " & _
                "WHERE id_venta= " & id_venta, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim cadena As String = rs.Fields("cantidad").Value & " X " & "  " & FormatCurrency(rs.Fields("importe").Value)
                Dim relleno As Integer = cfg_longitud_maxima_ticket - cadena.Length

                If imprime_precios = True Then
                    b.AnadirLineaSubcabeza(rs.Fields("cantidad").Value & " X " & rellenar_texto_derecha(rs.Fields("descripcion").Value, relleno) & "  " & FormatCurrency(rs.Fields("importe").Value))
                Else
                    b.AnadirLineaSubcabeza(rs.Fields("cantidad").Value & " X " & rellenar_texto_derecha(rs.Fields("descripcion").Value, relleno))
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT desc_global_porcent FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("desc_global_porcent").Value > 0 Then
                b.AnadirElemento("", " ", "", "")
                b.AnadirElemento("", rs.Fields("desc_global_porcent").Value & " % Descuento aplicado", "", "")
                bandera_descuento = True
            End If
        End If
        rs.Close()

        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("IMPUESTOS", "" & FormatCurrency(total_impuestos) & "")
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "")
        b.AnadirTotal("", "-----------")
        If bandera_descuento Then
            b.AnadirTotal("DESCUENTO", "" & FormatCurrency(obtener_total_desc_venta(id_venta)) & "")
        End If
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio

        b.AnadirTotal("RECIBIDO", "" & FormatCurrency(pago) & "")
        b.AnadirTotal("CAMBIO", "" & FormatCurrency(cambio) & "")



        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(" " & centrar_texto("SUCURSAL: " & global_nombre_sucursal, cfg_longitud_maxima_ticket, " ") & "")

        For x = 0 To 25
            If Not IsNothing(lineas_ticket_pie(x)) Then
                b.AnadeLineaAlPie(centrar_texto(lineas_ticket_pie(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadeLineaAlPie("" & centrar_texto(texto_copia, cfg_longitud_maxima_ticket, " ") & "")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Public Sub imprimir_ticket_envio_venta(ByVal id_venta As Integer)
        '=================CDIGO DE BARRAS===================
        global_codigo_barra_venta = Nothing
        Dim bm As Bitmap = Nothing
        Dim iHeight As Single = 0
        Dim iType As BarCode.Code128SubTypes = DirectCast([Enum].Parse(GetType(BarCode.Code128SubTypes), "CODE128"), BarCode.Code128SubTypes)
        bm = BarCode.Code128(id_venta, iType, False, 35)
        global_codigo_barra_venta = bm
        '==================================================
        Dim empleado As String = ""
        Dim total As Decimal = 0
        'Conectar()
        rs.Open("SELECT venta.total,CONCAT(persona.nombre,' ',persona.ap_paterno) AS nombre FROM venta JOIN empleado ON empleado.id_empleado=venta.id_empleado JOIN persona ON persona.id_persona=empleado.id_persona WHERE venta.id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            empleado = rs.Fields("nombre").Value
            total = rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '------------------
        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"

        Dim x As ticket = New ticket
        ' x.HeaderImage = Nothing
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        x.AnadirLineaCLiente("" & centrar_texto("FOLIO: " & global_serie & id_venta, cfg_longitud_titulo, " ") & "")
        x.AnadirLineaCLiente("")
        'b.AnadirLineaSubcabeza("")
        x.AnadirLineaSubcabeza("Le atendió: " & empleado & "")
        x.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        x.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
        'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
        'del producto y el tercero es el precio

        Dim imprime_precios As Boolean = True
        rs.Open("SELECT pc.mostrar_precios FROM cliente_precio pc JOIN venta v ON v.id_cliente=pc.id_cliente WHERE v.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("mostrar_precios").Value = 0 Then
                imprime_precios = False
            End If
        End If
        rs.Close()
        If imprime_precios = True Then
            EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Else
            EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
        End If


        Dim bandera_descuento As Boolean = False
        'Conectar()
        rs.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad,venta_detalle.precio,venta_detalle.descuento FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim importe As Decimal = CDec(rs.Fields("cantidad").Value) * CDec(rs.Fields("precio").Value)
                If imprime_precios = True Then
                    x.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & FormatCurrency(redondear(FormatNumber(importe, 2))) & "")
                Else
                    x.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "", "")
                End If

                If rs.Fields("descuento").Value > 0 Then
                    x.AnadirElemento("", " *Producto con " & devolver_enteros(rs.Fields("descuento").Value) & " % desc.", "", "")
                    bandera_descuento = True
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio

        x.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        x.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio
        globa_eliminar_imagen_ticket = True
        global_imprimir_codigo_barras = True
        x.ImprimeTicket(conf_impresoras(0))
        global_imprimir_codigo_barras = False
        globa_eliminar_imagen_ticket = False



    End Sub
    Public Sub imprimir_recibo_prefactura(ByVal id_factura As Integer)

        Dim id_cliente As Integer = 0
        Dim desc_global_porcent As Decimal = 0
        Dim num As String = "000"
        Dim nombre_cliente As String = ""
        Dim cliente_alias As String = ""
        Dim rfc As String = ""
        Dim subtotal As Decimal = 0
        Dim iva As Decimal = 0
        Dim total As Decimal = 0
        Dim total_letras As String = ""
        Dim fecha As Date
        Dim nombre_empleado As String = ""
        Dim id_empleado As Integer = 0
        'Conectar()
        rs.Open("SELECT factura.fecha,factura.subtotal,factura.iva,factura.total,factura.numero,factura.id_empleado,cliente.id_cliente,cliente.id_domicilio, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS alias,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,(SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END as rfc FROM cliente JOIN  factura ON factura.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura.id_factura=" & id_factura & ")As RFC FROM factura JOIN cliente ON factura.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura.id_factura=" & id_factura, conn)
        If rs.RecordCount > 0 Then
            num = Format(rs.Fields("numero").Value, "000")
            id_cliente = rs.Fields("id_cliente").Value
            nombre_cliente = rs.Fields("nombre").Value
            rfc = rs.Fields("rfc").Value
            subtotal = Replace(FormatCurrency(rs.Fields("subtotal").Value), "$", "")
            iva = Replace(FormatCurrency(rs.Fields("iva").Value), "$", "")
            total = Replace(FormatCurrency(rs.Fields("total").Value), "$", "")

            total_letras = Letras(CDbl(rs.Fields("total").Value))
            fecha = rs.Fields("fecha").Value
            id_empleado = rs.Fields("id_empleado").Value
            cliente_alias = rs.Fields("alias").Value
        End If
        rs.Close()
        rs.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado FROM empleado e JOIN persona p ON p.id_persona=e.id_persona WHERE e.id_empleado='" & id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            nombre_empleado = rs.Fields("empleado").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing


        EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, ""))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaCLiente("===========================")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("RECIBO DE PREFACTURACIÓN", 27, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("===========================")
        b.AnadirLineaCLiente("" & centrar_texto("RECIBO: " & num, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto(cliente_alias, cfg_longitud_titulo, " ") & "")
        'b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Elaboró: " & nombre_empleado & "")
        b.AnadirLineaSubcabeza("Cliente: " & nombre_cliente & "")
        b.AnadirLineaSubcabeza(fecha.ToLongDateString)


        'Conectar()
        rs.Open("SELECT factura_detalle.cantidad,factura_detalle.descripcion,factura_detalle.unidad,factura_detalle.precio_unitario,factura_detalle.total_porcent_iva,factura_detalle.total_porcent_otros,factura_detalle.importe, producto.codigo FROM factura_detalle JOIN producto ON producto.id_producto=factura_detalle.id_producto WHERE factura_detalle.id_factura=" & id_factura, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                'rs.Fields("codigo").Value
                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("descripcion").Value & "", "" & FormatCurrency(rs.Fields("precio_unitario").Value) & "", "" & FormatCurrency(rs.Fields("importe").Value) & "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("I.V.A.", "" & FormatCurrency(iva) & "")
        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "-----------")
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio
        b.AnadirTotal("", "") '/Ponemos un total en blanco que sirve de espacio
        b.AnadeLineaAlPie(centrar_texto("( " & total_letras & " )", cfg_longitud_maxima_ticket, " "))
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(" " & centrar_texto("SUCURSAL: " & global_nombre_sucursal, cfg_longitud_maxima_ticket, " ") & "")
        b.AnadeLineaAlPie("")

        b.AnadeLineaAlPie("")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub
    Public Sub imprimir_ticket_credito2(ByVal tipo As String, ByVal id_venta As Integer, ByVal cliente As String, ByVal folio As Integer, ByVal total As Decimal, ByVal empleado As String, ByVal i As Integer)
        Dim id_cliente As Integer = 0
        Dim fecha As DateTime
        'Conectar()
        rs.Open("SELECT fecha,id_cliente FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            fecha = rs.Fields("fecha").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Dim aplicar_redondeo As Boolean = obtener_aplicar_redondeo(id_cliente)

        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        If tipo = "pagare" Then
            Dim b As ticket = New ticket
            'b.AnadirLineaCabeza("          PAGARE")
            b.HeaderImage = global_logotipo
            b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
            b.AnadirLineaCabeza("")
            For x = 0 To 25
                If Not IsNothing(lineas_ticket_cabeza(x)) Then
                    b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
                Else
                    Exit For
                End If
            Next

            b.AnadirLineaCLiente("" & centrar_texto("PAGARE", cfg_longitud_titulo, " ") & "")
            b.AnadirLineaCLiente("")
            b.AnadirLineaCLiente("" & centrar_texto("CLIENTE: " & cliente, cfg_longitud_titulo, " ") & "")

            'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
            'de que al final de cada linea agrega una linea punteada "=========="
            b.AnadirLineaSubcabeza("")
            Dim letra As String = "(" & Letras(CDbl(total)) & ")"
            b.AnadirLineaSubcabeza("" & fecha.ToLongDateString())
            b.AnadirLineaSubcabeza("Hora: " & fecha.ToShortTimeString())
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("Por el presente PAGARÉ me obligo  a pagar incondicionalmente  en esta plaza a orden de " & global_razon_social & " el dia ___ de ______________ de 20____la cantidad de " & FormatCurrency(total) & " " + letra + " . Asi como, en caso de no ser cubierta arriba mencionada me comprometo a pagar intereses moratorios al ___% mensual, asi como todos los gastos judiciales y extrajudiciales que erogen para el cobro desde la fecha en que debio ser pagada hasta la total liquidación del adeudo.")
            'b.AnadirLineaSubcabeza("Cliente: " & cliente & "")
            'b.AnadirLineaSubcabeza("Forma de pago: " & tipo_pago & 
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("         NOTA DE VENTA " & id_venta & " " + vbCrLf + "------------------------------------")
            ' a.AnadirLineaSubcabeza(DateTime.Now.ToShortTimeStr ing())
            'El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
            'del producto y el tercero es el precio
            Dim imprime_precios As Boolean = True
            rs.Open("SELECT pc.mostrar_precios FROM cliente_precio pc JOIN venta v ON v.id_cliente=pc.id_cliente WHERE v.id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                If rs.Fields("mostrar_precios").Value = 0 Then
                    imprime_precios = False
                End If
            End If
            rs.Close()
            If imprime_precios = True Then
                EncabezadoConcepto = "CANT UNIDAD   DESCRIP.        P.UNIT. IMPORTE"
            Else
                EncabezadoConcepto = "CANT UNIDAD   DESCRIP."
            End If

            Dim bandera_descuento As Boolean = False
            'Conectar()
            rs.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad,venta_detalle.precio,venta_detalle.descuento FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim importe As Decimal = CDec(rs.Fields("cantidad").Value) * CDec(rs.Fields("precio").Value)
                    Dim importe_cadena As String = ""
                    If aplicar_redondeo Then
                        importe_cadena = FormatCurrency(redondear(FormatNumber(importe, 2)))
                    Else
                        importe_cadena = FormatCurrency(FormatNumber(importe, 2))
                    End If
                    If imprime_precios = True Then
                        b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "" & rs.Fields("precio").Value & "", "" & importe_cadena & "")
                    Else
                        b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("nombre").Value & "", "", "")
                    End If

                    If rs.Fields("descuento").Value > 0 Then
                        b.AnadirElemento("", " *Producto con " & devolver_enteros(rs.Fields("descuento").Value) & " % desc.", "", "")
                        bandera_descuento = True
                    End If
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            b.AnadirTotal("", "")
            If bandera_descuento Then
                b.AnadirTotal("DESCUENTO", "" & FormatCurrency(obtener_total_desc_venta(id_venta)) & "", 1)
                b.AnadirTotal("", "")
            End If

            b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
            For x = 0 To 2
                b.AnadirTotal("", "")
            Next
            b.AnadeLineaAlPie("        Nombre y firma ")
            For x = 0 To 4
                b.AnadeLineaAlPie("")
            Next
            'b.AnadirTotal("USTED-AHORRO", "0.00")
            '//El metodo AddFooterLine funciona igual que la cabecera
            b.AnadeLineaAlPie("     _______________________")
            b.AnadeLineaAlPie("           Cliente ")
            b.AnadeLineaAlPie("")
            b.AnadeLineaAlPie("" & no_copia & "")
            b.ImprimeTicket(conf_impresoras(0))
            For x = 0 To 3
                b.AnadeLineaAlPie("")
            Next
        End If

    End Sub
    Public Sub imprimir_orden_entrega(ByVal id_venta As Integer, ByVal i As Integer)

        EncabezadoConcepto = ""
        Dim id_cliente As Integer = 0
        Dim aplicar_redondeo As Boolean = False
        Dim no_copia As String
        Dim cliente_razon_social As String = ""
        Dim cliente_alias As String = ""
        Dim domicilio As String = ""

        rs.Open("SELECT fecha,id_cliente FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            cliente_razon_social = rs.Fields("cliente").Value
            cliente_alias = rs.Fields("cliente_alias").Value
        End If
        rs.Close()


        rs.Open("SELECT CONCAT(d.calle,' ',IF(d.cp='','',CONCAT(' C.P. ',d.cp))) domicilio FROM cliente c, domicilio d WHERE  d.id_domicilio=c.id_domicilio AND c.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            domicilio = rs.Fields("domicilio").Value
        End If
        rs.Close()

        aplicar_redondeo = obtener_aplicar_redondeo(id_cliente)

        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next

        b.AnadirLineaCLiente("" & centrar_texto("ORDEN DE ENTREGA", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("NOTA DE VENTA: " & id_venta, cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("CLIENTE: " & cliente_alias, cfg_longitud_titulo, " ") & "")

        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & Date.Today.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora:  " & Date.Now.ToShortTimeString())
        b.AnadirLineaSubcabeza(cliente_razon_social)
        b.AnadirLineaSubcabeza(domicilio)


        Dim bandera_descuento As Boolean = False
        'Conectar()
        rs.Open("SELECT producto.nombre,cantidad,unidad.nombre AS unidad FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(" CANT.    UNID.  DESCRIPCION")
            b.AnadirLineaSubcabeza("")
            While Not rs.EOF
                b.AnadirLineaSubcabeza(" " & rellenar_texto_derecha(rs.Fields("cantidad").Value, 6) & "   " & rellenar_texto_derecha(rs.Fields("unidad").Value, 5) & "  " & rs.Fields("nombre").Value)
                b.AnadirLineaSubcabeza("----------------------------------")
                rs.MoveNext()
            End While
        End If
        rs.Close()


        For x = 0 To 3
            b.AnadeLineaAlPie("")
        Next
        b.AnadeLineaAlPie("  ________________     ______________")
        b.AnadeLineaAlPie("Firma administrativa   Firma de salida")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("")



        b.AnadeLineaAlPie("        Nombre y firma ")
        For x = 0 To 4
            b.AnadeLineaAlPie("")
        Next
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("     _______________________")
        b.AnadeLineaAlPie("Recibí mercancia en buenas condiciones")
        b.AnadeLineaAlPie("           Cliente ")
        b.AnadeLineaAlPie("")

        b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        For x = 0 To 3
            b.AnadeLineaAlPie("")
        Next
    End Sub

    Public Sub imprimir_deposito_caja_termica(ByVal id_deposito_caja As Integer, ByVal i As Integer)
        Dim importe_recibido As Decimal = 0
        Dim concepto_deposito As String = ""
        Dim empleado_caja As String = ""
        Dim fecha_deposito As DateTime
        'Conectar()
        rs.Open("SELECT d.fecha,d.importe,d.descripcion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja FROM depositos d " & _
                "JOIN empleado e ON e.id_empleado=d.id_empleado_caja " & _
                "JOIN persona p ON p.id_persona=e.id_persona " & _
                "WHERE d.id_deposito_caja='" & id_deposito_caja & "'", conn)
        If rs.RecordCount > 0 Then
            importe_recibido = rs.Fields("importe").Value
            If Not IsDBNull(rs.Fields("descripcion").Value()) Then
                concepto_deposito = rs.Fields("descripcion").Value()
            End If
            empleado_caja = rs.Fields("empleado_caja").Value()
            fecha_deposito = rs.Fields("fecha").Value()
        End If
        rs.Close()

        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaCLiente("" & centrar_texto("DEPOSITO EN CAJA", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        b.AnadirLineaCLiente("" & centrar_texto("RECIBO", cfg_longitud_titulo, " ") & "")
        b.AnadirLineaCLiente("")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        Dim letra As String = "(" & Letras(CDbl(importe_recibido)) & ")"
        b.AnadirLineaSubcabeza("" & fecha_deposito.Now.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & fecha_deposito.Now.ToShortTimeString())
        b.AnadirLineaSubcabeza("Recibí  la cantidad de " & FormatCurrency(importe_recibido) & " " + letra + " por concepto de " & concepto_deposito & " ")
        b.AnadirLineaSubcabeza("")

        b.AnadirTotal("TOTAL", "" & FormatCurrency(importe_recibido) & "", 1)
        For x = 0 To 2
            b.AnadirTotal("", "")
        Next
        'El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
        b.AnadeLineaAlPie("        Nombre y firma ")
        For x = 0 To 4
            b.AnadeLineaAlPie("")
        Next
        'b.AnadirTotal("USTED-AHORRO", "0.00")
        '//El metodo AddFooterLine funciona igual que la cabecera
        b.AnadeLineaAlPie("     _______________________")
        b.AnadeLineaAlPie("           Cajero(a) ")
        b.AnadeLineaAlPie("Recibe: " & empleado_caja)
        b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        For x = 0 To 3
            b.AnadeLineaAlPie("")
        Next
    End Sub

    Public Sub imprimir_deposito_caja_matriz(ByVal id_deposito_caja As Integer, ByVal i As Integer)
        Dim importe_recibido As Decimal = 0
        Dim concepto_deposito As String = ""
        Dim empleado_caja As String = ""
        Dim fecha_deposito As DateTime
        'Conectar()
        rs.Open("SELECT d.fecha,d.importe,d.descripcion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja FROM depositos d " & _
                "JOIN empleado e ON e.id_empleado=d.id_empleado_caja " & _
                "JOIN persona p ON p.id_persona=e.id_persona " & _
                "WHERE d.id_deposito_caja='" & id_deposito_caja & "'", conn)
        If rs.RecordCount > 0 Then
            importe_recibido = rs.Fields("importe").Value
            If Not IsDBNull(rs.Fields("descripcion").Value()) Then
                concepto_deposito = rs.Fields("descripcion").Value()
            End If
            empleado_caja = rs.Fields("empleado_caja").Value()
            fecha_deposito = rs.Fields("fecha").Value()
        End If
        rs.Close()

        Dim no_copia As String
        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If
        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
        'b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza("")
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & centrar_texto("DEPOSITO EN CAJA", cfg_longitud_maxima_ticket, " ") & "")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & centrar_texto("RECIBO", cfg_longitud_maxima_ticket, " ") & "")
        'El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
        'de que al final de cada linea agrega una linea punteada "=========="
        b.AnadirLineaSubcabeza("")
        Dim letra As String = "(" & Letras(CDbl(importe_recibido)) & ")"
        b.AnadirLineaSubcabeza("" & fecha_deposito.ToLongDateString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Hora: " & fecha_deposito.ToShortTimeString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Recibí  la cantidad de " & FormatCurrency(importe_recibido))
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(letra)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(" por concepto de " & concepto_deposito & " ")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("        Nombre y firma ")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("..")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("...")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("....")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("     _______________________")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("           Cajero(a) ")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Recibe: " & empleado_caja)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".....")
        b.AnadirLineaSubcabeza("")
        b.AnadeLineaAlPie("" & no_copia & "")
        b.AnadeLineaAlPie("")
        b.ImprimeTicket(conf_impresoras(0))
    End Sub

    Public Sub imprimir_comprobante_pago(ByVal id_pagos_ventas As Integer, ByVal i As Integer)
        EncabezadoConcepto = ""
        Dim id_cliente As Integer = 0
        Dim id_venta As Integer = 0
        Dim aplicar_redondeo As Boolean = False
        Dim no_copia As String
        Dim cliente_razon_social As String = ""
        Dim cliente_alias As String = ""
        Dim domicilio As String = ""
        Dim status_venta As String = ""
        Dim empleado_caja As String = ""
        Dim fecha_cobro As DateTime
        Dim importe As Decimal = 0
        Dim cobro As Decimal = 0
        Dim cambio As Decimal = 0
        Dim id_forma_pago As Integer = 0
        Dim id_apartado As Integer = 0
        Dim id_pedido
        Dim es_abono As Integer = 0
        Dim bandera_descuento As Boolean = False
        Dim total_venta As Decimal = 0
        Dim total_apartado As Decimal = 0
        Dim total_pedido As Decimal = 0

        rs.Open("SELECT pv.es_abono,pv.id_venta,pv.fecha_cobro,pv.importe,pv.cobro,pv.cambio,pv.id_forma_pago,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) as empleado_caja  FROM pagos_ventas pv " &
                "JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                "JOIN persona p ON p.id_persona=e.id_persona " &
                "WHERE pv.id_pagos_ventas='" & id_pagos_ventas & "'", conn)
        If rs.RecordCount > 0 Then
            es_abono = rs.Fields("es_abono").Value
            id_venta = rs.Fields("id_venta").Value
            empleado_caja = rs.Fields("empleado_caja").Value
            fecha_cobro = rs.Fields("fecha_cobro").Value
            id_forma_pago = rs.Fields("id_forma_pago").Value
            importe = rs.Fields("importe").Value
            cobro = rs.Fields("cobro").Value
            cambio = rs.Fields("cambio").Value
        End If
        rs.Close()
        rs.Open("SELECT fecha,id_cliente,status,total FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            status_venta = rs.Fields("status").Value
            total_venta = rs.Fields("total").Value
        End If
        rs.Close()
        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias " &
                  "FROM cliente " &
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " &
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            cliente_razon_social = rs.Fields("cliente").Value
            cliente_alias = rs.Fields("cliente_alias").Value
        End If
        rs.Close()
        rs.Open("SELECT CONCAT(d.calle,' ',IF(d.cp='','',CONCAT(' C.P. ',d.cp))) domicilio FROM cliente c, domicilio d WHERE  d.id_domicilio=c.id_domicilio AND c.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            domicilio = rs.Fields("domicilio").Value
        End If
        rs.Close()

        aplicar_redondeo = obtener_aplicar_redondeo(id_cliente)

        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza("")
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
                'b.AnadirLineaCabeza(lineas_ticket_cabeza(x))
            Else
                Exit For
            End If
        Next
        If conf_pv(20) = 1 Then
            If es_abono = 0 Then
                b.AnadirLineaSubcabeza("COMPROBANTE DE PAGO " & id_pagos_ventas & "")
            ElseIf es_abono = 1 Then
                b.AnadirLineaSubcabeza("RECIBO " & id_pagos_ventas & "")
            End If
            ' b.AnadirLineaCLiente("" & centrar_texto("COMPROBANTE " & id_pagos_ventas, cfg_longitud_titulo) & "")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(FormatCurrency(importe))
            b.AnadirLineaSubcabeza("")

            id_pedido = 0
            id_apartado = 0
            total_apartado = 0
            total_pedido = 0

            rs.Open("SELECT id_apartado,total FROM apartado WHERE id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                id_apartado = rs.Fields("id_apartado").Value
                total_apartado = rs.Fields("total").Value
            End If
            rs.Close()

            rs.Open("SELECT id_pedido,total FROM pedido_clientes WHERE id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                id_pedido = rs.Fields("id_pedido").Value
                total_pedido = rs.Fields("total").Value
            End If
            rs.Close()

            If id_apartado > 0 Then
                b.AnadirLineaSubcabeza("APARTADO: " & id_apartado & "")
            End If

            If id_pedido > 0 Then
                b.AnadirLineaSubcabeza("PEDIDO: " & id_pedido & "")
            End If

            If id_pedido = 0 And id_apartado = 0 Then
                b.AnadirLineaSubcabeza("NOTA DE VENTA: " & id_venta & "")
            End If

            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("CLIENTE: " & cliente_alias & "")
        Else
            If es_abono = 0 Then
                b.AnadirLineaCLiente("" & centrar_texto("COMPROBANTE DE PAGO " & id_pagos_ventas, cfg_longitud_titulo, " ") & "")
            ElseIf es_abono = 1 Then
                b.AnadirLineaCLiente("" & centrar_texto("RECIBO " & id_pagos_ventas, cfg_longitud_titulo, " ") & "")
            End If
            id_pedido = 0
            id_apartado = 0
            total_apartado = 0
            total_pedido = 0

            rs.Open("SELECT id_apartado,total FROM apartado WHERE id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                id_apartado = rs.Fields("id_apartado").Value
                total_apartado = rs.Fields("total").Value
            End If
            rs.Close()

            rs.Open("SELECT id_pedido,total FROM pedido_clientes WHERE id_venta='" & id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                id_pedido = rs.Fields("id_pedido").Value
                total_pedido = rs.Fields("total").Value
            End If
            rs.Close()

            If id_apartado > 0 Then
                b.AnadirLineaCLiente("" & centrar_texto("APARTADO: " & id_apartado, cfg_longitud_titulo, " ") & "")
            End If

            If id_pedido > 0 Then
                b.AnadirLineaCLiente("" & centrar_texto("PEDIDO: " & id_pedido, cfg_longitud_titulo, " ") & "")
            End If

            If id_pedido = 0 And id_apartado = 0 Then
                b.AnadirLineaCLiente("" & centrar_texto("NOTA DE VENTA: " & id_venta, cfg_longitud_titulo, " ") & "")
            End If

            b.AnadirLineaCLiente("")
            b.AnadirLineaCLiente("" & centrar_texto(FormatCurrency(importe), cfg_longitud_titulo, " ") & "")
            b.AnadirLineaCLiente("")
            b.AnadirLineaCLiente("" & centrar_texto("CLIENTE: " & cliente_alias, cfg_longitud_titulo, "") & "")
        End If

        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(cliente_razon_social)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(domicilio)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & fecha_cobro.ToLongDateString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Hora: " & fecha_cobro.ToShortTimeString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Cajero(a): " & empleado_caja)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Forma de pago " & nombre_forma_pago(id_forma_pago))
        b.AnadirLineaSubcabeza("")
        If id_forma_pago = 0 Then ' efectivo
            If status_venta = "CERRADA" Then
                b.AnadirLineaSubcabeza("Recibido:" & FormatCurrency(cobro))
                b.AnadirLineaSubcabeza("")
                b.AnadirLineaSubcabeza("Cambio:" & FormatCurrency(cambio))
            End If
        End If

        If es_abono = 1 Then
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("====================================")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("Recibí de " & cliente_razon_social)
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("la cantidad de " & FormatCurrency(importe))
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("(" & Letras(importe) & ")")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("como abono al nota de venta " & id_venta & " ")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("====================================")

            rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_ventas WHERE id_venta='" & id_venta & "' AND status='ACTIVO' ", conn)
            Dim total_cobrado As Decimal = 0
            If rs.RecordCount > 0 Then
                total_cobrado = CDbl(rs.Fields("total").Value)
            End If
            rs.Close()
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("Saldo: " & FormatCurrency(total_venta - total_cobrado))
        End If
        'Conectar()
        rs.Open("SELECT producto.nombre,cantidad,unidad.nombre AS unidad FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(" CANT.    UNID.  DESCRIPCION")
            b.AnadirLineaSubcabeza("")
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & rellenar_texto_derecha(rs.Fields("cantidad").Value, 5) & " " & rellenar_texto_derecha(rs.Fields("unidad").Value, 4) & " " & rs.Fields("nombre").Value)
                b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("----------------------------------")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        'For x = 0 To 5
        'b.AnadeLineaAlPie("")
        'Next
    End Sub


    Public Sub imprimir_ticket_devolucion_matriz(ByVal id_devolucion As Integer, ByVal i As Integer)
        EncabezadoConcepto = ""

        Dim fecha As DateTime
        Dim total_devolucion As Decimal = 0
        Dim total_venta As Decimal = 0
        Dim cliente_razon_social As String = ""
        Dim cliente_alias As String = ""
        Dim id_venta As Integer = 0
        Dim empleado_caja As String = 0
        Dim aplicar_redondeo As Boolean
        Dim id_cliente As Integer = 0
        Dim no_copia As String = ""
        Dim tipo_devolucion As String = ""



        rs.Open("SELECT d.id_venta,d.fecha,d.total,d.tipo_devolucion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) as empleado  FROM devoluciones d " & _
                "JOIN empleado e ON e.id_empleado=d.id_empleado " & _
                "JOIN persona p ON p.id_persona=e.id_persona " & _
                "WHERE d.id_devolucion='" & id_devolucion & "'", conn)
        If rs.RecordCount > 0 Then
            id_venta = rs.Fields("id_venta").Value
            empleado_caja = rs.Fields("empleado").Value
            fecha = rs.Fields("fecha").Value
            total_devolucion = rs.Fields("total").Value
            id_venta = rs.Fields("id_venta").Value
        End If
        rs.Close()

        rs.Open("SELECT id_cliente,total FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            total_venta = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            cliente_razon_social = rs.Fields("cliente").Value
            cliente_alias = rs.Fields("cliente_alias").Value
        End If
        rs.Close()

        aplicar_redondeo = obtener_aplicar_redondeo(id_cliente)

        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        If total_devolucion <> total_venta Then
            tipo_devolucion = "DEVOLUCION PARCIAL"
        Else
            tipo_devolucion = "DEVOLUCION TOTAL"
        End If


        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        b.AnadirLineaCabeza("" & centrar_texto(no_copia, cfg_longitud_maxima_ticket, "-") & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza("")
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, ""))
                'b.AnadirLineaCabeza(lineas_ticket_cabeza(x))
            Else
                Exit For
            End If
        Next
        If conf_pv(20) = 1 Then

            b.AnadirLineaSubcabeza("DEVOLUCION " & id_devolucion & "")

            ' b.AnadirLineaCLiente("" & centrar_texto("COMPROBANTE " & id_pago_ventas, cfg_longitud_titulo) & "")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(tipo_devolucion)
        b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(FormatCurrency(total_devolucion))
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("(" & Letras(total_devolucion) & ")")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("NOTA DE VENTA: " & id_venta & "")
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("CLIENTE: " & cliente_alias & "")
        Else

            b.AnadirLineaCLiente("" & centrar_texto("DEVOLUCION  " & id_devolucion, cfg_longitud_titulo, " ") & "")

            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(tipo_devolucion)
            b.AnadirLineaSubcabeza("")

            b.AnadirLineaCLiente("" & centrar_texto("NOTA DE VENTA: " & id_venta, cfg_longitud_titulo, " ") & "")

            b.AnadirLineaCLiente("")
            b.AnadirLineaCLiente("" & centrar_texto(FormatCurrency(total_devolucion), cfg_longitud_titulo, " ") & "")
            b.AnadirLineaCLiente("")
            b.AnadirLineaSubcabeza("(" & Letras(total_devolucion) & ")")
            b.AnadirLineaCLiente("")
            b.AnadirLineaCLiente("" & centrar_texto("CLIENTE: " & cliente_alias, cfg_longitud_titulo, " ") & "")
        End If

        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(cliente_razon_social)
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("" & fecha.ToLongDateString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Hora: " & fecha.ToShortTimeString())
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Cajero(a): " & empleado_caja)
        b.AnadirLineaSubcabeza("")
       
        'Conectar()
        rs.Open("SELECT producto.nombre,cantidad,unidad.nombre AS unidad FROM devoluciones_detalle JOIN producto ON producto.id_producto=devoluciones_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE devoluciones_detalle.id_devolucion='" & id_devolucion & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza(" CANT.    UNID.  DESCRIPCION")
            b.AnadirLineaSubcabeza("")
            While Not rs.EOF
                b.AnadirLineaSubcabeza("" & rellenar_texto_derecha(rs.Fields("cantidad").Value, 5) & " " & rellenar_texto_derecha(rs.Fields("unidad").Value, 4) & " " & rs.Fields("nombre").Value)
                b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("----------------------------------")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                'b.AnadirLineaSubcabeza("")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("        Nombre y firma ")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("..")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("...")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("....")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("   ________________   ________________")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("     Recibe             autoriza")
        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza(".....")
        b.AnadirLineaSubcabeza("")
        b.AnadeLineaAlPie("" & no_copia & "")
        b.AnadeLineaAlPie("")
        b.ImprimeTicket(conf_impresoras(0))
        'For x = 0 To 5
        'b.AnadeLineaAlPie("")
        'Next
    End Sub

    Public Sub imprimir_orden_comedor(ByVal id_orden As Integer, ByVal i As Integer)
        EncabezadoConcepto = ""

        Dim id_cliente As Integer = 0
        Dim cuenta As String = ""
        Dim mesero As String
        Dim num_personas As Integer


        Dim aplicar_redondeo As Boolean = False
        Dim no_copia As String
        Dim cliente_razon_social As String = ""

        Dim subtotal As Decimal = 0
        Dim total_impuestos As Decimal = 0
        Dim total As Decimal = 0


        rs.Open("SELECT oc.id_cliente,oc.cuenta,oc.num_personas,m.nombre AS mesero FROM orden_comedor oc " & _
                "JOIN meseros m ON m.id_mesero=oc.id_mesero " & _
                "WHERE oc.id_orden=" & id_orden, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            cuenta = rs.Fields("cuenta").Value
            mesero = rs.Fields("mesero").Value
            num_personas = rs.Fields("num_personas").Value
        End If

        rs.Close()
        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            cliente_razon_social = rs.Fields("cliente").Value
        End If
        rs.Close()

        aplicar_redondeo = obtener_aplicar_redondeo(id_cliente)

        If i = 0 Then
            no_copia = "original"
        Else
            no_copia = "Copia " & i
        End If

        Dim b As ticket = New ticket
        b.HeaderImage = global_logotipo
        'b.AnadirLineaCabeza("" & centrar_texto("----------" & no_copia & "----------", cfg_longitud_maxima_ticket) & "")
        b.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                b.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), cfg_longitud_maxima_ticket, " "))
                'b.AnadirLineaCabeza(lineas_ticket_cabeza(x))
            Else
                Exit For
            End If
        Next



        b.AnadirLineaSubcabeza("")
        b.AnadirLineaSubcabeza("Orden:" & id_orden)
        b.AnadirLineaSubcabeza(cliente_razon_social)
        b.AnadirLineaSubcabeza("Cuenta: " & cuenta)
        b.AnadirLineaSubcabeza("" & Today.ToLongDateString())
        b.AnadirLineaSubcabeza("Hora: " & Today.ToShortTimeString())
        b.AnadirLineaSubcabeza("Mesero : " & mesero)
        b.AnadirLineaSubcabeza("")




        rs.Open("SELECT ocd.descripcion,ocd.cantidad,ocd.unidad,ocd.precio,ocd.importe,ocd.descuento FROM orden_comedor_detalle ocd " & _
                "WHERE ocd.id_orden_comedor='" & id_orden & "'", conn)
        If rs.RecordCount > 0 Then
            b.AnadirLineaSubcabeza("")
            b.AnadirLineaSubcabeza("CANT UNIDAD  DESCRIP.   P.UNIT. IMPORTE")
            b.AnadirLineaSubcabeza("")
            While Not rs.EOF

                b.AnadirElemento("" & devolver_enteros(rs.Fields("cantidad").Value) & "", "" & centrar_texto(rs.Fields("unidad").Value, 5, " ") & " " & rs.Fields("descripcion").Value & "", "" & FormatCurrency(rs.Fields("precio").Value) & "", "" & FormatCurrency(rs.Fields("importe").Value) & "")
                If rs.Fields("descuento").Value > 0 Then
                    b.AnadirElemento("", " *Producto con " & devolver_enteros(rs.Fields("descuento").Value) & " % desc.", "", "")
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  AS subtotal, " & _
                "CASE WHEN SUM(total_iva) IS NULL THEN 0 ELSE SUM(total_iva)  END  AS total_iva, " & _
                "CASE WHEN SUM(total_otros) IS NULL THEN 0 ELSE SUM(total_otros)  END  AS total_otros, " & _
                "CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  AS total " & _
                "FROM(orden_comedor_detalle) " & _
                "WHERE id_orden_comedor='" & id_orden & "'", conn)
        If rs.RecordCount > 0 Then
            subtotal = rs.Fields("subtotal").Value
            total_impuestos = rs.Fields("total_iva").Value + rs.Fields("total_otros").Value
            total = rs.Fields("total").Value
        End If
        rs.Close()



        b.AnadirTotal("SUBTOTAL", "" & FormatCurrency(subtotal) & "")
        b.AnadirTotal("IMPUESTOS", "" & FormatCurrency(total_impuestos) & "")
        b.AnadirTotal("", "-----------")

        b.AnadirTotal("TOTAL", "" & FormatCurrency(total) & "", 1)
        b.AnadirTotal("", "") ' //Ponemos un total en blanco que sirve de espacio


        b.AnadeLineaAlPie("")
        b.AnadeLineaAlPie(" " & centrar_texto("SUCURSAL: " & global_nombre_sucursal, cfg_longitud_maxima_ticket, " ") & "")
        b.AnadeLineaAlPie("")

        For x = 0 To 25
            If Not IsNothing(lineas_ticket_pie(x)) Then
                b.AnadeLineaAlPie(centrar_texto(lineas_ticket_pie(x), cfg_longitud_maxima_ticket, " "))
            Else
                Exit For
            End If
        Next
        'b.AnadeLineaAlPie("" & no_copia & "")
        b.ImprimeTicket(conf_impresoras(0))
        'For x = 0 To 5
        'b.AnadeLineaAlPie("")
        'Next
    End Sub

End Module
