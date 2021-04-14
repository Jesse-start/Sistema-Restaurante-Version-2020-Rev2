Public Class frm_conversiones
    Private producto_origen_inventario As Boolean ' indica si existe algun registro del producto en el inventario con el almacen indicado
    Private producto_destino_inventario As Boolean
    Private existe_registro_paquete As Boolean
    Private cporigen As Decimal ' cantidad_producto_origen
    Private cpdestino As Decimal ' cantidad_producto_destino
    Private iporigen As Decimal 'inventario_producto_origen
    Private ipdestino As Decimal ''inventario_producto_destino
    Private id_producto_origen As Integer
    Private id_producto_destino As Integer
    Private tabla As DataTable
    Private Linea As DataRow
    Dim cargado As Boolean
    Private cantidad_destino_permitida As Decimal
    Private Sub aplicar_colores()
        Me.BackColor = Color.FromArgb(conf_colores(1))
        Label2.ForeColor = Color.FromArgb(conf_colores(13))
        gb_conversion.ForeColor = Color.FromArgb(conf_colores(2))
        gb_paquetes.ForeColor = Color.FromArgb(conf_colores(2))
        TabPage1.BackColor = Color.FromArgb(conf_colores(1))
        TabPage2.BackColor = Color.FromArgb(conf_colores(1))
        'lbl_cantidad_destino.ForeColor = Color.FromArgb(conf_colores(13))
        'lbl_cantidad_origen.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_existencia_destino.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_existencia_origen.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_paquete_cantidad.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_paquete_existencias.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_paquete_nombre.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_producto_destino.ForeColor = Color.FromArgb(conf_colores(13))
        lbl_producto_origen.ForeColor = Color.FromArgb(conf_colores(13))

        btn_convertir.BackColor = Color.FromArgb(conf_colores(8))
        btn_convertir.ForeColor = Color.FromArgb(conf_colores(9))

        btn_generar_paquetes.BackColor = Color.FromArgb(conf_colores(8))
        btn_generar_paquetes.ForeColor = Color.FromArgb(conf_colores(9))


        Button1.BackColor = Color.FromArgb(conf_colores(8))
        Button1.ForeColor = Color.FromArgb(conf_colores(9))

        Button2.BackColor = Color.FromArgb(conf_colores(8))
        Button2.ForeColor = Color.FromArgb(conf_colores(9))

        btn_salir.BackColor = Color.FromArgb(conf_colores(8))
        btn_salir.ForeColor = Color.FromArgb(conf_colores(9))

        dg_paquetes.CaptionBackColor = Color.FromArgb(conf_colores(8))
        dg_paquetes.CaptionForeColor = Color.FromArgb(conf_colores(9))

    End Sub
    Private Sub frm_conversiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        aplicar_colores()
        llenar_almacenes()
        paquete_productos("Productos del paquete", dg_paquetes, tabla)
        gb_conversion.Enabled = False
        gb_paquetes.Enabled = False
        confinicio()
        conf_inicio_paquetes()
        cargado = True
    End Sub
    Private Sub llenar_almacenes()
        cb_almacenes.Items.Clear()
        cb_almacenes.Text = ""
        'Conectar()
        rs.Open("SELECT * FROM almacenes Order By nombre", conn)

        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_almacenes.Items.Add(New myItem(rs.Fields("id_almacen").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If


        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
    Private Sub confinicio()
        'gb_conversion.Enabled = False
        tb_cantidad_origen.Text = ""
        tb_cantidad_destino.Text = ""
        lbl_producto_origen.Text = ""
        lbl_producto_destino.Text = ""
        lbl_existencia_origen.Text = ""
        lbl_existencia_destino.Text = ""
        cb_producto.Text = ""
        pb_producto_origen.BackgroundImage = Nothing
        pb_producto_destino.BackgroundImage = Nothing
        cpdestino = 0
        cporigen = 0
        iporigen = 0
        ipdestino = 0
        producto_origen_inventario = False
        producto_destino_inventario = False
        existe_registro_paquete = False

        id_producto_origen = 0
        id_producto_destino = 0
    End Sub
    Private Sub cb_almacenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_almacenes.SelectedIndexChanged
        If cb_almacenes.SelectedIndex <> -1 Then
            cargado = False
            confinicio()
            conf_inicio_paquetes()
            gb_conversion.Enabled = True
            gb_paquetes.Enabled = True
            cargar_productos_disponibles(CType(cb_almacenes.SelectedItem, myItem).Value)
            cargar_paquetes_disponibles()
            cargado = True
        End If
    End Sub
    Private Sub cargar_paquetes_disponibles()
        cb_paquete.Items.Clear()
        cb_paquete.Text = ""
        'Conectar()
        rs.Open("SELECT producto.id_producto,producto.nombre FROM producto_paquete JOIN producto ON producto.id_producto=producto_paquete.id_producto ORDER by producto.nombre", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_paquete.Items.Add(New myItem(rs.Fields("id_producto").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
    End Sub
    Private Sub cargar_productos_disponibles(ByVal id_almacen As Integer)
        cb_producto.Items.Clear()
        cb_producto.Text = ""
        'Conectar()
        rs.Open("SELECT producto_equivalente.id_producto_equivalente,producto.id_producto,CONCAT(producto.nombre) As nombre FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad JOIN producto_equivalente ON producto_equivalente.id_producto_origen=producto.id_producto JOIN producto_sucursal ON producto_sucursal.id_producto=producto_equivalente.id_producto_origen WHERE producto_sucursal.id_almacen=" & id_almacen, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_producto.Items.Add(New myItem(rs.Fields("id_producto_equivalente").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()

    End Sub
    Private Sub obtener_detalle(ByVal id_conversion As Integer)
        producto_destino_inventario = True
        producto_destino_inventario = True
        Dim bDatos() As Byte
        'Conectar()
        rs.Open("SELECT	pe.id_producto_origen,pe.cantidad_origen,p.nombre as nombre_origen,p.descripcion as descripcion_origen,p.thumb as miniatura_origen ,pe.id_producto_destino,pe.cantidad_destino,h.nombre as nombre_destino,h.descripcion as descripcion_destino,h.thumb as miniatura_destino " & _
                "FROM producto p, producto h, producto_equivalente pe " & _
                "WHERE p.id_producto = pe.id_producto_origen AND pe.id_producto_destino = h.id_producto AND pe.id_producto_equivalente=" & id_conversion, conn)
        If rs.RecordCount > 0 Then
            ' tb_cantidad_origen.Text = rs.Fields("cantidad_origen").Value
            cporigen = rs.Fields("cantidad_origen").Value
            lbl_producto_origen.Text = rs.Fields("nombre_origen").Value
            tb_cantidad_destino.Text = rs.Fields("cantidad_destino").Value
            cpdestino = rs.Fields("cantidad_destino").Value
            lbl_producto_destino.Text = rs.Fields("nombre_destino").Value
            id_producto_origen = rs.Fields("id_producto_origen").Value
            id_producto_destino = rs.Fields("id_producto_destino").Value

            If Not IsDBNull(rs.Fields("miniatura_origen").Value) Then
                bDatos = CType(rs.Fields("miniatura_origen").Value, Byte())
                pb_producto_origen.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
            Else
                pb_producto_origen.BackgroundImage = ventas.My.Resources._50CENTAVOS
                'pb_producto_origen.BackgroundImageLayout
            End If
            If Not IsDBNull(rs.Fields("miniatura_destino").Value) Then
                bDatos = CType(rs.Fields("miniatura_destino").Value, Byte())
                pb_producto_destino.BackgroundImage = New Bitmap(Bytes_Imagen(bDatos))
            Else
                pb_producto_destino.BackgroundImage = ventas.My.Resources._50CENTAVOS
            End If
        End If


        '=====obtenemos las existencias en almacen=======================0
        Dim rs2 As New ADODB.Recordset
        rs2.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & rs.Fields("id_producto_origen").Value & "' AND id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value, conn)
        If rs2.RecordCount > 0 Then
            lbl_existencia_origen.Text = rs2.Fields("cantidad").Value & " unidades en almacen"
            iporigen = rs2.Fields("cantidad").Value
        Else
            lbl_existencia_origen.Text = "0 unidades en almacen"
            iporigen = 0
            producto_origen_inventario = False
        End If
        rs2.Close()
        rs2.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & rs.Fields("id_producto_destino").Value & "' AND id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value, conn)
        If rs2.RecordCount > 0 Then
            lbl_existencia_destino.Text = rs2.Fields("cantidad").Value & " unidades en almacen"
            ipdestino = rs2.Fields("cantidad").Value
        Else
            lbl_existencia_destino.Text = "0 unidades en almacen"
            ipdestino = 0
            producto_destino_inventario = False
        End If
        rs2.Close()

        tb_cantidad_origen.Text = rs.Fields("cantidad_origen").Value
        rs.Close()

        btn_convertir.Enabled = True

    End Sub
    Private Sub obtener_detalle_paquete(ByVal id_producto As Integer)
        existe_registro_paquete = True
        Dim imagen_paquete As System.Drawing.Image = Nothing
        'Conectar()
        rs.Open("SELECT thumb,nombre from producto WHERE id_producto=" & id_producto, conn)
        If rs.RecordCount > 0 Then
            imagen_paquete = obtener_miniatura(rs.Fields("thumb").Value, 1)
            lbl_paquete_nombre.Text = rs.Fields("nombre").Value
        End If
        rs.Close()

        pb_paquete.Image = imagen_paquete
        lbl_paquete_cantidad.Text = 1

        rs.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & id_producto & "' AND id_almacen=" & CType(cb_almacenes.SelectedItem, myItem).Value, conn)
        If rs.RecordCount > 0 Then
            lbl_paquete_existencias.Text = rs.Fields("cantidad").Value & " unidades en almacen"
        Else
            lbl_paquete_existencias.Text = "0 unidades en almacen"
            existe_registro_paquete = False
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '--obtenemos los productos del kit
        tabla.Clear()
        'Conectar()
        Dim rs2 As New ADODB.Recordset
        rs2.Open("SELECT producto_compuesto.id_articulo,producto_compuesto.num_articulo, producto.nombre FROM producto_compuesto JOIN producto ON producto.id_producto=producto_compuesto.id_articulo WHERE producto_compuesto.id_producto=" & id_producto, conn)
        If rs2.RecordCount > 0 Then
            While Not rs2.EOF
                Linea = tabla.NewRow()
                Linea(0) = rs2.Fields("id_articulo").Value
                Linea(1) = rs2.Fields("nombre").Value
                Linea(2) = rs2.Fields("num_articulo").Value
                Linea(3) = validar_existencia_producto(rs2.Fields("id_articulo").Value, CType(cb_almacenes.SelectedItem, myItem).Value, 1)
                Linea(4) = rs2.Fields("num_articulo").Value
                tabla.Rows.Add(Linea)
                rs2.MoveNext()
            End While
        End If
        rs2.Close()
        'conn.close()
        'conn = Nothing
        '------------------------------

    End Sub

    Private Sub cb_producto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_producto.SelectedIndexChanged
        cargado = False
        If cb_producto.SelectedIndex <> -1 Then
            obtener_detalle(CType(cb_producto.SelectedItem, myItem).Value)
        End If
        cargado = True
    End Sub
    Private Sub btn_convertir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_convertir.Click

        Dim correcto As Boolean = True
        Dim cadena As String = "Se encontraron los siguientes errores:" & vbCrLf

        If Trim(tb_cantidad_origen.Text) = "" Then
            cadena &= "   *La cantidad de origen no es correcta." & vbCrLf
            correcto = False
        End If

        If Trim(tb_cantidad_destino.Text) = "" Then
            cadena &= "   *La cantidad de origen no es correcta." & vbCrLf
            correcto = False
        End If
        If correcto = True Then
            If tb_cantidad_origen.Text <= iporigen Then
                If CDec(tb_cantidad_destino.Text) = cantidad_destino_permitida Then
                    aplicar_conversion()
                Else
                    frm_validacion.validacion = 7
                    frm_validacion.Show()
                End If
            Else
                MsgBox("No se puede convertir, no existe la cantidad solicitada en el inventario del producto origen", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Else
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Aviso")
        End If


    End Sub
    Public Sub aplicar_conversion()
        If MsgBox("Confirme la conversión de " & tb_cantidad_origen.Text & " " & lbl_producto_origen.Text & " a " & tb_cantidad_destino.Text & " " & lbl_producto_destino.Text & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            '--actualizamos el inventario del producto de origen
            'Conectar()
            conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & CDbl(tb_cantidad_origen.Text) & ") WHERE id_almacen='" & CType(cb_almacenes.SelectedItem, myItem).Value & "' AND id_producto=" & id_producto_origen)
            '-actualizamos el inventario del producto destino
            If producto_destino_inventario = True Then
                conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & CDbl(tb_cantidad_destino.Text) & ") WHERE id_almacen='" & CType(cb_almacenes.SelectedItem, myItem).Value & "' AND id_producto=" & id_producto_destino)
            Else
                conn.Execute("INSERT INTO producto_sucursal(id_precio,id_producto,id_sucursal,id_almacen,cantidad,fecha_alta,precio_especial_inicio,precio_especial_termino,cantidad_minima,cantidad_maxima) (SELECT id_precio,id_producto,id_sucursal," & CType(cb_almacenes.SelectedItem, myItem).Value & "," & CDbl(tb_cantidad_destino.Text) & ",fecha_alta,precio_especial_inicio,precio_especial_termino,cantidad_minima,cantidad_maxima FROM producto_sucursal WHERE id_producto='" & id_producto_destino & "' LIMIT 1)")
            End If
            'conn.close()
            'conn = Nothing
            'confinicio()
            obtener_detalle(CType(cb_producto.SelectedItem, myItem).Value)
            MsgBox("Conversión realizada correctamente")
        End If
    End Sub
    Private Sub cb_paquete_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_paquete.SelectedIndexChanged
        If cb_paquete.SelectedIndex <> -1 Then
            conf_inicio_paquetes()
            obtener_detalle_paquete(CType(cb_paquete.SelectedItem, myItem).Value)

        End If
    End Sub
    Private Sub conf_inicio_paquetes()
        cb_paquete_cantidad.Value = 0
        btn_generar_paquetes.Enabled = False
        cb_paquete.Text = ""
        lbl_paquete_cantidad.Text = ""
        lbl_paquete_existencias.Text = ""
        lbl_paquete_nombre.Text = ""
        tabla.Clear()
    End Sub
    Private Sub cb_paquete_cantidad_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_paquete_cantidad.ValueChanged
        Dim correcto As Boolean = True
        If cb_paquete.SelectedIndex <> -1 Then
            If Trim(cb_paquete_cantidad.Value) <> 0 Then
                lbl_paquete_cantidad.Text = cb_paquete_cantidad.Value
                For x = 0 To tabla.Rows.Count - 1
                    dg_paquetes.Item(x, 2) = CDec(dg_paquetes.Item(x, 4)) * cb_paquete_cantidad.Value
                    If dg_paquetes.Item(x, 2) > dg_paquetes.Item(x, 3) Then
                        correcto = False
                    End If
                Next

                If correcto Then
                    btn_generar_paquetes.Enabled = True
                Else
                    btn_generar_paquetes.Enabled = False
                End If
                'lbl_cantidad_origen.Text = CDbl(tb_cantidad.Value) * CDbl(cporigen)
                'lbl_cantidad_destino.Text = CDbl(cpdestino) * CDbl(lbl_cantidad_origen.Text)
                ' If CDbl(lbl_cantidad_origen.Text) <= iporigen Then
                'btn_convertir.Enabled = True
                'Else
                '    btn_convertir.Enabled = False
                ' End If
            Else
                btn_generar_paquetes.Enabled = False
            End If
        End If
    End Sub

    Private Sub btn_generar_paquetes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generar_paquetes.Click
        Dim correcto As Boolean = True
        If MsgBox("Confirme creacion  de " & lbl_paquete_cantidad.Text & " " & lbl_paquete_nombre.Text & "", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            For x = 0 To tabla.Rows.Count - 1
                If dg_paquetes.Item(x, 2) > validar_existencia_producto(dg_paquetes.Item(x, 0), CType(cb_almacenes.SelectedItem, myItem).Value, 1) Then
                    correcto = False
                End If
            Next
            If correcto Then
                '--agregamos/actualizamos paquete
                If existe_registro_paquete = True Then
                    conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad + " & CDec(lbl_paquete_cantidad.Text) & ") WHERE id_almacen='" & CType(cb_almacenes.SelectedItem, myItem).Value & "' AND id_producto=" & CType(cb_paquete.SelectedItem, myItem).Value)
                Else
                    conn.Execute("INSERT INTO producto_sucursal (id_precio,id_producto,id_sucursal,id_almacen,cantidad,fecha_alta,precio_especial_inicio,precio_especial_termino,cantidad_minima,cantidad_maxima) (SELECT id_precio,id_producto,id_sucursal," & CType(cb_almacenes.SelectedItem, myItem).Value & "," & CDec(lbl_paquete_cantidad.Text) & ",fecha_alta,precio_especial_inicio,precio_especial_termino,cantidad_minima,cantidad_maxima FROM producto_sucursal WHERE id_producto='" & CType(cb_paquete.SelectedItem, myItem).Value & "' LIMIT 1)")
                End If
                '-------------------------------
                ' actualizamos lista de productos que componen el paquete
                For x = 0 To tabla.Rows.Count - 1
                    conn.Execute("UPDATE producto_sucursal  SET cantidad=(cantidad - " & CDec(dg_paquetes.Item(x, 2)) & ") WHERE id_almacen='" & CType(cb_almacenes.SelectedItem, myItem).Value & "' AND id_producto=" & dg_paquetes.Item(x, 0))
                Next
                '--------------------------------

            End If
            'conn.close()
            'conn = Nothing
            If correcto = False Then
                MsgBox("Se ha cancelado la operacion. Es posible que el inventario ha sido modificado mientras realizaba ajustes de conversiones.Intentelo nuevamente.")
            End If
            conf_inicio_paquetes()
            obtener_detalle_paquete(CType(cb_paquete.SelectedItem, myItem).Value)
            MsgBox("Se han creado los paquetes correctamente")
        End If
    End Sub

    Private Sub dg_paquetes_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles dg_paquetes.Navigate

    End Sub

    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tb_cantidad.Value < tb_cantidad.Maximum Then
            tb_cantidad.Value += 1
        End If

    End Sub

    Private Sub btn_down_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If tb_cantidad.Value > tb_cantidad.Minimum Then
            tb_cantidad.Value -= 1
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cb_paquete_cantidad.Value < cb_paquete_cantidad.Maximum Then
            cb_paquete_cantidad.Value += 1
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cb_paquete_cantidad.Value > cb_paquete_cantidad.Minimum Then
            cb_paquete_cantidad.Value -= 1
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub tb_cantidad_origen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cantidad_origen.KeyPress
        e.Handled = txtNumerico(tb_cantidad_origen, e.KeyChar, True)
    End Sub

    Private Sub tb_cantidad_origen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cantidad_origen.TextChanged
        If cargado = True Then
            
            If Trim(tb_cantidad_origen.Text) <> "" Then
                If tb_cantidad_origen.Text = "0" Then
                    btn_convertir.Enabled = False
                Else
                    btn_convertir.Enabled = True
                End If

                If tb_cantidad_origen.Text > iporigen Then
                    MsgBox("La cantidad no puede ser mayor a " & iporigen, MsgBoxStyle.Exclamation, "Aviso")
                    tb_cantidad_origen.Text = cporigen
                Else
                    calcular_cantidad_destino(tb_cantidad_origen.Text)
                End If
            End If
        End If
    End Sub
    Private Sub calcular_cantidad_destino(ByVal cantidad_origen As Decimal)
        cantidad_destino_permitida = 0
        tb_cantidad_destino.Text = (cantidad_origen * cpdestino) / cporigen
        cantidad_destino_permitida = (cantidad_origen * cpdestino) / cporigen
    End Sub
    Private Function tb_cantidad() As Object
        Throw New NotImplementedException
    End Function

    Private Sub tb_cantidad_destino_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tb_cantidad_destino.KeyPress
        e.Handled = txtNumerico(tb_cantidad_destino, e.KeyChar, True)
    End Sub
    Private Sub tb_cantidad_destino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_cantidad_destino.TextChanged
        If Trim(tb_cantidad_destino.TextLength) > 0 Then
            If tb_cantidad_destino.Text = "0" Then
                btn_convertir.Enabled = False
            End If
        End If
    End Sub
End Class