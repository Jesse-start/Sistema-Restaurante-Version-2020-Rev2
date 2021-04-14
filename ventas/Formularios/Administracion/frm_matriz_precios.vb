Imports System.Math
Public Class frm_matriz_precios
    Dim rx As New ADODB.Recordset
    Dim id_producto_precio(25) As Integer
    Dim precio(25) As Decimal
    Dim cargado As Boolean = False

    Dim reg_por_pag As Integer = 20
    Dim inicial As Integer = 0
    Dim total_productos As Integer = 0
    Dim total_paginas As Integer = 0

    Private Sub limpiar_variables()
        For x = 0 To 25
            id_producto_precio(x) = 0
            precio(x) = 0
        Next
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Panel1.BackColor = Color.FromArgb(conf_colores(1))
        btn_buscar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_guardar.BackColor = Color.FromArgb(conf_colores(8))
        btn_guardar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub frm_matriz_precios_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_matriz_precios = 1
    End Sub
    Private Sub frm_matriz_precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        aplicar_colores()
        'Me.MdiParent = frm_principal
        global_frm_matriz_precios = 1
        estilo_matriz_precios(dgv_matriz_precios)
        obtener_categorias()
        obtener_marcas()
        cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value)
        cargado = True
    End Sub
    Private Sub obtener_categorias()
        cb_categoria.Text = ""
        cb_categoria.SelectedIndex = -1

        rs.Open("SELECT id_categoria,nombre FROM categoria Order By id_categoria", conn)
        If rs.RecordCount > 0 Then
            cb_categoria.Items.Add(New myItem(0, "[Todas]"))
            While Not rs.EOF
                cb_categoria.Items.Add(New myItem(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()

        If cb_categoria.Items.Count > 0 Then
            cb_categoria.SelectedIndex = 0
        End If

    End Sub
    Private Sub obtener_marcas()
        cb_marca.Text = ""
        cb_marca.SelectedIndex = -1

        rs.Open("SELECT id_marca,nombre FROM producto_marca Order By id_marca", conn)
        If rs.RecordCount > 0 Then
            cb_marca.Items.Add(New myItem(0, "[Todas]"))
            While Not rs.EOF
                cb_marca.Items.Add(New myItem(rs.Fields("id_marca").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()

        If cb_marca.Items.Count > 0 Then
            cb_marca.SelectedIndex = 0
        End If

    End Sub

    Private Sub cargar_precios(ByVal busqueda As String, ByVal id_categoria As Integer, ByVal id_marca As Integer, Optional pagina As Integer = 1)

        tb_pagina.Text = pagina
        inicial = (pagina - 1) * reg_por_pag


        tabla_matriz_precios.Clear()
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


        rs.Open("SELECT count(*) as total_productos " & _
                "FROM producto " & _
                "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " & _
                "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                "WHERE 1 " & filtro, conn)
        total_productos = rs.Fields("total_productos").Value
        rs.Close()

        total_paginas = Ceiling(total_productos / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas


        rs.Open("SELECT producto.id_producto,producto.codigo,producto.nombre,producto.precio As precio_pg,producto.costo " & _
                "FROM producto " & _
                "JOIN producto_marca ON producto_marca.id_marca=producto.id_marca " & _
                "JOIN categoria ON categoria.id_categoria=producto.id_categoria " & _
                "WHERE 1 " & filtro & "LIMIT " & inicial & "," & reg_por_pag, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cargar_precios_productos(rs.Fields("id_producto").Value, rs.Fields("precio_pg").Value, rs.Fields("costo").Value)
                Dim utilidad_precio_publico As Decimal = FormatNumber((((rs.Fields("precio_pg").Value / rs.Fields("costo").Value) - 1) * 100), 2)
                agregar_matriz_precios(False, rs.Fields("id_producto").Value, rs.Fields("codigo").Value, rs.Fields("nombre").Value, rs.Fields("costo").Value, utilidad_precio_publico, rs.Fields("precio_pg").Value, id_producto_precio(1), precio(1), id_producto_precio(2), precio(2), id_producto_precio(3), precio(3), id_producto_precio(4), precio(4), id_producto_precio(5), precio(5), id_producto_precio(6), precio(6), id_producto_precio(7), precio(7), id_producto_precio(8), precio(8), id_producto_precio(9), precio(9), id_producto_precio(10), precio(10), id_producto_precio(11), precio(11), id_producto_precio(12), precio(12), id_producto_precio(13), precio(13), id_producto_precio(14), precio(14), id_producto_precio(15), precio(15), id_producto_precio(16), precio(16), id_producto_precio(17), precio(17), id_producto_precio(18), precio(18), id_producto_precio(19), precio(19), id_producto_precio(20), precio(20), id_producto_precio(21), precio(21), id_producto_precio(22), precio(22), id_producto_precio(23), precio(23), id_producto_precio(24), precio(24), id_producto_precio(25), precio(25))
                rs.MoveNext()
            End While
        End If
        tb_resultados.Text = total_productos & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()
    End Sub
    Private Sub cargar_precios_productos(ByVal id_producto As Integer, ByVal precio_producto As Decimal, ByVal producto_costo As Decimal)
        'id_catalogo_precio(15)
        'precio(15)
        limpiar_variables()
        rx.Open("SELECT id_producto_precio,precio FROM producto_precio WHERE id_producto='" & id_producto & "' ORDER BY id_ctlg_precios DESC", conn)
        If rx.RecordCount > 0 Then
            Dim i As Integer = 1
            While Not rx.EOF
                id_producto_precio(i) = rx.Fields("id_producto_precio").Value
                'precio= producto_precio.precio-(producto.costo*(producto_volumen.descuento/100))) AS precio
                precio(i) = rx.Fields("precio").Value
                i += 1
                rx.MoveNext()
            End While
        End If
        rx.Close()

    End Sub
    Private Sub dgv_matriz_precios_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_matriz_precios.CellFormatting
        For x = 0 To dgv_matriz_precios.Columns.Count - 1
            If dgv_matriz_precios.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
                Dim publico As Decimal = dgv_matriz_precios.Rows(e.RowIndex).Cells("precio_pg").Value

                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 4 Then
                    If e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.Yellow
                        e.CellStyle.ForeColor = Color.Black
                    ElseIf e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.Green
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.Red
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If


                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 8 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 10 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 12 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 14 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 16 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 18 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 20 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 22 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 24 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 26 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 28 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 30 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 32 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 34 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 36 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 38 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 40 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 42 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 44 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 46 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 48 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 51 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 53 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 54 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 56 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If
                If dgv_matriz_precios.Columns(e.ColumnIndex).Index = 58 Then
                    If e.Value < publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkSlateBlue
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value = publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkGreen
                        e.CellStyle.ForeColor = Color.White
                    ElseIf e.Value > publico Then
                        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                        e.CellStyle.BackColor = Color.DarkRed
                        e.CellStyle.ForeColor = Color.White
                    End If
                End If

            End If
        Next
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'obtenemos el total de precios
        Dim total_precio As Integer = 0
        rs.Open("SELECT COUNT(id_ctlg_precios)AS total FROM ctlg_precios", conn)
        If rs.RecordCount > 0 Then
            total_precio = rs.Fields("total").Value
        End If
        rs.Close()
        For x = 0 To tabla_matriz_precios.Rows.Count - 1
            conn.Execute("UPDATE producto SET costo='" & dgv_matriz_precios.Rows(x).Cells("costo").Value & "',nombre='" & dgv_matriz_precios.Rows(x).Cells("descripcion").Value & "',precio='" & dgv_matriz_precios.Rows(x).Cells("precio_pg").Value & "' WHERE id_producto='" & dgv_matriz_precios.Rows(x).Cells("id_producto").Value & "'")
            For y = 1 To total_precio
                Dim utilidad As Decimal = FormatNumber(((dgv_matriz_precios.Rows(x).Cells("precio" & y).Value / dgv_matriz_precios.Rows(x).Cells("costo").Value) - 1) * 100, 2)
                conn.Execute("UPDATE producto_precio SET utilidad='" & utilidad & "',precio='" & dgv_matriz_precios.Rows(x).Cells("precio" & y).Value & "' WHERE id_producto_precio='" & dgv_matriz_precios.Rows(x).Cells("id_ctlg_precio" & y).Value & "'")
            Next
        Next
        cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value)
        MsgBox("Precios modificados correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub cb_categoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_categoria.SelectedIndexChanged
        If cb_categoria.SelectedIndex <> -1 Then
            If cargado = True Then
                cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value)
            End If
        End If
    End Sub

    Private Sub cb_marca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_marca.SelectedIndexChanged
        If cb_marca.SelectedIndex <> -1 Then
            If cargado = True Then
                cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value)
            End If
        End If
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value)
    End Sub

    Private Sub dgv_matriz_precios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_matriz_precios.CellContentClick

    End Sub

    Private Sub dgv_matriz_precios_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_matriz_precios.CellValueChanged
        If dgv_matriz_precios.Rows.Count > 0 Then
            actualizar_valores(dgv_matriz_precios.Rows(dgv_matriz_precios.CurrentRow.Index).Cells("id_producto").Value)
        End If
    End Sub
    Private Sub actualizar_valores(ByVal id_producto As Integer)
        Dim foundRows() As Data.DataRow = tabla_matriz_precios.Select("id_producto = " & id_producto)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then
            foundRows(0).Item("utilidad") = FormatNumber(((foundRows(0).Item("precio_pg") / foundRows(0).Item("costo")) - 1) * 100, 2)
        End If
        If dgv_matriz_precios.CurrentCell.ColumnIndex = 4 Then
            If MsgBox("Se ha modificado el precio de compra, ¿desea actualizar todos los precios del catalogo en relación a su utilidad?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

                Dim total_precios As Integer
                limpiar_variables()
                'Conectar()
                rx.Open("SELECT id_producto_precio,utilidad FROM producto_precio WHERE id_producto='" & id_producto & "' ORDER BY id_producto_precio DESC", conn)
                If rx.RecordCount > 0 Then
                    Dim i As Integer = 1
                    While Not rx.EOF
                        id_producto_precio(i) = rx.Fields("id_producto_precio").Value
                        precio(i) = FormatNumber((foundRows(0).Item("costo") * ((rx.Fields("utilidad").Value / 100) + 1)), 2)
                        total_precios = i
                        i += 1
                        rx.MoveNext()
                    End While

                End If
                rx.Close()
                'conn.close()
                'conn = Nothing
                For x = 1 To total_precios
                    foundRows(0).Item("precio" & x) = precio(x)
                Next
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For x = 0 To dgv_matriz_precios.RowCount - 1
            If IsDBNull(dgv_matriz_precios.Rows(x).Cells("eliminar").Value) = True Then
                dgv_matriz_precios.Rows(x).Cells("eliminar").Value = True
            Else
                If dgv_matriz_precios.Rows(x).Cells("eliminar").Value = True Then
                    dgv_matriz_precios.Rows(x).Cells("eliminar").Value = False
                Else
                    dgv_matriz_precios.Rows(x).Cells("eliminar").Value = True
                End If
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim seleccionados As Integer = 0
        Dim eliminados As Integer = 0
        If existen_turnos_abiertos() = False Then
            If MsgBox("Se eliminarán los productos seleccionados, ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                For x = 0 To dgv_matriz_precios.RowCount - 1
                    If dgv_matriz_precios.Rows(x).Cells("eliminar").Value = True Then
                        seleccionados = seleccionados + 1
                    End If
                Next
                For x = 0 To dgv_matriz_precios.RowCount - 1
                    If dgv_matriz_precios.Rows(x).Cells("eliminar").Value = True Then
                        eliminar_producto(dgv_matriz_precios.Rows(x).Cells("id_producto").Value)
                        eliminados = eliminados + 1
                    End If
                Next
                MsgBox("Se eliminarón " & eliminados & " productos de " & seleccionados & " seleccionados", MsgBoxStyle.Exclamation, "aviso")
                cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value)
            End If
        Else
            MsgBox("Se encontro turno(s) abierto(s), para realizar esta operacion, todos los usuarios deben realizar corte de caja!", MsgBoxStyle.Exclamation, "aviso")
        End If
    End Sub
    Private Function existen_turnos_abiertos() As Boolean
        Dim abierto As Boolean = False
        'Conectar()
        Dim hoy As String = Format(Today, "yyyy-MM-dd")
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND DATE(fecha)='" & hoy & "'", conn)
        If rs.RecordCount > 0 Then
            abierto = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return abierto
    End Function
    Private Sub eliminar_producto(ByVal id As Integer)
        'Conectar()
        conn.Execute("DELETE FROM factura_compra_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM cliente_productos WHERE id_producto=" & id)
        conn.Execute("DELETE FROM cotizacion_detalle WHERE id_producto=" & id)
        'conn.Execute("DELETE FROM detalle_pedido WHERE id_producto=" & id)
        conn.Execute("DELETE FROM devoluciones_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM factura_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM pedido_prog_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_cat_imp WHERE id_producto=" & id)
        conn.Execute("DELETE FROM cliente_productos WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_compuesto WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_equivalente WHERE id_producto_equivalente=" & id)
        conn.Execute("DELETE FROM producto_equivalente WHERE id_producto_origen=" & id)
        conn.Execute("DELETE FROM producto_volumen WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_sucursal WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_precio WHERE id_producto=" & id)
        conn.Execute("DELETE FROM proveedor_productos WHERE id_producto=" & id)
        conn.Execute("DELETE FROM temp_venta_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM traspaso_env_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM traspaso_recep_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM venta_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto WHERE id_producto=" & id)
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub pb_anterior_Click(sender As System.Object, e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value, tb_pagina.Text)
        End If
    End Sub
    Private Sub pb_siguiente_Click(sender As System.Object, e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value, tb_pagina.Text)
        End If
    End Sub
    Private Sub tb_pagina_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar_precios(tb_buscar.Text, CType(cb_categoria.SelectedItem, myItem).Value, CType(cb_marca.SelectedItem, myItem).Value, tb_pagina.Text)
            End If
        End If
    End Sub
End Class