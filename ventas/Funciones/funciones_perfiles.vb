Module funciones_perfiles
    Public txt_perfiles As String = System.IO.Directory.GetCurrentDirectory() & "/perfiles.txt"
    Public txt_temporal As String = System.IO.Directory.GetCurrentDirectory() & "/tmp.txt"

    Public carpeta_campos As String = System.IO.Directory.GetCurrentDirectory() & "/campos/"

    Dim sLine As String = ""

    Public campos As New ArrayList()
    Public perfiles As New ArrayList()

    Public Sub leer_perfiles()
        If System.IO.File.Exists(txt_perfiles) = True Then
            Dim objReader As New System.IO.StreamReader(txt_perfiles)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    perfiles.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()
        Else
            Dim objWriter As New System.IO.StreamWriter(txt_perfiles, False)
            objWriter.Close()
        End If
    End Sub

    Public Sub borrar_archivo(ByVal archivo As String)
        My.Computer.FileSystem.DeleteFile(archivo)
    End Sub

    Public Sub agregar_campo(ByVal campo As String, ByVal archivo_campos As String)
        Dim objWriter As New System.IO.StreamWriter(archivo_campos, True)
        objWriter.WriteLine(campo)
        objWriter.Close()
    End Sub

    Public Sub leer_campos(ByVal archivo_campos As String)
        Dim txt_campos As String = carpeta_campos & archivo_campos & ".txt"
        If Not System.IO.Directory.Exists(carpeta_campos) Then
            System.IO.Directory.CreateDirectory(carpeta_campos)
        End If

        If System.IO.File.Exists(txt_campos) = True Then
            Dim objReader As New System.IO.StreamReader(txt_campos)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    campos.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()
        Else
            Dim objWriter As New System.IO.StreamWriter(txt_campos, False)
            objWriter.Close()
        End If
    End Sub
    Public Sub borrar_perfil(ByVal posicion As String)
        Dim objReader As New System.IO.StreamReader(txt_perfiles)
        If System.IO.File.Exists(txt_perfiles) = True Then
            Dim i As Integer = 0
            Dim objWriter As New System.IO.StreamWriter(txt_temporal, False)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    If posicion <> i Then
                        objWriter.WriteLine(sLine)
                    End If
                End If
                i = i + 1
            Loop Until sLine Is Nothing

            objReader.Close()
            objWriter.Close()

            borrar_archivo(txt_perfiles)
            My.Computer.FileSystem.RenameFile(txt_temporal, "perfiles.txt")

        End If
    End Sub

    Public Sub borrar_campo(ByVal posicion As String, ByVal archivo_campos As String)
        Dim txt_campo As String = System.IO.Directory.GetCurrentDirectory() & "/campos/" & archivo_campos & ".txt"
        Dim txt_temporal As String = System.IO.Directory.GetCurrentDirectory() & "/campos/tmp.txt"
        Dim objReader As New System.IO.StreamReader(txt_campo)
        If System.IO.File.Exists(txt_campo) = True Then
            Dim i As Integer = 0
            Dim objWriter As New System.IO.StreamWriter(txt_temporal, False)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    If posicion <> i Then
                        objWriter.WriteLine(sLine)
                    End If
                End If
                i = i + 1
            Loop Until sLine Is Nothing

            objReader.Close()
            objWriter.Close()

            borrar_archivo(txt_campo)
            My.Computer.FileSystem.RenameFile(txt_temporal, archivo_campos & ".txt")
        End If
    End Sub

    Public Sub agregar_perfil(ByVal perfil As String)
        Dim objWriter As New System.IO.StreamWriter(txt_perfiles, True)
        objWriter.WriteLine(perfil)
        objWriter.Close()
    End Sub

    Public Sub agregar_perfil(ByVal perfil As String, ByVal posicion As Integer)
        Dim objReader As New System.IO.StreamReader(txt_perfiles)
        If System.IO.File.Exists(txt_perfiles) = True Then
            Dim i As Integer = 0
            Dim objWriter As New System.IO.StreamWriter(txt_temporal, False)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    If posicion <> i Then
                        objWriter.WriteLine(sLine)
                    Else
                        objWriter.WriteLine(perfil)
                    End If
                End If
                i = i + 1
            Loop Until sLine Is Nothing

            objReader.Close()
            objWriter.Close()
            My.Computer.FileSystem.DeleteFile(txt_perfiles)
            My.Computer.FileSystem.RenameFile(txt_temporal, "perfiles.txt")
        End If
    End Sub

    
End Module
