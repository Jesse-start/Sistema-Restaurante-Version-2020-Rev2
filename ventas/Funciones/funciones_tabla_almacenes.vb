Module funciones_tabla_almacenes
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_almacenes As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_almacenes(ByVal ventas As DataGridView)
        tabla_almacenes = New DataTable("almacenes")

        With tabla_almacenes.Columns
            .Add(New DataColumn("id_almacen", GetType(Integer)))
            .Add(New DataColumn("almacen", GetType(String)))
            .Add(New DataColumn("domicilio", GetType(String)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_almacenes)

        With ventas
            .DataSource = ds
            .DataMember = "almacenes"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_almacen")
                .HeaderText = "ID"
                .Width = 45
                .ReadOnly = True
            End With
            With .Columns("almacen")
                .HeaderText = "Descripción"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("domicilio")
                .HeaderText = "Domicilio"
                .Width = 300
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_almacen(ByVal id_almacen As Integer, ByVal nombre As String, ByVal domicilio As String)

        tabla_linea = tabla_almacenes.NewRow()
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("almacen") = nombre
        tabla_linea("domicilio") = domicilio
        tabla_almacenes.Rows.Add(tabla_linea)

    End Sub
    Public Sub obtener_almacenes(ByVal filtro As String)
        tabla_almacenes.Clear()
        If filtro = "" Then
            '-obtenemos todos los almacenes
            'Conectar()
            rs.Open("SELECT id_almacen,nombre,domicilio,default_ventas FROM almacenes ORDER by id_almacen", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_almacen(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value, rs.Fields("domicilio").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
        Else
            '-obtenemos lo almacenes de la busqueda
            'Conectar()
            rs.Open("SELECT id_almacen,nombte,domicilio FROM almacenes WHERE nombre like '%" & filtro & "%' ORDER by ID_Almacen", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_almacen(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value, rs.Fields("domicilio").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing

        End If
    End Sub
End Module
