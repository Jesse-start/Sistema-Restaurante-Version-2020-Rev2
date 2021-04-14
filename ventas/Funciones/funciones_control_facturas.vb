Module funciones_control_facturas
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_control_facturas As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_control_facturas(ByVal control_facturas As DataGridView)
        tabla_control_facturas = New DataTable("control_facturas")

        With tabla_control_facturas.Columns
            .Add(New DataColumn("id_factura", GetType(Integer)))
            .Add(New DataColumn("num_factura", GetType(Integer)))
            .Add(New DataColumn("cliente", GetType(String)))
            .Add(New DataColumn("fecha_larga", GetType(String)))
            .Add(New DataColumn("total", GetType(String)))
            .Add(New DataColumn("fecha", GetType(Date)))
            .Add(New DataColumn("estatus", GetType(String)))
            .Add(New DataColumn("razon_social", GetType(String)))
            .Add(New DataColumn("folio_factura", GetType(Integer)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_control_facturas)

        With control_facturas
            .DataSource = ds
            .DataMember = "control_facturas"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_factura").Visible = False
            .Columns("fecha").Visible = False
            .Columns("razon_social").Visible = False
            With .Columns("num_factura")
                .HeaderText = "No Prefactura"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("cliente")
                .HeaderText = "Cliente"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("fecha_larga")
                .HeaderText = "Fecha"
                .Width = 180
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "total"
                .Width = 80
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("estatus")
                .HeaderText = "Estatus"
                .Width = 80
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("folio_factura")
                .HeaderText = "No Factura"
                .Width = 60
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_control_facturas(ByVal id_factura As Integer, ByVal num_factura As String, ByVal cliente As String, ByVal fecha_larga As String, ByVal total As Decimal, ByVal fecha As Date, ByVal estatus As String, ByVal razon_social As String)
        tabla_linea = tabla_control_facturas.NewRow()
        tabla_linea("id_factura") = id_factura
        tabla_linea("num_factura") = num_factura
        tabla_linea("cliente") = cliente
        tabla_linea("fecha_larga") = fecha_larga
        tabla_linea("total") = total
        tabla_linea("fecha") = fecha
        tabla_linea("estatus") = estatus
        tabla_linea("razon_social") = razon_social
        tabla_control_facturas.Rows.Add(tabla_linea)
    End Sub
End Module
