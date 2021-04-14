Public Class frm_modificadores
    Private current_id_modificador As Integer
    Private Sub frm_modificadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_modificadores()
    End Sub
    Private Sub cargar_modificadores()
        cb_modificadores.Items.Clear()
        'Conectar()
        rs.Open("SELECT * FROM modificadores", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_modificadores.Items.Add(New myItem(rs.Fields("id_modificador").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        btn_actualizar_perspectiva.Enabled = False
        btn_borrar_perspectiva.Enabled = False
        tb_nombre_perspectiva_nuevo.Text = ""
        tb_nombre_perspectiva_nuevo.Enabled = False
        btn_aceptar.Enabled = False
    End Sub

    Private Sub btn_agregar_perspectiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_modificador.Click
        If Trim(tb_nombre_modificador.TextLength) = 0 Then
            MsgBox("Debe escribir un nombre valido para el modificador", MsgBoxStyle.Exclamation, "Aviso")
        Else
            'Conectar()
            conn.Execute("INSERT INTO modificadores(nombre)VALUES('" & tb_nombre_modificador.Text & "')")
            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            current_id_modificador = rs.Fields(0).Value
            rs.Close()
            'conn.close()
            'conn = Nothing
            cb_modificadores.Items.Add(New myItem(current_id_modificador, tb_nombre_modificador.Text))
            tb_nombre_modificador.Text = ""
        End If
    End Sub

    Private Sub btn_borrar_perspectiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_borrar_perspectiva.Click
        If cb_modificadores.Items.Count > 0 Then
            If cb_modificadores.SelectedIndex <> -1 Then
                'Conectar()
                conn.Execute(" DELETE FROM modificadores WHERE id_modificador= " & CType(cb_modificadores.SelectedItem, myItem).Value)
                'conn.close()
                'conn = Nothing
                cargar_modificadores()

            Else
                MsgBox("Seleccione un modificador de la lista", MsgBoxStyle.Information, "Aviso")
            End If
        End If
    End Sub

    Private Sub btn_actualizar_perspectiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar_perspectiva.Click
        If cb_modificadores.SelectedIndex <> -1 Then
            'Conectar()
            conn.Execute("UPDATE modificadores SET nombre='" & tb_nombre_perspectiva_nuevo.Text & "' WHERE id_modificador= " & CType(cb_modificadores.SelectedItem, myItem).Value)
            'conn.close()
            'conn = Nothing
            cargar_modificadores()
        Else
            MsgBox("Seleccione un modificador de la lista", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub cb_modificadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_modificadores.Click
        If cb_modificadores.SelectedItems.Count > 0 Then
            If cb_modificadores.SelectedIndex <> -1 Then
                tb_nombre_perspectiva_nuevo.Text = CType(cb_modificadores.SelectedItem, myItem).Text
                btn_borrar_perspectiva.Enabled = True
                tb_nombre_perspectiva_nuevo.Enabled = True
                btn_actualizar_perspectiva.Enabled = True
                current_id_modificador = CType(cb_modificadores.SelectedItem, myItem).Value
                btn_aceptar.Enabled = True
            Else
                btn_borrar_perspectiva.Enabled = False
                tb_nombre_perspectiva_nuevo.Enabled = False
                btn_actualizar_perspectiva.Enabled = False
            End If
        End If
      
    End Sub

    Private Sub cb_modificadores_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_modificadores.DoubleClick
        If cb_modificadores.SelectedItems.Count > 0 Then
            btn_aceptar_Click(sender, e)
        End If
    End Sub

    Private Sub cb_modificadores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_modificadores.SelectedIndexChanged

    End Sub

    Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cerrar.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        frm_producto._agregar_modificador(CType(cb_modificadores.SelectedItem, myItem).Value, CType(cb_modificadores.SelectedItem, myItem).Text)
        Me.Close()
    End Sub
End Class