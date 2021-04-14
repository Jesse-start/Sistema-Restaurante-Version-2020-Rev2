Public Class frm_seleccionar_almacen
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_almacenes.ForeColor = Color.FromArgb(conf_colores(2))
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
        Button24.BackColor = Color.FromArgb(conf_colores(8))
        Button24.ForeColor = Color.FromArgb(conf_colores(9))
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
    End Sub
    Private Sub frm_almacenes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        frm_principal3.preparar_para_codigo()


    End Sub
    Private Sub frm_almacenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        estilo_almacenes(dgv_almacenes)
        obtener_almacenes(tb_search.Text)
        If global_current_idalmacen <> 0 Then
            btn_salir.Visible = True
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
        Else
            btn_salir.Visible = False
            'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, btn_barra.Click, Button33.Click
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

    Private Sub tb_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_search.TextChanged
        obtener_almacenes(tb_search.Text)
    End Sub

    Private Sub dgv_almacenes_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_almacenes.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_almacenes.Columns.Count - 1
            If dgv_almacenes.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_clientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_almacenes.DoubleClick
        If tabla_almacenes.Rows.Count > 0 Then
            global_current_idalmacen = dgv_almacenes.Rows(dgv_almacenes.CurrentRow.Index).Cells("ID_Almacen").Value
            If global_default_idalmacen = 0 Then
                global_default_idalmacen = dgv_almacenes.Rows(dgv_almacenes.CurrentRow.Index).Cells("ID_Almacen").Value
                global_default_nombrealmacen = dgv_almacenes.Rows(dgv_almacenes.CurrentRow.Index).Cells("almacen").Value
            End If
            Me.Close()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Function dgv_pagos() As Object
        Throw New NotImplementedException
    End Function

End Class