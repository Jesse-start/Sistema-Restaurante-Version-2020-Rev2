Module funciones_tabla_descuentos
    Private ds As DataSet
    Private tabla_linea As DataRow
    Public tabla_descuentos As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Dim linea As Integer
    Public Sub estilo_descuentos(ByVal descuentos As DataGridView)
        tabla_descuentos = New DataTable("descuentos")

        With tabla_descuentos.Columns
            .Add(New DataColumn("id_temp_venta_detalle", GetType(Integer)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("descuento", GetType(Decimal)))
            .Add(New DataColumn("importe_descuento", GetType(Decimal)))
            'Ocultos


        End With

        ds = New DataSet
        ds.Tables.Add(tabla_descuentos)

        With descuentos
            .DataSource = ds
            .DataMember = "descuentos"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .Columns("id_producto").Visible = False
            .Columns("id_temp_venta_detalle").Visible = False
            
            With .Columns("imagen")
                .HeaderText = "Imagen"
                .Width = 60
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
            With .Columns("descuento")
                .HeaderText = "% Descuento"
                .Width = 90
                .ReadOnly = False
            End With
            With .Columns("importe_descuento")
                .HeaderText = "Importe con descuento"
                .Width = 90
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With
    End Sub
    Public Sub agregar_tabla_descuento(ByVal id_temp_venta_detalle As Integer, ByVal id_producto As Integer, ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal precio As Decimal, ByVal imagen As Object, ByVal descuento As Decimal, ByVal importe As Decimal, ByVal importe_descuento As Decimal)
        linea = linea + 1
        tabla_linea = tabla_descuentos.NewRow()
        tabla_linea("id_temp_venta_detalle") = id_temp_venta_detalle
        tabla_linea("id_producto") = id_producto
        tabla_linea("imagen") = imagen
        tabla_linea("descripcion") = descripcion
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("precio") = precio
        Dim _importe As Decimal = precio * cantidad
        If global_current_aplicar_redondeo Then
            tabla_linea("importe") = redondear(FormatNumber(_importe, 2))
        Else
            tabla_linea("importe") = FormatNumber(_importe, 2)
        End If

        tabla_linea("descuento") = descuento
        Dim _importe_descuento As Decimal = tabla_linea("importe") * (descuento / 100)
        Dim importe_con_desc As Decimal = tabla_linea("importe") - _importe_descuento
        If global_current_aplicar_redondeo Then
            tabla_linea("importe_descuento") = redondear(FormatNumber(importe_con_desc, 2))
        Else
            tabla_linea("importe_descuento") = FormatNumber(importe_con_desc, 2)
        End If
        tabla_descuentos.Rows.Add(tabla_linea)
    End Sub
End Module
