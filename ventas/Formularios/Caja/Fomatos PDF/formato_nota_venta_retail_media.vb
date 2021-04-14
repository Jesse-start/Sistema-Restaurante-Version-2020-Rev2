Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System
Imports System.Math

Module formato_nota_venta_retail_media
    Dim leyenda1 As String = ""
    Dim leyenda2 As String = ""
    Dim leyenda3 As String = ""
    Dim leyenda4 As String = ""
    Dim leyenda5 As String = ""
    Dim matrix_nota_venta(100, 6) As Object
    Dim len_max_fila = Len("CASERO - M Rojo 250 grs CASERO - M Rojo 250 grs CASERO - M Rojo 250 grs")
    Dim lineas_ejecutadas As Integer
    Dim max_lineas As Integer
    Dim mostrar_pagare As Boolean

    '/ 0          / 1       /  2   /3    /    4      /    5         /     6   /
    '/ num_pagina/cantidad/unidad/codigo/descripcion/precio_unitario/importe/

    Public Sub Generar_Formato_venta_retail_media(ByVal id_venta As Integer, ByVal cancelado As Boolean, ByVal regalia As Boolean)
        mostrar_pagare = False
        max_lineas = 0
        lineas_ejecutadas = 0

        'Tryn
        'Intentar generar el documento.
        obtener_leyendas()
        Dim doc As New Document(PageSize.A5.Rotate, 20, 15, 20, 15)
        'Dim doc As New Document(New Rectangle(600.0F, 420.0F), 10, 10, 10, 10)

        Dim filename As String = Application.StartupPath & "\Notas" + "\NOTA_VENTA_" & Format(id_venta, "0000") & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        cargar_matriz_nota_venta(id_venta)
        Dim numero_paginas As Integer = Ceiling(lineas_ejecutadas / max_lineas)
        If numero_paginas > 1 Then
            For x = 1 To numero_paginas
                Generar_pagina(doc, writer, id_venta, -2565928, x, numero_paginas)
            Next
        Else
            Generar_pagina(doc, writer, id_venta, -2565928, 1, 1)
        End If

        'Generar_pagina(doc, writer, id_venta, -2565928, 1, 1)
        doc.Close()
        If cancelado = True Then
            encripta_cancelado(filename, "UKLRQe2610188696")
        End If
        If regalia = True Then
            encripta_regalia(filename, "UKLRQe2610188696")
        End If
        Process.Start(filename)
    End Sub
    Private Sub obtener_leyendas()
        leyenda1 = ""
        rs.Open("SELECT leyenda1,leyenda2,leyenda3,leyenda4,leyenda5 FROM cfg_leyenda_nota WHERE id_cfg_leyenda_nota='1'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("leyenda1").Value) Then
                leyenda1 = rs.Fields("leyenda1").Value
            End If
            If Not IsDBNull(rs.Fields("leyenda2").Value) Then
                leyenda2 = rs.Fields("leyenda2").Value
            End If
            If Not IsDBNull(rs.Fields("leyenda3").Value) Then
                leyenda3 = rs.Fields("leyenda3").Value
            End If
            If Not IsDBNull(rs.Fields("leyenda4").Value) Then
                leyenda4 = rs.Fields("leyenda4").Value
            End If
            If Not IsDBNull(rs.Fields("leyenda5").Value) Then
                leyenda5 = rs.Fields("leyenda5").Value
            End If
        End If
        rs.Close()
    End Sub
    Private Sub cargar_matriz_nota_venta(ByVal id_venta As Integer)
        limpiar_matriz_nota_venta()
        lineas_ejecutadas = 0

        rs.Open("SELECT status FROM venta WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("status").Value = "PENDIENTE" Then
                mostrar_pagare = True
            End If
        End If
        rs.Close()
        If mostrar_pagare = True Then
            max_lineas = 5
        Else
            max_lineas = 10
        End If

        Dim w As Integer = 0
        rs.Open("SELECT p.codigo,vd.cantidad,vd.precio,vd.descripcion,vd.unidad,vd.importe,vd.tasa_impuestos,vd.total_impuestos FROM venta_detalle vd JOIN producto p ON p.id_producto=vd.id_producto WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                matrix_nota_venta(w, 1) = rs.Fields("cantidad").Value
                matrix_nota_venta(w, 2) = rs.Fields("unidad").Value
                matrix_nota_venta(w, 3) = rs.Fields("codigo").Value
                matrix_nota_venta(w, 4) = rs.Fields("descripcion").Value
                matrix_nota_venta(w, 5) = Math.Round(rs.Fields("precio").Value * (1 + rs.Fields("tasa_impuestos").Value), 2)
                matrix_nota_venta(w, 6) = rs.Fields("importe").Value + rs.Fields("total_impuestos").Value

                lineas_ejecutadas = lineas_ejecutadas + Ceiling(Len(rs.Fields("descripcion").Value) / len_max_fila)
                matrix_nota_venta(w, 0) = Ceiling(lineas_ejecutadas / max_lineas)
                w = w + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT id_apartado,comentarios,fecha_entrega FROM apartado WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("comentarios").Value) Then
                If Trim(rs.Fields("comentarios").Value) <> "" Then
                    matrix_nota_venta(w, 1) = " "
                    matrix_nota_venta(w, 2) = " "
                    matrix_nota_venta(w, 3) = " "
                    matrix_nota_venta(w, 4) = UCase(rs.Fields("comentarios").Value)
                    matrix_nota_venta(w, 5) = " "
                    matrix_nota_venta(w, 6) = " "
                End If

                lineas_ejecutadas = lineas_ejecutadas + Ceiling(Len(rs.Fields("comentarios").Value) / len_max_fila)
                matrix_nota_venta(w, 0) = Ceiling(lineas_ejecutadas / max_lineas)
            End If
        End If
        rs.Close()
        '/ 0          / 1       /  2   /3    /    4      /    5         /     6   /
        '/ num_pagina/cantidad/unidad/codigo/descripcion/precio_unitario/importe/
    End Sub
    Private Sub limpiar_matriz_nota_venta()
        For x = 0 To 100
            For j = 0 To 6
                matrix_nota_venta(x, j) = Nothing
            Next
        Next
    End Sub

    Public Sub Generar_pagina(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_venta As Integer, ByVal color_fondo As String, ByVal num_pagina As Integer, ByVal total_paginas As Integer)

        Dim nombre_cliente As String = ""
        Dim direccion_cliente As String = ""
        Dim ciudad_cliente As String = ""
        Dim telefono_fijo_cliente As String = ""
        Dim telefono_cel_cliente As String = ""
        Dim whatsapp_cliente As String = ""
        Dim email_cliente As String = ""
        Dim vendedor As String = ""
        Dim modalidad_compra As String = ""
        Dim tiempo_apartado As String = ""
        Dim forma_pago_enganche As String = ""
        Dim enganche As Decimal = 0
        Dim referencia As String = ""
        Dim saldo As String = ""
        Dim total_venta As Decimal = 0
        Dim fecha_venta As DateTime
        Dim serie_venta As String = global_serie
        Dim fecha_entrega As DateTime
        Dim id_cliente As Integer = 0
        Dim id_domicilio As Integer = 0
        Dim id_apartado As Integer = 0
        Dim id_pedido As Integer = 0
        Dim estatus_venta As String = ""
        Dim descuento_global_porcentual As Decimal = 0
        Dim descuento_global_importe As Decimal = 0
        Dim leyenda_descuento As String = ""
        Dim cliente_publico_alias As String = ""

        Dim rw As New ADODB.Recordset


        rs.Open("SELECT venta.fecha,venta.id_cliente,venta.desc_global_porcent,venta.desc_global_importe,venta.cliente_publico_alias,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado_venta,venta.total,venta.status " & _
                "FROM venta JOIN empleado ON empleado.id_empleado=venta.id_empleado " & _
                "JOIN persona ON persona.id_persona=empleado.id_persona WHERE venta.id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            fecha_venta = rs.Fields("fecha").Value
            vendedor = rs.Fields("empleado_venta").Value
            total_venta = rs.Fields("total").Value
            estatus_venta = rs.Fields("status").Value
            descuento_global_porcentual = rs.Fields("desc_global_porcent").Value
            descuento_global_importe = rs.Fields("desc_global_importe").Value
            cliente_publico_alias = rs.Fields("cliente_publico_alias").Value
        End If
        rs.Close()

        If descuento_global_porcentual > 0 Then
            leyenda_descuento = "Descuento especial del " & descuento_global_porcentual & "% "
        End If


        If descuento_global_importe > 0 Then
            leyenda_descuento = "Descuento especial de " & FormatCurrency(descuento_global_importe)
        End If


        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            nombre_cliente = rs.Fields("cliente").Value
        End If
        rs.Close()
        If id_cliente = 1 Then
            nombre_cliente = cliente_publico_alias
        End If

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.email ELSE persona.email END AS email,CASE WHEN cliente.id_persona = 0 THEN  empresa.tel_fijo ELSE persona.tel_fijo END AS telefono_fijo,CASE WHEN cliente.id_persona = 0 THEN  empresa.tel_cel ELSE persona.tel_cel END AS telefono_celular,CASE WHEN cliente.id_persona = 0 THEN  empresa.whatsapp ELSE persona.whatsapp END AS whatsapp " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            email_cliente = rs.Fields("email").Value
            telefono_fijo_cliente = rs.Fields("telefono_fijo").Value
            telefono_cel_cliente = rs.Fields("telefono_celular").Value
            whatsapp_cliente = rs.Fields("whatsapp").Value
        End If
        rs.Close()



        rs.Open("SELECT id_domicilio FROM cliente WHERE id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            id_domicilio = rs.Fields("id_domicilio").Value

        End If
        rs.Close()

        rs.Open("SELECT Concat(calle,' ',num_ext,' ',' ',num_int,', ',colonia,', ',municipio,', ',if(cp='','',concat(' C.P. ',cp)) ) domicilio, CONCAT(poblacion,', ',estado,', ',pais) AS ciudad FROM domicilio WHERE id_domicilio='" & id_domicilio & "'", conn)
        If rs.RecordCount > 0 Then
            direccion_cliente = rs.Fields("domicilio").Value
            ciudad_cliente = rs.Fields("ciudad").Value
        End If
        rs.Close()

        rs.Open("SELECT id_apartado,fecha_entrega FROM apartado WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            id_apartado = rs.Fields("id_apartado").Value
            fecha_entrega = rs.Fields("fecha_entrega").Value
        End If
        rs.Close()

        rs.Open("SELECT id_pedido,fecha_entrega FROM pedido_clientes WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            id_pedido = rs.Fields("id_pedido").Value
            fecha_entrega = rs.Fields("fecha_entrega").Value
        End If
        rs.Close()

        If id_apartado <> 0 Then
            modalidad_compra = "APARTADO " & id_apartado
            tiempo_apartado = DateDiff(DateInterval.Day, fecha_venta, fecha_entrega) & " dias "
        ElseIf id_pedido <> 0 Then
            modalidad_compra = "PEDIDO  " & id_pedido
        Else
            If estatus_venta = "CERRADA" Then
                modalidad_compra = "VENTA EN EXISTENCIA"
            ElseIf estatus_venta = "PENDIENTE" Then
                modalidad_compra = "VENTA A CREDITO"
            End If
        End If

        rs.Open("SELECT pv.importe,fp.nombre AS forma_pago,fecha,num_autorizacion " &
                "FROM pagos_ventas pv " &
                "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
                "WHERE pv.id_venta='" & id_venta & "' AND pv.status='ACTIVO' ORDER BY pv.fecha ASC LIMIT 1", conn)
        If rs.RecordCount > 0 Then
            forma_pago_enganche = rs.Fields("Forma_pago").Value
            enganche = rs.Fields("importe").Value
            If Not IsDBNull(rs.Fields("num_autorizacion").Value) Then
                referencia = rs.Fields("num_autorizacion").Value
            End If
        End If
        rs.Close()

        Dim total_abonos As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total_abonos " & _
              "FROM pagos_ventas  " & _
              "WHERE id_venta='" & id_venta & "' AND status='ACTIVO'", conn)
        If rs.RecordCount > 0 Then
            total_abonos = rs.Fields("total_abonos").Value
        End If
        rs.Close()


        saldo = FormatCurrency(total_venta - total_abonos)
        '=======================================================================================================
        '                                        TABLA DE NOTA DE VENTA
        '======================================================================================================

        Dim logo As iTextSharp.text.Image
        logo = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\logo.png")
        logo.ScaleAbsoluteWidth(100)
        logo.ScaleAbsoluteHeight(50)

        Dim NOTA As New PdfPTable(9)
        NOTA.SetWidthPercentage({60, 60, 80, 120, 80, 55, 50, 50, 50}, document.PageSize)


        Dim A1 As New PdfPCell(logo)
        A1.Border = Nothing
        A1.Rowspan = 4
        A1.Colspan = 2
        A1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(A1)

        Dim A2 As New PdfPCell(New Paragraph(leyenda1, FontFactory.GetFont("Arial", 9, Font.BOLD)))
        A2.Border = Nothing
        A2.Rowspan = 4
        A2.Colspan = 2
        A2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(A2)

        Dim A4 As New PdfPCell(New Paragraph(" Sucursal", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        A4.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        A4.MinimumHeight = 15
        A4.Colspan = 2
        A4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(A4)

        Dim A6 As New PdfPCell(New Paragraph(" NOTA DE VENTA", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        A6.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        A6.Colspan = 3
        A6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(A6)

        Dim B4 As New PdfPCell(New Paragraph(global_nombre_sucursal, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        B4.MinimumHeight = 15
        B4.Colspan = 2
        B4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(B4)

        Dim B6 As New PdfPCell(New Paragraph(serie_venta & " " & Format(id_venta, "0000"), FontFactory.GetFont("Arial", 10, Font.BOLD)))
        B6.Colspan = 3
        B6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(B6)

        Dim C4 As New PdfPCell(New Paragraph("Hoja " & num_pagina & " de " & total_paginas, FontFactory.GetFont("Arial", 9, Font.NORMAL))) 'leyenda 1
        C4.MinimumHeight = 15
        C4.Border = Nothing
        C4.Colspan = 2
        C4.PaddingTop = 10
        C4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(C4)

        Dim C6 As New PdfPCell(New Paragraph("FECHA", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        C6.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        C6.Colspan = 3
        C6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(C6)

        Dim D4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.NORMAL))) ' leyenda 2
        D4.MinimumHeight = 15
        D4.Border = Nothing
        D4.Colspan = 2
        D4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D4)

        Dim D6 As New PdfPCell(New Paragraph(fecha_venta.Day, FontFactory.GetFont("Arial", 9, Font.BOLD)))
        D6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D6)

        Dim D7 As New PdfPCell(New Paragraph(fecha_venta.Month, FontFactory.GetFont("Arial", 9, Font.BOLD)))
        D7.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D7)

        Dim D8 As New PdfPCell(New Paragraph(fecha_venta.Year, FontFactory.GetFont("Arial", 9, Font.BOLD)))
        D8.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D8)


        'Dim E1 As New PdfPCell(New Paragraph("EL Trópico" & vbCrLf & _
        '"Materiales para Construcción" & vbCrLf & _
        '"Carretera a Puerto Angel Km 6.5, San Agustín de las Juntas, Oaxaca, Oax. C.P. 71260" & vbCrLf & _
        '"Tel:. 14 381 44 Email:eltropicomateriales@gmail.com", FontFactory.GetFont("Arial", 9, Font.BOLD)))
        'E1.Border = Nothing
        'E1.Colspan = 7
        'E1.MinimumHeight = 50
        'E1.HorizontalAlignment = Element.ALIGN_LEFT
        'NOTA.AddCell(E1)

        ' Dim E7 As New PdfPCell(New Paragraph(" " & vbCrLf & _
        '                                     "" & vbCrLf & _
        '                                     " " & vbCrLf & _
        '                                     " " & vbCrLf & _
        '                                     " " & vbCrLf & _
        '                                     "", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        'E7.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        'E7.Border = Nothing
        'E7.Colspan = 2
        'E7.MinimumHeight = 60
        'E7.HorizontalAlignment = Element.ALIGN_CENTER
        'NOTA.AddCell(E7)

        Dim F1 As New PdfPCell(New Paragraph("NOMBRE :", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        F1.Colspan = 2
        F1.BorderWidthTop = 1
        F1.BorderWidthLeft = 1
        F1.BorderWidthBottom = 0.1
        F1.BorderWidthRight = 0
        F1.MinimumHeight = 15
        'F1.PaddingTop = 7
        F1.PaddingLeft = 7
        F1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F1)

        Dim F2 As New PdfPCell(New Paragraph(nombre_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        F2.Colspan = 3
        F2.BorderWidthTop = 1
        F2.BorderWidthLeft = 0
        F2.BorderWidthBottom = 0.1
        F2.BorderWidthRight = 0
        'F2.PaddingTop = 7
        F2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F2)

        Dim F5 As New PdfPCell(New Paragraph("TEL:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        F5.BorderWidthTop = 1
        F5.BorderWidthLeft = 1
        F5.BorderWidthBottom = 0.1
        F5.BorderWidthRight = 0
        'F5.PaddingTop = 7
        F5.PaddingLeft = 7
        F5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F5)

        Dim F6 As New PdfPCell(New Paragraph(telefono_fijo_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        F6.Colspan = 3
        F6.BorderWidthRight = 1
        F6.BorderWidthLeft = 0
        F6.BorderWidthBottom = 0.1
        F6.BorderWidthTop = 1
        'F6.PaddingTop = 7
        F6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F6)

        Dim G1 As New PdfPCell(New Paragraph("DIRECCION:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        G1.Colspan = 2
        G1.BorderWidthLeft = 1
        G1.BorderWidthTop = 0.1
        G1.BorderWidthBottom = 0
        G1.BorderWidthRight = 0
        G1.MinimumHeight = 15
        'G1.PaddingTop = 7
        G1.PaddingLeft = 7
        G1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(G1)

        Dim G2 As New PdfPCell(New Paragraph(direccion_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        G2.Colspan = 3
        G2.Rowspan = 2
        G2.BorderWidthLeft = 0
        G2.BorderWidthTop = 0.1
        G2.BorderWidthRight = 0
        G2.BorderWidthBottom = 0.1
        G2.MinimumHeight = 30
        'G2.PaddingTop = 7
        G2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(G2)

        Dim G5 As New PdfPCell(New Paragraph("CEL:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        G5.BorderWidthLeft = 1
        G5.BorderWidthRight = 0
        G5.BorderWidthBottom = 0.1
        G5.BorderWidthTop = 0.1
        'G5.PaddingTop = 7
        G5.PaddingLeft = 7
        G5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(G5)

        Dim G6 As New PdfPCell(New Paragraph(telefono_cel_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        G6.Colspan = 3
        G6.BorderWidthRight = 1
        G6.BorderWidthBottom = 0.1
        G6.BorderWidthTop = 0.1
        G6.BorderWidthLeft = 0
        'G6.PaddingTop = 7
        G6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(G6)

        Dim H1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        H1.Colspan = 2
        H1.BorderWidthLeft = 1
        H1.BorderWidthTop = 0
        H1.BorderWidthRight = 0
        H1.BorderWidthBottom = 0.1
        H1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(H1)

        Dim H5 As New PdfPCell(New Paragraph("EMAIL:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        H5.BorderWidthLeft = 1
        H5.BorderWidthTop = 0.1
        H5.BorderWidthRight = 0
        H5.BorderWidthBottom = 0.1
        ' H5.PaddingTop = 7
        H5.PaddingLeft = 7
        H5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(H5)

        Dim H6 As New PdfPCell(New Paragraph(email_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        H6.Colspan = 3
        H6.BorderWidthRight = 1
        H6.BorderWidthLeft = 0
        H6.BorderWidthTop = 0.1
        H6.BorderWidthBottom = 0.1
        'H6.PaddingTop = 7
        H6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(H6)

        Dim I1 As New PdfPCell(New Paragraph("CIUDAD:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        I1.Colspan = 2
        I1.BorderWidthBottom = 1
        I1.BorderWidthLeft = 1
        I1.BorderWidthTop = 0.1
        I1.BorderWidthRight = 0
        I1.MinimumHeight = 15
        'I1.PaddingTop = 7
        I1.PaddingLeft = 7
        I1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I1)

        Dim I2 As New PdfPCell(New Paragraph(ciudad_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        I2.Colspan = 3
        I2.BorderWidthBottom = 1
        I2.BorderWidthRight = 0
        I2.BorderWidthTop = 0.1
        I2.BorderWidthLeft = 0
        'I2.PaddingTop = 7
        I2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I2)

        Dim I5 As New PdfPCell(New Paragraph("WhatsApp:", FontFactory.GetFont("Arial", 7, Font.BOLD)))
        I5.BorderWidthLeft = 1
        I5.BorderWidthBottom = 1
        I5.BorderWidthTop = 0.1
        I5.BorderWidthRight = 0
        'I5.PaddingTop = 7
        I5.PaddingLeft = 7
        I5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I5)

        Dim I6 As New PdfPCell(New Paragraph(whatsapp_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        I6.Colspan = 3
        I6.BorderWidthBottom = 1
        I6.BorderWidthRight = 1
        I6.BorderWidthLeft = 0
        I6.BorderWidthTop = 0.1
        'I6.PaddingTop = 7
        I6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I6)

        Dim J1 As New PdfPCell(New Paragraph("VENDEDOR:", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        J1.Border = Nothing
        J1.MinimumHeight = 15
        J1.PaddingTop = 5
        J1.PaddingBottom = 5
        J1.Colspan = 2
        J1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J1)

        Dim J2 As New PdfPCell(New Paragraph(vendedor, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        J2.Border = Nothing
        J2.PaddingTop = 5
        J2.PaddingBottom = 5
        J2.Colspan = 2
        J2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J2)

        Dim J4 As New PdfPCell(New Paragraph("MODALIDAD:", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        J4.Border = Nothing
        J4.PaddingTop = 5
        J4.PaddingBottom = 5
        J4.Colspan = 2
        J4.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J4)

        Dim J6 As New PdfPCell(New Paragraph(modalidad_compra, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        J6.Border = Nothing
        J6.PaddingTop = 5
        J6.PaddingBottom = 5
        J6.Colspan = 3
        J6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J6)

        Dim L1 As New PdfPCell(New Paragraph("CANT.", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L1.BorderWidthRight = 0.1
        L1.BorderWidthBottom = 1
        L1.BorderWidthLeft = 1
        L1.BorderWidthTop = 1
        L1.PaddingTop = 2
        L1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L1.MinimumHeight = 15
        L1.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L1)

        Dim L1A As New PdfPCell(New Paragraph("CODIGO", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L1A.BorderWidthRight = 0
        L1A.BorderWidthBottom = 1
        L1A.BorderWidthLeft = 0.1
        L1A.BorderWidthTop = 1
        L1A.PaddingTop = 2
        L1A.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L1A.Colspan = 1
        L1A.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L1A)

        Dim L1B As New PdfPCell(New Paragraph("DESCRIPCION", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L1B.BorderWidthRight = 0
        L1B.BorderWidthBottom = 1
        L1B.BorderWidthLeft = 0.1
        L1B.BorderWidthTop = 1
        L1B.PaddingTop = 2
        L1B.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L1B.Colspan = 2
        L1B.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L1B)

        Dim L4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 5, Font.BOLD)))
        L4.BorderWidthRight = 0
        L4.BorderWidthBottom = 1
        L4.BorderWidthLeft = 0
        L4.BorderWidthTop = 1
        L4.PaddingTop = 2
        L4.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L4)

        Dim L5 As New PdfPCell(New Paragraph("PRECIO UNITARIO", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L5.BorderWidthRight = 0.1
        L5.BorderWidthBottom = 1
        L5.BorderWidthLeft = 0.1
        L5.BorderWidthTop = 1
        L5.PaddingTop = 2
        L5.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L5.Colspan = 2
        L5.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L5)

        Dim L6 As New PdfPCell(New Paragraph("IMPORTE", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L6.BorderWidthRight = 1
        L6.BorderWidthBottom = 1
        L6.BorderWidthLeft = 0.1
        L6.BorderWidthTop = 1
        L6.PaddingTop = 2
        L6.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L6.Colspan = 2
        L6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L6)
        '/ 0          / 1       /  2   /3    /    4      /    5         /     6   /
        '/ num_pagina/cantidad/unidad/codigo/descripcion/precio_unitario/importe/

        Dim filas_ejecutadas As Integer = 0
        Dim filas_xejecutar As Decimal = 0

        For w = 0 To 100
            If Not IsNothing(matrix_nota_venta(w, 0)) Then
                If matrix_nota_venta(w, 0) = num_pagina Then

                    Dim filas_requerida As Integer = Ceiling(Len(matrix_nota_venta(w, 4)) / len_max_fila)
                    filas_ejecutadas = filas_ejecutadas + filas_requerida

                    Dim P1 As New PdfPCell(New Paragraph(matrix_nota_venta(w, 1), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                    P1.BorderWidthRight = 0.1
                    P1.BorderWidthBottom = 0
                    P1.BorderWidthLeft = 1
                    P1.BorderWidthTop = 0
                    P1.HorizontalAlignment = Element.ALIGN_CENTER
                    P1.MinimumHeight = 10 * filas_requerida
                    NOTA.AddCell(P1)

                    Dim P1A As New PdfPCell(New Paragraph(matrix_nota_venta(w, 3), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                    P1A.BorderWidthRight = 0
                    P1A.BorderWidthBottom = 0
                    P1A.BorderWidthLeft = 0.1
                    P1A.BorderWidthTop = 0
                    P1A.HorizontalAlignment = Element.ALIGN_CENTER
                    P1A.MinimumHeight = 10 * filas_requerida
                    NOTA.AddCell(P1A)

                    Dim P1B As New PdfPCell(New Paragraph(matrix_nota_venta(w, 4), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                    P1B.BorderWidthRight = 0
                    P1B.BorderWidthBottom = 0
                    P1B.BorderWidthLeft = 0.1
                    P1B.BorderWidthTop = 0
                    P1B.PaddingLeft = 5
                    P1B.Colspan = 3
                    P1B.HorizontalAlignment = Element.ALIGN_LEFT
                    NOTA.AddCell(P1B)

                    Dim P5 As New PdfPCell(New Paragraph(matrix_nota_venta(w, 5), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                    P5.BorderWidthRight = 0.1
                    P5.BorderWidthBottom = 0
                    P5.BorderWidthLeft = 0.1
                    P5.BorderWidthTop = 0
                    P5.Colspan = 2
                    P5.HorizontalAlignment = Element.ALIGN_CENTER
                    NOTA.AddCell(P5)

                    Dim P6 As New PdfPCell(New Paragraph(matrix_nota_venta(w, 6), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                    P6.BorderWidthRight = 1
                    P6.BorderWidthBottom = 0
                    P6.BorderWidthLeft = 0.1
                    P6.BorderWidthTop = 0
                    P6.PaddingRight = 10
                    P6.Colspan = 2
                    P6.HorizontalAlignment = Element.ALIGN_RIGHT
                    NOTA.AddCell(P6)


                End If
            End If

        Next
        If num_pagina = total_paginas Then
            filas_xejecutar = max_lineas - filas_ejecutadas
            If filas_xejecutar > 0 Then
                For x = 1 To filas_xejecutar
                    Dim P1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                    P1.BorderWidthRight = 0.1
                    P1.BorderWidthBottom = 0
                    P1.BorderWidthLeft = 1
                    P1.BorderWidthTop = 0
                    P1.HorizontalAlignment = Element.ALIGN_CENTER
                    P1.MinimumHeight = 12
                    NOTA.AddCell(P1)

                    Dim P1B As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                    P1B.BorderWidthRight = 0
                    P1B.BorderWidthBottom = 0
                    P1B.BorderWidthLeft = 0.1
                    P1B.BorderWidthTop = 0
                    P1B.PaddingLeft = 5
                    P1B.Colspan = 4
                    P1B.HorizontalAlignment = Element.ALIGN_LEFT
                    NOTA.AddCell(P1B)

                    Dim P5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                    P5.BorderWidthRight = 0.1
                    P5.BorderWidthBottom = 0
                    P5.BorderWidthLeft = 0.1
                    P5.BorderWidthTop = 0
                    P5.Colspan = 2
                    P5.HorizontalAlignment = Element.ALIGN_CENTER
                    NOTA.AddCell(P5)

                    Dim P6 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                    P6.BorderWidthRight = 1
                    P6.BorderWidthBottom = 0
                    P6.BorderWidthLeft = 0.1
                    P6.BorderWidthTop = 0
                    P6.PaddingRight = 10
                    P6.Colspan = 2
                    P6.HorizontalAlignment = Element.ALIGN_RIGHT
                    NOTA.AddCell(P6)
                Next
            End If
        End If


        Dim S1 As New PdfPCell(New Paragraph("FORMA DE PAGO:", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        S1.Colspan = 2
        S1.MinimumHeight = 20
        S1.BorderWidthRight = 0
        S1.BorderWidthBottom = 0
        S1.BorderWidthLeft = 1
        S1.BorderWidthTop = 0.1
        S1.HorizontalAlignment = Element.ALIGN_RIGHT
        NOTA.AddCell(S1)

        Dim S2 As New PdfPCell(New Paragraph(forma_pago_enganche, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        S2.BorderWidthRight = 0
        S2.BorderWidthBottom = 0
        S2.BorderWidthLeft = 0
        S2.BorderWidthTop = 0.1
        S2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(S2)

        Dim S3 As New PdfPCell(New Paragraph("SU PAGO:", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC))) ' enganche
        S3.BorderWidthRight = 0
        S3.BorderWidthBottom = 0
        S3.BorderWidthLeft = 0
        S3.BorderWidthTop = 0.1
        S3.HorizontalAlignment = Element.ALIGN_RIGHT
        NOTA.AddCell(S3)

        Dim S4 As New PdfPCell(New Paragraph(FormatCurrency(enganche) & " (Abonos:" & FormatCurrency(total_abonos - enganche) & ")", FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        S4.BorderWidthRight = 0.1
        S4.BorderWidthBottom = 0
        S4.BorderWidthLeft = 0
        S4.BorderWidthTop = 0.1
        S4.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(S4)
        If leyenda_descuento = "" Then
            Dim S5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
            S5.Colspan = 2
            S5.Rowspan = 2
            S5.BorderWidthRight = 0.1
            S5.BorderWidthBottom = 0
            S5.BorderWidthLeft = 0
            S5.BorderWidthTop = 0
            S5.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(S5)

            Dim S7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
            S7.Rowspan = 2
            S7.BorderWidthRight = 1
            S7.BorderWidthBottom = 0
            S7.BorderWidthLeft = 0.1
            S7.BorderWidthTop = 0
            S7.Colspan = 2
            S7.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(S7)
        Else
            Dim S5 As New PdfPCell(New Paragraph(leyenda_descuento, FontFactory.GetFont("Arial", 8, Font.BOLD)))
            S5.Colspan = 4
            S5.Rowspan = 2
            S5.BorderWidthRight = 0.1
            S5.BorderWidthBottom = 0
            S5.BorderWidthLeft = 0
            S5.BorderWidthTop = 0
            S5.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(S5)
        End If


        Dim T1 As New PdfPCell(New Paragraph("REFERENCIA: ", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        T1.Colspan = 2
        T1.MinimumHeight = 20
        T1.BorderWidthRight = 0
        T1.BorderWidthBottom = 0
        T1.BorderWidthLeft = 1
        T1.BorderWidthTop = 0
        T1.HorizontalAlignment = Element.ALIGN_RIGHT
        NOTA.AddCell(T1)

        Dim T2 As New PdfPCell(New Paragraph(referencia, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        T2.BorderWidthRight = 0
        T2.BorderWidthBottom = 0
        T2.BorderWidthLeft = 0
        T2.BorderWidthTop = 0
        T2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(T2)

        Dim T3 As New PdfPCell(New Paragraph("RESTA: ", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        T3.BorderWidthRight = 0
        T3.BorderWidthBottom = 0
        T3.BorderWidthLeft = 0
        T3.BorderWidthTop = 0
        T3.HorizontalAlignment = Element.ALIGN_RIGHT
        NOTA.AddCell(T3)

        Dim T4 As New PdfPCell(New Paragraph(saldo, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        T4.BorderWidthRight = 0.1
        T4.BorderWidthBottom = 0
        T4.BorderWidthLeft = 0
        T4.BorderWidthTop = 0
        T4.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(T4)

        Dim total_letras As String = ""
        If num_pagina = total_paginas Then
            total_letras = Letras(total_venta)
        End If

        Dim V1 As New PdfPCell(New Paragraph(total_letras, FontFactory.GetFont("Arial", 8, Font.BOLD))) ' leyenda atencion a clientes
        V1.BorderWidthRight = 0.1
        V1.BorderWidthBottom = 1
        V1.BorderWidthLeft = 1
        V1.BorderWidthTop = 0.1
        V1.MinimumHeight = 15
        V1.PaddingTop = 5
        V1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        V1.MinimumHeight = 15
        V1.Colspan = 5
        V1.MinimumHeight = 20
        V1.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(V1)

        'Dim V2 As New PdfPCell(New Paragraph(Letras(total_venta), FontFactory.GetFont("Arial", 8, Font.BOLD)))
        '  V2.BorderWidthRight = 0.1
        ' V2.BorderWidthBottom = 1
        'V2.BorderWidthLeft = 0.1
        'V2.BorderWidthTop = 0.1
        'V2.PaddingLeft = 10
        '   V2.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        '  V2.Colspan = 3
        ' V2.HorizontalAlignment = Element.ALIGN_CENTER
        'NOTA.AddCell(V2)
        Dim leyenda_total As String = ""
        If num_pagina = total_paginas Then
            leyenda_total = "TOTAL"
        End If

        Dim V5 As New PdfPCell(New Paragraph(leyenda_total, FontFactory.GetFont("Arial", 12, Font.BOLD)))
        V5.BorderWidthRight = 0.1
        V5.BorderWidthBottom = 1
        V5.BorderWidthLeft = 0.1
        V5.BorderWidthTop = 0.1
        V5.PaddingLeft = 2
        V5.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        V5.Colspan = 2
        V5.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(V5)

        Dim cantidad_total As String = ""
        If num_pagina = total_paginas Then
            cantidad_total = FormatCurrency(total_venta)
        End If
        Dim V7 As New PdfPCell(New Paragraph(cantidad_total, FontFactory.GetFont("Arial", 12, Font.BOLD)))
        V7.BorderWidthRight = 0.1
        V7.BorderWidthBottom = 1
        V7.BorderWidthLeft = 0.1
        V7.BorderWidthTop = 0.1
        V7.PaddingLeft = 2
        V7.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        V7.Colspan = 2
        V7.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(V7)

        Dim XA1 As New PdfPCell(New Paragraph(" REPARTIDOR_________________     RECIBIO:_________________     REVISADO POR:________________     RECIBI EN PERFECTAS CONDICIONES________________", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
        XA1.HorizontalAlignment = Element.ALIGN_CENTER
        XA1.MinimumHeight = 35
        XA1.Colspan = 9
        XA1.PaddingTop = 20
        'XA1.Border = Nothing
        NOTA.AddCell(XA1)

        If mostrar_pagare = True Then
            Dim W1 As New PdfPCell(New Paragraph("PAGARE", FontFactory.GetFont("Arial", 6, Font.BOLD)))
            W1.HorizontalAlignment = Element.ALIGN_CENTER
            W1.BorderWidthTop = 1
            W1.BorderWidthLeft = 1
            W1.BorderWidthBottom = 0
            W1.BorderWidthRight = 0
            W1.MinimumHeight = 5
            NOTA.AddCell(W1)

            Dim W2 As New PdfPCell(New Paragraph("_________", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            W2.MinimumHeight = 5
            W2.BorderWidthTop = 1
            W2.BorderWidthLeft = 0
            W2.BorderWidthBottom = 0
            W2.BorderWidthRight = 0
            W2.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(W2)

            Dim W3 As New PdfPCell(New Paragraph("___________________________________," & fecha_venta.ToLongDateString, FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            W3.MinimumHeight = 5
            W3.BorderWidthTop = 1
            W3.BorderWidthLeft = 0
            W3.BorderWidthBottom = 0
            W3.BorderWidthRight = 0
            W3.HorizontalAlignment = Element.ALIGN_CENTER
            W3.Colspan = 4
            NOTA.AddCell(W3)

            Dim W6 As New PdfPCell(New Paragraph("BUENO POR:", FontFactory.GetFont("Arial", 6, Font.BOLD)))
            W6.Colspan = 2
            W6.MinimumHeight = 5
            W6.BorderWidthTop = 1
            W6.BorderWidthLeft = 0
            W6.BorderWidthBottom = 0
            W6.BorderWidthRight = 0
            W6.HorizontalAlignment = Element.ALIGN_RIGHT
            NOTA.AddCell(W6)

            Dim W8 As New PdfPCell(New Paragraph(FormatCurrency(total_venta), FontFactory.GetFont("Arial", 6, Font.UNDERLINE)))
            W8.Colspan = 2
            W8.MinimumHeight = 5
            W8.BorderWidthTop = 1
            W8.BorderWidthLeft = 0
            W8.BorderWidthBottom = 0
            W8.BorderWidthRight = 1
            W8.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(W8)

            Dim XA As New PdfPCell(New Paragraph("Debo y pagaré incondicionalmente a la orden de " & global_razon_social & " y/o ____________________________________________________________" & vbCrLf & _
                                                 "En esta ciudad o en cualquier otra que se me requiera, El________ la cantidad de: " & Letras(total_venta) & " valor recibido a mi entera satisfacción. Este pagaré es mercantil y se rige por la Ley General de Títulos y operación de crédito en su artículo 173 parte final y articulos correlativos por no ser pagaré domiciliado, de no realizarse el pago el dia de su vencimiento, se causará un interés moratorio del _____ % mensual por todo el tiempo.", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            XA.Colspan = 9
            XA.MinimumHeight = 20
            XA.BorderWidthTop = 0
            XA.BorderWidthLeft = 1
            XA.BorderWidthBottom = 0
            XA.BorderWidthRight = 1
            XA.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(XA)

            Dim X1 As New PdfPCell(New Paragraph("DATOS DEL DEUDOR O REP. LEGAL", FontFactory.GetFont("Arial", 6, Font.BOLD)))
            X1.Colspan = 4
            X1.MinimumHeight = 5
            X1.BorderWidthTop = 0
            X1.BorderWidthLeft = 1
            X1.BorderWidthBottom = 0
            X1.BorderWidthRight = 0
            X1.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(X1)

            Dim X5 As New PdfPCell(New Paragraph("Acepto(amos)", FontFactory.GetFont("Arial", 6, Font.BOLD)))
            X5.PaddingTop = 15
            X5.Rowspan = 3
            X5.MinimumHeight = 5
            X5.BorderWidthTop = 0
            X5.BorderWidthLeft = 0
            X5.BorderWidthBottom = 1
            X5.BorderWidthRight = 0
            X5.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(X5)

            Dim X6 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLD)))
            X6.Colspan = 2
            X6.Rowspan = 2
            X6.MinimumHeight = 5
            X6.Border = Nothing
            X6.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(X6)

            Dim X8 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLD)))
            X8.Rowspan = 2
            X8.Colspan = 2
            X8.MinimumHeight = 5
            X8.BorderWidthTop = 0
            X8.BorderWidthLeft = 0
            X8.BorderWidthBottom = 0
            X8.BorderWidthRight = 1
            X8.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(X8)

            Dim Y1 As New PdfPCell(New Paragraph("Nombre:", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            Y1.MinimumHeight = 5
            Y1.BorderWidthTop = 0
            Y1.BorderWidthLeft = 1
            Y1.BorderWidthBottom = 0
            Y1.BorderWidthRight = 0
            Y1.PaddingLeft = 2
            Y1.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(Y1)

            Dim Y2 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            Y2.Colspan = 3
            Y2.MinimumHeight = 5
            Y2.Border = Nothing
            Y2.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(Y2)


            Dim Z1 As New PdfPCell(New Paragraph("Direccion:", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            Z1.MinimumHeight = 5
            Z1.BorderWidthTop = 0
            Z1.BorderWidthLeft = 1
            Z1.BorderWidthBottom = 1
            Z1.BorderWidthRight =
                Z1.PaddingLeft = 2
            Z1.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(Z1)

            Dim Z2 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
            Z2.Colspan = 3
            Z2.MinimumHeight = 5
            Z2.BorderWidthTop = 0
            Z2.BorderWidthLeft = 0
            Z2.BorderWidthBottom = 1
            Z2.BorderWidthRight = 0
            Z2.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(Z2)

            Dim Z6 As New PdfPCell(New Paragraph("Nombre", FontFactory.GetFont("Arial", 6, Font.BOLD)))
            Z6.Colspan = 2
            Z6.Rowspan = 2
            Z6.MinimumHeight = 5
            Z6.BorderWidthTop = 0
            Z6.BorderWidthLeft = 0
            Z6.BorderWidthBottom = 1
            Z6.BorderWidthRight = 0
            Z6.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(Z6)

            Dim Z8 As New PdfPCell(New Paragraph("Firma", FontFactory.GetFont("Arial", 6, Font.BOLD)))
            Z8.Rowspan = 2
            Z8.Colspan = 2
            Z8.MinimumHeight = 5
            Z8.BorderWidthTop = 0
            Z8.BorderWidthLeft = 0
            Z8.BorderWidthBottom = 1
            Z8.BorderWidthRight = 1
            Z8.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(Z8)
        End If

        NOTA.HorizontalAlignment = Element.ALIGN_RIGHT

        '=======================================================================================================
        '                                        FIN TABLA NOTA VENTA
        '=======================================================================================================

        document.Add(NOTA)
        'document.Add(NOTA)

    End Sub
    Private Sub encripta_cancelado(ByVal filename As String, ByVal strPass As String)


        Dim FileNew As String

        Dim Encoding As New System.Text.UTF8Encoding()

        Dim reader As New PdfReader(filename)

        FileNew = Replace(filename, ".pdf", "excrypt.pdf")


        Dim stamper = New PdfStamper(reader, New FileStream(FileNew, FileMode.Create))

        stamper.SetEncryption(Nothing, Encoding.GetBytes(strPass), PdfWriter.ALLOW_PRINTING, PdfWriter.STRENGTH40BITS)

        For pageIndex As Integer = 1 To reader.NumberOfPages
            '
            Dim pageRectangle As Rectangle = reader.GetPageSizeWithRotation(pageIndex)

            Dim pdfData As PdfContentByte = stamper.GetUnderContent(pageIndex)

            pdfData.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 90)

            Dim graphicsState As New PdfGState()
            graphicsState.FillOpacity = 0.2F

            pdfData.SetGState(graphicsState)

            pdfData.SetColorFill(BaseColor.BLUE)

            pdfData.BeginText()

            pdfData.ShowTextAligned(Element.ALIGN_CENTER, "CANCELADA", pageRectangle.Width / 2, pageRectangle.Height / 2, 45)

            pdfData.EndText()
        Next

        stamper.Close()

        reader.Close()


        File.Delete(filename)

        File.Copy(FileNew, filename)

        File.Delete(FileNew)

    End Sub
    Private Sub encripta_regalia(ByVal filename As String, ByVal strPass As String)


        Dim FileNew As String

        Dim Encoding As New System.Text.UTF8Encoding()

        Dim reader As New PdfReader(filename)

        FileNew = Replace(filename, ".pdf", "excrypt.pdf")


        Dim stamper = New PdfStamper(reader, New FileStream(FileNew, FileMode.Create))

        stamper.SetEncryption(Nothing, Encoding.GetBytes(strPass), PdfWriter.ALLOW_PRINTING, PdfWriter.STRENGTH40BITS)

        For pageIndex As Integer = 1 To reader.NumberOfPages
            '
            Dim pageRectangle As Rectangle = reader.GetPageSizeWithRotation(pageIndex)

            Dim pdfData As PdfContentByte = stamper.GetUnderContent(pageIndex)

            pdfData.SetFontAndSize(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 90)

            Dim graphicsState As New PdfGState()
            graphicsState.FillOpacity = 0.2F

            pdfData.SetGState(graphicsState)

            pdfData.SetColorFill(BaseColor.BLUE)

            pdfData.BeginText()

            pdfData.ShowTextAligned(Element.ALIGN_CENTER, "REGALIA", pageRectangle.Width / 2, pageRectangle.Height / 2, 45)

            pdfData.EndText()
        Next

        stamper.Close()

        reader.Close()


        File.Delete(filename)

        File.Copy(FileNew, filename)

        File.Delete(FileNew)

    End Sub
End Module


