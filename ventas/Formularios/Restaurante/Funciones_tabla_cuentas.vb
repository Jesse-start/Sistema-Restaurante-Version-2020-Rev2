Module Funciones_tabla_cuentas
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_cuentas As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_cuentas(ByVal cuentas As DataGridView)
        tabla_cuentas = New DataTable("cuentas")

        With tabla_cuentas.Columns


            .Add(New DataColumn("cuenta", GetType(String)))
            .Add(New DataColumn("mesero", GetType(String)))
            .Add(New DataColumn("id_orden", GetType(Integer)))
           

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_cuentas)

        With cuentas
            .DataSource = ds
            .DataMember = "cuentas"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .RowTemplate.MinimumHeight = 30

            With .Columns("cuenta")
                .HeaderText = "Cuenta"
                .Width = 100
                .ReadOnly = True
                .Visible = True
            End With
            With .Columns("mesero")
                .HeaderText = "Mesero"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("id_orden")
                .HeaderText = "Orden"
                .Width = 50
                .ReadOnly = True
            End With

        End With
    End Sub
    Public Sub agregar_tabla_cuentas(ByVal cuenta As String, ByVal mesero As String, ByVal id_orden As Integer)
        tabla_linea = tabla_cuentas.NewRow()
        tabla_linea("cuenta") = cuenta
        tabla_linea("mesero") = mesero
        tabla_linea("id_orden") = id_orden
        tabla_cuentas.Rows.Add(tabla_linea)
    End Sub
End Module