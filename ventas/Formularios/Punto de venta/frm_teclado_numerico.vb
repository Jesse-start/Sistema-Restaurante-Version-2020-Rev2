Public Class frm_teclado_numerico
    Public modo As Integer = 0 '0 ajuste de inventario,1.-producto_sucursal_cantidad
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        btn0.BackColor = Color.FromArgb(conf_colores(8))
        btn0.ForeColor = Color.FromArgb(conf_colores(9))

        btn1.BackColor = Color.FromArgb(conf_colores(8))
        btn1.ForeColor = Color.FromArgb(conf_colores(9))

        btn2.BackColor = Color.FromArgb(conf_colores(8))
        btn2.ForeColor = Color.FromArgb(conf_colores(9))

        btn3.BackColor = Color.FromArgb(conf_colores(8))
        btn3.ForeColor = Color.FromArgb(conf_colores(9))

        btn4.BackColor = Color.FromArgb(conf_colores(8))
        btn4.ForeColor = Color.FromArgb(conf_colores(9))

        btn5.BackColor = Color.FromArgb(conf_colores(8))
        btn5.ForeColor = Color.FromArgb(conf_colores(9))

        btn6.BackColor = Color.FromArgb(conf_colores(8))
        btn6.ForeColor = Color.FromArgb(conf_colores(9))

        btn7.BackColor = Color.FromArgb(conf_colores(8))
        btn7.ForeColor = Color.FromArgb(conf_colores(9))

        btn8.BackColor = Color.FromArgb(conf_colores(8))
        btn8.ForeColor = Color.FromArgb(conf_colores(9))

        btn9.BackColor = Color.FromArgb(conf_colores(8))
        btn9.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))

        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))

        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))

        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))

        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            tb_codigo.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If tb_codigo.TextLength > 0 Then
            tb_codigo.Text = tb_codigo.Text.Remove(tb_codigo.TextLength - 1, 1)
            tb_codigo.SelectionStart = Len(tb_codigo.Text)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        tb_codigo.Text = ""
    End Sub
    Private Sub tb_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_codigo.KeyPress
        'e.Handled = validar_teclado(e.KeyChar, {"0"})
        e.Handled = txtNumerico(tb_codigo, e.KeyChar, True)
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Trim(tb_codigo.TextLength) > 0 Then
            If modo = 0 Then
                frm_ajuste_inventario.cantidad_real(tb_codigo.Text)
                tb_codigo.Text = ""
                Me.Close()
            ElseIf modo = 1 Then
                If tb_codigo.Text <> 0 Then
                    frm_productos_recepcion.modificar_cantidad(tb_codigo.Text)
                    tb_codigo.Text = ""
                    Me.Close()
                Else
                    MsgBox("La cantidad no puede ser cero", MsgBoxStyle.Exclamation, "Aviso")
                End If
            ElseIf modo = 2 Then
                If tb_codigo.Text <> 0 Then
                    frm_traspasos_recepcion.modificar_cantidad(tb_codigo.Text)
                    tb_codigo.Text = ""
                    Me.Close()
                Else
                    MsgBox("La cantidad no puede ser cero", MsgBoxStyle.Exclamation, "Aviso")
                End If
            ElseIf modo = 3 Then
                If tb_codigo.Text <> 0 Then
                    frm_traspasos_envio.modificar_cantidad(tb_codigo.Text)
                    tb_codigo.Text = ""
                    Me.Close()
                Else
                    MsgBox("La cantidad no puede ser cero", MsgBoxStyle.Exclamation, "Aviso")
                End If
            End If

        Else
            MsgBox("Escriba una cantidad")
        End If
    End Sub

    Private Sub frm_teclado_numerico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        tb_codigo.Text = "1"
    End Sub
End Class