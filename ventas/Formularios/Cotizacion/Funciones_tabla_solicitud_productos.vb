Module Funciones_tabla_solicitud_productos
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_solicitud_productos As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_solicitud_producto(ByVal solicitud_productos As DataGridView)
        tabla_solicitud_productos = New DataTable("solicitud_productos")

        With tabla_solicitud_productos.Columns

            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("producto", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("cantidad_existente", GetType(Decimal)))
            .Add(New DataColumn("cantidad_solicitada", GetType(Decimal)))
            .Add(New DataColumn("cantidad_recibida", GetType(Decimal)))
            .Add(New DataColumn("cantidad_faltante", GetType(Decimal)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_solicitud_productos)

        With solicitud_productos
            .DataSource = ds
            .DataMember = "solicitud_productos"

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
            With .Columns("producto")
                .HeaderText = "Producto"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "unidad"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("cantidad_existente")
                .HeaderText = "Cant. Existente"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("cantidad_solicitada")
                .HeaderText = "Cant. Solicitada"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("cantidad_recibida")
                .HeaderText = "Cant. Recibida"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("cantidad_faltante")
                .HeaderText = "Cant. Faltante"
                .Width = 80
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_solicitud_productos(ByVal id_producto As Integer, ByVal producto As String, ByVal unidad As String, ByVal cantidad_existente As Decimal, ByVal cantidad_solicitada As Decimal, ByVal cantidad_recibida As Decimal, ByVal cantidad_faltante As Decimal)
        tabla_linea = tabla_solicitud_productos.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("producto") = producto
        tabla_linea("unidad") = unidad
        tabla_linea("cantidad_existente") = cantidad_existente
        tabla_linea("cantidad_existente") = cantidad_solicitada
        tabla_linea("cantidad_existente") = cantidad_recibida
        tabla_linea("cantidad_existente") = cantidad_faltante
        tabla_solicitud_productos.Rows.Add(tabla_linea)
    End Sub
End Module
