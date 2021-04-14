Public Class frm_saldo_inicial
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))

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

        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))

        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))

        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))

        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            tb_cantidad.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If (tb_cantidad.TextLength) <> 0 Then
            tb_cantidad.Text = tb_cantidad.Text.Remove(tb_cantidad.TextLength - 1, 1)
            tb_cantidad.SelectionStart = Len(tb_cantidad.Text)
        End If
      
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        tb_cantidad.Text = ""
    End Sub

    Private Sub tb_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cantidad.KeyPress
        e.Handled = txtNumerico(tb_cantidad, e.KeyChar, True)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            If Trim(tb_cantidad.TextLength) = 0 Then
                MsgBox("Ingrese la cantidad de fondo de caja", MsgBoxStyle.Exclamation, "Aviso")
            Else
                'If tb_cantidad.Text <> 0 Then
                If MsgBox("Confirme fondo de caja por " & FormatCurrency(tb_cantidad.Text), MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
                    'Conectar()
                    conn.Execute("INSERT INTO caja_saldo_inicial(saldo_inicial,id_empleado,fecha) VALUES ('" & CDec(tb_cantidad.Text) & "','" & global_id_empleado & "',NOW())")
                    'conn.close()
                    'conn = Nothing
                    ' MsgBox("Fondo de caja guar")
                    Me.Close()
                End If
                'Else
                'MsgBox("El saldo no puede ser 0")
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
       
    End Sub

    Private Sub frm_saldo_inicial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        tb_cantidad.Text = 0
    End Sub

    Private Sub btn0_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn0.MouseDown, btn1.MouseDown, btn2.MouseDown, btn3.MouseDown, btn4.MouseDown, btn5.MouseDown, btn6.MouseDown, btn7.MouseDown, btn8.MouseDown, btn9.MouseDown, Button10.MouseDown, Button14.MouseDown, Button6.MouseDown, btn_punto.MouseDown
        sender.backcolor = Color.FromArgb(conf_colores(8))
        sender.forecolor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub btn0_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn0.MouseUp, btn1.MouseUp, btn2.MouseUp, btn3.MouseUp, btn4.MouseUp, btn5.MouseUp, btn6.MouseUp, btn7.MouseUp, btn8.MouseUp, btn9.MouseUp, Button10.MouseUp, Button14.MouseUp, Button6.MouseUp, btn_punto.MouseUp
        sender.backcolor = Color.FromArgb(conf_colores(9))
        sender.forecolor = Color.FromArgb(conf_colores(8))
    End Sub
End Class