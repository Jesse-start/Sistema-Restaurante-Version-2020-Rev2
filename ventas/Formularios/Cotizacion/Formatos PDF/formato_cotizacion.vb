Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System

Module formato_cotizacion
    Public Sub Generarcotizacion(ByVal id_cotizacion As Integer, Optional ByVal membretada As Boolean = True)
        'Tryn
        'Intentar generar el documento.
        Dim doc As New Document(PageSize.LETTER, 10, 30, 135, 45)
        'Path que guarda el reporte en el escritorio de windows (Desktop).
        Dim mem As String = ""
        If membretada = True Then
            mem = "membretada"
        Else
            mem = "nomembretada"
        End If
        Dim filename As String = global_dir_cotizaciones + "\COTIZACION-" & Format(id_cotizacion, "000") & "-" & mem & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()

        ExportarCotizacion(doc, writer, id_cotizacion, membretada)
        doc.Close()
        Process.Start(filename)
        'Catch ex As Exception
        'Si el intento es fallido, mostrar MsgBox.
        ' MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' End Try
    End Sub
    
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function

    Public Sub ExportarCotizacion(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_cotizacion As Integer, Optional ByVal membretada As Boolean = True)
        Dim nombre_cliente As String = ""
        Dim mensaje As String = ""
        Dim despedida As String = ""
        Dim fecha As Date

        'Conectar()
        rs.Open("SELECT fecha,mensaje,despedida,nombre_cliente FROM cotizacion WHERE id_cotizacion=" & id_cotizacion, conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            nombre_cliente = rs.Fields("nombre_cliente").Value
            mensaje = rs.Fields("mensaje").Value
            despedida = rs.Fields("despedida").Value

        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        Dim bfR As iTextSharp.text.pdf.BaseFont
        bfR = iTextSharp.text.pdf.BaseFont.CreateFont("ARIALMT.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        Dim bfR2 As iTextSharp.text.pdf.BaseFont
        bfR2 = iTextSharp.text.pdf.BaseFont.CreateFont("FUTURAN.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        Dim cgothic As iTextSharp.text.pdf.BaseFont
        cgothic = iTextSharp.text.pdf.BaseFont.CreateFont("GOTHIC.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)

        Dim ArialMT7 As New Font(bfR, 7, Font.NORMAL)
        Dim ArialMT13 As New Font(bfR, 13.5, Font.BOLD, BaseColor.WHITE)
        Dim ArialMT13_black As New Font(bfR, 13.5, Font.BOLD)
        Dim ArialMT11 As New Font(bfR, 11, Font.NORMAL, BaseColor.WHITE)
        Dim Futuran11 As New Font(bfR2, 11, Font.NORMAL)
        Dim ArialMT12 As New Font(bfR, 12, Font.NORMAL, BaseColor.WHITE)
        Dim ArialMT12_black As New Font(bfR, 12, Font.NORMAL)
        Dim Futuran10 As New Font(bfR2, 10, Font.NORMAL)

        Dim ArialMT10 As New Font(bfR, 9, Font.NORMAL)
        Dim ArialMT8 As New Font(bfR, 8, Font.NORMAL)
        Dim CGothic14 As New Font(cgothic, 14, Font.BOLD)
        Dim CGothic14_white_smok As New Font(cgothic, 14, Font.BOLD, New BaseColor(System.Drawing.Color.FromArgb(-723723)))
        Dim CGothic16_bold As New Font(cgothic, 16, Font.BOLD)
        Dim CGothic16_bold_azul As New Font(cgothic, 16, Font.BOLD, New BaseColor(System.Drawing.Color.FromArgb(-11170101)))

        Dim _espacio As New Paragraph ' Declaracion de un parrafo
        '_alias.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _espacio.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _espacio.Add("  ") 'Texto que se insertara
        '=======================================================================================================
        '                                        TABLA DE COTIZACION
        '======================================================================================================



        Dim membrete As iTextSharp.text.Image
        membrete = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\membrete.png")
        membrete.SetAbsolutePosition(0, 655) 'Posicion en el eje cartesiano
        membrete.ScaleAbsoluteWidth(615) 'Ancho de la imagen
        membrete.ScaleAbsoluteHeight(141) 'Altura de la imagen

        Dim TablaCotizacion As New PdfPTable(7)
        TablaCotizacion.SetWidthPercentage({50, 80, 80, 250, 15, 80, 50}, PageSize.LETTER)


        Dim cell1 As New PdfPCell(New Paragraph("", ArialMT13))
        cell1.MinimumHeight = 40
        cell1.BorderColor = BaseColor.WHITE
        cell1.BorderWidth = 1
        TablaCotizacion.AddCell(cell1)


        Dim _folio As New PdfPCell(New Paragraph("C O T I Z A C I O N " & FormatNumber(id_cotizacion, "0000"), CGothic16_bold))
        _folio.Colspan = 7
        _folio.HorizontalAlignment = Element.ALIGN_CENTER
        _folio.BorderColor = BaseColor.WHITE
        TablaCotizacion.AddCell(_folio)


        Dim cell1b As New PdfPCell(New Paragraph("", ArialMT13))
        cell1b.MinimumHeight = 40
        cell1b.BorderColor = BaseColor.WHITE
        cell1b.BorderWidth = 1
        TablaCotizacion.AddCell(cell1b)


        Dim _fecha As New PdfPCell(New Paragraph(fecha.ToLongDateString, CGothic14))
        _fecha.Colspan = 7
        _fecha.HorizontalAlignment = Element.ALIGN_RIGHT
        _fecha.BorderColor = BaseColor.WHITE
        TablaCotizacion.AddCell(_fecha)

        Dim cell91 As New PdfPCell(New Paragraph("", ArialMT13))
        cell91.BorderColor = BaseColor.WHITE
        cell91.BorderWidth = 1
        TablaCotizacion.AddCell(cell91)

        Dim cell30 As New PdfPCell(New Paragraph("", ArialMT13))
        cell30.Colspan = 7
        cell30.BorderColor = BaseColor.WHITE
        cell30.BorderWidth = 1
        cell30.MinimumHeight = 25
        TablaCotizacion.AddCell(cell30)

        Dim cell301 As New PdfPCell(New Paragraph("", ArialMT13))
        cell301.BorderColor = BaseColor.WHITE
        cell301.BorderWidth = 1
        cell301.MinimumHeight = 20
        TablaCotizacion.AddCell(cell301)

        Dim cell2 As New PdfPCell(New Paragraph("PARA:", CGothic14))
        cell2.BorderColor = BaseColor.WHITE
        cell2.BorderWidth = 1
        TablaCotizacion.AddCell(cell2)

        Dim cliente As New PdfPCell(New Paragraph(nombre_cliente, CGothic14))
        cliente.Colspan = 4
        cliente.PaddingBottom = 5
        'cliente.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-12566463))
        cliente.HorizontalAlignment = Element.ALIGN_LEFT
        'cliente.Border = Nothing
        cliente.BorderWidth = 1
        cliente.BorderColor = BaseColor.WHITE
        TablaCotizacion.AddCell(cliente)

        Dim cell202 As New PdfPCell(New Paragraph(" ", CGothic14))
        cell202.BorderColor = BaseColor.WHITE
        cell202.BorderWidth = 1
        TablaCotizacion.AddCell(cell202)

        Dim cell161 As New PdfPCell(New Paragraph("", CGothic14))
        cell161.BorderColor = BaseColor.WHITE
        cell161.BorderWidth = 1
        cell161.Colspan = 7
        cell161.MinimumHeight = 10
        TablaCotizacion.AddCell(cell161)

        Dim cell15 As New PdfPCell(New Paragraph("", CGothic14))
        cell15.BorderColor = BaseColor.WHITE
        cell15.BorderWidth = 1
        cell15.Rowspan = 2
        TablaCotizacion.AddCell(cell15)

        Dim text1 As New PdfPCell(New Paragraph(mensaje, CGothic14))
        text1.Colspan = 5
        text1.PaddingBottom = 5
        text1.HorizontalAlignment = Element.ALIGN_LEFT
        'text1.Border = Nothing
        text1.BorderWidth = 1
        text1.BorderColor = BaseColor.WHITE
        TablaCotizacion.AddCell(text1)

        Dim cell16 As New PdfPCell(New Paragraph("", CGothic14))
        cell16.BorderColor = BaseColor.WHITE
        cell16.BorderWidth = 1
        cell16.Rowspan = 2
        TablaCotizacion.AddCell(cell16)

        Dim cell3 As New PdfPCell(New Paragraph("", CGothic14))
        cell3.PaddingTop = 8
        cell3.Colspan = 7
        cell3.HorizontalAlignment = Element.ALIGN_RIGHT
        cell3.BorderColor = BaseColor.WHITE
        cell3.BorderWidth = 1
        TablaCotizacion.AddCell(cell3)

        Dim cell18 As New PdfPCell(New Paragraph("", CGothic14))
        cell18.BorderColor = BaseColor.WHITE
        cell18.BorderWidth = 1
        TablaCotizacion.AddCell(cell18)

        Dim label_codigo As New PdfPCell(New Paragraph("CODIGO", CGothic14_white_smok))
        label_codigo.BorderWidthRight = 1.5
        label_codigo.BorderColor = BaseColor.WHITE
        label_codigo.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-8289662))
        label_codigo.PaddingBottom = 5
        label_codigo.PaddingTop = 5
        label_codigo.HorizontalAlignment = Element.ALIGN_CENTER
        TablaCotizacion.AddCell(label_codigo)

        Dim label_unidad As New PdfPCell(New Paragraph("UNIDAD", CGothic14_white_smok))
        label_unidad.BorderWidthRight = 1.5
        label_unidad.BorderColor = BaseColor.WHITE
        label_unidad.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-8289662))
        label_unidad.PaddingBottom = 5
        label_unidad.PaddingTop = 5
        label_unidad.HorizontalAlignment = Element.ALIGN_CENTER
        TablaCotizacion.AddCell(label_unidad)

        Dim label_producto As New PdfPCell(New Paragraph("PRODUCTO", CGothic14_white_smok))
        label_producto.BorderWidthRight = 1.5
        label_producto.BorderColor = BaseColor.WHITE
        label_producto.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-8289662))
        label_producto.PaddingBottom = 5
        label_producto.PaddingTop = 5
        label_producto.HorizontalAlignment = Element.ALIGN_CENTER
        TablaCotizacion.AddCell(label_producto)

        Dim label_precio As New PdfPCell(New Paragraph("PRECIO", CGothic14_white_smok))
        label_precio.Colspan = 2
        label_precio.BorderWidthRight = 1.5
        label_precio.BorderColor = BaseColor.WHITE
        label_precio.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-8289662))
        label_precio.PaddingBottom = 5
        label_precio.PaddingTop = 5
        label_precio.HorizontalAlignment = Element.ALIGN_CENTER
        TablaCotizacion.AddCell(label_precio)

        Dim cell19 As New PdfPCell(New Paragraph("", CGothic14))
        cell19.BorderColor = BaseColor.WHITE
        cell19.BorderWidth = 1
        TablaCotizacion.AddCell(cell19)

        Dim max_rows As Integer = 11
        Dim format As Integer = 0
        'Conectar()
        rs.Open("SELECT producto.codigo,cotizacion_detalle.descripcion,cotizacion_detalle.cantidad,cotizacion_detalle.unidad,cotizacion_detalle.precio_unitario FROM cotizacion_detalle JOIN producto ON producto.id_producto=cotizacion_detalle.id_producto WHERE id_cotizacion=" & id_cotizacion, conn)
        If rs.RecordCount > 0 Then
            max_rows = max_rows - rs.RecordCount
            While Not rs.EOF
                Dim cell100 As New PdfPCell(New Paragraph("", CGothic14))
                cell100.BorderColor = BaseColor.WHITE
                cell100.BorderWidth = 1
                TablaCotizacion.AddCell(cell100)

                Dim codigo001 As New PdfPCell(New Paragraph(rs.Fields("codigo").Value, CGothic14))
                codigo001.PaddingTop = 2
                codigo001.PaddingBottom = 5
                codigo001.HorizontalAlignment = Element.ALIGN_CENTER
                codigo001.BorderWidthTop = 0
                codigo001.BorderWidthBottom = 0
                codigo001.BorderWidthLeft = 0
                codigo001.BorderWidthRight = 2
                codigo001.BorderColor = BaseColor.WHITE
                If format = 1 Then
                    codigo001.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2299917))
                End If
                TablaCotizacion.AddCell(codigo001)

                Dim unidad001 As New PdfPCell(New Paragraph(rs.Fields("unidad").Value, CGothic14))
                unidad001.PaddingTop = 2
                unidad001.PaddingBottom = 5
                unidad001.HorizontalAlignment = Element.ALIGN_CENTER
                unidad001.BorderWidthTop = 0
                unidad001.BorderWidthBottom = 0
                unidad001.BorderWidthLeft = 0
                unidad001.BorderWidthRight = 2
                unidad001.BorderColor = BaseColor.WHITE
                If format = 1 Then
                    unidad001.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2299917))
                End If
                TablaCotizacion.AddCell(unidad001)


                Dim concepto001 As New PdfPCell(New Paragraph(rs.Fields("descripcion").Value, CGothic14))
                ' concepto001.Colspan = 2
                concepto001.PaddingTop = 2
                concepto001.PaddingBottom = 5
                concepto001.PaddingLeft = 4
                concepto001.HorizontalAlignment = Element.ALIGN_LEFT
                concepto001.BorderWidthTop = 0
                concepto001.BorderWidthBottom = 0
                concepto001.BorderWidthLeft = 0
                concepto001.BorderWidthRight = 2
                concepto001.BorderColor = BaseColor.WHITE
                If format = 1 Then
                    concepto001.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2299917))
                End If
                TablaCotizacion.AddCell(concepto001)

                Dim signo0201 As New PdfPCell(New Paragraph("$", CGothic14))
                signo0201.PaddingTop = 2
                signo0201.PaddingBottom = 5
                signo0201.HorizontalAlignment = Element.ALIGN_CENTER
                signo0201.BorderWidth = 0
                If format = 1 Then
                    signo0201.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2299917))
                End If
                TablaCotizacion.AddCell(signo0201)

                Dim precio001 As New PdfPCell(New Paragraph(Replace(FormatCurrency(rs.Fields("precio_unitario").Value), "$", ""), CGothic14))
                precio001.PaddingTop = 2
                precio001.PaddingBottom = 5
                precio001.PaddingRight = 5
                precio001.HorizontalAlignment = Element.ALIGN_RIGHT
                precio001.BorderWidthTop = 0
                precio001.BorderWidthBottom = 0
                precio001.BorderWidthLeft = 0
                precio001.BorderWidthRight = 2
                precio001.BorderColor = BaseColor.WHITE
                If format = 1 Then
                    precio001.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-2299917))
                End If
                TablaCotizacion.AddCell(precio001)


                Dim cell101 As New PdfPCell(New Paragraph("", CGothic14))
                cell101.BorderColor = BaseColor.WHITE
                cell101.BorderWidth = 1
                TablaCotizacion.AddCell(cell101)

                If format = 0 Then
                    format = 1
                Else
                    format = 0
                End If

                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        For x = 0 To max_rows - 1
            Dim cell100 As New PdfPCell(New Paragraph("", CGothic14))
            cell100.BorderColor = BaseColor.WHITE
            cell100.BorderWidth = 1
            TablaCotizacion.AddCell(cell100)

            Dim codigo001 As New PdfPCell(New Paragraph(" ", CGothic16_bold_azul))
            codigo001.PaddingTop = 2
            codigo001.PaddingBottom = 5
            codigo001.HorizontalAlignment = Element.ALIGN_CENTER
            codigo001.BorderWidthTop = 0
            codigo001.BorderWidthBottom = 0
            codigo001.BorderWidthLeft = 0
            codigo001.BorderWidthRight = 2
            codigo001.BorderColor = BaseColor.WHITE
            TablaCotizacion.AddCell(codigo001)

            Dim unidad001 As New PdfPCell(New Paragraph(" ", CGothic16_bold))
            unidad001.PaddingTop = 2
            unidad001.PaddingBottom = 5
            unidad001.HorizontalAlignment = Element.ALIGN_CENTER
            unidad001.BorderWidthTop = 0
            unidad001.BorderWidthBottom = 0
            unidad001.BorderWidthLeft = 0
            unidad001.BorderWidthRight = 2
            unidad001.BorderColor = BaseColor.WHITE
            TablaCotizacion.AddCell(unidad001)


            Dim concepto001 As New PdfPCell(New Paragraph(" ", CGothic16_bold))
            ' concepto001.Colspan = 2
            concepto001.PaddingTop = 5
            concepto001.PaddingBottom = 5
            concepto001.PaddingLeft = 4
            concepto001.HorizontalAlignment = Element.ALIGN_LEFT
            concepto001.BorderWidthTop = 0
            concepto001.BorderWidthBottom = 0
            concepto001.BorderWidthLeft = 0
            concepto001.BorderWidthRight = 2
            concepto001.BorderColor = BaseColor.WHITE
            TablaCotizacion.AddCell(concepto001)

            Dim signo0201 As New PdfPCell(New Paragraph(" ", CGothic14))
            signo0201.PaddingTop = 2
            signo0201.PaddingBottom = 5
            signo0201.HorizontalAlignment = Element.ALIGN_CENTER
            signo0201.BorderWidth = 0
            TablaCotizacion.AddCell(signo0201)

            Dim precio001 As New PdfPCell(New Paragraph(" ", CGothic16_bold))
            precio001.PaddingTop = 2
            precio001.PaddingBottom = 5
            precio001.PaddingRight = 5
            precio001.HorizontalAlignment = Element.ALIGN_RIGHT
            precio001.BorderWidthTop = 0
            precio001.BorderWidthBottom = 0
            precio001.BorderWidthLeft = 0
            precio001.BorderWidthRight = 2
            precio001.BorderColor = BaseColor.WHITE
            TablaCotizacion.AddCell(precio001)


            Dim cell101 As New PdfPCell(New Paragraph(" ", CGothic14))
            cell101.BorderColor = BaseColor.WHITE
            cell101.BorderWidth = 1
            TablaCotizacion.AddCell(cell101)
        Next

        Dim cell20 As New PdfPCell(New Paragraph("", CGothic14))
        cell20.Colspan = 7
        cell20.BorderColor = BaseColor.WHITE
        cell20.BorderWidth = 1
        cell20.MinimumHeight = 10
        TablaCotizacion.AddCell(cell20)

        Dim cell21 As New PdfPCell(New Paragraph("", CGothic14))
        cell21.BorderColor = BaseColor.WHITE
        cell21.BorderWidth = 1
        cell21.Rowspan = 2
        TablaCotizacion.AddCell(cell21)

        Dim text2 As New PdfPCell(New Paragraph(despedida, CGothic14))
        text2.Colspan = 5
        text2.Rowspan = 2
        text2.PaddingBottom = 5
        text2.HorizontalAlignment = Element.ALIGN_LEFT
        'text2.Border = Nothing
        text2.BorderWidth = 1
        text2.BorderColor = BaseColor.WHITE
        TablaCotizacion.AddCell(text2)

        Dim cell22 As New PdfPCell(New Paragraph("", CGothic14))
        cell22.BorderColor = BaseColor.WHITE
        cell22.BorderWidth = 1
        cell22.Rowspan = 2
        TablaCotizacion.AddCell(cell22)

        Dim cell201 As New PdfPCell(New Paragraph("", CGothic14))
        cell201.Colspan = 7
        cell201.BorderColor = BaseColor.WHITE
        cell201.BorderWidth = 1
        cell201.MinimumHeight = 50
        TablaCotizacion.AddCell(cell201)

        Dim cell5 As New PdfPCell(New Paragraph("", ArialMT7))
        cell5.BorderColor = BaseColor.WHITE
        cell5.BorderWidth = 1
        cell5.Colspan = 2
        TablaCotizacion.AddCell(cell5)

        Dim atentamente As New PdfPCell(New Paragraph(global_razon_social, CGothic14))
        atentamente.Colspan = 2
        atentamente.HorizontalAlignment = Element.ALIGN_CENTER
        atentamente.BorderColor = BaseColor.WHITE
        atentamente.BorderWidth = 1
        TablaCotizacion.AddCell(atentamente)

        Dim cell6 As New PdfPCell(New Paragraph("", ArialMT7))
        cell6.BorderColor = BaseColor.WHITE
        cell6.BorderWidth = 1
        cell6.Colspan = 3
        TablaCotizacion.AddCell(cell6)




        TablaCotizacion.HorizontalAlignment = Element.ALIGN_RIGHT


        '=======================================================================================================
        '                                        FIN TABLA FACTURA CLIENTE
        '=======================================================================================================
        If membretada = True Then
            document.Add(membrete)
        End If
        document.Add(TablaCotizacion)

    End Sub
    Private Function centrar_texto(ByVal cadena As String, ByVal valor_maximo As Integer) As String
        Dim center_string As String = cadena
        Dim longitud_cadena As Integer = Len(cadena)
        Dim espacios As String = ""
        Dim x As Integer
        If longitud_cadena < valor_maximo Then
            Dim len As Integer = CInt((valor_maximo - longitud_cadena) / 2)
            For x = 1 To len
                espacios += " "
            Next
            center_string = espacios & cadena '& espacios
        End If
        Return center_string
    End Function
End Module





