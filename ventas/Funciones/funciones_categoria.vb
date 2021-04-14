Module funciones_categoria

    Dim ds As DataSet
    Dim Linea As DataRow
    Dim Tabla As DataTable


    Public Sub arbol_categoria(ByVal nivel As Integer, ByVal Nodo As TreeNodeCollection)
        Dim i As Integer

        Dim rs = New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * from categoria where super ='" & nivel & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        i = 0
        While Not rs.EOF
            Nodo.Add(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value)
            Nodo(i).Tag = rs.Fields("id_categoria").Value
            arbol_categoria(rs.Fields("id_categoria").Value, Nodo(i).Nodes)
            rs.MoveNext()
            i = i + 1
        End While
        rs.Close()
        ''conn.close()
        ''conn = Nothing
    End Sub

    Public Sub Producto(ByVal consulta As String, ByVal nombreTabla As String, ByVal grid As DataGrid)
        grid.CaptionText = nombreTabla

        Dim conectar As ADODB.Recordset
        Dim coneccion As ADODB.Connection
        conectar = conector()
        coneccion = Conexion()

        conectar.Open(consulta, coneccion, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        ds = New DataSet
        Tabla = New DataTable(nombreTabla)

        Tabla.Columns.Add(New DataColumn("1", GetType(String)))
        Tabla.Columns.Add(New DataColumn("2", GetType(String)))
        Tabla.Columns.Add(New DataColumn("3", GetType(String)))
        Tabla.Columns.Add(New DataColumn("4", GetType(String)))

        While Not conectar.EOF
            Linea = Tabla.NewRow()
            Linea(0) = conectar.Fields("id_producto").Value
            Linea(1) = conectar.Fields("nombre").Value
            Linea(2) = conectar.Fields("id_unidad").Value
            Linea(3) = conectar.Fields("medida").Value
            Tabla.Rows.Add(Linea)
            conectar.MoveNext()
        End While

        ds.Tables.Add(Tabla)

        grid.TableStyles.Clear()
        grid.DataSource = Nothing
        grid.TableStyles.Add(Estilo_producto(nombreTabla))
        grid.SetDataBinding(ds, nombreTabla)
        grid.ReadOnly = True
        conectar.Close()
    End Sub

    Public Function Estilo_producto(ByVal tabla As String)
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
            .HeaderText = "Nombre"
            .TextBox.Multiline = True
            .Width = 150
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "3"
            .HeaderText = "Unidad"
            .Width = 100
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "4"
            .HeaderText = "Medida"
            .Width = 100
            .TextBox.Enabled = False
        End With
        Estilo.GridColumnStyles.Add(sColumna)
        Return Estilo
    End Function
End Module
