Module funciones_tabla_cuentasxpagar_proveedores
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea As Integer
    Public tabla_cuentasxpagar_proveedores As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_cuentasxpagar_proveedores(ByVal cuentasxpagar_proveedores As DataGridView)
        tabla_cuentasxpagar_proveedores = New DataTable("cuentasxpagar_proveedores")

        With tabla_cuentasxpagar_proveedores.Columns
            .Add(New DataColumn("id_proveedor", GetType(Integer)))
            .Add(New DataColumn("proveedor", GetType(String)))
            .Add(New DataColumn("razon_social", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_cuentasxpagar_proveedores)

        With cuentasxpagar_proveedores
            .DataSource = ds
            .DataMember = "cuentasxpagar_proveedores"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_proveedor").Visible = False
            .Columns("id_proveedor").Width = 0
            .Columns("razon_social").Visible = False
            .Columns("razon_social").Width = 0

            With .Columns("proveedor")
                .HeaderText = "proveedor"
                .Width = 400
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_cuentasxpagar_proveedores(ByVal id_proveedor As Integer, ByVal proveedor As String, ByVal razon_social As String)
        linea = linea + 1
        tabla_linea = tabla_cuentasxpagar_proveedores.NewRow()
        tabla_linea("id_proveedor") = id_proveedor
        tabla_linea("proveedor") = proveedor
        tabla_linea("razon_social") = razon_social
        tabla_cuentasxpagar_proveedores.Rows.Add(tabla_linea)
    End Sub
End Module
