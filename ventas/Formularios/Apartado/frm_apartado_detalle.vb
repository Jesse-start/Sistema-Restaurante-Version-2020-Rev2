Public Class frm_apartado_detalle
    '----tabla pedidos---------------
    Dim ds, dsp, dsps As DataSet
    Dim tabla, tabla_productos_apartado As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow
    '----------------------------
    Dim current_id_venta As Integer = 0
    Public current_id_apartado As Integer = 0
    Dim Current_subtotal_apartado As Decimal = 0
    Dim Current_total_iva As Decimal = 0
    Dim Current_total_otros As Decimal = 0
    Dim current_id_venta_cancelado As Boolean
    Private total_productos, total_productos_surtir As Integer
    Dim nombre_empleado_apartado As String = ""

    Dim total_apartado As Decimal = 0
    Dim total_cobrado As Decimal = 0
    Dim saldo As Decimal = 0

    Dim cargado As Boolean
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        tab_almacenes.BackColor = Color.FromArgb(conf_colores(1))
        tab_productos.BackColor = Color.FromArgb(conf_colores(1))

        gb_productos.ForeColor = Color.FromArgb(conf_colores(2))

        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.FromArgb(conf_colores(2))

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

        btn_enviar_apartado.BackColor = Color.FromArgb(conf_colores(8))
        btn_enviar_apartado.ForeColor = Color.FromArgb(conf_colores(9))

        btn_entregar.BackColor = Color.FromArgb(conf_colores(8))
        btn_entregar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_generar_nota_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_generar_nota_venta.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))

        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_agente.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label6.ForeColor = Color.FromArgb(conf_colores(13))
        Label7.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        Label9.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_dias_faltantes.ForeColor = Color.FromArgb(conf_colores(13))
        'lbl_direccion.ForeColor = Color.FromArgb(conf_colores(13))
        'lbl_error_surtir.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_error_surtir_detalle.ForeColor = Color.FromArgb(conf_colores(13))
        'lbl_fecha_hora.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_iva.ForeColor = Color.FromArgb(conf_colores(13))
        'lbl_nombre.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_num_apartado.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_subtotal.ForeColor = Color.FromArgb(conf_colores(13))
        'lbl_telefono.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_total.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_otros.ForeColor = Color.FromArgb(conf_colores(13))
    End Sub

    Private Sub frm_apartado_detalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
        global_frm_apartado_detalle = 0

        If global_frm_apartados = 1 Then
            frm_apartados.cargar_apartados(frm_apartados.tb_buscar.Text)
        End If
        'If pedidos_para_hoy() Then
        'If global_cfg_id_pantalla = 0 Then
        'If global_frm_principal = 1 Then
        'frm_principal.tmr_aviso.Enabled = True
        'frm_principal.tmr_aviso.Start()
        ' End If

        ' Else
        'If global_frm_principal2 = 1 Then
        'frm_principal2.tmr_aviso.Enabled = True
        'frm_principal2.tmr_aviso.Start()
        'End If
        'End If

        'Else
        'If global_cfg_id_pantalla = 0 Then
        'If global_frm_principal = 1 Then
        'frm_principal.tmr_aviso.Stop()
        'frm_principal.tmr_aviso.Enabled = False
        'frm_principal.tb_aviso_pedidos.Visible = False
        'End If

        'Else
        'If global_frm_principal2 = 1 Then
        'frm_principal2.tmr_aviso.Stop()
        'frm_principal2.tmr_aviso.Enabled = False
        'frm_principal2.tb_aviso_pedidos.Visible = False
        'End If

        'End If
        'End If
        'If global_frm_pedidos_clientes = 1 Then
        'frm_pedidos_clientes.cargar_pedidos("")
        'End If
    End Sub
    Private Sub conf_inicio()
        btn_enviar_apartado.Enabled = False
        lbl_num_apartado.Text = "--"
        cb_almacenes.SelectedIndex = -1
        cb_almacenes.Text = ""
        lbl_entregado.Text = "--"
        lbl_fecha_hora.Text = "--"
        lbl_nombre.Text = "--"
        lbl_direccion.Text = "--"
        lbl_telefono.Text = "--"
        lbl_subtotal.Text = "--"
        lbl_iva.Text = "--"
        lbl_total.Text = "--"
        cb_agente_entrega.SelectedIndex = -1
        cb_agente_entrega.Text = ""
        tabla_productos.Clear()
    End Sub
    Private Sub frm_apartado_detalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_apartado_detalle = 1
        'Me.MdiParent = frm_principal
        aplicar_colores()
    End Sub
    Private Sub cargar_agentes_entrega()
        cb_agente_entrega.Items.Clear()
        'Conectar()
        rs.Open("SELECT agente_entrega.id_empleado,CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno,' ',moviles.num_unidad,': ',tipo_movil.tipo_movil) AS nombre FROM agente_entrega JOIN empleado ON empleado.id_empleado=agente_entrega.id_empleado JOIN persona ON persona.id_persona=empleado.id_persona JOIN moviles ON moviles.id_movil=agente_entrega.id_vehiculo JOIN tipo_movil ON tipo_movil.id_tipomovil=moviles.id_tipomovil JOIN empleado_puesto ON empleado_puesto.id_puesto=empleado.id_puesto ORDER BY agente_entrega.id_agente_entrega", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_agente_entrega.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub Cargar_almacenes()
        cb_almacenes.Items.Clear()
        'Conectar()
        rs.Open("SELECT * FROM almacenes Order By nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                If rs.RecordCount > 0 Then
                    cb_almacenes.Items.Add(New myItem(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()
                End If

            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub Cargar_estilo_productos_apartado()
        tabla_productos_apartado = New DataTable("productos_apartado")
        With tabla_productos_apartado.Columns
            ' .Add(New DataColumn("1", GetType(Boolean)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("miniatura", GetType(System.Drawing.Image)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("producto", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("total", GetType(Decimal)))
        End With

        dsp = New DataSet
        dsp.Tables.Add(tabla_productos_apartado)

        With dg_productos
            .DataSource = dsp
            .DataMember = "productos_apartado"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_producto")
                .HeaderText = ""
                .Width = 0
                .Visible = False
                .ReadOnly = True
            End With
            With .Columns("miniatura")
                .HeaderText = "Imagen"
                .Width = 30
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("producto")
                .HeaderText = "Producto"
                .Width = 200
                .ReadOnly = True
            End With

            With .Columns("precio")
                .HeaderText = "Precio Unit."
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
        End With
    End Sub
    Private Sub agregar_producto(ByVal producto As String, ByVal id_producto As Integer, ByVal miniatura As Object, ByVal cantidad As Decimal, ByVal unidad As String, ByVal precio As Decimal, ByVal total As Decimal)
        tabla_linea = tabla_productos_apartado.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("miniatura") = miniatura
        tabla_linea("producto") = producto
        tabla_linea("unidad") = unidad
        tabla_linea("cantidad") = cantidad
        tabla_linea("precio") = precio
        tabla_linea("total") = total
        tabla_productos_apartado.Rows.Add(tabla_linea)
    End Sub
    Public Sub cargar_apartado_detalle(ByVal id_apartado As Integer)
        If conf_pv(16) = 0 Then
            btn_generar_nota_venta.Visible = False
        Else
            btn_generar_nota_venta.Visible = True
        End If
        Cargar_estilo_productos_apartado()
        estilo_tabla_abono_apartado(dgv_abonos)
        generar_programados()
        Cargar_almacenes()
        cargar_agentes_entrega()

        cargado = False
        tabla_productos_apartado.Clear()
        current_id_apartado = id_apartado
        current_id_venta_cancelado = False
        total_apartado = 0
        total_cobrado = 0
        saldo = 0


        If id_apartado <> 0 Then

            Dim rs2 As New ADODB.Recordset
            'Conectar()
            rs2.Open("SELECT cliente.id_persona,apartado.id_apartado,apartado.id_empleado,apartado.fecha_entrega,apartado.id_cliente,apartado.entregado,apartado.id_empleado_entrega,apartado.subtotal,apartado.iva,apartado.otros_impuestos,apartado.total,apartado.status_pago,apartado.id_venta,apartado.id_empleado,apartado.comentarios,apartado.status,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente, " & _
                    "(SELECT CONCAT(d.calle,' ',IF(d.cp='','',CONCAT(' C.P. ',d.cp))) domicilio FROM cliente c, domicilio d, apartado ap WHERE  d.id_domicilio=c.id_domicilio AND ap.id_apartado='" & id_apartado & "' AND c.id_cliente=ap.id_cliente ) AS domicilio " & _
                    "FROM cliente " & _
                    "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                    "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                    "JOIN apartado ON apartado.id_cliente=cliente.id_cliente " & _
                    "WHERE apartado.id_apartado='" & current_id_apartado & "'", conn)
            If rs2.RecordCount > 0 Then
                current_id_venta = rs2.Fields("id_venta").Value
                lbl_num_apartado.Text = rs2.Fields("id_apartado").Value
                Dim fecha_entrega As DateTime = rs2.Fields("fecha_entrega").Value
                lbl_fecha_hora.Text = fecha_entrega.ToLongDateString & " " & fecha_entrega.ToLongTimeString
                lbl_dias_faltantes.Text = DateDiff(DateInterval.Day, Date.Today, fecha_entrega) & " Dias"
                lbl_nombre.Text = rs2.Fields("cliente").Value
                lbl_direccion.Text = rs2.Fields("domicilio").Value
                lbl_telefono.Text = ""
                If Not IsDBNull(rs2.Fields("domicilio").Value) Then
                    Tb_comentarios.Text = rs2.Fields("comentarios").Value
                Else
                    Tb_comentarios.Text = ""
                End If
                If rs2.Fields("id_empleado_entrega").Value > 0 Then
                    seleccionar_agente(rs2.Fields("id_empleado_entrega").Value)
                    cb_agente_entrega.Enabled = False
                    btn_enviar_apartado.Enabled = False
                Else
                    cb_agente_entrega.SelectedIndex = -1
                    cb_agente_entrega.Text = ""
                    cb_agente_entrega.Enabled = True
                    btn_enviar_apartado.Enabled = True
                End If
                If rs2.Fields("entregado").Value <> 0 Then
                    lbl_entregado.Text = "ENTREGADO"
                    'lbl_entregado.ForeColor = Color.DarkGreen
                    cb_almacenes.Enabled = False
                    ' Tab_Surtir.Parent = Nothing
                    btn_entregar.Enabled = False
                Else
                    lbl_entregado.Text = "NO ENTREGADO"
                    lbl_entregado.ForeColor = Color.DarkRed
                    'Tab_Surtir.Parent = tc_pedidos
                    cb_almacenes.Enabled = True
                    'btn_enviar_apartado.Enabled = False
                    btn_entregar.Enabled = True
                End If
                If rs2.Fields("status").Value = "CANCELADO" Then
                    gb_botones.Enabled = False
                    gb_productos.Enabled = False
                    tb_aviso_cancelado.Visible = True
                    current_id_venta_cancelado = True
                Else
                    gb_botones.Enabled = True
                    gb_productos.Enabled = True
                    tb_aviso_cancelado.Visible = False
                End If
                Dim rs3 As New ADODB.Recordset
                rs3.Open("SELECT CONCAT(p.nombre,'',p.ap_paterno,' ',p.ap_materno) AS vendedor FROM venta v " & _
                         "JOIN empleado e ON e.id_empleado=v.id_empleado " & _
                         "JOIN persona p ON p.id_persona=e.id_persona " & _
                         "WHERE v.id_venta='" & current_id_venta & "'", conn)
                If rs3.RecordCount > 0 Then
                    tb_vendedor.Text = rs3.Fields("vendedor").Value
                End If
                rs3.Close()
                '--obtenemos telefono de la persona
                If rs2.Fields("id_persona").Value <> 0 Then
                    rs3.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, persona_tel pt,telefono t WHERE t.id_telefono=pt.id_telefono AND pt.id_persona=c.id_persona AND c.id_cliente=" & rs2.Fields("id_cliente").Value, conn)
                    If rs3.RecordCount > 0 Then
                        Dim cont As Integer = 1
                        While Not rs3.EOF
                            lbl_telefono.Text = lbl_telefono.Text & " Tel. " & cont & ": " & rs3.Fields("telefono").Value
                            cont = cont + 1
                            rs3.MoveNext()
                        End While
                    End If
                    rs3.Close()
                    '---------
                Else
                    '--obtenemos telefono de la empresa
                    rs3.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, empresa_tel et,telefono t WHERE t.id_telefono=et.id_telefono AND et.id_empresa=c.id_empresa AND c.id_cliente=" & rs2.Fields("id_cliente").Value, conn)
                    If rs3.RecordCount > 0 Then
                        Dim cont As Integer = 1
                        While Not rs3.EOF
                            lbl_telefono.Text = lbl_telefono.Text & " Tel. " & cont & ": " & rs3.Fields("telefono").Value
                            cont = cont + 1
                            rs3.MoveNext()
                        End While
                    End If
                    rs3.Close()
                    '---------
                End If
                'lbl_telefono.Text = rs.Fields("telefono").Value

                lbl_subtotal.Text = FormatCurrency(rs2.Fields("subtotal").Value)
                Current_subtotal_apartado = rs2.Fields("subtotal").Value
                lbl_iva.Text = FormatCurrency(rs2.Fields("iva").Value)
                lbl_otros.Text = FormatCurrency(rs2.Fields("otros_impuestos").Value)
                Current_total_iva = rs2.Fields("iva").Value
                total_apartado = rs2.Fields("total").Value

                lbl_total.Text = FormatCurrency(rs2.Fields("total").Value)
                rs3.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS nombre_empleado " & _
                         "FROM empleado e " & _
                         "JOIN persona p ON p.id_persona=e.id_persona " & _
                         "WHERE e.id_empleado='" & rs2.Fields("id_empleado").Value & "'")
                If rs3.RecordCount > 0 Then
                    nombre_empleado_apartado = rs3.Fields("nombre_empleado").Value
                End If
                rs3.Close()

            End If
            rs2.Close()

            '==========CARGAMOS LOS PRODUCTOS DEL APARTADO=========================
            tabla_productos_apartado.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,p.thumb,vd.id_almacen " & _
                    "FROM venta_detalle vd " & _
                    "JOIN producto p ON p.id_producto=vd.id_producto WHERE vd.id_venta='" & current_id_venta & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                While Not rs.EOF
                    agregar_producto(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, rs.Fields("importe").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            If id_almacen = 0 Then
                'Conectar()
                rs.Open("SELECT id_almacen FROM almacenes WHERE default_ventas='1'", conn)
                If rs.RecordCount > 0 Then
                    id_almacen = rs.Fields("ID_Almacen").Value
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
            End If
            seleccionar_almacen(id_almacen)

            '#############################obtenemos cobros#####################
            tabla_abono_apartado.Clear()
            rs.Open("SELECT pv.id_pago_ventas,pv.importe,pv.id_forma_pago,pv.fecha,pv.fecha_cobro,pv.status, CONCAT(p.nombre,' ',p.ap_paterno) AS empleado_caja " &
                    "FROM pagos_ventas pv " &
                    " JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                    " JOIN persona p ON p.id_persona=e.id_persona " &
                    "WHERE pv.id_venta='" & current_id_venta & "' ORDER by fecha_cobro", conn)
            Dim i = 0
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_abono_apartado(rs.Fields("id_pago_ventas").Value, Format(rs.Fields("fecha").Value, "dd-MM-yyyy"), Format(rs.Fields("fecha_cobro").Value, "dd-MM-yyyy"), nombre_forma_pago(rs.Fields("id_forma_pago").Value), FormatCurrency(rs.Fields("importe").Value), rs.Fields("empleado_caja").Value, rs.Fields("status").Value)
                    rs.MoveNext()
                End While

            End If
            rs.Close()
            '###################################################################



            ' ========================================
        End If
        comprobar_existencias()

        rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_ventas WHERE id_venta='" & current_id_venta & "' AND status='ACTIVO' ", conn)
        If rs.RecordCount > 0 Then
            total_cobrado = CDbl(rs.Fields("total").Value)
        End If
        rs.Close()
        saldo = total_apartado - total_cobrado

        lbl_cobros.Text = FormatCurrency(total_cobrado)
        lbl_saldo.Text = FormatCurrency(saldo)

        If saldo > 0 Then
            btn_cobrar.Visible = True
        Else
            btn_cobrar.Visible = False
        End If
        cargado = True

    End Sub
    Private Sub cb_almacenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_almacenes.SelectedIndexChanged
        If cargado = True Then
            If lbl_entregado.Text = "NO ENTREGADO" Then
                comprobar_existencias()
            End If
        End If

    End Sub
    Private Sub comprobar_existencias()
        If cb_almacenes.SelectedIndex <> -1 Then
            btn_entregar.Enabled = False
            lbl_error_surtir_detalle.Text = ""
            '----verificamos la existencia de los productos en el almacen
            Dim bandera_correcto As Boolean = True
            Dim cadena As String = ""
            Dim bandera_insuficiente As Boolean = False
            'Conectar()
            For x = 0 To tabla_productos_apartado.Rows.Count - 1

                rs.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & dg_productos.Rows(x).Cells("id_producto").Value & "' AND id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value, conn)
                If rs.RecordCount > 0 Then
                    If rs.Fields("cantidad").Value <> 0 Then
                        If rs.Fields("cantidad").Value < dg_productos.Rows(x).Cells("cantidad").Value Then
                            cadena = cadena & vbCrLf & dg_productos.Rows(x).Cells("cantidad").Value & " " & dg_productos.Rows(x).Cells("producto").Value & " (" & rs.Fields("cantidad").Value & " unidades en este almacen)"
                            bandera_correcto = False
                            bandera_insuficiente = True
                        Else
                            bandera_insuficiente = True
                        End If
                    Else
                        cadena = cadena & vbCrLf & dg_productos.Rows(x).Cells("cantidad").Value & " " & dg_productos.Rows(x).Cells("producto").Value & " (" & rs.Fields("cantidad").Value & " unidades en este almacen)"
                        bandera_correcto = False
                    End If

                Else
                    cadena = cadena & vbCrLf & dg_productos.Rows(x).Cells("cantidad").Value & " " & dg_productos.Rows(x).Cells("producto").Value & " *No existe el producto en almacen"
                    bandera_correcto = False
                End If
                rs.Close()



            Next
            'conn.close()
            'conn = Nothing
            If bandera_correcto = True Then
                ' tb_opciones.SelectedIndex = 0
                lbl_error_surtir.Visible = False
                lbl_error_surtir_detalle.Visible = False
                If lbl_entregado.Text = "NO ENTREGADO" Then
SURTIR_NEG:         btn_entregar.Enabled = True
                End If
            Else
                'tb_opciones.SelectedIndex = 1
                lbl_error_surtir.Visible = True
                lbl_error_surtir_detalle.Text = cadena
                lbl_error_surtir_detalle.Visible = True
                btn_entregar.Enabled = False
                If bandera_insuficiente = True Then
                    If conf_pv(3) = 1 Then
                        If lbl_entregado.Text = "NO ENTREGADO" Then
                            GoTo SURTIR_NEG
                        End If
                    End If
                End If
            End If
            '------------------------------------------------------------
        Else
            btn_entregar.Enabled = False
            lbl_error_surtir.Visible = False
            lbl_error_surtir_detalle.Visible = False

        End If
    End Sub
    Private Sub generar_programados()
        Dim id_cliente As Integer
        'Dim dias_anticipacion As Integer
        Dim fecha_entrega As New Date
        Dim fecha_prox_entrega As String
        Dim id_periodicidad As Integer
        Dim intervalo As Integer
        Dim rs2, rs3 As New ADODB.Recordset
        Dim id_pedido As Integer


        'Conectar()
        rs.Open("SELECT id_pedido_prog,intervalo,id_periodicidad,fecha_prox_entrega,DATE(fecha_prox_entrega) as fecha_entrega,hora FROM pedido_prog", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                fecha_entrega = rs.Fields("fecha_entrega").Value
                id_periodicidad = rs.Fields("id_periodicidad").Value
                intervalo = rs.Fields("intervalo").Value
                If DateDiff(DateInterval.Day, Today, fecha_entrega) < 0 Then
                    If id_periodicidad = 1 Then
                        fecha_entrega = fecha_entrega.AddDays(intervalo)
                    ElseIf id_periodicidad = 2 Then
                        fecha_entrega = fecha_entrega.AddDays(7 * intervalo)
                    ElseIf id_periodicidad = 3 Then
                        fecha_entrega = fecha_entrega.AddMonths(intervalo)
                    End If

                    fecha_prox_entrega = Format(fecha_entrega, "yyyy-MM-dd") & " " & Format(rs.Fields("hora").Value, "HH:mm:ss")
                    conn.Execute("UPDATE pedido_prog SET fecha_prox_entrega='" & fecha_prox_entrega & "' WHERE id_pedido_prog=" & rs.Fields("id_pedido_prog").Value)
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()


        '---buscamos todos los pedidos_programados

        rs.Open("SELECT id_pedido_prog,id_empleado,id_sucursal,id_cliente,intervalo,id_periodicidad,fecha_prox_entrega,dias_anticipacion,DATE(fecha_prox_entrega) as fecha_entrega,total FROM pedido_prog", conn)

        If rs.RecordCount > 0 Then
            While Not rs.EOF
                id_cliente = rs.Fields("id_cliente").Value
                fecha_entrega = rs.Fields("fecha_entrega").Value
                '--verificamos si ya esta programado
                rs2.Open("SELECT id_pedido FROM pedido_clientes WHERE id_cliente='" & id_cliente & "' AND fecha_entrega='" & rs.Fields("fecha_prox_entrega").Value & "' AND status='ACTIVO'", conn)
                If rs2.RecordCount = 0 Then
                    If DateDiff(DateInterval.Day, Today, fecha_entrega) <= 3 Then
                        '-.-programamos el pedido
                        conn.Execute("INSERT INTO pedido_clientes (id_empleado,fecha_pedido,fecha_entrega,id_cliente,total,id_sucursal,programado) VALUES " & _
                      " ('" & rs.Fields("id_empleado").Value & "',NOW(),'" & rs.Fields("fecha_prox_entrega").Value & "','" & rs.Fields("id_cliente").Value & "','" & rs.Fields("total").Value & "','" & rs.Fields("id_sucursal").Value & "','1')")
                        rs3.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_pedido = rs3.Fields(0).Value
                        rs3.Close()
                        rs3.Open("SELECT id_producto,cantidad,precio,impuesto FROM pedido_prog_detalle WHERE id_pedido_prog=" & rs.Fields("id_pedido_prog").Value, conn)
                        If rs3.RecordCount > 0 Then
                            While Not rs3.EOF

                                Dim ry As New ADODB.Recordset
                                Dim producto_costo As Decimal = 0
                                ry.Open("SELECT costo FROM producto WHERE id_producto='" & rs3.Fields("id_producto").Value & "'", conn)
                                If ry.RecordCount > 0 Then
                                    producto_costo = ry.Fields("costo").Value
                                End If
                                ry.Close()

                                conn.Execute("INSERT INTO detalle_pedido(id_pedido,id_producto,producto_costo,cantidad,precio,impuesto)" & _
                                           " VALUES ('" & id_pedido & "', '" & rs3.Fields("id_producto").Value & "','" & producto_costo & "','" & rs3.Fields("cantidad").Value & "', '" & rs3.Fields("precio").Value & "','" & rs3.Fields("impuesto").Value & "')")
                                rs3.MoveNext()
                            End While
                        End If
                        rs3.Close()
                        '-------------------
                    End If

                End If
                rs2.Close()

                '----------------------------
                rs.MoveNext()
            End While


        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub seleccionar_agente(ByVal id_empleado As Integer)
        For x = 0 To cb_agente_entrega.Items.Count - 1
            If id_empleado = CType(cb_agente_entrega.Items(x), myItem).Value Then
                cb_agente_entrega.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub seleccionar_almacen(ByVal id_almacen As Integer)
        For x = 0 To cb_almacenes.Items.Count - 1
            If id_almacen = CType(cb_almacenes.Items(x), myItem).Value Then
                cb_almacenes.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub btn_recibir_nota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Confirme que desea registrar que el pedido ha sido suministrado y se recibe nota", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("UPDATE pedido_clientes SET status='SUMINISTRADO', status_pago='NOTA' WHERE id_pedido='" & current_id_apartado & "'")
            'conn.close()
            'conn = Nothing
            cargar_apartado_detalle(current_id_apartado)

        End If
    End Sub

    Private Sub btn_recibir_pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim num_ticket As Integer
        'Conectar()
        rs.Open("SELECT id_venta FROM pedido_clientes WHERE id_pedido='" & current_id_apartado & "'", conn)
        If rs.RecordCount > 0 Then
            num_ticket = rs.Fields("id_venta").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        frm_caja.Show()
        frm_caja.BringToFront()
        frm_caja.tb_buscar.Text = num_ticket
        frm_caja.obtener_cuentasxcobrar(num_ticket)
    End Sub

    Private Sub btn_apartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cobrar.Click
        frm_formas_pago_ventas.id_venta = current_id_venta
        frm_formas_pago_ventas.credito = 1
        frm_formas_pago_ventas.nombre_cliente = lbl_nombre.Text
        frm_formas_pago_ventas.empleado_venta = nombre_empleado_apartado
        frm_formas_pago_ventas.credito_asignado = True
        frm_formas_pago_ventas.ShowDialog()
    End Sub

    Private Sub btn_enviar_apartado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar_apartado.Click
        '---guardamos todos los datos
        If cb_agente_entrega.SelectedIndex = -1 Then
            MsgBox("Para poder enviar el producto es necesario que seleccione el agente de entrega", MsgBoxStyle.Exclamation, "Aviso")
        Else
            If MsgBox("Confirme que desea entregar_este apartado", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                '---actualizamos el detalle entrega
                'Conectar()
                For x = 0 To tabla_productos_apartado.Rows.Count - 1
                    Dim importe As Decimal = 0
                    If global_current_aplicar_redondeo Then
                        importe = redondear(FormatNumber((CDec(dg_productos.Rows(x).Cells("cantidad").Value) * CDec(dg_productos.Rows(x).Cells("precio").Value)), 2))
                    Else
                        importe = FormatNumber((CDec(dg_productos.Rows(x).Cells("cantidad").Value) * CDec(dg_productos.Rows(x).Cells("precio").Value)), 2)
                    End If

                    conn.Execute("UPDATE venta_detalle SET cantidad='" & dg_productos.Rows(x).Cells("cantidad").Value & "',descripcion='" & dg_productos.Rows(x).Cells("producto").Value & "',precio='" & dg_productos.Rows(x).Cells("precio").Value & "',importe='" & importe & "' WHERE id_venta=" & current_id_venta & " AND id_producto='" & dg_productos.Rows(x).Cells("id_producto").Value & "'")
                Next
                '--------------------------------
                conn.Execute("UPDATE apartado SET subtotal='" & Current_subtotal_apartado & "',total='" & total_apartado & "',id_empleado_entrega='" & CType(cb_agente_entrega.SelectedItem, myItem).Value & "' WHERE id_apartado='" & current_id_apartado & "'")

                For x = 0 To 1
                    imprimir_ticket_credito("pagare", current_id_venta, lbl_nombre.Text, current_id_venta, total_apartado, "", "", "", "", x)
                Next
                cargar_apartado_detalle(current_id_apartado)
            End If
        End If

        '---------------------------------------
    End Sub

    Private Sub btn_surtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_entregar.Click
        If MsgBox("Confirme que desea entregar este apartado. Los productos se daran de baja en el inventario", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            Dim bandera_correcto As Boolean = True
            For x = 0 To tabla_productos_apartado.Rows.Count - 1
                rs.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & dg_productos.Rows(x).Cells("id_producto").Value & "' AND id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value, conn)
                If rs.RecordCount > 0 Then
                    If rs.Fields("cantidad").Value <> 0 Then
                        If rs.Fields("cantidad").Value < dg_productos.Rows(x).Cells("cantidad").Value Then
                            bandera_correcto = False
                        End If
                    End If

                Else
                    bandera_correcto = False
                End If
                rs.Close()


            Next
            'conn.close()
            'conn = Nothing

            If bandera_correcto = True Then
_SURTIR_NEGATIVO:  'Conectar()
                For x = 0 To tabla_productos_apartado.Rows.Count - 1

                    '---descontamos del inventario
                    conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & CDbl(dg_productos.Rows(x).Cells("cantidad").Value) & ") WHERE id_almacen='" & CType(cb_almacenes.SelectedItem, myItem).Value & "' AND id_producto=" & dg_productos.Rows(x).Cells("id_producto").Value) '--damos de baja del inventario
                    '--actualizamos el registro de sucursal
                    conn.Execute("UPDATE venta_detalle  SET id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value & " WHERE id_venta='" & current_id_venta & "'")
                    conn.Execute("UPDATE venta  SET id_sucursal=" & global_id_sucursal & ",fecha_salida_almacen=NOW() WHERE id_venta='" & current_id_venta & "'")

                Next

                conn.Execute("UPDATE apartado SET entregado=1 WHERE id_apartado=" & current_id_apartado)
                'conn.close()
                'conn = Nothing


                

                If conf_pv(9) = 1 Then
                    If conf_pv(16) = 1 Then
                        Generar_orden_entrega(current_id_venta)
                    Else
                        imprimir_orden_entrega(current_id_venta, 0)
                    End If
                End If

                cargar_apartado_detalle(current_id_apartado)
                MsgBox("Apartado entregado correctamente", MsgBoxStyle.Information, "Aviso")
                'cb_almacenes.SelectedIndex = -1
                'lbl_surtido.Text = "SURTIDO"
                'lbl_surtido.ForeColor = Color.DarkGreen
                ''Tab_Surtir.Parent = Nothing
                'cb_almacenes.Enabled = False
                ' cb_agente_entrega.SelectedIndex = -1
                'cb_agente_entrega.Text = ""
                ' btn_enviar_pedido.Enabled = True
            Else
                If conf_pv(3) = 1 Then
                    GoTo _SURTIR_NEGATIVO
                Else
                    MsgBox("Al parecer algun producto no se encontro en el inventario. " & vbCrLf & " Es posible que ha sido dado de baja mientras realizaba esta operacion. " & vbCrLf & "Se ha cancelado la operación")
                End If

            End If
            comprobar_existencias()
        End If
    End Sub
    Private Sub btn_generar_nota_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar_nota_venta.Click
        If conf_pv(16) = 1 Then
            If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                Generar_Formato_venta_retail(current_id_venta, current_id_venta_cancelado)
            ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                Generar_Formato_venta_retail_media(current_id_venta, current_id_venta_cancelado, False)
            ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                Generar_Formato_venta_apartado(current_id_venta)
            End If

        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        frm_validacion.origen_cancelacion_apartado = 0
        frm_validacion.validacion = 8
        frm_validacion.ShowDialog()
    End Sub
    Public Sub cancelar_apartado()
        If MsgBox("Se cancelará este apartado y todos los pagos que se hayan realizado, ¿Desea continua?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("UPDATE apartado SET status='CANCELADO' WHERE id_apartado='" & current_id_apartado & "'")
            conn.Execute("UPDATE pagos_ventas SET status='CANCELADO', fecha_cancelacion=NOW() WHERE id_venta='" & current_id_venta & "' AND status='ACTIVO'")
            conn.Execute("UPDATE venta SET status='CANCELADA' WHERE id_venta='" & current_id_venta & "'")
            cargar_apartado_detalle(current_id_apartado)
            MsgBox("Apartado cancelado correctamente0", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub dgv_abonos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_abonos.CellContentClick

    End Sub

    Private Sub dgv_abonos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_abonos.CellFormatting
        For x = 0 To dgv_abonos.Columns.Count - 1
            e.CellStyle.Font = New Font("Century Gothic", 8, FontStyle.Bold)
            If dgv_abonos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
            If dgv_abonos.Columns(e.ColumnIndex).Index = 6 Then '9 id_estatus
                'e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                If e.Value = "ACTIVO" Then
                    'e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                    e.CellStyle.BackColor = Color.DarkGreen
                    e.CellStyle.ForeColor = Color.White
                ElseIf e.Value = "CANCELADO" Then
                    e.CellStyle.BackColor = Color.DarkRed
                    e.CellStyle.ForeColor = Color.White
                End If
            End If

        Next
    End Sub

    Private Sub btn_cancelar_pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_pago.Click
        If dgv_abonos.SelectedRows.Count > 0 Then
            frm_validacion.id_venta_cobro = dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("id_pago_ventas").Value
            frm_validacion.tipo_de_cobro = dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("forma_pago").Value
            frm_validacion.validacion = 4
            frm_validacion.ShowDialog()
        Else
            MsgBox("Seleccione un abono de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub

    Private Sub btn_imprimir_abono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_abono.Click
        If dgv_abonos.SelectedRows.Count > 0 Then
            If conf_pv(16) = 1 Then
                If conf_pv_id_formato(3) = 2 Then
                    Generar_Formato_abono(dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("id_pago_ventas").Value)
                End If
            Else
                'imprimir_abono en miniprinter
            End If

            If conf_pv(18) = 1 Then 'IMPRESION DE COMPROBANTE DE PAGO
                For x = 0 To 1
                    imprimir_comprobante_pago(dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("id_pago_ventas").Value, x)
                Next
            End If
        Else
            MsgBox("Seleccione un abono de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_guardar_observaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_observaciones.Click
        frm_validacion.validacion = 9
        frm_validacion.ShowDialog()
    End Sub
    Public Sub actualizar_comentarios_apartado()
        conn.Execute("UPDATE apartado SET comentarios='" & tb_comentarios.Text & "' WHERE id_apartado='" & current_id_apartado & "'")
        cargar_apartado_detalle(current_id_apartado)
        MsgBox("Los comentarios han sido actualizados correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub

End Class