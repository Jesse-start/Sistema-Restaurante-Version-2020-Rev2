Public Class frm_facturacion

    Dim id_factura As Integer = 0
    Dim id_cliente As Integer = 0
    Dim id_empleado As Integer = 0
    Dim id_catalogo_precio As Integer = 0
    Dim aplicar_redondeo As Boolean = False
    Dim cliente_descuento As Decimal = 0
    Dim i As Integer
    Dim tmp As Integer

    Dim total_productos As Integer = 0

    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim cargado As Boolean = False
    Dim suma_subtotal As Decimal
    Dim suma_iva As Decimal
    Dim suma_otros As Decimal
    Dim factura(19, 2) As String
    Dim factura_productos(100, 7) As String
    Dim tickes_facturas(100, 1) As Object
    Dim index_matrix_tickets As Integer = 0
    Dim index_inicio As Integer = 0
    Dim num_lineas As Integer = 0
    Public Sub limpiar_tickets_factura()
        For x = 0 To 100
            For j = 0 To 1
                tickes_facturas(x, j) = Nothing
            Next
        Next
    End Sub

    Public Sub limpiar_factura()
        For x = 0 To 19
            For j = 0 To 2
                factura(x, j) = Nothing
            Next
        Next
    End Sub
    Public Sub limpiar_factura_productos()
        For x = 0 To 20
            For j = 0 To 7
                factura_productos(x, j) = Nothing
            Next
        Next
    End Sub

    Private Sub frm_factura_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
        ' habilitar_menu_ventana()
        global_frm_factura = 0
        If global_frm_cuentasxcobrar = 1 Then
            frm_cuentas_xcobrar.cargar_clientes("")
        End If

    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Panel7.BackColor = Color.FromArgb(conf_colores(1))
        FlowLayoutPanel1.BackColor = Color.FromArgb(conf_colores(1))

        'gbRecepcion.ForeColor = Color.FromArgb(conf_colores(2))
       
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox2.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox3.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox4.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox5.ForeColor = Color.FromArgb(conf_colores(2))

        'lblFacturaProveedor.ForeColor = Color.FromArgb(conf_colores(13))
 
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label10.ForeColor = Color.FromArgb(conf_colores(13))
        Label11.ForeColor = Color.FromArgb(conf_colores(13))
        Label12.ForeColor = Color.FromArgb(conf_colores(13))
        Label13.ForeColor = Color.FromArgb(conf_colores(13))
        Label15.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
       
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label6.ForeColor = Color.FromArgb(conf_colores(13))
        Label7.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        Label9.ForeColor = Color.FromArgb(conf_colores(13))

    End Sub
    Private Sub frm_factura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        suma_subtotal = 0
        suma_iva = 0
        suma_otros = 0

        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        global_frm_factura = 1


        tabla = New DataTable("factura")

        With tabla.Columns
            .Add(New DataColumn("partida", GetType(Integer)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
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

        With dg_factura
            .DataSource = ds
            .DataMember = "factura"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_producto").Visible = False
            .Columns("id_precio").Visible = False
            .Columns("precio_especial").Visible = False

            .Columns("id_impuesto").Visible = False
            '.Columns("total_iva").Visible = False
            '.Columns("total_otros").Visible = False
            .Columns("precio_venta").Visible = False
            With .Columns("total_iva")
                .HeaderText = "iva"
                .Width = 45
                .ReadOnly = True
            End With
            With .Columns("total_otros")
                .HeaderText = "otros"
                .Width = 45
                .ReadOnly = True
            End With

            With .Columns("partida")
                .HeaderText = "Partida"
                .Width = 45
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
                .Width = 200
                .ReadOnly = True
            End With
            With .Columns("impuesto")
                .HeaderText = "Impuestos"
                .Width = 70
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unitario"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = False
            End With
            'With .Columns("precio_venta")
            '.HeaderText = "Precio Venta"
            ' .Width = 100
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .DefaultCellStyle.Format = "c"
            ' .ReadOnly = True
            ' End With
            With .Columns("importe")
                .HeaderText = "Importe Sin impuestos"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With

        Panel1.Enabled = False
        pb_url.Visible = False
        m_guardar.Enabled = False
        m_exportar.Enabled = False
        cargar()
        cargado = True

    End Sub

    Public Sub cargar_cotizacion(Optional ByVal id As Integer = 0)
        Panel1.Enabled = True
        id_factura = id

        ' Cliente
        tb_domicilio.Text = ""
        tb_email.Text = ""
        'Conectar()
        rs.Open("SELECT id_cotizacion,numero,total,subtotal,iva,otros,id_cliente,id_empleado,fecha,year(fecha) anio FROM cotizacion where id_cotizacion = " & id_factura, conn)
        id_cliente = rs.Fields("id_cliente").Value
        id_empleado = rs.Fields("id_empleado").Value
        tb_numero_factura.Text = "FT" & rs.Fields("anio").Value & "-" & Format(CInt(rs.Fields("numero").Value), "0000")
        tb_fecha.Value = Format(rs.Fields("fecha").Value, "yyyy-MM-dd")

        '   Totales
        tb_subtotal.Text = "$ " & FormatNumber(rs.Fields("subtotal").Value, 2)
        tb_iva.Text = "$ " & FormatNumber(rs.Fields("iva").Value, 2)
        tb_otros_impuestos.Text = "$ " & FormatNumber(rs.Fields("otros").Value, 2)
        tb_total.Text = "$ " & FormatNumber(rs.Fields("total").Value, 2)
        rs.Close()

        rs.Open("SELECT trim(Concat(p.ap_paterno,' ',p.ap_materno,' ',p.nombre)) as nombre, ep.id_puesto, ep.nombre nombre_puesto from persona p JOIN empleado e JOIN empleado_puesto ep ON e.id_puesto=ep.id_puesto AND e.id_persona=p.id_persona  WHERE e.id_empleado=" & id_empleado & " ORDER BY p.nombre", conn)
        tb_empleado.Text = rs.Fields("nombre").Value
        tb_puesto.Text = rs.Fields("nombre_puesto").Value
        rs.Close()

        m_exportar.Enabled = True

        dg_factura.Columns("cantidad").ReadOnly = True
        tb_fecha.Enabled = False
        cb_cliente.Enabled = False
        gp_agregar.Enabled = False
        m_guardar.Enabled = False

        tabla.Clear()
        total_productos = 0

        Dim rs2 As ADODB.Recordset = New ADODB.Recordset

        rs2.Open("SELECT cotizacion_detalle.*,cotizacion.id_cliente from cotizacion_detalle WHERE id_cotizacion = " & id_factura, conn)
        If rs2.RecordCount > 0 Then
            aplicar_redondeo = obtener_aplicar_redondeo(rs2.Fields("id_cliente").Value, True)
            While Not rs2.EOF
                agregar_producto(rs2.Fields("descripcion").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, rs2.Fields("impuesto").Value, rs2.Fields("precio_unitario").Value, rs2.Fields("precio_venta").Value, rs2.Fields("total_porcent_iva").Value, rs2.Fields("total_porcent_otros").Value, rs2.Fields("impuesto").Value)

                rs2.MoveNext()
            End While
        End If

        rs2.Close()

        Dim total_persona As Integer = 0
        Dim total_empresa As Integer = 0

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
                    .SelectedIndex = 0
                End If
            End If
        End With
        'conn.close()
        'conn = Nothing
        tb_codigo.Focus()
    End Sub

    Public Sub cargar(Optional ByVal id As Integer = 0)
        Panel1.Enabled = True
        id_factura = id
        tb_numero_factura.ReadOnly = True
        ' Cliente
        tb_domicilio.Text = ""
        tb_email.Text = ""

        If id_factura > 0 Then
            'Conectar()
            rs.Open("SELECT id_factura,numero,total,subtotal,iva,otros,id_cliente,id_empleado,fecha,year(fecha) anio FROM factura where id_factura = " & id_factura, conn)
            id_cliente = rs.Fields("id_cliente").Value
            id_empleado = rs.Fields("id_empleado").Value
            'tb_numero_factura.Text = "FT" & rs.Fields("anio").Value & "-" & Format(CInt(rs.Fields("numero").Value), "0000")
            tb_numero_factura.Text = rs.Fields("numero").Value
            tb_fecha.Value = Format(rs.Fields("fecha").Value, "yyyy-MM-dd")

            '   Totales
            tb_subtotal.Text = "$ " & FormatNumber(rs.Fields("subtotal").Value, 2)
            tb_iva.Text = "$ " & FormatNumber(rs.Fields("iva").Value, 2)
            tb_otros_impuestos.Text = "$ " & FormatNumber(rs.Fields("otros").Value, 2)
            tb_total.Text = "$ " & FormatNumber(rs.Fields("total").Value, 2)
            rs.Close()

            rs.Open("SELECT trim(Concat(p.ap_paterno,' ',p.ap_materno,' ',p.nombre)) as nombre, ep.id_puesto, ep.nombre nombre_puesto from persona p JOIN empleado e JOIN empleado_puesto ep ON e.id_puesto=ep.id_puesto AND e.id_persona=p.id_persona  WHERE e.id_empleado=" & id_empleado & " ORDER BY p.nombre", conn)
            tb_empleado.Text = rs.Fields("nombre").Value
            tb_puesto.Text = rs.Fields("nombre_puesto").Value
            rs.Close()

            m_exportar.Enabled = True


            dg_factura.Columns("cantidad").ReadOnly = True
            tb_fecha.Enabled = False
            cb_cliente.Enabled = False
            gp_agregar.Enabled = False
            m_guardar.Enabled = False
            gb_tickets.Enabled = False
            tsb_imprimir.Visible = True
            ' btn_generar_factura.Visible = True
            btn_eliminar_factura.Visible = True
            tabla.Clear()
            total_productos = 0

            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT factura_detalle.*, factura.id_cliente from factura_detalle JOIN factura ON factura.id_factura=factura_detalle.id_factura WHERE factura_detalle.id_factura = " & id_factura, conn)
            If rs2.RecordCount > 0 Then
                aplicar_redondeo = obtener_aplicar_redondeo(rs2.Fields("id_cliente").Value, True)
                While Not rs2.EOF
                    agregar_producto(rs2.Fields("descripcion").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, rs2.Fields("impuesto").Value, rs2.Fields("precio_unitario").Value, rs2.Fields("precio_venta").Value, rs2.Fields("total_porcent_iva").Value, rs2.Fields("total_porcent_otros").Value, rs2.Fields("impuesto").Value, rs2.Fields("id_producto").Value)
                    rs2.MoveNext()
                End While
            End If

            rs2.Close()
            'conn.close()
            'conn = Nothing
        Else
            tabla.Clear()
            total_productos = 0
            tsb_imprimir.Visible = False
            'btn_generar_factura.Visible = False
            btn_eliminar_factura.Visible = False

            dg_factura.Columns("cantidad").ReadOnly = False
            id_cliente = 0
            id_empleado = global_id_empleado

            ' factura
            'tb_numero_factura.Text = "FT" & Date.Today.Year & "-000X"
            'Conectar()
            rs.Open("SELECT IF(MAX(numero) IS NULL,1,MAX(numero)+1) numero from factura WHERE YEAR(fecha) = '" & Date.Today.Year & "'", conn)
            tb_numero_factura.Text = Format(rs.Fields("numero").Value, "000")
            rs.Close()
            'conn.close()
            'conn = Nothing

            tb_fecha.Value = Date.Today

            ' Total
            tb_subtotal.Text = "$ 0.00"
            tb_iva.Text = "$ 0.00"
            tb_total.Text = "$ 0.00"
            tb_otros_impuestos.Text = "$ 0.00"

            tb_empleado.Text = global_nombre
            tb_puesto.Text = global_puesto

            m_exportar.Enabled = False
            tb_fecha.Enabled = True
            cb_cliente.Enabled = True
            m_guardar.Enabled = False
            gp_agregar.Enabled = True
            gb_tickets.Enabled = True
            limpiar_tickets_factura()
            index_matrix_tickets = 0
            tb_numero_factura.ReadOnly = False
        End If


        Dim total_persona As Integer = 0
        Dim total_empresa As Integer = 0

        With cb_cliente
            i = 0
            tmp = 0
            .Text = ""
            .Items.Clear()
            'Conectar()
            rs.Open("SELECT c.id_cliente,if(c.id_persona IS NULL,-1,c.id_persona) id_persona,ct.descuento, p.alias as alias from persona p JOIN cliente c JOIN cliente_tipo ct ON c.id_persona=p.id_persona AND ct.id_tipo=c.id_tipo ORDER BY p.nombre", conn)
            While Not rs.EOF
                .Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("alias").Value, 0, rs.Fields("descuento").Value))
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
            'conn.close()
            'conn = Nothing
            If total_empresa > 0 Then
                If id_cliente > 0 Then
                    .SelectedIndex = tmp
                Else
                    .SelectedIndex = 0
                End If
            End If
        End With
        tb_codigo.Focus()

    End Sub

    Private Sub agregar_producto(ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal impuesto As String, ByVal precio As Decimal, ByVal precio_venta As Decimal, ByVal total_iva As Decimal, ByVal total_otros As Decimal, ByVal nombre_impuestos As String, Optional ByVal id_producto As Integer = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id_producto)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then

            If foundRows(0).Item("precio_venta") = precio_venta Then

                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + cantidad
                If aplicar_redondeo Then
                    foundRows(0).Item("importe") = redondear(FormatNumber(CDec(foundRows(0).Item("precio_venta")) * (foundRows(0).Item("cantidad")), 2))
                Else
                    foundRows(0).Item("importe") = CDec(foundRows(0).Item("precio_venta")) * (foundRows(0).Item("cantidad"))
                End If
            Else
                GoTo NEW_LINE
            End If


        Else
NEW_LINE:   total_productos = total_productos + 1
            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id_producto
            tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = descripcion
            tabla_linea("cantidad") = cantidad
            tabla_linea("unidad") = unidad
            tabla_linea("precio") = precio
            tabla_linea("precio_venta") = precio_venta
            If aplicar_redondeo Then
                tabla_linea("importe") = redondear(FormatNumber(precio_venta * cantidad, 2))
            Else
                tabla_linea("importe") = precio_venta * cantidad
            End If
            tabla_linea("impuesto") = nombre_impuestos
            tabla_linea("total_iva") = total_iva
            tabla_linea("total_otros") = total_otros

            tabla.Rows.Add(tabla_linea)
        End If





    End Sub

    Public Sub agregar_producto(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Decimal = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If
            'foundRows(0).Item("precio") = obtener_precio_producto(id, id_catalogo_precio, foundRows(0).Item("cantidad"))
            'foundRows(0).Item("precio_venta") = obtener_precio_producto(id, id_catalogo_precio, foundRows(0).Item("cantidad"))

            'foundRows(0).Item("precio") = obtener_precio_producto(id, id_catalogo_precio, foundRows(0).Item("cantidad"))
            'foundRows(0).Item("precio_venta") = obtener_precio_producto(id, id_catalogo_precio, foundRows(0).Item("cantidad"))
            foundRows(0).Item("precio_venta") = foundRows(0).Item("precio")
            If aplicar_redondeo Then
                foundRows(0).Item("importe") = redondear(FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio")), 2))
            Else
                foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio")), 2)
            End If
            dg_factura.UpdateCellValue(dg_factura.Columns.Item("precio_venta").Index, dg_factura.CurrentRow.Index)
            dg_factura.UpdateCellValue(dg_factura.Columns.Item("importe").Index, dg_factura.CurrentRow.Index)

        Else
            total_productos = total_productos + 1
            tabla_linea = tabla.NewRow()
            If cantidad > 0 Then
                tabla_linea("cantidad") = cantidad
            Else
                tabla_linea("cantidad") = 1
            End If
            tabla_linea("precio") = obtener_precio_producto(id, id_catalogo_precio)
            'Conectar()
            rs.Open("SELECT DISTINCT p.id_producto, p.nombre, p.descripcion, u.nombre unidad, pp.id_precio, pp.precio, ps.precio_especial_termino, ps.precio_especial_inicio, ps.precio_especial " & _
                    "FROM producto p, unidad u,producto_precio pp, producto_sucursal ps " & _
                    "WHERE(ps.id_precio = pp.id_precio) " & _
                    "AND pp.id_producto = p.id_producto " & _
                    "AND p.id_unidad=u.id_unidad AND p.id_producto=" & id, conn)

            tabla_linea("id_producto") = id
            tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = rs.Fields("nombre").Value & vbCrLf & rs.Fields("descripcion").Value

            tabla_linea("unidad") = rs.Fields("unidad").Value
            tabla_linea("id_precio") = rs.Fields("id_precio").Value

            rs.Close()
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

            'conn.close()
            'conn = Nothing

            tabla_linea("precio_venta") = obtener_precio_producto(id, id_catalogo_precio)
            If aplicar_redondeo Then
                tabla_linea("importe") = redondear(FormatNumber(tabla_linea("precio_venta") * tabla_linea("cantidad"), 2))
            Else
                tabla_linea("importe") = tabla_linea("precio_venta") * tabla_linea("cantidad")
            End If


            tabla.Rows.Add(tabla_linea)
        End If
        actualizar_totales()
    End Sub

    Private Sub actualizar_partida()
        Dim j As Integer

        For j = 0 To dg_factura.RowCount - 1
            dg_factura.Rows(j).Cells("partida").Value = j + 1
            total_productos = j + 1
        Next
    End Sub
    Private Sub actualizar_totales()
        Dim j As Integer

        Dim subtotal As Decimal = 0

        Dim total_iva As Decimal = 0
        Dim total_otros As Decimal = 0

        For j = 0 To dg_factura.RowCount - 1
            subtotal = subtotal + CDec(dg_factura.Rows(j).Cells("importe").Value)

            If CDec(dg_factura.Rows(j).Cells("total_iva").Value) > 0 Then
                total_iva += (CDec(dg_factura.Rows(j).Cells("importe").Value) * CDec(dg_factura.Rows(j).Cells("total_iva").Value)) / 100
            End If

            If CDec(dg_factura.Rows(j).Cells("total_iva").Value) > 0 Then
                total_otros += (CDec(dg_factura.Rows(j).Cells("importe").Value) * CDec(dg_factura.Rows(j).Cells("total_otros").Value)) / 100
            End If

        Next
        tb_subtotal.Text = "$ " & FormatNumber(subtotal, 2)
        tb_otros_impuestos.Text = "$ " & FormatNumber(total_otros, 2)
        tb_iva.Text = "$ " & FormatNumber(total_iva, 2)
        tb_total.Text = "$ " & FormatNumber(subtotal + total_otros + total_iva, 2)
    End Sub
    Private Sub limpiar_tabla()
        tabla.Clear()
        suma_subtotal = 0
        suma_iva = 0
        suma_otros = 0
        tb_subtotal.Text = "$ 0.00"
        tb_iva.Text = "$ 0.00"
        tb_total.Text = "$ 0.00"
        tb_otros_impuestos.Text = "$ 0.00"
        chb_generalizar.Checked = False
        limpiar_tickets_factura()
        index_matrix_tickets = 0
    End Sub

    Private Sub pb_url_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub cb_cliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
        frm_factura_abrir.ShowDialog()
    End Sub

    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bucar.Click
        global_frm_producto_abrir = 3
        'frm_producto_abrir.ShowDialog()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        If Trim(tb_codigo.Text) <> "" Then
            'Conectar()
            rs.Open("select id_producto from producto WHERE codigo='" & Trim(tb_codigo.Text) & "'", conn)
            If rs.RecordCount > 0 Then
                Dim id_producto As Integer = rs.Fields("id_producto").Value
                rs.Close()
                tb_codigo.Text = ""
                agregar_producto(id_producto)
            Else
                rs.Close()
                'conn.close()
                'conn = Nothing
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

    Private Sub dg_factura_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_factura.CellEndEdit
        dg_factura_CellValueChanged(sender, e)
    End Sub
    Private Sub dg_factura_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dg_factura.CellValidating
        ''If id_factura = 0 Then
        ''Dim newInteger As Integer
        ''If dg_factura.Rows(e.RowIndex).IsNewRow Then Return
        ''If dg_factura.Columns("cantidad").Index = e.ColumnIndex Then
        ''If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger <= 0 Then
        ''e.Cancel = True
        ''MsgBox("Solo se permiten valores enteros mayores a 0", MsgBoxStyle.Information, "Error en el tipo de dato")
        'dg_cotizacion.Rows(e.RowIndex).ErrorText = "Solo se permiten valores enteros mayores a 0"
        ''End If
        ''End If
        ''Else
        'e.Cancel = True
        ''End If
    End Sub
    Private Sub dg_factura_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_factura.CellValueChanged
        If cargado Then
            agregar_producto(dg_factura.Rows(dg_factura.CurrentRow.Index).Cells("id_producto").Value, True)
        End If
    End Sub

    Private Sub dg_factura_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_factura.CellDoubleClick
        'If id_factura = 0 Then
        'If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
        'dg_factura.Rows.RemoveAt(dg_factura.CurrentRow.Index)
        ' If dg_factura.Rows.Count = 0 Then
        'total_productos = 0
        '  m_guardar.Enabled = False
        '  End If
        '  actualizar_partida()
        '  actualizar_totales()
        '  End If
        ' End If
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
        If Trim(tb_numero_factura.TextLength) = 0 Then
            MsgBox("El numero de factura no puede estar vacio", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If
        'Conectar()
        Dim numero As String = ""

        numero = tb_numero_factura.Text

        conn.Execute("INSERT INTO factura (fecha,numero,subtotal,iva,otros,total,id_cliente,descuento,id_empleado) VALUES" & _
                     " ('" & Format(tb_fecha.Value, "yy-MM-dd") & "','" & numero & "','" & CDec(tb_subtotal.Text) & "','" & CDec(tb_iva.Text) & "','" & CDec(tb_otros_impuestos.Text) & "','" & CDec(tb_total.Text) & "'," & id_cliente & ",'" & cliente_descuento & "'," & id_empleado & ")")

        rs.Open("SELECT last_insert_id() id_factura", conn)
        id_factura = rs.Fields("id_factura").Value
        rs.Close()

        For row = 0 To tabla.Rows.Count - 1
            conn.Execute("INSERT INTO factura_detalle (id_factura,id_producto,descripcion,cantidad,unidad,total_porcent_iva,total_porcent_otros,impuesto,precio_unitario,precio_venta,importe) VALUES" & _
                         " (" & id_factura & "," & dg_factura.Item("id_producto", row).Value & ",'" & dg_factura.Item("descripcion", row).Value & "'," & dg_factura.Item("cantidad", row).Value & ",'" & dg_factura.Item("unidad", row).Value & "','" & dg_factura.Item("total_iva", row).Value & "','" & dg_factura.Item("total_otros", row).Value & "','" & dg_factura.Item("impuesto", row).Value & "','" & CDec(dg_factura.Item("precio", row).Value) & "','" & CDec(dg_factura.Item("precio_venta", row).Value) & "','" & CDec(dg_factura.Item("importe", row).Value) & "')")


        Next
        For x = 0 To 100

            If Not IsNothing(tickes_facturas(x, 0)) Then
                If tickes_facturas(x, 0) = 0 Then
                    conn.Execute("UPDATE venta SET id_factura=" & id_factura & " WHERE num_ticket=" & tickes_facturas(x, 1))
                Else
                    conn.Execute("UPDATE pedido_clientes SET id_factura=" & id_factura & " WHERE id_pedido=" & tickes_facturas(x, 1))
                End If
            Else
                Exit For
            End If
        Next

        Dim importe_total_tickets As Decimal = 0
        rs.Open("SELECT total from venta WHERE id_factura='" & id_factura & "' AND status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                importe_total_tickets += rs.Fields("total").Value
                rs.MoveNext()
            End While
        End If
        rs.Close()

        rs.Open("SELECT venta.total FROM venta JOIN pedido_clientes ON pedido_clientes.id_venta=venta.id_venta WHERE pedido_clientes.id_factura='" & id_factura & "' AND venta.status='CERRADA'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                importe_total_tickets += rs.Fields("total").Value
                rs.MoveNext()
            End While

        End If
        rs.Close()

        If CDec(tb_total.Text) = importe_total_tickets Then
            conn.Execute("UPDATE factura SET estatus='PAGADO' WHERE id_factura=" & id_factura)
        End If


        m_guardar.Enabled = False
        m_exportar.Enabled = True
        'conn.close()
        'conn = Nothing
        cargar(id_factura)

        MsgBox("La factura se ha generado con el Número " & vbCrLf & tb_numero_factura.Text, MsgBoxStyle.Information, "Confirmacion factura")
    End Sub
    Private Sub frm_factura_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If cargado Then
            If Me.Width > 1100 Then
                dg_factura.Columns("descripcion").Width = 40 + Me.Width - 900
            Else
                dg_factura.Columns("descripcion").Width = 250
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_abrir_cotizacion.Click
        global_frm_cotizacion_abrir = 2
        ' frm_cotizacion_abrir.ShowDialog()
    End Sub


    Private Sub tb_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_total.TextChanged
        If total_productos > 0 Then
            m_guardar.Enabled = True
        End If
    End Sub

    Private Sub dg_factura_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_factura.CellContentClick

    End Sub
    Private Sub cb_pedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_pedidos.SelectedIndexChanged

    End Sub

    Private Sub cb_ticket_inicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_ticket_inicio.SelectedIndexChanged
        If cb_ticket_inicio.SelectedIndex <> -1 Then
            cb_ticket_termino.Text = cb_ticket_inicio.Text
        End If
    End Sub

    Private Sub rb_ticket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_ticket.CheckedChanged
        If rb_ticket.Checked = True Then
            cb_ticket_inicio.Enabled = True
            cb_ticket_termino.Enabled = True
        Else
            cb_ticket_inicio.Enabled = False
            cb_ticket_termino.Enabled = False
        End If
    End Sub

    Private Sub rb_pedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_pedido.CheckedChanged
        If rb_pedido.Checked = True Then
            cb_pedidos.Enabled = True
        Else
            cb_pedidos.Enabled = False
        End If
    End Sub

    Private Sub rb_cotizacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_cotizacion.CheckedChanged
        If rb_cotizacion.Checked = True Then
            btn_abrir_cotizacion.Enabled = True
        Else
            btn_abrir_cotizacion.Enabled = False
        End If
    End Sub
    Private Function buscar_ticket(ByVal tipo As Integer, ByVal id_ticket As Integer) As Boolean
        Dim existe_ticket As Boolean = False
        For x = 0 To 100
            If Not IsNothing(tickes_facturas(x, 1)) Then
                If tickes_facturas(x, 0) = tipo Then
                    If tickes_facturas(x, 1) = id_ticket Then
                        existe_ticket = True
                        Exit For
                    End If
                End If
            Else
                Exit For
            End If
        Next
        Return existe_ticket
    End Function

    Public Sub btn_agregar_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_doc.Click
        'MsgBox(index_matrix_tickets)
        '--matrix ticket factura
        '    0   / 1
        'id_tipo/folio
        '0-ticket
        '1-pedido

        If rb_pedido.Checked = True Then

            If cb_pedidos.SelectedIndex <> -1 Then
                If buscar_ticket(1, CType(cb_pedidos.SelectedItem, myItem).Value) Then
                    MsgBox("Este pedido ya existe en esta factura")
                Else
                    '---agregamos pedido seleccionado
                    'Conectar()
                    rs.Open("SELECT pedido_clientes.id_cliente,pedido_clientes.subtotal,pedido_clientes.iva,pedido_clientes.otros_impuestos,pedido_clientes.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM detalle_pedido JOIN pedido_clientes ON pedido_clientes.id_pedido=detalle_pedido.id_pedido WHERE pedido_clientes.id_pedido=" & CType(cb_pedidos.SelectedItem, myItem).Value, conn)
                    If rs.RecordCount > 0 Then
                        suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                        suma_iva = suma_iva + CDec(rs.Fields("iva").Value)
                        suma_otros = suma_otros + CDec(rs.Fields("otros_impuestos").Value)
                        aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                        While Not rs.EOF
                            agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                    'conn.close()
                    'conn = Nothing
                    tickes_facturas(index_matrix_tickets, 0) = 1
                    tickes_facturas(index_matrix_tickets, 1) = CType(cb_pedidos.SelectedItem, myItem).Value
                    index_matrix_tickets = index_matrix_tickets + 1
                    '----------------------------
                End If
            Else
                MsgBox("Seleccione un pedido")
            End If

        ElseIf rb_ticket.Checked = True Then
            If cb_ticket_inicio.SelectedIndex <> -1 Then
                If CType(cb_ticket_inicio.SelectedItem, myItem).Value = CType(cb_ticket_termino.SelectedItem, myItem).Value Then
                    If buscar_ticket(0, CType(cb_ticket_inicio.SelectedItem, myItem).Value) Then
                        MsgBox("Este ticket ya existe en esta factura")
                    Else
                        '---agregamos ticket seleccionado
                        'Conectar()
                        rs.Open("SELECT venta.id_cliente,venta.subtotal,venta.total_iva,venta.total_otros,venta.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE venta.id_venta=" & CType(cb_ticket_inicio.SelectedItem, myItem).Value, conn)
                        If rs.RecordCount > 0 Then
                            suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                            suma_iva = suma_iva + CDec(rs.Fields("total_iva").Value)
                            suma_otros = suma_otros + CDec(rs.Fields("total_otros").Value)
                            aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                            While Not rs.EOF
                                agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                                rs.MoveNext()
                            End While
                        End If
                        rs.Close()
                        'conn.close()
                        'conn = Nothing
                        '----------------------------
                        tickes_facturas(index_matrix_tickets, 0) = 0
                        tickes_facturas(index_matrix_tickets, 1) = CType(cb_ticket_inicio.SelectedItem, myItem).Value
                        index_matrix_tickets = index_matrix_tickets + 1

                    End If

                Else
                    '---agregamos rango de tickets
                    Dim id_venta As Integer = 0
                    'Conectar()
                    rs.Open("SELECT venta.id_cliente,venta.id_venta,venta.subtotal,venta.total_iva,venta.total_otros,venta.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE  id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value & " AND venta.id_venta BETWEEN " & CType(cb_ticket_inicio.SelectedItem, myItem).Value & " and " & CType(cb_ticket_termino.SelectedItem, myItem).Value, conn)
                    If rs.RecordCount > 0 Then

                        While Not rs.EOF
                            Dim n = 0
                            If id_venta <> rs.Fields("id_venta").Value Then
                                If buscar_ticket(0, rs.Fields("id_venta").Value) Then
                                    MsgBox("El ticket " & rs.Fields("id_venta").Value & " ya existe en esta factura")
                                    n = 1
                                Else
                                    suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                                    suma_iva = suma_iva + CDec(rs.Fields("total_iva").Value)
                                    suma_otros = suma_otros + CDec(rs.Fields("total_otros").Value)
                                    id_venta = rs.Fields("id_venta").Value
                                    tickes_facturas(index_matrix_tickets, 0) = 0
                                    tickes_facturas(index_matrix_tickets, 1) = rs.Fields("id_venta").Value
                                    index_matrix_tickets = index_matrix_tickets + 1
                                End If

                            End If
                            If n = 0 Then
                                aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                                agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                            End If



                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                    'conn.close()
                    'conn = Nothing
                    '----------------------------

                End If
            Else
                MsgBox("Seleccione un ticket")
            End If
        ElseIf rb_ticket_alone.Checked = True Then
            If Trim(tb_ticket_alone.TextLength) <> 0 Then
                Dim id_cliente As Integer
                If tabla.Rows.Count = 0 Then
                    '---agregamos ticket seleccionado
                    'Conectar()

                    '----1.-obtenemos el id_cliente del ticket
                    id_cliente = 0
                    rs.Open("SELECT id_cliente FROM venta WHERE id_factura=0 AND id_venta=" & tb_ticket_alone.Text, conn)
                    If rs.RecordCount > 0 Then
                        id_cliente = rs.Fields("id_cliente").Value
                    End If
                    rs.Close()
                    '-----FIN 1.------------
                    'conn.close()
                    'conn = Nothing

                    If id_cliente = 1 Then
                        If MsgBox("El ticket con el folio " & tb_ticket_alone.Text & " es de Publico General.¿ Desea agregar este ticket de todas formas? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                            GoTo A
                        End If
                    Else
                        If id_cliente <> 0 Then
A:                          If buscar_ticket(0, tb_ticket_alone.Text) Then
                                MsgBox("El ticket " & tb_ticket_alone.Text & " ya existe en esta factura")
                            Else
                                'Conectar()
                                rs.Open("SELECT venta.id_cliente,venta.subtotal,venta.total_iva,venta.total_otros,venta.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE venta.id_venta=" & tb_ticket_alone.Text, conn)
                                If rs.RecordCount > 0 Then
                                    suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                                    suma_iva = suma_iva + CDec(rs.Fields("total_iva").Value)
                                    suma_otros = suma_otros + CDec(rs.Fields("total_otros").Value)
                                    aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                                    While Not rs.EOF
                                        agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                                        rs.MoveNext()
                                    End While
                                End If
                                rs.Close()
                                'conn.close()
                                'conn = Nothing
                                tickes_facturas(index_matrix_tickets, 0) = 0
                                tickes_facturas(index_matrix_tickets, 1) = tb_ticket_alone.Text
                                index_matrix_tickets = index_matrix_tickets + 1
                            End If

                            If id_cliente <> 1 Then
                                seleccionar_cliente(id_cliente)
                            End If
                        Else
                            MsgBox("No se encontro el ticket con el folio " & tb_ticket_alone.Text & ". El ticket no existe o ya se encuentra facturado!")
                        End If
                    End If
                Else
                    '---agregamos ticket seleccionado
                    'Conectar()
                    id_cliente = 0
                    rs.Open("SELECT id_cliente FROM venta WHERE id_factura=0 AND id_venta=" & tb_ticket_alone.Text, conn)
                    If rs.RecordCount > 0 Then
                        id_cliente = rs.Fields("id_cliente").Value
                    End If
                    rs.Close()

                    If id_cliente = 1 Then
                        If MsgBox("El ticket con el folio " & tb_ticket_alone.Text & " es de Publico General.¿ Desea agregar este ticket de todas formas? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                            GoTo B
                        End If
                    Else
                        If id_cliente <> 0 Then
                            If id_cliente = CType(cb_cliente.SelectedItem, myItem).Value Then
B:                              If buscar_ticket(0, tb_ticket_alone.Text) Then
                                    MsgBox("El ticket " & tb_ticket_alone.Text & " ya existe en esta factura")
                                Else
                                    rs.Open("SELECT venta.id_cliente,venta.subtotal,venta.total_iva,venta.total_otros,venta.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE venta.id_venta=" & tb_ticket_alone.Text, conn)
                                    If rs.RecordCount > 0 Then
                                        suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                                        suma_iva = suma_iva + CDec(rs.Fields("total_iva").Value)
                                        suma_otros = suma_otros + CDec(rs.Fields("total_otros").Value)
                                        aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                                        While Not rs.EOF
                                            agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                                            rs.MoveNext()
                                        End While
                                    End If
                                    rs.Close()
                                    tickes_facturas(index_matrix_tickets, 0) = 0
                                    tickes_facturas(index_matrix_tickets, 1) = tb_ticket_alone.Text
                                    index_matrix_tickets = index_matrix_tickets + 1
                                End If
                                'conn.close()
                                'conn = Nothing
                                tb_ticket_alone.Text = ""
                            Else
                                MsgBox("El ticket con el folio " & tb_ticket_alone.Text & " no pertenece a este cliente")
                                tb_ticket_alone.Text = ""
                            End If
                        Else
                            MsgBox("No se encontro el ticket con el folio " & tb_ticket_alone.Text & ". El ticket no existe o ya se encuentra facturado!")
                            tb_ticket_alone.Text = ""
                        End If
                    End If
                End If
            Else
                MsgBox("Ingrese el numero de ticket a facturar")
            End If
        End If

        tb_subtotal.Text = FormatCurrency(suma_subtotal)
        tb_iva.Text = FormatCurrency(suma_iva)
        tb_otros_impuestos.Text = FormatCurrency(suma_otros)
        tb_total.Text = FormatCurrency(suma_subtotal + suma_iva + suma_otros)
        tb_ticket_alone.Text = ""
        'MsgBox(index_matrix_tickets)
    End Sub
    Public Sub agregar_ticket(ByVal id_venta As Integer)

        Dim id_cliente As Integer
        If tabla.Rows.Count = 0 Then
            '---agregamos ticket seleccionado
            'Conectar()

            '----1.-obtenemos el id_cliente del ticket
            id_cliente = 0
            rs.Open("SELECT id_cliente FROM venta WHERE id_factura=0 AND id_venta=" & id_venta, conn)
            If rs.RecordCount > 0 Then
                id_cliente = rs.Fields("id_cliente").Value
            End If
            rs.Close()
            '-----FIN 1.------------
            'conn.close()
            'conn = Nothing

            If id_cliente = 1 Then
                If MsgBox("El ticket con el folio " & tb_ticket_alone.Text & " es de Publico General.¿ Desea agregar este ticket de todas formas? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    GoTo A
                End If
            Else
                If id_cliente <> 0 Then
A:                  If buscar_ticket(0, id_venta) Then
                        MsgBox("El ticket " & id_venta & " ya existe en esta factura")
                    Else
                        'Conectar()
                        rs.Open("SELECT venta.id_cliente,venta.subtotal,venta.total_iva,venta.total_otros,venta.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE venta.id_venta=" & id_venta, conn)
                        If rs.RecordCount > 0 Then
                            suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                            suma_iva = suma_iva + CDec(rs.Fields("total_iva").Value)
                            suma_otros = suma_otros + CDec(rs.Fields("total_otros").Value)
                            aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                            While Not rs.EOF
                                agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                                rs.MoveNext()
                            End While
                        End If
                        'conn.close()
                        'conn = Nothing
                        tickes_facturas(index_matrix_tickets, 0) = 0
                        tickes_facturas(index_matrix_tickets, 1) = id_venta
                        index_matrix_tickets = index_matrix_tickets + 1
                    End If

                    If id_cliente <> 1 Then
                        seleccionar_cliente(id_cliente)
                    End If
                Else
                    MsgBox("No se encontro el ticket con el folio " & id_venta & ". El ticket no existe o ya se encuentra facturado!")
                End If
            End If
        Else
            '---agregamos ticket seleccionado
            'Conectar()
            id_cliente = 0
            rs.Open("SELECT id_cliente FROM venta WHERE id_factura=0 AND id_venta=" & id_venta, conn)
            If rs.RecordCount > 0 Then
                id_cliente = rs.Fields("id_cliente").Value
            End If
            rs.Close()

            If id_cliente = 1 Then
                If MsgBox("El ticket con el folio " & id_venta & " es de Publico General.¿ Desea agregar este ticket de todas formas? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    GoTo B
                End If
            Else
                If id_cliente <> 0 Then
                    If id_cliente = CType(cb_cliente.SelectedItem, myItem).Value Then
B:                      If buscar_ticket(0, id_venta) Then
                            MsgBox("El ticket " & id_venta & " ya existe en esta factura")
                        Else
                            rs.Open("SELECT venta.id_cliente,venta.subtotal,venta.total_iva,venta.total_otros,venta.total,id_producto,descripcion, unidad,cantidad, precio,impuesto,total_porcent_iva,total_porcent_otros,nombre_impuestos FROM venta_detalle JOIN venta ON venta.id_venta=venta_detalle.id_venta WHERE venta.id_venta=" & id_venta, conn)
                            If rs.RecordCount > 0 Then
                                suma_subtotal = suma_subtotal + CDec(rs.Fields("subtotal").Value)
                                suma_iva = suma_iva + CDec(rs.Fields("total_iva").Value)
                                suma_otros = suma_otros + CDec(rs.Fields("total_otros").Value)
                                aplicar_redondeo = obtener_aplicar_redondeo(rs.Fields("id_cliente").Value, True)
                                While Not rs.EOF
                                    agregar_producto(rs.Fields("descripcion").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("impuesto").Value, rs.Fields("precio").Value, rs.Fields("precio").Value, rs.Fields("total_porcent_iva").Value, rs.Fields("total_porcent_otros").Value, rs.Fields("nombre_impuestos").Value, rs.Fields("id_producto").Value)
                                    rs.MoveNext()
                                End While
                            End If
                            tickes_facturas(index_matrix_tickets, 0) = 0
                            tickes_facturas(index_matrix_tickets, 1) = id_venta
                            index_matrix_tickets = index_matrix_tickets + 1
                        End If
                        'conn.close()
                        'conn = Nothing
                        tb_ticket_alone.Text = ""
                    Else
                        MsgBox("El ticket con el folio " & id_venta & " no pertenece a este cliente")
                    End If
                    tb_ticket_alone.Text = ""
                Else
                    MsgBox("No se encontro el ticket con el folio " & id_venta & ". El ticket no existe o ya se encuentra facturado!")
                    tb_ticket_alone.Text = ""
                End If
            End If
        End If

        tb_subtotal.Text = FormatCurrency(suma_subtotal)
        tb_iva.Text = FormatCurrency(suma_iva)
        tb_otros_impuestos.Text = FormatCurrency(suma_otros)
        tb_total.Text = FormatCurrency(suma_subtotal + suma_iva + suma_otros)
        tb_ticket_alone.Text = ""
    End Sub
    Public Sub seleccionar_cliente(ByVal id_cliente As Integer)
        For x = 0 To cb_cliente.Items.Count - 1
            If id_cliente = CType(cb_cliente.Items(x), myItem).Value Then
                cb_cliente.SelectedIndex = x
                'MsgBox(cb_cliente.Items.IndexOf(cb_cliente.Items(x)))
                Exit For
            End If
        Next
    End Sub

    Private Sub tsb_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_imprimir.Click
        imprimir_recibo_prefactura(id_factura)
        'preparar_documento(1, id_factura, tb_domicilio.Text, tb_ciudad.Text, tb_cp.Text)
        'If chb_generalizar.Checked = True Then
        'If tb_generalizar.TextLength = 0 Then
        'MsgBox("Falta la descripcion para realizar la factura")
        'Else
        'If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        'PrintDocument1.Print()
        'End If
        'End If
        'Else

        '######imprimir todos los productos
        'index_inicio = 0
        'num_lineas = 0
        'Dim num_productos As Integer = tabla.Rows.Count
        'Dim max_lineas As Integer = factura(17, 0)
        'If num_productos <= max_lineas Then
        ''---mandamos a imprimir todo

        'If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        'PrintDocument1.Print()
        'End If
        '------------------------
        'Else
        'If MsgBox("El numero maximo de lineas por facturas es de " & max_lineas & " conceptos. Desea imprimir varias facturas?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
        'Dim numero_facturas As Integer = num_productos \ max_lineas
        'Dim lineas_restantes As Integer = num_productos - (numero_facturas * max_lineas)

        'For x = 1 To numero_facturas
        'index_inicio = (max_lineas * x) - max_lineas
        'num_lineas = max_lineas
        'If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        ' PrintDocument1.Print()
        ' End If
        ' Next

        'If lineas_restantes <> 0 Then
        'index_inicio = ((max_lineas * (numero_facturas + 1)) - max_lineas)
        'num_lineas = lineas_restantes
        'If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        'PrintDocument1.Print()
        'End If
        'End If
        'End If

        'End If
        '######################################3

        'End If





    End Sub
    Private Sub preparar_documento(ByVal tipo_documento As Integer, ByVal id_documento As Integer, ByVal direccion As String, ByVal ciudad As String, ByVal cp As String)
        '   0      /  1  /  2
        '----------------------------------------------------------------------------------------------------------------------
        '    CAMPO/  X  /  Y  /
        '0.-dia 
        '1.-mes 
        '2.-año 
        '3.-cliente 
        '4.-direccion 
        '5.-ciudad 
        '6.-rfc 
        '7.-subtotal 
        '8.-total_iva 
        '9.-otros_impuestos 
        '10.-total 
        '11.-total_letra

        '12.-CANTIDAD (PRODUCTO)"))
        '13.-DESCRIPCION (PRODUCTO)"))
        '14.-UNIDAD (PRODUCTO)"))
        '15.-PRECIO UNIT. (PRODUCTO)"))
        '16.-IMPORTE (PRODUCTO)"))

        '17.-CP(CLIENTE)
        '18.-CODIGO(PRODUCTO)

        If tipo_documento = 1 Then '-----1.- factura
            '---obtenemos detos de la factura
            'Conectar()
            limpiar_factura()
            rs.Open("SELECT factura.fecha,factura.subtotal,factura.iva,factura.otros,factura.total,cliente.id_cliente as num_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,(SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END as rfc FROM cliente JOIN  factura ON factura.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura.id_factura=" & id_documento & ")As RFC FROM factura JOIN cliente ON factura.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura.id_factura=" & id_documento, conn)
            If rs.RecordCount > 0 Then
                factura(0, 0) = Format(rs.Fields("fecha").Value, "dd")
                factura(1, 0) = Format(rs.Fields("fecha").Value, "MMMM")
                factura(2, 0) = Format(rs.Fields("fecha").Value, "yyyy")
                factura(3, 0) = rs.Fields("nombre").Value
                factura(4, 0) = direccion
                factura(5, 0) = ciudad
                factura(6, 0) = rs.Fields("RFC").Value
                factura(7, 0) = FormatCurrency(rs.Fields("subtotal").Value)
                factura(8, 0) = FormatCurrency(rs.Fields("iva").Value)
                factura(9, 0) = FormatCurrency(rs.Fields("otros").Value)
                factura(10, 0) = FormatCurrency(rs.Fields("total").Value)
                factura(11, 0) = Letras(CDbl(rs.Fields("total").Value))
                factura(17, 0) = cp
            End If
            rs.Close()
            rs.Open("SELECT perfil_impresion_campos.id_campo_documento,perfil_impresion_campos.x,perfil_impresion_campos.y,perfil_impresion.ajuste_x,perfil_impresion.ajuste_y,perfil_impresion.max_lineas FROM perfil_impresion_campos JOIN perfil_impresion ON perfil_impresion.id_perfil_impresion=perfil_impresion_campos.id_perfil_impresion WHERE perfil_impresion.id_tipo_documento=1")
            If rs.RecordCount > 0 Then
                factura(19, 0) = rs.Fields("max_lineas").Value
                While Not rs.EOF
                    agregar_posicion_generales(1, rs.Fields("id_campo_documento").Value, rs.Fields("x").Value, rs.Fields("y").Value, rs.Fields("ajuste_x").Value, rs.Fields("ajuste_y").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            '---factura_productos
            ' /    0     /      1     /   2    /      3          /  4    /          5        /          6         /  7   /
            '/ cantidad / descripcion/ unidad / precio_unitario/ importe/ total_porcent_iva / total_porcent_otros/CODIGO/
            Dim i As Integer = 0
            limpiar_factura_productos()
            rs.Open("SELECT factura_detalle.cantidad,factura_detalle.descripcion,factura_detalle.unidad,factura_detalle.precio_unitario,factura_detalle.importe,factura_detalle.total_porcent_iva,factura_detalle.total_porcent_otros, producto.codigo FROM factura_detalle JOIN producto ON producto.id_producto=factura_detalle.id_producto WHERE factura_detalle.id_factura=" & id_documento)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    factura_productos(i, 0) = rs.Fields("cantidad").Value
                    factura_productos(i, 1) = rs.Fields("descripcion").Value
                    factura_productos(i, 2) = rs.Fields("unidad").Value
                    factura_productos(i, 3) = FormatCurrency(rs.Fields("precio_unitario").Value)
                    factura_productos(i, 4) = rs.Fields("importe").Value
                    factura_productos(i, 5) = rs.Fields("total_porcent_iva").Value
                    factura_productos(i, 6) = rs.Fields("total_porcent_otros").Value
                    factura_productos(i, 7) = rs.Fields("codigo").Value
                    i = i + 1
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End If

        'e.Graphics.DrawString("HOLA MUNDO---------------------------------------------------------------(" & i & "," & i & ")", New Font("Tahoma", 10, FontStyle.Bold), Brushes.Black, (i * pix), (i * pix))

    End Sub
    Private Sub agregar_posicion_generales(ByVal tipo_documento As Integer, ByVal id_campo As Integer, ByVal x As Decimal, ByVal y As Decimal, ByVal ajuste_x As Decimal, ByVal ajuste_y As Decimal)
        If tipo_documento = 1 Then  '----obtenemos las posiciines
            x = (x * 10)
            y = (y * 10)
            ajuste_x = ajuste_x * 10
            ajuste_y = ajuste_y * 10
            factura(id_campo, 1) = (x - ajuste_x)
            factura(id_campo, 2) = (y - ajuste_y)
        End If
    End Sub

    Private Sub imprimir_documento(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        If chb_generalizar.Checked = True Then
            '----obtenemos todas las lineas
            For x = 0 To 11
                If Not IsNothing(factura(x, 1)) <> Nothing Then
                    e.Graphics.DrawString(factura(x, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(x, 1), factura(x, 2))
                End If
            Next
            If Not IsNothing(factura(17, 1)) <> Nothing Then
                e.Graphics.DrawString(factura(17, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(17, 1), factura(17, 2))
            End If
            '---factura_productos
            ' /    0     /      1     /   2    /      3          /  4    /          5        /          6         /  7 /
            '/ cantidad / descripcion/ unidad / precio_unitario/ importe/ total_porcent_iva / total_porcent_otros/codigo /
            If Not IsNothing(factura(12, 1)) Then
                e.Graphics.DrawString(1, New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(12, 1), factura(12, 2))
            End If
            If Not IsNothing(factura(13, 1)) Then
                e.Graphics.DrawString(tb_generalizar.Text, New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(13, 1), factura(13, 2))
            End If
            If Not IsNothing(factura(14, 1)) Then
                e.Graphics.DrawString("", New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(14, 1), factura(14, 2))
            End If
            If Not IsNothing(factura(15, 1)) Then
                e.Graphics.DrawString(factura(7, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(15, 1), factura(15, 2))
            End If
            If Not IsNothing(factura(16, 1)) Then
                e.Graphics.DrawString(factura(7, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(16, 1), factura(16, 2))
            End If
            If Not IsNothing(factura(17, 1)) Then
                e.Graphics.DrawString(factura(17, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(17, 1), factura(17, 2))
            End If

            '------------------------------
        Else
            If num_lineas = 0 Then
                '----obtenemos todas las lineas
                For x = 0 To 11
                    If Not IsNothing(factura(x, 1)) <> Nothing Then
                        e.Graphics.DrawString(factura(x, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(x, 1), factura(x, 2))
                    End If
                Next
                If Not IsNothing(factura(17, 1)) <> Nothing Then
                    e.Graphics.DrawString(factura(17, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(17, 1), factura(17, 2))
                End If
                '---factura_productos
                ' /    0     /      1     /   2    /      3          /  4    /          5        /          6         / 7     /
                '/ cantidad / descripcion/ unidad / precio_unitario/ importe/ total_porcent_iva / total_porcent_otros/codigo /
                For x = 0 To 20
                    If factura_productos(x, 0) = Nothing Then
                        Exit For
                    Else
                        Dim interlineado = x * 5
                        If Not IsNothing(factura(12, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(12, 1), factura(12, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(13, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 1), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(13, 1), factura(13, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(14, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 2), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(14, 1), factura(14, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(15, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 3), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(15, 1), factura(15, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(16, 1)) Then
                            e.Graphics.DrawString(FormatCurrency(factura_productos(x, 4)), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(16, 1), factura(16, 2) + interlineado)
                        End If

                        If Not IsNothing(factura(18, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 7), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(18, 1), factura(18, 2) + interlineado)
                        End If

                    End If
                Next
                '------------------------------
            Else
                '---factura_productos
                ' /    0     /      1     /   2    /      3          /  4    /          5        /          6         / 7/
                '/ cantidad / descripcion/ unidad / precio_unitario/ importe/ total_porcent_iva / total_porcent_otros/codigo/
                Dim y As Integer = 0
                Dim total_iva As Decimal = 0
                Dim total_otros As Decimal = 0
                Dim subtotal As Decimal = 0

                y = index_inicio + num_lineas
                Dim j As Integer = 0
                For x = index_inicio To y - 1
                    If factura_productos(x, 0) = Nothing Then
                        Exit For
                    Else

                        Dim interlineado As Decimal = j * 5

                        If Not IsNothing(factura(12, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(12, 1), factura(12, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(13, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 1), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(13, 1), factura(13, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(14, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 2), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(14, 1), factura(14, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(15, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 3), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(15, 1), factura(15, 2) + interlineado)
                        End If
                        If Not IsNothing(factura(16, 1)) Then
                            e.Graphics.DrawString(FormatCurrency(factura_productos(x, 4)), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(16, 1), factura(16, 2) + interlineado)
                        End If

                        If Not IsNothing(factura(18, 1)) Then
                            e.Graphics.DrawString(factura_productos(x, 7), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(18, 1), factura(18, 2) + interlineado)
                        End If
                        '----obtenemos impuestos----
                        subtotal = subtotal + CDec(factura_productos(x, 4))
                        total_iva = total_iva + (CDec(factura_productos(x, 4)) * (CDec(factura_productos(x, 5)) / 100))
                        total_otros = total_otros + (CDec(factura_productos(x, 4)) * (CDec(factura_productos(x, 6)) / 100))
                        '---------------------------
                    End If
                    j = j + 1
                Next
                '---grabamos nuevos valores
                Dim total As Decimal = FormatNumber(subtotal + total_iva + total_otros, 2)
                factura(7, 0) = FormatCurrency(subtotal)
                factura(8, 0) = FormatCurrency(total_iva)
                factura(9, 0) = FormatCurrency(total_otros)
                factura(10, 0) = FormatCurrency(total)
                factura(11, 0) = Letras(CDbl(total))
                '-------------------------
                '------------------------------
                '----obtenemos todas las lineas
                For x = 0 To 11
                    If Not IsNothing(factura(x, 1)) <> Nothing Then
                        e.Graphics.DrawString(factura(x, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(x, 1), factura(x, 2))
                    End If
                Next
                If Not IsNothing(factura(17, 1)) <> Nothing Then
                    e.Graphics.DrawString(factura(17, 0), New Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, factura(17, 1), factura(17, 2))
                End If
            End If
        End If

    End Sub

    Private Sub rb_ticket_alone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_ticket_alone.CheckedChanged
        If rb_ticket_alone.Checked = True Then
            tb_ticket_alone.Enabled = True
        Else
            tb_ticket_alone.Enabled = False
            tb_ticket_alone.Text = ""
        End If
    End Sub

    Private Sub tb_ticket_alone_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_ticket_alone.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_agregar_doc_Click(sender, e)
        End If
    End Sub


    Private Sub chb_codigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_codigo.CheckedChanged
        If chb_codigo.Checked = True Then
            limpiar_tabla()
            gb_tickets.Enabled = False
            tb_codigo.Enabled = True
            btn_agregar.Enabled = True
            btn_bucar.Enabled = True
        Else
            limpiar_tabla()
            gb_tickets.Enabled = True
            tb_codigo.Enabled = False
            btn_agregar.Enabled = False
            btn_bucar.Enabled = False
        End If
    End Sub
    Private Sub chb_generalizar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_generalizar.CheckedChanged
        If chb_generalizar.Checked = True Then
            tb_generalizar.Enabled = True
        Else
            tb_generalizar.Enabled = False
        End If
    End Sub

    Private Sub btn_generar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar_factura.Click
        If chb_generalizar.Checked = True Then
            GenerarFacturaSerieA2(id_factura, True, tb_generalizar.Text)
        Else
            GenerarFacturaSerieA2(id_factura, False, "")
        End If
    End Sub

    Private Sub btn_nuevo_cliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo_cliente.Click
        frm_directorio_factura.Show()
    End Sub

    Private Sub cb_cliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_cliente.KeyDown
        cb_cliente.DroppedDown = False
    End Sub

    Private Sub cb_cliente_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cliente.SelectedIndexChanged
        If cb_cliente.SelectedIndex >= 0 Then
            id_cliente = CType(cb_cliente.SelectedItem, myItem).Value
            cliente_descuento = CType(cb_cliente.SelectedItem, myItem).Opcional2
            If CType(cb_cliente.SelectedItem, myItem).Opcional = 0 Then
                'Conectar()
                rs.Open("SELECT p.email, concat(d.calle,' ',d.colonia,' ',d.municipio) domicilio,d.cp as cp,d.municipio,d.poblacion FROM cliente c, domicilio d, persona p WHERE p.id_persona=c.id_persona AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                tb_ciudad.Text = rs.Fields("poblacion").Value
                tb_cp.Text = rs.Fields("cp").Value
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
                    'conn.close()
                    'conn = Nothing
                End With
            ElseIf CType(cb_cliente.SelectedItem, myItem).Opcional = 1 Then
                'Conectar()
                rs.Open("SELECT e.url, concat(d.calle,' ',d.colonia,' ',d.municipio) domicilio,d.cp as cp,d.municipio,d.poblacion FROM cliente c, domicilio d, empresa e WHERE e.id_empresa=c.id_empresa AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                tb_ciudad.Text = rs.Fields("poblacion").Value
                tb_cp.Text = rs.Fields("cp").Value
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
                    'conn.close()
                    'conn = Nothing
                End With
            End If

            '----obtenemos pedidos
            cb_pedidos.Items.Clear()
            cb_pedidos.Text = ""

            'Conectar()
            rs.Open("SELECT id_pedido,num_ticket,date(fecha_entrega) as fecha,total FROM pedido_clientes WHERE id_factura=0 AND status='CERRADO' AND id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
            While Not rs.EOF
                If rs.RecordCount > 0 Then
                    Dim pedido As String = "PED: " & rs.Fields("num_ticket").Value & " - " & rs.Fields("fecha").Value & " - " & FormatCurrency(rs.Fields("total").Value)
                    cb_pedidos.Items.Add(New myItem(rs.Fields("id_pedido").Value, pedido))
                    rs.MoveNext()
                End If

            End While
            rs.Close()
            '-----------------------

            '---obtenermos tickets
            cb_ticket_inicio.Items.Clear()
            cb_ticket_termino.Items.Clear()
            cb_ticket_inicio.Text = ""
            cb_ticket_termino.Text = ""
            rs.Open("SELECT id_venta,num_ticket,date(fecha) as fecha,total FROM venta WHERE id_cliente='" & CType(cb_cliente.SelectedItem, myItem).Value & "' AND id_factura=0 AND status='CERRADA'", conn)
            While Not rs.EOF
                If rs.RecordCount > 0 Then
                    Dim ticket As String = "ticket: " & rs.Fields("num_ticket").Value & " fecha: " & rs.Fields("fecha").Value
                    cb_ticket_inicio.Items.Add(New myItem(rs.Fields("id_venta").Value, ticket))
                    cb_ticket_termino.Items.Add(New myItem(rs.Fields("id_venta").Value, ticket))
                    rs.MoveNext()
                End If

            End While
            rs.Close()
            '---------------------------
            '---seleccionamos el precio_especial de este cliente
            id_catalogo_precio = 0
            rs.Open("SELECT * FROM cliente_precio WHERE id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
            If rs.RecordCount > 0 Then
                id_catalogo_precio = rs.Fields("id_catalogo_precio").Value
                If rs.Fields("aplicar_redondeo").Value = 1 Then
                    aplicar_redondeo = True
                Else
                    aplicar_redondeo = False
                End If
            End If
            rs.Close()
            '---------------------------------------------

            'conn.close()
            'conn = Nothing
        End If

        If id_factura = 0 Then
            If tb_ticket_alone.Text = "" Then
                limpiar_tabla()
            End If
        End If
    End Sub

    Private Sub btn_eliminar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_factura.Click
        If MsgBox("Esta seguro que desea cancelar esta factura", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("UPDATE venta SET id_factura='0' WHERE id_factura=" & id_factura)
            conn.Execute("UPDATE pedido_clientes SET id_factura='0' WHERE id_factura=" & id_factura)
            conn.Execute("DELETE FROM factura_detalle WHERE id_factura=" & id_factura)
            conn.Execute("DELETE FROM factura WHERE id_factura=" & id_factura)
            'conn.close()
            'conn = Nothing
            cargar()
            MsgBox("Factura eliminada correctamente", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub
End Class