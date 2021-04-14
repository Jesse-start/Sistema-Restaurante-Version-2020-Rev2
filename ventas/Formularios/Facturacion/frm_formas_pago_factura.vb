Public Class frm_formas_pago_factura
    Dim forma_pago As Integer = 0 '0.-efectivo,1.-transferencia,2.-cheque,3.-notacredito, 4.0 tarjeta bancaria
    Dim num_cheque As Integer = 0
    Public id_factura As Integer = 0
    Dim importe_deuda As Double ' importe total a cobrar
    Dim saldo_acumulado As Double 'saldo acumulado
    Dim saldo_porcobrar As Double 'importe por cobrar
    Dim subtotal As Decimal
    Dim total_iva As Decimal
    Dim total_otros As Double
    Dim importe As Decimal
    Public nombre_cliente As String
    Public cliente_alias As String
    Public empleado_venta As String
    Private cobrado As Boolean = False
    Dim id_cliente As Integer = 0
    Dim tb_seleccionado As Integer = 0
    Dim myProcess As Process
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        groupBox2.ForeColor = Color.FromArgb(conf_colores(2))
        groupBox3.ForeColor = Color.FromArgb(conf_colores(2))

        label6.ForeColor = Color.FromArgb(conf_colores(13))
        label7.ForeColor = Color.FromArgb(conf_colores(13))
        label23.ForeColor = Color.FromArgb(conf_colores(13))
        label24.ForeColor = Color.FromArgb(conf_colores(13))

        tab_efectivo.BackColor = Color.FromArgb(conf_colores(1))
        tab_cheques.BackColor = Color.FromArgb(conf_colores(1))
        tab_transferencia.BackColor = Color.FromArgb(conf_colores(1))
        tab_ncredito.BackColor = Color.FromArgb(conf_colores(1))
        tab_tarjeta.BackColor = Color.FromArgb(conf_colores(1))

        tab_efectivo.ForeColor = Color.FromArgb(conf_colores(13))
        tab_cheques.ForeColor = Color.FromArgb(conf_colores(13))
        tab_transferencia.ForeColor = Color.FromArgb(conf_colores(13))
        tab_ncredito.ForeColor = Color.FromArgb(conf_colores(13))
        tab_tarjeta.ForeColor = Color.FromArgb(conf_colores(13))

        label2.ForeColor = Color.FromArgb(conf_colores(13))

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

        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))


    End Sub

    Private Sub frm_formas_pago_ventas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        global_frm_formas_pago_factura = 0
        If Not IsNothing(myProcess) Then
            If Not myProcess.HasExited Then
                ' myProcess.Kill()
                myProcess.CloseMainWindow()
            End If
        End If

        If global_frm_cuentasxcobrar = 1 Then
            frm_cuentas_xcobrar.cargar_tickets_cliente()
        End If
    End Sub

    Private Sub frm_formas_pago_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_formas_pago_factura = 1
        aplicar_colores()
        cobrado = False
        confinicio()
        obtener_banco_cliente()
    End Sub
    Private Sub confinicio()
        btn_aceptar.Text = "Guardar"
        tb_num_referencia.Text = ""
        tb_num_cheque.Text = ""
        tb_num_notacredito.Text = ""
        cb_cuenta_cheques.Items.Clear()
        cb_cuenta_destino.Items.Clear()
        cb_banco_cuenta.Items.Clear()
        ' lbl_saldo_cuenta_cheque.Text = "$00.00"
        lbl_saldo_cuenta_transf.Text = "$00.00"
        cb_cuenta_cheques.Text = ""
        cb_banco_cuenta.Text = ""
        cb_cuenta_destino.Text = ""
        obtener_bancos() '--obtenemos nuestras cuentas
        obtenerimporte_deuda() ' obtenemos el id_cliente, importe, saldo acumulado
        llenar_bancos()
    End Sub
    Private Sub llenar_bancos()
        CBbancoCheques.Items.Clear()
        cb_bancos_tarjeta.Items.Clear()
        'Conectar()
        rs.Open("SELECT * FROM banco Order By descripcion", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                CBbancoCheques.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                cb_bancos_tarjeta.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_banco_cliente()
        cb_BancoTransferencia.Items.Clear()
        'Conectar()
        rs.Open("SELECT DISTINCT(cc.banco),cc.id_cuenta_cliente FROM cliente_cuenta cc, cliente c WHERE cc.id_cliente=c.id_cliente AND c.id_cliente='" & id_cliente & "'", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_BancoTransferencia.Items.Add(New myItem(rs.Fields("id_cuenta_cliente").Value, rs.Fields("banco").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_bancos()
        cb_BancoTransferenciaR.Items.Clear()
        'CBbancoCheques.Items.Clear()
        'Conectar()
        rs.Open("SELECT DISTINCT(b.descripcion),bc.id_banco FROM banco_cuentas bc, banco b WHERE bc.id_banco=b.id_banco", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_BancoTransferenciaR.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                ' CBbancoCheques.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub cb_BancoTransferenciaR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_BancoTransferenciaR.SelectedIndexChanged
        cb_cuenta_destino.Items.Clear()
        cb_cuenta_destino.Text = ""
        'Conectar()
        rs.Open("SELECT id_cuenta,cuenta,Saldo FROM banco_cuentas WHERE id_banco='" & CType(cb_BancoTransferenciaR.SelectedItem, myItem).Value & "'", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_cuenta_destino.Items.Add(New myItem(rs.Fields("id_cuenta").Value, rs.Fields("cuenta").Value, rs.Fields("Saldo").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub cb_cuenta_destino_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cuenta_destino.SelectedIndexChanged
        If cb_cuenta_destino.SelectedIndex <> -1 Then
            lbl_saldo_cuenta_transf.Text = FormatCurrency(CType(cb_cuenta_destino.SelectedItem, myItem).Opcional)
        End If
    End Sub
    Public Sub obtenerimporte_deuda()
        saldo_acumulado = 0
        saldo_porcobrar = 0
        importe_deuda = 0
        subtotal = 0
        total_iva = 0
        total_otros = 0
        'Conectar()
        '---------OBTENEMOS id_cliente, IMPORTE TOTAL DE VENTA, 
        rs.Open("SELECT c.id_cliente, fe.subtotal,fe.iva,fe.total " & _
                "FROM  factura_electronica fe  " & _
                "JOIN cliente c ON c.id_cliente = fe.id_cliente " & _
                "WHERE fe.id_factura_electronica ='" & id_factura & "'", conn)
        If rs.RecordCount > 0 Then
            importe_deuda = rs.Fields("total").Value
            'tb_nombre_cheque.Text = rs.Fields("razon_social").Value
            'tb_nombre_notacredito.Text = rs.Fields("razon_social").Value
            'nombre_proveedor = rs.Fields("razon_social").Value
            id_cliente = rs.Fields("id_cliente").Value
            tb_importe.Text = FormatCurrency(importe_deuda)
            subtotal = rs.Fields("subtotal").Value
            total_iva = rs.Fields("iva").Value
            ' total_otros = rs.Fields("otros").Value

        End If
        rs.Close()
        '-----------------------------------------------------------------------
        saldo_porcobrar = importe_deuda
        saldo_porcobrar = FormatNumber(saldo_porcobrar, 2)
        If saldo_porcobrar > 0 Then
            tb_efectivo.Text = saldo_porcobrar
            tb_transferencia_importe.Text = saldo_porcobrar
            tb_cheque_importe.Text = saldo_porcobrar
            tb_importe_nota_credito.Text = saldo_porcobrar
            tb_importe_tarjeta.Text = saldo_porcobrar

        End If

    End Sub

    Private Sub cb_BancoTransferencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_BancoTransferencia.SelectedIndexChanged
        If cb_BancoTransferencia.SelectedIndex <> -1 Then
            cb_banco_cuenta.Items.Clear()
            cb_banco_cuenta.Text = ""
            'Conectar()
            rs.Open("SELECT id_cuenta_cliente,cuenta FROM cliente_cuenta WHERE banco='" & cb_BancoTransferencia.Text & "'", conn)
            While Not rs.EOF
                If rs.RecordCount > 0 Then
                    cb_banco_cuenta.Items.Add(New myItem(rs.Fields("id_cuenta_cliente").Value, rs.Fields("cuenta").Value))
                    rs.MoveNext()
                End If
            End While
            rs.Close()
            'conn.close()
            'conn = Nothing
        End If
    End Sub
    Private Sub tbcontrolPagos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcontrolPagos.SelectedIndexChanged
        forma_pago = tbcontrolPagos.SelectedIndex
        tb_seleccionado = 0
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim cadena As String = ""
        Dim bandera_correcto As Boolean = True
        cobrado = False
        If forma_pago = 0 Then
            If Trim(tb_efectivo.Text) = "" Then
                cadena = cadena & "  * Escriba la cantidad" & vbCrLf
                bandera_correcto = False
            End If
            If CDbl(tb_efectivo.Text) <> saldo_porcobrar Then
                cadena = cadena & "  * Su importe no puede ser diferente " & saldo_porcobrar & vbCrLf & ". Este cliente no tiene credito"
                bandera_correcto = False
                tb_efectivo.Text = saldo_porcobrar
            End If
        ElseIf forma_pago = 1 Then
            If cb_banco_cuenta.SelectedIndex = -1 Then
                cadena = cadena & "  * Cuenta origen" & vbCrLf
                bandera_correcto = False
            End If
            If cb_BancoTransferenciaR.SelectedIndex = -1 Then
                cadena = cadena & "  * Banco destino" & vbCrLf
                bandera_correcto = False
            End If
            If cb_cuenta_destino.SelectedIndex = -1 Then
                cadena = cadena & "  * Cuenta receptora" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_transferencia_importe.Text) = "" Or tb_transferencia_importe.Text = "0.00" Then
                cadena = cadena & "  * Importe de la transferencia" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_num_referencia.Text) = "" Then
                cadena = cadena & "  * Numero de Referencia:" & vbCrLf
                bandera_correcto = False
            End If

            If CDbl(tb_transferencia_importe.Text) <> saldo_porcobrar Then
                cadena = cadena & "  * Su importe no puede ser diferente " & saldo_porcobrar & vbCrLf & ". Este cliente no tiene credito"
                bandera_correcto = False
                tb_transferencia_importe.Text = saldo_porcobrar
            End If

        ElseIf forma_pago = 2 Then
            'If cb_cuenta_cheques.SelectedIndex = -1 Then
            'cadena = cadena & "  * Cuenta" & vbCrLf
            'bandera_correcto = False
            ' End If
            If CBbancoCheques.SelectedIndex = -1 Then
                cadena = cadena & "  * Seleccione Banco" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_num_cheque.Text) = "" Then
                cadena = cadena & "  * Numero de Chque" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_cheque_importe.Text) = "" Or tb_cheque_importe.Text = "0.00" Then
                cadena = cadena & "  * importe del cheque" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_nombre_cheque.Text) = "" Then
                cadena = cadena & "  * A favor de:" & vbCrLf
                bandera_correcto = False
            End If
            If CDbl(tb_cheque_importe.Text) <> saldo_porcobrar Then
                cadena = cadena & "  * Su importe no puede ser diferente que " & saldo_porcobrar & vbCrLf & ". Este cliente no tiene credito"
                bandera_correcto = False
                tb_cheque_importe.Text = saldo_porcobrar
            End If


        ElseIf forma_pago = 3 Then
            If Trim(tb_nombre_notacredito.Text) = "" Then
                cadena = cadena & "  * A favor de:" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_importe_nota_credito.Text) = "" Or tb_importe_nota_credito.Text = "0.00" Then
                cadena = cadena & "  * Importe de la nota de credito:" & vbCrLf
                bandera_correcto = False
            End If

            If CDbl(tb_importe_nota_credito.Text) <> saldo_porcobrar Then
                cadena = cadena & "  * Su importe no puede ser diferente que " & saldo_porcobrar & vbCrLf & ". Este cliente no tiene credito"
                bandera_correcto = False
                tb_importe_nota_credito.Text = saldo_porcobrar
            End If

        ElseIf forma_pago = 4 Then
            If cb_bancos_tarjeta.SelectedIndex = -1 Then
                cadena = cadena & "  * Banco" & vbCrLf
                bandera_correcto = False
            End If
            If Trim(tb_numero_tarjeta.Text) = "" Then
                cadena = cadena & "  * No de tarjeta:" & vbCrLf
                bandera_correcto = False
            End If
            If CDbl(tb_importe_tarjeta.Text) <> saldo_porcobrar Then
                cadena = cadena & "  * Su importe no puede ser diferente que " & saldo_porcobrar & vbCrLf & ". Este cliente no tiene credito"
                bandera_correcto = False
                tb_importe_tarjeta.Text = saldo_porcobrar
            End If

        End If
        '=========================================
        If bandera_correcto = True Then
            If forma_pago = 0 Then
                frm_origen_destino_recursos.cargar(2, CDec(tb_efectivo.Text))
                frm_origen_destino_recursos.ShowDialog()
            Else
                If forma_pago = 1 Then 'transferencia bancaria
                    If MsgBox("confirmar cobro por" & FormatCurrency(tb_transferencia_importe.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        cobrado = True
                        importe = tb_transferencia_importe.Text

                        Dim rx As New ADODB.Recordset
                        'Conectar()
                        rx.Open("SELECT id_venta,total FROM venta WHERE id_factura='" & id_factura & "' AND status='PENDIENTE'", conn)
                        If rx.RecordCount > 0 Then
                            While Not rx.EOF
                                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,id_cuenta_receptor,banco_cliente,cuenta_cliente,banco_receptor,cuenta_receptor,num_referencia,id_empleado_caja) VALUES " & _
     " (" & rx.Fields("id_venta").Value & "," & rx.Fields("total").Value & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_transferencia.Value, "yyyy-MM-dd hh:mm:ss") & "','" & CType(cb_cuenta_destino.SelectedItem, myItem).Value & "','" & cb_BancoTransferencia.Text & "','" & cb_banco_cuenta.Text & "','" & cb_BancoTransferenciaR.Text & "','" & cb_cuenta_destino.Text & "','" & tb_num_referencia.Text & "','" & global_id_empleado & "')", , -1)
                                Dim saldo As Double = CDbl(CType(cb_cuenta_destino.SelectedItem, myItem).Opcional) + CDbl(tb_transferencia_importe.Text)
                                conn.Execute("UPDATE banco_cuentas SET Saldo = '" & saldo & "',Fecha_modificacion =NOW() WHERE id_cuenta = " & CType(cb_cuenta_destino.SelectedItem, myItem).Value)
                                conn.Execute("UPDATE venta SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "' WHERE id_venta = " & rx.Fields("id_venta").Value)
                                rx.MoveNext()
                            End While
                        End If
                        rx.Close()
                        conn.Execute("UPDATE factura SET estatus = 'PAGADO' WHERE id_factura = " & id_factura & "")
                        'conn.close()
                        'conn = Nothing
                        For x = 0 To 1
                            imprimir_ticket_cobro_factura("recibo", id_factura, nombre_cliente, empleado_venta, nombre_forma_pago(forma_pago), x)
                        Next
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        Me.Close()
                    End If
                ElseIf forma_pago = 2 Then 'pago con cheque
                    If MsgBox("confirmar cobro por" & FormatCurrency(tb_cheque_importe.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        cobrado = True
                        importe = tb_cheque_importe.Text
                        Dim rx As New ADODB.Recordset
                        'Conectar()
                        rx.Open("SELECT id_venta,total FROM venta WHERE id_factura='" & id_factura & "' AND status='PENDIENTE'", conn)
                        If rx.RecordCount > 0 Then
                            While Not rx.EOF
                                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,banco_cliente,num_cheque,nombre_cheque,id_empleado_caja) VALUES " & _
                        " (" & rx.Fields("id_venta").Value & "," & importe & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_cheque.Value, "yyyy-MM-dd hh:mm:ss") & "','" & CBbancoCheques.Text & "','" & tb_num_cheque.Text & "','" & tb_nombre_cheque.Text & "','" & global_id_empleado & "')", , -1)
                                conn.Execute("UPDATE venta SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "' WHERE id_venta = " & rx.Fields("id_venta").Value)
                                rx.MoveNext()
                            End While
                        End If
                        rx.Close()
                        conn.Execute("UPDATE factura SET estatus = 'PAGADO' WHERE id_factura = " & id_factura & "")
                        'conn.close()
                        'conn = Nothing
                        For x = 0 To 1
                            imprimir_ticket_cobro_factura("recibo", id_factura, nombre_cliente, empleado_venta, nombre_forma_pago(forma_pago), x)
                        Next
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        Me.Close()
                    End If

                ElseIf forma_pago = 3 Then 'nota de credito
                    If MsgBox("confirmar cobro por" & FormatCurrency(tb_importe_nota_credito.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        cobrado = True
                        importe = tb_importe_nota_credito.Text
                        Dim rx As New ADODB.Recordset
                        'Conectar()
                        rx.Open("SELECT id_venta,total FROM venta WHERE id_factura='" & id_factura & "' AND status='PENDIENTE'", conn)
                        If rx.RecordCount > 0 Then
                            While Not rx.EOF
                                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,num_notacredito,nombre_notacredito,id_empleado_caja) VALUES " & _
                        " (" & rx.Fields("id_venta").Value & "," & rx.Fields("total").Value & ",'" & forma_pago & "',NOW(),'" & Format(dtp_fecha_notacredito.Value, "yyyy-MM-dd hh:mm:ss") & "','" & tb_num_notacredito.Text & "','" & tb_nombre_notacredito.Text & "','" & global_id_empleado & "')", , -1)
                                conn.Execute("UPDATE venta SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "' WHERE id_venta = " & rx.Fields("id_venta").Value)
                                rx.MoveNext()
                            End While
                        End If
                        rx.Close()
                        conn.Execute("UPDATE factura SET estatus = 'PAGADO' WHERE id_factura = " & id_factura & "")
                        'conn.close()
                        'conn = Nothing
                        For x = 0 To 1
                            imprimir_ticket_cobro_factura("recibo", id_factura, nombre_cliente, empleado_venta, nombre_forma_pago(forma_pago), x)
                        Next
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        Me.Close()
                    End If
                ElseIf forma_pago = 4 Then 'tarjeta de credito
                    If MsgBox("confirmar cobro por" & FormatCurrency(tb_importe_tarjeta.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        cobrado = True
                        importe = tb_importe_tarjeta.Text

                        Dim rx As New ADODB.Recordset
                        'Conectar()
                        rx.Open("SELECT id_venta,total FROM venta WHERE id_factura='" & id_factura & "' AND status='PENDIENTE'", conn)
                        If rx.RecordCount > 0 Then
                            While Not rx.EOF
                                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,banco_cliente,num_tarjeta,id_empleado_caja) VALUES " & _
                       " (" & rx.Fields("id_venta").Value & "," & rx.Fields("total").Value & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_tarjeta.Value, "yyyy-MM-dd hh:mm:ss") & "','" & cb_bancos_tarjeta.Text & "','" & tb_numero_tarjeta.Text & "','" & global_id_empleado & "')", , -1)
                                conn.Execute("UPDATE venta SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "' WHERE id_venta = " & rx.Fields("id_venta").Value)
                                rx.MoveNext()
                            End While
                        End If
                        rx.Close()
                        conn.Execute("UPDATE factura SET estatus = 'PAGADO' WHERE id_factura = " & id_factura & "")
                        'conn.close()
                        'conn = Nothing
                        For x = 0 To 1
                            imprimir_ticket_cobro_factura("recibo", id_factura, nombre_cliente, empleado_venta, nombre_forma_pago(forma_pago), x)
                        Next
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        Me.Close()
                    End If
                End If
            End If
        Else
            MsgBox(cadena)
        End If

    End Sub
    Public Sub guardar_cobro(ByVal afecta_caja As Integer)
        If forma_pago = 0 Then '---pago en efectivo
            cobrado = True
            importe = tb_efectivo.Text

            Dim rx As New ADODB.Recordset
            'Conectar()
            rx.Open("SELECT id_venta,total FROM venta WHERE id_factura='" & id_factura & "' AND status='PENDIENTE'", conn)
            If rx.RecordCount > 0 Then
                While Not rx.EOF
                    conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,id_empleado_caja,afecta_caja) VALUES " & _
                            " (" & rx.Fields("id_venta").Value & "," & rx.Fields("total").Value & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_efectivo.Value, "yyyy-MM-dd hh:mm:ss") & "','" & global_id_empleado & "','" & afecta_caja & "')", , -1)
                    conn.Execute("UPDATE venta SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "' WHERE id_venta = " & rx.Fields("id_venta").Value)
                    rx.MoveNext()
                End While
            End If
            rx.Close()
            conn.Execute("UPDATE factura_electronica SET estatus = 'PAGADO' WHERE id_factura_electronica = " & id_factura & "")
            'conn.close()
            'conn = Nothing
            For x = 0 To 1
                imprimir_ticket_cobro_factura("recibo", id_factura, nombre_cliente, empleado_venta, nombre_forma_pago(forma_pago), x)
            Next

            MsgBox("pago guardado correctamente", vbOKOnly, "Información")
            Me.Close()
        End If
    End Sub
    Private Sub tb_efectivo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_efectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_efectivo.Text <> "" Then
                tb_efectivo.Text = FormatNumber(tb_efectivo.Text, 2)
                btn_aceptar.Focus()
            Else
                tb_efectivo.Text = FormatNumber(tb_efectivo.Text, 2)
            End If
        End If
    End Sub

    Private Sub tb_efectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_efectivo.KeyPress
        e.Handled = txtNumerico(tb_efectivo, e.KeyChar, True)
    End Sub

    Private Sub tb_transferencia_importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_transferencia_importe.Click
        tb_seleccionado = 2
    End Sub
    Private Sub tb_transferencia_importe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_transferencia_importe.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_transferencia_importe.Text <> "" Then
                tb_transferencia_importe.Text = FormatNumber(tb_transferencia_importe.Text, 2)
                fecha_pago_transferencia.Focus()
            Else
                tb_transferencia_importe.Text = FormatNumber(tb_transferencia_importe.Text, 2)
            End If
        End If
    End Sub

    Private Sub tb_transferencia_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_transferencia_importe.KeyPress
        e.Handled = txtNumerico(tb_transferencia_importe, e.KeyChar, True)
    End Sub

    Private Sub tb_cheque_importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cheque_importe.Click
        tb_seleccionado = 2
    End Sub
    Private Sub tb_cheque_importe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_cheque_importe.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_cheque_importe.Text <> "" Then
                tb_cheque_importe.Text = FormatNumber(tb_cheque_importe.Text, 2)
                btn_aceptar.Focus()
            Else
                tb_cheque_importe.Text = FormatNumber(tb_cheque_importe.Text, 2)
            End If
        End If
    End Sub

    Private Sub tb_cheque_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cheque_importe.KeyPress
        e.Handled = txtNumerico(tb_cheque_importe, e.KeyChar, True)
    End Sub

    Private Sub tb_importe_nota_credito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_nota_credito.Click
        tb_seleccionado = 2
    End Sub
    Private Sub tb_importe_nota_credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_importe_nota_credito.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_importe_nota_credito.Text <> "" Then
                tb_importe_nota_credito.Text = FormatNumber(tb_importe_nota_credito.Text, 2)
                btn_aceptar.Focus()
            Else
                tb_importe_nota_credito.Text = FormatNumber(tb_importe_nota_credito.Text, 2)
            End If
        End If
    End Sub

    Private Sub tb_importe_nota_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_importe_nota_credito.KeyPress
        e.Handled = txtNumerico(tb_importe_nota_credito, e.KeyChar, True)
    End Sub
    Private Sub tb_num_cheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_num_cheque.Click
        tb_seleccionado = 1
    End Sub

    Private Sub tb_num_cheque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_num_cheque.KeyDown
        If cb_cuenta_cheques.SelectedIndex <> -1 Then
            If e.KeyCode = Keys.Enter Then
                btn_aceptar.Focus()
            End If
        End If
    End Sub

    Private Sub tb_num_cheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_num_cheque.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Dispose()
    End Sub

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If tbcontrolPagos.SelectedIndex = 0 Then
                tb_efectivo.Focus()
            ElseIf tbcontrolPagos.SelectedIndex = 1 Then
                If tb_seleccionado = 1 Then
                    tb_num_referencia.Focus()
                ElseIf tb_seleccionado = 2 Then
                    tb_transferencia_importe.Focus()
                End If
            ElseIf tbcontrolPagos.SelectedIndex = 2 Then
                If tb_seleccionado = 1 Then
                    tb_num_cheque.Focus()
                ElseIf tb_seleccionado = 2 Then
                    tb_cheque_importe.Focus()
                End If
            ElseIf tbcontrolPagos.SelectedIndex = 3 Then
                If tb_seleccionado = 1 Then
                    tb_num_notacredito.Focus()
                ElseIf tb_seleccionado = 2 Then
                    tb_importe_nota_credito.Focus()
                End If
            ElseIf tbcontrolPagos.SelectedIndex = 4 Then
                If tb_seleccionado = 1 Then
                    tb_numero_tarjeta.Focus()
                ElseIf tb_seleccionado = 2 Then
                    tb_importe_tarjeta.Focus()
                End If

            End If
            'tb_pago.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If tbcontrolPagos.SelectedIndex = 0 Then
            btn_aceptar_Click(sender, e)
        Else
            If tb_seleccionado = 2 Then
                btn_aceptar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub tb_num_referencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_num_referencia.Click
        tb_seleccionado = 1
    End Sub
    Private Sub tb_num_notacredito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_num_notacredito.Click
        tb_seleccionado = 1
    End Sub
    Private Sub tb_numero_tarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_numero_tarjeta.Click
        tb_seleccionado = 1
    End Sub
    Private Sub tb_importe_tarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_tarjeta.Click
        tb_seleccionado = 2
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If tbcontrolPagos.SelectedIndex = 0 Then
            tb_efectivo.Text = ""
        ElseIf tbcontrolPagos.SelectedIndex = 1 Then
            If tb_seleccionado = 1 Then
                tb_num_referencia.Text = ""
            ElseIf tb_seleccionado = 2 Then
                tb_transferencia_importe.Text = ""
            End If
        ElseIf tbcontrolPagos.SelectedIndex = 2 Then
            If tb_seleccionado = 1 Then
                tb_num_cheque.Text = ""
            ElseIf tb_seleccionado = 2 Then
                tb_cheque_importe.Text = ""
            End If
        ElseIf tbcontrolPagos.SelectedIndex = 3 Then
            If tb_seleccionado = 1 Then
                tb_num_notacredito.Text = ""
            ElseIf tb_seleccionado = 2 Then
                tb_importe_nota_credito.Text = ""
            End If
        ElseIf tbcontrolPagos.SelectedIndex = 4 Then
            If tb_seleccionado = 1 Then
                tb_numero_tarjeta.Text = ""
            ElseIf tb_seleccionado = 2 Then
                tb_importe_tarjeta.Text = ""
            End If

        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If tbcontrolPagos.SelectedIndex = 0 Then

            tb_efectivo.Text = tb_efectivo.Text.Remove(tb_efectivo.TextLength - 1, 1)
            tb_efectivo.SelectionStart = Len(tb_efectivo.Text)
        ElseIf tbcontrolPagos.SelectedIndex = 1 Then
            If tb_seleccionado = 1 Then
                tb_num_referencia.Text = tb_num_referencia.Text.Remove(tb_num_referencia.TextLength - 1, 1)
                tb_num_referencia.SelectionStart = Len(tb_num_referencia.Text)
            ElseIf tb_seleccionado = 2 Then
                tb_transferencia_importe.Text = tb_transferencia_importe.Text.Remove(tb_transferencia_importe.TextLength - 1, 1)
                tb_transferencia_importe.SelectionStart = Len(tb_transferencia_importe.Text)
            End If
        ElseIf tbcontrolPagos.SelectedIndex = 2 Then
            If tb_seleccionado = 1 Then
                tb_num_cheque.Text = tb_num_cheque.Text.Remove(tb_num_cheque.TextLength - 1, 1)
                tb_num_cheque.SelectionStart = Len(tb_num_cheque.Text)
            ElseIf tb_seleccionado = 2 Then
                tb_cheque_importe.Text = tb_cheque_importe.Text.Remove(tb_cheque_importe.TextLength - 1, 1)
                tb_cheque_importe.SelectionStart = Len(tb_cheque_importe.Text)
            End If
        ElseIf tbcontrolPagos.SelectedIndex = 3 Then
            If tb_seleccionado = 1 Then
                tb_num_notacredito.Text = tb_num_notacredito.Text.Remove(tb_num_notacredito.TextLength - 1, 1)
                tb_num_notacredito.SelectionStart = Len(tb_num_notacredito.Text)
            ElseIf tb_seleccionado = 2 Then
                tb_importe_nota_credito.Text = tb_importe_nota_credito.Text.Remove(tb_importe_nota_credito.TextLength - 1, 1)
                tb_importe_nota_credito.SelectionStart = Len(tb_importe_nota_credito.Text)
            End If
        ElseIf tbcontrolPagos.SelectedIndex = 4 Then
            If tb_seleccionado = 1 Then
                tb_numero_tarjeta.Text = tb_numero_tarjeta.Text.Remove(tb_numero_tarjeta.TextLength - 1, 1)
                tb_numero_tarjeta.SelectionStart = Len(tb_numero_tarjeta.Text)
            ElseIf tb_seleccionado = 2 Then
                tb_importe_tarjeta.Text = tb_importe_tarjeta.Text.Remove(tb_importe_tarjeta.TextLength - 1, 1)
                tb_importe_tarjeta.SelectionStart = Len(tb_importe_tarjeta.Text)
            End If
        End If
    End Sub

    Private Sub btn_teclado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_teclado.Click
        If IsNothing(myProcess) Then
            myProcess = System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() & "/teclado.exe")
        Else
            If myProcess.HasExited Then
                myProcess = System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() & "/teclado.exe")
            End If
        End If

    End Sub

End Class