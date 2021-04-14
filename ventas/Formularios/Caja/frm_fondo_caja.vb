Public Class frm_fondo_caja
    Private current_fp As Integer = 0 '5-billete20,6.-billete5o,7.-Billetede100,8.-billete200,9.-billetede500,10.-billetede1000,11.-1, 12.-2, 13.-5,14.-10
    Private cargado As Boolean = False
    Public modo_venta As Integer = 0 ' 0 rapido, 1 comedor

    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        gb_efectivo.ForeColor = Color.FromArgb(conf_colores(2))
        FlowLayoutPanel1.ForeColor = Color.FromArgb(conf_colores(13))

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

        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))

        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))

        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))
        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Function calcular_total_efectivo() As Decimal
        Dim total As Decimal = 0
        If tb_1.TextLength = 0 Or tb_1.Text = "." Then
            tb_1.Text = "0"
        End If
        If tb_2.TextLength = 0 Or tb_2.Text = "." Then
            tb_2.Text = "0"
        End If
        If tb_5.TextLength = 0 Or tb_5.Text = "." Then
            tb_5.Text = "0"
        End If
        If tb_10.TextLength = 0 Or tb_10.Text = "." Then
            tb_10.Text = "0"
        End If
        If tb_20.TextLength = 0 Or tb_20.Text = "." Then
            tb_20.Text = "0"
        End If
        If tb_50.TextLength = 0 Or tb_50.Text = "." Then
            tb_50.Text = "0"
        End If
        If tb_50c.TextLength = 0 Or tb_50c.Text = "." Then
            tb_50c.Text = "0"
        End If
        If tb_100.TextLength = 0 Or tb_100.Text = "." Then
            tb_100.Text = "0"
        End If
        If tb_200.TextLength = 0 Or tb_200.Text = "." Then
            tb_200.Text = "0"
        End If
        If tb_500.TextLength = 0 Or tb_500.Text = "." Then
            tb_500.Text = "0"
        End If
        If tb_1000.TextLength = 0 Or tb_1000.Text = "." Then
            tb_1000.Text = "0"
        End If
        total = CDec(tb_50c.Text * 0.5) + CDec(tb_1.Text) + CDec(tb_2.Text * 2) + CDec(tb_5.Text * 5) + CDec(tb_10.Text * 10) + CDec(tb_20.Text * 20) + CDec(tb_50.Text * 50) + CDec(tb_100.Text * 100) + CDec(tb_200.Text * 200) + CDec(tb_500.Text * 500) + CDec(tb_1000.Text * 1000)
        Return total
    End Function
    
    Private Sub actualizar_total_efectivo()
        tb_efectivo.Text = calcular_total_efectivo()
    End Sub
    Private Sub frm_declaracion_cajero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        cargado = False
        current_fp = 0
        actualizar_colores()
        cargado = True

        tb_efectivo.Text = "0.00"
        tb_20.Text = "0"
        tb_50.Text = "0"
        tb_100.Text = "0"
        tb_200.Text = "0"
        tb_500.Text = "0"
        tb_1000.Text = "0"
        tb_1.Text = "0"
        tb_2.Text = "0"
        tb_5.Text = "0"
        tb_10.Text = "0"
        tb_50c.Text = "0"

    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If current_fp = 0 Then
                tb_efectivo.Focus()
            ElseIf current_fp = 5 Then
                tb_20.Focus()
            ElseIf current_fp = 6 Then
                tb_50.Focus()
            ElseIf current_fp = 7 Then
                tb_100.Focus()
            ElseIf current_fp = 8 Then
                tb_200.Focus()
            ElseIf current_fp = 9 Then
                tb_500.Focus()
            ElseIf current_fp = 10 Then
                tb_1000.Focus()
            ElseIf current_fp = 11 Then
                tb_1.Focus()
            ElseIf current_fp = 12 Then
                tb_2.Focus()
            ElseIf current_fp = 13 Then
                tb_5.Focus()
            ElseIf current_fp = 14 Then
                tb_10.Focus()
            ElseIf current_fp = 15 Then
                tb_50c.Focus()
            End If
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub
    Private Sub tb_efectivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_efectivo.Click, lb_efectivo.Click
        current_fp = 0
        actualizar_colores()
        tb_efectivo.Focus()
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If current_fp < 4 Then
            current_fp += 1
            actualizar_colores()
        Else
            btn_aceptar_Click(sender, e)
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
        'If global_cfg_id_pantalla = 0 Then
        'principal.Dispose()
        'Else
        'frm_principal2.Dispose()
        'End If
        ' frm_usuarios.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If MsgBox("Estan correcto los datos?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Try
                If Trim(tb_efectivo.TextLength) = 0 Then
                    MsgBox("Ingrese la cantidad de fondo de caja", MsgBoxStyle.Exclamation, "Aviso")
                Else
                    'If tb_cantidad.Text <> 0 Then
                    If MsgBox("Confirme fondo de caja por " & FormatCurrency(tb_efectivo.Text), MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
                        'Conectar()
                        conn.Execute("INSERT INTO caja_saldo_inicial(saldo_inicial,id_empleado,fecha) VALUES ('" & CDec(tb_efectivo.Text) & "','" & global_id_empleado & "',NOW())")
                        'conn.close()
                        'conn = Nothing
                        ' MsgBox("Fondo de caja guar")
                        If modo_venta = 0 Then
                            frm_botones_terminal.Hide()
                            frm_principal3.modo_venta = Me.modo_venta
                            frm_principal3.cargar_usuario_actual()
                            frm_principal3.Show()
                            frm_principal3.BringToFront()
                        Else
                            frm_comedor.Show()
                            frm_comedor.BringToFront()
                        End If
                        Me.Close()
                    End If
                    'Else
                    'MsgBox("El saldo no puede ser 0")
                    'End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If current_fp = 0 Then
            If tb_efectivo.TextLength > 0 Then
                tb_efectivo.Text = tb_efectivo.Text.Remove(tb_efectivo.TextLength - 1, 1)
                tb_efectivo.SelectionStart = Len(tb_efectivo.Text)
            End If
        

        ElseIf current_fp = 5 Then
            If tb_20.TextLength > 0 Then
                tb_20.Text = tb_20.Text.Remove(tb_20.TextLength - 1, 1)
                tb_20.SelectionStart = Len(tb_20.Text)
            End If
        ElseIf current_fp = 6 Then
            If tb_50.TextLength > 0 Then
                tb_50.Text = tb_50.Text.Remove(tb_50.TextLength - 1, 1)
                tb_50.SelectionStart = Len(tb_50.Text)
            End If
        ElseIf current_fp = 7 Then
            If tb_100.TextLength > 0 Then
                tb_100.Text = tb_100.Text.Remove(tb_100.TextLength - 1, 1)
                tb_100.SelectionStart = Len(tb_100.Text)
            End If
        ElseIf current_fp = 8 Then
            If tb_200.TextLength > 0 Then
                tb_200.Text = tb_200.Text.Remove(tb_200.TextLength - 1, 1)
                tb_200.SelectionStart = Len(tb_200.Text)
            End If
        ElseIf current_fp = 9 Then
            If tb_500.TextLength > 0 Then
                tb_500.Text = tb_500.Text.Remove(tb_500.TextLength - 1, 1)
                tb_500.SelectionStart = Len(tb_500.Text)
            End If
        ElseIf current_fp = 10 Then
            If tb_1000.TextLength > 0 Then
                tb_1000.Text = tb_1000.Text.Remove(tb_1000.TextLength - 1, 1)
                tb_1000.SelectionStart = Len(tb_1000.Text)
            End If
        ElseIf current_fp = 11 Then
            If tb_1.TextLength > 0 Then
                tb_1.Text = tb_1.Text.Remove(tb_1.TextLength - 1, 1)
                tb_1.SelectionStart = Len(tb_1.Text)
            End If
        ElseIf current_fp = 12 Then
            If tb_2.TextLength > 0 Then
                tb_2.Text = tb_2.Text.Remove(tb_2.TextLength - 1, 1)
                tb_2.SelectionStart = Len(tb_2.Text)
            End If
        ElseIf current_fp = 13 Then
            If tb_5.TextLength > 0 Then
                tb_5.Text = tb_5.Text.Remove(tb_5.TextLength - 1, 1)
                tb_5.SelectionStart = Len(tb_5.Text)
            End If
        ElseIf current_fp = 14 Then
            If tb_10.TextLength > 0 Then
                tb_10.Text = tb_10.Text.Remove(tb_10.TextLength - 1, 1)
                tb_10.SelectionStart = Len(tb_10.Text)
            End If
        ElseIf current_fp = 15 Then
            If tb_50c.TextLength > 0 Then
                tb_50c.Text = tb_50c.Text.Remove(tb_50c.TextLength - 1, 1)
                tb_50c.SelectionStart = Len(tb_50c.Text)
            End If
        End If
    End Sub

    Private Sub tb_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_efectivo.KeyPress
        e.Handled = txtNumerico(tb_efectivo, e.KeyChar, True)
    End Sub
    Private Sub tb_efectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_efectivo.LostFocus
        If tb_efectivo.TextLength = 0 Then
            tb_efectivo.Text = "0.00"
        End If
    End Sub
    Private Sub tb_1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_1.LostFocus
        If tb_1.TextLength = 0 Then
            tb_1.Text = "0"
        End If
    End Sub
    Private Sub tb_2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_2.LostFocus
        If tb_2.TextLength = 0 Then
            tb_2.Text = "0"
        End If
    End Sub
    Private Sub tb_5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_5.LostFocus
        If tb_5.TextLength = 0 Then
            tb_5.Text = "0"
        End If
    End Sub
    Private Sub tb_10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_10.LostFocus
        If tb_10.TextLength = 0 Then
            tb_10.Text = "0"
        End If
    End Sub
    Private Sub tb_20_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_20.LostFocus
        If tb_20.TextLength = 0 Then
            tb_20.Text = "0"
        End If
    End Sub
    Private Sub tb_50_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_50.LostFocus
        If tb_50.TextLength = 0 Then
            tb_50.Text = "0"
        End If
    End Sub
    Private Sub tb_50c_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_50c.LostFocus
        If tb_50c.TextLength = 0 Then
            tb_50c.Text = "0"
        End If
    End Sub
    Private Sub tb_100_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_100.LostFocus
        If tb_100.TextLength = 0 Then
            tb_100.Text = "0"
        End If
    End Sub
    Private Sub tb_200_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_200.LostFocus
        If tb_200.TextLength = 0 Then
            tb_200.Text = "0"
        End If
    End Sub
    Private Sub tb_500_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_500.LostFocus
        If tb_500.TextLength = 0 Then
            tb_500.Text = "0"
        End If
    End Sub
    Private Sub tb_1000_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_1000.LostFocus
        If tb_1000.TextLength = 0 Then
            tb_1000.Text = "0"
        End If
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If current_fp = 0 Then
            tb_efectivo.Text = "0.00"
        ElseIf current_fp = 5 Then
            tb_20.Text = "0"
        ElseIf current_fp = 6 Then
            tb_50.Text = "0"
        ElseIf current_fp = 7 Then
            tb_100.Text = "0"
        ElseIf current_fp = 8 Then
            tb_200.Text = "0"
        ElseIf current_fp = 9 Then
            tb_500.Text = "0"
        ElseIf current_fp = 10 Then
            tb_1000.Text = "0"
        ElseIf current_fp = 11 Then
            tb_1.Text = "0"
        ElseIf current_fp = 12 Then
            tb_2.Text = "0"
        ElseIf current_fp = 13 Then
            tb_5.Text = "0"
        ElseIf current_fp = 14 Then
            tb_10.Text = "0"
        ElseIf current_fp = 15 Then
            tb_50c.Text = "0"
        End If
        actualizar_colores()
    End Sub
    Private Sub actualizar_colores()
        lb_efectivo.BackColor = Color.White
        btn_1.BackColor = Color.White
        btn_2.BackColor = Color.White
        btn_5.BackColor = Color.White
        btn_10.BackColor = Color.White
        btn_20.BackColor = Color.White
        btn_50.BackColor = Color.White
        btn_100.BackColor = Color.White
        btn_200.BackColor = Color.White
        btn_500.BackColor = Color.White
        btn_1000.BackColor = Color.White
        btn_50c.BackColor = Color.White
        If current_fp = 0 Then
            lb_efectivo.BackColor = Color.GreenYellow
        ElseIf current_fp = 5 Then
            btn_20.BackColor = Color.GreenYellow
        ElseIf current_fp = 6 Then
            btn_50.BackColor = Color.GreenYellow
        ElseIf current_fp = 7 Then
            btn_100.BackColor = Color.GreenYellow
        ElseIf current_fp = 8 Then
            btn_200.BackColor = Color.GreenYellow
        ElseIf current_fp = 9 Then
            btn_500.BackColor = Color.GreenYellow
        ElseIf current_fp = 10 Then
            btn_1000.BackColor = Color.GreenYellow
        ElseIf current_fp = 11 Then
            btn_1.BackColor = Color.GreenYellow
        ElseIf current_fp = 12 Then
            btn_2.BackColor = Color.GreenYellow
        ElseIf current_fp = 13 Then
            btn_5.BackColor = Color.GreenYellow
        ElseIf current_fp = 14 Then
            btn_10.BackColor = Color.GreenYellow
        ElseIf current_fp = 15 Then
            btn_50c.BackColor = Color.GreenYellow
        End If
    End Sub
    Private Sub tb_20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_20.Click, btn_20.Click
        current_fp = 5
        actualizar_colores()
        tb_20.Focus()
        tb_20.SelectAll()
    End Sub

    Private Sub tb_50_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_50.Click, btn_50.Click
        current_fp = 6
        actualizar_colores()
        tb_50.Focus()
        tb_50.SelectAll()
    End Sub

    Private Sub tb_100_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_100.Click, btn_100.Click
        current_fp = 7
        actualizar_colores()
        tb_100.Focus()
        tb_100.SelectAll()
    End Sub
    Private Sub tb_200_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_200.Click, btn_200.Click
        current_fp = 8
        actualizar_colores()
        tb_200.Focus()
        tb_200.SelectAll()
    End Sub
    Private Sub tb_500_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_500.Click, btn_500.Click
        current_fp = 9
        actualizar_colores()
        tb_500.Focus()
        tb_500.SelectAll()
    End Sub
    Private Sub tb_1000_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_1000.Click, btn_1000.Click
        current_fp = 10
        actualizar_colores()
        tb_1000.Focus()
        tb_1000.SelectAll()
    End Sub
    Private Sub tb_1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_1.Click, btn_1.Click
        current_fp = 11
        actualizar_colores()
        tb_1.Focus()
        tb_1.SelectAll()
    End Sub
    Private Sub tb_2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_2.Click, btn_2.Click
        current_fp = 12
        actualizar_colores()
        tb_2.Focus()
        tb_2.SelectAll()
    End Sub
    Private Sub tb_5_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_5.Click, btn_5.Click
        current_fp = 13
        actualizar_colores()
        tb_5.Focus()
        tb_5.SelectAll()
    End Sub
    Private Sub tb_10_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_10.Click, btn_10.Click
        current_fp = 14
        actualizar_colores()
        tb_10.Focus()
        tb_10.SelectAll()
    End Sub
    Private Sub tb_50c_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_50c.Click, btn_50c.Click
        current_fp = 15
        actualizar_colores()
        tb_50c.Focus()
        tb_50c.SelectAll()

    End Sub
    Private Sub tb_20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_20.KeyPress
        e.Handled = txtNumerico(tb_20, e.KeyChar, True)
    End Sub
    Private Sub tb_50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_50.KeyPress
        e.Handled = txtNumerico(tb_50, e.KeyChar, True)
    End Sub
    Private Sub tb_100_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_100.KeyPress
        e.Handled = txtNumerico(tb_100, e.KeyChar, True)
    End Sub
    Private Sub tb_200_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_200.KeyPress
        e.Handled = txtNumerico(tb_200, e.KeyChar, True)
    End Sub
    Private Sub tb_500_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_500.KeyPress
        e.Handled = txtNumerico(tb_500, e.KeyChar, True)
    End Sub
    Private Sub tb_1000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_1000.KeyPress
        e.Handled = txtNumerico(tb_1000, e.KeyChar, True)
    End Sub
    Private Sub tb_1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_1.KeyPress
        e.Handled = txtNumerico(tb_1, e.KeyChar, True)
    End Sub
    Private Sub tb_2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_2.KeyPress
        e.Handled = txtNumerico(tb_2, e.KeyChar, True)
    End Sub
    Private Sub tb_5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_5.KeyPress
        e.Handled = txtNumerico(tb_5, e.KeyChar, True)
    End Sub
    Private Sub tb_10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_10.KeyPress
        e.Handled = txtNumerico(tb_10, e.KeyChar, True)
    End Sub
    Private Sub tb_50c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_50c.KeyPress
        e.Handled = txtNumerico(tb_50c, e.KeyChar, True)
    End Sub
    Private Sub tb_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_1.TextChanged, tb_2.TextChanged, tb_5.TextChanged, tb_10.TextChanged, tb_20.TextChanged, tb_50.TextChanged, tb_100.TextChanged, tb_200.TextChanged, tb_500.TextChanged, tb_1000.TextChanged, tb_50c.TextChanged
        If cargado Then
            actualizar_total_efectivo()
        End If
    End Sub
End Class