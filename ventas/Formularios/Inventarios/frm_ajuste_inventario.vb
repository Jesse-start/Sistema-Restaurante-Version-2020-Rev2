Public Class frm_ajuste_inventario
    Dim id_inventario As Integer = 0
    Dim select_servidor As String = ""
    Dim select_usuario As String = ""
    Dim select_password As String = ""
    Dim cargado As Boolean
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_log.ForeColor = Color.FromArgb(conf_colores(2))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        btn_aplicar_merma.BackColor = Color.FromArgb(conf_colores(8))
        btn_aplicar_merma.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_inventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        aplicar_colores()
        estilo_ajuste_inventario(dgv_inventario)
        obtener_sucursales()
        obtener_categorias()
        obtener_marcas()
        seleccionar_sucursal(global_id_sucursal)
        cargado = True
    End Sub
    Private Sub obtener_categorias()
        cb_categoria.Text = ""
        cb_categoria.SelectedIndex = -1
        'Conectar()
        rs.Open("SELECT id_categoria,nombre FROM categoria Order By id_categoria", conn)
        If rs.RecordCount > 0 Then
            cb_categoria.Items.Add(New myItem(0, "[Todas]"))
            While Not rs.EOF
                cb_categoria.Items.Add(New myItem(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_marcas()
        cb_marca.Text = ""
        cb_marca.SelectedIndex = -1
        'Conectar()
        rs.Open("SELECT id_marca,nombre FROM producto_marca Order By id_marca", conn)
        If rs.RecordCount > 0 Then
            cb_marca.Items.Add(New myItem(0, "[Todas]"))
            While Not rs.EOF
                cb_marca.Items.Add(New myItem(rs.Fields("id_marca").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Public Sub cantidad_real(ByVal cantidad As Decimal)
        dgv_inventario.Rows(dgv_inventario.CurrentRow.Index).Cells("cantidad_fisica").Value = cantidad
        dgv_inventario.Rows(dgv_inventario.CurrentRow.Index).Cells("diferencia").Value = cantidad - dgv_inventario.Rows(dgv_inventario.CurrentRow.Index).Cells("cantidad").Value
    End Sub
    Private Sub cantidad_real2(ByVal id As Decimal)

        Dim foundRows() As Data.DataRow = tabla_ajuste_inventario.Select("id_producto = " & id)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then
            foundRows(0).Item("diferencia") = CDec(foundRows(0).Item("cantidad_fisica")) - CDec(foundRows(0).Item("cantidad"))
        End If


    End Sub
    Private Sub limpiar_sucursales()
        For i = 0 To 15
            For j = 0 To 5
                sucursal(i, j) = Nothing
            Next
        Next
    End Sub
    Private Sub seleccionar_sucursal(ByVal id_sucursal As Integer)
        For x = 0 To cb_sucursal.Items.Count - 1
            If id_sucursal = CType(cb_sucursal.Items(x), myItem).Value Then
                cb_sucursal.SelectedIndex = x
                tb_log.Text = "Seleccione un almacen"
                Exit For
            End If
        Next
    End Sub
    Private Sub obtener_sucursales()
        ',matrix sucursal
        '----/     0     / 1   /    2   /         3      /       4         /   5     /
        '---/id_sucursal/alias/servidor/servidor_usuario/servidor_password/domicilio/
        cb_sucursal.Items.Clear()
        cb_sucursal.Text = ""
        limpiar_sucursales()
        'Conectar()
        Dim i As Integer = 0
        rs.Open("SELECT sucursal.*,concat(domicilio.calle,if(domicilio.cp='','',concat(' C.P. ',domicilio.cp)),' ',domicilio.colonia,' ',domicilio.municipio ) As domicilio FROM sucursal JOIN domicilio On domicilio.id_domicilio=sucursal.id_domicilio Order By alias", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                sucursal(i, 0) = rs.Fields("id_sucursal").Value
                sucursal(i, 1) = rs.Fields("alias").Value
                sucursal(i, 2) = rs.Fields("servidor").Value
                sucursal(i, 3) = rs.Fields("servidor_usuario").Value
                sucursal(i, 4) = rs.Fields("servidor_password").Value
                sucursal(i, 5) = rs.Fields("id_sucursal").Value
                cb_sucursal.Items.Add(New myItem(rs.Fields("id_sucursal").Value, rs.Fields("alias").Value))
                i = i + 1
                rs.MoveNext()

            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_almacenes(ByVal id_sucursal As Integer)
        cb_almacen.Items.Clear()
        cb_almacen.Text = ""
        tabla_ajuste_inventario.Clear()
        If id_sucursal = global_id_sucursal Then
            'tb_log.Visible = False
            'Conectar()
            rs.Open("SELECT * FROM almacenes WHERE id_sucursal=" & id_sucursal & " Order By nombre", conn)
            If rs.RecordCount > 0 Then
                cb_almacen.Items.Add(New myItem(0, "[Todos]"))
                While Not rs.EOF

                    cb_almacen.Items.Add(New myItem(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()

                End While
                tb_log.Text = "Seleccione un almacen"
            Else
                tb_log.Text = "No se encontraron almacenes"
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
        Else
            select_servidor = ""
            select_usuario = ""
            select_password = ""

            For x = 0 To 15
                If sucursal(x, 0) = id_sucursal Then
                    select_servidor = sucursal(x, 2)
                    select_usuario = sucursal(x, 3)
                    select_password = sucursal(x, 4)
                    Exit For
                End If
            Next
            If Conectar_Sucursal(select_servidor, select_usuario, select_password, "pymes") Then
                'tb_log.Visible = False
                rss.Open("SELECT * FROM almacenes Order By Nombre", conn_sucursal)
                If rss.RecordCount > 0 Then
                    cb_almacen.Items.Add(New myItem(0, "[Todos]"))
                    While Not rss.EOF

                        cb_almacen.Items.Add(New myItem(rss.Fields("id_almacen").Value, rss.Fields("nombre").Value))
                        rss.MoveNext()

                    End While
                    tb_log.Text = "Seleccione un almacen"
                Else
                    tb_log.Text = "No se encontraron almacenes"
                End If
                rss.Close()
                conn_sucursal.Close()
                conn_sucursal = Nothing
            Else
                tb_log.Text = "No se estableció la conexion con el servidor de " & cb_sucursal.Text
                tb_log.Visible = True
            End If

        End If

    End Sub

    Private Sub cb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_sucursal.SelectedIndexChanged
        If cb_sucursal.SelectedIndex <> -1 Then
            obtener_almacenes(CType(cb_sucursal.SelectedItem, myItem).Value)
        End If
    End Sub

    Private Sub cb_almacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_almacen.SelectedIndexChanged
        Dim id_categoria As Integer = 0
        Dim id_marca As Integer = 0
        If cb_categoria.SelectedIndex <> -1 Then
            id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
        End If
        If cb_marca.SelectedIndex <> -1 Then
            id_marca = CType(cb_marca.SelectedItem, myItem).Value
        End If
        If cb_almacen.SelectedIndex <> -1 Then
            obtener_inventario(CType(cb_sucursal.SelectedItem, myItem).Value, CType(cb_almacen.SelectedItem, myItem).Value, id_categoria, id_marca, tb_buscar.Text)
        End If

    End Sub
    Public Sub obtener_inventario(ByVal id_sucursal As Integer, ByVal id_almacen As Integer, ByVal id_categoria As Integer, ByVal id_marca As Integer, ByVal busqueda As String)
        Dim filtro As String = ""

        If id_categoria > 0 Then
            filtro = filtro & " AND categoria.id_categoria='" & id_categoria & "' "
        End If
        If id_marca > 0 Then
            filtro = filtro & "AND producto_marca.id_marca='" & id_marca & "' "
        End If
        If busqueda <> "" Then
            filtro = filtro & " AND producto.nombre LIKE '%" & busqueda & "%' OR producto.descripcion LIKE '%" & busqueda & "%' "
        End If
        tb_log.Text = ""
        btn_aplicar_merma.Enabled = False
        tabla_ajuste_inventario.Clear()
        If id_sucursal = global_id_sucursal Then
            If id_almacen = 0 Then
                '---seleccionamos todos los productos de esta sucursal
                'Conectar()
                rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen,producto_sucursal.merma " &
                        "FROM producto_sucursal " &
                        "JOIN producto On producto.id_producto=producto_sucursal.id_producto " &
                        "JOIN unidad On unidad.id_unidad=producto.id_unidad " &
                        "JOIN categoria ON categoria.id_categoria=producto.id_categoria " &
                        "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " &
                        "WHERE 1 " & filtro & "  group by producto.id_producto ORDER BY cantidad DESC", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        agregar_ajuste_inventario(rs.Fields("id_producto").Value, rs.Fields("cantidad").Value, rs.Fields("nombre").Value, rs.Fields("descripcion").Value, rs.Fields("unidad").Value, rs.Fields("codigo").Value, rs.Fields("cantidad_maxima").Value, rs.Fields("cantidad_minima").Value, rs.Fields("merma").Value, conn)
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '---------------------------------------------------

            Else
                '---seleccionamos todos los productos de este almacen
                'Conectar()
                rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen,producto_sucursal.merma " &
                        "FROM producto_sucursal " &
                        "JOIN producto On producto.id_producto=producto_sucursal.id_producto " &
                        "JOIN unidad On unidad.id_unidad=producto.id_unidad " &
                        "JOIN categoria ON categoria.id_categoria=producto.id_categoria " &
                        "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " &
                        "WHERE producto_sucursal.id_almacen=" & id_almacen & " " & filtro & "  group by producto.id_producto ORDER BY cantidad DESC", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        agregar_ajuste_inventario(rs.Fields("id_producto").Value, rs.Fields("cantidad").Value, rs.Fields("nombre").Value, rs.Fields("descripcion").Value, rs.Fields("unidad").Value, rs.Fields("codigo").Value, rs.Fields("cantidad_maxima").Value, rs.Fields("cantidad_minima").Value, rs.Fields("merma").Value, conn)
                        rs.MoveNext()
                    End While
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '---------------------------------------------------
                If tabla_ajuste_inventario.Rows.Count > 0 Then
                    btn_aplicar_merma.Enabled = True
                End If
            End If

        Else
            If id_almacen = 0 Then
                '--seleccionamos todos los productos de esta sucursal
                If Conectar_Sucursal(select_servidor, select_usuario, select_password, "pymes") Then
                    'tb_log.Visible = False
                    rss.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen,producto_sucursal.merma FROM producto_sucursal JOIN producto On producto.id_producto=producto_sucursal.id_producto JOIN unidad On unidad.id_unidad=producto.id_unidad WHERE 1 " & filtro & "  group by producto.id_producto ORDER BY cantidad DESC", conn_sucursal)
                    If rss.RecordCount > 0 Then
                        While Not rss.EOF
                            agregar_ajuste_inventario(rss.Fields("id_producto").Value, rss.Fields("cantidad").Value, rss.Fields("nombre").Value, rss.Fields("descripcion").Value, rss.Fields("unidad").Value, rss.Fields("codigo").Value, rss.Fields("cantidad_maxima").Value, rss.Fields("cantidad_minima").Value, rss.Fields("merma").Value, conn_sucursal)
                            rss.MoveNext()
                        End While
                    End If
                    rss.Close()
                    conn_sucursal.Close()
                    conn_sucursal = Nothing
                Else
                    tb_log.Text = "No se estableció la conexion con el servidor de " & cb_sucursal.Text
                    'tb_log.Visible = True
                End If
                '-------------------
            Else
                '--seleccionamos todos los productos de este almacen
                If Conectar_Sucursal(select_servidor, select_usuario, select_password, "pymes") Then
                    'tb_log.Visible = False
                    rss.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen,producto_sucursal.merma FROM producto_sucursal JOIN producto On producto.id_producto=producto_sucursal.id_producto JOIN unidad On unidad.id_unidad=producto.id_unidad WHERE producto_sucursal.id_almacen=" & id_almacen & " " & filtro & " group by producto.id_producto ORDER BY cantidad DESC", conn_sucursal)
                    If rss.RecordCount > 0 Then
                        While Not rss.EOF
                            agregar_ajuste_inventario(rss.Fields("id_producto").Value, rss.Fields("cantidad").Value, rss.Fields("nombre").Value, rss.Fields("descripcion").Value, rss.Fields("unidad").Value, rss.Fields("codigo").Value, rss.Fields("cantidad_maxima").Value, rss.Fields("cantidad_minima").Value, rss.Fields("merma").Value, conn_sucursal)
                            rss.MoveNext()
                        End While
                    End If
                    rss.Close()
                    conn_sucursal.Close()
                    conn_sucursal = Nothing
                    If tabla_ajuste_inventario.Rows.Count > 0 Then
                        btn_aplicar_merma.Enabled = True
                    End If
                Else
                    tb_log.Text = "No se estableció la conexion con el servidor de " & cb_sucursal.Text
                    ' tb_log.Visible = True
                End If
                '-------------------
            End If

        End If
    End Sub
    Private Sub dgv_inventario_surtir_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_inventario.CellFormatting
        Try
            If dgv_inventario.Columns(e.ColumnIndex).Index = 7 Then
                Dim cant_min As Decimal = dgv_inventario.Rows(e.RowIndex).Cells("cant_min").Value
                e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
                If e.Value <= cant_min Then
                    e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
                    e.CellStyle.BackColor = Color.DarkRed
                    e.CellStyle.ForeColor = Color.White
                End If
            End If
            If dgv_inventario.Columns(e.ColumnIndex).Index = 0 Then
                e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
            End If
            If dgv_inventario.Columns(e.ColumnIndex).Index = 8 Then
                e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
            End If
            If dgv_inventario.Columns(e.ColumnIndex).Index = 9 Then
                e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
                If e.Value < 0 Then
                    e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
                    e.CellStyle.BackColor = Color.DarkRed
                    e.CellStyle.ForeColor = Color.White
                ElseIf e.Value > 0 Then
                    e.CellStyle.BackColor = Color.DarkGreen
                    e.CellStyle.ForeColor = Color.White
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgv_inventario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_inventario.Click

        If dgv_inventario.Rows.Count > 0 Then
            If dgv_inventario.CurrentCell.ColumnIndex = 8 Then
                If CType(cb_almacen.SelectedItem, myItem).Value > 0 Then
                    btn_aplicar_merma.Enabled = True
                    If chb_teclado.CheckState = 1 Then
                        frm_teclado_numerico.modo = 0
                        frm_teclado_numerico.ShowDialog()
                    Else
                        dgv_inventario.Columns("cantidad_fisica").ReadOnly = False
                    End If
                Else
                    MsgBox("Seleccione un almacen para realizar el ajuste de inventario")
                    btn_aplicar_merma.Enabled = False
                    If chb_teclado.CheckState = 0 Then
                        dgv_inventario.Columns("cantidad_fisica").ReadOnly = True
                    End If

                End If

            End If
        End If
    End Sub

    Private Sub btn_aplicar_merma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_merma.Click
        If tabla_ajuste_inventario.Rows.Count > 0 Then
            For x = 0 To tabla_ajuste_inventario.Rows.Count - 1
                If dgv_inventario.Rows(x).Cells("merma_aplicada").Value = 0 Then
                    If dgv_inventario.Rows(x).Cells("merma").Value > 0 Then
                        Dim cantidad_fisica As Decimal = dgv_inventario.Rows(x).Cells("cantidad_fisica").Value
                        Dim merma As Decimal = dgv_inventario.Rows(x).Cells("merma").Value
                        dgv_inventario.Rows(x).Cells("cantidad_fisica").Value = FormatNumber(cantidad_fisica - (cantidad_fisica * merma), 2)
                        dgv_inventario.Rows(x).Cells("merma_aplicada").Value = 1
                        tb_log.Text = "La merma se ha calculado y aplicado correctamente. Haga click en guardar para actualizar los registros "
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub dgv_inventario_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_inventario.CellValueChanged
        If chb_teclado.CheckState = 0 Then
            If dgv_inventario.Rows.Count > 0 Then
                If CType(cb_almacen.SelectedItem, myItem).Value > 0 Then
                    cantidad_real2(dgv_inventario.Rows(dgv_inventario.CurrentRow.Index).Cells("id_producto").Value)
                End If
            End If
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim id_categoria As Integer = 0
        Dim id_marca As Integer = 0
        If cb_categoria.SelectedIndex <> -1 Then
            id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
        End If
        If cb_marca.SelectedIndex <> -1 Then
            id_marca = CType(cb_marca.SelectedItem, myItem).Value
        End If
        If cb_almacen.SelectedIndex <> -1 Then
            obtener_inventario(CType(cb_sucursal.SelectedItem, myItem).Value, CType(cb_almacen.SelectedItem, myItem).Value, id_categoria, id_marca, tb_buscar.Text)
        End If
    End Sub

    Private Sub dgv_inventario_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_inventario.CellContentClick

    End Sub

    Private Sub cb_categoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_categoria.SelectedIndexChanged
        Dim id_categoria As Integer = 0
        Dim id_marca As Integer = 0
        If cargado = True Then
            If cb_categoria.SelectedIndex <> -1 Then
                id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
            End If
            If cb_marca.SelectedIndex <> -1 Then
                id_marca = CType(cb_marca.SelectedItem, myItem).Value
            End If
            If cb_almacen.SelectedIndex <> -1 Then
                obtener_inventario(CType(cb_sucursal.SelectedItem, myItem).Value, CType(cb_almacen.SelectedItem, myItem).Value, id_categoria, id_marca, tb_buscar.Text)
            End If
        End If
    End Sub

    Private Sub cb_marca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_marca.SelectedIndexChanged
        Dim id_categoria As Integer = 0
        Dim id_marca As Integer = 0
        If cargado = True Then
            If cb_categoria.SelectedIndex <> -1 Then
                id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
            End If
            If cb_marca.SelectedIndex <> -1 Then
                id_marca = CType(cb_marca.SelectedItem, myItem).Value
            End If
            If cb_almacen.SelectedIndex <> -1 Then
                obtener_inventario(CType(cb_sucursal.SelectedItem, myItem).Value, CType(cb_almacen.SelectedItem, myItem).Value, id_categoria, id_marca, tb_buscar.Text)
            End If
        End If
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        imprimir_ticket_inventario(chb_habilitar_espaciado.Checked, tb_num_espacio.Value)
    End Sub
    Public Sub imprimir_ticket_inventario(ByVal habilitar_espaciado As Boolean, ByVal num_espacio As Integer)
        Dim S As ticket = New ticket

        S.HeaderImage = global_logotipo
        S.AnadirLineaCabeza("")
        For x = 0 To 25
            If Not IsNothing(lineas_ticket_cabeza(x)) Then
                S.AnadirLineaCabeza(centrar_texto(lineas_ticket_cabeza(x), 47, " "))
            Else
                Exit For
            End If
        Next

        S.AnadirLineaCLiente("" & centrar_texto("INVENTARIO", 27, " ") & "")
        S.AnadirLineaCLiente("")
        S.AnadirLineaCLiente("" & centrar_texto(cb_sucursal.Text, 27, " ") & "")
        S.AnadirLineaCLiente("")
        S.AnadirLineaCLiente("" & centrar_texto(cb_almacen.Text, 27, " ") & "")

        S.AnadirLineaSubcabeza("")

        S.AnadirLineaSubcabeza("" & DateTime.Now.ToLongDateString())
        S.AnadirLineaSubcabeza("Hora: " & DateTime.Now.ToShortTimeString())
        S.AnadirLineaSubcabeza("")


        S.AnadirLineaSubcabeza("Existencias    Unidad  Nombre")
        ' S.AnadirLineaSubcabeza(" CODIGO  UNIDAD  EXISTENCIAS")
        S.AnadirLineaSubcabeza("")


        For x = 0 To tabla_ajuste_inventario.Rows.Count - 1
            S.AnadirLineaSubcabeza("__________" & rellenar_texto_derecha(dgv_inventario.Rows(x).Cells("unidad").Value, 6) & " " & rellenar_texto_derecha(dgv_inventario.Rows(x).Cells("nombre").Value, 25))
            If habilitar_espaciado = True Then
                For i = 1 To num_espacio
                    S.AnadirLineaSubcabeza(" ")
                Next

            End If
            'S.AnadirLineaSubcabeza("_____________________________________")
        Next


        NombreDeLaFuente = "Helvetica"
        TamanoDeLaFuente = 6.5
        CaracteresMaximos = 55
        S.ImprimeTicket(conf_impresoras(0))
        NombreDeLaFuente = "Lucida Console" 'Lucida Console original
        TamanoDeLaFuente = 7
        CaracteresMaximos = 39
    End Sub

    Private Sub tb_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_buscar.TextChanged
        If tb_buscar.TextLength = 0 Then
            btn_buscar_Click(sender, e)
        Else
            If tb_buscar.TextLength > 2 Then
                btn_buscar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_guardar_Click_1(sender As Object, e As EventArgs) Handles btn_guardar.Click
        If tabla_ajuste_inventario.Rows.Count > 0 Then
            'Conectar()
            For x = 0 To tabla_ajuste_inventario.Rows.Count - 1
                Dim merma_aplicada As Integer = dgv_inventario.Rows(x).Cells("merma_aplicada").Value
                Dim flag_merma As Integer = dgv_inventario.Rows(x).Cells("flag_merma").Value
                Dim diferencia As Decimal = dgv_inventario.Rows(x).Cells("diferencia").Value
                Dim id_producto As Integer = dgv_inventario.Rows(x).Cells("id_producto").Value
                If diferencia <> 0 Then
                    If merma_aplicada = 1 Then
                        If flag_merma = 0 Then
                            conn.Execute("INSERT INTO ajuste_inventario(id_producto,nombre,fecha,id_empleado,diferencia,merma) VALUES('" & id_producto & "','" & dgv_inventario.Rows(x).Cells("nombre").Value & "',NOW(),'" & global_id_empleado & "','" & diferencia & "',1)")
                            dgv_inventario.Rows(x).Cells("flag_merma").Value = 1
                            conn.Execute("UPDATE producto_sucursal  SET cantidad='" & CDbl(dgv_inventario.Rows(x).Cells("cantidad_fisica").Value) & "' WHERE id_almacen='" & CType(cb_almacen.SelectedItem, myItem).Value & "' AND id_producto=" & id_producto)
                        Else
                            GoTo c
                        End If
                    Else
c:                      conn.Execute("INSERT INTO ajuste_inventario(id_producto,nombre,fecha,id_empleado,diferencia,merma) VALUES('" & id_producto & "','" & dgv_inventario.Rows(x).Cells("nombre").Value & "',NOW(),'" & global_id_empleado & "','" & diferencia & "',0)")
                        conn.Execute("UPDATE producto_sucursal  SET cantidad='" & CDbl(dgv_inventario.Rows(x).Cells("cantidad_fisica").Value) & "' WHERE id_almacen='" & CType(cb_almacen.SelectedItem, myItem).Value & "' AND id_producto=" & id_producto)
                    End If
                Else
                    If merma_aplicada = 1 Then
                        If flag_merma = 0 Then
                            conn.Execute("INSERT INTO ajuste_inventario(id_producto,nombre,fecha,id_empleado,diferencia,merma) VALUES('" & id_producto & "','" & dgv_inventario.Rows(x).Cells("nombre").Value & "',NOW(),'" & global_id_empleado & "','" & diferencia & "',1)")
                            dgv_inventario.Rows(x).Cells("flag_merma").Value = 1
                            conn.Execute("UPDATE producto_sucursal  SET cantidad='" & CDbl(dgv_inventario.Rows(x).Cells("cantidad_fisica").Value) & "' WHERE id_almacen='" & CType(cb_almacen.SelectedItem, myItem).Value & "' AND id_producto=" & id_producto)
                        End If
                    End If
                End If
            Next
            'conn.close()
            'conn = Nothing
            tb_log.Text = "Todos los cambios se han guardado correctamente"
            MsgBox("inventario actualizado correctamente", MsgBoxStyle.Information, "Correcto")
        End If
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        cargar_inventario(0)
    End Sub
    Public Sub cargar_inventario(Optional ByVal id As Integer = 0)

        id_inventario = id

        If id_inventario > 0 Then

            rs.Open("SELECT fecha_hora,id_almacen,id_empleado,inventario_teorico,inventario_fisico,diferencia " &
                    "FROM inventario_fisico " &
                    "WHERE id_inventario_fisico = " & id_inventario, conn)
            seleccionar_catalogo(rs.Fields("id_almacen").Value, cb_almacen)

            'seleccionamos la información del inventario
        Else
            '==========PREPARAMOS PARA NUEVO INVENTARIO===================

            btn_cancelar.Visible = False

        End If


    End Sub
End Class