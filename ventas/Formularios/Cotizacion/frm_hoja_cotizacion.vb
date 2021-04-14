Public Class frm_hoja_cotizacion
    Public id_cotizacion As Integer
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_con_membrete.CheckedChanged
        If chb_con_membrete.Checked = True Then
            chb_sin_membrete.Checked = False
            chb_ambos.Checked = False
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If chb_con_membrete.Checked = True Then
            Generarcotizacion(id_cotizacion, True)
        ElseIf chb_sin_membrete.Checked = True Then
            Generarcotizacion(id_cotizacion, False)
        ElseIf chb_ambos.Checked = True Then
            Generarcotizacion(id_cotizacion, True)
            Generarcotizacion(id_cotizacion, False)
        End If
        Me.Close()
    End Sub

    Private Sub chb_sin_membrete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_sin_membrete.CheckedChanged
        If chb_sin_membrete.Checked = True Then
            chb_con_membrete.Checked = False
            chb_ambos.Checked = False
        End If
    End Sub

    Private Sub chb_ambos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_ambos.CheckedChanged
        If chb_ambos.Checked = True Then
            chb_sin_membrete.Checked = False
            chb_con_membrete.Checked = False
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
End Class