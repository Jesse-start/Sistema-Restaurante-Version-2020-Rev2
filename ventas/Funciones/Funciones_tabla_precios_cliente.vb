Module Funciones_tabla_precios_cliente
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_precios_cliente As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_precios_clientes(ByVal precios_cliente As DataGridView)
        tabla_precios_cliente = New DataTable("precios_cliente")

        With tabla_precios_cliente.Columns

            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("producto", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_precios_cliente)

        With precios_cliente
            .DataSource = ds
            .DataMember = "precios_cliente"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_producto")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("producto")
                .HeaderText = "Producto"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("precio")
                .HeaderText = "Precio"
                .Width = 80
                .ReadOnly = False
                .DefaultCellStyle.Format = "c"
            End With
        End With
    End Sub
    Public Sub agregar_precios_cliente(ByVal id_producto As Integer, ByVal producto As String, ByVal precio As Decimal)
        tabla_linea = tabla_precios_cliente.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("producto") = producto
        tabla_linea("precio") = precio
        tabla_precios_cliente.Rows.Add(tabla_linea)
    End Sub
End Module
