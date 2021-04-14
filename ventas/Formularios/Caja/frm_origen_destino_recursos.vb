Public Class frm_origen_destino_recursos
    Dim id_tipo_operacion As Integer ' 1 pagar ,2 cobrar
    Dim total_operacion As Decimal

    Private Sub frm_origen_destino_recursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        tb_total_caja.Text = "Total en caja: " & FormatCurrency(saldo_caja())
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_origen_destino.BackColor = Color.FromArgb(conf_colores(1))
        btn_afectar_caja.BackColor = Color.FromArgb(conf_colores(8))
        btn_afectar_caja.ForeColor = Color.FromArgb(conf_colores(9))
        btn_no_afectar.BackColor = Color.FromArgb(conf_colores(8))
        btn_no_afectar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Public Sub cargar(ByVal id_tipo As Integer, ByVal total As Decimal)
        'id_tipo 0 para cuentasxcobrar
        'id_tipo 1 para cuentasxpagar
        'id_tipo 2 para pagar_facturas
        id_tipo_operacion = id_tipo
        total_operacion = total
        If id_tipo = 0 Then
            lbl_titulo.Text = "COBRAR: " & FormatCurrency(total)
            If global_cobro_terminal = 1 Then
                btn_afectar_caja.Enabled = True
                btn_no_afectar.Enabled = True
            Else
                MsgBox("Al parecer usted no tiene permitido hacer cobros de creditos", MsgBoxStyle.Exclamation, "Aviso")
            End If
        ElseIf id_tipo = 1 Then
            lbl_titulo.Text = "PAGAR: " & FormatCurrency(total)
            If global_pago_proveedores = 1 Then
                btn_afectar_caja.Enabled = True
                btn_no_afectar.Enabled = True
            Else
                MsgBox("Al parecer usted no tiene permitido hacer pago a proveedores", MsgBoxStyle.Exclamation, "Aviso")
            End If
        ElseIf id_tipo = 2 Then
            lbl_titulo.Text = "COBRAR: " & FormatCurrency(total)
            If global_cobro_terminal = 1 Then
                btn_afectar_caja.Enabled = True
                btn_no_afectar.Enabled = True
            Else
                MsgBox("Al parecer usted no tiene permitido hacer cobros de creditos", MsgBoxStyle.Exclamation, "Aviso")
            End If
        End If
      
    End Sub

    Private Sub btn_afectar_caja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_afectar_caja.Click
        If id_tipo_operacion = 0 Then
            If MsgBox("Confirme que el cobro de " & FormatCurrency(total_operacion) & " se registrará  e ingresará a la caja en su turno", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If global_frm_formas_pago_ventas = 1 Then
                    frm_formas_pago_ventas.guardar_cobro(1)
                    Me.Close()
                End If
            End If
        ElseIf id_tipo_operacion = 1 Then
            If MsgBox("Confirme que el pago de " & FormatCurrency(total_operacion) & " se registrará y se descontará de caja en su turno", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If global_frm_formas_pago = 1 Then
                    frm_formas_pago.guardar_pago(1)
                    Me.Close()
                End If
            End If
        ElseIf id_tipo_operacion = 2 Then
            If MsgBox("Confirme que el cobro de " & FormatCurrency(total_operacion) & " se registrará  e ingresará a la caja en su turno", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If global_frm_formas_pago_factura = 1 Then
                    frm_formas_pago_factura.guardar_cobro(1)
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub btn_no_afectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_no_afectar.Click
        If id_tipo_operacion = 0 Then
            If MsgBox("Confirme que el cobro de " & FormatCurrency(total_operacion) & " , esta operación no afecta en caja.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If global_frm_formas_pago_ventas = 1 Then
                    frm_validacion.id_tipo_operacion = 0
                    frm_validacion.validacion = 6
                    frm_validacion.ShowDialog()
                    frm_validacion.BringToFront()
                    'frm_formas_pago_ventas.guardar_cobro(0)
                    Me.Close()
                End If
            End If
        ElseIf id_tipo_operacion = 1 Then
            If MsgBox("Confirme que el pago de " & FormatCurrency(total_operacion) & ", esta operación no afecta en caja.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If global_frm_formas_pago = 1 Then
                    frm_validacion.id_tipo_operacion = 1
                    frm_validacion.validacion = 6
                    frm_validacion.ShowDialog()
                    frm_validacion.BringToFront()
                    'frm_formas_pago.guardar_pago(0)
                    Me.Close()
                End If
            End If
        ElseIf id_tipo_operacion = 2 Then
            If MsgBox("Confirme que el cobro de " & FormatCurrency(total_operacion) & " , esta operación no afecta en caja.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                If global_frm_formas_pago_factura = 1 Then
                    frm_validacion.id_tipo_operacion = 2
                    frm_validacion.validacion = 6
                    frm_validacion.ShowDialog()
                    frm_validacion.BringToFront()
                    'frm_formas_pago_prefactura.guardar_cobro(0)
                    Me.Close()
                End If
            End If
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
End Class