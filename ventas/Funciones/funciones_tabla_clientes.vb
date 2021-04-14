Module funciones_tabla_clientes
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_clientes As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_clientes(ByVal ventas As DataGridView)
        tabla_clientes = New DataTable("clientes")

        With tabla_clientes.Columns
            .Add(New DataColumn("id_cliente", GetType(Integer)))
            .Add(New DataColumn("clave", GetType(String)))
            .Add(New DataColumn("cliente", GetType(String)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_clientes)

        With ventas
            .DataSource = ds
            .DataMember = "clientes"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            With .Columns("id_cliente")
                .Width = 0
                .ReadOnly = True
            End With
            With .Columns("clave")
                .HeaderText = "Clave"
                .Width = 45
                .ReadOnly = True
            End With
            With .Columns("cliente")
                .HeaderText = "Cliente"
                .Width = 500
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_cliente(ByVal id_cliente As Integer, ByVal clave As String, ByVal nombre As String)

        tabla_linea = tabla_clientes.NewRow()
        tabla_linea("id_cliente") = id_cliente
        tabla_linea("clave") = clave
        tabla_linea("cliente") = nombre
        tabla_clientes.Rows.Add(tabla_linea)

    End Sub
    Public Sub obtener_clientes(ByVal filtro As String)
        tabla_clientes.Clear()
        If filtro = "" Then
            For x = 0 To 500
                If Not IsNothing(clientes(x, 0)) Then
                    agregar_cliente(clientes(x, 0), clientes(x, 1), clientes(x, 2))
                Else
                    Exit For
                End If
            Next
            '-obtenemos todos los clientes
            ''Conectar()
            ' rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  CONCAT(empresa.alias,' [',empresa.razon_social,']') ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente<>1 ORDER by cliente.id_cliente", conn)
            'rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente<>1 ORDER by cliente.id_cliente", conn)
            'If rs.RecordCount > 0 Then
            'While Not rs.EOF
            'agregar_cliente(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value)
            'rs.MoveNext()
            'End While
            'End If
            'rs.Close()
            ''conn.close()
            ''conn = Nothing
        Else

            '-obtenemos los clientes 
            For x = 0 To 500
                If Not IsNothing(clientes(x, 0)) Then
                    Dim nombre As String = "-" & clientes(x, 1).ToString & clientes(x, 2).ToString
                    If InStr(nombre, filtro, CompareMethod.Text) <> 0 Then
                        agregar_cliente(clientes(x, 0), clientes(x, 1), clientes(x, 2))
                    End If
                Else
                    Exit For
                End If

            Next
            '-obtenemos todos los clientes
            ''Conectar()
            'rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente<>1 AND empresa.alias like '%" & filtro & "%' or empresa.razon_social like '%" & filtro & "%' or persona.nombre like '%" & filtro & "%' or persona.ap_paterno like '%" & filtro & "%' or persona.ap_materno like '%" & filtro & "%'  or persona.alias like '%" & filtro & "%' or cliente.id_cliente LIKE '%" & filtro & "%' ORDER by cliente.id_cliente", conn)
            'If rs.RecordCount > 0 Then
            'While Not rs.EOF
            'agregar_cliente(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value)
            'rs.MoveNext()
            'End While
            'End If
            'rs.Close()
            ''conn.close()
            ''conn = Nothing

        End If
    End Sub

End Module
