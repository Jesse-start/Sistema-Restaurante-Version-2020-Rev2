Public Class frm_reimpresion_ticket
    Dim ds As DataSet
    Dim tabla_reimpresion As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim total As Decimal = 0
    Dim total_iva As Decimal = 0
    Dim total_otros As Decimal = 0
    Dim subtotal As Decimal = 0
    Dim tipo_devolucion As Integer = 0
    Dim current_idventa As Integer = 0
    Dim msg_error As String = ""
    Dim btn_devolucion As Boolean = False
    Dim bandera_descuento As Boolean
    Dim cliente_alias As String = ""
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.Black
        Panel2.ForeColor = Color.FromArgb(conf_colores(13))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))

        btn_buscar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_reimprimir.BackColor = Color.FromArgb(conf_colores(8))
        btn_reimprimir.ForeColor = Color.FromArgb(conf_colores(9))

        btn0.BackColor = Color.FromArgb(conf_colores(8))
        btn0.ForeColor = Color.FromArgb(conf_colores(9))

        btn1.BackColor = Color.FromArgb(conf_colores(8))
        btn1.ForeColor = Color.FromArgb(conf_colores(9))

        btn2.BackColor = Color.FromArgb(conf_colores(8))
        btn2.ForeColor = Color.FromArgb(conf_colores(9))

        btn3.BackColor = Color.FromArgb(conf_colores(8))
        btn3.ForeColor = Color.FromArgb(conf_colores(9))

        btn4.BackColor = Color.FromArgb(conf_colores(8))
        btn4.ForeColor = Color.FromArgb(conf_colores(9))

        btn5.BackColor = Color.FromArgb(conf_colores(8))
        btn5.ForeColor = Color.FromArgb(conf_colores(9))

        btn6.BackColor = Color.FromArgb(conf_colores(8))
        btn6.ForeColor = Color.FromArgb(conf_colores(9))

        btn7.BackColor = Color.FromArgb(conf_colores(8))
        btn7.ForeColor = Color.FromArgb(conf_colores(9))

        btn8.BackColor = Color.FromArgb(conf_colores(8))
        btn8.ForeColor = Color.FromArgb(conf_colores(9))

        btn9.BackColor = Color.FromArgb(conf_colores(8))
        btn9.ForeColor = Color.FromArgb(conf_colores(9))

        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))

        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))

        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
        btn_punto.BackColor = Color.FromArgb(conf_colores(8))
        btn_punto.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub

    Private Sub frm_devoluciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        cargar_estilo_reimpresion()
        With lst_Pagos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Fecha de Registro", 0)
            .Columns.Add("Fecha de pago", 100)
            .Columns.Add("Forma de Pago", 100, HorizontalAlignment.Right)
            .Columns.Add("Importe", 80, HorizontalAlignment.Right)
            .Columns.Add("pago", 0, HorizontalAlignment.Right)
            .Columns.Add("cambio", 0, HorizontalAlignment.Right)
        End With
        conf_inicio()
    End Sub
    Private Sub agregar_producto_dev(ByVal id_producto As Integer, ByVal nombre As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal total_iva As Decimal, ByVal total_otros As Decimal, ByVal precio As Decimal, ByVal imagen As Object, ByVal id_almacen As Integer, ByVal impuestos As String, ByVal descuento As Decimal)
        tabla_linea = tabla_reimpresion.NewRow()
        tabla_linea("id_producto") = id_producto
        tabla_linea("imagen") = imagen
        tabla_linea("producto") = nombre
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("total_iva") = total_iva
        tabla_linea("total_otros") = total_otros
        tabla_linea("precio") = precio
        Dim importe As Decimal = precio * cantidad
        tabla_linea("importe") = redondear(FormatNumber(importe, 2))
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("nombre_impuestos") = impuestos
        tabla_linea("descuento") = descuento
        tabla_reimpresion.Rows.Add(tabla_linea)
    End Sub
    Private Sub cargar_estilo_reimpresion()
        tabla_reimpresion = New DataTable("reimpresion")
        With tabla_reimpresion.Columns
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("producto", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("id_almacen", GetType(Integer)))
            .Add(New DataColumn("total_iva", GetType(Decimal)))
            .Add(New DataColumn("total_otros", GetType(Decimal)))
            .Add(New DataColumn("nombre_impuestos", GetType(String)))
            .Add(New DataColumn("descuento", GetType(Decimal)))

        End With
        ds = New DataSet
        ds.Tables.Add(tabla_reimpresion)

        With dg_devoluciones
            .DataSource = ds
            .DataMember = "reimpresion"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_almacen").Visible = False
            .Columns("total_iva").Visible = False
            .Columns("total_otros").Visible = False
            .Columns("nombre_impuestos").Visible = False
            .Columns("descuento").Visible = False

            With .Columns("id_producto")
                '.HeaderText = "id_p"
                '.Width = 30
                '.ReadOnly = True
                .Visible = False
            End With
            With .Columns("imagen")
                .HeaderText = ""
                .Width = 30
                .ReadOnly = True
            End With
            With .Columns("producto")
                .HeaderText = "Producto"
                .Width = 150
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unit."
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Total"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
        End With
    End Sub

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        If TypeOf sender Is Button Then
            tb_folio.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub
    Private Sub conf_inicio()
        current_idventa = 0
        tabla_reimpresion.Clear()
        tb_cliente.Text = "--"
        tb_fecha.Text = "--"
        tb_hora.Text = "--"
        tb_forma_pago.Text = "--"
        tb_subtotal.Text = "$00.00"
        tb_iva.Text = "$00.00"
        tb_otros.Text = "$00.00"
        tb_total.Text = "$00.00"
        lbl_folio.Text = "--"
        cliente_alias = ""
        tb_empleado.Text = ""
        tb_status.Text = ""
        btn_reimprimir.Enabled = False
        lst_Pagos.Items.Clear()
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim fecha As Date
        Dim hora As DateTime
        btn_reimprimir.Enabled = False
        If tb_folio.TextLength > 0 Then
            conf_inicio()
            '---buscamos el ticket seleeccionado
            'Conectar()
            rs.Open("SELECT venta.fecha,venta.subtotal,venta.total_impuestos,venta.total," & _
                    "CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente," & _
                    "CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias,venta.status,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado ep, persona p, venta v " & _
                    "WHERE v.id_empleado=ep.id_empleado AND p.id_persona=ep.id_persona AND v.id_venta='" & tb_folio.Text & "') AS empleadopv  " & _
                    "FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                    "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                    "JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE venta.id_venta=" & tb_folio.Text, conn)
            If rs.RecordCount > 0 Then
                fecha = rs.Fields("fecha").Value
                hora = rs.Fields("fecha").Value
                tb_fecha.Text = fecha.ToLongDateString
                tb_hora.Text = hora.ToLongTimeString
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                tb_iva.Text = FormatCurrency(rs.Fields("total_impuestos").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)
                tb_cliente.Text = rs.Fields("cliente").Value
                cliente_alias = rs.Fields("cliente_alias").Value
                lbl_folio.Text = tb_folio.Text
                tb_empleado.Text = rs.Fields("empleadopv").Value
                tb_status.Text = rs.Fields("status").Value
                current_idventa = CInt(tb_folio.Text)
            End If
            rs.Close()
            '----obtenemos detalle de la venta
            rs.Open("SELECT venta_detalle.*,producto.thumb FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto WHERE venta_detalle.id_venta=" & tb_folio.Text, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_producto_dev(rs.Fields("id_producto").Value, rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("total_impuestos").Value, 0, rs.Fields("precio").Value, obtener_miniatura(rs.Fields("thumb").Value), rs.Fields("id_almacen").Value, rs.Fields("nombre_impuestos").Value, 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            '-------------------------------------------
            llenar_lista_cobros(tb_folio.Text)
            '-------------------------------------------
        Else
            MsgBox("Escriba el folio del ticket")
        End If
        tb_folio.Text = ""
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tb_folio.TextLength > 0 Then
            tb_folio.Text = tb_folio.Text.Remove(tb_folio.TextLength - 1, 1)
            tb_folio.SelectionStart = Len(tb_folio.Text)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tb_folio.Text = ""
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btn_buscar_Click(sender, e)
    End Sub

    Private Sub btn_buscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btn_buscar.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub

    Private Sub Button14_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        btn_buscar_Click(sender, e)
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_reimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reimprimir.Click
        If current_idventa <> 0 Then

            Dim k As Integer
            For k = 0 To conf_pv(5)
                imprimir_ticket_venta(current_idventa, k, conf_pv(5))
            Next
        End If
    End Sub
    Public Sub llenar_lista_cobros(ByVal id_venta As Integer)
        lst_Pagos.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_pago_ventas,cobro,cambio,importe,id_forma_pago,fecha,fecha_cobro,status FROM pagos_ventas WHERE id_venta='" & id_venta & "' ORDER by fecha_cobro", conn)
        Dim i = 0
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(6) As String
                str(0) = Format(rs.Fields("fecha").Value, "dd-MM-yyyy")
                str(1) = Format(rs.Fields("fecha_cobro").Value, "dd-MM-yyyy")
                str(2) = nombre_forma_pago(rs.Fields("id_forma_pago").Value)
                str(3) = FormatCurrency(rs.Fields("importe").Value)
                str(4) = FormatCurrency(rs.Fields("cobro").Value)
                str(5) = FormatCurrency(rs.Fields("cambio").Value)
                lst_Pagos.Items.Add(New ListViewItem(str, 0))
                lst_Pagos.Items(i).Tag = rs.Fields("id_pago_ventas").Value
                If rs.Fields("status").Value = "ACTIVO" Then
                    lst_Pagos.Items(i).BackColor = Color.DarkSeaGreen
                    lst_Pagos.Items(i).ForeColor = Color.White
                Else
                    lst_Pagos.Items(i).BackColor = Color.Red
                    lst_Pagos.Items(i).ForeColor = Color.White
                End If
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub lst_Pagos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_Pagos.Click
        If lst_Pagos.SelectedItems.Count > 0 Then
            If lst_Pagos.SelectedItems.Item(0).BackColor = Color.Red Then
                btn_reimprimir.Enabled = False
            Else
                btn_reimprimir.Enabled = True
            End If
        Else
            btn_reimprimir.Enabled = False
        End If
    End Sub
    Private Sub lst_Pagos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_Pagos.SelectedIndexChanged
        If lst_Pagos.SelectedItems.Count > 0 Then
            If lst_Pagos.SelectedItems.Item(0).BackColor = Color.Red Then
                btn_reimprimir.Enabled = False
            Else
                btn_reimprimir.Enabled = True
            End If
        Else
            btn_reimprimir.Enabled = False
        End If

    End Sub
End Class