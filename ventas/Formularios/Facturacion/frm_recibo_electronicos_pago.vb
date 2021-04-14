Imports System.Xml
Imports System.IO
Imports System.Collections
Imports TimbradoRV
Imports ventas.finkok_timbrar 'Importamos el web service de timbrado.
Imports ventas.finkok_cancelacion
Imports System.Text
Imports System.Math

Public Class frm_recibo_pagos

    Dim id_recibo_pago As Integer = 0
    Dim id_cliente As Integer = 0
    Dim id_empleado As Integer = 0
    Dim id_catalogo_precio As Integer = 0
    Dim cliente_descuento As Decimal = 0
    Dim i As Integer
    Dim tmp As Integer


    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim cargado As Boolean = False

    Dim num_lineas As Integer = 0

    'variables 

    Dim xmlFile As String = ""
    Dim xmlTimbradoFile As String = ""

    Dim rfc_receptor As String = ""
    Dim num_serie As String = ""
    Dim usuario_pac As String = ""
    Dim contraseña_pac As String = ""
    Dim uuid_recibo_timbrado As String = ""
    Dim sello_digital_emisor As String = ""

    Dim reg_por_pag As Integer = 23
    Dim inicial As Integer = 0
    Dim total_recibos As Integer = 0
    Dim total_paginas As Integer = 0


    Private Property tb_cadena_original_PAC As Object

    Private Sub frm_recibo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
        ' habilitar_menu_ventana()
        global_frm_recibo_pago = 0
    End Sub
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))

        Label10.ForeColor = Color.FromArgb(conf_colores(13))
        Label12.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))
        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        Label9.ForeColor = Color.FromArgb(conf_colores(13))

    End Sub
    Private Sub configuracion_inicio()
        gb_recibo.Enabled = False
        gb_listado.Enabled = True
        btn_deshacer.Enabled = False
        btn_nuevo.Enabled = True
    End Sub
    Private Sub configuracion_tabla_recibo()
        tabla = New DataTable("recibo")

        With tabla.Columns
            .Add(New DataColumn("id_documento", GetType(String)))
            .Add(New DataColumn("serie", GetType(String)))
            .Add(New DataColumn("folio", GetType(Decimal)))
            .Add(New DataColumn("moneda", GetType(String)))
            .Add(New DataColumn("tipo_cambio", GetType(String)))
            .Add(New DataColumn("metodo_pago", GetType(String)))
            .Add(New DataColumn("num_parcialidad", GetType(String)))
            .Add(New DataColumn("importe_saldo_anterior", GetType(Decimal)))
            .Add(New DataColumn("importe_pagado", GetType(Decimal)))
            .Add(New DataColumn("importe_saldo_insoluto", GetType(Decimal)))

            'Ocultos
            .Add(New DataColumn("id_factura_electronica", GetType(Integer)))


        End With

        ds = New DataSet
        ds.Tables.Add(tabla)

        With dg_recibo
            .DataSource = ds
            .DataMember = "recibo"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            .Columns("id_factura_electronica").Visible = False

            With .Columns("id_documento")
                .HeaderText = "ID Documento."
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("serie")
                .HeaderText = "Serie"
                .Width = 55
                .ReadOnly = False
            End With
            With .Columns("folio")
                .HeaderText = "Folio"
                .Width = 55
                .ReadOnly = True
            End With
            With .Columns("moneda")
                .HeaderText = "Moneda"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("tipo_cambio")
                .HeaderText = "Tipo Cambio"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("metodo_pago")
                .HeaderText = "Método de Pago"
                .Width = 60
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("num_parcialidad")
                .HeaderText = "No. de Parcialidad"
                .Width = 40
                .ReadOnly = False
            End With
            With .Columns("importe_saldo_anterior")
                .HeaderText = "Importe Saldo Anterior"
                .Width = 80
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = False
            End With
            With .Columns("importe_pagado")
                .HeaderText = "Importe Pagado"
                .Width = 80
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = False
            End With

            With .Columns("importe_saldo_insoluto")
                .HeaderText = "Importe Saldo Insoluto"
                .Width = 80
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = False
            End With

        End With
    End Sub
    Private Sub obtener_variables_globales()
        rs.Open("SELECT serie FROM cfg_recibo_pago_serie WHERE deshabilitar='0' AND id_cfg_recibo_pago_serie='1'", conn)
        If rs.RecordCount > 0 Then
            num_serie = rs.Fields("serie").Value
        End If
        rs.Close()

        rs.Open("SELECT * FROM cfg_facturacion_connector WHERE id_cfg_facturacion_connector", conn)
        If rs.RecordCount > 0 Then
            certificado_sat = Application.StartupPath & "/CFDI3.3/Certificados/" & rs.Fields("certificado").Value
            clave_sat = Application.StartupPath & "/CFDI3.3/Certificados/" & rs.Fields("clave").Value
            contrasena_sat = rs.Fields("contraseña_clave").Value
            usuario_pac = rs.Fields("usuario").Value
            contraseña_pac = rs.Fields("contraseña").Value
        End If
        rs.Close()
    End Sub

    Private Sub frm_recibo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_recibo_pago = 1
        aplicar_colores()
        configuracion_inicio()
        cargar_clientes()
        configuracion_listas()
        configuracion_tabla_recibo()
        obtener_variables_globales()
        rellenar_catalogo_combobox("id_forma_pago", "forma_pago", "ctlg_forma_pago", cb_pago_forma, , , "CONCAT(clave,'-',nombre) AS forma_pago")
        rellenar_catalogo_combobox("id_ctlg_moneda", "moneda", "ctlg_moneda", cb_moneda_pago, , , "CONCAT(clave,'-',nombre) AS moneda")

        cargar_recibo_pago(0)

    End Sub
    Private Sub cargar_facturas_cliente(ByVal id_cliente As Integer)
        cb_folio_fiscal.Text = ""
        cb_folio_fiscal.Items.Clear()

        rs.Open("SELECT id_factura_electronica,serie,total,fecha FROM factura_electronica WHERE id_cliente=" & id_cliente, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_folio_fiscal.Items.Add(New myItem(rs.Fields("id_factura_electronica").Value, rs.Fields("Serie").Value & rs.Fields("id_factura_electronica").Value & ", TOTAL: " & FormatCurrency(rs.Fields("total").Value) & "-" & FormatDateTime(rs.Fields("fecha").Value, DateFormat.LongDate)))
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Private Sub cargar_clientes()

        rs.Open("SELECT DISTINCT CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre, CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS razon_social, cliente.id_cliente " & _
               "FROM cliente " & _
               "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
               "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa", conn)
        If rs.RecordCount > 0 Then
            cb_cliente_busqueda.Items.Add(New myItem(0, "[todos]"))
            While Not rs.EOF
                cb_cliente_busqueda.Items.Add(New myItem(rs.Fields("id_cliente").Value, rs.Fields("razon_social").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()

        If cb_cliente_busqueda.Items.Count > 0 Then
            cb_cliente_busqueda.SelectedIndex = 0
        End If
    End Sub
    Private Sub configuracion_listas()
        With lst_recibos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Folio", 80)
            .Columns.Add("Cliente", 110)
            .Columns.Add("fecha", 80)
            .Columns.Add("Total", 80)
        End With

        For i = 0 To lst_recibos.Items.Count - 2 Step 2
            lst_recibos.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_recibos.Items(i).BackColor = Color.White
        Next



    End Sub
    Public Sub cargar_recibo_pago(Optional ByVal id As Integer = 0)

        id_recibo_pago = id

        xmlFile = Application.StartupPath & "/CFDI3.3/temp/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
        xmlTimbradoFile = Application.StartupPath & "/CFDI3.3/XML/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
        tb_numero_recibo.ReadOnly = True
        tb_domicilio.Text = ""

        If id_recibo_pago > 0 Then


            rs.Open("SELECT id_recibo_pago,serie,fecha,id_cliente,id_empleado,fecha_hora_pago,id_moneda,monto,estatus,id_forma_pago,estatus_timbrado,num_operacion,rfc_ordenante,cuenta_ordenante,nombre_ordenante,rfc_beneficiario,cuenta_beneficiario " & _
                    "FROM recibo_pago " & _
                    "WHERE id_recibo_pago = " & id_recibo_pago, conn)

            id_cliente = rs.Fields("id_cliente").Value
            id_empleado = rs.Fields("id_empleado").Value

            tb_numero_recibo.Text = num_serie & id_recibo_pago
            tb_fecha.Value = Format(rs.Fields("fecha").Value, "yyyy-MM-dd")


            '   Totales

            ' total_factura = rs.Fields("total").Value
            seleccionar_catalogo(rs.Fields("id_forma_pago").Value, cb_pago_forma)
            tb_total_pago.Text = rs.Fields("monto").Value

            lbl_estatus_timbrado.Visible = True
            lbl_estatus_timbrado.Text = rs.Fields("estatus_timbrado").Value

            tb_num_operacion.Text = rs.Fields("num_operacion").Value
            tb_rfc_ordenante.Text = rs.Fields("rfc_ordenante").Value
            tb_cuenta_ordenante.Text = rs.Fields("cuenta_ordenante").Value
            tb_nombre_ordenante.Text = rs.Fields("nombre_ordenante").Value
            tb_rfc_beneficiario.Text = rs.Fields("rfc_beneficiario").Value
            tb_cuenta_beneficiario.Text = rs.Fields("cuenta_beneficiario").Value

            If rs.Fields("estatus_timbrado").Value = "PENDIENTE" Then
                lbl_estatus_timbrado.BackColor = Color.OrangeRed
                btn_timbrar.Enabled = True
                btn_enviar.Enabled = False
                btn_xml.Enabled = False
                btn_pdf.Enabled = False
                btn_cancelar.Enabled = False
                btn_editar.Enabled = True
            ElseIf rs.Fields("estatus_timbrado").Value = "TIMBRADA" Then
                lbl_estatus_timbrado.BackColor = Color.ForestGreen
                btn_timbrar.Enabled = False
                btn_xml.Enabled = True
                btn_pdf.Enabled = True
                btn_cancelar.Enabled = True
                btn_editar.Enabled = False
                btn_enviar.Enabled = True
            End If

            If rs.Fields("estatus").Value = "CANCELADA" Then
                tb_aviso_cancelado.Visible = True
            Else
                tb_aviso_cancelado.Visible = False
            End If

            rs.Close()

            rs.Open("SELECT  CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END AS registro " & _
                    "FROM cliente " & _
                    "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                    "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                    "WHERE cliente.id_cliente='" & id_cliente & "'", conn)
            If rs.RecordCount > 0 Then
                rfc_receptor = rs.Fields("registro").Value
            End If
            rs.Close()

            rs.Open("SELECT trim(Concat(p.ap_paterno,' ',p.ap_materno,' ',p.nombre)) as nombre, ep.id_puesto from persona p JOIN empleado e JOIN empleado_puesto ep ON e.id_puesto=ep.id_puesto AND e.id_persona=p.id_persona  WHERE e.id_empleado=" & id_empleado & " ORDER BY p.nombre", conn)
            tb_empleado.Text = rs.Fields("nombre").Value
            rs.Close()


            tb_fecha.Enabled = False
            cb_cliente.Enabled = False

            btn_guardar.Enabled = False

            btn_cancelar.Visible = True
            tabla.Clear()


            rs.Open("SELECT * FROM recibo_pago_detalle WHERE id_recibo_pago=" & id_recibo_pago, conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    cargar_pagos_recibos(rs.Fields("id_factura_electronica").Value, rs.Fields("id_documento").Value, rs.Fields("serie").Value, rs.Fields("id_factura_electronica").Value, rs.Fields("moneda").Value, rs.Fields("tipo_cambio").Value, rs.Fields("metodo_pago").Value, rs.Fields("num_parcialidad").Value, rs.Fields("importe_anterior").Value, rs.Fields("importe_pagado").Value, rs.Fields("importe_saldo").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            cb_folio_fiscal.Text = ""

            configuracion_inicio()
        Else
            '==========PREPARAMOS PARA NUEVO RECIBO===================
            tabla.Clear()
            '   total_productos = 0

            btn_cancelar.Visible = False

            id_cliente = 0
            id_empleado = global_id_empleado

            rs.Open("SELECT IF(MAX(id_recibo_pago) IS NULL,1,MAX(id_recibo_pago)+1) numero from recibo_pago WHERE YEAR(fecha) = '" & Date.Today.Year & "'", conn)
            tb_numero_recibo.Text = num_serie & rs.Fields("numero").Value
            rs.Close()
            tb_fecha.Value = Date.Today

            ' suma_subtotal = 0
            ' suma_impuesto = 0


            tb_total_pago.Text = "0"
            tb_empleado.Text = global_nombre

            tb_fecha.Enabled = True
            cb_cliente.Enabled = True
            btn_guardar.Enabled = True
            btn_deshacer.Enabled = True

            tb_numero_recibo.ReadOnly = True
            lbl_estatus_timbrado.Visible = False

            btn_timbrar.Enabled = False
            btn_enviar.Enabled = False
            btn_xml.Enabled = False
            btn_pdf.Enabled = False
            btn_cancelar.Enabled = False
            tb_aviso_cancelado.Visible = False
            btn_editar.Enabled = False
            gb_recibo.Enabled = True

            cb_folio_fiscal.Text = ""

            tb_num_operacion.Text = ""
            tb_rfc_ordenante.Text = ""
            tb_cuenta_ordenante.Text = ""
            tb_nombre_ordenante.Text = ""
            tb_rfc_beneficiario.Text = ""
            tb_cuenta_beneficiario.Text = ""

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

        cargado = True

    End Sub
    Private Sub cargar_pagos_recibos(ByVal id_factura_electronica As Integer, ByVal id_documento As String, ByVal serie As String, ByVal folio As String, ByVal moneda As String, ByVal tipo_cambio As String, ByVal metodo_pago As String, ByVal num_parcialidad As String, ByVal importe_saldo_anterior As Decimal, ByVal importe_pagado As Decimal, ByVal importe_saldo_insoluto As Decimal)
        tabla_linea = tabla.NewRow()
        tabla_linea("id_factura_electronica") = id_factura_electronica
        tabla_linea("id_documento") = id_documento
        tabla_linea("serie") = serie
        tabla_linea("folio") = folio
        tabla_linea("moneda") = moneda
        tabla_linea("tipo_cambio") = tipo_cambio
        tabla_linea("metodo_pago") = metodo_pago
        tabla_linea("num_parcialidad") = num_parcialidad
        tabla_linea("importe_pagado") = importe_pagado
        tabla_linea("importe_saldo_anterior") = importe_saldo_anterior
        tabla_linea("importe_saldo_insoluto") = importe_saldo_insoluto
        tabla.Rows.Add(tabla_linea)
    End Sub

    Public Sub agregar_producto(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Decimal = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then
            If Not actualizar Then '=======SUMA UN PRODUCTO A LA LISTA QUE YA EXISTE
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If

            foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("cantidad") * foundRows(0).Item("precio"), 2)
            foundRows(0).Item("total_impuesto") = FormatNumber(foundRows(0).Item("importe") * foundRows(0).Item("tasa_impuesto"), 2)
        Else

            'total_productos = total_productos + 1
            tabla_linea = tabla.NewRow()
            If cantidad > 0 Then
                tabla_linea("cantidad") = cantidad
            Else
                tabla_linea("cantidad") = 1
            End If

            '==============obtenemos los datos del producto====================
            rs.Open("SELECT p.nombre,p.precio,u.nombre AS unidad,i.nombre AS nombre_impuesto,i.tasa AS tasa_impuesto FROM producto p " & _
                    "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                    "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                    "WHERE p.id_producto = " & id, conn)

            tabla_linea("id_producto") = id
            '  tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = rs.Fields("nombre").Value

            tabla_linea("unidad") = rs.Fields("unidad").Value
            tabla_linea("impuesto") = rs.Fields("nombre_impuesto").Value
            tabla_linea("tasa_impuesto") = rs.Fields("tasa_impuesto").Value

            tabla_linea("precio") = FormatNumber(rs.Fields("precio").Value / (1 + rs.Fields("tasa_impuesto").Value), 6)
            tabla_linea("importe") = FormatNumber(tabla_linea("precio") * tabla_linea("cantidad"), 2)
            tabla_linea("total_impuesto") = FormatNumber(tabla_linea("importe") * tabla_linea("tasa_impuesto"), 2)

            tabla_linea("total_impuesto_retenido") = 0
            tabla_linea("tasa_impuesto_retenido") = 0
            tabla_linea("nombre_impuesto_retenido") = ""


            rs.Close()

            tabla.Rows.Add(tabla_linea)
        End If
    End Sub

    Private Sub actualizar_partida()
        Dim j As Integer

        For j = 0 To dg_recibo.RowCount - 1
            dg_recibo.Rows(j).Cells("partida").Value = j + 1
            '  total_productos = j + 1
        Next
    End Sub

    Private Sub cb_cliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        tb_domicilio.Text = ""
    End Sub
    Private Sub m_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_facturacion_electronica_abrir.ShowDialog()
    End Sub
    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        global_frm_producto_abrir = 3
        frm_producto_abrir.ShowDialog()
    End Sub
    Private Sub dg_recibo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_recibo.CellEndEdit
        dg_factura_CellValueChanged(sender, e)
    End Sub
  
    Private Sub dg_factura_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_recibo.CellValueChanged
        If cargado Then

            dg_recibo.Rows(dg_recibo.CurrentRow.Index).Cells("importe_saldo_insoluto").Value = dg_recibo.Rows(dg_recibo.CurrentRow.Index).Cells("importe_saldo_anterior").Value() - dg_recibo.Rows(dg_recibo.CurrentRow.Index).Cells("importe_pagado").Value()
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
    Private Sub seleccionar_catalogo(ByVal id_catalogo As Integer, ByVal cb As ComboBox)
        '-----buscamos el tipo servicio_tecnico
        For x = 0 To cb.Items.Count - 1
            If id_catalogo = CType(cb.Items(x), myItem).Value Then
                cb.SelectedIndex = x
                Exit For
            End If
        Next
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
                rs.Open("SELECT concat(d.calle,' ',d.colonia,' ',d.municipio) domicilio FROM cliente c, domicilio d, persona p WHERE p.id_persona=c.id_persona AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                rs.Close()

            ElseIf CType(cb_cliente.SelectedItem, myItem).Opcional = 1 Then
                'Conectar()
                rs.Open("SELECT concat(d.calle,' ',d.colonia,' ',d.municipio) domicilio FROM cliente c, domicilio d, empresa e WHERE e.id_empresa=c.id_empresa AND d.id_domicilio=c.id_domicilio AND c.id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
                tb_domicilio.Text = rs.Fields("domicilio").Value
                rs.Close()

            End If

            '---seleccionamos el precio_especial de este cliente
            id_catalogo_precio = 0
            rs.Open("SELECT * FROM cliente_precio WHERE id_cliente=" & CType(cb_cliente.SelectedItem, myItem).Value, conn)
            If rs.RecordCount > 0 Then
                id_catalogo_precio = rs.Fields("id_ctlg_precios").Value
            End If
            rs.Close()
            '---------------------------------------------

            cargar_facturas_cliente(id_cliente)
        End If


    End Sub

    Private Sub btn_cancelar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        If MsgBox("Esta seguro que desea cancelar este recibo", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

            conn.Execute("UPDATE recibo_pago SET estatus='CANCELADA' WHERE id_recibo_pago=" & id_recibo_pago)

            cancelar_finkok()

            cargar_recibo_pago(id_recibo_pago)
            MsgBox("Recibo cancelado correctamente", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_generar_xml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
    Public Shared Function GetCadenaOriginal(ByVal xml As String, ByVal xslt As String) As String
        Dim strCadenaOriginal As String
        Dim newFile = Path.GetTempFileName()

        Dim Xsl = New Xml.Xsl.XslCompiledTransform()
        Xsl.Load(xslt)
        Xsl.Transform(xml, newFile)
        Xsl = Nothing

        Dim sr = New IO.StreamReader(newFile)
        strCadenaOriginal = sr.ReadToEnd
        sr.Close()

        'Eliminamos el archivo Temporal
        System.IO.File.Delete(newFile)

        xslt = Nothing
        newFile = Nothing
        Xsl = Nothing
        sr.Dispose()

        Return strCadenaOriginal
    End Function
    Private Shared Function GetCadenaSAT(ByVal xml As String, ByVal xslt As String) As String
        Dim Cadena_sat As String
        Dim CadenaOriginal As String
        Dim transformer As System.Xml.Xsl.XslCompiledTransform


        Dim document As New System.Xml.XmlDocument
        Dim elemento As System.Xml.XmlElement
        Dim Nodo As System.Xml.XmlNode
        Dim navigator As System.Xml.XPath.XPathNavigator
        Dim output As New System.IO.StringWriter()
        document = New System.Xml.XmlDocument()
        transformer = New System.Xml.Xsl.XslCompiledTransform


        Try
            'Cadena PAC
            document = Nothing
            transformer = Nothing
            document = New System.Xml.XmlDocument()
            transformer = New System.Xml.Xsl.XslCompiledTransform

            document.Load(xml)
            navigator = document.CreateNavigator
            Dim manager As New System.Xml.XmlNamespaceManager(navigator.NameTable)
            manager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
            Dim nodes As System.Xml.XPath.XPathNodeIterator = navigator.Select("Comprobante")
            nodes.MoveNext()
            navigator = nodes.Current
            transformer.Load(xslt)
            Nodo = document.Item("cfdi:Comprobante")
            elemento = document.DocumentElement()
            transformer.Transform(document.DocumentElement(), Nothing, output)
            Console.WriteLine(output.ToString)

            CadenaOriginal = output.ToString

            output.Close()
            Cadena_sat = "|" & CadenaOriginal & "||"

        Catch ex As Exception
            Cadena_sat = "Error :" + ex.Message
        Finally
            document = Nothing
            transformer = Nothing
            navigator = Nothing
            output.Dispose()
        End Try
        Return Cadena_sat

    End Function
    Private Sub cancelar_finkok()

        Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
        Dim reader As XmlTextReader = New XmlTextReader(xmlTimbradoFile)
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()

                            If reader.Name = "UUID" Then
                                uuid_recibo_timbrado = reader.Value
                            End If
                        End While
                    End If
            End Select
        Loop

        Try
            FabricaPEM()
            Dim uuid() As String
            uuid = {uuid_recibo_timbrado}
            Dim folio_fiscal_cancelar As String = uuid_recibo_timbrado
            Dim rfc As String
            Dim status As String
            Dim fecha As String
            Dim cer As String
            Dim key As String
            Dim RFCemisor As String
            Using fileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Application.StartupPath & "/CFDI3.3/cancelaciones/" & Path.GetFileName(certificado_sat) & ".pem")
                cer = fileReader.ReadToEnd
            End Using

            Using fileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Application.StartupPath & "/CFDI3.3/cancelaciones/" & Path.GetFileName(clave_sat) & ".enc")
                key = fileReader.ReadToEnd
            End Using
            rfc = global_rfc
            Dim cancel As New finkok_cancelacion.CancelSOAP
            Dim can As New cancel
            Dim nim As New UUIDS
            Dim acuse As String
            nim.uuids = uuid.ToArray
            can.UUIDS = nim
            can.username = usuario_pac
            can.password = contraseña_pac
            can.taxpayer_id = rfc
            can.cer = stringToBase64ByteArray(cer)
            can.key = stringToBase64ByteArray(key)
            Dim cancelresponse As New cancelResponse
            cancelresponse = cancel.cancel(can)
            status = cancelresponse.cancelResult.Folios(0).EstatusUUID
            fecha = cancelresponse.cancelResult.Fecha
            acuse = cancelresponse.cancelResult.Acuse
            RFCemisor = cancelresponse.cancelResult.RfcEmisor
            System.IO.File.WriteAllText(Application.StartupPath & "/CFDI3.3/cancelaciones/" & folio_fiscal_cancelar & ".xml", acuse)
        Catch ex As Exception
            MessageBox.Show("No se cancelo el recibo " & ex.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try


    End Sub
    Public Sub FabricaPEM()
        Dim DicArchivos As New Dictionary(Of String, String)
        Dim ConvierteCerAPem As String
        Dim ConvierteKeyAPem As String
        Dim EncriptaKey As String
        Dim ArchivoCer As String = certificado_sat
        Dim ArchivoKey As String = clave_sat
        Dim NombreArchivoCertificado As String = Path.GetFileName(ArchivoCer)
        Dim NombreArchivoLlave As String = Path.GetFileName(ArchivoKey)
        ConvierteCerAPem = "C:\OpenSSL-Win32\bin\" & "openssl.exe x509 -inform DER -outform PEM -in """ & ArchivoCer & """ -pubkey -out " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & Path.GetFileName(certificado_sat) & ".pem" & """"
        ConvierteKeyAPem = "C:\OpenSSL-Win32\bin\" & "openssl.exe pkcs8 -inform DER -in """ & ArchivoKey & """ -passin pass:" & contrasena_sat & " -out " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & Path.GetFileName(clave_sat) & ".pem" & """"
        EncriptaKey = "C:\OpenSSL-Win32\bin\" & "openssl.exe rsa -in " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & NombreArchivoLlave & ".pem""" & " -des3 -out " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & NombreArchivoLlave & ".enc""" & " -passout pass:" & "" & contraseña_pac & ""
        'Crea el archivo Certificado.BAT
        Dim oSW As New StreamWriter(Application.StartupPath & "/CFDI3.3/cancelaciones/" & "Certificado.bat")
        oSW.WriteLine(ConvierteCerAPem)
        oSW.WriteLine(ConvierteKeyAPem)
        oSW.WriteLine(EncriptaKey)
        oSW.Close()
        Process.Start(Application.StartupPath & "/CFDI3.3/cancelaciones/" & "Certificado.bat").WaitForExit()
    End Sub
    Private Sub timbrar_finkok_pago()

        Try
            Dim SelloSAT As String = ""
            Dim noCertificadoSAT As String = ""
            Dim FechaTimbrado As String = ""
            Dim uuid As String = ""
            Dim xmlTimbrado As String = ""
            Dim xmlCfdi As New System.Xml.XmlDocument()
            Dim timbrado As New ventas.finkok_timbrar.StampSOAP
            Dim timb As New stamp
            Dim ResponseTimbrar As New stampResponse
            Dim MensajeIncidencia As String = ""
            Dim CodigoIncidencia As String = ""

            xmlCfdi.Load(xmlFile) 'Cargamos el archivo XML.
            timb.xml = stringToBase64ByteArray(xmlCfdi.OuterXml) 'El archivo XML se envia en Base64.
            timb.username = usuario_pac
            timb.password = contraseña_pac

            ResponseTimbrar = timbrado.stamp(timb)
            If DirectCast(ResponseTimbrar.stampResult, AcuseRecepcionCFDI).Incidencias.Length > 0 Then
                CodigoIncidencia = DirectCast(ResponseTimbrar.stampResult, AcuseRecepcionCFDI).Incidencias(0).CodigoError
                MensajeIncidencia = DirectCast(ResponseTimbrar.stampResult, AcuseRecepcionCFDI).Incidencias(0).MensajeIncidencia
            Else
                CodigoIncidencia = "000"
                MensajeIncidencia = "Timbrado Satisfactorio"
            End If
            If CodigoIncidencia = "000" Then
                uuid = ResponseTimbrar.stampResult.UUID
                xmlTimbrado = ResponseTimbrar.stampResult.xml
                FechaTimbrado = ResponseTimbrar.stampResult.Fecha
                SelloSAT = ResponseTimbrar.stampResult.SatSeal
                noCertificadoSAT = ResponseTimbrar.stampResult.NoCertificadoSAT
                xmlCfdi.LoadXml(xmlTimbrado)
                xmlCfdi.Save(xmlTimbradoFile)
                ' txtUUID.Text = uuid

            ElseIf CodigoIncidencia = "707" Then
                Dim ResponseIsTimbrado As New stampedResponse
                Dim isTimbrado As New stamped
                isTimbrado.xml = stringToBase64ByteArray(xmlCfdi.OuterXml)
                isTimbrado.username = usuario_pac
                isTimbrado.password = contraseña_pac
                ResponseIsTimbrado = timbrado.stamped(isTimbrado)
                uuid = ResponseIsTimbrado.stampedResult.UUID
                xmlTimbrado = ResponseIsTimbrado.stampedResult.xml
                FechaTimbrado = ResponseIsTimbrado.stampedResult.Fecha
                SelloSAT = ResponseIsTimbrado.stampedResult.SatSeal
                noCertificadoSAT = ResponseIsTimbrado.stampedResult.NoCertificadoSAT
                xmlCfdi.LoadXml(xmlTimbrado)
                xmlCfdi.Save(xmlTimbradoFile)
                'txtUUID.Text = uuid
            Else
                MessageBox.Show(MensajeIncidencia)
                Exit Sub
            End If

            MessageBox.Show("Timbrado exitoso.")
            conn.Execute("UPDATE recibo_pago SET estatus_timbrado='TIMBRADA' WHERE id_recibo_pago=" & id_recibo_pago)

        Catch ex As Exception
            MessageBox.Show("No se realizo el timbrado " & ex.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try
    End Sub
    Public Function stringToBase64ByteArray(ByVal input As String) As Byte()
        Dim ret As Byte() = Encoding.UTF8.GetBytes(input)
        Dim s As String = Convert.ToBase64String(ret)
        ret = Convert.FromBase64String(s)
        Return ret
    End Function
    Private Sub generar_formato_pdf()
        Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
        Dim reader As XmlTextReader = New XmlTextReader(xmlTimbradoFile)
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()

                            If reader.Name = "UUID" Then
                                uuid_recibo_timbrado = reader.Value
                            ElseIf reader.Name = "SelloCFD" Then
                                sello_digital_emisor = reader.Value
                            End If
                        End While
                    End If
            End Select
        Loop

        QrCodeImgControl1.Text = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" & uuid_recibo_timbrado & "&re=" & global_rfc & "&rr=" & rfc_receptor & "&tt=" & 0 & "&fe=" & sello_digital_emisor.Substring(sello_digital_emisor.Length - 8, 8)
        Dim qrcode As System.Drawing.Image = DirectCast(QrCodeImgControl1.Image.Clone, Image)
        qrcode.Save(Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".png")
        qrcode.Dispose()

        Genera_recibo_pago(id_recibo_pago, False, "")
    End Sub
    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_recibo_pago(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores:" & vbCrLf


        If cb_pago_forma.SelectedIndex = -1 Then
            mensaje = mensaje & "   *Debe seleccionar una forma de pago" & vbCrLf
            correcto = False
        End If

        If cb_moneda_pago.SelectedIndex = -1 Then
            mensaje = mensaje & "   *Debe seleccionar una moneda" & vbCrLf
            correcto = False
        End If

        If Trim(tb_numero_recibo.TextLength) = 0 Then
            MsgBox("El numero del recibo no puede estar vacio", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If


        If correcto = True Then
            If id_recibo_pago > 0 Then

                '============ACTUALIZAMOS EL RECIBO======================
                Dim numero As String = ""
                numero = tb_numero_recibo.Text



                conn.Execute("UPDATE recibo_pago SET serie='" & num_serie & "',fecha=NOW(),id_cliente=" & id_cliente & ",id_empleado=" & id_empleado & ",fecha_hora_pago='" & Format(dtp_fecha_hora_pago.Value, "yyyy-MM-dd HH:mm:ss") & "',id_moneda='" & CType(cb_moneda_pago.SelectedItem, myItem).Value & "',monto='" & CDec(tb_total_pago.Text) & "',id_forma_pago='" & CType(cb_pago_forma.SelectedItem, myItem).Value & "',num_operacion='" & tb_num_operacion.Text & "',rfc_ordenante='" & tb_rfc_ordenante.Text & "',cuenta_ordenante='" & tb_cuenta_ordenante.Text & "',nombre_ordenante='" & tb_nombre_ordenante.Text & "',rfc_beneficiario='" & tb_rfc_beneficiario.Text & "',cuenta_beneficiario='" & tb_cuenta_beneficiario.Text & "' WHERE id_recibo_pago='" & id_recibo_pago & "'")
                conn.Execute("DELETE FROM recibo_pago_detalle WHERE id_recibo_pago='" & id_recibo_pago & "'")

                For row = 0 To tabla.Rows.Count - 1
                    conn.Execute("INSERT INTO recibo_pago_detalle (id_recibo_pago,id_documento,serie,moneda,metodo_pago,tipo_cambio,num_parcialidad,importe_anterior,importe_pagado,importe_saldo,id_factura_electronica) VALUES" & _
                      " (" & id_recibo_pago & ",'" & dg_recibo.Item("id_documento", row).Value & "','" & dg_recibo.Item("serie", row).Value & "','" & dg_recibo.Item("moneda", row).Value & "','" & dg_recibo.Item("metodo_pago", row).Value & "','" & dg_recibo.Item("tipo_cambio", row).Value & "','" & dg_recibo.Item("num_parcialidad", row).Value & "','" & dg_recibo.Item("importe_saldo_anterior", row).Value & "','" & dg_recibo.Item("importe_pagado", row).Value & "','" & dg_recibo.Item("importe_saldo_insoluto", row).Value & "','" & dg_recibo.Item("id_factura_electronica", row).Value & "')")

                Next

                btn_guardar.Enabled = False

                cargar_recibo_pago(id_recibo_pago)

                MsgBox("El recibo de pago " & tb_numero_recibo.Text & "se ha actualizado!" & vbCrLf, MsgBoxStyle.Information, "Aviso")

            Else
                '=================insertamos nuevo recibo====================
                Dim numero As String = ""

                numero = tb_numero_recibo.Text

                conn.Execute("INSERT INTO recibo_pago (serie,fecha,id_cliente,id_empleado,fecha_hora_pago,id_moneda,monto,id_forma_pago,num_operacion,rfc_ordenante,cuenta_ordenante,nombre_ordenante,rfc_beneficiario,cuenta_beneficiario) VALUES " & _
                        " ('" & num_serie & "',NOW(),'" & id_cliente & "','" & id_empleado & "','" & Format(dtp_fecha_hora_pago.Value, "yyyy-MM-dd HH:mm:ss") & "','" & CType(cb_moneda_pago.SelectedItem, myItem).Value & "'," & CDec(tb_total_pago.Text) & ",'" & CType(cb_pago_forma.SelectedItem, myItem).Value & "','" & tb_num_operacion.Text & "','" & tb_rfc_ordenante.Text & "','" & tb_cuenta_ordenante.Text & "','" & tb_nombre_ordenante.Text & "','" & tb_rfc_beneficiario.Text & "','" & tb_cuenta_beneficiario.Text & "')")

                rs.Open("SELECT last_insert_id() id_recibo_pago", conn)
                id_recibo_pago = rs.Fields("id_recibo_pago").Value
                rs.Close()


                For row = 0 To tabla.Rows.Count - 1
                    conn.Execute("INSERT INTO recibo_pago_detalle (id_recibo_pago,id_documento,serie,moneda,metodo_pago,tipo_cambio,num_parcialidad,importe_anterior,importe_pagado,importe_saldo,id_factura_electronica) VALUES" & _
                      " (" & id_recibo_pago & ",'" & dg_recibo.Item("id_documento", row).Value & "','" & dg_recibo.Item("serie", row).Value & "','" & dg_recibo.Item("moneda", row).Value & "','" & dg_recibo.Item("metodo_pago", row).Value & "','" & dg_recibo.Item("tipo_cambio", row).Value & "','" & dg_recibo.Item("num_parcialidad", row).Value & "','" & dg_recibo.Item("importe_saldo_anterior", row).Value & "','" & dg_recibo.Item("importe_pagado", row).Value & "','" & dg_recibo.Item("importe_saldo_insoluto", row).Value & "','" & dg_recibo.Item("id_factura_electronica", row).Value & "')")

                Next

                btn_guardar.Enabled = False
                cargar_recibo_pago(id_recibo_pago)
                MsgBox("El recibo de pago se ha generado con el Número " & vbCrLf & tb_numero_recibo.Text, MsgBoxStyle.Information, "Aviso")
            End If
            cargar_recibos_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
        Else
            MsgBox(mensaje)
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        tb_fecha.Enabled = True
        cb_cliente.Enabled = True
        btn_guardar.Enabled = True
        btn_timbrar.Enabled = False
        gb_recibo.Enabled = True
        gb_listado.Enabled = False
        btn_deshacer.Enabled = True
        btn_nuevo.Enabled = False
    End Sub

    Private Sub btn_timbrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_timbrar.Click
        Try
            Genera_CFDI3_3_pago(id_recibo_pago, num_serie)
            timbrar_finkok_pago()
            generar_formato_pdf()
            cargar_recibo_pago(id_recibo_pago)
        Catch ex As Exception
            MsgBox("Ocurrio un error al generar el recibo " & ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub btn_enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click
        enviar_recibo_email(id_recibo_pago)
    End Sub

    Private Sub btn_xml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_xml.Click
        'frm_cfdi.CId_factura = id_factura_electronica
        'frm_cfdi.Show()
        'frm_cfdi.BringToFront()
        Dim FolderBrowserDialog As New FolderBrowserDialog
        Dim ruta_destino_xml As String = ""
        Try
            ' Configuración del FolderBrowserDialog  
            With FolderBrowserDialog

                .RootFolder = Environment.SpecialFolder.Desktop

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then
                    ruta_destino_xml = .SelectedPath

                    Dim Source As String = Application.StartupPath & "/CFDI3.3/XML/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
                    Dim Destination As String = ruta_destino_xml & "/" & global_rfc & num_serie & Format(id_recibo_pago, "0000000000") & ".xml"
                    System.IO.File.Copy(Source, Destination, True)
                    MsgBox("El archivo ha sido guardado en " & Destination, MsgBoxStyle.Information, "Aviso")
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try

        ' Saves the Image via a FileStream created by the OpenFile method.
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pdf.Click
        generar_formato_pdf()
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub cb_cliente_busqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_cliente_busqueda.SelectedIndexChanged
        cargar_recibos_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
    End Sub
    Private Sub cargar_recibos_cliente(ByVal id_cliente As Integer, ByVal buscar As String, Optional ByVal pagina As Integer = 1)
        tb_pagina.Text = pagina
        inicial = (pagina - 1) * reg_por_pag

        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_recibos.Items.Clear()
        If id_cliente > 0 Then
            filtro = " WHERE r.id_cliente='" & id_cliente & "'"
        End If

        If buscar.Length > 0 Then
            If id_cliente > 0 Then
                filtro = filtro & " AND r.id_recibo_pago LIKE '%" & buscar & "%'"
            Else
                filtro = " WHERE r.id_recibo_pago LIKE '%" & buscar & "%'"
            End If

        End If


        rs.Open("SELECT count(*) as total_recibos FROM recibo_pago r " & filtro, conn)
        total_recibos = rs.Fields("total_recibos").Value
        rs.Close()

        total_paginas = Ceiling(total_recibos / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas


        rs.Open("SELECT r.id_recibo_pago,r.serie,r.fecha,r.monto, CASE WHEN c.id_persona = 0 THEN  e.razon_social ELSE CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) END AS razon_social, CASE WHEN c.id_persona = 0 THEN  e.rfc ELSE p.rfc END AS registro " & _
                "FROM recibo_pago r " & _
                "JOIN cliente c ON c.id_cliente=r.id_cliente " & _
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & filtro & "ORDER BY r.id_recibo_pago DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        If rs.RecordCount > 0 Then

            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("serie").Value & rs.Fields("id_recibo_pago").Value
                str(1) = rs.Fields("registro").Value
                str(2) = FormatDateTime(rs.Fields("fecha").Value, DateFormat.ShortDate)
                str(3) = FormatCurrency(rs.Fields("monto").Value, 2)

                lst_recibos.Items.Add(New ListViewItem(str, 0))
                lst_recibos.Items(i).Tag = rs.Fields("id_recibo_pago").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If

        tb_resultados.Text = total_recibos & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()

        aplicar_estilo_recibos()

    End Sub
    Private Sub aplicar_estilo_recibos()

        For i = 0 To lst_recibos.Items.Count - 2 Step 2
            lst_recibos.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_recibos.Items(i).BackColor = Color.White
        Next
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar_recibos_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
    End Sub

    Private Sub lst_recibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_recibos.DoubleClick
        If lst_recibos.SelectedItems.Count > 0 Then
            cargar_recibo_pago(lst_recibos.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_deshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
        cargar_recibo_pago(id_recibo_pago)
    End Sub
    Private Sub pb_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar_recibos_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar_recibos_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub tb_pagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar_recibos_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
            End If
        End If
    End Sub

    Private Sub btn_agregar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_factura.Click
        If cb_folio_fiscal.SelectedIndex >= 0 Then
            Dim uuid_factura As String = ""
            Dim serie As String = ""
            Dim moneda As String = ""
            Dim metodo As String = ""
            Dim tipo_cambio As String = ""
            Dim num_parcialidad As Integer = 0
            Dim importe_anterior As Decimal = 0
            Dim importe_pago As Decimal = CDec(tb_total_pago.Text)
            Dim importe_saldo As Decimal = 0
            Dim importe_factura As Decimal = 0


            rs.Open("SELECT f.serie,f.total, m.clave as moneda,p.clave as metodo,f.tipo_cambio " & _
                    "FROM factura_electronica f " & _
                    "JOIN ctlg_moneda m ON m.id_ctlg_moneda=f.id_moneda " & _
                    "JOIN ctlg_metodo_pago p ON p.id_metodo_pago=f.id_metodo_pago " & _
                    "WHERE f.id_factura_electronica = " & CType(cb_folio_fiscal.SelectedItem, myItem).Value, conn)
            If rs.RecordCount > 0 Then
                serie = rs.Fields("serie").Value
                moneda = rs.Fields("moneda").Value
                metodo = rs.Fields("metodo").Value
                tipo_cambio = rs.Fields("tipo_cambio").Value
                importe_factura = rs.Fields("total").Value
            End If
            rs.Close()


            Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & serie & Format(CType(cb_folio_fiscal.SelectedItem, myItem).Value, "0000000000") & ".xml"
            Dim reader As XmlTextReader = New XmlTextReader(xmlTimbradoFile)
            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                If reader.Name = "UUID" Then
                                    uuid_factura = reader.Value
                                End If
                            End While
                        End If
                End Select
            Loop
            rs.Open("SELECT CASE WHEN SUM(importe_pagado) IS NULL THEN 0 ELSE SUM(importe_pagado) END AS importe_pagado FROM recibo_pago_detalle WHERE id_factura_electronica=" & CType(cb_folio_fiscal.SelectedItem, myItem).Value, conn)
            If rs.RecordCount > 0 Then
                importe_anterior = importe_factura - rs.Fields("importe_pagado").Value
            End If
            rs.Close()

            rs.Open("SELECT IF(MAX(num_parcialidad) IS NULL,1,MAX(num_parcialidad)+1) num_parcialidad FROM recibo_pago_detalle WHERE id_factura_electronica=" & CType(cb_folio_fiscal.SelectedItem, myItem).Value, conn)
            If rs.RecordCount > 0 Then
                num_parcialidad = rs.Fields("num_parcialidad").Value
            End If
            rs.Close()

            cargar_pagos_recibos(CType(cb_folio_fiscal.SelectedItem, myItem).Value, uuid_factura, serie, CType(cb_folio_fiscal.SelectedItem, myItem).Value, moneda, tipo_cambio, metodo, num_parcialidad, importe_anterior, importe_pago, importe_anterior - importe_pago)

        End If


    End Sub
End Class