Imports System
Imports System.Management
'Delegate Sub FunctionCall(ByVal param As Object)
Public Class frm_usuarios
    Implements DPFP.Capture.EventHandler
    Private Capturer As DPFP.Capture.Capture
    Dim cont_lst As Integer
    Dim no_vendedor As Boolean
    Private Sub frm_usuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        'frm_principal3.preparar_para_codigo()
        'Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
        'Capturer.EventHandler = Me                              ' Subscribe for capturing events.
        'StartCapture()
        conn.Close()
        conn = Nothing
    End Sub
    
    Protected Sub load_splashscreen_alias(ByVal _alias As String)
        Invoke(New FunctionCall(AddressOf _statusalias), _alias)
    End Sub
    Private Sub _statusalias(ByVal _alias As Object)
        SplashScreen.lbl_alias.Text = _alias
    End Sub
    Protected Sub load_splashscreen_razon(ByVal _alias As String)
        Invoke(New FunctionCall(AddressOf _statusrazon), _alias)
    End Sub
    Private Sub _statusrazon(ByVal _alias As Object)
        SplashScreen.lbl_razon.Text = _alias
    End Sub
    Protected Sub load_splashscreen_rfc(ByVal _alias As String)
        Invoke(New FunctionCall(AddressOf _statusrfc), _alias)
    End Sub
    Private Sub _statusrfc(ByVal _alias As Object)
        SplashScreen.lbl_rfc.Text = _alias
    End Sub
    Private Sub obtener_lineas_ticket()
        '--OBTENEMOS LINEAS DE TICKET
        limpiar_lineas_ticket()
        Dim i As Integer = 0
        Dim j As Integer = 0
        'Conectar()
        rs.Open("SELECT * FROM cfg_lineas_ticket  ORDER BY id_lineas ASC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                If rs.Fields("id_tipo").Value = 1 Then
                    lineas_ticket_cabeza(i) = rs.Fields("descripcion").Value
                    i += 1
                Else
                    lineas_ticket_pie(j) = rs.Fields("descripcion").Value
                    j += 1
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '------------------------
    End Sub
    Private Sub obtener_dir_documentos()
        ''Conectar()
        rs.Open("SELECT * FROM cfg_documentos WHERE id_cfg_documentos=1", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("dir_facturas").Value) Then
                global_dir_facturas = rs.Fields("dir_facturas").Value
            Else
                global_dir_facturas = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            End If
            If Not IsDBNull(rs.Fields("dir_cotizaciones").Value) Then
                global_dir_cotizaciones = rs.Fields("dir_cotizaciones").Value
            Else
                global_dir_cotizaciones = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_cfg_pv()
        ''Conectar()
        rs.Open("SELECT * FROM cfg_punto_venta WHERE id_cfg_punto_venta=1", conn)
        If rs.RecordCount > 0 Then
            conf_pv(0) = rs.Fields("cfg_pago_express").Value
            conf_pv(1) = rs.Fields("cfg_activar_bascula").Value
            conf_pv(2) = rs.Fields("cfg_varias_lineas").Value
            conf_pv(3) = rs.Fields("cfg_cantidades_negativas").Value
            conf_pv(4) = rs.Fields("cfg_mostrar_codigo").Value
            conf_pv(5) = rs.Fields("cfg_copia_ticket").Value
            conf_pv(7) = rs.Fields("cfg_ticket_pago").Value
            conf_pv(8) = rs.Fields("cfg_cantidad_codigo").Value
            conf_pv(9) = rs.Fields("cfg_imprimir_orden_entrega").Value
            conf_pv(10) = rs.Fields("cfg_mostrar_codigo_venta_detalle").Value
            conf_pv(11) = rs.Fields("cfg_ver_pedidos_apartados").Value
            conf_pv(12) = rs.Fields("cfg_ajustar_precios").Value
            conf_pv(13) = rs.Fields("cfg_mostrar_barra_tareas").Value
            conf_pv(14) = rs.Fields("cfg_mostrar_boton_bascula").Value
            conf_pv(15) = rs.Fields("cfg_ingresar_observacion_producto").Value
            conf_pv(16) = rs.Fields("cfg_imprimir_formatos_carta").Value
            conf_pv(17) = rs.Fields("cfg_imprimir_productos_corte").Value
            conf_pv(18) = rs.Fields("cfg_imprimir_comprobante_pago").Value
            conf_pv(19) = rs.Fields("cfg_imprimir_logotipo_ticket").Value
            conf_pv(20) = rs.Fields("cfg_imprimir_texto_sin_formato").Value
            conf_pv(21) = rs.Fields("cfg_impresora_matriz").Value

            cfg_fuente_tituto = rs.Fields("fuente_titulo").Value
            cfg_fuente_producto = rs.Fields("fuente_producto").Value
            cfg_tamaño_fuente_titulo = rs.Fields("size_titulo").Value
            cfg_tamaño_fuente_producto = rs.Fields("size_producto").Value
            cfg_longitud_descripcion = rs.Fields("long_descripcion").Value
            cfg_longitud_maxima_ticket = rs.Fields("long_maxima").Value
            cfg_longitud_linea_productos = rs.Fields("long_linea_productos").Value
            cfg_productos_mayusculas_ticket = rs.Fields("productos_mayusculas").Value
            cfg_escala_logo_ticket = rs.Fields("escala_logo_ticket").Value
            cfg_escala_altura_logo = rs.Fields("escala_altura_logo").Value
            cfg_longitud_titulo = rs.Fields("longitud_titulo").Value
            cfg_espacios_antes_total = rs.Fields("espacios_antes_total").Value
            cfg_margen_izq_total = rs.Fields("margen_izq_total").Value

            If conf_pv(13) = 1 Then
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                Me.MinimizeBox = True
                Me.MaximizeBox = True
            End If
            Me.WindowState = Windows.Forms.FormWindowState.Maximized
        End If
        rs.Close()

        rs.Open("SELECT enviar_despues_generar FROM cfg_correo WHERE id_cfg_correo=1", conn)
        If rs.RecordCount > 0 Then
            conf_pv(6) = rs.Fields("enviar_despues_generar").Value
        End If
        rs.Close()

        rs.Open("SELECT * FROM cfg_formato_impresion WHERE id_cfg_formato_impresion='1'", conn)
        If rs.RecordCount > 0 Then
            conf_pv_id_formato(0) = rs.Fields("id_formato_nota_venta").Value
            conf_pv_id_formato(1) = rs.Fields("id_formato_orden_entrega").Value
            conf_pv_id_formato(2) = rs.Fields("id_formato_cotizacion").Value
            conf_pv_id_formato(3) = rs.Fields("id_formato_cxcobrar").Value
        End If
        rs.Close()



        rs.Open("SELECT * FROM cfg_bascula WHERE id_cfg_bascula='1'", conn)
        If rs.RecordCount > 0 Then
            global_cfg_bascula_portname = rs.Fields("portname").Value
            global_cfg_bascula_baudrate = rs.Fields("baudrate").Value
            global_cfg_bascula_databits = rs.Fields("databits").Value
            global_cfg_bascula_discarnull = rs.Fields("discarnull").Value
            global_cfg_bascula_parity = rs.Fields("parity").Value
            global_cfg_bascula_readbuffersize = rs.Fields("readbuffersize").Value
            global_cfg_bascula_readtimeout = rs.Fields("readtimeout").Value
            global_cfg_bascula_recievedbytethreshold = rs.Fields("receivedbytesthreshold").Value
            global_cfg_bascula_rtsenable = rs.Fields("rtsenable").Value
            global_cfg_bascula_stopbits = rs.Fields("stopbits").Value
            global_cfg_bascula_writebuffersize = rs.Fields("writebuffersize").Value
            global_cfg_bascula_writetimeout = rs.Fields("writetimeout").Value
        End If
        rs.Close()
        leer_cfg_terminal()

    End Sub
    Private Sub obtener_conf_colores()
        '---obtenemos la conf de colores de punto de venta
        ''Conectar()
        rs.Open("Select * FROM cfg_colores WHERE id_cfg_color=1", conn)
        If rs.RecordCount > 0 Then
            conf_colores(1) = rs.Fields("cfg_1").Value
            conf_colores(2) = rs.Fields("cfg_2").Value
            conf_colores(3) = rs.Fields("cfg_3").Value
            conf_colores(4) = rs.Fields("cfg_4").Value
            conf_colores(5) = rs.Fields("cfg_5").Value
            conf_colores(6) = rs.Fields("cfg_6").Value
            conf_colores(7) = rs.Fields("cfg_7").Value
            conf_colores(8) = rs.Fields("cfg_8").Value
            conf_colores(9) = rs.Fields("cfg_9").Value
            conf_colores(10) = rs.Fields("cfg_10").Value
            conf_colores(11) = rs.Fields("cfg_11").Value
            conf_colores(12) = rs.Fields("cfg_12").Value
            conf_colores(13) = rs.Fields("cfg_13").Value
            conf_colores(14) = rs.Fields("cfg_14").Value
            conf_colores(15) = rs.Fields("cfg_15").Value
            conf_colores(16) = rs.Fields("cfg_16").Value
            conf_colores(17) = rs.Fields("cfg_17").Value
            conf_colores(18) = rs.Fields("cfg_18").Value
            conf_colores(19) = rs.Fields("cfg_19").Value
            conf_colores(20) = rs.Fields("cfg_20").Value
            conf_colores(21) = rs.Fields("cfg_21").Value
            conf_colores(22) = rs.Fields("cfg_22").Value
            conf_colores(23) = rs.Fields("cfg_23").Value
            conf_colores(24) = rs.Fields("cfg_24").Value
            conf_colores(28) = rs.Fields("cfg_28").Value
            'colores factura
            conf_colores(25) = rs.Fields("cfg_25").Value
            conf_colores(26) = rs.Fields("cfg_26").Value
            conf_colores(27) = rs.Fields("cfg_27").Value

        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '--------------------
    End Sub
    Private Sub aplicar_colores()
        SplashScreen.BackColor = Color.FromArgb(conf_colores(1))
        SplashScreen.lbl_alias.ForeColor = Color.FromArgb(conf_colores(13))
        SplashScreen.lbl_razon.ForeColor = Color.FromArgb(conf_colores(13))
        SplashScreen.lbl_rfc.ForeColor = Color.FromArgb(conf_colores(13))
        Me.BackColor = Color.FromArgb(conf_colores(1))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir_apagar.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir_apagar.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub frm_usuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim _datos_cliente As String = Nothing
            Dim _licencia As String = ""
            'frm_redondear.ShowDialog()
            'Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
            'Capturer.EventHandler = Me                              ' Subscribe for capturing events.
            'StartCapture()
            habilitar_captura()
            Conectar()
            'If conectado Then
            'conn.close()
            ''conn = Nothing
            'Else
            'Exit Sub
            'End If
            obtener_conf_colores()
            aplicar_colores()
            'Conectar()
            rs.Open("SELECT logotipo from configuracion WHERE id_configuracion=1", conn)
            If rs.RecordCount > 0 Then
                Dim bDatos As Byte()
                Dim imagen As System.Drawing.Image
                Dim saveimagen As System.Drawing.Image
                If Not IsDBNull(rs.Fields("logotipo").Value) Then
                    bDatos = CType(rs.Fields("logotipo").Value, Byte())
                    imagen = New Bitmap(Bytes_Imagen(bDatos))
                    saveimagen = New Bitmap(Bytes_Imagen(bDatos))
                Else
                    imagen = ventas.My.Resources._50CENTAVOS
                End If
                global_logotipo = imagen
                SplashScreen.Pb_logo.Image = imagen
                saveimagen.Save(Application.StartupPath & "/logo.png", System.Drawing.Imaging.ImageFormat.Png)
            End If
            rs.Close()

            rs.Open("SELECT razon_social,alias,rfc,domicilio,id_pantalla,habilitar_cfdi,serie FROM configuracion WHERE id_configuracion=1", conn)
            If rs.RecordCount > 0 Then
                _datos_cliente = rs.Fields("alias").Value & rs.Fields("razon_social").Value & rs.Fields("rfc").Value & rs.Fields("domicilio").Value

                load_splashscreen_alias(rs.Fields("alias").Value)
                load_splashscreen_razon(rs.Fields("razon_social").Value)
                global_razon_social = rs.Fields("razon_social").Value
                load_splashscreen_rfc(rs.Fields("rfc").Value)

                lineas_reporte(0) = rs.Fields("alias").Value
                lineas_reporte(1) = rs.Fields("razon_social").Value
                lineas_reporte(2) = rs.Fields("domicilio").Value
                lineas_reporte(3) = rs.Fields("rfc").Value
                global_rfc = rs.Fields("rfc").Value
                global_habilitar_cfdi = rs.Fields("habilitar_cfdi").Value
                global_serie = rs.Fields("serie").Value

            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            obtener_cfg_pv()
            obtener_id_sucursal()
            obtener_dir_documentos()
            obtener_lineas_ticket()
            If global_id_sucursal <> 0 Then
                Centrar(gb_inicio)
                obtener_usuarios()
            Else
                MsgBox("No se ha configurado la sucursal para este punto de venta.Realice esta configuracion desde el administrador")
                End
            End If
            'validar_licencia(_datos_cliente)
            'MsgBox(fecha_internet.GetTime)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Excepcion interna")
        End Try

        
    End Sub
    Private Sub validar_licencia(ByVal _datos_cliente As String)
        Dim _licencia As String = ""

        Dim oMotherB As Object = Nothing
        Dim oDiskB As Object = Nothing
        ' Dim serie_motherboard As String = Nothing
        Dim serie_diskdrive As String = Nothing
        Dim oWMG As Object = GetObject("WinMgmts:")

        oMotherB = oWMG.InstancesOf("Win32_BaseBoard")
        oDiskB = oWMG.InstancesOf("Win32_PhysicalMedia")
        'For Each obj As Object In oMotherB

        'serie_motherboard += obj.SerialNumber

        'Next
        For Each obj As Object In oDiskB
            serie_diskdrive += obj.SerialNumber
        Next
        serie_diskdrive = Trim(Replace(serie_diskdrive, " ", ""))
        Dim registrado As Boolean = False
        ''Conectar()
        'rs.Open("SELECT id_licencia FROM cfg_licencia WHERE licencia='" & MD5(serie_motherboard & _datos_cliente & serie_diskdrive) & "'", conn)
        If System.IO.File.Exists(archivo_licencia) = True Then
            Dim objReader As New System.IO.StreamReader(archivo_licencia)
            _licencia = objReader.ReadLine()
            objReader.Close()
        End If

        If _licencia = MD5(_datos_cliente & serie_diskdrive & "rosadeabril") Then
            registrado = True
        Else
            registrado = False
            StopCapture()
        End If

        If registrado = False Then
            frm_aviso.Temporizador.Interval = 2000
            frm_aviso.Lbl_aviso.Text = "El sistema no tiene licencia" & vbCrLf & " Contacte a su proveedor"
            frm_aviso.ShowDialog()
            gb_usuarios.Enabled = False
        End If
    End Sub

    Public Sub habilitar_captura()
        Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
        Capturer.EventHandler = Me                              ' Subscribe for capturing events.
        StartCapture()
    End Sub
    Public Sub deshabilitar_captura()
        StopCapture()
        Capturer.EventHandler = Nothing
        Capture = Nothing
    End Sub
    Private Sub obtener_id_sucursal()
        ''Conectar()
        rs.Open("SELECT configuracion.id_sucursal,sucursal.alias from configuracion JOIN sucursal ON sucursal.id_sucursal=configuracion.id_sucursal", conn)
        If rs.RecordCount > 0 Then
            global_id_sucursal = rs.Fields("id_sucursal").Value
            global_nombre_sucursal = rs.Fields("alias").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

    End Sub

    Private Sub obtener_usuarios()

        'matriz usuarios           
        '       0     /  1   /    2       /  3   /   4      /     5        /    6            /   7              /        
        '/id_empleado/nombre/nombre_corto/puesto/contraseña/cobro_terminal/pago_proveedores/recepcion_productos/envio_traspasos/recep_traspasos/devoluciones/conversiones/ajuste_inventario
        Dim i As Integer
        limpiar_usuarios()
        limpiar_usuarios_thumb()
        ''Conectar()
        rs.Open("SELECT empleado.id_empleado, CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS nombre,persona.nombre AS nombre_corto,empleado_puesto.nombre As puesto,empleado.thumb,empleado.imagen,usuario.password,perfil.cobro_terminal,perfil.pago_proveedores_terminal,perfil.recepcion_producto_terminal,perfil.traspasos_env,perfil.traspasos_recep,perfil.devoluciones,perfil.conversiones,perfil.ajuste_inventario,perfil.compras FROM empleado JOIN persona ON persona.id_persona=empleado.id_persona JOIN empleado_puesto ON empleado_puesto.id_puesto=empleado.id_puesto JOIN perfil_empleado ON perfil_empleado.id_empleado=empleado.id_empleado JOIN perfil ON perfil.id_perfil=perfil_empleado.id_perfil JOIN usuario ON usuario.id_empleado=empleado.id_empleado WHERE empleado.id_sucursal='" & global_id_sucursal & "' AND perfil.punto_venta=1 ORDER BY nombre", conn)
        If rs.RecordCount > 0 Then
            i = 0
            While Not rs.EOF
                '--llenamos la matriz
                usuarios(i, 0) = rs.Fields("id_empleado").Value
                usuarios(i, 1) = rs.Fields("nombre").Value
                usuarios(i, 2) = rs.Fields("nombre_corto").Value
                usuarios(i, 3) = rs.Fields("puesto").Value
                usuarios(i, 4) = rs.Fields("password").Value
                usuarios(i, 5) = rs.Fields("cobro_terminal").Value
                usuarios(i, 6) = rs.Fields("pago_proveedores_terminal").Value
                usuarios(i, 7) = rs.Fields("compras").Value
                usuarios(i, 8) = rs.Fields("traspasos_env").Value
                usuarios(i, 9) = rs.Fields("traspasos_recep").Value
                usuarios(i, 10) = rs.Fields("devoluciones").Value
                usuarios(i, 11) = rs.Fields("conversiones").Value
                usuarios(i, 12) = rs.Fields("ajuste_inventario").Value

                '---------------
                Dim bDatos As Byte()
                Dim bThumb As Byte()
                Dim imagen As System.Drawing.Image
                Dim thumb As System.Drawing.Image
                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bDatos = CType(rs.Fields("imagen").Value, Byte())
                    imagen = New Bitmap(Bytes_Imagen(bDatos))
                Else
                    imagen = ventas.My.Resources.no_user_image
                End If
                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bThumb = CType(rs.Fields("imagen").Value, Byte())
                    thumb = New Bitmap(Bytes_Imagen(bDatos))
                Else
                    thumb = ventas.My.Resources.no_user_image
                End If
                usuario_thumb(i) = thumb
                agregar_datos_boton(i, imagen, rs.Fields("nombre_corto").Value)
                i = i + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        'obtenemos de la matriz



    End Sub
    Private Sub agregar_datos_boton(ByVal index As Integer, ByVal imagen As Object, ByVal nombre As String)
        Select Case index
            Case 0
                button1.BackgroundImage = imagen
                usuario1.Text = nombre
                button1.Visible = True
                usuario1.Visible = True
                button1.BackColor = Color.FromArgb(conf_colores(6))
                usuario1.ForeColor = Color.FromArgb(conf_colores(24))
            Case 1
                button2.BackgroundImage = imagen
                usuario2.Text = nombre
                button2.Visible = True
                usuario2.Visible = True
                button2.BackColor = Color.FromArgb(conf_colores(6))
                usuario2.ForeColor = Color.FromArgb(conf_colores(24))
            Case 2
                button3.BackgroundImage = imagen
                usuario3.Text = nombre
                button3.Visible = True
                usuario3.Visible = True
                button3.BackColor = Color.FromArgb(conf_colores(6))
                usuario3.ForeColor = Color.FromArgb(conf_colores(24))
            Case 3
                button4.BackgroundImage = imagen
                usuario4.Text = nombre
                button4.Visible = True
                usuario4.Visible = True
                button4.BackColor = Color.FromArgb(conf_colores(6))
                usuario4.ForeColor = Color.FromArgb(conf_colores(24))
            Case 4
                button5.BackgroundImage = imagen
                usuario5.Text = nombre
                button5.Visible = True
                usuario5.Visible = True
                button5.BackColor = Color.FromArgb(conf_colores(6))
                usuario5.ForeColor = Color.FromArgb(conf_colores(24))
            Case 5
                button6.BackgroundImage = imagen
                usuario6.Text = nombre
                button6.Visible = True
                usuario6.Visible = True
                button6.BackColor = Color.FromArgb(conf_colores(6))
                usuario6.ForeColor = Color.FromArgb(conf_colores(24))
            Case 6
                button7.BackgroundImage = imagen
                usuario7.Text = nombre
                button7.Visible = True
                usuario7.Visible = True
                button7.BackColor = Color.FromArgb(conf_colores(6))
                usuario7.ForeColor = Color.FromArgb(conf_colores(24))
            Case 7
                button8.BackgroundImage = imagen
                usuario8.Text = nombre
                button8.Visible = True
                usuario8.Visible = True
                button8.BackColor = Color.FromArgb(conf_colores(6))
                usuario8.ForeColor = Color.FromArgb(conf_colores(24))
            Case 8
                button9.BackgroundImage = imagen
                usuario9.Text = nombre
                button9.Visible = True
                usuario9.Visible = True
                button9.BackColor = Color.FromArgb(conf_colores(6))
                usuario9.ForeColor = Color.FromArgb(conf_colores(24))
            Case 9
                button10.BackgroundImage = imagen
                usuario10.Text = nombre
                button10.Visible = True
                usuario10.Visible = True
                button10.BackColor = Color.FromArgb(conf_colores(6))
                usuario10.ForeColor = Color.FromArgb(conf_colores(24))
            Case 10
                button11.BackgroundImage = imagen
                usuario11.Text = nombre
                button11.Visible = True
                usuario11.Visible = True
                button11.BackColor = Color.FromArgb(conf_colores(6))
                usuario11.ForeColor = Color.FromArgb(conf_colores(24))
            Case 11
                button12.BackgroundImage = imagen
                usuario12.Text = nombre
                button12.Visible = True
                usuario12.Visible = True
                button12.BackColor = Color.FromArgb(conf_colores(6))
                usuario12.ForeColor = Color.FromArgb(conf_colores(24))
            Case 12
                Button13.BackgroundImage = imagen
                usuario13.Text = nombre
                Button13.Visible = True
                usuario13.Visible = True
                Button13.BackColor = Color.FromArgb(conf_colores(6))
                usuario13.ForeColor = Color.FromArgb(conf_colores(24))
            Case 13
                Button14.BackgroundImage = imagen
                usuario14.Text = nombre
                Button14.Visible = True
                usuario14.Visible = True
                Button14.BackColor = Color.FromArgb(conf_colores(6))
                usuario14.ForeColor = Color.FromArgb(conf_colores(24))
            Case 14
                Button15.BackgroundImage = imagen
                usuario15.Text = nombre
                Button15.Visible = True
                usuario15.Visible = True
                Button15.BackColor = Color.FromArgb(conf_colores(6))
                usuario15.ForeColor = Color.FromArgb(conf_colores(24))
        End Select
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click, button2.Click, button3.Click, button4.Click, button5.Click, button6.Click, button7.Click, button8.Click, button9.Click, button10.Click, button11.Click, button12.Click, Button15.Click, Button14.Click, Button13.Click
        login_index_select = (CType(sender, Button).TabIndex)
        frm_login.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        If global_default_idalmacen <> 0 Then
            frm_principal3.Dispose()
            Me.Dispose()
        End If
        Me.Close()
    End Sub

    Private Sub btn_salir_apagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_apagar.Click
        If MsgBox("Esta seguro que deseea salir y apagar el equipo", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
            'Process.Start("shutdown.exe", " -s -t 0 -f")
            If global_default_idalmacen <> 0 Then

                frm_principal3.Dispose()


            End If
            Me.Close()
            End
        End If

    End Sub
    Public Sub StartCapture()
        Capturer.StartCapture()
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
    Protected Sub StopCapture()
        Capturer.StopCapture()
    End Sub

    Public Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        Process(Sample)

    End Sub

    Public Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        beep()
    End Sub
    Private Sub beep()

    End Sub
    Private Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        status("Lector de huellas dactilares desconectado")
    End Sub
    Private Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        status("Lector de huellas dactilares conectado")
    End Sub
    Public Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
    End Sub
    Protected Sub status(ByVal status)
        Invoke(New FunctionCall(AddressOf _status), status)
    End Sub
    Private Sub _status(ByVal status)
        lbl_status_dispositivo.Text = status
    End Sub

    Protected Overridable Sub Process(ByVal Sample As DPFP.Sample)
        Dim WMP As New Global.WMPLib.WindowsMediaPlayer
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
            ''Conectar()
            rs.Open("SELECT id_usuario,usuario.id_empleado,usuario,huella FROM usuario INNER JOIN empleado ON usuario.id_empleado=empleado.id_empleado WHERE huella IS NOT  null", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim empleado = rs.Fields("usuario").Value
                    Template.DeSerialize(CType(rs.Fields("huella").Value, Byte()))
                    Template.DeSerialize(Template.Bytes)
                    Dim result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
                    Verificator.Verify(features, Template, result)
                    If result.Verified Then
                        datos(rs)
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
            If no_vendedor = True Then
                frm_aviso.Temporizador.Interval = 200
                frm_aviso.Lbl_aviso.Text = "Sin permiso para utilizar el punto de venta"
                frm_aviso.ShowDialog()
            Else
                valida_usuario("ok")
            End If
        End If
    End Sub
    Protected Sub valida_usuario(ByVal status)
        Invoke(New FunctionCall(AddressOf _valida_usuario), status)
    End Sub
    Private Sub _valida_usuario(ByVal status)
        StopCapture()
        Capturer.EventHandler = Nothing
        Capture = Nothing
        Me.Hide()
        frm_botones_terminal.cargar_usuario_actual(global_id_empleado)
        frm_botones_terminal.Show()
        frm_botones_terminal.BringToFront()
        If global_frm_login = 1 Then
            frm_login.Close()
        End If
        'If global_cfg_id_pantalla = 0 Then
        'frm_principal.cargar_usuario_actual()
        'frm_principal.Show()
        'Else
        ' frm_principal2.cargar_usuario_actual()
        'frm_principal2.Show()
        'End If

    End Sub

    Protected Sub datos(ByVal status)
        Invoke(New FunctionCall(AddressOf _datos), status)
    End Sub

    Private Sub _datos(ByVal consulta)
        no_vendedor = True
        'set_usuario(consulta.Fields("usuario").Value)
        global_id_empleado = consulta.Fields("id_empleado").Value
        global_id_usuario = consulta.Fields("id_usuario").Value

        '---BUSCAMOS EL USUARIO EN LA MATRIZ
        'matriz usuarios
        '       0     /  1   /    2       /  3   /   4      /      5       /       6        /      7           /       8      /     9         /   10
        '/id_empleado/nombre/nombre_corto/puesto/contraseña/cobro_terminal/pago_proveedores/recepcion-productos/traspasos_env/traspasos_recep/devoluciones
        Dim current_index As Integer = 0
        For x = 0 To 14
            If global_id_empleado = usuarios(x, 0) Then
                current_index = x
                no_vendedor = False
                Exit For
            End If
        Next

        global_nombre = usuarios(current_index, 2)
        global_usuario_nombre = usuarios(current_index, 1)
        global_puesto = usuarios(current_index, 3)
        global_cobro_terminal = usuarios(current_index, 5)
        global_pago_proveedores = usuarios(current_index, 6)
        global_recepcion_productos = usuarios(current_index, 7)
        global_traspasos_env = usuarios(current_index, 8)
        global_traspasos_recep = usuarios(current_index, 9)
        global_devoluciones = usuarios(current_index, 10)
        global_conversiones = usuarios(current_index, 11)
        global_ajuste_inventario = usuarios(current_index, 12)
        global_thumb_usuario = usuario_thumb(current_index)

        StopCapture()
        Capturer.EventHandler = Nothing
        Capture = Nothing
        Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
        Capturer.EventHandler = Me                              ' Subscribe for capturing events.
        StartCapture()

    End Sub

    Private Sub gb_usuarios_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_usuarios.Enter

    End Sub

    Private Sub usuario12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usuario12.Click

    End Sub

    Private Sub gb_inicio_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_inicio.Enter

    End Sub
End Class
