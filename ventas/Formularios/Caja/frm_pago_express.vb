Public Class frm_pago_express
    Dim show_tarjeta_option As Boolean = False
    Public pe_id_venta As Integer
    Public pe_importe_venta As Decimal
    Public pe_subtotal As Decimal = 0
    Public pe_total_impuestos As Decimal = 0
    Public pe_cliente As String = ""
    Public pe_cliente_alias As String = ""
    Public pe_empleado As String = ""
    Dim current_fp As Integer = 0
    Dim deuda_efectivo As Decimal = 0
    Dim efectivo As Decimal = pe_importe_venta
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        FlowLayoutPanel1.BackColor = Color.FromArgb(conf_colores(1))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label6.ForeColor = Color.FromArgb(conf_colores(13))
        Label7.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        Label9.ForeColor = Color.FromArgb(conf_colores(13))
        Label10.ForeColor = Color.FromArgb(conf_colores(13))
        Label11.ForeColor = Color.FromArgb(conf_colores(13))

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

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

        btn_cobrar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cobrar.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub


    Private Sub show_options()
        gb_tarjeta.Size = New Size(462, 100)
        show_tarjeta_option = True
    End Sub
    Private Sub hide_options()
        gb_tarjeta.Size = New Size(462, 59)
        show_tarjeta_option = False
    End Sub
    Private Sub tb_importe_tarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_tarjeta.Click
        tb_importe_tarjeta.SelectAll()
        current_fp = 1
        If show_tarjeta_option = False Then
            show_options()
        Else
            hide_options()
        End If
    End Sub

    Private Sub frm_pago_express_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frm_caja.obtener_cuentasxcobrar()
        If frm_caja.tabla_caja.Rows.Count = 0 Then
            frm_caja.Close()
            frm_principal3.BringToFront()
        End If
    End Sub
    Private Sub conf_inicio()
        'current_fp = 0
        hide_options()
        'pe_subtotal = 0
        ' = 0
        'pe_total_otros = 0
        'pe_cliente = ""
        'pe_cliente_alias = ""
        'pe_empleado = ""
        'deuda_efectivo = 0
        'pb_efectivo.Visible = False
        'pb_tarjeta.Visible = False
        'pb_cupones.Visible = False
        'pb_cambio.Visible = False
    End Sub
    Private Sub frm_pago_express_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tb_importe_tarjeta.Text = "0.00"
        tb_importe_cupones.Text = "0.00"
        tb_cambio.Text = "0.00"
        aplicar_colores()
        conf_inicio()
        llenar_bancos()
        tb_importe_efectivo.Text = pe_importe_venta
        deuda_efectivo = pe_importe_venta
        tb_importe_total.Text = pe_importe_venta
        tb_referencia.Text = ""
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If current_fp = 0 Then
                tb_importe_efectivo.Focus()
            ElseIf current_fp = 1 Then
                tb_importe_tarjeta.Focus()
            ElseIf current_fp = 2 Then
                tb_importe_cupones.Focus()
            ElseIf current_fp = 3 Then
                tb_referencia.Focus()
            End If
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub tb_importe_efectivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_efectivo.Click
        tb_importe_efectivo.SelectAll()
        current_fp = 0
        hide_options()
    End Sub
    Private Sub tb_importe_cupones_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_cupones.Click
        tb_importe_cupones.SelectAll()
        current_fp = 2
        hide_options()
    End Sub

    Private Sub tb_referencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_referencia.Click
        tb_referencia.SelectAll()
        current_fp = 3
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If current_fp = 0 Then
            If tb_importe_efectivo.TextLength > 0 Then
                tb_importe_efectivo.Text = tb_importe_efectivo.Text.Remove(tb_importe_efectivo.TextLength - 1, 1)
                tb_importe_efectivo.SelectionStart = Len(tb_importe_efectivo.Text)
            End If
        ElseIf current_fp = 1 Then
            If tb_importe_tarjeta.TextLength > 0 Then
                tb_importe_tarjeta.Text = tb_importe_tarjeta.Text.Remove(tb_importe_tarjeta.TextLength - 1, 1)
                tb_importe_tarjeta.SelectionStart = Len(tb_importe_tarjeta.Text)
            End If
        ElseIf current_fp = 2 Then
            If tb_importe_cupones.TextLength > 0 Then
                tb_importe_cupones.Text = tb_importe_cupones.Text.Remove(tb_importe_cupones.TextLength - 1, 1)
                tb_importe_cupones.SelectionStart = Len(tb_importe_cupones.Text)
            End If
        ElseIf current_fp = 3 Then
            If tb_referencia.TextLength > 0 Then
                tb_referencia.Text = tb_referencia.Text.Remove(tb_referencia.TextLength - 1, 1)
                tb_referencia.SelectionStart = Len(tb_referencia.Text)
            End If
        End If
    End Sub

    Private Sub tb_referencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_referencia.TextChanged
        If show_tarjeta_option = False Then
            show_options()
        End If
    End Sub

    Private Sub tb_importe_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_importe_efectivo.KeyPress
        e.Handled = txtNumerico(tb_importe_efectivo, e.KeyChar, True)
    End Sub

    Private Sub tb_importe_efectivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_efectivo.LostFocus
        If tb_importe_efectivo.TextLength = 0 Then
            tb_importe_efectivo.Text = "0.00"
        End If
    End Sub

    Private Sub tb_importe_cupones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_importe_cupones.KeyPress
        e.Handled = txtNumerico(tb_importe_cupones, e.KeyChar, True)
    End Sub

    Private Sub tb_importe_cupones_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_cupones.LostFocus
        If tb_importe_cupones.TextLength = 0 Then
            tb_importe_cupones.Text = "0.00"
        End If
    End Sub

    Private Sub tb_importe_tarjeta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_importe_tarjeta.KeyPress
        e.Handled = txtNumerico(tb_importe_tarjeta, e.KeyChar, True)
    End Sub

    Private Sub tb_importe_tarjeta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_tarjeta.LostFocus
        If tb_importe_tarjeta.TextLength = 0 Then
            tb_importe_tarjeta.Text = "0.00"
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If current_fp = 0 Then
            tb_importe_efectivo.Text = "0.00"
        ElseIf current_fp = 1 Then
            tb_importe_tarjeta.Text = "0.00"
        ElseIf current_fp = 2 Then
            tb_importe_cupones.Text = "0.00"
        ElseIf current_fp = 3 Then
            tb_referencia.Text = ""
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub ajustar_formas(ByVal currentindex As Integer)
        Try
            If tb_importe_efectivo.TextLength = 0 Then
                tb_importe_efectivo.Text = "0.00"
            End If
            If tb_importe_tarjeta.TextLength = 0 Then
                tb_importe_tarjeta.Text = "0.00"
            End If
            If tb_importe_cupones.TextLength = 0 Then
                tb_importe_cupones.Text = "0.00"
            End If

            If currentindex = 0 Then
                'ajustamos para pago ebn efectivo
                Dim cambio As Decimal = CDec(tb_importe_efectivo.Text) - (pe_importe_venta - (CDec(tb_importe_tarjeta.Text) + CDec(tb_importe_cupones.Text)))
                tb_cambio.Text = cambio
                '--------------------------------
            Else
                efectivo = pe_importe_venta - (CDec(tb_importe_tarjeta.Text) + CDec(tb_importe_cupones.Text))
                tb_importe_efectivo.Text = efectivo
                deuda_efectivo = efectivo
            End If
            Dim suma As Decimal = CDec(tb_importe_tarjeta.Text) + CDec(tb_importe_cupones.Text)
            If CDec(tb_importe_tarjeta.Text) > pe_importe_venta Then
                tb_importe_tarjeta.Text = "0.00"
                MsgBox("El importe de la tarjeta no puede ser mayor al importe de la venta", MsgBoxStyle.Exclamation, "error")
                deuda_efectivo = pe_importe_venta
                efectivo = pe_importe_venta
            End If

            If CDec(tb_importe_cupones.Text) > pe_importe_venta Then
                tb_importe_cupones.Text = "0.00"
                MsgBox("El importe de los cupones no puede ser mayor al importe de la venta", MsgBoxStyle.Exclamation, "error")
                deuda_efectivo = pe_importe_venta
                efectivo = pe_importe_venta
            End If

            If suma > pe_importe_venta Then
                tb_importe_cupones.Text = "0.00"
                tb_importe_tarjeta.Text = "0.00"
                MsgBox("El importe de la tarjeta y cupones no puede ser mayor al importe de la venta", MsgBoxStyle.Exclamation, "error")
                deuda_efectivo = pe_importe_venta
                efectivo = pe_importe_venta
            End If
            actualizar_icono(tb_importe_efectivo.Text, pb_efectivo)
            actualizar_icono(tb_importe_tarjeta.Text, pb_tarjeta)
            actualizar_icono(tb_importe_cupones.Text, pb_cupones)
            If tb_cambio.Text = "" Then
                tb_cambio.Text = "0.00"
            End If
            actualizar_icono(tb_cambio.Text, pb_cambio)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Errorr")
        End Try

    End Sub
    Private Sub actualizar_icono(ByVal valor As Decimal, ByVal pb As PictureBox)

        pb.Visible = False
        pb.Image = ventas.My.Resources._50CENTAVOS
        If valor > 0 Then
            pb.Image = ventas.My.Resources._50CENTAVOS
            pb.Visible = True
        ElseIf valor < 0 Then
            pb.Image = ventas.My.Resources._50CENTAVOS
            pb.Visible = True
        End If
    End Sub

    Private Sub tb_importe_tarjeta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_importe_tarjeta.TextChanged
        If tb_importe_tarjeta.TextLength > 0 Then
            ajustar_formas(1)
        End If
    End Sub

    Private Sub tb_importe_cupones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_importe_cupones.TextChanged
        If tb_importe_cupones.TextLength > 0 Then
            ajustar_formas(2)
        End If
    End Sub

    Private Sub tb_importe_efectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_importe_efectivo.TextChanged
        If tb_importe_tarjeta.TextLength > 0 Then
            ajustar_formas(0)
        End If
    End Sub

    Private Sub btn_cobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cobrar.Click
        Dim suma As Decimal = CDec(tb_importe_efectivo.Text) + CDec(tb_importe_tarjeta.Text) + CDec(tb_importe_cupones.Text)
        Dim correcto As Boolean = True
        Dim cadena As String = "Se encontraron los siguiente errores: " & vbCrLf
        If suma < pe_importe_venta Then
            cadena += "El total de los pagos es menor al importe de la venta" & vbCrLf
            correcto = False
        End If
        If CDec(tb_importe_tarjeta.Text) > 0 Then
            If cb_bancos.SelectedIndex = -1 Then
                cadena += "Seleccione el banco de la tarjeta" & vbCrLf
                correcto = False
            End If
            If Trim(tb_referencia.TextLength) = 0 Then
                cadena += "No ha ingresado la referencia" & vbCrLf
                correcto = False
            End If
        End If
        If correcto Then
            Dim forma_pago As String = ""
            If CDec(tb_importe_efectivo.Text) > 0 Then
                forma_pago += " Efectivo"
                '---agregamos el registro de efectivo
                'Conectar()
                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,cobro,cambio,id_forma_pago,fecha,fecha_cobro,id_empleado_caja) VALUES " & _
                                    " (" & pe_id_venta & ",'" & CDec(deuda_efectivo) & "','" & CDec(tb_importe_efectivo.Text) & "','" & CDec(tb_cambio.Text) & "','0',NOW(),NOW(),'" & global_id_empleado & "')", , -1)
                'conn.close()
                'conn = Nothing
                '-------------------------------------
            End If
            If CDec(tb_importe_tarjeta.Text) > 0 Then
                forma_pago += " Tarjeta"
                '-----agregamos el registro de tarjeta
                'Conectar()
                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,banco_cliente,num_tarjeta,id_empleado_caja) VALUES " & _
               " (" & pe_id_venta & ",'" & CDec(tb_importe_tarjeta.Text) & "','4',NOW(),NOW(),'" & cb_bancos.Text & "','" & tb_referencia.Text & "','" & global_id_empleado & "')", , -1)
                'conn.close()
                'conn = Nothing
                '------------------------------------
            End If
            If CDec(tb_importe_cupones.Text) > 0 Then
                forma_pago += " Cupones"
                '-------agregamos el registro de  cupones
                'Conectar()
                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,id_empleado_caja) VALUES " & _
                                    " (" & pe_id_venta & ",'" & CDec(tb_importe_cupones.Text) & "','5',NOW(),NOW(),'" & global_id_empleado & "')", , -1)
                'conn.close()
                'conn = Nothing
                '----------------------------------------
            End If
            'Conectar()
            conn.Execute("UPDATE venta  SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "'  WHERE id_venta = " & pe_id_venta)
            'conn.close()

            Dim k As Integer
            For k = 0 To conf_pv(5)


                rs.Open("SELECT subtotal,total_impuestos FROM venta WHERE id_venta=''", conn)
                If rs.RecordCount > 0 Then
                    pe_subtotal = rs.Fields("subtotal").Value
                    pe_total_impuestos = rs.Fields("total_impuestos").Value
                End If
                rs.Close()

                imprimir_ticket_venta(pe_id_venta, pe_cliente, pe_cliente_alias, pe_id_venta, pe_subtotal, pe_total_impuestos, pe_importe_venta, FormatCurrency(tb_importe_efectivo.Text), FormatCurrency(tb_cambio.Text), pe_empleado, forma_pago, k, conf_pv(5), True, deuda_efectivo, CDec(tb_importe_tarjeta.Text), CDec(tb_importe_cupones.Text))
            Next
            Me.Close()
        Else
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Sub llenar_bancos()
        cb_bancos.Items.Clear()
        cb_bancos.Text = ""
        'Conectar()
        rs.Open("SELECT * FROM banco Order By descripcion", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_bancos.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub tb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_importe_total.Click, tb_cambio.Click

    End Sub

    Private Sub gb_tipo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_tipo.Enter

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click

    End Sub
End Class