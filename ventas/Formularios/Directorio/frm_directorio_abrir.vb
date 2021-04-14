Imports System.Math
Public Class frm_directorio_abrir
    Dim i As Integer

    Dim tipo_persona As Integer = 1

    Dim filtro_sql As String = ""

    Dim reg_por_pag As Integer = 40
    Dim reg_inicial As Integer = 0

    Dim total_resultados As Integer = 0
    Dim total_paginas As Integer = 0

    Dim ejecutar As Boolean = False

    'Private conn As ADODB.Connection
    'Private rs As ADODB.Recordset

    Private Sub frm_directorio_abrir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ''conn.close()
    End Sub

    Private Sub frm_directorio_abrir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'conn = conexion()
        'rs = conector()
        'Conectar()
        rs = New ADODB.Recordset

        iconos.Images.Add(ventas.My.Resources._50CENTAVOS)
        With cb_tipo
            .Items.Clear()
            .Items.Add("Iconos")
            .Items.Add("Detalles")
        End With

        cb_tipo.SelectedIndex = 1

        lista_cotizacion.FullRowSelect = True

        ejecutar = True

        tb_buscar.Text = "p"
        tb_buscar.Text = ""
    End Sub

    Private Sub cargar(Optional ByVal pagina As Integer = 1)

        btn_aceptar.Enabled = False
        tb_pagina.Text = pagina
        reg_inicial = (pagina - 1) * reg_por_pag
        lista_cotizacion.Items.Clear()
        filtro_sql = ""

        If rb_empleado.Checked Then

            tipo_persona = 1

            With lista_cotizacion
                .Columns.Clear()
                .Columns.Add("Nombre", 220)
                .Columns.Add("RFC", 130)
                .Columns.Add("Puesto", 150)
            End With

            If Trim(tb_buscar.Text) <> "" Then
                filtro_sql = filtro_sql & " AND (e.curp like '%" & Trim(tb_buscar.Text) & "%' OR p.nombre like '%" & Trim(tb_buscar.Text) & "%' OR p.ap_paterno like '%" & Trim(tb_buscar.Text) & "%' OR p.ap_materno like '%" & Trim(tb_buscar.Text) & "%' OR p.rfc like '%" & Trim(tb_buscar.Text) & "%')"
            End If

            rs.Open("SELECT COUNT(*) as total_resultados FROM persona p, empleado e, empleado_puesto ep WHERE p.id_persona = e.id_persona AND e.id_puesto=ep.id_puesto " & filtro_sql, conn)
            total_resultados = rs.Fields("total_resultados").Value
            rs.Close()

            total_paginas = Ceiling(total_resultados / reg_por_pag)

            If total_paginas > 1 Then
                Panel2.Visible = True
            Else
                Panel2.Visible = False
            End If

            rs.Open("SELECT e.id_empleado, TRIM(CONCAT(p.ap_paterno,' ',p.ap_materno,' ',p.nombre)) nombre, p.rfc, ep.nombre puesto FROM persona p, empleado e, empleado_puesto ep WHERE p.id_persona = e.id_persona AND e.id_puesto=ep.id_puesto " & filtro_sql & " ORDER by p.ap_paterno LIMIT " & reg_inicial & "," & reg_por_pag, conn)
            i = 0
            While Not rs.EOF

                Dim str(3) As String
                str(0) = rs.Fields("nombre").Value
                str(1) = rs.Fields("rfc").Value
                str(2) = rs.Fields("puesto").Value

                lista_cotizacion.Items.Add(New ListViewItem(str, 0))
                lista_cotizacion.Items(i).Tag = rs.Fields("id_empleado").Value
                rs.MoveNext()
                i = i + 1
            End While
            tb_resultados.Text = total_resultados & " resultado(s)"
            lb_pagina_actual.Text = "Mostrando del " & reg_inicial + 1 & " al " & rs.RecordCount + reg_inicial
            rs.Close()

        ElseIf rb_cliente.Checked Then

            If rb_moral.Checked = True Then

                tipo_persona = 2

                With lista_cotizacion
                    .Columns.Clear()
                    .Columns.Add("Alias", 220)
                    .Columns.Add("RFC", 130)
                End With

                If Trim(tb_buscar.Text) <> "" Then
                    filtro_sql = filtro_sql & " AND (e.alias like '%" & Trim(tb_buscar.Text) & "%' OR e.razon_social like '%" & Trim(tb_buscar.Text) & "%')"
                End If

                rs.Open("SELECT COUNT(*) as total_resultados FROM cliente c, empresa e WHERE e.id_empresa = c.id_empresa " & filtro_sql, conn)
                total_resultados = rs.Fields("total_resultados").Value
                rs.Close()

                total_paginas = Ceiling(total_resultados / reg_por_pag)

                If total_paginas > 1 Then
                    Panel2.Visible = True
                Else
                    Panel2.Visible = False
                End If

                rs.Open("SELECT c.id_cliente, e.alias,e.rfc FROM cliente c, empresa e WHERE e.id_empresa = c.id_empresa " & filtro_sql & " ORDER by e.alias LIMIT " & reg_inicial & "," & reg_por_pag, conn)
                i = 0
                While Not rs.EOF

                    Dim str(3) As String
                    str(0) = rs.Fields("alias").Value
                    str(1) = rs.Fields("rfc").Value
                    lista_cotizacion.Items.Add(New ListViewItem(str, 0))
                    lista_cotizacion.Items(i).Tag = rs.Fields("id_cliente").Value
                    rs.MoveNext()
                    i = i + 1
                End While
                tb_resultados.Text = total_resultados & " resultado(s)"
                lb_pagina_actual.Text = "Mostrando del " & reg_inicial + 1 & " al " & rs.RecordCount + reg_inicial
                rs.Close()


            ElseIf rb_fisica.Checked Then

                tipo_persona = 3

                With lista_cotizacion
                    .Columns.Clear()
                    .Columns.Add("ALIAS", 220)
                    .Columns.Add("RFC", 130)
                End With

                If Trim(tb_buscar.Text) <> "" Then
                    filtro_sql = filtro_sql & " AND (p.alias like '%" & Trim(tb_buscar.Text) & "%' OR p.nombre like '%" & Trim(tb_buscar.Text) & "%' OR p.ap_paterno like '%" & Trim(tb_buscar.Text) & "%' OR p.ap_materno like '%" & Trim(tb_buscar.Text) & "%' OR p.rfc like '%" & Trim(tb_buscar.Text) & "%')"
                End If

                rs.Open("SELECT COUNT(*) as total_resultados FROM persona p, cliente c WHERE p.id_persona = c.id_persona " & filtro_sql, conn)
                total_resultados = rs.Fields("total_resultados").Value
                rs.Close()

                total_paginas = Ceiling(total_resultados / reg_por_pag)

                If total_paginas > 1 Then
                    Panel2.Visible = True
                Else
                    Panel2.Visible = False
                End If

                rs.Open("SELECT c.id_cliente, p.alias alias, p.rfc FROM persona p, cliente c WHERE p.id_persona = c.id_persona " & filtro_sql & " ORDER by p.ap_paterno LIMIT " & reg_inicial & "," & reg_por_pag, conn)
                i = 0
                While Not rs.EOF

                    Dim str(2) As String
                    str(0) = rs.Fields("alias").Value
                    str(1) = rs.Fields("rfc").Value
                    lista_cotizacion.Items.Add(New ListViewItem(str, 0))
                    lista_cotizacion.Items(i).Tag = rs.Fields("id_cliente").Value
                    rs.MoveNext()
                    i = i + 1
                End While
                tb_resultados.Text = total_resultados & " resultado(s)"
                lb_pagina_actual.Text = "Mostrando del " & reg_inicial + 1 & " al " & rs.RecordCount + reg_inicial
                rs.Close()

            End If

        ElseIf rb_proveedor.Checked Then

            If rb_moral.Checked = True Then

                tipo_persona = 4

                With lista_cotizacion
                    .Columns.Clear()
                    .Columns.Add("Alias", 220)
                    .Columns.Add("RFC", 130)

                End With

                If Trim(tb_buscar.Text) <> "" Then
                    filtro_sql = filtro_sql & " AND (e.alias like '%" & Trim(tb_buscar.Text) & "%' OR e.razon_social like '%" & Trim(tb_buscar.Text) & "%')"
                End If

                rs.Open("SELECT COUNT(*) as total_resultados FROM proveedor pr, empresa e WHERE e.id_empresa = pr.id_empresa " & filtro_sql, conn)
                total_resultados = rs.Fields("total_resultados").Value
                rs.Close()

                total_paginas = Ceiling(total_resultados / reg_por_pag)

                If total_paginas > 1 Then
                    Panel2.Visible = True
                Else
                    Panel2.Visible = False
                End If

                rs.Open("SELECT pr.id_proveedor, e.alias,e.rfc FROM proveedor pr, empresa e WHERE e.id_empresa = pr.id_empresa " & filtro_sql & " ORDER by e.alias LIMIT " & reg_inicial & "," & reg_por_pag, conn)
                i = 0
                While Not rs.EOF

                    Dim str(3) As String
                    str(0) = rs.Fields("alias").Value
                    str(1) = rs.Fields("rfc").Value
                    lista_cotizacion.Items.Add(New ListViewItem(str, 0))
                    lista_cotizacion.Items(i).Tag = rs.Fields("id_proveedor").Value
                    rs.MoveNext()
                    i = i + 1
                End While
                tb_resultados.Text = total_resultados & " resultado(s)"
                lb_pagina_actual.Text = "Mostrando del " & reg_inicial + 1 & " al " & rs.RecordCount + reg_inicial
                rs.Close()


            ElseIf rb_fisica.Checked Then

                tipo_persona = 5

                With lista_cotizacion
                    .Columns.Clear()
                    .Columns.Add("Ali", 220)
                    .Columns.Add("RFC", 130)
                End With

                If Trim(tb_buscar.Text) <> "" Then
                    filtro_sql = filtro_sql & " AND (p.alias like '%" & Trim(tb_buscar.Text) & "%' OR p.nombre like '%" & Trim(tb_buscar.Text) & "%' OR p.ap_paterno like '%" & Trim(tb_buscar.Text) & "%' OR p.ap_materno like '%" & Trim(tb_buscar.Text) & "%' OR p.rfc like '%" & Trim(tb_buscar.Text) & "%')"
                End If

                rs.Open("SELECT COUNT(*) as total_resultados FROM persona p, proveedor pr WHERE p.id_persona = pr.id_persona " & filtro_sql, conn)
                total_resultados = rs.Fields("total_resultados").Value
                rs.Close()

                total_paginas = Ceiling(total_resultados / reg_por_pag)

                If total_paginas > 1 Then
                    Panel2.Visible = True
                Else
                    Panel2.Visible = False
                End If

                rs.Open("SELECT pr.id_proveedor, p.alias As nombre, p.rfc FROM persona p, proveedor pr WHERE p.id_persona = pr.id_persona " & filtro_sql & " ORDER by p.ap_paterno LIMIT " & reg_inicial & "," & reg_por_pag, conn)
                i = 0
                While Not rs.EOF

                    Dim str(2) As String
                    str(0) = rs.Fields("nombre").Value
                    str(1) = rs.Fields("rfc").Value
                    lista_cotizacion.Items.Add(New ListViewItem(str, 0))
                    lista_cotizacion.Items(i).Tag = rs.Fields("id_proveedor").Value
                    rs.MoveNext()
                    i = i + 1
                End While
                tb_resultados.Text = total_resultados & " resultado(s)"
                lb_pagina_actual.Text = "Mostrando del " & reg_inicial + 1 & " al " & rs.RecordCount + reg_inicial
                rs.Close()

            End If

        End If

        If pagina > 1 Then
            pb_anterior.Visible = True
        Else
            pb_anterior.Visible = False
        End If

        If pagina < total_paginas Then
            pb_siguiente.Visible = True
        Else
            pb_siguiente.Visible = False
        End If
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub lista_cotizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lista_cotizacion.DoubleClick
        btn_aceptar_Click(sender, e)
    End Sub

    Private Sub lista_cotizacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lista_cotizacion.SelectedIndexChanged
        If lista_cotizacion.SelectedItems.Count > 0 Then
            btn_aceptar.Enabled = True
        Else
            btn_aceptar.Enabled = False
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If lista_cotizacion.SelectedItems.Count > 0 Then
            If global_frm_directorio = 1 Then
                frm_directorio.cargar(lista_cotizacion.SelectedItems.Item(0).Tag, tipo_persona)
            Else
                frm_directorio.asignar_cliente = False
                frm_directorio.Show()
                frm_directorio.BringToFront()
                frm_directorio.cargar(lista_cotizacion.SelectedItems.Item(0).Tag, tipo_persona)
            End If
            Me.Close()
        End If
    End Sub

    Private Sub pb_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar(tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar(tb_pagina.Text)
        End If
    End Sub


    Private Sub tb_pagina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_pagina.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_pagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar(tb_pagina.Text)
            End If
        End If
    End Sub

    Private Sub pb_anterior_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb_anterior.MouseDown
        pb_anterior.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub pb_anterior_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb_anterior.MouseUp
        pb_anterior.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub pb_siguiente_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb_siguiente.MouseDown
        pb_siguiente.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub pb_siguiente_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb_siguiente.MouseUp
        pb_siguiente.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub cb_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_tipo.SelectedIndexChanged
        If cb_tipo.SelectedIndex = 0 Then

            lista_cotizacion.View = View.LargeIcon

        ElseIf cb_tipo.SelectedIndex = 1 Then
            lista_cotizacion.View = View.Details
        End If
    End Sub

    Private Sub tb_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_buscar.TextChanged
        If ejecutar Then
            cargar()
        End If
    End Sub

    Private Sub rb_cliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cliente.CheckedChanged
        If rb_cliente.Checked Then
            gb_tipo.Text = "Tipo de " & rb_cliente.Text
            gb_tipo.Enabled = True
            rb_moral.Checked = True
            If ejecutar Then
                cargar()
            End If
        End If
    End Sub

    Private Sub rb_proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_proveedor.CheckedChanged
        If rb_proveedor.Checked Then
            gb_tipo.Text = "Tipo de " & rb_proveedor.Text
            gb_tipo.Enabled = True
            rb_moral.Checked = True
            If ejecutar Then
                cargar()
            End If
        End If
    End Sub

    Private Sub rb_empleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_empleado.CheckedChanged
        If rb_empleado.Checked Then
            gb_tipo.Enabled = False
            rb_moral.Checked = False
            rb_fisica.Checked = False
            If ejecutar Then
                cargar()
            End If
        End If
    End Sub

    Private Sub rb_moral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_moral.CheckedChanged
        If ejecutar Then
            cargar()
        End If
    End Sub

    Private Sub rb_fisica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_fisica.CheckedChanged
        If ejecutar Then
            cargar()
        End If
    End Sub
End Class