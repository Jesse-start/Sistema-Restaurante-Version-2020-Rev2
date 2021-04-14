Public Class frm_cfg_enviar_email
    Private Declare Function IsNetworkAlive Lib "SENSAPI.DLL" (ByRef lpdwFlags As Long) As Long
    Private Sub frm_cfg_enviar_email_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        Obtener_documento_disponibles()
        cargar()
    End Sub
    Private Sub obtener_servidores_smtp()
        cb_servidor_smtp.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_smtp,servidor_smtp FROM servidores_smtp", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_servidor_smtp.Items.Add(New myItem(rs.Fields("id_smtp").Value, rs.Fields("servidor_smtp").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub cargar()
        obtener_servidores_smtp()
        Dim id_smtp As Integer = 0
        'Conectar()
        rs.Open("SELECT cfg_correo.* FROM cfg_correo JOIN servidores_smtp ON servidores_smtp.id_smtp=cfg_correo.id_smtp", conn)
        If rs.RecordCount > 0 Then
            tb_nombre_dest.Text = rs.Fields("nombre_dest").Value
            tb_email_dest.Text = rs.Fields("correo_dest").Value
            tb_asunto.Text = rs.Fields("asunto").Value
            tb_mensaje.Text = rs.Fields("mensaje").Value
            id_smtp = rs.Fields("id_smtp").Value
            chb_enviar_email_generado.CheckState = rs.Fields("enviar_despues_generar").Value
            seleccionar_tipo_documento(rs.Fields("id_adjuntar").Value)
            chb_proteger_pdf.CheckState = rs.Fields("proteger_pdf").Value
            If rs.Fields("id_adjuntar").Value > 1 Then
                If rs.Fields("proteger_pdf").Value = 1 Then
                    tb_password.Text = rs.Fields("password_pdf").Value
                    tb_password_confirm.Text = rs.Fields("password_pdf").Value
                End If
            End If

        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        seleccionar_servidor_smtp(id_smtp)
    End Sub
    Private Sub Obtener_documento_disponibles()
        cb_tipo_documento.Items.Clear()
        cb_tipo_documento.Items.Add(New myItem(1, "Corte de caja en cuerpo de mensaje"))
        'cb_tipo_documento.Items.Add(New myItem(2, "Corte de caja en formato PDF"))
    End Sub
    Private Sub cb_tipo_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_tipo_documento.SelectedIndexChanged
        If CType(cb_tipo_documento.SelectedItem, myItem).Value > 1 Then
            gb_cfg_pdf.Enabled = True
        Else
            gb_cfg_pdf.Enabled = False
        End If
    End Sub
    Private Sub seleccionar_servidor_smtp(ByVal id_adjuntar As Integer)
        For x = 0 To cb_servidor_smtp.Items.Count - 1
            If id_adjuntar = CType(cb_servidor_smtp.Items(x), myItem).Value Then
                cb_servidor_smtp.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub seleccionar_tipo_documento(ByVal id_smtp As Integer)
        For x = 0 To cb_tipo_documento.Items.Count - 1
            If id_smtp = CType(cb_tipo_documento.Items(x), myItem).Value Then
                cb_tipo_documento.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub

    Private Sub chb_proteger_pdf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_proteger_pdf.CheckedChanged
        If chb_proteger_pdf.Checked = True Then
            tb_password.Enabled = True
            tb_password_confirm.Enabled = True
        Else
            tb_password.Enabled = False
            tb_password_confirm.Enabled = False
            tb_password.Text = ""
            tb_password_confirm.Text = ""
        End If
    End Sub

    Private Sub cb_servidor_smtp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_servidor_smtp.SelectedIndexChanged
        If cb_servidor_smtp.SelectedIndex <> -1 Then
            'Conectar()
            rs.Open("SELECT * FROM servidores_smtp WHERE id_smtp=" & CType(cb_servidor_smtp.SelectedItem, myItem).Value, conn)
            If rs.RecordCount > 0 Then
                tb_correo_smtp.Text = rs.Fields("correo_smtp").Value
                tb_password_smtp.Text = rs.Fields("password_smtp").Value
                tb_puerto_smtp.Text = rs.Fields("puerto_smtp").Value
                chb_habilitar_ssl.CheckState = rs.Fields("habilitar_ssl").Value
            End If
            rs.Close()

            'conn.close()
            'conn = Nothing
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click

        Dim cadena As String = "Se encontraron los siguientes errores." & vbCrLf
        Dim correcto As Boolean = True

        If Trim(tb_nombre_dest.TextLength) = 0 Then
            cadena = cadena & "     *Nombre del destinatario" & vbCrLf
            correcto = False
        End If
        If Trim(tb_email_dest.TextLength) = 0 Then
            cadena = cadena & "     *correo del destinatario" & vbCrLf
            correcto = False
        End If
        If cb_tipo_documento.SelectedIndex = -1 Then
            cadena = cadena & "     *Imformacion adjunta" & vbCrLf
            correcto = False
        End If
        If Trim(cb_servidor_smtp.Text) = "" Then
            cadena = cadena & "     *Servidor smtp" & vbCrLf
            correcto = False
        End If
        If Trim(tb_correo_smtp.Text) = "" Then
            cadena = cadena & "     *Correo de servidor smtp" & vbCrLf
            correcto = False
        End If

        If Trim(tb_password_smtp.Text) = "" Then
            cadena = cadena & "     *Contraseña de servidor smtp" & vbCrLf
            correcto = False
        End If
        If Trim(tb_puerto_smtp.Text) = "" Then
            cadena = cadena & "     *Puerto de servidor smtp" & vbCrLf
            correcto = False
        End If

        If chb_proteger_pdf.Checked = True Then
            If Trim(tb_password.TextLength) = 0 Then
                cadena = cadena & "     *La contraseña no puede estar vacia" & vbCrLf
                correcto = False
            End If
            If Trim(tb_password_confirm.TextLength) = 0 Then
                cadena = cadena & "     *La confirmacion de contraseña no puede estar vacia" & vbCrLf
                correcto = False
            End If
            If tb_password.Text <> tb_password_confirm.Text Then
                cadena = cadena & "     *Las contraseñas no coinciden" & vbCrLf
                correcto = False
            End If
        End If

        If correcto Then
            If MsgBox("Confirme que desea actualizar estos valores", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim id_servidor_smtp As Integer = 0
                If cb_servidor_smtp.SelectedIndex = -1 Then
                    If MsgBox("Desea guardar " & cb_servidor_smtp.Text & " como nuevo servidor smtp", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        'Conectar()
                        conn.Execute("INSERT INTO servidores_smtp(servidor_smtp,correo_smtp,password_smtp,puerto_smtp,habilitar_ssl) VALUES('" & cb_servidor_smtp.Text & "','" & tb_correo_smtp.Text & "','" & tb_password_smtp.Text & "','" & tb_puerto_smtp.Text & "','" & chb_habilitar_ssl.CheckState & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_servidor_smtp = rs.Fields(0).Value
                        rs.Close()
                        'conn.close()
                        'conn = Nothing
                        GoTo ACTUALIZAR_CFG
                    Else
                        Exit Sub
                    End If
                Else
                    id_servidor_smtp = CType(cb_servidor_smtp.SelectedItem, myItem).Value
                    'Conectar()
                    conn.Execute("UPDATE servidores_smtp SET correo_smtp='" & tb_correo_smtp.Text & "',password_smtp='" & tb_password_smtp.Text & "',puerto_smtp='" & tb_puerto_smtp.Text & "',habilitar_ssl='" & chb_habilitar_ssl.CheckState & "' WHERE id_smtp=" & id_servidor_smtp)
                    'conn.close()
                    'conn = Nothing

ACTUALIZAR_CFG:     'Conectar()
                    conn.Execute("UPDATE cfg_correo SET nombre_dest='" & tb_nombre_dest.Text & "',correo_dest='" & tb_email_dest.Text & "',asunto='" & tb_asunto.Text & "',mensaje='" & tb_mensaje.Text & "',id_adjuntar='" & CType(cb_tipo_documento.SelectedItem, myItem).Value & "',proteger_pdf='" & chb_proteger_pdf.CheckState & "',password_pdf='" & tb_password.Text & "',enviar_despues_generar='" & chb_enviar_email_generado.CheckState & "',id_smtp='" & id_servidor_smtp & "' WHERE id_cfg_correo=1")
                    'conn.close()
                    'conn = Nothing
                End If
                cargar()
                MsgBox("Los cambios se han guardado correctamente", MsgBoxStyle.Information, "Correcto")
            End If
        Else
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_comprobar_cfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_comprobar_cfg.Click
        Dim cadena As String = "Se encontraron los siguientes errores." & vbCrLf
        Dim correcto As Boolean = True

        If Trim(tb_nombre_dest.TextLength) = 0 Then
            cadena = cadena & "     *Nombre del destinatario" & vbCrLf
            correcto = False
        End If
        If Trim(tb_email_dest.TextLength) = 0 Then
            cadena = cadena & "     *correo del destinatario" & vbCrLf
            correcto = False
        End If
        If cb_tipo_documento.SelectedIndex = -1 Then
            cadena = cadena & "     *Imformacion adjunta" & vbCrLf
            correcto = False
        End If
        If Trim(cb_servidor_smtp.Text) = "" Then
            cadena = cadena & "     *Servidor smtp" & vbCrLf
            correcto = False
        End If
        If Trim(tb_correo_smtp.Text) = "" Then
            cadena = cadena & "     *Correo de servidor smtp" & vbCrLf
            correcto = False
        End If

        If Trim(tb_password_smtp.Text) = "" Then
            cadena = cadena & "     *Contraseña de servidor smtp" & vbCrLf
            correcto = False
        End If
        If Trim(tb_puerto_smtp.Text) = "" Then
            cadena = cadena & "     *Puerto de servidor smtp" & vbCrLf
            correcto = False
        End If

        If chb_proteger_pdf.Checked = True Then
            If Trim(tb_password.TextLength) = 0 Then
                cadena = cadena & "     *La contraseña no puede estar vacia" & vbCrLf
                correcto = False
            End If
            If Trim(tb_password_confirm.TextLength) = 0 Then
                cadena = cadena & "     *La confirmacion de contraseña no puede estar vacia" & vbCrLf
                correcto = False
            End If
            If tb_password.Text <> tb_password_confirm.Text Then
                cadena = cadena & "     *Las contraseñas no coinciden" & vbCrLf
                correcto = False
            End If
        End If

        If correcto Then

            If MsgBox("Se enviará un correo de prueba. Esta operacion no afectara ningun registro en la base de datos ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                body_corte_html = corte_actual_html()
                probar_conf_actual()
            End If
        Else
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub
    Public Sub probar_conf_actual()
        Dim Ret As Long

        'Si el Api retorna 0 quiere decir que no hay ningun tipo de conexión de Red
        If IsNetworkAlive(Ret) = 0 Then
            MsgBox("No existe conexion a internet" & vbNewLine + "Error enviando E-Mail." & vbNewLine & vbNewLine + "Por favor revise su conexion a internet" & vbNewLine + "e intentelo nuevamente.", MsgBoxStyle.Exclamation)
        Else
            Dim MyMailMsg As New Net.Mail.MailMessage
            Dim HostName As String = My.Computer.Name

            Try

                MyMailMsg.From = New Net.Mail.MailAddress(tb_correo_smtp.Text)
                MyMailMsg.To.Add(tb_email_dest.Text)
                MyMailMsg.Subject = tb_asunto.Text

                If CType(cb_tipo_documento.SelectedItem, myItem).Value = 1 Then
                    MyMailMsg.Body = tb_mensaje.Text & " " & body_corte_html
                End If

                MyMailMsg.IsBodyHtml = True
                Dim att As New System.Net.Mail.Attachment(Application.StartupPath & "\logo.png")

                att.ContentId = "InlineImageID"
                Dim SMTP As New Net.Mail.SmtpClient(cb_servidor_smtp.Text)
                'Para enviar por Hotmail utilizamos smtp.live.com y para enviar por Gmail utilizamos smtp.gmail.com

                SMTP.Port = tb_puerto_smtp.Text

                Dim habilitar_ssl As Boolean = True
                If chb_habilitar_ssl.Checked = False Then
                    habilitar_ssl = False
                End If
                SMTP.EnableSsl = habilitar_ssl

                SMTP.Credentials = New System.Net.NetworkCredential(tb_correo_smtp.Text, tb_password_smtp.Text)
                'Aquí es necesario utilizar una cuenta de correo electrónico válida para que podamos mandar nuestros correos.

                MyMailMsg.Attachments.Add(att)

                SMTP.Send(MyMailMsg)
                MsgBox("Tu E-Mail se ha enviado exitosamente a " & tb_email_dest.Text & " ", MsgBoxStyle.Information, "Listo!!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class