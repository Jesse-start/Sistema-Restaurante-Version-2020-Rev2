Public Class frm_inventario
    Dim select_servidor As String = ""
    Dim select_usuario As String = ""
    Dim select_password As String = ""
    Dim cargado As Boolean
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_inventario.ForeColor = Color.FromArgb(conf_colores(2))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub frm_inventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        aplicar_colores()
        estilo_inventario(dgv_inventario)
        obtener_sucursales()
        obtener_categorias()
        obtener_marcas()
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

    Private Sub limpiar_sucursales()
        For i = 0 To 15
            For j = 0 To 5
                sucursal(i, j) = Nothing
            Next
        Next
    End Sub
    Private Sub obtener_sucursales()
        ',matrix sucursal
        cb_almacen.Items.Clear()
        cb_almacen.Text = ""
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
        tabla_inventario.Clear()
        If id_sucursal = global_id_sucursal Then
            tb_error.Visible = False
            'Conectar()
            rs.Open("SELECT * FROM almacenes WHERE id_sucursal=" & id_sucursal & " Order By Nombre", conn)
            If rs.RecordCount > 0 Then
                cb_almacen.Items.Add(New myItem(0, "[Todos]"))
                While Not rs.EOF

                    cb_almacen.Items.Add(New myItem(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()

                End While
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
                tb_error.Visible = False
                rss.Open("SELECT * FROM almacenes Order By nombre", conn_sucursal)
                If rss.RecordCount > 0 Then
                    cb_almacen.Items.Add(New myItem(0, "[Todos]"))
                    While Not rss.EOF

                        cb_almacen.Items.Add(New myItem(rss.Fields("id_almacen").Value, rss.Fields("nombre").Value))
                        rss.MoveNext()

                    End While
                End If
                rss.Close()
                conn_sucursal.Close()
                conn_sucursal = Nothing
            Else
                tb_error.Text = "No se estableció la conexion con el servidor de " & cb_sucursal.Text
                tb_error.Visible = True
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
            cb_categoria.Enabled = True
            cb_marca.Enabled = True
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
        tabla_inventario.Clear()
        If id_sucursal = global_id_sucursal Then
            If id_almacen = 0 Then
                '---seleccionamos todos los productos de esta sucursal
                'Conectar()
                rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen " & _
                        "FROM producto_sucursal " & _
                        "JOIN producto On producto.id_producto=producto_sucursal.id_producto " & _
                        "JOIN unidad On unidad.id_unidad=producto.id_unidad " & _
                        "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                        "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " & _
                        "WHERE 1 " & filtro & " group by producto.id_producto ORDER BY cantidad DESC", conn)
                If rs.RecordCount > 0 Then
                    btn_imprimir.Enabled = True
                    While Not rs.EOF
                        agregar_inventario(rs.Fields("id_producto").Value, rs.Fields("cantidad").Value, rs.Fields("nombre").Value, rs.Fields("descripcion").Value, rs.Fields("unidad").Value, rs.Fields("codigo").Value, rs.Fields("cantidad_maxima").Value, rs.Fields("cantidad_minima").Value)
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
                rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen " & _
                        "FROM producto_sucursal " & _
                        "JOIN producto On producto.id_producto=producto_sucursal.id_producto " & _
                        "JOIN unidad On unidad.id_unidad=producto.id_unidad " & _
                        "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                        "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " & _
                        "WHERE producto_sucursal.id_almacen=" & id_almacen & " " & filtro & " group by producto.id_producto ORDER BY cantidad DESC", conn)
                If rs.RecordCount > 0 Then
                    btn_imprimir.Enabled = True
                    While Not rs.EOF
                        agregar_inventario(rs.Fields("id_producto").Value, rs.Fields("cantidad").Value, rs.Fields("nombre").Value, rs.Fields("descripcion").Value, rs.Fields("unidad").Value, rs.Fields("codigo").Value, rs.Fields("cantidad_maxima").Value, rs.Fields("cantidad_minima").Value)
                        rs.MoveNext()
                    End While
                Else
                    btn_imprimir.Enabled = False
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
                '---------------------------------------------------
            End If

        Else
            If id_almacen = 0 Then
                '--seleccionamos todos los productos de esta sucursal
                If Conectar_Sucursal(select_servidor, select_usuario, select_password, "pymes") Then
                    tb_error.Visible = False
                    rss.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen " & _
                             "FROM producto_sucursal JOIN producto On producto.id_producto=producto_sucursal.id_producto " & _
                             "JOIN unidad On unidad.id_unidad=producto.id_unidad  " & _
                              "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                              "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " & _
                             " WHERE 1 " & filtro & "group by producto.id_producto ORDER BY cantidad DESC", conn_sucursal)
                    If rss.RecordCount > 0 Then
                        btn_imprimir.Enabled = True
                        While Not rss.EOF
                            agregar_inventario(rss.Fields("id_producto").Value, rss.Fields("cantidad").Value, rss.Fields("nombre").Value, rss.Fields("descripcion").Value, rss.Fields("unidad").Value, rss.Fields("codigo").Value, rss.Fields("cantidad_maxima").Value, rss.Fields("cantidad_minima").Value)
                            rss.MoveNext()
                        End While
                    Else
                        btn_imprimir.Enabled = False
                    End If
                    rss.Close()
                    conn_sucursal.Close()
                    conn_sucursal = Nothing
                Else
                    tb_error.Text = "No se estableció la conexion con el servidor de " & cb_sucursal.Text
                    tb_error.Visible = True
                End If
                '-------------------
            Else
                '--seleccionamos todos los productos de este almacen
                If Conectar_Sucursal(select_servidor, select_usuario, select_password, "pymes") Then
                    tb_error.Visible = False
                    rss.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,unidad.nombre as unidad,sum(producto_sucursal.cantidad) as cantidad,producto_sucursal.cantidad_maxima,producto_sucursal.cantidad_minima,producto.codigo,producto_sucursal.id_almacen " & _
                             "FROM producto_sucursal JOIN producto On producto.id_producto=producto_sucursal.id_producto " & _
                             "JOIN unidad On unidad.id_unidad=producto.id_unidad " & _
                             "WHERE producto_sucursal.id_almacen=" & id_almacen & " " & filtro & "group by producto.id_producto ORDER BY cantidad DESC", conn_sucursal)
                    If rss.RecordCount > 0 Then
                        btn_imprimir.Enabled = True
                        While Not rss.EOF
                            agregar_inventario(rss.Fields("id_producto").Value, rss.Fields("cantidad").Value, rss.Fields("nombre").Value, rss.Fields("descripcion").Value, rss.Fields("unidad").Value, rss.Fields("codigo").Value, rss.Fields("cantidad_maxima").Value, rss.Fields("cantidad_minima").Value)
                            rss.MoveNext()
                        End While
                    Else
                        btn_imprimir.Enabled = False
                    End If
                    rss.Close()
                    conn_sucursal.Close()
                    conn_sucursal = Nothing
                Else
                    tb_error.Text = "No se estableció la conexion con el servidor de " & cb_sucursal.Text
                    tb_error.Visible = True
                End If
                '-------------------
            End If

        End If


    End Sub
    Private Sub dgv_inventario_surtir_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_inventario.CellFormatting

        If dgv_inventario.Columns(e.ColumnIndex).Index = 1 Then
            Dim cant_min As Decimal = dgv_inventario.Rows(e.RowIndex).Cells("cant_min").Value
            e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
            If e.Value <= cant_min Then
                e.CellStyle.Font = New Font("Century Gothic", 14, FontStyle.Bold)
                e.CellStyle.BackColor = Color.DarkRed
                e.CellStyle.ForeColor = Color.White
            End If
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Public Sub imprimir_ticket_inventario(ByVal imprimir_codigos As Boolean)
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

        If imprimir_codigos = True Then
            S.AnadirLineaSubcabeza(" CODIGO  UNIDAD  EXISTENCIAS")
        Else
            S.AnadirLineaSubcabeza(" NOMBRE          UNIDAD  EXISTENCIAS")
        End If
        ' S.AnadirLineaSubcabeza(" CODIGO  UNIDAD  EXISTENCIAS")
        S.AnadirLineaSubcabeza("")


        For x = 0 To tabla_inventario.Rows.Count - 1
            If imprimir_codigos = True Then
                S.AnadirLineaSubcabeza("" & centrar_texto(FormatNumber(dgv_inventario.Rows(x).Cells("codigo").Value, "000"), 8, " ") & "    " & rellenar_texto_derecha(dgv_inventario.Rows(x).Cells("unidad").Value, 6) & "  " & rellenar_texto_izquierda(dgv_inventario.Rows(x).Cells("cantidad").Value, 11) & "")
            Else
                S.AnadirLineaSubcabeza("" & rellenar_texto_derecha(dgv_inventario.Rows(x).Cells("nombre").Value, 25) & " " & rellenar_texto_derecha(dgv_inventario.Rows(x).Cells("unidad").Value, 6) & " " & rellenar_texto_izquierda(dgv_inventario.Rows(x).Cells("cantidad").Value, 7) & "")
            End If


            S.AnadirLineaSubcabeza("_____________________________________")
        Next
        

        NombreDeLaFuente = "Helvetica"
        TamanoDeLaFuente = 6.5
        CaracteresMaximos = 47
        S.ImprimeTicket(conf_impresoras(0))
        NombreDeLaFuente = "Lucida Console" 'Lucida Console original
        TamanoDeLaFuente = 7
        CaracteresMaximos = 39
    End Sub

    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        imprimir_ticket_inventario(chb_imprimir_codigos.CheckState)
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

    Private Sub tb_buscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_buscar.TextChanged
        If cargado = True Then
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
        End If
    End Sub
End Class