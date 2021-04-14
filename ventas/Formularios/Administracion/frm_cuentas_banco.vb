Public Class frm_cuentas_banco
    Dim modo As String = ""
    Dim id_cuenta As Integer
    Dim cuenta As String
    Private Sub frm_cuentas_banco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        configuracion_inicio()
    End Sub
    Private Sub obtener_cuentas()
        cb_cuenta.Items.Clear()
        'Conectar()
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT id_cuenta,cuenta FROM banco_cuentas Order By saldo", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                If rs.RecordCount > 0 Then
                    cb_cuenta.Items.Add(New myItem(rs.Fields("id_cuenta").Value, rs.Fields("cuenta").Value))
                    rs.MoveNext()
                End If
            End While
        End If

        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub llenar_bancos()
        cb_banco.Items.Clear()
        cb_banco.DropDownStyle = ComboBoxStyle.DropDownList
        'Conectar()
        rs.Open("SELECT * FROM banco Order By descripcion", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_banco.Items.Add(New myItem(rs.Fields("id_banco").Value, rs.Fields("descripcion").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub configuracion_inicio()
        cb_cuenta.DropDownStyle = ComboBoxStyle.DropDownList
        cb_banco.DropDownStyle = ComboBoxStyle.Simple
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = False
        btn_guardar.Enabled = False
        btn_nuevo.Enabled = True
        tb_contrato.Text = ""
        tb_nip_audiomatico.Text = ""
        tb_nip_fiscal.Text = ""
        tb_num_cheque.Text = ""
        tb_num_cliente.Text = ""
        tb_saldo.Text = ""
        tb_sucursal.Text = ""
        obtener_cuentas()
    End Sub

    Private Sub cb_cuenta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cuenta.SelectedIndexChanged
        If cb_cuenta.SelectedIndex <> -1 Then
            id_cuenta = CType(cb_cuenta.SelectedItem, myItem).Value
            cuenta = cb_cuenta.Text
            'Conectar()
            rs.Open("SELECT * FROM banco_cuentas bc,banco b WHERE bc.id_banco=b.id_banco AND id_cuenta ='" & CType(cb_cuenta.SelectedItem, myItem).Value & "' order By bc.saldo", conn)
            If rs.RecordCount > 0 Then
                tb_num_cliente.Text = rs.Fields("Num_cliente").Value
                tb_contrato.Text = rs.Fields("Contrato").Value
                tb_sucursal.Text = rs.Fields("Sucursal").Value
                dtp_fecha_apertura.Text = rs.Fields("Fecha_Apertura").Value
                tb_nip_audiomatico.Text = rs.Fields("Nip_Audio").Value
                tb_nip_fiscal.Text = rs.Fields("Nip_Fiscal").Value
                tb_saldo.Text = rs.Fields("Saldo").Value
                tb_num_cheque.Text = rs.Fields("Ultimo_Cheq").Value
                cb_banco.Text = rs.Fields("descripcion").Value

            End If

            rs.Close()
            'conn.close()
            'conn = Nothing
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
        End If

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        modo = "nuevo"
        cb_cuenta.Items.Clear()
        cb_cuenta.DropDownStyle = ComboBoxStyle.Simple
        tb_contrato.Text = ""
        tb_nip_audiomatico.Text = ""
        tb_nip_fiscal.Text = ""
        tb_num_cheque.Text = ""
        tb_num_cliente.Text = ""
        tb_saldo.Text = ""
        tb_sucursal.Text = ""
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        btn_cancelar.Enabled = True
        btn_guardar.Enabled = True
        llenar_bancos()

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        modo = "editar"
        btn_nuevo.Enabled = False
        btn_cancelar.Enabled = True
        btn_guardar.Enabled = True
        btn_editar.Enabled = False
        btn_eliminar.Enabled = False
        cb_cuenta.DropDownStyle = ComboBoxStyle.Simple
        cb_banco.DropDownStyle = ComboBoxStyle.DropDown
        llenar_bancos()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        guardar(modo)
    End Sub
    Private Sub guardar(ByVal modo As String)
        Dim b As Boolean = False
        Dim mensaje_error As String = "Los siguientes datos son Obligatorios:" & vbCrLf & vbCrLf
        If cb_banco.SelectedIndex = -1 Then
            mensaje_error = mensaje_error & "   *  Banco" & vbCrLf
            b = True
        End If
        If Trim(cb_cuenta.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Nº de Cuenta" & vbCrLf
            b = True
        End If
        If Trim(tb_contrato.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Número de Contrato" & vbCrLf
            b = True
        End If

        If Trim(tb_num_cliente.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Número de Cliente" & vbCrLf
            b = True
        End If

        If Trim(tb_sucursal.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Sucursal" & vbCrLf
            b = True
        End If

        If Trim(tb_nip_audiomatico.Text) = "" Then
            mensaje_error = mensaje_error & "   *  NIP Audiomatico" & vbCrLf
            b = True
        End If

        If Trim(tb_nip_fiscal.Text) = "" Then
            mensaje_error = mensaje_error & "   *  NIP Fiscal" & vbCrLf
            b = True
        End If
        If Trim(tb_num_cheque.Text) = "" Then
            mensaje_error = mensaje_error & "   *  Nº de Cheque Inicial" & vbCrLf
            b = True
        End If
        If b Then
            MsgBox(mensaje_error, MsgBoxStyle.Exclamation, "Información Requerida")
        Else
            If modo = "nuevo" Then
                'Conectar()
                conn.Execute("INSERT INTO banco_cuentas(id_banco,Cuenta,Num_Cliente,Contrato,Sucursal,Fecha_Apertura,Nip_Audio,Nip_Fiscal,Saldo,Ultimo_Cheq) " & _
                             "VALUES ('" & CType(cb_banco.SelectedItem, myItem).Value & "','" & cb_cuenta.Text & "','" & tb_num_cliente.Text & "','" & tb_contrato.Text & "','" & tb_sucursal.Text & "','" & dtp_fecha_apertura.Value & "','" & tb_nip_audiomatico.Text & "','" & tb_nip_fiscal.Text & "','" & tb_saldo.Text & "','" & tb_num_cheque.Text & "')", , -1)
                'conn.close()
                'conn = Nothing
                MsgBox("La cuenta " & cb_cuenta.Text & " ha sido guardada correctamente", MsgBoxStyle.Information, "Información")
                configuracion_inicio()
            ElseIf modo = "editar" Then
                If id_cuenta <> 0 Then
                    If MsgBox("Esta seguro de modificar  " & cuenta & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        'Conectar()
                        conn.Execute("UPDATE banco_cuentas SET id_banco = '" & CType(cb_banco.SelectedItem, myItem).Value & "',Cuenta = '" & cb_cuenta.Text & "',Num_Cliente = '" & tb_num_cliente.Text & "',Contrato = '" & tb_contrato.Text & "',Sucursal = '" & tb_sucursal.Text & "',Fecha_Apertura = '" & dtp_fecha_apertura.Value & "',Nip_Audio = '" & tb_nip_audiomatico.Text & "',Nip_Fiscal = '" & tb_nip_fiscal.Text & "',Saldo = '" & tb_saldo.Text & "',Ultimo_Cheq = '" & tb_num_cheque.Text & "'  WHERE id_cuenta = " & id_cuenta)
                        'conn.close()
                        'conn = Nothing
                        MsgBox(cuenta & " actualizado correctamente", MsgBoxStyle.Information, "Información")
                        configuracion_inicio()
                    End If
                End If
            End If
        End If
    End Sub
End Class