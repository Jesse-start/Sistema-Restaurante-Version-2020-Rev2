Public Class frm_comedor
    Public current_id_orden_comedor As Integer
    Private subtotal As Decimal = 0
    Private total_iva As Decimal = 0
    Private total_otros As Decimal = 0
    Private impuestos As Decimal = 0
    Private total As Decimal = 0
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label6.ForeColor = Color.FromArgb(conf_colores(13))
        Label7.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        Label9.ForeColor = Color.FromArgb(conf_colores(13))
        Label13.ForeColor = Color.FromArgb(conf_colores(13))
        Label15.ForeColor = Color.FromArgb(conf_colores(13))

        Label1.BackColor = Color.FromArgb(conf_colores(1))
        Label2.BackColor = Color.FromArgb(conf_colores(1))
        Label3.BackColor = Color.FromArgb(conf_colores(1))
        Label4.BackColor = Color.FromArgb(conf_colores(1))
        Label5.BackColor = Color.FromArgb(conf_colores(1))
        Label6.BackColor = Color.FromArgb(conf_colores(1))
        Label7.BackColor = Color.FromArgb(conf_colores(1))
        Label8.BackColor = Color.FromArgb(conf_colores(1))
        Label9.BackColor = Color.FromArgb(conf_colores(1))
        Label13.BackColor = Color.FromArgb(conf_colores(1))
        Label15.BackColor = Color.FromArgb(conf_colores(1))

        btn_general.BackColor = Color.FromArgb(conf_colores(8))
        btn_general.ForeColor = Color.FromArgb(conf_colores(9))

        btn_abrir_cuenta.BackColor = Color.FromArgb(conf_colores(8))
        btn_abrir_cuenta.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cancela_producto.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancela_producto.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cambio_cuenta.BackColor = Color.FromArgb(conf_colores(8))
        btn_cambio_cuenta.ForeColor = Color.FromArgb(conf_colores(9))
        btn_juntar_cuentas.BackColor = Color.FromArgb(conf_colores(8))
        btn_juntar_cuentas.ForeColor = Color.FromArgb(conf_colores(9))
        btn_dividir_cuenta.BackColor = Color.FromArgb(conf_colores(8))
        btn_dividir_cuenta.ForeColor = Color.FromArgb(conf_colores(9))
        btn_imprimir_cuenta.BackColor = Color.FromArgb(conf_colores(8))
        btn_imprimir_cuenta.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_captura.BackColor = Color.FromArgb(conf_colores(8))
        btn_captura.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cambio_mesero.BackColor = Color.FromArgb(conf_colores(8))
        btn_cambio_mesero.ForeColor = Color.FromArgb(conf_colores(9))
        btn_traspaso_producto.BackColor = Color.FromArgb(conf_colores(8))
        btn_traspaso_producto.ForeColor = Color.FromArgb(conf_colores(9))
        btn_pagar_cuenta.BackColor = Color.FromArgb(conf_colores(8))
        btn_pagar_cuenta.ForeColor = Color.FromArgb(conf_colores(9))
        btn_reabrir_cuenta.BackColor = Color.FromArgb(conf_colores(8))
        btn_reabrir_cuenta.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir_cuenta.Click
        frm_abrir_cuenta.Show()
        frm_abrir_cuenta.BringToFront()
    End Sub
    Private Sub actualizar_totales()
        subtotal = 0
        total_iva = 0
        total_otros = 0
        impuestos = 0
        total = 0

        rs.Open("SELECT CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE (SUM(importe)) END AS subtotal FROM orden_comedor_detalle WHERE id_orden_comedor=" & current_id_orden_comedor & "", conn)
        If rs.RecordCount > 0 Then
            subtotal = rs.Fields("subtotal").Value
            impuestos = 0
            total = subtotal + impuestos
        End If
        rs.Close()

        tb_subtotal.Text = FormatCurrency(subtotal)
        tb_impuestos.Text = FormatCurrency(impuestos)
        tb_total.Text = FormatCurrency(total)
    End Sub
    Private Sub frm_comedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        Centrar(gb_comedor)
        estilo_cuentas(dgv_busqueda)
        cargar_cuentas()
        'cargar_mesas()

        With lst_productos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Cantidad", 100)
            .Columns.Add("Unidad", 100)
            .Columns.Add("Nombre", 300)
            .Columns.Add("Precio_unitario", 100)
            .Columns.Add("Importe", 100)
        End With
    End Sub
    Public Sub cargar_mesas()
        rs.Open("SELECT id_mesa,nombre FROM mesas", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_tabla_cuentas(rs.Fields("nombre").Value, "No asignado", 0)
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub
    Public Sub cargar_cuentas()

        tb_cuenta.Text = ""
        tb_area.Text = ""
        tb_apertura.Text = ""
        tb_personas.Text = ""
        tb_mesero.Text = ""
        tb_orden.Text = ""

        tabla_cuentas.Clear()
        lst_productos.Items.Clear()

        rs.Open("SELECT oc.id_orden, oc.cuenta,m.nombre AS mesero FROM orden_comedor oc " & _
                " JOIN meseros m ON m.id_mesero=oc.id_mesero " & _
                " WHERE oc.estatus<>'CERRADA'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_tabla_cuentas(rs.Fields("cuenta").Value, rs.Fields("mesero").Value, rs.Fields("id_orden").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        If dgv_busqueda.Rows.Count > 0 Then


            'Scroll to the last row.
            Me.dgv_busqueda.FirstDisplayedScrollingRowIndex = Me.dgv_busqueda.RowCount - 1

            'Clear the last selection
            Me.dgv_busqueda.ClearSelection()

            'Select the last row.
            Me.dgv_busqueda.Rows(Me.dgv_busqueda.RowCount - 1).Selected = True

            cargar_orden(dgv_busqueda.Rows(Me.dgv_busqueda.RowCount - 1).Cells("id_orden").Value)
        Else
            btn_abrir_cuenta.Enabled = True
            btn_cambio_cuenta.Enabled = False
            btn_cambio_mesero.Enabled = False
            btn_cancela_producto.Enabled = False
            btn_captura.Enabled = False
            btn_dividir_cuenta.Enabled = False
            btn_imprimir_cuenta.Enabled = False
            btn_juntar_cuentas.Enabled = False
            btn_pagar_cuenta.Enabled = False
            btn_reabrir_cuenta.Enabled = False
            btn_salir.Enabled = True
            btn_traspaso_producto.Enabled = False
        End If

    End Sub
    Public Sub cargar_orden(ByVal id_orden As Integer)
        current_id_orden_comedor = id_orden
        rs.Open("SELECT oc.estatus,oc.id_orden, oc.cuenta,m.nombre AS mesero ,oc.num_personas,oc.apertura,ac.nombre AS AREA " & _
                "FROM orden_comedor oc " & _
                "JOIN meseros m ON m.id_mesero=oc.id_mesero " & _
                "JOIN areas_comedor ac ON ac.id_area_comedor=oc.id_area " & _
                "WHERE oc.id_orden='" & id_orden & "'", conn)
        If rs.RecordCount > 0 Then
            tb_cuenta.Text = rs.Fields("cuenta").Value
            tb_area.Text = rs.Fields("area").Value
            tb_apertura.Text = Format(rs.Fields("apertura").Value, "dd/MM/yyyy -hh:mm:ss")
            tb_personas.Text = rs.Fields("num_personas").Value
            tb_mesero.Text = rs.Fields("mesero").Value
            tb_orden.Text = Format(rs.Fields("id_orden").Value, "000000")

            If rs.Fields("estatus").Value = "PENDIENTE" Then
                btn_abrir_cuenta.Enabled = True
                btn_cambio_cuenta.Enabled = True
                btn_cambio_mesero.Enabled = True
                btn_cancela_producto.Enabled = True
                btn_captura.Enabled = True
                btn_dividir_cuenta.Enabled = True
                btn_imprimir_cuenta.Enabled = True
                btn_juntar_cuentas.Enabled = True
                btn_pagar_cuenta.Enabled = True
                btn_reabrir_cuenta.Enabled = True
                btn_salir.Enabled = True
                btn_traspaso_producto.Enabled = True
            ElseIf rs.Fields("estatus").Value = "IMPRESA" Then
                btn_abrir_cuenta.Enabled = True
                btn_cambio_cuenta.Enabled = False
                btn_cambio_mesero.Enabled = False
                btn_cancela_producto.Enabled = False
                btn_captura.Enabled = False
                btn_dividir_cuenta.Enabled = False
                btn_imprimir_cuenta.Enabled = True
                btn_juntar_cuentas.Enabled = False
                btn_pagar_cuenta.Enabled = True
                btn_reabrir_cuenta.Enabled = True
                btn_salir.Enabled = True
                btn_traspaso_producto.Enabled = False
            End If
        End If
        rs.Close()

        lst_productos.Items.Clear()
        rs.Open("Select * FROM orden_comedor_detalle WHERE id_orden_comedor='" & id_orden & "'", conn)
        If rs.RecordCount > 0 Then
            Dim i = 0
            While Not rs.EOF

                Dim str(4) As String
                str(0) = rs.Fields("cantidad").Value
                str(1) = rs.Fields("unidad").Value
                str(2) = rs.Fields("descripcion").Value
                str(3) = FormatCurrency(rs.Fields("precio").Value)
                str(4) = FormatCurrency(rs.Fields("importe").Value)

                lst_productos.Items.Add(New ListViewItem(str, 0))
                lst_productos.Items(i).Tag = rs.Fields("id_orden_comedor_detalle").Value
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()
        actualizar_totales()
    End Sub

    Private Sub dgv_busqueda_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_busqueda.CellFormatting
        For x = 0 To dgv_busqueda.Columns.Count - 1

            If dgv_busqueda.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If

            If dgv_busqueda.Rows(e.RowIndex).Cells("id_orden").Value > 0 Then
                e.CellStyle.BackColor = Color.DarkOrange
                e.CellStyle.ForeColor = Color.White
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If

        Next
    End Sub

    Private Sub dgv_busqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_busqueda.Click
        If dgv_busqueda.SelectedRows.Count > 0 Then
            current_id_orden_comedor = dgv_busqueda.Rows(dgv_busqueda.CurrentRow.Index).Cells("id_orden").Value
            cargar_orden(dgv_busqueda.Rows(dgv_busqueda.CurrentRow.Index).Cells("id_orden").Value)
        End If
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Dispose()
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_captura.Click
        frm_principal3.modo_venta = 1
        frm_principal3.id_orden = current_id_orden_comedor
        frm_principal3.cargar_usuario_actual()
        frm_principal3.Show()
    End Sub
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir_cuenta.Click
        imprimir_orden_comedor(current_id_orden_comedor, 0)
        conn.Execute("UPDATE orden_comedor SET estatus='IMPRESA' WHERE id_orden='" & current_id_orden_comedor & "'")
        cargar_orden(current_id_orden_comedor)
        Me.BringToFront()
    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reabrir_cuenta.Click
        conn.Execute("UPDATE orden_comedor SET estatus='PENDIENTE' WHERE id_orden='" & current_id_orden_comedor & "'")
        cargar_orden(current_id_orden_comedor)
    End Sub

    Private Sub btn_pagar_cuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagar_cuenta.Click

        Dim cliente_publico_alias As String = ""
        Dim id_venta As Integer

        conn.Execute("INSERT INTO venta(fecha,id_sucursal,id_empleado,id_cliente,cliente_publico_alias,subtotal,total_iva,total_otros,total_descuento,total,desc_global_porcent,desc_global_importe) VALUES(NOW()," & global_id_sucursal & "," & global_id_empleado & ",'1','PUBLICO EN GENERAL','" & subtotal & "','" & total_iva & "','" & total_otros & "','0','" & total & "','0','0')")
        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        id_venta = rs.Fields(0).Value
        conn.Execute("UPDATE venta SET num_ticket=" & id_venta & " WHERE id_venta=" & id_venta)
        rs.Close()

        rs.Open("SELECT * FROM orden_comedor_detalle WHERE id_orden_comedor='" & current_id_orden_comedor & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim ry As New ADODB.Recordset
                Dim producto_costo As Decimal = 0
                ry.Open("SELECT costo FROM producto WHERE id_producto='" & rs.Fields("id_producto").Value & "'", conn)
                If ry.RecordCount > 0 Then
                    producto_costo = ry.Fields("costo").Value
                End If
                ry.Close()

                conn.Execute("INSERT INTO venta_detalle(id_venta,id_producto,producto_costo,cantidad,total_porcent_iva,total_porcent_otros,nombre_impuestos,precio,impuesto,descripcion,unidad,id_almacen,descuento,importe,modificador,id_producto_modificador)" & _
                     " VALUES(" & id_venta & "," & rs.Fields("id_producto").Value & ",'" & producto_costo & "','" & rs.Fields("cantidad").Value & "','" & total_iva & "','" & total_otros & "','','" & rs.Fields("precio").Value & "','0','" & rs.Fields("descripcion").Value & "','" & rs.Fields("unidad").Value & "','" & global_current_idalmacen & "','0','" & rs.Fields("importe").Value & "','" & rs.Fields("modificador").Value & "','" & rs.Fields("id_producto_modificador").Value & "')")

                rs.MoveNext()
            End While
        End If
        rs.Close()

        conn.Execute("UPDATE orden_comedor SET estatus='CERRADA',cierre=NOW(),id_venta='" & id_venta & "' WHERE id_orden='" & current_id_orden_comedor & "'")
        Me.cargar_cuentas()
        frm_caja.Show()
    End Sub

    Private Sub dgv_busqueda_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_busqueda.CellContentClick

    End Sub
End Class