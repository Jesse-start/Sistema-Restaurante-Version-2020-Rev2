Public Class frm_traspasos_envio
    Dim id_traspaso As Integer = 0
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
        Panel7.BackColor = Color.FromArgb(conf_colores(1))
        gbRecepcion.ForeColor = Color.FromArgb(conf_colores(2))
        gb_producto.ForeColor = Color.FromArgb(conf_colores(2))
        gb_sucursal.ForeColor = Color.FromArgb(conf_colores(2))

        lblFacturaProveedor.ForeColor = Color.FromArgb(conf_colores(13))
        lblFechaRecepcion.ForeColor = Color.FromArgb(conf_colores(13))
        lblNombrePersona.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_sucursal.ForeColor = Color.FromArgb(conf_colores(13))

        Label12.ForeColor = Color.FromArgb(conf_colores(13))
        Label16.ForeColor = Color.FromArgb(conf_colores(13))
        Label19.ForeColor = Color.FromArgb(conf_colores(13))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        label3.ForeColor = Color.FromArgb(conf_colores(13))
        label43.ForeColor = Color.FromArgb(conf_colores(13))
        Label7.ForeColor = Color.FromArgb(conf_colores(13))
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
        btn_agregar.ForeColor = Color.FromArgb(conf_colores(9))

        btn_buscar.BackColor = Color.FromArgb(conf_colores(8))
        btn_buscar.ForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_compras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        ' habilitar_menu_ventana()
        global_frm_traspasos_envio = 0
        ''conn.close()
    End Sub
    Private Sub inicializar_Combobox()
        llenar_Almacenes()
        cargar_empleados()
    End Sub
    Private Sub llenar_Almacenes()
        cb_almacen.Items.Clear()
        'Conectar()
        rs.Open("SELECT ID_Almacen, Nombre FROM almacenes", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_almacen.Items.Add(New myItem(rs.Fields("ID_Almacen").Value, rs.Fields("Nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
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
    Private Sub obtener_sucursales()
        cb_sucursales.Items.Clear()
        cb_sucursales.Text = "Seleccione"
        'Conectar()
        rs.Open("SELECT id_sucursal,alias FROM sucursal", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_sucursales.Items.Add(New myItem(rs.Fields("id_sucursal").Value, rs.Fields("alias").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub frm_compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        global_frm_traspasos_envio = 1
        aplicar_colores()
        obtener_sucursales()
        tsb_imprimir.Visible = False
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
            'Ocultos
            .Add(New DataColumn("id_producto", GetType(Integer)))
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
            .Columns("partida").Visible = False

            'With .Columns("partida")
            ' .HeaderText = "Partida"
            '.Width = 45
            '.ReadOnly = True
            'End With
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
                .Width = 100
                .ReadOnly = True
            End With
            With .Columns("descripcion")
                .HeaderText = "Descripcion"
                .Width = 250
                .ReadOnly = True
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
            'With .Columns("importe")
            '.HeaderText = "Importe Sin impuestos"
            '.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Width = 100
            ' .DefaultCellStyle.Format = "c"
            '.ReadOnly = True
            ' .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' End With
        End With

        'Panel1.Enabled = False


        m_guardar.Enabled = False
        'gb_sucursal.Enabled = True
        'gb_producto.Enabled = True
        'm_exportar.Enabled = False
        cargado = True

    End Sub
    Public Sub cargar(Optional ByVal id As Integer = 0)
        'Dim id_almacen As Integer
        
        id_proveedor = 0
        Panel1.Enabled = True
        id_traspaso = id
        ' Cliente
        tb_folio_traspaso.Enabled = True
        tsb_imprimir.Visible = False
        inicializar_Combobox()



        If id_traspaso > 0 Then
            'm_abrir.Enabled = False
            tsb_imprimir.Visible = True
            tb_folio_traspaso.Enabled = False
            tb_folio.Text = id_traspaso
            'Conectar()
            rs.Open("SELECT fecha,nombre_empleado,sucursal_destino FROM traspaso_env WHERE id_traspaso_env=" & id_traspaso, conn)
            tb_folio_traspaso.Text = id_traspaso
            cb_sucursales.Text = rs.Fields("sucursal_destino").Value
            rs.Close()
            dg_cotizacion.Columns("cantidad").ReadOnly = True
            m_guardar.Enabled = False
            gb_producto.Enabled = False
            gb_sucursal.Enabled = False
            tabla.Clear()
            total_productos = 0

            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT traspaso_env_detalle.*,producto.thumb,producto.codigo from traspaso_env_detalle JOIN producto ON traspaso_env_detalle.id_producto=producto.id_producto  WHERE id_traspaso_env = " & id_traspaso, conn)
            While Not rs2.EOF
                agregar_producto(rs2.Fields("codigo").Value, rs2.Fields("descripcion").Value, rs2.Fields("cantidad").Value, rs2.Fields("unidad").Value, obtener_miniatura(rs2.Fields("thumb").Value))
                rs2.MoveNext()
            End While
            rs2.Close()
            'conn.close()
        Else
            tabla.Clear()
            total_productos = 0
            dg_cotizacion.Columns("cantidad").ReadOnly = False
            id_proveedor = 0
            id_empleado = global_id_empleado
            ' Cotizacion
            ' Total
            'm_abrir.Enabled = True
            m_guardar.Enabled = False
            gb_producto.Enabled = True
            gb_sucursal.Enabled = True
            'obtenemos el folio
            'Conectar()
            rs.Open("Select CASE when max(id_traspaso_env) is null then 1 else max(id_traspaso_env)+1 end  as folio from traspaso_env", conn)
            tb_folio.Text = rs.Fields("folio").Value
            rs.Close()
            'conn.close()
            'conn = Nothing
            '-------------------
        End If

        tb_codigo.Focus()
    End Sub
    Private Sub agregar_producto(ByVal codigo As String, ByVal descripcion As String, ByVal cantidad As Decimal, ByVal unidad As String, ByVal imagen As Object)
        total_productos = total_productos + 1
        tabla_linea = tabla.NewRow()
        tabla_linea("partida") = total_productos
        tabla_linea("codigo") = codigo
        tabla_linea("imagen") = imagen
        tabla_linea("descripcion") = descripcion
        tabla_linea("cantidad") = cantidad
        tabla_linea("unidad") = unidad
        tabla.Rows.Add(tabla_linea)
    End Sub
    Public Sub agregar_producto(ByVal id As Integer, Optional ByVal actualizar As Boolean = False, Optional ByVal cantidad As Integer = 0)
        Dim foundRows() As Data.DataRow = tabla.Select("id_producto = " & id)
        Dim descuento As Decimal = 0
        If foundRows.Length > 0 Then
            If Not actualizar Then
                '---validamos las existencias
                'Conectar()
                Dim id_almacen = obtener_idalmacen(foundRows(0).Item("id_producto"))
                'conn.close()
                'conn = Nothing
                Dim stock As Decimal = validar_existencia_producto(foundRows(0).Item("id_producto"), id_almacen)
                If stock >= CDec(foundRows(0).Item("cantidad") + 1) Then
                    foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
                Else
                    MsgBox("No se puede relizar traspaso de este producto,solo se encuentran " & stock & " unidades en almacen", MsgBoxStyle.Critical, "Error")
                End If
                '-----------------------------
            End If
        Else

            '---validamos las existencias
            'Conectar()
            Dim id_almacen = obtener_idalmacen(id)
            'conn.close()
            'conn = Nothing

            Dim stock As Decimal = validar_existencia_producto(id, id_almacen)
            If stock > 0 Then
                'Conectar()
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

                rs.Close()
                tabla.Rows.Add(tabla_linea)
                m_guardar.Enabled = True
            Else
                MsgBox("No se puede relizar traspaso de este producto,solo se encuentran " & stock & " unidades en almacen", MsgBoxStyle.Critical, "Error")
            End If
            '-----------------------------

        End If
    End Sub

    Private Sub actualizar_partida()
        Dim j As Integer

        For j = 0 To dg_cotizacion.RowCount - 1
            dg_cotizacion.Rows(j).Cells("partida").Value = j + 1
            total_productos = j + 1
        Next
    End Sub

    Private Sub m_nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_nuevo.Click
        cargar()
    End Sub

    Private Sub m_abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_abrir.Click
        frm_traspasos_envio_abrir.ShowDialog()
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

    Private Sub dg_cotizacion_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellEndEdit
        dg_cotizacion_CellValueChanged(sender, e)
    End Sub
    Private Sub dg_cotizacion_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dg_cotizacion.CellValidating
        If id_traspaso = 0 Then
            'Dim newInteger As Integer
            'If dg_cotizacion.Rows(e.RowIndex).IsNewRow Then Return
            'If dg_cotizacion.Columns("cantidad").Index = e.ColumnIndex Then
            'If Not Integer.TryParse(e.FormattedValue.ToString(), newInteger) OrElse newInteger <= 0 Then
            'e.Cancel = True
            'MsgBox("Solo se permiten valores enteros mayores a 0", MsgBoxStyle.Information, "Error en el tipo de dato")
            'dg_cotizacion.Rows(e.RowIndex).ErrorText = "Solo se permiten valores enteros mayores a 0"
            'End If
            'End If
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub dg_cotizacion_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_cotizacion.CellValueChanged
        If cargado Then
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
    Private Sub celda_pbk(ByRef objeto As Object)
        objeto.Borders.Color = Color.White
        objeto.Interior.Color = Color.FromArgb(255, 102, 0)
        objeto.Font.Bold = True
        objeto.Font.Color = Color.White
        ' objeto.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
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
                dg_cotizacion.Columns("descripcion").Width = 40 + Me.Width - 900
            Else
                dg_cotizacion.Columns("descripcion").Width = 250
            End If
        End If
    End Sub
    Private Sub dg_cotizacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_cotizacion.DoubleClick
        If id_traspaso = 0 Then
            If MsgBox("Desea eliminar este Producto de la lista", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                dg_cotizacion.Rows.RemoveAt(dg_cotizacion.CurrentRow.Index)
                If dg_cotizacion.Rows.Count = 0 Then
                    total_productos = 0
                    m_guardar.Enabled = False
                End If
                actualizar_partida()
            End If
        End If
    End Sub
    Private Sub tsb_imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_imprimir.Click
        Dim x As Integer
        If MsgBox("A continuación se imprimirá el ticket de traspaso de producto. ¿Desea imprimir una copia?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            For x = 0 To 1
                imprimir_traspaso_env(id_traspaso, x)
            Next
        Else
            imprimir_traspaso_env(id_traspaso, 0)
        End If
    End Sub
    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn_punto.Click
        If TypeOf sender Is Button Then
            If no_campo = 1 Then
                tb_codigo.Focus()
                SendKeys.Send(CType(sender, Button).Text)
            ElseIf no_campo = 2 Then
                tb_folio_traspaso.Focus()
                SendKeys.Send(CType(sender, Button).Text)
            End If
        End If
    End Sub
    Private Sub dg_cotizacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_cotizacion.Click
        If dg_cotizacion.Rows.Count > 0 Then
            If dg_cotizacion.CurrentCell.ColumnIndex = 4 Then
                frm_teclado_numerico.modo = 3
                frm_teclado_numerico.ShowDialog()
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
            tb_folio_traspaso.Text = ""
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If no_campo = 1 Then
            If tb_codigo.TextLength > 0 Then
                tb_codigo.Text = tb_codigo.Text.Remove(tb_codigo.TextLength - 1, 1)
                tb_codigo.SelectionStart = Len(tb_codigo.Text)
            End If
        ElseIf no_campo = 2 Then
            If tb_folio_traspaso.TextLength > 0 Then
                tb_folio_traspaso.Text = tb_folio_traspaso.Text.Remove(tb_folio_traspaso.TextLength - 1, 1)
                tb_folio_traspaso.SelectionStart = Len(tb_folio_traspaso.Text)
            End If
        End If
    End Sub

    Private Sub btn_bucar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        frm_producto_busqueda._modo = 3
        frm_producto_busqueda.Show()
    End Sub
    Private Sub tb_NFactura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_folio_traspaso.Click
        no_campo = 2
    End Sub

    Public Sub modificar_cantidad(ByVal cantidad As Decimal)
        '---validamos las existencias
        'Conectar()
        Dim id_almacen As Integer = obtener_idalmacen(dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_producto").Value)
        'conn.close()
        'conn = Nothing

        Dim stock As Decimal = validar_existencia_producto(dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("id_producto").Value, id_almacen)
        If stock >= cantidad Then
            dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("cantidad").Value = cantidad
        Else
            MsgBox("No se puede relizar traspaso de este producto,solo se encuentran " & stock & " unidades en almacen", MsgBoxStyle.Critical, "Error")
        End If
        '-----------------------------
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_guardar.Click
        '===verificamos todos los campos================
        Dim x As Integer
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf

        ' If tb_folio_traspaso.Text = "" Then
        'cadena = cadena & "  *" & vbCrLf
        'bandera_correcto = False
        'End If
        'If cb_nombreReceptor.SelectedIndex = -1 Then
        'cadena = cadena & "  *Persona que recibe" & vbCrLf
        'bandera_correcto = False
        'End If

        If cb_sucursales.SelectedIndex = -1 Then
            cadena = cadena & "  *Sucursal destino" & vbCrLf
            bandera_correcto = False
        End If

        '=========================================
        If bandera_correcto = True Then
            If MsgBox("Confirme que desea traspasar productos", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

                Dim correcto As Boolean = True
                'Conectar()
                For x = 0 To tabla.Rows.Count - 1
                    rs.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & dg_cotizacion.Rows(x).Cells("id_producto").Value & "' AND id_almacen=" & obtener_idalmacen(dg_cotizacion.Rows(x).Cells("id_producto").Value), conn)
                    If rs.RecordCount > 0 Then
                        If rs.Fields("cantidad").Value <> 0 Then
                            If rs.Fields("cantidad").Value < dg_cotizacion.Rows(x).Cells("cantidad").Value Then
                                correcto = False
                            End If
                        End If
                    Else
                        correcto = False
                    End If
                    rs.Close()
                Next
                'conn.close()
                'conn = Nothing
                If correcto = True Then
                    'Conectar()
                    conn.Execute("INSERT INTO traspaso_env(fecha,id_empleado,nombre_empleado,id_sucursal_destino,sucursal_destino) VALUES" & _
                              " (NOW(),'" & global_id_empleado & "', '" & global_usuario_nombre & "', '" & CType(cb_sucursales.SelectedItem, myItem).Value & "', '" & cb_sucursales.Text & "')", , -1)

                    Dim id_traspaso_env As Integer = 0

                    rs.Open("SELECT last_insert_id() id_traspaso_env", conn)
                    id_traspaso_env = rs.Fields("id_traspaso_env").Value
                    rs.Close()

                    For row = 0 To tabla.Rows.Count - 1
                        Dim id_almacen = obtener_idalmacen(dg_cotizacion.Item("id_producto", row).Value)
                        conn.Execute("INSERT INTO traspaso_env_detalle(id_traspaso_env,id_producto,cantidad,unidad,descripcion) VALUES " & _
                                         " (" & id_traspaso_env & ",'" & dg_cotizacion.Item("id_producto", row).Value & "','" & dg_cotizacion.Item("cantidad", row).Value & "','" & dg_cotizacion.Item("unidad", row).Value & "','" & dg_cotizacion.Item("descripcion", row).Value & "')", , -1)
                        conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & dg_cotizacion.Item("cantidad", row).Value & ") WHERE id_producto=" & dg_cotizacion.Item("id_producto", row).Value & " AND id_almacen=" & id_almacen & "")
                    Next

                    'conn.close()
                    'conn = Nothing
                    cargar(id_traspaso_env)
                    MsgBox("El traspaso ha sido registrado y se ha actualizado los almacenes", MsgBoxStyle.Information, "Correcto")
                Else
                    MsgBox("Al parecer algun producto no se encontro en el inventario. " & vbCrLf & " Es posible que ha sido dado de baja mientras realizaba esta operacion. " & vbCrLf & "Se ha cancelado la operación")
                End If
            End If
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub cb_sucursales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_sucursales.KeyDown
        cb_sucursales.DroppedDown = False
    End Sub
End Class