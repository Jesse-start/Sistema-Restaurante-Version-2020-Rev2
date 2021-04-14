Module variables
    Public global_version As String = "2018 rev12 07/11/2018"
    Public conf_colores(28) As Double
    Public conf_pv(21) As Integer ' 0.-cfg_pago_express, 1-activar bascula automaticamente ,2- varias lineas por producto , 3-vender con cantidades negativas,- 4 mostrar codigo,5.-copias de ticket de venta,6.-enviar corte por email., 7.- imprimir ticket de pago, 8.- mostrar selector de cantidad, 9 imprimir_orden_entrega, 10 columna de codigos, 11 cfg_apartados, 12 ajustar_precios, 13 mostrar_barra_tareas, 14 boton_bascula, 15 observacion_producto, 16 fornatos_carta, 17 imprimir_productos de public en general en el corte de caja,18.-imprimir_comprobante_pago,19 imprimir_logotipo,20 imprimir_texto_sin formato, 21 Impresora_ matriz de punto
    Public conf_pv_id_formato(3) As Integer 'o NOTA DE VENTA,1 ORDEN DE ENTREGA, 2 COTIZACION 3 CUENTA POR COBRAR
    Public conf_impresoras(2) As String '0 caja, 1.- pedidos, 2.-almacen
    Public cfg_color As Double = -5737984
    Public global_current_idproducto As Integer 'id_producto seleccionado
    Public global_current_idcliente As Integer  'id_cliente seleccionado
    Public global_current_precio_especial As Integer '--precio especial selecccionado
    Public global_current_aplicar_redondeo As Boolean
    Public global_current_descuento_global As Decimal
    Public global_current_descuento_global_importe As Decimal
    Public global_current_idalmacen As Integer
    Public global_default_idalmacen As Integer
    Public global_default_nombrealmacen As String
    Public global_id_sucursal As Integer
    Public global_nombre_sucursal As String = ""
    Public global_current_tabindex_producto As Integer  'tabindex p                roducto_actual
    Public global_current_tabindex_categoria As Integer 'tabindex categoria actual
    Public global_thumb_usuario As System.Drawing.Image
    Public global_tipo_operacion As Integer '0-venta,1-pedidos
    Public EncabezadoConcepto As String
    Public Imprimir_recepcion_producto As Integer = 0
    'Public Nombre_impresora As String = "EPSON TM-T81 Receipt"
    Public global_frm_caja As Integer = 0
    Public global_razon_social As String = ""
    Public lineas_reporte(3) As String
    Public body_corte_html As String = ""
    Public globa_eliminar_imagen_ticket As Boolean = False
    Public global_codigo_barra_venta As System.Drawing.Image
    Public global_imprimir_codigo_barras As Boolean
    Public global_dir_facturas As String
    Public global_dir_cotizaciones As String

    'Public _logo As Image = New Bitmap(frm_principal.pb_logo.ImageLocation)
    'Public logo As Image = New Bitmap(Application.StartupPath & "\logo_thumb.png").GetThumbnailImage(128, 80, Nothing, New IntPtr)
    Public global_logotipo As Image

    Public clientes(5000, 2) As Object
    '/        0      /   1    /
    '/ id_cliente  / nombre  / 
    Public NombreDeLaFuente As String = "Lucida Console" 'Lucida Console original
    Public TamanoDeLaFuente As Integer = 7
    Public CaracteresMaximos As Integer = 39 ' 39 original

    Public global_matriz_clientes_cargado As Boolean = False
    '   Configuración de Sistema
    '
    Public cfg_tiempo_inactivo As Integer = 10
    Public cfg_intentos_fallidos As Integer = 0
    '
    '   Variables de Conexion
    '=========== variables de conexion db (Conectar)
    Public conn As ADODB.Connection
    Public rs As ADODB.Recordset
    Public bd As String
    Public user As String
    Public pass As String
    Public strConexion As String
    Public archivo_configuracion As String = System.IO.Directory.GetCurrentDirectory() & "/adodb.inf"
    Public directorio_respaldos As String = System.IO.Directory.GetCurrentDirectory() & "/Respaldos"
    '============================================
    '=========== variables de TERMINAL
    Public global_nombre_terminal As String = ""
    Public archivo_terminal As String = System.IO.Directory.GetCurrentDirectory() & "/terminal.inf"
    Public archivo_licencia As String = System.IO.Directory.GetCurrentDirectory() & "/stdole.ini"
    '============================================
    ' variables conexion a nueva sucursal
    Public rss As ADODB.Recordset 'recordset alternativo para sucursales
    Public strConexionSucursal As String
    Public conn_sucursal As ADODB.Connection
    '--------------------------------------
    '
    '   Variables de Conexion
    '
    Public conexion_str As String = ""
    Public conectado As Boolean = False
    Public conexion_prueba As New ADODB.Connection
    '
    '   Configuración Base de Datos
    '
    '   Configuración Base de Datos
    '
    Public db_nombre As String
    Public db_servidor As String
    Public db_usuario As String
    Public db_password As String
    Public db_directorio_mysql As String

    Public certificado_sat As String = ""
    Public clave_sat As String = ""
    Public contrasena_sat As String = ""

    '
    '   Variables Globales de Sesión
    '
    Public global_id_usuario As Integer = 0
    Public global_id_persona As Integer = 0
    Public global_id_empleado As Integer = 0
    Public global_nombre As String = ""
    Public global_usuario As String = "usuario"
    Public global_puesto As String = ""
    Public global_id_puesto As Integer = 0
    Public global_cobro_terminal As Integer = 0
    Public global_pago_proveedores As Integer = 0
    Public global_recepcion_productos As Integer = 0
    Public global_traspasos_env As Integer = 0
    Public global_traspasos_recep As Integer = 0
    Public global_devoluciones As Integer = 0
    Public global_conversiones As Integer = 0
    Public global_ajuste_inventario As Integer = 0
    Public global_usuario_nombre As String = ""
    Public global_usuario_ver_pedidos As Integer = 0
    Public global_rfc As String = ""
    Public global_habilitar_cfdi As Integer = 0
    Public global_serie As String = ""

    Public global_cfg_bascula_portname As String = "COM1"
    Public global_cfg_bascula_baudrate As Integer = 9600
    Public global_cfg_bascula_databits As Integer = 8
    Public global_cfg_bascula_discarnull As Boolean = False
    Public global_cfg_bascula_parity As String = "NONE"
    Public global_cfg_bascula_readbuffersize As Integer = 4096
    Public global_cfg_bascula_readtimeout As Integer = 3000
    Public global_cfg_bascula_recievedbytethreshold As Integer = 10
    Public global_cfg_bascula_rtsenable As Boolean = False
    Public global_cfg_bascula_stopbits As String = "ONE"
    Public global_cfg_bascula_writebuffersize As Integer = 2048
    Public global_cfg_bascula_writetimeout As Integer = 3000



    '
    '   Variables Globales Control Ventana
    '
    
    Public global_frm_cotizacion As Integer = 0
    Public global_frm_compras As Integer = 0
    Public global_frm_login As Integer = 0
    Public global_frm_cfg_usuario As Integer = 0
    Public global_frm_producto As Integer = 0
    Public global_frm_producto_categoria As Integer = 0
    Public global_frm_producto_sucursal As Integer = 0
    Public global_frm_categoria As Integer = 0
    Public global_frm_directorio As Integer = 0
    Public global_frm_impuesto As Integer = 0
    Public global_frm_producto_abrir As Integer = 0
    Public global_frm_factura As Integer = 0
    Public global_frm_recibo_pago As Integer = 0
    Public global_frm_nota_credito As Integer = 0
    Public global_frm_cotizacion_abrir As Integer = 0
    Public global_frm_splashscreen_abrir As Integer = 0
    Public global_frm_traspasos_recepcion As Integer = 0
    Public global_frm_traspasos_envio As Integer = 0
    Public global_frm_control_facturas As Integer = 0
    Public global_frm_matriz_precios As Integer = 0
    Public global_frm_cuentasxcobrar As Integer = 0
    Public global_frm_cuentasxpagar As Integer = 0
    Public global_frm_formas_pago_ventas As Integer = 0
    Public global_frm_formas_pago_factura As Integer = 0
    Public global_frm_formas_pago As Integer = 0
    Public global_frm_pedidos_clientes As Integer = 0
    Public global_frm_apartados As Integer = 0
    Public global_frm_apartado_detalle As Integer = 0
    Public global_frm_cancelaciones As Integer = 0
    Public global_frm_principal3 As Integer = 0
    Public global_frm_presentaciones As Integer = 0
    Public global_frm_insumos As Integer = 0
    Public global_frm_almacenes As Integer = 0
    Public global_frm_servicio As Integer = 0
    Public global_frm_areas_impresion As Integer = 0
    Public global_frm_inventario_fisico As Integer = 0
    Public global_frm_meseros As Integer = 0
    Public global_frm_unidad As Integer = 0
    Public global_frm_producto_busqueda As Integer = 0
    Public global_frm_colaboradores As Integer = 0

    '   Arreglos

    Public cfg_fuente_tituto As String = ""
    Public cfg_fuente_producto As String = ""
    Public cfg_tamaño_fuente_titulo As Integer = 0
    Public cfg_tamaño_fuente_producto As Integer = 0
    Public cfg_longitud_descripcion As Integer = 0
    Public cfg_longitud_maxima_ticket As Integer = 0
    Public cfg_longitud_linea_productos As Integer = 0
    Public cfg_productos_mayusculas_ticket As Integer = 0
    Public cfg_escala_logo_ticket As Integer = 0
    Public cfg_escala_altura_logo As Integer = 0
    Public cfg_longitud_titulo As Integer = 0
    Public cfg_espacios_antes_total As Integer = 0
    Public cfg_margen_izq_total As Integer = 0
    '
    Public nombre_mes As String() = {"", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
    Public nombre_corto_mes As String() = {"", "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"}
    Public nombre_dia As String() = {"", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"}
    Public nombre_dia_pedido As String() = {"Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado"}
    Public periodicidad As String() = {"", "Dia", "Semana", "Mes"}
End Module
