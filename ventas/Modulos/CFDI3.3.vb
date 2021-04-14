Imports CFD33.CFDx
Imports System.Security.Cryptography
Imports System.Xml.Serialization
Imports System.Reflection
Module CFDI3
    Public Sub Genera_CFDI3_3(ByVal id_factura As Integer, num_serie As String)


        Dim t As Date
        Dim s As String
        t = Now

        Try

            Dim CFDs As New CFD33.CFDx

            'Crea factura con datos basicos
            facturaNormal(CFDs, id_factura)

            'Ejemplo factura tipo pag
            'FacturaPagos(CFDs)

            'Factura con todos los metodos
            'TodosLosMetodos(CFDs)

            Dim Path As String = Application.StartupPath
            Dim CertFile As String = certificado_sat
            Dim KeyFile As String = clave_sat
            Dim KeyPass As String = contrasena_sat

            Dim Errores As String = ""
            Dim CO As String = ""

            Dim NC As String = ""
            Dim LlavePrivada As String = ""
            CFDs.ValidaCer(CertFile)



            'Funcion para crear el CFDI te regresa boleano true o false y la variable Errores te devuelve el error en caso de que sea false
            'Parametros:
            'Ruta de donde se creara el xml (string)
            'Ruta del archivo key (string)
            'Password del key (string)
            'Ruta del archivo .cer (string)
            'Parametro si existen errores ahi se mostrara el error (string)
            'Parametro que regresa la cadena original del cfdi generado (string)
            'Parametro que regresa Numero de certificado (string)
            If CFDs.CreaFacturaXML(Path & "/CFDI3.3/temp/" & global_rfc & num_serie & Format(id_factura, "0000000000") & ".xml", KeyFile, KeyPass, CertFile, Errores, CO, NC) = False Then
                MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
            Else

                'Dim nodo As String = "<tfd:TimbreFiscalDigital version=""1.0"" xsi:schemaLocation=""http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/TimbreFiscalDigital/TimbreFiscalDigital.xsd"" UUID=""FC30F384-131A-4602-BAD1-92C6FE38BF74"" selloSAT=""Xb/iZu88U1cm6MLwBGuW8CmBhLTxrnpZLKykwtznPdwLLuPfZawH699fTyeF2qaBzn2FTm9dZfdYFI2UXxSLT2CQzSG84SEa+GTrVpUPtGWjr0jR5i53MPQTm8BVJa9pWGMNcPzFfXIoNpTGGj7GcbnxuIj/RVWcIjat/C17xLQ="" noCertificadoSAT=""30001000000100000801"" selloCFD=""nsRcKnHDhyC9j6sSic9DT4mndOl6Mx+sSJTgJDnaOZezxQgtlATlPU4g+bJIycqZUE3iiPAalpGHLZd6v555dKDpxyauvI94SwlGRMcZDn0vyClDWoFGz1GM5GGw6z5KRrhJ+FOPqKqcJ8pLrqnfQHW0NykqRPQY4hET+HHO/90="" FechaTimbrado=""2017-03-17T12:07:13"" xmlns:tfd=""http://www.sat.gob.mx/TimbreFiscalDigital""/>"

                'Funcion que agrega el nodo timbre, si todo esta bien regresa un string vacio en caso contrario te regresa los errores
                'Parametros:
                'Nodo (String)
                'Ruta del archivo al que se le agregará el nodo timbre (string)
                'Dim r As String = CFDs.AgregaNodoTimbreFiscalString(nodo, "C:\XMLCreado.xml")


                Dim uuid As String
                Dim fecha As String
                Dim xmltimbrado As String
                Dim sellosat As String
                Dim noCertificadoSAT As String
                Dim MensajeIncidencia As String
                Dim codigoincidencia As String
                Dim re As String
                Dim sellocfd As String
                Dim CadenaOriginalSAT As String
                Dim version As String

                'timbrado dotnet
                'los datos rfcemisor, receptor y total sirven para crear el CBB
                're = CFDs.TimbrarDNPruebas("https://timbradopruebas.stagefacturador.com/timbrado.asmx", "test", "TEST", "C:\XMLCreado.xml", "C:\XMLCreado.png", "rfcemisor", "rfcreceptor", "100", version, fecha, sellocfd, noCertificadoSAT, sellosat, uuid, CadenaOriginalSAT)
                'Si re="" es correcto en caso contrario te regresara el error

                'timbradofinkok
                're = CFDs.TimbraFINKOK_DEMO("C:\XMLCreado.xml", "usuario", "password", uuid, sellosat, noCertificadoSAT, fecha, xmltimbrado, MensajeIncidencia, codigoincidencia)
                'si es 000 es correcto 


                If re = "000" Or re = "" Then
                    MsgBox("Se ha generado el archivo XML correctamente")
                Else
                    MsgBox(re & " " & MensajeIncidencia)
                End If


                MsgBox("Proceso Terminado!", MsgBoxStyle.Information)
            End If


            'If CFDs.CreaFacturaXMLNomina12("C:\XMLCreado.xml", KeyFile, KeyPass, CertFile, Errores, CO, NC) = False Then
            '    MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
            'Else
            '    MsgBox("Proceso Terminado!", MsgBoxStyle.Information)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Genera_CFDI3_3_nota(ByVal id_nota As Integer, ByVal num_serie As String)


        Dim t As Date
        Dim s As String
        t = Now

        Try

            Dim CFDs As New CFD33.CFDx

            'Crea factura con datos basicos
            nota_credito(CFDs, id_nota)

            'Ejemplo factura tipo pag
            'FacturaPagos(CFDs)

            'Factura con todos los metodos
            'TodosLosMetodos(CFDs)

            Dim Path As String = Application.StartupPath
            Dim CertFile As String = certificado_sat
            Dim KeyFile As String = clave_sat
            Dim KeyPass As String = contrasena_sat

            Dim Errores As String = ""
            Dim CO As String = ""

            Dim NC As String = ""
            Dim LlavePrivada As String = ""
            CFDs.ValidaCer(CertFile)



            'Funcion para crear el CFDI te regresa boleano true o false y la variable Errores te devuelve el error en caso de que sea false
            'Parametros:
            'Ruta de donde se creara el xml (string)
            'Ruta del archivo key (string)
            'Password del key (string)
            'Ruta del archivo .cer (string)
            'Parametro si existen errores ahi se mostrara el error (string)
            'Parametro que regresa la cadena original del cfdi generado (string)
            'Parametro que regresa Numero de certificado (string)
            If CFDs.CreaFacturaXML(Path & "/CFDI3.3/temp/" & global_rfc & num_serie & Format(id_nota, "0000000000") & ".xml", KeyFile, KeyPass, CertFile, Errores, CO, NC) = False Then
                MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
            Else

                'Dim nodo As String = "<tfd:TimbreFiscalDigital version=""1.0"" xsi:schemaLocation=""http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/TimbreFiscalDigital/TimbreFiscalDigital.xsd"" UUID=""FC30F384-131A-4602-BAD1-92C6FE38BF74"" selloSAT=""Xb/iZu88U1cm6MLwBGuW8CmBhLTxrnpZLKykwtznPdwLLuPfZawH699fTyeF2qaBzn2FTm9dZfdYFI2UXxSLT2CQzSG84SEa+GTrVpUPtGWjr0jR5i53MPQTm8BVJa9pWGMNcPzFfXIoNpTGGj7GcbnxuIj/RVWcIjat/C17xLQ="" noCertificadoSAT=""30001000000100000801"" selloCFD=""nsRcKnHDhyC9j6sSic9DT4mndOl6Mx+sSJTgJDnaOZezxQgtlATlPU4g+bJIycqZUE3iiPAalpGHLZd6v555dKDpxyauvI94SwlGRMcZDn0vyClDWoFGz1GM5GGw6z5KRrhJ+FOPqKqcJ8pLrqnfQHW0NykqRPQY4hET+HHO/90="" FechaTimbrado=""2017-03-17T12:07:13"" xmlns:tfd=""http://www.sat.gob.mx/TimbreFiscalDigital""/>"

                'Funcion que agrega el nodo timbre, si todo esta bien regresa un string vacio en caso contrario te regresa los errores
                'Parametros:
                'Nodo (String)
                'Ruta del archivo al que se le agregará el nodo timbre (string)
                'Dim r As String = CFDs.AgregaNodoTimbreFiscalString(nodo, "C:\XMLCreado.xml")




                Dim uuid As String
                Dim fecha As String
                Dim xmltimbrado As String
                Dim sellosat As String
                Dim noCertificadoSAT As String
                Dim MensajeIncidencia As String
                Dim codigoincidencia As String
                Dim re As String
                Dim sellocfd As String
                Dim CadenaOriginalSAT As String
                Dim version As String

                'timbrado dotnet
                'los datos rfcemisor, receptor y total sirven para crear el CBB
                're = CFDs.TimbrarDNPruebas("https://timbradopruebas.stagefacturador.com/timbrado.asmx", "test", "TEST", "C:\XMLCreado.xml", "C:\XMLCreado.png", "rfcemisor", "rfcreceptor", "100", version, fecha, sellocfd, noCertificadoSAT, sellosat, uuid, CadenaOriginalSAT)
                'Si re="" es correcto en caso contrario te regresara el error

                'timbradofinkok
                're = CFDs.TimbraFINKOK_DEMO("C:\XMLCreado.xml", "usuario", "password", uuid, sellosat, noCertificadoSAT, fecha, xmltimbrado, MensajeIncidencia, codigoincidencia)
                'si es 000 es correcto 


                If re = "000" Or re = "" Then
                    MsgBox("Se ha genera el archivo XML correctamente")
                Else
                    MsgBox(re & " " & MensajeIncidencia)
                End If
            End If


            'If CFDs.CreaFacturaXMLNomina12("C:\XMLCreado.xml", KeyFile, KeyPass, CertFile, Errores, CO, NC) = False Then
            '    MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
            'Else
            '    MsgBox("Proceso Terminado!", MsgBoxStyle.Information)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Public Sub Genera_CFDI3_3_pago(ByVal id_recibo_pago As Integer, ByVal num_serie As String)


        Dim t As Date
        Dim s As String
        t = Now

        Try

            Dim CFDs As New CFD33.CFDx

            'Crea factura con datos basicos
            FacturaPagos(CFDs, id_recibo_pago)

            'Ejemplo factura tipo pag
            'FacturaPagos(CFDs)

            'Factura con todos los metodos
            'TodosLosMetodos(CFDs)

            Dim Path As String = Application.StartupPath
            Dim CertFile As String = certificado_sat
            Dim KeyFile As String = clave_sat
            Dim KeyPass As String = contrasena_sat

            Dim Errores As String = ""
            Dim CO As String = ""

            Dim NC As String = ""
            Dim LlavePrivada As String = ""
            CFDs.ValidaCer(CertFile)



            'Funcion para crear el CFDI te regresa boleano true o false y la variable Errores te devuelve el error en caso de que sea false
            'Parametros:
            'Ruta de donde se creara el xml (string)
            'Ruta del archivo key (string)
            'Password del key (string)
            'Ruta del archivo .cer (string)
            'Parametro si existen errores ahi se mostrara el error (string)
            'Parametro que regresa la cadena original del cfdi generado (string)
            'Parametro que regresa Numero de certificado (string)
            If CFDs.CreaFacturaXML(Path & "/CFDI3.3/temp/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml", KeyFile, KeyPass, CertFile, Errores, CO, NC) = False Then
                MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
            Else

                'Dim nodo As String = "<tfd:TimbreFiscalDigital version=""1.0"" xsi:schemaLocation=""http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/TimbreFiscalDigital/TimbreFiscalDigital.xsd"" UUID=""FC30F384-131A-4602-BAD1-92C6FE38BF74"" selloSAT=""Xb/iZu88U1cm6MLwBGuW8CmBhLTxrnpZLKykwtznPdwLLuPfZawH699fTyeF2qaBzn2FTm9dZfdYFI2UXxSLT2CQzSG84SEa+GTrVpUPtGWjr0jR5i53MPQTm8BVJa9pWGMNcPzFfXIoNpTGGj7GcbnxuIj/RVWcIjat/C17xLQ="" noCertificadoSAT=""30001000000100000801"" selloCFD=""nsRcKnHDhyC9j6sSic9DT4mndOl6Mx+sSJTgJDnaOZezxQgtlATlPU4g+bJIycqZUE3iiPAalpGHLZd6v555dKDpxyauvI94SwlGRMcZDn0vyClDWoFGz1GM5GGw6z5KRrhJ+FOPqKqcJ8pLrqnfQHW0NykqRPQY4hET+HHO/90="" FechaTimbrado=""2017-03-17T12:07:13"" xmlns:tfd=""http://www.sat.gob.mx/TimbreFiscalDigital""/>"

                'Funcion que agrega el nodo timbre, si todo esta bien regresa un string vacio en caso contrario te regresa los errores
                'Parametros:
                'Nodo (String)
                'Ruta del archivo al que se le agregará el nodo timbre (string)
                'Dim r As String = CFDs.AgregaNodoTimbreFiscalString(nodo, "C:\XMLCreado.xml")




                Dim uuid As String
                Dim fecha As String
                Dim xmltimbrado As String
                Dim sellosat As String
                Dim noCertificadoSAT As String
                Dim MensajeIncidencia As String
                Dim codigoincidencia As String
                Dim re As String
                Dim sellocfd As String
                Dim CadenaOriginalSAT As String
                Dim version As String

                'timbrado dotnet
                'los datos rfcemisor, receptor y total sirven para crear el CBB
                're = CFDs.TimbrarDNPruebas("https://timbradopruebas.stagefacturador.com/timbrado.asmx", "test", "TEST", "C:\XMLCreado.xml", "C:\XMLCreado.png", "rfcemisor", "rfcreceptor", "100", version, fecha, sellocfd, noCertificadoSAT, sellosat, uuid, CadenaOriginalSAT)
                'Si re="" es correcto en caso contrario te regresara el error

                'timbradofinkok
                're = CFDs.TimbraFINKOK_DEMO("C:\XMLCreado.xml", "usuario", "password", uuid, sellosat, noCertificadoSAT, fecha, xmltimbrado, MensajeIncidencia, codigoincidencia)
                'si es 000 es correcto 


                If re = "000" Or re = "" Then
                    MsgBox("Se ha genera el archivo XML correctamente")
                Else
                    MsgBox(re & " " & MensajeIncidencia)
                End If
            End If


            'If CFDs.CreaFacturaXMLNomina12("C:\XMLCreado.xml", KeyFile, KeyPass, CertFile, Errores, CO, NC) = False Then
            '    MsgBox("Se encontraron los siguientes Errores:" & vbNewLine & Errores, MsgBoxStyle.Exclamation)
            'Else
            '    MsgBox("Proceso Terminado!", MsgBoxStyle.Information)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub facturaNormal(ByRef objeto As CFD33.CFDx, ByVal id_factura As Integer)


        '==============INFORMACION PARA GENERAR ARCHIVO XML 3.3====================
        Dim numero_serie As String = ""
        Dim id_cliente As Integer = 0
        Dim fecha_elaboracion As DateTime
        Dim descuento As Decimal = 0
        Dim total As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_iva_retenido As Decimal = 0


        Dim forma_pago As String = ""
        Dim metodo_pago As String = ""
        Dim condiciones_pago As String = ""
        Dim lugar_expedicion As String = ""
        Dim tipo_cambio As String = ""
        Dim moneda As String = "MXN"

        Dim emisor_razon_social As String = ""
        Dim emisor_rfc As String = ""
        Dim emisor_regimen As String = ""


        Dim receptor_uso_cfdi As String = ""
        Dim receptor_razon_social As String = ""
        Dim receptor_rfc As String = ""


        rs.Open("SELECT c.razon_social,c.rfc,c.cp,rf.clave AS regimen_fiscal " & _
                "FROM configuracion c " & _
                "JOIN ctlg_regimen_fiscal rf ON rf.id_regimen_fiscal=c.id_regimen_fiscal " & _
                "WHERE id_configuracion = 1", conn)
        If rs.RecordCount > 0 Then
            emisor_razon_social = rs.Fields("razon_social").Value
            emisor_rfc = rs.Fields("rfc").Value
            lugar_expedicion = rs.Fields("cp").Value
            emisor_regimen = rs.Fields("regimen_fiscal").Value
        End If
        rs.Close()

        '==============================================
        rs.Open("SELECT CASE WHEN c.id_persona = 0 THEN  e.razon_social ELSE CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) END AS razon_social, " &
                "CASE WHEN c.id_persona = 0 THEN  e.rfc ELSE p.rfc END AS registro, " &
                "fe.serie,fe.fecha,fe.subtotal,fe.iva,fe.iva_retenido,fe.total,fe.descuento,fe.tipo_cambio,fp.clave AS forma_pago,mp.clave AS metodo_pago,uc.clave AS uso_cfdi,fe.condiciones_pago " &
                "FROM factura_electronica fe " &
                "JOIN cliente c ON c.id_cliente=fe.id_cliente " &
                "JOIN forma_pago fp ON fp.id_forma_pago=fe.id_forma_pago " &
                "JOIN ctlg_metodo_pago mp ON mp.id_metodo_pago=fe.id_metodo_pago " &
                "JOIN ctlg_uso_cfdi uc ON uc.id_uso_cfdi=fe.id_uso_cfdi " &
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " &
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa  " &
                "WHERE fe.id_factura_electronica=" & id_factura, conn)
        If rs.RecordCount > 0 Then
            receptor_razon_social = rs.Fields("razon_social").Value
            receptor_rfc = rs.Fields("registro").Value
            numero_serie = rs.Fields("serie").Value
            fecha_elaboracion = rs.Fields("fecha").Value
            subtotal = rs.Fields("subtotal").Value
            tipo_cambio = rs.Fields("tipo_cambio").Value
            'total_iva = rs.Fields("iva").Value
            total_iva_retenido = rs.Fields("iva_retenido").Value
            total = rs.Fields("total").Value
            descuento = rs.Fields("descuento").Value
            forma_pago = rs.Fields("forma_pago").Value
            metodo_pago = rs.Fields("metodo_pago").Value
            receptor_uso_cfdi = rs.Fields("uso_cfdi").Value
            condiciones_pago = rs.Fields("condiciones_pago").Value
        End If
        rs.Close()

        '==============================================================


        With objeto
            'Metodol que crea nodo comprobante
            'Parametros:
            'Serie (String)
            'Folio (String)
            'fecha (Date)
            'Forma de pago: usar catalogo del sat (String)
            'Subtotal (Double)
            'Total (Double)
            'Tipo de comprobante: usar catalogo I,E,T,P,N (String)
            'Metodo de pago. usar catalogo (String)
            'Lugar de expedicion usar Codigo postal (String)
            'Tipo de cambio (Decimal)
            'Condiciones de pago (String)
            'Descuento (Double)
            'Moneda:Catalogo de monedas (String)
            'Confirmación en caso de que se requiera (String)
            .Comprobante(numero_serie, id_factura, FormatDateTime(Now, DateFormat.GeneralDate), forma_pago, subtotal, total, "I", metodo_pago, lugar_expedicion, tipo_cambio, condiciones_pago, descuento, moneda)



            rs.Open("SELECT ctlg_tipo_relacion.clave AS tipo_relacion,factura_electronica_docs.UUID " & _
               "FROM factura_electronica_docs " & _
               "JOIN ctlg_tipo_relacion ON ctlg_tipo_relacion.id_tipo_relacion=factura_electronica_docs.id_tipo_relacion " & _
               "WHERE id_factura_electronica=" & id_factura, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    .AgregaCFDIRelacionado(rs.Fields("UUID").Value)
                    .CFDIRelacionados(rs.Fields("tipo_relacion").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'Metodo para agregar documentos relacionados pueden ser varios
            'Parametro
            'UUID del documento relacionado (String)
            ' .AgregaCFDIRelacionado("F749FC01-4DA4-4EAA-A032-A4A96E25A417")
            ' .AgregaCFDIRelacionado("B3B29505-09F9-43AF-820A-C3D31E9FE402")
            'Tipo de relacion de los documentos:Catalogo (String)
            '.CFDIRelacionados("04")

            'Metodo para crea nodo Datos del emisor
            'Parametros:
            'RFC (String)
            'Razon Social (String)
            'Regimen: catalogo (string)
            .AgregaEmisor(emisor_rfc, emisor_razon_social, emisor_regimen)

            'Metodo para crear nodo Datos del receptor
            'Uso del cfdi: catalogo
            'RFC (String)
            'Razon Social (String)
            'NumRegIDTrib Opcional (String)
            'residencia fiscal: opcional (String)
            .AgregaReceptor(receptor_uso_cfdi, receptor_rfc, receptor_razon_social, "", "")

            'Metodo para crear nodo Impuestos del concepto,
            'Parametros
            'Impuesto: Catalogo (String)
            'Base (double)
            'Importe (double)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo Factor: catalogo (String)
            ' .AgregaImpuestoTrasladoDelProducto("002", 100, 100 * 0.16, 0.16, "Tasa") 'iva

            'Tasa 0
            '.AgregaImpuestoTrasladoDelProducto("002", 100, 0, 0, "Tasa") 'iva

            'Exento
            '.AgregaImpuestoTrasladoDelProducto("002", 100, 0, 0, "Exento") 'iva

            'Metodo para crear nodo Concepto
            'Clave sat del producto: catalogo (String)
            'Cantidad (doubel)
            'Clave sat de la unidad de medida: catalogo (String)
            'Unidad (String)
            'Descripcion (String)
            'Valor unitario (Double)
            'No identificacion del producto (String)
            'descuento (double)
            'Numero de pedimento de aduana: checar expresion regular (String)
            'Cuenta predial (String)
            'Alumno
            'CURP
            'NIvel Educativo
            'RFCPago
            'RVOE
            ' .AgregaConcepto2("10141501", 2, "H87", "PZA", "CAJA 48Z", 50, "0012", 0)

            'Metodo para crear nodo Impuestos globales
            'Impuestos trasladados:
            'Parametros:
            'Impuesto: Catalogo (String)
            'Importe (Double)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo factor (String)

            'OBTENEMOS SUMA DE IMPORTE DE  PRODUCTOS CON TASA 0.16
            Dim total_productos_tasa16 As Integer = 0

            rs.Open("SELECT COUNT(*) AS producto_tasa16 FROM factura_electronica_detalle WHERE tasa_impuesto='0.16' AND id_factura_electronica=" & id_factura, conn)
            If rs.RecordCount > 0 Then
                total_productos_tasa16 = rs.Fields("producto_tasa16").Value
            End If
            rs.Close()

            If total_productos_tasa16 > 0 Then
                rs.Open("SELECT CASE WHEN ISNULL(SUM(total_impuesto)) THEN 0 ELSE SUM(total_impuesto) END AS total_iva FROM factura_electronica_detalle WHERE tasa_impuesto='0.16' AND id_factura_electronica=" & id_factura, conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        total_iva = rs.Fields("total_iva").Value
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
                .AgregaImpuestoTraslado("002", total_iva, 0.16, "Tasa")
            End If


            'OBTENEMOS SUMA DE IMPORTE DE  PRODUCTOS CON TASA 0.16
            Dim total_productos_tasa0 As Integer = 0

            rs.Open("SELECT COUNT(*) AS producto_tasa0 FROM factura_electronica_detalle WHERE tasa_impuesto='0.00' AND id_factura_electronica=" & id_factura, conn)
            If rs.RecordCount > 0 Then
                total_productos_tasa0 = rs.Fields("producto_tasa0").Value
            End If
            rs.Close()

            If total_productos_tasa0 > 0 Then
                .AgregaImpuestoTraslado("002", 0, 0.0, "Tasa")
            End If


            'Impuesto: Catalogo (String)
            'Importe double
            If total_iva_retenido > 0 Then
                .AgregaImpuestoRetenido("002", total_iva_retenido)
            End If

            rs.Open("SELECT pc.clave AS producto_clave,p.nombre,fed.cantidad,ic.codigo AS clave_impuesto,fed.total_impuesto,u.nombre AS unidad, u.clave AS clave_unidad,fed.tasa_impuesto,fed.precio,fed.importe,fed.total_impuesto_retenido,fed.tasa_impuesto_retenido " & _
                    "FROM factura_electronica_detalle fed " & _
                    "JOIN producto p ON p.id_producto=fed.id_producto " & _
                    "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                    "JOIN producto_clavesat pc ON pc.id_clavesat=p.id_clavesat " & _
                    "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                    "JOIN cfg_impuesto_catalogo ic ON ic.id_cfg_impuesto_catalogo=i.id_cfg_impuesto_catalogo " & _
                    "WHERE fed.id_factura_electronica=" & id_factura, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF

                    .AgregaImpuestoTrasladoDelProducto(rs.Fields("clave_impuesto").Value, rs.Fields("importe").Value, rs.Fields("total_impuesto").Value, rs.Fields("tasa_impuesto").Value, "Tasa") 'iva
                    If rs.Fields("total_impuesto_retenido").Value > 0 Then
                        .AgregaImpuestoRetenidoDelProducto("002", rs.Fields("importe").Value, rs.Fields("total_impuesto_retenido").Value, rs.Fields("tasa_impuesto_retenido").Value, "Tasa")
                    End If
                    .AgregaConcepto2(rs.Fields("producto_clave").Value, rs.Fields("cantidad").Value, rs.Fields("clave_unidad").Value, rs.Fields("unidad").Value, rs.Fields("nombre").Value, rs.Fields("precio").Value, "", 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()



        End With
    End Sub
    Private Sub nota_credito(ByRef objeto As CFD33.CFDx, ByVal id_nota_credito As Integer)


        '==============INFORMACION PARA GENERAR ARCHIVO XML 3.3====================
        Dim numero_serie As String = ""
        Dim id_cliente As Integer = 0
        Dim fecha_elaboracion As DateTime
        Dim descuento As Decimal = 0
        Dim total As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_iva_retenido As Decimal = 0


        Dim forma_pago As String = ""
        Dim metodo_pago As String = ""
        Dim condiciones_pago As String = ""
        Dim lugar_expedicion As String = ""
        Dim tipo_cambio As Decimal = 1
        Dim moneda As String = "MXN"

        Dim emisor_razon_social As String = ""
        Dim emisor_rfc As String = ""
        Dim emisor_regimen As String = ""


        Dim receptor_uso_cfdi As String = ""
        Dim receptor_razon_social As String = ""
        Dim receptor_rfc As String = ""


        rs.Open("SELECT c.razon_social,c.rfc,c.cp,rf.clave AS regimen_fiscal " & _
                "FROM configuracion c " & _
                "JOIN ctlg_regimen_fiscal rf ON rf.id_regimen_fiscal=c.id_regimen_fiscal " & _
                "WHERE id_configuracion = 1", conn)
        If rs.RecordCount > 0 Then
            emisor_razon_social = rs.Fields("razon_social").Value
            emisor_rfc = rs.Fields("rfc").Value
            lugar_expedicion = rs.Fields("cp").Value
            emisor_regimen = rs.Fields("regimen_fiscal").Value
        End If
        rs.Close()

        '==============================================
        rs.Open("SELECT CASE WHEN c.id_persona = 0 THEN  e.razon_social ELSE CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) END AS razon_social, " &
                "CASE WHEN c.id_persona = 0 THEN  e.rfc ELSE p.rfc END AS registro, " &
                "nc.serie,nc.fecha,nc.subtotal,nc.iva,nc.total,nc.descuento,fp.clave AS forma_pago,mp.clave AS metodo_pago,uc.clave AS uso_cfdi,nc.condiciones_pago " &
                "FROM nota_credito nc " &
                "JOIN cliente c ON c.id_cliente=nc.id_cliente " &
                "JOIN forma_pago fp ON fp.id_forma_pago=nc.id_forma_pago " &
                "JOIN ctlg_metodo_pago mp ON mp.id_metodo_pago=nc.id_metodo_pago " &
                "JOIN ctlg_uso_cfdi uc ON uc.id_uso_cfdi=nc.id_uso_cfdi " &
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " &
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa  " &
                "WHERE nc.id_nota_credito=" & id_nota_credito, conn)
        If rs.RecordCount > 0 Then
            receptor_razon_social = rs.Fields("razon_social").Value
            receptor_rfc = rs.Fields("registro").Value
            numero_serie = rs.Fields("serie").Value
            fecha_elaboracion = rs.Fields("fecha").Value
            subtotal = rs.Fields("subtotal").Value
            total_iva = rs.Fields("iva").Value
            total = rs.Fields("total").Value
            descuento = rs.Fields("descuento").Value
            forma_pago = rs.Fields("forma_pago").Value
            metodo_pago = rs.Fields("metodo_pago").Value
            receptor_uso_cfdi = rs.Fields("uso_cfdi").Value
            condiciones_pago = rs.Fields("condiciones_pago").Value
        End If
        rs.Close()

        '==============================================================


        With objeto
            'Metodol que crea nodo comprobante
            'Parametros:
            'Serie (String)
            'Folio (String)
            'fecha (Date)
            'Forma de pago: usar catalogo del sat (String)
            'Subtotal (Double)
            'Total (Double)
            'Tipo de comprobante: usar catalogo I,E,T,P,N (String)
            'Metodo de pago. usar catalogo (String)
            'Lugar de expedicion usar Codigo postal (String)
            'Tipo de cambio (Decimal)
            'Condiciones de pago (String)
            'Descuento (Double)
            'Moneda:Catalogo de monedas (String)
            'Confirmación en caso de que se requiera (String)
            .Comprobante(numero_serie, id_nota_credito, FormatDateTime(Now, DateFormat.GeneralDate), forma_pago, subtotal, total, "E", metodo_pago, lugar_expedicion, tipo_cambio, condiciones_pago, descuento, moneda)



            rs.Open("SELECT ctlg_tipo_relacion.clave AS tipo_relacion,nota_credito_docs.UUID " & _
                    "FROM nota_credito_docs " & _
                    "JOIN ctlg_tipo_relacion ON ctlg_tipo_relacion.id_tipo_relacion=nota_credito_docs.id_tipo_relacion " & _
                    "WHERE id_nota_credito=" & id_nota_credito, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    .AgregaCFDIRelacionado(rs.Fields("UUID").Value)
                    .CFDIRelacionados(rs.Fields("tipo_relacion").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'Metodo para agregar documentos relacionados pueden ser varios
            'Parametro
            'UUID del documento relacionado (String)
            '.CFDIRelacionados("04")

            '.AgregaCFDIRelacionado("B3B29505-09F9-43AF-820A-C3D31E9FE402")
            'Tipo de relacion de los documentos:Catalogo (String)


            'Metodo para crea nodo Datos del emisor
            'Parametros:
            'RFC (String)
            'Razon Social (String)
            'Regimen: catalogo (string)
            .AgregaEmisor(emisor_rfc, emisor_razon_social, emisor_regimen)

            'Metodo para crear nodo Datos del receptor
            'Uso del cfdi: catalogo
            'RFC (String)
            'Razon Social (String)
            'NumRegIDTrib Opcional (String)
            'residencia fiscal: opcional (String)
            .AgregaReceptor(receptor_uso_cfdi, receptor_rfc, receptor_razon_social, "", "")

            'Metodo para crear nodo Impuestos del concepto,
            'Parametros
            'Impuesto: Catalogo (String)
            'Base (double)
            'Importe (double)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo Factor: catalogo (String)
            ' .AgregaImpuestoTrasladoDelProducto("002", 100, 100 * 0.16, 0.16, "Tasa") 'iva

            'Tasa 0
            '.AgregaImpuestoTrasladoDelProducto("002", 100, 0, 0, "Tasa") 'iva

            'Exento
            '.AgregaImpuestoTrasladoDelProducto("002", 100, 0, 0, "Exento") 'iva

            'Metodo para crear nodo Concepto
            'Clave sat del producto: catalogo (String)
            'Cantidad (doubel)
            'Clave sat de la unidad de medida: catalogo (String)
            'Unidad (String)
            'Descripcion (String)
            'Valor unitario (Double)
            'No identificacion del producto (String)
            'descuento (double)
            'Numero de pedimento de aduana: checar expresion regular (String)
            'Cuenta predial (String)
            'Alumno
            'CURP
            'NIvel Educativo
            'RFCPago
            'RVOE
            ' .AgregaConcepto2("10141501", 2, "H87", "PZA", "CAJA 48Z", 50, "0012", 0)

            'Metodo para crear nodo Impuestos globales
            'Impuestos trasladados:
            'Parametros:
            'Impuesto: Catalogo (String)
            'Importe (Double)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo factor (String)
            '.AgregaImpuestoTraslado("002", total_iva, 0.16, "Tasa")

            'Impuesto: Catalogo (String)
            'Importe double
            '.AgregaImpuestoRetenido("001", 100)
            'rs.Open("SELECT pc.clave AS producto_clave,p.nombre,ncd.cantidad,ic.codigo AS clave_impuesto,ncd.total_impuesto,u.nombre AS unidad, u.clave AS clave_unidad,ncd.tasa_impuesto,ncd.precio,ncd.importe " & _
            '       "FROM nota_credito_detalle ncd " & _
            '      "JOIN producto p ON p.id_producto=ncd.id_producto " & _
            '     "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
            '    "JOIN producto_clavesat pc ON pc.id_clavesat=p.id_clavesat " & _
            '   "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
            '  "JOIN cfg_impuesto_catalogo ic ON ic.id_cfg_impuesto_catalogo=i.id_cfg_impuesto_catalogo " & _
            ' "WHERE ncd.id_nota_credito=" & id_nota_credito, conn)
            'If rs.RecordCount > 0 Then
            'While Not rs.EOF
            '.AgregaImpuestoTrasladoDelProducto(rs.Fields("clave_impuesto").Value, rs.Fields("importe").Value, rs.Fields("total_impuesto").Value, rs.Fields("tasa_impuesto").Value, "Tasa") 'iva
            '.AgregaConcepto2(rs.Fields("producto_clave").Value, rs.Fields("cantidad").Value, rs.Fields("clave_unidad").Value, rs.Fields("unidad").Value, rs.Fields("nombre").Value, rs.Fields("precio").Value, "", 0)
            'rs.MoveNext()
            'End While
            'End If
            'rs.Close()



            'End With

            'OBTENEMOS SUMA DE IMPORTE DE  PRODUCTOS CON TASA 0.16
            Dim total_productos_tasa16 As Integer = 0

            rs.Open("SELECT COUNT(*) AS producto_tasa16 FROM nota_credito_detalle WHERE tasa_impuesto='0.16' AND id_nota_credito=" & id_nota_credito, conn)
            If rs.RecordCount > 0 Then
                total_productos_tasa16 = rs.Fields("producto_tasa16").Value
            End If
            rs.Close()

            If total_productos_tasa16 > 0 Then
                rs.Open("SELECT CASE WHEN ISNULL(SUM(total_impuesto)) THEN 0 ELSE SUM(total_impuesto) END AS total_iva FROM nota_credito_detalle WHERE tasa_impuesto='0.16' AND id_nota_credito=" & id_nota_credito, conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        total_iva = rs.Fields("total_iva").Value
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
                .AgregaImpuestoTraslado("002", total_iva, 0.16, "Tasa")
            End If


            'OBTENEMOS SUMA DE IMPORTE DE  PRODUCTOS CON TASA 0.16
            Dim total_productos_tasa0 As Integer = 0

            rs.Open("SELECT COUNT(*) AS producto_tasa0 FROM nota_credito_detalle WHERE tasa_impuesto='0.00' AND id_nota_credito=" & id_nota_credito, conn)
            If rs.RecordCount > 0 Then
                total_productos_tasa0 = rs.Fields("producto_tasa0").Value
            End If
            rs.Close()

            If total_productos_tasa0 > 0 Then
                .AgregaImpuestoTraslado("002", 0, 0.0, "Tasa")
            End If


            'Impuesto: Catalogo (String)
            'Importe double
            If total_iva_retenido > 0 Then
                .AgregaImpuestoRetenido("002", total_iva_retenido)
            End If

            rs.Open("SELECT pc.clave AS producto_clave,p.nombre,ncd.cantidad,ic.codigo AS clave_impuesto,ncd.total_impuesto,u.nombre AS unidad, u.clave AS clave_unidad,ncd.tasa_impuesto,ncd.precio,ncd.importe " & _
                   "FROM nota_credito_detalle ncd " & _
                  "JOIN producto p ON p.id_producto=ncd.id_producto " & _
                 "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                "JOIN producto_clavesat pc ON pc.id_clavesat=p.id_clavesat " & _
               "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
              "JOIN cfg_impuesto_catalogo ic ON ic.id_cfg_impuesto_catalogo=i.id_cfg_impuesto_catalogo " & _
             "WHERE ncd.id_nota_credito=" & id_nota_credito, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    .AgregaImpuestoTrasladoDelProducto(rs.Fields("clave_impuesto").Value, rs.Fields("importe").Value, rs.Fields("total_impuesto").Value, rs.Fields("tasa_impuesto").Value, "Tasa") 'iva
                    .AgregaConcepto2(rs.Fields("producto_clave").Value, rs.Fields("cantidad").Value, rs.Fields("clave_unidad").Value, rs.Fields("unidad").Value, rs.Fields("nombre").Value, rs.Fields("precio").Value, "", 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End With
    End Sub
    Private Sub FacturaPagos(ByRef objeto As CFD33.CFDx, ByVal id_recibo_pago As Integer)
        Dim emisor_razon_social As String = ""
        Dim emisor_rfc As String = ""
        Dim lugar_expedicion As String = ""
        Dim emisor_regimen As String = ""
        Dim receptor_razon_social As String = ""
        Dim receptor_rfc As String = ""
        Dim serie As String = ""
        Dim fecha_recibo As DateTime
        Dim fecha_pago As Date
        Dim forma_pago As String = ""
        Dim monto As Decimal = 0
        Dim moneda As String = ""

        Dim num_operacion As String = ""
        Dim rfc_ordenante As String = ""
        Dim cuenta_ordenante As String = ""
        Dim nombre_ordenante As String = ""
        Dim rfc_beneficiario As String = ""
        Dim cuenta_beneficiario As String = ""


        rs.Open("SELECT c.razon_social,c.rfc,c.cp,rf.clave AS regimen_fiscal " & _
              "FROM configuracion c " & _
              "JOIN ctlg_regimen_fiscal rf ON rf.id_regimen_fiscal=c.id_regimen_fiscal " & _
              "WHERE id_configuracion = 1", conn)
        If rs.RecordCount > 0 Then
            emisor_razon_social = rs.Fields("razon_social").Value
            emisor_rfc = rs.Fields("rfc").Value
            lugar_expedicion = rs.Fields("cp").Value
            emisor_regimen = rs.Fields("regimen_fiscal").Value
        End If
        rs.Close()


        With objeto
            'Metodo que crea nodo comprobante
            'Parametros:
            'Serie (String)
            'Folio (String)
            'fecha (Date)
            'Forma de pago: usar catalogo del sat (String)
            'Subtotal (Double)
            'Total (Double)
            'Tipo de comprobante: usar catalogo I,E,T,P,N (String)
            'Metodo de pago. usar catalogo (String)
            'Lugar de expedicion usar Codigo postal (String)
            'Tipo de cambio (Decimal)
            'Condiciones de pago (String)
            'Descuento (Double)
            'Moneda:Catalogo de monedas (String)
            'Confirmación en caso de que se requiera (String)
            rs.Open("SELECT CASE WHEN c.id_persona = 0 THEN  e.razon_social ELSE CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) END AS razon_social, " &
                "CASE WHEN c.id_persona = 0 THEN  e.rfc ELSE p.rfc END AS registro,r.num_operacion,r.rfc_ordenante,r.cuenta_ordenante,r.nombre_ordenante,r.rfc_beneficiario,r.cuenta_beneficiario," &
                "r.serie,r.fecha, r.fecha_hora_pago,r.monto,fp.clave as forma_pago, m.clave as moneda " &
                "from recibo_pago r " &
                "JOIN cliente c ON c.id_cliente=r.id_cliente " &
                "JOIN forma_pago fp ON fp.id_forma_pago=r.id_forma_pago " &
                "JOIN ctlg_moneda m ON m.id_ctlg_moneda=r.id_moneda " &
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " &
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa  " &
                "WHERE r.id_recibo_pago=" & id_recibo_pago, conn)
            If rs.RecordCount > 0 Then
                receptor_razon_social = rs.Fields("razon_social").Value
                receptor_rfc = rs.Fields("registro").Value
                serie = rs.Fields("serie").Value
                fecha_recibo = rs.Fields("fecha").Value
                fecha_pago = rs.Fields("fecha_hora_pago").Value
                forma_pago = rs.Fields("forma_pago").Value
                monto = rs.Fields("monto").Value
                moneda = rs.Fields("moneda").Value
                num_operacion = rs.Fields("num_operacion").Value
                rfc_ordenante = rs.Fields("rfc_ordenante").Value
                cuenta_ordenante = rs.Fields("cuenta_ordenante").Value
                nombre_ordenante = rs.Fields("nombre_ordenante").Value
                rfc_beneficiario = rs.Fields("rfc_beneficiario").Value
                cuenta_beneficiario = rs.Fields("cuenta_beneficiario").Value
            End If
            rs.Close()

            .Comprobante(serie, id_recibo_pago, FormatDateTime(fecha_recibo, DateFormat.GeneralDate), "", 0, 0, "P", "", lugar_expedicion, , "", , "XXX")

            'Metodo para crea nodo Datos del emisor
            'Parametros:
            'RFC (String)
            'Razon Social (String)
            'Regimen: catalogo (string)
            .AgregaEmisor(emisor_rfc, emisor_razon_social, emisor_regimen)

            'Metodo para crear nodo Datos del receptor
            'Uso del cfdi: catalogo
            'RFC (String)
            'Razon Social (String)
            'NumRegIDTrib Opcional (String)
            'residencia fiscal: opcional (String)
            .AgregaReceptor("P01", receptor_rfc, receptor_razon_social, "", "")

            'Metodo para crear nodo Concepto
            'Clave sat del producto: catalogo (String)
            'Cantidad (doubel)
            'Clave sat de la unidad de medida: catalogo (String)
            'Unidad (String)
            'Descripcion (String)
            'Valor unitario (Double)
            'No identificacion del producto (String)
            'descuento (double)
            'Numero de pedimento de aduana: checar expresion regular (String)
            'Cuenta predial (String)
            .AgregaConcepto("84111506", 1, "ACT", "", "Pago", 0, "", 0, "", "")



            'Complemento pagos 1.0
            '***************************
            'Metodo para crear  nodo de los documentos relacionados del complemento de pago
            'Parametros:
            'UUID (string)
            'Serie (string)
            'Folio (string)
            'Moneda (string)
            'Tipo de cambio (double)
            'Metodo de pago (string)
            'Numero de parcialidad (integer)
            'Importe saldo anterior (double)
            'Importe pago (double)
            'Importe saldo insoluto (double)
            rs.Open("SELECT * FROM recibo_pago_detalle WHERE id_recibo_pago=" & id_recibo_pago, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    .AgregaPagoImpuestoDoctoRelacionado(rs.Fields("id_documento").Value, rs.Fields("serie").Value, rs.Fields("id_factura_electronica").Value, rs.Fields("moneda").Value, rs.Fields("tipo_cambio").Value, rs.Fields("metodo_pago").Value, rs.Fields("num_parcialidad").Value, rs.Fields("importe_anterior").Value, rs.Fields("importe_pagado").Value, rs.Fields("importe_saldo").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            ' .AgregaPagoImpuestoDoctoRelacionado("8939E6D3-1A3E-41C6-952A-83DB2ED307EA", "A", 2, "MXN", 1, "PUE", 1, 50, 10, 40)

            'Metodo para crear el nodo complemento de pago
            'Parametros
            'Fecha pago (string)
            'forma de pago (string)
            'moneda (string)
            'Tipo de cambio (double)
            'MOnto (double)
            'Numero de operacion (string)
            'RFC emisor cta ordenante (string)
            'Cta ordenante (string)
            'RFC emisor cta beneficiaria (string)
            'Cta beneficiaria (string)
            'BANCO extranjero (STRING OPCIONAL)
            'Tipo CADENA PAGO (STRING OPCIONAL)
            'CERTIFICADO PAGO (STRING OPCIONAL)
            'CADENA (STRING OPCIONAL)
            'SELLO (STRING OPCIONAL)
            .AgregaPago(fecha_pago, forma_pago, moneda, 1, monto, num_operacion, rfc_ordenante, cuenta_ordenante, rfc_beneficiario, cuenta_beneficiario, nombre_ordenante, "", "", "", "")

        End With

    End Sub

    Private Sub TodosLosMetodos(ByRef objeto As CFD33.CFDx)
        With objeto
            'Metodo que crea nodo comprobante
            'Parametros:
            'Serie (String)
            'Folio (String)
            'fecha (Date)
            'Forma de pago: usar catalogo del sat (String)
            'Subtotal (Double)
            'Total (Double)
            'Tipo de comprobante: usar catalogo I,E,T,P,N (String)
            'Metodo de pago. usar catalogo (String)
            'Lugar de expedicion usar Codigo postal (String)
            'Tipo de cambio (Decimal)
            'Condiciones de pago (String)
            'Descuento (Double)
            'Moneda:Catalogo de monedas (String)
            'Confirmación en caso de que se requiera (String)
            .Comprobante("A", 124, FormatDateTime(Now, DateFormat.GeneralDate), "01", 190, 190 * 1.16, "I", "PUE", "77516", , "Condicion de pago")

            'Metodo para agregar documentos relacionados pueden ser varios
            'Parametro
            'UUID del documento relacionado (String)
            .AgregaCFDIRelacionado("F749FC01-4DA4-4EAA-A032-A4A96E25A417")
            .AgregaCFDIRelacionado("B3B29505-09F9-43AF-820A-C3D31E9FE402")
            'Tipo de relacion de los documentos:Catalogo (String)
            .CFDIRelacionados("04")

            'Metodo para crea nodo Datos del emisor
            'Parametros:
            'RFC (String)
            'Razon Social (String)
            'Regimen: catalogo (string)
            .AgregaEmisor("AAA010101AAA", "AGUILAR BARRIGA JOSE GERARDO", "601")

            'Metodo para crear nodo Datos del receptor
            'Uso del cfdi: catalogo
            'RFC (String)
            'Razon Social (String)
            'NumRegIDTrib Opcional (String)
            'residencia fiscal: opcional (String)
            .AgregaReceptor("G01", "AAMO8509249H6", "CARREÑO ACEVES MARIA DE LOS ANGELES", "NUMIDTRIB", "MEX")

            'Metodo para crear nodo Impuestos del concepto,
            'Parametros
            'Impuesto: Catalogo (String)
            'Base (double)
            'Importe (double)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo Factor: catalogo (String)
            .AgregaImpuestoTrasladoDelProducto("002", 50, 50 * 0.16, 0.16, "Tasa") 'iva
            .AgregaImpuestoTrasladoDelProducto("003", 50, 50 * 0.0591, 0.0591, "Tasa") 'ieps

            'Parametros
            'Impuesto: Catalogo (String)
            'Base (double)
            'Importe (double)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo Factor: catalogo (String)
            .AgregaImpuestoRetenidoDelProducto("001", 50, 10, 0.16, "Tasa")

            'Metodo para crear nodo Concepto
            'Clave sat del producto: catalogo (String)
            'Cantidad (doubel)
            'Clave sat de la unidad de medida: catalogo (String)
            'Unidad (String)
            'Descripcion (String)
            'Valor unitario (Double)
            'No identificacion del producto (String)
            'descuento (double)
            'Numero de pedimento de aduana: checar expresion regular (String)
            'Cuenta predial (String)
            .AgregaConcepto("10141501", 2, "H87", "PZA", "CAJA 48Z", 50, "0012", 10, "01  31  7320  0700024", "0102030405")

            'Concepto Sin impuestos
            '.AgregaConcepto("10141501", 1, "H87", "ACT", "NOMINA", 150, "0012", 0, "", "")

            '.AgregaImpuestoTrasladoDelProducto("003", 100, 100 * 0.53, 0.53, "Tasa") 'ieps
            '.AgregaImpuestoRetenidoDelProducto("001", 100, 100 * 0.1, 0.1, "Tasa")
            '.AgregaConcepto("10141501", 3, "H87", "PZA", "CAJA 50Z", 100, "0012")

            'Dim escuela As New CFD33.instEducativas
            'escuela.version = "1.0"
            'escuela.nombreAlumno = "Alex"
            'escuela.CURP = "LOMM820918HTCPNG08"
            'escuela.nivelEducativo = "Profesional técnico"
            'escuela.rfcPago = "LOMM820918P65"
            'escuela.autRVOE = "12345"

            'Dim esc As New CFD33.ComprobanteConceptoComplementoConcepto
            'esc.Any = .DevuelveNodoIEDU(escuela)
            '.AgregaConcepto("53102705", 1, "H87", "PZA", "Colegiatura", 1000, "0011", , , ,  esc)


            ''por terceros complemento concepto
            'Dim portercero As New CFD33.PorCuentadeTerceros
            'portercero.rfc = "LOMM820918P65"
            'portercero.nombre = "Miguel Lopez"

            'portercero.InformacionFiscalTercero = _
            'New CFD33.PorCuentadeTercerosInformacionFiscalTercero With {.calle = "Calle", _
            '                                                          .municipio = "Municipio", _
            '                                                          .estado = "Estado", _
            '                                                          .pais = "Pais", _
            '                                                          .codigoPostal = "77500"}

            'Dim impuestotercero As New CFD33.PorCuentadeTercerosImpuestos
            'Dim rettercero As New List(Of CFD33.PorCuentadeTercerosImpuestosRetencion)

            'rettercero.Add(New CFD33.PorCuentadeTercerosImpuestosRetencion With _
            '               {.impuesto = CFD33.PorCuentadeTercerosImpuestosRetencionImpuesto.IVA, _
            '                .importe = 100})

            'rettercero.Add(New CFD33.PorCuentadeTercerosImpuestosRetencion With _
            '               {.impuesto = CFD33.PorCuentadeTercerosImpuestosRetencionImpuesto.ISR, _
            '                .importe = 200})

            'Dim trasladotercero As New List(Of CFD33.PorCuentadeTercerosImpuestosTraslado)

            'trasladotercero.Add(New CFD33.PorCuentadeTercerosImpuestosTraslado With _
            '               {.impuesto = CFD33.PorCuentadeTercerosImpuestosTrasladoImpuesto.IVA, _
            '                .tasa = 1, _
            '                .importe = 10})

            'trasladotercero.Add(New CFD33.PorCuentadeTercerosImpuestosTraslado With _
            '               {.impuesto = CFD33.PorCuentadeTercerosImpuestosTrasladoImpuesto.IEPS, _
            '                .tasa = 0, _
            '                .importe = 0})



            'impuestotercero.Retenciones = rettercero.ToArray
            'impuestotercero.Traslados = trasladotercero.ToArray
            'portercero.Impuestos = impuestotercero
            'Dim tercero As New CFD33.ComprobanteConceptoComplementoConcepto
            'tercero.Any = .DevuelveNodoPorTerceros(portercero)

            '.AgregaConcepto("53102705", 1, "H87", "PZA", "Producto con tercero", 500, Impuestos, "0010", , , , tercero)
            ''fin por terceros complemento concepto

            'Metodo para crear nodo Impuestos globales
            'Impuestos trasladados:
            'Parametros:
            'Impuesto: Catalogo (String)
            'Base (Doubel)
            'Tasa o cuota: catalogo (Decimal)
            'Tipo factor (String)
            .AgregaImpuestoTraslado("002", 190 * 0.16, 0.16, "Tasa")
            .AgregaImpuestoTraslado("003", 190 * 0.3, 0.3, "Tasa")

            'Metodo para crear nodo Impuestos Retenidos:
            'Parametros:
            'Impuesto: catalogo (String)
            'Importe (Double)
            .AgregaImpuestoRetenido("002", 10)

            'Metodo para crear impuestos locales trasladados
            'Parametros:
            'Tipo traslado local (string)
            'Tasa (double)
            'Importe (doble)
            .AgregaImpuestoLocalTraslado("ISH", 10, 100)

            'Metodo para crear impuestos locales retenidos
            'Parametros:
            'Tipo retencion local (string)
            'Tasa (double)
            'Importe (double)
            .AgregaImpuestoLocalRetencion("Tipo", 10, 100)

            '.AgregaServicioParcial("1.0", "1", "Calle", "Municipio", CFD33.parcialesconstruccionInmuebleEstado.Item24, "77510", "NE", "NI", "Colonia", "Localidad", "Referencia")

            '.AgregaComplementoDonataria("122", "18/09/1982", "Este comprobante ampara un donativo, el cual será destinado por la donataria a los fines propios de su objeto social. En el caso de que los bienes donados hayan sido deducidos previamente para los efectos del impuesto sobre la renta, este donativo no es deducible. La reproducción no autorizada de este comprobante constituye un delito en los términos de las disposiciones fiscales.")


            'Notarios publicos
            '.AgregaNotario("123", "LOMM820918HTCPNG18", "01", "")
            '.AgregaDatosDeOperacion("123", "26/01/2016", 100, 16, 116)
            '.AgregaInmueble("01", "Calle", "", "", "", "", "", "Benito Juarez", "23", "MEX", 77500)
            '.AgregaInmueble("02", "Calle", "", "", "", "", "", "Benito Juarez", "23", "MEX", 77500)


            ''un solo enajenante
            'Dim EnajenanteUnico As New CFD.NotariosPublicosDatosEnajenanteDatosUnEnajenante

            'With EnajenanteUnico
            '    .RFC = "LOMM820918P66"
            '    .CURP = "LOMM820918HTCPNG18"
            '    .Nombre = "Miguel Alejandro"
            '    .ApellidoPaterno = "Lopez"
            '    .ApellidoMaterno = "Montaño"
            'End With



            ''Sin son varios
            'Dim EnajenanteHijo As New List(Of CFD.NotariosPublicosDatosEnajenanteDatosEnajenantesCopSCDatosEnajenanteCopSC)
            'Dim Enajenante As New CFD.NotariosPublicosDatosEnajenanteDatosEnajenantesCopSC

            'EnajenanteHijo.Add(New CFD.NotariosPublicosDatosEnajenanteDatosEnajenantesCopSCDatosEnajenanteCopSC _
            '                   With {.RFC = "LOMM820918P66", _
            '                        .CURP = "LOMM820918HTCPNG18", _
            '                        .Nombre = "Miguel", _
            '                        .ApellidoPaterno = "Lopez", _
            '                        .ApellidoMaterno = "Montaño", _
            '                        .Porcentaje = 50})

            'EnajenanteHijo.Add(New CFD.NotariosPublicosDatosEnajenanteDatosEnajenantesCopSCDatosEnajenanteCopSC _
            '                  With {.RFC = "LOMM820918P61", _
            '                       .CURP = "LOMM820918HTCPNG11", _
            '                       .Nombre = "Angel", _
            '                       .ApellidoPaterno = "Lopez", _
            '                       .ApellidoMaterno = "Montaño", _
            '                       .Porcentaje = 50})


            'Enajenante.DatosEnajenanteCopSC = EnajenanteHijo.ToArray

            '.AgregaDatosEnajenante(CFD.NotariosPublicosDatosEnajenanteCoproSocConyugalE.No, EnajenanteUnico)

            ''un solo adquiriente
            'Dim AdquirienteUnico As New CFD.NotariosPublicosDatosAdquirienteDatosUnAdquiriente
            'With AdquirienteUnico
            '    .RFC = "LOMM820918P23"
            '    .CURP = "LOMM820918HTCPNG32"
            '    .Nombre = "Roberto"
            '    .ApellidoPaterno = "Lopez"
            '    .ApellidoMaterno = "Montaño"
            'End With

            ''Sin son varios
            'Dim AdquirienteHijo As New List(Of CFD.NotariosPublicosDatosAdquirienteDatosAdquirientesCopSCDatosAdquirienteCopSC)
            'Dim Adquiriente As New CFD.NotariosPublicosDatosAdquirienteDatosAdquirientesCopSC

            'AdquirienteHijo.Add(New CFD.NotariosPublicosDatosAdquirienteDatosAdquirientesCopSCDatosAdquirienteCopSC _
            '                   With {.RFC = "LOMM820918P66", _
            '                        .CURP = "LOMM820918HTCPNG18", _
            '                        .Nombre = "Roberto", _
            '                        .ApellidoPaterno = "Lopez", _
            '                        .ApellidoMaterno = "Montaño", _
            '                        .Porcentaje = 50})

            'AdquirienteHijo.Add(New CFD.NotariosPublicosDatosAdquirienteDatosAdquirientesCopSCDatosAdquirienteCopSC _
            '                  With {.RFC = "LOMM820918P61", _
            '                       .CURP = "LOMM820918HTCPNG11", _
            '                       .Nombre = "Cinthya", _
            '                       .ApellidoPaterno = "Lopez", _
            '                       .ApellidoMaterno = "Montaño", _
            '                       .Porcentaje = 50})


            'Adquiriente.DatosAdquirienteCopSC = AdquirienteHijo.ToArray

            '.AgregaDatosAdquiriente(CFD.NotariosPublicosDatosAdquirienteCoproSocConyugalE.No, AdquirienteUnico)

            'Fin notarios publicos

            'Divisas
            .AgregaTipoOperacionDivisa(CFD33.DivisasTipoOperacion.venta)
            'Fin divisas


            'INE
            'Parametro
            'IdContabilidad (integer)
            .AgregaIdContabilidadINE(2)
            .AgregaIdContabilidadINE(4)

            'Clave entidad (integer)
            'Ambito (integer)
            'Se especifico el ambito (boolean)
            .AgregaEntidadINE(CFD33.t_ClaveEntidad.NAY, Nothing, False)
            .LimpiarIdContabilidadINE()
            .AgregaIdContabilidadINE(5)
            .AgregaEntidadINE(CFD33.t_ClaveEntidad.ZAC, CFD33.INEEntidadAmbito.Federal, False)
            .LimpiarIdContabilidadINE()

            'Tipo Proceso
            'Tipo comite
            '¿Se especifico tipo comite? boolean
            'Id contabilidad
            '¿Se especifico idcontabilidad? boolean
            .AgregaDatosINE(CFD33.INETipoProceso.Ordinario, CFD33.INETipoComite.DirectivoEstatal, True, 1, False)

            'Leyendas
            '.AgregaLeyenda("", "", "Leyenda 1")
            '.AgregaLeyenda("ISr 214", "", "Leyenda 2")
            '.AgregaDatosLeyendaFiscal()

            'Complemento pagos 1.0
            '***************************
            'Metodo que crea Nodo Impuestos trasladados del complemento de pago
            'Parametros:
            'Impuesto:usar catalogo (string)
            'Importe (double)
            'Tasa (decimla)
            'Tipo factor (string)
            .AgregaPagoImpuestoTraslado("002", 100, 0.16, "Tasa")

            'Metodo para crear nodo impuestos retenidos del complemento de pago
            'Parametros:
            'Impuesto: usar catalogo (string)
            'Importe (double)
            .AgregaPagoImpuestoRetenido("001", 50)

            'Metodo para crear  nodo de los documentos relacionados del complemento de pago
            'Parametros:
            'UUID (string)
            'Serie (string)
            'Folio (string)
            'Moneda (string)
            'Tipo de cambio (double)
            'Metodo de pago (string)
            'Numero de parcialidad (integer)
            'Importe saldo anterior (double)
            'Importe pago (double)
            'Importe saldo insoluto (double)
            .AgregaPagoImpuestoDoctoRelacionado("B3B29505-09F9-43AF-820A-C3D31E9FE402", "A", 1, "MXN", 1, "PUE", 1, 100, 10, 90)
            .AgregaPagoImpuestoDoctoRelacionado("8939E6D3-1A3E-41C6-952A-83DB2ED307EA", "A", 2, "MXN", 1, "PUE", 1, 50, 10, 40)

            'Metodo para crear el nodo complemento de pago
            'Parametros
            'Fecha pago (string)
            'forma de pago (string)
            'moneda (string)
            'Tipo de cambio (double)
            'MOnto (double)
            'Numero de operacion (string)
            'RFC emisor cta ordenante (string)
            'Cta ordenante (string)
            'RFC emisor cta beneficiaria (string)
            'Cta beneficiaria (string)
            'BANCO extranjero (STRING OPCIONAL)
            'Tipo CADENA PAGO (STRING OPCIONAL)
            'CERTIFICADO PAGO (STRING OPCIONAL)
            .AgregaPago("28/02/2017", "02", "MXN", 1, 150, "00001", "XEXX010101000", "0123456789", "MAL820918UZ7", "9012345678", "BANCO EXT", "", "CERTPAGO")

            'Nomina
            '**********************************
            '**********************************
            '**********************************
            '.Comprobante("Nom", 124, FormatDateTime(Now, DateFormat.GeneralDate), _
            '             "", 190, 190 * 1.16, _
            '             "N", "", "77500", Moneda:="MXN", descuento:=10)

            '.AgregaEmisor("AAA010101AAA", "AGUILAR BARRIGA JOSE GERARDO", "601")



            '.AgregaReceptor("G01", "A&MO8509249H6", "CARREÑO ACEVES MARIA DE LOS ANGELES", "NUMIDTRIB", "MEX")

            '.AgregaConcepto("10141501", 1, "ACT", "ACTIVIDAD", "Pago de nómina", 50, Nothing)


            ''Emisor
            ''***********************
            'Dim Emisor As New CFD33.NominaEmisor
            'Emisor.RegistroPatronal = "R012345"
            'Emisor.Curp = Nothing
            'Emisor.EntidadSNCF = Nothing
            'Emisor.RfcPatronOrigen = Nothing

            ''Receptor
            ''***********************
            'Dim Receptor As New CFD33.NominaReceptor
            'Receptor.Curp = "LOMM820918HTCPNG18"
            'Receptor.NumSeguridadSocial = "1234567890"
            'Receptor.FechaInicioRelLaboral = "2015-01-18"
            ''P#AñosY#MesesM#DiasD  sino existe años o mes no se coloca la clave
            'Receptor.Antigüedad = "P1Y10M15D"


            'Receptor.TipoContrato = CFD33.c_TipoContrato.Item01
            'Receptor.Sindicalizado = CFD33.NominaReceptorSindicalizado.No
            'Receptor.SindicalizadoSpecified = False
            'Receptor.TipoJornada = CFD33.c_TipoJornada.Item01
            'Receptor.TipoRegimen = CFD33.c_TipoRegimen.Item02
            'Receptor.NumEmpleado = 123
            'Receptor.Departamento = "Sistemas"
            'Receptor.Puesto = "Programador"
            'Receptor.RiesgoPuesto = CFD33.c_RiesgoPuesto.Item1
            'Receptor.PeriodicidadPago = CFD33.c_PeriodicidadPago.Item01
            'Receptor.CuentaBancaria = "0202020202"
            'If Receptor.CuentaBancaria.Length <> 18 Then
            '    Receptor.Banco = CFD33.c_Banco.Item002
            '    Receptor.BancoSpecified = True
            'End If
            'Receptor.SalarioBaseCotApor = FormatCurrency(125, 2)
            'Receptor.SalarioDiarioIntegrado = FormatCurrency(130, 0)


            'Dim Edo As New CFD33.c_Estado
            'Edo = System.Enum.Parse(GetType(CFD33.c_Estado), "YUC")

            'Receptor.ClaveEntFed = Edo 'CFD.c_Estado.ROO

            'Dim receptorSubContrata As New List(Of CFD33.NominaReceptorSubContratacion)
            'receptorSubContrata.Add(New CFD33.NominaReceptorSubContratacion With {.RfcLabora = "AAMO8509249H6", .PorcentajeTiempo = 100})
            'Receptor.SubContratacion = receptorSubContrata.ToArray

            ''Percepciones
            ''***********************
            'Dim Percepcion As New List(Of CFD33.NominaPercepcionesPercepcion)

            'Dim horasExtras As New List(Of CFD33.NominaPercepcionesPercepcionHorasExtra)
            'horasExtras.Add(New CFD33.NominaPercepcionesPercepcionHorasExtra With {.TipoHoras = CFD33.c_TipoHoras.Item01, _
            '                                                                    .Dias = 1, _
            '                                                                    .HorasExtra = 2, _
            '                                                                    .ImportePagado = FormatCurrency(100, 2)})

            'Percepcion.Add(New CFD33.NominaPercepcionesPercepcion With {.Clave = "001-SUE", _
            '                                                         .Concepto = "Sueldo", _
            '                                                         .TipoPercepcion = CFD33.c_TipoPercepcion.Item002, _
            '                                                         .ImporteGravado = FormatCurrency(100, 2), _
            '                                                         .ImporteExento = FormatCurrency(50, 2), _
            '                                                         .HorasExtra = horasExtras.ToArray, _
            '                                                         .AccionesOTitulos = Nothing})





            'Dim Percepciones As New CFD33.NominaPercepciones
            'Percepciones.Percepcion = Percepcion.ToArray

            'Percepciones.JubilacionPensionRetiro = New CFD33.NominaPercepcionesJubilacionPensionRetiro With {.IngresoAcumulable = 0, _
            '                                                                                               .IngresoNoAcumulable = 0, _
            '                                                                                               .MontoDiario = 0, _
            '                                                                                               .TotalParcialidad = 0, _
            '                                                                                               .TotalUnaExhibicion = 0}

            'Percepciones.SeparacionIndemnizacion = New CFD33.NominaPercepcionesSeparacionIndemnizacion With {.NumAñosServicio = 1, _
            '                                                                                               .TotalPagado = 10, _
            '                                                                                               .UltimoSueldoMensOrd = 0, _
            '                                                                                               .IngresoAcumulable = 0, _
            '                                                                                               .IngresoNoAcumulable = 0}



            'Percepciones.TotalExento = 0
            'Percepciones.TotalGravado = 0
            'Percepciones.TotalJubilacionPensionRetiro = 0
            'Percepciones.TotalSeparacionIndemnizacion = 0
            'Percepciones.TotalSueldos = 100

            ''Otras pagos
            ''***********************
            'Dim otropagosubsidio As New CFD33.NominaOtroPagoSubsidioAlEmpleo

            'otropagosubsidio.SubsidioCausado = FormatCurrency(100, 2)




            'Dim OtrosPagos As New List(Of CFD33.NominaOtroPago)

            'OtrosPagos.Add(New CFD33.NominaOtroPago With {.Clave = "001", _
            '                                         .Concepto = "Prueba Otro pago", _
            '                                         .Importe = 100, _
            '                                         .TipoOtroPago = CFD33.c_TipoOtroPago.Item003, _
            '                                         .SubsidioAlEmpleo = otropagosubsidio, _
            '                                         .CompensacionSaldosAFavor = Nothing})




            ''Deducciones
            ''***********************
            'Dim deduccion As New List(Of CFD33.NominaDeduccionesDeduccion)
            'Dim Deducciones As New CFD33.NominaDeducciones

            'deduccion.Add(New CFD33.NominaDeduccionesDeduccion With {.Clave = "001-renta", _
            '.Concepto = "Renta", _
            '.Importe = 100, _
            '.TipoDeduccion = CFD33.c_TipoDeduccion.Item004})


            'Deducciones.Deduccion = deduccion.ToArray

            'Deducciones.TotalImpuestosRetenidos = 50
            'If Deducciones.TotalImpuestosRetenidos > 0 Then
            '    Deducciones.TotalImpuestosRetenidosSpecified = True
            'End If
            'Deducciones.TotalOtrasDeducciones = 10
            'If Deducciones.TotalOtrasDeducciones > 0 Then
            '    Deducciones.TotalOtrasDeduccionesSpecified = True
            'End If

            ''Incapacidades
            ''********************************
            'Dim Incapacidades As New List(Of CFD33.NominaIncapacidad)

            'Incapacidades.Add(New CFD33.NominaIncapacidad With {.DiasIncapacidad = 1, _
            '                                                  .ImporteMonetario = FormatCurrency(150, 2), _
            '                                                  .TipoIncapacidad = CFD33.c_TipoIncapacidad.Item01})



            '.Nomina(CFD33.c_TipoNomina.O, "2016-10-28", "2016-10-01", "2016-10-15", 15, Emisor, Receptor, Percepciones, OtrosPagos, Deducciones, Incapacidades)

            'Fin Nomina
            '**********************************
            '**********************************
            '**********************************
        End With

    End Sub

    Private Sub facturaNominas(ByRef objeto As CFD33.CFDx)
        With objeto
            'Metodo que crea nodo comprobante
            'Parametros:
            'Serie (String)
            'Folio (String)
            'fecha (Date)
            'Forma de pago: usar catalogo del sat (String)
            'Subtotal (Double)
            'Total (Double)
            'Tipo de comprobante: usar catalogo I,E,T,P,N (String)
            'Metodo de pago. usar catalogo (String)
            'Lugar de expedicion usar Codigo postal (String)
            'Tipo de cambio (Decimal)
            'Condiciones de pago (String)
            'Descuento (Double)
            'Moneda:Catalogo de monedas (String)
            'Confirmación en caso de que se requiera (String)
            .Comprobante("A", 124, FormatDateTime(Now, DateFormat.GeneralDate), "01", 100, 100 * 1.16, "N", "PUE", "77516", , "", 0, "MXN")


            'Metodo para crea nodo Datos del emisor
            'Parametros:
            'RFC (String)
            'Razon Social (String)
            'Regimen: catalogo (string)
            .AgregaEmisor("LAN7008173R5", "EMISOR PRUEBAS", "601")

            'Metodo para crear nodo Datos del receptor
            'Uso del cfdi: catalogo
            'RFC (String)
            'Razon Social (String)
            'NumRegIDTrib Opcional (String)
            'residencia fiscal: opcional (String)
            .AgregaReceptor("G01", "XAXX010101000", "CLIENTE PUBLICO EN GENERAL", "", "")



            'Metodo para crear nodo Concepto
            'Clave sat del producto: catalogo (String)
            'Cantidad (doubel)
            'Clave sat de la unidad de medida: catalogo (String)
            'Unidad (String)
            'Descripcion (String)
            'Valor unitario (Double)
            'No identificacion del producto (String)
            'descuento (double)
            'Numero de pedimento de aduana: checar expresion regular (String)
            'Cuenta predial (String)
            .AgregaConcepto("84111505", 1, "ACT", "", "Pago de nómina", 100, , 0, , , )


            'Registro patronal
            'Curp
            'RFC patron origen
            .AgregaEmisorNomina("RegistroPatronal", "Curp", "RFCPatronOrigen")

            'CURP
            'NSS
            'Fecha inicio relacion laboral
            'Antiguedad
            'Tipo contrato
            'Sindicalizado boolean
            'TipoJornada
            'Tipo Regimen
            'Num empleado
            'Depto
            'Puesto
            ' "Riesgo"
            ' "Periodicidad"
            '"CuentaBancaria"
            '"Banco"
            'Salario diario 
            'Salario diario integrado
            ' "ClaveEntidad",
            ' "RFCLabora",
            'Descuento 
            .AgregaReceptorNomina("Curp", "NSS", "Fecha", "Antiguedad", "TipoContrato", False, "TipoJornada", "TipoRegimen", "NumEmpleado", "Depto", "Puesto", "Riesgo", "Periodicidad", "CuentaBancaria", "Banco", 100, 115, "ClaveEntidad", "RFCLabora", 0)


            'Estos metodos los tendras que meter en un while o for
            'Clave interna
            'Concepto,
            'TipoPercepcion (clave sat)
            'Importe gravado
            'Importe exento
            'Tipo horas extras (sino hay pasas vacion ""
            'dias
            'horas extras
            'importe horas extras
            .AgregaPercepcionNomina("Clave", "Concepto", "001", 100, 0, "01", 1, 1, 10)

            'Estos metodos los tendras que meter en un while o for
            'Clave interna de la deduccion
            'Concepto
            'Importe
            'Clave SAT
            .AgregaDeduccionesNomina("Clave", "Concepto", 10, "002")

            'Estos metodos los tendras que meter en un while o for
            'Clave interna
            'Descripcion del concepto
            'Importe
            'Clave sat
            'Importe subsidio causado (solo va cuando el concepto sea subsidio
            'Saldo a favor (sino va es 0)
            'Remanente (sino va es 0)
            'Año (sino va es 0)
            .AgregaOtrosPagosNomina("Clave", "Concepto", 50, "001", 80, 0, 0, 0)

            'Estos metodos los tendras que meter en un while o for
            'Dias de incapacidad
            'Importe
            'Tipo incapacidad
            .AgregaIncapacidadesNomina(1, 10, "001")

            'Total una exhibicion
            'Total parcialidad
            'ingreso acumulable
            'ingreso no acumulable
            'monto diario
            .AgregaJubilacionPensionRetiroNomina(100, 0, 50, 50, 10)

            'Total pagado
            'años de servicio
            'ultimo sueldo mensual ordinario
            'acumulable
            'no acumulable
            .AgregaSeparacionIndemnizacionNomina(100, 1, 100, 100, 0)

            'Tipo de nomina
            'Fecha de pago
            'Fecha inicial
            'fecha final
            'dias pagados
            .NominaV2("O", "02/08/2017", "15/07/2017", "31/07/2017", 15)

        End With
    End Sub
End Module
