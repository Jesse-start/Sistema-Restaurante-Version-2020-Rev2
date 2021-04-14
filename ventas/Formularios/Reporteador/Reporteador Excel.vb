Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Excel = Microsoft.Office.Interop.Excel

Module Reporteador

    Dim excel_app As New Excel.Application()
    Dim wBook As Excel.Workbook
    Dim wSheet As Excel.Worksheet
    Dim Rango As Excel.Range

    Dim puntero_fila As Integer = 6
    Dim puntero_columna As Integer = 2
    Dim longitud_columna(15) As Integer

    Private Sub limpiar_longitud_columna()
        For x = 0 To 15
            longitud_columna(x) = 0
        Next
    End Sub

    Public Sub Incializar_reporte_excel(nombre_reporte As String)
        ' Dim excel_app As New Excel.Application()
        'Dim wBook As Excel.Workbook
        'Dim wSheet As Excel.Worksheet
        ' Dim Rango As Excel.Range

        wBook = excel_app.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        wSheet.PageSetup.TopMargin = 1
        wSheet.PageSetup.BottomMargin = 1
        wSheet.PageSetup.LeftMargin = 1
        wSheet.PageSetup.RightMargin = 1


        wSheet.Name = "Reporte"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png", _
CType(False, Microsoft.Office.Core.MsoTriState), _
CType(True, Microsoft.Office.Core.MsoTriState), 30, 2, 150, 75)


        Dim col As Integer = 0
        Dim row As Integer = 0

        excel_app.Cells(2, 7) = lineas_reporte(0)
        Rango = wSheet.Range(excel_app.Cells(2, 7), excel_app.Cells(2, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(3, 7) = lineas_reporte(1)
        Rango = wSheet.Range(excel_app.Cells(3, 7), excel_app.Cells(3, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = False
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(4, 7) = lineas_reporte(2)
        Rango = wSheet.Range(excel_app.Cells(4, 7), excel_app.Cells(4, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = False
        Rango.Font.Size = 10
        Rango.Merge()
        excel_app.Cells(5, 7) = lineas_reporte(3)
        Rango = wSheet.Range(excel_app.Cells(5, 7), excel_app.Cells(5, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = False
        Rango.Font.Size = 10
        Rango.Merge()


        excel_app.Cells(10, 3) = UCase(nombre_reporte)
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

    End Sub

    Public Sub Agregar_carecteristica_reporte_excel(caracteristica As String, dato As String)
        excel_app.Cells(puntero_fila, 10) = UCase(caracteristica) & ":" & dato
        Rango = wSheet.Range(excel_app.Cells(puntero_fila, 7), excel_app.Cells(puntero_fila, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        puntero_fila += 1
    End Sub


    Public Sub agregar_categoria_reporte_excel(nombre_categoria As String, numero_columnas As Integer)

        limpiar_longitud_columna()
        puntero_columna = 2

        puntero_fila += 2
        excel_app.Cells(puntero_fila, 2) = nombre_categoria
        Rango = wSheet.Range(excel_app.Cells(puntero_fila, 2), excel_app.Cells(puntero_fila, 15))
        celda_pbk(excel_app.Cells(puntero_fila, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        puntero_fila += 1
    End Sub
    Public Sub agregar_columna_categoria_excel(ByVal num As Integer, nombre_columna As String, num_celdas As Integer)

        longitud_columna(num) = num_celdas
        excel_app.Cells(puntero_fila, puntero_columna) = nombre_columna
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(puntero_fila, puntero_columna), excel_app.Cells(puntero_fila, puntero_columna + num_celdas - 1))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        ' puntero_fila
        puntero_columna += num_celdas
    End Sub

    Public Sub agregar_dato_columna_excel(ByVal num As Integer, ByVal valor_columna As String)
        If num = 1 Then
            puntero_fila += 1
            puntero_columna = 2
        End If

        excel_app.Cells(puntero_fila, puntero_columna) = valor_columna
        Rango = wSheet.Range(excel_app.Cells(puntero_fila, puntero_columna), excel_app.Cells(puntero_fila, puntero_columna + longitud_columna(num) - 1))
        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Merge()
        puntero_columna += longitud_columna(num)
    End Sub
    Public Sub agregar_celda_total_excel(nombre As String, valor As String, longitud_nombre As Integer, longitud_valor As Integer, columna_inicio As Integer)

        puntero_fila += 1

        excel_app.Cells(puntero_fila, columna_inicio) = nombre
        celda_total(excel_app.Cells(puntero_fila, columna_inicio))
        Rango = wSheet.Range(excel_app.Cells(puntero_fila, columna_inicio), excel_app.Cells(puntero_fila, columna_inicio + longitud_nombre - 1))
        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Merge()


        excel_app.Cells(puntero_fila, columna_inicio + longitud_nombre) = valor
        celda_total(excel_app.Cells(puntero_fila, columna_inicio + longitud_nombre))
        Rango = wSheet.Range(excel_app.Cells(puntero_fila, columna_inicio + longitud_nombre), excel_app.Cells(puntero_fila, columna_inicio + longitud_nombre + longitud_valor - 1))
        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Merge()

    End Sub
    Public Sub agregar_espacio_excel(ByVal cantidad As Integer)

        puntero_fila += cantidad
    End Sub

    Public Sub finalizar_excel()
        puntero_columna = 2
        puntero_fila = 6
        limpiar_longitud_columna()

        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/tmpCotizacion.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                System.IO.File.Delete(strFileName)
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & "Cierre dicho Archivo e Intente Nuevamente")
            End Try
        End If

        Try
            wBook.SaveAs(strFileName)
            excel_app.Workbooks.Open(strFileName)
            excel_app.Visible = True
            wBook.Close()

            releaseObject(wBook)
            releaseObject(wSheet)
            releaseObject(excel_app)

        Catch ex As Exception
        End Try

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub celda_pbk(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.LightSteelBlue
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub
    Private Sub celda_total(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.DarkGreen
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub
    Private Sub celda_atencion(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.DarkRed
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub
End Module
