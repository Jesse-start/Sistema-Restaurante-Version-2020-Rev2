Public Class frm_categorias
    Private id_categoria As Integer = 0

    Private Sub frm_categorias_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        global_frm_categoria = 0
        If global_frm_producto = 1 Then
            frm_producto2.rellenar_catalogo_combobox("id_categoria", "nombre", "categoria", frm_producto2.cb_categoria)
        End If
    End Sub

    Private Sub frm_categorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_categoria = 1
        configuracion_inicio()
        configuracion_listas()
        cargar_catalogo_categorias()
    End Sub

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_categoria.Enabled = False

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_categoria.Enabled = False

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_categoria.Enabled = True

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_categoria.Enabled = True
    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_categoria.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_categorias
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 80)
            .Columns.Add("Nombre", 200)
        End With

        For i = 0 To lst_categorias.Items.Count - 2 Step 2
            lst_categorias.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_categorias.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_categoria(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_categoria(id_categoria)
    End Sub
    Private Sub guardar_categoria(ByVal id_categoria As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_clave.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta clave " & vbCrLf
        End If

        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre de la categoría " & vbCrLf
        End If

        If correcto = True Then

            If id_categoria > 0 Then
                conn.Execute("UPDATE categoria SET clave='" & tb_clave.Text & "', nombre='" & tb_nombre.Text & "' WHERE id_categoria='" & id_categoria & "'")
                MsgBox("Categoría actualizada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                conn.Execute("INSERT INTO categoria(clave,nombre)VALUES('" & tb_clave.Text & "','" & tb_nombre.Text & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_categoria = rs.Fields(0).Value
                rs.Close()
                MsgBox("Categoría insertada correctamente", MsgBoxStyle.Information, "Aviso")
            End If

            cargar_categoria(id_categoria)
            cargar_catalogo_categorias()
        Else
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub btn_deshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub cargar_catalogo_categorias()
        Dim i As Integer = 0

        lst_categorias.Items.Clear()

        rs.Open("SELECT id_categoria,clave,nombre " & _
                "FROM categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(2) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("nombre").Value

                lst_categorias.Items.Add(New ListViewItem(str, 0))
                lst_categorias.Items(i).Tag = rs.Fields("id_categoria").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo()
    End Sub
    Private Sub aplicar_estilo()

        For i = 0 To lst_categorias.Items.Count - 2 Step 2
            lst_categorias.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_categorias.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_categoria(ByVal id As Integer)
        id_categoria = id

        If id_categoria > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT * " & _
                    "FROM categoria " & _
                    "WHERE id_categoria='" & id_categoria & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value


            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_categoria.Enabled = False
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
        End If
    End Sub
    Private Sub lst_areas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_categorias.DoubleClick
        If lst_categorias.SelectedItems.Count > 0 Then
            cargar_categoria(lst_categorias.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_precio(id_categoria)
    End Sub
    Private Sub eliminar_precio(ByVal id As Integer)
        '    Try
        If MsgBox("Desea borrar este categoría?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("DELETE FROM categoria WHERE id_categoria='" & id & "'")
            cargar_catalogo_categorias()
            configuracion_inicio()
        End If
        '   Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        '   End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
End Class