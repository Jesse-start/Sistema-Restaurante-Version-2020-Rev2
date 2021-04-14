Public Class frm_formas_pago
    Dim forma_pago As Integer = 0 '0.-efectivo,1.-transferencia,2.-cheque,3.-notacredito
    Dim num_cheque As Integer = 0
    Public id_factura_compra As Integer = 0
    Dim total_factura As Decimal ' importe total a pagar
    Dim total_pagado As Decimal 'saldo acumulado
    Dim saldo As Decimal
    Dim nombre_proveedor As String = ""
    Dim id_proveedor As Integer = 0
    Dim tb_seleccionado As Integer = 0
    Dim myProcess As Process
    Dim importe_pago_realizado As Decimal
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        groupBox2.ForeColor = Color.FromArgb(conf_colores(2))
        groupBox3.ForeColor = Color.FromArgb(conf_colores(2))

        label6.ForeColor = Color.FromArgb(conf_colores(13))
        label7.ForeColor = Color.FromArgb(conf_colores(13))
        label23.ForeColor = Color.FromArgb(conf_colores(13))
        label24.ForeColor = Color.FromArgb(conf_colores(13))

        label1.ForeColor = Color.FromArgb(conf_colores(13))
        label2.ForeColor = Color.FromArgb(conf_colores(13))

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

        btn_cancelar_pago.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar_pago.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_formas_pago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        global_frm_formas_pago = 1

        If Not IsNothing(myProcess) Then
            If Not myProcess.HasExited Then
                ' myProcess.Kill()
                myProcess.CloseMainWindow()
            End If
        End If
        If global_frm_cuentasxpagar = 1 Then
            frm_cuentas_xpagar.cargar_remisiones_proveedores()
        End If
    End Sub
    Private Sub frm_formas_pago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_formas_pago = 1
        aplicar_colores()
        obtener_banco_proveedor()
        obtener_bancos_cuentas()
        obtener_bancos()
        With lst_Pagos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Fecha de Registro", 110)
            .Columns.Add("Fecha de pago", 100)
            .Columns.Add("Forma de Pago", 90, HorizontalAlignment.Right)
            .Columns.Add("Importe", 80, HorizontalAlignment.Right)
        End With
        cargar()

    End Sub
    Private Sub cargar()
        confinicio()
        obtener_pagos_realizados()
        obtener_importe_deuda()
    End Sub
    Private Sub confinicio()
        btn_cancelar_pago.Enabled = False
        btn_aceptar.Text = "Guardar"
        tb_num_referencia.Text = ""
        tb_num_cheque.Text = ""
        tb_num_notacredito.Text = ""
        cb_cuenta_cheques.Items.Clear()
        cb_cuenta_destino.Items.Clear()
        cb_banco_cuenta.Items.Clear()
        lbl_saldo_cuenta_cheque.Text = "$00.00"
        lbl_saldo_cuenta_transf.Text = "$00.00"
        cb_cuenta_cheques.Text = ""
        cb_banco_cuenta.Text = ""
        cb_cuenta_destino.Text = ""
    End Sub
    Private Sub obtener_pagos_realizados()
        lst_Pagos.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_forma_pago,importe,id_forma_pago,fecha,fecha_pago,status FROM pagos_compras WHERE id_factura_compra='" & id_factura_compra & "' ORDER by fecha_pago", conn)
        Dim i = 0
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(4) As String
                str(0) = Format(rs.Fields("fecha").Value, "dd-MM-yyyy")
                str(1) = Format(rs.Fields("fecha_pago").Value, "dd-MM-yyyy")
                str(2) = nombre_forma_pago(rs.Fields("id_forma_pago").Value)
                str(3) = FormatCurrency(rs.Fields("importe").Value)
                lst_Pagos.Items.Add(New ListViewItem(str, 0))
                lst_Pagos.Items(i).Tag = rs.Fields("id_forma_pago").Value
                If rs.Fields("status").Value = "ACTIVO" Then
                    lst_Pagos.Items(i).BackColor = Color.White
                    lst_Pagos.Items(i).ForeColor = Color.Black
                Else
                    lst_Pagos.Items(i).BackColor = Color.Red
                    lst_Pagos.Items(i).ForeColor = Color.White
                End If
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()
    End Sub
    'Private Function nombre_forma_pago(ByVal id_forma As Integer) As String
    'Dim nombre_pago As String = ""
    'If id_forma = 0 Then
    '        nombre_pago = "Efectivo"
    'ElseIf id_forma = 1 Then
    '       nombre_pago = "Transferencia"
    'ElseIf id_forma = 2 Then
    '       nombre_pago = "Cheque"
    'ElseIf id_forma = 3 Then
    '       nombre_pago = "Nota de credito"
    'ElseIf id_forma = 4 Then
    '        nombre_pago = "Tarjeta Bancaria"
    'ElseIf id_forma = 5 Then
    '       nombre_pago = "Cupones"
    'End If
    'Return nombre_pago
    'End Function
    Private Sub obtener_importe_deuda()

        total_factura = 0
        total_pagado = 0
        saldo = 0

        rs.Open("SELECT proveedor.id_proveedor,factura_compra.total, CASE WHEN proveedor.id_persona = 0 THEN empresa.razon_social  ELSE  CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS razon_social " & _
                "FROM  proveedor  " & _
                "LEFT OUTER JOIN persona ON persona.id_persona = proveedor.id_persona " & _
                "LEFT OUTER  JOIN empresa ON empresa.id_empresa = proveedor.id_empresa " & _
                "JOIN factura_compra ON factura_compra.id_proveedor = proveedor.id_proveedor " & _
                "WHERE proveedor.id_proveedor  AND factura_compra.id_factura_compra ='" & id_factura_compra & "' ORDER BY razon_social", conn)
        If rs.RecordCount > 0 Then
            total_factura = rs.Fields("total").Value
            tb_nombre_cheque.Text = rs.Fields("razon_social").Value
            tb_nombre_notacredito.Text = rs.Fields("razon_social").Value
            nombre_proveedor = rs.Fields("razon_social").Value
            id_proveedor = rs.Fields("id_proveedor").Value
            tb_importe.Text = FormatCurrency(total_factura)

        End If
        rs.Close()

        rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_compras WHERE id_factura_compra='" & id_factura_compra & "' AND status='ACTIVO' ", conn)
        If rs.RecordCount > 0 Then
            total_pagado = CDbl(rs.Fields("total").Value)
        End If
        tb_total.Text = FormatCurrency(total_pagado)
        rs.Close()

        saldo = total_factura - total_pagado
        'saldo = FormatNumber(saldo, 2)

        If saldo > 0 Then
            tb_efectivo.Text = saldo
            tb_transferencia_importe.Text = saldo
            tb_cheque_importe.Text = saldo
            tb_importe_nota_credito.Text = saldo
            tb_importe_tarjeta.Text = saldo
        End If

    End Sub
    Private Sub obtener_bancos()
        cb_BancoTransferenciaR.Items.Clear()
        cb_bancos_tarjeta.Items.Clear()
        'Conectar()
        rs.Open("SELECT * FROM banco Order By descripcion", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_BancoTransferenciaR.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                cb_bancos_tarjeta.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_bancos_cuentas()
        cb_BancoTransferencia.Items.Clear()
        CBbancoCheques.Items.Clear()
        'Conectar()
        rs.Open("SELECT DISTINCT(b.descripcion),bc.id_banco FROM banco_cuentas bc, banco b WHERE bc.id_banco=b.id_banco", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_BancoTransferencia.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                CBbancoCheques.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_banco_proveedor()
        cb_BancoTransferenciaR.Items.Clear()
        'Conectar()
        rs.Open("SELECT DISTINCT(pc.banco),pc.id_cuenta_proveedor FROM proveedor_cuenta pc, proveedor p WHERE pc.id_proveedor=p.id_proveedor AND p.id_proveedor='" & id_proveedor & "'", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_BancoTransferenciaR.Items.Add(New myItem(rs.Fields("id_cuenta_proveedor").Value, rs.Fields("banco").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub cb_BancoTransferencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_BancoTransferencia.SelectedIndexChanged
        cb_banco_cuenta.Items.Clear()
        cb_banco_cuenta.Text = ""
        'Conectar()
        rs.Open("SELECT id_cuenta,cuenta,Saldo FROM banco_cuentas WHERE id_banco='" & CType(cb_BancoTransferencia.SelectedItem, myItem).Value & "'", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_banco_cuenta.Items.Add(New myItem(rs.Fields("id_cuenta").Value, rs.Fields("cuenta").Value, rs.Fields("Saldo").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub tbcontrolPagos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcontrolPagos.SelectedIndexChanged
        forma_pago = tbcontrolPagos.SelectedIndex
        'MsgBox(tbcontrolPagos.SelectedIndex)
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        importe_pago_realizado = 0

        If btn_aceptar.Text = "Guardar" Then
            Dim cadena As String = ""
            Dim bandera_correcto As Boolean = True
            If forma_pago = 0 Then
                If Trim(tb_efectivo.Text) = "" Then
                    cadena = cadena & "  * Escriba la cantidad" & vbCrLf
                    bandera_correcto = False
                End If
                If CDbl(tb_efectivo.Text) > saldo Then
                    cadena = cadena & "  * Su importe no puede ser mayor que su deuda" & vbCrLf
                    bandera_correcto = False
                    tb_efectivo.Text = saldo
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
                If CDbl(tb_transferencia_importe.Text) > saldo Then
                    cadena = cadena & "  * Su importe no puede ser mayor que su deuda" & vbCrLf
                    bandera_correcto = False
                    tb_transferencia_importe.Text = saldo
                End If
            ElseIf forma_pago = 2 Then
                If cb_cuenta_cheques.SelectedIndex = -1 Then
                    cadena = cadena & "  * Cuenta" & vbCrLf
                    bandera_correcto = False
                End If
                If Trim(tb_num_cheque.Text) = "" Then
                    cadena = cadena & "  * Numero de Chque" & vbCrLf
                    bandera_correcto = False
                Else
                    If verificar_cheque(tb_num_cheque.Text) = True Then
                        cadena = cadena & "  * Este cheque ya existe" & vbCrLf
                        bandera_correcto = False
                    End If
                End If
                If Trim(tb_cheque_importe.Text) = "" Or tb_cheque_importe.Text = "0.00" Then
                    cadena = cadena & "  * importe del cheque" & vbCrLf
                    bandera_correcto = False
                End If
                If Trim(tb_nombre_cheque.Text) = "" Then
                    cadena = cadena & "  * A favor de:" & vbCrLf
                    bandera_correcto = False
                End If
                If CDbl(tb_cheque_importe.Text) > saldo Then
                    cadena = cadena & "  * Su importe no puede ser mayor que su deuda" & vbCrLf
                    bandera_correcto = False
                    tb_cheque_importe.Text = saldo
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
                If CDbl(tb_importe_nota_credito.Text) > saldo Then
                    cadena = cadena & "  * Su importe no puede ser mayor que su deuda" & vbCrLf
                    bandera_correcto = False
                    tb_importe_nota_credito.Text = saldo
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
                If CDbl(tb_importe_tarjeta.Text) > saldo Then
                    cadena = cadena & "  * Su importe no puede ser mayor " & saldo & vbCrLf
                    bandera_correcto = False
                    tb_importe_tarjeta.Text = saldo
                End If
            End If
            '=========================================


            If bandera_correcto = True Then
                If forma_pago = 0 Then '---pago en efectivo
                    frm_origen_destino_recursos.cargar(1, CDec(tb_efectivo.Text))
                    frm_origen_destino_recursos.ShowDialog()
                ElseIf forma_pago = 1 Then 'transferencia bancaria
                    If MsgBox("confirmar pago por" & FormatCurrency(tb_transferencia_importe.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        importe_pago_realizado = tb_transferencia_importe.Text
                        conn.Execute("INSERT INTO pagos_compras(id_factura_compra,importe,id_forma_pago,fecha,fecha_pago,id_cuenta,banco,cuenta,banco_receptor,cuenta_receptor,num_referencia,id_empleado_pago) VALUES " & _
                         " (" & id_factura_compra & "," & tb_transferencia_importe.Text & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_transferencia.Value, "yyyy-MM-dd hh:mm:ss") & "','" & CType(cb_BancoTransferencia.SelectedItem, myItem).Value & "','" & cb_BancoTransferencia.Text & "','" & cb_banco_cuenta.Text & "','" & cb_BancoTransferenciaR.Text & "','" & cb_cuenta_destino.Text & "','" & tb_num_referencia.Text & "','" & global_id_empleado & "')", , -1)
                        Dim saldo As Double = CDbl(CType(cb_banco_cuenta.SelectedItem, myItem).Opcional) - CDbl(tb_transferencia_importe.Text)
                        conn.Execute("UPDATE banco_cuentas SET Saldo = '" & saldo & "',Fecha_modificacion =NOW() WHERE id_cuenta = " & CType(cb_banco_cuenta.SelectedItem, myItem).Value)
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        imprimir_comprobante()
                    End If

                ElseIf forma_pago = 2 Then 'pago con cheque
                    If MsgBox("confirmar pago por" & FormatCurrency(tb_cheque_importe.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        importe_pago_realizado = tb_cheque_importe.Text

                        conn.Execute("INSERT INTO pagos_compras(id_factura_compra,importe,id_forma_pago,fecha,fecha_pago,id_cuenta,banco,cuenta,num_cheque,nombre_cheque,id_empleado_pago) VALUES " & _
                        " (" & id_factura_compra & "," & tb_cheque_importe.Text & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_cheque.Value, "yyyy-MM-dd hh:mm:ss") & "','" & CType(cb_cuenta_cheques.SelectedItem, myItem).Value & "','" & CBbancoCheques.Text & "','" & cb_cuenta_cheques.Text & "','" & tb_num_cheque.Text & "','" & tb_nombre_cheque.Text & "','" & global_id_empleado & "')", , -1)
                        Dim saldo As Double = CDbl(CType(cb_cuenta_cheques.SelectedItem, myItem).Opcional) - CDbl(tb_cheque_importe.Text)
                        conn.Execute("UPDATE banco_cuentas SET Saldo = '" & saldo & "',Fecha_modificacion =NOW(),Ultimo_Cheq='" & tb_num_cheque.Text & "' WHERE id_cuenta = " & CType(cb_cuenta_cheques.SelectedItem, myItem).Value)
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        imprimir_comprobante()
                    End If

                ElseIf forma_pago = 3 Then 'nota de credito
                    If MsgBox("confirmar pago por" & FormatCurrency(tb_importe_nota_credito.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        importe_pago_realizado = tb_importe_nota_credito.Text
                        conn.Execute("INSERT INTO pagos_compras(id_factura_compra,importe,id_forma_pago,fecha,fecha_pago,num_notacredito,nombre_notacredito,id_empleado_pago) VALUES " & _
                       " (" & id_factura_compra & "," & tb_importe_nota_credito.Text & ",'" & forma_pago & "',NOW(),'" & Format(dtp_fecha_notacredito.Value, "yyyy-MM-dd hh:mm:ss") & "','" & tb_num_notacredito.Text & "','" & tb_nombre_notacredito.Text & "','" & global_id_empleado & "')", , -1)
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        imprimir_comprobante()
                    End If
                ElseIf forma_pago = 4 Then 'tarjeta bancaria
                    If MsgBox("confirmar pago por" & FormatCurrency(tb_importe_tarjeta.Text) & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        importe_pago_realizado = tb_importe_tarjeta.Text
                        conn.Execute("INSERT INTO pagos_compras(id_factura_compra,importe,id_forma_pago,fecha,fecha_pago,banco,num_tarjeta,id_empleado_pago) VALUES " & _
                       " (" & id_factura_compra & "," & tb_importe_tarjeta.Text & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_tarjeta.Value, "yyyy-MM-dd hh:mm:ss") & "','" & cb_bancos_tarjeta.Text & "','" & tb_numero_tarjeta.Text & "','" & global_id_empleado & "')", , -1)
                        MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                        imprimir_comprobante()
                    End If
                End If

            Else
                MsgBox(cadena)
            End If
        Else
            tb_cheque_importe.Enabled = True
            CBbancoCheques.Enabled = True
            cb_cuenta_cheques.Enabled = True
            fecha_pago_cheque.Enabled = True
            tb_nombre_cheque.Enabled = True
            cargar()
        End If

    End Sub
    Private Sub imprimir_comprobante()
        Dim _total_pagado As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_compras WHERE id_factura_compra='" & id_factura_compra & "' AND status='ACTIVO' ", conn)
        If rs.RecordCount > 0 Then
            _total_pagado = CDbl(rs.Fields("total").Value)
        End If
        rs.Close()

        For x = 0 To 1
            imprimir_recibo_pago_proveedor(id_factura_compra, nombre_proveedor, id_factura_compra, FormatCurrency(importe_pago_realizado), FormatCurrency(total_factura - _total_pagado), nombre_forma_pago(forma_pago), x)
        Next

        Dim _saldo As Decimal = total_factura - _total_pagado

        If _saldo > 0 Then
            cargar()
        Else
            conn.Execute("UPDATE factura_compra SET status = 'PAGADA' WHERE id_factura_compra = " & id_factura_compra)
            MsgBox("La factura ha sido pagada en su totalidad", vbOKOnly, "Información")
            Me.Close()
        End If
    End Sub
    Public Sub guardar_pago(ByVal afecta_caja As Integer)
        Dim saldo_actual_caja As Decimal = saldo_caja()
        If forma_pago = 0 Then '---pago en efectivo
            If afecta_caja = 1 Then
                If saldo_actual_caja > CDec(tb_efectivo.Text) Then
Pagar:              importe_pago_realizado = tb_efectivo.Text
                    'Conectar()
                    conn.Execute("INSERT INTO pagos_compras(id_factura_compra,importe,id_forma_pago,fecha,fecha_pago,id_empleado_pago,afecta_caja) VALUES " & _
                                    " (" & id_factura_compra & "," & CDbl(tb_efectivo.Text) & ",'" & forma_pago & "',NOW(),'" & Format(fecha_pago_efectivo.Value, "yyyy-MM-dd hh:mm:ss") & "','" & global_id_empleado & "','" & afecta_caja & "')", , -1)
                    'conn.close()
                    'conn = Nothing
                    MsgBox("pago guardado correctamente", vbOKOnly, "Información")
                    imprimir_comprobante()
                Else
                    MsgBox("No cuenta con suficiente efectivo en caja para realizar este pago", MsgBoxStyle.Exclamation, "Aviso")
                End If
            Else
                GoTo Pagar
            End If
        End If
    End Sub

    Private Sub cb_cuenta_cheques_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cuenta_cheques.SelectedIndexChanged
        If CBbancoCheques.SelectedIndex <> -1 Then
            'Conectar()
            rs.Open("SELECT ultimo_Cheq FROM banco_cuentas WHERE id_cuenta='" & CType(cb_cuenta_cheques.SelectedItem, myItem).Value & "'", conn)
            If rs.RecordCount > 0 Then
                num_cheque = CDbl(rs.Fields("Ultimo_Cheq").Value) + 1
                tb_num_cheque.Text = num_cheque
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
        End If
        If cb_cuenta_cheques.SelectedIndex <> -1 Then
            lbl_saldo_cuenta_cheque.Text = FormatCurrency(CType(cb_cuenta_cheques.SelectedItem, myItem).Opcional)
        End If

    End Sub

    Private Sub CBbancoCheques_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBbancoCheques.SelectedIndexChanged
        cb_cuenta_cheques.Items.Clear()
        cb_cuenta_cheques.Text = ""
        'Conectar()
        rs.Open("SELECT id_cuenta,cuenta,Saldo FROM banco_cuentas WHERE id_banco='" & CType(CBbancoCheques.SelectedItem, myItem).Value & "'", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_cuenta_cheques.Items.Add(New myItem(rs.Fields("id_cuenta").Value, rs.Fields("cuenta").Value, rs.Fields("Saldo").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cb_BancoTransferenciaR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_BancoTransferenciaR.SelectedIndexChanged
        If cb_BancoTransferenciaR.SelectedIndex <> -1 Then
            cb_cuenta_destino.Items.Clear()
            cb_cuenta_destino.Text = ""
            'Conectar()
            rs.Open("SELECT id_cuenta_proveedor,cuenta FROM proveedor_cuenta WHERE banco='" & cb_BancoTransferenciaR.Text & "'", conn)
            While Not rs.EOF
                If rs.RecordCount > 0 Then
                    cb_cuenta_destino.Items.Add(New myItem(rs.Fields("id_cuenta_proveedor").Value, rs.Fields("cuenta").Value))
                    rs.MoveNext()
                End If
            End While
            rs.Close()
            'conn.close()
            'conn = Nothing
        End If

    End Sub
    Private Sub cb_banco_cuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_banco_cuenta.SelectedIndexChanged
        If cb_banco_cuenta.SelectedIndex <> -1 Then
            lbl_saldo_cuenta_transf.Text = FormatCurrency(CType(cb_banco_cuenta.SelectedItem, myItem).Opcional)
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
    Private Sub btn_cancelar_pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_pago.Click
        If MsgBox("Esta seguro que desea cancelar este pago", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If lst_Pagos.SelectedItems(0).SubItems(2).Text = "Transferencia" Or lst_Pagos.SelectedItems(0).SubItems(2).Text = "Cheque" Then
                'Conectar()
                conn.Execute("UPDATE pagos_compras SET status = 'CANCELADO',fecha_cancelacion=NOW() WHERE id_forma_pago = " & lst_Pagos.SelectedItems.Item(0).Tag)
                '----sacamos la cuenta 
                rs.Open("SELECT importe,id_forma_pago,id_cuenta FROM pagos_compras WHERE id_forma_pago=" & lst_Pagos.SelectedItems.Item(0).Tag, conn)
                If rs.RecordCount > 0 Then
                    conn.Execute("UPDATE banco_cuentas SET saldo=(saldo +" & CDbl(rs.Fields("importe").Value) & ") WHERE id_cuenta = " & rs.Fields("id_cuenta").Value)
                End If
                rs.Close()
                '------
            Else
                conn.Execute("UPDATE pagos_compras SET status = 'CANCELADO',fecha_cancelacion=NOW() WHERE id_forma_pago = " & lst_Pagos.SelectedItems.Item(0).Tag)
            End If

            MsgBox("Pago cancelado correctamente", MsgBoxStyle.Information, "Información")
            cargar()
        End If
    End Sub
    Private Sub lst_Pagos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_Pagos.Click
        If lst_Pagos.SelectedItems.Count > 0 Then
            If lst_Pagos.SelectedItems.Item(0).BackColor = Color.Red Then
                btn_cancelar_pago.Enabled = False
            Else
                btn_cancelar_pago.Enabled = True
            End If
        Else
            btn_cancelar_pago.Enabled = False
        End If
    End Sub

    Private Sub lst_Pagos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_Pagos.SelectedIndexChanged
        If lst_Pagos.SelectedItems.Count > 0 Then
            If lst_Pagos.SelectedItems.Item(0).BackColor = Color.Red Then
                btn_cancelar_pago.Enabled = False
            Else
                btn_cancelar_pago.Enabled = True
            End If
        Else
            btn_cancelar_pago.Enabled = False
        End If

    End Sub

    Private Sub tb_num_cheque_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_num_cheque.KeyDown
        If cb_cuenta_cheques.SelectedIndex <> -1 Then
            If e.KeyCode = Keys.Enter Then
                If verificar_cheque(tb_num_cheque.Text) Then
                    btn_aceptar.Focus()
                Else
                    tb_cheque_importe.Enabled = True
                    CBbancoCheques.Enabled = True
                    cb_cuenta_cheques.Enabled = True
                    fecha_pago_cheque.Enabled = True
                    tb_nombre_cheque.Enabled = True
                    btn_aceptar.Text = "Guardar"
                    fecha_pago_cheque.Value = Today
                    tb_nombre_cheque.Text = nombre_proveedor
                    tb_nombre_cheque.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub tb_num_cheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_num_cheque.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub
    Private Function verificar_cheque(ByVal num_cheque As Integer) As Boolean
        Dim status As Boolean = False

        'Conectar()
        rs.Open("SELECT importe,fecha,fecha_pago,banco,cuenta,nombre_cheque,status FROM pagos_compras WHERE id_forma_pago='2' AND num_cheque='" & num_cheque & "' AND id_cuenta='" & CType(cb_cuenta_cheques.SelectedItem, myItem).Value & "' ", conn)
        If rs.RecordCount > 0 Then
            status = True
            tb_cheque_importe.Text = rs.Fields("importe").Value
            CBbancoCheques.Text = rs.Fields("banco").Value
            cb_cuenta_cheques.Text = rs.Fields("cuenta").Value
            fecha_pago_cheque.Value = rs.Fields("fecha_pago").Value
            tb_nombre_cheque.Text = rs.Fields("nombre_cheque").Value
            btn_aceptar.Text = "Aceptar"
            tb_cheque_importe.Enabled = False
            CBbancoCheques.Enabled = False
            cb_cuenta_cheques.Enabled = False
            fecha_pago_cheque.Enabled = False
            tb_nombre_cheque.Enabled = False
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return status
    End Function

    Private Sub tb_num_cheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_num_cheque.Click
        tb_seleccionado = 1
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

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If tbcontrolPagos.SelectedIndex = 0 Then
            btn_aceptar_Click(sender, e)
        Else
            If tb_seleccionado = 2 Then
                btn_aceptar_Click(sender, e)
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
    Private Sub tb_transferencia_importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_transferencia_importe.Click
        tb_seleccionado = 2
    End Sub
    Private Sub tb_cheque_importe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_cheque_importe.Click
        tb_seleccionado = 2
    End Sub
    Private Sub tb_importe_nota_credito_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_importe_nota_credito.Click
        tb_seleccionado = 2
    End Sub

    Private Sub btn_guardar_cambios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cambios.Click

    End Sub
End Class