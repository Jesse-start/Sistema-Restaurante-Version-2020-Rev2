Module funciones_tabla_apartados
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_apartados As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_apartados(ByVal apartados As DataGridView)
        tabla_apartados = New DataTable("apartados")

        With tabla_apartados.Columns
            .Add(New DataColumn("id_apartado", GetType(Integer)))
            .Add(New DataColumn("num_ticket", GetType(String)))
            .Add(New DataColumn("cliente", GetType(String)))
            .Add(New DataColumn("fecha_hora", GetType(String)))
            .Add(New DataColumn("repartidor", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("retiro", GetType(Decimal)))
            .Add(New DataColumn("total_recibir", GetType(Decimal)))
            .Add(New DataColumn("estatus", GetType(String)))
            .Add(New DataColumn("estatus_pago", GetType(String)))
            'Ocultos
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_apartados)

        With apartados
            .DataSource = ds
            .DataMember = "apartados"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_apartado")
                .HeaderText = "No. Apartado"
                .Width = 60
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("num_ticket")
                .HeaderText = "Ticket"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("cliente")
                .HeaderText = "Cliente"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("fecha_hora")
                .HeaderText = "Fecha Entrega"
                .Width = 100
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("repartidor")
                .HeaderText = "Repartidor"
                .Width = 120
                .ReadOnly = True
            End With
            With .Columns("retiro")
                .HeaderText = "Retiro"
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("total_recibir")
                .HeaderText = "Total a Recibir"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("estatus")
                .HeaderText = "Estado"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("estatus_pago")
                .HeaderText = "Pago"
                .Width = 80
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_apartados(ByVal id_apartado As Integer, ByVal num_ticket As String, ByVal cliente As String, ByVal fecha_hora As String, ByVal repartidor As String, ByVal total As Decimal, ByVal retiro As Decimal, ByVal total_recibir As Decimal, ByVal estatus As String, ByVal estatus_pago As String)
        tabla_linea = tabla_apartados.NewRow()
        tabla_linea("id_apartado") = id_apartado
        tabla_linea("num_ticket") = num_ticket
        tabla_linea("cliente") = cliente
        tabla_linea("fecha_hora") = fecha_hora
        tabla_linea("repartidor") = repartidor
        tabla_linea("total") = total
        tabla_linea("retiro") = retiro
        tabla_linea("total_recibir") = total_recibir
        tabla_linea("estatus") = estatus
        tabla_linea("estatus_pago") = estatus_pago
        tabla_apartados.Rows.Add(tabla_linea)
    End Sub
End Module
