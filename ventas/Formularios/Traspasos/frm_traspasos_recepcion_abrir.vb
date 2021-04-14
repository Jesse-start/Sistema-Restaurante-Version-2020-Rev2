Imports System.Math
Public Class frm_traspasos_recepcion_abrir
    Dim i As Integer
    Dim filtro_sql As String = ""
    Dim reg_por_pag As Integer = 40
    Dim inicial As Integer = 0
    Dim total_facturas As Integer = 0
    Dim total_paginas As Integer = 0
    Dim ejecutar As Boolean = False
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        lb_pagina_actual.ForeColor = Color.FromArgb(conf_colores(13))
        lblSucursales.ForeColor = Color.FromArgb(conf_colores(13))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        label3.ForeColor = Color.FromArgb(conf_colores(13))
        tb_resultados.ForeColor = Color.FromArgb(conf_colores(13))
        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub frm_compras_abrir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ''conn.close()
    End Sub
    Private Sub frm_compras_abrir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        'Conectar()

        iconos.Images.Add(ventas.My.Resources._50CENTAVOS)

        With cb_tipo
            .Items.Clear()
            .Items.Add("Iconos")
            .Items.Add("Detalles")
        End With
        cb_tipo.SelectedIndex = 1

        With lista_traspasos
            .FullRowSelect = True
            .Columns.Clear()

            .Columns.Add("Traspaso", 80)
            .Columns.Add("Origen", 150, HorizontalAlignment.Right)
            .Columns.Add("Fecha", 150, HorizontalAlignment.Right)
        End With


        tb_numero.Text = ""

        tb_fecha1.Value = "01/" & Date.Today.Month & " /" & Date.Today.Year
        tb_fecha2.Value = Date.Today

        ejecutar = True

        With cb_sucursales
            .Items.Clear()
            .Text = ""
            .Items.Add(New myItem(0, "Todas"))
            .SelectedIndex = 0
        End With

        With cb_sucursales
            rs.Open("SELECT id_sucursal,alias " & _
                                " FROM sucursal ORDER BY alias", conn)
            While Not rs.EOF
                .Items.Add(New myItem(rs.Fields("id_sucursal").Value, rs.Fields("alias").Value))
                rs.MoveNext()
            End While
            rs.Close()
        End With
    End Sub
    Private Sub cargar(Optional ByVal pagina As Integer = 1)

        btn_aceptar.Enabled = False

        tb_pagina.Text = pagina

        inicial = (pagina - 1) * reg_por_pag

        lista_traspasos.Items.Clear()
        filtro_sql = ""

        If Trim(tb_numero.Text) <> "" Then
            Try
                filtro_sql = filtro_sql & "AND id_traspaso_recep like '%" & CType(tb_numero.Text, Integer) & "%'"
                filtro_sql = filtro_sql & " AND year(fecha) = '" & Date.Today.Year & "'"
            Catch ex As Exception
            End Try
        Else
            filtro_sql = filtro_sql & " AND DATE(fecha) BETWEEN '" & Format(tb_fecha1.Value, "yy-MM-dd") & "' AND '" & Format(tb_fecha2.Value, "yy-MM-dd") & "'"
        End If


        If cb_sucursales.SelectedIndex > -1 Then
            If CType(cb_sucursales.SelectedItem, MyItem).Value > 0 Then
                filtro_sql = filtro_sql & " AND id_sucursal_origen= " & CType(cb_sucursales.SelectedItem, myItem).Value
            End If
        End If

        rs.Open("select distinct year(fecha) anio from traspaso_recep WHERE 1 " & filtro_sql & " ORDER by fecha DESC", conn)
        While Not rs.EOF
            lista_traspasos.Groups.Add(rs.Fields("anio").Value, rs.Fields("anio").Value)
            rs.MoveNext()
        End While
        rs.Close()

        rs.Open("SELECT count(*) as total_traspasos FROM traspaso_recep WHERE 1 " & filtro_sql, conn)
        total_facturas = rs.Fields("total_traspasos").Value
        rs.Close()

        total_paginas = Ceiling(total_facturas / reg_por_pag)

        If total_paginas > 1 Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

        rs.Open("SELECT id_traspaso_recep,sucursal_origen,fecha,YEAR(fecha) AS anio FROM traspaso_recep WHERE 1 " & filtro_sql & " ORDER BY id_traspaso_recep DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        i = 0
        While Not rs.EOF
            Dim str(2) As String

            str(0) = rs.Fields("id_traspaso_recep").Value
            str(1) = rs.Fields("sucursal_origen").Value
            str(2) = rs.Fields("fecha").Value



            lista_traspasos.Items.Add(New ListViewItem(str, 0))
            lista_traspasos.Items(i).Group = lista_traspasos.Groups(rs.Fields("anio").Value.ToString)
            lista_traspasos.Items(i).Tag = rs.Fields("id_traspaso_recep").Value
            rs.MoveNext()
            i = i + 1
        End While

        tb_resultados.Text = total_facturas & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()

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
        ' TextBox1.Text = "SELECT id_cotizacion, YEAR(fecha) anio,fecha FROM cotizacion WHERE 1 " & filtro_sql & " ORDER BY id_cotizacion DESC LIMIT " & inicial & "," & reg_por_pag
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub lista_factura_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lista_traspasos.DoubleClick
        btn_aceptar_Click(sender, e)
    End Sub

    Private Sub lista_factura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lista_traspasos.SelectedIndexChanged
        If lista_traspasos.SelectedItems.Count > 0 Then
            btn_aceptar.Enabled = True
        Else
            btn_aceptar.Enabled = False
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If lista_traspasos.SelectedItems.Count > 0 Then
            frm_traspasos_recepcion.cargar(lista_traspasos.SelectedItems.Item(0).Tag)
            Me.Close()
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
                Panel1.Enabled = False
            Else
                Panel1.Enabled = True
            End If
            cargar()
        End If
    End Sub
    Private Sub pb_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar(tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar(tb_pagina.Text)
        End If
    End Sub
    Private Sub tb_numero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_pagina_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub tb_pagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar(tb_pagina.Text)
            End If
        End If
    End Sub

    Private Sub pb_anterior_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pb_anterior.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub pb_anterior_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pb_anterior.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub pb_siguiente_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pb_siguiente.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub pb_siguiente_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pb_siguiente.BackgroundImage = ventas.My.Resources._50CENTAVOS
    End Sub

    Private Sub cb_tipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_tipo.SelectedIndexChanged
        If cb_tipo.SelectedIndex = 0 Then
            lista_traspasos.View = View.LargeIcon

        ElseIf cb_tipo.SelectedIndex = 1 Then
            lista_traspasos.View = View.Details
        End If
    End Sub

    Private Sub cb_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_sucursales.SelectedIndexChanged
        If ejecutar Then
            cargar()
        End If
    End Sub
End Class
