Public Class frm_servicio
    Dim id_servicio As Integer
    Dim bandera_default As Boolean = False
    Private Sub frm_servicio_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_servicio = 0
    End Sub

    Private Sub frm_servicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_servicio = 1
        configuracion_inicio()
        rellenar_catalogo_combobox("id_servicio_marca", "nombre", "ctlg_servicio_marca", cb_marca)
        rellenar_catalogo_combobox("id_servicio_modelo", "nombre", "ctlg_servicio_modelo", cb_modelo)
        cargar_clientes()
        cargar_colaboradores()
        configuracion_listas()
        cargar_servicios()
    End Sub
    Private Sub cargar_colaboradores()
        cb_colaborador.Items.Clear()
        'Conectar()
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_colaborador.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub

    Private Sub cargar_clientes()

        rs.Open("SELECT DISTINCT CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre, CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS razon_social, cliente.id_cliente " & _
               "FROM cliente " & _
               "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
               "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_cliente.Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("razon_social").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()

        If cb_cliente.Items.Count > 0 Then
            cb_cliente.SelectedIndex = 0
        End If
    End Sub
    Private Sub rellenar_catalogo_combobox(ByVal id As String, ByVal valor As String, ByVal tabla_db As String, ByVal combobox As ComboBox, Optional ByVal opcion_general As Boolean = False)
        Dim recordset As New ADODB.Recordset
        combobox.Items.Clear()
        If opcion_general = True Then
            combobox.Items.Add(New myItem("0", "Todos"))
        End If
        recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & "", conn)
        Dim registros = recordset.RecordCount
        If recordset.RecordCount > 0 Then
            While Not recordset.EOF
                combobox.Items.Add(New myItem(recordset.Fields(id).Value, recordset.Fields(valor).Value))
                recordset.MoveNext()
            End While
        End If
        recordset.Close()
        If registros > 0 Then
            combobox.SelectedIndex = 0
        End If
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
        tb_imei.Text = ""
        tb_falla.Text = ""
        tb_observaciones.Text = ""
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
        tb_imei.Text = ""
        gb_almacen.Enabled = True
        seleccionar_catalogo(global_id_empleado, cb_colaborador)
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
        With lst_servicios
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("FOLIO", 100)
            .Columns.Add("FECHA", 50)
            .Columns.Add("ESTADO", 200)
        End With

        For i = 0 To lst_servicios.Items.Count - 2 Step 2
            lst_servicios.Items(i + 1).BackColor = Color.Turquoise
            lst_servicios.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_servicios()
        lst_servicios.Items.Clear()
        Dim i As Integer = 0

        rs.Open("SELECT id_servicio,fecha,estatus FROM servicio", conn)
        If rs.RecordCount > 0 Then

            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("id_servicio").Value
                str(1) = rs.Fields("fecha").Value
                str(2) = rs.Fields("estatus").Value

                lst_servicios.Items.Add(New ListViewItem(str, 0))
                lst_servicios.Items(i).Tag = rs.Fields("id_servicio").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_listado()
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_servicio(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar_servicio(id_servicio)
    End Sub
    Private Sub guardar_servicio(ByVal id_servicio As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf


        If cb_cliente.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un cliente" & vbCrLf
        End If

        If cb_colaborador.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un colaborador" & vbCrLf
        End If
        If Trim(tb_imei.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta IMEI" & vbCrLf
        End If
        If Trim(cb_marca.Text) = "" Then
            correcto = False
            mensaje &= "    Seleccione una marca" & vbCrLf
        End If

        If Trim(cb_modelo.Text) = "" Then
            correcto = False
            mensaje &= "    Seleccione un modelo" & vbCrLf
        End If

        If correcto = True Then

            Dim id_servicio_modelo As Integer = 0
            Dim id_servicio_marca As Integer = 0
            Dim id_cliente As Integer = 0
            Dim id_colaborador As Integer = 0



            If cb_marca.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO ctlg_servicio_marca (nombre) VALUES ('" & cb_marca.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_servicio_marca = rs.Fields(0).Value
                rs.Close()
            Else
                id_servicio_marca = CType(cb_marca.SelectedItem, myItem).Value
            End If


            If cb_modelo.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO ctlg_servicio_modelo (nombre) VALUES ('" & cb_modelo.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_servicio_modelo = rs.Fields(0).Value
                rs.Close()
            Else
                id_servicio_modelo = CType(cb_modelo.SelectedItem, myItem).Value
            End If


            id_cliente = CType(cb_cliente.SelectedItem, myItem).Value
            id_colaborador = CType(cb_colaborador.SelectedItem, myItem).Value

            If id_servicio > 0 Then
                conn.Execute("UPDATE servicio SET fecha='" & Format(dtp_fecha_recepcion.Value, "yyyy-MM-dd") & "', id_cliente='" & id_cliente & "',id_empleado='" & id_colaborador & "',id_modelo='" & id_servicio_modelo & "',id_marca='" & id_servicio_marca & "',falla='" & tb_falla.Text & "',imei='" & tb_imei.Text & "',observacion='" & tb_observaciones.Text & "' WHERE id_servicio='" & id_servicio & "'")

            Else
                conn.Execute("INSERT INTO servicio(fecha,id_cliente,id_empleado,id_servicio_modelo,id_servicio_marca,falla,imei,observacion)VALUES('" & Format(dtp_fecha_recepcion.Value, "yyyy-MM-dd") & "','" & id_cliente & "','" & id_colaborador & "','" & id_servicio_modelo & "','" & id_servicio_marca & "','" & tb_falla.Text & "','" & tb_imei.Text & "','" & tb_observaciones.Text & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_servicio = rs.Fields(0).Value
                rs.Close()

            End If
            cargar_servicios()
            cargar_servicio(id_servicio)
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

    Private Sub cb_grupo_busqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  cargar_tipos_almacenes(CType(cb_busqueda_tipo.SelectedItem, myItem).Value)
        ' If cb_busqueda_tipo.SelectedIndex > 0 Then
        'seleccionar_catalogo(CType(cb_busqueda_tipo.SelectedItem, myItem).Value, cb_cliente)
        '  End If
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

    Private Sub aplicar_estilo_listado()

        For i = 0 To lst_servicios.Items.Count - 2 Step 2
            lst_servicios.Items(i + 1).BackColor = Color.Turquoise
            lst_servicios.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_servicio(ByVal id As Integer)
        id_servicio = id

        If id_servicio > 0 Then
            '=======================CARGAMOS SERVICIO==========================
            rs.Open("SELECT * FROM servicio WHERE id_servicio='" & id_servicio & "'", conn)
            If rs.RecordCount > 0 Then

                seleccionar_catalogo(rs.Fields("id_cliente").Value, cb_cliente)

                seleccionar_catalogo(rs.Fields("id_empleado").Value, cb_colaborador)
                seleccionar_catalogo(rs.Fields("id_servicio_marca").Value, cb_marca)
                seleccionar_catalogo(rs.Fields("id_servicio_modelo").Value, cb_modelo)
                tb_imei.Text = rs.Fields("imei").Value
                tb_falla.Text = rs.Fields("falla").Value
                tb_observaciones.Text = rs.Fields("observacion").Value
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

        End If
    End Sub
    Private Sub lst_almacenes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_servicios.DoubleClick
        If lst_servicios.SelectedItems.Count > 0 Then
            cargar_servicio(lst_servicios.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        ' eliminar_servicio(id_servicio)
    End Sub
    Private Sub eliminar_almacen(ByVal id As Integer)
        Try
            If MsgBox("Desea borrar este almacen?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM almacenes WHERE id_almacen='" & id & "'")
                'cargar_tipos_almacenes(CType(cb_busqueda_tipo.SelectedItem, myItem).Value)
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub

    Private Sub chb_defecto_ventas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        bandera_default = True
    End Sub

    Private Sub cb_marca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_marca.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Tab_servicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab_servicio.SelectedIndexChanged

    End Sub
End Class