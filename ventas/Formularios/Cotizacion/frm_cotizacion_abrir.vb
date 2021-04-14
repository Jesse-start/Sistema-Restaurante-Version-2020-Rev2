Imports System.Math
Public Class frm_cotizacion_abrir
    Dim i As Integer
    Dim filtro_sql As String = ""

    Dim reg_por_pag As Integer = 40
    Dim inicial As Integer = 0

    Dim total_cotizaciones As Integer = 0

    Dim total_paginas As Integer = 0

    Dim ejecutar As Boolean = False
    Private Sub frm_cotizacion_abrir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        iconos.Images.Add(ventas.My.Resources._50CENTAVOS)
        tb_anio.Enabled = False

        With cb_tipo
            .Items.Clear()
            .Items.Add("Iconos")
            .Items.Add("Detalles")
        End With
        cb_tipo.SelectedIndex = 0

        With lista_cotizacion
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Cotizacion", 150)
            .Columns.Add("Fecha", 100)
            .Columns.Add("Numero", 100, HorizontalAlignment.Right)
            .Columns.Add("Total", 140, HorizontalAlignment.Right)
        End With

        tb_numero.Text = ""
        tb_anio.Maximum = Date.Today.Year
        tb_anio.Value = Date.Today.Year

        tb_fecha1.Value = "01/" & Date.Today.Month & " /" & Date.Today.Year
        tb_fecha2.Value = Date.Today

        ejecutar = True

        With cb_cliente
            .Items.Clear()
            .Text = ""
            .Items.Add(New myItem(0, "Todos"))
            .SelectedIndex = 0
        End With
        'Conectar()
        With cb_cliente
            rs.Open("SELECT c.id_cliente, trim(Concat(p.nombre,' ',p.ap_paterno,' ',p.ap_materno)) as nombre from persona p JOIN cliente c ON c.id_persona=p.id_persona ORDER BY p.nombre", conn)
            While Not rs.EOF
                .Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
            rs.Close()
        End With
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub cargar(Optional ByVal pagina As Integer = 1)

        btn_aceptar.Enabled = False

        tb_pagina.Text = pagina

        inicial = (pagina - 1) * reg_por_pag

        lista_cotizacion.Items.Clear()
        filtro_sql = ""

        If Trim(tb_numero.Text) <> "" Then
            Try
                filtro_sql = filtro_sql & "AND numero like '%" & CType(tb_numero.Text, Integer) & "%'"
                filtro_sql = filtro_sql & " AND year(fecha) = '" & tb_anio.Value & "'"
            Catch ex As Exception
            End Try
        Else
            filtro_sql = filtro_sql & " AND fecha BETWEEN '" & Format(tb_fecha1.Value, "yy-MM-dd") & "' AND '" & Format(tb_fecha2.Value, "yy-MM-dd") & "'"
        End If
        If cb_cliente.SelectedIndex > -1 Then
            If CType(cb_cliente.SelectedItem, myItem).Value > 0 Then
                filtro_sql = filtro_sql & " AND id_cliente = " & CType(cb_cliente.SelectedItem, myItem).Value
            End If
        End If
        'Conectar()
        rs.Open("select distinct year(fecha) anio from cotizacion WHERE 1 " & filtro_sql & " ORDER by fecha DESC", conn)
        While Not rs.EOF
            lista_cotizacion.Groups.Add(rs.Fields("anio").Value, rs.Fields("anio").Value)
            rs.MoveNext()
        End While
        rs.Close()

        rs.Open("SELECT count(*) as total_cotizaciones FROM cotizacion WHERE 1 " & filtro_sql, conn)
        total_cotizaciones = rs.Fields("total_cotizaciones").Value
        rs.Close()

        total_paginas = Ceiling(total_cotizaciones / reg_por_pag)

        If total_paginas > 1 Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

        rs.Open("SELECT id_cotizacion,numero,total, YEAR(fecha) anio,fecha FROM cotizacion WHERE 1 " & filtro_sql & " ORDER BY id_cotizacion DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        i = 0
        While Not rs.EOF
            Dim str(3) As String

            str(0) = "CT" & rs.Fields("anio").Value & "-" & vbCrLf & Format(CInt(rs.Fields("numero").Value), "0000")
            str(1) = rs.Fields("fecha").Value
            str(2) = rs.Fields("numero").Value
            str(3) = "$ " & FormatNumber(rs.Fields("total").Value, 2)

            lista_cotizacion.Items.Add(New ListViewItem(str, 0))
            lista_cotizacion.Items(i).Group = lista_cotizacion.Groups(rs.Fields("anio").Value.ToString)
            lista_cotizacion.Items(i).Tag = rs.Fields("id_cotizacion").Value
            rs.MoveNext()
            i = i + 1
        End While

        tb_resultados.Text = total_cotizaciones & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()
        'conn.close()
        'conn = Nothing
        ' lb_pagina.Text = "Pagina " & pagina & " de " & total_paginas


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
        TextBox1.Text = "SELECT id_cotizacion, YEAR(fecha) anio,fecha FROM cotizacion WHERE 1 " & filtro_sql & " ORDER BY id_cotizacion DESC LIMIT " & inicial & "," & reg_por_pag
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub lista_cotizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lista_cotizacion.DoubleClick
        frm_cotizacion.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
        Me.Close()
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
            If global_frm_cotizacion = 1 Then
                frm_cotizacion.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
            Else
                frm_cotizacion.Show()
                frm_cotizacion.BringToFront()
                frm_cotizacion.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
            End If
            Me.Close()
        End If
    End Sub
    Private Sub cb_cliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cliente.SelectedIndexChanged
        If ejecutar Then
            cargar()
        End If
    End Sub
    Private Sub tb_fecha1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_fecha1.ValueChanged
        If ejecutar Then
            cargar()
        End If
    End Sub
    Private Sub tb_fecha2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_fecha2.ValueChanged
        If ejecutar Then
            cargar()
        End If
    End Sub
    Private Sub tb_numero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_numero.TextChanged
        If ejecutar Then
            If Trim(tb_numero.Text) <> "" Then
                tb_anio.Enabled = True
                Panel1.Enabled = False
            Else
                tb_anio.Enabled = False
                Panel1.Enabled = True
            End If
            cargar()
        End If
    End Sub
    Private Sub tb_anio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_anio.ValueChanged
        If ejecutar Then
            cargar()
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
    Private Sub tb_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_numero.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
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
End Class