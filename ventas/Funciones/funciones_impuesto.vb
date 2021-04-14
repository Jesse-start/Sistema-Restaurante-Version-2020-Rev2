Module funciones_impuestos

    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable

    Public Sub Catalogo(ByVal lista As ListBox)
        Dim i As Integer
        Dim conectar As ADODB.Recordset
        Dim coneccion As ADODB.Connection
        conectar = conector()
        coneccion = Conexion()

        conectar.Open("SELECT id_catalogo, nombre from impuesto_catalogo ", coneccion, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        i = 0
        While Not conectar.EOF
            lista.Items.Add(New myItem(conectar.Fields("id_catalogo").Value, conectar.Fields("nombre").Value))
            conectar.MoveNext()
            i = i + 1
        End While
        conectar.Close()
        coneccion.Close()
    End Sub

    Public Sub CategoriaImpuesto(ByVal Nodo As TreeNodeCollection)
        Dim i As Integer
        Dim conectar As ADODB.Recordset
        Dim coneccion As ADODB.Connection
        conectar = conector()
        coneccion = Conexion()

        conectar.Open("SELECT id_catalogo, nombre from impuesto_catalogo where fecha_baja is NULL", coneccion, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        i = 0
        While Not conectar.EOF
            Nodo.Add(conectar.Fields("id_catalogo").Value, conectar.Fields("nombre").Value)
            Nodo(i).Tag = conectar.Fields("id_catalogo").Value
            conectar.MoveNext()
            i = i + 1
        End While
        conectar.Close()
        coneccion.Close()
    End Sub

    Public Sub Impuesto(ByVal consulta As String, ByVal nombreTabla As String, ByVal grid As DataGrid)
        Dim conectar As ADODB.Recordset
        Dim coneccion As ADODB.Connection

        conectar = conector()
        coneccion = Conexion()

        grid.CaptionText = nombreTabla

        conectar.Open(consulta, coneccion, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        ds = New DataSet
        Tabla = New DataTable(nombreTabla)

        Tabla.Columns.Add(New DataColumn("1", GetType(String)))
        Tabla.Columns.Add(New DataColumn("2", GetType(String)))
        Tabla.Columns.Add(New DataColumn("3", GetType(String)))
        Tabla.Columns.Add(New DataColumn("4", GetType(String)))

        While Not conectar.EOF
            Linea = Tabla.NewRow()
            Linea(0) = conectar.Fields("id_impuesto").Value
            Linea(1) = conectar.Fields("nombre").Value
            Linea(2) = conectar.Fields("alias").Value
            Linea(3) = conectar.Fields("porcentaje").Value
            Tabla.Rows.Add(Linea)
            conectar.MoveNext()
        End While

        ds.Tables.Add(Tabla)

        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_impuesto(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
        conectar.Close()
        coneccion.Close()

    End Sub

    Public Function Estilo_impuesto(ByVal tabla As String)
        Dim sColumna As DataGridTextBoxColumn
        Dim Estilo As DataGridTableStyle
        Estilo = New DataGridTableStyle

        Estilo.MappingName = tabla

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "1"
            .Width = 0
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "2"
            .Width = 0
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Alias"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Porcentaje"
            .Width = 80
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function

End Module
