Public Class frm_almacenes
    Dim modo As String ' indica si se actualiza o se agrega uno nuevo
    Dim nombre_almacen As String ' nombre del almacen seleccionado
    Dim id_almacen As Integer = 0 ' id del almacen seleccionado
    Dim bandera_default As Boolean = False
    Private Sub frm_almacenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        configuracion_inicio()
    End Sub
    Private Sub llenar_nombre()
        tb_nombre.Items.Clear()
        'Conectar()
        rs.Open("SELECT * FROM almacenes Order By Nombre", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                tb_nombre.Items.Add(New MyItem(rs.Fields("ID_Almacen").Value, rs.Fields("Nombre").Value))
                rs.MoveNext()
            End If

        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub configuracion_inicio()
        tb_nombre.DropDownStyle = ComboBoxStyle.DropDownList
        llenar_nombre()
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = False
        btn_guardar.Enabled = False
        btn_nuevo.Enabled = True
        tb_nombre.Text = ""
        tb_calle.Text = ""
        tb_colonia.Text = ""
        tb_localidad.Text = ""
        tb_responsable.Text = ""
        tb_telefono.Text = ""
        chb_default.Checked = False
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        modo = "nuevo"
        tb_nombre.Items.Clear()
        tb_nombre.DropDownStyle = ComboBoxStyle.Simple
        tb_nombre.Text = ""
        tb_calle.Text = ""
        tb_colonia.Text = ""
        tb_localidad.Text = ""
        tb_responsable.Text = ""
        tb_telefono.Text = ""
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = True
        btn_guardar.Enabled = True
        chb_default.Checked = False
    End Sub

    Private Sub tb_nombre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_nombre.SelectedIndexChanged
        If tb_nombre.SelectedIndex >= 0 Then
            'Conectar()
            rs.Open("SELECT * FROM almacenes WHERE ID_Almacen='" & CType(tb_nombre.SelectedItem, MyItem).Value & "'", conn)
            If rs.RecordCount > 0 Then
                id_almacen = rs.Fields("ID_Almacen").Value
                nombre_almacen = rs.Fields("Nombre").Value
                tb_calle.Text = rs.Fields("Calle").Value
                tb_colonia.Text = rs.Fields("Colonia").Value
                tb_localidad.Text = rs.Fields("Localidad").Value
                tb_telefono.Text = rs.Fields("Telefono").Value
                tb_responsable.Text = rs.Fields("Responsable").Value
                chb_default.CheckState = rs.Fields("default_ventas").Value
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True


        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar(modo)
    End Sub
    Private Sub guardar(ByVal modo As String)
        Dim b As Boolean = False
        Dim mensaje_error As String = "Los siguientes datos son Obligatorios:" & vbCrLf & vbCrLf

        If Trim(tb_nombre.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Nombre del Almacén" & vbCrLf
            b = True
        End If
        If Trim(tb_calle.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Calle" & vbCrLf
            b = True
        End If

        If Trim(tb_colonia.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Colonia" & vbCrLf
            b = True
        End If

        If Trim(tb_localidad.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Localidad" & vbCrLf
            b = True
        End If

        If Trim(tb_telefono.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Telefono" & vbCrLf
            b = True
        End If

        If Trim(tb_responsable.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Responsable" & vbCrLf
            b = True
        End If
        If b Then
            MsgBox(mensaje_error, MsgBoxStyle.Exclamation, "Información Requerida")
        Else
            If modo = "nuevo" Then
                'Conectar()
                If bandera_default = True Then
                    If chb_default.Checked = True Then
                        conn.Execute("UPDATE almacenes SET default_ventas=0 WHERE default_ventas=1")
                    End If
                End If
                conn.Execute("INSERT INTO almacenes(Nombre,Calle,Colonia,Localidad,Telefono,Responsable,id_sucursal,default_ventas) VALUES ('" & tb_nombre.Text & "','" & tb_calle.Text & "','" & tb_colonia.Text & "','" & tb_localidad.Text & "','" & tb_telefono.Text & "','" & tb_responsable.Text & "','" & global_id_sucursal & "','" & chb_default.CheckState & "')", , -1)
                'conn.close()
                'conn = Nothing
                MsgBox(tb_nombre.Text & " guardado correctamente", MsgBoxStyle.Information, "Información")
                configuracion_inicio()
            ElseIf modo = "editar" Then
                If id_almacen <> 0 Then
                    If MsgBox("Esta seguro de modificar  " & nombre_almacen & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        'Conectar()
                        If bandera_default = True Then
                            If chb_default.Checked = True Then
                                conn.Execute("UPDATE almacenes SET default_ventas=0 WHERE default_ventas=1")
                            End If
                        End If
                        conn.Execute("UPDATE almacenes SET Nombre = '" & tb_nombre.Text & "',Calle = '" & tb_calle.Text & "',Colonia = '" & tb_colonia.Text & "',Localidad = '" & tb_localidad.Text & "',Telefono = '" & tb_telefono.Text & "',Responsable = '" & tb_responsable.Text & "',default_ventas='" & chb_default.CheckState & "' WHERE ID_Almacen = " & id_almacen)
                        'conn.close()
                        'conn = Nothing
                        MsgBox(nombre_almacen & " actualizado correctamente", MsgBoxStyle.Information, "Información")
                        configuracion_inicio()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        modo = "editar"
        btn_nuevo.Enabled = False
        btn_cancelar.Enabled = True
        btn_guardar.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        tb_nombre.DropDownStyle = ComboBoxStyle.Simple
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If tb_nombre.SelectedIndex >= 0 Then
            If MsgBox("Esta seguro de eliminar  " & tb_nombre.Text & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                conn.Execute("DELETE FROM almacenes WHERE ID_Almacen='" & CType(tb_nombre.SelectedItem, MyItem).Value & "'")
                'conn.close()
                'conn = Nothing
                MsgBox(nombre_almacen & " Eliminado correctamente", MsgBoxStyle.Information, "Información")
                configuracion_inicio()
            End If
        End If
    End Sub

    Private Sub chb_default_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_default.Click
        bandera_default = True
    End Sub
End Class
