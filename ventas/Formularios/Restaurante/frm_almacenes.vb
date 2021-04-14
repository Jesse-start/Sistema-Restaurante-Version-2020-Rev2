Public Class frm_almacenes2
    Private id_almacen As Integer = 0
    Dim bandera_default As Boolean = False
    Private Sub frm_insumos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_almacenes = 0
    End Sub

    Private Sub frm_insumos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        global_frm_almacenes = 1
        configuracion_inicio()
        rellenar_catalogo_combobox("id_almacen_tipo", "nombre", "almacenes_tipo", cb_busqueda_tipo, True)
        rellenar_catalogo_combobox("id_almacen_tipo", "nombre", "almacenes_tipo", cb_tipo_almacen)
        rellenar_catalogo_combobox("id_sucursal", "alias", "sucursal", cb_sucursal)
        cargar_empleados()
        configuracion_listas()
    End Sub
    Private Sub cargar_empleados()
        cb_responsable.Items.Clear()
        'Conectar()
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_responsable.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
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
        gb_almacen.Enabled = False

        tb_clave.Text = ""
        tb_nombre.Text = ""
        tb_domicilio.Text = ""

        chb_defecto_ventas.CheckState = 0
    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_almacen.Enabled = True

        tb_clave.Text = ""
        tb_nombre.Text = ""
        tb_domicilio.Text = ""
        gb_almacen.Enabled = True
        chb_defecto_ventas.CheckState = 0
    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_almacen.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_almacenes
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Tipo", 100)
            .Columns.Add("Clave", 50)
            .Columns.Add("Nombre", 200)
        End With

        For i = 0 To lst_almacenes.Items.Count - 2 Step 2
            lst_almacenes.Items(i + 1).BackColor = Color.Turquoise
            lst_almacenes.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        cargar_almacen(0)
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        guardar_almacen(id_almacen)
    End Sub
    Private Sub guardar_almacen(id_almacen As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre del almacen " & vbCrLf
        End If
        If cb_tipo_almacen.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un tipo de almacen " & vbCrLf
        End If
        If Trim(tb_domicilio.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta domicilio del almacen" & vbCrLf
        End If
        If cb_responsable.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un responsable de almacen" & vbCrLf
        End If

        If cb_sucursal.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione una sucursal " & vbCrLf
        End If

        If correcto = True Then

            Dim id_tipo_almacen As Integer = 0
            Dim id_responsable As Integer = 0
            Dim id_sucursal As Integer = 0


            id_tipo_almacen = CType(cb_tipo_almacen.SelectedItem, myItem).Value
            id_responsable = CType(cb_responsable.SelectedItem, myItem).Value
            id_sucursal = CType(cb_sucursal.SelectedItem, myItem).Value

            If bandera_default = True Then
                If chb_defecto_ventas.Checked = True Then
                    conn.Execute("UPDATE almacenes SET default_ventas=0 WHERE default_ventas=1")
                End If
            End If


            If id_almacen > 0 Then
                conn.Execute("UPDATE almacenes SET id_almacen_tipo='" & id_tipo_almacen & "',clave='" & tb_clave.Text & "',nombre='" & tb_nombre.Text & "',id_empleado_responsable='" & id_responsable & "',id_sucursal='" & id_sucursal & "',domicilio='" & tb_domicilio.Text & "',default_ventas='" & chb_defecto_ventas.CheckState & "' WHERE id_almacen='" & id_almacen & "'")

            Else
                conn.Execute("INSERT INTO almacenes(id_almacen_tipo,clave,nombre,id_empleado_responsable,id_sucursal,domicilio,default_ventas)VALUES('" & id_tipo_almacen & "','" & tb_clave.Text & "','" & tb_nombre.Text & "','" & id_responsable & "','" & id_sucursal & "','" & tb_domicilio.Text & "','" & chb_defecto_ventas.CheckState & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_almacen = rs.Fields(0).Value
                rs.Close()

            End If


            cargar_tipos_almacenes(CType(cb_busqueda_tipo.SelectedItem, myItem).Value)
            cargar_almacen(id_almacen)
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

    Private Function propuesta_codigo(ByVal id_tipo As Integer) As String
        tb_clave.Text = ""
        Dim codigo As String = ""
        Dim rw As New ADODB.Recordset
        Dim clave_tipo As String = 0


        rw.Open("SELECT clave FROM almacenes WHERE id_almacen_tipo='" & id_tipo & "'", conn)
        If rw.RecordCount > 0 Then
            clave_tipo = rw.Fields("clave").Value
        End If
        rw.Close()


        rw.Open("SELECT CASE WHEN ISNULL(MAX(clave)) THEN 0 ELSE (MAX(clave)+1) END AS propuesta FROM almacenes WHERE id_almacen_tipo='" & id_tipo & "'", conn)
        If rw.RecordCount > 0 Then
            codigo = rw.Fields("propuesta").Value
        End If
        rw.Close()

        If codigo = "0" Then
            codigo = CDbl(clave_tipo) + 1
        End If
        Return codigo
    End Function

    Private Sub cb_grupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_tipo_almacen.SelectedIndexChanged
        If cb_tipo_almacen.SelectedIndex <> -1 Then

            If cb_tipo_almacen.SelectedIndex <> 0 Then
                chb_defecto_ventas.CheckState = 0
                chb_defecto_ventas.Enabled = False
            Else
                chb_defecto_ventas.CheckState = 0
                chb_defecto_ventas.Enabled = True
            End If

            tb_clave.Text = propuesta_codigo(CType(cb_tipo_almacen.SelectedItem, myItem).Value)

        End If
    End Sub

    Private Sub cb_grupo_busqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_busqueda_tipo.SelectedIndexChanged
        cargar_tipos_almacenes(CType(cb_busqueda_tipo.SelectedItem, myItem).Value)
        If cb_busqueda_tipo.SelectedIndex > 0 Then
            seleccionar_catalogo(CType(cb_busqueda_tipo.SelectedItem, myItem).Value, cb_tipo_almacen)
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
    Private Sub cargar_tipos_almacenes(id_tipo As Integer)
        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_almacenes.Items.Clear()
        If id_tipo > 0 Then
            filtro = "WHERE a.id_almacen_tipo='" & id_tipo & "'"
        End If

        rs.Open("SELECT a.id_almacen,a.clave,a.nombre,at.nombre AS tipo_almacen " & _
                "FROM almacenes a  " & _
                "JOIN almacenes_tipo at ON a.id_almacen_tipo=at.id_almacen_tipo " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(2) As String
                str(0) = rs.Fields("tipo_almacen").Value
                str(1) = rs.Fields("clave").Value
                str(2) = rs.Fields("nombre").Value

                lst_almacenes.Items.Add(New ListViewItem(str, 0))
                lst_almacenes.Items(i).Tag = rs.Fields("id_almacen").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_almacen()

    End Sub
    Private Sub aplicar_estilo_almacen()

        For i = 0 To lst_almacenes.Items.Count - 2 Step 2
            lst_almacenes.Items(i + 1).BackColor = Color.Turquoise
            lst_almacenes.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_almacen(id As Integer)
        id_almacen = id

        If id_almacen > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT id_almacen_tipo,clave,nombre,id_empleado_responsable,id_sucursal,domicilio,default_ventas " & _
                    "FROM almacenes " & _
                    "WHERE id_almacen='" & id_almacen & "'", conn)
            If rs.RecordCount > 0 Then
                tb_nombre.Text = rs.Fields("nombre").Value
                seleccionar_catalogo(rs.Fields("id_almacen_tipo").Value, cb_tipo_almacen)
                tb_clave.Text = rs.Fields("clave").Value
                seleccionar_catalogo(rs.Fields("id_empleado_responsable").Value, cb_responsable)
                seleccionar_catalogo(rs.Fields("id_sucursal").Value, cb_sucursal)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                chb_defecto_ventas.CheckState = rs.Fields("default_ventas").Value

            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_almacen.Enabled = False
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
            If cb_tipo_almacen.SelectedIndex <> -1 Then
                tb_clave.Text = propuesta_codigo(CType(cb_tipo_almacen.SelectedItem, myItem).Value)
            End If
        End If
    End Sub
    Private Sub lst_almacenes_DoubleClick(sender As Object, e As System.EventArgs) Handles lst_almacenes.DoubleClick
        If lst_almacenes.SelectedItems.Count > 0 Then
            cargar_almacen(lst_almacenes.SelectedItems.Item(0).Tag)
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_almacen(id_almacen)
    End Sub
    Private Sub eliminar_almacen(id As Integer)
        Try
            If MsgBox("Desea borrar este almacen?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM almacenes WHERE id_almacen='" & id & "'")
                cargar_tipos_almacenes(CType(cb_busqueda_tipo.SelectedItem, myItem).Value)
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try


    End Sub

    Private Sub btn_editar_Click(sender As System.Object, e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub

    Private Sub chb_defecto_ventas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chb_defecto_ventas.CheckedChanged
        bandera_default = True
    End Sub

    Private Sub lst_almacenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_almacenes.SelectedIndexChanged

    End Sub

    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs) Handles btn_buscar.Click

    End Sub
End Class