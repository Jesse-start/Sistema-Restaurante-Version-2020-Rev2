Public Class frm_meseros
    Private id_mesero As Integer = 0
    Private Sub frm_areas_impresion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_meseros = 0
    End Sub

    Private Sub frm_meseros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_meseros = 1
        configuracion_inicio()

        configuracion_listas()
        cargar_listado_meseros()
    End Sub
    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_buscar.Enabled = True
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_mesero.Enabled = False

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_mesero.Enabled = False

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_mesero.Enabled = True

        tb_clave.Text = ""
        tb_nombre.Text = ""
        gb_mesero.Enabled = True

    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_mesero.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_meseros
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 80)
            .Columns.Add("Nombre", 200)
        End With

        For i = 0 To lst_meseros.Items.Count - 2 Step 2
            lst_meseros.Items(i + 1).BackColor = Color.Turquoise
            lst_meseros.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_mesero(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_mesero(id_mesero)
    End Sub
    Private Sub guardar_mesero(ByVal id_mesero As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre del mesero " & vbCrLf
        End If
       

        If correcto = True Then

          

           

            If id_mesero > 0 Then
                conn.Execute("UPDATE meseros SET clave='" & tb_clave.Text & "', nombre='" & tb_nombre.Text & "',password='" & tb_password.Text & "' WHERE id_mesero='" & id_mesero & "'")

            Else
                conn.Execute("INSERT INTO meseros(clave,nombre,password)VALUES('" & tb_clave.Text & "','" & tb_nombre.Text & "','" & tb_password.Text & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_mesero = rs.Fields(0).Value
                rs.Close()

            End If

            cargar_mesero(id_mesero)
            cargar_listado_meseros()
            MsgBox("Mesero agregado correctamente", MsgBoxStyle.Information, "Aviso")
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


        rw.Open("SELECT CASE WHEN ISNULL(MAX(clave)) THEN 0 ELSE (MAX(clave)+1) END AS propuesta FROM meseros", conn)
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
    Private Sub cargar_listado_meseros()
        Dim i As Integer = 0

        lst_meseros.Items.Clear()

        rs.Open("SELECT id_mesero,clave,nombre AS mesero FROM meseros", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(2) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("mesero").Value

                lst_meseros.Items.Add(New ListViewItem(str, 0))
                lst_meseros.Items(i).Tag = rs.Fields("id_mesero").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_meseros()
    End Sub
    Private Sub aplicar_estilo_meseros()

        For i = 0 To lst_meseros.Items.Count - 2 Step 2
            lst_meseros.Items(i + 1).BackColor = Color.Turquoise
            lst_meseros.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_mesero(ByVal id As Integer)
        id_mesero = id

        If id_mesero > 0 Then
            '=======================CARGAMOS MESERO===========================
            rs.Open("SELECT clave,nombre,password " & _
                    "FROM meseros " & _
                    "WHERE id_mesero='" & id_mesero & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_password.Text = rs.Fields("password").Value
            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_mesero.Enabled = False
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
            tb_clave.Text = propuesta_codigo()
        End If
    End Sub
    Private Sub lst_areas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_meseros.DoubleClick
        If lst_meseros.SelectedItems.Count > 0 Then
            cargar_mesero(lst_meseros.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_mesero(id_mesero)
    End Sub
    Private Sub eliminar_mesero(ByVal id As Integer)
        Try
            If MsgBox("Desea borrar este mesero?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM meseros WHERE id_mesero='" & id & "'")
                cargar_listado_meseros()
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
End Class