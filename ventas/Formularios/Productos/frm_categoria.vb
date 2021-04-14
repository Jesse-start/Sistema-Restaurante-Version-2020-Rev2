Public Class frm_categoria
    Private idNodo As Integer
    Private nodo As TreeViewEventArgs
    Private Sub frm_categoria_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        ' habilitar_menu_ventana()
        global_frm_categoria = 0
        If global_frm_producto = 1 Then
            frm_producto2.rellenar_catalogo_combobox("id_categoria", "nombre", "categoria", frm_producto2.cb_categoria)
        End If
    End Sub

    Private Sub frm_categoria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        global_frm_categoria = 1
        obtener_categorias()
        Button5.Enabled = False
        'Conectar()
        rs.Open("SELECT id_catalogo, nombre FROM impuesto_catalogo WHERE fecha_baja is NULL", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            clb_iva.Items.Add(New myItem(rs.Fields("id_catalogo").Value, rs.Fields("nombre").Value))
            rs.MoveNext()
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_categorias()
        arbolCategorias.Nodes.Clear()
        arbolCategorias.Nodes.Add(0, "Categorias")
        'Conectar()
        arbol_categoria(0, arbolCategorias.Nodes(0).Nodes)
        'conn.close()
        'conn = Nothing
        arbolCategorias.Nodes(0).Expand()
        tb_nombre.Text = ""
    End Sub

    Private Sub arbolCategorias_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbolCategorias.AfterSelect
        nodo = e
        idNodo = e.Node.Tag
        tb_categoria.Text = e.Node.Text
        nodo = e
        If tb_categoria.Text = "Categorias" Then
            GroupBox1.Enabled = False
        Else
            GroupBox1.Enabled = True
            Button4.Enabled = True
            If e.Node.GetNodeCount(False) <> 0 Then
                Button4.Enabled = False
            Else
                'Conectar()
                rs.Open("SELECT count(nombre) AS total from producto where id_categoria ='" & idNodo & "'", conn)
                If rs.Fields("total").Value <> 0 Then
                    Button4.Enabled = False
                End If
                rs.Close()
                'conn.close()
                'conn = Nothing
            End If
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        arbolCategorias.Focus()
        arbolCategorias.SelectedNode.Collapse()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        arbolCategorias.Focus()
        arbolCategorias.SelectedNode.ExpandAll()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If nodo.Node.Text <> tb_categoria.Text Then
            If tb_categoria.Text <> "" Then
                If actualizar("UPDATE categoria SET nombre = '" & tb_categoria.Text & "' WHERE id_categoria = " & idNodo) = True Then
                    nodo.Node.Text = tb_categoria.Text
                End If
            Else
                MsgBox("Campo vacio")
            End If
        Else
            MsgBox("sin cambio")
        End If
        Button5.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If actualizar(" DELETE FROM categoria WHERE id_categoria= " & idNodo) = True Then
            nodo.Node.Remove()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'conn.BeginTrans()
        ' Try
        If nodo IsNot Nothing Then
            If tb_nombre.Text <> "" Then
                'Conectar()
                conn.Execute("INSERT INTO categoria(nombre,super,fecha_alta,nivel) VALUES ('" & tb_nombre.Text & "', " & idNodo & ",NOW(),1)")
                nodo.Node.Nodes.Add(tb_nombre.Text)
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                For corrimiento = 0 To clb_iva.CheckedItems.Count - 1
                    conn.Execute("INSERT INTO categoria_cat_imp VALUES (" & rs.Fields(0).Value & ", " & CType(clb_iva.CheckedItems(corrimiento), myItem).Value & ")")
                Next
                Button4.Enabled = False
                rs.Close()
                'conn.close()
                'conn = Nothing
                obtener_categorias()
                'conn.CommitTrans()
            Else
                MsgBox("Campo vacio")
            End If
        Else
            MsgBox("Seleccione el nodo donde se insertará la categoria")
        End If
        ' Catch ex As Exception
        '  conn.RollbackTrans()
        ' MsgBox(ex.Message)
        ' End Try

    End Sub

    Private Sub tb_categoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_categoria.TextChanged
        Button5.Enabled = True
    End Sub
End Class