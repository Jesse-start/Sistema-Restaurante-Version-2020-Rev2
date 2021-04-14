Public Class frm_pedido_programacion
    Dim id_pedido_prog As Integer = 0
    Dim id_cliente As Integer = 0
    Dim id_empleado As Integer = 0
    Dim fecha1, fecha2, fecha3, fecha_prox_entrega As New Date
    Dim nombre_periodicidad As String
    Dim cliente_descuento As Decimal = 0
    Dim i As Integer
    Dim tmp As Integer

    Dim total_productos As Integer = 0

    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim cargado As Boolean = False

    Private conn As ADODB.Connection
    Private rs As ADODB.Recordset
    Private id_periodicidad As Integer
    Private id_dia_semana As Integer
    Private id_dia_mes As Integer

    Private Sub frm_cotizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        'habilitar_menu_ventana()
        ' global_frm_cotizacion = 0
        'conn.close()
    End Sub

    Private Sub frm_cotizacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        conn = conexion()
        rs = conector()

        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        'global_frm_cotizacion = 1


        tabla = New DataTable("cotizacion")

        With tabla.Columns
            .Add(New DataColumn("partida", GetType(Integer)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Integer)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("impuesto", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("precio_venta", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))

            'Ocultos
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("id_precio", GetType(Integer)))
            .Add(New DataColumn("precio_especial", GetType(Decimal)))
            .Add(New DataColumn("id_impuesto", GetType(String)))
            .Add(New DataColumn("total_iva", GetType(String)))
            .Add(New DataColumn("total_otros", GetType(String)))
        End With

        ds = New DataSet
        ds.Tables.Add(tabla)

        With dg_cotizacion
            .DataSource = ds
            .DataMember = "cotizacion"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_producto").Visible = False
            .Columns("id_precio").Visible = False
            .Columns("precio_especial").Visible = False

            .Columns("id_impuesto").Visible = False
            .Columns("total_iva").Visible = False
            .Columns("total_otros").Visible = False

            With .Columns("partida")
                .HeaderText = "Partida"
                .Width = 45
                .ReadOnly = True
            End With
            With .Columns("imagen")
                .HeaderText = "Imagen"
                .Width = 60
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 60
                .ReadOnly = False
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 150
                .ReadOnly = True
            End With
            With .Columns("impuesto")
                .Width = 0
                .Visible = False
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unitario"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("precio_venta")
                .HeaderText = "Precio Venta"
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe Sin impuestos"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With

        Panel1.Enabled = False
        panel_precio.Visible = False
        pb_url.Visible = False

        m_guardar.Enabled = False
        m_exportar.Enabled = False
        cargado = True
    End Sub

    Public Sub cargar(Optional ByVal id As Integer = 0)
        Panel1.Enabled = True
        panel_precio.Visible = False
        id_pedido_prog = id

        ' Cliente
        tb_domicilio.Text = ""
        tb_email.Text = ""

        If id_pedido_prog > 0 Then
            rs.Open("SELECT id_pedido_prog,numero,nombre_programacion,total,subtotal,iva,otros_impuestos,id_cliente,id_empleado,intervalo,id_periodicidad,periodicidad,hora,fecha_creacion,fecha_prox_entrega,year(fecha_creacion) anio FROM pedido_prog where id_pedido_prog = " & id_pedido_prog, conn)
            id_cliente = rs.Fields("id_cliente").Value
            id_empleado = rs.Fields("id_empleado").Value
            tb_nombre_prog.Text = rs.Fields("nombre_programacion").Value
            tb_numero_programacion.Text = "PP" & rs.Fields("anio").Value & "-" & Format(CInt(rs.Fields("numero").Value), "0000")
            'tb_fecha.Value = Format(rs.Fields("fecha").Value, "dd-MM-yy")

            '   Totales
            tb_subtotal.Text = "$ " & FormatNumber(rs.Fields("subtotal").Value, 2)
            tb_iva.Text = "$ " & FormatNumber(rs.Fields("iva").Value, 2)
            tb_otros_impuestos.Text = "$ " & FormatNumber(rs.Fields("otros_impuestos").Value, 2)
            tb_total.Text = "$ " & FormatNumber(rs.Fields("total").Value, 2)
            tb_periodo.Value = rs.Fields("intervalo").Value
            nombre_periodicidad = rs.Fields("periodicidad").Value
            id_periodicidad = rs.Fields("id_periodicidad").Value
            dtp_hora.Value = rs.Fields("hora").Value
            fecha_prox_entrega = rs.Fields("fecha_prox_entrega").Value

            rs.Close()

            rs.Open("SELECT trim(Concat(p.ap_paterno,' ',p.ap_materno,' ',p.nombre)) as nombre, ep.id_puesto, ep.nombre nombre_puesto from persona p JOIN empleado e JOIN empleado_puesto ep ON e.id_puesto=ep.id_puesto AND e.id_persona=p.id_persona  WHERE e.id_empleado=" & id_empleado & " ORDER BY p.nombre", conn)
            tb_empleado.Text = rs.Fields("nombre").Value
            tb_puesto.Text = rs.Fields("nombre_puesto").Value
            rs.Close()

            m_exportar.Enabled = True


            dg_cotizacion.Columns("cantidad").ReadOnly = True
            'tb_fecha.Enabled = False
            cb_cliente.Enabled = False
            tb_nombre_prog.Enabled = False
            gp_agregar.Enabled = False
            m_guardar.Enabled = False
            gb_programacion.Enabled = False

            tabla.Clear()
            total_productos = 0

            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT pedido_prog_detalle.*, producto.thumb from pedido_prog_detalle JOIN producto ON producto.id_producto=pedido_prog_detalle.id_producto WHERE id_pedido_prog = " & id_pedido_prog, conn)
            While Not rs2.EOF
                Dim bDatos() As Byte
                Dim imagen As System.Drawing.Image
                If Not IsDBNull(rs2.Fields("thumb").Value) Then
                    bDatos = CType(rs2.Fields("thumb").Value, Byte())
                    imagen = New Bitmap(Bytes_Imagen(bDatos))
                Else
                    imagen = ventas.My.Resources._50CENTAVOS
                    'pb_producto_origen.BackgroundImageLayout
                End If
                agregar_producto(rs2.Fields("descripcion").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, rs2.Fields("impuesto").Value, rs2.Fields("precio").Value, rs2.Fields("precio").Value, imagen)

                rs2.MoveNext()
            End While
            rs2.Close()

        Else
            '---preparamos la tabla para una nueva programacion
            tabla.Clear()
            total_productos = 0

            dg_cotizacion.Columns("cantidad").ReadOnly = False
            id_cliente = 0
            id_empleado = global_id_empleado

            ' Cotizacion
            tb_nombre_prog.Text = ""
            tb_numero_programacion.Text = "PP" & Date.Today.Year & "-000X"
            'tb_fecha.Value = Date.Today

            ' Total
            tb_subtotal.Text = "$ 0.00"
            tb_iva.Text = "$ 0.00"
            tb_total.Text = "$ 0.00"
            tb_otros_impuestos.Text = "$ 0.00"

            lbl_fecha1.Text = ""
            lbl_fecha2.Text = ""
            lbl_fecha3.Text = ""

            tb_empleado.Text = global_nombre
            tb_puesto.Text = global_puesto

            m_exportar.Enabled = False
            ' tb_fecha.Enabled = True
            tb_nombre_prog.Enabled = True
            cb_cliente.Enabled = True
            m_guardar.Enabled = True
            gp_agregar.Enabled = True
            gb_programacion.Enabled = True
            '----
        End If


        Dim total_persona As Integer = 0
        Dim total_empresa As Integer = 0
        '-----Agregamos todos los clientes fisicos del sistema
        With cb_cliente
            i = 0
            tmp = 0
            .Text = ""
            .Items.Clear()
            rs.Open("SELECT c.id_cliente,if(c.id_persona IS NULL,-1,c.id_persona) id_persona,ct.descuento, trim(Concat(p.ap_paterno,' ',p.ap_materno,' ',p.nombre)) as nombre from persona p JOIN cliente c JOIN cliente_tipo ct ON c.id_persona=p.id_persona AND ct.id_tipo=c.id_tipo ORDER BY p.nombre", conn)
            While Not rs.EOF
                .Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value, 0, rs.Fields("descuento").Value))
                If id_cliente > 0 Then
                    If rs.Fields("id_cliente").Value = id_cliente Then
                        tmp = i
                    End If
                End If
                i = i + 1
                rs.MoveNext()
            End While
            total_persona = rs.RecordCount
            rs.Close()
            '------------------------------------------------
            '--agregamos todos los clientes morales del sistema
            rs.Open("SELECT c.id_cliente,if(c.id_empresa IS NULL,-1,c.id_empresa) id_empresa, ct.descuento, e.alias from empresa e JOIN cliente c JOIN cliente_tipo ct ON c.id_empresa=e.id_empresa AND ct.id_tipo=c.id_tipo ORDER BY e.alias", conn)
            While Not rs.EOF
                .Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("alias").Value, 1, rs.Fields("descuento").Value))
                If id_cliente > 0 Then
                    If rs.Fields("id_cliente").Value = id_cliente Then
                        tmp = i
                    End If
                End If
                i = i + 1
                rs.MoveNext()
            End While
            total_empresa = total_persona + rs.RecordCount
            rs.Close()
            If total_empresa > 0 Then
                If id_cliente > 0 Then
                    .SelectedIndex = tmp
                Else
                    .SelectedIndex = -1
                End If
            End If
        End With
        '------------------------
        '--agremos dias de la semana, periodicidad
        With cb_dia
            .Text = ""
            .Items.Clear()
            For x = 1 To 31
                .Items.Add(New myItem(x, "Dia " & x))
            Next
        End With
        With cb_dia_semana
            .Text = ""
            .Items.Clear()
            For x = 0 To nombre_dia_pedido.Length - 1
                .Items.Add(New myItem(x, nombre_dia_pedido(x).ToString))
            Next
        End With
        With cb_periodicidad
            .Text = ""
            .Items.Clear()
            For x = 1 To periodicidad.Length - 1
                .Items.Add(New myItem(x, periodicidad(x).ToString))
            Next
        End With
        If id_cliente > 0 Then
            cb_periodicidad.Text = nombre_periodicidad

            If id_periodicidad <> 3 Then
                cb_dia_semana.Text = nombre_dia_pedido(fecha_prox_entrega.DayOfWeek).ToString
            Else
                cb_dia.Text = "Dia " & fecha_prox_entrega.Day
            End If
        End If
        tb_codigo.Focus()
    End Sub

    Private Sub agregar_producto(ByVal descripcion As String, ByVal cantidad As Integer, ByVal unidad As String, ByVal impuesto As String, ByVal precio As Decimal, ByVal precio_venta As Decimal, ByVal imagen As Object)
        total_productos = total_productos + 1
        tabla_linea = tabla.NewRow()
        tabla_linea("partida") = total_productos
        tabla_linea("imagen") = imagen
        tabla_linea("descripcion") = descripcion
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("impuesto") = impuesto
        tabla_linea("precio") = precio
        tabla_linea("precio_venta") = precio_venta
        tabla_linea("importe") = precio_venta * cantidad
        tabla.Rows.Add(tabla_linea)
    End Sub

    Public Sub agregar_producto(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Integer = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If

            If foundRows(0).Item("precio_especial") = 0 Then
                rs.Open("select descuento from producto_volumen WHERE " & foundRows(0).Item("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
                If rs.RecordCount > 0 Then
                    descuento = rs.Fields("descuento").Value
                End If

                rs.Close()

                If descuento > 0 Then
                    descuento = (CDec(foundRows(0).Item("precio")) * descuento) / 100
                End If

            End If

            foundRows(0).Item("precio_venta") = CDec(foundRows(0).Item("precio")) - descuento
            foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio_venta")), 2)

            dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("precio_venta").Index, dg_cotizacion.CurrentRow.Index)
            dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("importe").Index, dg_cotizacion.CurrentRow.Index)

        Else
            rs.Open("SELECT DISTINCT p.id_producto, p.nombre, p.descripcion,p.thumb, u.nombre unidad, pp.id_precio, pp.precio, ps.precio_especial_termino, ps.precio_especial_inicio, ps.precio_especial " & _
                    "FROM producto p, unidad u,producto_precio pp, producto_sucursal ps " & _
                    "WHERE(ps.id_precio = pp.id_precio) " & _
                    "AND pp.id_producto = p.id_producto " & _
                    "AND p.id_unidad=u.id_unidad AND p.id_producto=" & id, conn)

            total_productos = total_productos + 1

            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id
            tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = rs.Fields("nombre").Value & vbCrLf & rs.Fields("descripcion").Value

            Dim bDatos() As Byte
            If Not IsDBNull(rs.Fields("thumb").Value) Then
                bDatos = CType(rs.Fields("thumb").Value, Byte())
                tabla_linea("imagen") = New Bitmap(Bytes_Imagen(bDatos))
            Else
                tabla_linea("imagen") = ventas.My.Resources._50CENTAVOS
            End If

            If cantidad > 0 Then
                tabla_linea("cantidad") = cantidad
            Else
                tabla_linea("cantidad") = 1
            End If

            tabla_linea("unidad") = rs.Fields("unidad").Value
            tabla_linea("id_precio") = rs.Fields("id_precio").Value
            tabla_linea("precio") = rs.Fields("precio").Value

            If rs.Fields("precio_especial").Value > 0 Then
                If Date.Today >= CType(rs.Fields("precio_especial_inicio").Value, Date) And Date.Today <= CType(rs.Fields("precio_especial_termino").Value, Date) Then
                    tabla_linea("precio_especial") = rs.Fields("precio_especial").Value
                    tabla_linea("precio") = rs.Fields("precio_especial").Value
                Else
                    tabla_linea("precio_especial") = 0
                End If
            Else
                tabla_linea("precio_especial") = 0
            End If

            rs.Close()
            '--"AGREGAR IMPUESTOS"-------------------------
            tabla_linea("impuesto") = ""
            rs.Open("SELECT i.id_impuesto,i.alias,i.porcentaje from categoria_cat_imp cci JOIN producto p JOIN impuesto i " & _
                    "WHERE i.id_catalogo=cci.id_catalogo AND cci.id_categoria = p.id_categoria AND p.id_producto = " & id & " AND i.fecha_baja IS NULL " & _
                    "UNION SELECT i.id_impuesto,i.alias,i.porcentaje FROM producto p JOIN producto_cat_imp pci JOIN impuesto i " & _
                    "WHERE p.id_producto=pci.id_producto AND pci.id_catalogo = i.id_catalogo AND p.id_producto = " & id & " AND i.fecha_baja IS NULL", conn)
            Dim aux As String = ""
            Dim total_otros As Decimal = 0
            Dim total_iva As Decimal = 0
            i = 0
            While Not rs.EOF
                If i = 0 Then
                    tabla_linea("impuesto") &= rs.Fields("alias").Value & "(" & rs.Fields("porcentaje").Value & ")"
                    aux = rs.Fields("id_impuesto").Value
                Else
                    tabla_linea("impuesto") &= ", " & rs.Fields("alias").Value & "(" & rs.Fields("porcentaje").Value & ")"
                    aux &= "," & rs.Fields("id_impuesto").Value
                End If

                If rs.Fields("alias").Value = "IVA" Then
                    total_iva += rs.Fields("porcentaje").Value
                Else
                    total_otros += rs.Fields("porcentaje").Value
                End If

                rs.MoveNext()
                i += 1
            End While

            tabla_linea("id_impuesto") = aux
            tabla_linea("total_iva") = total_iva
            tabla_linea("total_otros") = total_otros
            rs.Close()
            '-----FIN "AGREGAR IMPUESTOS"

            rs.Open("select descuento from producto_volumen WHERE " & tabla_linea("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
            If rs.RecordCount > 0 Then
                descuento = rs.Fields("descuento").Value
            End If
            rs.Close()

            If descuento > 0 Then
                descuento = (tabla_linea("precio") * descuento) / 100
            End If

            tabla_linea("precio_venta") = tabla_linea("precio") - descuento
            tabla_linea("importe") = tabla_linea("precio_venta") * tabla_linea("cantidad")

            tabla.Rows.Add(tabla_linea)
        End If
        actualizar_totales()
    End Sub

    Private Sub actualizar_partida()
        Dim j As Integer

        For j = 0 To dg_cotizacion.RowCount - 1
            dg_cotizacion.Rows(j).Cells("partida").Value = j + 1
            total_productos = j + 1
        Next
    End Sub
    Private Sub actualizar_totales()
        Dim j As Integer

        Dim subtotal As Decimal = 0

        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0

        For j = 0 To dg_cotizacion.RowCount - 1
            subtotal = subtotal + CDec(dg_cotizacion.Rows(j).Cells("importe").Value)

            If CDec(dg_cotizacion.Rows(j).Cells("total_iva").Value) > 0 Then
                total_iva += (CDec(dg_cotizacion.Rows(j).Cells("importe").Value) * CDec(dg_cotizacion.Rows(j).Cells("total_iva").Value)) / 100
            End If

            If CDec(dg_cotizacion.Rows(j).Cells("total_iva").Value) > 0 Then
                total_otros += (CDec(dg_cotizacion.Rows(j).Cells("importe").Value) * CDec(dg_cotizacion.Rows(j).Cells("total_otros").Value)) / 100
            End If

        Next
        tb_subtotal.Text = "$ " & FormatNumber(subtotal, 2)
        tb_otros_impuestos.Text = "$ " & FormatNumber(total_otros, 2)
        tb_iva.Text = "$ " & FormatNumber(total_iva, 2)
        tb_total.Text = "$ " & FormatNumber(subtotal + total_otros + total_iva, 2)
    End Sub

    Private Sub cb_cliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cliente.SelectedIndexChanged
        If cb_cliente.SelectedIndex >= 0 Then
            id_cliente = CType(cb_cliente.SelectedItem, myItem).Value
            cliente_descuento = CType(cb_cliente.SelectedItem, myItem).Opcional2

            If CType(cb_cliente.SelectedItem, myItem).Opcional = 0 Then
                rs.Open("SELECT p.email, concat(d.calle,' ',if(d.cp='','',concat(' C.P. ',d.cp)) ) domicilio FROM cliente c, domicilio d, persona p WHERE p.id_persona=c.id_persona AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                lb_email.Text = "Email:"
                tb_email.Text = rs.Fields("email").Value
                rs.Close()
                pb_url.Visible = False
                With cb_telefono
                    .Items.Clear()
                    .Text = ""
                    rs.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, persona_tel pt,telefono t WHERE t.id_telefono=pt.id_telefono AND pt.id_persona=c.id_persona AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            cb_telefono.Items.Add(rs.Fields("telefono").Value)
                            rs.MoveNext()
                        End While
                        cb_telefono.Enabled = True
                        cb_telefono.DropDownStyle = ComboBoxStyle.DropDownList
                        .SelectedIndex = 0
                    Else
                        cb_telefono.Enabled = False
                    End If
                    rs.Close()
                End With
            ElseIf CType(cb_cliente.SelectedItem, myItem).Opcional = 1 Then
                rs.Open("SELECT e.url, concat(d.calle,' ',if(d.cp='','',concat(' C.P. ',d.cp)) ) domicilio FROM cliente c, domicilio d, empresa e WHERE e.id_empresa=c.id_empresa AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                lb_email.Text = "U r l:"
                tb_email.Text = rs.Fields("url").Value
                rs.Close()
                pb_url.Visible = True

                With cb_telefono
                    .Items.Clear()
                    .Text = ""
                    rs.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, empresa_tel et,telefono t WHERE t.id_telefono=et.id_telefono AND et.id_empresa=c.id_empresa AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            cb_telefono.Items.Add(rs.Fields("telefono").Value)
                            rs.MoveNext()
                        End While
                        cb_telefono.Enabled = True
                        cb_telefono.DropDownStyle = ComboBoxStyle.DropDownList
                        .SelectedIndex = 0
                    Else
                        cb_telefono.Enabled = False
                    End If
                    rs.Close()
                End With
            End If
            If id_pedido_prog = 0 Then
                '---cargamos los productos del cliente
                tabla.Clear()
                total_productos = 0
                ''Conectar()
                Dim rs2 = New ADODB.Recordset
                rs2.Open("SELECT * from cliente_productos WHERE id_cliente = " & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                If rs2.RecordCount > 0 Then
                    While Not rs2.EOF
                        agregar_producto_cliente(rs2.Fields("id_producto").Value, rs2.Fields("cantidad").Value)
                        rs2.MoveNext()
                    End While
                End If

                rs2.Close()
                ''conn.close()
                '-------------------------------------
            End If

        End If
    End Sub
    Public Sub agregar_producto_cliente(ByVal id As Integer, ByVal cantidad_producto As Double, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Integer = 0, Optional ByVal precio As Double = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0
        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If

            If foundRows(0).Item("precio_especial") = 0 Then
                rs.Open("select descuento from producto_volumen WHERE " & foundRows(0).Item("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
                descuento = rs.Fields("descuento").Value
                rs.Close()

                If descuento > 0 Then
                    descuento = (CDec(foundRows(0).Item("precio")) * descuento) / 100
                End If

            End If

            foundRows(0).Item("precio_venta") = CDec(foundRows(0).Item("precio")) - descuento
            foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio_venta")), 2)

            dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("precio_venta").Index, dg_cotizacion.CurrentRow.Index)
            dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("importe").Index, dg_cotizacion.CurrentRow.Index)

        Else
            rs.Open("SELECT DISTINCT p.id_producto, p.nombre, p.descripcion,p.thumb, u.nombre unidad, pp.id_precio, pp.precio, ps.precio_especial_termino, ps.precio_especial_inicio, ps.precio_especial " & _
                    "FROM producto p, unidad u,producto_precio pp, producto_sucursal ps " & _
                    "WHERE(ps.id_precio = pp.id_precio) " & _
                    "AND pp.id_producto = p.id_producto " & _
                    "AND p.id_unidad=u.id_unidad AND p.id_producto=" & id, conn)

            total_productos = total_productos + 1

            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id
            tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = rs.Fields("nombre").Value & vbCrLf & rs.Fields("descripcion").Value
            Dim imagen, miniatura As System.Drawing.Image
            Dim bDatos() As Byte
            If Not IsDBNull(rs.Fields("thumb").Value) Then
                bDatos = CType(rs.Fields("thumb").Value, Byte())
                imagen = New Bitmap(Bytes_Imagen(bDatos))
            Else
                imagen = ventas.My.Resources._50CENTAVOS
            End If
            miniatura = imagen.GetThumbnailImage(30, 30, Nothing, New IntPtr)

            tabla_linea("imagen") = imagen

            'If cantidad > 0 Then
            tabla_linea("cantidad") = cantidad_producto
            'Else
            'tabla_linea("cantidad") = 1
            'End If

            tabla_linea("unidad") = rs.Fields("unidad").Value
            tabla_linea("id_precio") = rs.Fields("id_precio").Value
            tabla_linea("precio") = rs.Fields("precio").Value

            If rs.Fields("precio_especial").Value > 0 Then
                If Date.Today >= CType(rs.Fields("precio_especial_inicio").Value, Date) And Date.Today <= CType(rs.Fields("precio_especial_termino").Value, Date) Then
                    tabla_linea("precio_especial") = rs.Fields("precio_especial").Value
                    tabla_linea("precio") = rs.Fields("precio_especial").Value
                Else
                    tabla_linea("precio_especial") = 0
                End If
            Else
                tabla_linea("precio_especial") = 0
            End If

            rs.Close()
            '--"AGREGAR IMPUESTOS"-------------------------
            tabla_linea("impuesto") = ""
            rs.Open("SELECT i.id_impuesto,i.alias,i.porcentaje from categoria_cat_imp cci JOIN producto p JOIN impuesto i " & _
                    "WHERE i.id_catalogo=cci.id_catalogo AND cci.id_categoria = p.id_categoria AND p.id_producto = " & id & " AND i.fecha_baja IS NULL " & _
                    "UNION SELECT i.id_impuesto,i.alias,i.porcentaje FROM producto p JOIN producto_cat_imp pci JOIN impuesto i " & _
                    "WHERE p.id_producto=pci.id_producto AND pci.id_catalogo = i.id_catalogo AND p.id_producto = " & id & " AND i.fecha_baja IS NULL", conn)
            Dim aux As String = ""
            Dim total_otros As Decimal = 0
            Dim total_iva As Decimal = 0
            i = 0
            While Not rs.EOF
                If i = 0 Then
                    tabla_linea("impuesto") &= rs.Fields("alias").Value & "(" & rs.Fields("porcentaje").Value & ")"
                    aux = rs.Fields("id_impuesto").Value
                Else
                    tabla_linea("impuesto") &= ", " & rs.Fields("alias").Value & "(" & rs.Fields("porcentaje").Value & ")"
                    aux &= "," & rs.Fields("id_impuesto").Value
                End If

                If rs.Fields("alias").Value = "IVA" Then
                    total_iva += rs.Fields("porcentaje").Value
                Else
                    total_otros += rs.Fields("porcentaje").Value
                End If

                rs.MoveNext()
                i += 1
            End While

            tabla_linea("id_impuesto") = aux
            tabla_linea("total_iva") = total_iva
            tabla_linea("total_otros") = total_otros
            rs.Close()
            '-----FIN "AGREGAR IMPUESTOS"

            rs.Open("select descuento from producto_volumen WHERE " & tabla_linea("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
            If rs.RecordCount > 0 Then
                descuento = rs.Fields("descuento").Value
            End If
            rs.Close()

            If descuento > 0 Then
                descuento = (tabla_linea("precio") * descuento) / 100
            End If

            tabla_linea("precio_venta") = tabla_linea("precio") - descuento
            tabla_linea("importe") = tabla_linea("precio_venta") * tabla_linea("cantidad")

            tabla.Rows.Add(tabla_linea)
        End If
        actualizar_totales()
    End Sub

    Private Sub pb_url_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_url.Click
        If Trim(tb_email.Text) <> "" Then
            Try
                System.Diagnostics.Process.Start(tb_email.Text)
            Catch ex As Exception
                Try
                    System.Diagnostics.Process.Start("http://" & tb_email.Text)
                Catch ex2 As Exception
                End Try
            End Try
        End If
    End Sub
    Private Sub cb_cliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_cliente.TextChanged
        tb_domicilio.Text = ""
        tb_email.Text = ""
        cb_telefono.Text = ""
        cb_telefono.Items.Clear()
        cb_telefono.Enabled = False
    End Sub

    Private Sub m_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_nuevo.Click
        cargar()
    End Sub

    Private Sub m_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_abrir.Click
        '   global_frm_producto_abrir = 1
        '  frm_cotizacion_abrir.ShowDialog()
    End Sub

    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bucar.Click
        global_frm_producto_abrir = 6
        frm_producto_abrir.ShowDialog()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Trim(tb_codigo.Text) <> "" Then
            rs.Open("select id_producto from producto WHERE codigo='" & Trim(tb_codigo.Text) & "'")
            If rs.RecordCount > 0 Then
                Dim id_producto As Integer = rs.Fields("id_producto").Value
                rs.Close()
                tb_codigo.Text = ""
                agregar_producto(id_producto)
                If total_productos > 0 Then
                    m_guardar.Enabled = True
                End If
            Else
                rs.Close()
                tb_codigo.Text = ""
                MsgBox("Codigo del Producto no encontrado", MsgBoxStyle.Information)
            End If
        End If
        tb_codigo.Focus()
    End Sub

    Private Sub tb_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_codigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_agregar_Click(sender, e)
        End If
    End Sub

    Private Sub dg_cotizacion_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellEndEdit
        dg_cotizacion_CellValueChanged(sender, e)
    End Sub
    Private Sub dg_cotizacion_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dg_cotizacion.CellValidating
        If id_pedido_prog = 0 Then
            Dim newInteger As Integer
            If dg_cotizacion.Rows(e.RowIndex).IsNewRow Then Return
            If dg_cotizacion.Columns("cantidad").Index = e.ColumnIndex Then
                If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger <= 0 Then
                    e.Cancel = True
                    MsgBox("Solo se permiten valores enteros mayores a 0", MsgBoxStyle.Information, "Error en el tipo de dato")
                    'dg_cotizacion.Rows(e.RowIndex).ErrorText = "Solo se permiten valores enteros mayores a 0"
                End If
            End If
        Else
            'e.Cancel = True
        End If
    End Sub
    Private Sub dg_cotizacion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellValueChanged
        If cargado Then
            agregar_producto(dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_producto").Value, True)
        End If
    End Sub
    Private Sub dg_cotizacion_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellLeave
        If dg_cotizacion.Rows.Count > 0 Then
            If dg_cotizacion.CurrentCell.ColumnIndex = dg_cotizacion.Columns("precio").Index Then
                panel_precio.Visible = False
            End If
        End If
    End Sub

    Private Sub dg_cotizacion_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellEnter
        If id_pedido_prog = 0 Then
            If dg_cotizacion.Rows.Count > 0 Then
                If dg_cotizacion.CurrentCell.ColumnIndex = dg_cotizacion.Columns("precio").Index Then
                    cargar_precios(dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_producto").Value, dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_precio").Value, dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("precio_especial").Value)
                    panel_precio.Visible = True
                Else
                    panel_precio.Visible = False
                End If
            End If
        End If
    End Sub
    Private Sub dg_cotizacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellDoubleClick
        If id_pedido_prog = 0 Then
            If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                dg_cotizacion.Rows.RemoveAt(dg_cotizacion.CurrentRow.Index)
                If dg_cotizacion.Rows.Count = 0 Then
                    total_productos = 0
                    m_guardar.Enabled = False
                End If
                panel_precio.Visible = False
                actualizar_partida()
                actualizar_totales()
            End If
        End If
    End Sub
    Private Sub cargar_precios(ByVal id As Integer, ByVal id_precio As Integer, ByVal especial As Decimal)
        If especial > 0 Then
            panel_precio_especial.Visible = True
            panel_lista_precio.Visible = False
            tb_precio_especial.Text = "$ " & FormatNumber(especial, 2)
        Else
            panel_lista_precio.Visible = True
            panel_precio_especial.Visible = False

            With cb_precio
                .Items.Clear()
                .Text = ""
                i = 0
                tmp = 0

                rs = New ADODB.Recordset
                rs.Open("SELECT id_precio,precio from producto_precio WHERE id_producto = " & id, conn)
                While Not rs.EOF
                    .Items.Add(New myItem(rs.Fields("id_precio").Value, rs.Fields("precio").Value))
                    If rs.Fields("id_precio").Value = id_precio Then
                        tmp = i
                    End If
                    i = i + 1
                    rs.MoveNext()
                End While
                If rs.RecordCount > 0 Then
                    rs.Close()
                    .SelectedIndex = tmp
                Else
                    rs.Close()
                End If
            End With
        End If
    End Sub
    Private Sub cb_precio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_precio.SelectedIndexChanged
        If CType(cb_precio.SelectedItem, myItem).Value <> dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_precio").Value Then
            dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_precio").Value = CType(cb_precio.SelectedItem, myItem).Value
            dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("precio").Value = CType(cb_precio.SelectedItem, myItem).Text
            agregar_producto(dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_producto").Value, True)
        End If
    End Sub
    

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_guardar.Click
        Dim numero As Integer

        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        'Try
        If Trim(tb_nombre_prog.Text) = "" Then
            cadena = cadena & "   Nombre de la programación" & vbCrLf
            bandera_correcto = False
        End If
        If cb_periodicidad.SelectedIndex = -1 Then
            cadena = cadena & "   Periodicidad" & vbCrLf
            bandera_correcto = False
        End If
        If cb_dia_semana.SelectedIndex = -1 Then
            If cb_dia.SelectedIndex = -1 Then
                cadena = cadena & "   Dia de inicio" & vbCrLf
                bandera_correcto = False
            End If
        End If
        If cb_cliente.SelectedIndex = -1 Then
            cadena = cadena & "   Cliente" & vbCrLf
            bandera_correcto = False
        End If
        If tabla.Rows.Count = 0 Then
            cadena = cadena & "     Productos" & vbCrLf
            bandera_correcto = False
        End If
        If bandera_correcto = True Then
            Try
                conn.BeginTrans()
                rs.Open("SELECT IF(MAX(numero) IS NULL,1,MAX(numero)+1) numero from pedido_prog", conn)
                numero = rs.Fields("numero").Value
                rs.Close()
                ''  Dim fecha_entrega As String
                ''fecha_entrega = Format(fecha1, "yyyy-MM-dd") & " " & dtp_hora.Value
                Dim fecha_entrega As String
                fecha_entrega = Format(fecha1, "yyyy-MM-dd") & " " & Format(dtp_hora.Value, "HH:mm:ss")

                conn.Execute("INSERT INTO pedido_prog (numero,nombre_programacion,id_empleado,id_cliente,id_sucursal,intervalo,id_periodicidad,periodicidad,hora,fecha_creacion,fecha_prox_entrega,subtotal,iva,otros_impuestos,total) VALUES " & _
                             " ('" & numero & "','" & tb_nombre_prog.Text & "','" & id_empleado & "','" & id_cliente & "','" & global_id_sucursal & "','" & tb_periodo.Value & "','" & CType(cb_periodicidad.SelectedItem, myItem).Value & "','" & cb_periodicidad.Text & "','" & Format(dtp_hora.Value, "HH:mm:ss") & "',NOW(),'" & fecha_entrega & "','" & CDec(tb_subtotal.Text) & "','" & CDec(tb_iva.Text) & "','" & CDec(tb_otros_impuestos.Text) & "','" & CDec(tb_total.Text) & "')")

                rs.Open("SELECT last_insert_id() id_pedido_prog", conn)
                id_pedido_prog = rs.Fields("id_pedido_prog").Value
                rs.Close()

                For row = 0 To tabla.Rows.Count - 1
                    conn.Execute("INSERT INTO pedido_prog_detalle (id_pedido_prog,id_producto,descripcion,cantidad,unidad,precio,impuesto) VALUES" & _
                                 " (" & id_pedido_prog & "," & dg_cotizacion.Item("id_producto", row).Value & ",'" & dg_cotizacion.Item("descripcion", row).Value & "'," & dg_cotizacion.Item("cantidad", row).Value & ",'" & dg_cotizacion.Item("unidad", row).Value & "','" & CDec(dg_cotizacion.Item("precio", row).Value) & "','" & dg_cotizacion.Item("impuesto", row).Value & "')")

                    'Dim id_detalle As Integer

                    'rs.Open("SELECT last_insert_id() id_detalle", conn)
                    'id_detalle = rs.Fields("id_detalle").Value
                    'rs.Close()

                    'Dim tmp As String() = Split(dg_cotizacion.Item("id_impuesto", row).Value, ",")
                    'For p = 0 To tmp.Length - 1
                    'If tmp(p) <> "" Then
                    'conn.Execute("INSERT INTO cotizacion_detalle_impuesto (id_detalle,id_impuesto) VALUES" & _
                    '         " (" & id_detalle & "," & tmp(p) & ")")
                    'End If
                    'Next
                Next

                tb_numero_programacion.Text = "PP" & Date.Today.Year & "-" & Format(numero, "0000")

                m_guardar.Enabled = False
                m_exportar.Enabled = True

                cargar(id_pedido_prog)

                conn.CommitTrans()
                MsgBox("La programacion se ha generado con el Número " & vbCrLf & tb_numero_programacion.Text, MsgBoxStyle.Information, "Confirmacion Programación de Pedido")

            Catch ex As Exception
                MsgBox(ex.Message)
                conn.RollbackTrans()
            End Try
        Else
            MsgBox(cadena)
        End If







    End Sub
    Private Sub frm_cotizacion_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If cargado Then
            If Me.Width > 1100 Then
                dg_cotizacion.Columns("descripcion").Width = 40 + Me.Width - 900
            Else
                dg_cotizacion.Columns("descripcion").Width = 250
            End If
        End If
    End Sub

    Private Sub cb_periodicidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_periodicidad.SelectedIndexChanged
        If cb_periodicidad.SelectedIndex <> -1 Then
            id_periodicidad = CType(cb_periodicidad.SelectedItem, myItem).Value
            If id_periodicidad = 1 Then
                cb_dia.Enabled = False
                cb_dia.SelectedIndex = -1
                cb_dia.Text = ""
                cb_dia_semana.Enabled = True
            ElseIf id_periodicidad = 2 Then
                cb_dia.Enabled = False
                cb_dia.SelectedIndex = -1
                cb_dia.Text = ""
                cb_dia_semana.Enabled = True
            ElseIf id_periodicidad = 3 Then
                cb_dia.Enabled = True
                cb_dia_semana.SelectedIndex = -1
                cb_dia_semana.Text = ""
                cb_dia_semana.Enabled = False
            End If
            calcular_fechas()
        End If
    End Sub
  
    Private Sub calcular_fechas()
        If cb_periodicidad.SelectedIndex <> -1 Then
            If cb_dia_semana.SelectedIndex <> -1 Then
                id_dia_semana = CType(cb_dia_semana.SelectedItem, myItem).Value
                If id_periodicidad = 1 Then
                    '--calculo de fechas
                    fecha1 = Today.ToShortDateString
                    If Not fecha1.DayOfWeek = id_dia_semana Then
                        For x = 1 To 7
                            If Not fecha1.DayOfWeek = id_dia_semana Then
                                fecha1 = Today.AddDays(x)
                            End If
                        Next
                    End If
                    fecha2 = fecha1.AddDays(tb_periodo.Value)
                    fecha3 = fecha2.AddDays(tb_periodo.Value)
                    '-----

                ElseIf id_periodicidad = 2 Then
                    '--calculo de fechas
                    fecha1 = Today.ToShortDateString
                    If Not fecha1.DayOfWeek = id_dia_semana Then
                        For x = 1 To 7
                            If Not fecha1.DayOfWeek = id_dia_semana Then
                                fecha1 = Today.AddDays(x)
                            Else
                                Exit For
                            End If
                        Next
                    End If
                    fecha2 = fecha1.AddDays(7 * tb_periodo.Value)
                    fecha3 = fecha2.AddDays(7 * tb_periodo.Value)
                    '-----
                End If

                lbl_fecha1.Text = "1.- " & fecha1.ToLongDateString
                lbl_fecha2.Text = "2.- " & fecha2.ToLongDateString
                lbl_fecha3.Text = "3.- " & fecha3.ToLongDateString

            End If
            If cb_dia.SelectedIndex <> -1 Then
                id_dia_mes = CType(cb_dia.SelectedItem, myItem).Value
                If id_periodicidad = 3 Then
                    fecha1 = Today.ToShortDateString
                    If Not fecha1.Day = id_dia_mes Then
                        For x = 1 To 31
                            If Not fecha1.Day = id_dia_mes Then
                                fecha1 = Today.AddDays(x)
                            Else
                                Exit For
                            End If
                        Next
                    End If
                    fecha2 = fecha1.AddMonths(tb_periodo.Value)
                    fecha3 = fecha2.AddMonths(tb_periodo.Value)
                    lbl_fecha1.Text = "1.- " & fecha1.ToLongDateString
                    lbl_fecha2.Text = "2.- " & fecha2.ToLongDateString
                    lbl_fecha3.Text = "3.- " & fecha3.ToLongDateString
                End If
            End If
        End If

    End Sub

    Private Sub cb_dia_semana_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_dia_semana.SelectedIndexChanged
        calcular_fechas()
    End Sub

    Private Sub cb_dia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_dia.SelectedIndexChanged
        calcular_fechas()
    End Sub

    Private Sub tb_periodo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_periodo.ValueChanged
        calcular_fechas()
    End Sub
End Class