Public Class frm_resultado
    Public busqueda As String
    Private Sub frm_resultado_busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With lst_busqueda
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Nombre", 250)
            .Columns.Add("Unidad", 100)
        End With
        buscar()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If lst_busqueda.SelectedItems.Count > 0 Then
            frm_producto._agregar_producto_modificador(lst_busqueda.SelectedItems.Item(0).Tag, lst_busqueda.SelectedItems.Item(0).Text)
            Me.Dispose()
        Else
            MsgBox("Debe seleccionar un producto de la lista", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub
    Public Function buscar() As Boolean
        Me.Hide()
        Dim found As Boolean = False
        lst_busqueda.Items.Clear()
        'Conectar()
        rs.Open("SELECT p.id_producto,p.nombre,u.nombre unidad FROM producto p, unidad u WHERE 1 AND p.id_unidad=u.id_unidad AND p.nombre like '%" & Trim(busqueda) & "%' OR p.descripcion like '%" & Trim(busqueda) & "' GROUP BY id_producto ORDER BY p.nombre", conn)
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
        'conn.close()
        Return found
    End Function
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
    End Sub
    Private Sub lst_busqueda_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_busqueda.DoubleClick
        Button1_Click(sender, e)
    End Sub
End Class