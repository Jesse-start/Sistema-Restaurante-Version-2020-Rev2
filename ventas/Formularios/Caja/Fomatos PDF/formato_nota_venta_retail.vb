Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System
Imports System.Math

Module formato_nota_venta_retail
    Dim leyenda1 As String = ""
    Dim leyenda2 As String = ""
    Dim leyenda3 As String = ""
    Dim leyenda4 As String = ""
    Dim leyenda5 As String = ""
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
    Public Sub Generar_Formato_venta_retail(ByVal id_venta As Integer, ByVal cancelado As Boolean)
        'Tryn
        'Intentar generar el documento.
        obtener_leyendas()
        Dim doc As New Document(PageSize.LETTER, 30, 40, 20, 45)
        Dim filename As String = Application.StartupPath & "\Notas" + "\NOTA_VENTA_" & Format(id_venta, "0000") & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        Generar_pagina(doc, writer, id_venta, -2565928)
        doc.Close()
        If cancelado = True Then
            EncriptaArchivo(filename, "UKLRQe2610188696")
        End If
        Process.Start(filename)
    End Sub
    Public Sub Generar_pagina(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_venta As Integer, ByVal color_fondo As String)

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
        Dim serie_venta As String = "E"
        Dim fecha_entrega As DateTime
        Dim id_cliente As Integer = 0
        Dim id_domicilio As Integer = 0
        Dim id_apartado As Integer = 0
        Dim id_pedido As Integer = 0
        Dim comentario_apartado As String = ""
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

        rs.Open("SELECT id_apartado,comentarios,fecha_entrega FROM apartado WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            id_apartado = rs.Fields("id_apartado").Value
            fecha_entrega = rs.Fields("fecha_entrega").Value
            If Not IsDBNull(rs.Fields("comentarios").Value) Then
                comentario_apartado = rs.Fields("comentarios").Value
            End If
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
        rs.Open("SELECT pv.importe,fp.descripcion AS forma_pago,fecha,num_tarjeta " &
                "FROM pagos_ventas pv " &
                "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
                "WHERE pv.id_venta='" & id_venta & "' AND pv.status='ACTIVO' ORDER BY pv.fecha ASC LIMIT 1", conn)
        If rs.RecordCount > 0 Then
            forma_pago_enganche = rs.Fields("Forma_pago").Value
            enganche = rs.Fields("importe").Value
            If Not IsDBNull(rs.Fields("num_tarjeta").Value) Then
                referencia = rs.Fields("num_tarjeta").Value
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
        logo.ScaleAbsoluteWidth(125)
        logo.ScaleAbsoluteHeight(67)

        Dim NOTA As New PdfPTable(9)
        NOTA.SetWidthPercentage({60, 60, 80, 120, 80, 55, 50, 50, 50}, PageSize.LETTER)


        Dim A1 As New PdfPCell(logo)
        A1.Border = Nothing
        A1.Rowspan = 4
        A1.Colspan = 4
        A1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(A1)

        Dim A4 As New PdfPCell(New Paragraph(" Sucursal", FontFactory.GetFont("Arial", 14, Font.BOLD)))
        A4.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        A4.MinimumHeight = 15
        A4.Colspan = 2
        A4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(A4)

        Dim A6 As New PdfPCell(New Paragraph(" NOTA DE VENTA", FontFactory.GetFont("Arial", 14, Font.BOLD)))
        A6.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        A6.Colspan = 3
        A6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(A6)

        Dim B4 As New PdfPCell(New Paragraph(global_nombre_sucursal, FontFactory.GetFont("Arial", 11, Font.BOLD)))
        B4.MinimumHeight = 15
        B4.Colspan = 2
        B4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(B4)

        Dim B6 As New PdfPCell(New Paragraph(serie_venta & " " & Format(id_venta, "0000"), FontFactory.GetFont("Arial", 12, Font.BOLD)))
        B6.Colspan = 3
        B6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(B6)

        Dim C4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 9, Font.NORMAL))) 'leyenda 1
        C4.MinimumHeight = 15
        C4.Border = Nothing
        C4.Colspan = 2
        C4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(C4)

        Dim C6 As New PdfPCell(New Paragraph("FECHA", FontFactory.GetFont("Arial", 11, Font.BOLD)))
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

        Dim D6 As New PdfPCell(New Paragraph(fecha_venta.Day, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D6)

        Dim D7 As New PdfPCell(New Paragraph(fecha_venta.Month, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D7.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D7)

        Dim D8 As New PdfPCell(New Paragraph(fecha_venta.Year, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D8.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(D8)

        'LEYENDA 1
        Dim E1 As New PdfPCell(New Paragraph(leyenda1, FontFactory.GetFont("Arial", 9, Font.BOLD)))
        E1.Border = Nothing
        E1.Colspan = 7
        E1.MinimumHeight = 50
        E1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(E1)

        Dim E7 As New PdfPCell(New Paragraph(" " & vbCrLf & _
                                             "" & vbCrLf & _
                                             " " & vbCrLf & _
                                             " " & vbCrLf & _
                                             " " & vbCrLf & _
                                             "", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        E7.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        E7.Border = Nothing
        E7.Colspan = 2
        E7.MinimumHeight = 60
        E7.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(E7)

        Dim F1 As New PdfPCell(New Paragraph("NOMBRE :", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        F1.Colspan = 2
        F1.BorderWidthTop = 1
        F1.BorderWidthLeft = 1
        F1.BorderWidthBottom = 0.1
        F1.BorderWidthRight = 0
        F1.MinimumHeight = 25
        F1.PaddingTop = 7
        F1.PaddingLeft = 7
        F1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F1)

        Dim F2 As New PdfPCell(New Paragraph(nombre_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        F2.Colspan = 3
        F2.BorderWidthTop = 1
        F2.BorderWidthLeft = 0
        F2.BorderWidthBottom = 0.1
        F2.BorderWidthRight = 0
        F2.PaddingTop = 7
        F2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F2)

        Dim F5 As New PdfPCell(New Paragraph("TEL:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        F5.BorderWidthTop = 1
        F5.BorderWidthLeft = 1
        F5.BorderWidthBottom = 0.1
        F5.BorderWidthRight = 0
        F5.PaddingTop = 7
        F5.PaddingLeft = 7
        F5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F5)

        Dim F6 As New PdfPCell(New Paragraph(telefono_fijo_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        F6.Colspan = 3
        F6.BorderWidthRight = 1
        F6.BorderWidthLeft = 0
        F6.BorderWidthBottom = 0.1
        F6.BorderWidthTop = 1
        F6.PaddingTop = 7
        F6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(F6)

        Dim G1 As New PdfPCell(New Paragraph("DIRECCION:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        G1.Colspan = 2
        G1.BorderWidthLeft = 1
        G1.BorderWidthTop = 0.1
        G1.BorderWidthBottom = 0
        G1.BorderWidthRight = 0
        G1.MinimumHeight = 25
        G1.PaddingTop = 7
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
        G2.MinimumHeight = 50
        G2.PaddingTop = 7
        G2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(G2)

        Dim G5 As New PdfPCell(New Paragraph("CEL:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        G5.BorderWidthLeft = 1
        G5.BorderWidthRight = 0
        G5.BorderWidthBottom = 0.1
        G5.BorderWidthTop = 0.1
        G5.PaddingTop = 7
        G5.PaddingLeft = 7
        G5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(G5)

        Dim G6 As New PdfPCell(New Paragraph(telefono_cel_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        G6.Colspan = 3
        G6.BorderWidthRight = 1
        G6.BorderWidthBottom = 0.1
        G6.BorderWidthTop = 0.1
        G6.BorderWidthLeft = 0
        G6.PaddingTop = 7
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
        H5.PaddingTop = 7
        H5.PaddingLeft = 7
        H5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(H5)

        Dim H6 As New PdfPCell(New Paragraph(email_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        H6.Colspan = 3
        H6.BorderWidthRight = 1
        H6.BorderWidthLeft = 0
        H6.BorderWidthTop = 0.1
        H6.BorderWidthBottom = 0.1
        H6.PaddingTop = 7
        H6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(H6)

        Dim I1 As New PdfPCell(New Paragraph("CIUDAD:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        I1.Colspan = 2
        I1.BorderWidthBottom = 1
        I1.BorderWidthLeft = 1
        I1.BorderWidthTop = 0.1
        I1.BorderWidthRight = 0
        I1.MinimumHeight = 25
        I1.PaddingTop = 7
        I1.PaddingLeft = 7
        I1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I1)

        Dim I2 As New PdfPCell(New Paragraph(ciudad_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        I2.Colspan = 3
        I2.BorderWidthBottom = 1
        I2.BorderWidthRight = 0
        I2.BorderWidthTop = 0.1
        I2.BorderWidthLeft = 0
        I2.PaddingTop = 7
        I2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I2)

        Dim I5 As New PdfPCell(New Paragraph("WhatsApp:", FontFactory.GetFont("Arial", 7, Font.BOLD)))
        I5.BorderWidthLeft = 1
        I5.BorderWidthBottom = 1
        I5.BorderWidthTop = 0.1
        I5.BorderWidthRight = 0
        I5.PaddingTop = 7
        I5.PaddingLeft = 7
        I5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I5)

        Dim I6 As New PdfPCell(New Paragraph(whatsapp_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        I6.Colspan = 3
        I6.BorderWidthBottom = 1
        I6.BorderWidthRight = 1
        I6.BorderWidthLeft = 0
        I6.BorderWidthTop = 0.1
        I6.PaddingTop = 7
        I6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(I6)

        Dim J1 As New PdfPCell(New Paragraph("VENDEDOR:", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        J1.Border = Nothing
        J1.MinimumHeight = 15
        J1.PaddingTop = 10
        J1.PaddingBottom = 10
        J1.Colspan = 2
        J1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J1)

        Dim J2 As New PdfPCell(New Paragraph(vendedor, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        J2.Border = Nothing
        J2.PaddingTop = 10
        J2.PaddingBottom = 10
        J2.Colspan = 2
        J2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J2)

        Dim J4 As New PdfPCell(New Paragraph("MODALIDAD:", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        J4.Border = Nothing
        J4.PaddingTop = 10
        J4.PaddingBottom = 10
        J4.Colspan = 2
        J4.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J4)

        Dim J6 As New PdfPCell(New Paragraph(modalidad_compra, FontFactory.GetFont("Arial", 8, Font.UNDERLINE)))
        J6.Border = Nothing
        J6.PaddingTop = 10
        J6.PaddingBottom = 10
        J6.Colspan = 3
        J6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(J6)

        Dim K1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLDITALIC))) ' promocion
        K1.Border = Nothing
        K1.MinimumHeight = 15
        K1.PaddingBottom = 10
        K1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(K1)

        Dim K1B As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL))) ' linea promocion
        K1B.Border = Nothing
        K1B.PaddingBottom = 10
        K1B.Colspan = 2
        K1B.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(K1B)

        Dim K3 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLDITALIC))) ' costo servicio de entrega
        K3.PaddingBottom = 10
        K3.Border = Nothing
        K3.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(K3)

        Dim K4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL))) ' linea costo servicio de entrega
        K4.Border = Nothing
        K4.PaddingBottom = 10
        K4.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(K4)

        Dim K5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLDITALIC))) ' tiempo de apartado
        K5.Colspan = 2
        K5.Border = Nothing
        K5.PaddingBottom = 10
        K5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(K5)

        Dim K6 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.UNDERLINE))) ' valor tiempo_apartado
        K6.Border = Nothing
        K6.PaddingBottom = 10
        K6.Colspan = 2
        K6.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(K6)

        Dim L1 As New PdfPCell(New Paragraph("CANT.", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L1.BorderWidthRight = 0.1
        L1.BorderWidthBottom = 1
        L1.BorderWidthLeft = 1
        L1.BorderWidthTop = 1
        L1.PaddingTop = 5
        L1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L1.MinimumHeight = 25
        L1.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L1)

        Dim L1A As New PdfPCell(New Paragraph("CODIGO", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L1A.BorderWidthRight = 0
        L1A.BorderWidthBottom = 1
        L1A.BorderWidthLeft = 0.1
        L1A.BorderWidthTop = 1
        L1A.PaddingTop = 5
        L1A.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L1A.Colspan = 1
        L1A.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L1A)

        Dim L1B As New PdfPCell(New Paragraph("DESCRIPCION", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L1B.BorderWidthRight = 0
        L1B.BorderWidthBottom = 1
        L1B.BorderWidthLeft = 0.1
        L1B.BorderWidthTop = 1
        L1B.PaddingTop = 5
        L1B.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L1B.Colspan = 2
        L1B.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L1B)

        Dim L4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 5, Font.BOLD)))
        L4.BorderWidthRight = 0
        L4.BorderWidthBottom = 1
        L4.BorderWidthLeft = 0
        L4.BorderWidthTop = 1
        L4.PaddingTop = 5
        L4.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L4.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L4)

        Dim L5 As New PdfPCell(New Paragraph("PRECIO UNITARIO", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L5.BorderWidthRight = 0.1
        L5.BorderWidthBottom = 1
        L5.BorderWidthLeft = 0.1
        L5.BorderWidthTop = 1
        L5.PaddingTop = 5
        L5.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L5.Colspan = 2
        L5.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L5)

        Dim L6 As New PdfPCell(New Paragraph("IMPORTE", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        L6.BorderWidthRight = 1
        L6.BorderWidthBottom = 1
        L6.BorderWidthLeft = 0.1
        L6.BorderWidthTop = 1
        L6.PaddingTop = 5
        L6.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        L6.Colspan = 2
        L6.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(L6)

        Dim filas_ejecutadas As Integer = 0
        Dim filas_xejecutar As Decimal = 0
        Dim maximo_filas As Integer = 15
        Dim len_max_fila = Len("CASERO - M Rojo 250 grs CASERO - M Rojo 250 grs CASERO - M Rojo 250 grs")

        rs.Open("SELECT p.codigo,vd.cantidad,vd.precio,vd.descripcion,vd.unidad,vd.importe FROM venta_detalle vd JOIN producto p ON p.id_producto=vd.id_producto WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim filas_requerida As Integer = Ceiling(Len(rs.Fields("descripcion").Value) / len_max_fila)
                filas_ejecutadas = filas_ejecutadas + filas_requerida

                Dim P1 As New PdfPCell(New Paragraph(rs.Fields("cantidad").Value, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                P1.BorderWidthRight = 0.1
                P1.BorderWidthBottom = 0
                P1.BorderWidthLeft = 1
                P1.BorderWidthTop = 0
                P1.HorizontalAlignment = Element.ALIGN_CENTER
                P1.MinimumHeight = 15 * filas_requerida
                NOTA.AddCell(P1)

                Dim P1A As New PdfPCell(New Paragraph(rs.Fields("codigo").Value, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                P1A.BorderWidthRight = 0
                P1A.BorderWidthBottom = 0
                P1A.BorderWidthLeft = 0.1
                P1A.BorderWidthTop = 0
                P1A.HorizontalAlignment = Element.ALIGN_CENTER
                P1A.MinimumHeight = 15 * filas_requerida
                NOTA.AddCell(P1A)

                Dim P1B As New PdfPCell(New Paragraph(rs.Fields("descripcion").Value, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                P1B.BorderWidthRight = 0
                P1B.BorderWidthBottom = 0
                P1B.BorderWidthLeft = 0.1
                P1B.BorderWidthTop = 0
                P1B.PaddingLeft = 5
                P1B.Colspan = 3
                P1B.HorizontalAlignment = Element.ALIGN_LEFT
                NOTA.AddCell(P1B)

                Dim P5 As New PdfPCell(New Paragraph(FormatCurrency(rs.Fields("precio").Value), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                P5.BorderWidthRight = 0.1
                P5.BorderWidthBottom = 0
                P5.BorderWidthLeft = 0.1
                P5.BorderWidthTop = 0
                P5.Colspan = 2
                P5.HorizontalAlignment = Element.ALIGN_CENTER
                NOTA.AddCell(P5)

                Dim P6 As New PdfPCell(New Paragraph(FormatCurrency(rs.Fields("importe").Value), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
                P6.BorderWidthRight = 1
                P6.BorderWidthBottom = 0
                P6.BorderWidthLeft = 0.1
                P6.BorderWidthTop = 0
                P6.PaddingRight = 10
                P6.Colspan = 2
                P6.HorizontalAlignment = Element.ALIGN_RIGHT
                NOTA.AddCell(P6)

                rs.MoveNext()
            End While
        End If
        rs.Close()

        If comentario_apartado <> "" Then
            Dim filas_observaciones As Integer = Ceiling(Len(comentario_apartado) / len_max_fila)

            filas_ejecutadas = filas_ejecutadas + filas_observaciones

            Dim OP1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
            OP1.BorderWidthRight = 0.1
            OP1.BorderWidthBottom = 0
            OP1.BorderWidthLeft = 1
            OP1.BorderWidthTop = 0
            OP1.HorizontalAlignment = Element.ALIGN_CENTER
            OP1.MinimumHeight = 15 * filas_observaciones
            NOTA.AddCell(OP1)


            Dim OP1A As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
            OP1A.BorderWidthRight = 0
            OP1A.BorderWidthBottom = 0
            OP1A.BorderWidthLeft = 0.1
            OP1A.BorderWidthTop = 0
            OP1A.HorizontalAlignment = Element.ALIGN_CENTER
            OP1A.MinimumHeight = 15 * filas_observaciones
            NOTA.AddCell(OP1A)

            Dim OP1B As New PdfPCell(New Paragraph("Comentarios: " & comentario_apartado, FontFactory.GetFont("Arial", 7, Font.NORMAL)))
            OP1B.BorderWidthRight = 0
            OP1B.BorderWidthBottom = 0
            OP1B.BorderWidthLeft = 0.1
            OP1B.BorderWidthTop = 0
            OP1B.PaddingLeft = 5
            OP1B.Colspan = 3
            OP1B.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(OP1B)

            Dim OP5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
            OP5.BorderWidthRight = 0.1
            OP5.BorderWidthBottom = 0
            OP5.BorderWidthLeft = 0.1
            OP5.BorderWidthTop = 0
            OP5.Colspan = 2
            OP5.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(OP5)

            Dim OP6 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
            OP6.BorderWidthRight = 1
            OP6.BorderWidthBottom = 0
            OP6.BorderWidthLeft = 0.1
            OP6.BorderWidthTop = 0
            OP6.PaddingRight = 10
            OP6.Colspan = 2
            OP6.HorizontalAlignment = Element.ALIGN_RIGHT
            NOTA.AddCell(OP6)
        End If

        filas_xejecutar = maximo_filas - filas_ejecutadas
        If filas_xejecutar > 0 Then

            For x = 1 To filas_xejecutar
                Dim P1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                P1.BorderWidthRight = 0.1
                P1.BorderWidthBottom = 0
                P1.BorderWidthLeft = 1
                P1.BorderWidthTop = 0
                P1.HorizontalAlignment = Element.ALIGN_CENTER
                P1.MinimumHeight = 15
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

        Dim S5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        S5.Colspan = 2
        S5.BorderWidthRight = 0.1
        S5.BorderWidthBottom = 0
        S5.BorderWidthLeft = 0
        S5.BorderWidthTop = 0
        S5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(S5)

        Dim S7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        S7.BorderWidthRight = 1
        S7.BorderWidthBottom = 0
        S7.BorderWidthLeft = 0.1
        S7.BorderWidthTop = 0
        S7.Colspan = 2
        S7.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(S7)

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

        Dim T5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        T5.BorderWidthRight = 0.1
        T5.BorderWidthBottom = 0
        T5.BorderWidthLeft = 0.1
        T5.BorderWidthTop = 0
        T5.Colspan = 2
        T5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(T5)

        Dim T7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        T7.BorderWidthRight = 1
        T7.BorderWidthBottom = 0
        T7.BorderWidthLeft = 0.1
        T7.BorderWidthTop = 0
        T7.Colspan = 2
        T7.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(T7)



        Dim nota_venta_01 As iTextSharp.text.Image
        nota_venta_01 = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\nota_venta_01.png")
        nota_venta_01.ScaleAbsoluteWidth(70)
        nota_venta_01.ScaleAbsoluteHeight(70)




        Dim U1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD))) ' cambiar a la imagen si se requiere
        U1.BorderWidthRight = 0
        U1.BorderWidthBottom = 0.1
        U1.BorderWidthLeft = 1
        U1.BorderWidthTop = 0
        U1.PaddingBottom = 3
        U1.MinimumHeight = 60
        U1.Colspan = 2
        U1.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(U1)

        Dim U2 As New PdfPCell(New Paragraph("" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
        U2.BorderWidthRight = 0
        U2.BorderWidthBottom = 0.1
        U2.BorderWidthLeft = 0
        U2.BorderWidthTop = 0
        U2.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(U2)

        Dim U3 As New PdfPCell(New Paragraph("_______________________" & vbCrLf & _
                                             "FIRMA DEL CLIENTE", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        U3.BorderWidthRight = 0.1
        U3.BorderWidthBottom = 0.1
        U3.BorderWidthLeft = 0
        U3.BorderWidthTop = 0
        U3.PaddingTop = 25
        U3.Colspan = 2
        U3.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(U3)

        If leyenda_descuento = "" Then
            Dim U5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 14, Font.BOLD)))
            U5.BorderWidthRight = 0.1
            U5.BorderWidthBottom = 0
            U5.BorderWidthLeft = 0.1
            U5.BorderWidthTop = 0
            U5.Colspan = 2
            U5.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(U5)

            Dim U7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
            U7.BorderWidthRight = 1
            U7.BorderWidthBottom = 0
            U7.BorderWidthLeft = 0.1
            U7.BorderWidthTop = 0
            U7.Colspan = 2
            U7.HorizontalAlignment = Element.ALIGN_LEFT
            NOTA.AddCell(U7)
        Else
            Dim U5 As New PdfPCell(New Paragraph(leyenda_descuento, FontFactory.GetFont("Arial", 12, Font.BOLD)))
            U5.BorderWidthRight = 1
            U5.BorderWidthBottom = 0
            U5.BorderWidthLeft = 0.1
            U5.BorderWidthTop = 0
            U5.Colspan = 4
            U5.HorizontalAlignment = Element.ALIGN_CENTER
            NOTA.AddCell(U5)
        End If

        Dim V1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLD))) ' leyenda atencion a clientes
        V1.BorderWidthRight = 0.1
        V1.BorderWidthBottom = 1
        V1.BorderWidthLeft = 1
        V1.BorderWidthTop = 0.1
        V1.MinimumHeight = 15
        V1.PaddingTop = 5
        V1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        V1.MinimumHeight = 25
        V1.Colspan = 2
        V1.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(V1)

        Dim V2 As New PdfPCell(New Paragraph(Letras(total_venta), FontFactory.GetFont("Arial", 8, Font.BOLD)))
        V2.BorderWidthRight = 0.1
        V2.BorderWidthBottom = 1
        V2.BorderWidthLeft = 0.1
        V2.BorderWidthTop = 0.1
        V2.PaddingLeft = 10
        V2.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        V2.Colspan = 3
        V2.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(V2)

        Dim V5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        V5.BorderWidthRight = 0.1
        V5.BorderWidthBottom = 1
        V5.BorderWidthLeft = 0.1
        V5.BorderWidthTop = 0
        V5.Colspan = 2
        V5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(V5)

        Dim V7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        V7.BorderWidthRight = 1
        V7.BorderWidthBottom = 1
        V7.BorderWidthLeft = 0.1
        V7.BorderWidthTop = 0
        V7.Colspan = 2
        V7.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(V7)

        Dim W1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.BOLD))) ' titulo de la nota final
        W1.Border = Nothing
        W1.Colspan = 5
        W1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(W1)

        Dim W5 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.ITALIC)))
        W5.Border = Nothing
        W5.Colspan = 4
        W5.MinimumHeight = 5
        W5.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(W5)

        Dim X1 As New PdfPCell(New Paragraph("" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "" & vbCrLf & _
                                             "", FontFactory.GetFont("Arial", 6, Font.ITALIC)))
        X1.Border = Nothing
        X1.Colspan = 5
        X1.MinimumHeight = 40
        X1.HorizontalAlignment = Element.ALIGN_LEFT
        NOTA.AddCell(X1)

        Dim X5 As New PdfPCell(New Paragraph("TOTAL ", FontFactory.GetFont("Arial", 12, Font.BOLD)))
        X5.BorderWidth = 1
        X5.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(color_fondo))
        X5.Colspan = 2
        X5.MinimumHeight = 40
        X5.PaddingTop = 15
        X5.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(X5)

        Dim X7 As New PdfPCell(New Paragraph(FormatCurrency(total_venta), FontFactory.GetFont("Arial", 12, Font.BOLD)))
        X7.BorderWidth = 1
        X7.Colspan = 2
        X7.MinimumHeight = 40
        X7.PaddingTop = 15
        X7.HorizontalAlignment = Element.ALIGN_CENTER
        NOTA.AddCell(X7)


        NOTA.HorizontalAlignment = Element.ALIGN_RIGHT


        '=======================================================================================================
        '                                        FIN TABLA NOTA VENTA
        '=======================================================================================================

        document.Add(NOTA)

    End Sub
    Private Sub EncriptaArchivo(ByVal filename As String, ByVal strPass As String)


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
End Module


