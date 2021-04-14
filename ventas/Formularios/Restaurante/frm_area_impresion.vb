Public Class frm_areas_impresion
    Private id_area As Integer = 0
    Private Sub frm_areas_impresion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_areas_impresion = 0
    End Sub

    Private Sub frm_areas_impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_areas_impresion = 1
        configuracion_inicio()
        rellenar_catalogo_combobox("id_almacen", "nombre", "almacenes", cb_almacen_descarga)
        configuracion_listas()
        cargar_listado_areas()
    End Sub
    Private Sub rellenar_catalogo_combobox(ByVal id As String, ByVal valor As String, ByVal tabla_db As String, ByVal combobox As ComboBox, Optional ByVal opcion_general As Boolean = False)
        Dim recordset As New ADODB.Recordset
        combobox.Items.Clear()
        If opcion_general = True Then
            combobox.Items.Add(New myItem("0", "Todos"))
        End If
        recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & "", conn)
        If recordset.RecordCount > 0 Then
            While Not recordset.EOF
                combobox.Items.Add(New myItem(recordset.Fields(id).Value, recordset.Fields(valor).Value))
                recordset.MoveNext()
            End While
        End If
        recordset.Close()
        combobox.SelectedIndex = 0
    End Sub

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_buscar.Enabled = True
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_area.Enabled = False

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_area.Enabled = False

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_area.Enabled = True

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_area.Enabled = True

    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_area.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_areas
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 100)
            .Columns.Add("Nombre", 200)
        End With

        For i = 0 To lst_areas.Items.Count - 2 Step 2
            lst_areas.Items(i + 1).BackColor = Color.Turquoise
            lst_areas.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_area(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_area(id_area)
    End Sub
    Private Sub guardar_area(ByVal id_area As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre del area " & vbCrLf
        End If
        If cb_almacen_descarga.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un almacen de descarga " & vbCrLf
        End If

        If correcto = True Then

            Dim id_almacen_descarga As Integer = 0


            id_almacen_descarga = CType(cb_almacen_descarga.SelectedItem, myItem).Value
            
            If id_area > 0 Then
                conn.Execute("UPDATE areas_impresion SET clave='" & tb_clave.Text & "', nombre='" & tb_nombre.Text & "',id_almacen_descarga='" & id_almacen_descarga & "' WHERE id_area_impresion='" & id_area & "'")

            Else
                conn.Execute("INSERT INTO areas_impresion(clave,nombre,id_almacen_descarga)VALUES('" & tb_clave.Text & "','" & tb_nombre.Text & "','" & id_almacen_descarga & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_area = rs.Fields(0).Value
                rs.Close()

            End If

            cargar_area(id_area)
            cargar_listado_areas()
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

    Private Function propuesta_codigo() As String
        tb_clave.Text = ""
        Dim codigo As String = ""
        Dim rw As New ADODB.Recordset


        rw.Open("SELECT CASE WHEN ISNULL(MAX(clave)) THEN 0 ELSE (MAX(clave)+1) END AS propuesta FROM areas_impresion", conn)
        If rw.RecordCount > 0 Then
            codigo = rw.Fields("propuesta").Value
        End If
        rw.Close()

        If codigo = "0" Then
            codigo = 1
        End If
        Return codigo
    End Function
    Private Sub seleccionar_catalogo(ByVal id_catalogo As Integer, ByVal cb As ComboBox)
        '-----buscamos el tipo servicio_tecnico
        For x = 0 To cb.Items.Count - 1
            If id_catalogo = CType(cb.Items(x), myItem).Value Then
                cb.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub cargar_listado_areas()
        Dim i As Integer = 0

        lst_areas.Items.Clear()

        rs.Open("SELECT id_area_impresion,clave,nombre,id_almacen_descarga " & _
                "FROM areas_impresion", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(2) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("nombre").Value

                lst_areas.Items.Add(New ListViewItem(str, 0))
                lst_areas.Items(i).Tag = rs.Fields("id_area_impresion").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_almacen()
    End Sub
    Private Sub aplicar_estilo_almacen()

        For i = 0 To lst_areas.Items.Count - 2 Step 2
            lst_areas.Items(i + 1).BackColor = Color.Turquoise
            lst_areas.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_area(ByVal id As Integer)
        id_area = id

        If id_area > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT clave,nombre,id_almacen_descarga " & _
                    "FROM areas_impresion " & _
                    "WHERE id_area_impresion='" & id_area & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                seleccionar_catalogo(rs.Fields("id_almacen_descarga").Value, cb_almacen_descarga)
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
            tb_clave.Text = propuesta_codigo()
        End If
    End Sub
    Private Sub lst_areas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_areas.DoubleClick
        If lst_areas.SelectedItems.Count > 0 Then
            cargar_area(lst_areas.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_area(id_area)
    End Sub
    Private Sub eliminar_area(ByVal id As Integer)
        Try
            If MsgBox("Desea borrar esta area de impresión?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM areas_impresion WHERE id_area='" & id & "'")
                cargar_listado_areas()
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
    Private Sub btn_agregar_almacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_almacen.Click
        frm_almacenes2.Show()
    End Sub
End Class