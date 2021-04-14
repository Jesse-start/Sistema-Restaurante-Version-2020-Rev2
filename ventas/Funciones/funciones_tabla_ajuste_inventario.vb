Module funciones_tabla_ajuste_inventario
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_ajuste_inventario As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    ',matrix sucursal

    '----/     0     / 1   /    2   /         3      /       4         /   5     /
    '---/id_sucursal/alias/servidor/servidor_usuario/servidor_password/domicilio/


    Public Sub estilo_ajuste_inventario(ByVal inventario As DataGridView)
        tabla_ajuste_inventario = New DataTable("ajuste")

        With tabla_ajuste_inventario.Columns

            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("cant_min", GetType(Decimal)))
            .Add(New DataColumn("cant_max", GetType(Decimal)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("cantidad_fisica", GetType(Decimal)))
            .Add(New DataColumn("diferencia", GetType(String)))
            .Add(New DataColumn("merma", GetType(Decimal)))
            .Add(New DataColumn("merma_aplicada", GetType(Integer)))
            .Add(New DataColumn("flag_merma", GetType(Integer)))

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_ajuste_inventario)

        With inventario
            .DataSource = ds
            .DataMember = "ajuste"

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
                .Width = 250
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = ""
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
                .Width = 80
                .Visible = True
            End With
            With .Columns("cant_min")
                .HeaderText = "Cant. Min."
                .Width = 80
                .Visible = True
            End With
            With .Columns("cantidad_fisica")
                .HeaderText = "Cant. Real."
                .Width = 100
                .Visible = True
            End With
            With .Columns("diferencia")
                .HeaderText = "Diferencia."
                .Width = 100
                .Visible = True
            End With
            With .Columns("merma")
                .HeaderText = "merma"
                .Width = 70
                .Visible = True
                .ReadOnly = True
            End With
            With .Columns("merma_aplicada")
                .HeaderText = "merma_aplicada"
                .Width = 0
                .Visible = False
            End With
            With .Columns("flag_merma")
                .HeaderText = "flag_merma"
                .Width = 0
                .Visible = False
            End With
        End With
    End Sub
    Public Sub agregar_ajuste_inventario(ByVal id_producto As Integer, ByVal cantidad As Decimal, ByVal nombre As String, ByVal descripcion As String, ByVal unidad As String, ByVal codigo As String, ByVal cant_max As Decimal, ByVal cant_min As Decimal, ByVal merma As Decimal, ByVal connection As ADODB.Connection)
        tabla_linea = tabla_ajuste_inventario.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("cantidad") = cantidad
        tabla_linea("cantidad_fisica") = cantidad
        tabla_linea("diferencia") = 0
        tabla_linea("nombre") = nombre
        tabla_linea("descripcion") = descripcion
        tabla_linea("unidad") = unidad
        tabla_linea("codigo") = codigo
        tabla_linea("cant_max") = cant_max
        tabla_linea("cant_min") = cant_min
        tabla_linea("merma") = merma
        Dim _merma As Integer = verificar_merma_aplicada(id_producto, connection)
        tabla_linea("merma_aplicada") = _merma
        tabla_linea("flag_merma") = _merma
        tabla_ajuste_inventario.Rows.Add(tabla_linea)
    End Sub
    Public Function verificar_merma_aplicada(ByVal id_producto As Integer, ByVal connection As ADODB.Connection) As Integer
        Dim aplicada As Integer = 0
        Dim rs_2 As New ADODB.Recordset
        rs_2.Open("SELECT merma from ajuste_inventario WHERE id_producto=" & id_producto & " AND date(fecha)='" & Format(Today, "yyyy-MM-dd") & "'", connection)
        If rs_2.RecordCount > 0 Then
            aplicada = rs_2.Fields("merma").Value
        End If
        rs_2.Close()
        Return aplicada
    End Function
End Module
