Public Class frm_clientes
    Dim current_catalogo_precio As Integer
    Dim cargado As Boolean
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        gb_clientes.ForeColor = Color.FromArgb(conf_colores(2))
        lbl_cliente.ForeColor = Color.FromArgb(conf_colores(13))
        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))
        Button2.BackColor = Color.FromArgb(conf_colores(8))
        Button2.ForeColor = Color.FromArgb(conf_colores(9))
        Button3.BackColor = Color.FromArgb(conf_colores(8))
        Button3.ForeColor = Color.FromArgb(conf_colores(9))
        Button4.BackColor = Color.FromArgb(conf_colores(8))
        Button4.ForeColor = Color.FromArgb(conf_colores(9))
        Button5.BackColor = Color.FromArgb(conf_colores(8))
        Button5.ForeColor = Color.FromArgb(conf_colores(9))
        Button6.BackColor = Color.FromArgb(conf_colores(8))
        Button6.ForeColor = Color.FromArgb(conf_colores(9))
        Button7.BackColor = Color.FromArgb(conf_colores(8))
        Button7.ForeColor = Color.FromArgb(conf_colores(9))
        Button8.BackColor = Color.FromArgb(conf_colores(8))
        Button8.ForeColor = Color.FromArgb(conf_colores(9))
        Button9.BackColor = Color.FromArgb(conf_colores(8))
        Button9.ForeColor = Color.FromArgb(conf_colores(9))
        Button10.BackColor = Color.FromArgb(conf_colores(8))
        Button10.ForeColor = Color.FromArgb(conf_colores(9))
        Button11.BackColor = Color.FromArgb(conf_colores(8))
        Button11.ForeColor = Color.FromArgb(conf_colores(9))
        Button12.BackColor = Color.FromArgb(conf_colores(8))
        Button12.ForeColor = Color.FromArgb(conf_colores(9))
        Button13.BackColor = Color.FromArgb(conf_colores(8))
        Button13.ForeColor = Color.FromArgb(conf_colores(9))
        Button14.BackColor = Color.FromArgb(conf_colores(8))
        Button14.ForeColor = Color.FromArgb(conf_colores(9))
        Button15.BackColor = Color.FromArgb(conf_colores(8))
        Button15.ForeColor = Color.FromArgb(conf_colores(9))
        Button16.BackColor = Color.FromArgb(conf_colores(8))
        Button16.ForeColor = Color.FromArgb(conf_colores(9))
        Button17.BackColor = Color.FromArgb(conf_colores(8))
        Button17.ForeColor = Color.FromArgb(conf_colores(9))
        Button18.BackColor = Color.FromArgb(conf_colores(8))
        Button18.ForeColor = Color.FromArgb(conf_colores(9))
        Button19.BackColor = Color.FromArgb(conf_colores(8))
        Button19.ForeColor = Color.FromArgb(conf_colores(9))
        Button20.BackColor = Color.FromArgb(conf_colores(8))
        Button20.ForeColor = Color.FromArgb(conf_colores(9))
        Button21.BackColor = Color.FromArgb(conf_colores(8))
        Button21.ForeColor = Color.FromArgb(conf_colores(9))
        Button22.BackColor = Color.FromArgb(conf_colores(8))
        Button22.ForeColor = Color.FromArgb(conf_colores(9))
        Button23.BackColor = Color.FromArgb(conf_colores(8))
        Button23.ForeColor = Color.FromArgb(conf_colores(9))
        Button25.BackColor = Color.FromArgb(conf_colores(8))
        Button25.ForeColor = Color.FromArgb(conf_colores(9))
        Button26.BackColor = Color.FromArgb(conf_colores(8))
        Button26.ForeColor = Color.FromArgb(conf_colores(9))
        Button27.BackColor = Color.FromArgb(conf_colores(8))
        Button27.ForeColor = Color.FromArgb(conf_colores(9))
        Button28.BackColor = Color.FromArgb(conf_colores(8))
        Button28.ForeColor = Color.FromArgb(conf_colores(9))
        Button29.BackColor = Color.FromArgb(conf_colores(8))
        Button29.ForeColor = Color.FromArgb(conf_colores(9))
        Button30.BackColor = Color.FromArgb(conf_colores(8))
        Button30.ForeColor = Color.FromArgb(conf_colores(9))
        Button31.BackColor = Color.FromArgb(conf_colores(8))
        Button31.ForeColor = Color.FromArgb(conf_colores(9))
        Button33.BackColor = Color.FromArgb(conf_colores(8))
        Button33.ForeColor = Color.FromArgb(conf_colores(9))
        btn_general.BackColor = Color.FromArgb(conf_colores(8))
        btn_general.ForeColor = Color.FromArgb(conf_colores(9))
        btn_barra.BackColor = Color.FromArgb(conf_colores(8))
        btn_barra.ForeColor = Color.FromArgb(conf_colores(9))
        btn_clear.BackColor = Color.FromArgb(conf_colores(8))
        btn_clear.ForeColor = Color.FromArgb(conf_colores(9))
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

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))
        btn_aceptar.BackColor = Color.FromArgb(conf_colores(8))
        btn_aceptar.ForeColor = Color.FromArgb(conf_colores(9))


    End Sub

    Private Sub frm_clientes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frm_principal3.preparar_para_codigo()
    End Sub
    Private Sub limpiar_matriz_clientes()
        For x = 0 To 5000
            For j = 0 To 2
                clientes(x, j) = Nothing
            Next
        Next
    End Sub
    Public Sub cargar_matriz_clientes()
        'Public clientes(500, 1) As Object
        '/        0      /   1    /
        '/ id_cliente  / nombre  / 
        limpiar_matriz_clientes()
        Dim x As Integer = 0
        'Conectar()
        ' rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  CONCAT(empresa.alias,' [',empresa.razon_social,']') ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente<>1 ORDER by cliente.id_cliente", conn)
        rs.Open("SELECT cliente.id_cliente,cliente.clave,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE cliente.id_cliente<>1 ORDER by cliente.id_cliente", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                clientes(x, 0) = rs.Fields("id_cliente").Value
                clientes(x, 1) = rs.Fields("clave").Value
                clientes(x, 2) = rs.Fields("nombre").Value
                x += 1
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        global_matriz_clientes_cargado = True
    End Sub
    Private Sub frm_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        aplicar_colores()
        estilo_clientes(dgv_clientes)
        tb_search.Text = ""
        If global_matriz_clientes_cargado = False Then
            cargar_matriz_clientes()
        End If
        obtener_clientes(tb_search.Text)
        cargado = True
        tb_search.Select()
        tb_search.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button23.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, btn_barra.Click, Button33.Click
        If TypeOf sender Is Button Then
            tb_search.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        If tb_search.TextLength > 0 Then
            tb_search.Text = tb_search.Text.Remove(tb_search.TextLength - 1, 1)
            tb_search.SelectionStart = Len(tb_search.Text)
        End If
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        tb_search.Text = ""
    End Sub

    Private Sub tb_search_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_search.KeyDown, Me.KeyDown
        If e.KeyCode = 40 Then 'abajo
            dgv_clientes.Select()
        End If
    End Sub

    Private Sub tb_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_search.TextChanged
        If cargado = True Then
            obtener_clientes(tb_search.Text)
        End If

    End Sub
    Private Sub dgv_clientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_clientes.DoubleClick
        If tabla_clientes.Rows.Count > 0 Then
            verificar_precio_especial(dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value)
        End If
    End Sub

    Private Sub btn_general_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_general.Click
        If global_tipo_operacion = 0 Then
            btn_general.Enabled = True
        Else
            btn_general.Enabled = False
        End If

        global_current_idcliente = 1
        frm_principal3.tb_cliente.Text = "1.- PÚBLICO EN GENERAL"

        global_current_precio_especial = 0
        global_current_aplicar_redondeo = obtener_aplicar_redondeo(global_current_idcliente)
        Me.Close()
        If tabla_ventas.Rows.Count > 0 Then
            '.actualizamos los precios de la lista
            frm_principal3.actualizar_precios_lista()
        End If
    End Sub
    Private Sub verificar_precio_especial(ByVal id_cliente As Integer)
        current_catalogo_precio = 0
        Dim autorizacion As Integer = 0
        'Conectar()
        rs.Open("SELECT * FROM cliente_precio WHERE id_cliente=" & id_cliente, conn)
        If rs.RecordCount > 0 Then
            current_catalogo_precio = rs.Fields("id_ctlg_precios").Value
            autorizacion = rs.Fields("autorizacion").Value
            If rs.Fields("aplicar_redondeo").Value = 1 Then
                global_current_aplicar_redondeo = True
            Else
                global_current_aplicar_redondeo = False
            End If
        End If
        rs.Close()
        If autorizacion = 1 Then
            frm_validaciones.origen_validacion_cliente = 0
            frm_validaciones.tipo_validacion = 1 '--validacion de precio especial
            frm_validaciones.ShowDialog()
            frm_validaciones.BringToFront()
        Else
            cargar_cliente()
        End If
    End Sub
    Public Sub cargar_cliente()
        global_current_idcliente = dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value
        frm_principal3.tb_cliente.Text = dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("clave").Value & ".- " & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("cliente").Value

        If conf_pv(12) = 0 Then
            '========================AJUSTE DE PRECIO=========================00

            global_current_precio_especial = current_catalogo_precio
            If tabla_ventas.Rows.Count > 0 Then
                '.actualizamos los precios de la lista
                frm_principal3.actualizar_precios_lista()
            End If
            Me.Hide()
            '---cargamos los productos del cliente
            Dim precio As Decimal = 0
            Dim importe As Decimal = 0
            Dim total_impuestos As Decimal = 0
            Dim correcto As Boolean = True
            Dim cadena As String = "Se encontraron los siguientes errores" & vbCrLf
            'Conectar()
            Dim _rs As New ADODB.Recordset
            _rs.Open("SELECT p.id_producto,p.nombre,u.nombre_corto AS unidad,cp.cantidad, i.nombre AS nombre_impuesto, i.tasa AS tasa_impuesto " & _
                    "FROM cliente_productos cp " & _
                    "JOIN producto p ON p.id_producto=cp.id_producto " & _
                    "JOIN unidad u ON p.id_unidad=u.id_unidad " & _
                    "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                    "WHERE id_cliente= " & dgv_clientes.Rows(dgv_clientes.CurrentRow.Index).Cells("id_cliente").Value, conn)
            If _rs.RecordCount > 0 Then
                While Not _rs.EOF
                    'MsgBox(conf_pv(2))
                    Dim id_producto As Integer = _rs.Fields("id_producto").Value
                    Dim descripcion As String = _rs.Fields("nombre").Value
                    Dim unidad As String = _rs.Fields("unidad").Value
                    Dim cantidad As String = _rs.Fields("cantidad").Value
                    Dim nombre_impuesto As String = _rs.Fields("nombre_impuesto").Value
                    Dim tasa_impuesto As String = _rs.Fields("tasa_impuesto").Value

                    If global_tipo_operacion = 0 Then 'SE GUARDA COMO VENTA DIRECTA
                        Dim stock As Decimal = validar_existencia_producto(id_producto, global_current_idalmacen, 1)
                        If stock >= cantidad Then ' CON STOCK
_CANTIDADES_NEGATIVAS:

                            Dim foundRows() As Data.DataRow = tabla_ventas.Select("id_producto = " & id_producto)
                            If foundRows.Length > 0 Then
                                If conf_pv(2) = 1 Then
                                    GoTo _AGREGAR_PC
                                Else
                                    cadena = cadena & "   " & descripcion & " ya se encuentra en la lista" & vbCrLf
                                    correcto = False
                                End If

                            Else
_AGREGAR_PC:
                                precio = Math.Round(obtener_precio_producto(id_producto, global_current_precio_especial) / (1 + tasa_impuesto), 2)
                                importe = precio * cantidad
                                total_impuestos = Math.Round(importe * tasa_impuesto, 2)

                                conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,cantidad,precio,importe,total_impuestos,nombre_impuestos,id_cliente,id_almacen,desc_global_porcent) " & _
                                             "VALUES(" & global_id_empleado & "," & id_producto & ",'" & cantidad & "','" & precio & "','" & importe & "','" & total_impuestos & "','" & nombre_impuesto & "','" & global_current_idcliente & "','" & global_current_idalmacen & "','" & global_current_descuento_global & "')")

                                Dim id_temp_venta As Integer
                                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                                id_temp_venta = rs.Fields(0).Value
                                rs.Close()

                                conn.Execute("UPDATE producto_sucursal SET cantidad=(cantidad-" & cantidad & ") WHERE id_producto='" & id_producto & "' AND id_almacen='" & global_current_idalmacen & "'")

                                agregar_producto(id_producto, descripcion, cantidad, unidad, total_impuestos, tasa_impuesto, precio, importe, global_current_idalmacen, nombre_impuesto, id_temp_venta, 0, 0)
                            End If
                        Else
                            If conf_pv(3) = 1 Then
                                GoTo _CANTIDADES_NEGATIVAS
                            Else
                                cadena = cadena & "   NO se puede surtir " & descripcion & " no hay unidades suficientes en este almacen" & vbCrLf
                                correcto = False
                            End If

                        End If
                    Else

                        Dim foundRows() As Data.DataRow = tabla_ventas.Select("id_producto = " & id_producto)
                        If foundRows.Length > 0 Then
                            If conf_pv(2) = 1 Then
                                GoTo AGREGAR_PC2
                            Else
                                cadena = cadena & "   " & descripcion & " ya se encuentra en la lista" & vbCrLf
                                correcto = False
                            End If

                        Else
AGREGAR_PC2:

                            precio = Math.Round(obtener_precio_producto(id_producto, global_current_precio_especial) / (1 + tasa_impuesto), 2)
                            importe = precio * cantidad
                            total_impuestos = Math.Round(importe * tasa_impuesto, 2)

                            conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,cantidad,precio,importe,total_impuestos,nombre_impuestos,id_cliente,id_almacen,desc_global_porcent) " & _
                                         "VALUES(" & global_id_empleado & "," & id_producto & ",'" & cantidad & "','" & precio & "','" & importe & "','" & total_impuestos & "','" & nombre_impuesto & "','" & global_current_idcliente & "','" & global_current_idalmacen & "','" & global_current_descuento_global & "')")

                            Dim rx As New ADODB.Recordset
                            Dim id_temp_venta As Integer = 0
                            rx.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                            id_temp_venta = rx.Fields(0).Value
                            rx.Close()

                            agregar_producto(id_producto, descripcion, cantidad, unidad, total_impuestos, tasa_impuesto, precio, importe, global_current_idalmacen, nombre_impuesto, id_temp_venta, 0, 0)

                        End If

                    End If

                    _rs.MoveNext()
                End While

            End If

            _rs.Close()
            'conn.close()
            If correcto = False Then
                MsgBox(cadena)
            End If
            '-------------------------------------
        End If

        Me.Close()
    End Sub

    Private Sub dgv_clientes_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_clientes.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        For x = 0 To dgv_clientes.Columns.Count - 1
            If dgv_clientes.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        If TypeOf sender Is Button Then
            tb_search.Focus()
            SendKeys.Send(CType(sender, Button).Text)
        End If
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        dgv_clientes_DoubleClick(sender, e)
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub dgv_clientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_clientes.KeyDown
        If e.KeyCode = 13 Then
            If dgv_clientes.SelectedRows.Count > 0 Then
                btn_aceptar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub dgv_clientes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_clientes.CellContentClick

    End Sub
End Class