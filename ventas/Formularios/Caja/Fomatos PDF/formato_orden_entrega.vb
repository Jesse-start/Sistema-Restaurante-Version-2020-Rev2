Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System
Imports System.Math

Module Formato_orden_entrega
    Dim leyenda1 As String = ""
    Dim leyenda2 As String = ""
    Dim leyenda3 As String = ""
    Dim leyenda4 As String = ""
    Dim leyenda5 As String = ""
    Public Sub Generar_orden_entrega(ByVal id_venta As Integer)
        'Tryn
        'Intentar generar el documento.
        obtener_leyendas()
        Dim doc As New Document(PageSize.LETTER, 30, 40, 20, 45)

        Dim filename As String = global_dir_facturas + "\ORDEN_ENTREGA_" & Format(id_venta, "0000") & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        Generar_pagina(doc, writer, id_venta)
        doc.Close()
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
    Public Sub Generar_pagina(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_venta As Integer)

        Dim nombre_cliente As String = ""
        Dim direccion_cliente As String = ""
        Dim ciudad_cliente As String = ""
        Dim telefono_cel_cliente As String = ""
        Dim serie_venta As String = "E"
        Dim fecha_salida_almacen As DateTime
        Dim id_cliente As Integer = 0
        Dim id_domicilio As Integer = 0
        Dim comentario_apartado As String = ""
        Dim estatus_venta As String = ""
        Dim rw As New ADODB.Recordset


        rs.Open("SELECT venta.fecha_salida_almacen,venta.id_cliente,venta.status " & _
                "FROM venta " & _
                "WHERE venta.id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
            estatus_venta = rs.Fields("status").Value
            fecha_salida_almacen = rs.Fields("fecha_salida_almacen").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            nombre_cliente = rs.Fields("cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.tel_cel ELSE persona.tel_cel END AS telefono_celular " & _
                  "FROM cliente " & _
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            telefono_cel_cliente = rs.Fields("telefono_celular").Value
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

        rs.Open("SELECT comentarios FROM apartado WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("comentarios").Value) Then
                comentario_apartado = rs.Fields("comentarios").Value
            End If
        End If
        rs.Close()

        '=======================================================================================================
        '                                        TABLA DE ORDEN DE ENTREGA
        '======================================================================================================

        Dim logo As iTextSharp.text.Image
        logo = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\logo.png")
        logo.ScaleAbsoluteWidth(125)
        logo.ScaleAbsoluteHeight(67)

        Dim ORDEN As New PdfPTable(7)
        ORDEN.SetWidthPercentage({80, 60, 70, 100, 100, 100, 100}, PageSize.LETTER)


        Dim A1 As New PdfPCell(logo)
        A1.Border = Nothing
        A1.Rowspan = 3
        A1.Colspan = 5
        A1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(A1)

        Dim A5 As New PdfPCell(New Paragraph("ORDEN DE ENTREGA", FontFactory.GetFont("Arial", 14, Font.BOLD)))
        A5.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        A5.BorderWidthTop = 1.5
        A5.BorderWidthLeft = 1.5
        A5.BorderWidthBottom = 0.1
        A5.BorderWidthRight = 1.5
        A5.MinimumHeight = 20
        A5.Colspan = 2
        A5.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(A5)




        Dim B5 As New PdfPCell(New Paragraph(serie_venta & " " & Format(id_venta, "0000"), FontFactory.GetFont("Arial", 16, Font.BOLD)))
        B5.BorderWidthTop = 0.1
        B5.BorderWidthLeft = 1.5
        B5.BorderWidthBottom = 1.5
        B5.BorderWidthRight = 1.5
        B5.Colspan = 2
        B5.MinimumHeight = 30
        B5.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(B5)

        Dim AA6 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 14, Font.BOLD)))
        AA6.Border = Nothing
        AA6.Colspan = 2
        AA6.MinimumHeight = 20
        AA6.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(AA6)
        Dim C1 As New PdfPCell(New Paragraph(leyenda2, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        C1.MinimumHeight = 30
        C1.Border = Nothing
        C1.Colspan = 7
        C1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(C1)


        Dim D1 As New PdfPCell(New Paragraph("NOTA: ", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D1.BorderWidthTop = 1.5
        D1.BorderWidthLeft = 1.5
        D1.BorderWidthBottom = 0.1
        D1.BorderWidthRight = 0
        D1.MinimumHeight = 20
        D1.PaddingLeft = 5
        D1.Colspan = 2
        D1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(D1)

        Dim D3 As New PdfPCell(New Paragraph(Format(id_venta, "0000"), FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        D3.BorderWidthTop = 1.5
        D3.BorderWidthLeft = 0
        D3.BorderWidthBottom = 0.1
        D3.BorderWidthRight = 0.1
        D3.MinimumHeight = 20
        'D1.Border = Nothing
        D3.Colspan = 1
        D3.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(D3)


        Dim D4 As New PdfPCell(New Paragraph("FECHA: ", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D4.BorderWidthTop = 1.5
        D4.BorderWidthLeft = 0.1
        D4.BorderWidthBottom = 0.1
        D4.BorderWidthRight = 0
        'D3.Colspan = 2
        D4.PaddingLeft = 5
        D4.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(D4)

        Dim D5 As New PdfPCell(New Paragraph(fecha_salida_almacen.ToShortDateString, FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        D5.BorderWidthTop = 1.5
        D5.BorderWidthLeft = 0
        D5.BorderWidthBottom = 0.1
        D5.BorderWidthRight = 0.1
        D5.Colspan = 1
        D5.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(D5)

        Dim D6 As New PdfPCell(New Paragraph("HORA:", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D6.BorderWidthTop = 1.5
        D6.BorderWidthLeft = 0.1
        D6.BorderWidthBottom = 0.1
        D6.BorderWidthRight = 0
        D6.PaddingLeft = 5
        D6.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(D6)

        Dim D7 As New PdfPCell(New Paragraph(fecha_salida_almacen.ToLongTimeString, FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        D7.BorderWidthTop = 1.5
        D7.BorderWidthLeft = 0
        D7.BorderWidthBottom = 0.1
        D7.BorderWidthRight = 1.5
        D7.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(D7)

        Dim E1 As New PdfPCell(New Paragraph("NOMBRE:", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        E1.BorderWidthTop = 0.1
        E1.BorderWidthLeft = 1.5
        E1.BorderWidthBottom = 0.1
        E1.BorderWidthRight = 0
        'E1.Border = Nothing
        'E1.Colspan = 7
        E1.PaddingLeft = 5
        E1.MinimumHeight = 20
        E1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(E1)

        Dim E2 As New PdfPCell(New Paragraph(nombre_cliente, FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        'E2.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        E2.BorderWidthTop = 0.1
        E2.BorderWidthLeft = 0
        E2.BorderWidthBottom = 0.1
        E2.BorderWidthRight = 1.5
        E2.Colspan = 6
        E2.MinimumHeight = 15
        E2.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(E2)

        Dim F1 As New PdfPCell(New Paragraph("DIRECCCION:", FontFactory.GetFont("Arial", 9, Font.BOLD)))
        F1.Colspan = 1
        F1.BorderWidthTop = 0.1
        F1.BorderWidthLeft = 1.5
        F1.BorderWidthBottom = 0
        F1.BorderWidthRight = 0
        F1.MinimumHeight = 20
        F1.PaddingLeft = 5
        F1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(F1)

        Dim F2 As New PdfPCell(New Paragraph(direccion_cliente, FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        F2.BorderWidthTop = 0.1
        F2.BorderWidthLeft = 0
        F2.BorderWidthBottom = 0.1
        F2.BorderWidthRight = 1.5
        F2.Colspan = 6
        F2.Rowspan = 2
        F2.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(F2)


        Dim G1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        G1.MinimumHeight = 20
        G1.BorderWidthTop = 0
        G1.BorderWidthLeft = 1.5
        G1.BorderWidthBottom = 0
        G1.BorderWidthRight = 0
        G1.Colspan = 2
        G1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(G1)

        'Dim H1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        'H1.BorderWidthTop = 0
        'H1.BorderWidthLeft = 1.5
        'H1.BorderWidthBottom = 0.1
        'H1.BorderWidthRight = 0
        'H1.Colspan = 2
        'H1.MinimumHeight = 20
        'H1.HorizontalAlignment = Element.ALIGN_LEFT
        'ORDEN.AddCell(H1)

        Dim I1 As New PdfPCell(New Paragraph("CIUDAD:", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        I1.BorderWidthTop = 0.1
        I1.BorderWidthLeft = 1.5
        I1.BorderWidthBottom = 0
        I1.BorderWidthRight = 0
        I1.PaddingLeft = 5
        I1.Colspan = 1
        I1.MinimumHeight = 15
        I1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(I1)

        Dim I2 As New PdfPCell(New Paragraph(ciudad_cliente, FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        I2.BorderWidthTop = 0.1
        I2.BorderWidthLeft = 0
        I2.BorderWidthBottom = 0.1
        I2.BorderWidthRight = 0.1
        I2.Colspan = 3
        I2.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(I2)

        Dim I5 As New PdfPCell(New Paragraph("TEL:", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        I5.BorderWidthTop = 0.1
        I5.BorderWidthLeft = 0.1
        I5.BorderWidthBottom = 0.1
        I5.BorderWidthRight = 0
        I5.PaddingLeft = 5
        I5.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(I5)

        Dim I6 As New PdfPCell(New Paragraph(telefono_cel_cliente, FontFactory.GetFont("Arial", 10, Font.NORMAL)))
        I6.BorderWidthTop = 0.1
        I6.BorderWidthLeft = 0
        I6.BorderWidthBottom = 0.1
        I6.BorderWidthRight = 1.5
        I6.Colspan = 2
        I6.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(I6)

        Dim L1 As New PdfPCell(New Paragraph("CANT.", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        L1.BorderWidthRight = 0.1
        L1.BorderWidthBottom = 1
        L1.BorderWidthLeft = 1.5
        L1.BorderWidthTop = 1
        L1.PaddingTop = 5
        L1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        L1.MinimumHeight = 20
        L1.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(L1)

        Dim L1B As New PdfPCell(New Paragraph("D E S C R I P C I O N", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        L1B.BorderWidthRight = 0.1
        L1B.BorderWidthBottom = 1
        L1B.BorderWidthLeft = 0.1
        L1B.BorderWidthTop = 1
        L1B.PaddingTop = 5
        L1B.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        L1B.Colspan = 5
        L1B.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(L1B)

        Dim L7 As New PdfPCell(New Paragraph("LOC.", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        L7.BorderWidthRight = 1.5
        L7.BorderWidthBottom = 1
        L7.BorderWidthLeft = 0.1
        L7.BorderWidthTop = 1
        L7.PaddingTop = 5
        L7.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        L7.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(L7)

        Dim filas_ejecutadas As Integer = 0
        Dim filas_xejecutar As Decimal = 0
        Dim maximo_filas As Integer = 12
        Dim len_max_fila = Len("CASERO - M Rojo 250 grs CASERO - M Rojo 250 grs CASERO - M Rojo 250 grs")

        rs.Open("SELECT p.codigo,vd.cantidad,vd.precio,vd.descripcion,vd.unidad,vd.importe FROM venta_detalle vd JOIN producto p ON p.id_producto=vd.id_producto WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim filas_requerida As Integer = Ceiling(Len(rs.Fields("descripcion").Value) / len_max_fila)
                filas_ejecutadas = filas_ejecutadas + filas_requerida
                Dim K1 As New PdfPCell(New Paragraph(rs.Fields("cantidad").Value, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                K1.BorderWidthRight = 0.1
                K1.BorderWidthBottom = 0
                K1.BorderWidthLeft = 1.5
                K1.BorderWidthTop = 0
                K1.HorizontalAlignment = Element.ALIGN_CENTER
                K1.MinimumHeight = 15 * filas_requerida
                ORDEN.AddCell(K1)

                Dim P1B As New PdfPCell(New Paragraph(rs.Fields("descripcion").Value, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                P1B.BorderWidthRight = 0
                P1B.BorderWidthBottom = 0
                P1B.BorderWidthLeft = 0.1
                P1B.BorderWidthTop = 0
                P1B.PaddingLeft = 5
                P1B.Colspan = 5
                P1B.HorizontalAlignment = Element.ALIGN_LEFT
                ORDEN.AddCell(P1B)

                Dim K7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 9, Font.NORMAL)))
                K7.BorderWidthRight = 1.5
                K7.BorderWidthBottom = 0
                K7.BorderWidthLeft = 0.1
                K7.BorderWidthTop = 0
                K7.Colspan = 1
                K7.HorizontalAlignment = Element.ALIGN_CENTER
                ORDEN.AddCell(K7)

                rs.MoveNext()
            End While
        End If
        rs.Close()

        filas_xejecutar = maximo_filas - filas_ejecutadas
        If filas_xejecutar > 0 Then

            For x = 1 To filas_xejecutar
                Dim K1 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                K1.BorderWidthRight = 0.1
                K1.BorderWidthBottom = 0
                K1.BorderWidthLeft = 1.5
                K1.BorderWidthTop = 0
                K1.HorizontalAlignment = Element.ALIGN_CENTER
                K1.MinimumHeight = 15
                ORDEN.AddCell(K1)

                Dim P1B As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                P1B.BorderWidthRight = 0
                P1B.BorderWidthBottom = 0
                P1B.BorderWidthLeft = 0.1
                P1B.BorderWidthTop = 0
                P1B.PaddingLeft = 5
                P1B.Colspan = 5
                P1B.HorizontalAlignment = Element.ALIGN_LEFT
                ORDEN.AddCell(P1B)

                Dim K7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
                K7.BorderWidthRight = 1.5
                K7.BorderWidthBottom = 0
                K7.BorderWidthLeft = 0.1
                K7.BorderWidthTop = 0
                K7.Colspan = 1
                K7.HorizontalAlignment = Element.ALIGN_CENTER
                ORDEN.AddCell(K7)

            Next
        End If

        Dim O1 As New PdfPCell(New Paragraph("OBSERVACIONES: ", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        O1.BorderWidthRight = 0
        O1.BorderWidthBottom = 0.1
        O1.BorderWidthLeft = 1.5
        O1.BorderWidthTop = 0.1
        O1.Colspan = 2
        O1.MinimumHeight = 40
        O1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(O1)

        Dim O3 As New PdfPCell(New Paragraph(comentario_apartado, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
        O3.BorderWidthRight = 1.5
        O3.BorderWidthBottom = 0.1
        O3.BorderWidthLeft = 0
        O3.BorderWidthTop = 0.1
        O3.Colspan = 5
        O3.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(O3)

        Dim PB As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        PB.BorderWidthRight = 1.5
        PB.BorderWidthBottom = 0.1
        PB.BorderWidthLeft = 1.5
        PB.BorderWidthTop = 0.1
        PB.MinimumHeight = 50
        PB.Colspan = 7
        PB.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(PB)

        Dim P1 As New PdfPCell(New Paragraph("G U I A  D E  R E V I S I O N", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        P1.BorderWidthRight = 1.5
        P1.BorderWidthBottom = 0.1
        P1.BorderWidthLeft = 1.5
        P1.BorderWidthTop = 0.1
        P1.Colspan = 7
        P1.MinimumHeight = 15
        P1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        P1.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(P1)

        Dim Q1 As New PdfPCell(New Paragraph("CAJA DE HERR. Y MAQ. AJUSTE", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        Q1.BorderWidthRight = 0.1
        Q1.BorderWidthBottom = 0
        Q1.BorderWidthLeft = 1.5
        Q1.BorderWidthTop = 0
        Q1.Colspan = 3
        Q1.MinimumHeight = 15
        Q1.PaddingLeft = 20
        Q1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(Q1)

        Dim Q4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        Q4.BorderWidthRight = 0.1
        Q4.BorderWidthBottom = 0.1
        Q4.BorderWidthLeft = 0.1
        Q4.BorderWidthTop = 0.1
        Q4.Colspan = 1
        Q4.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(Q4)

        Dim Q5 As New PdfPCell(New Paragraph("RECTIFICACION FISICA", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        Q5.BorderWidthRight = 0.1
        Q5.BorderWidthBottom = 0
        Q5.BorderWidthLeft = 0.1
        Q5.BorderWidthTop = 0.1
        Q5.Colspan = 2
        Q5.PaddingLeft = 20
        Q5.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(Q5)


        Dim Q7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        Q7.BorderWidthRight = 1.5
        Q7.BorderWidthBottom = 0.1
        Q7.BorderWidthLeft = 0.1
        Q7.BorderWidthTop = 0.1
        Q7.Colspan = 1
        Q7.HorizontalAlignment = Element.ALIGN_RIGHT
        ORDEN.AddCell(Q7)

        Dim R1 As New PdfPCell(New Paragraph("MANTENIMIENTO/SOPORTES", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        R1.MinimumHeight = 15
        R1.BorderWidthRight = 0.1
        R1.BorderWidthBottom = 0
        R1.BorderWidthLeft = 1.5
        R1.BorderWidthTop = 0
        R1.PaddingLeft = 20
        R1.Colspan = 3
        R1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(R1)

        Dim R4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        R4.BorderWidthRight = 0.1
        R4.BorderWidthBottom = 0.1
        R4.BorderWidthLeft = 0.1
        R4.BorderWidthTop = 0.1
        R4.Colspan = 1
        R4.HorizontalAlignment = Element.ALIGN_RIGHT
        ORDEN.AddCell(R4)

        Dim R5 As New PdfPCell(New Paragraph("COMUNICACION CLIENTE", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        R5.BorderWidthRight = 0.1
        R5.BorderWidthBottom = 0
        R5.BorderWidthLeft = 0.1
        R5.BorderWidthTop = 0
        R5.PaddingLeft = 20
        R5.Colspan = 2
        R5.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(R5)


        Dim R7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        R7.BorderWidthRight = 1.5
        R7.BorderWidthBottom = 0.1
        R7.BorderWidthLeft = 0.1
        R7.BorderWidthTop = 0.1
        R7.Colspan = 1
        R7.HorizontalAlignment = Element.ALIGN_RIGHT
        ORDEN.AddCell(R7)


        Dim S1 As New PdfPCell(New Paragraph("EMBALAJE", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        S1.MinimumHeight = 15
        S1.BorderWidthRight = 0.1
        S1.BorderWidthBottom = 0.1
        S1.BorderWidthLeft = 1.5
        S1.BorderWidthTop = 0
        S1.PaddingLeft = 20
        S1.Colspan = 3
        S1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(S1)

        Dim S4 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        S4.BorderWidthRight = 0.1
        S4.BorderWidthBottom = 0.1
        S4.BorderWidthLeft = 0.1
        S4.BorderWidthTop = 0.1
        S4.Colspan = 1
        S4.HorizontalAlignment = Element.ALIGN_RIGHT
        ORDEN.AddCell(S4)

        Dim S5 As New PdfPCell(New Paragraph("EQUIPO DE COMUNICACION", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        S5.BorderWidthRight = 0.1
        S5.BorderWidthBottom = 0.1
        S5.BorderWidthLeft = 0.1
        S5.BorderWidthTop = 0
        S5.PaddingLeft = 20
        S5.Colspan = 2
        S5.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(S5)


        Dim S7 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.BOLDITALIC)))
        S7.BorderWidthRight = 1.5
        S7.BorderWidthBottom = 0.1
        S7.BorderWidthLeft = 0.1
        S7.BorderWidthTop = 0.1
        S7.Colspan = 1
        S7.HorizontalAlignment = Element.ALIGN_RIGHT
        ORDEN.AddCell(S7)


        Dim T1 As New PdfPCell(New Paragraph("FLETE: ", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        T1.BorderWidthRight = 0
        T1.BorderWidthBottom = 0
        T1.BorderWidthLeft = 1.5
        T1.BorderWidthTop = 0.1
        T1.Colspan = 1
        T1.MinimumHeight = 25
        T1.PaddingLeft = 20
        T1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(T1)

        Dim T2 As New PdfPCell(New Paragraph("_______________", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        T2.Border = Nothing
        T2.Colspan = 3
        T2.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(T2)

        Dim T5 As New PdfPCell(New Paragraph("________________________________" & vbCrLf & _
                                             "         FIRMA DE SALIDA", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
        T5.BorderWidthRight = 1.5
        T5.BorderWidthBottom = 0
        T5.BorderWidthLeft = 0
        T5.BorderWidthTop = 0
        T5.PaddingTop = 30
        T5.Colspan = 3
        T5.Rowspan = 2
        T5.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(T5)


        Dim V1 As New PdfPCell(New Paragraph("RESTA: ", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        V1.MinimumHeight = 25
        V1.BorderWidthRight = 0
        V1.BorderWidthBottom = 0
        V1.BorderWidthLeft = 1.5
        V1.BorderWidthTop = 0
        V1.Colspan = 1
        V1.PaddingLeft = 20
        V1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(V1)

        Dim V2 As New PdfPCell(New Paragraph("______________", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        V2.Border = Nothing
        V2.Colspan = 3
        V2.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(V2)


        Dim W1 As New PdfPCell(New Paragraph("TOTAL: ", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        W1.MinimumHeight = 40
        W1.BorderWidthRight = 0
        W1.BorderWidthBottom = 0
        W1.BorderWidthLeft = 1.5
        W1.BorderWidthTop = 0
        W1.PaddingLeft = 20
        W1.Colspan = 1
        W1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(W1)

        Dim W2 As New PdfPCell(New Paragraph("_______________", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        W2.Border = Nothing
        W2.Colspan = 3
        W2.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(W2)

        Dim W5 As New PdfPCell(New Paragraph("_____________________________________________________" & vbCrLf & _
                                             "       RECIBI LA MERCANCIA EN BUENAS CONDICIONES", FontFactory.GetFont("Arial", 6, Font.NORMAL)))

        W5.BorderWidthRight = 1.5
        W5.BorderWidthBottom = 0
        W5.BorderWidthLeft = 1
        W5.BorderWidthTop = 1
        W5.PaddingTop = 40
        W5.Colspan = 3
        W5.Rowspan = 2
        W5.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(W5)

        Dim X1 As New PdfPCell(New Paragraph(" __________________________________" & vbCrLf & _
                                             "      FIRMA ADMINISTRATIVA", FontFactory.GetFont("Arial", 7, Font.NORMAL)))
        X1.BorderWidthRight = 0
        X1.BorderWidthBottom = 0.1
        X1.BorderWidthLeft = 1.5
        X1.BorderWidthTop = 0
        X1.PaddingTop = 25
        X1.Colspan = 4
        X1.Rowspan = 2
        X1.MinimumHeight = 50
        X1.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(X1)

        Dim XX1 As New PdfPCell(New Paragraph("FIRMA DEL CLIENTE", FontFactory.GetFont("Arial", 12, Font.BOLD)))

        XX1.BorderWidthRight = 1.5
        XX1.BorderWidthBottom = 1
        XX1.BorderWidthLeft = 1
        XX1.BorderWidthTop = 0
        XX1.Colspan = 3
        XX1.PaddingTop = 15
        XX1.MinimumHeight = 40
        XX1.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(XX1)

        Dim Y1 As New PdfPCell(New Paragraph(leyenda4, FontFactory.GetFont("Arial", 7, Font.NORMAL)))
        Y1.BorderWidthRight = 1.5
        Y1.BorderWidthBottom = 1.5
        Y1.BorderWidthLeft = 1.5
        Y1.BorderWidthTop = 0
        Y1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        Y1.Colspan = 7
        Y1.MinimumHeight = 20
        Y1.HorizontalAlignment = Element.ALIGN_LEFT
        ORDEN.AddCell(Y1)

        Dim Z1 As New PdfPCell(New Paragraph("Atencion a clientes", FontFactory.GetFont("Arial", 7, Font.BOLD)))
        Z1.Border = Nothing
        Z1.BorderWidth = 1
        Z1.Colspan = 2
        Z1.MinimumHeight = 10
        Z1.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(Z1)

        Dim Z3 As New PdfPCell(New Paragraph(leyenda5, FontFactory.GetFont("Arial", 7, Font.BOLD)))
        Z3.Border = Nothing
        Z3.BorderWidth = 1
        Z3.Colspan = 5
        Z3.MinimumHeight = 10
        Z3.HorizontalAlignment = Element.ALIGN_CENTER
        ORDEN.AddCell(Z3)

        ORDEN.HorizontalAlignment = Element.ALIGN_RIGHT


        '=======================================================================================================
        '                                        FIN TABLA NOTA VENTA
        '=======================================================================================================

        document.Add(ORDEN)

    End Sub
End Module


