Public Class frm_busqueda_insumo
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        frm_resultado_insumo.busqueda = tb_busqueda.Text
        If frm_resultado_insumo.buscar() = False Then
            MsgBox("No se encontraron resultados", MsgBoxStyle.Exclamation, "Aviso")
        Else
            frm_resultado_insumo.ShowDialog()
            Me.Dispose()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class