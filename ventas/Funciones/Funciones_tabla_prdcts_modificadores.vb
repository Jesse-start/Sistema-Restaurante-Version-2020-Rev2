Module Funciones_tabla_prdcts_modificadores
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_prdcts_modificadores As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Public Sub estilo_prdcts_modificadores(ByVal productos_modificadores As DataGridView)
        tabla_prdcts_modificadores = New DataTable("productos_modificadores")

        With tabla_prdcts_modificadores.Columns
            .Add(New DataColumn("id_modificador", GetType(Integer)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("descripcion", GetType(String)))


        End With

        ds = New DataSet
        ds.Tables.Add(tabla_prdcts_modificadores)

        With productos_modificadores
            .DataSource = ds
            .DataMember = "productos_modificadores"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .Columns("id_producto").Visible = False

            With .Columns("id_modificador")
                .HeaderText = "MODIF"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 50
                .ReadOnly = False
            End With

            With .Columns("descripcion")
                .HeaderText = "Producto"
                .Width = 250
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_producto_modificador(ByVal id_producto As Integer, ByVal cantidad As Decimal, ByVal descripcion As String, ByVal id_modificador As Integer)
        tabla_linea = tabla_prdcts_modificadores.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("cantidad") = cantidad
        tabla_linea("descripcion") = descripcion
        tabla_linea("id_modificador") = id_modificador
        tabla_prdcts_modificadores.Rows.Add(tabla_linea)
    End Sub
End Module
