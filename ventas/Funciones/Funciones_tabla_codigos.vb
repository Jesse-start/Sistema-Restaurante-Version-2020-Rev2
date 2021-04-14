Module Funciones_tabla_codigos
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_codigos As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Public Sub estilo_tabla_codigos(ByVal dgv_codigos As DataGridView)
        tabla_codigos = New DataTable("codigos")

        With tabla_codigos.Columns

            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("nombre", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_codigos)

        With dgv_codigos
            .DataSource = ds
            .DataMember = "codigos"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_producto")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("codigo")
                .HeaderText = "Codigo"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 250
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_tabla_codigos(ByVal id_producto As Integer, ByVal codigo As String, ByVal nombre As String)
        tabla_linea = tabla_codigos.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("codigo") = codigo
        tabla_linea("nombre") = nombre
        tabla_codigos.Rows.Add(tabla_linea)
    End Sub
End Module
