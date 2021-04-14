Imports System.Math
Public Class frm_principal3
    Public modo_venta As Integer = 0 '0 venta rapida, 1-venta de comedor
    Public id_orden As Integer = 0

    Dim global_subtotal As Decimal
    Dim global_total_impuestos As Decimal
    Dim global_total As Decimal
    Dim global_total_descuento As Decimal = 0

    Dim global_id_venta_pedido As Integer = 0
    Dim current_catalogo_precio As Integer
    Dim id_cliente_encontrado As Integer
    Private dragging As Boolean
    Private posicionX, posicionY As Integer
    Dim position_buttons(20, 1) As Integer
    Dim modo_ajuste_posicion As Boolean
    Private _inactiveTimeRetriever As cIdleTimeStool    'Tiempo Inactivo
    Dim inactiveTime As System.TimeSpan
    Dim pagina_categoria As Integer = 1
    Dim no_campo As Integer = 1
    Private Sub frm_principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("En verdad desea salir de la Aplicación", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Cancel Then
            e.Cancel = True
        Else
            global_frm_principal3 = 0
            frm_usuarios.Dispose()
        End If
    End Sub
    Public Sub preparar_para_codigo()
        tb_codigo.Select()
        tb_codigo.SelectAll()
        tb_codigo.Focus()
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_productos.ForeColor = Color.FromArgb(conf_colores(2))
        gb_categorias.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox3.ForeColor = Color.FromArgb(conf_colores(2))

        btn_almacen.BackColor = Color.FromArgb(conf_colores(8))
        btn_almacen.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cobrar_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_cobrar_venta.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cancelar_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar_venta.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cobrar_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_cobrar_venta.ForeColor = Color.FromArgb(conf_colores(9))

        btn_enviar_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_enviar_venta.ForeColor = Color.FromArgb(conf_colores(9))


        btn_opciones.BackColor = Color.FromArgb(conf_colores(8))
        btn_opciones.ForeColor = Color.FromArgb(conf_colores(9))


        btn_pedido.BackColor = Color.FromArgb(conf_colores(8))
        btn_pedido.ForeColor = Color.FromArgb(conf_colores(9))

        btn_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_venta.ForeColor = Color.FromArgb(conf_colores(9))

        btn_apartado.BackColor = Color.FromArgb(conf_colores(8))
        btn_apartado.ForeColor = Color.FromArgb(conf_colores(9))

        categoria1.BackColor = Color.FromArgb(conf_colores(11))
        categoria1.ForeColor = Color.FromArgb(conf_colores(12))

        tb_aviso_pedidos.BackColor = Color.FromArgb(conf_colores(14))
        tb_aviso_pedidos.ForeColor = Color.FromArgb(conf_colores(15))
        lb_nombre_producto.BackColor = Color.FromArgb(conf_colores(14))
        lb_nombre_producto.ForeColor = Color.FromArgb(conf_colores(15))
        tb_tipo.ForeColor = Color.FromArgb(conf_colores(13))
        lb_fecha.ForeColor = Color.FromArgb(conf_colores(13))

        btn_borrar_producto.BackColor = Color.FromArgb(conf_colores(8))
        btn_modificar_cantidad.BackColor = Color.FromArgb(conf_colores(8))
        btn_modificar_precio.BackColor = Color.FromArgb(conf_colores(8))
        btn_aplicar_descuento.BackColor = Color.FromArgb(conf_colores(8))

        btn_borrar_producto.ForeColor = Color.FromArgb(conf_colores(9))
        btn_modificar_cantidad.ForeColor = Color.FromArgb(conf_colores(9))
        btn_modificar_precio.ForeColor = Color.FromArgb(conf_colores(9))
        btn_aplicar_descuento.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_principal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        preparar_para_codigo()
    End Sub

    Private Sub tb_codigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_codigo.Click
        no_campo = 1
    End Sub

    Private Sub frm_principal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, tb_codigo.KeyDown, dgv_ventas.KeyDown
        If e.KeyCode = 113 Then
            Me.Hide()
            frm_usuarios.Show()
        ElseIf e.KeyCode = 114 Then
            frm_producto_busqueda._modo = 0
            frm_producto_busqueda.ShowDialog()
        ElseIf e.KeyCode = 115 Then
            If global_cobro_terminal = 1 Then
                frm_retiros_deposito.ShowDialog()
            Else
                MsgBox("No tiene permiso para realizar_retiros", MsgBoxStyle.Exclamation, "Aviso")
            End If
        ElseIf e.KeyCode = 116 Then
            If dgv_ventas.Rows.Count > 0 Then
                If global_cobro_terminal = 1 Then
                    btn_cobrar_venta_Click(sender, e)
                Else
                    MsgBox("No tiene permiso para cobrar esta venta", MsgBoxStyle.Exclamation, "Aviso")
                End If
            End If
        ElseIf e.KeyCode = 117 Then
            If dgv_ventas.Rows.Count > 0 Then
                btn_enviar_venta_Click(sender, e)
            End If
        ElseIf e.KeyCode = 118 Then
            btn_pedido_Click(sender, e)
        ElseIf e.KeyCode = 119 Then
            frm_validacion.validacion = 2
            frm_validacion.ShowDialog()
        ElseIf e.KeyCode = 120 Then
            frm_facturacion.ShowDialog()
        ElseIf e.KeyCode = 121 Then
            frm_clientes.ShowDialog()
        ElseIf e.KeyCode = 122 Then
            If global_cobro_terminal = 1 Then
                frm_caja.ShowDialog()
            Else
                MsgBox("No tiene permiso para ver la caja", MsgBoxStyle.Exclamation, "Aviso")
            End If
        ElseIf e.KeyCode = 123 Then
            frm_seleccionar_almacen.ShowDialog()
        ElseIf e.KeyCode = 46 Then
            If dgv_ventas.Rows.Count > 0 Then
                If dgv_ventas.SelectedRows.Count > 0 Then
                    btn_borrar_producto_Click(sender, e)
                End If
            End If
        ElseIf e.KeyCode = 13 Then
            btn_codigo_Click(sender, e)
        ElseIf e.KeyCode = 40 Then 'abajo
            ' lst_productos.Select()
            btn_codigo_Click(sender, e)
        End If
    End Sub
    Private Sub aspecto_nuevo()
        gb_venta.Controls.Add(btn_opciones)
        btn_opciones.Location = New Point(576, 24)
        gb_venta.Controls.Add(pb_usuario)
        pb_usuario.Location = New Point(661, 24)
        gb_venta.Controls.Add(btn_cliente)
        btn_cliente.Location = New Point(747, 25)
        gb_venta.Controls.Add(tb_codigo_cliente)
        tb_codigo_cliente.Location = New Point(837, 27)


        gb_venta.Controls.Add(GroupBox3)
        GroupBox3.Location = New Point(3, 117)
        GroupBox3.Size = New Size(1010, 657)

        btn_modificar_cantidad.Location = New Point(6, 459)
        btn_borrar_producto.Location = New Point(106, 461)
        btn_enviar_venta.Location = New Point(203, 462)
        btn_cobrar_venta.Location = New Point(306, 462)
        btn_salir.Location = New Point(404, 462)

        btn_modificar_precio.Location = New Point(7, 546)
        btn_cancelar_venta.Location = New Point(106, 550)
        btn_aplicar_descuento.Location = New Point(203, 547)
        btn_procesar.Location = New Point(306, 550)


    End Sub
    Public Sub frm_principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pb_logo.Image = global_logotipo
        tmr_fecha_hora.Start()

        If conf_pv(13) = 1 Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.MinimizeBox = True
            Me.MaximizeBox = True
        End If
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        global_frm_principal3 = 1

        Centrar(gb_venta)
        
        obtener_productos_categoria(global_current_tabindex_categoria)
        cargar_categorias()
        verifica_almacen_default()
        'obtener_lineas_ticket()
        cfg_ventana_ticket()
        modo_ajuste_posicion = False

        'aplicar_llave_bloqueo() '--esta funcio limita automaticamente el programa, borre esta linea para obtener todas las funcionalidades
        preparar_para_codigo()
        position_buttons(1, 0) = producto1.Location.X
        position_buttons(1, 1) = producto1.Location.Y
        position_buttons(2, 0) = producto2.Location.X
        position_buttons(2, 1) = producto2.Location.Y
        position_buttons(3, 0) = producto3.Location.X
        position_buttons(3, 1) = producto3.Location.Y
        position_buttons(4, 0) = producto4.Location.X
        position_buttons(4, 1) = producto4.Location.Y
        position_buttons(5, 0) = producto5.Location.X
        position_buttons(5, 1) = producto5.Location.Y
        position_buttons(6, 0) = producto6.Location.X
        position_buttons(6, 1) = producto6.Location.Y
        position_buttons(7, 0) = producto7.Location.X
        position_buttons(7, 1) = producto7.Location.Y
        position_buttons(8, 0) = producto8.Location.X
        position_buttons(8, 1) = producto8.Location.Y
        position_buttons(9, 0) = producto9.Location.X
        position_buttons(9, 1) = producto9.Location.Y
        position_buttons(10, 0) = producto10.Location.X
        position_buttons(10, 1) = producto10.Location.Y
        position_buttons(11, 0) = producto11.Location.X
        position_buttons(11, 1) = producto11.Location.Y
        position_buttons(12, 0) = producto12.Location.X
        position_buttons(12, 1) = producto12.Location.Y
        position_buttons(13, 0) = producto13.Location.X
        position_buttons(13, 1) = producto13.Location.Y
        position_buttons(14, 0) = producto14.Location.X
        position_buttons(14, 1) = producto14.Location.Y
        position_buttons(15, 0) = producto15.Location.X
        position_buttons(15, 1) = producto15.Location.Y
        position_buttons(16, 0) = producto16.Location.X
        position_buttons(16, 1) = producto16.Location.Y
        position_buttons(17, 0) = producto17.Location.X
        position_buttons(17, 1) = producto17.Location.Y
        position_buttons(18, 0) = producto18.Location.X
        position_buttons(18, 1) = producto18.Location.Y
        position_buttons(19, 0) = producto19.Location.X
        position_buttons(19, 1) = producto19.Location.Y
        position_buttons(20, 0) = producto20.Location.X
        position_buttons(20, 1) = producto20.Location.Y
        lb_fecha.Text = Today.ToLongDateString


        If conf_pv(11) = 0 Then
            btn_pedido.Visible = True
        ElseIf conf_pv(11) = 1 Then
            btn_apartado.Visible = True
        ElseIf conf_pv(11) = 2 Then
            btn_pedido.Visible = True
            btn_apartado.Visible = True
        End If
    End Sub
    Private Sub ajustar_etiqueta()
        FavLb1.Location = New Point(3, 50)
        FavLb2.Location = New Point(3, 50)
        FavLb3.Location = New Point(3, 50)
        FavLb4.Location = New Point(3, 50)
        FavLb5.Location = New Point(3, 50)
        FavLb6.Location = New Point(3, 50)
        FavLb7.Location = New Point(3, 50)
        FavLb8.Location = New Point(3, 50)
        FavLb9.Location = New Point(3, 50)
        FavLb10.Location = New Point(3, 50)
        FavLb11.Location = New Point(3, 50)
        FavLb12.Location = New Point(3, 50)
        FavLb13.Location = New Point(3, 50)
        FavLb14.Location = New Point(3, 50)
        FavLb15.Location = New Point(3, 50)
        FavLb16.Location = New Point(3, 50)
        FavLb17.Location = New Point(3, 50)
        FavLb18.Location = New Point(3, 50)
        FavLb19.Location = New Point(3, 50)
        FavLb20.Location = New Point(3, 50)
    End Sub
    Private Sub cfg_ventana_ticket()

        ajustar_etiqueta()
    End Sub
    Private Sub verifica_almacen_default()
        'Conectar()
        rs.Open("SELECT ID_Almacen,Nombre FROM almacenes  WHERE default_ventas=1 LIMIT 1", conn)
        If rs.RecordCount > 0 Then
            global_current_idalmacen = rs.Fields("ID_Almacen").Value
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
    Public Sub cargar_usuario_actual()

        _inactiveTimeRetriever = New cIdleTimeStool
        global_id_venta_pedido = 0
        'If global_current_idalmacen = 0 Then
        estilo_ventas(dgv_ventas)
        aplicar_colores()
        'End If
        conf_inicio()
        pb_usuario.Image = global_thumb_usuario
        tb_usuario.Text = "LE ATENDIÓ:" & global_nombre
        If pedidos_para_hoy() Then
            tmr_aviso.Enabled = True
            tmr_aviso.Start()
        Else
            tmr_aviso.Stop()
            tmr_aviso.Enabled = False
            tb_aviso_pedidos.Visible = False
        End If
        If global_cobro_terminal = 0 Then
            btn_cobrar_venta.Visible = False
            'btn_retiros.Visible = False
        Else

            btn_cobrar_venta.Visible = True
            'btn_retiros.Visible = True
            'verificar_saldo_inicial()
        End If
        'leemos el temporal de ventas
        'Conectar()
        tabla_ventas.Clear()
        linea_ = 0
        Dim consulta As String = ""

        If modo_venta = 0 Then ' venta rapida
            consulta = "SELECT tvd.*,u.nombre_corto AS unidad FROM temp_venta_detalle tvd " & _
                "JOIN producto p ON p.id_producto=tvd.id_producto " & _
                "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                "WHERE id_empleado='" & global_id_empleado & "' ORDER BY id_temp_venta_detalle"
        Else ' modo comedor
            consulta = "SELECT orden_comedor_detalle.*, producto.thumb, producto.codigo " & _
                "FROM orden_comedor_detalle JOIN producto ON producto.id_producto=orden_comedor_detalle.id_producto WHERE orden_comedor_detalle.id_orden_comedor='" & id_orden & "' ORDER BY orden_comedor_detalle.id_orden_comedor_detalle"
        End If

        rs.Open(consulta, conn)

        If rs.RecordCount > 0 Then
            If IsDBNull(rs.Fields("id_venta").Value) Then
                global_id_venta_pedido = 0
            Else
                global_id_venta_pedido = rs.Fields("id_venta").Value
            End If
            global_current_idcliente = rs.Fields("id_cliente").Value
            global_current_descuento_global = rs.Fields("desc_global_porcent").Value
            global_current_descuento_global_importe = rs.Fields("desc_global_importe").Value

            Dim rs2 As New ADODB.Recordset
            rs2.Open("SELECT cliente.id_cliente,cliente.clave,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre,cliente_precio.id_ctlg_precios,cliente_precio.aplicar_redondeo FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN cliente_precio ON cliente_precio.id_cliente=cliente.id_cliente WHERE cliente.id_cliente=" & rs.Fields("id_cliente").Value, conn)
            If rs2.RecordCount > 0 Then
                tb_cliente.Text = rs2.Fields("clave").Value & ".- " & rs2.Fields("nombre").Value
                global_current_precio_especial = rs2.Fields("id_ctlg_precios").Value

                If rs2.Fields("aplicar_redondeo").Value = 1 Then
                    global_current_aplicar_redondeo = True
                Else
                    global_current_aplicar_redondeo = False
                End If
            End If
            rs2.Close()
            If rs.Fields("id_almacen").Value <> 0 Then
                global_tipo_operacion = 0
                btn_enviar_venta.Text = "Enviar Venta"
                btn_cancelar_venta.Text = "Borrar Todos"
                btn_cobrar_venta.Enabled = True
                tb_tipo.Text = " NUEVA VENTA"


                If conf_pv(11) = 0 Then
                    btn_pedido.Visible = True
                ElseIf conf_pv(11) = 1 Then
                    btn_apartado.Visible = True
                ElseIf conf_pv(11) = 2 Then
                    btn_pedido.Visible = True
                    btn_apartado.Visible = True
                End If


                Me.BackColor = Color.FromArgb(conf_colores(1))
            Else
                global_tipo_operacion = 1

                If conf_pv(11) = 0 Then
                    btn_pedido.Visible = True
                ElseIf conf_pv(11) = 1 Then
                    btn_apartado.Visible = True
                ElseIf conf_pv(11) = 2 Then
                    btn_pedido.Visible = True
                    btn_apartado.Visible = True
                End If

                btn_cancelar_venta.Text = "Borrar Todos"
                btn_cobrar_venta.Enabled = False
                btn_aplicar_descuento.Enabled = False

                If conf_pv(11) = 0 Then
                    tb_tipo.Text = "NUEVO PEDIDO"
                ElseIf conf_pv(11) = 1 Then
                    tb_tipo.Text = "NUEVO APARTADO"
                ElseIf conf_pv(11) = 2 Then
                    tb_tipo.Text = "PEDIDO/APARTADO"
                End If


                Me.BackColor = Color.FromArgb(conf_colores(23))
            End If
            While Not rs.EOF
                If modo_venta = 0 Then 'VENTA RAPIDA
                    agregar_producto(rs.Fields("id_producto").Value, rs.Fields("nombre").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("total_impuestos").Value, rs.Fields("precio").Value, rs.Fields("importe").Value, rs.Fields("id_almacen").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("tasa_impuestos").Value, rs.Fields("id_temp_venta_detalle").Value, rs.Fields("modificador").Value, rs.Fields("id_producto_modificador").Value)
                Else ' VENTA DE COMEDOR
                    agregar_producto(rs.Fields("id_producto").Value, rs.Fields("nombre").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("total_impuestos").Value, rs.Fields("precio").Value, rs.Fields("importe").Value, rs.Fields("id_almacen").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("tasa_impuestos").Value, rs.Fields("id_temp_venta_detalle").Value, rs.Fields("modificador").Value, rs.Fields("id_producto_modificador").Value)
                End If

                rs.MoveNext()
            End While
        Else
            'actualizar_totales()

            global_current_idcliente = 1
            tb_cliente.Text = "PÚBLICO EN GENERAL"
            global_current_precio_especial = 0
            global_current_aplicar_redondeo = obtener_aplicar_redondeo(global_current_idcliente, True)
            '----nueva venta
            global_tipo_operacion = 0
            btn_enviar_venta.Text = "Enviar Venta"
            btn_cancelar_venta.Text = "Borrar Todos"
            tb_tipo.Text = " NUEVA VENTA"
            Me.BackColor = Color.FromArgb(conf_colores(1))
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '----------------------------
        preparar_para_codigo()
        'seleccionar_ultima_fila()
    End Sub
    Private Sub verificar_saldo_inicial()
        Dim saldo_inicial As Boolean = False
        'Conectar()
        Dim hoy As String = Format(Today, "yyyy-MM-dd")
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND id_empleado='" & global_id_empleado & "' AND DATE(fecha)='" & hoy & "'", conn)
        If rs.RecordCount > 0 Then
            saldo_inicial = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        If saldo_inicial = False Then
            frm_fondo_caja.ShowDialog()
        End If
    End Sub
    Private Sub ocultar_categorias()
        'categoria1.Visible = False
        'categoria1.Text = "--"
        categoria2.Visible = False
        categoria2.Text = "--"
        categoria3.Visible = False
        categoria3.Text = "--"
        categoria4.Visible = False
        categoria4.Text = "--"
        categoria5.Visible = False
        categoria5.Text = "--"
        categoria6.Visible = False
        categoria6.Text = "--"
        categoria7.Visible = False
        categoria7.Text = "--"
        categoria8.Visible = False
        categoria8.Text = "--"
        categoria9.Visible = False
        categoria9.Text = "--"
        categoria10.Visible = False
        categoria10.Text = "--"

    End Sub
    Private Sub cargar_categorias(Optional ByVal pagina As Integer = 1)
        ocultar_categorias()
        Dim i As Integer
        Dim total_categorias As Integer = 0
        Dim registro_xpagina As Integer = 9
        'matriz categoria
        '       0     /  1    /   
        '/id_categoria/nombre/

        'Conectar()
        rs.Open("SELECT id_categoria FROM categoria WHERE id_categoria<>1", conn)
        If rs.RecordCount > 0 Then
            total_categorias = rs.RecordCount
        End If
        rs.Close()

        Dim total_paginas As Integer = Ceiling(total_categorias / registro_xpagina)
        Dim inicial As Integer = (pagina - 1) * registro_xpagina

        rs.Open("SELECT id_categoria,nombre FROM categoria WHERE id_categoria<>1 ORDER by id_categoria LIMIT " & inicial & "," & registro_xpagina & "", conn)
        If rs.RecordCount > 0 Then
            i = 0 + (9 * (pagina_categoria - 1))
            While Not rs.EOF
                '--llenamos la matriz
                categoria(i, 0) = rs.Fields("id_categoria").Value
                categoria(i, 1) = rs.Fields("nombre").Value
                '---------------
                agregar_datos_boton_categorias(i, rs.Fields("nombre").Value)
                i = i + 1
                rs.MoveNext()
            End While
        End If

        rs.Close()
        'conn.close()
        'conn = Nothing
        If pagina = total_paginas Then
            btn_cat_sig.Visible = False
        Else
            btn_cat_sig.Visible = True
        End If
    End Sub
    Private Sub obtener_productos_categoria(ByVal index_categoria As Integer)
        If index_categoria = 0 Then 'favoritos
            If favoritos_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 1 Then
            If cat1_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 2 Then
            If cat2_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 3 Then
            If cat3_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 4 Then
            If cat4_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 5 Then
            If cat5_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 6 Then
            If cat6_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 7 Then
            If cat7_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 8 Then
            If cat8_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 9 Then
            If cat9_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 10 Then
            If cat10_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 11 Then
            If cat11_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 12 Then
            If cat12_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 13 Then
            If cat13_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 14 Then
            If cat14_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 15 Then
            If cat15_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 16 Then
            If cat16_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 17 Then
            If cat17_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 18 Then
            If cat18_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 19 Then
            If cat19_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 20 Then
            If cat20_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 21 Then
            If cat21_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 22 Then
            If cat22_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 23 Then
            If cat23_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 24 Then
            If cat24_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 25 Then
            If cat25_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 26 Then
            If cat26_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 27 Then
            If cat27_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 28 Then
            If cat28_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If
        ElseIf index_categoria = 29 Then
            If cat29_llena Then
                leer_matriz(index_categoria)
            Else
                cargar_matriz(index_categoria)
            End If

        End If
    End Sub
    Private Sub ocultar_botones_productos()
        producto1.Visible = False
        producto2.Visible = False
        producto3.Visible = False
        producto4.Visible = False
        producto5.Visible = False
        producto6.Visible = False
        producto7.Visible = False
        producto8.Visible = False
        producto9.Visible = False
        producto10.Visible = False
        producto11.Visible = False
        producto12.Visible = False
        producto13.Visible = False
        producto14.Visible = False
        producto15.Visible = False
        producto16.Visible = False
        producto17.Visible = False
        producto18.Visible = False
        producto19.Visible = False
        producto20.Visible = False
        FavLb1.Visible = False
        FavLb2.Visible = False
        FavLb3.Visible = False
        FavLb4.Visible = False
        FavLb5.Visible = False
        FavLb6.Visible = False
        FavLb7.Visible = False
        FavLb8.Visible = False
        FavLb9.Visible = False
        FavLb10.Visible = False
        FavLb11.Visible = False
        FavLb12.Visible = False
        FavLb13.Visible = False
        FavLb14.Visible = False
        FavLb15.Visible = False
        FavLb16.Visible = False
        FavLb17.Visible = False
        FavLb18.Visible = False
        FavLb19.Visible = False
        FavLb20.Visible = False
    End Sub
    Private Sub leer_matriz(ByVal index_categoria As Integer)
        '0-favoritos
        '1-categoria1, 2-categoria2 ....
        ocultar_botones_productos()
        Dim _selector As Integer = 1 ' para 1 obtenemos el nonbre del producto, para 4 obtenemos el codigo
        If conf_pv(4) = 1 Then
            _selector = 4
        Else
            'lb_nombre_producto.Visible = True
        End If
        If index_categoria = 0 Then
            For i = 0 To 20
                If favoritos(i, 0) = Nothing Then
                    '   Exit For
                Else
                    agregar_datos_boton_producto(i, favoritos_thumb(i), favoritos(i, _selector))
                End If
            Next
        ElseIf index_categoria = 1 Then
            For i = 0 To 20
                If cat1(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat1_thumb(i), cat1(i, _selector))
                End If
            Next
        ElseIf index_categoria = 2 Then
            For i = 0 To 20
                If cat2(i, 0) = Nothing Then
                    '  Exit For
                Else
                    agregar_datos_boton_producto(i, cat2_thumb(i), cat2(i, _selector))
                End If
            Next
        ElseIf index_categoria = 3 Then
            For i = 0 To 20
                If cat3(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat3_thumb(i), cat3(i, _selector))
                End If
            Next
        ElseIf index_categoria = 4 Then
            For i = 0 To 20
                If cat4(i, 0) = Nothing Then
                    'Exit For
                Else
                    agregar_datos_boton_producto(i, cat4_thumb(i), cat4(i, _selector))
                End If
            Next
        ElseIf index_categoria = 5 Then
            For i = 0 To 20
                If cat5(i, 0) = Nothing Then
                    '   Exit For
                Else
                    agregar_datos_boton_producto(i, cat5_thumb(i), cat5(i, _selector))
                End If
            Next
        ElseIf index_categoria = 6 Then
            For i = 0 To 20
                If cat6(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat6_thumb(i), cat6(i, _selector))
                End If
            Next
        ElseIf index_categoria = 7 Then
            For i = 0 To 20
                If cat7(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat7_thumb(i), cat7(i, _selector))
                End If
            Next
        ElseIf index_categoria = 8 Then
            For i = 0 To 20
                If cat8(i, 0) = Nothing Then
                    'Exit For
                Else
                    agregar_datos_boton_producto(i, cat8_thumb(i), cat8(i, _selector))
                End If
            Next
        ElseIf index_categoria = 9 Then
            For i = 0 To 20
                If cat9(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat9_thumb(i), cat9(i, _selector))
                End If
            Next
        ElseIf index_categoria = 10 Then
            For i = 0 To 20
                If cat10(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat10_thumb(i), cat10(i, _selector))
                End If
            Next
        ElseIf index_categoria = 11 Then
            For i = 0 To 20
                If cat11(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat11_thumb(i), cat11(i, _selector))
                End If
            Next
        ElseIf index_categoria = 12 Then
            For i = 0 To 20
                If cat12(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat12_thumb(i), cat12(i, _selector))
                End If
            Next
        ElseIf index_categoria = 13 Then
            For i = 0 To 20
                If cat13(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat13_thumb(i), cat13(i, _selector))
                End If
            Next
        ElseIf index_categoria = 14 Then
            For i = 0 To 20
                If cat14(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat14_thumb(i), cat14(i, _selector))
                End If
            Next
        ElseIf index_categoria = 15 Then
            For i = 0 To 20
                If cat15(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat15_thumb(i), cat15(i, _selector))
                End If
            Next
        ElseIf index_categoria = 16 Then
            For i = 0 To 20
                If cat16(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat16_thumb(i), cat16(i, _selector))
                End If
            Next
        ElseIf index_categoria = 17 Then
            For i = 0 To 20
                If cat17(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat17_thumb(i), cat17(i, _selector))
                End If
            Next
        ElseIf index_categoria = 18 Then
            For i = 0 To 20
                If cat18(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat18_thumb(i), cat18(i, _selector))
                End If
            Next
        ElseIf index_categoria = 19 Then
            For i = 0 To 20
                If cat19(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat19_thumb(i), cat19(i, _selector))
                End If
            Next
        ElseIf index_categoria = 20 Then
            For i = 0 To 20
                If cat20(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat20_thumb(i), cat20(i, _selector))
                End If
            Next
        ElseIf index_categoria = 21 Then
            For i = 0 To 20
                If cat21(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat21_thumb(i), cat21(i, _selector))
                End If
            Next
        ElseIf index_categoria = 22 Then
            For i = 0 To 20
                If cat22(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat22_thumb(i), cat22(i, _selector))
                End If
            Next
        ElseIf index_categoria = 23 Then
            For i = 0 To 20
                If cat23(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat23_thumb(i), cat23(i, _selector))
                End If
            Next
        ElseIf index_categoria = 24 Then
            For i = 0 To 20
                If cat24(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat24_thumb(i), cat24(i, _selector))
                End If
            Next
        ElseIf index_categoria = 25 Then
            For i = 0 To 20
                If cat25(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat25_thumb(i), cat25(i, _selector))
                End If
            Next
        ElseIf index_categoria = 26 Then
            For i = 0 To 20
                If cat26(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat26_thumb(i), cat26(i, _selector))
                End If
            Next
        ElseIf index_categoria = 27 Then
            For i = 0 To 20
                If cat27(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat27_thumb(i), cat27(i, _selector))
                End If
            Next
        ElseIf index_categoria = 28 Then
            For i = 0 To 20
                If cat28(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat28_thumb(i), cat28(i, _selector))
                End If
            Next
        ElseIf index_categoria = 29 Then
            For i = 0 To 20
                If cat29(i, 0) = Nothing Then
                    ' Exit For
                Else
                    agregar_datos_boton_producto(i, cat29_thumb(i), cat29(i, _selector))
                End If
            Next
        End If


    End Sub
    Private Sub cargar_matriz(ByVal index_categoria As Integer)
        Dim filtro As String = ""
        If index_categoria <> 0 Then
            filtro = "WHERE producto.id_categoria=" & categoria(index_categoria - 1, 0) & " AND producto.favorito_cat<>0 ORDER by producto.favorito_cat"
        Else
            filtro = " WHERE producto.favorito<>0 ORDER by producto.favorito"
        End If
        ' matriz productos
        '  /     0     /  1   /    2      /  3   /   4  /     5      /   6      /  7     /
        ' /id_producto/nombre/descripcion/unidad/codigo/id_categoria/venta_peso/favorito/

        'Dim i As Integer
        'Conectar()
        Dim filtro_favorito As String = ""
        If index_categoria = 0 Then
            filtro_favorito = "producto.favorito"
        Else
            filtro_favorito = "producto.favorito_cat as favorito"
        End If
        rs.Open("SELECT id_producto," & filtro_favorito & ",producto.nombre,descripcion,unidad.nombre as unidad,producto.codigo,id_categoria,venta_peso,imagen FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad " & filtro, conn)
        If rs.RecordCount > 0 Then
            'i = 0
            While Not rs.EOF
                '--llenamos la matriz
                Dim bThumb As Byte()
                Dim thumb As System.Drawing.Image
                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bThumb = CType(rs.Fields("imagen").Value, Byte())
                    thumb = New Bitmap(Bytes_Imagen(bThumb))
                Else
                    thumb = ventas.My.Resources.no_image
                End If
                Dim favoritos As Integer = rs.Fields("favorito").Value
                favoritos = favoritos - 1
                llenar_matriz(favoritos, index_categoria, rs.Fields("id_producto").Value, rs.Fields("nombre").Value, rs.Fields("descripcion").Value, rs.Fields("unidad").Value, rs.Fields("codigo").Value, rs.Fields("id_categoria").Value, rs.Fields("venta_peso").Value, rs.Fields("favorito").Value, thumb)
                'i = i + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        leer_matriz(index_categoria)
        'obtenemos de la matriz
        '0-favoritos
        '1-categoria1, 2-categoria2 ....

    End Sub
    Private Sub llenar_matriz(ByVal i As Integer, ByVal index_categoria As Integer, ByVal id_producto As Integer, ByVal nombre As String, ByVal descripcion As String, ByVal unidad As String, ByVal codigo As String, ByVal id_categoria As Integer, ByVal venta_peso As Integer, ByVal favorito As Integer, ByVal imagen As Object)
        ' matriz productos
        '  /     0     /  1   /    2      /  3   /   4  /     5      /   6      /  7     /
        ' /id_producto/nombre/descripcion/unidad/codigo/id_categoria/venta_peso/favorito/

        If index_categoria = 0 Then
            If i = 0 Then
                favoritos_llena = True
            End If
            favoritos(i, 0) = id_producto
            favoritos(i, 1) = nombre
            favoritos(i, 2) = descripcion
            favoritos(i, 3) = unidad
            favoritos(i, 4) = codigo
            favoritos(i, 5) = id_categoria
            favoritos(i, 6) = venta_peso
            favoritos(i, 7) = favorito
            favoritos_thumb(i) = imagen
        ElseIf index_categoria = 1 Then
            If i = 0 Then
                cat1_llena = True
            End If
            cat1(i, 0) = id_producto
            cat1(i, 1) = nombre
            cat1(i, 2) = descripcion
            cat1(i, 3) = unidad
            cat1(i, 4) = codigo
            cat1(i, 5) = id_categoria
            cat1(i, 6) = venta_peso
            cat1(i, 7) = favorito
            cat1_thumb(i) = imagen
        ElseIf index_categoria = 2 Then
            If i = 0 Then
                cat2_llena = True
            End If
            cat2(i, 0) = id_producto
            cat2(i, 1) = nombre
            cat2(i, 2) = descripcion
            cat2(i, 3) = unidad
            cat2(i, 4) = codigo
            cat2(i, 5) = id_categoria
            cat2(i, 6) = venta_peso
            cat2(i, 7) = favorito
            cat2_thumb(i) = imagen
        ElseIf index_categoria = 3 Then
            If i = 0 Then
                cat3_llena = True
            End If
            cat3(i, 0) = id_producto
            cat3(i, 1) = nombre
            cat3(i, 2) = descripcion
            cat3(i, 3) = unidad
            cat3(i, 4) = codigo
            cat3(i, 5) = id_categoria
            cat3(i, 6) = venta_peso
            cat3(i, 7) = favorito
            cat3_thumb(i) = imagen
        ElseIf index_categoria = 4 Then
            If i = 0 Then
                cat4_llena = True
            End If
            cat4(i, 0) = id_producto
            cat4(i, 1) = nombre
            cat4(i, 2) = descripcion
            cat4(i, 3) = unidad
            cat4(i, 4) = codigo
            cat4(i, 5) = id_categoria
            cat4(i, 6) = venta_peso
            cat4(i, 7) = favorito
            cat4_thumb(i) = imagen
        ElseIf index_categoria = 5 Then
            If i = 0 Then
                cat5_llena = True
            End If
            cat5(i, 0) = id_producto
            cat5(i, 1) = nombre
            cat5(i, 2) = descripcion
            cat5(i, 3) = unidad
            cat5(i, 4) = codigo
            cat5(i, 5) = id_categoria
            cat5(i, 6) = venta_peso
            cat5(i, 7) = favorito
            cat5_thumb(i) = imagen
        ElseIf index_categoria = 6 Then
            If i = 0 Then
                cat6_llena = True
            End If
            cat6(i, 0) = id_producto
            cat6(i, 1) = nombre
            cat6(i, 2) = descripcion
            cat6(i, 3) = unidad
            cat6(i, 4) = codigo
            cat6(i, 5) = id_categoria
            cat6(i, 6) = venta_peso
            cat6(i, 7) = favorito
            cat6_thumb(i) = imagen
        ElseIf index_categoria = 7 Then
            If i = 0 Then
                cat7_llena = True
            End If
            cat7(i, 0) = id_producto
            cat7(i, 1) = nombre
            cat7(i, 2) = descripcion
            cat7(i, 3) = unidad
            cat7(i, 4) = codigo
            cat7(i, 5) = id_categoria
            cat7(i, 6) = venta_peso
            cat7(i, 7) = favorito
            cat7_thumb(i) = imagen
        ElseIf index_categoria = 8 Then
            If i = 0 Then
                cat8_llena = True
            End If
            cat8(i, 0) = id_producto
            cat8(i, 1) = nombre
            cat8(i, 2) = descripcion
            cat8(i, 3) = unidad
            cat8(i, 4) = codigo
            cat8(i, 5) = id_categoria
            cat8(i, 6) = venta_peso
            cat8(i, 7) = favorito
            cat8_thumb(i) = imagen
        ElseIf index_categoria = 9 Then
            If i = 0 Then
                cat9_llena = True
            End If
            cat9(i, 0) = id_producto
            cat9(i, 1) = nombre
            cat9(i, 2) = descripcion
            cat9(i, 3) = unidad
            cat9(i, 4) = codigo
            cat9(i, 5) = id_categoria
            cat9(i, 6) = venta_peso
            cat9(i, 7) = favorito
            cat9_thumb(i) = imagen
        ElseIf index_categoria = 10 Then
            If i = 0 Then
                cat10_llena = True
            End If
            cat10(i, 0) = id_producto
            cat10(i, 1) = nombre
            cat10(i, 2) = descripcion
            cat10(i, 3) = unidad
            cat10(i, 4) = codigo
            cat10(i, 5) = id_categoria
            cat10(i, 6) = venta_peso
            cat10(i, 7) = favorito
            cat10_thumb(i) = imagen
        ElseIf index_categoria = 11 Then
            If i = 0 Then
                cat11_llena = True
            End If
            cat11(i, 0) = id_producto
            cat11(i, 1) = nombre
            cat11(i, 2) = descripcion
            cat11(i, 3) = unidad
            cat11(i, 4) = codigo
            cat11(i, 5) = id_categoria
            cat11(i, 6) = venta_peso
            cat11(i, 7) = favorito
            cat11_thumb(i) = imagen
        ElseIf index_categoria = 12 Then
            If i = 0 Then
                cat12_llena = True
            End If
            cat12(i, 0) = id_producto
            cat12(i, 1) = nombre
            cat12(i, 2) = descripcion
            cat12(i, 3) = unidad
            cat12(i, 4) = codigo
            cat12(i, 5) = id_categoria
            cat12(i, 6) = venta_peso
            cat12(i, 7) = favorito
            cat12_thumb(i) = imagen
        ElseIf index_categoria = 13 Then
            If i = 0 Then
                cat13_llena = True
            End If
            cat13(i, 0) = id_producto
            cat13(i, 1) = nombre
            cat13(i, 2) = descripcion
            cat13(i, 3) = unidad
            cat13(i, 4) = codigo
            cat13(i, 5) = id_categoria
            cat13(i, 6) = venta_peso
            cat13(i, 7) = favorito
            cat13_thumb(i) = imagen
        ElseIf index_categoria = 14 Then
            If i = 0 Then
                cat14_llena = True
            End If
            cat14(i, 0) = id_producto
            cat14(i, 1) = nombre
            cat14(i, 2) = descripcion
            cat14(i, 3) = unidad
            cat14(i, 4) = codigo
            cat14(i, 5) = id_categoria
            cat14(i, 6) = venta_peso
            cat14(i, 7) = favorito
            cat14_thumb(i) = imagen
        ElseIf index_categoria = 15 Then
            If i = 0 Then
                cat15_llena = True
            End If
            cat15(i, 0) = id_producto
            cat15(i, 1) = nombre
            cat15(i, 2) = descripcion
            cat15(i, 3) = unidad
            cat15(i, 4) = codigo
            cat15(i, 5) = id_categoria
            cat15(i, 6) = venta_peso
            cat15(i, 7) = favorito
            cat15_thumb(i) = imagen
        ElseIf index_categoria = 16 Then
            If i = 0 Then
                cat16_llena = True
            End If
            cat16(i, 0) = id_producto
            cat16(i, 1) = nombre
            cat16(i, 2) = descripcion
            cat16(i, 3) = unidad
            cat16(i, 4) = codigo
            cat16(i, 5) = id_categoria
            cat16(i, 6) = venta_peso
            cat16(i, 7) = favorito
            cat16_thumb(i) = imagen
        ElseIf index_categoria = 17 Then
            If i = 0 Then
                cat17_llena = True
            End If
            cat17(i, 0) = id_producto
            cat17(i, 1) = nombre
            cat17(i, 2) = descripcion
            cat17(i, 3) = unidad
            cat17(i, 4) = codigo
            cat17(i, 5) = id_categoria
            cat17(i, 6) = venta_peso
            cat17(i, 7) = favorito
            cat17_thumb(i) = imagen
        ElseIf index_categoria = 18 Then
            If i = 0 Then
                cat18_llena = True
            End If
            cat18(i, 0) = id_producto
            cat18(i, 1) = nombre
            cat18(i, 2) = descripcion
            cat18(i, 3) = unidad
            cat18(i, 4) = codigo
            cat18(i, 5) = id_categoria
            cat18(i, 6) = venta_peso
            cat18(i, 7) = favorito
            cat18_thumb(i) = imagen
        ElseIf index_categoria = 19 Then
            If i = 0 Then
                cat19_llena = True
            End If
            cat19(i, 0) = id_producto
            cat19(i, 1) = nombre
            cat19(i, 2) = descripcion
            cat19(i, 3) = unidad
            cat19(i, 4) = codigo
            cat19(i, 5) = id_categoria
            cat19(i, 6) = venta_peso
            cat19(i, 7) = favorito
            cat19_thumb(i) = imagen
        ElseIf index_categoria = 20 Then
            If i = 0 Then
                cat20_llena = True
            End If
            cat20(i, 0) = id_producto
            cat20(i, 1) = nombre
            cat20(i, 2) = descripcion
            cat20(i, 3) = unidad
            cat20(i, 4) = codigo
            cat20(i, 5) = id_categoria
            cat20(i, 6) = venta_peso
            cat20(i, 7) = favorito
            cat20_thumb(i) = imagen
        ElseIf index_categoria = 21 Then
            If i = 0 Then
                cat21_llena = True
            End If
            cat21(i, 0) = id_producto
            cat21(i, 1) = nombre
            cat21(i, 2) = descripcion
            cat21(i, 3) = unidad
            cat21(i, 4) = codigo
            cat21(i, 5) = id_categoria
            cat21(i, 6) = venta_peso
            cat21(i, 7) = favorito
            cat21_thumb(i) = imagen
        ElseIf index_categoria = 22 Then
            If i = 0 Then
                cat22_llena = True
            End If
            cat22(i, 0) = id_producto
            cat22(i, 1) = nombre
            cat22(i, 2) = descripcion
            cat22(i, 3) = unidad
            cat22(i, 4) = codigo
            cat22(i, 5) = id_categoria
            cat22(i, 6) = venta_peso
            cat22(i, 7) = favorito
            cat22_thumb(i) = imagen
        ElseIf index_categoria = 23 Then
            If i = 0 Then
                cat23_llena = True
            End If
            cat23(i, 0) = id_producto
            cat23(i, 1) = nombre
            cat23(i, 2) = descripcion
            cat23(i, 3) = unidad
            cat23(i, 4) = codigo
            cat23(i, 5) = id_categoria
            cat23(i, 6) = venta_peso
            cat23(i, 7) = favorito
            cat23_thumb(i) = imagen
        ElseIf index_categoria = 24 Then
            If i = 0 Then
                cat24_llena = True
            End If
            cat24(i, 0) = id_producto
            cat24(i, 1) = nombre
            cat24(i, 2) = descripcion
            cat24(i, 3) = unidad
            cat24(i, 4) = codigo
            cat24(i, 5) = id_categoria
            cat24(i, 6) = venta_peso
            cat24(i, 7) = favorito
            cat24_thumb(i) = imagen
        ElseIf index_categoria = 25 Then
            If i = 0 Then
                cat25_llena = True
            End If
            cat25(i, 0) = id_producto
            cat25(i, 1) = nombre
            cat25(i, 2) = descripcion
            cat25(i, 3) = unidad
            cat25(i, 4) = codigo
            cat25(i, 5) = id_categoria
            cat25(i, 6) = venta_peso
            cat25(i, 7) = favorito
            cat25_thumb(i) = imagen
        ElseIf index_categoria = 26 Then
            If i = 0 Then
                cat26_llena = True
            End If
            cat26(i, 0) = id_producto
            cat26(i, 1) = nombre
            cat26(i, 2) = descripcion
            cat26(i, 3) = unidad
            cat26(i, 4) = codigo
            cat26(i, 5) = id_categoria
            cat26(i, 6) = venta_peso
            cat26(i, 7) = favorito
            cat26_thumb(i) = imagen
        ElseIf index_categoria = 27 Then
            If i = 0 Then
                cat27_llena = True
            End If
            cat27(i, 0) = id_producto
            cat27(i, 1) = nombre
            cat27(i, 2) = descripcion
            cat27(i, 3) = unidad
            cat27(i, 4) = codigo
            cat27(i, 5) = id_categoria
            cat27(i, 6) = venta_peso
            cat27(i, 7) = favorito
            cat27_thumb(i) = imagen
        ElseIf index_categoria = 28 Then
            If i = 0 Then
                cat28_llena = True
            End If
            cat28(i, 0) = id_producto
            cat28(i, 1) = nombre
            cat28(i, 2) = descripcion
            cat28(i, 3) = unidad
            cat28(i, 4) = codigo
            cat28(i, 5) = id_categoria
            cat28(i, 6) = venta_peso
            cat28(i, 7) = favorito
            cat28_thumb(i) = imagen
        ElseIf index_categoria = 29 Then
            If i = 0 Then
                cat29_llena = True
            End If
            cat29(i, 0) = id_producto
            cat29(i, 1) = nombre
            cat29(i, 2) = descripcion
            cat29(i, 3) = unidad
            cat29(i, 4) = codigo
            cat29(i, 5) = id_categoria
            cat29(i, 6) = venta_peso
            cat29(i, 7) = favorito
            cat29_thumb(i) = imagen
        End If
    End Sub
    Private Sub agregar_datos_boton_producto(ByVal index As Integer, ByVal imagen As Object, ByVal nombre As String)
        Select Case index
            Case 0
                producto1.BackgroundImage = imagen
                FavLb1.Text = nombre
                producto1.Visible = True
                FavLb1.Visible = True
                producto1.BackColor = Color.FromArgb(conf_colores(6))

                FavLb1.Parent = producto1
                FavLb1.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb1.BackColor = Color.FromArgb(150, Color.Black)

            Case 1
                producto2.BackgroundImage = imagen
                FavLb2.Text = nombre
                producto2.Visible = True
                FavLb2.Visible = True
                producto2.BackColor = Color.FromArgb(conf_colores(6))

                FavLb2.Parent = producto2
                FavLb2.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb2.BackColor = Color.FromArgb(150, Color.Black)
            Case 2
                producto3.BackgroundImage = imagen
                FavLb3.Text = nombre
                producto3.Visible = True
                FavLb3.Visible = True
                producto3.BackColor = Color.FromArgb(conf_colores(6))

                FavLb3.Parent = producto3
                FavLb3.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb3.BackColor = Color.FromArgb(150, Color.Black)

            Case 3
                producto4.BackgroundImage = imagen
                FavLb4.Text = nombre
                producto4.Visible = True
                FavLb4.Visible = True
                producto4.BackColor = Color.FromArgb(conf_colores(6))

                FavLb4.Parent = producto4
                FavLb4.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb4.BackColor = Color.FromArgb(150, Color.Black)
            Case 4
                producto5.BackgroundImage = imagen
                FavLb5.Text = nombre
                producto5.Visible = True
                FavLb5.Visible = True
                producto5.BackColor = Color.FromArgb(conf_colores(6))

                FavLb5.Parent = producto5
                FavLb5.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb5.BackColor = Color.FromArgb(150, Color.Black)
            Case 5
                producto6.BackgroundImage = imagen
                FavLb6.Text = nombre
                producto6.Visible = True
                FavLb6.Visible = True
                producto6.BackColor = Color.FromArgb(conf_colores(6))

                FavLb6.Parent = producto6
                FavLb6.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb6.BackColor = Color.FromArgb(150, Color.Black)

            Case 6
                producto7.BackgroundImage = imagen
                FavLb7.Text = nombre
                producto7.Visible = True
                FavLb7.Visible = True
                producto7.BackColor = Color.FromArgb(conf_colores(6))

                FavLb7.Parent = producto7
                FavLb7.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb7.BackColor = Color.FromArgb(150, Color.Black)
            Case 7
                producto8.BackgroundImage = imagen
                FavLb8.Text = nombre
                producto8.Visible = True
                FavLb8.Visible = True
                producto8.BackColor = Color.FromArgb(conf_colores(6))

                FavLb8.Parent = producto8
                FavLb8.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb8.BackColor = Color.FromArgb(150, Color.Black)
            Case 8
                producto9.BackgroundImage = imagen
                FavLb9.Text = nombre
                producto9.Visible = True
                FavLb9.Visible = True
                producto9.BackColor = Color.FromArgb(conf_colores(6))

                FavLb9.Parent = producto9
                FavLb9.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb9.BackColor = Color.FromArgb(150, Color.Black)
            Case 9
                producto10.BackgroundImage = imagen
                FavLb10.Text = nombre
                producto10.Visible = True
                FavLb10.Visible = True
                producto10.BackColor = Color.FromArgb(conf_colores(6))

                FavLb10.Parent = producto10
                FavLb10.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb10.BackColor = Color.FromArgb(150, Color.Black)
            Case 10
                producto11.BackgroundImage = imagen
                FavLb11.Text = nombre
                producto11.Visible = True
                FavLb11.Visible = True
                producto11.BackColor = Color.FromArgb(conf_colores(6))

                FavLb11.Parent = producto11
                FavLb11.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb11.BackColor = Color.FromArgb(150, Color.Black)
            Case 11
                producto12.BackgroundImage = imagen
                FavLb12.Text = nombre
                producto12.Visible = True
                FavLb12.Visible = True
                producto12.BackColor = Color.FromArgb(conf_colores(6))

                FavLb12.Parent = producto12
                FavLb12.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb12.BackColor = Color.FromArgb(150, Color.Black)
            Case 12
                producto13.BackgroundImage = imagen
                FavLb13.Text = nombre
                producto13.Visible = True
                FavLb13.Visible = True
                producto13.BackColor = Color.FromArgb(conf_colores(6))

                FavLb13.Parent = producto13
                FavLb13.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb13.BackColor = Color.FromArgb(150, Color.Black)
            Case 13
                producto14.BackgroundImage = imagen
                FavLb14.Text = nombre
                producto14.Visible = True
                FavLb14.Visible = True
                producto14.BackColor = Color.FromArgb(conf_colores(6))

                FavLb14.Parent = producto14
                FavLb14.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb14.BackColor = Color.FromArgb(150, Color.Black)
            Case 14
                producto15.BackgroundImage = imagen
                FavLb15.Text = nombre
                producto15.Visible = True
                FavLb15.Visible = True
                producto15.BackColor = Color.FromArgb(conf_colores(6))

                FavLb15.Parent = producto15
                FavLb15.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb15.BackColor = Color.FromArgb(150, Color.Black)
            Case 15
                producto16.BackgroundImage = imagen
                FavLb16.Text = nombre
                producto16.Visible = True
                FavLb16.Visible = True
                producto16.BackColor = Color.FromArgb(conf_colores(6))

                FavLb16.Parent = producto16
                FavLb16.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb16.BackColor = Color.FromArgb(150, Color.Black)
            Case 16
                producto17.BackgroundImage = imagen
                FavLb17.Text = nombre
                producto17.Visible = True
                FavLb17.Visible = True
                producto17.BackColor = Color.FromArgb(conf_colores(6))

                FavLb17.Parent = producto17
                FavLb17.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb17.BackColor = Color.FromArgb(150, Color.Black)
            Case 17
                producto18.BackgroundImage = imagen
                FavLb18.Text = nombre
                producto18.Visible = True
                FavLb18.Visible = True
                producto18.BackColor = Color.FromArgb(conf_colores(6))

                FavLb18.Parent = producto18
                FavLb18.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb18.BackColor = Color.FromArgb(150, Color.Black)
            Case 18
                producto19.BackgroundImage = imagen
                FavLb19.Text = nombre
                producto19.Visible = True
                FavLb19.Visible = True
                producto19.BackColor = Color.FromArgb(conf_colores(6))

                FavLb19.Parent = producto19
                FavLb19.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb19.BackColor = Color.FromArgb(150, Color.Black)
            Case 19
                producto20.BackgroundImage = imagen
                FavLb20.Text = nombre
                producto20.Visible = True
                FavLb20.Visible = True
                producto20.BackColor = Color.FromArgb(conf_colores(6))

                FavLb20.Parent = producto20
                FavLb20.ForeColor = Color.FromArgb(conf_colores(7))
                FavLb20.BackColor = Color.FromArgb(150, Color.Black)
        End Select
    End Sub
    Private Sub agregar_datos_boton_categorias(ByVal index As Integer, ByVal nombre As String)
        Select Case index
            Case 0
                'categoria2.Image = imagen
                categoria2.Text = nombre
                categoria2.Visible = True
                categoria2.BackColor = Color.FromArgb(conf_colores(11))
                categoria2.ForeColor = Color.FromArgb(conf_colores(12))
            Case 1
                ' categoria3.Image = imagen
                categoria3.Text = nombre
                categoria3.Visible = True
                categoria3.BackColor = Color.FromArgb(conf_colores(11))
                categoria3.ForeColor = Color.FromArgb(conf_colores(12))
            Case 2
                ' categoria4.Image = imagen
                categoria4.Text = nombre
                categoria4.Visible = True
                categoria4.BackColor = Color.FromArgb(conf_colores(11))
                categoria4.ForeColor = Color.FromArgb(conf_colores(12))
            Case 3
                ' categoria5.Image = imagen
                categoria5.Text = nombre
                categoria5.Visible = True
                categoria5.BackColor = Color.FromArgb(conf_colores(11))
                categoria5.ForeColor = Color.FromArgb(conf_colores(12))
            Case 4
                'categoria6.Image = imagen
                categoria6.Text = nombre
                categoria6.Visible = True
                categoria6.BackColor = Color.FromArgb(conf_colores(11))
                categoria6.ForeColor = Color.FromArgb(conf_colores(12))
            Case 5
                'categoria7.Image = imagen
                categoria7.Text = nombre
                categoria7.Visible = True
                categoria7.BackColor = Color.FromArgb(conf_colores(11))
                categoria7.ForeColor = Color.FromArgb(conf_colores(12))
            Case 6
                ' categoria8.Image = imagen
                categoria8.Text = nombre
                categoria8.Visible = True
                categoria8.BackColor = Color.FromArgb(conf_colores(11))
                categoria8.ForeColor = Color.FromArgb(conf_colores(12))
            Case 7
                ' categoria9.Image = imagen
                categoria9.Text = nombre
                categoria9.Visible = True
                categoria9.BackColor = Color.FromArgb(conf_colores(11))
                categoria9.ForeColor = Color.FromArgb(conf_colores(12))
            Case 8
                ' categoria10.Image = imagen
                categoria10.Text = nombre
                categoria10.Visible = True
                categoria10.BackColor = Color.FromArgb(conf_colores(11))
                categoria10.ForeColor = Color.FromArgb(conf_colores(12))
            Case 9                ' categoria10.Image = imagen
                categoria2.Text = nombre
                categoria2.Visible = True
                categoria2.BackColor = Color.FromArgb(conf_colores(11))
                categoria2.ForeColor = Color.FromArgb(conf_colores(12))
            Case 10               ' categoria10.Image = imagen
                categoria3.Text = nombre
                categoria3.Visible = True
                categoria3.BackColor = Color.FromArgb(conf_colores(11))
                categoria3.ForeColor = Color.FromArgb(conf_colores(12))
            Case 11
                ' categoria4.Image = imagen
                categoria4.Text = nombre
                categoria4.Visible = True
                categoria4.BackColor = Color.FromArgb(conf_colores(11))
                categoria4.ForeColor = Color.FromArgb(conf_colores(12))
            Case 12
                ' categoria5.Image = imagen
                categoria5.Text = nombre
                categoria5.Visible = True
                categoria5.BackColor = Color.FromArgb(conf_colores(11))
                categoria5.ForeColor = Color.FromArgb(conf_colores(12))
            Case 13
                'categoria6.Image = imagen
                categoria6.Text = nombre
                categoria6.Visible = True
                categoria6.BackColor = Color.FromArgb(conf_colores(11))
                categoria6.ForeColor = Color.FromArgb(conf_colores(12))
            Case 14
                'categoria7.Image = imagen
                categoria7.Text = nombre
                categoria7.Visible = True
                categoria7.BackColor = Color.FromArgb(conf_colores(11))
                categoria7.ForeColor = Color.FromArgb(conf_colores(12))
            Case 15
                ' categoria8.Image = imagen
                categoria8.Text = nombre
                categoria8.Visible = True
                categoria8.BackColor = Color.FromArgb(conf_colores(11))
                categoria8.ForeColor = Color.FromArgb(conf_colores(12))
            Case 16
                ' categoria9.Image = imagen
                categoria9.Text = nombre
                categoria9.Visible = True
                categoria9.BackColor = Color.FromArgb(conf_colores(11))
                categoria9.ForeColor = Color.FromArgb(conf_colores(12))
            Case 17
                ' categoria10.Image = imagen
                categoria10.Text = nombre
                categoria10.Visible = True
                categoria10.BackColor = Color.FromArgb(conf_colores(11))
                categoria10.ForeColor = Color.FromArgb(conf_colores(12))
            Case 18
                'categoria2.Image = imagen
                categoria2.Text = nombre
                categoria2.Visible = True
                categoria2.BackColor = Color.FromArgb(conf_colores(11))
                categoria2.ForeColor = Color.FromArgb(conf_colores(12))
            Case 19
                ' categoria3.Image = imagen
                categoria3.Text = nombre
                categoria3.Visible = True
                categoria3.BackColor = Color.FromArgb(conf_colores(11))
                categoria3.ForeColor = Color.FromArgb(conf_colores(12))
            Case 20
                ' categoria4.Image = imagen
                categoria4.Text = nombre
                categoria4.Visible = True
                categoria4.BackColor = Color.FromArgb(conf_colores(11))
                categoria4.ForeColor = Color.FromArgb(conf_colores(12))
            Case 21
                ' categoria5.Image = imagen
                categoria5.Text = nombre
                categoria5.Visible = True
                categoria5.BackColor = Color.FromArgb(conf_colores(11))
                categoria5.ForeColor = Color.FromArgb(conf_colores(12))
            Case 22
                'categoria6.Image = imagen
                categoria6.Text = nombre
                categoria6.Visible = True
                categoria6.BackColor = Color.FromArgb(conf_colores(11))
                categoria6.ForeColor = Color.FromArgb(conf_colores(12))
            Case 23
                'categoria7.Image = imagen
                categoria7.Text = nombre
                categoria7.Visible = True
                categoria7.BackColor = Color.FromArgb(conf_colores(11))
                categoria7.ForeColor = Color.FromArgb(conf_colores(12))
            Case 24
                ' categoria8.Image = imagen
                categoria8.Text = nombre
                categoria8.Visible = True
                categoria8.BackColor = Color.FromArgb(conf_colores(11))
                categoria8.ForeColor = Color.FromArgb(conf_colores(12))
            Case 25
                ' categoria9.Image = imagen
                categoria9.Text = nombre
                categoria9.Visible = True
                categoria9.BackColor = Color.FromArgb(conf_colores(11))
                categoria9.ForeColor = Color.FromArgb(conf_colores(12))
            Case 26
                ' categoria10.Image = imagen
                categoria10.Text = nombre
                categoria10.Visible = True
                categoria10.BackColor = Color.FromArgb(conf_colores(11))
                categoria10.ForeColor = Color.FromArgb(conf_colores(12))
        End Select
    End Sub

    Private Sub categoria1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles categoria1.Click, categoria2.Click, categoria3.Click, categoria4.Click, categoria5.Click, categoria6.Click, categoria7.Click, categoria8.Click, categoria9.Click, categoria10.Click
        global_current_tabindex_categoria = (CType(sender, Button).TabIndex)
        obtener_productos_categoria(global_current_tabindex_categoria)
        If global_current_tabindex_categoria = 0 Then
            gb_productos.Text = "Favoritos"
        Else
            gb_productos.Text = categoria(global_current_tabindex_categoria - 1, 1)
        End If
        preparar_para_codigo()
    End Sub

    Private Sub producto1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles producto1.Click, producto2.Click, producto3.Click, producto4.Click, producto5.Click, producto6.Click, producto7.Click, producto8.Click, producto9.Click, producto10.Click, producto11.Click, producto12.Click, producto13.Click, producto14.Click, producto15.Click, producto16.Click, producto17.Click, producto18.Click, producto19.Click, producto20.Click
        If modo_ajuste_posicion = False Then
            global_current_tabindex_producto = (CType(sender, Button).TabIndex)

            frm_producto_cantidad.modo = 1 'le indicamos que es nueva linea
            frm_producto_cantidad.ShowDialog()
            frm_producto_cantidad.BringToFront()
            '------------------------------
        End If

    End Sub
    Private Sub favlb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FavLb1.Click, FavLb2.Click, FavLb3.Click, FavLb4.Click, FavLb5.Click, FavLb6.Click, FavLb7.Click, FavLb8.Click, FavLb9.Click, FavLb10.Click, FavLb11.Click, FavLb12.Click, FavLb13.Click, FavLb14.Click, FavLb15.Click, FavLb16.Click, FavLb17.Click, FavLb18.Click, FavLb19.Click, FavLb20.Click
        If modo_ajuste_posicion = False Then
            global_current_tabindex_producto = (CType(sender, Label).TabIndex)

            frm_producto_cantidad.modo = 1 'le indicamos que es nueva linea
            frm_producto_cantidad.ShowDialog()
            frm_producto_cantidad.BringToFront()
        End If

        '------------------------------
    End Sub

    Private Sub btn_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cliente.Click
        If Trim(tb_codigo_cliente.Text) <> "" Then

            Dim existe_cliente As Boolean = False
            Dim total_clientes As Integer
            Dim _id_cliente As Integer = 0
            'Conectar()
            rs.Open("SELECT id_cliente FROM cliente WHERE clave='" & tb_codigo_cliente.Text & "'", conn)
            If rs.RecordCount > 0 Then
                total_clientes = rs.RecordCount
                _id_cliente = rs.Fields("id_cliente").Value
                existe_cliente = True
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            If existe_cliente = True Then
                If total_clientes > 1 Then
                    frm_clientes.tb_search.Text = tb_codigo_cliente.Text
                    frm_clientes.ShowDialog()
                Else
                    verificar_precio_especial(_id_cliente)
                End If
            Else
                frm_clientes.tb_search.Text = tb_codigo_cliente.Text
                frm_clientes.ShowDialog()
            End If

            tb_codigo_cliente.Text = ""
        Else
            frm_clientes.ShowDialog()
        End If
        preparar_para_codigo()
    End Sub

    Public Sub actualizar_precios_lista() '--actualizamos los precios de la lista por el cambio del cliente

        For x = 0 To dgv_ventas.RowCount - 1
            dgv_ventas.Rows(x).Cells("precio").Value = obtener_precio_producto(dgv_ventas.Rows(x).Cells("id_producto").Value, global_current_precio_especial) / (1 + dgv_ventas.Rows(x).Cells("tasa_impuestos").Value)

            dgv_ventas.Rows(x).Cells("importe").Value = dgv_ventas.Rows(x).Cells("precio").Value * dgv_ventas.Rows(x).Cells("cantidad").Value
            dgv_ventas.Rows(x).Cells("total_impuestos").Value = dgv_ventas.Rows(x).Cells("importe").Value * dgv_ventas.Rows(x).Cells("tasa_impuestos").Value
            '--actualizamos la tabla------
            'Conectar()
            conn.Execute("UPDATE temp_venta_detalle SET precio='" & dgv_ventas.Rows(x).Cells("precio").Value & "',importe='" & Math.Round(dgv_ventas.Rows(x).Cells("importe").Value, 2) & "',total_impuestos='" & Math.Round(dgv_ventas.Rows(x).Cells("total_impuestos").Value, 2) & "',id_cliente='" & global_current_idcliente & "' WHERE id_producto='" & dgv_ventas.Rows(x).Cells("id_producto").Value & "' AND id_empleado='" & global_id_empleado & "'")
            'conn.close()
            'conn = Nothing
            '-----------------------------
        Next
        actualizar_totales()
        'seleccionar_ultima_fila()
    End Sub

    Private Sub btn_almacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_seleccionar_almacen.ShowDialog()
    End Sub
    Public Sub borrar_linea()

        If modo_venta = 0 Then
            Dim id_almacen As Integer
            Dim id_producto As Integer
            'Dim cantidad_actual As Decimal = CDec(lst_productos.Items(lst_productos.SelectedIndices(0)).SubItems(0).Text())
            Dim cantidad_actual As Decimal = 0
            cantidad_actual = dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("cantidad").Value

            'Conectar()
            rs.Open("SELECT id_producto,id_almacen from temp_venta_detalle WHERE id_temp_venta_detalle='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_temp_venta").Value & "' AND id_empleado='" & global_id_empleado & "' ORDER BY id_temp_venta_detalle", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                id_producto = rs.Fields("id_producto").Value
            End If
            rs.Close()
            conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad + " & cantidad_actual & ") WHERE id_producto='" & id_producto & "' AND id_almacen='" & id_almacen & "'")
            conn.Execute("DELETE FROM temp_venta_detalle WHERE id_temp_venta_detalle=" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_temp_venta").Value)



            dgv_ventas.Rows.RemoveAt(dgv_ventas.CurrentRow.Index)


            If dgv_ventas.Rows.Count = 0 Then
                linea_ = 0
            End If
            actualizar_totales()

        Else
            dgv_ventas.Rows.RemoveAt(dgv_ventas.CurrentRow.Index)

            conn.Execute("DELETE FROM orden_comedor_detalle WHERE id_orden_comedor_detalle=" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_temp_venta").Value)

            If dgv_ventas.Rows.Count = 0 Then
                linea_ = 0
            End If
            actualizar_totales()
            'seleccionar_ultima_fila()

            ' SE AGREGA LOS PRODUCTOS A LA LISTA_TICKET
        End If


    End Sub
    Public Sub borrar_linea_VERSION_DGV()
        Dim id_almacen As Integer
        Dim id_temp_venta_detalle As Integer
        Dim cantidad_actual As Decimal = CDec(dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("cantidad").Value)
        'Conectar()
        rs.Open("SELECT id_temp_venta_detalle,id_almacen from temp_venta_detalle WHERE id_producto='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_producto").Value & "' AND id_empleado='" & global_id_empleado & "' ORDER BY id_temp_venta_detalle", conn)
        If rs.RecordCount > 0 Then
            id_almacen = rs.Fields("id_almacen").Value
            id_temp_venta_detalle = rs.Fields("id_temp_venta_detalle").Value
        End If
        rs.Close()
        conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad + " & cantidad_actual & ") WHERE id_producto='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_producto").Value & "' AND id_almacen='" & id_almacen & "'")
        conn.Execute("DELETE FROM temp_venta_detalle WHERE id_temp_venta_detalle=" & id_temp_venta_detalle)
        'conn.close()
        dgv_ventas.Rows.RemoveAt(dgv_ventas.CurrentRow.Index)
        If dgv_ventas.Rows.Count = 0 Then
            linea_ = 0
        End If
        actualizar_totales()
    End Sub
    Public Sub buscar_borrar_linea(ByVal id_temp_venta As Integer)
        For x = 0 To dgv_ventas.RowCount - 1
            If dgv_ventas.Rows(x).Cells("id_temp_venta").Value = id_temp_venta Then
                dgv_ventas.Rows.RemoveAt(dgv_ventas.Rows(x).Index)
                If dgv_ventas.Rows.Count = 0 Then
                    linea_ = 0
                End If
                actualizar_totales()
                'seleccionar_ultima_fila()
                Exit For
            End If
        Next

    End Sub
    Private Sub FavLbl_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles FavLb1.MouseHover, FavLb2.MouseHover, FavLb3.MouseHover, FavLb4.MouseHover, FavLb5.MouseHover, FavLb6.MouseHover, FavLb7.MouseHover, FavLb8.MouseHover, FavLb9.MouseHover, FavLb10.MouseHover, FavLb11.MouseHover, FavLb12.MouseHover, FavLb13.MouseHover, FavLb14.MouseHover, FavLb15.MouseHover, FavLb16.MouseHover, FavLb17.MouseHover, FavLb18.MouseHover, FavLb19.MouseHover, FavLb20.MouseHover
        lb_nombre_producto.Visible = True
        global_current_tabindex_producto = (CType(sender, Label).TabIndex)

        If global_current_tabindex_categoria = 0 Then
            global_current_idproducto = favoritos(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 1 Then
            global_current_idproducto = cat1(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 2 Then
            global_current_idproducto = cat2(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 3 Then
            global_current_idproducto = cat3(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 4 Then
            global_current_idproducto = cat4(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 5 Then
            global_current_idproducto = cat5(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 6 Then
            global_current_idproducto = cat6(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 7 Then
            global_current_idproducto = cat7(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 8 Then
            global_current_idproducto = cat8(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 9 Then
            global_current_idproducto = cat9(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 10 Then
            global_current_idproducto = cat10(global_current_tabindex_producto, 0)
        ElseIf global_current_tabindex_categoria = 11 Then
            global_current_idproducto = cat11(global_current_tabindex_producto, 0)
        End If

    End Sub

    Private Sub producto1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles producto1.MouseDown, producto2.MouseDown, producto3.MouseDown, producto4.MouseDown, producto5.MouseDown, producto6.MouseDown, producto7.MouseDown, producto8.MouseDown, producto9.MouseDown, producto10.MouseDown, producto11.MouseDown, producto12.MouseDown, producto13.MouseDown, producto14.MouseDown, producto15.MouseDown, producto16.MouseDown, producto17.MouseDown, producto18.MouseDown, producto19.MouseDown, producto20.MouseDown
        If modo_ajuste_posicion = True Then
            dragging = True
            posicionX = e.X
            posicionY = e.Y
        End If

    End Sub
    Private Sub producto1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles producto1.MouseHover, producto2.MouseHover, producto3.MouseHover, producto4.MouseHover, producto5.MouseHover, producto6.MouseHover, producto7.MouseHover, producto8.MouseHover, producto9.MouseHover, producto10.MouseHover, producto11.MouseHover, producto12.MouseHover, producto13.MouseHover, producto14.MouseHover, producto15.MouseHover, producto16.MouseHover, producto17.MouseHover, producto18.MouseHover, producto19.MouseHover, producto20.MouseHover
        lb_nombre_producto.Visible = True
        global_current_tabindex_producto = (CType(sender, Button).TabIndex)
        Dim nombre_producto As String = ""

        If global_current_tabindex_categoria = 0 Then
            global_current_idproducto = favoritos(global_current_tabindex_producto, 0)
            nombre_producto = favoritos(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 1 Then
            global_current_idproducto = cat1(global_current_tabindex_producto, 0)
            nombre_producto = cat1(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 2 Then
            global_current_idproducto = cat2(global_current_tabindex_producto, 0)
            nombre_producto = cat2(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 3 Then
            global_current_idproducto = cat3(global_current_tabindex_producto, 0)
            nombre_producto = cat3(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 4 Then
            global_current_idproducto = cat4(global_current_tabindex_producto, 0)
            nombre_producto = cat4(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 5 Then
            global_current_idproducto = cat5(global_current_tabindex_producto, 0)
            nombre_producto = cat5(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 6 Then
            global_current_idproducto = cat6(global_current_tabindex_producto, 0)
            nombre_producto = cat6(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 7 Then
            global_current_idproducto = cat7(global_current_tabindex_producto, 0)
            nombre_producto = cat7(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 8 Then
            global_current_idproducto = cat8(global_current_tabindex_producto, 0)
            nombre_producto = cat8(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 9 Then
            global_current_idproducto = cat9(global_current_tabindex_producto, 0)
            nombre_producto = cat9(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 10 Then
            global_current_idproducto = cat10(global_current_tabindex_producto, 0)
            nombre_producto = cat10(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 11 Then
            global_current_idproducto = cat11(global_current_tabindex_producto, 0)
            nombre_producto = cat11(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 12 Then
            global_current_idproducto = cat12(global_current_tabindex_producto, 0)
            nombre_producto = cat12(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 13 Then
            global_current_idproducto = cat13(global_current_tabindex_producto, 0)
            nombre_producto = cat13(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 14 Then
            global_current_idproducto = cat14(global_current_tabindex_producto, 0)
            nombre_producto = cat14(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 15 Then
            global_current_idproducto = cat15(global_current_tabindex_producto, 0)
            nombre_producto = cat15(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 16 Then
            global_current_idproducto = cat16(global_current_tabindex_producto, 0)
            nombre_producto = cat16(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 17 Then
            global_current_idproducto = cat17(global_current_tabindex_producto, 0)
            nombre_producto = cat17(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 18 Then
            global_current_idproducto = cat18(global_current_tabindex_producto, 0)
            nombre_producto = cat18(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 19 Then
            global_current_idproducto = cat19(global_current_tabindex_producto, 0)
            nombre_producto = cat19(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 20 Then
            global_current_idproducto = cat20(global_current_tabindex_producto, 0)
            nombre_producto = cat20(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 21 Then
            global_current_idproducto = cat21(global_current_tabindex_producto, 0)
            nombre_producto = cat21(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 22 Then
            global_current_idproducto = cat22(global_current_tabindex_producto, 0)
            nombre_producto = cat22(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 23 Then
            global_current_idproducto = cat23(global_current_tabindex_producto, 0)
            nombre_producto = cat23(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 24 Then
            global_current_idproducto = cat24(global_current_tabindex_producto, 0)
            nombre_producto = cat24(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 25 Then
            global_current_idproducto = cat25(global_current_tabindex_producto, 0)
            nombre_producto = cat25(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 26 Then
            global_current_idproducto = cat26(global_current_tabindex_producto, 0)
            nombre_producto = cat26(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 27 Then
            global_current_idproducto = cat27(global_current_tabindex_producto, 0)
            nombre_producto = cat27(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 28 Then
            global_current_idproducto = cat28(global_current_tabindex_producto, 0)
            nombre_producto = cat28(global_current_tabindex_producto, 1)
        ElseIf global_current_tabindex_categoria = 29 Then
            global_current_idproducto = cat29(global_current_tabindex_producto, 0)
            nombre_producto = cat29(global_current_tabindex_producto, 1)
        End If
    End Sub
    Public Sub actualizar_totales()
        Dim j As Integer

        global_subtotal = 0
        global_total_impuestos = 0

        For j = 0 To dgv_ventas.RowCount - 1
            
            global_subtotal = global_subtotal + CDec(dgv_ventas.Rows(j).Cells("importe").Value)
            global_total_impuestos = global_total_impuestos + CDec(dgv_ventas.Rows(j).Cells("total_impuestos").Value)
          
        Next
        '--obtenemos el importe de descuento total

        '---------------------------------------------
        tb_subtotal.Text = FormatCurrency(global_subtotal, 2)
        tb_impuestos.Text = FormatCurrency(global_total_impuestos, 2)
        global_total = global_subtotal + global_total_impuestos
        tb_total.Text = FormatCurrency(global_total, 2)



        If tabla_ventas.Rows.Count > 0 Then
            btn_cancelar_venta.Enabled = True
            btn_enviar_venta.Enabled = True
            btn_aplicar_descuento.Enabled = True


            If global_tipo_operacion = 0 Then
                btn_cobrar_venta.Enabled = True
                btn_aplicar_descuento.Enabled = True
            Else
                btn_cobrar_venta.Enabled = False
            End If
            If dgv_ventas.SelectedRows.Count > 0 Then
                btn_borrar_producto.Enabled = True
                btn_modificar_cantidad.Enabled = True
                btn_modificar_precio.Enabled = True
                btn_aplicar_descuento.Enabled = True
            Else
                btn_borrar_producto.Enabled = False
                btn_modificar_cantidad.Enabled = False
                btn_modificar_precio.Enabled = False
                btn_aplicar_descuento.Enabled = True
            End If
        Else
            btn_cancelar_venta.Enabled = False
            btn_enviar_venta.Enabled = False
            btn_cobrar_venta.Enabled = False
            btn_aplicar_descuento.Enabled = False
            btn_borrar_producto.Enabled = False
            btn_modificar_cantidad.Enabled = False
            btn_modificar_precio.Enabled = False

        End If
        preparar_para_codigo()
    End Sub

    Private Sub btn_cancelar_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_venta.Click
        If global_tipo_operacion = 0 Then
            '---cancelamos_venta
            If MsgBox("Desea borrar todos los productos de esta venta? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim cantidad As Decimal = 0
                Dim id_almacen, id_producto As Integer
                'Conectar()
                For x = 0 To dgv_ventas.RowCount - 1
                    cantidad = dgv_ventas.Rows(x).Cells("cantidad").Value
                    id_almacen = dgv_ventas.Rows(x).Cells("id_almacen").Value
                    id_producto = dgv_ventas.Rows(x).Cells("id_producto").Value
                    '--actualizamos la tabla------
                    conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad +" & cantidad & ") WHERE id_producto='" & id_producto & "' AND id_almacen='" & id_almacen & "'")
                    '-----------------------------
                Next

                If modo_venta = 0 Then
                    conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")
                Else
                    conn.Execute("DELETE FROM orden_comedor_detalle WHERE id_orden_comedor='" & id_orden & "'")
                End If

                'conn.close()
                'conn = Nothing
                conf_inicio()
            End If
            '----
        Else
            If MsgBox("Esta seguro de cancelar este pedido? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")
                'conn.close()
                'conn = Nothing
                conf_inicio()
            End If

        End If

        preparar_para_codigo()
    End Sub

    Private Sub btn_enviar_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar_venta.Click
        If global_tipo_operacion = 0 Then
            '----GUARDAMOS COMO VENTA---------
            If MsgBox("Confirme enviar venta", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                Dim id_venta As Integer = 0
                Dim total_impuestos As Decimal = 0
                'Conectar()
                Dim cliente_publico_alias As String = ""
                If global_current_idcliente = 1 Then
                    If Trim(tb_codigo_cliente.Text) <> "" Then
                        cliente_publico_alias = tb_codigo_cliente.Text
                    Else
                        cliente_publico_alias = "Publico en General"
                    End If
                End If

                If global_id_venta_pedido = 0 Then
                    conn.Execute("INSERT INTO venta(fecha,id_sucursal,id_empleado,id_cliente,cliente_publico_alias,subtotal,total_impuestos,total_descuento,total,desc_global_porcent,desc_global_importe) VALUES(NOW()," & global_id_sucursal & "," & global_id_empleado & "," & global_current_idcliente & ",'" & cliente_publico_alias & "','" & global_subtotal & "','" & global_total_impuestos & "','" & global_total_descuento & "','" & global_total & "','" & global_current_descuento_global & "','" & global_current_descuento_global_importe & "')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_venta = rs.Fields(0).Value
                    rs.Close()
                Else
                    conn.Execute("UPDATE venta SET fecha=NOW(),id_sucursal='" & global_id_sucursal & "',id_empleado='" & global_id_empleado & "',id_cliente='" & global_current_idcliente & "',subtotal='" & global_subtotal & "',total_impuestos='" & global_total_impuestos & "',total_descuento='" & global_total_descuento & "',total='" & global_total & "',desc_global_porcent='" & global_current_descuento_global & "',status='ABIERTA' WHERE id_venta='" & global_id_venta_pedido & "'")
                    id_venta = global_id_venta_pedido
                End If

                For x = 0 To dgv_ventas.RowCount - 1
                    conn.Execute("INSERT INTO venta_detalle(id_venta,id_producto,cantidad,total_impuestos,nombre_impuestos,tasa_impuestos,precio,descripcion,unidad,id_almacen,importe,modificador,id_producto_modificador)" & _
                            " VALUES(" & id_venta & "," & dgv_ventas.Rows(x).Cells("id_producto").Value & ",'" & dgv_ventas.Rows(x).Cells("cantidad").Value & "','" & Math.Round(dgv_ventas.Rows(x).Cells("total_impuestos").Value, 2) & "','" & dgv_ventas.Rows(x).Cells("nombre_impuestos").Value & "','" & dgv_ventas.Rows(x).Cells("tasa_impuestos").Value & "','" & dgv_ventas.Rows(x).Cells("precio").Value & "','" & dgv_ventas.Rows(x).Cells("descripcion").Value & "','" & dgv_ventas.Rows(x).Cells("unidad").Value & "','" & dgv_ventas.Rows(x).Cells("id_almacen").Value & "','" & Math.Round(dgv_ventas.Rows(x).Cells("importe").Value, 2) & "','" & dgv_ventas.Rows(x).Cells("modificador").Value & "','" & dgv_ventas.Rows(x).Cells("id_producto_modificador").Value & "')")
                    '---descontamos y registramos productos compuesto-----
                    rs.Open("SELECT id_insumo,cantidad,id_tipo_descuento,cantidad_unidad FROM cfg_producto_compuesto WHERE id_producto=" & dgv_ventas.Rows(x).Cells("id_producto").Value, conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            Dim cantidad_insumo As Decimal = 0
                            If rs.Fields("id_tipo_descuento").Value = 0 Then
                                cantidad_insumo = (CDec(rs.Fields("cantidad").Value) * CDec(dgv_ventas.Rows(x).Cells("cantidad").Value)) / CDec(rs.Fields("cantidad_unidad").Value)
                            ElseIf rs.Fields("id_tipo_descuento").Value = 1 Then
                                cantidad_insumo = CDec(rs.Fields("cantidad").Value)
                            End If
                            Dim id_almacen = obtener_idalmacen(rs.Fields("id_insumo").Value)
                            conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad - " & cantidad_insumo & ") WHERE id_producto=" & rs.Fields("id_insumo").Value & " AND id_almacen=" & id_almacen & "")
                            conn.Execute("INSERT INTO venta_insumo(id_venta,id_producto,cantidad,id_insumo) VALUES('" & id_venta & "','" & dgv_ventas.Rows(x).Cells("id_producto").Value & "','" & cantidad_insumo & "','" & rs.Fields("id_insumo").Value & "')")
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                    '-------------------------------- ----------------------
                Next
                conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")
                'conn.close()
                'conn = Nothing
                If conf_pv(7) = 1 Then
                    imprimir_ticket_envio_venta(id_venta) 'ENVIAMOS EL TICKET CON EL CODIGO DE BARRA
                End If
                conf_inicio()
            End If
        Else
            global_id_venta_pedido = 0
            frm_pedido_fecha.ShowDialog()
            frm_pedido_fecha.BringToFront()
        End If
        preparar_para_codigo()

    End Sub

    Public Sub enviar_como_pedido(ByVal fecha As Date, ByVal hora As DateTime, ByVal comentarios As String)
        If fecha = Today Then
            If MsgBox("Esta seguro que desean enviar el pedido con la fecha de hoy", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
                GoTo A
            End If
        Else
            If MsgBox("Confirme enviar pedido", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
A:              If global_current_idcliente <> 1 Then
                    Dim id_venta As Integer = 0
                    Dim id_pedido As Integer = 0
                    Dim total_iva As Decimal = 0
                    Dim total_otros As Decimal = 0
                    Dim total_impuestos As Decimal = 0
                    Dim fecha_entrega As String = ""
                    fecha_entrega = Format(fecha, "yyyy-MM-dd") & " " & Format(hora, "HH:mm:ss")
                    'Conectar()

                    conn.Execute("INSERT INTO venta(fecha,id_sucursal,id_empleado,id_cliente,subtotal,total_impuestos,total_descuento,total,desc_global_porcent,desc_global_importe,credito,status) VALUES(NOW()," & global_id_sucursal & "," & global_id_empleado & "," & global_current_idcliente & ",'" & global_subtotal & "','" & global_total_impuestos & "','" & global_total_descuento & "','" & global_total & "','" & global_current_descuento_global & "','" & global_current_descuento_global_importe & "','1','PENDIENTE')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_venta = rs.Fields(0).Value
                    conn.Execute("UPDATE venta SET num_ticket=" & id_venta & " WHERE id_venta=" & id_venta)
                    rs.Close()

                    For x = 0 To dgv_ventas.RowCount - 1

                        If CDec(dgv_ventas.Rows(x).Cells("total_iva").Value) > 0 Then
                            total_iva = (CDec(dgv_ventas.Rows(x).Cells("importe").Value) * CDec(dgv_ventas.Rows(x).Cells("total_iva").Value)) / 100
                        End If

                        If CDec(dgv_ventas.Rows(x).Cells("total_iva").Value) > 0 Then
                            total_otros = (CDec(dgv_ventas.Rows(x).Cells("importe").Value) * CDec(dgv_ventas.Rows(x).Cells("total_otros").Value)) / 100
                        End If
                        total_impuestos = total_iva + total_otros

                        Dim ry As New ADODB.Recordset
                        Dim producto_costo As Decimal = 0
                        ry.Open("SELECT costo FROM producto WHERE id_producto='" & dgv_ventas.Rows(x).Cells("id_producto").Value & "'", conn)
                        If ry.RecordCount > 0 Then
                            producto_costo = ry.Fields("costo").Value
                        End If
                        ry.Close()

                        Dim _descripcion As String = dgv_ventas.Rows(x).Cells("descripcion").Value
                        If dgv_ventas.Rows(x).Cells("observaciones").Value <> "Observaciones:" Then
                            If dgv_ventas.Rows(x).Cells("observaciones").Value <> "" Then
                                _descripcion = _descripcion & " (" & dgv_ventas.Rows(x).Cells("observaciones").Value & ")"
                            End If
                        End If

                        conn.Execute("INSERT INTO venta_detalle(id_venta,id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,descuento,importe,modificador,id_producto_modificador)" & _
                                     " VALUES(" & id_venta & "," & dgv_ventas.Rows(x).Cells("id_producto").Value & ",'" & producto_costo & "','" & dgv_ventas.Rows(x).Cells("cantidad").Value & "','" & dgv_ventas.Rows(x).Cells("total_iva").Value & "','" & dgv_ventas.Rows(x).Cells("total_otros").Value & "','" & dgv_ventas.Rows(x).Cells("nombre_impuestos").Value & "','" & dgv_ventas.Rows(x).Cells("precio").Value & "','" & total_impuestos & "','" & _descripcion & "','" & dgv_ventas.Rows(x).Cells("unidad").Value & "','" & dgv_ventas.Rows(x).Cells("id_almacen").Value & "','" & dgv_ventas.Rows(x).Cells("descuento").Value & "','" & dgv_ventas.Rows(x).Cells("importe").Value & "','" & dgv_ventas.Rows(x).Cells("modificador").Value & "','" & dgv_ventas.Rows(x).Cells("id_producto_modificador").Value & "')")

                    Next
                    conn.Execute("INSERT INTO pedido_clientes(id_empleado,fecha_pedido,fecha_entrega,id_cliente,subtotal,total_impuestos,total,id_sucursal,id_venta,comentarios)" & _
                                 " VALUES(" & global_id_empleado & ",NOW(),'" & fecha_entrega & "'," & global_current_idcliente & ",'" & global_subtotal & "','" & global_total_impuestos & "','" & global_total & "','" & global_id_sucursal & "','" & id_venta & "','" & comentarios & "')")

                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_pedido = rs.Fields(0).Value
                    conn.Execute("UPDATE pedido_clientes SET num_ticket=" & id_pedido & " WHERE id_pedido=" & id_pedido)
                    rs.Close()

                    conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")
                    conf_inicio()
                    '=======================================
                    conf_inicio()
                    If pedidos_para_hoy() Then
                        Me.tmr_aviso.Enabled = True
                        Me.tmr_aviso.Start()
                    Else
                        Me.tmr_aviso.Stop()
                        Me.tmr_aviso.Enabled = False
                        Me.tb_aviso_pedidos.Visible = False
                    End If
                    'If MsgBox("A continuación se imprimirá el ticket de pedido. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    'For x = 0 To 1
                    imprimir_ticket_pedido2(id_pedido, 0)
                    'Next
                    'Else
                    'imprimir_ticket_pedido2(id_pedido, 0)
                    ' End If
                Else
                    MsgBox("Seleccione un cliente.La operacion ha sido rechazada")
                End If
            End If
        End If
    End Sub
    Public Sub enviar_como_apartado(ByVal fecha As Date, ByVal hora As DateTime, ByVal comentarios As String)
        If fecha = Today Then
            If MsgBox("Esta seguro que desean enviar el apartado con la fecha de hoy", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
                GoTo A
            End If
        Else
            If MsgBox("Confirme enviar Apartado", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
A:              If global_current_idcliente <> 1 Then
                    Dim id_venta As Integer = 0
                    Dim id_apartado As Integer = 0
                    Dim total_iva As Decimal = 0
                    Dim total_otros As Decimal = 0
                    Dim total_impuestos As Decimal = 0
                    Dim fecha_entrega As String = ""
                    fecha_entrega = Format(fecha, "yyyy-MM-dd") & " " & Format(hora, "HH:mm:ss")
                    'Conectar()


                    conn.Execute("INSERT INTO venta(fecha,id_sucursal,id_empleado,id_cliente,subtotal,total_impuestos,total_descuento,total,desc_global_porcent,desc_global_importe,credito,status) " & _
                                 "VALUES(NOW()," & global_id_sucursal & "," & global_id_empleado & "," & global_current_idcliente & ",'" & global_subtotal & "','" & global_total_impuestos & "','" & global_total_descuento & "','" & global_total & "','" & global_current_descuento_global & "','" & global_current_descuento_global_importe & "','1','PENDIENTE')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_venta = rs.Fields(0).Value
                    conn.Execute("UPDATE venta SET num_ticket=" & id_venta & " WHERE id_venta=" & id_venta)
                    rs.Close()

                    For x = 0 To dgv_ventas.RowCount - 1

                        If CDec(dgv_ventas.Rows(x).Cells("total_iva").Value) > 0 Then
                            total_iva = (CDec(dgv_ventas.Rows(x).Cells("importe").Value) * CDec(dgv_ventas.Rows(x).Cells("total_iva").Value)) / 100
                        End If

                        If CDec(dgv_ventas.Rows(x).Cells("total_iva").Value) > 0 Then
                            total_otros = (CDec(dgv_ventas.Rows(x).Cells("importe").Value) * CDec(dgv_ventas.Rows(x).Cells("total_otros").Value)) / 100
                        End If
                        total_impuestos = total_iva + total_otros

                        Dim ry As New ADODB.Recordset
                        Dim producto_costo As Decimal = 0
                        ry.Open("SELECT costo FROM producto WHERE id_producto='" & dgv_ventas.Rows(x).Cells("id_producto").Value & "'", conn)
                        If ry.RecordCount > 0 Then
                            producto_costo = ry.Fields("costo").Value
                        End If
                        ry.Close()

                        Dim _descripcion As String = dgv_ventas.Rows(x).Cells("descripcion").Value
                        If dgv_ventas.Rows(x).Cells("observaciones").Value <> "Observaciones:" Then
                            If dgv_ventas.Rows(x).Cells("observaciones").Value <> "" Then
                                _descripcion = _descripcion & " (" & dgv_ventas.Rows(x).Cells("observaciones").Value & ")"
                            End If
                        End If

                        conn.Execute("INSERT INTO venta_detalle(id_venta,id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,descuento,importe,modificador,id_producto_modificador)" & _
                                     " VALUES(" & id_venta & "," & dgv_ventas.Rows(x).Cells("id_producto").Value & ",'" & producto_costo & "','" & dgv_ventas.Rows(x).Cells("cantidad").Value & "','" & dgv_ventas.Rows(x).Cells("total_iva").Value & "','" & dgv_ventas.Rows(x).Cells("total_otros").Value & "','" & dgv_ventas.Rows(x).Cells("nombre_impuestos").Value & "','" & dgv_ventas.Rows(x).Cells("precio").Value & "','" & total_impuestos & "','" & _descripcion & "','" & dgv_ventas.Rows(x).Cells("unidad").Value & "','" & dgv_ventas.Rows(x).Cells("id_almacen").Value & "','" & dgv_ventas.Rows(x).Cells("descuento").Value & "','" & dgv_ventas.Rows(x).Cells("importe").Value & "','" & dgv_ventas.Rows(x).Cells("modificador").Value & "','" & dgv_ventas.Rows(x).Cells("id_producto_modificador").Value & "')")
                        '---descontamos y registramos productos compuesto-----
                        'rs.Open("SELECT id_insumo,cantidad,id_tipo_descuento,cantidad_unidad FROM cfg_producto_compuesto WHERE id_producto=" & dgv_ventas.Rows(x).Cells("id_producto").Value, conn)
                        'If rs.RecordCount > 0 Then
                        'While Not rs.EOF
                        'Dim cantidad_insumo As Decimal = 0
                        'If rs.Fields("id_tipo_descuento").Value = 0 Then
                        'cantidad_insumo = (CDec(rs.Fields("cantidad").Value) * CDec(dgv_ventas.Rows(x).Cells("cantidad").Value)) / CDec(rs.Fields("cantidad_unidad").Value)
                        'ElseIf rs.Fields("id_tipo_descuento").Value = 1 Then
                        'cantidad_insumo = CDec(rs.Fields("cantidad").Value)
                        'End If
                        'Dim id_almacen = obtener_idalmacen(rs.Fields("id_insumo").Value)
                        'conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad - " & cantidad_insumo & ") WHERE id_producto=" & rs.Fields("id_insumo").Value & " AND id_almacen=" & id_almacen & "")
                        'conn.Execute("INSERT INTO venta_insumo(id_venta,id_producto,cantidad,id_insumo) VALUES('" & id_venta & "','" & dgv_ventas.Rows(x).Cells("id_producto").Value & "','" & cantidad_insumo & "','" & rs.Fields("id_insumo").Value & "')")
                        'rs.MoveNext()
                        'End While
                        'End If
                        'rs.Close()
                        '-------------------------------- ----------------------
                    Next

                    conn.Execute("INSERT INTO apartado(id_empleado,fecha_apartado,fecha_entrega,id_cliente,subtotal,total_impuestos,total,id_sucursal,id_venta,comentarios)" & _
                                 " VALUES(" & global_id_empleado & ",NOW(),'" & fecha_entrega & "'," & global_current_idcliente & ",'" & global_subtotal & "','" & global_total_impuestos & "','" & global_total & "','" & global_id_sucursal & "','" & id_venta & "','" & comentarios & "')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_apartado = rs.Fields(0).Value
                    rs.Close()
                    conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")
                    conf_inicio()
                    frm_apartado_detalle.cargar_apartado_detalle(id_apartado)
                    frm_apartado_detalle.ShowDialog()
                Else
                    MsgBox("Seleccione un cliente.La operacion ha sido rechazada")
                End If
            End If
        End If
    End Sub
    Private Sub conf_inicio()
        tabla_ventas.Clear()
        global_id_venta_pedido = 0
        global_current_idcliente = 1
        tb_cliente.Text = "PÚBLICO EN GENERAL"
        global_current_precio_especial = 0
        global_current_aplicar_redondeo = obtener_aplicar_redondeo(global_current_idcliente)
        actualizar_totales()
        'seleccionar_ultima_fila()
        global_tipo_operacion = 0
        btn_enviar_venta.Text = "Enviar Venta"
        btn_cancelar_venta.Text = "Borrar Todos"
        Me.BackColor = Color.FromArgb(conf_colores(1))
        tb_tipo.Text = " NUEVA VENTA"

        global_current_descuento_global = 0
        global_current_descuento_global_importe = 0
        tb_codigo_cliente.Text = ""
        ' SE AGREGA LOS PRODUCTOS A LA LISTA_TICKET
    End Sub
    Private Sub devolver_lista_actual()
        Dim cantidad As Decimal
        Dim id_almacen As Integer
        Dim id_producto As Integer
        For x = 0 To dgv_ventas.RowCount - 1
            dgv_ventas.Rows(x).Cells("descuento").Value = 0
            dgv_ventas.Rows(x).Cells("importe_descuento").Value = dgv_ventas.Rows(x).Cells("importe").Value
            cantidad = dgv_ventas.Rows(x).Cells("cantidad").Value
            id_almacen = dgv_ventas.Rows(x).Cells("id_almacen").Value
            id_producto = dgv_ventas.Rows(x).Cells("id_producto").Value
            If id_almacen <> 0 Then
                '--actualizamos la tabla------
                'Conectar()
                conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad +" & cantidad & ") WHERE id_producto='" & id_producto & "' AND id_almacen='" & id_almacen & "'")
                conn.Execute("UPDATE temp_venta_detalle SET id_almacen=0 WHERE id_empleado='" & global_id_empleado & "' AND id_producto='" & id_producto & "' AND id_almacen='" & id_almacen & "'")
                '-----------------------------
                dgv_ventas.Rows(x).Cells("id_almacen").Value = 0
                'conn.close()
                'conn = Nothing
            End If
        Next
    End Sub

    Private Sub btn_ver_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_pedidos_detalle.ShowDialog()
    End Sub

    Private Sub btn_cobrar_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cobrar_venta.Click
        If dgv_ventas.RowCount <= 50 Then
            '--enviamos venta
            'Dim id_venta As Integer = 0
            Dim total_iva As Decimal = 0
            Dim total_otros As Decimal = 0
            Dim total_impuestos As Decimal = 0
            Dim id_venta As Integer

            Dim cliente_publico_alias As String = ""
            If global_current_idcliente = 1 Then
                If Trim(tb_codigo_cliente.Text) <> "" Then
                    cliente_publico_alias = tb_codigo_cliente.Text
                Else
                    cliente_publico_alias = "Publico en General"
                End If
            End If

            'Conectar()
            If global_id_venta_pedido = 0 Then
                conn.Execute("INSERT INTO venta(fecha,id_sucursal,id_empleado,id_cliente,cliente_publico_alias,subtotal,total_impuestos,total_descuento,total,desc_global_porcent,desc_global_importe) " & _
                             "VALUES(NOW()," & global_id_sucursal & "," & global_id_empleado & "," & global_current_idcliente & ",'" & cliente_publico_alias & "','" & global_subtotal & "','" & global_total_impuestos & "','" & global_total_descuento & "','" & global_total & "','" & global_current_descuento_global & "','" & global_current_descuento_global_importe & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_venta = rs.Fields(0).Value
                rs.Close()
            Else
                conn.Execute("UPDATE venta SET fecha=NOW(),id_sucursal='" & global_id_sucursal & "',id_empleado='" & global_id_empleado & "',id_cliente='" & global_current_idcliente & "',subtotal='" & global_subtotal & "',total_impuestos='" & global_total_impuestos & "',total_descuento='" & global_total_descuento & "',total='" & global_total & "',desc_global_porcent='" & global_current_descuento_global & "',status='ABIERTA' WHERE id_venta='" & global_id_venta_pedido & "'")
                id_venta = global_id_venta_pedido
            End If


            For x = 0 To dgv_ventas.RowCount - 1

                conn.Execute("INSERT INTO venta_detalle(id_venta,id_producto,cantidad,total_impuestos,nombre_impuestos,tasa_impuestos,precio,descripcion,unidad,id_almacen,importe,modificador,id_producto_modificador)" & _
                             " VALUES(" & id_venta & "," & dgv_ventas.Rows(x).Cells("id_producto").Value & ",'" & dgv_ventas.Rows(x).Cells("cantidad").Value & "','" & Math.Round(dgv_ventas.Rows(x).Cells("total_impuestos").Value, 2) & "','" & dgv_ventas.Rows(x).Cells("nombre_impuestos").Value & "','" & dgv_ventas.Rows(x).Cells("tasa_impuestos").Value & "','" & dgv_ventas.Rows(x).Cells("precio").Value & "','" & dgv_ventas.Rows(x).Cells("descripcion").Value & "','" & dgv_ventas.Rows(x).Cells("unidad").Value & "','" & dgv_ventas.Rows(x).Cells("id_almacen").Value & "','" & Math.Round(dgv_ventas.Rows(x).Cells("importe").Value, 2) & "','" & dgv_ventas.Rows(x).Cells("modificador").Value & "','" & dgv_ventas.Rows(x).Cells("id_producto_modificador").Value & "')")
                '---descontamos y registramos productos compuesto-----
                rs.Open("SELECT id_insumo,cantidad,id_tipo_descuento,cantidad_unidad FROM cfg_producto_compuesto WHERE id_producto=" & dgv_ventas.Rows(x).Cells("id_producto").Value, conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        Dim cantidad_insumo As Decimal = 0
                        If rs.Fields("id_tipo_descuento").Value = 0 Then
                            cantidad_insumo = (CDec(rs.Fields("cantidad").Value) * CDec(dgv_ventas.Rows(x).Cells("cantidad").Value)) / CDec(rs.Fields("cantidad_unidad").Value)
                        ElseIf rs.Fields("id_tipo_descuento").Value = 1 Then
                            cantidad_insumo = CDec(rs.Fields("cantidad").Value)
                        End If
                        Dim id_almacen = obtener_idalmacen(rs.Fields("id_insumo").Value)
                        conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad - " & cantidad_insumo & ") WHERE id_producto=" & rs.Fields("id_insumo").Value & " AND id_almacen=" & id_almacen & "")
                        conn.Execute("INSERT INTO venta_insumo(id_venta,id_producto,cantidad,id_insumo) VALUES('" & id_venta & "','" & dgv_ventas.Rows(x).Cells("id_producto").Value & "','" & cantidad_insumo & "','" & rs.Fields("id_insumo").Value & "')")
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
                '-------------------------------- ----------------------
            Next

            conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")
          
            If conf_pv(7) = 1 Then
                ' imprimir_ticket_envio_venta(id_venta) 'ENVIAMOS EL TICKET CON EL CODIGO DE BARRA
            End If
            conf_inicio()
            '----
            frm_caja.ShowDialog()
        Else
            MsgBox("No se permite la captura de  mas de 50 lineas de productos por nota de venta", MsgBoxStyle.Exclamation, "Aviso")
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

    Private Sub btn_codigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        If Trim(tb_codigo.TextLength) <> 0 Then
            If Trim(UCase(tb_codigo.Text)) = "K001" Then
                If modo_ajuste_posicion = False Then
                    modo_ajuste_posicion = True
                    Me.BackColor = Color.DarkOrange
                Else
                    modo_ajuste_posicion = False
                    Me.BackColor = Color.FromArgb(conf_colores(1))
                End If
            ElseIf Trim(UCase(tb_codigo.Text)) = "K002" Then
                '   frm_producto2.ShowDialog()
            ElseIf Trim(UCase(tb_codigo.Text)) = "K003" Then
                ' frm_directorio.asignar_cliente = True
                '  frm_directorio.ShowDialog()
            Else
                Dim existe_codigo As Boolean = False
                Dim total_productos As Integer = 0
                Dim venta_peso As Integer = 0

                rs.Open("SELECT id_producto,venta_peso FROM producto WHERE codigo='" & tb_codigo.Text & "'", conn)
                If rs.RecordCount > 0 Then
                    total_productos = rs.RecordCount
                    global_current_idproducto = rs.Fields("id_producto").Value
                    venta_peso = rs.Fields("venta_peso").Value
                    existe_codigo = True
                End If
                rs.Close()

                If existe_codigo = True Then
                    If total_productos > 1 Then
                        frm_producto_busqueda.tb_search.Text = tb_codigo.Text
                        frm_producto_busqueda._modo = 0
                        frm_producto_busqueda.ShowDialog()
                    Else
                        If venta_peso = 1 Then
                            frm_producto_cantidad.modo = 1
                            frm_producto_cantidad.ShowDialog()
                            frm_producto_cantidad.BringToFront()
                        Else
                            If conf_pv(8) = 1 Then ' MOSTRAR SELECTOR DE CANTIDAD
                                frm_producto_cantidad.modo = 1
                                frm_producto_cantidad.ShowDialog()
                                frm_producto_cantidad.BringToFront()
                            Else
                                actualizar_producto(0, global_current_idproducto)
                            End If
                        End If

                    End If

                    Dim WMP As New Global.WMPLib.WindowsMediaPlayer
                    WMP.URL = System.IO.Directory.GetCurrentDirectory() & "/beep-7.wav"
                    WMP.controls.play()

                Else
                    frm_producto_busqueda.tb_search.Text = tb_codigo.Text
                    frm_producto_busqueda._modo = 0
                    frm_producto_busqueda.ShowDialog()
                End If
            End If

            tb_codigo.Text = ""
        End If
        preparar_para_codigo()
    End Sub

    Private Sub dtp_fecha_entrega_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        preparar_para_codigo()
    End Sub

    Private Sub dtp_hora_entrega_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        preparar_para_codigo()
    End Sub
    Public Sub cambiar_precio(ByVal precio As Decimal)

        dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("precio").Value = precio

        dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe").Value = dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("cantidad").Value * dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("precio").Value
        dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("total_impuestos").Value = dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe").Value * dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("tasa_impuestos").Value

        'Conectar()
            If modo_venta = 0 Then
            conn.Execute("UPDATE temp_venta_detalle SET precio='" & precio & "',importe='" & Math.Round(dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe").Value, 2) & "',total_impuestos='" & Math.Round(dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("total_impuestos").Value, 2) & "' WHERE id_temp_venta_detalle='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_temp_venta").Value & "'")
            Else
            conn.Execute("UPDATE orden_comedor_detalle SET precio='" & precio & "',importe='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe").Value & "',total_impuestos='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("total_impuestos").Value & "' WHERE id_orden_comedor_detalle='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_temp_venta").Value & "'")
            End If

        'conn.close()
        'conn = Nothing
        'Dim importe_descuento As Decimal = CDec(dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe").Value) - ((CDec(dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe").Value) * CDec(dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("descuento").Value)) / 100)
        'dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("importe_descuento").Value = importe_descuento 'redondear(math.Round(importe_descuento, 2))

        actualizar_totales()
        ' seleccionar_ultima_fila()

    End Sub

    Private Sub btn_conversiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_conversiones.ShowDialog()
    End Sub

    Private Sub btn_buscar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_producto_busqueda._modo = 0
        frm_producto_busqueda.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_inventario.ShowDialog()
    End Sub
    Private Sub btn_opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_opciones.Click
        Me.Hide()
        frm_botones_terminal.Show()
        frm_botones_terminal.BringToFront()

    End Sub
    Private Sub tmr_aviso_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_aviso.Tick
        If tb_aviso_pedidos.Visible = True Then
            tb_aviso_pedidos.Visible = False
        Else
            tb_aviso_pedidos.Visible = True
        End If
    End Sub
    Private Sub dgv_ventas_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_ventas.CellFormatting

        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular) ' EN LA VERSION ANTERIOR ERA 10
        For x = 0 To dgv_ventas.Columns.Count - 1
            If dgv_ventas.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub btn_modificar_precio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar_precio.Click
        If dgv_ventas.SelectedRows.Count > 0 Then
            If conf_pv(12) = 0 Then
                frm_validaciones.tipo_validacion = 2
                frm_validaciones.ShowDialog()
                frm_validacion.BringToFront()
                'Me.Close()
                'Me.Close()
            Else
                frm_producto_cantidad.modo = 4
                frm_producto_cantidad.ShowDialog()
            End If
        Else
            MsgBox("Seleccione un producto de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If


    End Sub

    Private Sub btn_borrar_producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrar_producto.Click
        If dgv_ventas.SelectedRows.Count > 0 Then
            If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                borrar_linea()
                'Me.Close()
            End If
        Else
            MsgBox("Seleccione un producto de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If
        preparar_para_codigo()
    End Sub

    Private Sub btn_modificar_cantidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_modificar_cantidad.Click
        If dgv_ventas.SelectedRows.Count > 0 Then

            rs.Open("SELECT id_producto,id_almacen from temp_venta_detalle WHERE id_temp_venta_detalle='" & dgv_ventas.Rows(dgv_ventas.CurrentRow.Index).Cells("id_temp_venta").Value & "' AND id_empleado='" & global_id_empleado & "' ORDER BY id_temp_venta_detalle", conn)
            If rs.RecordCount > 0 Then
                global_current_idproducto = rs.Fields("id_producto").Value
            End If
            rs.Close()

            frm_producto_cantidad.modo = 2 'le indicamos que modificara cantidad
            frm_producto_cantidad.ShowDialog()
            frm_producto_cantidad.BringToFront()

            '.Close()
            'Me.Close()

        Else
            MsgBox("Seleccione un producto de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If


    End Sub
    Private Sub frm_principal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        'preparar_para_codigo()
    End Sub

    Private Sub btn_aplicar_descuento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_descuento.Click
        frm_descuentos.ShowDialog()
    End Sub
    Public Sub seleccionar_ultima_fila()
        If dgv_ventas.Rows.Count > 0 Then
            'Scroll to the last row.
            'Me.dgv_ventas.FirstDisplayedScrollingRowIndex = Me.dgv_ventas.RowCount - 1

            'Clear the last selection
            'Me.dgv_ventas.ClearSelection()

            'Select the last row.
            'Me.dgv_ventas.Rows(Me.dgv_ventas.RowCount - 1).Selected = True
        End If
    End Sub
    Private Sub gb_productos_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles gb_productos.MouseHover, gb_categorias.MouseHover, gb_venta.MouseHover, GroupBox3.MouseHover, lbl_descuento.MouseHover, btn_almacen.MouseHover, btn_aplicar_descuento.MouseHover, btn_borrar_producto.MouseHover, btn_cancelar_venta.MouseHover, btn_cobrar_venta.MouseHover, btn_enviar_venta.MouseHover, btn_modificar_cantidad.MouseHover, btn_modificar_precio.MouseHover, btn_opciones.MouseHover, categoria1.MouseHover, categoria10.MouseHover, categoria2.MouseHover, categoria3.MouseHover, categoria4.MouseHover, categoria5.MouseHover, categoria6.MouseHover, categoria7.MouseHover, categoria8.MouseHover, categoria9.MouseHover, dgv_ventas.MouseHover, btn_buscar.MouseHover, btn_procesar.MouseHover, Label5.MouseHover
        lb_nombre_producto.Visible = False
    End Sub
    Private Sub lst_productos_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If dgv_ventas.SelectedRows.Count > 0 Then
            btn_borrar_producto.Enabled = True
            btn_modificar_cantidad.Enabled = True
            btn_modificar_precio.Enabled = True
        Else
            btn_borrar_producto.Enabled = False
            btn_modificar_cantidad.Enabled = False
            btn_modificar_precio.Enabled = False
        End If

        Dim toolTip1 As New ToolTip()

        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 1000
        toolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = True

        ' Set up the ToolTip text for the Button and Checkbox.
        ' toolTip1.SetToolTip(Me.lst_productos, "My button1")
        'toolTip1.SetToolTip(Me.btn_cobrar_venta, "My checkBox1")
        'preparar_para_codigo()

    End Sub

    Private Sub tb_aviso_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_aviso_pedidos.Click
        If global_usuario_ver_pedidos = 1 Then
            frm_pedidos_clientes.ShowDialog()
            frm_pedidos_clientes.BringToFront()
        Else
            MsgBox("Usted no tiene permiso para ver pedido", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub

    Private Sub trm_preparar_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trm_preparar.Tick
        If tb_codigo_cliente.Focused = False And dgv_ventas.SelectedRows.Count = 0 And dragging = False And inactiveTime.TotalSeconds < 1 And global_frm_producto = 0 And global_frm_directorio = 0 And global_frm_compras = 0 And Trim(tb_codigo.Text) = "" Then
            preparar_para_codigo()
        End If
        If dgv_ventas.Focused = True And inactiveTime.TotalSeconds > 2 Then
            preparar_para_codigo()
        End If

    End Sub

    Private Sub tb_codigo_cliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_codigo_cliente.Click
        no_campo = 2
    End Sub

    Private Sub tb_codigo_cliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_codigo_cliente.KeyDown
        If e.KeyCode = 113 Then
            Me.Hide()
            frm_usuarios.Show()
        ElseIf e.KeyCode = 114 Then
            frm_producto_busqueda._modo = 0
            frm_producto_busqueda.ShowDialog()
        ElseIf e.KeyCode = 115 Then
            If global_cobro_terminal = 1 Then
                frm_retiros_deposito.ShowDialog()
            Else
                MsgBox("No tiene permiso para realizar_retiros", MsgBoxStyle.Exclamation, "Aviso")
            End If
        ElseIf e.KeyCode = 116 Then
            If dgv_ventas.Rows.Count > 0 Then
                If global_cobro_terminal = 1 Then
                    btn_cobrar_venta_Click(sender, e)
                Else
                    MsgBox("No tiene permiso para cobrar esta venta", MsgBoxStyle.Exclamation, "Aviso")
                End If
            End If
        ElseIf e.KeyCode = 117 Then
            If dgv_ventas.Rows.Count > 0 Then
                btn_enviar_venta_Click(sender, e)
            End If
        ElseIf e.KeyCode = 118 Then
            btn_pedido_Click(sender, e)
        ElseIf e.KeyCode = 119 Then
            frm_validacion.validacion = 2
            frm_validacion.ShowDialog()
        ElseIf e.KeyCode = 120 Then
            frm_facturacion.ShowDialog()
        ElseIf e.KeyCode = 121 Then
            frm_clientes.ShowDialog()
        ElseIf e.KeyCode = 122 Then
            If global_cobro_terminal = 1 Then
                frm_caja.ShowDialog()
            Else
                MsgBox("No tiene permiso para ver la caja", MsgBoxStyle.Exclamation, "Aviso")
            End If
        ElseIf e.KeyCode = 123 Then
            frm_seleccionar_almacen.ShowDialog()
        ElseIf e.KeyCode = 46 Then
            If dgv_ventas.Rows.Count > 0 Then
                If dgv_ventas.SelectedRows.Count > 0 Then
                    btn_borrar_producto_Click(sender, e)
                End If
                If dgv_ventas.SelectedRows.Count > 0 Then
                    btn_borrar_producto_Click(sender, e)
                End If
            End If
        ElseIf e.KeyCode = 13 Then
            btn_cliente_Click(sender, e)
        ElseIf e.KeyCode = 40 Then 'abajo
            dgv_ventas.Select()

        End If
    End Sub
    Public Sub verificar_precio_especial(ByVal id_cliente As Integer)

        current_catalogo_precio = 0
        Dim autorizacion As Integer = 0
        id_cliente_encontrado = id_cliente
        'Conectar()
        rs.Open("SELECT * FROM cliente_precio WHERE id_cliente=" & id_cliente, conn)
        If rs.RecordCount > 0 Then
            current_catalogo_precio = rs.Fields("id_catalogo_precio").Value
            autorizacion = rs.Fields("autorizacion").Value
            If rs.Fields("aplicar_redondeo").Value = 1 Then
                global_current_aplicar_redondeo = True
            Else
                global_current_aplicar_redondeo = False
            End If
        End If
        rs.Close()
        If autorizacion = 1 Then
            frm_validaciones.origen_validacion_cliente = 1
            frm_validaciones.tipo_validacion = 1 '--validacion de precio especial
            frm_validaciones.ShowDialog()
            frm_validaciones.BringToFront()
        Else
            cargar_cliente()
        End If
    End Sub
    Public Sub cargar_cliente()

        global_current_idcliente = id_cliente_encontrado
        rs.Open("SELECT cliente.id_cliente,cliente.clave,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre,cliente.clave FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & id_cliente_encontrado & "'", conn)
        If rs.RecordCount > 0 Then

            Me.tb_cliente.Text = rs.Fields("clave").Value & ".- " & rs.Fields("nombre").Value


        End If
        rs.Close()

        global_current_precio_especial = current_catalogo_precio

        If tabla_ventas.Rows.Count > 0 Then
            '.actualizamos los precios de la lista

            Me.actualizar_precios_lista()

        End If
        'Me.Hide()

        '---cargamos los productos del cliente
        Dim precio As Decimal
        Dim total_iva As Decimal
        Dim importe As Decimal = 0
        Dim total_impuestos As Decimal = 0
        Dim correcto As Boolean = True
        Dim cadena As String = "Se encontraron los siguientes errores" & vbCrLf
        'Conectar()
        Dim _rs As New ADODB.Recordset
        _rs.Open("SELECT p.id_producto,p.nombre,u.nombre_corto AS unidad,cp.cantidad, i.nombre AS nombre_impuesto, i.tasa AS tasa_impuesto " & _
                    "FROM cliente_productos cp " & _
                    "JOIN producto p ON p.id_producto=cp.id_producto " & _
                    "JOIN unidad u ON p.id_unidad=u.id_unidad " & _
                    "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                    "WHERE id_cliente= " & id_cliente_encontrado, conn)
        If _rs.RecordCount > 0 Then

            While Not _rs.EOF
                'MsgBox(conf_pv(2))
                Dim id_producto As Integer = _rs.Fields("id_producto").Value
                Dim descripcion As String = _rs.Fields("nombre").Value
                Dim unidad As String = _rs.Fields("unidad").Value
                Dim cantidad As String = _rs.Fields("cantidad").Value
                Dim nombre_impuesto As String = _rs.Fields("nombre_impuesto").Value
                Dim tasa_impuesto As String = _rs.Fields("tasa_impuesto").Value

                If global_tipo_operacion = 0 Then
                    Dim stock As Decimal = validar_existencia_producto(id_producto, global_current_idalmacen, 1)
                    If stock >= cantidad Then
_CANTIDADES_NEGATIVAS:  

                        Dim foundRows() As Data.DataRow = tabla_ventas.Select("id_producto = " & id_producto)
                        If foundRows.Length > 0 Then
                            If conf_pv(2) = 1 Then
                                GoTo _AGREGAR_PC
                            Else
                                cadena = cadena & "   " & descripcion & " ya se encuentra en la lista" & vbCrLf
                                correcto = False
                            End If
                        Else
_AGREGAR_PC:


                            precio = obtener_precio_producto(id_producto, global_current_precio_especial) / (1 + tasa_impuesto)
                            importe = precio * cantidad
                            total_impuestos = importe * tasa_impuesto

                            conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,cantidad,precio,importe,total_impuestos,nombre_impuestos,tasa_impuesto,tasa_impuestos,id_cliente,id_almacen,desc_global_porcent) " & _
                                            "VALUES(" & global_id_empleado & "," & id_producto & ",'" & cantidad & "','" & precio & "','" & Math.Round(importe, 2) & "','" & Math.Round(total_impuestos, 2) & "','" & nombre_impuesto & "','" & tasa_impuesto & "','" & global_current_idcliente & "','" & global_current_idalmacen & "','" & global_current_descuento_global & "')")

                            Dim id_temp_venta As Integer = 0
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_temp_venta = rs.Fields(0).Value
                            rs.Close()

                            conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & cantidad & ") WHERE id_producto='" & id_producto & "' AND id_almacen='" & global_current_idalmacen & "'")
                            agregar_producto(id_producto, descripcion, cantidad, unidad, total_impuestos, precio, importe, global_current_idalmacen, nombre_impuesto, tasa_impuesto, id_temp_venta, 0, 0)
                        End If
                    Else
                        If conf_pv(3) = 1 Then
                            GoTo _CANTIDADES_NEGATIVAS
                        Else
                            cadena = cadena & "   NO se puede surtir " & descripcion & " no hay unidades suficientes en este almacen" & vbCrLf
                            correcto = False
                        End If
                    End If
                Else

                    Dim foundRows() As Data.DataRow = tabla_ventas.Select("id_producto = " & id_producto)
                    If foundRows.Length > 0 Then
                        If conf_pv(2) = 1 Then
                            GoTo AGREGAR_PC2
                        Else
                            cadena = cadena & "   " & descripcion & " ya se encuentra en la lista" & vbCrLf
                            correcto = False
                        End If

                    Else

                        precio = obtener_precio_producto(id_producto, global_current_precio_especial) / (1 + tasa_impuesto)
                        importe = precio * cantidad
                        total_impuestos = importe * tasa_impuesto
AGREGAR_PC2:
                        conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,cantidad,precio,importe,total_impuestos,nombre_impuestos,tasa_impuestos,id_cliente,id_almacen,desc_global_porcent) " & _
                                           "VALUES(" & global_id_empleado & "," & id_producto & ",'" & cantidad & "','" & precio & "','" & Math.Round(importe, 2) & "','" & Math.Round(total_impuestos, 2) & "','" & nombre_impuesto & "','" & tasa_impuesto & "','" & global_current_idcliente & "','" & global_current_idalmacen & "','" & global_current_descuento_global & "')")

                        Dim rx As New ADODB.Recordset
                        Dim id_temp_venta As Integer = 0
                        rx.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_temp_venta = rx.Fields(0).Value
                        rx.Close()

                        agregar_producto(id_producto, descripcion, cantidad, unidad, total_impuestos, precio, importe, global_current_idalmacen, nombre_impuesto, tasa_impuesto, id_temp_venta, 0, 0)

                    End If

                End If

                _rs.MoveNext()
            End While

        End If

        _rs.Close()
        If correcto = False Then
            MsgBox(cadena)
        End If
    End Sub
    Private Sub producto1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles producto1.MouseMove, producto2.MouseMove, producto3.MouseMove, producto4.MouseMove, producto5.MouseMove, producto6.MouseMove, producto7.MouseMove, producto8.MouseMove, producto9.MouseMove, producto10.MouseMove, producto11.MouseMove, producto12.MouseMove, producto13.MouseMove, producto14.MouseMove, producto15.MouseMove, producto16.MouseMove, producto17.MouseMove, producto18.MouseMove, producto19.MouseMove, producto20.MouseMove
        If modo_ajuste_posicion = True Then
            If dragging = True Then
                CType(sender, Button).BringToFront()
                CType(sender, Button).Location = New Point(CType(sender, Button).Location.X + e.X - posicionX, CType(sender, Button).Location.Y + e.Y - posicionY)
                Me.Refresh()
                Dim posicion As Integer = buscar_posicion(CType(sender, Button).Location.X + e.X - posicionX, CType(sender, Button).Location.Y + e.Y - posicionY)
                cambiar_color_etiqueta(posicion)
            End If
        End If

    End Sub

    Private Sub producto1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles producto1.MouseUp, producto2.MouseUp, producto3.MouseUp, producto4.MouseUp, producto5.MouseUp, producto6.MouseUp, producto7.MouseUp, producto8.MouseUp, producto9.MouseUp, producto10.MouseUp, producto11.MouseUp, producto12.MouseUp, producto13.MouseUp, producto14.MouseUp, producto15.MouseUp, producto16.MouseUp, producto17.MouseUp, producto18.MouseUp, producto19.MouseUp, producto20.MouseUp
        If modo_ajuste_posicion = True Then
            dragging = False
            Dim posicion_origen As Integer = CType(sender, Button).TabIndex + 1
            Dim posicion_destino As Integer = buscar_posicion(CType(sender, Button).Location.X, CType(sender, Button).Location.Y)

            Dim id_producto_origen As Integer
            Dim id_producto_destino As Integer
            If posicion_origen <> posicion_destino Then
                If posicion_destino <> 0 And posicion_origen <> 0 Then
                    If global_current_tabindex_categoria = 0 Then
                        id_producto_origen = favoritos(posicion_origen - 1, 0)
                        id_producto_destino = favoritos(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 1 Then
                        id_producto_origen = cat1(posicion_origen - 1, 0)
                        id_producto_destino = cat1(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 2 Then
                        id_producto_origen = cat2(posicion_origen - 1, 0)
                        id_producto_destino = cat2(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 3 Then
                        id_producto_origen = cat3(posicion_origen - 1, 0)
                        id_producto_destino = cat3(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 4 Then
                        id_producto_origen = cat4(posicion_origen - 1, 0)
                        id_producto_destino = cat4(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 5 Then
                        id_producto_origen = cat5(posicion_origen - 1, 0)
                        id_producto_destino = cat5(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 6 Then
                        id_producto_origen = cat6(posicion_origen - 1, 0)
                        id_producto_destino = cat6(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 7 Then
                        id_producto_origen = cat7(posicion_origen - 1, 0)
                        id_producto_destino = cat7(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 8 Then
                        id_producto_origen = cat8(posicion_origen - 1, 0)
                        id_producto_destino = cat8(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 9 Then
                        id_producto_origen = cat9(posicion_origen - 1, 0)
                        id_producto_destino = cat9(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 10 Then
                        id_producto_origen = cat10(posicion_origen - 1, 0)
                        id_producto_destino = cat10(posicion_destino - 1, 0)
                    ElseIf global_current_tabindex_categoria = 11 Then
                        id_producto_origen = cat11(posicion_origen - 1, 0)
                        id_producto_destino = cat11(posicion_destino - 1, 0)
                    End If

                    If global_current_tabindex_categoria = 0 Then
                        conn.Execute("UPDATE producto SET favorito='" & posicion_destino & "' WHERE id_producto='" & id_producto_origen & "'")
                        If id_producto_destino = 0 Then
                            conn.Execute("UPDATE producto SET favorito='0' WHERE id_producto='" & id_producto_origen & "'")
                        Else
                            conn.Execute("UPDATE producto SET favorito='" & posicion_origen & "' WHERE id_producto='" & id_producto_destino & "'")
                        End If
                    Else
                        conn.Execute("UPDATE producto SET favorito_cat='" & posicion_destino & "' WHERE id_producto='" & id_producto_origen & "'")
                        If id_producto_destino = 0 Then
                            conn.Execute("UPDATE producto SET favorito_cat='0' WHERE id_producto='" & id_producto_origen & "'")
                        Else
                            conn.Execute("UPDATE producto SET favorito_cat='" & posicion_origen & "' WHERE id_producto='" & id_producto_destino & "'")
                        End If
                    End If
                    restablecer_posicion(posicion_origen)
                    cargar_matriz(global_current_tabindex_categoria)
                End If
            End If
        End If

    End Sub
    Private Function buscar_posicion(ByVal x As Integer, ByVal y As Integer) As Integer
        Dim posicion As Integer
        If Math.Abs(position_buttons(1, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(1, 1) - y) <= 50 Then
                posicion = 1
            End If
        End If
        If Math.Abs(position_buttons(2, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(2, 1) - y) <= 50 Then
                posicion = 2
            End If
        End If
        If Math.Abs(position_buttons(3, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(3, 1) - y) <= 50 Then
                posicion = 3
            End If
        End If
        If Math.Abs(position_buttons(4, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(4, 1) - y) <= 50 Then
                posicion = 4
            End If
        End If
        If Math.Abs(position_buttons(5, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(5, 1) - y) <= 50 Then
                posicion = 5
            End If
        End If
        If Math.Abs(position_buttons(6, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(6, 1) - y) <= 50 Then
                posicion = 6
            End If
        End If
        If Math.Abs(position_buttons(7, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(7, 1) - y) <= 50 Then
                posicion = 7
            End If
        End If
        If Math.Abs(position_buttons(8, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(8, 1) - y) <= 30 Then
                posicion = 8
            End If
        End If
        If Math.Abs(position_buttons(9, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(9, 1) - y) <= 50 Then
                posicion = 9
            End If
        End If
        If Math.Abs(position_buttons(10, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(10, 1) - y) <= 30 Then
                posicion = 10
            End If
        End If
        If Math.Abs(position_buttons(11, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(11, 1) - y) <= 50 Then
                posicion = 11
            End If
        End If
        If Math.Abs(position_buttons(12, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(12, 1) - y) <= 50 Then
                posicion = 12
            End If
        End If
        If Math.Abs(position_buttons(13, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(13, 1) - y) <= 50 Then
                posicion = 13
            End If
        End If
        If Math.Abs(position_buttons(14, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(14, 1) - y) <= 50 Then
                posicion = 14
            End If
        End If
        If Math.Abs(position_buttons(15, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(15, 1) - y) <= 50 Then
                posicion = 15
            End If
        End If
        If Math.Abs(position_buttons(16, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(16, 1) - y) <= 30 Then
                posicion = 16
            End If
        End If
        If Math.Abs(position_buttons(17, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(17, 1) - y) <= 30 Then
                posicion = 17
            End If
        End If
        If Math.Abs(position_buttons(18, 0) - x) <= 30 Then
            If Math.Abs(position_buttons(18, 1) - y) <= 10 Then
                posicion = 18
            End If
        End If
        If Math.Abs(position_buttons(19, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(19, 1) - y) <= 50 Then
                posicion = 19
            End If
        End If
        If Math.Abs(position_buttons(20, 0) - x) <= 50 Then
            If Math.Abs(position_buttons(20, 1) - y) <= 50 Then
                posicion = 20
            End If
        End If

        Return posicion

    End Function
    Private Sub restablecer_posicion(ByVal posicion As Integer)
        If posicion = 1 Then
            producto1.Location = New Point(position_buttons(1, 0), position_buttons(1, 1))
        ElseIf posicion = 2 Then
            producto2.Location = New Point(position_buttons(2, 0), position_buttons(2, 1))
        ElseIf posicion = 3 Then
            producto3.Location = New Point(position_buttons(3, 0), position_buttons(3, 1))
        ElseIf posicion = 4 Then
            producto4.Location = New Point(position_buttons(4, 0), position_buttons(4, 1))
        ElseIf posicion = 5 Then
            producto5.Location = New Point(position_buttons(5, 0), position_buttons(5, 1))
        ElseIf posicion = 6 Then
            producto6.Location = New Point(position_buttons(6, 0), position_buttons(6, 1))
        ElseIf posicion = 7 Then
            producto7.Location = New Point(position_buttons(7, 0), position_buttons(7, 1))
        ElseIf posicion = 8 Then
            producto8.Location = New Point(position_buttons(8, 0), position_buttons(8, 1))
        ElseIf posicion = 9 Then
            producto9.Location = New Point(position_buttons(9, 0), position_buttons(9, 1))
        ElseIf posicion = 10 Then
            producto10.Location = New Point(position_buttons(10, 0), position_buttons(10, 1))
        ElseIf posicion = 11 Then
            producto11.Location = New Point(position_buttons(11, 0), position_buttons(11, 1))
        ElseIf posicion = 12 Then
            producto12.Location = New Point(position_buttons(12, 0), position_buttons(12, 1))
        ElseIf posicion = 13 Then
            producto13.Location = New Point(position_buttons(13, 0), position_buttons(13, 1))
        ElseIf posicion = 14 Then
            producto14.Location = New Point(position_buttons(14, 0), position_buttons(14, 1))
        ElseIf posicion = 15 Then
            producto15.Location = New Point(position_buttons(15, 0), position_buttons(15, 1))
        ElseIf posicion = 16 Then
            producto16.Location = New Point(position_buttons(16, 0), position_buttons(16, 1))
        ElseIf posicion = 17 Then
            producto17.Location = New Point(position_buttons(17, 0), position_buttons(17, 1))
        ElseIf posicion = 18 Then
            producto18.Location = New Point(position_buttons(18, 0), position_buttons(18, 1))
        ElseIf posicion = 19 Then
            producto19.Location = New Point(position_buttons(19, 0), position_buttons(19, 1))
        ElseIf posicion = 20 Then
            producto20.Location = New Point(position_buttons(20, 0), position_buttons(20, 1))
        End If

    End Sub
    Private Sub cambiar_color_etiqueta(ByVal posicion As Integer)
        FavLb1.BackColor = Color.FromArgb(128, Color.Black)
        FavLb2.BackColor = Color.FromArgb(128, Color.Black)
        FavLb3.BackColor = Color.FromArgb(128, Color.Black)
        FavLb4.BackColor = Color.FromArgb(128, Color.Black)
        FavLb5.BackColor = Color.FromArgb(128, Color.Black)
        FavLb6.BackColor = Color.FromArgb(128, Color.Black)
        FavLb7.BackColor = Color.FromArgb(128, Color.Black)
        FavLb8.BackColor = Color.FromArgb(128, Color.Black)
        FavLb9.BackColor = Color.FromArgb(128, Color.Black)
        FavLb10.BackColor = Color.FromArgb(128, Color.Black)
        FavLb11.BackColor = Color.FromArgb(128, Color.Black)
        FavLb12.BackColor = Color.FromArgb(128, Color.Black)
        FavLb13.BackColor = Color.FromArgb(128, Color.Black)
        FavLb14.BackColor = Color.FromArgb(128, Color.Black)
        FavLb15.BackColor = Color.FromArgb(128, Color.Black)
        FavLb16.BackColor = Color.FromArgb(128, Color.Black)
        FavLb17.BackColor = Color.FromArgb(128, Color.Black)
        FavLb18.BackColor = Color.FromArgb(128, Color.Black)
        FavLb19.BackColor = Color.FromArgb(128, Color.Black)
        FavLb20.BackColor = Color.FromArgb(128, Color.Black)



        If posicion = 1 Then
            FavLb1.BackColor = Color.DarkBlue
        ElseIf posicion = 2 Then
            FavLb2.BackColor = Color.DarkBlue
        ElseIf posicion = 3 Then
            FavLb3.BackColor = Color.DarkBlue
        ElseIf posicion = 4 Then
            FavLb4.BackColor = Color.DarkBlue
        ElseIf posicion = 5 Then
            FavLb5.BackColor = Color.DarkBlue
        ElseIf posicion = 6 Then
            FavLb6.BackColor = Color.DarkBlue
        ElseIf posicion = 7 Then
            FavLb7.BackColor = Color.DarkBlue
        ElseIf posicion = 8 Then
            FavLb8.BackColor = Color.DarkBlue
        ElseIf posicion = 9 Then
            FavLb9.BackColor = Color.DarkBlue
        ElseIf posicion = 10 Then
            FavLb10.BackColor = Color.DarkBlue
        ElseIf posicion = 11 Then
            FavLb11.BackColor = Color.DarkBlue
        ElseIf posicion = 12 Then
            FavLb12.BackColor = Color.DarkBlue
        ElseIf posicion = 13 Then
            FavLb13.BackColor = Color.DarkBlue
        ElseIf posicion = 14 Then
            FavLb14.BackColor = Color.DarkBlue
        ElseIf posicion = 15 Then
            FavLb15.BackColor = Color.DarkBlue
        ElseIf posicion = 16 Then
            FavLb16.BackColor = Color.DarkBlue
        ElseIf posicion = 17 Then
            FavLb17.BackColor = Color.DarkBlue
        ElseIf posicion = 18 Then
            FavLb18.BackColor = Color.DarkBlue
        ElseIf posicion = 19 Then
            FavLb19.BackColor = Color.DarkBlue
        ElseIf posicion = 20 Then
            FavLb20.BackColor = Color.DarkBlue
        End If

    End Sub

    Private Sub tiempo_inactivo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo_inactivo.Tick
        If global_frm_principal3 = 1 Then
            inactiveTime = _inactiveTimeRetriever.GetInactiveTime
        End If

    End Sub

    Private Sub gb_venta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gb_venta.Enter

    End Sub

    Private Sub btn_cat_sig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cat_sig.Click
        pagina_categoria = pagina_categoria + 1
        cargar_categorias(pagina_categoria)
        cambiar_index_categoria()
        If pagina_categoria > 1 Then
            btn_cat_ant.Visible = True
        Else
            btn_cat_ant.Visible = False
        End If
    End Sub

    Private Sub btn_cat_ant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cat_ant.Click
        pagina_categoria = pagina_categoria - 1
        cargar_categorias(pagina_categoria)
        cambiar_index_categoria()
        If pagina_categoria > 1 Then
            btn_cat_ant.Visible = True
        Else
            btn_cat_ant.Visible = False
        End If
    End Sub
    Private Sub cambiar_index_categoria()
        categoria2.TabIndex = 1 + (9 * (pagina_categoria - 1))
        categoria3.TabIndex = 2 + (9 * (pagina_categoria - 1))
        categoria4.TabIndex = 3 + (9 * (pagina_categoria - 1))
        categoria5.TabIndex = 4 + (9 * (pagina_categoria - 1))
        categoria6.TabIndex = 5 + (9 * (pagina_categoria - 1))
        categoria7.TabIndex = 6 + (9 * (pagina_categoria - 1))
        categoria8.TabIndex = 7 + (9 * (pagina_categoria - 1))
        categoria9.TabIndex = 8 + (9 * (pagina_categoria - 1))
        categoria10.TabIndex = 9 + (9 * (pagina_categoria - 1))
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TypeOf sender Is Button Then
            If TypeOf sender Is Button Then
                If no_campo = 1 Then
                    tb_codigo.Focus()
                    SendKeys.Send(CType(sender, Button).Text)
                ElseIf no_campo = 2 Then
                    tb_codigo_cliente.Focus()
                    SendKeys.Send(CType(sender, Button).Text)
                End If
            End If
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If no_campo = 1 Then
            tb_codigo.Text = ""
        ElseIf no_campo = 2 Then
            tb_codigo_cliente.Text = ""
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If no_campo = 1 Then
            If tb_codigo.TextLength > 0 Then
                tb_codigo.Text = tb_codigo.Text.Remove(tb_codigo.TextLength - 1, 1)
                tb_codigo.SelectionStart = Len(tb_codigo.Text)
            End If
        ElseIf no_campo = 2 Then
            If tb_codigo_cliente.TextLength > 0 Then
                tb_codigo_cliente.Text = tb_codigo_cliente.Text.Remove(tb_codigo_cliente.TextLength - 1, 1)
                tb_codigo_cliente.SelectionStart = Len(tb_codigo_cliente.Text)
            End If
        End If
    End Sub

    Private Sub tb_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cliente.Click

    End Sub

    Private Sub lst_productos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_punto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_buscar.MouseUp, btn_cat_ant.MouseUp, btn_cat_sig.MouseUp, categoria1.MouseUp, categoria2.MouseUp, categoria3.MouseUp, categoria4.MouseUp, categoria5.MouseUp, categoria5.MouseUp, categoria6.MouseUp, categoria7.MouseUp, categoria8.MouseUp, categoria9.MouseUp, categoria10.MouseUp
        If TypeOf sender Is Button Then
            sender.backcolor = Color.FromArgb(conf_colores(8))
        End If
    End Sub

    Private Sub btn_punto_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_buscar.MouseDown, btn_cat_ant.MouseDown, btn_cat_sig.MouseDown, categoria1.MouseDown, categoria2.MouseDown, categoria3.MouseDown, categoria4.MouseDown, categoria5.MouseDown, categoria5.MouseDown, categoria6.MouseDown, categoria7.MouseDown, categoria8.MouseDown, categoria9.MouseDown, categoria10.MouseDown
        If TypeOf sender Is Button Then
            sender.backcolor = Color.FromArgb(conf_colores(1))
        End If
    End Sub

    Private Sub btn_codigo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If no_campo = 1 Then
            btn_buscar_producto_Click(sender, e)
        ElseIf no_campo = 2 Then
            btn_cliente_Click(sender, e)
        End If
    End Sub

    Private Sub tmr_fecha_hora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_fecha_hora.Tick
        'lb_fecha.Text = UCase(Now.ToLongDateString) & ", " & UCase(Now.ToLongTimeString)
    End Sub

    Private Sub btn_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pedido.Click
        If global_tipo_operacion = 0 Or global_tipo_operacion = 2 Then
            If tabla_ventas.Rows.Count > 0 Then
                If MsgBox("Desea convertir esta venta a pedido, esta operacion no se puede revertir? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    GoTo CONVERTIR_A_PEDIDO
                End If
            Else
CONVERTIR_A_PEDIDO: global_tipo_operacion = 1

                btn_enviar_venta.Text = "Enviar Pedido"



                btn_cancelar_venta.Text = "Borrar Todos"
                btn_cobrar_venta.Enabled = False


                tb_tipo.Text = "NUEVO PEDIDO"

                Me.BackColor = Color.FromArgb(conf_colores(23))
                devolver_lista_actual()
                preparar_para_codigo()
                If global_current_idcliente = 1 Then
                    frm_clientes.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub btn_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_venta.Click
        If global_tipo_operacion = 1 Or global_tipo_operacion = 2 Then
            If MsgBox("Esta seguro de cancelar esta operacion? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()

                global_tipo_operacion = 0
                conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & global_id_empleado & "'")

                btn_enviar_venta.Text = "Enviar"

                btn_cobrar_venta.Enabled = True

                tb_tipo.Text = "NUEVA VENTA"

                Me.BackColor = Color.FromArgb(conf_colores(1))
                devolver_lista_actual()
                preparar_para_codigo()
                tabla_ventas.Clear()
                actualizar_totales()
                'conn.close()
                'conn = Nothing
                ' conf_inicio()
            End If
        End If
    End Sub

    Private Sub btn_apartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_apartado.Click
        If global_tipo_operacion = 0 Or global_tipo_operacion = 1 Then
            If tabla_ventas.Rows.Count > 0 Then
                If MsgBox("Desea convertir esta venta en apartado, esta operacion no se puede revertir? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    GoTo CONVERTIR_A_APARTADO
                End If
            Else
CONVERTIR_A_APARTADO: global_tipo_operacion = 2

                btn_enviar_venta.Text = "Enviar Apartado"

                btn_cancelar_venta.Text = "Borrar Todos"
                btn_cobrar_venta.Enabled = False
                tb_tipo.Text = "NUEVO APARTADO"
                Me.BackColor = Color.FromArgb(conf_colores(28))
                devolver_lista_actual()
                preparar_para_codigo()
                If global_current_idcliente = 1 Then
                    frm_clientes.ShowDialog()
                End If
            End If

        End If
    End Sub
    Private Sub btn_procesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_procesar.Click
        Me.Hide()
        frm_comedor.cargar_orden(frm_comedor.current_id_orden_comedor)
        frm_comedor.BringToFront()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Hide()
        frm_botones_terminal.Show()
        frm_botones_terminal.BringToFront()
    End Sub
    Public Sub actualizar_producto(ByVal cantidad As Decimal, Optional ByVal id_producto As Integer = 0)

        Dim rx As New ADODB.Recordset
        Dim precio As Decimal = 0
        Dim importe As Decimal = 0
        Dim total_impuestos As Decimal = 0
        Dim nombre_impuestos As String = ""
        Dim tasa_impuesto As Decimal = 0
        Dim id_temp_venta As Integer
        Dim producto_nombre As String = ""
        Dim producto_unidad As String = ""


        Dim foundRows() As Data.DataRow = tabla_ventas.Select("id_producto = " & global_current_idproducto)

        If foundRows.Length > 0 Then
            If cantidad = 0 Then
                '============incrementamos el producto en 1
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
                foundRows(0).Item("importe") = foundRows(0).Item("precio") * foundRows(0).Item("cantidad")
                foundRows(0).Item("total_impuestos") = foundRows(0).Item("importe") * foundRows(0).Item("tasa_impuestos")
                conn.Execute("UPDATE temp_venta_detalle SET cantidad='" & foundRows(0).Item("cantidad") & "',importe='" & Math.Round(foundRows(0).Item("importe"), 2) & "', total_impuestos='" & Math.Round(foundRows(0).Item("total_impuestos"), 2) & "' WHERE id_temp_venta_detalle='" & foundRows(0).Item("id_temp_venta") & "'")
            Else
                '============' actualizamos a la cantidad indicada=================
                foundRows(0).Item("cantidad") = cantidad
                foundRows(0).Item("importe") = foundRows(0).Item("precio") * foundRows(0).Item("cantidad")
                foundRows(0).Item("total_impuestos") = foundRows(0).Item("importe") * foundRows(0).Item("tasa_impuestos")
                conn.Execute("UPDATE temp_venta_detalle SET cantidad='" & foundRows(0).Item("cantidad") & "',importe='" & Math.Round(foundRows(0).Item("importe"), 2) & "', total_impuestos='" & Math.Round(foundRows(0).Item("total_impuestos"), 2) & "' WHERE id_temp_venta_detalle='" & foundRows(0).Item("id_temp_venta") & "'")
            End If
        Else
            '====nuevo linea============
            If cantidad = 0 Then
                cantidad = 1
            End If
            Dim espaquete As Boolean = verificar_producto_paquete(global_current_idproducto)
_ENVIAR:
            Dim stock As Decimal = validar_existencia_producto(global_current_idproducto, global_current_idalmacen)

            If stock >= cantidad Then
NUEVA_LINEA:
                rx.Open("SELECT p.nombre AS producto,i.nombre AS nombre_impuesto, i.tasa AS tasa_impuesto, u.nombre_corto AS unidad " & _
                        "FROM producto p " & _
                        "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                        "Join unidad u ON u.id_unidad=p.id_unidad " & _
                        "WHERE p.id_producto=" & global_current_idproducto, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rx.RecordCount > 0 Then
                    nombre_impuestos = rx.Fields("nombre_impuesto").Value
                    tasa_impuesto = rx.Fields("tasa_impuesto").Value
                    producto_nombre = rx.Fields("producto").Value
                    producto_unidad = rx.Fields("unidad").Value
                    producto_nombre = rx.Fields("producto").Value
                End If
                rx.Close()



                precio = obtener_precio_producto(global_current_idproducto, global_current_precio_especial) / (1 + tasa_impuesto)
                importe = precio * cantidad
                total_impuestos = importe * tasa_impuesto

                '-agregamos a temporal----

                conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,nombre,cantidad,precio,importe,total_impuestos,nombre_impuestos,tasa_impuestos,id_cliente,id_almacen,desc_global_porcent) " & _
                            "VALUES(" & global_id_empleado & "," & global_current_idproducto & ",'" & producto_nombre & "','" & cantidad & "','" & precio & "','" & Math.Round(importe, 2) & "','" & Math.Round(total_impuestos, 2) & "','" & nombre_impuestos & "','" & tasa_impuesto & "','" & global_current_idcliente & "','" & global_current_idalmacen & "','" & global_current_descuento_global & "')")


                rx.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_temp_venta = rx.Fields(0).Value
                rx.Close()

                If global_tipo_operacion = 0 Then '=======LO MANEJAMOS COMO VENTA====================
                    conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & cantidad & ") WHERE id_producto='" & global_current_idproducto & "' AND id_almacen='" & global_current_idalmacen & "'")
                End If

                agregar_producto(global_current_idproducto, producto_nombre, (cantidad), producto_unidad, total_impuestos, precio, importe, global_current_idalmacen, nombre_impuestos, tasa_impuesto, id_temp_venta, 0, 0)

            Else
                If conf_pv(3) = 1 Or espaquete = True Then
                    GoTo NUEVA_LINEA
                Else
                    MsgBox("Unidades insuficientes en este almacen. Solo " & stock & " Unidades", MsgBoxStyle.Critical, "Aviso")
                End If
            End If

            If espaquete = True Then
                frm_paquete.id_producto = global_current_idproducto
                frm_paquete.cantidad = cantidad
                verifica_cambio_almacen()
                frm_paquete.ShowDialog()
                Me.Close()
            Else
                verifica_cambio_almacen()
            End If

        End If

        actualizar_totales()
    End Sub

    Private Sub btn_servicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_servicio.ShowDialog()
    End Sub

    Private Sub btn_cambio_precio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cambio_precio.Click
        frm_cambio_precio.ShowDialog()
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
End Class