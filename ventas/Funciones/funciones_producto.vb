Module Funciones_producto
    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Function Estilo_producto_Agrupado(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = "id"
            .Width = 0
            .NullText = ""
            .ReadOnly = True
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "nombre"
            .Width = 90
            .NullText = ""
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "# de articulos"
            .Width = 100
            .NullText = ""
            .ReadOnly = True
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function


    Public Sub producto_Agrupado(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(String)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(String)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_producto_Agrupado(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True

    End Sub
End Module
