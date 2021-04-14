Public Class frm_vehiculos
    '----tabla vehiculos
    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla_vehiculos As DataTable
    Dim modo As String = ""
    Dim moviles(50, 7) As String 'Matriz almacenar vehiculos (filas,columnas)

    Private Sub frm_vehiculos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        vehiculos("Vehiculos", dg_vehiculos, Tabla_vehiculos)
        conf_inicio()
        obtener_sucursales()
        obtener_tipo_vehiculos()
        cargar_status_unidad()
        obtener_vehiculos()
    End Sub
    Private Sub obtener_vehiculos()
        'Conectar()


        ' id_movil  │     0       │   1     │    2    │      3     │     4      │      5       │      6     │   7  │ 
        ' -----------         -------------------------------------------------------------------------------------------------------------------
        '    0      │ num_unidad / cap_carga/ placas /aseguradora/ num_poliza / status_unidad/ tipo_movil/ alias /
        '    1             x          x     n   x          x             x            x            x           x 
        Dim i As Integer
        limpiar_moviles() '-limpiamos la matriz
        Tabla_vehiculos.Clear()
        rs.Open("SELECT moviles.id_movil,num_unidad,cap_carga,placas,aseguradora,num_poliza,status_unidad,tipo_movil.tipo_movil,sucursal.alias FROM moviles JOIN tipo_movil ON tipo_movil.id_tipomovil=moviles.id_tipomovil JOIN sucursal ON sucursal.id_sucursal=moviles.id_sucursal order by moviles.id_movil", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            '--agregamos a moviles
            i = rs.Fields("id_movil").Value
            moviles(i, 0) = rs.Fields("num_unidad").Value
            moviles(i, 1) = rs.Fields("cap_carga").Value
            moviles(i, 2) = rs.Fields("placas").Value
            moviles(i, 3) = rs.Fields("aseguradora").Value
            moviles(i, 4) = rs.Fields("num_poliza").Value
            moviles(i, 5) = rs.Fields("status_unidad").Value
            moviles(i, 6) = rs.Fields("tipo_movil").Value
            moviles(i, 7) = rs.Fields("alias").Value
            '-------------------------
            Linea = Tabla_vehiculos.NewRow()
            Linea(0) = i
            Linea(1) = rs.Fields("num_unidad").Value
            Linea(2) = rs.Fields("tipo_movil").Value
            Tabla_vehiculos.Rows.Add(Linea)
            rs.MoveNext()
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub limpiar_moviles()
        For i = 0 To 50
            For j = 0 To 7
                moviles(i, j) = Nothing

            Next
        Next
    End Sub
    Private Sub conf_inicio()
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = False
        btn_guardar.Enabled = False
        btn_nuevo.Enabled = True
        gb_unidad.Enabled = False
        limpiar()
    End Sub
    Private Sub obtener_detalle_sucursal(ByVal id_sucursal As Integer)
        'Conectar()
        rs.Open("SELECT domicilio.* FROM domicilio JOIN sucursal ON sucursal.id_domicilio=domicilio.id_domicilio WHERE sucursal.id_sucursal=" & id_sucursal, conn)
        If rs.RecordCount > 0 Then
            tb_estado.Text = rs.Fields("estado").Value
            tb_pais.Text = rs.Fields("pais").Value
            tb_poblacion.Text = rs.Fields("poblacion").Value
            tb_calle.Text = rs.Fields("calle").Value
            tb_colonia.Text = rs.Fields("colonia").Value
            tb_municipio.Text = rs.Fields("municipio").Value
            tb_cp.Text = rs.Fields("cp").Value
        End If
        rs.Close()
        tb_telefonos.Items.Clear()
        rs.Open("SELECT CONCAT(telefono.lada,' ',telefono.numero) As numero FROM telefono JOIN sucursal_tel ON sucursal_tel.id_telefono=telefono.id_telefono WHERE sucursal_tel.id_sucursal=" & id_sucursal, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                tb_telefonos.Items.Add(rs.Fields("numero").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub limpiar()
        '--direccion---

        tb_estado.Text = ""
        tb_pais.Text = ""
        tb_poblacion.Text = ""
        tb_calle.Text = ""
        tb_colonia.Text = ""
        tb_municipio.Text = ""
        tb_cp.Text = ""
        '--detalle vehiculo
        tb_id_movil.Text = ""
        tb_num_uni.Text = ""
        cb_tipo_vehiculo.SelectedIndex = -1
        cb_tipo_vehiculo.Text = ""
        tb_capcarga.Text = ""
        tb_placas.Text = ""
        tb_aseguradora.Text = ""
        tb_numpoliza.Text = ""

    End Sub
    Private Sub cargar(Optional ByVal id_vehiculo As Integer = 0)
        If id_vehiculo <> 0 Then

            ' id_movil  │     0       │   1     │    2    │      3     │     4      │      5       │      6     │   7  │ 
            ' -----------         -------------------------------------------------------------------------------------------------------------------
            '    0      │ num_unidad / cap_carga/ placas /aseguradora/ num_poliza / status_unidad/ tipo_movil/ alias /
            '    1             x          x     n   x          x             x            x            x           x 
            Dim i As Integer = id_vehiculo
            tb_id_movil.Text = i
            tb_num_uni.Text = moviles(i, 0)
            tb_capcarga.Text = moviles(i, 1)
            tb_placas.Text = moviles(i, 2)
            tb_aseguradora.Text = moviles(i, 3)
            tb_numpoliza.Text = moviles(i, 4)
            cb_status_unidad.Text = moviles(i, 5)
            cb_tipo_vehiculo.Text = moviles(i, 6)
            cb_sucursal.Text = moviles(i, 7)
        Else
            modo = "nuevo"
            gb_unidad.Enabled = True
            btn_editar.Enabled = False
            btn_eliminar.Enabled = False
            btn_cancelar.Enabled = True
            btn_guardar.Enabled = True
            obtener_sucursales(global_id_sucursal)
            obtener_tipo_vehiculos()
            cargar_status_unidad()
            limpiar()
        End If

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar()
    End Sub
    Private Sub obtener_tipo_vehiculos()
        cb_tipo_vehiculo.Items.Clear()
        cb_tipo_vehiculo.Text = ""
        'Conectar()
        rs.Open("SELECT * FROM tipo_movil ORDER by id_tipomovil", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_tipo_vehiculo.Items.Add(New myItem(rs.Fields("id_tipomovil").Value, rs.Fields("tipo_movil").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub obtener_sucursales(Optional ByVal current_idsucursal As Integer = 0)
        Dim tmp, i As Integer
        'Conectar()
        cb_sucursal.Items.Clear()
        cb_sucursal.Text = ""
        rs.Open("SELECT id_sucursal,alias FROM sucursal ORDER by id_sucursal", conn)
        If rs.RecordCount > 0 Then
            i = 0
            While Not rs.EOF
                cb_sucursal.Items.Add(New myItem(rs.Fields("id_sucursal").Value, rs.Fields("alias").Value))
                If rs.Fields("id_sucursal").Value = global_id_sucursal Then
                    tmp = i
                End If
                i = i + 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        If current_idsucursal <> 0 Then
            cb_sucursal.SelectedIndex = tmp
        End If
    End Sub

    Private Sub cb_sucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_sucursal.SelectedIndexChanged
        If cb_sucursal.SelectedIndex <> -1 Then
            obtener_detalle_sucursal(CType(cb_sucursal.SelectedItem, myItem).Value)
        End If
    End Sub
    Private Sub cargar_status_unidad()
        cb_status_unidad.Items.Clear()
        cb_status_unidad.Text = ""
        cb_status_unidad.Items.Add("ACTIVA")
        cb_status_unidad.Items.Add("FUERA DE SERVICIO")
        cb_status_unidad.Items.Add("SUSPENDIDA")
        cb_status_unidad.SelectedIndex = 0
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True

        cadena = "Error en los siguientes campos:" & vbCrLf

        If cb_sucursal.SelectedIndex = -1 Then
            cadena = cadena & "  Sucursal" & vbCrLf
            bandera_correcto = False
        End If
        If Trim(tb_num_uni.Text) = "" Then
            cadena = cadena & "  Número de vehiculo" & vbCrLf
            bandera_correcto = False
        End If
        If cb_tipo_vehiculo.SelectedIndex = -1 Then
            cadena = cadena & "  Tipo de vehiculo" & vbCrLf
            bandera_correcto = False
        End If

        If cb_status_unidad.SelectedIndex = -1 Then
            cadena = cadena & "  Status de unidad" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            If modo = "nuevo" Then
                If MsgBox("Confirme agregar nuevo vehiculo", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    'Conectar()
                    conn.Execute("INSERT INTO moviles(id_sucursal,num_unidad,cap_carga,placas,aseguradora,num_poliza,status_unidad,id_tipomovil)" & _
                                 " VALUES(" & CType(cb_sucursal.SelectedItem, myItem).Value & ",'" & tb_num_uni.Text & "','" & tb_capcarga.Text & "','" & tb_placas.Text & "','" & tb_aseguradora.Text & "','" & tb_numpoliza.Text & "','" & cb_status_unidad.Text & "'," & CType(cb_tipo_vehiculo.SelectedItem, myItem).Value & " )")
                    'conn.close()
                    MsgBox("Vehiculo Ingresado correctamemte")
                    conf_inicio()
                    obtener_vehiculos()
                End If
            End If
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        conf_inicio()
    End Sub

    Private Sub dg_vehiculos_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_vehiculos.MouseUp
        ' CON ESTA FUNCION SELECCIONAMOS TODA LA FILA-------------
        Dim pt As System.Drawing.Point
        pt = New Point(e.X, e.Y)
        Dim hti As DataGrid.HitTestInfo
        hti = dg_vehiculos.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            dg_vehiculos.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            dg_vehiculos.Select(hti.Row)
        End If
        '-------------------
        '-MOSTRAMOS VALORES SELECCIONADOS-------------------
        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = Tabla_vehiculos.Rows.Count
            If dg_vehiculos.IsSelected(NumRow) = True Then
                Dim id_vehiculo As Integer
                id_vehiculo = dg_vehiculos.Item(dg_vehiculos.CurrentCell.RowNumber, 0)
                conf_inicio()
                cargar(id_vehiculo)
            End If
            NumRow = NumRow + 1
        Loop
        '--------------------------------------------
    End Sub

    Private Sub dg_vehiculos_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_vehiculos.Navigate

    End Sub

    Private Sub tb_calle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_calle.TextChanged

    End Sub
End Class