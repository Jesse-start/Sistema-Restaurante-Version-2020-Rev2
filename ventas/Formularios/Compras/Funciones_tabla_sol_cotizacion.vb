Module Funciones_tabla_sol_cotizacion
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_solicitud_cotizacion As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_solicitud_cotizacion(ByVal solicitud_cotizacion As DataGridView)
        tabla_solicitud_cotizacion = New DataTable("solicitud_cotizacion")

        With tabla_solicitud_cotizacion.Columns

            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("precio_proveedor1", GetType(Decimal)))
            .Add(New DataColumn("asignado_proveedor1", GetType(Boolean)))
            .Add(New DataColumn("precio_proveedor2", GetType(Decimal)))
            .Add(New DataColumn("asignado_proveedor2", GetType(Boolean)))
            .Add(New DataColumn("precio_proveedor3", GetType(Decimal)))
            .Add(New DataColumn("asignado_proveedor3", GetType(Boolean)))
            .Add(New DataColumn("importe", GetType(Decimal)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_solicitud_cotizacion)

        With solicitud_cotizacion
            .DataSource = ds
            .DataMember = "solicitud_cotizacion"

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
                .HeaderText = "Producto"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("precio_proveedor1")
                .HeaderText = "Precio P1"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("asignado_proveedor1")
                .HeaderText = "Asignar P1"
                .Width = 40
                .ReadOnly = True
            End With
            With .Columns("precio_proveedor2")
                .HeaderText = "Precio P2"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("asignado_proveedor2")
                .HeaderText = "Asignar P2"
                .Width = 40
                .ReadOnly = True
            End With
            With .Columns("precio_proveedor3")
                .HeaderText = "Precio P3"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("asignado_proveedor3")
                .HeaderText = "Asignar P3"
                .Width = 40
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .Width = 80
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_tabla_solicitud_cotizacion(ByVal id_producto As Integer, ByVal nombre As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal precio_proveedor1 As Decimal, ByVal asignar_proveedor1 As Boolean, ByVal precio_proveedor2 As Decimal, ByVal asignar_proveedor2 As String, ByVal precio_proveedor3 As Decimal, ByVal asignar_proveedor3 As Boolean, ByVal importe As Decimal)
        tabla_linea = tabla_solicitud_cotizacion.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("nombre") = nombre
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("precio_proveedor1") = precio_proveedor1
        tabla_linea("asignado_proveedor1") = asignar_proveedor1
        tabla_linea("precio_proveedor2") = precio_proveedor2
        tabla_linea("asignado_proveedor2") = asignar_proveedor2
        tabla_linea("precio_proveedor3") = precio_proveedor3
        tabla_linea("asignado_proveedor3") = asignar_proveedor3
        tabla_linea("importe") = importe

        tabla_solicitud_cotizacion.Rows.Add(tabla_linea)
    End Sub
End Module