Module funciones_tabla_cuentasxpagar_remisiones
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea As Integer
    Public tabla_cuentasxpagar_remisiones As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_cuentasxpagar_remisiones(ByVal cuentasxpagar_remisiones As DataGridView)
        tabla_cuentasxpagar_remisiones = New DataTable("cuentasxpagar_remisiones")

        With tabla_cuentasxpagar_remisiones.Columns
            .Add(New DataColumn("id_factura_compra", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("remision", GetType(String)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("nombre_empleado", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_cuentasxpagar_remisiones)

        With cuentasxpagar_remisiones
            .DataSource = ds
            .DataMember = "cuentasxpagar_remisiones"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            '.Columns("id_factura").Visible = False
            '.Columns("id_factura").Width = 0
            .Columns("nombre_empleado").Visible = False
            .Columns("nombre_empleado").Width = 0
            With .Columns("id_factura_compra")
                .HeaderText = "Folio Recepcion"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("fecha")
                .HeaderText = "Fecha"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("remision")
                .HeaderText = "Remision"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .Width = 100
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With

        End With
    End Sub
    Public Sub agregar_cuentasxpagar_remisiones(ByVal id_factura As Integer, ByVal fecha As String, ByVal remision As String, ByVal importe As Decimal, ByVal nombre_empleado As String)
        linea = linea + 1
        tabla_linea = tabla_cuentasxpagar_remisiones.NewRow()
        tabla_linea("id_factura_compra") = id_factura
        tabla_linea("fecha") = fecha
        tabla_linea("remision") = remision
        tabla_linea("importe") = importe
        tabla_linea("nombre_empleado") = nombre_empleado
        tabla_cuentasxpagar_remisiones.Rows.Add(tabla_linea)
    End Sub
End Module
