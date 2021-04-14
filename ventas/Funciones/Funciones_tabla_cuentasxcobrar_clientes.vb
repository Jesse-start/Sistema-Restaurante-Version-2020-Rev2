Module funciones_tabla_cuentasxcobrar_clientes
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea As Integer
    Public tabla_cuentasxcobrar_clientes As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_cuentasxcobrar_clientes(ByVal cuentasxcobrar_clientes As DataGridView)
        tabla_cuentasxcobrar_clientes = New DataTable("cuentasxcobrar_clientes")

        With tabla_cuentasxcobrar_clientes.Columns
            .Add(New DataColumn("id_cliente", GetType(Integer)))
            .Add(New DataColumn("cliente", GetType(String)))
            .Add(New DataColumn("credito", GetType(Integer)))
            .Add(New DataColumn("razon_social", GetType(String)))
        End With
       
        ds = New DataSet
        ds.Tables.Add(tabla_cuentasxcobrar_clientes)

        With cuentasxcobrar_clientes
            .DataSource = ds
            .DataMember = "cuentasxcobrar_clientes"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_cliente").Visible = False
            .Columns("id_cliente").Width = 0
            .Columns("credito").Visible = False
            .Columns("credito").Width = 0
            .Columns("razon_social").Visible = False
            .Columns("razon_social").Width = 0

            With .Columns("cliente")
                .HeaderText = "Cliente"
                .Width = 300
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_cuentasxcobrar_clientes(ByVal id_cliente As Integer, ByVal cliente As String, ByVal credito As Integer, ByVal razon_social As String)
        linea = linea + 1
        tabla_linea = tabla_cuentasxcobrar_clientes.NewRow()
        tabla_linea("id_cliente") = id_cliente
        tabla_linea("cliente") = cliente
        tabla_linea("credito") = credito
        tabla_linea("razon_social") = razon_social
        tabla_cuentasxcobrar_clientes.Rows.Add(tabla_linea)
    End Sub
End Module
