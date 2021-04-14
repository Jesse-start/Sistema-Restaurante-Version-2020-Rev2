Public Class frm_impuesto
    Private nodo As TreeViewEventArgs
    Private bandera_actualizar As Boolean
    Private _actualizar As Boolean
    Private nodo_aux As TreeNode
    Private conn As ADODB.Connection
    Private rs As ADODB.Recordset
    Private tabla As DataTable

    Private Sub frm_impuesto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        'habilitar_menu_ventana()
        global_frm_impuesto = 0
        ''conn.close()
    End Sub

    Private Sub frm_impuesto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn = conexion()
        rs = conector()

        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        global_frm_impuesto = 1

        CategoriaImpuesto(arbolCategorias.Nodes)
        tb_nombre.Enabled = False
        tb_alias.Enabled = False
        tb_porcentaje.Enabled = False
        _actualizar = False
        bandera_actualizar = False
        If arbolCategorias.Nodes.Count > 0 Then
            arbolCategorias.SelectedNode = arbolCategorias.Nodes(0)
        End If
    End Sub

    Private Sub arbolCategorias_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbolCategorias.AfterSelect



        tb_categoria.Text = e.Node.Text
        nodo = e
        Button8.Enabled = False

        Button5.Enabled = True
        Impuesto("SELECT id_impuesto,nombre, alias ,porcentaje FROM impuesto WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag, "Impuestos " & nodo.Node.Text, dg_impuesto)
        tb_nombre.Enabled = False
        tb_alias.Enabled = False
        tb_porcentaje.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tb_categoria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_categoria.TextChanged
        Button8.Enabled = True

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If tb_categoria.Text <> nodo.Node.Text Then
            actualizar("UPDATE impuesto_catalogo SET nombre = '" & tb_categoria.Text & "' WHERE id_catalogo = " & nodo.Node.Tag)
            nodo.Node.Text = tb_categoria.Text
            Button5.Enabled = False
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If actualizar("INSERT INTO impuesto_catalogo VALUES ('','" & tb_categoria.Text & "', NOW(), (NULL))") = True Then
            rs.Open("select last_insert_id() ", conn)
            arbolCategorias.Nodes.Add(rs.Fields(0).Value, tb_categoria.Text)
            arbolCategorias.Nodes(arbolCategorias.Nodes.Count - 1).Tag = rs.Fields(0).Value
            rs.Close()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = dg_impuesto.VisibleRowCount
            If dg_impuesto.IsSelected(NumRow) = True Then
                actualizar("UPDATE impuesto SET fecha_baja = CURDATE() WHERE fecha_baja is null AND id_impuesto = " & dg_impuesto.Item(dg_impuesto.CurrentCell.RowNumber, 0).ToString & " AND id_catalogo = " & nodo.Node.Tag)
            End If
            NumRow = NumRow + 1
        Loop
        Impuesto("SELECT id_impuesto,nombre, alias ,porcentaje FROM impuesto WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag, "Impuestos " & nodo.Node.Text, dg_impuesto)
    End Sub

    Private Sub dg_impuesto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_impuesto.Click
        If dg_impuesto.VisibleRowCount <> 0 Then
            bandera_actualizar = True
            tb_nombre.Text = dg_impuesto.Item(dg_impuesto.CurrentCell.RowNumber, 1).ToString
            tb_alias.Text = dg_impuesto.Item(dg_impuesto.CurrentCell.RowNumber, 2).ToString
            tb_porcentaje.Text = dg_impuesto.Item(dg_impuesto.CurrentCell.RowNumber, 3).ToString
            tb_nombre.Enabled = True
            tb_alias.Enabled = True
            tb_porcentaje.Enabled = True
        End If
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        tb_nombre.Text = ""
        tb_alias.Text = ""
        tb_porcentaje.Text = ""
        bandera_actualizar = False
        tb_porcentaje.Enabled = True
        tb_alias.Enabled = True
        tb_nombre.Enabled = True
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        If bandera_actualizar = True Then
            conn.BeginTrans()
            Try
                conn.Execute("UPDATE impuesto SET fecha_baja = CURDATE() WHERE fecha_baja is null AND id_impuesto = " & dg_impuesto.Item(dg_impuesto.CurrentCell.RowNumber, 0).ToString & " AND id_catalogo = " & nodo.Node.Tag)
                conn.Execute("INSERT INTO impuesto VALUES (''," & nodo.Node.Tag & ", '" & tb_nombre.Text & "','" & tb_alias.Text & "'," & Replace(tb_porcentaje.Text, ",", ".") & ", NOW(), (NULL) )")
                conn.CommitTrans()
                Impuesto("SELECT id_impuesto,nombre,alias,porcentaje FROM impuesto WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag, "Impuestos " & nodo.Node.Text, dg_impuesto)
                'conn.close()
            Catch ex As Exception
                MsgBox(ex.Message)
                conn.RollbackTrans()
                'conn.close()
            End Try
        Else
            actualizar("INSERT INTO impuesto VALUES (''," & nodo.Node.Tag & ", '" & tb_nombre.Text & "','" & tb_alias.Text & "'," & Replace(tb_porcentaje.Text, ",", ".") & ", NOW(), (NULL) )")
            Impuesto("SELECT id_impuesto,nombre,alias,porcentaje FROM impuesto WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag, "Impuestos " & nodo.Node.Text, dg_impuesto)
            tb_nombre.Enabled = False
            tb_nombre.Text = ""
            tb_alias.Enabled = False
            tb_alias.Text = ""
            tb_porcentaje.Enabled = False
            tb_porcentaje.Text = ""
        End If
    End Sub

    Private Sub dg_impuesto_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_impuesto.Navigate

    End Sub

    Private Sub m_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_nuevo.Click
        tb_categoria.Visible = True
        tb_categoria.Text = ""
        m_guardar.Enabled = True
        m_eliminar.Enabled = False
        m_editar.Enabled = False
        m_cancelar.Visible = True
    End Sub

    Private Sub m_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_editar.Click
        arbolCategorias.Enabled = False
        nodo.Node.ForeColor = Color.Red
        _actualizar = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
        m_cancelar.Visible = True
        tb_categoria.Visible = True
        tb_categoria.Text = nodo.Node.Text
        m_editar.Enabled = False
        m_guardar.Enabled = True
        m_nuevo.Enabled = False
    End Sub

    Private Sub m_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_eliminar.Click
        If MsgBox("Esta seguro de eliminar el catalogo", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

            actualizar("UPDATE impuesto_catalogo SET fecha_baja = CURDATE() WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag)
            actualizar("UPDATE impuesto SET fecha_baja = CURDATE() WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag)
            actualizar("DELETE FROM categoria_cat_imp WHERE id_catalogo= " & nodo.Node.Tag)
            nodo.Node.Remove()
        End If
    End Sub

    Private Sub m_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cancelar.Click
        If _actualizar = True Then
            Impuesto("SELECT id_impuesto,nombre,alias,porcentaje FROM impuesto WHERE fecha_baja is null AND id_catalogo = " & nodo.Node.Tag, "Impuestos " & nodo.Node.Text, dg_impuesto)
            tb_nombre.Enabled = False
            tb_nombre.Text = ""
            tb_alias.Enabled = False
            tb_alias.Text = ""
            tb_porcentaje.Enabled = False
            tb_porcentaje.Text = ""

            m_cancelar.Visible = False
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
            arbolCategorias.Enabled = True
            _actualizar = False
            m_editar.Enabled = True
            nodo.Node.ForeColor = Color.White
        Else
            tb_categoria.Visible = False
            m_eliminar.Enabled = True
            m_editar.Enabled = True
        End If
        m_guardar.Enabled = False
        m_cancelar.Visible = False
        m_nuevo.Enabled = True
    End Sub

    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_guardar.Click
        bandera_actualizar = True
        If _actualizar = False Then
            If tb_categoria.Text <> "" Then
                If actualizar("INSERT INTO impuesto_catalogo VALUES ('','" & tb_categoria.Text.ToUpper() & "', NOW(), (NULL))") = True Then
                    rs.Open("select last_insert_id()", conn)
                    arbolCategorias.Nodes.Add(rs.Fields(0).Value, tb_categoria.Text.ToUpper)
                    arbolCategorias.Nodes(arbolCategorias.Nodes.Count - 1).Tag = rs.Fields(0).Value
                    m_guardar.Enabled = False
                    tb_nombre.Visible = True
                    m_eliminar.Enabled = True
                    m_editar.Enabled = True
                    m_cancelar.Visible = False
                    rs.Close()
                End If
            End If
        Else
            rs.Open("SELECT id_catalogo, nombre FROM (SELECT impuesto.id_catalogo, impuesto_catalogo.nombre , count(*) AS contador FROM impuesto INNER JOIN impuesto_catalogo ON impuesto.id_catalogo=impuesto_catalogo.id_catalogo WHERE impuesto.fecha_baja IS NULL AND impuesto.id_catalogo!= " & nodo.Node.Tag & " GROUP BY impuesto.id_catalogo) AS categoria WHERE contador=" & tabla.Rows.Count, conn)
            While Not rs.EOF And bandera_actualizar
                If rs.RecordCount > 0 Then
                    Dim rs2 As New ADODB.Recordset
                    rs2.Open("SELECT COUNT(temp1.alias) AS identicos from (SELECT alias,porcentaje FROM impuesto WHERE id_catalogo='" & rs.Fields("id_catalogo").Value & "' AND fecha_baja IS NULL) as temp1, (SELECT alias,porcentaje FROM impuesto WHERE id_catalogo='" & nodo.Node.Tag & "' AND fecha_baja IS NULL) as temp2 WHERE temp1.alias=temp2.alias AND temp1.porcentaje=temp2.porcentaje", conn)
                    If rs2.RecordCount > 0 Then
                        If rs2.Fields("identicos").Value = tabla.Rows.Count Then
                            bandera_actualizar = False
                            MessageBox.Show("La categotia " & rs.Fields("nombre").Value & " contiene la misma informacion")
                        End If
                    End If
                    rs2.Close()
                    rs.MoveNext()
                End If
            End While
            rs.Close()
            If bandera_actualizar = True Then
                arbolCategorias.Enabled = True
                If tb_categoria.Text <> nodo.Node.Text Then
                    actualizar("UPDATE impuesto_catalogo SET nombre = '" & tb_categoria.Text & "' WHERE id_catalogo = " & nodo.Node.Tag, conn)
                    nodo.Node.Text = tb_categoria.Text

                    _actualizar = False
                End If
                tb_nombre.Enabled = False
                tb_nombre.Text = ""
                tb_alias.Enabled = False
                tb_alias.Text = ""
                tb_porcentaje.Enabled = False
                tb_porcentaje.Text = ""
                m_guardar.Enabled = False
                tb_nombre.Visible = False
                m_eliminar.Enabled = True
                m_editar.Enabled = True
                m_nuevo.Enabled = True
                m_cancelar.Visible = False
                GroupBox2.Enabled = False
                GroupBox3.Enabled = False
                arbolCategorias.Enabled = True
                _actualizar = False
                m_editar.Enabled = True
                nodo.Node.ForeColor = Color.White
            End If
        End If
        tb_categoria.Visible = False
    End Sub
End Class