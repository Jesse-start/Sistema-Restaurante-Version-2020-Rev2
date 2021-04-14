Public Class frm_pedidos_detalle
    '----tabla pedidos---------------
    Dim ds, dsp, dsps As DataSet
    Dim tabla, tabla_productos As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow
    '----------------------------
    Dim CurrentIDPedido As Integer = 0
    Dim current_id_retiro = 0
    Dim Current_subtotal_pedido As Decimal = 0
    Dim Current_total_iva As Decimal = 0
    Dim Current_total_otros As Decimal = 0
    Dim current_total As Decimal = 0
    Dim current_id_venta_pedido As Integer = 0
    Dim current_id_venta_cancelado As Boolean
    Private total_productos, total_productos_surtir As Integer
    Dim cargado As Boolean
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        tab_almacenes.BackColor = Color.FromArgb(conf_colores(1))
        tab_repartidor.BackColor = Color.FromArgb(conf_colores(1))

        gb_productos.ForeColor = Color.FromArgb(conf_colores(2))

        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.FromArgb(conf_colores(2))

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

        btn_enviar_pedido.BackColor = Color.FromArgb(conf_colores(8))
        btn_enviar_pedido.ForeColor = Color.FromArgb(conf_colores(9))

        btn_surtir.BackColor = Color.FromArgb(conf_colores(8))
        btn_surtir.ForeColor = Color.FromArgb(conf_colores(9))

        btn_modificar.BackColor = Color.FromArgb(conf_colores(8))
        btn_modificar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_recibir_nota.BackColor = Color.FromArgb(conf_colores(8))
        btn_recibir_nota.ForeColor = Color.FromArgb(conf_colores(9))

        btn_recibir_pago.BackColor = Color.FromArgb(conf_colores(8))
        btn_recibir_pago.ForeColor = Color.FromArgb(conf_colores(9))

        btn_calcular.BackColor = Color.FromArgb(conf_colores(8))
        btn_calcular.ForeColor = Color.FromArgb(conf_colores(9))

        btn_retiro.BackColor = Color.FromArgb(conf_colores(8))
        btn_retiro.ForeColor = Color.FromArgb(conf_colores(9))

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
        lbl_direccion.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_error_surtir.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_error_surtir_detalle.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_fecha_hora.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_iva.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_nombre.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_num_pedido.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_subtotal.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_telefono.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_total.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_diferencia.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_total_para.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_otros.ForeColor = Color.FromArgb(conf_colores(13))
    End Sub

    Private Sub frm_pedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frm_principal3.preparar_para_codigo()
 
        If pedidos_para_hoy() Then
            frm_principal3.tmr_aviso.Enabled = True
            frm_principal3.tmr_aviso.Start()
        Else
            frm_principal3.tmr_aviso.Stop()
            frm_principal3.tmr_aviso.Enabled = False
            frm_principal3.tb_aviso_pedidos.Visible = False
        
        End If
        If global_frm_pedidos_clientes = 1 Then
            frm_pedidos_clientes.cargar_pedidos("")
        End If
    End Sub
    Private Sub conf_inicio()
        btn_enviar_pedido.Enabled = False
        lbl_num_pedido.Text = "--"
        cb_almacenes.SelectedIndex = -1
        cb_almacenes.Text = ""
        lbl_surtido.Text = "--"
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
    Private Sub frm_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        aplicar_colores()
        cargar()
    End Sub
    Private Sub cargar()
        Cargar_estilo_productos()
        generar_programados()
        Cargar_almacenes()
        cargar_agentes_entrega()
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
        rs.Open("SELECT * FROM almacenes Order By Nombre", conn)
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
    Private Sub Cargar_estilo_productos()
        tabla_productos = New DataTable("productos")
        With tabla_productos.Columns
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
        dsp.Tables.Add(tabla_productos)

        With dg_productos
            .DataSource = dsp
            .DataMember = "productos"

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
    Private Sub agregar_pedidos(ByVal id_pedido As Integer, ByVal fecha_hora As String, ByVal cliente As String, ByVal programado As Integer)
        tabla_linea = tabla.NewRow()
        tabla_linea("id_pedido") = id_pedido
        If programado = 0 Then
            tabla_linea("status") = "SOLICITADO"
        Else
            tabla_linea("status") = "PROGRAMADO"
        End If

        tabla_linea("fecha_hora") = fecha_hora
        tabla_linea("cliente") = cliente
        tabla.Rows.Add(tabla_linea)
    End Sub
    Private Sub agregar_producto(ByVal producto As String, ByVal id_producto As Integer, ByVal miniatura As Object, ByVal cantidad As Decimal, ByVal unidad As String, ByVal precio As Decimal, ByVal total As Decimal)
        tabla_linea = tabla_productos.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("miniatura") = miniatura
        tabla_linea("producto") = producto
        tabla_linea("unidad") = unidad
        tabla_linea("cantidad") = cantidad
        tabla_linea("precio") = precio
        tabla_linea("total") = total
        tabla_productos.Rows.Add(tabla_linea)
    End Sub
    Public Sub cargar_detalle_pedido(ByVal id_pedido As Integer)
        tb_aviso_cancelado.Visible = False
        current_id_venta_cancelado = False
        cargado = False
        tabla_productos.Clear()
        CurrentIDPedido = id_pedido
        tb_total_recibir.Text = "0"
        tb_diferencia.Text = "0"
        current_id_retiro = 0
        btn_cancelar.Visible = True
        gb_productos.Enabled = True
        If id_pedido <> 0 Then

            'Conectar()
            rs.Open("SELECT cliente.id_persona,pedido_clientes.id_pedido,pedido_clientes.id_empleado,pedido_clientes.fecha_entrega,pedido_clientes.id_cliente,pedido_clientes.surtido,pedido_clientes.id_empleado_entrega,pedido_clientes.subtotal,pedido_clientes.iva,pedido_clientes.otros_impuestos,pedido_clientes.total,pedido_clientes.id_retiro,pedido_clientes.status,pedido_clientes.status_pago,pedido_clientes.id_venta," & _
                    "CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente, " & _
                    "(SELECT CONCAT(d.calle,' ',IF(d.cp='','',CONCAT(' C.P. ',d.cp))) domicilio FROM cliente c, domicilio d, pedido_clientes pc WHERE  d.id_domicilio=c.id_domicilio AND pc.id_pedido='" & id_pedido & "' AND c.id_cliente=pc.id_cliente ) AS domicilio " & _
                    "FROM cliente " & _
                    "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                    "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                    "JOIN pedido_clientes ON pedido_clientes.id_cliente=cliente.id_cliente " & _
                    "WHERE pedido_clientes.id_pedido='" & id_pedido & "'", conn)
            If rs.RecordCount > 0 Then
                current_id_venta_pedido = rs.Fields("id_venta").Value
                lbl_num_pedido.Text = rs.Fields("id_pedido").Value
                Dim fecha_entrega As DateTime = rs.Fields("fecha_entrega").Value
                lbl_fecha_hora.Text = fecha_entrega.ToLongDateString & " " & fecha_entrega.ToLongTimeString
                lbl_dias_faltantes.Text = DateDiff(DateInterval.Day, Date.Today, fecha_entrega) & " Dias"
                lbl_nombre.Text = rs.Fields("cliente").Value
                lbl_direccion.Text = rs.Fields("domicilio").Value
                lbl_telefono.Text = ""
                If rs.Fields("id_empleado_entrega").Value > 0 Then
                    seleccionar_agente(rs.Fields("id_empleado_entrega").Value)
                Else
                    cb_agente_entrega.SelectedIndex = -1
                    cb_agente_entrega.Text = ""
                End If


                If rs.Fields("surtido").Value <> 0 Then
                    lbl_surtido.Text = "SURTIDO"
                    lbl_surtido.ForeColor = Color.DarkGreen
                    btn_surtir.Enabled = False
                    cb_almacenes.Enabled = False
                    ' Tab_Surtir.Parent = Nothing
                Else
                    lbl_surtido.Text = "NO SURTIDO"
                    lbl_surtido.ForeColor = Color.DarkRed
                    'Tab_Surtir.Parent = tc_pedidos
                    btn_surtir.Enabled = True
                    cb_almacenes.Enabled = True
                    btn_enviar_pedido.Enabled = False
                End If
                current_id_retiro = rs.Fields("id_retiro").Value

                If rs.Fields("status").Value = "PENDIENTE" Then
                    btn_modificar.Enabled = True
                    btn_surtir.Enabled = True
                    btn_retiro.Enabled = False
                    btn_enviar_pedido.Enabled = False
                    btn_recibir_nota.Enabled = False
                    btn_recibir_pago.Enabled = False
                    btn_cancelar.Enabled = True
                ElseIf rs.Fields("status").Value = "SURTIDO" Then
                    btn_modificar.Enabled = False
                    btn_surtir.Enabled = False
                    btn_retiro.Enabled = True
                    btn_enviar_pedido.Enabled = True
                    btn_recibir_nota.Enabled = False
                    btn_recibir_pago.Enabled = False
                    btn_cancelar.Enabled = True
                ElseIf rs.Fields("status").Value = "ENVIADO" Then
                    btn_modificar.Enabled = False
                    btn_surtir.Enabled = False
                    btn_retiro.Enabled = False
                    btn_enviar_pedido.Enabled = False
                    btn_recibir_nota.Enabled = True
                    btn_recibir_pago.Enabled = True
                    btn_cancelar.Enabled = True
                ElseIf rs.Fields("status").Value = "SUMINISTRADO" Then
                    btn_modificar.Enabled = False
                    btn_surtir.Enabled = False
                    btn_retiro.Enabled = False
                    btn_enviar_pedido.Enabled = False
                    btn_recibir_nota.Enabled = False
                    btn_cancelar.Enabled = False
                    If rs.Fields("status_pago").Value = "NOTA" Then
                        btn_recibir_pago.Enabled = True
                    Else
                        btn_recibir_pago.Enabled = True
                    End If
                ElseIf rs.Fields("status").Value = "CANCELADO" Then
                    current_id_venta_cancelado = True
                    btn_cancelar.Visible = False
                    gb_productos.Enabled = False
                    tb_aviso_cancelado.Visible = True
                End If

                Dim rs3 As New ADODB.Recordset
                '--obtenemos telefono de la persona
                If rs.Fields("id_persona").Value <> 0 Then
                    rs3.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, persona_tel pt,telefono t WHERE t.id_telefono=pt.id_telefono AND pt.id_persona=c.id_persona AND c.id_cliente=" & rs.Fields("id_cliente").Value, conn)
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
                    rs3.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, empresa_tel et,telefono t WHERE t.id_telefono=et.id_telefono AND et.id_empresa=c.id_empresa AND c.id_cliente=" & rs.Fields("id_cliente").Value, conn)
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

                lbl_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                Current_subtotal_pedido = rs.Fields("subtotal").Value
                lbl_iva.Text = FormatCurrency(rs.Fields("iva").Value)
                lbl_otros.Text = FormatCurrency(rs.Fields("otros_impuestos").Value)
                Current_total_iva = rs.Fields("iva").Value
                current_total = rs.Fields("total").Value
                lbl_total.Text = FormatCurrency(rs.Fields("total").Value)
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            If current_id_retiro > 0 Then
                btn_retiro.Text = "Cancelar Retiro"
                cb_agente_entrega.Enabled = False
                'Conectar()
                rs.Open("SELECT cantidad FROM retiros WHERE id_retiro='" & current_id_retiro & "'", conn)
                If rs.RecordCount > 0 Then
                    tb_diferencia.Text = rs.Fields("cantidad").Value
                    tb_total_recibir.Text = rs.Fields("cantidad").Value + current_total
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
            Else
                btn_retiro.Text = "Realizar Retiro"
                cb_agente_entrega.Enabled = True
            End If


            tabla_productos.Clear()
            'Conectar()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,p.thumb,vd.id_almacen FROM venta_detalle vd " & _
                    "JOIN producto p ON p.id_producto=vd.id_producto WHERE id_venta='" & current_id_venta_pedido & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                While Not rs.EOF
                    agregar_producto(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, rs.Fields("importe").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing

            If id_almacen = 0 Then
                'Conectar()
                rs.Open("SELECT id_almacen FROM almacenes WHERE default_ventas='1'", conn)
                If rs.RecordCount > 0 Then
                    id_almacen = rs.Fields("id_almacen").Value
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
            End If
            seleccionar_almacen(id_almacen)

        End If
        comprobar_existencias()
        cargado = True

    End Sub
    Private Sub cb_almacenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_almacenes.SelectedIndexChanged
        If cargado = True Then
            comprobar_existencias()
        End If

    End Sub
    Private Sub comprobar_existencias()
        If cb_almacenes.SelectedIndex <> -1 Then
            btn_surtir.Enabled = False
            lbl_error_surtir_detalle.Text = ""
            '----verificamos la existencia de los productos en el almacen
            Dim bandera_correcto As Boolean = True
            Dim cadena As String = ""
            Dim bandera_insuficiente As Boolean = False
            'Conectar()
            For x = 0 To tabla_productos.Rows.Count - 1

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
                lbl_error_surtir.Visible = False
                lbl_error_surtir_detalle.Visible = False
SURTIR_NEG:     btn_surtir.Enabled = True
            Else
                lbl_error_surtir.Visible = True
                lbl_error_surtir_detalle.Text = cadena
                lbl_error_surtir_detalle.Visible = True
                btn_surtir.Enabled = False
                If bandera_insuficiente = True Then
                    If conf_pv(3) = 1 Then
                        If lbl_surtido.Text = "NO SURTIDO" Then
                            GoTo SURTIR_NEG
                        End If
                    End If
                End If
            End If
            '------------------------------------------------------------
        Else
            btn_surtir.Enabled = False
            lbl_error_surtir.Visible = False
            lbl_error_surtir_detalle.Visible = False

        End If
    End Sub

    Private Sub btn_surtir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_surtir.Click
        If MsgBox("Confirme que desea surtir este pedido. Los productos se daran de baja en el inventario", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            Dim bandera_correcto As Boolean = True
            For x = 0 To tabla_productos.Rows.Count - 1
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
                For x = 0 To tabla_productos.Rows.Count - 1

                    '---descontamos del inventario
                    conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & CDbl(dg_productos.Rows(x).Cells("cantidad").Value) & ") WHERE id_almacen='" & CType(cb_almacenes.SelectedItem, myItem).Value & "' AND id_producto=" & dg_productos.Rows(x).Cells("id_producto").Value) '--damos de baja del inventario
                    '--actualizamos el registro de sucursal
                    'conn.Execute("UPDATE detalle_pedido  SET id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value & ",id_sucursal=" & global_id_sucursal & ",nombre_almacen='" & cb_almacenes.Text & "',nombre_sucursal='" & global_nombre_sucursal & "' WHERE cantidad=" & CDbl(dg_productos.Rows(x).Cells("cantidad").Value) & " AND id_producto=" & dg_productos.Rows(x).Cells("id_producto").Value & " AND id_pedido=" & CurrentIDPedido)

                Next

                conn.Execute("UPDATE pedido_clientes  SET surtido=1, status='SURTIDO' WHERE id_pedido=" & CurrentIDPedido)
                'conn.close()
                'conn = Nothing
                cargar_detalle_pedido(CurrentIDPedido)
                MsgBox("Pedido surtido correctamente", MsgBoxStyle.Information, "Aviso")
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


    Private Sub cb_agente_entrega_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_agente_entrega.Click
        If lbl_surtido.Text = "NO SURTIDO" Then
            MsgBox("Debe surtir esteb pedido antes de seleccionar agente de entrega", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_enviar_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar_pedido.Click
        '---guardamos todos los datos del pedido
        If cb_agente_entrega.SelectedIndex = -1 Then
            MsgBox("Para poder enviar el pedido es necesario que seleccione el agente repartidor", MsgBoxStyle.Exclamation, "Aviso")
        Else
            If MsgBox("Confirme que desea enviar este pedido", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                '---actualizamos el detalle pedido
                'Conectar()
                For x = 0 To tabla_productos.Rows.Count - 1
                    Dim importe As Decimal = 0
                    If global_current_aplicar_redondeo Then
                        importe = redondear(FormatNumber((CDec(dg_productos.Rows(x).Cells("cantidad").Value) * CDec(dg_productos.Rows(x).Cells("precio").Value)), 2))
                    Else
                        importe = FormatNumber((CDec(dg_productos.Rows(x).Cells("cantidad").Value) * CDec(dg_productos.Rows(x).Cells("precio").Value)), 2)
                    End If

                    'conn.Execute("UPDATE detalle_pedido SET cantidad='" & dg_productos.Rows(x).Cells("cantidad").Value & "',descripcion='" & dg_productos.Rows(x).Cells("producto").Value & "',precio='" & dg_productos.Rows(x).Cells("precio").Value & "',importe='" & importe & "' WHERE id_pedido=" & CurrentIDPedido & " AND id_producto='" & dg_productos.Rows(x).Cells("id_producto").Value & "'")
                Next
                '--------------------------------
                conn.Execute("UPDATE pedido_clientes SET subtotal='" & Current_subtotal_pedido & "',total='" & current_total & "',id_empleado_entrega='" & CType(cb_agente_entrega.SelectedItem, myItem).Value & "' WHERE id_pedido='" & CurrentIDPedido & "'")

                '---lo mandamos  ventas
                'Dim id_pedido_venta As Integer
                ' conn.Execute("INSERT INTO venta(fecha,id_sucursal,id_empleado,id_empleado_caja,id_cliente,subtotal,total_iva,total_otros,total,credito,STATUS) (SELECT fecha_entrega,id_sucursal,id_empleado,'" & global_id_empleado & "',id_cliente,subtotal,iva,otros_impuestos,total,'1','PENDIENTE' FROM pedido_clientes WHERE id_pedido=" & CurrentIDPedido & ")")
                ' rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                'id_pedido_venta = rs.Fields(0).Value
                'rs.Close()
                'conn.Execute("UPDATE venta SET num_ticket=" & id_pedido_venta & " WHERE id_venta=" & id_pedido_venta)
                'conn.Execute("UPDATE pedido_clientes SET id_venta=" & id_pedido_venta & ",status='ENVIADO' WHERE id_pedido=" & CurrentIDPedido)
                'For x = 0 To tabla_productos.Rows.Count - 1
                'conn.Execute("INSERT INTO venta_detalle(id_venta,id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,importe) (SELECT '" & id_pedido_venta & "',id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,importe FROM detalle_pedido WHERE id_pedido='" & CurrentIDPedido & "' AND id_producto='" & dg_productos.Rows(x).Cells("id_producto").Value & "')")
                'Next
                '-------------------------------
                'conn.close()
                'conn = Nothing

                For x = 0 To 1
                    imprimir_ticket_pedido_pagare(CurrentIDPedido, x)
                Next

                If conf_pv(9) = 1 Then
                    If conf_pv(16) = 1 Then
                        If conf_pv_id_formato(1) = 2 Then
                            Generar_orden_entrega(current_id_venta_pedido)
                        End If
                    Else
                        imprimir_orden_entrega(current_id_venta_pedido, 0)
                    End If
                End If

                cargar_detalle_pedido(CurrentIDPedido)
            End If
        End If
        '---------------------------------------
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
    Private Sub realizar_retiro()
        Dim saldo_inicial As Decimal = 0
        Dim total_ventas As Decimal = total_efectivo()
        Dim total_retiros As Decimal = retiros()
        Dim saldo_caja As Decimal = 0
        If cb_agente_entrega.SelectedIndex <> -1 Then

            If Trim(tb_diferencia.TextLength) = 0 Then
                MsgBox("La diferencia no puede ser 0", MsgBoxStyle.Exclamation, "Aviso")
            Else
                If tb_diferencia.Text > 0 Then
                    'Conectar()
                    rs.Open("SELECT saldo_inicial from caja_saldo_inicial WHERE id_empleado='" & global_id_empleado & "' AND date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND bandera_corte_caja=0", conn)
                    If rs.RecordCount > 0 Then
                        saldo_inicial = rs.Fields("saldo_inicial").Value
                    End If
                    rs.Close()
                    'conn.close()
                    'conn = Nothing
                    saldo_caja = saldo_inicial + total_ventas - total_retiros
                    If CDec(tb_diferencia.Text) <= saldo_caja Then
                        If MsgBox("Confirme que desea retirar " & FormatCurrency(tb_diferencia.Text) & " para " & cb_agente_entrega.Text, MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                            'Conectar()
                            conn.Execute("INSERT INTO retiros(fecha,cantidad,descripcion,id_empleado,id_sucursal) VALUES(NOW(),'" & CDec(tb_diferencia.Text) & "','Para " & cb_agente_entrega.Text & " en entrega de cambio del pedido " & CurrentIDPedido & "', '" & global_id_empleado & "', '" & global_id_sucursal & "')")
                            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            conn.Execute("UPDATE pedido_clientes SET id_retiro='" & rs.Fields(0).Value & "', id_empleado_entrega='" & CType(cb_agente_entrega.SelectedItem, myItem).Value & "' WHERE id_pedido='" & CurrentIDPedido & "'")
                            current_id_retiro = rs.Fields(0).Value
                            cb_agente_entrega.Enabled = False
                            rs.Close()
                            'conn.close()
                            'conn = Nothing
                            Dim x As Integer
                            If MsgBox("A continuación se imprimirá el ticket de retiro de efectivo. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                                For x = 0 To 1
                                    If conf_pv(21) = 0 Then
                                        imprimir_recibo_retiro_termica(global_usuario_nombre, CDec(tb_diferencia.Text), "Para " & cb_agente_entrega.Text & " en entrega de cambio del pedido " & CurrentIDPedido, x)
                                    Else
                                        imprimir_recibo_retiro_matriz(global_usuario_nombre, CDec(tb_diferencia.Text), "Para " & cb_agente_entrega.Text & " en entrega de cambio del pedido " & CurrentIDPedido, x)
                                    End If
                                Next
                            Else
                                If conf_pv(21) = 0 Then
                                    imprimir_recibo_retiro_termica(global_usuario_nombre, CDec(tb_diferencia.Text), "Para " & cb_agente_entrega.Text & " en entrega de cambio del pedido " & CurrentIDPedido, 0)
                                Else
                                    imprimir_recibo_retiro_matriz(global_usuario_nombre, CDec(tb_diferencia.Text), "Para " & cb_agente_entrega.Text & " en entrega de cambio del pedido " & CurrentIDPedido, 0)
                                End If
                            End If
                            cargar_detalle_pedido(CurrentIDPedido)
                            MsgBox("Retiro guardado correctamente", MsgBoxStyle.Information, "Correcto")

                        End If
                    Else
                        MsgBox("No se puede retirar esta cantidad,Excede el saldo actual de " & FormatCurrency(saldo_caja), MsgBoxStyle.Exclamation, "Aviso")
                    End If
                Else
                    MsgBox("la diferencia no puede ser igual o menor a cero", MsgBoxStyle.Exclamation, "Aviso")
                End If
            End If
        Else
            MsgBox("Seleccione el agente de entrega", MsgBoxStyle.Exclamation, "Aviso")
        End If


    End Sub
    Private Sub cancelar_retiro()
        If MsgBox("Confirme que desea cancelar el retiro", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("DELETE FROM retiros WHERE id_retiro='" & current_id_retiro & "'")
            conn.Execute("UPDATE pedido_clientes SET id_retiro='0' WHERE id_pedido='" & CurrentIDPedido & "'")
            cargar_detalle_pedido(CurrentIDPedido)
            MsgBox("Retiro cancelado correctamente", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_retiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_retiro.Click
        If current_id_retiro > 0 Then
            cancelar_retiro()
        Else
            realizar_retiro()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcular.Click
        tb_diferencia.Text = CDec(tb_total_recibir.Text) - current_total
    End Sub

    Private Sub btn_recibir_nota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_recibir_nota.Click
        If MsgBox("Confirme que desea registrar que el pedido ha sido suministrado y se recibe nota", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("UPDATE pedido_clientes SET status='SUMINISTRADO', status_pago='NOTA' WHERE id_pedido='" & CurrentIDPedido & "'")
            'conn.close()
            'conn = Nothing
            cargar_detalle_pedido(CurrentIDPedido)

        End If
    End Sub

    Private Sub btn_recibir_pago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_recibir_pago.Click
        Dim num_ticket As Integer
        'Conectar()
        rs.Open("SELECT id_venta FROM pedido_clientes WHERE id_pedido='" & CurrentIDPedido & "'", conn)
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

    Private Sub btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Imprimir.Click
        If conf_pv(16) = 1 Then
            If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                Generar_Formato_venta_retail(current_id_venta_pedido, current_id_venta_cancelado)
            ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                Generar_Formato_venta_retail_media(current_id_venta_pedido, current_id_venta_cancelado, False)
            ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                Generar_Formato_venta_apartado(current_id_venta_pedido)
            End If
        Else
            If MsgBox("A continuación se imprimirá el ticket de pedido. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                For x = 0 To 1
                    imprimir_ticket_pedido_pagare(CurrentIDPedido, 0)
                Next
            Else
                imprimir_ticket_pedido_pagare(CurrentIDPedido, 0)
            End If

        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        If MsgBox("Se cancelará este pedido y todos los pagos que se hayan realizado, ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("UPDATE pedido_clientes SET status='CANCELADO' WHERE id_pedido='" & CurrentIDPedido & "'")
            conn.Execute("UPDATE pagos_ventas SET status='CANCELADO', fecha_cancelacion=NOW() WHERE id_venta='" & current_id_venta_pedido & "' AND status='ACTIVO'")
            conn.Execute("UPDATE venta SET status='CANCELADA' WHERE id_venta='" & current_id_venta_pedido & "'")
            cargar_detalle_pedido(CurrentIDPedido)
            MsgBox("Pedido cancelado correctamente0", MsgBoxStyle.Information, "Aviso")
        End If

    End Sub
End Class