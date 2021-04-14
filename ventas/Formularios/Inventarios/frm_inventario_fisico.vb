Imports System.Math
Public Class frm_inventario_fisico
    Private id_inventario As Integer = 0
    Private cargado As Boolean = False
    Private inventario_fisico As Decimal = 0
    Private inventario_teorico As Decimal = 0
    Private diferencia As Decimal = 0
    Private costo_inventario_fisico As Decimal
    Private costo_inventario_teorico As Decimal
    Private costo_inventario_diferencia As Decimal
    Private id_almacen_tipo As Integer

    ' variables de navegación
    Dim reg_por_pag As Integer = 20
    Dim inicial As Integer = 0
    Dim total_productos As Integer = 0
    Dim total_paginas As Integer = 0


#Region "DATAGRIDVIEW"
    '==============VARIABLES PARA DATAGRIDVIEW===============
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Private tabla_inventario As DataTable
    Private tabla_columna As DataGridTextBoxColumn

    Public Sub estilo_inventario(ByVal inventario As DataGridView)
        tabla_inventario = New DataTable("inventario")

        With tabla_inventario.Columns

            .Add(New DataColumn("id_inventario_detalle", GetType(Integer)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("unidad", GetType(String)))
            .Add(New DataColumn("costo_unitario", GetType(Decimal)))
            .Add(New DataColumn("cantidad_teorica", GetType(Decimal)))
            .Add(New DataColumn("cantidad_fisica", GetType(Decimal)))
            .Add(New DataColumn("cantidad_diferencia", GetType(Decimal)))
            .Add(New DataColumn("diferencia_importe", GetType(Decimal)))
            .Add(New DataColumn("minimo", GetType(Decimal)))
            .Add(New DataColumn("maximo", GetType(Decimal)))


        End With

        ds = New DataSet
        ds.Tables.Add(tabla_inventario)

        With inventario
            .DataSource = ds
            .DataMember = "inventario"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .RowTemplate.MinimumHeight = 30

            With .Columns("id_inventario_detalle")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With

            With .Columns("id_producto")
                .HeaderText = ""
                .Width = 0
                .ReadOnly = True
                .Visible = False
            End With

            With .Columns("codigo")
                .HeaderText = "Codigo"
                .Width = 100
                .ReadOnly = True
                .Visible = True
            End With

            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 220
                .ReadOnly = True
                .Visible = True
            End With


            With .Columns("unidad")
                .HeaderText = "Unidad"
                .Width = 60
                .ReadOnly = True
                .Visible = True
            End With

            With .Columns("costo_unitario")
                .HeaderText = "Costo"
                .Width = 60
                .ReadOnly = True
                .Visible = True
                .DefaultCellStyle.Format = "c"
            End With

            With .Columns("cantidad_teorica")
                .HeaderText = "Cantidad Teorica"
                .Width = 80
                .ReadOnly = True
                .Visible = True
            End With


            With .Columns("cantidad_fisica")
                .HeaderText = "Cantidad fisica"
                .Width = 80
                .ReadOnly = False
                .Visible = True
            End With

            With .Columns("cantidad_diferencia")
                .HeaderText = "Diferencia Cantidad"
                .Width = 60
                .ReadOnly = True
                .Visible = True
            End With

            With .Columns("diferencia_importe")
                .HeaderText = "Diferencia Importe"
                .Width = 60
                .ReadOnly = True
                .Visible = True
                .DefaultCellStyle.Format = "c"
            End With


            With .Columns("minimo")
                .HeaderText = "Minimo"
                .Width = 60
                .ReadOnly = True
                .Visible = True
            End With

            With .Columns("maximo")
                .HeaderText = "Maximo"
                .Width = 60
                .ReadOnly = True
                .Visible = True
            End With
        End With
    End Sub
    Public Sub agregar_tabla_inventario(ByVal id_inventario_detalle As String, ByVal codigo As String, nombre As String, ByVal id_producto As Integer, unidad As String, costo_unitario As Decimal, cantidad_teorica As Decimal, cantidad_fisica As Decimal, cantidad_diferencia As Decimal, diferencia_importe As Decimal, minimo As Decimal, maximo As Decimal)
        tabla_linea = tabla_inventario.NewRow()
        tabla_linea("id_inventario_detalle") = id_inventario_detalle
        tabla_linea("id_producto") = id_producto
        tabla_linea("codigo") = codigo
        tabla_linea("nombre") = nombre
        tabla_linea("unidad") = unidad
        tabla_linea("costo_unitario") = costo_unitario
        tabla_linea("cantidad_teorica") = cantidad_teorica
        tabla_linea("cantidad_fisica") = cantidad_fisica
        tabla_linea("cantidad_diferencia") = cantidad_diferencia
        tabla_linea("diferencia_importe") = diferencia_importe
        tabla_linea("minimo") = minimo
        tabla_linea("maximo") = maximo
        tabla_inventario.Rows.Add(tabla_linea)
    End Sub
#End Region
    Private Sub frm_inventario_fisico_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_inventario_fisico = 0
    End Sub

    Public Sub cargar()
        Try
            cargado = False
            estilo_inventario(dgv_inventario)
            configuracion_inicio()
            rellenar_catalogo_combobox("id_almacen", "nombre", "almacenes", cb_almacen)
            rellenar_catalogo_combobox("id_almacen", "nombre", "almacenes", cb_almacen_busqueda, True)
            cargar_opciones_busqueda()
            cargar_empleados()
            configuracion_listas()
            buscar_inventarios(CType(cb_opciones_busqueda.SelectedItem, myItem).Value)
            cargado = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try
    End Sub
    Public Sub cargar_elemento(id As Integer, nombre_elemento As String)

        'dgv_inventario.Rows(5).Selected = True
        'dgv_inventario.CurrentCell = dgv_inventario.Rows(5).Cells(7)

        Dim BindingSource As Windows.Forms.BindingSource = New BindingSource

        BindingSource.DataSource = tabla_inventario

        Dim fila As Integer = BindingSource.Find("id_producto", id)

        If fila = -1 Then
            MsgBox("El producto no se encuentra en esta lista", MsgBoxStyle.Exclamation, " Aviso")
        Else
            dgv_inventario.Rows(fila).Cells(7).Selected = True
            dgv_inventario.BeginEdit(True)
        End If


        'Dim ea  As EventArgs= New EventArgs())


    End Sub

    Private Sub cargar_empleados()
        cb_empleado.Items.Clear()
        'Conectar()
        rs.Open("SELECT E.id_empleado, CONCAT(P.nombre,' ', P.ap_paterno,' ',P.ap_materno) As nombre FROM empleado E,persona P WHERE P.id_persona=E.id_persona", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_empleado.Items.Add(New myItem(rs.Fields("id_empleado").Value, rs.Fields("nombre").Value, 0, 0))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub cargar_opciones_busqueda()
        cb_opciones_busqueda.Items.Clear()
        cb_opciones_busqueda.Text = ""
        cb_opciones_busqueda.Items.Add(New myItem(1, "TODOS", 0, 0))
        cb_opciones_busqueda.Items.Add(New myItem(2, "POR FECHA", 0, 0))
        cb_opciones_busqueda.Items.Add(New myItem(3, "POR PERIODO", 0, 0))
        cb_opciones_busqueda.SelectedIndex = 1
        dtp_fecha_busqueda.Value = Today
    End Sub
    Private Sub frm_inventario_fisico_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        global_frm_inventario_fisico = 1
        cargar()
    End Sub
    Private Sub actualizar_costos_inventarios()
        costo_inventario_fisico = 0
        costo_inventario_teorico = 0
        costo_inventario_diferencia = 0

        For row = 0 To tabla_inventario.Rows.Count - 1
            costo_inventario_fisico += (dgv_inventario.Rows(row).Cells("cantidad_fisica").Value * dgv_inventario.Rows(row).Cells("costo_unitario").Value)
            costo_inventario_teorico += (dgv_inventario.Rows(row).Cells("cantidad_teorica").Value * dgv_inventario.Rows(row).Cells("costo_unitario").Value)
        Next
        costo_inventario_diferencia = costo_inventario_teorico - costo_inventario_fisico

        tb_inventario_fisico.Text = FormatCurrency(costo_inventario_fisico)
        tb_inventario_teorico.Text = FormatCurrency(costo_inventario_teorico)
        tb_diferencia.Text = FormatCurrency(costo_inventario_diferencia)
    End Sub

    Private Sub rellenar_catalogo_combobox(id As String, valor As String, tabla_db As String, combobox As ComboBox, Optional opcion_general As Boolean = False)
        Dim recordset As New ADODB.Recordset
        combobox.Items.Clear()
        If opcion_general = True Then
            combobox.Items.Add(New myItem("0", "Todos"))
        End If

        recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & "", conn)
        If recordset.RecordCount > 0 Then
            While Not recordset.EOF
                combobox.Items.Add(New myItem(recordset.Fields(id).Value, recordset.Fields(valor).Value))
                recordset.MoveNext()
            End While
        End If
        recordset.Close()

        If combobox.Items.Count > 0 Then
            combobox.SelectedIndex = 0
        End If

    End Sub

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = False
        btn_imprimir.Enabled = False

        tb_folio.Text = "0000"
        tb_inventario_teorico.Text = "$0.00"
        tb_inventario_fisico.Text = "$0.00"
        tb_diferencia.Text = "$0.00"

    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = True
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True
        btn_imprimir.Enabled = False

        tb_folio.Text = "0000"
        tb_inventario_teorico.Text = "$0.00"
        tb_inventario_fisico.Text = "$0.00"
        tb_diferencia.Text = "$0.00"
        dtp_fecha_inventario.Value = Today
        dtp_hora_inventario.Value = Now

    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = True
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True
        btn_imprimir.Enabled = False
    End Sub
    Private Sub configuracion_listas()
        With lst_inventarios
            ' .CheckBoxes = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Folio", 50)
            .Columns.Add("Fecha", 90)
            .Columns.Add("Almacen", 110)
            .Columns.Add("Estado", 20)
        End With

        For i = 0 To lst_inventarios.Items.Count - 2 Step 2
            lst_inventarios.Items(i + 1).BackColor = Color.Turquoise
            lst_inventarios.Items(i).BackColor = Color.White
        Next

    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        cargar_inventario(0)
    End Sub


    Private Sub guardar_inventario(id_inventario As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If cb_almacen.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un almacen " & vbCrLf
        End If
        If cb_empleado.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione quien elaboró " & vbCrLf
        End If

        If correcto = True Then

            Dim id_almacen As Integer = 0
            Dim id_empleado As Integer = 0
            Dim fecha_hora As String = ""


            id_almacen = CType(cb_almacen.SelectedItem, myItem).Value
            id_empleado = CType(cb_empleado.SelectedItem, myItem).Value
            fecha_hora = Format(dtp_fecha_inventario.Value, "yyyy-MM-dd") & " " & Format(dtp_hora_inventario.Value, "HH:mm:ss")


            If id_inventario > 0 Then
                conn.Execute("UPDATE inventario_fisico SET fecha_hora='" & fecha_hora & "',id_almacen='" & id_almacen & "',id_empleado='" & id_empleado & "',inventario_teorico='" & inventario_teorico & "',inventario_fisico='" & inventario_fisico & "',diferencia='" & diferencia & "' WHERE id_inventario_fisico='" & id_inventario & "'")

            Else
                conn.Execute("INSERT INTO inventario_fisico(fecha_hora,id_almacen,id_empleado,inventario_teorico,inventario_fisico,diferencia,estado)VALUES('" & fecha_hora & "','" & id_almacen & "','" & id_empleado & "','" & inventario_teorico & "','" & inventario_fisico & "','" & diferencia & "','ACTIVO')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_inventario = rs.Fields(0).Value
                rs.Close()
            End If
            buscar_inventarios(CType(cb_opciones_busqueda.SelectedItem, myItem).Value)
            cargar_inventario(id_inventario)
        Else
            MsgBox(mensaje, MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        guardar_inventario(id_inventario)
    End Sub

    Private Sub btn_deshacer_Click(sender As System.Object, e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
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
    Private Sub buscar_inventarios(tipo_busqueda As Integer)
        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_inventarios.Items.Clear()

        If tipo_busqueda = 1 Then ' TODOS LOS REGISTROS
            filtro = ""
        ElseIf tipo_busqueda = 2 Then ' POR FECHA
            filtro = " WHERE DATE(i.fecha_hora)='" & Format(dtp_fecha_busqueda.Value, "yyyy-MM-dd") & "'"
        ElseIf tipo_busqueda = 3 Then ' POR PERIODO

            filtro = "WHERE DATE(i.fecha_hora) BETWEEN '" & Format(dtp_fecha_inicio.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp_fecha_termino.Value, "yyyy-MM-dd") & "'"
        End If

        rs.Open("SELECT i.id_inventario_fisico,i.fecha_hora,a.nombre AS almacen,i.estado " &
                 "FROM inventario_fisico i " &
                 "JOIN almacenes a ON a.id_almacen=i.id_almacen " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("id_inventario_fisico").Value
                str(1) = Format(rs.Fields("fecha_hora").Value, "dd/MM/yyyy")
                str(2) = rs.Fields("almacen").Value
                str(3) = rs.Fields("estado").Value

                lst_inventarios.Items.Add(New ListViewItem(str, 0))
                lst_inventarios.Items(i).Tag = rs.Fields("id_inventario_fisico").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_insumo()

    End Sub
    Private Sub aplicar_estilo_insumo()
        For i = 0 To lst_inventarios.Items.Count - 2 Step 2
            lst_inventarios.Items(i + 1).BackColor = Color.Turquoise
            lst_inventarios.Items(i).BackColor = Color.White
        Next
    End Sub
    Private Sub cargar_inventario(id As Integer)
        cargado = False
        id_inventario = id
        Dim fecha As DateTime

        If id_inventario > 0 Then
            '=======================CARGAMOS INVENTARIO===========================
            rs.Open("SELECT fecha_hora,id_almacen,id_empleado,inventario_teorico,inventario_fisico, diferencia, estado FROM inventario_fisico WHERE id_inventario_fisico='" & id_inventario & "'", conn)
            If rs.RecordCount > 0 Then
                tb_folio.Text = Format(id_inventario, "0000")
                fecha = rs.Fields("fecha_hora").Value
                dtp_fecha_inventario.Value = fecha
                dtp_hora_inventario.Value = fecha
                seleccionar_catalogo(rs.Fields("id_almacen").Value, cb_almacen)
                seleccionar_catalogo(rs.Fields("id_empleado").Value, cb_empleado)
            End If
            rs.Close()

            cargar_productos_inventario(id_inventario, tb_buscar.Text)

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
        Else
            '=============================NUEVO INVENTARIO===================================
            configuracion_nuevo()
            frm_nuevo_inventario_fisico.ShowDialog()
        End If
        cargado = True
    End Sub
    Private Sub cargar_productos_inventario(ByVal id_inventario_fisico As Integer, ByVal buscar As String, Optional ByVal pagina As Integer = 1)
        tabla_inventario.Clear()
        tb_pagina.Text = pagina
        inicial = (pagina - 1) * reg_por_pag

        Dim filtro As String = ""

        If buscar.Length > 0 Then
            filtro = "AND p.nombre LIKE '%" & buscar & "%'"
        End If

        rs.Open("SELECT  COUNT(*) AS total_productos FROM inventario_fisico_detalle ifd " &
                 "JOIN producto p ON p.id_producto=ifd.id_producto " &
                  "WHERE ifd.id_inventario_fisico='" & id_inventario_fisico & "'" & filtro, conn)
        total_productos = rs.Fields("total_productos").Value
        rs.Close()

        total_paginas = Ceiling(total_productos / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas

        '=======CARGAMOS LOS PRODUCTOS DEL INVENTARIO========="
        rs.Open("SELECT ifd.id_inventario_fisico_detalle,ifd.id_producto,p.codigo, p.nombre as producto,u.nombre as unidad, ifd.cantidad_teorica,ifd.cantidad_fisica,ifd.costo_unitario,ifd.diferencia_importe " &
            "FROM inventario_fisico_detalle ifd " &
            "JOIN producto p on p.id_producto=ifd.id_producto " &
            "JOIN unidad u on u.id_unidad=p.id_unidad " &
            "WHERE ifd.id_inventario_fisico=" & id_inventario_fisico & "'" & filtro & " LIMIT " & inicial & "," & reg_por_pag, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_tabla_inventario(rs.Fields("id_inventario_fisico_detalle").Value, rs.Fields("codigo").Value, rs.Fields("producto").Value, rs.Fields("id_producto").Value, rs.Fields("unidad").Value, rs.Fields("costo_unitario").Value, rs.Fields("cantidad_teorica").Value, rs.Fields("cantidad_fisica").Value, rs.Fields("cantidad_teorica").Value - rs.Fields("cantidad_fisica").Value, rs.Fields("diferencia_importe").Value, 0, 0)
                rs.MoveNext()
            End While
        End If

        tb_resultados.Text = total_productos & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()
    End Sub
    Private Sub lst_insumos_DoubleClick(sender As Object, e As System.EventArgs) Handles lst_inventarios.DoubleClick
        If lst_inventarios.SelectedItems.Count > 0 Then
            cargar_inventario(lst_inventarios.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_inventario(id_inventario)
    End Sub
    Private Sub eliminar_inventario(id As Integer)
        Try
            If MsgBox("Desea cancelar este inventario?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM inventario_fisico WHERE id_inventario_fisico='" & id & "'")
                buscar_inventarios(CType(cb_opciones_busqueda.SelectedItem, myItem).Value)
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try

    End Sub
    Private Sub btn_editar_Click(sender As System.Object, e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub

    Private Sub cb_almacen_busqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_almacen_busqueda.SelectedIndexChanged
        If cargado = True Then
            buscar_inventarios(CType(cb_opciones_busqueda.SelectedItem, myItem).Value)
        End If

    End Sub

    Private Sub cb_opciones_busqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_opciones_busqueda.SelectedIndexChanged
        If cargado = True Then
            buscar_inventarios(CType(cb_opciones_busqueda.SelectedItem, myItem).Value)
        End If

    End Sub
    Public Sub agregar_categoria_inventario(id_categoria As Integer, id_almacen As Integer, id_inventario_fisico As Integer)

        rs.Open("SELECT id_almacen_tipo FROM almacenes WHERE id_almacen='" & id_almacen & "'")
        If rs.RecordCount > 0 Then
            id_almacen_tipo = rs.Fields("id_almacen_tipo").Value
        End If
        rs.Close()


        If id_almacen_tipo = 1 Then ' inventarios de productos

            'agregamos los productos de la categoria
            'rs.Open("SELECT ps.id_producto,p.codigo,p.nombre,u.nombre AS unidad,p.costo,ps.cantidad,ps.cantidad_minima,ps.cantidad_maxima " &
            '       "FROM producto_sucursal ps " &
            '      "JOIN producto p ON p.id_producto=ps.id_producto " &
            '     "JOIN unidad u ON u.id_unidad=p.id_unidad " &
            '    "WHERE ps.id_almacen='" & id_almacen & "' AND p.id_categoria='" & id_categoria & "'")


            rs.Open("SELECT ps.id_producto,p.costo,ps.cantidad " &
                    "FROM producto_sucursal ps " &
                    "JOIN producto p ON p.id_producto=ps.id_producto " &
                    "WHERE ps.id_almacen='" & id_almacen & "' AND p.id_categoria='" & id_categoria & "'")
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    conn.Execute("INSERT INTO inventario_fisico_detalle (id_inventario_fisico,id_producto,cantidad_teorica,costo_unitario) VALUES(" & id_inventario_fisico & "," & rs.Fields("id_producto").Value & "," & rs.Fields("cantidad").Value & ", " & rs.Fields("costo").Value & ")")
                    'agregar_tabla_inventario(0, rs.Fields("codigo").Value, rs.Fields("nombre").Value, rs.Fields("id_producto").Value, rs.Fields("unidad").Value, rs.Fields("costo").Value, rs.Fields("cantidad").Value, 0, rs.Fields("cantidad").Value, rs.Fields("cantidad").Value * rs.Fields("costo").Value, rs.Fields("cantidad_minima").Value, rs.Fields("cantidad_maxima").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            ' actualizar_costos_inventarios()
        Else
            ' agregamos los insumos de la categoria
        End If
    End Sub

    Private Sub dgv_inventario_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_inventario.CellContentClick

    End Sub

    Private Sub dgv_inventario_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_inventario.CellFormatting
        e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        For x = 0 To dgv_inventario.Columns.Count - 1
            If dgv_inventario.Columns(e.ColumnIndex).Index = x Then
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next

        Try
            If dgv_inventario.Columns(e.ColumnIndex).Index = 6 Then
                Dim cant_min As Decimal = dgv_inventario.Rows(e.RowIndex).Cells("minimo").Value
                e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                If e.Value <= cant_min Then
                    e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                    e.CellStyle.BackColor = Color.DarkRed
                    e.CellStyle.ForeColor = Color.White
                End If
            End If

            If dgv_inventario.Columns(e.ColumnIndex).Index = 8 Then
                e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                If e.Value < 0 Then
                    e.CellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
                    e.CellStyle.BackColor = Color.DarkRed
                    e.CellStyle.ForeColor = Color.White
                ElseIf e.Value > 0 Then
                    e.CellStyle.BackColor = Color.DarkGreen
                    e.CellStyle.ForeColor = Color.White
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub
    Private Sub calcular_diferencia(ByVal id As Decimal)
        Dim foundRows() As Data.DataRow = tabla_inventario.Select("id_producto = " & id)
        Dim descuento As Decimal = 0
        If foundRows.Length > 0 Then
            foundRows(0).Item("cantidad_diferencia") = CDec(foundRows(0).Item("cantidad_fisica")) - CDec(foundRows(0).Item("cantidad_teorica"))
            foundRows(0).Item("diferencia_importe") = (CDec(foundRows(0).Item("cantidad_diferencia")) * CDec(foundRows(0).Item("costo_unitario")))
            actualizar_costos_inventarios()
        End If
    End Sub

    Private Sub dgv_inventario_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_inventario.CellValueChanged
        If dgv_inventario.Rows.Count > 0 Then
            calcular_diferencia(dgv_inventario.Rows(dgv_inventario.CurrentRow.Index).Cells("id_producto").Value)
        End If
    End Sub

    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs) Handles btn_buscar.Click
        frm_resultado_busqueda_inventario.id_almacen_tipo = Me.id_almacen_tipo
        frm_resultado_busqueda_inventario.Show()
    End Sub

    Private Sub pb_anterior_Click(sender As Object, e As EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar_productos_inventario(id_inventario, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_siguiente_Click(sender As Object, e As EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar_productos_inventario(id_inventario, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub tb_pagina_TextChanged(sender As Object, e As EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar_productos_inventario(id_inventario, tb_buscar.Text, tb_pagina.Text)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_productos_inventario(id_inventario, tb_buscar.Text)
    End Sub
End Class