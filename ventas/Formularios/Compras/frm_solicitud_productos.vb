Public Class frm_solicitud_productos
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_solicitud_productos As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Private dsr As DataSet
    Private tabla_linear As DataRow
    Dim linea_r As Integer
    Public tabla_lista_requisiciones As DataTable
    Private tabla_columnar As DataGridTextBoxColumn

    Private dsp As DataSet
    Private tabla_lineap As DataRow
    Dim linea_p As Integer
    Public tabla_lista_solicitudes As DataTable
    Private tabla_columnap As DataGridTextBoxColumn

    Private id_solicitud As Integer = 0
    Private subtotal As Decimal = 0
    Private impuestos As Decimal = 0
    Private total As Decimal = 0

    Dim cmb As New DataGridViewComboBoxColumn

    Private proveedores(500, 1) As Object
    '/        0      /   1    /
    '/ id_proveedor  / nombre  / 
    Public Sub limpiar_matriz_proveedores()
        For x = 0 To 500
            For j = 0 To 1
                proveedores(x, j) = Nothing
            Next
        Next
    End Sub
    Private cargado As Boolean
    Public Sub estilo_lista_requisiciones(ByVal requisiciones As DataGridView)
        tabla_lista_requisiciones = New DataTable("requisiciones")

        With tabla_lista_requisiciones.Columns
            .Add(New DataColumn("id_requisicion", GetType(Integer)))
            .Add(New DataColumn("folio", GetType(String)))
            .Add(New DataColumn("area_solicitud", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))
        End With
        dsr = New DataSet
        dsr.Tables.Add(tabla_lista_requisiciones)

        With requisiciones
            .DataSource = dsr
            .DataMember = "requisiciones"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_requisicion").Visible = False
            .Columns("id_requisicion").Width = 0

            With .Columns("folio")
                .HeaderText = "Folio"
                .Width = 60
                .ReadOnly = True
            End With

            With .Columns("area_solicitud")
                .HeaderText = "Area"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .Width = 80
                .ReadOnly = True
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With

        End With
    End Sub
    Public Sub agregar_lista_requisiciones(ByVal id_requisicion As Integer, ByVal folio As String, ByVal area_solicitud As String, ByVal total As Decimal)
        tabla_linear = tabla_lista_requisiciones.NewRow()
        tabla_linear("id_requisicion") = id_requisicion
        tabla_linear("folio") = folio
        tabla_linear("area_solicitud") = area_solicitud
        tabla_linear("total") = total
        tabla_lista_requisiciones.Rows.Add(tabla_linear)
    End Sub

    Public Sub estilo_lista_solicitudes(ByVal solicitudes As DataGridView)
        tabla_lista_solicitudes = New DataTable("solicitudes")

        With tabla_lista_solicitudes.Columns
            .Add(New DataColumn("id_solicitud_compra", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("estatus", GetType(String)))

        End With
        dsp = New DataSet
        dsp.Tables.Add(tabla_lista_solicitudes)

        With solicitudes
            .DataSource = dsp
            .DataMember = "solicitudes"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            With .Columns("id_solicitud_compra")
                .HeaderText = "folio"
                .Width = 40
                .ReadOnly = True
            End With

            With .Columns("fecha")
                .HeaderText = "fecha"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .Width = 70
                .ReadOnly = True
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With
            With .Columns("estatus")
                .HeaderText = "Estado"
                .Width = 70
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_lista_solicitudes(ByVal id_solicitud_compra As Integer, ByVal fecha As String, ByVal total As Decimal, ByVal estatus As String)
        tabla_lineap = tabla_lista_solicitudes.NewRow()
        tabla_lineap("id_solicitud_compra") = id_solicitud_compra
        tabla_lineap("fecha") = fecha
        tabla_lineap("total") = total
        tabla_lineap("estatus") = estatus
        tabla_lista_solicitudes.Rows.Add(tabla_lineap)
    End Sub
    Public Sub estilo_solicitud_productos(ByVal solicitud_productos As DataGridView)
        tabla_solicitud_productos = New DataTable("solicitud_productos")


        cmb.HeaderText = "Proveedor"
        cmb.Name = "proveedor"
        cmb.Items.Clear()
        limpiar_matriz_proveedores()


        rs.Open("SELECT id_proveedor,CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
                "FROM proveedor " & _
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa", conn)
        If rs.RecordCount > 0 Then
            Dim count = 0
            While Not rs.EOF
                '/        0      /   1    /
                '/ id_proveedor  / nombre  / 
                Me.proveedores(count, 0) = rs.Fields("id_proveedor").Value
                Me.proveedores(count, 1) = rs.Fields("nombre").Value
                cmb.Items.Add(rs.Fields("nombre").Value)
                count += 1
                rs.MoveNext()
            End While
        End If
        rs.Close()

        cmb.Width = 150

        With tabla_solicitud_productos.Columns
            .Add(New DataColumn("seleccionado", GetType(Boolean)))
            .Add(New DataColumn("id_cmi_requisicion_detalle", GetType(Integer)))
            .Add(New DataColumn("id_precio_unitario_accion", GetType(Integer)))
            .Add(New DataColumn("id_partida", GetType(Integer)))
            .Add(New DataColumn("partida", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("precio_unitario", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("impuesto", GetType(String)))
            .Add(New DataColumn("total_impuesto", GetType(Decimal)))
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("id_impuesto", GetType(Integer)))
            .Add(New DataColumn("id_unidad", GetType(Integer)))
            .Add(New DataColumn("id_proveedor", GetType(Integer)))
            .Add(New DataColumn("orden_compra", GetType(String)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_solicitud_productos)

        With solicitud_productos
            .DataSource = ds
            .DataMember = "solicitud_productos"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_cmi_requisicion_detalle").Visible = False
            .Columns("id_cmi_requisicion_detalle").Width = 0
            .Columns("id_precio_unitario_accion").Visible = False
            .Columns("id_partida").Visible = False
            .Columns("id_impuesto").Visible = False
            .Columns("id_unidad").Width = 0
            .Columns("id_unidad").Visible = False
            .Columns("id_proveedor").Width = 0
            .Columns("id_proveedor").Visible = False
            'With .Columns("id_producto")
            '.HeaderText = ""
            ' .Width = 0
            '.ReadOnly = True
            '.Visible = False
            'End With
            With .Columns("seleccionado")
                .HeaderText = "Sel."
                .Width = 30
                .ReadOnly = False
            End With
            With .Columns("partida")
                .HeaderText = "partida"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 250
                .ReadOnly = False
            End With
            With .Columns("precio_unitario")
                .HeaderText = "Precio Unitario"
                .Width = 65
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .Visible = True
                .ReadOnly = False
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 55
                .ReadOnly = False
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .Width = 60
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("impuesto")
                .HeaderText = "Impuesto"
                .Width = 65
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .Width = 60
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("total_impuesto")
                .HeaderText = "Impuesto"
                .Width = 60
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("orden_compra")
                .HeaderText = "Orden Compra"
                .Width = 60
                ' .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                '.DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .Visible = True
            End With
        End With

        solicitud_productos.Columns.Insert(16, cmb)
        'Determinamos el alto de las filas
        solicitud_productos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'Referenciamos la columna
        Dim col As DataGridViewColumn = solicitud_productos.Columns("total")
        'Ajustamos la celda a su contenido.
        col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    Public Sub agregar_solicitud_productos(ByVal seleccionado As Boolean, ByVal id_cmi_requisicion_detalle As Integer, ByVal id_precio_unitario_accion As Integer, ByVal id_partida As Integer, ByVal partida As String, ByVal unidad As String, ByVal descripcion As String, ByVal precio_unitario As Decimal, ByVal cantidad As Decimal, ByVal total As Decimal, ByVal id_impuesto As Integer, ByVal impuesto As String, ByVal id_unidad As Integer, ByVal importe As Decimal, ByVal total_impuesto As Decimal, ByVal id_proveedor As Integer, ByVal orden_compra As String)
        tabla_linea = tabla_solicitud_productos.NewRow()
        tabla_linea("seleccionado") = seleccionado
        tabla_linea("id_cmi_requisicion_detalle") = id_cmi_requisicion_detalle
        tabla_linea("id_precio_unitario_accion") = id_precio_unitario_accion
        tabla_linea("id_partida") = id_partida
        tabla_linea("partida") = partida
        tabla_linea("unidad") = unidad
        tabla_linea("descripcion") = descripcion
        tabla_linea("precio_unitario") = precio_unitario
        tabla_linea("impuesto") = impuesto
        tabla_linea("importe") = importe
        tabla_linea("cantidad") = cantidad
        tabla_linea("total") = total
        tabla_linea("id_impuesto") = id_impuesto
        tabla_linea("total_impuesto") = total_impuesto
        tabla_linea("id_unidad") = id_unidad
        tabla_linea("id_proveedor") = id_proveedor
        tabla_linea("orden_compra") = orden_compra
        'tabla_linea("proveedor") = proveedor
        tabla_solicitud_productos.Rows.Add(tabla_linea)
    End Sub
    Private Sub frm_solicitud_cotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frm_principal3
        cargado = False
        estilo_solicitud_productos(dgv_solicitud_productos)
        estilo_lista_requisiciones(dgv_busqueda)
        estilo_lista_solicitudes(dgv_solicitudes)
        buscar_requisiciones()
        tb_solicitud.SelectTab(tab_solicitud)
        cargar_opciones_busqueda()
        conf_inicio()
        cargado = True
        buscar_solicitudes(cb_opciones_busqueda_sol.SelectedIndex)
    End Sub
    Private Sub buscar_requisiciones()
        tabla_lista_requisiciones.Clear()
        rs.Open("SELECT r.id_cmi_requisicion,r.folio,r.total,a.nombre AS area_solicitud FROM cmi_requisicion r " & _
                "JOIN cmi_area a ON a.id_area=r.id_area " & _
                "WHERE r.estatus='COTIZACION' AND r.status_solicitud_compra='PENDIENTE'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_lista_requisiciones(rs.Fields("id_cmi_requisicion").Value, Format(rs.Fields("folio").Value, "000000"), rs.Fields("area_solicitud").Value, rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub
    Private Sub cargar_productos_requisicion(ByVal id_cmi_requisicion As Integer, Optional ByVal limpiar_tabla As Boolean = True)
        If limpiar_tabla = True Then
            tabla_solicitud_productos.Clear()
        End If
        rs.Open("SELECT rd.id_cmi_requisicion_detalle,rd.id_precio_unitario_accion,rd.id_partida,p.codigo AS partida,u.nombre AS unidad,rd.e_descripcion,rd.cantidad,rd.precio_unitario,rd.importe,rd.eid_unidad,rd.eid_impuesto,i.nombre AS impuesto,i.valor AS tasa " & _
                "FROM cmi_requisicion_detalle rd " & _
                "JOIN cmi_unidad u ON u.id_unidad=rd.eid_unidad " & _
                "JOIN cmi_partidas p ON p.id_partida=rd.id_partida " & _
                "JOIN cmi_impuestos i on i.id_impuesto=rd.eid_impuesto " & _
                "WHERE id_cmi_requisicion='" & id_cmi_requisicion & "' AND id_solicitud_compra='0'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim importe As Decimal = rs.Fields("precio_unitario").Value * rs.Fields("cantidad").Value
                Dim total_impuesto As Decimal = importe * rs.Fields("tasa").Value
                agregar_solicitud_productos(False, rs.Fields("id_cmi_requisicion_detalle").Value, rs.Fields("id_precio_unitario_accion").Value, rs.Fields("id_partida").Value, rs.Fields("partida").Value, rs.Fields("unidad").Value, rs.Fields("e_descripcion").Value, rs.Fields("precio_unitario").Value, rs.Fields("cantidad").Value, rs.Fields("importe").Value, rs.Fields("eid_impuesto").Value, rs.Fields("impuesto").Value, rs.Fields("eid_unidad").Value, importe, total_impuesto, 0, "")
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub
    Private Sub dgv_busqueda_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_busqueda.CellFormatting, dgv_solicitudes.CellFormatting
        For x = 0 To dgv_busqueda.Columns.Count - 1
            If dgv_busqueda.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_busqueda_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_busqueda.MouseUp
        If dgv_busqueda.SelectedRows.Count > 0 Then
            If dgv_busqueda.SelectedRows.Count = 1 Then
                cargar_productos_requisicion(dgv_busqueda.Rows(dgv_busqueda.CurrentRow.Index).Cells("id_requisicion").Value)
            Else
                tabla_solicitud_productos.Clear()
                For x = 0 To dgv_busqueda.Rows.Count - 1
                    If dgv_busqueda.Rows(x).Selected = True Then
                        cargar_productos_requisicion(dgv_busqueda.Rows(x).Cells("id_requisicion").Value, False)
                    End If

                Next
            End If
            cargar_filtro_partida()
            actualizar_totales()
        End If
    End Sub
    Private Sub cargar_filtro_partida()
        cb_partida.Items.Clear()
        cb_partida.Text = ""
        Dim filtro As String = " AND rd.id_cmi_requisicion='0' "

        For x = 0 To dgv_busqueda.Rows.Count - 1
            If dgv_busqueda.Rows(x).Selected = True Then
                filtro = filtro & " OR id_cmi_requisicion='" & dgv_busqueda.Rows(x).Cells("id_requisicion").Value & "' "
            End If

        Next

        rs.Open("SELECT DISTINCT(rd.id_partida),p.codigo AS partida FROM cmi_requisicion_detalle rd " & _
                "JOIN cmi_partidas p ON p.id_partida=rd.id_partida " & _
                "WHERE 1 " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_partida.Items.Add(New myItem(rs.Fields("id_partida").Value, rs.Fields("partida").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub
    Private Sub btn_guardar_solicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If id_solicitud = 0 Then

            Dim count_seleccionado As Integer = 0
            For x = 0 To dgv_solicitud_productos.Rows.Count - 1
                If dgv_solicitud_productos.Rows(x).Cells("seleccionado").Value = True Then
                    count_seleccionado += 1
                End If
            Next

            actualizar_totales()
            If count_seleccionado > 0 Then
                id_solicitud = 0
                conn.Execute("INSERT INTO solicitud_compra(fecha,id_persona_elabora,subtotal,impuestos,total) VALUES(NOW(),'" & global_id_persona & "','" & subtotal & "','" & impuestos & "','" & total & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_solicitud = rs.Fields(0).Value
                rs.Close()

                For x = 0 To dgv_solicitud_productos.Rows.Count - 1
                    If dgv_solicitud_productos.Rows(x).Cells("seleccionado").Value = True Then
                        conn.Execute("INSERT INTO solicitud_compra_detalle(id_solicitud_compra,id_cmi_requisicion_detalle,id_precio_unitario_accion,id_partida,partida,unidad,descripcion,precio_unitario,impuesto,importe,cantidad,total,id_impuesto,total_impuesto,id_unidad,id_proveedor) " & _
                            "VALUES('" & id_solicitud & "','" & dgv_solicitud_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("id_precio_unitario_accion").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("id_partida").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("partida").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("unidad").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("descripcion").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("precio_unitario").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("impuesto").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("importe").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("cantidad").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("total").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("id_impuesto").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("total_impuesto").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("id_unidad").Value & "','" & dgv_solicitud_productos.Rows(x).Cells("id_proveedor").Value & "')")
                        conn.Execute("UPDATE cmi_requisicion_detalle SET id_solicitud_compra='" & id_solicitud & "' WHERE id_cmi_requisicion_detalle='" & dgv_solicitud_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "'")
                    End If
                Next

                For x = 0 To dgv_busqueda.Rows.Count - 1
                    rs.Open("SELECT COUNT(*) AS total FROM cmi_requisicion_detalle WHERE id_cmi_requisicion='" & dgv_busqueda.Rows(x).Cells("id_requisicion").Value & "' AND id_solicitud_compra='0'", conn)
                    If rs.RecordCount > 0 Then
                        If rs.Fields("total").Value = 0 Then
                            conn.Execute("UPDATE cmi_requisicion SET status_solicitud_compra='CERRADA' WHERE id_cmi_requisicion='" & dgv_busqueda.Rows(x).Cells("id_requisicion").Value & "'")
                        End If
                    End If
                    rs.Close()
                Next

                buscar_requisiciones()
                buscar_solicitudes(cb_opciones_busqueda_sol.SelectedIndex)
                cargar_solicitud(id_solicitud)
                MsgBox("Solicitud de compra guarda correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Debe seleccionar al menos un insumo/producto para guardar la solicitud de productos", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Else
            conn.Execute("UPDATE solicitud_compra SET subtotal ='" & subtotal & "',impuestos='" & impuestos & "',total='" & total & "' WHERE id_solicitud_compra='" & id_solicitud & "'")

            For x = 0 To dgv_solicitud_productos.Rows.Count - 1
                conn.Execute("UPDATE solicitud_compra_detalle SET " & _
                             "descripcion='" & dgv_solicitud_productos.Rows(x).Cells("descripcion").Value & "', " & _
                             "precio_unitario='" & dgv_solicitud_productos.Rows(x).Cells("precio_unitario").Value & "', " & _
                             "importe='" & dgv_solicitud_productos.Rows(x).Cells("importe").Value & "'," & _
                             "cantidad='" & dgv_solicitud_productos.Rows(x).Cells("cantidad").Value & "'," & _
                             "id_proveedor='" & dgv_solicitud_productos.Rows(x).Cells("id_proveedor").Value & "' " & _
                             "WHERE id_cmi_requisicion_detalle='" & dgv_solicitud_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "' AND id_solicitud_compra='" & id_solicitud & "'")
            Next

        End If
    End Sub
    Private Sub cargar_solicitud(Optional ByVal id As Integer = 0)
        id_solicitud = id
        Dim fecha As DateTime
        If id_solicitud > 0 Then
            tb_solicitud.SelectTab(tab_solicitud)
            rs.Open("SELECT sc.fecha,sc.status,sc.subtotal,sc.impuestos,sc.total, CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS persona FROM solicitud_compra sc " & _
                    "JOIN persona p ON p.id_persona=sc.id_persona_elabora " & _
                    "WHERE id_solicitud_compra='" & id_solicitud & "'", conn)
            If rs.RecordCount > 0 Then

                tb_folio.Text = Format(id_solicitud, "000000")
                tb_persona_elabora.Text = rs.Fields("persona").Value
                fecha = rs.Fields("fecha").Value
                dtp_fecha.Value = fecha
                dtp_hora.Value = fecha
                tb_estatus.Text = rs.Fields("status").Value
                If rs.Fields("status").Value = "CANCELADA" Then
                    tb_aviso_cancelado.Visible = True
                Else
                    tb_aviso_cancelado.Visible = False
                End If
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                tb_impuestos.Text = FormatCurrency(rs.Fields("impuestos").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)

            End If
            rs.Close()

            tabla_solicitud_productos.Clear()
            Dim rw As New ADODB.Recordset
            Dim folio_orden As String = ""
            rs.Open("SELECT * FROM solicitud_compra_detalle WHERE  id_solicitud_compra='" & id_solicitud & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    rw.Open("SELECT oc.folio FROM orden_compra oc JOIN solicitud_compra_detalle scd ON scd.id_orden_compra=oc.id_orden_compra WHERE scd.id_solicitud_compra_detalle='" & rs.Fields("id_solicitud_compra_detalle").Value & "'", conn)
                    If rw.RecordCount > 0 Then
                        folio_orden = Format(rw.Fields("folio").Value, "000000")
                    End If
                    rw.Close()
                    agregar_solicitud_productos(False, rs.Fields("id_cmi_requisicion_detalle").Value, rs.Fields("id_precio_unitario_accion").Value, rs.Fields("id_partida").Value, rs.Fields("partida").Value, rs.Fields("unidad").Value, rs.Fields("descripcion").Value, rs.Fields("precio_unitario").Value, rs.Fields("cantidad").Value, rs.Fields("total").Value, rs.Fields("id_impuesto").Value, rs.Fields("impuesto").Value, rs.Fields("id_unidad").Value, rs.Fields("importe").Value, rs.Fields("total_impuesto").Value, rs.Fields("id_proveedor").Value, folio_orden)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            For x = 0 To dgv_solicitud_productos.Rows.Count - 1

                For y = 0 To 200
                    If Not IsNothing(Me.proveedores(y, 0)) Then
                        If Me.proveedores(y, 0) = dgv_solicitud_productos.Rows(x).Cells("id_proveedor").Value() Then
                            dgv_solicitud_productos.Rows(x).Cells("proveedor").Value = Me.proveedores(y, 1)
                        End If
                    Else
                        Exit For
                    End If
                Next

            Next

            rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS subtotal,CASE WHEN ISNULL(SUM(total_impuesto)) THEN 0 ELSE SUM(total_impuesto) END AS impuesto,CASE WHEN ISNULL(SUM(total)) THEN 0 ELSE SUM(total) END AS total FROM solicitud_compra_detalle WHERE id_solicitud_compra='" & id_solicitud & "'", conn)
            If rs.RecordCount > 0 Then
                subtotal = rs.Fields("subtotal").Value
                impuestos = rs.Fields("impuesto").Value
                total = rs.Fields("total").Value
            End If
            rs.Close()
            tb_subtotal.Text = subtotal
            tb_impuestos.Text = impuestos
            tb_total.Text = total

            btn_nuevo.Enabled = True
           

            If tb_aviso_cancelado.Visible = True Then
                btn_guardar.Enabled = False
                'btn_imprimir.Enabled = False
                btn_cancelar.Enabled = False
                btn_editar.Enabled = False
                btn_deshacer.Enabled = False
                gb_insumos.Enabled = False
                btn_generar_orden.Enabled = False
            Else
                btn_guardar.Enabled = False
                'btn_imprimir.Enabled = True
                btn_cancelar.Enabled = True
                btn_editar.Enabled = True
                btn_deshacer.Enabled = False
                gb_insumos.Enabled = False
                btn_generar_orden.Enabled = True
            End If

        Else
            conf_inicio()
            tb_solicitud.SelectTab(tab_origen)
            btn_nuevo.Enabled = False
            btn_guardar.Enabled = True
                'btn_imprimir.Enabled = False
                btn_cancelar.Enabled = False
                btn_editar.Enabled = False
                btn_deshacer.Enabled = True
                gb_insumos.Enabled = True
                btn_generar_orden.Enabled = False
        End If
    End Sub
    Private Sub conf_inicio()
        tabla_solicitud_productos.Clear()
        tb_folio.Text = "000000"
        tb_persona_elabora.Text = global_nombre
        dtp_fecha.Value = Now
        dtp_hora.Value = Now
        tb_subtotal.Text = FormatCurrency(0)
        tb_impuestos.Text = FormatCurrency(0)
        tb_total.Text = FormatCurrency(0)
        tb_estatus.Text = "PENDIENTE"
        tb_aviso_cancelado.Visible = False
        gb_insumos.Enabled = False

        tb_solicitud.SelectTab(tab_solicitud)
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        ' btn_imprimir.Enabled = False
        btn_cancelar.Enabled = False
        btn_editar.Enabled = False
        btn_deshacer.Enabled = False
        btn_generar_orden.Enabled = False
    End Sub
    Private Sub actualizar_totales(Optional ByVal todos As Boolean = False)
        subtotal = 0
        impuestos = 0
        total = 0

        For x = 0 To dgv_solicitud_productos.Rows.Count - 1
            If dgv_solicitud_productos.Rows(x).Cells("seleccionado").Value = True Then
                subtotal += dgv_solicitud_productos.Rows(x).Cells("importe").Value
                impuestos += dgv_solicitud_productos.Rows(x).Cells("total_impuesto").Value
                total += dgv_solicitud_productos.Rows(x).Cells("total").Value
            Else
                If todos = True Then
                    subtotal += dgv_solicitud_productos.Rows(x).Cells("importe").Value
                    impuestos += dgv_solicitud_productos.Rows(x).Cells("total_impuesto").Value
                    total += dgv_solicitud_productos.Rows(x).Cells("total").Value
                End If
            End If
        Next
        tb_subtotal.Text = FormatCurrency(subtotal)
        tb_impuestos.Text = FormatCurrency(impuestos)
        tb_total.Text = FormatCurrency(total)
    End Sub

    Private Sub btn_nueva_solicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_solicitud()
    End Sub

    Private Sub dgv_solicitud_productos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_solicitud_productos.CellEnter

    End Sub
    Private Sub dgv_solicitud_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_solicitud_productos.CellValueChanged
        If cargado = True Then
            actualizar_totales()
            actualizar_proveedor()
        End If
    End Sub
    Private Sub actualizar_proveedor()

        Dim id_proveedor As Integer = 0

        For x = 0 To 200
            If Not IsNothing(Me.proveedores(x, 0)) Then
                If Me.proveedores(x, 1) = dgv_solicitud_productos.Rows(dgv_solicitud_productos.CurrentRow.Index).Cells("proveedor").Value() Then
                    id_proveedor = Me.proveedores(x, 0)
                End If
            Else
                Exit For
            End If
        Next
        dgv_solicitud_productos.Rows(dgv_solicitud_productos.CurrentRow.Index).Cells("id_proveedor").Value() = id_proveedor

    End Sub
    Private Sub dgv_solicitudes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_solicitudes.DoubleClick
        If dgv_solicitudes.SelectedRows.Count > 0 Then
            cargar_solicitud(dgv_solicitudes.Rows(dgv_solicitudes.CurrentRow.Index).Cells("id_solicitud_compra").Value)
        End If
    End Sub
    Private Sub btn_deshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deshacer.Click
        conf_inicio()
    End Sub
    Private Sub dgv_solicitud_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_solicitud_productos.DoubleClick
        MsgBox(dgv_solicitud_productos.Rows(dgv_solicitud_productos.CurrentRow.Index).Cells("proveedor").Value)
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        'btn_imprimir.Enabled = False
        btn_cancelar.Enabled = False
        btn_editar.Enabled = False
        btn_deshacer.Enabled = True
        gb_insumos.Enabled = True
        btn_generar_orden.Enabled = False
    End Sub

    Private Sub btn_generar_orden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar_orden.Click
        'obtenemos proveedores
        Dim rw As New ADODB.Recordset
        Dim id_persona_aut1 As Integer = 0
        Dim id_area_aut1 As Integer = 0
        Dim id_persona_aut2 As Integer = 0
        Dim id_area_aut2 As Integer = 0
        Dim id_persona_aut3 As Integer = 0
        Dim id_area_aut3 As Integer = 0
        Dim id_persona_aut4 As Integer = 0
        Dim id_area_aut4 As Integer = 0

        rs.Open("SELECT * FROM orden_compra_cfg WHERE id_orden_compra_cfg='1'", conn)
        If rs.RecordCount > 0 Then
            id_persona_aut1 = rs.Fields("id_persona_aut1").Value
            id_area_aut1 = rs.Fields("id_area_aut1").Value
            id_persona_aut2 = rs.Fields("id_persona_aut2").Value()
            id_area_aut2 = rs.Fields("id_area_aut2").Value
            id_persona_aut3 = rs.Fields("id_persona_aut3").Value()
            id_area_aut3 = rs.Fields("id_area_aut3").Value()
            id_persona_aut4 = rs.Fields("id_persona_aut4").Value()
            id_area_aut4 = rs.Fields("id_area_aut4").Value()
        End If
        rs.Close()

        rs.Open("SELECT DISTINCT(id_proveedor) FROM solicitud_compra_detalle WHERE id_solicitud_compra='" & id_solicitud & "' AND id_proveedor<>'0' AND id_orden_compra='0'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF

                conn.Execute("INSERT INTO orden_compra(id_solicitud,id_proveedor,fecha,id_persona_elabora) " & _
                             "VALUES('" & id_solicitud & "','" & rs.Fields("id_proveedor").Value & "',NOW(),'" & global_id_persona & "')")

                rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                Dim id_orden_compra = rw.Fields(0).Value
                rw.Close()

                rw.Open("SELECT id_solicitud_compra_detalle,id_cmi_requisicion_detalle,id_precio_unitario_accion,id_partida,partida,unidad,descripcion,precio_unitario,impuesto,importe,cantidad,total,id_impuesto,total_impuesto,id_unidad FROM solicitud_compra_detalle WHERE id_solicitud_compra='" & id_solicitud & "' AND id_proveedor='" & rs.Fields("id_proveedor").Value & "'", conn)
                If rw.RecordCount > 0 Then

                    Dim total_orden_importe As Decimal = 0
                    Dim total_orden_impuestos As Decimal = 0
                    Dim total_orden_total As Decimal = 0

                    While Not rw.EOF
                        total_orden_importe += rw.Fields("importe").Value
                        total_orden_impuestos += rw.Fields("total_impuesto").Value
                        total_orden_total += rw.Fields("total").Value

                        conn.Execute("INSERT INTO orden_compra_detalle(id_orden_compra,id_cmi_requisicion_detalle,id_partida,partida,unidad,descripcion,precio_unitario,impuesto,importe,cantidad,total,id_impuesto,total_impuesto,id_unidad) " & _
                                     "VALUES('" & id_orden_compra & "','" & rw.Fields("id_cmi_requisicion_detalle").Value & "','" & rw.Fields("id_partida").Value & "','" & rw.Fields("partida").Value & "','" & rw.Fields("unidad").Value & "','" & rw.Fields("descripcion").Value & "','" & rw.Fields("precio_unitario").Value & "','" & rw.Fields("impuesto").Value & "','" & rw.Fields("importe").Value & "','" & rw.Fields("cantidad").Value & "','" & rw.Fields("total").Value & "','" & rw.Fields("id_impuesto").Value & "','" & rw.Fields("total_impuesto").Value & "','" & rw.Fields("id_unidad").Value & "')")
                        conn.Execute("UPDATE solicitud_compra_detalle SET id_orden_compra='" & id_orden_compra & "' WHERE id_solicitud_compra_detalle='" & rw.Fields("id_solicitud_compra_detalle").Value & "'")
                        rw.MoveNext()
                    End While
                    conn.Execute("UPDATE orden_compra SET subtotal='" & total_orden_importe & "',total_impuestos='" & total_orden_impuestos & "',total='" & total_orden_total & "',id_persona_aut1='" & id_persona_aut1 & "',id_persona_aut2='" & id_persona_aut2 & "',id_persona_aut3='" & id_persona_aut3 & "' WHERE id_orden_compra='" & id_orden_compra & "'")
                End If
                rw.Close()

                conn.Execute("INSERT INTO orden_compra_autorizacion(id_orden_compra,id_aut,id_area,id_persona) VALUES('" & id_orden_compra & "','1','" & id_area_aut1 & "','" & id_persona_aut1 & "')")
                conn.Execute("INSERT INTO orden_compra_autorizacion(id_orden_compra,id_aut,id_area,id_persona) VALUES('" & id_orden_compra & "','2','" & id_area_aut2 & "','" & id_persona_aut2 & "')")
                conn.Execute("INSERT INTO orden_compra_autorizacion(id_orden_compra,id_aut,id_area,id_persona) VALUES('" & id_orden_compra & "','3','" & id_area_aut3 & "','" & id_persona_aut3 & "')")
                conn.Execute("INSERT INTO orden_compra_autorizacion(id_orden_compra,id_aut,id_area,id_persona) VALUES('" & id_orden_compra & "','4','" & id_area_aut4 & "','" & id_persona_aut4 & "')")
                        
                rs.MoveNext()
            End While
        Else
            MsgBox("No se encontraron ordenes de compra pendientes por generar, guarde sus cambios y vuelva a intentarlo", MsgBoxStyle.Information, "Aviso")
        End If
        rs.Close()
    End Sub

    Private Sub dgv_solicitudes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_solicitudes.CellContentClick

    End Sub

    Private Sub dgv_solicitud_productos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_solicitud_productos.CellContentClick

    End Sub

    Private Sub dgv_solicitud_productos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_solicitud_productos.CellFormatting
        If dgv_solicitud_productos.Rows(e.RowIndex).Cells("orden_compra").Value = "000000" Then
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.SelectionBackColor = Color.Black
            e.CellStyle.SelectionForeColor = Color.White
        ElseIf dgv_solicitud_productos.Rows(e.RowIndex).Cells("orden_compra").Value = "" Then
            e.CellStyle.BackColor = Color.Yellow
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.SelectionBackColor = Color.Black
            e.CellStyle.SelectionForeColor = Color.White
        Else

            e.CellStyle.BackColor = Color.YellowGreen
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.SelectionBackColor = Color.Black
            e.CellStyle.SelectionForeColor = Color.White
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btn_eliminar_seleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_seleccion.Click
        Dim seleccionados As Integer = 0
        Dim orden_encontrada As Boolean = False
        For x = 0 To dgv_solicitud_productos.Rows.Count - 1
            If dgv_solicitud_productos.Rows(x).Cells("seleccionado").Value = True Then
                If dgv_solicitud_productos.Rows(x).Cells("orden_compra").Value = "000000" Then
                    orden_encontrada = True
                End If
                seleccionados += 1
            End If
        Next
        If seleccionados > 0 Then
            If orden_encontrada = True Then
                MsgBox("Se encontraron insumos que se encuentran en orden de compra, para eliminar estos productos, cancele la orden de compra o verifique su selección", MsgBoxStyle.Exclamation, "Aviso")
            Else
                If MsgBox("Desea eliminar " & seleccionados & " insumo(s) seleccionados? Esta operacion no se puede deshacer.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    For x = 0 To dgv_solicitud_productos.Rows.Count - 1
                        If dgv_solicitud_productos.Rows(x).Cells("seleccionado").Value = True Then
                            conn.Execute("DELETE FROM solicitud_compra_detalle WHERE id_cmi_requisicion_detalle='" & dgv_solicitud_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "'")
                            conn.Execute("UPDATE cmi_requisicion_detalle SET id_solicitud_compra='0' WHERE id_cmi_requisicion_detalle='" & dgv_solicitud_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "'")
                        End If
                    Next
                    cargar_solicitud(id_solicitud)
                    actualizar_totales(True)
                    btn_guardar_solicitud_Click(sender, e)
                    MsgBox("Insumos seleccionados correctamente", MsgBoxStyle.Information, "Aviso")
                End If
            End If
           
        Else
            MsgBox("Debe seleeccionar por lo menos un insumo", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub

    Private Sub btn_buscar_folio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar_solicitud.Click
        If Trim(tb_folio_busqueda.TextLength) > 0 Then
            Dim id_solicitud_compra As Integer = 0
            rs.Open("SELECT id_solicitud_compra from solicitud_compra WHERE id_solicitud_compra='" & Trim(tb_folio_busqueda.Text) & "'")
            If rs.RecordCount > 0 Then
                id_solicitud_compra = rs.Fields("id_solicitud_compra").Value
            End If
            rs.Close()
            If id_solicitud_compra > 0 Then
                cargar_solicitud(id_solicitud_compra)
            Else
                tb_folio_busqueda.Text = ""
                MsgBox("No se encontrol el folio ingresado", MsgBoxStyle.Exclamation, "Aviso")

            End If
        Else
            MsgBox("Debe ingresar un folio de Solicitud de Productos", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub
    Private Sub buscar_solicitudes(ByVal index_opcion_busqueda As Integer)
        Dim consulta As String = ""
        Dim filtro As String = ""

        If index_opcion_busqueda = 0 Then ' Busqueda por fecha
            consulta = "SELECT id_solicitud_compra AS id,fecha AS fecha,total AS total,status AS estatus FROM Solicitud_compra " & _
            "ORDER BY id_solicitud_compra DESC"

        ElseIf index_opcion_busqueda = 1 Then ' busqueda por periodo

            consulta = "SELECT id_solicitud_compra AS id,fecha AS fecha,total AS total,status AS estatus FROM Solicitud_compra " & _
       "WHERE DATE(fecha)= '" & Format(dtp_fecha_busqueda_sol.Value, "yyyy-MM-dd") & "'" & _
      " ORDER BY id_solicitud_compra DESC"

        ElseIf index_opcion_busqueda = 2 Then ' busqueda de todos

            consulta = "SELECT id_solicitud_compra AS id,fecha AS fecha,total AS total,status AS estatus FROM Solicitud_compra " & _
    "WHERE DATE(fecha) BETWEEN '" & Format(dtp_fecha_inicio_sol.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino_sol.Value, "yyyy-MM-dd") & "' " & _
   "ORDER BY id_solicitud_compra DESC"
        End If

        tabla_lista_solicitudes.Clear()
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
                agregar_lista_solicitudes(rs.Fields("id").Value, fecha.ToShortDateString, rs.Fields("total").Value, rs.Fields("estatus").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Private Sub cb_opciones_busqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_opciones_busqueda.SelectedIndexChanged, ComboBox3.SelectedIndexChanged, ComboBox2.SelectedIndexChanged, ComboBox1.SelectedIndexChanged
        If cb_opciones_busqueda_sol.SelectedIndex <> -1 Then
            If cb_opciones_busqueda_sol.SelectedIndex = 0 Then
                dtp_fecha_busqueda_sol.Visible = False
                dtp_fecha_inicio_sol.Visible = False
                dtp_fecha_termino_sol.Visible = False
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
            buscar_solicitudes(cb_opciones_busqueda.SelectedIndex)
        End If
    End Sub
    Private Sub cb_opciones_busquedas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_opciones_busqueda_sol.SelectedIndexChanged
        If cb_opciones_busqueda_sol.SelectedIndex <> -1 Then
            If cb_opciones_busqueda_sol.SelectedIndex = 0 Then 'TODOS
                dtp_fecha_busqueda_sol.Visible = False
                dtp_fecha_inicio_sol.Visible = False
                dtp_fecha_termino_sol.Visible = False
                Label11.Visible = False
                Label12.Visible = False
            ElseIf cb_opciones_busqueda_sol.SelectedIndex = 1 Then 'FECHA
                dtp_fecha_busqueda_sol.Visible = True
                dtp_fecha_inicio_sol.Visible = False
                dtp_fecha_termino_sol.Visible = False
                Label11.Visible = False
                Label12.Visible = False
            ElseIf cb_opciones_busqueda_sol.SelectedIndex = 2 Then ' PERIODO
                dtp_fecha_busqueda_sol.Visible = False
                dtp_fecha_inicio_sol.Visible = True
                dtp_fecha_termino_sol.Visible = True
                Label11.Visible = True
                Label12.Visible = True
            End If
        End If
        If cargado = True Then
            buscar_solicitudes(cb_opciones_busqueda_sol.SelectedIndex)
        End If
    End Sub

    Private Sub dtp_fecha_busqueda_sol_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_busqueda_sol.ValueChanged
        If cargado = True Then
            buscar_solicitudes(cb_opciones_busqueda_sol.SelectedIndex)
        End If
    End Sub

    Private Sub dtp_fecha_inicio_sol_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_inicio_sol.ValueChanged
        If cargado = True Then
            buscar_solicitudes(cb_opciones_busqueda_sol.SelectedIndex)
        End If
    End Sub

    Private Sub dtp_fecha_terminal_sol_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_termino_sol.ValueChanged
        If cargado = True Then
            buscar_solicitudes(cb_opciones_busqueda_sol.SelectedIndex)
        End If
    End Sub
    Private Sub cargar_opciones_busqueda()
        cb_opciones_busqueda_sol.Items.Clear()
        cb_opciones_busqueda_sol.Text = ""
        cb_opciones_busqueda_sol.Items.Add("TODOS")
        cb_opciones_busqueda_sol.Items.Add("FECHA")
        cb_opciones_busqueda_sol.Items.Add("PERIODO")
        cb_opciones_busqueda_sol.SelectedIndex = 0
        dtp_fecha_busqueda_sol.Value = Today
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Dim numero_insumos As Integer = 0
        rs.Open("SELECT COUNT(*) AS total FROM solicitud_compra_detalle WHERE id_solicitud_compra='" & id_solicitud & "' AND id_orden_compra>0", conn)
        If rs.RecordCount > 0 Then
            numero_insumos = rs.Fields("total").Value
        End If
        rs.Close()
        If numero_insumos > 0 Then

        Else
            If MsgBox("Desea cancelar esta solicitud de productos? Esta operacion no se puede deshacer.", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("UPDATE solicitud_compra SET status='CANCELADA' WHERE id_solicitud_compra='" & id_solicitud & "'")
                rs.Open("SELECT DISTINCT(id_cmi_requisicion) FROM cmi_requisicion_detalle WHERE id_solicitud_compra='" & id_solicitud & "'")
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        conn.Execute("UPDATE cmi_requisicion SET status_solicitud_compra='PENDIENTE' WHERE id_cmi_requisicion='" & rs.Fields("id_cmi_requisicion").Value & "'")
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
                conn.Execute("UPDATE cmi_requisicion_detalle SET id_solicitud_compra='0' WHERE id_solicitud_compra='" & id_solicitud & "'")
                cargar_solicitud(id_solicitud)
                'buscar_solicitudes()
                'buscar_requisiciones()
                MsgBox("Solicitud de compra cancelada correctamente", MsgBoxStyle.Information, "Aviso")
            End If

        End If
    End Sub
End Class