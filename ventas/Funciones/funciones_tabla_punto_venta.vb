Module funciones_tabla_punto_venta
    Private ds As DataSet
    Private tabla_linea As DataRow
    Private linea_ As Integer
    Public tabla_punto_venta As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_punto_venta(ByVal punto_venta As DataGridView)
        tabla_punto_venta = New DataTable("punto_venta")

        With tabla_punto_venta.Columns
            .Add(New DataColumn("no", GetType(Integer)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("impuesto", GetType(Decimal)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))

            'Ocultos
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("id_almacen", GetType(Integer)))
            .Add(New DataColumn("id_impuesto", GetType(String)))
            .Add(New DataColumn("descuento", GetType(Decimal)))
            .Add(New DataColumn("importe_descuento", GetType(Decimal)))
            .Add(New DataColumn("id_temp_venta", GetType(Integer)))
            .Add(New DataColumn("observaciones", GetType(String)))
            .Add(New DataColumn("modificador", GetType(Integer)))
            .Add(New DataColumn("id_producto_modificador", GetType(Integer)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_punto_venta)

        With punto_venta
            .DataSource = ds
            .DataMember = "punto_venta"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_producto").Visible = False
            .Columns("id_almacen").Visible = False
            .Columns("id_impuesto").Visible = False
            .Columns("descuento").Visible = False
            .Columns("importe_descuento").Visible = False
            .Columns("id_temp_venta").Visible = False
            .Columns("observaciones").Visible = False
            .Columns("modificador").Visible = False
            .Columns("id_producto_modificador").Visible = False


            With .Columns("no")
                .HeaderText = "No"
                .Width = 45
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 80
                .ReadOnly = False
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 220
                .ReadOnly = True
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unitario"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With
    End Sub
    Public Sub agregar_producto_punto_venta(id_producto As Integer, descripcion As String, cantidad As Decimal, unidad As String, precio As Decimal, importe As Decimal, id_almacen As Integer, descuento As Decimal, importe_descuento As Decimal, id_temp_venta As Integer, observaciones As String, modificador As Integer, id_producto_modificador As Integer)
        linea_ = linea_ + 1
        tabla_linea = tabla_punto_venta.NewRow()
        '=============V I S I B L E S====================
        tabla_linea("no") = linea_
        tabla_linea("id_producto") = id_producto
        tabla_linea("descripcion") = descripcion
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("precio") = precio
        tabla_linea("importe") = importe
        '============ O C U L T O S =====================
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("descuento") = descuento
        tabla_linea("importe_descuento") = importe_descuento
        tabla_linea("id_temp_venta") = id_temp_venta
        tabla_linea("observaciones") = observaciones
        tabla_linea("modificador") = modificador
        tabla_linea("id_producto_modificador") = id_producto_modificador
        tabla_punto_venta.Rows.Add(tabla_linea)
    End Sub
End Module
