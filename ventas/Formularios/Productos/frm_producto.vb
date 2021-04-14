Public Class frm_producto
    Private tabla As DataTable
    Private tablaAgrupacion As DataTable
    Private tablaPrecio As DataTable
    Private Linea As DataRow
    Private actualiza As Boolean = False
    Private celdaSeleccionadaIntervalos As Integer = -1
    Private insertar As Boolean = False
    Private copia_costo As String = 0
    Private copia_precio As String = 0
    Private copia_descuento As String = 0
    Private copia_especial As String = 0
    Private id As Integer = 0
    Private bandera_intervalos As Boolean
    Private bandera_ivas As Boolean
    Private bandera_paquete As Boolean
    '--banderas para la subidad de imagen
    Private bandera_Insertada As Boolean
    Private bandera As Boolean
    Private bDatos() As Byte
    '--------------------------------------
    Private image_producto As System.Drawing.Image
    'Private conn As ADODB.Connection
    'Private rs As ADODB.Recordset

    Private Sub frm_producto_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        'habilitar_menu_ventana()
        global_frm_producto = 0
        ''conn.close()
    End Sub
    Private Sub frm_producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conn = conexion()
        'rs = conector()
        'Me.MdiParent = frm_principal
        'habilitar_menu_ventana()
        global_frm_producto = 1
        cargar()
    End Sub
    Private Sub cargar_almacenes()
        cb_almacenes.Items.Clear()
        Dim id_almacen_default As Integer = 0
        'Conectar()
        rs.Open("SELECT ID_Almacen,Nombre,default_ventas FROM almacenes Order By Nombre", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                If rs.Fields("default_ventas").Value = 1 Then
                    id_almacen_default = rs.Fields("ID_Almacen").Value
                End If
                cb_almacenes.Items.Add(New myItem(rs.Fields("ID_Almacen").Value, rs.Fields("Nombre").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
        seleccionar_almacen(id_almacen_default)
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub seleccionar_almacen(ByVal id_almacen As Integer)
        For x = 0 To cb_almacenes.Items.Count - 1
            If id_almacen = CType(cb_almacenes.Items(x), myItem).Value Then
                cb_almacenes.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub

    Private Sub cargar_categorias()
        cb_categoria.Items.Clear()
        cb_categoria.Text = ""
        rs.Open("SELECT id_categoria,nombre FROM categoria Order By id_categoria", conn)
        While Not rs.EOF
            If rs.RecordCount > 0 Then
                cb_categoria.Items.Add(New myItem(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End If
        End While
        rs.Close()
    End Sub
    Private Sub seleccionar_categoria(ByVal id_categoria As Integer)
        For x = 0 To cb_categoria.Items.Count - 1
            If id_categoria = CType(cb_categoria.Items(x), myItem).Value Then
                cb_categoria.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Public Sub cargar(Optional ByVal id As Integer = 0)
        'Dim consulta As ADODB.Recordset
        'Dim consulta1 As ADODB.Recordset
        Dim contador As Integer
        Me.id = id
        'consulta = conector()
        'consulta1 = conector()
        If id = 0 Then

            btn_eliminar.Enabled = False
            btn_aceptar.Text = "Agregar"
            btn_buscar.Visible = True
            cb_kid.Enabled = True
            btn_actualizar.Visible = False
            inicial.Value = Date.Today.AddDays(-1)
            final.Value = Date.Today.AddDays(-1)
            tb_Precio.Text = ""
            tb_descuento.Text = ""
            tb_nombre.Text = ""
            tb_max.Maximum = 10000000
            tb_max.Minimum = 0
            tb_max.Value = 0
            ' tb_porcentaje.Maximum = 100
            'tb_porcentaje.Minimum = 0
            tb_porcentaje.Value = 0
            tb_codigoProducto.Text = ""
            tb_numArticulos.Text = ""
            tb_modelo.Text = ""
            tb_producto.Text = ""
            tb_codigo.Text = "0"
            tb_medida.Text = "1"
            tb_costo.Text = "0.00"
            tb_descripcion.Text = ""
            cb_kid.Checked = False
            tb_especial.Text = "0.00"
            tb_merma.Text = "0.00"
            tb_cantidad_maxima.Text = "10"
            tb_cantidad_minima.Text = "1"
            chb_merma.Checked = False
            chb_invalidar_intervalos.Checked = True
            cb_unidad.Items.Clear()
            CheckBoxVenta_Peso.Checked = False
            chb_invalidar_intervalos.Checked = True
            cargar_almacenes()
            cargar_categorias()

            'Conectar()
            '---obtenemos la imagen---------------

            rs.Open("SELECT imagen FROM configuracion", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                bDatos = CType(rs.Fields("imagen").Value, Byte())
                pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
            End If
            ofd_foto.Title = "Seleccionar imágen"
            ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"
            rs.Close()
            '--------------------------------------------
            rs.Open("SELECT id_unidad, nombre FROM unidad ORDER BY nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                cb_unidad.Items.Add(rs.Fields("nombre").Value)
                rs.MoveNext()
            End While
            If cb_unidad.Items.Count <> 0 Then
                cb_unidad.Text = cb_unidad.Items.Item(0)
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            intervalo("Intervalos", dg_intervalos, tabla)
            precio("Precios", dg_precio, tablaPrecio)
            producto_Agrupado("Producto", dg_agrupacion, tablaAgrupacion)

            estilo_prdcts_modificadores(dgv_productos_modificadores)
            estilo_modificadores(dgv_modificadores)
            'Linea = tabla.NewRow()
            ' Linea(0) = "Default".ToUpper
            'Linea(1) = "1"
            'Linea(2) = "Maximo"
            'Linea(3) = "0"
            'tabla.Rows.Add(Linea)
            'Conectar()
            '--obtenemos los precios del catalogo de precios
            rs.Open("SELECT id_catalogo_precio,nombre,cantidad_inicio, cantidad_termino,utilidad FROM catalogo_precios  WHERE utilidad<>0 ORDER by id_catalogo_precio", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                Linea = tabla.NewRow()
                Linea(0) = rs.Fields("nombre").Value
                Linea(1) = rs.Fields("cantidad_inicio").Value
                If rs.Fields("cantidad_termino").Value = 10000000 Then
                    Linea(2) = "Maximo"
                Else
                    Linea(2) = rs.Fields("cantidad_termino").Value
                End If
                Linea(3) = rs.Fields("utilidad").Value
                Linea(5) = rs.Fields("utilidad").Value
                Linea(6) = rs.Fields("id_catalogo_precio").Value
                tabla.Rows.Add(Linea)
                rs.MoveNext()
            End While
            rs.Close()
            '--------------------------------------------------
            '--al ultimo precio le asignamos maximo
            ' If tabla.Rows.Count > 0 Then
            ' dg_intervalos.Item(tabla.Rows.Count - 1, 2) = "Maximo"
            ' End If
            '---------------------------------------
            clb_iva.Items.Clear()
            rs.Open("SELECT id_catalogo, nombre FROM impuesto_catalogo WHERE fecha_baja is NULL ORDER BY nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                clb_iva.Items.Add(New myItem(rs.Fields("id_catalogo").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
            rs.Close()
            lb_productos.Items.Clear()
            rs.Open("SELECT id_producto, nombre FROM producto ORDER BY nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                lb_productos.Items.Add(New myItem(rs.Fields("id_producto").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
            rs.Close()
            cb_marca.Items.Clear()
            rs.Open("SELECT id_marca, nombre FROM producto_marca ORDER BY nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                cb_marca.Items.Add(New myItem(rs.Fields("id_marca").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
            rs.Close()
            cb_marca.Text = ""


            cb_talla.Items.Clear()
            rs.Open("SELECT id_producto_talla, talla FROM producto_talla ORDER BY talla", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                cb_talla.Items.Add(New myItem(rs.Fields("id_producto_talla").Value, rs.Fields("talla").Value))
                rs.MoveNext()
            End While
            rs.Close()
            cb_talla.Text = ""


            cb_color.Items.Clear()
            rs.Open("SELECT id_producto_color, color FROM producto_color ORDER BY color", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            While Not rs.EOF
                cb_color.Items.Add(New myItem(rs.Fields("id_producto_color").Value, rs.Fields("color").Value))
                rs.MoveNext()
            End While
            rs.Close()
            cb_color.Text = ""
            'conn.close()
            'conn = Nothing
            mostrar_codigo(1)
        Else
            btn_eliminar.Enabled = True
            btn_aceptar.Text = "Guardar"
            btn_buscar.Visible = False
            cb_kid.Enabled = False
            btn_actualizar.Visible = True
            'Conectar()
            rs.Open("SELECT nombre, codigo, medida, id_unidad,venta_peso, descripcion, costo,peso,id_marca,modelo,imagen,invalidar_intervalos,id_categoria,id_producto_talla,id_producto_color FROM producto WHERE id_producto=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                tb_producto.Text = rs.Fields("nombre").Value
                tb_codigo.Text = rs.Fields("codigo").Value
                tb_medida.Text = rs.Fields("medida").Value
                CheckBoxVenta_Peso.CheckState = rs.Fields("venta_peso").Value
                chb_invalidar_intervalos.CheckState = rs.Fields("invalidar_intervalos").Value
                seleccionar_categoria(rs.Fields("id_categoria").Value)
                seleccionar_catalogo(rs.Fields("id_producto_talla").Value, cb_talla)
                seleccionar_catalogo(rs.Fields("id_producto_color").Value, cb_color)
                Dim rs2 As New ADODB.Recordset
                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bDatos = CType(rs.Fields("imagen").Value, Byte())
                    pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
                Else
                    '---obtenemos la imagen---------------

                    rs2.Open("SELECT imagen FROM configuracion", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    If Not rs2.EOF Then
                        bDatos = CType(rs2.Fields("imagen").Value, Byte())
                        pb_foto.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
                    End If
                    ofd_foto.Title = "Seleccionar imágen"
                    ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"
                    rs2.Close()
                    '--------------------------------------------
                End If

                rs2.Open("SELECT nombre FROM unidad WHERE id_unidad=" & rs.Fields("id_unidad").Value, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If Not rs2.EOF Then
                    cb_unidad.Text = rs2.Fields("nombre").Value
                Else
                    cb_unidad.Text = "NO ASIGNADO"
                End If
                rs2.Close()
                rs2.Open("SELECT nombre FROM producto_marca WHERE id_marca=" & rs.Fields("id_marca").Value, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If Not rs2.EOF Then
                    cb_marca.Text = rs2.Fields("nombre").Value
                Else
                    cb_marca.Text = "NO ASIGNADO"
                End If
                rs2.Close()
                tb_modelo.Text = rs.Fields("modelo").Value
                tb_costo.Text = rs.Fields("costo").Value
                copia_costo = rs.Fields("costo").Value
                numericUpDown2.Value = rs.Fields("peso").Value
                tb_descripcion.Text = rs.Fields("descripcion").Value
                rs2.Open("SELECT id_producto FROM producto_paquete WHERE id_producto=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs2.RecordCount > 0 Then
                    cb_kid.Checked = True
                Else
                    cb_kid.Checked = False
                End If
                rs2.Close()
                rs2.Open("SELECT ps.precio_especial,ps.precio_especial_inicio,ps.precio_especial_termino,a.nombre,ps.cantidad_minima,ps.cantidad_maxima,ps.merma " & _
                "FROM producto_sucursal ps " & _
                "JOIN almacenes a ON a.id_almacen=ps.id_almacen " & _
                "WHERE ps.id_producto='" & id & "' AND ps.id_sucursal='" & global_id_sucursal & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs2.RecordCount > 0 Then
                    tb_especial.Text = rs2.Fields("precio_especial").Value
                    inicial.Value = rs2.Fields("precio_especial_inicio").Value
                    final.Value = rs2.Fields("precio_especial_termino").Value
                    cb_almacenes.Text = rs2.Fields("nombre").Value
                    tb_cantidad_minima.Text = rs2.Fields("cantidad_minima").Value
                    tb_cantidad_maxima.Text = rs2.Fields("cantidad_maxima").Value
                    If rs2.Fields("merma").Value > 0 Then
                        chb_merma.Checked = True
                        tb_merma.Text = rs2.Fields("merma").Value
                    Else
                        chb_merma.Checked = False
                        tb_merma.Text = "0.00"
                    End If
                End If
                rs2.Close()
                For contador = 0 To tablaPrecio.Rows.Count - 1
                    rs2.Open("SELECT precio, ganacia FROM producto_precio WHERE id_producto=" & id & " AND id_nombre_precio=" & dg_precio.Item(contador, 0) & " AND  fecha_baja IS NULL", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    If Not rs2.EOF Then
                        dg_precio.Item(contador, 2) = rs2.Fields("precio").Value
                        dg_precio.Item(contador, 3) = rs2.Fields("ganacia").Value
                    End If
                    rs2.Close()
                Next
                intervalo("Intervalos", dg_intervalos, tabla)
                rs2.Open("SELECT catalogo_precios.nombre, catalogo_precios.id_catalogo_precio,catalogo_precios.utilidad AS utilidad_catalogo,producto_volumen.utilidad,producto_volumen.descuento,producto_volumen.rango_inicial,producto_volumen.rango_final,(producto_precio.precio-(producto.costo*(producto_volumen.descuento/100))) AS precio FROM producto_volumen JOIN catalogo_precios ON catalogo_precios.id_catalogo_precio=producto_volumen.id_catalogo_precio JOIN producto_precio ON producto_precio.id_producto=producto_volumen.id_producto JOIN producto ON producto.id_producto=producto_volumen.id_producto WHERE producto_volumen.utilidad<>0 AND producto_volumen.id_producto=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs2.EOF
                    Linea = tabla.NewRow()
                    Linea(0) = rs2.Fields("nombre").Value
                    Linea(1) = rs2.Fields("rango_inicial").Value
                    If rs2.Fields("rango_final").Value = 10000000 Then
                        Linea(2) = "Maximo"
                    Else
                        Linea(2) = rs2.Fields("rango_final").Value
                    End If
                    Linea(3) = rs2.Fields("utilidad").Value
                    Linea(4) = rs2.Fields("descuento").Value
                    Linea(5) = rs2.Fields("utilidad_catalogo").Value
                    Linea(6) = rs2.Fields("id_catalogo_precio").Value
                    Linea(7) = FormatNumber(rs2.Fields("precio").Value, 2)
                    tabla.Rows.Add(Linea)
                    rs2.MoveNext()
                End While
                rs2.Close()
                clb_iva.Items.Clear()
                rs2.Open("SELECT id_catalogo, nombre FROM impuesto_catalogo WHERE fecha_baja is NULL ORDER BY nombre", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs2.EOF
                    clb_iva.Items.Add(New myItem(rs2.Fields("id_catalogo").Value, rs2.Fields("nombre").Value, 0))
                    Dim rs3 As New ADODB.Recordset
                    rs3.Open("SELECT id_catalogo FROM producto_cat_imp WHERE id_catalogo=" & rs2.Fields("id_catalogo").Value & " AND id_producto=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    If Not rs3.EOF Then
                        clb_iva.SetItemChecked((clb_iva.Items.Count - 1), True)
                    End If
                    rs3.Close()
                    rs2.MoveNext()
                End While
                rs2.Close()
                producto_Agrupado("Producto", dg_agrupacion, tablaAgrupacion)
                rs2.Open("SELECT producto.id_producto, nombre, num_articulo from producto INNER JOIN producto_compuesto WHERE producto.id_producto=producto_compuesto.id_articulo AND producto_compuesto.id_producto=" & id, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                While Not rs2.EOF
                    Linea = tablaAgrupacion.NewRow()
                    Linea(0) = rs2.Fields("id_producto").Value
                    Linea(1) = rs2.Fields("nombre").Value
                    Linea(2) = rs2.Fields("num_articulo").Value
                    tablaAgrupacion.Rows.Add(Linea)
                    rs2.MoveNext()
                End While
                rs2.Close()
            End If
            rs.Close()

            tabla_prdcts_modificadores.Clear()
            tabla_modificadores.Clear()
            '===agregamos_modificadores==============================
            rs.Open("SELECT producto_modificador.id_modificador,modificadores.nombre FROM producto_modificador JOIN modificadores ON modificadores.id_modificador=producto_modificador.id_modificador WHERE producto_modificador.id_producto=" & id)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    _agregar_modificador(rs.Fields("id_modificador").Value, rs.Fields("nombre").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            rs.Open("SELECT paquete_modificador_producto.id_modificador,paquete_modificador_producto.id_producto,paquete_modificador_producto.cantidad,producto.nombre FROM paquete_modificador_producto JOIN producto ON producto.id_producto=paquete_modificador_producto.id_producto WHERE paquete_modificador_producto.id_paquete=" & id)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_producto_modificador(rs.Fields("id_producto").Value, rs.Fields("cantidad").Value, rs.Fields("nombre").Value, rs.Fields("id_modificador").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            '=======================================
            'conn.close()
            'conn = Nothing
            bandera_intervalos = False
            bandera_ivas = False
            bandera_paquete = False
        End If
    End Sub

    Private Sub dg_intervalos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_intervalos.Click
        ' If tabla.Rows.Count <> 0 Then
        'tb_max.Value = dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 1)
        ' tb_porcentaje.Value = dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 3)
        ' End If
    End Sub
    Private Sub dg_intervalos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dg_intervalos.KeyPress
        e.KeyChar = ""
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GroupBox2.Enabled = False
        Panel2.Enabled = False
        Panel4.Enabled = False
        Panel5.Enabled = False
        GroupBox1.Enabled = False
        GroupBox6.Enabled = False
        GroupBox9.Enabled = False
        GroupBox10.Enabled = False
        celdaSeleccionadaIntervalos = -1
        GroupBox3.Enabled = False
        dg_intervalos.Enabled = False
        If 0 < tabla.Rows.Count Then
            If dg_intervalos.Item(tabla.Rows.Count - 1, 2) = "Maximo" Then
                dg_intervalos.Item(tabla.Rows.Count - 1, 2) = 10000000
            End If
            GroupBox3.Enabled = True
            Button3.Enabled = False
            tb_max.Minimum = dg_intervalos.Item(tabla.Rows.Count - 1, 1).ToString + 2
            tb_max.Text = dg_intervalos.Item(tabla.Rows.Count - 1, 1).ToString + 2
            tb_max.Maximum = dg_intervalos.Item(tabla.Rows.Count - 1, 2).ToString - 1
            'tb_porcentaje.Minimum = dg_intervalos.Item(tabla.Rows.Count - 1, 3).ToString + 0.01
            tb_porcentaje.Text = dg_intervalos.Item(tabla.Rows.Count - 1, 3).ToString + 0.01
        End If
        If dg_intervalos.Item(tabla.Rows.Count - 1, 2) = 10000000 Then
            dg_intervalos.Item(tabla.Rows.Count - 1, 2) = "Maximo"
        End If
        tb_nombre.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim contador As Integer
        Dim bandSalto As Boolean = False
        Linea = tabla.NewRow()
        If (tb_nombre.Text <> "") Then
            contador = tabla.Rows.Count
            While 0 < contador
                If dg_intervalos.Item(contador - 1, 0).ToString.ToUpper.Equals(tb_nombre.Text.ToUpper) Then
                    contador = 0
                End If
                contador = contador - 1
            End While
            If contador <> -1 Then
                If -1 = celdaSeleccionadaIntervalos Then
                    ' agregar un nuevo elemento en la ultima posicion
                    Linea(0) = tb_nombre.Text.ToUpper
                    Linea(1) = tb_max.Text
                    dg_intervalos.Item(tabla.Rows.Count - 1, 2) = tb_max.Text - 1
                    Linea(2) = "Maximo"
                    Linea(3) = tb_porcentaje.Text
                    tabla.Rows.Add(Linea)
                    GroupBox3.Enabled = False
                    Button3.Enabled = True
                    tb_porcentaje.Text = ""
                    tb_max.Text = ""
                    tb_nombre.Text = ""
                    dg_intervalos.Enabled = True
                    Panel2.Enabled = True
                    Panel4.Enabled = True
                    Panel5.Enabled = True
                    GroupBox1.Enabled = True
                    GroupBox2.Enabled = True
                    GroupBox6.Enabled = True
                    GroupBox9.Enabled = True
                    GroupBox10.Enabled = True
                    bandera_intervalos = True
                Else
                    Linea(0) = ""
                    Linea(1) = ""
                    Linea(2) = ""
                    Linea(3) = ""
                    tabla.Rows.Add(Linea)
                    contador = tabla.Rows.Count - 1
                    While celdaSeleccionadaIntervalos < contador
                        dg_intervalos.Item(contador, 0) = dg_intervalos.Item(contador - 1, 0)
                        dg_intervalos.Item(contador, 1) = dg_intervalos.Item(contador - 1, 1)
                        dg_intervalos.Item(contador, 2) = dg_intervalos.Item(contador - 1, 2)
                        dg_intervalos.Item(contador, 3) = dg_intervalos.Item(contador - 1, 3)
                        contador = contador - 1
                    End While
                    dg_intervalos.Item(contador, 0) = tb_nombre.Text.ToUpper
                    dg_intervalos.Item(contador, 2) = tb_max.Text
                    dg_intervalos.Item(contador, 3) = tb_porcentaje.Text
                    dg_intervalos.Item(contador + 1, 1) = tb_max.Text + 1
                    Button5.Text = "Aceptar"
                    celdaSeleccionadaIntervalos = -1
                    dg_intervalos.Enabled = True
                    GroupBox3.Enabled = False
                    Button3.Enabled = True
                    tb_porcentaje.Text = ""
                    tb_max.Text = ""
                    tb_nombre.Text = ""
                    Panel2.Enabled = True
                    Panel4.Enabled = True
                    Panel5.Enabled = True
                    GroupBox1.Enabled = True
                    GroupBox2.Enabled = True
                    GroupBox6.Enabled = True
                    GroupBox9.Enabled = True
                    GroupBox10.Enabled = True
                End If
                tb_max.Maximum = 10000000
                'tb_porcentaje.Maximum = 100
            Else
                MsgBox("EL nombre esta duplicado")
            End If
        Else
            MsgBox("Falta rellenar el campo nombre")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim contador As Integer
        bandera_intervalos = True
        contador = tabla.Rows.Count
        While 0 < contador
            If dg_intervalos.IsSelected(contador - 1) = True Then
                dg_intervalos.Item(contador - 1, 0) = ""
            End If
            contador = contador - 1
        End While
        contador = tabla.Rows.Count
        While 0 < contador
            If dg_intervalos.Item(contador - 1, 0) = "" Then
                If contador <> 1 Then
                    tabla.Rows.Item(contador - 1).Delete()
                Else
                    dg_intervalos.Item(contador - 1, 0) = "Default".ToUpper
                End If
            End If
            contador = contador - 1
        End While
        contador = 0
        While contador < tabla.Rows.Count - 1
            dg_intervalos.Item(contador + 1, 1) = dg_intervalos.Item(contador, 2) + 1
            contador = contador + 1
        End While
        dg_intervalos.Item(tabla.Rows.Count - 1, 2) = "Maximo"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        dg_intervalos.Enabled = True
        GroupBox3.Enabled = False
        tb_nombre.Text = ""
        'tb_porcentaje.Text = ""
        'lb_minimo.Text = ""
        'tb_max.Text = ""
        Button3.Enabled = True
        actualiza = False
        Button5.Text = "Aceptar"
        celdaSeleccionadaIntervalos = -1
        tb_max.Maximum = 100
        Panel2.Enabled = True
        Panel4.Enabled = True
        Panel5.Enabled = True
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox6.Enabled = True
        GroupBox9.Enabled = True
        GroupBox10.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim corrimiento As Integer
        Dim aux As Integer
        Dim Linea As DataRow
        Dim index
        Dim numIndex As Integer
        For corrimiento = 0 To lb_productos.SelectedItems.Count - 1
            Linea = tablaAgrupacion.NewRow()
            Linea(0) = CType(lb_productos.SelectedItems(corrimiento), myItem).Value
            Linea(1) = CType(lb_productos.SelectedItems(corrimiento), myItem).Text
            Linea(2) = 1
            tablaAgrupacion.Rows.Add(Linea)
        Next
        index = lb_productos.SelectedIndices
        numIndex = index.Count - 1
        For corrimiento = 0 To numIndex
            aux = numIndex - corrimiento
            aux = index(aux)
            lb_productos.Items.RemoveAt(aux)
        Next
    End Sub

    Private Sub dg_precio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_precio.Click
        If tb_costo.Text <> "0.00" Then
            Panel3.Enabled = False
            Panel4.Enabled = False
            Panel5.Enabled = False
            GroupBox6.Enabled = False
            GroupBox5.Enabled = True
            GroupBox4.Enabled = False
            GroupBox1.Enabled = False
            GroupBox9.Enabled = False
            GroupBox10.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            lb_nombre.Text = dg_precio.Item(dg_precio.CurrentCell.RowNumber, 1)
            tb_Precio.Text = dg_precio.Item(dg_precio.CurrentCell.RowNumber, 2)
            tb_descuento.Text = dg_precio.Item(dg_precio.CurrentCell.RowNumber, 3)
        Else
            MsgBox("Falta introducir el costo")
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        dg_precio.Item(dg_precio.CurrentCell.RowNumber, 1) = lb_nombre.Text
        dg_precio.Item(dg_precio.CurrentCell.RowNumber, 2) = FormatNumber(tb_Precio.Text, 2)
        dg_precio.Item(dg_precio.CurrentCell.RowNumber, 3) = FormatNumber(tb_descuento.Text, 2)
        tb_Precio.Text = ""
        lb_nombre.Text = ""
        tb_descuento.Text = ""
        GroupBox5.Enabled = False
        GroupBox4.Enabled = True
        GroupBox1.Enabled = True
        GroupBox9.Enabled = True
        GroupBox10.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Panel3.Enabled = True
        Panel4.Enabled = True
        Panel5.Enabled = True
        GroupBox6.Enabled = True
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        tb_Precio.Text = ""
        lb_nombre.Text = ""
        tb_descuento.Text = ""
        GroupBox5.Enabled = False
        GroupBox4.Enabled = True
        GroupBox1.Enabled = True
        GroupBox9.Enabled = True
        GroupBox10.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Panel3.Enabled = True
        Panel4.Enabled = True
        Panel5.Enabled = True
        GroupBox6.Enabled = True
    End Sub

    'Comienza la validacion de las texbox
    ' eventos del texbox Precio

    Private Sub tb_Precio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_Precio.Click
        copia_precio = tb_Precio.Text
    End Sub

    Private Sub tb_Precio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_Precio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_Precio.Text <> "" And tb_Precio.Text <> "." Then
                tb_Precio.Text = FormatNumber(tb_Precio.Text, 2)
            Else
                tb_Precio.Text = FormatNumber(copia_precio, 2)
            End If
        End If
    End Sub

    Private Sub tb_Precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_Precio.KeyPress
        e.Handled = txtNumerico(tb_Precio, e.KeyChar, True)
    End Sub

    Private Sub tb_Precio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_Precio.KeyUp
        If tb_Precio.Text <> "" And tb_Precio.Text <> "." Then
            tb_descuento.Text = FormatNumber(((tb_Precio.Text - tb_costo.Text) / tb_costo.Text) * 100, 2)
        End If
    End Sub

    Private Sub tb_Precio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_Precio.LostFocus
        If tb_Precio.Text = "" Or tb_Precio.Text = "." Then
            tb_Precio.Text = copia_precio
        End If
        tb_Precio.Text = FormatNumber(tb_Precio.Text)
        copia_precio = tb_Precio.Text
    End Sub

    ' eventos del texbox Descuento

    Private Sub tb_descuento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_descuento.Click
        copia_descuento = tb_costo.Text
    End Sub

    Private Sub tb_descuento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_descuento.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_descuento.Text <> "" Then
                tb_descuento.Text = FormatNumber(tb_descuento.Text, 2)
            Else
                tb_descuento.Text = FormatNumber(copia_descuento, 2)
            End If
        End If
    End Sub

    Private Sub tb_descuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_descuento.KeyPress
        e.Handled = txtNumerico(tb_descuento, e.KeyChar, True)
    End Sub

    Private Sub tb_descuento_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_descuento.KeyUp
        If tb_descuento.Text <> "" And tb_descuento.Text <> "." Then
            tb_Precio.Text = FormatNumber(tb_costo.Text * (1 + (tb_descuento.Text / 100)))
        End If
    End Sub

    Private Sub tb_descuento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_descuento.LostFocus
        If tb_descuento.Text = "" Or tb_descuento.Text = "." Then
            tb_descuento.Text = copia_descuento
        End If
        tb_descuento.Text = FormatNumber(tb_descuento.Text)
        copia_descuento = tb_descuento.Text
    End Sub
    ' eventos del texbox  Costo
    Private Sub tb_costo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_costo.Click
        copia_costo = tb_costo.Text
    End Sub
    Private Sub tb_costo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_costo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_costo.Text <> "" Then
                tb_costo.Text = FormatNumber(tb_costo.Text, 2)
                tb_descripcion.Focus()
            Else
                tb_costo.Text = FormatNumber(copia_costo, 2)
            End If
        End If
    End Sub

    Private Sub tb_costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_costo.KeyPress
        e.Handled = txtNumerico(tb_costo, e.KeyChar, True)
    End Sub

    Private Sub tb_costo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_costo.KeyUp
        Dim contador As Integer
        If tb_costo.Text <> "" And btn_aceptar.Text <> "Guardar" And tb_costo.Text <> "." Then
            For contador = 0 To tablaPrecio.Rows.Count - 1
                dg_precio.Item(contador, 2) = FormatNumber(tb_costo.Text * (1 + (dg_precio.Item(contador, 3) / 100)), 2)
            Next
        Else
            tb_Precio.Text = 0
        End If

    End Sub
    Private Sub tb_costo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_costo.LostFocus
        If tb_costo.Text = "" Or tb_costo.Text = "." Then
            tb_costo.Text = copia_costo
        End If
        tb_costo.Text = FormatNumber(tb_costo.Text)
        If btn_aceptar.Text = "Guardar" And copia_costo <> tb_costo.Text And tb_descripcion.Focus = True Then
            If MsgBox("Desea actualizar los precios ", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                For contador = 0 To tablaPrecio.Rows.Count - 1
                    dg_precio.Item(contador, 2) = FormatNumber(tb_costo.Text * (1 + (dg_precio.Item(contador, 3) / 100)), 2)
                Next
                '--actualizamos la tabla de precios
                Dim costo_producto As Decimal = CDec(tb_costo.Text)
                If tabla.Rows.Count = 0 Then
                    MsgBox("No se encontraron precios disponibles.Se ha cancelado la operacion")
                Else
                    Dim utilidad_maxima As Double = CDbl(dg_intervalos.Item(0, 5))
                    For x = 0 To tabla.Rows.Count - 1
                        dg_intervalos.Item(x, 7) = FormatNumber(costo_producto + (costo_producto * (CDec(dg_intervalos.Item(x, 3)) / 100)), 2)
                    Next
                    ' MsgBox(utilidad_maxima & " " & utilidad_producto)
                End If
                '----------------------------------
            End If
        End If
        copia_costo = tb_costo.Text
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_buscar.Click
        Panel1.Visible = False
        GroupBox7.Visible = True
        GroupBox1.Visible = False
        GroupBox8.Visible = True
        GroupBox9.Visible = False
        GroupBox10.Visible = False
        Panel2.Enabled = False
        Panel3.Enabled = False
        Panel4.Enabled = False
        Panel5.Visible = False
    End Sub
    Private Sub btn_aceptar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim corrimiento As Integer
        Dim cadena As String
        Dim bandera_correcto As Boolean = True
        Dim id_marca As Integer
        'Dim consulta As ADODB.Recordset
        Dim precio As String
        Dim id_producto As Integer = 0
        'consulta = conector()
        ' conn.BeginTrans()
        cadena = "Error en los siguientes campos:" & vbCrLf
        'Try
        If tb_producto.Text = "" Then
            cadena = cadena & "   Producto" & vbCrLf
            bandera_correcto = False
        End If
        If tb_codigo.TextLength = 0 Or tb_codigo.Text = "0" Then
            cadena = cadena & "   Codigo de barra" & vbCrLf
            bandera_correcto = False
        End If
        If tb_medida.Text = "0" Then
            cadena = cadena & "   Medida" & vbCrLf
            bandera_correcto = False
        End If
        If tb_costo.Text = "0" Then
            cadena = cadena & "   Costo" & vbCrLf
            bandera_correcto = False
        End If


        If Trim(cb_talla.Text) = "" Then
            cadena = cadena & "   Talla" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(cb_color.Text) = "" Then
            cadena = cadena & "   Color" & vbCrLf
            bandera_correcto = False
        End If

        If cb_almacenes.SelectedIndex = -1 Then
            cadena = cadena & "     Almacen" & vbCrLf
            bandera_correcto = False
        End If
        If tb_cantidad_minima.TextLength = 0 Then
            cadena = cadena & "   Cantidad minima" & vbCrLf
            bandera_correcto = False
        End If
        If tb_cantidad_maxima.TextLength = 0 Then
            cadena = cadena & "   Cantida maxima" & vbCrLf
            bandera_correcto = False
        End If
        If chb_merma.Checked = True Then
            If Trim(tb_merma.TextLength) = 0 Then
                cadena = cadena & "   Merma" & vbCrLf
                bandera_correcto = False
            End If
        End If

        Dim invalidar_intervalos As Integer = 0
        If chb_invalidar_intervalos.Checked = True Then
            invalidar_intervalos = 1
        End If

        Dim merma As Decimal = 0
        If chb_merma.Checked = True Then
            merma = CDec(tb_merma.Text)
        End If

        If bandera_correcto = True Then
            'Conectar()

            If btn_aceptar.Text = "Agregar" Then
                Dim id_unidad As Integer = 0
                '---AGREGAMOS NUEVO PRODUCTO------------------
                If cb_unidad.SelectedIndex = -1 Then
                    If MsgBox("Esta seguro que desea asignar esta unidad", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        conn.Execute("INSERT INTO unidad (nombre) VALUES ('" & cb_unidad.Text.ToUpper & "')")
                        cb_unidad.Items.Add(cb_unidad.Text.ToUpper)
                    End If
                End If
                If cb_marca.SelectedIndex = -1 Then

                    If MsgBox("Esta seguro que desea asignar esta marca " & cb_marca.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        conn.Execute("INSERT INTO producto_marca (nombre) VALUES ('" & cb_marca.Text.ToUpper & "')")
                        cb_marca.Items.Add(cb_marca.Text.ToUpper)
                    End If
                End If

                rs.Open("SELECT id_marca FROM producto_marca WHERE nombre ='" & cb_marca.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    id_marca = rs.Fields("id_marca").Value
                End If
                rs.Close()

                rs.Open("SELECT id_unidad FROM unidad WHERE nombre = '" & cb_unidad.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    id_unidad = rs.Fields("id_unidad").Value
                End If
                rs.Close()

                Dim id_categoria As Integer = 1
                If cb_categoria.SelectedIndex <> -1 Then
                    id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
                End If




                Dim id_talla As Integer = 0
                Dim id_color As Integer = 0

                Dim rw As New ADODB.Recordset

                'buscamos y agregamos talla
                If cb_talla.SelectedIndex = -1 Then
                    rs.Open("SELECT id_producto_talla FROM producto_talla WHERE talla='" & Trim(UCase(cb_talla.Text)) & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_talla = rs.Fields("id_producto_talla").Value
                    Else
                        conn.Execute("INSERT INTO producto_talla(talla) VALUES('" & Trim(UCase(cb_talla.Text)) & "')")
                        rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_talla = rw.Fields(0).Value
                        rw.Close()
                    End If
                    rs.Close()
                Else
                    id_talla = CType(cb_talla.SelectedItem, myItem).Value
                End If

                'buscamos y agregamos color
                If cb_color.SelectedIndex = -1 Then
                    rs.Open("SELECT id_producto_color FROM producto_color WHERE color='" & Trim(UCase(cb_color.Text)) & "'", conn)
                    If rs.RecordCount > 0 Then
                        cb_color = rs.Fields("id_producto_color").Value
                    Else
                        conn.Execute("INSERT INTO producto_color(color) VALUES('" & Trim(UCase(cb_color.Text)) & "')")
                        rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_color = rw.Fields(0).Value
                        rw.Close()
                    End If
                    rs.Close()
                Else
                    id_color = CType(cb_color.SelectedItem, myItem).Value
                End If

                '---insertamos producto
                Dim rs2 As New ADODB.Recordset
                rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
                rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
                rs2.ActiveConnection = conn
                rs2.Open("select * from producto")
                If rs2.RecordCount <> 0 Then
                    rs2.MoveFirst()
                End If
                rs2.AddNew()
                rs2.Fields("nombre").Value = tb_producto.Text
                rs2.Fields("codigo").Value = tb_codigo.Text
                rs2.Fields("medida").Value = tb_medida.Text
                rs2.Fields("id_unidad").Value = id_unidad
                rs2.Fields("venta_peso").Value = CheckBoxVenta_Peso.CheckState
                rs2.Fields("id_categoria").Value = id_categoria
                rs2.Fields("descripcion").Value = tb_descripcion.Text
                rs2.Fields("costo").Value = CDec(tb_costo.Text)
                rs2.Fields("peso").Value = numericUpDown2.Value
                rs2.Fields("id_marca").Value = id_marca
                rs2.Fields("modelo").Value = tb_modelo.Text
                rs2.Fields("id_producto_talla").Value = id_talla
                rs2.Fields("id_producto_color").Value = id_color
                rs2.Fields("id_almacen").Value = CType(cb_almacenes.SelectedItem, myItem).Value
                If bandera_Insertada = True Then
                    rs2.Fields("imagen").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(250, pb_foto.BackgroundImage.Height / (pb_foto.BackgroundImage.Width / 250), Nothing, New IntPtr))
                    rs2.Fields("thumb").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(60, 60, Nothing, New IntPtr))
                End If
                rs2.Fields("fecha_alta").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Fields("fecha_modificacion").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Fields("invalidar_intervalos").Value = invalidar_intervalos
                rs2.Update()
                rs2.Close()
                '-----------------
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id = rs.Fields(0).Value
                For corrimiento = 0 To tablaPrecio.Rows.Count - 1
                    conn.Execute("INSERT INTO producto_precio VALUES ('', " & CDec(dg_precio.Item(corrimiento, 2)) & ", " & dg_precio.Item(corrimiento, 3) & ", " & dg_precio.Item(corrimiento, 0) & ", " & rs.Fields(0).Value & ", NOW(), (NULL) )")
                Next
                'Dim rs2 As New ADODB.Recordset
                rs2.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                precio = rs2.Fields(0).Value
                rs2.Close()

                conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES('" & rs.Fields(0).Value & "','" & CDec(tb_costo.Text) & "','" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "')")

                For corrimiento = 0 To tabla.Rows.Count - 1
                    If dg_intervalos.Item(corrimiento, 2) = "Maximo" Then
                        conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final)" & _
                                     " VALUES ('" & dg_intervalos.Item(corrimiento, 0) & "', '" & dg_intervalos.Item(corrimiento, 6) & "', '" & dg_intervalos.Item(corrimiento, 3) & "', '" & dg_intervalos.Item(corrimiento, 4) & "', '" & rs.Fields(0).Value & "', '" & dg_intervalos.Item(corrimiento, 1) & "', 10000000 )")
                    Else
                        conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final)" & _
                                     " VALUES ('" & dg_intervalos.Item(corrimiento, 0) & "', '" & dg_intervalos.Item(corrimiento, 6) & "', '" & dg_intervalos.Item(corrimiento, 3) & "', '" & dg_intervalos.Item(corrimiento, 4) & "','" & rs.Fields(0).Value & "', '" & dg_intervalos.Item(corrimiento, 1) & "', '" & dg_intervalos.Item(corrimiento, 2) & "')")
                    End If
                Next
                rs2.Open("SELECT id_catalogo_precio,nombre FROM catalogo_precios WHERE utilidad=0", conn)
                If rs2.RecordCount > 0 Then
                    While Not rs2.EOF
                        conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final)" & _
                                   " VALUES ('" & rs2.Fields("nombre").Value & "', '" & rs2.Fields("id_catalogo_precio").Value & "', '0.00', '" & dg_precio.Item(0, 3) & "','" & rs.Fields(0).Value & "', 0,0)")
                        rs2.MoveNext()
                    End While
                End If
                rs2.Close()

                For corrimiento = 0 To clb_iva.CheckedItems.Count - 1
                    conn.Execute("INSERT INTO producto_cat_imp VALUES (" & rs.Fields(0).Value & ", " & CType(clb_iva.CheckedItems(corrimiento), myItem).Value & " )")
                Next
                For corrimiento = 0 To tablaAgrupacion.Rows.Count - 1
                    conn.Execute("INSERT INTO producto_compuesto VALUES ( " & rs.Fields(0).Value & ", " & dg_agrupacion.Item(corrimiento, 0) & ", " & dg_agrupacion.Item(corrimiento, 2) & " )")
                Next
                If cb_kid.Checked = True Then
                    conn.Execute("INSERT INTO producto_paquete VALUES ( " & rs.Fields(0).Value & " )")
                End If
                'rs2.Open("SELECT id_sucursal FROM sucursal", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                'While Not rs2.EOF '

                conn.Execute("INSERT INTO  producto_sucursal (id_precio,id_producto,id_sucursal,fecha_alta,precio_especial,precio_especial_inicio,precio_especial_termino,id_almacen,cantidad_minima,cantidad_maxima,merma) VALUES " & _
                             "( '" & precio & "','" & rs.Fields(0).Value & "','" & global_id_sucursal & "', NOW(),'" & CDec(tb_especial.Text) & "', '" & Format(inicial.Value, "yyyy-MM-dd") & "', '" & Format(final.Value, "yyyy-MM-dd") & "','" & CType(cb_almacenes.SelectedItem, myItem).Value & "','" & tb_cantidad_minima.Text & "','" & tb_cantidad_maxima.Text & "','" & merma & "')")
                'rs2.MoveNext()
                'End While
                'rs2.Close()

                ' rs2.Open("SELECT id_almacen FROM almacen", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                'While Not rs2.EOF
                'conn.Execute("INSERT INTO producto_almacen VALUES ( ''," & rs2.Fields("id_almacen").Value & ", " & rs.Fields(0).Value & ", 0, NOW(), (NULL) )")
                'rs2.MoveNext()
                'End While
                'rs2.Close()
                '================AGREGAMOS PRODUCTOS DE PAQUETES================================
                If dgv_productos_modificadores.RowCount > 0 Then
                    conn.Execute("UPDATE producto SET paquete='1' WHERE id_producto=" & rs.Fields(0).Value)
                    For x = 0 To dgv_modificadores.RowCount - 1
                        conn.Execute("INSERT INTO producto_modificador(id_producto,id_modificador) VALUES('" & rs.Fields(0).Value & "','" & dgv_modificadores.Rows(x).Cells("id_modificador").Value & "')")
                    Next
                    For x = 0 To dgv_productos_modificadores.RowCount - 1
                        conn.Execute("INSERT INTO paquete_modificador_producto(id_paquete,id_modificador,id_producto,cantidad) VALUES('" & rs.Fields(0).Value & "','" & dgv_productos_modificadores.Rows(x).Cells("id_modificador").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("id_producto").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("cantidad").Value & "')")
                    Next

                End If
                '===============================================================================
                rs.Close()
                'conn.close()
                'conn = Nothing
                cargar(id)
                MsgBox("Producto registrado correctamente", MsgBoxStyle.Information, "Aviso")
                '----FIN GUARDAR NUEVO PRODUCTO--------------
            Else
                Dim id_unidad As Integer = 0

                If cb_unidad.SelectedIndex = -1 Then
                    If MsgBox("Esta seguro que desea asignar esta unidad", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        conn.Execute("INSERT INTO unidad (nombre) VALUES ('" & cb_unidad.Text.ToUpper & "')")
                        cb_unidad.Items.Add(cb_unidad.Text.ToUpper)
                    End If
                End If
                If cb_marca.SelectedIndex = -1 Then
                    If MsgBox("Esta seguro que desea asignar esta marca " & cb_marca.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        conn.Execute("INSERT INTO producto_marca (nombre) VALUES ('" & cb_marca.Text.ToUpper & "')")
                        cb_marca.Items.Add(cb_marca.Text.ToUpper)
                    End If
                End If
                'Conectar()
                rs.Open("SELECT id_marca FROM producto_marca WHERE nombre ='" & cb_marca.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    id_marca = rs.Fields("id_marca").Value
                End If
                rs.Close()

                rs.Open("SELECT id_unidad FROM unidad WHERE nombre = '" & cb_unidad.Text & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                If rs.RecordCount > 0 Then
                    id_unidad = rs.Fields("id_unidad").Value
                End If
                rs.Close()

                Dim id_categoria As Integer = 1
                If cb_categoria.SelectedIndex <> -1 Then
                    id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
                End If


                Dim id_talla As Integer = 0
                Dim id_color As Integer = 0

                Dim rw As New ADODB.Recordset

                'buscamos y agregamos talla
                If cb_talla.SelectedIndex = -1 Then
                    rs.Open("SELECT id_producto_talla FROM producto_talla WHERE talla='" & Trim(UCase(cb_talla.Text)) & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_talla = rs.Fields("id_producto_talla").Value
                    Else
                        conn.Execute("INSERT INTO producto_talla(talla) VALUES('" & Trim(UCase(cb_talla.Text)) & "')")
                        rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_talla = rw.Fields(0).Value
                        rw.Close()
                    End If
                    rs.Close()
                Else
                    id_talla = CType(cb_talla.SelectedItem, myItem).Value
                End If

                'buscamos y agregamos color
                If cb_color.SelectedIndex = -1 Then
                    rs.Open("SELECT id_producto_color FROM producto_color WHERE color='" & Trim(UCase(cb_color.Text)) & "'", conn)
                    If rs.RecordCount > 0 Then
                        cb_color = rs.Fields("id_producto_color").Value
                    Else
                        conn.Execute("INSERT INTO producto_color(color) VALUES('" & Trim(UCase(cb_color.Text)) & "')")
                        rw.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_color = rw.Fields(0).Value
                        rw.Close()
                    End If
                    rs.Close()
                Else
                    id_color = CType(cb_color.SelectedItem, myItem).Value
                End If
                '---actualizamos producto
                Dim rs2 As New ADODB.Recordset

                rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
                rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
                rs2.ActiveConnection = conn
                rs2.Open("SELECT * FROM producto WHERE id_producto=" & id)
                If rs2.RecordCount <> 0 Then
                    rs2.MoveFirst()
                End If
                'rs2.AddNew()
                rs2.Fields("nombre").Value = tb_producto.Text
                rs2.Fields("codigo").Value = tb_codigo.Text
                rs2.Fields("medida").Value = tb_medida.Text
                rs2.Fields("id_unidad").Value = id_unidad
                rs2.Fields("venta_peso").Value = CheckBoxVenta_Peso.CheckState
                rs2.Fields("id_categoria").Value = id_categoria
                rs2.Fields("descripcion").Value = tb_descripcion.Text
                rs2.Fields("costo").Value = CDec(tb_costo.Text)
                rs2.Fields("peso").Value = numericUpDown2.Value
                rs2.Fields("id_marca").Value = id_marca
                rs2.Fields("modelo").Value = tb_modelo.Text

                rs2.Fields("id_producto_talla").Value = id_talla
                rs2.Fields("id_producto_color").Value = id_color

                'rs2.Fields("id_marca").Value = id_marca
                'rs2.Fields("modelo").Value = tb_modelo.Text
                rs2.Fields("id_almacen").Value = CType(cb_almacenes.SelectedItem, myItem).Value
                If bandera_Insertada = True Then
                    rs2.Fields("imagen").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(250, pb_foto.BackgroundImage.Height / (pb_foto.BackgroundImage.Width / 250), Nothing, New IntPtr))
                    rs2.Fields("thumb").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(60, 60, Nothing, New IntPtr))
                End If
                'rs2.Fields("fecha_alta").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Fields("fecha_modificacion").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Fields("invalidar_intervalos").Value = invalidar_intervalos

                rs2.Update()
                rs2.Close()
                '-----------------
                'conn.Execute("UPDATE producto SET nombre='" & tb_producto.Text & "', codigo= '" & tb_codigo.Text & "', medida=" & tb_medida.Text & ", id_unidad=" &  & ", descripcion='" & tb_descripcion.Text & "', costo=" & tb_costo.Text & ",peso=" & numericUpDown2.Value & ", fecha_modificacion=NOW() WHERE id_producto=" & id)
                Dim ultimo_costo As Decimal = 0

                rs.Open("SELECT costo FROM producto_costo WHERE id_producto='" & id & "' ORDER BY fecha DESC LIMIT 1", conn)
                If rs.RecordCount > 0 Then
                    ultimo_costo = rs.Fields("costo").Value
                End If
                rs.Close()
                If ultimo_costo <> CDec(tb_costo.Text) Then
                    conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES('" & id & "','" & CDec(tb_costo.Text) & "','" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "')")

                    Dim rx As New ADODB.Recordset
                    rx.Open("SELECT id_descuento,descuento FROM producto_volumen WHERE id_producto='" & id & "' ORDER BY id_catalogo_precio DESC", conn)
                    If rx.RecordCount > 0 Then
                        Dim i As Integer = 1
                        While Not rx.EOF
                            Dim precio_catalogo As Decimal = FormatNumber((CDec(dg_precio.Item(0, 2)) - (CDec(tb_costo.Text) * (rx.Fields("descuento").Value / 100))), 2)
                            Dim _descuento As Decimal = FormatNumber((((CDec(dg_precio.Item(0, 2)) - precio_catalogo) / CDec(tb_costo.Text)) * 100), 2)
                            conn.Execute("UPDATE producto_volumen SET descuento='" & _descuento & "' WHERE id_descuento='" & rx.Fields("id_descuento").Value & "'")
                            rx.MoveNext()
                        End While
                    End If
                    rx.Close()
                End If

                conn.Execute("UPDATE producto_sucursal SET precio_especial='" & CDec(tb_especial.Text) & "',precio_especial_inicio='" & Format(inicial.Value, "yyyy-MM-dd") & "', precio_especial_termino='" & Format(final.Value, "yyyy-MM-dd") & "',cantidad_minima='" & tb_cantidad_minima.Text & "',cantidad_maxima='" & tb_cantidad_maxima.Text & "',merma='" & merma & "' WHERE id_producto=" & id)

                For corrimiento = 0 To tablaPrecio.Rows.Count - 1
                    conn.Execute("UPDATE producto_precio SET precio='" & CDec(dg_precio.Item(corrimiento, 2)) & "', ganacia='" & dg_precio.Item(corrimiento, 3) & "' WHERE id_producto=" & id & " AND id_nombre_precio='" & dg_precio.Item(corrimiento, 0) & "'")
                Next

                If bandera_intervalos = True Then
                    conn.Execute("DELETE FROM producto_volumen  WHERE id_producto=" & id)
                    For corrimiento = 0 To tabla.Rows.Count - 1
                        If dg_intervalos.Item(corrimiento, 2) = "Maximo" Then
                            conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final)" & _
                                         " VALUES ('" & dg_intervalos.Item(corrimiento, 0) & "', '" & dg_intervalos.Item(corrimiento, 6) & "', '" & dg_intervalos.Item(corrimiento, 3) & "', '" & dg_intervalos.Item(corrimiento, 4) & "', '" & id & "', '" & dg_intervalos.Item(corrimiento, 1) & "', 10000000 )")
                        Else
                            conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final)" & _
                                         " VALUES ('" & dg_intervalos.Item(corrimiento, 0) & "', '" & dg_intervalos.Item(corrimiento, 6) & "', '" & dg_intervalos.Item(corrimiento, 3) & "', '" & dg_intervalos.Item(corrimiento, 4) & "','" & id & "', '" & dg_intervalos.Item(corrimiento, 1) & "', '" & dg_intervalos.Item(corrimiento, 2) & "')")
                        End If
                    Next
                    rs.Open("SELECT id_catalogo_precio,nombre FROM catalogo_precios WHERE utilidad=0", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final)" & _
                                       " VALUES ('" & rs.Fields("nombre").Value & "', '" & rs.Fields("id_catalogo_precio").Value & "', '0.00', '" & dg_precio.Item(0, 3) & "','" & id & "', 0,0)")
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()
                End If
                If bandera_ivas = True Then
                    conn.Execute("DELETE FROM producto_cat_imp  WHERE id_producto=" & id)
                    For corrimiento = 0 To clb_iva.CheckedItems.Count - 1
                        conn.Execute("INSERT INTO producto_cat_imp VALUES (" & id & ", " & CType(clb_iva.CheckedItems(corrimiento), myItem).Value & " )")
                    Next
                End If
                If bandera_paquete = True Then
                    '=============== =AGREGAMOS PRODUCTOS DE PAQUETES================================
                    conn.Execute("DELETE FROM producto_modificador WHERE id_producto=" & id)
                    conn.Execute("DELETE FROM paquete_modificador_producto WHERE id_paquete=" & id)
                    If dgv_productos_modificadores.RowCount > 0 Then
                        conn.Execute("UPDATE producto SET paquete='1' WHERE id_producto=" & id)
                        For x = 0 To dgv_modificadores.RowCount - 1
                            conn.Execute("INSERT INTO producto_modificador(id_producto,id_modificador) VALUES('" & id & "','" & dgv_modificadores.Rows(x).Cells("id_modificador").Value & "')")
                        Next
                        For x = 0 To dgv_productos_modificadores.RowCount - 1
                            conn.Execute("INSERT INTO paquete_modificador_producto(id_paquete,id_modificador,id_producto,cantidad) VALUES('" & id & "','" & dgv_productos_modificadores.Rows(x).Cells("id_modificador").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("id_producto").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("cantidad").Value & "')")
                        Next
                    Else
                        conn.Execute("UPDATE producto SET paquete='0' WHERE id_producto=" & id)
                    End If
                    '===========================================================
                End If

                'conn.close()
                'conn = Nothing
                cargar(id)
                MsgBox("producto actualizado correctamente")
            End If
        Else
            MsgBox(cadena)
        End If
        ' conn.CommitTrans()
        ' Catch ex As Exception
        ' Try
        'rs.Close()
        'Catch ex1 As Exception
        'End Try
        ' conn.RollbackTrans()
        'MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub tb_codigoProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_codigoProducto.KeyDown
        Dim corrimiento As Integer
        Dim numProductos As Integer
        If e.KeyCode = Keys.Enter Then
            numProductos = lb_productos.Items.Count - 1
            For corrimiento = 0 To numProductos
                If tb_codigoProducto.Text = CType(lb_productos.Items(corrimiento), myItem).Value Then
                    Linea = tablaAgrupacion.NewRow()
                    Linea(0) = CType(lb_productos.Items(corrimiento), myItem).Value
                    Linea(1) = CType(lb_productos.Items(corrimiento), myItem).Text
                    Linea(2) = 1
                    tablaAgrupacion.Rows.Add(Linea)
                    lb_productos.Items.RemoveAt(corrimiento)
                    corrimiento = numProductos + 1
                End If

            Next
        End If
    End Sub
    Private Sub lb_productos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_productos.DoubleClick
        Button1_Click(sender, e)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupBox7.Visible = False
        GroupBox1.Visible = True
        GroupBox8.Visible = False
        GroupBox9.Visible = True
        GroupBox10.Visible = True
        Panel1.Visible = True
        Panel2.Enabled = True
        Panel3.Enabled = True
        Panel4.Enabled = True
        Panel5.Visible = True
    End Sub
    Private Sub dg_agrupacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_agrupacion.Click
        If 0 < tablaAgrupacion.Rows.Count Then
            GroupBox8.Enabled = True
            GroupBox8.Text = "Numero de Articulos de " & dg_agrupacion.Item(dg_agrupacion.CurrentCell.RowNumber, 1)
            tb_numArticulos.Text = dg_agrupacion.Item(dg_agrupacion.CurrentCell.RowNumber, 2)
        End If
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        dg_agrupacion.Item(dg_agrupacion.CurrentCell.RowNumber, 2) = tb_numArticulos.Text
        tb_numArticulos.Text = ""
        GroupBox8.Text = "Numero de Articulos"
        GroupBox8.Enabled = False
    End Sub
    Private Sub tb_numArticulos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_numArticulos.KeyDown
        If e.KeyCode = Keys.Enter Then
            dg_agrupacion.Item(dg_agrupacion.CurrentCell.RowNumber, 2) = tb_numArticulos.Text
            tb_numArticulos.Text = ""
            GroupBox8.Text = "Numero de Articulos"
            GroupBox8.Enabled = False
        End If
    End Sub
    Private Sub dg_agrupacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_agrupacion.DoubleClick
        Dim contador As Integer
        contador = tablaAgrupacion.Rows.Count
        While 0 < contador
            If dg_agrupacion.IsSelected(contador - 1) = True Then
                lb_productos.Items.Add(New myItem(dg_agrupacion.Item(contador - 1, 0), dg_agrupacion.Item(contador - 1, 1)))
                dg_agrupacion.Item(contador - 1, 0) = ""
            End If
            contador = contador - 1
        End While
        contador = tablaAgrupacion.Rows.Count
        While 0 < contador
            If dg_agrupacion.Item(contador - 1, 0) = "" Then
                tablaAgrupacion.Rows.Item(contador - 1).Delete()
            End If
            contador = contador - 1
        End While
    End Sub
    Private Sub tb_numArticulos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_numArticulos.KeyPress
        e.Handled = txtNumerico(tb_numArticulos, e.KeyChar, True)
    End Sub
    Private Sub tb_codigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub
    Private Sub tb_medida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_medida.KeyPress
        e.Handled = validar_teclado(e.KeyChar, {"0"})
    End Sub
    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_actualizar.Click
        For contador = 0 To tablaPrecio.Rows.Count - 1
            dg_precio.Item(contador, 2) = FormatNumber(tb_costo.Text * (1 + (dg_precio.Item(contador, 3) / 100)), 2)
        Next
    End Sub
    Private Sub tb_especial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_especial.Click
        copia_especial = tb_especial.Text
    End Sub
    Private Sub tb_especial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_especial.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_especial.Text <> "" Then
                tb_especial.Text = FormatNumber(tb_especial.Text, 2)
                inicial.Focus()
            Else
                tb_especial.Text = FormatNumber(copia_especial, 2)
            End If
        End If
    End Sub
    Private Sub tb_especial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_especial.KeyPress
        e.Handled = txtNumerico(tb_especial, e.KeyChar, True)
    End Sub
    Private Sub tb_especial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_especial.LostFocus
        If tb_especial.Text = "" Or tb_especial.Text = "." Then
            tb_especial.Text = copia_especial
        End If
        tb_especial.Text = FormatNumber(tb_especial.Text)
        copia_especial = tb_especial.Text
    End Sub

    Private Sub clb_iva_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles clb_iva.ItemCheck
        bandera_ivas = True
    End Sub
    Private Sub newToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newToolStripButton.Click
        cargar()
    End Sub

    Private Sub openToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openToolStripButton.Click
        global_frm_producto_abrir = 2
        frm_producto_abrir.ShowDialog()
    End Sub
    Private Sub Button9_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ofd_foto.ShowDialog()
        'If bandera_Insertada = False Then
        'MsgBox("Tamaño de la imagen sobrepasa lo permitido")
        'ofd_foto.FileName = ""
        '
        'bandera_Insertada = True

        'Button9_Click(sender, e)
        'End If
    End Sub
    Private Sub ofd_foto_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofd_foto.FileOk
        Dim tamaño As Integer
        Dim File As New System.IO.FileInfo(ofd_foto.FileName)
        tamaño = File.Length / 1024
        bandera_Insertada = True
        If ofd_foto.FileName <> "" Then
            'If (tamaño < 63) Then
            pb_foto.BackgroundImage = New Bitmap(ofd_foto.FileName)
            bandera = True
            'Else
            ' bandera_Insertada = False
            'End If
        End If
    End Sub
    Private Sub dg_intervalos_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dg_intervalos.MouseUp
        ' CON ESTA FUNCION SELECCIONAMOS TODA LA FILA-------------
        Dim pt As System.Drawing.Point
        pt = New Point(e.X, e.Y)
        Dim hti As DataGrid.HitTestInfo
        hti = dg_intervalos.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            dg_intervalos.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            dg_intervalos.Select(hti.Row)
        End If
        '-------------------
        '-MOSTRAMOS VALORES SELECCIONADOS-------------------
        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = tabla.Rows.Count
            If dg_intervalos.IsSelected(NumRow) = True Then
                tb_min.Value = dg_intervalos.Item(NumRow, 1)
                If dg_intervalos.Item(NumRow, 2) = "Maximo" Then
                    chb_max.Checked = True
                    tb_max.Value = 0
                Else
                    chb_max.Checked = False
                    tb_max.Value = dg_intervalos.Item(NumRow, 2)
                End If
                tb_porcentaje.Value = dg_intervalos.Item(NumRow, 3)
                Button11.Enabled = True
            End If
            NumRow = NumRow + 1
        Loop
        '--------------------------------------------
    End Sub
    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        GroupBox3.Enabled = True
        GroupBox2.Enabled = False
        chb_poner_ceros.Checked = False
        'If tb_max.Value = 1 Then
        '   tb_max.Enabled = False
        'Else
        'tb_max.Enabled = True
        'End If
    End Sub
    Private Sub btn_aceptar_intervalo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar_intervalo.Click
        'If tb_max.Value > 1000 Then
        'MsgBox("El intervalo no puede ser mayor que 1000")
        'Exit Sub
        'End If
        bandera_intervalos = True
        If dg_intervalos.CurrentCell.RowNumber > 0 Then
            ' tb_porcentaje.Maximum = dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber - 1, 3).ToString - 0.01
            'tb_porcentaje.Maximum = dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber - 1, 3).ToString
        End If
        dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 1) = tb_min.Value
        If chb_max.Checked = True Then
            dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 2) = "Maximo"
        Else
            dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 2) = tb_max.Value
        End If

        dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 3) = tb_porcentaje.Value
        dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 4) = Format(CDbl(CDbl(dg_precio.Item(0, 3)) - dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 3)), "00.00") & " %"
        dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber, 7) = FormatNumber(tb_precio_intervalo.Text, 2)
        ' If dg_intervalos.CurrentCell.RowNumber > 0 Then
        'dg_intervalos.Item(dg_intervalos.CurrentCell.RowNumber - 1, 2) = tb_max.Text - 1
        '  End If
        dg_intervalos.Enabled = True
        GroupBox3.Enabled = False
        tb_nombre.Text = ""
        'tb_porcentaje.Text = ""
        'lb_minimo.Text = ""
        'tb_max.Text = ""
        Button3.Enabled = True
        actualiza = False
        Button5.Text = "Aceptar"
        celdaSeleccionadaIntervalos = -1
        ' tb_max.Minimum = 1
        'tb_max.Maximum = 1000
        tb_porcentaje.Minimum = 0
        'tb_porcentaje.Maximum = 100
        Panel2.Enabled = True
        Panel4.Enabled = True
        Panel5.Enabled = True
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox6.Enabled = True
        GroupBox9.Enabled = True
        GroupBox10.Enabled = True

        '-MOSTRAMOS VALORES SELECCIONADOS-------------------
        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = tabla.Rows.Count
            If dg_intervalos.IsSelected(NumRow) = True Then
                tb_min.Value = dg_intervalos.Item(NumRow, 1)
                If dg_intervalos.Item(NumRow, 2) = "Maximo" Then
                    chb_max.Checked = True
                    tb_max.Value = 0
                Else
                    chb_max.Checked = False
                    tb_max.Value = dg_intervalos.Item(NumRow, 2)
                End If
                tb_porcentaje.Value = dg_intervalos.Item(NumRow, 3)
            End If
            NumRow = NumRow + 1
        Loop
        '--------------------------------------------
        Button11.Enabled = False
    End Sub
    Private Sub btn_generar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar.Click
        Dim utilidad_producto As Double = CDbl(dg_precio.Item(0, 3))
        Dim costo_producto As Decimal = CDec(tb_costo.Text)
        If tabla.Rows.Count = 0 Then
            MsgBox("No se encontraron precios disponibles.Se ha cancelado la operacion")
        Else
            Dim utilidad_maxima As Double = CDbl(dg_intervalos.Item(0, 5))
            For x = 0 To tabla.Rows.Count - 1
                dg_intervalos.Item(x, 3) = Format(((((CDbl(dg_intervalos.Item(x, 5)) * 100) / utilidad_maxima) / 100) * utilidad_producto), "00.00")
                dg_intervalos.Item(x, 4) = Format(CDbl(utilidad_producto - dg_intervalos.Item(x, 3)), "00.00") & " %"
                dg_intervalos.Item(x, 7) = FormatNumber(costo_producto + (costo_producto * (CDec(dg_intervalos.Item(x, 3)) / 100)), 2)
            Next
            ' MsgBox(utilidad_maxima & " " & utilidad_producto)
        End If
        bandera_intervalos = True
    End Sub
    Private Sub tb_porcentaje_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_porcentaje.ValueChanged
        Dim costo_producto As Decimal = CDec(tb_costo.Text)
        tb_precio_intervalo.Text = FormatNumber(costo_producto + (costo_producto * (tb_porcentaje.Value / 100)), 2)
    End Sub
    Private Sub tb_precio_intervalo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_precio_intervalo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(tb_precio_intervalo.TextLength) <> 0 Then
                If tb_costo.Text <> 0 Then
                    Dim porcentaje As Decimal = FormatNumber((((CDec(tb_precio_intervalo.Text) - CDec(tb_costo.Text)) * 100) / CDec(tb_costo.Text)), 2)
                    '  If porcentaje < tb_porcentaje.Minimum Then
                    'MsgBox("La utilidad es negativa")
                    'tb_precio_intervalo.Text = ""
                    'Else
                    '   If porcentaje > tb_porcentaje.Maximum Then
                    'MsgBox("La utilidad esta por encima de lo permitido")
                    'tb_precio_intervalo.Text = ""
                    'Else
                    tb_porcentaje.Value = porcentaje
                    'End If
                    ' End If
                Else
                    MsgBox("El costo no puede ser cero")
                    tb_precio_intervalo.Text = ""
                End If
            End If
        End If
    End Sub
    Private Sub tb_precio_intervalo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_precio_intervalo.LostFocus
        If Trim(tb_precio_intervalo.TextLength) <> 0 Then
            If tb_costo.Text <> 0 Then
                Dim porcentaje As Decimal = FormatNumber((((CDec(tb_precio_intervalo.Text) - CDec(tb_costo.Text)) * 100) / CDec(tb_costo.Text)), 2)
                'If porcentaje < tb_porcentaje.Minimum Then
                'MsgBox("La utilidad es negativa")
                'tb_precio_intervalo.Text = ""
                'Else
                'If porcentaje > tb_porcentaje.Maximum Then
                '    MsgBox("La utilidad esta por encima de lo permitido")
                '   tb_precio_intervalo.Text = ""
                'Else
                tb_porcentaje.Value = porcentaje
                'End If
                'End If
            Else
                MsgBox("El costo no puede ser cero")
                tb_precio_intervalo.Text = ""
            End If
        End If
    End Sub

    Private Sub chb_poner_ceros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_poner_ceros.CheckedChanged
        If chb_poner_ceros.Checked = True Then
            chb_max.Checked = False
            tb_max.Value = 0
            tb_min.Value = 0
        End If
    End Sub
    Private Sub tb_merma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_merma.KeyPress
        e.Handled = txtNumerico(tb_merma, e.KeyChar, True)
    End Sub
    Private Sub chb_merma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_merma.CheckedChanged
        If chb_merma.Checked = True Then
            tb_merma.Enabled = True
        Else
            tb_merma.Enabled = False
            tb_merma.Text = "0.00"
        End If
    End Sub
    Private Sub btn_agregar_modificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_modificador.Click
        frm_modificadores.Show()
    End Sub

    Private Sub btn_eliminar_modificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_modificador.Click

        Dim correcto As Boolean = True

delete: If tabla_prdcts_modificadores.Rows.Count > 0 Then
            For x = 0 To dgv_productos_modificadores.RowCount - 1
                correcto = True
                If dgv_modificadores.Rows(dgv_modificadores.CurrentRow.Index).Cells("id_modificador").Value = dgv_productos_modificadores.Rows(x).Cells("id_modificador").Value Then
                    dgv_productos_modificadores.Rows.RemoveAt(dgv_productos_modificadores.Rows(x).Index)
                    correcto = False
                    Exit For
                End If
            Next
        Else
            correcto = True
        End If


        If correcto = False Then
            GoTo delete
        End If

        dgv_modificadores.Rows.RemoveAt(dgv_modificadores.CurrentRow.Index)
        If dgv_modificadores.Rows.Count = 0 Then
            btn_eliminar_modificador.Enabled = False
            btn_agregar_prdct_modificador.Enabled = False
        Else
            btn_eliminar_modificador.Enabled = True
            btn_agregar_prdct_modificador.Enabled = True
        End If
        bandera_paquete = True
    End Sub
    Public Sub _agregar_modificador(ByVal id_modificador As Integer, ByVal nombre As String)
        agregar_modificador(id_modificador, nombre)
        btn_eliminar_modificador.Enabled = True
        bandera_paquete = True
    End Sub
    Private Sub dgv_modificadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_modificadores.Click
        If dgv_modificadores.SelectedRows.Count > 0 Then
            btn_eliminar_modificador.Enabled = True
            btn_agregar_prdct_modificador.Enabled = True
        Else
            btn_eliminar_modificador.Enabled = False
            btn_agregar_prdct_modificador.Enabled = False
        End If
    End Sub

    Private Sub dgv_productos_modificadores_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_productos_modificadores.CellValueChanged
        bandera_paquete = True
    End Sub

    Private Sub dgv_productos_modificadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv_productos_modificadores.Click
        If dgv_productos_modificadores.SelectedRows.Count > 0 Then
            btn_eliminar_prdct_modificador.Enabled = True
        Else
            btn_eliminar_prdct_modificador.Enabled = False
        End If
    End Sub
    Public Sub _agregar_producto_modificador(ByVal id_producto As Integer, ByVal descripcion As String)
        agregar_producto_modificador(id_producto, 1, descripcion, dgv_modificadores.Rows(dgv_modificadores.CurrentRow.Index).Cells("id_modificador").Value)
        btn_eliminar_prdct_modificador.Enabled = True
        bandera_paquete = True
    End Sub

    Private Sub btn_agregar_prdct_modificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_prdct_modificador.Click
        frm_busqueda_insumo.Show()
    End Sub

    Private Sub btn_eliminar_prdct_modificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_prdct_modificador.Click
        dgv_productos_modificadores.Rows.RemoveAt(dgv_productos_modificadores.CurrentRow.Index)
        If dgv_productos_modificadores.Rows.Count = 0 Then
            btn_eliminar_prdct_modificador.Enabled = False
        Else
            btn_eliminar_prdct_modificador.Enabled = True
        End If
        bandera_paquete = True
    End Sub
    Private Sub btn_eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar.Click
        If existen_turnos_abiertos() = False Then
            eliminar_producto(id)
        Else
            MsgBox("Se encontro turno(s) abierto(s), para realizar esta operacion, todos los usuarios deben realizar corte de caja!", MsgBoxStyle.Exclamation, "aviso")
        End If
    End Sub

    Private Sub eliminar_producto(ByVal id As Integer)
        'Conectar()
        conn.Execute("DELETE FROM factura_compra_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM cliente_productos WHERE id_producto=" & id)
        conn.Execute("DELETE FROM cotizacion_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM detalle_pedido WHERE id_producto=" & id)
        conn.Execute("DELETE FROM devoluciones_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM factura_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM pedido_prog_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_cat_imp WHERE id_producto=" & id)
        conn.Execute("DELETE FROM cliente_productos WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_compuesto WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_equivalente WHERE id_producto_equivalente=" & id)
        conn.Execute("DELETE FROM producto_equivalente WHERE id_producto_origen=" & id)
        conn.Execute("DELETE FROM producto_volumen WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_sucursal WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto_precio WHERE id_producto=" & id)
        conn.Execute("DELETE FROM proveedor_productos WHERE id_producto=" & id)
        conn.Execute("DELETE FROM temp_venta_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM traspaso_env_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM traspaso_recep_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM venta_detalle WHERE id_producto=" & id)
        conn.Execute("DELETE FROM producto WHERE id_producto=" & id)
        'conn.close()
        'conn = Nothing
        cargar()
        MsgBox("El producto ha sido eliminado correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub
    Private Function existen_turnos_abiertos() As Boolean
        Dim abierto As Boolean = False
        'Conectar()
        Dim hoy As String = Format(Today, "yyyy-MM-dd")
        rs.Open("SELECT saldo_inicial FROM caja_saldo_inicial WHERE bandera_corte_caja=0 AND DATE(fecha)='" & hoy & "'", conn)
        If rs.RecordCount > 0 Then
            abierto = True
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        Return abierto
    End Function
    Private Sub mostrar_codigo(ByVal id_categoria As Integer)
        Try
            If id_categoria = 1 Then
                'Conectar()
                rs.Open("SELECT CASE WHEN ISNULL(MAX(codigo)) THEN 1 ELSE (MAX(codigo)+1) END AS posible FROM producto", conn)
                If rs.RecordCount > 0 Then
                    tb_codigo.Text = rs.Fields("posible").Value
                End If
                rs.Close()
                'conn.close()
            Else
                tb_codigo.Text = "0"
                Dim codigo_posible As String
                'Conectar()
                rs.Open("SELECT CASE WHEN ISNULL(MAX(codigo)) THEN 1 ELSE (MAX(codigo)+1) END AS posible FROM producto WHERE id_categoria='" & id_categoria & "'", conn)
                If rs.RecordCount > 0 Then
                    codigo_posible = rs.Fields("posible").Value
                End If
                rs.Close()

                For x = 0 To 1000
                    Dim codigo As String
                    codigo = FormatNumber(CDbl(codigo_posible), 0) + 1

                    rs.Open("SELECT id_producto FROM producto WHERE codigo='" & codigo & "'", conn)
                    If rs.RecordCount = 0 Then
                        tb_codigo.Text = codigo
                        rs.Close()
                        Exit For
                    End If
                    rs.Close()
                Next

                'conn.close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cb_categoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_categoria.SelectedIndexChanged
        If cb_categoria.SelectedIndex <> -1 Then
            If id = 0 Then
                mostrar_codigo(CType(cb_categoria.SelectedItem, myItem).Value)
            End If
        End If
    End Sub


    Private Sub btn_ver_codigos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ver_codigos.Click
        If cb_categoria.SelectedIndex <> -1 Then
            ' frm_productos_codigos.cargar(CType(cb_categoria.SelectedItem, myItem).Value, tb_producto.Text, 0
            frm_productos_codigos.id_categoria = CType(cb_categoria.SelectedItem, myItem).Value
            frm_productos_codigos.producto = tb_producto.Text
            frm_productos_codigos.tipo_bus = 1
            frm_productos_codigos.ShowDialog()
        Else
            'frm_productos_codigos.cargar(1, tb_producto.Text, 0)
            frm_productos_codigos.id_categoria = 1
            frm_productos_codigos.producto = tb_producto.Text
            frm_productos_codigos.tipo_bus = 1
            frm_productos_codigos.ShowDialog()

        End If
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

    Private Sub tb_costo_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_costo.TextChanged

    End Sub
End Class