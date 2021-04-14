Public Class frm_catalogo_precio
    Private id_precio As Integer = 0

    Private Sub frm_areas_impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        configuracion_inicio()
        configuracion_listas()
        cargar_catalogo_precios()
    End Sub

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_area.Enabled = False

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_area.Enabled = False
        chb_utilidad.CheckState = 0

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_area.Enabled = True

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_area.Enabled = True
        chb_utilidad.CheckState = 0
    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_area.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_precios
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 80)
            .Columns.Add("Nombre", 150)
            .Columns.Add("Utilidad", 80)
        End With

        For i = 0 To lst_precios.Items.Count - 2 Step 2
            lst_precios.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_precios.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_precio(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_precio(id_precio)
    End Sub
    Private Sub guardar_precio(ByVal id_precio As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_clave.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta clave " & vbCrLf
        End If

        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre del precio " & vbCrLf
        End If

        If correcto = True Then

            If id_precio > 0 Then
                conn.Execute("UPDATE ctlg_precios SET clave='" & tb_clave.Text & "', nombre='" & tb_nombre.Text & "', utilidad='" & tb_utilidad.Value & "' WHERE id_ctlg_precios='" & id_precio & "'")
                MsgBox("Precio actualizado correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                conn.Execute("INSERT INTO ctlg_precios(clave,nombre,utilidad)VALUES('" & tb_clave.Text & "','" & tb_nombre.Text & "','" & tb_utilidad.Value & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_precio = rs.Fields(0).Value
                rs.Close()
                MsgBox("Precio agregado correctamente", MsgBoxStyle.Information, "Aviso")
            End If

            cargar_precio(id_precio)
            cargar_catalogo_precios()
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
    Private Sub cargar_catalogo_precios()
        Dim i As Integer = 0

        lst_precios.Items.Clear()

        rs.Open("SELECT id_ctlg_precios,clave,nombre,utilidad " & _
                "FROM ctlg_precios", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(2) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("nombre").Value
                str(2) = rs.Fields("utilidad").Value

                lst_precios.Items.Add(New ListViewItem(str, 0))
                lst_precios.Items(i).Tag = rs.Fields("id_ctlg_precios").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo()
    End Sub
    Private Sub aplicar_estilo()

        For i = 0 To lst_precios.Items.Count - 2 Step 2
            lst_precios.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_precios.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_precio(ByVal id As Integer)
        id_precio = id

        If id_precio > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT * " & _
                    "FROM ctlg_precios " & _
                    "WHERE id_ctlg_precios='" & id_precio & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_utilidad.Text = rs.Fields("utilidad").Value

            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_area.Enabled = False
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
        End If
    End Sub
    Private Sub lst_areas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_precios.DoubleClick
        If lst_precios.SelectedItems.Count > 0 Then
            cargar_precio(lst_precios.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_precio(id_precio)
    End Sub
    Private Sub eliminar_precio(ByVal id As Integer)
        '  Try
        If MsgBox("Desea borrar este precio del catalogo?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("DELETE FROM ctlg_precios WHERE id_ctlg_precios='" & id & "'")
            cargar_catalogo_precios()
            configuracion_inicio()
        End If
        'Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        ' End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
    Private Sub chb_utilidad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chb_utilidad.CheckedChanged
        If chb_utilidad.CheckState = 1 Then
            tb_utilidad.Enabled = True
        ElseIf chb_utilidad.CheckState = 0 Then
            tb_utilidad.Enabled = False
            tb_utilidad.Value = 0
        End If
    End Sub
End Class