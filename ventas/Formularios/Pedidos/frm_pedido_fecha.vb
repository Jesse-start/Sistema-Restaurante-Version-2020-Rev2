Public Class frm_pedido_fecha
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        If TypeOf sender Is Button Then
            dtp_hora_entrega.Focus()
            SendKeys.Send("{UP}")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_down.Click
        If TypeOf sender Is Button Then
            dtp_hora_entrega.Focus()
            SendKeys.Send("{DOWN}")
        End If
    End Sub

    Private Sub frm_pedido_fecha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtp_fecha_entrega.Value = Today
        dtp_fecha_entrega.MinDate = Today
        dtp_hora_entrega.Value = DateTime.Now
        tb_comentarios.Text = ""
        If global_tipo_operacion = 1 Then
            lbl_tipo_operacion.Text = "Configuracion del Pedido"
        ElseIf global_tipo_operacion = 2 Then
            lbl_tipo_operacion.Text = "Configuracion del Apartado"
        End If
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_fecha_entrega.ForeColor = Color.FromArgb(conf_colores(2))

        btn_up.BackColor = Color.FromArgb(conf_colores(8))
        btn_up.ForeColor = Color.FromArgb(conf_colores(9))

        btn_down.BackColor = Color.FromArgb(conf_colores(8))
        btn_down.ForeColor = Color.FromArgb(conf_colores(9))

        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click


        If global_tipo_operacion = 1 Then
            frm_principal3.enviar_como_pedido(dtp_fecha_entrega.Value, dtp_hora_entrega.Value, tb_comentarios.Text)
        ElseIf global_tipo_operacion = 2 Then
            frm_principal3.enviar_como_apartado(dtp_fecha_entrega.Value, dtp_hora_entrega.Value, tb_comentarios.Text)
        End If


        Me.Close()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class