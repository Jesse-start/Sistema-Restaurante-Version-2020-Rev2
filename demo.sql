/*
SQLyog Enterprise - MySQL GUI v8.18 
MySQL - 5.0.51b-community-nt-log : Database - spvpyme
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`spvpyme` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `spvpyme`;

/*Table structure for table `agente_entrega` */

DROP TABLE IF EXISTS `agente_entrega`;

CREATE TABLE `agente_entrega` (
  `id_agente_entrega` int(11) NOT NULL auto_increment,
  `id_empleado` int(11) default NULL,
  `id_vehiculo` int(11) default NULL,
  `status` varchar(50) default 'ACTIVO',
  PRIMARY KEY  (`id_agente_entrega`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `ajuste_inventario` */

DROP TABLE IF EXISTS `ajuste_inventario`;

CREATE TABLE `ajuste_inventario` (
  `id_ajuste_inventario` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `nombre` varchar(50) default NULL,
  `fecha` datetime default NULL,
  `id_empleado` int(11) default NULL,
  `diferencia` decimal(11,2) default NULL,
  `merma` int(1) default '0',
  PRIMARY KEY  (`id_ajuste_inventario`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `almacenes` */

DROP TABLE IF EXISTS `almacenes`;

CREATE TABLE `almacenes` (
  `ID_Almacen` int(50) NOT NULL auto_increment,
  `id_almacen_tipo` int(11) default '0',
  `clave` varchar(100) default '',
  `nombre` varchar(50) NOT NULL default '',
  `id_empleado_responsable` int(11) NOT NULL default '0',
  `id_sucursal` int(11) default NULL,
  `domicilio` varchar(100) default '',
  `default_ventas` int(1) default '0',
  PRIMARY KEY  (`ID_Almacen`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `almacenes_tipo` */

DROP TABLE IF EXISTS `almacenes_tipo`;

CREATE TABLE `almacenes_tipo` (
  `id_almacen_tipo` int(11) NOT NULL auto_increment,
  `nombre` varchar(500) default '',
  PRIMARY KEY  (`id_almacen_tipo`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `apartado` */

DROP TABLE IF EXISTS `apartado`;

CREATE TABLE `apartado` (
  `id_apartado` int(10) unsigned NOT NULL auto_increment,
  `id_empleado` int(10) unsigned NOT NULL,
  `fecha_apartado` datetime default NULL,
  `fecha_entrega` datetime default NULL,
  `id_cliente` int(10) unsigned default NULL,
  `codigo` int(10) unsigned default NULL,
  `subtotal` decimal(11,2) default NULL,
  `iva` decimal(11,2) default NULL,
  `otros_impuestos` decimal(11,2) default NULL,
  `total` decimal(10,2) default NULL,
  `id_sucursal` int(10) unsigned default NULL,
  `id_factura` int(11) default '0',
  `entregado` int(1) default '0',
  `id_empleado_entrega` int(1) default '0',
  `id_venta` int(1) default '0',
  `status_pago` varchar(15) default 'PENDIENTE',
  `status` varchar(20) default 'ACTIVO',
  `comentarios` text,
  PRIMARY KEY  (`id_apartado`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `area_comedor` */

DROP TABLE IF EXISTS `area_comedor`;

CREATE TABLE `area_comedor` (
  `id_area_comedor` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default 'GENERAL',
  PRIMARY KEY  (`id_area_comedor`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `areas_comedor` */

DROP TABLE IF EXISTS `areas_comedor`;

CREATE TABLE `areas_comedor` (
  `id_area_comedor` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default '',
  PRIMARY KEY  (`id_area_comedor`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `areas_impresion` */

DROP TABLE IF EXISTS `areas_impresion`;

CREATE TABLE `areas_impresion` (
  `id_area_impresion` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default '',
  `nombre` varchar(100) default '',
  `id_almacen_descarga` int(11) default NULL,
  PRIMARY KEY  (`id_area_impresion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `banco` */

DROP TABLE IF EXISTS `banco`;

CREATE TABLE `banco` (
  `id_banco` int(11) NOT NULL auto_increment,
  `descripcion` varchar(50) NOT NULL,
  `logotipo` longblob,
  PRIMARY KEY  (`id_banco`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Table structure for table `banco_cuentas` */

DROP TABLE IF EXISTS `banco_cuentas`;

CREATE TABLE `banco_cuentas` (
  `id_cuenta` int(11) NOT NULL auto_increment,
  `id_banco` int(11) NOT NULL,
  `Cuenta` varchar(20) NOT NULL default '',
  `Num_Cliente` varchar(20) NOT NULL default '',
  `Contrato` varchar(20) NOT NULL default '',
  `Sucursal` varchar(10) NOT NULL default '',
  `Fecha_Apertura` datetime NOT NULL default '0000-00-00 00:00:00',
  `Fecha_modificacion` datetime default '0000-00-00 00:00:00',
  `Nip_Audio` double NOT NULL default '0',
  `Nip_Fiscal` double NOT NULL default '0',
  `Saldo` double NOT NULL default '0',
  `Ultimo_Cheq` double NOT NULL default '0',
  `CuentaID` int(11) NOT NULL default '0',
  `Status` varchar(20) default 'ACTIVO',
  PRIMARY KEY  (`id_cuenta`),
  UNIQUE KEY `ID_Banco` (`id_cuenta`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `caja_saldo_inicial` */

DROP TABLE IF EXISTS `caja_saldo_inicial`;

CREATE TABLE `caja_saldo_inicial` (
  `id_saldo_inicial` int(11) NOT NULL auto_increment,
  `saldo_inicial` decimal(11,2) default NULL,
  `id_empleado` int(11) default NULL,
  `fecha` datetime default NULL,
  `bandera_corte_caja` int(11) default '0',
  PRIMARY KEY  (`id_saldo_inicial`)
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;

/*Table structure for table `catalogo_precios` */

DROP TABLE IF EXISTS `catalogo_precios`;

CREATE TABLE `catalogo_precios` (
  `id_catalogo_precio` int(11) NOT NULL auto_increment,
  `nombre` varchar(25) default NULL,
  `cantidad_inicio` int(10) default NULL,
  `cantidad_termino` int(10) default NULL,
  `utilidad` decimal(10,2) default NULL,
  PRIMARY KEY  (`id_catalogo_precio`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `categoria` */

DROP TABLE IF EXISTS `categoria`;

CREATE TABLE `categoria` (
  `id_categoria` int(11) NOT NULL auto_increment,
  `clave` int(5) default '0',
  `nombre` varchar(100) NOT NULL,
  `super` int(11) NOT NULL,
  `fecha_alta` datetime default NULL,
  `fecha_modificacion` timestamp NULL default CURRENT_TIMESTAMP,
  `nivel` int(2) default NULL,
  PRIMARY KEY  (`id_categoria`),
  UNIQUE KEY `NewIndex1` (`nombre`,`super`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `categoria_cat_imp` */

DROP TABLE IF EXISTS `categoria_cat_imp`;

CREATE TABLE `categoria_cat_imp` (
  `id_categoria` int(11) default NULL,
  `id_catalogo` int(11) default NULL,
  KEY `FK_prod_cat_imp` (`id_categoria`),
  KEY `FK_prod_cat_imp_cat` (`id_catalogo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `cfg_bascula` */

DROP TABLE IF EXISTS `cfg_bascula`;

CREATE TABLE `cfg_bascula` (
  `id_cfg_bascula` int(11) NOT NULL auto_increment,
  `portname` varchar(100) default 'COM1',
  `baudrate` varchar(100) default '9600',
  `databits` varchar(100) default '8',
  `discarnull` varchar(100) default 'False',
  `parity` varchar(100) default 'None',
  `readbuffersize` varchar(100) default '4096',
  `readtimeout` varchar(100) default '3000',
  `receivedbytesthreshold` varchar(100) default '10',
  `rtsenable` varchar(100) default 'False',
  `stopbits` varchar(100) default 'One',
  `writebuffersize` varchar(100) default '2048',
  `writetimeout` varchar(100) default '3000',
  PRIMARY KEY  (`id_cfg_bascula`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_colores` */

DROP TABLE IF EXISTS `cfg_colores`;

CREATE TABLE `cfg_colores` (
  `id_cfg_color` int(1) NOT NULL auto_increment,
  `cfg_1` text,
  `cfg_2` text,
  `cfg_3` text,
  `cfg_4` text,
  `cfg_5` text,
  `cfg_6` text,
  `cfg_7` text,
  `cfg_8` text,
  `cfg_9` text,
  `cfg_10` text,
  `cfg_11` text,
  `cfg_12` text,
  `cfg_13` text,
  `cfg_14` text,
  `cfg_15` text,
  `cfg_16` text,
  `cfg_17` text,
  `cfg_18` text,
  `cfg_19` text,
  `cfg_20` text,
  `cfg_21` text,
  `cfg_22` text,
  `cfg_23` text,
  `cfg_24` text,
  `cfg_25` text,
  `cfg_26` text,
  `cfg_27` text,
  `cfg_28` text,
  PRIMARY KEY  (`id_cfg_color`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_correo` */

DROP TABLE IF EXISTS `cfg_correo`;

CREATE TABLE `cfg_correo` (
  `id_cfg_correo` int(11) NOT NULL auto_increment,
  `nombre_dest` varchar(100) default '',
  `correo_dest` varchar(50) default '',
  `asunto` varchar(50) default '',
  `mensaje` varchar(100) default '',
  `id_smtp` int(11) default '1',
  `id_adjuntar` int(11) default '1',
  `proteger_pdf` int(1) default '0',
  `password_pdf` varchar(50) default '',
  `enviar_despues_generar` int(1) default '0',
  PRIMARY KEY  (`id_cfg_correo`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_descuento` */

DROP TABLE IF EXISTS `cfg_descuento`;

CREATE TABLE `cfg_descuento` (
  `id_cfg_descuento` int(11) NOT NULL auto_increment,
  `porcentaje` decimal(11,2) default '0.00',
  `fecha_inicio` datetime default NULL,
  `fecha_termino` datetime default NULL,
  PRIMARY KEY  (`id_cfg_descuento`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_descuento_cat` */

DROP TABLE IF EXISTS `cfg_descuento_cat`;

CREATE TABLE `cfg_descuento_cat` (
  `id_cfg_descuento_cat` int(11) NOT NULL auto_increment,
  `id_cfg_descuento` int(11) default '0',
  `id_categoria` int(11) default NULL,
  PRIMARY KEY  (`id_cfg_descuento_cat`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_documentos` */

DROP TABLE IF EXISTS `cfg_documentos`;

CREATE TABLE `cfg_documentos` (
  `id_cfg_documentos` int(11) NOT NULL auto_increment,
  `dir_facturas` text,
  `dir_cotizaciones` text,
  PRIMARY KEY  (`id_cfg_documentos`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_facturacion` */

DROP TABLE IF EXISTS `cfg_facturacion`;

CREATE TABLE `cfg_facturacion` (
  `id_cfg_facturacion` int(11) NOT NULL auto_increment,
  `concepto_predeterminado` int(1) default '0',
  `concepto` text,
  `unidad_predeterminada` int(1) default '0',
  `id_unidad` int(11) default '0',
  `id_cfg_impuesto_default` int(11) default '0',
  PRIMARY KEY  (`id_cfg_facturacion`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_facturacion_connector` */

DROP TABLE IF EXISTS `cfg_facturacion_connector`;

CREATE TABLE `cfg_facturacion_connector` (
  `id_cfg_facturacion_connector` int(11) NOT NULL auto_increment,
  `usuario` varchar(100) default '',
  `contraseña` varchar(100) default '',
  `certificado` varchar(200) default '',
  `clave` varchar(200) default '',
  `contraseña_clave` varchar(200) default '',
  PRIMARY KEY  (`id_cfg_facturacion_connector`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_facturacion_serie` */

DROP TABLE IF EXISTS `cfg_facturacion_serie`;

CREATE TABLE `cfg_facturacion_serie` (
  `id_cfg_facturacion_serie` int(11) NOT NULL auto_increment,
  `serie` varchar(50) default '',
  `deshabilitar` int(1) default '0',
  `consecutivo_inicial` int(11) default '1',
  `consecutivo_final` int(11) default '1000',
  `num_aprobacion` varchar(50) default '',
  `ano_aprobacion` varchar(50) default '',
  `ultimo_folio_factura` varchar(50) default '',
  PRIMARY KEY  (`id_cfg_facturacion_serie`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_formato_impresion` */

DROP TABLE IF EXISTS `cfg_formato_impresion`;

CREATE TABLE `cfg_formato_impresion` (
  `id_cfg_formato_impresion` int(11) NOT NULL auto_increment,
  `id_formato_nota_venta` int(2) default '0',
  `id_formato_orden_entrega` int(2) default '0',
  `id_formato_cotizacion` int(2) default '0',
  `id_formato_cxcobrar` int(2) default '0',
  PRIMARY KEY  (`id_cfg_formato_impresion`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_impresoras` */

DROP TABLE IF EXISTS `cfg_impresoras`;

CREATE TABLE `cfg_impresoras` (
  `id_cfg_impresora` int(11) NOT NULL auto_increment,
  `index_imp_caja` varchar(100) default '',
  `index_imp_pedidos` varchar(100) default '',
  `index_imp_almacen` varchar(100) default '',
  PRIMARY KEY  (`id_cfg_impresora`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_impuesto` */

DROP TABLE IF EXISTS `cfg_impuesto`;

CREATE TABLE `cfg_impuesto` (
  `id_cfg_impuesto` int(11) NOT NULL auto_increment,
  `id_cfg_impuesto_catalogo` int(11) default NULL,
  `nombre` varchar(20) default NULL,
  `tasa` decimal(9,2) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_baja` datetime default NULL,
  PRIMARY KEY  (`id_cfg_impuesto`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_impuesto_catalogo` */

DROP TABLE IF EXISTS `cfg_impuesto_catalogo`;

CREATE TABLE `cfg_impuesto_catalogo` (
  `id_cfg_impuesto_catalogo` int(11) NOT NULL auto_increment,
  `codigo` varchar(10) default '',
  `alias` varchar(50) default NULL,
  `nombre` varchar(50) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_baja` datetime default NULL,
  PRIMARY KEY  (`id_cfg_impuesto_catalogo`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_leyenda_nota` */

DROP TABLE IF EXISTS `cfg_leyenda_nota`;

CREATE TABLE `cfg_leyenda_nota` (
  `id_cfg_leyenda_nota` int(11) NOT NULL auto_increment,
  `leyenda1` text,
  `leyenda2` text,
  `leyenda3` text,
  `leyenda4` text,
  `leyenda5` text,
  PRIMARY KEY  (`id_cfg_leyenda_nota`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_licencia` */

DROP TABLE IF EXISTS `cfg_licencia`;

CREATE TABLE `cfg_licencia` (
  `id_licencia` int(11) NOT NULL auto_increment,
  `licencia` text,
  PRIMARY KEY  (`id_licencia`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_lineas_ticket` */

DROP TABLE IF EXISTS `cfg_lineas_ticket`;

CREATE TABLE `cfg_lineas_ticket` (
  `id_lineas` int(11) NOT NULL auto_increment,
  `id_tipo` int(1) default '1',
  `descripcion` varchar(50) default NULL,
  PRIMARY KEY  (`id_lineas`)
) ENGINE=MyISAM AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_nota_credito_serie` */

DROP TABLE IF EXISTS `cfg_nota_credito_serie`;

CREATE TABLE `cfg_nota_credito_serie` (
  `id_cfg_facturacion_serie` int(11) NOT NULL auto_increment,
  `serie` varchar(50) default '',
  `deshabilitar` int(1) default '0',
  `consecutivo_inicial` int(11) default '1',
  `consecutivo_final` int(11) default '1000',
  `num_aprobacion` varchar(50) default '',
  `ano_aprobacion` varchar(50) default '',
  `ultimo_folio_factura` varchar(50) default '',
  PRIMARY KEY  (`id_cfg_facturacion_serie`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_producto_compuesto` */

DROP TABLE IF EXISTS `cfg_producto_compuesto`;

CREATE TABLE `cfg_producto_compuesto` (
  `id_producto` int(11) default NULL,
  `id_insumo` int(11) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `id_tipo_descuento` int(1) default '0',
  `cantidad_unidad` decimal(9,3) default '1.000'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `cfg_punto_venta` */

DROP TABLE IF EXISTS `cfg_punto_venta`;

CREATE TABLE `cfg_punto_venta` (
  `id_cfg_punto_venta` int(11) NOT NULL auto_increment,
  `cfg_pago_express` int(1) default '0',
  `cfg_activar_bascula` int(1) default '0',
  `cfg_varias_lineas` int(1) default '0',
  `cfg_cantidades_negativas` int(1) default '0',
  `cfg_mostrar_codigo` int(1) default '0',
  `cfg_copia_ticket` int(1) default '0',
  `cfg_ticket_pago` int(1) default '0',
  `cfg_cantidad_codigo` int(1) default '0',
  `cfg_imprimir_orden_entrega` int(1) default '0',
  `cfg_mostrar_codigo_venta_detalle` int(1) default '0',
  `cfg_ver_pedidos_apartados` int(1) default '0',
  `cfg_ajustar_precios` int(1) default '0',
  `cfg_mostrar_barra_tareas` int(1) default '0',
  `cfg_mostrar_boton_bascula` int(1) default '1',
  `cfg_ingresar_observacion_producto` int(1) default '0',
  `cfg_imprimir_formatos_carta` int(1) default '0',
  `cfg_imprimir_productos_corte` int(1) default '0',
  `cfg_imprimir_comprobante_pago` int(1) default '0',
  `cfg_imprimir_logotipo_ticket` int(1) default '0',
  `cfg_imprimir_texto_sin_formato` int(1) default '0',
  `cfg_impresora_matriz` int(1) default '0',
  `fuente_titulo` varchar(100) default 'Lucida Console',
  `fuente_producto` varchar(100) default 'Arial Narrow',
  `size_titulo` int(11) default '10',
  `size_producto` int(11) default '7',
  `long_descripcion` int(11) default '30',
  `long_maxima` int(11) default '39',
  `long_linea_productos` int(11) default '70',
  `productos_mayusculas` int(1) default '0',
  `escala_logo_ticket` int(11) default '58',
  `escala_altura_logo` int(11) default '15',
  `longitud_titulo` int(11) default '25',
  `espacios_antes_total` int(11) default '7',
  `margen_izq_total` int(11) default '9',
  PRIMARY KEY  (`id_cfg_punto_venta`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `cliente` */

DROP TABLE IF EXISTS `cliente`;

CREATE TABLE `cliente` (
  `id_cliente` int(11) NOT NULL auto_increment,
  `clave` varchar(30) default '',
  `id_persona` int(11) default NULL,
  `id_empresa` int(11) default '0',
  `id_domicilio` int(11) default NULL,
  `id_telefono` int(11) default NULL,
  `id_tipo` int(11) default '1',
  `fecha_alta` datetime default NULL,
  `fecha_modificacion` timestamp NULL default CURRENT_TIMESTAMP,
  `id_catalogo_precio` int(11) default '0',
  PRIMARY KEY  (`id_cliente`),
  KEY `FK_cliente_empresa` (`id_empresa`),
  KEY `FK_cliente_domicilio` (`id_domicilio`),
  KEY `FK_cliente_persona` (`id_persona`),
  KEY `FK_cliente_telefono` (`id_telefono`),
  KEY `FK_cliente_tipo` (`id_tipo`)
) ENGINE=MyISAM AUTO_INCREMENT=3644 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `cliente_credito` */

DROP TABLE IF EXISTS `cliente_credito`;

CREATE TABLE `cliente_credito` (
  `id_cliente` int(11) default NULL,
  `credito` int(1) default '0',
  `limite` int(1) default '0',
  `limite_credito` double(9,2) default '0.00',
  KEY `FK_id_cliente` (`id_cliente`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `cliente_cuenta` */

DROP TABLE IF EXISTS `cliente_cuenta`;

CREATE TABLE `cliente_cuenta` (
  `id_cuenta_cliente` int(20) NOT NULL auto_increment,
  `id_cliente` int(11) NOT NULL,
  `banco` varchar(25) NOT NULL,
  `cuenta` varchar(25) NOT NULL,
  `sucursal` varchar(25) default '',
  `clabe` varchar(25) default '',
  PRIMARY KEY  (`id_cuenta_cliente`),
  KEY `FK_id_cliente` (`id_cliente`)
) ENGINE=MyISAM AUTO_INCREMENT=201 DEFAULT CHARSET=latin1;

/*Table structure for table `cliente_precio` */

DROP TABLE IF EXISTS `cliente_precio`;

CREATE TABLE `cliente_precio` (
  `id_cliente_precio` int(11) NOT NULL auto_increment,
  `id_cliente` int(11) default '0',
  `id_ctlg_precios` int(11) default '0',
  `autorizacion` int(1) default '0',
  `aplicar_redondeo` int(1) default '1',
  `mostrar_precios` int(1) default '1',
  `id_catalogo_precio` int(11) default '0',
  PRIMARY KEY  (`id_cliente_precio`),
  KEY `FK_cliente_precio` (`id_cliente`)
) ENGINE=MyISAM AUTO_INCREMENT=4159 DEFAULT CHARSET=latin1;

/*Table structure for table `cliente_productos` */

DROP TABLE IF EXISTS `cliente_productos`;

CREATE TABLE `cliente_productos` (
  `id_cliente_producto` int(11) NOT NULL auto_increment,
  `id_cliente` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` double(9,2) default '0.00',
  PRIMARY KEY  (`id_cliente_producto`),
  KEY `FK_id_cliente` (`id_cliente`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `cliente_tipo` */

DROP TABLE IF EXISTS `cliente_tipo`;

CREATE TABLE `cliente_tipo` (
  `id_tipo` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default NULL,
  `descuento` decimal(4,2) default NULL,
  PRIMARY KEY  (`id_tipo`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `clientes` */

DROP TABLE IF EXISTS `clientes`;

CREATE TABLE `clientes` (
  `id_cliente` int(11) default NULL,
  `rfc` varchar(15) default NULL,
  `razon_social` varchar(122) default NULL,
  `tipo` int(1) default NULL,
  `descuento` decimal(4,2) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `configuracion` */

DROP TABLE IF EXISTS `configuracion`;

CREATE TABLE `configuracion` (
  `id_configuracion` int(1) NOT NULL auto_increment,
  `imagen` blob,
  `thumb` blob,
  `logotipo` longblob,
  `logotipo_thumb` longblob,
  `logo` blob,
  `codigo_barras` blob,
  `alias` varchar(100) default '',
  `razon_social` varchar(100) default '',
  `domicilio` varchar(100) default '',
  `url` varchar(100) default '',
  `rfc` varchar(15) default '',
  `calle` varchar(100) default '',
  `num_int` varchar(6) default '',
  `num_ext` varchar(6) default '',
  `colonia` varchar(100) default '',
  `municipio` varchar(100) default '',
  `localidad` varchar(100) default '',
  `cp` varchar(6) default '',
  `estado` varchar(40) default '',
  `pais` varchar(100) default '',
  `telefono` varchar(40) default '',
  `correo` varchar(30) default '',
  `tiempo_vida_venta` tinyint(2) default '5',
  `tiempo_vida_carro` tinyint(2) default '5',
  `venta_caduca` tinyint(2) default '0',
  `tiempo_inactivo` tinyint(1) default NULL,
  `intentos_fallidos` tinyint(1) default NULL,
  `cfg_titulo` varchar(100) default NULL,
  `cfg_cat_nivel` int(2) default NULL,
  `cfg_stock_minimo` int(2) default NULL,
  `cfg_descripcion` text,
  `cfg_keywords` text,
  `cfg_color` text,
  `cfg_imagen_producto` varchar(100) default '',
  `id_sucursal` int(11) default '0',
  `id_pantalla` int(1) default '0',
  `habilitar_cfdi` int(11) default '0',
  `serie` varchar(10) default '',
  `id_regimen_fiscal` int(11) default '0',
  UNIQUE KEY `id_configuracion` (`id_configuracion`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `corte_declaracion` */

DROP TABLE IF EXISTS `corte_declaracion`;

CREATE TABLE `corte_declaracion` (
  `id_declaracion` int(11) NOT NULL auto_increment,
  `total_efectivo` decimal(9,2) default '0.00',
  `total_tarjeta` decimal(9,2) default '0.00',
  `total_transferencia` decimal(9,2) default '0.00',
  `total_cheque` decimal(9,2) default '0.00',
  `total_nota` decimal(9,2) default '0.00',
  `id_corte` int(11) default '0',
  PRIMARY KEY  (`id_declaracion`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

/*Table structure for table `corte_detalle` */

DROP TABLE IF EXISTS `corte_detalle`;

CREATE TABLE `corte_detalle` (
  `id_corte_detalle` int(11) NOT NULL auto_increment,
  `id_corte` int(11) default '0',
  `billete_20` decimal(9,2) default '0.00',
  `billete_50` decimal(9,2) default '0.00',
  `billete_100` decimal(9,2) default '0.00',
  `billete_200` decimal(9,2) default '0.00',
  `billete_500` decimal(9,2) default '0.00',
  `billete_1000` decimal(9,2) default '0.00',
  `moneda_1` decimal(9,2) default '0.00',
  `moneda_2` decimal(9,2) default '0.00',
  `moneda_5` decimal(9,2) default '0.00',
  `moneda_10` decimal(9,2) default '0.00',
  `moneda_50c` decimal(9,2) default '0.00',
  `tarjeta_visa` decimal(9,2) default '0.00',
  `tarjeta_master_card` decimal(9,2) default '0.00',
  `tarjeta_american_express` decimal(9,2) default '0.00',
  PRIMARY KEY  (`id_corte_detalle`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

/*Table structure for table `cortes` */

DROP TABLE IF EXISTS `cortes`;

CREATE TABLE `cortes` (
  `id_corte` int(5) NOT NULL auto_increment,
  `fecha` datetime default NULL,
  `id_empleado_caja` varchar(20) default NULL,
  `nombre_empleado` varchar(50) default NULL,
  `total_ventas` decimal(11,2) default NULL,
  `total_retiros` decimal(11,2) default NULL,
  `total_caja` decimal(11,2) default NULL,
  `body_html` text,
  PRIMARY KEY  (`id_corte`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

/*Table structure for table `cotizacion` */

DROP TABLE IF EXISTS `cotizacion`;

CREATE TABLE `cotizacion` (
  `id_cotizacion` int(11) NOT NULL auto_increment,
  `fecha` date default NULL,
  `numero` int(11) default NULL,
  `importe` decimal(9,2) default NULL,
  `descuento` decimal(9,2) default '0.00',
  `subtotal` decimal(9,2) default NULL,
  `otros` decimal(9,2) default NULL,
  `iva` decimal(9,2) default NULL,
  `total` decimal(9,2) default NULL,
  `id_cliente` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  `id_catalogo_precio` int(11) default NULL,
  `mensaje` text,
  `despedida` text,
  `nombre_cliente` text,
  PRIMARY KEY  (`id_cotizacion`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `cotizacion_detalle` */

DROP TABLE IF EXISTS `cotizacion_detalle`;

CREATE TABLE `cotizacion_detalle` (
  `id_detalle` int(10) NOT NULL auto_increment,
  `id_cotizacion` int(10) default NULL,
  `id_producto` int(10) default NULL,
  `descripcion` text,
  `cantidad` int(5) default NULL,
  `unidad` varchar(50) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `impuesto` text,
  `precio_venta` decimal(10,2) default NULL,
  `descuento` decimal(5,2) default '0.00',
  `precio_unitario` decimal(10,2) default NULL,
  PRIMARY KEY  (`id_detalle`),
  KEY `FK_cotizacion_detalle` (`id_cotizacion`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `ctlg_forma_pago` */

DROP TABLE IF EXISTS `ctlg_forma_pago`;

CREATE TABLE `ctlg_forma_pago` (
  `id_pago` int(11) NOT NULL auto_increment,
  `clave` varchar(50) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY  (`id_pago`,`clave`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `ctlg_metodo_pago` */

DROP TABLE IF EXISTS `ctlg_metodo_pago`;

CREATE TABLE `ctlg_metodo_pago` (
  `id_metodo_pago` int(11) NOT NULL auto_increment,
  `clave` varchar(50) NOT NULL,
  `nombre` varchar(100) default NULL,
  PRIMARY KEY  (`id_metodo_pago`,`clave`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Table structure for table `ctlg_precios` */

DROP TABLE IF EXISTS `ctlg_precios`;

CREATE TABLE `ctlg_precios` (
  `id_ctlg_precios` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default NULL,
  `nombre` varchar(50) default NULL,
  `utilidad` decimal(10,2) default NULL,
  PRIMARY KEY  (`id_ctlg_precios`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `ctlg_regimen_fiscal` */

DROP TABLE IF EXISTS `ctlg_regimen_fiscal`;

CREATE TABLE `ctlg_regimen_fiscal` (
  `id_regimen_fiscal` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default NULL,
  `nombre` varchar(100) default NULL,
  PRIMARY KEY  (`id_regimen_fiscal`)
) ENGINE=MyISAM AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;

/*Table structure for table `ctlg_servicio_marca` */

DROP TABLE IF EXISTS `ctlg_servicio_marca`;

CREATE TABLE `ctlg_servicio_marca` (
  `id_servicio_marca` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default '',
  PRIMARY KEY  (`id_servicio_marca`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `ctlg_servicio_modelo` */

DROP TABLE IF EXISTS `ctlg_servicio_modelo`;

CREATE TABLE `ctlg_servicio_modelo` (
  `id_servicio_modelo` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default '',
  PRIMARY KEY  (`id_servicio_modelo`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `ctlg_tipo_relacion` */

DROP TABLE IF EXISTS `ctlg_tipo_relacion`;

CREATE TABLE `ctlg_tipo_relacion` (
  `id_tipo_relacion` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default NULL,
  `nombre` varchar(100) default NULL,
  PRIMARY KEY  (`id_tipo_relacion`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Table structure for table `ctlg_uso_cfdi` */

DROP TABLE IF EXISTS `ctlg_uso_cfdi`;

CREATE TABLE `ctlg_uso_cfdi` (
  `id_uso_cfdi` int(11) NOT NULL auto_increment,
  `clave` varchar(50) default NULL,
  `nombre` varchar(100) default NULL,
  PRIMARY KEY  (`id_uso_cfdi`)
) ENGINE=MyISAM AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

/*Table structure for table `depositos` */

DROP TABLE IF EXISTS `depositos`;

CREATE TABLE `depositos` (
  `id_deposito_caja` int(11) NOT NULL auto_increment,
  `fecha` datetime default NULL,
  `importe` decimal(9,2) default '0.00',
  `descripcion` text,
  `id_empleado_caja` int(11) default '0',
  `id_sucursal` int(11) default '0',
  `bandera_corte_caja` int(11) default '0',
  `status` varchar(30) default 'ACTIVO',
  PRIMARY KEY  (`id_deposito_caja`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

/*Table structure for table `detalle_pedido` */

DROP TABLE IF EXISTS `detalle_pedido`;

CREATE TABLE `detalle_pedido` (
  `id_detalle_pedido` int(10) unsigned NOT NULL auto_increment,
  `id_pedido` int(10) default NULL,
  `id_producto` int(10) default NULL,
  `producto_costo` decimal(9,2) default '0.00',
  `descripcion` varchar(50) default NULL,
  `unidad` varchar(11) default NULL,
  `cantidad` decimal(10,3) default NULL,
  `precio` decimal(10,2) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `nombre_impuestos` varchar(50) default '',
  `impuesto` decimal(10,2) default '0.00',
  `id_almacen` int(11) default '0',
  `id_sucursal` int(11) default '0',
  `nombre_almacen` varchar(25) default 'NO ASIGNADO',
  `nombre_sucursal` varchar(25) default 'NO ASIGNADO',
  `importe` decimal(9,2) default NULL,
  PRIMARY KEY  (`id_detalle_pedido`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `devoluciones` */

DROP TABLE IF EXISTS `devoluciones`;

CREATE TABLE `devoluciones` (
  `id_devolucion` int(11) NOT NULL auto_increment,
  `id_venta` int(11) default NULL,
  `fecha` datetime default NULL,
  `subtotal` decimal(11,2) default NULL,
  `total_impuestos` decimal(11,2) default NULL,
  `total` decimal(11,2) default NULL,
  `tipo_devolucion` int(1) default '0',
  `id_empleado` int(11) default NULL,
  `bandera_corte_caja` int(11) default '0',
  PRIMARY KEY  (`id_devolucion`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Table structure for table `devoluciones_detalle` */

DROP TABLE IF EXISTS `devoluciones_detalle`;

CREATE TABLE `devoluciones_detalle` (
  `id_devolucion_detalle` int(11) NOT NULL auto_increment,
  `id_devolucion` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `descripcion` varchar(50) default NULL,
  `unidad` varchar(25) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `total_impuestos` decimal(11,2) default NULL,
  `importe` decimal(11,2) default NULL,
  `precio_unitario` decimal(11,2) default NULL,
  `id_almacen` int(11) default NULL,
  PRIMARY KEY  (`id_devolucion_detalle`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Table structure for table `devoluciones_proveedor` */

DROP TABLE IF EXISTS `devoluciones_proveedor`;

CREATE TABLE `devoluciones_proveedor` (
  `id_devolucion` int(11) NOT NULL auto_increment,
  `id_factura_compra` int(11) default NULL,
  `fecha` datetime default NULL,
  `subtotal` decimal(11,2) default NULL,
  `total_iva` decimal(11,2) default NULL,
  `total_otros` decimal(11,2) default NULL,
  `total` decimal(11,2) default NULL,
  `id_empleado` int(11) default NULL,
  `bandera_corte_caja` int(1) default '0',
  PRIMARY KEY  (`id_devolucion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `devoluciones_proveedor_detalle` */

DROP TABLE IF EXISTS `devoluciones_proveedor_detalle`;

CREATE TABLE `devoluciones_proveedor_detalle` (
  `id_devolucion_proveedor_detalle` int(11) NOT NULL auto_increment,
  `id_devolucion_proveedor` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `descripcion` varchar(50) default NULL,
  `unidad` varchar(25) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `importe` decimal(11,2) default NULL,
  `precio_unitario` decimal(11,2) default NULL,
  `id_almacen` int(11) default NULL,
  PRIMARY KEY  (`id_devolucion_proveedor_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `domicilio` */

DROP TABLE IF EXISTS `domicilio`;

CREATE TABLE `domicilio` (
  `id_domicilio` int(11) NOT NULL auto_increment,
  `calle` varchar(40) default '',
  `num_ext` varchar(10) default '',
  `num_int` varchar(10) default '',
  `colonia` varchar(100) default '',
  `municipio` varchar(100) default '',
  `cp` varchar(6) default '',
  `poblacion` varchar(40) default '',
  `estado` varchar(40) default '',
  `pais` varchar(40) default '',
  PRIMARY KEY  (`id_domicilio`)
) ENGINE=MyISAM AUTO_INCREMENT=3693 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `empleado` */

DROP TABLE IF EXISTS `empleado`;

CREATE TABLE `empleado` (
  `id_empleado` int(11) NOT NULL auto_increment,
  `curp` varchar(18) default NULL,
  `id_persona` int(11) default NULL,
  `id_domicilio` int(11) default NULL,
  `imagen` blob,
  `thumb` blob,
  `huella` blob,
  `id_puesto` int(11) NOT NULL,
  `puesto` varchar(100) default '',
  `fecha_alta` datetime default NULL,
  `fecha_modificacion` timestamp NULL default CURRENT_TIMESTAMP,
  `id_sucursal` int(11) NOT NULL,
  PRIMARY KEY  (`id_empleado`),
  KEY `FK_empleado` (`id_domicilio`),
  KEY `FK_empleado_persona` (`id_persona`)
) ENGINE=MyISAM AUTO_INCREMENT=36 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `empleado_horario` */

DROP TABLE IF EXISTS `empleado_horario`;

CREATE TABLE `empleado_horario` (
  `id_empleado` int(11) default NULL,
  `hora_entrada` time default NULL,
  `hora_salida` time default NULL,
  `tolerancia` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `empleado_jornada` */

DROP TABLE IF EXISTS `empleado_jornada`;

CREATE TABLE `empleado_jornada` (
  `id_empleado_jornada` int(11) NOT NULL auto_increment,
  `id_empleado` int(11) default NULL,
  `fecha` date default NULL,
  `hora_entrada` time default NULL,
  `hora_salida` time default NULL,
  `id_puesto` int(11) default NULL,
  PRIMARY KEY  (`id_empleado_jornada`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `empleado_opciones` */

DROP TABLE IF EXISTS `empleado_opciones`;

CREATE TABLE `empleado_opciones` (
  `id_empleado_opciones` int(11) NOT NULL auto_increment,
  `id_empleado` int(11) default '0',
  `posicion` int(11) default '0',
  `id_opcion` int(11) default '0',
  `opcion` text,
  `extra` varchar(100) default '',
  PRIMARY KEY  (`id_empleado_opciones`)
) ENGINE=MyISAM AUTO_INCREMENT=121 DEFAULT CHARSET=utf8;

/*Table structure for table `empleado_puesto` */

DROP TABLE IF EXISTS `empleado_puesto`;

CREATE TABLE `empleado_puesto` (
  `id_puesto` int(11) NOT NULL auto_increment,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY  (`id_puesto`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Table structure for table `empleado_tel` */

DROP TABLE IF EXISTS `empleado_tel`;

CREATE TABLE `empleado_tel` (
  `id_telefono` int(11) default '0',
  `id_empleado` int(11) default '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `empleados` */

DROP TABLE IF EXISTS `empleados`;

CREATE TABLE `empleados` (
  `id_sucursal` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  `nombre` varchar(122) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `empresa` */

DROP TABLE IF EXISTS `empresa`;

CREATE TABLE `empresa` (
  `id_empresa` int(11) NOT NULL auto_increment,
  `razon_social` varchar(100) NOT NULL,
  `alias` varchar(100) NOT NULL,
  `id_domicilio` int(11) NOT NULL,
  `url` varchar(60) default NULL,
  `rfc` varchar(15) default NULL,
  `email` varchar(40) default NULL,
  `tel_fijo` varchar(20) default '',
  `tel_cel` varchar(20) default '',
  `whatsapp` varchar(20) default '',
  `razon_temp` varchar(100) default '',
  PRIMARY KEY  (`id_empresa`),
  KEY `FK_proveedor` (`id_domicilio`)
) ENGINE=MyISAM AUTO_INCREMENT=2759 DEFAULT CHARSET=latin1;

/*Table structure for table `empresa_contacto` */

DROP TABLE IF EXISTS `empresa_contacto`;

CREATE TABLE `empresa_contacto` (
  `id_persona` int(11) default NULL,
  `id_empresa` int(11) default NULL,
  KEY `FK_empresa_contacto` (`id_empresa`),
  KEY `FK_empresa_contacto1` (`id_persona`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `empresa_tel` */

DROP TABLE IF EXISTS `empresa_tel`;

CREATE TABLE `empresa_tel` (
  `id_empresa` int(11) default '0',
  `id_telefono` int(11) default '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `factura` */

DROP TABLE IF EXISTS `factura`;

CREATE TABLE `factura` (
  `id_factura` int(10) NOT NULL auto_increment,
  `fecha` date default NULL,
  `numero` int(10) default NULL,
  `importe` decimal(10,2) default NULL,
  `descuento` decimal(10,2) default '0.00',
  `subtotal` decimal(10,2) default NULL,
  `otros` decimal(10,2) default NULL,
  `iva` decimal(10,2) default NULL,
  `total` decimal(10,2) default NULL,
  `id_cliente` int(10) default NULL,
  `id_empleado` int(10) default NULL,
  `estatus` varchar(20) default 'PENDIENTE',
  `num_factura_real` varchar(50) default '',
  PRIMARY KEY  (`id_factura`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `factura_compra` */

DROP TABLE IF EXISTS `factura_compra`;

CREATE TABLE `factura_compra` (
  `id_factura_compra` int(11) NOT NULL auto_increment,
  `fecha` datetime NOT NULL,
  `numero` varchar(10) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  `otros` decimal(10,2) default NULL,
  `iva` decimal(10,2) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `descuento` decimal(10,2) NOT NULL,
  `folio` varchar(10) default NULL,
  `id_proveedor` int(11) NOT NULL,
  `id_empleado_captura` int(11) default '0',
  `fecha_remision` date default NULL,
  `id_moneda` int(11) NOT NULL,
  `id_sucursal` int(11) NOT NULL,
  `importe` decimal(10,2) NOT NULL,
  `id_forma_pago` int(11) NOT NULL,
  `fecha_vencimiento` date default NULL,
  `id_almacen` int(11) NOT NULL,
  `status` varchar(25) NOT NULL default 'ACTIVO',
  `fecha_cancelacion` datetime default NULL,
  PRIMARY KEY  (`id_factura_compra`),
  KEY `FK_factura_compra` (`id_proveedor`),
  KEY `FK_factura_compras` (`id_sucursal`),
  KEY `FK_factura_compraM` (`id_moneda`),
  KEY `FK_factura_compra_pago` (`id_forma_pago`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `factura_compra_detalle` */

DROP TABLE IF EXISTS `factura_compra_detalle`;

CREATE TABLE `factura_compra_detalle` (
  `id_detalle_compra` int(11) NOT NULL auto_increment,
  `id_factura_compra` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `cantidad` decimal(11,2) NOT NULL,
  `impuesto` varchar(50) NOT NULL,
  `precio_unitario` decimal(10,2) NOT NULL,
  `unidad` varchar(20) default NULL,
  `descripcion` varchar(100) NOT NULL,
  PRIMARY KEY  (`id_detalle_compra`),
  KEY `FK_factura_compra_detalle` (`id_factura_compra`),
  KEY `FK_factura_compra_detallecom` (`id_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `factura_detalle` */

DROP TABLE IF EXISTS `factura_detalle`;

CREATE TABLE `factura_detalle` (
  `id_detalle` int(10) NOT NULL auto_increment,
  `id_factura` int(10) default NULL,
  `id_producto` int(10) default NULL,
  `descripcion` text,
  `cantidad` decimal(11,3) default NULL,
  `unidad` varchar(50) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `impuesto` varchar(50) default '',
  `precio_venta` decimal(10,2) default NULL,
  `descuento` decimal(5,2) default '0.00',
  `precio_unitario` decimal(10,2) default NULL,
  `importe` decimal(11,2) default '0.00',
  PRIMARY KEY  (`id_detalle`),
  KEY `FK_cotizacion_detalle` (`id_factura`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `factura_electronica` */

DROP TABLE IF EXISTS `factura_electronica`;

CREATE TABLE `factura_electronica` (
  `id_factura_electronica` int(10) NOT NULL auto_increment,
  `serie` varchar(50) default '',
  `fecha` datetime default NULL,
  `descuento` decimal(10,2) default '0.00',
  `subtotal` decimal(10,2) default NULL,
  `iva` decimal(10,2) default NULL,
  `iva_retenido` decimal(10,2) default '0.00',
  `total` decimal(10,2) default NULL,
  `id_cliente` int(10) default NULL,
  `id_empleado` int(10) default NULL,
  `estatus` varchar(20) default 'PENDIENTE',
  `id_forma_pago` int(11) default '0',
  `id_metodo_pago` int(11) default '0',
  `id_uso_cfdi` int(11) default '0',
  `condiciones_pago` varchar(200) default '',
  `pago_cuenta` varchar(20) default 'No Aplica',
  `estatus_timbrado` varchar(20) default 'PENDIENTE',
  PRIMARY KEY  (`id_factura_electronica`)
) ENGINE=MyISAM AUTO_INCREMENT=790 DEFAULT CHARSET=latin1;

/*Table structure for table `factura_electronica_detalle` */

DROP TABLE IF EXISTS `factura_electronica_detalle`;

CREATE TABLE `factura_electronica_detalle` (
  `id_factura_electronica_detalle` int(10) NOT NULL auto_increment,
  `id_factura_electronica` int(10) default NULL,
  `id_producto` int(10) default NULL,
  `cantidad` decimal(11,3) default NULL,
  `total_impuesto` decimal(11,4) default NULL,
  `tasa_impuesto` decimal(11,2) default '0.00',
  `nombre_impuesto` varchar(50) default '',
  `total_impuesto_retenido` decimal(11,2) default '0.00',
  `tasa_impuesto_retenido` decimal(11,2) default '0.00',
  `nombre_impuesto_retenido` varchar(50) default '',
  `precio` decimal(10,6) default NULL,
  `descuento` decimal(5,2) default '0.00',
  `importe` decimal(10,4) default NULL,
  PRIMARY KEY  (`id_factura_electronica_detalle`),
  KEY `FK_id_factura_electronica` (`id_factura_electronica`)
) ENGINE=MyISAM AUTO_INCREMENT=8900 DEFAULT CHARSET=latin1;

/*Table structure for table `factura_electronica_docs` */

DROP TABLE IF EXISTS `factura_electronica_docs`;

CREATE TABLE `factura_electronica_docs` (
  `id_factura_electronica_docs` int(11) NOT NULL auto_increment,
  `id_factura_electronica` int(11) default NULL,
  `id_tipo_relacion` int(11) default NULL,
  `UUID` varchar(100) default NULL,
  PRIMARY KEY  (`id_factura_electronica_docs`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Table structure for table `forma_pago` */

DROP TABLE IF EXISTS `forma_pago`;

CREATE TABLE `forma_pago` (
  `id_pago` int(11) default NULL,
  `descripcion` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `id_pedido_clientes` */

DROP TABLE IF EXISTS `id_pedido_clientes`;

CREATE TABLE `id_pedido_clientes` (
  `id_pedido` int(10) unsigned default NULL,
  `id_empleado` int(10) unsigned default NULL,
  `fecha_pedido` datetime default NULL,
  `fecha_entrega` datetime default NULL,
  `id_cliente` int(10) unsigned default NULL,
  `codigo` int(10) unsigned default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `impuesto` */

DROP TABLE IF EXISTS `impuesto`;

CREATE TABLE `impuesto` (
  `id_impuesto` int(11) NOT NULL auto_increment,
  `id_catalogo` int(11) default NULL,
  `nombre` varchar(30) default NULL,
  `alias` varchar(10) default NULL,
  `porcentaje` decimal(4,2) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_baja` date default NULL,
  PRIMARY KEY  (`id_impuesto`),
  KEY `FK_cat_imp_imp` (`id_catalogo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `impuesto_catalogo` */

DROP TABLE IF EXISTS `impuesto_catalogo`;

CREATE TABLE `impuesto_catalogo` (
  `id_catalogo` int(11) NOT NULL auto_increment,
  `nombre` varchar(20) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_baja` date default NULL,
  PRIMARY KEY  (`id_catalogo`),
  UNIQUE KEY `NewIndex1` (`nombre`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `inventario_fisico` */

DROP TABLE IF EXISTS `inventario_fisico`;

CREATE TABLE `inventario_fisico` (
  `id_inventario_fisico` int(11) NOT NULL auto_increment,
  `fecha_hora` datetime default NULL,
  `id_almacen` int(11) default '0',
  `id_empleado` int(11) default '0',
  `inventario_teorico` decimal(9,2) default NULL,
  `inventario_fisico` decimal(9,2) default NULL,
  `diferencia` decimal(9,2) default NULL,
  `estado` varchar(50) default 'ACTIVO',
  PRIMARY KEY  (`id_inventario_fisico`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `inventario_fisico_detalle` */

DROP TABLE IF EXISTS `inventario_fisico_detalle`;

CREATE TABLE `inventario_fisico_detalle` (
  `id_inventario_fisico_detalla` int(11) NOT NULL auto_increment,
  `id_inventario_fisico` int(11) default '0',
  `id_producto` int(11) default '0',
  `id_insumo` int(11) default '0',
  `id_presentacion` int(11) default '0',
  `cantidad_teorica` decimal(9,2) default '0.00',
  `cantidad_fisica` decimal(9,2) default '0.00',
  `costo_unitario` decimal(9,2) default '0.00',
  `diferencia_importe` decimal(9,2) default '0.00',
  PRIMARY KEY  (`id_inventario_fisico_detalla`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `manto_bitacora` */

DROP TABLE IF EXISTS `manto_bitacora`;

CREATE TABLE `manto_bitacora` (
  `id_manto_bitacora` int(11) NOT NULL auto_increment,
  `fecha_proceso` datetime default NULL,
  `fecha_inicial` date default NULL,
  `fecha_final` date default NULL,
  `total_cuentas` int(11) default NULL,
  `total_cuentas_modificadas` int(11) default NULL,
  `importe_anterior` decimal(9,2) default NULL,
  `importe_nuevo` decimal(9,2) default NULL,
  `diferencia` decimal(9,2) default NULL,
  `tipo_eliminacion` varchar(50) default '',
  PRIMARY KEY  (`id_manto_bitacora`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `manto_pagos_ventas` */

DROP TABLE IF EXISTS `manto_pagos_ventas`;

CREATE TABLE `manto_pagos_ventas` (
  `id_manto_cobro` int(11) NOT NULL auto_increment,
  `id_venta` int(11) NOT NULL,
  `importe` double(9,2) NOT NULL default '0.00',
  `cobro` double(10,2) default '0.00',
  `cambio` double(10,2) default '0.00',
  `id_forma_pago` int(11) default NULL,
  `fecha` datetime NOT NULL,
  `fecha_cobro` datetime NOT NULL,
  `fecha_cancelacion` datetime default NULL,
  `id_cuenta_receptor` int(11) NOT NULL,
  `banco_cliente` varchar(25) default NULL,
  `cuenta_cliente` varchar(25) default NULL,
  `banco_receptor` varchar(25) default NULL,
  `cuenta_receptor` varchar(25) default NULL,
  `num_referencia` varchar(25) default NULL,
  `num_cheque` int(11) NOT NULL,
  `num_tarjeta` varchar(25) default NULL,
  `nombre_cheque` varchar(50) default NULL,
  `status_cheque` varchar(25) NOT NULL default 'ACTIVO',
  `num_notacredito` int(11) NOT NULL,
  `nombre_notacredito` varchar(50) default NULL,
  `id_empleado_caja` int(11) default '0',
  `id_empleado_validacion` int(11) default '0',
  `status` varchar(50) default 'ACTIVO',
  `afecta_caja` int(1) default '1',
  `es_abono` int(1) default '0',
  `id_corte` int(11) default '0',
  PRIMARY KEY  (`id_manto_cobro`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `manto_venta` */

DROP TABLE IF EXISTS `manto_venta`;

CREATE TABLE `manto_venta` (
  `id_manto_venta` int(11) NOT NULL auto_increment,
  `id_venta` int(11) default NULL,
  `fecha` datetime default NULL,
  `id_sucursal` int(11) default '1',
  `id_empleado` int(11) default '0',
  `id_empleado_caja` int(11) default '0',
  `id_empleado_validacion` int(11) default '0',
  `id_cliente` int(11) default '1',
  `cliente_publico_alias` varchar(200) default '',
  `num_ticket` int(11) default NULL,
  `id_forma_pago` int(1) default '0',
  `subtotal` decimal(11,2) default '0.00',
  `total_iva` decimal(11,2) default '0.00',
  `total_otros` decimal(11,2) default '0.00',
  `total_descuento` decimal(11,2) default '0.00',
  `total` decimal(10,2) default '0.00',
  `codigo` varchar(25) default NULL,
  `id_factura` int(11) default '0',
  `id_corte` int(11) default '0',
  `desc_global_porcent` decimal(9,2) default '0.00',
  `desc_global_importe` decimal(9,2) default '0.00',
  `fecha_salida_almacen` datetime default NULL,
  `credito` int(1) default '0',
  `status` varchar(15) default 'ABIERTA',
  `id_bitacora` int(11) default '0',
  PRIMARY KEY  (`id_manto_venta`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `manto_venta_detalle` */

DROP TABLE IF EXISTS `manto_venta_detalle`;

CREATE TABLE `manto_venta_detalle` (
  `id_manto_venta_detalle` int(11) NOT NULL auto_increment,
  `id_venta` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `producto_costo` decimal(9,2) default '0.00',
  `cantidad` decimal(11,3) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `nombre_impuestos` varchar(50) default '',
  `precio` decimal(10,2) default NULL,
  `impuesto` decimal(10,2) default NULL,
  `descripcion` text,
  `unidad` varchar(50) default NULL,
  `id_almacen` int(11) default NULL,
  `descuento` decimal(11,2) default '0.00',
  `importe` decimal(11,2) default '0.00',
  `modificador` int(1) default '0',
  `id_producto_modificador` int(11) default '0',
  PRIMARY KEY  (`id_manto_venta_detalle`),
  KEY `FK_venta_detalle` (`id_venta`),
  KEY `FK_venta_detalle_producto` (`id_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `mesas` */

DROP TABLE IF EXISTS `mesas`;

CREATE TABLE `mesas` (
  `id_mesa` int(11) NOT NULL auto_increment,
  `id_area` int(11) default '0',
  `nombre` varchar(15) default '',
  PRIMARY KEY  (`id_mesa`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `meseros` */

DROP TABLE IF EXISTS `meseros`;

CREATE TABLE `meseros` (
  `id_mesero` int(11) NOT NULL auto_increment,
  `clave` varchar(20) default '',
  `nombre` varchar(20) default '',
  `password` varchar(20) default '',
  `id_meseros_tipo` int(11) default '0',
  `id_perfil` int(11) default '0',
  `imagen` blob,
  PRIMARY KEY  (`id_mesero`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `meseros_tipo` */

DROP TABLE IF EXISTS `meseros_tipo`;

CREATE TABLE `meseros_tipo` (
  `id_meseros_tipo` int(11) NOT NULL auto_increment,
  `nombre` varchar(15) default '',
  PRIMARY KEY  (`id_meseros_tipo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `modificadores` */

DROP TABLE IF EXISTS `modificadores`;

CREATE TABLE `modificadores` (
  `id_modificador` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default NULL,
  PRIMARY KEY  (`id_modificador`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `moneda` */

DROP TABLE IF EXISTS `moneda`;

CREATE TABLE `moneda` (
  `id_moneda` int(11) NOT NULL auto_increment,
  `nombre` varchar(30) default NULL,
  `nombre_corto` varchar(15) default NULL,
  `valor` decimal(10,2) default NULL,
  `siglas` varchar(5) default NULL,
  `rss` tinyint(1) default NULL,
  `fecha_modificacion` date default NULL,
  PRIMARY KEY  (`id_moneda`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `moviles` */

DROP TABLE IF EXISTS `moviles`;

CREATE TABLE `moviles` (
  `id_movil` int(11) NOT NULL auto_increment,
  `id_sucursal` int(11) NOT NULL,
  `num_unidad` varchar(11) NOT NULL,
  `cap_carga` double(10,2) default '0.00',
  `placas` varchar(10) default 'ESTADO',
  `aseguradora` varchar(25) default 'COMPAÑIA',
  `num_poliza` varchar(25) default '20110601',
  `status_unidad` varchar(11) NOT NULL default 'ACTIVA',
  `id_tipomovil` int(2) default '0',
  PRIMARY KEY  (`id_movil`),
  KEY `FK_moviles` (`id_sucursal`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `nota_credito` */

DROP TABLE IF EXISTS `nota_credito`;

CREATE TABLE `nota_credito` (
  `id_nota_credito` int(10) NOT NULL auto_increment,
  `serie` varchar(50) default '',
  `fecha` datetime default NULL,
  `descuento` decimal(10,2) default '0.00',
  `subtotal` decimal(10,2) default NULL,
  `iva` decimal(10,2) default NULL,
  `total` decimal(10,2) default NULL,
  `id_cliente` int(10) default NULL,
  `id_empleado` int(10) default NULL,
  `estatus` varchar(20) default 'PENDIENTE',
  `id_forma_pago` int(11) default '0',
  `id_metodo_pago` int(11) default '0',
  `id_uso_cfdi` int(11) default '0',
  `condiciones_pago` varchar(200) default '',
  `pago_cuenta` varchar(20) default 'No Aplica',
  `estatus_timbrado` varchar(20) default 'PENDIENTE',
  PRIMARY KEY  (`id_nota_credito`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `nota_credito_detalle` */

DROP TABLE IF EXISTS `nota_credito_detalle`;

CREATE TABLE `nota_credito_detalle` (
  `id_nota_credito_detalle` int(10) NOT NULL auto_increment,
  `id_nota_credito` int(10) default NULL,
  `id_producto` int(10) default NULL,
  `cantidad` decimal(11,3) default NULL,
  `total_impuesto` decimal(11,2) default NULL,
  `tasa_impuesto` decimal(11,2) default '0.00',
  `nombre_impuesto` varchar(50) default '',
  `precio` decimal(10,4) default NULL,
  `descuento` decimal(5,2) default '0.00',
  `importe` decimal(10,2) default NULL,
  PRIMARY KEY  (`id_nota_credito_detalle`),
  KEY `FK_id_factura_electronica` (`id_nota_credito`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `nota_credito_docs` */

DROP TABLE IF EXISTS `nota_credito_docs`;

CREATE TABLE `nota_credito_docs` (
  `id_nota_credito_docs` int(11) NOT NULL auto_increment,
  `id_nota_credito` int(11) default NULL,
  `id_tipo_relacion` int(11) default NULL,
  `UUID` varchar(100) default NULL,
  PRIMARY KEY  (`id_nota_credito_docs`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `orden_comedor` */

DROP TABLE IF EXISTS `orden_comedor`;

CREATE TABLE `orden_comedor` (
  `id_orden` int(11) NOT NULL auto_increment,
  `id_area` int(11) default '1',
  `folio` varchar(50) default '',
  `cuenta` varchar(50) default '',
  `id_mesero` int(11) default NULL,
  `num_personas` int(11) default NULL,
  `apertura` datetime default NULL,
  `cierre` datetime default NULL,
  `id_cliente` decimal(11,0) default '1',
  `estatus` varchar(50) default 'PENDIENTE',
  `id_venta` int(11) default '0',
  PRIMARY KEY  (`id_orden`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `orden_comedor_detalle` */

DROP TABLE IF EXISTS `orden_comedor_detalle`;

CREATE TABLE `orden_comedor_detalle` (
  `id_orden_comedor_detalle` int(11) NOT NULL auto_increment,
  `id_orden_comedor` int(11) default '0',
  `id_empleado` int(10) unsigned default NULL,
  `id_producto` int(10) unsigned default NULL,
  `descripcion` varchar(25) default NULL,
  `unidad` varchar(25) default NULL,
  `cantidad` decimal(10,3) default NULL,
  `precio` decimal(10,2) default NULL,
  `impuesto` decimal(10,2) default NULL,
  `importe` decimal(10,4) default NULL,
  `id_venta` int(10) unsigned default NULL,
  `total_iva` decimal(11,0) default NULL,
  `total_otros` decimal(11,0) default NULL,
  `nombre_impuestos` varchar(50) default '',
  `id_cliente` int(11) default NULL,
  `id_almacen` int(11) default NULL,
  `descuento` decimal(11,2) default '0.00',
  `desc_global_porcent` decimal(9,2) default '0.00',
  `desc_global_importe` decimal(9,2) default '0.00',
  `observaciones` text,
  `modificador` int(1) default '0',
  `id_producto_modificador` int(11) default '0',
  PRIMARY KEY  (`id_orden_comedor_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `orden_comedor_mesa` */

DROP TABLE IF EXISTS `orden_comedor_mesa`;

CREATE TABLE `orden_comedor_mesa` (
  `id_orden_comedor_mesa` int(11) NOT NULL auto_increment,
  `id_mesa` int(11) default '0',
  `id_orden` int(11) default '0',
  PRIMARY KEY  (`id_orden_comedor_mesa`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `orden_compra` */

DROP TABLE IF EXISTS `orden_compra`;

CREATE TABLE `orden_compra` (
  `id_orden_compra` int(11) NOT NULL auto_increment,
  `folio` int(11) default '0',
  `id_solicitud` int(11) default '0',
  `id_proveedor` int(11) default '0',
  `fecha` datetime default NULL,
  `factura` varchar(100) default '',
  `folio_fiscal` varchar(500) default '',
  `id_persona_elabora` int(11) default '0',
  `subtotal` decimal(9,2) default '0.00',
  `total_impuestos` decimal(9,2) default '0.00',
  `total` decimal(9,2) default '0.00',
  `id_persona_aut1` int(11) default '0',
  `id_persona_aut2` int(11) default '0',
  `id_persona_aut3` int(11) default '0',
  `status` varchar(100) default 'PENDIENTE',
  PRIMARY KEY  (`id_orden_compra`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `orden_compra_detalle` */

DROP TABLE IF EXISTS `orden_compra_detalle`;

CREATE TABLE `orden_compra_detalle` (
  `id_orden_compra_detalle` int(11) NOT NULL auto_increment,
  `id_orden_compra` int(11) default '0',
  `id_cmi_requisicion_detalle` int(11) default '0',
  `id_partida` int(11) default '0',
  `partida` varchar(50) default '0',
  `unidad` varchar(50) default '0',
  `descripcion` text,
  `precio_unitario` decimal(9,2) default '0.00',
  `impuesto` varchar(50) default '0',
  `importe` decimal(9,2) default '0.00',
  `cantidad` decimal(9,2) default '0.00',
  `total` decimal(9,2) default '0.00',
  `id_impuesto` int(11) default '0',
  `total_impuesto` decimal(9,2) default '0.00',
  `id_unidad` int(11) default '0',
  PRIMARY KEY  (`id_orden_compra_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `pagos_compras` */

DROP TABLE IF EXISTS `pagos_compras`;

CREATE TABLE `pagos_compras` (
  `id_pago` int(11) NOT NULL auto_increment,
  `id_factura_compra` int(11) NOT NULL,
  `id_empleado_pago` int(11) default NULL,
  `importe` double(9,2) NOT NULL default '0.00',
  `id_forma_pago` int(11) default NULL,
  `fecha` datetime NOT NULL,
  `fecha_pago` datetime NOT NULL,
  `fecha_cancelacion` datetime default NULL,
  `id_cuenta` int(11) NOT NULL,
  `banco` varchar(25) default NULL,
  `num_tarjeta` varchar(50) default NULL,
  `cuenta` varchar(25) default NULL,
  `banco_receptor` varchar(25) default NULL,
  `cuenta_receptor` varchar(25) default NULL,
  `num_referencia` varchar(25) default NULL,
  `num_cheque` int(11) NOT NULL,
  `nombre_cheque` varchar(50) default NULL,
  `status_cheque` varchar(25) NOT NULL default 'ACTIVO',
  `num_notacredito` int(11) NOT NULL,
  `nombre_notacredito` varchar(50) default NULL,
  `status` varchar(50) default 'ACTIVO',
  `afecta_caja` int(1) default '1',
  `id_corte` int(11) default '0',
  PRIMARY KEY  (`id_pago`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `pagos_ventas` */

DROP TABLE IF EXISTS `pagos_ventas`;

CREATE TABLE `pagos_ventas` (
  `id_cobro` int(11) NOT NULL auto_increment,
  `id_venta` int(11) NOT NULL,
  `importe` double(9,2) NOT NULL default '0.00',
  `cobro` double(10,2) default '0.00',
  `cambio` double(10,2) default '0.00',
  `id_forma_pago` int(11) default NULL,
  `fecha` datetime NOT NULL,
  `fecha_cobro` datetime NOT NULL,
  `fecha_cancelacion` datetime default NULL,
  `id_cuenta_receptor` int(11) NOT NULL,
  `banco_cliente` varchar(25) default NULL,
  `cuenta_cliente` varchar(25) default NULL,
  `banco_receptor` varchar(25) default NULL,
  `cuenta_receptor` varchar(25) default NULL,
  `num_referencia` varchar(25) default NULL,
  `num_cheque` int(11) NOT NULL,
  `num_tarjeta` varchar(25) default NULL,
  `nombre_cheque` varchar(50) default NULL,
  `status_cheque` varchar(25) NOT NULL default 'ACTIVO',
  `num_notacredito` int(11) NOT NULL,
  `nombre_notacredito` varchar(50) default NULL,
  `id_empleado_caja` int(11) default '0',
  `id_empleado_validacion` int(11) default '0',
  `status` varchar(50) default 'ACTIVO',
  `afecta_caja` int(1) default '1',
  `es_abono` int(1) default '0',
  `id_corte` int(11) default '0',
  PRIMARY KEY  (`id_cobro`)
) ENGINE=InnoDB AUTO_INCREMENT=2337 DEFAULT CHARSET=latin1;

/*Table structure for table `paquete_modificador_producto` */

DROP TABLE IF EXISTS `paquete_modificador_producto`;

CREATE TABLE `paquete_modificador_producto` (
  `id_paquete_modificador_producto` int(11) NOT NULL auto_increment,
  `id_paquete` int(11) default NULL,
  `id_modificador` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(9,2) default NULL,
  PRIMARY KEY  (`id_paquete_modificador_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `pedido_clientes` */

DROP TABLE IF EXISTS `pedido_clientes`;

CREATE TABLE `pedido_clientes` (
  `id_pedido` int(10) unsigned NOT NULL auto_increment,
  `id_empleado` int(10) unsigned NOT NULL,
  `fecha_pedido` datetime default NULL,
  `fecha_entrega` datetime default NULL,
  `id_cliente` int(10) unsigned default NULL,
  `codigo` int(10) unsigned default NULL,
  `subtotal` decimal(11,2) default NULL,
  `iva` decimal(11,2) default NULL,
  `otros_impuestos` decimal(11,2) default NULL,
  `total` decimal(10,2) default NULL,
  `id_sucursal` int(10) unsigned default NULL,
  `num_ticket` int(10) unsigned default NULL,
  `id_factura` int(11) default '0',
  `surtido` int(1) default '0',
  `programado` int(1) default '0',
  `id_empleado_entrega` int(1) default '0',
  `id_venta` int(1) default '0',
  `status` varchar(15) default 'PENDIENTE',
  `status_pago` varchar(20) default 'PENDIENTE',
  `id_retiro` int(11) default '0',
  `entregado` int(11) default '0',
  `comentarios` text,
  PRIMARY KEY  (`id_pedido`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `pedido_prog` */

DROP TABLE IF EXISTS `pedido_prog`;

CREATE TABLE `pedido_prog` (
  `id_pedido_prog` int(11) NOT NULL auto_increment,
  `numero` int(10) default NULL,
  `nombre_programacion` varchar(35) default NULL,
  `id_empleado` int(11) default NULL,
  `id_cliente` int(11) default NULL,
  `id_sucursal` int(11) default NULL,
  `intervalo` int(11) default NULL,
  `id_periodicidad` int(11) default NULL,
  `periodicidad` varchar(25) default NULL,
  `hora` time default NULL,
  `fecha_creacion` datetime default NULL,
  `fecha_modificacion` datetime default NULL,
  `fecha_prox_entrega` datetime default NULL,
  `dias_anticipacion` int(11) default '3',
  `subtotal` decimal(11,2) default NULL,
  `iva` decimal(11,2) default NULL,
  `otros_impuestos` decimal(11,2) default NULL,
  `total` decimal(11,2) default NULL,
  PRIMARY KEY  (`id_pedido_prog`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `pedido_prog_detalle` */

DROP TABLE IF EXISTS `pedido_prog_detalle`;

CREATE TABLE `pedido_prog_detalle` (
  `id_pedido_prog_detalle` int(11) NOT NULL auto_increment,
  `id_pedido_prog` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `descripcion` varchar(25) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `unidad` varchar(15) default NULL,
  `precio` decimal(11,2) default NULL,
  `impuesto` decimal(11,2) default NULL,
  PRIMARY KEY  (`id_pedido_prog_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `perfil` */

DROP TABLE IF EXISTS `perfil`;

CREATE TABLE `perfil` (
  `id_perfil` int(11) NOT NULL auto_increment,
  `nombre` varchar(25) default NULL,
  `usuarios` int(1) default '0',
  `cuentas_bancarias` int(1) default '0',
  `impuestos` int(1) default '0',
  `productos` int(1) default '0',
  `catalogo` int(1) default '0',
  `sucursal` int(1) default '0',
  `almacenes` int(1) default '0',
  `directorio` int(1) default '0',
  `directorio_soloalta` int(1) default '0',
  `cotizaciones` int(1) default '0',
  `compras` int(1) default '0',
  `compras_rapidas` int(1) default '0',
  `pedidos` int(1) default '0',
  `caja` int(1) default '0',
  `pagos` int(1) default '0',
  `facturacion` int(1) default '0',
  `punto_venta` int(1) default '0',
  `cobros_creditos` int(1) default '0',
  `corte_caja` int(1) default '0',
  `corte_x` int(1) default '0',
  `cancelar_venta` int(1) default '0',
  `cancelar_pagos` int(1) default '0',
  `precio_especial` int(1) default '0',
  `regalias` int(1) default '0',
  `cambio_precio` int(1) default '0',
  `cobro_terminal` int(1) default '0',
  `pago_proveedores_terminal` int(1) default '0',
  `recepcion_producto_terminal` int(1) default '0',
  `ajuste_inventario` int(1) default '0',
  `clasificacion_productos` int(1) default '0',
  `favoritos` int(1) default '0',
  `conversiones` int(1) default '0',
  `programacion_pedidos` int(1) default '0',
  `vehiculos` int(1) default '0',
  `repartidores` int(1) default '0',
  `catalogo_precios` int(1) default '0',
  `perfiles_impresion` int(1) default '0',
  `cfg_conversiones` int(1) default '0',
  `cfg_empresa` int(1) default '0',
  `traspasos_env` int(1) default '0',
  `traspasos_recep` int(1) default '0',
  `reporteador` int(1) default '0',
  `cfg_descuentos` int(1) default '0',
  `cfg_godmode` int(1) default '0',
  `devoluciones` int(1) default '0',
  `cfg_correo` int(1) default '0',
  `ajuste_conversiones` int(1) default '0',
  `cancelar_apartado` int(1) default '0',
  PRIMARY KEY  (`id_perfil`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

/*Table structure for table `perfil_empleado` */

DROP TABLE IF EXISTS `perfil_empleado`;

CREATE TABLE `perfil_empleado` (
  `id_perfil_empleado` int(11) NOT NULL auto_increment,
  `id_perfil` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  PRIMARY KEY  (`id_perfil_empleado`)
) ENGINE=MyISAM AUTO_INCREMENT=106 DEFAULT CHARSET=latin1;

/*Table structure for table `perfil_impresion` */

DROP TABLE IF EXISTS `perfil_impresion`;

CREATE TABLE `perfil_impresion` (
  `id_perfil_impresion` int(11) NOT NULL auto_increment,
  `id_tipo_documento` int(11) default '0',
  `nombre_tipo_documento` varchar(50) default NULL,
  `nombre_perfil` varchar(50) default NULL,
  `alto_pagina` decimal(11,2) default NULL,
  `ancho_pagina` decimal(11,2) default NULL,
  `ajuste_x` decimal(11,2) default '0.00',
  `ajuste_y` decimal(11,2) default '0.00',
  `max_lineas` int(11) default '0',
  PRIMARY KEY  (`id_perfil_impresion`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `perfil_impresion_campos` */

DROP TABLE IF EXISTS `perfil_impresion_campos`;

CREATE TABLE `perfil_impresion_campos` (
  `id_perfil_impresion_campos` int(11) NOT NULL auto_increment,
  `id_perfil_impresion` int(11) default NULL,
  `id_campo_documento` int(11) default NULL,
  `nombre` varchar(50) default NULL,
  `x` decimal(11,2) default NULL,
  `y` decimal(11,2) default NULL,
  PRIMARY KEY  (`id_perfil_impresion_campos`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `perfil_proveedor` */

DROP TABLE IF EXISTS `perfil_proveedor`;

CREATE TABLE `perfil_proveedor` (
  `id_perfil_proveedor` int(11) NOT NULL auto_increment,
  `id_perfil` int(11) default NULL,
  `id_proveedor` int(11) default NULL,
  PRIMARY KEY  (`id_perfil_proveedor`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `persona` */

DROP TABLE IF EXISTS `persona`;

CREATE TABLE `persona` (
  `id_persona` int(11) NOT NULL auto_increment,
  `titulo` varchar(20) default '',
  `nombre` varchar(40) default '',
  `ap_paterno` varchar(40) default '',
  `ap_materno` varchar(40) default '',
  `rfc` varchar(15) default '',
  `email` varchar(40) default '',
  `fecha_nacimiento` date default NULL,
  `alias` varchar(50) default '',
  `tel_fijo` varchar(20) default '',
  `tel_cel` varchar(20) default '',
  `whatsapp` varchar(20) default '',
  PRIMARY KEY  (`id_persona`)
) ENGINE=MyISAM AUTO_INCREMENT=931 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `persona_tel` */

DROP TABLE IF EXISTS `persona_tel`;

CREATE TABLE `persona_tel` (
  `id_persona` int(11) default NULL,
  `id_telefono` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `precio_nombre` */

DROP TABLE IF EXISTS `precio_nombre`;

CREATE TABLE `precio_nombre` (
  `id_nombre_precio` int(2) NOT NULL auto_increment,
  `nombre` varchar(25) default NULL,
  PRIMARY KEY  (`id_nombre_precio`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `prefactura` */

DROP TABLE IF EXISTS `prefactura`;

CREATE TABLE `prefactura` (
  `id_factura` int(10) NOT NULL auto_increment,
  `fecha` date default NULL,
  `numero` int(10) default NULL,
  `importe` decimal(10,2) default NULL,
  `descuento` decimal(10,2) default '0.00',
  `subtotal` decimal(10,2) default NULL,
  `otros` decimal(10,2) default NULL,
  `iva` decimal(10,2) default NULL,
  `total` decimal(10,2) default NULL,
  `id_cliente` int(10) default NULL,
  `id_empleado` int(10) default NULL,
  `estatus` varchar(20) default 'PENDIENTE',
  `num_factura_real` varchar(50) default '',
  PRIMARY KEY  (`id_factura`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `prefactura_detalle` */

DROP TABLE IF EXISTS `prefactura_detalle`;

CREATE TABLE `prefactura_detalle` (
  `id_detalle` int(10) NOT NULL auto_increment,
  `id_factura` int(10) default NULL,
  `id_producto` int(10) default NULL,
  `descripcion` text,
  `cantidad` decimal(11,3) default NULL,
  `unidad` varchar(50) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `impuesto` varchar(50) default '',
  `precio_venta` decimal(10,2) default NULL,
  `descuento` decimal(5,2) default '0.00',
  `precio_unitario` decimal(10,2) default NULL,
  `importe` decimal(11,2) default '0.00',
  PRIMARY KEY  (`id_detalle`),
  KEY `FK_cotizacion_detalle` (`id_factura`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `producto` */

DROP TABLE IF EXISTS `producto`;

CREATE TABLE `producto` (
  `id_producto` int(11) NOT NULL auto_increment,
  `nombre` text NOT NULL,
  `codigo` varchar(30) default NULL,
  `id_unidad` int(3) default NULL,
  `precio` decimal(9,2) default '0.00',
  `precio_neto` decimal(9,2) default '0.00',
  `venta_peso` int(1) default '0',
  `id_categoria` int(11) default '1',
  `descripcion` text,
  `costo` decimal(10,2) default '0.00',
  `costo_neto` decimal(9,2) default '0.00',
  `id_marca` int(5) default NULL,
  `id_modelo` int(11) default '0',
  `imagen` blob,
  `thumb` blob,
  `visitas` int(5) default '0',
  `id_almacen` int(11) default '0',
  `fecha_alta` datetime NOT NULL,
  `fecha_modificacion` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `favorito` int(2) unsigned NOT NULL default '0',
  `favorito_cat` int(2) default '0',
  `id_talla` int(11) default '1',
  `id_color` int(11) default '1',
  `id_impuesto` int(11) default '0',
  `precio_especial` decimal(9,2) default NULL,
  `precio_especial_inicio` date default NULL,
  `precio_especial_termino` date default NULL,
  `id_clavesat` int(11) default NULL,
  `paquete` int(1) default '0',
  PRIMARY KEY  (`id_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=8220 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_cat_imp` */

DROP TABLE IF EXISTS `producto_cat_imp`;

CREATE TABLE `producto_cat_imp` (
  `id_producto` int(11) default NULL,
  `id_catalogo` int(11) default NULL,
  KEY `FK_prod_cat_imp` (`id_producto`),
  KEY `FK_prod_cat_imp_cat` (`id_catalogo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_clavesat` */

DROP TABLE IF EXISTS `producto_clavesat`;

CREATE TABLE `producto_clavesat` (
  `id_clavesat` int(9) NOT NULL auto_increment,
  `clave` varchar(100) default NULL,
  `Nombre` varchar(100) default NULL,
  PRIMARY KEY  (`id_clavesat`)
) ENGINE=MyISAM AUTO_INCREMENT=485 DEFAULT CHARSET=utf8;

/*Table structure for table `producto_color` */

DROP TABLE IF EXISTS `producto_color`;

CREATE TABLE `producto_color` (
  `id_color` int(11) NOT NULL auto_increment,
  `nombre` varchar(100) default '',
  PRIMARY KEY  (`id_color`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

/*Table structure for table `producto_compuesto` */

DROP TABLE IF EXISTS `producto_compuesto`;

CREATE TABLE `producto_compuesto` (
  `id_producto` int(11) default NULL,
  `id_articulo` int(11) default NULL,
  `num_articulo` decimal(11,2) default NULL,
  KEY `FK_producto_compuesto` (`id_producto`),
  KEY `FK_producto_compuesto1` (`id_articulo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_costo` */

DROP TABLE IF EXISTS `producto_costo`;

CREATE TABLE `producto_costo` (
  `id_producto_costo` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `costo` decimal(9,2) default NULL,
  `fecha` datetime default NULL,
  PRIMARY KEY  (`id_producto_costo`)
) ENGINE=MyISAM AUTO_INCREMENT=8370 DEFAULT CHARSET=utf8;

/*Table structure for table `producto_equivalente` */

DROP TABLE IF EXISTS `producto_equivalente`;

CREATE TABLE `producto_equivalente` (
  `id_producto_equivalente` int(11) NOT NULL auto_increment,
  `cantidad_origen` decimal(11,2) default NULL,
  `id_producto_origen` int(11) default NULL,
  `cantidad_destino` decimal(11,2) default NULL,
  `id_producto_destino` int(11) default NULL,
  PRIMARY KEY  (`id_producto_equivalente`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `producto_marca` */

DROP TABLE IF EXISTS `producto_marca`;

CREATE TABLE `producto_marca` (
  `id_marca` int(5) NOT NULL auto_increment,
  `nombre` varchar(20) default NULL,
  PRIMARY KEY  (`id_marca`)
) ENGINE=MyISAM AUTO_INCREMENT=272 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_modelo` */

DROP TABLE IF EXISTS `producto_modelo`;

CREATE TABLE `producto_modelo` (
  `id_modelo` int(11) NOT NULL auto_increment,
  `nombre` varchar(100) default '',
  PRIMARY KEY  (`id_modelo`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Table structure for table `producto_modificador` */

DROP TABLE IF EXISTS `producto_modificador`;

CREATE TABLE `producto_modificador` (
  `id_producto_modificador` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `id_modificador` int(11) default NULL,
  PRIMARY KEY  (`id_producto_modificador`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `producto_paquete` */

DROP TABLE IF EXISTS `producto_paquete`;

CREATE TABLE `producto_paquete` (
  `id_producto` int(11) default NULL,
  KEY `FK_producto_paquete` (`id_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_precio` */

DROP TABLE IF EXISTS `producto_precio`;

CREATE TABLE `producto_precio` (
  `id_producto_precio` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `id_ctlg_precios` int(11) default NULL,
  `utilidad` decimal(9,2) default NULL,
  `precio` decimal(9,2) default NULL,
  PRIMARY KEY  (`id_producto_precio`),
  KEY `FK_producto_precio` (`precio`)
) ENGINE=MyISAM AUTO_INCREMENT=16438 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_recepcion` */

DROP TABLE IF EXISTS `producto_recepcion`;

CREATE TABLE `producto_recepcion` (
  `id_recepcion` int(11) NOT NULL auto_increment,
  `id_sucursal` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  `id_factura_compra` int(11) default NULL,
  `fecha_recepcion` datetime default NULL,
  PRIMARY KEY  (`id_recepcion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_sucursal` */

DROP TABLE IF EXISTS `producto_sucursal`;

CREATE TABLE `producto_sucursal` (
  `id_producto_sucursal` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `id_sucursal` int(11) default NULL,
  `id_almacen` int(11) default '0',
  `cantidad` decimal(11,3) default '0.000',
  `fecha_alta` datetime default NULL,
  `fecha_baja` date default NULL,
  `precio_especial` decimal(10,2) default '0.00',
  `precio_especial_inicio` date default NULL,
  `precio_especial_termino` date default NULL,
  `cantidad_minima` int(11) default '0',
  `cantidad_maxima` int(11) default '0',
  `merma` decimal(11,2) default '0.00',
  PRIMARY KEY  (`id_producto_sucursal`),
  KEY `FK_producto_sucursal` (`id_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=8220 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `producto_talla` */

DROP TABLE IF EXISTS `producto_talla`;

CREATE TABLE `producto_talla` (
  `id_talla` int(11) NOT NULL auto_increment,
  `nombre` varchar(100) default '',
  PRIMARY KEY  (`id_talla`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `producto_volumen` */

DROP TABLE IF EXISTS `producto_volumen`;

CREATE TABLE `producto_volumen` (
  `id_descuento` int(11) NOT NULL auto_increment,
  `nombre` varchar(20) default NULL,
  `id_catalogo_precio` int(11) default '0',
  `utilidad` decimal(5,2) default '0.00',
  `descuento` decimal(5,2) default NULL,
  `id_producto` int(11) default NULL,
  `rango_inicial` int(10) default NULL,
  `rango_final` int(10) default NULL,
  PRIMARY KEY  (`id_descuento`),
  KEY `FK_producto_volumen` (`id_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `proveedor` */

DROP TABLE IF EXISTS `proveedor`;

CREATE TABLE `proveedor` (
  `id_proveedor` int(11) NOT NULL auto_increment,
  `clave` varchar(30) default '',
  `id_persona` int(11) default NULL,
  `id_empresa` int(11) default NULL,
  `id_domicilio` int(11) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_modificacion` timestamp NULL default CURRENT_TIMESTAMP,
  PRIMARY KEY  (`id_proveedor`),
  KEY `FK_clientes` (`id_persona`),
  KEY `FK_clientes_domicilio` (`id_domicilio`),
  KEY `FK_cliente_empresa` (`id_empresa`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `proveedor_cuenta` */

DROP TABLE IF EXISTS `proveedor_cuenta`;

CREATE TABLE `proveedor_cuenta` (
  `id_cuenta_proveedor` int(25) NOT NULL auto_increment,
  `id_proveedor` int(11) NOT NULL,
  `banco` varchar(25) NOT NULL,
  `cuenta` varchar(25) NOT NULL,
  `sucursal` varchar(25) default '',
  `clabe` varchar(25) default '',
  PRIMARY KEY  (`id_cuenta_proveedor`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `proveedor_productos` */

DROP TABLE IF EXISTS `proveedor_productos`;

CREATE TABLE `proveedor_productos` (
  `id_proveedor_producto` int(11) NOT NULL auto_increment,
  `id_proveedor` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` double(9,2) default '0.00',
  `precio_unitario` double(9,2) default '0.00',
  PRIMARY KEY  (`id_proveedor_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `proveedores` */

DROP TABLE IF EXISTS `proveedores`;

CREATE TABLE `proveedores` (
  `id_proveedor` int(11) default NULL,
  `rfc` varchar(15) default NULL,
  `razon_social` varchar(122) default NULL,
  `domicilio` varchar(64) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `rest_insumo` */

DROP TABLE IF EXISTS `rest_insumo`;

CREATE TABLE `rest_insumo` (
  `id_insumo` int(11) NOT NULL auto_increment,
  `id_insumo_grupo` int(11) default '0',
  `clave` varchar(10) default '',
  `descripcion` varchar(100) default '',
  `id_unidad` int(11) default NULL,
  `ultimo_costo` decimal(9,2) default '0.00',
  `costo_promedio` decimal(9,2) default '0.00',
  `id_impuesto` int(11) default '0',
  `costo_cimpuestos` decimal(9,2) default '0.00',
  `inventariable` int(1) default '1',
  PRIMARY KEY  (`id_insumo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `rest_insumo_grupo` */

DROP TABLE IF EXISTS `rest_insumo_grupo`;

CREATE TABLE `rest_insumo_grupo` (
  `id_insumo_grupo` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default '',
  `grupo` varchar(100) default '',
  PRIMARY KEY  (`id_insumo_grupo`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `rest_presentacion` */

DROP TABLE IF EXISTS `rest_presentacion`;

CREATE TABLE `rest_presentacion` (
  `id_presentacion` int(11) NOT NULL auto_increment,
  `id_insumo_grupo` int(11) default '0',
  `clave` varchar(10) default '',
  `descripcion` varchar(100) default '',
  `id_unidad` int(11) default NULL,
  `ultimo_costo` decimal(9,2) default '0.00',
  `costo_promedio` decimal(9,2) default '0.00',
  `costo_estandar` decimal(9,2) default '0.00',
  `id_impuesto` int(11) default '0',
  `costo_cimpuestos` decimal(9,2) default '0.00',
  `id_proveedor` int(11) default '0',
  `id_insumo` int(11) default '0',
  `rendimiento` decimal(9,2) default '0.00',
  `stock_minimo` decimal(9,2) default '0.00',
  `stock_maximo` decimal(9,2) default '0.00',
  PRIMARY KEY  (`id_presentacion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `retiros` */

DROP TABLE IF EXISTS `retiros`;

CREATE TABLE `retiros` (
  `id_retiro` int(11) NOT NULL auto_increment,
  `fecha` datetime default NULL,
  `cantidad` decimal(11,2) default NULL,
  `descripcion` varchar(50) default NULL,
  `id_empleado` int(11) default NULL,
  `id_sucursal` int(11) default NULL,
  `bandera_corte_caja` int(11) default '0',
  `status` varchar(20) default 'ACTIVO',
  PRIMARY KEY  (`id_retiro`)
) ENGINE=MyISAM AUTO_INCREMENT=62 DEFAULT CHARSET=latin1;

/*Table structure for table `servicio` */

DROP TABLE IF EXISTS `servicio`;

CREATE TABLE `servicio` (
  `id_servicio` int(11) NOT NULL auto_increment,
  `fecha` date default NULL,
  `id_cliente` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  `id_servicio_modelo` int(11) default NULL,
  `id_servicio_marca` int(11) default NULL,
  `imei` varchar(50) default NULL,
  `falla` varchar(500) default NULL,
  `observacion` varchar(500) default NULL,
  `estatus` varchar(50) default 'PENDIENTE',
  PRIMARY KEY  (`id_servicio`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Table structure for table `servidores_smtp` */

DROP TABLE IF EXISTS `servidores_smtp`;

CREATE TABLE `servidores_smtp` (
  `id_smtp` int(11) NOT NULL auto_increment,
  `servidor_smtp` varchar(50) default '',
  `correo_smtp` varchar(50) default '',
  `password_smtp` varchar(50) default '',
  `puerto_smtp` varchar(10) default '587',
  `habilitar_ssl` int(1) default '0',
  PRIMARY KEY  (`id_smtp`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Table structure for table `solicitud_compra` */

DROP TABLE IF EXISTS `solicitud_compra`;

CREATE TABLE `solicitud_compra` (
  `id_solicitud_compra` int(11) NOT NULL auto_increment,
  `fecha` datetime default NULL,
  `id_persona_elabora` int(11) default '0',
  `status` varchar(11) default 'PENDIENTE',
  `subtotal` decimal(9,2) default '0.00',
  `impuestos` decimal(9,2) default '0.00',
  `total` decimal(9,2) default '0.00',
  PRIMARY KEY  (`id_solicitud_compra`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `solicitud_compra_detalle` */

DROP TABLE IF EXISTS `solicitud_compra_detalle`;

CREATE TABLE `solicitud_compra_detalle` (
  `id_solicitud_compra_detalle` int(11) NOT NULL auto_increment,
  `id_solicitud_compra` int(11) default '0',
  `id_cmi_requisicion_detalle` int(11) default '0',
  `id_precio_unitario_accion` int(11) default '0',
  `id_partida` int(11) default '0',
  `partida` varchar(50) default '0',
  `unidad` varchar(50) default '0',
  `descripcion` text,
  `precio_unitario` decimal(9,2) default '0.00',
  `impuesto` varchar(50) default '0',
  `importe` decimal(9,2) default '0.00',
  `cantidad` decimal(9,2) default '0.00',
  `total` decimal(9,2) default '0.00',
  `id_impuesto` int(11) default '0',
  `total_impuesto` decimal(9,2) default '0.00',
  `id_unidad` int(11) default '0',
  `id_proveedor` int(11) default '0',
  `id_orden_compra` int(11) default '0',
  PRIMARY KEY  (`id_solicitud_compra_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `sucursal` */

DROP TABLE IF EXISTS `sucursal`;

CREATE TABLE `sucursal` (
  `id_sucursal` int(11) NOT NULL auto_increment,
  `id_domicilio` int(11) NOT NULL,
  `alias` varchar(30) NOT NULL,
  `servidor` varchar(25) default NULL,
  `servidor_usuario` varchar(25) default NULL,
  `servidor_password` varchar(25) default NULL,
  PRIMARY KEY  (`id_sucursal`),
  KEY `FK_sucursal` (`id_domicilio`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `sucursal_tel` */

DROP TABLE IF EXISTS `sucursal_tel`;

CREATE TABLE `sucursal_tel` (
  `id_sucursal` int(11) default NULL,
  `id_telefono` int(11) default NULL,
  KEY `FK_sucursal_tel` (`id_telefono`),
  KEY `FK_sucursal_tel2` (`id_sucursal`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `telefono` */

DROP TABLE IF EXISTS `telefono`;

CREATE TABLE `telefono` (
  `id_telefono` int(11) NOT NULL auto_increment,
  `lada` varchar(10) default NULL,
  `numero` varchar(20) default NULL,
  PRIMARY KEY  (`id_telefono`)
) ENGINE=MyISAM AUTO_INCREMENT=2303 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `temp_venta_detalle` */

DROP TABLE IF EXISTS `temp_venta_detalle`;

CREATE TABLE `temp_venta_detalle` (
  `id_temp_venta_detalle` int(11) NOT NULL auto_increment,
  `id_empleado` int(10) unsigned default NULL,
  `id_producto` int(10) unsigned default NULL,
  `nombre` varchar(100) default NULL,
  `cantidad` decimal(9,3) default NULL,
  `precio` decimal(12,6) default NULL,
  `importe` decimal(9,2) default NULL,
  `total_impuestos` decimal(9,2) unsigned default NULL,
  `nombre_impuestos` varchar(50) default '',
  `tasa_impuestos` varchar(50) default NULL,
  `id_cliente` int(11) default NULL,
  `id_almacen` int(11) default NULL,
  `desc_global_porcent` decimal(9,2) default '0.00',
  `desc_global_importe` decimal(9,2) default '0.00',
  `modificador` int(1) default '0',
  `id_producto_modificador` int(11) default '0',
  `id_venta` int(11) default NULL,
  PRIMARY KEY  (`id_temp_venta_detalle`)
) ENGINE=MyISAM AUTO_INCREMENT=6739 DEFAULT CHARSET=latin1;

/*Table structure for table `tipo_movil` */

DROP TABLE IF EXISTS `tipo_movil`;

CREATE TABLE `tipo_movil` (
  `id_tipomovil` int(2) NOT NULL auto_increment,
  `tipo_movil` varchar(20) default NULL,
  PRIMARY KEY  (`id_tipomovil`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Table structure for table `traspaso_env` */

DROP TABLE IF EXISTS `traspaso_env`;

CREATE TABLE `traspaso_env` (
  `id_traspaso_env` int(11) NOT NULL auto_increment,
  `fecha` datetime default NULL,
  `id_empleado` int(11) default NULL,
  `nombre_empleado` varchar(100) default NULL,
  `id_sucursal_destino` int(11) default NULL,
  `sucursal_destino` varchar(100) default NULL,
  `status` varchar(10) default 'ACTIVO',
  `fecha_cancelacion` datetime default NULL,
  PRIMARY KEY  (`id_traspaso_env`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `traspaso_env_detalle` */

DROP TABLE IF EXISTS `traspaso_env_detalle`;

CREATE TABLE `traspaso_env_detalle` (
  `id_traspaso_env_detalle` int(11) NOT NULL auto_increment,
  `id_traspaso_env` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `unidad` varchar(10) default NULL,
  `descripcion` text,
  PRIMARY KEY  (`id_traspaso_env_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `traspaso_recep` */

DROP TABLE IF EXISTS `traspaso_recep`;

CREATE TABLE `traspaso_recep` (
  `id_traspaso_recep` int(11) NOT NULL auto_increment,
  `fecha_registro` datetime default NULL,
  `fecha` datetime default NULL,
  `folio_origen` varchar(50) default NULL,
  `id_empleado_captura` int(11) default NULL,
  `id_empleado_recep` int(11) default NULL,
  `empleado_recep` varchar(100) default NULL,
  `id_sucursal_origen` int(11) default NULL,
  `sucursal_origen` varchar(100) default NULL,
  `status` varchar(10) default 'ACTIVO',
  `fecha_cancelacion` datetime default NULL,
  PRIMARY KEY  (`id_traspaso_recep`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `traspaso_recep_detalle` */

DROP TABLE IF EXISTS `traspaso_recep_detalle`;

CREATE TABLE `traspaso_recep_detalle` (
  `id_traspaso_recep_detalle` int(11) NOT NULL auto_increment,
  `id_traspaso_recep` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `unidad` varchar(10) default NULL,
  `descripcion` text,
  PRIMARY KEY  (`id_traspaso_recep_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `unidad` */

DROP TABLE IF EXISTS `unidad`;

CREATE TABLE `unidad` (
  `id_unidad` int(3) NOT NULL auto_increment,
  `clave` varchar(5) NOT NULL,
  `nombre` varchar(20) default '',
  `nombre_corto` varchar(5) default '',
  PRIMARY KEY  (`id_unidad`,`clave`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL auto_increment,
  `usuario` varchar(20) NOT NULL,
  `password` varchar(32) NOT NULL,
  `activo` tinyint(1) default '1',
  `id_cuenta` int(11) NOT NULL,
  `id_empleado` int(11) NOT NULL,
  PRIMARY KEY  (`id_usuario`),
  UNIQUE KEY `usuario` (`usuario`)
) ENGINE=MyISAM AUTO_INCREMENT=31 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `usuario_cuenta` */

DROP TABLE IF EXISTS `usuario_cuenta`;

CREATE TABLE `usuario_cuenta` (
  `id_cuenta` int(2) NOT NULL auto_increment,
  `nombre` varchar(30) NOT NULL,
  PRIMARY KEY  (`id_cuenta`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `venta` */

DROP TABLE IF EXISTS `venta`;

CREATE TABLE `venta` (
  `id_venta` int(11) NOT NULL auto_increment,
  `fecha` datetime default NULL,
  `id_sucursal` int(11) default '1',
  `id_empleado` int(11) default '0',
  `id_empleado_caja` int(11) default '0',
  `id_empleado_validacion` int(11) default '0',
  `id_cliente` int(11) default '1',
  `cliente_publico_alias` varchar(200) default '',
  `id_forma_pago` int(1) default '0',
  `subtotal` decimal(11,2) default '0.00',
  `total_impuestos` decimal(11,2) default '0.00',
  `total_descuento` decimal(11,2) default '0.00',
  `total` decimal(10,2) default '0.00',
  `codigo` varchar(25) default NULL,
  `id_factura` int(11) default '0',
  `id_corte` int(11) default '0',
  `desc_global_porcent` decimal(9,2) default '0.00',
  `desc_global_importe` decimal(9,2) default '0.00',
  `fecha_salida_almacen` datetime default NULL,
  `credito` int(1) default '0',
  `status` varchar(15) default 'ABIERTA',
  PRIMARY KEY  (`id_venta`)
) ENGINE=InnoDB AUTO_INCREMENT=2361 DEFAULT CHARSET=latin1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `venta_detalle` */

DROP TABLE IF EXISTS `venta_detalle`;

CREATE TABLE `venta_detalle` (
  `id_venta_detalle` int(11) NOT NULL auto_increment,
  `id_venta` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(11,3) default NULL,
  `total_impuestos` decimal(11,4) default NULL,
  `nombre_impuestos` varchar(50) default '',
  `tasa_impuestos` decimal(9,2) default NULL,
  `precio` decimal(13,6) default NULL,
  `descripcion` varchar(100) default NULL,
  `unidad` varchar(50) default NULL,
  `id_almacen` int(11) default NULL,
  `importe` decimal(11,4) default '0.0000',
  `modificador` int(1) default '0',
  `id_producto_modificador` int(11) default '0',
  PRIMARY KEY  (`id_venta_detalle`),
  KEY `FK_venta_detalle` (`id_venta`),
  KEY `FK_venta_detalle_producto` (`id_producto`)
) ENGINE=InnoDB AUTO_INCREMENT=4700 DEFAULT CHARSET=latin1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `venta_insumo` */

DROP TABLE IF EXISTS `venta_insumo`;

CREATE TABLE `venta_insumo` (
  `id_venta` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(9,2) default NULL,
  `id_insumo` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `facturas` */

DROP TABLE IF EXISTS `facturas`;

/*!50001 DROP VIEW IF EXISTS `facturas` */;
/*!50001 DROP TABLE IF EXISTS `facturas` */;

/*!50001 CREATE TABLE  `facturas`(
 `fecha` datetime ,
 `serie` varchar(50) ,
 `id_factura_electronica` int(10) ,
 `RFC` varchar(15) ,
 `subtotal` decimal(10,2) ,
 `iva` decimal(10,2) ,
 `total` decimal(10,2) ,
 `estatus` varchar(20) ,
 `estatus_timbrado` varchar(20) ,
 `forma_pago` varchar(151) ,
 `nombre` varchar(122) 
)*/;

/*View structure for view facturas */

/*!50001 DROP TABLE IF EXISTS `facturas` */;
/*!50001 DROP VIEW IF EXISTS `facturas` */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
