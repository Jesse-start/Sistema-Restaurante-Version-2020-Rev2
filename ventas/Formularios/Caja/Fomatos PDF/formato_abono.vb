Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System
Imports System.Math

Module Formato_abono
    Dim leyenda1 As String = ""
    Private Sub obtener_leyendas()
        leyenda1 = ""
        rs.Open("SELECT leyenda1 FROM cfg_leyenda_nota WHERE id_cfg_leyenda_nota='1'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("leyenda1").Value) Then
                leyenda1 = rs.Fields("leyenda1").Value
            End If
        End If
        rs.Close()
    End Sub
    Public Sub Generar_Formato_abono(ByVal id_pago_ventas As Integer)
        'Tryn
        'Intentar generar el documento.
        obtener_leyendas()
        Dim doc As New Document(PageSize.LETTER, 30, 40, 20, 45)
        Dim filename As String = global_dir_facturas + "\ABONO_VENTA_" & Format(id_pago_ventas, "0000") & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        Generar_pagina(doc, writer, id_pago_ventas)
        doc.Close()
        Process.Start(filename)
    End Sub
    Public Sub Generar_pagina(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_pago_ventas As Integer)

        Dim nombre_cliente As String = ""
        Dim telefono_cel_cliente As String = ""
        Dim empleado_caja As String = ""
        Dim importe_abono As Decimal = 0
        Dim fecha_cobro As DateTime
        Dim serie_abono As String = "E"
        Dim id_cliente As Integer = 0
        Dim rw As New ADODB.Recordset
        Dim id_venta As Integer = 0
        Dim num_abono As Integer = 0

        rs.Open("SELECT pv.id_venta,pv.importe,pv.fecha_cobro,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja FROM pagos_ventas pv " &
                "JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                "JOIN persona p ON p.id_persona=e.id_persona WHERE id_pago_ventas='" & id_pago_ventas & "'", conn)
        If rs.RecordCount > 0 Then
            id_venta = rs.Fields("id_venta").Value
            importe_abono = rs.Fields("importe").Value
            fecha_cobro = rs.Fields("fecha_cobro").Value
            empleado_caja = rs.Fields("empleado_caja").Value
        End If
        rs.Close()


        rs.Open("SELECT id_cliente FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " &
                  "FROM cliente " &
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " &
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then
            nombre_cliente = rs.Fields("cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.tel_cel ELSE persona.tel_cel END AS telefono_celular " &
                  "FROM cliente " &
                  "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " &
                  "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                  "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
        If rs.RecordCount > 0 Then

            telefono_cel_cliente = rs.Fields("telefono_celular").Value
        End If
        rs.Close()

        Dim i As Integer = 1
        num_abono = i

        rs.Open("SELECT id_pago_ventas FROM pagos_ventas WHERE id_venta='" & id_venta & "'", conn)
        If rs.RecordCount > 0 Then
            i = 1
            While Not rs.EOF
                If rs.Fields("id_pago_ventas").Value = id_pago_ventas Then
                    num_abono = i
                End If
                i = i + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()

        '=======================================================================================================
        '                                        TABLA DE NOTA DE VENTA
        '======================================================================================================

        Dim logo As iTextSharp.text.Image
        logo = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\logo.png")
        logo.ScaleAbsoluteWidth(125)
        logo.ScaleAbsoluteHeight(65)

        Dim ABONO As New PdfPTable(5)
        ABONO.SetWidthPercentage({150, 200, 80, 80, 80}, PageSize.LETTER)


        Dim A1 As New PdfPCell(logo)
        A1.Border = Nothing
        A1.Rowspan = 3
        A1.Colspan = 2
        A1.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(A1)

        Dim A3 As New PdfPCell(New Paragraph("ABONO", FontFactory.GetFont("Arial", 12, Font.BOLD)))
        A3.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        A3.Colspan = 3
        A3.MinimumHeight = 25
        A3.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(A3)

        Dim B3 As New PdfPCell(New Paragraph(Format(num_abono, "00") & "-" & Format(id_venta, "0000"), FontFactory.GetFont("Arial", 18, Font.BOLD)))
        B3.Colspan = 3
        B3.Rowspan = 2
        B3.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(B3)

        '  Dim BB3 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 12, Font.BOLD)))
        ' BB3.Colspan = 3
        'BB3.HorizontalAlignment = Element.ALIGN_CENTER
        'ABONO.AddCell(BB3)

        'Dim C1 As New PdfPCell(New Paragraph("www.mueblika.com " & vbCrLf & _
        '                                    "Tel: (matriz) 01 222 144 55 16 " & vbCrLf & _
        '                                   "facebook: MueblikaEvolution" & vbCrLf & _
        '                                    "WhatsApp: 227 63 64 71", FontFactory.GetFont("Arial", 9, Font.NORMAL)))
        Dim C1 As New PdfPCell(New Paragraph(leyenda1, FontFactory.GetFont("Arial", 9, Font.NORMAL)))
        C1.Border = Nothing
        C1.Colspan = 2
        C1.Rowspan = 2
        C1.PaddingTop = 5
        C1.MinimumHeight = 40
        C1.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(C1)

        Dim C3 As New PdfPCell(New Paragraph("FECHA", FontFactory.GetFont("Arial", 12, Font.BOLD)))
        C3.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2565928))
        C3.MinimumHeight = 25
        C3.Colspan = 3
        C3.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(C3)

        Dim D3 As New PdfPCell(New Paragraph(fecha_cobro.Day, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D3.HorizontalAlignment = Element.ALIGN_CENTER
        D3.MinimumHeight = 20
        ABONO.AddCell(D3)

        Dim D4 As New PdfPCell(New Paragraph(fecha_cobro.Month, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D4.HorizontalAlignment = Element.ALIGN_CENTER
        D4.MinimumHeight = 20
        ABONO.AddCell(D4)

        Dim D5 As New PdfPCell(New Paragraph(fecha_cobro.Year, FontFactory.GetFont("Arial", 10, Font.BOLD)))
        D5.HorizontalAlignment = Element.ALIGN_CENTER
        D5.MinimumHeight = 20
        ABONO.AddCell(D5)

        Dim _ESP As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 10, Font.BOLD)))
        _ESP.Colspan = 5
        _ESP.Border = Nothing
        _ESP.MinimumHeight = 10
        ABONO.AddCell(_ESP)


        Dim E1 As New PdfPCell(New Paragraph("DATOS DEL RECEPTOR:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        E1.Colspan = 1
        E1.Rowspan = 2
        E1.BorderWidthTop = 1
        E1.BorderWidthLeft = 1
        E1.BorderWidthBottom = 0.1
        E1.BorderWidthRight = 0.1
        E1.MinimumHeight = 25
        E1.PaddingTop = 20
        E1.PaddingLeft = 7
        E1.HorizontalAlignment = Element.ALIGN_LEFT
        E1.MinimumHeight = 35
        ABONO.AddCell(E1)

        Dim E2 As New PdfPCell(New Paragraph("NOMBRE:", FontFactory.GetFont("Arial", 6, Font.BOLD)))
        E2.Colspan = 4
        E2.BorderWidthTop = 1
        E2.BorderWidthLeft = 0.1
        E2.BorderWidthBottom = 0
        E2.BorderWidthRight = 1
        E2.PaddingTop = 7
        E2.PaddingLeft = 10
        E2.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(E2)

        Dim EE2 As New PdfPCell(New Paragraph(empleado_caja, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        EE2.Colspan = 4
        EE2.BorderWidthTop = 0
        EE2.BorderWidthLeft = 0
        EE2.BorderWidthBottom = 0.1
        EE2.BorderWidthRight = 1
        EE2.PaddingTop = 7
        EE2.MinimumHeight = 30
        EE2.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(EE2)

        Dim F1 As New PdfPCell(New Paragraph("SUCURSAL:", FontFactory.GetFont("Arial", 6, Font.BOLD)))
        F1.Colspan = 1
        F1.BorderWidthTop = 0.1
        F1.BorderWidthLeft = 1
        F1.BorderWidthBottom = 0
        F1.BorderWidthRight = 0.1
        F1.PaddingTop = 7
        F1.PaddingLeft = 10
        F1.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(F1)

        Dim F2 As New PdfPCell(New Paragraph("", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        F2.Colspan = 4
        F2.Rowspan = 2
        F2.BorderWidthRight = 1
        F2.BorderWidthLeft = 0.1
        F2.BorderWidthBottom = 0
        F2.BorderWidthTop = 0.1
        F2.PaddingTop = 7
        F2.MinimumHeight = 35
        F2.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(F2)

        Dim FF1 As New PdfPCell(New Paragraph(global_nombre_sucursal, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        FF1.Colspan = 1
        FF1.Rowspan = 2
        FF1.BorderWidthTop = 0
        FF1.BorderWidthLeft = 1
        FF1.BorderWidthBottom = 1
        FF1.BorderWidthRight = 0.1
        FF1.PaddingTop = 7
        FF1.PaddingLeft = 7
        FF1.HorizontalAlignment = Element.ALIGN_CENTER
        FF1.MinimumHeight = 35
        ABONO.AddCell(FF1)

        Dim FF2 As New PdfPCell(New Paragraph("FIRMA", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
        FF2.Colspan = 4
        FF2.BorderWidthRight = 1
        FF2.BorderWidthLeft = 0.1
        FF2.BorderWidthBottom = 1
        FF2.BorderWidthTop = 0
        FF2.PaddingTop = 7
        FF2.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(FF2)


        Dim G1 As New PdfPCell(New Paragraph("DATOS DEL CLIENTE:", FontFactory.GetFont("Arial", 8, Font.BOLD)))
        G1.Colspan = 1
        G1.Rowspan = 2
        G1.BorderWidthLeft = 1
        G1.BorderWidthTop = 0
        G1.BorderWidthBottom = 0.1
        G1.BorderWidthRight = 0.1
        G1.PaddingTop = 20
        G1.PaddingLeft = 7
        G1.HorizontalAlignment = Element.ALIGN_LEFT
        G1.MinimumHeight = 35
        ABONO.AddCell(G1)

        Dim G2 As New PdfPCell(New Paragraph("NOMBRE", FontFactory.GetFont("Arial", 6, Font.BOLD)))
        G2.Colspan = 4
        G2.BorderWidthLeft = 0.1
        G2.BorderWidthTop = 0
        G2.BorderWidthRight = 1
        G2.BorderWidthBottom = 0
        G2.PaddingTop = 7
        G2.PaddingLeft = 10
        G2.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(G2)

        Dim GG2 As New PdfPCell(New Paragraph(nombre_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        GG2.Colspan = 4
        GG2.BorderWidthLeft = 0.1
        GG2.BorderWidthTop = 0
        GG2.BorderWidthRight = 1
        GG2.BorderWidthBottom = 0.1
        GG2.MinimumHeight = 30
        GG2.PaddingTop = 7
        GG2.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(GG2)

        Dim H1 As New PdfPCell(New Paragraph("NUM. DE NOTA:", FontFactory.GetFont("Arial", 6, Font.BOLD)))
        H1.Colspan = 1
        H1.BorderWidthBottom = 0
        H1.BorderWidthLeft = 1
        H1.BorderWidthTop = 0.1
        H1.BorderWidthRight = 0.1
        H1.PaddingTop = 7
        H1.PaddingLeft = 10
        H1.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(H1)

        Dim H2 As New PdfPCell(New Paragraph("TELEFONO:", FontFactory.GetFont("Arial", 6, Font.NORMAL)))
        H2.Colspan = 4
        H2.BorderWidthBottom = 0
        H2.BorderWidthRight = 1
        H2.BorderWidthTop = 0.1
        H2.BorderWidthLeft = 0.1
        H2.PaddingTop = 7
        H2.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(H2)

        Dim HH1 As New PdfPCell(New Paragraph(Format(id_venta, "0000"), FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        HH1.Colspan = 1
        HH1.BorderWidthBottom = 1
        HH1.BorderWidthLeft = 1
        HH1.BorderWidthTop = 0
        HH1.BorderWidthRight = 0.1
        HH1.PaddingTop = 7
        HH1.PaddingLeft = 7
        HH1.HorizontalAlignment = Element.ALIGN_CENTER
        HH1.MinimumHeight = 35
        ABONO.AddCell(HH1)

        Dim HH2 As New PdfPCell(New Paragraph(telefono_cel_cliente, FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        HH2.Colspan = 4
        HH2.BorderWidthBottom = 1
        HH2.BorderWidthRight = 1
        HH2.BorderWidthTop = 0
        HH2.BorderWidthLeft = 0.1
        HH2.PaddingTop = 7
        HH2.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(HH2)

        Dim I1 As New PdfPCell(New Paragraph("___________________________" & vbCrLf &
                                             "     FIRMA DEL CLIENTE", FontFactory.GetFont("Arial", 7, Font.BOLD)))
        I1.Border = Nothing
        I1.PaddingTop = 50
        I1.PaddingLeft = 7
        I1.Colspan = 1
        I1.Rowspan = 3
        I1.HorizontalAlignment = Element.ALIGN_LEFT
        I1.MinimumHeight = 70
        ABONO.AddCell(I1)

        Dim I2 As New PdfPCell(New Paragraph("TOTAL " & FormatCurrency(importe_abono), FontFactory.GetFont("Arial", 10, Font.BOLD)))
        I2.Colspan = 4
        I2.BorderWidthRight = 1
        I2.BorderWidthLeft = 1
        I2.BorderWidthBottom = 0.1
        I2.BorderWidthTop = 0
        I2.PaddingTop = 10
        I2.MinimumHeight = 35
        I2.HorizontalAlignment = Element.ALIGN_CENTER
        ABONO.AddCell(I2)


        Dim J2 As New PdfPCell(New Paragraph("IMPORTE CON LETRA:", FontFactory.GetFont("Arial", 6, Font.BOLD)))
        J2.Colspan = 4
        J2.BorderWidthRight = 1
        J2.BorderWidthLeft = 1
        J2.BorderWidthBottom = 0
        J2.BorderWidthTop = 0.1
        J2.PaddingTop = 7
        J2.PaddingLeft = 10
        J2.HorizontalAlignment = Element.ALIGN_LEFT
        ABONO.AddCell(J2)

        Dim JJ2 As New PdfPCell(New Paragraph(Letras(importe_abono), FontFactory.GetFont("Arial", 10, Font.BOLD)))
        JJ2.Colspan = 4
        JJ2.BorderWidthRight = 1
        JJ2.BorderWidthLeft = 1
        JJ2.BorderWidthBottom = 1
        JJ2.BorderWidthTop = 0
        JJ2.PaddingTop = 7
        JJ2.HorizontalAlignment = Element.ALIGN_CENTER
        JJ2.MinimumHeight = 35
        ABONO.AddCell(JJ2)

        ' Dim K1 As New PdfPCell(New Paragraph("Es responsabilidad del cliente notificar le fecha de entrega a la sucursal 15 dias antes de requerir sus productos." & vbCrLf & _
        '"Aplica en compras de sistema de apartado", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        Dim K1 As New PdfPCell(New Paragraph("" & vbCrLf &
                                            "", FontFactory.GetFont("Arial", 8, Font.NORMAL)))
        K1.Colspan = 5
        K1.Border = Nothing
        K1.PaddingTop = 7
        K1.HorizontalAlignment = Element.ALIGN_LEFT
        K1.MinimumHeight = 35
        ABONO.AddCell(K1)

        ABONO.HorizontalAlignment = Element.ALIGN_RIGHT

        '=======================================================================================================
        '                                        FIN TABLA NOTA VENTA
        '=======================================================================================================

        document.Add(ABONO)

    End Sub
End Module


