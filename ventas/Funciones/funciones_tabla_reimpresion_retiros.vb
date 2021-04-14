Module funciones_tabla_reimpresion_retiros
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea As Integer
    Public tabla_reimpresion_retiros As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_reimpresion_retiro(ByVal reimpresion_retiros As DataGridView)
        tabla_reimpresion_retiros = New DataTable("reimpresion_retiros")

        With tabla_reimpresion_retiros.Columns
            .Add(New DataColumn("id_retiro", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("colaborador", GetType(String)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("descripcion", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_reimpresion_retiros)

        With reimpresion_retiros
            .DataSource = ds
            .DataMember = "reimpresion_retiros"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_retiro").Visible = False
            .Columns("id_retiro").Width = 0

            With .Columns("fecha")
                .HeaderText = "Fecha"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("colaborador")
                .HeaderText = "Colaborador"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 90
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_reimpresion_retiro(ByVal id_retiro As Integer, ByVal fecha As String, ByVal colaborador As String, ByVal importe As Decimal, ByVal descripcion As String)
        linea = linea + 1
        tabla_linea = tabla_reimpresion_retiros.NewRow()
        tabla_linea("id_retiro") = id_retiro
        tabla_linea("fecha") = fecha
        tabla_linea("colaborador") = colaborador
        tabla_linea("importe") = importe
        tabla_linea("descripcion") = descripcion
        tabla_reimpresion_retiros.Rows.Add(tabla_linea)

    End Sub
 
End Module
