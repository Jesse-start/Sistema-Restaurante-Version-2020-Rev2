Imports System.Data
Public Class frm_cfg_usuario
    Dim id_usuario As Integer = 0
    Dim id_cuenta As Integer = 0
    Dim id_empleado As Integer = 0

    Dim i As Integer
    Dim j As Integer
    Dim tmp As Integer


    Dim tmp_str As String = ""

    Dim filtro_sql As String = ""

    Dim ds As DataSet

    Dim tabla_usuarios As DataTable
    Dim estilo_usuarios As DataGridTableStyle

    Dim tabla_cuentas As DataTable
    Dim estilo_cuentas As DataGridTableStyle

    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_fila As DataRow

    'Private conn As ADODB.Connection
    'Private rs As ADODB.Recordset
    Private Sub frm_usuario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        'habilitar_menu_ventana()
        global_frm_cfg_usuario = 0
        ' 'conn.close()
    End Sub

    Private Sub frm_usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'conn = conexion()
        'rs = conector()
        'Me.MdiParent = frm_principal
        ' habilitar_menu_ventana()
        global_frm_cfg_usuario = 1

        cargar() '---cargamos la cuentas existentes
        cargar_cuenta() '----cargamos la conf de cuenta nueva
    End Sub
    Public Sub estilo(ByRef estilo As DataGridTableStyle, ByVal nombre As String)
        estilo = New DataGridTableStyle
        estilo.MappingName = nombre

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "id_usuario"
            .Width = 0
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "usuario"
            .HeaderText = "Usuario"
            .Width = 130
            .TextBox.Enabled = False
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "nombre"
            .HeaderText = "Nombre"
            .Width = 170
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "id_perfil"
            .Width = 0
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "perfil"
            .HeaderText = "Perfil"
            .Width = 300
            .TextBox.Enabled = False
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        estilo.HeaderFont = New Font("Tahoma", 8, FontStyle.Bold)
    End Sub
    Public Sub cargar()
        tb_minutos.Text = cfg_tiempo_inactivo
        'Conectar()
        rs.Open("SELECT id_usuario, usuario, concat(p.ap_paterno,' ',p.ap_materno,' ',p.nombre) nombre FROM usuario u JOIN persona p JOIN empleado e JOIN empleado_puesto ep ON e.id_empleado=u.id_empleado AND e.id_persona = p.id_persona AND e.id_puesto=ep.id_puesto", conn)
        If rs.RecordCount > 0 Then
            tabla_usuarios = New DataTable("usuarios")
            tabla_usuarios.Columns.Add(New DataColumn("id_usuario", GetType(Integer)))
            tabla_usuarios.Columns.Add(New DataColumn("nombre", GetType(String)))
            tabla_usuarios.Columns.Add(New DataColumn("usuario", GetType(String)))
            While Not rs.EOF
                tabla_fila = tabla_usuarios.NewRow()
                tabla_fila("id_usuario") = rs.Fields("id_usuario").Value
                tabla_fila("nombre") = rs.Fields("nombre").Value
                tabla_fila("usuario") = rs.Fields("usuario").Value
                tabla_usuarios.Rows.Add(tabla_fila)
                rs.MoveNext()
            End While

            ds = New DataSet
            ds.Tables.Add(tabla_usuarios)
            dg_usuarios.TableStyles.Clear()
            estilo(estilo_usuarios, "usuarios")
            dg_usuarios.TableStyles.Add(estilo_usuarios)
            dg_usuarios.SetDataBinding(ds, "usuarios")
        Else
            dg_usuarios.DataSource = Nothing
        End If
        rs.Close()

        rs.Open("SELECT id_perfil, nombre FROM perfil ORDER by id_perfil", conn)
        If rs.RecordCount > 0 Then
            tabla_cuentas = New DataTable("cuentas")
            tabla_cuentas.Columns.Add(New DataColumn("id_perfil", GetType(Integer)))
            tabla_cuentas.Columns.Add(New DataColumn("perfil", GetType(String)))
            While Not rs.EOF
                tabla_fila = tabla_cuentas.NewRow()
                tabla_fila("id_perfil") = rs.Fields("id_perfil").Value
                tabla_fila("perfil") = rs.Fields("nombre").Value
                tabla_cuentas.Rows.Add(tabla_fila)
                rs.MoveNext()
            End While

            ds = New DataSet
            ds.Tables.Add(tabla_cuentas)
            dg_cuenta.TableStyles.Clear()
            estilo(estilo_cuentas, "cuentas")
            dg_cuenta.TableStyles.Add(estilo_cuentas)
            dg_cuenta.SetDataBinding(ds, "cuentas")
        Else
            dg_cuenta.DataSource = Nothing
        End If
        rs.Close()
        'conn.close()
        cargar_usuario()
    End Sub
    Public Sub cargar_cuenta(Optional ByVal id As Integer = 0)
        id_cuenta = id

        If id_cuenta > 0 Then
            btn_cuenta_eliminar.Enabled = True
            'gp_cuenta.Text = "Actualizar Perfil"
            btn_guardar_cuenta.Text = "Actualizar"
            btn_cancelar_cuenta.Visible = True
            btn_agregar_empleado.Enabled = False
            btn_agregar_proveedor.Enabled = False
            btn_eliminar_empleado.Enabled = False
            btn_eliminar_proveedor.Enabled = False
            TabEmpleados.Parent = TabControl1
            TabProveedores.Parent = TabControl1
            'Conectar()
            rs.Open("Select * from perfil WHERE id_perfil = " & id_cuenta, conn)
            If rs.RecordCount > 0 Then
                tb_cuenta.Text = rs.Fields("nombre").Value
                cb_usuarios.CheckState = rs.Fields("usuarios").Value
                cb_cuentas.CheckState = rs.Fields("cuentas_bancarias").Value
                cb_impuestos.CheckState = rs.Fields("impuestos").Value
                cb_productos.CheckState = rs.Fields("productos").Value
                cb_catalogo.CheckState = rs.Fields("catalogo").Value
                cb_sucursal.CheckState = rs.Fields("sucursal").Value
                cb_almacenes.CheckState = rs.Fields("almacenes").Value
                cb_directorio.CheckState = rs.Fields("directorio").Value
                cb_directorio_alta.CheckState = rs.Fields("directorio_soloalta").Value
                cb_cotizaciones.CheckState = rs.Fields("cotizaciones").Value
                cb_compra.CheckState = rs.Fields("compras").Value
                cb_pedidos.CheckState = rs.Fields("pedidos").Value
                cb_caja.CheckState = rs.Fields("caja").Value
                cb_pagos.CheckState = rs.Fields("pagos").Value
                If cb_pagos.Checked = True Then
                    TabProveedores.Parent = TabControl1
                Else
                    TabProveedores.Parent = Nothing
                End If
                cb_facturacion.CheckState = rs.Fields("facturacion").Value
                cb_compra_rapida.CheckState = rs.Fields("compras_rapidas").Value
                cb_punto_deventa.CheckState = rs.Fields("punto_venta").Value
                cb_cobros_creditos.CheckState = rs.Fields("cobros_creditos").Value
                cb_corte_caja.CheckState = rs.Fields("corte_caja").Value
                cb_corte_x.CheckState = rs.Fields("corte_x").Value
                cb_cancelar_venta.CheckState = rs.Fields("cancelar_venta").Value
                cb_cancelar_pagos.CheckState = rs.Fields("cancelar_pagos").Value
                cb_precio_especial.CheckState = rs.Fields("precio_especial").Value
                cb_regalias.CheckState = rs.Fields("regalias").Value
                cb_cambio_precio.CheckState = rs.Fields("cambio_precio").Value
                cb_cobro_terminal.CheckState = rs.Fields("cobro_terminal").Value
                cb_pago_proveedores_terminal.CheckState = rs.Fields("pago_proveedores_terminal").Value
                cb_recepcion_producto_terminal.CheckState = rs.Fields("recepcion_producto_terminal").Value
                cb_ajuste_inventario.CheckState = rs.Fields("ajuste_inventario").Value
                cb_clasif_productos.CheckState = rs.Fields("clasificacion_productos").Value
                cb_favorios.CheckState = rs.Fields("favoritos").Value
                cb_conversiones.CheckState = rs.Fields("conversiones").Value
                cb_ajuste_conversiones.CheckState = rs.Fields("ajuste_conversiones").Value
                cb_progr_pedidos.CheckState = rs.Fields("programacion_pedidos").Value
                cb_vehiculos.CheckState = rs.Fields("vehiculos").Value
                cb_agentes_entrega.CheckState = rs.Fields("repartidores").Value
                cb_catalogo_precios.CheckState = rs.Fields("catalogo_precios").Value
                cb_perfiles_impresion.CheckState = rs.Fields("perfiles_impresion").Value
                cb_cfg_conversiones.CheckState = rs.Fields("cfg_conversiones").Value
                cb_cfg_empresa.CheckState = rs.Fields("cfg_empresa").Value
                cb_traspasos_env.CheckState = rs.Fields("traspasos_env").Value
                cb_traspasos_recep.CheckState = rs.Fields("traspasos_recep").Value
                cb_descuentos.CheckState = rs.Fields("cfg_descuentos").Value
                cb_reporteador.CheckState = rs.Fields("reporteador").Value
                cb_godmode.CheckState = rs.Fields("cfg_godmode").Value
                cb_devoluciones.CheckState = rs.Fields("devoluciones").Value
                cb_correo.CheckState = rs.Fields("cfg_correo").Value
                cb_cancelar_apartado.CheckState = rs.Fields("cancelar_apartado").Value
            End If
            rs.Close()
            '--obtenemos la lista de proveedores
            lst_proveedores.Items.Clear()
            If cb_pagos.Checked = True Then
                rs.Open("SELECT perfil_proveedor.id_perfil_proveedor,proveedor.id_proveedor,CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN perfil_proveedor ON perfil_proveedor.id_proveedor=proveedor.id_proveedor WHERE perfil_proveedor.id_perfil='" & id_cuenta & "' ORDER BY nombre ", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        lst_proveedores.Items.Add(New myItem(rs.Fields("id_perfil_proveedor").Value, rs.Fields("nombre").Value))
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
            End If
            '------------------------------
            '---obtenemos empleados.
            lst_empleados.Items.Clear()
            rs.Open("SELECT PE.id_perfil_empleado,E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P,perfil_empleado PE WHERE P.id_persona=E.id_persona AND PE.id_empleado=E.id_empleado AND PE.id_perfil='" & id_cuenta & "' ORDER BY Nombre ", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    lst_empleados.Items.Add(New myItem(rs.Fields("id_perfil_empleado").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            '----------------------
            'conn.close()
            'conn = Nothing
            cargar_combo_empleados()
            cargar_combo_proveedores(id_cuenta)
        Else
            btn_cuenta_eliminar.Enabled = False
            'gp_cuenta.Text = "Agregar Cuenta"
            btn_guardar_cuenta.Text = "Agregar"
            tb_cuenta.Text = ""
            btn_cancelar_cuenta.Visible = False
            confinicio()
            lst_empleados.Items.Clear()
            lst_proveedores.Items.Clear()
            cb_proveedores.Items.Clear()
            'cargar_combo_empleados()
        End If
    End Sub
    Private Sub cargar_combo_empleados()
        cb_empleados.Items.Clear()
        cb_empleados.Text = ""
        cb_empleados.SelectedIndex = -1
        'Conectar()
        rs.Open("SELECT empleado.id_empleado, CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS nombre FROM empleado JOIN persona ON persona.id_persona=empleado.id_persona  WHERE persona.id_persona=empleado.id_persona AND empleado.id_empleado NOT IN(SELECT DISTINCT(perfil_empleado.id_empleado) FROM perfil_empleado) ORDER BY nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_empleados.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub cargar_combo_proveedores(ByVal id_perfil As Integer)
        cb_proveedores.Items.Clear()
        cb_proveedores.Text = ""
        cb_proveedores.SelectedIndex = -1
        'Conectar()
        rs.Open("SELECT proveedor.id_proveedor,CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa WHERE proveedor.id_proveedor NOT IN (SELECT DISTINCT(perfil_proveedor.id_proveedor) FROM perfil_proveedor WHERE id_perfil='" & id_perfil & "') ORDER BY nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_proveedores.Items.Add(New myItem(rs.Fields("id_proveedor").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Public Sub cargar_usuario(Optional ByVal id As Integer = 0)
        id_usuario = id

        tb_password.Text = ""
        tb_password_repetir.Text = ""
        tb_usuario.MaxLength = 15
        tb_password.MaxLength = 15
        tb_password_repetir.MaxLength = 15

        panel_usuario.Enabled = True
        cb_empleado.Enabled = True

        cb_empleado.Visible = True
        tb_empleado.Visible = False

        If id_usuario > 0 Then

            btn_guardar.Enabled = True

            btn_cancelar.Visible = True
            ck_cambiar_password.Visible = True
            ck_cambiar_password.Checked = False
            lb_password.Text = "Cambiar Password:"
            gp_usuario.Text = "Usuario Seleccionado"

            'Conectar()
            rs.Open("SELECT u.activo,u.id_empleado,u.usuario,ep.nombre nombre_puesto,ep.id_puesto FROM usuario u JOIN empleado e JOIN empleado_puesto ep ON u.id_empleado=e.id_empleado AND e.id_puesto=ep.id_puesto AND id_usuario=" & id_usuario, conn)
            btn_guardar.Text = "Actualizar"

            tb_usuario.Text = rs.Fields("usuario").Value
            id_empleado = rs.Fields("id_empleado").Value
            tb_puesto.Text = rs.Fields("nombre_puesto").Value

            ck_activa.Enabled = True
            If rs.Fields("activo").Value = 1 Then
                ck_activa.Checked = True
            Else
                ck_activa.Checked = False
            End If

            If rs.Fields("id_puesto").Value = 1 Then
                ck_activa.Enabled = False
                ck_activa.Checked = True
            End If

            rs.Close()
            'conn.close()
        Else
            btn_cancelar.Visible = False
            ck_cambiar_password.Visible = False
            ck_cambiar_password.Checked = True
            lb_password.Text = "Password:"
            gp_usuario.Text = "Agregar Usuario"

            ck_activa.Checked = True
            ck_activa.Enabled = False

            btn_guardar.Text = "Agregar"
            tb_usuario.Text = ""
            id_empleado = 0
            tb_puesto.Text = ""
        End If
        cargar_empleados()
    End Sub
    Private Sub cargar_empleados()
        filtro_sql = ""
        If id_usuario > 0 Then
            filtro_sql = "=" & id_empleado
            cb_empleado.Visible = False
            tb_empleado.Visible = True
        Else
            filtro_sql = "not in (select id_empleado from usuario)"
        End If
        'Conectar()
        rs.Open("SELECT CONCAT(p.nombre,' ',ap_paterno,' ',ap_materno) nombre, e.id_empleado, p.id_persona,ep.nombre nombre_puesto FROM persona p, empleado e, empleado_puesto ep WHERE e.id_puesto=ep.id_puesto AND p.id_persona = e.id_persona and e.id_empleado " & filtro_sql, conn)

        If rs.RecordCount = 0 Then

            panel_usuario.Enabled = False
            btn_guardar.Enabled = False
            tb_empleado.Text = "Da de alta un Empleado"

            cb_empleado.Visible = False
            tb_empleado.Visible = True
        Else

            With cb_empleado
                .Items.Clear()
                .Text = ""
                j = 0
                tmp = 0
                While Not rs.EOF
                    tb_empleado.Text = rs.Fields("nombre").Value

                    .Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, rs.Fields("nombre_puesto").Value))
                    If id_empleado > 0 Then
                        If rs.Fields("id_empleado").Value = id_empleado Then
                            tmp = j
                        End If
                    End If
                    j = j + 1

                    rs.MoveNext()
                End While
                If rs.RecordCount > 0 Then
                    If id_empleado > 0 Then
                        .SelectedIndex = tmp
                    Else
                        .SelectedIndex = 0
                    End If
                End If
            End With
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim b As Integer
        b = 0
        Dim cadena As String = ""
        Dim usuario As String = ""

        If cb_empleado.SelectedIndex < 0 Then
            b = 1
            cadena &= "  *  Selecciona a un Empleado de la lista, o antes da de alta un nuevo empleado" & vbCrLf
        End If
        If Trim(tb_usuario.Text) = "" Then
            b = 1
            cadena &= "  *  Escribe el Nombre de Usuario" & vbCrLf
        ElseIf tb_usuario.TextLength < 4 Then
            b = 1
            cadena &= "  *  El Nombre de usuario debe contener al menor 4 caracteres" & vbCrLf
        End If
        'Conectar()
        If id_usuario > 0 Then
            rs.Open("SELECT id_usuario from usuario where usuario = '" & UCase(tb_usuario.Text) & "' and id_usuario !=" & id_usuario, conn)
        Else
            rs.Open("SELECT id_usuario from usuario where usuario = '" & UCase(tb_usuario.Text) & "'", conn)
        End If
        If rs.RecordCount > 0 Then
            b = 1
            cadena &= "  *  El Usuario '" & tb_usuario.Text & "' ya existe" & vbCrLf
        End If
        rs.Close()
        'conn.close()
        If ck_cambiar_password.Checked Then
            If tb_password.Text = "" Then
                b = 1
                cadena &= "  *  Escribe el Password" & vbCrLf
            Else
                If tb_password.TextLength < 4 Then
                    b = 1
                    cadena &= "  *  El Password debe contener al menor 4 caracteres" & vbCrLf
                Else
                    If tb_password.Text <> tb_password_repetir.Text Then
                        b = 1
                        cadena &= "  *  La confirmacion del password es incorrecta"
                    End If
                End If
            End If
        End If

        If (b = 1) Then
            cadena = "Es necesario ingresar los datos en los siguientes datos" & vbCrLf & vbCrLf & cadena
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Campos Vacios")
        Else
            If id_usuario > 0 Then
                cadena = MsgBox("¿Esta seguro que desea " & btn_guardar.Text & " los datos del Usuario?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, btn_guardar.Text)
                If cadena = MsgBoxResult.Yes Then
                    If (id_usuario > 0) Then

                        filtro_sql = ""
                        If ck_activa.Checked Then
                            filtro_sql &= ",activo = 1"
                        Else
                            filtro_sql &= ",activo = 0"
                        End If

                        If ck_cambiar_password.Checked = True Then
                            filtro_sql = ",password = MD5(CONCAT(id_empleado,'" & UCase(tb_password.Text) & "'))"
                        End If
                        'Conectar()
                        conn.Execute("UPDATE usuario set usuario='" & UCase(tb_usuario.Text) & "' " & filtro_sql & " WHERE id_usuario='" & id_usuario & "'")
                        'conn.close()
                        cargar()
                        cargar_usuario()
                        MsgBox("Se Ha Actualizado el Registro", MsgBoxStyle.Information, "Confirmación de Registro")
                    End If
                End If
            Else
                'Conectar()
                conn.Execute("INSERT INTO usuario (usuario,password,id_empleado) VALUES ('" & UCase(tb_usuario.Text) & "',MD5(CONCAT(" & CType(cb_empleado.SelectedItem, myItem).Value & ",'" & UCase(tb_password.Text) & "')),'" & CType(cb_empleado.SelectedItem, myItem).Value & "')")
                'conn.close()
                cargar()
                cargar_usuario()
                MsgBox("El Registro ha sido guardado correctamente", MsgBoxStyle.Information, "Confirmación de Registro")
            End If
        End If
    End Sub
    Private Sub btn_nuevo_usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_usuario_nuevo.Click
        cargar_usuario()
    End Sub
    Private Sub dg_usuarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_usuarios.Click
        If dg_usuarios.CurrentRowIndex >= 0 Then
            If dg_usuarios.CurrentCell.ColumnNumber = 1 Then
                cargar_usuario(dg_usuarios.Item(dg_usuarios.CurrentRowIndex, 0))
            End If
        End If
    End Sub

    Private Sub ck_cambiar_password_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_cambiar_password.CheckedChanged
        If ck_cambiar_password.Checked = True Then
            tb_password.Enabled = True
            tb_password_repetir.Enabled = True
        Else
            tb_password.Enabled = False
            tb_password_repetir.Enabled = False
        End If
    End Sub

    Private Sub tb_usuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_usuario.TextChanged
        tb_usuario.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Sub tb_usuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_usuario.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "0"})
    End Sub
    Private Sub tb_usuario_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_usuario.GotFocus
        tmp_str = Clipboard.GetText
        Clipboard.Clear()
    End Sub
    Private Sub tb_usuario_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_usuario.LostFocus
        Try
            Clipboard.SetText(tmp_str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_password_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_password.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "0"})
    End Sub
    Private Sub tb_password_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_password.GotFocus
        tmp_str = Clipboard.GetText
        Clipboard.Clear()
    End Sub
    Private Sub tb_password_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_password.LostFocus
        Try
            Clipboard.SetText(tmp_str)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_password_repetir_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_password_repetir.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "0"})
    End Sub
    Private Sub tb_password_repetir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_password_repetir.GotFocus
        tmp_str = Clipboard.GetText
        Clipboard.Clear()
    End Sub
    Private Sub tb_password_repetir_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_password_repetir.LostFocus
        Try
            Clipboard.SetText(tmp_str)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cb_empleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_empleado.SelectedIndexChanged
        If cb_empleado.SelectedIndex >= 0 Then
            tb_puesto.Text = CType(cb_empleado.SelectedItem, myItem).Opcional
        End If
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        cargar_usuario()
    End Sub
    Private Sub tb_minutos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub ck_intentos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ck_intentos.CheckedChanged
        If ck_intentos.Checked Then
            conn.Execute("UPDATE configuracion set intentos_fallidos = " & 1)
            cfg_intentos_fallidos = 1
        Else
            conn.Execute("UPDATE configuracion set intentos_fallidos = " & 0)
            cfg_intentos_fallidos = 0
        End If
    End Sub

    Private Sub tb_minutos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_minutos.LostFocus
        If cfg_tiempo_inactivo <> tb_minutos.Value Then
            conn.Execute("UPDATE configuracion set tiempo_inactivo = " & tb_minutos.Value)
            cfg_tiempo_inactivo = tb_minutos.Value
        End If
    End Sub

    Private Sub dg_cuenta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_cuenta.Click
        If dg_cuenta.CurrentRowIndex >= 0 Then
            If dg_cuenta.CurrentCell.ColumnNumber = 4 Then
                cargar_cuenta(dg_cuenta.Item(dg_cuenta.CurrentRowIndex, 3))
            End If
        End If
    End Sub
    Private Sub btn_cuenta_nueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cuenta_nueva.Click
        cargar_cuenta()
    End Sub
    Private Sub btn_cancelar_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btn_cuenta_nueva_Click(sender, e)
    End Sub
    Private Sub confinicio()
        TabProveedores.Parent = Nothing
        btn_agregar_empleado.Enabled = False
        btn_agregar_proveedor.Enabled = False
        btn_eliminar_empleado.Enabled = False
        btn_eliminar_proveedor.Enabled = False
        TabProveedores.Parent = Nothing
        TabEmpleados.Parent = Nothing
        cb_empleados.Text = ""
        cb_empleados.SelectedIndex = -1
        cb_proveedores.Text = ""
        cb_proveedores.SelectedIndex = -1
        '-----------configuracion
        cbConfiguracion.Checked = False
        cb_usuarios.Checked = False
        cb_cuentas.Checked = False
        cb_impuestos.Checked = False
        cbConfiguracion.Enabled = True
        cb_usuarios.Enabled = False
        cb_cuentas.Enabled = False
        cb_impuestos.Enabled = False

        cb_vehiculos.Enabled = False
        cb_agentes_entrega.Enabled = False
        cb_catalogo_precios.Enabled = False
        cb_perfiles_impresion.Enabled = False
        cb_cfg_conversiones.Enabled = False
        cb_cfg_empresa.Enabled = False
        cb_descuentos.Enabled = False
        cb_reporteador.Enabled = False
        cb_godmode.Enabled = False
        cb_correo.Enabled = False

        cb_vehiculos.Checked = False
        cb_agentes_entrega.Checked = False
        cb_catalogo_precios.Checked = False
        cb_perfiles_impresion.Checked = False
        cb_cfg_conversiones.Checked = False
        cb_cfg_empresa.Checked = False
        cb_descuentos.Checked = False
        cb_reporteador.Checked = False
        cb_godmode.Checked = False
        cb_correo.Checked = False

        '.------------------productos
        cbProductos.Checked = False
        cb_productos.Checked = False
        cb_catalogo.Checked = False
        cb_sucursal.Checked = False
        cb_almacenes.Checked = False
        cbProductos.Enabled = True
        cb_productos.Enabled = False
        cb_catalogo.Enabled = False
        cb_sucursal.Enabled = False
        cb_almacenes.Enabled = False

        cb_clasif_productos.Enabled = False
        cb_favorios.Enabled = False
        cb_conversiones.Enabled = False
        cb_ajuste_conversiones.Enabled = False
        cb_devoluciones.Enabled = False

        cb_clasif_productos.Checked = False
        cb_favorios.Checked = False
        cb_conversiones.Checked = False
        cb_ajuste_conversiones.Checked = False
        cb_devoluciones.Checked = False

        '----------directorio
        cbDirectorio.Checked = False
        cb_directorio.Checked = False
        cb_directorio_alta.Checked = False
        cbDirectorio.Enabled = True
        cb_directorio.Enabled = False
        cb_directorio_alta.Enabled = False
        '-----servivcios
        cbServicios.Checked = False
        cb_cotizaciones.Checked = False
        cb_compra.Checked = False
        cb_pedidos.Checked = False
        cb_caja.Checked = False
        cb_pagos.Checked = False
        cb_facturacion.Checked = False
        cb_compra_rapida.Checked = False
        cb_punto_deventa.Checked = False
        cb_cobros_creditos.Checked = False
        cb_cobro_terminal.Checked = False
        cb_traspasos_env.Checked = False
        cb_traspasos_recep.Checked = False
        cbServicios.Enabled = True
        cb_cotizaciones.Enabled = False
        cb_compra.Enabled = False
        cb_pedidos.Enabled = False
        cb_caja.Enabled = False
        cb_pagos.Enabled = False
        cb_facturacion.Enabled = False
        cb_compra_rapida.Enabled = False
        cb_punto_deventa.Enabled = False
        cb_cobros_creditos.Enabled = False
        cb_cobro_terminal.Enabled = False

        cb_progr_pedidos.Enabled = False
        cb_progr_pedidos.Checked = False
        cb_traspasos_env.Enabled = False
        cb_traspasos_recep.Enabled = False
        '----autorizaciones
        cbAutorizaciones.Checked = False
        cb_corte_caja.Checked = False
        cb_corte_x.Checked = False
        cb_cancelar_venta.Checked = False
        cb_cancelar_pagos.Checked = False
        cb_precio_especial.Checked = False
        cb_regalias.Checked = False
        cb_cambio_precio.Checked = False
        cbAutorizaciones.Enabled = True
        cb_corte_caja.Enabled = False
        cb_corte_x.Enabled = False
        cb_cancelar_venta.Enabled = False
        cb_cancelar_pagos.Enabled = False
        cb_precio_especial.Enabled = False
        cb_regalias.Enabled = False
        cb_cambio_precio.Enabled = False

        cb_ajuste_inventario.Enabled = False
        cb_ajuste_inventario.Checked = False

        cb_cancelar_apartado.Enabled = False
        cb_cancelar_apartado.CheckState = False

    End Sub

    Private Sub cbConfiguracion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbConfiguracion.CheckedChanged
        If cbConfiguracion.Checked = True Then
            cb_usuarios.Enabled = True
            cb_cuentas.Enabled = True
            cb_impuestos.Enabled = True
            cb_vehiculos.Enabled = True
            cb_agentes_entrega.Enabled = True
            cb_catalogo_precios.Enabled = True
            cb_perfiles_impresion.Enabled = True
            cb_cfg_conversiones.Enabled = True
            cb_cfg_empresa.Enabled = True
            cb_descuentos.Enabled = True
            cb_reporteador.Enabled = True
            cb_godmode.Enabled = True
            cb_correo.Enabled = True
        Else
            cb_usuarios.Checked = False
            cb_cuentas.Checked = False
            cb_impuestos.Checked = False
            cb_usuarios.Enabled = False
            cb_cuentas.Enabled = False
            cb_impuestos.Enabled = False

            cb_vehiculos.Enabled = False
            cb_agentes_entrega.Enabled = False
            cb_catalogo_precios.Enabled = False
            cb_perfiles_impresion.Enabled = False
            cb_cfg_conversiones.Enabled = False
            cb_cfg_empresa.Enabled = False
            cb_descuentos.Enabled = False
            cb_reporteador.Enabled = False
            cb_godmode.Enabled = False
            cb_correo.Enabled = False

            cb_vehiculos.Checked = False
            cb_agentes_entrega.Checked = False
            cb_catalogo_precios.Checked = False
            cb_perfiles_impresion.Checked = False
            cb_cfg_conversiones.Checked = False
            cb_cfg_empresa.Checked = False
            cb_descuentos.Checked = False
            cb_reporteador.Checked = False
            cb_godmode.Checked = False
            cb_correo.Checked = False
        End If
    End Sub

    Private Sub cbProductos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbProductos.CheckedChanged
        If cbProductos.Checked = True Then
            cb_productos.Enabled = True
            cb_catalogo.Enabled = True
            cb_sucursal.Enabled = True
            cb_almacenes.Enabled = True

            cb_clasif_productos.Enabled = True
            cb_favorios.Enabled = True
            cb_conversiones.Enabled = True
            cb_ajuste_conversiones.Enabled = True
            cb_devoluciones.Enabled = True

        Else
            cb_productos.Checked = False
            cb_catalogo.Checked = False
            cb_sucursal.Checked = False
            cb_almacenes.Checked = False
            cb_productos.Enabled = False
            cb_catalogo.Enabled = False
            cb_sucursal.Enabled = False
            cb_almacenes.Enabled = False

            cb_clasif_productos.Enabled = False
            cb_favorios.Enabled = False
            cb_conversiones.Enabled = False
            cb_ajuste_conversiones.Enabled = False
            cb_devoluciones.Enabled = False

            cb_clasif_productos.Checked = False
            cb_favorios.Checked = False
            cb_conversiones.Checked = False
            cb_ajuste_conversiones.Checked = False
            cb_devoluciones.Checked = False
        End If
    End Sub

    Private Sub cbDirectorio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDirectorio.CheckedChanged
        If cbDirectorio.Checked = True Then
            cb_directorio.Enabled = True
            cb_directorio_alta.Enabled = True
        Else
            cb_directorio.Checked = False
            cb_directorio_alta.Checked = False
            cb_directorio.Enabled = False
            cb_directorio_alta.Enabled = False
        End If
    End Sub

    Private Sub cbServicios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbServicios.CheckedChanged
        If cbServicios.Checked = True Then
            cb_cotizaciones.Enabled = True
            cb_compra.Enabled = True
            cb_pedidos.Enabled = True
            cb_caja.Enabled = True
            cb_pagos.Enabled = True
            cb_facturacion.Enabled = True
            cb_compra_rapida.Enabled = True
            cb_punto_deventa.Enabled = True
            cb_cobros_creditos.Enabled = True
            cb_cobro_terminal.Enabled = True
            cb_progr_pedidos.Enabled = True
            cb_traspasos_env.Enabled = True
            cb_traspasos_recep.Enabled = True

        Else
            cb_cotizaciones.Checked = False
            cb_compra.Checked = False
            cb_pedidos.Checked = False
            cb_caja.Checked = False
            cb_pagos.Checked = False
            cb_facturacion.Checked = False
            cb_compra_rapida.Checked = False
            cb_punto_deventa.Checked = False
            cb_cobros_creditos.Checked = False
            cb_cobro_terminal.Checked = False
            cb_pago_proveedores_terminal.Checked = False
            cb_recepcion_producto_terminal.Checked = False
            cb_traspasos_env.Checked = False
            cb_traspasos_recep.Checked = False
            '----------------------------------
            cb_cotizaciones.Enabled = False
            cb_compra.Enabled = False
            cb_pedidos.Enabled = False
            cb_caja.Enabled = False
            cb_pagos.Enabled = False
            cb_facturacion.Enabled = False
            cb_compra_rapida.Enabled = False
            cb_punto_deventa.Enabled = False
            cb_cobros_creditos.Enabled = False
            cb_cobro_terminal.Enabled = False
            cb_pago_proveedores_terminal.Enabled = False
            cb_recepcion_producto_terminal.Enabled = False

            cb_progr_pedidos.Enabled = False
            cb_progr_pedidos.Checked = False
            cb_traspasos_env.Enabled = False
            cb_traspasos_recep.Enabled = False
        End If
    End Sub

    Private Sub cb_pagos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_pagos.CheckedChanged
        If cb_pagos.Checked = True Then
            TabProveedores.Parent = TabControl1
        Else
            TabProveedores.Parent = Nothing
        End If
    End Sub

    Private Sub cb_proveedores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_proveedores.SelectedIndexChanged
        If cb_proveedores.SelectedIndex = -1 Then
            btn_agregar_proveedor.Enabled = False
        Else
            btn_agregar_proveedor.Enabled = True
        End If
    End Sub

    Private Sub cb_empleados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_empleados.SelectedIndexChanged
        If cb_empleados.SelectedIndex = -1 Then
            btn_agregar_empleado.Enabled = False
        Else
            btn_agregar_empleado.Enabled = True
        End If
    End Sub

    Private Sub btn_eliminar_empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_empleado.Click
        If MsgBox("Esta seguro de eliminar  " & lst_empleados.Text & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("DELETE FROM perfil_empleado WHERE id_perfil_empleado='" & CType(lst_empleados.SelectedItem, myItem).Value & "'")
            '---obtenemos empleados.
            lst_empleados.Items.Clear()
            rs.Open("SELECT PE.id_perfil_empleado,E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P,perfil_empleado PE WHERE P.id_persona=E.id_persona AND PE.id_empleado=E.id_empleado AND PE.id_perfil='" & id_cuenta & "' ORDER BY Nombre ", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    lst_empleados.Items.Add(New myItem(rs.Fields("id_perfil_empleado").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            '----------------------
            'conn.close()
            cargar_combo_empleados()
        End If
    End Sub

    Private Sub btn_agregar_empleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_empleado.Click
        If cb_empleados.SelectedIndex <> -1 Then
            'Conectar()
            conn.Execute("INSERT INTO perfil_empleado (id_perfil,id_empleado) VALUES ('" & id_cuenta & "','" & CType(cb_empleados.SelectedItem, myItem).Value & "')")
            '---obtenemos empleados.
            lst_empleados.Items.Clear()
            rs.Open("SELECT PE.id_perfil_empleado,E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P,perfil_empleado PE WHERE P.id_persona=E.id_persona AND PE.id_empleado=E.id_empleado AND PE.id_perfil='" & id_cuenta & "' ORDER BY Nombre ", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    lst_empleados.Items.Add(New myItem(rs.Fields("id_perfil_empleado").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            '----------------------
            'conn.close()
            cargar_combo_empleados()
        End If
    End Sub

    Private Sub btn_guardar_cuenta_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cuenta.Click
        If btn_guardar_cuenta.Text = "Agregar" Then
            If Trim(tb_cuenta.Text) = "" Then
                MsgBox("Indique nobre del pefil", MsgBoxStyle.Information, "Aviso")
                tb_cuenta.Focus()
            Else
                'Conectar()
                Dim cuenta As Integer
                conn.Execute("INSERT INTO perfil (nombre,usuarios,cuentas_bancarias,impuestos,productos,catalogo,sucursal,almacenes,directorio,directorio_soloalta,cotizaciones,compras,compras_rapidas,pedidos,caja,pagos,facturacion,punto_venta,cobros_creditos,corte_caja,corte_x,cancelar_venta,cancelar_pagos,precio_especial,regalias,cambio_precio,cobro_terminal,pago_proveedores_terminal,recepcion_producto_terminal,ajuste_inventario,clasificacion_productos,favoritos,conversiones,programacion_pedidos,vehiculos,repartidores,catalogo_precios,perfiles_impresion,cfg_conversiones,cfg_empresa,traspasos_env,traspasos_recep,cfg_descuentos,reporteador,cfg_godmode,devoluciones,cfg_correo,ajuste_conversiones,cancelar_apartado) VALUES ('" & tb_cuenta.Text.ToUpper & "','" & cb_usuarios.CheckState & "','" & cb_cuentas.CheckState & "','" & cb_impuestos.CheckState & "','" & cb_productos.CheckState & "','" & cb_catalogo.CheckState & "','" & cb_sucursal.CheckState & "','" & cb_almacenes.CheckState & "','" & cb_directorio.CheckState & "','" & cb_directorio_alta.CheckState & "','" & cb_cotizaciones.CheckState & "','" & cb_compra.CheckState & "','" & cb_compra_rapida.CheckState & "','" & cb_pedidos.CheckState & "','" & cb_caja.CheckState & "','" & cb_pagos.CheckState & "','" & cb_facturacion.CheckState & "','" & cb_punto_deventa.CheckState & "','" & cb_cobros_creditos.CheckState & "','" & cb_corte_caja.CheckState & "','" & cb_corte_x.CheckState & "','" & cb_cancelar_venta.CheckState & "','" & cb_cancelar_pagos.CheckState & "','" & cb_precio_especial.CheckState & "','" & cb_regalias.CheckState & "','" & cb_cambio_precio.CheckState & "','" & cb_cobro_terminal.CheckState & "','" & cb_pago_proveedores_terminal.CheckState & "','" & cb_recepcion_producto_terminal.CheckState & "','" & cb_ajuste_inventario.CheckState & "','" & cb_clasif_productos.CheckState & "','" & cb_favorios.CheckState & "','" & cb_conversiones.CheckState & "','" & cb_progr_pedidos.CheckState & "','" & cb_vehiculos.CheckState & "','" & cb_agentes_entrega.CheckState & "','" & cb_catalogo_precios.CheckState & "','" & cb_perfiles_impresion.CheckState & "','" & cb_cfg_conversiones.CheckState & "','" & cb_cfg_empresa.CheckState & "','" & cb_traspasos_env.CheckState & "','" & cb_traspasos_recep.CheckState & "','" & cb_descuentos.CheckState & "','" & cb_reporteador.CheckState & "','" & cb_godmode.CheckState & "','" & cb_devoluciones.CheckState & "','" & cb_correo.CheckState & "','" & cb_ajuste_conversiones.CheckState & "','" & cb_cancelar_apartado.CheckState & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                cuenta = rs.Fields(0).Value
                rs.Close()
                'conn.close()
                cargar()
                cargar_cuenta(cuenta)
            End If
        ElseIf btn_guardar_cuenta.Text = "Actualizar" Then
            If MsgBox("Esta seguro de actualizar este perfil ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                conn.Execute("UPDATE perfil SET nombre='" & tb_cuenta.Text.ToUpper & "',usuarios='" & cb_usuarios.CheckState & "',cuentas_bancarias='" & cb_cuentas.CheckState & "',impuestos='" & cb_impuestos.CheckState & "',productos='" & cb_productos.CheckState & "',catalogo='" & cb_catalogo.CheckState & "',sucursal='" & cb_sucursal.CheckState & "',almacenes='" & cb_almacenes.CheckState & "',directorio='" & cb_directorio.CheckState & "',directorio_soloalta='" & cb_directorio_alta.CheckState & "',cotizaciones='" & cb_cotizaciones.CheckState & "',compras='" & cb_compra.CheckState & "',compras_rapidas='" & cb_compra_rapida.CheckState & "',pedidos='" & cb_pedidos.CheckState & "',caja='" & cb_caja.CheckState & "',pagos='" & cb_pagos.CheckState & "',facturacion='" & cb_facturacion.CheckState & "',punto_venta='" & cb_punto_deventa.CheckState & "',cobros_creditos='" & cb_cobros_creditos.CheckState & "',corte_caja='" & cb_corte_caja.CheckState & "',corte_x='" & cb_corte_x.CheckState & "',cancelar_venta='" & cb_cancelar_venta.CheckState & "',cancelar_pagos='" & cb_cancelar_pagos.CheckState & "',precio_especial='" & cb_precio_especial.CheckState & "',regalias='" & cb_regalias.CheckState & "',cambio_precio='" & cb_cambio_precio.CheckState & "',cobro_terminal='" & cb_cobro_terminal.CheckState & "',pago_proveedores_terminal='" & cb_pago_proveedores_terminal.CheckState & "',recepcion_producto_terminal='" & cb_recepcion_producto_terminal.CheckState & "',ajuste_inventario='" & cb_ajuste_inventario.CheckState & "',clasificacion_productos='" & cb_clasif_productos.CheckState & "',favoritos='" & cb_favorios.CheckState & "',conversiones='" & cb_conversiones.CheckState & "',ajuste_conversiones='" & cb_ajuste_conversiones.CheckState & "',programacion_pedidos='" & cb_progr_pedidos.CheckState & "',vehiculos='" & cb_vehiculos.CheckState & "',repartidores='" & cb_agentes_entrega.CheckState & "',catalogo_precios='" & cb_catalogo_precios.CheckState & "',perfiles_impresion='" & cb_perfiles_impresion.CheckState & "',cfg_conversiones='" & cb_cfg_conversiones.CheckState & "',cfg_empresa='" & cb_cfg_empresa.CheckState & "',traspasos_env='" & cb_traspasos_env.CheckState & "',traspasos_recep='" & cb_traspasos_recep.CheckState & "',cfg_descuentos='" & cb_descuentos.CheckState & "',reporteador='" & cb_reporteador.CheckState & "',cfg_godmode='" & cb_godmode.CheckState & "',devoluciones='" & cb_devoluciones.CheckState & "',cfg_correo='" & cb_correo.CheckState & "',cancelar_apartado='" & cb_cancelar_apartado.CheckState & "' WHERE id_perfil='" & id_cuenta & "'")
                'conn.close()
                cargar_cuenta(id_cuenta)
                MsgBox("perfil actualizado correctamente", MsgBoxStyle.Information, "Correcto")
            End If
        End If


    End Sub

    Private Sub btn_agregar_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_proveedor.Click
        If cb_proveedores.SelectedIndex <> -1 Then
            'Conectar()
            conn.Execute("INSERT INTO perfil_proveedor (id_perfil,id_proveedor) VALUES ('" & id_cuenta & "','" & CType(cb_proveedores.SelectedItem, myItem).Value & "')")
            '--obtenemos la lista de proveedores
            lst_proveedores.Items.Clear()
            If cb_pagos.Checked = True Then
                rs.Open("SELECT perfil_proveedor.id_perfil_proveedor,proveedor.id_proveedor,CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN perfil_proveedor ON perfil_proveedor.id_proveedor=proveedor.id_proveedor WHERE perfil_proveedor.id_perfil='" & id_cuenta & "' ORDER BY nombre ", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        lst_proveedores.Items.Add(New myItem(rs.Fields("id_perfil_proveedor").Value, rs.Fields("nombre").Value))
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
            End If
            '------------------------------
            'conn.close()
            cargar_combo_proveedores(id_cuenta)
        End If
    End Sub

    Private Sub lst_empleados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_empleados.Click
        If lst_empleados.Items.Count > 0 Then
            If lst_empleados.SelectedItems.Count > 0 Then
                btn_eliminar_empleado.Enabled = True
            Else
                btn_eliminar_empleado.Enabled = False
            End If
        End If
    End Sub
    Private Sub lst_proveedores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_proveedores.Click
        If lst_proveedores.Items.Count > 0 Then
            If lst_proveedores.SelectedItems.Count > 0 Then
                btn_eliminar_proveedor.Enabled = True
            Else
                btn_eliminar_proveedor.Enabled = False
            End If
        End If
    End Sub

    Private Sub btn_eliminar_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_proveedor.Click
        If MsgBox("Esta seguro de eliminar  " & lst_proveedores.Text & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("DELETE FROM perfil_proveedor WHERE id_perfil_proveedor='" & CType(lst_proveedores.SelectedItem, myItem).Value & "'")
            '--obtenemos la lista de proveedores
            lst_proveedores.Items.Clear()
            If cb_pagos.Checked = True Then
                rs.Open("SELECT perfil_proveedor.id_perfil_proveedor,proveedor.id_proveedor,CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN perfil_proveedor ON perfil_proveedor.id_proveedor=proveedor.id_proveedor WHERE perfil_proveedor.id_perfil='" & id_cuenta & "' ORDER BY nombre ", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        lst_proveedores.Items.Add(New myItem(rs.Fields("id_perfil_proveedor").Value, rs.Fields("nombre").Value))
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
            End If
            '------------------------------
            'conn.close()
            cargar_combo_proveedores(id_cuenta)
        End If
    End Sub

    Private Sub btn_cuenta_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cuenta_eliminar.Click
        If id_cuenta <> 0 Then
            If MsgBox("Esta seguro de eliminar  " & tb_cuenta.Text & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                conn.Execute("DELETE FROM perfil WHERE id_perfil='" & id_cuenta & "'")
                conn.Execute("DELETE FROM perfil_empleado WHERE id_perfil='" & id_cuenta & "'")
                conn.Execute("DELETE FROM perfil_proveedor WHERE id_perfil='" & id_cuenta & "'")
                'conn.close()
                cargar()
                cargar_cuenta()
                MsgBox("Perfil eliminado correctamente")
            End If
        End If
    End Sub

    Private Sub cbAutorizaciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAutorizaciones.CheckedChanged
        If cbAutorizaciones.Checked = True Then
            cb_corte_caja.Enabled = True
            cb_corte_x.Enabled = True
            cb_cancelar_venta.Enabled = True
            cb_cancelar_pagos.Enabled = True
            cb_precio_especial.Enabled = True
            cb_regalias.Enabled = True
            cb_cambio_precio.Enabled = True
            cb_ajuste_inventario.Enabled = True
            cb_cancelar_apartado.Enabled = True
        Else
            cb_corte_caja.Checked = False
            cb_corte_x.Enabled = False
            cb_cancelar_venta.Checked = False
            cb_cancelar_pagos.Checked = False
            cb_precio_especial.Checked = False
            cb_regalias.Checked = False
            cb_ajuste_inventario.Checked = False
            cb_corte_caja.Enabled = False
            cb_corte_x.Enabled = False
            cb_cancelar_venta.Enabled = False
            cb_cancelar_pagos.Enabled = False
            cb_precio_especial.Enabled = False
            cb_regalias.Enabled = False
            cb_cambio_precio.Enabled = False
            cb_ajuste_inventario.Enabled = False
            cb_ajuste_inventario.Checked = False
            cb_cancelar_apartado.Enabled = False
            cb_cancelar_apartado.CheckState = False

        End If
    End Sub

    Private Sub cb_cobro_terminal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cobro_terminal.CheckedChanged
        If cb_cobro_terminal.Checked = True Then
            cb_pago_proveedores_terminal.Enabled = True
            cb_recepcion_producto_terminal.Enabled = True
        Else
            cb_pago_proveedores_terminal.Enabled = False
            cb_recepcion_producto_terminal.Enabled = False
        End If
    End Sub

    Private Sub btn_agregar_todos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_todos.Click
        'Conectar()
        conn.Execute("DELETE FROM perfil_proveedor WHERE id_perfil='" & id_cuenta & "'")
        rs.Open("SELECT id_proveedor FROM proveedor", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                conn.Execute("INSERT INTO perfil_proveedor (id_perfil,id_proveedor) VALUES ('" & id_cuenta & "','" & rs.Fields("id_proveedor").Value & "')")
                rs.MoveNext()
            End While
        End If
        rs.Close()


        '--obtenemos la lista de proveedores

        lst_proveedores.Items.Clear()
        If cb_pagos.Checked = True Then
            rs.Open("SELECT perfil_proveedor.id_perfil_proveedor,proveedor.id_proveedor,CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre" & _
                            " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN perfil_proveedor ON perfil_proveedor.id_proveedor=proveedor.id_proveedor WHERE perfil_proveedor.id_perfil='" & id_cuenta & "' ORDER BY nombre ", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    lst_proveedores.Items.Add(New myItem(rs.Fields("id_perfil_proveedor").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End If
        '------------------------------
        'conn.close()
        cargar_combo_proveedores(id_cuenta)
        MsgBox("Todos los proveedores han sido agregados", MsgBoxStyle.Information, "Aviso")
    End Sub
End Class