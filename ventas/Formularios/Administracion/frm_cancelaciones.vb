Public Class Frm_cancelaciones
    Dim ds, dsp, dsps As DataSet
    Dim tabla, tabla_productos_cancelacion As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Private current_id_venta_doc As Integer
    Public current_id_doc As Integer
    Public current_id_venta_cancelado As Boolean
    Private cargado As Boolean
    Private tipo_movimiento As String = ""
    Private Sub estilo_productos_cancelacion()
        tabla_productos_cancelacion = New DataTable("productos_cancelacion")
        With tabla_productos_cancelacion.Columns
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
        dsp.Tables.Add(tabla_productos_cancelacion)

        With dgv_producto_cancelacion
            .DataSource = dsp
            .DataMember = "productos_cancelacion"

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
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("producto")
                .HeaderText = "Producto"
                .Width = 180
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
                .Width = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
        End With
    End Sub
    Private Sub agregar_productos_cancelacion(ByVal producto As String, ByVal id_producto As Integer, ByVal miniatura As Object, ByVal cantidad As Decimal, ByVal unidad As String, ByVal precio As Decimal, ByVal total As Decimal)
        tabla_linea = tabla_productos_cancelacion.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("miniatura") = miniatura
        tabla_linea("producto") = producto
        tabla_linea("unidad") = unidad
        tabla_linea("cantidad") = cantidad
        tabla_linea("precio") = precio
        tabla_linea("total") = total
        tabla_productos_cancelacion.Rows.Add(tabla_linea)
    End Sub
    Private Sub Frm_cancelaciones_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_cancelaciones = 0
    End Sub
    Private Sub Frm_cancelaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        global_frm_cancelaciones = 1
        estilo_buscar_doc(dgv_busqueda)
        estilo_productos_cancelacion()
        estilo_tabla_abono_cancelaciones(dgv_abonos)
        cargar_opciones_busqueda()
        cargado = True
        buscar_documentos(cb_opciones_busqueda.SelectedIndex)
    End Sub
    Private Sub cargar_opciones_busqueda()
        cb_opciones_busqueda.Items.Clear()
        cb_opciones_busqueda.Text = ""
        cb_opciones_busqueda.Items.Add("TODOS")
        cb_opciones_busqueda.Items.Add("POR FECHA")
        cb_opciones_busqueda.Items.Add("POR PERIODO")
        cb_opciones_busqueda.SelectedIndex = 1
        dtp_fecha_busqueda.Value = Today
    End Sub
    Private Sub buscar_documentos(ByVal index_opcion_busqueda As Integer)
        Dim consulta As String = ""
        Dim filtro As String = ""
        If Trim(tb_cliente_busqueda.Text) <> "" Then
            filtro = " AND (e.alias LIKE '%" & tb_cliente_busqueda.Text & "%'" & _
                   " OR e.razon_social LIKE '%" & tb_cliente_busqueda.Text & "%'" & _
                   " OR p.alias LIKE '%" & tb_cliente_busqueda.Text & "%'" & _
                   " OR p.nombre LIKE '%" & tb_cliente_busqueda.Text & "%'" & _
                   " OR p.ap_paterno LIKE '%" & tb_cliente_busqueda.Text & "%'" & _
                   " OR p.ap_materno LIKE '%" & tb_cliente_busqueda.Text & "%') "

        End If

        If index_opcion_busqueda = 0 Then
            If rb_buscar_nota.Checked = True Then
                consulta = "SELECT v.id_venta AS id,v.fecha AS fecha,v.total AS total,v.status AS estatus, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
            "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
            "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
            "JOIN venta v ON v.id_cliente=c.id_cliente " & _
             "WHERE 1 " & filtro & " AND v.status='CERRADA' OR v.status='CANCELADA' OR v.status='REABIERTA'" & _
            "ORDER BY v.id_venta DESC"

            ElseIf rb_buscar_pedido.Checked = True Then
                consulta = "SELECT pc.id_pedido AS id,pc.fecha_pedido AS fecha,pc.total AS total,pc.status AS estatus, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
               "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
               "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
               "JOIN pedido_clientes pc ON pc.id_cliente=c.id_cliente " & _
                "WHERE 1 " & filtro & " " & _
               "ORDER BY pc.id_pedido DESC"

            ElseIf rb_buscar_apartado.Checked = True Then
                consulta = "SELECT ap.id_apartado AS id,ap.fecha_apartado AS fecha,ap.total AS total,ap.status AS estatus, CASE WHEN p.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
                "JOIN apartado ap ON ap.id_cliente=c.id_cliente " & _
                "WHERE 1 " & filtro & " " & _
                "ORDER BY ap.id_apartado DESC"
            ElseIf rb_buscar_credito.Checked = True Then
                consulta = "SELECT v.id_venta AS id,v.fecha AS fecha,v.total AS total,v.status AS estatus, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
           "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
           "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
           "JOIN venta v ON v.id_cliente=c.id_cliente " & _
            "WHERE 1 " & filtro & " AND v.status='PENDIENTE'" & _
           "ORDER BY v.id_venta DESC"
            ElseIf rb_buscar_compra.Checked = True Then
                consulta = "SELECT fc.id_factura_compra AS id,fc.fecha AS fecha,fc.total AS total,fc.status AS estatus, CASE WHEN pv.id_persona = 0 THEN  e.alias ELSE p.alias END AS proveedor_alias FROM proveedor pv " & _
               "LEFT OUTER JOIN persona p ON pv.id_persona = p.id_persona " & _
               "LEFT OUTER JOIN empresa e ON pv.id_empresa = e.id_empresa " & _
               "JOIN factura_compra fc ON fc.id_proveedor=pv.id_proveedor " & _
               "WHERE 1 " & filtro & " " & _
               "ORDER BY fc.id_factura_compra DESC"
            ElseIf rb_buscar_traspaso_env.Checked = True Then
                consulta = "SELECT te.id_traspaso_env AS id,te.fecha AS fecha,0 AS total,te.status AS estatus FROM traspaso_env te " & _
             "WHERE 1 " & filtro & " " & _
             "ORDER BY te.id_traspaso_env DESC"
            ElseIf rb_buscar_traspaso_recep.Checked = True Then
                consulta = "SELECT tr.id_traspaso_recep AS id,tr.fecha AS fecha,0 AS total,tr.status AS estatus FROM traspaso_recep tr " & _
         "WHERE 1 " & filtro & " " & _
         " ORDER BY tr.id_traspaso_recep DESC"
            End If

        ElseIf index_opcion_busqueda = 1 Then
            If rb_buscar_nota.Checked = True Then
                consulta = "SELECT v.id_venta AS id,v.fecha AS fecha,v.total AS total,v.status AS estatus,v.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
            "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
            "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
            "JOIN venta v ON v.id_cliente=c.id_cliente " & _
             "WHERE 1 " & filtro & " AND DATE(v.fecha)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "' AND (v.status='CERRADA' OR v.status='CANCELADA') " & _
            "ORDER BY v.id_venta DESC"

            ElseIf rb_buscar_pedido.Checked = True Then
                consulta = "SELECT pc.id_pedido AS id,pc.fecha_pedido AS fecha,pc.total AS total,pc.status AS estatus,pc.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
               "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
               "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
               "JOIN pedido_clientes pc ON pc.id_cliente=c.id_cliente " & _
                "WHERE 1 " & filtro & " AND DATE(pc.fecha_pedido)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "' " & _
               "ORDER BY pc.id_pedido DESC"

            ElseIf rb_buscar_apartado.Checked = True Then
                consulta = "SELECT ap.id_apartado AS id,ap.fecha_apartado AS fecha,ap.total AS total,ap.status AS estatus,ap.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
                "JOIN apartado ap ON ap.id_cliente=c.id_cliente " & _
                "WHERE 1 " & filtro & " AND DATE(ap.fecha_apartado)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "' " & _
                "ORDER BY ap.id_apartado DESC"
            ElseIf rb_buscar_credito.Checked = True Then
                consulta = "SELECT v.id_venta AS id,v.fecha AS fecha,v.total AS total,v.status AS estatus,v.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
           "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
           "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
           "JOIN venta v ON v.id_cliente=c.id_cliente " & _
            "WHERE 1 " & filtro & " AND DATE(v.fecha)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "' AND v.status='PENDIENTE' " & _
           "ORDER BY v.id_venta DESC"
            ElseIf rb_buscar_compra.Checked = True Then
                consulta = "SELECT fc.id_factura_compra AS id,fc.fecha AS fecha,fc.total AS total,fc.status AS estatus, CASE WHEN pv.id_persona = 0 THEN  e.alias ELSE p.alias END AS proveedor_alias FROM proveedor pv " & _
               "LEFT OUTER JOIN persona p ON pv.id_persona = p.id_persona " & _
               "LEFT OUTER JOIN empresa e ON pv.id_empresa = e.id_empresa " & _
               "JOIN factura_compra fc ON fc.id_proveedor=pv.id_proveedor " & _
               "WHERE 1 " & filtro & " AND DATE(fc.fecha)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "' " & _
               "ORDER BY fc.id_factura_compra DESC"
            ElseIf rb_buscar_traspaso_env.Checked = True Then
                consulta = "SELECT te.id_traspaso_env AS id,te.fecha AS fecha,0 AS total,te.status AS estatus FROM traspaso_env te " & _
             "WHERE 1 " & filtro & " AND DATE(te.fecha)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "'" & _
             "ORDER BY te.id_traspaso_env DESC"
            ElseIf rb_buscar_traspaso_recep.Checked = True Then
                consulta = "SELECT tr.id_traspaso_recep AS id,tr.fecha AS fecha,0 AS total,tr.status AS estatus FROM traspaso_recep tr " & _
    "WHERE 1 " & filtro & " AND DATE(tr.fecha)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "'" & _
    " ORDER BY tr.id_traspaso_recep DESC"
            End If

        ElseIf index_opcion_busqueda = 2 Then
            If rb_buscar_nota.Checked = True Then
                consulta = "SELECT v.id_venta AS id,v.fecha AS fecha,v.total AS total,v.status AS estatus,v.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
            "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
            "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
            "JOIN venta v ON v.id_cliente=c.id_cliente " & _
             "WHERE 1 " & filtro & " AND DATE(v.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "' AND (v.status='CERRADA'OR v.status='CANCELADA') " & _
            "ORDER BY v.id_venta DESC"

            ElseIf rb_buscar_pedido.Checked = True Then
                consulta = "SELECT pc.id_pedido AS id,pc.fecha_pedido AS fecha,pc.total AS total,pc.status AS estatus,pc.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
               "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
               "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
               "JOIN pedido_clientes pc ON pc.id_cliente=c.id_cliente " & _
                "WHERE 1 " & filtro & " AND DATE(pc.fecha_pedido) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "' " & _
               "ORDER BY pc.id_pedido DESC"

            ElseIf rb_buscar_apartado.Checked = True Then
                consulta = "SELECT ap.id_apartado AS id,ap.fecha_apartado AS fecha,ap.total AS total,ap.status AS estatus,ap.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
                "JOIN apartado ap ON ap.id_cliente=c.id_cliente " & _
                "WHERE 1 " & filtro & " AND DATE(ap.fecha_apartado) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "' " & _
                "ORDER BY ap.id_apartado DESC"
            ElseIf rb_buscar_credito.Checked = True Then
                consulta = "SELECT v.id_venta AS id,v.fecha AS fecha,v.total AS total,v.status AS estatus,v.total AS total, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
         "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
         "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
         "JOIN venta v ON v.id_cliente=c.id_cliente " & _
          "WHERE 1 " & filtro & " AND DATE(v.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "' AND v.status='PENDIENTE' " & _
         "ORDER BY v.id_venta DESC"
            ElseIf rb_buscar_compra.Checked = True Then
                consulta = "SELECT fc.id_factura_compra AS id,fc.fecha AS fecha,fc.total AS total,fc.status AS estatus, CASE WHEN pv.id_persona = 0 THEN  e.alias ELSE p.alias END AS proveedor_alias FROM proveedor pv " & _
               "LEFT OUTER JOIN persona p ON pv.id_persona = p.id_persona " & _
               "LEFT OUTER JOIN empresa e ON pv.id_empresa = e.id_empresa " & _
               "JOIN factura_compra fc ON fc.id_proveedor=pv.id_proveedor " & _
               "WHERE 1 " & filtro & " AND DATE(fc.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "'" & _
               "ORDER BY fc.id_factura_compra DESC"
            ElseIf rb_buscar_traspaso_env.Checked = True Then
                consulta = "SELECT te.id_traspaso_env AS id,te.fecha AS fecha,0 AS total,te.status AS estatus FROM traspaso_env te " & _
             "WHERE 1 " & filtro & " AND DATE(te.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "'" & _
             "ORDER BY te.id_traspaso_env DESC"
            ElseIf rb_buscar_traspaso_recep.Checked = True Then
                consulta = "SELECT tr.id_traspaso_recep AS id,tr.fecha AS fecha,0 AS total,tr.status AS estatus FROM traspaso_recep tr " & _
  "WHERE 1 " & filtro & " AND DATE(tr.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "'" & _
  " ORDER BY tr.id_traspaso_recep DESC"
            End If
        End If

        tabla_buscar_doc.Clear()
        rs.Open(consulta, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim cancelado As Boolean = False
                Dim fecha As DateTime = rs.Fields("fecha").Value
                If rs.Fields("estatus").Value = "CANCELADO" Then
                    cancelado = True
                ElseIf rs.Fields("estatus").Value = "CANCELADA" Then
                    cancelado = True
                End If
                agregar_tabla_buscar_doc(rs.Fields("id").Value, tipo_movimiento & " - " & rs.Fields("id").Value, fecha.ToShortDateString, rs.Fields("total").Value, cancelado)
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Private Sub cb_opciones_busqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_opciones_busqueda.SelectedIndexChanged
        If cb_opciones_busqueda.SelectedIndex <> -1 Then
            If cb_opciones_busqueda.SelectedIndex = 0 Then
                dtp_fecha_busqueda.Visible = False
                dtp_fecha_inicio.Visible = False
                dtp_fecha_termino.Visible = False
                Label1.Visible = False
                Label2.Visible = False
            ElseIf cb_opciones_busqueda.SelectedIndex = 1 Then
                dtp_fecha_busqueda.Visible = True
                dtp_fecha_inicio.Visible = False
                dtp_fecha_termino.Visible = False
                Label1.Visible = False
                Label2.Visible = False
            ElseIf cb_opciones_busqueda.SelectedIndex = 2 Then
                dtp_fecha_busqueda.Visible = False
                dtp_fecha_inicio.Visible = True
                dtp_fecha_termino.Visible = True
                Label1.Visible = True
                Label2.Visible = True
            End If
        End If
        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub dtp_fecha_busqueda_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_busqueda.ValueChanged
        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub dtp_fecha_termino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_termino.ValueChanged
        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub dtp_fecha_inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_inicio.ValueChanged
        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub tb_cliente_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cliente_busqueda.TextChanged
        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub rb_buscar_nota_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_nota.CheckedChanged
        If rb_buscar_nota.Checked = True Then
            tipo_movimiento = "Venta"
            gb_datos_clientes.Visible = True
            gb_datos_compra.Visible = False
            gb_traspaso_envio.Visible = False
            gb_traspaso_recepcion.Visible = False
            rb_buscar_apartado.Checked = False
            rb_buscar_pedido.Checked = False
            rb_buscar_compra.Checked = False
            rb_buscar_credito.Checked = False
            rb_buscar_traspaso_env.Checked = False
            rb_buscar_traspaso_recep.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub rb_buscar_pedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_pedido.CheckedChanged
        If rb_buscar_pedido.Checked = True Then
            tipo_movimiento = "Pedido"
            gb_datos_clientes.Visible = True
            gb_datos_compra.Visible = False
            gb_traspaso_envio.Visible = False
            gb_traspaso_recepcion.Visible = False
            rb_buscar_apartado.Checked = False
            rb_buscar_nota.Checked = False
            rb_buscar_compra.Checked = False
            rb_buscar_credito.Checked = False
            rb_buscar_traspaso_env.Checked = False
            rb_buscar_traspaso_recep.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub rb_buscar_apartado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_apartado.CheckedChanged
        If rb_buscar_apartado.Checked = True Then
            tipo_movimiento = "Apartado"
            gb_datos_clientes.Visible = True
            gb_datos_compra.Visible = False
            gb_traspaso_envio.Visible = False
            gb_traspaso_recepcion.Visible = False
            rb_buscar_nota.Checked = False
            rb_buscar_pedido.Checked = False
            rb_buscar_compra.Checked = False
            rb_buscar_credito.Checked = False
            rb_buscar_traspaso_env.Checked = False
            rb_buscar_traspaso_recep.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub
    Private Sub dgv_busqueda_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_busqueda.CellDoubleClick
        If dgv_busqueda.Rows.Count > 0 Then
            cargar_documento(dgv_busqueda.Rows(dgv_busqueda.CurrentRow.Index).Cells("id_doc").Value)
        End If
    End Sub

    Private Sub dgv_busqueda_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_busqueda.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 8, FontStyle.Regular)
        For x = 0 To dgv_busqueda.Columns.Count - 1
            If dgv_busqueda.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Public Sub cargar_documento(ByVal id_doc As Integer)
        current_id_doc = id_doc
        current_id_venta_cancelado = False
        tb_tipo_movimiento.Text = UCase(tipo_movimiento)
        If rb_buscar_nota.Checked = True Then 'BUSCAMOS NOTAS DE VENTA
            '===============CARGAR DETALLE DE LA VENTA EN EXISTENCIA CERRADA=======================
            current_id_venta_doc = id_doc
            Dim id_cliente As Integer = 0
            Dim fecha_venta As DateTime
            Dim id_domicilio As Integer = 0
            Dim total_abonos As Decimal = 0
            Dim total_venta As Decimal = 0
            Dim estatus_venta As String = ""
            rs.Open("SELECT venta.fecha,venta.id_cliente,venta.desc_global_porcent,venta.desc_global_importe,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado_venta,venta.total,venta.status,venta.subtotal,venta.total_impuestos,venta.total_descuento " & _
               "FROM venta JOIN empleado ON empleado.id_empleado=venta.id_empleado " & _
               "JOIN persona ON persona.id_persona=empleado.id_persona WHERE venta.id_venta=" & id_doc, conn)
            If rs.RecordCount > 0 Then
                tb_folio.Text = id_doc
                id_cliente = rs.Fields("id_cliente").Value
                fecha_venta = rs.Fields("fecha").Value
                tb_vendedor.Text = rs.Fields("empleado_venta").Value
                total_venta = rs.Fields("total").Value
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                If rs.Fields("desc_global_importe").Value > 0 Then
                    tb_descuento.Text = FormatCurrency(rs.Fields("desc_global_importe").Value)
                Else
                    tb_descuento.Text = FormatCurrency(rs.Fields("total_descuento").Value)
                End If

                tb_impuestos.Text = FormatCurrency(rs.Fields("total_impuestos").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)
                estatus_venta = rs.Fields("status").Value
                tb_estatus.Text = rs.Fields("status").Value

            End If
            rs.Close()
            dtp_fecha.Value = fecha_venta
            dtp_hora.Value = fecha_venta

            rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " & _
                      "FROM cliente " & _
                      "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                      "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                      "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                tb_cliente.Text = rs.Fields("cliente").Value
            End If
            rs.Close()

            rs.Open("SELECT id_domicilio FROM cliente WHERE id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                id_domicilio = rs.Fields("id_domicilio").Value

            End If
            rs.Close()

            rs.Open("SELECT Concat(calle,' ',num_ext,' ',' ',num_int,', ',colonia,', ',municipio,', ',if(cp='','',concat(' C.P. ',cp)) ) domicilio, CONCAT(poblacion,', ',estado,', ',pais) AS ciudad FROM domicilio WHERE id_domicilio='" & id_domicilio & "'", conn)
            If rs.RecordCount > 0 Then
                tb_direccion.Text = rs.Fields("domicilio").Value & " " & rs.Fields("ciudad").Value
            End If
            rs.Close()


            rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total_abonos " & _
                  "FROM pagos_ventas  " & _
                  "WHERE id_venta='" & id_doc & "' AND status='ACTIVO'", conn)
            If rs.RecordCount > 0 Then
                total_abonos = rs.Fields("total_abonos").Value
            End If
            rs.Close()
            lbl_cobros.Text = FormatCurrency(total_abonos)
            lbl_saldo.Text = FormatCurrency(total_venta - total_abonos)

            If estatus_venta = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
                current_id_venta_cancelado = False
            ElseIf estatus_venta = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
                current_id_venta_cancelado = True
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,p.thumb,vd.id_almacen " & _
                    "FROM venta_detalle vd " & _
                    "JOIN producto p ON p.id_producto=vd.id_producto WHERE vd.id_venta='" & id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, rs.Fields("importe").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tabla_abono_cancelaciones.Clear()
            rs.Open("SELECT pv.id_pagos_ventas,pv.importe,pv.id_forma_pago,pv.fecha,pv.fecha_cobro,pv.status, CONCAT(p.nombre,' ',p.ap_paterno) AS empleado_caja " &
                    "FROM pagos_ventas pv " &
                    " JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                    " JOIN persona p ON p.id_persona=e.id_persona " &
                    "WHERE pv.id_venta='" & id_doc & "' ORDER by fecha_cobro", conn)
            Dim i = 0
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_abono_cancelaciones(rs.Fields("id_pagos_ventas").Value, Format(rs.Fields("fecha").Value, "dd-MM-yyyy"), Format(rs.Fields("fecha_cobro").Value, "dd-MM-yyyy"), nombre_forma_pago(rs.Fields("id_forma_pago").Value), FormatCurrency(rs.Fields("importe").Value), rs.Fields("empleado_caja").Value, rs.Fields("status").Value)
                    rs.MoveNext()
                End While

            End If
            rs.Close()

        ElseIf rb_buscar_apartado.Checked = True Then 'BUSCAMOS APARTADOS
            '===============CARGAR DETALLLE DEL APARTADO=======================
            Dim id_cliente As Integer = 0
            Dim fecha_apartado As DateTime
            Dim id_domicilio As Integer = 0
            Dim total_abonos As Decimal = 0
            Dim total_apartado As Decimal = 0
            Dim estatus_entregado As String = ""
            Dim estatus_apatado As String = ""

            rs.Open("SELECT apartado.fecha_apartado,apartado.id_cliente,apartado.subtotal,apartado.iva,apartado.otros_impuestos,apartado.total,apartado.entregado,apartado.id_venta,apartado.status," & _
                    "venta.total_descuento,venta.desc_global_importe,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado_venta " & _
                "FROM apartado " & _
                "JOIN venta ON venta.id_venta=apartado.id_venta " & _
                "JOIN empleado ON empleado.id_empleado=venta.id_empleado " & _
            "JOIN persona ON persona.id_persona=empleado.id_persona WHERE apartado.id_apartado=" & id_doc, conn)
            If rs.RecordCount > 0 Then
                tb_folio.Text = id_doc
                current_id_venta_doc = rs.Fields("id_venta").Value
                id_cliente = rs.Fields("id_cliente").Value
                fecha_apartado = rs.Fields("fecha_apartado").Value
                tb_vendedor.Text = rs.Fields("empleado_venta").Value
                total_apartado = rs.Fields("total").Value
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                estatus_apatado = rs.Fields("status").Value
                If rs.Fields("desc_global_importe").Value > 0 Then
                    tb_descuento.Text = FormatCurrency(rs.Fields("desc_global_importe").Value)
                Else
                    tb_descuento.Text = FormatCurrency(rs.Fields("total_descuento").Value)
                End If

                tb_impuestos.Text = FormatCurrency(rs.Fields("iva").Value + rs.Fields("otros_impuestos").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)

                If rs.Fields("entregado").Value = 1 Then
                    estatus_entregado = "ENTREGADO"
                Else
                    estatus_entregado = "NO ENTREGADO"
                End If
                tb_estatus.Text = estatus_entregado

                ' descuento_global_porcentual = rs.Fields("desc_global_porcent").Value
                'descuento_global_importe = rs.Fields("desc_global_importe").Value
            End If
            rs.Close()
            dtp_fecha.Value = fecha_apartado
            dtp_hora.Value = fecha_apartado

            rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " & _
                      "FROM cliente " & _
                      "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                      "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                      "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                tb_cliente.Text = rs.Fields("cliente").Value
            End If
            rs.Close()

            rs.Open("SELECT id_domicilio FROM cliente WHERE id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                id_domicilio = rs.Fields("id_domicilio").Value

            End If
            rs.Close()

            rs.Open("SELECT Concat(calle,' ',num_ext,' ',' ',num_int,', ',colonia,', ',municipio,', ',if(cp='','',concat(' C.P. ',cp)) ) domicilio, CONCAT(poblacion,', ',estado,', ',pais) AS ciudad FROM domicilio WHERE id_domicilio='" & id_domicilio & "'", conn)
            If rs.RecordCount > 0 Then
                tb_direccion.Text = rs.Fields("domicilio").Value & " " & rs.Fields("ciudad").Value
            End If
            rs.Close()


            rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total_abonos " & _
                  "FROM pagos_ventas  " & _
                  "WHERE id_venta='" & current_id_venta_doc & "' AND status='ACTIVO'", conn)
            If rs.RecordCount > 0 Then
                total_abonos = rs.Fields("total_abonos").Value
            End If
            rs.Close()
            lbl_cobros.Text = FormatCurrency(total_abonos)
            lbl_saldo.Text = FormatCurrency(total_apartado - total_abonos)

            If estatus_apatado = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            ElseIf estatus_apatado = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,p.thumb,vd.id_almacen " & _
                    "FROM venta_detalle vd " & _
                    "JOIN producto p ON p.id_producto=vd.id_producto WHERE vd.id_venta='" & current_id_venta_doc & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, rs.Fields("importe").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tabla_abono_cancelaciones.Clear()
            rs.Open("SELECT pv.id_pagos_ventas,pv.importe,pv.id_forma_pago,pv.fecha,pv.fecha_cobro,pv.status, CONCAT(p.nombre,' ',p.ap_paterno) AS empleado_caja " &
                    "FROM pagos_ventas pv " &
                    " JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                    " JOIN persona p ON p.id_persona=e.id_persona " &
                    "WHERE pv.id_venta='" & current_id_venta_doc & "' ORDER by fecha_cobro", conn)
            Dim i = 0
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_abono_cancelaciones(rs.Fields("id_pagos_ventas").Value, Format(rs.Fields("fecha").Value, "dd-MM-yyyy"), Format(rs.Fields("fecha_cobro").Value, "dd-MM-yyyy"), nombre_forma_pago(rs.Fields("id_forma_pago").Value), FormatCurrency(rs.Fields("importe").Value), rs.Fields("empleado_caja").Value, rs.Fields("status").Value)
                    rs.MoveNext()
                End While

            End If
            rs.Close()

        ElseIf rb_buscar_pedido.Checked = True Then
            '===============CARGAR DETALLLE DEL PEDIDO=======================
            Dim id_cliente As Integer = 0
            Dim fecha_pedido As DateTime
            Dim id_domicilio As Integer = 0
            Dim total_abonos As Decimal = 0
            Dim total_pedido As Decimal = 0
            Dim estatus_pedido As String = ""

            rs.Open("SELECT pedido_clientes.fecha_pedido,pedido_clientes.id_cliente,pedido_clientes.subtotal,pedido_clientes.iva,pedido_clientes.otros_impuestos,pedido_clientes.total,pedido_clientes.status,pedido_clientes.status,pedido_clientes.id_venta," & _
                    "CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado_venta " & _
                "FROM pedido_clientes " & _
               "JOIN empleado ON empleado.id_empleado=pedido_clientes.id_empleado " & _
            "JOIN persona ON persona.id_persona=empleado.id_persona WHERE pedido_clientes.id_pedido=" & id_doc, conn)

            If rs.RecordCount > 0 Then
                tb_folio.Text = id_doc
                current_id_venta_doc = rs.Fields("id_venta").Value
                id_cliente = rs.Fields("id_cliente").Value
                fecha_pedido = rs.Fields("fecha_pedido").Value
                tb_vendedor.Text = rs.Fields("empleado_venta").Value
                total_pedido = rs.Fields("total").Value
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)

                tb_descuento.Text = FormatCurrency(0)

                tb_impuestos.Text = FormatCurrency(rs.Fields("iva").Value + rs.Fields("otros_impuestos").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)
                tb_estatus.Text = rs.Fields("status").Value
                estatus_pedido = rs.Fields("status").Value
            End If

            rs.Close()
            dtp_fecha.Value = fecha_pedido
            dtp_hora.Value = fecha_pedido

            rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " & _
                      "FROM cliente " & _
                      "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                      "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                      "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                tb_cliente.Text = rs.Fields("cliente").Value
            End If
            rs.Close()

            rs.Open("SELECT id_domicilio FROM cliente WHERE id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                id_domicilio = rs.Fields("id_domicilio").Value

            End If
            rs.Close()

            rs.Open("SELECT Concat(calle,' ',num_ext,' ',' ',num_int,', ',colonia,', ',municipio,', ',if(cp='','',concat(' C.P. ',cp)) ) domicilio, CONCAT(poblacion,', ',estado,', ',pais) AS ciudad FROM domicilio WHERE id_domicilio='" & id_domicilio & "'", conn)
            If rs.RecordCount > 0 Then
                tb_direccion.Text = rs.Fields("domicilio").Value & " " & rs.Fields("ciudad").Value
            End If
            rs.Close()


            rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total_abonos " & _
                  "FROM pagos_ventas  " & _
                  "WHERE id_venta='" & current_id_venta_doc & "' AND status='ACTIVO'", conn)
            If rs.RecordCount > 0 Then
                total_abonos = rs.Fields("total_abonos").Value
            End If
            rs.Close()
            lbl_cobros.Text = FormatCurrency(total_abonos)
            lbl_saldo.Text = FormatCurrency(total_pedido - total_abonos)

            If estatus_pedido = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            ElseIf estatus_pedido = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,p.thumb,vd.id_almacen " & _
                    "FROM venta_detalle vd " & _
                    "JOIN producto p ON p.id_producto=vd.id_producto WHERE vd.id_venta='" & current_id_venta_doc & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, rs.Fields("importe").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tabla_abono_cancelaciones.Clear()
            rs.Open("SELECT pv.id_pagos_ventas,pv.importe,pv.id_forma_pago,pv.fecha,pv.fecha_cobro,pv.status, CONCAT(p.nombre,' ',p.ap_paterno) AS empleado_caja " &
                    "FROM pagos_ventas pv " &
                    " JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                    " JOIN persona p ON p.id_persona=e.id_persona " &
                    "WHERE pv.id_venta='" & current_id_venta_doc & "' ORDER by fecha_cobro", conn)
            Dim i = 0
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_abono_cancelaciones(rs.Fields("id_pagos_ventas").Value, Format(rs.Fields("fecha").Value, "dd-MM-yyyy"), Format(rs.Fields("fecha_cobro").Value, "dd-MM-yyyy"), nombre_forma_pago(rs.Fields("id_forma_pago").Value), FormatCurrency(rs.Fields("importe").Value), rs.Fields("empleado_caja").Value, rs.Fields("status").Value)
                    rs.MoveNext()
                End While

            End If
            rs.Close()

        ElseIf rb_buscar_credito.Checked = True Then
            '===============CARGAR DETALLE DEL CREDITO=======================
            current_id_venta_doc = id_doc
            Dim id_cliente As Integer = 0
            Dim fecha_venta As DateTime
            Dim id_domicilio As Integer = 0
            Dim total_abonos As Decimal = 0
            Dim total_venta As Decimal = 0
            Dim estatus_venta As String = ""
            rs.Open("SELECT venta.fecha,venta.id_cliente,venta.desc_global_porcent,venta.desc_global_importe,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado_venta,venta.total,venta.status,venta.subtotal,venta.total_iva,venta.total_otros,venta.total_descuento " & _
               "FROM venta JOIN empleado ON empleado.id_empleado=venta.id_empleado " & _
               "JOIN persona ON persona.id_persona=empleado.id_persona WHERE venta.id_venta=" & id_doc, conn)
            If rs.RecordCount > 0 Then
                tb_folio.Text = id_doc
                id_cliente = rs.Fields("id_cliente").Value
                fecha_venta = rs.Fields("fecha").Value
                tb_vendedor.Text = rs.Fields("empleado_venta").Value
                total_venta = rs.Fields("total").Value
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                If rs.Fields("desc_global_importe").Value > 0 Then
                    tb_descuento.Text = FormatCurrency(rs.Fields("desc_global_importe").Value)
                Else
                    tb_descuento.Text = FormatCurrency(rs.Fields("total_descuento").Value)
                End If

                tb_impuestos.Text = FormatCurrency(rs.Fields("total_iva").Value + rs.Fields("total_otros").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)
                estatus_venta = rs.Fields("status").Value
                tb_estatus.Text = rs.Fields("status").Value

                ' descuento_global_porcentual = rs.Fields("desc_global_porcent").Value
                'descuento_global_importe = rs.Fields("desc_global_importe").Value
            End If
            rs.Close()
            dtp_fecha.Value = fecha_venta
            dtp_hora.Value = fecha_venta

            rs.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente " & _
                      "FROM cliente " & _
                      "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                      "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                      "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                tb_cliente.Text = rs.Fields("cliente").Value
            End If
            rs.Close()

            rs.Open("SELECT id_domicilio FROM cliente WHERE id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                id_domicilio = rs.Fields("id_domicilio").Value

            End If
            rs.Close()

            rs.Open("SELECT Concat(calle,' ',num_ext,' ',' ',num_int,', ',colonia,', ',municipio,', ',if(cp='','',concat(' C.P. ',cp)) ) domicilio, CONCAT(poblacion,', ',estado,', ',pais) AS ciudad FROM domicilio WHERE id_domicilio='" & id_domicilio & "'", conn)
            If rs.RecordCount > 0 Then
                tb_direccion.Text = rs.Fields("domicilio").Value & " " & rs.Fields("ciudad").Value
            End If
            rs.Close()


            rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total_abonos " & _
                  "FROM pagos_ventas  " & _
                  "WHERE id_venta='" & id_doc & "' AND status='ACTIVO'", conn)
            If rs.RecordCount > 0 Then
                total_abonos = rs.Fields("total_abonos").Value
            End If
            rs.Close()
            lbl_cobros.Text = FormatCurrency(total_abonos)
            lbl_saldo.Text = FormatCurrency(total_venta - total_abonos)

            If estatus_venta = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            ElseIf estatus_venta = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,p.thumb,vd.id_almacen " & _
                    "FROM venta_detalle vd " & _
                    "JOIN producto p ON p.id_producto=vd.id_producto WHERE vd.id_venta='" & id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("id_almacen").Value
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, rs.Fields("importe").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tabla_abono_cancelaciones.Clear()
            rs.Open("SELECT pv.id_pagos_ventas,pv.importe,pv.id_forma_pago,pv.fecha,pv.fecha_cobro,pv.status, CONCAT(p.nombre,' ',p.ap_paterno) AS empleado_caja " &
                    "FROM pagos_ventas pv " &
                    " JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                    " JOIN persona p ON p.id_persona=e.id_persona " &
                    "WHERE pv.id_venta='" & id_doc & "' ORDER by fecha_cobro", conn)
            Dim i = 0
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_abono_cancelaciones(rs.Fields("id_pagos_ventas").Value, Format(rs.Fields("fecha").Value, "dd-MM-yyyy"), Format(rs.Fields("fecha_cobro").Value, "dd-MM-yyyy"), nombre_forma_pago(rs.Fields("id_forma_pago").Value), FormatCurrency(rs.Fields("importe").Value), rs.Fields("empleado_caja").Value, rs.Fields("status").Value)
                    rs.MoveNext()
                End While

            End If
            rs.Close()
        ElseIf rb_buscar_compra.Checked = True Then ' BUSCAMOS COMPRAS
            Dim id_proveedor As Integer = 0
            Dim fecha_compra As DateTime
            Dim id_persona_recibe As Integer = 0
            Dim remision_proveedor As Decimal = 0
            Dim fecha_remision As DateTime
            Dim subtotal_compra As Decimal = 0
            Dim total_ivas As Decimal = 0
            Dim total_otroa As Decimal = 0
            Dim total_compra As Decimal = 0
            Dim estatus_compra As String = ""
            rs.Open("SELECT factura_compra.fecha,factura_compra.id_proveedor,factura_compra.subtotal,factura_compra.iva,factura_compra.otros,factura_compra.total,factura_compra.folio,factura_compra.status," & _
                  "CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado_recibe " & _
              "FROM factura_compra " & _
             "JOIN empleado ON empleado.id_empleado=factura_compra.id_empleado_captura " & _
          "JOIN persona ON persona.id_persona=empleado.id_persona WHERE factura_compra.id_factura_compra=" & id_doc, conn)

            If rs.RecordCount > 0 Then
                tb_folio.Text = id_doc
                current_id_venta_doc = id_doc
                id_proveedor = rs.Fields("id_proveedor").Value
                fecha_compra = rs.Fields("fecha").Value
                tb_persona_recibe.Text = rs.Fields("empleado_recibe").Value
                total_compra = rs.Fields("total").Value
                estatus_compra = rs.Fields("status").Value
                tb_estatus_compra.Text = rs.Fields("status").Value
                tb_remision.Text = rs.Fields("folio").Value
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                tb_descuento.Text = FormatCurrency(0)
                tb_impuestos.Text = FormatCurrency(rs.Fields("iva").Value + rs.Fields("otros").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)

            End If

            rs.Close()
            dtp_fecha.Value = fecha_compra
            dtp_hora.Value = fecha_compra

            rs.Open("SELECT CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS proveedor " & _
                      "FROM proveedor " & _
                      "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                      "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                      "WHERE proveedor.id_proveedor='" & id_proveedor & "'", conn)
            If rs.RecordCount > 0 Then
                tb_proveedor.Text = rs.Fields("proveedor").Value
            End If
            rs.Close()

            If estatus_compra = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            ElseIf estatus_compra = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT fcd.id_producto,fcd.descripcion,fcd.unidad,fcd.cantidad,fcd.precio_unitario,p.thumb " & _
                    "FROM factura_compra_detalle fcd " & _
                    "JOIN producto p ON p.id_producto=fcd.id_producto WHERE fcd.id_factura_compra='" & current_id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio_unitario").Value, rs.Fields("cantidad").Value * rs.Fields("precio_unitario").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tabla_abono_cancelaciones.Clear()
            lbl_cobros.Text = FormatCurrency(0)
            lbl_saldo.Text = FormatCurrency(0)

        ElseIf rb_buscar_traspaso_env.Checked = True Then
            Dim empleado_traspaso As String = ""
            Dim fecha_traspaso As DateTime
            Dim estatus_traspaso_envio As String = ""
            Dim sucursal_destino As String = ""
            current_id_venta_doc = id_doc

            rs.Open("SELECT fecha,nombre_empleado,sucursal_destino,status " & _
                   "FROM traspaso_env " & _
                   "WHERE id_traspaso_env='" & id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                empleado_traspaso = rs.Fields("nombre_empleado").Value
                fecha_traspaso = rs.Fields("fecha").Value
                sucursal_destino = rs.Fields("sucursal_destino").Value
                estatus_traspaso_envio = rs.Fields("status").Value
            End If
            rs.Close()

            tb_folio.Text = id_doc
            dtp_fecha.Value = fecha_traspaso
            dtp_hora.Value = fecha_traspaso
            tb_empleado_traspaso_envio.Text = empleado_traspaso
            tb_sucursal_destino_traspaso.Text = sucursal_destino
            tb_estatus_traspaso_envio.Text = estatus_traspaso_envio


            If estatus_traspaso_envio = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            ElseIf estatus_traspaso_envio = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT ted.id_producto,ted.descripcion,ted.unidad,ted.cantidad,p.thumb " & _
                    "FROM traspaso_env_detalle ted " & _
                    "JOIN producto p ON p.id_producto=ted.id_producto WHERE ted.id_traspaso_env='" & current_id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, 0, 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tb_subtotal.Text = FormatCurrency(0)
            tb_descuento.Text = FormatCurrency(0)
            tb_impuestos.Text = FormatCurrency(0)
            tb_total.Text = FormatCurrency(0)

        ElseIf rb_buscar_traspaso_recep.Checked = True Then
            Dim empleado_traspaso As String = ""
            Dim fecha_traspaso As DateTime
            Dim estatus_traspaso_recepcion As String = ""
            Dim sucursal_origen As String = ""
            current_id_venta_doc = id_doc

            rs.Open("SELECT fecha_registro,empleado_recep,sucursal_origen,status " & _
                   "FROM traspaso_recep " & _
                   "WHERE id_traspaso_recep='" & id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                empleado_traspaso = rs.Fields("empleado_recep").Value
                fecha_traspaso = rs.Fields("fecha_registro").Value
                sucursal_origen = rs.Fields("sucursal_origen").Value
                estatus_traspaso_recepcion = rs.Fields("status").Value
            End If
            rs.Close()

            tb_folio.Text = id_doc
            dtp_fecha.Value = fecha_traspaso
            dtp_hora.Value = fecha_traspaso
            tb_recibio_traspaso.Text = empleado_traspaso
            tb_sucursal_origen_traspaso.Text = sucursal_origen
            tb_estatus_traspaso_recepcion.Text = estatus_traspaso_recepcion


            If estatus_traspaso_recepcion = "CANCELADO" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            ElseIf estatus_traspaso_recepcion = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
                gb_opciones_doc.Enabled = False
                gb_opciones_pagos.Enabled = False
            Else
                tb_aviso_cancelado.Visible = False
                gb_opciones_doc.Enabled = True
                gb_opciones_pagos.Enabled = True
            End If

            tabla_productos_cancelacion.Clear()
            Dim id_almacen As Integer = 0
            rs.Open("SELECT tre.id_producto,tre.descripcion,tre.unidad,tre.cantidad,p.thumb " & _
                    "FROM traspaso_recep_detalle tre " & _
                    "JOIN producto p ON p.id_producto=tre.id_producto WHERE tre.id_traspaso_recep='" & current_id_doc & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_productos_cancelacion(rs.Fields("descripcion").Value, rs.Fields("id_producto").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("cantidad").Value, rs.Fields("unidad").Value, 0, 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            tb_subtotal.Text = FormatCurrency(0)
            tb_descuento.Text = FormatCurrency(0)
            tb_impuestos.Text = FormatCurrency(0)
            tb_total.Text = FormatCurrency(0)

        End If
    End Sub

    Private Sub btn_reimprimir_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reimprimir_documento.Click
        If rb_buscar_nota.Checked = True Then
            If conf_pv(16) = 1 Then
                If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                    Generar_Formato_venta_retail(current_id_venta_doc, current_id_venta_cancelado)
                ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                    Generar_Formato_venta_retail_media(current_id_venta_doc, current_id_venta_cancelado, False)
                ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                    Generar_Formato_venta_apartado(current_id_venta_doc)
                End If
            Else
                'generar ticket de venta miniprinter
            End If

            ElseIf rb_buscar_apartado.Checked = True Then
            If conf_pv(16) = 1 Then
                If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                    Generar_Formato_venta_retail(current_id_venta_doc, current_id_venta_cancelado)
                ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                    Generar_Formato_venta_retail_media(current_id_venta_doc, current_id_venta_cancelado, False)
                ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                    Generar_Formato_venta_apartado(current_id_venta_doc)
                End If
            Else
                'generar ticket de venta miniprinter
            End If
            ElseIf rb_buscar_pedido.Checked = True Then
                If conf_pv(16) = 1 Then
                    'reimprimos pagare_ticket
                Else
                    'reimprimos pagare_ticket
                End If
            ElseIf rb_buscar_credito.Checked = True Then
            If conf_pv(16) = 1 Then
                If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                    Generar_Formato_venta_retail(current_id_venta_doc, current_id_venta_cancelado)
                ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                    Generar_Formato_venta_retail_media(current_id_venta_doc, current_id_venta_cancelado, False)
                ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                    Generar_Formato_venta_apartado(current_id_venta_doc)
                End If
            Else
                'generar ticket de venta miniprinter
            End If
            End If
      

    End Sub

    Private Sub btn_imprimir_orden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_orden.Click
        If conf_pv(16) = 1 Then
            If conf_pv_id_formato(1) = 2 Then
                Generar_orden_entrega(current_id_venta_doc)
            End If
        Else
            imprimir_orden_entrega(current_id_venta_doc, 0)
        End If
    End Sub

    Private Sub btn_imprimir_abono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_abono.Click
        If dgv_abonos.SelectedRows.Count > 0 Then
            If conf_pv(16) = 1 Then
                If conf_pv_id_formato(3) = 2 Then
                    Generar_Formato_abono(dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("id_pagos_ventas").Value)
                End If
            Else
                'imprimir_abono en miniprinter
            End If
        Else
            MsgBox("Seleccione un abono de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_cancelar_abono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_abono.Click
        If dgv_abonos.SelectedRows.Count > 0 Then
            frm_validacion.id_venta_cobro = dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("id_pagos_ventas").Value
            frm_validacion.tipo_de_cobro = dgv_abonos.Rows(dgv_abonos.CurrentRow.Index).Cells("forma_pago").Value
            frm_validacion.validacion = 4
            frm_validacion.ShowDialog()
        Else
            MsgBox("Seleccione un abono de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub rb_buscar_compra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_compra.CheckedChanged
        If rb_buscar_compra.Checked = True Then
            tipo_movimiento = "Compra"
            gb_datos_clientes.Visible = False
            gb_datos_compra.Visible = True
            gb_traspaso_envio.Visible = False
            gb_traspaso_recepcion.Visible = False
            rb_buscar_nota.Checked = False
            rb_buscar_apartado.Checked = False
            rb_buscar_pedido.Checked = False
            rb_buscar_credito.Checked = False
            rb_buscar_traspaso_env.Checked = False
            rb_buscar_traspaso_recep.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub rb_buscar_traspaso_env_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_traspaso_env.CheckedChanged
        If rb_buscar_traspaso_env.Checked = True Then
            tipo_movimiento = "Traspaso (envio)"
            gb_datos_clientes.Visible = False
            gb_datos_compra.Visible = False
            gb_traspaso_recepcion.Visible = False
            gb_traspaso_envio.Visible = True
            rb_buscar_nota.Checked = False
            rb_buscar_apartado.Checked = False
            rb_buscar_pedido.Checked = False
            rb_buscar_compra.Checked = False
            rb_buscar_credito.Checked = False
            rb_buscar_traspaso_recep.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub

    Private Sub rb_buscar_traspaso_recep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_traspaso_recep.CheckedChanged
        If rb_buscar_traspaso_recep.Checked = True Then
            tipo_movimiento = "Traspaso (Recep)"
            gb_datos_clientes.Visible = False
            gb_datos_compra.Visible = False
            gb_traspaso_envio.Visible = False
            gb_traspaso_recepcion.Visible = True
            rb_buscar_nota.Checked = False
            rb_buscar_apartado.Checked = False
            rb_buscar_pedido.Checked = False
            rb_buscar_compra.Checked = False
            rb_buscar_credito.Checked = False
            rb_buscar_traspaso_env.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
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
    Private Sub dgv_producto_cancelacion_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_producto_cancelacion.CellFormatting
        For x = 0 To dgv_abonos.Columns.Count - 1
            e.CellStyle.Font = New Font("Century Gothic", 8, FontStyle.Bold)
            If dgv_abonos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub btn_cancelar_documento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_documento.Click
        If rb_buscar_nota.Checked = True Then
            If MsgBox("Confirme que desea cancelar esta nota de venta y los pagos realizados seran cancelados. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE pagos_ventas SET status='CANCELADO', fecha_cancelacion=NOW() WHERE id_venta='" & current_id_venta_doc & "' AND status='ACTIVO'")
                conn.Execute("UPDATE venta SET status='CANCELADA' WHERE id_venta='" & current_id_venta_doc & "'")
                If MsgBox("¿Desea regresar los productos de esta venta al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    rs.Open("SELECT id_producto,cantidad,id_almacen FROM venta_detalle WHERE id_venta='" & current_id_venta_doc & "'", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            '---descontamos del inventario
                            conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & rs.Fields("id_almacen").Value & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                End If

                cargar_documento(current_id_doc)
                MsgBox("Nota de venta cancelada correctamente", MsgBoxStyle.Information, "Aviso")
            End If

        ElseIf rb_buscar_pedido.Checked = True Then
            If MsgBox("Confirme que desea cancelar este pedido,la nota de venta y los pagos realizados seran cancelados. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE pedido_clientes SET status='CANCELADO' WHERE id_pedido='" & current_id_doc & "'")
                conn.Execute("UPDATE pagos_ventas SET status='CANCELADO', fecha_cancelacion=NOW() WHERE id_venta='" & current_id_venta_doc & "' AND status='ACTIVO'")
                conn.Execute("UPDATE venta SET status='CANCELADA' WHERE id_venta='" & current_id_venta_doc & "'")
                Dim surtido As Integer = 0
                rs.Open("SELECT surtido FROM pedido_clientes WHERE id_pedido='" & current_id_doc & "'", conn)
                If rs.RecordCount > 0 Then
                    surtido = rs.Fields("surtido").Value
                End If
                rs.Close()

                If surtido = 1 Then
                    If MsgBox("Este pedido ya ha sido surtido ¿Desea regresar los productos al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        rs.Open("SELECT id_producto,cantidad,id_almacen FROM venta_detalle WHERE id_venta='" & current_id_venta_doc & "'", conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                '---descontamos del inventario
                                conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & rs.Fields("id_almacen").Value & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                                rs.MoveNext()
                            End While
                        End If
                        rs.Close()
                    End If
                End If

                cargar_documento(current_id_doc)
                MsgBox("Pedido cancelado correctamente", MsgBoxStyle.Information, "Aviso")
            End If
        ElseIf rb_buscar_apartado.Checked = True Then
            If MsgBox("Confirme que desea cancelar este apartado,la nota de venta y los pagos realizados seran cancelados. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE apartado SET status='CANCELADO' WHERE id_apartado='" & current_id_doc & "'")
                conn.Execute("UPDATE pagos_ventas SET status='CANCELADO', fecha_cancelacion=NOW() WHERE id_venta='" & current_id_venta_doc & "' AND status='ACTIVO'")
                conn.Execute("UPDATE venta SET status='CANCELADA' WHERE id_venta='" & current_id_venta_doc & "'")
                Dim entregado As Integer = 0
                rs.Open("SELECT entregado FROM apartado WHERE id_apartado='" & current_id_doc & "'", conn)
                If rs.RecordCount > 0 Then
                    entregado = rs.Fields("entregado").Value
                End If
                rs.Close()

                If entregado = 1 Then
                    If MsgBox("Este apartado ya ha sido entregado ¿Desea regresar los productos al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        rs.Open("SELECT id_producto,cantidad,id_almacen FROM venta_detalle WHERE id_venta='" & current_id_venta_doc & "'", conn)
                        If rs.RecordCount > 0 Then
                            While Not rs.EOF
                                '---descontamos del inventario
                                conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & rs.Fields("id_almacen").Value & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                                rs.MoveNext()
                            End While
                        End If
                        rs.Close()
                    End If
                End If

                cargar_documento(current_id_doc)
                MsgBox("Apartado cancelado correctamente", MsgBoxStyle.Information, "Aviso")
            End If
        ElseIf rb_buscar_credito.Checked = True Then
            If MsgBox("Confirme que desea cancelar este credito,la nota de venta y los pagos realizados seran cancelados. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE pagos_ventas SET status='CANCELADO', fecha_cancelacion=NOW() WHERE id_venta='" & current_id_venta_doc & "' AND status='ACTIVO'")
                conn.Execute("UPDATE venta SET status='CANCELADA' WHERE id_venta='" & current_id_venta_doc & "'")
                If MsgBox("¿Desea regresar los productos al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    rs.Open("SELECT id_producto,cantidad,id_almacen FROM venta_detalle WHERE id_venta='" & current_id_venta_doc & "'", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            '---descontamos del inventario
                            conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & rs.Fields("id_almacen").Value & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                End If
            End If
            cargar_documento(current_id_doc)
            MsgBox("Credito cancelado correctamente", MsgBoxStyle.Information, "Aviso")
        ElseIf rb_buscar_compra.Checked = True Then
            If MsgBox("Confirme que desea cancelar esta compra,los pagos realizados seran cancelados. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE factura_compra SET status='CANCELADA', fecha_cancelacion=NOW() WHERE id_factura_compra='" & current_id_venta_doc & "'")
                If MsgBox("¿Desea descontar los productos al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    rs.Open("SELECT id_producto,cantidad FROM factura_compra_detalle WHERE id_factura_compra='" & current_id_venta_doc & "'", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            '---descontamos del inventario
                            conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & global_current_idalmacen & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                End If
            End If
            cargar_documento(current_id_doc)
            MsgBox("Compra cancelada correctamente", MsgBoxStyle.Information, "Aviso")
        ElseIf rb_buscar_traspaso_env.Checked = True Then
            If MsgBox("Confirme que desea cancelar este traspaso envio. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE traspaso_env SET status='CANCELADA', fecha_cancelacion=NOW() WHERE id_traspaso_env='" & current_id_venta_doc & "'")
                If MsgBox("¿Desea ingresar los productos al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    rs.Open("SELECT id_producto,cantidad FROM traspaso_env_detalle WHERE id_traspaso_env='" & current_id_venta_doc & "'", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            '---descontamos del inventario
                            conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & global_current_idalmacen & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                End If
            End If
            cargar_documento(current_id_doc)
            MsgBox("Traspaso envío cancelado correctamente", MsgBoxStyle.Information, "Aviso")

        ElseIf rb_buscar_traspaso_recep.Checked = True Then
            If MsgBox("Confirme que desea cancelar este traspaso recepción. Esta operacion no se puede deshacer ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE traspaso_recep SET status='CANCELADA', fecha_cancelacion=NOW() WHERE id_traspaso_recep='" & current_id_venta_doc & "'")
                If MsgBox("¿Desea descontar los productos al inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    rs.Open("SELECT id_producto,cantidad FROM traspaso_recep_detalle WHERE id_traspaso_recep='" & current_id_venta_doc & "'", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            '---descontamos del inventario
                            conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & rs.Fields("cantidad").Value & ") WHERE id_almacen='" & global_current_idalmacen & "' AND id_producto=" & rs.Fields("id_producto").Value) '--damos de baja del inventario
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                End If
            End If
            cargar_documento(current_id_doc)
            MsgBox("Traspaso recepcion cancelado correctamente", MsgBoxStyle.Information, "Aviso")

        End If
    End Sub

    Private Sub rb_buscar_credito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_buscar_credito.CheckedChanged
        If rb_buscar_credito.Checked = True Then
            tipo_movimiento = "Credito Venta"
            gb_datos_clientes.Visible = True
            gb_datos_compra.Visible = False
            gb_traspaso_envio.Visible = False
            gb_traspaso_recepcion.Visible = False
            rb_buscar_nota.Checked = False
            rb_buscar_pedido.Checked = False
            rb_buscar_compra.Checked = False
            rb_buscar_apartado.Checked = False
            rb_buscar_traspaso_env.Checked = False
            rb_buscar_traspaso_recep.Checked = False
        End If

        If cargado = True Then
            buscar_documentos(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub
    Private Sub btn_buscar_folio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_folio.Click
        Dim correcto As Boolean = False
        If rb_buscar_nota.Checked = True Then
            rs.Open("SELECT COUNT(id_venta) AS total FROM venta WHERE id_venta='" & tb_folio_busqueda.Text & "'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()
        ElseIf rb_buscar_credito.Checked = True Then
            rs.Open("SELECT COUNT(id_venta) AS total FROM venta WHERE id_venta='" & tb_folio_busqueda.Text & "' AND status='CANCELADA'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()

        ElseIf rb_buscar_pedido.Checked = True Then
            rs.Open("SELECT COUNT(id_pedido) AS total FROM pedido_clientes WHERE id_pedido='" & tb_folio_busqueda.Text & "'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()
        ElseIf rb_buscar_apartado.Checked = True Then
            rs.Open("SELECT COUNT(id_apartado) AS total FROM apartado WHERE id_apartado='" & tb_folio_busqueda.Text & "'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()
        ElseIf rb_buscar_compra.Checked = True Then
            rs.Open("SELECT COUNT(id_factura_compra) AS total FROM factura_compra WHERE id_factura_compra='" & tb_folio_busqueda.Text & "'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()
        ElseIf rb_buscar_traspaso_env.Checked = True Then
            rs.Open("SELECT COUNT(id_traspaso_env) AS total FROM traspaso_env WHERE id_traspaso_env='" & tb_folio_busqueda.Text & "'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()
        ElseIf rb_buscar_traspaso_recep.Checked = True Then
            rs.Open("SELECT COUNT(id_traspaso_recep) AS total FROM traspaso_recep WHERE id_traspaso_recep='" & tb_folio_busqueda.Text & "'", conn)
            If rs.Fields("total").Value > 0 Then
                correcto = True
            End If
            rs.Close()
        End If

        If correcto = True Then
            cargar_documento(tb_folio_busqueda.Text)
        Else
            MsgBox("No se encuentra este folio, verifique su seleccion de tipo de documento", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub

    Private Sub tb_folio_busqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_folio_busqueda.KeyPress
        e.Handled = txtNumerico(tb_folio_busqueda, e.KeyChar, False)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub dgv_busqueda_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_busqueda.CellContentClick

    End Sub
End Class