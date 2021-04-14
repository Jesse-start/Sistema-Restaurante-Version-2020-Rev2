Imports System.Math
Public Class frm_producto2
    Private id_producto As Integer = 0
    Public precarga As Boolean = False
    Private cargado As Boolean = False
    Private bandera_imagen As Boolean = False
    Private bandera_paquete As Boolean = False
    Private bandera_costo As Boolean = False
    Private bDatos() As Byte

    Dim reg_por_pag As Integer = 20
    Dim inicial As Integer = 0
    Dim total_productos As Integer = 0
    Dim total_paginas As Integer = 0


    Private Sub frm_producto2_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_producto = 0
    End Sub
    Public Sub cargar()
        '  Try

        estilo_prdcts_modificadores(dgv_productos_modificadores)
        estilo_modificadores(dgv_modificadores)
        estilo_tabla_precios(dgv_precios)

        configuracion_listas()
        configuracion_inicio()
        rellenar_catalogo_combobox("id_categoria", "nombre", "categoria", cb_categoria)

        rellenar_catalogo_combobox("id_unidad", "nombre", "unidad", cb_unidad)
        rellenar_catalogo_combobox("id_almacen", "nombre", "almacenes", cb_almacen, , " where id_almacen_tipo=1")
        rellenar_catalogo_combobox("id_cfg_impuesto", "nombre", "cfg_impuesto", cb_impuesto)

        rellenar_catalogo_combobox("id_marca", "nombre", "producto_marca", cb_marca)
        rellenar_catalogo_combobox("id_modelo", "nombre", "producto_modelo", cb_modelo)
        rellenar_catalogo_combobox("id_talla", "nombre", "producto_talla", cb_talla)
        rellenar_catalogo_combobox("id_color", "nombre", "producto_color", cb_color)
        rellenar_catalogo_combobox("id_clavesat", "clave", "producto_clavesat", cb_clavesat)
        rellenar_catalogo_combobox("id_categoria", "nombre", "categoria", cb_categoria_busqueda, True)


        tab_compuesto.Parent = Nothing
        tab_conversiones.Parent = Nothing

        ' Catch ex As Exception
        ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        ' End Try
    End Sub
    Private Sub frm_producto2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        global_frm_producto = 1
        cargar()
    End Sub
    Public Sub rellenar_catalogo_combobox(id As String, valor As String, tabla_db As String, combobox As ComboBox, Optional opcion_general As Boolean = False, Optional condicion As String = "")
        Dim recordset As New ADODB.Recordset
        combobox.Items.Clear()
        If opcion_general = True Then
            combobox.Items.Add(New myItem("0", "Todos"))
        End If

        recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & condicion & "", conn)
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
        btn_buscar.Enabled = True
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = False
        tb_codigo.Text = ""
        tb_nombre.Text = ""
        tb_descripcion.Text = ""
        tb_precio_compra.Text = ""
        tb_precio_venta.Text = ""
        chb_venta_peso.CheckState = False
        cb_clavesat.Text = ""


        cb_modelo.Text = ""
        cb_marca.Text = ""
        cb_color.Text = ""
        cb_talla.Text = ""
        cb_almacen.Text = ""

        cb_categoria.SelectedIndex = -1
        cb_impuesto.SelectedIndex = -1
        cb_modelo.SelectedIndex = -1
        cb_marca.SelectedIndex = -1
        cb_color.SelectedIndex = -1
        cb_talla.SelectedIndex = -1
        cb_unidad.SelectedIndex = -1
        cb_almacen.SelectedIndex = -1
        cb_clavesat.SelectedIndex = -1


        tb_stock_maximo.Text = "10"
        tb_stock_minimo.Text = "1"
        tabla_modificadores.Clear()
        tabla_prdcts_modificadores.Clear()
        gb_productos.Enabled = True
       
    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True

        tb_codigo.Text = ""
        tb_nombre.Text = ""
        tb_descripcion.Text = ""
        tb_precio_compra.Text = ""
        tb_precio_venta.Text = ""
        chb_venta_peso.CheckState = False
        cb_clavesat.Text = ""

        cb_modelo.Text = ""
        cb_marca.Text = ""
        cb_color.Text = ""
        cb_talla.Text = ""
        cb_almacen.Text = ""

        cb_categoria.SelectedIndex = -1
        cb_impuesto.SelectedIndex = -1
        cb_modelo.SelectedIndex = -1
        cb_marca.SelectedIndex = -1
        cb_color.SelectedIndex = -1
        cb_talla.SelectedIndex = -1
        cb_unidad.SelectedIndex = -1
        cb_almacen.SelectedIndex = -1
        cb_clavesat.SelectedIndex = -1



        tb_stock_maximo.Text = "10"
        tb_stock_minimo.Text = "1"
        tabla_modificadores.Clear()
        tabla_prdcts_modificadores.Clear()
        gb_productos.Enabled = False
    End Sub
    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True
        gb_productos.Enabled = False

    End Sub
    Private Sub configuracion_listas()
        With lst_productos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Codigo", 50)
            .Columns.Add("Nombre", 250)
            .Columns.Add("Und.", 40)
            .Columns.Add("Precio", 50)
        End With

        For i = 0 To lst_productos.Items.Count - 2 Step 2
            lst_productos.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_productos.Items(i).BackColor = Color.White
        Next

    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        cargar_producto(0)
    End Sub


    Private Sub guardar_producto(id_producto As Integer)
        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf


        If cb_categoria.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione una categoria" & vbCrLf
        End If
        If Trim(tb_codigo.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta codigo de barras " & vbCrLf
        End If
        If Trim(tb_nombre.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta nombre del producto " & vbCrLf
        End If

        If cb_unidad.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione una unidad de medida " & vbCrLf
        End If

        If cb_almacen.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un almacén " & vbCrLf
        End If

        If cb_impuesto.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un impuesto " & vbCrLf
        End If


        If Trim(tb_precio_compra.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta precio de compra " & vbCrLf
        End If

        If Trim(tb_precio_venta.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta precio de venta " & vbCrLf
        End If

        If Trim(tb_stock_minimo.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta stock minimo " & vbCrLf
        End If

        If Trim(tb_stock_maximo.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta stock máximo " & vbCrLf
        End If


        If Trim(cb_marca.Text.Length) = 0 Then
            correcto = False
            mensaje &= "    Falta marca " & vbCrLf
        End If

        If Trim(cb_modelo.Text.Length) = 0 Then
            correcto = False
            mensaje &= "    Falta modelo " & vbCrLf
        End If

        If Trim(cb_talla.Text.Length) = 0 Then
            correcto = False
            mensaje &= "    Falta talla " & vbCrLf
        End If

        If Trim(cb_color.Text.Length) = 0 Then
            correcto = False
            mensaje &= "    Falta color " & vbCrLf
        End If
        If Trim(cb_clavesat.Text.Length) = 0 Then
            correcto = False
            mensaje &= "    Falta clave producto/servicio SAT " & vbCrLf
        End If


        If correcto = True Then
            Dim id_marca As Integer = 0
            Dim id_talla As Integer = 0
            Dim id_modelo As Integer = 0
            Dim id_color As Integer = 0
            Dim id_clavesat As Integer = 0


            If cb_marca.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO producto_marca (nombre) VALUES ('" & cb_marca.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_marca = rs.Fields(0).Value
                rs.Close()
            Else
                id_marca = CType(cb_marca.SelectedItem, myItem).Value
            End If

            If cb_talla.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO producto_talla (nombre) VALUES ('" & cb_talla.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_talla = rs.Fields(0).Value
                rs.Close()
            Else
                id_talla = CType(cb_talla.SelectedItem, myItem).Value
            End If

            If cb_modelo.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO producto_modelo (nombre) VALUES ('" & cb_modelo.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_modelo = rs.Fields(0).Value
                rs.Close()
            Else
                id_modelo = CType(cb_modelo.SelectedItem, myItem).Value
            End If

            If cb_color.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO producto_color (nombre) VALUES ('" & cb_color.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_color = rs.Fields(0).Value
                rs.Close()
            Else
                id_color = CType(cb_color.SelectedItem, myItem).Value
            End If

            If cb_clavesat.SelectedIndex = -1 Then
                conn.Execute("INSERT INTO producto_clavesat (clave) VALUES ('" & cb_clavesat.Text.ToUpper & "')")
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_clavesat = rs.Fields(0).Value
                rs.Close()
            Else
                id_clavesat = CType(cb_clavesat.SelectedItem, myItem).Value
            End If

            If id_producto > 0 Then


                '---ACTUALIZACION DEL PRODUCTO
                Dim rs2 As New ADODB.Recordset

                rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
                rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
                rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
                rs2.ActiveConnection = conn
                rs2.Open("SELECT * FROM producto WHERE id_producto=" & id_producto)
                If rs2.RecordCount <> 0 Then
                    rs2.MoveFirst()
                End If
                'rs2.AddNew()
                rs2.Fields("nombre").Value = tb_nombre.Text
                rs2.Fields("codigo").Value = tb_codigo.Text
                rs2.Fields("id_unidad").Value = CType(cb_unidad.SelectedItem, myItem).Value
                rs2.Fields("venta_peso").Value = chb_venta_peso.CheckState
                rs2.Fields("id_categoria").Value = CType(cb_categoria.SelectedItem, myItem).Value
                rs2.Fields("id_impuesto").Value = CType(cb_impuesto.SelectedItem, myItem).Value
                rs2.Fields("descripcion").Value = tb_descripcion.Text
                rs2.Fields("costo").Value = CDec(tb_precio_compra.Text)
                rs2.Fields("precio").Value = CDec(tb_precio_venta.Text)
                rs2.Fields("id_talla").Value = id_talla
                rs2.Fields("id_color").Value = id_color
                rs2.Fields("id_marca").Value = id_marca
                rs2.Fields("id_modelo").Value = id_modelo
                rs2.Fields("id_almacen").Value = CType(cb_almacen.SelectedItem, myItem).Value
                rs2.Fields("precio_especial").Value = CDec(tb_especial.Text)
                rs2.Fields("id_clavesat").Value = id_clavesat
                rs2.Fields("precio_especial_inicio").Value = Format(dtp_inicial_oferta.Value, "yyyy-MM-dd")
                rs2.Fields("precio_especial_termino").Value = Format(dtp_final_oferta.Value, "yyyy-MM-dd")


                If bandera_imagen = True Then
                    rs2.Fields("imagen").Value = Imagen_Bytes(pb_imagen.BackgroundImage.GetThumbnailImage(250, pb_imagen.BackgroundImage.Height / (pb_imagen.BackgroundImage.Width / 250), Nothing, New IntPtr))
                    rs2.Fields("thumb").Value = Imagen_Bytes(pb_imagen.BackgroundImage.GetThumbnailImage(60, 60, Nothing, New IntPtr))
                End If
                'rs2.Fields("fecha_alta").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Fields("fecha_modificacion").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")


                rs2.Update()
                rs2.Close()
                '-----------------
                conn.Execute("UPDATE producto_sucursal SET cantidad_minima='" & tb_stock_minimo.Text & "',cantidad_maxima='" & tb_stock_minimo.Text & "' WHERE id_producto=" & id_producto)

                '=============== =AGREGAMOS PRODUCTOS DE PAQUETES================================
                If bandera_paquete = True Then

                    conn.Execute("DELETE FROM producto_modificador WHERE id_producto=" & id_producto)
                    conn.Execute("DELETE FROM paquete_modificador_producto WHERE id_paquete=" & id_producto)
                    If dgv_productos_modificadores.RowCount > 0 Then
                        conn.Execute("UPDATE producto SET paquete='1' WHERE id_producto=" & id_producto)
                        For x = 0 To dgv_modificadores.RowCount - 1
                            conn.Execute("INSERT INTO producto_modificador(id_producto,id_modificador) VALUES('" & id_producto & "','" & dgv_modificadores.Rows(x).Cells("id_modificador").Value & "')")
                        Next
                        For x = 0 To dgv_productos_modificadores.RowCount - 1
                            conn.Execute("INSERT INTO paquete_modificador_producto(id_paquete,id_modificador,id_producto,cantidad) VALUES('" & id_producto & "','" & dgv_productos_modificadores.Rows(x).Cells("id_modificador").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("id_producto").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("cantidad").Value & "')")
                        Next
                    End If

                End If
                '===========================================================

                If bandera_costo = True Then
                    conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES ('" & id_producto & "','" & CDec(tb_precio_compra.Text) & "',NOW())")
                End If

                '=======================AGREGAMOS PRECIO PRODUCTOS

                '================AGREGAMOS MODIFICADORES================================
                If dgv_precios.RowCount > 0 Then
                    For w = 0 To tabla_precios.Rows.Count - 1
                        conn.Execute("UPDATE producto_precio SET utilidad='" & dgv_precios.Rows(w).Cells("utilidad").Value & "',precio='" & dgv_precios.Rows(w).Cells("precio").Value & "' WHERE id_producto_precio='" & dgv_precios.Rows(w).Cells("id_producto_precio").Value & "'")
                    Next
                End If
                '============================================================================


                MsgBox("Producto actualizado correctamente", MsgBoxStyle.Information, "Aviso")
                configuracion_inicio()
                cargar_producto(id_producto)
            Else
                '==========NUEVO PRODUCTO=================

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
                rs2.Fields("nombre").Value = tb_nombre.Text
                rs2.Fields("codigo").Value = tb_codigo.Text
                rs2.Fields("id_unidad").Value = CType(cb_unidad.SelectedItem, myItem).Value
                rs2.Fields("venta_peso").Value = chb_venta_peso.CheckState
                rs2.Fields("id_categoria").Value = CType(cb_categoria.SelectedItem, myItem).Value
                rs2.Fields("descripcion").Value = tb_descripcion.Text
                rs2.Fields("costo").Value = CDec(tb_precio_compra.Text)
                rs2.Fields("precio").Value = CDec(tb_precio_venta.Text)
                rs2.Fields("id_marca").Value = id_marca
                rs2.Fields("id_impuesto").Value = CType(cb_impuesto.SelectedItem, myItem).Value
                rs2.Fields("id_modelo").Value = id_modelo
                rs2.Fields("id_talla").Value = id_talla
                rs2.Fields("id_color").Value = id_color
                rs2.Fields("id_almacen").Value = CType(cb_almacen.SelectedItem, myItem).Value
                rs2.Fields("precio_especial").Value = CDec(tb_especial.Text)
                rs2.Fields("id_clavesat").Value = id_clavesat
                rs2.Fields("precio_especial_inicio").Value = Format(dtp_inicial_oferta.Value, "yyyy-MM-dd")
                rs2.Fields("precio_especial_termino").Value = Format(dtp_final_oferta.Value, "yyyy-MM-dd")

                If bandera_imagen = True Then
                    rs2.Fields("imagen").Value = Imagen_Bytes(pb_imagen.BackgroundImage.GetThumbnailImage(250, pb_imagen.BackgroundImage.Height / (pb_imagen.BackgroundImage.Width / 250), Nothing, New IntPtr))
                    rs2.Fields("thumb").Value = Imagen_Bytes(pb_imagen.BackgroundImage.GetThumbnailImage(60, 60, Nothing, New IntPtr))
                End If
                rs2.Fields("fecha_alta").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Fields("fecha_modificacion").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                rs2.Update()
                rs2.Close()
                '-----------------
                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_producto = rs.Fields(0).Value
                rs.Close()

                conn.Execute("INSERT INTO  producto_sucursal (id_producto,id_sucursal,fecha_alta,id_almacen,cantidad_minima,cantidad_maxima) VALUES " & _
                             "('" & id_producto & "','" & global_id_sucursal & "', NOW(),'" & CType(cb_almacen.SelectedItem, myItem).Value & "','" & tb_stock_minimo.Text & "','" & tb_stock_maximo.Text & "')")

                conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES ('" & id_producto & "','" & CDec(tb_precio_compra.Text) & "',NOW())")

                '================AGREGAMOS MODIFICADORES================================
                If dgv_productos_modificadores.RowCount > 0 Then
                    conn.Execute("UPDATE producto SET paquete='1' WHERE id_producto=" & id_producto)
                    For x = 0 To dgv_modificadores.RowCount - 1
                        conn.Execute("INSERT INTO producto_modificador(id_producto,id_modificador) VALUES('" & id_producto & "','" & dgv_modificadores.Rows(x).Cells("id_modificador").Value & "')")
                    Next
                    For x = 0 To dgv_productos_modificadores.RowCount - 1
                        conn.Execute("INSERT INTO paquete_modificador_producto(id_paquete,id_modificador,id_producto,cantidad) VALUES('" & id_producto & "','" & dgv_productos_modificadores.Rows(x).Cells("id_modificador").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("id_producto").Value & "','" & dgv_productos_modificadores.Rows(x).Cells("cantidad").Value & "')")
                    Next
                End If
                '===============================================================================

                '=======================AGREGAMOS PRECIO PRODUCTOS
                For w = 0 To tabla_precios.Rows.Count - 1

                    conn.Execute("INSERT INTO producto_precio(id_producto,id_ctlg_precios,utilidad,precio)" & _
                                 " VALUES ('" & id_producto & "', '" & dgv_precios.Rows(w).Cells("id_ctlg_precios").Value & "', '" & dgv_precios.Rows(w).Cells("utilidad").Value & "', '" & dgv_precios.Rows(w).Cells("precio").Value & "')")
                Next
                '============================================================================
                configuracion_inicio()
                cargar_producto(id_producto)
                MsgBox("Producto agregado correctamente", MsgBoxStyle.Information, "Aviso")
                '----FIN GUARDAR NUEVO PRODUCTO--------------
            End If
            cargar_grupo_producto(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
        Else
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If
        gb_productos.Enabled = True
    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        guardar_producto(id_producto)
    End Sub

    Private Sub btn_deshacer_Click(sender As System.Object, e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Function propuesta_codigo(ByVal id_grupo As Integer) As String
        tb_codigo.Text = ""
        Dim codigo As String = ""
        Dim rw As New ADODB.Recordset
        Dim clave_grupo As String = ""


        rw.Open("SELECT clave FROM categoria WHERE id_categoria='" & id_grupo & "'", conn)
        If rw.RecordCount > 0 Then
            clave_grupo = rw.Fields("clave").Value
        End If
        rw.Close()


        rw.Open("SELECT CASE WHEN ISNULL(MAX(clave)) THEN 0 ELSE (MAX(clave)+1) END AS propuesta FROM categoria WHERE id_Categoria='" & id_grupo & "'", conn)
        If rw.RecordCount > 0 Then
            codigo = rw.Fields("propuesta").Value
        End If
        rw.Close()

        If codigo = "0" Then
            codigo = CDbl(clave_grupo) + 1
        End If

        Return codigo
    End Function
    Private Sub cb_grupo_busqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_categoria_busqueda.SelectedIndexChanged
        cargar_grupo_producto(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
        If cb_categoria_busqueda.SelectedIndex > 0 Then
            seleccionar_catalogo(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, cb_categoria)
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
    Private Sub cargar_grupo_producto(id_categoria As Integer, buscar As String, Optional pagina As Integer = 1)

        tb_pagina.Text = pagina
        inicial = (pagina - 1) * reg_por_pag

        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_productos.Items.Clear()
        If id_categoria > 0 Then
            filtro = "WHERE p.id_categoria='" & id_categoria & "'"
        End If

        If buscar.Length > 0 Then
            If id_categoria > 0 Then
                filtro = filtro & " AND p.nombre LIKE '%" & buscar & "%' OR p.codigo='" & buscar & "'"
            Else
                filtro = " WHERE p.nombre LIKE '%" & buscar & "%' OR p.codigo='" & buscar & "'"
            End If

        End If

        rs.Open("SELECT count(*) as total_productos FROM producto p " & filtro, conn)
        total_productos = rs.Fields("total_productos").Value
        rs.Close()

        total_paginas = Ceiling(total_productos / reg_por_pag)
        lb_total_paginas.Text = "/" & total_paginas

        rs.Open("SELECT p.id_producto,p.nombre, p.codigo,p.precio,u.nombre_corto AS unidad " & _
                "FROM producto p " & _
                "JOIN unidad u ON u.id_unidad=p.id_unidad " & filtro & " LIMIT " & inicial & "," & reg_por_pag, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("codigo").Value
                str(1) = rs.Fields("nombre").Value
                str(2) = rs.Fields("unidad").Value
                str(3) = FormatCurrency(rs.Fields("precio").Value, 2)

                lst_productos.Items.Add(New ListViewItem(str, 0))
                lst_productos.Items(i).Tag = rs.Fields("id_producto").Value
                rs.MoveNext()
                i = i + 1
            End While
           
        End If
        tb_resultados.Text = total_productos & " resultado(s)"
        lb_pagina_actual.Text = "Mostrando del " & inicial + 1 & " al " & rs.RecordCount + inicial
        rs.Close()

        aplicar_estilo_insumo()

    End Sub
    Private Sub aplicar_estilo_insumo()

        For i = 0 To lst_productos.Items.Count - 2 Step 2
            lst_productos.Items(i + 1).BackColor = Color.LightSteelBlue
            lst_productos.Items(i).BackColor = Color.White
        Next


    End Sub
    Private Sub cargar_producto(id As Integer)
        cargado = False
        id_producto = id

        If id_producto > 0 Then

            bandera_costo = False
            '=================MOSTRAR INFORMACION  PRODUCTO
            rs.Open("SELECT * " & _
                    "FROM producto " & _
                    "WHERE id_producto=" & id_producto, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                tb_nombre.Text = rs.Fields("nombre").Value
                tb_codigo.Text = rs.Fields("codigo").Value
                chb_venta_peso.CheckState = rs.Fields("venta_peso").Value
                seleccionar_catalogo(rs.Fields("id_categoria").Value, cb_categoria)
                seleccionar_catalogo(rs.Fields("id_impuesto").Value, cb_impuesto)
                seleccionar_catalogo(rs.Fields("id_marca").Value, cb_marca)
                seleccionar_catalogo(rs.Fields("id_talla").Value, cb_talla)
                seleccionar_catalogo(rs.Fields("id_color").Value, cb_color)
                seleccionar_catalogo(rs.Fields("id_modelo").Value, cb_modelo)
                seleccionar_catalogo(rs.Fields("id_unidad").Value, cb_unidad)
                seleccionar_catalogo(rs.Fields("id_clavesat").Value, cb_clavesat)
                tb_especial.Text = rs.Fields("precio_especial").Value
                dtp_inicial_oferta.Value = rs.Fields("precio_especial_inicio").Value
                dtp_inicial_oferta.Value = rs.Fields("precio_especial_termino").Value

                ' seleccionar_catalogo(rs.Fields("id_almacen").Value, cb_almacen)
                tb_precio_compra.Text = rs.Fields("costo").Value
                tb_precio_venta.Text = rs.Fields("precio").Value
                tb_descripcion.Text = rs.Fields("descripcion").Value
                Dim rs2 As New ADODB.Recordset
                If Not IsDBNull(rs.Fields("imagen").Value) Then
                    bDatos = CType(rs.Fields("imagen").Value, Byte())
                    pb_imagen.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
                Else
                    '---obtenemos la imagen---------------

                    pb_imagen.BackgroundImage = Global.ventas.My.Resources.Resources._50CENTAVOS

                    ofd_foto.Title = "Seleccionar imágen"
                    ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                    ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"

                    '--------------------------------------------
                End If
            End If
            rs.Close()

            rs.Open("SELECT cantidad_minima, cantidad_maxima " & _
              "FROM producto_sucursal " & _
              "WHERE id_producto='" & id_producto & "' AND id_sucursal='" & global_id_sucursal & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If rs.RecordCount > 0 Then
                tb_stock_minimo.Text = rs.Fields("cantidad_minima").Value
                tb_stock_maximo.Text = rs.Fields("cantidad_maxima").Value
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


            '===AGREGAMOS LOS PRECIOS DE LOS PRODUCTOS==============================
            tabla_precios.Clear()
            rs.Open("SELECT pp.id_producto_precio,pp.utilidad,pp.precio,cp.nombre AS nombre_precio,cp.id_ctlg_precios FROM producto_precio pp " & _
                    "JOIN ctlg_precios cp ON cp.id_ctlg_precios=pp.id_ctlg_precios " & _
                    "WHERE pp.id_producto='" & id_producto & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_producto_precio(rs.Fields("id_producto_precio").Value, rs.Fields("id_ctlg_precios").Value, rs.Fields("nombre_precio").Value, rs.Fields("utilidad").Value, rs.Fields("precio").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            '=================================================

            '=================FIN MOSTRAR INFORMACION

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
        Else
            '=============================PRODUCTO NUEVO===================================
            configuracion_nuevo()

            '---obtenemos la imagen---------------
            rs.Open("SELECT imagen FROM configuracion", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            If Not rs.EOF Then
                bDatos = CType(rs.Fields("imagen").Value, Byte())
                pb_imagen.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
            End If
            ofd_foto.Title = "Seleccionar imágen"
            ofd_foto.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            ofd_foto.Filter = "Archivos de imágen(*.jpg)|*.jpg"
            rs.Close()
            '--------------------------------------------
            '=============AGREGAMOS PRECIOS=================
            tabla_precios.Clear()
            rs.Open("SELECT id_ctlg_precios,nombre,utilidad FROM ctlg_precios", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    agregar_tabla_producto_precio(0, rs.Fields("id_ctlg_precios").Value, rs.Fields("nombre").Value, rs.Fields("utilidad").Value, 0)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            '=================================================



            If cb_categoria.SelectedIndex <> -1 Then
                If id_producto = 0 Then
                    tb_codigo.Text = propuesta_codigo(CType(cb_categoria.SelectedItem, myItem).Value)
                End If

            End If
        End If
        cargado = True
    End Sub
    Private Sub lst_insumos_DoubleClick(sender As Object, e As System.EventArgs) Handles lst_productos.DoubleClick
        If lst_productos.SelectedItems.Count > 0 Then
            cargar_producto(lst_productos.SelectedItems.Item(0).Tag)
        End If
    End Sub
    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_producto(id_producto)
    End Sub
    Private Sub eliminar_producto(id As Integer)
        '  Try
        If MsgBox("¿Esta seguro que desea borrar este producto?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If existen_turnos_abiertos() = False Then
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
                cargar()
                MsgBox("El producto ha sido eliminado correctamente", MsgBoxStyle.Information, "Aviso")
                configuracion_inicio()
            Else
                MsgBox("Se encontro turno(s) abierto(s), para realizar esta operacion, todos los usuarios deben realizar corte de caja!", MsgBoxStyle.Exclamation, "aviso")
            End If

        End If
        ' Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        ' End Try

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

    Private Sub btn_editar_Click(sender As System.Object, e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
    Public Sub cargar_insumo(id As Integer, insumo As String, unidad As String)
        '  id_insumo = id
        'tb_insumo_base.Text = insumo
        ' tb_unidad_rendimiento.Text = unidad
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
        frm_directorio.Show()
    End Sub
    Private Sub tb_ultimo_costo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        '   e.Handled = txtNumerico(tb_ultimo_costo, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_promedio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        '   e.Handled = txtNumerico(tb_costo_promedio, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_estandar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        '    e.Handled = txtNumerico(tb_costo_estandar, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_impuesto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        '    e.Handled = txtNumerico(tb_costo_impuesto, e.KeyChar, True)
    End Sub
    Private Function calcular_costo(costo_impuesto As Decimal, id_impuesto As Integer) As Decimal
        '  Try
        Dim costo As Decimal = 0
        Dim porcentaje As Decimal = 0

        Dim rw As New ADODB.Recordset
        rw.Open("SELECT porcentaje FROM impuesto WHERE id_impuesto='" & id_impuesto & "'", conn)
        If rw.RecordCount > 0 Then
            porcentaje = rw.Fields("porcentaje").Value
        End If
        rw.Close()

        costo = FormatNumber(costo_impuesto / (1 + (porcentaje / 100)), 2)
        Return costo
        ' Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error interno")
        ' End Try


    End Function

    Private Sub tb_costo_impuesto_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        '    If Trim(tb_costo_impuesto.Text) = "" Then
        'tb_ultimo_costo.Text = "0.00"
        '   Else
        'Dim costo As Decimal = calcular_costo(tb_costo_impuesto.Text, CType(cb_impuesto.SelectedItem, myItem).Value)
        ' tb_ultimo_costo.Text = costo
        ' End If
    End Sub
    Private Sub btn_agregar_imagen_Click(sender As System.Object, e As System.EventArgs) Handles btn_agregar_imagen.Click
        ofd_foto.ShowDialog()
    End Sub
    Private Sub ofd_foto_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofd_foto.FileOk
        bandera_imagen = False
        Dim File As New System.IO.FileInfo(ofd_foto.FileName)
        If ofd_foto.FileName <> "" Then
            pb_imagen.BackgroundImage = New Bitmap(ofd_foto.FileName)
            bandera_imagen = True
        End If
    End Sub
    Public Sub _agregar_modificador(ByVal id_modificador As Integer, ByVal nombre As String)
        agregar_modificador(id_modificador, nombre)
        btn_eliminar_modificador.Enabled = True
        bandera_paquete = True
    End Sub

    Private Sub btn_agregar_modificador_Click(sender As System.Object, e As System.EventArgs) Handles btn_agregar_modificador.Click
        frm_modificadores.Show()
    End Sub

    Private Sub btn_eliminar_modificador_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar_modificador.Click
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

    Private Sub btn_agregar_prdct_modificador_Click(sender As System.Object, e As System.EventArgs) Handles btn_agregar_prdct_modificador.Click
        frm_busqueda_insumo.Show()
    End Sub

    Private Sub btn_eliminar_prdct_modificador_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar_prdct_modificador.Click
        dgv_productos_modificadores.Rows.RemoveAt(dgv_productos_modificadores.CurrentRow.Index)
        If dgv_productos_modificadores.Rows.Count = 0 Then
            btn_eliminar_prdct_modificador.Enabled = False
        Else
            btn_eliminar_prdct_modificador.Enabled = True
        End If
        bandera_paquete = True
    End Sub

    Private Sub lst_productos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lst_productos.SelectedIndexChanged
        If cargado = True Then
            If cb_categoria.SelectedIndex <> -1 Then
                If id_producto = 0 Then
                    tb_codigo.Text = propuesta_codigo(CType(cb_categoria.SelectedItem, myItem).Value)
                End If
            End If
        End If
    End Sub
    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs) Handles btn_buscar.Click
        cargar_grupo_producto(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, tb_buscar.Text)
    End Sub

    Private Sub tb_precio_compra_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_precio_compra.KeyPress
        bandera_costo = True
        e.Handled = txtNumerico(tb_precio_compra, e.KeyChar, True)
    End Sub
    Private Sub tb_precio_compra_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_precio_compra.TextChanged
        If Trim(tb_precio_compra.TextLength) > 0 Then
            If cargado = True Then
                actualizar_catalogo_precios(tb_precio_compra.Text)
            End If
        End If

    End Sub
    Private Sub actualizar_catalogo_precios(precio_compra As Decimal)
        If tabla_precios.Rows.Count > 0 Then
            For x = 0 To dgv_precios.RowCount - 1
                Dim utilidad As Decimal = dgv_precios.Rows(x).Cells("utilidad").Value / 100
                dgv_precios.Rows(x).Cells("precio").Value = precio_compra * (1 + utilidad)
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        frm_categorias.Show()
        frm_categorias.BringToFront()
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        frm_colaboradores.Show()
        frm_colaboradores.BringToFront()
    End Sub

    Private Sub pb_anterior_Click(sender As System.Object, e As System.EventArgs) Handles pb_anterior.Click
        If tb_pagina.Text > 1 Then
            tb_pagina.Text = CInt(tb_pagina.Text) - 1
            cargar_grupo_producto(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub pb_siguiente_Click(sender As System.Object, e As System.EventArgs) Handles pb_siguiente.Click
        If tb_pagina.Text < total_paginas Then
            tb_pagina.Text = CInt(tb_pagina.Text) + 1
            cargar_grupo_producto(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
        End If
    End Sub

    Private Sub tb_pagina_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_pagina.TextChanged
        If Trim(tb_pagina.Text) <> "" Then
            If tb_pagina.Text > 0 And tb_pagina.Text <= total_paginas Then
                cargar_grupo_producto(CType(cb_categoria_busqueda.SelectedItem, myItem).Value, tb_buscar.Text, tb_pagina.Text)
            End If
        End If
    End Sub

    Private Sub tb_precio_venta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_precio_venta.KeyPress
        e.Handled = txtNumerico(tb_precio_venta, e.KeyChar, True)
    End Sub

    Private Sub tb_precio_venta_TextChanged(sender As System.Object, e As System.EventArgs) Handles tb_precio_venta.TextChanged

    End Sub
End Class