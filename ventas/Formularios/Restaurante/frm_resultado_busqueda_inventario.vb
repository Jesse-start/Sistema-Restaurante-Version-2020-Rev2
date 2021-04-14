Public Class frm_resultado_busqueda_inventario
    Public id_almacen_tipo As Integer
    Private Sub frm_resultado_busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With lst_busqueda
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Nombre", 250)
            .Columns.Add("Unidad", 100)
        End With
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If lst_busqueda.SelectedItems.Count > 0 Then
            frm_inventario_fisico.cargar_elemento(lst_busqueda.SelectedItems.Item(0).Tag, lst_busqueda.SelectedItems.Item(0).Text)
            Me.Close()
        Else
            MsgBox("Debe seleccionar un producto de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub
    Public Function buscar(busqueda As String) As Boolean
        Dim found As Boolean = False
        lst_busqueda.Items.Clear()


        If id_almacen_tipo = 1 Then ' ALMACEN DE PRODUCTOS

            rs.Open("SELECT p.id_producto,p.nombre,u.nombre AS unidad FROM producto p " & _
                    "JOIN  unidad u  ON p.id_unidad=u.id_unidad " & _
                    "WHERE (p.nombre LIKE '%" & Trim(busqueda) & "%' OR p.codigo LIKE '%" & Trim(busqueda) & "%') ORDER BY p.nombre", conn)
            If rs.RecordCount > 0 Then
                Dim i = 0
                While Not rs.EOF
                    Dim str(2) As String
                    str(0) = rs.Fields("nombre").Value
                    str(1) = rs.Fields("unidad").Value
                    lst_busqueda.Items.Add(New ListViewItem(str, 0))
                    lst_busqueda.Items(i).Tag = rs.Fields("id_producto").Value
                    rs.MoveNext()
                    i = i + 1
                End While
                found = True
            End If
            rs.Close()

        ElseIf id_almacen_tipo = 2 Then ' ALMACEN DE INSUMOS
            '===============BUSCAMOS UN INSUMO==========================
            rs.Open("SELECT ri.id_insumo,ri.descripcion,u.nombre AS unidad FROM rest_insumo ri, unidad u WHERE 1 AND ri.id_unidad=u.id_unidad AND ri.descripcion like '%" & Trim(busqueda) & "%' GROUP BY id_insumo ORDER BY ri.descripcion", conn)
            If rs.RecordCount > 0 Then
                Dim i = 0
                While Not rs.EOF
                    Dim str(2) As String
                    str(0) = rs.Fields("descripcion").Value
                    str(1) = rs.Fields("unidad").Value
                    lst_busqueda.Items.Add(New ListViewItem(str, 0))
                    lst_busqueda.Items(i).Tag = rs.Fields("id_insumo").Value
                    rs.MoveNext()
                    i = i + 1
                End While
                found = True
            End If
            rs.Close()

        ElseIf id_almacen_tipo = 3 Then ' ALMACEN DE PRESENTACIONES


        End If

        Return found
    End Function
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
    End Sub
    Private Sub lst_busqueda_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_busqueda.DoubleClick
        Button1_Click(sender, e)
    End Sub
    Private Sub tb_busqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_busqueda.TextChanged
        If Trim(tb_busqueda.TextLength) > 2 Then
            buscar(tb_busqueda.Text)
        End If
    End Sub
End Class