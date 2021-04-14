Public Class frm_descuentos
    Dim modo As Integer = 0 ' 0 descuento global. 1 - descuento por producto
    Dim cargado As Boolean = False

    Private Sub frm_descuentos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frm_principal3.cargar_usuario_actual()
    End Sub
    Private Sub frm_descuentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        aplicar_colores()
        estilo_descuentos(dgv_descuentos)
        cargar()
    End Sub
    Private Sub cargar()
        'Conectar()
        rs.Open("SELECT temp_venta_detalle.*, producto.thumb FROM temp_venta_detalle JOIN producto ON producto.id_producto=temp_venta_detalle.id_producto WHERE id_empleado='" & global_id_empleado & "' ORDER BY temp_venta_detalle.id_temp_venta_detalle", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_tabla_descuento(rs.Fields("id_temp_venta_detalle").Value, rs.Fields("id_producto").Value, rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("precio").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("descuento").Value, "0", "0")
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '----------------------------
        obtener_totales(global_current_descuento_global)
        tb_descuento.Text = global_current_descuento_global
        lb_informacion.Text = "Aplicar descuento global del " & tb_descuento.Text & " %"
        cargado = True
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.Black
        Panel2.ForeColor = Color.FromArgb(conf_colores(13))

        rb_descuento_global.ForeColor = Color.FromArgb(conf_colores(13))
        rb_descuento_producto.ForeColor = Color.FromArgb(conf_colores(13))

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))

        btn0.BackColor = Color.FromArgb(conf_colores(8))
        btn0.ForeColor = Color.FromArgb(conf_colores(9))

        btn1.BackColor = Color.FromArgb(conf_colores(8))
        btn1.ForeColor = Color.FromArgb(conf_colores(9))

        btn2.BackColor = Color.FromArgb(conf_colores(8))
        btn2.ForeColor = Color.FromArgb(conf_colores(9))

        btn3.BackColor = Color.FromArgb(conf_colores(8))
        btn3.ForeColor = Color.FromArgb(conf_colores(9))

        btn4.BackColor = Color.FromArgb(conf_colores(8))
        btn4.ForeColor = Color.FromArgb(conf_colores(9))

        btn5.BackColor = Color.FromArgb(conf_colores(8))
        btn5.ForeColor = Color.FromArgb(conf_colores(9))

        btn6.BackColor = Color.FromArgb(conf_colores(8))
        btn6.ForeColor = Color.FromArgb(conf_colores(9))

        btn7.BackColor = Color.FromArgb(conf_colores(8))
        btn7.ForeColor = Color.FromArgb(conf_colores(9))

        btn8.BackColor = Color.FromArgb(conf_colores(8))
        btn8.ForeColor = Color.FromArgb(conf_colores(9))

        btn9.BackColor = Color.FromArgb(conf_colores(8))
        btn9.ForeColor = Color.FromArgb(conf_colores(9))

        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))

        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))

        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If modo = 0 Then
                tb_descuento.Focus()
            ElseIf modo = 1 Then
                tb_descuento_producto.Focus()
            ElseIf modo = 2 Then
                tb_importe.Focus()
            End If
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If modo = 0 Then
            If tb_descuento.TextLength > 0 Then
                tb_descuento.Text = tb_descuento.Text.Remove(tb_descuento.TextLength - 1, 1)
                tb_descuento.SelectionStart = Len(tb_descuento.Text)
            End If
        ElseIf modo = 1 Then
            If tb_descuento_producto.TextLength > 0 Then
                tb_descuento_producto.Text = tb_descuento_producto.Text.Remove(tb_descuento_producto.TextLength - 1, 1)
                tb_descuento_producto.SelectionStart = Len(tb_descuento_producto.Text)
            End If
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub dgv_descuentos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_descuentos.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        For x = 0 To dgv_descuentos.Columns.Count - 1
            If dgv_descuentos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_descuentos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_descuentos.CellValueChanged
        If cargado = True Then
            actualizar_importe(dgv_descuentos.Rows(dgv_descuentos.CurrentRow.Index).Cells("id_temp_venta_detalle").Value)
        End If
    End Sub
    Private Sub actualizar_importe(ByVal id_temp_venta_detalle As Integer)
        Dim foundRows() As Data.DataRow = tabla_descuentos.Select("id_temp_venta_detalle = " & id_temp_venta_detalle)
        Dim precio As Decimal = 0
        If foundRows.Length > 0 Then
            Dim _importe_descuento As Decimal = foundRows(0).Item("importe") * (foundRows(0).Item("descuento") / 100)
            Dim importe_con_desc As Decimal = foundRows(0).Item("importe") - _importe_descuento
            If global_current_aplicar_redondeo Then
                foundRows(0).Item("importe_descuento") = redondear(FormatNumber(importe_con_desc, 2))
            Else
                foundRows(0).Item("importe_descuento") = FormatNumber(importe_con_desc, 2)
            End If
        End If
    End Sub
    Private Sub actualizar_descuento(ByVal id_temp_venta_detalle As Integer, ByVal descuento As Decimal)
        Dim foundRows() As Data.DataRow = tabla_descuentos.Select("id_temp_venta_detalle = " & id_temp_venta_detalle)
        Dim precio As Decimal = 0
        If foundRows.Length > 0 Then
            foundRows(0).Item("descuento") = descuento
            Dim _importe_descuento As Decimal = foundRows(0).Item("importe") * (foundRows(0).Item("descuento") / 100)
            Dim importe_con_desc As Decimal = foundRows(0).Item("importe") - _importe_descuento
            If global_current_aplicar_redondeo Then
                foundRows(0).Item("importe_descuento") = redondear(FormatNumber(importe_con_desc, 2))
            Else
                foundRows(0).Item("importe_descuento") = FormatNumber(importe_con_desc, 2)
            End If
        End If
    End Sub
    Private Sub dgv_descuentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_descuentos.Click
        If dgv_descuentos.Rows.Count > 0 Then
            If dgv_descuentos.CurrentCell.ColumnIndex = 4 Then

            End If
        End If
    End Sub

    Private Sub rb_descuento_global_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_descuento_global.CheckedChanged

        If rb_descuento_global.Checked = True Then
            tb_descuento.Enabled = True
            tb_importe.Enabled = False
            tb_descuento_producto.Enabled = False
            modo = 0
            tb_descuento.Text = ""
            If tb_descuento.Text = "" Then
                lb_informacion.Text = "Aplicar descuento global del 0 %"
            Else
                lb_informacion.Text = "Aplicar descuento global del " & tb_descuento.Text & " %"
            End If
        Else
            If rb_descuento_global_importe.Checked = True Then
                tb_descuento.Enabled = False
                tb_importe.Enabled = True
                tb_descuento_producto.Enabled = False
                modo = 2
                tb_descuento_producto.Text = ""
                If tb_importe.Text = "" Then
                    lb_informacion.Text = "Aplicar descuento global del $0.00"
                Else
                    lb_informacion.Text = "Aplicar descuento global de " & FormatCurrency(tb_importe.Text)
                End If
            Else
                tb_descuento.Enabled = False
                tb_importe.Enabled = False
                tb_descuento_producto.Enabled = True
                modo = 1
                tb_descuento_producto.Text = ""
                lb_informacion.Text = "Aplicar descuento asignados a cada producto"
            End If

        End If
    End Sub

    Private Sub rb_descuento_producto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_descuento_producto.CheckedChanged
        If rb_descuento_producto.Checked = True Then
            tb_descuento.Enabled = False
            tb_importe.Enabled = False
            tb_descuento_producto.Enabled = True
            modo = 1
            tb_descuento.Text = ""
            lb_informacion.Text = "Aplicar descuento asignados a cada producto"

        Else
            If rb_descuento_global_importe.Checked = True Then
                tb_descuento.Enabled = False
                tb_importe.Enabled = True
                tb_descuento_producto.Enabled = False
                modo = 2
                tb_descuento_producto.Text = ""
                If tb_importe.Text = "" Then
                    lb_informacion.Text = "Aplicar descuento global del $0.00"
                Else
                    lb_informacion.Text = "Aplicar descuento global de " & FormatCurrency(tb_importe.Text)
                End If
            Else
                tb_descuento.Enabled = True
                tb_importe.Enabled = False
                tb_descuento_producto.Enabled = False
                modo = 0
                tb_descuento_producto.Text = ""
                If tb_descuento.Text = "" Then
                    lb_informacion.Text = "Aplicar descuento global del 0 %"
                Else
                    lb_informacion.Text = "Aplicar descuento global del " & tb_descuento.Text & " %"
                End If
            End If


        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If modo = 0 Then
            tb_descuento.Text = ""

        ElseIf modo = 1 Then
            tb_descuento_producto.Text = ""
        End If
    End Sub

    Private Sub dgv_descuentos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_descuentos.CellContentClick

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If tabla_descuentos.Rows.Count > 0 Then
            If modo = 0 Then
                If tb_descuento.Text = "" Then
                    MsgBox("Introduzca la el porcentaje a descontar del total de la venta", MsgBoxStyle.Information, "Aviso")
                Else
                    obtener_totales(tb_descuento.Text)
                    lb_informacion.Text = "Aplicar descuento global del " & tb_descuento.Text & " %"
                End If
            ElseIf modo = 1 Then
                If tb_descuento_producto.Text = "" Then
                    MsgBox("Introduzca el porcentaje del descuento", MsgBoxStyle.Information, "Aviso")
                Else
                    actualizar_descuento(dgv_descuentos.Rows(dgv_descuentos.CurrentRow.Index).Cells("id_temp_venta_detalle").Value, tb_descuento_producto.Text)
                    tb_descuento_producto.Text = ""
                    obtener_totales(global_current_descuento_global)
                End If
            ElseIf modo = 2 Then
                If tb_importe.Text = "" Then
                    MsgBox("Introduzca el importe a descontar del total de la venta", MsgBoxStyle.Information, "Aviso")
                Else
                    obtener_totales(0)
                    lb_informacion.Text = "Aplicar descuento global de " & FormatCurrency(tb_importe.Text)
                End If
            End If
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        If MsgBox("Confirme que desea aplicar los descuentos correspondientes", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If modo = 0 Then
                If tb_descuento.Text = "" Then
                    MsgBox("Introduzca la el porcentaje a descontar del total de la venta", MsgBoxStyle.Information, "Aviso")
                Else
                    'Conectar()
                    global_current_descuento_global = tb_descuento.Text
                    For x = 0 To dgv_descuentos.RowCount - 1
                        conn.Execute("UPDATE temp_venta_detalle SET desc_global_porcent='" & global_current_descuento_global & "' WHERE id_temp_venta_detalle=' " & dgv_descuentos.Rows(x).Cells("id_temp_venta_detalle").Value & "'")
                    Next
                    'conn.close()
                    'conn = Nothing
                    MsgBox("Los descuentos fueron aplicados correctamente", MsgBoxStyle.Information, "Aviso")
                    Me.Close()
                End If
            ElseIf modo = 1 Then
                'Conectar()
                For x = 0 To dgv_descuentos.RowCount - 1
                    conn.Execute("UPDATE temp_venta_detalle SET descuento='" & dgv_descuentos.Rows(x).Cells("descuento").Value & "' WHERE id_temp_venta_detalle=' " & dgv_descuentos.Rows(x).Cells("id_temp_venta_detalle").Value & "'")
                Next
                'conn.close()
                'conn = Nothing
                MsgBox("Los descuentos fueron aplicados correctamente", MsgBoxStyle.Information, "Aviso")
                Me.Close()
            ElseIf modo = 2 Then
                If tb_importe.Text = "" Then
                    MsgBox("Introduzca la el importe a descontar del total de la venta", MsgBoxStyle.Information, "Aviso")
                Else
                    'Conectar()
                    global_current_descuento_global_importe = CDec(tb_importe.Text)
                    For x = 0 To dgv_descuentos.RowCount - 1
                        conn.Execute("UPDATE temp_venta_detalle SET desc_global_importe='" & global_current_descuento_global_importe & "' WHERE id_temp_venta_detalle=' " & dgv_descuentos.Rows(x).Cells("id_temp_venta_detalle").Value & "'")
                    Next
                    'conn.close()
                    'conn = Nothing
                    MsgBox("Los descuentos fueron aplicados correctamente", MsgBoxStyle.Information, "Aviso")
                    Me.Close()
                End If
            End If
        End If
    End Sub
    Private Sub obtener_totales(ByVal porcent_descuento_global As Decimal)
        Dim subtotal As Decimal = 0
        Dim total_descuento As Decimal = 0
        Dim total As Decimal = 0

        If modo = 2 Then
            For x = 0 To dgv_descuentos.RowCount - 1
                subtotal += dgv_descuentos.Rows(x).Cells("importe").Value
                Dim _importe_descuento As Decimal = 0
                If global_current_aplicar_redondeo Then
                    _importe_descuento = redondear(FormatNumber(dgv_descuentos.Rows(x).Cells("importe").Value * (dgv_descuentos.Rows(x).Cells("descuento").Value / 100), 2))
                Else
                    _importe_descuento = FormatNumber(dgv_descuentos.Rows(x).Cells("importe").Value * (dgv_descuentos.Rows(x).Cells("descuento").Value / 100))
                End If
                total_descuento += _importe_descuento
            Next

            Dim total_descuento_global As Decimal = CDec(tb_importe.Text)
            total_descuento += total_descuento_global
            total = subtotal - total_descuento
            tb_subtotal.Text = FormatCurrency(subtotal)
            tb_descuento_total.Text = FormatCurrency(total_descuento)
            tb_total.Text = FormatCurrency(total)
        Else
            For x = 0 To dgv_descuentos.RowCount - 1
                subtotal += dgv_descuentos.Rows(x).Cells("importe").Value
                Dim _importe_descuento As Decimal = 0
                If global_current_aplicar_redondeo Then
                    _importe_descuento = redondear(FormatNumber(dgv_descuentos.Rows(x).Cells("importe").Value * (dgv_descuentos.Rows(x).Cells("descuento").Value / 100), 2))
                Else
                    _importe_descuento = FormatNumber(dgv_descuentos.Rows(x).Cells("importe").Value * (dgv_descuentos.Rows(x).Cells("descuento").Value / 100))
                End If
                total_descuento += _importe_descuento
            Next
            Dim total_descuento_global As Decimal = (subtotal - total_descuento) * (porcent_descuento_global / 100)

            If global_current_aplicar_redondeo Then
                total_descuento_global = redondear(FormatNumber(total_descuento_global, 3))
            End If

            total_descuento += total_descuento_global
            total = subtotal - total_descuento
            tb_subtotal.Text = FormatCurrency(subtotal)
            tb_descuento_total.Text = FormatCurrency(total_descuento)
            tb_total.Text = FormatCurrency(total)
        End If
       
    End Sub

    Private Sub rb_descuento_global_importe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_descuento_global_importe.CheckedChanged
        If rb_descuento_global_importe.Checked = True Then
            tb_descuento.Enabled = False
            tb_importe.Enabled = True
            tb_descuento_producto.Enabled = False
            modo = 2
            tb_descuento.Text = ""
            If tb_importe.Text = "" Then
                lb_informacion.Text = "Aplicar descuento global del $0.00"
            Else
                lb_informacion.Text = "Aplicar descuento global de " & FormatCurrency(tb_importe.Text)
            End If

        Else
            If rb_descuento_global.Checked = True Then
                tb_descuento.Enabled = True
                tb_importe.Enabled = False
                tb_descuento_producto.Enabled = False
                modo = 0
                tb_descuento_producto.Text = ""
                If tb_descuento.Text = "" Then
                    lb_informacion.Text = "Aplicar descuento global del 0 %"
                Else
                    lb_informacion.Text = "Aplicar descuento global del " & tb_descuento.Text & " %"
                End If
            Else
                tb_descuento.Enabled = False
                tb_importe.Enabled = False
                tb_descuento_producto.Enabled = True
                modo = 1
                tb_descuento.Text = ""
                lb_informacion.Text = "Aplicar descuento asignados a cada producto"
            End If
        End If
    End Sub

    Private Sub tb_descuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_descuento.KeyDown, tb_importe.KeyDown, tb_descuento_producto.KeyDown, dgv_descuentos.KeyDown
        If e.KeyCode = 13 Then
            Button14_Click(sender, e)
        End If
    End Sub
End Class