Module funciones_tabla_paquetes

    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Function Estilo_producto_paquetes(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = ""
            .Width = 0
            .NullText = ""
            .ReadOnly = True
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "nombre"
            .Width = 150
            .NullText = ""
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Cant. Req."
            .Width = 85
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Cant. Alm."
            .Width = 90
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "5"
            .HeaderText = "cantidad"
            .Width = 90
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function


    Public Sub paquete_productos(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(Integer)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(Decimal)))
        datos.Columns.Add(New DataColumn("4", GetType(Decimal)))
        datos.Columns.Add(New DataColumn("5", GetType(Decimal)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_producto_paquetes(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

End Module

