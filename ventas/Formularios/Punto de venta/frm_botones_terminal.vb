Imports System.Diagnostics
Public Class frm_botones_terminal
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        lb_nombre.ForeColor = Color.FromArgb(conf_colores(13))
        lb_puesto.ForeColor = Color.FromArgb(conf_colores(13))

        Label1.BackColor = Color.FromArgb(conf_colores(1))
        lb_nombre.BackColor = Color.FromArgb(conf_colores(1))
        lb_puesto.BackColor = Color.FromArgb(conf_colores(1))

        p_header.BackColor = Color.FromArgb(conf_colores(1))
        btn_ajuste_inventario.BackColor = Color.FromArgb(conf_colores(8))
        btn_ajuste_inventario.ForeColor = Color.FromArgb(conf_colores(9))
        btn_buscar_producto.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar_producto.ForeColor = Color.FromArgb(conf_colores(9))
        btn_caja.BackColor = Color.FromArgb(conf_colores(8))
        btn_caja.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cortex.BackColor = Color.FromArgb(conf_colores(8))
        btn_cortex.ForeColor = Color.FromArgb(conf_colores(9))
        btn_corte_caja.BackColor = Color.FromArgb(conf_colores(8))
        btn_corte_caja.ForeColor = Color.FromArgb(conf_colores(9))
        btn_conversiones.BackColor = Color.FromArgb(conf_colores(8))
        btn_conversiones.ForeColor = Color.FromArgb(conf_colores(9))
        btn_ajuste_inventario.BackColor = Color.FromArgb(conf_colores(8))
        btn_ajuste_inventario.ForeColor = Color.FromArgb(conf_colores(9))
        btn_inventario.BackColor = Color.FromArgb(conf_colores(8))
        btn_inventario.ForeColor = Color.FromArgb(conf_colores(9))
        btn_pagos.BackColor = Color.FromArgb(conf_colores(8))
        btn_pagos.ForeColor = Color.FromArgb(conf_colores(9))
        btn_devoluciones_clientes.BackColor = Color.FromArgb(conf_colores(8))
        btn_devoluciones_clientes.ForeColor = Color.FromArgb(conf_colores(9))
        btn_recepcion_productos.BackColor = Color.FromArgb(conf_colores(8))
        btn_recepcion_productos.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir_apagar.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir_apagar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_traspasos_recep.BackColor = Color.FromArgb(conf_colores(8))
        btn_traspasos_recep.ForeColor = Color.FromArgb(conf_colores(9))
        btn_traspasos_env.BackColor = Color.FromArgb(conf_colores(8))
        btn_traspasos_env.ForeColor = Color.FromArgb(conf_colores(9))
        btn_reimpresion_ticket.BackColor = Color.FromArgb(conf_colores(8))
        btn_reimpresion_ticket.ForeColor = Color.FromArgb(conf_colores(9))
        btn_retiros.BackColor = Color.FromArgb(conf_colores(8))
        btn_retiros.ForeColor = Color.FromArgb(conf_colores(9))
        lb_almacen.ForeColor = Color.FromArgb(conf_colores(22))
        tb_almacen.ForeColor = Color.FromArgb(conf_colores(22))
        gb_almacen.ForeColor = Color.FromArgb(conf_colores(2))
        btn_cambiar_almacen.BackColor = Color.FromArgb(conf_colores(8))
        btn_cambiar_almacen.ForeColor = Color.FromArgb(conf_colores(9))
        btn_facturar_ticket.BackColor = Color.FromArgb(conf_colores(8))
        btn_facturar_ticket.ForeColor = Color.FromArgb(conf_colores(9))

        btn_comedor.BackColor = Color.FromArgb(conf_colores(8))
        btn_comedor.ForeColor = Color.FromArgb(conf_colores(9))

        btn_mesas.BackColor = Color.FromArgb(conf_colores(8))
        btn_mesas.ForeColor = Color.FromArgb(conf_colores(9))


        btn_meseros.BackColor = Color.FromArgb(conf_colores(8))
        btn_meseros.ForeColor = Color.FromArgb(conf_colores(9))

        tab_caja.BackColor = Color.FromArgb(conf_colores(1))
        tab_catalogos.BackColor = Color.FromArgb(conf_colores(1))
        tab_configuraciones.BackColor = Color.FromArgb(conf_colores(1))
        tab_inventarios.BackColor = Color.FromArgb(conf_colores(1))
        tab_sistema.BackColor = Color.FromArgb(conf_colores(1))
        tab_favoritos.BackColor = Color.FromArgb(conf_colores(1))
        tab_restaurante.BackColor = Color.FromArgb(conf_colores(1))
        Panel1.BackColor = Color.White
    End Sub
    Private Sub verifica_almacen_default()
        'Conectar()
        rs.Open("SELECT ID_Almacen,Nombre FROM almacenes  WHERE default_ventas=1 LIMIT 1", conn)
        If rs.RecordCount > 0 Then
            global_current_idalmacen = rs.Fields("ID_Almacen").Value
            Me.tb_almacen.Text = rs.Fields("Nombre").Value
            If global_default_idalmacen = 0 Then
                global_default_idalmacen = rs.Fields("ID_Almacen").Value
                global_default_nombrealmacen = rs.Fields("Nombre").Value
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        If global_current_idalmacen = 0 Then
            frm_seleccionar_almacen.ShowDialog()
        End If

    End Sub
    Private Sub btn_conversiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_conversiones.Click
        frm_conversiones.ShowDialog()
        'frm_conversiones.BringToFront()
        'Me.Close()
    End Sub

    Private Sub btn_buscar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_producto.Click
        frm_producto_busqueda._modo = 0
        frm_producto_busqueda.ShowDialog()
        'Me.Close()
    End Sub

    Private Sub btn_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inventario.Click
        frm_inventario_fisico.ShowDialog()
        'Me.Close()
    End Sub
    Private Sub btn_corte_caja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_corte_caja.Click
        ' Me.Close()
        frm_validacion.validacion = 2
        frm_validacion.ShowDialog()
    End Sub
    Private Sub btn_cortex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cortex.Click
        'Me.Close()
        frm_validacion.validacion = 1
        frm_validacion.ShowDialog()
    End Sub

    Private Sub btn_caja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_caja.Click
        If turno_caja_iniciado() = True Then
            frm_caja.ShowDialog()
        Else
            MsgBox("Para usar la caja debe indicar su fondo de caja, vaya a punto de venta e indique su fondo", MsgBoxStyle.Exclamation, "Aviso")
        End If

        'Me.Close()
    End Sub
    Private Sub btn_pagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagos.Click
        If turno_caja_iniciado() = True Then
            frm_cuentas_xpagar.ShowDialog()
            frm_cuentas_xpagar.BringToFront()
        Else
            MsgBox("Para usar la caja debe indicar su fondo de caja, vaya a punto de venta e indique su fondo", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub

    Private Sub btn_recepcion_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_recepcion_productos.Click
        frm_productos_recepcion.Show()
        frm_productos_recepcion.BringToFront()
    End Sub

    Private Sub btn_ajuste_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ajuste_inventario.Click
        'Me.Close()
        frm_validacion.validacion = 5
        frm_validacion.ShowDialog()
    End Sub
    Public Sub cargar_usuario_actual(ByVal id_empleado As Integer)
        lb_nombre.Text = global_usuario_nombre
        lb_puesto.Text = global_puesto
        Dim _datos_cliente As String = Nothing
        'If global_id_puesto = 1 Then
        'm_configuracion.Visible = True
        'Else
        'm_configuracion.Visible = False
        'End If

        Dim foto As Byte()
        Conectar()
        rs.Open("SELECT thumb FROM empleado WHERE id_empleado=" & global_id_empleado, conn)
        If Not IsDBNull(rs.Fields("thumb").Value) Then
            foto = CType(rs.Fields("thumb").Value, Byte())
            ' Try
            pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(foto))
            '  Catch ex As Exception
            ' End Try
            rs.Close()
        Else
            rs.Close()
            rs.Open("SELECT thumb FROM configuracion", conn)
            If Not IsDBNull(rs.Fields("thumb").Value) Then
                foto = CType(rs.Fields("thumb").Value, Byte())
                ' Try
                pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(foto))
                '  Catch ex As Exception
                '  End Try
                rs.Close()
            End If
        End If

        rs.Open("Select razon_social,alias,rfc from configuracion", conn)
        If rs.RecordCount > 0 Then
            Me.Text = rs.Fields("alias").Value & " | " & rs.Fields("razon_social").Value & " | " & rs.Fields("rfc").Value
        End If
        rs.Close()
        '-obtenemos la configuracion del usuario actual
        cargar_botones_favoritos()

        Dim permiso_encontrado As Boolean = True
        rs.Open("SELECT perfil.* FROM perfil JOIN perfil_empleado ON perfil_empleado.id_perfil=perfil.id_perfil WHERE perfil_empleado.id_empleado=" & id_empleado, conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("usuarios").Value = 1 Then 'ID01 
                btn_usurarios.Enabled = True
                btn_perfiles_usuarios.Enabled = True
            Else
                btn_usurarios.Enabled = False
                btn_perfiles_usuarios.Enabled = False
            End If
            If rs.Fields("cuentas_bancarias").Value = 1 Then 'ID02 
                btn_cuentas_bancarias.Enabled = True
            Else
                btn_cuentas_bancarias.Enabled = False
            End If
            If rs.Fields("impuestos").Value = 1 Then 'ID03
                btn_impuestos.Enabled = True
            Else
                btn_impuestos.Enabled = False
            End If
            If rs.Fields("productos").Value = 1 Then 'ID04
                btn_productos.Enabled = True
            Else
                btn_productos.Enabled = False
            End If
            If rs.Fields("catalogo").Value = 1 Then 'ID05
                btn_categorias.Enabled = True
            Else
                btn_categorias.Enabled = False
            End If
            If rs.Fields("sucursal").Value = 1 Then 'ID06
                btn_sucursales.Enabled = True
            Else
                btn_sucursales.Enabled = False
            End If
            If rs.Fields("almacenes").Value = 1 Then 'ID07
                btn_almacenes.Enabled = True
            Else
                btn_almacenes.Enabled = False
            End If
            If rs.Fields("directorio").Value = 1 Then 'ID08
                btn_directorio.Enabled = True
            Else
                btn_directorio.Enabled = False
            End If
            If rs.Fields("cotizaciones").Value = 1 Then 'ID09
                btn_cotizacion.Enabled = True
            Else
                btn_cotizacion.Enabled = False
            End If
            If rs.Fields("compras").Value = 1 Then 'ID10
                btn_recepcion_productos.Enabled = True
            Else
                btn_recepcion_productos.Enabled = False
            End If
            If rs.Fields("pedidos").Value = 1 Then 'ID11
                btn_ver_pedidos.Enabled = True
                global_usuario_ver_pedidos = 1
            Else
                btn_ver_pedidos.Enabled = False
                global_usuario_ver_pedidos = 0
            End If
            If rs.Fields("caja").Value = 1 Then 'ID12
                btn_caja.Enabled = True
                btn_retiros.Enabled = True
                btn_cortex.Enabled = True
            Else
                btn_caja.Enabled = False
                btn_retiros.Enabled = False
                btn_cortex.Enabled = False
            End If

            If rs.Fields("pagos").Value = 1 Then 'ID13
                btn_pagos.Enabled = True
            Else
                btn_pagos.Enabled = False
            End If
            If rs.Fields("facturacion").Value = 1 Then 'ID14
                btn_facturar_ticket.Enabled = True
                btn_control_facturas.Enabled = True
            Else
                btn_facturar_ticket.Enabled = False
                btn_control_facturas.Enabled = False
            End If
            If rs.Fields("clasificacion_productos").Value = 1 Then 'ID15
                btn_clasificacion.Enabled = True
            Else
                btn_clasificacion.Enabled = False
            End If
            If rs.Fields("favoritos").Value = 1 Then 'ID16
                btn_favoritos.Enabled = True
            Else
                btn_favoritos.Enabled = False
            End If
            If rs.Fields("conversiones").Value = 1 Then 'ID17
                btn_conversiones.Enabled = True
            Else
                btn_conversiones.Enabled = False
            End If
            If rs.Fields("programacion_pedidos").Value = 1 Then 'ID18
                btn_programacion_pedidos.Enabled = True
            Else
                btn_programacion_pedidos.Enabled = False
            End If
            If rs.Fields("vehiculos").Value = 1 Then 'ID19
                btn_vehiculos.Enabled = True
            Else
                btn_vehiculos.Enabled = False
            End If
            If rs.Fields("repartidores").Value = 1 Then 'ID20
                btn_repartidores.Enabled = True
            Else
                btn_repartidores.Enabled = False
            End If
            If rs.Fields("catalogo_precios").Value = 1 Then 'ID21
                btn_catalogo_precios.Enabled = True
            Else
                btn_catalogo_precios.Enabled = False
            End If
            If rs.Fields("perfiles_impresion").Value = 1 Then 'ID22
                btn_perfil_impresion.Enabled = True
            Else
                btn_perfil_impresion.Enabled = False
            End If
            If rs.Fields("cfg_conversiones").Value = 1 Then 'ID23
                btn_cfg_conversiones.Enabled = True
            Else
                btn_cfg_conversiones.Enabled = False
            End If
            If rs.Fields("cfg_empresa").Value = 1 Then 'ID24
                btn_cfg_empresa.Enabled = True
            Else
                btn_cfg_empresa.Enabled = False
            End If
            If rs.Fields("cfg_descuentos").Value = 1 Then 'ID25
                btn_programar_descuentos.Enabled = True
            Else
                btn_programar_descuentos.Enabled = False
            End If
            If rs.Fields("reporteador").Value = 1 Then 'ID26
                btn_reporteador.Enabled = True
            Else
                btn_reporteador.Enabled = False
            End If
            If rs.Fields("ajuste_inventario").Value = 1 Then 'ID27
                btn_ajuste_inventario.Enabled = True
                btn_inventario.Enabled = True
            Else
                btn_ajuste_inventario.Enabled = False
                btn_inventario.Enabled = False
            End If
            If rs.Fields("traspasos_env").Value = 1 Then 'ID28
                btn_traspasos_env.Enabled = True
            Else
                btn_traspasos_env.Enabled = False
            End If
            If rs.Fields("traspasos_recep").Value = 1 Then 'ID29
                btn_traspasos_recep.Enabled = True
            Else
                btn_traspasos_recep.Enabled = False
            End If
            If rs.Fields("cfg_godmode").Value = 1 Then 'ID30
                btn_cfg_avanzada.Enabled = True
            Else
                btn_cfg_avanzada.Enabled = False
            End If
            If rs.Fields("cfg_correo").Value = 1 Then 'ID31
                btn_cfg_correo.Enabled = True
                btn_reenviar_correo.Enabled = True
            Else
                btn_cfg_correo.Enabled = False
                btn_reenviar_correo.Enabled = False
            End If
            If rs.Fields("punto_venta").Value = 1 Then 'ID32
                btn_punto_venta.Enabled = True
            Else
                btn_punto_venta.Enabled = False
            End If
            If rs.Fields("cobros_creditos").Value = 1 Then 'ID33
                btn_cuentasxcobrar.Enabled = True
            Else
                btn_cuentasxcobrar.Enabled = False
            End If
            If rs.Fields("corte_caja").Value = 1 Then 'ID34
                btn_corte_caja.Enabled = True
            Else
                btn_corte_caja.Enabled = False
            End If
            'If rs.Fields("corte_x").Value = 1 Then 'ID35
            'btn_cortex.Enabled = True
            'Else
            ' btn_cortex.Enabled = False
            'End If
            If rs.Fields("devoluciones").Value = 1 Then 'ID36
                btn_devoluciones_clientes.Enabled = True
            Else
                btn_devoluciones_clientes.Enabled = False
            End If
            If rs.Fields("catalogo_precios").Value = 1 Then 'ID37
                btn_catalogo_precios.Enabled = True
                btn_lista_precios.Enabled = True
            Else
                btn_catalogo_precios.Enabled = False
                btn_lista_precios.Enabled = False
            End If



            'aplicar_llave_bloqueo() '--esta funcio limita automaticamente el programa, borre esta linea para obtener todas las funcionalidades
        Else
            permiso_encontrado = False
        End If
        rs.Close()
        If permiso_encontrado = False Then
            MsgBox("No tiene asignado ningun permiso.Contacte al administrador del sistema. El programa se cerra ahora", MsgBoxStyle.Exclamation, "Aviso")
            End
        End If


    End Sub
    Public Sub cargar_botones_favoritos()
        btn_opcion1.Visible = False
        btn_opcion2.Visible = False
        btn_opcion3.Visible = False
        btn_opcion4.Visible = False
        btn_opcion5.Visible = False
        btn_opcion6.Visible = False
        btn_opcion7.Visible = False
        btn_opcion8.Visible = False
        btn_opcion9.Visible = False
        btn_opcion10.Visible = False
        btn_opcion11.Visible = False
        btn_opcion12.Visible = False
        btn_opcion13.Visible = False
        btn_opcion14.Visible = False
       
        If global_habilitar_cfdi = 1 Then
            btn_cfdi.Enabled = True
        Else
            btn_cfdi.Enabled = False
        End If

        rs.Open("SELECT * FROM empleado_opciones WHERE id_empleado='" & global_id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                If rs.Fields("posicion").Value = 1 Then
                    btn_opcion1.Text = rs.Fields("opcion").Value
                    btn_opcion1.Tag = rs.Fields("id_opcion").Value
                    btn_opcion1.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion1.Visible = True

                ElseIf rs.Fields("posicion").Value = 2 Then
                    btn_opcion2.Text = rs.Fields("opcion").Value
                    btn_opcion2.Tag = rs.Fields("id_opcion").Value
                    btn_opcion2.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion2.Visible = True
                ElseIf rs.Fields("posicion").Value = 3 Then
                    btn_opcion3.Text = rs.Fields("opcion").Value
                    btn_opcion3.Tag = rs.Fields("id_opcion").Value
                    btn_opcion3.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion3.Visible = True
                ElseIf rs.Fields("posicion").Value = 4 Then
                    btn_opcion4.Text = rs.Fields("opcion").Value
                    btn_opcion4.Tag = rs.Fields("id_opcion").Value
                    btn_opcion4.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion4.Visible = True
                ElseIf rs.Fields("posicion").Value = 5 Then
                    btn_opcion5.Text = rs.Fields("opcion").Value
                    btn_opcion5.Tag = rs.Fields("id_opcion").Value
                    btn_opcion5.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion5.Visible = True
                ElseIf rs.Fields("posicion").Value = 6 Then
                    btn_opcion6.Text = rs.Fields("opcion").Value
                    btn_opcion6.Tag = rs.Fields("id_opcion").Value
                    btn_opcion6.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion6.Visible = True
                ElseIf rs.Fields("posicion").Value = 7 Then
                    btn_opcion7.Text = rs.Fields("opcion").Value
                    btn_opcion7.Tag = rs.Fields("id_opcion").Value
                    btn_opcion7.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion7.Visible = True
                ElseIf rs.Fields("posicion").Value = 8 Then
                    btn_opcion8.Text = rs.Fields("opcion").Value
                    btn_opcion8.Tag = rs.Fields("id_opcion").Value
                    btn_opcion8.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion8.Visible = True
                ElseIf rs.Fields("posicion").Value = 9 Then
                    btn_opcion9.Text = rs.Fields("opcion").Value
                    btn_opcion9.Tag = rs.Fields("id_opcion").Value
                    btn_opcion9.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion9.Visible = True
                ElseIf rs.Fields("posicion").Value = 10 Then
                    btn_opcion10.Text = rs.Fields("opcion").Value
                    btn_opcion10.Tag = rs.Fields("id_opcion").Value
                    btn_opcion10.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion10.Visible = True
                ElseIf rs.Fields("posicion").Value = 11 Then
                    btn_opcion11.Text = rs.Fields("opcion").Value
                    btn_opcion11.Tag = rs.Fields("id_opcion").Value
                    btn_opcion11.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion11.Visible = True
                ElseIf rs.Fields("posicion").Value = 12 Then
                    btn_opcion12.Text = rs.Fields("opcion").Value
                    btn_opcion12.Tag = rs.Fields("id_opcion").Value
                    btn_opcion12.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion12.Visible = True
                ElseIf rs.Fields("posicion").Value = 13 Then
                    btn_opcion13.Text = rs.Fields("opcion").Value
                    btn_opcion13.Tag = rs.Fields("id_opcion").Value
                    btn_opcion13.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion13.Visible = True
                ElseIf rs.Fields("posicion").Value = 14 Then
                    btn_opcion14.Text = rs.Fields("opcion").Value
                    btn_opcion14.Tag = rs.Fields("id_opcion").Value
                    btn_opcion14.Image = obtener_imagen(rs.Fields("id_opcion").Value)
                    btn_opcion14.Visible = True
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Public Function obtener_imagen(ByVal id_opcion As String) As System.Drawing.Image
        Dim image As System.Drawing.Image = Nothing

        If id_opcion = 1 Then 'ID01 
            image = btn_usurarios.Image
        ElseIf id_opcion = 2 Then 'ID02 
            image = btn_cuentas_bancarias.Image
        ElseIf id_opcion = 3 Then 'ID03
            image = btn_impuestos.Image
        ElseIf id_opcion = 4 Then 'ID04
            image = btn_productos.Image
        ElseIf id_opcion = 5 Then 'ID05
            image = btn_categorias.Image
        ElseIf id_opcion = 6 Then 'ID06
            image = btn_sucursales.Image
        ElseIf id_opcion = 7 Then 'ID07
            image = btn_almacenes.Image
        ElseIf id_opcion = 8 Then 'ID08
            image = btn_directorio.Image
        ElseIf id_opcion = 9 Then 'ID09
            image = btn_cotizacion.Image
        ElseIf id_opcion = 10 Then 'ID10
            image = btn_recepcion_productos.BackgroundImage
        ElseIf id_opcion = 11 Then 'ID11
            image = btn_ver_pedidos.Image
        ElseIf id_opcion = 12 Then 'ID12
            image = btn_caja.Image
        ElseIf id_opcion = 13 Then 'ID13
            image = btn_pagos.Image
        ElseIf id_opcion = 14 Then 'ID14
            image = btn_facturar_ticket.Image
        ElseIf id_opcion = 15 Then 'ID15
            image = btn_clasificacion.Image
        ElseIf id_opcion = 16 Then 'ID16
            image = btn_favoritos.Image
        ElseIf id_opcion = 17 Then 'ID17
            image = btn_conversiones.Image
        ElseIf id_opcion = 18 Then 'ID18
            image = btn_programacion_pedidos.Image
        ElseIf id_opcion = 19 Then 'ID19
            image = btn_vehiculos.Image
        ElseIf id_opcion = 20 Then 'ID20
            image = btn_repartidores.Image
        ElseIf id_opcion = 21 Then 'ID21
            image = btn_catalogo_precios.Image
        ElseIf id_opcion = 22 Then 'ID22
            image = btn_perfil_impresion.Image
        ElseIf id_opcion = 23 Then 'ID23
            image = btn_cfg_conversiones.Image
        ElseIf id_opcion = 24 Then 'ID24
            image = btn_cfg_empresa.Image
        ElseIf id_opcion = 25 Then 'ID25
            image = btn_programar_descuentos.Image
        ElseIf id_opcion = 26 Then 'ID26
            image = btn_reporteador.Image
        ElseIf id_opcion = 27 Then 'ID27
            image = btn_inventario.Image
        ElseIf id_opcion = 28 Then 'ID28
            image = btn_traspasos_env.Image
        ElseIf id_opcion = 29 Then 'ID29
            image = btn_traspasos_recep.Image
        ElseIf id_opcion = 30 Then 'ID30
            image = btn_cfg_avanzada.Image
        ElseIf id_opcion = 31 Then 'ID31
            image = btn_cfg_correo.Image
        ElseIf id_opcion = 32 Then 'ID32
            image = btn_punto_venta.Image
        ElseIf id_opcion = 33 Then 'ID33
            image = btn_cuentasxcobrar.Image
        ElseIf id_opcion = 34 Then 'ID34
            image = btn_corte_caja.Image
        ElseIf id_opcion = 35 Then 'ID35
            image = btn_cortex.Image
        ElseIf id_opcion = 36 Then 'ID36
            image = btn_devoluciones_clientes.Image
        ElseIf id_opcion = 37 Then 'ID21A
            image = btn_lista_precios.Image
        ElseIf id_opcion = 38 Then 'ID27
            image = btn_ajuste_inventario.Image
        ElseIf id_opcion = 39 Then
            image = My.Resources._50CENTAVOS
        ElseIf id_opcion = 40 Then
            image = btn_mantenimiento.Image
        End If
        If IsNothing(image) Then
            image = ventas.My.Resources._50CENTAVOS
        End If
        Return image
    End Function

    Private Sub frm_botones_terminal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frm_usuarios.Dispose()
    End Sub
    Private Sub frm_botones_terminal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If conf_pv(13) = 1 Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.MinimizeBox = True
            Me.MaximizeBox = True
        End If
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        lbl_version.Text = "Software para punto de Venta Ver. " & global_version
        'tab_favoritos.Parent = Nothing
        Centrar(gb_opciones)
        aplicar_colores()
        btn_corte_caja.Enabled = False
        btn_cortex.Enabled = False
        btn_pagos.Enabled = False
        btn_recepcion_productos.Enabled = False
        btn_caja.Enabled = False
        btn_traspasos_env.Enabled = False
        btn_traspasos_env.Enabled = False
        btn_devoluciones_clientes.Enabled = False
        btn_conversiones.Enabled = False
        btn_ajuste_inventario.Enabled = False

        If global_cobro_terminal = 1 Then
            btn_corte_caja.Enabled = True
            btn_cortex.Enabled = True
            btn_caja.Enabled = True
        End If
        If global_pago_proveedores = 1 Then
            btn_pagos.Enabled = True
        End If
        If global_recepcion_productos = 1 Then
            btn_recepcion_productos.Enabled = True
        End If
        If global_traspasos_env = 1 Then
            btn_traspasos_env.Enabled = True
        End If
        If global_traspasos_recep = 1 Then
            btn_traspasos_recep.Enabled = True
        End If
        If global_devoluciones = 1 Then
            btn_devoluciones_clientes.Enabled = True
        End If

        If global_conversiones = 1 Then
            btn_conversiones.Enabled = True
        End If
        If global_ajuste_inventario = 1 Then
            btn_ajuste_inventario.Enabled = True
        End If
        verifica_almacen_default()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click

        'If global_cfg_id_pantalla = 0 Then
        'frm_principal.Dispose()
        'Else
        'frm_principal2.Dispose()
        'End If
        'Me.Close()
        Me.Close()
        'frm_usuarios.Dispose()
    End Sub

    Private Sub btn_salir_apagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir_apagar.Click
        If MsgBox("Esta seguro que deseea salir y apagar el equipo", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
            Process.Start("shutdown.exe", " -s -t 0 -f")
            ' Me.Close()
            frm_usuarios.Dispose()
            End
        End If

    End Sub

    Private Sub btn_devoluciones_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devoluciones_clientes.Click
        If turno_caja_iniciado() = True Then
            frm_devoluciones.Show()
        Else
            MsgBox("Para usar la caja debe indicar su fondo de caja, vaya a punto de venta e indique su fondo", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_traspasos_recep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_traspasos_recep.Click
        frm_traspasos_recepcion.Show()
        frm_traspasos_recepcion.BringToFront()
    End Sub

    Private Sub btn_traspasos_env_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_traspasos_env.Click
        frm_traspasos_envio.Show()
        frm_traspasos_envio.BringToFront()
    End Sub

    Private Sub btn_reimpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reimpresion_ticket.Click
        frm_reimpresion_ticket.Show()
    End Sub

    Private Sub btn_facturar_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturar_ticket.Click, btn_cfdi.Click
        frm_facturacion_electronica.Show()
    End Sub

    Private Sub btn_retiros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_retiros.Click
        If turno_caja_iniciado() = True Then
            frm_retiros_deposito.tipo_movimiento = 0 ' retiro
            frm_retiros_deposito.Show()
        Else
            MsgBox("Para usar la caja debe indicar su fondo de caja, vaya a punto de venta e indique su fondo", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_almacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambiar_almacen.Click
        frm_seleccionar_almacen.ShowDialog()
    End Sub

    Private Sub btn_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_productos.Click
        frm_producto2.Show()
        frm_producto2.BringToFront()
    End Sub

    Private Sub btn_cotizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cotizacion.Click
        frm_cotizacion.Show()
        frm_cotizacion.BringToFront()
    End Sub

    Private Sub btn_programacion_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_programacion_pedidos.Click
        frm_pedido_programacion.Show()
        frm_pedido_programacion.BringToFront()
    End Sub

    Private Sub btn_directorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_directorio.Click
        frm_directorio.Show()
        frm_directorio.BringToFront()
    End Sub

    Private Sub btn_categorias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_categorias.Click
        frm_categorias.Show()
        frm_categorias.BringToFront()
    End Sub

    Private Sub btn_clasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clasificacion.Click
        frm_clasificar.Show()
        frm_clasificar.BringToFront()
    End Sub

    Private Sub btn_favoritos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_favoritos.Click
        frm_categoria_favoritos.Show()
        frm_categoria_favoritos.BringToFront()
    End Sub

    Private Sub btn_impuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_impuestos.Click
        frm_impuesto.Show()
        frm_impuesto.BringToFront()
    End Sub
    Private Sub btn_unidades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_unidades.Click
        frm_colaboradores.Show()
        frm_colaboradores.BringToFront()
    End Sub

    Private Sub btn_usurarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_usurarios.Click
        frm_cfg_usuario.Show()
        frm_cfg_usuario.BringToFront()
    End Sub

    Private Sub btn_control_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_control_facturas.Click
        frm_control_de_facturas.Show()
        frm_control_de_facturas.BringToFront()
    End Sub

    Private Sub btn_lista_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lista_precios.Click
        frm_matriz_precios.Show()
        frm_matriz_precios.BringToFront()
    End Sub

    Private Sub btn_programar_descuentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_programar_descuentos.Click
        frm_cfg_descuentos.Show()
        frm_cfg_descuentos.BringToFront()
    End Sub

    Private Sub btn_cfg_empresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cfg_empresa.Click
        frm_configuracion_empresa.Show()
        frm_configuracion_empresa.BringToFront()
    End Sub

    Private Sub btn_cfg_conversiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cfg_conversiones.Click
        frm_configuracion_conversiones.Show()
        frm_configuracion_conversiones.BringToFront()
    End Sub

    Private Sub btn_perfil_impresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_perfil_impresion.Click
        frm_perfiles.Show()
        frm_perfiles.BringToFront()
    End Sub

    Private Sub btn_almacenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_almacenes.Click
        frm_almacenes2.Show()
        frm_almacenes2.BringToFront()
    End Sub

    Private Sub btn_catalogo_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_catalogo_precios.Click
        frm_catalogo_precio.Show()
        frm_catalogo_precio.BringToFront()
    End Sub

    Private Sub btn_repartidores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_repartidores.Click
        frm_agentes_pedidos.Show()
        frm_agentes_pedidos.BringToFront()
    End Sub

    Private Sub btn_sucursales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sucursales.Click
        frm_sucursal.Show()
        frm_sucursal.BringToFront()
    End Sub

    Private Sub btn_cuentas_bancarias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cuentas_bancarias.Click
        frm_cuentas_banco.Show()
        frm_cuentas_banco.BringToFront()
    End Sub

    Private Sub btn_cfg_correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cfg_correo.Click
        frm_cfg_enviar_email.Show()
        frm_cfg_enviar_email.BringToFront()
    End Sub

    Private Sub btn_reenviar_correo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reenviar_correo.Click
        frm_reenviar_email.Show()
        frm_reenviar_email.BringToFront()
    End Sub

    Private Sub btn_cfg_avanzada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_godmode.Show()
        frm_godmode.BringToFront()
    End Sub

    Private Sub btn_cfg_avanzada_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cfg_avanzada.Click
        frm_godmode.Show()
        frm_godmode.BringToFront()
    End Sub

    Private Sub btn_reimpresion_retiros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reimpresion_retiros.Click
        frm_reimpresion_retiro.Show()
        frm_reimpresion_retiro.BringToFront()
    End Sub

    Private Sub btn_cambiar_usuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambiar_usuario.Click
        'If global_cfg_id_pantalla = 0 Then
        'frm_principal.Hide()
        ' Else
        ' frm_principal2.Hide()
        ' End If
        Me.Hide()
        frm_usuarios.habilitar_captura()
        frm_usuarios.Show()
        frm_usuarios.BringToFront()
    End Sub

    Private Sub btn_perfiles_usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_perfiles_usuarios.Click
        frm_cfg_usuario.Show()
        frm_cfg_usuario.BringToFront()
    End Sub

    Private Sub btn_cuentasxcobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cuentasxcobrar.Click
        If turno_caja_iniciado() = True Then
            frm_cuentas_xcobrar.ShowDialog()
            frm_cuentas_xcobrar.BringToFront()
        Else
            MsgBox("Para usar la caja debe indicar su fondo de caja, vaya a punto de venta e indique su fondo", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_ver_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ver_pedidos.Click
        frm_pedidos_clientes.ShowDialog()
        frm_pedidos_clientes.BringToFront()
    End Sub

    Private Sub btn_reporteador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporteador.Click
        frm_reporteador2.Show()
        frm_reporteador2.BringToFront()
    End Sub

    Private Sub btn_devoluciones_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devoluciones_proveedor.Click
        frm_devoluciones_proveedor.ShowDialog()
        frm_devoluciones_proveedor.BringToFront()
    End Sub

    Private Sub btn_punto_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_punto_venta.Click
        If global_cobro_terminal = 0 Then

            frm_principal3.modo_venta = 0
            frm_principal3.cargar_usuario_actual()
            frm_principal3.Show()
            Me.Hide()

        Else
            verificar_saldo_inicial(0)
        End If

    End Sub
    Private Sub verificar_saldo_inicial(ByVal modo As Integer)
        Dim saldo_inicial As Boolean = False
        'Conectar()
        Dim hoy As String = Format(Today, "yyyy-MM-dd")
        'rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND id_empleado='" & global_id_empleado & "' AND DATE(fecha)='" & hoy & "'", conn)
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND id_empleado='" & global_id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            saldo_inicial = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        If saldo_inicial = False Then
            frm_fondo_caja.modo_venta = modo
            frm_fondo_caja.ShowDialog()
        Else
            If modo = 0 Then

                frm_principal3.modo_venta = 0
                frm_principal3.cargar_usuario_actual()
                frm_principal3.Show()
                Me.Hide()
            Else
                frm_comedor.Show()
                'Me.Hide()
            End If

        End If
    End Sub
    Private Function turno_caja_iniciado() As Boolean
        Dim iniciado As Boolean = False

        Dim hoy As String = Format(Today, "yyyy-MM-dd")
        'rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND id_empleado='" & global_id_empleado & "' AND DATE(fecha)='" & hoy & "'", conn)
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND id_empleado='" & global_id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            iniciado = True
        End If
        rs.Close()
        Return iniciado
    End Function

    Private Sub btn_agregar_favoritos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_favoritos.Click
        frm_opciones_favoritos.Show()
        frm_opciones_favoritos.BringToFront()
    End Sub

    Private Sub btn_opcion1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_opcion1.Click, btn_opcion2.Click, btn_opcion3.Click, btn_opcion4.Click, btn_opcion5.Click, btn_opcion6.Click, btn_opcion7.Click, btn_opcion8.Click, btn_opcion9.Click, btn_opcion10.Click, btn_opcion11.Click, btn_opcion12.Click, btn_opcion13.Click, btn_opcion14.Click
        ejecutar_boton_favorito((CType(sender, Button).Tag), sender, e)

    End Sub
    Private Sub ejecutar_boton_favorito(ByVal id_opcion As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        If id_opcion = 1 Then 'ID01 
            btn_usurarios_Click(sender, e)
        ElseIf id_opcion = 2 Then 'ID02 
            btn_cuentas_bancarias_Click(sender, e)
        ElseIf id_opcion = 3 Then 'ID03
            btn_impuestos_Click(sender, e)
        ElseIf id_opcion = 4 Then 'ID04
            btn_productos_Click(sender, e)
        ElseIf id_opcion = 5 Then 'ID05
            btn_categorias_Click(sender, e)
        ElseIf id_opcion = 6 Then 'ID06
            btn_sucursales_Click(sender, e)
        ElseIf id_opcion = 7 Then 'ID07
            btn_almacenes_Click(sender, e)
        ElseIf id_opcion = 8 Then 'ID08
            btn_directorio_Click(sender, e)
        ElseIf id_opcion = 9 Then 'ID09
            btn_cotizacion_Click(sender, e)
        ElseIf id_opcion = 10 Then 'ID10
            btn_recepcion_productos_Click(sender, e)
        ElseIf id_opcion = 11 Then 'ID11
            btn_ver_pedidos_Click(sender, e)
        ElseIf id_opcion = 12 Then 'ID12
            btn_caja_Click(sender, e)
        ElseIf id_opcion = 13 Then 'ID13
            btn_pagos_Click(sender, e)
        ElseIf id_opcion = 14 Then 'ID14
            btn_facturar_ticket_Click(sender, e)
        ElseIf id_opcion = 15 Then 'ID15
            btn_clasificacion_Click(sender, e)
        ElseIf id_opcion = 16 Then 'ID16
            btn_favoritos_Click(sender, e)
        ElseIf id_opcion = 17 Then 'ID17
            btn_conversiones_Click(sender, e)
        ElseIf id_opcion = 18 Then 'ID18
            btn_programacion_pedidos_Click(sender, e)
        ElseIf id_opcion = 19 Then 'ID19
            btn_vehiculos_Click(sender, e)
        ElseIf id_opcion = 20 Then 'ID20
            btn_repartidores_Click(sender, e)
        ElseIf id_opcion = 21 Then 'ID21
            btn_catalogo_precios_Click(sender, e)
        ElseIf id_opcion = 22 Then 'ID22
            btn_perfil_impresion_Click(sender, e)
        ElseIf id_opcion = 23 Then 'ID23
            btn_cfg_conversiones_Click(sender, e)
        ElseIf id_opcion = 24 Then 'ID24
            btn_cfg_empresa_Click(sender, e)
        ElseIf id_opcion = 25 Then 'ID25
            btn_programar_descuentos_Click(sender, e)
        ElseIf id_opcion = 26 Then 'ID26
            btn_reporteador_Click(sender, e)
        ElseIf id_opcion = 27 Then 'ID27
            btn_inventario_Click(sender, e)
        ElseIf id_opcion = 28 Then 'ID28
            btn_traspasos_env_Click(sender, e)
        ElseIf id_opcion = 29 Then 'ID29
            btn_traspasos_recep_Click(sender, e)
        ElseIf id_opcion = 30 Then 'ID30
            btn_cfg_avanzada_Click(sender, e)
        ElseIf id_opcion = 31 Then 'ID31
            btn_cfg_correo_Click(sender, e)
        ElseIf id_opcion = 32 Then 'ID32
            btn_punto_venta_Click(sender, e)
        ElseIf id_opcion = 33 Then 'ID33
            btn_cuentasxcobrar_Click(sender, e)
        ElseIf id_opcion = 34 Then 'ID34
            btn_corte_caja_Click(sender, e)
        ElseIf id_opcion = 35 Then 'ID35
            btn_cortex_Click(sender, e)
        ElseIf id_opcion = 36 Then 'ID36
            btn_devoluciones_clientes_Click(sender, e)
        ElseIf id_opcion = 37 Then 'ID21A
            btn_lista_precios_Click(sender, e)
        ElseIf id_opcion = 38 Then 'ID27
            btn_ajuste_inventario_Click(sender, e)
        ElseIf id_opcion = 39 Then
            frm_navegador.Show()
        ElseIf id_opcion = 40 Then
            btn_mantenimiento_Click(sender, e)
        End If
    End Sub

    Private Sub btn_vehiculos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_vehiculos.Click
        frm_vehiculos.Show()
        frm_vehiculos.BringToFront()
    End Sub

    Private Sub btn_lista_clientes_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_lista_clientes_precios.Click
        frm_precios_clientes.Show()
        frm_precios_clientes.BringToFront()
    End Sub

    Private Sub btn_apartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_apartado.Click
        frm_apartados.ShowDialog()
        frm_apartados.BringToFront()
    End Sub

    Private Sub btn_deposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deposito.Click
        If turno_caja_iniciado() = True Then
            frm_retiros_deposito.tipo_movimiento = 1 ' retiro
            frm_retiros_deposito.Show()
        Else
            MsgBox("Para usar la caja debe indicar su fondo de caja, vaya a punto de venta e indique su fondo", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_cancelaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelaciones.Click
        Frm_cancelaciones.Show()
        Frm_cancelaciones.BringToFront()
    End Sub

    Private Sub btn_cierre_ventas_x_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cierre_ventas_x.Click, Button2.Click
        frm_corte_x.ShowDialog()
    End Sub

    Private Sub btn_solicitud_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_solicitud_productos.Click
        frm_solicitud_productos.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frm_orden_compra.Show()
    End Sub

    Private Sub btn_comedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_comedor.Click

        If global_cobro_terminal = 0 Then
            frm_comedor.Show()
            frm_comedor.BringToFront()
            'Me.Hide()
        Else
            verificar_saldo_inicial(1)
        End If
    End Sub

    Private Sub btn_nota_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nota_credito.Click
        frm_compras.Show()
    End Sub

    Private Sub btn_insumos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_insumos.Click
        frm_insumos.Show()
    End Sub

    Private Sub Btn_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_imagen.Click
        Form1.Show()
    End Sub

    Private Sub btn_presentaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_presentaciones.Click
        frm_presentaciones.precarga = False
        frm_presentaciones.cargar()
        frm_presentaciones.Show()
    End Sub

    Private Sub btn_areas_impresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_areas_impresion.Click
        frm_areas_impresion.Show()
        frm_areas_impresion.BringToFront()
    End Sub

    Private Sub btn_inventario_fisico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inventario_fisico.Click
        frm_inventario_fisico.Show()
    End Sub

    Private Sub btn_meseros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_meseros.Click
        frm_meseros.Show()
    End Sub

    Private Sub btn_mantenimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mantenimiento.Click
        frm_bitacora.Show()
        frm_bitacora.BringToFront()
    End Sub

    Private Sub btn_servicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_servicio.Click
        frm_servicio.ShowDialog()
    End Sub

    Private Sub btn_colaborador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_colaborador.Click
        frm_colaboradores2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frm_recibo_pagos.Show()
    End Sub
End Class