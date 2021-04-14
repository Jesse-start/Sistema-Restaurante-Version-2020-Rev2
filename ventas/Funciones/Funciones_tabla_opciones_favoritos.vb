Module funciones_tabla_opciones_favoritos
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_opciones_favoritos As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_opciones_favoritos(ByVal opciones_favoritos As DataGridView)
        tabla_opciones_favoritos = New DataTable("opciones_favoritos")

        With tabla_opciones_favoritos.Columns
            .Add(New DataColumn("no", GetType(Integer)))
            .Add(New DataColumn("id_opcion", GetType(Integer)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("opcion", GetType(String)))
            .Add(New DataColumn("extra", GetType(String)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_opciones_favoritos)

        With opciones_favoritos
            .DataSource = ds
            .DataMember = "opciones_favoritos"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            With .Columns("no")
                .HeaderText = "No"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("id_opcion")
                .Width = 0
                .ReadOnly = True
            End With
            With .Columns("imagen")
                .HeaderText = "imagen"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("opcion")
                .HeaderText = "Opcion"
                .Width = 250
                .ReadOnly = True
            End With
            With .Columns("extra")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
        End With
    End Sub
    Public Sub agregar_opciones_favoritos(ByVal no As Integer, ByVal id_opcion As Integer, ByVal opcion As String, ByVal imagen As System.Drawing.Image, ByVal extra As String)

        tabla_linea = tabla_opciones_favoritos.NewRow()
        tabla_linea("no") = no
        tabla_linea("id_opcion") = id_opcion
        tabla_linea("imagen") = imagen
        tabla_linea("opcion") = opcion
        tabla_linea("extra") = extra
        tabla_opciones_favoritos.Rows.Add(tabla_linea)
    End Sub
End Module
