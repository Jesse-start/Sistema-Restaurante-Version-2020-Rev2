Public Class frm_cfg_descuentos
    Private Sub cargar_categorias()
        cb_categoria.Items.Clear()
        cb_categoria.Text = ""
        'Conectar()
        rs.Open("SELECT id_categoria,nombre FROM categoria WHERE id_categoria NOT IN(SELECT id_categoria FROM cfg_descuento_cat WHERE id_cfg_descuento=1) ORDER BY id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_categoria.Items.Add(New myItem(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub cargar_lista_cat()
        'Conectar()
        rs.Open("SELECT * FROM cfg_descuento WHERE id_cfg_descuento=1", conn)
        If rs.RecordCount > 0 Then
            dtp_fecha_inicio.Value = rs.Fields("fecha_inicio").Value
            dtp_fecha_termino.Value = rs.Fields("fecha_termino").Value
            tb_descuento.Text = rs.Fields("porcentaje").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

        lstv_categorias.Items.Clear()
        'Conectar()
        rs.Open("SELECT cfg_descuento_cat.id_categoria,categoria.nombre FROM cfg_descuento_cat JOIN categoria ON categoria.id_categoria=cfg_descuento_cat.id_categoria WHERE cfg_descuento_cat.id_cfg_descuento=1", conn)
        If rs.RecordCount > 0 Then
            Dim i As Integer = 0
            While Not rs.EOF
                lstv_categorias.Items.Add(New myItem(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub frm_cfg_descuentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        cargar_lista_cat()
        cargar_categorias()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim correcto As Boolean = True
        Dim cadena As String = "Se encontraron los siguientes errores" & vbCrLf

        If ((CType(dtp_fecha_termino.Text, DateTime) - CType(dtp_fecha_inicio.Text, DateTime)).TotalDays.ToString < 0) Then
            correcto = False
            cadena = cadena & "   *  La Fecha de Terminación debe ser posterior o igual a la de Inicio" & vbCrLf
        End If
        If correcto Then
            If MsgBox("Confirme que desea aplicar los cambios realizados", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                conn.Execute("UPDATE cfg_descuento SET porcentaje='" & tb_descuento.Text & "',fecha_inicio='" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "',fecha_termino='" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "'")
                conn.Execute("TRUNCATE TABLE cfg_descuento_cat")
                For x = 0 To lstv_categorias.Items.Count - 1
                    conn.Execute("INSERT INTO cfg_descuento_cat(id_cfg_descuento,id_categoria) VALUES(1," & CType(lstv_categorias.Items(x), myItem).Value & ")")
                Next
                'conn.close()
                'conn = Nothing
                frm_cfg_descuentos_Load(sender, e)
                MsgBox("Los cambios han sido guardado correctamente", MsgBoxStyle.Information, "Correcto")
            End If
        Else
            MsgBox(cadena, MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If cb_categoria.SelectedIndex <> -1 Then
            'Conectar()
            conn.Execute("INSERT INTO cfg_descuento_cat(id_cfg_descuento,id_categoria) VALUES(1," & CType(cb_categoria.SelectedItem, myItem).Value & ")")
            'conn.close()
            'conn = Nothing
            cargar_categorias()
            cargar_lista_cat()
            MsgBox("Los cambios han sido guardado correctamente", MsgBoxStyle.Information, "Correcto")
        Else
            MsgBox("Seleccione una categoria", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub

    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click

        If lstv_categorias.SelectedItems.Count > 0 Then
            'Conectar()
            conn.Execute("DELETE FROM cfg_descuento_cat WHERE id_cfg_descuento=1 AND id_categoria=" & CType(lstv_categorias.SelectedItem, myItem).Value)
            'conn.close()
            'conn = Nothing
            cargar_categorias()
            cargar_lista_cat()
            MsgBox("Los cambios han sido guardado correctamente", MsgBoxStyle.Information, "Correcto")
        Else
            MsgBox("Seleccione una categoria de la lista", MsgBoxStyle.Exclamation, "Error")
        End If


    End Sub
End Class