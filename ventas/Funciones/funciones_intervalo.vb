Module funciones_intervalo

    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Function Estilo_Intervalo(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = "Nombre"
            .Width = 90
            .NullText = ""
            .ReadOnly = True
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "Minimo"
            .Width = 45
            .NullText = ""
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Maximo"
            .Width = 45
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Utilidad"
            .Width = 50
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "5"
            .HeaderText = "Desc."
            .Width = 50
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "6"
            .HeaderText = "utilidad_catalogo"
            .Width = 0
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "7"
            .HeaderText = "id_catalogo"
            .Width = 0
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "8"
            .HeaderText = "precio"
            .Width = 50
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function


    Public Sub intervalo(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

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
        datos.Columns.Add(New DataColumn("8", GetType(String)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_Intervalo(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

End Module
