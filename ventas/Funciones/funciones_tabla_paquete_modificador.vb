Module funciones_tabla_paquete_modificador
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_paquete_modificador As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_tabla_paquete_modificador(ByVal paquete_modificador As DataGridView)
        tabla_paquete_modificador = New DataTable("paquete_modificador")

        With tabla_paquete_modificador.Columns
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("miniatura", GetType(System.Drawing.Image)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("id_almacen", GetType(String)))
            .Add(New DataColumn("codigo", GetType(String)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_paquete_modificador)

        With paquete_modificador
            .DataSource = ds
            .DataMember = "paquete_modificador"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_producto")
                .HeaderText = "ID"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("miniatura")
                .HeaderText = ""
                .Width = 30
                .ReadOnly = True
            End With
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("id_almacen")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("codigo")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
        End With
    End Sub
    Public Sub agregar_producto_paquete(ByVal id_producto As Integer, ByVal miniatura As Object, ByVal nombre As String, ByVal unidad As String, ByVal cantidad As Decimal, ByVal id_almacen As Integer, ByVal codigo As String)

        tabla_linea = tabla_paquete_modificador.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("miniatura") = miniatura
        tabla_linea("nombre") = nombre
        tabla_linea("unidad") = unidad
        tabla_linea("cantidad") = cantidad
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("codigo") = codigo
        tabla_paquete_modificador.Rows.Add(tabla_linea)

    End Sub
End Module
