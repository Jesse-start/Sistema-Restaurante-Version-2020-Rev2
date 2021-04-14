Public Class frm_configuracion_conversiones
    Dim tabla_conversiones As New DataTable
    Private Linea As DataRow

    Private Sub frm_configuracion_conversiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        cargar()
    End Sub
    Private Sub cargar()
        Conversiones("Conversiones", dg_conversiones, tabla_conversiones)
        '------obtenemos los productos----------
        'Conectar()
        rs.Open("SELECT id_producto, CONCAT(producto.nombre,' UNIDAD:',unidad.nombre) As nombre FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad ORDER By nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        cb_producto_origen.Items.Clear()
        cb_producto_salida.Items.Clear()
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_producto_origen.Items.Add(New myItem(rs.Fields("id_producto").Value, rs.Fields("nombre").Value))
                cb_producto_salida.Items.Add(New myItem(rs.Fields("id_producto").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If

        rs.Close()
        ''conn.close()
        '--obtenemos las equivalencias.
        ''Conectar()
        tabla_conversiones.Clear()
        rs.Open("SELECT cantidad_origen,(SELECT CONCAT(producto.nombre,' UNIDAD:',unidad.nombre) As nombre FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE id_producto=id_producto_origen) as producto_origen,id_producto_origen,cantidad_destino,(SELECT CONCAT(producto.nombre,' UNIDAD:',unidad.nombre) As nombre FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE id_producto=id_producto_destino) as producto_destino,id_producto_destino from producto_equivalente ORDER BY id_producto_equivalente", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Linea = tabla_conversiones.NewRow()
                Linea(0) = rs.Fields("cantidad_origen").Value
                Linea(1) = rs.Fields("producto_origen").Value
                Linea(2) = rs.Fields("id_producto_origen").Value
                Linea(3) = "="
                Linea(4) = rs.Fields("cantidad_destino").Value
                Linea(5) = rs.Fields("producto_destino").Value
                Linea(6) = rs.Fields("id_producto_destino").Value
                tabla_conversiones.Rows.Add(Linea)
                rs.MoveNext()
            End While
        End If

        rs.Close()
        'conn.close()
        'conn = Nothing
        '-´--------------------
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        If Trim(tb_cantidad_origen.TextLength) = 0 Then
            cadena = cadena & "  Cantidad" & vbCrLf
            bandera_correcto = False
        End If
        If cb_producto_origen.SelectedIndex = -1 Then
            cadena = cadena & "  Producto origen" & vbCrLf
            bandera_correcto = False
        End If
        If Trim(tb_cantidad_destino.TextLength) = 0 Then
            cadena = cadena & "  Cantidad" & vbCrLf
            bandera_correcto = False
        End If
        If cb_producto_salida.SelectedIndex = -1 Then
            cadena = cadena & "  Producto salida" & vbCrLf
            bandera_correcto = False
        End If

        If bandera_correcto = True Then
            If btn_aceptar.Text = "Aceptar" Then
                Linea = tabla_conversiones.NewRow()
                Linea(0) = tb_cantidad_origen.Text
                Linea(1) = cb_producto_origen.Text
                Linea(2) = CType(cb_producto_origen.SelectedItem, myItem).Value
                Linea(3) = "="
                Linea(4) = tb_cantidad_destino.Text
                Linea(5) = cb_producto_salida.Text
                Linea(6) = CType(cb_producto_salida.SelectedItem, myItem).Value
                tabla_conversiones.Rows.Add(Linea)
            Else
                '  dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 1) = Tb_lada.Text
                ' dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 2) = tb_telefono.Text
            End If
            btn_aceptar.Text = "Aceptar"
            tb_cantidad_destino.Text = ""
            tb_cantidad_origen.Text = ""
            cb_producto_origen.SelectedIndex = -1
            cb_producto_salida.SelectedIndex = -1
            cb_producto_origen.Text = ""
            cb_producto_salida.Text = ""
            gb_detalle.Enabled = False
            gb_tabla.Enabled = True
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub btn_agregar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        gb_detalle.Enabled = True
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        btn_aceptar.Text = "Aceptar"
        tb_cantidad_destino.Text = ""
        tb_cantidad_origen.Text = ""
        cb_producto_origen.SelectedIndex = -1
        cb_producto_salida.SelectedIndex = -1
        cb_producto_origen.Text = ""
        cb_producto_salida.Text = ""
        gb_detalle.Enabled = False
        gb_tabla.Enabled = True
    End Sub

    Private Sub btn_guardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'Conectar()
        Dim corrimiento As Integer
        conn.Execute("TRUNCATE TABLE producto_equivalente")
        For corrimiento = 0 To tabla_conversiones.Rows.Count - 1
            conn.Execute("INSERT INTO producto_equivalente (cantidad_origen,id_producto_origen,cantidad_destino,id_producto_destino) VALUES ('" & dg_conversiones.Item(corrimiento, 0) & "', " & dg_conversiones.Item(corrimiento, 2) & "," & dg_conversiones.Item(corrimiento, 4) & ", " & dg_conversiones.Item(corrimiento, 6) & ")")
        Next
        'conn.close()
        'conn = Nothing
        MsgBox("Los cambios han sido guardados correctamente")
    End Sub

    Private Sub dg_conversiones_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_conversiones.MouseUp
        ' CON ESTA FUNCION SELECCIONAMOS TODA LA FILA-------------
        Dim pt As System.Drawing.Point
        pt = New Point(e.X, e.Y)
        Dim hti As DataGrid.HitTestInfo
        hti = dg_conversiones.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            dg_conversiones.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            dg_conversiones.Select(hti.Row)
        End If
        '-------------------
        '-MOSTRAMOS VALORES SELECCIONADOS-------------------
        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = tabla_conversiones.Rows.Count
            If dg_conversiones.IsSelected(NumRow) = True Then
                tb_cantidad_origen.Text = dg_conversiones.Item(dg_conversiones.CurrentCell.RowNumber, 0)
                cb_producto_origen.Text = dg_conversiones.Item(dg_conversiones.CurrentCell.RowNumber, 1)
                tb_cantidad_destino.Text = dg_conversiones.Item(dg_conversiones.CurrentCell.RowNumber, 4)
                cb_producto_salida.Text = dg_conversiones.Item(dg_conversiones.CurrentCell.RowNumber, 5)
            End If
            NumRow = NumRow + 1
        Loop
        '--------------------------------------------
    End Sub

    Private Sub dg_conversiones_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_conversiones.Navigate

    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        Dim contador As Integer
        contador = tabla_conversiones.Rows.Count
        While 0 < contador
            If dg_conversiones.IsSelected(contador - 1) = True Then
                tabla_conversiones.Rows.Item(contador - 1).Delete()
            End If
            contador = contador - 1
        End While
    End Sub
End Class