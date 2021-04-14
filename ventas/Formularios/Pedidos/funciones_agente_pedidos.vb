Module funciones_agentes_pedidos
    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Sub agente_pedidos(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)

        grid.CaptionText = nombreTabla
        ds = New DataSet
        datos = New DataTable(nombreTabla)
        datos.Columns.Add(New DataColumn("1", GetType(String))) 'id_agente_pedidos  
        datos.Columns.Add(New DataColumn("2", GetType(String))) 'id_empleado        oculto
        datos.Columns.Add(New DataColumn("3", GetType(String)))  'nombre empleado.
        datos.Columns.Add(New DataColumn("4", GetType(String)))  'puesto
        datos.Columns.Add(New DataColumn("5", GetType(String)))  'id_movil          oculto
        datos.Columns.Add(New DataColumn("6", GetType(String)))  'num_unidad
        datos.Columns.Add(New DataColumn("7", GetType(String)))  'tipo_unidad
        ds.Tables.Add(datos)
        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(estilo_agente_pedidos(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
    End Sub

    Public Function estilo_agente_pedidos(ByVal tabla As String)
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
            .Width = 20
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Colaborador"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Puesto"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "5"
            .TextBox.Multiline = True
            .Width = 20
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "6"
            .HeaderText = "Unidad"
            .TextBox.Multiline = True
            .Width = 80
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "7"
            .HeaderText = "Tipo"
            .TextBox.Multiline = True
            .Width = 120
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function
End Module
