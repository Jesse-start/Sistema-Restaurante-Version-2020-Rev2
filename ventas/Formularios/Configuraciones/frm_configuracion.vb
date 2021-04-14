Public Class frm_configuracion
    Dim selected_text As Integer = 0
    Private Sub frm_configuracion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Not conectado Then
            MsgBox("El Programa se Cerrara, Favor de comprobar la configuracion de la Conexion posteriormente", MsgBoxStyle.Information, "Configuracion Erronea")
            frm_usuarios.Dispose()
        End If
    End Sub
    Private Sub frmConfiguracion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If System.IO.File.Exists(archivo_configuracion) = True Then
            Dim objReader As New System.IO.StreamReader(archivo_configuracion)
            tb_nombre.Text = objReader.ReadLine()
            tb_servidor.Text = objReader.ReadLine()
            tb_usuario.Text = objReader.ReadLine()
            tb_password.Text = objReader.ReadLine()
            objReader.Close()
        End If
        MsgBox("No se pudo establecer la conexion, Porfavor Configure el Origen de los Datos")
    End Sub
    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub Guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If Trim(tb_nombre.Text) = "" Then
            MsgBox("Debes Escribir el Nombre de la Base de Datos", MsgBoxStyle.Information, "Campo Requerido")
        Else
            db_nombre = tb_nombre.Text
            db_servidor = tb_servidor.Text
            db_usuario = tb_usuario.Text
            db_password = tb_password.Text

            conexion_str = "Driver={MySQL ODBC 8.0 Unicode Driver};" _
                                & "Server=" & db_servidor & ";" _
                                & "Database=" & db_nombre & ";User=" & db_usuario & ";" _
                                & "Option=3;" _
                                & "Password=" & db_password & ";"
            conn = New ADODB.Connection
            conn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            conn.ConnectionString = conexion_str
            'Try
            conn.Open()
            conectado = True
            MsgBox("Conexión Establecida")

            Dim objWriter As New System.IO.StreamWriter(archivo_configuracion, False)
            objWriter.WriteLine(tb_nombre.Text)
            objWriter.WriteLine(tb_servidor.Text)
            objWriter.WriteLine(tb_usuario.Text)
            objWriter.WriteLine(tb_password.Text)
            objWriter.WriteLine("C:\AppServ\MySQL")
            objWriter.Close()
            Me.Close()
            'Catch ex As Exception
            'conectado = False
            'MsgBox("No se puede Establecer la Conexión " & vbCrLf & "(" & ex.Message & ")")
            'End Try
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button23.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, btn_barra.Click, Button33.Click, Button32.Click, Button34.Click, Button35.Click, Button36.Click, Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click, Button42.Click
        If TypeOf sender Is Button Then
            If selected_text = 1 Then
                tb_nombre.Focus()
            ElseIf selected_text = 2 Then
                tb_servidor.Focus()
            ElseIf selected_text = 3 Then
                tb_usuario.Focus()
            ElseIf selected_text = 4 Then
                tb_password.Focus()
            End If
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub tb_nombre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_nombre.Click
        selected_text = 1
        tb_nombre.Focus()
    End Sub

    Private Sub tb_servidor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_servidor.Click
        selected_text = 2
        tb_servidor.Focus()
    End Sub
    Private Sub tb_usuario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_usuario.Click
        selected_text = 3
        tb_usuario.Focus()
    End Sub
    Private Sub tb_password_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_password.Click
        selected_text = 4
        tb_password.Focus()
    End Sub
    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        If selected_text = 1 Then
            If tb_nombre.TextLength > 0 Then
                tb_nombre.Text = tb_nombre.Text.Remove(tb_nombre.TextLength - 1, 1)
                tb_nombre.SelectionStart = Len(tb_nombre.Text)
            End If
        ElseIf selected_text = 2 Then
            If tb_servidor.TextLength > 0 Then
                tb_servidor.Text = tb_servidor.Text.Remove(tb_servidor.TextLength - 1, 1)
                tb_servidor.SelectionStart = Len(tb_servidor.Text)
            End If
        ElseIf selected_text = 3 Then
            If tb_usuario.TextLength > 0 Then
                tb_usuario.Text = tb_usuario.Text.Remove(tb_usuario.TextLength - 1, 1)
                tb_usuario.SelectionStart = Len(tb_usuario.Text)
            End If
        ElseIf selected_text = 4 Then
            If tb_password.TextLength > 0 Then
                tb_password.Text = tb_password.Text.Remove(tb_password.TextLength - 1, 1)
                tb_password.SelectionStart = Len(tb_password.Text)
            End If
        End If

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If selected_text = 1 Then
            tb_nombre.Text = ""
        ElseIf selected_text = 2 Then
            tb_servidor.Text = ""
        ElseIf selected_text = 3 Then
            tb_usuario.Text = ""
        ElseIf selected_text = 4 Then
            tb_password.Text = ""
        End If
    End Sub

    
End Class