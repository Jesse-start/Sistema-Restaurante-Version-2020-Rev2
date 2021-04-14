Module Funciones_contacto
    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Sub contacto(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(String)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(String)))
        datos.Columns.Add(New DataColumn("4", GetType(String)))
        datos.Columns.Add(New DataColumn("5", GetType(String)))
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_contacto(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

    Public Function Estilo_contacto(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .HeaderText = "id"
            .Width = 0
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "Nombre"
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Apellido Paterno"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Apellido Materno"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "5"
            .HeaderText = "E-mail"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function
End Module
