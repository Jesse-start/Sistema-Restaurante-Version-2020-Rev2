Module funciones_precio
    Dim ds As DataSet
    Dim Linea As DataRow
    Dim datos As DataTable

    Public Function Estilo_Precio(ByVal tabla As String)
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
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .HeaderText = "Nombre"
            .Width = 90
            .NullText = ""
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Precio"
            .Width = 90
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "% Ganancia"
            .Width = 70
            .NullText = "0"
            .ReadOnly = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function

    Public Sub precio(ByVal nombreTabla As String, ByVal grid As DataGrid, ByRef datos As DataTable)
        Dim conectar As ADODB.Recordset
        Dim coneccion As ADODB.Connection
        grid.CaptionText = nombreTabla
        Conectar = conector()
        coneccion = Conexion()

        ds = New DataSet
        datos = New DataTable(nombreTabla)

        datos.Columns.Add(New DataColumn("1", GetType(String)))
        datos.Columns.Add(New DataColumn("2", GetType(String)))
        datos.Columns.Add(New DataColumn("3", GetType(String)))
        datos.Columns.Add(New DataColumn("4", GetType(String)))

        conectar.Open("SELECT id_nombre_precio, nombre from precio_nombre ORDER BY nombre ", coneccion, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        While Not conectar.EOF
            Linea = datos.NewRow()
            Linea(0) = conectar.Fields("id_nombre_precio").Value
            Linea(1) = conectar.Fields("nombre").Value
            Linea(2) = "0.00"
            Linea(3) = "0.00"
            datos.Rows.Add(Linea)
            conectar.MoveNext()
        End While
        conectar.Close()
        coneccion.Close()

        ds.Tables.Add(datos)

        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_Precio(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True

    End Sub
End Module
