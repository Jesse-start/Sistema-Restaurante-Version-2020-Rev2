Module funciones_tabla_catalogo_cliente
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_catalogo_cliente As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_catalogo_cliente(ByVal catalogo_cliente As DataGridView)
        tabla_catalogo_cliente = New DataTable("catalogo_cliente")

        With tabla_catalogo_cliente.Columns

            .Add(New DataColumn("id_cliente", GetType(String)))
            .Add(New DataColumn("alias", GetType(String)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_catalogo_cliente)

        With catalogo_cliente
            .DataSource = ds
            .DataMember = "catalogo_cliente"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_cliente")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("alias")
                .HeaderText = "Alias"
                .Width = 250
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_catalogo_cliente(ByVal id_cliente As Integer, ByVal cliente As String)
        tabla_linea = tabla_catalogo_cliente.NewRow()
        tabla_linea("id_cliente") = id_cliente
        tabla_linea("alias") = cliente
        tabla_catalogo_cliente.Rows.Add(tabla_linea)
    End Sub
End Module
