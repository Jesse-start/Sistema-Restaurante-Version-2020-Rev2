Public Class frm_pedidos_clientes

    Private Sub frm_pedidos_clientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_pedidos_clientes = 0
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
        Label2.ForeColor = Color.FromArgb(conf_colores(17))
        rb_fecha.ForeColor = Color.FromArgb(conf_colores(17))
        rb_todos.ForeColor = Color.FromArgb(conf_colores(17))

    End Sub
    Private Sub frm_pedidos_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_pedidos_clientes = 1
        estilo_pedidos(dgv_pedidos)
        aplicar_colores()
        cargar_estatus()
        dtp_fecha.Value = Date.Today
        cargar_repartidor()
        If cb_estatus.SelectedIndex = -1 Then
            cb_estatus.SelectedIndex = 0
        End If
        cargar_pedidos(tb_buscar.Text)
    End Sub
    Private Sub cargar_estatus()
        cb_estatus.Items.Clear()
        cb_estatus_pago.Items.Clear()

        cb_estatus.Items.Add("TODOS")
        cb_estatus.Items.Add("PENDIENTE")
        cb_estatus.Items.Add("SURTIDO")
        cb_estatus.Items.Add("ENVIADO")
        cb_estatus.Items.Add("SUMINISTRADO")

        cb_estatus_pago.Items.Add("TODOS")
        cb_estatus_pago.Items.Add("PENDIENTE")
        cb_estatus_pago.Items.Add("NOTA")
        cb_estatus_pago.Items.Add("PAGADO")

        cb_estatus.Text = ""
        cb_estatus_pago.Text = ""
    End Sub
    Public Sub cargar_pedidos(ByVal busqueda As String)
        tabla_pedidos.Clear()
        Dim filtro As String = ""
        If busqueda <> "" Then
            filtro = " AND (e.alias LIKE '%" & busqueda & "%'" & _
                         " OR e.razon_social LIKE '%" & busqueda & "%'" & _
                         " OR p.alias LIKE '%" & busqueda & "%'" & _
                         " OR p.nombre LIKE '%" & busqueda & "%'" & _
                         " OR p.ap_paterno LIKE '%" & busqueda & "%'" & _
                         " OR p.ap_materno LIKE '%" & busqueda & "%') "
        End If
        If cb_estatus.Text <> "TODOS" Then
            filtro = filtro & " AND pc.status='" & cb_estatus.Text & "'"
        End If
        If cb_estatus.Text = "SUMINISTRADO" Then
            If cb_estatus_pago.Text <> "TODOS" Then
                filtro = filtro & " AND pc.status_pago='" & cb_estatus_pago.Text & "'"
            End If
        End If
        If cb_repartidor.SelectedIndex > -1 Then
            filtro = filtro & " AND pc.id_empleado_entrega='" & CType(cb_repartidor.SelectedItem, myItem).Value & "'"
        End If
        If rb_fecha.Checked = True Then
            filtro = filtro & " AND DATE(pc.fecha_entrega)='" & Format(dtp_fecha.Value, "yyyy-MM-dd") & "'"
        End If
        'Conectar()
        Dim ry As New ADODB.Recordset
        rs.Open("SELECT pc.id_pedido,pc.fecha_entrega,pc.total,pc.id_venta,pc.id_empleado_entrega,pc.status,pc.status_pago,pc.id_retiro, CASE WHEN c.id_persona = 0 THEN  e.alias ELSE p.alias END AS cliente_alias FROM cliente c " & _
    "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
    "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & _
    "JOIN pedido_clientes pc ON pc.id_cliente=c.id_cliente " & _
     "WHERE 1 " & filtro & " " & _
    "ORDER BY pc.id_pedido DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim empleado_entrega As String = "No Asignado"
                Dim retiro As Decimal = 0
                ry.Open("SELECT CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS empleado FROM persona JOIN empleado ON empleado.id_persona=persona.id_persona WHERE empleado.id_empleado='" & rs.Fields("id_empleado_entrega").Value & "'", conn)
                If ry.RecordCount > 0 Then
                    empleado_entrega = ry.Fields("empleado").Value
                End If
                ry.Close()
                If rs.Fields("id_retiro").Value > 0 Then

                    ry.Open("SELECT cantidad FROM retiros WHERE id_retiro='" & rs.Fields("id_retiro").Value & "'", conn)
                    If ry.RecordCount > 0 Then
                        retiro = ry.Fields("cantidad").Value
                    End If
                    ry.Close()
                End If
                agregar_pedidos(rs.Fields("id_pedido").Value, rs.Fields("id_venta").Value, rs.Fields("cliente_alias").Value, Format(rs.Fields("fecha_entrega").Value, "dd/MM/yyyy hh:mm;ss"), empleado_entrega, rs.Fields("total").Value, retiro, rs.Fields("total").Value + retiro, rs.Fields("status").Value, rs.Fields("status_pago").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub btn_ver_pedido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ver_pedido.Click
        If dgv_pedidos.Rows.Count > 0 Then
            If dgv_pedidos.SelectedRows.Count > 0 Then
                frm_pedidos_detalle.Show()
                frm_pedidos_detalle.cargar_detalle_pedido(dgv_pedidos.Rows(dgv_pedidos.CurrentRow.Index).Cells("id_pedido").Value)
                frm_pedidos_detalle.BringToFront()
            End If
        End If
    End Sub

    Private Sub dgv_pedidos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_pedidos.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        For x = 0 To dgv_pedidos.Columns.Count - 1
            If dgv_pedidos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_pedidos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pedidos.DoubleClick
        btn_ver_pedido_Click(sender, e)
    End Sub
    Private Sub cb_estatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_estatus.SelectedIndexChanged
        If cb_estatus.Text = "SUMINISTRADO" Then
            cb_estatus_pago.Visible = True
            lbl_estatus_pago.Visible = True
        Else
            cb_estatus_pago.Visible = False
            lbl_estatus_pago.Visible = False
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar_pedidos(tb_buscar.Text)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub cargar_repartidor()
        cb_repartidor.Items.Clear()
        cb_repartidor.Text = ""
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
    End Sub

    Private Sub rb_fecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_fecha.CheckedChanged
        If rb_fecha.Checked = True Then
            rb_todos.Checked = False
        End If
    End Sub
End Class