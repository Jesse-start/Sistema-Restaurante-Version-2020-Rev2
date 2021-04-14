Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frm_reporteador
    ' Dim Excel As Object = CreateObject("Excel.application")
    Dim abonos(4) As Decimal
    Private Sub btn_reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporte.Click
        
    End Sub
    Private Sub limpiar_abonos()
        For x = 0 To 22
            abonos(x) = 0
        Next
    End Sub
    'Public Function nombre_forma_pago(ByVal id_forma As Integer) As String
    'Dim nombre_pago As String = ""
    'If id_forma = 0 Then
    '       nombre_pago = "Efectivo"
    'ElseIf id_forma = 1 Then
    '       nombre_pago = "Transferencia"
    'ElseIf id_forma = 2 Then
    '       nombre_pago = "Cheque"
    'ElseIf id_forma = 3 Then
    '       nombre_pago = "Nota de credito"
    'ElseIf id_forma = 4 Then
    '       nombre_pago = "Tarjeta Bancaria"
    'ElseIf id_forma = 5 Then
    '       nombre_pago = "Cupones"
    'End If
    'Return nombre_pago
    'End Function
    Private Sub generar_inventario_actual()

        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0
        wBook = excel_app.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        wSheet.PageSetup.TopMargin = 1
        wSheet.PageSetup.BottomMargin = 1
        wSheet.PageSetup.LeftMargin = 1
        wSheet.PageSetup.RightMargin = 1

        wSheet.Name = "Inventario"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png", _
CType(False, Microsoft.Office.Core.MsoTriState), _
CType(True, Microsoft.Office.Core.MsoTriState), 30, 2, 150, 75)

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
        '  excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        '  Rango = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = False
        ' Rango.Font.Size = 10
        'Rango.Merge()
        excel_app.Cells(8, 7) = UCase(dtp_fecha.Value.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        'excel_app.Cells(8, 10) = "Colaborador: " & cb_usuario.Text
        'Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()

        excel_app.Cells(10, 3) = "INVENTARIO"
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "INVENTARIO"
        Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 13))
        celda_pbk(excel_app.Cells(12, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(13, 2) = "CODIGO"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "DESCRIPCIÓN"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 8) = "UNIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 8), excel_app.Cells(13, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "CANTIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        'excel_app.Cells(13, 12) = "PRECIO"
        'celda_pbk(excel_app.Cells(13, 3))
        'Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Font.Bold = True
        'Rango.Merge()
        'row = 14
        Dim filtro As String = ""
        If cb_ordenar.Text = "Cantidad" Then
            filtro = "ORDER BY producto_sucursal.cantidad"
        ElseIf cb_ordenar.Text = "Codigo" Then
            filtro = "ORDER BY producto.codigo"
        ElseIf cb_ordenar.Text = "Producto" Then
            filtro = "ORDER BY producto.nombre"
        End If
        If rb_asc.Checked = True Then
            filtro = filtro & " ASC"
        Else
            filtro = filtro & " DESC"
        End If
        row = 15
        '---OBTENEMOS EL INVENTARO DE PRODUCTOS
        'Conectar()
        rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,producto.codigo,unidad.nombre AS unidad,producto_sucursal.cantidad FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad JOIN producto_sucursal ON producto_sucursal.id_producto=producto.id_producto " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 2) = rs.Fields("codigo").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("nombre").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = ""
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While
        Else
            row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing

        '------FIN OBTENER PRODUCTOS DE PUBLICO EN GENERAL


        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/inventario.xls"
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
        objeto.Interior.Color = Color.RoyalBlue
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

    Private Sub Btn_Inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inventario.Click
        generar_inventario_actual()
    End Sub

    Private Sub cargar_empleados()
        cb_usuario.Items.Clear()
        cb_usuario.Text = ""
        cb_usuario_asistencia.Items.Clear()
        cb_usuario_asistencia.Text = ""
        'Conectar()
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            cb_usuario.Items.Add(New myItem(0, "Todos los usuarios", 0, 0))
            cb_usuario_asistencia.Items.Add(New myItem(0, "Todos los usuarios", 0, 0))
            While Not rs.EOF
                cb_usuario.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, 0, 0))
                cb_usuario_asistencia.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub obtener_clientes()
        cb_cliente.Items.Clear()
        cb_cliente.Text = ""
        cb_cliente.Items.Add(New myItem("0", "TODOS"))
        'Conectar()
        ' rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  CONCAT(empresa.alias,' [',empresa.razon_social,']') ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente<>1 ORDER by cliente.id_cliente", conn)
        rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa ORDER by cliente.id_cliente", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_cliente.Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = nothing

    End Sub
    Private Sub frm_reporteador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        cargar_empleados()
        obtener_clientes()
        'Reporteador.Show()

    End Sub

    Private Sub Btb_Creditos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_creditos.Click
        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0

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
        'excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        'Rango = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        ''Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = False
        'Rango.Font.Size = 10
        'Rango.Merge()
        excel_app.Cells(8, 7) = UCase(dtp_fecha.Value.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        ' excel_app.Cells(8, 10) = "Colaborador: " & cb_usuario.Text
        ' Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        ' Rango.Font.Bold = True
        ' Rango.Font.Size = 10
        ' Rango.Merge()


        ' excel_app.Cells(10, 3) = "REPORTE DE CUENTAS POR COBRAR"
        ' Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        '  Rango.Font.Size = 12
        '  Rango.Merge()

        '  excel_app.Cells(12, 2) = "CUENTAS POR COBRAR"
        '  Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 15))
        '  celda_pbk(excel_app.Cells(12, 2))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        ' Rango.Font.Bold = True
        ' Rango.Font.Size = 10
        ' Rango.Merge()

        ' excel_app.Cells(13, 2) = "TICKET FOLIO"
        'celda_pbk(excel_app.Cells(13, 2))
        ' Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '  Rango.Font.Bold = True
        ' Rango.Merge()

        ' excel_app.Cells(13, 4) = "FECHA - HORA"
        'celda_pbk(excel_app.Cells(13, 3))
        ' Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 5))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        ' Rango.Merge()

        '  excel_app.Cells(13, 6) = "CLIENTE"
        'celda_pbk(excel_app.Cells(13, 3))
        '  Rango = wSheet.Range(excel_app.Cells(13, 6), excel_app.Cells(13, 9))
        '  Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '  Rango.Font.Bold = True
        ' Rango.Merge()

        'excel_app.Cells(13, 10) = "SUBTOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        ' Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        '   Rango.Merge()

        ' excel_app.Cells(13, 12) = "I.V.A."
        'celda_pbk(excel_app.Cells(13, 3))
        '  Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        ' Rango.Merge()

        '  excel_app.Cells(13, 14) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        '  Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 15))
        '  Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '  Rango.Font.Bold = True
        ' Rango.Merge()
        row = 14
        Dim filtro As String = ""

        '---OBTENEMOS REGISTRO DE CUENTAS POR COBRAR
        'Conectar()

        rs.Open("SELECT venta.id_venta,venta.fecha,venta.subtotal,venta.total_impuestos,venta.total,cliente.id_cliente,venta.id_empleado_caja AS id_ec,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_ec) AS empleado_caja,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE STATUS='PENDIENTE'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim venta_fecha As DateTime = rs.Fields("fecha").Value
                excel_app.Cells(row, 2) = UCase(venta_fecha.ToLongDateString & " " & venta_fecha.ToLongTimeString & " ," & rs.Fields("cliente_alias").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
                celda_pbk(excel_app.Cells(row, 2))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                Rango.Font.Bold = True
                Rango.Font.Size = 10
                Rango.Merge()
                row += 1
                excel_app.Cells(row, 2) = "TICKET FOLIO"
                'celda_pbk(excel_app.Cells(13, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "FECHA - HORA"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = "CLIENTE"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "SUBTOTAL"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 12) = "I.V.A."
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 14) = "TOTAL"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row += 1
                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 4) = rs.Fields("fecha").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 6) = rs.Fields("cliente_alias").Value
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = FormatCurrency(rs.Fields("subtotal").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(rs.Fields("total_impuestos").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                row += 2
                'obtenemos el detalle de los productos
                excel_app.Cells(row, 2) = "CODIGO"
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "PRODUCTO"
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 8) = "CANTIDAD"
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "UNIDAD"
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 12) = "PRECIO UNIT."
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 14) = "IMPORTE"
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row += 1
                Dim _rs As New ADODB.Recordset
                _rs.Open("SELECT venta_detalle.id_producto,producto.codigo,venta_detalle.cantidad,venta_detalle.descripcion,venta_detalle.unidad,venta_detalle.precio,(venta_detalle.cantidad*venta_detalle.precio) AS importe FROM venta_detalle JOIN producto ON venta_detalle.id_producto=producto.id_producto WHERE venta_detalle.id_venta=" & rs.Fields("id_venta").Value, conn)
                If _rs.RecordCount > 0 Then
                    While Not _rs.EOF

                        excel_app.Cells(row, 2) = _rs.Fields("codigo").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 4) = _rs.Fields("descripcion").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 8) = _rs.Fields("cantidad").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 10) = _rs.Fields("unidad").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 12) = FormatCurrency(_rs.Fields("precio").Value)
                        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 14) = FormatCurrency(redondear(FormatNumber(_rs.Fields("importe").Value, 2)))
                        Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()
                        row += 1
                        _rs.MoveNext()
                    End While
                End If
                _rs.Close()

                '---- FIN OBTENER DETALLES DE PRODUCTOS

                '---OBTENER LISTA DE PAGOS
                row += 1
                excel_app.Cells(row, 2) = "FECHA-HORA"
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "RECIBIO"
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 6))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 7) = "FORMA DE PAGO"
                Rango = wSheet.Range(excel_app.Cells(row, 7), excel_app.Cells(row, 8))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 9) = "IMPORTE"
                Rango = wSheet.Range(excel_app.Cells(row, 9), excel_app.Cells(row, 10))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 11) = "STATUS"
                Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 12))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 13) = "AUTORIZO"
                Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row += 1
                Dim _rs2 As New ADODB.Recordset
                _rs2.Open("SELECT pv.fecha,pv.importe,pv.status,pv.id_forma_pago,pv.id_empleado_validacion AS id_validacion, CONCAT(p.nombre,' ',p.ap_paterno) AS empleado_caja, (CASE WHEN pv.id_empleado_validacion='0' THEN '' ELSE (SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM persona p,empleado e WHERE e.id_empleado=id_validacion AND e.id_persona=p.id_persona) END )AS empleado_validacion FROM pagos_ventas pv,persona p,empleado e WHERE e.id_empleado=pv.id_empleado_caja AND e.id_persona=p.id_persona AND pv.id_venta=" & rs.Fields("id_venta").Value, conn)
                If _rs2.RecordCount > 0 Then

                    While Not _rs2.EOF

                        excel_app.Cells(row, 2) = _rs2.Fields("fecha").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 4) = _rs2.Fields("empleado_caja").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 6))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 7) = nombre_forma_pago(_rs2.Fields("id_forma_pago").Value)
                        Rango = wSheet.Range(excel_app.Cells(row, 7), excel_app.Cells(row, 8))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 9) = FormatCurrency(_rs2.Fields("importe").Value)
                        Rango = wSheet.Range(excel_app.Cells(row, 9), excel_app.Cells(row, 10))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        If _rs2.Fields("status").Value = "CANCELADO" Then
                            celda_atencion(excel_app.Cells(row, 11))
                        End If

                        excel_app.Cells(row, 11) = _rs2.Fields("status").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 12))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 13) = _rs2.Fields("empleado_validacion").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 15))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()
                        row += 1
                        _rs2.MoveNext()
                    End While
                Else

                    excel_app.Cells(row, 2) = "No se encontraron resultados"
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Font.Size = 10
                    Rango.Merge()
                    row += 1

                End If
                _rs2.Close()
                '-----FIN OBTENER LISTA DE PAGOS}

                '--OBTENEMOS LOS DETALLES FINALES
                row += 1
                Dim saldo_acumulado As Decimal = 0
                Dim importexpagar As Decimal = 0
                Dim agente_entrega As String = "En Mostrador"

                _rs.Open("SELECT  CASE WHEN ISNULL(SUM(importe)) THEN 0 ELSE SUM(importe) END AS total FROM pagos_ventas WHERE STATUS='ACTIVO' AND id_venta=" & rs.Fields("id_venta").Value, conn)
                If _rs.RecordCount > 0 Then
                    saldo_acumulado = _rs.Fields("total").Value
                End If
                _rs.Close()

                _rs.Open("SELECT CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS agente " & _
                         "FROM pedido_clientes JOIN empleado ON pedido_clientes.id_empleado_entrega=empleado.id_empleado JOIN persona ON empleado.id_persona=persona.id_persona WHERE pedido_clientes.id_venta=" & rs.Fields("id_venta").Value, conn)
                If _rs.RecordCount > 0 Then
                    agente_entrega = _rs.Fields("agente").Value
                End If
                _rs.Close()

                importexpagar = CDec(rs.Fields("total").Value) - saldo_acumulado

                excel_app.Cells(row, 2) = "Autorizo credito"
                celda_total(excel_app.Cells(row, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                excel_app.Cells(row, 6) = "Entregó productos"
                celda_total(excel_app.Cells(row, 6))
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                excel_app.Cells(row, 10) = "Total pagos"
                celda_total(excel_app.Cells(row, 10))
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 12))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                excel_app.Cells(row, 13) = "Saldo"
                celda_total(excel_app.Cells(row, 13))
                Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                row += 1
                excel_app.Cells(row, 2) = rs.Fields("empleado_caja").Value
                celda_total(excel_app.Cells(row, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                excel_app.Cells(row, 6) = agente_entrega
                celda_total(excel_app.Cells(row, 6))
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                excel_app.Cells(row, 10) = FormatCurrency(saldo_acumulado)
                celda_total(excel_app.Cells(row, 10))
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 12))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()

                excel_app.Cells(row, 13) = FormatCurrency(importexpagar)
                celda_total(excel_app.Cells(row, 13))
                Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 10
                Rango.Merge()
                '----FIN OBTENER LOS DETALLES FINALES

                row += 2
                rs.MoveNext()
            End While
        Else


            row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        '------FIN OBTENER REGISTROS DE CUENTAS POR COBRAR

        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_creditos.xls"
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

    Private Sub cb_ordenar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_ordenar.SelectedIndexChanged
        If cb_ordenar.SelectedIndex <> -1 Then
            btn_inventario.Enabled = True
        End If
    End Sub

    Private Sub cb_usuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_usuario.SelectedIndexChanged
        If cb_usuario.SelectedIndex <> -1 Then
            btn_reporte.Enabled = True
            btn_reporte_pdf.Enabled = True
        End If
    End Sub

    Private Sub btn_ventas_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ventas_cliente.Click
        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0

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
        'excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        '' = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Font.Bold = False
        'Rango.Font.Size = 10
        'Rango.Merge()


        Dim filtro As String = ""



        'excel_app.Cells(8, 7) = dtp_fecha.Value.ToLongDateString
        'Rango = wSheet.Range(excel_app.Cells(8, 9), excel_app.Cells(8, 9))
        '.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        '.Font.Size = 10
        'Rango.Merge()

        excel_app.Cells(8, 10) = "CLIENTE: " & UCase(cb_cliente.Text)
        Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        If rb_todos.Checked = True Then
            excel_app.Cells(10, 3) = "REPORTE DE VENTAS POR CLIENTE"
        Else
            excel_app.Cells(10, 3) = "REPORTE DE VENTAS POR CLIENTE," & " " & UCase(dtp_clientes.Value.ToLongDateString)
        End If
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "PRODUCTOS VENDIDOS A " & UCase(cb_cliente.Text)
        Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 15))
        celda_pbk(excel_app.Cells(12, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(13, 2) = "CODIGO"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "DESCRIPCIÓN"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 8) = "CANTIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 8), excel_app.Cells(13, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "UNIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 12) = "PRECIO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        row = 14
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = "AND date(venta.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If
        '---OBTENEMOS REGISTRO DE PRODUCTOS VENDIDOS A PUBLICO EN GENERAL
        'Conectar()
        'rs.Open("SELECT venta_detalle.id_producto AS id,venta_detalle.descripcion,precio AS  precio_vendido,unidad,producto.codigo, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' AND date(venta.fecha)='" & Format(dtp_fecha, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1) AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' AND date(venta.fecha)='" & Format(Today, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1),venta_detalle.precio) AS puntero " & _
        '"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta JOIN producto ON producto.id_producto=venta_detalle.id_producto " & _
        '"WHERE venta.status='CERRADA' AND date(venta.fecha)='" & Format(dtp_fecha, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " AND venta.id_cliente=1 GROUP BY puntero " & _
        '"ORDER BY cantidad_vendido DESC", conn)
        Dim filtro_cliente As String = ""

        If CType(cb_cliente.SelectedItem, myItem).Value > 1 Then
            filtro_cliente = "AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & ""
        End If
        rs.Open("SELECT venta_detalle.id_producto AS id,venta_detalle.descripcion,venta_detalle.precio AS  precio_vendido,unidad,producto.codigo, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' " & filtro & " " & filtro_cliente & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' " & filtro & " " & filtro_cliente & "),venta_detalle.precio) AS puntero " & _
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta JOIN producto ON producto.id_producto=venta_detalle.id_producto " & _
"WHERE venta.status='CERRADA' " & filtro & " " & filtro_cliente & " GROUP BY puntero " & _
"ORDER BY cantidad_vendido DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 2) = rs.Fields("codigo").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("cantidad_vendido").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(rs.Fields("precio_vendido").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While
        Else
            row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        '------FIN OBTENER PRODUCTOS DE PUBLICO EN GENERAL
        '---OBTENEMOS REGISTRO DE PRODUCTOS ENTREGADOS EN REGALIAS
        row += 2
        excel_app.Cells(row, 2) = "PRODUCTOS ENTREGADOS EN REGALIAS"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "FOLIO TICKET"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 4) = "DESCRIPCIÓN"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 8) = "CANTIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 10) = "UNIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 12) = "PRECIO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        row += 1
        'Conectar()
        '  rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,venta_detalle.id_venta,precio AS precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(dtp_fecha, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(dtp_fecha, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & "),venta_detalle.precio) AS puntero " & _
        '"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
        '"WHERE venta.status='REGALIA' AND date(venta.fecha)='" & Format(dtp_fecha, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja=" & global_id_empleado & " GROUP BY puntero " & _
        '"ORDER BY id_venta DESC", conn)
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = "AND date(venta.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If
        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,venta_detalle.id_venta,precio AS precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' " & filtro & " AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' " & filtro & " AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & "),venta_detalle.precio) AS puntero " & _
    "FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " & _
    "WHERE venta.status='REGALIA' " & filtro & " AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & " GROUP BY puntero " & _
    "ORDER BY id_venta DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("cantidad_vendido").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(rs.Fields("precio_vendido").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While
        Else
            'row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If

        rs.Close()
        Dim x As Integer = 0
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = "AND date(v.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If

        '  rs.Open("SELECT v.id_venta,v.id_empleado_caja,v.id_empleado_validacion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja,CONCAT(p2.nombre,' ',p2.ap_paterno,' ',p2.ap_materno) AS empleado_validacion FROM venta v,empleado e,persona p,empleado e2 ,persona p2 WHERE v.status='REGALIA' AND e.id_empleado=v.id_empleado_caja AND e.id_persona=p.id_persona AND e2.id_empleado=v.id_empleado_validacion AND e2.id_persona=p2.id_persona AND date(v.fecha)='" & Format(dtp_fecha.Value, "yyyy-MM-dd") & "' AND v.id_corte='0' AND v.id_empleado_caja='" & global_id_empleado & "' ORDER BY id_venta DESC", conn)
        rs.Open("SELECT v.id_venta,v.id_empleado_caja,v.id_empleado_validacion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja,CONCAT(p2.nombre,' ',p2.ap_paterno,' ',p2.ap_materno) AS empleado_validacion FROM venta v,empleado e,persona p,empleado e2 ,persona p2 WHERE v.status='REGALIA' AND v.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & " AND e.id_empleado=v.id_empleado_caja AND e.id_persona=p.id_persona AND e2.id_empleado=v.id_empleado_validacion AND e2.id_persona=p2.id_persona " & filtro & " ORDER BY id_venta DESC", conn)
        If rs.RecordCount > 0 Then
            row += 1
            While Not rs.EOF
                If x = 0 Then
                    excel_app.Cells(row, 2) = "FOLIO TICKET"
                    'celda_pbk(excel_app.Cells(13, 2))
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 4) = "COLABORADOR EN CAJA"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 8) = "PERSONA QUE AUTORIZÓ"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()
                    row += 1
                End If
                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("empleado_caja").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("empleado_validacion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()
                x += 1
                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        row += 2

        '------FIN OBTENER PRODUCTOS ENTREGADOS EN REGALIAS

        '--------OBTENEMOS REGISTRO DE  CREDITOS
        excel_app.Cells(row, 2) = "CREDITOS"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "FOLIO TICKET"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 4) = "CLIENTE"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 8) = "SUBTOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 10) = "I.V.A."
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 12) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        row += 1
        Dim total_creditos As Decimal = 0
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = "AND date(venta.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If
        'Conectar()
        rs.Open("SELECT venta.subtotal,venta.total_impuestos,venta.total,venta.id_venta, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " & _
               "FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente " & _
               "WHERE venta.status='PENDIENTE' " & filtro & "AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & "", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_creditos += CDec(rs.Fields("total").Value)
                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = rs.Fields("nombre").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(rs.Fields("subtotal").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = FormatCurrency(rs.Fields("total_impuestos").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While
            excel_app.Cells(row, 10) = "Total de Creditos"
            celda_total(excel_app.Cells(row, 10))
            Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
            Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Merge()

            excel_app.Cells(row, 12) = FormatCurrency(total_creditos)
            celda_total(excel_app.Cells(row, 12))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
            Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Merge()

        Else
            'row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        row += 2
        '---FIN OBTENER REGISTRO DE CREDITOS

        '---OBTENEMOS REGISTRO DE DEVOLUCIONES REALIZADAS EN EFECTIVO
        excel_app.Cells(row, 2) = "DEVOLUCIONES REALIZADAS EN EFECTIVO AL CLIENTE"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "FOLIO TICKET"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 4) = "PRODUCTO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 8) = "CANTIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 10) = "UNIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 12) = "PRECIO_UNITARIO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 14) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        row += 1
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = " AND DATE(devoluciones.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If
        'Conectar()
        rs.Open("SELECT devoluciones.id_venta,devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,devoluciones_detalle.unidad,devoluciones.total,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones_detalle.id_producto=id  " & filtro & " AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4)) AS cantidad,devoluciones_detalle.descripcion AS producto " & _
               " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion JOIN venta ON venta.id_venta=devoluciones.id_venta " & _
               "WHERE venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & " " & filtro & " AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) GROUP BY id_producto", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 4) = rs.Fields("producto").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(rs.Fields("precio_unitario").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row += 1
                rs.MoveNext()
            End While
            filtro = ""
            If rb_fecha.Checked = True Then
                filtro = " AND DATE(fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
            End If
            Dim _rs As New ADODB.Recordset
            '  _rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_iva) IS NULL THEN 0 ELSE SUM(total_iva)  END  AS total_iva,CASE WHEN SUM(total_otros) IS NULL THEN 0 ELSE SUM(total_otros)  END  AS total_otros,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE DATE(fecha)='" & Format(dtp_fecha.Value, "yyyy-MM-dd") & "' AND id_empleado='" & global_id_empleado & "' AND (tipo_devolucion=3 OR  tipo_devolucion=4) AND bandera_corte_caja=0", conn)
            _rs.Open("SELECT CASE WHEN SUM(devoluciones.subtotal) IS NULL THEN 0 ELSE SUM(devoluciones.subtotal)  END  AS subtotal,CASE WHEN SUM(devoluciones.total_iva) IS NULL THEN 0 ELSE SUM(devoluciones.total_iva)  END  AS total_iva,CASE WHEN SUM(devoluciones.total_otros) IS NULL THEN 0 ELSE SUM(devoluciones.total_otros)  END  AS total_otros,CASE WHEN SUM(devoluciones.total) IS NULL THEN 0 ELSE SUM(devoluciones.total)  END  AS total FROM devoluciones JOIN venta ON venta.id_venta=devoluciones.id_venta  WHERE venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & " " & filtro & " AND (tipo_devolucion=3 OR  tipo_devolucion=4)", conn)
            If rs.RecordCount > 0 Then
                excel_app.Cells(row, 12) = "Total Devoluciones"
                celda_total(excel_app.Cells(row, 12))
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = FormatCurrency(_rs.Fields("total").Value)
                celda_total(excel_app.Cells(row, 14))
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()
            End If
            _rs.Close()

        Else
            'row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        x = 0
        'conn.close()
        'conn = nothing
        row += 2
        '-- FIN OBTENER DEVOLUCIONES EN EFECTIVO
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = " AND DATE(venta.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If

        '---OBTENEMOS REGISTRO DE CANCELACIONES
        'Conectar()
        rs.Open("SELECT venta.id_venta,venta.fecha,venta.subtotal,venta.total_impuestos,venta.total,venta.id_empleado_validacion AS id_validacion,cliente.id_cliente,venta.id_empleado AS id_e,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_e) AS empleado_terminal,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_validacion) AS empleado_validacion,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE venta.STATUS='CANCELADA' " & filtro & " AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & "", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 2) = "CANCELACIONES DE VENTA EN CAJA"
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
                celda_pbk(excel_app.Cells(row, 2))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                Rango.Font.Bold = True
                Rango.Font.Size = 10
                Rango.Merge()
                row += 1
                excel_app.Cells(row, 2) = "TICKET FOLIO"
                'celda_pbk(excel_app.Cells(13, 2))
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "FECHA - HORA"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = "CLIENTE"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "SUBTOTAL"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 12) = "I.V.A."
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 14) = "TOTAL"
                'celda_pbk(excel_app.Cells(13, 3))
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row += 1
                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 4) = rs.Fields("fecha").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 6) = rs.Fields("cliente_alias").Value
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = FormatCurrency(rs.Fields("subtotal").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = FormatCurrency(rs.Fields("total_impuestos").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                row += 2
                'obtenemos el detalle de los productos
                excel_app.Cells(row, 2) = "CODIGO"
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "PRODUCTO"
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 8) = "CANTIDAD"
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "UNIDAD"
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 12) = "PRECIO UNIT."
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 14) = "IMPORTE"
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row += 1
                Dim _rs As New ADODB.Recordset
                _rs.Open("SELECT venta_detalle.id_producto,producto.codigo,venta_detalle.cantidad,venta_detalle.descripcion,venta_detalle.unidad,venta_detalle.precio,(venta_detalle.cantidad*venta_detalle.precio) AS importe FROM venta_detalle JOIN producto ON venta_detalle.id_producto=producto.id_producto WHERE venta_detalle.id_venta=" & rs.Fields("id_venta").Value, conn)
                If _rs.RecordCount > 0 Then
                    While Not _rs.EOF

                        excel_app.Cells(row, 2) = _rs.Fields("codigo").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 4) = _rs.Fields("descripcion").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 8) = _rs.Fields("cantidad").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 10) = _rs.Fields("unidad").Value
                        Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 12) = FormatCurrency(_rs.Fields("precio").Value)
                        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()

                        excel_app.Cells(row, 14) = FormatCurrency(redondear(FormatNumber(_rs.Fields("importe").Value, 2)))
                        Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        Rango.Merge()
                        row += 1
                        _rs.MoveNext()
                    End While
                End If
                _rs.Close()

                '---- FIN OBTENER DETALLES DE PRODUCTOS


                '--OBTENEMOS LOS DETALLES FINALES
                row += 1
                excel_app.Cells(row, 2) = "REALIZO LA VENTA"
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = "AUTORIZÓ CANCELACIÓN"
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                row += 1
                excel_app.Cells(row, 2) = rs.Fields("empleado_terminal").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = rs.Fields("empleado_validacion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()
                '----FIN OBTENER LOS DETALLES FINALES

                row += 2
                rs.MoveNext()
            End While
        Else
            row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        '-- FIN OBTENER REGISTRO DE CANCELACIONES

        Dim row_colum2 As Integer = row

        '---OBTENEMOS LOS TOTALES DE LAS VENTAS
        Dim total_ventas As Decimal = 0
        ' excel_app.Cells(row_colum2, 8) = "TOTALES POR CATEGORIA"
        'Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 15))
        'celda_pbk(excel_app.Cells(row_colum2, 8))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()
        row_colum2 += 1

        ' excel_app.Cells(row_colum2, 8) = "CATEGORIA"
        'celda_pbk(excel_app.Cells(13, 2))
        ' Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 10))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Font.Bold = True
        'Rango.Merge()

        'excel_app.Cells(row_colum2, 11) = "I.V.A."
        ''celda_pbk(excel_app.Cells(13, 3))
        'Rango = wSheet.Range(excel_app.Cells(row_colum2, 11), excel_app.Cells(row_colum2, 12))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Font.Bold = True
        'Rango.Merge()

        ' excel_app.Cells(row_colum2, 13) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        'Rango = wSheet.Range(excel_app.Cells(row_colum2, 13), excel_app.Cells(row_colum2, 14))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Font.Bold = True
        ' Rango.Merge()

        row_colum2 += 1

        ' Dim total_pago_prov As Decimal = 0
        filtro = ""
        If rb_fecha.Checked = True Then
            filtro = " AND DATE(venta.fecha)='" & Format(dtp_clientes.Value, "yyyy-MM-dd") & "'"
        End If

        'Conectar()
        ' rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(venta.fecha)='" & Format(dtp_fecha.Value, "yyyy-MM-dd") & "' AND venta.id_corte='0' AND venta.id_empleado_caja='" & global_id_empleado & "' AND venta.status='CERRADA' GROUP BY forma_pago.nombre", conn)
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE venta.status='CERRADA'  " & filtro & " AND venta.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & "  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas += CDec(rs.Fields("total").Value)

                excel_app.Cells(row_colum2, 8) = UCase(rs.Fields("descripcion").Value)
                Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 10))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 12
                Rango.Merge()

                excel_app.Cells(row_colum2, 11) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row_colum2, 11), excel_app.Cells(row_colum2, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 12
                Rango.Merge()

                ' excel_app.Cells(row_colum2, 13) = FormatCurrency(rs.Fields("total").Value)
                ' Rango = wSheet.Range(excel_app.Cells(row_colum2, 13), excel_app.Cells(row_colum2, 14))
                ' Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                ' Rango.Merge()
                ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
                row_colum2 += 1
                rs.MoveNext()
            End While
            excel_app.Cells(row_colum2, 8) = "Total ventas"
            celda_total(excel_app.Cells(row_colum2, 8))
            Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 10))
            'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Size = 12
            Rango.Merge()

            excel_app.Cells(row_colum2, 11) = FormatCurrency(total_ventas)
            celda_total(excel_app.Cells(row_colum2, 11))
            Rango = wSheet.Range(excel_app.Cells(row_colum2, 11), excel_app.Cells(row_colum2, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Size = 12
            Rango.Merge()
        Else
            excel_app.Cells(row_colum2, 8) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        row_colum2 += 2
        '---- FIN DE TOTALES DE VENTA

        '  excel_app.Cells(2, 6) = "COTIZACIÓN       "
        ' Rango = wSheet.Range(excel_app.Cells(2, 6), excel_app.Cells(3, 11))
        ' Rango.Merge()

        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.Font.Bold = True
        'Rango.Font.Size = 12

        'excel_app.Cells(5, 1) = "CLIENTE"
        'Rango = wSheet.Range(excel_app.Cells(5, 1), excel_app.Cells(5, 8))
        ' Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        ' Rango.Merge()
        'celda_pbk(Rango)
        ' Rango.Font.Bold = True

        ' excel_app.Cells(6, 1) = "Razon social:"
        'Rango = wSheet.Range(excel_app.Cells(6, 1), excel_app.Cells(6, 2))
        'Rango.Merge()
        'Rango.Font.Bold = True

        'excel_app.Cells(6, 3) = "nombre del cliente cliente"
        'Rango = wSheet.Range(excel_app.Cells(6, 3), excel_app.Cells(6, 8))
        'Rango.Merge()

        'excel_app.Cells(7, 1) = "Dirección:"
        'Rango = wSheet.Range(excel_app.Cells(7, 1), excel_app.Cells(7, 2))
        ' Rango.Merge()
        ' Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignTop
        'Rango.Font.Bold = True

        'excel_app.Cells(7, 3) = "tb_domicilio.Text"
        ' = wSheet.Range(excel_app.Cells(7, 3), excel_app.Cells(7, 8))
        ' Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignTop
        ' Rango.Merge()
        'Rango.WrapText = True
        '  wSheet.Rows(7).RowHeight = (Math.Floor(tb_domicilio.Text.Length / 50) + 1) * 11.25

        'excel_app.Cells(8, 1) = "Ciudad:"
        'Rango = wSheet.Range(excel_app.Cells(8, 1), excel_app.Cells(8, 2))
        'Rango.Merge()
        'Rango.Font.Bold = True

        'excel_app.Cells(9, 1) = "Telefono:"
        'Rango = wSheet.Range(excel_app.Cells(9, 1), excel_app.Cells(9, 2))
        'Rango.Merge()
        'Rango.Font.Bold = True

        'excel_app.Cells(9, 3) = "cb_telefono.Text"
        ' Rango = wSheet.Range(excel_app.Cells(9, 3), excel_app.Cells(9, 8))
        'Rango.Merge()

        ' Rango = wSheet.Range(excel_app.Cells(6, 1), excel_app.Cells(9, 8))
        ' Rango.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

        ' excel_app.Cells(5, 10) = "ELABORÓ"
        'Rango = wSheet.Range(excel_app.Cells(5, 10), excel_app.Cells(5, 13))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.Merge()
        ' celda_pbk(Rango)
        ' Rango.Font.Bold = True

        'excel_app.Cells(6, 10) = "Nombre:"
        'Rango.Font.Bold = True

        'excel_app.Cells(10, 10) = "E-mail:"
        'Rango = wSheet.Range(excel_app.Cells(10, 10), excel_app.Cells(10, 10))
        'Rango.Merge()
        'Rango.Font.Bold = True

        'excel_app.Cells(7, 10) = "Dirección:"
        'Rango = wSheet.Range(excel_app.Cells(7, 10), excel_app.Cells(7, 10))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignTop
        'Rango.Font.Bold = True


        ' excel_app.Cells(8, 10) = "Ciudad:"
        ' Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 10))
        'Rango.Font.Bold = True

        'excel_app.Cells(9, 10) = "Telefono:"
        'Rango = wSheet.Range(excel_app.Cells(9, 10), excel_app.Cells(9, 10))
        'Rango.Merge()
        'Rango.Font.Bold = True

        ''.Cells(11, 10) = "Fecha:"
        'Rango = wSheet.Range(excel_app.Cells(11, 10), excel_app.Cells(11, 10))
        'Rango.Merge()
        'Rango.Font.Bold = True

        ' excel_app.Cells(11, 11) = ucWords(Format("tb_fecha.Value", "Long Date"))
        ' Rango = wSheet.Range(excel_app.Cells(11, 11), excel_app.Cells(11, 13))
        ' Rango.Merge()

        'Rango = wSheet.Range(excel_app.Cells(6, 10), excel_app.Cells(11, 13))
        'Rango.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

        ' excel_app.Cells(3, 12) = "NÚMERO"
        'celda_pbk(excel_app.Cells(3, 12))
        ' Rango = wSheet.Range(excel_app.Cells(3, 12), excel_app.Cells(3, 13))
        ' Rango.Merge()

        ' excel_app.Cells(4, 12) = "tb_numero_cotizacion.Text"
        ' Rango = wSheet.Range(excel_app.Cells(4, 12), excel_app.Cells(4, 13))
        ' Rango.Merge()
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

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

    Private Sub cb_cliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cliente.SelectedIndexChanged
        If cb_cliente.SelectedIndex <> -1 Then
            btn_ventas_cliente.Enabled = True
        End If
    End Sub
    Private Sub reporte_pdf_caja(ByVal fecha As Date, ByVal id_cliente As Integer)
        Try
            'Intentar generar el documento.
            Dim doc As New Document(PageSize.LETTER, 10, 10, 15, 10)
            'Path que guarda el reporte en el escritorio de windows (Desktop).
            Dim generado As String = Format(Today.Date, "dd-MM-yyyy")
            Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\Inventario-" & generado & ".pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)

            Dim encripted = PdfWriter.GetInstance(doc, file)
            encripted.SetEncryption(PdfWriter.STRENGTH128BITS, "UKLRQe26", Nothing, PdfWriter.AllowCopy)
            doc.Open()
            ExportarDatosPDF(doc)
            doc.Close()
            Process.Start(filename)
        Catch ex As Exception
            'Si el intento es fallido, mostrar MsgBox.
            MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_reporte_pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporte_pdf.Click
        reporte_pdf_caja(dtp_fecha.Value, CType(cb_usuario.SelectedItem, myItem).Value)
        enviar_email_corte()
    End Sub
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function
    Public Sub ExportarDatosPDF(ByVal document As Document)
        'Se crea un objeto PDFTable con el numero de columnas del DataGridView.
        Dim imagendemo As iTextSharp.text.Image
        Dim _alias As New Paragraph ' Declaracion de un parrafo
        '_alias.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _alias.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _alias.Add("    " & lineas_reporte(0) & "") 'Texto que se insertara

        Dim _razon As New Paragraph ' Declaracion de un parrafo
        '_razon.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _razon.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _razon.Add("    " & lineas_reporte(1) & "") 'Texto que se insertara

        Dim _domicilio As New Paragraph ' Declaracion de un parrafo
        '_domicilio.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _domicilio.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _domicilio.Add("    " & lineas_reporte(2) & "") 'Texto que se insertara

        Dim _rfc As New Paragraph ' Declaracion de un parrafo
        '_rfc.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _rfc.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _rfc.Add("    " & lineas_reporte(3) & "") 'Texto que se insertara

        Dim _genero As New Paragraph ' Declaracion de un parrafo
        '_alias.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _genero.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _genero.Add("    REPORTE GENERADO POR: " & UCase(global_nombre) & "") 'Texto que se insertara

        Dim _espacio As New Paragraph ' Declaracion de un parrafo
        '_alias.Alignment = Element.ALIGN_RIGHT 'Alinea el parrafo para que sea centrado o justificado
        _espacio.Font = FontFactory.GetFont("Tahoma", 12) 'Asigan fuente
        _espacio.Add("  ") 'Texto que se insertara

        imagendemo = iTextSharp.text.Image.GetInstance(Application.StartupPath & "\logo.png")
        imagendemo.Alignment = Element.ALIGN_TOP

        'imagendemo.SetAbsolutePosition(50, 520) 'Posicion en el eje cartesiano
        imagendemo.ScaleAbsoluteWidth(150) 'Ancho de la imagen
        imagendemo.ScaleAbsoluteHeight(75) 'Altura de la imagen


        'Dim datatable As New PdfPTable(dgv_inventario.ColumnCount)
        'Se asignan algunas propiedades para el diseño del PDF.
        ' datatable.DefaultCell.Padding = 3
        'Dim headerwidths As Single() = GetColumnasSize(dgv_inventario)
        'datatable.SetWidths(headerwidths)
        'datatable.WidthPercentage = 100
        ' datatable.DefaultCell.BorderWidth = 2
        ' datatable.DefaultCell.color = iTextSharp.text.BaseColor.BLACK
        'datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        'Se crea el encabezado en el PDF.
        Dim encabezado As New Paragraph("REPORTE DE VENTAS", New Font(Font.Name = "Tahoma", 20, Font.Bold))
        encabezado.Alignment = Element.ALIGN_CENTER
        'Se crea el texto abajo del encabezado.
        ' Dim fecha_reporte As New Phrase("Inventario de: " + Now.Date.ToLongDateString & vbCrLf & "Almacen: " & cb_almacen.Text, New Font(Font.Name = "Tahoma", 14, Font.Bold))

        'Se capturan los nombres de las columnas del DataGridView.
        'For i As Integer = 0 To dgv_inventario.ColumnCount - 1
        'DataTable.AddCell(dgv_inventario.Columns(i).HeaderText)
        'Next
        ' DataTable.HeaderRows = 1
        ' DataTable.DefaultCell.BorderWidth = 1
        'Se generan las columnas del DataGridView.
        'for i As Integer = 0 To dgv_inventario.RowCount - 1
        'For j As Integer = 0 To dgv_inventario.ColumnCount - 1
        'DataTable.AddCell(dgv_inventario(j, i).Value.ToString())
        'Next
        ' DataTable.CompleteRow()
        ' Next
        'Se agrega el PDFTable al documento.
        document.Add(imagendemo) ' Agrega la imagen al documento
        document.Add(_alias)
        document.Add(_razon)
        document.Add(_domicilio)
        document.Add(_rfc)
        document.Add(_genero)
        document.Add(_espacio)
        document.Add(encabezado)
        'document.Add(fecha_reporte)
        'document.Add(DataTable)
        'document.Add(datatable)
    End Sub

    Private Sub btn_ajuste_inventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ajuste_inventario.Click
        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0

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
        'excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        'Rango = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        ''Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = False
        'Rango.Font.Size = 10
        'Rango.Merge()


        ' excel_app.Cells(8, 10) = "Colaborador: " & cb_usuario.Text
        ' Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        ' Rango.Font.Bold = True
        ' Rango.Font.Size = 10
        ' Rango.Merge()


        ' excel_app.Cells(10, 3) = "REPORTE DE CUENTAS POR COBRAR"
        ' Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        '  Rango.Font.Size = 12
        '  Rango.Merge()

        '  excel_app.Cells(12, 2) = "CUENTAS POR COBRAR"
        '  Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 15))
        '  celda_pbk(excel_app.Cells(12, 2))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        ' Rango.Font.Bold = True
        ' Rango.Font.Size = 10
        ' Rango.Merge()

        ' excel_app.Cells(13, 2) = "TICKET FOLIO"
        'celda_pbk(excel_app.Cells(13, 2))
        ' Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '  Rango.Font.Bold = True
        ' Rango.Merge()

        ' excel_app.Cells(13, 4) = "FECHA - HORA"
        'celda_pbk(excel_app.Cells(13, 3))
        ' Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 5))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        ' Rango.Merge()

        '  excel_app.Cells(13, 6) = "CLIENTE"
        'celda_pbk(excel_app.Cells(13, 3))
        '  Rango = wSheet.Range(excel_app.Cells(13, 6), excel_app.Cells(13, 9))
        '  Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '  Rango.Font.Bold = True
        ' Rango.Merge()

        'excel_app.Cells(13, 10) = "SUBTOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        ' Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        '   Rango.Merge()

        ' excel_app.Cells(13, 12) = "I.V.A."
        'celda_pbk(excel_app.Cells(13, 3))
        '  Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Font.Bold = True
        ' Rango.Merge()

        '  excel_app.Cells(13, 14) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        '  Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 15))
        '  Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        '  Rango.Font.Bold = True
        ' Rango.Merge()
        excel_app.Cells(10, 3) = "REPORTE DE AJUSTE DE INVENTARIO"
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()
        row = 11
        Dim filtro As String = ""
        If rb_xfecha_ajuste_inventario.Checked = True Then
            filtro = "WHERE DATE(ajuste_inventario.fecha)='" & Format(dtp_ajuste_inventario.Value, "yyyy-MM-dd") & "'"
        End If
        Dim last_fecha As String = ""
        '---OBTENEMOS REGISTRO DE LOS AJUSTES DE INVENTARIO
        'Conectar()

        rs.Open("SELECT producto.nombre,unidad.nombre AS unidad,ajuste_inventario.diferencia,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS empleado,ajuste_inventario.fecha  FROM ajuste_inventario JOIN empleado ON empleado.id_empleado=ajuste_inventario.id_empleado  JOIN persona ON persona.id_persona=empleado.id_persona JOIN  producto ON ajuste_inventario.id_producto=producto.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad " & filtro & " ORDER BY fecha DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim venta_fecha As DateTime = rs.Fields("fecha").Value
                If last_fecha = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") Then
                    row += 1
                    excel_app.Cells(row, 2) = venta_fecha.ToLongTimeString
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()


                    excel_app.Cells(row, 4) = rs.Fields("diferencia").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    If CDbl(rs.Fields("diferencia").Value) < 0 Then
                        celda_atencion(excel_app.Cells(row, 4))
                    Else
                        celda_total(excel_app.Cells(row, 4))
                    End If
                    Rango.Merge()

                    excel_app.Cells(row, 6) = rs.Fields("unidad").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    excel_app.Cells(row, 8) = rs.Fields("nombre").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    excel_app.Cells(row, 12) = rs.Fields("empleado").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 15))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()
                Else
                    row += 2
                    excel_app.Cells(row, 2) = UCase(venta_fecha.ToLongDateString)
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
                    celda_pbk(excel_app.Cells(row, 2))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                    Rango.Font.Bold = True
                    Rango.Font.Size = 10
                    Rango.Merge()
                    row += 1
                    excel_app.Cells(row, 2) = "HORA"
                    'celda_pbk(excel_app.Cells(13, 2))
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 4) = "DIFERENCIA"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 6) = "UNIDAD"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 8) = "PRODUCTO"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 12) = "REALIZÓ AJUSTE"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 15))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    'excel_app.Cells(row, 14) = "TOTAL"
                    'celda_pbk(excel_app.Cells(13, 3))
                    ' Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                    'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    'Rango.Font.Bold = True
                    'Rango.Merge()
                    row += 1
                    excel_app.Cells(row, 2) = venta_fecha.ToLongTimeString
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    excel_app.Cells(row, 4) = rs.Fields("diferencia").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    If CDbl(rs.Fields("diferencia").Value) < 0 Then
                        celda_atencion(excel_app.Cells(row, 4))
                    Else
                        celda_total(excel_app.Cells(row, 4))
                    End If
                    Rango.Merge()

                    excel_app.Cells(row, 6) = rs.Fields("unidad").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 7))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    excel_app.Cells(row, 8) = rs.Fields("nombre").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    excel_app.Cells(row, 12) = rs.Fields("empleado").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 15))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    'excel_app.Cells(row, 14) = FormatCurrency(rs.Fields("total").Value)
                    'Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                    'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    'Rango.Merge()
                    last_fecha = Format(rs.Fields("fecha").Value, "yyyy-MM-dd")
                End If

                rs.MoveNext()
            End While
        Else
            row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        '------FIN OBTENER REGISTRIOS DE AJUSTE DE INVENTARIO

        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/ajuste_inventario.xls"
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

    Private Sub btn_reporte_asistencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporte_asistencia.Click
        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0

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

        excel_app.Cells(10, 3) = "REPORTE DE REGISTRO DE ASISTENCIAS"
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()
        row = 11
        Dim filtro As String = ""
        If rb_xfecha_asistencia.Checked = True Then
            If cb_usuario_asistencia.SelectedIndex = -1 Then
                filtro = "WHERE empleado_jornada.fecha='" & Format(dtp_fecha_asistencia.Value, "yyyy-MM-dd") & "'"
            Else
                If CType(cb_usuario_asistencia.SelectedItem, myItem).Value <> 0 Then
                    filtro = "WHERE empleado_jornada.fecha='" & Format(dtp_fecha_asistencia.Value, "yyyy-MM-dd") & "' AND empleado_jornada.id_empleado='" & CType(cb_usuario_asistencia.SelectedItem, myItem).Value & "' "
                End If
            End If
        ElseIf rb_all_asistencia.Checked = True Then
            If cb_usuario_asistencia.SelectedIndex <> -1 Then
                If CType(cb_usuario_asistencia.SelectedItem, myItem).Value <> 0 Then
                    filtro = "WHERE empleado_jornada.id_empleado='" & CType(cb_usuario_asistencia.SelectedItem, myItem).Value & "' "
                End If
            End If
        ElseIf rb_asistencia_periodo.Checked = True Then

            If cb_usuario_asistencia.SelectedIndex = -1 Then
                filtro = "WHERE empleado_jornada.fecha BETWEEN '" & Format(dtp_asistencia_inicio.Value, "yyyy-MM-dd") & "' AND  '" & Format(dtp_asistencia_termino.Value, "yyyy-MM-dd") & "'"
            Else
                If CType(cb_usuario_asistencia.SelectedItem, myItem).Value <> 0 Then
                    filtro = "WHERE empleado_jornada.fecha BETWEEN '" & Format(dtp_asistencia_inicio.Value, "yyyy-MM-dd") & "' AND  '" & Format(dtp_asistencia_termino.Value, "yyyy-MM-dd") & "' AND empleado_jornada.id_empleado='" & CType(cb_usuario_asistencia.SelectedItem, myItem).Value & "' "
                End If
            End If

        End If

        Dim last_fecha As String = ""
        '---OBTENEMOS REGISTRO DE LOS AJUSTES DE INVENTARIO
        'Conectar()

        rs.Open("SELECT empleado_jornada.id_empleado,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS colaborador,empleado_jornada.fecha,empleado_jornada.hora_entrada,empleado_jornada.hora_salida" & _
             " FROM empleado_jornada " & _
            "JOIN empleado ON empleado_jornada.id_empleado=empleado.id_empleado " & _
            "JOIN persona ON persona.id_persona=empleado.id_persona " & filtro & "" & _
            " ORDER BY fecha DESC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                '================obtenemos valores==============
                Dim hora_entrada_ideal As DateTime
                Dim hora_salida_idea As DateTime
                Dim tolerancia As Integer = 0
                Dim rw As New ADODB.Recordset
                rw.Open("SELECT hora_entrada,hora_salida,tolerancia FROM empleado_horario WHERE id_empleado=" & rs.Fields("id_empleado").Value, conn)
                If rw.RecordCount > 0 Then
                    hora_entrada_ideal = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") & " " & Format(rw.Fields("hora_entrada").Value, "HH:mm:ss")
                    hora_salida_idea = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") & " " & Format(rw.Fields("hora_entrada").Value, "HH:mm:ss")
                    tolerancia = rw.Fields("tolerancia").Value
                End If
                rw.Close()

                '=======================================
                Dim registro_fecha As DateTime = rs.Fields("fecha").Value

                If last_fecha = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") Then
                    row += 1
                    excel_app.Cells(row, 2) = registro_fecha.ToLongDateString
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()


                    excel_app.Cells(row, 6) = rs.Fields("colaborador").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 10))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    Dim hora_entrada As DateTime = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") & " " & Format(rs.Fields("hora_entrada").Value, "HH:mm:ss")
                    excel_app.Cells(row, 11) = Format(rs.Fields("hora_entrada").Value, "HH:mm:ss")
                    Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 12))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    Dim hora_salida As String = "NO REGISTRADO"
                    If Not IsDBNull(rs.Fields("hora_salida").Value) Then
                        hora_salida = Format(rs.Fields("hora_salida").Value, "HH:mm:ss")
                    End If
                    excel_app.Cells(row, 13) = hora_salida
                    Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 14))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    If hora_salida = "NO REGISTRADO" Then
                        celda_atencion(excel_app.Cells(row, 13))
                    End If
                    Rango.Merge()

                    'Dim hora_entrada_ideal As DateTime = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") & " 06:00:00"
                    Dim retardo As Integer
                    retardo = DateDiff(DateInterval.Minute, hora_entrada_ideal, hora_entrada)
                    Dim estatus As String = "ASISTENCIA"
                    If retardo > tolerancia Then
                        estatus = "RETARDO DE " & retardo & " MINUTOS"
                    Else
                        If retardo < 0 Then
                            estatus = "ANTICIPADO"
                        End If
                    End If
                    excel_app.Cells(row, 15) = estatus
                    Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()
                Else
                    row += 2
                    excel_app.Cells(row, 2) = UCase(registro_fecha.ToLongDateString)
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 17))
                    celda_pbk(excel_app.Cells(row, 2))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                    Rango.Font.Bold = True
                    Rango.Font.Size = 10
                    Rango.Merge()
                    row += 1
                    excel_app.Cells(row, 2) = "FECHA"
                    'celda_pbk(excel_app.Cells(13, 2))
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 6) = "COLABORADOR"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 10))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 11) = "HORA ENTRADA"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 12))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 13) = "HORA SALIDA"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 14))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 15) = "ESTATUS"
                    'celda_pbk(excel_app.Cells(13, 3))
                    Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()


                    row += 1
                    excel_app.Cells(row, 2) = registro_fecha.ToLongDateString
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 5))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    excel_app.Cells(row, 6) = rs.Fields("colaborador").Value
                    Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 10))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    Dim hora_entrada As DateTime = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") & " " & Format(rs.Fields("hora_entrada").Value, "HH:mm:ss")
                    excel_app.Cells(row, 11) = Format(rs.Fields("hora_entrada").Value, "HH:mm:ss")
                    Rango = wSheet.Range(excel_app.Cells(row, 11), excel_app.Cells(row, 12))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    Dim hora_salida As String = "NO REGISTRADO"
                    If Not IsDBNull(rs.Fields("hora_salida").Value) Then
                        hora_salida = Format(rs.Fields("hora_salida").Value, "HH:m:ss")
                    End If

                    excel_app.Cells(row, 13) = hora_salida
                    Rango = wSheet.Range(excel_app.Cells(row, 13), excel_app.Cells(row, 14))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    ' Dim hora_entrada_ideal As DateTime = Format(rs.Fields("fecha").Value, "yyyy-MM-dd") & " 06:00:00"
                    Dim retardo As Integer
                    retardo = DateDiff(DateInterval.Minute, hora_entrada_ideal, hora_entrada)
                    Dim estatus As String = "ASISTENCIA"
                    If retardo > tolerancia Then
                        estatus = "RETARDO DE " & retardo & " MINUTOS"
                    Else
                        If retardo < 0 Then
                            estatus = "ANTICIPADO"
                        End If
                    End If
                    excel_app.Cells(row, 15) = estatus
                    Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Merge()

                    last_fecha = Format(rs.Fields("fecha").Value, "yyyy-MM-dd")
                End If
                rs.MoveNext()
            End While
        Else
            row += 1
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 17))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        '------FIN OBTENER REGISTRIOS DE AJUSTE DE INVENTARIO

        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/ajuste_inventario.xls"
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

    Private Sub btn_registro_devoluciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_utilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_utilidad.Click
        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0
        wBook = excel_app.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        wSheet.PageSetup.TopMargin = 1
        wSheet.PageSetup.BottomMargin = 1
        wSheet.PageSetup.LeftMargin = 1
        wSheet.PageSetup.RightMargin = 1

        wSheet.Name = "Utilidad"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png", _
CType(False, Microsoft.Office.Core.MsoTriState), _
CType(True, Microsoft.Office.Core.MsoTriState), 30, 2, 150, 75)

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
        '  excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        '  Rango = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = False
        ' Rango.Font.Size = 10
        'Rango.Merge()
        excel_app.Cells(8, 7) = UCase("REPORTE ELABORADO: " & Date.Today.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        'excel_app.Cells(8, 10) = "Colaborador: " & cb_usuario.Text
        'Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()
        Dim titulo_reporte As String = ""
        Dim fecha_incio As Date
        If rb_all_utilidad.Checked = True Then
            rs.Open("SELECT DATE(fecha) AS fecha FROM venta ORDER BY fecha ASC LIMIT 1", conn)
            If rs.RecordCount > 0 Then
                fecha_incio = rs.Fields("fecha").Value
            End If
            rs.Close()
            titulo_reporte = "Reporte de utilidad del dia " & fecha_incio.ToLongDateString & " al " & dtp_fecha_termino_utilidad.Value.ToLongDateString
        ElseIf rb_xfecha_utilidad.Checked = True Then
            titulo_reporte = "Reporte de utilidad del dia " & dtp_fecha_utilidad.Value.ToLongDateString
        ElseIf rb_periodo.Checked = True Then
            titulo_reporte = "Reporte de utilidad del " & dtp_fecha_inicio_utilidad.Value.ToLongDateString & " al " & dtp_fecha_termino_utilidad.Value.ToLongDateString
        End If


        excel_app.Cells(10, 3) = titulo_reporte
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "REPORTE"
        Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 17))
        celda_pbk(excel_app.Cells(12, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(13, 2) = "CODIGO"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "DESCRIPCIÓN"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 8) = "UNIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 8), excel_app.Cells(13, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "CANTIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 12) = "COSTO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 14) = "P. VENTA"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 16) = "UTILIDAD"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 16), excel_app.Cells(13, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        'row = 14

        Dim filtro As String = ""

        If rb_all_utilidad.Checked = True Then

        ElseIf rb_xfecha_utilidad.Checked = True Then
            filtro = " AND DATE(v.fecha)='" & Format(dtp_fecha_utilidad.Value, "yyyy-MM-dd") & "' "
        ElseIf rb_periodo.Checked = True Then
            filtro = " AND DATE(v.fecha) BETWEEN '" & Format(dtp_fecha_inicio_utilidad.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino_utilidad.Value, "yyyy-MM-dd") & "' "
        End If

        row = 15
        Dim total_utilidad As Decimal = 0
        Dim rw, ry, rx As New ADODB.Recordset
        rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta v " & _
                "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                "JOIN producto p ON p.id_producto=vd.id_producto " & _
                "WHERE  1 " & filtro & " " & _
                "AND (v.status='CERRADA' OR v.status='PENDIENTE')", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " & _
                                   "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                           "WHERE  1 AND vd.id_producto='" & rs.Fields("id_producto").Value & "'" & filtro & " " & _
                               "AND (v.status='CERRADA' OR v.status='PENDIENTE') ", conn)
                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        rx.Open("SELECT vd.producto_costo AS costo FROM venta v " & _
                                  "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                          "WHERE  1 AND vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' " & filtro & " " & _
                              "AND (v.status='CERRADA' OR v.status='PENDIENTE') ", conn)
                        If rx.RecordCount > 0 Then
                            ry.Open("SELECT SUM(vd.cantidad) AS cantidad FROM venta v " & _
                                   "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " & _
                           "WHERE  1 AND vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND vd.producto_costo='" & rx.Fields("costo").Value & "' " & filtro & " " & _
                               "AND (v.status='CERRADA' OR v.status='PENDIENTE') ", conn)
                            If ry.RecordCount > 0 Then
                                If Not IsDBNull(ry.Fields("cantidad").Value) Then
                                    Dim utilidad As Decimal = 0

                                    utilidad = (rw.Fields("precio").Value - rx.Fields("costo").Value) * ry.Fields("cantidad").Value
                                    total_utilidad += utilidad
                                    excel_app.Cells(row, 2) = rs.Fields("codigo").Value
                                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()


                                    excel_app.Cells(row, 4) = rs.Fields("descripcion").Value
                                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()

                                    excel_app.Cells(row, 8) = rs.Fields("unidad").Value
                                    Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()

                                    excel_app.Cells(row, 10) = ry.Fields("cantidad").Value
                                    Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()

                                    excel_app.Cells(row, 12) = FormatCurrency(rx.Fields("costo").Value)
                                    Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()

                                    excel_app.Cells(row, 14) = FormatCurrency(rw.Fields("precio").Value)
                                    Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()

                                    excel_app.Cells(row, 16) = FormatCurrency(utilidad)
                                    Rango = wSheet.Range(excel_app.Cells(row, 16), excel_app.Cells(row, 17))
                                    Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    Rango.Merge()

                                    row += 1
                                End If
                            End If

                            ry.Close()
                        End If
                        rx.Close()
                        rw.MoveNext()
                    End While
                End If
                rw.Close()
                rs.MoveNext()
            End While
            row = row + 1
            excel_app.Cells(row, 12) = "Total Utilidad"
            celda_total(excel_app.Cells(row, 12))
            Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 14))
            'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Size = 12
            Rango.Merge()

            excel_app.Cells(row, 15) = FormatCurrency(total_utilidad)
            celda_total(excel_app.Cells(row, 15))
            Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Size = 12
            Rango.Merge()
        End If
        rs.Close()
        '---OBTENEMOS EL INVENTARO DE PRODUCTOS
        'Conectar()
        'rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,producto.codigo,unidad.nombre AS unidad,producto_sucursal.cantidad FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad JOIN producto_sucursal ON producto_sucursal.id_producto=producto.id_producto " & filtro, conn)
        'If rs.RecordCount > 0 Then
        'While Not rs.EOF
        'excel_app.Cells(row, 2) = rs.Fields("codigo").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()


        'excel_app.Cells(row, 4) = rs.Fields("nombre").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
        ' Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Merge()

        ' excel_app.Cells(row, 8) = rs.Fields("unidad").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()

        'excel_app.Cells(row, 10) = rs.Fields("cantidad").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()

        'excel_app.Cells(row, 12) = ""
        'Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()

        ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
        'row += 1
        'rs.MoveNext()
        'End While
        'Else
        'row += 1
        'excel_app.Cells(row, 2) = "No se encontraron resultados"
        'Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()
        'End If
        'rs.Close()
        'conn.close()
        'conn = nothing

        '------FIN OBTENER PRODUCTOS DE PUBLICO EN GENERAL


        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_utilidad.xls"
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

    Private Sub btn_reporte_ingreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reporte_ingreso.Click
        Dim excel_app As New Excel.Application()
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet
        Dim Rango As Excel.Range
        Dim col As Integer = 0
        Dim row As Integer = 0
        wBook = excel_app.Workbooks.Add()
        wSheet = wBook.ActiveSheet()
        wSheet.PageSetup.TopMargin = 1
        wSheet.PageSetup.BottomMargin = 1
        wSheet.PageSetup.LeftMargin = 1
        wSheet.PageSetup.RightMargin = 1

        wSheet.Name = "Ingresos"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png", _
CType(False, Microsoft.Office.Core.MsoTriState), _
CType(True, Microsoft.Office.Core.MsoTriState), 30, 2, 150, 75)

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
        '  excel_app.Cells(6, 7) = "TEL/FAX:(951) 132 41 48"
        '  Rango = wSheet.Range(excel_app.Cells(6, 7), excel_app.Cells(6, 10))
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = False
        ' Rango.Font.Size = 10
        'Rango.Merge()
        excel_app.Cells(8, 7) = UCase("REPORTE ELABORADO: " & Date.Today.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        'excel_app.Cells(8, 10) = "Colaborador: " & cb_usuario.Text
        'Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()
        Dim titulo_reporte As String = ""
        Dim fecha_incio As Date
        If rb_todos_ingresos.Checked = True Then
            rs.Open("SELECT DATE(fecha) AS fecha FROM pagos_ventas ORDER BY fecha ASC LIMIT 1", conn)
            If rs.RecordCount > 0 Then
                fecha_incio = rs.Fields("fecha").Value
            End If
            rs.Close()
            titulo_reporte = "Reporte de Ingresos del dia " & fecha_incio.ToLongDateString & " al " & Today.ToLongDateString
        ElseIf rb_ingresos_fecha.Checked = True Then
            titulo_reporte = "Reporte de Ingresos del dia " & dtp_ingresos_fecha.Value.ToLongDateString
        ElseIf rb_ingresos_periodo.Checked = True Then
            titulo_reporte = "Reporte de Ingresos del " & dtp_ingreso_fecha_inicio.Value.ToLongDateString & " al " & dtp_ingresos_fecha_fin.Value.ToLongDateString
        End If


        excel_app.Cells(10, 3) = titulo_reporte
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "REPORTE DE INGRESOS"
        Rango = wSheet.Range(excel_app.Cells(12, 2), excel_app.Cells(12, 24))
        celda_pbk(excel_app.Cells(12, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(13, 2) = "FOLIO DE VENTA"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "TIPO DE MOVIMIENTO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 8) = "IMPORTE"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 8), excel_app.Cells(13, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "FORMA DE PAGO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 12) = "FECHA"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 14) = "CAJERO(A)"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 18) = "VENDEDOR"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 18), excel_app.Cells(13, 21))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 22) = "ESTADO DE ENTREGA"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 22), excel_app.Cells(13, 24))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 25) = "CLIENTE"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 25), excel_app.Cells(13, 27))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()


        'row = 14

        Dim filtro As String = ""

        If rb_todos_ingresos.Checked = True Then

        ElseIf rb_ingresos_fecha.Checked = True Then
            filtro = " AND DATE(pv.fecha_cobro)='" & Format(dtp_ingresos_fecha.Value, "yyyy-MM-dd") & "' "
        ElseIf rb_ingresos_periodo.Checked = True Then
            filtro = " AND DATE(pv.fecha_cobro) BETWEEN '" & Format(dtp_ingreso_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_ingresos_fecha_fin.Value, "yyyy-MM-dd") & "' "
        End If

        row = 15
        rs.Open("SELECT pv.id_venta,pv.importe,fp.descripcion AS forma_pago,pv.fecha_cobro,CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS empleado_caja,v.id_cliente FROM pagos_ventas pv " &
                "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
                "JOIN empleado e ON e.id_empleado=pv.id_empleado_caja " &
                "JOIN persona p ON p.id_persona=e.id_persona " &
                "JOIN venta v ON v.id_venta=pv.id_venta " &
                "WHERE v.status<>'CANCELADA' AND pv.status='ACTIVO' " & filtro & "")

        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim tipo_movimiento As String = ""
                Dim rw As New ADODB.Recordset
                Dim vendedor As String = ""
                Dim estatus_entrega As String = ""
                Dim nombre_cliente As String = ""
                rw.Open("SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente='" & rs.Fields("id_cliente").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    nombre_cliente = rw.Fields("cliente").Value
                End If
                rw.Close()
                rw.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor FROM empleado e " & _
                        "JOIN persona p ON p.id_persona=e.id_persona " & _
                        "JOIN venta v ON v.id_empleado=e.id_empleado WHERE v.id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    vendedor = rw.Fields("vendedor").Value
                End If
                rw.Close()

                rw.Open("SELECT id_apartado,total,entregado FROM apartado WHERE id_venta='" & rs.Fields("id_venta").Value & "'", conn)
                If rw.RecordCount > 0 Then
                    If rs.Fields("importe").Value < rw.Fields("total").Value Then
                        tipo_movimiento = "ABONO AL APARTADO FOLIO " & rw.Fields("id_apartado").Value
                    ElseIf rs.Fields("importe").Value = rw.Fields("total").Value Then
                        tipo_movimiento = "PAGO DEL APARTADO FOLIO " & rw.Fields("id_apartado").Value
                    End If
                    If rw.Fields("entregado").Value = "1" Then
                        estatus_entrega = "ENTREGADO"
                    Else
                        estatus_entrega = "NO ENTREGADO"
                    End If
                Else
                    tipo_movimiento = "VENTA EN EXISTENCIA"
                    estatus_entrega = "ENTREGADO"
                End If
                rw.Close()

                excel_app.Cells(row, 2) = rs.Fields("id_venta").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()


                excel_app.Cells(row, 4) = tipo_movimiento
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(rs.Fields("importe").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("forma_pago").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("fecha_cobro").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = rs.Fields("empleado_caja").Value
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 18) = vendedor
                Rango = wSheet.Range(excel_app.Cells(row, 18), excel_app.Cells(row, 21))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 22) = estatus_entrega
                Rango = wSheet.Range(excel_app.Cells(row, 22), excel_app.Cells(row, 24))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 25) = nombre_cliente
                Rango = wSheet.Range(excel_app.Cells(row, 25), excel_app.Cells(row, 27))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While

        End If
        rs.Close()
        row = row + 1
        Dim filtro2 As String = ""

        If rb_todos_ingresos.Checked = True Then

        ElseIf rb_ingresos_fecha.Checked = True Then
            filtro2 = " AND DATE(d.fecha)='" & Format(dtp_ingresos_fecha.Value, "yyyy-MM-dd") & "' "
        ElseIf rb_ingresos_periodo.Checked = True Then
            filtro2 = " AND DATE(d.fecha) BETWEEN '" & Format(dtp_ingreso_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_ingresos_fecha_fin.Value, "yyyy-MM-dd") & "' "
        End If

        rs.Open("SELECT d.fecha,d.importe,d.descripcion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja FROM depositos d " & _
                "JOIN empleado e ON e.id_empleado=d.id_empleado_caja " & _
                "JOIN persona p ON p.id_persona=e.id_persona " & _
                "WHERE d.status='ACTIVO' " & filtro2 & "", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF

                excel_app.Cells(row, 2) = ""
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 4) = "DEPOSITO EN CAJA (" & rs.Fields("descripcion").Value & ")"
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = FormatCurrency(rs.Fields("importe").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 10) = "Efectivo"
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("fecha").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 14) = rs.Fields("empleado_caja").Value
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 17))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                rs.MoveNext()
                row = row + 1
            End While
        End If
        rs.Close()

        row = row + 1
        Dim total_ingreso As Decimal = 0
        rs.Open("SELECT fp.id_forma_pago,fp.descripcion,SUM(pv.importe)AS total FROM pagos_ventas pv " &
 "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
 "JOIN venta v ON v.id_venta=pv.id_venta  " &
 "WHERE v.status<>'CANCELADA' AND pv.status='ACTIVO' " & filtro & "" &
 "GROUP BY fp.descripcion", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 12) = rs.Fields("descripcion").Value
                'celda_pbk(excel_app.Cells(row, 12))
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 14))
                'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 12
                Rango.Merge()

                excel_app.Cells(row, 15) = FormatCurrency(rs.Fields("total").Value)
                'celda_pbk(excel_app.Cells(row, 15))
                Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Size = 12
                Rango.Merge()
                total_ingreso = total_ingreso + rs.Fields("total").Value
                row = row + 1
                rs.MoveNext()
            End While

        End If
        rs.Close()

        Dim total_depositos As Decimal = 0
        rs.Open("SELECT CASE WHEN ISNULL(SUM(d.importe)) THEN 0 ELSE SUM(d.importe) END AS total_depositos FROM depositos d WHERE d.status='ACTIVO' " & filtro2 & "", conn)
        If rs.RecordCount > 0 Then
            total_depositos = rs.Fields("total_depositos").Value
        End If
        rs.Close()

        excel_app.Cells(row, 12) = "Depositos en caja"
        'celda_pbk(excel_app.Cells(row, 12))
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 14))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(row, 15) = FormatCurrency(total_depositos)
        'celda_pbk(excel_app.Cells(row, 15))
        Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Size = 12
        Rango.Merge()


        row = row + 1
        excel_app.Cells(row, 12) = "Total Ingresos"
        celda_total(excel_app.Cells(row, 12))
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 14))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(row, 15) = FormatCurrency(total_ingreso + total_depositos)
        celda_total(excel_app.Cells(row, 15))
        Rango = wSheet.Range(excel_app.Cells(row, 15), excel_app.Cells(row, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Size = 12
        Rango.Merge()
        '---OBTENEMOS EL INVENTARO DE PRODUCTOS
        'Conectar()
        'rs.Open("SELECT producto.id_producto,producto.nombre,producto.descripcion,producto.codigo,unidad.nombre AS unidad,producto_sucursal.cantidad FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad JOIN producto_sucursal ON producto_sucursal.id_producto=producto.id_producto " & filtro, conn)
        'If rs.RecordCount > 0 Then
        'While Not rs.EOF
        'excel_app.Cells(row, 2) = rs.Fields("codigo").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()


        'excel_app.Cells(row, 4) = rs.Fields("nombre").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
        ' Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        ' Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ' Rango.Merge()

        ' excel_app.Cells(row, 8) = rs.Fields("unidad").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()

        'excel_app.Cells(row, 10) = rs.Fields("cantidad").Value
        'Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()

        'excel_app.Cells(row, 12) = ""
        'Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
        'Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Merge()

        ' b.AnadirLineaSubcabeza("" & rs.Fields("cantidad_vendido").Value & " " & rs.Fields("descripcion").Value & " " & rs.Fields("unidad").Value & " " & rs.Fields("precio_vendido").Value & "")
        'row += 1
        'rs.MoveNext()
        'End While
        'Else
        'row += 1
        'excel_app.Cells(row, 2) = "No se encontraron resultados"
        'Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
        'Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        'Rango.Font.Bold = True
        'Rango.Font.Size = 10
        'Rango.Merge()
        'End If
        'rs.Close()
        'conn.close()
        'conn = nothing

        '------FIN OBTENER PRODUCTOS DE PUBLICO EN GENERAL


        Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_utilidad.xls"
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
End Class