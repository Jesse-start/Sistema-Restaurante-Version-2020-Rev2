Module funciones_tabla_paquete_seleccion
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_paquete_seleccion As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_tabla_paquete_seleccion(ByVal paquete_seleccion As DataGridView)
        tabla_paquete_seleccion = New DataTable("paquete_seleccion")

        With tabla_paquete_seleccion.Columns
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("miniatura", GetType(System.Drawing.Image)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("id_almacen", GetType(String)))
            .Add(New DataColumn("id_modificador", GetType(Integer)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_paquete_seleccion)

        With paquete_seleccion
            .DataSource = ds
            .DataMember = "paquete_seleccion"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_producto")
                .HeaderText = "ID"
                .Width = 40
                .ReadOnly = True
            End With
            With .Columns("miniatura")
                .HeaderText = ""
                .Width = 30
                .ReadOnly = True
            End With
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 180
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("id_almacen")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("id_modificador")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
        End With
    End Sub
    Public Sub agregar_paquete_selecion(ByVal id_producto As Integer, ByVal miniatura As Object, ByVal nombre As String, ByVal unidad As String, ByVal cantidad As Decimal, ByVal id_modificador As Integer, ByVal id_almacen As Integer)

        tabla_linea = tabla_paquete_seleccion.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("miniatura") = miniatura
        tabla_linea("nombre") = nombre
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("id_modificador") = id_modificador
        tabla_linea("id_almacen") = id_almacen
        tabla_paquete_seleccion.Rows.Add(tabla_linea)

    End Sub
End Module
