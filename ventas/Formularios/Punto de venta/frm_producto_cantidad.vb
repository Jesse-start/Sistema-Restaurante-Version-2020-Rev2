'Delegate Sub FunctionCall(ByVal param)
Public Class frm_producto_cantidad
    Dim cantidad As Decimal = 0
    Dim venta_peso As Integer
    Public modo As Integer '1--nueva linea 2.---modificar cantidad, 3.-cambia_precio
    Dim lectura_bascula As String
    Dim bascula_activada As Boolean = False
    Dim aux As String = ""
    Dim dato_recibido As Boolean = False
    Dim enviar_cantidad_ahora As Boolean = False
    Dim cancelar_cantidad As Boolean = False
    Dim i As Integer = 0
    Dim rx As New ADODB.Recordset

    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        groupBox3.ForeColor = Color.FromArgb(conf_colores(2))
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

        btn_bascula.BackColor = Color.FromArgb(conf_colores(8))
        btn_bascula.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_delete.BackColor = Color.FromArgb(conf_colores(8))
        btn_delete.ForeColor = Color.FromArgb(conf_colores(9))

        btn_ok.BackColor = Color.FromArgb(conf_colores(8))
        btn_ok.ForeColor = Color.FromArgb(conf_colores(9))

        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))

        btn_clear.BackColor = Color.FromArgb(conf_colores(8))
        btn_clear.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            tb_cantidad.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub
    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If tb_cantidad.TextLength > 0 Then
            tb_cantidad.Text = tb_cantidad.Text.Remove(tb_cantidad.TextLength - 1, 1)
            tb_cantidad.SelectionStart = Len(tb_cantidad.Text)
        End If
    End Sub
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        tb_cantidad.Text = ""
    End Sub
    Private Sub tb_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cantidad.KeyPress
        e.Handled = txtNumerico(tb_cantidad, e.KeyChar, True)
    End Sub
    Private Sub frm_producto_cantidad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If bascula_activada = True Then
            MsgBox("Debe detener la bascula", MsgBoxStyle.Exclamation, "Aviso")
            e.Cancel = True
        Else
            frm_principal3.preparar_para_codigo()
        End If
    End Sub
    Private Sub conf_inicio()
        bascula_activada = False
        aux = ""
        trm_verificar_bascula.Stop()
        trm_verificar_bascula.Enabled = False
        trm_enviar_dato.Stop()
        trm_enviar_dato.Enabled = False

        trm_cerrar_puerto.Stop()
        trm_cerrar_puerto.Enabled = False

    End Sub
    Private Sub frm_producto_cantidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If conf_pv(14) = 1 Then
            btn_bascula.Visible = True
            If conf_pv(15) = 0 Then
                btn_cancelar.Location = New Point(10, 406)
                groupBox3.Size = New Size(273, 581)
                Me.Size = New Size(289, 526)
            End If
        Else
            btn_bascula.Visible = False
            If conf_pv(15) = 0 Then
                btn_cancelar.Location = New Point(10, 329)
                groupBox3.Size = New Size(273, 487)
                Me.Size = New Size(289, 434)
            End If
        End If


        If venta_peso = 1 Then
            btn_bascula.Enabled = True
        End If

        cancelar_cantidad = False
        btn_bascula.Enabled = False
        tb_cantidad.Text = 1
        conf_inicio()
        aplicar_colores()
        '-----configuracion de inicio-bascula
        bascula_activada = False
        dato_recibido = False
        enviar_cantidad_ahora = False
        '------------------------
        If modo = 4 Then
            tb_cantidad.SelectAll()
            btn_bascula.Enabled = False
            groupBox3.Text = "Introduzca el nuevo precio"
            Me.Text = "Cambio de precio"
        Else
            groupBox3.Text = "Introduzca la cantidad"
            Me.Text = "Cantidad"
            If modo = 2 Or modo = 1 Or modo = 5 Then
                If venta_peso = 1 Then
                    btn_bascula.Enabled = True
                    '------ACTIVAMOS LA BASCULA AUTOMATICAMENTE
                    If conf_pv(1) = 1 Then
                        Try
                            If sp_bascula.IsOpen = False Then
                                sp_bascula.PortName = global_cfg_bascula_portname
                                sp_bascula.BaudRate = global_cfg_bascula_baudrate
                                sp_bascula.DataBits = global_cfg_bascula_databits
                                sp_bascula.DiscardNull = global_cfg_bascula_discarnull

                                If global_cfg_bascula_parity = "None" Then
                                    sp_bascula.Parity = IO.Ports.Parity.None
                                ElseIf global_cfg_bascula_parity = "Odd" Then
                                    sp_bascula.Parity = IO.Ports.Parity.Odd
                                ElseIf global_cfg_bascula_parity = "Even" Then
                                    sp_bascula.Parity = IO.Ports.Parity.Even
                                ElseIf global_cfg_bascula_parity = "Mark" Then
                                    sp_bascula.Parity = IO.Ports.Parity.Mark
                                ElseIf global_cfg_bascula_parity = "Space" Then
                                    sp_bascula.Parity = IO.Ports.Parity.Space
                                End If

                                sp_bascula.ReadBufferSize = global_cfg_bascula_readbuffersize
                                sp_bascula.ReadTimeout = global_cfg_bascula_readtimeout
                                sp_bascula.ReceivedBytesThreshold = global_cfg_bascula_recievedbytethreshold
                                sp_bascula.RtsEnable = global_cfg_bascula_rtsenable

                                If global_cfg_bascula_stopbits = "None" Then
                                    sp_bascula.StopBits = IO.Ports.StopBits.None
                                ElseIf global_cfg_bascula_stopbits = "One" Then
                                    sp_bascula.StopBits = IO.Ports.StopBits.One
                                ElseIf global_cfg_bascula_stopbits = "Two" Then
                                    sp_bascula.StopBits = IO.Ports.StopBits.Two
                                ElseIf global_cfg_bascula_stopbits = "OnePointFive" Then
                                    sp_bascula.StopBits = IO.Ports.StopBits.OnePointFive
                                End If

                                sp_bascula.WriteBufferSize = global_cfg_bascula_writebuffersize
                                sp_bascula.WriteTimeout = global_cfg_bascula_writetimeout

                                sp_bascula.Open()

                                bascula_activada = True
                                btn_bascula.Text = "Detener bascula (introducir cantidad manualmente)"

                                enviar_dato()
                                trm_verificar_bascula.Enabled = True
                                trm_verificar_bascula.Start()
                            Else
                                sp_bascula.Close()
                                bascula_activada = False
                                btn_bascula.Text = "Obtener de  bascula"
                                btn_ok.Enabled = True
                                btn_cancelar.Enabled = True
                                MsgBox("Verifique que la bascula se encuentre conectada y encendida", MsgBoxStyle.Exclamation, "Aviso")
                            End If
                        Catch ex As Exception
                            MsgBox("Verifique que la bascula se encuentre conectada en el puerto correcto y Cierre todos los demas programas.", MsgBoxStyle.Information, ex.Message)
                        End Try

                    End If
                    '-------------------------------------------------
                End If
            End If
        End If
        tb_cantidad.Select()
        tb_cantidad.Focus()
    End Sub

    Private Sub button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        bascula_activada = False
        btn_bascula.Text = "Obtener de  bascula"
        btn_ok.Enabled = True
        btn_cancelar.Enabled = True
        enviar_cantidad_ahora = True
        trm_enviar_dato.Enabled = True
        trm_enviar_dato.Start()
    End Sub
    public Sub enviar_cantidad()
        'Try
        If Trim(tb_cantidad.TextLength) <> 0 Then
            If modo = 1 Then
                '----ingresamos nueva linea----------------
                frm_principal3.actualizar_producto(CDec(tb_cantidad.Text), global_current_idproducto)
                Me.Close()
            ElseIf modo = 2 Then
                '----actualizamos linea
                frm_principal3.actualizar_producto(CDec(tb_cantidad.Text), global_current_idproducto)
                Me.Close()
                '--------------------
            ElseIf modo = 4 Then
                '----actualizamos precio
                frm_principal3.cambiar_precio(CDec(tb_cantidad.Text))
                Me.Close()
                '---------------------------------
            End If
        Else
            MsgBox("Introduzca la cantidad", MsgBoxStyle.Exclamation, "Aviso")
        End If
        'Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Aviso")
        ' End Try
    End Sub

    Private Sub btn_bascula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bascula.Click
        Try
            If bascula_activada = False Then
                If sp_bascula.IsOpen = False Then
                    sp_bascula.PortName = "COM1"
                    sp_bascula.BaudRate = 9600
                    sp_bascula.Open()

                    bascula_activada = True
                    btn_bascula.Text = "Detener bascula (introducir cantidad manualmente)"
                    dato_recibido = False

                    'btn_ok.Enabled = False
                    'btn_cancelar.Enabled = False
                    enviar_dato()
                    trm_verificar_bascula.Enabled = True
                    trm_verificar_bascula.Start()
                Else
                    sp_bascula.Close()
                    bascula_activada = False
                    btn_bascula.Text = "Obtener de  bascula"
                    btn_ok.Enabled = True
                    btn_cancelar.Enabled = True
                    MsgBox("Verifique que la bascula se encuentre conectada y encendida", MsgBoxStyle.Exclamation, "Aviso")
                End If
            Else
                bascula_activada = False
                btn_bascula.Text = "Obtener de  bascula"
                btn_ok.Enabled = True
                btn_cancelar.Enabled = True
            End If

        Catch ex As Exception
            MsgBox("Verifique que la bascula se encuentre conectada en el puerto correcto y Cierre todos los demas programas.", MsgBoxStyle.Information, ex.Message)
        End Try

    End Sub
    Private Sub enviar_dato()
        'dato_recibido = 0
        sp_bascula.Write("P")
    End Sub
    Private Sub leer_puerto()

        lectura_bascula = sp_bascula.ReadExisting()
        despliega_trama(lectura_bascula)

    End Sub
    Protected Sub despliega_trama(ByVal status As String)
        Invoke(New FunctionCall(AddressOf _status), status)
    End Sub
    Private Sub _status(ByVal status As String)
        Dim cantidad, total As String
        cantidad = ""
        total = ""
        Dim longitud As Integer = 0
        status = Replace(status, "k", "")
        status = Replace(status, "K", "")
        status = Replace(status, "g", "")
        status = Replace(status, "G", "")
        status = Replace(status, "l", "")
        status = Replace(status, "L", "")
        status = Replace(status, "b", "")
        status = Replace(status, "B", "")
        status = Replace(status, "o", "")
        status = Replace(status, "O", "")
        status = Replace(status, "z", "")
        status = Replace(status, "Z", "")
        status = Replace(status, "%", "")
        status = Replace(status, "T", "")
        status = Replace(status, "A", "")
        status = Replace(status, "R", "")
        status = Replace(status, "E", "")
        status = Replace(status, "t", "")
        status = Replace(status, "a", "")
        status = Replace(status, "r", "")
        status = Replace(status, "e", "")
        cantidad = Replace(status, " ", "")
        longitud = Len(cantidad)
        tb_cantidad.Text = cantidad

    End Sub
    Private Sub cerrar_puerto()
        sp_bascula.Close()
    End Sub
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sp_bascula.DataReceived
        dato_recibido = True
        leer_puerto()
        If bascula_activada = True Then
            enviar_dato()
        Else
            cerrar_puerto()
        End If
    End Sub
    Private Sub trm_enviar_dato_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sp_bascula.Write("P")
    End Sub

    Private Sub trm_verificar_bascula_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trm_verificar_bascula.Tick
        If dato_recibido = False Then
            trm_verificar_bascula.Stop()
            bascula_activada = False
            btn_bascula.Text = "Obtener de  bascula"
            btn_ok.Enabled = True
            btn_cancelar.Enabled = True
            sp_bascula.Close()
            MsgBox("Verifique que la bascula se encuentre conectada y encendida", MsgBoxStyle.Exclamation, "Aviso")

        End If
    End Sub

    Private Sub trm_enviar_dato_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trm_enviar_dato.Tick
        If enviar_cantidad_ahora = True Then
            If sp_bascula.IsOpen = False Then
                trm_enviar_dato.Stop()
                enviar_cantidad()
            End If
        End If
    End Sub

    Private Sub trm_cerrar_puerto_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trm_cerrar_puerto.Tick
        If sp_bascula.IsOpen = False Then
            trm_cerrar_puerto.Stop()
            Me.Close()
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        If bascula_activada = True Then
            trm_verificar_bascula.Stop()
            bascula_activada = False
            btn_bascula.Text = "Obtener de  bascula"
            btn_ok.Enabled = True
            btn_cancelar.Enabled = True
            trm_cerrar_puerto.Enabled = True
            trm_cerrar_puerto.Start()
        Else
            Me.Close()
        End If
    End Sub
    Private Sub btn_punto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_punto.MouseUp, btn_clear.MouseUp, btn_cancelar.MouseUp, btn0.MouseUp, btn1.MouseUp, btn2.MouseUp, btn3.MouseUp, btn4.MouseUp, btn5.MouseUp, btn6.MouseUp, btn7.MouseUp, btn8.MouseUp, btn9.MouseUp, btn_ok.MouseUp, btn_bascula.MouseUp, btn_delete.MouseUp
        If TypeOf sender Is Button Then
            sender.backcolor = Color.FromArgb(conf_colores(8))
        End If
    End Sub

    Private Sub btn_punto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_punto.MouseDown, btn_clear.MouseDown, btn_cancelar.MouseDown, btn0.MouseDown, btn1.MouseDown, btn2.MouseDown, btn3.MouseDown, btn4.MouseDown, btn5.MouseDown, btn6.MouseDown, btn7.MouseDown, btn8.MouseDown, btn9.MouseDown, btn_ok.MouseDown, btn_bascula.MouseUp, btn_delete.MouseDown
        If TypeOf sender Is Button Then
            sender.backcolor = Color.FromArgb(conf_colores(1))
        End If
    End Sub
    Private Function global_cfg_id_pantalla() As Integer
        Throw New NotImplementedException
    End Function
End Class