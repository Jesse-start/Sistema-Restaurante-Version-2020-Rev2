Public Class frm_cuentas_xpagar_anterior
    Dim id_proveedor As Integer = 0 'id del proveedor seleccionado
    Dim total_pagos As Integer = 0
    '========================varibales para la tabla cuentasxpagar
    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow
    Dim saldo_acumulado As Double
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Seleccion_pago.BackColor = Color.FromArgb(conf_colores(1))

        lbl_nombre.ForeColor = Color.FromArgb(conf_colores(13))

        btn_pagar.BackColor = Color.FromArgb(conf_colores(8))
        btn_pagar.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_cuentas_xpagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        crear_columnas_cuentasxpagar()
        llenar_proveedores()
    End Sub
    Private Sub adeudos2_proveedor()
        tabla.Clear()
        Dim fecha_factura As String
        If id_proveedor <> 0 Then
            'Conectar()
            rs.Open("SELECT id_factura_compra,DATE(fecha) As fecha,TIME(fecha) As hora,total,folio FROM factura_compra WHERE status='ACTIVO' AND id_proveedor =" & id_proveedor, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim fecha As Date = rs.Fields("fecha").Value
                    Dim hora As DateTime = rs.Fields("hora").Value
                    fecha_factura = fecha.ToLongDateString & vbCrLf & hora.ToLongTimeString
                    agregar_pagos_pendiente(rs.Fields("id_factura_compra").Value, rs.Fields("folio").Value, fecha_factura, rs.Fields("total").Value, rs.Fields("total").Value)
                    rs.MoveNext()
                End While
            End If

            rs.Close()
            'conn.close()
        Else
            'Conectar()
            rs.Open("SELECT FC.id_factura_compra,DATE(FC.fecha)As fecha,TIME(FC.fecha)As hora,FC.total,FC.folio FROM factura_compra FC, proveedor PV  WHERE FC.status='ACTIVO' AND PV.id_proveedor=FC.id_proveedor", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim fecha As Date = rs.Fields("fecha").Value
                    Dim hora As DateTime = rs.Fields("hora").Value
                    fecha_factura = fecha.ToLongDateString & vbCrLf & hora.ToLongTimeString
                    agregar_pagos_pendiente(rs.Fields("id_factura_compra").Value, rs.Fields("folio").Value, fecha_factura, rs.Fields("total").Value, rs.Fields("total").Value)
                    rs.MoveNext()
                End While
            End If

            rs.Close()
            'conn.close()

        End If

    End Sub
    Private Sub agregar_pagos_pendiente(ByVal id_factura_compra As Integer, ByVal folio As String, ByVal fecha_factura As String, ByVal total As String, ByVal monto As String)
        total_pagos = total_pagos + 1
        tabla_linea = tabla.NewRow()
        tabla_linea("F") = total_pagos
        tabla_linea("folio") = id_factura_compra
        Dim xd As New ADODB.Recordset
        Dim nombre_proveedor As String = ""
        xd.Open("SELECT CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE factura_compra.id_factura_compra=" & id_factura_compra, conn)
        If xd.RecordCount > 0 Then
            nombre_proveedor = xd.Fields("nombre").Value
        End If
        xd.Close()
        tabla_linea("proveedor") = nombre_proveedor
        tabla_linea("id_factura") = id_factura_compra
        tabla_linea("No_Factura") = folio
        tabla_linea("Fecha_factura") = fecha_factura
        ' tabla_linea("Fecha_vencimiento") = total_pagos
        tabla_linea("total") = total
        Suma_Saldo(id_factura_compra)
        tabla_linea("monto_pendiente") = total - saldo_acumulado
        tabla_linea("saldo_acumulado") = saldo_acumulado
        tabla.Rows.Add(tabla_linea)

    End Sub
    Private Sub Suma_Saldo(ByVal id_factura_compra As Integer)
        saldo_acumulado = 0
        Dim rs2 As New ADODB.Recordset
        rs2.Open("SELECT SUM(importe) as total FROM pagos_compras WHERE id_factura_compra='" & id_factura_compra & "' AND status='ACTIVO' ", conn)
        If Not IsDBNull(rs2.Fields("total").Value) Then
            saldo_acumulado = CDbl(rs2.Fields("total").Value)
        Else
            saldo_acumulado = 0
        End If
        rs2.Close()
    End Sub
    Private Sub crear_columnas_cuentasxpagar()
        tabla = New DataTable("pagos")
        With tabla.Columns
            .Add(New DataColumn("F", GetType(String)))
            .Add(New DataColumn("folio", GetType(Integer)))
            .Add(New DataColumn("Proveedor", GetType(String)))
            .Add(New DataColumn("No_Factura", GetType(String)))
            .Add(New DataColumn("Fecha_factura", GetType(String)))
            '.Add(New DataColumn("Fecha_Vencimiento", GetType(String)))
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("monto_pendiente", GetType(Decimal)))
            .Add(New DataColumn("saldo_acumulado", GetType(Decimal)))
            'Ocultos
            .Add(New DataColumn("id_factura", GetType(Decimal)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla)

        With dgv_pagos
            .DataSource = ds
            .DataMember = "pagos"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_factura").Visible = False
            With .Columns("F")
                .Width = 0
                .Visible = False
            End With

            With .Columns("folio")
                .HeaderText = "Folio"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("proveedor")
                .HeaderText = "Proveedor"
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("No_Factura")
                .HeaderText = "No de factura"
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("Fecha_Factura")
                .HeaderText = "Fecha de Factura"
                .Width = 150
                .ReadOnly = True
            End With
            '  With .Columns("Fecha_Vencimiento")
            '.HeaderText = "Fecha de Vencimiento"
            '  .Width = 130
            '  .ReadOnly = True
            ' End With
            With .Columns("total")
                .HeaderText = "Total"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("monto_pendiente")
                .HeaderText = "Saldo"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("saldo_acumulado")
                .HeaderText = "Total Pagos"
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub llenar_proveedores()
        cb_proveedor.Items.Clear()
        '===obtenemos la lista de proveedores
        With cb_proveedor
            .Items.Add(New myItem(0, "[Todos]"))
            'Conectar()
            rs.Open("SELECT DISTINCT(proveedor.id_proveedor), CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE factura_compra.status='ACTIVO' ORDER BY nombre", conn)
            If rs.RecordCount > 0 Then

                While Not rs.EOF
                    .Items.Add(New myItem(rs.Fields("id_proveedor").Value, rs.Fields("nombre").Value))
                    rs.MoveNext()
                End While
            End If

            rs.Close()
            'conn.close()
            cb_proveedor.SelectedIndex = 0
        End With
        '====================================

    End Sub

    Private Sub cb_proveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_proveedor.SelectedIndexChanged
        id_proveedor = CType(cb_proveedor.SelectedItem, MyItem).Value
        total_pagos = 0
        adeudos2_proveedor()
        btn_pagar.Enabled = False
    End Sub

    Private Sub dgv_pagos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_pagos.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_pagos.Columns.Count - 1
            If dgv_pagos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
                If x = 1 Or x = 6 Then
                    e.CellStyle.Font = New Font("Century Gothic", 11, FontStyle.Bold)
                End If
            End If
        Next
    End Sub

    Private Sub dgv_pagos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pagos.Click
        If total_pagos > 0 Then
            'MsgBox(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_factura").Value)
            btn_pagar.Enabled = True
        Else
            btn_pagar.Enabled = False
        End If

    End Sub
    Private Sub btn_pagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pagar.Click
        If verificar_permiso_pagos(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_factura").Value) Then
            frm_formas_pago.id_factura_compra = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_factura").Value
            frm_formas_pago.ShowDialog()
        Else
            MsgBox("No tiene permiso para realizar pagos a este proveedor")
        End If

    End Sub
    Private Function verificar_permiso_pagos(ByVal id_factura_compra As Integer) As Boolean
        Dim validacion As Boolean = False
        'Conectar()
        rs.Open("SELECT perfil_proveedor.id_proveedor FROM perfil_proveedor JOIN perfil_empleado ON perfil_empleado.id_perfil=perfil_proveedor.id_perfil JOIN perfil ON perfil.id_perfil=perfil_empleado.id_perfil JOIN factura_compra ON factura_compra.id_proveedor=perfil_proveedor.id_proveedor WHERE perfil_empleado.id_empleado=" & global_id_empleado & " AND perfil.pago_proveedores_terminal=1 AND factura_compra.id_factura_compra=" & id_factura_compra, conn)
        If rs.RecordCount > 0 Then
            validacion = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return validacion
    End Function
End Class