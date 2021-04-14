Public Class frm_cotizacion
    Dim id_cotizacion As Integer = 0
    Dim id_cliente As Integer = 0
    Dim id_empleado As Integer = 0
    Dim id_catalogo_precio As Integer = 0
    Dim cliente_descuento As Decimal = 0
    Dim i As Integer
    Dim tmp As Integer

    Dim total_productos As Integer = 0

    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim cargado As Boolean = False
    Private Sub frm_cotizacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        'habilitar_menu_ventana()
        global_frm_cotizacion = 0
    End Sub
    Private Sub cargar_tipos_precio()
        cb_tipo_precio.Items.Clear()
        cb_tipo_precio.Items.Add(New myItem(0, "PUBLICO EN GENERAL"))
        'Conectar()
        rs.Open("SELECT id_catalogo_precio,nombre FROM catalogo_precios", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_tipo_precio.Items.Add(New myItem(rs.Fields("id_catalogo_precio").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub frm_cotizacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.MdiParent = frm_principal
        ' habilitar_menu_ventana()
        global_frm_cotizacion = 1


        tabla = New DataTable("cotizacion")

        With tabla.Columns
            .Add(New DataColumn("partida", GetType(Integer)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Integer)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("impuesto", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))
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
                .Width = 250
                .ReadOnly = True
            End With
            With .Columns("impuesto")
                .HeaderText = "Impuestos"
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unitario"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
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
        tb_mensaje.Enabled = False
        tb_despedida.Enabled = False
        cargar_tipos_precio()
        seleccionar_id_catalogo_precio(0)
        cargado = True
    End Sub
    Public Sub seleccionar_id_catalogo_precio(ByVal id_catalogo_precio As Integer)
        For x = 0 To cb_tipo_precio.Items.Count - 1
            If id_catalogo_precio = CType(cb_tipo_precio.Items(x), myItem).Value Then
                cb_tipo_precio.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Public Sub cargar(Optional ByVal id As Integer = 0)
        Panel1.Enabled = True
        id_cotizacion = id

        ' Cliente
        tb_domicilio.Text = ""
        tb_email.Text = ""
        Dim nombre_cliente As String = ""
        If id_cotizacion > 0 Then
            'Conectar()
            rs.Open("SELECT id_cotizacion,numero,total,subtotal,iva,otros,id_cliente,id_empleado,fecha,year(fecha) anio,id_catalogo_precio,mensaje,despedida,nombre_cliente,fecha FROM cotizacion where id_cotizacion = " & id_cotizacion, conn)
            id_cliente = rs.Fields("id_cliente").Value
            id_empleado = rs.Fields("id_empleado").Value
            tb_numero_cotizacion.Text = "CT" & rs.Fields("anio").Value & "-" & Format(CInt(rs.Fields("numero").Value), "0000")
            Dim fecha As Date = rs.Fields("fecha").Value
            tb_fecha.Value = fecha
            tb_mensaje.Text = rs.Fields("mensaje").Value
            tb_despedida.Text = rs.Fields("despedida").Value
            seleccionar_id_catalogo_precio(rs.Fields("id_catalogo_precio").Value)
            nombre_cliente = rs.Fields("nombre_cliente").Value
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
            'conn.close()
            'conn = Nothing

            m_exportar.Enabled = True
            btn_generar_cotizacion_pdf.Visible = True
            tb_mensaje.Enabled = False
            tb_despedida.Enabled = False


            dg_cotizacion.Columns("cantidad").ReadOnly = True
            tb_fecha.Enabled = False
            cb_cliente.Enabled = False
            gp_agregar.Enabled = False
            m_guardar.Enabled = False

            tabla.Clear()
            total_productos = 0

            'Conectar()
            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT * from cotizacion_detalle WHERE id_cotizacion = " & id_cotizacion, conn)
            While Not rs2.EOF

                agregar_producto(rs2.Fields("descripcion").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, rs2.Fields("impuesto").Value, rs2.Fields("precio_unitario").Value)

                rs2.MoveNext()
            End While
            rs2.Close()
            'conn.close()
            'conn = Nothing

        Else
            tabla.Clear()
            total_productos = 0

            dg_cotizacion.Columns("cantidad").ReadOnly = False
            id_cliente = 0
            id_empleado = global_id_empleado

            ' Cotizacion
            tb_numero_cotizacion.Text = "CT" & Date.Today.Year & "-000X"
            tb_fecha.Value = Date.Today

            ' Total
            tb_subtotal.Text = "$ 0.00"
            tb_iva.Text = "$ 0.00"
            tb_total.Text = "$ 0.00"
            tb_otros_impuestos.Text = "$ 0.00"

            tb_mensaje.Text = ""
            tb_despedida.Text = ""

            tb_empleado.Text = global_nombre
            tb_puesto.Text = global_puesto

            m_exportar.Enabled = False


            tb_fecha.Enabled = True
            cb_cliente.Enabled = True
            m_guardar.Enabled = False
            gp_agregar.Enabled = True

            btn_generar_cotizacion_pdf.Visible = False
            tb_mensaje.Enabled = True
            tb_despedida.Enabled = True
            tb_mensaje.Text = ""
            tb_despedida.Text = ""
        End If


        Dim total_persona As Integer = 0
        Dim total_empresa As Integer = 0

        'Conectar()
        With cb_cliente
            i = 0
            tmp = 0
            .Text = ""
            .Items.Clear()
            rs.Open("SELECT c.id_cliente,if(c.id_persona IS NULL,-1,c.id_persona) id_persona,ct.descuento, p.alias as nombre from persona p JOIN cliente c JOIN cliente_tipo ct ON c.id_persona=p.id_persona AND ct.id_tipo=c.id_tipo ORDER BY p.nombre", conn)
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
            'conn.close()
            'conn = Nothing

            If total_empresa > 0 Then
                If id_cliente > 0 Then
                    .SelectedIndex = tmp
                Else
                    '.SelectedIndex = 0
                    .Text = nombre_cliente
                End If
            End If
        End With

        tb_codigo.Focus()
    End Sub

    Private Sub agregar_producto(ByVal descripcion As String, ByVal cantidad As Integer, ByVal unidad As String, ByVal impuesto As String, ByVal precio As Decimal)
        total_productos = total_productos + 1
        tabla_linea = tabla.NewRow()
        tabla_linea("partida") = total_productos
        tabla_linea("descripcion") = descripcion
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla_linea("impuesto") = impuesto
        tabla_linea("precio") = precio
        tabla_linea("importe") = precio * cantidad
        tabla.Rows.Add(tabla_linea)
    End Sub

    Public Sub agregar_producto(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Integer = 0)

        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If

            foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * CDec(foundRows(0).Item("precio")), 2)

            dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("precio").Index, dg_cotizacion.CurrentRow.Index)
            dg_cotizacion.UpdateCellValue(dg_cotizacion.Columns.Item("importe").Index, dg_cotizacion.CurrentRow.Index)

        Else
            'Conectar()
            rs.Open("SELECT DISTINCT p.id_producto, p.nombre, p.descripcion, u.nombre unidad, pp.id_precio, pp.precio, ps.precio_especial_termino, ps.precio_especial_inicio, ps.precio_especial " & _
                    "FROM producto p, unidad u,producto_precio pp, producto_sucursal ps " & _
                    "WHERE(ps.id_precio = pp.id_precio) " & _
                    "AND pp.id_producto = p.id_producto " & _
                    "AND p.id_unidad=u.id_unidad AND p.id_producto=" & id, conn)

            total_productos = total_productos + 1

            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id
            tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = rs.Fields("nombre").Value & vbCrLf & rs.Fields("descripcion").Value

            If cantidad > 0 Then
                tabla_linea("cantidad") = cantidad
            Else
                tabla_linea("cantidad") = 1
            End If

            tabla_linea("unidad") = rs.Fields("unidad").Value

            tabla_linea("id_precio") = rs.Fields("id_precio").Value

            If cb_tipo_precio.SelectedIndex <> -1 Then
                id_catalogo_precio = CType(cb_tipo_precio.SelectedItem, myItem).Value
            End If


            '---cargamos precios del combo
            tabla_linea("precio") = obtener_precio_producto(id, id_catalogo_precio)

            If rs.Fields("precio_especial").Value > 0 Then
                If Date.Today >= CType(rs.Fields("precio_especial_inicio").Value, Date) And Date.Today <= CType(rs.Fields("precio_especial_termino").Value, Date) Then
                    tabla_linea("precio_especial") = rs.Fields("precio_especial").Value
                    tabla_linea("precio") = rs.Fields("precio_especial").Value
                End If
            Else
                tabla_linea("precio_especial") = 0
            End If

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

            tabla_linea("importe") = tabla_linea("precio") * tabla_linea("cantidad")

            tabla.Rows.Add(tabla_linea)
            'conn.close()
            'conn = Nothing
        End If
        If total_productos > 0 Then
            m_guardar.Enabled = True
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

    Private Sub cb_cliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_cliente.KeyDown
        cb_cliente.DroppedDown = False
    End Sub

    Private Sub cb_cliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cliente.SelectedIndexChanged
        Dim rx As New ADODB.Recordset
        If cb_cliente.SelectedIndex <> -1 Then
            id_cliente = CType(cb_cliente.SelectedItem, myItem).Value
            cliente_descuento = CType(cb_cliente.SelectedItem, myItem).Opcional2

            If CType(cb_cliente.SelectedItem, myItem).Opcional = 0 Then
                'Conectar()
                rx.Open("SELECT p.email, concat(d.calle,' ',if(d.cp='','',concat(' C.P. ',d.cp)) ) domicilio FROM cliente c, domicilio d, persona p WHERE p.id_persona=c.id_persona AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rx.Fields("domicilio").Value
                lb_email.Text = "Email:"
                tb_email.Text = rx.Fields("email").Value
                rx.Close()
                pb_url.Visible = False
                With cb_telefono
                    .Items.Clear()
                    .Text = ""
                    rx.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, persona_tel pt,telefono t WHERE t.id_telefono=pt.id_telefono AND pt.id_persona=c.id_persona AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                    If rx.RecordCount > 0 Then
                        While Not rx.EOF
                            cb_telefono.Items.Add(rx.Fields("telefono").Value)
                            rx.MoveNext()
                        End While
                        cb_telefono.Enabled = True
                        cb_telefono.DropDownStyle = ComboBoxStyle.DropDownList
                        .SelectedIndex = 0
                    Else
                        cb_telefono.Enabled = False
                    End If
                    rx.Close()
                End With
                'conn.close()
                'conn = Nothing
            ElseIf CType(cb_cliente.SelectedItem, myItem).Opcional = 1 Then
                'Conectar()
                rx.Open("SELECT e.url, concat(d.calle,' ',if(d.cp='','',concat(' C.P. ',d.cp)) ) domicilio FROM cliente c, domicilio d, empresa e WHERE e.id_empresa=c.id_empresa AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rx.Fields("domicilio").Value
                lb_email.Text = "U r l:"
                tb_email.Text = rx.Fields("url").Value
                rx.Close()
                pb_url.Visible = True

                With cb_telefono
                    .Items.Clear()
                    .Text = ""
                    rx.Open("SELECT concat(t.lada,' ', t.numero) telefono FROM cliente c, empresa_tel et,telefono t WHERE t.id_telefono=et.id_telefono AND et.id_empresa=c.id_empresa AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                    If rx.RecordCount > 0 Then
                        While Not rx.EOF
                            cb_telefono.Items.Add(rx.Fields("telefono").Value)
                            rx.MoveNext()
                        End While
                        cb_telefono.Enabled = True
                        cb_telefono.DropDownStyle = ComboBoxStyle.DropDownList
                        .SelectedIndex = 0
                    Else
                        cb_telefono.Enabled = False
                    End If
                    rx.Close()
                End With
                'conn.close()
                'conn = Nothing
            End If
            'Conectar()
            rx.Open("SELECT id_catalogo_precio FROM cliente_precio WHERE id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
            If rx.RecordCount > 0 Then
                seleccionar_id_catalogo_precio(rx.Fields("id_catalogo_precio").Value)
            End If
            rx.Close()
            'conn.close()
            'conn = Nothing
        End If
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
        global_frm_producto_abrir = 1
        frm_cotizacion_abrir.ShowDialog()
    End Sub

    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bucar.Click
        global_frm_producto_abrir = 1
        frm_producto_abrir.ShowDialog()
    End Sub

    Private Sub btn_agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar.Click
        Dim id_producto As Integer = 0
        If Trim(tb_codigo.Text) <> "" Then
            'Conectar()
            rs.Open("select id_producto from producto WHERE codigo='" & Trim(tb_codigo.Text) & "'", conn)
            If rs.RecordCount > 0 Then

                id_producto = rs.Fields("id_producto").Value
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            If id_producto <> 0 Then
                tb_codigo.Text = ""
                agregar_producto(id_producto)
            Else
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
        If id_cotizacion = 0 Then
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
    Private Sub dg_cotizacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellDoubleClick
        If id_cotizacion = 0 Then
            If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                dg_cotizacion.Rows.RemoveAt(dg_cotizacion.CurrentRow.Index)
                If dg_cotizacion.Rows.Count = 0 Then
                    total_productos = 0
                    m_guardar.Enabled = False
                End If
                actualizar_partida()
                actualizar_totales()
            End If
        End If
    End Sub
    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_guardar.Click
        'Conectar()
        Dim numero As Integer
        conn.BeginTrans()
        Try
            If cb_cliente.SelectedIndex = -1 Then
                id_cliente = 0
            Else
                id_cliente = CType(cb_cliente.SelectedItem, myItem).Value
            End If

            rs.Open("SELECT IF(MAX(numero) IS NULL,1,MAX(numero)+1) numero from cotizacion WHERE YEAR(fecha) = '" & Date.Today.Year & "'", conn)
            numero = rs.Fields("numero").Value
            rs.Close()

            conn.Execute("INSERT INTO Cotizacion (fecha,numero,subtotal,iva,otros,total,id_cliente,descuento,id_empleado,id_catalogo_precio,mensaje,despedida,nombre_cliente) VALUES" & _
                         " ('" & Format(tb_fecha.Value, "yy-MM-dd") & "','" & numero & "','" & CDec(tb_subtotal.Text) & "','" & CDec(tb_iva.Text) & "','" & CDec(tb_otros_impuestos.Text) & "','" & CDec(tb_total.Text) & "'," & id_cliente & ",'" & cliente_descuento & "'," & id_empleado & ",'" & id_catalogo_precio & "','" & tb_mensaje.Text & "','" & tb_despedida.Text & "','" & cb_cliente.Text & "')")

            rs.Open("SELECT last_insert_id() id_cotizacion", conn)
            id_cotizacion = rs.Fields("id_cotizacion").Value
            rs.Close()

            For row = 0 To tabla.Rows.Count - 1
                conn.Execute("INSERT INTO cotizacion_detalle (id_cotizacion,id_producto,descripcion,cantidad,unidad,impuesto,precio_unitario) VALUES" & _
                             " (" & id_cotizacion & "," & dg_cotizacion.Item("id_producto", row).Value & ",'" & dg_cotizacion.Item("descripcion", row).Value & "'," & dg_cotizacion.Item("cantidad", row).Value & ",'" & dg_cotizacion.Item("unidad", row).Value & "','" & dg_cotizacion.Item("impuesto", row).Value & "','" & CDec(dg_cotizacion.Item("precio", row).Value) & "')")

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

            tb_numero_cotizacion.Text = "CT" & Date.Today.Year & "-" & Format(numero, "0000")

            m_guardar.Enabled = False
            m_exportar.Enabled = True

            conn.CommitTrans()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.RollbackTrans()
        End Try
        'conn.close()
        'conn = Nothing

        cargar(id_cotizacion)
        MsgBox("La cotizacion se ha generado con el Número " & vbCrLf & tb_numero_cotizacion.Text, MsgBoxStyle.Information, "Confirmacion Cotizacion")
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
    Private Sub btn_generar_pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar_cotizacion_pdf.Click
        frm_hoja_cotizacion.id_cotizacion = id_cotizacion
        frm_hoja_cotizacion.ShowDialog()
    End Sub
End Class