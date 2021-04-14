Public Class frm_traspasos_recepcion
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
        gb_recepcion.ForeColor = Color.FromArgb(conf_colores(2))
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
        global_frm_traspasos_recepcion = 0
        ''conn.close()
    End Sub
    Private Sub inicializar_Combobox()
        llenar_Almacenes()

        cargar_empleados()
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
        global_frm_traspasos_recepcion = 1
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
        dtp_recepcion.Enabled = True
        cb_nombreReceptor.Enabled = True
        tsb_imprimir.Visible = False
        inicializar_Combobox()
        If id_traspaso > 0 Then
            tsb_imprimir.Visible = True
            tb_folio_traspaso.Enabled = False
            dtp_recepcion.Enabled = False
            cb_nombreReceptor.Enabled = False
            tb_folio.Text = id_traspaso
            'Conectar()
            rs.Open("SELECT fecha,empleado_recep,sucursal_origen,folio_origen FROM traspaso_recep WHERE id_traspaso_recep=" & id_traspaso, conn)
            dtp_recepcion.Value = rs.Fields("fecha").Value
            cb_nombreReceptor.Text = rs.Fields("empleado_recep").Value
            tb_folio_traspaso.Text = rs.Fields("folio_origen").Value
            cb_sucursales.Text = rs.Fields("sucursal_origen").Value
            rs.Close()
            dg_cotizacion.Columns("cantidad").ReadOnly = True
            gb_producto.Enabled = False
            m_guardar.Enabled = False
            gb_sucursal.Enabled = False
            tabla.Clear()
            total_productos = 0

            Dim rs2 As ADODB.Recordset = New ADODB.Recordset

            rs2.Open("SELECT traspaso_recep_detalle.*,producto.thumb,producto.codigo from traspaso_recep_detalle JOIN producto ON traspaso_recep_detalle.id_producto=producto.id_producto  WHERE id_traspaso_recep = " & id_traspaso, conn)
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
            'm_exportar.Enabled = False
            m_guardar.Enabled = False
            gb_recepcion.Enabled = True
            gb_producto.Enabled = True
            gb_sucursal.Enabled = True
            'obtenemos el folio
            'Conectar()
            rs.Open("Select CASE when max(id_traspaso_recep) is null then 1 else max(id_traspaso_recep)+1 end  as folio from traspaso_recep", conn)
            tb_folio.Text = rs.Fields("folio").Value
            rs.Close()
            'conn.close()
            'conn = Nothing
            '-------------------
        End If

        tb_codigo.Focus()
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

        If foundRows.Length > 0 Then
            If Not actualizar Then
                foundRows(0).Item("cantidad") = foundRows(0).Item("cantidad") + 1
            End If
        Else
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
        frm_traspasos_recepcion_abrir.ShowDialog()
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
                imprimir_traspaso_recep(id_traspaso, x)
            Next
        Else
            imprimir_traspaso_recep(id_traspaso, 0)
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
            If id_traspaso = 0 Then
                If dg_cotizacion.CurrentCell.ColumnIndex = 4 Then
                    frm_teclado_numerico.modo = 2
                    frm_teclado_numerico.ShowDialog()
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
        frm_producto_busqueda._modo = 2
        frm_producto_busqueda.Show()
    End Sub
    Private Sub tb_NFactura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_folio_traspaso.Click
        no_campo = 2
    End Sub
    Public Sub modificar_cantidad(ByVal cantidad As Decimal)
        dg_cotizacion.Rows(dg_cotizacion.CurrentRow.Index).Cells("cantidad").Value = cantidad
    End Sub
    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
    Private Sub m_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_guardar.Click
        '===verificamos todos los campos================
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf

        If tb_folio_traspaso.Text = "" Then
            cadena = cadena & "  *" & vbCrLf
            bandera_correcto = False
        End If
        If cb_nombreReceptor.SelectedIndex = -1 Then
            cadena = cadena & "  *Persona que recibe" & vbCrLf
            bandera_correcto = False
        End If

        If cb_sucursales.SelectedIndex = -1 Then
            cadena = cadena & "  *Sucursal origen" & vbCrLf
            bandera_correcto = False
        End If

        '=========================================
        If bandera_correcto = True Then
            If MsgBox("Confirme que desea traspasar productos", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                'Conectar()
                rs.Open("SELECT id_traspaso_recep FROM traspaso_recep WHERE folio_origen= '" & tb_folio_traspaso.Text & "' AND id_sucursal_origen ='" & CType(cb_sucursales.SelectedItem, myItem).Value & "'", conn)
                If rs.RecordCount > 0 Then
                    rs.Close()
                    'conn.close()
                    MsgBox("El folio " & tb_folio_traspaso.Text & " de la sucursal """ & cb_sucursales.Text & """ ya fue ingresado", MsgBoxStyle.Exclamation, "Aviso")
                Else
                    rs.Close()
                    conn.Execute("INSERT INTO traspaso_recep(fecha_registro,fecha,folio_origen,id_empleado_captura,id_empleado_recep,empleado_recep,id_sucursal_origen,sucursal_origen) VALUES" & _
                              " (NOW(), '" & Format(dtp_recepcion.Value, "yyyy-MM-dd") & "', '" & tb_folio_traspaso.Text & "', '" & global_id_empleado & "', '" & CType(cb_nombreReceptor.SelectedItem, myItem).Value & "', '" & cb_nombreReceptor.Text & "', '" & CType(cb_sucursales.SelectedItem, myItem).Value & "', '" & cb_sucursales.Text & "')", , -1)

                    Dim id_traspaso_recep As Integer = 0

                    rs.Open("SELECT last_insert_id() id_traspaso_recep", conn)
                    id_traspaso_recep = rs.Fields("id_traspaso_recep").Value
                    rs.Close()
                    For row = 0 To tabla.Rows.Count - 1
                        Dim id_almacen = obtener_idalmacen(dg_cotizacion.Item("id_producto", row).Value)

                        conn.Execute("INSERT INTO traspaso_recep_detalle(id_traspaso_recep,id_producto,cantidad,unidad,descripcion) VALUES " & _
                                     " (" & id_traspaso_recep & ",'" & dg_cotizacion.Item("id_producto", row).Value & "','" & dg_cotizacion.Item("cantidad", row).Value & "','" & dg_cotizacion.Item("unidad", row).Value & "','" & dg_cotizacion.Item("descripcion", row).Value & "')", , -1)
                        conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & dg_cotizacion.Item("cantidad", row).Value & ") WHERE id_producto=" & dg_cotizacion.Item("id_producto", row).Value & " AND id_almacen=" & id_almacen & "")
                    Next

                    'conn.close()
                    'conn = Nothing
                    cargar(id_traspaso_recep)
                    MsgBox("El traspaso ha sido registrado y se ha actualizado los almacenes")
                End If
            End If
        Else
            MsgBox(cadena)
        End If
    End Sub

    Private Sub cb_nombreReceptor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_nombreReceptor.KeyDown
        cb_nombreReceptor.DroppedDown = False
    End Sub

    Private Sub cb_sucursales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cb_sucursales.KeyDown
        cb_sucursales.DroppedDown = False
    End Sub
    Private Function recomendar_folio(ByVal id_sucursal_origen As Integer) As String
        Dim rw As New ADODB.Recordset
        Dim folio_recomendado As String = ""
        rw.Open("SELECT CASE WHEN ISNULL(MAX(folio_origen)+1) THEN 1 ELSE MAX(folio_origen)+1 END AS folio_recomendado FROM traspaso_recep WHERE id_sucursal_origen='" & id_sucursal_origen & "'", conn)
        If rw.RecordCount > 0 Then
            folio_recomendado = rw.Fields("folio_recomendado").Value
        End If
        rw.Close()
        Return folio_recomendado
    End Function

    Private Sub cb_sucursales_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_sucursales.SelectedIndexChanged
        If cargado = True Then
            If cb_sucursales.SelectedIndex <> -1 Then
                tb_folio_traspaso.Text = recomendar_folio(CType(cb_sucursales.SelectedItem, myItem).Value)
            End If
        End If
    End Sub
End Class