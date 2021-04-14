Module funciones_tabla_inventario
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_inventario As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    ',matrix sucursal

    '----/     0     / 1   /    2   /         3      /       4         /   5     /
    '---/id_sucursal/alias/servidor/servidor_usuario/servidor_password/domicilio/
    Public sucursal(15, 5) As String

    Public Sub estilo_inventario(ByVal inventario As DataGridView)
        tabla_inventario = New DataTable("inventario")

        With tabla_inventario.Columns
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))

            'Ocultos
            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("cant_min", GetType(Decimal)))
            .Add(New DataColumn("cant_max", GetType(Decimal)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_inventario)

        With inventario
            .DataSource = ds
            .DataMember = "inventario"

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
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 400
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 50
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("codigo")
                .HeaderText = "Codigo"
                .Width = 100
                .Visible = True
            End With
            With .Columns("cant_max")
                .HeaderText = "Cant. Max."
                .Width = 100
                .Visible = True
            End With
            With .Columns("cant_min")
                .HeaderText = "Cant. Min."
                .Width = 100
                .Visible = True
            End With
        End With
    End Sub
    Public Sub agregar_inventario(ByVal id_producto As Integer, ByVal cantidad As Decimal, ByVal nombre As String, ByVal descripcion As String, ByVal unidad As String, ByVal codigo As String, ByVal cant_max As Decimal, ByVal cant_min As Decimal)
        tabla_linea = tabla_inventario.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("cantidad") = cantidad
        tabla_linea("nombre") = nombre
        tabla_linea("descripcion") = descripcion
        tabla_linea("unidad") = unidad
        tabla_linea("codigo") = codigo
        tabla_linea("cant_max") = cant_max
        tabla_linea("cant_min") = cant_min
        tabla_inventario.Rows.Add(tabla_linea)
    End Sub

End Module
