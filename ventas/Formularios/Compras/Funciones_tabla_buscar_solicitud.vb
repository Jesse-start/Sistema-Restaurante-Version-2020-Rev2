Module Funciones_tabla_buscar_solicitud
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_buscar_solicitud As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_buscar_solicitud(ByVal buscar_solicitud As DataGridView)
        tabla_buscar_solicitud = New DataTable("buscar_solicitud")

        With tabla_buscar_solicitud.Columns

            .Add(New DataColumn("id_doc", GetType(Integer)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("cancelado", GetType(Boolean)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_buscar_solicitud)

        With buscar_solicitud
            .DataSource = ds
            .DataMember = "buscar_solicitud"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_doc")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("nombre")
                .HeaderText = "Solicitud"
                .Width = 90
                .ReadOnly = True
            End With
            With .Columns("fecha")
                .HeaderText = "Fecha"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "Total"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("cancelado")
                .HeaderText = "Cancelado"
                .Width = 40
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_tabla_buscar_solicitud(ByVal id_solicitud As Integer, ByVal nombre As String, ByVal fecha As String, ByVal total As Decimal, ByVal cancelado As Boolean)
        tabla_linea = tabla_buscar_solicitud.NewRow()
        tabla_linea("id_solicitud") = id_solicitud
        tabla_linea("nombre") = nombre
        tabla_linea("fecha") = fecha
        tabla_linea("total") = total
        tabla_linea("cancelado") = cancelado
        tabla_buscar_solicitud.Rows.Add(tabla_linea)
    End Sub
End Module