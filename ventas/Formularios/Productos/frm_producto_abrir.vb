Imports System.Math
Public Class frm_producto_abrir
    Dim i As Integer
    Dim filtro_sql As String = ""

    Dim reg_por_pag As Integer = 40
    Dim inicial As Integer = 0
    Dim total_productos As Integer = 0
    Dim total_paginas As Integer = 0

    Dim ejecutar As Boolean = False

    Private conn As ADODB.Connection
    Private rs As ADODB.Recordset

    Private Sub frm_producto_abrir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'conn.close()
    End Sub

    Private Sub frm_producto_abrir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn = conexion()
        rs = conector()

        imagenes.Images.Add(ventas.My.Resources._50CENTAVOS)
        With cb_tipo
            .Items.Clear()
            .Items.Add("Iconos")
            .Items.Add("Detalles")
        End With

        If global_frm_producto_abrir = 1 Then
            btn_aceptar.Text = "Agregar"
        ElseIf global_frm_producto_abrir = 2 Then
            btn_aceptar.Text = "Abrir"
        End If

        cb_tipo.SelectedIndex = 1

        With lista_cotizacion
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Codigo", 100)
            .Columns.Add("Nombre", 200)
            .Columns.Add("Unidad", 50)
            .Columns.Add("Descripcion", 140)
            '.Columns.Add("Numero", 100, HorizontalAlignment.Right)
            '.Columns.Add("Total", 140, HorizontalAlignment.Right)
        End With

        ejecutar = True

        tb_buscar.Text = "p"
        tb_buscar.Text = ""
    End Sub

    Private Sub cargar(Optional ByVal pagina As Integer = 1)

        btn_aceptar.Enabled = False

        tb_pagina.Text = pagina

        inicial = (pagina - 1) * reg_por_pag

        lista_cotizacion.Items.Clear()
        filtro_sql = ""

        If Trim(tb_buscar.Text) <> "" Then
            filtro_sql = filtro_sql & " AND p.nombre like '%" & Trim(tb_buscar.Text) & "%' OR p.descripcion like '%" & Trim(tb_buscar.Text) & "%' OR p.codigo like '%" & Trim(tb_buscar.Text) & "%'"
        End If

        rs.Open("SELECT count(*) as total_productos FROM producto p WHERE 1 " & filtro_sql, conn)
        total_productos = rs.Fields("total_productos").Value
        rs.Close()

        total_paginas = Ceiling(total_productos / reg_por_pag)

        If total_paginas > 1 Then
            Panel2.Visible = True
        Else
            Panel2.Visible = False
        End If

        rs.Open("SELECT p.id_producto,p.nombre,p.codigo, p.descripcion, u.nombre unidad FROM producto p, unidad u WHERE 1 AND p.id_unidad=u.id_unidad " & filtro_sql & " GROUP BY id_producto ORDER BY p.nombre DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        i = 0
        While Not rs.EOF

            Dim str(3) As String
            str(0) = rs.Fields("codigo").Value
            str(1) = rs.Fields("nombre").Value
            str(2) = rs.Fields("unidad").Value
            str(3) = rs.Fields("descripcion").Value

            lista_cotizacion.Items.Add(New ListViewItem(str, 0))
            lista_cotizacion.Items(i).Tag = rs.Fields("id_producto").Value
            rs.MoveNext()
            i = i + 1
        End While

        tb_resultados.Text = total_productos & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()

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
        TextBox1.Text = "SELECT * FROM producto p WHERE 1 " & filtro_sql & " ORDER BY p.nombre DESC LIMIT " & inicial & "," & reg_por_pag
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub lista_cotizacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lista_cotizacion.SelectedIndexChanged
        If lista_cotizacion.SelectedItems.Count > 0 Then
            btn_aceptar.Enabled = True
        Else
            btn_aceptar.Enabled = False
        End If
    End Sub

    Private Sub lista_cotizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lista_cotizacion.DoubleClick
        btn_aceptar_Click(sender, e)
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If lista_cotizacion.SelectedItems.Count > 0 Then
            If global_frm_producto_abrir = 1 Then
                If global_frm_cotizacion = 1 Then
                    frm_cotizacion.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                Else
                    frm_cotizacion.Show()
                    frm_cotizacion.BringToFront()
                    frm_cotizacion.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                End If
            ElseIf global_frm_producto_abrir = 2 Then

                If global_frm_producto = 1 Then
                    frm_producto.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
                    Me.Close()
                Else
                    frm_producto.Show()
                    frm_producto.BringToFront()
                    frm_producto.cargar(lista_cotizacion.SelectedItems.Item(0).Tag)
                    Me.Close()
                End If
            ElseIf global_frm_producto_abrir = 3 Then

                If global_frm_factura = 1 Then
                    frm_facturacion_electronica.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                    Me.Close()
                Else
                    frm_facturacion_electronica.Show()
                    frm_facturacion_electronica.BringToFront()
                    frm_facturacion_electronica.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                    Me.Close()
                End If
            ElseIf global_frm_producto_abrir = 4 Then

                If global_frm_nota_credito = 1 Then
                    frm_compras.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                    Me.Close()
                Else
                    frm_compras.Show()
                    frm_compras.BringToFront()
                    frm_compras.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                    Me.Close()
                End If


                'ElseIf global_frm_producto_abrir = 4 Then
                '   If global_frm_compras = 1 Then
                'frm_recepcion_productos.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                'Else
                '   frm_recepcion_productos.Show()
                '  frm_recepcion_productos.BringToFront()
                ' frm_recepcion_productos.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                'End If
                ' Me.Close()
                '--formulario llamado desde programacion de pedidos
            ElseIf global_frm_producto_abrir = 6 Then

                If global_frm_cotizacion = 1 Then
                    frm_pedido_programacion.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                Else
                    frm_pedido_programacion.Show()
                    frm_pedido_programacion.BringToFront()
                    frm_pedido_programacion.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                End If
                '----------------------------------------
                ' End If
            ElseIf global_frm_producto_abrir = 7 Then ' traspaso envio

                If global_frm_traspasos_envio = 1 Then
                    frm_traspasos_envio.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                Else
                    frm_traspasos_envio.Show()
                    frm_traspasos_envio.BringToFront()
                    frm_traspasos_envio.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                End If
                '----------------------------------------
            ElseIf global_frm_producto_abrir = 8 Then ' traspaso recepcion

                If global_frm_traspasos_recepcion = 1 Then
                    frm_traspasos_recepcion.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                Else
                    frm_traspasos_recepcion.Show()
                    frm_traspasos_recepcion.BringToFront()
                    frm_traspasos_recepcion.agregar_producto(lista_cotizacion.SelectedItems.Item(0).Tag)
                End If
                '----------------------------------------
            End If
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

    Private Sub tb_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ejecutar Then
            cargar()
        End If
    End Sub

    Private Sub tb_descripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_buscar.TextChanged
        If ejecutar Then
            cargar()
        End If
    End Sub

    Private Sub btn_cancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class