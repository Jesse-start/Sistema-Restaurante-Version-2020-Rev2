Imports System.Math
Public Class frm_categoria_favoritos

    Dim i As Integer
    Dim filtro_sql As String = ""

    Dim reg_por_pag As Integer = 40
    Dim inicial As Integer = 0

    Dim total_productos As Integer = 0

    Dim total_paginas As Integer = 0

    Dim ejecutar As Boolean = False
    '---tabla_
    Dim ds As DataSet
    Dim tabla_favoritos As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow
    Dim current_id_categoria As Integer = -1


    Private Sub frm_producto_abrir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.MdiParent = frm_principal
        conf_listbox()
        cargar_categorias()
        cargar_estilo_favoritos()
        If cb_categoria.Items.Count > 0 Then
            cb_categoria.SelectedIndex = 0
        End If
    End Sub
    Private Sub cargar_estilo_favoritos()
        tabla_favoritos = New DataTable("favoritos")

        With tabla_favoritos.Columns
            .Add(New DataColumn("no", GetType(Integer)))
            .Add(New DataColumn("id_producto", GetType(Integer))) 'oculto
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image))) 'oculto
            .Add(New DataColumn("nombre", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_favoritos)

        With dgv_favoritos
            .DataSource = ds
            .DataMember = "favoritos"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_producto").Visible = False
            .Columns("imagen").Visible = False


            With .Columns("no")
                .HeaderText = "Lugar"
                .Width = 45
                .ReadOnly = True
            End With
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 250
                .ReadOnly = False
            End With
        End With
    End Sub
    Private Sub cargar_categorias()
        cb_categoria.Items.Clear()
        cb_categoria.Text = ""
        cb_categoria.Items.Add(New myItem(0, "Favoritos"))
        'Conectar()
        rs.Open("SELECT id_categoria,nombre FROM categoria WHERE super=0 Order By id_categoria", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_categoria.Items.Add(New myItem(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End If

        End While
        rs.Close()

        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub conf_listbox()
        With lista_cotizacion
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Nombre", 250)
            .Columns.Add("Unidad", 100)
        End With

        ejecutar = True

        tb_buscar.Text = "p"
        tb_buscar.Text = ""
    End Sub

    Private Sub cargar_productos_categorias(Optional ByVal pagina As Integer = 1, Optional ByVal id_categoria As Integer = 0)

        btn_agregar.Enabled = False

        tb_pagina.Text = pagina

        inicial = (pagina - 1) * reg_por_pag

        lista_cotizacion.Items.Clear()
        filtro_sql = ""

        If Trim(tb_buscar.Text) <> "" Then
            filtro_sql = filtro_sql & " AND (p.nombre like '%" & Trim(tb_buscar.Text) & "%' OR p.descripcion like '%" & Trim(tb_buscar.Text) & "%')"
        End If
        Dim filtro_cat As String = ""
        If id_categoria <> 0 Then
            filtro_cat = " p.id_categoria=" & id_categoria
        Else
            filtro_cat = "1"
        End If
        'Conectar()
        rs.Open("SELECT count(*) as total_productos FROM producto p WHERE " & filtro_cat & filtro_sql, conn)
        total_productos = rs.Fields("total_productos").Value
        rs.Close()

        total_paginas = Ceiling(total_productos / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas

        If total_paginas > 1 Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

        rs.Open("SELECT p.id_producto,p.nombre,p.descripcion, u.nombre unidad FROM producto p, unidad u WHERE " & filtro_cat & " AND p.id_unidad=u.id_unidad " & filtro_sql & " GROUP BY id_producto ORDER BY p.nombre DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        i = 0
        While Not rs.EOF

            Dim str(2) As String
            str(0) = rs.Fields("nombre").Value
            str(1) = rs.Fields("unidad").Value
            lista_cotizacion.Items.Add(New ListViewItem(str, 0))
            lista_cotizacion.Items(i).Tag = rs.Fields("id_producto").Value
            rs.MoveNext()
            i = i + 1
        End While

        tb_resultados.Text = total_productos & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()
        'conn.close()
        'conn = Nothing
        If pagina > 1 Then
            pb_anterior.Visible = True
        Else
            pb_anterior.Visible = False
        End If

        If pagina < total_paginas Then
            pb_siguiente.Visible = True
        Else
            pb_siguiente.Visible = False
        End If
        'TextBox1.Text = "SELECT * FROM producto p WHERE " & filtro_cat & filtro_sql & " ORDER BY p.nombre DESC LIMIT " & inicial & "," & reg_por_pag
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub lista_cotizacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lista_cotizacion.SelectedIndexChanged
        If lista_cotizacion.SelectedItems.Count > 0 Then
            btn_agregar.Enabled = True
        Else
            btn_agregar.Enabled = False
        End If
    End Sub

    Private Sub lista_cotizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lista_cotizacion.DoubleClick
        btn_aceptar_Click(sender, e)
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If lista_cotizacion.SelectedItems.Count > 0 Then
            If tabla_favoritos.Rows.Count <= 19 Then

                Dim foundRows() As Data.DataRow = tabla_favoritos.Select("id_producto = " & lista_cotizacion.SelectedItems.Item(0).Tag)
                Dim descuento As Decimal = 0

                If foundRows.Length > 0 Then
                    MsgBox("el producto ya se encuentra en la lista")
                Else

                    For x = 1 To 20

                        Dim foundRows_lugar() As Data.DataRow = tabla_favoritos.Select("no = " & x)
                        If foundRows_lugar.Length = 0 Then
                            agregar_favorito(x, lista_cotizacion.SelectedItems.Item(0).Tag, lista_cotizacion.SelectedItems(0).SubItems(0).Text)
                            Exit For
                        End If
                    Next





                End If
            Else
                MsgBox("No puede agregar mas productos a los favoritos de esta categoria")
            End If

        End If
    End Sub

    Private Sub pb_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            If cb_categoria.SelectedIndex <> -1 Then
                cargar_productos_categorias(tb_pagina.Text, CType(cb_categoria.SelectedItem, myItem).Value)
            End If
        End If
    End Sub

    Private Sub pb_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            If cb_categoria.SelectedIndex <> -1 Then
                cargar_productos_categorias(tb_pagina.Text, CType(cb_categoria.SelectedItem, myItem).Value)
            End If
        End If
    End Sub


    Private Sub tb_pagina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_pagina.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_pagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                If cb_categoria.SelectedIndex <> -1 Then
                    cargar_productos_categorias(tb_pagina.Text, CType(cb_categoria.SelectedItem, myItem).Value)
                End If
            End If
        End If
    End Sub
    Private Sub tb_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ejecutar Then
            If cb_categoria.SelectedIndex <> -1 Then
                cargar_productos_categorias(, CType(cb_categoria.SelectedItem, myItem).Value)
            End If
        End If
    End Sub

    Private Sub tb_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_buscar.TextChanged
        If ejecutar Then
            If cb_categoria.SelectedIndex <> -1 Then
                cargar_productos_categorias(, CType(cb_categoria.SelectedItem, myItem).Value)
            End If
        End If
    End Sub

    Private Sub cb_categoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_categoria.SelectedIndexChanged
        If cb_categoria.SelectedIndex <> -1 Then
            current_id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
            cargar_productos_categorias(, current_id_categoria)

            obtener_favoritos(current_id_categoria)
        End If
    End Sub
    Private Sub agregar_favorito(ByVal lugar As Integer, ByVal id_producto As Integer, ByVal nombre As String)
        tabla_linea = tabla_favoritos.NewRow()
        tabla_linea("no") = lugar
        tabla_linea("id_producto") = id_producto
        tabla_linea("nombre") = nombre
        tabla_favoritos.Rows.Add(tabla_linea)
    End Sub
    Private Sub obtener_favoritos(ByVal id_categoria As Integer)
        tabla_favoritos.Clear()
        'Conectar()
        If id_categoria = 0 Then
            rs.Open("SELECT id_producto,nombre,favorito FROM producto WHERE favorito<>0 ORDER by favorito", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_favorito(rs.Fields("favorito").Value, rs.Fields("id_producto").Value, rs.Fields("nombre").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        Else
            rs.Open("SELECT id_producto,nombre,favorito_cat FROM producto WHERE id_categoria='" & id_categoria & "' AND favorito_cat<>0 ORDER by favorito_cat", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_favorito(rs.Fields("favorito_cat").Value, rs.Fields("id_producto").Value, rs.Fields("nombre").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End If
        'conn.close()
        'conn = Nothing

    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            dgv_favoritos.Rows.RemoveAt(dgv_favoritos.CurrentRow.Index)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cb_categoria.SelectedIndex <> -1 Then
            If MsgBox("Confirme Guardar cambios", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                If current_id_categoria = 0 Then
                    conn.Execute("UPDATE producto set favorito=0 WHERE favorito<>0")
                    For x = 0 To tabla_favoritos.Rows.Count - 1
                        conn.Execute("UPDATE producto set favorito='" & dgv_favoritos.Item("no", x).Value & "' where id_producto='" & dgv_favoritos.Item("id_producto", x).Value & "'")
                    Next
                Else
                    conn.Execute("UPDATE producto set favorito_cat=0 WHERE id_categoria='" & current_id_categoria & "' AND favorito_cat<>0")
                    For x = 0 To tabla_favoritos.Rows.Count - 1
                        conn.Execute("UPDATE producto set favorito_cat='" & dgv_favoritos.Item("no", x).Value & "' where id_producto='" & dgv_favoritos.Item("id_producto", x).Value & "'")
                    Next
                End If
                'conn.close()
                MsgBox("favoritos actualizado correctamente")
            End If
        End If

    End Sub
End Class