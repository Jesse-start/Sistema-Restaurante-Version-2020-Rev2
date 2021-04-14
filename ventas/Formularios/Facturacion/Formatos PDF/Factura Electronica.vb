Imports System.Xml
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System

Module FacturaElectronica
    Dim serie_certificado_emisor As String = ""
    Dim folio_fiscal As String = ""
    Dim num_serie_certificado_sat As String = ""
    Dim fecha_hora_certificacion As String = ""
    Dim cadena_original_complemento_certificacion_sta As String = ""
    Dim sello_digital_emisor As String = ""
    Dim sello_digital_sat As String = ""
    Dim num_serie As String = ""
    Dim rfc_pac As String = ""
    Private Sub obtener_valores_xml(ByVal id_factura_electronica As Integer)
        Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
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

    Public Sub GenerarFacturaElectronica(ByVal id_factura_electronica As Integer, ByVal concepto_general As Boolean, ByVal cadena_concepto As String)

        'Tryn
        'Intentar generar el documento.
        Dim doc As New Document(PageSize.LETTER, 10, 55, 20, 20)
        'Path que guarda el reporte en el escritorio de windows (Desktop).
        Dim generado As String = Format(Today.Date, "dd-MM-yyyy")
        'Conectar()
        rs.Open("SELECT serie FROM factura_electronica WHERE id_factura_electronica=" & id_factura_electronica, conn)
        If rs.RecordCount > 0 Then
            num_serie = rs.Fields("serie").Value
        End If
        rs.Close()
        'conn.close()
        obtener_valores_xml(id_factura_electronica)

        Dim filename As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".pdf"
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, file)
        doc.Open()
        ExportarDatosPDF_SerieA(doc, writer, id_factura_electronica, concepto_general, cadena_concepto)
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
    Public Sub ExportarDatosPDF_SerieA(ByVal document As Document, ByVal writer As PdfWriter, ByVal id_factura_electronica As Integer, ByVal concepto_general As Boolean, ByVal cadena_concepto As String)
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
        Dim _iva_retenido As String = ""
        Dim _total As String = ""
        Dim id_cliente As Integer = 0
        Dim id_domicilio As Integer = 0
        Dim _fecha As DateTime
        Dim _numero_serie As String = ""
        Dim _uso_cfdi As String = ""

        Dim _forma_pago As String = ""
        Dim _metodo_pago As String = ""
        Dim _cuenta_pago As String = ""
        Dim _condiciones_pago As String = ""


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
        rs.Open("SELECT factura_electronica.fecha,factura_electronica.subtotal,factura_electronica.iva,factura_electronica.iva_retenido,factura_electronica.total,factura_electronica.serie,factura_electronica.condiciones_pago,CONCAT(ctlg_uso_cfdi.clave,' ',ctlg_uso_cfdi.nombre) AS uso_cfdi,pago_cuenta,cliente.id_cliente,cliente.id_domicilio, " & _
                "CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre," & _
                "(SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END as rfc FROM cliente JOIN  factura_electronica ON factura_electronica.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura_electronica.id_factura_electronica=" & id_factura_electronica & ")As RFC " & _
                "FROM factura_electronica " & _
                "JOIN cliente ON factura_electronica.id_cliente=cliente.id_cliente " & _
                "JOIN ctlg_uso_cfdi ON ctlg_uso_cfdi.id_uso_cfdi=factura_electronica.id_uso_cfdi " & _
                "LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "WHERE factura_electronica.id_factura_electronica=" & id_factura_electronica, conn)
        If rs.RecordCount > 0 Then
            _folio = id_factura_electronica
            id_cliente = rs.Fields("id_cliente").Value
            _nombre = rs.Fields("nombre").Value
            _rfc = rs.Fields("rfc").Value
            _subtotal = Replace(FormatCurrency(rs.Fields("subtotal").Value), "$", "")
            _iva = Replace(FormatCurrency(rs.Fields("iva").Value), "$", "")
            _iva_retenido = Replace(FormatCurrency(rs.Fields("iva_retenido").Value), "$", "")
            _total = Replace(FormatCurrency(rs.Fields("total").Value), "$", "")
            id_domicilio = rs.Fields("id_domicilio").Value
            _total_letra = Letras(CDbl(rs.Fields("total").Value))
            _fecha = rs.Fields("fecha").Value
            _condiciones_pago = rs.Fields("condiciones_pago").Value
            _cuenta_pago = rs.Fields("pago_cuenta").Value
            _numero_serie = rs.Fields("serie").Value
            _uso_cfdi = rs.Fields("uso_cfdi").Value

        End If
        rs.Close()

        rw.Open("SELECT CONCAT(fp.clave,' ',fp.nombre) AS forma_pago,CONCAT(mp.clave,' ',mp.nombre) AS metodo_pago " &
                   "FROM factura_electronica fe " &
                   "JOIN forma_pago fp ON fp.id_forma_pago=fe.id_forma_pago " &
                   "JOIN ctlg_metodo_pago mp ON mp.id_metodo_pago=fe.id_metodo_pago " &
                   "WHERE id_factura_electronica=" & id_factura_electronica, conn)
        If rw.RecordCount > 0 Then
            _forma_pago = rw.Fields("forma_pago").Value
            _metodo_pago = rw.Fields("metodo_pago").Value
        End If
        rw.Close()

        rs.Open("SELECT CONCAT(calle,' ',num_ext,' ',num_int,' ',colonia,' ',municipio) domicilio,cp AS cp,municipio,poblacion FROM domicilio WHERE id_domicilio=" & id_domicilio, conn)
        If rs.RecordCount > 0 Then
            _direccion = rs.Fields("domicilio").Value
            _cp = rs.Fields("cp").Value
            _ciudad = rs.Fields("poblacion").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

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


        rs.Open("SELECT fed.id_tipo_relacion, CONCAT(tr.clave,' ',tr.nombre) AS tipo_relacion,fed.UUID " & _
                    "FROM factura_electronica_docs fed " & _
                    "JOIN ctlg_tipo_relacion tr ON tr.id_tipo_relacion=fed.id_tipo_relacion " & _
                    "WHERE fed.id_factura_electronica=" & id_factura_electronica, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cadena_relacion_documentos = cadena_relacion_documentos & " Tipo relación: " & rs.Fields("tipo_relacion").Value & " UUID: " & rs.Fields("UUID").Value & vbCrLf
                rs.MoveNext()
            End While
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

        Dim factura As New PdfPCell(New Paragraph("FACTURA", ArialMT13))
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

        Dim folio As New PdfPCell(New Paragraph(_folio, ArialMT13_black))
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

        Dim email As New PdfPCell(New Paragraph("Tipo de Comprobante: I Ingreso   Atención a clientes:" & emisor_correo & " Tel.: " & emisor_telefono, ArialMT7))
        email.Colspan = 7
        email.PaddingBottom = 8
        email.BorderColor = BaseColor.WHITE
        TablaSerie.AddCell(email)

        Dim lugar_expedicion As New PdfPCell(New Paragraph("Lugar, fecha y hora de emisión: " & emisor_cp & "," & Format(_fecha, "yyyy-MM-ddTHH:mm:ss"), ArialMT7))
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

        Dim dia As New PdfPCell(New Paragraph(Format(_fecha, "dd"), Futuran11))
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


        Dim mes As New PdfPCell(New Paragraph(UCase(nombre_mes(Format(_fecha, "MM"))), Futuran11))
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

        Dim año As New PdfPCell(New Paragraph(Format(_fecha, "yyyy"), Futuran11))
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

        Dim e_nombre As New PdfPCell(New Paragraph("Nombre:", ArialMT10_black))
        e_nombre.PaddingTop = 7
        e_nombre.PaddingBottom = 5
        e_nombre.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_nombre)

        Dim nombre As New PdfPCell(New Paragraph(_nombre, Futuran10))
        nombre.PaddingTop = 7
        nombre.PaddingBottom = 5
        nombre.BorderWidthTop = 0
        nombre.BorderWidthLeft = 0
        nombre.BorderWidthRight = 0
        nombre.Colspan = 10

        TablaDescripcion.AddCell(nombre)

        'Dim e_direccion As New PdfPCell(New Paragraph("Dirección:", ArialMT10_black))
        'e_direccion.PaddingTop = 7
        'e_direccion.PaddingBottom = 5
        'e_direccion.BorderColor = BaseColor.WHITE
        'TablaDescripcion.AddCell(e_direccion)

        'Dim direccion As New PdfPCell(New Paragraph(_direccion & "," & _ciudad, Futuran10))
        'direccion.PaddingTop = 7
        'direccion.PaddingBottom = 5
        'direccion.Colspan = 10
        'direccion.BorderWidthTop = 0
        'direccion.BorderWidthLeft = 0
        'direccion.BorderWidthRight = 0
        'TablaDescripcion.AddCell(direccion)

        Dim e_ciudad As New PdfPCell(New Paragraph("Uso CFDI:", ArialMT10_black))
        e_ciudad.PaddingTop = 7
        e_ciudad.PaddingBottom = 5
        e_ciudad.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_ciudad)

        Dim ciudad As New PdfPCell(New Paragraph(_uso_cfdi, Futuran10))
        ciudad.PaddingTop = 7
        ciudad.PaddingBottom = 5
        ciudad.Colspan = 5
        ciudad.BorderWidthTop = 0
        ciudad.BorderWidthLeft = 0
        ciudad.BorderWidthRight = 0
        TablaDescripcion.AddCell(ciudad)

        'Dim e_cp As New PdfPCell(New Paragraph("CP:", ArialMT10_black))
        'e_cp.PaddingTop = 7
        'e_cp.PaddingBottom = 5
        'e_cp.BorderWidth = 0
        'TablaDescripcion.AddCell(e_cp)

        'Dim cp As New PdfPCell(New Paragraph(_cp, Futuran10))
        'cp.PaddingTop = 7
        'cp.PaddingBottom = 5
        'cp.HorizontalAlignment = Element.ALIGN_CENTER
        'cp.BorderWidthTop = 0
        'cp.BorderWidthLeft = 0
        'cp.BorderWidthRight = 0
        'TablaDescripcion.AddCell(cp)

        Dim e_rfc As New PdfPCell(New Paragraph("RFC:", ArialMT10_black))
        e_rfc.PaddingTop = 7
        e_rfc.PaddingBottom = 5
        e_rfc.HorizontalAlignment = Element.ALIGN_CENTER
        e_rfc.BorderWidth = 0
        TablaDescripcion.AddCell(e_rfc)



        Dim rfc_cliente As New PdfPCell(New Paragraph(_rfc, Futuran10))
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


        Dim e_codigo As New PdfPCell(New Paragraph("Clave ProdServ", ArialMT12))
        e_codigo.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_codigo.BorderColor = BaseColor.WHITE
        e_codigo.HorizontalAlignment = Element.ALIGN_CENTER
        e_codigo.BorderWidthRight = 1.5
        e_codigo.PaddingBottom = 4
        TablaDescripcion.AddCell(e_codigo)

        Dim e_cantidad As New PdfPCell(New Paragraph("Cantidad", ArialMT12))
        e_cantidad.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_cantidad.BorderColor = BaseColor.WHITE
        e_cantidad.HorizontalAlignment = Element.ALIGN_CENTER
        e_cantidad.BorderWidthRight = 1.5
        e_cantidad.PaddingBottom = 4
        TablaDescripcion.AddCell(e_cantidad)

        Dim e_unidad As New PdfPCell(New Paragraph("Unidad", ArialMT12))
        e_unidad.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_unidad.BorderColor = BaseColor.WHITE
        e_unidad.HorizontalAlignment = Element.ALIGN_CENTER
        e_unidad.BorderWidthRight = 1.5
        e_unidad.PaddingBottom = 4

        TablaDescripcion.AddCell(e_unidad)

        Dim e_concepto As New PdfPCell(New Paragraph("Concepto", ArialMT12))
        e_concepto.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_concepto.BorderColor = BaseColor.WHITE
        e_concepto.Colspan = 4
        'e_concepto.HorizontalAlignment = Element.ALIGN_CENTER
        e_concepto.PaddingLeft = 5
        e_concepto.BorderWidthRight = 1.5
        e_concepto.PaddingBottom = 4
        TablaDescripcion.AddCell(e_concepto)

        Dim e_precio As New PdfPCell(New Paragraph("Precio", ArialMT12))
        e_precio.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_precio.BorderColor = BaseColor.WHITE
        e_precio.Colspan = 2
        e_precio.HorizontalAlignment = Element.ALIGN_CENTER
        e_precio.BorderWidthRight = 1.5
        e_precio.PaddingBottom = 4
        TablaDescripcion.AddCell(e_precio)

        Dim e_importe As New PdfPCell(New Paragraph("Importe", ArialMT12))
        e_importe.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(25)))
        e_importe.Colspan = 2
        e_importe.HorizontalAlignment = Element.ALIGN_CENTER
        e_importe.PaddingBottom = 4
        e_importe.BorderColor = BaseColor.WHITE
        TablaDescripcion.AddCell(e_importe)

        Dim max_rows As Integer = 10

        If concepto_general Then
            Dim codigo001 As New PdfPCell(New Paragraph("A1", Futuran8))
            codigo001.MinimumHeight = 15
            'codigo001.PaddingTop = 5
            'codigo001.PaddingBottom = 5
            codigo001.HorizontalAlignment = Element.ALIGN_CENTER
            codigo001.BorderWidthTop = 0
            codigo001.BorderWidthBottom = 0
            codigo001.BorderWidthLeft = 0
            codigo001.BorderWidthRight = 1.5
            codigo001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(codigo001)

            Dim cantidad001 As New PdfPCell(New Paragraph("1", Futuran8))
            cantidad001.MinimumHeight = 15
            'cantidad001.PaddingTop = 5
            'cantidad001.PaddingBottom = 5
            cantidad001.HorizontalAlignment = Element.ALIGN_CENTER
            cantidad001.BorderWidthTop = 0
            cantidad001.BorderWidthBottom = 0
            cantidad001.BorderWidthLeft = 0
            cantidad001.BorderWidthRight = 1.5
            cantidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(cantidad001)

            Dim unidad001 As New PdfPCell(New Paragraph("No Aplica", Futuran8))
            unidad001.MinimumHeight = 15
            ' unidad001.PaddingTop = 5
            ' unidad001.PaddingBottom = 5
            unidad001.HorizontalAlignment = Element.ALIGN_CENTER
            unidad001.BorderWidthTop = 0
            unidad001.BorderWidthBottom = 0
            unidad001.BorderWidthLeft = 0
            unidad001.BorderWidthRight = 1.5
            unidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(unidad001)

            Dim concepto001 As New PdfPCell(New Paragraph(cadena_concepto, Futuran8))
            concepto001.MinimumHeight = 15
            concepto001.Colspan = 4
            'concepto001.PaddingTop = 5
            'concepto001.PaddingBottom = 5
            concepto001.PaddingLeft = 4
            concepto001.HorizontalAlignment = Element.ALIGN_LEFT
            concepto001.BorderWidthTop = 0
            concepto001.BorderWidthBottom = 0
            concepto001.BorderWidthLeft = 0
            concepto001.BorderWidthRight = 1.5
            concepto001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(concepto001)

            Dim signo0101 As New PdfPCell(New Paragraph(" ", Futuran8))
            signo0101.MinimumHeight = 15
            'signo0101.PaddingTop = 5
            'signo0101.PaddingBottom = 5
            signo0101.HorizontalAlignment = Element.ALIGN_CENTER
            signo0101.BorderWidth = 0
            TablaDescripcion.AddCell(signo0101)

            Dim precio001 As New PdfPCell(New Paragraph(_subtotal, Futuran8))
            precio001.MinimumHeight = 15
            'precio001.PaddingTop = 5
            'precio001.PaddingBottom = 5
            precio001.PaddingRight = 5
            precio001.HorizontalAlignment = Element.ALIGN_RIGHT
            precio001.BorderWidthTop = 0
            precio001.BorderWidthBottom = 0
            precio001.BorderWidthLeft = 0
            precio001.BorderWidthRight = 1.5
            precio001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(precio001)


            Dim signo0201 As New PdfPCell(New Paragraph("$", Futuran8))
            signo0201.MinimumHeight = 15
            'signo0201.PaddingTop = 5
            'signo0201.PaddingBottom = 5
            signo0201.HorizontalAlignment = Element.ALIGN_CENTER
            signo0201.BorderWidth = 0
            TablaDescripcion.AddCell(signo0201)


            Dim importe001 As New PdfPCell(New Paragraph(_subtotal, Futuran8))
            importe001.MinimumHeight = 15
            'importe001.PaddingTop = 5
            'importe001.PaddingBottom = 5
            importe001.PaddingRight = 5
            importe001.HorizontalAlignment = Element.ALIGN_RIGHT
            importe001.BorderWidth = 0
            TablaDescripcion.AddCell(importe001)

            max_rows = 9
        Else
            'Conectar()
            rs.Open("SELECT pc.clave AS producto_clave,p.nombre,fed.cantidad,ic.codigo AS clave_impuesto,i.nombre AS nombre_impuesto,fed.total_impuesto,u.nombre AS unidad, u.clave AS clave_unidad,fed.tasa_impuesto,fed.precio,fed.importe,fed.descuento,fed.total_impuesto_retenido,fed.nombre_impuesto_retenido " & _
                    "FROM factura_electronica_detalle fed " & _
                    "JOIN producto p ON p.id_producto=fed.id_producto " & _
                    "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                    "JOIN producto_clavesat pc ON pc.id_clavesat=p.id_clavesat " & _
                    "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                    "JOIN cfg_impuesto_catalogo ic ON ic.id_cfg_impuesto_catalogo=i.id_cfg_impuesto_catalogo " & _
                    "WHERE fed.id_factura_electronica = " & id_factura_electronica, conn)
            If rs.RecordCount > 0 Then
                max_rows = max_rows - rs.RecordCount
                While Not rs.EOF
                    Dim codigo001 As New PdfPCell(New Paragraph(rs.Fields("producto_clave").Value, Futuran8))
                    codigo001.MinimumHeight = 15
                    'codigo001.PaddingTop = 5
                    ' codigo001.PaddingBottom = 5
                    codigo001.HorizontalAlignment = Element.ALIGN_CENTER
                    codigo001.BorderWidthTop = 0
                    codigo001.BorderWidthBottom = 0
                    codigo001.BorderWidthLeft = 0
                    codigo001.BorderWidthRight = 1.5
                    codigo001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(codigo001)

                    Dim cantidad001 As New PdfPCell(New Paragraph(rs.Fields("cantidad").Value, Futuran8))
                    cantidad001.MinimumHeight = 15
                    'cantidad001.PaddingTop = 5
                    'cantidad001.PaddingBottom = 5
                    cantidad001.HorizontalAlignment = Element.ALIGN_CENTER
                    cantidad001.BorderWidthTop = 0
                    cantidad001.BorderWidthBottom = 0
                    cantidad001.BorderWidthLeft = 0
                    cantidad001.BorderWidthRight = 1.5
                    cantidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(cantidad001)

                    Dim unidad001 As New PdfPCell(New Paragraph(rs.Fields("clave_unidad").Value & "-" & rs.Fields("unidad").Value, Futuran8))
                    unidad001.MinimumHeight = 15
                    ' unidad001.PaddingTop = 5
                    'unidad001.PaddingBottom = 5
                    unidad001.HorizontalAlignment = Element.ALIGN_CENTER
                    unidad001.BorderWidthTop = 0
                    unidad001.BorderWidthBottom = 0
                    unidad001.BorderWidthLeft = 0
                    unidad001.BorderWidthRight = 1.5
                    unidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(unidad001)
                    Dim cadena_retenciones As String = ""
                    If rs.Fields("total_impuesto_retenido").Value > 0 Then
                        cadena_retenciones = " Retenidos: 002 " & rs.Fields("nombre_impuesto_retenido").Value & ": " & FormatCurrency(rs.Fields("total_impuesto_retenido").Value) & " Factor:Tasa "
                    End If

                    Dim concepto001 As New PdfPCell(New Paragraph(rs.Fields("nombre").Value & vbCrLf & "Descuento:" & FormatCurrency(rs.Fields("descuento").Value) & " Impuestos: Traslado " & rs.Fields("clave_impuesto").Value & " " & rs.Fields("nombre_impuesto").Value & ":" & FormatCurrency(rs.Fields("total_impuesto").Value) & " Factor:Tasa" & vbCrLf & cadena_retenciones, Futuran8))
                    concepto001.MinimumHeight = 15

                    concepto001.Colspan = 4
                    'concepto001.PaddingTop = 5
                    'concepto001.PaddingBottom = 5
                    concepto001.PaddingLeft = 4
                    concepto001.HorizontalAlignment = Element.ALIGN_LEFT
                    concepto001.BorderWidthTop = 0
                    concepto001.BorderWidthBottom = 0
                    concepto001.BorderWidthLeft = 0
                    concepto001.BorderWidthRight = 1.5
                    concepto001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(concepto001)

                    Dim signo0101 As New PdfPCell(New Paragraph("$", Futuran8))
                    signo0101.MinimumHeight = 15

                    'signo0101.PaddingTop = 5
                    'signo0101.PaddingBottom = 5
                    signo0101.HorizontalAlignment = Element.ALIGN_CENTER
                    signo0101.BorderWidth = 0
                    TablaDescripcion.AddCell(signo0101)

                    Dim precio001 As New PdfPCell(New Paragraph(Replace(FormatCurrency(rs.Fields("precio").Value), "$", ""), Futuran8))
                    precio001.MinimumHeight = 15

                    'precio001.PaddingTop = 5
                    'precio001.PaddingBottom = 5
                    precio001.PaddingRight = 5
                    precio001.HorizontalAlignment = Element.ALIGN_RIGHT
                    precio001.BorderWidthTop = 0
                    precio001.BorderWidthBottom = 0
                    precio001.BorderWidthLeft = 0
                    precio001.BorderWidthRight = 1.5
                    precio001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
                    TablaDescripcion.AddCell(precio001)


                    Dim signo0201 As New PdfPCell(New Paragraph("$", Futuran8))
                    signo0201.MinimumHeight = 15
                    'signo0201.PaddingTop = 5
                    'signo0201.PaddingBottom = 5
                    signo0201.HorizontalAlignment = Element.ALIGN_CENTER
                    signo0201.BorderWidth = 0
                    TablaDescripcion.AddCell(signo0201)


                    Dim importe001 As New PdfPCell(New Paragraph(Replace(FormatCurrency(rs.Fields("importe").Value), "$", ""), Futuran8))
                    importe001.MinimumHeight = 15
                    ' importe001.PaddingTop = 5
                    'importe001.PaddingBottom = 5
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

            Dim codigo001 As New PdfPCell(New Paragraph(" ", Futuran8))
            codigo001.MinimumHeight = 15

            'codigo001.PaddingTop = 5
            'codigo001.PaddingBottom = 5
            codigo001.HorizontalAlignment = Element.ALIGN_CENTER
            codigo001.BorderWidthTop = 0
            codigo001.BorderWidthBottom = 0
            codigo001.BorderWidthLeft = 0
            codigo001.BorderWidthRight = 1.5
            codigo001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(codigo001)

            Dim cantidad001 As New PdfPCell(New Paragraph(" ", Futuran8))
            cantidad001.MinimumHeight = 15

            'cantidad001.PaddingTop = 5
            'cantidad001.PaddingBottom = 5
            cantidad001.HorizontalAlignment = Element.ALIGN_CENTER
            cantidad001.BorderWidthTop = 0
            cantidad001.BorderWidthBottom = 0
            cantidad001.BorderWidthLeft = 0
            cantidad001.BorderWidthRight = 1.5
            cantidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(cantidad001)

            Dim unidad001 As New PdfPCell(New Paragraph(" ", Futuran8))
            unidad001.MinimumHeight = 15
            'unidad001.PaddingTop = 5
            'unidad001.PaddingBottom = 5
            unidad001.HorizontalAlignment = Element.ALIGN_CENTER
            unidad001.BorderWidthTop = 0
            unidad001.BorderWidthBottom = 0
            unidad001.BorderWidthLeft = 0
            unidad001.BorderWidthRight = 1.5
            unidad001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(unidad001)

            Dim concepto001 As New PdfPCell(New Paragraph(" ", Futuran8))
            concepto001.MinimumHeight = 15

            concepto001.Colspan = 4
            'concepto001.PaddingTop = 5
            'concepto001.PaddingBottom = 5
            concepto001.PaddingLeft = 4
            concepto001.HorizontalAlignment = Element.ALIGN_LEFT
            concepto001.BorderWidthTop = 0
            concepto001.BorderWidthBottom = 0
            concepto001.BorderWidthLeft = 0
            concepto001.BorderWidthRight = 1.5
            concepto001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(concepto001)

            Dim signo0101 As New PdfPCell(New Paragraph(" ", Futuran8))
            signo0101.MinimumHeight = 15
            'signo0101.PaddingTop = 5
            'signo0101.PaddingBottom = 5
            signo0101.HorizontalAlignment = Element.ALIGN_CENTER
            signo0101.BorderWidth = 0
            TablaDescripcion.AddCell(signo0101)

            Dim precio001 As New PdfPCell(New Paragraph(" ", Futuran8))
            precio001.MinimumHeight = 15
            'precio001.PaddingTop = 5
            ' precio001.PaddingBottom = 5
            precio001.PaddingRight = 5
            precio001.HorizontalAlignment = Element.ALIGN_RIGHT
            precio001.BorderWidthTop = 0
            precio001.BorderWidthBottom = 0
            precio001.BorderWidthLeft = 0
            precio001.BorderWidthRight = 1.5
            precio001.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(-4407872))
            TablaDescripcion.AddCell(precio001)


            Dim signo0201 As New PdfPCell(New Paragraph(" ", Futuran8))
            signo0201.MinimumHeight = 15
            'signo0201.PaddingTop = 5
            'signo0201.PaddingBottom = 5
            signo0201.HorizontalAlignment = Element.ALIGN_CENTER
            signo0201.BorderWidth = 0
            TablaDescripcion.AddCell(signo0201)


            Dim importe001 As New PdfPCell(New Paragraph(" ", Futuran8))
            importe001.MinimumHeight = 15
            'importe001.PaddingTop = 5
            'importe001.PaddingBottom = 5
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

        Dim total_letra As New PdfPCell(New Paragraph(_total_letra, Futuran9))
        total_letra.Colspan = 4
        total_letra.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
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
        signo03.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        signo03.PaddingBottom = 3
        signo03.PaddingRight = 4
        signo03.PaddingTop = 7
        signo03.HorizontalAlignment = Element.ALIGN_RIGHT
        signo03.BorderColorTop = BaseColor.WHITE
        signo03.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        signo03.BorderColorLeft = BaseColor.WHITE
        signo03.BorderWidthRight = 0
        Tablatotales.AddCell(signo03)

        Dim subtotal As New PdfPCell(New Paragraph(_subtotal, Futuran11))
        subtotal.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        subtotal.PaddingBottom = 3
        subtotal.PaddingRight = 4
        subtotal.PaddingTop = 7
        subtotal.HorizontalAlignment = Element.ALIGN_RIGHT
        subtotal.BorderColorTop = BaseColor.WHITE
        subtotal.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        subtotal.BorderWidthLeft = 0
        subtotal.BorderWidthRight = 0
        subtotal.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))

        Tablatotales.AddCell(subtotal)




        Dim exhibicion3 As New PdfPCell(New Paragraph("Serie del Certificado del CSD:", ArialMT8bold))
        exhibicion3.BorderWidthRight = 0
        exhibicion3.BorderWidthTop = 0
        exhibicion3.BorderWidthBottom = 0
        exhibicion3.BorderWidthLeft = 0
        exhibicion3.Colspan = 3
        Tablatotales.AddCell(exhibicion3)


        Dim cheque3 As New PdfPCell(New Paragraph(serie_certificado_emisor, ArialMT8))
        cheque3.Border = 0
        Tablatotales.AddCell(cheque3)

        Dim e_total3 As New PdfPCell(New Paragraph("IVA 16%:", ArialMT12_black))
        e_total3.Rowspan = 3
        e_total3.PaddingBottom = 3
        e_total3.PaddingRight = 10
        e_total3.PaddingTop = 10
        e_total3.HorizontalAlignment = Element.ALIGN_RIGHT
        e_total3.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(e_total3)

        Dim signo053 As New PdfPCell(New Paragraph("$", Futuran11))
        signo053.Rowspan = 3
        signo053.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        signo053.PaddingBottom = 3
        signo053.PaddingRight = 4
        signo053.PaddingTop = 10
        signo053.BorderWidthTop = 5
        signo053.BorderWidthBottom = 3
        signo053.HorizontalAlignment = Element.ALIGN_RIGHT
        signo053.BorderColorTop = BaseColor.WHITE
        signo053.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        signo053.BorderColorLeft = BaseColor.WHITE
        signo053.BorderWidthRight = 0
        Tablatotales.AddCell(signo053)

        Dim total3 As New PdfPCell(New Paragraph(_iva, Futuran11))
        total3.Rowspan = 3
        total3.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        total3.PaddingBottom = 3
        total3.PaddingRight = 4
        total3.BorderWidthTop = 5
        total3.BorderWidthBottom = 3
        total3.PaddingTop = 10
        total3.HorizontalAlignment = Element.ALIGN_RIGHT
        total3.BorderColorTop = BaseColor.WHITE
        total3.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        total3.BorderWidthLeft = 0
        total3.BorderWidthRight = 0
        Tablatotales.AddCell(total3)

        Dim blank001_c13 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c13.Border = 0
        Tablatotales.AddCell(blank001_c13)

        Dim blank001_c23 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c23.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank001_c23)

        Dim blank001_c33 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c33.Border = 0
        Tablatotales.AddCell(blank001_c33)

        Dim blank001_c43 As New PdfPCell(New Paragraph("", ArialMT7))
        blank001_c43.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank001_c43)



        Dim parcialidades3 As New PdfPCell(New Paragraph("Folio Fiscal:", ArialMT8bold))
        parcialidades3.BorderWidthRight = 0
        parcialidades3.BorderWidthTop = 0
        parcialidades3.BorderWidthBottom = 0
        parcialidades3.BorderWidthLeft = 0
        parcialidades3.Colspan = 3
        Tablatotales.AddCell(parcialidades3)


        Dim trasferencia3 As New PdfPCell(New Paragraph(folio_fiscal, ArialMT8))
        trasferencia3.Border = 0
        Tablatotales.AddCell(trasferencia3)


        Dim blank002_c13 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c13.Border = 0
        Tablatotales.AddCell(blank002_c13)

        Dim blank002_c23 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c23.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank002_c23)

        Dim blank002_c33 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c33.Border = 0
        Tablatotales.AddCell(blank002_c33)

        Dim blank002_c43 As New PdfPCell(New Paragraph("", ArialMT7))
        blank002_c43.Colspan = 4
        blank002_c43.BorderColor = BaseColor.WHITE
        Tablatotales.AddCell(blank002_c43)

        If _iva_retenido > 0 Then

            '========================RETENCIONES
            Dim total_letra1 As New PdfPCell(New Paragraph("", Futuran9))
            total_letra1.Colspan = 4
            total_letra1.HorizontalAlignment = Element.ALIGN_CENTER
            total_letra1.Border = 0
            Tablatotales.AddCell(total_letra1)


            Dim e_subtotal1 As New PdfPCell(New Paragraph("IVA R. 4%:", ArialMT12_black))
            e_subtotal1.PaddingBottom = 3
            e_subtotal1.PaddingRight = 10
            e_subtotal1.PaddingTop = 7
            e_subtotal1.HorizontalAlignment = Element.ALIGN_RIGHT
            e_subtotal1.BorderColor = BaseColor.WHITE
            Tablatotales.AddCell(e_subtotal1)

            Dim signo031 As New PdfPCell(New Paragraph("$", Futuran11))
            signo031.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
            signo031.PaddingBottom = 3
            signo031.PaddingRight = 4
            signo031.PaddingTop = 7
            signo031.HorizontalAlignment = Element.ALIGN_RIGHT
            signo031.BorderColorTop = BaseColor.WHITE
            signo031.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
            signo031.BorderColorLeft = BaseColor.WHITE
            signo031.BorderWidthRight = 0
            Tablatotales.AddCell(signo031)

            Dim subtotal1 As New PdfPCell(New Paragraph(_iva_retenido, Futuran11))
            subtotal1.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
            subtotal1.PaddingBottom = 3
            subtotal1.PaddingRight = 4
            subtotal1.PaddingTop = 7
            subtotal1.HorizontalAlignment = Element.ALIGN_RIGHT
            subtotal1.BorderColorTop = BaseColor.WHITE
            subtotal1.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
            subtotal1.BorderWidthLeft = 0
            subtotal1.BorderWidthRight = 0
            subtotal1.BorderColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))

            Tablatotales.AddCell(subtotal1)
            '=========

        End If

        Dim exhibicion As New PdfPCell(New Paragraph("No de Serie del Certificado del SAT:", ArialMT8bold))
        exhibicion.BorderWidthRight = 0
        exhibicion.BorderWidthTop = 0
        exhibicion.BorderWidthBottom = 0
        exhibicion.BorderWidthLeft = 0
        exhibicion.Colspan = 3
        Tablatotales.AddCell(exhibicion)


        Dim cheque As New PdfPCell(New Paragraph(num_serie_certificado_sat, ArialMT8))
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
        signo05.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        signo05.PaddingBottom = 3
        signo05.PaddingRight = 4
        signo05.PaddingTop = 10
        signo05.BorderWidthTop = 5
        signo05.BorderWidthBottom = 3
        signo05.HorizontalAlignment = Element.ALIGN_RIGHT
        signo05.BorderColorTop = BaseColor.WHITE
        signo05.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        signo05.BorderColorLeft = BaseColor.WHITE
        signo05.BorderWidthRight = 0
        Tablatotales.AddCell(signo05)

        Dim total As New PdfPCell(New Paragraph(_total, Futuran11))
        total.Rowspan = 3
        total.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
        total.PaddingBottom = 3
        total.PaddingRight = 4
        total.BorderWidthTop = 5
        total.BorderWidthBottom = 3
        total.PaddingTop = 10
        total.HorizontalAlignment = Element.ALIGN_RIGHT
        total.BorderColorTop = BaseColor.WHITE
        total.BorderColorBottom = New BaseColor(System.Drawing.Color.FromArgb(conf_colores(27)))
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


        Dim parcialidades As New PdfPCell(New Paragraph("Fecha y hora de certificación", ArialMT8bold))
        parcialidades.BorderWidthRight = 0
        parcialidades.BorderWidthTop = 0
        parcialidades.BorderWidthBottom = 0
        parcialidades.BorderWidthLeft = 0
        parcialidades.Colspan = 3
        Tablatotales.AddCell(parcialidades)

        Dim trasferencia As New PdfPCell(New Paragraph(fecha_hora_certificacion, ArialMT8))
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

        Dim efectivo As New PdfPCell(New Paragraph("Metodo de pago:" & _metodo_pago & "   Forma de pago: " & _forma_pago, ArialMT7))
        efectivo.Colspan = 4
        efectivo.Border = 0
        Tablatotales.AddCell(efectivo)

        Dim efectivo2 As New PdfPCell(New Paragraph("Condiciones de pago:", ArialMT7))
        efectivo2.Border = 0
        efectivo2.Colspan = 2
        Tablatotales.AddCell(efectivo2)

        Dim efectivo3 As New PdfPCell(New Paragraph(_condiciones_pago, ArialMT7))
        efectivo3.Border = 0
        Tablatotales.AddCell(efectivo3)


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


        Dim relacion As New PdfPCell(New Paragraph(cadena_relacion_documentos, ArialMT7))
        relacion.Colspan = 7
        relacion.Border = 0
        relacion.HorizontalAlignment = Element.ALIGN_CENTER
        Tablatotales.AddCell(relacion)
       


        Dim leyenda As New PdfPCell(New Paragraph("Este documento es una representación impresa de un CFDI", Futuran9_white))
        leyenda.Colspan = 7
        leyenda.BackgroundColor = New BaseColor(System.Drawing.Color.FromArgb(-12566463))
        leyenda.PaddingTop = 2
        leyenda.PaddingBottom = 2
        leyenda.HorizontalAlignment = Element.ALIGN_CENTER
        leyenda.BorderColor = BaseColor.WHITE

        Tablatotales.AddCell(leyenda)


        Dim codigo_seriea As iTextSharp.text.Image
        codigo_seriea = iTextSharp.text.Image.GetInstance(Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".png")
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


