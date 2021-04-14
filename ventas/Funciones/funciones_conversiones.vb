Module funciones_conversiones

    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Function Estilo_Conversiones(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = "Cant."
            .Width = 30
            .NullText = ""
            .ReadOnly = True
            .Alignment = HorizontalAlignment.Center
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "Producto origen"
            .Width = 210
            .NullText = ""
            .ReadOnly = False
            .Alignment = HorizontalAlignment.Center
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = ""
            .Width = 0
            .NullText = ""
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = ""
            .Width = 10
            .ReadOnly = False
            .Alignment = HorizontalAlignment.Center
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "5"
            .HeaderText = "Cant."
            .Width = 30
            .ReadOnly = False
            .Alignment = HorizontalAlignment.Center
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "6"
            .HeaderText = "Producto a generar."
            .Width = 210
            .ReadOnly = False
            .Alignment = HorizontalAlignment.Center
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "7"
            .HeaderText = ""
            .Width = 0
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function


    Public Sub Conversiones(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(String)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(String)))
        datos.Columns.Add(New DataColumn("4", GetType(String)))
        datos.Columns.Add(New DataColumn("5", GetType(String)))
        datos.Columns.Add(New DataColumn("6", GetType(String)))
        datos.Columns.Add(New DataColumn("7", GetType(String)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_Conversiones(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

End Module
