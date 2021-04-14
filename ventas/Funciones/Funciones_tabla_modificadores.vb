Module Funciones_tabla_modificadores
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_modificadores As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Public Sub estilo_modificadores(ByVal modificador As DataGridView)
        tabla_modificadores = New DataTable("modificadores")

        With tabla_modificadores.Columns
            .Add(New DataColumn("id_modificador", GetType(Integer)))
            .Add(New DataColumn("descripcion", GetType(String)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_modificadores)

        With modificador
            .DataSource = ds
            .DataMember = "modificadores"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            With .Columns("id_modificador")
                .HeaderText = "MODIF"
                .Width = 50
                .ReadOnly = True
            End With

            With .Columns("descripcion")
                .HeaderText = "Nombre"
                .Width = 250
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_modificador(ByVal id_modificador As Integer, ByVal descripcion As String)
        tabla_linea = tabla_modificadores.NewRow()
        tabla_linea("id_modificador") = id_modificador
        tabla_linea("descripcion") = descripcion
        tabla_modificadores.Rows.Add(tabla_linea)
    End Sub
End Module
