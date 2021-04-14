Public Class frm_devoluciones_proveedor
    Dim ds As DataSet
    Dim tabla_devoluciones As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim total As Decimal = 0
    Dim total_iva As Decimal = 0
    Dim total_otros As Decimal = 0
    Dim subtotal As Decimal = 0
    Dim tipo_devolucion As Integer = 0
    Dim current_idfactura_compra As Integer = 0
    Dim msg_error As String = ""
    Dim btn_devolucion As Boolean = False
    Dim bandera_descuento As Boolean
    Dim cargado As Boolean = False
    Dim total_compra As Decimal = 0
    Dim total_devolucion As Decimal = 0
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_devoluciones.ForeColor = Color.FromArgb(conf_colores(2))
        gb_devolucion.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.Black
        Panel2.ForeColor = Color.FromArgb(conf_colores(13))

        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        rb_descontar_inventario.ForeColor = Color.FromArgb(conf_colores(13))

        btn_buscar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_devolver.BackColor = Color.FromArgb(conf_colores(8))
        btn_devolver.ForeColor = Color.FromArgb(conf_colores(9))

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
        cargado = False
        aplicar_colores()
        cargar_estilo_devoluciones()
        cargado = True
    End Sub
    Private Sub agregar_producto_dev(ByVal id_producto As Integer, ByVal nombre As String, ByVal cantidad As Decimal, ByVal cantidad_devolucion As Decimal, ByVal unidad As String, ByVal total_iva As Decimal, ByVal total_otros As Decimal, ByVal precio As Decimal, ByVal imagen As Object, ByVal id_almacen As Integer, ByVal impuestos As String, ByVal descuento As Decimal)
        tabla_linea = tabla_devoluciones.NewRow()
        tabla_linea("devolucion") = False
        tabla_linea("id_producto") = id_producto
        tabla_linea("imagen") = imagen
        tabla_linea("producto") = nombre
        tabla_linea("unidad") = unidad
        tabla_linea("cantidad") = cantidad
        tabla_linea("cantidad_devolucion") = cantidad_devolucion
        tabla_linea("precio") = precio
        Dim importe As Decimal = precio * cantidad
        tabla_linea("importe") = redondear(FormatNumber(importe, 2))
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("total_iva") = total_iva
        tabla_linea("total_otros") = total_otros
        tabla_linea("nombre_impuestos") = impuestos
        tabla_linea("descuento") = descuento
        tabla_devoluciones.Rows.Add(tabla_linea)
    End Sub
    Private Sub cargar_estilo_devoluciones()
        tabla_devoluciones = New DataTable("devoluciones")
        With tabla_devoluciones.Columns
            .Add(New DataColumn("devolucion", GetType(Boolean)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("producto", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("cantidad_devolucion", GetType(Decimal)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("id_almacen", GetType(Integer)))
            .Add(New DataColumn("total_iva", GetType(Decimal)))
            .Add(New DataColumn("total_otros", GetType(Decimal)))
            .Add(New DataColumn("nombre_impuestos", GetType(String)))
            .Add(New DataColumn("descuento", GetType(Decimal)))

        End With
        ds = New DataSet
        ds.Tables.Add(tabla_devoluciones)

        With dg_devoluciones
            .DataSource = ds
            .DataMember = "devoluciones"

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

            With .Columns("devolucion")
                .HeaderText = "Dev."
                .Width = 40
                .ReadOnly = False
            End With
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
                .Width = 250
                .ReadOnly = True
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 60
                .ReadOnly = True
            End With

            With .Columns("cantidad_devolucion")
                .HeaderText = "Cantidad Devolucion"
                .Width = 60
                .ReadOnly = False
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unit."
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Total"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
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
        tabla_devoluciones.Clear()
        tb_proveedor.Text = "--"
        tb_fecha.Text = "--"
        tb_hora.Text = "--"
        tb_subtotal.Text = "$00.00"
        tb_iva.Text = "$00.00"
        tb_otros.Text = "$00.00"
        tb_total.Text = "$00.00"
        lbl_folio.Text = "--"
        tb_total_despues_devolucion.Text = "$00.00"
        subtotal = 0
        total_iva = 0
        total_otros = 0
        total_devolucion = 0
        lbl_total_devolucion.Text = "$00.00"
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar(tb_folio.Text)
    End Sub
    Private Sub cargar(ByVal id_factura_compra As String)
        Dim fecha As Date
        Dim hora As DateTime
        total_compra = 0
        If Trim(id_factura_compra) <> "" Then
            conf_inicio()
            '---buscamos el ticket seleeccionado
            'Conectar()
            rs.Open("SELECT factura_compra.fecha,factura_compra.folio,factura_compra.subtotal,factura_compra.iva,factura_compra.otros,factura_compra.total," & _
                    "CASE WHEN proveedor.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS proveedor," & _
                    "CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS proveedor_alias " & _
                    "FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                    "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa " & _
                    "JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE factura_compra.id_factura_compra=" & id_factura_compra, conn)

            If rs.RecordCount > 0 Then
                fecha = rs.Fields("fecha").Value
                hora = rs.Fields("fecha").Value
                tb_fecha.Text = fecha.ToLongDateString
                tb_hora.Text = hora.ToLongTimeString
                tb_subtotal.Text = FormatCurrency(rs.Fields("subtotal").Value)
                tb_iva.Text = FormatCurrency(rs.Fields("iva").Value)
                tb_otros.Text = FormatCurrency(rs.Fields("otros").Value)
                total_compra = FormatCurrency(rs.Fields("total").Value)
                tb_total.Text = FormatCurrency(rs.Fields("total").Value)
                tb_proveedor.Text = rs.Fields("proveedor").Value
                lbl_folio.Text = rs.Fields("folio").Value
                current_idfactura_compra = CInt(id_factura_compra)
            End If
            rs.Close()
            '----obtenemos detalle de la venta
            Dim rw As New ADODB.Recordset
            Dim id_almacen As Integer = 0
            rs.Open("SELECT factura_compra_detalle.*,producto.thumb FROM factura_compra_detalle JOIN producto ON producto.id_producto=factura_compra_detalle.id_producto WHERE factura_compra_detalle.id_factura_compra=" & id_factura_compra, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    rw.Open("SELECT id_almacen FROM producto_sucursal WHERE id_producto='" & rs.Fields("id_producto").Value & "' LIMIT 1", conn)
                    If rw.RecordCount > 0 Then
                        id_almacen = rw.Fields("id_almacen").Value
                    End If
                    rw.Close()
                    agregar_producto_dev(rs.Fields("id_producto").Value, rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, 0, rs.Fields("unidad").Value, "0", "0", rs.Fields("precio_unitario").Value, obtener_miniatura(rs.Fields("thumb").Value), id_almacen, "", "0")
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            '-------------------------------------------
            'conn.close()
            'conn = Nothing
            '-------------------------------------------
        Else
            MsgBox("Escriba el folio de la recepcion de producto a devolver")
        End If
        tb_folio.Text = ""
    End Sub
    Private Sub dg_devoluciones_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_devoluciones.CellValueChanged
        If cargado = True Then
            If dg_devoluciones.Rows(dg_devoluciones.CurrentRow.Index).Cells("cantidad_devolucion").Value > dg_devoluciones.Rows(dg_devoluciones.CurrentRow.Index).Cells("cantidad").Value Then
                dg_devoluciones.Rows(dg_devoluciones.CurrentRow.Index).Cells("cantidad_devolucion").Value = 0
                MsgBox("No se puede devolver una cantidad mayor a la recibida", MsgBoxStyle.Exclamation, "Aviso")
            End If
            validar_checked()
            If btn_devolucion = True Then
                btn_devolver.Enabled = True
            Else
                btn_devolver.Enabled = False
            End If
        End If

    End Sub
    Private Sub validar_checked()
        btn_devolucion = False
        total_devolucion = 0
        For x = 0 To dg_devoluciones.RowCount - 1
            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                total_devolucion += dg_devoluciones.Rows(x).Cells("cantidad_devolucion").Value * dg_devoluciones.Rows(x).Cells("precio").Value
                btn_devolucion = True
            End If
        Next
        lbl_total_devolucion.Text = FormatCurrency(total_devolucion)
        tb_total_despues_devolucion.Text = FormatCurrency(total_compra - total_devolucion)
    End Sub

    Private Sub btn_devolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devolver.Click
        Dim id_devolucion_proveedor As Integer = 0
        If MsgBox("Esta seguro que deseea devolver los productos seleccionados?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
            If validar_stock() Then
                '---guardamos el registro de devolucion
                'Conectar()
                '------agregamos registro devolucion---------
                conn.Execute("INSERT INTO devoluciones_proveedor(id_factura_compra,fecha,subtotal,total_iva,total_otros,total,id_empleado) VALUES(" & current_idfactura_compra & ",NOW(),'" & total_devolucion & "','0','0','" & total_devolucion & "'," & global_id_empleado & ")")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_devolucion_proveedor = rs.Fields(0).Value
                rs.Close()
                '------------------------------------------------
                '--------agregamos detalle de la devolucion-----
                For x = 0 To dg_devoluciones.RowCount - 1
                    If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                        conn.Execute("INSERT INTO devoluciones_proveedor_detalle(id_devolucion_proveedor,id_producto,descripcion,unidad,cantidad,total_porcent_iva,total_porcent_otros,importe,precio_unitario,id_almacen) VALUES('" & id_devolucion_proveedor & "','" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "','" & dg_devoluciones.Rows(x).Cells("producto").Value & "','" & dg_devoluciones.Rows(x).Cells("unidad").Value & "','" & dg_devoluciones.Rows(x).Cells("cantidad_devolucion").Value & "','" & dg_devoluciones.Rows(x).Cells("total_iva").Value & "','" & dg_devoluciones.Rows(x).Cells("total_otros").Value & "','" & dg_devoluciones.Rows(x).Cells("cantidad_devolucion").Value * dg_devoluciones.Rows(x).Cells("precio").Value & "','" & dg_devoluciones.Rows(x).Cells("precio").Value & "','" & dg_devoluciones.Rows(x).Cells("id_almacen").Value & "')")
                        conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & dg_devoluciones.Rows(x).Cells("cantidad_devolucion").Value & ") WHERE id_producto='" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "' AND id_almacen=" & global_current_idalmacen)
                        conn.Execute("UPDATE factura_compra_detalle SET cantidad=(cantidad-" & dg_devoluciones.Rows(x).Cells("cantidad_devolucion").Value & ") WHERE id_producto='" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "' AND id_factura_compra=" & current_idfactura_compra)
                    End If
                Next
                '--------------------------------------------------
                conn.Execute("UPDATE factura_compra SET subtotal=(subtotal-" & total_devolucion & "), total=(total-" & total_devolucion & ") WHERE id_factura_compra=" & current_idfactura_compra)
                'conn.close()
                'conn = Nothing

                conf_inicio()
                cargar(current_idfactura_compra)
                MsgBox("Devolucion efectuada correctamente", MsgBoxStyle.Information, "Aviso")
                If MsgBox("A continuación se imprimirá el ticket de devolucion. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    For x = 0 To 1
                        imprimir_devolucion_proveedor(id_devolucion_proveedor, x)
                        imprimir_compra_producto(current_idfactura_compra, x)
                    Next
                Else
                    imprimir_devolucion_proveedor(id_devolucion_proveedor, 0)
                    imprimir_compra_producto(current_idfactura_compra, 0)
                End If
            Else
                MsgBox(msg_error, MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub
    Private Function validar_stock() As Boolean
        Dim correcto As Boolean = True
        msg_error = "No se puede realizar esta operacion." & vbCrLf & "Se encontraron los siguiente errores:" & vbCrLf
        For x = 0 To dg_devoluciones.RowCount - 1
            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                Dim cantidad = CDec(dg_devoluciones.Rows(x).Cells("cantidad_devolucion").Value)
                Dim stock = validar_existencia_producto(dg_devoluciones.Rows(x).Cells("id_producto").Value, global_current_idalmacen)
                If stock < cantidad Then
                    correcto = False
                    msg_error += "    -" & cantidad & " " & dg_devoluciones.Rows(x).Cells("producto").Value & ". No existen unidades suficientes."
                End If
            End If
        Next

        Return correcto
    End Function

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If tb_folio.TextLength > 0 Then
            tb_folio.Text = tb_folio.Text.Remove(tb_folio.TextLength - 1, 1)
            tb_folio.SelectionStart = Len(tb_folio.Text)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
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

    Private Sub dg_devoluciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_devoluciones.CellContentClick

    End Sub
End Class