Module funciones_tabla_cuentasxcobrar_tickets
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea As Integer
    Public tabla_cuentasxcobrar_tickets As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_cuentasxcobrar_tickets(ByVal cuentasxcobrar_tickets As DataGridView)
        tabla_cuentasxcobrar_tickets = New DataTable("cuentasxcobrar_tickets")

        With tabla_cuentasxcobrar_tickets.Columns
            .Add(New DataColumn("id_venta", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("folio", GetType(String)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("cobrado", GetType(Decimal)))
            .Add(New DataColumn("saldo", GetType(Decimal)))
            .Add(New DataColumn("nombre_empleado", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_cuentasxcobrar_tickets)

        With cuentasxcobrar_tickets
            .DataSource = ds
            .DataMember = "cuentasxcobrar_tickets"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_venta").Visible = False
            .Columns("id_venta").Width = 0
            .Columns("nombre_empleado").Visible = False
            .Columns("nombre_empleado").Width = 0

            With .Columns("fecha")
                .HeaderText = "Fecha"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("Folio")
                .HeaderText = "Folio"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .Width = 70
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With
            With .Columns("cobrado")
                .HeaderText = "Cobrado"
                .Width = 70
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With
            With .Columns("saldo")
                .HeaderText = "Saldo"
                .Width = 70
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
            End With

        End With
    End Sub
    Public Sub agregar_cuentasxcobrar_tickets(ByVal id_venta As Integer, ByVal fecha As String, ByVal folio As String, ByVal importe As Decimal, ByVal cobrado As Decimal, ByVal saldo As Decimal, ByVal nombre_empleado As String)
        linea = linea + 1
        tabla_linea = tabla_cuentasxcobrar_tickets.NewRow()
        tabla_linea("id_venta") = id_venta
        tabla_linea("fecha") = fecha
        tabla_linea("folio") = folio
        tabla_linea("importe") = importe
        tabla_linea("cobrado") = cobrado
        tabla_linea("saldo") = saldo
        tabla_linea("nombre_empleado") = nombre_empleado
        tabla_cuentasxcobrar_tickets.Rows.Add(tabla_linea)
    End Sub
End Module
