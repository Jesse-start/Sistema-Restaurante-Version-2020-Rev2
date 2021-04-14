Public Class frm_colaboradores2
    Private bDatos() As Byte
    Private id_colaborador As Integer = 0

    Private Sub frm_colaboradores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        global_frm_colaboradores = 0
    End Sub
    Private Sub frm_colaboradores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_colaboradores = 1
        configuracion_inicio()
        configuracion_listas()
        cargar_lista_colaboradores()
        rellenar_catalogo_combobox("id_perfil", "nombre", "perfil", cb_perfil)
    End Sub
    Private Sub cargar_lista_colaboradores()
        Dim i As Integer = 0
        rs.Open("SELECT e.id_empleado,CONCAT(pe.nombre,' ',pe.ap_paterno,' ',pe.ap_materno)AS nombre_empleado, p.nombre AS nombre_perfil FROM empleado e " & _
                "JOIN persona pe ON pe.id_persona=e.id_persona " & _
                "JOIN perfil_empleado pee ON pee.id_empleado=e.id_empleado " & _
                "JOIN perfil p ON p.id_perfil=pee.id_perfil	", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(1) As String
                str(0) = rs.Fields("nombre_empleado").Value
                str(1) = rs.Fields("nombre_perfil").Value
                lst_colaboradores.Items.Add(New ListViewItem(str, 0))
                lst_colaboradores.Items(i).Tag = rs.Fields("id_empleado").Value
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()
        aplicar_estilo()
    End Sub

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_unidad.Enabled = False

        tb_nombre.Text = ""
        gb_unidad.Enabled = False

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_unidad.Enabled = True

        tb_alias.Text = ""
        tb_nombre.Text = ""
        tb_apellidoP.Text = ""
        tb_apellidoM.Text = ""
        tb_emailF.Text = ""
        tb_rfcF.Text = ""
        tb_curp.Text = ""
        tb_tel_fijo.Text = ""
        tb_tel_cel.Text = ""
        tb_whatsapp.Text = ""
        tb_usuario.Text = ""
        tb_password.Text = ""
        tb_confirmar.Text = ""

        chb_domicilio.Checked = False
        tb_calle.Text = ""
        tb_num_ext.Text = ""
        tb_num_int.Text = ""
        tb_colonia.Text = ""
        tb_municipio.Text = ""
        tb_cp.Text = ""
        tb_poblacion.Text = ""
        tb_estado.Text = ""
        tb_pais.Text = ""
        panel_domicilio.Enabled = False
 
        gb_unidad.Enabled = True
    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_unidad.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_colaboradores
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Nompre", 220)
            .Columns.Add("Perfil", 130)
        End With

        For i = 0 To lst_colaboradores.Items.Count - 2 Step 2
            lst_colaboradores.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_colaboradores.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_colaborador(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        'guardar_unidad(id_unidad)
    End Sub
    Private Sub guardar_colaborador(ByVal id_colaborador As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        'If Trim(tb_clave.TextLength) = 0 Then
        'correcto = False
        ' mensaje &= "    Falta clave " & vbCrLf
        'End If
        '
        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre de la unidad " & vbCrLf
        End If
        ' If Trim(tb_nombre_corto.TextLength) = 0 Then
        'correcto = False
        ' mensaje &= "    Falta nombre corto " & vbCrLf
        ' End If

        If correcto = True Then

            If id_colaborador > 0 Then
                '  conn.Execute("UPDATE unidad SET clave='" & tb_clave.Text & "', nombre='" & tb_nombre.Text & "', nombre_corto='" & tb_nombre_corto.Text & "' WHERE id_unidad='" & id_unidad & "'")
                MsgBox("Unidad actualizada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                '  conn.Execute("INSERT INTO unidad(clave,nombre,nombre_corto)VALUES('" & tb_clave.Text & "','" & tb_nombre.Text & "','" & tb_nombre_corto.Text & "')")

                '  rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_colaborador = rs.Fields(0).Value
                rs.Close()
                MsgBox("Unidad insertarda correctamente", MsgBoxStyle.Information, "Aviso")
            End If

            cargar_colaborador(id_colaborador)


            ' cargar_catalogo_unidad()
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
    Private Sub aplicar_estilo()

        For i = 0 To lst_colaboradores.Items.Count - 2 Step 2
            lst_colaboradores.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_colaboradores.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_colaborador(ByVal id As Integer)
        Dim rs2 As New ADODB.Recordset
        id_colaborador = id

        If id_colaborador > 0 Then
            '=======================CARGAMOS COLABORADOR===========================
            rs.Open("SELECT pe.alias,pe.nombre,pe.ap_paterno,pe.ap_materno,pe.email,pe.rfc,e.curp,e.imagen,e.id_domicilio,p.id_perfil,pe.tel_fijo,pe.tel_cel,pe.whatsapp,u.usuario " & _
                    "FROM empleado e " & _
                    "JOIN persona pe ON pe.id_persona=e.id_persona " & _
                    "JOIN perfil_empleado pee ON pee.id_empleado=e.id_empleado " & _
                    "JOIN perfil p ON p.id_perfil=pee.id_perfil " & _
                    "JOIN usuario u ON u.id_empleado=e.id_empleado " & _
            "WHERE e.id_empleado='" & id_colaborador & "'", conn)

            If rs.RecordCount > 0 Then
                tb_alias.Text = rs.Fields("alias").Value
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_apellidoP.Text = rs.Fields("ap_paterno").Value
                tb_apellidoM.Text = rs.Fields("ap_materno").Value
                tb_emailF.Text = rs.Fields("email").Value
                tb_rfcF.Text = rs.Fields("rfc").Value
                tb_curp.Text = rs.Fields("curp").Value
                tb_tel_fijo.Text = rs.Fields("tel_fijo").Value
                tb_tel_cel.Text = rs.Fields("tel_cel").Value
                tb_whatsapp.Text = rs.Fields("whatsapp").Value
                tb_usuario.Text = rs.Fields("usuario").Value
                tb_password.Text = "****"
                tb_confirmar.Text = "****"
                seleccionar_catalogo(rs.Fields("id_perfil").Value, cb_perfil)

                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bDatos = CType(rs.Fields("imagen").Value, Byte())
                    pb_imagen.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
                Else

                    rs2.Open("SELECT imagen FROM configuracion", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    If Not rs2.EOF Then
                        bDatos = CType(rs2.Fields("imagen").Value, Byte())
                        pb_imagen.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
                    End If
                    rs2.Close()

                    '---obtenemos la imagen---------------
                    ofd_foto.Title = "Seleccionar imágen"
                    ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"

                    '--------------------------------------------
                End If
                If rs.Fields("id_domicilio").Value > 0 Then
                    chb_domicilio.Checked = True
                    panel_domicilio.Enabled = True

                    rs2.Open("SELECT * FROM domicilio WHERE id_domicilio='" & rs.Fields("id_domicilio").Value & "'", conn)
                    If rs2.RecordCount > 0 Then
                        tb_calle.Text = rs2.Fields("calle").Value
                        tb_num_ext.Text = rs2.Fields("num_ext").Value
                        tb_num_int.Text = rs2.Fields("num_int").Value
                        tb_colonia.Text = rs2.Fields("colonia").Value
                        tb_municipio.Text = rs2.Fields("municipio").Value
                        tb_cp.Text = rs2.Fields("cp").Value
                        tb_poblacion.Text = rs2.Fields("poblacion").Value
                        tb_estado.Text = rs2.Fields("estado").Value
                        tb_pais.Text = rs2.Fields("pais").Value
                    End If
                    rs2.Close()
                Else
                    chb_domicilio.Checked = False
                    panel_domicilio.Enabled = False
                End If
            End If
            rs.Close()

            rs.Open("SELECT hora_entrada,hora_salida,tolerancia FROM empleado_horario WHERE id_empleado=" & id_colaborador, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                dtp_hora_entrada.Value = rs.Fields("hora_entrada").Value
                dtp_hora_salida.Value = rs.Fields("hora_salida").Value
                tb_minutos_tolerancia.Value = rs.Fields("tolerancia").Value
            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
            gb_unidad.Enabled = False
        Else
            '  '=============================COLABORADOR NUEVO==================================
            configuracion_nuevo()
            rs.Open("SELECT imagen FROM configuracion", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                bDatos = CType(rs.Fields("imagen").Value, Byte())
                pb_imagen.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
            End If
            ofd_foto.Title = "Seleccionar imágen"
            ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"
            rs.Close()
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
    Private Sub lst_unidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_colaboradores.DoubleClick
        If lst_colaboradores.SelectedItems.Count > 0 Then
            cargar_colaborador(lst_colaboradores.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        '   eliminar_precio(id_unidad)
    End Sub
    Private Sub eliminar_precio(ByVal id As Integer)
        '   Try
        If MsgBox("Desea borrar esta unidad?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("DELETE FROM unidad WHERE id_unidad='" & id & "'")
            '  cargar_catalogo_unidad()
            configuracion_inicio()
        End If
        ' Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        '  End Try
    End Sub
    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub

    Private Sub lst_colaboradores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_colaboradores.SelectedIndexChanged

    End Sub

    Private Sub chb_domicilio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_domicilio.CheckedChanged
        If chb_domicilio.Checked = True Then
            panel_domicilio.Enabled = True
        Else
            panel_domicilio.Enabled = False
        End If
    End Sub
End Class