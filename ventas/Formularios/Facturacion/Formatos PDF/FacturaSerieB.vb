Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System

Module FacturaSerieB
    Public Sub GenerarFacturaSerieB(ByVal id_factura As Integer, ByVal concepto_general As Boolean, ByVal cadena_concepto As String)
        'Tryn
        'Intentar generar el documento.
        Dim doc As New Document(PageSize.LETTER, 10, 55, 55, 45)
        'Path que guarda el reporte en el escritorio de windows (Desktop).
        Dim generado As String = Format(Today.Date, "dd-MM-yyyy")
        Dim num As String = "000"
        'Conectar()
        rs.Open("SELECT numero FROM factura WHERE id_factura=" & id_factura, conn)
        If rs.RecordCount > 0 Then
            num = Format(rs.Fields("numero").Value, "000")
        End If
        rs.Close()
        'conn.close()
        Dim filename As String = global_dir_facturas + "\FACTURA-" & num & " SERIEB.pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        ExportarDatosPDF_SerieB(doc, writer, id_factura, concepto_general, cadena_concepto)
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
    Public Sub ExportarDatosPDF_SerieB(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_factura As Integer, ByVal concepto_general As Boolean, ByVal cadena_concepto As String)
        '=========================================================================
        'variables a utilizar
        Dim _folio As String = ""
        Dim _nombre As String = ""
        Dim _direccion As String = ""
        Dim _ciudad As String = ""
        Dim _cp As String = ""
        Dim _rfc As String = ""
        Dim _total_letra As String = ""
        Dim _subtotal As String = ""
        Dim _iva As String = ""
        Dim _total As String = ""
        Dim id_cliente As Integer = 0
        Dim id_domicilio As Integer = 0
        Dim _fecha As Date

        'Conectar()
        rs.Open("SELECT factura.fecha,factura.subtotal,factura.iva,factura.total,factura.numero,cliente.id_cliente,cliente.id_domicilio, CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,(SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END as rfc FROM cliente JOIN  factura ON factura.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura.id_factura=" & id_factura & ")As RFC FROM factura JOIN cliente ON factura.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura.id_factura=" & id_factura, conn)
        If rs.RecordCount > 0 Then
            _folio = Format(rs.Fields("numero").Value, "000")
            id_cliente = rs.Fields("id_cliente").Value
            _nombre = rs.Fields("nombre").Value
            _rfc = rs.Fields("rfc").Value
            _subtotal = Replace(FormatCurrency(rs.Fields("subtotal").Value), "$", "")
            _iva = Replace(FormatCurrency(rs.Fields("iva").Value), "$", "")
            _total = Replace(FormatCurrency(rs.Fields("total").Value), "$", "")
            id_domicilio = rs.Fields("id_domicilio").Value
            _total_letra = Letras(CDbl(rs.Fields("total").Value))
            _fecha = rs.Fields("fecha").Value
        End If
        rs.Close()

        rs.Open("SELECT CONCAT(calle,' ',colonia,' ',municipio) domicilio,cp AS cp,municipio,poblacion FROM domicilio WHERE id_domicilio=" & id_domicilio, conn)
        If rs.RecordCount > 0 Then
            _direccion = rs.Fields("domicilio").Value
            _cp = rs.Fields("cp").Value
            _ciudad = rs.Fields("poblacion").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        '=========================================================================

        Dim bfR As iTextSharp.text.pdf.BaseFont
        bfR = iTextSharp.text.pdf.BaseFont.CreateFont("ARIALMT.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        Dim bfR2 As iTextSharp.text.pdf.BaseFont
        bfR2 = iTextSharp.text.pdf.BaseFont.CreateFont("FUTURAN.TTF", iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED)
        Dim ArialMT7 As New Font(bfR, 7, Font.NORMAL)
        Dim ArialMT13 As New Font(bfR, 13.5, Font.BOLD, BaseColor.WHITE)
        Dim ArialMT13_black As New Font(bfR, 13.5, Font.BOLD)
        Dim ArialMT11 As New Font(bfR, 11, Font.NORMAL, BaseColor.WHITE)
        Dim Futuran11 As New Font(bfR2, 11, Font.NORMAL)
        Dim Futuran09 As New Font(bfR2, 9, Font.NORMAL)
        Dim ArialMT12 As New Font(bfR, 12, Font.NORMAL, BaseColor.WHITE)
        Dim ArialMT12_black As New Font(bfR, 12, Font.NORMAL)
        Dim ArialMT10_black As New Font(bfR, 10, Font.NORMAL)
        Dim Futuran10 As New Font(bfR2, 10, Font.NORMAL)

        Dim ArialMT10 As New Font(bfR, 9, Font.NORMAL)
        Dim ArialMT8 As New Font(bfR, 8, Font.NORMAL)

        Dim _espacio As New Paragraph ' Declaracion de un parrafo
        '_alias.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _espacio.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _espacio.Add("  ") 'Texto que se insertara
        '=======================================================================================================
        '                                        TABLA DE FACTURA SERIE
        '======================================================================================================


        Dim imagendemo As iTextSharp.text.Image
        imagendemo = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\logo.png")
        imagendemo.SetAbsolutePosition(50, 620) 'Posicion en el eje cartesiano
        imagendemo.ScaleAbsoluteWidth(200) 'Ancho de la imagen
        imagendemo.ScaleAbsoluteHeight(125) 'Altura de la imagen

        Dim TablaSerie As New PdfPTable(7)
        TablaSerie.SetWidthPercentage({33, 33, 38, 90, 30, 38, 45}, PageSize.LETTER)


        Dim cell1 As New PdfPCell(New Paragraph("", ArialMT13))
        cell1.Colspan = 2
        cell1.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(cell1)

        Dim cell2 As New PdfPCell(New Paragraph("", ArialMT13))
        cell2.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(cell2)

        Dim factura As New PdfPCell(New Paragraph("FACTURA", ArialMT13))
        factura.PaddingBottom = 5
        factura.HorizontalAlignment = Element.ALIGN_CENTER
        factura.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        factura.BorderColor = BaseColor.WHITE
        factura.BorderWidthRight = 3
        TablaSerie.AddCell(factura)

        Dim serie As New PdfPCell(New Paragraph("SERIE B", ArialMT13))
        serie.Colspan = 2
        serie.PaddingBottom = 5
        serie.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-12566463))
        serie.HorizontalAlignment = Element.ALIGN_CENTER
        serie.Border = Nothing
        TablaSerie.AddCell(serie)

        Dim folio As New PdfPCell(New Paragraph(_folio, ArialMT13_black))
        folio.PaddingBottom = 5
        folio.HorizontalAlignment = Element.ALIGN_CENTER
        folio.Border = Nothing
        TablaSerie.AddCell(folio)

        Dim regimen As New PdfPCell(New Paragraph("REGIMEN INTERMEDIO CON ACTIVIDAD EMPRESARIAL", ArialMT7))
        regimen.PaddingTop = 8
        regimen.Colspan = 7
        regimen.HorizontalAlignment = Element.ALIGN_RIGHT
        regimen.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(regimen)

        Dim razon As New PdfPCell(New Paragraph("ARCELIA CASTELLANOS HERNANDEZ", ArialMT7))
        razon.Colspan = 7
        razon.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(razon)

        Dim domicilio As New PdfPCell(New Paragraph("MORELOS S/N LOCALES 26 Y 32 COL. CENTRO. OAXACA DE JUAREZ,OAX.", ArialMT7))
        domicilio.Colspan = 7
        domicilio.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(domicilio)

        Dim rfc As New PdfPCell(New Paragraph("R.F.C. CAHA840519CQ8", ArialMT7))
        rfc.Colspan = 3
        rfc.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(rfc)

        Dim curp As New PdfPCell(New Paragraph("CURP. CAHA840519MOCSRR08", ArialMT7))
        curp.Colspan = 4
        curp.HorizontalAlignment = Element.ALIGN_RIGHT
        curp.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(curp)

        Dim email As New PdfPCell(New Paragraph("ventas@lacteosarce.com", ArialMT7))
        email.Colspan = 3
        email.PaddingBottom = 8
        email.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(email)

        Dim telefono As New PdfPCell(New Paragraph("Atención al cliente: (951) 1324181", ArialMT7))
        telefono.Colspan = 4
        telefono.HorizontalAlignment = Element.ALIGN_RIGHT
        telefono.BorderColor = BaseColor.WHITE
        telefono.PaddingBottom = 8
        TablaSerie.AddCell(telefono)

        Dim e_dia As New PdfPCell(New Paragraph("DÍA:", ArialMT11))
        e_dia.PaddingBottom = 5
        e_dia.HorizontalAlignment = Element.ALIGN_CENTER
        e_dia.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_dia.BorderColor = BaseColor.WHITE
        e_dia.BorderWidthRight = 2
        TablaSerie.AddCell(e_dia)

        Dim dia As New PdfPCell(New Paragraph(Format(_fecha, "dd"), Futuran11))
        dia.PaddingBottom = 5
        dia.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        dia.HorizontalAlignment = Element.ALIGN_CENTER
        dia.BorderColor = BaseColor.WHITE
        dia.BorderWidthRight = 4
        TablaSerie.AddCell(dia)

        Dim e_mes As New PdfPCell(New Paragraph("MES:", ArialMT11))
        e_mes.PaddingBottom = 5
        e_mes.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_mes.HorizontalAlignment = Element.ALIGN_CENTER
        e_mes.BorderColor = BaseColor.WHITE
        e_mes.BorderWidthRight = 2
        TablaSerie.AddCell(e_mes)


        Dim mes As New PdfPCell(New Paragraph(UCase(nombre_mes(Format(_fecha, "MM"))), Futuran11))
        mes.Colspan = 2
        mes.PaddingBottom = 5
        mes.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        mes.HorizontalAlignment = Element.ALIGN_CENTER
        mes.BorderColor = BaseColor.WHITE
        mes.BorderWidthRight = 4
        TablaSerie.AddCell(mes)

        Dim e_año As New PdfPCell(New Paragraph("AÑO:", ArialMT11))
        e_año.PaddingBottom = 5
        e_año.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_año.HorizontalAlignment = Element.ALIGN_CENTER
        e_año.BorderColor = BaseColor.WHITE
        e_año.BorderWidthRight = 2
        TablaSerie.AddCell(e_año)

        Dim año As New PdfPCell(New Paragraph(Format(_fecha, "yyyy"), Futuran11))
        año.PaddingBottom = 5
        año.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        año.HorizontalAlignment = Element.ALIGN_CENTER
        año.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(año)


        TablaSerie.HorizontalAlignment = Element.ALIGN_RIGHT


        '=======================================================================================================
        '                                        FIN TABLA FACTURA CLIENTE
        '=======================================================================================================

        '=======================================================================================================
        '                                        INICIO TABLA DESCRIPCION
        '=======================================================================================================
        Dim TablaDescripcion As New PdfPTable(11) 'declara la tabla con 4 columnas
        TablaDescripcion.SetWidthPercentage({65, 70, 60, 90, 30, 70, 38, 10, 55, 10, 70}, PageSize.LETTER) 'Ajusta el tamaño de cada columna

        Dim e_datos_cliente As New PdfPCell(New Paragraph("Datos de cliente", ArialMT12))
        e_datos_cliente.Colspan = 11
        e_datos_cliente.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_datos_cliente.PaddingBottom = 3
        e_datos_cliente.PaddingRight = 4
        e_datos_cliente.HorizontalAlignment = Element.ALIGN_RIGHT
        e_datos_cliente.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_datos_cliente)

        Dim e_nombre As New PdfPCell(New Paragraph("Nombre:", ArialMT12_black))
        e_nombre.PaddingTop = 7
        e_nombre.PaddingBottom = 5
        e_nombre.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_nombre)

        Dim nombre As New PdfPCell(New Paragraph(_nombre, Futuran11))
        nombre.PaddingTop = 7
        nombre.PaddingBottom = 5
        nombre.BorderWidthTop = 0
        nombre.BorderWidthLeft = 0
        nombre.BorderWidthRight = 0
        nombre.Colspan = 10

        TablaDescripcion.AddCell(nombre)

        Dim e_direccion As New PdfPCell(New Paragraph("Dirección:", ArialMT12_black))
        e_direccion.PaddingTop = 7
        e_direccion.PaddingBottom = 5
        e_direccion.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_direccion)

        Dim direccion As New PdfPCell(New Paragraph(_direccion, Futuran11))
        direccion.PaddingTop = 7
        direccion.PaddingBottom = 5
        direccion.Colspan = 10
        direccion.BorderWidthTop = 0
        direccion.BorderWidthLeft = 0
        direccion.BorderWidthRight = 0
        TablaDescripcion.AddCell(direccion)

        Dim e_ciudad As New PdfPCell(New Paragraph("Ciudad:", ArialMT12_black))
        e_ciudad.PaddingTop = 7
        e_ciudad.PaddingBottom = 5
        e_ciudad.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_ciudad)

        Dim ciudad As New PdfPCell(New Paragraph(_ciudad, Futuran11))
        ciudad.PaddingTop = 7
        ciudad.PaddingBottom = 5
        ciudad.Colspan = 3
        ciudad.BorderWidthTop = 0
        ciudad.BorderWidthLeft = 0
        ciudad.BorderWidthRight = 0
        TablaDescripcion.AddCell(ciudad)

        Dim e_cp As New PdfPCell(New Paragraph("CP:", ArialMT12_black))
        e_cp.PaddingTop = 7
        e_cp.PaddingBottom = 5
        e_cp.BorderWidth = 0
        TablaDescripcion.AddCell(e_cp)

        Dim cp As New PdfPCell(New Paragraph(_cp, Futuran11))
        cp.PaddingTop = 7
        cp.PaddingBottom = 5
        cp.HorizontalAlignment = Element.ALIGN_CENTER
        cp.BorderWidthTop = 0
        cp.BorderWidthLeft = 0
        cp.BorderWidthRight = 0
        TablaDescripcion.AddCell(cp)

        Dim e_rfc As New PdfPCell(New Paragraph("RFC:", ArialMT12_black))
        e_rfc.PaddingTop = 7
        e_rfc.PaddingBottom = 5
        e_rfc.HorizontalAlignment = Element.ALIGN_CENTER
        e_rfc.BorderWidth = 0
        TablaDescripcion.AddCell(e_rfc)



        Dim rfc_cliente As New PdfPCell(New Paragraph(_rfc, Futuran11))
        rfc_cliente.PaddingTop = 7
        rfc_cliente.PaddingBottom = 5
        rfc_cliente.Colspan = 5
        rfc_cliente.BorderWidthTop = 0
        rfc_cliente.BorderWidthLeft = 0
        rfc_cliente.BorderWidthRight = 0
        rfc_cliente.HorizontalAlignment = Element.ALIGN_CENTER
        TablaDescripcion.AddCell(rfc_cliente)

        Dim blank_row As New PdfPCell(New Paragraph("", ArialMT12_black))
        blank_row.Colspan = 11
        blank_row.PaddingTop = 5
        blank_row.PaddingBottom = 5
        blank_row.Border = Nothing
        TablaDescripcion.AddCell(blank_row)


        Dim e_codigo As New PdfPCell(New Paragraph("Código", ArialMT12))
        e_codigo.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_codigo.BorderColor = BaseColor.WHITE
        e_codigo.HorizontalAlignment = Element.ALIGN_CENTER
        e_codigo.BorderWidthRight = 1.5
        e_codigo.PaddingBottom = 4
        TablaDescripcion.AddCell(e_codigo)

        Dim e_cantidad As New PdfPCell(New Paragraph("Cantidad", ArialMT12))
        e_cantidad.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_cantidad.BorderColor = BaseColor.WHITE
        e_cantidad.HorizontalAlignment = Element.ALIGN_CENTER
        e_cantidad.BorderWidthRight = 1.5
        e_cantidad.PaddingBottom = 4
        TablaDescripcion.AddCell(e_cantidad)

        Dim e_unidad As New PdfPCell(New Paragraph("Unidad", ArialMT12))
        e_unidad.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_unidad.BorderColor = BaseColor.WHITE
        e_unidad.HorizontalAlignment = Element.ALIGN_CENTER
        e_unidad.BorderWidthRight = 1.5
        e_unidad.PaddingBottom = 4

        TablaDescripcion.AddCell(e_unidad)

        Dim e_concepto As New PdfPCell(New Paragraph("Concepto", ArialMT12))
        e_concepto.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_concepto.BorderColor = BaseColor.WHITE
        e_concepto.Colspan = 4
        'e_concepto.HorizontalAlignment = Element.ALIGN_CENTER
        e_concepto.PaddingLeft = 5
        e_concepto.BorderWidthRight = 1.5
        e_concepto.PaddingBottom = 4
        TablaDescripcion.AddCell(e_concepto)

        Dim e_precio As New PdfPCell(New Paragraph("Precio", ArialMT12))
        e_precio.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_precio.BorderColor = BaseColor.WHITE
        e_precio.Colspan = 2
        e_precio.HorizontalAlignment = Element.ALIGN_CENTER
        e_precio.BorderWidthRight = 1.5
        e_precio.PaddingBottom = 4
        TablaDescripcion.AddCell(e_precio)

        Dim e_importe As New PdfPCell(New Paragraph("Importe", ArialMT12))
        e_importe.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-16738854))
        e_importe.Colspan = 2
        e_importe.HorizontalAlignment = Element.ALIGN_CENTER
        e_importe.PaddingBottom = 4
        e_importe.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_importe)

        Dim max_rows As Integer = 10

        If concepto_general Then
            Dim codigo001 As New PdfPCell(New Paragraph("B1", Futuran10))
            codigo001.PaddingTop = 5
            codigo001.PaddingBottom = 5
            codigo001.HorizontalAlignment = Element.ALIGN_CENTER
            codigo001.BorderWidthTop = 0
            codigo001.BorderWidthBottom = 0
            codigo001.BorderWidthLeft = 0
            codigo001.BorderWidthRight = 1.5
            codigo001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(codigo001)

            Dim cantidad001 As New PdfPCell(New Paragraph("1", Futuran10))
            cantidad001.PaddingTop = 5
            cantidad001.PaddingBottom = 5
            cantidad001.HorizontalAlignment = Element.ALIGN_CENTER
            cantidad001.BorderWidthTop = 0
            cantidad001.BorderWidthBottom = 0
            cantidad001.BorderWidthLeft = 0
            cantidad001.BorderWidthRight = 1.5
            cantidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(cantidad001)

            Dim unidad001 As New PdfPCell(New Paragraph("", Futuran10))
            unidad001.PaddingTop = 5
            unidad001.PaddingBottom = 5
            unidad001.HorizontalAlignment = Element.ALIGN_CENTER
            unidad001.BorderWidthTop = 0
            unidad001.BorderWidthBottom = 0
            unidad001.BorderWidthLeft = 0
            unidad001.BorderWidthRight = 1.5
            unidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(unidad001)

            Dim concepto001 As New PdfPCell(New Paragraph(cadena_concepto, Futuran10))
            concepto001.Colspan = 4
            concepto001.PaddingTop = 5
            concepto001.PaddingBottom = 5
            concepto001.PaddingLeft = 4
            concepto001.HorizontalAlignment = Element.ALIGN_LEFT
            concepto001.BorderWidthTop = 0
            concepto001.BorderWidthBottom = 0
            concepto001.BorderWidthLeft = 0
            concepto001.BorderWidthRight = 1.5
            concepto001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(concepto001)

            Dim signo0101 As New PdfPCell(New Paragraph(" ", Futuran10))
            signo0101.PaddingTop = 5
            signo0101.PaddingBottom = 5
            signo0101.HorizontalAlignment = Element.ALIGN_CENTER
            signo0101.BorderWidth = 0
            TablaDescripcion.AddCell(signo0101)

            Dim precio001 As New PdfPCell(New Paragraph(_subtotal, Futuran10))
            precio001.PaddingTop = 5
            precio001.PaddingBottom = 5
            precio001.PaddingRight = 5
            precio001.HorizontalAlignment = Element.ALIGN_RIGHT
            precio001.BorderWidthTop = 0
            precio001.BorderWidthBottom = 0
            precio001.BorderWidthLeft = 0
            precio001.BorderWidthRight = 1.5
            precio001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(precio001)


            Dim signo0201 As New PdfPCell(New Paragraph("$", Futuran10))
            signo0201.PaddingTop = 5
            signo0201.PaddingBottom = 5
            signo0201.HorizontalAlignment = Element.ALIGN_CENTER
            signo0201.BorderWidth = 0
            TablaDescripcion.AddCell(signo0201)


            Dim importe001 As New PdfPCell(New Paragraph(_subtotal, Futuran10))
            importe001.PaddingTop = 5
            importe001.PaddingBottom = 5
            importe001.PaddingRight = 5
            importe001.HorizontalAlignment = Element.ALIGN_RIGHT
            importe001.BorderWidth = 0
            TablaDescripcion.AddCell(importe001)

            max_rows = 9
        Else
            'Conectar()
            rs.Open("SELECT factura_detalle.cantidad,factura_detalle.descripcion,factura_detalle.unidad,factura_detalle.precio_unitario,factura_detalle.importe,factura_detalle.total_porcent_iva,factura_detalle.total_porcent_otros, producto.codigo FROM factura_detalle JOIN producto ON producto.id_producto=factura_detalle.id_producto WHERE factura_detalle.id_factura=" & id_factura, conn)
            If rs.RecordCount > 0 Then
                max_rows = max_rows - rs.RecordCount
                While Not rs.EOF
                    Dim codigo001 As New PdfPCell(New Paragraph(rs.Fields("codigo").Value, Futuran10))
                    codigo001.PaddingTop = 5
                    codigo001.PaddingBottom = 5
                    codigo001.HorizontalAlignment = Element.ALIGN_CENTER
                    codigo001.BorderWidthTop = 0
                    codigo001.BorderWidthBottom = 0
                    codigo001.BorderWidthLeft = 0
                    codigo001.BorderWidthRight = 1.5
                    codigo001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(codigo001)

                    Dim cantidad001 As New PdfPCell(New Paragraph(rs.Fields("cantidad").Value, Futuran10))
                    cantidad001.PaddingTop = 5
                    cantidad001.PaddingBottom = 5
                    cantidad001.HorizontalAlignment = Element.ALIGN_CENTER
                    cantidad001.BorderWidthTop = 0
                    cantidad001.BorderWidthBottom = 0
                    cantidad001.BorderWidthLeft = 0
                    cantidad001.BorderWidthRight = 1.5
                    cantidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(cantidad001)

                    Dim unidad001 As New PdfPCell(New Paragraph(rs.Fields("unidad").Value, Futuran10))
                    unidad001.PaddingTop = 5
                    unidad001.PaddingBottom = 5
                    unidad001.HorizontalAlignment = Element.ALIGN_CENTER
                    unidad001.BorderWidthTop = 0
                    unidad001.BorderWidthBottom = 0
                    unidad001.BorderWidthLeft = 0
                    unidad001.BorderWidthRight = 1.5
                    unidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(unidad001)

                    Dim concepto001 As New PdfPCell(New Paragraph(rs.Fields("descripcion").Value, Futuran10))
                    concepto001.Colspan = 4
                    concepto001.PaddingTop = 5
                    concepto001.PaddingBottom = 5
                    concepto001.PaddingLeft = 4
                    concepto001.HorizontalAlignment = Element.ALIGN_LEFT
                    concepto001.BorderWidthTop = 0
                    concepto001.BorderWidthBottom = 0
                    concepto001.BorderWidthLeft = 0
                    concepto001.BorderWidthRight = 1.5
                    concepto001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(concepto001)

                    Dim signo0101 As New PdfPCell(New Paragraph("$", Futuran10))
                    signo0101.PaddingTop = 5
                    signo0101.PaddingBottom = 5
                    signo0101.HorizontalAlignment = Element.ALIGN_CENTER
                    signo0101.BorderWidth = 0
                    TablaDescripcion.AddCell(signo0101)

                    Dim precio001 As New PdfPCell(New Paragraph(Replace(FormatCurrency(rs.Fields("precio_unitario").Value), "$", ""), Futuran10))
                    precio001.PaddingTop = 5
                    precio001.PaddingBottom = 5
                    precio001.PaddingRight = 5
                    precio001.HorizontalAlignment = Element.ALIGN_RIGHT
                    precio001.BorderWidthTop = 0
                    precio001.BorderWidthBottom = 0
                    precio001.BorderWidthLeft = 0
                    precio001.BorderWidthRight = 1.5
                    precio001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(precio001)


                    Dim signo0201 As New PdfPCell(New Paragraph("$", Futuran10))
                    signo0201.PaddingTop = 5
                    signo0201.PaddingBottom = 5
                    signo0201.HorizontalAlignment = Element.ALIGN_CENTER
                    signo0201.BorderWidth = 0
                    TablaDescripcion.AddCell(signo0201)


                    Dim importe001 As New PdfPCell(New Paragraph(Replace(FormatCurrency(rs.Fields("importe").Value), "$", ""), Futuran10))
                    importe001.PaddingTop = 5
                    importe001.PaddingBottom = 5
                    importe001.PaddingRight = 5
                    importe001.HorizontalAlignment = Element.ALIGN_RIGHT
                    importe001.BorderWidth = 0
                    TablaDescripcion.AddCell(importe001)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
        End If

        For x = 1 To max_rows

            Dim codigo001 As New PdfPCell(New Paragraph(" ", Futuran10))
            codigo001.PaddingTop = 5
            codigo001.PaddingBottom = 5
            codigo001.HorizontalAlignment = Element.ALIGN_CENTER
            codigo001.BorderWidthTop = 0
            codigo001.BorderWidthBottom = 0
            codigo001.BorderWidthLeft = 0
            codigo001.BorderWidthRight = 1.5
            codigo001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(codigo001)

            Dim cantidad001 As New PdfPCell(New Paragraph(" ", Futuran10))
            cantidad001.PaddingTop = 5
            cantidad001.PaddingBottom = 5
            cantidad001.HorizontalAlignment = Element.ALIGN_CENTER
            cantidad001.BorderWidthTop = 0
            cantidad001.BorderWidthBottom = 0
            cantidad001.BorderWidthLeft = 0
            cantidad001.BorderWidthRight = 1.5
            cantidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(cantidad001)

            Dim unidad001 As New PdfPCell(New Paragraph(" ", Futuran10))
            unidad001.PaddingTop = 5
            unidad001.PaddingBottom = 5
            unidad001.HorizontalAlignment = Element.ALIGN_CENTER
            unidad001.BorderWidthTop = 0
            unidad001.BorderWidthBottom = 0
            unidad001.BorderWidthLeft = 0
            unidad001.BorderWidthRight = 1.5
            unidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(unidad001)

            Dim concepto001 As New PdfPCell(New Paragraph(" ", Futuran10))
            concepto001.Colspan = 4
            concepto001.PaddingTop = 5
            concepto001.PaddingBottom = 5
            concepto001.PaddingLeft = 4
            concepto001.HorizontalAlignment = Element.ALIGN_LEFT
            concepto001.BorderWidthTop = 0
            concepto001.BorderWidthBottom = 0
            concepto001.BorderWidthLeft = 0
            concepto001.BorderWidthRight = 1.5
            concepto001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(concepto001)

            Dim signo0101 As New PdfPCell(New Paragraph(" ", Futuran10))
            signo0101.PaddingTop = 5
            signo0101.PaddingBottom = 5
            signo0101.HorizontalAlignment = Element.ALIGN_CENTER
            signo0101.BorderWidth = 0
            TablaDescripcion.AddCell(signo0101)

            Dim precio001 As New PdfPCell(New Paragraph(" ", Futuran10))
            precio001.PaddingTop = 5
            precio001.PaddingBottom = 5
            precio001.PaddingRight = 5
            precio001.HorizontalAlignment = Element.ALIGN_RIGHT
            precio001.BorderWidthTop = 0
            precio001.BorderWidthBottom = 0
            precio001.BorderWidthLeft = 0
            precio001.BorderWidthRight = 1.5
            precio001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(precio001)


            Dim signo0201 As New PdfPCell(New Paragraph(" ", Futuran10))
            signo0201.PaddingTop = 5
            signo0201.PaddingBottom = 5
            signo0201.HorizontalAlignment = Element.ALIGN_CENTER
            signo0201.BorderWidth = 0
            TablaDescripcion.AddCell(signo0201)


            Dim importe001 As New PdfPCell(New Paragraph(" ", Futuran10))
            importe001.PaddingTop = 5
            importe001.PaddingBottom = 5
            importe001.PaddingRight = 5
            importe001.HorizontalAlignment = Element.ALIGN_RIGHT
            importe001.BorderWidth = 0
            TablaDescripcion.AddCell(importe001)


        Next


        TablaDescripcion.HorizontalAlignment = Element.ALIGN_RIGHT
        '=======================================================================================================
        '                                        FIN TABLA DESCRIPCION
        '=======================================================================================================

        Dim Tablatotales As New PdfPTable(7)
        Tablatotales.SetWidthPercentage({15, 125, 15, 220, 93, 15, 75}, PageSize.LETTER) 'Ajusta el tamaño de cada columna

        Dim e_total_letra As New PdfPCell(New Paragraph("Total con letra:", ArialMT12_black))
        e_total_letra.Colspan = 7
        e_total_letra.PaddingBottom = 3
        e_total_letra.PaddingRight = 4
        e_total_letra.PaddingTop = 10
        e_total_letra.HorizontalAlignment = Element.ALIGN_LEFT
        e_total_letra.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(e_total_letra)

        Dim total_letra As New PdfPCell(New Paragraph(_total_letra, Futuran09))
        total_letra.Colspan = 4
        total_letra.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        total_letra.PaddingTop = 7
        total_letra.PaddingBottom = 7
        total_letra.HorizontalAlignment = Element.ALIGN_CENTER
        total_letra.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(total_letra)


        Dim e_subtotal As New PdfPCell(New Paragraph("SUBTOTAL:", ArialMT12_black))
        e_subtotal.PaddingBottom = 3
        e_subtotal.PaddingRight = 10
        e_subtotal.PaddingTop = 7
        e_subtotal.HorizontalAlignment = Element.ALIGN_RIGHT
        e_subtotal.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(e_subtotal)

        Dim signo03 As New PdfPCell(New Paragraph("$", Futuran11))
        signo03.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        signo03.PaddingBottom = 3
        signo03.PaddingRight = 4
        signo03.PaddingTop = 7
        signo03.HorizontalAlignment = Element.ALIGN_RIGHT
        signo03.BorderColorTop = BaseColor.WHITE
        signo03.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        signo03.BorderColorLeft = BaseColor.WHITE
        signo03.BorderWidthRight = 0
        Tablatotales.AddCell(signo03)

        Dim subtotal As New PdfPCell(New Paragraph(_subtotal, Futuran11))
        subtotal.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        subtotal.PaddingBottom = 3
        subtotal.PaddingRight = 4
        subtotal.PaddingTop = 7
        subtotal.HorizontalAlignment = Element.ALIGN_RIGHT
        subtotal.BorderColorTop = BaseColor.WHITE
        subtotal.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        subtotal.BorderWidthLeft = 0
        subtotal.BorderWidthRight = 0
        subtotal.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))

        Tablatotales.AddCell(subtotal)


        Dim forma_pago As New PdfPCell(New Paragraph("FORMA DE PAGO.", ArialMT12_black))
        forma_pago.Colspan = 4
        forma_pago.PaddingTop = 13
        forma_pago.PaddingBottom = 6
        forma_pago.PaddingRight = 4
        forma_pago.HorizontalAlignment = Element.ALIGN_LEFT
        forma_pago.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(forma_pago)


        Dim e_iva As New PdfPCell(New Paragraph("I.V.A. 16 %", ArialMT12_black))
        e_iva.PaddingBottom = 3
        e_iva.PaddingRight = 10
        e_iva.PaddingTop = 10
        e_iva.HorizontalAlignment = Element.ALIGN_RIGHT
        e_iva.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(e_iva)

        Dim signo04 As New PdfPCell(New Paragraph("$", Futuran11))
        signo04.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        signo04.PaddingBottom = 3
        signo04.PaddingRight = 4
        signo04.BorderWidthTop = 5
        signo04.PaddingTop = 10
        signo04.HorizontalAlignment = Element.ALIGN_RIGHT
        signo04.BorderColorTop = BaseColor.WHITE
        signo04.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        signo04.BorderColorLeft = BaseColor.WHITE
        signo04.BorderWidthRight = 0
        Tablatotales.AddCell(signo04)

        Dim total_iva As New PdfPCell(New Paragraph(_iva, Futuran11))
        total_iva.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        total_iva.PaddingBottom = 3
        total_iva.PaddingRight = 4
        total_iva.BorderWidthTop = 5
        total_iva.PaddingTop = 10
        total_iva.HorizontalAlignment = Element.ALIGN_RIGHT
        total_iva.BorderColorTop = BaseColor.WHITE
        total_iva.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        total_iva.BorderWidthLeft = 0
        total_iva.BorderWidthRight = 0
        Tablatotales.AddCell(total_iva)


        Dim op_exhibicion As New PdfPCell(New Paragraph("", Futuran10))
        op_exhibicion.HorizontalAlignment = Element.ALIGN_CENTER
        Tablatotales.AddCell(op_exhibicion)

        Dim exhibicion As New PdfPCell(New Paragraph("En una sola exhibición.", ArialMT10))
        exhibicion.BorderWidthRight = 0
        exhibicion.BorderWidthTop = 0
        exhibicion.BorderWidthBottom = 0
        Tablatotales.AddCell(exhibicion)

        Dim op_cheque As New PdfPCell(New Paragraph("", Futuran10))
        Tablatotales.AddCell(op_cheque)

        Dim cheque As New PdfPCell(New Paragraph("Cheque.", ArialMT10))
        cheque.Border = 0
        Tablatotales.AddCell(cheque)

        Dim e_total As New PdfPCell(New Paragraph("TOTAL:", ArialMT12_black))
        e_total.Rowspan = 3
        e_total.PaddingBottom = 3
        e_total.PaddingRight = 10
        e_total.PaddingTop = 10
        e_total.HorizontalAlignment = Element.ALIGN_RIGHT
        e_total.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(e_total)

        Dim signo05 As New PdfPCell(New Paragraph("$", Futuran11))
        signo05.Rowspan = 3
        signo05.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        signo05.PaddingBottom = 3
        signo05.PaddingRight = 4
        signo05.PaddingTop = 10
        signo05.BorderWidthTop = 5
        signo05.BorderWidthBottom = 3
        signo05.HorizontalAlignment = Element.ALIGN_RIGHT
        signo05.BorderColorTop = BaseColor.WHITE
        signo05.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        signo05.BorderColorLeft = BaseColor.WHITE
        signo05.BorderWidthRight = 0
        Tablatotales.AddCell(signo05)

        Dim total As New PdfPCell(New Paragraph(_total, Futuran11))
        total.Rowspan = 3
        total.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        total.PaddingBottom = 3
        total.PaddingRight = 4
        total.BorderWidthTop = 5
        total.BorderWidthBottom = 3
        total.PaddingTop = 10
        total.HorizontalAlignment = Element.ALIGN_RIGHT
        total.BorderColorTop = BaseColor.WHITE
        total.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(-3610893))
        total.BorderWidthLeft = 0
        total.BorderWidthRight = 0
        Tablatotales.AddCell(total)

        Dim blank001_c1 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c1.Border = 0
        Tablatotales.AddCell(blank001_c1)

        Dim blank001_c2 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c2.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank001_c2)

        Dim blank001_c3 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c3.Border = 0
        Tablatotales.AddCell(blank001_c3)

        Dim blank001_c4 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c4.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank001_c4)

        Dim op_parcialidades As New PdfPCell(New Paragraph("", Futuran10))
        op_parcialidades.HorizontalAlignment = Element.ALIGN_CENTER
        Tablatotales.AddCell(op_parcialidades)

        Dim parcialidades As New PdfPCell(New Paragraph("En parcialidades.", ArialMT10))
        parcialidades.BorderWidthRight = 0
        parcialidades.BorderWidthTop = 0
        parcialidades.BorderWidthBottom = 0
        Tablatotales.AddCell(parcialidades)

        Dim op_transferencia As New PdfPCell(New Paragraph("", Futuran10))
        op_transferencia.HorizontalAlignment = Element.ALIGN_CENTER
        Tablatotales.AddCell(op_transferencia)

        Dim trasferencia As New PdfPCell(New Paragraph("Transferencia electrónica.", ArialMT10))
        trasferencia.Border = 0
        Tablatotales.AddCell(trasferencia)


        Dim blank002_c1 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c1.Border = 0
        Tablatotales.AddCell(blank002_c1)

        Dim blank002_c2 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c2.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank002_c2)

        Dim blank002_c3 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c3.Border = 0
        Tablatotales.AddCell(blank002_c3)

        Dim blank002_c4 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c4.Colspan = 4
        blank002_c4.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank002_c4)


        Dim op_tarjeta As New PdfPCell(New Paragraph("", Futuran10))
        Tablatotales.AddCell(op_tarjeta)

        Dim tarjeta As New PdfPCell(New Paragraph("Tarjeta de crédito.", ArialMT10))
        tarjeta.BorderWidthRight = 0
        tarjeta.BorderWidthTop = 0
        tarjeta.BorderWidthBottom = 0
        Tablatotales.AddCell(tarjeta)

        Dim op_efectivo As New PdfPCell(New Paragraph("", Futuran10))
        Tablatotales.AddCell(op_efectivo)

        Dim efectivo As New PdfPCell(New Paragraph("Efectivo.", ArialMT10))
        efectivo.Colspan = 4
        efectivo.Border = 0
        Tablatotales.AddCell(efectivo)

        Dim blank003_c1 As New PdfPCell(New Paragraph("", ArialMT7))
        blank003_c1.Border = 0
        Tablatotales.AddCell(blank003_c1)

        Dim blank003_c2 As New PdfPCell(New Paragraph("", ArialMT7))
        blank003_c2.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank003_c2)

        Dim blank003_c3 As New PdfPCell(New Paragraph("", ArialMT7))
        blank003_c3.Border = 0
        Tablatotales.AddCell(blank003_c3)

        Dim blank003_c4 As New PdfPCell(New Paragraph("", ArialMT7))
        blank003_c4.Colspan = 4
        blank003_c4.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank003_c4)

        Dim op_noidentif As New PdfPCell(New Paragraph("", Futuran10))
        Tablatotales.AddCell(op_noidentif)

        Dim noidentificado As New PdfPCell(New Paragraph("No identificado.", ArialMT10))
        noidentificado.BorderWidthRight = 0
        noidentificado.BorderWidthTop = 0
        noidentificado.BorderWidthBottom = 0
        Tablatotales.AddCell(noidentificado)

        Dim blank004 As New PdfPCell(New Paragraph("", Futuran10))
        blank004.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank004)

        Dim cuenta As New PdfPCell(New Paragraph("Número de cuenta o tarjeta._______________", ArialMT10))
        cuenta.Colspan = 5
        cuenta.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(cuenta)

        Dim blank005_c1 As New PdfPCell(New Paragraph("", ArialMT7))
        blank005_c1.Border = 0
        Tablatotales.AddCell(blank005_c1)

        Dim blank005_c4 As New PdfPCell(New Paragraph("", ArialMT7))
        blank005_c4.Colspan = 6
        blank005_c4.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank005_c4)

        Dim codigo_serieb As iTextSharp.text.Image
        codigo_serieb = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\SERIE_B.png")
        codigo_serieb.ScaleAbsoluteWidth(80) 'Ancho de la imagen
        codigo_serieb.ScaleAbsoluteHeight(80) 'Altura de la imagen

        Dim codigo_bidimensional As New PdfPCell(codigo_serieb)
        codigo_bidimensional.Colspan = 2
        codigo_bidimensional.Rowspan = 6
        codigo_bidimensional.PaddingTop = 5
        codigo_bidimensional.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(codigo_bidimensional)

        Dim linea1 As New PdfPCell(New Paragraph("La reproducción apócrifa de este comprobante constituye un delito en los términos de las disposiciones fiscales. Este comprobante tendrá una vigencia de dos años contados a partir de la fecha de aprobación de la asignacion de folios serie B del 01 al 100, la cual es del 27/11/2012 18:24:29", ArialMT7))
        linea1.Colspan = 5
        linea1.PaddingTop = 6
        linea1.PaddingBottom = 5
        linea1.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea1)

        Dim linea2 As New PdfPCell(New Paragraph("CADENA ORIGINAL.", ArialMT7))
        linea2.Colspan = 10
        linea2.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea2)

        Dim linea3 As New PdfPCell(New Paragraph("|CAHA840519CQ8|ARCELIA CASTELLANOS", ArialMT8))
        linea3.Colspan = 5
        linea3.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea3)

        Dim linea4 As New PdfPCell(New Paragraph("HERNANDEZ|FACTURAS|B|1|100|24246751|27/11/2012", ArialMT8))
        linea4.Colspan = 5
        linea4.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea4)

        Dim linea5 As New PdfPCell(New Paragraph("18:24:29|APROBACIÓN|00001000000010000001|", ArialMT8))
        linea5.Colspan = 3
        linea5.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea5)

        Dim linea_firma As New PdfPCell(New Paragraph("________________", ArialMT8))
        linea_firma.Colspan = 2
        linea_firma.HorizontalAlignment = Element.ALIGN_CENTER
        linea_firma.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea_firma)

        Dim linea6 As New PdfPCell(New Paragraph("NUMERO DE APROBACION SICOFI 24246751", ArialMT7))
        linea6.Colspan = 3
        linea6.PaddingTop = 6
        linea6.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea6)

        Dim firma As New PdfPCell(New Paragraph("Firma.", ArialMT8))
        firma.Colspan = 3
        firma.HorizontalAlignment = Element.ALIGN_CENTER
        firma.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(firma)

        Tablatotales.HorizontalAlignment = Element.ALIGN_RIGHT

        'Tablatotales.TotalWidth = 505
        'Tablatotales.WriteSelectedRows(0, -1, 52, (document.PageSize.Height - 500), writer.DirectContent)
        '=======================================================================================================
        '                                        AGREGAMOS OBJETOS AL DOCUMENTO
        '======================================================================================================
        document.Add(imagendemo)
        document.Add(TablaSerie)
        document.Add(_espacio)
        document.Add(TablaDescripcion)
        document.Add(Tablatotales)

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


