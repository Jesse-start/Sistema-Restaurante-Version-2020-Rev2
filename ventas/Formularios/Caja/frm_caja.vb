Public Class frm_caja
    Dim total_ventas As Integer = 0 ' numero de  ventas en la lista
    Dim total_creditos As Integer = 0 'numero de  creditos en la lista
    Private credito As Integer = 0
    Private _inactiveTimeRetriever As New cIdleTimeStool    'Tiempo Inactivo
    Dim form_activo As Boolean = True
    Dim bandera_cobro As Boolean = False

    '========================varibales para la tabla cuentasxcobrar
    Dim ds, ds2 As DataSet
    Public tabla_caja As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow
    Private current_campo As Integer '0- pago, 1.-referencia
    Private Sub conf_pagotarjeta()
        gb_tarjeta.Visible = True
        gb_efectivo.Enabled = False
        btn_1.Enabled = False
        btn_2.Enabled = False
        btn_5.Enabled = False
        btn_10.Enabled = False
        btn_20.Enabled = False
        btn_50.Enabled = False
        btn_50c.Enabled = False
        btn_100.Enabled = False
        btn_200.Enabled = False
        btn_500.Enabled = False
        btn_1000.Enabled = False
    End Sub
    Private Sub conf_pagoefectivo()
        seleccionar_catalogo("1", cb_forma_pago) 'el id de efectivo es 1
        gb_efectivo.Enabled = True
        current_campo = 0
        gb_tarjeta.Visible = False
        btn_1.Enabled = True
        btn_2.Enabled = True
        btn_5.Enabled = True
        btn_10.Enabled = True
        btn_20.Enabled = True
        btn_50.Enabled = True
        btn_50c.Enabled = True
        btn_100.Enabled = True
        btn_200.Enabled = True
        btn_500.Enabled = True
    End Sub
    Private Sub aplicar_colores()
        lbl_forma_pago.ForeColor = Color.FromArgb(conf_colores(13))
        Me.BackColor = Color.FromArgb(conf_colores(1))
        'TabCreditos.BackColor = Color.FromArgb(conf_colores(1))
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        Panel2.ForeColor = Color.FromArgb(conf_colores(13))
        Panel1.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
        lb_nombre.ForeColor = Color.FromArgb(conf_colores(13))
        lb_nombre.ActiveLinkColor = Color.FromArgb(conf_colores(13))
        lb_nombre.LinkColor = Color.FromArgb(conf_colores(13))
        lb_puesto.ForeColor = Color.FromArgb(conf_colores(13))

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

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
        btn_cancelar_venta.BackColor = Color.FromArgb(conf_colores(8))
        btn_cancelar_venta.ForeColor = Color.FromArgb(conf_colores(9))
        btn_credito.BackColor = Color.FromArgb(conf_colores(8))
        btn_credito.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cobrar.BackColor = Color.FromArgb(conf_colores(8))
        btn_cobrar.ForeColor = Color.FromArgb(conf_colores(9))
        btn_cupones.BackColor = Color.FromArgb(conf_colores(8))
        btn_cupones.ForeColor = Color.FromArgb(conf_colores(9))
        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))
        btn_regalias.BackColor = Color.FromArgb(conf_colores(8))
        btn_regalias.ForeColor = Color.FromArgb(conf_colores(9))
    End Sub
    Private Sub frm_caja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        global_frm_caja = 0
        'If global_cfg_id_pantalla = 0 Then
        'frm_principal.preparar_para_codigo()
        'Else
        'frm_principal2.preparar_para_codigo()
        'End If
    End Sub
    Private Sub frm_cuentas_xcobrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TabCreditos.Parent = Nothing
        aplicar_colores()
        global_frm_caja = 1
        _inactiveTimeRetriever = New cIdleTimeStool
        tiempo_inactivo.Start()
        current_campo = 0
        crear_columnas_cuentasxcobrar()
        obtener_cuentasxcobrar()
        ' Centrar(Pagos)
        cargar()
        If conf_pv(0) = 1 Then
            btn_cupones.Enabled = True
        End If
        'tb_pago.Focus()
    End Sub
    Private Sub cargar_billete(ByVal cantidad As Decimal)
        If tb_pago.TextLength = 0 Then
            tb_pago.Text = cantidad
        Else
            tb_pago.Text = CDec(tb_pago.Text) + cantidad
        End If
        bandera_cobro = False
        tb_cambio.Text = "0.00"
    End Sub
    Public Sub cargar()

        rellenar_catalogo_combobox("id_forma_pago", "nombre", "forma_pago", cb_forma_pago,,, "CONCAT(clave,'-',nombre) as nombre")

        lb_nombre.Text = global_nombre
        lb_puesto.Text = global_puesto
        Dim foto As Byte()
        'Conectar()
        rs.Open("SELECT thumb FROM empleado WHERE id_empleado=" & global_id_empleado, conn)
        If Not IsDBNull(rs.Fields("thumb").Value) Then
            foto = CType(rs.Fields("thumb").Value, Byte())
            Try
                pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(foto))
            Catch ex As Exception
            End Try
            rs.Close()

        Else
            rs.Close()
            rs.Open("SELECT thumb FROM configuracion", conn)
            If Not IsDBNull(rs.Fields("thumb").Value) Then
                foto = CType(rs.Fields("thumb").Value, Byte())
                Try
                    pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(foto))
                Catch ex As Exception
                End Try
                rs.Close()
            End If
        End If
        'conn.close()
        'conn = Nothing
    End Sub
    Public Sub obtener_cuentasxcobrar(Optional ByVal busqueda As String = "") 'obtenemos todas la cuentas pendientes por cobrar
        tabla_caja.Clear()
        total_ventas = 0
        total_creditos = 0
        Dim filtro As String = ""
        If Trim(busqueda) <> "" Then
            filtro = "And venta.id_venta='" & tb_buscar.Text & "'"
        End If


        rs.Open("SELECT venta.id_empleado,venta.id_venta,venta.fecha,venta.total,venta.cliente_publico_alias,cliente.id_cliente, CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " &
                "FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " &
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " &
                "JOIN venta ON venta.id_cliente=cliente.id_cliente WHERE STATUS='ABIERTA' " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim nombre_cliente As String = rs.Fields("nombre").Value
                If rs.Fields("id_cliente").Value = 1 Then
                    nombre_cliente = rs.Fields("cliente_publico_alias").Value
                End If
                agregar_venta(rs.Fields("id_venta").Value, rs.Fields("id_empleado").Value, rs.Fields("fecha").Value, nombre_cliente, rs.Fields("nombre").Value, rs.Fields("id_cliente").Value, rs.Fields("total").Value, "ventas", 0, 0)
                rs.MoveNext()
            End While
        End If
        rs.Close()


        seleccion_venta()
        tb_buscar.Text = ""

        If conf_pv(7) = 1 Then
            tb_buscar.Select()
            tb_buscar.Focus()
        End If

    End Sub
    Private Sub agregar_venta(ByVal id_venta As Integer, ByVal id_empleado As Integer, ByVal fecha As Date, ByVal nombre_cliente As String, ByVal cliente_alias As String, ByVal id_cliente As Integer, ByVal total As Decimal, ByVal _tabla As String, ByVal id_retiro As Integer, ByVal cantidad_retiro As Decimal, Optional ByVal agente_entrega As String = "")
        If _tabla = "ventas" Then
            total_ventas = total_ventas + 1
            tabla_linea = tabla_caja.NewRow()
            tabla_linea("id_venta") = id_venta
            tabla_linea("num_ticket") = id_venta
            tabla_linea("id_empleado") = id_empleado
            tabla_linea("nombre_empleado") = obtener_nombre_empleado_venta(id_venta)
            tabla_linea("id_cliente") = id_cliente
            tabla_linea("cliente_alias") = cliente_alias
            tabla_linea("num_venta") = total_ventas
            tabla_linea("fecha_hora") = fecha
            tabla_linea("cliente") = nombre_cliente
            tabla_linea("productos") = obtener_detalle_venta(id_venta)
            tabla_linea("total") = total
            tabla_linea("id_retiro") = id_retiro
            tabla_linea("cantidad_retiro") = cantidad_retiro
            tabla_caja.Rows.Add(tabla_linea)
        End If

    End Sub
    Private Function obtener_nombre_empleado_venta(ByVal id_venta As Integer) As String
        Dim nombre As String = ""
        Dim rs2 As New ADODB.Recordset
        rs2.Open("SELECT persona.nombre from persona join empleado on empleado.id_persona=persona.id_persona join venta on venta.id_empleado=empleado.id_empleado WHERE venta.id_venta='" & id_venta & "'", conn)
        If rs2.RecordCount > 0 Then
            nombre = rs2.Fields("nombre").Value
        End If
        rs2.Close()
        Return nombre
    End Function

    Private Function obtener_detalle_venta(ByVal id_venta As Integer) As String
        Dim detalle As String = ""
        ' 'Conectar()
        Dim rs2 As New ADODB.Recordset
        rs2.Open("SELECT producto.nombre,cantidad,unidad.nombre as unidad FROM venta_detalle JOIN producto ON producto.id_producto=venta_detalle.id_producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE venta_detalle.id_venta='" & id_venta & "'", conn)
        If rs2.RecordCount > 0 Then
            While Not rs2.EOF
                detalle = detalle & rs2.Fields("cantidad").Value & " " & rs2.Fields("unidad").Value & " " & rs2.Fields("nombre").Value & vbCrLf
                rs2.MoveNext()
            End While
        End If
        rs2.Close()
        Return detalle
    End Function
    Private Sub crear_columnas_cuentasxcobrar()
        tabla_caja = New DataTable("ventas")
        With tabla_caja.Columns
            .Add(New DataColumn("id_venta", GetType(Integer)))  'Oculto
            .Add(New DataColumn("nombre_empleado", GetType(String))) 'Oculto
            .Add(New DataColumn("num_venta", GetType(String)))
            .Add(New DataColumn("fecha_hora", GetType(String)))
            .Add(New DataColumn("cliente", GetType(String)))
            .Add(New DataColumn("id_cliente", GetType(Integer))) 'oculto
            .Add(New DataColumn("num_ticket", GetType(Decimal)))
            .Add(New DataColumn("productos", GetType(String)))
        
            .Add(New DataColumn("total", GetType(Decimal)))
            .Add(New DataColumn("cliente_alias", GetType(String)))
            .Add(New DataColumn("id_empleado", GetType(Integer)))
            .Add(New DataColumn("id_retiro", GetType(Integer)))
            .Add(New DataColumn("cantidad_retiro", GetType(Decimal)))
        End With
        ds = New DataSet
        ds.Tables.Add(tabla_caja)

        With dgv_pagos
            .DataSource = ds

            .DataMember = "ventas"
            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            With .Columns("id_venta")
                .Visible = False
                .Width = 0
            End With
            With .Columns("id_cliente")
                .Visible = False
                .Width = 0
            End With
            With .Columns("nombre_empleado")
                .Visible = False
                .Width = 0
            End With
            With .Columns("cliente_alias")
                .Visible = False
                .Width = 0
            End With

            With .Columns("fecha_hora")
                .HeaderText = "Fecha - Hora"
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With

            With .Columns("id_retiro")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("cantidad_retiro")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With

            With .Columns("num_venta")
                .HeaderText = "No"
                .Width = 30
                .ReadOnly = True
            End With
            With .Columns("cliente")
                .HeaderText = "Cliente"
                .Width = 175
                .ReadOnly = True
            End With
            With .Columns("num_ticket")
                .HeaderText = "Folio"
                .Width = 50
                .ReadOnly = True
            End With

            With .Columns("productos")
                .HeaderText = "Productos"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 230
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                ' .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("total")
                .HeaderText = "Total a pagar"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("id_empleado")
                .Width = 0
                .Visible = False
            End With
        End With
    End Sub

    Private Sub btn_cobrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cobrar.Click
        frm_formas_pago_ventas.id_venta = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value
        frm_formas_pago_ventas.credito = Me.credito
        frm_formas_pago_ventas.nombre_cliente = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente").Value
        frm_formas_pago_ventas.cliente_alias = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente_alias").Value
        frm_formas_pago_ventas.empleado_venta = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("nombre_empleado").Value
        frm_formas_pago_ventas.credito_asignado = False
        frm_formas_pago_ventas.ShowDialog()

    End Sub
    Private Sub dgv_pagos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_pagos.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        For x = 0 To dgv_pagos.Columns.Count - 1
            If dgv_pagos.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dgv_pagos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_pagos.Click
        seleccion_venta()
    End Sub
    Private Sub seleccion_venta()
        bandera_cobro = False
        If total_ventas > 0 Then
            If dgv_pagos.SelectedRows.Count > 0 Then
                btn_credito.Enabled = False
                btn_regalias.Enabled = False
                bandera_cobro = False
                btn_cobrar.Enabled = True
                btn_cancelar_venta.Enabled = True
                If dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_retiro").Value > 0 Then
                    tb_importe.Text = FormatCurrency(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value + dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cantidad_retiro").Value)
                Else
                    tb_importe.Text = FormatCurrency(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value)
                End If

                tb_pago.Text = ""
                tb_cambio.Text = "00.00"
                tb_pago.Select()
                tb_pago.Focus()
                '--verificamos si podemos dar regalias

                btn_regalias.Enabled = True

                '---------------------------------------
                '----verificamos privilegios crediticios
                credito = 0
                Dim limite As Integer = 0
                Dim limite_credito As Double = 0
                Dim total_credito As Double = 0
                Dim credito_actual As Double = 0
                'Conectar()
                rs.Open("SELECT * FROM cliente_credito where id_cliente=" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_cliente").Value, conn)
                If rs.RecordCount > 0 Then
                    credito = rs.Fields("credito").Value
                    limite = rs.Fields("limite").Value
                    limite_credito = CDbl(rs.Fields("limite_credito").Value)
                End If
                rs.Close()
                'conn.close()

                If credito = 1 Then
                    If limite = 1 Then
                        '---verificamos los creditos existentes
                        'Conectar()
                        rs.Open("SELECT ((SELECT CASE WHEN ISNULL(SUM(total)) THEN 0 ELSE SUM(total) END FROM venta WHERE id_cliente='" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_cliente").Value & "' AND status='PENDIENTE')-(CASE WHEN ISNULL(SUM(pagos_ventas.importe)) THEN 0 ELSE SUM(pagos_ventas.importe) END)) as total_credito FROM pagos_ventas JOIN venta ON venta.id_venta=pagos_ventas.id_venta JOIN cliente ON cliente.id_cliente=venta.id_cliente WHERE venta.status='PENDIENTE' AND pagos_ventas.status='ACTIVO' AND venta.id_cliente=" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_cliente").Value, conn)
                        If Not IsDBNull(rs.Fields("total_credito").Value) Then
                            total_credito = CDbl(rs.Fields("total_credito").Value)
                        End If
                        rs.Close()
                        'conn.close()
                        credito_actual = limite_credito - total_credito
                        If (CDbl(tb_importe.Text)) > credito_actual Then
                            btn_credito.Enabled = False
                            'btn_credito.Text = "Excede credito actual ($" & credito_actual & ")" & vbCrLf & "limite credito ($" & limite_credito & ")"
                            btn_credito.Text = "Venta a Credito"
                            credito = 0
                        Else
                            btn_credito.Enabled = True
                            'btn_credito.Text = "credito,credito actual ($" & credito_actual & ")" & vbCrLf & "limite credito ($" & limite_credito & ")"
                            btn_credito.Text = "Venta a Credito"
                            credito = 1
                        End If
                        '---------------------------------------
                    Else
                        btn_credito.Enabled = True
                        'btn_credito.Text = "sin limite de credito"
                        btn_credito.Text = "Venta a Credito"
                        credito = 1
                    End If
                Else
                    btn_credito.Enabled = False
                    btn_credito.Text = "Sin credito"
                    credito = 0
                End If
                ' preparar_currentprinticket()
                tb_pago.Select()
                tb_pago.Focus()
            Else
                bandera_cobro = False
                tb_importe.Text = "$00.00"
                tb_cambio.Text = "$00.00"
                btn_cobrar.Enabled = False
                btn_cancelar_venta.Enabled = False
                btn_credito.Enabled = False
                btn_regalias.Enabled = False
            End If
        Else
            bandera_cobro = False
            tb_importe.Text = "$00.00"
            btn_credito.Enabled = False
            btn_regalias.Enabled = False
            bandera_cobro = False
            btn_cobrar.Enabled = False
            btn_cancelar_venta.Enabled = False
        End If
    End Sub


    Private Sub tb_pago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If tb_importe.Text = "" Or tb_importe.Text = 0.0 Then
                MsgBox("introduzca el cobro")
                bandera_cobro = False
            Else
                If CDbl(tb_pago.Text) >= CDbl(tb_importe.Text) Then
                    Dim cambio As Double
                    cambio = CDbl(tb_pago.Text) - CDbl(tb_importe.Text)
                    tb_cambio.Text = FormatCurrency(cambio)
                    tb_pago.Text = FormatCurrency(tb_pago.Text)
                    bandera_cobro = True
                End If
            End If
        End If
    End Sub
    Private Sub realizar_cobro_venta()
        If CType(cb_forma_pago.SelectedItem, myItem).Value = 1 Then ' guardamos forma de pago en efectivo
pago_efectivo: If dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_retiro").Value > 0 Then
                If conf_pv(16) = 0 Then
                    Dim k As Integer
                    For k = 0 To conf_pv(5)
                        imprimir_ticket_venta(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, k, conf_pv(5))
                    Next
                End If

                'Conectar()
                Dim id_pagos_ventas As Integer = 0
                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,cobro,cambio,id_forma_pago,fecha,fecha_cobro,id_empleado_caja) VALUES " &
                                           " (" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "," & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value & "," & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value & ",'0.00' ," & CType(cb_forma_pago.SelectedItem, myItem).Value & ",NOW(),NOW(),'" & global_id_empleado & "')", , -1)
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_pagos_ventas = rs.Fields(0).Value
                rs.Close()
                conn.Execute("UPDATE venta  SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "',id_corte=0,fecha_salida_almacen=NOW()  WHERE id_venta = " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                conn.Execute("UPDATE pedido_clientes  SET status_pago = 'PAGADO',status='SUMINISTRADO' WHERE id_venta = " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                conn.Execute("DELETE FROM retiros WHERE id_retiro = " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_retiro").Value)
                'conn.close()
                'conn = Nothing

                If conf_pv(16) = 1 Then
                    If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                        Generar_Formato_venta_retail(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False)
                    ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                        Generar_Formato_venta_retail_media(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False, False)
                    ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                        Generar_Formato_venta_apartado(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                    End If
                End If

                If conf_pv(18) = 1 Then ' IMPRESION DE COMPROBANTE DE PAGO
                    For k = 0 To conf_pv(5)
                        imprimir_comprobante_pago(id_pagos_ventas, k)
                    Next
                End If


                If conf_pv(9) = 1 Then
                    If conf_pv(16) = 1 Then
                        If conf_pv_id_formato(1) = 2 Then
                            Generar_orden_entrega(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                        End If
                    Else
                        imprimir_orden_entrega(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, 0)
                    End If
                End If
            Else
                If conf_pv(16) = 0 Then
                    Dim k As Integer
                    For k = 0 To conf_pv(5)
                        imprimir_ticket_venta(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, k, conf_pv(5))
                    Next
                End If

                'Conectar()
                Dim id_pagos_ventas As Integer = 0
                conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,cobro,cambio,id_forma_pago,fecha,fecha_cobro,id_empleado_caja) VALUES " &
                                           " (" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "," & CDbl(tb_importe.Text) & "," & CDbl(tb_pago.Text) & "," & CDbl(tb_cambio.Text) & " ," & CType(cb_forma_pago.SelectedItem, myItem).Value & ",NOW(),NOW(),'" & global_id_empleado & "')", , -1)
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_pagos_ventas = rs.Fields(0).Value
                rs.Close()
                conn.Execute("UPDATE venta  SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "',id_corte=0,fecha_salida_almacen=NOW()  WHERE id_venta = " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)

                If conf_pv(16) = 1 Then

                    If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                        Generar_Formato_venta_retail(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False)
                    ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                        Generar_Formato_venta_retail_media(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False, False)
                    ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                        Generar_Formato_venta_apartado(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                    End If
                End If

                If conf_pv(18) = 1 Then ' IMPRESION DE COMPROBANTE DE PAGO
                    For k = 0 To conf_pv(5)
                        imprimir_comprobante_pago(id_pagos_ventas, k)
                    Next
                End If


                If conf_pv(9) = 1 Then
                    If conf_pv(16) = 1 Then
                        If conf_pv_id_formato(1) = 2 Then
                            Generar_orden_entrega(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                        End If
                    Else
                        imprimir_orden_entrega(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, 0)
                    End If
                End If

            End If

            frm_aviso.Temporizador.Interval = 6000
            frm_aviso.btn_ok.Visible = True
            frm_aviso.Lbl_aviso.Text = "Cambio: " & FormatCurrency(tb_cambio.Text)
            frm_aviso.TopMost = False
            frm_aviso.ShowDialog()
            bandera_cobro = False
            tb_importe.Text = "$00.00"
            tb_cambio.Text = "00.00"
            tb_pago.Text = ""
            obtener_cuentasxcobrar()
            If tabla_caja.Rows.Count = 0 Then
                Me.Close()
            End If
        ElseIf CType(cb_forma_pago.SelectedItem, myItem).Value = 4 Then 'aplica para las formas de pago con tarjeta

pago_tarjeta: If conf_pv(16) = 0 Then
                Dim k As Integer
                For k = 0 To conf_pv(5)
                    imprimir_ticket_venta(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, k, conf_pv(5))
                Next
            End If

            Dim id_pagos_ventas As Integer = 0
            conn.Execute("INSERT INTO pagos_ventas(id_venta,importe,id_forma_pago,fecha,fecha_cobro,num_autorizacion,id_empleado_caja) VALUES " &
           " (" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "," & CDbl(tb_importe.Text) & "," & CType(cb_forma_pago.SelectedItem, myItem).Value & ",NOW(),NOW(),'" & tb_referencia.Text & "','" & global_id_empleado & "')", , -1)

            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            id_pagos_ventas = rs.Fields(0).Value
            rs.Close()
            conn.Execute("UPDATE venta  SET status = 'CERRADA',id_empleado_caja='" & global_id_empleado & "',id_corte=0,fecha_salida_almacen=NOW()  WHERE id_venta = " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)


            If conf_pv(16) = 1 Then

                If conf_pv_id_formato(0) = 2 Then ' FORMATO RETAIL LETTER
                    Generar_Formato_venta_retail(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False)
                ElseIf conf_pv_id_formato(0) = 3 Then 'FORMATO A5
                    Generar_Formato_venta_retail_media(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False, False)
                ElseIf conf_pv_id_formato(0) = 4 Then 'FORMATO MK LETTER
                    Generar_Formato_venta_apartado(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                End If
            End If

            If conf_pv(18) = 1 Then ' IMPRESION DE COMPROBANTE DE PAGO
                For k = 0 To conf_pv(5)
                    imprimir_comprobante_pago(id_pagos_ventas, k)
                Next
            End If


            If conf_pv(9) = 1 Then
                If conf_pv(16) = 1 Then
                    If conf_pv_id_formato(1) = 2 Then
                        Generar_orden_entrega(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
                    End If
                Else
                    imprimir_orden_entrega(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, 0)
                End If

            End If

            bandera_cobro = False
            tb_importe.Text = "$00.00"
            tb_cambio.Text = "00.00"
            tb_pago.Text = ""
            obtener_cuentasxcobrar()
            If tabla_caja.Rows.Count = 0 Then
                Me.Close()
            End If

        ElseIf CType(cb_forma_pago.SelectedItem, myItem).Value = 18 Then
            GoTo pago_tarjeta
        Else
            GoTo pago_efectivo
        End If

    End Sub
    Private Sub btn_credito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_credito.Click
        If MsgBox("Confirme credito a  " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente").Value & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

            'Conectar()
            conn.Execute("UPDATE venta  SET status = 'PENDIENTE',id_empleado_caja='" & global_id_empleado & "',credito='1' WHERE id_venta = " & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value)
            'conn.close()

            If conf_pv(16) = 0 Then
                For x = 0 To 1
                    imprimir_ticket_credito("pagare", dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente").Value, dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("num_ticket").Value, FormatCurrency(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value), "", "", "", "", x)
                Next
            Else
                Generar_Formato_venta_retail_media(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value, False, False)
            End If

            obtener_cuentasxcobrar()
            If tabla_caja.Rows.Count = 0 Then
                Me.Close()

                frm_principal3.BringToFront()

            End If
        End If

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiempo_inactivo.Tick
        Dim inactiveTime = _inactiveTimeRetriever.GetInactiveTime
        If Not inactiveTime Is Nothing Then
            If (inactiveTime.Value.TotalMinutes > 1) Then
                obtener_cuentasxcobrar()
                If (inactiveTime.Value.TotalMinutes > cfg_tiempo_inactivo) Then
                    form_activo = False
                End If
            Else
                If dgv_pagos.RowCount = 0 Then
                    obtener_cuentasxcobrar()
                    If form_activo = False Then
                        form_activo = True
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            bandera_cobro = False
            If current_campo = 0 Then
                tb_pago.Focus()
            ElseIf current_campo = 1 Then
                tb_referencia.Focus()
            End If
            SendKeys.Send(CType(sender, Button).Text)
        End If
        bandera_cobro = False
        tb_cambio.Text = "0.00"
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        'Try
        If bandera_cobro = True Then 'esta listo para registrar el pago
                realizar_cobro_venta()
            Else
                If tb_pago.Text = "" Or tb_pago.Text = "00.0" Or tb_pago.Text = "." Then
                    MsgBox("introduzca la cantidad recibida", MsgBoxStyle.Information, "aviso")
                    bandera_cobro = False
                Else
                    If CDbl(tb_pago.Text) >= CDbl(tb_importe.Text) Then
                        If CType(cb_forma_pago.SelectedItem, myItem).Value = 1 Then ' pago en efectivo
                            Dim cambio As Double = 0
                            cambio = CDbl(tb_pago.Text) - CDbl(tb_importe.Text)
                            tb_cambio.Text = FormatCurrency(cambio)
                            tb_pago.Text = FormatCurrency(tb_pago.Text)
                            bandera_cobro = True
                        Else
                            If CDec(tb_pago.Text) <> CDec(tb_importe.Text) Then
                                MsgBox("La cantidad recibida no puede ser diferente al importe para pagos que no sean en efectivo, En caso de que desee abonar esta cantidad haga click en el boton de pago combinado ", MsgBoxStyle.Information, "aviso")
                                tb_cambio.Text = "$0.00"
                            Else
                                Dim cambio As Double = 0
                                cambio = CDbl(tb_pago.Text) - CDbl(tb_importe.Text)
                                tb_cambio.Text = FormatCurrency(cambio)
                                tb_pago.Text = FormatCurrency(tb_pago.Text)
                                bandera_cobro = True
                            End If
                        End If
                    Else
                        MsgBox("La cantidad recibida no puede ser menor al importe. En caso de que desee abonar esta cantidad haga click en el boton 'formas de pago'", MsgBoxStyle.Information, "aviso")
                        tb_cambio.Text = "$0.00"
                    End If
                End If
            End If
        'Catch ex As Exception
        'MsgBox("Error de captura,verifique que el dato sea correcto. ERROR: " & ex.Message, MsgBoxStyle.Exclamation, "Aviso")
        ' End Try

    End Sub
    Private Sub btn_cancelar_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_venta.Click
        frm_validacion.id_venta = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value
        frm_validacion.validacion = 0
        frm_validacion.ShowDialog()
    End Sub

    Private Sub tb_pago_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_pago.Click
        current_campo = 0
        tb_pago.SelectAll()
    End Sub

    Private Sub tb_pago_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_pago.KeyDown
        If e.KeyCode = 13 Then
            Button14_Click(sender, e)
        Else
            bandera_cobro = False
            tb_cambio.Text = "0.00"
        End If

    End Sub

    Private Sub tb_pago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_pago.KeyPress
        e.Handled = txtNumerico(tb_pago, e.KeyChar, True)
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If current_campo = 0 Then
            tb_pago.Text = ""
        ElseIf current_campo = 1 Then
            tb_referencia.Text = ""
        End If
        bandera_cobro = False
        tb_cambio.Text = "0.00"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If current_campo = 0 Then
            If tb_pago.TextLength > 0 Then
                tb_pago.Text = tb_pago.Text.Remove(tb_pago.TextLength - 1, 1)
                tb_pago.SelectionStart = Len(tb_pago.Text)
            End If
        ElseIf current_campo = 1 Then
            If tb_referencia.TextLength > 0 Then
                tb_referencia.Text = tb_referencia.Text.Remove(tb_referencia.TextLength - 1, 1)
                tb_referencia.SelectionStart = Len(tb_referencia.Text)
            End If
        End If

        bandera_cobro = False
        tb_cambio.Text = "0.00"
    End Sub

    Private Sub btn_corte_caja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        frm_validacion.validacion = 2
        frm_validacion.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        obtener_cuentasxcobrar()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        frm_validacion.validacion = 1
        frm_validacion.ShowDialog()
    End Sub

    Private Sub btn_regalias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_regalias.Click
        frm_validacion.id_venta = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value
        frm_validacion.validacion = 3
        frm_validacion.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub dgv_pagos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If conf_pv(0) = 1 Then
            If tabla_caja.Rows.Count > 0 Then
                frm_pago_express.pe_id_venta = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value
                frm_pago_express.pe_importe_venta = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value)
                ' frm_pago_express.pe_subtotal = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("subtotal").Value)
                'frm_pago_express.pe_total_iva = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total_iva").Value)
                'frm_pago_express.pe_total_otros = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total_otros").Value)
                frm_pago_express.pe_cliente = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente").Value
                frm_pago_express.pe_cliente_alias = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente_alias").Value
                frm_pago_express.pe_empleado = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("nombre_empleado").Value
                frm_pago_express.ShowDialog()
            End If
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cupones.Click
        If conf_pv(0) = 1 Then
            If tabla_caja.Rows.Count > 0 Then
                frm_pago_express.pe_id_venta = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value
                frm_pago_express.pe_importe_venta = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total").Value)
                'frm_pago_express.pe_subtotal = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("subtotal").Value)
                'frm_pago_express.pe_total_iva = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total_iva").Value)
                'frm_pago_express.pe_total_otros = CDec(dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("total_otros").Value)
                frm_pago_express.pe_cliente = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente").Value
                frm_pago_express.pe_cliente_alias = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("cliente_alias").Value
                frm_pago_express.pe_empleado = dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("nombre_empleado").Value
                frm_pago_express.ShowDialog()
            End If
        Else
            MsgBox("No esta configuarado el uso de cupones para esta terminal", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub
    Private Sub btn_20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_20.Click
        cargar_billete(20)
    End Sub

    Private Sub btn_50_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_50.Click
        cargar_billete(50)
    End Sub

    Private Sub btn_100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_100.Click
        cargar_billete(100)
    End Sub

    Private Sub btn_200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_200.Click
        cargar_billete(200)
    End Sub

    Private Sub btn_500_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_500.Click
        cargar_billete(500)
    End Sub

    Private Sub btn_1000_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1000.Click
        cargar_billete(1000)
    End Sub

    Private Sub btn_50c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_50c.Click
        cargar_billete(0.5)
    End Sub

    Private Sub btn_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1.Click
        cargar_billete(1)
    End Sub

    Private Sub btn_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_2.Click
        cargar_billete(2)
    End Sub

    Private Sub btn_10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_10.Click
        cargar_billete(10)
    End Sub

    Private Sub btn_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_5.Click
        cargar_billete(5)
    End Sub

    Private Sub btn_visa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tarjeta_credito.Click
        conf_pagotarjeta()
        seleccionar_catalogo("4", cb_forma_pago) 'el id de credito es 4
        lb_tarjeta.Text = "CRÉDITO"
    End Sub
    Private Sub btn_tarjeta_debito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tarjeta_debito.Click
        conf_pagotarjeta()
        seleccionar_catalogo("18", cb_forma_pago) 'el id de debito es 18
        lb_tarjeta.Text = "DÉBITO"
    End Sub

    Private Sub btn_efectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_efectivo.Click
        conf_pagoefectivo()
    End Sub

    Private Sub tb_pago_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pago.TextChanged
        'tb_cambio.Text = "0.00"
    End Sub
    Private Sub tb_referencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_referencia.Click, tb_buscar.Click
        current_campo = 1
    End Sub

    Private Sub dgv_pagos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_pagos.CellContentClick

    End Sub
    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        obtener_cuentasxcobrar(tb_buscar.Text)
    End Sub

    Private Sub tb_buscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_buscar.KeyDown
        If e.KeyCode = 13 Then
            obtener_cuentasxcobrar(tb_buscar.Text)
        End If
    End Sub

    Private Sub tb_referencia_TextChanged(sender As Object, e As EventArgs) Handles tb_referencia.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_forma_pago.SelectedIndexChanged
        If CType(cb_forma_pago.SelectedItem, myItem).Value = 4 Then
            conf_pagotarjeta()
            lb_tarjeta.Text = "CRÉDITO"
        ElseIf CType(cb_forma_pago.SelectedItem, myItem).Value = 18 Then
            conf_pagotarjeta()
            lb_tarjeta.Text = "DÉBITO"
        Else
            gb_efectivo.Enabled = True
            current_campo = 0
            gb_tarjeta.Visible = False
            btn_1.Enabled = True
            btn_2.Enabled = True
            btn_5.Enabled = True
            btn_10.Enabled = True
            btn_20.Enabled = True
            btn_50.Enabled = True
            btn_50c.Enabled = True
            btn_100.Enabled = True
            btn_200.Enabled = True
            btn_500.Enabled = True
        End If

    End Sub

    Private Sub btn_reabrir_venta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reabrir_venta.Click
        If dgv_pagos.SelectedRows.Count > 0 Then
            Dim venta_pendiente As Boolean = False
            'Conectar()
            rs.Open("SELECT id_temp_venta_detalle FROM temp_venta_detalle WHERE id_empleado='" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_empleado").Value & "'", conn)
            If rs.RecordCount > 0 Then
                venta_pendiente = True
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            If venta_pendiente = True Then
                If MsgBox("Se encontro una venta pendiente, se eliminar esa venta y se reabrira la seleccionada, ¿Desea continua?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
reabrir_venta:      'Conectar()
                    conn.Execute("DELETE FROM temp_venta_detalle WHERE id_empleado='" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_empleado").Value & "'")
                    conn.Execute("UPDATE venta SET status='REABIERTA' WHERE id_venta='" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "'")
                    rs.Open("SELECT v.id_empleado,v.id_cliente,v.desc_global_porcent,vd.id_producto,vd.descripcion,vd.unidad,vd.cantidad,vd.precio,vd.importe,vd.total_impuestos,vd.nombre_impuestos,vd.tasa_impuestos,vd.id_almacen " &
                            "FROM venta v " &
                            "JOIN venta_detalle vd ON vd.id_venta=v.id_venta  " &
                            "WHERE v.id_venta='" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "'", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF

                            conn.Execute("INSERT INTO temp_venta_detalle(id_empleado,id_producto,nombre,cantidad,precio,importe,total_impuestos,nombre_impuestos,tasa_impuestos,id_cliente,id_almacen,desc_global_porcent,id_venta) " &
                                         " VALUES('" & rs.Fields("id_empleado").Value & "','" & rs.Fields("id_producto").Value & "','" & rs.Fields("descripcion").Value & "','" & rs.Fields("cantidad").Value & "','" & rs.Fields("precio").Value & "','" & rs.Fields("importe").Value & "','" & rs.Fields("total_impuestos").Value & "','" & rs.Fields("nombre_impuestos").Value & "','" & rs.Fields("tasa_impuestos").Value & "','" & rs.Fields("id_cliente").Value & "','" & rs.Fields("id_almacen").Value & "','" & rs.Fields("desc_global_porcent").Value & "','" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "')")
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                    conn.Execute("DELETE FROM venta_detalle WHERE id_venta='" & dgv_pagos.Rows(dgv_pagos.CurrentRow.Index).Cells("id_venta").Value & "'")
                    'conn.close()
                    'conn = Nothing

                    frm_principal3.cargar_usuario_actual()
                    frm_botones_terminal.Hide()
                    frm_principal3.Show()
                    frm_principal3.BringToFront()
                    Me.Close()
                End If
            Else
                GoTo reabrir_venta
            End If
        Else
            MsgBox("Seleccione una venta de la lista", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub
End Class