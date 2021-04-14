Module Funciones_enviar_email
    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long
    Dim abonos(4) As Decimal
    Public Sub enviar_email_corte()
        Dim Ret As Long
        Dim correo_dest As String = ""
        Dim nombre_dest As String = ""
        Dim asunto As String = ""
        Dim mensaje As String = ""
        Dim servidor_smtp As String = ""
        Dim correo_smtp As String = ""
        Dim pass_smtp As String = ""
        Dim puerto_smtp As String = ""
        Dim habilitar_ssl As Boolean = True
        Dim id_adjuntar As Integer = 0
        Dim proteger_pdf As Integer = 0
        Dim pass_pdf As String = ""
        Dim body As String = ""

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try
                '-----obtenemos los datos necesarios para enviar email------
                'Conectar()
                rs.Open("SELECT * FROM cfg_correo JOIN servidores_smtp ON cfg_correo.id_smtp=servidores_smtp.id_smtp WHERE id_cfg_correo=1", conn)
                If rs.RecordCount > 0 Then
                    nombre_dest = rs.Fields("nombre_dest").Value
                    correo_dest = rs.Fields("correo_dest").Value
                    asunto = rs.Fields("asunto").Value
                    mensaje = rs.Fields("mensaje").Value
                    id_adjuntar = rs.Fields("id_adjuntar").Value
                    proteger_pdf = rs.Fields("proteger_pdf").Value
                    pass_pdf = rs.Fields("password_pdf").Value
                    servidor_smtp = rs.Fields("servidor_smtp").Value
                    correo_smtp = rs.Fields("correo_smtp").Value
                    pass_smtp = rs.Fields("password_smtp").Value
                    puerto_smtp = rs.Fields("puerto_smtp").Value
                    If rs.Fields("habilitar_ssl").Value = 0 Then
                        habilitar_ssl = False
                    End If
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '-----------------------------------------------------------
                MyMailMsg.From = New Net.Mail.MailAddress(correo_smtp)
                MyMailMsg.To.Add(correo_dest)
                MyMailMsg.Subject = asunto & " " & Date.Today.ToLongDateString

                If id_adjuntar = 1 Then
                    MyMailMsg.Body = mensaje & " " & body_corte_html
                    '
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(servidor_smtp)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = puerto_smtp
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(correo_smtp, pass_smtp)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                MyMailMsg.Attachments.Add(att)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & correo_dest & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Sub reenviar_email(ByVal id_corte As Integer)
        Dim Ret As Long
        Dim correo_dest As String = ""
        Dim nombre_dest As String = ""
        Dim asunto As String = ""
        Dim mensaje As String = ""
        Dim servidor_smtp As String = ""
        Dim correo_smtp As String = ""
        Dim pass_smtp As String = ""
        Dim puerto_smtp As String = ""
        Dim habilitar_ssl As Boolean = True
        Dim id_adjuntar As Integer = 0
        Dim proteger_pdf As Integer = 0
        Dim pass_pdf As String = ""
        Dim body As String = ""

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try
                '-----obtenemos los datos necesarios para enviar email------
                'Conectar()
                rs.Open("SELECT * FROM cfg_correo JOIN servidores_smtp ON cfg_correo.id_smtp=servidores_smtp.id_smtp WHERE id_cfg_correo=1", conn)
                If rs.RecordCount > 0 Then
                    nombre_dest = rs.Fields("nombre_dest").Value
                    correo_dest = rs.Fields("correo_dest").Value
                    asunto = rs.Fields("asunto").Value
                    mensaje = rs.Fields("mensaje").Value
                    id_adjuntar = rs.Fields("id_adjuntar").Value
                    proteger_pdf = rs.Fields("proteger_pdf").Value
                    pass_pdf = rs.Fields("password_pdf").Value
                    servidor_smtp = rs.Fields("servidor_smtp").Value
                    correo_smtp = rs.Fields("correo_smtp").Value
                    pass_smtp = rs.Fields("password_smtp").Value
                    puerto_smtp = rs.Fields("puerto_smtp").Value
                    If rs.Fields("habilitar_ssl").Value = 0 Then
                        habilitar_ssl = False
                    End If
                End If
                rs.Close()
                rs.Open("SELECT body_html FROM cortes WHERE id_corte=" & id_corte, conn)
                If rs.RecordCount > 0 Then
                    body = rs.Fields("body_html").Value
                End If
                rs.Close()

                'conn.close()
                'conn = Nothing

                '-----------------------------------------------------------
                MyMailMsg.From = New Net.Mail.MailAddress(correo_smtp)
                MyMailMsg.To.Add(correo_dest)
                MyMailMsg.Subject = asunto

                If id_adjuntar = 1 Then
                    MyMailMsg.Body = "Mensaje reenviado " & body
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(servidor_smtp)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = puerto_smtp
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(correo_smtp, pass_smtp)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                MyMailMsg.Attachments.Add(att)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & correo_dest & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Function generar_cuerpo_corte_html(ByVal id_corte As Integer) As String

        Dim folio_inicial As Integer = 0
        Dim fecha As DateTime
        Dim folio_final As Integer = 0
        Dim total_ventas As Decimal = 0
        Dim total_cobros As Decimal = 0
        Dim total_cobros_efectivo As Decimal = 0
        Dim total_abonos_efectivo As Decimal = 0
        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0
        Dim fondo_caja As Decimal = 0
        Dim total_depositos As Decimal = 0
        Dim total_retiros As Decimal = 0
        Dim total_devoluciones As Decimal = 0
        Dim total_caja_sinfondo As Decimal = 0
        Dim total_pago_proveedores As Decimal = 0
        Dim total_caja As Decimal = 0
        Dim nombre_empleado As String = ""
        Dim id_empleado As Integer = 0
        Dim b As ticket = New ticket
        Dim declaraciom_total_efectivo As Decimal = 0
        Dim declaraciom_total_tarjeta As Decimal = 0
        Dim declaraciom_total_trasnferencia As Decimal = 0
        Dim declaraciom_total_cheque As Decimal = 0
        Dim declaraciom_total_nota As Decimal = 0


        '=====================OBTEMOS LOS DETALLES DEL CORTE=====================
        rs.Open("SELECT fecha,id_empleado_caja,nombre_empleado FROM cortes WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fecha = rs.Fields("fecha").Value
            nombre_empleado = rs.Fields("nombre_empleado").Value
            id_empleado = rs.Fields("id_empleado_caja").Value
        End If
        rs.Close()

        rs.Open("SELECT MIN(id_venta) As folio_inicio,MAX(id_venta) As folio_termino FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("folio_inicio").Value) Then
                folio_inicial = rs.Fields("folio_inicio").Value
                folio_final = rs.Fields("folio_termino").Value
            End If
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(cantidad) IS NULL THEN 0 ELSE SUM(cantidad)  END  as total from retiros WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_retiros = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            fondo_caja = rs.Fields("saldo_inicial").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_compras.importe)) THEN 0 ELSE SUM(pagos_compras.importe) END AS total FROM pagos_compras WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            total_pago_proveedores = rs.Fields("total").Value
        End If
        rs.Close()

        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
              "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
              "JOIN venta ON venta.id_venta=pagos_ventas.id_venta " &
              "WHERE DATE(pagos_ventas.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn) ' pagos en efectivo
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_cobros_efectivo = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT * FROM corte_declaracion WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            declaraciom_total_efectivo = rs.Fields("total_efectivo").Value
            declaraciom_total_tarjeta = rs.Fields("total_tarjeta").Value
            declaraciom_total_trasnferencia = rs.Fields("total_transferencia").Value
            declaraciom_total_cheque = rs.Fields("total_cheque").Value
            declaraciom_total_nota = rs.Fields("total_nota").Value
        End If

        rs.Close()
        '======================================================================

        Dim html As String = "<body>" & _
"<fieldset style='width:700px; height:inherit; margin: 0 auto; margin-top:5px; background-color:#FFFFFF;'>" & _
    "<table width='675' border='0' style='font-family:Century Gothic'>" & _
        "<tr>" & _
            "<td colspan='6' rowspan='5'><div align='center'><img src='cid:InlineImageID' width='200' height='100'/></div></td>" & _
            "<td colspan='4'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='4'><span style='font-size: 14px'>" & lineas_reporte(0) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='23' colspan='4'><span style='font-size: 14px'>" & lineas_reporte(1) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='26' colspan='4'><span style='font-size: 14px'>" & lineas_reporte(2) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='26' colspan='4'><span style='font-size: 14px'>" & lineas_reporte(3) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>CIERRE DE VENTAS </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td width='10'>&nbsp;</td>" & _
            "<td width='82' style='font-size: 14px'>Caja:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>1</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='22'>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Usuario:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>" & nombre_empleado & "</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Fecha:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>" & fecha.ToLongDateString() & "</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Hora:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>" & fecha.ToShortTimeString & "</td>" & _
        "</tr>"

        Dim linea_folio As String = "<tr>" & _
                "<td>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Del folio: </td>" & _
            "<td colspan='8' style='font-size: 14px'><strong>" & folio_inicial & "</strong> al folio <strong>" & folio_final & "</strong></td>" & _
        "</tr>"
     
        html = html + linea_folio
        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>PRODUCTOS VENDIDOS</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cantidad</div></td>" & _
            "<td width='96' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>unidad</div></td>" & _
            "<td colspan='4' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Producto</div></td>" & _
            "<td width='116' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Precio Unitario </div></td>" & _
            "<td width='154' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
        "</tr>"

        Dim ppeng As String = ""  'productos vendidos a publico en general

        Dim rw, ry As New ADODB.Recordset
        rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta_detalle vd " & _
           "JOIN venta v ON vd.id_venta=v.id_venta " & _
           "JOIN producto p ON p.id_producto=vd.id_producto " & _
           "WHERE v.id_corte='" & id_corte & " '", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " & _
                                   "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                           "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND  v.id_corte='" & id_corte & "'", conn)
                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        ry.Open("SELECT SUM(vd.cantidad) AS cantidad_vendido FROM venta_detalle vd " & _
                       "JOIN venta v ON v.id_venta=vd.id_venta " & _
               "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND v.id_corte='" & id_corte & "' ORDER BY vd.cantidad DESC", conn)
                        If ry.RecordCount > 0 Then
                            While Not ry.EOF

                                ppeng = ppeng & " <tr>" & _
                                             "<td>&nbsp;</td>" & _
                                            "<td colspan='2' style='font-size: 14px'><div align='center'>" & ry.Fields("cantidad_vendido").Value & "</div></td>" & _
                                           "<td style='font-size: 14px'><div align='center'>" & rs.Fields("unidad").Value & "</div></td>" & _
                                          "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 12px'>" & rs.Fields("descripcion").Value & "</div></td>" & _
                                        "<td style='font-size: 14px'><div align='center'>" & rw.Fields("precio").Value & "</div></td>" & _
                                       "<td style='font-size: 14px'><div align='center'>" & FormatCurrency(ry.Fields("cantidad_vendido").Value * rw.Fields("precio").Value) & "</div></td>" & _
                                       "</tr>"
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

        html = html & ppeng

        html = html & "<tr>" & _
           " <td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>PRODUCTOS ENTREGADOS EN REGALIA </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cantidad</div></td>" & _
            "<td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Unidad</div></td>" & _
            "<td colspan='4' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Producto</div></td>" & _
            "<td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Precio venta </div></td>" & _
            "<td bgcolor='#F5F5F5'>&nbsp;</td>" & _
        "</tr>"


        Dim pereg As String = "" 'productos entregadoe en regalias


        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND venta.id_corte='" & id_corte & "') AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA'AND venta.id_corte='" & id_corte & "'),venta_detalle.precio) AS puntero " & _
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
"WHERE venta.status='REGALIA' AND venta.id_corte='" & id_corte & "' GROUP BY puntero " & _
"ORDER BY cantidad_vendido DESC", conn)
        If rs.RecordCount > 0 Then
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    pereg = pereg & "<tr>" & _
                                    "<td>&nbsp;</td>" & _
                                    "<td colspan='2' style='font-size: 14px'><div align='center'>" & rs.Fields("cantidad_vendido").Value & "</div></td>" & _
                                     "<td style='font-size: 14px'><div align='center'>" & rs.Fields("unidad").Value & "</div></td>" & _
                                    "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 12px'>" & rs.Fields("descripcion").Value & "</div></td>" & _
                                    "<td style='font-size: 14px'><div align='center'>" & rs.Fields("precio_vendido").Value & "</div></td>" & _
                                    "<td >&nbsp;</td>" & _
                                    "</tr>"
                    rs.MoveNext()
                End While
            End If
        End If
        rs.Close()
       
        html = html & pereg


        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>CUENTAS POR COBRAR</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
               "<td colspan='1' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Nota de Venta</div></td>" & _
            "<td colspan='5' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cliente</div></td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"


        Dim creditos As String = ""
        rs.Open("SELECT venta.id_venta,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
                 "FROM cliente " & _
                 "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                 "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                 "JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
                 "WHERE venta.status='PENDIENTE' AND venta.id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                creditos = creditos & "<tr>" & _
                             "<td>&nbsp;</td>" & _
                              "<td colspan='1' style='font-size: 14px'><div align='center'>" & rs.Fields("id_venta").Value & "</div></td>" & _
                             "<td colspan='5' style='font-size: 14px'><div align='center'>" & rs.Fields("nombre").Value & "</div></td>" & _
                             "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
                         "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & creditos

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>COBROS CREDITOS </div></td>" & _
        "</tr>" & _
        "<tr>" & _
           " <td>&nbsp;</td>" & _
           " <td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Foma de pago </div></td>" & _
           " <td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Total</div></td>" & _
           " <td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        limpiar_abonos()
        Dim text_abonos As String = ""
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & id_empleado & "' AND pagos_ventas.es_abono='1' AND pagos_ventas.afecta_caja='1' AND pagos_ventas.id_corte='" & id_corte & "' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim i As Integer = rs.Fields("id_forma_pago").Value
                abonos(i) += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        For x = 0 To 22
            If abonos(x) <> 0 Then
                text_abonos = text_abonos & "<tr>" &
                                  "<td>&nbsp;</td>" &
                                  "<td colspan='6' style='font-size: 14px'><div align='center'>" & nombre_forma_pago(x) & "</div></td>" &
                                  "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(abonos(x)) & "</div></td>" &
                                  "</tr>"
            End If
        Next
        html = html & text_abonos


        html = html & "<tr>" & _
     "<td colspan='10'>&nbsp;</td>" & _
 "</tr>" & _
 "<tr>" & _
     "<td>&nbsp;</td>" & _
     "<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>PAGO A PROVEEDORES</div></td>" & _
 "</tr>" & _
 "<tr>" & _
     "<td>&nbsp;</td>" & _
     "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
     "<td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Proveedor</div></td>" & _
     "<td rowspan='2'>&nbsp;</td>" & _
 "</tr>"

        Dim pago_proveed As String = ""

        Dim rx As New ADODB.Recordset

        rs.Open("SELECT pagos_compras.importe,factura_compra.id_proveedor " & _
        " FROM pagos_compras " & _
        "JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  " & _
        "WHERE pagos_compras.id_corte='" & id_corte & "' AND pagos_compras.afecta_caja='1'")
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim nombre_proveedor As String = ""
                rx.Open("SELECT  CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
                "FROM proveedor " & _
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                "WHERE proveedor.id_proveedor='" & rs.Fields("id_proveedor").Value & "'", conn)
                If rx.RecordCount > 0 Then
                    nombre_proveedor = rx.Fields("nombre").Value
                End If
                rx.Close()
                pago_proveed = pago_proveed & "<tr>" & _
                                            " <td>&nbsp;</td>" & _
                                            "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("importe").Value) & "</div></td>" & _
                                            "<td colspan='6' style='font-size: 14px'><div align='center'>" & nombre_proveedor & "</div></td>" & _
                                            "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & pago_proveed


        html = html & "<tr>" & _
           "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>DEVOLUCIONES (DE EFECTIVO) </div></td>" & _
        "</tr>" & _
        "<tr>" & _
         "   <td>&nbsp;</td>" & _
          "  <td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cantidad</div></td>" & _
           " <td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Unidad</div></td>" & _
            "<td colspan='4' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Producto</div></td>" & _
            "<td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Precio Unitario </div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        Dim devoluciones As String = ""
        rs.Open("SELECT devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,devoluciones_detalle.unidad,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones.bandera_corte_caja='" & id_corte & "' AND DATE(devoluciones.fecha)='" & Format(fecha, "yyyy-MM-dd") & "' AND devoluciones.id_empleado='" & id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) AND devoluciones_detalle.id_producto=id) AS cantidad, CONCAT(devoluciones_detalle.unidad,' ',devoluciones_detalle.descripcion) AS producto " & _
                " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion " & _
                "WHERE devoluciones.bandera_corte_caja='" & id_corte & "' GROUP BY id_producto", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                devoluciones = devoluciones & "<tr>" & _
                                                 "<td>&nbsp;</td>" & _
                                                  "<td colspan='2' style='font-size: 14px'><div align='center'>" & rs.Fields("cantidad").Value & "</div></td>" & _
                                                 "<td style='font-size: 14px'><div align='center'>" & rs.Fields("unidad").Value & "</div></td>" & _
                                                "<td colspan='4' style='font-size: 14px'><div align='center'>" & rs.Fields("producto").Value & "</div></td>" & _
                                                 "<td style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("precio_unitario").Value) & "</div></td>" & _
                                                  "</tr>"

                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & devoluciones

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>"

        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_iva) IS NULL THEN 0 ELSE SUM(total_iva)  END  AS total_iva ,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            html = html & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>Subtotal</div></td>" & _
            "<td colspan='4'><div align='center'><strong>" & FormatCurrency(rs.Fields("subtotal").Value) & "</strong></div></td>" & _
            "<td colspan='2' rowspan='4'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>Total IVA </div></td>" & _
            "<td colspan='4'><div align='center'><strong>" & FormatCurrency(rs.Fields("total_iva").Value) & "</strong></div></td>" & _
        "</tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>Total</div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'><strong>" & FormatCurrency(rs.Fields("total").Value) & "</strong></div></td>" & _
        "</tr>"

        End If
        rs.Close()



        html = html & "<tr>" & _
     "<td colspan='10'>&nbsp;</td>" & _
 "</tr>" & _
 "<tr>" & _
     "<td>&nbsp;</td>" & _
     "<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>DEPOSITOS</div></td>" & _
 "</tr>" & _
 "<tr>" & _
     "<td>&nbsp;</td>" & _
     "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
     "<td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Descripcion</div></td>" & _
     "<td rowspan='2'>&nbsp;</td>" & _
 "</tr>"


        Dim depositos As String = ""
          rs.Open("SELECT importe,descripcion FROM depositos WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                depositos = depositos & "<tr>" & _
                             "<td>&nbsp;</td>" & _
                             "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("importe").Value) & "</div></td>" & _
                             "<td colspan='6' style='font-size: 14px'><div align='center'>" & rs.Fields("descripcion").Value & "</div></td>" & _
                         "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & depositos


        html = html & "<tr>" & _
"<td colspan='10'>&nbsp;</td>" & _
"</tr>" & _
"<tr>" & _
"<td>&nbsp;</td>" & _
"<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>RETIROS</div></td>" & _
"</tr>" & _
"<tr>" & _
"<td>&nbsp;</td>" & _
"<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
"<td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Descripcion</div></td>" & _
"<td rowspan='2'>&nbsp;</td>" & _
"</tr>"


        Dim retiros As String = ""
        rs.Open("SELECT cantidad,descripcion FROM retiros WHERE status='ACTIVO' AND bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                retiros = retiros & "<tr>" & _
                             "<td>&nbsp;</td>" & _
                             "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("cantidad").Value) & "</div></td>" & _
                             "<td colspan='6' style='font-size: 14px'><div align='center'>" & rs.Fields("descripcion").Value & "</div></td>" & _
                         "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & retiros


        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>TOTAL POR CATEGORIAS </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' bgcolor='#EFEFEF' style='font-size: 14px'><div align='center'>Categoria</div></td>" & _
            "<td colspan='4' bgcolor='#EFEFEF' style='font-size: 14px'><div align='center'>Total + Impuestos </div></td>" & _
            "<td bgcolor='#EFEFEF' style='font-size: 14px'><div align='center'>Impuestos</div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        Dim total_cat As String = ""
        rs.Open("SELECT categoria.nombre,SUM(venta_detalle.importe)AS total,SUM(venta_detalle.total_impuestos) AS total_impuestos FROM venta_detalle " & _
               "JOIN producto on producto.id_producto=venta_detalle.id_producto " & _
               "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
               "JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
               "WHERE venta.id_corte='" & id_corte & "' GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_cat = total_cat & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>" & UCase(rs.Fields("nombre").Value) & "</div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
            "<td style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total_impuestos").Value) & "</div></td>" & _
        "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_iva) IS NULL THEN 0 ELSE SUM(total_iva)  END  AS total_iva,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE bandera_corte_caja='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_devoluciones = rs.Fields("total").Value
        End If
        rs.Close()


        rs.Open("SELECT (CASE WHEN ISNULL(sum(total)) THEN 0 ELSE sum(total) END)as total FROM venta WHERE id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas = total_ventas + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        Dim total_ventas_cobradas As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_ventas.importe)) THEN 0 ELSE SUM(pagos_ventas.importe) END AS total FROM pagos_ventas " & _
                "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas_cobradas = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        html = html & total_cat

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>TOTALES</div></td>" & _
        "</tr>"

       

        html = html & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
            "<td style='font-size: 14px'><div align='center'></div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>TOTAL VENTAS </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_ventas) & "</div></td>" & _
            "<td colspan='2' rowspan='7'>&nbsp;</td>" & _
        "</tr>"


        html = html & "<tr>" & _
           "<td>&nbsp;</td>" & _
           "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
           "<td style='font-size: 14px'><div align='center'></div></td>" & _
           "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
       "</tr>" & _
       "<tr>" & _
           "<td>&nbsp;</td>" & _
           "<td colspan='3' style='font-size: 14px'><div align='center'>TOTAL COBROS</div></td>" & _
           "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_ventas_cobradas) & "</div></td>" & _
           "<td colspan='2' rowspan='7'>&nbsp;</td>" & _
       "</tr>"

        Dim total_fpago As String = ""
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
                 "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
                 "WHERE pagos_ventas.id_corte='" & id_corte & "' AND pagos_ventas.status<>'CANCELADO' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_fpago = total_fpago & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>" & UCase(rs.Fields("descripcion").Value) & "</div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
            "<td colspan='2' rowspan='7'>&nbsp;</td>" & _
        "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & total_fpago

        html = html & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
            "<td style='font-size: 14px'><div align='center'></div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
        "</tr>"

        html = html & "<tr>" & _
         "<td>&nbsp;</td>" & _
         "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
         "<td style='font-size: 14px'><div align='center'></div></td>" & _
         "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
     "</tr>" & _
     "<tr>" & _
         "<td>&nbsp;</td>" & _
         "<td colspan='3' style='font-size: 14px'><div align='center'>COBROS EFECTIVO </div></td>" & _
         "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_cobros_efectivo) & "</div></td>" & _
         "<td colspan='2' rowspan='7'>&nbsp;</td>" & _
     "</tr>"

        html = html & "<tr>" & _
         "<td>&nbsp;</td>" & _
         "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
         "<td style='font-size: 14px'><div align='center'></div></td>" & _
         "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
     "</tr>"

       
        rs.Open("SELECT (CASE WHEN ISNULL(sum(total_impuestos)) THEN 0 ELSE sum(total_impuestos) END)as total_impuestos FROM venta WHERE  status='CERRADA' AND id_corte='" & id_corte & "'", conn)
        If rs.RecordCount > 0 Then
            total_iva = rs.Fields("total_impuestos").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        total_caja = fondo_caja + total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones
        total_caja_sinfondo = total_cobros_efectivo + total_depositos - total_retiros - total_pago_proveedores - total_devoluciones

        html = html & "<tr><td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>TOTAL IVA </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_iva) & "</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
            "<td style='font-size: 14px'><div align='center'></div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>FONDO DE CAJA </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(fondo_caja) & "</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>+ TOTAL DEPOSITOS </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_depositos) & "</div></td>" & _
        "</tr>" & _
         "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>-TOTAL RETIROS </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_retiros) & "</div></td>" & _
        "</tr>" & _
         "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>-DEVOLUCIONES </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_devoluciones) & "</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>-PAGO A PROVEEDOR </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_pago_proveedores) & "</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>TOTAL CAJA (SIN FONDO) </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>" & FormatCurrency(total_caja_sinfondo) & "</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>TOTAL CAJA </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>" & FormatCurrency(total_caja) & "</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
       " </tr>" & _
       " <tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
       " </tr>" & _
   " </table>" & _
"</fieldset>" & _
        "</body>"

        Return html
    End Function
    Public Function corte_actual_html() As String
        Dim html As String = "<body>" & _
"<fieldset style='width:700px; height:inherit; margin: 0 auto; margin-top:5px; background-color:#FFFFFF;'>" & _
    "<table width='675' border='0' style='font-family:Century Gothic'>" & _
        "<tr>" & _
            "<td colspan='6' rowspan='5'><div align='center'><img src='cid:InlineImageID' width='200' height='100'/></div></td>" & _
            "<td colspan='4'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='4'><span style='font-size: 14px'>" & lineas_reporte(0) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='23' colspan='4'><span style='font-size: 14px'>" & lineas_reporte(1) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='26' colspan='4'><span style='font-size: 14px'>" & lineas_reporte(2) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='26' colspan='4'><span style='font-size: 14px'>" & lineas_reporte(3) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>CIERRE DE VENTAS </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td width='10'>&nbsp;</td>" & _
            "<td width='82' style='font-size: 14px'>Caja:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>1</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='22'>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Usuario:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>" & global_nombre & "</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Fecha:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>" & DateTime.Now.ToLongDateString() & "</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Hora:</td>" & _
            "<td colspan='8' style='font-size: 14px; font-weight: bold'>" & DateTime.Now.ToShortTimeString & "</td>" & _
        "</tr>"

        Dim linea_folio As String = ""

        'Conectar()

        rs.Open("SELECT MIN(id_venta) As folio_inicio,MAX(id_venta) As folio_termino FROM venta WHERE date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            linea_folio = "<tr>" & _
                "<td>&nbsp;</td>" & _
            "<td style='font-size: 14px'>Del folio: </td>" & _
            "<td colspan='8' style='font-size: 14px'><strong>" & rs.Fields("folio_inicio").Value & "</strong> al folio <strong>" & rs.Fields("folio_termino").Value & "</strong></td>" & _
        "</tr>"
        End If
        rs.Close()
        html = html + linea_folio
        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>PRODUCTOS VENDIDOS A PUBLICO EN GENERAL </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cantidad</div></td>" & _
            "<td width='96' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>unidad</div></td>" & _
            "<td colspan='4' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Producto</div></td>" & _
            "<td width='116' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Precio Unitario </div></td>" & _
            "<td width='154' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
        "</tr>"

        Dim ppeng As String = ""  'productos vendidos a publico en general

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

                                ppeng = ppeng & " <tr>" & _
                                                 "<td>&nbsp;</td>" & _
                                                "<td colspan='2' style='font-size: 14px'><div align='center'>" & ry.Fields("cantidad_vendido").Value & "</div></td>" & _
                                               "<td style='font-size: 14px'><div align='center'>" & rs.Fields("unidad").Value & "</div></td>" & _
                                              "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 12px'>" & rs.Fields("descripcion").Value & "</div></td>" & _
                                            "<td style='font-size: 14px'><div align='center'>" & rw.Fields("precio").Value & "</div></td>" & _
                                           "<td style='font-size: 14px'><div align='center'>" & FormatCurrency(ry.Fields("cantidad_vendido").Value * rw.Fields("precio").Value) & "</div></td>" & _
                                           "</tr>"
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

        html = html & ppeng

        html = html & "<tr>" & _
           " <td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>PRODUCTOS ENTREGADOS EN REGALIA </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cantidad</div></td>" & _
            "<td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Unidad</div></td>" & _
            "<td colspan='4' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Producto</div></td>" & _
            "<td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Precio venta </div></td>" & _
            "<td bgcolor='#F5F5F5'>&nbsp;</td>" & _
        "</tr>"


        Dim pereg As String = "" 'productos entregadoe en regalias
        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & "),venta_detalle.precio) AS puntero " & _
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
"WHERE venta.status='REGALIA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " GROUP BY puntero " & _
"ORDER BY cantidad_vendido DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                pereg = pereg & "<tr>" & _
                                "<td>&nbsp;</td>" & _
                                "<td colspan='2' style='font-size: 14px'><div align='center'>" & rs.Fields("cantidad_vendido").Value & "</div></td>" & _
                                 "<td style='font-size: 14px'><div align='center'>" & rs.Fields("unidad").Value & "</div></td>" & _
                                "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 12px'>" & rs.Fields("descripcion").Value & "</div></td>" & _
                                "<td style='font-size: 14px'><div align='center'>" & rs.Fields("precio_vendido").Value & "</div></td>" & _
                                "<td >&nbsp;</td>" & _
                                "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()

        html = html & pereg


        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>CREDITOS</div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cliente</div></td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Importe</div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"


        Dim creditos As String = ""
        rs.Open("SELECT venta.subtotal,venta.total, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE venta.status='PENDIENTE' and date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_empleado_caja=" & global_id_empleado, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                creditos = creditos & "<tr>" & _
                             "<td>&nbsp;</td>" & _
                             "<td colspan='6' style='font-size: 14px'><div align='center'>" & rs.Fields("nombre").Value & "</div></td>" & _
                             "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
                         "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & creditos

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>COBROS CREDITOS </div></td>" & _
        "</tr>" & _
        "<tr>" & _
           " <td>&nbsp;</td>" & _
           " <td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Foma de pago </div></td>" & _
           " <td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Total</div></td>" & _
           " <td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        limpiar_abonos()
        Dim text_abonos As String = ""
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' AND venta.status='PENDIENTE'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim i As Integer = rs.Fields("id_forma_pago").Value
                abonos(i) += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' AND  venta.status='CERRADA' AND DATE(venta.fecha)<>'" & Format(Today, "yyyy-MM-dd") & "'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim i As Integer = rs.Fields("id_forma_pago").Value
                abonos(i) += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        For x = 0 To 22
            If abonos(x) <> 0 Then
                text_abonos = text_abonos & "<tr>" &
                                  "<td>&nbsp;</td>" &
                                  "<td colspan='6' style='font-size: 14px'><div align='center'>" & nombre_forma_pago(x) & "</div></td>" &
                                  "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(abonos(x)) & "</div></td>" &
                                  "</tr>"
            End If
        Next
        html = html & text_abonos

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='9'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>PAGO A PROVEEDORES </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='6' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Forma de pago </div></td>" & _
            "<td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Total</div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        Dim pago_proveed As String = ""
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_compras.importe)AS total FROM pagos_compras JOIN forma_pago ON forma_pago.id_forma_pago=pagos_compras.id_forma_pago JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  WHERE DATE(pagos_compras.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_compras.id_empleado_pago='" & global_id_empleado & "'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                pago_proveed = pago_proveed & "<tr>" & _
                                            " <td>&nbsp;</td>" & _
                                            "<td colspan='6' style='font-size: 14px'><div align='center'>" & UCase(rs.Fields("descripcion").Value) & "</div></td>" & _
                                            "<td colspan='2' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
                                            "</tr>"

                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & pago_proveed

        html = html & "<tr>" & _
           "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>DEVOLUCIONES (DE EFECTIVO) </div></td>" & _
        "</tr>" & _
        "<tr>" & _
         "   <td>&nbsp;</td>" & _
          "  <td colspan='2' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Cantidad</div></td>" & _
           " <td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Unidad</div></td>" & _
            "<td colspan='4' bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Producto</div></td>" & _
            "<td bgcolor='#F5F5F5' style='font-size: 14px'><div align='center'>Precio Unitario </div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        Dim devoluciones As String = ""
        rs.Open("SELECT devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,devoluciones_detalle.unidad,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones.bandera_corte_caja='0' AND DATE(devoluciones.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND devoluciones.id_empleado='" & global_id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) AND devoluciones_detalle.id_producto=id) AS cantidad, CONCAT(devoluciones_detalle.unidad,' ',devoluciones_detalle.descripcion) AS producto " & _
                " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion " & _
                "WHERE devoluciones.bandera_corte_caja='0' AND DATE(devoluciones.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND devoluciones.id_empleado='" & global_id_empleado & "' AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) GROUP BY id_producto", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                devoluciones = devoluciones & "<tr>" & _
                                                 "<td>&nbsp;</td>" & _
                                                  "<td colspan='2' style='font-size: 14px'><div align='center'>" & rs.Fields("cantidad").Value & "</div></td>" & _
                                                 "<td style='font-size: 14px'><div align='center'>" & rs.Fields("unidad").Value & "</div></td>" & _
                                                "<td colspan='4' style='font-size: 14px'><div align='center'>" & rs.Fields("producto").Value & "</div></td>" & _
                                                 "<td style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("precio_unitario").Value) & "</div></td>" & _
                                                  "</tr>"


                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & devoluciones

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>"

        rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal," &
                "CASE WHEN SUM(total_impuestos) Is NULL THEN 0 ELSE SUM(total_impuestos)  END  AS total_impuestos," &
                "CASE WHEN SUM(total) Is NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones " &
                "WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_empleado='" & global_id_empleado & "' AND (tipo_devolucion=3 OR  tipo_devolucion=4) AND bandera_corte_caja=0", conn)
        If rs.RecordCount > 0 Then
            html = html & "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center'>Subtotal</div></td>" &
            "<td colspan='4'><div align='center'><strong>" & FormatCurrency(rs.Fields("subtotal").Value) & "</strong></div></td>" &
            "<td colspan='2' rowspan='4'>&nbsp;</td>" &
        "</tr>" &
        "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center'>Total Impuestos </div></td>" &
            "<td colspan='4'><div align='center'><strong>" & FormatCurrency(rs.Fields("total_impuestos").Value) & "</strong></div></td>" &
        "</tr>" &
        "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center'>Total</div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center'><strong>" & FormatCurrency(rs.Fields("total").Value) & "</strong></div></td>" &
        "</tr>"

        End If
        rs.Close()


        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='9' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'>TOTAL POR CATEGORIAS </div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' bgcolor='#EFEFEF' style='font-size: 14px'><div align='center'>Categoria</div></td>" & _
            "<td colspan='4' bgcolor='#EFEFEF' style='font-size: 14px'><div align='center'>Total + Impuestos </div></td>" & _
            "<td bgcolor='#EFEFEF' style='font-size: 14px'><div align='center'>Impuestos</div></td>" & _
            "<td rowspan='2'>&nbsp;</td>" & _
        "</tr>"

        Dim total_cat As String = ""
        rs.Open("SELECT categoria.nombre,SUM(venta_detalle.importe)AS total,SUM(venta_detalle.total_impuestos) AS impuesto FROM venta_detalle join producto on producto.id_producto=venta_detalle.id_producto JOIN categoria ON categoria.id_categoria=producto.id_categoria JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja='" & global_id_empleado & "' AND venta.status='CERRADA' GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_cat = total_cat & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>" & UCase(rs.Fields("nombre").Value) & "</div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
            "<td style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("impuesto").Value) & "</div></td>" & _
        "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()

        html = html & total_cat

        html = html & "<tr>" & _
            "<td colspan='10'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='10'><div align='center' style='font-size: 14px; font-weight: bold; text-decoration: underline'>TOTALES</div></td>" & _
        "</tr>"

        Dim TOTAL As Decimal = 0
        Dim total_fpago As String = ""
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja='" & global_id_empleado & "' AND venta.status='CERRADA' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                TOTAL = TOTAL + CDbl(rs.Fields("total").Value)
                total_fpago = total_fpago & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>" & UCase(rs.Fields("descripcion").Value) & "</div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(rs.Fields("total").Value) & "</div></td>" & _
            "<td colspan='2' rowspan='7'>&nbsp;</td>" & _
        "</tr>"
                rs.MoveNext()
            End While
        End If
        rs.Close()
        html = html & total_fpago

        html = html & "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" & _
            "<td style='font-size: 14px'><div align='center'></div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='3' style='font-size: 14px'><div align='center'>TOTAL VENTAS </div></td>" & _
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(TOTAL) & "</div></td>" & _
            "<td colspan='2' rowspan='7'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>"
        Dim total_impuestos As Decimal = 0
        rs.Open("SELECT (CASE WHEN ISNULL(sum(total_impuestos)) THEN 0 ELSE sum(total_impuestos) END)as total_impuestos FROM venta WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_empleado_caja=" & global_id_empleado & " AND status='CERRADA' AND id_corte=0", conn)
        If rs.RecordCount > 0 Then
            total_impuestos = rs.Fields("total_impuestos").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        html = html & "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center'>TOTAL IMPUESTOS</div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(total_impuestos) & "</div></td>" &
        "</tr>" &
          "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='2' style='font-size: 14px'><div align='center'></div></td>" &
            "<td style='font-size: 14px'><div align='center'></div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center'></div></td>" &
        "</tr>" &
        "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center'>FONDO DE CAJA </div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(fondo_caja_inicial()) & "</div></td>" &
        "</tr>" &
        "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center'>TOTAL RETIROS </div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center'>" & FormatCurrency(retiros()) & "</div></td>" &
        "</tr>" &
        "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>TOTAL CAJA (SIN FONDO) </div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>" & FormatCurrency(saldo_caja() - fondo_caja_inicial()) & "</div></td>" &
        "</tr>" &
        "<tr>" &
            "<td>&nbsp;</td>" &
            "<td colspan='3' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>TOTAL CAJA </div></td>" &
            "<td colspan='4' style='font-size: 14px'><div align='center' style='font-size: 16px; font-weight: bold'>" & FormatCurrency(saldo_caja()) & "</div></td>" &
        "</tr>" &
        "<tr>" &
            "<td colspan='10'>&nbsp;</td>" &
       " </tr>" &
       " <tr>" &
            "<td colspan='10'>&nbsp;</td>" &
       " </tr>" &
   " </table>" &
"</fieldset>" &
        "</body>"

        Return html
    End Function
    Public Sub enviar_nota_credito_email(ByVal id_nota_credito As Integer)
        Dim Ret As Long


        Dim asunto As String = ""
        Dim mensaje As String = ""
        Dim servidor_smtp As String = ""
        Dim correo_smtp As String = ""
        Dim pass_smtp As String = ""
        Dim puerto_smtp As String = ""
        Dim habilitar_ssl As Boolean = True
        Dim id_adjuntar As Integer = 0
        Dim proteger_pdf As Integer = 0
        Dim pass_pdf As String = ""
        Dim body As String = ""

        Dim num_serie As String = ""
        Dim razon_destinatario As String = ""
        Dim correo_emisor As String = ""
        Dim telefono_emisor As String = ""
        Dim archivo_xml As String = ""
        Dim archivo_pdf As String = ""
        Dim correo_dest As String = ""
        Dim id_cliente As String = ""

        rs.Open("SELECT serie FROM cfg_nota_credito_serie WHERE deshabilitar='0' AND id_cfg_facturacion_serie='1'", conn)
        If rs.RecordCount > 0 Then
            num_serie = rs.Fields("serie").Value
        End If
        rs.Close()

        archivo_xml = Application.StartupPath & "\CFDI3.3\xml\" & global_rfc & num_serie & Format(id_nota_credito, "0000000000") & ".xml"
        archivo_pdf = Application.StartupPath & "\CFDI3.3\xml\" & global_rfc & num_serie & Format(id_nota_credito, "0000000000") & ".pdf"


        rs.Open("SELECT telefono,correo FROM configuracion WHERE id_configuracion='1'", conn)
        If rs.RecordCount > 0 Then
            correo_emisor = rs.Fields("correo").Value
            telefono_emisor = rs.Fields("telefono").Value
        End If
        rs.Close()

        rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre " & _
             "FROM cliente " & _
             "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
             "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
             "JOIN nota_credito ON nota_credito.id_cliente=cliente.id_cliente " & _
             "WHERE nota_credito.id_nota_credito=" & id_nota_credito & "", conn)
        If rs.RecordCount > 0 Then
            razon_destinatario = rs.Fields("nombre").Value
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.email ELSE persona.email END AS correo " & _
             "FROM cliente " & _
             "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
             "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
             "WHERE cliente.id_cliente=" & id_cliente & "", conn)
        If rs.RecordCount > 0 Then
            correo_dest = rs.Fields("correo").Value
        End If
        rs.Close()

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try
                '-----obtenemos los datos necesarios para enviar email------
                'Conectar()
                rs.Open("SELECT * FROM cfg_correo JOIN servidores_smtp ON cfg_correo.id_smtp=servidores_smtp.id_smtp WHERE id_cfg_correo=2", conn)
                If rs.RecordCount > 0 Then
                    asunto = rs.Fields("asunto").Value
                    mensaje = rs.Fields("mensaje").Value
                    id_adjuntar = rs.Fields("id_adjuntar").Value
                    proteger_pdf = rs.Fields("proteger_pdf").Value
                    pass_pdf = rs.Fields("password_pdf").Value
                    servidor_smtp = rs.Fields("servidor_smtp").Value
                    correo_smtp = rs.Fields("correo_smtp").Value
                    pass_smtp = rs.Fields("password_smtp").Value
                    puerto_smtp = rs.Fields("puerto_smtp").Value
                    If rs.Fields("habilitar_ssl").Value = 0 Then
                        habilitar_ssl = False
                    End If
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '-----------------------------------------------------------
                MyMailMsg.From = New Net.Mail.MailAddress(correo_smtp)
                MyMailMsg.To.Add(correo_dest)
                MyMailMsg.CC.Add(correo_smtp)
                MyMailMsg.Subject = asunto & " " & Date.Today.ToLongDateString

                If id_adjuntar = 1 Then
                    MyMailMsg.Body = mensaje & " " & generar_cuerpo_factura_html(razon_destinatario, correo_emisor, telefono_emisor)
                    '
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(servidor_smtp)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = puerto_smtp
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(correo_smtp, pass_smtp)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                Dim pdf As New System.Net.Mail.Attachment(archivo_pdf)
                Dim xml As New System.Net.Mail.Attachment(archivo_xml)

                MyMailMsg.Attachments.Add(att)
                MyMailMsg.Attachments.Add(pdf)
                MyMailMsg.Attachments.Add(xml)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & correo_dest & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Sub enviar_factura_email(ByVal id_factura As Integer)
        Dim Ret As Long


        Dim asunto As String = ""
        Dim mensaje As String = ""
        Dim servidor_smtp As String = ""
        Dim correo_smtp As String = ""
        Dim pass_smtp As String = ""
        Dim puerto_smtp As String = ""
        Dim habilitar_ssl As Boolean = True
        Dim id_adjuntar As Integer = 0
        Dim proteger_pdf As Integer = 0
        Dim pass_pdf As String = ""
        Dim body As String = ""

        Dim num_serie As String = ""
        Dim razon_destinatario As String = ""
        Dim correo_emisor As String = ""
        Dim telefono_emisor As String = ""
        Dim archivo_xml As String = ""
        Dim archivo_pdf As String = ""
        Dim correo_dest As String = ""
        Dim id_cliente As String = ""

        rs.Open("SELECT serie FROM cfg_facturacion_serie WHERE deshabilitar='0' AND id_cfg_facturacion_serie='1'", conn)
        If rs.RecordCount > 0 Then
            num_serie = rs.Fields("serie").Value
        End If
        rs.Close()

        archivo_xml = Application.StartupPath & "\CFDI3.3\xml\" & global_rfc & num_serie & Format(id_factura, "0000000000") & ".xml"
        archivo_pdf = Application.StartupPath & "\CFDI3.3\xml\" & global_rfc & num_serie & Format(id_factura, "0000000000") & ".pdf"


        rs.Open("SELECT telefono,correo FROM configuracion WHERE id_configuracion='1'", conn)
        If rs.RecordCount > 0 Then
            correo_emisor = rs.Fields("correo").Value
            telefono_emisor = rs.Fields("telefono").Value
        End If
        rs.Close()

        rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre " & _
             "FROM cliente " & _
             "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
             "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
             "JOIN factura_electronica ON factura_electronica.id_cliente=cliente.id_cliente " & _
             "WHERE factura_electronica.id_factura_electronica=" & id_factura & "", conn)
        If rs.RecordCount > 0 Then
            razon_destinatario = rs.Fields("nombre").Value
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.email ELSE persona.email END AS correo " & _
             "FROM cliente " & _
             "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
             "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
             "WHERE cliente.id_cliente=" & id_cliente & "", conn)
        If rs.RecordCount > 0 Then
            correo_dest = rs.Fields("correo").Value
        End If
        rs.Close()

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try
                '-----obtenemos los datos necesarios para enviar email------
                'Conectar()
                rs.Open("SELECT * FROM cfg_correo JOIN servidores_smtp ON cfg_correo.id_smtp=servidores_smtp.id_smtp WHERE id_cfg_correo=2", conn)
                If rs.RecordCount > 0 Then
                    asunto = rs.Fields("asunto").Value
                    mensaje = rs.Fields("mensaje").Value
                    id_adjuntar = rs.Fields("id_adjuntar").Value
                    proteger_pdf = rs.Fields("proteger_pdf").Value
                    pass_pdf = rs.Fields("password_pdf").Value
                    servidor_smtp = rs.Fields("servidor_smtp").Value
                    correo_smtp = rs.Fields("correo_smtp").Value
                    pass_smtp = rs.Fields("password_smtp").Value
                    puerto_smtp = rs.Fields("puerto_smtp").Value
                    If rs.Fields("habilitar_ssl").Value = 0 Then
                        habilitar_ssl = False
                    End If
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '-----------------------------------------------------------
                MyMailMsg.From = New Net.Mail.MailAddress(correo_smtp)
                MyMailMsg.To.Add(correo_dest)
                MyMailMsg.CC.Add(correo_smtp)
                MyMailMsg.Subject = asunto & " " & Date.Today.ToLongDateString

                If id_adjuntar = 1 Then
                    MyMailMsg.Body = mensaje & " " & generar_cuerpo_factura_html(razon_destinatario, correo_emisor, telefono_emisor)
                    '
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(servidor_smtp)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = puerto_smtp
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(correo_smtp, pass_smtp)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                Dim pdf As New System.Net.Mail.Attachment(archivo_pdf)
                Dim xml As New System.Net.Mail.Attachment(archivo_xml)

                MyMailMsg.Attachments.Add(att)
                MyMailMsg.Attachments.Add(pdf)
                MyMailMsg.Attachments.Add(xml)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & correo_dest & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Sub enviar_recibo_email(ByVal id_recibo_pago As Integer)
        Dim Ret As Long


        Dim asunto As String = ""
        Dim mensaje As String = ""
        Dim servidor_smtp As String = ""
        Dim correo_smtp As String = ""
        Dim pass_smtp As String = ""
        Dim puerto_smtp As String = ""
        Dim habilitar_ssl As Boolean = True
        Dim id_adjuntar As Integer = 0
        Dim proteger_pdf As Integer = 0
        Dim pass_pdf As String = ""
        Dim body As String = ""

        Dim num_serie As String = ""
        Dim razon_destinatario As String = ""
        Dim correo_emisor As String = ""
        Dim telefono_emisor As String = ""
        Dim archivo_xml As String = ""
        Dim archivo_pdf As String = ""
        Dim correo_dest As String = ""
        Dim id_cliente As String = ""

        rs.Open("SELECT serie FROM cfg_recibo_pago_serie WHERE deshabilitar='0' AND id_cfg_recibo_pago_serie='1'", conn)
        If rs.RecordCount > 0 Then
            num_serie = rs.Fields("serie").Value
        End If
        rs.Close()

        archivo_xml = Application.StartupPath & "\CFDI3.3\xml\" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
        archivo_pdf = Application.StartupPath & "\CFDI3.3\xml\" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".pdf"


        rs.Open("SELECT telefono,correo FROM configuracion WHERE id_configuracion='1'", conn)
        If rs.RecordCount > 0 Then
            correo_emisor = rs.Fields("correo").Value
            telefono_emisor = rs.Fields("telefono").Value
        End If
        rs.Close()

        rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre " & _
             "FROM cliente " & _
             "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
             "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
             "JOIN recibo_pago ON recibo_pago.id_cliente=cliente.id_cliente " & _
             "WHERE recibo_pago.id_recibo_pago=" & id_recibo_pago & "", conn)
        If rs.RecordCount > 0 Then
            razon_destinatario = rs.Fields("nombre").Value
            id_cliente = rs.Fields("id_cliente").Value
        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.email ELSE persona.email END AS correo " & _
             "FROM cliente " & _
             "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
             "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
             "WHERE cliente.id_cliente=" & id_cliente & "", conn)
        If rs.RecordCount > 0 Then
            correo_dest = rs.Fields("correo").Value
        End If
        rs.Close()

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try
                '-----obtenemos los datos necesarios para enviar email------
                'Conectar()
                rs.Open("SELECT * FROM cfg_correo JOIN servidores_smtp ON cfg_correo.id_smtp=servidores_smtp.id_smtp WHERE id_cfg_correo=2", conn)
                If rs.RecordCount > 0 Then
                    asunto = rs.Fields("asunto").Value
                    mensaje = rs.Fields("mensaje").Value
                    id_adjuntar = rs.Fields("id_adjuntar").Value
                    proteger_pdf = rs.Fields("proteger_pdf").Value
                    pass_pdf = rs.Fields("password_pdf").Value
                    servidor_smtp = rs.Fields("servidor_smtp").Value
                    correo_smtp = rs.Fields("correo_smtp").Value
                    pass_smtp = rs.Fields("password_smtp").Value
                    puerto_smtp = rs.Fields("puerto_smtp").Value
                    If rs.Fields("habilitar_ssl").Value = 0 Then
                        habilitar_ssl = False
                    End If
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '-----------------------------------------------------------
                MyMailMsg.From = New Net.Mail.MailAddress(correo_smtp)
                MyMailMsg.To.Add(correo_dest)
                MyMailMsg.CC.Add(correo_smtp)
                MyMailMsg.Subject = asunto & " " & Date.Today.ToLongDateString

                If id_adjuntar = 1 Then
                    MyMailMsg.Body = mensaje & " " & generar_cuerpo_factura_html(razon_destinatario, correo_emisor, telefono_emisor)
                    '
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(servidor_smtp)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = puerto_smtp
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(correo_smtp, pass_smtp)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                Dim pdf As New System.Net.Mail.Attachment(archivo_pdf)
                Dim xml As New System.Net.Mail.Attachment(archivo_xml)

                MyMailMsg.Attachments.Add(att)
                MyMailMsg.Attachments.Add(pdf)
                MyMailMsg.Attachments.Add(xml)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & correo_dest & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub


    Public Sub enviar_corte_email(ByVal id_corte As Integer)
        Dim Ret As Long
        Dim correo_dest As String = ""
        Dim nombre_dest As String = ""
        Dim asunto As String = ""
        Dim mensaje As String = ""
        Dim servidor_smtp As String = ""
        Dim correo_smtp As String = ""
        Dim pass_smtp As String = ""
        Dim puerto_smtp As String = ""
        Dim habilitar_ssl As Boolean = True
        Dim id_adjuntar As Integer = 0
        Dim proteger_pdf As Integer = 0
        Dim pass_pdf As String = ""
        Dim body As String = ""

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try
                '-----obtenemos los datos necesarios para enviar email------
                'Conectar()
                rs.Open("SELECT * FROM cfg_correo JOIN servidores_smtp ON cfg_correo.id_smtp=servidores_smtp.id_smtp WHERE id_cfg_correo=1", conn)
                If rs.RecordCount > 0 Then
                    nombre_dest = rs.Fields("nombre_dest").Value
                    correo_dest = rs.Fields("correo_dest").Value
                    asunto = rs.Fields("asunto").Value
                    mensaje = rs.Fields("mensaje").Value
                    id_adjuntar = rs.Fields("id_adjuntar").Value
                    proteger_pdf = rs.Fields("proteger_pdf").Value
                    pass_pdf = rs.Fields("password_pdf").Value
                    servidor_smtp = rs.Fields("servidor_smtp").Value
                    correo_smtp = rs.Fields("correo_smtp").Value
                    pass_smtp = rs.Fields("password_smtp").Value
                    puerto_smtp = rs.Fields("puerto_smtp").Value
                    If rs.Fields("habilitar_ssl").Value = 0 Then
                        habilitar_ssl = False
                    End If
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '-----------------------------------------------------------
                MyMailMsg.From = New Net.Mail.MailAddress(correo_smtp)
                MyMailMsg.To.Add(correo_dest)
                MyMailMsg.Subject = asunto & ", " & Date.Today.ToLongDateString

                If id_adjuntar = 1 Then
                    MyMailMsg.Body = mensaje & " " & generar_cuerpo_corte_html(id_corte)
                    '
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(servidor_smtp)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = puerto_smtp
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(correo_smtp, pass_smtp)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                MyMailMsg.Attachments.Add(att)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & correo_dest & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Public Function generar_cuerpo_factura_html(ByVal razon_social_destinatario As String, ByVal correo_emisor As String, ByVal telefono_emisor As String) As String

        Dim html As String = "<body>" & _
"<fieldset style='width:700px; height:inherit; margin: 0 auto; margin-top:5px; background-color:#FFFFFF;'>" & _
    "<table width='675' border='0' style='font-family:Century Gothic'>" & _
        "<tr>" & _
            "<td colspan='6' rowspan='5'><div align='center'><img src='cid:InlineImageID' width='200' height='100'/></div></td>" & _
            "<td>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td><span style='font-size: 14px'>" & lineas_reporte(0) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='23'><span style='font-size: 14px'>" & lineas_reporte(1) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='26'><span style='font-size: 14px'>" & lineas_reporte(2) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='26'><span style='font-size: 14px'>" & lineas_reporte(3) & "</span></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td colspan='7' style='font-size: 14px; font-weight: bold; text-decoration: underline'><div align='center'></div></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td width='10'>&nbsp;</td>" & _
            "<td colspan='6' style='font-size: 14px'><strong>" & razon_social_destinatario & " </strong></td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td height='22'>&nbsp;</td>" & _
            "<td colspan='6' style='font-size: 14px'>PRESENTE</td>" & _
            "" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td width='82' style='font-size: 14px'>&nbsp;</td>" & _
            "<td colspan='5' style='font-size: 14px; font-weight: bold'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
            "<td>&nbsp;</td>" & _
            "<td colspan='6' style='font-size: 14px'>A quien corresponda: </td>" & _
            "</tr>" & _
          "<tr>" & _
              "<td>&nbsp;</td>" & _
              "<td colspan='6' style='font-size: 14px'>Por medio de la presente le informamos que " & global_razon_social & ", le ha enviado un nuevo Comprobante Fiscal Digital. </td>" & _
          "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>Su Comprobante Fiscal Digital podra ser descargado como archivo adjunto.</td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>ESTIMADO CLIENTE: LO INVITAMOS A REVISAR SU FACTURA, SI TIENE ALGUNA DUDA FAVOR DE INDICAR EL MISMO DÍA DE LA FACTURACIÓN. DE LO CONTRARIO, NO SE HARÁN CANCELACIONES O REFACTURACIÓN EN DÍAS POSTERIORES POR SU COMPRENSION, GRACIAS.</td>" & _
        "</tr>" & _
       "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'><strong>Atentamente</strong></td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>" & global_razon_social & " </td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'><a href='" & correo_emisor & "'>" & correo_emisor & "</a></td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>" & telefono_emisor & "</td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: 14px'>&nbsp;</td>" & _
        "</tr>" & _
        "<tr>" & _
          "<td>&nbsp;</td>" & _
          "<td colspan='6' style='font-size: x-small; font-weight: bold;'>Aviso de Confidencialidad </td>" & _
        "</tr>" & _
        "<tr>" & _
                "<td>&nbsp;</td>" & _
            "<td colspan='6' style='font-size: x-small;'>Este correo electr&oacute;nico y/o material adjunto es para uso exclusivo de la persona o entidad a la que expresamente se le ha enviado y puede contener informaci&oacute;n confidencial o material privilegiado. Si usted no es el destinatario legitimo del mismo, por favor rep&oacute;rtelo inmediantamente al remitente del correo y b&oacute;rrrelo. Cualquier revisi&oacute;n, retransmisi&oacute;n, difusi&oacute;n o cualquier otro uso de este correo, por personas o entidades distintas a las del destinatario leg&iacute;timo, queda expresamente prohibido. Este correo electr&oacute;nico no pretende ni debe ser considerado como constitutivo de ninguna relaci&oacute;n legal, contractual o de otra &iacute;ndole similar.</td>" & _
            "" & _
        "</tr>" & _
         "<tr>" & _
            "<td colspan='7'>&nbsp;</td>" & _
        "</tr>" & _
   "</table>" & _
"</fieldset>" & _
        "</body>"

        Return html
    End Function
    Private Sub limpiar_abonos()
        For x = 0 To 4
            abonos(x) = 0
        Next
    End Sub
End Module
