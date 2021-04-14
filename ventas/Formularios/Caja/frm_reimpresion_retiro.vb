Public Class frm_reimpresion_retiro
    Dim cargado As Boolean
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_reimpresion_retiros.CellContentClick

    End Sub

    Private Sub frm_reimpresion_retiro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        estilo_reimpresion_retiro(dgv_reimpresion_retiros)
        cargar_colaboradores()
        dtp_fecha_inicio.Value = Today
        dtp_fecha_termino.Value = Today
        cargado = True
        cargar_retiros(CType(cb_colaborador.SelectedItem, myItem).Value, dtp_fecha_inicio.Value, dtp_fecha_termino.Value)
    End Sub
    Private Sub cargar_colaboradores()
        cb_colaborador.Items.Clear()
        cb_colaborador.Text = ""
        'Conectar()
        cb_colaborador.Items.Add(New myItem(0, "Todos los colaboradores", 0, 0))
        rs.Open("SELECT e.id_empleado, CONCAT(p.nombre,' ', p.ap_paterno,' ',P.ap_materno) As nombre FROM empleado e,persona p WHERE p.id_persona=e.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_colaborador.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        cb_colaborador.Text = "Todos los colaboradores"
    End Sub
    Private Sub cargar_retiros(ByVal id_empleado As Integer, ByVal fecha_inicio As DateTime, ByVal fecha_termino As DateTime)
        Dim filtro As String = " "

        If id_empleado > 0 Then
            filtro = filtro & "AND r.id_empleado='" & id_empleado & "' "
        End If
        If CType(dtp_fecha_inicio.Value, Date) = CType(dtp_fecha_termino.Value, Date) Then
            filtro = filtro & "AND DATE(r.fecha)='" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' "
        Else
            filtro = filtro & "AND DATE(r.fecha) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "' "
        End If
        tabla_reimpresion_retiros.Clear()
        'Conectar()
        rs.Open("SELECT r.id_retiro,r.fecha,r.cantidad,r.descripcion, CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS  empleado " & _
                " FROM retiros r JOIN empleado e ON e.id_empleado=r.id_empleado JOIN persona p ON p.id_persona=e.id_persona " & _
                " WHERE 1 " & filtro & "", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_reimpresion_retiro(rs.Fields("id_retiro").Value, rs.Fields("fecha").Value, rs.Fields("empleado").Value, rs.Fields("cantidad").Value, rs.Fields("descripcion").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub cb_colaborador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_colaborador.SelectedIndexChanged
        If cargado Then
            cargar_retiros(CType(cb_colaborador.SelectedItem, myItem).Value, dtp_fecha_inicio.Value, dtp_fecha_termino.Value)
        End If

    End Sub

    Private Sub dtp_fecha_inicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_inicio.ValueChanged
        If cargado Then
            cargar_retiros(CType(cb_colaborador.SelectedItem, myItem).Value, dtp_fecha_inicio.Value, dtp_fecha_termino.Value)
        End If

    End Sub

    Private Sub dtp_fecha_termino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_fecha_termino.ValueChanged
        If cargado Then
            cargar_retiros(CType(cb_colaborador.SelectedItem, myItem).Value, dtp_fecha_inicio.Value, dtp_fecha_termino.Value)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btn_reimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reimprimir.Click
        If dgv_reimpresion_retiros.SelectedRows.Count > 0 Then
            Dim x As Integer
            If MsgBox("A continuación se reimprimirá el ticket de retiro de efectivo. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                For x = 0 To 1
                    reimprimir_recibo_retiro(dgv_reimpresion_retiros.Rows(dgv_reimpresion_retiros.CurrentRow.Index).Cells("id_retiro").Value, x)
                Next
            Else
                reimprimir_recibo_retiro(dgv_reimpresion_retiros.Rows(dgv_reimpresion_retiros.CurrentRow.Index).Cells("id_retiro").Value, 0)
            End If
        Else
            MsgBox("Seleccione un retiro para reimprimir", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub
End Class