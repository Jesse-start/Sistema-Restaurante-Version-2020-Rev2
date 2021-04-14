Public Class frm_validacion
    Implements DPFP.Capture.EventHandler
    Private Capturer As DPFP.Capture.Capture

    Public id_venta As Integer
    Public id_venta_cobro As Integer
    Public tipo_de_cobro As String
    Private id_empleado_validacion As Integer
    Public id_tipo_operacion As Integer
    Public origen_cancelacion_apartado As Integer ' 0 para desde el detalle de apartado, 1 para cancelacion general
    Public validacion As Integer 'cadena que indica el tipo de validacion 0 cancelar_venta,1 cortex ,2 corte de caja,3 regalias ,4 cancelar pagos,5-ajuste inventario, 6 no afectar_caja,7 conversiones, 8 CANCELAR APARTADO, 9 actualizar comentarios de apartado
    Private Sub habilitar_captura()
        Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
        Capturer.EventHandler = Me                              ' Subscribe for capturing events.
        StartCapture()
    End Sub
    Private Sub deshabilitar_captura()
        StopCapture()
        Capturer.EventHandler = Nothing
        Capture = Nothing
    End Sub
    Private Sub StartCapture()
        Capturer.StartCapture()
    End Sub
    Protected Sub StopCapture()
        Capturer.StopCapture()
    End Sub
    Private Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        Process(Sample)
    End Sub
    Private Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        status("Lector de huellas dactilares desconectado")
    End Sub
    Private Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
    End Sub
    Private Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
    End Sub
    Private Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
    End Sub
    Private Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        status("Lector de huellas dactilares conectado")
    End Sub
    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()        ' Create a feature extractor
        Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim features As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, feedback, features) ' TODO: return features as a result?
        If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
            Return features
        Else
            Return Nothing
        End If
    End Function
    Protected Overridable Sub Process(ByVal Sample As DPFP.Sample)
        Dim WMP As New WMPLib.WindowsMediaPlayer
        WMP.URL = System.IO.Directory.GetCurrentDirectory() & "/beep-7.wav"
        WMP.controls.play()
        Dim validado As Boolean = False
        Dim Template As DPFP.Template
        Dim Verificator As DPFP.Verification.Verification
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)
        Template = New DPFP.Template()
        Verificator = New DPFP.Verification.Verification()
        ' Check quality of the sample and start verification if it's good
        If Not features Is Nothing Then
            ' Compare the feature set with our template
            'Conectar()
            rs.Open("SELECT id_usuario,usuario.id_empleado,usuario,huella FROM usuario INNER JOIN empleado ON usuario.id_empleado=empleado.id_empleado WHERE huella IS NOT  null", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Template.DeSerialize(CType(rs.Fields("huella").Value, Byte()))
                    Template.DeSerialize(Template.Bytes)
                    Dim result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
                    Verificator.Verify(features, Template, result)
                    If result.Verified Then
                        cargar_id_empleado_huella(rs)
                        validado = True
                    End If
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
        End If
        If validado = False Then
            frm_aviso.ShowDialog()
        Else
            validar_usuario("ok")
        End If
    End Sub

    Protected Sub validar_usuario(ByVal status)
        Invoke(New FunctionCall(AddressOf _validar_usuario), status)
    End Sub
    Private Sub _validar_usuario(ByVal consulta)
        validar_permiso()
    End Sub
    Protected Sub cargar_id_empleado_huella(ByVal status)
        Invoke(New FunctionCall(AddressOf _cargar_id_empleado_huella), status)
    End Sub
    Private Sub _cargar_id_empleado_huella(ByVal consulta)
        id_empleado_validacion = consulta.Fields("id_empleado").Value
        StopCapture()
        Capturer.EventHandler = Nothing
        Capture = Nothing
        Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
        Capturer.EventHandler = Me                              ' Subscribe for capturing events.
        StartCapture()
    End Sub

    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))

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

        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))

        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))

        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))
        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
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
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Trim(tb_codigo.TextLength) <> 0 Then
            id_empleado_validacion = 0

            'Conectar()
            rs.Open("SELECT id_empleado from usuario WHERE  password = MD5(CONCAT(id_empleado,'" & UCase(tb_codigo.Text) & "'))", conn)
            If rs.RecordCount > 0 Then
                id_empleado_validacion = rs.Fields("id_empleado").Value
            End If
            rs.Close()
            'conn.close()
            validar_permiso()
        Else
            MsgBox("Para realizar esta operacion es necesario realizar uno de los siguientes pasos" & vbCrLf & "    * Ingrese codigo de verificacion" & vbCrLf & "    * Toque el lector de huellas dactilares con el dedo indice de su mano derecha ")
        End If
    End Sub
    Private Sub validar_permiso()
        Dim cancelar_venta As Integer = 0
        Dim _corte_caja As Integer = 0
        Dim _corte_x As Integer = 0
        Dim cancelar_pagos As Integer = 0
        Dim regalias As Integer = 0
        Dim ajuste_inventario As Integer = 0
        Dim pagos_proveedor As Integer = 0
        Dim cobro_creditos As Integer = 0
        Dim ajuste_conversiones As Integer = 0
        Dim cancelar_apartado As Integer = 0
        Dim rs As New ADODB.Recordset
        Dim rw As New ADODB.Recordset
        'Conectar()
        '--verificamos los permisos---

        rs.Open(" SELECT perfil.corte_caja,perfil.corte_x,perfil.cancelar_venta,perfil.cancelar_pagos,perfil.precio_especial,perfil.regalias,perfil.ajuste_inventario,perfil.pagos,perfil.cobros_creditos,perfil.ajuste_conversiones,perfil.cancelar_apartado FROM perfil JOIN perfil_empleado ON perfil_empleado.id_perfil=perfil.id_perfil WHERE perfil_empleado.id_empleado='" & id_empleado_validacion & "'", conn)
        If rs.RecordCount > 0 Then
            cancelar_venta = rs.Fields("cancelar_venta").Value
            _corte_caja = rs.Fields("corte_caja").Value
            _corte_x = rs.Fields("corte_x").Value
            cancelar_pagos = rs.Fields("cancelar_pagos").Value
            regalias = rs.Fields("regalias").Value
            ajuste_inventario = rs.Fields("ajuste_inventario").Value
            pagos_proveedor = rs.Fields("pagos").Value
            cobro_creditos = rs.Fields("cobros_creditos").Value
            ajuste_conversiones = rs.Fields("ajuste_conversiones").Value
            cancelar_apartado = rs.Fields("cancelar_apartado").Value
        End If
        rs.Close()
        '-----------------------------
        'conn.close()

        If validacion = 0 Then 'cancelar venta
            If cancelar_venta = 1 Then
                'Conectar()

                conn.Execute("UPDATE venta  SET id_empleado_caja='" & global_id_empleado & "',id_empleado_validacion='" & id_empleado_validacion & "', status = 'CANCELADA' WHERE id_venta = " & id_venta)
                rw.Open("SELECT id_producto,cantidad,id_almacen FROM venta_detalle WHERE id_venta='" & id_venta & "'", conn)
                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & rw.Fields("cantidad").Value & " ) WHERE id_producto = '" & rw.Fields("id_producto").Value & "' AND id_almacen=" & rw.Fields("id_almacen").Value)
                        rw.MoveNext()
                    End While
                End If
                rw.Close()

                '---descontamos y registramos productos compuesto-----

                rw.Open("SELECT id_insumo,cantidad FROM venta_insumo WHERE id_venta=" & id_venta, conn)
                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        Dim id_almacen = obtener_idalmacen(rw.Fields("id_insumo").Value)
                        conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad +" & CDec(rw.Fields("cantidad").Value) & ") WHERE id_producto=" & rw.Fields("id_insumo").Value & " AND id_almacen=" & id_almacen & "")
                        rw.MoveNext()
                    End While
                End If
                conn.Execute("DELETE FROM venta_insumo WHERE id_venta=" & id_venta)
                rw.Close()
                '-------------------------------- ----------------------
                'conn.close()
                Generar_Formato_venta_retail_media(id_venta, True, False)
                frm_caja.obtener_cuentasxcobrar()
                Me.Close()
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.btn_ok.Visible = True
                frm_aviso.Lbl_aviso.Text = "VENTA CANCELADO EXITOSAMENTE"
                frm_aviso.ShowDialog()
                If frm_caja.tabla_caja.Rows.Count = 0 Then
                    frm_caja.Close()

                    frm_principal3.BringToFront()

                End If
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 1 Then 'cortex
            If _corte_x = 1 Then
                'Me.Hide()

                Dim total_ventas As Decimal = 0
                Dim total_retiros As Decimal = 0
                Dim total_depositos As Decimal = 0
                Dim saldo_inicial As Decimal = 0
                Dim mensaje As String = ""

                total_ventas = corte_x()
                total_retiros = retiros()
                total_depositos = depositos()

                mensaje = "     Total Ventas: " & FormatCurrency(total_ventas) & ", Total Depositos: " & FormatCurrency(total_depositos) & ", Total Retiros: " & FormatCurrency(total_retiros) & ", Pago a Proveedores: " & FormatCurrency(pago_proveedores_efectivo()) & ", Devoluciones: " & FormatCurrency(devoluciones) & vbCrLf & ",Total en caja: " & FormatCurrency(saldo_caja())
                'MsgBox(mensaje, MsgBoxStyle.Information, "Corte x")
                Me.Close()
                frm_aviso.Temporizador.Interval = 6000
                frm_aviso.btn_ok.Visible = True
                frm_aviso.Lbl_aviso.Text = mensaje
                frm_aviso.ShowDialog()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 2 Then 'corte caja
            If _corte_caja = 1 Then
                Me.Hide()
                frm_declaracion_cajero.ShowDialog()
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 3 Then 'regalias
            If regalias = 1 Then
                'Conectar()
                conn.Execute("UPDATE venta  SET id_empleado_caja='" & global_id_empleado & "',id_empleado_validacion='" & id_empleado_validacion & "', status = 'REGALIA' WHERE id_venta = " & id_venta)
                'conn.close()
                frm_caja.obtener_cuentasxcobrar()
                'MsgBox("Regalia registrada correctamente")
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "REGALIA REGISTRADA CORRECTAMENTE"
                frm_aviso.ShowDialog()
                Me.Close()

                If conf_pv(16) = 1 Then
                    If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                        Generar_Formato_venta_retail(id_venta, False)
                    ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                        Generar_Formato_venta_retail_media(id_venta, False, True)
                    ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                        Generar_Formato_venta_apartado(id_venta)
                    End If
                End If


                If frm_caja.tabla_caja.Rows.Count = 0 Then
                    frm_caja.Close()
                    frm_principal3.BringToFront()
                End If
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 4 Then 'cancelar pagos
            If cancelar_pagos = 1 Then
                If tipo_de_cobro = "Transferencia" Then
                    'Conectar()
                    conn.Execute("UPDATE pagos_ventas SET status = 'CANCELADO',fecha_cancelacion=NOW(),id_empleado_caja='" & global_id_empleado & "',id_empleado_validacion='" & id_empleado_validacion & "' WHERE id_pago_ventas = " & id_venta_cobro)
                    '----sacamos la cuenta 
                    rs.Open("SELECT importe,id_forma_pago,id_cuenta_receptor FROM pagos_ventas WHERE id_pago_ventas=" & id_venta_cobro, conn)
                    If rs.RecordCount > 0 Then
                        conn.Execute("UPDATE banco_cuentas SET saldo=(saldo -" & CDbl(rs.Fields("importe").Value) & ") WHERE id_cuenta = " & rs.Fields("id_cuenta_receptor").Value)
                    End If
                    rs.Close()
                    '------
                    'conn.close()
                    'conn = Nothing
                Else
                    'Conectar()
                    conn.Execute("UPDATE pagos_ventas SET status = 'CANCELADO',fecha_cancelacion=NOW(),id_empleado_caja='" & global_id_empleado & "',id_empleado_validacion='" & id_empleado_validacion & "' WHERE id_pago_ventas = " & id_venta_cobro)
                    'conn.close()
                    'conn = Nothing
                End If

                'MsgBox("Pago cancelado correctamente", MsgBoxStyle.Information, "Información")
                frm_formas_pago_ventas.cargar()
                'frm_formas_pago_ventas.llenar_lista_cobros()
                Me.Close()
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "PAGO CANCELADO CORRECTAMENTE"
                frm_aviso.ShowDialog()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 5 Then 'ajuste invetario
            If ajuste_inventario = 1 Then
                frm_ajuste_inventario.ShowDialog()
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 6 Then 'autorizar pago/cobros

            If id_tipo_operacion = 0 Then
                If cobro_creditos = 1 Then
                    frm_formas_pago_ventas.guardar_cobro(0)
                    Me.Close()
                Else
                    frm_aviso.Temporizador.Interval = 200
                    frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                    frm_aviso.ShowDialog()
                    tb_codigo.Text = ""
                End If

            ElseIf id_tipo_operacion = 1 Then
                If pagos_proveedor = 1 Then
                    frm_formas_pago.guardar_pago(0)
                    Me.Close()
                Else
                    frm_aviso.Temporizador.Interval = 200
                    frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                    frm_aviso.ShowDialog()
                    tb_codigo.Text = ""
                End If


            ElseIf id_tipo_operacion = 2 Then
                If cobro_creditos = 1 Then
                    frm_formas_pago_factura.guardar_cobro(0)
                    Me.Close()
                Else
                    frm_aviso.Temporizador.Interval = 200
                    frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                    frm_aviso.ShowDialog()
                    tb_codigo.Text = ""
                End If
            End If
        ElseIf validacion = 7 Then
            If ajuste_conversiones = 1 Then
                frm_conversiones.aplicar_conversion()
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 8 Then
            If cancelar_apartado = 1 Then
                If origen_cancelacion_apartado = 0 Then
                    If global_frm_apartado_detalle = 1 Then
                        frm_apartado_detalle.cancelar_apartado()
                    End If
                End If
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf validacion = 9 Then
            If cancelar_apartado = 1 Then
                If global_frm_apartado_detalle = 1 Then
                    frm_apartado_detalle.actualizar_comentarios_apartado()
                End If
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO PARA VALIDAR"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        End If
    End Sub
    Private Function obtener_idalmacen(ByVal id_producto As Integer) As Integer
        Dim id_almacen As Integer = 0
        Dim rx As New ADODB.Recordset
        rx.Open("SELECT id_almacen FROM producto WHERE id_producto=" & id_producto, conn)
        If rx.RecordCount > 0 Then
            id_almacen = rx.Fields("id_almacen").Value
        End If
        rx.Close()
        Return id_almacen
    End Function
    Private Sub frm_validacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        deshabilitar_captura()
        If global_frm_apartado_detalle = 1 Then
            frm_apartado_detalle.cargar_apartado_detalle(frm_apartado_detalle.current_id_apartado)
        End If

        If global_frm_cancelaciones = 1 Then
            Frm_cancelaciones.cargar_documento(Frm_cancelaciones.current_id_doc)
        End If
    End Sub
    Private Sub frm_validacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        habilitar_captura()
        aplicar_colores()
        tb_codigo.Text = ""
        id_empleado_validacion = 0
        tb_codigo.Select()
        tb_codigo.Focus()
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
    End Sub
    Private Sub tb_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_codigo.KeyPress
        'e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub
    Protected Sub status(ByVal status)
        Invoke(New FunctionCall(AddressOf _status), status)
    End Sub
    Private Sub _status(ByVal status)
        lbl_status_dispositivo.Text = status
    End Sub

    Private Function global_cfg_id_pantalla() As Integer
        Throw New NotImplementedException
    End Function

End Class