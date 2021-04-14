Public Class frm_insumos
    Private id_insumo As Integer = 0

    Private Sub frm_insumos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_insumos = 0
    End Sub

    Private Sub frm_insumos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        global_frm_insumos = 1
        configuracion_inicio()
        rellenar_catalogo_combobox("id_insumo_grupo", "grupo", "rest_insumo_grupo", cb_grupo_busqueda, True)
        rellenar_catalogo_combobox("id_insumo_grupo", "grupo", "rest_insumo_grupo", cb_grupo)
        rellenar_catalogo_combobox("id_unidad", "nombre", "unidad", cb_unidad_medida)
        rellenar_catalogo_combobox("id_impuesto", "alias", "impuesto", cb_impuesto)
        configuracion_listas()
    End Sub

    Private Sub rellenar_catalogo_combobox(id As String, valor As String, tabla_db As String, combobox As ComboBox, Optional opcion_general As Boolean = False)
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
        gb_insumo.Enabled = False

        tb_clave.Text = ""
        tb_descripcion.Text = ""
        tb_costo_impuesto.Text = "0"
        tb_costo_promedio.Text = "0"
        tb_ultimo_costo.Text = "0"
        lst_presentaciones.Items.Clear()
    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True

        tb_descripcion.Text = ""
        tb_costo_impuesto.Text = "0"
        tb_costo_promedio.Text = "0"
        tb_ultimo_costo.Text = "0"
        lst_presentaciones.Items.Clear()

    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_insumos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 100)
            .Columns.Add("Descripción", 180)
            .Columns.Add("Costo", 50)
            .Columns.Add("Unidad", 70)
        End With

        With lst_presentaciones
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 70)
            .Columns.Add("Descripción", 200)
            .Columns.Add("Rendimiento", 70)
            .Columns.Add("Unidad", 70)
            .Columns.Add("Costo", 70)
        End With


        For i = 0 To lst_insumos.Items.Count - 2 Step 2
            lst_insumos.Items(i + 1).BackColor = Color.Turquoise
            lst_insumos.Items(i).BackColor = Color.White
        Next


        For i = 0 To lst_presentaciones.Items.Count - 2 Step 2
            lst_presentaciones.Items(i + 1).BackColor = Color.YellowGreen
            lst_presentaciones.Items(i).BackColor = Color.White
        Next
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        cargar_insumo(0)
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        guardar_insumo(id_insumo)
    End Sub
    Private Sub guardar_insumo(id_insumo As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_descripcion.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta descripción de la presentacion " & vbCrLf
        End If
        If cb_grupo.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un grupo de insumos " & vbCrLf
        End If
        If cb_unidad_medida.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione una unidad de medida " & vbCrLf
        End If

        If cb_impuesto.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un impuesto " & vbCrLf
        End If

        If cb_impuesto.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un impuesto " & vbCrLf
        End If

        If correcto = True Then

            Dim id_insumo_grupo As Integer = 0
            Dim id_unidad_medida As Integer = 0
            Dim id_impuesto As Integer = 0


            id_insumo_grupo = CType(cb_grupo.SelectedItem, myItem).Value
            id_unidad_medida = CType(cb_unidad_medida.SelectedItem, myItem).Value
            id_impuesto = CType(cb_impuesto.SelectedItem, myItem).Value

            If id_insumo > 0 Then
                conn.Execute("UPDATE rest_insumo SET id_insumo_grupo='" & id_insumo_grupo & "',clave='" & tb_clave.Text & "',descripcion='" & tb_descripcion.Text & "',id_unidad='" & id_unidad_medida & "',ultimo_costo='" & tb_ultimo_costo.Text & "',costo_promedio='" & tb_costo_promedio.Text & "',id_impuesto='" & id_impuesto & "',costo_cimpuestos='" & tb_costo_impuesto.Text & "',inventariable='" & chb_inventariable.CheckState & "' WHERE id_insumo='" & id_insumo & "'")

            Else
                conn.Execute("INSERT INTO rest_insumo(id_insumo_grupo,clave,descripcion,id_unidad,ultimo_costo,costo_promedio,id_impuesto,costo_cimpuestos,inventariable)VALUES('" & id_insumo_grupo & "','" & tb_clave.Text & "','" & tb_descripcion.Text & "','" & id_unidad_medida & "','" & tb_ultimo_costo.Text & "','" & tb_costo_promedio.Text & "','" & id_impuesto & "','" & tb_costo_impuesto.Text & "','" & chb_inventariable.CheckState & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_insumo = rs.Fields(0).Value
                rs.Close()

            End If


            cargar_grupo_productos(CType(cb_grupo_busqueda.SelectedItem, myItem).Value)
            cargar_insumo(id_insumo)
        Else
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If

    End Sub

    Private Sub btn_deshacer_Click(sender As System.Object, e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Function propuesta_codigo(ByVal id_grupo As Integer) As String
        tb_clave.Text = ""
        Dim codigo As String = ""
        Dim rw As New ADODB.Recordset
        Dim clave_grupo As String = ""


        rw.Open("SELECT clave FROM rest_insumo_grupo WHERE id_insumo_grupo='" & id_grupo & "'", conn)
        If rw.RecordCount > 0 Then
            clave_grupo = rw.Fields("clave").Value
        End If
        rw.Close()


        rw.Open("SELECT CASE WHEN ISNULL(MAX(clave)) THEN 0 ELSE (MAX(clave)+1) END AS propuesta FROM rest_insumo WHERE id_insumo_grupo='" & id_grupo & "'", conn)
        If rw.RecordCount > 0 Then
            codigo = rw.Fields("propuesta").Value
        End If
        rw.Close()

        If codigo = "0" Then
            codigo = CDbl(clave_grupo) + 1
        End If

        Return codigo
    End Function

    Private Sub cb_grupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_grupo.SelectedIndexChanged
        If cb_grupo.SelectedIndex <> -1 Then
            tb_clave.Text = propuesta_codigo(CType(cb_grupo.SelectedItem, myItem).Value)
        End If
    End Sub

    Private Sub cb_grupo_busqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_grupo_busqueda.SelectedIndexChanged
        cargar_grupo_productos(CType(cb_grupo_busqueda.SelectedItem, myItem).Value)
        If cb_grupo_busqueda.SelectedIndex > 0 Then
            seleccionar_catalogo(CType(cb_grupo_busqueda.SelectedItem, myItem).Value, cb_grupo)
        End If
    End Sub

    Private Sub seleccionar_catalogo(ByVal id_catalogo As Integer, ByVal cb As ComboBox)
        '-----buscamos el tipo servicio_tecnico
        For x = 0 To cb.Items.Count - 1
            If id_catalogo = CType(cb.Items(x), myItem).Value Then
                cb.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub cargar_grupo_productos(id_grupo As Integer)
        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_insumos.Items.Clear()
        If id_grupo > 0 Then
            filtro = "WHERE id_insumo_grupo='" & id_grupo & "'"
        End If

        rs.Open("SELECT ri.id_insumo, ri.clave, ri.descripcion,u.nombre AS unidad,ri.ultimo_costo " & _
                "FROM rest_insumo ri " & _
                "JOIN unidad u ON u.id_unidad=ri.id_unidad " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("descripcion").Value
                str(2) = FormatCurrency(rs.Fields("ultimo_costo").Value, 2)
                str(3) = rs.Fields("unidad").Value

                lst_insumos.Items.Add(New ListViewItem(str, 0))
                lst_insumos.Items(i).Tag = rs.Fields("id_insumo").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_insumo()

    End Sub
    Private Sub aplicar_estilo_insumo()

        For i = 0 To lst_insumos.Items.Count - 2 Step 2
            lst_insumos.Items(i + 1).BackColor = Color.Turquoise
            lst_insumos.Items(i).BackColor = Color.White
        Next


        For i = 0 To lst_presentaciones.Items.Count - 2 Step 2
            lst_presentaciones.Items(i + 1).BackColor = Color.YellowGreen
            lst_presentaciones.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_insumo(id As Integer)
        id_insumo = id

        If id_insumo > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT id_insumo_grupo,clave,descripcion,id_unidad,ultimo_costo,costo_promedio,id_impuesto,costo_cimpuestos,inventariable " & _
                    "FROM rest_insumo " & _
                    "WHERE id_insumo='" & id_insumo & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_descripcion.Text = rs.Fields("descripcion").Value
                seleccionar_catalogo(rs.Fields("id_unidad").Value, cb_unidad_medida)
                tb_ultimo_costo.Text = rs.Fields("ultimo_costo").Value
                tb_costo_promedio.Text = rs.Fields("costo_promedio").Value
                seleccionar_catalogo(rs.Fields("id_impuesto").Value, cb_impuesto)
                tb_costo_impuesto.Text = rs.Fields("costo_cimpuestos").Value
                chb_inventariable.CheckState = rs.Fields("inventariable").Value

            End If
            rs.Close()
            cargar_presentaciones(id_insumo)

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_presentaciones.Enabled = True
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
            If cb_grupo.SelectedIndex <> -1 Then
                tb_clave.Text = propuesta_codigo(CType(cb_grupo.SelectedItem, myItem).Value)
            End If
            gb_presentaciones.Enabled = False
        End If
    End Sub
    Public Sub cargar_presentaciones(id_insumo As Integer)
        Dim i As Integer = 0

        lst_presentaciones.Items.Clear()

        rs.Open("SELECT rp.id_presentacion, rp.clave, rp.descripcion,u.nombre AS unidad,rp.costo_cimpuestos " & _
               "FROM rest_presentacion rp " & _
               "JOIN unidad u ON u.id_unidad=rp.id_unidad WHERE id_insumo='" & id_insumo & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("descripcion").Value
                str(2) = FormatCurrency(rs.Fields("costo_cimpuestos").Value, 2)
                str(3) = rs.Fields("unidad").Value

                lst_presentaciones.Items.Add(New ListViewItem(str, 0))
                lst_presentaciones.Items(i).Tag = rs.Fields("id_presentacion").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_insumo()
    End Sub
    Private Sub lst_insumos_DoubleClick(sender As Object, e As System.EventArgs) Handles lst_insumos.DoubleClick
        If lst_insumos.SelectedItems.Count > 0 Then
            cargar_insumo(lst_insumos.SelectedItems.Item(0).Tag)
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_insumo(id_insumo)
    End Sub
    Private Sub eliminar_insumo(id As Integer)
        Try
            If MsgBox("Desea borrar este insumo?, se eliminaran de las recetas!", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM rest_insumo WHERE id_insumo='" & id & "'")
                cargar_grupo_productos(CType(cb_grupo_busqueda.SelectedItem, myItem).Value)
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try


    End Sub

    Private Sub btn_editar_Click(sender As System.Object, e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub

    Private Sub btn_agregar_presentacion_Click(sender As System.Object, e As System.EventArgs) Handles btn_agregar_presentacion.Click
        frm_presentaciones.precarga = False
        frm_presentaciones.cargar()
        frm_presentaciones.precargar_insumo(id_insumo, tb_descripcion.Text, cb_unidad_medida.Text)
        frm_presentaciones.Show()
    End Sub
    Private Sub tb_ultimo_costo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_ultimo_costo.KeyPress
        e.Handled = txtNumerico(tb_costo_impuesto, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_promedio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_costo_promedio.KeyPress
        e.Handled = txtNumerico(tb_costo_promedio, e.KeyChar, True)
    End Sub

    Private Sub tb_costo_impuesto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_costo_impuesto.KeyPress
        e.Handled = txtNumerico(tb_costo_impuesto, e.KeyChar, True)
    End Sub

    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs) Handles btn_buscar.Click

    End Sub
End Class