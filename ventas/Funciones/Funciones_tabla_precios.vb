Module Funciones_tabla_precios
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_precios As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Public Sub estilo_tabla_precios(ByVal precios As DataGridView)
        tabla_precios = New DataTable("producto_precios")

        With tabla_precios.Columns
            .Add(New DataColumn("id_producto_precio", GetType(Integer)))
            .Add(New DataColumn("id_ctlg_precios", GetType(Integer)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("utilidad", GetType(Decimal)))
            .Add(New DataColumn("precio", GetType(Decimal)))


        End With

        ds = New DataSet
        ds.Tables.Add(tabla_precios)

        With precios
            .DataSource = ds
            .DataMember = "producto_precios"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .Columns("id_producto_precio").Visible = False
            .Columns("id_ctlg_precios").Visible = False

            With .Columns("id_producto_precio")
                .Width = 0
            End With
            With .Columns("id_ctlg_precios")
                .Width = 0
            End With

            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("utilidad")
                .HeaderText = "Utilidad (%)"
                .Width = 80
                .ReadOnly = False
            End With

            With .Columns("precio")
                .HeaderText = "Precio"
                .Width = 80
                .ReadOnly = False
            End With

        End With
    End Sub
    Public Sub agregar_tabla_producto_precio(ByVal id_producto_precio As Integer, ByVal id_ctlg_precios As Integer, ByVal nombre As String, ByVal utilidad As Decimal, ByVal precio As Decimal)
        tabla_linea = tabla_precios.NewRow()
        tabla_linea("id_producto_precio") = id_producto_precio
        tabla_linea("id_ctlg_precios") = id_ctlg_precios
        tabla_linea("nombre") = nombre
        tabla_linea("utilidad") = utilidad
        tabla_linea("precio") = precio
        tabla_precios.Rows.Add(tabla_linea)
    End Sub
End Module
