Public Class frm_directorio_factura
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
    Private bandera_activado As Boolean
    Private id_persona As Integer
    Private id_empresa As Integer
    Private id_domicilio As Integer
    Private id_telefono As Integer
    Private id As Integer
    Private tipo_bus As Integer
    Private contador_muestras As Integer
    Dim maxima_utilidad As Double = 0
    Private Sub frm_directorio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        global_frm_directorio = 0
    End Sub
    Public Sub cargar(Optional ByVal id As Integer = 0, Optional ByVal tipo_bus As Integer = 0)
        Me.id = id
        Me.tipo_bus = tipo_bus
        bandera_activado = False
        bandera_actualizar = False
        bandera = False
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

        rb_cliente.Checked = True
        rb_fisica.Checked = True

        tb_alias_fisica.Text = ""
        '-------------------
        If id <> 0 Then
            btn_eliminar.Enabled = True
            gb_clase.Enabled = False
            bandera_actualizar = True
            rs.Open("SELECT id_persona,id_empresa FROM cliente WHERE id_cliente=" & id)
            If rs.RecordCount > 0 Then
                If rs.Fields("id_empresa").Value <> 0 Then
                    Me.tipo_bus = 2
                    tipo_bus = 2
                Else
                    Me.tipo_bus = 3
                    tipo_bus = 3
                End If

            End If
            rs.Close()
            If tipo_bus = 2 Then '--cliente moral
                rb_cliente.Checked = True
                rb_moral.Checked = True
                Panel6.Enabled = False
                rs.Open("select " & _
                    "cliente.id_empresa, " & _
                    "cliente.id_domicilio, " & _
                    "empresa.razon_social, " & _
                    "empresa.alias, " & _
                    "empresa.url, " & _
                    "empresa.rfc, " & _
                    "empresa.email, " & _
                    "domicilio.calle, " & _
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
                tb_razon.Text = rs.Fields("razon_social").Value
                tb_alias.Text = rs.Fields("alias").Value
                tb_url.Text = rs.Fields("url").Value
                tb_emailM.Text = rs.Fields("email").Value
                tb_rfcM.Text = rs.Fields("rfc").Value
                cb_clasificacion.Text = rs.Fields("tipo").Value
                tb_calle.Text = rs.Fields("calle").Value
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
                '-----------------------------
            End If
            If tipo_bus = 3 Then '--cliente fisica
                Panel6.Enabled = False
                rs.Open("select " & _
                    "cliente.id_persona, " & _
                    "cliente.id_domicilio, " & _
                    "persona.nombre, " & _
                    "persona.ap_materno, " & _
                    "persona.ap_paterno, " & _
                    "persona.email, " & _
                    "persona.rfc, " & _
                      "persona.alias, " & _
                    "domicilio.calle, " & _
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
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_apellidoP.Text = rs.Fields("ap_paterno").Value
                tb_apellidoM.Text = rs.Fields("ap_materno").Value
                tb_emailF.Text = rs.Fields("email").Value
                tb_rfcF.Text = rs.Fields("rfc").Value
                cb_clasificacion.Text = rs.Fields("tipo").Value
                tb_calle.Text = rs.Fields("calle").Value
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
                '-----------------------------
            End If

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
    End Sub

    Private Sub frm_directorio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If id <> 0 Then
            frm_facturacion.cargar()
            frm_facturacion.seleccionar_cliente(id)
        End If
    End Sub
    Private Sub frm_cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_directorio = 1
        aplicar_colores()
        cargar()
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        gb_clase.ForeColor = Color.FromArgb(conf_colores(2))
        gb_empresa.ForeColor = Color.FromArgb(conf_colores(2))
        gb_persona.ForeColor = Color.FromArgb(conf_colores(2))
        gb_tipo.ForeColor = Color.FromArgb(conf_colores(2))
        FlowLayoutPanel1.ForeColor = Color.FromArgb(conf_colores(13))
        Panel1.ForeColor = Color.FromArgb(conf_colores(13))
        Panel6.ForeColor = Color.FromArgb(conf_colores(13))
        Panel7.ForeColor = Color.FromArgb(conf_colores(13))

        btn_eliminar.BackColor = Color.FromArgb(conf_colores(8))
        btn_eliminar.ForeColor = Color.FromArgb(conf_colores(9))

        Label1.ForeColor = Color.FromArgb(conf_colores(13))

        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label22.ForeColor = Color.FromArgb(conf_colores(13))
        Label23.ForeColor = Color.FromArgb(conf_colores(13))
        Label26.ForeColor = Color.FromArgb(conf_colores(13))
        Label27.ForeColor = Color.FromArgb(conf_colores(13))
        Label28.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
        Label40.ForeColor = Color.FromArgb(conf_colores(13))
        Label41.ForeColor = Color.FromArgb(conf_colores(13))
        Label42.ForeColor = Color.FromArgb(conf_colores(13))
        Label43.ForeColor = Color.FromArgb(conf_colores(13))
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label52.ForeColor = Color.FromArgb(conf_colores(13))
        Label53.ForeColor = Color.FromArgb(conf_colores(13))
        Label6.ForeColor = Color.FromArgb(conf_colores(13))
        Label7.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        rb_cliente.ForeColor = Color.FromArgb(conf_colores(13))
        rb_fisica.ForeColor = Color.FromArgb(conf_colores(13))
        rb_moral.ForeColor = Color.FromArgb(conf_colores(13))

    End Sub
    Private Sub rb_fisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_fisica.CheckedChanged
        If rb_fisica.Checked = True Then
            gb_empresa.Visible = False
            gb_persona.Visible = True
        End If
    End Sub

    Private Sub rb_moral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_moral.CheckedChanged
        If rb_moral.Checked = True Then
            gb_empresa.Visible = True
            gb_persona.Visible = False
        End If
    End Sub
    Private Sub tb_nombre_contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"a", " "})
    End Sub
    Private Sub tb_email_contacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0", "a", ".\-_@"})
    End Sub
    Private Sub tb_nombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_nombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            'tb_nombre.Text = ucWords(tb_nombre.Text)
            tb_apellidoP.Focus()
        End If
    End Sub
    Private Sub tb_apellidoP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_apellidoP.KeyDown
        If e.KeyCode = Keys.Enter Then
            'tb_apellidoP.Text = ucWords(tb_apellidoP.Text)
            tb_apellidoM.Focus()
        End If
    End Sub
    Private Sub tb_apellidoM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_apellidoM.KeyDown
        If e.KeyCode = Keys.Enter Then
            tb_apellidoM.Text = ucWords(tb_apellidoM.Text)
            tb_emailF.Focus()
        End If
    End Sub
    Private Sub tb_emailF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_emailF.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a", ".\-_@"})
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
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        'Dim id_domicilio As Integer
        'Dim id_persona As Integer
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
        ''Conectar()
        'conn.BeginTrans()
        'Try
        If bandera_correcto = True Then
            If bandera_actualizar = False Then
                '==guardamos el domicilio========================================
                'Conectar()
                conn.Execute("INSERT INTO domicilio(calle,colonia,municipio,cp,poblacion,estado,pais) VALUES ('" & tb_calle.Text & "', '" & tb_colonia.Text & "', '" & tb_municipio.Text & "', '" & tb_cp.Text & "', '" & tb_poblacion.Text & "', '" & tb_estado.Text & "', '" & tb_pais.Text & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_domicilio = rs.Fields(0).Value
                rs.Close()
                'conn.close()
                '===============================================================

                '=====guardamos como cliente======================================================

                If rb_cliente.Checked = True Then
                    If rb_fisica.Checked = True Then
                        'Conectar()
                        conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,rfc,email,alias) VALUES ('" & tb_nombre.Text & "', '" & tb_apellidoP.Text & "', '" & tb_apellidoM.Text & "', '" & tb_rfcF.Text & "', '" & tb_emailF.Text & "','" & tb_alias_fisica.Text & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_persona = rs.Fields(0).Value
                        rs.Close()
                        id_empresa = 0
                        'conn.close()
                    Else
                        'Conectar()
                        conn.Execute("INSERT INTO empresa (razon_social,alias,id_domicilio,url,rfc,email) VALUES ('" & tb_razon.Text & "', '" & tb_alias.Text & "', " & id_domicilio & ", '" & tb_url.Text & "', '" & tb_rfcM.Text & "','" & tb_emailM.Text & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_empresa = rs.Fields(0).Value
                        rs.Close()
                        id_persona = 0
                        'conn.close()
                    End If

                    'Conectar()
                    conn.Execute("INSERT INTO cliente (id_persona,id_empresa,id_domicilio,id_telefono,id_tipo,fecha_alta,fecha_modificacion) VALUES ( '" & id_persona & "','" & id_empresa & "', '" & id_domicilio & "','" & id_telefono & "', '" & CType(cb_clasificacion.SelectedItem, myItem).Value & "',NOW(), NOW())")

                    rs.Open("SELECT last_insert_id()", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id = rs.Fields(0).Value
                    '-----guardamos privilegios crediticios del cliente
                    Dim credito As Integer = 1 ' 0 sin credito, 1 con credito
                    Dim limite As Integer = 0 ' 0 sin limite, 1 con limite
                    credito = 0
                    limite = 1
                    conn.Execute("INSERT INTO cliente_credito(id_cliente,credito,limite,limite_credito) VALUES (' " & rs.Fields(0).Value & "','" & credito & "', '" & limite & "', '0' )")
                    '------------------------------------------------
                    '-----guardamos precio del cliente
                    Dim id_catalogo_precio As Integer = 0
                    conn.Execute("INSERT INTO cliente_precio(id_cliente,id_catalogo_precio,autorizacion) VALUES (' " & rs.Fields(0).Value & "','" & id_catalogo_precio & "', '1')")
                    '------------------------------------------------
                    rs.Close()
                    'conn.close()
                    MsgBox("CLIENTE AGREGADO CORRECTAMENTE")
                    cargar(id)
                    Exit Sub
                End If


            Else
                ''actualizar

                '=============actualizamos cliente moral==============
                If tipo_bus = 2 Then
                    'Conectar()
                    conn.Execute("UPDATE empresa  SET razon_social='" & tb_razon.Text & "',alias='" & tb_alias.Text & "',id_domicilio='" & id_domicilio & "',url='" & tb_url.Text & "',rfc='" & tb_rfcM.Text & "',email='" & tb_emailM.Text & "' WHERE id_empresa=" & id_empresa)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    conn.Execute("UPDATE cliente  SET id_tipo='" & CType(cb_clasificacion.SelectedItem, myItem).Value & "',id_telefono='" & id_telefono & "',fecha_modificacion=NOW() WHERE id_cliente=" & id)
                    'conn.close()
                    MsgBox("cliente actualizado correctamente")
                    cargar(id)
                    Exit Sub
                End If
                '========================================================================
                '=============actualizamos cliente fisico==============
                If tipo_bus = 3 Then
                    'Conectar()

                    conn.Execute("UPDATE persona  SET nombre='" & tb_nombre.Text & "',ap_paterno='" & tb_apellidoP.Text & "',ap_materno='" & tb_apellidoM.Text & "',rfc='" & tb_rfcF.Text & "',email='" & tb_emailF.Text & "',alias='" & tb_alias_fisica.Text & "'  WHERE id_persona=" & id_persona)
                    conn.Execute("UPDATE domicilio SET calle='" & tb_calle.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',cp='" & tb_cp.Text & "',poblacion='" & tb_poblacion.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "' WHERE id_domicilio=" & id_domicilio)
                    conn.Execute("UPDATE cliente  SET id_tipo='" & CType(cb_clasificacion.SelectedItem, myItem).Value & "',id_telefono='" & id_telefono & "',fecha_modificacion=NOW() WHERE id_cliente=" & id)
                    'conn.close()
                    MsgBox("cliente actualizado correctamente")
                    cargar(id)
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
    Private Sub tb_emailM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_emailM.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a", ".\-_@"})
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        cargar()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cliente.CheckedChanged
        gb_tipo.Visible = True
        gb_tipo.Height = 100
        Panel7.Enabled = True
        gb_persona.Text = "Datos del cliente"
        gb_empresa.Text = "Datos del cliente"

        gb_persona.Height = 190
    End Sub
    Private Sub tb_rfcM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_rfcM.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a"})
    End Sub

    Private Sub tb_rfcF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_rfcF.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0", "a"})
    End Sub

    Private Sub tb_curp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0", "a"})
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ofd_foto.ShowDialog()
        If bandera_Insertada = False Then
            MsgBox("Tamaño de la imagen sobrepasa lo permitido")
            ofd_foto.FileName = ""
            'bandera_Insertada = True
            'Button9_Click(sender, e)
        End If
    End Sub

    Private Sub tb_cp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cp.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If existen_turnos_abiertos() = False Then
            If rb_cliente.Checked = True Then
                If id <> 1 Then
                    eliminar_cliente(id)
                Else
                    MsgBox("Esta acción no esta permitida para este cliente. Se ha cancelado la operación", MsgBoxStyle.Information, "Aviso")
                End If

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
    Private Sub tb_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_salir.Click
        Me.Close()
    End Sub


End Class