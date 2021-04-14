Imports System.Math
Public Class frm_producto_busqueda
    Dim current_catalogo_precio As Integer
    Public cargado As Boolean = False
    Public _modo As Integer = 0 '0--ventas 1.- recepcion_producto 2.-traspaso_recepcion, 3.-traspaso_envio, 4. directorio+, 5 punto_venta

    Dim reg_por_pag As Integer = 12
    Dim inicial As Integer = 0
    Dim total_productos As Integer = 0
    Dim total_paginas As Integer = 0
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))
        Button2.BackColor = Color.FromArgb(conf_colores(8))
        Button2.ForeColor = Color.FromArgb(conf_colores(9))
        Button3.BackColor = Color.FromArgb(conf_colores(8))
        Button3.ForeColor = Color.FromArgb(conf_colores(9))
        Button4.BackColor = Color.FromArgb(conf_colores(8))
        Button4.ForeColor = Color.FromArgb(conf_colores(9))
        Button5.BackColor = Color.FromArgb(conf_colores(8))
        Button5.ForeColor = Color.FromArgb(conf_colores(9))
        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
        Button7.BackColor = Color.FromArgb(conf_colores(8))
        Button7.ForeColor = Color.FromArgb(conf_colores(9))
        Button8.BackColor = Color.FromArgb(conf_colores(8))
        Button8.ForeColor = Color.FromArgb(conf_colores(9))
        Button9.BackColor = Color.FromArgb(conf_colores(8))
        Button9.ForeColor = Color.FromArgb(conf_colores(9))
        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))
        Button11.BackColor = Color.FromArgb(conf_colores(8))
        Button11.ForeColor = Color.FromArgb(conf_colores(9))
        Button12.BackColor = Color.FromArgb(conf_colores(8))
        Button12.ForeColor = Color.FromArgb(conf_colores(9))
        Button13.BackColor = Color.FromArgb(conf_colores(8))
        Button13.ForeColor = Color.FromArgb(conf_colores(9))
        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))
        Button15.BackColor = Color.FromArgb(conf_colores(8))
        Button15.ForeColor = Color.FromArgb(conf_colores(9))
        Button16.BackColor = Color.FromArgb(conf_colores(8))
        Button16.ForeColor = Color.FromArgb(conf_colores(9))
        Button17.BackColor = Color.FromArgb(conf_colores(8))
        Button17.ForeColor = Color.FromArgb(conf_colores(9))
        Button18.BackColor = Color.FromArgb(conf_colores(8))
        Button18.ForeColor = Color.FromArgb(conf_colores(9))
        Button19.BackColor = Color.FromArgb(conf_colores(8))
        Button19.ForeColor = Color.FromArgb(conf_colores(9))
        Button20.BackColor = Color.FromArgb(conf_colores(8))
        Button20.ForeColor = Color.FromArgb(conf_colores(9))
        Button21.BackColor = Color.FromArgb(conf_colores(8))
        Button21.ForeColor = Color.FromArgb(conf_colores(9))
        Button22.BackColor = Color.FromArgb(conf_colores(8))
        Button22.ForeColor = Color.FromArgb(conf_colores(9))
        Button23.BackColor = Color.FromArgb(conf_colores(8))
        Button23.ForeColor = Color.FromArgb(conf_colores(9))
        Button25.BackColor = Color.FromArgb(conf_colores(8))
        Button25.ForeColor = Color.FromArgb(conf_colores(9))
        Button26.BackColor = Color.FromArgb(conf_colores(8))
        Button26.ForeColor = Color.FromArgb(conf_colores(9))
        Button27.BackColor = Color.FromArgb(conf_colores(8))
        Button27.ForeColor = Color.FromArgb(conf_colores(9))
        Button28.BackColor = Color.FromArgb(conf_colores(8))
        Button28.ForeColor = Color.FromArgb(conf_colores(9))
        Button29.BackColor = Color.FromArgb(conf_colores(8))
        Button29.ForeColor = Color.FromArgb(conf_colores(9))
        Button30.BackColor = Color.FromArgb(conf_colores(8))
        Button30.ForeColor = Color.FromArgb(conf_colores(9))
        Button31.BackColor = Color.FromArgb(conf_colores(8))
        Button31.ForeColor = Color.FromArgb(conf_colores(9))
        Button33.BackColor = Color.FromArgb(conf_colores(8))
        Button33.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_barra.BackColor = Color.FromArgb(conf_colores(8))
        btn_barra.ForeColor = Color.FromArgb(conf_colores(9))
        btn_clear.BackColor = Color.FromArgb(conf_colores(8))
        btn_clear.ForeColor = Color.FromArgb(conf_colores(9))
        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub frm_producto_busqueda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frm_principal3.preparar_para_codigo()
        global_frm_producto_busqueda = 0
    End Sub
    Private Sub frm_producto_busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_producto_busqueda = 1
        cargado = False
        aplicar_colores()
        estilo_productos(dgv_productos)
        cargado = True
        obtener_productos(tb_search.Text)
        tb_search.Select()
        tb_search.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button23.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, btn_barra.Click, Button33.Click
        If TypeOf sender Is Button Then
            tb_search.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        If tb_search.TextLength > 0 Then
            tb_search.Text = tb_search.Text.Remove(tb_search.TextLength - 1, 1)
            tb_search.SelectionStart = Len(tb_search.Text)
        End If
    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        tb_search.Text = ""
    End Sub
    Private Sub tb_search_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_search.KeyDown, Me.KeyDown
        If e.KeyCode = 40 Then 'abajo
            dgv_productos.Select()
        End If
    End Sub
    Private Sub tb_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_search.TextChanged
        If cargado = True Then
            obtener_productos(tb_search.Text)
        End If
    End Sub
    Private Sub dgv_productos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_productos.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_productos.Columns.Count - 1
            If dgv_productos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos.DoubleClick
        btn_aceptar_Click(sender, e)
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If _modo = 0 Then
            If dgv_productos.Rows.Count > 0 Then
                Dim foundRows() As Data.DataRow = tabla_ventas.Select("id_producto = " & dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                If foundRows.Length > 0 Then
                    If conf_pv(2) = 1 Then
                        GoTo _ENVIAR
                    Else
                        MsgBox("Este producto ya se encuentra en la lista", MsgBoxStyle.Exclamation, "Aviso")
                    End If

                Else
_ENVIAR:            global_current_idproducto = dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value
                    frm_producto_cantidad.modo = 1
                    frm_producto_cantidad.ShowDialog()
                    frm_producto_cantidad.BringToFront()
                    tb_search.SelectAll()
                    tb_search.Focus()
                    If chb_mantener.CheckState = 0 Then
                        Me.Close()
                    End If
                End If
            End If
        ElseIf _modo = 1 Then
            If dgv_productos.Rows.Count > 0 Then
                If global_frm_compras = 1 Then
                    frm_productos_recepcion.agregar_producto(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                Else
                    frm_productos_recepcion.Show()
                    frm_productos_recepcion.BringToFront()
                    frm_productos_recepcion.agregar_producto(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                End If
                tb_search.SelectAll()
                tb_search.Focus()
                If chb_mantener.CheckState = 0 Then
                    Me.Close()
                End If
            End If
        ElseIf _modo = 2 Then
            If dgv_productos.Rows.Count > 0 Then
                If global_frm_traspasos_recepcion = 1 Then
                    frm_traspasos_recepcion.agregar_producto(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                Else
                    frm_productos_recepcion.Show()
                    frm_productos_recepcion.BringToFront()
                    frm_productos_recepcion.agregar_producto(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                End If
                tb_search.SelectAll()
                tb_search.Focus()
                If chb_mantener.CheckState = 0 Then
                    Me.Close()
                End If
            End If
        ElseIf _modo = 3 Then
            If dgv_productos.Rows.Count > 0 Then
                If global_frm_traspasos_envio = 1 Then
                    frm_traspasos_envio.agregar_producto(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                Else
                    frm_traspasos_envio.Show()
                    frm_traspasos_envio.BringToFront()
                    frm_traspasos_envio.agregar_producto(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
                End If
                tb_search.SelectAll()
                tb_search.Focus()
                If chb_mantener.CheckState = 0 Then
                    Me.Close()
                End If
            End If
        ElseIf _modo = 4 Then
            If global_frm_directorio = 1 Then
                frm_directorio.seleccionar_producto_directorio(dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
            End If
            tb_search.SelectAll()
            tb_search.Focus()
            If chb_mantener.CheckState = 0 Then
                Me.Close()
            End If
        ElseIf _modo = 5 Then
            global_current_idproducto = (dgv_productos.Rows(dgv_productos.CurrentRow.Index).Cells("id_producto").Value)
            Me.Close()
        End If
    End Sub
    Public Function devolver_producto(id_producto As Integer) As Integer
        Return id_producto
    End Function
    Private Sub dgv_productos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_productos.KeyDown
        If e.KeyCode = 13 Then
            If dgv_productos.SelectedRows.Count > 0 Then
                btn_aceptar_Click(sender, e)
            End If
        End If
    End Sub
    Public Sub obtener_productos(ByVal filtro_busqueda As String, Optional pagina As Integer = 1)

        tb_pagina.Text = pagina
        inicial = (pagina - 1) * reg_por_pag

        tabla_productos.Clear()
        Dim filtro As String = ""

        If Trim(filtro_busqueda) <> "" Then
            Dim palabras() As String = Strings.Split(filtro_busqueda, " ")
            Dim total_palabras As Integer = 0
            Dim i As Integer

            For i = 0 To UBound(palabras)
                total_palabras += 1
            Next i
            For x = 0 To total_palabras - 1
                filtro &= " AND (producto.nombre LIKE '%" & palabras(x) & "%' OR producto.codigo LIKE '%" & palabras(x) & "%')"
            Next
        End If


        rs.Open("SELECT count(*) as total_productos FROM producto WHERE 1 " & filtro, conn)
        total_productos = rs.Fields("total_productos").Value
        rs.Close()

        total_paginas = Ceiling(total_productos / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas


        Try
            rs.Open("SELECT producto.id_producto,producto.nombre,producto.codigo,unidad.nombre AS unidad " & _
                "FROM producto " & _
                "JOIN unidad ON unidad.id_unidad=producto.id_unidad " & _
                "WHERE 1 " & filtro & " LIMIT " & inicial & "," & reg_por_pag, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim precio As Decimal = obtener_precio_producto(rs.Fields("id_producto").Value, global_current_precio_especial)
                    agregar_producto_busqueda(rs.Fields("id_producto").Value, rs.Fields("codigo").Value, rs.Fields("nombre").Value, precio, rs.Fields("unidad").Value)
                    rs.MoveNext()
                End While
            End If
            tb_resultados.Text = total_productos & " resultado(s)"
            lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
            rs.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub pb_anterior_Click(sender As System.Object, e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            obtener_productos(tb_search.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_siguiente_Click(sender As System.Object, e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            obtener_productos(tb_search.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub tb_pagina_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                obtener_productos(tb_search.Text, tb_pagina.Text)
            End If
        End If
    End Sub
End Class