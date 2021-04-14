Imports System.Data.OleDb
Imports System.IO.StreamWriter
Imports System.IO
Public Class frm_godmode

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Esta operacion eliminara toda la imformacion de productos,clientes,ventas,proveedores,precios y pedidods.Desea restablecer valores de fabrica", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            truncate_all_tables()
            'Conectar()
            '--CONFIGURACION DE PUBLICO EN GENERAL-------------------
            conn.Execute("INSERT INTO domicilio(calle,colonia,municipio,cp,poblacion,estado,pais) VALUES('','','','','','','')")
            conn.Execute("INSERT INTO empresa(razon_social,alias,id_domicilio,url,rfc,email) VALUES('PÚBLICO EN GENERAL','PÚBLICO EN GENERAL',1,'','','')")
            conn.Execute("INSERT INTO cliente_tipo(nombre,descuento) VALUES('Ocasional','0.00')")
            conn.Execute("INSERT INTO cliente_tipo(nombre,descuento) VALUES('Frecuente','0.00')")
            conn.Execute("INSERT INTO cliente(id_persona,id_empresa,id_domicilio,id_telefono,id_tipo,fecha_alta,fecha_modificacion) VALUES(0,1,1,0,1,NOW(),NOW())")
            conn.Execute("INSERT INTO cliente_credito(id_cliente,credito,limite,limite_credito) VALUES(1,0,0,'0.00')")
            conn.Execute("INSERT INTO cliente_precio(id_cliente,id_catalogo_precio,autorizacion) VALUES(1,0,0)")
            '--------------------------------------------------------
            '---USUARIO ADMINISTRADOR DE SISTEMA---------------------
            conn.Execute("INSERT INTO perfil(nombre,usuarios,cuentas_bancarias,impuestos,productos,catalogo,sucursal,almacenes,directorio,directorio_soloalta,cotizaciones,compras,compras_rapidas,pedidos,caja,pagos,facturacion,punto_venta,cobros_creditos,corte_caja,corte_x,cancelar_venta,cancelar_pagos,precio_especial,regalias,cambio_precio,cobro_terminal,pago_proveedores_terminal,recepcion_producto_terminal,ajuste_inventario,clasificacion_productos,favoritos,conversiones,programacion_pedidos,vehiculos,repartidores,catalogo_precios,perfiles_impresion,cfg_conversiones,cfg_empresa,traspasos_env,traspasos_recep) " & _
                                      "VALUES('ADMINISTRADOR',1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1)")
            conn.Execute("INSERT INTO persona(titulo,nombre,ap_paterno,ap_materno,rfc,email,fecha_nacimiento,alias) VALUES('ING.','ADMINISTRADOR','SUPER','','','',NOW(),'ADMINISTRADOR')")
            conn.Execute("INSERT INTO empleado_puesto(nombre) VALUES('ADMINISTRADOR')")
            conn.Execute("INSERT INTO empleado(curp,id_persona,id_domicilio,id_puesto,puesto,fecha_alta,fecha_modificacion,id_sucursal) VALUES('',1,1,1,'',NOW(),NOW(),0)")
            conn.Execute("INSERT INTO perfil_empleado(id_perfil,id_empleado) VALUES(1,1)")
            conn.Execute("INSERT INTO usuario_cuenta(nombre) VALUES('Super Adminstrador')")
            conn.Execute("INSERT INTO usuario_cuenta(nombre) VALUES('Adminstrador')")
            conn.Execute("INSERT INTO usuario_cuenta(nombre) VALUES('Vendedor')")
            conn.Execute("INSERT INTO usuario_cuenta(nombre) VALUES('Cliente')")
            conn.Execute("INSERT INTO usuario_cuenta(nombre) VALUES('Soporte')")
            conn.Execute("INSERT INTO usuario(usuario,password,activo,id_cuenta,id_empleado) VALUES('ADMIN','9062f8de21a652fc56516789d04bb21c',1,1,1)")
            '--------------------------------------------------------
            '---configuraciones generales
            conn.Execute("INSERT INTO categoria(nombre,super,fecha_alta,fecha_modificacion,nivel) VALUES('NO CLASF.',0,NOW(),NOW(),1)")
            conn.Execute("INSERT INTO cfg_colores(cfg_1,cfg_2,cfg_3,cfg_4,cfg_5,cfg_6,cfg_7,cfg_8,cfg_9,cfg_10,cfg_11,cfg_12,cfg_13,cfg_14,cfg_15,cfg_16,cfg_17,cfg_18,cfg_19,cfg_20,cfg_21,cfg_22,cfg_23,cfg_24,cfg_25,cfg_26,cfg_27,cfg_28) VALUES('-1','0','0','0','0','0','0','-1','0','0','0','0','-16777216','-1','0','0','0','0','0','0','0','0','-1','0','0','0','0','0')")
            conn.Execute("INSERT INTO cfg_lineas_ticket(id_tipo,descripcion) VALUES(1,'EMPRESA DEMOSTRATIVA')")
            conn.Execute("INSERT INTO cfg_lineas_ticket(id_tipo,descripcion) VALUES(1,'DOMICILIO')")
            conn.Execute("INSERT INTO cfg_lineas_ticket(id_tipo,descripcion) VALUES(1,'RFC')")
            conn.Execute("INSERT INTO cfg_lineas_ticket(id_tipo,descripcion) VALUES(1,'TELEFONO')")
            conn.Execute("INSERT INTO cfg_lineas_ticket(id_tipo,descripcion) VALUES(0,'GRACIAS POR SU COMPRA')")
            'Para guardar SELECT * FROM configuracion  INTO OUTFILE "D:/QUESERIA/Queseria 3.1/conf.txt" FIELDS TERMINATED BY '1986' LINES TERMINATED BY '\n\r';
            'conn.Execute("INSERT INTO configuracion(razon_social,alias,domicilio,rfc,cfg_color) VALUES('EMPRESA DEMOSTRATIVA','EMPRESA DEMOSTRATIVA','DOMICILIO','RFC','-1')")
            Dim location As String = Replace(Application.StartupPath & "\cfg\conf.txt", "\", "/")
            conn.Execute("LOAD DATA INFILE '" & location & "' INTO TABLE configuracion FIELDS TERMINATED BY '1986' LINES TERMINATED BY '\r\n'")
            rs.Open("SELECT logotipo,logotipo_thumb from configuracion WHERE id_configuracion=1", conn)
            If rs.RecordCount > 0 Then
                Dim bDatos, bDatos2 As Byte()
                Dim logo_default, logo_default_thumb As System.Drawing.Image
                bDatos = CType(rs.Fields("logotipo").Value, Byte())
                bDatos2 = CType(rs.Fields("logotipo_thumb").Value, Byte())
                logo_default = New Bitmap(Bytes_Imagen(bDatos))
                logo_default_thumb = New Bitmap(Bytes_Imagen(bDatos2))
                logo_default.Save(Application.StartupPath & "/logo.png", System.Drawing.Imaging.ImageFormat.Png)
                logo_default_thumb.Save(Application.StartupPath & "/logo.png", System.Drawing.Imaging.ImageFormat.Png)
            End If
            rs.Close()
            conn.Execute("INSERT INTO forma_pago(id_forma_pago,descripcion) VALUES(0,'Efectivo')")
            conn.Execute("INSERT INTO forma_pago(id_forma_pago,descripcion) VALUES(1,'Trasferencia')")
            conn.Execute("INSERT INTO forma_pago(id_forma_pago,descripcion) VALUES(2,'Cheque')")
            conn.Execute("INSERT INTO forma_pago(id_forma_pago,descripcion) VALUES(3,'Nota Credito')")
            conn.Execute("INSERT INTO forma_pago(id_forma_pago,descripcion) VALUES(4,'Tarjeta Bancaria')")
            conn.Execute("INSERT INTO forma_pago(id_forma_pago,descripcion) VALUES(5,'Cupones')")
            conn.Execute("INSERT INTO moneda(nombre,nombre_corto,valor,siglas,rss,fecha_modificacion) VALUES('Peso mexicano','Peso(s)','1.00','MXN',0,NOW())")
            conn.Execute("INSERT INTO moneda(nombre,nombre_corto,valor,siglas,rss,fecha_modificacion) VALUES('Dolar estadounidense','Dolar(es)','12.50','USD',1,NOW())")
            conn.Execute("INSERT INTO moneda(nombre,nombre_corto,valor,siglas,rss,fecha_modificacion) VALUES('Euro','Euro(s)','17.56','EUR',1,NOW())")
            conn.Execute("INSERT INTO precio_nombre(nombre) VALUES('Precio público')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Bicicleta')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Motocicleta')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Automovil')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Camioneta')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Camion')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Trailer')")
            conn.Execute("INSERT INTO tipo_movil(tipo_movil) VALUES('Trailer Semiremolque')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Banamex')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Banca Serfin')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Bancomer')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Banco Inbursa')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Banco Satander Mexicano')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Banorte')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('HSBC')")
            conn.Execute("INSERT INTO banco(descripcion) VALUES('Scotiabank Inverlat')")
            conn.Execute("INSERT INTO cfg_descuento(porcentaje,fecha_inicio,fecha_termino) VALUES('0',NOW(),NOW())")
            conn.Execute("INSERT INTO cfg_punto_venta(cfg_pago_express,cfg_activar_bascula,cfg_varias_lineas) VALUES(0,0,0)")
            conn.Execute("INSERT INTO cfg_punto_venta(cfg_pago_express,cfg_activar_bascula,cfg_varias_lineas) VALUES(0,0,0)")
            conn.Execute("INSERT INTO servidores_smtp(servidor_smtp,correo_smtp,habilitar_ssl) VALUES('smtp.live.com','correo@hotmail.com','1')")
            conn.Execute("INSERT INTO servidores_smtp(servidor_smtp,correo_smtp,habilitar_ssl) VALUES('smtp.gmail.com','correo@gmail.com','1')")
            conn.Execute("INSERT INTO servidores_smtp(servidor_smtp,correo_smtp,habilitar_ssl) VALUES('out.izymail.com','correo@yahoo.com','0')")
            conn.Execute("INSERT INTO cfg_correo(nombre_dest) VALUES('Usuario')")
            conn.Execute("INSERT INTO domicilio(calle,colonia,municipio,cp,poblacion,estado,pais) VALUES('CALLE','COLONIA','MUNICIPIO','00000','POBLACION','ESTADO','PAIS')")
            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Dim id_domicilio_sucursal = rs.Fields(0).Value
            rs.Close()
            conn.Execute("INSERT INTO sucursal(id_domicilio,alias,servidor,servidor_usuario,servidor_password) VALUES('" & id_domicilio_sucursal & "','MATRIZ','localhost','root','admin')")
            rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Dim id_sucursal = rs.Fields(0).Value
            rs.Close()
            conn.Execute("UPDATE configuracion SET id_sucursal='" & id_sucursal & "'")
            conn.Execute("UPDATE empleado SET id_sucursal='" & id_sucursal & "'")
            conn.Execute("INSERT INTO almacenes(Nombre,Calle,Colonia,Localidad,Telefono,Responsable,id_sucursal,num_almacen,default_ventas) VALUES('Principal','Calle','Colonia','Localidad','Telefono','Responsable','" & id_sucursal & "','0000','1')")
            '----------------------------
            'conn.close()

            'conn = Nothing
            MsgBox("Valores restablecidos correctamente.Salga y vuelva a entrar al sistema", MsgBoxStyle.Information, "correcto")
        End If

    End Sub

    Private Sub btn_eliminar_todas_ventas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_todas_ventas.Click
        If MsgBox("Esta operacion eliminara todas las ventas realizadas en el sistema. Esta operacion es irreversible, se recomienda hacer un respaldo de la base de datos. ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            conn.Execute("TRUNCATE TABLE venta")
            conn.Execute("TRUNCATE TABLE venta_detalle")
            conn.Execute("TRUNCATE TABLE pagos_ventas")
            conn.Execute("TRUNCATE TABLE caja_saldo_inicial")
            conn.Execute("TRUNCATE TABLE cortes")
            conn.Execute("TRUNCATE TABLE corte_declaracion")
            conn.Execute("TRUNCATE TABLE corte_detalle")
            conn.Execute("TRUNCATE TABLE devoluciones")
            conn.Execute("TRUNCATE TABLE devoluciones_detalle")
            conn.Execute("TRUNCATE TABLE depositos")
            conn.Execute("TRUNCATE TABLE retiros")

            'conn.close()
            MsgBox("Valores restablecidos correctamente.Salga y vuelva a entrar al sistema", MsgBoxStyle.Information, "correcto")
        End If
    End Sub

    Private Sub frm_godmode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
    End Sub
    Private Sub truncate_all_tables()
        'Conectar()
        conn.Execute("TRUNCATE TABLE agente_entrega")
        conn.Execute("TRUNCATE TABLE ajuste_inventario")
        conn.Execute("TRUNCATE TABLE almacenes")
        conn.Execute("TRUNCATE TABLE banco")
        conn.Execute("TRUNCATE TABLE banco_cuentas")
        conn.Execute("TRUNCATE TABLE caja_saldo_inicial")
        conn.Execute("TRUNCATE TABLE catalogo_precios")
        conn.Execute("TRUNCATE TABLE categoria")
        conn.Execute("TRUNCATE TABLE categoria_cat_imp")
        conn.Execute("TRUNCATE TABLE cfg_colores")
        conn.Execute("TRUNCATE TABLE cfg_correo")
        conn.Execute("TRUNCATE TABLE cfg_descuento")
        conn.Execute("TRUNCATE TABLE cfg_descuento_cat")
        conn.Execute("TRUNCATE TABLE cfg_lineas_ticket")
        conn.Execute("TRUNCATE TABLE cfg_punto_venta")
        conn.Execute("TRUNCATE TABLE cliente")
        conn.Execute("TRUNCATE TABLE cliente_credito")
        conn.Execute("TRUNCATE TABLE cliente_cuenta")
        conn.Execute("TRUNCATE TABLE cliente_precio")
        conn.Execute("TRUNCATE TABLE cliente_productos")
        conn.Execute("TRUNCATE TABLE cliente_tipo")
        conn.Execute("TRUNCATE TABLE configuracion")
        conn.Execute("TRUNCATE TABLE cortes")
        conn.Execute("TRUNCATE TABLE cotizacion_detalle")
        conn.Execute("TRUNCATE TABLE cotizacion")
        conn.Execute("TRUNCATE TABLE detalle_pedido")
        conn.Execute("TRUNCATE TABLE devoluciones")
        conn.Execute("TRUNCATE TABLE devoluciones_detalle")
        conn.Execute("TRUNCATE TABLE empleado_puesto")
        conn.Execute("TRUNCATE TABLE empleado_tel")
        conn.Execute("TRUNCATE TABLE empleado_horario")
        conn.Execute("TRUNCATE TABLE empleado_jornada")
        conn.Execute("TRUNCATE TABLE empleado_opciones")
        conn.Execute("TRUNCATE TABLE empresa_contacto")
        conn.Execute("TRUNCATE TABLE empresa_tel")
        conn.Execute("TRUNCATE TABLE factura_compra")
        conn.Execute("TRUNCATE TABLE factura_compra_detalle")
        conn.Execute("TRUNCATE TABLE factura_detalle")
        conn.Execute("TRUNCATE TABLE factura_electronica")
        conn.Execute("TRUNCATE TABLE factura_electronica_detalle")
        conn.Execute("TRUNCATE TABLE factura")
        conn.Execute("TRUNCATE TABLE forma_pago")
        conn.Execute("TRUNCATE TABLE impuesto")
        conn.Execute("TRUNCATE TABLE impuesto_catalogo")
        conn.Execute("TRUNCATE TABLE moneda")
        conn.Execute("TRUNCATE TABLE moviles")
        conn.Execute("TRUNCATE TABLE pagos_compras")
        conn.Execute("TRUNCATE TABLE pagos_ventas")
        conn.Execute("TRUNCATE TABLE pedido_clientes")
        conn.Execute("TRUNCATE TABLE pedido_prog")
        conn.Execute("TRUNCATE TABLE pedido_prog_detalle")
        conn.Execute("TRUNCATE TABLE perfil")
        conn.Execute("TRUNCATE TABLE perfil_empleado")
        conn.Execute("TRUNCATE TABLE perfil_impresion")
        conn.Execute("TRUNCATE TABLE perfil_impresion_campos")
        conn.Execute("TRUNCATE TABLE perfil_proveedor")
        conn.Execute("TRUNCATE TABLE persona_tel")
        conn.Execute("TRUNCATE TABLE precio_nombre")
        conn.Execute("TRUNCATE TABLE producto_cat_imp")
        conn.Execute("TRUNCATE TABLE producto_compuesto")
        conn.Execute("TRUNCATE TABLE producto_equivalente")
        conn.Execute("TRUNCATE TABLE producto_marca")
        conn.Execute("TRUNCATE TABLE producto_talla")
        conn.Execute("TRUNCATE TABLE producto_paquete")
        conn.Execute("TRUNCATE TABLE producto_recepcion")
        conn.Execute("TRUNCATE TABLE producto_sucursal")
        conn.Execute("TRUNCATE TABLE producto_volumen")
        conn.Execute("TRUNCATE TABLE producto_costo")
        conn.Execute("TRUNCATE TABLE producto_modificador")
        conn.Execute("TRUNCATE TABLE proveedor")
        conn.Execute("TRUNCATE TABLE proveedor_cuenta")
        conn.Execute("TRUNCATE TABLE proveedor_productos")
        conn.Execute("TRUNCATE TABLE retiros")
        conn.Execute("TRUNCATE TABLE servidores_smtp")
        conn.Execute("TRUNCATE TABLE sucursal")
        conn.Execute("TRUNCATE TABLE sucursal_tel")
        conn.Execute("TRUNCATE TABLE temp_venta")
        conn.Execute("TRUNCATE TABLE temp_venta_detalle")
        conn.Execute("TRUNCATE TABLE tipo_movil")
        conn.Execute("TRUNCATE TABLE traspaso_env")
        conn.Execute("TRUNCATE TABLE traspaso_env_detalle")
        conn.Execute("TRUNCATE TABLE traspaso_recep")
        conn.Execute("TRUNCATE TABLE traspaso_recep_detalle")
        conn.Execute("TRUNCATE TABLE unidad")
        conn.Execute("TRUNCATE TABLE usuario")
        conn.Execute("TRUNCATE TABLE usuario_cuenta")
        conn.Execute("TRUNCATE TABLE venta")
        conn.Execute("TRUNCATE TABLE venta_detalle")
        conn.Execute("TRUNCATE TABLE empleado")
        conn.Execute("TRUNCATE TABLE empresa")
        conn.Execute("TRUNCATE TABLE persona")
        conn.Execute("TRUNCATE TABLE producto_precio")
        conn.Execute("TRUNCATE TABLE producto")
        conn.Execute("TRUNCATE TABLE domicilio")
        conn.Execute("TRUNCATE TABLE apartado")
        conn.Execute("TRUNCATE TABLE devoluciones_proveedor")
        conn.Execute("TRUNCATE TABLE devoluciones_proveedor_detalle")
        conn.Execute("TRUNCATE TABLE modificadores")
        conn.Execute("TRUNCATE TABLE paquete_modificador_producto")
        conn.Execute("TRUNCATE TABLE telefono")
        'conn.close()
        'conn = Nothing
    End Sub

    Private Sub btn_eliminar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_clientes.Click
        If MsgBox("Esta operación eliminara todos los clientes del sistema. Esta operacion es irreversible, se recomienda hacer un respaldo de la base de datos. ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            rs.Open("SELECT id_cliente FROM cliente WHERE id_cliente<>1", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    eliminar_cliente(rs.Fields("id_cliente").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            MsgBox("Clientes eliminados correctamente.Salga y vuelva a entrar al sistema", MsgBoxStyle.Information, "correcto")
        End If
    End Sub
    Private Sub eliminar_cliente(ByVal id_cliente As Integer)

        Dim rx As New ADODB.Recordset
        Dim rz As New ADODB.Recordset
        Dim rw As New ADODB.Recordset
        rw.Open("SELECT id_persona,id_empresa,id_domicilio,id_telefono FROM cliente WHERE id_cliente=" & id_cliente, conn)
        If rw.RecordCount > 0 Then
            conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rw.Fields("id_telefono").Value)

            '---eliminamos empresa-----

            rx.Open("SELECT id_telefono FROM empresa_tel WHERE id_empresa=" & rw.Fields("id_empresa").Value, conn)
            If rx.RecordCount > 0 Then
                conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rx.Fields("id_telefono").Value)
            End If
            rx.Close()
            conn.Execute("DELETE FROM empresa_tel WHERE id_empresa=" & rw.Fields("id_empresa").Value)
            rx.Open("SELECT id_persona FROM empresa_contacto WHERE id_empresa=" & rw.Fields("id_empresa").Value, conn)
            If rx.RecordCount > 0 Then
                conn.Execute("DELETE FROM persona WHERE id_persona=" & rx.Fields("id_persona").Value)
                rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value, conn)
                If rz.RecordCount > 0 Then
                    conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                End If
                rz.Close()
                conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value)

            End If
            rx.Close()
            conn.Execute("DELETE FROM empresa_contacto WHERE id_empresa=" & rw.Fields("id_empresa").Value)
            conn.Execute("DELETE FROM empresa WHERE id_empresa=" & rw.Fields("id_empresa").Value)
            '-------------------------
            '---eliminamos persona-----
            rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rw.Fields("id_persona").Value, conn)
            If rz.RecordCount > 0 Then
                conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
            End If
            rz.Close()
            conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rw.Fields("id_persona").Value)
            conn.Execute("DELETE FROM persona WHERE id_persona=" & rw.Fields("id_persona").Value)
            '-------------------------
            conn.Execute("DELETE FROM cliente WHERE id_cliente=" & id_cliente)
            conn.Execute("DELETE FROM domicilio WHERE id_domicilio=" & rw.Fields("id_domicilio").Value)
        End If
        rw.Close()
        conn.Execute("DELETE FROM cliente_cuenta WHERE id_cliente=" & id_cliente)
        conn.Execute("DELETE FROM cliente_productos WHERE id_cliente=" & id_cliente)
        conn.Execute("DELETE FROM cliente_credito WHERE id_cliente=" & id_cliente)
        conn.Execute("DELETE FROM cliente_precio WHERE id_cliente=" & id_cliente)

    End Sub

    Private Sub btn_seleccionar_archivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_seleccionar_archivo.Click
        Dim stRuta As String = "" 
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                stRuta = .FileName
                lbl_archivo.Text = stRuta
            End If
        End With
        'Try
        Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";")))
        'este es el codigo que funciona para office 2007 y 2010 
        Dim cnConex As New OleDbConnection(stConexion)
        Dim Cmd As New OleDbCommand("Select * From [clientes$]")
        Dim Ds As New DataSet
        Dim Da As New OleDbDataAdapter
        Dim Dt As New DataTable
        cnConex.Open()
        Cmd.Connection = cnConex
        Da.SelectCommand = Cmd
        Da.Fill(Ds)
        Dt = Ds.Tables(0)
        Me.dgv_clientes.Columns.Clear()
        Me.dgv_clientes.DataSource = Dt
        'Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Private Sub btn_agregar_clientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_clientes.Click
        Dim id_cliente As Integer
        Dim id_domicilio_cliente As Integer
        Dim id_persona_cliente As Integer
        Dim id_telefono_cliente As Integer
        Dim id_empresa_cliente As Integer
        'Try


        If dgv_clientes.Rows.Count > 0 Then


            For x = 0 To dgv_clientes.Rows.Count - 1
                id_cliente = 0
                id_domicilio_cliente = 0
                id_persona_cliente = 0
                id_telefono_cliente = 0
                id_empresa_cliente = 0

                If Trim(dgv_clientes.Rows(x).Cells(0).Value()) <> "" Then

                    '=guardamos el domicilio========================================
                    conn.Execute("INSERT INTO domicilio(calle,num_ext,num_int,colonia,municipio,cp,poblacion,estado,pais) VALUES ('" & dgv_clientes.Rows(x).Cells(5).Value() & "','" & dgv_clientes.Rows(x).Cells(6).Value() & "','" & dgv_clientes.Rows(x).Cells(7).Value() & "','" & dgv_clientes.Rows(x).Cells(9).Value() & "', '" & dgv_clientes.Rows(x).Cells(11).Value() & "', '" & dgv_clientes.Rows(x).Cells(8).Value() & "', '" & dgv_clientes.Rows(x).Cells(10).Value() & "', '" & dgv_clientes.Rows(x).Cells(12).Value() & "', '" & dgv_clientes.Rows(x).Cells(13).Value() & "')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_domicilio_cliente = rs.Fields(0).Value
                    rs.Close()
                    '===============================================================

                    If dgv_clientes.Rows(x).Cells(0).Value() = "FISICO" Then
                        Dim total_palabras As Integer = obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value())
                        Dim nombre As String = ""
                        Dim ap_paterno As String = ""
                        Dim ap_materno As String = ""
                        If total_palabras >= 3 Then
                            ap_materno = obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value(), total_palabras)
                            ap_paterno = obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value(), total_palabras - 1)
                            For w = 1 To total_palabras - 2
                                nombre &= obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value(), w) & " "
                                If w <> total_palabras - 2 Then
                                    nombre &= " "
                                End If
                            Next
                        ElseIf total_palabras = 2 Then
                            ap_materno = ""
                            ap_paterno = obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value(), total_palabras)
                            nombre = obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value(), total_palabras - 1)
                        ElseIf total_palabras = 1 Then
                            ap_materno = ""
                            ap_paterno = ""
                            nombre = obtener_nombre(dgv_clientes.Rows(x).Cells(3).Value(), total_palabras)

                        End If
                        '=======================CLIENTE FISICO===============================
                        conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,rfc,email,alias) VALUES ('" & Trim(nombre) & "', '" & Trim(ap_paterno) & "', '" & Trim(ap_materno) & "', '" & dgv_clientes.Rows(x).Cells(2).Value() & "', '" & dgv_clientes.Rows(x).Cells(16).Value() & "','" & dgv_clientes.Rows(x).Cells(4).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_persona_cliente = rs.Fields(0).Value
                        rs.Close()

                        conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dgv_clientes.Rows(x).Cells(14).Value() & "','" & dgv_clientes.Rows(x).Cells(15).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_telefono_cliente = rs.Fields(0).Value
                        conn.Execute("INSERT INTO persona_tel (id_telefono,id_persona)  VALUES ('" & rs.Fields(0).Value & "','" & id_persona_cliente & "')")
                        rs.Close()
                        id_empresa_cliente = 0

                    ElseIf dgv_clientes.Rows(x).Cells(0).Value() = "MORAL" Then
                        '============================CLIENTE MORAL==================================
                        conn.Execute("INSERT INTO empresa (razon_social,alias,id_domicilio,url,rfc,email) VALUES ('" & dgv_clientes.Rows(x).Cells(3).Value & "', '" & dgv_clientes.Rows(x).Cells(4).Value & "', " & id_domicilio_cliente & ", '', '" & dgv_clientes.Rows(x).Cells(2).Value & "','" & dgv_clientes.Rows(x).Cells(16).Value & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_empresa_cliente = rs.Fields(0).Value
                        rs.Close()

                        conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dgv_clientes.Rows(x).Cells(14).Value() & "', '" & dgv_clientes.Rows(x).Cells(15).Value() & "' )")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_telefono_cliente = rs.Fields(0).Value
                        conn.Execute("INSERT INTO empresa_tel (id_empresa,id_telefono) VALUES (" & id_empresa_cliente & ", " & rs.Fields(0).Value & " )")
                        rs.Close()

                        id_persona_cliente = 0

                    End If
                    '================================GUARDAMOS_CLIENTE
                    conn.Execute("INSERT INTO cliente (clave,id_persona,id_empresa,id_domicilio,id_telefono,id_tipo,fecha_alta,fecha_modificacion) VALUES ( '" & dgv_clientes.Rows(x).Cells(1).Value() & "','" & id_persona_cliente & "','" & id_empresa_cliente & "', '" & id_domicilio_cliente & "','" & id_telefono_cliente & "', '1',NOW(), NOW())")

                    rs.Open("SELECT last_insert_id()", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_cliente = rs.Fields(0).Value
                    rs.Close()
                    '-----guardamos privilegios crediticios del cliente
                    Dim credito As Integer = 0 ' 0 sin credito, 1 con credito
                    Dim limite As Integer = 0 ' 0 sin limite, 1 con limite
                    If Trim(dgv_clientes.Rows(x).Cells(18).Value().ToString) <> "" Then
                        If UCase(Trim(dgv_clientes.Rows(x).Cells(18).Value().ToString)) = "SI" Then
                            credito = 1
                        End If
                    End If
                    conn.Execute("INSERT INTO cliente_credito(id_cliente,credito,limite,limite_credito) VALUES (' " & id_cliente & "','" & credito & "', '" & limite & "', '0' )")
                    '------------------------------------------------
                    '-----guardamos precio del cliente
                    Dim id_catalogo_precio As Integer = 0
                    Dim cantidad_precio As Integer = 0
                    Dim rq As New ADODB.Recordset
                    rs.Open("SELECT id_ctlg_precios FROM ctlg_precios WHERE nombre='" & Trim(dgv_clientes.Rows(x).Cells(17).Value().ToString) & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_catalogo_precio = rs.Fields("id_ctlg_precios").Value
                    End If
                    rs.Close()
                    If Trim(dgv_clientes.Rows(x).Cells(17).Value().ToString) <> "" Then
                        If id_catalogo_precio = 0 Then
                            rs.Open("SELECT id_ctlg_precios FROM ctlg_precios", conn)
                            cantidad_precio = rs.RecordCount
                            rs.Close()
                            If cantidad_precio > 0 Then

                                Dim id_catalogo_precio_ultimo As Integer
                                Dim utilidad_ultimo As Decimal = 2
                                rs.Open("SELECT id_ctlg_precios,utilidad FROM ctlg_precios ORDER BY id_ctlg_precios DESC LIMIT 1", conn)
                                If rs.RecordCount > 0 Then
                                    id_catalogo_precio_ultimo = rs.Fields("id_ctlg_precios").Value
                                    If rs.Fields("utilidad").Value > 0 Then
                                        utilidad_ultimo = rs.Fields("utilidad").Value
                                    End If
                                End If
                                rs.Close()

                                conn.Execute("INSERT INTO ctlg_precios(nombre,utilidad) VALUES('" & dgv_clientes.Rows(x).Cells(17).Value() & "','" & utilidad_ultimo - 1 & "')")
                                rs.Open("SELECT last_insert_id()", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                                id_catalogo_precio = rs.Fields(0).Value
                                rs.Close()

                                rs.Open("SELECT id_producto FROM producto", conn)
                                If rs.RecordCount > 0 Then
                                    While Not rs.EOF
                                        conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final) VALUES('" & dgv_clientes.Rows(x).Cells(17).Value() & "','" & id_catalogo_precio & "','" & utilidad_ultimo - 1 & "','0','" & rs.Fields("id_producto").Value & "','0','10000000')")
                                        rs.MoveNext()
                                    End While
                                End If
                                rs.Close()
                            Else
                                conn.Execute("INSERT INTO ctlg_precios(nombre,utilidad) VALUES('" & dgv_clientes.Rows(x).Cells(17).Value() & "','100')")
                                rs.Open("SELECT last_insert_id()", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                                id_catalogo_precio = rs.Fields(0).Value
                                rs.Close()
                                rs.Open("SELECT id_producto FROM producto", conn)
                                If rs.RecordCount > 0 Then
                                    While Not rs.EOF
                                        conn.Execute("INSERT INTO producto_volumen(nombre,id_catalogo_precio,utilidad,descuento,id_producto,rango_inicial,rango_final) VALUES('" & dgv_clientes.Rows(x).Cells(17).Value() & "','" & id_catalogo_precio & "','100','0','" & rs.Fields("id_producto").Value & "','1','10000000')")
                                        rs.MoveNext()
                                    End While
                                End If
                                rs.Close()
                            End If
                        End If

                    End If
                    conn.Execute("INSERT INTO cliente_precio(id_cliente,id_ctlg_precios,autorizacion, aplicar_redondeo) VALUES (' " & id_cliente & "','" & id_catalogo_precio & "', '0','1')")
                    '------------------------------------------------
                End If
            Next
            MsgBox("Registros ingresados correctamente")
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try






    End Sub
    Private Function obtener_nombre(ByVal nombre As String, Optional ByVal posicion As Integer = 0) As String
        Dim palabra As String = ""
        Dim contador As Integer ' numero de palabras
        Dim fin As Integer() = {0, 0, 0, 0, 0, 0, 0}



        Dim i As Integer
        For i = 1 To Len(nombre)
            If Mid(nombre, i, 1) = " " Then
                contador = contador + 1
            End If
        Next

        For x = 1 To contador

            If x = 1 Then
                fin(x) = nombre.IndexOf(" ", 1)
            Else
                fin(x) = nombre.IndexOf(" ", fin(x - 1) + 1)
            End If

        Next
        fin(contador + 1) = Len(nombre)

        If posicion = 0 Then
            palabra = contador + 1
        ElseIf posicion = 1 Then
            palabra = nombre.Substring(0, fin(1))
        ElseIf posicion = 2 Then
            palabra = nombre.Substring(fin(1), fin(2) - fin(1))
        ElseIf posicion = 3 Then
            palabra = nombre.Substring(fin(2), fin(3) - fin(2))
        ElseIf posicion = 4 Then
            palabra = nombre.Substring(fin(3), fin(4) - fin(3))
        ElseIf posicion = 5 Then
            palabra = nombre.Substring(fin(4), fin(5) - fin(4))
        ElseIf posicion = 6 Then
            palabra = nombre.Substring(fin(5), fin(6) - fin(5))
        End If
        Return palabra
    End Function

    Private Sub btn_establecer_costos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_establecer_costos.Click
        If MsgBox("Esta operación eliminara todo el historico de costo y establecera el costo actual como unico. Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("TRUNCATE TABLE producto_costo")
            rs.Open("SELECT id_producto,costo,fecha_alta FROM producto", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES('" & rs.Fields("id_producto").Value & "','" & rs.Fields("costo").Value & "','" & Format(rs.Fields("fecha_alta").Value, "yyyy-MM-dd hh:mm:ss") & "')")
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End If

    End Sub

    Private Sub btn_eliminar_pedidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_pedidos.Click
        If MsgBox("Esta operación eliminara el historico de pedidos, los pedidos actuales y la programación de pedidos. Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'conn.Execute("TRUNCATE TABLE detalle_pedido")
            conn.Execute("TRUNCATE TABLE pedido_clientes")
            conn.Execute("TRUNCATE TABLE pedido_prog_detalle")
            conn.Execute("TRUNCATE TABLE pedido_prog")
            MsgBox("Todos los pedidos han sido eliminados", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_eliminar_compras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_compras.Click
        If MsgBox("Esta operación eliminara el historico de compras. Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("TRUNCATE TABLE factura_compra")
            conn.Execute("TRUNCATE TABLE factura_compra_detalle")
            conn.Execute("TRUNCATE TABLE pagos_compras")
            MsgBox("Todas los compras han sido eliminadas", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_examinar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_examinar_productos.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                stRuta = .FileName
                lbl_archivo_productos.Text = stRuta
            End If
        End With
        'Try
        Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";")))
        'este es el codigo que funciona para office 2007 y 2010 
        Dim cnConex As New OleDbConnection(stConexion)
        Dim Cmd As New OleDbCommand("Select * From [productos$]")
        Dim Ds As New DataSet
        Dim Da As New OleDbDataAdapter
        Dim Dt As New DataTable
        cnConex.Open()
        Cmd.Connection = cnConex
        Da.SelectCommand = Cmd
        Da.Fill(Ds)
        Dt = Ds.Tables(0)
        Me.dgv_productos.Columns.Clear()
        Me.dgv_productos.DataSource = Dt
        ' Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        ' End Try
    End Sub

    Private Sub btn_agregar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_productos.Click
        pb_avance.Maximum = dgv_productos.Rows.Count

        Dim id_producto As Integer
        Dim id_unidad As Integer
        Dim id_marca As Integer
        Dim id_precio As Integer
        Dim id_categoria As Integer
        Dim id_modelo As Integer
        Dim id_clavesat As Integer
        Dim id_talla As Integer
        Dim id_color As Integer

        'Try


        If dgv_productos.Rows.Count > 0 Then

            For x = 0 To dgv_productos.Rows.Count - 1
                id_producto = 0
                id_unidad = 0
                id_marca = 0
                id_precio = 0
                id_categoria = 0
                id_modelo = 0
                id_clavesat = 0
                id_talla = 0
                id_color = 0

                If Trim(dgv_productos.Rows(x).Cells(1).Value()) <> "" Then ' FILA DE NOMBRE DE PRODUCTO
                    '====================INSERTAMOS PRODUCTO

                    '=====================buscamos y gregamos unidad============
                    rs.Open("SELECT id_unidad FROM unidad WHERE nombre='" & dgv_productos.Rows(x).Cells(4).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_unidad = rs.Fields("id_unidad").Value
                    End If
                    rs.Close()
                    If id_unidad = 0 Then
                        conn.Execute("INSERT INTO unidad (clave,nombre) VALUES ('" & dgv_productos.Rows(x).Cells(13).Value() & "','" & dgv_productos.Rows(x).Cells(4).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_unidad = rs.Fields(0).Value
                        rs.Close()
                    End If
                    '======================agregamos marca============
                    rs.Open("SELECT id_marca FROM producto_marca WHERE nombre='" & dgv_productos.Rows(x).Cells(6).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_marca = rs.Fields("id_marca").Value
                    End If
                    rs.Close()
                    If id_marca = 0 Then
                        conn.Execute("INSERT INTO producto_marca (nombre) VALUES ('" & dgv_productos.Rows(x).Cells(6).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_marca = rs.Fields(0).Value
                        rs.Close()
                    End If
                    '======================agregamos modelo============
                    rs.Open("SELECT id_modelo FROM producto_modelo WHERE nombre='" & dgv_productos.Rows(x).Cells(7).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_modelo = rs.Fields("id_modelo").Value
                    End If
                    rs.Close()

                    If id_modelo = 0 Then
                        conn.Execute("INSERT INTO producto_modelo (nombre) VALUES ('" & dgv_productos.Rows(x).Cells(7).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_modelo = rs.Fields(0).Value
                        rs.Close()
                    End If

                    '======================agregamos talla============
                    rs.Open("SELECT id_talla FROM producto_talla WHERE nombre='" & dgv_productos.Rows(x).Cells(8).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_talla = rs.Fields("id_talla").Value
                    End If
                    rs.Close()

                    If id_talla = 0 Then
                        conn.Execute("INSERT INTO producto_talla (nombre) VALUES ('" & dgv_productos.Rows(x).Cells(8).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_talla = rs.Fields(0).Value
                        rs.Close()
                    End If
                    '==============================================
                    '======================agregamos color============
                    rs.Open("SELECT id_color FROM producto_color WHERE nombre='" & dgv_productos.Rows(x).Cells(9).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_color = rs.Fields("id_color").Value
                    End If
                    rs.Close()

                    If id_color = 0 Then
                        conn.Execute("INSERT INTO producto_color (nombre) VALUES ('" & dgv_productos.Rows(x).Cells(9).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_color = rs.Fields(0).Value
                        rs.Close()
                    End If
                    '==============================================
                    '======================agregamos clave sat producto/servicio============
                    rs.Open("SELECT id_clavesat FROM producto_clavesat WHERE clave='" & dgv_productos.Rows(x).Cells(14).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_clavesat = rs.Fields("id_clavesat").Value
                    End If
                    rs.Close()

                    If id_clavesat = 0 Then
                        conn.Execute("INSERT INTO producto_clavesat (clave,nombre) VALUES ('" & dgv_productos.Rows(x).Cells(14).Value() & "','" & dgv_productos.Rows(x).Cells(15).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_clavesat = rs.Fields(0).Value
                        rs.Close()
                    End If

                    '===========================================agregamos la categoria==============================================
                    rs.Open("SELECT id_categoria FROM categoria WHERE nombre='" & dgv_productos.Rows(x).Cells(3).Value() & "'", conn)
                    If rs.RecordCount > 0 Then
                        id_categoria = rs.Fields("id_categoria").Value
                    End If
                    rs.Close()
                    If id_categoria = 0 Then
                        conn.Execute("INSERT INTO categoria (nombre,super,fecha_alta) VALUES ('" & dgv_productos.Rows(x).Cells(3).Value() & "','0',NOW())")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_categoria = rs.Fields(0).Value
                        rs.Close()
                    End If
                    '======================establecemos codigo del producto===============================
                    Dim codigo As String = ""
                    If Not IsDBNull(dgv_productos.Rows(x).Cells(0).Value()) Then
                        codigo = dgv_productos.Rows(x).Cells(0).Value()
                    End If
                    '====================================================================================================================

                    '============================INSERTAMOS PRODUCTO=========================
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
                    rs2.Fields("nombre").Value = dgv_productos.Rows(x).Cells(1).Value()
                    rs2.Fields("codigo").Value = codigo
                    rs2.Fields("id_unidad").Value = id_unidad
                    rs2.Fields("precio").Value = dgv_productos.Rows(x).Cells(17).Value()
                    rs2.Fields("venta_peso").Value = dgv_productos.Rows(x).Cells(5).Value()
                    rs2.Fields("id_categoria").Value = id_categoria
                    rs2.Fields("descripcion").Value = dgv_productos.Rows(x).Cells(2).Value().ToString
                    rs2.Fields("costo").Value = dgv_productos.Rows(x).Cells(16).Value()
                    rs2.Fields("id_marca").Value = id_marca
                    rs2.Fields("id_modelo").Value = id_modelo
                    rs2.Fields("id_talla").Value = id_talla
                    rs2.Fields("id_color").Value = id_color
                    rs2.Fields("id_clavesat").Value = id_clavesat
                    rs2.Fields("id_almacen").Value = global_current_idalmacen
                    rs2.Fields("id_impuesto").Value = dgv_productos.Rows(x).Cells(10).Value()
                    rs2.Fields("fecha_alta").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                    rs2.Fields("fecha_modificacion").Value = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")
                    rs2.Fields("precio_especial").Value = 0
                    rs2.Fields("precio_especial_inicio").Value = Now()
                    rs2.Fields("precio_especial_termino").Value = Now()
                    rs2.Update()
                    rs2.Close()
                    '-----------------

                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_producto = rs.Fields(0).Value
                    rs.Close()

                    '========================insertamos historico de precios de compra===============
                    conn.Execute("INSERT INTO producto_costo(id_producto,costo,fecha) VALUES('" & id_producto & "','" & dgv_productos.Rows(x).Cells(16).Value() & "','" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "')")


                    '======================================insertamos inventario de producto=====================
                    conn.Execute("INSERT INTO  producto_sucursal (id_producto,id_sucursal,fecha_alta,id_almacen,cantidad_minima,cantidad_maxima,merma) VALUES " & _
                             "('" & id_producto & "','" & global_id_sucursal & "', NOW(),'" & global_current_idalmacen & "','" & dgv_productos.Rows(x).Cells(11).Value() & "','" & dgv_productos.Rows(x).Cells(12).Value() & "','0')")


                    '========================insertamos precios de productos del catalogo existente=============
                    rs.Open("SELECT * FROM ctlg_precios", conn)
                    If rs.RecordCount > 0 Then
                        While Not rs.EOF
                            Dim precio As Decimal = FormatNumber(CDec(dgv_productos.Rows(x).Cells(16).Value()) * ((rs.Fields("utilidad").Value / 100) + 1), 2)
                            conn.Execute("INSERT INTO producto_precio(id_producto,id_ctlg_precios,utilidad,precio) VALUES('" & id_producto & "','" & rs.Fields("id_ctlg_precios").Value & "','" & rs.Fields("utilidad").Value & "','" & precio & "')")
                            rs.MoveNext()
                        End While
                    End If
                    rs.Close()


                    '=================================ACTUALIZAMOS E INGRESAMOS LOS PRECIOS DE LA LISTA DE PRECIOS================================
                    For w = 18 To dgv_productos.Columns.Count - 1
                        If Trim(dgv_productos.Rows(x).Cells(w).Value().ToString) <> "" Then
                            Dim cid_catalogo_precio As Integer = 0
                            Dim descuento As Decimal = 0

                            rs.Open("SELECT id_ctlg_precios FROM ctlg_precios WHERE nombre='" & Trim(dgv_productos.Columns(w).Name) & "'", conn)
                            If rs.RecordCount > 0 Then
                                cid_catalogo_precio = rs.Fields("id_ctlg_precios").Value
                            End If
                            rs.Close()

                            Dim utilidad As Decimal = FormatNumber(((dgv_productos.Rows(x).Cells(w).Value() / dgv_productos.Rows(x).Cells(16).Value()) - 1) * 100, 2)

                            If cid_catalogo_precio = 0 Then
                                '================guardamos como nuevo precio
                                conn.Execute("INSERT INTO ctlg_precios(clave,nombre,utilidad) VALUES('','" & Trim(dgv_productos.Columns(w).Name) & "','0')")
                                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                                cid_catalogo_precio = rs.Fields(0).Value
                                rs.Close()

                                conn.Execute("INSERT INTO producto_precio(id_producto,id_ctlg_precios,utilidad,precio) VALUES('" & id_producto & "','" & cid_catalogo_precio & "','" & utilidad & "','" & dgv_productos.Rows(x).Cells(w).Value() & "')")

                            Else
                                '===============actualizamos el precio  
                                conn.Execute("UPDATE producto_precio SET utilidad='" & utilidad & "',precio='" & dgv_productos.Rows(x).Cells(w).Value() & "' WHERE id_producto='" & id_producto & "' AND id_ctlg_precios='" & cid_catalogo_precio & "' ")

                            End If
                        End If
                    Next
                End If
                pb_avance.Value += 1
                lbl_avance.Text = "Registros ingresados: " & pb_avance.Value & " de " & pb_avance.Maximum & " registros"
            Next
            MsgBox("Registros ingresados correctamente")
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub btn_eliminar_productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_productos.Click
        If MsgBox("Esta operación eliminara todos los productos y la configuracion de productos de clientes y proveedores. Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            If MsgBox("Esta operación requiere eliminar todas las compras, el historico de ventas,pedidos, traspasos,cotizaciones y facturas . Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then


                'venta
                conn.Execute("TRUNCATE TABLE venta")
                conn.Execute("TRUNCATE TABLE venta_detalle")
                conn.Execute("TRUNCATE TABLE pagos_ventas")
                conn.Execute("TRUNCATE TABLE caja_saldo_inicial")
                conn.Execute("TRUNCATE TABLE cortes")
                conn.Execute("TRUNCATE TABLE corte_declaracion")
                conn.Execute("TRUNCATE TABLE corte_detalle")
                conn.Execute("TRUNCATE TABLE devoluciones")
                conn.Execute("TRUNCATE TABLE devoluciones_detalle")
                'pedidos
                conn.Execute("TRUNCATE TABLE detalle_pedido")
                conn.Execute("TRUNCATE TABLE pedido_clientes")
                conn.Execute("TRUNCATE TABLE pedido_prog_detalle")
                conn.Execute("TRUNCATE TABLE pedido_prog")
                'compras
                conn.Execute("TRUNCATE TABLE factura_compra")
                conn.Execute("TRUNCATE TABLE factura_compra_detalle")
                conn.Execute("TRUNCATE TABLE pagos_compras")
                'traspasos
                conn.Execute("TRUNCATE TABLE traspaso_env")
                conn.Execute("TRUNCATE TABLE traspaso_env_detalle")
                conn.Execute("TRUNCATE TABLE traspaso_recep")
                conn.Execute("TRUNCATE TABLE traspaso_recep_detalle")
                'facturas
                conn.Execute("TRUNCATE TABLE factura_detalle")
                conn.Execute("TRUNCATE TABLE factura")
                'cotizaciones
                conn.Execute("TRUNCATE TABLE cotizacion_detalle")
                conn.Execute("TRUNCATE TABLE cotizacion")


                'productos
                conn.Execute("TRUNCATE TABLE cliente_productos")
                conn.Execute("TRUNCATE TABLE proveedor_productos")
                conn.Execute("TRUNCATE TABLE producto_cat_imp")
                conn.Execute("TRUNCATE TABLE producto_compuesto")
                conn.Execute("TRUNCATE TABLE producto_equivalente")
                conn.Execute("TRUNCATE TABLE producto_marca")
                conn.Execute("TRUNCATE TABLE producto_paquete")
                conn.Execute("TRUNCATE TABLE producto_recepcion")
                conn.Execute("TRUNCATE TABLE producto_sucursal")
                conn.Execute("TRUNCATE TABLE producto_volumen")
                conn.Execute("TRUNCATE TABLE producto_precio")
                conn.Execute("TRUNCATE TABLE producto_costo")
                conn.Execute("TRUNCATE TABLE producto_marca")
                conn.Execute("TRUNCATE TABLE producto_modelo")
                conn.Execute("TRUNCATE TABLE producto_talla")
                conn.Execute("TRUNCATE TABLE producto")
                'ajuste_inventario
                conn.Execute("TRUNCATE TABLE ajuste_inventario")
                If MsgBox("Desea eliminar el catalogo de unidades?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    conn.Execute("TRUNCATE TABLE unidad")
                End If
                If MsgBox("Desea eliminar el catalogo de marcas?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    conn.Execute("TRUNCATE TABLE producto_marca")
                End If
                If MsgBox("Desea eliminar el catalogo de categorias?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    conn.Execute("TRUNCATE TABLE categoria")
                    conn.Execute("INSERT INTO categoria(nombre,super,fecha_alta,fecha_modificacion,nivel) VALUES('NO CLASF.',0,NOW(),NOW(),1)")
                End If
                If MsgBox("Desea eliminar el catalogo de precios?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                    conn.Execute("UPDATE cliente_precio SET id_ctlg_precios='0'")
                    conn.Execute("TRUNCATE TABLE producto_volumen")
                    conn.Execute("TRUNCATE TABLE ctlg_precios")
                End If

                MsgBox("Todas los productos han sido eliminados", MsgBoxStyle.Information, "Aviso")
            End If

        End If
    End Sub

    Private Sub btn_eliminar_traspasos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_traspasos.Click
        If MsgBox("Desea eliminar todos los traspasos?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("TRUNCATE TABLE traspaso_env")
            conn.Execute("TRUNCATE TABLE traspaso_env_detalle")
            conn.Execute("TRUNCATE TABLE traspaso_recep")
            conn.Execute("TRUNCATE TABLE traspaso_recep_detalle")
            MsgBox("Todas los traspasos han sido eliminados", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_eliminar_facturas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_facturas.Click
        If MsgBox("Desea eliminar todas las facturas?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("TRUNCATE TABLE factura_detalle")
            conn.Execute("TRUNCATE TABLE factura")
            MsgBox("Todas las facturas han sido eliminadas", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_eliminar_cotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_cotizaciones.Click
        If MsgBox("Desea eliminar todas las cotizaciones?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("TRUNCATE TABLE cotizacion")
            conn.Execute("TRUNCATE TABLE cotizacion_detalle")
            MsgBox("Todas las cotizaciones han sido eliminadas", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_eliminar_catalogo_precios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_catalogo_precios.Click
        If MsgBox("Desea eliminar el catalogo de precios?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("UPDATE cliente_precio SET id_ctlg_precios='0'")
            conn.Execute("TRUNCATE TABLE producto_volumen")
            conn.Execute("TRUNCATE TABLE ctlg_precios")
            MsgBox("El catalogo de precios ha sido eliminado", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_respaldar_bd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_respaldar_bd.Click

        If Not Directory.Exists(directorio_respaldos) Then
            Directory.CreateDirectory(directorio_respaldos)
        End If

        Dim respaldar As New SaveFileDialog
        Dim carpeta As New FolderBrowserDialog

        respaldar.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        'pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.1", "Location", 0)
        'If pathmysql = Nothing Then
        'MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
        'carpeta.ShowDialog()
        'pathmysql = carpeta.SelectedPath
        pathmysql = db_directorio_mysql
        'End If
        respaldar.Filter = "File MYSQL (*.sql)|*.sql"
        respaldar.FileName = "Respaldo-" & lineas_ticket_cabeza(0) & "-" & Format(Date.Today, "dd-MM-yyyy") & "-" & Format(TimeOfDay, "HH-mm-ss")
        respaldar.InitialDirectory = My.Computer.FileSystem.CurrentDirectory & "\Respaldos"
        If respaldar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Try
            comando = pathmysql & "\bin\mysqldump --user=" & db_usuario & " --password=" & db_password & " --databases " & db_nombre & " -r """ & respaldar.FileName & """"
            Shell(comando, AppWinStyle.MinimizedFocus, True)
            'Catch ex As Exception
            'MsgBox("Ocurrio un error al respaldar_ " & ex.Message, MsgBoxStyle.Critical, "Informacion")
            '  End Try
            MsgBox("Base de datos respaldada correctamente", MsgBoxStyle.Information, "Informacion")
        End If
    End Sub

    Private Sub btn_restaurar_bd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_restaurar_bd.Click
        If Not Directory.Exists(directorio_respaldos) Then
            Directory.CreateDirectory(directorio_respaldos)
        End If

        Dim abrir As New OpenFileDialog
        Dim carpeta As New FolderBrowserDialog

        abrir.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        Dim arg As String

        abrir.Filter = "File MYSQL (*.sql)|*.sql"
        abrir.InitialDirectory = My.Computer.FileSystem.CurrentDirectory & "\Respaldos"
        'pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.1", "Location", 0)
        'If pathmysql = Nothing Then
        'MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
        'carpeta.ShowDialog()
        'pathmysql = carpeta.SelectedPath
        pathmysql = db_directorio_mysql
        ' End If
        If abrir.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Try
            comando = pathmysql & "\bin\mysql.exe"
            comando.Replace("\\", "\")
            arg = " --user=" & db_usuario & " --password=" & db_password & " --host=" & db_servidor & " --database " & db_nombre & " < " & Chr(34) & abrir.FileName & Chr(34)
            Dim proceso As New Process
            proceso.StartInfo.FileName = "cmd.exe"
            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            proceso.StartInfo.UseShellExecute = False
            proceso.StartInfo.RedirectStandardOutput = True
            proceso.StartInfo.RedirectStandardInput = True
            proceso.StartInfo.CreateNoWindow = True
            proceso.Start()
            Dim escribeconsola As StreamWriter = proceso.StandardInput
            Dim leyendoconsola As StreamReader = proceso.StandardOutput
            escribeconsola.WriteLine(comando & arg)
            escribeconsola.Close()
            proceso.WaitForExit()
            proceso.Close()
            'Catch ex As Exception
            ' MsgBox("Ocurrio un error al restaurar: " & ex.Message, MsgBoxStyle.Critical, "Informacion")
            ' End Try
            MsgBox("Base de datos restaurada correctamente", MsgBoxStyle.Information, "Informacion")
        End If
    End Sub

    Private Sub btn_eliminar_proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_proveedores.Click
        If MsgBox("Esta operación eliminara todos los proveedores del sistema. Esta operacion es irreversible, se recomienda hacer un respaldo de la base de datos. ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            rs.Open("SELECT id_proveedor FROM proveedor", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    eliminar_proveedor(rs.Fields("id_proveedor").Value)
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            'conn.close()
            'conn = Nothing
            MsgBox("Proveedores eliminados correctamente.Salga y vuelva a entrar al sistema", MsgBoxStyle.Information, "correcto")
        End If
    End Sub
    Private Sub eliminar_proveedor(ByVal id_proveedor As Integer)
        Dim rx As New ADODB.Recordset
        Dim rz As New ADODB.Recordset
        Dim rw As New ADODB.Recordset
        'Conectar()
        rw.Open("SELECT id_persona,id_empresa,id_domicilio FROM proveedor WHERE id_proveedor=" & id_proveedor, conn)
        If rw.RecordCount > 0 Then

            '---eliminamos empresa-----

            rx.Open("SELECT id_telefono FROM empresa_tel WHERE id_empresa=" & rw.Fields("id_empresa").Value, conn)
            If rx.RecordCount > 0 Then
                conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rx.Fields("id_telefono").Value)
            End If
            rx.Close()
            conn.Execute("DELETE FROM empresa_tel WHERE id_empresa=" & rw.Fields("id_empresa").Value)
            rx.Open("SELECT id_persona FROM empresa_contacto WHERE id_empresa=" & rw.Fields("id_empresa").Value, conn)
            If rx.RecordCount > 0 Then
                conn.Execute("DELETE FROM persona WHERE id_persona=" & rx.Fields("id_persona").Value)
                rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value, conn)
                If rz.RecordCount > 0 Then
                    conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
                End If
                rz.Close()
                conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rx.Fields("id_persona").Value)

            End If
            rx.Close()
            conn.Execute("DELETE FROM empresa_contacto WHERE id_empresa=" & rw.Fields("id_empresa").Value)
            conn.Execute("DELETE FROM empresa WHERE id_empresa=" & rw.Fields("id_empresa").Value)
            '-------------------------
            '---eliminamos persona-----
            rz.Open("SELECT id_telefono FROM persona_tel WHERE id_persona=" & rw.Fields("id_persona").Value, conn)
            If rz.RecordCount > 0 Then
                conn.Execute("DELETE FROM telefono WHERE id_telefono=" & rz.Fields("id_telefono").Value)
            End If
            rz.Close()
            conn.Execute("DELETE FROM persona_tel WHERE id_persona=" & rw.Fields("id_persona").Value)
            conn.Execute("DELETE FROM persona WHERE id_persona=" & rw.Fields("id_persona").Value)
            '-------------------------
            conn.Execute("DELETE FROM proveedor WHERE id_proveedor=" & id_proveedor)
            conn.Execute("DELETE FROM domicilio WHERE id_domicilio=" & rw.Fields("id_domicilio").Value)
        End If
        rw.Close()
        conn.Execute("DELETE FROM proveedor_cuenta WHERE id_proveedor=" & id_proveedor)
        conn.Execute("DELETE FROM proveedor_productos WHERE id_proveedor=" & id_proveedor)
    End Sub

    Private Sub dgv_proveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_examinar_proveedores.Click
        Dim stRuta As String = ""
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivos"
            .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                stRuta = .FileName
                lbl_archivo_productos.Text = stRuta
            End If
        End With
        'Try
        Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";")))
        'este es el codigo que funciona para office 2007 y 2010 
        Dim cnConex As New OleDbConnection(stConexion)
        Dim Cmd As New OleDbCommand("Select * From [proveedores$]")
        Dim Ds As New DataSet
        Dim Da As New OleDbDataAdapter
        Dim Dt As New DataTable
        cnConex.Open()
        Cmd.Connection = cnConex
        Da.SelectCommand = Cmd
        Da.Fill(Ds)
        Dt = Ds.Tables(0)
        Me.dgv_proveedores.Columns.Clear()
        Me.dgv_proveedores.DataSource = Dt
        'Catch ex As Exception
        'MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Private Sub btn_agregar_proveedores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregar_proveedores.Click
        Dim id_proveedor As Integer
        Dim id_domicilio_proveedor As Integer
        Dim id_persona_proveedor As Integer
        Dim id_telefono_proveedor As Integer
        Dim id_empresa_proveedor As Integer
        'Try


        If dgv_proveedores.Rows.Count > 0 Then


            For x = 0 To dgv_proveedores.Rows.Count - 1
                id_proveedor = 0
                id_domicilio_proveedor = 0
                id_persona_proveedor = 0
                id_telefono_proveedor = 0
                id_empresa_proveedor = 0

                If Trim(dgv_proveedores.Rows(x).Cells(0).Value()) <> "" Then

                    '=guardamos el domicilio========================================
                    conn.Execute("INSERT INTO domicilio(calle,num_ext,num_int,colonia,municipio,cp,poblacion,estado,pais) VALUES ('" & dgv_proveedores.Rows(x).Cells(5).Value() & "','" & dgv_proveedores.Rows(x).Cells(6).Value() & "','" & dgv_proveedores.Rows(x).Cells(7).Value() & "','" & dgv_proveedores.Rows(x).Cells(9).Value() & "', '" & dgv_proveedores.Rows(x).Cells(11).Value() & "', '" & dgv_proveedores.Rows(x).Cells(8).Value() & "', '" & dgv_proveedores.Rows(x).Cells(10).Value() & "', '" & dgv_proveedores.Rows(x).Cells(12).Value() & "', '" & dgv_proveedores.Rows(x).Cells(13).Value() & "')")
                    rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_domicilio_proveedor = rs.Fields(0).Value
                    rs.Close()
                    '===============================================================

                    If dgv_proveedores.Rows(x).Cells(0).Value() = "FISICO" Then
                        Dim total_palabras As Integer = obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value())
                        Dim nombre As String = ""
                        Dim ap_paterno As String = ""
                        Dim ap_materno As String = ""
                        If total_palabras >= 3 Then
                            ap_materno = obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value(), total_palabras)
                            ap_paterno = obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value(), total_palabras - 1)
                            For w = 1 To total_palabras - 2
                                nombre &= obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value(), w) & " "
                                If w <> total_palabras - 2 Then
                                    nombre &= " "
                                End If
                            Next
                        ElseIf total_palabras = 2 Then
                            ap_materno = ""
                            ap_paterno = obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value(), total_palabras)
                            nombre = obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value(), total_palabras - 1)
                        ElseIf total_palabras = 1 Then
                            ap_materno = ""
                            ap_paterno = ""
                            nombre = obtener_nombre(dgv_proveedores.Rows(x).Cells(3).Value(), total_palabras)

                        End If
                        '=======================CLIENTE FISICO===============================
                        conn.Execute("INSERT INTO persona (nombre,ap_paterno,ap_materno,rfc,email,alias) VALUES ('" & Trim(nombre) & "', '" & Trim(ap_paterno) & "', '" & Trim(ap_materno) & "', '" & dgv_proveedores.Rows(x).Cells(2).Value() & "', '" & dgv_proveedores.Rows(x).Cells(16).Value() & "','" & dgv_proveedores.Rows(x).Cells(4).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_persona_proveedor = rs.Fields(0).Value
                        rs.Close()

                        conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dgv_proveedores.Rows(x).Cells(14).Value() & "','" & dgv_proveedores.Rows(x).Cells(15).Value() & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_telefono_proveedor = rs.Fields(0).Value
                        conn.Execute("INSERT INTO persona_tel (id_telefono,id_persona)  VALUES ('" & rs.Fields(0).Value & "','" & id_persona_proveedor & "')")
                        rs.Close()
                        id_empresa_proveedor = 0

                    ElseIf dgv_proveedores.Rows(x).Cells(0).Value() = "MORAL" Then
                        '============================CLIENTE MORAL==================================
                        conn.Execute("INSERT INTO empresa (razon_social,alias,id_domicilio,url,rfc,email) VALUES ('" & dgv_proveedores.Rows(x).Cells(3).Value & "', '" & dgv_proveedores.Rows(x).Cells(4).Value & "', " & id_domicilio_proveedor & ", '', '" & dgv_proveedores.Rows(x).Cells(2).Value & "','" & dgv_proveedores.Rows(x).Cells(16).Value & "')")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_empresa_proveedor = rs.Fields(0).Value
                        rs.Close()

                        conn.Execute("INSERT INTO telefono (lada,numero) VALUES ('" & dgv_proveedores.Rows(x).Cells(14).Value() & "', '" & dgv_proveedores.Rows(x).Cells(15).Value() & "' )")
                        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                        id_telefono_proveedor = rs.Fields(0).Value
                        conn.Execute("INSERT INTO empresa_tel (id_empresa,id_telefono) VALUES (" & id_empresa_proveedor & ", " & rs.Fields(0).Value & " )")
                        rs.Close()

                        id_persona_proveedor = 0

                    End If
                    '================================GUARDAMOS_CLIENTE
                    conn.Execute("INSERT INTO proveedor (clave,id_persona,id_empresa,id_domicilio,fecha_alta) VALUES ( '" & dgv_proveedores.Rows(x).Cells(1).Value() & "','" & id_persona_proveedor & "','" & id_empresa_proveedor & "', '" & id_domicilio_proveedor & "',NOW())")

                    rs.Open("SELECT last_insert_id()", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                    id_proveedor = rs.Fields(0).Value
                    rs.Close()

                End If
            Next
            MsgBox("Registros ingresados correctamente")
        End If

        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub btn_inicializar_stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_inicializar_stock.Click
        If MsgBox("Esta operacion establecera en cero las existencias de todos los productos. Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            conn.Execute("UPDATE producto_sucursal SET cantidad=0")
            MsgBox("Existencias inicializadas correctamente", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub btn_eliminar_apartados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_apartados.Click
        If MsgBox("Esta operación eliminara todos los apartados del sistema. Esta operacion es irreversible, se recomienda hacer un respaldo de la base de datos. ¿Desea continuar?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'Conectar()
            rs.Open("SELECT id_venta FROM apartado ", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    conn.Execute("DELETE FROM pagos_ventas WHERE id_venta='" & rs.Fields("id_venta").Value & "'")
                    conn.Execute("DELETE FROM venta WHERE id_venta='" & rs.Fields("id_venta").Value & "'")
                    rs.MoveNext()
                End While
            End If
            rs.Close()
            conn.Execute("TRUNCATE TABLE apartado")
            'conn.close()
            'conn = Nothing
            MsgBox("Clientes eliminados correctamente.Salga y vuelva a entrar al sistema", MsgBoxStyle.Information, "correcto")
        End If
    End Sub

    Private Sub btn_enviar_base_Click(sender As System.Object, e As System.EventArgs) Handles btn_enviar_base.Click
        If Not Directory.Exists(directorio_respaldos) Then
            Directory.CreateDirectory(directorio_respaldos)
        End If

        Dim respaldar As New SaveFileDialog
        Dim carpeta As New FolderBrowserDialog

        respaldar.DefaultExt = "sql"
        Dim pathmysql As String
        Dim comando As String
        'pathmysql = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MySQL AB\MYSQL Server 5.1", "Location", 0)
        'If pathmysql = Nothing Then
        'MsgBox("No se encontro en tu equipo Mysql, escoge la carpeta donde esta ubicado")
        'carpeta.ShowDialog()
        'pathmysql = carpeta.SelectedPath
        pathmysql = db_directorio_mysql
        'End If
        respaldar.Filter = "File MYSQL (*.sql)|*.sql"
        respaldar.FileName = "Respaldo-" & lineas_ticket_cabeza(0) & "-" & Format(Date.Today, "dd-MM-yyyy") & "-" & Format(TimeOfDay, "HH-mm-ss")
        respaldar.InitialDirectory = My.Computer.FileSystem.CurrentDirectory & "\Respaldos"
        If respaldar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Try
            comando = pathmysql & "\bin\mysqldump -u " & db_usuario & " -p" & db_password & " --databases " & db_nombre & " | mysql --host=189.220.226.18  -–user=root --password=10188696 --databases estructura"
            Shell(comando, AppWinStyle.MaximizedFocus, True)
            'Catch ex As Exception
            'MsgBox("Ocurrio un error al respaldar_ " & ex.Message, MsgBoxStyle.Critical, "Informacion")
            '  End Try
            MsgBox("Base de datos respaldada correctamente", MsgBoxStyle.Information, "Informacion")
        End If
    End Sub
End Class
