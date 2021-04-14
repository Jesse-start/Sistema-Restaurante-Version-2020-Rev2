Imports Skybound.Gecko
Imports System.IO

Public Class frm_navegador
    Private Sub frm_navegador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.Open("SELECT extra FROM empleado_opciones WHERE id_opcion='39' AND id_empleado='" & global_id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            tb_direccion.Text = rs.Fields("extra").Value
        End If
        rs.Close()
        navegador.Navigate(tb_direccion.Text)
    End Sub

    Private Sub btn_ir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ir.Click
        navegador.Navigate(tb_direccion.Text)
    End Sub

    Private Sub btn_atras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_atras.Click
        navegador.GoBack()
    End Sub

    Private Sub btn_adelante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_adelante.Click
        navegador.GoForward()
    End Sub

    Private Sub btn_actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        navegador.Refresh()
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Skybound.Gecko.Xpcom.Initialize(Application.StartupPath & "\xulrunner")
        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class