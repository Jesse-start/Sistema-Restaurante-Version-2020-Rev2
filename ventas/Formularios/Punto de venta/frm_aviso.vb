Public Class frm_aviso
    Dim x As Integer
    Private Sub Temporizador_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Temporizador.Tick
        Try
            If x = 8 Then
                Temporizador.Enabled = False
                Temporizador.Stop()
                Me.Dispose()
            Else
                If x > 8 Then
                    x = 0
                Else
                    x = x + 1
                    If Me.BackColor = Color.FromArgb(conf_colores(8)) Then
                        Me.BackColor = Color.FromArgb(conf_colores(9))
                        Lbl_aviso.ForeColor = Color.FromArgb(conf_colores(8))
                    Else
                        Me.BackColor = Color.FromArgb(conf_colores(8))
                        Lbl_aviso.ForeColor = Color.FromArgb(conf_colores(9))
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_aviso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.TopMost = True
    End Sub

    Private Sub frm_aviso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        x = 0
        Me.BackColor = Color.FromArgb(conf_colores(8))
        Lbl_aviso.ForeColor = Color.FromArgb(conf_colores(9))
        Temporizador.Enabled = True
        Temporizador.Start()
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Temporizador.Stop()
        'btn_ok.Visible = False
        'Me.TopMost = True
        Me.Close()
    End Sub

    Private Sub Lbl_aviso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbl_aviso.Click

    End Sub
End Class