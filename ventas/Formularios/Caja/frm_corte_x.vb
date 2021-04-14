Public Class frm_corte_x
    Dim cargado As Boolean
    Private Sub frm_corte_x_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        cargar_tipo_reporte()
        dtp_fecha.Value = Today
        obtener_cortes(dtp_fecha.Value)
        cargado = True
    End Sub
    Private Sub cargar_tipo_reporte()
        cb_tipo_reporte.Items.Clear()
        cb_tipo_reporte.Text = ""
        cb_tipo_reporte.Items.Add(New myItem("1", "SENCILLO"))
        'cb_turno.Items.Add(New myItem("2", "DETALLADO"))
        cb_tipo_reporte.SelectedIndex = 0
    End Sub
    Private Sub obtener_cortes(ByVal fecha As Date)
        cb_turno.Items.Clear()
        cb_turno.Text = ""
        Dim hora As DateTime
        rs.Open("SELECT id_corte,nombre_empleado,fecha FROM cortes WHERE DATE(fecha)='" & Format(fecha, "yyyy-MM-dd") & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                hora = rs.Fields("fecha").Value
                cb_turno.Items.Add(New myItem(rs.Fields("id_corte").Value, rs.Fields("id_corte").Value & "-" & hora.ToLongTimeString & "-" & rs.Fields("nombre_empleado").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub

    Private Sub dtp_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha.ValueChanged
        If cargado = True Then
            obtener_cortes(dtp_fecha.Value)
        End If
    End Sub

    Private Sub btn_impresora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_impresora.Click
        If cb_turno.SelectedIndex <> -1 Then
            If CType(cb_tipo_reporte.SelectedItem, myItem).Value = 1 Then
                imprimir_corte_caja_v3(CType(cb_turno.SelectedItem, myItem).Value)
            End If
        Else
            MsgBox("Para generar el corte, debe seleccionar un turno de la lista!", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_pantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla.Click
        If cb_turno.SelectedIndex <> -1 Then
            If CType(cb_tipo_reporte.SelectedItem, myItem).Value = 1 Then
                imprimir_corte_x_pantalla(CType(cb_turno.SelectedItem, myItem).Value)
            End If
        Else
            MsgBox("Para generar el corte, debe seleccionar un turno de la lista!", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        If cb_turno.SelectedIndex <> -1 Then
            If CType(cb_tipo_reporte.SelectedItem, myItem).Value = 1 Then
                sfd_excel.Filter = "Excel Files (*.xlsx*)|*.xlsx"

                If sfd_excel.ShowDialog = Windows.Forms.DialogResult.OK Then
                    imprimir_corte_x_excel(CType(cb_turno.SelectedItem, myItem).Value, sfd_excel.FileName)
                End If
            End If
        Else
            MsgBox("Para generar el corte, debe seleccionar un turno de la lista!", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_enviar_email_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar_email.Click
        If cb_turno.SelectedIndex <> -1 Then
            If CType(cb_tipo_reporte.SelectedItem, myItem).Value = 1 Then
                enviar_corte_email(CType(cb_turno.SelectedItem, myItem).Value)
            End If
        Else
            MsgBox("Para enviar el corte, debe seleccionar un turno de la lista!", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub
End Class