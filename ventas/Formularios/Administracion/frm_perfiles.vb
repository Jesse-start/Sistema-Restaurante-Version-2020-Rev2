Public Class frm_perfiles
    Dim ds As DataSet

    Dim tabla_perfiles As DataTable
    Dim tabla_campos As DataTable

    Dim estilo_perfiles As DataGridTableStyle
    Dim estilo_campos As DataGridTableStyle

    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_fila As DataRow

    Dim cadena As String()

    Dim perfil_actual As Integer = -1
    Dim campo_actual As Integer = -1

    Public Sub estilo(ByRef estilo As DataGridTableStyle, ByVal nombre As String)
        estilo = New DataGridTableStyle
        estilo.MappingName = nombre

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "id_perfil"
            .Width = 0
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "id_campo"
            .Width = 0
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "perfil"
            .HeaderText = "Nombre del Perfil"
            .Width = 184
            .TextBox.Enabled = False
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "campo"
            .HeaderText = "Nombre del Campo"
            .Width = 194
            .TextBox.Enabled = False
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "x"
            .HeaderText = "Posición X"
            .Width = 80
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        tabla_columna = New DataGridTextBoxColumn
        With tabla_columna
            .MappingName = "y"
            .HeaderText = "Posición Y"
            .Width = 80
        End With
        estilo.GridColumnStyles.Add(tabla_columna)

        estilo.HeaderFont = New Font("Tahoma", 8, FontStyle.Bold)
    End Sub


    Private Sub cargar(Optional ByVal posicion As Integer = -1)

        perfil_actual = posicion

        tb_nombre_perfil.Text = ""
        tb_alto.Text = ""
        tb_ancho.Text = ""

        gb_perfil.Enabled = True

        tb_nombre_campo.Text = ""
        tb_pos_x.Text = ""
        tb_pos_y.Text = ""

        btn_agregar_campo.Text = "Agregar"

        gb_campos.Visible = False

        cargar_perfiles()

        If perfil_actual > -1 Then

            tb_nombre_perfil.Text = ""
            tb_alto.Text = ""
            tb_ancho.Text = ""
            'Conectar()
            rs.Open("SELECT * from perfil_impresion WHERE id_perfil_impresion=" & perfil_actual, conn)
            If rs.RecordCount > 0 Then
                cb_documento.Text = rs.Fields("nombre_tipo_documento").Value
                tb_nombre_perfil.Text = rs.Fields("nombre_perfil").Value
                tb_alto.Text = rs.Fields("alto_pagina").Value
                tb_ancho.Text = rs.Fields("ancho_pagina").Value
                If rs.Fields("ajuste_x").Value = 0 Then
                    If rs.Fields("ajuste_y").Value = 0 Then
                        chb_ajuste.Checked = False
                        tb_ajuste_x.Text = ""
                        tb_ajuste_y.Text = ""
                    Else
                        chb_ajuste.Checked = True
                        tb_ajuste_x.Text = rs.Fields("ajuste_x").Value
                        tb_ajuste_y.Text = rs.Fields("ajuste_y").Value
                    End If
                Else
                    chb_ajuste.Checked = True
                    tb_ajuste_x.Text = rs.Fields("ajuste_x").Value
                    tb_ajuste_y.Text = rs.Fields("ajuste_y").Value
                End If
                If rs.Fields("max_lineas").Value = 0 Then
                    chb_max_lineas.Checked = False
                Else
                    chb_max_lineas.Checked = True
                    tb_max_productos.Text = rs.Fields("max_lineas").Value
                End If
            End If
            rs.Close()
            'conn.close()
            btn_agregar_perfil.Text = "Actualizar"
            cargar_campos(perfil_actual)
        Else
            btn_agregar_perfil.Text = "Agregar"
        End If
    End Sub

    Private Sub cargar_perfiles()
        dg_perfiles.TableStyles.Clear()
        perfiles = New ArrayList

        tabla_perfiles = New DataTable("perfiles")
        tabla_perfiles.Columns.Add(New DataColumn("id_perfil", GetType(String)))
        tabla_perfiles.Columns.Add(New DataColumn("perfil", GetType(String)))

        '---cargamos los perfiles
        'Conectar()
        rs.Open("SELECT * FROM perfil_impresion", conn)
        If rs.RecordCount > 0 Then
            lb_quitar_perfil.Visible = True
            btn_quitar_perfil.Visible = True
            While Not rs.EOF
                tabla_fila = tabla_perfiles.NewRow()
                tabla_fila(0) = rs.Fields("id_perfil_impresion").Value
                tabla_fila(1) = rs.Fields("nombre_perfil").Value
                tabla_perfiles.Rows.Add(tabla_fila)
                rs.MoveNext()
            End While
            ds = New DataSet
            ds.Tables.Add(tabla_perfiles)
            dg_perfiles.TableStyles.Add(estilo_perfiles)
            dg_perfiles.SetDataBinding(ds, "perfiles")

        Else
            dg_perfiles.DataSource = Nothing
            lb_quitar_perfil.Visible = False
            btn_quitar_perfil.Visible = False
        End If
        rs.Close()

        'conn.close()
        'conn = Nothing

        '-------------------
    End Sub
    Private Sub cargar_campos(ByVal id_perfil As String)
        gb_campos.Visible = True
        dg_campos.TableStyles.Clear()

        campos = New ArrayList

        tabla_campos = New DataTable("campos")
        tabla_campos.Columns.Add(New DataColumn("id_campo", GetType(Integer)))
        tabla_campos.Columns.Add(New DataColumn("campo", GetType(String)))
        tabla_campos.Columns.Add(New DataColumn("x", GetType(Decimal)))
        tabla_campos.Columns.Add(New DataColumn("y", GetType(Decimal)))


        '---leemos los campos
        'Conectar()
        rs.Open("SELECT * FROM perfil_impresion_campos WHERE id_perfil_impresion=" & id_perfil, conn)
        If rs.RecordCount > 0 Then
            lb_quitar_campo.Visible = True
            btn_quitar_campo.Visible = True
            gb_perfil.Enabled = True
            While Not rs.EOF
                tabla_fila = tabla_campos.NewRow()
                tabla_fila(0) = rs.Fields("id_perfil_impresion_campos").Value
                tabla_fila(1) = rs.Fields("nombre").Value
                tabla_fila(2) = rs.Fields("x").Value
                tabla_fila(3) = rs.Fields("y").Value
                tabla_campos.Rows.Add(tabla_fila)
                rs.MoveNext()
            End While
            ds = New DataSet
            ds.Tables.Add(tabla_campos)
            dg_campos.TableStyles.Add(estilo_campos)
            dg_campos.SetDataBinding(ds, "campos")
        Else
            dg_campos.DataSource = Nothing
            lb_quitar_campo.Visible = False
            btn_quitar_campo.Visible = False
        End If
        rs.Close()
        'conn.close()

        '--------------------

    End Sub

    Private Sub frm_perfiles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.MdiParent = frm_principal
        estilo(estilo_perfiles, "perfiles")
        estilo(estilo_campos, "campos")
        cargar()
        cb_documento.Items.Add(New myItem(1, "Factura"))
        cb_documento.Text = "Factura"
    End Sub

    Private Sub m_cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_cerrar.Click
        Me.Close()
    End Sub

    Private Sub dg_perfiles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_perfiles.DoubleClick
        If dg_perfiles.CurrentRowIndex >= 0 Then
            cargar(dg_perfiles.Item(dg_perfiles.CurrentCell.RowNumber, 0))
        End If
    End Sub

    Private Sub m_nuevo_perfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_nuevo_perfil.Click
        cargar()
    End Sub
    Private Sub btn_quitar_perfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitar_perfil.Click
        If dg_perfiles.CurrentRowIndex >= 0 Then
            If MsgBox("Deseas eliminar el Perfil Seleccionado? " & vbCrLf & "Además se borrarán sus Campos", MsgBoxStyle.OkCancel, "Eliminacion de Perfil") = MsgBoxResult.Ok Then
                'Conectar()
                If campos.Count > 0 Then
                    conn.Execute("DELETE FROM perfil_impresion_campos WHERE id_perfil_impresion=" & dg_perfiles.Item(dg_perfiles.CurrentCell.RowNumber, 0))
                End If
                conn.Execute("DELETE FROM perfil_impresion WHERE id_perfil_impresion=" & dg_perfiles.Item(dg_perfiles.CurrentCell.RowNumber, 0))
                'conn.close()
                'conn = Nothing
                cargar()
            End If
        End If
    End Sub


    Private Sub btn_agregar_perfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_perfil.Click
        Dim b As Boolean = False
        Dim mensaje As String = ""

        If Trim(tb_nombre_perfil.Text) = "" Then
            mensaje = mensaje & "   *   Escribe el Nombre del Perfil" & vbCrLf
            b = True
        End If
        If Trim(tb_alto.Text) = "" Then
            mensaje = mensaje & "   *   Alto de la página" & vbCrLf
            b = True
        Else
            If CDec(tb_alto.Text) <= 0 Then
                mensaje = mensaje & "   *   El alto debe ser mayor a 0" & vbCrLf
                b = True
            End If
        End If
        If Trim(tb_ancho.Text) = "" Then
            mensaje = mensaje & "   *   Ancho de la página" & vbCrLf
            b = True
        Else
            If CDec(tb_ancho.Text) <= 0 Then
                mensaje = mensaje & "   *   El ancho debe ser mayor a 0" & vbCrLf
                b = True
            End If
        End If

        If chb_ajuste.Checked = True Then
            If Trim(tb_ajuste_x.TextLength) = 0 Then
                mensaje = mensaje & "   *   Ajuste de margen izquierdo" & vbCrLf
                b = True
            End If
            If Trim(tb_ajuste_y.TextLength) = 0 Then
                mensaje = mensaje & "   *   Ajuste de margen superior" & vbCrLf
                b = True
            End If
        End If
        If chb_max_lineas.Checked = True Then
            If Trim(tb_max_productos.TextLength) = 0 Then
                mensaje = mensaje & "   *   Numero maximo de productos" & vbCrLf
                b = True
            End If
        End If
        If b Then
            mensaje = "Revise los siguientes puntos:" & vbCrLf & vbCrLf & mensaje
            MsgBox(mensaje, MsgBoxStyle.Exclamation, "Información Requerida")
        Else
            Dim ajuste_x As Decimal = 0
            Dim ajuste_y As Decimal = 0
            Dim max_productos As Integer = 0

            If chb_ajuste.Checked = True Then
                ajuste_x = CDec(tb_ajuste_x.Text)
                ajuste_y = CDec(tb_ajuste_y.Text)
            End If
            If chb_max_lineas.Checked = True Then
                max_productos = tb_max_productos.Text
            End If

            If perfil_actual > -1 Then
                Dim lastinsert As Integer = 0
                'Conectar()
                conn.Execute("UPDATE perfil_impresion SET nombre_tipo_documento='" & cb_documento.Text & "',nombre_perfil='" & tb_nombre_perfil.Text & "',alto_pagina='" & tb_alto.Text & "',ancho_pagina='" & tb_ancho.Text & "',ajuste_x='" & ajuste_x & "',ajuste_y='" & ajuste_y & "',max_lineas='" & max_productos & "' WHERE id_perfil_impresion='" & perfil_actual & "'")
                'conn.close()
                cargar(perfil_actual)
            Else
                '---AGREGAMOS PERFIL

                'Conectar()
                conn.Execute("INSERT INTO perfil_impresion(id_tipo_documento,nombre_tipo_documento,nombre_perfil,alto_pagina,ancho_pagina,ajuste_x,ajuste_y,max_lineas) VALUES (" & CType(cb_documento.SelectedItem, myItem).Value & ",'" & cb_documento.Text & "','" & tb_nombre_perfil.Text & "','" & tb_alto.Text & "','" & tb_ancho.Text & "','" & ajuste_x & "','" & ajuste_y & "','" & max_productos & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                perfil_actual = rs.Fields(0).Value
                rs.Close()
                'conn.close()
                cargar(perfil_actual)
            End If
        End If
    End Sub
    Private Sub tb_alto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_alto.KeyPress
        e.Handled = txtNumerico(tb_alto, e.KeyChar, True)
    End Sub
    Private Sub tb_ancho_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_ancho.KeyPress
        e.Handled = txtNumerico(tb_ancho, e.KeyChar, True)
    End Sub

    Private Sub btn_agregar_campo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_campo.Click
        Dim b As Boolean = False
        Dim mensaje As String = ""
        If tb_campos.SelectedIndex = -1 Then
            mensaje = mensaje & "   *   Seleccione el campo" & vbCrLf
            b = True
        End If
        If Trim(tb_pos_x.Text) = "" Then
            mensaje = mensaje & "   *   Posición hacia la derecha" & vbCrLf
            b = True
        ElseIf CDec(tb_pos_x.Text) <= 0 Then
            mensaje = mensaje & "   *   La posicion en X debe ser mayor a 0" & vbCrLf
            b = True
        ElseIf CDec(tb_pos_x.Text) >= CDec(tb_ancho.Text) Then
            mensaje = mensaje & "   *   La posicion en X debe ser menor al Ancho de la página" & vbCrLf
            b = True
        End If


        If Trim(tb_pos_y.Text) = "" Then
            mensaje = mensaje & "   *   Posición hacia abajo" & vbCrLf
            b = True
        ElseIf CDec(tb_pos_y.Text) <= 0 Then
            mensaje = mensaje & "   *   La posicion en Y debe ser mayor a 0" & vbCrLf
            b = True
        ElseIf CDec(tb_pos_y.Text) >= CDec(tb_alto.Text) Then
            mensaje = mensaje & "   *   La posicion en Y debe ser menor al Alto de la página" & vbCrLf
            b = True
        End If

        If b Then
            mensaje = "Revise los siguientes puntos:" & vbCrLf & vbCrLf & mensaje
            MsgBox(mensaje, MsgBoxStyle.Exclamation, "Información Requerida")
        Else
            '---agregamos campos a base de datos
            'Conectar()
            conn.Execute("INSERT INTO perfil_impresion_campos(id_perfil_impresion,id_campo_documento,nombre,x,y) VALUES(" & perfil_actual & "," & CType(tb_campos.SelectedItem, myItem).Value & ",'" & tb_campos.Text & "','" & tb_pos_x.Text & "', '" & tb_pos_y.Text & "')")
            'conn.close()
            '-----------------------------------
            cargar(perfil_actual)
        End If

    End Sub

    Private Sub btn_quitar_campo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_quitar_campo.Click
        If dg_campos.CurrentRowIndex >= 0 Then

            If MsgBox("Deseas eliminar el Campo seleccionado?", MsgBoxStyle.OkCancel, "Eliminacion de Campos") = MsgBoxResult.Ok Then
                'Conectar()
                conn.Execute("DELETE FROM perfil_impresion_campos WHERE id_perfil_impresion_campos=" & dg_campos.Item(dg_campos.CurrentCell.RowNumber, 1))
                'conn.close()
                'conn = Nothing
                cargar(perfil_actual)
            End If

        End If
    End Sub

    Private Sub cb_documento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_documento.SelectedIndexChanged
        If cb_documento.SelectedIndex <> -1 Then
            llenar_campos_documento(CType(cb_documento.SelectedItem, myItem).Value)
        End If
    End Sub
    Private Sub llenar_campos_documento(ByVal id_tipo_documento As Integer)
        If id_tipo_documento = 1 Then '--factura
            'llenamos de campos
            tb_campos.Items.Add(New myItem(0, "DIA (FECHA)"))
            tb_campos.Items.Add(New myItem(1, "MES (FECHA)"))
            tb_campos.Items.Add(New myItem(2, "AÑO (FECHA)"))
            tb_campos.Items.Add(New myItem(3, "NOMBRE (CLIENTE)"))
            tb_campos.Items.Add(New myItem(4, "DIRECCION (CLIENTE)"))
            tb_campos.Items.Add(New myItem(5, "CIUDAD (CLIENTE)"))
            tb_campos.Items.Add(New myItem(6, "RFC (CLIENTE)"))
            tb_campos.Items.Add(New myItem(7, "SUBTOTAL"))
            tb_campos.Items.Add(New myItem(8, "TOTAL IVA"))
            tb_campos.Items.Add(New myItem(9, "OTROS IMPUESTOS"))
            tb_campos.Items.Add(New myItem(10, "TOTAL"))
            tb_campos.Items.Add(New myItem(11, "TOTAL CON LETRA"))

            tb_campos.Items.Add(New myItem(12, "CANTIDAD (PRODUCTO)"))
            tb_campos.Items.Add(New myItem(13, "DESCRIPCION (PRODUCTO)"))
            tb_campos.Items.Add(New myItem(14, "UNIDAD (PRODUCTO)"))
            tb_campos.Items.Add(New myItem(15, "PRECIO UNIT. (PRODUCTO)"))
            tb_campos.Items.Add(New myItem(16, "IMPORTE (PRODUCTO)"))
        End If
    End Sub

    Private Sub dg_perfiles_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_perfiles.Navigate

    End Sub

    Private Sub chb_ajuste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_ajuste.CheckedChanged
        If chb_ajuste.Checked = True Then
            tb_ajuste_x.Enabled = True
            tb_ajuste_y.Enabled = True
        Else
            tb_ajuste_x.Enabled = False
            tb_ajuste_y.Enabled = False
        End If
    End Sub

    Private Sub chb_max_lineas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_max_lineas.CheckedChanged
        If chb_max_lineas.Checked = True Then
            tb_max_productos.Enabled = True
        Else
            tb_max_productos.Enabled = False
            tb_max_productos.Text = ""
        End If
    End Sub

   
End Class
