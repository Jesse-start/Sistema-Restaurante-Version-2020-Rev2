Public Class frm_orden_compra
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_detalle_orden As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Private dso As DataSet
    Private tabla_lineao As DataRow
    Dim linea_o As Integer
    Public tabla_orden_compra As DataTable
    Private tabla_columnao As DataGridTextBoxColumn

    Private id_orden_compra As Integer = 0
    Private subtotal As Decimal = 0
    Private impuestos As Decimal = 0
    Private total As Decimal = 0
    Private estatus_orden As String = ""
    Private factura As String = ""
    Private cargado As Boolean
    Public lista_ordenes As Boolean

    Public Sub estilo_lista_ordenes(ByVal ordenes As DataGridView)
        tabla_orden_compra = New DataTable("ordenes")

        With tabla_orden_compra.Columns
            .Add(New DataColumn("id_orden_compra", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))

        End With
        dso = New DataSet
        dso.Tables.Add(tabla_orden_compra)

        With ordenes
            .DataSource = dso
            .DataMember = "ordenes"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            With .Columns("id_orden_compra")
                .HeaderText = "folio"
                .Width = 60
                .ReadOnly = True
            End With

            With .Columns("fecha")
                .HeaderText = "fecha"
                .Width = 60
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
    Public Sub agregar_lista_ordenes(ByVal id_orden_compra As Integer, ByVal fecha As String, ByVal total As Decimal)
        tabla_lineao = tabla_orden_compra.NewRow()
        tabla_lineao("id_orden_compra") = id_orden_compra
        tabla_lineao("fecha") = fecha
        tabla_lineao("total") = total
        tabla_orden_compra.Rows.Add(tabla_lineao)
    End Sub
    Public Sub estilo_orden_detalle(ByVal orden_detalle As DataGridView)
        tabla_detalle_orden = New DataTable("orden_detalle")

        With tabla_detalle_orden.Columns
            .Add(New DataColumn("id_orden_compra_detalle", GetType(Integer)))
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

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_detalle_orden)

        With orden_detalle
            .DataSource = ds
            .DataMember = "orden_detalle"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_orden_compra_detalle").Visible = False
            .Columns("id_orden_compra_detalle").Width = 0
            .Columns("id_cmi_requisicion_detalle").Visible = False
            .Columns("id_cmi_requisicion_detalle").Width = 0
            .Columns("id_precio_unitario_accion").Visible = False
            .Columns("id_partida").Visible = False
            .Columns("id_impuesto").Visible = False
            .Columns("id_unidad").Width = 0
            .Columns("id_unidad").Visible = False
            'With .Columns("id_producto")
            '.HeaderText = ""
            ' .Width = 0
            '.ReadOnly = True
            '.Visible = False
            'End With
            With .Columns("partida")
                .HeaderText = "partida"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
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
                .Width = 60
                .ReadOnly = False
            End With
            With .Columns("total")
                .HeaderText = "Importe + IVA"
                .Width = 65
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("impuesto")
                .HeaderText = "Impuesto"
                .Width = 0
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .Width = 65
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("total_impuesto")
                .HeaderText = "Impuesto"
                .Width = 0
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .Visible = False
            End With
        End With

        'Determinamos el alto de las filas
        orden_detalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        'Referenciamos la columna
        Dim col As DataGridViewColumn = orden_detalle.Columns("total")
        'Ajustamos la celda a su contenido.
        col.DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    Public Sub agregar_orden_detalle(ByVal id_orden_compra_detalle As Integer, ByVal id_cmi_requisicion_detalle As Integer, ByVal id_partida As Integer, ByVal partida As String, ByVal unidad As String, ByVal descripcion As String, ByVal precio_unitario As Decimal, ByVal cantidad As Decimal, ByVal total As Decimal, ByVal id_impuesto As Integer, ByVal impuesto As String, ByVal id_unidad As Integer, ByVal importe As Decimal, ByVal total_impuesto As Decimal)
        tabla_linea = tabla_detalle_orden.NewRow()
        tabla_linea("id_orden_compra_detalle") = id_orden_compra_detalle
        tabla_linea("id_cmi_requisicion_detalle") = id_cmi_requisicion_detalle
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
        tabla_detalle_orden.Rows.Add(tabla_linea)
    End Sub

    Private Sub frm_orden_compra_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub frm_solicitud_cotizacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.MdiParent = frm_principal3


        cargado = False
        estilo_orden_detalle(dgv_orden_productos)
        estilo_lista_ordenes(dgv_orden_compra)
        buscar_ordenes_compra()
        conf_inicio()
        cargado = True
        If global_id_usuario = 1 Then
            mostrar_lista_ordenes()
        Else
            If lista_ordenes = True Then
                mostrar_lista_ordenes()
            Else
                ocultar_lista_ordenes()
            End If
        End If
      

    End Sub
    Private Sub buscar_ordenes_compra()
        tabla_orden_compra.Clear()
        rs.Open("SELECT id_orden_compra,fecha,total,status FROM orden_compra", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim cancelado As Boolean = False
                If rs.Fields("status").Value = "CANCELADA" Then
                    cancelado = True
                End If
                agregar_lista_ordenes(rs.Fields("id_orden_compra").Value, Format(rs.Fields("fecha").Value, "dd-MM-yyyy"), rs.Fields("total").Value)
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
    Private Sub btn_guardar_solicitud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If id_orden_compra = 0 Then

            Dim count_seleccionado As Integer = 0
            For x = 0 To dgv_orden_productos.Rows.Count - 1
                If dgv_orden_productos.Rows(x).Cells("seleccionado").Value = True Then
                    count_seleccionado += 1
                End If
            Next

            If count_seleccionado > 0 Then
                id_orden_compra = 0
                conn.Execute("INSERT INTO solicitud_compra(fecha,id_persona_elabora,subtotal,impuestos,total) VALUES(NOW(),'" & global_id_persona & "','" & subtotal & "','" & impuestos & "','" & total & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_orden_compra = rs.Fields(0).Value
                rs.Close()

                For x = 0 To dgv_orden_productos.Rows.Count - 1
                    If dgv_orden_productos.Rows(x).Cells("seleccionado").Value = True Then
                        conn.Execute("INSERT INTO solicitud_compra_detalle(id_solicitud_compra,id_cmi_requisicion_detalle,id_precio_unitario_accion,id_partida,partida,unidad,descripcion,precio_unitario,impuesto,importe,cantidad,total,id_impuesto,total_impuesto,id_unidad,id_proveedor) " & _
                            "VALUES('" & id_orden_compra & "','" & dgv_orden_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "','" & dgv_orden_productos.Rows(x).Cells("id_precio_unitario_accion").Value & "','" & dgv_orden_productos.Rows(x).Cells("id_partida").Value & "','" & dgv_orden_productos.Rows(x).Cells("partida").Value & "','" & dgv_orden_productos.Rows(x).Cells("unidad").Value & "','" & dgv_orden_productos.Rows(x).Cells("descripcion").Value & "','" & dgv_orden_productos.Rows(x).Cells("precio_unitario").Value & "','" & dgv_orden_productos.Rows(x).Cells("impuesto").Value & "','" & dgv_orden_productos.Rows(x).Cells("importe").Value & "','" & dgv_orden_productos.Rows(x).Cells("cantidad").Value & "','" & dgv_orden_productos.Rows(x).Cells("total").Value & "','" & dgv_orden_productos.Rows(x).Cells("id_impuesto").Value & "','" & dgv_orden_productos.Rows(x).Cells("total_impuesto").Value & "','" & dgv_orden_productos.Rows(x).Cells("id_unidad").Value & "','" & dgv_orden_productos.Rows(x).Cells("id_proveedor").Value & "')")
                        conn.Execute("UPDATE cmi_requisicion_detalle SET id_solicitud_compra='" & id_orden_compra & "' WHERE id_cmi_requisicion_detalle='" & dgv_orden_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "'")
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

                buscar_ordenes_compra()
                cargar_orden_compra(id_orden_compra)
                MsgBox("Solicitud de compra guarda correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Debe seleccionar al menos un insumo/producto para guardar la solicitud de productos", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Else
            For x = 0 To dgv_orden_productos.Rows.Count - 1
                conn.Execute("UPDATE solicitud_compra_detalle SET " & _
                             "descripcion='" & dgv_orden_productos.Rows(x).Cells("descripcion").Value & "', " & _
                             "precio_unitario='" & dgv_orden_productos.Rows(x).Cells("precio_unitario").Value & "', " & _
                             "importe='" & dgv_orden_productos.Rows(x).Cells("importe").Value & "'," & _
                             "cantidad='" & dgv_orden_productos.Rows(x).Cells("cantidad").Value & "'," & _
                             "id_proveedor='" & dgv_orden_productos.Rows(x).Cells("id_proveedor").Value & "' " & _
                             "WHERE id_cmi_requisicion_detalle='" & dgv_orden_productos.Rows(x).Cells("id_cmi_requisicion_detalle").Value & "' AND id_solicitud_compra='" & id_orden_compra & "'")
            Next

        End If





    End Sub
    Public Sub cargar_orden_compra(Optional ByVal id As Integer = 0)
        id_orden_compra = id
        Dim fecha As DateTime
        Dim id_proveedor As Integer = 0


        If id_orden_compra > 0 Then
            rs.Open("SELECT oc.fecha,oc.status,oc.subtotal,oc.total_impuestos,oc.total,oc.factura,oc.folio_fiscal,oc.id_proveedor,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS persona FROM orden_compra oc " & _
                    "JOIN persona p ON p.id_persona=oc.id_persona_elabora " & _
                    "WHERE id_orden_compra='" & id_orden_compra & "'", conn)
            If rs.RecordCount > 0 Then

                tb_folio.Text = Format(id_orden_compra, "000000")
                tb_persona_elabora.Text = rs.Fields("persona").Value
                fecha = rs.Fields("fecha").Value
                dtp_fecha.Value = fecha
                dtp_hora.Value = fecha
                tb_estatus.Text = rs.Fields("status").Value
                estatus_orden = rs.Fields("status").Value
                If rs.Fields("persona").Value = "CANCELADA" Then
                    tb_aviso_cancelado.Visible = True
                Else
                    tb_aviso_cancelado.Visible = False
                End If
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                tb_impuestos.Text = FormatCurrency(rs.Fields("total_impuestos").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)
                id_proveedor = rs.Fields("id_proveedor").Value
                factura = rs.Fields("factura").Value
                tb_factura.Text = rs.Fields("factura").Value
                tb_folio_fiscal.Text = rs.Fields("folio_fiscal").Value
            End If
            rs.Close()

            rs.Open("SELECT CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
                "FROM proveedor " & _
                "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                "WHERE proveedor.id_proveedor='" & id_proveedor & "'", conn)
            If rs.RecordCount > 0 Then
                tb_proveedor.Text = rs.Fields("nombre").Value
            End If
            rs.Close()

            tabla_detalle_orden.Clear()
            rs.Open("SELECT * FROM orden_compra_detalle WHERE  id_orden_compra='" & id_orden_compra & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_orden_detalle(rs.Fields("id_orden_compra_detalle").Value, rs.Fields("id_cmi_requisicion_detalle").Value, rs.Fields("id_partida").Value, rs.Fields("partida").Value, rs.Fields("unidad").Value, rs.Fields("descripcion").Value, rs.Fields("precio_unitario").Value, rs.Fields("cantidad").Value, rs.Fields("total").Value, rs.Fields("id_impuesto").Value, rs.Fields("impuesto").Value, rs.Fields("id_unidad").Value, rs.Fields("importe").Value, rs.Fields("total_impuesto").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()


            ' btn_nuevo.Enabled = True
            'btn_guardar.Enabled = False
            btn_generar_formato.Enabled = True
            btn_cancelar.Enabled = True
            'btn_editar.Enabled = True
            'btn_deshacer.Enabled = False
        Else
            conf_inicio()
            ' btn_nuevo.Enabled = False
            ' btn_guardar.Enabled = True
            btn_generar_formato.Enabled = False
            btn_cancelar.Enabled = False
            ' btn_editar.Enabled = False
            ' btn_deshacer.Enabled = True
        End If
    End Sub
    Private Sub conf_inicio()
        tabla_detalle_orden.Clear()
        tb_folio.Text = "000000"
        tb_persona_elabora.Text = global_nombre
        dtp_fecha.Value = Now
        dtp_hora.Value = Now
        tb_subtotal.Text = FormatCurrency(0)
        tb_impuestos.Text = FormatCurrency(0)
        tb_total.Text = FormatCurrency(0)
        tb_estatus.Text = "PENDIENTE"
        tb_aviso_cancelado.Visible = False
        factura = ""

        ' btn_nuevo.Enabled = True
        ' btn_guardar.Enabled = False
        btn_generar_formato.Enabled = False
        btn_cancelar.Enabled = False
        ' btn_editar.Enabled = False
        'btn_deshacer.Enabled = False
    End Sub
    Private Sub actualizar_totales()
        subtotal = 0
        impuestos = 0
        total = 0
        For x = 0 To dgv_orden_productos.Rows.Count - 1
            If dgv_orden_productos.Rows(x).Cells("seleccionado").Value = True Then
                subtotal += dgv_orden_productos.Rows(x).Cells("importe").Value
                impuestos += dgv_orden_productos.Rows(x).Cells("total_impuesto").Value
                total += dgv_orden_productos.Rows(x).Cells("total").Value
            End If
        Next
        tb_subtotal.Text = FormatCurrency(subtotal)
        tb_impuestos.Text = FormatCurrency(impuestos)
        tb_total.Text = FormatCurrency(total)
    End Sub
    Private Sub dgv_solicitud_productos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_orden_productos.CellValueChanged
        If cargado = True Then
            actualizar_totales()
        End If

    End Sub
    Private Sub dgv_solicitudes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_solicitudes.DoubleClick
        If dgv_solicitudes.SelectedRows.Count > 0 Then
            cargar_orden_compra(dgv_solicitudes.Rows(dgv_solicitudes.CurrentRow.Index).Cells("id_solicitud_compra").Value)
        End If
    End Sub
    Private Sub dgv_orden_compra_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_orden_compra.DoubleClick
        If dgv_orden_compra.SelectedRows.Count > 0 Then
            cargar_orden_compra(dgv_orden_compra.Rows(dgv_orden_compra.CurrentRow.Index).Cells("id_orden_compra").Value)
        End If
    End Sub
    Private Sub btn_ocultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ocultar.Click
        ocultar_lista_ordenes()
    End Sub
    Private Sub btn_mostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mostrar.Click
        mostrar_lista_ordenes()
    End Sub
    Private Sub ocultar_lista_ordenes()
        Panel1.Visible = False
        Me.Width = 762
    End Sub
    Private Sub mostrar_lista_ordenes()
        Panel1.Visible = True
        Me.Width = 1068
    End Sub
    Private Sub btn_guardar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Confirme que desea actualizar la informacion de la factura", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Aviso") = MsgBoxResult.Yes Then
            conn.Execute("UPDATE orden_compra SET factura='" & tb_factura.Text & "',folio_fiscal='" & tb_folio_fiscal.Text & "' WHERE id_orden_compra='" & id_orden_compra & "'")
            cargar_orden_compra(id_orden_compra)
        End If
    End Sub
End Class