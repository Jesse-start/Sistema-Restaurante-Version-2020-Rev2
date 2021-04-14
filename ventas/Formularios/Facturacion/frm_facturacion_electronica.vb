Imports System.Xml
Imports System.IO
'Imports tagcode.xml
Imports System.Collections
Imports TimbradoRV
Imports ventas.finkok_timbrar 'Importamos el web service de timbrado.
Imports ventas.finkok_cancelacion
Imports System.Text
Imports System.Math

Public Class frm_facturacion_electronica

    Dim id_factura_electronica As Integer = 0
    Dim id_cliente As Integer = 0
    Dim id_empleado As Integer = 0
    Dim id_catalogo_precio As Integer = 0
    'Dim aplicar_redondeo As Boolean = False
    Dim cliente_descuento As Decimal = 0
    Dim i As Integer
    Dim tmp As Integer

    Dim total_productos As Integer = 0

    Dim ds As DataSet
    Dim tabla As DataTable
    Dim tabla_columna As DataGridTextBoxColumn
    Dim tabla_linea As DataRow

    Dim cargado As Boolean = False
    ' Dim suma_subtotal As Decimal
    '  Dim suma_impuesto As Decimal
    Dim factura(500, 2) As String
    Dim factura_productos(500, 7) As String
    Dim tickes_facturas(500, 1) As Object
    Dim index_matrix_tickets As Integer = 0
    Dim index_inicio As Integer = 0
    Dim num_lineas As Integer = 0

    'variables facturacion

    Dim xmlFile As String = ""
    Dim xmlTimbradoFile As String = ""
    ' Dim xsltFile As String = Application.StartupPath & "/cdfi32/xlst/cadenaoriginal_3_2.xslt"
    'Dim xsltPACFile As String = Application.StartupPath & "/cfdi32/xlst/cadenaoriginal_TFD_1_0.xslt"
    'Dim certificado As String = ""
    'Dim clave As String = ""
    ' Dim contrasena As String = ""
    Dim rfc_receptor As String = ""
    Dim total_factura As Decimal = 0
    Dim num_serie As String = ""
    Dim usuario_pac As String = ""
    Dim contraseña_pac As String = ""
    Dim uuid_factura_timbra As String = ""
    Dim sello_digital_emisor As String = ""

    Dim reg_por_pag As Integer = 23
    Dim inicial As Integer = 0
    Dim total_facturas As Integer = 0
    Dim total_paginas As Integer = 0


    Private Property tb_cadena_original_PAC As Object

    Public Sub limpiar_tickets_factura()
        For x = 0 To 500
            For j = 0 To 1
                tickes_facturas(x, j) = Nothing
            Next
        Next
    End Sub

    Public Sub limpiar_factura()
        For x = 0 To 500
            For j = 0 To 2
                factura(x, j) = Nothing
            Next
        Next
    End Sub
    Public Sub limpiar_factura_productos()
        For x = 0 To 500
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

        GroupBox1.ForeColor = Color.FromArgb(conf_colores(2))

        Label1.ForeColor = Color.FromArgb(conf_colores(13))
        Label10.ForeColor = Color.FromArgb(conf_colores(13))

        Label12.ForeColor = Color.FromArgb(conf_colores(13))

        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        Label3.ForeColor = Color.FromArgb(conf_colores(13))
        Label4.ForeColor = Color.FromArgb(conf_colores(13))

        Label5.ForeColor = Color.FromArgb(conf_colores(13))
        Label8.ForeColor = Color.FromArgb(conf_colores(13))
        Label9.ForeColor = Color.FromArgb(conf_colores(13))

    End Sub
    Private Sub configuracion_inicio()
        'suma_subtotal = 0
        ' suma_impuesto = 0
        gb_factura.Enabled = False
        gb_listado.Enabled = True
        btn_deshacer.Enabled = False
        btn_nuevo.Enabled = True
        ' btn_enviar.Enabled = False
    End Sub
    Private Sub configuracion_tabla_factura()
        tabla = New DataTable("factura")

        With tabla.Columns
            .Add(New DataColumn("partida", GetType(Integer)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("cantidad", GetType(Decimal)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("impuesto", GetType(String)))
            .Add(New DataColumn("precio", GetType(Decimal)))
            .Add(New DataColumn("importe", GetType(Decimal)))

            'Ocultos
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("tasa_impuesto", GetType(Decimal)))
            .Add(New DataColumn("total_impuesto", GetType(Decimal)))
            .Add(New DataColumn("nombre_impuesto_retenido", GetType(String)))
            .Add(New DataColumn("tasa_impuesto_retenido", GetType(Decimal)))
            .Add(New DataColumn("total_impuesto_retenido", GetType(Decimal)))

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
            .Columns("tasa_impuesto").Visible = False

            With .Columns("partida")
                .HeaderText = "No."
                .Width = 40
                .ReadOnly = True
            End With
            With .Columns("cantidad")
                .HeaderText = "Cantidad"
                .Width = 50
                .ReadOnly = False
            End With
            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 250
                .ReadOnly = True
            End With
            With .Columns("impuesto")
                .HeaderText = "Impuestos"
                .Width = 60
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With
            With .Columns("precio")
                .HeaderText = "Precio Unitario"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "c"
                .ReadOnly = False
            End With
            With .Columns("importe")
                .HeaderText = "Importe"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 80
                ' .DefaultCellStyle.Format = "c"
                .ReadOnly = True
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns("total_impuesto")
                .HeaderText = "Impuesto"
                .Width = 50
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                '.DefaultCellStyle.Format = "c"
                .ReadOnly = True

            End With

            With .Columns("nombre_impuesto_retenido")
                .HeaderText = "IVA RET"
                .Width = 80
                .ReadOnly = False
            End With

            With .Columns("tasa_impuesto_retenido")
                .HeaderText = "Tasa IVA Ret"
                .Width = 80
                .ReadOnly = False
            End With

            With .Columns("total_impuesto_retenido")
                .HeaderText = "Total IVA Ret"
                .Width = 80
                .ReadOnly = False
            End With
        End With
    End Sub
    Private Sub obtener_variables_globales()
        rs.Open("SELECT serie FROM cfg_facturacion_serie WHERE deshabilitar='0' AND id_cfg_facturacion_serie='1'", conn)
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
    
    Private Sub frm_factura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_factura = 1
        aplicar_colores()
        configuracion_inicio()
        cargar_clientes()
        configuracion_listas()
        configuracion_tabla_factura()
        obtener_variables_globales()
        rellenar_catalogo_combobox("id_forma_pago", "forma_pago", "forma_pago", cb_pago_forma, , , "CONCAT(clave,'-',nombre) AS forma_pago")
        rellenar_catalogo_combobox("id_metodo_pago", "metodo_pago", "ctlg_metodo_pago", cb_pago_metodo, , , "CONCAT(clave,'-',nombre) AS metodo_pago")
        rellenar_catalogo_combobox("id_uso_cfdi", "uso_cfdi", "ctlg_uso_cfdi", cb_uso_cfdi, , , "CONCAT(clave,'-',nombre) AS uso_cfdi")
        rellenar_catalogo_combobox("id_tipo_relacion", "tipo_relacion", "ctlg_tipo_relacion", cb_tipo_relacion, , , "CONCAT(clave,'-',nombre) AS tipo_relacion")
        rellenar_catalogo_combobox("id_ctlg_moneda", "moneda", "ctlg_moneda", cb_moneda, , , "CONCAT(clave,'-',nombre) AS moneda")
        cargar_factura(0)

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
        With lst_facturas
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Folio", 80)
            .Columns.Add("Cliente", 110)
            .Columns.Add("fecha", 80)
            .Columns.Add("Total", 80)
        End With

        For Me.i = 0 To lst_facturas.Items.Count - 2 Step 2
            lst_facturas.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_facturas.Items(i).BackColor = Color.White
        Next


        With lst_documentos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Tipo Relación", 80)
            .Columns.Add("Documento", 110)
        End With

    End Sub
    Public Sub cargar_factura(Optional ByVal id As Integer = 0)

        id_factura_electronica = id

        xmlFile = Application.StartupPath & "/CFDI3.3/temp/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
        xmlTimbradoFile = Application.StartupPath & "/CFDI3.3/XML/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
        tb_numero_factura.ReadOnly = True
        tb_domicilio.Text = ""

        If id_factura_electronica > 0 Then


            rs.Open("SELECT id_factura_electronica,total,subtotal,iva,iva_retenido,id_cliente,id_empleado,fecha,year(fecha) anio,id_forma_pago,id_metodo_pago,id_moneda,tipo_cambio,condiciones_pago,pago_cuenta,estatus_timbrado,estatus " & _
                    "FROM factura_electronica " & _
                    "WHERE id_factura_electronica = " & id_factura_electronica, conn)

            id_cliente = rs.Fields("id_cliente").Value
            id_empleado = rs.Fields("id_empleado").Value

            tb_numero_factura.Text = num_serie & id_factura_electronica
            tb_fecha.Value = Format(rs.Fields("fecha").Value, "yyyy-MM-dd")

            '   Totales
            tb_subtotal.Text = "$ " & FormatNumber(rs.Fields("subtotal").Value, 2)
            tb_impuestos.Text = "$ " & FormatNumber(rs.Fields("iva").Value, 2)
            tb_retenciones.Text = "$ " & FormatNumber(rs.Fields("iva_retenido").Value, 2)
            tb_total.Text = "$ " & FormatNumber(rs.Fields("total").Value, 2)
            total_factura = rs.Fields("total").Value
            seleccionar_catalogo(rs.Fields("id_forma_pago").Value, cb_pago_forma)
            seleccionar_catalogo(rs.Fields("id_metodo_pago").Value, cb_pago_metodo)
            seleccionar_catalogo(rs.Fields("id_moneda").Value, cb_moneda)
            tb_pago_cuenta.Text = rs.Fields("pago_cuenta").Value
            tb_pago_condiciones.Text = rs.Fields("condiciones_pago").Value
            tb_tipo_cambio.Text = rs.Fields("tipo_cambio").Value

            lbl_estatus_timbrado.Visible = True
            lbl_estatus_timbrado.Text = rs.Fields("estatus_timbrado").Value

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


            dg_factura.Columns("cantidad").ReadOnly = False
            tb_fecha.Enabled = False
            cb_cliente.Enabled = False
            gp_agregar.Enabled = False
            btn_guardar.Enabled = False

            btn_cancelar.Visible = True
            tabla.Clear()
            total_productos = 0

            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT fed.*, fe.id_cliente,p.nombre as producto,u.nombre as unidad " & _
                     "FROM factura_electronica_detalle fed " & _
                     "JOIN factura_electronica fe ON fe.id_factura_electronica=fed.id_factura_electronica " & _
                     "JOIN producto p ON p.id_producto=fed.id_producto " & _
                     "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                     "WHERE fed.id_factura_electronica = " & id_factura_electronica, conn)
            If rs2.RecordCount > 0 Then
                While Not rs2.EOF
                    cargar_producto_factura(rs2.Fields("producto").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, rs2.Fields("nombre_impuesto").Value, rs2.Fields("precio").Value, rs2.Fields("importe").Value, rs2.Fields("total_impuesto").Value, rs2.Fields("tasa_impuesto").Value, rs2.Fields("nombre_impuesto_retenido").Value, rs2.Fields("tasa_impuesto_retenido").Value, rs2.Fields("total_impuesto_retenido").Value, rs2.Fields("id_producto").Value)
                    rs2.MoveNext()
                End While
            End If

            rs2.Close()


            lst_documentos.Items.Clear()
            cb_folio_fiscal.Text = ""
            '=====obtenemos los documentos relacionados
            rs.Open("SELECT fed.id_tipo_relacion, CONCAT(tr.clave,' ',tr.nombre) AS tipo_relacion,fed.UUID " & _
                    "FROM factura_electronica_docs fed " & _
                    "JOIN ctlg_tipo_relacion tr ON tr.id_tipo_relacion=fed.id_tipo_relacion " & _
                    "WHERE fed.id_factura_electronica=" & id_factura_electronica, conn)
            If rs.RecordCount > 0 Then
                i = 0
                While Not rs.EOF
                    Dim str(1) As String
                    str(0) = rs.Fields("tipo_relacion").Value
                    str(1) = rs.Fields("UUID").Value

                    lst_documentos.Items.Add(New ListViewItem(str, 0))
                    lst_documentos.Items(i).Tag = rs.Fields("id_tipo_relacion").Value
                    rs.MoveNext()
                    i = i + 1

                End While
            End If

            rs.Close()
            configuracion_inicio()
        Else
            '==========PREPARAMOS PARA NUEVA FACTURA===================
            tabla.Clear()
            total_productos = 0

            btn_cancelar.Visible = False

            dg_factura.Columns("cantidad").ReadOnly = False
            id_cliente = 0
            id_empleado = global_id_empleado

            rs.Open("SELECT IF(MAX(id_factura_electronica) IS NULL,1,MAX(id_factura_electronica)+1) numero from factura_electronica WHERE YEAR(fecha) = '" & Date.Today.Year & "'", conn)
            tb_numero_factura.Text = num_serie & rs.Fields("numero").Value
            rs.Close()
            tb_fecha.Value = Date.Today

            ' suma_subtotal = 0
            ' suma_impuesto = 0

            tb_subtotal.Text = "$ 0.00"
            tb_impuestos.Text = "$ 0.00"
            tb_total.Text = "$ 0.00"
            tb_pago_cuenta.Text = "No Aplica"
            tb_pago_condiciones.Text = ""
            tb_empleado.Text = global_nombre
            tb_tipo_cambio.Text = "1"

            tb_fecha.Enabled = True
            cb_cliente.Enabled = True
            btn_guardar.Enabled = False
            gp_agregar.Enabled = True
            limpiar_tickets_factura()
            index_matrix_tickets = 0
            tb_numero_factura.ReadOnly = True
            lbl_estatus_timbrado.Visible = False

            btn_timbrar.Enabled = False
            btn_enviar.Enabled = False
            btn_xml.Enabled = False
            btn_pdf.Enabled = False
            btn_cancelar.Enabled = False
            tb_aviso_cancelado.Visible = False
            btn_editar.Enabled = False
            gb_factura.Enabled = True

            lst_documentos.Items.Clear()
            cb_folio_fiscal.Text = ""

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
        cargado = True

    End Sub

    Private Sub agregar_producto(ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal impuesto As String, ByVal precio As Decimal, ByVal importe As Decimal, ByVal total_impuesto As Decimal, ByVal tasa_impuesto As Decimal, ByVal nombre_impuesto_retenido As String, ByVal tasa_impuesto_retenido As Decimal, ByVal total_impuesto_retenido As Decimal, Optional ByVal id_producto As Integer = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id_producto)
        Dim descuento As Decimal = 0

        If foundRows.Length > 0 Then

            If foundRows(0).Item("precio") = precio Then

                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + cantidad
                foundRows(0).Item("importe") = FormatNumber(foundRows(0).Item("precio") * foundRows(0).Item("cantidad"), 2)
                foundRows(0).Item("total_impuesto") = FormatNumber(foundRows(0).Item("importe") * foundRows(0).Item("tasa_impuesto"), 2)
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
            tabla_linea("importe") = importe
            tabla_linea("impuesto") = impuesto
            tabla_linea("total_impuesto") = total_impuesto
            tabla_linea("tasa_impuesto") = tasa_impuesto

            tabla_linea("nombre_impuesto_retenido") = nombre_impuesto_retenido
            tabla_linea("tasa_impuesto_retenido") = tasa_impuesto_retenido
            tabla_linea("total_impuesto_retenido") = total_impuesto_retenido

            tabla.Rows.Add(tabla_linea)
        End If
        actualizar_totales()
    End Sub
    Private Sub cargar_producto_factura(ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal impuesto As String, ByVal precio As Decimal, ByVal importe As Decimal, ByVal total_impuesto As Decimal, ByVal tasa_impuesto As Decimal, ByVal nombre_impuesto_retenido As String, ByVal tasa_impuesto_retenido As Decimal, ByVal total_impuesto_retenido As Decimal, Optional ByVal id_producto As Integer = 0)
        total_productos = total_productos + 1
            tabla_linea = tabla.NewRow()
            tabla_linea("id_producto") = id_producto
            tabla_linea("partida") = total_productos
            tabla_linea("descripcion") = descripcion
            tabla_linea("cantidad") = cantidad
            tabla_linea("unidad") = unidad
            tabla_linea("precio") = precio
            tabla_linea("importe") = importe
            tabla_linea("impuesto") = impuesto
            tabla_linea("total_impuesto") = total_impuesto
            tabla_linea("tasa_impuesto") = tasa_impuesto

            tabla_linea("nombre_impuesto_retenido") = nombre_impuesto_retenido
            tabla_linea("tasa_impuesto_retenido") = tasa_impuesto_retenido
            tabla_linea("total_impuesto_retenido") = total_impuesto_retenido

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

            total_productos = total_productos + 1
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
            tabla_linea("partida") = total_productos
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
        Dim total_impuestos As Decimal = 0
        Dim total_impuestos_retenidos As Decimal = 0

        For j = 0 To dg_factura.RowCount - 1
            subtotal = subtotal + (CDec(dg_factura.Rows(j).Cells("importe").Value))

            If CDec(dg_factura.Rows(j).Cells("total_impuesto").Value) > 0 Then
                total_impuestos += CDec(dg_factura.Rows(j).Cells("total_impuesto").Value)
            End If


            If CDec(dg_factura.Rows(j).Cells("total_impuesto_retenido").Value) > 0 Then
                total_impuestos_retenidos += CDec(dg_factura.Rows(j).Cells("total_impuesto_retenido").Value)
            End If
        Next

        tb_subtotal.Text = "$ " & Math.Round(subtotal, 2)
        tb_impuestos.Text = "$ " & Math.Round(total_impuestos, 2)
        tb_retenciones.Text = "$ " & Math.Round(total_impuestos_retenidos, 2)
        tb_total.Text = "$ " & Math.Round(subtotal + total_impuestos - total_impuestos_retenidos, 2)
    End Sub
    Private Sub limpiar_tabla()
        tabla.Clear()
        ' suma_subtotal = 0
        ' suma_impuesto = 0

        tb_subtotal.Text = "$ 0.00"
        tb_impuestos.Text = "$ 0.00"
        tb_total.Text = "$ 0.00"
        limpiar_tickets_factura()
        index_matrix_tickets = 0
    End Sub
    Private Sub cb_cliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        tb_domicilio.Text = ""
    End Sub
    Private Sub m_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_facturacion_electronica_abrir.ShowDialog()
    End Sub
    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bucar.Click
        global_frm_producto_abrir = 3
        frm_producto_abrir.ShowDialog()
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
    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        global_frm_cotizacion_abrir = 2
        ' frm_cotizacion_abrir.ShowDialog()
    End Sub

    Private Sub tb_total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_total.TextChanged
        If total_productos > 0 Then
            btn_guardar.Enabled = True
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
        If rb_ticket_alone.Checked = True Then
            If Trim(tb_ticket_alone.TextLength) <> 0 Then
                Dim id_cliente As Integer
                If tabla.Rows.Count = 0 Then
                    '---agregamos ticket seleccionado
                    '----1.-obtenemos el id_cliente del ticket
                    id_cliente = 0
                    rs.Open("SELECT id_cliente FROM venta WHERE id_factura=0 AND id_venta=" & tb_ticket_alone.Text, conn)
                    If rs.RecordCount > 0 Then
                        id_cliente = rs.Fields("id_cliente").Value
                    End If
                    rs.Close()

                    If id_cliente = 1 Then
                        If MsgBox("El ticket con el folio " & tb_ticket_alone.Text & " es de Publico General.¿ Desea agregar este ticket de todas formas? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                            GoTo A
                        End If
                    Else
                        If id_cliente <> 0 Then
A:                          If buscar_ticket(0, tb_ticket_alone.Text) Then
                                MsgBox("El ticket " & tb_ticket_alone.Text & " ya existe en esta factura")
                            Else
                                '========CAPTURAMOS LOS DATOS DEL TICKET EN LA FACTURA
                                rs.Open("SELECT v.id_cliente,v.total,vd.importe,vd.id_producto,p.nombre, u.nombre AS unidad,vd.cantidad, vd.precio,vd.total_impuestos,i.nombre AS nombre_impuesto,i.tasa AS tasa_impuesto " & _
                                        "FROM venta_detalle vd " & _
                                        "JOIN venta v ON v.id_venta=vd.id_venta " & _
                                        "JOIN producto p ON p.id_producto=vd.id_producto " & _
                                        "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                                        "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                                         "WHERE v.id_venta=" & tb_ticket_alone.Text, conn)
                                If rs.RecordCount > 0 Then

                                    While Not rs.EOF

                                        'suma_subtotal = suma_subtotal + rs.Fields("importe").Value
                                        'suma_impuesto = suma_impuesto + rs.Fields("total_impuestos").Value
                                        Dim importe As Decimal = FormatNumber(rs.Fields("precio").Value * rs.Fields("cantidad").Value, 2)
                                        Dim total_impuestos As Decimal = FormatNumber(importe * rs.Fields("tasa_impuesto").Value, 2)

                                        agregar_producto(rs.Fields("nombre").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("nombre_impuesto").Value, rs.Fields("precio").Value, importe, total_impuestos, rs.Fields("tasa_impuesto").Value, "", 0, 0, rs.Fields("id_producto").Value)
                                        rs.MoveNext()
                                    End While
                                End If
                                rs.Close()


                                tickes_facturas(index_matrix_tickets, 0) = 0
                                tickes_facturas(index_matrix_tickets, 1) = tb_ticket_alone.Text
                                index_matrix_tickets = index_matrix_tickets + 1
                            End If
                            If id_cliente <> 1 Then
                                seleccionar_catalogo(id_cliente, cb_cliente)
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
                                    '========CAPTURAMOS LOS DATOS DEL TICKET EN LA FACTURA
                                    rs.Open("SELECT v.id_cliente,v.total,vd.importe,vd.total_impuestos,vd.id_producto,p.nombre, u.nombre AS unidad,vd.cantidad, vd.precio,i.nombre AS nombre_impuesto,i.tasa AS tasa_impuesto " & _
                                            "FROM venta_detalle vd " & _
                                            "JOIN venta v ON v.id_venta=vd.id_venta " & _
                                            "JOIN producto p ON p.id_producto=vd.id_producto " & _
                                            "JOIN unidad u ON u.id_unidad=p.id_unidad " & _
                                            "JOIN cfg_impuesto i ON i.id_cfg_impuesto=p.id_impuesto " & _
                                             "WHERE v.id_venta=" & tb_ticket_alone.Text, conn)
                                    If rs.RecordCount > 0 Then

                                        While Not rs.EOF
                                            ' suma_subtotal = suma_subtotal + rs.Fields("importe").Value
                                            'suma_impuesto = suma_impuesto + rs.Fields("total_impuestos").Value

                                            Dim importe As Decimal = FormatNumber(rs.Fields("precio").Value * rs.Fields("cantidad").Value, 2)
                                            Dim total_impuestos As Decimal = FormatNumber(importe * rs.Fields("tasa_impuesto").Value, 2)

                                            agregar_producto(rs.Fields("nombre").Value, rs.Fields("cantidad").Value, rs.Fields("unidad").Value, rs.Fields("nombre_impuesto").Value, rs.Fields("precio").Value, importe, total_impuestos, rs.Fields("tasa_impuesto").Value, "", 0, 0, rs.Fields("id_producto").Value)
                                            rs.MoveNext()
                                        End While
                                    End If
                                    rs.Close()
                                    tickes_facturas(index_matrix_tickets, 0) = 0
                                    tickes_facturas(index_matrix_tickets, 1) = tb_ticket_alone.Text
                                    index_matrix_tickets = index_matrix_tickets + 1
                                End If

                                tb_ticket_alone.Text = ""
                            Else
                                If MsgBox("El ticket con el folio " & tb_ticket_alone.Text & " no pertenece a este cliente.¿ Desea continuar de todas formas? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                                    GoTo B
                                Else
                                    tb_ticket_alone.Text = ""
                                End If
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

        'tb_subtotal.Text = FormatCurrency(suma_subtotal)
        ' tb_impuestos.Text = FormatCurrency(suma_impuesto)
        ' tb_total.Text = FormatCurrency(suma_subtotal + suma_impuesto)
        tb_ticket_alone.Text = ""

    End Sub


    Private Sub tsb_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        imprimir_recibo_prefactura(id_factura_electronica)
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
            rs.Open("SELECT factura_electronica.fecha,factura_electronica.subtotal,factura_electronica.iva,factura_electronica.otros,factura_electronica.total,cliente.id_cliente as num_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS nombre,(SELECT CASE WHEN cliente.id_persona = 0 THEN  empresa.rfc ELSE persona.rfc END as rfc FROM cliente JOIN  factura_electronica ON factura_electronica.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura_electronica.id_factura_electronica=" & id_documento & ")As RFC FROM factura_electronica JOIN cliente ON factura_electronica.id_cliente=cliente.id_cliente LEFT OUTER JOIN persona ON persona.id_persona = cliente.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa WHERE factura_electronica.id_factura_electronica=" & id_documento, conn)
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
            rs.Open("SELECT factura_electronica_detalle.cantidad,factura_electronica_detalle.descripcion,factura_electronica_detalle.unidad,factura_electronica_detalle.precio_unitario,factura_electronica_detalle.importe,factura_electronica_detalle.total_porcent_iva,factura_electronica_detalle.total_porcent_otros, producto.codigo FROM factura_electronica_detalle JOIN producto ON producto.id_producto=factura_electronica_detalle.id_producto WHERE factura_electronica_detalle.id_factura_electronica=" & id_documento)
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
            Dim total As Decimal = Math.Round(subtotal + total_iva + total_otros, 2)
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
            tb_codigo.Enabled = True
            btn_agregar.Enabled = True
            btn_bucar.Enabled = True
        Else
            limpiar_tabla()
            tb_codigo.Enabled = False
            btn_agregar.Enabled = False
            btn_bucar.Enabled = False
        End If
    End Sub
    Private Sub btn_generar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        End If

        If id_factura_electronica = 0 Then
            If tb_ticket_alone.Text = "" Then
                'limpiar_tabla()
            End If
        End If
    End Sub

    Private Sub btn_cancelar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        If MsgBox("Esta seguro que desea cancelar esta factura", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

            conn.Execute("UPDATE venta SET id_factura='0' WHERE id_factura=" & id_factura_electronica)
            conn.Execute("UPDATE factura_electronica SET estatus='CANCELADA' WHERE id_factura_electronica=" & id_factura_electronica)

            cancelar_finkok()

            cargar_factura(id_factura_electronica)
            MsgBox("Factura cancelada correctamente", MsgBoxStyle.Information, "Aviso")
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

        Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
        Dim reader As XmlTextReader = New XmlTextReader(xmlTimbradoFile)
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()

                            If reader.Name = "UUID" Then
                                uuid_factura_timbra = reader.Value
                            End If
                        End While
                    End If
            End Select
        Loop

        Try
            FabricaPEM()
            Dim uuid() As String
            uuid = {uuid_factura_timbra}
            Dim folio_fiscal_cancelar As String = uuid_factura_timbra
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
            MessageBox.Show("No se cancelo la factura " & ex.Message)
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
        ConvierteCerAPem = "C:\OpenSSL\bin\" & "openssl.exe x509 -inform DER -outform PEM -in """ & ArchivoCer & """ -pubkey -out " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & Path.GetFileName(certificado_sat) & ".pem" & """"
        ConvierteKeyAPem = "C:\OpenSSL\bin\" & "openssl.exe pkcs8 -inform DER -in """ & ArchivoKey & """ -passin pass:" & contrasena_sat & " -out " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & Path.GetFileName(clave_sat) & ".pem" & """"
        EncriptaKey = "C:\OpenSSL\bin\" & "openssl.exe rsa -in " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & NombreArchivoLlave & ".pem""" & " -des3 -out " & """" & Application.StartupPath & "/CFDI3.3/cancelaciones/" & NombreArchivoLlave & ".enc""" & " -passout pass:" & "" & contraseña_pac & ""
        'Crea el archivo Certificado.BAT
        Dim oSW As New StreamWriter(Application.StartupPath & "/CFDI3.3/cancelaciones/" & "Certificado.bat")
        oSW.WriteLine(ConvierteCerAPem)
        oSW.WriteLine(ConvierteKeyAPem)
        oSW.WriteLine(EncriptaKey)
        oSW.Close()
        Process.Start(Application.StartupPath & "/CFDI3.3/cancelaciones/" & "Certificado.bat").WaitForExit()
    End Sub
    Private Sub timbrar_finkok()

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
            conn.Execute("UPDATE factura_electronica SET estatus_timbrado='TIMBRADA' WHERE id_factura_electronica=" & id_factura_electronica)

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

    Private Sub btn_timbrar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub generar_formato_pdf()
        Dim xmlTimbradoFile As String = Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
        Dim reader As XmlTextReader = New XmlTextReader(xmlTimbradoFile)
        Do While (reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()

                            If reader.Name = "UUID" Then
                                uuid_factura_timbra = reader.Value
                            ElseIf reader.Name = "SelloCFD" Then
                                sello_digital_emisor = reader.Value
                            End If
                        End While
                    End If
            End Select
        Loop

        QrCodeImgControl1.Text = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" & uuid_factura_timbra & "&re=" & global_rfc & "&rr=" & rfc_receptor & "&tt=" & total_factura & "&fe=" & sello_digital_emisor.Substring(sello_digital_emisor.Length - 8, 8)
        Dim qrcode As System.Drawing.Image = DirectCast(QrCodeImgControl1.Image.Clone, Image)
        qrcode.Save(Application.StartupPath & "/CFDI3.3/xml/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".png")
        qrcode.Dispose()

        GenerarFacturaElectronica(id_factura_electronica, False, "")
    End Sub

    Private Sub btn_enviar_factura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn_editar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub dg_factura_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dg_factura.UserDeletedRow
        actualizar_totales()
    End Sub

    Private Sub dg_factura_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_factura.CellContentClick

    End Sub

    Private Sub btn_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nuevo.Click
        cargar_factura(0)
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores:" & vbCrLf

        If cb_pago_metodo.SelectedIndex = -1 Then
            mensaje = mensaje & "   *Debe seleccionar un metodo de pago" & vbCrLf
            correcto = False
        End If
        If cb_pago_forma.SelectedIndex = -1 Then
            mensaje = mensaje & "   *Debe seleccionar una forma de pago" & vbCrLf
            correcto = False
        End If

        If Trim(tb_numero_factura.TextLength) = 0 Then
            MsgBox("El numero de factura no puede estar vacio", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If


        If correcto = True Then
            If id_factura_electronica > 0 Then

                '============ACTUALIZAMOS LA FACTURA ELECTRONICA=======================
                Dim numero As String = ""
                numero = tb_numero_factura.Text



                conn.Execute("UPDATE factura_electronica SET serie='" & num_serie & "',fecha=NOW(),subtotal='" & CDec(tb_subtotal.Text) & "',iva='" & CDec(tb_impuestos.Text) & "',iva_retenido='" & CDec(tb_retenciones.Text) & "',total='" & CDec(tb_total.Text) & "',id_cliente=" & id_cliente & ",descuento='" & cliente_descuento & "',id_empleado=" & id_empleado & ",id_forma_pago='" & CType(cb_pago_forma.SelectedItem, myItem).Value & "',id_metodo_pago='" & CType(cb_pago_metodo.SelectedItem, myItem).Value & "',id_moneda='" & CType(cb_moneda.SelectedItem, myItem).Value & "',tipo_cambio='" & tb_tipo_cambio.Text & "',id_uso_cfdi='" & CType(cb_uso_cfdi.SelectedItem, myItem).Value & "',pago_cuenta='" & tb_pago_cuenta.Text & "',condiciones_pago='" & tb_pago_condiciones.Text & "' WHERE id_factura_electronica='" & id_factura_electronica & "'")
                conn.Execute("DELETE FROM factura_electronica_detalle WHERE id_factura_electronica='" & id_factura_electronica & "'")

                For row = 0 To tabla.Rows.Count - 1
                    conn.Execute("INSERT INTO factura_electronica_detalle (id_factura_electronica,id_producto,cantidad,total_impuesto,tasa_impuesto,nombre_impuesto,precio,importe,nombre_impuesto_retenido,tasa_impuesto_retenido,total_impuesto_retenido) VALUES" & _
                                 " (" & id_factura_electronica & "," & dg_factura.Item("id_producto", row).Value & ",'" & dg_factura.Item("cantidad", row).Value & "'," & dg_factura.Item("total_impuesto", row).Value & ",'" & dg_factura.Item("tasa_impuesto", row).Value & "','" & dg_factura.Item("impuesto", row).Value & "','" & dg_factura.Item("precio", row).Value & "','" & dg_factura.Item("importe", row).Value & "','" & dg_factura.Item("nombre_impuesto_retenido", row).Value & "','" & dg_factura.Item("tasa_impuesto_retenido", row).Value & "','" & dg_factura.Item("total_impuesto_retenido", row).Value & "')")

                Next

                For x = 0 To 100

                    If Not IsNothing(tickes_facturas(x, 0)) Then
                        If tickes_facturas(x, 0) = 0 Then
                            conn.Execute("UPDATE venta SET id_factura=" & id_factura_electronica & " WHERE id_venta=" & tickes_facturas(x, 1))
                        End If
                    Else
                        Exit For
                    End If
                Next



                conn.Execute("DELETE FROM factura_electronica_docs WHERE id_factura_electronica='" & id_factura_electronica & "'")
                For x = 0 To lst_documentos.Items.Count - 1
                    conn.Execute("INSERT INTO factura_electronica_docs(id_factura_electronica,id_tipo_relacion,UUID) VALUES('" & id_factura_electronica & "','" & lst_documentos.Items(x).Tag & "','" & lst_documentos.Items(x).SubItems(1).Text & "')")
                Next
                '===================verificamos si toda la factura esta pagada==============
                Dim importe_total_tickets As Decimal = 0
                rs.Open("SELECT total from venta WHERE id_factura='" & id_factura_electronica & "' AND status='CERRADA'", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        importe_total_tickets += rs.Fields("total").Value
                        rs.MoveNext()
                    End While
                End If
                rs.Close()

                If CDec(tb_total.Text) = importe_total_tickets Then
                    conn.Execute("UPDATE factura_electronica SET estatus='PAGADO' WHERE id_factura_electronica=" & id_factura_electronica)
                End If


                btn_guardar.Enabled = False

                cargar_factura(id_factura_electronica)

                MsgBox("La factura electrónica " & tb_numero_factura.Text & "se ha actualizado!" & vbCrLf, MsgBoxStyle.Information, "Aviso")

            Else
                '=================insertamos nueva factura====================
                Dim numero As String = ""

                numero = tb_numero_factura.Text

                conn.Execute("INSERT INTO factura_electronica (serie,fecha,subtotal,iva,iva_retenido,total,id_cliente,descuento,id_empleado,id_forma_pago,id_metodo_pago,id_uso_cfdi,pago_cuenta,condiciones_pago,id_moneda,tipo_cambio) VALUES" & _
                             " ('" & num_serie & "',NOW(),'" & CDec(tb_subtotal.Text) & "','" & CDec(tb_impuestos.Text) & "','" & CDec(tb_retenciones.Text) & "','" & CDec(tb_total.Text) & "'," & id_cliente & ",'" & cliente_descuento & "'," & id_empleado & ",'" & CType(cb_pago_forma.SelectedItem, myItem).Value & "','" & CType(cb_pago_metodo.SelectedItem, myItem).Value & "','" & CType(cb_uso_cfdi.SelectedItem, myItem).Value & "','" & tb_pago_cuenta.Text & "','" & tb_pago_condiciones.Text & "','" & CType(cb_moneda.SelectedItem, myItem).Value & "','" & tb_tipo_cambio.Text & "')")

                rs.Open("SELECT last_insert_id() id_factura_electronica", conn)
                id_factura_electronica = rs.Fields("id_factura_electronica").Value
                rs.Close()


                For row = 0 To tabla.Rows.Count - 1
                    conn.Execute("INSERT INTO factura_electronica_detalle (id_factura_electronica,id_producto,cantidad,total_impuesto,tasa_impuesto,nombre_impuesto,precio,importe,nombre_impuesto_retenido,tasa_impuesto_retenido,total_impuesto_retenido) VALUES" & _
                                " (" & id_factura_electronica & "," & dg_factura.Item("id_producto", row).Value & ",'" & dg_factura.Item("cantidad", row).Value & "'," & dg_factura.Item("total_impuesto", row).Value & ",'" & dg_factura.Item("tasa_impuesto", row).Value & "','" & dg_factura.Item("impuesto", row).Value & "','" & dg_factura.Item("precio", row).Value & "','" & dg_factura.Item("importe", row).Value & "','" & dg_factura.Item("nombre_impuesto_retenido", row).Value & "','" & dg_factura.Item("tasa_impuesto_retenido", row).Value & "','" & dg_factura.Item("total_impuesto_retenido", row).Value & "')")

                Next

                For x = 0 To 100
                    If Not IsNothing(tickes_facturas(x, 0)) Then
                        If tickes_facturas(x, 0) = 0 Then
                            conn.Execute("UPDATE venta SET id_factura=" & id_factura_electronica & " WHERE id_venta=" & tickes_facturas(x, 1))
                        End If
                    Else
                        Exit For
                    End If
                Next

                Dim importe_total_tickets As Decimal = 0
                rs.Open("SELECT total from venta WHERE id_factura='" & id_factura_electronica & "' AND status='CERRADA'", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        importe_total_tickets += rs.Fields("total").Value
                        rs.MoveNext()
                    End While
                End If
                rs.Close()


                If CDec(tb_total.Text) = importe_total_tickets Then
                    conn.Execute("UPDATE factura_electronica SET estatus='PAGADO' WHERE id_factura_electronica=" & id_factura_electronica)
                End If

                For x = 0 To lst_documentos.Items.Count - 1
                    conn.Execute("INSERT INTO factura_electronica_docs(id_factura_electronica,id_tipo_relacion,UUID) VALUES('" & id_factura_electronica & "','" & lst_documentos.Items(x).Tag & "','" & lst_documentos.Items(x).SubItems(1).Text & "')")
                Next


                btn_guardar.Enabled = False
                cargar_factura(id_factura_electronica)
                MsgBox("La factura electrónica se ha generado con el Número " & vbCrLf & tb_numero_factura.Text, MsgBoxStyle.Information, "Aviso")
            End If
            cargar_facturas_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
        Else
            MsgBox(mensaje)
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar.Click
        tb_fecha.Enabled = True
        cb_cliente.Enabled = True
        btn_guardar.Enabled = True
        gp_agregar.Enabled = True
        btn_timbrar.Enabled = False
        gb_factura.Enabled = True
        gb_listado.Enabled = False
        btn_deshacer.Enabled = True
        btn_nuevo.Enabled = False
    End Sub

    Private Sub btn_timbrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_timbrar.Click
        Try
            ' GenerarXML(id_factura_electronica)
            'tb_cadena_original.Text = GetCadenaOriginal(xmlFile, xsltFile)
            'tb_cadena_original_PAC.Text = GetCadenaSAT(IO.Path.Combine(Application.StartupPath, xmlFile), xsltPACFile)
            Genera_CFDI3_3(id_factura_electronica, num_serie)
            timbrar_finkok()
            generar_formato_pdf()
            cargar_factura(id_factura_electronica)
        Catch ex As Exception
            MsgBox("Ocurrio un error al generar la factura " & ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub btn_enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_enviar.Click
        enviar_factura_email(id_factura_electronica)
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

                    Dim Source As String = Application.StartupPath & "/CFDI3.3/XML/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
                    Dim Destination As String = ruta_destino_xml & "/" & global_rfc & num_serie & Format(id_factura_electronica, "0000000000") & ".xml"
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
        cargar_facturas_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
    End Sub
    Private Sub cargar_facturas_cliente(ByVal id_cliente As Integer, ByVal buscar As String, Optional ByVal pagina As Integer = 1)
        tb_pagina.Text = pagina
        inicial = (pagina - 1) * reg_por_pag

        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_facturas.Items.Clear()
        If id_cliente > 0 Then
            filtro = " WHERE f.id_cliente='" & id_cliente & "'"
        End If

        If buscar.Length > 0 Then
            If id_cliente > 0 Then
                filtro = filtro & " AND f.id_factura_electronica LIKE '%" & buscar & "%'"
            Else
                filtro = " WHERE f.id_factura_electronica LIKE '%" & buscar & "%'"
            End If

        End If


        rs.Open("SELECT count(*) as total_facturas FROM factura_electronica f " & filtro, conn)
        total_facturas = rs.Fields("total_facturas").Value
        rs.Close()

        total_paginas = Ceiling(total_facturas / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas


        rs.Open("SELECT f.id_factura_electronica,f.serie,f.fecha,f.total, CASE WHEN c.id_persona = 0 THEN  e.razon_social ELSE CONCAT(p.nombre,' ',p.ap_paterno,' ',p.ap_materno) END AS razon_social, CASE WHEN c.id_persona = 0 THEN  e.rfc ELSE p.rfc END AS registro " & _
                "FROM factura_electronica f " & _
                "JOIN cliente c ON c.id_cliente=f.id_cliente " & _
                "LEFT OUTER JOIN persona p ON c.id_persona = p.id_persona " & _
                "LEFT OUTER JOIN empresa e ON c.id_empresa = e.id_empresa " & filtro & "ORDER BY f.id_factura_electronica DESC LIMIT " & inicial & "," & reg_por_pag, conn)
        If rs.RecordCount > 0 Then

            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("serie").Value & rs.Fields("id_factura_electronica").Value
                str(1) = rs.Fields("registro").Value
                str(2) = FormatDateTime(rs.Fields("fecha").Value, DateFormat.ShortDate)
                str(3) = FormatCurrency(rs.Fields("total").Value, 2)

                lst_facturas.Items.Add(New ListViewItem(str, 0))
                lst_facturas.Items(i).Tag = rs.Fields("id_factura_electronica").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If

        tb_resultados.Text = total_facturas & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()

        aplicar_estilo_facturas()

    End Sub
    Private Sub aplicar_estilo_facturas()

        For Me.i = 0 To lst_facturas.Items.Count - 2 Step 2
            lst_facturas.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_facturas.Items(i).BackColor = Color.White
        Next
    End Sub

    Private Sub btn_buscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        cargar_facturas_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
    End Sub

    Private Sub lst_facturas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lst_facturas.DoubleClick
        If lst_facturas.SelectedItems.Count > 0 Then
            cargar_factura(lst_facturas.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_deshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
        cargar_factura(id_factura_electronica)
    End Sub

    Private Sub btn_agregar_folio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_folio.Click
        If Trim(cb_folio_fiscal.Text) <> "" Then
            Dim str(1) As String
            str(0) = cb_tipo_relacion.Text
            str(1) = cb_folio_fiscal.Text

            lst_documentos.Items.Add(New ListViewItem(str, 0))
            lst_documentos.Items(lst_documentos.Items.Count - 1).Tag = CType(cb_tipo_relacion.SelectedItem, myItem).Value
        Else
            MsgBox("Indique el documento relacionado")
        End If
    End Sub

    Private Sub btn_eliminar_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_doc.Click
        For x = 0 To lst_documentos.Items.Count - 1
            If lst_documentos.Items(x).Selected = True Then
                lst_documentos.Items(x).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub pb_anterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar_facturas_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_siguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar_facturas_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub tb_pagina_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar_facturas_cliente(CType(cb_cliente_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
            End If
        End If
    End Sub
End Class