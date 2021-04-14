Imports System.Math
Public Class frm_producto_recepcion_abrir
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
        lblProveedor.ForeColor = Color.FromArgb(conf_colores(13))
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
        cb_tipo.SelectedIndex = 0

        With lista_factura
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("factura", 150)
            .Columns.Add("Fecha", 100)
            .Columns.Add("Numero", 100, HorizontalAlignment.Right)
            .Columns.Add("Total", 140, HorizontalAlignment.Right)
        End With


        tb_numero.Text = ""

        tb_fecha1.Value = "01/" & Date.Today.Month & " /" & Date.Today.Year
        tb_fecha2.Value = Date.Today

        ejecutar = True

        With cb_proveedor
            .Items.Clear()
            .Text = ""
            .Items.Add(New myItem(0, "Todos"))
            .SelectedIndex = 0
        End With

        With cb_proveedor
            rs.Open("SELECT id_proveedor, CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE persona.alias END AS nombre" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa ORDER BY nombre", conn)
            While Not rs.EOF
                .Items.Add(New myItem(rs.Fields("id_proveedor").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
            rs.Close()
        End With
    End Sub
    Private Sub cargar(Optional ByVal pagina As Integer = 1)

        btn_aceptar.Enabled = False

        tb_pagina.Text = pagina

        inicial = (pagina - 1) * reg_por_pag

        lista_factura.Items.Clear()
        filtro_sql = ""

        If Trim(tb_numero.Text) <> "" Then
            Try
                filtro_sql = filtro_sql & "AND folio like '%" & CType(tb_numero.Text, Integer) & "%'"
                filtro_sql = filtro_sql & " AND year(fecha) = '" & Date.Today.Year & "'"
            Catch ex As Exception
            End Try
        Else
            filtro_sql = filtro_sql & " AND DATE(fecha) BETWEEN '" & Format(tb_fecha1.Value, "yy-MM-dd") & "' AND '" & Format(tb_fecha2.Value, "yy-MM-dd") & "'"
        End If


        If cb_proveedor.SelectedIndex > -1 Then
            If CType(cb_proveedor.SelectedItem, MyItem).Value > 0 Then
                filtro_sql = filtro_sql & " AND id_proveedor= " & CType(cb_proveedor.SelectedItem, MyItem).Value
            End If
        End If

        rs.Open("select distinct year(fecha) anio from factura_compra WHERE 1 " & filtro_sql & " ORDER by fecha DESC", conn)
        While Not rs.EOF
            lista_factura.Groups.Add(rs.Fields("anio").Value, rs.Fields("anio").Value)
            rs.MoveNext()
        End While
        rs.Close()

        rs.Open("SELECT count(*) as total_facturas FROM factura_compra WHERE 1 " & filtro_sql, conn)
        total_facturas = rs.Fields("total_facturas").Value
        rs.Close()

        total_paginas = Ceiling(total_facturas / reg_por_pag)

        If total_paginas > 1 Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

        rs.Open("SELECT id_factura_compra,numero,total,folio, YEAR(fecha) anio,fecha FROM factura_compra WHERE 1 " & filtro_sql & " ORDER BY id_factura_compra DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        i = 0
        While Not rs.EOF
            Dim str(3) As String

            str(0) = rs.Fields("folio").Value
            str(1) = rs.Fields("fecha").Value
            str(2) = rs.Fields("numero").Value
            str(3) = "$ " & FormatNumber(rs.Fields("total").Value, 2)

            lista_factura.Items.Add(New ListViewItem(str, 0))
            lista_factura.Items(i).Group = lista_factura.Groups(rs.Fields("anio").Value.ToString)
            lista_factura.Items(i).Tag = rs.Fields("id_factura_compra").Value
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

    Private Sub lista_factura_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lista_factura.DoubleClick
        btn_aceptar_Click(sender, e)
    End Sub

    Private Sub lista_factura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lista_factura.SelectedIndexChanged
        If lista_factura.SelectedItems.Count > 0 Then
            btn_aceptar.Enabled = True
        Else
            btn_aceptar.Enabled = False
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If lista_factura.SelectedItems.Count > 0 Then
            If global_frm_cotizacion_abrir = 1 Then
                If global_frm_cotizacion = 1 Then
                    frm_productos_recepcion.cargar(lista_factura.SelectedItems.Item(0).Tag)
                Else
                    frm_productos_recepcion.Show()
                    frm_productos_recepcion.BringToFront()
                    frm_productos_recepcion.cargar(lista_factura.SelectedItems.Item(0).Tag)
                End If
                'Else
                'If global_frm_factura = 1 Then
                'frm_factura.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
                ' Else
                '  frm_factura.Show()
                '  frm_factura.BringToFront()
                ' frm_factura.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
                'End If
            End If
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
            lista_factura.View = View.LargeIcon

        ElseIf cb_tipo.SelectedIndex = 1 Then
            lista_factura.View = View.Details
        End If
    End Sub

    Private Sub cb_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_proveedor.SelectedIndexChanged
        If ejecutar Then
            cargar()
        End If
    End Sub
End Class
