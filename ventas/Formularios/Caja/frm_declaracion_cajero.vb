Public Class frm_declaracion_cajero
    Private current_fp As Integer = 0 '5-billete20,6.-billete5o,7.-Billetede100,8.-billete200,9.-billetede500,10.-billetede1000,11.-1, 12.-2, 13.-5,14.-10
    Private show_efectivo_options As Boolean
    Private show_tarjeta_options As Boolean
    Private cargado As Boolean = False
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        gb_efectivo.ForeColor = Color.FromArgb(conf_colores(2))
        gb_tarjeta.ForeColor = Color.FromArgb(conf_colores(2))
        gb_otras_formas.ForeColor = Color.FromArgb(conf_colores(2))
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
    Private Function calcular_total_tarjeta() As Decimal
        Dim total As Decimal = 0
        If tb_visa.TextLength = 0 Or tb_visa.Text = "." Then
            tb_visa.Text = "0.00"
        End If
        If tb_mc.TextLength = 0 Or tb_mc.Text = "." Then
            tb_mc.Text = "0.00"
        End If
        If tb_ae.TextLength = 0 Or tb_ae.Text = "." Then
            tb_ae.Text = "0.00"
        End If
     
        total = CDec(tb_visa.Text) + CDec(tb_mc.Text) + CDec(tb_ae.Text)
        Return total
    End Function
    Private Sub actualizar_total_efectivo()
        tb_efectivo.Text = calcular_total_efectivo()
    End Sub
    Private Sub actualizar_total_tarjeta()
        tb_tarjeta.Text = calcular_total_tarjeta()
    End Sub

    Private Sub frm_declaracion_cajero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        cargado = False
        current_fp = 0
        actualizar_colores()
        cargado = True
        show_efectivo_options = True
        show_tarjeta_options = False


        tb_efectivo.Text = "0.00"
        tb_tarjeta.Text = "0.00"
        tb_transferencia.Text = "0.00"
        tb_cheque.Text = "0.00"
        tb_nota_credito.Text = "0.00"
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
        tb_visa.Text = "0.00"
        tb_mc.Text = "0.00"
        tb_ae.Text = "0.00"

    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If current_fp = 0 Then
                tb_efectivo.Focus()
            ElseIf current_fp = 1 Then
                tb_tarjeta.Focus()
            ElseIf current_fp = 2 Then
                tb_transferencia.Focus()
            ElseIf current_fp = 3 Then
                tb_cheque.Focus()
            ElseIf current_fp = 4 Then
                tb_nota_credito.Focus()
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
            ElseIf current_fp = 16 Then
                tb_visa.Focus()
            ElseIf current_fp = 17 Then
                tb_mc.Focus()
            ElseIf current_fp = 18 Then
                tb_ae.Focus()
            End If
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub
    Private Sub tb_efectivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_efectivo.Click, lb_efectivo.Click
        current_fp = 0
        actualizar_colores()
        tb_efectivo.Focus()
        If show_efectivo_options = False Then
            efectivo_show_options()
            If show_tarjeta_options Then
                tarjeta_hide_options()
            End If
        Else
            efectivo_hide_options()
        End If
    End Sub

    Private Sub tb_tarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tarjeta.Click, lb_tarjeta.Click
        current_fp = 1
        actualizar_colores()
        tb_tarjeta.Focus()
        If show_tarjeta_options = False Then
            tarjeta_show_options()
            If show_efectivo_options Then
                efectivo_hide_options()
            End If
        Else
            tarjeta_hide_options()
        End If
    End Sub
    Private Sub tb_transferencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_transferencia.Click, lb_transferencia.Click
        current_fp = 2
        actualizar_colores()
        tb_transferencia.Focus()
        tb_transferencia.SelectAll()
        tarjeta_hide_options()
        efectivo_hide_options()

    End Sub
    Private Sub tb_cheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cheque.Click, lb_cheque.Click
        current_fp = 3
        actualizar_colores()
        tb_cheque.Focus()
        tb_cheque.SelectAll()
        tarjeta_hide_options()
        efectivo_hide_options()
    End Sub
    Private Sub tb_nota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_nota_credito.Click, lb_nota_credito.Click
        current_fp = 4
        actualizar_colores()
        tb_nota_credito.Focus()
        tb_nota_credito.SelectAll()
        tarjeta_hide_options()
        efectivo_hide_options()
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
        Me.Dispose()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If MsgBox("Estan correcto los datos?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            body_corte_html = ""
            'body_corte_html = corte_actual_html()
            If tb_efectivo.TextLength = 0 Then
                tb_efectivo.Text = 0
            End If
            If tb_tarjeta.TextLength = 0 Then
                tb_tarjeta.Text = 0
            End If
            If tb_transferencia.TextLength = 0 Then
                tb_transferencia.Text = 0
            End If
            If tb_cheque.TextLength = 0 Then
                tb_cheque.Text = 0
            End If
            If tb_nota_credito.TextLength = 0 Then
                tb_nota_credito.Text = 0
            End If

            'imprimir_corte_caja(tb_efectivo.Text, tb_tarjeta.Text, tb_transferencia.Text, tb_cheque.Text, tb_nota_credito.Text, tb_20.Text, tb_50.Text, tb_100.Text, tb_200.Text, tb_500.Text, tb_1000.Text, tb_1.Text, tb_2.Text, tb_5.Text, tb_10.Text, tb_50c.Text, tb_visa.Text, tb_mc.Text, tb_ae.Text)
           
            '---guardamos el corte y actualizamos la tabla de venta
            Dim total_ventas As Decimal = corte_x()
            Dim total_retiros As Decimal = retiros()
            Dim total_caja As Decimal = saldo_caja()
            'Conectar()
            'conn.Execute("INSERT INTO cortes (fecha,id_empleado_caja,nombre_empleado,total_ventas,total_retiros,total_caja,body_html) VALUES (NOW(), '" & global_id_empleado & "','" & global_nombre & "', '" & total_ventas & "','" & total_retiros & "','" & total_caja & ",'" & body_corte_html & ")")

            '---insertamos nuevo registro de corte
            'Dim rs2 As New ADODB.Recordset
            'rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
            'rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
            'rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
            'rs2.ActiveConnection = conn
            'rs2.Open("select * from cortes")
            'If rs2.RecordCount <> 0 Then
            'rs2.MoveFirst()
            'End If
            'rs2.AddNew()
            'rs2.Fields("fecha").Value = Today.Now()
            'rs2.Fields("id_empleado_caja").Value = global_id_empleado
            'rs2.Fields("nombre_empleado").Value = global_nombre
            'rs2.Fields("total_ventas").Value = total_ventas
            'rs2.Fields("total_retiros").Value = total_retiros
            'rs2.Fields("total_caja").Value = total_caja
            'rs2.Fields("body_html").Value = body_corte_html
            'rs2.Update()
            'rs2.Close()

            conn.Execute("INSERT INTO cortes(fecha,id_empleado_caja,nombre_empleado,total_ventas,total_retiros,total_caja,body_html)VALUES(NOW(),'" & global_id_empleado & "','" & global_nombre & "','" & total_ventas & "','" & total_retiros & "','" & total_caja & "','" & body_corte_html & "')")
            '-----------------
            Dim id_corte As Integer = 0
            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            id_corte = rs.Fields(0).Value
            conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE  id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='CERRADA'")
            conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE  id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='REGALIA'")
            conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE  id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='CANCELADA'")
            conn.Execute("INSERT INTO corte_declaracion(total_efectivo,total_tarjeta,total_transferencia,total_cheque,total_nota,id_corte) VALUES('" & tb_efectivo.Text & "', '" & tb_tarjeta.Text & "', '" & tb_transferencia.Text & "', '" & tb_cheque.Text & "', '" & tb_nota_credito.Text & "','" & rs.Fields(0).Value & "')")
            conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE id_corte='0' AND status='PENDIENTE'")
            conn.Execute("UPDATE pagos_ventas SET id_corte='" & rs.Fields(0).Value & "' WHERE  id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='ACTIVO'")
            conn.Execute("UPDATE pagos_compras SET id_corte='" & rs.Fields(0).Value & "' WHERE id_corte='0' AND id_empleado_pago='" & global_id_empleado & "' AND status='ACTIVO'")
            conn.Execute("INSERT INTO corte_detalle(id_corte,billete_20,billete_50,billete_100,billete_200,billete_500,billete_1000,moneda_1,moneda_2,moneda_5,moneda_10,moneda_50c,tarjeta_visa,tarjeta_master_card,tarjeta_american_express) " & _
                        "VALUES('" & rs.Fields(0).Value & "','" & tb_20.Text & "','" & tb_50.Text & "','" & tb_100.Text & "','" & tb_200.Text & "','" & tb_500.Text & "','" & tb_1000.Text & "','" & tb_1.Text & "','" & tb_2.Text & "','" & tb_5.Text & "','" & tb_10.Text & "','" & tb_50c.Text & "','" & tb_visa.Text & "','" & tb_mc.Text & "','" & tb_ae.Text & "')")
            Dim bandera As Integer = 0
            conn.Execute("UPDATE retiros SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE  bandera_corte_caja='0' AND id_empleado='" & global_id_empleado & "'")
            conn.Execute("UPDATE depositos SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE bandera_corte_caja='0' AND id_empleado_caja='" & global_id_empleado & "'")
            conn.Execute("UPDATE caja_saldo_inicial SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE bandera_corte_caja='0' AND id_empleado='" & global_id_empleado & "'")
            conn.Execute("UPDATE devoluciones SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE bandera_corte_caja='0' AND id_empleado='" & global_id_empleado & "'")

            ' conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='CERRADA'")
            'conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='REGALIA'")
            ' conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='CANCELADA'")
            ' conn.Execute("INSERT INTO corte_declaracion(total_efectivo,total_tarjeta,total_transferencia,total_cheque,total_nota,id_corte) VALUES('" & tb_efectivo.Text & "', '" & tb_tarjeta.Text & "', '" & tb_transferencia.Text & "', '" & tb_cheque.Text & "', '" & tb_nota_credito.Text & "','" & rs.Fields(0).Value & "')")
            ' conn.Execute("UPDATE venta SET id_corte='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND status='PENDIENTE'")
            '  conn.Execute("UPDATE pagos_ventas SET id_corte='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_caja='" & global_id_empleado & "' AND status='ACTIVO'")
            '    conn.Execute("UPDATE pagos_compras SET id_corte='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND id_corte='0' AND id_empleado_pago='" & global_id_empleado & "' AND status='ACTIVO'")
            ' conn.Execute("INSERT INTO corte_detalle(id_corte,billete_20,billete_50,billete_100,billete_200,billete_500,billete_1000,moneda_1,moneda_2,moneda_5,moneda_10,moneda_50c,tarjeta_visa,tarjeta_master_card,tarjeta_american_express) " & _
            '           "VALUES('" & rs.Fields(0).Value & "','" & tb_20.Text & "','" & tb_50.Text & "','" & tb_100.Text & "','" & tb_200.Text & "','" & tb_500.Text & "','" & tb_1000.Text & "','" & tb_1.Text & "','" & tb_2.Text & "','" & tb_5.Text & "','" & tb_10.Text & "','" & tb_50c.Text & "','" & tb_visa.Text & "','" & tb_mc.Text & "','" & tb_ae.Text & "')")
            ' Dim bandera As Integer = 0
            ' conn.Execute("UPDATE retiros SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND bandera_corte_caja='0' AND id_empleado='" & global_id_empleado & "'")
            '  conn.Execute("UPDATE depositos SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND bandera_corte_caja='0' AND id_empleado_caja='" & global_id_empleado & "'")
            '  conn.Execute("UPDATE caja_saldo_inicial SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND bandera_corte_caja='0' AND id_empleado='" & global_id_empleado & "'")
            '  conn.Execute("UPDATE devoluciones SET bandera_corte_caja='" & rs.Fields(0).Value & "' WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND bandera_corte_caja='0' AND id_empleado='" & global_id_empleado & "'")



            rs.Close()

            If conf_pv(6) = 1 Then
                enviar_corte_email(id_corte)
            End If

            '-------------------------------------------------------
            Me.Close()

            frm_corte_x.ShowDialog()
            'If global_cfg_id_pantalla = 0 Then
            'frm_principal.Hide()
            ' Else
            '  frm_principal2.Hide()
            ' End If

            'frm_usuarios.Show()
            'frm_usuarios.BringToFront()
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If current_fp = 0 Then
            If tb_efectivo.TextLength > 0 Then
                tb_efectivo.Text = tb_efectivo.Text.Remove(tb_efectivo.TextLength - 1, 1)
                tb_efectivo.SelectionStart = Len(tb_efectivo.Text)
            End If
        ElseIf current_fp = 1 Then
            If tb_tarjeta.TextLength > 0 Then
                tb_tarjeta.Text = tb_tarjeta.Text.Remove(tb_tarjeta.TextLength - 1, 1)
                tb_tarjeta.SelectionStart = Len(tb_tarjeta.Text)
            End If
        ElseIf current_fp = 2 Then
            If tb_transferencia.TextLength > 0 Then
                tb_transferencia.Text = tb_transferencia.Text.Remove(tb_transferencia.TextLength - 1, 1)
                tb_transferencia.SelectionStart = Len(tb_transferencia.Text)
            End If
        ElseIf current_fp = 3 Then
            If tb_cheque.TextLength > 0 Then
                tb_cheque.Text = tb_cheque.Text.Remove(tb_cheque.TextLength - 1, 1)
                tb_cheque.SelectionStart = Len(tb_cheque.Text)
            End If
        ElseIf current_fp = 4 Then
            If tb_nota_credito.TextLength > 0 Then
                tb_nota_credito.Text = tb_nota_credito.Text.Remove(tb_nota_credito.TextLength - 1, 1)
                tb_nota_credito.SelectionStart = Len(tb_nota_credito.Text)
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
        ElseIf current_fp = 16 Then
            If tb_visa.TextLength > 0 Then
                tb_visa.Text = tb_visa.Text.Remove(tb_visa.TextLength - 1, 1)
                tb_visa.SelectionStart = Len(tb_visa.Text)
            End If
        ElseIf current_fp = 17 Then
            If tb_mc.TextLength > 0 Then
                tb_mc.Text = tb_mc.Text.Remove(tb_mc.TextLength - 1, 1)
                tb_mc.SelectionStart = Len(tb_mc.Text)
            End If
        ElseIf current_fp = 18 Then
            If tb_ae.TextLength > 0 Then
                tb_ae.Text = tb_ae.Text.Remove(tb_ae.TextLength - 1, 1)
                tb_ae.SelectionStart = Len(tb_ae.Text)
            End If
        End If
    End Sub

    Private Sub tb_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_efectivo.KeyPress
        e.Handled = txtNumerico(tb_efectivo, e.KeyChar, True)
    End Sub
    Private Sub tb_tarjerta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_tarjeta.KeyPress
        e.Handled = txtNumerico(tb_tarjeta, e.KeyChar, True)
    End Sub
    Private Sub tb_transferencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_transferencia.KeyPress
        e.Handled = txtNumerico(tb_transferencia, e.KeyChar, True)
    End Sub
    Private Sub tb_cheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cheque.KeyPress
        e.Handled = txtNumerico(tb_cheque, e.KeyChar, True)
    End Sub
    Private Sub tb_nota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_nota_credito.KeyPress
        e.Handled = txtNumerico(tb_nota_credito, e.KeyChar, True)
    End Sub

    Private Sub tb_efectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_efectivo.LostFocus
        If tb_efectivo.TextLength = 0 Then
            tb_efectivo.Text = "0.00"
        End If
    End Sub
    Private Sub tb_tarjeta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_tarjeta.LostFocus
        If tb_tarjeta.TextLength = 0 Then
            tb_tarjeta.Text = "0.00"
        End If
    End Sub
    Private Sub tb_transferencia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_transferencia.LostFocus
        If tb_transferencia.TextLength = 0 Then
            tb_transferencia.Text = "0.00"
        End If
    End Sub
    Private Sub tb_cheque_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cheque.LostFocus
        If tb_cheque.TextLength = 0 Then
            tb_cheque.Text = "0.00"
        End If
    End Sub
    Private Sub tb_nota_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_nota_credito.LostFocus
        If tb_nota_credito.TextLength = 0 Then
            tb_nota_credito.Text = "0.00"
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
    Private Sub tb_visa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_visa.LostFocus
        If tb_visa.TextLength = 0 Then
            tb_visa.Text = "0.00"
        End If
    End Sub
    Private Sub tb_mc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_mc.LostFocus
        If tb_mc.TextLength = 0 Then
            tb_mc.Text = "0.00"
        End If
    End Sub
    Private Sub tb_ae_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_ae.LostFocus
        If tb_ae.TextLength = 0 Then
            tb_ae.Text = "0.00"
        End If
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If current_fp = 0 Then
            tb_efectivo.Text = "0.00"
        ElseIf current_fp = 1 Then
            tb_tarjeta.Text = "0.00"
        ElseIf current_fp = 2 Then
            tb_transferencia.Text = "0.00"
        ElseIf current_fp = 3 Then
            tb_cheque.Text = "0.00"
        ElseIf current_fp = 4 Then
            tb_nota_credito.Text = "0.00"
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
        ElseIf current_fp = 16 Then
            tb_visa.Text = "0.00"
        ElseIf current_fp = 17 Then
            tb_mc.Text = "0.00"
        ElseIf current_fp = 18 Then
            tb_ae.Text = "0.00"
        End If
        actualizar_colores()
    End Sub
    Private Sub actualizar_colores()
        lb_efectivo.BackColor = Color.White
        lb_tarjeta.BackColor = Color.White
        lb_transferencia.BackColor = Color.White
        lb_cheque.BackColor = Color.White
        lb_nota_credito.BackColor = Color.White
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
        ElseIf current_fp = 1 Then
            lb_tarjeta.BackColor = Color.GreenYellow
        ElseIf current_fp = 2 Then
            lb_transferencia.BackColor = Color.GreenYellow
        ElseIf current_fp = 3 Then
            lb_cheque.BackColor = Color.GreenYellow
        ElseIf current_fp = 4 Then
            lb_nota_credito.BackColor = Color.GreenYellow
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
    Private Sub efectivo_show_options()
        gb_efectivo.Size = New Size(457, 363)
        show_efectivo_options = True
    End Sub
    Private Sub efectivo_hide_options()
        gb_efectivo.Size = New Size(457, 66)
        show_efectivo_options = False
    End Sub
    Private Sub tarjeta_show_options()
        gb_tarjeta.Size = New Size(457, 194)
        show_tarjeta_options = True
    End Sub
    Private Sub tarjeta_hide_options()
        gb_tarjeta.Size = New Size(457, 66)
        show_tarjeta_options = False
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
    Private Sub tb_visa_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_visa.Click, btn_visa.Click
        current_fp = 16
        actualizar_colores()
        tb_visa.Focus()
        tb_visa.SelectAll()
    End Sub
    Private Sub tb_mc_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_mc.Click, btn_mc.Click
        current_fp = 17
        actualizar_colores()
        tb_mc.Focus()
        tb_mc.SelectAll()
    End Sub
    Private Sub tb_ae_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_ae.Click, btn_ae.Click
        current_fp = 18
        actualizar_colores()
        tb_ae.Focus()
        tb_ae.SelectAll()
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
    Private Sub tb_10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_10.KeyPress, tb_ae.KeyPress, tb_mc.KeyPress, tb_visa.KeyPress
        e.Handled = txtNumerico(tb_10, e.KeyChar, True)
    End Sub
    Private Sub tb_50c_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_50c.KeyPress
        e.Handled = txtNumerico(tb_50c, e.KeyChar, True)
    End Sub
    Private Sub tb_visa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_visa.KeyPress
        e.Handled = txtNumerico(tb_visa, e.KeyChar, True)
    End Sub
    Private Sub tb_mc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_mc.KeyPress
        e.Handled = txtNumerico(tb_mc, e.KeyChar, True)
    End Sub
    Private Sub tb_ae_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_ae.KeyPress
        e.Handled = txtNumerico(tb_ae, e.KeyChar, True)
    End Sub
    Private Sub tb_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_1.TextChanged, tb_2.TextChanged, tb_5.TextChanged, tb_10.TextChanged, tb_20.TextChanged, tb_50.TextChanged, tb_100.TextChanged, tb_200.TextChanged, tb_500.TextChanged, tb_1000.TextChanged, tb_50c.TextChanged, tb_visa.TextChanged, tb_mc.TextChanged, tb_ae.TextChanged
        If cargado Then
            actualizar_total_efectivo()
        End If
    End Sub
    Private Sub tb_tarjeta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_visa.TextChanged, tb_mc.TextChanged, tb_ae.TextChanged
        If cargado Then
            actualizar_total_tarjeta()
        End If
    End Sub

End Class