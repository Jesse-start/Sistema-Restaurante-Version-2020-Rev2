Public Class frm_apartados
    Private cargado As Boolean
    Private Sub frm_apartados_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_apartados = 0
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        btn_buscar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_ver_pedido.BackColor = Color.FromArgb(conf_colores(8))
        btn_ver_pedido.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        lbl_estatus_pago.ForeColor = Color.FromArgb(conf_colores(17))
        Label1.ForeColor = Color.FromArgb(conf_colores(17))
        rb_fecha.ForeColor = Color.FromArgb(conf_colores(17))
        rb_todos.ForeColor = Color.FromArgb(conf_colores(17))

    End Sub
    Private Sub frm_apartados_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        global_frm_apartados = 1
        estilo_apartados(dgv_apartado)
        aplicar_colores()
        cargar_estatus()
        dtp_fecha.Value = Date.Today
        cargar_repartidor()
        cargar_vendedores()
        cargado = True
        cargar_apartados(tb_buscar.Text)
    End Sub
    Private Sub cargar_vendedores()
        cb_vendedor.Items.Clear()
        'Conectar()
        cb_vendedor.Items.Add("TODOS")
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As Nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_vendedor.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("Nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        cb_vendedor.SelectedIndex = 0
    End Sub
    Private Sub cargar_estatus()
        cb_estatus_pago.Items.Clear()
        cb_estatus_pago.Items.Add("TODOS")
        cb_estatus_pago.Items.Add("PENDIENTE")
        cb_estatus_pago.Items.Add("PAGADO")
        cb_estatus_pago.Text = ""
        cb_estatus_pago.SelectedIndex = 0
    End Sub
    Public Sub cargar_apartados(ByVal busqueda As String)
        tabla_apartados.Clear()
        Dim filtro As String = ""
        If busqueda <> "" Then
            filtro = " AND (e.alias LIKE '%" & busqueda & "%'" & _
                         " OR e.razon_social LIKE '%" & busqueda & "%'" & _
                         " OR p.alias LIKE '%" & busqueda & "%'" & _
                         " OR p.nombre LIKE '%" & busqueda & "%'" & _
                         " OR p.ap_paterno LIKE '%" & busqueda & "%'" & _
                         " OR p.ap_materno LIKE '%" & busqueda & "%') "
        End If

        If cb_estatus_pago.Text <> "TODOS" Then
            filtro = filtro & " AND ap.status_pago='" & cb_estatus_pago.Text & "'"
        End If
        If cb_repartidor.SelectedIndex > 0 Then
            filtro = filtro & " AND ap.id_empleado_entrega='" & CType(cb_repartidor.SelectedItem, myItem).Value & "'"
        End If
        If cb_vendedor.SelectedIndex > 0 Then
            filtro = filtro & " AND v.id_empleado='" & CType(cb_vendedor.SelectedItem, myItem).Value & "'"
        End If
        If rb_fecha.Checked = True Then
            filtro = filtro & " AND DATE(ap.fecha_entrega)='" & Format(dtp_fecha.Value, "yyyy-MM-dd") & "'"
        End If
        'Conectar()
        Dim ry As New ADODB.Recordset
        rs.Open("SELECT ap.id_apartado,ap.fecha_entrega,ap.total,ap.id_venta,ap.id_empleado_entrega,ap.status_pago,ap.entregado, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
    "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
    "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
    "JOIN apartado ap ON ap.id_cliente=c.id_cliente " & _
    "JOIN venta v ON v.id_venta=ap.id_venta " & _
     "WHERE 1 " & filtro & " " & _
    "ORDER BY ap.id_apartado DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim empleado_entrega As String = "No Asignado"
                Dim status_entrega As String = ""
                Dim retiro As Decimal = 0
                If rs.Fields("entregado").Value = 1 Then
                    status_entrega = "ENTREGADO"
                Else
                    status_entrega = "NO ENTREGADO"
                End If
                ry.Open("SELECT CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS empleado FROM persona JOIN empleado ON empleado.id_persona=persona.id_persona WHERE empleado.id_empleado='" & rs.Fields("id_empleado_entrega").Value & "'", conn)
                If ry.RecordCount > 0 Then
                    empleado_entrega = ry.Fields("empleado").Value
                End If
                ry.Close()
                agregar_apartados(rs.Fields("id_apartado").Value, rs.Fields("id_venta").Value, rs.Fields("cliente_alias").Value, Format(rs.Fields("fecha_entrega").Value, "dd/MM/yyyy hh:mm;ss"), empleado_entrega, rs.Fields("total").Value, 0, 0, status_entrega, rs.Fields("status_pago").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub btn_ver_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ver_pedido.Click
        If dgv_apartado.Rows.Count > 0 Then
            If dgv_apartado.SelectedRows.Count > 0 Then
                frm_apartado_detalle.Show()
                frm_apartado_detalle.cargar_apartado_detalle(dgv_apartado.Rows(dgv_apartado.CurrentRow.Index).Cells("id_apartado").Value)
                frm_apartado_detalle.BringToFront()
            End If
        End If
    End Sub

    Private Sub dgv_pedidos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_apartado.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        For x = 0 To dgv_apartado.Columns.Count - 1
            If dgv_apartado.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_pedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_apartado.DoubleClick
        btn_ver_pedido_Click(sender, e)
    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar_apartados(tb_buscar.Text)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub cargar_repartidor()
        cb_repartidor.Items.Clear()
        cb_repartidor.Text = ""
        cb_repartidor.Items.Add("TODOS")
        rs.Open("SELECT ae.id_empleado, CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) as nombre FROM agente_entrega ae " & _
               "JOIN empleado e ON e.id_empleado=ae.id_empleado " & _
               "JOIN persona p ON p.id_persona=e.id_persona WHERE ae.status='ACTIVO'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_repartidor.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub

    Private Sub rb_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_todos.CheckedChanged
        If rb_todos.Checked = True Then
            rb_fecha.Checked = False
        End If
        If cargado = True Then
            btn_buscar_Click(sender, e)
        End If
    End Sub

    Private Sub rb_fecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_fecha.CheckedChanged
        If rb_fecha.Checked = True Then
            rb_todos.Checked = False
        End If
        If cargado = True Then
            btn_buscar_Click(sender, e)
        End If
    End Sub
    Private Sub tb_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_buscar.TextChanged
        If cargado = True Then

            If Trim(tb_buscar.Text) = "" Then
                If tb_buscar.TextLength = 0 Then
                    btn_buscar_Click(sender, e)
                End If
            Else
                If Len(tb_buscar.Text) > 2 Then
                    btn_buscar_Click(sender, e)
                End If
            End If
          
        End If
    End Sub

    Private Sub dtp_fecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha.ValueChanged
        If cargado = True Then
            btn_buscar_Click(sender, e)
        End If
    End Sub

    Private Sub cb_repartidor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_repartidor.SelectedIndexChanged
        If cargado = True Then
            btn_buscar_Click(sender, e)
        End If
    End Sub

    Private Sub cb_estatus_pago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_estatus_pago.SelectedIndexChanged
        If cargado = True Then
            btn_buscar_Click(sender, e)
        End If
    End Sub

    Private Sub cb_vendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_vendedor.SelectedIndexChanged
        If cargado = True Then
            btn_buscar_Click(sender, e)
        End If
    End Sub
End Class