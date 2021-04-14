Public Class frm_abrir_cuenta

    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        

        Label1.BackColor = Color.FromArgb(conf_colores(1))
        Label2.BackColor = Color.FromArgb(conf_colores(1))
        Label3.BackColor = Color.FromArgb(conf_colores(1))
       

        btn_cancelar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_abrir_cuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        cargar_mesero()
    End Sub
    Private Sub cargar_mesero()
        cb_mesero.Items.Clear()

        rs.Open("SELECT id_mesero,nombre FROM meseros", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_mesero.Items.Add(New myItem(rs.Fields("id_mesero").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click

        Dim correcto As Boolean = True
        Dim mensaje_error As String = "Se encontrarón los siguientes errores " & vbCrLf

        If cb_mesero.SelectedIndex = -1 Then
            correcto = False
            mensaje_error &= "      * Debe seleccionar un mesero de la lista " & vbCrLf
        End If

        If Trim(tb_cuenta.TextLength) = 0 Then
            correcto = False
            mensaje_error &= "      * Indique el nombre de la cuenta " & vbCrLf
        End If

        If correcto = True Then
            conn.Execute("INSERT INTO orden_comedor(cuenta,id_mesero,num_personas,apertura) VALUES ('" & tb_cuenta.Text & "','" & CType(cb_mesero.SelectedItem, myItem).Value & "','" & cb_num_personas.Value & "',CURRENT_TIMESTAMP)")

            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Dim id_orden = rs.Fields(0).Value
            rs.Close()

            frm_principal3.modo_venta = 1
            frm_principal3.id_orden = id_orden
            frm_principal3.cargar_usuario_actual()
            frm_principal3.Show()
            frm_principal3.BringToFront()

            frm_comedor.cargar_cuentas()
            frm_comedor.cargar_orden(id_orden)
            Me.Close()
        Else
            MsgBox(mensaje_error, MsgBoxStyle.Critical, " Aviso")
        End If
        

    End Sub
End Class