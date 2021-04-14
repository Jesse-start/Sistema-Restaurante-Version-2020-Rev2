Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Math
Public Class frm_reporteador2
    Dim abonos(4) As Decimal
    Private Property cargado As Boolean

    '===========VARIABLES PARA GRAFICA DE BARRAS============
    Dim CArea As ChartArea
    Dim T As Title
    Dim Servicios As Series
    Dim contador As Integer = 0
    Dim total_registros_grafica As Integer = 0
    Dim limite_barras_grafica As Integer = 7
    Dim total_paginas As Integer = 0
    Private Sub conf_inicio_reporteador()
    End Sub
    Private Sub frm_reporteador_comedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        cargar_tipo_reporte()
        cargar_colaboradores()
        obtener_clientes()
        cargar_orden()
        cambio_controles()
        cargado = True
    End Sub
    Private Sub cargar_tipo_reporte()
        cb_tipo_reporte.Items.Clear()
        cb_tipo_reporte.Items.Add(New myItem("1", "1.-Ventas por Ticket"))
        cb_tipo_reporte.Items.Add(New myItem("2", "2.-Existencias en Almacén"))
        cb_tipo_reporte.Items.Add(New myItem("3", "3.-Creditos por Ticket"))
        cb_tipo_reporte.Items.Add(New myItem("4", "4.-Ventas por Cliente"))
        cb_tipo_reporte.Items.Add(New myItem("5", "5.-Ingresos"))
        cb_tipo_reporte.Items.Add(New myItem("6", "6.-Ajustes de Inventario"))
        cb_tipo_reporte.Items.Add(New myItem("7", "7.-Asistencia"))
        ' cb_tipo_reporte.Items.Add(New myItem("8", "8.-Utilidad"))
        cb_tipo_reporte.Items.Add(New myItem("9", "9.-Reporte productos vendidos"))
        cb_tipo_reporte.Items.Add(New myItem("10", "10.-Reporte de utilidad"))

        cb_tipo_reporte.SelectedIndex = 0
    End Sub

    Private Sub cargar_colaboradores()
        cb_colaborador.Items.Clear()
        'Conectar()
        cb_colaborador.Items.Add(New myItem(0, "[Todos]"))
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As Nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_colaborador.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("Nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        If cb_colaborador.Items.Count > 0 Then
            cb_colaborador.SelectedIndex = 0
        End If
    End Sub

    Private Sub obtener_clientes()
        cb_cliente.Items.Clear()
        cb_cliente.Text = ""
        cb_cliente.Items.Add(New myItem("0", "[Todos]"))
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
        cb_cliente.SelectedIndex = 0

    End Sub
    Private Sub cargar_orden()
        cb_ordenado.Items.Clear()
        cb_ordenado.Items.Add(New myItem("1", "Cantidad"))
        cb_ordenado.Items.Add(New myItem("2", "Codigo"))
        cb_ordenado.Items.Add(New myItem("3", "Producto"))
        cb_ordenado.SelectedIndex = 0
    End Sub
    Private Sub btn_genera_reporte_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_genera_reporte_excel.Click

        sfd_excel.Filter = "Excel Files (*.xlsx*)|*.xlsx"
        If sfd_excel.ShowDialog = Windows.Forms.DialogResult.OK Then
            If CType(cb_tipo_reporte.SelectedItem, myItem).Value = 1 Then
                Reporte_ventas_ticket(CType(cb_colaborador.SelectedItem, myItem).Value, cb_colaborador.Text, dtp_inicio.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 2 Then
                Reporte_existencias(cb_ordenado.Text, rb_ascendente.Checked, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 3 Then
                Reporte_creditos_ticket(sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 4 Then
                Reporte_ventas_clientes(CType(cb_cliente.SelectedItem, myItem).Value, cb_cliente.Text, dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 5 Then
                Reporte_ingresos(dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 6 Then
                Reporte_ajuste_inventario(dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 7 Then
                Reporte_asistencia(CType(cb_colaborador.SelectedItem, myItem).Value, dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 8 Then
                Reporte_utilidad(dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 9 Then
                Reporte_productos_vendidos(dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 10 Then
                Reporte_utilidad_2(dtp_inicio.Value, dtp_termino.Value, sfd_excel.FileName)
            End If
        End If
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub cambio_controles()
        If CType(cb_tipo_reporte.SelectedItem, myItem).Value = 1 Then ' Reporte de ventas x ticket
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = False
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = True
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 2 Then 'Reporte de Existencias
            dtp_inicio.Enabled = False
            dtp_termino.Enabled = False
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = True
            rb_ascendente.Enabled = True
            rb_descendente.Enabled = True
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 3 Then 'Reporte de Creditos
            dtp_inicio.Enabled = False
            dtp_termino.Enabled = False
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 4 Then 'Reporte de ventas por cliente
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = True
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 5 Then 'Reporte de ingresos
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 6 Then 'Reporte de ajuste de inventario
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 7 Then 'Reporte de asistencia
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = True
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 8 Then 'Reporte de utilidad
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = True
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 9 Then 'Reporte de productos_vendidos
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        ElseIf CType(cb_tipo_reporte.SelectedItem, myItem).Value = 10 Then 'Reporte de utilidad
            dtp_inicio.Enabled = True
            dtp_termino.Enabled = True
            cb_cliente.Enabled = False
            cb_colaborador.Enabled = False
            cb_ordenado.Enabled = False
            rb_ascendente.Enabled = False
            rb_descendente.Enabled = False
        End If
    End Sub
    Private Sub cb_tipo_reporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_tipo_reporte.SelectedIndexChanged
        If cargado = True Then
            cambio_controles()
        End If
    End Sub
    Private Sub Reporte_ventas_ticket(ByVal id_usuario As Integer, ByVal nombre_usuario As String, ByVal fecha_inicio As Date, nombre_archivo As String)
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



        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        Dim filtro As String = ""
        If id_usuario <> 0 Then
            filtro = "AND id_empleado_caja=" & id_usuario & ""
        End If

        ''Conectar()
        rs.Open("SELECT MIN(id_venta) As folio_inicio,MAX(id_venta) As folio_termino FROM venta WHERE date(fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            excel_app.Cells(8, 3) = "Del folio " & rs.Fields("folio_inicio").Value & " al folio " & rs.Fields("folio_termino").Value & " "
            Rango = wSheet.Range(excel_app.Cells(8, 3), excel_app.Cells(8, 6))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        ''conn.close()

        'excel_app.Cells(8, 7) = dtp_fecha.Value.ToLongDateString
        'Rango = wSheet.Range(excel_app.Cells(8, 9), excel_app.Cells(8, 9))
        '.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        'Rango.Font.Bold = True
        '.Font.Size = 10
        'Rango.Merge()

        excel_app.Cells(8, 10) = "Colaborador: " & nombre_usuario
        Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()


        excel_app.Cells(10, 3) = "REPORTE DE VENTAS," & " " & UCase(fecha_inicio.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "PRODUCTOS VENDIDOS"
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

        excel_app.Cells(13, 12) = "PRECIO VENTA"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 14) = "IMPORTE"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        row = 14
        filtro = ""
        If id_usuario <> 0 Then
            filtro = "AND v.id_empleado_caja=" & id_usuario & ""
        End If

        Dim rw, ry As New ADODB.Recordset
        rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta_detalle vd " &
           "JOIN venta v ON vd.id_venta=v.id_venta " &
           "JOIN producto p ON p.id_producto=vd.id_producto " &
           "WHERE v.status='CERRADA' AND DATE(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " ", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " &
                                   "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " &
                           "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND v.status='CERRADA' AND DATE(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " ", conn)
                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        ry.Open("SELECT SUM(vd.cantidad) AS cantidad_vendido FROM venta_detalle vd " &
                       "JOIN venta v ON v.id_venta=vd.id_venta " &
               "WHERE vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND v.status='CERRADA' AND DATE(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " ORDER BY vd.cantidad DESC", conn)
                        If ry.RecordCount > 0 Then
                            While Not ry.EOF
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

                                excel_app.Cells(row, 8) = ry.Fields("cantidad_vendido").Value
                                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 9))
                                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                Rango.Merge()

                                excel_app.Cells(row, 10) = rs.Fields("unidad").Value
                                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                Rango.Merge()

                                excel_app.Cells(row, 12) = FormatCurrency(rw.Fields("precio").Value)
                                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                Rango.Merge()

                                excel_app.Cells(row, 14) = FormatCurrency(ry.Fields("cantidad_vendido").Value * rw.Fields("precio").Value)
                                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                                Rango.Merge()

                                row += 1
                                ry.MoveNext()
                            End While
                        End If
                        ry.Close()
                        rw.MoveNext()
                    End While
                End If
                rw.Close()
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
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 4) = "DESCRIPCIÓN"
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

        excel_app.Cells(row, 12) = "PRECIO"
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()
        row += 1

        filtro = ""
        If id_usuario <> 0 Then
            filtro = "AND venta.id_empleado_caja=" & id_usuario & ""
        End If
        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,venta_detalle.id_venta,precio AS precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & "),venta_detalle.precio) AS puntero " &
    "FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " &
    "WHERE venta.status='REGALIA' AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " GROUP BY puntero " &
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
        If id_usuario <> 0 Then
            filtro = " AND v.id_empleado_caja=" & id_usuario & ""
        End If

        rs.Open("SELECT v.id_venta,v.id_empleado_caja,v.id_empleado_validacion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja,CONCAT(p2.nombre,' ',p2.ap_paterno,' ',p2.ap_materno) AS empleado_validacion FROM venta v,empleado e,persona p,empleado e2 ,persona p2 WHERE v.status='REGALIA' AND e.id_empleado=v.id_empleado_caja AND e.id_persona=p.id_persona AND e2.id_empleado=v.id_empleado_validacion AND e2.id_persona=p2.id_persona AND date(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " ORDER BY id_venta DESC", conn)
        If rs.RecordCount > 0 Then
            row += 1
            While Not rs.EOF
                If x = 0 Then
                    excel_app.Cells(row, 2) = "FOLIO TICKET"

                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 4) = "COLABORADOR EN CAJA"
                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 8) = "PERSONA QUE AUTORIZÓ"
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
                row += 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
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

        If id_usuario <> 0 Then
            filtro = " AND venta.id_empleado_caja=" & id_usuario & ""
        End If

        rs.Open("SELECT venta.subtotal,venta.total_impuestos,venta.total,venta.id_venta, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " &
               "FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente " &
               "WHERE venta.status='PENDIENTE' and date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & "", conn)
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
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        ''conn.close()
        ''conn = nothing
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
        If id_usuario <> 0 Then
            filtro = " AND devoluciones.id_empleado=" & id_usuario & ""
        End If
        'Conectar()

        rs.Open("SELECT devoluciones.id_venta,devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,devoluciones_detalle.unidad,devoluciones.total,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE DATE(devoluciones.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) AND devoluciones_detalle.id_producto=id) AS cantidad,devoluciones_detalle.descripcion AS producto " &
               " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion " &
               "WHERE DATE(devoluciones.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) GROUP BY id_producto", conn)
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

                row += 1
                rs.MoveNext()
            End While
            filtro = ""
            If id_usuario <> 0 Then
                filtro = " AND id_empleado=" & id_usuario & ""
            End If
            Dim _rs As New ADODB.Recordset
            _rs.Open("SELECT CASE WHEN SUM(subtotal) IS NULL THEN 0 ELSE SUM(subtotal)  END  AS subtotal,CASE WHEN SUM(total_iva) IS NULL THEN 0 ELSE SUM(total_iva)  END  AS total_iva,CASE WHEN SUM(total_otros) IS NULL THEN 0 ELSE SUM(total_otros)  END  AS total_otros,CASE WHEN SUM(total) IS NULL THEN 0 ELSE SUM(total)  END  AS total FROM devoluciones WHERE DATE(fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND (tipo_devolucion=3 OR  tipo_devolucion=4)", conn)
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
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        x = 0
        ''conn.close()
        ''conn = nothing
        row += 2
        '-- FIN OBTENER DEVOLUCIONES EN EFECTIVO
        filtro = ""
        If id_usuario <> 0 Then
            filtro = " AND venta.id_empleado=" & id_usuario & ""
        End If

        '---OBTENEMOS REGISTRO DE CANCELACIONES
        'Conectar()
        rs.Open("SELECT venta.id_venta,venta.fecha,venta.subtotal,venta.total_impuestos,venta.total,venta.id_empleado_validacion AS id_validacion,cliente.id_cliente,venta.id_empleado AS id_e,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_e) AS empleado_terminal,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_validacion) AS empleado_validacion,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE venta.STATUS='CANCELADA' " & filtro & " AND DATE(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'", conn)
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

                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "FECHA - HORA"

                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = "CLIENTE"

                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "SUBTOTAL"

                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 12) = "I.V.A."

                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 14) = "TOTAL"

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
        ''conn.close()
        ''conn = nothing
        '-- FIN OBTENER REGISTRO DE CANCELACIONES

        '---OBTENEMOS REGISTRO DE RETIROS
        excel_app.Cells(row, 2) = "RETIROS DE EFECTIVO EN CAJA"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 15))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "HORA"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 5) = "IMPORTE"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 8) = "USUARIO"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 12) = "DESCRIPCION"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        row += 1
        filtro = ""
        If id_usuario <> 0 Then
            filtro = " AND retiros.id_empleado=" & id_usuario & ""
        End If
        'conectar()
        Dim fecha_retiro As DateTime
        rs.Open("SELECT fecha,cantidad,descripcion,CONCAT(persona.nombre,' ',persona.ap_paterno) AS usuario FROM retiros JOIN empleado ON empleado.id_empleado=retiros.id_empleado JOIN persona ON persona.id_persona=empleado.id_persona " &
               "WHERE DATE(fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " ORDER BY retiros.cantidad", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                fecha_retiro = rs.Fields("fecha").Value
                excel_app.Cells(row, 2) = fecha_retiro.ToLongTimeString
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 5) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 7))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 8) = rs.Fields("usuario").Value
                Rango = wSheet.Range(excel_app.Cells(row, 8), excel_app.Cells(row, 11))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 15))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

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
        x = 0
        ''conn.close()
        ''conn = nothing
        row += 2
        '-- FIN OBTENER RETIROS EN CAJA

        Dim row_colum2 As Integer = row
        '---OBTENEMOS LOS COBROS DE CREDITOS
        excel_app.Cells(row, 2) = "COBROS DE CREDITOS"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 6))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "FORMA DE PAGO"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 5) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        row += 1

        limpiar_abonos()
        Dim total_cobros_creditos As Decimal = 0
        filtro = ""
        If id_usuario <> 0 Then
            filtro = " AND pagos_ventas.id_empleado_caja=" & id_usuario & ""
        End If

        'Conectar()
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND venta.status='PENDIENTE'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim i As Integer = rs.Fields("id_forma_pago").Value
                abonos(i) += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(pagos_ventas.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND  venta.status='CERRADA' AND DATE(venta.fecha)<>'" & Format(fecha_inicio, "yyyy-MM-dd") & "'  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim i As Integer = rs.Fields("id_forma_pago").Value
                abonos(i) += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        'conn.close()
        'conn = nothing
        For x = 0 To 4
            If abonos(x) <> 0 Then
                total_cobros_creditos += CDec(abonos(x))

                excel_app.Cells(row, 2) = nombre_forma_pago(x)
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 5) = FormatCurrency(abonos(x))
                Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                row += 1
            End If
        Next
        excel_app.Cells(row, 2) = "Total cobros creditos"
        celda_total(excel_app.Cells(row, 2))
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Merge()

        excel_app.Cells(row, 5) = FormatCurrency(total_cobros_creditos)
        celda_total(excel_app.Cells(row, 5))
        Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
        Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Merge()
        row += 2
        '---- FIN DE TOTAL DE COBROS CREDITOS

        '---OBTENEMOS LOS PAGOS A PROVEEDORES
        excel_app.Cells(row, 2) = "PAGO A PROVEEDORES"
        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 6))
        celda_pbk(excel_app.Cells(row, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row += 1

        excel_app.Cells(row, 2) = "FORMA DE PAGO"

        Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row, 5) = "TOTAL"

        Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        row += 1

        Dim total_pago_prov As Decimal = 0
        filtro = ""
        If id_usuario <> 0 Then
            filtro = " AND pagos_compras.id_empleado_pago=" & id_usuario & ""
        End If
        '
        rs.Open("SELECT forma_pago.id_forma_pago,forma_pago.nombre,SUM(pagos_compras.importe)AS total FROM pagos_compras JOIN forma_pago ON forma_pago.id_forma_pago=pagos_compras.id_forma_pago JOIN factura_compra ON factura_compra.id_factura_compra=pagos_compras.id_factura_compra  WHERE DATE(pagos_compras.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & "  GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_pago_prov += CDec(rs.Fields("total").Value)

                excel_app.Cells(row, 2) = UCase(rs.Fields("descripcion").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row, 5) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                row += 1
                rs.MoveNext()
            End While
            excel_app.Cells(row, 2) = "Total cobros creditos"
            celda_total(excel_app.Cells(row, 2))
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 4))
            Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Merge()

            excel_app.Cells(row, 5) = FormatCurrency(total_pago_prov)
            celda_total(excel_app.Cells(row, 5))
            Rango = wSheet.Range(excel_app.Cells(row, 5), excel_app.Cells(row, 6))
            Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Merge()
        Else
            excel_app.Cells(row, 2) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 6))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()
        'conn.close()
        'conn = nothing
        row += 2
        '---- FIN DE PAGO A PROVEEDORES
        '---OBTENEMOS LOS TOTALES POR CATEGORIA
        excel_app.Cells(row_colum2, 8) = "TOTALES POR CATEGORIA"
        Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 15))
        celda_pbk(excel_app.Cells(row_colum2, 8))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()
        row_colum2 += 1

        excel_app.Cells(row_colum2, 8) = "CATEGORIA"
        'celda_pbk(excel_app.Cells(13, 2))
        Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row_colum2, 11) = "I.V.A."
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row_colum2, 11), excel_app.Cells(row_colum2, 12))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(row_colum2, 13) = "TOTAL"
        'celda_pbk(excel_app.Cells(13, 3))
        Rango = wSheet.Range(excel_app.Cells(row_colum2, 13), excel_app.Cells(row_colum2, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        row_colum2 += 1

        ' Dim total_pago_prov As Decimal = 0
        filtro = ""
        If id_usuario <> 0 Then
            filtro = " AND venta.id_empleado_caja=" & id_usuario & ""
        End If

        rs.Open("SELECT categoria.nombre,SUM(venta_detalle.importe + venta_detalle.total_impuestos)AS total,SUM(venta_detalle.total_impuestos) AS impuesto FROM venta_detalle join producto on producto.id_producto=venta_detalle.id_producto JOIN categoria ON categoria.id_categoria=producto.id_categoria JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND venta.status='CERRADA' GROUP BY categoria.id_categoria", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_pago_prov += CDec(rs.Fields("total").Value)

                excel_app.Cells(row_colum2, 8) = UCase(rs.Fields("nombre").Value)
                Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 10))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row_colum2, 11) = FormatCurrency(rs.Fields("impuesto").Value)
                Rango = wSheet.Range(excel_app.Cells(row_colum2, 11), excel_app.Cells(row_colum2, 12))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                excel_app.Cells(row_colum2, 13) = FormatCurrency(rs.Fields("total").Value)
                Rango = wSheet.Range(excel_app.Cells(row_colum2, 13), excel_app.Cells(row_colum2, 14))
                Rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Merge()

                row_colum2 += 1
                rs.MoveNext()
            End While

        Else
            excel_app.Cells(row_colum2, 8) = "No se encontraron resultados"
            Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 13))
            Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            Rango.Font.Bold = True
            Rango.Font.Size = 10
            Rango.Merge()
        End If
        rs.Close()

        row_colum2 += 2
        '---- FIN DE TOTAL POR CATEGORIAS

        '---OBTENEMOS LOS TOTALES DE LAS VENTAS
        Dim total_ventas As Decimal = 0

        row_colum2 += 1

        filtro = ""
        If id_usuario <> 0 Then
            filtro = " AND venta.id_empleado_caja=" & id_usuario & ""
        End If

        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE DATE(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' " & filtro & " AND venta.status='CERRADA' GROUP BY forma_pago.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                total_ventas += CDec(rs.Fields("total").Value)

                excel_app.Cells(row_colum2, 8) = UCase(rs.Fields("nombre").Value)
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

                row_colum2 += 1
                rs.MoveNext()
            End While
            excel_app.Cells(row_colum2, 8) = "Total ventas"
            celda_total(excel_app.Cells(row_colum2, 8))
            Rango = wSheet.Range(excel_app.Cells(row_colum2, 8), excel_app.Cells(row_colum2, 10))
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

        row_colum2 += 2
        '---- FIN DE TOTALES DE VENTA



        'Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_Venta_Tickets.xls"

        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_existencias(ByVal orden As String, ByVal ASC As Integer, nombre_archivo As String)
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

        wSheet.Name = "Existencias"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6


        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        excel_app.Cells(8, 7) = UCase(Now.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()


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

        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "DESCRIPCIÓN"

        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 8) = "UNIDAD"

        Rango = wSheet.Range(excel_app.Cells(13, 8), excel_app.Cells(13, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "CANTIDAD"

        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        Dim filtro As String = ""
        If orden = "Cantidad" Then
            filtro = "ORDER BY producto_sucursal.cantidad"
        ElseIf orden = "Codigo" Then
            filtro = "ORDER BY producto.codigo"
        ElseIf orden = "Producto" Then
            filtro = "ORDER BY producto.nombre"
        End If
        If ASC = 1 Then
            filtro = filtro & " ASC"
        Else
            filtro = filtro & " DESC"
        End If
        row = 15

        '---OBTENEMOS EL INVENTARO DE PRODUCTOS
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

        '------FIN OBTENER PRODUCTOS DE PUBLICO EN GENERAL

        Dim strFileName As String = nombre_archivo
        'Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_existencias.xls"
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
    Private Sub Reporte_creditos_ticket(ByVal nombre_archivo As String)
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

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        excel_app.Cells(8, 7) = UCase(Now.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(8, 7), excel_app.Cells(8, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()


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

                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 4) = "FECHA - HORA"
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 6) = "CLIENTE"
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = True
                Rango.Merge()

                excel_app.Cells(row, 10) = "SUBTOTAL"
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

                _rs.Open("SELECT CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS agente " &
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

        'Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_creditos.xls"

        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_ventas_clientes(ByVal id_cliente As Integer, ByVal nombre_cliente As String, ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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


        wSheet.Name = "Ventas"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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


        Dim filtro As String = ""



        excel_app.Cells(8, 10) = "CLIENTE: " & UCase(nombre_cliente)
        Rango = wSheet.Range(excel_app.Cells(8, 10), excel_app.Cells(8, 15))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
        Rango.Font.Bold = True
        Rango.Font.Size = 10
        Rango.Merge()

        excel_app.Cells(10, 3) = "REPORTE DE VENTAS POR CLIENTE"

        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()

        excel_app.Cells(12, 2) = "PRODUCTOS VENDIDOS A " & UCase(nombre_cliente)
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
        If fecha_inicio = fecha_termino Then
            filtro = "AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(venta.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If


        '---OBTENEMOS REGISTRO DE PRODUCTOS VENDIDOS A PUBLICO EN GENERAL

        Dim filtro_cliente As String = ""

        If id_cliente > 1 Then
            filtro_cliente = "AND venta.id_cliente=" & id_cliente & ""
        End If
        rs.Open("SELECT venta_detalle.id_producto AS id,venta_detalle.descripcion,venta_detalle.precio AS  precio_vendido,unidad,producto.codigo, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' " & filtro & " " & filtro_cliente & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='CERRADA' " & filtro & " " & filtro_cliente & "),venta_detalle.precio) AS puntero " &
"FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta JOIN producto ON producto.id_producto=venta_detalle.id_producto " &
"WHERE venta.status='CERRADA' " & filtro & " " & filtro_cliente & " GROUP BY puntero " &
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

        filtro = ""

        If fecha_inicio = fecha_termino Then
            filtro = "AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(venta.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If

        rs.Open("SELECT id_producto AS id,venta_detalle.descripcion,venta_detalle.id_venta,precio AS precio_vendido,unidad, (SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' " & filtro & " AND venta.id_cliente=" & id_cliente & ") AS cantidad_vendido,concat(venta_detalle.id_producto,(SELECT SUM(cantidad) FROM venta_detalle  JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE id_producto=id AND precio=precio_vendido AND venta.status='REGALIA' " & filtro & " AND venta.id_cliente=" & id_cliente & "),venta_detalle.precio) AS puntero " &
    "FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta " &
    "WHERE venta.status='REGALIA' " & filtro & " AND venta.id_cliente=" & id_cliente & " GROUP BY puntero " &
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
        If fecha_inicio = fecha_termino Then
            filtro = "AND date(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(v.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If

        rs.Open("SELECT v.id_venta,v.id_empleado_caja,v.id_empleado_validacion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja,CONCAT(p2.nombre,' ',p2.ap_paterno,' ',p2.ap_materno) AS empleado_validacion FROM venta v,empleado e,persona p,empleado e2 ,persona p2 WHERE v.status='REGALIA' AND v.id_cliente=" & id_cliente & " AND e.id_empleado=v.id_empleado_caja AND e.id_persona=p.id_persona AND e2.id_empleado=v.id_empleado_validacion AND e2.id_persona=p2.id_persona " & filtro & " ORDER BY id_venta DESC", conn)
        If rs.RecordCount > 0 Then
            row += 1
            While Not rs.EOF
                If x = 0 Then
                    excel_app.Cells(row, 2) = "FOLIO TICKET"
                    Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 4) = "COLABORADOR EN CAJA"
                    Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 7))
                    Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    Rango.Font.Bold = True
                    Rango.Merge()

                    excel_app.Cells(row, 8) = "PERSONA QUE AUTORIZÓ"
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

        If fecha_inicio = fecha_termino Then
            filtro = "AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(venta.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If
        'Conectar()
        rs.Open("SELECT venta.subtotal,venta.total_impuestos,venta.total,venta.id_venta, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ',persona.ap_paterno) END AS nombre " &
               "FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente " &
               "WHERE venta.status='PENDIENTE' " & filtro & "AND venta.id_cliente=" & id_cliente & "", conn)
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
        If fecha_inicio = fecha_termino Then
            filtro = "AND date(devoluciones.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(devoluciones.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If
        'Conectar()
        rs.Open("SELECT devoluciones.id_venta,devoluciones_detalle.id_producto AS id,devoluciones_detalle.precio_unitario,devoluciones_detalle.unidad,devoluciones.total,(SELECT CASE WHEN SUM(devoluciones_detalle.cantidad) IS NULL THEN 0 ELSE SUM(devoluciones_detalle.cantidad) END  AS cantidad FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion WHERE devoluciones_detalle.id_producto=id  " & filtro & " AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4)) AS cantidad,devoluciones_detalle.descripcion AS producto " &
               " FROM devoluciones_detalle JOIN devoluciones ON devoluciones.id_devolucion=devoluciones_detalle.id_devolucion JOIN venta ON venta.id_venta=devoluciones.id_venta " &
               "WHERE venta.id_cliente=" & id_cliente & " " & filtro & " AND (devoluciones.tipo_devolucion=3 OR devoluciones.tipo_devolucion=4) GROUP BY id_producto", conn)
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

                row += 1
                rs.MoveNext()
            End While
            filtro = ""
            If fecha_inicio = fecha_termino Then
                filtro = "AND date(fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
            Else
                filtro = "AND date(fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
            End If
            Dim _rs As New ADODB.Recordset
            '  
            _rs.Open("SELECT CASE WHEN SUM(devoluciones.subtotal) IS NULL THEN 0 ELSE SUM(devoluciones.subtotal)  END  AS subtotal,CASE WHEN SUM(devoluciones.total_impuestos) IS NULL THEN 0 ELSE SUM(devoluciones.total_impuestos)  END  AS total_iva,CASE WHEN SUM(devoluciones.total_otros) IS NULL THEN 0 ELSE SUM(devoluciones.total_otros)  END  AS total_otros,CASE WHEN SUM(devoluciones.total) IS NULL THEN 0 ELSE SUM(devoluciones.total)  END  AS total FROM devoluciones JOIN venta ON venta.id_venta=devoluciones.id_venta  WHERE venta.id_cliente=" & id_cliente & " " & filtro & " AND (tipo_devolucion=3 OR  tipo_devolucion=4)", conn)
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
        If fecha_inicio = fecha_termino Then
            filtro = "AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(venta.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If

        '---OBTENEMOS REGISTRO DE CANCELACIONES
        'Conectar()
        rs.Open("SELECT venta.id_venta,venta.fecha,venta.subtotal,venta.total_impuestos,venta.total,venta.id_empleado_validacion AS id_validacion,cliente.id_cliente,venta.id_empleado AS id_e,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_e) AS empleado_terminal,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado e,persona p WHERE e.id_persona=p.id_persona AND e.id_empleado=id_validacion) AS empleado_validacion,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE venta.STATUS='CANCELADA' " & filtro & " AND venta.id_cliente=" & id_cliente & "", conn)
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

        '-- FIN OBTENER REGISTRO DE CANCELACIONES

        Dim row_colum2 As Integer = row

        '---OBTENEMOS LOS TOTALES DE LAS VENTAS
        Dim total_ventas As Decimal = 0


        row_colum2 += 1

        ' Dim total_pago_prov As Decimal = 0
        filtro = ""
        If fecha_inicio = fecha_termino Then
            filtro = "AND date(venta.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "AND date(venta.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If

        'Conectar()
        rs.Open("SELECT forma_pago.nombre,SUM(pagos_ventas.importe)AS total FROM pagos_ventas JOIN forma_pago ON forma_pago.id_forma_pago=pagos_ventas.id_forma_pago JOIN venta ON venta.id_venta=pagos_ventas.id_venta  WHERE venta.status='CERRADA'  " & filtro & " AND venta.id_cliente=" & id_cliente & "  GROUP BY forma_pago.nombre", conn)
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


        ' Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_ventas_cliente.xls"

        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_ingresos(ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        If fecha_inicio = fecha_termino = True Then
            titulo_reporte = "Reporte de Ingresos del dia " & fecha_inicio.ToLongDateString
        Else
            titulo_reporte = "Reporte de Ingresos del " & fecha_inicio.ToLongDateString & " al " & fecha_termino.ToLongDateString
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
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "TIPO DE MOVIMIENTO"
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 7))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 8) = "IMPORTE"
        Rango = wSheet.Range(excel_app.Cells(13, 8), excel_app.Cells(13, 9))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "FORMA DE PAGO"
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 12) = "FECHA"

        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 14) = "CAJERO(A)"

        Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 17))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 18) = "VENDEDOR"

        Rango = wSheet.Range(excel_app.Cells(13, 18), excel_app.Cells(13, 21))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 22) = "ESTADO DE ENTREGA"

        Rango = wSheet.Range(excel_app.Cells(13, 22), excel_app.Cells(13, 24))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 25) = "CLIENTE"

        Rango = wSheet.Range(excel_app.Cells(13, 25), excel_app.Cells(13, 27))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()


        'row = 14

        Dim filtro As String = ""



        If fecha_inicio = fecha_termino Then
            filtro = " AND DATE(pv.fecha_cobro)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' "
        Else
            filtro = " AND DATE(pv.fecha_cobro) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "' "
        End If

        row = 15
        rs.Open("SELECT pv.id_venta,pv.importe,fp.nombre AS forma_pago,pv.fecha_cobro,CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS empleado_caja,v.id_cliente FROM pagos_ventas pv " &
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
                rw.Open("SELECT CONCAT(p.nombre,' ',p.ap_paterno,'',p.ap_materno) AS vendedor FROM empleado e " &
                        "JOIN persona p ON p.id_persona=e.id_persona " &
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

        If fecha_inicio = fecha_termino Then
            filtro2 = " AND DATE(d.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' "
        Else
            filtro2 = " AND DATE(d.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "' "
        End If

        rs.Open("SELECT d.fecha,d.importe,d.descripcion,CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) AS empleado_caja FROM depositos d " &
                "JOIN empleado e ON e.id_empleado=d.id_empleado_caja " &
                "JOIN persona p ON p.id_persona=e.id_persona " &
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
        rs.Open("SELECT fp.id_forma_pago,fp.nombre,SUM(pv.importe)AS total FROM pagos_ventas pv " &
 "JOIN forma_pago fp ON fp.id_forma_pago=pv.id_forma_pago " &
 "JOIN venta v ON v.id_venta=pv.id_venta  " &
 "WHERE v.status<>'CANCELADA' AND pv.status='ACTIVO' " & filtro & "" &
 "GROUP BY fp.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 12) = rs.Fields("nombre").Value
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
        '------FIN OBTENER PRODUCTOS DE PUBLICO EN GENERAL


        '  Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_ingresos.xls"
        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_ajuste_inventario(ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        excel_app.Cells(10, 3) = "REPORTE DE AJUSTE DE INVENTARIO"
        Rango = wSheet.Range(excel_app.Cells(10, 3), excel_app.Cells(10, 13))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()
        row = 11
        Dim filtro As String = ""
        If fecha_inicio = fecha_termino Then
            filtro = "WHERE DATE(ajuste_inventario.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "WHERE DATE(ajuste_inventario.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "' "
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

        '------FIN OBTENER REGISTRIOS DE AJUSTE DE INVENTARIO

        ' Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_ajuste_inventario.xls"
        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_asistencia(ByVal id_usuario As Integer, ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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


        wSheet.Name = "Asistencia"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        If fecha_inicio = fecha_termino = True Then
            If id_usuario = 0 Then
                filtro = "WHERE empleado_jornada.fecha='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
            Else
                filtro = "WHERE empleado_jornada.fecha='" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND empleado_jornada.id_empleado='" & id_usuario & "' "
            End If

        Else
            If id_usuario = 0 Then
                filtro = "WHERE empleado_jornada.fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND  '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
            Else
                filtro = "WHERE empleado_jornada.fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND  '" & Format(fecha_termino, "yyyy-MM-dd") & "' AND empleado_jornada.id_empleado='" & id_usuario & "' "
            End If
        End If

        Dim last_fecha As String = ""
        '---OBTENEMOS REGISTRO DE LOS AJUSTES DE INVENTARIO
        'Conectar()

        rs.Open("SELECT empleado_jornada.id_empleado,CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) AS colaborador,empleado_jornada.fecha,empleado_jornada.hora_entrada,empleado_jornada.hora_salida" &
             " FROM empleado_jornada " &
            "JOIN empleado ON empleado_jornada.id_empleado=empleado.id_empleado " &
            "JOIN persona ON persona.id_persona=empleado.id_persona " & filtro & "" &
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

        '  Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_asistencia.xls"

        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_utilidad(ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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


        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        If fecha_inicio = fecha_termino Then
            titulo_reporte = "Reporte de utilidad del dia " & fecha_inicio.ToLongDateString
        Else
            titulo_reporte = "Reporte de utilidad del " & fecha_inicio.ToLongDateString & " al " & fecha_termino.ToLongDateString
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



        If fecha_inicio = fecha_termino = True Then
            filtro = " AND DATE(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "' "
        Else
            filtro = " AND DATE(v.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "' "
        End If

        row = 15
        Dim total_utilidad As Decimal = 0
        Dim rw, ry, rx As New ADODB.Recordset
        rs.Open("SELECT DISTINCT (vd.id_producto), vd.descripcion,vd.unidad,p.codigo FROM venta v " &
                "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " &
                "JOIN producto p ON p.id_producto=vd.id_producto " &
                "WHERE  1 " & filtro & " " &
                "AND (v.status='CERRADA' OR v.status='PENDIENTE')", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                rw.Open("SELECT DISTINCT(vd.precio) FROM venta v " &
                                   "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " &
                           "WHERE  1 AND vd.id_producto='" & rs.Fields("id_producto").Value & "'" & filtro & " " &
                               "AND (v.status='CERRADA' OR v.status='PENDIENTE') ", conn)
                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        rx.Open("SELECT vd.producto_costo AS costo FROM venta v " &
                                  "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " &
                          "WHERE  1 AND vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' " & filtro & " " &
                              "AND (v.status='CERRADA' OR v.status='PENDIENTE') ", conn)
                        If rx.RecordCount > 0 Then
                            ry.Open("SELECT SUM(vd.cantidad) AS cantidad FROM venta v " &
                                   "JOIN venta_detalle vd ON vd.id_venta=v.id_venta " &
                           "WHERE  1 AND vd.id_producto='" & rs.Fields("id_producto").Value & "' AND vd.precio='" & rw.Fields("precio").Value & "' AND vd.producto_costo='" & rx.Fields("costo").Value & "' " & filtro & " " &
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

        'Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_utilidad.xls"
        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_productos_vendidos(ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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


        wSheet.Name = "Ventas"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6


        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        excel_app.Cells(10, 3) = "REPORTE DE PRODUCTOS VENDIDOS DEL " & UCase(fecha_inicio.ToLongDateString) & " AL " & UCase(fecha_termino.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(10, 2), excel_app.Cells(10, 18))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()



        excel_app.Cells(13, 2) = "CANTIDAD"
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        celda_pbk(excel_app.Cells(13, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "UNIDAD"
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 5))
        celda_pbk(excel_app.Cells(13, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 6) = "CONCEPTO"
        Rango = wSheet.Range(excel_app.Cells(13, 6), excel_app.Cells(13, 9))
        celda_pbk(excel_app.Cells(13, 6))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "PRECIO UNITARIO"
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        celda_pbk(excel_app.Cells(13, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 12) = "IMPORTE"
        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        celda_pbk(excel_app.Cells(13, 12))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 14) = "IMPUESTOS"
        Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 15))
        celda_pbk(excel_app.Cells(13, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 16) = "TOTAL"
        Rango = wSheet.Range(excel_app.Cells(13, 16), excel_app.Cells(13, 17))
        celda_pbk(excel_app.Cells(13, 16))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()


        row = 14

        Dim filtro As String = ""

        If fecha_inicio = fecha_termino = True Then
            filtro = "WHERE DATE(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "WHERE DATE(v.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If


        Dim last_fecha As String = ""
        '---OBTENEMOS REGISTRO DE LOS AJUSTES DE INVENTARIO
        'Conectar()
        rs.Open("SELECT u.nombre AS unidad,vd.cantidad,vd.precio,vd.importe,vd.total_impuestos,vd.descripcion FROM venta_detalle vd " &
                "JOIN producto p ON p.id_producto=vd.id_producto " &
                "JOIN unidad u ON u.id_unidad=p.id_unidad " &
                "JOIN venta v ON v.id_venta=vd.id_venta " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                excel_app.Cells(row, 2) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 4) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 6) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 10) = rs.Fields("precio").Value
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("importe").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 14) = rs.Fields("total_impuestos").Value
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 16) = rs.Fields("importe").Value + rs.Fields("total_impuestos").Value
                Rango = wSheet.Range(excel_app.Cells(row, 16), excel_app.Cells(row, 17))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                row += 1
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

        '------FIN OBTENER REGISTRIOS DE AJUSTE DE INVENTARIO

        'Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_producto_vendidos.xls"
        Dim strFileName As String = nombre_archivo
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
    Private Sub Reporte_utilidad_2(ByVal fecha_inicio As Date, ByVal fecha_termino As Date, nombre_archivo As String)
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


        wSheet.Name = "Ventas"
        excel_app.Cells.Font.Size = 8
        excel_app.Columns.ColumnWidth = 6

        wSheet.Shapes.AddPicture(Application.StartupPath & "\logo.png",
CType(False, Microsoft.Office.Core.MsoTriState),
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

        excel_app.Cells(10, 3) = "REPORTE DE UTILIDAD DEL " & UCase(fecha_inicio.ToLongDateString) & " AL " & UCase(fecha_termino.ToLongDateString)
        Rango = wSheet.Range(excel_app.Cells(10, 2), excel_app.Cells(10, 18))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Font.Size = 12
        Rango.Merge()



        excel_app.Cells(13, 2) = "CANTIDAD"
        Rango = wSheet.Range(excel_app.Cells(13, 2), excel_app.Cells(13, 3))
        celda_pbk(excel_app.Cells(13, 2))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 4) = "UNIDAD"
        Rango = wSheet.Range(excel_app.Cells(13, 4), excel_app.Cells(13, 5))
        celda_pbk(excel_app.Cells(13, 4))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 6) = "CONCEPTO"
        Rango = wSheet.Range(excel_app.Cells(13, 6), excel_app.Cells(13, 9))
        celda_pbk(excel_app.Cells(13, 6))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 10) = "PRECIO COMPRA"
        Rango = wSheet.Range(excel_app.Cells(13, 10), excel_app.Cells(13, 11))
        celda_pbk(excel_app.Cells(13, 10))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 12) = "PRECIO VENTA"
        Rango = wSheet.Range(excel_app.Cells(13, 12), excel_app.Cells(13, 13))
        celda_pbk(excel_app.Cells(13, 12))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 14) = "UTILIDAD/UNIDAD"
        Rango = wSheet.Range(excel_app.Cells(13, 14), excel_app.Cells(13, 15))
        celda_pbk(excel_app.Cells(13, 14))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()

        excel_app.Cells(13, 16) = "TOTAL UTILIDAD"
        Rango = wSheet.Range(excel_app.Cells(13, 16), excel_app.Cells(13, 17))
        celda_pbk(excel_app.Cells(13, 16))
        Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        Rango.Font.Bold = True
        Rango.Merge()


        row = 14

        Dim filtro As String = ""

        If fecha_inicio = fecha_termino = True Then
            filtro = "WHERE DATE(v.fecha)='" & Format(fecha_inicio, "yyyy-MM-dd") & "'"
        Else
            filtro = "WHERE DATE(v.fecha) BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_termino, "yyyy-MM-dd") & "'"
        End If


        Dim last_fecha As String = ""
        '---OBTENEMOS REGISTRO DE LOS AJUSTES DE INVENTARIO
        'Conectar()
        rs.Open("SELECT u.nombre AS unidad,vd.cantidad,vd.precio,vd.importe,vd.total_impuestos,vd.descripcion,vd.tasa_impuestos,p.costo FROM venta_detalle vd " &
                "JOIN producto p ON p.id_producto=vd.id_producto " &
                "JOIN unidad u ON u.id_unidad=p.id_unidad " &
                "JOIN venta v ON v.id_venta=vd.id_venta " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim costo As Decimal = rs.Fields("costo").Value / (1 + rs.Fields("tasa_impuestos").Value)
                Dim utilidad_unitario As Decimal = rs.Fields("precio").Value - costo
                Dim utilidad As Decimal = rs.Fields("cantidad").Value * utilidad_unitario
                excel_app.Cells(row, 2) = rs.Fields("cantidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 2), excel_app.Cells(row, 3))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 4) = rs.Fields("unidad").Value
                Rango = wSheet.Range(excel_app.Cells(row, 4), excel_app.Cells(row, 5))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 6) = rs.Fields("descripcion").Value
                Rango = wSheet.Range(excel_app.Cells(row, 6), excel_app.Cells(row, 9))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 10) = costo
                Rango = wSheet.Range(excel_app.Cells(row, 10), excel_app.Cells(row, 11))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 12) = rs.Fields("precio").Value
                Rango = wSheet.Range(excel_app.Cells(row, 12), excel_app.Cells(row, 13))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 14) = utilidad_unitario
                Rango = wSheet.Range(excel_app.Cells(row, 14), excel_app.Cells(row, 15))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                excel_app.Cells(row, 16) = utilidad
                Rango = wSheet.Range(excel_app.Cells(row, 16), excel_app.Cells(row, 17))
                Rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                Rango.Font.Bold = False
                Rango.Merge()

                row += 1
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

        '------FIN OBTENER REGISTRIOS DE AJUSTE DE INVENTARIO

        'Dim strFileName As String = System.IO.Directory.GetCurrentDirectory() & "/Reporte_utilidad_2.xls"
        Dim strFileName As String = nombre_archivo
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

    Private Sub limpiar_abonos()
        For x = 0 To 4
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
End Class