Imports System.Drawing.Text
Public Class frm_configuracion_empresa
    Dim bandera_Insertada, bandera As Boolean
    Dim id_diseño As Integer = 0
    Dim current_id_cfg_facturacion_serie As Integer
    Private Sub cargar_catalogo_impresoras()
        Dim i As Integer
        With Printing.PrinterSettings.InstalledPrinters
            For i = 0 To .Count - 1
                cb_impresora_caja.Items.Add(New myItem(i, .Item(i)))
                cb_impresora_pedidos.Items.Add(New myItem(i, .Item(i)))
                cb_impresora_almacen.Items.Add(New myItem(i, .Item(i)))
            Next
        End With
    End Sub
    Private Sub cargar_cfg_dir_documentos()
        'Conectar()
        rs.Open("SELECT * FROM cfg_documentos WHERE id_cfg_documentos=1", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("dir_facturas").Value) Then
                tb_facturas.Text = rs.Fields("dir_facturas").Value
            Else
                tb_facturas.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            End If
            If Not IsDBNull(rs.Fields("dir_cotizaciones").Value) Then
                tb_cotizaciones.Text = rs.Fields("dir_cotizaciones").Value
            Else
                tb_cotizaciones.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub btn_examinar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_examinar.Click
        ofd_foto.ShowDialog()
        If bandera_Insertada = False Then
            MsgBox("Tamaño de la imagen sobrepasa lo permitido")
            ofd_foto.FileName = ""
        Else
            bandera_Insertada = True
        End If
    End Sub

    Private Sub ofd_foto_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofd_foto.FileOk
        Dim tamaño As Integer
        Dim File As New System.IO.FileInfo(ofd_foto.FileName)
        tamaño = File.Length / 1024
        bandera_Insertada = True
        If ofd_foto.FileName <> "" Then
            If (tamaño < 200) Then
                pb_foto.BackgroundImage = New Bitmap(ofd_foto.FileName)
                bandera = True
            Else
                bandera_Insertada = False
            End If
        End If
    End Sub

    Private Sub frm_configuracion_empresa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.TopMost = False
    End Sub

    Private Sub frm_configuracion_empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        id_diseño = 0
        'Me.MdiParent = frm_principal
        cargar()

        Dim font_family As FontFamily
        Dim installed_fonts As New InstalledFontCollection
        cb_fuente_titulo.Items.Clear()
        cb_fuente_producto.Items.Clear()
        For Each font_family In FontFamily.Families
            cb_fuente_titulo.Items.Add(font_family.Name)
            cb_fuente_producto.Items.Add(font_family.Name)
        Next


    End Sub
    Private Sub cargar_cfg_formatos()
        cargar_catalogo_formatos()

        rs.Open("SELECT * FROM cfg_formato_impresion WHERE id_cfg_formato_impresion='1'", conn)
        If rs.RecordCount > 0 Then
            seleccionar_combo(rs.Fields("id_formato_nota_venta").Value, cb_formato_nota_venta)
            seleccionar_combo(rs.Fields("id_formato_orden_entrega").Value, cb_formato_orden_entrega)
            seleccionar_combo(rs.Fields("id_formato_cotizacion").Value, cb_formato_cotización)
            seleccionar_combo(rs.Fields("id_formato_cxcobrar").Value, cb_formato_cxcobrar)
        End If
        rs.Close()
    End Sub
    Private Sub cargar_catalogo_formatos()
        cb_formato_nota_venta.Items.Clear()
        cb_formato_orden_entrega.Items.Clear()
        cb_formato_cotización.Items.Clear()
        cb_formato_cxcobrar.Items.Clear()

        cb_formato_nota_venta.Text = ""
        cb_formato_orden_entrega.Text = ""
        cb_formato_cotización.Text = ""
        cb_formato_cxcobrar.Text = ""


        cb_formato_cotización.Items.Add(New myItem("2", "LA_LETTER"))
        cb_formato_cotización.Items.Add(New myItem("3", "RETAIL_LETTER"))

        If conf_pv(16) = 0 Then
            cb_formato_nota_venta.Items.Add(New myItem("1", "LA"))

            cb_formato_orden_entrega.Items.Add(New myItem("1", "MK"))

            'cb_formato_cotización.Items.Add(New myItem("1", "RETAIL"))

            cb_formato_cxcobrar.Items.Add(New myItem("1", "LA"))


        Else
            cb_formato_nota_venta.Items.Add(New myItem("2", "RETAIL_LETTER"))
            cb_formato_nota_venta.Items.Add(New myItem("3", "RETAIL_A5"))
            cb_formato_nota_venta.Items.Add(New myItem("4", "MK_LETTER"))

            cb_formato_orden_entrega.Items.Add(New myItem("2", "MK_LETTER"))

            cb_formato_cxcobrar.Items.Add(New myItem("2", "MK_LETTER"))
        End If



    End Sub
    Private Sub cargar()
        'Conectar()
        rs.Open("SELECT logotipo,logotipo_thumb,id_pantalla from configuracion WHERE id_configuracion=1", conn)
        If rs.RecordCount > 0 Then
            Dim bDatos As Byte()
            Dim imagen As System.Drawing.Image
            If Not IsDBNull(rs.Fields("logotipo").Value) Then
                bDatos = CType(rs.Fields("logotipo").Value, Byte())
                imagen = New Bitmap(Bytes_Imagen(bDatos))
            Else
                imagen = ventas.My.Resources._50CENTAVOS
            End If
            pb_foto.BackgroundImage = imagen
            If rs.Fields("id_pantalla").Value = 0 Then
                rb_pantalla0.Checked = True
                rb_pantalla1.Checked = False
            Else
                rb_pantalla0.Checked = False
                rb_pantalla1.Checked = True
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '--OBTENEMOS LINEAS DE TICKET
        lst_ticket_cabeza.Items.Clear()
        lst_ticket_pie.Items.Clear()
        'Conectar()
        rs.Open("SELECT * FROM cfg_lineas_ticket  ORDER BY id_lineas ASC", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                If rs.Fields("id_tipo").Value = 1 Then
                    lst_ticket_cabeza.Items.Add(rs.Fields("descripcion").Value)
                Else
                    lst_ticket_pie.Items.Add(rs.Fields("descripcion").Value)
                End If
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '------------------------
        '---obtenemos la conf de colores de punto de venta
        'Conectar()
        rs.Open("Select * FROM cfg_colores WHERE id_cfg_color=1", conn)
        If rs.RecordCount > 0 Then
            If Not IsDBNull(rs.Fields("cfg_1").Value) Then
                cfg_1.BackColor = Color.FromArgb(rs.Fields("cfg_1").Value)
                cfg_punto_venta.BackColor = Color.FromArgb(rs.Fields("cfg_1").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_2").Value) Then
                cfg_2.BackColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_cliente.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_producto.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_categorias.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_otros_contenedores.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_usuario.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_totales.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
                cfg_punto_venta.ForeColor = Color.FromArgb(rs.Fields("cfg_2").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_3").Value) Then
                cfg_3.BackColor = Color.FromArgb(rs.Fields("cfg_3").Value)
                cfg_cliente.BackColor = Color.FromArgb(rs.Fields("cfg_3").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_4").Value) Then
                cfg_4.BackColor = Color.FromArgb(rs.Fields("cfg_4").Value)
                txt_cliente.ForeColor = Color.FromArgb(rs.Fields("cfg_4").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_5").Value) Then
                cfg_5.BackColor = Color.FromArgb(rs.Fields("cfg_5").Value)
                cfg_producto.BackColor = Color.FromArgb(rs.Fields("cfg_5").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_6").Value) Then
                cfg_6.BackColor = Color.FromArgb(rs.Fields("cfg_6").Value)
                btn_producto.BackColor = Color.FromArgb(rs.Fields("cfg_6").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_7").Value) Then
                cfg_7.BackColor = Color.FromArgb(rs.Fields("cfg_7").Value)
                txt_producto.ForeColor = Color.FromArgb(rs.Fields("cfg_7").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_8").Value) Then
                cfg_8.BackColor = Color.FromArgb(rs.Fields("cfg_8").Value)
                btn_ejecucion.BackColor = Color.FromArgb(rs.Fields("cfg_8").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_9").Value) Then
                cfg_9.BackColor = Color.FromArgb(rs.Fields("cfg_9").Value)
                btn_ejecucion.ForeColor = Color.FromArgb(rs.Fields("cfg_9").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_10").Value) Then
                cfg_10.BackColor = Color.FromArgb(rs.Fields("cfg_10").Value)
                cfg_categorias.BackColor = Color.FromArgb(rs.Fields("cfg_10").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_11").Value) Then
                cfg_11.BackColor = Color.FromArgb(rs.Fields("cfg_11").Value)
                btn_categoria.BackColor = Color.FromArgb(rs.Fields("cfg_11").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_12").Value) Then
                cfg_12.BackColor = Color.FromArgb(rs.Fields("cfg_12").Value)
                btn_categoria.ForeColor = Color.FromArgb(rs.Fields("cfg_12").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_13").Value) Then
                cfg_13.BackColor = Color.FromArgb(rs.Fields("cfg_13").Value)
                txt_venta.ForeColor = Color.FromArgb(rs.Fields("cfg_13").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_14").Value) Then
                cfg_14.BackColor = Color.FromArgb(rs.Fields("cfg_14").Value)
                tb_alerta.BackColor = Color.FromArgb(rs.Fields("cfg_14").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_15").Value) Then
                cfg_15.BackColor = Color.FromArgb(rs.Fields("cfg_15").Value)
                tb_alerta.ForeColor = Color.FromArgb(rs.Fields("cfg_15").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_16").Value) Then
                cfg_16.BackColor = Color.FromArgb(rs.Fields("cfg_16").Value)
                cfg_totales.BackColor = Color.FromArgb(rs.Fields("cfg_16").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_17").Value) Then
                cfg_17.BackColor = Color.FromArgb(rs.Fields("cfg_17").Value)
                txt_total.ForeColor = Color.FromArgb(rs.Fields("cfg_17").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_18").Value) Then
                cfg_18.BackColor = Color.FromArgb(rs.Fields("cfg_18").Value)
                txt_cantidad.ForeColor = Color.FromArgb(rs.Fields("cfg_18").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_19").Value) Then
                cfg_19.BackColor = Color.FromArgb(rs.Fields("cfg_19").Value)
                cfg_usuario.BackColor = Color.FromArgb(rs.Fields("cfg_19").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_20").Value) Then
                cfg_20.BackColor = Color.FromArgb(rs.Fields("cfg_20").Value)
                txt_usuario.ForeColor = Color.FromArgb(rs.Fields("cfg_20").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_21").Value) Then
                cfg_21.BackColor = Color.FromArgb(rs.Fields("cfg_21").Value)
                cfg_otros_contenedores.BackColor = Color.FromArgb(rs.Fields("cfg_21").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_22").Value) Then
                cfg_22.BackColor = Color.FromArgb(rs.Fields("cfg_22").Value)
                txt_otros.ForeColor = Color.FromArgb(rs.Fields("cfg_22").Value)
            End If
            If Not IsDBNull(rs.Fields("cfg_23").Value) Then
                cfg_23.BackColor = Color.FromArgb(rs.Fields("cfg_23").Value)

            End If
            If Not IsDBNull(rs.Fields("cfg_24").Value) Then
                cfg_24.BackColor = Color.FromArgb(rs.Fields("cfg_24").Value)
            End If

            If Not IsDBNull(rs.Fields("cfg_25").Value) Then
                cfg_25.BackColor = Color.FromArgb(rs.Fields("cfg_25").Value)
            End If

            If Not IsDBNull(rs.Fields("cfg_26").Value) Then
                cfg_26.BackColor = Color.FromArgb(rs.Fields("cfg_26").Value)
            End If

            If Not IsDBNull(rs.Fields("cfg_27").Value) Then
                cfg_27.BackColor = Color.FromArgb(rs.Fields("cfg_27").Value)
            End If

            If Not IsDBNull(rs.Fields("cfg_28").Value) Then
                cfg_28.BackColor = Color.FromArgb(rs.Fields("cfg_28").Value)
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
        '--------------------
        '-------------------------------------------------------
        tb_terminal.Text = global_nombre_terminal

        cargar_sucursales()
        cargar_catalogo_impresoras()
        obtener_datos_empresa()
        obtener_cfg_punto_venta()
        obtener_cfg_impresoras()
        cargar_cfg_dir_documentos()
        cargar_cfg_facturacion()
        cargar_cfg_formatos()
        cargar_cfg_bascula()
    End Sub
    Private Sub cargar_cfg_bascula()

        cb_discartnull.Items.Clear()
        cb_discartnull.SelectedIndex = -1
        cb_rtsenable.Items.Clear()
        cb_rtsenable.SelectedIndex = -1
        cb_stopbits.Items.Clear()
        cb_stopbits.SelectedIndex = -1
        cb_parity.Items.Clear()
        cb_parity.SelectedIndex = -1

        cb_discartnull.Items.Add("True")
        cb_discartnull.Items.Add("False")
        cb_rtsenable.Items.Add("True")
        cb_rtsenable.Items.Add("False")

        cb_stopbits.Items.Add("None")
        cb_stopbits.Items.Add("One")
        cb_stopbits.Items.Add("Two")
        cb_stopbits.Items.Add("OnePointFive")

        cb_parity.Items.Add("None")
        cb_parity.Items.Add("Odd")
        cb_parity.Items.Add("Even")
        cb_parity.Items.Add("Mark")
        cb_parity.Items.Add("Space")


        cb_discartnull.SelectedIndex = 0
        cb_rtsenable.SelectedIndex = 0
        cb_stopbits.SelectedIndex = 0
        cb_parity.SelectedIndex = 0


        rs.Open("SELECT * FROM cfg_bascula WHERE id_cfg_bascula='1'", conn)
        If rs.RecordCount > 0 Then
            tb_portname.Text = rs.Fields("portname").Value
            tb_baurate.Text = rs.Fields("baudrate").Value
            tb_databits.Value = rs.Fields("databits").Value
            cb_discartnull.Text = rs.Fields("discarnull").Value
            cb_parity.Text = rs.Fields("parity").Value
            tb_readbuffersize.Text = rs.Fields("readbuffersize").Value
            tb_readtimeout.Text = rs.Fields("readtimeout").Value
            tb_receivedbytesthreshold.Text = rs.Fields("receivedbytesthreshold").Value
            cb_rtsenable.Text = rs.Fields("rtsenable").Value
            cb_stopbits.Text = rs.Fields("stopbits").Value
            tb_writebuffersize.Text = rs.Fields("writebuffersize").Value
            tb_writetimeout.Text = rs.Fields("writetimeout").Value
        End If
        rs.Close()


    End Sub
    Private Sub limpiar_cfg_impresoras()
        For x = 0 To 2
            conf_impresoras(x) = Nothing
        Next
    End Sub
    Private Sub obtener_cfg_impresoras()
        'Conectar()
        'rs.Open("SELECT * FROM cfg_impresoras WHERE id_cfg_impresora=1", conn)
        'If rs.RecordCount > 0 Then
        'cb_impresora_caja.Text = rs.Fields("index_imp_caja").Value
        'cb_impresora_pedidos.Text = rs.Fields("index_imp_pedidos").Value
        'cb_impresora_almacen.Text = rs.Fields("index_imp_almacen").Value

        'seleccionar_impresora(rs.Fields("index_imp_caja").Value, cb_impresora_caja)
        'seleccionar_impresora(rs.Fields("index_imp_pedidos").Value, cb_impresora_pedidos)
        'seleccionar_impresora(rs.Fields("index_imp_almacen").Value, cb_impresora_almacen)
        'End If
        'rs.Close()
        'conn.close()
        'conn = Nothing

        cb_impresora_caja.Text = conf_impresoras(0)
        cb_impresora_pedidos.Text = conf_impresoras(1)
        cb_impresora_almacen.Text = conf_impresoras(2)
    End Sub
    Public Sub seleccionar_impresora(ByVal index As Integer, ByVal combo As ComboBox)
        For x = 0 To combo.Items.Count - 1
            If index = CType(combo.Items(x), myItem).Value Then
                combo.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub obtener_datos_empresa()
        conf_inicio()
        'Conectar()
        rs.Open("SELECT razon_social,calle,num_int,num_ext,colonia,municipio,localidad,cp,estado,pais,url,rfc,alias,correo,id_sucursal,id_regimen_fiscal,telefono FROM configuracion WHERE id_configuracion=1", conn)
        If rs.RecordCount > 0 Then
            tb_razon.Text = rs.Fields("razon_social").Value
            tb_alias.Text = rs.Fields("alias").Value
            tb_calle.Text = rs.Fields("calle").Value
            tb_num_int.Text = rs.Fields("num_int").Value
            tb_num_ext.Text = rs.Fields("num_ext").Value
            tb_colonia.Text = rs.Fields("colonia").Value
            tb_municipio.Text = rs.Fields("municipio").Value
            tb_localidad.Text = rs.Fields("localidad").Value
            tb_cp.Text = rs.Fields("cp").Value
            tb_estado.Text = rs.Fields("estado").Value
            tb_pais.Text = rs.Fields("pais").Value
            tb_url.Text = rs.Fields("url").Value
            tb_rfcM.Text = rs.Fields("rfc").Value
            tb_emailM.Text = rs.Fields("correo").Value
            tb_telefono.Text = rs.Fields("telefono").Value
            seleccionar_catalogo(rs.Fields("id_regimen_fiscal").Value, cb_regimen)
            If rs.Fields("id_sucursal").Value > 0 Then
                seleccionar_catalogo(rs.Fields("id_sucursal").Value, cb_sucursal)
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub
   
    Private Sub conf_inicio()
        tb_alias.Text = ""
        tb_url.Text = ""
        tb_rfcM.Text = ""
        tb_razon.Text = ""
        cb_sucursal.Text = ""
        cb_sucursal.SelectedIndex = -1
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
    Private Sub cargar_sucursales()
        cb_sucursal.Items.Clear()
        'Conectar()
        rs.Open("SELECT id_sucursal,alias FROM sucursal ORDER by id_sucursal", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_sucursal.Items.Add(New myItem(rs.Fields("id_sucursal").Value, rs.Fields("alias").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing

    End Sub
    Private Sub btn_agregar_cabeza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_cabeza.Click
        lst_ticket_cabeza.Items.Add(tb_agregar_linea_cabeza.Text)
        tb_agregar_linea_cabeza.Text = ""
    End Sub

    Private Sub btn_eliminar_cabeza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_cabeza.Click
        lst_ticket_cabeza.Items.Remove(lst_ticket_cabeza.SelectedItem)
    End Sub

    Private Sub btn_aplicar_lineas_head_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_lineas_head.Click
        'Conectar()
        conn.Execute("DELETE FROM cfg_lineas_ticket WHERE id_tipo=1")
        For x = 0 To lst_ticket_cabeza.Items.Count - 1
            conn.Execute("INSERT INTO cfg_lineas_ticket(descripcion,id_tipo) VALUES('" & lst_ticket_cabeza.Items(x) & "',1)")
        Next
        'conn.close()
        'conn = Nothing
        MsgBox("Los cambios se guardaron correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub btn_agregar_pie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_pie.Click
        lst_ticket_pie.Items.Add(tb_agregar_linea_pie.Text)
        tb_agregar_linea_pie.Text = ""
    End Sub

    Private Sub btn_eliminar_pie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_pie.Click
        lst_ticket_pie.Items.Remove(lst_ticket_pie.SelectedItem)
    End Sub

    Private Sub btn_aplicar_lineas_foot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_lineas_foot.Click
        'Conectar()
        conn.Execute("DELETE FROM cfg_lineas_ticket WHERE id_tipo=0")
        For x = 0 To lst_ticket_pie.Items.Count - 1
            conn.Execute("INSERT INTO cfg_lineas_ticket(descripcion,id_tipo) VALUES('" & lst_ticket_pie.Items(x) & "',0)")
        Next
        'conn.close()
        'conn = Nothing
        MsgBox("Los cambios se guardaron correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cadena As String = ""
        Dim bandera_correcto As Boolean = True
        cadena = "Error en los siguientes campos:" & vbCrLf

        If Trim(tb_razon.TextLength) = 0 Then
            cadena = cadena & "   Razon Social" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(tb_alias.TextLength) = 0 Then
            cadena = cadena & "   Alias" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(tb_rfcM.TextLength) = 0 Then
            cadena = cadena & "   RFC" & vbCrLf
            bandera_correcto = False
        End If

        If cb_sucursal.SelectedIndex = -1 Then
            cadena = cadena & "   Sucursal" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(tb_calle.TextLength) = 0 Then
            cadena = cadena & "   Calle" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(tb_colonia.TextLength) = 0 Then
            cadena = cadena & "   Colonia" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(tb_municipio.TextLength) = 0 Then
            cadena = cadena & "   Municipio" & vbCrLf
            bandera_correcto = False
        End If

        If Trim(tb_cp.TextLength) = 0 Then
            cadena = cadena & "   CP" & vbCrLf
            bandera_correcto = False
        End If

        If bandera_correcto = True Then
            'Conectar()
            Dim id_sucursal As Integer = 0
            If CType(cb_sucursal.SelectedItem, myItem).Value > 0 Then
                id_sucursal = CType(cb_sucursal.SelectedItem, myItem).Value
            End If
            conn.Execute("UPDATE configuracion SET alias='" & tb_alias.Text & "',razon_social='" & tb_razon.Text & "',url='" & tb_url.Text & "',rfc='" & tb_rfcM.Text & "',correo='" & tb_emailM.Text & "',id_sucursal='" & id_sucursal & "',calle='" & tb_calle.Text & "',num_int='" & tb_num_int.Text & "',num_ext='" & tb_num_ext.Text & "',colonia='" & tb_colonia.Text & "',municipio='" & tb_municipio.Text & "',localidad='" & tb_localidad.Text & "',cp='" & tb_cp.Text & "',estado='" & tb_estado.Text & "',pais='" & tb_pais.Text & "',id_regimen_fiscal='" & CType(cb_regimen.SelectedItem, myItem).Value & "',telefono='" & tb_telefono.Text & "' WHERE id_configuracion=1")
            conn.Execute("UPDATE empleado SET id_sucursal=" & id_sucursal & "")
            conn.Execute("UPDATE producto_sucursal SET id_sucursal=" & id_sucursal & "")
            conn.Execute("UPDATE venta SET id_sucursal=" & id_sucursal & "")
            conn.Execute("UPDATE pedido_clientes SET id_sucursal=" & id_sucursal & "")
            conn.Execute("UPDATE almacenes SET id_sucursal=" & id_sucursal & "")

            'conn.close()
            'conn = Nothing
            obtener_datos_empresa()
            obtener_id_sucursal()
            guardar_cfg_terminal(tb_terminal.Text, conf_impresoras(0), conf_impresoras(1), conf_impresoras(2))
            global_nombre_terminal = tb_terminal.Text
            MsgBox("Los datos de la empresa han sido guardados correctamente", MsgBoxStyle.Information, "Información")
        Else
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Información")
        End If
    End Sub

    Private Sub btn_sucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sucursal.Click
        frm_sucursal.Show()
        cargar_sucursales()
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn10.Click, btn11.Click, btn12.Click, btn13.Click, btn14.Click, btn15.Click, btn16.Click, btn17.Click, btn18.Click, btn19.Click, btn20.Click, btn21.Click, btn22.Click, btn23.Click, btn24.Click, btn_25.Click, btn_26.Click, btn_27.Click, Label80.Click
        '(CType(sender, Button).TabIndex)
        id_diseño = (CType(sender, Label).TabIndex)
        cd_color.ShowDialog()
        'MsgBox(id_diseño)
        Select Case id_diseño
            Case 0

            Case 1
                cfg_1.BackColor = cd_color.Color
                cfg_punto_venta.BackColor = cd_color.Color
            Case 2
                cfg_2.BackColor = cd_color.Color
                cfg_cliente.ForeColor = cd_color.Color
                cfg_producto.ForeColor = cd_color.Color
                cfg_categorias.ForeColor = cd_color.Color
                cfg_otros_contenedores.ForeColor = cd_color.Color
                cfg_usuario.ForeColor = cd_color.Color
                cfg_totales.ForeColor = cd_color.Color
                cfg_punto_venta.ForeColor = cd_color.Color
            Case 3
                cfg_3.BackColor = cd_color.Color
                cfg_cliente.BackColor = cd_color.Color
            Case 4
                cfg_4.BackColor = cd_color.Color
                txt_cliente.ForeColor = cd_color.Color
            Case 5
                cfg_5.BackColor = cd_color.Color
                cfg_producto.BackColor = cd_color.Color
            Case 6
                cfg_6.BackColor = cd_color.Color
                btn_producto.BackColor = cd_color.Color
            Case 7
                cfg_7.BackColor = cd_color.Color
                txt_producto.ForeColor = cd_color.Color
            Case 8
                cfg_8.BackColor = cd_color.Color
                btn_ejecucion.BackColor = cd_color.Color
            Case 9
                cfg_9.BackColor = cd_color.Color
                btn_ejecucion.ForeColor = cd_color.Color
            Case 10
                cfg_10.BackColor = cd_color.Color
                cfg_categorias.BackColor = cd_color.Color
            Case 11
                cfg_11.BackColor = cd_color.Color
                btn_categoria.BackColor = cd_color.Color
            Case 12
                cfg_12.BackColor = cd_color.Color
                btn_categoria.ForeColor = cd_color.Color
            Case 13
                cfg_13.BackColor = cd_color.Color
                txt_venta.ForeColor = cd_color.Color
            Case 14
                cfg_14.BackColor = cd_color.Color
                tb_alerta.BackColor = cd_color.Color
            Case 15
                cfg_15.BackColor = cd_color.Color
                tb_alerta.ForeColor = cd_color.Color
            Case 16
                cfg_16.BackColor = cd_color.Color
                cfg_totales.BackColor = cd_color.Color
            Case 17
                cfg_17.BackColor = cd_color.Color
                txt_total.ForeColor = cd_color.Color
            Case 18
                cfg_18.BackColor = cd_color.Color
                txt_cantidad.ForeColor = cd_color.Color
            Case 19
                cfg_19.BackColor = cd_color.Color
                cfg_usuario.BackColor = cd_color.Color
            Case 20
                cfg_20.BackColor = cd_color.Color
                txt_usuario.ForeColor = cd_color.Color
            Case 21
                cfg_21.BackColor = cd_color.Color
                cfg_otros_contenedores.BackColor = cd_color.Color
            Case 22
                cfg_22.BackColor = cd_color.Color
                txt_otros.ForeColor = cd_color.Color
            Case 23
                cfg_23.BackColor = cd_color.Color
            Case 24
                cfg_24.BackColor = cd_color.Color
            Case 25
                cfg_25.BackColor = cd_color.Color
            Case 26
                cfg_26.BackColor = cd_color.Color
            Case 27
                cfg_27.BackColor = cd_color.Color
            Case 28
                cfg_28.BackColor = cd_color.Color
        End Select
    End Sub

    Private Sub btn_guardar_colores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_colores.Click
        'Conectar()
        conn.Execute("UPDATE cfg_colores SET cfg_1='" & cfg_1.BackColor.ToArgb & "',cfg_2='" & cfg_2.BackColor.ToArgb & "',cfg_3='" & cfg_3.BackColor.ToArgb & "',cfg_4='" & cfg_4.BackColor.ToArgb & "',cfg_5='" & cfg_5.BackColor.ToArgb & "',cfg_6='" & cfg_6.BackColor.ToArgb & "',cfg_7='" & cfg_7.BackColor.ToArgb & "',cfg_8='" & cfg_8.BackColor.ToArgb & "',cfg_9='" & cfg_9.BackColor.ToArgb & "',cfg_10='" & cfg_10.BackColor.ToArgb & "',cfg_11='" & cfg_11.BackColor.ToArgb & "',cfg_12='" & cfg_12.BackColor.ToArgb & "',cfg_13='" & cfg_13.BackColor.ToArgb & "',cfg_14='" & cfg_14.BackColor.ToArgb & "',cfg_15='" & cfg_15.BackColor.ToArgb & "',cfg_16='" & cfg_16.BackColor.ToArgb & "',cfg_17='" & cfg_17.BackColor.ToArgb & "',cfg_18='" & cfg_18.BackColor.ToArgb & "',cfg_19='" & cfg_19.BackColor.ToArgb & "',cfg_20='" & cfg_20.BackColor.ToArgb & "',cfg_21='" & cfg_21.BackColor.ToArgb & "',cfg_22='" & cfg_22.BackColor.ToArgb & "',cfg_23='" & cfg_23.BackColor.ToArgb & "',cfg_24='" & cfg_24.BackColor.ToArgb & "',cfg_28='" & cfg_28.BackColor.ToArgb & "' WHERE id_cfg_color=1")
      
        'conn.close()
        'conn = Nothing
        MsgBox("Cambios guardados correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub btn_guardar_logo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_logo.Click

        If bandera_Insertada = True Then
            'Conectar()
            '---actualizamos producto
            Dim rs2 As New ADODB.Recordset
            rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
            rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
            rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
            rs2.ActiveConnection = conn
            rs2.Open("SELECT id_configuracion,logotipo,logotipo_thumb FROM configuracion WHERE id_configuracion=1")
            If rs2.RecordCount <> 0 Then
                rs2.MoveFirst()
            End If
            If bandera_Insertada = True Then
                rs2.Fields("logotipo").Value = Imagen_Bytes(pb_foto.BackgroundImage)
                rs2.Fields("logotipo_thumb").Value = Imagen_Bytes(pb_foto.BackgroundImage.GetThumbnailImage(200, 100, Nothing, New IntPtr))
            End If
            'rs2.Fields("fecha_alta").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
            rs2.Update()
            rs2.Close()
            '-----------------
            'conn.close()
            'conn = Nothing
            Dim logo_source As System.Drawing.Image
            logo_source = New Bitmap(ofd_foto.FileName).GetThumbnailImage(200, 100, Nothing, New IntPtr)
            logo_source.Save(Application.StartupPath & "/logo.png", System.Drawing.Imaging.ImageFormat.Png)
            pb_foto.BackgroundImage.Save(Application.StartupPath & "/logo.png", System.Drawing.Imaging.ImageFormat.Png)
            ' frm_principal.pb_logotipo.Image = Me.pb_foto.BackgroundImage
            MsgBox("La imagen ha sido guardada correctamente", MsgBoxStyle.Information, "Correcto")
        Else
            MsgBox("No ha selecciona ninguna nueva imagen", MsgBoxStyle.Exclamation, "Aviso")
        End If

    End Sub
    Private Sub obtener_cfg_punto_venta()
        'Conectar()
        rs.Open("SELECT * FROM cfg_punto_venta WHERE id_cfg_punto_venta=1", conn)
        If rs.RecordCount > 0 Then
            chb_forma_pago_express.CheckState = rs.Fields("cfg_pago_express").Value
            chb_activar_auto_bascula.CheckState = rs.Fields("cfg_activar_bascula").Value
            chb_varias_lineas.CheckState = rs.Fields("cfg_varias_lineas").Value
            chb_cantidades_negativas.CheckState = rs.Fields("cfg_cantidades_negativas").Value
            chb_ticket_pago.CheckState = rs.Fields("cfg_ticket_pago").Value
            chb_mostrar_codigo.CheckState = rs.Fields("cfg_mostrar_codigo").Value
            chb_cantidad_codigo.CheckState = rs.Fields("cfg_cantidad_codigo").Value
            chb_imprimir_orden_entrega.CheckState = rs.Fields("cfg_imprimir_orden_entrega").Value
            chb_mostrar_codigo_venta_detalle.CheckState = rs.Fields("cfg_mostrar_codigo_venta_detalle").Value
            chb_ajustar_precios.CheckState = rs.Fields("cfg_ajustar_precios").Value
            chb_mostrar_barra_tareas.CheckState = rs.Fields("cfg_mostrar_barra_tareas").Value
            chb_mostrar_boton_bascula.CheckState = rs.Fields("cfg_mostrar_boton_bascula").Value
            chb_ingresar_observacion.CheckState = rs.Fields("cfg_ingresar_observacion_producto").Value
            chb_imprimir_formatos_carta.CheckState = rs.Fields("cfg_imprimir_formatos_carta").Value
            chb_imprimir_productos_corte.CheckState = rs.Fields("cfg_imprimir_productos_corte").Value
            chb_imprimir_comprobante_de_pago.CheckState = rs.Fields("cfg_imprimir_comprobante_pago").Value
            chb_imprimir_logotipo.CheckState = rs.Fields("cfg_imprimir_logotipo_ticket").Value
            chb_imprimir_texto_sin_formato.CheckState = rs.Fields("cfg_imprimir_texto_sin_formato").Value
            chb_impresora_matriz.CheckState = rs.Fields("cfg_impresora_matriz").Value
            tb_longitud_titulo.Value = rs.Fields("longitud_titulo").Value
            tb_espacios_antes_total.Value = rs.Fields("espacios_antes_total").Value
            tb_margen_izq_total.Value = rs.Fields("margen_izq_total").Value


            cb_fuente_titulo.Text = rs.Fields("fuente_titulo").Value
            cb_fuente_producto.Text = rs.Fields("fuente_producto").Value
            tb_tamaño_fuente_titulo.Value = rs.Fields("size_titulo").Value
            tb_tamaño_fuente_productos.Value = rs.Fields("size_producto").Value
            tb_longitud_descripcion.Value = rs.Fields("long_descripcion").Value
            tb_longitud_maxima.Value = rs.Fields("long_maxima").Value
            tb_longitud_linea_productos.Value = rs.Fields("long_linea_productos").Value
            chb_productos_mayusculas.CheckState = rs.Fields("productos_mayusculas").Value
            tb_escala_logo_ticket.Value = rs.Fields("escala_logo_ticket").Value
            tb_escala_altura_logo.Value = rs.Fields("escala_altura_logo").Value

            If rs.Fields("cfg_ver_pedidos_apartados").Value = 0 Then
                rb_pedidos.Checked = True
            ElseIf rs.Fields("cfg_ver_pedidos_apartados").Value = 1 Then
                rb_apartados.Checked = True
            ElseIf rs.Fields("cfg_ver_pedidos_apartados").Value = 2 Then
                rb_ambos.Checked = True
            End If

            If rs.Fields("cfg_copia_ticket").Value > 0 Then
                chb_copia_ticket.CheckState = 1
                num_copias.Value = rs.Fields("cfg_copia_ticket").Value
                num_copias.Enabled = True
            Else
                chb_copia_ticket.CheckState = 0
                num_copias.Value = 1
                num_copias.Enabled = False
            End If
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub btn_guardar_cfg_pv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cfg_pv.Click
        'Conectar()
        Dim copias_ticket As Integer = 0
        If chb_copia_ticket.Checked = True Then
            copias_ticket = num_copias.Value
        End If
        Dim ver_pedido_apartado As Integer = 0
        If rb_pedidos.Checked = True Then
            ver_pedido_apartado = 0
        ElseIf rb_apartados.Checked = True Then
            ver_pedido_apartado = 1
        ElseIf rb_ambos.Checked = True Then
            ver_pedido_apartado = 2
        End If

        conn.Execute("UPDATE cfg_punto_venta SET cfg_pago_express='" & chb_forma_pago_express.CheckState & "',cfg_activar_bascula='" & chb_activar_auto_bascula.CheckState & "',cfg_varias_lineas='" & chb_varias_lineas.CheckState & "',cfg_cantidades_negativas='" & chb_cantidades_negativas.CheckState & "',cfg_mostrar_codigo='" & chb_mostrar_codigo.CheckState & "',cfg_copia_ticket='" & copias_ticket & "',cfg_ticket_pago='" & chb_ticket_pago.CheckState & "',cfg_cantidad_codigo='" & chb_cantidad_codigo.CheckState & "',cfg_imprimir_orden_entrega='" & chb_imprimir_orden_entrega.CheckState & "',cfg_mostrar_codigo_venta_detalle='" & chb_mostrar_codigo_venta_detalle.CheckState & "',cfg_ver_pedidos_apartados='" & ver_pedido_apartado & "',cfg_ajustar_precios='" & chb_ajustar_precios.CheckState & "',cfg_mostrar_barra_tareas='" & chb_mostrar_barra_tareas.CheckState & "',cfg_mostrar_boton_bascula='" & chb_mostrar_boton_bascula.CheckState & "',cfg_ingresar_observacion_producto='" & chb_ingresar_observacion.CheckState & "',cfg_imprimir_formatos_carta='" & chb_imprimir_formatos_carta.CheckState & "',cfg_imprimir_productos_corte='" & chb_imprimir_productos_corte.CheckState & "',cfg_imprimir_comprobante_pago='" & chb_imprimir_comprobante_de_pago.CheckState & "',cfg_imprimir_logotipo_ticket='" & chb_imprimir_logotipo.CheckState & "',cfg_imprimir_texto_sin_formato='" & chb_imprimir_texto_sin_formato.CheckState & "',cfg_impresora_matriz='" & chb_impresora_matriz.CheckState & "'  WHERE id_cfg_punto_venta=1")
        'conn.close()
        'conn = Nothing
        conf_pv(0) = chb_forma_pago_express.CheckState
        conf_pv(1) = chb_activar_auto_bascula.CheckState
        conf_pv(2) = chb_varias_lineas.CheckState
        conf_pv(3) = chb_cantidades_negativas.CheckState
        conf_pv(4) = chb_mostrar_codigo.CheckState
        conf_pv(5) = chb_copia_ticket.CheckState
        conf_pv(7) = chb_ticket_pago.CheckState
        conf_pv(8) = chb_cantidad_codigo.CheckState
        conf_pv(9) = chb_imprimir_orden_entrega.CheckState
        conf_pv(10) = chb_mostrar_codigo_venta_detalle.CheckState
        conf_pv(11) = ver_pedido_apartado
        conf_pv(12) = chb_ajustar_precios.CheckState
        conf_pv(13) = chb_mostrar_barra_tareas.CheckState
        conf_pv(14) = chb_mostrar_boton_bascula.CheckState
        conf_pv(15) = chb_ingresar_observacion.CheckState
        conf_pv(16) = chb_imprimir_formatos_carta.CheckState
        conf_pv(17) = chb_imprimir_productos_corte.CheckState
        conf_pv(18) = chb_imprimir_comprobante_de_pago.CheckState
        conf_pv(19) = chb_imprimir_logotipo.CheckState
        conf_pv(20) = chb_imprimir_texto_sin_formato.CheckState
        conf_pv(21) = chb_impresora_matriz.CheckState

        obtener_cfg_punto_venta()
        cargar_cfg_formatos()
        MsgBox("Los cambios han sido aplicados existosamente", MsgBoxStyle.Information, "Correcto")
    End Sub

    Private Sub chb_copia_ticket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_copia_ticket.CheckedChanged
        If chb_copia_ticket.Checked = True Then
            num_copias.Enabled = True
        Else
            num_copias.Enabled = False
        End If
    End Sub
    Private Sub btn_guardar_impresoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_impresoras.Click
        If MsgBox("Confirme que desea actualizar las impresoras", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            Dim index_imp_caja As String = ""
            Dim index_imp_pedidos As String = ""
            Dim index_imp_almacen As String = ""
            Dim bandera_correcto As Boolean = True

            If cb_impresora_caja.SelectedIndex <> -1 Then
                index_imp_caja = cb_impresora_caja.Text
            Else
                bandera_correcto = False
            End If
            If cb_impresora_pedidos.SelectedIndex <> -1 Then
                index_imp_pedidos = cb_impresora_pedidos.Text
            Else
                bandera_correcto = False
            End If
            If cb_impresora_almacen.SelectedIndex <> -1 Then
                index_imp_almacen = cb_impresora_almacen.Text
            Else
                bandera_correcto = False
            End If
            If bandera_correcto = True Then
                ''Conectar()
                'conn.Execute("UPDATE cfg_impresoras SET index_imp_caja='" & index_imp_caja & "',index_imp_pedidos='" & index_imp_pedidos & "',index_imp_almacen='" & index_imp_almacen & "' WHERE id_cfg_impresora='1'")
                ''conn.close()
                ''conn = Nothing
                guardar_cfg_terminal(global_nombre_terminal, index_imp_caja, index_imp_pedidos, index_imp_almacen)
                limpiar_cfg_impresoras()
                conf_impresoras(0) = index_imp_caja
                conf_impresoras(1) = index_imp_pedidos
                conf_impresoras(2) = index_imp_almacen

                MsgBox("Configuracion guardada correctamente", MsgBoxStyle.Information, "Aviso")
            Else
                MsgBox("Debe seleccionar una impresora de la lista", MsgBoxStyle.Critical, "Aviso")
            End If

        End If
    End Sub

    Private Sub btn_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturas.Click
        Try
            ' Configuración del FolderBrowserDialog  
            With FolderBrowserDialog1

                .RootFolder = Environment.SpecialFolder.Desktop

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then
                    tb_facturas.Text = .SelectedPath
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_cotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cotizaciones.Click
        Try
            ' Configuración del FolderBrowserDialog  
            With FolderBrowserDialog1

                .RootFolder = Environment.SpecialFolder.Desktop

                Dim ret As DialogResult = .ShowDialog ' abre el diálogo  

                ' si se presionó el botón aceptar ...  
                If ret = Windows.Forms.DialogResult.OK Then
                    tb_cotizaciones.Text = .SelectedPath
                End If

                .Dispose()

            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btn_guardar_dir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_dir.Click
        If MsgBox("Confirme que desea actualizar los directorios", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            '---actualizamos producto
            Dim rs2 As New ADODB.Recordset
            rs2.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
            rs2.CursorLocation = ADODB.CursorLocationEnum.adUseClient      'Ubicación del cursor: Del lado del cliente
            rs2.LockType = ADODB.LockTypeEnum.adLockOptimistic      'Tipo de bloqueo: Optimista
            rs2.ActiveConnection = conn
            rs2.Open("SELECT id_cfg_documentos,dir_facturas,dir_cotizaciones FROM cfg_documentos WHERE id_cfg_documentos=1")
            If rs2.RecordCount <> 0 Then
                rs2.MoveFirst()
            End If
            rs2.Fields("dir_facturas").Value = tb_facturas.Text
            rs2.Fields("dir_cotizaciones").Value = tb_cotizaciones.Text
            rs2.Update()
            rs2.Close()
            '-----------------
            'conn.close()
            'conn = Nothing

            global_dir_facturas = tb_facturas.Text
            global_dir_cotizaciones = tb_cotizaciones.Text
            MsgBox("Directorios actualizados correctamente", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub rb_pantalla0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_pantalla0.CheckedChanged
        If rb_pantalla0.Checked = True Then
            rb_pantalla1.Checked = False
        Else
            rb_pantalla1.Checked = True
        End If
    End Sub

    Private Sub rb_pantalla1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_pantalla1.CheckedChanged
        If rb_pantalla1.Checked = True Then
            rb_pantalla0.Checked = False
        Else
            rb_pantalla0.Checked = True
        End If
    End Sub

    Private Sub rb_pedidos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_pedidos.CheckedChanged
        If rb_pedidos.Checked = True Then
            rb_apartados.Checked = False
            rb_ambos.Checked = False
        End If
    End Sub

    Private Sub rb_apartados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_apartados.CheckedChanged
        If rb_apartados.Checked = True Then
            rb_pedidos.Checked = False
            rb_ambos.Checked = False
        End If
    End Sub

    Private Sub rb_ambos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb_ambos.CheckedChanged
        If rb_ambos.Checked = True Then
            rb_apartados.Checked = False
            rb_pedidos.Checked = False
        End If
    End Sub
    Private Sub cargar_unidad()
        cb_unidad.Items.Clear()
        cb_unidad.Text = ""
        rs.Open("SELECT id_unidad,nombre FROM unidad", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_unidad.Items.Add(New myItem(rs.Fields("id_unidad").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub
    Public Sub seleccionar_combo(ByVal index As Integer, ByVal combo As ComboBox)
        For x = 0 To combo.Items.Count - 1
            If index = CType(combo.Items(x), myItem).Value Then
                combo.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub rellenar_catalogo_combobox(id As String, valor As String, tabla_db As String, combobox As ComboBox, Optional opcion_general As Boolean = False, Optional condicion As String = "", Optional cadena_concatenar As String = "")
        Try
            Dim recordset As New ADODB.Recordset
            combobox.Items.Clear()
            If opcion_general = True Then
                combobox.Items.Add(New myItem("0", "Todos"))
            End If

            If cadena_concatenar = "" Then
                recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & condicion & "", conn)
            Else
                recordset.Open("SELECT " & id & "," & cadena_concatenar & " FROM " & tabla_db & condicion & "", conn)
            End If

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
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargar_cfg_facturacion()
        rellenar_catalogo_combobox("id_regimen_fiscal", "regimen_fiscal", "ctlg_regimen_fiscal", cb_regimen, , , "CONCAT(clave,'-',nombre) AS regimen_fiscal")
        cargar_unidad()
        Dim cfg_facturacion_encontrada As Boolean = False
        rs.Open("SELECT * FROM cfg_facturacion WHERE id_cfg_facturacion='1'", conn)
        If rs.RecordCount > 0 Then
            cfg_facturacion_encontrada = True
            chb_concepto_predet.CheckState = rs.Fields("concepto_predeterminado").Value
            chb_unidad_predet.CheckState = rs.Fields("unidad_predeterminada").Value

            If Not IsDBNull(rs.Fields("concepto").Value) Then
                tb_concepto_predt.Text = rs.Fields("concepto").Value
            End If

            If rs.Fields("id_unidad").Value > 0 Then
                seleccionar_combo(rs.Fields("id_unidad").Value, cb_unidad)
            End If
        End If
        rs.Close()
        If cfg_facturacion_encontrada = False Then
            cargar_cfg_facturacion()
        End If

        With lstv_series_facturas
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Serie", 50)
            .Columns.Add("Ultimo Folio", 80)
        End With
        cargar_series_facturacion()
    End Sub

    Private Sub chb_concepto_predet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_concepto_predet.CheckedChanged
        If chb_concepto_predet.Checked = True Then
            tb_concepto_predt.Enabled = True
        Else
            tb_concepto_predt.Enabled = False
        End If
    End Sub

    Private Sub chb_unidad_predet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_unidad_predet.CheckedChanged
        If chb_unidad_predet.Checked = True Then
            cb_unidad.Enabled = True
        Else
            cb_unidad.Enabled = False
        End If
    End Sub

    Private Sub btn_cfg_facturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cfg_facturacion.Click
        Dim cadena As String = "Se encontraron los siguiente errores: " & vbCrLf
        Dim correcto As Boolean = True
        Dim id_unidad As Integer = 0
        Dim regimen As String = ""

        If cb_regimen.SelectedIndex = -1 Then
            cadena &= "     *Debe seleccionar un régimen" & vbCrLf
            correcto = False
        End If
        If chb_unidad_predet.Checked = True Then
            If cb_unidad.SelectedIndex = -1 Then
                cadena &= "     *Debe seleccionar una unidad" & vbCrLf
                correcto = False
            Else
                id_unidad = CType(cb_unidad.SelectedItem, myItem).Value
            End If
        End If
        If chb_concepto_predet.Checked = True Then
            If Trim(tb_concepto_predt.Text) = "" Then
                cadena &= "     *Debe especificar el concepto predeterminado" & vbCrLf
                correcto = False
            End If
        End If

        If correcto = True Then
            conn.Execute("UPDATE cfg_facturacion SET concepto_predeterminado='" & chb_concepto_predet.CheckState & "',concepto='" & tb_concepto_predt.Text & "',unidad_predeterminada='" & chb_unidad_predet.CheckState & "',id_unidad='" & id_unidad & "' WHERE id_cfg_facturacion='1' ")
            conn.Execute("UPDATE cfg_colores SET cfg_25='" & cfg_25.BackColor.ToArgb & "',cfg_26='" & cfg_26.BackColor.ToArgb & "',cfg_27='" & cfg_27.BackColor.ToArgb & "' WHERE id_cfg_color=1")
            cargar_cfg_facturacion()
            MsgBox("Configuracion actualizada correctamente", MsgBoxStyle.Information, "Aviso")
        Else
            MsgBox(cadena, MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub btn_nueva_serie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_nueva_serie.Click
        gb_serie_factura.Enabled = True
        tb_serie.Text = ""
        chb_deshabilitar_serie.Checked = False
        tb_consecutivo_inicio.Text = "1"
        tb_consecutivo_fin.Text = "1000"
        tb_num_aprobacion.Text = ""
        tb_ano_aprobacion.Text = Now.Year
        tb_ultimo_folio_factura.Text = "000000"
        current_id_cfg_facturacion_serie = 0
        btn_guardar_serie.Enabled = True
        btn_cancelar_serie.Enabled = True
        btn_editar_serie.Enabled = False
        btn_eliminar_serie.Enabled = False
        btn_nueva_serie.Enabled = False


    End Sub

    Private Sub btn_guardar_serie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_serie.Click
        If current_id_cfg_facturacion_serie > 0 Then
            conn.Execute("UPDATE cfg_facturacion_serie SET serie='" & tb_serie.Text & "',deshabilitar='" & chb_deshabilitar_serie.CheckState & "',consecutivo_inicial='" & tb_consecutivo_inicio.Text & "',consecutivo_final='" & tb_consecutivo_fin.Text & "',num_aprobacion='" & tb_num_aprobacion.Text & "',ano_aprobacion='" & tb_ano_aprobacion.Text & "',ultimo_folio_factura='" & tb_ultimo_folio_factura.Text & "' WHERE id_cfg_facturacion_serie='" & current_id_cfg_facturacion_serie & "'")
            cargar_series_facturacion()
            MsgBox("Serie actualizada correctamente", MsgBoxStyle.Information, "Aviso")
        Else
            'ingresamos nuevo registro
            conn.Execute("INSERT INTO cfg_facturacion_serie (serie,deshabilitar,consecutivo_inicial,consecutivo_final,num_aprobacion,ano_aprobacion,ultimo_folio_factura) " & _
                         " VALUES('" & tb_serie.Text & "','" & chb_deshabilitar_serie.CheckState & "','" & tb_consecutivo_inicio.Text & "','" & tb_consecutivo_fin.Text & "','" & tb_num_aprobacion.Text & "','" & tb_ano_aprobacion.Text & "','" & tb_ultimo_folio_factura.Text & "')")
            cargar_series_facturacion()
            MsgBox("Serie guardada correctamente", MsgBoxStyle.Information, "Aviso")
        End If
        gb_serie_factura.Enabled = False
        btn_nueva_serie.Enabled = True
        btn_guardar_serie.Enabled = False
        btn_editar_serie.Enabled = True
        btn_eliminar_serie.Enabled = True
        btn_cancelar_serie.Enabled = False

    End Sub

    Private Sub btn_editar_serie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_editar_serie.Click
        gb_serie_factura.Enabled = True
        btn_nueva_serie.Enabled = False
        btn_guardar_serie.Enabled = True
        btn_editar_serie.Enabled = False
        btn_eliminar_serie.Enabled = False
        btn_cancelar_serie.Enabled = True
    End Sub

    Private Sub btn_eliminar_serie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_serie.Click
        If MsgBox("Confirme que desea eliminar la serie seleccionada, ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("DELETE FROM cfg_facturacion_serie WHERE id_cfg_facturacion_serie='" & current_id_cfg_facturacion_serie & "'")
            cargar_series_facturacion()
            MsgBox("Serie eliminada correctamente", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub
    Private Sub cargar_series_facturacion()
        lstv_series_facturas.Items.Clear()
        rs.Open("SELECT id_cfg_facturacion_serie,serie,ultimo_folio_factura FROM cfg_facturacion_serie", conn)
        If rs.RecordCount > 0 Then
            Dim i As Integer = 0
            While Not rs.EOF
                Dim str(1) As String

                str(0) = rs.Fields("serie").Value
                str(1) = rs.Fields("ultimo_folio_factura").Value

                lstv_series_facturas.Items.Add(New ListViewItem(str, 0))
                lstv_series_facturas.Items(i).Tag = rs.Fields("id_cfg_facturacion_serie").Value
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()

        gb_serie_factura.Enabled = False
        btn_nueva_serie.Enabled = True
        btn_guardar_serie.Enabled = False
        btn_editar_serie.Enabled = False
        btn_eliminar_serie.Enabled = False
        btn_cancelar_serie.Enabled = False
    End Sub
    Private Sub lstv_series_facturas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstv_series_facturas.Click
        If lstv_series_facturas.SelectedItems.Count > 0 Then
            btn_editar_serie.Enabled = True
            btn_eliminar_serie.Enabled = True
            current_id_cfg_facturacion_serie = lstv_series_facturas.SelectedItems.Item(0).Tag
            cargar_detalle_serie()
        End If
    End Sub
    Private Sub btn_cancelar_serie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_serie.Click
        gb_serie_factura.Enabled = False
        btn_nueva_serie.Enabled = True
        btn_guardar_serie.Enabled = False
        btn_editar_serie.Enabled = False
        btn_eliminar_serie.Enabled = False
        btn_cancelar_serie.Enabled = False
    End Sub
    Private Sub cargar_detalle_serie()
        rs.Open("SELECT * FROM cfg_facturacion_serie WHERE id_cfg_facturacion_serie='" & current_id_cfg_facturacion_serie & "'", conn)
        If rs.RecordCount > 0 Then
            tb_serie.Text = rs.Fields("serie").Value
            chb_deshabilitar_serie.Checked = rs.Fields("deshabilitar").Value
            tb_consecutivo_inicio.Text = rs.Fields("consecutivo_inicial").Value
            tb_consecutivo_fin.Text = rs.Fields("consecutivo_final").Value
            tb_num_aprobacion.Text = rs.Fields("num_aprobacion").Value
            tb_ano_aprobacion.Text = rs.Fields("ano_aprobacion").Value
            tb_ultimo_folio_factura.Text = rs.Fields("ultimo_folio_factura").Value
        End If
        rs.Close()
    End Sub

    Private Sub btn_guardar_cfg_pdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cfg_pdf.Click
        Dim correcto As Boolean = True
        Dim mensaje As String = "No se puede guardar la configuracion, se encontraron los siguientes errores:" & vbCrLf

        If cb_formato_nota_venta.SelectedIndex = -1 Then
            mensaje = mensaje & " *Seleccione un formato de nota de venta" & vbCrLf
            correcto = False
        End If

        If cb_formato_orden_entrega.SelectedIndex = -1 Then
            mensaje = mensaje & " *Seleccione un formato de orden de entrega" & vbCrLf
            correcto = False
        End If

        If cb_formato_cotización.SelectedIndex = -1 Then
            mensaje = mensaje & " *Seleccione un formato de cotizacion" & vbCrLf
            correcto = False
        End If

        If cb_formato_cxcobrar.SelectedIndex = -1 Then
            mensaje = mensaje & " *Seleccione un formato de cuentas por cobrar" & vbCrLf
            correcto = False
        End If

        If correcto = True Then
            conn.Execute("UPDATE cfg_formato_impresion SET id_formato_nota_venta='" & CType(cb_formato_nota_venta.SelectedItem, myItem).Value & "',id_formato_orden_entrega='" & CType(cb_formato_orden_entrega.SelectedItem, myItem).Value & "',id_formato_cotizacion='" & CType(cb_formato_cotización.SelectedItem, myItem).Value & "',id_formato_cxcobrar='" & CType(cb_formato_cxcobrar.SelectedItem, myItem).Value & "' WHERE id_cfg_formato_impresion='1'")
            MsgBox("configuracion de formatos actualizados_correctamente", MsgBoxStyle.Information, "Aviso")

            conf_pv_id_formato(0) = CType(cb_formato_nota_venta.SelectedItem, myItem).Value
            conf_pv_id_formato(1) = CType(cb_formato_orden_entrega.SelectedItem, myItem).Value
            conf_pv_id_formato(2) = CType(cb_formato_cotización.SelectedItem, myItem).Value
            conf_pv_id_formato(3) = CType(cb_formato_cxcobrar.SelectedItem, myItem).Value
        Else
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If
    End Sub

    Private Sub btn_guardar_formato_ticket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_formato_ticket.Click
        conn.Execute("UPDATE cfg_punto_venta SET fuente_titulo='" & cb_fuente_titulo.Text & "',fuente_producto='" & cb_fuente_producto.Text & "',size_titulo='" & tb_tamaño_fuente_titulo.Value & "',size_producto='" & tb_tamaño_fuente_productos.Value & "',long_descripcion='" & tb_longitud_descripcion.Value & "',long_maxima='" & tb_longitud_maxima.Value & "',long_linea_productos='" & tb_longitud_linea_productos.Value & "',productos_mayusculas='" & chb_productos_mayusculas.CheckState & "',escala_logo_ticket='" & tb_escala_logo_ticket.Value & "',escala_altura_logo='" & tb_escala_altura_logo.Value & "',longitud_titulo='" & tb_longitud_titulo.Value & "',espacios_antes_total='" & tb_espacios_antes_total.Value & "',margen_izq_total='" & tb_margen_izq_total.Value & "' WHERE id_cfg_punto_venta='1'")
        cfg_fuente_tituto = cb_fuente_titulo.Text
        cfg_fuente_producto = cb_fuente_producto.Text
        cfg_tamaño_fuente_titulo = tb_tamaño_fuente_titulo.Value
        cfg_tamaño_fuente_producto = tb_tamaño_fuente_productos.Value
        cfg_longitud_descripcion = tb_longitud_descripcion.Value
        cfg_longitud_maxima_ticket = tb_longitud_maxima.Value
        cfg_longitud_linea_productos = tb_longitud_linea_productos.Value
        cfg_productos_mayusculas_ticket = chb_productos_mayusculas.CheckState
        cfg_escala_logo_ticket = tb_escala_logo_ticket.Value
        cfg_escala_altura_logo = tb_escala_altura_logo.Value
        cfg_longitud_titulo = tb_longitud_titulo.Value
        cfg_espacios_antes_total = tb_espacios_antes_total.Value
        cfg_margen_izq_total = tb_margen_izq_total.Value

        MsgBox("Configuracion de fuentes guardada correctamente", MsgBoxStyle.Information, "Aviso")
    End Sub

    Private Sub btn_guardar_cfg_bascula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar_cfg_bascula.Click
        If MsgBox("Confirme que desea actualizar la configuracion, ", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("UPDATE cfg_bascula SET " & _
                     "portname='" & tb_portname.Text & "', " & _
                    "baudrate='" & tb_baurate.Text & "', " & _
                    "databits='" & tb_databits.Value & "', " & _
                    "discarnull='" & cb_discartnull.Text & "', " & _
                    "parity='" & cb_parity.Text & "', " & _
                    "readbuffersize='" & tb_readbuffersize.Text & "', " & _
                    "readtimeout='" & tb_readtimeout.Text & "', " & _
                    "receivedbytesthreshold='" & tb_receivedbytesthreshold.Text & "', " & _
                    "rtsenable='" & cb_rtsenable.Text & "', " & _
                    "stopbits='" & cb_stopbits.Text & "', " & _
                    "writebuffersize='" & tb_writebuffersize.Text & "', " & _
                    "writetimeout='" & tb_writetimeout.Text & "'")


            rs.Open("SELECT * FROM cfg_bascula WHERE id_cfg_bascula='1'", conn)
            If rs.RecordCount > 0 Then
                global_cfg_bascula_portname = rs.Fields("portname").Value
                global_cfg_bascula_baudrate = rs.Fields("baudrate").Value
                global_cfg_bascula_databits = rs.Fields("databits").Value
                global_cfg_bascula_discarnull = rs.Fields("discarnull").Value
                global_cfg_bascula_parity = rs.Fields("parity").Value
                global_cfg_bascula_readbuffersize = rs.Fields("readbuffersize").Value
                global_cfg_bascula_readtimeout = rs.Fields("readtimeout").Value
                global_cfg_bascula_recievedbytethreshold = rs.Fields("receivedbytesthreshold").Value
                global_cfg_bascula_rtsenable = rs.Fields("rtsenable").Value
                global_cfg_bascula_stopbits = rs.Fields("stopbits").Value
                global_cfg_bascula_writebuffersize = rs.Fields("writebuffersize").Value
                global_cfg_bascula_writetimeout = rs.Fields("writetimeout").Value
            End If
            rs.Close()


            MsgBox("Informacion actualizada correctamente", MsgBoxStyle.Information, "Aviso")


        End If


    End Sub
End Class