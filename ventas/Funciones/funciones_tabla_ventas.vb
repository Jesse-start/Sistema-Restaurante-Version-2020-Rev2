Module funciones_tabla_ventas
    Private ds As DataSet
    Private tabla_linea As DataRow
    Public linea_ As Integer
    Public tabla_ventas As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_ventas(ByVal ventas As DataGridView)
        tabla_ventas = New DataTable("ventas")

        Dim miEstilo As New DataGridViewCellStyle()
        miEstilo.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        ventas.ColumnHeadersDefaultCellStyle = miEstilo


        With tabla_ventas.Columns
            '  .Add(New DataColumn("no", GetType(Integer)))
            '   .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))

            'Ocultos
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("id_almacen", GetType(Integer)))
            .Add(New DataColumn("total_impuestos", GetType(Decimal)))
            .Add(New DataColumn("nombre_impuestos", GetType(String)))
            .Add(New DataColumn("tasa_impuestos", GetType(Decimal)))
            .Add(New DataColumn("id_temp_venta", GetType(Integer)))
            .Add(New DataColumn("modificador", GetType(Integer)))
            .Add(New DataColumn("id_producto_modificador", GetType(Integer)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_ventas)

        With ventas
            .DataSource = ds
            .DataMember = "ventas"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
           

            .Columns("id_producto").Visible = False
            .Columns("id_almacen").Visible = False
            .Columns("total_impuestos").Visible = False
            .Columns("nombre_impuestos").Visible = False
            .Columns("tasa_impuestos").Visible = False
            .Columns("id_temp_venta").Visible = False
            .Columns("modificador").Visible = False
            .Columns("id_producto_modificador").Visible = False

            With .Columns("cantidad")
                .HeaderText = "Cant."
                .Width = 50
                .ReadOnly = False
            End With
            With .Columns("unidad")
                .HeaderText = "Und."
                .Width = 40
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 250
                .ReadOnly = True
            End With
           
            With .Columns("precio")
                .HeaderText = "P.U."
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With
    End Sub
    Public Sub agregar_producto(ByVal id_producto As Integer, ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal total_impuestos As Decimal, ByVal precio As Decimal, ByVal importe As Decimal, ByVal id_almacen As Integer, ByVal nombre_impuestos As String, tasa_impuestos As Decimal, ByVal id_temp_venta_detalle As Integer, ByVal modificador As Integer, ByVal id_producto_modificador As Integer)
        linea_ = linea_ + 1
        tabla_linea = tabla_ventas.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("descripcion") = descripcion
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("total_impuestos") = total_impuestos
        tabla_linea("precio") = precio
        tabla_linea("importe") = importe
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("nombre_impuestos") = nombre_impuestos
        tabla_linea("tasa_impuestos") = tasa_impuestos
        tabla_linea("id_temp_venta") = id_temp_venta_detalle
        tabla_linea("modificador") = modificador
        tabla_linea("id_producto_modificador") = id_producto_modificador

        tabla_ventas.Rows.Add(tabla_linea)

        frm_principal3.actualizar_totales()
        frm_principal3.seleccionar_ultima_fila()

    End Sub
    Public Function redondear(ByVal importe As Decimal) As Decimal
        Dim total As Decimal = redondear_a_centavos(importe)
        Return total
    End Function
    Private Function redondear_a_peso(ByVal importe As Decimal) As Decimal
        Dim total As Decimal = importe
        Dim total_cadena As String = importe.ToString
        Dim s As String = importe.ToString
        Dim longitud As Integer = Len(importe.ToString)
        Dim enteros As String = Mid(total_cadena, 1, longitud - 3) 'parte entera
        Dim _enteros As Decimal = CInt(enteros)
        s = Right(s, 2) 'parte decimal
        Dim decimales As Integer = CInt(s)
        If decimales >= 1 Then
            total = _enteros + 1
        Else
            total = enteros
        End If
        Return total
    End Function
    Private Function redondear_a_centavos(ByVal importe As Decimal) As Decimal
        Dim total As Decimal = importe
        Dim total_cadena As String = importe.ToString
        Dim s As String = importe.ToString
        Dim longitud As Integer = Len(importe.ToString)
        Dim enteros As String = Mid(total_cadena, 1, longitud - 3) 'parte entera
        Dim _enteros As Decimal = CInt(enteros)
        s = Right(s, 2) 'parte decimal
        Dim decimales As Integer = CInt(s)

        If decimales <= 24 Then
            total = _enteros
        Else
            If decimales >= 75 Then
                total = _enteros + 1
            Else
                total = _enteros + 0.5
            End If
        End If
        Return total
    End Function

    Public Sub verifica_cambio_almacen()
        If global_default_idalmacen <> global_current_idalmacen Then
            If MsgBox("El almacen seleccionado no es su almacen por defecto. ¿ Desea regresar al almacen por defecto?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                global_current_idalmacen = global_default_idalmacen
            End If
        End If
    End Sub
End Module
