Public Class frm_login
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        label2.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_usuario.ForeColor = Color.FromArgb(conf_colores(13))
        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))

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

        delbutton.BackColor = Color.FromArgb(conf_colores(8))
        delbutton.ForeColor = Color.FromArgb(conf_colores(9))

        acbutton.BackColor = Color.FromArgb(conf_colores(8))
        acbutton.ForeColor = Color.FromArgb(conf_colores(9))

        validarbtn.BackColor = Color.FromArgb(conf_colores(8))
        validarbtn.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        If TypeOf sender Is Button Then
            tb_codigo.Focus()
            SendKeys.Send(CType(sender, Button).Text)

        End If
    End Sub

    Private Sub acbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles acbutton.Click
        tb_codigo.Text = ""
    End Sub

    Private Sub delbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delbutton.Click
        If tb_codigo.TextLength > 0 Then
            tb_codigo.Text = tb_codigo.Text.Remove(tb_codigo.TextLength - 1, 1)
            tb_codigo.SelectionStart = Len(tb_codigo.Text)
        End If
        
    End Sub

    Private Sub frm_login_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_login = 0
    End Sub
    Private Sub frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_login = 1
        aplicar_colores()
        lbl_usuario.Text = usuarios(login_index_select, 2)
        tb_codigo.Text = ""
        tb_codigo.Select()
        tb_codigo.Focus()
        lbl_status_dispositivo.Text = frm_usuarios.lbl_status_dispositivo.Text
    End Sub

    Private Sub validarbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles validarbtn.Click
        '--validamos password
        If Trim(tb_codigo.TextLength) <> 0 Then
            Dim pass As String = String.Concat(usuarios(login_index_select, 0), UCase(tb_codigo.Text))
            If MD5(pass) = usuarios(login_index_select, 4) Then
                Me.Hide()
                '---cargamos usuarios_globales
                'matriz usuarios
                '       0     /  1   /    2       /  3   /   4      /      5       /       6        /      7           /       8      /     9         /   10
                '/id_empleado/nombre/nombre_corto/puesto/contraseña/cobro_terminal/pago_proveedores/recepcion-productos/traspasos_env/traspasos_recep/devoluciones
                global_id_empleado = usuarios(login_index_select, 0)
                global_nombre = usuarios(login_index_select, 2)
                global_usuario_nombre = usuarios(login_index_select, 1)
                global_puesto = usuarios(login_index_select, 3)
                global_cobro_terminal = usuarios(login_index_select, 5)
                global_pago_proveedores = usuarios(login_index_select, 6)
                global_recepcion_productos = usuarios(login_index_select, 7)
                global_traspasos_env = usuarios(login_index_select, 8)
                global_traspasos_recep = usuarios(login_index_select, 9)
                global_devoluciones = usuarios(login_index_select, 10)
                global_conversiones = usuarios(login_index_select, 11)
                global_ajuste_inventario = usuarios(login_index_select, 12)
                global_thumb_usuario = usuario_thumb(login_index_select)

                Me.Close()
                frm_usuarios.deshabilitar_captura()
                frm_usuarios.Hide()
                frm_botones_terminal.cargar_usuario_actual(global_id_empleado)
                frm_botones_terminal.Show()
                frm_botones_terminal.BringToFront()

                'If global_cfg_id_pantalla = 0 Then
                'frm_principal.cargar_usuario_actual()
                'frm_principal.Show()
                'Else
                'frm_principal2.cargar_usuario_actual()
                'frm_principal2.Show()
                'End If
            Else
                MsgBox("Codigo Incorrecto", MsgBoxStyle.Critical, "Aviso")
                tb_codigo.Text = ""
            End If
        Else
            MsgBox("Ingrese codigo", MsgBoxStyle.Exclamation, "Aviso")
        End If


    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

End Class