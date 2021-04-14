Module funciones_productos
        Dim ds As DataSet
        Dim Linea As DataRow
        Dim Tabla As DataTable
    ''funcion de productos de proveedores y cliente
    Public Sub style_productos(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(String)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(String)))
        datos.Columns.Add(New DataColumn("4", GetType(String)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_Productos2(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

    Public Function Estilo_Productos2(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = "id_producto"
            .Width = 0
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "Producto"
            .Width = 240
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Cantidad"
            .TextBox.Multiline = True
            .Width = 80
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Precio de compra"
            .TextBox.Multiline = True
            .Width = 100
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function
    End Module