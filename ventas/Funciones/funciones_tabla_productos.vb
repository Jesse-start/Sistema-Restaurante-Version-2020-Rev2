Module funciones_tabla_productos
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_productos As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_productos(ByVal productos As DataGridView)
        tabla_productos = New DataTable("productos")

        With tabla_productos.Columns
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("precio_unitario", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_productos)

        With productos
            .DataSource = ds
            .DataMember = "productos"

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
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 450
                .ReadOnly = True
            End With
            With .Columns("codigo")
                .HeaderText = "codigo"
                .Width = 150
                .ReadOnly = True
            End With
            With .Columns("precio_unitario")
                .HeaderText = "Precio Unitario"
                .Width = 80
                .ReadOnly = True
                .Visible = True
            End With

            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_producto_busqueda(ByVal id_producto As Integer, ByVal codigo As String, ByVal nombre As String, ByVal precio_unitario As Decimal, ByVal unidad As String)

        tabla_linea = tabla_productos.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("nombre") = nombre
        tabla_linea("codigo") = codigo
        tabla_linea("precio_unitario") = FormatCurrency(precio_unitario)
        tabla_linea("unidad") = unidad
        tabla_productos.Rows.Add(tabla_linea)

    End Sub
End Module
