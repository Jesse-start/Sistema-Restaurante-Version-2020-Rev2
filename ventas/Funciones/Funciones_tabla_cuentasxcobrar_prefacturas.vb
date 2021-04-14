Module funciones_tabla_cuentasxcobrar_prefactura
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea As Integer
    Public tabla_cuentasxcobrar_factura As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_cuentasxcobrar_factura(ByVal cuentasxcobrar_factura As DataGridView)
        tabla_cuentasxcobrar_factura = New DataTable("cuentasxcobrar_factura")

        With tabla_cuentasxcobrar_factura.Columns
            .Add(New DataColumn("id_factura", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("folio", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("folio_real", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_cuentasxcobrar_factura)

        With cuentasxcobrar_factura
            .DataSource = ds
            .DataMember = "cuentasxcobrar_factura"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_factura").Visible = False
            .Columns("id_factura").Width = 0

            With .Columns("fecha")
                .HeaderText = "Fecha"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("Folio")
                .HeaderText = "Folio Prefactura"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .Width = 60
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With
            With .Columns("folio_real")
                .HeaderText = "Folio factura"
                .Width = 70
                .ReadOnly = False
            End With
        End With
    End Sub
    Public Sub agregar_cuentasxcobrar_factura(ByVal id_factura As Integer, ByVal fecha As String, ByVal folio As String, ByVal total As Decimal, ByVal folio_real As String)
        linea = linea + 1
        tabla_linea = tabla_cuentasxcobrar_factura.NewRow()
        tabla_linea("id_factura") = id_factura
        tabla_linea("fecha") = fecha
        tabla_linea("folio") = folio
        tabla_linea("total") = total
        tabla_linea("folio_real") = folio_real
        tabla_cuentasxcobrar_factura.Rows.Add(tabla_linea)
    End Sub
End Module
