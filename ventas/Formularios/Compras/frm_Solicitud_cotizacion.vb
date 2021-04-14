Public Class frm_Solicitud_cotizacion

    Private Sub frm_Solicitud_cotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        estilo_buscar_solicitud(dgv_busqueda)
        estilo_solicitud_cotizacion(dgv_solicitud_cotizacion)
        agregar_tabla_solicitud_cotizacion(1, "PRODUCTO DE PRUEBA", 20, "PIEZA", 50, False, 21, False, 32, False, 0)
    End Sub
End Class