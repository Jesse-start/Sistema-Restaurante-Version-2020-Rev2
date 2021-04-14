Public Class frm_opciones_favoritos

    Private Sub frm_opciones_favoritos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        estilo_opciones(dgv_opciones)
        estilo_opciones_favoritos(dgv_opciones_favoritos)
        obtener_opciones_diponibles()
        cargar_favoritos()
    End Sub
    Private Sub cargar_favoritos()
        tabla_opciones_favoritos.Clear()
        rs.Open("SELECT * FROM empleado_opciones WHERE id_empleado='" & global_id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_opciones_favoritos(rs.Fields("posicion").Value, rs.Fields("id_opcion").Value, rs.Fields("opcion").Value, frm_botones_terminal.obtener_imagen(rs.Fields("id_opcion").Value).GetThumbnailImage(50, 50, Nothing, New IntPtr), tb_url.Text)
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If dgv_opciones.SelectedRows.Count > 0 Then
            If dgv_opciones_favoritos.Rows.Count <= 19 Then

                Dim foundRows() As Data.DataRow = tabla_opciones_favoritos.Select("id_opcion = " & dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("id_opcion").Value)
                Dim descuento As Decimal = 0

                If foundRows.Length > 0 Then
                    MsgBox("La opcion ya se encuentra en la lista")
                Else
                    If dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("id_opcion").Value = 39 Then
                        If Trim(tb_url.Text) = "" Then
                            MsgBox("Debe escribir una direccion valida para esta opcion", MsgBoxStyle.Exclamation, "Aviso")
                        Else
                            For x = 1 To 20
                                Dim foundRows_lugar() As Data.DataRow = tabla_opciones_favoritos.Select("no = " & x)
                                If foundRows_lugar.Length = 0 Then
                                    agregar_opciones_favoritos(x, dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("id_opcion").Value, dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("opcion").Value, dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("imagen").Value, tb_url.Text)
                                    Exit For
                                End If
                            Next
                        End If
                    Else
                        For x = 1 To 20
                            Dim foundRows_lugar() As Data.DataRow = tabla_opciones_favoritos.Select("no = " & x)
                            If foundRows_lugar.Length = 0 Then
                                agregar_opciones_favoritos(x, dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("id_opcion").Value, dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("opcion").Value, dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("imagen").Value, tb_url.Text)
                                Exit For
                            End If
                        Next
                    End If

                  
                End If
            Else
                MsgBox("No puede agregar mas opciones")
            End If

        End If
    End Sub

    Private Sub btn_quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar.Click
        If dgv_opciones_favoritos.SelectedRows.Count > 0 Then
            If MsgBox("Desea eliminar esta opcion de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                dgv_opciones_favoritos.Rows.RemoveAt(dgv_opciones_favoritos.CurrentRow.Index)
            End If
        Else
            MsgBox("Seleccione una opcion")
        End If

    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        conn.Execute("DELETE FROM empleado_opciones WHERE id_empleado='" & global_id_empleado & "'")
        For x = 0 To tabla_opciones_favoritos.Rows.Count - 1
            conn.Execute("INSERT INTO empleado_opciones(id_empleado,posicion,id_opcion,opcion,extra)VALUES('" & global_id_empleado & "','" & dgv_opciones_favoritos.Item("no", x).Value & "','" & dgv_opciones_favoritos.Item("id_opcion", x).Value & "','" & dgv_opciones_favoritos.Item("opcion", x).Value & "','" & dgv_opciones_favoritos.Item("extra", x).Value & "')")
        Next
        frm_botones_terminal.cargar_botones_favoritos()
        MsgBox("La configuracion ha sido aplicada con exito", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub dgv_opciones_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_opciones.CellClick
        If dgv_opciones.Rows(dgv_opciones.CurrentRow.Index).Cells("id_opcion").Value = 39 Then
            lb_url.Visible = True
            tb_url.Visible = True
        Else
            lb_url.Visible = False
            tb_url.Visible = False
            tb_url.Text = ""
        End If
    End Sub


    Private Sub dgv_opciones_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_opciones.CellFormatting
        For x = 0 To dgv_opciones.Columns.Count - 1
            If dgv_opciones.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_opciones_favoritos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_opciones_favoritos.CellFormatting
        For x = 0 To dgv_opciones_favoritos.Columns.Count - 1
            If dgv_opciones_favoritos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub dgv_opciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_opciones.DoubleClick
        If dgv_opciones.SelectedRows.Count > 0 Then
            btn_agregar_Click(sender, e)
        End If
    End Sub

    Private Sub dgv_opciones_favoritos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_opciones_favoritos.DoubleClick
        If dgv_opciones_favoritos.SelectedRows.Count > 0 Then
            btn_quitar_Click(sender, e)
        End If
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class