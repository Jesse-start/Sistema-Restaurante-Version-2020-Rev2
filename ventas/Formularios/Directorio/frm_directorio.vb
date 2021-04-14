Delegate Sub FunctionCall(ByVal param)
Public Class frm_directorio
    '=====VARIABLES LECTOR DE HUELLAS 
    Implements DPFP.Capture.EventHandler
    Private Capturer As DPFP.Capture.Capture
    Private Enroller As DPFP.Processing.Enrollment
    Private bandera_activado As Boolean
    '====================================
    Private tablaTelefono As DataTable
    Private tablaContacto As DataTable
    Private tablaCuentas As DataTable
    Private tablaProductos As DataTable
    Private Linea As DataRow
    Private bDatos() As Byte
    Private bandera As Boolean
    Private bandera_Insertada As Boolean
    Private bandera_actualizar As Boolean
    Private bandera_telefonos As Boolean
    Private bandera_privilegios As Boolean
    Private bandera_cuentas As Boolean
    Private bandera_productos As Boolean
    Private bandera_contacto As Boolean
    Private bandera_horario As Boolean
    Private id_persona As Integer
    Private id_empresa As Integer
    Private id_domicilio As Integer
    Private id_telefono As Integer
    Private id As Integer
    Private tipo_bus As Integer
    Private contador_muestras As Integer
    Dim maxima_utilidad As Double = 0
    '=====FUNCIONES LECTOR DE HUELLAS====
    Public asignar_cliente As Boolean
    Private id_cliente_asignar As Integer
    Public Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        contador_muestras += 1
        SetPrompt("Nuestras obtenida # " & contador_muestras)
        Process(Sample)
    End Sub
    Public Sub UpdateStatus()
        ' Show number of samples needed.
        SetStatus(String.Format("Muestras restantes de la huella digital: {0}", Enroller.FeaturesNeeded))
    End Sub

    Protected Sub SetStatus(ByVal status)
        Invoke(New FunctionCall(AddressOf _SetStatus), status)
    End Sub

    Private Sub _SetStatus(ByVal status)
        linea_estado.Text = status
    End Sub

    Public Sub StartCapture()
        Capturer.StartCapture()
    End Sub

    Protected Sub SetPrompt(ByVal text)
        Invoke(New FunctionCall(AddressOf _SetPrompt), text)
    End Sub

    Private Sub _SetPrompt(ByVal text)
        accion.Text = text
    End Sub

    Protected Sub Setfocus()
        Invoke(New FunctionCall(AddressOf _Setfocus))
    End Sub

    Private Sub _Setfocus()
        frm_login.Hide()
    End Sub

    Protected Overridable Sub Process(ByVal Sample As DPFP.Sample)
        DrawPicture(ConvertSampleToBitmap(Sample))
        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

        ' Check quality of the sample and add to enroller if it's good
        If (Not features Is Nothing) Then
            Try
                Enroller.AddFeatures(features)              ' Add feature set to template.
            Finally
                UpdateStatus()
                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready        ' Report success and stop capturing
                        'RaiseEvent OnTemplate(Enroller.Template)
                        SetStatus("Muestras obtenidas satisfactoriamente.")
                        StopCapture()
                        MakeReport("")
                    Case DPFP.Processing.Enrollment.Status.Failed       ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
                        StartCapture()
                End Select
            End Try
        End If
    End Sub

    Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertor As New DPFP.Capture.SampleConversion()    ' Create a sample convertor.
        Dim bitmap As Bitmap = Nothing                          ' TODO: the size doesn't matter
        convertor.ConvertToPicture(Sample, bitmap)              ' TODO: return bitmap as a result
        Return bitmap
    End Function

    Protected Sub DrawPicture(ByVal bmp)
        Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub

    Private Sub _DrawPicture(ByVal bmp)
        huella_digital.Image = New Bitmap(bmp, huella_digital.Size)
    End Sub

    Protected Sub StopCapture()
        Capturer.StopCapture()
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

    Protected Sub MakeReport(ByVal status)
        Invoke(New FunctionCall(AddressOf _MakeReport), status)
    End Sub

    Private Sub _MakeReport(ByVal status)
        accion.Text = status
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detener_lector.Click
        StopCapture()
        linea_estado.Text = "Esperando"
        accion.Text = "Inicializar dispositivo"
    End Sub
    Private Sub frm_directorio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        'habilitar_menu_ventana()
        global_frm_directorio = 0
        If bandera_activado = True Then
            StopCapture()
        End If
        If asignar_cliente = True Then
            If id_cliente_asignar <> 0 Then
                frm_principal3.verificar_precio_especial(id_cliente_asignar)
            End If
        End If
    End Sub

    Public Sub cargar(Optional ByVal id As Integer = 0, Optional ByVal tipo_bus As Integer = 0)
        Me.id = id
        Me.tipo_bus = tipo_bus
        bandera_activado = False
        bandera_actualizar = False
        bandera = False
        id_cliente_asignar = 0
        Telefono("Telefonos del cliente", dg_telefonos, tablaTelefono)
        contacto("Contactos de la empresa", dg_contacto, tablaContacto)
        cuentas("Cuentas Bancarias", Dg_cuentas, tablaCuentas)
        style_productos("Productos", dg_productos, tablaProductos)
        'Conectar()
        '---------obtenemos los tipos de cliete
        rs.Open("SELECT id_tipo, nombre FROM cliente_tipo", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cb_clasificacion.Items.Clear()
        While Not rs.EOF
            cb_clasificacion.Items.Add(New myItem(rs.Fields("id_tipo").Value, rs.Fields("nombre").Value))
            rs.MoveNext()
        End While
        cb_clasificacion.SelectedIndex = 0
        rs.Close()

        '------obtenemos los productos----------
        rs.Open("SELECT id_producto, CONCAT(producto.nombre,' UNIDAD:',unidad.nombre) As nombre, costo FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad ORDER By nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cb_productos.Items.Clear()
        While Not rs.EOF
            cb_productos.Items.Add(New myItem(rs.Fields("id_producto").Value, rs.Fields("nombre").Value, rs.Fields("costo").Value))
            rs.MoveNext()
        End While
        rs.Close()
        '---obtenemos los puestos--------------
        rs.Open("SELECT * FROM empleado_puesto", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cb_puesto.Items.Clear()
        While Not rs.EOF
            cb_puesto.Items.Add(New myItem(rs.Fields("id_puesto").Value, rs.Fields("nombre").Value))
            rs.MoveNext()
        End While
        cb_puesto.SelectedIndex = 0
        rs.Close()
        '----obtenemos todos los bancos------------------------
        cb_banco.Items.Clear()
        rs.Open("SELECT * FROM banco Order By descripcion", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_banco.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        '---obtenemos el catalogo de precios
        cb_catalogo_precios.Items.Clear()
        rs.Open("SELECT id_ctlg_precios,nombre,utilidad FROM ctlg_precios", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_catalogo_precios.Items.Add(New myItem(rs.Fields("id_ctlg_precios").Value, rs.Fields("nombre").Value, rs.Fields("utilidad").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        '------
        rs.Open("SELECT CASE WHEN ISNULL(MAX(utilidad)) THEN 0 ELSE MAX(utilidad) END AS max_utilidad FROM ctlg_precios", conn)
        If rs.RecordCount > 0 Then
            maxima_utilidad = rs.Fields("max_utilidad").Value
        End If
        rs.Close()
        '-----------------------------------
        '---obtenemos la imagen---------------
        rs.Open("SELECT imagen FROM configuracion", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If Not rs.EOF Then
            bDatos = CType(rs.Fields("imagen").Value, Byte())
            pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
        End If
        rs.Close()
        ofd_foto.Title = "Seleccionar imágen"
        ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"
        tab_contacto.Parent = Nothing
        tab_foto.Parent = Nothing
        rb_cliente.Checked = True
        rb_fisica.Checked = True
        CheckBoxSinLimite.Checked = True
        tb_limite_credito.Enabled = False
        CheckBoxSinCredito.Enabled = True
        tb_limite_credito.Text = "0.00"
        CheckBoxSinCredito.Checked = False
        CheckBoxSinLimite.Enabled = True
        '--catalogo_precios---
        cb_autorizacion_precio.Checked = False
        cb_autorizacion_precio.Enabled = False
        cb_catalogo_precios.Text = ""
        cb_catalogo_precios.SelectedIndex = -1
        cb_catalogo_precios.Enabled = False
        cb_Noasignar_precio.Checked = True
        lbl_ganancia.Text = ""
        lbl_descuento.Text = ""
        tb_alias_fisica.Text = ""
        tb_clave.Text = ""
        '-------------------
        If id <> 0 Then
            btn_eliminar.Enabled = True
            gb_clase.Enabled = False
            bandera_actualizar = True
            If tipo_bus = 1 Then '--empleado
                rb_empleado.Checked = True
                rs.Open("select " & _
                    "empleado.curp, " & _
                    "empleado.imagen, " & _
                    "empleado.id_domicilio, " & _
                    "empleado.id_persona, " & _
                    "empleado.puesto," & _
                    "empleado_puesto.nombre as nombre_puesto," & _
                    "persona.nombre, " & _
                    "persona.ap_materno, " & _
                    "persona.ap_paterno, " & _
                    "persona.email, " & _
                    "persona.alias, " & _
                    "persona.rfc, " & _
                    "domicilio.calle, " & _
                       "domicilio.num_ext, " & _
                          "domicilio.num_int, " & _
                    "domicilio.colonia, " & _
                    "domicilio.cp, " & _
                    "domicilio.municipio, " & _
                    "domicilio.poblacion, " & _
                    "domicilio.estado, " & _
                    "domicilio.pais " & _
                    "FROM empleado " & _
                "INNER JOIN persona ON empleado.id_persona = persona.id_persona " & _
                "INNER JOIN domicilio ON empleado.id_domicilio = domicilio.id_domicilio " & _
                "INNER JOIN empleado_puesto ON empleado_puesto.id_puesto = empleado.id_puesto " & _
                "WHERE id_empleado = " & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_apellidoP.Text = rs.Fields("ap_paterno").Value
                tb_apellidoM.Text = rs.Fields("ap_materno").Value
                tb_emailF.Text = rs.Fields("email").Value
                tb_rfcF.Text = rs.Fields("rfc").Value
                tb_curp.Text = rs.Fields("curp").Value
                cb_puesto.Text = rs.Fields("puesto").Value
                tb_calle.Text = rs.Fields("calle").Value
                tb_num_ext.Text = rs.Fields("num_ext").Value
                tb_num_int.Text = rs.Fields("num_int").Value
                tb_colonia.Text = rs.Fields("colonia").Value
                tb_municipio.Text = rs.Fields("municipio").Value
                tb_cp.Text = rs.Fields("cp").Value
                tb_poblacion.Text = rs.Fields("poblacion").Value
                tb_estado.Text = rs.Fields("estado").Value
                tb_pais.Text = rs.Fields("pais").Value
                id_domicilio = rs.Fields("id_domicilio").Value
                id_persona = rs.Fields("id_persona").Value
                tb_alias_fisica.Text = rs.Fields("alias").Value
                cb_puesto.Text = rs.Fields("nombre_puesto").Value
                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bDatos = CType(rs.Fields("imagen").Value, Byte())
                    pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
                End If
                rs.Close()
                rs.Open("SELECT lada, numero FROM telefono INNER JOIN empleado_tel ON empleado_tel.id_telefono=telefono.id_telefono WHERE id_empleado=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaTelefono.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("lada").Value
                    Linea(2) = rs.Fields("numero").Value
                    tablaTelefono.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                'rs.Open("SELECT hora_entrada,hora_salida,tolerancia FROM empleado_horario WHERE id_empleado=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                'If rs.RecordCount > 0 Then
                'dtp_hora_entrada.Value = rs.Fields("hora_entrada").Value
                'dtp_hora_salida.Value = rs.Fields("hora_salida").Value
                'tb_minutos_tolerancia.Value = rs.Fields("tolerancia").Value
                'End If
                'rs.Close()
            End If
            If tipo_bus = 2 Then '--cliente moral
                rb_cliente.Checked = True
                rb_moral.Checked = True
                Panel6.Enabled = False
                rs.Open("select " & _
                    "cliente.clave, " & _
                    "cliente.id_empresa, " & _
                    "cliente.id_domicilio, " & _
                    "empresa.razon_social, " & _
                    "empresa.alias, " & _
                    "empresa.url, " & _
                    "empresa.rfc, " & _
                    "empresa.email, " & _
                    "domicilio.calle, " & _
                      "domicilio.num_ext, " & _
                        "domicilio.num_int, " & _
                    "domicilio.colonia, " & _
                    "domicilio.cp, " & _
                    "domicilio.municipio, " & _
                    "domicilio.poblacion, " & _
                    "domicilio.estado, " & _
                    "domicilio.pais, " & _
                    "cliente_tipo.nombre  as tipo " & _
                    "FROM cliente " & _
                "INNER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                "INNER JOIN domicilio ON cliente.id_domicilio = domicilio.id_domicilio " & _
                "INNER JOIN cliente_tipo ON cliente.id_tipo = cliente_tipo.id_tipo " & _
                "WHERE id_cliente = " & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                tb_clave.Text = rs.Fields("clave").Value
                tb_razon.Text = rs.Fields("razon_social").Value
                tb_alias.Text = rs.Fields("alias").Value
                tb_url.Text = rs.Fields("url").Value
                tb_emailM.Text = rs.Fields("email").Value
                tb_rfcM.Text = rs.Fields("rfc").Value
                cb_clasificacion.Text = rs.Fields("tipo").Value
                tb_calle.Text = rs.Fields("calle").Value
                tb_num_ext.Text = rs.Fields("num_ext").Value
                tb_num_int.Text = rs.Fields("num_int").Value
                tb_colonia.Text = rs.Fields("colonia").Value
                tb_municipio.Text = rs.Fields("municipio").Value
                tb_cp.Text = rs.Fields("cp").Value
                tb_poblacion.Text = rs.Fields("poblacion").Value
                tb_estado.Text = rs.Fields("estado").Value
                tb_pais.Text = rs.Fields("pais").Value
                id_empresa = rs.Fields("id_empresa").Value
                id_domicilio = rs.Fields("id_domicilio").Value
                cb_clasificacion.Text = rs.Fields("tipo").Value
                rs.Close()
                rs.Open("SELECT lada, numero FROM telefono INNER JOIN empresa_tel ON empresa_tel.id_telefono=telefono.id_telefono WHERE id_empresa=" & id_empresa, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaTelefono.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("lada").Value
                    Linea(2) = rs.Fields("numero").Value
                    tablaTelefono.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT nombre,ap_paterno,ap_materno,email FROM persona INNER JOIN empresa_contacto ON empresa_contacto.id_persona=persona.id_persona WHERE id_empresa=" & id_empresa, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaContacto.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("nombre").Value
                    Linea(2) = rs.Fields("ap_paterno").Value
                    Linea(3) = rs.Fields("ap_materno").Value
                    Linea(4) = rs.Fields("email").Value
                    tablaContacto.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                '---obtenemos la lista de cuentas bancarias
                rs.Open("SELECT * FROM cliente_cuenta  WHERE id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaCuentas.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("banco").Value
                    Linea(2) = rs.Fields("cuenta").Value
                    Linea(3) = rs.Fields("sucursal").Value
                    Linea(4) = rs.Fields("clabe").Value
                    tablaCuentas.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT CP.id_producto,CP.cantidad, CONCAT(P.nombre,' UNIDAD:',U.nombre) As nombre FROM cliente_productos CP, unidad U, producto P  WHERE P.id_unidad=U.id_unidad AND CP.id_producto=P.id_producto AND CP.id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaProductos.NewRow()
                    Linea(0) = rs.Fields("id_producto").Value
                    Linea(1) = rs.Fields("nombre").Value
                    Linea(2) = rs.Fields("cantidad").Value
                    tablaProductos.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT * FROM cliente_credito WHERE id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    If rs.Fields("credito").Value = 0 Then
                        CheckBoxSinCredito.Checked = True
                    Else
                        If rs.Fields("limite").Value = 0 Then
                            CheckBoxSinLimite.Checked = True
                            tb_limite_credito.Enabled = False
                        Else
                            tb_limite_credito.Text = rs.Fields("limite_credito").Value
                            CheckBoxSinLimite.Checked = False
                        End If
                    End If
                End If
                rs.Close()
                '--obtenemos el precio del cliente
                rs.Open("SELECT ca.nombre,cp.id_ctlg_precios,cp.autorizacion,cp.aplicar_redondeo FROM cliente_precio cp,ctlg_precios ca WHERE cp.id_ctlg_precios=ca.id_ctlg_precios AND id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    cb_Noasignar_precio.CheckState = 0
                    cb_catalogo_precios.Text = rs.Fields("nombre").Value
                    cb_autorizacion_precio.CheckState = rs.Fields("autorizacion").Value
                Else
                    cb_Noasignar_precio.CheckState = 1
                End If
                rs.Close()
                '-----------------------------
                rs.Open("SELECT aplicar_redondeo,mostrar_precios FROM cliente_precio WHERE id_cliente=" & id, conn)
                If rs.RecordCount > 0 Then
                    chb_aplicar_redondeo.CheckState = rs.Fields("aplicar_redondeo").Value
                    chb_mostrar_precios.CheckState = rs.Fields("mostrar_precios").Value
                End If
                rs.Close()
            End If
            If tipo_bus = 3 Then '--cliente fisica
                Panel6.Enabled = False
                rs.Open("select " & _
                    "cliente.clave, " & _
                    "cliente.id_persona, " & _
                    "cliente.id_domicilio, " & _
                    "persona.nombre, " & _
                    "persona.ap_materno, " & _
                    "persona.ap_paterno, " & _
                    "persona.email, " & _
                    "persona.rfc, " & _
                      "persona.alias, " & _
                    "domicilio.calle, " & _
                      "domicilio.num_ext, " & _
                        "domicilio.num_int, " & _
                    "domicilio.colonia, " & _
                    "domicilio.cp, " & _
                    "domicilio.municipio, " & _
                    "domicilio.poblacion, " & _
                    "domicilio.estado, " & _
                    "domicilio.pais, " & _
                    "cliente_tipo.nombre  as tipo " & _
                    "FROM cliente " & _
                "INNER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "INNER JOIN domicilio ON cliente.id_domicilio = domicilio.id_domicilio " & _
                "INNER JOIN cliente_tipo ON cliente_tipo.id_tipo = cliente.id_tipo " & _
                "WHERE id_cliente = " & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_apellidoP.Text = rs.Fields("ap_paterno").Value
                tb_apellidoM.Text = rs.Fields("ap_materno").Value
                tb_emailF.Text = rs.Fields("email").Value
                tb_rfcF.Text = rs.Fields("rfc").Value
                cb_clasificacion.Text = rs.Fields("tipo").Value
                tb_calle.Text = rs.Fields("calle").Value
                tb_num_ext.Text = rs.Fields("num_ext").Value
                tb_num_int.Text = rs.Fields("num_int").Value
                tb_colonia.Text = rs.Fields("colonia").Value
                tb_municipio.Text = rs.Fields("municipio").Value
                tb_cp.Text = rs.Fields("cp").Value
                tb_poblacion.Text = rs.Fields("poblacion").Value
                tb_estado.Text = rs.Fields("estado").Value
                tb_pais.Text = rs.Fields("pais").Value
                id_persona = rs.Fields("id_persona").Value
                id_domicilio = rs.Fields("id_domicilio").Value
                tb_alias_fisica.Text = rs.Fields("alias").Value
                rs.Close()
                rs.Open("SELECT lada, numero FROM telefono INNER JOIN persona_tel ON persona_tel.id_telefono=telefono.id_telefono WHERE id_persona=" & id_persona, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaTelefono.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("lada").Value
                    Linea(2) = rs.Fields("numero").Value
                    tablaTelefono.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT * FROM cliente_cuenta  WHERE id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaCuentas.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("banco").Value
                    Linea(2) = rs.Fields("cuenta").Value
                    Linea(3) = rs.Fields("sucursal").Value
                    Linea(4) = rs.Fields("clabe").Value
                    tablaCuentas.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT CP.id_producto,CP.cantidad, CONCAT(P.nombre,' UNIDAD:',U.nombre) As nombre FROM cliente_productos CP, unidad U, producto P  WHERE P.id_unidad=U.id_unidad AND CP.id_producto=P.id_producto AND CP.id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaProductos.NewRow()
                    Linea(0) = rs.Fields("id_producto").Value
                    Linea(1) = rs.Fields("nombre").Value
                    Linea(2) = rs.Fields("cantidad").Value
                    tablaProductos.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT * FROM cliente_credito WHERE id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    If rs.Fields("credito").Value = 0 Then
                        CheckBoxSinCredito.Checked = True
                    Else
                        If rs.Fields("limite").Value = 0 Then
                            CheckBoxSinLimite.Checked = True
                            tb_limite_credito.Enabled = False
                        Else
                            tb_limite_credito.Text = rs.Fields("limite_credito").Value
                            CheckBoxSinLimite.Checked = False
                        End If
                    End If
                End If
                rs.Close()
                '--obtenemos el precio del cliente
                rs.Open("SELECT ca.nombre,cp.id_ctlg_precios,cp.autorizacion,cp.aplicar_redondeo FROM cliente_precio cp,ctlg_precios ca WHERE cp.id_ctlg_precios=ca.id_ctlg_precios AND id_cliente=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    cb_Noasignar_precio.CheckState = 0
                    cb_catalogo_precios.Text = rs.Fields("nombre").Value
                    cb_autorizacion_precio.CheckState = rs.Fields("autorizacion").Value
                Else
                    cb_Noasignar_precio.CheckState = 1
                End If
                rs.Close()
                '-----------------------------
                rs.Open("SELECT aplicar_redondeo,mostrar_precios FROM cliente_precio WHERE id_cliente=" & id, conn)
                If rs.RecordCount > 0 Then
                    chb_aplicar_redondeo.CheckState = rs.Fields("aplicar_redondeo").Value
                    chb_mostrar_precios.CheckState = rs.Fields("mostrar_precios").Value
                End If
                rs.Close()
            End If
            '=====cargamos valores para proveedor moral
            If tipo_bus = 4 Then
                rb_proveedor.Checked = True
                rb_moral.Checked = True
                Panel6.Enabled = False
                rs.Open("select " & _
                         "proveedor.clave, " & _
                    "proveedor.id_empresa, " & _
                    "proveedor.id_domicilio, " & _
                    "empresa.razon_social, " & _
                    "empresa.alias, " & _
                    "empresa.url, " & _
                    "empresa.rfc, " & _
                    "empresa.email, " & _
                    "domicilio.calle, " & _
                      "domicilio.num_ext, " & _
                        "domicilio.num_int, " & _
                    "domicilio.colonia, " & _
                    "domicilio.cp, " & _
                    "domicilio.municipio, " & _
                    "domicilio.poblacion, " & _
                    "domicilio.estado, " & _
                    "domicilio.pais " & _
                    "FROM proveedor " & _
                "INNER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                "INNER JOIN domicilio ON proveedor.id_domicilio = domicilio.id_domicilio " & _
                "WHERE id_proveedor = " & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                tb_clave.Text = rs.Fields("clave").Value
                tb_razon.Text = rs.Fields("razon_social").Value
                tb_alias.Text = rs.Fields("alias").Value
                tb_url.Text = rs.Fields("url").Value
                tb_emailM.Text = rs.Fields("email").Value
                tb_rfcM.Text = rs.Fields("rfc").Value
                ' cb_clasificacion.Text = rs.Fields("tipo").Value
                tb_calle.Text = rs.Fields("calle").Value
                tb_num_ext.Text = rs.Fields("num_ext").Value
                tb_num_int.Text = rs.Fields("num_int").Value
                tb_colonia.Text = rs.Fields("colonia").Value
                tb_municipio.Text = rs.Fields("municipio").Value
                tb_cp.Text = rs.Fields("cp").Value
                tb_poblacion.Text = rs.Fields("poblacion").Value
                tb_estado.Text = rs.Fields("estado").Value
                tb_pais.Text = rs.Fields("pais").Value
                id_empresa = rs.Fields("id_empresa").Value
                id_domicilio = rs.Fields("id_domicilio").Value
                'cb_clasificacion.Text = rs.Fields("tipo").Value
                rs.Close()
                rs.Open("SELECT lada, numero FROM telefono INNER JOIN empresa_tel ON empresa_tel.id_telefono=telefono.id_telefono WHERE id_empresa=" & id_empresa, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaTelefono.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("lada").Value
                    Linea(2) = rs.Fields("numero").Value
                    tablaTelefono.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT nombre,ap_paterno,ap_materno,email FROM persona INNER JOIN empresa_contacto ON empresa_contacto.id_persona=persona.id_persona WHERE id_empresa=" & id_empresa, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaContacto.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("nombre").Value
                    Linea(2) = rs.Fields("ap_paterno").Value
                    Linea(3) = rs.Fields("ap_materno").Value
                    Linea(4) = rs.Fields("email").Value
                    tablaContacto.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT * FROM proveedor_cuenta  WHERE id_proveedor=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaCuentas.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("banco").Value
                    Linea(2) = rs.Fields("cuenta").Value
                    Linea(3) = rs.Fields("sucursal").Value
                    Linea(4) = rs.Fields("clabe").Value
                    tablaCuentas.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT PP.id_producto,PP.cantidad,PP.precio_unitario, CONCAT(P.nombre,' UNIDAD:',U.nombre) As nombre FROM proveedor_productos PP, unidad U, producto P  WHERE P.id_unidad=U.id_unidad AND PP.id_producto=P.id_producto AND PP.id_proveedor=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaProductos.NewRow()
                    Linea(0) = rs.Fields("id_producto").Value
                    Linea(1) = rs.Fields("nombre").Value
                    Linea(2) = rs.Fields("cantidad").Value
                    Linea(3) = rs.Fields("precio_unitario").Value
                    tablaProductos.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
            End If
            '=========================================================
            '======cargamos valores para proveedor fisica=====
            If tipo_bus = 5 Then
                rb_proveedor.Checked = True
                rb_fisica.Checked = True
                Panel6.Enabled = False
                rs.Open("select " & _
                    "proveedor.clave, " & _
                    "proveedor.id_persona, " & _
                    "proveedor.id_domicilio, " & _
                    "persona.nombre, " & _
                    "persona.ap_materno, " & _
                    "persona.ap_paterno, " & _
                    "persona.email, " & _
                    "persona.alias, " & _
                    "persona.rfc, " & _
                    "domicilio.calle, " & _
                      "domicilio.num_ext, " & _
                        "domicilio.num_int, " & _
                    "domicilio.colonia, " & _
                    "domicilio.cp, " & _
                    "domicilio.municipio, " & _
                    "domicilio.poblacion, " & _
                    "domicilio.estado, " & _
                    "domicilio.pais " & _
                    "FROM proveedor " & _
                "INNER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "INNER JOIN domicilio ON proveedor.id_domicilio = domicilio.id_domicilio " & _
                "WHERE id_proveedor = " & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_apellidoP.Text = rs.Fields("ap_paterno").Value
                tb_apellidoM.Text = rs.Fields("ap_materno").Value
                tb_emailF.Text = rs.Fields("email").Value
                tb_rfcF.Text = rs.Fields("rfc").Value
                'cb_clasificacion.Text = rs.Fields("tipo").Value
                tb_calle.Text = rs.Fields("calle").Value
                tb_num_ext.Text = rs.Fields("num_ext").Value
                tb_num_int.Text = rs.Fields("num_int").Value
                tb_colonia.Text = rs.Fields("colonia").Value
                tb_municipio.Text = rs.Fields("municipio").Value
                tb_cp.Text = rs.Fields("cp").Value
                tb_poblacion.Text = rs.Fields("poblacion").Value
                tb_estado.Text = rs.Fields("estado").Value
                tb_pais.Text = rs.Fields("pais").Value
                id_persona = rs.Fields("id_persona").Value
                id_domicilio = rs.Fields("id_domicilio").Value
                tb_alias_fisica.Text = rs.Fields("alias").Value
                rs.Close()
                rs.Open("SELECT lada, numero FROM telefono INNER JOIN persona_tel ON persona_tel.id_telefono=telefono.id_telefono WHERE id_persona=" & id_persona, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaTelefono.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("lada").Value
                    Linea(2) = rs.Fields("numero").Value
                    tablaTelefono.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT * FROM proveedor_cuenta  WHERE id_proveedor=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaCuentas.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("banco").Value
                    Linea(2) = rs.Fields("cuenta").Value
                    Linea(3) = rs.Fields("sucursal").Value
                    Linea(4) = rs.Fields("clabe").Value
                    tablaCuentas.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
                rs.Open("SELECT PP.id_producto,PP.cantidad, CONCAT(P.nombre,' UNIDAD:',U.nombre) As nombre,PP.precio_unitario FROM proveedor_productos PP, unidad U, producto P  WHERE P.id_unidad=U.id_unidad AND PP.id_producto=P.id_producto AND PP.id_proveedor=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs.EOF
                    Linea = tablaProductos.NewRow()
                    Linea(0) = rs.Fields("id_producto").Value
                    Linea(1) = rs.Fields("nombre").Value
                    Linea(2) = rs.Fields("cantidad").Value
                    Linea(3) = rs.Fields("precio_unitario").Value
                    tablaProductos.Rows.Add(Linea)
                    rs.MoveNext()
                End While
                rs.Close()
            End If
            '==================================================
            bandera_privilegios = False
        Else
            btn_eliminar.Enabled = False
            gb_clase.Enabled = True
            Panel6.Enabled = True
            rb_fisica.Checked = True
            rb_cliente.Checked = True
            tb_razon.Text = ""
            tb_alias.Text = ""
            tb_url.Text = ""
            tb_emailM.Text = ""
            tb_nombre.Text = ""
            tb_apellidoP.Text = ""
            tb_apellidoM.Text = ""
            tb_emailF.Text = ""
            tb_curp.Text = ""
            tb_calle.Text = ""
            tb_num_ext.Text = ""
            tb_num_int.Text = ""
            tb_colonia.Text = ""
            tb_municipio.Text = ""
            tb_cp.Text = ""
            tb_poblacion.Text = ""
            tb_estado.Text = ""
            tb_pais.Text = ""
            tb_rfcM.Text = ""
            tb_rfcF.Text = ""
        End If
        'conn.close()
        bandera_cuentas = False
        bandera_contacto = False
        bandera_horario = False
        bandera_privilegios = False
        bandera_productos = False
        bandera_privilegios = False
        bandera_telefonos = False
    End Sub

    Private Sub frm_directorio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If global_frm_presentaciones = 1 Then
            frm_presentaciones.cargar_proveedores()
        End If
    End Sub
    Private Sub frm_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        global_frm_directorio = 1
        cargar()
    End Sub

    Private Sub rb_fisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_fisica.CheckedChanged
        If rb_fisica.Checked = True Then
            gb_empresa.Visible = False
            gb_persona.Visible = True
            tab_contacto.Parent = Nothing
        End If
    End Sub

    Private Sub rb_moral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_moral.CheckedChanged
        If rb_moral.Checked = True Then
            gb_empresa.Visible = True
            gb_persona.Visible = False
            tab_contacto.Parent = TabDirectorio
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        gb_datos_contacto.Enabled = True
        Button2.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        If tb_nombre_contacto.Text = "" Then
            cadena = cadena & "  Nombre" & vbCrLf
            bandera_correcto = False
        End If
        If tb_apellidoP_contacto.Text = "" Then
            cadena = cadena & "  Apellido Paterno" & vbCrLf
            bandera_correcto = False
        End If
        If Validar_Email(tb_email_contacto.Text) = False Then
            cadena = cadena & "  E-mail" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            If Button3.Text = "Aceptar" Then
                Linea = tablaContacto.NewRow()
                Linea(0) = 0
                Linea(1) = tb_nombre_contacto.Text
                Linea(2) = tb_apellidoP_contacto.Text
                Linea(3) = tb_apellidoM_contacto.Text
                Linea(4) = tb_email_contacto.Text
                tablaContacto.Rows.Add(Linea)
            Else
                dg_contacto.Item(dg_telefonos.CurrentCell.RowNumber, 1) = tb_nombre_contacto.Text
                dg_contacto.Item(dg_telefonos.CurrentCell.RowNumber, 2) = tb_apellidoP_contacto.Text
                dg_contacto.Item(dg_telefonos.CurrentCell.RowNumber, 3) = tb_apellidoM_contacto.Text
                dg_contacto.Item(dg_telefonos.CurrentCell.RowNumber, 4) = tb_email_contacto.Text
            End If
            tb_nombre_contacto.Text = ""
            tb_apellidoP_contacto.Text = ""
            tb_apellidoM_contacto.Text = ""
            tb_email_contacto.Text = ""
            gb_datos_contacto.Enabled = False
            Button2.Enabled = True
            Button1.Enabled = True
            Button3.Text = "Aceptar"
            bandera_contacto = True
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        If Tb_lada.Text = "" Then
            cadena = cadena & "  Lada" & vbCrLf
            bandera_correcto = False
        End If
        If tb_telefono.Text = "" Then
            cadena = cadena & "  Telefono" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            If Button7.Text = "Aceptar" Then
                Linea = tablaTelefono.NewRow()
                Linea(0) = 0
                Linea(1) = Tb_lada.Text
                Linea(2) = tb_telefono.Text
                tablaTelefono.Rows.Add(Linea)
            Else
                dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 1) = Tb_lada.Text
                dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 2) = tb_telefono.Text
            End If
            Button7.Text = "Aceptar"
            tb_telefono.Text = ""
            Tb_lada.Text = ""
            gb_datos_telefono.Enabled = False
            Panel1.Enabled = True
            Panel3.Enabled = True
            Panel5.Enabled = True
            bandera_telefonos = True
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        gb_datos_telefono.Enabled = True
        Panel1.Enabled = False
        Panel3.Enabled = False
        Panel5.Enabled = False
    End Sub

    Private Sub Tb_lada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_lada.KeyPress
        e.Handled = txtNumerico(Tb_lada, e.KeyChar, True)
    End Sub

    Private Sub tb_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_telefono.KeyPress
        e.Handled = txtNumerico(tb_telefono, e.KeyChar, True)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        tb_telefono.Text = ""
        Tb_lada.Text = ""
        gb_datos_telefono.Enabled = False
        Panel1.Enabled = True
        Panel3.Enabled = True
        Panel5.Enabled = True
        Button7.Text = "Aceptar"
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim contador As Integer
        contador = tablaTelefono.Rows.Count
        While 0 < contador
            If dg_telefonos.IsSelected(contador - 1) = True Then
                tablaTelefono.Rows.Item(contador - 1).Delete()
                bandera_contacto = True
                bandera_telefonos = True
            End If
            contador = contador - 1
        End While
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim contador As Integer
        contador = tablaContacto.Rows.Count
        While 0 < contador
            If dg_contacto.IsSelected(contador - 1) = True Then
                tablaContacto.Rows.Item(contador - 1).Delete()
            End If
            contador = contador - 1
        End While
    End Sub

    Private Sub tb_nombre_contacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_nombre_contacto.KeyDown
        If e.KeyCode = Keys.Enter Then
            'tb_nombre_contacto.Text = ucWords(tb_nombre_contacto.Text)
            tb_apellidoP_contacto.Focus()
        End If
    End Sub

    Private Sub tb_nombre_contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_nombre_contacto.KeyPress
        'e.Handled = txtLetraEsp(e.KeyChar)
        e.Handled = validar_teclado(e.KeyChar, {"a", " "})

    End Sub

    Private Sub tb_apellidoP_contacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_apellidoP_contacto.KeyDown
        If e.KeyCode = Keys.Enter Then
            tb_apellidoP_contacto.Text = ucWords(tb_apellidoP_contacto.Text)
            tb_apellidoM_contacto.Focus()
        End If
    End Sub

    Private Sub tb_apellidoP_contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_apellidoP_contacto.KeyPress
        'e.Handled = validar_teclado(e.KeyChar, {"a", " "})
    End Sub

    Private Sub tb_apellidoM_contacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_apellidoM_contacto.KeyDown
        If e.KeyCode = Keys.Enter Then
            'tb_apellidoM_contacto.Text = ucWords(tb_apellidoM_contacto.Text)
            tb_email_contacto.Focus()
        End If
    End Sub

    Private Sub tb_apellidoM_contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_apellidoM_contacto.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", " "})
    End Sub

    Private Sub tb_email_contacto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_email_contacto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub tb_email_contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_email_contacto.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a", ".\-_@"})
    End Sub

    Private Sub tb_nombre_contacto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_nombre_contacto.LostFocus
        ' tb_nombre_contacto.Text = ucWords(tb_nombre_contacto.Text)
    End Sub

    Private Sub tb_apellidoP_contacto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_apellidoP_contacto.LostFocus
        'tb_apellidoP_contacto.Text = ucWords(tb_apellidoP_contacto.Text)
    End Sub

    Private Sub tb_apellidoM_contacto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_apellidoM_contacto.LostFocus
        ' tb_apellidoM_contacto.Text = ucWords(tb_apellidoM_contacto.Text)
    End Sub

    Private Sub tb_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_nombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            'tb_nombre.Text = ucWords(tb_nombre.Text)
            tb_apellidoP.Focus()
        End If
    End Sub

    Private Sub tb_nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_nombre.KeyPress
        ' e.Handled = validar_teclado(e.KeyChar, {"a", " "})
    End Sub

    Private Sub tb_apellidoP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_apellidoP.KeyDown
        If e.KeyCode = Keys.Enter Then
            'tb_apellidoP.Text = ucWords(tb_apellidoP.Text)
            tb_apellidoM.Focus()
        End If
    End Sub

    Private Sub tb_apellidoP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_apellidoP.KeyPress
        'e.Handled = validar_teclado(e.KeyChar, {"a", " "})
    End Sub

    Private Sub tb_apellidoM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_apellidoM.KeyDown
        If e.KeyCode = Keys.Enter Then
            tb_apellidoM.Text = ucWords(tb_apellidoM.Text)
            tb_emailF.Focus()
        End If
    End Sub

    Private Sub tb_apellidoM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_apellidoM.KeyPress
        'e.Handled = validar_teclado(e.KeyChar, {"a", " "})
    End Sub

    Private Sub tb_emailF_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_emailF.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub tb_emailF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_emailF.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a", ".\-_@"})
    End Sub

    Private Sub tb_nombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_nombre.LostFocus
        'tb_nombre.Text = ucWords(tb_nombre.Text)
    End Sub

    Private Sub tb_apellidoP_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_apellidoP.LostFocus
        ' tb_apellidoP.Text = ucWords(tb_apellidoP.Text)
    End Sub

    Private Sub tb_apellidoM_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_apellidoM.LostFocus
        'tb_apellidoM.Text = ucWords(tb_apellidoM.Text)
    End Sub

    Private Sub tb_url_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_url.KeyDown
        If e.KeyCode = Keys.Enter Then
            If validar_url(tb_url.Text) = False Then
                MsgBox("correcto")
            Else
                MsgBox("mal")
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        tb_nombre_contacto.Text = ""
        tb_apellidoP_contacto.Text = ""
        tb_apellidoM_contacto.Text = ""
        tb_email_contacto.Text = ""
        gb_datos_contacto.Enabled = False
        Button2.Enabled = True
        Button1.Enabled = True
        Button3.Text = "Aceptar"
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        'Dim id_domicilio As Integer
        'Dim id_persona As Integer
        Dim id_empleado As Integer
        'Dim id_empresa As Integer

        'rs = New ADODB.Recordset
        ''Conectar()
        'conn.BeginTrans()

        cadena = "Error en los siguientes campos:" & vbCrLf
        If rb_fisica.Checked Then
            If tb_nombre.Text = "" Then
                cadena = cadena & "  Nombre" & vbCrLf
                bandera_correcto = False
            End If
            If tb_apellidoP.Text = "" Then
                cadena = cadena & "  Apellido Paterno" & vbCrLf
                bandera_correcto = False
            End If
            If tb_emailF.Text <> "" Then
                If Validar_Email(tb_emailF.Text) = False Then
                    cadena = cadena & "  E-mail" & vbCrLf
                    bandera_correcto = False
                End If
            End If
            If tb_rfcF.Text = "" Then
                cadena = cadena & "  RFC" & vbCrLf
                bandera_correcto = False
            End If

        Else
            If tb_razon.Text = "" Then
                cadena = cadena & "  Nombre" & vbCrLf
                bandera_correcto = False
            End If
            If tb_alias.Text = "" Then
                cadena = cadena & "  Alias" & vbCrLf
                bandera_correcto = False
            End If
            If tb_emailM.Text <> "" Then
                If Validar_Email(tb_emailM.Text) = False Then
                    cadena = cadena & "  E-mail" & vbCrLf
                    bandera_correcto = False
                End If
            End If
            If tb_rfcM.Text = "" Then
                cadena = cadena & "  RFC" & vbCrLf
                bandera_correcto = False
            End If
        End If
        If rb_empleado.Checked = True Then

            If cb_puesto.SelectedIndex = -1 Then
                If Trim(cb_puesto.Text) = "" Then
                    cadena = cadena & "  Escriba o seleccione un puesto" & vbCrLf
                    bandera_correcto = False
                End If
            End If
        End If

        If rb_cliente.Checked = True Then
            If CheckBoxSinCredito.Checked = False Then
                If CheckBoxSinLimite.Checked = False Then
                    If Trim(tb_limite_credito.Text) = "0.00" Then
                        cadena = cadena & "  Limite de credito" & vbCrLf
                        bandera_correcto = False
                    End If
                End If
            End If
        End If
        If tb_calle.Text = "" Then
            cadena = cadena & "  Calle" & vbCrLf
            bandera_correcto = False
        End If
        If tb_colonia.Text = "" Then
            cadena = cadena & "  Colonia" & vbCrLf
            bandera_correcto = False
        End If
        If tb_municipio.Text = "" Then
            cadena = cadena & "  Municipio" & vbCrLf
            bandera_correcto = False
        End If
        If tb_cp.Text = "" Then
            cadena = cadena & "  C.P." & vbCrLf
            bandera_correcto = False
        End If
        If tb_poblacion.Text = "" Then
            cadena = cadena & "  Poblacion" & vbCrLf
            bandera_correcto = False
        End If
        If cb_Noasignar_precio.Checked = False Then
            If cb_catalogo_precios.SelectedIndex = -1 Then
                cadena = cadena & "  Seleccione el precio para el cliente actual" & vbCrLf
                bandera_correcto = False
            End If

        End If
        ''Conectar()
        'conn.BeginTrans()
        'Try
        If bandera_correcto = True Then
            If bandera_actualizar = False Then
                '==guardamos el domicilio========================================
                'Conectar()
                conn.Execute("INSERT INTO domicilio(calle,num_ext,num_int,colonia,municipio,cp,poblacion,estado,pais) VALUES ('" & tb_calle.Text & "','" & tb_num_ext.Text & "','" & tb_num_int.Text & "','" & tb_colonia.Text & "', '" & tb_municipio.Text & "', '" & tb_cp.Text & "', '" & tb_poblacion.Text & "', '" & tb_estado.Text & "', '" & tb_pais.Text & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_domicilio = rs.Fields(0).Value
                rs.Close()
                'conn.close()
                '===============================================================
                '===guardamos como empleado?=======================================================
                If rb_empleado.Checked = True Then
                    Dim id_puesto As Integer = 0
                    'Conectar()
                    conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,rfc,email,alias,tel_fijo,tel_cel,whatsapp) VALUES ('" & tb_nombre.Text & "', '" & tb_apellidoP.Text & "', '" & tb_apellidoM.Text & "', '" & tb_rfcF.Text & "', '" & tb_emailF.Text & "','" & tb_alias_fisica.Text & "','" & tb_tel_fijo.Text & "','" & tb_tel_cel.Text & "','" & tb_whatsapp.Text & "')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_persona = rs.Fields(0).Value
                    rs.Close()
                    If cb_puesto.SelectedIndex = -1 Then
                        conn.Execute("INSERT INTO empleado_puesto(nombre) VALUES('" & cb_puesto.Text & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_puesto = rs.Fields(0).Value
                        rs.Close()
                    Else
                        id_puesto = CType(cb_puesto.SelectedItem, myItem).Value
                    End If
                    rs.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
                    rs.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
                    rs.ActiveConnection = conn
                    rs.Open("select * from empleado")
                    If rs.RecordCount <> 0 Then
                        rs.MoveFirst()
                    End If
                    rs.AddNew()
                    rs.Fields("id_puesto").Value = id_puesto
                    rs.Fields("curp").Value = tb_curp.Text
                    rs.Fields("id_persona").Value = id_persona
                    rs.Fields("id_domicilio").Value = id_domicilio
                    If bandera_Insertada = True Then
                        rs.Fields("imagen").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(150, pb_foto.BackgroundImage.Height / (pb_foto.BackgroundImage.Width / 150), Nothing, New IntPtr))
                        rs.Fields("thumb").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(60, pb_foto.BackgroundImage.Height / (pb_foto.BackgroundImage.Width / 60), Nothing, New IntPtr))
                    End If
                    '======GUARDAMOS LA HUELLA=========
                    If Not IsNothing(Enroller) Then
                        rs.Fields("huella").Value = Enroller.Template.Bytes
                    End If
                    '=================================
                    rs.Fields("fecha_modificacion").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                    rs.Fields("id_sucursal").Value = global_id_sucursal
                    rs.Update()
                    rs.Close()
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_empleado = rs.Fields(0).Value
                    rs.Close()
                    '====guardamos telefonos==========================================
                    For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                        conn.Execute("INSERT INTO telefono VALUES ('', '" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        conn.Execute("INSERT INTO empleado_tel VALUES (" & rs.Fields(0).Value & ", " & id_empleado & " )")
                        rs.Close()
                    Next
                    '==============================guardamos horarios
                    conn.Execute("INSERT INTO empleado_horario(id_empleado,hora_entrada,hora_salida,tolerancia) VALUES('" & id_empleado & "','" & Format(dtp_hora_entrada.Value, "HH:mm:ss") & "','" & Format(dtp_hora_salida.Value, "HH:mm:ss") & "','" & tb_minutos_tolerancia.Value & "')")
                    '=================================================
                    'conn.close()
                    cargar(id_empleado, 1)
                    MsgBox("EMPLEADO AGREGADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '=====guardamos como cliente======================================================

                If rb_cliente.Checked = True Then
                    If rb_fisica.Checked = True Then
                        'Conectar()
                        conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,rfc,email,alias,tel_fijo,tel_cel,whatsapp) VALUES ('" & tb_nombre.Text & "', '" & tb_apellidoP.Text & "', '" & tb_apellidoM.Text & "', '" & tb_rfcF.Text & "', '" & tb_emailF.Text & "','" & tb_alias_fisica.Text & "','" & tb_tel_fijo.Text & "','" & tb_tel_cel.Text & "','" & tb_whatsapp.Text & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_persona = rs.Fields(0).Value
                        rs.Close()
                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dg_telefonos.Item(corrimiento, 1) & "','" & dg_telefonos.Item(corrimiento, 2) & "')")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_telefono = rs.Fields(0).Value
                            conn.Execute("INSERT INTO persona_tel (id_telefono,id_persona)  VALUES ('" & rs.Fields(0).Value & "','" & id_persona & "')")
                            rs.Close()
                        Next
                        id_empresa = 0
                        'conn.close()
                    Else
                        'Conectar()
                        conn.Execute("INSERT INTO empresa (razon_social,alias,id_domicilio,url,rfc,email) VALUES ('" & tb_razon.Text & "', '" & tb_alias.Text & "', " & id_domicilio & ", '" & tb_url.Text & "', '" & tb_rfcM.Text & "','" & tb_emailM.Text & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_empresa = rs.Fields(0).Value
                        rs.Close()
                        For corrimiento = 0 To tablaContacto.Rows.Count - 1
                            conn.Execute("INSERT INTO persona (id_persona,nombre,ap_paterno,ap_materno,rfc,email) VALUES ( '', '" & dg_contacto.Item(corrimiento, 1) & "', '" & dg_contacto.Item(corrimiento, 2) & "', '" & dg_contacto.Item(corrimiento, 3) & "', '', '" & dg_contacto.Item(corrimiento, 4) & "')")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO empresa_contacto (id_persona,id_empresa) VALUES (" & rs.Fields(0).Value & ", " & id_empresa & " )")
                            rs.Close()
                        Next
                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_telefono = rs.Fields(0).Value
                            conn.Execute("INSERT INTO empresa_tel (id_empresa,id_telefono) VALUES (" & id_empresa & ", " & rs.Fields(0).Value & " )")
                            rs.Close()
                        Next
                        id_persona = 0
                        'conn.close()
                    End If

                    'Conectar()
                    conn.Execute("INSERT INTO cliente (clave,id_persona,id_empresa,id_domicilio,id_telefono,id_tipo,fecha_alta,fecha_modificacion) VALUES ( '" & tb_clave.Text & "','" & id_persona & "','" & id_empresa & "', '" & id_domicilio & "','" & id_telefono & "', '" & CType(cb_clasificacion.SelectedItem, myItem).Value & "',NOW(), NOW())")
                    Dim id_cliente As Integer = 0
                    rs.Open("SELECT last_insert_id()", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_cliente = rs.Fields(0).Value
                    '----guardamos cuentas bancarias
                    For corrimiento = 0 To tablaCuentas.Rows.Count - 1
                        conn.Execute("INSERT INTO cliente_cuenta (id_cliente,banco,cuenta,sucursal,clabe) VALUES (' " & rs.Fields(0).Value & "','" & Dg_cuentas.Item(corrimiento, 1) & "', '" & Dg_cuentas.Item(corrimiento, 2) & "', '" & Dg_cuentas.Item(corrimiento, 3) & "', '" & Dg_cuentas.Item(corrimiento, 4) & "' )")
                    Next
                    '-----------------------
                    '----guardamos productos del cliente
                    For corrimiento = 0 To tablaProductos.Rows.Count - 1
                        conn.Execute("INSERT INTO cliente_productos (id_cliente,id_producto,cantidad) VALUES (' " & rs.Fields(0).Value & "','" & dg_productos.Item(corrimiento, 0) & "', '" & dg_productos.Item(corrimiento, 2) & "' )")
                    Next
                    '-----------------------
                    '-----guardamos privilegios crediticios del cliente
                    Dim credito As Integer = 1 ' 0 sin credito, 1 con credito
                    Dim limite As Integer = 0 ' 0 sin limite, 1 con limite
                    If CheckBoxSinCredito.Checked = True Then
                        credito = 0
                    Else
                        If CheckBoxSinLimite.Checked = False Then
                            limite = 1
                        End If
                    End If
                    conn.Execute("INSERT INTO cliente_credito(id_cliente,credito,limite,limite_credito) VALUES (' " & rs.Fields(0).Value & "','" & credito & "', '" & limite & "', '" & CDbl(tb_limite_credito.Text) & "' )")
                    '------------------------------------------------
                    '-----guardamos precio del cliente
                    Dim id_catalogo_precio As Integer = 0
                    If cb_Noasignar_precio.Checked = False Then
                        id_catalogo_precio = CType(cb_catalogo_precios.SelectedItem, myItem).Value
                    End If
                    conn.Execute("INSERT INTO cliente_precio(id_cliente,id_ctlg_precios,autorizacion, aplicar_redondeo,mostrar_precios) VALUES (' " & rs.Fields(0).Value & "','" & id_catalogo_precio & "', '" & cb_autorizacion_precio.CheckState & "','" & chb_aplicar_redondeo.CheckState & "','" & chb_mostrar_precios.CheckState & "')")
                    '------------------------------------------------
                    rs.Close()
                    'conn.close()
                    If rb_fisica.Checked = True Then
                        cargar(id_cliente, 3)
                    Else
                        cargar(id_cliente, 2)
                    End If
                    id_cliente_asignar = id_cliente
                    frm_clientes.cargar_matriz_clientes()
                    MsgBox("CLIENTE AGREGADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '===========guardamos como proveedor==================================
                If rb_proveedor.Checked = True Then
                    If rb_fisica.Checked = True Then
                        '-guardamos proveedor fisica
                        'Conectar()
                        conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,rfc,email,alias,tel_fijo,tel_cel,whatsapp) VALUES ('" & tb_nombre.Text & "', '" & tb_apellidoP.Text & "', '" & tb_apellidoM.Text & "', '" & tb_rfcF.Text & "', '" & tb_emailF.Text & "','" & tb_alias_fisica.Text & "','" & tb_tel_fijo.Text & "','" & tb_tel_cel.Text & "','" & tb_whatsapp.Text & "')", , -1)
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_persona = rs.Fields(0).Value
                        rs.Close()
                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "')", , -1)
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO persona_tel (id_telefono,id_persona)  VALUES ('" & rs.Fields(0).Value & "', '" & id_persona & "')", , -1)
                            rs.Close()
                        Next
                        id_empresa = 0
                        'conn.close()
                    Else
                        'Conectar()
                        conn.Execute("INSERT INTO empresa (razon_social,alias,id_domicilio,url,rfc,email,tel_fijo,tel_cel,whatsapp) VALUES ( '" & tb_razon.Text & "', '" & tb_alias.Text & "', " & id_domicilio & ", '" & tb_url.Text & "', '" & tb_rfcM.Text & "','" & tb_emailM.Text & "','" & tb_tel_fijo.Text & "','" & tb_tel_cel.Text & "','" & tb_whatsapp.Text & "')", , -1)
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_empresa = rs.Fields(0).Value
                        rs.Close()
                        For corrimiento = 0 To tablaContacto.Rows.Count - 1
                            conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,email) VALUES ('" & dg_contacto.Item(corrimiento, 1) & "', '" & dg_contacto.Item(corrimiento, 2) & "', '" & dg_contacto.Item(corrimiento, 3) & "','" & dg_contacto.Item(corrimiento, 4) & "')", , -1)
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO empresa_contacto (id_persona,id_empresa) VALUES ('" & rs.Fields(0).Value & "', '" & id_empresa & "')", , -1)
                            rs.Close()
                        Next
                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "')", , -1)
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO empresa_tel (id_empresa,id_telefono) VALUES ('" & id_empresa & "', '" & rs.Fields(0).Value & "')", , -1)
                            rs.Close()
                        Next
                        id_persona = 0
                        'conn.close()
                    End If
                    'Conectar()
                    conn.Execute("INSERT INTO proveedor (clave,id_persona,id_empresa,id_domicilio,fecha_alta,fecha_modificacion) VALUES ('" & tb_clave.Text & "','" & id_persona & "', '" & id_empresa & "','" & id_domicilio & "',NOW(), NOW())", , -1)
                    Dim id_proveedor As Integer = 0
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_proveedor = rs.Fields(0).Value
                    '----cuentas bancarias
                    For corrimiento = 0 To tablaCuentas.Rows.Count - 1
                        conn.Execute("INSERT INTO proveedor_cuenta (id_proveedor,banco,cuenta,sucursal,clabe) VALUES (' " & rs.Fields(0).Value & "','" & Dg_cuentas.Item(corrimiento, 1) & "', '" & Dg_cuentas.Item(corrimiento, 2) & "', '" & Dg_cuentas.Item(corrimiento, 3) & "', '" & Dg_cuentas.Item(corrimiento, 4) & "' )")
                    Next
                    ' rs.Close()
                    '-----------------------
                    '----productos del proveedor
                    For corrimiento = 0 To tablaProductos.Rows.Count - 1
                        conn.Execute("INSERT INTO proveedor_productos (id_proveedor,id_producto,cantidad,precio_unitario) VALUES (' " & rs.Fields(0).Value & "','" & dg_productos.Item(corrimiento, 0) & "', '" & dg_productos.Item(corrimiento, 2) & "','" & dg_productos.Item(corrimiento, 3) & "' )")
                    Next
                    rs.Close()
                    '-----------------------
                    'conn.close()
                    If rb_fisica.Checked = True Then
                        cargar(id_proveedor, 5)
                    Else
                        cargar(id_proveedor, 4)
                    End If
                    MsgBox("PROVEEDOR AGREGADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '======================================================================

            Else
                ''actualizar
                '====actualizamos empleado======================================
                If tipo_bus = 1 Then
                    'Conectar()
                    Dim id_puesto As Integer = 0
                    If cb_puesto.SelectedIndex = -1 Then
                        conn.Execute("INSERT INTO empleado_puesto(nombre) VALUES('" & cb_puesto.Text & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_puesto = rs.Fields(0).Value
                        rs.Close()
                    Else
                        id_puesto = CType(cb_puesto.SelectedItem, myItem).Value
                    End If

                    rs.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                    rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
                    rs.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
                    rs.ActiveConnection = conn
                    rs.Open("select * from empleado where id_empleado=" & id)
                    rs.Fields("id_puesto").Value = id_puesto
                    rs.Fields("curp").Value = tb_curp.Text
                    rs.Fields("fecha_modificacion").Value = Format(Date.Today, "yyyy-MM-dd hh:mm:ss")
                    If bandera_Insertada = True Then
                        rs.Fields("imagen").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(150, 150, Nothing, New IntPtr))
                        rs.Fields("thumb").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(60, 60, Nothing, New IntPtr))
                    End If
                    '======GUARDAMOS LA HUELLA=========
                    If Not IsNothing(Enroller) Then
                        rs.Fields("huella").Value = Enroller.Template.Bytes
                    End If
                    '=================================
                    rs.Update()
                    rs.Close()
                    If bandera_telefonos = True Then
                        rs.Open("SELECT id_telefono FROM empleado_tel  WHERE id_empleado=" & id, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM telefono WHERE id_telefono='" & rs.Fields("id_telefono").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()

                        ' conn.Execute("DELETE FROM telefono WHERE id_telefono=(SELECT id_telefono FROM empleado_tel  WHERE id_empleado=" & id & ") ")
                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono VALUES ('', '" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

                            conn.Execute("INSERT INTO empleado_tel VALUES (" & rs.Fields(0).Value & ", " & id & " )")
                            rs.Close()
                        Next
                    End If
                    If bandera_horario = True Then
                        conn.Execute("UPDATE empleado_horario SET hora_entrada='" & Format(dtp_hora_entrada.Value, "HH:mm:ss") & "',hora_salida='" & Format(dtp_hora_salida.Value, "HH:mm:ss") & "',tolerancia='" & tb_minutos_tolerancia.Value & "' WHERE id_empleado=" & id)
                    End If
                    conn.Execute("UPDATE persona SET nombre='" & tb_nombre.Text & "',ap_paterno='" & tb_apellidoP.Text & "',ap_materno='" & tb_apellidoM.Text & "',rfc='" & tb_rfcF.Text & "',email='" & tb_emailF.Text & "',alias='" & tb_alias_fisica.Text & "',tel_fijo='" & tb_tel_fijo.Text & "',tel_cel='" & tb_tel_cel.Text & "',whatsapp='" & tb_whatsapp.Text & "' WHERE id_persona=" & id_persona)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',num_ext='" & tb_num_ext.Text & "',num_int='" & tb_num_int.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    'conn.close()
                    cargar(id, tipo_bus)
                    MsgBox("EMPLEADO ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '======================================================
                '=============actualizamos cliente moral==============
                If tipo_bus = 2 Then
                    'Conectar()
                    conn.Execute("UPDATE empresa  SET razon_social='" & tb_razon.Text & "',alias='" & tb_alias.Text & "',id_domicilio='" & id_domicilio & "',url='" & tb_url.Text & "',rfc='" & tb_rfcM.Text & "',email='" & tb_emailM.Text & "',tel_fijo='" & tb_tel_fijo.Text & "',tel_cel='" & tb_tel_cel.Text & "',whatsapp='" & tb_whatsapp.Text & "' WHERE id_empresa=" & id_empresa)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',num_ext='" & tb_num_ext.Text & "',num_int='" & tb_num_int.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    If bandera_telefonos = True Then
                        rs.Open("select t.id_telefono from cliente c,empresa e, telefono t,empresa_tel et  WHERE c.id_empresa=e.id_empresa AND et.id_empresa=e.id_empresa AND et.id_telefono=t.id_telefono AND e.id_empresa=" & id_empresa, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM telefono WHERE id_telefono='" & rs.Fields("id_telefono").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()

                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono () VALUES ('', '" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_telefono = rs.Fields(0).Value
                            conn.Execute("INSERT INTO empresa_tel VALUES (" & id_empresa & ", " & rs.Fields(0).Value & " )")
                            rs.Close()
                        Next
                    End If

                    If bandera_contacto = True Then
                        rs.Open("SELECT id_persona FROM empresa_contacto  WHERE id_empresa=" & id_empresa, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM persona WHERE id_persona='" & rs.Fields("id_persona").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()

                        'conn.Execute("DELETE FROM persona WHERE id_persona=(SELECT id_persona FROM empresa_contacto  WHERE id_empresa=" & id_empresa & ") ")
                        For corrimiento = 0 To tablaContacto.Rows.Count - 1
                            conn.Execute("INSERT INTO persona (id_persona,nombre,ap_paterno,ap_materno,rfc,email) VALUES ( '', '" & dg_contacto.Item(corrimiento, 1) & "', '" & dg_contacto.Item(corrimiento, 2) & "', '" & dg_contacto.Item(corrimiento, 3) & "', '', '" & dg_contacto.Item(corrimiento, 4) & "')")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO empresa_contacto VALUES (" & rs.Fields(0).Value & ", " & id_empresa & " )")
                            rs.Close()
                        Next
                    End If
                    If bandera_cuentas = True Then
                        conn.Execute("DELETE FROM cliente_cuenta WHERE id_cliente='" & id & "'")
                        '----cuentas bancarias
                        For corrimiento = 0 To tablaCuentas.Rows.Count - 1
                            conn.Execute("INSERT INTO cliente_cuenta (id_cliente,banco,cuenta,sucursal,clabe) VALUES (' " & id & "','" & Dg_cuentas.Item(corrimiento, 1) & "', '" & Dg_cuentas.Item(corrimiento, 2) & "', '" & Dg_cuentas.Item(corrimiento, 3) & "', '" & Dg_cuentas.Item(corrimiento, 4) & "' )")
                        Next
                        '-----------------------
                    End If
                    If bandera_productos = True Then
                        conn.Execute("DELETE FROM cliente_productos WHERE id_cliente='" & id & "'")
                        '----productos del cliente
                        For corrimiento = 0 To tablaProductos.Rows.Count - 1
                            conn.Execute("INSERT INTO cliente_productos (id_cliente,id_producto,cantidad) VALUES (' " & id & "','" & dg_productos.Item(corrimiento, 0) & "', '" & dg_productos.Item(corrimiento, 2) & "' )")
                        Next
                        '-----------------------
                    End If
                    If bandera_privilegios = True Then
                        '-----actualizamos privilegios crediticios del cliente
                        Dim credito As Integer = 1 ' 0 sin credito, 1 con credito
                        Dim limite As Integer = 0 ' 0 sin limite, 1 con limite
                        If CheckBoxSinCredito.Checked = True Then
                            credito = 0
                        Else
                            If CheckBoxSinLimite.Checked = False Then
                                limite = 1
                            End If
                        End If
                        conn.Execute("UPDATE cliente_credito SET credito='" & credito & "',limite='" & limite & "',limite_credito='" & CDbl(tb_limite_credito.Text) & "' WHERE id_cliente=" & id)
                        '------------------------------------------------
                        '-----guardamos precio del cliente
                        Dim id_catalogo_precio As Integer = 0
                        If cb_Noasignar_precio.Checked = False Then
                            id_catalogo_precio = CType(cb_catalogo_precios.SelectedItem, myItem).Value
                        End If
                        conn.Execute("UPDATE cliente_precio SET id_ctlg_precios='" & id_catalogo_precio & "',autorizacion='" & cb_autorizacion_precio.CheckState & "',aplicar_redondeo='" & chb_aplicar_redondeo.CheckState & "',mostrar_precios='" & chb_mostrar_precios.CheckState & "' WHERE id_cliente=" & id)
                        '------------------------------------------------
                    End If
                    conn.Execute("UPDATE cliente  SET clave='" & tb_clave.Text & "',id_tipo='" & CType(cb_clasificacion.SelectedItem, myItem).Value & "',id_telefono='" & id_telefono & "',fecha_modificacion=NOW() WHERE id_cliente=" & id)
                    'conn.close()
                    cargar(id, tipo_bus)
                    id_cliente_asignar = id
                    frm_clientes.cargar_matriz_clientes()
                    MsgBox("CLIENTE ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '========================================================================
                '=============actualizamos cliente fisico==============
                If tipo_bus = 3 Then
                    'Conectar()
                    conn.Execute("UPDATE persona  SET nombre='" & tb_nombre.Text & "',ap_paterno='" & tb_apellidoP.Text & "',ap_materno='" & tb_apellidoM.Text & "',rfc='" & tb_rfcF.Text & "',email='" & tb_emailF.Text & "',alias='" & tb_alias_fisica.Text & "',tel_fijo='" & tb_tel_fijo.Text & "',tel_cel='" & tb_tel_cel.Text & "',whatsapp='" & tb_whatsapp.Text & "'  WHERE id_persona=" & id_persona)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',num_ext='" & tb_num_ext.Text & "',num_int='" & tb_num_int.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    If bandera_telefonos = True Then
                        rs.Open("select t.id_telefono from cliente c,persona p, telefono t,persona_tel pt WHERE c.id_persona=p.id_persona AND pt.id_persona=p.id_persona AND pt.id_telefono=t.id_telefono AND p.id_persona=" & id_persona, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM telefono WHERE id_telefono='" & rs.Fields("id_telefono").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()


                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono () VALUES ('', '" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_telefono = rs.Fields(0).Value
                            conn.Execute("INSERT INTO persona_tel(id_persona,id_telefono) VALUES (" & id_persona & ", " & rs.Fields(0).Value & " )")
                            rs.Close()
                        Next
                    End If
                    If bandera_cuentas = True Then
                        conn.Execute("DELETE FROM cliente_cuenta WHERE id_cliente='" & id & "'")
                        '----cuentas bancarias
                        For corrimiento = 0 To tablaCuentas.Rows.Count - 1
                            conn.Execute("INSERT INTO cliente_cuenta (id_cliente,banco,cuenta,sucursal,clabe) VALUES (' " & id & "','" & Dg_cuentas.Item(corrimiento, 1) & "', '" & Dg_cuentas.Item(corrimiento, 2) & "', '" & Dg_cuentas.Item(corrimiento, 3) & "', '" & Dg_cuentas.Item(corrimiento, 4) & "' )")
                        Next
                        '-----------------------
                    End If
                    If bandera_productos = True Then
                        conn.Execute("DELETE FROM cliente_productos WHERE id_cliente='" & id & "'")
                        '----productos del cliente
                        For corrimiento = 0 To tablaProductos.Rows.Count - 1
                            conn.Execute("INSERT INTO cliente_productos (id_cliente,id_producto,cantidad) VALUES (' " & id & "','" & dg_productos.Item(corrimiento, 0) & "', '" & dg_productos.Item(corrimiento, 2) & "' )")
                        Next
                        '-----------------------
                    End If
                    If bandera_privilegios = True Then
                        '-----actualizamos privilegios crediticios del cliente
                        Dim credito As Integer = 1 ' 0 sin credito, 1 con credito
                        Dim limite As Integer = 0 ' 0 sin limite, 1 con limite
                        If CheckBoxSinCredito.Checked = True Then
                            credito = 0
                        Else
                            If CheckBoxSinLimite.Checked = False Then
                                limite = 1
                            End If
                        End If
                        conn.Execute("UPDATE cliente_credito SET credito='" & credito & "',limite='" & limite & "',limite_credito='" & CDbl(tb_limite_credito.Text) & "' WHERE id_cliente=" & id)
                        '------------------------------------------------
                        '-----guardamos precio del cliente
                        Dim id_catalogo_precio As Integer = 0
                        If cb_Noasignar_precio.Checked = False Then
                            id_catalogo_precio = CType(cb_catalogo_precios.SelectedItem, myItem).Value
                        End If
                        conn.Execute("UPDATE cliente_precio SET id_ctlg_precios='" & id_catalogo_precio & "',autorizacion='" & cb_autorizacion_precio.CheckState & "',aplicar_redondeo='" & chb_aplicar_redondeo.CheckState & "',mostrar_precios='" & chb_mostrar_precios.CheckState & "' WHERE id_cliente=" & id)
                        '------------------------------------------------
                    End If
                    'if bandera_contacto = True Then
                    'onn.Execute("DELETE FROM persona WHERE id_persona=(SELECT id_persona FROM empresa_contacto  WHERE id_empresa=" & id_empresa & ") ")
                    'For corrimiento = 0 To tablaContacto.Rows.Count - 1
                    'onn.Execute("INSERT INTO persona (id_persona,nombre,ap_paterno,ap_materno,rfc,email) VALUES ( '', '" & dg_contacto.Item(corrimiento, 1) & "', '" & dg_contacto.Item(corrimiento, 2) & "', '" & dg_contacto.Item(corrimiento, 3) & "', '', '" & dg_contacto.Item(corrimiento, 4) & "')")
                    'rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    'conn.Execute("INSERT INTO empresa_contacto VALUES (" & rs.Fields(0).Value & ", " & id_empresa & " )")
                    'rs.Close()
                    'Next
                    'End If
                    conn.Execute("UPDATE cliente  SET clave='" & tb_clave.Text & "', id_tipo='" & CType(cb_clasificacion.SelectedItem, myItem).Value & "',id_telefono='" & id_telefono & "',fecha_modificacion=NOW() WHERE id_cliente=" & id)
                    'conn.close()
                    cargar(id, tipo_bus)
                    id_cliente_asignar = id
                    MsgBox("CLIENTE ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '========================================================================
                '=============actualizamos proveedor moral==============
                If tipo_bus = 4 Then
                    'Conectar()
                    conn.Execute("UPDATE proveedor SET clave='" & tb_clave.Text & "', fecha_modificacion=NOW() WHERE id_proveedor=" & id)
                    conn.Execute("UPDATE empresa  SET razon_social='" & tb_razon.Text & "',alias='" & tb_alias.Text & "',id_domicilio='" & id_domicilio & "',url='" & tb_url.Text & "',rfc='" & tb_rfcM.Text & "',email='" & tb_emailM.Text & "',tel_fijo='" & tb_tel_fijo.Text & "',tel_cel='" & tb_tel_cel.Text & "',whatsapp='" & tb_whatsapp.Text & "' WHERE id_empresa=" & id_empresa)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',num_ext='" & tb_num_ext.Text & "',num_int='" & tb_num_int.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    If bandera_telefonos = True Then
                        rs.Open("SELECT id_telefono FROM empresa_tel  WHERE id_empresa=" & id_empresa, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM telefono WHERE id_telefono='" & rs.Fields("id_telefono").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()

                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono () VALUES ('', '" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO empresa_tel VALUES (" & id_empresa & ", " & rs.Fields(0).Value & " )")
                            rs.Close()
                        Next
                    End If
                    If bandera_contacto = True Then
                        rs.Open("SELECT id_persona FROM empresa_contacto  WHERE id_empresa=" & id_empresa, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM persona WHERE id_persona='" & rs.Fields("id_persona").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()

                        'conn.Execute("DELETE FROM persona WHERE id_persona=(SELECT id_persona FROM empresa_contacto  WHERE id_empresa=" & id_empresa & ") ")
                        For corrimiento = 0 To tablaContacto.Rows.Count - 1
                            conn.Execute("INSERT INTO persona (id_persona,nombre,ap_paterno,ap_materno,rfc,email) VALUES ( '', '" & dg_contacto.Item(corrimiento, 1) & "', '" & dg_contacto.Item(corrimiento, 2) & "', '" & dg_contacto.Item(corrimiento, 3) & "', '', '" & dg_contacto.Item(corrimiento, 4) & "')")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO empresa_contacto VALUES (" & rs.Fields(0).Value & ", " & id_empresa & " )")
                            rs.Close()
                        Next
                    End If
                    If bandera_cuentas = True Then
                        conn.Execute("DELETE FROM proveedor_cuenta WHERE id_proveedor='" & id & "'")
                        '----cuentas bancarias
                        For corrimiento = 0 To tablaCuentas.Rows.Count - 1
                            conn.Execute("INSERT INTO proveedor_cuenta (id_proveedor,banco,cuenta,sucursal,clabe) VALUES (' " & id & "','" & Dg_cuentas.Item(corrimiento, 1) & "', '" & Dg_cuentas.Item(corrimiento, 2) & "', '" & Dg_cuentas.Item(corrimiento, 3) & "', '" & Dg_cuentas.Item(corrimiento, 4) & "' )")
                        Next
                        '-----------------------
                    End If
                    If bandera_productos = True Then
                        conn.Execute("DELETE FROM proveedor_productos WHERE id_proveedor='" & id & "'")
                        '----productos del cliente
                        For corrimiento = 0 To tablaProductos.Rows.Count - 1
                            conn.Execute("INSERT INTO proveedor_productos (id_proveedor,id_producto,cantidad,precio_unitario) VALUES (' " & id & "','" & dg_productos.Item(corrimiento, 0) & "', '" & dg_productos.Item(corrimiento, 2) & "','" & dg_productos.Item(corrimiento, 3) & "' )")
                        Next
                        '-----------------------
                    End If
                    'conn.close()
                    cargar(id, tipo_bus)
                    MsgBox("PROVEEDOR ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '========================================================================
                '=============actualizamos proveedor fisico==============
                If tipo_bus = 5 Then
                    'Conectar()
                    conn.Execute("UPDATE proveedor SET clave='" & tb_clave.Text & "', fecha_modificacion=NOW() WHERE id_proveedor=" & id)
                    conn.Execute("UPDATE persona  SET nombre='" & tb_nombre.Text & "',ap_paterno='" & tb_apellidoP.Text & "',ap_materno='" & tb_apellidoM.Text & "',rfc='" & tb_rfcF.Text & "',email='" & tb_emailF.Text & "',alias='" & tb_alias_fisica.Text & "',tel_fijo='" & tb_tel_fijo.Text & "',tb_tel_cel='" & tb_tel_cel.Text & "',whatsapp='" & tb_whatsapp.Text & "'  WHERE id_persona=" & id_persona)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',num_ext='" & tb_num_ext.Text & "',num_int='" & tb_num_int.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    If bandera_telefonos = True Then
                        rs.Open("SELECT id_telefono FROM persona_tel  WHERE id_persona=" & id_persona, conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                If rs.RecordCount > 0 Then
                                    conn.Execute("DELETE FROM telefono WHERE id_telefono='" & rs.Fields("id_telefono").Value & "'")
                                    rs.MoveNext()
                                End If
                            End While
                        End If
                        rs.Close()

                        For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                            conn.Execute("INSERT INTO telefono () VALUES ('', '" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "' )")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("INSERT INTO persona_tel(id_persona,id_telefono) VALUES (" & id_persona & ", " & rs.Fields(0).Value & " )")
                            rs.Close()
                        Next
                    End If
                    If bandera_cuentas = True Then
                        conn.Execute("DELETE FROM proveedor_cuenta WHERE id_proveedor='" & id & "'")
                        '----cuentas bancarias
                        For corrimiento = 0 To tablaCuentas.Rows.Count - 1
                            conn.Execute("INSERT INTO proveedor_cuenta (id_proveedor,banco,cuenta,sucursal,clabe) VALUES (' " & id & "','" & Dg_cuentas.Item(corrimiento, 1) & "', '" & Dg_cuentas.Item(corrimiento, 2) & "', '" & Dg_cuentas.Item(corrimiento, 3) & "', '" & Dg_cuentas.Item(corrimiento, 4) & "' )")
                        Next
                        '-----------------------
                    End If
                    If bandera_productos = True Then
                        conn.Execute("DELETE FROM proveedor_productos WHERE id_proveedor='" & id & "'")
                        '----productos del cliente
                        For corrimiento = 0 To tablaProductos.Rows.Count - 1
                            conn.Execute("INSERT INTO proveedor_productos (id_proveedor,id_producto,cantidad,precio_unitario) VALUES (' " & id & "','" & dg_productos.Item(corrimiento, 0) & "', '" & dg_productos.Item(corrimiento, 2) & "','" & dg_productos.Item(corrimiento, 3) & "' )")
                        Next
                        '-----------------------
                    End If

                    'if bandera_contacto = True Then
                    'onn.Execute("DELETE FROM persona WHERE id_persona=(SELECT id_persona FROM empresa_contacto  WHERE id_empresa=" & id_empresa & ") ")
                    'For corrimiento = 0 To tablaContacto.Rows.Count - 1
                    'onn.Execute("INSERT INTO persona (id_persona,nombre,ap_paterno,ap_materno,rfc,email) VALUES ( '', '" & dg_contacto.Item(corrimiento, 1) & "', '" & dg_contacto.Item(corrimiento, 2) & "', '" & dg_contacto.Item(corrimiento, 3) & "', '', '" & dg_contacto.Item(corrimiento, 4) & "')")
                    'rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    'conn.Execute("INSERT INTO empresa_contacto VALUES (" & rs.Fields(0).Value & ", " & id_empresa & " )")
                    'rs.Close()
                    'Next
                    'End If
                    'conn.close()
                    cargar(id, tipo_bus)
                    MsgBox("PROVEEDOR ACTUALIZADO CORRECTAMENTE", MsgBoxStyle.Information, "AVISO")
                    If MsgBox("¿Desea agregar o modificar otro registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Aviso") = MsgBoxResult.No Then
                        Me.Close()
                    End If
                    Exit Sub
                End If
                '========================================================================

            End If
            'conn.CommitTrans()
            ''conn.close()
            ''conn.close()
            ''conn = Nothing
         
        Else
            MsgBox(cadena)
            'conn.RollbackTrans()
            ''conn.close()
            ''conn = Nothing
        End If
        ' Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub tb_numInt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_numExt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_emailM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_emailM.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.Focus()
        End If
    End Sub

    Private Sub tb_emailM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_emailM.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a", ".\-_@"})
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        cargar()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cliente.CheckedChanged
        gb_tipo.Visible = True
        gb_tipo.Height = 81
        Panel7.Enabled = True
        gb_persona.Text = "Datos del cliente"
        gb_empresa.Text = "Datos del cliente"
        Panel2.Visible = False
        gb_persona.Height = 160
        Panel2.Visible = False
        tab_foto.Parent = Nothing
        tab_cuenta.Parent = TabDirectorio
        tab_productos.Parent = TabDirectorio
        tab_huella.Parent = Nothing
        tab_horario.Parent = Nothing
        tab_privilegios.Parent = TabDirectorio
        lbl_producto_precio.Visible = False
        tb_producto_precio.Visible = False

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_empleado.CheckedChanged
        gb_tipo.Visible = False
        gb_empresa.Visible = False
        rb_fisica.Checked = True
        gb_persona.Text = "Datos del empleado"
        Panel2.Visible = True
        gb_persona.Height = 221
        tab_foto.Parent = TabDirectorio
        Panel7.Enabled = False
        tab_cuenta.Parent = Nothing
        tab_productos.Parent = Nothing
        tab_huella.Parent = TabDirectorio
        tab_horario.Parent = TabDirectorio
        tab_privilegios.Parent = Nothing
    End Sub

    Private Sub rb_proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_proveedor.CheckedChanged
        gb_tipo.Visible = True
        gb_tipo.Height = 43
        gb_persona.Text = "Datos del proveedor"
        gb_empresa.Text = "Datos del proveedor"
        Panel2.Visible = False
        gb_persona.Height = 160
        Panel2.Visible = False
        tab_foto.Parent = Nothing
        Panel7.Enabled = False
        tab_cuenta.Parent = TabDirectorio
        tab_productos.Parent = TabDirectorio
        tab_huella.Parent = Nothing
        tab_privilegios.Parent = Nothing
        lbl_producto_precio.Visible = True
        tb_producto_precio.Visible = True
    End Sub

    Private Sub tb_rfcM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_rfcM.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a"})
    End Sub

    Private Sub tb_rfcF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_rfcF.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a"})
    End Sub

    Private Sub tb_curp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_curp.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a"})
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ofd_foto.ShowDialog()
        ' If bandera_Insertada = False Then
        'MsgBox("Tamaño de la imagen sobrepasa lo permitido")
        'ofd_foto.FileName = ""
        'bandera_Insertada = True
        'Button9_Click(sender, e)
        'End If
    End Sub

    Private Sub ofd_foto_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofd_foto.FileOk
        Dim tamaño As Integer
        Dim File As New System.IO.FileInfo(ofd_foto.FileName)
        tamaño = File.Length / 1024
        bandera_Insertada = True
        If ofd_foto.FileName <> "" Then
            'If (tamaño < 63) Then
            pb_foto.BackgroundImage = New Bitmap(ofd_foto.FileName)
            bandera = True
            '
            ' bandera_Insertada = False
            ' End If
        End If

    End Sub
    Private Sub tb_cp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cp.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub
    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        frm_directorio_abrir.ShowDialog()
        frm_directorio_abrir.BringToFront()
    End Sub

    Private Sub dg_telefonos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_telefonos.DoubleClick
        If tablaTelefono.Rows.Count <> 0 Then
            gb_datos_telefono.Enabled = True
            Panel1.Enabled = False
            Panel3.Enabled = False
            Panel5.Enabled = False
            Tb_lada.Text = dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 1)
            tb_telefono.Text = dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 2)
            Button7.Text = "Actualizar"
        End If
    End Sub

    Private Sub dg_contacto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_contacto.DoubleClick
        If tablaContacto.Rows.Count <> 0 Then
            gb_datos_contacto.Enabled = True
            Button1.Enabled = False
            Button2.Enabled = False
            Panel1.Enabled = False
            Panel3.Enabled = False
            Panel4.Enabled = False
            tb_nombre_contacto.Text = dg_contacto.Item(dg_contacto.CurrentCell.RowNumber, 1)
            tb_apellidoP_contacto.Text = dg_contacto.Item(dg_contacto.CurrentCell.RowNumber, 2)
            tb_apellidoM_contacto.Text = dg_contacto.Item(dg_contacto.CurrentCell.RowNumber, 3)
            tb_email_contacto.Text = dg_contacto.Item(dg_contacto.CurrentCell.RowNumber, 4)
            Button3.Text = "Actualizar"
        End If

    End Sub
    Private Sub btn_agregar_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_cuenta.Click
        gb_cuentas.Enabled = True
        Panel1.Enabled = False
        Panel3.Enabled = False
        Panel5.Enabled = False
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar_cuenta.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        If cb_banco.SelectedIndex = -1 Then
            cadena = cadena & "  Banco" & vbCrLf
            bandera_correcto = False
        End If
        If Trim(tb_cuenta.TextLength = 0) Then
            cadena = cadena & "  Cuenta" & vbCrLf
            bandera_correcto = False
        End If
        If Trim(tb_sucursal.TextLength = 0) Then
            cadena = cadena & "  Sucursal" & vbCrLf
            bandera_correcto = False
        End If
        If Trim(tb_clabe.TextLength = 0) Then
            cadena = cadena & "  Clabe Interbancaria" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            If btn_aceptar_cuenta.Text = "Aceptar" Then
                Linea = tablaCuentas.NewRow()
                Linea(0) = 0
                Linea(1) = cb_banco.Text
                Linea(2) = tb_cuenta.Text
                Linea(3) = tb_sucursal.Text
                Linea(4) = tb_clabe.Text
                tablaCuentas.Rows.Add(Linea)
            Else
                Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 1) = cb_banco.Text
                Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 2) = tb_cuenta.Text
                Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 3) = tb_sucursal.Text
                Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 4) = tb_clabe.Text
            End If
            btn_aceptar_cuenta.Text = "Aceptar"
            tb_cuenta.Text = ""
            tb_sucursal.Text = ""
            tb_sucursal.Text = ""
            tb_clabe.Text = ""
            gb_cuentas.Enabled = False
            Panel1.Enabled = True
            Panel3.Enabled = True
            Panel5.Enabled = True
            bandera_cuentas = True
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub btn_cancelar_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_cuenta.Click
        tb_cuenta.Text = ""
        tb_sucursal.Text = ""
        tb_sucursal.Text = ""
        tb_clabe.Text = ""
        Tb_lada.Text = ""
        gb_cuentas.Enabled = False
        Panel1.Enabled = True
        Panel3.Enabled = True
        Panel5.Enabled = True
        btn_aceptar_cuenta.Text = "Aceptar"
    End Sub

    Private Sub btn_quitar_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_cuenta.Click
        Dim contador As Integer
        contador = tablaCuentas.Rows.Count
        While 0 < contador
            If Dg_cuentas.IsSelected(contador - 1) = True Then
                tablaCuentas.Rows.Item(contador - 1).Delete()
                bandera_cuentas = True
            End If
            contador = contador - 1
        End While
    End Sub

    Private Sub Dg_cuentas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dg_cuentas.DoubleClick
        If tablaCuentas.Rows.Count <> 0 Then
            gb_cuentas.Enabled = True
            Panel1.Enabled = False
            Panel3.Enabled = False
            Panel5.Enabled = False
            cb_banco.Text = Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 1)
            tb_cuenta.Text = Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 2)
            tb_sucursal.Text = Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 3)
            tb_clabe.Text = Dg_cuentas.Item(Dg_cuentas.CurrentCell.RowNumber, 4)
            btn_aceptar_cuenta.Text = "Actualizar"
        End If
    End Sub


    Private Sub btn_agregar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_productos.Click
        gb_datos_productos.Enabled = True
        Panel1.Enabled = False
        Panel3.Enabled = False
        Panel5.Enabled = False
    End Sub

    Private Sub btn_quitar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_productos.Click
        Dim contador As Integer
        contador = tablaProductos.Rows.Count
        While 0 < contador
            If dg_productos.IsSelected(contador - 1) = True Then
                tablaProductos.Rows.Item(contador - 1).Delete()
                bandera_productos = True
            End If
            contador = contador - 1
        End While
    End Sub

    Private Sub btn_aceptar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar_productos.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        If cb_productos.SelectedIndex = -1 Then
            cadena = cadena & "  Producto" & vbCrLf
            bandera_correcto = False
        End If
        If Trim(tb_cantidad_producto.TextLength = 0) Then
            cadena = cadena & "  Cantidad" & vbCrLf
            bandera_correcto = False
        End If
        If rb_proveedor.Checked = True Then
            If tb_producto_precio.Text = "" Then
                cadena = cadena & "  Precio de producto" & vbCrLf
                bandera_correcto = False
            End If
        End If

        If bandera_correcto = True Then
            If btn_aceptar_productos.Text = "Aceptar" Then
                Linea = tablaProductos.NewRow()
                Linea(0) = CType(cb_productos.SelectedItem, myItem).Value
                Linea(1) = cb_productos.Text
                Linea(2) = tb_cantidad_producto.Text
                Linea(3) = tb_producto_precio.Text
                tablaProductos.Rows.Add(Linea)
            Else
                dg_productos.Item(dg_productos.CurrentCell.RowNumber, 0) = CType(cb_productos.SelectedItem, myItem).Value
                dg_productos.Item(dg_productos.CurrentCell.RowNumber, 1) = cb_productos.Text
                dg_productos.Item(dg_productos.CurrentCell.RowNumber, 2) = tb_cantidad_producto.Text
                dg_productos.Item(dg_productos.CurrentCell.RowNumber, 3) = tb_producto_precio.Text
            End If
            btn_aceptar_productos.Text = "Aceptar"
            cb_productos.SelectedIndex = -1
            cb_productos.Text = ""
            tb_producto_precio.Text = ""
            tb_cantidad_producto.Text = ""
            gb_cuentas.Enabled = False
            Panel1.Enabled = True
            Panel3.Enabled = True
            Panel5.Enabled = True
            bandera_productos = True
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub btn_cancelar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_productos.Click
        cb_productos.Text = ""
        cb_productos.SelectedIndex = -1
        tb_cantidad_producto.Text = ""
        gb_datos_productos.Enabled = False
        Panel1.Enabled = True
        Panel3.Enabled = True
        Panel5.Enabled = True
        btn_aceptar_productos.Text = "Aceptar"
    End Sub

    Private Sub dg_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_productos.DoubleClick
        If tablaProductos.Rows.Count <> 0 Then
            gb_datos_productos.Enabled = True
            Panel1.Enabled = False
            Panel3.Enabled = False
            Panel5.Enabled = False
            cb_productos.Text = dg_productos.Item(dg_productos.CurrentCell.RowNumber, 1)
            tb_cantidad_producto.Text = dg_productos.Item(dg_productos.CurrentCell.RowNumber, 2)
            If rb_proveedor.Checked = True Then
                tb_producto_precio.Text = dg_productos.Item(dg_productos.CurrentCell.RowNumber, 3)
            End If
            btn_aceptar_productos.Text = "Actualizar"
        End If
    End Sub
    Private Sub CheckBoxSinLimite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSinLimite.CheckedChanged
        If CheckBoxSinLimite.Checked = True Then
            tb_limite_credito.Enabled = False
            'CheckBoxSinCredito.Enabled = False
        Else
            tb_limite_credito.Enabled = True
            'CheckBoxSinCredito.Enabled = False
        End If
        bandera_privilegios = True
    End Sub

    Private Sub CheckBoxSinCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSinCredito.CheckedChanged
        If CheckBoxSinCredito.Checked = True Then
            CheckBoxSinLimite.Checked = False
            CheckBoxSinLimite.Enabled = False
            tb_limite_credito.Enabled = False
            tb_limite_credito.Text = "0.00"
        Else
            'CheckBoxSinLimite.Checked = True
            tb_limite_credito.Enabled = True
            CheckBoxSinLimite.Enabled = True
        End If
        bandera_privilegios = True
    End Sub

    Private Sub tb_limite_credito_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_limite_credito.KeyDown
        If e.KeyCode = Keys.Enter Then
            tb_limite_credito.Text = FormatNumber(tb_limite_credito.Text, 2)
        End If
    End Sub

    Private Sub tb_limite_credito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_limite_credito.KeyPress
        e.Handled = txtNumerico(tb_limite_credito, e.KeyChar, True)
    End Sub
    Private Sub tb_numExt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cb_asignar_precio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_Noasignar_precio.CheckedChanged
        If cb_Noasignar_precio.Checked = True Then
            cb_autorizacion_precio.Checked = False
            cb_autorizacion_precio.Enabled = False
            cb_catalogo_precios.Text = ""
            cb_catalogo_precios.SelectedIndex = -1
            cb_catalogo_precios.Enabled = False
            lbl_ganancia.Text = ""
            lbl_descuento.Text = ""
        Else
            cb_autorizacion_precio.Enabled = True
            cb_catalogo_precios.Enabled = True
        End If
        bandera_privilegios = True
    End Sub

    Private Sub cb_autorizacion_precio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_autorizacion_precio.CheckedChanged
        bandera_privilegios = True
    End Sub

    Private Sub cb_catalogo_precios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_catalogo_precios.SelectedIndexChanged
        If cb_catalogo_precios.SelectedIndex <> -1 Then
            lbl_ganancia.Text = "Ganancia de " & CType(cb_catalogo_precios.SelectedItem, myItem).Opcional & " %"
            lbl_descuento.Text = "Descuento de " & maxima_utilidad - CDbl(CType(cb_catalogo_precios.SelectedItem, myItem).Opcional) & " %"
        End If
        bandera_privilegios = True
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If existen_turnos_abiertos() = False Then
            If rb_empleado.Checked = True Then
                If id <> 1 Then
                    eliminar_empleado(id)
                Else
                    MsgBox("Esta acción no esta permitida para este empleado. Se ha cancelado la operación", MsgBoxStyle.Information, "Aviso")
                End If

            ElseIf rb_cliente.Checked = True Then

                If id <> 1 Then
                    eliminar_cliente(id)
                Else
                    MsgBox("Esta acción no esta permitida para este cliente. Se ha cancelado la operación", MsgBoxStyle.Information, "Aviso")
                End If
            ElseIf rb_proveedor.Checked = True Then
                eliminar_proveedor(id)
            End If
        Else
            MsgBox("Se encontro turno(s) abierto(s), para realizar esta operacion, todos los usuarios deben realizar corte de caja!", MsgBoxStyle.Exclamation, "aviso")
        End If

    End Sub
    Private Sub eliminar_cliente(ByVal id_cliente As Integer)
        If MsgBox("Desea eliminar este cliente?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If MsgBox("ESTA OPERACIÓN NO SE PODRÁ DESHACER POSTERIORMENTE, EL CLIENTE DESAPARECERÁ DE LOS REPORTES. ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirmación") = MsgBoxResult.Yes Then
                Dim rx As New ADODB.Recordset
                Dim rz As New ADODB.Recordset

                'Conectar()
                rs.Open("SELECT id_persona,id_empresa,id_domicilio,id_telefono FROM cliente WHERE id_cliente=" & id_cliente, conn)
                If rs.RecordCount > 0 Then
                    conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rs.Fields("id_telefono").Value)

                    '---eliminamos empresa-----

                    rx.Open("SELECT id_telefono FROM empresa_tel WHERE id_empresa=" & rs.Fields("id_empresa").Value, conn)
                    If rx.RecordCount > 0 Then
                        conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rx.Fields("id_telefono").Value)
                    End If
                    rx.Close()
                    conn.Execute("DELETE FROM empresa_tel WHERE id_empresa=" & rs.Fields("id_empresa").Value)
                    rx.Open("SELECT id_persona FROM empresa_contacto WHERE id_empresa=" & rs.Fields("id_empresa").Value, conn)
                    If rx.RecordCount > 0 Then
                        conn.Execute("DELETE FROM persona WHERE id_persona=" & rx.Fields("id_persona").Value)
                        rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value, conn)
                        If rz.RecordCount > 0 Then
                            conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                        End If
                        rz.Close()
                        conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value)

                    End If
                    rx.Close()
                    conn.Execute("DELETE FROM empresa_contacto WHERE id_empresa=" & rs.Fields("id_empresa").Value)
                    conn.Execute("DELETE FROM empresa WHERE id_empresa=" & rs.Fields("id_empresa").Value)
                    '-------------------------
                    '---eliminamos persona-----
                    rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rs.Fields("id_persona").Value, conn)
                    If rz.RecordCount > 0 Then
                        conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                    End If
                    rz.Close()
                    conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rs.Fields("id_persona").Value)
                    conn.Execute("DELETE FROM persona WHERE id_persona=" & rs.Fields("id_persona").Value)
                    '-------------------------
                    conn.Execute("DELETE FROM cliente WHERE id_cliente=" & id_cliente)
                    conn.Execute("DELETE FROM domicilio WHERE id_domicilio=" & rs.Fields("id_domicilio").Value)
                End If
                rs.Close()
                conn.Execute("DELETE FROM cliente_cuenta WHERE id_cliente=" & id_cliente)
                conn.Execute("DELETE FROM cliente_productos WHERE id_cliente=" & id_cliente)
                conn.Execute("DELETE FROM cliente_credito WHERE id_cliente=" & id_cliente)
                conn.Execute("DELETE FROM cliente_precio WHERE id_cliente=" & id_cliente)

                'conn.close()
                cargar()
                MsgBox("Cliente eliminado correctamente", MsgBoxStyle.Exclamation, "Aviso")

            End If
        End If
    End Sub
    Private Sub eliminar_empleado(ByVal id_empleado As Integer)
        If MsgBox("Desea eliminar este empleado?.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If MsgBox("ESTA OPERACIÓN NO SE PODRÁ DESHACER POSTERIORMENTE, EL EMPLEADO DESAPARECERÁ DE LOS REPORTES. ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirmación") = MsgBoxResult.Yes Then
                Dim rx As New ADODB.Recordset
                Dim rz As New ADODB.Recordset

                'Conectar()

                rz.Open("SELECT id_telefono FROM empleado_tel WHERE id_empleado=" & id_empleado, conn)
                If rz.RecordCount > 0 Then
                    conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                End If
                rz.Close()

                conn.Execute("DELETE FROM empleado_tel WHERE id_empleado=" & id_empleado)
                rs.Open("SELECT id_persona,id_domicilio FROM empleado WHERE id_empleado=" & id_empleado, conn)
                If rs.RecordCount > 0 Then

                    conn.Execute("DELETE FROM empleado WHERE id_empleado=" & id_empleado)

                    '---eliminamos persona-----
                    rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rs.Fields("id_persona").Value, conn)
                    If rz.RecordCount > 0 Then
                        conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                    End If
                    rz.Close()
                    conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rs.Fields("id_persona").Value)
                    conn.Execute("DELETE FROM persona WHERE id_persona=" & rs.Fields("id_persona").Value)
                    '-------------------------

                    conn.Execute("DELETE FROM domicilio WHERE id_domicilio=" & rs.Fields("id_domicilio").Value)
                End If
                rs.Close()


                conn.Execute("DELETE FROM usuario WHERE id_empleado=" & id_empleado)
                'conn.close()
                cargar()
                MsgBox("Empleado eliminado correctamente", MsgBoxStyle.Exclamation, "Aviso")
            End If
        End If
    End Sub
    Private Sub eliminar_proveedor(ByVal id_proveedor As Integer)
        If MsgBox("Desea eliminar este proveedor?.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If MsgBox("ESTA OPERACIÓN NO SE PODRÁ DESHACER POSTERIORMENTE, EL PROVEEDOR DESAPARECERÁ DE LOS REPORTES. ¿DESEA CONTINUAR?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirmación") = MsgBoxResult.Yes Then
                Dim rx As New ADODB.Recordset
                Dim rz As New ADODB.Recordset

                'Conectar()
                rs.Open("SELECT id_persona,id_empresa,id_domicilio FROM proveedor WHERE id_proveedor=" & id_proveedor, conn)
                If rs.RecordCount > 0 Then

                    '---eliminamos empresa-----

                    rx.Open("SELECT id_telefono FROM empresa_tel WHERE id_empresa=" & rs.Fields("id_empresa").Value, conn)
                    If rx.RecordCount > 0 Then
                        conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rx.Fields("id_telefono").Value)
                    End If
                    rx.Close()
                    conn.Execute("DELETE FROM empresa_tel WHERE id_empresa=" & rs.Fields("id_empresa").Value)
                    rx.Open("SELECT id_persona FROM empresa_contacto WHERE id_empresa=" & rs.Fields("id_empresa").Value, conn)
                    If rx.RecordCount > 0 Then
                        conn.Execute("DELETE FROM persona WHERE id_persona=" & rx.Fields("id_persona").Value)
                        rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value, conn)
                        If rz.RecordCount > 0 Then
                            conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                        End If
                        rz.Close()
                        conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value)

                    End If
                    rx.Close()
                    conn.Execute("DELETE FROM empresa_contacto WHERE id_empresa=" & rs.Fields("id_empresa").Value)
                    conn.Execute("DELETE FROM empresa WHERE id_empresa=" & rs.Fields("id_empresa").Value)
                    '-------------------------
                    '---eliminamos persona-----
                    rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rs.Fields("id_persona").Value, conn)
                    If rz.RecordCount > 0 Then
                        conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                    End If
                    rz.Close()
                    conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rs.Fields("id_persona").Value)
                    conn.Execute("DELETE FROM persona WHERE id_persona=" & rs.Fields("id_persona").Value)
                    '-------------------------
                    conn.Execute("DELETE FROM proveedor WHERE id_proveedor=" & id_proveedor)
                    conn.Execute("DELETE FROM domicilio WHERE id_domicilio=" & rs.Fields("id_domicilio").Value)
                End If
                rs.Close()
                conn.Execute("DELETE FROM proveedor_cuenta WHERE id_proveedor=" & id_proveedor)
                conn.Execute("DELETE FROM proveedor_productos WHERE id_proveedor=" & id_proveedor)
                'conn.close()
                cargar()
                MsgBox("Proveedor eliminado correctamente", MsgBoxStyle.Exclamation, "Aviso")
            End If
        End If
    End Sub
    Private Function existen_turnos_abiertos() As Boolean
        Dim abierto As Boolean = False

        'Conectar()
        Dim hoy As String = Format(Today, "yyyy-MM-dd")
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND DATE(fecha)='" & hoy & "'", conn)
        If rs.RecordCount > 0 Then
            abierto = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return abierto
    End Function

    Private Sub chb_aplicar_redondeo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_aplicar_redondeo.CheckedChanged, chb_mostrar_precios.CheckedChanged
        bandera_privilegios = True
    End Sub
    Private Sub dtp_hora_entrada_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hora_entrada.ValueChanged
        bandera_horario = True
    End Sub

    Private Sub tb_minutos_tolerancia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_minutos_tolerancia.ValueChanged
        bandera_horario = True
    End Sub

    Private Sub dtp_hora_salida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_hora_salida.ValueChanged
        bandera_horario = True
    End Sub

    Private Sub cb_productos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_productos.KeyDown
        cb_productos.DroppedDown = False
        If e.KeyCode = Keys.Return Then
            Dim producto_encontrado As Boolean = False
            If Trim(cb_productos.Text) <> "" Then
                If cb_productos.SelectedIndex = -1 Then
                    rs.Open("SELECT id_producto FROM producto WHERE codigo='" & cb_productos.Text & "'", conn)
                    If rs.RecordCount > 0 Then
                        seleccionar_producto(rs.Fields("id_producto").Value)
                        producto_encontrado = True
                        tb_cantidad_producto.Focus()
                        tb_cantidad_producto.SelectAll()
                    End If
                    rs.Close()
                    If producto_encontrado = False Then
                        frm_producto_busqueda.tb_search.Text = cb_productos.Text
                        frm_producto_busqueda._modo = 4
                        frm_producto_busqueda.ShowDialog()
                        'MsgBox("No se encontraron coincidencias", MsgBoxStyle.Information, "Aviso")
                        'frm_aviso.showdialog()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub seleccionar_producto(ByVal id_producto As Integer)
        For x = 0 To cb_productos.Items.Count - 1
            If id_producto = CType(cb_productos.Items(x), myItem).Value Then
                cb_productos.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub

    Private Sub cb_productos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_productos.SelectedIndexChanged
        If cb_productos.SelectedIndex <> -1 Then
            tb_producto_precio.Items.Clear()
            tb_producto_precio.Items.Add(CType(cb_productos.SelectedItem, myItem).Opcional)
        End If
    End Sub
    Public Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone

    End Sub

    Public Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        StartCapture()
    End Sub

    Public Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        SetPrompt("Dispositivo listo.")
    End Sub

    Public Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        MsgBox("El lector de huellas digitales esta desconectado")
        MakeReport("Conectar dispositivo.")
    End Sub

    Public Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality

    End Sub
    Private Sub btn_activar_lector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_activar_lector.Click
        bandera_activado = True
        contador_muestras = 0
        accion.Text = "Dispositivo listo."
        Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.
        Capturer.EventHandler = Me                              ' Subscribe for capturing events.
        Enroller = New DPFP.Processing.Enrollment()         ' Create an enrollment.
        UpdateStatus()
        StartCapture()
    End Sub
    Public Sub seleccionar_producto_directorio(ByVal id_producto As Integer)
        For x = 0 To cb_productos.Items.Count - 1
            If id_producto = CType(cb_productos.Items(x), myItem).Value Then
                cb_productos.SelectedIndex = x
                Exit For
            End If
        Next
        tb_cantidad_producto.Focus()
        tb_cantidad_producto.SelectAll()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class