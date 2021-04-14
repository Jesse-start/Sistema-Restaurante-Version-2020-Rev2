Public Class frm_agentes_pedidos
    Private tabla_agentes As DataTable
    Private Linea As DataRow
    Private Sub frm_agentes_pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        agente_pedidos("Agentes-Pedidos", dg_agentes_pedidos, tabla_agentes)
        obtener_puestos()
        obtener_moviles()
        cargar()
    End Sub
    Private Sub cargar()
        tabla_agentes.Clear()
        'Conectar()
        rs.Open("SELECT agente_entrega.id_agente_entrega,agente_entrega.id_empleado,CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS nombre,empleado_puesto.nombre AS puesto,agente_entrega.id_vehiculo,moviles.num_unidad,tipo_movil.tipo_movil  FROM agente_entrega JOIN empleado ON empleado.id_empleado=agente_entrega.id_empleado JOIN persona ON persona.id_persona=empleado.id_persona JOIN moviles ON moviles.id_movil=agente_entrega.id_vehiculo JOIN tipo_movil ON tipo_movil.id_tipomovil=moviles.id_tipomovil JOIN empleado_puesto ON empleado_puesto.id_puesto=empleado.id_puesto ORDER BY agente_entrega.id_agente_entrega", conn)
        While Not rs.EOF
            Linea = tabla_agentes.NewRow()
            Linea(0) = rs.Fields("id_agente_entrega").Value
            Linea(1) = rs.Fields("id_empleado").Value
            Linea(2) = rs.Fields("nombre").Value
            Linea(3) = rs.Fields("puesto").Value
            Linea(4) = rs.Fields("id_vehiculo").Value
            Linea(5) = rs.Fields("num_unidad").Value
            Linea(6) = rs.Fields("tipo_movil").Value
            tabla_agentes.Rows.Add(Linea)
            rs.MoveNext()

        End While
        rs.Close()
        'conn.close()
        'conn = Nothing

    End Sub
    Private Sub obtener_puestos()
        cb_puesto.Items.Clear()
        cb_puesto.Text = ""
        'Conectar()
        rs.Open("SELECT * FROM empleado_puesto ORDER by nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_puesto.Items.Add(New myItem(rs.Fields("id_puesto").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

    End Sub
    Private Sub obtener_moviles()
        cb_moviles.Items.Clear()
        cb_moviles.Text = ""
        'Conectar()
        rs.Open("SELECT CONCAT(moviles.num_unidad, ' ',tipo_movil.tipo_movil) as movil,moviles.id_movil,moviles.num_unidad ,tipo_movil.tipo_movil FROM moviles JOIN tipo_movil ON tipo_movil.id_tipomovil=moviles.id_tipomovil WHERE moviles.status_unidad='ACTIVA' AND moviles.id_sucursal=" & global_id_sucursal, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_moviles.Items.Add(New myItem(rs.Fields("id_movil").Value, rs.Fields("movil").Value, rs.Fields("num_unidad").Value, rs.Fields("tipo_movil").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub obtener_empleados(Optional ByVal id_puesto As Integer = 0)
        cb_empleado.Items.Clear()
        cb_empleado.Text = ""
        If id_puesto <> 0 Then
            'Conectar()
            rs.Open("SELECT empleado.id_empleado, CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS nombre,empleado_puesto.nombre As puesto FROM empleado JOIN persona ON persona.id_persona=empleado.id_persona JOIN empleado_puesto ON empleado_puesto.id_puesto=empleado.id_puesto WHERE empleado.id_sucursal='" & global_id_sucursal & "' AND empleado.id_puesto='" & id_puesto & "' ORDER BY nombre", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    cb_empleado.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, rs.Fields("puesto").Value))
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            cb_empleado.Enabled = True
        Else
            'Conectar()
            rs.Open("SELECT empleado.id_empleado, CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) AS nombre,empleado_puesto.nombre As puesto FROM empleado JOIN persona ON persona.id_persona=empleado.id_persona JOIN empleado_puesto ON empleado_puesto.id_puesto=empleado.id_puesto WHERE empleado.id_sucursal='" & global_id_sucursal & "' ORDER BY nombre", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    cb_empleado.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, rs.Fields("puesto").Value))
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        gb_detalle.Enabled = True
        gb_agentes.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim contador As Integer
        contador = tabla_agentes.Rows.Count
        While 0 < contador
            If dg_agentes_pedidos.IsSelected(contador - 1) = True Then
                tabla_agentes.Rows.Item(contador - 1).Delete()
            End If
            contador = contador - 1
        End While
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        Dim contador As Integer
        cadena = "Error en los siguientes campos:" & vbCrLf
        If cb_empleado.SelectedIndex = -1 Then
            cadena = cadena & "  Colaborador" & vbCrLf
            bandera_correcto = False
        End If
        If cb_moviles.SelectedIndex = -1 Then
            cadena = cadena & "  Vehiculo" & vbCrLf
            bandera_correcto = False
        End If
        '---buscamos coincidencias de nombre------
        contador = tabla_agentes.Rows.Count
        While 0 < contador
            If dg_agentes_pedidos.Item(contador - 1, 2).ToString.ToUpper.Equals(cb_empleado.Text.ToUpper) Then
                cadena = cadena & "  Ya existe este agente" & vbCrLf
                bandera_correcto = False
            End If
            contador = contador - 1
        End While
        '--------------------------------------

        If bandera_correcto = True Then
            If btn_aceptar.Text = "Aceptar" Then
                Linea = tabla_agentes.NewRow()
                If tabla_agentes.Rows.Count = 0 Then
                    Linea(0) = 1
                Else
                    Linea(0) = CDbl(dg_agentes_pedidos.Item(tabla_agentes.Rows.Count - 1, 0)) + 1
                End If
                Linea(1) = CType(cb_empleado.SelectedItem, myItem).Value
                Linea(2) = cb_empleado.Text
                Linea(3) = CType(cb_empleado.SelectedItem, myItem).Opcional
                Linea(4) = CType(cb_moviles.SelectedItem, myItem).Value
                Linea(5) = CType(cb_moviles.SelectedItem, myItem).Opcional
                Linea(6) = CType(cb_moviles.SelectedItem, myItem).Opcional2
                tabla_agentes.Rows.Add(Linea)
            Else
                dg_agentes_pedidos.Item(dg_agentes_pedidos.CurrentCell.RowNumber, 1) = CType(cb_empleado.SelectedItem, myItem).Value
                dg_agentes_pedidos.Item(dg_agentes_pedidos.CurrentCell.RowNumber, 2) = cb_empleado.Text
                dg_agentes_pedidos.Item(dg_agentes_pedidos.CurrentCell.RowNumber, 3) = CType(cb_empleado.SelectedItem, myItem).Opcional
                dg_agentes_pedidos.Item(dg_agentes_pedidos.CurrentCell.RowNumber, 3) = CType(cb_moviles.SelectedItem, myItem).Value
                dg_agentes_pedidos.Item(dg_agentes_pedidos.CurrentCell.RowNumber, 3) = CType(cb_moviles.SelectedItem, myItem).Opcional
                dg_agentes_pedidos.Item(dg_agentes_pedidos.CurrentCell.RowNumber, 3) = CType(cb_moviles.SelectedItem, myItem).Opcional2

            End If
            btn_aceptar.Text = "Aceptar"
            cb_empleado.SelectedIndex = -1
            cb_moviles.SelectedIndex = -1
            gb_agentes.Enabled = True
            gb_detalle.Enabled = False
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub cb_puesto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_puesto.SelectedIndexChanged
        If cb_puesto.SelectedIndex <> -1 Then
            obtener_empleados(CType(cb_puesto.SelectedItem, myItem).Value)
        End If
    End Sub

    Private Sub rb_todos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_todos.CheckedChanged
        If rb_todos.Checked = True Then
            cb_puesto.Enabled = False
            obtener_empleados()
        Else
            cb_puesto.Enabled = True
        End If
    End Sub


    Private Sub rb_puesto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_puesto.CheckedChanged
        If rb_puesto.Checked = True Then
            If cb_puesto.SelectedIndex = -1 Then
                cb_empleado.Enabled = False
            Else
                cb_empleado.Enabled = True
            End If
        End If

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        btn_aceptar.Text = "Aceptar"
        cb_empleado.SelectedIndex = -1
        cb_moviles.SelectedIndex = -1
        gb_agentes.Enabled = True
        gb_detalle.Enabled = False
    End Sub

    Private Sub dg_agentes_pedidos_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_agentes_pedidos.MouseUp
        ' CON ESTA FUNCION SELECCIONAMOS TODA LA FILA-------------
        Dim pt As System.Drawing.Point
        pt = New Point(e.X, e.Y)
        Dim hti As DataGrid.HitTestInfo
        hti = dg_agentes_pedidos.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            dg_agentes_pedidos.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            dg_agentes_pedidos.Select(hti.Row)
        End If
        '-------------------
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'Conectar()
        Dim corrimiento As Integer
        conn.Execute("TRUNCATE TABLE agente_entrega")
        For corrimiento = 0 To tabla_agentes.Rows.Count - 1
            conn.Execute("INSERT INTO agente_entrega (id_empleado,id_vehiculo) VALUES ('" & dg_agentes_pedidos.Item(corrimiento, 1) & "', " & dg_agentes_pedidos.Item(corrimiento, 4) & ")")
        Next
        'conn.close()
        'conn = Nothing
    End Sub
    
End Class