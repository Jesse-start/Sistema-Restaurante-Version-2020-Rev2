Public Class frm_productos_recepcion
    Dim id_compra As Integer = 0
    Dim id_proveedor As Integer = 0
    Dim id_empleado As Integer = 0

    Dim cliente_descuento As Decimal = 0
    Dim i As Integer
    Dim tmp As Integer

    Dim total_productos As Integer = 0
    '--- varibales para datagrid view
    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow
    '-------------------------------

    Dim cargado As Boolean = False

    Dim importe As Decimal = 0
    Dim subtotal As Decimal = 0
    Dim total_iva As Decimal = 0
    Dim total_otros As Decimal = 0
    Dim x As Integer = 0
    Dim selected_text As Boolean
    Dim selected_grid As Boolean
    Dim no_campo As Integer = 1
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        FlowLayoutPanel1.BackColor = Color.FromArgb(conf_colores(1))

        gb_recepcion.ForeColor = Color.FromArgb(conf_colores(2))
        gb_proveedor.ForeColor = Color.FromArgb(conf_colores(2))
        gb_producto.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))
        ' GroupBox3.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox4.ForeColor = Color.FromArgb(conf_colores(2))
        GroupBox5.ForeColor = Color.FromArgb(conf_colores(2))

        lblFacturaProveedor.ForeColor = Color.FromArgb(conf_colores(13))
        lblFechaProveedor.ForeColor = Color.FromArgb(conf_colores(13))
        lblFechaRecepcion.ForeColor = Color.FromArgb(conf_colores(13))
        lblNombrePersona.ForeColor = Color.FromArgb(conf_colores(13))
        lblProveedor.ForeColor = Color.FromArgb(conf_colores(13))
        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        'Label10.ForeColor = Color.FromArgb(conf_colores(13))
        'Label11.ForeColor = Color.FromArgb(conf_colores(13))
        Label12.ForeColor = Color.FromArgb(conf_colores(13))
        Label15.ForeColor = Color.FromArgb(conf_colores(13))
        Label16.ForeColor = Color.FromArgb(conf_colores(13))

        Label18.ForeColor = Color.FromArgb(conf_colores(13))
        Label19.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        'Label20.ForeColor = Color.FromArgb(conf_colores(13))
        Label21.ForeColor = Color.FromArgb(conf_colores(13))
        label3.ForeColor = Color.FromArgb(conf_colores(13))
        'Label4.ForeColor = Color.FromArgb(conf_colores(13))

        Label7.ForeColor = Color.FromArgb(conf_colores(13))
        'Label9.ForeColor = Color.FromArgb(conf_colores(13))
        tb_folio.ForeColor = Color.FromArgb(conf_colores(13))

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


        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

        btn_agregar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_buscar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        ' habilitar_menu_ventana()
        global_frm_compras = 0
        ''conn.close()
    End Sub
    Private Sub inicializar_Combobox()
        llenar_Tipo_moneda()
        llenar_Almacenes()
        llenar_Proveedores()
        cargar_empleados()
        '  cb_Moneda.SelectedIndex = 0

    End Sub
    Private Sub cargar_empleados()
        cb_nombreReceptor.Items.Clear()
        'Conectar()
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As Nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_nombreReceptor.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("Nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub frm_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        aplicar_colores()
        btn_imprimir.Visible = False
        ''Conectar()
        'Me.MdiParent = frm_principal
        ' habilitar_menu_ventana()
        global_frm_compras = 1
        tabla = New DataTable("cotizacion")
        With tabla.Columns
            .Add(New DataColumn("partida", GetType(Integer)))
            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
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

        With dgv_recepcion
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
            .Columns("impuesto").Visible = False
            .Columns("total_iva").Visible = False
            .Columns("total_otros").Visible = False
            '.Columns("importe").Visible = False
            .Columns("precio_venta").Visible = False
            .Columns("partida").Visible = False


            With .Columns("imagen")
                .HeaderText = "imagen"
                .Width = 30
                .ReadOnly = False
            End With
            With .Columns("codigo")
                .HeaderText = "codigo"
                .Width = 100
                .ReadOnly = False
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 60
                .ReadOnly = False
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 80
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 300
                .ReadOnly = True
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unitario"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = False
            End With
            ' With .Columns("impuesto")
            '.HeaderText = "Impuestos"
            '.Width = 70
            '.ReadOnly = True
            'End With

            'With .Columns("precio")
            '.HeaderText = "Precio Unitario"
            '.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Width = 100
            '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.DefaultCellStyle.Format = "c"
            '.ReadOnly = False
            'End With
            'With .Columns("precio_venta")
            '.HeaderText = "Precio Venta"
            '.Width = 100
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' .DefaultCellStyle.Format = "c"
            ' .ReadOnly = True
            '  End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
        End With
        tb_subtotal.Text = "$ 0.00"
        tb_iva.Text = "$ 0.00"
        tb_total.Text = "$ 0.00"
        tb_otros_impuestos.Text = "$ 0.00"


        m_guardar.Enabled = False
        cargado = True

    End Sub
    Public Sub cargar(Optional ByVal id As Integer = 0)
        Dim empleado As Integer
        'Dim id_almacen As Integer
        id_proveedor = 0
        Panel1.Enabled = True

        id_compra = id

        ' Cliente

        tb_NFactura.Text = ""
        dtp_fecha_remision.Enabled = True
        tb_NFactura.Enabled = True
        dtp_fecha_recepcion.Enabled = True
        ' cb_Moneda.Enabled = True
        cb_nombreReceptor.Enabled = True
        btn_imprimir.Visible = False
        inicializar_Combobox()
        m_abrir.Enabled = True
        If id_compra > 0 Then
            btn_imprimir.Visible = True
            dtp_fecha_remision.Enabled = False
            tb_NFactura.Enabled = False
            dtp_fecha_recepcion.Enabled = False
            'cb_Moneda.Enabled = False
            cb_nombreReceptor.Enabled = False
            tb_folio.Text = id_compra
            'Conectar()
            rs.Open("SELECT folio,numero,total,importe,descuento,subtotal,iva,otros,id_proveedor,fecha,YEAR(fecha) anio, moneda.siglas,fecha_recepcion,alias, id_empleado,fecha_remision" & _
                                          " FROM factura_compra INNER JOIN moneda ON factura_compra.id_moneda = moneda.id_moneda " & _
                                          "INNER JOIN producto_recepcion ON factura_compra.id_factura_compra = producto_recepcion.id_factura_compra" & _
                                          " INNER JOIN sucursal ON sucursal.id_sucursal = factura_compra.id_sucursal" & _
                                           " WHERE factura_compra.id_factura_compra='" & id_compra & "'", conn)
            If rs.RecordCount > 0 Then
                dtp_fecha_recepcion.Value = rs.Fields("fecha_recepcion").Value
                'id_cliente = rs.Fields("id_cliente").Value
                empleado = rs.Fields("id_empleado").Value
                ' id_almacen = rs.Fields("id_almacen").Value
                id_proveedor = rs.Fields("id_proveedor").Value
                tb_NFactura.Text = rs.Fields("folio").Value
                dtp_fecha_remision.Value = rs.Fields("fecha").Value
                'cb_Moneda.Text = rs.Fields("siglas").Value
                tb_subtotal.Text = rs.Fields("subtotal").Value
                'tb_numero_cotizacion.Text = "CT" & rs.Fields("anio").Value & "-" & Format(CInt(rs.Fields("numero").Value), "0000")
                'tb_fecha.Value = Format(rs.Fields("fecha").Value, "dd-MM-yy")

                If IsDBNull(rs.Fields("fecha_remision").Value) Then
                    conn.Execute("UPDATE factura_compra SET fecha_remision=DATE(fecha) WHERE id_factura_compra='" & id_compra & "'")
                    dtp_fecha_remision.Value = Format(rs.Fields("fecha").Value, "dd-MM-yy")
                Else
                    dtp_fecha_remision.Value = Format(rs.Fields("fecha_remision").Value, "dd-MM-yy")
                End If


                '   Totales
                tb_subtotal.Text = "$ " & FormatNumber(rs.Fields("subtotal").Value, 2)
                tb_iva.Text = "$ " & FormatNumber(rs.Fields("iva").Value, 2)
                tb_otros_impuestos.Text = "$ " & FormatNumber(rs.Fields("otros").Value, 2)
                tb_total.Text = "$ " & FormatNumber(rs.Fields("total").Value, 2)
            End If
            rs.Close()
            Dim tipo_proveedor As Integer = 0
            rs.Open("SELECT proveedor.id_persona, CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) END AS razon_social" & _
                                " FROM proveedor LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa JOIN factura_compra ON factura_compra.id_proveedor=proveedor.id_proveedor WHERE proveedor.id_proveedor=" & id_proveedor, conn)
            cb_proveedor.Text = ""
            cb_proveedor.Items.Clear()
            cb_proveedor.Text = rs.Fields("razon_social").Value
            tipo_proveedor = rs.Fields("id_persona").Value
            rs.Close()

            rs.Open("SELECT CONCAT(persona.nombre,' ', persona.ap_paterno,' ',persona.ap_materno) As nombre FROM empleado JOIN persona ON persona.id_persona=empleado.id_persona WHERE empleado.id_empleado=" & empleado)
            cb_nombreReceptor.Text = rs.Fields("nombre").Value
            rs.Close()


            dgv_recepcion.Columns("cantidad").ReadOnly = True
            dgv_recepcion.Columns("precio").ReadOnly = True
            ' tb_fecha.Enabled = False
            cb_proveedor.Enabled = False
            gb_producto.Enabled = False
            gb_proveedor.Enabled = False
            gb_recepcion.Enabled = False
            m_guardar.Enabled = False
            m_nuevo.Enabled = True

            tabla.Clear()
            total_productos = 0

            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT factura_compra_detalle.*,producto.thumb,producto.codigo from factura_compra_detalle JOIN producto ON factura_compra_detalle.id_producto=producto.id_producto  WHERE id_factura_compra = " & id_compra, conn)
            While Not rs2.EOF

                agregar_producto(rs2.Fields("codigo").Value, rs2.Fields("descripcion").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, rs2.Fields("impuesto").Value, rs2.Fields("precio_unitario").Value, 0, obtener_miniatura(rs2.Fields("thumb").Value))

                rs2.MoveNext()
            End While
            rs2.Close()
            'conn.close()
        Else
            cb_proveedor.SelectedIndex = -1
            cb_proveedor.Text = ""
            cb_nombreReceptor.Text = ""
            cb_proveedor.Text = ""
            tabla.Clear()
            total_productos = 0

            dgv_recepcion.Columns("cantidad").ReadOnly = False
            dgv_recepcion.Columns("precio").ReadOnly = False
            id_proveedor = 0
            id_empleado = global_id_empleado

            ' Cotizacion
            'tb_numero_cotizacion.Text = "CT" & Date.Today.Year & "-000X"
            'tb_fecha.Value = Date.Today

            ' Total
            tb_subtotal.Text = "$ 0.00"
            tb_iva.Text = "$ 0.00"
            tb_total.Text = "$ 0.00"
            tb_otros_impuestos.Text = "$ 0.00"
            '
            'tb_empleado.Text = global_nombre
            'tb_puesto.Text = global_puesto

            'tb_fecha.Enabled = True
            cb_proveedor.Enabled = True
            m_guardar.Enabled = False
            gb_producto.Enabled = False
            gb_proveedor.Enabled = True
            gb_recepcion.Enabled = True
            'obtenemos el folio
            'Conectar()
            rs.Open("Select CASE when max(id_factura_compra) is null then 1 else max(id_factura_compra)+1 end  as folio from factura_compra", conn)
            tb_folio.Text = rs.Fields("folio").Value
            rs.Close()
            'conn.close()
            'conn = Nothing
            '-------------------
        End If

        tb_codigo.Focus()
    End Sub
    Private Sub llenar_Proveedores()
        cb_proveedor.Items.Clear()
        '====obtenemos la lista de proveedores====================================
        Dim total_persona As Integer = 0
        Dim total_empresa As Integer = 0
        With cb_proveedor
            i = 0
            tmp = 0
            .Text = ""
            .Items.Clear()
            'Conectar()
            rs.Open("SELECT pv.id_proveedor,if(pv.id_persona IS NULL,-1,pv.id_persona) id_persona, p.alias as nombre from persona p JOIN proveedor pv  ON pv.id_persona=p.id_persona ORDER BY p.nombre", conn)
            While Not rs.EOF
                .Items.Add(New MyItem(rs.Fields("id_proveedor").Value, rs.Fields("nombre").Value, 0, 0))
                If id_proveedor > 0 Then
                    If rs.Fields("id_cliente").Value = id_proveedor Then
                        tmp = i
                    End If
                End If
                i = i + 1
                rs.MoveNext()
            End While
            total_persona = rs.RecordCount
            rs.Close()

            rs.Open("SELECT pv.id_proveedor,if(pv.id_empresa IS NULL,-1,pv.id_empresa) id_empresa, e.alias from empresa e JOIN proveedor pv ON pv.id_empresa=e.id_empresa ORDER BY e.alias", conn)
            While Not rs.EOF
                .Items.Add(New MyItem(rs.Fields("id_proveedor").Value, rs.Fields("alias").Value, 1, 0))
                If id_proveedor > 0 Then
                    If rs.Fields("id_proveedor").Value = id_proveedor Then
                        tmp = i
                    End If
                End If
                i = i + 1
                rs.MoveNext()
            End While
            total_empresa = total_persona + rs.RecordCount
            rs.Close()
            'conn.close()
            If total_empresa > 0 Then
                If id_proveedor > 0 Then
                    .SelectedIndex = tmp
                Else
                    .SelectedIndex = 0
                End If
            End If
        End With
    End Sub
    Private Sub llenar_Almacenes()
        cb_almacen.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_almacen, nombre FROM almacenes", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_almacen.Items.Add(New myItem(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub llenar_Tipo_moneda()
        'cb_Moneda.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_moneda, siglas FROM moneda", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                ' cb_Moneda.Items.Add(New MyItem(rs.Fields("id_moneda").Value, rs.Fields("siglas").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub agregar_producto(ByVal codigo As String, ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal impuesto As String, ByVal precio As Decimal, ByVal precio_venta As Decimal, ByVal imagen As Object)
        total_productos = total_productos + 1
        tabla_linea = tabla.NewRow()
        tabla_linea("partida") = total_productos
        tabla_linea("codigo") = codigo
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
    Public Sub agregar_producto_proveedor(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Decimal = 0, Optional ByVal precio As Double = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0
        'Dim precio As Decimal = 0
        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + cantidad
            End If

            'If foundRows(0).Item("precio_especial") = 0 Then
            'rs.Open("select descuento from producto_volumen WHERE " & foundRows(0).Item("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
            'descuento = rs.Fields("descuento").Value
            'rs.Close()

            'If descuento > 0 Then
            'descuento = (CDec(foundRows(0).Item("precio")) * descuento) / 100
            'End If

            'End If

            'foundRows(0).Item("precio_venta") = CDec(foundRows(0).Item("precio")) - descuento
            foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio")), 2)

            'dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("precio_venta").Index, dg_cotizacion.CurrentRow.Index)
            dgv_recepcion.UpdateCellValue(dgv_recepcion.Columns.Item("importe").Index, dgv_recepcion.CurrentRow.Index)

        Else
            ''Conectar()
            Dim rs2 As New ADODB.Recordset
            'rs2.Open("SELECT precio FROM producto_proveedor WHERE id_producto='" & id & "' AND id_proveedor='" & CType(cb_cliente.SelectedItem, myItem).Value & "'", conn)
            '  If rs2.RecordCount > 0 Then
            '    precio = rs2.Fields("precio").Value
            'Else
            '    precio = 0
            'End If
            'rs2.Close()
            rs2.Open("SELECT DISTINCT producto.id_producto,producto.nombre,producto.codigo,descripcion,unidad.nombre AS unidad,thumb " & _
                    "FROM producto INNER JOIN unidad ON producto.id_unidad = unidad.id_unidad " & _
                    "INNER JOIN producto_sucursal ON producto.id_producto = producto_sucursal.id_producto  " & _
                    "WHERE producto.id_producto = " & id, conn)

            total_productos = total_productos + 1

            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id
            tabla_linea("partida") = total_productos
            tabla_linea("codigo") = rs2.Fields("codigo").Value
            tabla_linea("descripcion") = rs2.Fields("nombre").Value & vbCrLf '& rs2.Fields("descripcion").Value
            tabla_linea("imagen") = obtener_miniatura(rs2.Fields("thumb").Value)
            If cantidad > 0 Then
                tabla_linea("cantidad") = cantidad
            Else
                tabla_linea("cantidad") = 1
            End If

            tabla_linea("unidad") = rs2.Fields("Unidad").Value
            tabla_linea("precio") = precio
            ' tabla_linea("id_precio") = rs.Fields("id_precio").Value
            'tabla_linea("precio") = rs.Fields("precio").Value

            'If rs.Fields("precio_especial").Value > 0 Then
            'If Date.Today >= CType(rs.Fields("precio_especial_inicio").Value, Date) And Date.Today <= CType(rs.Fields("precio_especial_termino").Value, Date) Then
            'tabla_linea("precio_especial") = rs.Fields("precio_especial").Value
            ' tabla_linea("precio") = rs.Fields("precio_especial").Value
            'End If
            ' Else
            '   tabla_linea("precio_especial") = 0
            ' End If

            rs2.Close()
            ''conn.close()

            tabla_linea("impuesto") = ""

            rs2.Open("SELECT i.id_impuesto,i.alias,i.porcentaje from categoria_cat_imp cci JOIN producto p JOIN impuesto i " & _
                  "WHERE i.id_catalogo=cci.id_catalogo AND cci.id_categoria = p.id_categoria AND p.id_producto = " & id & " AND i.fecha_baja IS NULL " & _
                     "UNION SELECT i.id_impuesto,i.alias,i.porcentaje FROM producto p JOIN producto_cat_imp pci JOIN impuesto i " & _
                      "WHERE p.id_producto=pci.id_producto AND pci.id_catalogo = i.id_catalogo AND p.id_producto = " & id & " AND i.fecha_baja IS NULL", conn)
            Dim aux As String = ""
            Dim total_otros As Decimal = 0
            Dim total_iva As Decimal = 0
            i = 0
            While Not rs2.EOF
                If i = 0 Then
                    tabla_linea("impuesto") &= rs2.Fields("alias").Value & "(" & rs2.Fields("porcentaje").Value & ")"
                    aux = rs2.Fields("id_impuesto").Value
                Else
                    tabla_linea("impuesto") &= ", " & rs2.Fields("alias").Value & "(" & rs2.Fields("porcentaje").Value & ")"
                    aux &= "," & rs2.Fields("id_impuesto").Value
                End If

                If rs2.Fields("alias").Value = "IVA" Then
                    total_iva += rs2.Fields("porcentaje").Value
                Else
                    total_otros += rs2.Fields("porcentaje").Value
                End If

                rs2.MoveNext()
                i += 1
            End While

            tabla_linea("id_impuesto") = aux
            tabla_linea("total_iva") = total_iva
            tabla_linea("total_otros") = total_otros
            rs2.Close()

            'rs.Open("select descuento from producto_volumen WHERE " & tabla_linea("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
            'descuento = rs.Fields("descuento").Value
            'rs.Close()

            'If descuento > 0 Then
            'descuento = (tabla_linea("precio") * descuento) / 100
            '  End If

            ' tabla_linea("precio_venta") = tabla_linea("precio") - descuento
            tabla_linea("importe") = tabla_linea("precio") * tabla_linea("cantidad")

            tabla.Rows.Add(tabla_linea)
            m_guardar.Enabled = True
        End If
        actualizar_totales()
    End Sub

    Public Sub agregar_producto(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Integer = 0)

        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0
        Dim precio As Decimal = 0
        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If

            '=============VERIFICAMOS EL PRECIO ACTUAL DEL PRODUCTO==========================
            Dim asignado_proveedor As Boolean = True
            Dim _ultimo_precio As Decimal = 0
            rs.Open("SELECT precio_unitario FROM proveedor_productos WHERE id_producto='" & id & "' AND id_proveedor='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'", conn)
            If rs.RecordCount > 0 Then
                _ultimo_precio = rs.Fields("precio_unitario").Value
            Else
                _ultimo_precio = 0
                asignado_proveedor = False
            End If
            rs.Close()

            If asignado_proveedor = True Then
                If _ultimo_precio <> CDec(foundRows(0).Item("precio")) Then
                    If MsgBox("Desea guardar este  nuevo precio para el este proveedor", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        conn.Execute("UPDATE proveedor_productos SET precio_unitario='" & CDec(foundRows(0).Item("precio")) & "' WHERE id_producto='" & id & "' AND id_proveedor='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'")
                    End If

                    Dim requiere_promedio As Boolean = False
                    Dim suma As Decimal = 0
                    Dim costo_promedio As Decimal = 0
                    Dim costo As Decimal = 0
                    Dim cantidad_proveedores As Integer = 0

                    rs.Open("SELECT DISTINCT id_proveedor,precio_unitario FROM proveedor_productos WHERE id_producto=" & id & "", conn)
                    If rs.RecordCount > 0 Then
                        cantidad_proveedores = rs.RecordCount
                        If rs.RecordCount > 1 Then
                            requiere_promedio = True
                        End If
                        While Not rs.EOF
                            suma = suma + rs.Fields("precio_unitario").Value
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()

                    rs.Open("SELECT costo FROM producto WHERE id_producto='" & id & "'", conn)
                    If rs.RecordCount > 0 Then
                        costo = rs.Fields("costo").Value
                    End If
                    rs.Close()

                    If cantidad_proveedores > 0 Then
                        costo_promedio = suma / cantidad_proveedores
                    Else
                        costo_promedio = costo
                    End If


                    Dim precio_publico As Decimal = 0

                    rs.Open("SELECT precio FROM producto_precio WHERE id_producto='" & id & "'", conn)
                    If rs.RecordCount > 0 Then
                        precio_publico = rs.Fields("precio").Value
                    End If
                    rs.Close()

                    If requiere_promedio = True Then
                        If MsgBox("Existe mas de un proveedor para este producto, desea establecer el costo con un promedio de " & FormatCurrency(costo_promedio) & " ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

ACTUALIZAR_COSTO:           Dim ganancia As Decimal = 0
                            ganancia = CDec(((precio_publico - costo_promedio) / costo_promedio) * 100)

                            conn.Execute("UPDATE producto SET costo='" & costo_promedio & "' WHERE id_producto='" & id & "'")
                            conn.Execute("UPDATE producto_precio SET ganacia='" & ganancia & "' WHERE id_producto='" & id & "'")
                            conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES('" & id & "','" & costo_promedio & "','" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "')")

                            Dim rx As New ADODB.Recordset
                            rx.Open("SELECT id_descuento,descuento FROM producto_volumen WHERE id_producto='" & id & "' ORDER BY id_catalogo_precio DESC", conn)
                            If rx.RecordCount > 0 Then
                                Dim i As Integer = 1
                                While Not rx.EOF
                                    Dim precio_catalogo As Decimal = FormatNumber((precio_publico - (costo * (rx.Fields("descuento").Value / 100))), 2)
                                    Dim _descuento As Decimal = FormatNumber((((precio_publico - precio_catalogo) / costo_promedio) * 100), 2)
                                    conn.Execute("UPDATE producto_volumen SET descuento='" & _descuento & "' WHERE id_descuento='" & rx.Fields("id_descuento").Value & "'")
                                    rx.MoveNext()
                                End While
                            End If
                            rx.Close()

                        End If
                    Else
                        GoTo ACTUALIZAR_COSTO
                    End If

                End If
            Else
                Dim nuevo_costo As Decimal = CDec(foundRows(0).Item("precio"))
                Dim costo_anterior As Decimal = 0
                Dim precio_publico As Decimal = 0
                Dim ganancia As Decimal = 0

                rs.Open("SELECT costo FROM producto WHERE id_producto='" & id & "'", conn)
                If rs.RecordCount > 0 Then
                    costo_anterior = rs.Fields("costo").Value
                End If
                rs.Close()

                If costo_anterior <> nuevo_costo Then
                    If MsgBox("Este producto no se encuentra relacionado con algun proveedor, Desea actualizar el costo del producto?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                        rs.Open("SELECT precio FROM producto_precio WHERE id_producto='" & id & "'", conn)
                        If rs.RecordCount > 0 Then
                            precio_publico = rs.Fields("precio").Value
                        End If
                        rs.Close()

                        ganancia = CDec(((precio_publico - nuevo_costo) / nuevo_costo) * 100)

                        conn.Execute("UPDATE producto SET costo='" & nuevo_costo & "' WHERE id_producto='" & id & "'")
                        conn.Execute("UPDATE producto_precio SET ganacia='" & ganancia & "' WHERE id_producto='" & id & "'")
                        conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES('" & id & "','" & nuevo_costo & "','" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "')")

                        Dim rx As New ADODB.Recordset
                        rx.Open("SELECT id_descuento,descuento FROM producto_volumen WHERE id_producto='" & id & "' ORDER BY id_catalogo_precio DESC", conn)
                        If rx.RecordCount > 0 Then
                            Dim i As Integer = 1
                            While Not rx.EOF
                                Dim precio_catalogo As Decimal = FormatNumber((precio_publico - (nuevo_costo * (rx.Fields("descuento").Value / 100))), 2)
                                Dim _descuento As Decimal = FormatNumber((((precio_publico - precio_catalogo) / nuevo_costo) * 100), 2)
                                conn.Execute("UPDATE producto_volumen SET descuento='" & _descuento & "' WHERE id_descuento='" & rx.Fields("id_descuento").Value & "'")
                                rx.MoveNext()
                            End While
                        End If
                        rx.Close()

                    End If
                End If
            End If

            'If foundRows(0).Item("precio_especial") = 0 Then
            'rs.Open("select descuento from producto_volumen WHERE " & foundRows(0).Item("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
            'descuento = rs.Fields("descuento").Value
            'rs.Close()

            'If descuento > 0 Then
            'descuento = (CDec(foundRows(0).Item("precio")) * descuento) / 100
            'End If

            'End If

            'foundRows(0).Item("precio_venta") = CDec(foundRows(0).Item("precio")) - descuento
            foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio")), 2)

            'dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("precio_venta").Index, dg_cotizacion.CurrentRow.Index)
            dgv_recepcion.UpdateCellValue(dgv_recepcion.Columns.Item("importe").Index, dgv_recepcion.CurrentRow.Index)

        Else
            'Conectar()
            Dim precio_encontrado As Boolean = True
            rs.Open("SELECT precio_unitario FROM proveedor_productos WHERE id_producto='" & id & "' AND id_proveedor='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'", conn)
            If rs.RecordCount > 0 Then
                precio = rs.Fields("precio_unitario").Value
            Else
                precio = 0
                precio_encontrado = False
            End If
            rs.Close()

            If precio_encontrado = False Then
                rs.Open("SELECT costo FROM producto WHERE id_producto='" & id & "'", conn)
                If rs.RecordCount > 0 Then
                    precio = rs.Fields("costo").Value
                End If
                rs.Close()
            End If


            rs.Open("SELECT DISTINCT producto.id_producto, producto.nombre,descripcion,producto.codigo,producto.thumb,unidad.nombre AS unidad " & _
                    "FROM producto INNER JOIN unidad ON producto.id_unidad = unidad.id_unidad " & _
                    "INNER JOIN producto_sucursal ON producto.id_producto = producto_sucursal.id_producto  " & _
                    "WHERE producto.id_producto = " & id, conn)

            total_productos = total_productos + 1

            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id
            tabla_linea("partida") = total_productos
            tabla_linea("codigo") = rs.Fields("codigo").Value
            tabla_linea("imagen") = obtener_miniatura(rs.Fields("thumb").Value)
            tabla_linea("descripcion") = rs.Fields("nombre").Value '& vbCrLf & rs.Fields("descripcion").Value

            If cantidad > 0 Then
                tabla_linea("cantidad") = cantidad
            Else
                tabla_linea("cantidad") = 1
            End If

            tabla_linea("unidad") = rs.Fields("Unidad").Value
            tabla_linea("precio") = precio
            ' tabla_linea("id_precio") = rs.Fields("id_precio").Value
            'tabla_linea("precio") = rs.Fields("precio").Value

            'If rs.Fields("precio_especial").Value > 0 Then
            'If Date.Today >= CType(rs.Fields("precio_especial_inicio").Value, Date) And Date.Today <= CType(rs.Fields("precio_especial_termino").Value, Date) Then
            'tabla_linea("precio_especial") = rs.Fields("precio_especial").Value
            ' tabla_linea("precio") = rs.Fields("precio_especial").Value
            'End If
            ' Else
            '   tabla_linea("precio_especial") = 0
            ' End If

            rs.Close()
            ' 'conn.close()

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
            'rs.Open("select descuento from producto_volumen WHERE " & tabla_linea("cantidad") & " between rango_inicial and rango_final AND id_producto = " & id, conn)
            'descuento = rs.Fields("descuento").Value
            'rs.Close()

            'If descuento > 0 Then
            'descuento = (tabla_linea("precio") * descuento) / 100
            '  End If

            tabla_linea("precio_venta") = tabla_linea("precio")
            tabla_linea("importe") = tabla_linea("precio") * tabla_linea("cantidad")

            tabla.Rows.Add(tabla_linea)
            m_guardar.Enabled = True
        End If
        actualizar_totales()
    End Sub

    Private Sub actualizar_partida()
        Dim j As Integer

        For j = 0 To dgv_recepcion.RowCount - 1
            dgv_recepcion.Rows(j).Cells("partida").Value = j + 1
            total_productos = j + 1
        Next
    End Sub
    Private Sub actualizar_totales()
        Dim j As Integer
        importe = 0
        subtotal = 0
        total_iva = 0
        total_otros = 0

        For j = 0 To dgv_recepcion.RowCount - 1
            importe = importe + CDec(dgv_recepcion.Rows(j).Cells("importe").Value)
            subtotal = subtotal + CDec(dgv_recepcion.Rows(j).Cells("importe").Value)

            If CDec(dgv_recepcion.Rows(j).Cells("total_iva").Value) > 0 Then
                total_iva += (CDec(dgv_recepcion.Rows(j).Cells("importe").Value) * CDec(dgv_recepcion.Rows(j).Cells("total_iva").Value)) / 100
            End If

            If CDec(dgv_recepcion.Rows(j).Cells("total_iva").Value) > 0 Then
                total_otros += (CDec(dgv_recepcion.Rows(j).Cells("importe").Value) * CDec(dgv_recepcion.Rows(j).Cells("total_otros").Value)) / 100
            End If

        Next
        tb_subtotal.Text = "$ " & FormatNumber(subtotal, 2)
        tb_otros_impuestos.Text = "$ " & FormatNumber(total_otros, 2)
        tb_iva.Text = "$ " & FormatNumber(total_iva, 2)
        tb_total.Text = "$ " & FormatNumber(subtotal + total_otros + total_iva, 2)
    End Sub

    Private Sub cb_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_proveedor.KeyDown
        cb_proveedor.DroppedDown = False

        If e.KeyCode = Keys.Return Then
            Dim proveedor_encontrado As Boolean = False
            Dim id_proveedor_encontrado As Integer = 0
            If Trim(cb_proveedor.Text) <> "" Then
                rs.Open("SELECT id_proveedor FROM proveedor WHERE clave='" & cb_proveedor.Text & "'", conn)
                If rs.RecordCount > 0 Then
                    id_proveedor_encontrado = rs.Fields("id_proveedor").Value
                    proveedor_encontrado = True
                End If
                rs.Close()
                If proveedor_encontrado = True Then
                    seleccionar_proveedor(id_proveedor_encontrado)
                    tb_NFactura.Focus()
                    tb_NFactura.SelectAll()
                Else
                    'MsgBox("No se encontraron coincidencias", MsgBoxStyle.Information, "Aviso")
                    'frm_aviso.showdialog()
                End If
            End If
        End If
    End Sub
    Private Sub seleccionar_proveedor(ByVal id_proveedor As Integer)
        For x = 0 To cb_proveedor.Items.Count - 1
            If id_proveedor = CType(cb_proveedor.Items(x), myItem).Value Then
                cb_proveedor.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub cb_cliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_proveedor.SelectedIndexChanged
        If cb_proveedor.SelectedIndex >= 0 Then
            gb_producto.Enabled = True
            id_proveedor = CType(cb_proveedor.SelectedItem, myItem).Value
            cliente_descuento = CType(cb_proveedor.SelectedItem, myItem).Opcional2

            '---cargamos los productos del cliente

            tabla.Clear()
            total_productos = 0
            'Conectar()
            rs.Open("SELECT * from proveedor_productos WHERE id_proveedor = " & id_proveedor, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_producto_proveedor(rs.Fields("id_producto").Value, , rs.Fields("cantidad").Value, rs.Fields("precio_unitario").Value)
                    rs.MoveNext()
                End While
            End If

            rs.Close()
            'conn.close()
            '-------------------------------------
        End If
    End Sub
    Private Sub m_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_nuevo.Click
        cargar()
    End Sub

    Private Sub m_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_abrir.Click
        global_frm_cotizacion_abrir = 1
        frm_producto_recepcion_abrir.ShowDialog()
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
                If total_productos > 0 Then
                    m_guardar.Enabled = True
                End If
            Else
                rs.Close()
                'conn.close()
                tb_codigo.Text = ""
                MsgBox("Codigo del Producto no encontrado", MsgBoxStyle.Information)
            End If
        End If
        tb_codigo.Focus()
    End Sub

    Private Sub tb_codigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_codigo.Click
        no_campo = 1
    End Sub

    Private Sub tb_codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_codigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_agregar_Click(sender, e)
        End If
    End Sub

    Private Sub dg_cotizacion_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        dg_cotizacion_CellValueChanged(sender, e)
    End Sub
    Private Sub dg_cotizacion_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs)
        If id_compra = 0 Then
            Dim newInteger As Integer
            If dgv_recepcion.Rows(e.RowIndex).IsNewRow Then Return
            If dgv_recepcion.Columns("cantidad").Index = e.ColumnIndex Then
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

    Private Sub dg_cotizacion_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_recepcion.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        For x = 0 To dgv_recepcion.Columns.Count - 1
            If dgv_recepcion.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
    Private Sub dg_cotizacion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_recepcion.CellValueChanged
        If cargado Then
            agregar_producto(dgv_recepcion.Rows(dgv_recepcion.CurrentRow.Index).Cells("id_producto").Value, True)
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
    Private Sub celda_pbk(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.FromArgb(255, 102, 0)
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        ' objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    End Sub

    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_guardar.Click
        'Dim tipo_pago As String
        Dim numeroF As String = ""
        ' Dim fecha_vencimiento As String

        '===verificamos todos los campos================
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf
        'If cb_almacen.SelectedIndex = -1 Then
        'cadena = cadena & "  * Selecione el almacen" & vbCrLf
        'bandera_correcto = False
        'End If
        If cb_proveedor.SelectedIndex = -1 Then
            cadena = cadena & "  * Seleccione el proveedor" & vbCrLf
            bandera_correcto = False
        End If
        ' If cb_Moneda.SelectedIndex = -1 Then
        'cadena = cadena & "  * Seleccione tipo de moneda" & vbCrLf
        'bandera_correcto = False
        'End If
        If tb_NFactura.Text = "" Then
            cadena = cadena & "  *Nº de factura" & vbCrLf
            bandera_correcto = False
        End If
        If cb_nombreReceptor.SelectedIndex = -1 Then
            cadena = cadena & "  *Persona que recibe" & vbCrLf
            bandera_correcto = False
        End If

        rs.Open("SELECT id_factura_compra FROM factura_compra WHERE folio= '" & tb_NFactura.Text & "' AND id_proveedor ='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'", conn)
        If rs.RecordCount > 0 Then
            cadena = cadena & "  *Este folio remision del proveedor ya existe en el sistema" & vbCrLf
            bandera_correcto = False
        End If
        rs.Close()
        '=========================================
        If bandera_correcto = True Then
            rs.Open("SELECT COUNT(numero)  AS numero FROM factura_compra  WHERE id_proveedor='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'", conn)
            Dim rs2 As New ADODB.Recordset

            If rs.Fields("numero").Value = 0 Then
                rs2.Open("SELECT CASE WHEN proveedor.id_persona = 0 THEN " & _
                                          "CONCAT(UPPER(CONCAT(SUBSTRING(SUBSTRING_INDEX(SUBSTRING_INDEX(razon_social,' ',2),' ',1),1,1),SUBSTRING(SUBSTRING(SUBSTRING_INDEX(razon_social,' ',2),CHAR_LENGTH(SUBSTRING_INDEX(razon_social,' ',1))+2),1,1))),'0001') " & _
                                          "ELSE  CONCAT(UPPER(CONCAT(SUBSTRING(SUBSTRING_INDEX(nombre,' ',1),1,1),SUBSTRING(ap_paterno,1,1),SUBSTRING(ap_materno,1,1))),'0001') END AS numero " & _
                                          "FROM proveedor LEFT OUTER  JOIN empresa ON proveedor.id_empresa = empresa.id_empresa LEFT OUTER  JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                                          "WHERE proveedor.id_proveedor='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'", conn)

                numeroF = rs2.Fields("numero").Value
                rs2.Close()
            Else
                rs2.Open("SELECT CASE WHEN proveedor.id_persona = 0 THEN " & _
                                              "CONCAT(UPPER(CONCAT(SUBSTRING(SUBSTRING_INDEX(SUBSTRING_INDEX(razon_social,' ',2),' ',1),1,1),SUBSTRING(SUBSTRING(SUBSTRING_INDEX(razon_social,' ',2),CHAR_LENGTH(SUBSTRING_INDEX(razon_social,' ',1))+2),1,1))),'" & Format((rs.Fields("numero").Value + 1), "0000") & "') " & _
                                              "ELSE  CONCAT(UPPER(CONCAT(SUBSTRING(SUBSTRING_INDEX(nombre,' ',1),1,1),SUBSTRING(ap_paterno,1,1),SUBSTRING(ap_materno,1,1))),'" & Format((rs.Fields("numero").Value + 1), "0000") & "') END AS numero " & _
                                              "FROM proveedor LEFT OUTER  JOIN empresa ON proveedor.id_empresa = empresa.id_empresa LEFT OUTER  JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                                              "WHERE proveedor.id_proveedor='" & CType(cb_proveedor.SelectedItem, myItem).Value & "'", conn)

                numeroF = rs2.Fields("numero").Value
                rs2.Close()
            End If

            rs.Close()
            'conn.close()

            Dim total = subtotal + total_iva + total_otros

            '---agregamos la factura_compra-----------------
            'Conectar()

            'conn.Execute("INSERT INTO factura_compra (fecha,numero,importe,subtotal,otros,iva,total,descuento,folio,id_proveedor,id_moneda,id_sucursal,id_empleado_captura,fecha_remision) VALUES" & _
            '         " ('" & Format(dtp_fecha_recepcion.Value, "yyyy-MM-dd hh:mm:ss") & "', '" & numeroF & "', '" & importe & "', '" & subtotal & "', '" & total_otros & "', '" & total_iva & "', '" & total & "', '0', '" & tb_NFactura.Text & "','" & CType(cb_proveedor.SelectedItem, myItem).Value & "','" & CType(cb_Moneda.SelectedItem, myItem).Value & "','" & global_id_sucursal & "','" & global_id_empleado & "','" & Format(dtp_fecha_remision.Value, "yyyy-MM-dd") & "')", , -1)
            'Dim id_factura_compra As Integer

            rs.Open("SELECT last_insert_id() id_factura_compra", conn)
            'id_factura_compra = rs.Fields("id_factura_compra").Value
            rs.Close()
            For row = 0 To tabla.Rows.Count - 1
                Dim id_almacen = obtener_idalmacen(dgv_recepcion.Item("id_producto", row).Value)

                ' conn.Execute("INSERT INTO factura_compra_detalle(id_factura_compra,id_producto,descripcion,cantidad,unidad,impuesto,precio_unitario) VALUES " & _
                '         " (" & id_factura_compra & "," & dgv_recepcion.Item("id_producto", row).Value & ",'" & dgv_recepcion.Item("descripcion", row).Value & "'," & dgv_recepcion.Item("cantidad", row).Value & ",'" & dgv_recepcion.Item("unidad", row).Value & "','','" & CDec(dgv_recepcion.Item("precio", row).Value) & "')", , -1)
                'conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & dgv_recepcion.Item("cantidad", row).Value & ") WHERE id_producto=" & dgv_recepcion.Item("id_producto", row).Value & " AND id_almacen=" & id_almacen & "")
            Next
            'conn.Execute("INSERT into producto_recepcion(id_sucursal,id_empleado,id_factura_compra,fecha_recepcion) VALUES " & _
            '                " (" & global_id_sucursal & "," & CType(cb_nombreReceptor.SelectedItem, myItem).Value & ",'" & id_factura_compra & "','" & Format(dtp_fecha_recepcion.Value, "yyyy-MM-dd hh:mm:ss") & "')", , -1)

            'conn.close()
            'conn = Nothing
            'cargar(id_factura_compra)
            MsgBox("Los datos han sido guardados satisfactoriamente", MsgBoxStyle.Information, "Correcto")
            'Conectar()
        Else
            MsgBox(cadena)
        End If


    End Sub
    Private Function obtener_idalmacen(ByVal id_producto As Integer) As Integer
        Dim id_almacen As Integer = 0
        rs.Open("SELECT id_almacen FROM producto WHERE id_producto=" & id_producto, conn)
        If rs.RecordCount > 0 Then
            id_almacen = rs.Fields("id_almacen").Value
        End If
        rs.Close()
        Return id_almacen
    End Function

    Private Sub frm_compras_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If cargado Then
            If Me.Width > 1100 Then
                dgv_recepcion.Columns("descripcion").Width = 40 + Me.Width - 900
            Else
                dgv_recepcion.Columns("descripcion").Width = 250
            End If
        End If
    End Sub
    Private Sub dg_cotizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_recepcion.DoubleClick
        If id_compra = 0 Then
            If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                dgv_recepcion.Rows.RemoveAt(dgv_recepcion.CurrentRow.Index)
                If dgv_recepcion.Rows.Count = 0 Then
                    total_productos = 0
                    m_guardar.Enabled = False
                End If
                actualizar_partida()
                actualizar_totales()
            End If
        End If
    End Sub
    Private Sub btn_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_imprimir.Click
        Dim x As Integer
        If MsgBox("A continuación se imprimirá el ticket de recepción de producto. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            For x = 0 To 1
                imprimir_compra_producto(id_compra, x)
            Next
        Else
            imprimir_compra_producto(id_compra, 0)
        End If


    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If no_campo = 1 Then
                tb_codigo.Focus()
                SendKeys.Send(CType(sender, Button).Text)
            ElseIf no_campo = 2 Then
                tb_NFactura.Focus()
                SendKeys.Send(CType(sender, Button).Text)
            End If
        End If
    End Sub
    Private Sub dg_cotizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_recepcion.Click
        If dgv_recepcion.Rows.Count > 0 Then
            If dgv_recepcion.CurrentCell.ColumnIndex = 4 Then
                If id_compra = 0 Then
                    If chb_teclado.CheckState = 1 Then
                        frm_teclado_numerico.modo = 1
                        frm_teclado_numerico.ShowDialog()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If no_campo = 1 Then
            btn_agregar_Click(sender, e)
        End If
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If no_campo = 1 Then
            tb_codigo.Text = ""
        ElseIf no_campo = 2 Then
            tb_NFactura.Text = ""
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If no_campo = 1 Then
            If tb_codigo.TextLength > 0 Then
                tb_codigo.Text = tb_codigo.Text.Remove(tb_codigo.TextLength - 1, 1)
                tb_codigo.SelectionStart = Len(tb_codigo.Text)
            End If
        ElseIf no_campo = 2 Then
            If tb_NFactura.TextLength > 0 Then
                tb_NFactura.Text = tb_NFactura.Text.Remove(tb_NFactura.TextLength - 1, 1)
                tb_NFactura.SelectionStart = Len(tb_NFactura.Text)
            End If
        End If
    End Sub

    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        frm_producto_busqueda._modo = 1
        frm_producto_busqueda.Show()
    End Sub
    Private Sub tb_NFactura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_NFactura.Click
        no_campo = 2
    End Sub

    Public Sub modificar_cantidad(ByVal cantidad As Decimal)
        dgv_recepcion.Rows(dgv_recepcion.CurrentRow.Index).Cells("cantidad").Value = cantidad
        dgv_recepcion.Rows(dgv_recepcion.CurrentRow.Index).Cells("importe").Value = cantidad * dgv_recepcion.Rows(dgv_recepcion.CurrentRow.Index).Cells("precio").Value
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub dg_cotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_recepcion.KeyDown
        If id_compra = 0 Then
            If e.KeyCode = 46 Then
                actualizar_totales()
            End If
        End If
    End Sub

    Private Function tb_precio_especial() As Object
        Throw New NotImplementedException
    End Function

    Private Sub btn_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_reset.Click
        For row = 0 To tabla.Rows.Count - 1
            dgv_recepcion.Rows(row).Cells("cantidad").Value = 0
            dgv_recepcion.Rows(row).Cells("importe").Value = dgv_recepcion.Rows(row).Cells("cantidad").Value * dgv_recepcion.Rows(row).Cells("precio").Value
        Next
        actualizar_totales()
    End Sub

    Private Sub cb_nombreReceptor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_nombreReceptor.KeyDown
        cb_nombreReceptor.DroppedDown = False
    End Sub

    Private Sub dgv_recepcion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_recepcion.CellContentClick

    End Sub
End Class