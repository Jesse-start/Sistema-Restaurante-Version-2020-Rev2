Public Class frm_retiros_deposito
    Dim active_cantidad As Boolean = True
    Dim active_descripcion As Boolean = False
    Public tipo_movimiento As Integer = 0 '0 retiro - 1 deposito
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))
        Button2.BackColor = Color.FromArgb(conf_colores(8))
        Button2.ForeColor = Color.FromArgb(conf_colores(9))
        Button3.BackColor = Color.FromArgb(conf_colores(8))
        Button3.ForeColor = Color.FromArgb(conf_colores(9))
        Button4.BackColor = Color.FromArgb(conf_colores(8))
        Button4.ForeColor = Color.FromArgb(conf_colores(9))
        Button5.BackColor = Color.FromArgb(conf_colores(8))
        Button5.ForeColor = Color.FromArgb(conf_colores(9))
        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
        Button7.BackColor = Color.FromArgb(conf_colores(8))
        Button7.ForeColor = Color.FromArgb(conf_colores(9))
        Button8.BackColor = Color.FromArgb(conf_colores(8))
        Button8.ForeColor = Color.FromArgb(conf_colores(9))
        Button9.BackColor = Color.FromArgb(conf_colores(8))
        Button9.ForeColor = Color.FromArgb(conf_colores(9))
        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))
        Button11.BackColor = Color.FromArgb(conf_colores(8))
        Button11.ForeColor = Color.FromArgb(conf_colores(9))
        Button12.BackColor = Color.FromArgb(conf_colores(8))
        Button12.ForeColor = Color.FromArgb(conf_colores(9))
        Button13.BackColor = Color.FromArgb(conf_colores(8))
        Button13.ForeColor = Color.FromArgb(conf_colores(9))
        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))
        Button15.BackColor = Color.FromArgb(conf_colores(8))
        Button15.ForeColor = Color.FromArgb(conf_colores(9))
        Button16.BackColor = Color.FromArgb(conf_colores(8))
        Button16.ForeColor = Color.FromArgb(conf_colores(9))
        Button17.BackColor = Color.FromArgb(conf_colores(8))
        Button17.ForeColor = Color.FromArgb(conf_colores(9))
        Button18.BackColor = Color.FromArgb(conf_colores(8))
        Button18.ForeColor = Color.FromArgb(conf_colores(9))
        Button19.BackColor = Color.FromArgb(conf_colores(8))
        Button19.ForeColor = Color.FromArgb(conf_colores(9))
        Button20.BackColor = Color.FromArgb(conf_colores(8))
        Button20.ForeColor = Color.FromArgb(conf_colores(9))
        Button21.BackColor = Color.FromArgb(conf_colores(8))
        Button21.ForeColor = Color.FromArgb(conf_colores(9))
        Button22.BackColor = Color.FromArgb(conf_colores(8))
        Button22.ForeColor = Color.FromArgb(conf_colores(9))
        Button23.BackColor = Color.FromArgb(conf_colores(8))
        Button23.ForeColor = Color.FromArgb(conf_colores(9))
        Button25.BackColor = Color.FromArgb(conf_colores(8))
        Button25.ForeColor = Color.FromArgb(conf_colores(9))
        Button26.BackColor = Color.FromArgb(conf_colores(8))
        Button26.ForeColor = Color.FromArgb(conf_colores(9))
        Button27.BackColor = Color.FromArgb(conf_colores(8))
        Button27.ForeColor = Color.FromArgb(conf_colores(9))
        Button28.BackColor = Color.FromArgb(conf_colores(8))
        Button28.ForeColor = Color.FromArgb(conf_colores(9))
        Button29.BackColor = Color.FromArgb(conf_colores(8))
        Button29.ForeColor = Color.FromArgb(conf_colores(9))
        Button30.BackColor = Color.FromArgb(conf_colores(8))
        Button30.ForeColor = Color.FromArgb(conf_colores(9))
        Button31.BackColor = Color.FromArgb(conf_colores(8))
        Button31.ForeColor = Color.FromArgb(conf_colores(9))
        Button33.BackColor = Color.FromArgb(conf_colores(8))
        Button33.ForeColor = Color.FromArgb(conf_colores(9))
        Button32.BackColor = Color.FromArgb(conf_colores(8))
        Button32.ForeColor = Color.FromArgb(conf_colores(9))
        Button34.BackColor = Color.FromArgb(conf_colores(8))
        Button34.ForeColor = Color.FromArgb(conf_colores(9))
        Button35.BackColor = Color.FromArgb(conf_colores(8))
        Button35.ForeColor = Color.FromArgb(conf_colores(9))
        Button36.BackColor = Color.FromArgb(conf_colores(8))
        Button36.ForeColor = Color.FromArgb(conf_colores(9))
        Button37.BackColor = Color.FromArgb(conf_colores(8))
        Button37.ForeColor = Color.FromArgb(conf_colores(9))
        Button38.BackColor = Color.FromArgb(conf_colores(8))
        Button38.ForeColor = Color.FromArgb(conf_colores(9))
        Button39.BackColor = Color.FromArgb(conf_colores(8))
        Button39.ForeColor = Color.FromArgb(conf_colores(9))
        Button40.BackColor = Color.FromArgb(conf_colores(8))
        Button40.ForeColor = Color.FromArgb(conf_colores(9))
        Button41.BackColor = Color.FromArgb(conf_colores(8))
        Button41.ForeColor = Color.FromArgb(conf_colores(9))
        Button42.BackColor = Color.FromArgb(conf_colores(8))
        Button42.ForeColor = Color.FromArgb(conf_colores(9))
        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_barra.BackColor = Color.FromArgb(conf_colores(8))
        btn_barra.ForeColor = Color.FromArgb(conf_colores(9))
        btn_clear.BackColor = Color.FromArgb(conf_colores(8))
        btn_clear.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button23.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, btn_barra.Click, Button33.Click
        If TypeOf sender Is Button Then
            If active_cantidad = True Then
                tb_cantidad.Focus()
            Else
                tb_descripcion.Focus()
            End If

            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub frm_retiros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        tb_cantidad.Select()
        tb_cantidad.Focus()
        If tipo_movimiento = 0 Then
            Me.Text = "Retiro de Caja"
            lbl_tipo_movimiento.Text = "Retiro de Caja"
        Else
            Me.Text = "Deposito en Caja"
            lbl_tipo_movimiento.Text = "Deposito en Caja"
        End If
    End Sub

    Private Sub tb_cantidad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cantidad.Click
        active_cantidad = True
        active_descripcion = False
        tb_cantidad.SelectAll()
        tb_cantidad.Focus()
    End Sub

    Private Sub tb_descripcion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_descripcion.Click
        active_cantidad = False
        active_descripcion = True
        tb_descripcion.SelectAll()
        tb_descripcion.Focus()
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click
        If TypeOf sender Is Button Then
            If active_cantidad = True Then
                tb_cantidad.Focus()
            Else
                tb_descripcion.Focus()
            End If

            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        If active_cantidad = True Then
            If tb_cantidad.TextLength > 0 Then
                tb_cantidad.Text = tb_cantidad.Text.Remove(tb_cantidad.TextLength - 1, 1)
                tb_cantidad.SelectionStart = Len(tb_cantidad.Text)
            End If
        Else
            If tb_descripcion.TextLength > 0 Then
                tb_descripcion.Text = tb_descripcion.Text.Remove(tb_descripcion.TextLength - 1, 1)
                tb_descripcion.SelectionStart = Len(tb_descripcion.Text)
            End If
        End If

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If active_cantidad = True Then
            tb_cantidad.Text = ""
        Else
            tb_descripcion.Text = ""
        End If
    End Sub

    Private Sub tb_cantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cantidad.KeyPress
        e.Handled = txtNumerico(tb_cantidad, e.KeyChar, True)
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click

        Dim correcto As Boolean = True

        Dim cadena As String = "Se encontraron lo siguientes errores" & vbCrLf

        If Trim(tb_descripcion.TextLength) = 0 Then
            cadena = cadena & "   *Debe escribir el concepto"
            correcto = False
        End If

        If Trim(tb_cantidad.TextLength) = 0 Then
            cadena = cadena & "   *Debe escribir la cantidad"
            correcto = False
        End If

        If correcto Then
            If tipo_movimiento = 0 Then
                Dim saldo_inicial As Decimal = 0
                Dim total_ventas As Decimal = total_efectivo()
                Dim total_retiros As Decimal = retiros()
                Dim total_depositos As Decimal = depositos()
                Dim saldo_caja As Decimal = 0
                Dim total_devoluciones As Decimal = devoluciones()
                If tb_cantidad.Text <> 0 Then
                    'Conectar()
                    rs.Open("SELECT saldo_inicial from caja_saldo_inicial WHERE id_empleado='" & global_id_empleado & "' AND date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND bandera_corte_caja=0", conn)
                    If rs.RecordCount > 0 Then
                        saldo_inicial = rs.Fields("saldo_inicial").Value
                    End If
                    rs.Close()
                    'conn.close()
                    'conn = Nothing
                    saldo_caja = saldo_inicial + total_ventas + total_depositos - total_retiros - total_devoluciones

                    If CDec(tb_cantidad.Text) <= saldo_caja Then
                        If MsgBox("Confirme que desea retirar " & FormatCurrency(tb_cantidad.Text), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                            'Conectar()
                            conn.Execute("INSERT INTO retiros(fecha,cantidad,descripcion,id_empleado,id_sucursal) VALUES(NOW(),'" & CDec(tb_cantidad.Text) & "','" & tb_descripcion.Text & "', '" & global_id_empleado & "', '" & global_id_sucursal & "')")
                            'conn.close()
                            'conn = Nothing
                            Dim x As Integer
                            If MsgBox("A continuación se imprimirá el ticket de retiro de efectivo. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                                For x = 0 To 1
                                    If conf_pv(21) = 0 Then
                                        imprimir_recibo_retiro_termica(global_usuario_nombre, CDec(tb_cantidad.Text), tb_descripcion.Text, x)
                                    Else
                                        imprimir_recibo_retiro_matriz(global_usuario_nombre, CDec(tb_cantidad.Text), tb_descripcion.Text, x)
                                    End If

                                Next
                            Else
                                If conf_pv(21) = 0 Then
                                    imprimir_recibo_retiro_termica(global_usuario_nombre, CDec(tb_cantidad.Text), tb_descripcion.Text, 0)
                                Else
                                    imprimir_recibo_retiro_matriz(global_usuario_nombre, CDec(tb_cantidad.Text), tb_descripcion.Text, 0)
                                End If
                            End If

                            MsgBox("Retiro guardado correctamente", MsgBoxStyle.Information, "Correcto")
                            Me.Close()
                        End If
                    Else
                        MsgBox("No se puede retirar esta cantidad,Excede el saldo actual ", MsgBoxStyle.Exclamation, "Aviso")
                    End If
                Else
                    MsgBox("Escriba la cantidad a retirar", MsgBoxStyle.Exclamation, "Aviso")
                End If
            Else
                If MsgBox("Confirme que desea depositar " & FormatCurrency(tb_cantidad.Text), MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    'Conectar()
                    conn.Execute("INSERT INTO depositos(fecha,importe,descripcion,id_empleado_caja,id_sucursal) VALUES(NOW(),'" & CDec(tb_cantidad.Text) & "','" & tb_descripcion.Text & "', '" & global_id_empleado & "', '" & global_id_sucursal & "')")
                    'conn.close()
                    'conn = Nothing
                    Dim id_deposito As Integer = 0
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_deposito = rs.Fields(0).Value
                    rs.Close()

                    Dim x As Integer
                    If MsgBox("A continuación se imprimirá el ticket de deposito de efectivo. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        For x = 0 To 1

                            If conf_pv(21) = 0 Then
                                imprimir_deposito_caja_termica(id_deposito, x)
                            Else
                                imprimir_deposito_caja_matriz(id_deposito, x)
                            End If

                        Next
                    Else
                        If conf_pv(21) = 0 Then
                            imprimir_deposito_caja_termica(id_deposito, x)
                        Else
                            imprimir_deposito_caja_matriz(id_deposito, x)
                        End If
                    End If

                    MsgBox("Deposito guardado correctamente", MsgBoxStyle.Information, "Correcto")
                    Me.Close()
                End If
            End If
        Else
            MsgBox(cadena, MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class