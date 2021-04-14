Public Class frm_colaboradores
    Private id_unidad As Integer = 0

    Private Sub frm_unidad_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        global_frm_unidad = 0
        If global_frm_producto = 1 Then
            frm_producto2.rellenar_catalogo_combobox("id_unidad", "nombre", "unidad", frm_producto2.cb_unidad)
        End If
    End Sub

    Private Sub frm_unidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_unidad = 1
        configuracion_inicio()
        configuracion_listas()
        cargar_catalogo_unidad()
    End Sub

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_unidad.Enabled = False

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_unidad.Enabled = False

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_unidad.Enabled = True

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_unidad.Enabled = True
    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_unidad.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_unidad
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 80)
            .Columns.Add("Nombre", 250)
        End With

        For i = 0 To lst_unidad.Items.Count - 2 Step 2
            lst_unidad.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_unidad.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_unidad(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_unidad(id_unidad)
    End Sub
    Private Sub guardar_unidad(ByVal id_unidad As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_clave.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta clave " & vbCrLf
        End If

        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre de la unidad " & vbCrLf
        End If
        If Trim(tb_nombre_corto.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre corto " & vbCrLf
        End If

        If correcto = True Then

            If id_unidad > 0 Then
                conn.Execute("UPDATE unidad SET clave='" & tb_clave.Text & "', nombre='" & tb_nombre.Text & "', nombre_corto='" & tb_nombre_corto.Text & "' WHERE id_unidad='" & id_unidad & "'")
                MsgBox("Unidad actualizada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                conn.Execute("INSERT INTO unidad(clave,nombre,nombre_corto)VALUES('" & tb_clave.Text & "','" & tb_nombre.Text & "','" & tb_nombre_corto.Text & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_unidad = rs.Fields(0).Value
                rs.Close()
                MsgBox("Unidad insertarda correctamente", MsgBoxStyle.Information, "Aviso")
            End If

            cargar_unidad(id_unidad)


            cargar_catalogo_unidad()
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
    Private Sub cargar_catalogo_unidad()
        Dim i As Integer = 0

        lst_unidad.Items.Clear()

        rs.Open("SELECT id_unidad,clave,nombre " & _
                "FROM unidad", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(2) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("nombre").Value

                lst_unidad.Items.Add(New ListViewItem(str, 0))
                lst_unidad.Items(i).Tag = rs.Fields("id_unidad").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo()
    End Sub
    Private Sub aplicar_estilo()

        For i = 0 To lst_unidad.Items.Count - 2 Step 2
            lst_unidad.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_unidad.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_unidad(ByVal id As Integer)
        id_unidad = id

        If id_unidad > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT * " & _
                    "FROM unidad " & _
                    "WHERE id_unidad='" & id_unidad & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_nombre_corto.Text = rs.Fields("nombre_corto").Value

            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_unidad.Enabled = False
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
        End If
    End Sub
    Private Sub lst_unidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_unidad.DoubleClick
        If lst_unidad.SelectedItems.Count > 0 Then
            cargar_unidad(lst_unidad.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_precio(id_unidad)
    End Sub
    Private Sub eliminar_precio(ByVal id As Integer)
        '   Try
        If MsgBox("Desea borrar esta unidad?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("DELETE FROM unidad WHERE id_unidad='" & id & "'")
            cargar_catalogo_unidad()
            configuracion_inicio()
        End If
        ' Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        '  End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
End Class