Public Class frm_validaciones
    Implements DPFP.Capture.EventHandler
    Private Capturer As DPFP.Capture.Capture
    Public tipo_validacion As Integer '1-precio-especial 2.-cambio de precio 3.-catalogo_precios
    Private id_empleado_validacion As Integer
    Public origen_validacion_cliente As Integer '0 desde clientes y 1 desde principal2 
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
    Protected Sub status(ByVal status)
        Invoke(New FunctionCall(AddressOf _status), status)
    End Sub
    Private Sub _status(ByVal status)
        lbl_status_dispositivo.Text = status
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        lbl_descripcion.ForeColor = Color.FromArgb(conf_colores(13))
        ' lbl_usuario.ForeColor = Color.FromArgb(conf_colores(13))
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

        delbutton.BackColor = Color.FromArgb(conf_colores(8))
        delbutton.ForeColor = Color.FromArgb(conf_colores(9))

        acbutton.BackColor = Color.FromArgb(conf_colores(8))
        acbutton.ForeColor = Color.FromArgb(conf_colores(9))

        validarbtn.BackColor = Color.FromArgb(conf_colores(8))
        validarbtn.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub frm_validaciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        deshabilitar_captura()
    End Sub
    Private Sub frm_validaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        If tipo_validacion = 1 Then
            lbl_descripcion.Text = "Este cliente  tiene asignado un precio especial que requiere validación."
        ElseIf tipo_validacion = 2 Then
            lbl_descripcion.Text = "Para cambiar el precio del producto es necesario realizar una validacion."
        ElseIf tipo_validacion = 3 Then
            lbl_descripcion.Text = "Para cambiar el precio del producto es necesario realizar una validacion."
        End If
        tb_codigo.Text = ""
        tb_codigo.Select()
        tb_codigo.Focus()
        habilitar_captura()
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

    Private Sub validarbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles validarbtn.Click
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
        'If Trim(tb_codigo.TextLength) <> 0 Then
        ' Dim id_empleado_validacion As Integer = 0
        Dim precio_especial As Integer = 0
        Dim cambio_precio As Integer = 0
        'Conectar()
        ' rs.Open("SELECT id_empleado from usuario WHERE  password = MD5(CONCAT(id_empleado,'" & UCase(tb_codigo.Text) & "'))", conn)
        'If rs.RecordCount > 0 Then
        '--verificamos los permisos---
        'id_empleado_validacion = rs.Fields("id_empleado").Value
        'Dim rs As New ADODB.Recordset
        rs.Open(" SELECT perfil.precio_especial,perfil.cambio_precio FROM perfil JOIN perfil_empleado ON perfil_empleado.id_perfil=perfil.id_perfil WHERE perfil_empleado.id_empleado='" & id_empleado_validacion & "'", conn)
        If rs.RecordCount > 0 Then
            precio_especial = rs.Fields("precio_especial").Value
            cambio_precio = rs.Fields("cambio_precio").Value
        End If
        rs.Close()
        '-----------------------------
        'rs.Close()
        'conn.close()

        'End If
        If tipo_validacion = 1 Then 'precio_especial
            If precio_especial = 1 Then
                Me.Hide()
                If origen_validacion_cliente = 0 Then
                    frm_clientes.cargar_cliente()
                Else
                    frm_principal3.cargar_cliente()
                End If

                Me.Close()
            Else
                tb_codigo.Text = ""
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO"
                frm_aviso.ShowDialog()
            End If
        ElseIf tipo_validacion = 2 Then 'cambio_precio
            If cambio_precio = 1 Then
                frm_producto_cantidad.modo = 4
                frm_producto_cantidad.ShowDialog()
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If
        ElseIf tipo_validacion = 3 Then 'catalogo_precio

            If cambio_precio = 1 Then
                frm_cambio_precio.guardar_cambio_precios()
                Me.Close()
            Else
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "SIN PERMISO"
                frm_aviso.ShowDialog()
                tb_codigo.Text = ""
            End If

        End If
        'Else
        'MsgBox("Para realizar esta operacion es necesario realizar uno de los siguientes pasos" & vbCrLf & "    * Ingrese codigo de verificacion" & vbCrLf & "    * Toque el lector de huellas dactilares con el dedo indice de su mano derecha ")
        'End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
End Class