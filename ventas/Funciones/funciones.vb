Imports System.Management
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.IO
'---impresora
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
'-----------
Module funciones

    Private Sub configuracion()
        If System.IO.File.Exists(archivo_configuracion) = True Then
            Dim objReader As New System.IO.StreamReader(archivo_configuracion)
            db_nombre = objReader.ReadLine()
            db_servidor = objReader.ReadLine()
            db_usuario = objReader.ReadLine()
            db_password = objReader.ReadLine()
            db_directorio_mysql = objReader.ReadLine()
            objReader.Close()
        Else
            Dim objWriter As New System.IO.StreamWriter(archivo_configuracion, False)
            objWriter.WriteLine("bd")
            db_nombre = "bd"
            objWriter.WriteLine("localhost")
            db_servidor = "localhost"
            objWriter.WriteLine("root")
            db_usuario = "root"
            objWriter.WriteLine("password")
            db_password = "password"
            objWriter.WriteLine("directorio_mysql")
            db_password = "directorio_mysql"
            objWriter.Close()
        End If
    End Sub
    Public Sub guardar_cfg_terminal(ByVal nombre_terminal As String, ByVal imp_caja As String, ByVal imp_pedidos As String, ByVal imp_almacen As String)
        If System.IO.File.Exists(archivo_terminal) = True Then
            Dim objWriter As New System.IO.StreamWriter(archivo_terminal, False)
            objWriter.WriteLine(nombre_terminal)
            objWriter.WriteLine(imp_caja)
            objWriter.WriteLine(imp_pedidos)
            objWriter.WriteLine(imp_almacen)
            objWriter.Close()
        End If
    End Sub

    Public Sub leer_cfg_terminal()
        If System.IO.File.Exists(archivo_terminal) = True Then
            Dim objReader As New System.IO.StreamReader(archivo_terminal)
            global_nombre_terminal = objReader.ReadLine()
            conf_impresoras(0) = objReader.ReadLine()
            conf_impresoras(1) = objReader.ReadLine()
            conf_impresoras(2) = objReader.ReadLine()
            objReader.Close()
        Else
            Dim objWriter As New System.IO.StreamWriter(archivo_terminal, False)

            rs.Open("SELECT * FROM cfg_impresoras WHERE id_cfg_impresora=1", conn)
            If rs.RecordCount > 0 Then
                conf_impresoras(0) = rs.Fields("index_imp_caja").Value
                conf_impresoras(1) = rs.Fields("index_imp_pedidos").Value
                conf_impresoras(2) = rs.Fields("index_imp_almacen").Value
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing

            objWriter.WriteLine("Terminal Punto de Venta")
            global_nombre_terminal = "Terminal Punto de Venta"
            objWriter.WriteLine(conf_impresoras(0))
            objWriter.WriteLine(conf_impresoras(1))
            objWriter.WriteLine(conf_impresoras(2))


            objWriter.Close()
        End If
    End Sub
    Public Sub Conectar()
        configuracion()
        rs = New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        strConexion = "Driver={MySQL ODBC 8.0 Unicode Driver};" _
                            & "Server=" & db_servidor & ";" _
                            & "Database=" & db_nombre & ";User=" & db_usuario & ";" _
                            & "Password=" & db_password & ";" _
                            & "Option=3;"
        conn = New ADODB.Connection
        conn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        conn.ConnectionString = strConexion
        Try
            conn.Open()
        Catch ex As Exception

            frm_configuracion.ShowDialog()

        End Try
        conectado = True
    End Sub
    Public Function Conectar_Sucursal(ByVal server As String, ByVal username As String, ByVal password As String, ByVal database As String) As Boolean
        Dim conectado As Boolean = True
        rss = New ADODB.Recordset
        rss.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        strConexionSucursal = "Driver={MySQL ODBC 8.0 Unicode Driver};" _
                            & "Server=" & server & ";" _
                            & "Database=" & database & ";User=" & username & ";" _
                            & "Password=" & password & ";" _
                            & "Option=3;"

        conn_sucursal = New ADODB.Connection
        conn_sucursal.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        conn_sucursal.ConnectionString = strConexionSucursal

        Try
            conn_sucursal.Open()
        Catch ex As Exception
            conectado = False
        End Try
        Return conectado

    End Function

    Public Function conexion()
        configuracion()

        conexion_str = "Driver={MySQL ODBC 8.0 Unicode Driver};" _
                   & "Server=" & db_servidor & ";" _
                   & "Database=" & db_nombre & ";User=" & db_usuario & ";" _
                   & "Password=" & db_password & ";" _
                   & "Option=3;"

        conexion_prueba = New ADODB.Connection
        conexion_prueba.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        conexion_prueba.ConnectionString = conexion_str
        Try
            conexion_prueba.Open()
            conectado = True
        Catch ex As Exception
            conectado = False
            MsgBox("No se pudo establecer la conexion, Porfavor Configure el Origen de los Datos" & vbCrLf & "(" & ex.Message & ")")
            frm_configuracion.ShowDialog()
        End Try
        Return conexion_prueba
    End Function


    Public Function conector()
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        Return rs
    End Function

    Public Function actualizar(ByRef consulta As String)
        Dim conn As ADODB.Connection
        Dim rs As ADODB.Recordset
        conn = conexion()
        rs = conector()

        Try
            conn.Execute(consulta)
            'conn.close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Source)
            If 27806816 = ex.GetHashCode Then
                MsgBox(ex.GetHashCode)
            End If
            'conn.close()
            Return False
        End Try
    End Function

    Public Function actualizar(ByVal consulta As String, ByVal conexion As ADODB.Connection, Optional ByVal mensaje_error As Object = Nothing)
        conexion.BeginTrans()
        Try
            conexion.Execute(consulta)
            conexion.CommitTrans()
            Return True
        Catch ex As Exception
            conexion.RollbackTrans()
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, mensaje_error)
            Return False
        End Try
    End Function

    Public Function split_array_list(ByVal arreglo As ArrayList)
        Dim cadena As String = ""
        For i = 0 To arreglo.Count - 1
            If i = 0 Then
                cadena = arreglo(i)
            Else
                cadena = cadena & "," & arreglo(i)
            End If
        Next
        Return cadena
    End Function



    Public Function MD5(ByVal number As String) As String
        Dim ASCIIenc As New System.Text.ASCIIEncoding
        Dim strReturn As String = ""
        Dim ByteSourceText() As Byte = ASCIIenc.GetBytes(number)
        Dim Md5Hash As New MD5CryptoServiceProvider
        Dim ByteHash() As Byte = Md5Hash.ComputeHash(ByteSourceText)
        For Each b As Byte In ByteHash
            strReturn &= b.ToString("x2")
        Next
        Return strReturn
    End Function



    Public Function validar_teclado(ByVal caracter As Char, ByVal parametros As Array) As Boolean
        Dim patron_cadena As String = ""
        For Each valor In parametros
            If valor = "a" Then
                valor = "a-zA-Z"
            ElseIf valor = "0" Then
                valor = "0-9"
            ElseIf valor = "hex" Then
                valor = "a-fA-F"
            End If
            patron_cadena &= valor
        Next
        Dim patron As Regex = New Regex("[" & patron_cadena & Convert.ToChar(Keys.Back) & "]")
        Dim M As Match = patron.Match(caracter)
        If M.Success Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function txtNumerico(ByVal txtControl As Object, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function
    Public Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Validar_Email(ByVal Email As String) As Boolean
        Dim strTmp As String
        Dim n As Long
        Dim sEXT As String

        Validar_Email = True

        sEXT = Email

        Do While InStr(1, sEXT, ".") <> 0
            sEXT = Right(sEXT, Len(sEXT) - InStr(1, sEXT, "."))
        Loop

        If Email = "" Then
            Validar_Email = False
        ElseIf InStr(1, Email, "@") = 0 Then
            Validar_Email = False
        ElseIf InStr(1, Email, "@") = 1 Then
            Validar_Email = False
        ElseIf InStr(1, Email, "@") = Len(Email) Then
            Validar_Email = False
        ElseIf EXTisOK(sEXT) = False Then
            Validar_Email = False
        ElseIf Len(Email) < 6 Then
            Validar_Email = False
        End If
        strTmp = Email
        Do While InStr(1, strTmp, "@") <> 0
            n = 1
            strTmp = Right(strTmp, Len(strTmp) - InStr(1, strTmp, "@"))
        Loop
        If n > 1 Then
            Validar_Email = False
        End If

        Dim pos As Integer

        pos = InStr(1, Email, "@")

        If Mid(Email, pos + 1, 1) = "." Then
            Validar_Email = False
        End If
    End Function

    Public Function EXTisOK(ByVal sEXT As String) As Boolean
        Dim EXT As String
        EXT = ""
        EXTisOK = False
        If Left(sEXT, 1) <> "." Then sEXT = "." & sEXT
        sEXT = UCase(sEXT) 'just to avoid errors
        EXT = EXT & ".COM.EDU.GOB.NET.BIZ.ORG.TV"
        EXT = EXT & ".AF.AL.DZ.As.AD.AO.AI.AQ.AG.AP.AR.AM.AW.AU.AT.AZ.BS.BH.BD.BB.BY"
        EXT = EXT & ".BE.BZ.BJ.BM.BT.BO.BA.BW.BV.BR.IO.BN.BG.BF.MM.BI.KH.CM.CA.CV.KY"
        EXT = EXT & ".CF.TD.CL.CN.CX.CC.CO.KM.CG.CD.CK.CR.CI.HR.CU.CY.CZ.DK.DJ.DM.DO"
        EXT = EXT & ".TP.EC.EG.SV.GQ.ER.EE.ET.FK.FO.FJ.FI.CS.SU.FR.FX.GF.PF.TF.GA.GM.GE.DE"
        EXT = EXT & ".GH.GI.GB.GR.GL.GD.GP.GU.GT.GN.GW.GY.HT.HM.HN.HK.HU.IS.IN.ID.IR.IQ"
        EXT = EXT & ".IE.IL.IT.JM.JP.JO.KZ.KE.KI.KW.KG.LA.LV.LB.LS.LR.LY.LI.LT.LU.MO.MK.MG"
        EXT = EXT & ".MW.MY.MV.ML.MT.MH.MQ.MR.MU.YT.MX.FM.MD.MC.MN.MS.MA.MZ.NA"
        EXT = EXT & ".NR.NP.NL.AN.NT.NC.NZ.NI.NE.NG.NU.NF.KP.MP.NO.OM.PK.PW.PA.PG.PY"
        EXT = EXT & ".PE.PH.PN.PL.PT.PR.QA.RE.RO.RU.RW.GS.SH.KN.LC.PM.ST.VC.SM.SA.SN.SC"
        EXT = EXT & ".SL.SG.SK.SI.SB.SO.ZA.KR.ES.LK.SD.SR.SJ.SZ.SE.CH.SY.TJ.TW.TZ.TH.TG.TK"
        EXT = EXT & ".TO.TT.TN.TR.TM.TC.TV.UG.UA.AE.UK.US.UY.UM.UZ.VU.VA.VE.VN.VG.VI"
        EXT = EXT & ".WF.WS.EH.YE.YU.ZR.ZM.ZW"
        EXT = UCase(EXT) 'just to avoid errors
        If InStr(1, EXT, sEXT, 0) <> 0 Then
            EXTisOK = True
        End If
    End Function

    Public Function validar_url(ByVal url As String) As Boolean
        'Dim EmailRegex As Regex = New Regex("^(ht|f)tp(s?)\:\/\/www.([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)( [a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$" )
        Dim EmailRegex As Regex = New Regex("^(ht|f)tp(s?)\:\/\/www.([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*")
        Dim M As Match = EmailRegex.Match(url)
        If M.Success Then
            Return False
        Else
            Return True
        End If
    End Function


    Public Function ucWords(ByVal texto As String) As String
        Dim cadenas() As String
        Dim cadenaAux As String
        Dim letra As String
        Dim cadenaReturn As String
        Dim pos As Integer
        cadenaReturn = ""
        cadenaAux = LCase(texto)
        cadenas = cadenaAux.Split(" ")
        For pos = 0 To cadenas.Length - 1
            If cadenas(pos) <> "" Then
                letra = Left(cadenas(pos), 1)
                cadenaReturn = cadenaReturn & UCase(Left(cadenas(pos), 1)) & Mid(cadenas(pos), 2)
                If pos <> cadenas.Length - 1 Then
                    cadenaReturn = cadenaReturn & " "
                End If
            End If
        Next
        Return cadenaReturn
    End Function

    Public Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function
    Public Sub Centrar(ByVal Objeto As Object)
        ' Centrar un Formulario ...  
        If TypeOf Objeto Is Form Then
            Dim frm As Form = CType(Objeto, Form)
            With Screen.PrimaryScreen.WorkingArea ' Dimensiones de la pantalla sin el TaskBar  
                frm.Top = (.Height - frm.Height) \ 2
                frm.Left = (.Width - frm.Width) \ 2
            End With

            ' Centrar un control dentro del contenedor  
        Else
            ' referencia al control  
            Dim c As Control = CType(Objeto, Control)

            'le  establece el top y el Left dentro del Parent  
            With c
                .Top = (.Parent.ClientSize.Height - c.Height) \ 2
                .Left = (.Parent.ClientSize.Width - c.Width) \ 2
            End With
        End If
    End Sub
    Public Sub obtener_id_sucursal()
        'Conectar()
        rs.Open("SELECT configuracion.id_sucursal,sucursal.alias from configuracion JOIN sucursal ON sucursal.id_sucursal=configuracion.id_sucursal", conn)
        If rs.RecordCount > 0 Then
            global_id_sucursal = rs.Fields("id_sucursal").Value
            global_nombre_sucursal = rs.Fields("alias").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Public Function obtener_miniatura(ByVal image As Object, Optional ByVal normal_size As Integer = 0) As System.Drawing.Image
        Dim bThumb As Byte()
        Dim miniatura As System.Drawing.Image
        Dim thumb As System.Drawing.Image
        If Not IsDBNull(image) Then
            bThumb = CType(image, Byte())
            thumb = New Bitmap(Bytes_Imagen(bThumb))
        Else
            thumb = ventas.My.Resources._50CENTAVOS
        End If
        miniatura = thumb.GetThumbnailImage(30, 30, Nothing, New IntPtr)
        If normal_size = 0 Then
            Return miniatura
        Else
            Return thumb
        End If

    End Function
    Public Function corte_x(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        'Conectar()
        Dim TOTAL As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND venta.id_empleado_caja='" & global_id_empleado & "' AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' "
        End If
        'rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' " & filtro & " AND venta.status='CERRADA' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE venta.id_corte='0' " & filtro & " AND venta.status='CERRADA' AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                TOTAL = TOTAL + CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        Return TOTAL
    End Function
    Public Function total_efectivo(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        'Conectar()
        Dim TOTAL As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = " AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "' "
        End If
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas " &
                "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago " &
                "JOIN venta ON venta.id_venta=pagos_ventas.id_venta " &
                "WHERE pagos_ventas.id_corte='0' " & filtro & " AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn) ' pagois en efectivo
        '"WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND pagos_ventas.id_corte='0' " & filtro & " AND pagos_ventas.status<>'CANCELADO' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                TOTAL = CDbl(rs.Fields("total").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        Return TOTAL
    End Function
    Public Function retiros(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        'Conectar()
        Dim TOTAL As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND id_empleado='" & global_id_empleado & "'"
        End If
        'rs.Open("SELECT CASE WHEN SUM(cantidad) IS NULL THEN 0 ELSE SUM(cantidad)  END  as total from retiros WHERE date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " AND bandera_corte_caja=0", conn)
        rs.Open("SELECT CASE WHEN SUM(cantidad) IS NULL THEN 0 ELSE SUM(cantidad)  END  as total from retiros WHERE 1 " & filtro & " AND bandera_corte_caja=0", conn)
        If rs.RecordCount > 0 Then
            TOTAL = rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        Return TOTAL
    End Function
    Public Function depositos(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        'Conectar()
        Dim TOTAL As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND id_empleado_caja='" & global_id_empleado & "'"
        End If
        rs.Open("SELECT CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  as total from depositos WHERE bandera_corte_caja=0 " & filtro & "", conn)
        ' rs.Open("SELECT CASE WHEN SUM(importe) IS NULL THEN 0 ELSE SUM(importe)  END  as total from depositos WHERE date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " AND bandera_corte_caja=0", conn)
        If rs.RecordCount > 0 Then
            TOTAL = rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        Return TOTAL
    End Function
    Public Function devoluciones(Optional ByVal todoslosuduarios As Integer = 0) As Decimal 'suma de total de devoluciones en efectivo
        'Conectar()
        Dim TOTAL As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND id_empleado='" & global_id_empleado & "'"
        End If
        'rs.Open("SELECT CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " AND (tipo_devolucion=3 OR tipo_devolucion=4) AND bandera_corte_caja=0", conn)
        rs.Open("SELECT CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE 1 " & filtro & " AND (tipo_devolucion=3 OR tipo_devolucion=4) AND bandera_corte_caja=0", conn)
        If rs.RecordCount > 0 Then
            TOTAL = rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        Return TOTAL
    End Function
    Public Function fondo_caja_inicial(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        'Conectar()
        Dim fondo_caja As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND id_empleado='" & global_id_empleado & "'"
        End If
        'rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 " & filtro & " AND DATE(fecha)='" & Format(Today, "yyyy-MM-dd") & "'", conn)
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 " & filtro & "", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                fondo_caja += rs.Fields("saldo_inicial").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        Return fondo_caja
    End Function
    Public Function total_abonos_creditos(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        'Conectar()
        Dim total_abonos As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND pagos_ventas.id_empleado_caja='" & global_id_empleado & "'"
        End If
        'rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " AND venta.status='PENDIENTE' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1'  GROUP BY forma_pago.nombre", conn)
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE 1 " & filtro & " AND venta.status='PENDIENTE' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1'  GROUP BY forma_pago.nombre", conn) ' pagos en efectivo
        If rs.RecordCount > 0 Then
            total_abonos += rs.Fields("total").Value
        End If
        rs.Close()
        'rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " AND venta.status='CERRADA' AND DATE(venta.fecha)<>'" & Format(Today, "yyyy-MM-dd") & "' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1'  GROUP BY forma_pago.nombre", conn)
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE 1 " & filtro & " AND venta.status='CERRADA' AND DATE(venta.fecha)<>'" & Format(Today, "yyyy-MM-dd") & "' AND forma_pago.id_forma_pago=1 AND pagos_ventas.afecta_caja='1'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then

            total_abonos += rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        Return total_abonos
    End Function
    Public Function saldo_caja(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        Dim total_ventas As Decimal = 0
        Dim total_retiros As Decimal = 0
        Dim saldo_inicial As Decimal = 0
        Dim total_abonos As Decimal = 0
        Dim total_devol As Decimal = 0
        Dim total_depositos As Decimal = 0
        Dim pago_proveedor_efectivo As Decimal = 0
        Dim saldo As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = "AND id_empleado='" & global_id_empleado & "'"
        End If
        'Conectar()
        'rs.Open("SELECT saldo_inicial from caja_saldo_inicial WHERE date(fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " AND bandera_corte_caja=0", conn)
        rs.Open("SELECT saldo_inicial from caja_saldo_inicial WHERE 1 " & filtro & " AND bandera_corte_caja=0", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                saldo_inicial = saldo_inicial + rs.Fields("saldo_inicial").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()

        If todoslosuduarios = 0 Then
            total_ventas = total_efectivo()
            total_retiros = retiros()
            total_depositos = depositos()
            total_abonos = total_abonos_creditos()
            pago_proveedor_efectivo = pago_proveedores_efectivo()
            total_devol = devoluciones()

        Else
            total_ventas = total_efectivo(1)
            total_retiros = retiros(1)
            total_depositos = depositos(1)
            total_abonos = total_abonos_creditos(1)
            pago_proveedor_efectivo = pago_proveedores_efectivo(1)
            total_devol = devoluciones(1)
        End If
        saldo = saldo_inicial + total_ventas + total_depositos - total_retiros - pago_proveedor_efectivo - total_devol
        Return saldo
    End Function
    Public Function pago_proveedores_efectivo(Optional ByVal todoslosuduarios As Integer = 0) As Decimal
        Dim pago_prov_efectivo As Decimal = 0
        Dim filtro As String = ""
        If todoslosuduarios = 0 Then
            filtro = " AND pagos_compras.id_empleado_pago='" & global_id_empleado & "'"
        End If
        'Conectar()
        'rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_compras.importe)) THEN 0 ELSE SUM(pagos_compras.importe) END AS total FROM pagos_compras " & _
        ' "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_compras.id_forma_pago " & _
        ' "WHERE DATE(pagos_compras.fecha)='" & Format(Today, "yyyy-MM-dd") & "' " & filtro & " " & _
        '  "AND forma_pago.id_forma_pago=1 AND pagos_compras.afecta_caja='1'", conn)

        rs.Open("SELECT CASE WHEN ISNULL(SUM(pagos_compras.importe)) THEN 0 ELSE SUM(pagos_compras.importe) END AS total FROM pagos_compras " &
                "JOIN forma_pago ON forma_pago.id_forma_pago=pagos_compras.id_forma_pago " &
                "WHERE 1 " & filtro & " " &
                "AND forma_pago.id_forma_pago=1 AND pagos_compras.afecta_caja='1'", conn)

        If rs.RecordCount > 0 Then
            pago_prov_efectivo = rs.Fields("total").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return pago_prov_efectivo
    End Function
    Public Function pedidos_para_hoy() As Boolean
        Dim existen_pedidos As Boolean = False
        'Conectar()
        rs.Open("SELECT id_pedido FROM pedido_clientes WHERE DATE(fecha_entrega)='" & Format(Today, "yyyy-MM-dd") & "' AND surtido=0 AND status='PENDIENTE'", conn)
        If rs.RecordCount > 0 Then
            existen_pedidos = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return existen_pedidos
    End Function
    Public Function Letras(ByVal Valor As Double) As String
        Dim Largo As Integer

        Dim Decimales As Double = 0
        Dim strDecimal As String = ""

        Largo = Len(CStr(Format(CDbl(Valor), "#,###.00")))

        Decimales = Mid(CStr(Format(CDbl(Valor), "#,###.00")), Largo - 2)
        Select Case Decimales
            Case 0 : strDecimal = "00"
            Case 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 : strDecimal = (Mid(CStr(Decimales), 3, 2)) * 10
            Case Is < 100 : strDecimal = Mid(CStr(Decimales), 3, 2)
        End Select
        Valor = Valor - Decimales
        Letras = Num2Text(CInt(Valor)) & " PESOS " & strDecimal & "/100" & " M.N."

    End Function
    Public Function Num2Text(ByVal value As Double) As String

        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function
    Public Function nombre_forma_pago(ByVal id_forma As Integer) As String
        Dim nombre_pago As String = ""
        Dim ws As New ADODB.Recordset
        ws.Open("SELECT nombre FROM forma_pago WHERE id_forma_pago='" & id_forma & "'", conn)
        If ws.RecordCount > 0 Then
            nombre_pago = ws.Fields("nombre").Value
        End If
        ws.Close()
        Return nombre_pago
    End Function
    Public Function obtener_venta_peso(ByVal id_producto As Integer) As Integer
        Dim vp As Integer = 0
        'Conectar()
        rs.Open("SELECT venta_peso FROM producto WHERE id_producto=" & id_producto, conn)
        If rs.RecordCount > 0 Then
            vp = rs.Fields("venta_peso").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return vp
    End Function
    Public Function obtener_total_desc_venta(ByVal id_venta As Integer) As Decimal
        Dim tdes As Decimal = 0
        'Conectar()
        rs.Open("SELECT total_descuento FROM venta WHERE id_venta=" & id_venta, conn)
        If rs.RecordCount > 0 Then
            tdes = rs.Fields("total_descuento").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return tdes
    End Function
    Public Function obtener_aplicar_redondeo(ByVal id_cliente As Integer, Optional ByVal conexion_abierta As Boolean = False)
        Dim rw As New ADODB.Recordset
        Dim aplicar As Boolean = True
        If conexion_abierta = False Then
            'Conectar()
        End If
        rw.Open("SELECT aplicar_redondeo FROM cliente_precio WHERE id_cliente=" & id_cliente, conn)
        If rw.RecordCount > 0 Then
            If rw.Fields("aplicar_redondeo").Value = 0 Then
                aplicar = False
            End If
        End If
        rw.Close()
        If conexion_abierta = False Then
            'conn.close()
            'conn = Nothing
        End If
        Return aplicar
    End Function
    Public Function verificar_producto_paquete(ByVal id_producto As Integer) As Boolean
        Dim espaquete As Boolean = False
        'Conectar()
        rs.Open("SELECT paquete FROM producto WHERE id_producto=" & id_producto, conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("paquete").Value = 1 Then
                espaquete = True
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return espaquete
    End Function
    Public Sub rellenar_catalogo_combobox(ByVal id As String, ByVal valor As String, ByVal tabla_db As String, ByVal combobox As ComboBox, Optional ByVal opcion_general As Boolean = False, Optional ByVal condicion As String = "", Optional ByVal cadena_concatenar As String = "")
        Try
            Dim recordset As New ADODB.Recordset
            combobox.Items.Clear()
            If opcion_general = True Then
                combobox.Items.Add(New myItem("0", "Todos"))
            End If

            If cadena_concatenar = "" Then
                recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & condicion & "", conn)
            Else
                recordset.Open("SELECT " & id & "," & cadena_concatenar & " FROM " & tabla_db & condicion & "", conn)
            End If

            If recordset.RecordCount > 0 Then
                While Not recordset.EOF
                    combobox.Items.Add(New myItem(recordset.Fields(id).Value, recordset.Fields(valor).Value))
                    recordset.MoveNext()
                End While
            End If
            recordset.Close()

            If combobox.Items.Count > 0 Then
                combobox.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub seleccionar_catalogo(ByVal id_catalogo As Integer, ByVal cb As ComboBox)
        '-----buscamos el tipo servicio_tecnico
        For x = 0 To cb.Items.Count - 1
            If id_catalogo = CType(cb.Items(x), myItem).Value Then
                cb.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
End Module



