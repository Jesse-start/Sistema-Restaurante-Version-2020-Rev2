Public Class frm_sucursal
    Dim modo As String = ""
    Dim tablaTelefono As DataTable
    Private Linea As DataRow
    Private bandera_telefonos As Boolean
    Private currentid_sucursal As Integer = 0
    Private Sub frm_sucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        cargar_sucursales()
        cargar()
    End Sub
    Private Sub cargar(Optional ByVal id_sucursal As Integer = 0)
        conf_inicio()
        Telefono("Telefonos Sucursal", dg_telefonos, tablaTelefono)
        If id_sucursal <> 0 Then
            'Conectar()
            rs.Open("SELECT sucursal.*,domicilio.* FROM sucursal JOIN domicilio ON domicilio.id_domicilio=sucursal.id_domicilio  WHERE id_sucursal=" & id_sucursal, conn)
            If rs.RecordCount > 0 Then
                'cb_alias.DropDownStyle = ComboBoxStyle.Simple
                cb_alias.Text = rs.Fields("alias").Value
                tb_servidor.Text = rs.Fields("servidor").Value
                tb_servidor_usuario.Text = rs.Fields("servidor_usuario").Value
                tb_servidor_contraseña.Text = "****"
                tb_repetir_contraseña.Text = "****"
                tb_calle.Text = rs.Fields("calle").Value
                tb_colonia.Text = rs.Fields("colonia").Value
                tb_municipio.Text = rs.Fields("municipio").Value
                tb_cp.Text = rs.Fields("cp").Value
                tb_poblacion.Text = rs.Fields("poblacion").Value
                tb_estado.Text = rs.Fields("estado").Value
                tb_pais.Text = rs.Fields("pais").Value

            End If
            rs.Close()
            tablaTelefono.Clear()
            rs.Open("SELECT telefono.lada, telefono.numero FROM telefono JOIN sucursal_tel ON sucursal_tel.id_telefono=telefono.id_telefono WHERE sucursal_tel.id_sucursal=" & id_sucursal, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Linea = tablaTelefono.NewRow()
                    Linea(0) = 0
                    Linea(1) = rs.Fields("lada").Value
                    Linea(2) = rs.Fields("numero").Value
                    tablaTelefono.Rows.Add(Linea)
                    rs.MoveNext()
                End While
            End If

            rs.Close()
            'conn.close()
            'conn = Nothing
        Else

        End If

    End Sub
    Private Sub cargar_sucursales()
        cb_alias.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_sucursal,alias FROM sucursal ORDER by id_sucursal", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_alias.Items.Add(New myItem(rs.Fields("id_sucursal").Value, rs.Fields("alias").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

    End Sub
    Private Sub limpiar()

        tb_estado.Text = ""
        tb_pais.Text = ""
        tb_servidor.Text = ""
        tb_poblacion.Text = ""
        tb_servidor_contraseña.Text = ""
        tb_servidor_usuario.Text = ""
        tb_calle.Text = ""
        tb_colonia.Text = ""
        cb_alias.Text = ""
        tb_municipio.Text = ""
        tb_cp.Text = ""
        tb_repetir_contraseña.Text = ""
    End Sub
    Private Sub conf_inicio()
        pn_sucursal.Enabled = False
        cb_alias.DropDownStyle = ComboBoxStyle.DropDownList
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = False
        btn_guardar.Enabled = False
        btn_nuevo.Enabled = True
        limpiar()
    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        modo = "guardar"
        'cb_alias.Items.Clear()
        cb_alias.DropDownStyle = ComboBoxStyle.Simple
        limpiar()
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = True
        btn_guardar.Enabled = True
        pn_sucursal.Enabled = True
        gb_telefonos.Enabled = True
        btn_nuevo.Enabled = False
        tablaTelefono.Clear()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        conf_inicio()
    End Sub
    Private Sub tb_cp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cp.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_pais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_pais.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "ñÑ", "áéíóúäëïöü"})
    End Sub

    Private Sub tb_estado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_estado.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "ñÑ", " áéíóúäëïöü"})
    End Sub
    Private Sub tb_municipio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_municipio.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "ñÑ", " áéíóúäëïöü"})
    End Sub

    Private Sub Tb_colonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_colonia.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "ñÑ", " áéíóúäëïöü"})
    End Sub

    Private Sub tb_poblacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_poblacion.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"a", "ñÑ", "áéíóúäëïöü"})
    End Sub
    Private Sub tb_numInt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_numExt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        Dim id_domicilio As Integer
        Dim id_sucursal As Integer

        cadena = "Error en los siguientes campos:" & vbCrLf

        If cb_alias.Text = "" Then
            cadena = cadena & "  Alias" & vbCrLf
            bandera_correcto = False
        End If
        If tb_calle.Text = "" Then
            cadena = cadena & "  Calle" & vbCrLf
            bandera_correcto = False
        End If
        If tb_colonia.Text = "" Then
            cadena = cadena & "  Colonia" & vbCrLf
            bandera_correcto = False
        End If
        If tb_municipio.Text = "" Then
            cadena = cadena & "  Municipio" & vbCrLf
            bandera_correcto = False
        End If
        If tb_cp.Text = "" Then
            cadena = cadena & "  C.P." & vbCrLf
            bandera_correcto = False
        End If
        If tb_poblacion.Text = "" Then
            cadena = cadena & "  Poblacion" & vbCrLf
            bandera_correcto = False
        End If
        If tb_servidor.Text = "" Then
            cadena = cadena & "  Servidor" & vbCrLf
            bandera_correcto = False
        End If
        If tb_servidor_usuario.Text = "" Then
            cadena = cadena & "  Usuario de servidor" & vbCrLf
            bandera_correcto = False
        End If
        If tb_servidor_contraseña.Text = "" Then
            cadena = cadena & "  Usuario Contraseña" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            If modo = "guardar" Then
                '---guardamos como nueva sucursal----------
                'Conectar()
                conn.Execute("INSERT INTO domicilio(calle,colonia,municipio,cp,poblacion,estado,pais) VALUES ('" & tb_calle.Text & "','" & tb_colonia.Text & "', '" & tb_municipio.Text & "', '" & tb_cp.Text & "', '" & tb_poblacion.Text & "', '" & tb_estado.Text & "', '" & tb_pais.Text & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_domicilio = rs.Fields(0).Value()
                rs.Close()
                conn.Execute("INSERT INTO sucursal(id_domicilio,alias,servidor,servidor_usuario,servidor_password) VALUES ( '" & id_domicilio & "', '" & cb_alias.Text & "', '" & tb_servidor.Text & "', '" & tb_servidor_usuario.Text & "','" & tb_servidor_contraseña.Text & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_sucursal = rs.Fields(0).Value()
                rs.Close()
                If bandera_telefonos = True Then
                    For corrimiento = 0 To tablaTelefono.Rows.Count - 1
                        conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dg_telefonos.Item(corrimiento, 1) & "', '" & dg_telefonos.Item(corrimiento, 2) & "')", , -1)
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        conn.Execute("INSERT INTO sucursal_tel (id_sucursal,id_telefono) VALUES ('" & id_sucursal & "', '" & rs.Fields(0).Value & "')", , -1)
                        rs.Close()
                    Next
                End If
                'conn.close()
                'conn = Nothing
                'cargar(id_sucursal)
                MsgBox("Sucursal guardada correctamente")
                '------------------------------------------
            End If
        Else
            MsgBox(cadena)
        End If

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        gb_datos_telefono.Enabled = True
        gb_sucursal.Enabled = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim contador As Integer
        contador = tablaTelefono.Rows.Count
        While 0 < contador
            If dg_telefonos.IsSelected(contador - 1) = True Then
                tablaTelefono.Rows.Item(contador - 1).Delete()
                bandera_telefonos = True
            End If
            contador = contador - 1
        End While
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        If Tb_lada.Text = "" Then
            cadena = cadena & "  Lada" & vbCrLf
            bandera_correcto = False
        End If
        If tb_telefono.Text = "" Then
            cadena = cadena & "  Telefono" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            If Button7.Text = "Aceptar" Then
                Linea = tablaTelefono.NewRow()
                Linea(0) = 0
                Linea(1) = Tb_lada.Text
                Linea(2) = tb_telefono.Text
                tablaTelefono.Rows.Add(Linea)
            Else
                dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 1) = Tb_lada.Text
                dg_telefonos.Item(dg_telefonos.CurrentCell.RowNumber, 2) = tb_telefono.Text
            End If
            Button7.Text = "Aceptar"
            tb_telefono.Text = ""
            Tb_lada.Text = ""
            gb_datos_telefono.Enabled = False
            bandera_telefonos = True
            gb_sucursal.Enabled = True
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        tb_telefono.Text = ""
        Tb_lada.Text = ""
        gb_datos_telefono.Enabled = False
        gb_sucursal.Enabled = True
        Button7.Text = "Aceptar"
    End Sub
    Private Sub Tb_lada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Tb_lada.KeyPress
        e.Handled = txtNumerico(Tb_lada, e.KeyChar, True)
    End Sub

    Private Sub tb_telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_telefono.KeyPress
        e.Handled = txtNumerico(tb_telefono, e.KeyChar, True)
    End Sub

    Private Sub cb_alias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_alias.SelectedIndexChanged
        If cb_alias.SelectedIndex <> -1 Then
            currentid_sucursal = CType(cb_alias.SelectedItem, myItem).Value
            cargar(currentid_sucursal)
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
        End If
     
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        modo = "actualizar"
        modo = "editar"
        btn_nuevo.Enabled = False
        btn_cancelar.Enabled = True
        btn_guardar.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        cb_alias.DropDownStyle = ComboBoxStyle.Simple
        pn_sucursal.Enabled = True
        gb_telefonos.Enabled = True
    End Sub

    Private Sub tb_calle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_calle.TextChanged

    End Sub
End Class