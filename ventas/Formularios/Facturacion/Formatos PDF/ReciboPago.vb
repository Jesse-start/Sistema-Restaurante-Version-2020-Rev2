Imports System.Xml
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System

Module ReciboPago
    Dim serie_certificado_emisor As String = ""
    Dim folio_fiscal As String = ""
    Dim num_serie_certificado_sat As String = ""
    Dim fecha_hora_certificacion As String = ""
    Dim cadena_original_complemento_certificacion_sta As String = ""
    Dim sello_digital_emisor As String = ""
    Dim sello_digital_sat As String = ""
    Dim num_serie As String = ""
    Dim rfc_pac As String = ""
    Private Sub obtener_valores_xml(ByVal id_recibo_pago As Integer)
        Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
        Dim reader As XmlTextReader = New XmlTextReader(xmlTimbradoFile)

        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            If reader.Name = "NoCertificado" Then
                                serie_certificado_emisor = reader.Value
                            ElseIf reader.Name = "UUID" Then
                                folio_fiscal = reader.Value
                            ElseIf reader.Name = "NoCertificadoSAT" Then
                                num_serie_certificado_sat = reader.Value
                            ElseIf reader.Name = "FechaTimbrado" Then
                                fecha_hora_certificacion = reader.Value
                            ElseIf reader.Name = "SelloCFD" Then
                                sello_digital_emisor = reader.Value
                            ElseIf reader.Name = "SelloSAT" Then
                                sello_digital_sat = reader.Value
                            ElseIf reader.Name = "RfcProvCertif" Then
                                rfc_pac = reader.Value
                            End If
                        End While
                    End If
            End Select
        Loop

        cadena_original_complemento_certificacion_sta = "||1.1|" & folio_fiscal & "|" & fecha_hora_certificacion & "|" & rfc_pac & "|" & sello_digital_emisor & "|" & num_serie_certificado_sat & "||"

    End Sub

    Public Sub Genera_recibo_pago(ByVal id_recibo_pago As Integer, ByVal concepto_general As Boolean, ByVal cadena_concepto As String)

        'Tryn
        'Intentar generar el documento.
        Dim doc As New Document(PageSize.LETTER, 10, 55, 20, 20)
        'Path que guarda el reporte en el escritorio de windows (Desktop).
        Dim generado As String = Format(Today.Date, "dd-MM-yyyy")
        'Conectar()
        rs.Open("SELECT serie FROM recibo_pago WHERE id_recibo_pago=" & id_recibo_pago, conn)
        If rs.RecordCount > 0 Then
            num_serie = rs.Fields("serie").Value
        End If
        rs.Close()
        'conn.close()
        obtener_valores_xml(id_recibo_pago)

        Dim filename As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        ExportarDatosPDF_SerieA(doc, writer, id_recibo_pago, concepto_general, cadena_concepto)
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
    Public Sub ExportarDatosPDF_SerieA(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_recibo_pago As Integer, ByVal concepto_general As Boolean, ByVal cadena_concepto As String)
        '=========================================================================
        'variables a utilizar
        Dim _numero_serie As String = ""
        Dim _nombre As String = ""
        Dim _rfc As String = ""
        Dim _monto As String = ""
        Dim _fecha_recibo As DateTime
        Dim _moneda As String = ""
        Dim _fecha_pago As DateTime
        Dim _forma_pago As String = ""

        Dim num_operacion As String = ""
        Dim rfc_ordenante As String = ""
        Dim cuenta_ordenante As String = ""
        Dim nombre_ordenante As String = ""
        Dim rfc_beneficiario As String = ""
        Dim cuenta_beneficiario As String = ""


        Dim emisor_regimen As String = ""
        Dim emisor_razon_social As String = ""
        Dim emisor_rfc As String = ""
        Dim emisor_calle As String = ""
        Dim emisor_num_ext As String = ""
        Dim emisor_num_int As String = ""
        Dim emisor_colonia As String = ""
        Dim emisor_municipio As String = ""
        Dim emisor_localidad As String = ""
        Dim emisor_cp As String = ""
        Dim emisor_estado As String = ""
        Dim emisor_pais As String = ""
        Dim emisor_correo As String = ""
        Dim emisor_telefono As String = ""

        Dim cadena_relacion_documentos As String = ""

        Dim rw As New ADODB.Recordset
        'Conectar()
        rs.Open("SELECT recibo_pago.serie,recibo_pago.fecha,recibo_pago.fecha_hora_pago,recibo_pago.monto,recibo_pago.num_operacion,recibo_pago.rfc_ordenante,recibo_pago.cuenta_ordenante,recibo_pago.nombre_ordenante,rfc_beneficiario,recibo_pago.cuenta_beneficiario, " &
                "CONCAT(ctlg_moneda.clave,' ',ctlg_moneda.nombre) AS moneda,  CONCAT(ctlg_forma_pago.clave,' ',ctlg_forma_pago.nombre) AS forma_pago, " &
                "CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre, " &
               "(SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END AS rfc FROM cliente JOIN  recibo_pago ON recibo_pago.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE recibo_pago.id_recibo_pago=" & id_recibo_pago & ")AS rfc " &
        "FROM recibo_pago " &
                "JOIN cliente ON recibo_pago.id_cliente=cliente.id_cliente " &
                "LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona " &
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                "JOIN ctlg_forma_pago ON ctlg_forma_pago.id_forma_pago=recibo_pago.id_forma_pago " &
                "JOIN ctlg_moneda ON ctlg_moneda.id_ctlg_moneda=recibo_pago.id_moneda " &
                "WHERE recibo_pago.id_recibo_pago = " & id_recibo_pago, conn)
        If rs.RecordCount > 0 Then
            _numero_serie = rs.Fields("serie").Value
            _fecha_recibo = rs.Fields("fecha").Value
            _fecha_pago = rs.Fields("fecha_hora_pago").Value
            _monto = rs.Fields("monto").Value
            _forma_pago = rs.Fields("forma_pago").Value
            _moneda = rs.Fields("moneda").Value
            _nombre = rs.Fields("nombre").Value
            _rfc = rs.Fields("rfc").Value
            num_operacion = rs.Fields("num_operacion").Value
            rfc_ordenante = rs.Fields("rfc_ordenante").Value
            cuenta_ordenante = rs.Fields("cuenta_ordenante").Value
            nombre_ordenante = rs.Fields("nombre_ordenante").Value
            rfc_beneficiario = rs.Fields("rfc_beneficiario").Value
            cuenta_beneficiario = rs.Fields("cuenta_beneficiario").Value

        End If
        rs.Close()

        rs.Open("SELECT razon_social,rfc,calle,num_int,num_ext,colonia,municipio,localidad,cp,estado,pais,correo,telefono FROM configuracion WHERE id_configuracion='1'", conn)
        If rs.RecordCount > 0 Then

            emisor_razon_social = rs.Fields("razon_social").Value
            emisor_rfc = rs.Fields("rfc").Value
            emisor_calle = rs.Fields("calle").Value
            emisor_num_ext = rs.Fields("num_ext").Value
            emisor_num_int = rs.Fields("num_int").Value
            emisor_colonia = rs.Fields("colonia").Value
            emisor_localidad = rs.Fields("localidad").Value
            emisor_municipio = rs.Fields("municipio").Value
            emisor_cp = rs.Fields("cp").Value
            emisor_estado = rs.Fields("estado").Value
            emisor_pais = rs.Fields("pais").Value
            emisor_correo = rs.Fields("correo").Value
            emisor_telefono = rs.Fields("telefono").Value
        End If
        rs.Close()

        rs.Open("SELECT CONCAT(rf.clave,' ',rf.nombre) AS regimen_fiscal " & _
                "FROM  configuracion c " & _
                "JOIN ctlg_regimen_fiscal rf ON rf.id_regimen_fiscal=c.id_regimen_fiscal " & _
                "WHERE id_configuracion=1", conn)
        If rs.RecordCount > 0 Then
            emisor_regimen = rs.Fields("regimen_fiscal").Value
        End If
        rs.Close()


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
        Dim ArialMT12 As New Font(bfR, 12, Font.NORMAL, BaseColor.WHITE)
        Dim ArialMT12_black As New Font(bfR, 12, Font.NORMAL)
        Dim ArialMT10_black As New Font(bfR, 10, Font.NORMAL)
        Dim Futuran10 As New Font(bfR2, 10, Font.NORMAL)
        Dim Futuran9 As New Font(bfR2, 9, Font.NORMAL)
        Dim Futuran9_white As New Font(bfR2, 9, Font.NORMAL, BaseColor.WHITE)
        Dim Futuran8 As New Font(bfR2, 8, Font.NORMAL)

        Dim ArialMT10 As New Font(bfR, 9, Font.NORMAL)
        Dim ArialMT10_white As New Font(bfR, 9, Font.NORMAL, BaseColor.WHITE)
        Dim ArialMT8 As New Font(bfR, 8, Font.NORMAL)
        Dim ArialMT8bold As New Font(bfR, 8, Font.BOLD)

        Dim _espacio As New Paragraph ' Declaracion de un parrafo
        '_alias.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _espacio.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _espacio.Add("  ") 'Texto que se insertara
        '=======================================================================================================
        '                                        TABLA DE FACTURA SERIE
        '======================================================================================================


        Dim imagendemo As iTextSharp.text.Image
        imagendemo = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\logo.png")
        imagendemo.SetAbsolutePosition(20, 650) 'Posicion en el eje cartesiano
        imagendemo.ScaleAbsoluteWidth(200) 'Ancho de la imagen
        imagendemo.ScaleAbsoluteHeight(125) 'Altura de la imagen

        Dim TablaSerie As New PdfPTable(7)
        TablaSerie.SetWidthPercentage({33, 33, 38, 150, 30, 38, 45}, PageSize.LETTER)


        'Dim cell1 As New PdfPCell(New Paragraph("", ArialMT13))
        ' cell1.Colspan = 2
        'cell1.BorderColor = BaseColor.WHITE
        'TablaSerie.AddCell(cell1)

        'Dim cell2 As New PdfPCell(New Paragraph("", ArialMT13))
        'cell2.BorderColor = BaseColor.WHITE
        'TablaSerie.AddCell(cell2)

        Dim factura As New PdfPCell(New Paragraph("RECIBO PAGO", ArialMT12))
        factura.PaddingBottom = 5
        factura.HorizontalAlignment = Element.ALIGN_CENTER
        factura.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        factura.BorderColor = BaseColor.WHITE
        factura.BorderWidthRight = 3
        factura.Colspan = 3
        TablaSerie.AddCell(factura)

        Dim serie As New PdfPCell(New Paragraph("SERIE " & _numero_serie, ArialMT13))
        serie.Colspan = 2
        serie.PaddingBottom = 5
        serie.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(26)))
        serie.HorizontalAlignment = Element.ALIGN_CENTER
        serie.Border = Nothing
        TablaSerie.AddCell(serie)

        Dim folio As New PdfPCell(New Paragraph(id_recibo_pago, ArialMT13_black))
        folio.PaddingBottom = 5
        folio.HorizontalAlignment = Element.ALIGN_CENTER
        folio.Border = Nothing
        folio.Colspan = 2
        TablaSerie.AddCell(folio)

        Dim regimen As New PdfPCell(New Paragraph("Regimen Fiscal:" & emisor_regimen, ArialMT7))
        regimen.PaddingTop = 8
        regimen.Colspan = 7
        regimen.HorizontalAlignment = Element.ALIGN_RIGHT
        regimen.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(regimen)

        Dim razon As New PdfPCell(New Paragraph(emisor_razon_social, ArialMT7))
        razon.Colspan = 7
        razon.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(razon)

        Dim domicilio As New PdfPCell(New Paragraph(emisor_calle & " " & emisor_num_ext & " " & emisor_num_int & ", " & emisor_colonia & ", " & emisor_localidad & ", " & emisor_municipio & ", CP." & emisor_cp & ", " & emisor_estado & "," & emisor_pais, ArialMT7))
        domicilio.Colspan = 7
        domicilio.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(domicilio)

        Dim rfc As New PdfPCell(New Paragraph("R.F.C.: " & emisor_rfc, ArialMT7))
        rfc.Colspan = 3
        rfc.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(rfc)

        Dim curp As New PdfPCell(New Paragraph("", ArialMT7))
        curp.Colspan = 4
        curp.HorizontalAlignment = Element.ALIGN_RIGHT
        curp.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(curp)

        Dim email As New PdfPCell(New Paragraph("Tipo de Comprobante: P Pago   Atención a clientes:" & emisor_correo & " Tel.: " & emisor_telefono, ArialMT7))
        email.Colspan = 7
        email.PaddingBottom = 8
        email.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(email)

        Dim lugar_expedicion As New PdfPCell(New Paragraph("Lugar, fecha y hora de emisión: " & emisor_cp & "," & Format(_fecha_recibo, "yyyy-MM-ddTHH:mm:ss"), ArialMT7))
        lugar_expedicion.Colspan = 7
        lugar_expedicion.PaddingBottom = 8
        lugar_expedicion.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(lugar_expedicion)

        'Dim telefono As New PdfPCell(New Paragraph("Atención al cliente: (951) 1325455", ArialMT7))
        'telefono.Colspan = 4
        'telefono.HorizontalAlignment = Element.ALIGN_RIGHT
        'telefono.BorderColor = BaseColor.WHITE
        'telefono.PaddingBottom = 8
        'TablaSerie.AddCell(telefono)

        Dim e_dia As New PdfPCell(New Paragraph("DÍA:", ArialMT11))
        e_dia.PaddingBottom = 5
        e_dia.HorizontalAlignment = Element.ALIGN_CENTER
        e_dia.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_dia.BorderColor = BaseColor.WHITE
        e_dia.BorderWidthRight = 2
        TablaSerie.AddCell(e_dia)

        Dim dia As New PdfPCell(New Paragraph(Format(_fecha_recibo, "dd"), Futuran11))
        dia.PaddingBottom = 5
        dia.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        dia.HorizontalAlignment = Element.ALIGN_CENTER
        dia.BorderColor = BaseColor.WHITE
        dia.BorderWidthRight = 4
        TablaSerie.AddCell(dia)

        Dim e_mes As New PdfPCell(New Paragraph("MES:", ArialMT11))
        e_mes.PaddingBottom = 5
        e_mes.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_mes.HorizontalAlignment = Element.ALIGN_CENTER
        e_mes.BorderColor = BaseColor.WHITE
        e_mes.BorderWidthRight = 2
        TablaSerie.AddCell(e_mes)


        Dim mes As New PdfPCell(New Paragraph(UCase(nombre_mes(Format(_fecha_recibo, "MM"))), Futuran11))
        mes.Colspan = 2
        mes.PaddingBottom = 5
        mes.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        mes.HorizontalAlignment = Element.ALIGN_CENTER
        mes.BorderColor = BaseColor.WHITE
        mes.BorderWidthRight = 4
        TablaSerie.AddCell(mes)

        Dim e_año As New PdfPCell(New Paragraph("AÑO:", ArialMT11))
        e_año.PaddingBottom = 5
        e_año.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_año.HorizontalAlignment = Element.ALIGN_CENTER
        e_año.BorderColor = BaseColor.WHITE
        e_año.BorderWidthRight = 2
        TablaSerie.AddCell(e_año)

        Dim año As New PdfPCell(New Paragraph(Format(_fecha_recibo, "yyyy"), Futuran11))
        año.PaddingBottom = 5
        año.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
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
        TablaDescripcion.SetWidthPercentage({65, 70, 60, 90, 30, 70, 38, 10, 60, 10, 65}, PageSize.LETTER) 'Ajusta el tamaño de cada columna

        Dim e_datos_cliente As New PdfPCell(New Paragraph("Información del Receptor", ArialMT11))
        e_datos_cliente.Colspan = 11
        e_datos_cliente.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_datos_cliente.PaddingBottom = 3
        e_datos_cliente.PaddingRight = 4
        e_datos_cliente.HorizontalAlignment = Element.ALIGN_LEFT
        e_datos_cliente.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_datos_cliente)

        Dim e_nombre As New PdfPCell(New Paragraph("Nombre:", ArialMT8))
        e_nombre.PaddingTop = 7
        e_nombre.PaddingBottom = 5
        e_nombre.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_nombre)

        Dim nombre As New PdfPCell(New Paragraph(_nombre, Futuran8))
        nombre.PaddingTop = 7
        nombre.PaddingBottom = 5
        nombre.BorderWidthTop = 0
        nombre.BorderWidthLeft = 0
        nombre.BorderWidthRight = 0
        nombre.Colspan = 5
        TablaDescripcion.AddCell(nombre)


        Dim e_rfc As New PdfPCell(New Paragraph("RFC:", ArialMT8))
        e_rfc.PaddingTop = 7
        e_rfc.PaddingBottom = 5
        e_rfc.HorizontalAlignment = Element.ALIGN_CENTER
        e_rfc.BorderWidth = 0
        TablaDescripcion.AddCell(e_rfc)


        Dim rfc_cliente As New PdfPCell(New Paragraph(_rfc, Futuran8))
        rfc_cliente.PaddingTop = 7
        rfc_cliente.PaddingBottom = 5
        rfc_cliente.Colspan = 5
        rfc_cliente.BorderWidthTop = 0
        rfc_cliente.BorderWidthLeft = 0
        rfc_cliente.BorderWidthRight = 0
        rfc_cliente.HorizontalAlignment = Element.ALIGN_CENTER
        TablaDescripcion.AddCell(rfc_cliente)

        Dim blank_row As New PdfPCell(New Paragraph("", ArialMT10_black))
        blank_row.Colspan = 11
        blank_row.PaddingTop = 5
        blank_row.PaddingBottom = 5
        blank_row.Border = Nothing
        TablaDescripcion.AddCell(blank_row)



        Dim info_pago As New PdfPCell(New Paragraph("Información del pago", ArialMT11))
        info_pago.Colspan = 11
        info_pago.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        info_pago.PaddingBottom = 3
        info_pago.PaddingRight = 4
        info_pago.HorizontalAlignment = Element.ALIGN_LEFT
        info_pago.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(info_pago)

        Dim e_fecha_pago As New PdfPCell(New Paragraph("Fecha pago:", ArialMT8))
        e_fecha_pago.PaddingTop = 7
        e_fecha_pago.PaddingBottom = 5
        e_fecha_pago.BorderColor = BaseColor.WHITE
        e_fecha_pago.Colspan = 2
        TablaDescripcion.AddCell(e_fecha_pago)

        Dim fecha_pago As New PdfPCell(New Paragraph(Format(_fecha_pago, "yyyy-MM-ddTHH:mm:ss"), Futuran8))
        fecha_pago.PaddingTop = 7
        fecha_pago.PaddingBottom = 5
        fecha_pago.BorderWidthTop = 0
        fecha_pago.BorderWidthLeft = 0
        fecha_pago.BorderWidthRight = 0
        fecha_pago.Colspan = 3
        TablaDescripcion.AddCell(fecha_pago)


        Dim e_tipo_cambio As New PdfPCell(New Paragraph("Tipo cambio:", ArialMT8))
        e_tipo_cambio.PaddingTop = 7
        e_tipo_cambio.PaddingBottom = 5
        e_tipo_cambio.HorizontalAlignment = Element.ALIGN_CENTER
        e_tipo_cambio.BorderWidth = 0
        e_tipo_cambio.Colspan = 2
        TablaDescripcion.AddCell(e_tipo_cambio)


        Dim tipo_cambio As New PdfPCell(New Paragraph("", Futuran8))
        tipo_cambio.PaddingTop = 7
        tipo_cambio.PaddingBottom = 5
        tipo_cambio.Colspan = 5
        tipo_cambio.BorderWidthTop = 0
        tipo_cambio.BorderWidthLeft = 0
        tipo_cambio.BorderWidthRight = 0
        tipo_cambio.HorizontalAlignment = Element.ALIGN_CENTER
        TablaDescripcion.AddCell(tipo_cambio)


        Dim e_forma_pago As New PdfPCell(New Paragraph("Forma de pago", ArialMT8))
        e_forma_pago.PaddingTop = 7
        e_forma_pago.PaddingBottom = 5
        e_forma_pago.BorderColor = BaseColor.WHITE
        e_forma_pago.Colspan = 2
        TablaDescripcion.AddCell(e_forma_pago)

        Dim forma_pago As New PdfPCell(New Paragraph(_forma_pago, Futuran8))
        forma_pago.PaddingTop = 7
        forma_pago.PaddingBottom = 5
        forma_pago.BorderWidthTop = 0
        forma_pago.BorderWidthLeft = 0
        forma_pago.BorderWidthRight = 0
        forma_pago.Colspan = 3
        TablaDescripcion.AddCell(forma_pago)


        Dim e_monto As New PdfPCell(New Paragraph("Monto:", ArialMT8))
        e_monto.PaddingTop = 7
        e_monto.PaddingBottom = 5
        e_monto.HorizontalAlignment = Element.ALIGN_CENTER
        e_monto.BorderWidth = 0
        e_monto.Colspan = 2
        TablaDescripcion.AddCell(e_monto)


        Dim monto As New PdfPCell(New Paragraph(FormatCurrency(_monto), Futuran8))
        monto.PaddingTop = 7
        monto.PaddingBottom = 5
        monto.Colspan = 5
        monto.BorderWidthTop = 0
        monto.BorderWidthLeft = 0
        monto.BorderWidthRight = 0
        monto.HorizontalAlignment = Element.ALIGN_CENTER
        TablaDescripcion.AddCell(monto)

        Dim e_moneda As New PdfPCell(New Paragraph("Moneda", ArialMT8))
        e_moneda.PaddingTop = 7
        e_moneda.PaddingBottom = 5
        e_moneda.BorderColor = BaseColor.WHITE
        e_moneda.Colspan = 2
        TablaDescripcion.AddCell(e_moneda)

        Dim moneda As New PdfPCell(New Paragraph(_moneda, Futuran8))
        moneda.PaddingTop = 7
        moneda.PaddingBottom = 5
        moneda.BorderWidthTop = 0
        moneda.BorderWidthLeft = 0
        moneda.BorderWidthRight = 0
        moneda.Colspan = 3
        TablaDescripcion.AddCell(moneda)


        Dim e_num_operacion As New PdfPCell(New Paragraph("Numero de operación:", ArialMT8))
        e_num_operacion.PaddingTop = 7
        e_num_operacion.PaddingBottom = 5
        e_num_operacion.BorderColor = BaseColor.WHITE
        e_num_operacion.Colspan = 2
        TablaDescripcion.AddCell(e_num_operacion)

        Dim num_operacion_cell As New PdfPCell(New Paragraph(num_operacion, Futuran8))
        num_operacion_cell.PaddingTop = 7
        num_operacion_cell.PaddingBottom = 5
        num_operacion_cell.BorderWidthTop = 0
        num_operacion_cell.BorderWidthLeft = 0
        num_operacion_cell.BorderWidthRight = 0
        num_operacion_cell.Colspan = 5
        TablaDescripcion.AddCell(num_operacion_cell)

        Dim blank_row_info As New PdfPCell(New Paragraph("", ArialMT8))
        blank_row_info.Colspan = 11
        blank_row_info.PaddingTop = 5
        blank_row_info.PaddingBottom = 5
        blank_row_info.Border = Nothing
        TablaDescripcion.AddCell(blank_row_info)

        Dim detalle_pago As New PdfPCell(New Paragraph("Detalles del pago", ArialMT11))
        detalle_pago.Colspan = 11
        detalle_pago.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        detalle_pago.PaddingBottom = 3
        detalle_pago.PaddingRight = 4
        detalle_pago.HorizontalAlignment = Element.ALIGN_LEFT
        detalle_pago.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(detalle_pago)

        Dim e_rfc_ordenante As New PdfPCell(New Paragraph("RFC Emisor Cuenta Ordenante:", ArialMT8))
        e_rfc_ordenante.PaddingTop = 7
        e_rfc_ordenante.PaddingBottom = 5
        e_rfc_ordenante.BorderColor = BaseColor.WHITE
        e_rfc_ordenante.Colspan = 2
        TablaDescripcion.AddCell(e_rfc_ordenante)

        Dim rfc_cuenta_ordenante As New PdfPCell(New Paragraph(rfc_ordenante, Futuran8))
        rfc_cuenta_ordenante.PaddingTop = 7
        rfc_cuenta_ordenante.PaddingBottom = 5
        rfc_cuenta_ordenante.BorderWidthTop = 0
        rfc_cuenta_ordenante.BorderWidthLeft = 0
        rfc_cuenta_ordenante.BorderWidthRight = 0
        rfc_cuenta_ordenante.Colspan = 3
        TablaDescripcion.AddCell(rfc_cuenta_ordenante)


        Dim e_rfc_beneficiario As New PdfPCell(New Paragraph("RFC Emisor Cuenta Beneficiario", ArialMT8))
        e_rfc_beneficiario.PaddingTop = 7
        e_rfc_beneficiario.PaddingBottom = 5
        e_rfc_beneficiario.HorizontalAlignment = Element.ALIGN_CENTER
        e_rfc_beneficiario.BorderWidth = 0
        e_rfc_beneficiario.Colspan = 2
        TablaDescripcion.AddCell(e_rfc_beneficiario)


        Dim rfc_beneficiario_cell As New PdfPCell(New Paragraph(rfc_beneficiario, Futuran8))
        rfc_beneficiario_cell.PaddingTop = 7
        rfc_beneficiario_cell.PaddingBottom = 5
        rfc_beneficiario_cell.Colspan = 5
        rfc_beneficiario_cell.BorderWidthTop = 0
        rfc_beneficiario_cell.BorderWidthLeft = 0
        rfc_beneficiario_cell.BorderWidthRight = 0
        rfc_beneficiario_cell.HorizontalAlignment = Element.ALIGN_CENTER
        TablaDescripcion.AddCell(rfc_beneficiario_cell)


        Dim e_nombre_ordenante As New PdfPCell(New Paragraph("Nombre del Banco Ordenante:", ArialMT8))
        e_nombre_ordenante.PaddingTop = 7
        e_nombre_ordenante.PaddingBottom = 5
        e_nombre_ordenante.BorderColor = BaseColor.WHITE
        e_nombre_ordenante.Colspan = 2
        TablaDescripcion.AddCell(e_nombre_ordenante)

        Dim nombre_ordenante_cell As New PdfPCell(New Paragraph(nombre_ordenante, Futuran8))
        nombre_ordenante_cell.PaddingTop = 7
        nombre_ordenante_cell.PaddingBottom = 5
        nombre_ordenante_cell.BorderWidthTop = 0
        nombre_ordenante_cell.BorderWidthLeft = 0
        nombre_ordenante_cell.BorderWidthRight = 0
        nombre_ordenante_cell.Colspan = 3
        TablaDescripcion.AddCell(nombre_ordenante_cell)


        Dim e_cuenta_beneficiario As New PdfPCell(New Paragraph("Cuenta Beneficiario:", ArialMT8))
        e_cuenta_beneficiario.PaddingTop = 7
        e_cuenta_beneficiario.PaddingBottom = 5
        e_cuenta_beneficiario.HorizontalAlignment = Element.ALIGN_CENTER
        e_cuenta_beneficiario.BorderWidth = 0
        e_cuenta_beneficiario.Colspan = 2
        TablaDescripcion.AddCell(e_cuenta_beneficiario)


        Dim cuenta_beneficiario_cell As New PdfPCell(New Paragraph(cuenta_beneficiario, Futuran8))
        cuenta_beneficiario_cell.PaddingTop = 7
        cuenta_beneficiario_cell.PaddingBottom = 5
        cuenta_beneficiario_cell.Colspan = 5
        cuenta_beneficiario_cell.BorderWidthTop = 0
        cuenta_beneficiario_cell.BorderWidthLeft = 0
        cuenta_beneficiario_cell.BorderWidthRight = 0
        cuenta_beneficiario_cell.HorizontalAlignment = Element.ALIGN_CENTER
        TablaDescripcion.AddCell(cuenta_beneficiario_cell)

        Dim e_cuenta_ordenante As New PdfPCell(New Paragraph("Cuenta Ordenante:", ArialMT8))
        e_cuenta_ordenante.PaddingTop = 7
        e_cuenta_ordenante.PaddingBottom = 5
        e_cuenta_ordenante.BorderColor = BaseColor.WHITE
        e_cuenta_ordenante.Colspan = 2
        TablaDescripcion.AddCell(e_cuenta_ordenante)

        Dim cuenta_ordenante_Cell As New PdfPCell(New Paragraph(cuenta_ordenante, Futuran8))
        cuenta_ordenante_Cell.PaddingTop = 7
        cuenta_ordenante_Cell.PaddingBottom = 5
        cuenta_ordenante_Cell.BorderWidthTop = 0
        cuenta_ordenante_Cell.BorderWidthLeft = 0
        cuenta_ordenante_Cell.BorderWidthRight = 0
        cuenta_ordenante_Cell.Colspan = 3
        TablaDescripcion.AddCell(cuenta_ordenante_Cell)


        Dim relleno As New PdfPCell(New Paragraph("", ArialMT10_black))
        relleno.PaddingTop = 7
        relleno.PaddingBottom = 5
        relleno.HorizontalAlignment = Element.ALIGN_CENTER
        relleno.BorderWidth = 0
        relleno.Colspan = 7
        TablaDescripcion.AddCell(relleno)

        Dim blank_row_info2 As New PdfPCell(New Paragraph("", ArialMT10_black))
        blank_row_info2.Colspan = 11
        blank_row_info2.PaddingTop = 5
        blank_row_info2.PaddingBottom = 5
        blank_row_info2.Border = Nothing
        TablaDescripcion.AddCell(blank_row_info2)

        TablaDescripcion.HorizontalAlignment = Element.ALIGN_RIGHT


        Dim TablaDocumentos As New PdfPTable(10) 'declara la tabla con 4 columnas
        TablaDocumentos.SetWidthPercentage({104, 47, 47, 47, 50, 47, 57, 57, 57, 57}, PageSize.LETTER) 'Ajusta el tamaño de cada columna

        Dim e_id_documento As New PdfPCell(New Paragraph("ID Documento", ArialMT10_white))
        e_id_documento.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_id_documento.BorderColor = BaseColor.WHITE
        e_id_documento.HorizontalAlignment = Element.ALIGN_CENTER
        e_id_documento.BorderWidthRight = 1.5
        e_id_documento.PaddingBottom = 4
        TablaDocumentos.AddCell(e_id_documento)

        Dim e_serie As New PdfPCell(New Paragraph("Serie", ArialMT10_white))
        e_serie.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_serie.BorderColor = BaseColor.WHITE
        e_serie.HorizontalAlignment = Element.ALIGN_CENTER
        e_serie.BorderWidthRight = 1.5
        e_serie.PaddingBottom = 4
        TablaDocumentos.AddCell(e_serie)

        Dim e_folio As New PdfPCell(New Paragraph("Folio", ArialMT10_white))
        e_folio.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_folio.BorderColor = BaseColor.WHITE
        e_folio.HorizontalAlignment = Element.ALIGN_CENTER
        e_folio.BorderWidthRight = 1.5
        e_folio.PaddingBottom = 4
        TablaDocumentos.AddCell(e_folio)

        Dim e_moneda_doc As New PdfPCell(New Paragraph("Moneda", ArialMT10_white))
        e_moneda_doc.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_moneda_doc.BorderColor = BaseColor.WHITE
        e_moneda_doc.HorizontalAlignment = Element.ALIGN_CENTER
        e_moneda_doc.PaddingLeft = 5
        e_moneda_doc.BorderWidthRight = 1.5
        e_moneda_doc.PaddingBottom = 4
        TablaDocumentos.AddCell(e_moneda_doc)

        Dim e_tipo_cambio_doc As New PdfPCell(New Paragraph("Tipo Cambio", ArialMT10_white))
        e_tipo_cambio_doc.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_tipo_cambio_doc.BorderColor = BaseColor.WHITE
        e_tipo_cambio_doc.HorizontalAlignment = Element.ALIGN_CENTER
        e_tipo_cambio_doc.BorderWidthRight = 1.5
        e_tipo_cambio_doc.PaddingBottom = 4
        TablaDocumentos.AddCell(e_tipo_cambio_doc)

        Dim e_metodo_pago_doc As New PdfPCell(New Paragraph("Método de Pago", ArialMT10_white))
        e_metodo_pago_doc.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_metodo_pago_doc.HorizontalAlignment = Element.ALIGN_CENTER
        e_metodo_pago_doc.PaddingBottom = 4
        e_metodo_pago_doc.BorderColor = BaseColor.WHITE
        TablaDocumentos.AddCell(e_metodo_pago_doc)

        Dim e_num_parcialidad As New PdfPCell(New Paragraph("No. Parcialidad", ArialMT10_white))
        e_num_parcialidad.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_num_parcialidad.HorizontalAlignment = Element.ALIGN_CENTER
        e_num_parcialidad.PaddingBottom = 4
        e_num_parcialidad.BorderColor = BaseColor.WHITE
        TablaDocumentos.AddCell(e_num_parcialidad)

        Dim e_saldo_anterior As New PdfPCell(New Paragraph("Importe Saldo Anterior", ArialMT10_white))
        e_saldo_anterior.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_saldo_anterior.HorizontalAlignment = Element.ALIGN_CENTER
        e_saldo_anterior.PaddingBottom = 4
        e_saldo_anterior.BorderColor = BaseColor.WHITE
        TablaDocumentos.AddCell(e_saldo_anterior)

        Dim e_importe_pagado As New PdfPCell(New Paragraph("Importe Pagado", ArialMT10_white))
        e_importe_pagado.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_importe_pagado.HorizontalAlignment = Element.ALIGN_CENTER
        e_importe_pagado.PaddingBottom = 4
        e_importe_pagado.BorderColor = BaseColor.WHITE
        TablaDocumentos.AddCell(e_importe_pagado)

        Dim e_importe_saldo As New PdfPCell(New Paragraph("Importe Saldo Insoluto", ArialMT10_white))
        e_importe_saldo.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_importe_saldo.HorizontalAlignment = Element.ALIGN_CENTER
        e_importe_saldo.PaddingBottom = 4
        e_importe_saldo.BorderColor = BaseColor.WHITE
        TablaDocumentos.AddCell(e_importe_saldo)


        rs.Open("SELECT * FROM recibo_pago_detalle WHERE id_recibo_pago=" & id_recibo_pago, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim dat01 As New PdfPCell(New Paragraph(rs.Fields("id_documento").Value, Futuran8))
                dat01.MinimumHeight = 15
                dat01.PaddingTop = 5
                dat01.PaddingBottom = 5
                dat01.HorizontalAlignment = Element.ALIGN_CENTER
                dat01.BorderWidthTop = 0
                dat01.BorderWidthBottom = 0
                dat01.BorderWidthLeft = 0
                dat01.BorderWidthRight = 1.5
                dat01.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat01)

                Dim dat02 As New PdfPCell(New Paragraph(rs.Fields("serie").Value, Futuran8))
                dat02.MinimumHeight = 15
                dat02.PaddingTop = 5
                dat02.PaddingBottom = 5
                dat02.HorizontalAlignment = Element.ALIGN_CENTER
                dat02.BorderWidthTop = 0
                dat02.BorderWidthBottom = 0
                dat02.BorderWidthLeft = 0
                dat02.BorderWidthRight = 1.5
                dat02.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat02)

                Dim dat03 As New PdfPCell(New Paragraph(rs.Fields("id_factura_electronica").Value, Futuran8))
                dat03.MinimumHeight = 15
                dat03.PaddingTop = 5
                dat03.PaddingBottom = 5
                dat03.HorizontalAlignment = Element.ALIGN_CENTER
                dat03.BorderWidthTop = 0
                dat03.BorderWidthBottom = 0
                dat03.BorderWidthLeft = 0
                dat03.BorderWidthRight = 1.5
                dat03.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat03)

                Dim dat04 As New PdfPCell(New Paragraph(rs.Fields("moneda").Value, Futuran8))
                dat04.MinimumHeight = 15
                dat04.PaddingTop = 5
                dat04.PaddingBottom = 5
                dat04.HorizontalAlignment = Element.ALIGN_CENTER
                dat04.BorderWidthTop = 0
                dat04.BorderWidthBottom = 0
                dat04.BorderWidthLeft = 0
                dat04.BorderWidthRight = 1.5
                dat04.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat04)

                Dim dat05 As New PdfPCell(New Paragraph("", Futuran8))
                dat05.MinimumHeight = 15
                dat05.PaddingTop = 5
                dat05.PaddingBottom = 5
                dat05.HorizontalAlignment = Element.ALIGN_CENTER
                dat05.BorderWidthTop = 0
                dat05.BorderWidthBottom = 0
                dat05.BorderWidthLeft = 0
                dat05.BorderWidthRight = 1.5
                dat05.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat05)

                Dim dat06 As New PdfPCell(New Paragraph(rs.Fields("metodo_pago").Value, Futuran8))
                dat06.MinimumHeight = 15
                dat06.PaddingTop = 5
                dat06.PaddingBottom = 5
                dat06.HorizontalAlignment = Element.ALIGN_CENTER
                dat06.BorderWidthTop = 0
                dat06.BorderWidthBottom = 0
                dat06.BorderWidthLeft = 0
                dat06.BorderWidthRight = 1.5
                dat06.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat06)

                Dim dat07 As New PdfPCell(New Paragraph(rs.Fields("num_parcialidad").Value, Futuran8))
                dat07.MinimumHeight = 15
                dat07.PaddingTop = 5
                dat07.PaddingBottom = 5
                dat07.HorizontalAlignment = Element.ALIGN_CENTER
                dat07.BorderWidthTop = 0
                dat07.BorderWidthBottom = 0
                dat07.BorderWidthLeft = 0
                dat07.BorderWidthRight = 1.5
                dat07.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat07)

                Dim dat08 As New PdfPCell(New Paragraph(rs.Fields("importe_anterior").Value, Futuran8))
                dat08.MinimumHeight = 15
                dat08.PaddingTop = 5
                dat08.PaddingBottom = 5
                dat08.HorizontalAlignment = Element.ALIGN_CENTER
                dat08.BorderWidthTop = 0
                dat08.BorderWidthBottom = 0
                dat08.BorderWidthLeft = 0
                dat08.BorderWidthRight = 1.5
                dat08.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat08)

                Dim dat09 As New PdfPCell(New Paragraph(rs.Fields("importe_pagado").Value, Futuran8))
                dat09.MinimumHeight = 15
                dat09.PaddingTop = 5
                dat09.PaddingBottom = 5
                dat09.HorizontalAlignment = Element.ALIGN_CENTER
                dat09.BorderWidthTop = 0
                dat09.BorderWidthBottom = 0
                dat09.BorderWidthLeft = 0
                dat09.BorderWidthRight = 1.5
                dat09.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat09)

                Dim dat10 As New PdfPCell(New Paragraph(rs.Fields("importe_saldo").Value, Futuran8))
                dat10.MinimumHeight = 15
                dat10.PaddingTop = 5
                dat10.PaddingBottom = 5
                dat10.HorizontalAlignment = Element.ALIGN_CENTER
                dat10.BorderWidthTop = 0
                dat10.BorderWidthBottom = 0
                dat10.BorderWidthLeft = 0
                dat10.BorderWidthRight = 1.5
                dat10.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                TablaDocumentos.AddCell(dat10)

                rs.MoveNext()
            End While
        End If
        rs.Close()

        TablaDocumentos.HorizontalAlignment = Element.ALIGN_RIGHT
        '=======================================================================================================
        '                                        FIN TABLA DESCRIPCION
        '=======================================================================================================

        Dim Tablatotales As New PdfPTable(7)
        Tablatotales.SetWidthPercentage({15, 125, 15, 220, 93, 15, 75}, PageSize.LETTER) 'Ajusta el tamaño de cada columna

      
        Dim exhibicion3 As New PdfPCell(New Paragraph("Serie del Certificado del CSD:", ArialMT8bold))
        exhibicion3.BorderWidthRight = 0
        exhibicion3.BorderWidthTop = 0
        exhibicion3.BorderWidthBottom = 0
        exhibicion3.BorderWidthLeft = 0
        exhibicion3.Colspan = 3
        Tablatotales.AddCell(exhibicion3)


        Dim cheque3 As New PdfPCell(New Paragraph(serie_certificado_emisor, ArialMT8))
        cheque3.Border = 0
        cheque3.Colspan = 4
        Tablatotales.AddCell(cheque3)


        Dim parcialidades3 As New PdfPCell(New Paragraph("Folio Fiscal:", ArialMT8bold))
        parcialidades3.BorderWidthRight = 0
        parcialidades3.BorderWidthTop = 0
        parcialidades3.BorderWidthBottom = 0
        parcialidades3.BorderWidthLeft = 0
        parcialidades3.Colspan = 3
        Tablatotales.AddCell(parcialidades3)


        Dim trasferencia3 As New PdfPCell(New Paragraph(folio_fiscal, ArialMT8))
        trasferencia3.Border = 0
        trasferencia3.Colspan = 4
        Tablatotales.AddCell(trasferencia3)


        Dim exhibicion As New PdfPCell(New Paragraph("No de Serie del Certificado del SAT:", ArialMT8bold))
        exhibicion.BorderWidthRight = 0
        exhibicion.BorderWidthTop = 0
        exhibicion.BorderWidthBottom = 0
        exhibicion.BorderWidthLeft = 0
        exhibicion.Colspan = 3
        Tablatotales.AddCell(exhibicion)


        Dim cheque As New PdfPCell(New Paragraph(num_serie_certificado_sat, ArialMT8))
        cheque.Border = 0
        cheque.Colspan = 4
        Tablatotales.AddCell(cheque)


        
        Dim parcialidades As New PdfPCell(New Paragraph("Fecha y hora de certificación", ArialMT8bold))
        parcialidades.BorderWidthRight = 0
        parcialidades.BorderWidthTop = 0
        parcialidades.BorderWidthBottom = 0
        parcialidades.BorderWidthLeft = 0
        parcialidades.Colspan = 3
        Tablatotales.AddCell(parcialidades)

        Dim trasferencia As New PdfPCell(New Paragraph(fecha_hora_certificacion, ArialMT8))
        trasferencia.Border = 0
        trasferencia.Colspan = 4
        Tablatotales.AddCell(trasferencia)



        Dim leyenda As New PdfPCell(New Paragraph("Este documento es una representación impresa de un CFDI", Futuran9_white))
        leyenda.Colspan = 7
        leyenda.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-12566463))
        leyenda.PaddingTop = 2
        leyenda.PaddingBottom = 2
        leyenda.HorizontalAlignment = Element.ALIGN_CENTER
        leyenda.BorderColor = BaseColor.WHITE

        Tablatotales.AddCell(leyenda)


        Dim codigo_seriea As iTextSharp.text.Image
        codigo_seriea = iTextSharp.text.Image.GetInstance(Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".png")
        codigo_seriea.ScaleAbsoluteWidth(100) 'Ancho de la imagen
        codigo_seriea.ScaleAbsoluteHeight(100) 'Altura de la imagen

        Dim codigo_bidimensional As New PdfPCell(codigo_seriea)
        codigo_bidimensional.Colspan = 2
        codigo_bidimensional.Rowspan = 5
        codigo_bidimensional.PaddingTop = 5
        codigo_bidimensional.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(codigo_bidimensional)


        Dim linea2 As New PdfPCell(New Paragraph("Cadena Original del complemento de certificación digital del SAT:", ArialMT8bold))
        linea2.Colspan = 5
        linea2.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea2)

        Dim cadena_original As New PdfPCell(New Paragraph(cadena_original_complemento_certificacion_sta, ArialMT7))
        cadena_original.Colspan = 5
        cadena_original.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(cadena_original)

        Dim linea3 As New PdfPCell(New Paragraph("Sello Digital del CFDI:", ArialMT8bold))
        linea3.Colspan = 5
        linea3.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea3)

        Dim sello_emisor As New PdfPCell(New Paragraph(sello_digital_emisor, ArialMT7))
        sello_emisor.Colspan = 5
        sello_emisor.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(sello_emisor)

        Dim linea4 As New PdfPCell(New Paragraph("Sello del SAT:", ArialMT8bold))
        linea4.Colspan = 5
        linea4.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(linea4)

        Dim linea5 As New PdfPCell(New Paragraph("RFC del proveedor de certificación:" & vbCrLf & rfc_pac, ArialMT8bold))
        linea5.Colspan = 2
        linea5.BorderColor = BaseColor.WHITE
        linea5.HorizontalAlignment = True
        Tablatotales.AddCell(linea5)

        Dim sello_sat As New PdfPCell(New Paragraph(sello_digital_sat, ArialMT7))
        sello_sat.Colspan = 5
        sello_sat.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(sello_sat)





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
        document.Add(TablaDocumentos)
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


