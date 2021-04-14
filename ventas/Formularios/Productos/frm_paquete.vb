Public Class frm_paquete
    Private modificadores(9, 1) As Object
    Public id_producto As Integer
    Private index_modificador As Integer = 0
    Public cantidad As Decimal
    Public id_temp_venta_detalle As Integer
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        btn_anterior.BackColor = Color.FromArgb(conf_colores(8))
        btn_anterior.ForeColor = Color.FromArgb(conf_colores(9))
        btn_siguiente.BackColor = Color.FromArgb(conf_colores(8))
        btn_siguiente.ForeColor = Color.FromArgb(conf_colores(9))
        tb_cantidad.ForeColor = Color.FromArgb(conf_colores(17))
        tb_nombre_modificador.ForeColor = Color.FromArgb(conf_colores(17))
        tb_nombre_paquete.ForeColor = Color.FromArgb(conf_colores(17))
        tb_unidad.ForeColor = Color.FromArgb(conf_colores(17))

    End Sub
    Private Sub frm_paquete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        estilo_tabla_paquete_modificador(dgv_paquete_modificador)
        estilo_tabla_paquete_seleccion(dgv_paquete_seleccion)
        cargar(id_producto)
    End Sub
    Private Sub limpiar_modificadores()
        For x = 0 To 9
            For j = 0 To 1
                modificadores(x, j) = Nothing
            Next
        Next
    End Sub
    Private Sub cargar(ByVal id As Integer)
        index_modificador = 0
        limpiar_modificadores()
        id_producto = id
        Dim bThumb As Byte()

        Dim thumb As System.Drawing.Image


        'Conectar()
        '--- cargamos los modificadores a la matriz
        Dim i As Integer = 0

        rs.Open("SELECT producto_modificador.id_modificador, modificadores.nombre, producto.nombre AS paquete,producto.thumb,unidad.nombre as unidad FROM producto_modificador JOIN modificadores ON modificadores.id_modificador=producto_modificador.id_modificador JOIN producto ON producto.id_producto=producto_modificador.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE producto_modificador.id_producto=" & id_producto, conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("thumb").Value) Then
                bThumb = CType(rs.Fields("thumb").Value, Byte())
                thumb = New Bitmap(Bytes_Imagen(bThumb))
            Else
                thumb = ventas.My.Resources._50CENTAVOS
            End If
            pb_paquete.Image = thumb
            tb_cantidad.Text = cantidad
            tb_nombre_paquete.Text = rs.Fields("paquete").Value
            tb_unidad.Text = rs.Fields("unidad").Value
            While Not rs.EOF
                modificadores(i, 0) = rs.Fields("id_modificador").Value
                modificadores(i, 1) = rs.Fields("nombre").Value
                i = i + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        cargar_productos_modificador(index_modificador)
        btn_anterior.Enabled = False
        If Not IsNothing(modificadores(index_modificador + 1, 0)) Then
            btn_siguiente.Enabled = True
        Else
            btn_siguiente.Enabled = False
        End If
    End Sub
    Private Sub cargar_productos_modificador(ByVal matrix_index As Integer)
        If Not IsNothing(modificadores(matrix_index, 0)) Then
            tb_nombre_modificador.Text = modificadores(matrix_index, 1)
            tabla_paquete_modificador.Clear()
            'Conectar()
            rs.Open("SELECT paquete_modificador_producto.id_producto,paquete_modificador_producto.cantidad, producto.nombre, unidad.nombre AS unidad,producto.thumb,producto.codigo " & _
                    "FROM paquete_modificador_producto " & _
                    "JOIN producto ON producto.id_producto=paquete_modificador_producto.id_producto " & _
                    "JOIN unidad ON unidad.id_unidad=producto.id_unidad " & _
                    " WHERE paquete_modificador_producto.id_paquete ='" & id_producto & "' And paquete_modificador_producto.id_modificador =" & modificadores(matrix_index, 0), conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim miniatura As Image = obtener_miniatura(rs.Fields("thumb").Value)
                    agregar_producto_paquete(rs.Fields("id_producto").Value, miniatura, rs.Fields("nombre").Value, rs.Fields("unidad").Value, rs.Fields("cantidad").Value, 1, rs.Fields("codigo").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
        End If
    End Sub

    Private Sub btn_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_siguiente.Click
        index_modificador += 1
        btn_anterior.Enabled = True
        cargar_productos_modificador(index_modificador)

        If Not IsNothing(modificadores(index_modificador + 1, 0)) Then
            btn_siguiente.Enabled = True
        Else
            btn_siguiente.Enabled = False
        End If
    End Sub

    Private Sub btn_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_anterior.Click
        index_modificador -= 1
        cargar_productos_modificador(index_modificador)
        If index_modificador - 1 = 0 Then
            btn_anterior.Enabled = True
        Else
            btn_anterior.Enabled = False
        End If
        If Not IsNothing(modificadores(index_modificador + 1, 0)) Then
            btn_siguiente.Enabled = True
        Else
            btn_siguiente.Enabled = False
        End If
    End Sub
    Private Sub dgv_paquete_modificador_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_paquete_modificador.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_paquete_modificador.Columns.Count - 1
            If dgv_paquete_modificador.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub dgv_paquete_modificador_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_paquete_modificador.DoubleClick
        If tabla_paquete_modificador.Rows.Count > 0 Then
            Dim stock As Decimal = validar_existencia_producto(dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value, global_current_idalmacen)
            Dim cantidad_total As Decimal = dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("cantidad").Value * cantidad
            If stock >= CDec(cantidad_total) Then
                '===============AGREGAMOS EL PRODUCTO A LA LISTA============================================
_ENVIAR_NEGATIVO:  '---buscamos y borramos seleccion anterior

                If frm_principal3.modo_venta = 0 Then ' modo venta_rapida
                    For x = 0 To dgv_paquete_seleccion.Rows.Count - 1
                        If dgv_paquete_seleccion.Rows(x).Cells("id_modificador").Value = modificadores(index_modificador, 0) Then
                            Dim id_almacen As Integer
                            Dim id_temp_venta_detalle As Integer
                            'Conectar()
                            rs.Open("SELECT id_temp_venta_detalle,id_almacen from temp_venta_detalle WHERE id_producto='" & dgv_paquete_seleccion.Rows(x).Cells("id_producto").Value & "' AND id_empleado='" & global_id_empleado & "' ORDER BY id_temp_venta_detalle", conn)
                            If rs.RecordCount > 0 Then
                                id_almacen = rs.Fields("id_almacen").Value
                                id_temp_venta_detalle = rs.Fields("id_temp_venta_detalle").Value
                            End If
                            rs.Close()
                            conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad+" & CDec(dgv_paquete_seleccion.Rows(x).Cells("cantidad").Value) & ") WHERE id_producto='" & dgv_paquete_seleccion.Rows(x).Cells("id_producto").Value & "' AND id_almacen='" & id_almacen & "'")
                            conn.Execute("DELETE FROM temp_venta_detalle WHERE id_temp_venta_detalle=" & id_temp_venta_detalle)
                            'conn.close()

                            dgv_paquete_seleccion.Rows.RemoveAt(dgv_paquete_seleccion.Rows(x).Index)

                            frm_principal3.buscar_borrar_linea(id_temp_venta_detalle)

                            Exit For
                        End If
                    Next
                    '---------------------------------------
                    '===========================================================================================
                    '-agregamos a temporal----
                    Dim id_temp_venta As Integer

                    conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,nombre,cantidad,precio,importe,total_impuestos,nombre_impuestos,tasa_impuestos,id_cliente,id_almacen,desc_global_porcent,modificador,id_producto_modificador) " & _
                                 "VALUES(" & global_id_empleado & "," & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value & ",'>>" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("nombre").Value & "','" & cantidad_total & "','0','0','0','',"",'" & global_current_idcliente & "','" & global_current_idalmacen & "','" & global_current_descuento_global & "','1','" & id_producto & "')")
                    Dim rx As New ADODB.Recordset
                    rx.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_temp_venta = rx.Fields(0).Value
                    rx.Close()
                    conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & CDec(cantidad_total) & ") WHERE id_producto='" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value & "' AND id_almacen='" & global_current_idalmacen & "'")
                    '----------------
                    agregar_paquete_selecion(dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("miniatura").Value, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("nombre").Value, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("unidad").Value, cantidad_total, modificadores(index_modificador, 0), global_current_idalmacen)
                    agregar_producto(dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value, ">>" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("nombre").Value, cantidad_total, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("unidad").Value, 0, 0, 0, global_current_idalmacen, "", 0, id_temp_venta, 1, id_producto)
                    If btn_siguiente.Enabled = True Then
                        btn_siguiente_Click(sender, e)
                    Else
                        Me.Close()
                    End If
                Else ' modo venta_comedor
                    Dim id_orden_comedor_detalle As Integer = 0
                    For x = 0 To dgv_paquete_seleccion.Rows.Count - 1
                        If dgv_paquete_seleccion.Rows(x).Cells("id_modificador").Value = modificadores(index_modificador, 0) Then
                            Dim id_almacen As Integer
                            Dim id_temp_venta_detalle As Integer
                            'Conectar()
                            rs.Open("SELECT id_orde_comedor_detalle,id_almacen from orden_comedor_detalle WHERE id_producto='" & dgv_paquete_seleccion.Rows(x).Cells("id_producto").Value & "' AND id_empleado='" & global_id_empleado & "' ORDER BY id_orden_comedor_detalle", conn)
                            If rs.RecordCount > 0 Then
                                id_almacen = rs.Fields("id_almacen").Value
                                id_orden_comedor_detalle = rs.Fields("id_orden_comedor_detalle").Value
                            End If
                            rs.Close()
                            conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad+" & CDec(dgv_paquete_seleccion.Rows(x).Cells("cantidad").Value) & ") WHERE id_producto='" & dgv_paquete_seleccion.Rows(x).Cells("id_producto").Value & "' AND id_almacen='" & id_almacen & "'")
                            conn.Execute("DELETE FROM orden_comedor_detalle WHERE id_orden_comedor_detalle=" & id_orden_comedor_detalle)
                            'conn.close()

                            dgv_paquete_seleccion.Rows.RemoveAt(dgv_paquete_seleccion.Rows(x).Index)

                            frm_principal3.buscar_borrar_linea(id_orden_comedor_detalle)
                            Exit For
                        End If
                    Next
                    '---------------------------------------
                    '===========================================================================================
                    '-agregamos a temporal----
                    Dim id_temp_venta As Integer
                    'Conectar()
                    conn.Execute("INSERT INTO orden_comedor_detalle(id_orden_comedor,id_empleado,id_producto,descripcion,unidad,cantidad,precio,importe,total_iva,total_otros,id_cliente,id_almacen,nombre_impuestos,descuento,desc_global_porcent,modificador,id_producto_modificador) VALUES('" & frm_principal3.id_orden & "'," & global_id_empleado & "," & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value & ",'>>" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("nombre").Value & "','" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("unidad").Value & "','" & cantidad_total & "','0','0','0','0','" & global_current_idcliente & "','" & global_current_idalmacen & "','','0','" & global_current_descuento_global & "','1','" & id_producto & "')")
                    Dim rx As New ADODB.Recordset
                    rx.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_temp_venta = rx.Fields(0).Value
                    rx.Close()
                    conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & CDec(cantidad_total) & ") WHERE id_producto='" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value & "' AND id_almacen='" & global_current_idalmacen & "'")
                    'conn.close()
                    'conn = Nothing
                    '----------------
                    agregar_paquete_selecion(dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("miniatura").Value, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("nombre").Value, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("unidad").Value, cantidad_total, modificadores(index_modificador, 0), global_current_idalmacen)
                    agregar_producto(dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("id_producto").Value, ">>" & dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("nombre").Value, cantidad_total, dgv_paquete_modificador.Rows(dgv_paquete_modificador.CurrentRow.Index).Cells("unidad").Value, 0, 0, 0, global_current_idalmacen, "", 0, id_temp_venta, 1, id_producto)
                    If btn_siguiente.Enabled = True Then
                        btn_siguiente_Click(sender, e)
                    Else
                        Me.Close()
                    End If
                End If
            Else
                If conf_pv(3) = 1 Then
                    GoTo _ENVIAR_NEGATIVO
                Else
                    MsgBox("No se puede agregar esta producto al paquete, no se encuentran existencias en stock", MsgBoxStyle.Exclamation, "AVISO")
                End If
            End If
        End If
    End Sub
    Private Sub dgv_paquete_seleccion_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_paquete_seleccion.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_paquete_seleccion.Columns.Count - 1
            If dgv_paquete_seleccion.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
End Class