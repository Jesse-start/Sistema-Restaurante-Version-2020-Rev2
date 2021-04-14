Module Funciones_tabla_abonos_cancelaciones
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_abono_cancelaciones As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Public Sub estilo_tabla_abono_cancelaciones(ByVal dgv_abono As DataGridView)
        tabla_abono_cancelaciones = New DataTable("abono")

        With tabla_abono_cancelaciones.Columns

            .Add(New DataColumn("id_pago_ventas", GetType(Integer)))
            .Add(New DataColumn("fecha", GetType(String)))
            .Add(New DataColumn("fecha_cobro", GetType(String)))
            .Add(New DataColumn("forma_pago", GetType(String)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("cajero", GetType(String)))
            .Add(New DataColumn("status", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla_abono_cancelaciones)

        With dgv_abono
            .DataSource = ds
            .DataMember = "abono"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False


            With .Columns("id_pago_ventas")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("fecha")
                .HeaderText = "Fecha"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("fecha_cobro")
                .HeaderText = "Fecha_cobro"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("forma_pago")
                .HeaderText = "Forma de pago"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .Width = 70
                .ReadOnly = True
            End With
            With .Columns("cajero")
                .HeaderText = "Cajero(a)"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("status")
                .HeaderText = "Estatus"
                .Width = 80
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_tabla_abono_cancelaciones(ByVal id_pago_ventas As Integer, ByVal fecha As String, ByVal fecha_cobro As String, ByVal forma_pago As String, ByVal importe As Decimal, ByVal cajero As String, ByVal status As String)
        tabla_linea = tabla_abono_cancelaciones.NewRow()
        tabla_linea("id_pago_ventas") = id_pago_ventas
        tabla_linea("fecha") = fecha
        tabla_linea("fecha_cobro") = fecha_cobro
        tabla_linea("forma_pago") = forma_pago
        tabla_linea("importe") = importe
        tabla_linea("cajero") = cajero
        tabla_linea("status") = status
        tabla_abono_cancelaciones.Rows.Add(tabla_linea)
    End Sub
End Module
