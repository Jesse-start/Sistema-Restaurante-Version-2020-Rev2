Module funciones_vehiculos
    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Sub vehiculos(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(String)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(String)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(estilo_vehiculos(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

    Public Function estilo_vehiculos(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = "ID"
            .Width = 30
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "Numero"
            .Width = 80
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Tipo"
            .TextBox.Multiline = True
            .Width = 120
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function

End Module

