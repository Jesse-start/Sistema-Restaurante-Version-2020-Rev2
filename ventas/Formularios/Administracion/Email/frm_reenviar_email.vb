Public Class frm_reenviar_email

    Private Sub frm_reenviar_email_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        dtp_fecha.Value = Today
        obtener_documentos(dtp_fecha.Value)
    End Sub
    Private Sub obtener_documentos(ByVal fecha As Date)
        cb_documentos.Items.Clear()
        cb_documentos.Text = ""
        'Conectar()
        rs.Open("SELECT id_corte,nombre_empleado,total_caja FROM cortes WHERE id_empleado_caja=" & global_id_usuario & " AND NOT ISNULL(body_html) AND DATE(fecha)='" & Format(fecha, "yyyy-MM-dd") & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_documentos.Items.Add(New myItem(rs.Fields("id_corte").Value, rs.Fields("nombre_empleado").Value & " Total en caja: " & FormatCurrency(rs.Fields("total_caja").Value)))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub dtp_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha.ValueChanged
        obtener_documentos(dtp_fecha.Value)
    End Sub

    
    Private Sub btn_reenviar_email_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reenviar_email.Click
        If cb_documentos.SelectedIndex <> -1 Then
            If MsgBox("Se reenviara el corte seleccionado. Esta operacion no afectara ningun registro en la base de datos ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                reenviar_email(CType(cb_documentos.SelectedItem, myItem).Value)
            End If
        Else
            MsgBox("Seleccione un corte", MsgBoxStyle.Exclamation, "aviso")
        End If
    End Sub
End Class