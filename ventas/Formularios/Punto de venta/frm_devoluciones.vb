Public Class frm_devoluciones
    Dim ds As DataSet
    Dim tabla_devoluciones As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim total As Decimal = 0
    Dim total_impuestos As Decimal = 0
    Dim subtotal As Decimal = 0
    Dim tipo_devolucion As Integer = 0
    Dim current_idventa As Integer = 0
    Dim msg_error As String = ""
    Dim btn_devolucion As Boolean = False
    Dim bandera_descuento As Boolean
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_devoluciones.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.Black
        Panel2.ForeColor = Color.FromArgb(conf_colores(13))
        Panel1.ForeColor = Color.FromArgb(conf_colores(13))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        rb_intercambio_producto.ForeColor = Color.FromArgb(conf_colores(13))
        rb_devolucion_importe.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_devolver.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_devolver_total.ForeColor = Color.FromArgb(conf_colores(13))

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
        aplicar_colores()
        cargar_estilo_devoluciones()
    End Sub
    Private Sub agregar_producto_dev(ByVal id_producto As Integer, ByVal nombre As String, ByVal cantidad_vendida As Decimal, ByVal cantidad_devuelta As Decimal, ByVal unidad As String, ByVal total_impuestos As Decimal, ByVal precio As Decimal, ByVal importe As Decimal, ByVal id_almacen As Integer, ByVal nombre_impuestos As String, ByVal tasa_impuestos As Decimal, ByVal descuento As Decimal)
        tabla_linea = tabla_devoluciones.NewRow()
        tabla_linea("devolucion") = False
        tabla_linea("id_producto") = id_producto
        tabla_linea("producto") = nombre
        tabla_linea("cantidad_vendida") = cantidad_vendida
        tabla_linea("cantidad_devuelta") = cantidad_devuelta
        tabla_linea("unidad") = unidad
        tabla_linea("total_impuestos") = total_impuestos
        tabla_linea("precio") = precio
        tabla_linea("importe") = importe
        tabla_linea("id_almacen") = id_almacen
        tabla_linea("nombre_impuestos") = nombre_impuestos
        tabla_linea("tasa_impuestos") = tasa_impuestos
        tabla_linea("descuento") = descuento
        tabla_devoluciones.Rows.Add(tabla_linea)
    End Sub
    Private Sub cargar_estilo_devoluciones()
        tabla_devoluciones = New DataTable("devoluciones")
        With tabla_devoluciones.Columns
            .Add(New DataColumn("devolucion", GetType(Boolean)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("producto", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("cantidad_vendida", GetType(Decimal)))
            .Add(New DataColumn("cantidad_devuelta", GetType(Decimal)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))
            .Add(New DataColumn("id_almacen", GetType(Integer)))
            .Add(New DataColumn("total_impuestos", GetType(Decimal)))
            .Add(New DataColumn("nombre_impuestos", GetType(String)))
            .Add(New DataColumn("tasa_impuestos", GetType(String)))
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
            '.Columns("total_impuestos").Visible = False
            '.Columns("nombre_impuestos").Visible = False
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
            With .Columns("producto")
                .HeaderText = "Producto"
                .Width = 150
                .ReadOnly = True
            End With
            With .Columns("cantidad_vendida")
                .HeaderText = "Cantidad venta"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("cantidad_devuelta")
                .HeaderText = "Cantidad a devolver"
                .Width = 80
                .ReadOnly = False
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
        tabla_devoluciones.Clear()
        tb_cliente.Text = "--"
        tb_fecha.Text = "--"
        tb_hora.Text = "--"
        tb_forma_pago.Text = "--"
        tb_subtotal.Text = "$00.00"
        tb_iva.Text = "$00.00"
        tb_total.Text = "$00.00"
        lbl_folio.Text = "--"
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Dim fecha As Date
        Dim hora As DateTime
        If tb_folio.TextLength > 0 Then
            conf_inicio()
            '---buscamos el ticket seleeccionado
            'Conectar()
            rs.Open("SELECT venta.id_venta,venta.fecha,venta.subtotal,venta.total_impuestos,venta.total, " & _
                    "CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente, " & _
                    "CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias " & _
                    "FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
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
                lbl_folio.Text = rs.Fields("id_venta").Value
                current_idventa = CInt(tb_folio.Text)
            End If
            rs.Close()
            '----obtenemos detalle de la venta
            rs.Open("SELECT venta_detalle.*,producto.thumb FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto WHERE venta_detalle.id_venta=" & tb_folio.Text, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_producto_dev(rs.Fields("id_producto").Value, rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, 0, rs.Fields("unidad").Value, rs.Fields("total_impuestos").Value, rs.Fields("precio").Value, rs.Fields("importe").Value, rs.Fields("id_almacen").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("tasa_impuestos").Value, 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            '-------------------------------------------
            'conn.close()
            'conn = Nothing
            '-------------------------------------------
        Else
            MsgBox("Escriba el folio del ticket a devolver")
        End If
        tb_folio.Text = ""
    End Sub
    Private Sub rb_devolucion_importe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_devolucion_importe.CheckedChanged
        If rb_devolucion_importe.Checked = True Then
            lbl_devolver.Visible = True
            lbl_devolver_total.Visible = True
            obtener_total_devolucion()
        Else
            lbl_devolver.Visible = False
            lbl_devolver_total.Visible = False
        End If
    End Sub
    Private Sub obtener_total_devolucion()
        bandera_descuento = False
        total = 0
        total_impuestos = 0
        subtotal = 0

        For x = 0 To dg_devoluciones.RowCount - 1
            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                Dim importe As Decimal = dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value * dg_devoluciones.Rows(x).Cells("precio").Value
                subtotal += importe
                total_impuestos += (importe * dg_devoluciones.Rows(x).Cells("tasa_impuestos").Value)
            End If
        Next
        total = total_impuestos + subtotal
        lbl_devolver_total.Text = FormatCurrency(total)
    End Sub
    Private Sub dg_devoluciones_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_devoluciones.CellValueChanged
        obtener_total_devolucion()
        validar_checked()
        If btn_devolucion = True Then
            btn_devolver.Enabled = True
        Else
            btn_devolver.Enabled = False
        End If

        For x = 0 To dg_devoluciones.RowCount - 1
            If dg_devoluciones.Rows(x).Cells("devolucion").Value = True Then
                If dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value = 0 Then
                    dg_devoluciones.Rows(x).Cells("devolucion").Value = False
                End If
                If dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value > dg_devoluciones.Rows(x).Cells("cantidad_vendida").Value Then
                    MsgBox("No se puede devolver una cantidad mayor a la vendida", MsgBoxStyle.Exclamation, "Aviso")
                    dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value = 0

                End If
            Else
                If dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value > 0 Then
                    dg_devoluciones.Rows(x).Cells("devolucion").Value = True
                End If
            End If


        Next
    End Sub
    Private Sub validar_checked()
        btn_devolucion = False
        For x = 0 To dg_devoluciones.RowCount - 1
            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                btn_devolucion = True
            End If
        Next
    End Sub

    Private Sub btn_devolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_devolver.Click
        Dim confirmacion As String = ""

        If rb_intercambio_producto.Checked = True Then
            If rb_devolver_almacen.Checked = True Then
                tipo_devolucion = 1
                confirmacion = "intercambiar el producto por otro igual en las mismas cantidades y lo devuelto agregarlo al almacen"
            ElseIf rb_no_devolver_almacen.Checked = True Then
                tipo_devolucion = 2
                confirmacion = "intercambiar el producto por otro igual en las mismas cantidades y lo devuelto reportarlo al proveedor"
            End If
        ElseIf rb_devolucion_importe.Checked = True Then
            If rb_devolver_almacen.Checked = True Then
                tipo_devolucion = 3
                confirmacion = "dar el importe de " & lbl_devolver_total.Text & " de los productos devueltos y  agregarlo al almacen"
            ElseIf rb_no_devolver_almacen.Checked = True Then
                tipo_devolucion = 4
                confirmacion = "dar el importe de " & lbl_devolver_total.Text & " de los productos devueltos y reportarlo al proveedor"
            End If
        End If
        If MsgBox("Esta seguro que deseea " & confirmacion, MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
            If tipo_devolucion = 1 Then
                If validar_stock() Then
                    '---guardamos el registro de devolucion
                    'Conectar()
                    '------agregamos registro devolucion---------
                    conn.Execute("INSERT INTO devoluciones(id_venta,fecha,subtotal,total_impuestos,total,tipo_devolucion,id_empleado) VALUES(" & current_idventa & ",NOW(),'" & subtotal & "','" & total_impuestos & "','" & total & "'," & tipo_devolucion & "," & global_id_empleado & ")")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    Dim id_devolucion As Integer = rs.Fields(0).Value
                    rs.Close()
                    '------------------------------------------------
                    '--------agregamos detalle de la devolucion-----
                    For x = 0 To dg_devoluciones.RowCount - 1
                        If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                            conn.Execute("INSERT INTO devoluciones_detalle(id_devolucion,id_producto,descripcion,unidad,cantidad,total_impuestos,importe,precio_unitario,id_almacen) VALUES('" & id_devolucion & "','" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "','" & dg_devoluciones.Rows(x).Cells("producto").Value & "','" & dg_devoluciones.Rows(x).Cells("unidad").Value & "','" & dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value & "','" & dg_devoluciones.Rows(x).Cells("total_impuestos").Value & "','" & dg_devoluciones.Rows(x).Cells("importe").Value & "','" & dg_devoluciones.Rows(x).Cells("precio").Value & "','" & dg_devoluciones.Rows(x).Cells("id_almacen").Value & "')")
                        End If
                    Next
                    '--------------------------------------------------
                    'conn.close()
                    'conn = Nothing
                    conf_inicio()
                    imprimir_comprobante_devolucion(id_devolucion)
                    MsgBox("Devolucion efectuada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox(msg_error, MsgBoxStyle.Critical, "Error")
                End If
            ElseIf tipo_devolucion = 2 Then
                If validar_stock() Then
                    '---guardamos el registro de devolucion
                    'Conectar()
                    '------agregamos registro devolucion---------
                    conn.Execute("INSERT INTO devoluciones(id_venta,fecha,subtotal,total_impuestos,total,tipo_devolucion,id_empleado) VALUES(" & current_idventa & ",NOW(),'" & subtotal & "','" & total_impuestos & "','" & total & "'," & tipo_devolucion & "," & global_id_empleado & ")")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    Dim id_devolucion As Integer = rs.Fields(0).Value
                    rs.Close()
                    '------------------------------------------------
                    '--------agregamos detalle de la devolucion-----
                    For x = 0 To dg_devoluciones.RowCount - 1
                        If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                            conn.Execute("INSERT INTO devoluciones_detalle(id_devolucion,id_producto,descripcion,unidad,cantidad,total_impuestos,importe,precio_unitario,id_almacen) VALUES('" & id_devolucion & "','" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "','" & dg_devoluciones.Rows(x).Cells("producto").Value & "','" & dg_devoluciones.Rows(x).Cells("unidad").Value & "','" & dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value & "','" & dg_devoluciones.Rows(x).Cells("total_impuestos").Value & "','" & dg_devoluciones.Rows(x).Cells("importe").Value & "','" & dg_devoluciones.Rows(x).Cells("precio").Value & "','" & dg_devoluciones.Rows(x).Cells("id_almacen").Value & "')")
                            conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value & ") WHERE id_producto='" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "' AND id_almacen=" & global_current_idalmacen)
                        End If
                    Next
                    '--------------------------------------------------
                    'conn.close()
                    'conn = Nothing
                    conf_inicio()
                    imprimir_comprobante_devolucion(id_devolucion)
                    MsgBox("Devolucion efectuada correctamente", MsgBoxStyle.Information, "Aviso")
                Else
                    MsgBox(msg_error, MsgBoxStyle.Critical, "Error")
                End If
            ElseIf tipo_devolucion = 3 Then

                If bandera_descuento Then
                    MsgBox("No se puede devolver efectivo de productos vendidos con descuento", MsgBoxStyle.Critical, "Operación no permitida")
                Else
                    If saldo_caja() >= total Then
                        '---guardamos el registro de devolucion
                        'Conectar()
                        '------agregamos registro devolucion---------
                        conn.Execute("INSERT INTO devoluciones(id_venta,fecha,subtotal,total_impuestos,total,tipo_devolucion,id_empleado) VALUES(" & current_idventa & ",NOW(),'" & subtotal & "','" & total_impuestos & "','" & total & "'," & tipo_devolucion & "," & global_id_empleado & ")")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        Dim id_devolucion As Integer = rs.Fields(0).Value
                        rs.Close()
                        '------------------------------------------------
                        '--------agregamos detalle de la devolucion-----
                        For x = 0 To dg_devoluciones.RowCount - 1
                            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                                conn.Execute("INSERT INTO devoluciones_detalle(id_devolucion,id_producto,descripcion,unidad,cantidad,total_impuestos,importe,precio_unitario,id_almacen) VALUES('" & id_devolucion & "','" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "','" & dg_devoluciones.Rows(x).Cells("producto").Value & "','" & dg_devoluciones.Rows(x).Cells("unidad").Value & "','" & dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value & "','" & dg_devoluciones.Rows(x).Cells("total_impuestos").Value & "','" & dg_devoluciones.Rows(x).Cells("importe").Value & "','" & dg_devoluciones.Rows(x).Cells("precio").Value & "','" & dg_devoluciones.Rows(x).Cells("id_almacen").Value & "')")
                                conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad +" & dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value & ") WHERE id_producto='" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "' AND id_almacen=" & dg_devoluciones.Rows(x).Cells("id_almacen").Value)
                            End If
                        Next
                        '--------------------------------------------------
                        'conn.close()
                        'conn = Nothing
                        conf_inicio()
                        imprimir_comprobante_devolucion(id_devolucion)
                        MsgBox("Devolucion efectuada correctamente", MsgBoxStyle.Information, "Aviso")
                    Else
                        MsgBox("No se puede realizar esta operación. No cuenta con el efectivo suficiente", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            ElseIf tipo_devolucion = 4 Then
                If bandera_descuento Then
                    MsgBox("No se puede devolver efectivo de productos vendidos con descuento", MsgBoxStyle.Critical, "Operación no permitida")
                Else
                    If saldo_caja() >= total Then
                        '---guardamos el registro de devolucion
                        'Conectar()
                        '------agregamos registro devolucion---------
                        conn.Execute("INSERT INTO devoluciones(id_venta,fecha,subtotal,total_impuestos,total,tipo_devolucion,id_empleado) VALUES(" & current_idventa & ",NOW(),'" & subtotal & "','" & total_impuestos & "','" & total & "'," & tipo_devolucion & "," & global_id_empleado & ")")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        Dim id_devolucion As Integer = rs.Fields(0).Value
                        rs.Close()
                        '------------------------------------------------
                        '--------agregamos detalle de la devolucion-----
                        For x = 0 To dg_devoluciones.RowCount - 1
                            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                                conn.Execute("INSERT INTO devoluciones_detalle(id_devolucion,id_producto,descripcion,unidad,cantidad,total_impuestos,importe,precio_unitario,id_almacen) VALUES('" & id_devolucion & "','" & dg_devoluciones.Rows(x).Cells("id_producto").Value & "','" & dg_devoluciones.Rows(x).Cells("producto").Value & "','" & dg_devoluciones.Rows(x).Cells("unidad").Value & "','" & dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value & "','" & dg_devoluciones.Rows(x).Cells("total_impuestos").Value & "','" & dg_devoluciones.Rows(x).Cells("importe").Value & "','" & dg_devoluciones.Rows(x).Cells("precio").Value & "','" & dg_devoluciones.Rows(x).Cells("id_almacen").Value & "')")
                            End If
                        Next
                        '--------------------------------------------------
                        'conn.close()
                        'conn = Nothing
                        conf_inicio()
                        imprimir_comprobante_devolucion(id_devolucion)
                        MsgBox("Devolucion efectuada correctamente", MsgBoxStyle.Information, "Aviso")
                    Else
                        MsgBox("No se puede realizar esta operación. No cuenta con el efectivo sufuciente", MsgBoxStyle.Critical, "Error")
                    End If
                End If

            End If
        End If
    End Sub
    Private Sub imprimir_comprobante_devolucion(ByVal id_devolucion As Integer)
        If MsgBox("A continuación se imprimirá el ticket de retiro de efectivo. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            For x = 0 To 1
                If conf_pv(21) = 0 Then
                    imprimir_ticket_devolucion_matriz(id_devolucion, x)
                Else
                    imprimir_ticket_devolucion_matriz(id_devolucion, x)
                End If

            Next
        Else
            If conf_pv(21) = 0 Then
                imprimir_ticket_devolucion_matriz(id_devolucion, 0)
            Else
                imprimir_ticket_devolucion_matriz(id_devolucion, 0)
            End If
        End If
    End Sub
    Private Function validar_stock() As Boolean
        Dim correcto As Boolean = True
        msg_error = "No se puede realizar esta operacion." & vbCrLf & "Se encontraron los siguiente errores:" & vbCrLf
        For x = 0 To dg_devoluciones.RowCount - 1
            If dg_devoluciones.Rows(x).Cells("devolucion").Value Then
                Dim cantidad = CDec(dg_devoluciones.Rows(x).Cells("cantidad_devuelta").Value)
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