Imports System.Runtime.InteropServices
Imports System.ComponentModel

Module _shell

#Region "Constantes, Estructura y Funciones de la API"

    Private WAIT_INFINITE As System.UInt32 = Convert.ToUInt32(&HFFFFFFF)
    'Private Const WAIT_INFINITE As Int32 = &HFFFFFFFF

    Private Const STILL_ACTIVE As Int32 = &H103

    Private Const LOGON_WITH_PROFILE As Int32 = &H1
    Private Const LOGON_NETCREDENTIALS_ONLY As Int32 = &H2
    Private Const CREATE_DEFAULT_ERROR_MODE As Int32 = &H4000000
    Private Const CREATE_NEW_CONSOLE As Int32 = &H10
    Private Const CREATE_NEW_PROCESS_GROUP As Int32 = &H200
    Private Const CREATE_SEPARATE_WOW_VDM As Int32 = &H800
    Private Const CREATE_SUSPENDED As Int32 = &H4
    Private Const CREATE_UNICODE_ENVIRONMENT As Int32 = &H400
    Private Const ABOVE_NORMAL_PRIORITY_CLASS As Int32 = &H8000
    Private Const BELOW_NORMAL_PRIORITY_CLASS As Int32 = &H4000
    Private Const HIGH_PRIORITY_CLASS As Int32 = &H80
    Private Const IDLE_PRIORITY_CLASS As Int32 = &H40
    Private Const NORMAL_PRIORITY_CLASS As Int32 = &H20
    Private Const REALTIME_PRIORITY_CLASS As Int32 = &H100

    Private Const SW_HIDE As Int32 = 0
    Private Const STARTF_USESHOWWINDOW As Int32 = &H1

    Private processInfo As New PROCESS_INFORMATION()
    Private startInfo As New STARTUPINFO()

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure PROCESS_INFORMATION
        Friend hProcess As IntPtr
        Friend hThread As IntPtr
        Friend dwProcessId As Int32
        Friend dwThreadId As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure STARTUPINFO
        Friend cb As Int32
        Friend lpReserved As IntPtr
        Friend lpDesktop As IntPtr
        Friend lpTitle As IntPtr
        Friend dwX As Int32
        Friend dwY As Int32
        Friend dwXSize As Int32
        Friend dwYSize As Int32
        Friend dwXCountChars As Int32
        Friend dwYCountChars As Int32
        Friend dwFillAttribute As Int32
        Friend dwFlags As Int32
        Friend wShowWindow As Short
        Friend cbReserved2 As Short
        Friend lpReserved2 As IntPtr
        Friend hStdInput As IntPtr
        Friend hStdOutput As IntPtr
        Friend hStdError As IntPtr
    End Structure

    <Flags()> _
    Private Enum HANDLE_TYPES
        STD_INPUT_HANDLE = -10
        STD_OUTPUT_HANDLE = -11
        STD_ERROR_HANDLE = -12
    End Enum

    <Flags()> _
    Private Enum START_UP_INFO_FLAGS
        STARTF_USESHOWWINDOW = &H1
        STARTF_USESIZE = &H2
        STARTF_USEPOSITION = &H4
        STARTF_USECOUNTCHARS = &H8
        STARTF_USEFILLATTRIBUTE = &H10
        STARTF_RUNFULLSCREEN = &H20
        STARTF_FORCEONFEEDBACK = &H40
        STARTF_FORCEOFFFEEDBACK = &H80
        STARTF_USESTDHANDLES = &H100
    End Enum

    <DllImport("Kernel32.dll", SetLastError:=True)> _
    Private Function CloseHandle(ByVal handle As IntPtr) As Boolean
        ' Sin código de implementación
    End Function

    <DllImport("advapi32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Private Function CreateProcessWithLogonW( _
            ByVal lpUsername As String, _
            ByVal lpDomain As String, _
            ByVal lpPassword As String, _
            ByVal dwLogonFlags As UInt32, _
            ByVal lpApplicationName As String, _
            ByVal lpCommandLine As String, _
            ByVal dwCreationFlags As UInt32, _
            ByVal lpEnvironment As UIntPtr, _
            ByVal lpCurrentDirectory As String, _
            ByRef lpStartupInfo As STARTUPINFO, _
            ByRef lpProcessInfo As PROCESS_INFORMATION) As Int32
        ' Sin código de implementación
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)> _
    Private Function GetExitCodeProcess( _
        ByVal hProcess As IntPtr, _
        ByRef lpExitCode As UInt32) As Int32
        ' Sin código de implementación
    End Function

    <DllImport("Kernel32.dll", SetLastError:=True)> _
    Private Function GetStdHandle(ByVal nStdHandle As IntPtr) As IntPtr
        ' Sin código de implementación
    End Function

    <DllImport("Kernel32.dll", SetLastError:=True)> _
    Private Function WaitForSingleObject( _
        ByVal handle As IntPtr, _
        ByVal milliseconds As UInt32) As UInt32
        ' Sin código de implementación
    End Function

    Friend Function RunAs( _
        ByVal application As String, _
        ByVal commandLine As String, _
        ByVal userName As String, _
        ByVal password As String, _
        ByVal domain As String, _
        ByVal hide As Boolean) As UInt32

        Dim si As STARTUPINFO
        Dim piProcess As PROCESS_INFORMATION
        Dim intReturn As Int32
        Dim exitCode As UInt32
        Dim currentDirectory As String = IO.Directory.GetCurrentDirectory

        If (commandLine Is Nothing) Then commandLine = String.Empty

        si.cb = Marshal.SizeOf(si)

        If hide Then
            si.dwFlags = STARTF_USESHOWWINDOW
            si.wShowWindow = SW_HIDE
        End If

        Try
            intReturn = CreateProcessWithLogonW( _
                userName, _
                domain, _
                password, _
                LOGON_WITH_PROFILE, _
                application, _
                commandLine, _
                NORMAL_PRIORITY_CLASS Or _
                    CREATE_DEFAULT_ERROR_MODE Or _
                    CREATE_NEW_CONSOLE Or _
                    CREATE_NEW_PROCESS_GROUP, _
                UIntPtr.Zero, _
                currentDirectory, _
                si, _
                piProcess)

            If intReturn = 0 Then
                intReturn = Err.LastDllError
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If

            ' Esperar a que finalice la aplicación
            '
            Call WaitForSingleObject(piProcess.hProcess, WAIT_INFINITE)

            ' Obtenemos el valor de retorno
            '
            Dim ret As Int32 = GetExitCodeProcess(piProcess.hProcess, exitCode)

            Return exitCode

        Catch ex As Exception
            Throw New Win32Exception(Marshal.GetLastWin32Error())

        Finally
            ' Cerrar el manipulador del proceso
            CloseHandle(piProcess.hProcess)

            ' Cerrar el manipulador del subproceso creado
            CloseHandle(piProcess.hThread)

        End Try

    End Function

#End Region

End Module
