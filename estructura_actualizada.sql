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
CREATE DATABASE /*!32312 IF NOT EXISTS*/`estructura_restaurante` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `spvpyme`;

/*Table structure for table `agente_entrega` */

DROP TABLE IF EXISTS `agente_entrega`;

CREATE TABLE `agente_entrega` (
  `id_agente_entrega` int(11) NOT NULL auto_increment,
  `id_empleado` int(11) default NULL,
  `id_vehiculo` int(11) default NULL,
  `status` varchar(50) default 'ACTIVO',
  PRIMARY KEY  (`id_agente_entrega`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `agente_entrega` */

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

/*Data for the table `ajuste_inventario` */

/*Table structure for table `almacenes` */

DROP TABLE IF EXISTS `almacenes`;

CREATE TABLE `almacenes` (
  `id_almacen` int(50) NOT NULL auto_increment,
  `id_almacen_tipo` int(11) default '0',
  `clave` varchar(100) default '',
  `nombre` varchar(50) NOT NULL default '',
  `id_empleado_responsable` int(11) NOT NULL default '0',
  `id_sucursal` int(11) default NULL,
  `domicilio` varchar(100) default '',
  `default_ventas` int(1) default '0',
  PRIMARY KEY  (`id_almacen`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `almacenes` */

insert  into `almacenes`(`id_almacen`,`id_almacen_tipo`,`clave`,`nombre`,`id_empleado_responsable`,`id_sucursal`,`domicilio`,`default_ventas`) values (1,1,'01','PRINCIPAL',1,1,'CONOCIDO',1),(2,2,'02','COCINA',1,1,'CONOCIDO',0),(3,2,'03','BARRA',1,1,'CONOCIDO',0),(4,3,'04','BODEGA PRINCIPAL',1,1,'CONOCIDO',0);

/*Table structure for table `almacenes_tipo` */

DROP TABLE IF EXISTS `almacenes_tipo`;

CREATE TABLE `almacenes_tipo` (
  `id_almacen_tipo` int(11) NOT NULL auto_increment,
  `nombre` varchar(500) default '',
  PRIMARY KEY  (`id_almacen_tipo`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `almacenes_tipo` */

insert  into `almacenes_tipo`(`id_almacen_tipo`,`nombre`) values (1,'PRODUCTOS'),(2,'INSUMOS'),(3,'PRESENTACIONES');

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

/*Data for the table `apartado` */

/*Table structure for table `area_comedor` */

DROP TABLE IF EXISTS `area_comedor`;

CREATE TABLE `area_comedor` (
  `id_area_comedor` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default 'GENERAL',
  PRIMARY KEY  (`id_area_comedor`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `area_comedor` */

insert  into `area_comedor`(`id_area_comedor`,`nombre`) values (1,'GENERAL');

/*Table structure for table `areas_comedor` */

DROP TABLE IF EXISTS `areas_comedor`;

CREATE TABLE `areas_comedor` (
  `id_area_comedor` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default '',
  PRIMARY KEY  (`id_area_comedor`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `areas_comedor` */

insert  into `areas_comedor`(`id_area_comedor`,`nombre`) values (1,'GENERAL');

/*Table structure for table `areas_impresion` */

DROP TABLE IF EXISTS `areas_impresion`;

CREATE TABLE `areas_impresion` (
  `id_area_impresion` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default '',
  `nombre` varchar(100) default '',
  `id_almacen_descarga` int(11) default NULL,
  PRIMARY KEY  (`id_area_impresion`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `areas_impresion` */

insert  into `areas_impresion`(`id_area_impresion`,`clave`,`nombre`,`id_almacen_descarga`) values (1,'1','COCINA',2),(2,'2','BARRA',3);

/*Table structure for table `banco` */

DROP TABLE IF EXISTS `banco`;

CREATE TABLE `banco` (
  `id_banco` int(11) NOT NULL auto_increment,
  `descripcion` varchar(50) NOT NULL,
  `logotipo` longblob,
  PRIMARY KEY  (`id_banco`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Data for the table `banco` */

insert  into `banco`(`id_banco`,`descripcion`,`logotipo`) values (1,'Banamex',NULL),(2,'Banca Serfin',NULL),(3,'Bancomer',NULL),(4,'Banco Inbursa',NULL),(5,'Banco Satander Mexicano',NULL),(6,'Banorte',NULL),(7,'HSBC',NULL),(8,'Scotiabank Inverlat',NULL);

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `banco_cuentas` */

/*Table structure for table `caja_saldo_inicial` */

DROP TABLE IF EXISTS `caja_saldo_inicial`;

CREATE TABLE `caja_saldo_inicial` (
  `id_saldo_inicial` int(11) NOT NULL auto_increment,
  `saldo_inicial` decimal(11,2) default NULL,
  `id_empleado` int(11) default NULL,
  `fecha` datetime default NULL,
  `bandera_corte_caja` int(11) default '0',
  PRIMARY KEY  (`id_saldo_inicial`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `caja_saldo_inicial` */

insert  into `caja_saldo_inicial`(`id_saldo_inicial`,`saldo_inicial`,`id_empleado`,`fecha`,`bandera_corte_caja`) values (1,'0.00',1,'2016-05-29 09:58:07',1),(2,'0.00',1,'2016-06-20 13:44:58',2),(3,'0.00',1,'2016-08-02 19:28:10',0);

/*Table structure for table `catalogo_precios` */

DROP TABLE IF EXISTS `catalogo_precios`;

CREATE TABLE `catalogo_precios` (
  `id_catalogo_precio` int(11) NOT NULL auto_increment,
  `nombre` varchar(25) default NULL,
  `cantidad_inicio` int(10) default NULL,
  `cantidad_termino` int(10) default NULL,
  `utilidad` decimal(10,2) default NULL,
  PRIMARY KEY  (`id_catalogo_precio`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `catalogo_precios` */

insert  into `catalogo_precios`(`id_catalogo_precio`,`nombre`,`cantidad_inicio`,`cantidad_termino`,`utilidad`) values (1,'ESPECIAL',1,10000000,'0.11');

/*Table structure for table `categoria` */

DROP TABLE IF EXISTS `categoria`;

CREATE TABLE `categoria` (
  `id_categoria` int(11) NOT NULL auto_increment,
  `nombre` varchar(100) NOT NULL,
  `super` int(11) NOT NULL,
  `imagen` blob,
  `fecha_alta` datetime default NULL,
  `fecha_modificacion` timestamp NULL default CURRENT_TIMESTAMP,
  `nivel` int(2) default NULL,
  PRIMARY KEY  (`id_categoria`),
  UNIQUE KEY `NewIndex1` (`nombre`,`super`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `categoria` */

insert  into `categoria`(`id_categoria`,`nombre`,`super`,`imagen`,`fecha_alta`,`fecha_modificacion`,`nivel`) values (1,'NO CLASF.',0,NULL,'2016-03-28 09:51:38','2016-03-28 09:51:38',1),(2,'AGUAS',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(3,'ORDENES',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(4,'REFRESCOS',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(5,'CALIENTES',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(6,'PLANCHA',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(7,'CARNICOS',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(8,'ENLATADOS',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(9,'LICUADO',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(10,'CERVEZAS',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(11,'JUGOS',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(12,'PANQUE',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(13,'PAY',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(14,'POZOLE',0,NULL,'2016-03-28 11:46:50','2016-03-28 11:46:50',NULL),(15,'LACTEOS',0,NULL,'2016-03-28 11:46:51','2016-03-28 11:46:51',NULL),(16,'TACOS',0,NULL,'2016-03-28 12:49:15','2016-03-28 12:49:15',1),(17,'TORTAS',0,NULL,'2016-03-28 13:10:29','2016-03-28 13:10:29',1),(18,'TOSTADAS',0,NULL,'2016-03-28 13:10:42','2016-03-28 13:10:42',1),(19,'MODIFICADORES',0,NULL,'2016-04-05 09:27:25','2016-04-05 09:27:25',1);

/*Table structure for table `categoria_cat_imp` */

DROP TABLE IF EXISTS `categoria_cat_imp`;

CREATE TABLE `categoria_cat_imp` (
  `id_categoria` int(11) default NULL,
  `id_catalogo` int(11) default NULL,
  KEY `FK_prod_cat_imp` (`id_categoria`),
  KEY `FK_prod_cat_imp_cat` (`id_catalogo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `categoria_cat_imp` */

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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_bascula` */

insert  into `cfg_bascula`(`id_cfg_bascula`,`portname`,`baudrate`,`databits`,`discarnull`,`parity`,`readbuffersize`,`readtimeout`,`receivedbytesthreshold`,`rtsenable`,`stopbits`,`writebuffersize`,`writetimeout`) values (1,'COM1','9600','8','False','None','4096','-1','1','False','One','2048','-1');

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

/*Data for the table `cfg_colores` */

insert  into `cfg_colores`(`id_cfg_color`,`cfg_1`,`cfg_2`,`cfg_3`,`cfg_4`,`cfg_5`,`cfg_6`,`cfg_7`,`cfg_8`,`cfg_9`,`cfg_10`,`cfg_11`,`cfg_12`,`cfg_13`,`cfg_14`,`cfg_15`,`cfg_16`,`cfg_17`,`cfg_18`,`cfg_19`,`cfg_20`,`cfg_21`,`cfg_22`,`cfg_23`,`cfg_24`,`cfg_25`,`cfg_26`,`cfg_27`,`cfg_28`) values (1,'-2295862','0','0','0','0','0','-1','-1','0','0','0','0','-16777216','-16711808','0','0','0','0','0','0','0','0','-128','0','0','0','0','-2622209');

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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_correo` */

insert  into `cfg_correo`(`id_cfg_correo`,`nombre_dest`,`correo_dest`,`asunto`,`mensaje`,`id_smtp`,`id_adjuntar`,`proteger_pdf`,`password_pdf`,`enviar_despues_generar`) values (1,'Usuario','','','',1,1,0,'',0);

/*Table structure for table `cfg_descuento` */

DROP TABLE IF EXISTS `cfg_descuento`;

CREATE TABLE `cfg_descuento` (
  `id_cfg_descuento` int(11) NOT NULL auto_increment,
  `porcentaje` decimal(11,2) default '0.00',
  `fecha_inicio` datetime default NULL,
  `fecha_termino` datetime default NULL,
  PRIMARY KEY  (`id_cfg_descuento`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_descuento` */

insert  into `cfg_descuento`(`id_cfg_descuento`,`porcentaje`,`fecha_inicio`,`fecha_termino`) values (1,'0.00','2016-03-28 09:51:38','2016-03-28 09:51:38');

/*Table structure for table `cfg_descuento_cat` */

DROP TABLE IF EXISTS `cfg_descuento_cat`;

CREATE TABLE `cfg_descuento_cat` (
  `id_cfg_descuento_cat` int(11) NOT NULL auto_increment,
  `id_cfg_descuento` int(11) default '0',
  `id_categoria` int(11) default NULL,
  PRIMARY KEY  (`id_cfg_descuento_cat`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `cfg_descuento_cat` */

/*Table structure for table `cfg_documentos` */

DROP TABLE IF EXISTS `cfg_documentos`;

CREATE TABLE `cfg_documentos` (
  `id_cfg_documentos` int(11) NOT NULL auto_increment,
  `dir_facturas` text,
  `dir_cotizaciones` text,
  PRIMARY KEY  (`id_cfg_documentos`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_documentos` */

insert  into `cfg_documentos`(`id_cfg_documentos`,`dir_facturas`,`dir_cotizaciones`) values (1,'C:\\Documents and Settings\\Lacteos Arce\\Escritorio','C:\\Users\\Lacteos Arce\\Dropbox\\LACTEOS ARCE\\COTIZACIONES ARCE');

/*Table structure for table `cfg_facturacion` */

DROP TABLE IF EXISTS `cfg_facturacion`;

CREATE TABLE `cfg_facturacion` (
  `id_cfg_facturacion` int(11) NOT NULL auto_increment,
  `id_regimen_fiscal` int(11) default '0',
  `regimen_fiscal` text,
  `concepto_predeterminado` int(1) default '0',
  `concepto` text,
  `unidad_predeterminada` int(1) default '0',
  `id_unidad` int(11) default '0',
  `id_cfg_impuesto_default` int(11) default '0',
  PRIMARY KEY  (`id_cfg_facturacion`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_facturacion` */

insert  into `cfg_facturacion`(`id_cfg_facturacion`,`id_regimen_fiscal`,`regimen_fiscal`,`concepto_predeterminado`,`concepto`,`unidad_predeterminada`,`id_unidad`,`id_cfg_impuesto_default`) values (1,1,'REGIMEN DE PRUEBA',0,'',0,0,1);

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

/*Data for the table `cfg_facturacion_connector` */

insert  into `cfg_facturacion_connector`(`id_cfg_facturacion_connector`,`usuario`,`contraseña`,`certificado`,`clave`,`contraseña_clave`) values (1,'facturacion.demo2015@gmail.com','UKLRQe26*','aad990814bp7_1210261233s.cer','aad990814bp7_1210261233s.key','12345678a');

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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_facturacion_serie` */

insert  into `cfg_facturacion_serie`(`id_cfg_facturacion_serie`,`serie`,`deshabilitar`,`consecutivo_inicial`,`consecutivo_final`,`num_aprobacion`,`ano_aprobacion`,`ultimo_folio_factura`) values (1,'A',0,1,1000,'','','');

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

/*Data for the table `cfg_formato_impresion` */

insert  into `cfg_formato_impresion`(`id_cfg_formato_impresion`,`id_formato_nota_venta`,`id_formato_orden_entrega`,`id_formato_cotizacion`,`id_formato_cxcobrar`) values (1,1,1,3,1);

/*Table structure for table `cfg_impresoras` */

DROP TABLE IF EXISTS `cfg_impresoras`;

CREATE TABLE `cfg_impresoras` (
  `id_cfg_impresora` int(11) NOT NULL auto_increment,
  `index_imp_caja` varchar(100) default '',
  `index_imp_pedidos` varchar(100) default '',
  `index_imp_almacen` varchar(100) default '',
  PRIMARY KEY  (`id_cfg_impresora`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_impresoras` */

insert  into `cfg_impresoras`(`id_cfg_impresora`,`index_imp_caja`,`index_imp_pedidos`,`index_imp_almacen`) values (1,'EPSON TM-T88V Receipt','EPSON TM-T88V Receipt','EPSON TM-T88V Receipt');

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
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_impuesto` */

insert  into `cfg_impuesto`(`id_cfg_impuesto`,`id_cfg_impuesto_catalogo`,`nombre`,`tasa`,`fecha_alta`,`fecha_baja`) values (1,1,'IVA 0%','0.00','2015-01-06 06:18:19',NULL);

/*Table structure for table `cfg_impuesto_catalogo` */

DROP TABLE IF EXISTS `cfg_impuesto_catalogo`;

CREATE TABLE `cfg_impuesto_catalogo` (
  `id_cfg_impuesto_catalogo` int(11) NOT NULL auto_increment,
  `alias` varchar(50) default NULL,
  `nombre` varchar(50) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_baja` datetime default NULL,
  PRIMARY KEY  (`id_cfg_impuesto_catalogo`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_impuesto_catalogo` */

insert  into `cfg_impuesto_catalogo`(`id_cfg_impuesto_catalogo`,`alias`,`nombre`,`fecha_alta`,`fecha_baja`) values (1,'IVA','IMPUESTO VALOR AGREGADO','2015-01-06 06:17:55',NULL);

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
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `cfg_leyenda_nota` */

/*Table structure for table `cfg_licencia` */

DROP TABLE IF EXISTS `cfg_licencia`;

CREATE TABLE `cfg_licencia` (
  `id_licencia` int(11) NOT NULL auto_increment,
  `licencia` text,
  PRIMARY KEY  (`id_licencia`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_licencia` */

insert  into `cfg_licencia`(`id_licencia`,`licencia`) values (1,'57e73e6170a65c8efe21a7f760aa38f7'),(2,'06da8ce6b8c29014a1899eab4bfb7643'),(3,'4f8bc81451642972b0b8ae2837e61fa1'),(4,'1118725bb30b76fbd8c6f351ed6e7093'),(5,'b97fc0c4a1773fcf8f43ea359b0c85ac');

/*Table structure for table `cfg_lineas_ticket` */

DROP TABLE IF EXISTS `cfg_lineas_ticket`;

CREATE TABLE `cfg_lineas_ticket` (
  `id_lineas` int(11) NOT NULL auto_increment,
  `id_tipo` int(1) default '1',
  `descripcion` varchar(50) default NULL,
  PRIMARY KEY  (`id_lineas`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_lineas_ticket` */

insert  into `cfg_lineas_ticket`(`id_lineas`,`id_tipo`,`descripcion`) values (5,0,'GRACIAS POR SU COMPRA'),(10,1,'PORFIRIO DIAZ  617 CENTRO'),(9,1,'POZOLERIAS Y TAQUERIAS ALVARO'),(11,1,'OAXACA DE JUAREZ');

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
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `cfg_nota_credito_serie` */

/*Table structure for table `cfg_producto_compuesto` */

DROP TABLE IF EXISTS `cfg_producto_compuesto`;

CREATE TABLE `cfg_producto_compuesto` (
  `id_producto` int(11) default NULL,
  `id_insumo` int(11) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `id_tipo_descuento` int(1) default '0',
  `cantidad_unidad` decimal(9,3) default '1.000'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `cfg_producto_compuesto` */

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
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `cfg_punto_venta` */

insert  into `cfg_punto_venta`(`id_cfg_punto_venta`,`cfg_pago_express`,`cfg_activar_bascula`,`cfg_varias_lineas`,`cfg_cantidades_negativas`,`cfg_mostrar_codigo`,`cfg_copia_ticket`,`cfg_ticket_pago`,`cfg_cantidad_codigo`,`cfg_imprimir_orden_entrega`,`cfg_mostrar_codigo_venta_detalle`,`cfg_ver_pedidos_apartados`,`cfg_ajustar_precios`,`cfg_mostrar_barra_tareas`,`cfg_mostrar_boton_bascula`,`cfg_ingresar_observacion_producto`,`cfg_imprimir_formatos_carta`,`cfg_imprimir_productos_corte`,`cfg_imprimir_comprobante_pago`,`cfg_imprimir_logotipo_ticket`,`cfg_imprimir_texto_sin_formato`,`cfg_impresora_matriz`,`fuente_titulo`,`fuente_producto`,`size_titulo`,`size_producto`,`long_descripcion`,`long_maxima`,`long_linea_productos`,`productos_mayusculas`,`escala_logo_ticket`,`escala_altura_logo`,`longitud_titulo`,`espacios_antes_total`,`margen_izq_total`) values (1,0,0,1,1,0,0,0,0,0,0,2,0,1,1,0,0,0,0,1,0,0,'Lucida Console','Arial Narrow',10,8,40,40,80,1,58,15,25,9,9),(2,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,'Lucida Console','Arial Narrow',10,7,30,39,70,0,58,15,25,7,9);

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
  PRIMARY KEY  (`id_cliente`),
  KEY `FK_cliente_empresa` (`id_empresa`),
  KEY `FK_cliente_domicilio` (`id_domicilio`),
  KEY `FK_cliente_persona` (`id_persona`),
  KEY `FK_cliente_telefono` (`id_telefono`),
  KEY `FK_cliente_tipo` (`id_tipo`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `cliente` */

insert  into `cliente`(`id_cliente`,`clave`,`id_persona`,`id_empresa`,`id_domicilio`,`id_telefono`,`id_tipo`,`fecha_alta`,`fecha_modificacion`) values (1,'',0,1,1,0,1,'2016-03-28 09:51:38','2016-03-28 09:51:38'),(2,'',0,2,6,0,1,'2016-06-20 13:46:01','2016-06-20 13:46:01');

/*Table structure for table `cliente_credito` */

DROP TABLE IF EXISTS `cliente_credito`;

CREATE TABLE `cliente_credito` (
  `id_cliente` int(11) default NULL,
  `credito` int(1) default '0',
  `limite` int(1) default '0',
  `limite_credito` double(9,2) default '0.00',
  KEY `FK_id_cliente` (`id_cliente`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `cliente_credito` */

insert  into `cliente_credito`(`id_cliente`,`credito`,`limite`,`limite_credito`) values (1,0,0,0.00),(2,1,0,0.00);

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `cliente_cuenta` */

/*Table structure for table `cliente_precio` */

DROP TABLE IF EXISTS `cliente_precio`;

CREATE TABLE `cliente_precio` (
  `id_cliente_precio` int(11) NOT NULL auto_increment,
  `id_cliente` int(11) default '0',
  `id_catalogo_precio` int(11) default '0',
  `autorizacion` int(1) default '0',
  `aplicar_redondeo` int(1) default '1',
  `mostrar_precios` int(1) default '1',
  PRIMARY KEY  (`id_cliente_precio`),
  KEY `FK_cliente_precio` (`id_cliente`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `cliente_precio` */

insert  into `cliente_precio`(`id_cliente_precio`,`id_cliente`,`id_catalogo_precio`,`autorizacion`,`aplicar_redondeo`,`mostrar_precios`) values (1,1,0,0,1,1),(2,2,0,0,1,1);

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

/*Data for the table `cliente_productos` */

/*Table structure for table `cliente_tipo` */

DROP TABLE IF EXISTS `cliente_tipo`;

CREATE TABLE `cliente_tipo` (
  `id_tipo` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default NULL,
  `descuento` decimal(4,2) default NULL,
  PRIMARY KEY  (`id_tipo`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `cliente_tipo` */

insert  into `cliente_tipo`(`id_tipo`,`nombre`,`descuento`) values (1,'Ocasional','0.00'),(2,'Frecuente','0.00');

/*Table structure for table `clientes` */

DROP TABLE IF EXISTS `clientes`;

CREATE TABLE `clientes` (
  `id_cliente` int(11) default NULL,
  `rfc` varchar(15) default NULL,
  `razon_social` varchar(122) default NULL,
  `tipo` int(1) default NULL,
  `descuento` decimal(4,2) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `clientes` */

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
  UNIQUE KEY `id_configuracion` (`id_configuracion`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `configuracion` */

insert  into `configuracion`(`id_configuracion`,`imagen`,`thumb`,`logotipo`,`logotipo_thumb`,`logo`,`codigo_barras`,`alias`,`razon_social`,`domicilio`,`url`,`rfc`,`calle`,`num_int`,`num_ext`,`colonia`,`municipio`,`localidad`,`cp`,`estado`,`pais`,`telefono`,`correo`,`tiempo_vida_venta`,`tiempo_vida_carro`,`venta_caduca`,`tiempo_inactivo`,`intentos_fallidos`,`cfg_titulo`,`cfg_cat_nivel`,`cfg_stock_minimo`,`cfg_descripcion`,`cfg_keywords`,`cfg_color`,`cfg_imagen_producto`,`id_sucursal`,`id_pantalla`,`habilitar_cfdi`) values (1,'�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0x\0\0\0x\0\0\09d6�\0\0\0gAMA\0\0��7��\0\0\0tEXtSoftware\0Adobe ImageReadyq�e<\0\0KSIDATx^�}x�׺�$$\'\r�^\n�R�S�m)�b��wwwwww�$��F�$�$XB�y���|�0pz��9�>?�<���0���׻�+{_�O�>������V��\n|Z�O+�\\1l��4d9��Pȭ���s�\r5/t0Ի����Ŏ�&����;��h�u����-Ŗ44���`��Ƨ_��\\�z�C��]\r��w14����\r+�����`\0�`�yv1$yu5��sn�\r�`gN�3lpiku����Ζ�ʓj\Z�>����?�Y�&l�:�]��gog�ї������g�D�����N4��\\��\\�ZUBfՒ��?����������re�4���w��xt1$��h��T{��m��l�����%J�68`x6��?��_]Wg��y�-��3,��j�����o��<���.�\'�u�g\'�I����*p��_�%	7�IR�AI\n�/	׶I����D��N�g���\r�$tNu	UD|�d�K]m��:��ti�aˎV�]~k(�����c��{c���3�w^��Wxv����l�\Z8$��.�/��K��FI�{Z�^���\\����5�?X�e�H��H��H��ȋ�\"OO�<>.iw�Hb�J�97^\"v����U$p�g��=�ѽK�{.��.n��y��91Tۿ1�Oo�gV��ly�z�\r�����9Cr��\\r{U3���Dﻉ��\r���\"�aqw\0�-�W!f�_^�A�\0��`�D�_y�.�\0G��N����x{�$.�����΢o��x:gH=�%㕝��gt���<ƞ�l�3�7���n��w�L�{f���eo\n]PW�.-��1��p���\0���{��u����H�|	\0��g�)��yx�O��n1��*���$�Xo���}��}��ΙN���1������ {�u���7�)�^^�kz�o�$=��tl�%�4���GV@ߵb2d�2d:�,�h�b�~t���]\"�����\"��KR�ly���\ru�^�I��2��hh��}�	�d��o�����e���m�rmZy�F�bB̀��\'��\"I��_#�:�����x��\Z�8\nRM?�b1e\Z�X���w��6���:I��\\�\\�ʵI%Ļwƴ3�3�,h�qX�|��������ً��\Z���>-t��:�0�қ\0����Hr$,����x�~\rٶ���l-�`����Y��\r�\0x�b��� �[���bY%��H��ķ���L�,�f5�4s���ا�z~��y�\rȔ~{��Ȍ#�<,.Kp�ERbDRc5{��^�g\0�2��ߍ��%]����`1b�dӔ�Z�N�F~�8��\0C��n�7�[#��U���(��+�_�,��ݳ�\ZW/s?�/�\'��oP�,���Q�oH�ӁC�˝�H�y\r��Cj�DQ���P�6��Ƌ���%�S\0�d��ɗb13k��_��90���o�0f�+�CVHj�J���(a�\n�z�9��Au���ap��_�lsyP����r��#���2���ty֥9LU�Xc2,���2��#0��1T,�L��2�n�V\0?�fެb���\07��re1FIȼ��H������������S	���re���?`XΨ�+�+�UbR�\n�N�%	0㮒f�IpӍ\"&Xz*\0O��qf��f����/F�C�K��L\Z��]3�bx��i\0\'�X*I��s�>rcz�80g�fY�U-f_�c{��?���?F8~�?����b���(1�@C�\0f���MO�,&���\0|}����y�x�reB!9�+��u2q�l(�I�5���7�����/�͗vsI���C�U�`&H�Fv�+%S�Dd%�d/d��V�d�I��J��$�/$:\0\'^[���\"�����0:�iMۜ����g��qoR��l�?���Q��̫,�|��[�l-�1��d�η�,\0g�i�5�@X��/����R*!ɲ�.Yk-U#�bO�:[����:�:�F������Յe�<s�%7f���N1�f�Z$��@��7(����8:��k�\nK��.bG됋O�ٔ���,�T&��L\Z���\\��\r�/ٛf�C/�X��2�NU\0/�x��������M��Չem;G�Z%2��Ʉ����ݡ��yk��{;t�7�&,:Q\0@��2����0K�����0�^�T�K�R��\\�&{�	��]%���,8�[��������a�d�F�Zd�H�P��\\!�\0��7��BI\0���J|�<y��Wn�-\'g���P=ˤ��m,>5,_V���F]�R(��֒��Bnp�#�d�4Y��b�ZG�+J�n���}���^�Y�mrP�Y�U\"i�=�_f����Ps���HϠ!�do\0��<���rg}=	�\\(}Z3G�b���L%��\'��8����9_H�ũ\0��g\\$��Tk�X�2�R k�-��@�n�V��()puif�%{)Ϟ�.l�6%��n���*���Db�u�,�86h��\n�%�:\"��}}�<�Tء+�����#7W��yyr��wW� �!�uϰ�\\p.<��rc���T�I�@F<U\r�.��q�����L�(�/��p�.�����@�j�΍����]����	֛��ԜA+��)��Β�3�!���x�+�ҢJ�E3\Z���\Z=���O,��ڌb�{ۊ�[u�9S.�f�X�L��L&#�\0�`��#�����g�\n��v�4pU��c������b����V��<3�*y6\'XI�DB�%���qAsp<h�����3a��\\�V�4��S����\0`�x�y-(�9`Jэ7�}.�n#*ڄl�3�!��]�T3�zd�d2���M��n|M���-�1����p\Zu�C�f�^�^}����.�_�GV��\Z,-��k�8S�}��s�	roOK�1��,�74w��@6�ǃ.f�1�l��ӊ�-�Z�X,2Y�@�y�B�c2�I�\Z )6��\r�Xl\ZY����#X�!s��iGuؚ|gb�� ���\rj�В=�U-�ȳpL���$O/��G�HȂ/�ذ�Q���c��?*�æ�)tuf���k����z,2D� 3�̘�	�b�4T`[��g��X�֥ԫ��aq{��8P\Zݷ��o57(��A���?k,]���<\rQe�D`�KO	]��\\�P<�|A�\0��G���ծ�.�h[cI��Z��硘��d��2b2�Q��\rFl��ĉ���52��x,��*�n�}�\\(��r,ֽ���,�ީ}�ޛln0{&{���w�3�����>L����(�V�b֍\0�\"��9��=�X���K�=��RL<\Z��d�E&?�Q4�k�Q��`�l�Z���,�%���V;AIY&s���p<�[��3X*��Np��Z��&�2g��z�����=Q������{\08l�wr}^iS�\Z�n͏*��Z��ͅ���y�٧�Hl�=�@Ƣ�Y��Y͸�������&�d�ft\0�3��,�s(�ʖ�up�\Z\Z��1��i~�9�ٻ��Jg�K�������0yx���9�^_q�si���I�ˆG�F�=��h����8�	�rq���5�@Ƣ�Y���!�<���/�D��DUNleZ���[)�L��T�w~�s�j����\\���iK\\%�z��*���$j_46bP\ZE2�{��\'�ȭ����G	]�����+�����\0|q���-�&+������G���#HJ^u����Vr��j�elW��=k�f��C;F�%�I�.�7;G���Ζ����c�D������=$�p�	s�m����m\0���\0|vB����I�8�\Z�a�E�٠�)��)\n.>��RB-@k�VKV�����4�G�NB�W�R��T�{P�������7��$��\\����WO����\Z�5��g�t��W��&7�w��kj����Z��I���Q|r\\��AsK%>������Oi�\"�����)�d��3)�d5$2�S�ӬAE\\Wr��Q���2$܅Cѱ4Y6�[�NM�+�5��}Ӗ�3g�F3�ؘ�����S��.�{��\\���\\]YM�f�2֯���G��(^�wV��;[~�T$/渷Vm���ža3�V2�XI�YH��;�^��������*�j�^;̮���ZcnfX�e��ۑ̘Y!k�0�e�^&V�������� �w���:��m/Ww6��e_˹�œ�δ	\0�����=C\n;yM+r�b\"�u�L�D�b�_M��q�k�+05@�e\'\ZS�p�zd\"֪�?=��Yg���>�psn��,sϗq��\n�9GB��]-�݆�W\\�v����(���)�[\ZK���rpd�<92,�����D��M,z4xqEy�9V%6i�j� s��h��hJ7⥊єWf�d��p������C@c	*㬹�5�Y�d_�:Ufp�N������5�%����XKbu�DO	cb���\\��R��0��,u���v\0���ˀ�GG��?����P� �$��L\0���e���YM�?i����̀���6c��Z�[�\r��\\Ն�fˤJu�T�i>�I�Ko�}���h/�v������5�ov	��+Yl\0ق��)��������iEo�h�,�Ԝ:�Lx,��1Ng���\0���ހ�6S�5��5׸��2�)0W��x�dYkE*pf�K_64wG��$�]���cΚ4����$`ӯ��+9?�p�ϕ�����Ĕ?*�1Y�U�r�95>����$�7��\\x^���[�o��2)�e��?3׳\ZSUv�e�Z��c�q��U��Nh���.�H�\"�ƣ$\Z)�*��E͋�{�����F��l!�[���5����/�T~��Z���Y�\'�g���Y�5�4z=%�r�)�j�Q�(�u�0\n$���]3�GTώ[5��B�sh?��L��&�J��cV�.bn4�������!`.ۑ=Tܽ��{q7hkS���P<�T�3�ʨ��re���yG��\'�ҥ��kz�lvfB���RY*�e�����2��`h3ة!���Y���W�S���F�UmKGR}esoY?�af-�)s)d�ܩ23w�ʘ��v�3J�v\n��ۚ�?��z��甕c��֫�����c�g}�6���,�wp��s�@�W�c��(���`3NZ�_\0����c�����A�L1�a�d����H��\Z��u���%s�꫚*c�*����9�k �W�)EdF[��b�3,�D��}<��zr���e]�#g��򿺶�Ԙ3US��\"\0�a��k\0Y\0\'p��H�,��|Pʰ&�\nT�X�-?�Z��\rk\\f�lbp��NgD��-@sBu�Dws��n)�Ș65���Ҋ��mV94\"Oj�*��gv��5�<�����T�Nj����~�u�Y&�b1�n������n3`��:ӭ���\\�V��A��%��$ٲ�F$���Fc��ѥB��6\Za��P1�j��L���u_𕜜P�4��K�_��r��ӥ�M��,������܏�V�F2��9�����m��c:+5��Y9����Ϝ��9֒�Z��X�Sl?�C�a㮪sQ\n���F��?d�w}�y$V�����>{�S�L��l�j͍����Xܧ�Cɕݳ�8>6�uԒ1~�, l3H\\�7l7;^����It@͏����t%�Q��*�\Z���0y|f�*�ءb9�@���\r�m��eȲ�z�Ip�֐�3J��������F\'�y������^ۏh��Ά>��NM-�v*7ҙ��b�7�㖝���7�_B��}���?Gg+�Q�#�\'���X3��b��v�x��,�̔ѡ��ZչAۚ���_ ������_VSN�.\'GF�I��g����������\n�>�+߉�6UJ\ZrNn��uK�l���O���b����D�ͦG\0u�B�\\K�����\0��x��\ZL�X������܇3K�u�^�q�%9x���\r��?��Q<V~�V��s�ˑ1�LK�d�nP��dF;� ̫�������J�\Z4hPfD�&��+�x~~l��T�l��$�d\04@Ѧi��n���J/6��d*\'�W&O����Ccg�QO9����0t�T	�]!�ڭȔ�L1�z��#WԖs\0��=:.��\\6�u�Z7���fk���Q66��b_Dlj�K,VmL����<�8~Yʶ1�ܼ/�jΧؖ{vq��M�EF��dm|��8���ߡ�P�;�n�l����bv�n1`o\0Xռ�X�\r��U?�����b$T��\0��e�\n�o��j�<��n�cO�����U�S�l\rv�&��cR��66u㷓����҇o��9V��a���Rr��`VK���;:O7�:J�MV`�w�,�N#iBl5��[�0yBfL�	=H`�#��S��+H�.om��[��ݩK+���j���o��2��u�\r����9��߆hi�0�Tc\\|t�����mu�U�*m?�3� י$٪�M�TmL����^��d�83�${-��)�7���U�ȸ��&��>�a�T�߲�\nH�	&���R~�1�r\'�7������\r��;���߆��{�`��r�=����]��RT�\r�.��~#��m��s\"e&��M��!�u&�;59��ȫ府��R�☢��ڦ4��XmL���c�4�c4�<b��� a/�:Y}6U��y$�W>��+n��Wك�2ce�r�D/����m���\n��o,q�	P&M̈٨�&OWv4W�Ơ-MT��o�,帶*���~tE�=0:��\Z�M��i\"+����=ɼ㩲g�W�8��}&�uvZz��qϾ��&�������Bzt�!&���S�V��v�Q�z��,.<�����0)T�L]�T�c�%��q�5Fv�9�XH��:\0���BP�*�L�&��:Xz\r2O�Tf�A��D���X%P\Zc/!���[RMNϫ(G&�]3ɶ!�e��1���=Y�,��?�c׉�d��Q�⒨��4j�Y��^l�oF&�Wp�|8w���|T �4ϔ�ʨ�ݕG�%�\\k���M���}p���[&��ᡔ�}DJ��#ˎ���)-�$w�c�����]_��u��r�d�L����<���?{��M	�ye;b*X�2U�����1���i�_@]{�]�y�(n�kpf��\'�l�RO�;/kbeU�I��2�>k_Kɺ>R��Q���bRz�\'4I��F�<\")�Bϛ9�����������&��8,-����D��n��[m\\��:)���J��n�{v��p1ʳX�l����2]�#^��eǤ*��W�90�����,7`s#\rL�.\Z����:�9A�厏�Zd�H��~&OTs����cr˶~e#>{ø��~�Y�#뮤�\Z2���$ö�yf�|��M�7r�u�\"�7��]\r�k:p���\n�W<s�V�?\Z��L9*�Lډ	��j��x��\'�j���1@��\Z\'-{zH�Ʈ���Y�&���ʭ�&I��pϳkQX<\Z~\'��k9�~Hv-l%k���2�Ρ9� �we��E��y�Gf�Ƅ�5�ۢ�rf�Wr|FY94���\rPe���3ɚ��\rҜ?e��#�1�l����q��:\\����I�K����d��R\r\0���!��qr�\Z\nǜ�0ɠM\0yX���s�g�B��\0��y���a�^yx⒊CS_��W�J4�	�LN��p��Ǒ�2u�M����,��Pn<5�q��I[�!y�l�=V�ޛwM��B$����[=��ါ�[�y2�EeY��Vֵ7�:g[Y��N6�$[eE�)[�T�7��$�z۩��ko#k�;3[#�.Fl\r��n��7؂��7�����\Z�Y��e��d��e��&���|��E�.�)����8d,Ɯ�k�_��7�<8!�l�Y��X ������<��C�T�\Z���]2ঁ�|LJ1�	�\'R���L\\xC�<K���I�K�-�����{X�+:�\0��f����,_�J���er�5�1a9�d��%��A�V3ȑ���f�r��ANT0���d.�l�SX��]-�\'�/3L�~U�,����r��	{�d���mRr|�A���{C��qV��z\"�P�8�Sr\Z�\n�y\0&w@2�倸ץ�8�%k�:lg��߰��$�Xipb�\n�S�7��&��L�6&��de��$a���y��t�#�\"��)o��E\\��y{���~���!��3�����7E\Z�I��Re�g�l<|_6��Q<�$�`�4��,`���\r��9_{���=^ve�d��{��L��9d��K�|���/8�.�6\'�ao��EW(�!�{��k�<�G�`�w�$s�9\rs��34��&��E�(�d�L�<_���q���c�	5+J�����K��\0Q��݉����4Y��4�z^.��#@|���D�}���a�I6�L�\r�S%��I����b7d�}�&��#ir�I\\+�#�ݹ��-UA��H��AL�`\0�TVV� �x�?�{��R�N< ��أ�����&Y~2]\"OX��|^�%z��I&!/X}4En\"A�5�#�r|��4�r^�)s�x��D84��#]��d���^X���{�f�y��=c�[�ˁɫ+\rI����(��M��\'\Z����&����zxȊ��%��<��������o>JGc��M�W|\ru�x��9F{h�;,�D��J\'�({����J������i�{\0�^A�����[\0�\\Ƭ��a/���B\\Q��#�ǝ���4���FYp�1x-��G�d>%�N� �W�F�c�g\n�LI�s\0\\���r4�aR�\Z�<b�I��7�W�RJ��9�Y�N�`ށ��k�Jψ,$�+�?�a�Ei�q;]� �>�b��#�6�e��}M����gI�4,e^O&��IX�$*�����ș+F8��s�\\H��\'R�e#�B����?@y;:a�l�_H�::��9�]�og#��f�}ٲȁlYeO�̲�1���@��ne��l7��rr���F0x�z�)\0���bT9U)�ñr�Pey�4I�Gʈ�����񳖏�����ҥ��4��g��bM�Κ��W�v�|���_�I<���:�t��z��<�	�7\nY���ϥ!J���/�Y2����ZM�����\Ze�K��	6�$1���d��TŤ�\09��&�ڣ4q5C��*-�˗��ŋ�Kƌr��^���\'ǋ��Ŋɑ�e]���y����*�\"P�#a��GJ�!?�i�Y��Q�BEÌ*�Pn�4`9>}��c>?�)�v��c�K,�H:�s8%�!X���zt��T���<���p��������s}�/aZ��I�lL0�kB���I�EY�e�e�$D\"P6a�(�d�&+�X���Q�i�e�[��\\���&G�R%�ʀ��3<�}/g��J_��O\r����7sf�)#>�*�e�j�B�[��ll;@����=���C�T���F->���4ـ< �Q�:�R��-qVsҘD��_\Z\"]�_F#\'U^��pl:�#X gЦ4)�;&�hs��Y�կ�y�]�Ŧ\\��ez%ԛ�Z�+]n�\r�X�[��\0�	dj��Si��G|�^+�V���)e\nh,c1�[_T��\"]����m��Ģ�M��1XD&q��{מr�n]	m�^n}���e�*�4\0��rX���)]FV5�(��O�\"at~�Uȴ��t9出��9?�Q�c	,��1�)�a���/b�<��k5���J^\'���t��p��>�RkT���g�C\'����N�J8����O�����n4\n��r%\r-@���¢��ǈ ����<M0)�~\n{�����F,EVh�\\k�&����8�.�L��:�����ѱ��h!O\r��?�$��e�;ٳ����ſ>����\0~s�r��A3�tC^(�.?�	���;�N�\0�����R��2��9VK\'�8��$���r_�P��\0\0��atv<zC�o6J�>�iEs9��X&\\�a�2=�~(�31�θY�8��~�؈8y�\\w�4(��j*����)��$,��h, b�o&d�����\'Ͻ��̽ѹ�<\Z>\\�\0h����`w��v�^=�	�^����u�C*%�Jz���K0s�:��pb�	�,�Ư��]y�,�a��N>�Gx��ބ����6�t�;>U��{�Tu�X\0�Ჸ��+�ҽ\'~�\')�۪Tq\r5�f�?�(�\\a����Wd�y�E�TQ�@����d�8X��M	����V`s���\\|��w\\N��f�ĽcG���_<��^</��) ��U<\Z5<�QC���A�v�Mz�P~?�\ZT:�^�p,t>k�r�L 9:-����`��yEn ��V+��ǳh~�X�&e{�����!o�g��Ë��{��T�[ܹjCSd�q�\\B\"�8�\r�Evʍ��n/������0MB.e�^M�RI�V��B�@�,��g5����(�I\0�򞽲�qc9ӵ�x >�bo\0���g�\r���6�&M�v��oeU�Zrl�N�(�eSBc��T~kr�T��NH`�>*�\"�L�0��.�9<M\Za�[�_J(~FE����}a�]ҥڰ)�2�a�/z��X��ʨK7��P�9�])���&�Se��\\��Q�h�L6w�uKf�|�&JF_�L�$��@�f2B����l2����J9�b��q��1��&�X�^�\0��{�b�_���)��l���w�ڲ��m�Z�\0�K��،���⽒]�����̆��\'�F`9V=�\"���L,o`~K�v=�Ya��\nX8���� [o:�V����5�n��Q�ۊV��H�Ȃ��Ư*�+Y��O����E��\r��9��p�^���C�LX�\\�D��Z0��*�3&16�@��\"�h�:���k�EW�����i�e7�����YS�:8�-\'\'yְ�$���ݻ��G�m�F.}��\Z:]�\'�*�{P:��`-�r,���XXK��c^�o�H�q7e�G�b�px�v\Z]��У�,~9\Z��p��\0���Ñ�bc*��\\mH�̀<�\"{v����@_|d��kɘ���8�����R�(YW�$���i�Ѫ�ր�YM֐=�q��`�g1r|�9�{e�V3F^�$J��7��+={�\0\\@�m�V���:��h�g�D�\ZP��V���8���۪203��������e̍�Gʬ	[�e��G`�I.\0�sp~7��;�0J���R����le;�d���ZKy����ϒ]~��\"kQ���WC_��g0�=A��~�]�� \0�<��.Д0k�V���f\\#�YKR��\"�y�{(����:H�b�1C%�@�%_>��~S��\0�F����u�F����d�`Z�T�`~7�@�SleA)�3c&P0:-�eXb����K����ʁ�d��X�`j⟧�H��/��U���.{���;��*�1n^i�$i�(Uv^5�aH4�(6\0Na\"�FK�5�r�v���󰋘�<�@3&1�f|R�M��a52��ב:�)���`�M�����d�Δŋ��8U\0\nZ����\0�d��u���&m��L����O��.~�D<g�ǰ�1* a�����xbN�p�Gv��1���g�� ���C�����\'@�}8��nI���\Z死�7c��-�M�Q|����{R�h��r=���o{nb���\"G\0���wU�;��l�,��W@+F�t�f�&Д<.��p�i���~Rz��C.��$����%KD&MA{{�F���G,~�|�����U�� a\0Wɮ�P�\0�I<�����������gp���IN��(u��$<���ض܍�wې8m�š�oľ�8�@_r��[!GqJ��F�a��u�+I�7��8s��[/��8,6%:���H�����\'ʸ�\0[n���|3@>�	��� }�<�m�jR\'a�པ(�g}�F��M�S1Lk��6�e�p|��G�?������l*���j�$\0��_\"�zY�`o�j%�(�T�&�Ԗ�뎪�@aP���y[����i�k`�|��r\ZN�\n�N<H�#w�\0���@��*v�����/��[dv����U���n���X�5��8�� H��t�4ۓ\\�B-��g-�|&�S�}��R�+�6�Qю��K��Rۉ�n�Dw�}\0{���2vo��aT{FYҁ��U��t��)i����i	�&���٭�lv��\"���a�x6o)C�Jbp�}��ܷ���ܹ%	W@���F�?�5�Q�Q�*U�\rs��8z�Z3��q8,]\\�X0���^s�����-�n�i�kd�5?�q5I��;\0p}DVz y:�cGgp s�s�V�}�2��K�\\����>\0=�Ij`\r���6�(�o�!����[�2j�r`��	�?�M�hO��fLt�5L6�(�7��\'\'@�!c��aM�-@l�h�Y,�\Z h�z���f���\Zp��\"�����$�o_�9a�\\��M�>�\\�3d�\\����d�b�	����ײb�R�x;Yb�K�8�.�p\\����|\n��IH��;i���)���7Ri{Ai{����-�!��|L�\n��]@/\Z\'C�M{#ǐ�%����Q��X\'�b)N{��\Zm���Xe�[�,�\Zj]���K���Q���E:$H��ɲ���\0�G\\�`�s����(Y�*�1��~�|\0v�]��᮰�\Z�z	a\r��#�U�\0F�����x�;~�lG���w��g�\\��\0�\00��+6:��\0�.`Kqs�����9}-N�,t:�~�Gg�\0�c\0�0r���=�)2�g���Q@�-��:[���We\r����l�\"���;%�b7(����yo���@���s���n���b5~��aQ��S�M��9J�����p�V��\0�N��Y\niZ���q}(NF��\rAF��B�wcR�W\nh�l\r�q�V0���q�-�)�Z����i�@�_{&���T\0���G�\0p\0�\\��%�\0������k`�-��pt�^�k\'����F\\�~��z�>��C\'�y5]ܡ$<�}\Z��k���8����]�}j�4��]��쒥1��^�s[sq0~&X<�Q��|7s:7�%8]����X��\0��6�����J�bX�\\u߱�Q�7�}�o)�\'y\n��<]�C�4��*�}qe b�J�2�v�v���1�l���[Ze�V�f\\:�8\r��URF�!݌լ�)��1qa��vls�\n�M{�.����O|��\0/��F\0~�\'�D����!�J��:u#2�?�O$b��*{]C���۬�.#�#��|�>��)�1��8F��z�,z +��`8 \0��a\rfz�B�$2�ӌ�i���9�ɹ��&ʐ=�d�_�R;b֬�B�,a-��w���Y~�������ͳ|�[E�m�(-0��`�?3�3�Sd��X�1EM��x�41L��J4(��(�	�VGג2=���ݔrf�47,��3��y���/����ĉ�K�-UJp*\0Ng��?�A3$\0��}k֐\r�[ȶ��(��y\03�́�P\\�O�g��\r���c|�1���J8��@\r\\O�����C�Ax�{�1���8�E)2xO��9��օ��y�?�G Yr7�s��ۇ��6�y�x�?_�(�\"������%ȋ1���e��ײ��Wc��WX��F�@����[���`31��[ح��S��Ç.��&�%�͟3k��,Z$�lIB�\0$Z��p\0A�Z�\\6��\\��l��..��0L�Ǧ�9Լ��q��~�\\3����k1���b�S.�rpy�8�6�ă��s�ss�t��Fy赌sI�X��X��X��R�(�2�/��r~9\0���o��[d�|ͣC\n�I��sSddi.<x����	2�x����/��U0hN�GR�qo�\"�í��0ѓ2֌��\np<�%?0mv�Ӎ~��ݝ%y�B1`qv)Q�0NXJŊ\"��*	�,\0f7�j�d�7�ʊ���wP-��kf���#$�\"s��M\0���ح�;��u��E����(c��P>�.}���W �\Z�$�%�B$�!��Q77C�+�6A��z-�>�W��x����?�VQ��6�~P��i2�%&8��d���%�$\\���/�-��KhNt-&�����lf�b�I	g�Bg��4:X}(qn�q��WyԿ�$\\�`��A���Q`㘎	\'9��Y\"�C�ux�VM�W�k�3a�칂���#�@F|�3>\0iފ�ۨ3Ww.c.e�pG�:���D��H��ݸ@̫9w:�R�T\\�4�@��8��7�������J!�e�_C_�;~ś��N���_�F���i\ZT�u�lO�I��t�x��Tp0I&�C	ٲH7����hc�hM����A�pk��8�@g��j�이B�׫/C�����8k*ZT�p\n6^�Tz�X|�pa	Bb��mE��]K��\\��_([��\0>�N�GjN�4\"�d�z8�\Z�q9�r!\0���,��`�\"����S�eȎTYCY&��b��g\\0��CI2Wm��3@��s\00�ҩ���9�} \0��<�@�x�����\"�������Sd*� ��s!A�!�hkFs�:Д0�Z%e\0���P�)q{��.��b8[�~/e��,��ȑ��S��L=����\0�\n�Y�8��%����h]�t�1H�B�{R���b�j�ґ��e��n,�:��=P�M������˘;B���\0x�?�l�lK����s_\0��u��KP���a��4�b�y�XC��S}\0\\�Ϳ����k�4o�&O/�m/5G%A�Lʓ��*��8\'?��	̄hz+��Ƥ9q��z�����0)�l�p^e�@gF��V\0���#��m��GW*%�-d�ׇ� ���k�\0�?,\0 ���v���K�L{��xI�2��>����e�3-p�a{d���b7$[�XB��l��]x�<@υ���f��5\r���fȊ�lJ�%pb�J5�\Z��{g`=�����\'ܱ�[���$��c�����ޓ����s95z|(���Ri@�8j��gpQ��T���\'�T��\'æR�6�&�	4\'la5�o�������3v�,\\c�\\�۔s2j��MY�{G��\r.�FV��?l��,b+�\0�JB\\��GC<�C,�����nxߖR%eF�?e!��M\0�Y�r��y\0y6r\n��s��QVa�hڒ�P��5�M�����`9oM��kS����:EF����9s�b�e}$z���Vc\0�&�z J$�e���e+ō��[&�s�����s5��ϻ\'Hם�+����P������͚p�\Zhz��oz������f̲����-��I\Z��r��,�����q���\0dȪ���:6\0\0��\0�?D~�$�:�>R�v�~�9}e\r��#1�]��dֻ�:\0O�e,�ev��3�@\\+<`7��q�Ad���d�}���M�Ҁ�sSͦ�ٹa#Oc+�p\Zbw���c��XC�e��Bm3\n���?}�7��)8�g?������H�xi�*M��`Oz��IՂ�Ί�q�]F3�G+�~�ՌU�4V3W`��v�ec�*\0�t�9YR���)������Ȟ�!��5�G�\0��}����%\0���+Q����M����xQ��y���]�.�����W���㚏Rp@�����T#�W�<���	�R���tn�Y��Be�T;�3�!Z��lѶ��k��ɾ�y{��V���\Z{ǺW~wl�2������q\0᠑l �a�b�6\'��4�`3l�..�42��ƶ�h�-XpD���\\/&^hU�D�>���jU��y�D��p�aqx����e���}�A���zk�2�`)�4�,�&�2\0J�b~@ӳ_�\r��K����P[)�:�d+��92LQ�,��NO�����>�.�������˳4���]2�����X/��*���i�S�8\\��(�w�\'���@���Fmh\Z�	҃9aN�rE�豚�dD�8���J.-W�s��RdѸ����\\�]��<ƎQ<6R��k�&� �2i\0�\"��fd�!��0����Q��5�s�����ke΅dYPU�����2P��c�A��ʹT���L�~ءX���>.&�y�4(썓u���r}��)�o��{yd��U({���s�+��F�S��q�B_X?\0=\0]k�Y/��=�q\Z��Z��%!*�j�\0�X��]��{�D��� gI����ة�Y,�TP��D��v�q�,���eq�����dz�L2,o	2t��d�pu0������0A��*ǫ3�*�DP�̜+U�NN`�`��.}�>MV�E���\Zf�f�}��eg�J����u�e��C��?E%;5��jc���A�#\n �zdN��ց��r���:)��.���\0�@�D2s��C��� �E?��\"�E�4	-\03����}`�sd��yu��2�1���[D��V��.C6G�\\�����]�T���\Z��2�NK&�t桬�5`T�E_����Ij�K{c%G���%�{\Z��a^����d1B��![�K�e���Z��b��Z�\"a�B���Hw<�ѽ5V���\\]�،�\\�H,H�m%�:�d8�)d�b:c�[���qG���.���!�y\0n&��mU�};�[��i2j�9sK��ͤg�-8w[FM�	�N�2^-�*�Z�T���W\n���0*;[`*�J���	,��	����v��Z�c���������.�s� ��	�Y��V ���d��Ҙ�a,o�\'m��K��h�4��hNL�7&��[[�A\0�^΅��Ф�L�̍�btc��O���D\00�L���L�\'c��\rX�gy�1��Tw�Μ�O���֧B��k��^q-Cl��;������J���_��\ZT����J�U�j2���&�k@��uؗ.U� �e����ż�6��M���և�ML����R����<����+tc��G�t8$��	��0��duLNɷ�j��4	��\r�3]�)sd��-�[1]�]b,ǜJ���qh��r�xU9\n֒�JT�.+���2\0�����i�1~UD��t2=�եW�Tǫ�������W�J���T̝k����Xۃ�Z��,k-�7_�C[{��I��4C���3����	Y��\"��Fk���;\0oE�@w�]�j\'̉��:�L�(�\\(���8V]��O0�\0�p0z$�5��l�z�t]rOz�O��\'MJFkl��gX����ӓ$*�U#ǫ˯T�I���*Ιj�	���&��]1Hs�z1���c�C�)�\r������u��XY3S��Y꾒̰�ݰO�+��\0�6�E���xNfs��b6���%1�l���֠kY9���K���i�I�����)h��H�㸑�(���Ӓ>~��) ��40)���S�@��F%Ss���6�KI��F\\�����䨊� C���o�q��_�k���͠Lu^�;�#E;���2&�\Z ��MVs�J�1iz��J�4W����N=v[@ץ]��\Z�Ew\0�Z��G����XD=~�·J��Ƥ%-��A-�jL�yљ�a�t�x�kQ�K�d�>F2Չ69|s6�֩�,aOX�+��c��i}�r�j����}�1�w/%�qRg������D[�\0��j.\0%����d�Z6�\'jе2���>���F��eV/a��He�Z���H/�DP�T#�T����y	j�Zc�\\��$��/L��e���+֌�x���;�������5}3V�~5���)��_J�_^I�������\0��(�5Vl.F[mq,	\Z�\\cxM�T	���H���³������韣=�s���wRa� )@��Wg)C���9r�M7�c�Ij\r���{f�X��ۼ�OlmGa�j�r~x���(%�y�M꒱�߅�����kG�2~#�[�K-��	t��fF[�Zg�Fv�q��Y�V�s�	������X������;\nD���ϵS��t>�II��T&}>��ȹrΜ�Z�Z���+xh��χ5���#/������\Z\\�\'��S��-�+��}����k>M�P�06Dk�q��`Y����\nl2[y�v3n�+���6x|������[��D�,��V�N~���L&��\ZT��\'̉s+�.^͕s�X3�h��wt��m2�]���n�����2crv�}ފ��G��p�]��v՟��V�F,�����T��2>Y~�}-��5�n�V�Y�dZ_D�!��[���h�@���Y��������*~�qTU�X86�l�I��c�2!Y�ũI���m�h��a������Bmr��:7����0�������	2o*R��P��M�q�m��s����Un�����D��U:6z��]�O�|3&Ij�L�z�S�!��&(���-w����٭K�Zx�%��jo��k`&��f���O�����w�9��.���8Ʋ}��̱s�s�P%4)CE���W\\�����M�\\ӱ`�`ya�T}���	���sJv6XQ�C�z�����)�h�m���/>���F�M��4��Q&%i�4�5x����[�	.Q��=�<�$+�J�W�mjc�{�F�a^���(J�n��_p����ex�?�~/�����g���.~\'��c�X�P��c�X9f�*�Fۯ������s�2Cl��>g�ٯ[\rv��1g�ER^ʿJJ����ۿ�2�H�9�B���7�lUZ�umSx�*�ˏ۔�hS���\n>Q6_�&�T�U��l��`z��/��[d��mY�1�V?Fr��\n[mp�(W�7��	ۦ����;���3��:�j�~?�����w�;���M�&���F�J7�l��)�aSfk�M��6�{585^g�T\Z-o�n�#/���dy���^�����bJ��b���k�C��\rٿ�l���h�<��\n�`(2������R��m>�{˦쉇6�ܞ�|�eS!0֦�x���a�6��\Z��H�*��eﾯ��4�_�&�T��Z}���6��>�){4ܦ���o���7�n���!W�͆�?/6d�j���3\\\r�:Qu`�tKJ�4c�\'������?���f��v5�\Z2�mi�V�ِ��!ǆ��5�n��z�!w�e�<�rw�h��u�!_���}�\Z���;�,�a��-��ϐ��.C�N�\r�\\�?����086Zd�Y�![퉆,G��1��������Ƙ�+�뤩A���b������8�-�rN&01!+J�x �,a��:����`���\\��0���1������g<~e���c���y�1ql#o��	P,¿���S済<�B��	hd?���a������w��9�\'v��h~��O+�i��\n�?��R����\0\0\0\0IEND�B`�','�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0x\0\0\0x\0\0\09d6�\0\0\0gAMA\0\0��7��\0\0\0tEXtSoftware\0Adobe ImageReadyq�e<\0\0KSIDATx^�}x�׺�$$\'\r�^\n�R�S�m)�b��wwwwww�$��F�$�$XB�y���|�0pz��9�>?�<���0���׻�+{_�O�>������V��\n|Z�O+�\\1l��4d9��Pȭ���s�\r5/t0Ի����Ŏ�&����;��h�u����-Ŗ44���`��Ƨ_��\\�z�C��]\r��w14����\r+�����`\0�`�yv1$yu5��sn�\r�`gN�3lpiku����Ζ�ʓj\Z�>����?�Y�&l�:�]��gog�ї������g�D�����N4��\\��\\�ZUBfՒ��?����������re�4���w��xt1$��h��T{��m��l�����%J�68`x6��?��_]Wg��y�-��3,��j�����o��<���.�\'�u�g\'�I����*p��_�%	7�IR�AI\n�/	׶I����D��N�g���\r�$tNu	UD|�d�K]m��:��ti�aˎV�]~k(�����c��{c���3�w^��Wxv����l�\Z8$��.�/��K��FI�{Z�^���\\����5�?X�e�H��H��H��ȋ�\"OO�<>.iw�Hb�J�97^\"v����U$p�g��=�ѽK�{.��.n��y��91Tۿ1�Oo�gV��ly�z�\r�����9Cr��\\r{U3���Dﻉ��\r���\"�aqw\0�-�W!f�_^�A�\0��`�D�_y�.�\0G��N����x{�$.�����΢o��x:gH=�%㕝��gt���<ƞ�l�3�7���n��w�L�{f���eo\n]PW�.-��1��p���\0���{��u����H�|	\0��g�)��yx�O��n1��*���$�Xo���}��}��ΙN���1������ {�u���7�)�^^�kz�o�$=��tl�%�4���GV@ߵb2d�2d:�,�h�b�~t���]\"�����\"��KR�ly���\ru�^�I��2��hh��}�	�d��o�����e���m�rmZy�F�bB̀��\'��\"I��_#�:�����x��\Z�8\nRM?�b1e\Z�X���w��6���:I��\\�\\�ʵI%Ļwƴ3�3�,h�qX�|��������ً��\Z���>-t��:�0�қ\0����Hr$,����x�~\rٶ���l-�`����Y��\r�\0x�b��� �[���bY%��H��ķ���L�,�f5�4s���ا�z~��y�\rȔ~{��Ȍ#�<,.Kp�ERbDRc5{��^�g\0�2��ߍ��%]����`1b�dӔ�Z�N�F~�8��\0C��n�7�[#��U���(��+�_�,��ݳ�\ZW/s?�/�\'��oP�,���Q�oH�ӁC�˝�H�y\r��Cj�DQ���P�6��Ƌ���%�S\0�d��ɗb13k��_��90���o�0f�+�CVHj�J���(a�\n�z�9��Au���ap��_�lsyP����r��#���2���ty֥9LU�Xc2,���2��#0��1T,�L��2�n�V\0?�fެb���\07��re1FIȼ��H������������S	���re���?`XΨ�+�+�UbR�\n�N�%	0㮒f�IpӍ\"&Xz*\0O��qf��f����/F�C�K��L\Z��]3�bx��i\0\'�X*I��s�>rcz�80g�fY�U-f_�c{��?���?F8~�?����b���(1�@C�\0f���MO�,&���\0|}����y�x�reB!9�+��u2q�l(�I�5���7�����/�͗vsI���C�U�`&H�Fv�+%S�Dd%�d/d��V�d�I��J��$�/$:\0\'^[���\"�����0:�iMۜ����g��qoR��l�?���Q��̫,�|��[�l-�1��d�η�,\0g�i�5�@X��/����R*!ɲ�.Yk-U#�bO�:[����:�:�F������Յe�<s�%7f���N1�f�Z$��@��7(����8:��k�\nK��.bG됋O�ٔ���,�T&��L\Z���\\��\r�/ٛf�C/�X��2�NU\0/�x��������M��Չem;G�Z%2��Ʉ����ݡ��yk��{;t�7�&,:Q\0@��2����0K�����0�^�T�K�R��\\�&{�	��]%���,8�[��������a�d�F�Zd�H�P��\\!�\0��7��BI\0���J|�<y��Wn�-\'g���P=ˤ��m,>5,_V���F]�R(��֒��Bnp�#�d�4Y��b�ZG�+J�n���}���^�Y�mrP�Y�U\"i�=�_f����Ps���HϠ!�do\0��<���rg}=	�\\(}Z3G�b���L%��\'��8����9_H�ũ\0��g\\$��Tk�X�2�R k�-��@�n�V��()puif�%{)Ϟ�.l�6%��n���*���Db�u�,�86h��\n�%�:\"��}}�<�Tء+�����#7W��yyr��wW� �!�uϰ�\\p.<��rc���T�I�@F<U\r�.��q�����L�(�/��p�.�����@�j�΍����]����	֛��ԜA+��)��Β�3�!���x�+�ҢJ�E3\Z���\Z=���O,��ڌb�{ۊ�[u�9S.�f�X�L��L&#�\0�`��#�����g�\n��v�4pU��c������b����V��<3�*y6\'XI�DB�%���qAsp<h�����3a��\\�V�4��S����\0`�x�y-(�9`Jэ7�}.�n#*ڄl�3�!��]�T3�zd�d2���M��n|M���-�1����p\Zu�C�f�^�^}����.�_�GV��\Z,-��k�8S�}��s�	roOK�1��,�74w��@6�ǃ.f�1�l��ӊ�-�Z�X,2Y�@�y�B�c2�I�\Z )6��\r�Xl\ZY����#X�!s��iGuؚ|gb�� ���\rj�В=�U-�ȳpL���$O/��G�HȂ/�ذ�Q���c��?*�æ�)tuf���k����z,2D� 3�̘�	�b�4T`[��g��X�֥ԫ��aq{��8P\Zݷ��o57(��A���?k,]���<\rQe�D`�KO	]��\\�P<�|A�\0��G���ծ�.�h[cI��Z��硘��d��2b2�Q��\rFl��ĉ���52��x,��*�n�}�\\(��r,ֽ���,�ީ}�ޛln0{&{���w�3�����>L����(�V�b֍\0�\"��9��=�X���K�=��RL<\Z��d�E&?�Q4�k�Q��`�l�Z���,�%���V;AIY&s���p<�[��3X*��Np��Z��&�2g��z�����=Q������{\08l�wr}^iS�\Z�n͏*��Z��ͅ���y�٧�Hl�=�@Ƣ�Y��Y͸�������&�d�ft\0�3��,�s(�ʖ�up�\Z\Z��1��i~�9�ٻ��Jg�K�������0yx���9�^_q�si���I�ˆG�F�=��h����8�	�rq���5�@Ƣ�Y���!�<���/�D��DUNleZ���[)�L��T�w~�s�j����\\���iK\\%�z��*���$j_46bP\ZE2�{��\'�ȭ����G	]�����+�����\0|q���-�&+������G���#HJ^u����Vr��j�elW��=k�f��C;F�%�I�.�7;G���Ζ����c�D������=$�p�	s�m����m\0���\0|vB����I�8�\Z�a�E�٠�)��)\n.>��RB-@k�VKV�����4�G�NB�W�R��T�{P�������7��$��\\����WO����\Z�5��g�t��W��&7�w��kj����Z��I���Q|r\\��AsK%>������Oi�\"�����)�d��3)�d5$2�S�ӬAE\\Wr��Q���2$܅Cѱ4Y6�[�NM�+�5��}Ӗ�3g�F3�ؘ�����S��.�{��\\���\\]YM�f�2֯���G��(^�wV��;[~�T$/渷Vm���ža3�V2�XI�YH��;�^��������*�j�^;̮���ZcnfX�e��ۑ̘Y!k�0�e�^&V�������� �w���:��m/Ww6��e_˹�œ�δ	\0�����=C\n;yM+r�b\"�u�L�D�b�_M��q�k�+05@�e\'\ZS�p�zd\"֪�?=��Yg���>�psn��,sϗq��\n�9GB��]-�݆�W\\�v����(���)�[\ZK���rpd�<92,�����D��M,z4xqEy�9V%6i�j� s��h��hJ7⥊єWf�d��p������C@c	*㬹�5�Y�d_�:Ufp�N������5�%����XKbu�DO	cb���\\��R��0��,u���v\0���ˀ�GG��?����P� �$��L\0���e���YM�?i����̀���6c��Z�[�\r��\\Ն�fˤJu�T�i>�I�Ko�}���h/�v������5�ov	��+Yl\0ق��)��������iEo�h�,�Ԝ:�Lx,��1Ng���\0���ހ�6S�5��5׸��2�)0W��x�dYkE*pf�K_64wG��$�]���cΚ4����$`ӯ��+9?�p�ϕ�����Ĕ?*�1Y�U�r�95>����$�7��\\x^���[�o��2)�e��?3׳\ZSUv�e�Z��c�q��U��Nh���.�H�\"�ƣ$\Z)�*��E͋�{�����F��l!�[���5����/�T~��Z���Y�\'�g���Y�5�4z=%�r�)�j�Q�(�u�0\n$���]3�GTώ[5��B�sh?��L��&�J��cV�.bn4�������!`.ۑ=Tܽ��{q7hkS���P<�T�3�ʨ��re���yG��\'�ҥ��kz�lvfB���RY*�e�����2��`h3ة!���Y���W�S���F�UmKGR}esoY?�af-�)s)d�ܩ23w�ʘ��v�3J�v\n��ۚ�?��z��甕c��֫�����c�g}�6���,�wp��s�@�W�c��(���`3NZ�_\0����c�����A�L1�a�d����H��\Z��u���%s�꫚*c�*����9�k �W�)EdF[��b�3,�D��}<��zr���e]�#g��򿺶�Ԙ3US��\"\0�a��k\0Y\0\'p��H�,��|Pʰ&�\nT�X�-?�Z��\rk\\f�lbp��NgD��-@sBu�Dws��n)�Ș65���Ҋ��mV94\"Oj�*��gv��5�<�����T�Nj����~�u�Y&�b1�n������n3`��:ӭ���\\�V��A��%��$ٲ�F$���Fc��ѥB��6\Za��P1�j��L���u_𕜜P�4��K�_��r��ӥ�M��,������܏�V�F2��9�����m��c:+5��Y9����Ϝ��9֒�Z��X�Sl?�C�a㮪sQ\n���F��?d�w}�y$V�����>{�S�L��l�j͍����Xܧ�Cɕݳ�8>6�uԒ1~�, l3H\\�7l7;^����It@͏����t%�Q��*�\Z���0y|f�*�ءb9�@���\r�m��eȲ�z�Ip�֐�3J��������F\'�y������^ۏh��Ά>��NM-�v*7ҙ��b�7�㖝���7�_B��}���?Gg+�Q�#�\'���X3��b��v�x��,�̔ѡ��ZչAۚ���_ ������_VSN�.\'GF�I��g����������\n�>�+߉�6UJ\ZrNn��uK�l���O���b����D�ͦG\0u�B�\\K�����\0��x��\ZL�X������܇3K�u�^�q�%9x���\r��?��Q<V~�V��s�ˑ1�LK�d�nP��dF;� ̫�������J�\Z4hPfD�&��+�x~~l��T�l��$�d\04@Ѧi��n���J/6��d*\'�W&O����Ccg�QO9����0t�T	�]!�ڭȔ�L1�z��#WԖs\0��=:.��\\6�u�Z7���fk���Q66��b_Dlj�K,VmL����<�8~Yʶ1�ܼ/�jΧؖ{vq��M�EF��dm|��8���ߡ�P�;�n�l����bv�n1`o\0Xռ�X�\r��U?�����b$T��\0��e�\n�o��j�<��n�cO�����U�S�l\rv�&��cR��66u㷓����҇o��9V��a���Rr��`VK���;:O7�:J�MV`�w�,�N#iBl5��[�0yBfL�	=H`�#��S��+H�.om��[��ݩK+���j���o��2��u�\r����9��߆hi�0�Tc\\|t�����mu�U�*m?�3� י$٪�M�TmL����^��d�83�${-��)�7���U�ȸ��&��>�a�T�߲�\nH�	&���R~�1�r\'�7������\r��;���߆��{�`��r�=����]��RT�\r�.��~#��m��s\"e&��M��!�u&�;59��ȫ府��R�☢��ڦ4��XmL���c�4�c4�<b��� a/�:Y}6U��y$�W>��+n��Wك�2ce�r�D/����m���\n��o,q�	P&M̈٨�&OWv4W�Ơ-MT��o�,帶*���~tE�=0:��\Z�M��i\"+����=ɼ㩲g�W�8��}&�uvZz��qϾ��&�������Bzt�!&���S�V��v�Q�z��,.<�����0)T�L]�T�c�%��q�5Fv�9�XH��:\0���BP�*�L�&��:Xz\r2O�Tf�A��D���X%P\Zc/!���[RMNϫ(G&�]3ɶ!�e��1���=Y�,��?�c׉�d��Q�⒨��4j�Y��^l�oF&�Wp�|8w���|T �4ϔ�ʨ�ݕG�%�\\k���M���}p���[&��ᡔ�}DJ��#ˎ���)-�$w�c�����]_��u��r�d�L����<���?{��M	�ye;b*X�2U�����1���i�_@]{�]�y�(n�kpf��\'�l�RO�;/kbeU�I��2�>k_Kɺ>R��Q���bRz�\'4I��F�<\")�Bϛ9�����������&��8,-����D��n��[m\\��:)���J��n�{v��p1ʳX�l����2]�#^��eǤ*��W�90�����,7`s#\rL�.\Z����:�9A�厏�Zd�H��~&OTs����cr˶~e#>{ø��~�Y�#뮤�\Z2���$ö�yf�|��M�7r�u�\"�7��]\r�k:p���\n�W<s�V�?\Z��L9*�Lډ	��j��x��\'�j���1@��\Z\'-{zH�Ʈ���Y�&���ʭ�&I��pϳkQX<\Z~\'��k9�~Hv-l%k���2�Ρ9� �we��E��y�Gf�Ƅ�5�ۢ�rf�Wr|FY94���\rPe���3ɚ��\rҜ?e��#�1�l����q��:\\����I�K����d��R\r\0���!��qr�\Z\nǜ�0ɠM\0yX���s�g�B��\0��y���a�^yx⒊CS_��W�J4�	�LN��p��Ǒ�2u�M����,��Pn<5�q��I[�!y�l�=V�ޛwM��B$����[=��ါ�[�y2�EeY��Vֵ7�:g[Y��N6�$[eE�)[�T�7��$�z۩��ko#k�;3[#�.Fl\r��n��7؂��7�����\Z�Y��e��d��e��&���|��E�.�)����8d,Ɯ�k�_��7�<8!�l�Y��X ������<��C�T�\Z���]2ঁ�|LJ1�	�\'R���L\\xC�<K���I�K�-�����{X�+:�\0��f����,_�J���er�5�1a9�d��%��A�V3ȑ���f�r��ANT0���d.�l�SX��]-�\'�/3L�~U�,����r��	{�d���mRr|�A���{C��qV��z\"�P�8�Sr\Z�\n�y\0&w@2�倸ץ�8�%k�:lg��߰��$�Xipb�\n�S�7��&��L�6&��de��$a���y��t�#�\"��)o��E\\��y{���~���!��3�����7E\Z�I��Re�g�l<|_6��Q<�$�`�4��,`���\r��9_{���=^ve�d��{��L��9d��K�|���/8�.�6\'�ao��EW(�!�{��k�<�G�`�w�$s�9\rs��34��&��E�(�d�L�<_���q���c�	5+J�����K��\0Q��݉����4Y��4�z^.��#@|���D�}���a�I6�L�\r�S%��I����b7d�}�&��#ir�I\\+�#�ݹ��-UA��H��AL�`\0�TVV� �x�?�{��R�N< ��أ�����&Y~2]\"OX��|^�%z��I&!/X}4En\"A�5�#�r|��4�r^�)s�x��D84��#]��d���^X���{�f�y��=c�[�ˁɫ+\rI����(��M��\'\Z����&����zxȊ��%��<��������o>JGc��M�W|\ru�x��9F{h�;,�D��J\'�({����J������i�{\0�^A�����[\0�\\Ƭ��a/���B\\Q��#�ǝ���4���FYp�1x-��G�d>%�N� �W�F�c�g\n�LI�s\0\\���r4�aR�\Z�<b�I��7�W�RJ��9�Y�N�`ށ��k�Jψ,$�+�?�a�Ei�q;]� �>�b��#�6�e��}M����gI�4,e^O&��IX�$*�����ș+F8��s�\\H��\'R�e#�B����?@y;:a�l�_H�::��9�]�og#��f�}ٲȁlYeO�̲�1���@��ne��l7��rr���F0x�z�)\0���bT9U)�ñr�Pey�4I�Gʈ�����񳖏�����ҥ��4��g��bM�Κ��W�v�|���_�I<���:�t��z��<�	�7\nY���ϥ!J���/�Y2����ZM�����\Ze�K��	6�$1���d��TŤ�\09��&�ڣ4q5C��*-�˗��ŋ�Kƌr��^���\'ǋ��Ŋɑ�e]���y����*�\"P�#a��GJ�!?�i�Y��Q�BEÌ*�Pn�4`9>}��c>?�)�v��c�K,�H:�s8%�!X���zt��T���<���p��������s}�/aZ��I�lL0�kB���I�EY�e�e�$D\"P6a�(�d�&+�X���Q�i�e�[��\\���&G�R%�ʀ��3<�}/g��J_��O\r����7sf�)#>�*�e�j�B�[��ll;@����=���C�T���F->���4ـ< �Q�:�R��-qVsҘD��_\Z\"]�_F#\'U^��pl:�#X gЦ4)�;&�hs��Y�կ�y�]�Ŧ\\��ez%ԛ�Z�+]n�\r�X�[��\0�	dj��Si��G|�^+�V���)e\nh,c1�[_T��\"]����m��Ģ�M��1XD&q��{מr�n]	m�^n}���e�*�4\0��rX���)]FV5�(��O�\"at~�Uȴ��t9出��9?�Q�c	,��1�)�a���/b�<��k5���J^\'���t��p��>�RkT���g�C\'����N�J8����O�����n4\n��r%\r-@���¢��ǈ ����<M0)�~\n{�����F,EVh�\\k�&����8�.�L��:�����ѱ��h!O\r��?�$��e�;ٳ����ſ>����\0~s�r��A3�tC^(�.?�	���;�N�\0�����R��2��9VK\'�8��$���r_�P��\0\0��atv<zC�o6J�>�iEs9��X&\\�a�2=�~(�31�θY�8��~�؈8y�\\w�4(��j*����)��$,��h, b�o&d�����\'Ͻ��̽ѹ�<\Z>\\�\0h����`w��v�^=�	�^����u�C*%�Jz���K0s�:��pb�	�,�Ư��]y�,�a��N>�Gx��ބ����6�t�;>U��{�Tu�X\0�Ჸ��+�ҽ\'~�\')�۪Tq\r5�f�?�(�\\a����Wd�y�E�TQ�@����d�8X��M	����V`s���\\|��w\\N��f�ĽcG���_<��^</��) ��U<\Z5<�QC���A�v�Mz�P~?�\ZT:�^�p,t>k�r�L 9:-����`��yEn ��V+��ǳh~�X�&e{�����!o�g��Ë��{��T�[ܹjCSd�q�\\B\"�8�\r�Evʍ��n/������0MB.e�^M�RI�V��B�@�,��g5����(�I\0�򞽲�qc9ӵ�x >�bo\0���g�\r���6�&M�v��oeU�Zrl�N�(�eSBc��T~kr�T��NH`�>*�\"�L�0��.�9<M\Za�[�_J(~FE����}a�]ҥڰ)�2�a�/z��X��ʨK7��P�9�])���&�Se��\\��Q�h�L6w�uKf�|�&JF_�L�$��@�f2B����l2����J9�b��q��1��&�X�^�\0��{�b�_���)��l���w�ڲ��m�Z�\0�K��،���⽒]�����̆��\'�F`9V=�\"���L,o`~K�v=�Ya��\nX8���� [o:�V����5�n��Q�ۊV��H�Ȃ��Ư*�+Y��O����E��\r��9��p�^���C�LX�\\�D��Z0��*�3&16�@��\"�h�:���k�EW�����i�e7�����YS�:8�-\'\'yְ�$���ݻ��G�m�F.}��\Z:]�\'�*�{P:��`-�r,���XXK��c^�o�H�q7e�G�b�px�v\Z]��У�,~9\Z��p��\0���Ñ�bc*��\\mH�̀<�\"{v����@_|d��kɘ���8�����R�(YW�$���i�Ѫ�ր�YM֐=�q��`�g1r|�9�{e�V3F^�$J��7��+={�\0\\@�m�V���:��h�g�D�\ZP��V���8���۪203��������e̍�Gʬ	[�e��G`�I.\0�sp~7��;�0J���R����le;�d���ZKy����ϒ]~��\"kQ���WC_��g0�=A��~�]�� \0�<��.Д0k�V���f\\#�YKR��\"�y�{(����:H�b�1C%�@�%_>��~S��\0�F����u�F����d�`Z�T�`~7�@�SleA)�3c&P0:-�eXb����K����ʁ�d��X�`j⟧�H��/��U���.{���;��*�1n^i�$i�(Uv^5�aH4�(6\0Na\"�FK�5�r�v���󰋘�<�@3&1�f|R�M��a52��ב:�)���`�M�����d�Δŋ��8U\0\nZ����\0�d��u���&m��L����O��.~�D<g�ǰ�1* a�����xbN�p�Gv��1���g�� ���C�����\'@�}8��nI���\Z死�7c��-�M�Q|����{R�h��r=���o{nb���\"G\0���wU�;��l�,��W@+F�t�f�&Д<.��p�i���~Rz��C.��$����%KD&MA{{�F���G,~�|�����U�� a\0Wɮ�P�\0�I<�����������gp���IN��(u��$<���ض܍�wې8m�š�oľ�8�@_r��[!GqJ��F�a��u�+I�7��8s��[/��8,6%:���H�����\'ʸ�\0[n���|3@>�	��� }�<�m�jR\'a�པ(�g}�F��M�S1Lk��6�e�p|��G�?������l*���j�$\0��_\"�zY�`o�j%�(�T�&�Ԗ�뎪�@aP���y[����i�k`�|��r\ZN�\n�N<H�#w�\0���@��*v�����/��[dv����U���n���X�5��8�� H��t�4ۓ\\�B-��g-�|&�S�}��R�+�6�Qю��K��Rۉ�n�Dw�}\0{���2vo��aT{FYҁ��U��t��)i����i	�&���٭�lv��\"���a�x6o)C�Jbp�}��ܷ���ܹ%	W@���F�?�5�Q�Q�*U�\rs��8z�Z3��q8,]\\�X0���^s�����-�n�i�kd�5?�q5I��;\0p}DVz y:�cGgp s�s�V�}�2��K�\\����>\0=�Ij`\r���6�(�o�!����[�2j�r`��	�?�M�hO��fLt�5L6�(�7��\'\'@�!c��aM�-@l�h�Y,�\Z h�z���f���\Zp��\"�����$�o_�9a�\\��M�>�\\�3d�\\����d�b�	����ײb�R�x;Yb�K�8�.�p\\����|\n��IH��;i���)���7Ri{Ai{����-�!��|L�\n��]@/\Z\'C�M{#ǐ�%����Q��X\'�b)N{��\Zm���Xe�[�,�\Zj]���K���Q���E:$H��ɲ���\0�G\\�`�s����(Y�*�1��~�|\0v�]��᮰�\Z�z	a\r��#�U�\0F�����x�;~�lG���w��g�\\��\0�\00��+6:��\0�.`Kqs�����9}-N�,t:�~�Gg�\0�c\0�0r���=�)2�g���Q@�-��:[���We\r����l�\"���;%�b7(����yo���@���s���n���b5~��aQ��S�M��9J�����p�V��\0�N��Y\niZ���q}(NF��\rAF��B�wcR�W\nh�l\r�q�V0���q�-�)�Z����i�@�_{&���T\0���G�\0p\0�\\��%�\0������k`�-��pt�^�k\'����F\\�~��z�>��C\'�y5]ܡ$<�}\Z��k���8����]�}j�4��]��쒥1��^�s[sq0~&X<�Q��|7s:7�%8]����X��\0��6�����J�bX�\\u߱�Q�7�}�o)�\'y\n��<]�C�4��*�}qe b�J�2�v�v���1�l���[Ze�V�f\\:�8\r��URF�!݌լ�)��1qa��vls�\n�M{�.����O|��\0/��F\0~�\'�D����!�J��:u#2�?�O$b��*{]C���۬�.#�#��|�>��)�1��8F��z�,z +��`8 \0��a\rfz�B�$2�ӌ�i���9�ɹ��&ʐ=�d�_�R;b֬�B�,a-��w���Y~�������ͳ|�[E�m�(-0��`�?3�3�Sd��X�1EM��x�41L��J4(��(�	�VGג2=���ݔrf�47,��3��y���/����ĉ�K�-UJp*\0Ng��?�A3$\0��}k֐\r�[ȶ��(��y\03�́�P\\�O�g��\r���c|�1���J8��@\r\\O�����C�Ax�{�1���8�E)2xO��9��օ��y�?�G Yr7�s��ۇ��6�y�x�?_�(�\"������%ȋ1���e��ײ��Wc��WX��F�@����[���`31��[ح��S��Ç.��&�%�͟3k��,Z$�lIB�\0$Z��p\0A�Z�\\6��\\��l��..��0L�Ǧ�9Լ��q��~�\\3����k1���b�S.�rpy�8�6�ă��s�ss�t��Fy赌sI�X��X��X��R�(�2�/��r~9\0���o��[d�|ͣC\n�I��sSddi.<x����	2�x����/��U0hN�GR�qo�\"�í��0ѓ2֌��\np<�%?0mv�Ӎ~��ݝ%y�B1`qv)Q�0NXJŊ\"��*	�,\0f7�j�d�7�ʊ���wP-��kf���#$�\"s��M\0���ح�;��u��E����(c��P>�.}���W �\Z�$�%�B$�!��Q77C�+�6A��z-�>�W��x����?�VQ��6�~P��i2�%&8��d���%�$\\���/�-��KhNt-&�����lf�b�I	g�Bg��4:X}(qn�q��WyԿ�$\\�`��A���Q`㘎	\'9��Y\"�C�ux�VM�W�k�3a�칂���#�@F|�3>\0iފ�ۨ3Ww.c.e�pG�:���D��H��ݸ@̫9w:�R�T\\�4�@��8��7�������J!�e�_C_�;~ś��N���_�F���i\ZT�u�lO�I��t�x��Tp0I&�C	ٲH7����hc�hM����A�pk��8�@g��j�이B�׫/C�����8k*ZT�p\n6^�Tz�X|�pa	Bb��mE��]K��\\��_([��\0>�N�GjN�4\"�d�z8�\Z�q9�r!\0���,��`�\"����S�eȎTYCY&��b��g\\0��CI2Wm��3@��s\00�ҩ���9�} \0��<�@�x�����\"�������Sd*� ��s!A�!�hkFs�:Д0�Z%e\0���P�)q{��.��b8[�~/e��,��ȑ��S��L=����\0�\n�Y�8��%����h]�t�1H�B�{R���b�j�ґ��e��n,�:��=P�M������˘;B���\0x�?�l�lK����s_\0��u��KP���a��4�b�y�XC��S}\0\\�Ϳ����k�4o�&O/�m/5G%A�Lʓ��*��8\'?��	̄hz+��Ƥ9q��z�����0)�l�p^e�@gF��V\0���#��m��GW*%�-d�ׇ� ���k�\0�?,\0 ���v���K�L{��xI�2��>����e�3-p�a{d���b7$[�XB��l��]x�<@υ���f��5\r���fȊ�lJ�%pb�J5�\Z��{g`=�����\'ܱ�[���$��c�����ޓ����s95z|(���Ri@�8j��gpQ��T���\'�T��\'æR�6�&�	4\'la5�o�������3v�,\\c�\\�۔s2j��MY�{G��\r.�FV��?l��,b+�\0�JB\\��GC<�C,�����nxߖR%eF�?e!��M\0�Y�r��y\0y6r\n��s��QVa�hڒ�P��5�M�����`9oM��kS����:EF����9s�b�e}$z���Vc\0�&�z J$�e���e+ō��[&�s�����s5��ϻ\'Hם�+����P������͚p�\Zhz��oz������f̲����-��I\Z��r��,�����q���\0dȪ���:6\0\0��\0�?D~�$�:�>R�v�~�9}e\r��#1�]��dֻ�:\0O�e,�ev��3�@\\+<`7��q�Ad���d�}���M�Ҁ�sSͦ�ٹa#Oc+�p\Zbw���c��XC�e��Bm3\n���?}�7��)8�g?������H�xi�*M��`Oz��IՂ�Ί�q�]F3�G+�~�ՌU�4V3W`��v�ec�*\0�t�9YR���)������Ȟ�!��5�G�\0��}����%\0���+Q����M����xQ��y���]�.�����W���㚏Rp@�����T#�W�<���	�R���tn�Y��Be�T;�3�!Z��lѶ��k��ɾ�y{��V���\Z{ǺW~wl�2������q\0᠑l �a�b�6\'��4�`3l�..�42��ƶ�h�-XpD���\\/&^hU�D�>���jU��y�D��p�aqx����e���}�A���zk�2�`)�4�,�&�2\0J�b~@ӳ_�\r��K����P[)�:�d+��92LQ�,��NO�����>�.�������˳4���]2�����X/��*���i�S�8\\��(�w�\'���@���Fmh\Z�	҃9aN�rE�豚�dD�8���J.-W�s��RdѸ����\\�]��<ƎQ<6R��k�&� �2i\0�\"��fd�!��0����Q��5�s�����ke΅dYPU�����2P��c�A��ʹT���L�~ءX���>.&�y�4(썓u���r}��)�o��{yd��U({���s�+��F�S��q�B_X?\0=\0]k�Y/��=�q\Z��Z��%!*�j�\0�X��]��{�D��� gI����ة�Y,�TP��D��v�q�,���eq�����dz�L2,o	2t��d�pu0������0A��*ǫ3�*�DP�̜+U�NN`�`��.}�>MV�E���\Zf�f�}��eg�J����u�e��C��?E%;5��jc���A�#\n �zdN��ց��r���:)��.���\0�@�D2s��C��� �E?��\"�E�4	-\03����}`�sd��yu��2�1���[D��V��.C6G�\\�����]�T���\Z��2�NK&�t桬�5`T�E_����Ij�K{c%G���%�{\Z��a^����d1B��![�K�e���Z��b��Z�\"a�B���Hw<�ѽ5V���\\]�،�\\�H,H�m%�:�d8�)d�b:c�[���qG���.���!�y\0n&��mU�};�[��i2j�9sK��ͤg�-8w[FM�	�N�2^-�*�Z�T���W\n���0*;[`*�J���	,��	����v��Z�c���������.�s� ��	�Y��V ���d��Ҙ�a,o�\'m��K��h�4��hNL�7&��[[�A\0�^΅��Ф�L�̍�btc��O���D\00�L���L�\'c��\rX�gy�1��Tw�Μ�O���֧B��k��^q-Cl��;������J���_��\ZT����J�U�j2���&�k@��uؗ.U� �e����ż�6��M���և�ML����R����<����+tc��G�t8$��	��0��duLNɷ�j��4	��\r�3]�)sd��-�[1]�]b,ǜJ���qh��r�xU9\n֒�JT�.+���2\0�����i�1~UD��t2=�եW�Tǫ�������W�J���T̝k����Xۃ�Z��,k-�7_�C[{��I��4C���3����	Y��\"��Fk���;\0oE�@w�]�j\'̉��:�L�(�\\(���8V]��O0�\0�p0z$�5��l�z�t]rOz�O��\'MJFkl��gX����ӓ$*�U#ǫ˯T�I���*Ιj�	���&��]1Hs�z1���c�C�)�\r������u��XY3S��Y꾒̰�ݰO�+��\0�6�E���xNfs��b6���%1�l���֠kY9���K���i�I�����)h��H�㸑�(���Ӓ>~��) ��40)���S�@��F%Ss���6�KI��F\\�����䨊� C���o�q��_�k���͠Lu^�;�#E;���2&�\Z ��MVs�J�1iz��J�4W����N=v[@ץ]��\Z�Ew\0�Z��G����XD=~�·J��Ƥ%-��A-�jL�yљ�a�t�x�kQ�K�d�>F2Չ69|s6�֩�,aOX�+��c��i}�r�j����}�1�w/%�qRg������D[�\0��j.\0%����d�Z6�\'jе2���>���F��eV/a��He�Z���H/�DP�T#�T����y	j�Zc�\\��$��/L��e���+֌�x���;�������5}3V�~5���)��_J�_^I�������\0��(�5Vl.F[mq,	\Z�\\cxM�T	���H���³������韣=�s���wRa� )@��Wg)C���9r�M7�c�Ij\r���{f�X��ۼ�OlmGa�j�r~x���(%�y�M꒱�߅�����kG�2~#�[�K-��	t��fF[�Zg�Fv�q��Y�V�s�	������X������;\nD���ϵS��t>�II��T&}>��ȹrΜ�Z�Z���+xh��χ5���#/������\Z\\�\'��S��-�+��}����k>M�P�06Dk�q��`Y����\nl2[y�v3n�+���6x|������[��D�,��V�N~���L&��\ZT��\'̉s+�.^͕s�X3�h��wt��m2�]���n�����2crv�}ފ��G��p�]��v՟��V�F,�����T��2>Y~�}-��5�n�V�Y�dZ_D�!��[���h�@���Y��������*~�qTU�X86�l�I��c�2!Y�ũI���m�h��a������Bmr��:7����0�������	2o*R��P��M�q�m��s����Un�����D��U:6z��]�O�|3&Ij�L�z�S�!��&(���-w����٭K�Zx�%��jo��k`&��f���O�����w�9��.���8Ʋ}��̱s�s�P%4)CE���W\\�����M�\\ӱ`�`ya�T}���	���sJv6XQ�C�z�����)�h�m���/>���F�M��4��Q&%i�4�5x����[�	.Q��=�<�$+�J�W�mjc�{�F�a^���(J�n��_p����ex�?�~/�����g���.~\'��c�X�P��c�X9f�*�Fۯ������s�2Cl��>g�ٯ[\rv��1g�ER^ʿJJ����ۿ�2�H�9�B���7�lUZ�umSx�*�ˏ۔�hS���\n>Q6_�&�T�U��l��`z��/��[d��mY�1�V?Fr��\n[mp�(W�7��	ۦ����;���3��:�j�~?�����w�;���M�&���F�J7�l��)�aSfk�M��6�{585^g�T\Z-o�n�#/���dy���^�����bJ��b���k�C��\rٿ�l���h�<��\n�`(2������R��m>�{˦쉇6�ܞ�|�eS!0֦�x���a�6��\Z��H�*��eﾯ��4�_�&�T��Z}���6��>�){4ܦ���o���7�n���!W�͆�?/6d�j���3\\\r�:Qu`�tKJ�4c�\'������?���f��v5�\Z2�mi�V�ِ��!ǆ��5�n��z�!w�e�<�rw�h��u�!_���}�\Z���;�,�a��-��ϐ��.C�N�\r�\\�?����086Zd�Y�![퉆,G��1��������Ƙ�+�뤩A���b������8�-�rN&01!+J�x �,a��:����`���\\��0���1������g<~e���c���y�1ql#o��	P,¿���S済<�B��	hd?���a������w��9�\'v��h~��O+�i��\n�?��R����\0\0\0\0IEND�B`�','�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0�\0\0\0}\0\0\0�Y~]\0\0\0sBIT|d�\0\0\0	pHYs\0\0\0\0��~�\0\0\0tEXtSoftware\0Adobe Fireworks CS6輲�\0\0\0prVWx��y T����4#˝!�S�2��+*��VK����$I{����E�^��D/JiQIO�#Z��RT�2�s�a�Ko���?~�o��=��sϷ���;g\n��^�0&��~E�7IP�qE@��$qI@��\n��oT$H�Za\0��\"nQ������$~Q�(	�E|�]�W�#)�������3����\n���/��\'>�����$.,�$.�>�r,���<h��l\' QH���H޶���s�l�a=,��������b��`8 �}�	K�-ve!�`��{�``i���\Z�\r��x�3��+�ؿL�?N���\Zi8�5��8�!�׹�\ZY�3���\"d$k 4;	ڂ����õ�i[�I�5���c�%`#OրI?�B돂]��<��a����2�.�ᐎI� I/-kX����(k�|��\Z��\Z��G��y��;�߹�2�� \r��xȻS/���o\0�����@;��w����FC k0�@*��5H������f��4������l\\� z��\"Y�d\"k����)��3���b�Eb�\\�������DQ�k����9�R�hTj_*����iɸ��@R@!j���X��Je��ɜBѣJ(ʢЈ��)P�Q�F�t*JӠ�h��B��R���0����S�wQO���X8V���`*�(UE�>!ׄ�	��0���(J�@���إ�z@Yd�{!�+��5�mA: !$&�Q���H�*\r�z\"Epݙ��\nP*Āɚ`]\0 ��ë��އN��+Q�g�F ZJ�,�y��	�\0C�:	���Ĕ�/W��4�KC��h�P2�}� \rHG|$P��,��\0��l����!�y(v��aR�:A\0]N��Ir$5�9XP��ڛ�/�������|��E��/|,@��M�.�����t�*���x�/�?U�0�pouH��1bdl��Ut�0�_�c��f��9��\Z\n�Pl4P0/E����E-��Z_8��+���EQX��R�	�r�10�hH�aC�F\0Xc����g�cli\"1�u������:wPb#�s�Ǉ�����9��;S�s��9ʈ�9��\n�b�]0C�����>H�h�	�3�Mda�ه�s�j@\0b�]*�\n�#���2��w�y@}��!����]\'��Y1���w\Z��?��$W��Sh=��H(E��0\n⌄T�=�Ρv�_�c�ꛘ�t\\���Duoe���jt�<O�C��$�b\"��Fu���ڄ���mx�{��V�0��,:Q��k����ɿ�����,􅥁<!-&�?�<�+Bc�ɢ��M-�a�).����_����u�!��\nQ�pt�?�\Z��#�jJ�/�6ĉ��H?J��`�Q�$J�8�~H�<KO��N\ZN��2O�:	�wv����Ta�v0	��z&(ӷ�iڈl*[F��Hx<�]�������	ݟH�\"^0)v�\",����苌�6���\\�n��\\3�E锸)�@���?���\\H499H���P�E�bD���Xb�w�D��D��#����_��ir<ػMGڂF2oe���}�������?���0�B�B+� 4�\"q�ퟋ߆���jb��A�E���\'���#�Ǭ\\��{^��%�H���xCԄ*\"�٪��2�{�2�# ���B�����	��\\Ú�1b�^ʟ7\'C�$<KMa[���h�o	�7�����o\r]��}��?�n\'\"���C\\��+���	����o���Gt2ɀ9���\0=2p�h�!�rq�2�����`\0X�h�G����m��x\nw��N�a3M����1��a�aW�C����9dC	އW9`\0l�p�dhQ�t�\nl\n�X�\"t-CH�1U�����}<�|�	���<�?�xa�`��R�L-��!vBp���!�CɐM��Z�;$?�i��C:��M�a�e�#�����?h`�drpv\r��\rau�<1�8Z:T�q\0�$΁g\Z��22D0z���?�#L=<.�2���BP��c\0�^����\\\\� \nƀ��柘0���`,8��c�gb�o�W*�0�*�����^Y���\0y�<�Ag20`b_�\"�^<A���ď�0�\"�4(:�Z(D�(�����^��/���a����$>�t	&hh,m��E�%�6���g�C���2��<�0�\"v�3/�\n����X�JV!#�� d!!X�k���?R�?0Q<��blD��S) _��-�%\\i��\'�c�K��܋%@`���cu�s�&�#���\'~�P>��a`	Y*E�z7~}���\'g$2�\r\Z�b�:�u�\'����bc��� 2qd�]�Y�߬�2�DƙH~Ip��ғ�F�՟Q=g�Q!4Q�G����f�!ȣ0�a�!r)�^$wE������ڨ6��� }�\0�}��l�K���_2����-����sg�G�B�\Z�U��(P��5���9~b�߹R�й��)k l��\nW�d\r~x��\0&	W�d\r�������Gt�@�??��A�?�k�}!nlߵ�e\r��1�5�b�*��)�&���K�C�������T>����?����8~�^�i���d���֨�X���,��n�7��g;��������rk�_f}G���v���U�3���mߜK�Iiz-����|�%r�c̝w��A5�q,���`粃�Que�����ִkx|�S��̋�����OR\n��m���u��>�����VVu�4�j����S=	��yQ{���Tey̶�-l�QT�hs˹}�m����{��	��Y��Z{���z����l�R�Wݳ���Om\'����L�k{����غ�Ҋ��H��u�K�\'���b�R�]jN�%�������\\lxn�G^�\"����mֻ#G��6���89m9�8[�$�L>z�����F�L=*��#��6����짟C�~����؜�5��Ȼ�j��~��5�o��FS���.eo{����S�¬��y��g�3�\ZW�e�UE���,sn�a�UW��������M��-�u�vۨ��<�I���7X,���z��U�M�ɫ��j�ޕ�j\Zg�i��{\\<T�(R���~�c�(�>S�1�����[j����s���?)n��:����-��ヾm���5��{qܲ��k�G9����c���H��-�����!�9#j纯Ҵ�-ߓ�Ҟ�k������Fw�\');�4��V*��3���Ys�W�`c�A��Nʌ�#|�7��?:�����99��.�Y��c.�.���zߠt�\'@;o��d��L����������G�b���on�5(�fq�Ԍ��5~=�Fy�D37nYt�-�eΎq4w�C�\Z\r�:��G�,ǩ�Yn���kD:7��+u<�cp��[�W��bk���g����y��˗���:`FJ^E����SOZm���dr�r�\Z�f��M�>�ܚ�˻������S�o����8�خyi��Н�۟O�rxřo����}V�|t<;祳����ꆇ�ȱ���Z�>���sÇ��[��=,~���m��gjOnr~$dx����G\\��8\"0�fDQNU1H\\�n�B^e����#��nY�;-5��;s��u\Z�~�Ʊ�.W�(�����ʣWN�QQz�58ùp����O?��wt>����ѮO۝�ݰ8}��~��<�=�Ѭ���<��KfI|�#c3\Z2��>85݅}[w�/C���M��nu��衚5AT�S�\n��EzN�-�����&ʔrAS���s�wXn��K�kr����Pe��x��?�Z���>n��r�P�#>h�����gh�iݚ=���<��r`�B�!�?\"n-L>df��*é�퓏Us7Mw#+iA��3�Y��Bk���K�����m.W�_G5�>������Y�{��/��,��}uw���KnqWb�}L�O���N7Lժ��NO#�}�Ą+N�����>��]I]�������ХOX۪-�����1&������Ir](ͻ���͇krb�6��z��1�X���\"�������g[��>9O��7�-A�g��әSu�cc��^��<�$;�=���}xԞE�7���h���/�w��P�Ӝj�n��I��4(�ݫ*q\rRY�ۛå��Ws]Z\Z��Q�4TZf;���`M��Y\r���T�\Z����{�~}��IKN�|��=֯l]��=uF\\Mdz��T��щ#��[����8Q���W�\n�27��%�3����\Zw`��ͣ�|.\\��6�і��CεU��l|�a��i��0;�cZi�^�E�oϘ�~cE˅�����{&m�\\�:���P����cV<>�f������G\n��+oMQ�T�V�φ�V�o�����~(�>����v4���;����%w7�S�]Զ9�¥�dV�|���0��%�ϴ�)�kv�ڼ�Қ�8Y�N�K,ٯ�ᆊ�Wg�]m�s�7�lV��3K�F��6�~���������͠��o?퍷[I�����V��)x�f�k��e��Z;��n�+�i����W���5U)�k�C���ļF7���KZJ4�\\d0�*��|2y�Š���V�������6e��,�fɝۧd)�x}�9�y$����W5�Z�&Ԗ=��{�@]�8p����ū�����6P�5E�>�u~�O4�l$�~\n�|���nt����&�37�Էd��M�;zPth����ҽ��\n�ͱG�ء�C�=9m�\"x@�i;6Ǻ{-���c�ãŦ5!-y�N{�nP�wۇ����%�>q�ݕU��*�1�99ˎϿv�����ηJ���\0��\ng���]3��|���������rnL��4M���0���uU�ό�Pm���/�3\"�ǫ|�uY!�4k�i���*�{zkػU�#������֎�vJ�|AS�GT�Ö�~^1nz��3�-?.���=�6I��Ռ��A��1�?��\'���������	��m��>�����Z�J|ܒ71�����ߩ�`<5J�\"�|����c&�\ZlŚ�:�lC�K�b�C�oo�Ŏp��`Y��)�_��_�67��1�Aӭ������~t�̉�NS\'\n	{���ɬ?�2bxYE��<����9��kV��;ӄ���7�\'��\"��cE�Q�����m�O�[\\��N�5�M�^�K�؅a3�|ǝ9��k��U�������)ӡG�]rJ��U�ge�_�H�I��L����M�O8���8��^���k�]f���F�7�r<�u�d�RH�nr駟X��L�r3��?��~¶�㪙ӏ5	�ԃ��n�3+�J�9Z�h�s���;��w���5W.Z��|�?��4j��.1>�U���X�t�����\0�����W��\0\0\0HmkBF����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0)�3�\0\09mkTSx��]Ys�Ɩ��Ʊ%۲�L�y�U�L�S|�|IQRBII�r^\\ Hؚز��ė��>}Nwci6VRe�J�$��w�ӧ���nf�ó��\Z�ʹ�;hǚ�oGg��f�^S\rN{m�oh�����tK\r�F�Lӭ`�;�g\r=O���=r	��^�f�꓏���r�l(c�S�*}e���ogʇ�����${��M���=S�\"G|��1\\r���CzlL���9�^�I�}������xа����شz���+6�#v��.���nu�э�>��Z#�sD�>\Zқ����`zy�R�αv6sH��e:�6]�Q\'�N��2�!CF�Vv��+��g��i]�왬3mA̴���1�lO� �|Vޓ}W�4�b3��F�b�y	l�l<�bc���L\n�K�q)<�ǡ�8���;��8Y�?&�Y.������|\"����HX�0]��8���ne��@S�,4Ns�+��mK �[tϐ�qH1H[(�g��\0}�\00}�ʀ|�&�&�R+�R���ʭ�U�[��ܦa�a�O�_ �����ے�v�6��`�l��gɖ��z2\'a��G��2�sǲ�Uz�y��A��`�t>W`\rW�u2u�gV�F�Ш\Z�B�RhT\n�Z��!4��5��!���5U���YH�ӈ(�3�d�W�����L�S���#J��Qڒ��\\y����g!dQ�,�����Un�/��iԒ�Ea�(L.�ɥ0%��\'�\"Bĺ���5���z��*&f��>�I���\09f�}��.�dA�H��!�\"dR�L\Z�Y<�+dCy�<\",���i����T\Z��ԚJ}�<�P�\n�+��7�����l���)�wa���tS~$�?)��4Ll5�����fy��R)��\0I?+zN:^�SK�aq��MJc�-Ѝ	���(r�%�5�&�}�b�U�7\"�gpT Ӣ\0ic��x�O�yY�\nl��[�c8�̧G����y+Ԫ: {�(��l�5��g�\ro��~`�&��J�NC`1��Ȋ���>����=L��������z�c�0mʹ��vT~��&��1A�7��,e�\\��03&fa�Y]([<s�LMy$�����G�$}������� ��nc@�O�|�!�F@�Q��d�_¿JC\\�ٓ8f��a����\Z�z�NqF�(�6-,�!��_���\\c����b���Ysʜ:�j�\r�,�7�%�锲�ho7B���|A[Z%6K�f\"T�Xd�a^\n%�2t\\6�˦p�T���/c_e�1��9���q�#���G�+d1�O�$�,ؖ���u\"�*rW�T]VA�a����9	L��٤p���S]�/M�&�^)c�(+\0�g\0j��8qTi��x�aj3Pm3�=ñN��JUc`�e�_IV�@���oS��e�U��ER2rWhIޣ=7���t�1�}t��3w�=�?��v��(�j�9�E�cNid���h���U�C�S���tF�O���3���Wp�o���\Z�� ��o;�x>LX���\'L��˩#*!�!Xbe��cIM$M��A�!�{�l@5[��R?��WWF��s)n:��.���9S�3� �)z�ϡ�y���cz�h?�ˀ�/��_���0>� f8�U�H�#�Ƈy��nY��|�<�5��!�n���Z���v5��\Z�1��4�5T#��6m\n���b��<�c��PmTD��`���\n�j�	�qTS�mʙ�bu+ m2�O=�:����~К_��a��]aL\n�\n!�UE�0@��i2GӤ�\Z�[[dY*�R�����l<�l]V	���CE�eG����?͝.:��8��A҄�ab�u:��q��ˁ��0�A\0�8�)��5���5��S�0�\r2c��Yl�R;%���Q��JIKgü[��\'Ͽ�cX�k��8�Ţxݑ��0<Z\"�<�7x��*���2dA<�ͦ֖�����3���\"�K�\0\r��,���>k��\n��(+O{�Z��|l�w�+>��d��eR�$�n	m)�2i��J���d����[[*�6��E���[r�_ʶ4V����K����Y\"�K|(i��w��.ݎ�&/��\ZL\'6������}�>��a�.���l4\r���N����6l���f~�-4��`�(�:3���:�$H�\'|�s�r,��P߾�|��>�ѱ��2�D�q33\'� �����b�\Z2L=G��7Y<�d���q��.[g�\\����g�7(���%i��=�1əci��I�K�7��N��2�ПL�\';!P����F���g ��x�Â�K���M�J��#�P��=�&�����cBF~�%e}����,1#n��X�\"�l,���T��&�MT��@�Iơ%	��P:�yE�#�dH��ϙ�hbT*��;�|�>u����DXt��?��Z�b��2-_	xR�Me�T[)d/B����ʦG�Y����J�X~ԕ���\"A�h��r��I�y^�PE�>�s�R�i4�d�ٗJ�<�)��{r��xqrk�mf>����lX�v����HﱒFM�s��\"�v�<�V|.L�v��i��#����|l���02��n�{³��+[�.o�K��q�e��g�1�^&-��C��4�2�܊!�&��1R\ZC�*Q��h��WG�X�\0b��kH�fp�7�/�\'�3g�)żW1�\\�8&ۯ�e͛N�/�*>&\"ذf~(���$I�t{��Y7>�G؆��;��0��#\\0�#y����إ�ѥ�ۥ���\"�u<d0���is\nMЍGq�Cl�/DlB��{NR�T�N�D���G/H�p�	v�b�)\\���cC�`�=�\"�|����+�Q�^��|���\Z,]�Ċ����.��b���7�O]�:Z�K�]�7B$H�����3�<\"h$�0�9*��\Z�J>�&_�m1�\r@yhȢ����Jv�I�c�֥�uk�V �f(�0@\0H�,�����$c_5���fM�$��\nSo6A2�ǜ8f!��i5e+P6r�\\\\\0,*����~���\Z�,J5�&�D룻��f��,�÷��l�F�%Z�&�D�\"0�N�h�I��jDs(ќ�h���m��g��J/�<ed�q�{D5�6)I�5I+��!#i�b/�Z?�Tvʠ��\Z�<J.�&Wrm�A!H]J��=b<��F�	%ݤ&��5N�,^��$e{5�M)Ѧ5����Ѱ`l�~d|�Iƾj�)�DǞ��4U�J)�G-��q�I��j��X�ڎ������/3�kD	��I�*��<ƭ��N�x���� �YC�(MU�qFQ_Z�e1�Ǹ(�зu��q{%�_8���Ґ~�e�ꮛ��\'��;�♙h/�Fw�8��].Ǒ4,��RYrVo[�E]5�d՗���j�fC\'��!F���ɯ�^��ݩ�jɝ\r+��#�����w��7`8x��#n0e�j6L[D�Eb<q</\'�k{�T���3�\'co2Oѻ��Se�Q%��ٗ#���l�NcsGuTpw�ln����9����؜�8��4��t���&�@}�y+)�V�7���0\\gM���ܻ����F��?��L��nl�����p�=���M��\'���)j�ֺ�w�\r�Cn��F�aAՏ�\ZT��4�sNE���T牗u���I��C0���u����7�����V�c�p����F�}�j8\"EʈpX�m�)#bB���?��q�&����u��/�%|�0f̋ճ�R�Tg��w[7Y�aJ�\',i�R���	��5��T]����JC���&\Z=��n�É�����\\g�y��n�f�ۍ\r�N�����N�|�����?��>����x�٫fv�ÛY���\"ج*\\����:l�K�A����o\n�X��gʮ��u��tz�{W=�{�M�>�zV4]�ؗ����P,�]�%D6p���MZ�O��S|9�;�.�:�s<�2<�H��/�$>C��������M�u�!b��!VW^�7��a��	g����#iag=T�����=�ӻ�d��e2w�9_���/<�>�`��؟x�g���%�	�J�x���Y\'��W;P:���Qf�`�M�\n����;�	���	���!�\Zd���G6ȧF��� q׍�#�P0�36cG��ixDC��掎�(���,l�8H�.ഏ2՛2n��J8s�S�&�3�3�h��g�YǄ��Gi��{@��楠��q���EW��n�ZK�V<�	��Az�E�hE.\Z��Nzt��O��.ȶ8w�����3v��1=��Ĩ�K��\r�����~@�ZC�\Z���_���k\r}�4t̫�5t��k\r�Ukh����FCo2\r�;R�wr�w$�ut��k�5�h����FGs/:��k\r]k�ZC�\Zڨ5�������e���ڹ�εv�����S���_;ô���w��s���r�l��yʹ�Dn�ʻZg�:��u��&:���[�Ύdq�]W��\Z���ߚ��+��+�j\r]k�oECוw�GCוw���u�����ʻ����ʻZC�\Z�[��u�����u�]��k��-i����i���εv��s]y�nڹC�Z��WQ��9Z��m�(Q[/�s�%�%��TL�7!�s�\"1�\\$J�+� m&���C�ǦٰF���\n�����c�� X+�=�O�	^)�{�3`���5[��X6�����f�ۜ{�m[���]�D1~��b���L�¾�.ܡ�EW�j��ݪ}QC�;龨�Eu��~y�O\"}J4t����r�3ĥ�е���\Zz���֭5�ת��F�T�d��g	�Q7��~��mO���.[`19�Q@N\Z��$�s�1�7x3�S�A�1��Y,[`Ix����2n��{���}@9J\\My	s�@q�\'��P>��Hϳm��3���c�`�#R�ƽ%�\\���\'�}�����?��$Ǐ�&�G>A�O�F�h?9�C��\'��y�v�o��	9>��I�����GE�p�f������K����yfE߫����fuO>AM<\\W]�fYJs�(�$>!�tB��k����m�����Z�Wp��]\0��k���\'��A��)3��4��q\Z��	���:,m}�	���|B�<���Vz+��6�y��t.�W��X��T�rAB\\J�+�����$9��R��w�Gs����i֚������_���Q%�ccə��\r�q�p�f��$�}���kk.\Zv���\"G��?!���O��q_\"fW�e��-��N�Z��9�-�g���ٚ����U�;=�_�.��4M�3e=StV�gJ�S�3e�eKr�w\n{�b�3��$�%�����X�ok��bglI{�<Gֿ\rr$H�G�)r��yd�.��ŏ��V�$�->���)�TI{*�a׼H��\"�#�5�����c��\Z3L��_S\r��\Zڬ5t��k\r��i�4m��k�\r��}���^>t2���Q��Ptb���I9��2��������i�\ro�}C� ڦ[�\n_��Qn�~M�X�5s�Y�Uo�k���r��C|\rƵ��	J��y�&�<�_m���<n�I��a�m!{i�>H�7�FIeY݇�Y>�6<ٗP����os�n����̰�cǱ�B�������y�؜Jƺ�?�F&�v��r�2z%i��\\�6��T~�r@|��mfCw�ٟa�cm�d� �@932iMq�K���b�	�C�|L󨲉=:g�崊g}\"/k@T�����8��{�H	�����mɄ�$�߇������୑}>��f�r��Z�{;xG�ec��!0�#1�|������J5����c�者���Xd_�^����{+�=����+�#yr!��G�%i�~J=���u�	��pc\'<W��y�8�p���w�\r��l���O}�x�H��u`���Ve���\Zf�����|���?<?��+���!N��z��5\n���އM�o���Y�`��Q�h�),���\ZL�o<�3oK�dQ$�\rI�m�ҩ�+�᝶��������\Z�]�ٸ?Q~W`M֏kk}�lfH�f�tDf͍Qv@�l���(7>�v:Fp����t,�y����Z��3�Z܇�b���C�\'����iXC�c��fY���9���]w%}�X���u]��P�A\\�v4ʣ���Q^�N�,��3r�s�C�l���ԂGɏz�GP.q�U�Y;e혹�v,�*�X$�e��YחimkN�> O�I��ȸ��A���I���0vp�q�5�S�kkǘ����c���9:�Z��m=Dѫ��iTH�_F�k֊���RA��y��\nq����\Z8k>�~�Ë�5Ԅ3��\Z�/S�\n}~�@=߰�oȩ��߯׎�������}��	�.�����ZH;+��b��:�a�Ƶ��p���K�b6[������	�|�\Zhz�����đ��`����H��Q��z��Hr�Ͱ��y,eFyV�A5�1�տH���&Fh0����륟�ıQ�\0/���T�q\\�d�F�e���zs:�Y%|Qt��mU}�}�ʋ/���l�/���j��0\'��\Z��2�52��P�6G��y��Df��J$G������֞�&���huZŽS��~��E����t��i��~��5�2�Lp�j�V�QL��\'��;S��ϐ��}�h<�8UE�h��&\rB�VD5�2\n>m�,�����<�I�<F�Xg~4���s���y_���W�ڞ[ܠ\\��=�|�>����8�Xԟ����	Fn�s�}�����tr�i����\n]g~K���UЩ���pH�������ͬ���|_�A7��R��o���r	u�?�g?I�3��g亣�4�]l��g3��\Z�ʹ�;��!�ݷO�Sh��i�fFo��?�؞����f��O�q�`������z�)F�)F��Yß�>�\"�N�˹P�{ڿ�uG���\0�~���� ����}���o����{��C����N�!�̔ف��j�K������<�M���@���qI�K��r�[l���A���=���@ӡMo�h������~���kt�Qe�A�	��\'�X��v���C��h��#gBs����wO����м�����`��F��*4����}�\0����*��Pc��Z�ݣ67��aw���9�тv��i���ڭ����_�ÛY�;�g�K+�����:f_��)B��u�A�����J�&���	�?���o��8P�5�*���������?�Q� \Z�\0t�-xm*�=J�7�ҽ�7D�݃\r\'���פKc�\Z.�=A����6^�s���J؅K����=�W�: ���s�S�� #Eס�yft�u���Z�{�~�ao���������]��E���9t���(�s}B��IJy��:��6Ɛ�\Z���������J��M�ߥ1���.a[އ��$�j%II����O�q���`3$�t�e�h�C~�I��F�\'���b��:؃�ί�]{�}PB�Wp��!\Z��!\n]��I\'D�����!5\r�X3��(Ҧf�^��N�{}ЁYxDA��j:�ݡ?k��`xWo���؉>�Њ,����%�J�9g����Ѣ���\'���x�۴�����1u�V�\0z�:<m�:�i\rw�!��7Ҵ�F�֯ش���ul\rИ���N��\n�uD7�.o�A���ֈ^}4�79�ף����zED�X#\\H\Z.�96��j`�:]�64A!d�C���9G?�g���8�?Y%fڂ�i���c��>>�e�5gacRl�بRl</������Pl�4:�I�q)<.�ǡ�8\'��\n���p�Z�at���K1\0_0\0�iyt����q0ɅM��B�-���iYh\n��.W:Bۖ@8��!m�>b��PI��)�|�q[p�+�R,5�\\��\Z^E�u��m\ZFOF��MX�u~[r[���F�l��a� �,�R�=BO�$�2���U��X��J� :�7x6�������\n�N��̊Ш\Z�B�RhT\n�J�QB�<�&�À�fi�,��5U���YH���m��-N��qz&�)RX�%m�(mIQb�<Fwn��(BE�Z���Y�˽t\Z�d8cQ�,\n�Kar)L�`�	�i��}o�V��Ǧ(X��:��6)@�? �̰o�� �,��!�\"dR�L��I> k\"���p�l(�!��a��/��Μ�\'Ri�Rk2(�qV�,BY*|���,���CatQj�n�\"8]-��CI��\r[�(�k�Y���T�$*@�ϊ�������pXmh���etcB�s<��tI6AͲ	zE_�dU���)#�dZ m,����#/KP�-�yb\'����T�\0�<o��ZU@8�\rz��fZs�|��p�v����f]I�i,&xY�4���G�s|0��I�֜��E�VzX��A�v8h���	xi�\'ELP�\r�<K�,W�2̌�Y�vV�Ϝ2SS�>�5�?\Z$ �,��-\'��u}����\r�7ʍ�%� K��eP\Z�*Ξ\\�1�������ճt�3�FA��ia1A���=L�\Z�@��67ç-͚S��!T�l�d��9 ,�O���D{�bv�����f��C���\"��;�K��� \\�.�˦p�.��2U��e��6f�?�{�8�pD�S�(�y��,��ɑD��2^:ߡNDQ�@�ʑ��*�>�?W�#\'��P8�Ntzcp���IѤ�+eLe�}�Z,/NU��j2�d��T�Lc�p����R���B�+,�?S>K�z�mV���?���jִHJF�\n-�{���[<#��>fc�Ϧ\nF/�����h[Q��sR�<ǜ��-QѼ�{�����F�Y��&F)�4a�g)�9��r�\Z��e5�A���v�%�|��,��O.��S�SGTBLC��ʘXǒ��W��$1Mb^FE�\\�X���+#��7��O��	�˙c�	�=���P�<Vj�1=G��e�����/����	�zt\Z��J)6c��s��ݲ<�-7�2yk��;B<6D�2g��1l�2jt)5c4�;h�j�FSm�D����\'y��F��ڨ�j!=��!�R�L����T۔3���,V(@�d�z�t$�����5�0Џ�`q��B����a�G�d��I�5<�-��ȲT�j�%@�x@ٺ�.�5F�q�pG����?͝.:��8��A҄�ab�u:��q��ˁ��0�A\0�8�)��5]{��5�o�x��E������,6�����@Ȩ�������a�-\n�ѓ�_�1�U��PZ�bQ��HSn-a�<�fX�q� �f�\nk��X�e����I���%y\0��Gr�eR�5�g��q���=L-~R>\n6�.���*��0�,�bh\'1tK@hK�P�AH�U�%8&+�uƆ�\Z�R鵙�-�4t�b\\�*������%��E1��D֗�P�dl��]��M^�5�NlP�ͽ#����}*���0]�	��fZ���N����6l���f~�-4��`�(�:3���:�$H�\'|�s�r,��P߾�|���k�K�	/�Kt73s�b(Ki�!��!��s�|���M�lo��x�q&�e\n��|�|���m]����c!��9�VJa�Ժ�y�i9��(.�\r�ɔz2X��\r�5���jD����՗�mR|͉>��3�&�����cBF~�%e}����,1#n��X�\"�l,���T��&�MT��@�Iơ%	��P:�yE�#�dH��ϙ�hbT*��;�|�>u����DX�/����:�\'�i�J��Z\'m*Ӥ�J!{Z�X�V6=*��/�V����G�	�E[$E�� LrΛ𢐆*��!���jM��$sξT��yOa$ݓ������[�l3���LE�<`â��.��0DzOׅ��e��@r�j�Y+>&C�|��4�����|>6σ�i�B��=�8�2w\n����/YfǑ��B�%Ƭz��\\����p>��Cp+��_�$��LHi�~�DA~����W^b�<�I�!)��!v���p��ϜUxD:��^�trQ/�.����t�exV�1��5�C^�$$I�|�������n��n<��b~!b��s���Z�t�%��=zA��PLX�s[O�2ԕ����y.W��{E��������,�D��c+��vi|[���}����*^��\"�� A�ǌtm����Z��䋽!T _|O5��|FM�\n��b�����k�D�\nI%;��1��Rº5a+v3�K \0$n����w���\ZMJ@�&���_��	}� ��cN\n���մ��(�_..\0��lx�o?I�^�j��Um�����b��}����OR�W#Z��Qm�u��%�8�����Ո�P�95�*�)#�.����^�y��$;�$��j$mR�6k�V �CF���^�#�~8��\"�Aqk5ry�\\^M�\n���B��0��G{�x>�S�tJ�IM�,�k��4.Z�h�I��jD�R�Mk�-���a�0(�������}��S���=	�	�A� E��%b��#�?��_��\Z�C���/c��_F◙�5��äxn}��kr�\0�]��FZg�!e�����8��\n�!�e1�Ǹ(�зu��q{%�_8���Ґ~�e�ꮛ��\'��;�♙h/�Fw�8��].Ǒ4,��RYrVo[�E]5�d՗���j�fC\'��!F���ɯ�^��ݩ�jɝ\r+��#�����w��7��\"�Ϩ�#n0e�j6L[D�Eb<q</\'�k{�T���3�\'co2Oѻ��Se�Q%��ٗ#���l�NcsGuTpw�ln����9����؜�8��4��t���&�@}�y+)�V�7���0\\gM���ܻ����F��?��L��nl�����p�=���M��\'���)j�ֺ�w�\r�Cn��F�aAՏ�\ZT��4�sNE���T牗u���I��C0���u����7�����V�c�p����F�}�j8\"EʈpX�m�)#bB���?��q�&����u��/�%|�0f̋ճ�R�Tg��w[7Y�aJ�\',i�R���	��5��T]����JC���&\Z=��n�É�����\\g�y��n�f{�S�k�*X#\rY��u��?��>����x�٫f�W�೪p���eg\\,y�/���J�(���b��_V�+�.h����X�9��Ͱ�\0N��� O%��S|9�;�.�:�s<�2<�H��/�$>C��������\r_�-\"7D��W=���+��3�c��4�,Z���}$-쬇��K��ܓ�����2]�2�;�������xe0�\n~�O��3�K�����.��4���⺁{m|�5��\Z�4w��W\\k�~Y_<N�a�\r��[gU��1�G��`\nglƎ|����<���{3�G!��8�da#�Ab?t�}���ޔqK�VC�r5A����F�M<�:&t�?J��W�����PP]t���F��Dl�#o��czx;����+��u�����p?�z��k\r]k�YC۵��w\Z:�U�\Z��е���5�Vk�{��7�����;��;�:��ѵ���u�Y��{����ѵ��5t���j\rm�\Z��h�LCò��yk�\\k�Z;��Yĩ��믝aZ�y�;�ڹ��_�v�j��f�Y\"�u�]��k�}�:[[�]WޭBgG���ή+�j\r]k�oMCוw�OCוw���5�����ʻ����ʻZG�:����u�����u�]��k\r��i����h���εv���s]yw��s]yWk�Z;ڹ��[7��!G�bx��(R����6q���ѹ���o*&����9K��l.��j�6gg�![�c�lX#��t��H��y����Rj��������=�0K���-TS,��@�gq��m�=�-�mq�.z���A]1��u�`a_T�P����E���nվ�!�t_T�:Op�<�\'�>%\Z:��h����Rk�ZC�G\r���Q��\Z�k��O#}�L2u���ۨ�{?��\'�Yw�-���( \'\r�g�������ǩ����,�-�$�Tg���T�gh�>�%�����9|��G(�|����6A��I��E��)j��L.P��U����\nq��W؃ȟ��Y���J���#���h#L����!���y�<\nG;�7�Ʉ���Gʤ`��v�#��U�d3�s|���%m�C��<���U�_�Q�:��������}�,��^��M��]:!~�5��vU���}|K�?��+��{�.\0Z˵�]���� �a����u�H�8\ra��\\EE����>����s>!�	��H�\n���T��k|:�+]�d��O*B� �?.%���s�wԃf��~^)��;ᣋ�k�C�4k͇^ȇ�|��/��w�Y娒䱱�������m�\\3�\0�`��>���5��5\r;��q�#�����U�@�/����2K��~��S-}���ɳ�F�l���	R����Ǝ/~��g��晲�):��3��)홲�%��;��E1��dwϒ�MD��q�з5�?Y�3��=L�#��9��#�9H�<2NQ��G�c+V�ď�R[���i��=��0�k^�JB��K�R��1�����ӯ���B\rm�\Z��е���4t���ڵ��׾A�Y/:UMè�X(�1�g���as��	h{����׆����Mm�-�n�/���(7K�&�x,�9�,����5��f9��!�����%�ļc�y�����Pz�C�$~�ߌ����_$�i�����C�,�q��K��dc��9r7A�bbf�Ì����M!w��M�u��<VlN%c�|�r#�T;[�c��4@�k�NC*?g9 ���6��;���0ұ6R�f�O�����&�8ť�����ۡD>�yT�����rZų>���5 *��G�}�ƽU��H���dB�c���ql�}�{}���>�G3�t�GU-ҽ�#�1�����m�w���	�n`���\ZG�^��1qt�B��u,���^/P�G何���g��?���<��f��#ϒ�\\?���OҺʇ�]��1��+{�kU8�Q���6ޏ���G�$T~�:0�O\\��\\FK\r3Z���y>������X��?���vz=J�\Z�P�A��&׷�R�,R0Q���A4�V�@\r&ķ������A�(�̆��6_��̕���N�؃I��z�]}����lܟ(�+�&�ǵ��M63��3E:����(; ]6Frc�c;#8��W�~:��<��Qe���E-�CV�v����!�[�P�4�!�1�B�,M�Ɯ�������t,�PBܺ.�{�� ��J;\Z�����(�q���A���9Έ�{��\n�Uj����G�x�#(�8��ଝ�v�\\c;�G�d,���2����˴�5�y�����yd\\��}ڎ����s|;8�̸�\Z�)򋊵�c�y�I�k��1�i�^�Vz�������4*$�/��5kŊ�DUi�~P�x�5��eX�u޴�h3@6�G������@��D�ژ�r��\"�f��������0EPMf�A��H�	cM�G�l6ļ�z�g61d��֒�>f!L�Yy��nƪk�L��Eљ�5Ƶ>����_�ѹ!_�w�!�	�����G����z�a@i\r��a�>΢\'�@�]�Y�\'�\r-i[����huZ���@�G��~]tj�LOg�Y�F�+^��ᯌ6ܶ�L�<�I����g,��>��o0#���Έ*��q�{I��D�\Z8�6�BZ�U�d�$E#�S��\0����9}� �P���g��J�v�������Sy�xĈ��H�ɞG\'�S���8�y�)����\'�@IQY͍���&���UЩ�b���N��G���?�>@�9_�sf�Y�D��[�2�����+�W%�W%��J��W���uIV�2��)3�庘���O�i!=�X�3�A�4��p��k-�^Zxk^$�p����Z�����U�t�����~�cZo��[B�ٟ�OR�:����u�n����L\'�Fg3-�:x�`@�����`tں��? �BSN����כ��>9�Q�}֎���둧��t�f\rb�8r4:�.�B��i�f�=�#�{h�=|��9��8���a\\�?b�	Z����f����_;l��2SrdN؃���/���f�C��6}8�{\0�/C8�%�.�9���2l!��>\"z���`[oxM�6�!R�=<��v�Cx��7C�����!\\dDC�\Z6`�?��b�ഋǞb�G�9���^�{J.�G��͌|���\0�6\ZmT�!m�\'�c��s4T鵆\Zku�\Z�����N��\r�)<��[\'xL��\\�n��������zݑ?S_Z��O�ؖ�1��O����t����{G��:�+.:��@\"��=������k*������$��~ƀ{�AP�oa9l�P��],�q` �P��8�!$���!2����d@����[\n]&yс�I��!:��/��t���h�]�h�Wؾ�#����\r{�Q�~p�n?=��4)��)͡�-@y�4���*oNR�\Z\r�	�w�1�?�!�������J��M�ߥ1���.��v��T�H�X�7�=k݌�{u@8��=R����_s��V�i��˿���A,Д0�vt����B�2w�`�C|���>���+8�x���x���?�d[P�絚\0\0\0�mkBSx�]N��0����\0���Æ�\Z����	WM�����- �2�����*5X�|D�Z�\Z=�f��Lc��(�F?\n������h�Ҷ��B�L�r��Gp�od�g�d/�e>�f\n9��]�W��A\Z�\\��\\L�f�[xi�lϣ���Ts1�H	�Q�l�H�اE����t����(S�AZ���_Y �X\0\0<�mkBT����\0,[\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}XU��6�رbnn4�.*\" �1\Z�-�\ZŮ�wQ����{���;�T�Л��{�}�5{����K\"I�=�^����g��5k�Zkf� ցt��@:Ё���]1���1���-����rO�c�%<�/FC@������O4�@����\\sy�D�-_�����M�ҿ��4\Z�G���HT�K�d{�T~����ߠm��?�r(��PG�Z#P{c��_�ω�\Z,��u�/��S�N�v�3I����p�k�D��|J���La����؁����>bx$�&�Ψ6�,3)Tj�#9�j��\"�m˙�\"oQ����i���9@���P!�,�q(�T@��x4hA����{GD������Cɀz\ZOi<gW�N�v�,)��NP}}r̾�K\r�(�7hs�#�����H�{�8�%��}3M�U���cLs��D<%�0��˂�:��D���\'�W���ɗ��M�$H4�Xha���F���MG ��Zt�\"O{��Q����o{�<����!7`\"\Z���H��5ѽ���4��hpC��P��ˢ����Nr}�>!5����3t���;a׃HAh��\Z���h���A�Hh\"�����CY�Q�/��;C_����[�[9�.3�x]J���3u����$��aб���ߡ�s ���」�\'l0��F�� �iH�E{��\"����.�I5�K6��-���0��y���~������������(\rV@�[\'^�PK򀍉�]�b�9\n�$Q�9eҨ�\Z�\n�ѨӓF��x��ʼȱY�嬴:y������]t�C�ze).3Q�ۗhN���F|N�ѽ���Y\ni:cQ�9��P��4&��f�נpm��97嬓�l%ƭ-v��.��u�}P�M��+�܏*��hq��u�HԺuA��P䘏D��䛍B��dYI\"ߐd��84��:�1��6O�f^M:O2�su������9��̗�	��8xBc�1Ʉ���ܳ3\Zܻ���/2-G!W\"�h�h�.�B�����;�H�3u�����������\0�	Ih!{���Иh����|��^�}�)w�y�Pyg<�hG��F�HCQ?K����F����h$]�][h4�<hq����	O)�\Z�v��e=\n5���AO2픾�(M��t� ��@V�v{�D�wTx�F�Oo���O\'�o����֔���as�{D��8�k�B����h�����>���~����ދ��?���}��8ډ��>�-ܕ��{a[\\����)<��Y��N���t�F��h�{�HiB)<���r�T�}�Oe#�vYy,o���.n+b�I��et�8��߀\"ƅ�{�)9I�I�Q�b��&��ɢ�g<�]�ć��g�L�J���c ��\'�Ik$j�c��\\�5ȳ[�<�U�5׎������\n�֫���]�?���P:B6�eP\\>��t�{{>o��*d9�声,���r(.݊ʠ|�m�X}��l\nˡ�L�����q�x��Hr�Z���+�d�mt������EM����އ��pm�t��(��\'n����#3�Q��y���Qqsa�oG���(�>U\Z�Qt����Pru8�)���(���pT�P�-\n��JB!�%W�����}!�b�nP:-\n�����Q�ŗ�Gi�)M�&_��SyT~%�WP�y����k��n\rC��P�_�\'�o�B��(6��C��΋��ŝD���\Zk�r��G^�O;� 7�Hv}ّ���!9�K�\ns���&Ov�}�c�O�rS�\'�THDݓ|j���+�����z��R��5�l��ܾ60�Q�G7�X�}��H��8���3��ڃk>����� �+!Ð�uAhAW�AHҢ{c�Z��>��h���k�Od�(O\n]�tM����/^s�)]\"��S8+ˌ/3ń�Ce�S\\*�De��B�o5Y�c��r(ՐE��x�9�w�@�����7�BkDM�?��G]��j����|�l�Մubf\\S�س��0�`��n͐#+�Ǟ����b��W��a9�����q�/�8b�h�&pW�����SZ��E�%e:<*�[�\"ɀ\0�w���h>x�	-��_�I�y��ˉ\',M[>fs6���+�|O�����-��M��/>\rW�[z�i�N����q���ֹ9����[�=y��Y��+J� ǒ䃶4��$Ѩ1��G�T[�,����{ᑢ����:�]\'����}��ʸ\Z�.���촼a���b��U|y�(�ӚgpAN�����m�\r���.���Sm��a���d.�֋�;�T�+�OZ`� �s�\\��c��mA�?�9[c��}�l�3^�d��KJWC4|B���<?�������y ?V����u��T�����^���oae1?�Ӡ�{߶�N������4,��/-\\��>��ȴ\Z�\"]�j��9i4ʍ&�?�=*{�I��i�G�v��`��eb3�c��*nEz5�9����UYkr��:��N.18,��Ě��ln���LZ��\'�Dm�~>5���-�&�i���g=��\nTD�S\'��\Z]y�z��n^�:\n�����5RX5�1��\Z�N�c��W���|�F�V�w���س3��ڛ�O2;�1�1~���+�nD?���b���sV�|^|Z��ŏ�z~O�l��Ƅ\'���v�l�a��-�f��`{e\r�<H�;*jZ��o�6�y2�MILJsn����y��K/UY4����W�CH_߁q�w�	6��R�H�:�+�kQ<��r���V+-��F=uC�=K~^ǡ�4㷕��\09w�,x9r�!����Qxw�_�Ґ5(����Q\Z�9ዐ���/DV�Z�]������[���5ȿ����!?De�+Q���,�r��Ѕ�\\�����\\����Pz�;�w%չ���Q�ȋXCu,}��&��ad���#����癗4&\Z}�y���6\'}RC\r$jo}�,�h�rd����������Ѯ��Jb��*n���}zi�N�ۊ��nx�Fc��۪p�0�������Zj�t*}԰H_��I�cv�?��Yo�)O�q�R��udr��1eQYQ�bEq�bMq�b!��W�X\\�@1�$\\1�0J� ;R�8��r�3r#��+�,�P,)����勢<��}��R��\n+�P,ϊR,-��<�O�ss#���s���(���A�F)Q�J\n�ˣzs�+��ޟ⣼->� [�Y����c�y��!L�e������\Z�.H7\Z�&�q��f6�Ȧ�]#C�DM����������W�t����i��PC7o�$ǘK����R�2���CԷgn��:2�����Mwe>9�ѕ�x��)&�<h>�@]���gѕ0&=����0��4��Q���iުi���6w�s�ɢJW�삑(Лz>\"萨��{���I�-��ާX?G�P�n��z�(I�M��[;$Z���&�qfS�C��\nG����۟���\\{ÝKyb�&Y�m���\'G�⢯9�|��>��\rΊ����p��ƹ�A�O���uW�{�`�t��/P�7MZ�P�3�>�Ee�I����^���3�a��z�b�Ӈ��iY&x�k-���j���>at�u��1k���h��3�lu��������pȩ՟-�y�q��&^ގ��7�ZjJn׿$��z���ifp���]����z�/	/I?�t��ƣY_\Z�\Z�D��t��� �Tѷ�=`��V��&Lr����Oϩ��a���d� !�[���6�D������⩜E����\'{���j<�����^���f@�\r;�O�E�L�����������n��ً_����<�Ѩ0`~�(4���d�@�����Ǯ�H��yn#�mo${w�q�J<�Xk\Z�(*�NL��8&�����ہ��x��h����~�/h,义�PW���h����J��苺�x�j��u��g�8�gn�ޗ�9�t�4ơAo�tFOѶ\'�v��C<5%�(?p\Z�y�p-����Y���E��(�L1u[;��`o��6�{���lO�c�GH��B��h��X��H!��B����_�])͑0����Q�g\'[\rB����c{��e`i�U����_�Gea�ž\nx�ʯ-�u�\\�OQ�-��a�6������n��D�2����-�C,������B!m`�q�\'�wc{���Չ���u��bK7-��K5�6)�m�R�l3]�7i��������U_���g�죹hA�#�!xBz[�n��\\�A(2�F�&����U�5��\'��;�4]�d�l�|���t\Zv�K�����}q|�N����[�l7=�z��L���=���g{��;�\n�ݲT��΅�X0�f���\rP���x�9��$��~3�c/7L���s>`xf��?S�� }뇉ΓP��1�&�Lr W0ez����\r�atNV�4{��k��v�ȓ-����6Tʄ݄m�I����X��;��+\\}�d�Z�j��W��-�{���O�ej��*�����t�:���R]�0Q�0dz�\\5L�u��U��\\���?�IT�6}����6�/�3����*K�:7����ׅ��&�E�C��3��ơ�h���5��\'v9����\\�\n�z��P�G�������?��\'(��\'��>� �c?�S����h����U�g��ޥV����ۆl:�Hh�5_�z��λ�@�*�=yj�|����:���|���kx�`�#�&Huً�χ_��87.�w�%	{�a��ht�ւ�>��OQi(��qd����*��v��mU\Zw�}�{��~>B�}������>����~ߓ�_��ŏ@��!�Q\ZY\n�u&�Q�|���������k:X;�\Z$iL�P}\n�� ?� �G��GcL�hݗ����$zS�SX�����{��X��9��*��(?ޱXk����Z���vO&;�F��ǜ�ɯ�l��@WM��P�7g�DM��K�{�Jҗ K�\'�K���x�/���>�9��}��ӣ�cGIF�l?��8��O�F�}B��@t%���_\\�����:���=�Fw�E�&�K���N��!Џ�v��>�B���\Z_��8��X��q����Or�T��2��w/ErI�������3H���	��\'���kd������Dw*��Ǡ�@Z\'\'��f��ŭJRD�k���m�o��:T��;�{�ia��Z�+J_��!1���>�\'�������2�j���c׎}��]`�u����C� ӽ���4�z�Q���<#Ks��.�+6+\Z}�n��Ҏ��ֶq�otx�p���\r$��?9����4&)��*��*�=��Я���1���.��\0�}�O�:!�e*H����r�I0�� j��_�k0�\'��x��O���)�ݷ}��c��	�.�u����\"y�Џ��/�M�h����>��t�ԛ}�Kk�ޏ�k\'߄\\76��Ҽ��t��Lߐ!Y3�˞�m����4��y�M&z	��N��q]v�أ1���4X[���.�s�6X~�^���\n�����~�O�J�!G_\n�t$��/\rS��2�k{����\\g�(Ns(��)�z���������y�)�~�y�c��~��w&vSy�B�r_��_�{��gb};���$�e��ɶ���&?���t{���\\�u���{�y��v�5���S$w���s����hL��9����f��:�~Y����U(Lq�O�n\r�����LK��?)���ݱ�2��f�*ɐ,�u��!�GI�:�)���n����<����`\Z��2Lf�c�B��\n�OA����\r3M�6���Z�l^ᶹ��=��c��\"��J��2�\'+Vκ�MX�o�l��:�@��*k/�#�C������Iݕ�L����ƃ�􅄿m�0Y�-��>��om�!��F��k�@�.������/HjU�e��!^���r}����0����hm_��韞��m���K�?�^{^-qlљ���U�V�s��S�t7\Z;���a^��q���=�����Q�Ԯu���烱`�:�� }��*?�0�l�I�I���=���%�l)Lw�������Z�;�܉��B��H�������H��S��i�t���z������<��R�sDsƻ���m�@��\\����*�V-0�a��k����`�t*�$�����L~0��	�~�5KG��5:kԞ����$c嗗0�3٥����ك��ڟ�G�K����6^V�<�y�����H�+r�<=i�j\rG������?�(�� K��|_���r������j>f��iz�x|;��>��C|_���s��iz\'��o�7������w�&>��[�M�dv�)N���`ݮ�����=nO�xx=hV�H�hf��Xb����O����Tsfzz̽��w���9O��u>ݹw�����:���Q�5�z2�>���i�~�o�ת4�:�[���vS��~9�H���0�_����YL���ڐ�z�׳�l�q]�a�����Nv��o�7e�,���C�a阓͘���z�\r�K�n�\\���S���U���J\n1�;��y�S̟��\0\'זN�~@��;u\0	SK[a�@O|;s{����!��sTJ�AS��`yYQ�4{��7\n%��\"�����������cj�=��y�t�����UL��ȶ�����d{�`���VZwjG}[o���a�\'G1�+�������G����r��;S�BJ���ӅI�ض@_��҇�/�S�������칾�<qP��;ϻ�p��%�\Z<��֟/5�z\0��&��������I�������?���l�6[N����[l��ڤ������x�ɇ���#;��.����{Կ���_��~�}ZAd��t������~mv;�L��j�*�KS��u6ŉ��lV��0��ܚG��̇}��9g������铖�)��~�Z�.h%Q�H�o�9��$��B��$��~+j��_�k��7�R�����n�E��q����9�&�:q���qW ӷ�V���B�\Zw]0����f���)^;n�fސ����������e5��.)�[�v��-�s�z�rOIl٫��41��N(p�����0��/?9s�l�κ!��P��4���O���s�>G�6�.�Hn����Q�����5�UI�����1?�!��&���j<���e���o&J�T7&gIf�=Í�I�g��׺F��R�K���R�����T�lv�%����?��G6E��5dJm�5nO�\'Y\\�|2o�\Z&�8����\\�����\0�։]U,M�x���vu�lE4����od3�rI�k���?9h^� �����w҂�?��ɐ���O�W��0r���O��7�?��U�f�>G����7����e��7�,��U�EcaJo���¯!1=����tU}5c��S�g���~5�)�1M��������]�@��҄�*?(�\\�|fӽv���&N�.�\n�~�w�{��V�Q�#��F��,,�>�?f�2�^��樂C8O�7�ͯ�2=�����G�gÒ���R���̺��۹�n���\r`z�lw��m3nN�	��:�m�s�� ]o/��e�z�^;Y	&�T��b7�mߤwʺy��� �e�v���ɦ�t=��7vX\0ڵ/H���@���\r\Z�Ĺ�?�����ӓB�푨0��·��\'������6樂Y!��\"��in?���?���S���n�����IX8Zc?b{B�����[L���A:a���f�����W�ݾ���]-���}�k���$��?�?0������V���o	1Mx�J��`�����\0�S(�sL����1g�kn�ko�Ix��\n��ɋ���\Z;!�y0�R��y����}���E���\'F^;�����\rhU����������� ���7���Cݎn�&���hvݙ���ߞ����kOٶw�\n�S��f�C0�����l��a�fж���A��tk�/��B~�o`B)�5.E��4�:��A~͘�E4��%��X�-������n���$��m��n������7c\\:!�q0�H�7i�����~�g>�	�vD�Y��[{ v;��*Mh���0>j[���������]�U�C��\n�nms����a�Ɋ�����\"��Q�T�B�х��(��������֑H�ObkɝT�XR�h���7�T���_b�T�<~~��9Mb�/����&��ʛ�oɑm�c�J۵��/��:��sQ��1������`�sTG���������v=��#N�P?���4���J��}���S&���GryJ_���_ʷ��!�y�uұ�s\0��q>\\���ݘ��)Kݓ�ʃ#��[�n�g��=�`���L�����3f�Hu���us��ן���ʼ����0�3�[����;0�ׁ��宍�sj��}&ak]!�&��ޯ���N(��\Z��U��eD�d��?A<�Lrt����(���/�_\'�m��P[?��p��������ע0��s��v�ߟI�c�Ȏ\\�p�����V���v�*�%��a��#әt�l-�d9�_$�����t��]�@�ƚB��P������W�������I�¢�?�gN�a��[�9uᾁ���	Y��QJ��@��\"�or�à�4�ુ*����>dd5�ų_|o}�� ��e/A���v\'{�t�I4Ȓ=��!���o�Z�+g݄t�]d$Y@6]�}�KF�X|�J`���;�����&/V�����T&��l7�������0�qη��>V�$	��t���0�+��{;i��U%�IQ.�8ߴ�^vBa��k4�}�g$�_���_��I��\"���B��A��+n���c��;��w���\"�s+v\0z�\'�%tV���D�*A���V��fwr[�N���_\'�?R�����{vU��߇E5�Y-w�t���q_J�r{}\'�؜ؙ�-c�hNm�uɆs�fԹ�e��O�^������1��F��8�\rR�N�$��H[��T1�݇��o��nX{��pK����7��\Z��hB�j=�ݾ��F#��b�}��o~�����������ek��y���>�>��wm���5��E�f�@�*���o�6Y��d���6��6\Z\nO�sа7��Zx����Co�|a��T{vG3����+t�\n���4F������ۋA9\r����\'�^�ļWo^�{���^KZ� ���2����J��a@�_�NY���O�}���o�z�s�V��\\W4�uB3�����O�1����W1�������{_H��e	�����肧�;`�l��`���W�����>�߁?@;�ra�\r�O���B^��h���}�?v�+��{�B�������[���i,�M�������*��F��m���������~�ܟ����3|�{���^-�,D�o�=c��)���z#	d�}���r��ܒ#މ�Zqfc����~6�Y��IB����z�}�����1K	�r����!�7i���B_�从n�����Q���awg��31��7�L~�k�6酗��l��Ü�cC���:9��\r�Y��F��Ϲ\'߳��}�q;=*��z0���5�ϧ\'zx�G	��z\r��a�K*�\"����a�nqQ�wm\rR��KU�G�X����+\r׸%�s>��朻	�������;:��-6��-型S���R��1�v�I����\\g���\Z������+\'�o&��B_Z>����*�^_C����ZP䪿M)�I���8��.a�6�76&������$i�ot��	��k`yq%l�n���09<�>�/�������[	��2������PyJp�޻0�Q��mX�\Zl��E�O/��e%�_P`uMy�����j	\'��0:�-,ί0J�td��;-�\Z�k�`r��]	���H�.+���Mca�d����0P�S�u0:����ήs���1N086�g����\nX�Z��k,¼�~I���m���.�h�����G=�>����5���C������,���6Ć����\"���e��{V0R�]cxv���pO��H!�.,���u�A��S��`��z�3u�y%�p���x�҈Gw]pS��74��F��z�����nv�����W_F�z�\n4�Ak�TD9��<^�{S��-���d���w�	}��0����X�(�[���O�y���ބ��,�j�,ˆ�E؜�^9)�q��^X�.Z;PV���94(<	s�F��zX�؂˛$��Xh�*���~	ׄ���6�.ӝ&���c�PM��G�_A��B�>������\'�.���)<n����uOm.m�\Zel1?���Æ��X��EA�oM4v�X�]5�����W�et�g�!�CY�!�?���X4�����n�o�<�,=*\0N�w�������{٤ۺ鮆Ƒ9r����Ė�a�g\\��u�2t~$���D]	�b�k�v_��6\Z�L߈��t�����59��_z�-�l�v��*tX{Gu�k��_!�Q�kSAa\Z4�����$Z[���X�wO@}u.��3��:O�kvp`��7���p׋�v�f�?��3���D��Z#QN���0�����RX��롷oV\\��Q��h]��z��V%����m��rmu���wv]�z�9E��ާ`tl&L�n�C_T�碾���뒬$X�Y��Aְ���Z��)8k������m�-��6?m�q}��\Zk��ǓC���nRqYY��յ�:����G���hs���u��̮������t��čݣa|~u�P���m%4�/Co�\\���d�ܼ8h�W�}x��5����^Yؓ���6�6������ϖ$�&��{�B=�\'O��D����_O�G\"��?[�E��m��j5�O��\'ͯ�̮nX.�\\�dHs��5��.���������(ʘ�����4���Q��Tm$E; \"������T��M���k	6�;a{]����?�����Kc�YE�x(t���1h�)�Ic��>�KÜ������I������ز��3��}�B��\"���o;���G}�1�1>:�OC��u�����<H���V�:����<�[�᤹���:\Zn~W���\n9�2�Q�9A��?�Nȵ�r������,��TDM�v����R�Y*So���MZ�\\nq`��h?cX_�Xe~m��ز��-Q�p��U�xN�+e�J9��p�;\0����\'���>[��\\_������������1�^�5ٕ̀�w��7���O�e�����b��V�-�\\��-S�\"��x�oπ��5D�\nিZ�h��^c6eD�}G�[3�xuϚ�|{;�Lnq�b�z��ڑ��c�oEf��:<1�Vo��-����]��I���ŭ}3j��(OzZS�k��o� �o3�Ie�B����zuF��Tk���7��9D��5m�G�3s�pe=Jғ`wc��,U~(0�+�O�2��G�-�����O��$���8��r��<̯,���Ȍ��ʼ4��-F��eE���j���뤩z,66����&��]r������p�Z���%��g��t���5��j	rՀť��>>w�΢���������7ו�i.yj�d�Ṱ��\ZN��Y�[FzǢS���OHJ\r|�z����M�˕�O�N�S/M�x�� z4&�C����sj�ϯ���>�����B�,(\r|����]��@%�Q`6\Zu��R�Ԗ�\Z�ZԴm�mon�\r��V�W�|�(���\\A\"�\'B�/��+���֒������Ɠ�m{�R�L��qc}�{�u����J����Q�f�6��Է�J}U����ٕ�Y�\Z{�N�id��o�}3�CB}�U��������ZjòV�[{�d�{_�:�=�.������k���C�V�Iu����-������&����(��学�K������I����J�{�Lc���Wd�z>��`������.�����<q��_��x��Q�̎/y}���ʢ,����@Lb�N�x��ζ}�v�q�` \n��Q�7M�?E�ö^n������{���!z�1.:��>2	%���zmRr�q���vB��j�#n�^�4@5>#�(�WO3��M3��L3�IG[h�w�<۳7I�Ļ&�^f��Cb���|�#���I���w���g�pFZ�Ñؼ����ub��%�pk��c�Q�qaV�q��*�����	ya��������xa����[�m\rcm4��t���������O�&�Zhb�}�o����	�FJi��̏�0����Ҽ��4pc|t�dz;�R_-��oۚ�)���\"�9���|��ӕA��hT��d��[������ ~����֣��c4��_����d�1��C�?eƲ�	N[�K߼u�;�~ �\nx�\ZuՁC9~gk���c煖8����P�?��!�hB���Α�ow�<���?>�\n���}C��?�]�Jz�c4��R�/�)�u05�]�u��ia���è��\'����ϟ������E�����c��Փ���!!|$������^�� �m�H<��A��(]ܺ�\\�%�X�)#[�9�H�%>]�*�X�3�P�3$W�:?_\\ (�3�wϬĚ�;�����׋�\'G�{{��;V����;9��;畉{<�wL��Nk[��GF�����]5w��/��X��M_\\`�)��.�,���(�e��)��y~U�Ÿ/ar���t�i����\\q��?{ׯ����k%����2���\'7G�R���^�x�T������iH�����ֳC�KCﻬ\rM\r\\\Z��:4�yB����t���)~���<V�\'���O\"8��OvYG�J���S��\'z����Q��w���roc�#�m��k*���V&n�LYW��Je�����e�)A[+9/�LZ^�췵2�eQe�@�2�eEe��7�����S��Wf;�z���3Q�Ӄ;�+�Υg���o;����G�0\Z�r��hd�{��|���i>wz剾���X�ziԸvF�_W�{�C�gwT��F�G/Թ�B�GO��r���q�M��D��(tG�G�G��p�*���@��\04x�D��7�=YxO*�WG�[w�x�%[�/\ZݻS9�Q���=P��M�}(�ʠ4uޝ��E�����/;[�][�7>���h��tE��TJ�Fg\Z�\'�Fs(R��	������E���[�z׏���9�%�s�?�G��՟�x���6��³6]�y�s?�<v���9;����ag��qMn<�ؙl\r�n~<�2�5��O��s۞��g�>��Z<������<�o/�?O�Ѿ�򽦲+h.ȶ���x�%�R�Q��\Z�\\�:ۨ�n���#�g� 3@���y�g���4;C����h�����as-]��f�ѽ%��/;s�}w�)�Ұ�7*�OS��I�7�_2��<��-�n�<g�~�����}��Ǌw[��>7>�ڱr�!�Z�ƣ�P��~,ZnҜo9?=:J�]�\"��#��7��<l\Z:s}����Ʊ��{�̩\'��z�\r���g���<���q�A/d;�B�c�Rx�@��=�oK�6GyJiȤ��^�u�\\W*��dQ|�}Od��\'q�P\\>�/�:�(���ϲbq|;���Ngq�;u��>A���\\I��P�3\r�cPO<�r��j�|����|L�;׋�Wq�*=�!�P��ǯO�_vB���MF2�c��/��=���G�AH���kc�~e2t#��h�_�4��ȸ4iW�\"M��_��ۣ�Av�#u��5��H\"��knI\"���i~��#���dhNe\r�2)�&�u��]���F����_�@K�7��H�s�k�B-�Q�1M�4߳��G\"�pr��-�#3�v����n�X�p3�g3r|e�҃?/�����do�\'��D<ו���KL�A��,��F��tT\Z�\Z�Y�3��\Z�9�5��\Z��Pg4��)��K�S|5�՛OC��J7uf3Pe4\r�TV��7�5$��t:Wk�V��l*cjͦ��dj�(��tTS>�٨2���_���kTP�J��Pj5�}��yҭQoR,V�$9o�����u���6���x������Y���?��BP����w\'��s ��=���z��l�Nȳ�J��2���%�pNId%����f$�u�LvMO�w}��\Z��\Z�B�$?��u���\\�)<&���K	�{�RKC��t�G�w]�S�~���H��Զ|ɬ���pJ�\Z �e�R�RBND�hN1�5uƽ{�����Q���q9~�^E�|^��yQ!l��Bשo��?C\r�e�����L�x�����b��\n\r�PmBy���1i�����ϡ��ZJ�$x���o�ko?M��_{D��쭬�O�w!{����N���&���;�::�������x{��푭r�2��#�/0���,���@�q�)��a�8ھ����&��7<��������p�כ�ZI0owպ�@��xTi�G����o%���D�Lx7�����]�x��\'{�6���<�j����^��l�G��V��(u�KI�jLD���1�f}Ľˢ~����e�E�G��Z�y_�K&���>�W�mk�n���y�Sa~�Z��Q`�d�ȡB[�H�W�M=m�������N��aV���8�.���9ݍ{ϝ�x��y�oK����(q����ֹ3��ݐ��r�G�\'��p�ơ����%c�\'Z�d}��u��1����C��bT�L�ε��x��w�N����Cqv*�T�y{,��H#Sk\"����o ��C�	���F�q(ҕ9o���M�?_~3���u���>���G�gwn��ů�<&Y_Ar�\r��;|�LY<���ۣ��� z�D�� �i�&�Ѩ%T�F������R\'S��}�nw��C���iq�^�/A����Lw{�˯ͱ�m�>�מ�Pb���r���ш�<�Źq.�_eY�B��lT\ZNA�Ք\'9&S�s�W�L�Y)�$󩨟����,�e(���h���vݏk��t�%�?tB��?�o\"��ے�ύ�M�Y��O������9Yn�JK܌��$� R���c�?[�\r��;�ѹƟ����^�xh��<f;\rG��,�h�B����l�r�~���6%d$��O�������l��ϳ��g[+G��Ti�E����ÚR͖�=xЮs�:1�w�������uk�W��xB2!ߵ2����H��r�Ϛ\nWm�1u�;���������@<_��1�p��o0��ƣVw�u\n���>t~׷Q:�a���2�m���2̤P�)�j��x�5�zcrr�UdbB�}>z>p��*��\"��LF��*�ƠY��M-H939��/�^gDL�<vn�$�ơR4���cI�[/�J�{ujkm�{���@�.�͂F푨��9J��ef�-U�N��w�;��4�\Z����QCz^��7�CN\r�-�u�:���c]9d�\n��_4�a�f\'v0�ߠ]�Ϡ&�N�Hf��\Zq��nK��J��+�6t��@:Ёt��@�z�?�[|�G\0\0\n�mkBT����\0W�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x�흍��8FSH\ZI!)$����FRHn��w��H�Y��x3��ꇤ�\0���s�a�a�a�axI�����Ǐ��\'U�{�������o��_����ھg�W9���������������o\'�GW\r{>~����J���l�����o߾�����������)*/���N�\\��ϱ�o��v�[iZ_ձa�JΝ�/:�����6�O�-���92b?�T�����l�k�%?������_2������1�B��s��Y��5�>�:�>\0�c=1������O�w��y�^�- �ڶ,��X��z\0����u��sM�#גU]�>H_���y�Y��v�!ۉ���_m�i�Ru��s�]�X�m�_g�)YY�)�m�]�y,���m� z�1��a�a�axE�ߓG�ק��o/�Y���\\�k�6��x����j��gH������������|�y��u��.�������\\���a�æ�M&�w����k�#�ϐ�$?�]�M�o��\\��Ⱦ,�/��ڥ���Q�@��~6s?)}��,� l�����gX #�v�Q���g���B�����ٙ^��u��の�uh��m?�}{]��.~�}�v_��J;�x�o�gJ���Y]�޳�@��.�)��oqC����?}�>@��X���ߘ�\'-�\0����(�W�?�����������������	�źv�Ɣ����O�ʙ�R������v�[K?[A}�?-�w����m�Ց�}<G�c�K���1}���u��x�LzަU��0�0�Pc[��<>�g\\=��c��}�M������ggg�����	�Ǆ����-B^��k_g?��F?���� ����v0||؎��=ǧH�P���g�s��/�hؑ�I\r�t��~�{����n^�}���Z���yD������5����X���Wv����O)�\"��c0��vY������Z��|~�_%/�,��p\\��ɹyΰ�Z�/���;/x����s��_��9?��P�ܯ5ݻ\\�[��y|�����č8������g\0����ʱL{�?�0�0�_�k3���>���������z�\Z���_������\\S��|<�)�b|�����7��a�a�axn.��t�a?l��^C��vk��ؽ#����~e���)��3<3^�����k�dl�c�&�jK+���o\"e��<.�ʞ`���^(3z�����u\n���l�+6���v��<���ï�\r�k7]�/l�c[`�O����n}���򚄫��G��뎱���zt��^v��2)?;Wm�r�5��o�c����Iz�?�����O��zx��{�&��!��e�z.����������\"ѯ����\r��1������Gg���{+ҏ���l�w<�=}Gݽ��Fƨ�^�)�����zIp�G�����K�\0�֜�{�{���e����G��12��ۭ��q���iumf��>�.����}�����~�a�?�0�0��[u���+�7�Svq�����֭�y΅�\n�?ނ��}���\ZX��w�Ŷ��v�?��ߩ��D�����Zۓ�-q/�?߳�=��<��~����#�������>���Fk���\"q��z�r��Q�o	9��r�,��n�Y[;��o�:)@�-`ק-�7��({��߯�S������@�µ����K��9���֠�ɸ�>:�n�3��\n_[�_*�mt�cm��C>�q��S���L���<�?�<n��ѯn!��>=���<�6�;��ǫ�s�����a�a�a�{�xˌ�\\�ފ���px�?0׋�#�5����z��я��c�]����x^��l�򼠕��(�f���:~����٣^l�i�n�5\Z9����W��~�\\;�?v�n������6e�r������UbS~v����^��UO7O(�|;+�S��G��4|?�f������*?�r���W~�2�o�N��ٟ���S�9��~d�a�����և���mH�6��m�X�[��J����~�s.��y����m�4ٶO���|B��d�����/������b5��ɿ�y����U�?�0�0�0�0�0�0�0�.�P�~�*��1@G\\⟿��K����rKX���s2�(ߥ�纎J���8���\'>�X@▼�Q��Q�\Zb���q��wx��b�)����_�K|���v� ��1��M�6ke�e-2Ǜ��5��9��?K^�E��~�9�ϱQﱮY��F�8��N?�~;:=J<������-�t\0�ĒyNA���g��C��	\\��N��X�K�s)\'�^K�g\\~��2}�6�}Գ����)��n]O��r�^���j�~�\"��{p���29w�6��/�.�z-v�:�+�����M{�W����JY��Z���굢`%��\r�Ҥl9����ힶ�կ�#O�Uz+��U�?;���s���d�~v��N���D��7*.Y�+v:�ye;��8�}�~���|���+ÑޅN�9����}�{Bƞ#t���x��խs�Xɿk��S�V��/��uJ=o�G���<�ջL\'����L��:�D]�6�j�f���gL��z�/�+ؽ[{����r��C�M�Y�q�~��[�{�y������y\Z	c�zA��������;��w���9��z�szW���H�����V�ax3�\0��� �%�\0\0\\imkBT����\0p�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}\\��?��������v��kwݍAH)�����ݍ�J#Hw	�H����3/�u����������a�=3s��}���a\0��[+n��i^t�E恼<w��;W��_��TM(�=����w����R��P�r|w@��fȏ?E1ǡ,�rR]������e�Z�N��@���? �������1N5w�|\nBԔ$���}P�j���(-�b�b�v�ౣ0�ڊ@��h��V�(��Š�^1x��U�Q�����\r��~+��B�.���wν��ߺ��пhVx������ce��s7�{.�f\Z<�\\\0�V���<��>�\\xn;z���K�E�������0^9��3�����\r��0h=z���A��B�K�l��U�.o��Y�R��TV�yQu�ߺ��i$��1>�{��Ҳj�P�$\nM>�1:lfA?b�e7z��n)��0�Z(����Pe,\0%xM��8<@=�m��Jͅ��j��vB�����칡�z>�h��f��Ue�kܲ��,��������	�N�(����:lso��4�A+��Q֟�� �0`���y��&��K��_b��� �s�O�R�YP�:\r��\'@��$�����������̃\nA�D��X�A�9/4؉���n� ��́[��.G��:�U�E�[Us�ԧ�^������Fl�91����>(��oA�^��{�k�)��]\0�m��.����{:��M���Q0�\nOÐ�G��x�	,0�/�wn�c#��u��P����BK�xh�ʜ�������j˥�؆�lx)>跚�6B����ro.�����B��\06e�Y$���Jǵ�g\'\nOhs��v!�;/4�B�]�*U�sQ��!^�w�Hx���X�\'q�e�>ܒ����G�{�۞���|�ˤA<�i����1��_%�y���2\Z�fB��,�pZ5��d+]�s<G;�e��������5��ϼu*]֡͝]h��\"�A����?_�<�	��y?b��`L��d�7�ԍ�H�8��<{�9x��X���Ĳ>���C�E3yg\0˟�Nx�:c��$,�`�2O�\'�s��a)4X-�N��o=v����U�_V���ˡ�l���w��m��G�m;͆����5� No�ĥ?���`8Sv;�X?n�}�1��߽x�y�i\"����{�x���FzF���\0���2��òn�>�3p���,r��C��(�]���ￕ���~�Y�l�޻����l����ŏv�j�?k�H�n\"������\rb�7HpNd�Θ!�Nt>����C�3�+�?��d��c]O�xN?��7�#�c����a��zBt\0^����y���񿑖�﫮/K��.+`�v\Z��#�V��ȐD=?Z��R8��c�Ap}�2�2����?�i�	Vd�`�tH����3ev������	�\Z�	]q�5�\r��؎�\'�#�w��f/������bk:�tJ7�� ��\'�|��o#��	յ����g�?@��\0�p���E\Z��(}M�;�9��v�&�����Ě���8&��wF�#>S�#t\n4�c�����u�E!s�J���=�S�@&�4tgNf���A��b���F����=�+uќ�_��q4;�?��S�L�B��,��;����=����H������/p�m�����c<����������݈}o3n�`�?���L�6���þ��(і�������W�T���W�\Zi�`%/<��v�yV��u9\nUIF\ZYQ��Z��ĝ��	������IЁ���e<����������\\�m�����b�=<�͇6[Q(s��������l\0㳧�w���x���B�_�2}�\'x�%�(J��O>e�0�Fe��P|R�w����Wh\';Ҭ��k\Z�T���Q�\"54�)B�ù���]0S7������|��M��gdD���v�<��B�5T�͆ΐ	�Q>�φ�v�=\'�w8S�7��Bm�xyE�azc�æ�J�����?c�,\"�h�2�/��\'�yW�t\Z�A�+�G���$�YȖ�c\"\Z}���g\r��-����Pm\'\nU���E�WC�����Ρ<LW(+��]u�+��R�m(���}cu���p��X{[㑢l��D�׍���oLbZaq��=�9A{�s�������ɦ�MK��\">Ǫ��k��rC�9�9����c��;$�L�����_�)rnGE���]M�ߺ��E#��t��}�v|+�_6S�ߙ���#O+]�A��RhuX\nu�?���Z�� �L_��NhsZ\0�6��.M>��M�ʮ����q�U4ӟj���%y\'�4�Lb��/�e���(���c�`\0X��,�,lS�XX��U>��߼�f,���?������z��I�P����L\Zi���Hb�EЏ��tY΂.{n趝C͹?�-�\ng1h�o���\'2�(χr�]Q�^�Ƌ�gޒ[Wח>��L��2����w���x��s9��\"!9�n����ܝO�q���Lsvq�}������}�Yɹ��\Z�j�j��J:W�l��X�\'��k�NQ�=xb�\0:�����hBP��r�Ők%���!HY�][=�1#)O�[��z\0c�hA���݂i:_Ҧ�Q��>�z���v��y��7�(iþ�G��[�L�7���}<Viic	)	�PT\\u���rѩ�y���l6M��27�������������{�^����C#��\\���k�|�=�AW�(��GCc0\'<������TLO�mHN��r;��?�����Y0����j����bÎ>�,��c����;�Y�=z�!��O^QA��;��`aI�r붣���ϼ��r��fQ����gj������q���\0�d���f���pC���ġuzg�(*6@��\"���c�L�v2�ޝ��˞��?�ع%nJm�]��ŵ�_�}j�*\n�v���L�h�f�:�J�~gcky駕?}<����~��-�׮^s��9���dwl�Y���=3�hX����ݱx_�����f�����q8\'�G?�E�PN|(�N��I����xf�������o���KM���SWTQlv�s�ѐS��l�/ͿAIIv��������xl����+9)9X�a�ݳe&AEŧ�ݗ���9!{�[��q��YTl�>��n#\0�h��SX�\'1�S��p�\\;�#<���b�p��G⽺�F��_��j�*�M�4���Y埖�T��U�1갱u0��n���RUS�}RD�%&�ʥk�\\U5�x���+�]SQW����[��dG�@��b趞-^B�:��� ���8��+�[\'�j�郾`����WP\",�ڑ��h����f�����򦟱��ڞw�q_�vA�V���Қ����j�l��PTR{Nءgg���n!Q	8--������q�o!}�~����o���9R�y�H�H�Ho���;�1-\0�w�:[*�B��\040��b�Ü����n\n�����	��M���e��/�{�r�������q\'��1���8��IC�����k��\'�n��X�wUV�BJV�O[��=����k�\\�/�̬��0��J�c�I�}����:�PBd��l�\0��?a��w���S\"r��#�&G��6��\"r����܇	X��eq���#=L���~,�D��F�:\n�\"r�\"r�.�����6����<R\'�9�0���\\��וcyearD��Ԉ����ʇ�a�ewJ��\"��i3��P��C�͐5ėC����x�Զ�d�{%��J\"M�D��yߖ���x��8�~=��(Gcgp��q�8��|�����<\"w���������|��M[/m^9{�8��O���	�d~������\'���ŅY&<��B���\n,ACc�U��Z]6B��\Zj��y=t;m����VC��&�tƭ�J�p\\����m%t9�o<�\n:p�ut���v,�r]\rΛ���Ѝ�;o����u+��i\r��u��崊����G,_-x�^�����G��5ً�3\Z?�9\nãvx����!��^�OW/f�sTx���k���\Z�]�?�T8.����f&�B�/t[`m�\Z��@���Țji��x.��~��B(3�\r�w��B�����e<Pi�\reV���\0Ϲ�xL��:+o.�R=<f�����\\�c.���Pn5�����C����A�	?��%3��T�l��\\(����K�����#�5����P�zR�qA�s���U߮*Y�_^3��0ô�4_ߒc����k�t���}XO~��YV\r��Ӄ/E�~].X�lP���^-��H�nM٪�ʒ��uM+���s��Jvj�ۊ�s��v����B��@+M\nȚu7>��	����q�x� ����;�q��c<�g��`vh�\Z?6���X6�:��k4p@u�x��O֣A�?;4��AE����c>��\r�J<����n�7T{�A����:��=	q`���L��1:�7h��<]�?�����-Ok?�u,�J3&~;�z�m,Ƭ�/���2zfj�H�-���%��M�=�w��8r��S/$Gє��Ȭ���O=[Ŏ*w�.��zWYj�bE�gu�=����F�m����\r�Ǆg�>�MN�ɹ�G}mT�XR�n��{�b!�����\r>�E1�0��i����ח���~zL%4?�:�ߵ3 b$��w>k�Ъ\Z���g�Y�W����M˻��h��Ŀ���\n�7�>�E����Vs>���\Z�y�4^D����y����@4s��k7�2ײ=���9dmY�F��I��zh}�V9�y-�s0��^���ه���O#�ĆSk ��؇b6�F�Ms.��pHG�ڒY�Er���!��w\ZR�ـ�/&kz��q��l����G�6Ke8�c�a���E���\'L��z�z\Z�����<��a�V��p����V��͕�,�X�d}nL�z�F�\r�֗~q!�Bۧ����0Y�(,�Ѱ��xxAtB4�J�p]��f�TZUp��~����b�KoO�X^����i;�\"Um����d{�j�/��Jk�͸O\'z�̋�WU=�qȞt�\09\Z�=m�#+�_�Va�ֵ+�c/�T���&�(�lZ�}�04ےgx�q�&kC�1r�ǵ�C��2��G0sedM;Y��;�Ν�Xw�O��o �^�3�\"�8� �U<�Y��C1ڳ�{�ul��ء\\],s��f;Ȗ�ϑu$�<ē$w2�nsʯ��%k������6����{�T��wy\\x����<V^$�Znq3�Ӿ\\xNzB��gpڋf��Em6�8�5;��\'��v��Mݨ������V�1���ț��hY������Fֽ�68i??L3^�����.7#m�����I愜f���\r4��#>fk�=RK~o�v�7vʣ���\nsͦI�?m}��m�J�9xe���7��/:O��G���_{/�u-tZσ^;Q��N�\0�zqc|4ބ1q��AZ�J�(O	VA�X�3r\"tıC_\'tEO��(vh�-�Q�١#vtFL�\'a�%b2�Ep�qvx��䜞hv茝�����OF��s�v2<=XGW��焎�;|��������0N��#��lÏ��P�Ui֟���V�+��\0�0F�F�+\Zc/w��!��b�.|CzyqCU��S���~4��y�*�u<�0�b���l��X]����n����e6j�z?��3�P<S���~�*���.��\\��h���z�<5�}���I����q�r{���H`�Uo��[z�\"��n������)[M5��܊&���\n��Q�����[ڡQ�	�^�l�\ZH�2�V��u�G�ѾG��\r�v�P�(��<��W\"�dޛ<k�2��S;����OK���Ԅ.H,\nؚ��Srq�z���%�;��L.�=����9��gsrQ����M�%a[���%�����+�4�PrQ������ũ�����q{���%��mO~�%�8��z�$�$�K.ߏ��M.�?�\\�3�A���|��4�@rq���� �6xgr�׺����?4�v}>^��^_K��s���Թ��7�qj猻��\\�ވ�P��K�sP��	.��\n;J_@ZC����9,,M�Qv\\���I�~�J��\"ݕ}Jy\'i6�m0����Z��3�U+,�){y�΁��Yep��셨�w|���F�a�$m�\\X�i;��B27�5`��zג�3߽��?i�lu��b������h�\\�f�9�R��۠�{0��e������oM�O}[�Z�3��MhǸ��M���ב��H({>�?�\n��)�Zj_�|�hNN�Һ�fNZ��zP.G�7p8��q8�<�p��� �*��)��`Gqx��sn�ǝ�z�p�|�� �í\r��\n8��8<��u���e�8ˁí��#�0�û�v�����.��\rQ鸏�8������n��YH���x�Q]���~�����iXb���њK�ΰJm��)�L�w��~���\\�5���t�}a�+�ۖⴋ�q8]\n���3��O��4\n/��,�Yd���0��/^o.�����A>���g\r��2��^��ױ4�4*	���?튄�����.j�k,Ԡ���~��������I;f�+u=�{�R��ܔ�)���km_ǲx�븢lxo;tc=>�?� �&�uv��o��鋠��q������$>^$�ێ��Ԥ���K�������>�h,�7��G�.jG��N�k���N��������@6�^����t��f\n�m\rp���L#�y.�(�vyO�EJ�tν7�p51ҍ��otj���0��\\�CVh���#�_�\\�_`��a�\Z���B��]k_؏^flGh��.E9Y���������t�����r8�o���7��o��T��r���q��GK�^9Py����I�A��𨻭Y;�m*�%5�,X��ME�%hr�=泡�N���/>�Z�F�?���\ZB��|��7�?\0��E��ޘ�x8�i���Y�y�M!<�p��6n���aBe��t����A+Է>�Q��-�7�u1��\nr�k[Թ�N��a3gYo�fwK8�_s>�&�Ɲ�+�.�����W¤C�������\n\\r�����]��~�w]�E32\n�(o�P���?�{�{���+)O릣~�#.Xs�6�ޟios�ࢻ��I~��i]^�������f9Q�|�𓃡�J����k����+s�\'?���~94�`�\\QC>���	�\"+��M��1��D�����g=\n2�O�e��MZ���U�t	*�;f�s^��nau!5t����\0���}����7\"���7߈tͬ��u���w\'F  ��bj�~�#����\'����oI�_���NI/���(����\Zeˤȅw~�~��$�.ZX]S��q\'zv_K���lȬJ�.�I�!���tg��I\0�s[\Z�\\��F���M��FI.��YԚi�l�3��$\n}s��_]xa j4��̵�dΤ/���a�~.�o��?����}	�X��f���ӻ^�>�C��j><�Y]����S1|G3����>RtML�����\'m�Lτ��3�k1�Z��@�Ɛ�(��Q�|IgGDAʉo����Ӧx~(�E�/}4hv^��O��=�����c$M��[�>�Cߖֻ�HB����̅.A�p��#��,�ށ���u��u4W|��C_��f�N�J�(<E��n)�^�$��ʙj���Y��[����PIn����A7]�l�җ�CX��I��د.��Q����\Za \\O��\ZȎ��*!�3_m6��\"c�V��{\Z��1�d���~�6�35N�P��?�k�=�nWrX��W響~�SS}󑒧���O��3-!8{BDS9��߿�d$�0ߌ�>�^_�?%$[��)kRMz���]J��}9_%3逿����5hB��oK�+\0U���E+�N\Z�6�5u�J�㼯�>�y��EW�<G[��F�ר�#�𥧵\ZJ�<��tcP~����f�A�-�Le7ٽV�mck�9��߻�x #9^u�;l��J������� 檜\'l��S����\\TD���і��_��H՟�h���m�_�߇~�zWY��o����C_�Hj��IKo]�柺}��x�໷����;�b�a�k?4�}���b����*{��\"�,�C�\0�#��˄G�:�������d�o���5F 9VxY�k�skO����u�z�\'��7�l�i�\'i୴񦈇o�����X�q�5X4���N��Z�������Q���@��b(\r��A#)�o0j佬�9�٬����bR٢r�\rx�`1��OR\n�҉�Z��H�l���\nc΁�d5���\0ɉq�b��b�����/�_)1��Df�#,�ޑ� 2N�&���隆4ݿ�<��������Ar�:�4Hr��o�Ѷ�;�|\0z���S�����JS}	�NF�%��\'>C�\0�?]�\n~n�Pc�}6��@�ĳ2�+7*��m�$�����\rY�L�V\r��x�*�\"\r�ǫ�>�k���9_���n(��CyW\0�I� ���[U�����a�4ǳ{l��?_���d-�\0�4�\Z�YD9���L�������w��J]��2�v,5���@r�\n�M�WQNs	Vri�Hm��Q��5ܾ�v��5��հߚ 1EX��u/�N�S���ɚ���Æ��x����{Y�\n���4=T�6l�م��Į��X)����$�(���bN���5���̀�l8,B]/��<0���{q�#nj�|���ٵv�����_��vA}}D��$�\"֧N�_b�\Z�OT\Z\\:E{�ܑ?�T�5�`�m�Ey&���.���u*��hX7㚲�Ű�ۘ9��[yP�\Z���`}خ�ț��`1�\nl�.p��v(�&PA�Aǹ�nΜ���\\��͚U���u��c�j�*��Wsi��8\"7�\r\'���\0;�5������J3�)��(�����pP&*RI�+\"����eϮ�����`�l5`C�ͩ��	Z�V�]\ZyX�I��l�����Ie���RF{���G���(9%u�b�+g���d6�~�3���� :����&���ʅ���B�I�	�u����;�xB���_j��HΏ���e�*���5�b�O�K;��7E=��B�\'1��=9�Y�����3_Y]��ޓ3�=�+�(�U)&�q�\r� \\jxoX>���a�B{oߪ�<��B#�Ɉ�x�IHh�Bh�6��Uw��]p��z6sk��h����C��A�\0�G���-�I�l������7��.\n{q�W�s��n�ve�R��r	��\\����6�n����^\0M��P�}ᣨw����u!�����Tj��B��~��&�C��L	D��������\r��\Z�~�q<�[KN�a�����D����)Z�gw[�	Y�ғ`�L]e\':eH�pb�R�TAh���}B&|1���u�ǁ\Z�ǡ|NT��h��Q�pd����o���#�nc��l�|C�G���T��\n�>�\0��M�]]~3W~���A~h��J�9З8�zgx_<kV�+7W���/�X�䀤)�L��7�q��T�UvJ�.���`�����_�u}:�$�@���ɴ�ĮJLTA������ٝÖB3\0޷j﵇�dL	�lX���:�g����MTMbXGs|v���ZxvH��ϟ���?ʨ��TU��;=��M�\"ݓ[/m�����SЗ$�O���Q��?�9���#�<9��z[E�־\"��PI�^���B����@(3��d�z��u*��7����=�wb��L{L��,�%���8���c���0��]|�������3:/1M�M����T���(= ����K���/�Bf�|��S�)��\"X��!|�v@��㕫/���_��/[��A������ ��1y��8�(�r��Ֆsҟ\r�-��f����{bOqK�fWf��$�?�Hb�\"���8�#�����Ёv;��B#M\0\Z<��Y��ǚU����2l��ĸ7�Xt�^��;�8�w������q�@��bȿ+�S˵������Yk�q>�{c�|��&��!:\Z�����}_$��x�.�T�C]��^eX��02�rhoT����kx�����qW7�u�Km�a���5�:z�S\'���M�W�]U��ۖ5���~�4��W\r�>A�w����UC�:��+��W����i:7��~��?�9(���S/4��@��Bx��O���%����a�O�8]�(\rV bD�9)[$�.�-6�B��~�竾�cD=E� l/�H�w��u/f�<�\"���q��3.c����Jl�<U��$9�s�gW���!׼e�e����L�2�,��Bc�=�w�(�.\'w��Q�OUg�s\n��KNT��������s\">�C٭v 0�\",�x�ҧ�l����ʯ�^`=�&𰝃%��X[b��2��}\'$M�F������1���C��|h��@������;�cX�b�\'{sX��ʺ]G���#�A��u�$����R;��x�*�L�#�+3}*��$FT(>\"i�Y�3l���\n�����e�~6��ɨ{�Q�OVs<����������KQ�E��r)R�%�vI�9A���K��{����bv��	,����E�M�.a��k����x����m|`�t}#���{ԯ��Gn��@�I&���Z|�rħb��ԙ�7^��]��4��??7�-x� �4[�B�/<�I���9����������oc��X)��2�n�D�t1���^���$����!6J�xu+I.�\0��i:3Lㆻ�\\�H-6/2@>?����AJ��Eݸ�K��쮿����ad��k�gb�?�1M���-cׄU߫�y�S��lnÚ�\n�x�\n\'b��0s3��[����\r�އ�B\n�Zj\n|,g񾄷��E�j�4�����+i���5H\\Iݓ�P�W�]�e�����Cɿ\nT;.�~���6P���q��s�}��+���B|�2���a�4s6J��%F�6�grۭ�֦Q1�D�����%�`!��J?��D��2ϏJ\Zn�H���ȹ;E�.A#�w/�8���*�?��;u����.�|�_��!yF!�ߢ�9c�+Pz��{���Eg�;4(���Q������8\\ط1R�6��k��\Z�}\'�m�\'���b-:^���H�(9Ex�*��\Z���=|�3�\r�y,@���L�I�B�����AL�=����ρ�\0Z�C�;�Q#�w�b��\0�?%忄��¢�w\'V�b�5�\\�$f>j�8�7kfj:�Xf|<��k�r��Q\'��FƏ]��=*�6M`�R��v�p���g��ņ��:Wr����eC�ϥ�xv�߲�錁�O��EZhr�̜��(��k�mVE��@�P��C��6_�v���ў#+o���A�M����F_b)��Y�_g�������ذH\r�8����D��>��wY(8:|ݔ��F��1��j_����0@�?ΚU���nʟ�Or�����2�}�^\n�,�c�t��}�ÿZ�p~`����ef����$�\Z3��2�d���ʰm��j��_^{\"算;y�P5i��8N���OSD������﨟\r;�R�eJ��|K�E��\"�/�o��<Qe(���ţ���қ[��k�s/Vӫ,���0��Zqfވ�9�~�K�y�����[��|�-�w��nq�Q�C��?\'�;��\n,��c����ա��O�������I�oF���xps���)�\'n�+l�u+\r�K�ҋ�8˦+4�4�f9�\'1����9�1�\"�OTx�m�2d��>�|�:+Jz�tۙ��\"ս����%�F����\0xQ?�X��>.�S�Q�Q������#��p�.�3C]���3ϩ>�g��6���\\@}>qNU[-���w��ֿ\r;�_���L�f�<3��zE�M��������GŮ��9���*�1 S\'1�T9f^��[M�a�cBW���\nu��?��C3�^�/7�2�E������u���O�9�;�(��&K�\ZD�\r�G��M�<��M�\Zav�\"+j����W�O\"�\0�*�:U�S��R?��/�ψ���ׁw$�cU�9:\"�c�a�\rƹ]�����m��yU���C�,�P����U��#�)�>�Z���Fcן\Z��]+�{�cRX�_�iW���}��0���E������Sq�(�ՒD�(��e�$�X$W(Ll�M�a�C�=/�}�&\Z�{sC?�?���0֬r?n�����t�g���+�+��엇�C��*L��1;mh���B�̜5�W\"7�ߎe\\*T�m1�y�4纉�៾�I�ݴ\0v�_C�)�!��A�#:^\ZVp��.�a�[�r|��i��HG�N���X	�3#$Xԇ�˒��%\rG�߄I��/ȮE�7Qy�IC>-b ����YW���;���\Z\ZҰmưl\n�9\r�\'\'j3s�dL	ϑ�\Z�K���I�\\D���@���Tmj>��Ca��Y���~���j-\r�����D3��<��6��?R��N{Jϐ~R��T��i{��R�]���>�j0�=�3��$yp�	R�~p��Ry-j�Td�t���ܡ�Y��~�����2T�E�C��^|���Ќ�d���`������%FJ��v��h�g�V��7J\Z���$7��rT�o	ʞ�8��K�m�z�[�ܷ�\n���\r��5��H��ۉ:h�e�r5Z�)�DMfγ���	�q2G$I�[�&�-A��A\Z��?���<υЇ��F\\��h����&�ć������/F�%�|�̍r�|/��R��1��^��@��X�\"�ǐ8AVO!~�\"s��S���R��B��G��WY�S5N:�Ѻa9w��)d\n��>���q\"�7�\0gP�H�)D^���y.1Vz�˰�9[&��Đ�I<(I��6���>�U���j��^㰿 7��1�� 8F$I>�ch��]~h��f�&�V)��~�{|�.���7��(�Q��]�,��ɜ#��?�\r�\'�ס��o���<��G�������7W�o����\r����x�s�>�!�Vd�9�����a+�	�������N;�9���t`�-�kcO^=��C����ȯDg��¿�o�B�ׅ1���s팩���̨���$�H|\nc��ir���H�)L�B��4�N���h�����i�g�\ZS�������ۢQ��]\naf�$��!؁Z#&N��)��cG�8�8��V#�)�G��Å�t���	�(�6���2W�p�T\r-�m~�W�5@\"yQY�\Z12�6Q��T���\0c.��	B�s���}R����\\����|�\\Mo�H�;QrK�ǡ~#��\Z\'�\Z�?��!\"w4L�X*H$6�R$>�hw�s�o��y��u����h� �}T�F�U?��B]2V\n���L�E������1���X��Έ��4��P|O���C9�]�]*���Ϲ�k�u��?\\C(C�7��wYd>�3]�t���o�lL���m\0|,\'A����]�T���V���K�\'��;� �~�]��f�HlZ�HzR��\0\n}V���q4���A���F�L��A���}�n��^s�?������b����_��������\'��Pt�M5(�O�[:U]��N�������?��A��\"I|2/8V������s?�_r���7���E��Z����~0�Um�ʧ �.$M��	��m���Fy�\'�p�$��/�d��R�\'�@��J;�I���bL�z����)�/�O��2/XC>����7q|��>)��>I��0�j�^����Q������$�u�Q��+@��0<��&[a��Y/��o4s�W�;7W��o��i��e��7Yjk����vUd<��M��.n�-|���)�w\Z�{�hi�GQ�\r�>����A�]��b\n�_�yh��X�oF��E�?����h�ތ��U��c�p_إ;F),�g���OI5�4�\nB��Ql?��bia��/��T�3\\f��u#�U}��?�*]\Z��3�r`�d�?%HrlH~2��XOlb�\'�~��6�Z��ŚU��������7��\\�bպK��%�P��/b4�5-�N{�y�~.�ӬR�CP��T3iE���MȀja���z��:��N~�˻����n�mH�JV�P��3�ª�:�j�X���B}�j���Uӵ׮Y|���?�J�p����/��:��o�|		�|\n&�a���ү�n�^��s���,o���?Z�M��͋�V\\��_���B_�<�n)\0>��82��g�����:e��������h2;��/7>f��Ź��+�B��w�_r֏�;��~�\'Ow�}����M\0�75�<��O��xi�Ƕe��=���!��1�n91������mv\\�W��G���s���J5/�	dw:���c7���c�)�Gy�vK�p\n�Ի��u;��k?��憿a<��K?w%�����j%���h�Y�o[�_��������Oi���D���g_��y�9u�yi�_s��x��b��Hy����\r�g]V&��U���m�HB�bʦ����M���[!?�S�u�uv���.�-����`0�����h֬�\0n.�/_���&([�����Q��Z�[��ψ��5�A��Bxl)\r|З4�z��S��s��:��_��p�W�XF\r����og��)Dg|>��\Z�h�k�$��n�̽�i{ȹl�/=3f��߻��ߨ������>=�m�����E��\0ut~��B��b(�ᆮ0V�[X����a��#T���oE2%���ٿ��?~�W��_�����s9�I,Z��BȻ�����\r��x�����g�\Z�K�t|��u��\r/\'z��H���]���3lnH�z�Qz?��Üx�8湗�*c��|7>����9�>a���b\n2��U�J�e�s?�����e�ڟ��ly��[��b��8�${	eUF~<�.�I+�,+(�<+.���oXa�_XYF�Vf��ڌ�~хYaa��Q���ksS��T��go�z�/�\Z����S:4ۈ���}�C�?cF�V8�d�^4�p�@\'�F��Yq����{������{��SR�]���i��\n���^���pG��%]��;2���;ʈ_����g)���(%hהּ,�E� x�^�ky���eW��������>0;�.5�2)?S��墴	|����Tyk���M�Y��S���d���~w�S�wH�A~3)׋�1z��\0�j����T����5���­.��՝�ze�p_=n<W#/7�.�.��Bn)x�8�s����u�(c����pV�Zx�9>�8\\�	.Z{�m.�)������*�+�]�������i��U6�:(�+i)���������ux`��&������m��3�\n�U[�u�cp�WwuD�K�|>ֳ�\"�[}-/���!���@��x��G~��<�����F�W��X�V��ߑ��АN��{�Rg3�ӕoe��\">]���ܮ���jp���2-���z���z�tv���%p��\r��fz:����K��1�^;\n�W7A��K�kx�f[e��[Y\Z������ky��ւ�殰[1&��\\��\\H0gs��[���(8�\0���ߏ���2U��6>�:��x����������W����	�v�@�ؕN�Y{����;1�6����ciF4M���h��x?8�o����p�gݭ�e�n�j�o��ة������p{5�g\0Mc-���c�9���߽*�6:k�\ryQ�W��dop�=�$�\\J�aD�Q���u������M���`��^�ܠͱ�F�vmت�Ѯ��\"�����+��!4�\Z½��#{aj�_M�|gBg����_n�|�G���o�+yp3;��A����_<�:7�\r<-�C�����p�������_���4eȼt���j���S����UYW[�|��_�M��PVt�t�e����V޹��\ri�z����V�C�����3SϽ,lk�/rV߁r��ˋ�Az8XKI���P�v;�����s���(���\nN�{���Z*�[�tk�[ȹr�j�>�[�|�~����77��*?�/M\n�_km)_X�>����B�����p��	\\tv����!�뢽cC���g����F���fH��>���,ث�5��I�M?{�Ma\r�i<�p��) -�et�oS��>���w��f�������]����N�h�1����#뾘�<E��]![Y��s�g*B��xY��/���|d�BuT��!����z�6�=����1�\0�<h\n=)>W���D����/R�-{b��hZ�,����z4��A6r��S��xgr��G�!+5�<\rN���B�g���<��~\'�ϕ���*ۡ��ק��Қ� {irl���Q�x&.ĉ�ʲ����YG}�۫޷��=m�9��՝%-��{���oi�J��J?Br����w���]k0���(mP?���NA\\���F�Lr�`�l]}�������=�/8j�XwUx��%���^w�KF2�|�5CC���6:�o��^֗.u�Vt#G;��n��>ڇz_댆�[���C�����=N8������~W��*n�$���Ut��<��y���Pڒ��\n�k~ª� �\',��0?�ye�x<���I�����N(�w��S�Eq�ʍ�-��5���r�,���Μ@k��m�z��8s��J�����n��g�G� �����4w������O\0��>��t���n��`9ڨ���䷡��\nM�U�\\�4���A�j��A��9�ہW���ע��rm�+�e�������^� Ε�\0����eCS�On�;ة��{q����~��~�=�g��K��	�7�Cu�}�K9��W��ش��u�����~\'��^D�]��W5`(nq~�D0�9^ZކG�a��!MyU|�/-0-�y���Nv�_=d��m3��:�▷�P�����x��s���S����6�\\\06�P���(���=�}���c\\��q{������n�������������	�ev�3��j*���Ѷ��������q��[WݟNx\Z��|�W��8�r7����#�wC���pF�x��j*2�J~�]gC�;)�z�\r3�vJ�a~��?��~��8\'�����s�Rsؠ���Z偭��*�ݙd�!vJ�b����!�:��B|(�$5��o�9�xm����A6J�c~J����.ϛ?�5��)�_�z	�����k�Z����s)��o��I;��6llw�����>�~5��w7�������D��Q~�;TVQ߄��T��ۑ�P�����M�3��4)^�!����A��p/�r�o�y❟�I��ԟ�7H<jz?��든�at��A����.�����7�_#��A,o+�VN�s��sr57�|o���q�@HYRHfl�	�ʯ}�P8�s�D!M}%8��?������U��\r�MA^2��l�W�z@�4�ZV��:�_�͐]�җ�5�\0�ծ\rmf��Qk7T<L�������Pj��}C���[AV��ѧ��T�dBUI����5��Hψ]�{S��RgڏP�\01\'��-�m�Yv�f�j��������l�(����B|�`k9Ӭ`�.w�����a��u�TMI����C����{3�S���y�<UP��\nk^F:^�L�mz���N���Pt7:\Z���\0�ͭ�4��K��qH��p�����x��k��y��0:Zhu~k}����N���t�@��4e@c]!�9��{Y^<�P�������z��:䥴���ٙ��f�z�|����H��������i��n�[	@���a���|G�2t����������Pt��&�u����0��P���Y�Q��x럤l���#ΐ�@k�6;\0>&G��XJ����.���g)���Qw`=x�׵Cn��������x�y&\'���1�3<�>�)�`�����6�੷}�����(\'p3>�m��NW_��?|�F�߆>��\'>6r���pW8>f\'�����FY�9S]_��eD�|�����	�j�_>��r�y<�TŸ\Z.��\"��΂��!p�vܮ���gv�ʽ$�Kّ�Bld��\n�+c���0��8�^e���w^&>�}t�Al�Q�68Ft(���\r�VR�.��-*ya�cM��ϻ���~�I�����d�v����p?���w>��\'�C/#��3�~~�t/�Ş�v�T�~B��{��B��8ԇsP�j�e���;��;?t��߉��j@5�<�!\'��:7��&�6�&7�a�w/�:7��67��:/��:/9�:#&�:;��:/�N�\r�7�I���[���^J���s|l���sc���(ݳ+7\'�[�&y[gc\0�X|˺<���~���*٦辧uN��uV�\r��\"���\"�\0��g�������1�9)��/</���j�S�@�GVg�f��&�X�%���&��̠�����N�Q��#\'�f���#YԻ��\Z�cs#�9���r��lNFK�qn\\-\'��!;�Y� ;y�8�P6U�a����&9�!�i���rr�������j�̻`N��܄P���t���UN����U�+�ݳ�M±v�ιa��kC�N֪+��,M4K����r��Kv�͍��M�1.�	�����ϳ�P���ӷ����Ŷ>���d�E~}�{Q��\0��Ԇr{���{���7Qeq���\"\n}��Ł�鋠\'n$5D��o��Ǐ}_��Hf�=���g�WS�\0jW@���/�\n?��O�WC��|B���cG����s����[�������~%!r�B�=V���N\0��gS�\0 ���`ꁷ1�8�D�>�]��k���������A=c9�@����Ơ)�*���/��.���Q�>�����:��JK.�0˂l�ެbY2�@�$��%F�fÆr2�Y6�g7�f!��muɒeY�E.�QI�ջ�fF��i��hTG��P����?���.�$YМ���?�{����{���.C[�����˵-��+_�F\'��q�0�싱x_L%��f�?FKV�>�O���>G��64�>1l5�[b?l�����C�K��zI�N#i3�I�z�Jz��٦�tt)%��:$��vIיI��M�b$�S!Q(]�����Ւ*�ԫ$���EO0)%�n��@�Mf��A�!9�k�(�J�Ҩ��i�E�J�@��\rg%������ʗ��Ó���[N�j)�|n\\��\nh�+��*Нz\'�o�D�?�1�0f�6��E[��E[��N�@\Z}�u�+��I[�0��DO���#z*�`��[���x���>��������Տ���	���\\�(z*���b�+(��1�6�ێ��Ga�x��\\�,���_����\r�:���i�����[+��>EaZ�[�c�(m����Y���W\n���)����L�CD��N�0�{`$�se|\'�h���ϳ��1�b�(/\Z��v��?,#�q��`�뼗@c��K;��x��q����i�%�+b�0%�\\��1!c���\\4y�m�Q�\\�����9�:�L����sǩ~[��][�����n����7q�4��F��P�&b,��I���X��8�}V*�7�?�g��,\'`���i~`��.\'�P�!ٞ�)9�k	��<g�1�up9_犝a��t��-�5�c�h�r��#�U�y�y\\��r�m���g�>�����zG�\Z����ˎ�-z�_��:�8�y�M��7`:���D���`N�9���WaV���1�v�L�+��] ��Ҽ@�\"���\n���)<_Hq�>�~�?G��O�q3�b�<�geb�9\n��u�}^�PL�*�x�s��L�\n��s���eh�̕�\n���\r��t��g�\']�l%�D�����F�1CQ愈�5W(/^X�껬���t�<�?����}���-�������KϤEִ��%�C���X�K�q^�I�=6��B�兞���d��v���B��m�nhϤx\n+�����Zt��E3�wP����\'?���7h(�*��I�\\O��3��Ey�)_�ZӨ�*K��Q9E�Z�~�Ud���47�UP݊��O�셦wtfގ�����o�Jٮ����»[��5Ow�^��*5��W���f�c�J�q�J�\\e�)�6�?��_9f>�=B��+�%�K݌���]���`.�vL�8녾/L��	�^\"������߶��1�;/�R�����o���]/����[>�r4��l���hOبΞ1�B��Oy~K��,��B�����P�C��\'׾����x���io�夗���ٶ<�ߘ�	�r��f���zmm�WR���{�K2����C�u�2U�ߍu�؁��|\n�ǶCsx;S�v�(l>J�#�\'���s�Oi���a�x�KiF�v�)l�4��o!菊a+��gS>��Let��Oq����r��M�����e���K��rv�����L���H�l*�f��)m����Ѣ��-7�J\"��r�j�o�E����-��7�tT����\ZVȀ��|+�ʦx��Տ�IeQ5�Q���Q\r�Vyԙzr�_.�jTȣj�ȟO�䯮����(���y�yT����T���TSz;�)���i蠴Ӕ��\Z���f�Ci��ZJ���&\n�6RB�W����G������-e�����]p���a�\"\Z@�B����\"w����c�W�󮁭�&�o�`�\Z������,v,�����~�yÑ\'��q�Hl��`?r=.��#ξ�|M2yJ\\\'�X�������w{�/�~�%\\Hi�O���f��zc8z=̩!���\"�LxM:[I�w�	�\"���ČsLz��X��b��.��p��x֌0�;�)�0��\0}���VcBv5��z�S���˨��^�(�>/e��1��;ݮ�wZ�e���O�]�t��:���=�6H&ZCV\0��aN�#^����hO��C����IQ���ˡ����\r�Gtw���^�p�ayC��.�}��������Dl �|�E F�B`K�`�zt�]h�B��O��*A�8��>���7�O>��.�����%��X�wq٦�y�Z|�);\n�6�J|�xR���c8.\0ɡpD�\'%���qN~�`y�D�)��d����qTY�>��/=#��+l{�qSCrZ����,�\Z;������4�5z�ތ{1�{lz�a<O��wʐXn��`��7��J�>�R����Y��Z��e}��#,|英a��߸`�&��{rޘ����>��GdZ0�낞b��;z�N�$7�f�:L|�m�.����x�L�uGr:�<0�+�\rJE92�.�׍y�`*\roԟ��NGK�b�����a��2k�ۋ�?�t�r�5���D�K��H�b*�*QV�����g�y>7�z�ò�z���}�����5y���$��/�G�	�yඡ��?R�<�^�s��Խ�+u_���&`���Kc<,�7c.��	��a���c�	z&,#`ـ�X�{�����p�\n���7�mߣ,1���7�������3�]z�˜�ګL����/��\"0��3Ů����{n� \"�����mt�ߏ�=h��\rÁ`e�	Y�e��\0���zIr�_�����4,[[����L���ϴ��{�%�nk�������6po�2#���h����;��z��C]�A�m�M�o�t��o�����7۪w���Ø�v�X\\z����zJo�9��`7���rߏ;��F	3��D��\'\\0r��7`��C�4Hg*~�N����,��1�~����c����%�R?��Ɨ��w����\'���DUo��CZiL��\"���J�S/�H�<g�]���&⭮�\"��_�����n�C����5�*\\&���y���\\�����nSRq|g�x�1���k����\r-Ew�cfs�=ժ\"�&��MMgri��F5U/7u�?��y��:u�g���A��w��$ùk0Rp3F򯅃ey�x�}��b�,��������K��5�@�V����{j$&��0�SZ8�0�s\r�������:��4�/�%r�.┓g<�܋���:	�;8�a�h%��հ\\K��:�߈��1,�s�+)�+���d�8�X1����5�\\��c�{\Z<��g�H���z?)^��?^���d�O�Ĕy/F?��p�ϥ	�\r)����Do�u�g�C�&J�2d�iL.�;���gl��+��ӈ�bܬ���#�E:�~�yeg^��wͼ���i�>���	q.�;%�-Xf�����Ջ݆�t����i̞1濄სp���d�/�?�6>�l�O�8�yA�����\"-f\Z�߯p��ǃT��?�b�hAW�i˧����ĳ��ǂ<�H#��5��c^�NP����B�K�͸��=�I�k���ۂ���\r��ϛ�7a,1�1M�5�N�S�6�ڬ[�_!�\"/�}�r$�{,�qaȝ�~�x&���9�8wi����p����������/�8�ܤ��l5فФ��\'>�IA��n�6���<�`�A�/���8닱�\0�Q{��q�/���`9�=R����B��nX(�l����R�ؗ�-OT�gZ���s1���N9��x>�k��WZ���9�j3<�I��.)����`4�	���^�F��M���~�غ{�%��@Ņb&�ShwG\\ �`���}x�����q7؉���-ǼlF����|#a��[���@<� �1�pe;}������䬁��m8��c�&tҸ��}w�b�i�o,��ս�I\r^��6�o���jW[�/�Ϟ��%�>���К�W�<�>�`(>=	D���f�F��\r�!-�tO�f��!c4䚎�\0K���]s�-��t�2�V���q6�����]��\'lBl f��h.\n�x\\\0��}0�������5F�CY�5[���+�\\�����V����aKی��0�$`2���/�Ҹ����p\"ъ�`Xb�F�gǞ`��Y%���A$4�����z4��U�&X�n��=���~GL(&���ϩ�XOZ��c�#wب�u�F���=�������]]����%���ߓ����4�OZ\r����pd3рH�G}N��T�?�	O\Z�M��}��K��b�zL�xav�/&S�p���d�\'�=0�L�$&�^���B_�7��f�C�����R/��[��b��~���ma5���.{,]u���}�~�gH�����K	�pR���`��{x����H�@���� �)�Hj�%s�FX36Cu�	��t�!�t�~Sm�G���n��b���+�«Wk\r��КZfi����.z�S;�u�!��u�=�:����9�0��AS�Z*�h�)�zM]���L���+�a�k��X�����w�\"kV\"\0\0�mkBT����\0w�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��y|[Օ��8!e%N���N\'@��.Ô�	�&4t�|hg�-���i�t��Ҳ$�&�Jǉ-/��}����Y�,Y�mY��ɲ�-�ߜ�\'��g��fF	�|?�����w��I@��p�NY����.vu��|h*c�!sZ����C���C��T�A\"��R��_�vn̩}���ʹ�<�S��� XS`I���D\0�*7`AF��\\�+U\"�K��Z��k�\\{�v� 	���셅�PSw�Pz;VKE���m�\"�Io.�+z���ʹ��uZ�價���Qo��1���r/�jEX�a�t`�T��-	|a�-���˹���gO�-1\0��0҃a�m��d�H:�$��z�I[������~��k�G�:~��[\r]�^X��=}�3�a)�W�`~�<�rN����u�����zθ���s툪���*���?X1�\ZU�}X����|�2�|P�t`KeO�W�9Q�����\\;�h�y��X8�����ѳ[q��n\'�;h.����bL���Rޞ�S�7����9!�����?�lz f�aK	��X0fd�Dr���JW�x�ֆ:I�ES�O���z@~靽-U?��-b��M<��O������B�\"�7����h�X9\\/������u�a:�4���M���R� V\Z�L_\'6P?��I<�o*\Zˠo���}�6�^�U5����Z�(��Z�}�:񈾍��;��(��t\\_���&vu�o�u�G^>�U�6��\0��kr0�	���\r�\n��K${6\\es���J�9҃1�v�U�C+����i�������cct\r����&\Z���� ���c��Yg�o���0^�4�m�kzƆoC������Ib?��h��4<���ǡk�6F��0�r�ε�6\Z��[�R?�74<A��&?3K��M�=�s�:����z����W�̺SdS�1yt�\'}0]⁥:���\n��˥��2��j��_4C��b���H�f��h��sT>C�s�/aq�+vjc\'}�+�z�Hm�%ӄM\"�٘v\Z�Jǳ��\\�p��Pjc�4�,����ں�,J����y�i|S�Ȭ�����j�����Ȯ.��AQ�ZFa&%�	AM�UAfo�*�Y���m2�?$�,������Rҕ�zJ+r�ʖ��*[K��ږ��˄c6���k��u�ڻ�%j�Fc-3ݠ~W�yi>Z�ڰ�>�/;^�r6w��|E�5v�Εl�(+���t�۟��HtӅ����WaJމ���uk|\0l�aХDA�����(�D�\'���{�F�\n�\\�A��\n��2ʗQJ��TF�K,O헨�r�Pf��)����Q!���Q�\n��VO�M53�T.ԯ����!}Y�c礔l\0;^��q��h�${v�\\�\Z��4v���{�&���c��+��cZw��Z�����m=C=��C���O�/����[�M����0���Ā��$?��|`N��!=�P���`��E�6(�yA~b�ӷ�R�z򨜎{3�0��\rY�p���\\N�%S�ڲ��^PP��L\"���8i^���!j�{���{��8��B}i�Kԯ7uT4~?���݆�ǽ�i/�ݛC�x�t?t�xc0�>,�݄%�|c#=p�n7\rU|�[9�򭁉���&9��k���2���֯\Z��_�w�Fշ�C���bUߟՙ�����f���ˊ�13���a~�n,%����D?�%���_�����-o�BOy�?L&P���0C�oS��`�rS�/o�a�-?LP^�.�G�D}�H�f�}a�1�	B���\'S>�����ٹh=�gcP�H�O�S�R�Q�0��O�&=��9?��R�ϰ�yC≱���K�b�ښ�����o 6_�s7���y�b[����Wg�>����C��M��9\0��P��Pѱ�4�OQ�ґ��/�<��@��Y[���0�NMuj����±��\rP;\ZCG}T�Q����(��Q�����{Rh���\n���h�a.-��\0hȖ���r�v�kV\nk\Z�W�Tzb�*Z���n\Z*y�c����ᮟwi�_}u�)��2p7%�g\ns^�l2�>yQ��x[�$�e�\"��Z\Zw�\\\Z��-���N)��K�:z�q���/�r�7�ұ�ʛ����K�q�2i\\S�i)�i���S]�s~��j�=�u�ح�\rձs�R]+�u�qk�!ڨ�����:�Km�y�������%�%�P煑\r _�\\X��(���C{��.��S՝0W܉�ʭ+~c����Ay�u\\��>�4�1^�N��{A0��Wٚ���.��&Y��	L��|A�,�Mc��^8��Ӡ9��DX�áˊ���n��l[�:\Z�2לP%��l���tb���\r��}/�ON��X�w��!�!,��|f(�;1�\0Ù-�J6c�֒$w��Z�]����T؃)�O�9�u�� ��y��?��sY�X<Bk���P�@y��� �e���	DO��$��>��uN�kb��S���G��,fd�����y���Q���!�G�`*i7����K�|R(f�\"aJ��db8S�i�\Z��`�\r79��?��������s�lR�z|�������0,��?�Y�pѾmA&O섁�������%)�Q���13�\'��*�	�fe2ӃE�L����k�U@�x������J<�=�~���k�z��;�C;�Au��w;�{���\\1�0\'���K��ˮ=$�o���M��eW���^W�+�y�����䰽>�6�>�n�W�����\'���	u�?�˄8(�T�Gf>\"��%\"��/�|�B[1�7����������!1֣�O��@�J�}��\Za��\\�֍��۠����~��\\�����f1(1�������2��[~\n]J������М���&a���`%���y��	7m�l�b������۷���fȼ���><��{���~Eޒs���଱Z��\Zow?��=*������R<�2��9��3�:�L�����^ާ��\\�C�n�hEК�������w\\�y=\\N���������t�Y�}Y�*�u]i&J7�^偅R����B�1X�F����w|h����h$��X�&d�-�4�V\nqI+R�_���d�l��l\'�}��i��O��پGΤ�g��m�ۯ��M���ʗ4�E����hhx��LJ��|�����rN�>w?��W/5���S�b!��I�Mz\0�3�,����\'�d?�k�!�,^��ϊ0]$�D���ީ)Si��oS�^�(��kj�|Ѭ����쵄���ph~������=ݧL�m~~JYmy�%w;c���J�+.�R�I6gѵ��yވ�64ZI���I�~�9샩����`��\n[�g��R���r�;�u����M��X�S�-�C�\r���TEa��I��ros�wgoў���w*J�:5�?�j�c���6y�︦�a蚟��,����.��e�`��Q�\n�ƾk����~v~&i����+y�KY,*y�ݰ&a1)\0�����	�t����=�Ｃ\\�Ieߏ�˄�D&�hs��k�oюb!&��s���D2�s�-��b�쳰��K��X��Dm=�H}��b���8\\�&]�	1���E����Hֆ����*.����utj�S>��1�?,I�V�ՙ���h�N��b�`�q�!���f��ܙܘ�`ߙYl��ű�ܬ�F�\ne�o��Y%�q�g1�,ƙ�C�{�|&oG�0�KY�4�����}�gžo[�������B�x����)�!,9Q�;\Z���@̿	e�\n|�;Kz@����]��F���F����{\n�ł���3&+�Ud���˵���\n��d2v�GW\n:0��/�K�l-j�>W���\n�n �q��@�����ߧ��7�����<���ރ��XN��L�?	@��\0��}�̿�|���X�A�l��>��S��w�N�M�X�;�u��7�%�-`�g��l޷�b��`��U�+έ��g�@]\nEV4�ɑXLs�s���J��}q�3b0����@̦�`���6e/4�!����m0��^�+�º��jK�5��so�R�%{��\r�oZ�/�~�ڰ�6��`6��&��=�d�&�]�fhr}0H��*m7Li��N�LJ �)��~^�F��Z�[N~C�}8vݐ���(�|��}.)Ia��?e�.g���?�R�3�uO,K6`���\n��\n�V���j�띯����Rj�	�����/܊�����`h��`��n��p�p��B��L�H����\"���>�����_�t���/��ڜ>��͌�5c�S�R|�>Db*9���GB�rd.$FA}<\n�پ���u�v((՞����Bu�6���P�7���A�?.�a0>mG#�J��=O�=-��P�\'�`1>\0S�!Oڱ0rb�B#y$��1w?��bۻ_����(s�\0��X�v`:5��X$�Az�H�%�lEj�	���s�H����/9\ZʷwC��[��8��	{�?����:3��(X�#H�4f�/�G�1��7L��pl�R���܎��RM�s\"��-3�~�����o�\'����T,ـ��\'��[B0�/���X�$_2W3�a���h ��p���B�/V�}`K\'[���D?,&�a,��s��:���}�]�ϻ�������ްGK�/�H���?���ؙ������p�e�C6;��\'�h���;\ZY;�vÜ\Z3��Ί^ץ�!7�g��*j���_����5�]È,tdn������l�&~�Y����绳��=IP6�\'��F_�A�~ݧ���^�ځ��8�(�J�C!{]��\\R��vH���7zz�ίuo:�E���8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���������fN\0\04=mkBT����\0~�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��]\\U��#vDE_��`�j�1�Eb7�.�Tl(���{��ri�.��қ��{�bG�=��/ɗB�x�����9{�ݝ�ٙ�=�\\\0��p�p���(%x�\\�\\�9p�z]8��J��+���O6s!�v}8����sh�yY�$��<�e\\S�h׉�� ��D��J\0�@��HY�)��T�I�u��?@��yPj-]FK��t!t.xS��eJy�ż�ѯ3�����{\"d;.�\n{1xj�\0����N2�(@v�8`�����H�><��ސ1��8J���X����a:ʘG�ֆ�v=9����I�4��\"��y 43�C��ԙHA��2�6�u^�W2i�v]9�����(�����k\07�΅R{ahB���`.�;~eY}K쿠��G�� �_���F>C��}��>�����0��a�����Ts��ѯ7��mS�7����Q(P� /�Y������2��Pe$���L��$Nub��ם����҈�P�z�@��k�{�O��E��frA��<����s��B\"�I���l�����h��<& N�&1��#�B\rK��� �A?P�E�F~�R��h%=F�^V?X\\�$Tk�p>���������_�8������h������<i> <0@����5���X����u^s���<��I<>�zq|��҄��#6ُo(�\'ZN�/�]�1,�iH��N�\r1R���e�(O���A��R�2Y��\"�l*�֋��R�M�A���r�mY�~\n{����o�����@��ز1�t��!�Qۈϑzyp,XU��Ph.-&��`�ډ�\0y�m�.c7�|Y~O�-Wu�W.jnqLxZ�h�>F����ʺ$%h\r��������\0ʂ&d;΃r\'�p�U����q!��.�*��B��`tZ/�J�e�*{7���	�Q�]�#��#�Cy�|xFۄ��OQ&���}����c�;pT��A��\"��Z�8N�C��WU)��G�7q�ǡ��\n���\'uB�������nM��G����{1NS�,��Y-F�`�d�:��e\'ٌ�o����vU�h��=�<�k?�@/ʃ~&��nlCb��&O^(u[�&K�J<�Ol������@6ʁ҄P,\0M�S�9��Y�h\'��,n�o��M�o�Ș����x ]����lQr\Z�\\|N�Ԕ(���P�ԄP�v���P���sR�\\�/�G�}�px\0ާ�ʱ�{��d�\'���\'�b8>�����4|��q�0<���|٘GJ>c�D�l�I�\"�؟�3=��҄���AΗ����a�q��Y~9�rn	[5�!Y=��)]W.u�eh/��\0���gЇ�D��4ʬ�C��\0t��M*��B��n���M]+<�k9���~���m7�p|ư\"w��(�w���\nӖ�����c7���ðR^LҐ|�]�+��ʆӑ�*H�V��J��	�S��wA.�Xs���l��i�.+RRG��mX��Z)	fNE^�����X莠���ԏ���e���|o	b!4�[\0MF��`�\Z/�ڻ��6C��P��x_��jo.�6s|w��]���������}\r�m%�1�)��}���`J�Y�q�0N�	}�L�c~՘�7c��������z�χ>�y�t��{���,�:�Uo��O�J�1�w�����@iO�pyU��AV�NjE�fYW�f^]�����Қ�̊<������ʬ(P�mo�O���jW|RY����;�\\�*��*��(d�|Ժ2�Q_�x�w�)fs �r!dZρL�O!�l6d8͆���<���Pl��況�W�ِk��vxu�g�>��\ri�.����C�a�|����q1]��l��x9��m��$/G:�|{��t�#���̫�}6T�����i	�]\Z�Š��sxj2ڌ>�b+�Ԃ0C��Ѧ�_�������vvl9�0��dX{W�O�i{�6�a�\\͝Y��O�+��NT����65w<��������Qnc����f�cz�Q�xn�����P�@I������E��Axd0��$�p:bsvG��!�H�A�c��vGm�Py�q\'��C�A��At�����|�:�yn��͢Ӓq�i0m��1>B��z��P���Lz-�B��\0<�Z\rf���W<JH\Zm:�Y���9})��;�/\'���\"�I����O�:FWe���uV^\0�릛�o��{~���<x�����)LҒ�1����̣_���i7˴��t��I�S��E�k�3`:�A�������3��)�uh�X�I쇗�i8������4?�\r�����<��*�pz��9�G�7=.��!�[H^ď1=|6<��\Z�7mӐwD��N�I�B��b����E8&-�&�UO�.��t�6-�����\'�F���Z�\0�ب������*rc�h��>�;o��݂Ȳ�6k\r�i���w��/|�0S}/�]ڛ|��FAr������0������*}�U\Z%-��T��	���ӠaP���İ�`n�]���j�N�?�pǥ���5������1T��P�?I쐧�����P���D�a\Z��\rd������w�!4t�k��q��`����e����Y,�f�V�fej^��Ѧ�A�P�S���\n\\�Ka�}u�f�<��*�?Oy��Lcǐ�� bp�N�j�8I�6�l��r{}���|W�<ᘫ)��C��6\\g�����B�w-��(Z��@c�wP���Z#5��4����P�4���P��o�Ҙ}P�p+����4$�6h��U���~����Ƥ]P���c>�W�h����[�2j4�l���۱�]X�V|���@e�^,C�m%S�#�3��Gʟ��Ǚ��=,z� keʜP�4�n��?Vf�R1)-d������&����(?.ٙ��L\r�\"��^��:��@V5��0� \r�]:\0\\Ǥ٤=����[����oÓ�V��V�����K��\\��k�]t\\�L\"�z�6���6�%ȶ�%�V#��u��uu��9�	��5ɲ�eI�u���\"Y��\"I6�:E�e}�l}]�l1�.�$Q��x_��+�1�&Q��4Y���+��WT$ʶƤPײ�d,�䓈�&��b����r�Sd�\ZR6ǲ�g%]e��MZ�C�\"P�\Z\'�B�XB��ZOh���\"���k&mfĦ���<-�9�4�C��H��^�p/Y.ɩ�&�V/��̼&y���N�%z��;g���W$��(9�nz�r�S�� t�8���i-\r��� H�SuZk�;���bbIQƓ�y�V���_As�x��V�p���qW�M�ZK1h�X�v�\0T[����>���#`}er����Mu��],ԋ,���UVX�%=��,6M���u��wZD�N�u��+U\nv2;h�W�uX���7�4��V�<}�.���X_�����#0,��\ZXS�u(�������;��ˠ�t>4�/�*�W����z����m��q׭���������%;�2U��l��������աM&�n!��i��W�=,jo�����x�ΞO����9�c�f��	8�a�s��d�	+���]���;���ɼk\n�g�_v�~كx��A�Ͽ��z�Y�@��\'Pi�F7=3��`��=��z�c�%�=��5�]�\'�X�o2�2��g|��{r�����o�ŝ����U����h��5A+�L!�=����ؓƞ7��o�;0�ApgsEЗh��|}!��w\'kTZ-�fk�X5�b��n2�]_�?N7\'Y?�d.�W�k#ɷO���>x6ԙ~���-Fsr�-Ij{=������+�g3t��Q}�ǀ���)Pc!	=VK���c�qS�Iq�\Z��r��!�u�u�Sj\r�3�R�K��Z����r!��/^i�&4�u���cJA~NmU�A�����d�S�(u[�v���.�Z�eQ9���]W����<M�3(�0Y���z\nC��b�� T�CT��hד����;AY����E��sC��lh| �d���(���zr��`�����0)���<A����h&����V��o�z�OLhtI���(�����A�ߧ#��3#��f�<���Ջ1��w26�΅i\Z�xF��񰔅����G�x����j�aoݸY�w�Ȭ�_-s��V��\'sa\0�>2\'��\r����F:MP�[\n����h��}�x�wl������m6�W�1G#Ƚ���8��������o�	<�y�A��ѓuA�bf������ xߏ�8*o�����	��_�P�/�ThLU�/���O4ޮ�����7��oD.(�z�Wʞm��8�O�C�Rs�}(*��r�}t��$�^m��O���/|\'#ps!.\r�Y��2Bqq��1��:���;����J�#y��[��ǽc�b]V�<n�:&g\n��uAd�\Z�u\ZVL�\0��J >Q$&k��e�*>��NQ�jT���D���A�m����[e�\0�nv��V��x��ߋr��gT��SK!h�]f�F�f����o���\r�T@j�E�����\Z 5U��A����g�����`�� ��\"HOW���L-�N�.x�G�0��av���&��*,s�0_)>���HNSI,C�O$��=?^y/��Lu����34�N� �s�W�H�?��1���%~��zv�߷�����:�r����F�̈́�\0���(���3\rR���ؾ�Oa;kb{_Ķ�vF�K���>(1\r�OBLW��@z�&H�Wq�#��㎃�TŔ�G�f����:(�5O�}_܅��S�X��m�����!}�!�MAZ�aټ� ΋r��8�&��xxϫ��B�s�\Z�OU|zR�t+������|�CW�X���\r����b)��,�V��`}U|�i�~���hHADİ�$\'+c�¾Ňm;�<Ҝ��yX���cPF��iH�)�#�&����C\n鲈��Xvko�b����Nx�~�%X<�4�iΏ�7˟�2`\Z������x!5M����]��ȋb�Ab�Y,�2ŧ����Խ0�%�IjnZ�,��X����ɮbHB��d]#Y��5�-VA��h���ңM��L��!a�?�kӱ��#mg`Ǿ%:Y���v�G~΅�g�9WɊ܆�sUa�x��SI�����I�g)�E�h��O��jo9]`��ql���Z :a8������|5j��1hω�#����o�U8y\"0��#3��!�[b��؀2_r�\n�|ȓ�N�O�}�r�7t�l�GL�S+� `���+`rC��\\hF���`>4�H��-�Ѧ����1��(�I�#�g�2u%��J~����\Z��3��[�`��.������͇t��4 z�\r�cO�[uojQC�o���b��=O�u�8�S2e?�7DQ�,�9�~�[�u���?O��2����>�D�C���N����c�`)ϑr��.����5�*���������Pn%�̗B��8����oB���*�\\\'�8�P��+g\\���O����:��u�t�#��~��wV�W~�S\\�/4�W�^b�ٻ=�{�\Z��8�?�v��o�3HP���\nb[��X�{S��uW��_��A�s�UJ��B>�F��He���_%�4����!5�|��8��Ps\0�T�=\ZM�Q��F;A�����ߢxHAe�dU��T?REJV�*�\\c��4&�7���{��1��-JfHM����q�ُ����2�:���Mh{��G�}�\ZꛊD�l����o�cS� cL����*�/��uZ%�\0�Yb��ە3�����-�#<��y�o�-|,�}k?��?\Zm���Bh���_�FF���i}���E�;��_;��fß�1=���|�C��D��|i	D&�}���֫�<~��cn׃^o��\"�w�1�D\rZߟ��c��!�����h�E��F�,҅eQ_�U������ ��������2F���W��\rt�>��C��&_�D����V�����o\Z��_�]��=��������J����~��C^�:Ҝ�]���6�B[\\|��}�\'�el&;�Zyd��>��\Z�i��c6���G{Bl�b����b��lGR�V�Z��Ǡ]�KtW-�����D�Ќ\\#�;\"�����+�7A{�j����Z��Pi)���J��i��O2��� ���$�RST)_��$E��Z�����8�2�=�]���)~u����	M8\r�\\��`�8�7�[V��ڬ��\ZD��J�*�Ďס���T;Oo~�����H�/��\'��щ�~E^\"���i�\"ţb����|eɣ��ߥ?˯�]�:Y�o���_0:��A��\0�Y����գM��K��!���oa_�vی����>����������:�w��lb��i={���9rºV&���QC�U��]_;���w$Pǔ 4#><�W����6�d��-W�䏤��3���n��	DwT�}���?c�\n%���X=�]���Ń]����1�\Z��\0.(���mD��d)��E_v�i�~�o���-گ3��G��F�_�U�����w/��{�;�|�9�@�Jr���_̹h��ˍ{������Y`�8�/j\r��*�������΃RF��cFR�+5�-p\\�\n>�Bd*�/�S��������wm_zI����w���Y���&�恎���*�Pk�������w�\"1�4{�������I��6lˉS6���aI����]���\Z8�c�%�a:���N�=\r��UY\\�����W��㼵i4�l* 2I���)�o�nG��NU��-���qeDgS\\*)��#�&0��5gAџ�#�a��:�o�wsqZ�����Cܛ���B��P��Ea�������/�\Z��`u��Ѧ����)�Bz�����R�,��W�+���p��%���B�A�o�V�����u�Y��r��H|~�w/ڿ�4�\Z�MT�}�S/Ӳ���P��U��!r_������<[������&���HQ���\0y�i�,�t�k#:���\Zv��fxJ����/��\Z�Ⱦ����ו��M��K���!q��ǶO�p�}^�r��e��#��7\"�J���x\"gQf�]�xE�lA��C{Ů+$�W�^ys�*��-�fGYB��h�Ss{hSLTjG�P����H�/ᬗ4�i����J���\\��@�}�jC+�)��k���Ξ��2Y�#�Q{d�6T���kD�?q0�� ��ڼ�ߥM��E��ҟ�=�F�aħ��rġoL~�[�{�D�^�~�M�W�����R�ѵ���.��W�ͭ�값��)*�sHD �\0꟢��^��{Q���Hꯥ��|�����S��箔A\n���	�odE�H_=�hD�p�d1���pz��`���0&�C��8k}�����Yi��O����o�KϷ=���X9U�upۿ��/\nr:��~}�\'���g���6��Y�w�&(�_{oM�{�o�y��;���K�띣���_O�k\Z �Od�f�壞�~��-u��6~�\r\"<��RJ6���E���hx�e����{[�K|����)����d���Y\nC�h�����r�����ߧ�c\r����ql���S���i�a�6�q|�D�\\زX?\"kB����[D���:ᤓm��\Z�f������Ρ{Dua�TUzn\n�?�n|&��ܰ�ʍj�Z���ٯv��$�� zC��P:�����J��,�����Hی?�Y������Q���*�9��	Sg�U���à�\n�כ^��������Rӣ�?���h�)��g �������P�f(����;�����K����q\'�m<��h;����5t����VL �|4h�}��骰�[�I�Tf���8���P4�K|yx��{UzΘ�E�{�3/ �U@u��>U�����#m�����.aJ@o�G�E����2�9Њ�ׄ�����aП��?�vV����@��3�RX>,���C�����LB�����]UЧ&g\"8V��3�]0S�^���Olʹ�_Yn�|��K�.D�_�b+���\"�~���y$��d.�[����/�bh�x]i�S���\r�����$A�����F��[1M�^�˒Ɔ�����a>��<�Fho#���w�X�sT���������S�u/_ҽ���4�9C\nː�|�h�)����C���������.�[��:�\n=P���ÕBz,�:_|��bq�W�������Az�&,G9.M�i���1#�����]�q�\n|��&��U���N�����J��_�\'���U��+���Gی�í�]��W8�H_$7T{́v�������v��/9��AE������W���L����_��v�@��d]%���\"�	\"�&Úϯ��xz}&�	����M�뭫A3�����z.�aw��(3a�MX2u��d.e9Y_�O֛*Q�ȲqgAyM��\nH��F~��+Iւ� kA�k�/���5�ϴ�/��]��:}y�=л���4`4`��F�������a�_i��L�\';֙���$�y���[?���{�c�����	hϣ �c������Y�K>��2f>H���=�|\Zm\0U�h�M>߲m�����(���;�;y����ªOQ\'@ۍ�\'�D��>N���@b�\ZH�uǨ�L8�����w35��|$��q�Q=B<��,�W���P��\n$��٠�o����+��o��G�O��\"�.��\\*�|��]�eX6�0Q9z����J��Ѩbh�\ZC��*=]�Iq���#��?S��㓻���4�4����j~5j����1dm��9�uٸ�(��7��w�XzE�̶_�����ݑ]�:ç�{�qC	��f��>Pu��=?���,�G�|$3��mM�[�cvC�#\\�.��\Z�<d��:�޿������ޫFJ! \'r���R�軿^�%]���m����z��<Z��3�[�X��:�2t��[��o�ٰ���6��N��}�O���C���*v��6h�\0}��G���{4���i,\0�8��^� �?R�.}\0�_���W/aӫ��6��w�^l������cj|܎~2��盛�з/�~й���H�}�e�;�z�+D�\'��Ⱦ��?��uh�����J��K�(������[��Y��E��#��>`�d��hD��ń��9~�?AO�&v1��䬋`���\ZZ�o��:~�?r�+�\'��;>�g�c~�<~���?�=��w|���_��߈7a?<s����~����y�������~�m�R�h���g����߀���\0��c�wHyZ83/���`��(��E����&�岙�^��ra�\Z���c~����7~�a�(L\n,f�1��0s\"�\n������xdo�a��8̳<#~&��\'�{�����eą,����q� ��H�Ջr����+$�qЃ��h^�j>��5T�(�	\n�Jf�=���\"��ZjC�s������䠠�����ۚ�~�[(���.����G~7����0����RC�iI�̌�`f�#ߨ`�\'�)#��gz�����@艠���B��	���Vb`z�?�������l{��\0��\n���;����6�����P6�Q\\�*����<[�=~Ƨ���^p�����{\'�^cıl^f=��2�t}�ۜ�{R�k���)��ٹ-�>Z?�Á���&�`se8�+��E�j׻�3m�M��E�q.�k�\n�\Z߂󍝶I>���)Lv���`�]�n��Q��h�s����&oi���j��-���\Zt���E�W�F��$t�\'����&p�����g�m�n��9>��d�O���nǮ�������?���W��W��_���(��>�����3?	`}i+�\\ޮ���o��l�ַ�\\;�%!!آ.�\r�7����~���y��i~,��A�#G��/���\'�a	�{��C����-�յ�Hs���`p��>����Px��m���0>�gWAR��4UB�ٹ|Sm9~/=W�b��=��Z��1��O�B-�ܞU�$4+\"��*��AZ\Z����,���^17#B.��8_���\'���ءN`�\"5h}ϻ���(�^\nɾP��3�/˝����K~��f��?.����P���P����?��UH����`}M]u�iw3���?�wtU����8�������M����Nxgo|����n���o_a`��%���\"���4-�\\nA��-�-t7V����w�7������H�}p�0��ԏ˟�^�hk��57@��M�����q5��<�1�\0�X�j`��\0O2\"!�Q+����q��nD�H�L\n+��f���a��>q7=�[Z��HM���Ɨ��cNթ����6B��e\Zzv�`pf9t�U@eU1��mb�9���e����Ɓ��e>�Ї�\'{?c���\n�?h*\0MH�c��ߐg������<�uf|���A:���a�s��� ���y�\0�ӷ[_���ڧHo��^�w���0{h�����f���Ks��<<�v�[��Fzꀟ��>&g~^��i��P�k`���X��b^���蔨klls��\\/+@[��t��q��}}gY����,/p��\0��ׁ��`wcO��3�]{;郥�F�C�$��`������ׯ�i}�/�c�wv�������ٶ�����o�Փ�H�<�J�O��)����o�����.�񕴁㝃�1�\\�������7���E��h���q��\\���x}?��vW��ɀ��(`�An�7$F�Rm��P\0�:�BoU<��w�S�a�l�fx�����DC��6\'����\r&Z��k|`w*�B>��6x�D��e�>�������b\'Oƴ�q��/l�G ��\Zl�l��a��t���-�/ �ۀ��E9`���P���!�Ɗ�8n�_�S�pk��͑�k����z�����o���\r���a���X��wSmڎ��6��颈�1�Lc0UY����z��p;p38��t��Ɨ���I�or��Jc��F]��*�T�k�AFV$�4C��6x���ں�<lT7w��W>NOym��o2\n�;���g�?)���M9h�h�w����N��KeY`�^,����\0���^�1w�Kl�Ĵ�[k!��:���߃`�,��}�-!�A�]�U�I�?%9�p_c\r�\'�����a�wO�AOS.47W���k;<�%��~����k�/�P�Fo�Fݏ:��#(� �/�g6��R����/�\\�޷@}Q.x\Z����N|쪢;�C`��mmR��ҤP+����/�t��lo���`sq�d=���BpВ�#�-M;�=`es����vFF|���ap���(��\'�c̸���nvu����p(͊�K��<�O�G���0��:^�ގ�2Q�s_��6P�ñd��e��Fp�����9_߁z�V���D\r�E���f0C����A�K�t\n\nSc�y�T���� ��:��Ȁۍ�-^f\Z߆�q-Ĵ�X�W�2� �0j��1P�\ZM�A��\"�1T�bi�6mGD�{��~�+�p��Z\Z`{U�:�Z!���a�z��}hcx�{�r�cޗ\0��P�z\"߸��m�����.���`r��[q��+W�c઻�;������R�h\'��u���<!_�_l�N���/����:���hqV�M�k߃��^p��Wo{�phV�7�*�����q�(D��y�y�0�}��n���wC���7ΔRkyOgy��C�����ڣ�����}g\Z|녿�٦�H�?3���!sup����C;�]���_j���P�\0^��s��mL>(%{�Y,�~��Pb%�����Ѧ�H`����$#��,���<#�%�]�����r����X�f��j�O�uz�\nԲ�cm3�,M2YL�tG�t_s3���ͦ�`^���9��3B�fŦO/x9p2#��>#,d{F���\'\\[�୙Q�+5��<���|N;5\'�9����j�e����싷�/��MR��>�bG�,{�p,���&#��$3��23�F)=�ZS�c?�޼6�[z����aQ?�s�g��*��?�\0��\Z*+U��q�YJB���>i/�,`n���q��O��w��L���n3�2�\rO�OlM��E����E@�#]hẹ�{%�u���Uy}\rf��n�\Z\r��ix�b������|x��@��(u�u�,������\0U�R�n����C���yB��hח�������հ�@O�x��O���%�C�sAI�|�7���%(��B���ά�Ѯ3\'��G�<x�Ȕ��c�>�{�p]�$�s�vS!0�����܎��z������O��T��G��n�?��w�\\\\tZ��^K�4����@������=P�?�Y�d��r�8��!t��A=���,�f�Oߔ8|�3&�s��\n�\\�}_�׭�L���?/�� �!�T��d�KG^��򖓶��.�yk����v�����\rt���H��ZZ�RU�RQ�Х�\nQ�ȥ�!֥2��%\'�K^�m�<��K�C}����\\�]r�׹� �׹��}��ֹ�jISU�1�am�6?~x�t�=��������0���2�*3Q���o�z��ud|�����°&ϳ�6�dO���J?��j�E��*��*�pw���Z�O�˜��t�:�]��I[�㬷5��)T�!����� qhB;��1��#�BW�\\���?��)��`L�.&�N����.xG�C��2�>�H��A|�j�Z�B���M�BU����q�ݞ\Z�k��T������O��D�]�g��~�1����G��u�F�LΈ�O���̇���{4ߟ�gL�|�G�k����\'yF�q�.O���ُt&����^;��;�λ=�\Z�>�\nq����\\Z-��v��Az�����o�\r3l|�+=Qg�����U~�ח�i�\"�>g����=�\'�V.��\\�ދ�G;���w���[<�CZf��&��aX7٧\r�ݍ|�2��i�9^x}���i��)�Պ�^c�+r�^[d���Pl�\n�@��B�1�\r�BA��g?:m6�m�p�p�p�p�p�p�p�p�p�p�p�p�p�p�p�|����0+�\0\0�mkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x�흍�)��q ĉ8�D�^��>׻gI@���X�jjg�iЃ����`0��`0���?������ϟ|�:����s��\0e����Q����3|����ӧO|�:�2|�����.�}��;�7e��GF������O��6����_�Q�v��������]T��]\Z�^�ˮg��{>pj�z���k�u��o{�y���ye����?��{�-�������x���/D:��3D��&򈼹e�^H��y�i#/OG�z��Ϫ��߯_��~�\n:�sMe��#M��3Y�#=�2��Q�����Й���[\\s=E\Z��8�}E>�Gȩ�T���ڲ��T�g-��}������Vf���������o�SVw�zV}�.�/�>�~�<Vrv�@>�!?�U���������1����<�#������}����=�F[ ��~���QڋB�N�.�.+푹^ed���Lo+[\\�-��k���\rd�W����(}����6�q��$�#�?z�6��Bө�i����?�L���7�!�3�O_Q}Пu���o����[�=��tk�ȋ��M�����!\'}/�Ƈd��r2��_�C���ﲨ�:������`0:8�����o�=��+8-�4}�۞�c�ĥX�dq�{bU�����q��©ή��m�!�ƶ�g*Ϊ�U\\z��[��GA��=^�+ru��{��LV����	�U�?)�V>�ғ��)��x��|�Y�ҁ��gi��\\�yi�^c�U���o��*=�����!�����T���Y��?rf�g�����W��s�ʽV�n���*�V��X�#�=��F����ϫ��+[�\Z��F�~�yH�\\L�~��[���O҇��h�5�ݵ����T����o�\Z�w�|Sf����ӟ�+���)���;���F���;:x\r�������)/�OS�y��U���o��2��e�)Ve3\'w���gGg��=�J��^��`0��\nľ����u k�U,�Ks���ؑ5�nY�,��bXw{���w�&�����3�Qה��N��Qev�	�]��Ʒ���gcH��˞��i����{���A�3���I�8��h��w��d��u�w�����UI��W�q���8�����I�>�+���@��p��Qş���Gc�Z�����\\ƪ������U���ߝ�]���/�:�����3d�;ɫ:gB9�R�����|GW~����w�2��;�fz<AǏ�ߊg��_��l����y����������=����U���y3=� ��[�6_�����3]U�_�������k�]���]�ײ�2��;��j���->��t|��+�i5���n����Οg�Z�Y|<�1NyŬ|E7�k���������?����z/k���>�<���=�Α}N����΅���>�u�Wy�d�ʬ���dz��`0*��\\?W8�G������Y����:����Dg��c�g<���2+��������\'�W��6��qn؟{�r�u�\"w�<�Tk��.��\\�r���n�O����>U쏘~c�#T?��+��y��{�Q��,�,^�qF/X��v8�.֩g��3}�ȸ�OP��~n%�hU�G4���(_��sn|W}Tg&x^c���,F��������ѭ����+�<���#+}/�Uw8B�Rh_�����|�33!m�r\\7U9�m��({�ѝp���ve��w��[���x��G�������]�߱?g;�,�n�ҽ�ow8�]���ו����b�����?��OV�=��Z�_������#�ve�?��v��N_W��������r�YL���o;�����1�g�9pV^�G�~>�[_��v�NO�S��3��`0������Q����[�����	veO\\k^8\0֔��v<�Zbz����\\��\ZO�p���b�n$~�}���o�z�3�ј\rmK���vU���]^�i�N���WA��#��x�딫���j��t���q��:���E=�\rz%օ�q�)Cc��Y�E����q����yRG�-�+u(K\\�h�P�\'��*^ء��^���q�=m=y|K���vūe���\\��rȊ�4���=���{W���1����;=ݷ��x��p�;o@>���Ș�T\\Ԏ�+C��=*�ɫ|��G�JO�C��W]��x�1.��ﵠ9_E�б��\r��V�q�����)v�(��ʑ}��[G���w����Ǻ���{-�o���Sdו_˞��׃���2��;iT&�w*��w�����:�����g׭��S�O��s���j����%Z�[~_˯d�֮���+�������w]��7��`0����]��k��I�u��+e�L]���ւ�oA^���;=GR��?�\0�v쯱�;<��y�� o�$N�1紈=:ߥP�V��u��<�� <&����3K�yC��/�4��r�)i=��*/|Ύ^�]�Q�NН1q�G���w>ù{��<F������V��r�2�n��lo�؍ا�|�m�o��\'�qb���Ӌ��r�`e��ef����6\n0�lz��sA�_������x7��췣*�U}��R�%�+���C�����_�	�ڟ~I\\�Q��~�k�y��#_��jo~DyU���^���`5���p����k��o�?:��ˮ��C����w�������>?�Kv��:A���}E:���_�n+{��u��=����r����q͓�̳]>>��d�}+�����\Z|L������0���1��`0�l���e������g:��׺񶊝�`W��,3�O�?���]��\\9�P����~�[��kO��W�i�Gc~�)��-<�w��.��3q�}��\'v�u�w$V���n\Z��v��(�r������5��2���S;W����k�_�K�ϔ�8B/���h��E�ՠ�\'�9�w?K;�x:�x�<��|@��c��Ͻ����V��y���c��@ۖ�Sw�8B��q����]��=��2�l�B�e6V}e��������R�(�������	V��e��ZT��4���ad��e2ޒ�+n�Y����B�����Tq��S�����ߔ�<�����[&�=�f��[|�����s�z�P�)G������}{Zׅ�3���n7�j�p�W��wf�t��E�w���[ǽ�;�����`l?��`0��`0��`���{������~��������i`oL�y�>uo���i\\q��K�|}��\0��7��Svu9�G���쯿c¾#���>�,�jo��w{�Ն���ݲ�L��=�mW����2u_�����8د���jo�?���k��D���߱��m����w�>���#��}������E:��OۡO;<���s��y����}�ڛ�k�}~����|�M���\'8CT����o+�[W���������U����Q���r\'����\\��\'�t�TY��w��z.D�=��W|��~q=_��\0y��M������������Ǐk�t��bS=2��|�ұ�y�N�_}O��e���摽ۏ����tL��S6�q`C���jf��3�#��ܰ�?z�1���H���]������\\\"�W���]�����O;�2\'@���@~tG��:�����{��u����7m1��Q]�PW�V�2�S���z]ϥz��s������3��]v�����xwҞ��:ڗ>�y��`���$j��w�\0\0ymkBT����\0�6\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x�횉m�0]H\ZI!)$����FR�?6�c<lHٱd��t���C\"��+��RJ)��RJ��������kJ�߃��L��_SU��n7���s����s~�u�U�-U�yy9�c���������/Ju�z?��i�����>>>~�\0sm��+�v�u�Ց�νY�u�8����uN�?�WP>�1Js��WiV�����_uK�E��ϸ�/r����_�gK�W]ױ���EY�cl��,[��T�YH�T��������������}x���L#}A� ����G��V�7���^�}>�iҞ��-�����i���;}�LJ���X�&�T�P�3�T�#��ߨg���J��l e��\'�=���?�͘o���n���a�����|7��>��?ǐ�U�%�;�������/�m���N/��I����f�Qփ�z{��<�d��6�d�n�;������Q��m�{{�5�$���iѦx��g<�$�\"�^�%=����RJ)��S����t�e/�֔� ��a};k���_��y�?�9Ԛ�l�z���}m#��G��Kk!����k(�9�G��1�����z��,�Q�&�l�iV濊����#_�<���3�Ξm$�^9g\r�{9&�w�&��:˙�u��f֚��R��:ֽL+mW���W^���z%�I���2���lo���Z�f?�k4�W���-�#��	?V/�c^��!�!{u̵ʴU���\Zٷ�A�����Ge>G}�?�����v✽��3��X~j����{�zT��A�O^��ʰ�>��?s�y��|����G)�P�</1�1~2�ў׆�R/�7��\0Ӿsm�sr����\"�(�����2��c�Ϲ;�~�u-��)}����<�U�1�g���:�a�p�b�5{��3�(���k�!m\'mʞ����2��.�~[�)}G�κb��XE�L��������p�aԃ���7���7���Fy�0�@ߋL?󞕹��Khi�@=���RJ)��RJ)��RJ]M;�;����j�;��\0\0SmkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x����i�`�Qqqqq�����!��	�C�O��Ml�S�$I�$I�$I�$I�$I�$I�q��O�9˵w���O�o]�s�s������,�Խu˲<^�0��t�c�}�av���=��7����_��{V9��z�}��ٿ�^���s��_���y~�?���}e�z���۶�������������@��w��E՟�k�$I�$I�$I��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�@?\n���R�*f\0\0�mkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x���ytT�}��IpBǘE�\r$@d	��qN	5���M��MKz|NNh�6u��\r�V��\0-�I��he�X%KB�h�k��ef4�ъ����==�4紉�`�����޼�ޝ;�7��{�{2\02���u��c3�2��2��gYK�l��5�/+�f���2%�ZT�q��ed���k��+v�\ne�3Y�#O^)8�/2,|\"fcx��oE�qw9ك�C���_zg4��Wcz�q�Vv|:��xkچ����㎘\r�[c�֧�w�����{�{��E�;Z#Ӎ�d:�V��T~]ו��ݬ�%l�o�ٺ����ee֢@v]�����m�:�cJ+s��e�n�7]1��3~v�UӦ�>w�z�����}�+\']��ie���0����\'�E���0أ1pگ�6����)w��=8�?΢�v�Q8s�Y �}Xi;���R�`�����wDWd����g�,�n��6��6̵�1��x>����Z���=��o�HĚ{椭��U����r�?����ƿ�S釻j)����I�Li�pņ�qrz���oV�͖��jw����/���j);6;�Y=���>�I�w�)�����#g�:�˙�4m�^�U����\"�;<�5�A��t�I�BƝ~Aq�[�ij�I���Q8��-h��4e�B��\"(��¥�!�yHP~�&�MF�R���[W.h�R���υ�L��#W�>!�F�6�	Z�}AY�.d^�*(���>H�U�E�K�S�ʳ�Bvv� W�	��>�t�F��:��^[�kU�8s�O��ᰫ��	j�b�52�P�gi;�Y�ֳa�݌����_�����/�+ww]/Dk��e�O�3\Z�����W����������\ra�)���Qw��`x�X�w�X�{�h*!9G�&�+��X�}�h62�t��\rt�b��TF����X�w�h.��M�g����46�_0��7��f4_x�x��{ƺ�׍u��\r*:O���^~�X�<RZ��M�?j.9��������<]D�WQ������q�8�_���-�ݎ�hƭ�%i���(}�����i4)����Đ��y�cT���e���닾<�_��\\Xs��>S�+Я\\\nG��(M���P?�!ڷ*�a+�:Z(�aD#��|}�á^\nk�\n����h�R�g���1���]�8���Fy�9v�\'\\\n��Q_?)��5�v���$����#J/t�߄��PXc0\Z�֨\r7k�>���F���y���w�e�����4��zv�q���8��z�K�qq_/�Z��2�*iK�&r)M̃�u�9�y�XJs��xݥc1nz����sI�\'��b�D��OR^��B��]2I�\'��a��1���=@���� �Do�Dt(z�0���׾�7����x�����wέ���xSݎIc�i-e��]�o�\Z��.�NK��b�ǋ����xS��%t�m��r�����M�1�nF��x\r�O�u�j�?c=I��qq.WF1�H���W��y�ߧ�҆�C�%?X2�0���`j��1~������uS���x�:��4�������{T���%h��A_��/�����SN�:.��-�=J_�f��\'��t�S)�\"���\"�_�4����͔֓��l��(_���һ3}Ъ��9�(�B���;Z�X/��r^L���%����YJy}m\n���`Ԧ` 6�� �P�?��1�3��7߭��pw/TǇ\ZK`){ù����d��.=P���w������z�c������[��H�>܌�����$����#�#�D�{a�`3����xb\ZO���]\r���?:\'����$\"M\'6��MoBÉ 4Ŭ���Q�t^��>]�������[���`��]�k1\0}�pd�	�t�_��3�hM�UvC�W?��T#����y��n��9Y�{m;0C}���R>K}o���`�vL��/nzR�?m?���\'}/��\rk�~���5�Yؒ���Iߥ}JK\Z#�>Li#g�`8i���i�0��#��p������w.͖8�G�A�c?li{aK�[]wn/��麔�J�k���5������A��}�$���>���Z�_��W��:v�U�M��;�/p�}	��/��������t�g�M��`�|cn�6U\"�GG\n�{�:2�0�	-Iϛ[n���?Q���̦\"USm����D�XoPݨ+TU��*�i[��m��rn�PUA�+�)���՗о��E�&�C�&��i�TUa���ub�E���毫�/�?N�\n�����jk��~}�,jwbD��˗�>�_�<�ݪ6���*~6=��[�]�ȕM�Q��mxV����Jc��5�4�vҸ���Nwvb�í�����mX2	,�����^r�hI>��\n��y_5��??W�z+�_�����-\n����ʡ��N��;\r��]��矋���h����z	�.��Nm�31�De�߻����F˕Cs��ɗ�YN�N+�X�k��|[�COP[���H�.��m�B0�ѨM����[�r�ݿ�}�\'Itu�ߡ+7�ں�	\Z��\n������9�|���<[\\G���\nO��.G�`�Fn�3n5�R���2��������b.?�>�J�˥���/��pf柅��u��2iME\\g���3sZSvb &S���	�Mť�������H��g��\r��P�07v���xq\\�G���4W�X��r��a�{��}	,YO�=#��w�0��SA_�$�{;��L�����0����՜�\"t[1�����v~L���H���&9o���ͨ:�\r�����\rݱ���o�`�Vأ�0��]qa�Vg�.;�����g�:F>��u�����`�,���O�K�e\\��P��9��Z����\r���\0j��)���E��=�	8�a#�Ɂ�	l�(����,�����������1WE��/�zsVεuq��*���9\r�{n�4蹴��;�g�I��g_l�R�9�r~?,�1��-�wO�������Nͅ�;r�V��7�?l������l�[��PH��|&;J[�~R���U����z*��s������U���_��lˍ��m����S��T�y���|���r4N��]��� ��ı����.�Ų�w[s6���LD`(6��5c�N����R���\Zw���\'s���w#�w Ĺ����w\'�5[�R@��u��[,�������ÿ�qC���!Ɵ��.�boSϿWS\"�1A}�E�8��������z����3�G?�(;��2��Q������A�b\Z�=	K�V��C`��D㺭wjӾ���M��(3{���k�u[\'�����hJEo�6Ǆ`*z\r������\"�ҨwwY�C����݀�-�ѝ���0�	�X�7q\'-����_w]s�����!ſ#}\r��aO؂��@��^Wl0,�ΛK?�o���2���޸-�%�b4�֏֢7~Os�����Y�.{�wD�zj#�4�kM=�y��7\\���r�GW�N�&�/��<����(d�.{t�5�B�\\u�;����ea�^����.c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�e�e�˻ng\0\0M�mkBT����\0�D\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}X��7��z���v;��-��`RJo؛��nTT\ZA�i�����5��x�����?<���^3�f��{{��a\0��k+nǅ�n[t�y���O��[��U^��tm(�?������r��P���w@y�f(L<%qǡ\"�bJC����<���:cN��@���? ����덵q.u�l���ԕ%���}������,�b��������0�ً@��hs���(t�Š�QZ�P�.�R��*�9x�{a�\nł�o��s\'�����?�/�!2C�df����rP��\Z��B�Z����|xj7��A?}.<��}�����\"�s�!+np�/����Bx���A�\\�����mA��B�K:���V�/o��[�V��TN��y1\r�_���i4��11��g��ҊZ���\"\n�>xx����^���.\0]�B����*S^���\"I�k%5�P��T���=����p��R\Zl���^� ���	yɑ�l����&[!hs[^S��#7v���9�_{L�/�Pq�d��[;Jj#6�պ�A��t�y`\0e��b����͖�iPi�� �e�<P�\n��A��L(����g@e�$h�u�P��=T{~y^��}�yP�&و�-+1h��&���./hs�۞zl���Y�a�Ǫ�Э�����/�~�q�_#6�8ͪ|Þ\"?�uA�\"X/D���5<�.��]\0J���.����w&4L���10��\nO\"�\"G��(x��I,0�ϓ�wn�c��1�d���g������-T�|��C%�	��K�?���R|0`3���7z���__�����X�l�ΰJ����k��A��B��Bw^hs�*Ļ�]j<�O@�����,�^ư���9��qKʞ�v\01�Kdn�!/��S��x&\r�9O��ϱ�!<�2ϋf���������\0U.���Z��}�gh\'z�����/м��ہ�7.A��:����\n���B�>h��r��}��8�1@l_�	v�L����AR�8�3������Y<sۇ��`Y?ꃾ���b��3���P\'<C�1H�E�=�b�\no�\'�s��i)4�,����=v����SXQ���ˡ���Gy�E�����>�2(u�\r���;f4�F�^#N���x&�C�L���c�}�wĬ�����O���g�߇�>�c�X�C���x�0���x&��X��������>�u!���3*����o��o��.K5�z�]0��t�z6�����G��u�u�M�l7�G��PS���0�\"8\'3u@OܰN\':m���aY���1�2N���G{<g\0���q������1�=\":\0�yA�ES�q|�q�o�%w�k+�/A��\n�������043$Q�ρ���No�x\\����gbF��f�w��\'?����A��ōF�]��q�$��ބ��͆��Cl������7|�P���wS�Il	�5��:�!�����|���o#�{�I��Q��\0�����C��\0�p���M��(}M��as���&2Mt1��qk\"�/�8��Ŏ�L���iМ����CjR�e����)^�W~�T^�=����y�A;��H�-���X�jS�@w�4�r\"̀��X�h&O�2�\n���d���\'v\0��(���\"M@Z�w7���}t:-�b�~;����Wcޅr�&z�v#�}q̸�?�9�ğ\'�Ol0�ۈ����bD�+�D�7�8SX[BS\rޫXo�Cռ��O�5�i#(w4�)դ�h��l�SQlUQ�p��./O\\§@7ڛ~��LD��S�;����_�s\r7}��B����6:�E��Y\Z#�b�=���A�Ϟ ޽�_����~������$E��1�����Z�%~B�)����7_���H?t��\\�PW��4W��4y���\r�Q���]�woC�������VR�o�_3++�q��n����y!t��A��l�	�D��ӑ�l�o\'q�3�G2u~[$+�G�WV��78m*���i|��glX�E��Vv�E�3o�SCs�\"�\n`%��c���?ٲ�bLDcc�4����N�E�ĚjD�&x><�`��r8~#���3���\rgE;�]oC�Jׂ�c�o�}�\\�?��W\'�\'���|�$ס�5Y�Us��W��+Ӥ�X�s{�b^�^˼K���a��ris32o�H̳�)�����c�\r.h���Xz4���|<��#y�!���o���]�;��ook����o�h�#��	_�_�D�}�}?�LR]ԑ\'�nˠ�g)t8-��_���m�v���c\'t�,�>��PK�V�)�:ze׉OO���2��O�Oޞ��^�o!1����2V�Eh���	0����xV��l,�%�*E�o�S7U���Y&��ܯ=����S,��Um!�4~�v&��\"@zD�z��^Gnxh?��sJ[U�b�0� ��ğOf�Q�\r�\\{c&<�Ow̾����?s$m�ngc����d�����r��URj����\0���[_�������z\'2>��%}���RsR����5�5�uU�.�9|���O\"\"W����G3������t>h�	A%C*�C��0ܵ�U!�se<�B^�M�x*�\Z����S��\nV�������6����S5P�w��l.h�P�YOE�>\n���xgcn�1�2�ñjk;kHKJ��Ғi)��\n�������v���rA�M\\�������|���;�^�<��fԸC��\"��xO�ސ1+���PN����{������ې�\n��v�L|Z��ɣ�4h���6e\r�V�}VE^Ň�@OOOX�v\r����\nPTVR�p억�XY�ߥݸ�,���3/���f�Y5,��z�����2�K�_}��h��K9���w:.��v��I�Zq�G��9���Q�?Oc�c�\"�8���̹?LE}�e�P��`�ܞ0���������/�>\re5�6\'Ƭ�ܪef>4X�a�$ž�����i�O�m`D��[�q˫����u���>�[v���~�U2\"[��J�3nY��s[��B��F�E� �ޡ�<v8\'>�\'��$wC��|Kw\"3_O���P�7E��\nef~��i*�)��88�jʫ�P��?-�IEEv�������cg86�������,ٰ���rS������*��Ꝑ?����?�8�\Z����6A����Z/���)�R��O�s8d��̋x�X��0s���#�^C�����/�F\rE5�VK\Z}�͜ʏ�y�\"��*�t��;�]��Pn����.%*��`��5[.��~8��ޥ����������?��rc��i1<���>B�>��� �����+�[\'�j���P���뉘P�&,�ѝ��h����v����̦�֟���۟w��\\�!�Yox�`i]I݇cu6v6p��m()+�=\'�0p0�pl������W�IN�w�� �7B�>l?������~?)���P$w�b�7H���-��v\0�[�=�U�ᡅ\041ġ��c��|X7�rݎ�]oؤ�-	3�7G,{�|����;�^��>��9[*�6���ʿc�5<jJ�PP}qE��dč;��.�kT������y��|��������3;�\r]^Ew�}2��<�Op��S�OJ�N��� �� �f�T3�cbaqZT^ibT��Ԩ|���~qRT^I\n��?	�S�,�}��)x>ُ��������RGqJT�SPB���%x����`}yX^@�$�!��\'P����J,�.N����UQ�Y}?9���VyMNT�lF��\0��y���b��r������Y�*q�,SJ�,�l[QT�w��{\0��7o�ëW���r4~��gN�<�\'�l��_�l�#\n��h�m����� �ݴUz����\'\0$|l^X\\�&˫�G��|��>Y�~.!�:�~�{|[d�\Z�+��.������P�]����j��c5�8o�Wܺ��n�����=VB�3�v�cn���	��7@��z���^�����	�_\r��.׍x�:�nt���}��{]VQ��x�������mN���:hA��Q�����YZ���Us>���{�>]]��]a�Q����/1V�kt�fe^�ݠSP��ɺF��`��zmx���֋��q�_�-��PO��s����B��l�B��*��@���0�jn���\r�Fx�5^���c�x�Y}}��1��Pi�ǌ�bs�҄�/�J����I=4��t���C)�_f���B�=�6���� �|	����}���b�9\Z\Z�O�<(J�w��֊�\"ӛ5e�\n+릖g�����r����L����u����#U�u�\Z���{z�E�Hͯ�����74j�V��ܮ�XUW]6����B����#�w����*���/�ֶ=r\\}4�	BY���ա�As�x<�C8�)d\"4�O�Fܯ�-�lP�M�P��Ax<��&Q�U�L�� �\r����z4�d��p6�\n�\r�x�o\"�a��aP�ǚ��X�M�f�Z_6h\r��XgC�\'!���H��&B��\Zm<���D{��W��I����\'Xi�%ngYϷ�eø��%yX�E�N/\Z����<��$w�i���.�G��ڻb�TjM%6�p��:���ԳU�r7�b��\Z�7x��.,6S�oq����h��:W;���`tlq\\d�s3r��r�����N}�5��批/�?q���S\\����ߝ��i��~uYB_�����3a��>�]9\"&��H׳�yA�A��~FZ$���(\\����q�vfY�j�0t�{�[�^��a���!��y�(��7Ib��2י�\"qS:s-�����C�F�5odn��^����Qk��ג:�R����H�}8�N�4RNl8�2qx�}8f#k�_\'0�bI��n�yd�-��uX$g[�(�_U�qg ՝\r��|�֡���{�F��(x{Um�V��~�ﷸ�_pͽy�<#�嘆��z{+�J��ou�\n\'���o�2]Z�V-�2��U��ڔ�G��� nC��R�V�~���F�퇩zGa����ʇ�&ł����Ʌ�xn�h�UEǼg��/p�~s��������9�f��%8A��c��~�L�PFg}��D�[ѫg������RsO!�)w��丟Az�����A{�Y:W.}��XJ��˺�Գi�D�i��fO�Y��\\���g��?�%�\Z�.���h ��+#k��:׾�u�$�\"�x2�|Y\'�\"��y��9ɯ�9O#�1�ў߃�c#x�����랟�1�A�d~��� 1���a�$���1���~�L,Y�+x�<���]h��u]�)8�u��{Ѝ��Ze|��k���N�;Ah�8�c�<��>4˝n\Z�Y&��k�9p�?���[����g���,�����F_�g��@��\rD��/�6ٰ����E��a�邕.&vy��:%��N2\'�2��l�i�X+��[�{󴋡�K%��WXj�N��i�go�Ղ,�\';\r��~�u��t�\'>⼂��;��k��v�9�B�7�0�އ�q�:��;���ZU�GyB�\n!��\n=ѓ�;��c8�7v\ZtİCW�dh������S�\'j\n<���QS�3����#�\'�<�e���i�>	��Xg�T��8�A$n�����荚=����uGN�ߓ���b9���	���A4�#�\rc�qP.��&����C@�	s^������tIk��p�V9{�̺���./m���zj;�ߍ�_X�У��X�p6���\rK˅\0{��*��^f����a��3�C0M�(��3����v��-e/��=����,����*K��K7w����_��v�a\0,r�\Z��\\�=����\\��ٍX��)n�;�\r|�ݹ�Q����Ջ������\'s��)^Ѐ~t\'�[����� �΂(�c(y%�N�ɳ/R�:��jK\\��<uoZ]��䒠��ya?����G:�Z�#�$�����㩅��S+�6��$I-�ٔZ�5�4�Xji��ѻR����D�O-ޝZ�~8�븗�7�4�Pjy���{1[RKS��P�7xOjYʾ����x��Բ�C��q;S�ůM-�k�c��&�N��kCw�V��K�˼�}kG���ҫ+���rn�:w9��1N����u��w���k�k\Z�� bz\Z��t�=�p��d4Z�3����Ҫ���<���k��N#�Sկ<�w��`S�3�����������/��;�48�n�U<�T�N�}}�$;⥤�������/�#,{]v�-^���q%%T0��O��q�^O�$>p٭�����p!�M�;�#�W��~Rt�^����������o���@}<��]7�z�R��*��	eχ�\'�a���c�:V��?��������f:��ϑ��a�aO9ܽ��7<�#�8�*�9�1>�����u+�ç8ܫ�sD�+������\"���\'x]t<GdE�s%px4�r�Gs��a�n�9<�q�>7�#&����w�U����;�8��9\ZC���8�ï�R\Z�&b%K̕t�:�I�V�mp5͛)��W���o��f\nT�~�?�wg��s�Z�va6g�t�����z���u�Ȓ�Q,���En;p[H�IB`�zK��\\/�əͷ>k�Y�w�`����卐1)\0��i�$,?n�UQ[UXc�uݍ�����m�����O�1;}��1�{U���L�ަ8Sg�:�ų_%���Kxӭ������uhp����\ZG̡����O��\rD�����^]�ߝ��Q���������G�-a���w��I��O��t:�<��o��&�~#�s��/ �(v{�Cqg�3��\nr��2��K��z�J\"�s���[\'��L�㼦�Z;Nv?�3:W���7G�xօ(�|fR�l\r��c��Y�ײ����ǂ��b�t���*{��i,Hak�o��s�.[~s�A�vm�KIaGx.��(�l����������-;�t�<�sXSsʂu�*^W�IC��xl9D��c!��㩵m����a?�)|��{�c�p�R4�e����ޖ{ʞvS<Q��\Zv�����6�(\'U?�J7x���t���[�no�����q�L��\0^�X�آ��:�{Y����16{Z�Aú�!4�C�7�_�u+Ng,��!f;p���M�fP������������n��1p��Hu���������~W_�x۶\r�\Z%d�����i�d}-\rCKn�j��ߧsq�>g�7Ra.-�b��,��\'\'c����ȹ�Pר�܋x[�,����Gd-��rh�Ō�b�}>����~����0�����K���W��*��6���v	�O�t��9t$�8�UZ�yu�����\\��;�����*���_�P1��|-�Y4��F�9!H��V�@P�Å��{ܝyG�����M:�P�#�؞�%�1���>R�IT�v��u��)�o�j��EH�Y����|/�V�����O�ِ]��]�8��(�3]}�\0�oo�r�m�r\\69�g���i��Pk�ms�@��(�[�A�w�����3�6�9��`������L��:^���#�>�%���Z����}�~?\0�>����n���o�O���	̜ҳ�h�5q�s�C���5;3ʂ�@��j�kM�þ��=�G!�%=1QEi\'�v[��/O�����Q����x��u!�?���ȚG�wk��4o����}���.����jG賛�v�P�1��FQyY����\Z��n���m���<-�R�\n�tQx����Z�}�Q$+�3\'�=I�4r��n�?��B�w䃇t!��j~c��\'�c����Od��c��h�\r�p<��5t��k 7�j����r!t�-��`���X)��I4ǭ�������x��4]Kcw��/�����\\�I���}��OO�/DJ���9��gތ���IQ��,��^S��\"���G��x}����\\o��)u�]_\Z�ui��\r�U,d��2���W�u��=yw�\0�x/��I��;i�����j|���3�.���9�*�¾D�h�?=��X���kC�[�7�)n!d>$����n;{#��Q���}ă���{=a�N��ޯ�h����\0q��a�\\�j���b�*G���|J�\Z�@�E���F[��o���~�+Ի�: �6<��;�CGS����X�\Zb7����E|��Co�����=�%�|�T������M����a>�������,-�zB��s���\'} ~;\r��1�����\"[��[wfH�ÿZ�њ{pb�#p������}�F�*��x�����/�S�����K��o�\\l��J_!�Q*����=��,��й02����bF��	���ݪ�۾9nf��j�=��]	s������/�������� 0�HN�\0I.-��|�� ơ+�k;��A��U�c���9�r.E�-\"Al����mL���σ�:j����Z 0A$\'i\"_ʂ$�Z�v];�s������}\Z�wVJ�4��Ұt*����?�Y��V�Ѕ:>�[�j�x`0���^��1��0d��l�ze��z0HLT����YX<Q\r��\\�K����YtsP��ʻHLQ	ܪ��$-��\n�g�9��c?��\Z���(��yW��r �!�}�f��dU��R+���W���ݰc�)���)j�65�^D9�@x�4���y,��NN]�g�}7P;��k#�k`��Ab�<���K�O�S�=��Ֆz�ێ*=x`���{Ys�������6l���ŇĮ��x����$�(���N���%������|$,B]/��<0���{q*\"n\Z�|���ٵ#�q˃w��v���>���A�C�Ӥ�/1I�\'�-���^�ȟ�j�Z�l�.�\"��X�^�:U@`�\Z��uE��jD�m|7������a����]��7���bV5�\"xU1����P�͠��C�s�˒9��4���k �5�ԇ���5����4lռ�����	DnN��iJ 0Z	v�k����g�f�0S\r�E����LV�0�`WF��Qw�;�]3\"�	��(���\Z ��:�S��W�t��8�,�|��a��\0C��R�����H��X�iPrJ�źW�R3?��b��>g���y�@t\"i�Ml#\'��u�T�I�I�^\r����\'�;xD���_�C�HΏ���g�)���7�l�O\Zʺ��7G=��B�\'1��=�y��-G�Y����[�����K;��U&�q�\r��\0\\\Zxo%X>����B{o�h�9��B�����D�)Hh�Bh�6���t��]p��~6s��X�������E�\0�G���/�I�b���\'#�7��.7\n{q�W�sS�n�vU�R��\nI���g���6���\0��]\0���P���c�w����%�Y��T.��	Ơ�D?L�S��ѡ��\"	V�F:>��d\r�\0�4��%��1��V�g�`�4�;F,��l��)��;}e\':eX�pb�2��Ah���}Bf|q���u�ׁZ�\'�|NV���h��1�pd����o���#�ng��t�|c�GS���ԇ�J�>����u��~3W#hp�!\'~��j�9П<�zgx\"kN�;7W��g�/�\\�耤9�LR�7�q��t�Uv5J�.��	J�q��~C�ώȺ>�M F��d�AbW%&���E�?U�����?�Y\0�:t�:�b2�w6�w\Z�O�ҳB���&��0lc9>�vya=<=$f�|��O�f��eT�Ir���ŝ^�Fئў�қ�� ��4�%��S}&m�a�Ox�,�3�N���VU������2T�Š�q�X	Bm�<g�}Ѭ9�B��N�}��v9�#�N�]�i�	�O�G�D���qL0VF�������kG���K�ЅeӵA|�*U��DJ�\"?,��u>��䟐��?��4@l\Z���c_�í�D�Z���k��ekYX �׷~\\@b�w6&��G�eWm8��zN�������B:��ۈ�\'���NavU&L��sɁ$�+�h{1^IP8���)�~=�r��~\Z/4��ɛ��u_}	�9��\\^j#�N�{i�E���U��#��{��9����	T(= �����|GÈI�����磿7��\'�\0�g(�cQ�g�:���Y�O�WFʯj��Z��b(ÒĆq��W@{����`��	g����]���p@f��I���b��)JL�4V6q_2uW�i[�x&��I��K!�ZL}�|%2A\n�����@�:��+��W�+��z�~��?�����/4��@��Bx��O���5�����O�8]�(\rV bD�9�)[$�.�Pl�T����g���cD=E� l/�h�����/����,���q�ճ.b����Nl�\"U���s�gW���&�жe�E�\n���L�2�,��B�d��w� �n\'w;�Q�O�d�s\Z��KN������_����S\">�}�� 0�,�|�ҧ�l����o�7�D�{��[x���Nf�-1Yy@}����s�\"����������f>t�E��w�����q�9�1���>\"�w��l��?���Q� I���O�?V����d�xY��;=�#��2}*��$FT*=\"i�Y�7b���\n��t���~6�ϩ�{�Q�O�p>��������wKQ�E&�r)S�%�vI�9A���KL��7�x��^qX����E�M�.a��k��y���m��`�LC#���{ԯ��Gn��@�K%���F|�rħc��4��7Q��]�4��??7�ha��ڬD�:�ō��q������տ���Ļ]E�1@x��t9J7I�O��]V|��ik�A�BL4f�:���$��V�U3�]�	#]c�`���!��G�L� �F��n\\Υ�|v���_��8���31�����������kêo5,��iv7a�L%X<A����Ә����23Fx��1a�O-5>��x_��J�����b�\Z�56R�7�u���Z$���Ɍ�(�+�.׾u��y�a���_\rj��\0��;�r灡V�9�~��U��\\a��\n��d�9�K��#q��S��6K�3�W\"�FӋÒ6��v	���V��N�gG%�7g�ԍd|<]�`��	��p�Շ}m5�X��&���W��=&yF!�ߢ�9c�+Qz��;���%g�;5��q�1������8\\طq2o7�\Z����}\'�i{xGv�,�Zt�\"�ۑ�Qr�&��W�5V���;��g.�X�@���L�I�B�����&�^��D��@_\0��������Ի�0�������_��tq���+La1�\ZT�t\n3�x���5�i;�Yg}8��k�\nҁ���_#�ǮM��E�&0F��\\7�k$�{�sa�bc�E�+9C�ҍDG�����Rr>��o��t�Hݯ�\"��*�9\\f�M��TQ��6���Q��	(ݏ�!Lt������z�hϑ��`�7� ¦���o�/�m��_W�������ǰa��q8 �c;�Q�NS���Phl6�{�@����gc���(�I�a�|(�5��?��?ş�8[���3�}�^J�,�c�t��]�ÿZ�p~p����e����$�3��2�d�����m��z��_^{��i�	;yP5e��8N����PF������d�l�;�S�eJ��|K�G��\"c�ѷA^��6��Eۋ���1*pz�����#���e�;{VS~�83oD�X�\0�4�@��n~��\r�<�ڪv(��g����������\'���@\r�O�3��cΚPI�\'6��Jo~��$�7�P�뼸��\r��I7J��6ºU��B�Eq�e3��I�:\n��	��_�휗ظSQ�\'+��6}2NT�H�^��%�?=Q���JK�ھ��_��P��g��I�Nr�i�(���W�m����s8��,PW�3�D�sj�Y�ͧ�=RH3��\'Ωn���2�����7a��+�7^���LUd�P��)�������v���eX;G�X1d�$����̋�y�I� �c{L�2��ա��Gt~h#��熾HV��Xs\n}��N��C��?�)�Å�Zl�찯At��|�)�ľ+2��ԩ�fW|/B���J�9E�$���\"�S�8ի�\r�����D�)|xG��7^���#�?N�O�b��Eɸ�ݴ�	K�W�(�?��r�yI�xe�?✲�i��_l2~����߶���<&����U�vuܰ�G���\r�YN!]@J�\"w��_-I䉒+y�Lb�Er���&L�?�&t9�Rߧm��A�/7��S�x�`ͩ��\Z�����x�9��*�_�~q8)?<��ԏ�3��P�1*/���Yy%rC��XƥF�����Ms���\Z�黚<͋`\'��_���ZT=�ea���Ƅ�,�\'H��F:�t�$`93J�Es$�,ɹY�t�M�����:�|��2��\"��o�ᒆ�Ǵs��Ú�-��M�9�A��d]f��)�9�W#yI��C�#I����>�a�c9�K͇Rq�\"�v��!�v�0�8:lš)x6����Xf�_����w�gC*U��H��Oj^���2m/3Wʴ��5�}Q-��G|&ԟ$.2I����[*/�C͑�����\"|�;<0��7������;V�ʱHp�S׋O\"~�J�J�DI6�	�ď()Xb�nG��n�a6l�|cda	��)\n���@�����	OPm�^o���шu�];�0l��p]�9������6]�)Wc���Nt�T�<�8ʙ0\'sD�Լ�p.j2��!��t�	��#{Ah\'���^���o��c�_��?��o�O|X]]�`X�~�b�_��7�q��(��,�����?�%�1J�\Z��,r�x�4a�4�*3簉=%�;.u*/$�|$:y�U6]���V�N��B��;�C���\'��Pq���r@�]��g�e�H��x�����@��ă�d�\r�a��:!��xU�-`���5�5����_�\n���@��39��x����Pn&h�m�!�=�G��7F\Z�V�q|Eю���ot`�,m����l ?�����{^���`>j�?�>�h��C��B~{����b�l��{����˷23�ͩ�N���`��[��`��Hms\0���w���%���c[�WƟ�|��Z��I�ё_�� s%�)�Z�ʯc�����s��͙Q��N!��Hޑ� �(3���22vӘ����J=�5%��#B�+3��ά5��+N��-�Ecd�]�ca�$���x؉Z#&N��)��CG�8�8��V�)i\0G�Y��^:������^�+9n��g�|���ƶ����\Z����<s��w����_j�`�1:�ƃ9���>)�wn�㊿�>R���/��U��(�%��P����T��K�ן��Q8\Z!b*\"U-�uO�a�3����y��\r�]��h� �}T�F�U?��B]2^�\\��f��\"���o��?����ZgD�e�?�h(�\'���D���d�^�.�`���\\4��z��ﯠ\r���I�;�,r����/q���v�H>.���6>�� Nr���.]�OXw��h�%�Sω(qє�q��#�Q(���%:CB��g�o\Z���U`#��:S�x���� <F��!ڀR��0�|W� �)�X̯�?�W���\'��Pt�M�(�O�[:]SKz��H�|�Z6�~���W�$>��Bdnp�n�-����8��o�e�����1��LpG�B��)ȼ�E��r�ch$9uQ�:�^�q�K%Yt>�I��P$��eRc}����A���T���\'X^]���n���8��X��m���^�C�`����(x�W&��� ���GEr��JPa-Ox��^j��2��\\�U�������Ɲ�`G�㞭G��Ú��g�]��}gSy��[����H�8-�V��ao�+��(� �=�aO����j��g�+�������`�#!V䛱d}�\"�O*&8��7#kc�A\0���8ܗv��1JK�YF���cR6O�����s��ί�ZZ{���d����\'�١nA݈mD_n���*&�#~~FY������I�\r)�I���B����6�F����İ�rs��a��\ry�����t�0��C�94b����tM�S�޷�����4���)1�NY��/��3����F�[��>ouN��U�����j�7�fS���Ta�w�a�wz��K��X��f�,�w�f�]�����2R��)7�-?r_<�s�W�f�z��̤�a��ز/�n�]��e�H�YY�O��A�\"�]��(\0�.����x��Z\0��R�qd>�Ϛ����u��/������v�_nz�L��s-q����dw8J�\Z&��u�ã\'�߼�MO��&�g�Z۟m\n��o���m��ޞ��İ��`���`g�z��67!�\'70�+Y��5��b�^�\n�;��O�q����c�1)���?����mp�s�u5��uv�ݵ@�D꽗�*�`-�]@�� �z��g��mI��77���?�w��z�~n���5�dt|ɱ#D�U����\"e�]O_\"7L�uY��^8^=����	݈����Ͽ�{4#�xo���O���\"48��o����/��p���ObYsj���\\C>���1��ju\\�n r���FI?[��ݞ?#*��D[�m�k!h������;�����7���:�G:���2fx���~;��M!:�ӹ��FS];.)�|Cv���C�e��q����=&�F���G��ylÿ�l��\n\'%h��C��C�7�F�R���dͭ�X���G�|-�+�Β�������������X��l��֟�9/Ma�)�Fޅ&4�R�v�߇c��4��2;��NZ����_�Cߘ�l|1��pGF��0�\"�,�q[Sf̽����ї��%�&0ϕ���w,I��x/���:��e�E�ߍ�+�J�W[|S(�CX��P��7c�� /���w�f+�������Y|\'�%/�G(�:���u	.:a9!�9	�7�#�S\"*��t��|�f�\r�-Ή��Ό	�ʌ\\����ϧr^�={-/���W�Α�����N��<�^�7&���;v�Es�����R��=]��8��n�r��~!�n�	���38��$���Uu�֭��O�!�U�.̉t�:�ؙqA��Me�3Cf�����4���>k��gAGW�eAn���\\\n�l-Kjo~�]1x��u\'��W�A�Źu�1I����7�M��dv���{���k��&,�z����a�x��w�C�N��I�A���+�@��&�����K�Ǿ���\0.�w�����#�\r��\\���؆`��K+���s����kD�׹��9\Z\0��{�UmkCT���Ĉk�te\'���M����S�z#G���HOC�1�����>pT��줴���d��_�����u��?�c�i��+1�T\'�_�ց��a�_��m)�0��Xώ����_7c�w��n��\0�-��,�z��̃FuUG�X�Q�ߑ�wД\ZI��{�Zo3D�Uode�\">]��q#$y\\{���re[uF����?,?��*x��\0o[ip��\r��f~:-�Q�-��ܯ�˛ �4��ű�V��V�A}#�dfa�[_\0��ऽ+�F�)?�� ��������V�7;\n.���w�i+|��|Mρ�޺��f��}}�Us�b����9��Z��2irk�u�<L�c���F�+�X�KS��)�4�.�۠05�<t�U�cE�Ǧ���ajਲ਼��!�Q�#@�Zn�;n���q�?���ɻ	��:pMQ�U 3�<��<\n���d�t���s\0j� ##��2\'?ds��	x\\��\Z?B��~Սh�鿁���6p\n���H�K��(L��k�	B��w�5��������k{Z���Z��uh��BZ�Ni��ųP��<���<�耟�,�˻Y�-��i��LS��a@W\\)�p\'�3�������]���{���*Jn����\\��ޱ�;���!�x3p��\n���rRhzzb�깗����%��;P�v@ce	�ˌ[ɮ7��n�� �Q�b^��e�ޗ�E�E\0CsA{Uf{��~C{9W����}���{������\'y]�G��\0��/S���gL�/�),�2x����Mo<�/��k�}n�;6d�~�+!6�v8jo��+���K��˃��Z��ٔ�pT��Q�PU����ұA7ݟ�2�������{���?z+�gv?��=܎z�!7�j����v��B?>����S������:�~��A1��(���q���_� �O��WAuy�i��iphcC����{	��ESz��w�iEZ,8���<-Һ�(>�(��C�͡_�.�G#hjb�\0N?��Lt%�Ony9�1��mt4C C��Q��[!|�,���P��ue�1�Uִ�8ʒc{�-�B���3	a.l�P��$n���;R�^�����lO����){l�������@{kL��`pT�RC�(�߾}��:C�V�fAy����`q\nBmPn7Bv�\'�2����触:^�ٷ��Yw\'�{���7/ ����ݲR���mZh������BG����t��7bc�9;��\0O�}��~��Zg5e��S>~��/�q���,�$A�=/���C~���F�GS�^Ʊ@O�w���R���l���\'lڋ�x\"Ҝ�#\\W�0L\'B狼�X:����[p+�\0�;�^�����bh]��U���c\r6�v��j���l�z�_[PƸx�\rv��>~�Q���gxR�LN���jz����U<���w�ͬ ���I՟뢸\r��Vhm����<���nq� ��];��+����ޏ��0�+��ب/#��u��,���\0�p�����f���Z���=�Am5�Ip�w��8��6�2Q���N�~j��xY+@��R��֦���>��[����\"��2�z���k\0Cy�뽼�1�Yz�\Z�ў�4�U�i�����k��C7�U�y��u��ݬ��Ȫ��O��.\n�V���{,�O��4htG������@~�A�\'��!����V�|h���?��D]m��P\'�w>FG^��,,J�#=�~6��-܍������\0�Kg޸��t���w��|�����`�����=}�!T9W��\'�ڠ�*lW�v5���������࠲�������n?�s�����9w�����G��-��R\0�2������vg���9�N��!c\\����m��|Ȳ�(W�v港��o{߄ة���)�ގ������s�K������Zʮ�n�wh��Υ�����G]Pr\'۰	�ݽ\Zۗ�I�j�٩�v2�);!��{,��k��lw����	ec�,	7�-���\r��hgL�i2$�|M}Y��FI�>\\�P��}���\0�����?�o�x��n�;t��A�7�-�;~�\\\0]$������`˫��\rSrny����S������^��U��e������w���~�N�4W����,o�w3�^^S��#7A�ަ��1�_ɉs�ϋ�b�KW�3t&��ٵ���b;8�솪�iPv;z��5�o�����b��}�+?AU]6Ԕe��&�[���̬�U���ʭ�V���ՙA�q��²[	���i���?l�zeφ����[�n���U0�	u��49�fI>WOՕe���v��޿�7;7\r���_�3PU�%i�`���E���d�M�S�v\"/n������\\\n�F��ho}H3X��@Y�g�d�ȏ�OM����\n�ZP[���e�6�6�<��r��Co���@kI47C��ڀ����M�y*l@{k��ٮC>*��X�y�jq`���ه�L�����.�m�P��0H�\n�0����(�/0l�s!3���a?�M7����~�q�1=L�%��g~m��׾�\')[�s�D2!�V	|-��ّ�~�2�|C�}��+��iZ��U�X��s��`���^xn��#�m��I�r�O�u\n1���f$�}��:x�C�z\'�G�1?�<Lb[�@����t�/�?�跡O�瑟�ºۅ�<����	��c���Q����6�����{�,��z�~����CO�F�]�~o�5q��K߿�h_���ix<��K��X��t\'�_�(7�e���\\B}t�@p\\�QM�\0��A�ӫL4~����g�-7��6_�cD���<�n#�06HzW}I��(ǋxok2��x�5���Ïb�/\'�:�w0<^��q����3�>z�*�����g�п/����By���\n���P���������H���a�ؼ]�\'������4��$W��HG���4�� �m��X��\'���\0ۂ�@ۂ�۬�X��wۂ`:=?��</=���_|�R2=ԓ���d_p���PοC�ciW~:�Nq��O���\0���me����dZ{M�]�]oۼdۜ�k�U=%��%�YAN��I�vMw�i%��l��l�>x^#/݁���ʏ�΍���Oq�-H�t�O;��E}{aA���\\F^�&��O��w�i4��;�G3�R�E0Hٜ��*���Z^��Sn��zQn��qġ�j�#��m���83��O��:�Ѝ��fW���w���[N�I�v7�v�a4�����ej>W�+�㐟�c�b�w;�6�ߎ����P\'Y�l�fO+��dW��n�萟�gZ��mM����X`o�RAG�Аv�Mء�`�<���<��|s�u4��Έy�		���������k(��\n�y0h���]�@{���D��7��Ykc��T\\�����}a�w�B	Mz��C7�ZD�2n.��B��Y��|S�|.��Y[�ԁ����������{�IV�6Sv���#[!�	���L����H�\r\Z�����ʚ�/�޾�?\0��ѐ\r%�sa��;��6�kbf1��L�C��\0$��}���)rYdK��,���C���s�翁W�����i\Z�\0΀�z����h�h��`��?��~����zЃ�/F&*��\Z�1��-1QPI�!���ҭL�u�C�\0���3�>y��o�O��O��%ٺѭ]�%���)վ���j(۹����Mw����׫�,��}��a���,ճ�����N5h�ӻ�9!\'	eb^��&K\ne4)�96�J���MS(�%�1n��g��o{�퉴P�i�L��\Z^�M$�5��1S��P8*q�>�t�2�*oW^p.����)O̽Sdm ��F*����%�3i��~J��LY�>WKϻvP��Z�~{�W�5/k��%^��~0ڲ<}�z6~}���F_�����f�P�}���lc���d����q�H�m�p[i���6���9Wo2/�Felv��}�v��LEx.����9#��8�}2r_���o˽�ېՇO~��kp�o?,���PY��]g�{O�L�.�_�!;����������t�P��`�<�V��f,���A�宅R,�|^;�+�9x�&�ò�כ�s��t���[�9#�M�}��-���s�׿UA�P�n=�2���ZϿ\\>.��;G)y~#�^����j�n�FO�{�\n��������|��	��`�T\'l���O�sx{Q�;,�񂼗�#�\'�^�ѼsK�\\�s[��8�#����|�-q>�\"^Nr~�v8��E^��o:4:��g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�?���)a���\0\0*mkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}+��(���H,��\"�H$��\"#�X$������,�Q������ԈZs�>U{�	�.�.T��}6�\0ڳ�-��F`���p]�k\0߅~��b��\n�\nО$�wݓٱ����|s��Co\0���A+�q3��lO�x�@�(�0�a��+?�	��T,�_��7��s\\���Ϙ^Bl1)�C��+�k�(�FyN\"8��dPC�_9��>O0&l�4��Im+���n�w��G�rŰ����<Q��q	�	+����H�}����e��q���~~�[).�5c��6,�������m�uO���9p\\���<//?����N�:��Mp)� �Ĝ-�2p�\'�uKq`���_������/���6�4<~\0��77S����N��BQ�����맨�uM��{���5�%.B�NɊk:	k�N��m�9���*�u�U�|2���%;������]F�aג)��RE%HWc0Mg�>��)/tih�f���	ѸX�>����E����)��<,�6�s4����5�z�b�?��J���\\<OM%O#(7�6�:�=	����ӋYA��H\r���L�s6��M�X���BcX�&ǘJ�te�.�����	3.je(��?�<?�-1�$p�O=\0�x\Z����	]<Jt¡�Vg��`|I,<丕}�F�Qj]�o%[Pa���6�XY��<��?�Yoh\0�F��067ၭ6JF�G[��wv)��7?,�@w�\n�nM�Ǧ�m��k>?���L�j��=���%w�Z�izFTx��$��kP�8�E��m��	jAO�����ހ��>~������؆���B9���	�֤8U��KC�v�jb�L���C��y����;�mjP.� ����Dk���w��U�E�3�ܨ�����8x�U��J���s����\\���ɟ�+;}s�F�Q(KI����Xݛ�ƨ\n�1���+K����dX�];Jģ��c�x$��D�׷���X`i� ���@l̏�rn�m$���^�9΄�zBGϞ�Q=�nf�k�D���e;\n<���a��>,�⢞�j��k�0B�[p(��$�\0��Ǡ����p�4n��q`�XƓ�	�vϵ���.x�Hn���or�J���5�����H�u����뇗�f����a����[Z:><�M@J�9����$�q]�\0}=H�k��3�����鲺t�Q�=�,	7���߻����s\r�>��3�����6[��g���RL�؍����?�(�&w�.7C#~B{�]��\n��U�W�7��1jk~�e�cG��r�����D�.=��K�����@�W�ǱM�0倐�����0�\\��x��v�q�NZ�>#�\r����BE�	��)���&y�A}t�?B��Y�m(�WIp�ɱ���|�2�+���\\2�� ��)�l�8��tl�@Z.B�����e񅋍�RS��ƃm>d�I���l���\'N\ra�dĢG3�%���#�)?��$s�	_5=��Y�BR#-k\"qGP-�e�\"�f����%֩-ϓ37�����8�M9��ϊ�,���_*n;H����EBƱ��cl�~����\r˝[��/sa�g�IE2�,z�1�t�:�kL��������ș壋G)��{7�o���nd������{@r�P�>�k�w�k׽��#�kXfy��E����A��B�9�uM���4P=�_�l���gW��؇�N��#�_n��G�pp,Z��Uu�6ȓ��V��Ӱ��0EK�7*|��]�{��75F\\�Զ��zQ��z!��	uH�>���up�����T٣�o3P)���[�^�6�����` -�d&�*=�%���fY�<�^��ط`_6����|h���3ء>��2 P��q��7ώ����,Ns�j�F�=B���`�큳�C���i�U�)R鐏@L��Ү�����ǧmb<2FH�Rq��ùF�����X�i�䎲�Om�GA�����}:�*\Z��u�f�:@ʫRH�.��6���6�j���c�GOpO-\r��6H�����K��J��U���:�Jǃ�����v<gz���� ��1F*qm�-;�\rI�\07\r?��O�(Yr\r�de�\n��F�\r�	��ѥ��r��H���a���ۡ�>�\0,����3��D�Z��E��Ʈ�qq���7p�?��Ȍ�K����%ȧ$�;�?�Q�r�6�pP7`�a����^=����R�_����)m���>�D3#£�_\'\r�I��ɭu͋C��-R�ne㯄����ss���L��<ȭ/��R)|Lt_1����<u�}E\nD�zl��$H�+�N_2�scۯ-�rH�V.�����\Z���֏\'���(}�o	��:]謧�6�Fhlw���@��z�{6�P_�?�\rE����h���߹���v��K�/�B�\"M���h;������б�o��)gRm �$�5�, �E�x�(?�:�g�U뵅F�4���� 	���߹�E4��!��q?l���A����Yv��s:mR�(G��Z�y�Gq�+w0)Nz����u�Y�-�&�����\"�Y	=\'I����8��{��m�L/~�����!�����.�B�����A=���缱Y��|z��:f�#¬oh�2Xj��ǼI|1��i3A(|��vf1���\rNK���L�ͫ\Z�.����?�r�]�qBS�^#o��.l�%z�⁋\r���Y��~i�䔃P�\0�q�u&7(��U;B��l zF�x׎����M����,|PfV�֠�k��\'�N��b̔/�$EN���\nHA�i��Q=�u-/T�QAD9����g��W���%YZ�\\���aԥ��5�O�jr�����u\"9��B�zp�̬�vl��l=��ɸY���y�ܾ5t�����mE��z�+���M���>�L�k�=�rr4�����/g��E�r��~P��nB�[��\\g[{����g\Z��Y�vR�W\'��\n{Fe�m1���{�w�L��;�7�&$���x�c����0����n�����&��u�@5sC�Cձm��8H��ef���t��<PJZ��@����������4�K|��#`}a�kRN���\'�~IU!�k�W��L��Z��D�NK����̡U��������;��g��L~a(]��!Bjv�(�f�������\\��B�}�AuH�R����\0�g����\ZM��<7�O��:���[�m6u�v����;3��=���w�w�n����������3pK��M�������{�.\0t�\"��nt�\Z?��di�b�C6��=��E	�����,��ѮO�\n���0�h�v��G��;=���MV%����ʪ�r��\0���4�H\r8r���K썀�x��A�:�2\r�e�.���ݟ0N<g�����\'�����6��%��G�1�ַm}�^j�n�ҽ�S�0Cz���LX�3���U���M;^��^~Xc����a\Z�vGHu\"��\r1��kN�K�T�?,���r�=�܎�X}6CBW6ۻ\0�F��\\�3�m{4!]9�ử��J4n��5J�s�w��^�D��h����z�������8���P�]�z���1�x��~\0��J8#c�%�Ͼ��cF{d�����o��@w�0�QsP���_́� ?3yB2Đ{|��5����}�>x{q(a���тa�?����Q�%��l���4�ςxmWI׆�G���C�\Z���1���k�Q���3iJh�,�������\ZK��R����������O`���ʲ���<!�[��Nw���a�����Z���x�\\Rtv��^ZJ��a\\(��Z�PE����� 1��ޣ�h�����y0�S\0�L!�y�QP̞�#R@ӱ&4�a�9\'2��ċ�I�E�8X��Ir��\n4��*y��b��˼�\Z/#�\rx����;�2R~\0������O7���h�՘U��^�k�\r����(侠,���2���)�C�:(ِ;�Q3>��4�)�%���b6�B8�\\��\0p�����e<��S������+�js��p����%<&t{3?���|N)p7b�����?�a�i�D�Wl�����X���Z�>;u��)�ko)#W���S�n�cR�x��{[�sXv1��95�_�\Z�0K�����ՙ7�>�\0Tp�5���ٴ�l\Z3�S�\"؝�LX��睫[�5m�����Q\0=\"u}���pϘ*x�b�Չ����#iM+��@�Z!�	��Ϯ~j��Y�ݬ����$?5���mt�u�] �%�@��݅:4h8ۃ����tu�3�;�\nΑO�1A/r����\n��R*5������i�&j#Y2:�$Z(a�d�@�>\'z\n���L�����뇶��6Z���8|`�6�\"�X1�_�z\'\r�F-���я�?��X^�A:?1�;��h/K�VB\'��vOn�FS���Ƥ����Q{=kh7��M��wXQ�p�\\v�͓�O/��.����\n�N3��HKR��l�K�\"�q��^W��h��1wt��h@���3�e6�N|������I;y��?8t[�[�!����$,ήL��e�\"�z��%IކA�k��R�l!3u�8�ځy��?_�W��)�AbC����O�!rz��a��5S��n֗���#�<�43y��6\"���R����߃C��Q�&>�[��#\nB\0H�ǽ�{v�e��kO��T�lq(�UH�͵h��ݔ8�,@t�����ՂL�{p����/�*�L\"�d_y��k,4�G̖��bD>,��.ok\"�D;�|7�[.�D�C�A���#�i���l����ϟ�I֬�����D�q�]+�eE	��_�--����ڰc�����^���L��q�1~�C��C�����C�9��gN������\Z��H�8Bkh��J��#Z�-`�V�o��M�a 9r$\0�պZ-�h�kh�\n?C�$�	�^��tď��9d(�8P݅]ڶ���w[�wl��;��d��n�׆�o�K��d�H\Z�ބ(D������In�I� M���_(\0����\Z����5)6H/���Y�1�� �QR�k,n���XH��ʉ�����?>��df��&6����^EJ�m���t��{�C�����C�c`���0ʅv5��x<��\\9Y���c�����}1�06\"״!֏��9�dl:\'��1H\"�<HN�&]�5���6�9�!I�1;\"����YxA��K-�y�m|h�d\r�\"]������U�.ak�gbbw24�������j-� Q���\0Od�-���:N�	dG��˥M��������I	V�G=�W�!r6�w�H3����p\"��ۋ����#g6*x�9��k{H��<W�����BQߍO�MV��{Kh��^<�F�W\r<�L����:w$|�oY��-Q]<ʫ��!�!垹��F�q@}3f�R�%���oĿM���r�D����+�N|�Y�Y���6�j�r1�1k4��i\'X��f�\\:�e�޼� �~�P9���1�ߍ��\n��&7�8Q�ape�������5 9os�M�y�	�K-��u��u9��Bdx7H�V����&�_���!C�lgL �04���yS��}|�qٳ�k������b�s:f�\'/����㼳@!�]%���z#�=�J�s�`3�W ez<�PIG�C����0�@�4�������5�5g��x�c��T�G���U�#�R�CC�?tdx���L`�Ɓ8����dgsT�?M6},_��� �\\�k٬���lt΄l�s��:m\"2��5�be\\]\\�˛��{xa�Lo��Q�lPwK7���?M\0^a,�_�lb(��1�?�����3��݌^7���:���ރ��^�us�ϚqB�8*���h�Gx��Y�C�m5�M~�{Sg�9n�RX�C}[����hO�tC��1#W3�*��:;�&_�G�ۂ�&�H|������5�L���<4Ƀ��\\b�������D?]fM{V6*�S�<����e��0,�!��\rA��ؾ�������K��m��m���ߍ�r���O�oC������2�\n���#��p\'$�F�˿@!�{0�V��YW���oe�,��\'��H\'���`�r�1�����#�ͿMRS�\Z�Y����ZB�h�|�x��H�@\r6�YziWl�wQ��}�yqs��!`��~y#�-O�Ց����I�X���m������y�����|��*0o@��]ۓ�^(`P�q��v��ef���v�\'�OA=B����݂p��C�J#\n��֞����q��5�\rR������wV&�)ԩ��n@po��]��{3�v�:�������Y���f*aW��_�&\'\nJk0n����D�x���\\/H����D�u�qZ�\\ڌG+啵X�Z�T>z\'7�Q��q������Ɍ�#K�R.�/C��V��g�Q�Ȭ�����\\��`��?d��1y���uM�6Ƶ8ZX]8��^p��wQ�E��\r&�1frR��Ki����$G�����ݜ����Е���h3\'���������{���;;�~F��K�37�k���u<p��dʎ��+C�����R���Mz�Ə�7)n\0Ҁ���� lEGy�l��:̑�I���o�B�<A\\���\\6�d���F��q�ϡɅQ�[�1<k���N�>���S%|��Е�sTu�le���b�A}A�����ʹ�1��0�A{�K��ʘӺ�tj����dLI=r�	�PRg����_Lb�R���\rŞ�l?�␔�)!��[��F��o��wi&k^�CV(t@p�W2����{h�x�H�GRn�͉�eCb�xԉ����6G�������Q��d27\\�ثd�S��=\\�F�f*�0�ۣ\0�OP���5(r�ZߙxQ�Z>�~G�AeN-����jY��7�Ҿn;�n?ӹ\"P��x�}���\Z/�N��\0�W:݊&��׾��:x\"ꭥу;��R�펔���c䛅љ�������ElmG§a=�h�¨BG_�u���YnZ쫭FYs �U�\"zM&�:��Gn��u�.�DX�\Z��5Xn�����;�}�ԫ%XO?�~2&����Frjj���8��yA���*�W	������I�����9/��u�b)��Z�l:�s�� 8�5��J��>~�i�������I<�k��¶\r�٤�^�S�x�[����s��GD����(�\0+��\"E���HnֆA_��\\F�Z���%������?��4`���w��_{�7��\"��0�Y��@�f}�������PEj�m��v:�Q������rN��[w���z�*���5�c?�j������f�7���?K_�\ZP��\', sZ(oT\r|��Ó\\-%�蔒�h���y������\\	cK/	˧YGԻڐ����z&c\"*�(,�����y�E�q(�y�[���q`�a�7Xļ��~�����R���/��{h�h���\"�g��\Z=w���ݠ�՗���?����̶�uNh{�g��?tq���m�,�u�[�Y���ot��+�!�hf��.2]�ݹ?�&��wA�R���F�ľ붾Ue���%��d��l�i�����q��Ms&�6�X�w-&�Y���3(���G9��{cׁ�֬ǿM��;����v����n�\"���b��)�<�׾���e_�1���p����}��11��F#��YX��p�q\Z]��s��,[�%*&��@�D�f��ҹA�ٙfs���,���>��3Y�ԕ;�:#hEL�ם[ROd��^G�A�˩f�~Y!����E���n���0�~��/�A��\n�K�m���>^��WY�q�\"���<цF����*c��:\Zx�w�|�͞w��%�ehRg�������d�9��̕���v�3�v\rDg��h�>>?��3�h�YDk�gC�(ʹ�ԕ���S����Ԝ|�\r2Q��94�(�?OG�Q34�\rf�cc��PopT�Ya��W(�>��@�t�X4�`�LG�ٞp��Ʉ�a��Űl\\�[9�c�26��UM6f,����\0\'����C���4�i<D�n��#�x��г\rHz5�[�\n�_������Qt��m�vN�C_��`��x����~\rMb\rs\0�PEx���؇;���cW��*n\\��?���׿v�:O��3@f����R�&�e������m�[mٜC���5f(�M����Ni��YX�xШ���=�4\ny�HO�<�0|���3����[��B	:d1�\"Z�O$+Kx�i̒=�s��J����g���~�i[Rz\'����G�#�v��}�>�?W~p�sϠ?��k��A��K�rŵ���k@�I�|>^x�s�?�\\��`,D���̒�����5��W����^����w�D��M���Xf_8<%|\08_왉pP�1����W��lm߃���f?4����:��́�_�Ԕv ���M�;k�:p�����_���sj؎qw]$F��}���y�\r���,b\'��N���=�o�����0,\n�������~��M����\nY�R���4�6+!��}@~u�j�ct�C����P.�Y(�x�׎����z�?70�WXFܣ�o�����3z����0���c8�R��G��g�0���T�U�\Z�򄽻��w�\"/4��֏�����C�Q`[{O���c�n�]��+�{�{�����N!�3��<���V��yx�,!C\n�b�.��lf�����\'���\\ ן�����gu,μ���w-/��3ۥ����N���X(�c\r����o�MD�s��a�#�#0{c\r����%�uDWCB�Z�A��Z6�,؏��x�(Z%�����w����HbhTb2��<$��*c���nk���_�א�����#{D+B<�!���S/�g�Ï`�9��.^]��ß��C��+>��3�+��5��]�q����p�j\'\nr�9��FDȬ)~:�����9Gm��x2���-?s�raG\"yvU��pa;R�����ă� �A�\\&���\n�?�#��n	��0�ee����d~o�q嶭�!\0!ǲP^H)>�o��ȑ.�ļ�Զ=Hy�7�S�-M�\n�?���8y�c���ߧq�|�#�5\"�2Б�l�m#��U������e�Τ�V���bM���͘�jA�c7�Z\n�]>4�gb�\n����s	2WRsKg�6���\r\'s8qz�TT[�R�[w�\0�)I��9�5x���Wj��\r#�!nN+zP��ڔ�	�Kg���TE�,�����?��{�^R�Dݥ=�R�u^zîc������&D��\'i74�S�J�ߔ��&H��U�G�[���cr�ͦ��<����׿~��4}څ��h���;���lpAZ�%�X�Z;t�Q?������y��k1+Ƴu6�[������D��c4�Ɯ����*d��B#!}��e>�samh����G3c^��8u9󼵕⸈߂�U�y��B;f\"Y�i=�D�=����4��&�����|�C���3����g]�~���WgjhSIXU��\"1A5Fr4�{����A��lj�w�T����t6<�/N�� �\\����R�t���a|�i���>�T.�Wo>>�x��ϯ�Y���{緷\0m,J�{gg}�v~)�]��s!?w���X�����G�F��l!7��U��|Cn�fﳅ:.@mq%��臔����Ru?.��:��aB�ֺ��E#G�g\'yX�D��u�SW��ǊD)��21�ѵ�V��agW��P���q����Ȓ��s�?¶�@�g\")����s\\�T���{��f3g��o���^w:^�\"\0��{��d#�!φt�}�,n�yWFKv�X�4��|<��B+���8�i=�-;��X	5l=/xl��w����n�]� \n�+S�Ӽ,{՞\0�/Д�V\0���+<<\r�����o �����ԇeNp�^O������OvqR� �wHF3�݁�=o��;�`~k�R�wC�����u¦�k�jE�|��qϩ���KV,���*?���xk��}Q�x�U���/M������=��հp����=犐�^x�Bˏ���Kx���@�[���I���YB]T��➐������Kq�.ὀP��w����AG\\��W�ϋ���9���2S���A\\�Y\\��y=Ǩ�Gj������բ�M�@\Z�tԂ��vD���z�+���Bĺ\\������լ����6��k�6L��ʦ�R�_r�n�l|UAϯ<\n���|��!��;��8�_1�g�sލ��C����� >�VB�~�,����˘_�&f���jp�/W�ԍ�wa\0�O ���H3�����I`���u�����1�ͤ��������+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W����ݚ�w)��\0\02iTXtXML:com.adobe.xmp\0\0\0\0\0<?xpacket begin=\"﻿\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?>\n<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"Adobe XMP Core 5.3-c011 66.145661, 2012/02/06-14:56:27        \">\n   <rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">\n      <rdf:Description rdf:about=\"\"\n            xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\">\n         <xmp:CreatorTool>Adobe Fireworks CS6 (Windows)</xmp:CreatorTool>\n         <xmp:CreateDate>2016-04-03T17:42:39Z</xmp:CreateDate>\n         <xmp:ModifyDate>2016-04-04T04:59:35Z</xmp:ModifyDate>\n      </rdf:Description>\n      <rdf:Description rdf:about=\"\"\n            xmlns:dc=\"http://purl.org/dc/elements/1.1/\">\n         <dc:format>image/png</dc:format>\n      </rdf:Description>\n   </rdf:RDF>\n</x:xmpmeta>\n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                            \n<?xpacket end=\"w\"?>�,\0\0 \0IDATx��w�]E��?s���7��dw�H\'	%	 �ЂT�E�U@*�DPTP����Hh!!i��M�^o�������XĲ���9��<g��Ιy�y�#������}�.����`�ٰ���^�\'��^g�Xq7�q��,B)@Ѓ��S��.vY9���E\Z�J��n	�+�Mk����o�&�㾺A� ��}��3=N�}��~��L��Q=.f�}���B+A�HB�x������G�����Z:�\ZAH��[�Q4TdP��J��v��t`Y�-a�\Zh�C����}����$��!Zp�����1��HW�x�v�t��Q*$�\")�Y���V_�`�h9� �c�+�`I|<�\r.�H;\")�M�$Ua�H}�[Z�lV�:���Q_j���`{�A���@���ß:4�~�9�u��P���E��,�	�Tq4U��̈C[�@7-ҊN.�T���\0�/J>��9&��QcT��(�<�	tA�8�N�3��qҪ�1SY��]5��C�����]��0H�q�|�t��;�+f��=]�V�-�t�X��S5U`\n�����	R�BWP��L�+.Lt��ƍ0]�@(�	�\0RO�\"FoV`�:�2��8�B�ϐ�\"���^֕M�7�Փ�>��y�U�t}�m5��A�����>�\'�]\\�x��yQ]�qq�\0-ت���ݞ��Ml=�ne0T�H$M� t!�}�b l�,�9B���O��Tq%䥉�Г�q|�*��AT�`��;�8��\'��K7�k�޸�!��ڸc3��Կ��/�c@�΂��5��d&{T��Ɨ��RG��\ZYa���A1ۉ\Z�H�\Z�r\Z�|��\n~�((y�K@sA����zU\"\0��⁧���]P�v��lN��-4�\nS������\r�D���K����&?s�d����/�;w��8b�3W�o{鬲�NT��X\Z}�F�T�\"EbF+q-�bzDT���T\0G����\n�R�CE� \0�W�a�t��A\n@�\0�h@��TiMU\"��?� ���D퀼^B*jؙ�I�y�����~�cl�A��D��++��B��{>�h�hfvcD,\\ͤ��$Rm��,M��PN\02���X\Zh�R�og��j>��X�~�D�,�4v�A&�k��#�E��Ŏ�+(��0�\0J\"OP\0�,J�|F����otЧn�_������*N_���Eږ�_շ	��Y:\Z�(�,�D�X<�V\0GU7\0�+�� ��W���W�ASC�\n$�����ދ�̃���~��\r_�� T(� L�������b9F!NU��S][�WU��1g,i:���	;>ֆ�/� �?F,�۴��w�������rj)�!kc$�v�1���\\��T¹t.\03\0���\"\0�4P���@��\nj��q5O�h*膇�J��l/@Q�jD4�& !b���& �#��DA+�y���z�A��B\n�*���zUz��0ᔅk��c��^�����\'�Z�٫�ΑQJp�L\\��Rju��`+��8p@с<(��Ԫ\Z�Q��N)\"��Ux���^��b�i���W�X�iiWb(���N\'&���zd���l��RL\n�)\nxZ�\Z���o|=��t�>�f�ST�;K饖�t����������ߞ�x�Us��Wb���|X�.�k���Ϸֺ�#5�����\'�Giy;�ң(@*��Y� (�0@�Cg��킢Aѯ&�\r�qds�|j�S�O�r����{�)qR�f�/�rۨO�WO�lyF�_��\rGg4�� ������B��0+N�D%��j��@/@�_Fګ!�#��Q��!��������NS�M�������i����f���Ra��%��\Z���T�= ����B\0F$$w.��\n�E��.����w[*/8�o[ې�4�Ȏ��\0t|HSc-�Rv��߫Ǖq��ʩJY��殧1d3(�T9����C&; !Cg��A�v+Ð]I�Z�%U�Hq��_�}�w����\r:���A����-`�	�~$�/^��W�n�bHqu��k��F_2Gy�����VCg�)���[���Ƀb@�Q��\\u��H��R���D�%�F��\'���S��^)L���\n_׊+T+�����1\r�.x\Z�D;O�n�t��2_\'Z�i����3���I����}�D�_(�@\n�m���Gϟ:6���d_ۈ��b$�U)����1���3��A�P� �A�U�E�����c4�UW��tة��*m�4����6Mk���^e}����\"ŝ�ie1����8�]s�vt�����K�6zh*(L�u�_�W���:��0H��c-�+7�8Bi�`ؐ�oD�[�l�&m��+���ܭ�}�j�J&�!]ѻ�G� �^���-\"�>C9u�v+����|��~��9����t��ĩ�]^��e3+���W �$ף��9ؑi�\"WF��M���w�q�Ĩ�=��͔(��{)��$���]3릌��Gƣ�������!�<���ۙ舖�tWY�[_j:�Vr;���*q�CN���o=�J�����Yj��[e,{?�L����Z-���_0\"�E�pE�M(Bz���l^:S�>\'v��٬d/Y��n��3��A�/���x��3���9%�VL����yǃ]�#��ĊYz�a��:a��������7��!�{�\0�?@$���ʋ�_n5�_��AM��P��2���	\\���]LWG1vZq��V�$�h� �	I�+P�-R��B�9�C�=�Q��^|������*�l�q�đ3��:��Z\r��S�S�_��l��-���c�����v�mp\\gtem����O����������}�o�� ���1��\\���;Ɓ�/?���pc�y%Vt!���<a8��@:?���5Gw��n�+��;�&v6�\n%�g�����	�j�^�~a��~�b�?��ۀS����Է+&�?,Q]�k�e\"���5rZI�ؾKK�Jm2Ƥi��Zy5t�iv�� cN$#F޵>:��f�d�\Z4��!Ӕj.:z��ݻ���5��o}�s6���ڗ.�,��<x����	����략������ӽo�U�9��Q-����^�i��#��ޯ��ko]���W���ze`?wVIf�)	|p�0Զ����R���H�:�z3�-�q�\0C5H�|���U�s��Oo���5�G];������]B��\r�w�\0V���+�R�}?i��dt��2�޸�[�M2������U���\r��5���1;1�. @z�+�ZtƏ��������G�� $8���l�\r���9���1S�:����Ɔ���W��n~h��#[W��LGgw����o6e�C�\'ڱ�{ŮU����S{�>c��C�9?vޗ����S�.��v[�8��۱����N��\"$��I���J3���k�UҶk����?��҈�nBxbI�೻|���A���������a��D��Ș�xe�m����a�K�@��RMh�S �� AR�rz�m	�.��z�������@�!�6rj�	Ma�U�w�;��p�<�O����<t�c��}����y��#��:�=j�����q�sw}{.�	_�����R���w���F�r�Xq��$��4�3JBhdU�3I�i:z���%�bz\\7�1��f�wږ�K�����cg~�����`����ZYh�a�]�\'�QHD��0�� �y�&8zx����t\0V|�t�Sh��0�Лg�=z҂��P�%�z�S���ʹI�����Y�~�c����hߺ��n�0��>�?�__���\ZG\r;sw����2���X5f��7��Y;��nh���D,��CvP_����]TWnaTe����f�1��H���@ʹ�(��\'��Y\Z?�M�m$����[�,m{��UٝJ�+�P擌5Sj��$<�?<�?tU�H�?&<\"¬�<�S5��W�x�y���>P62-�=x{y��K�j����:�q�OO�o��Q���<׽���=G��׿ʦ7���?<4��sw�����V>f��Cʼ��������?��\Z)\Z�G: �0/P�/��\0S8���-�B���>���%U�]��o4�o��@�߀A��O�Y��+�����L!��B$�\'pA������_*�e�Qw]H�����#�/��l�y�h#FT�YQuDI����n��^��5��ξ�}�m�c�?��7�\rZ���T���Q5�\Ze���T�_^3��髩1�8�6Κ����G^U&���`8 �0u��t�#0D�$��A��!�Ayv\'�;��⮕g\r�m������w���x��y��7����G�	����{w=H���T��R�\r�Ύ�5ٮϖ�|2�2��Zb��t�|n5c�]W��c�1_���$�WW��^��Q~��C�j�`�����{{y�u��ٴ�b���#FL��@��J���U�;���1SƼ��o\"1�W�.n%e0�b��\'�1��7��xQ�n6o�恶�o���.��t����D\'!�<(ut��2�����\n��3ĕ<-�^T��Tv���^���_�tSF�ۗ��\nv�J\'��Jm���C�����]�� ��0��􀚆��2�vC�\r����\rrH�o�^1�69P��7@�@����C��Y�R��ο��x�5����x����u�� ^�̝cv�����߹GXec�x�k+��T=B�A ���$lUE.%d�� ��Nz!T�p�H����	�\0Eh�9)�\n ��LUA\n.��D	4� U�G:�)�t�X��͓J[�Vj��6�X��AK���QIG��ՏN�L��{]9n�ԙ5�R;-Th���<��Q�km�єn�e#��N9��%�\\��mo�;��\'��l�p���p��;~�q��|\"�����7-���z{�����M+������xN~DI�s��~w��D�|���]�r�����HW�q���RIGK\rC���7>\Z�� x�\'���w\08\r�\"�*F(���aA`�������������*�b�ˡN\0�f������\Z�~[���S/\'���n��M�.uǞ��Ԓ�͚u�E۾�4�P���\r\r6�*2=�=���hL5�14; P����T<&�T�(�j*ҵ�.X	���P�ZDq!P�\n�I�n��{��ET=��#��G�;�i(�D�9�� �	�Dz�*Q\\������\"(�f�hC�Rk�(���ӘF���1�߾59e�?�����/1b���O�5�9�$��RgN�C-��@g����D>xH$� �0��h�y��	1��bC�<;Tʉ�H(�� ��~����\n�	F2��0��`CD	�t3y�F�Q�燿�f��S�C�K��IC���$��XE�����C�n=�םُ�]�)D~ݫg�~sNej�ێ�ۘz�VC�Q�1m���n��M1#Q���K%�dt�V@D!HY���o8��RQ�dA�B\r\\����0	��(!2g�o�R��\\���̨x\"�4\\D.�0��\0?�SPt�P�x��\\�H���T�&��,?���9�ڏ��֮_~T��\\�[O�N�:O���OÔ�Hh+_�{�6唞]�]:}��ק7�n$��Q�x�����>�b5�\Z��y|e.31��y\\��ql]ӆ��bU/���\'������;��z;�Tz:�x�W.�N�,�ۅl�.�ӆ�\rk��jA���1-X���*���4�z�=�c9m|�c�\'n	�,��\\\\�/<M����m��@I!<.�d{o\r��GB5q�\0�E-}%t�F\\ȹ��A+�����\\�E�љ�Ah��P3 �i�J>\\I�J^;�u)�eZ(��C5]C�r2�\0RD|Ӊ�$�F��P��^�y���~��s��^1P�̻�}ɳ�^Y������/ie^�4Q�:m�MD��4.Z�#+TL����*��$n��4�\n���+K��I�	��\nC��>8`\n��H9_Ű��E�s,P@%�	\n��⁥�8Zx�4@ �\0U��\nPnJʬ\"�)qS�z\"�w�u��?�\\��Ǟ�}��_UP���]����)3����gu���M�����o���y�}���Ϊ(���x�7Ǌ��������Oz񪳾�U!D�����.��@���7�N��3j+��D��\r]^n���V����&_�����72�r�3��΅g�嗯��o������+/<;\Z�6���g�^�;�y_^����z�/�vn��<��c���1<����\\��/6��`\ZQ��0�������m�W]������n��e�5�{��}��y����,^Q�����s.�����������8���/�H�������X�b���]y��v\\e�ʯ�����[_�̣Ͼ�){�r���>����TלX?�>;����m�����\\�gC߈���`�CuW<;t�\0p��������\nd���\"�\0�$WT@��n�|N8��3e�Z�j����<d��V��<ZQT�<�b�%�Ru���b\n�^��1����=��ه|$#����\'�^����u�Q|#J.E��j�@MS���4]�@��$��af���,�\0�P)B����\rq�B�]5	�6(1��X���:hA��S��7�J	�^Z�f\\��\Zi+��)��\'��Sa�YW���\0������<l��Sرue���ֽj�)���W��~��7N.�|�7>����	5��~����f�)]fg\'lڵ�^J�\rOh�n�n�2����-�\'g�]8t¾�λ��Ji���!�j���e����]-��A��[�@p��3�9��Ո��+�0a�\"�5�7���%e�j��:bɳkG{��D�Z�����M�-3�=�9|�C[{��K�Z����8��g�zǆ����t������Gw<��/�\'�uh�.��m��}63>3�Ww7q�~�:����[�<]��Q]��V���m�j�n���������[�tm���m��v�����O>j��no�g�0m�Y��쨘%�]��skO%֋���Z�-QE�Ė�[l�	P@�Җ)�YP����\"��� |�\r�+d(�%U��/�sp�~Q�˂z,�Aj�����Q=���>eq��!k�iuj�d�Ĝ���b�#�İ�C/e\'�2+^9�����ӫo�6d�TַVI�Q%���d*�x3\r�&����K\\\r+t�5$�����@\r%�� BY����7!p����^�-�N�pΥ�y�n(��y����s;5��-l\'�a��+ �5q���>���O�ɻ.;�t����5F��G�t*Uxt��������5�UV�;��}�f�}g���i��#�B��Pe��_��U�(��W���S(��UUTఆ�5Ǎ;�G��}�O��+����?� �>�_��]��e[g�=a�L?�\Z�}���h}�̪�o��oy�����;�6og�SHuf\'�/�����k��wɬ��_�>j��G7��jE�v�ڝ��Jwn5o�	���a�)\\������5z�!���\"���o�5j��1��&|iΉX�f4�z)�\0S/<������8(��܇~��kk*K���zα�\0&}T�f�M�t�gv�SG\r;{��ѱ�q�urd�ۆ�y�E��<7\\�t��^�]���)8�P-\'W��n^�(�B����:�@��LA�q�q���9���NA%�����J3�\'�b�����#�����xͯ����H��K�mi�\\�_�dv��V� CQ��c6��]��P���A=�O���7�xq��!]Whd=���U<WG��E�D��&@w\r�D�5�i�԰�����6�g��T�B�IC����D� �G�a��\"j��[�C��{s��c\'p�#���o\"UL��^�د�$P��ɘ�1ol�8s�K�|��ϳ�������GOٟ��\n��V��.2\ZX�jOm{y��G�_\\��${��i�o^G���rt]�x��<j�PV���G�:�?�z[�!�PO��J�ݛ��H�u�w�T��L��}���f���O�����=y�;�\0�R�4z��׽|��+$�ch2�&�\0��\"j�z\raf1|�Z\r_����<x��3gΞ�\'��|����}f�I�{\0\0 \0IDAT亊|\'�I�Ē��p�!\'���u������b|��;���a���M[*�M����c\"�׷�����R�F�D� DO�b)%d�\"�Є %�(^�H�����H+t���S����0�(v��O�(1�4��n3E�%�(E)i�������%PK��\"�����d)|bήЉ�/����!f$E;��R\"���m#�kѴ�K�萙\'�<@t>\Z�+��E?3}y���~O�ѧ��%w�������I�=����/�xy�L��J��]S�i�\Z�f	�2^�otb��WQ�p������l�uc�%���(��2������b�:�����1J,z�,D`C���	\\%�0tT?O�� D9���e8���N��Eu�4G����\\{`&,gc�n�MK8u��+�n+-�\Zq t:j�*^ܱvJ�ؚ㏛0�k�����RkKFU�R@T�Q�\\})/wД��6}��+��X�y���p��Y�/\nlmj��7v$w��)��X�by壷>�������	[a͛F�������ߚ7�pv���}���9z��W�j�+�&U����~�}ٌ}��\'!J����64͕�F~�PG�u;�_�ZiIOP�MސdR:J󈱇���/��t_������ŖX�\"�:���y�غ��;n�D��}7iϦ���=y��~��k?���޴g�����Ouk�P���C���FF�_Eq$�\n)��U�ɚO U�X�m�hP 	�%Z?@�\n\"&����v�O`)� @>\n*A`�h�4���+��K��؝f	gS�0uR�m��p\nXV��NW#fk�F@���ny���\Z��}�����}��g���}䄈��D1I�R�F�ʷi-��RE�Pɤ���z�5�lɼŕ�ӷ=���\r�rD0�0]��܉(�F�^�1����d�.!v�	ػ;�sKP\Z��uVP������r6��P�}�x�d:D���Df9Ŋ��M��	�} �\ZJ\rh\n\"P�>N9��V`y������gA���>��蚗���Sq޹�<h��[��1���\"��C�j�-^ D���T���p伩-ź���\'�L&�y\0���j\Z1��ON�u�cf�j����sxn�K���s�Rד���Dl��w���=$\"����C����\\��|�Ʊ��A�kӋ�J��7�{\Z�n���t�ڹ_9��O�Y��{��__W�p�Ү�&t!��ϭ�z����QZ^)\0��/���plE�(QRv��܈��}�;�ye��f,�I��o</W�������Z�ZnQ�6��{n��;ͺ��v��<�a�8x�&u�eS�+{�@��lnx���=��C�����պ���x����6���\'n����roqiU.�ׄ�N=��K�����,`8e}o�f��Άc~�A�}7�蝘#2�>�t��bn�bL�\n��C�������E��K�������~b�IӡC�KO������ϧ��N?���?>���~r��?���w�Q�[��·�?���Q��Ï���.~�?��l\\|�a��f��k��杪��e-t�T�L3U������G�XdZc#kzw��u;�lY�����-�a;���M��9�=���M���ҭ2g�v@E��t[gj����GW�.���T״W>���ζ-QҸ�+�dC�Vˈ��������[���9x��h�n�s)����<�6\"��^z����-�M�7n��I����v�m]�F�N�g_d��ݺ��NH�8h�%�n+j�!\"c����c��R+V��EN������-z1HżdBߵ��<�}mf�\Z}��������k�8���Obɮ���6����8}�&�|�����3R�㛯�F�)�/�cB��Gk.���#��tP��.}r���Տ\\?�������\06�_;�k~�疽ZՋ���3R�>т�>�����~mU�l����n9��[f�Ǌ���[/�z�2vܤ���%Ɋ�Ww47,ܴjbsώ\'N�|Ƚ�6��?k�b��V��\r۞پ����וF�l������\rwE��?�q�K�M�f�T:rv�WGu���eFtބ��n�ҕ�U7I�VCΓYU�?G����W���Ԯ�����ڹ� _����z˫~��雟߶|�\r[w��tKe�,}p�\'#%e�;/f��g��Wg�b����\r\r�^�&b��Y�ӛ_���ږM�m�+�\\|Ջ��l90�e�ZV=��i����ڻ�2}��w���֍���ƪ@��<k��)u�!�\rˮ���W�X{����\r����I�?�`�J��歊���W��WN�~h�?�6<&M��k��g��S|s��X1���F��%�X�n\n��Q��:{�F�8d\0�0�?\r�oYt����˳9�h�4	�%Ģ)d�r.d\"�ȕ��ă��R	���S�\\ue�Ч̆�![�(ɝ6m�c;z�;r���WY��x�̚�S-mOΪ0����ߘ[���9\'݈[7{�~�/]S�[Z+,<o�Q�by�\r�t�K��u��Y��\'�h�R=��O\\z���f��{غ�O��ܮ������m\r	e���D��=oY)Ȝ6�п=ѥ\'M�pm!�{W��Z���u/ʭ|��ZcQ쵹O2ʾ��6ה֭ȨUKn}���}�fn��9}��e��?.��#�Z~{ޱ\'�5f�g�����a�eK�w���?aSY�^T1iI.�i��u\'.�P��Њ�#��MGΜ�v�V�����K�w��C���k;hߪ��[�~b���SV�#�>��kapR%H`y*�����~u��s�}ς�4`fɝ�__�]��D�\'jҬ+���FQu)	�����˟����W���[���\"�y���\Z�.[�ͳ>q��mϿZ�ta����Ջm%�J|+�\nC�M\r$��ң���c�t�!C�M��[G��0ܤo��K�k&R�t��z	C{����֌�I��2(���~w��{���\\��>g��Y���a����O��1��W��(O�~�@�9`DW6���)�s#A�@�J���@�D>hQ&�M|���o�\rb��H\rWu;n�_�hA��Ƿz�mO�M�e��M�{���0�����O�*��P�@E���k_��X*&��a��� �]Q9�]JlNs&�\n��(�&��`�:�]����o���V�t$�Ӈ�dU�\n���0��w���ky���:1�W�=e�lO��ӂY��* \nO�8\"h���#�=�\r�Ǿ�5�蚆�q����. eD��?2||�@�9�A�;�y��5\'S쁈BHx�(���n�\Z��3�0��g��M)�RM�h>82��8n	Y��C��⟃�Al&��K{��m�2���-?��4ä\ZE�8t��GS=��Q�\Z�ȸ��o��jh�\"�AjB]�F�5���.LT}?���Ow��Q��GϺ��U���D��J���\"�w��F7�,­ÉKQ��,^?!���Օ=���W(R>xҹ���������=r�AG�~̬�ݮh�������G-_��7{�\rY��[[��x:�C��f}���h���t�82.�1�om/�QB<x��ʒҲ�S��4���~�E3=����R?�Jh��y#����D�]�~�s?m�{b{OE�@�_�x��]��z>�����ѷ�v3�/ ���(�\0�$L!T�$�X�\Z�����S�Wm�}�Ou��8u�ƶ5+�l[�{Y�֞RMM�~�s� hF��f��ƛ��Ʉ/���Ap�M��y��?Z�n�#O�?����fP.�p��\'6�j��OϾ��kO8i�mƞw�o�����w/J�w��/�^�|]+0��p拏m���-m��⿙���m�D?�Hƥ{`�Ɣ����Κ�ܺ�u�hhXw��c��@�뺧O��Ҧt�wmh���B�ɀ�f�;������}��1�c��f}���_��A+�0�L�Mޠ�V�zfO�:Z�@�9J�jr�����}����;#1�P�A!_������,�}�3���n�����K����sN}p����`G��5v髋�E��tKt�KQ���H�ݙ���^�~��N�e�7m}���������\r;q���gT�/����Ӷ���eG+;w��������=������9{������o}���W,�x�m�lZ�1�ח�sٗo��EP\'�[�1_y���m[w�*§�\0$	�g�E��\'}TVM�1�k��$���D*�V̿;��W.?����>Ň͵��6㊫��bώ���o��-�1�q�tP�B	�ee��S=T#P���mn�����[[N=`v���|��g�\0;�f*���\'}5��Y(.	+NZ����N��`0�+���nQn�HL�-�R	H0���������/{�=������7ԯ[����ߠ��([������_���O:e ��qd�,+�܈�����P��|\'�25��u�{t������g�-�4��7�2�e*�l0����.fƼ｟r�����;�����D5�����+���]w����{���S�MR�GS\0ִ�w�X}[G{e��==,x!�?5׭��̯O�@{½�\Z�Ѳ���i���k>EC%�\rU}E����K[[�m��1���j�Ѵ͘��m�5���;���k0�t���]?]vނ��d㒦Ү\\����YR��\Z��\r�]�]\"�b�P�I���J9�x���w��~���.����O�ܞaY,�#ȅJ8:�\"	�ű������\\�Z$��/��\0W�0lQ!��B2�*�[?V���hٮ��/z|m���Zۉ��S+>9z��㎿d�c�2�-Yҍ!�\r�\nj�0gY\nt�GYU[�̸���_-l��}��x�$n%f����٬{c��{��{_�zj����RD#1$>�dIsSOM�[^�6�Oņ�]y��������=��{\'V�S�&}�l��7���L&I8��pصSȜRS�v�~m��<��Z�(:`:D�8Q�D�����/.|��e}!��Sϸt�	���}߶��?�ꑗo\\����%��a��5�DzB� (C8A(5�+B$J��D��Fز>Ů�E��Zڧ�]�u��#�S��M$d/�t��D(P�@Z����P#��/3�RR\"��I\\�@�C�i�Z\\ؖ�6�L~(��[�Re��|?�a�HtU�ck7��ʅ�2~\n3�LM�O:a\0���\nJ�_�J��=k6�-����ooڊ���a� ��W�TX�JK�%g<0���*����Q�n����U͢[��W��W�U�Gm����{��3s�\nP|D��\"X�d��w_���{t���~��\0�Oߒ>��@>fLAU4l|i\"�<ALEj�ࣩ*q��޴�ƥ[g�۳s�o��޴�g~��ϗ/�N<\ZG�\"H/\0��0T/@�\0!(\n�(�M��>R��DUBaGU�)8�U/4�,��ɋ؃g��[MBM�\'�T�$���(E1�����.8��\Zr���sHWAZE������Ae���	!x�ޕ�����8�\"�Bw)��:[���w�|�m��.1|��[p^(N�+�2�ǳՆa��1������� �PC�O�/K�xN:�ʮ�!3��(j����/�]E43�����n�[��JJ+`��O���c�h���]��Q��:N��(�#�Y*�ض��_�ܺ5�gW��0:��*�P�M\r�~���?{|�eW��ܴ#&�P3j�֊D@�\rP\nh4�j����K�����COO�}<��\\��ѿ������I3f\n�E=Q�@���L��W��}Ɲ6哇��������OL_\\S[n���0�ڴ\0I4\Z�ҭ��yޝ7?���ՙ��D~L	7�p=����P�F&�l��.E\Z-piX�Z?��a-B��g1������Y�B�ϳ��q�B�B\\^���i�����+�ٴeׁ�:�8J�̰�@7��V�Xw��=��L=a��U�:��>��ү)-��q-ֿ�����?}�?*�[�]�f{} �a%D!� �(�Y\n�Geݐ���?�}��{���J�(6���!��\0��eն���p�.=�sK�k�d��m.tLK`�΋�_0i���`Γo\\9��c��nX5�bB$��G�Qtݧ����[����^�����7�u�՚ٯӌ	B�;�xE�B�}��q��ϼ���?v�O~��s����?�5�/ϻ�~L���E��g��H@�hBg��&V.�8x_�m%b��&D�0>YM!f��7�\0���\'(��+R�� �L3T_-��z�.������Ƶ;Pu\r+�oxQtt�c��憻���/���� P��5�6(qP\"�R�[/��ޞ7ۜ�G=|�Yc�R][���8�p��<gh������6]��=���{e<��Gg�7;R�\ZH�#�\Z��B�dS��3������=Z���Ӿ��<�Xa(�\'C�]���Pز��[����=��wB͆�h���Q�p� \nN�c��߽��+j�ֽ�K����Af����FpG�ڜ���&��?{���Z\ZI(����量���@�ߜ�mguީ���������ߪ��g6Gi�\r\n���PD�$��\"���6�\\l0�L09�@�rΫ��\n+mγ���S��0�v����~�yxx$u����:�=�]t��4���uc_\Z0����AL�Z�\"��Ck}G��u\r%=��L	�r�`T�m,��4\0��p�?ְ���:�ҡ���@�e�dpZ`:�$��:1��~Z�l�ΕTГ\0,�9�\n�\rI��ڷk����w>�cŻ���~p+��d\0���a�ĉn�W\\;����,���HQ�U�M���-��h�aL�I�y���^�)W�s�L��Q��s�5��n�W<�y澵��i?z�E�v��a7҇=.�\r�y\0k^�z��]�\'>���&7c��_�l\0F��]�ԓ�����⥦\0�B}������0���O%�?�=O7Ip I��S��B�O,h����ϙ_�q�7�=3iL�Zj��I�ld�`VN�ā�\ZR����L���ES�I(��H@��\0�Ut�*�Ӿ�A�	��`��*4J�&�:�\0�;1�?�fImuk�r5��瀪ÊI)�\0�P]*�Z���mwv6E��\'�����d�n�6��i�u\0\':m��[�L��A)�x�H��������6Tg|s!��\r�o��\\�\n@2��\Z������hp~�)o\\�(R�=R�)rǎ-uy��b(���M�\0 n��� I��+j����\0�X�\'G�_H�6�$\0@�OW�	8x�9e*8\0��x�� T��w��T������y��|��z������A(��`2a��*��������3zV4q�YhF��`��	�$��G�z��Dh5$��8��qX\Z@��|V�V��Bgp��b L�9$]��	@�Y2f}�{�<Sѯ�@�C㔊\0�(��P])Vlf=fA�	:;��^}��7�P�`�G�H��)�b٬	�M��w������~h0\"�X���0�$	F2��殲�k}k8��1m��k��@$��\0K��q��q%�Os��7cy��M�6��SR� �@A`\",=�L&�Z:`9�I\n�H\Z��u㩯<��]\'4�Mvo���4\0\Z@�@�Q�֎�dT��\0��P,=\n0	��T����O���y|4\"J�h���`�`�v\0)7 �ן�����e9�-��d�\r�D�������\rW\0�}��i:`�6���\"���A}������E�s�0q��6L�:��ɽV����U��\n\Z������03�;&����t���U09(�������n�`��yO� z�h�\"�m�W�6g�O|ڞ|fف��.�t;��M0�\"W�8��\0\Z�6���\Z�n!w^���[�W���j%m�t	(*��\\��3��P��c�Ç+j�S�\'1#�8א3 �=q!�Bf�	@�\'��!�=�\'/V������j����&�j��T��mW¾f���m�%#�d2Je�U����#3͇��~r���?�=��R���E	=n�hS�(@��(�������ϗ{2|�����VXVDp&�o�v�t�aA�0����Yv<]��4�T4!j6�kB|��Q�gg��i=2bI��It�X�L��|P�;������ʮj��\0\0 \0IDATm�\nA�$�	 �\0=)a����C��{�\"����$��XA��%�z_Dx��Ϯ߷�^{9�E�p8-X��,��Mm��o�����S����$RfiI���p��&�X�e��#����:K�n\r�n�A�!��##;3Λ�<z	fy���n=�+8Z`H�Q �=\Z��3�b�%��̱�$�dН\0O��&��}�[���j�8���Drm��i����8MQ�Z�@��&�fs���V���!�񤎁�y8픱���~�c�+�_��{GE�G����(0 �$!���PUM�@P���G�)�1S̊<u$K�LOY�W�O>����F8hT�C�+�Au�\n \\��8������H�.��Ð$�(�L0�\n\n��.�@�\Z��-�g���}���\")+-�\r_��)�CU�f-�v�\n4������qX:�P�9b�Zz?쟷�\"gz\0�aGx-�>��m�P~���%m̐5�,O���\'$��\03N��i\Z\Z:����s#�K���{ՕB9l�n�a���+kZv���{�����u��-\r��o�uS; �:GV����\Z�}�LP�XX�ɿd	Ĥ���hE�9Ｕ��W/��젍*I�>1�\n��`)����/�j���U��)� ,��������~��g]�㔐M��M��S\'����ΟS�f�$:����dZ�����ӽɤB-@5SDk\"�T\0Pp��j>���&!A2����^S\0шC�8DbB\"n�D���+}u\':4�A8� ��	����R��ɽhs�ѣ�/س}�JU�(�=j@��)���.zqq�d(��pN�:Dti�}g�E�?;tRo�%�,	E`\Z)�m.ڔ��a��ϟ��{�5s�(fXLL\ZK��9!��N�����)��-�&!����:a�Ǔ�+ʴ,�y@��y���O����ڪ.��t�.SD$L\r�磤\0�xxN[0���3�>��\0P@�¡x��/��W/�N�(j9�R�|G�!����/n��pUm[�,	 $��!).��tf��[��=�.�ҳ�\"t���aڬ��H1�<�24G�ʞQ�\'eò��\"���iXv܄렄#�t;e�\'�ӥ0\'8(,H�\0KL��B	��#A3���G�w����0D��&���� �\0�m뙪]�C����s�\"�\0�EZ�cL�3񥒓�[\0`Ҝ�2F��Ms�H�rD!2%��t�YY�\n����\n1s�ij�I�Y�R9K:~>ZI�i���n�y�ͤh��\0X\Z83 ��V�8:r�#�\n\"�i���1�!8Q6,���s���7Ͻh���螡1�N@�@u1M���c@���n���ǿSFJLJ���U������x\0E��-�f$;��(�@��Óչ��Kg�@�loT�����;��<��q���\r5�u�>&pb�=��F�A�]�m�Q����,�H��$	�MV3��\"��e�]�N�=tܱ�tH&��2lv	��pQ��g}�H�;ӝu�	(�a���\'��#�N�uj�T�}���V�nd�.r�����Ӈ��FoZv�ԫ�s�������4ό\' �\0��iR�@�ּ�+��W_��wi3Ͳ�9��C��yJ����+���e/\\x�Y����lBv*+wv��\"����%�M��Ṹ��S^z���DHr�p8AL�S���$\n>�y�(�0j����F8\ZF���R*����p�����xv���t�a�^n���k/��֬����[+OY<�O�*3�J�p�B\"��=\Z�ъ��׼Y}��w���*�ή \\\0\'��RV\Z59\"�6�郖c�῕/?;����I��Np���~�	P���V .��.3�@mbFj�\"�9CB�`��lJh�#�L�U�CBB�!SS@@a�\0����!�B��u\0��K�䫊Y;�������>I� R�G��$�>\")R\0���2\r���W���9�)l�LѠX\Z�[���-�:���@��뵥&;_/2;p$� ��e�LW�Q�]u��\'w�Z���C,��\'`pp͂�rخ�\0�@6����3��p��%�z�|᫓͖U3t�C&.p!�*@\rPS����m� ����؎�����0<N\n�!�\'���s��z��_��U�ŨQ�ǯAn���2\Z���$H\"8�,�	\0Wݳ�Ζ��%�,�UJ9!�\0� D��-c��N��G��[,6�����o����*�?r���$��2A\0X6X�L��r@��ҩ�3\0�����ZnA�vM\0����Cry]��G��^v&	�\"x��\'\Z��\"0T@����-����Nt�A��\"A�,8DF\nĤj@X\0�?�x�?�qv]M�PI�Me�d��05��ۊ�4�uP��EԑyY���jn�P��)�Nm���9�����`�qG��SɄ����Q�$ �	����!��Zen�)�����\0X�ĵ�x�p\"��Z���ߠ��:��[Z[�TTpX\0W-�PU���ח��G����mh��Z:��0�v\"9�-\"�\"�6i������6�>>�&3��J�.Z��uHA���-Uξn�%CFg5#�r�\0�(Bq(ؽ�v�[Ϯ�h募O=�#�2-A�a��}p0\n`�@<&����`\\����G�²HS��h8\n*ɰS����	B����/N��qһԔ�	Ah�NnhPvr\'�G��}X�B��IP��	fov$U���������_F��.�Ƃ�z��v�mF\0�Br��)��`�D�$�%J��3(a�nd )9`\Z!|�ܞ!����2�;U��Z�@b�hs�1g��q�uY��#K�qd�:�,q�#�*��m�:�\'�*����YGm�Ҵ�?t���%�\0c~&�����z�ȿ|���_<�A?�� D���(@83@)CZ�i.|<��\n��+���p��@�\0�U�\\��ظ�r�+����q��F\'���R�$\n���v�F���x��s�(,,D4Fl��H@(8q`׎��O=�g��?��S����a/䫇8���!\Z\0�&@7ulY�?^��\'���헬����N�+9�vA@,#\0-C~�ې\r�2�٣T�ך�q��(����a���	������m:@�$D�	����Y&\0�Y���c�p|���k�+;D��\r�\0�Ni1�e/l��#�\0���$nD��M�<��V�L���P��܈O��^�����9�ѮRykj\\��ľ�kΌ;���m���-���\nP�y 2�7s7y��Κ�dn���*%+�*�H\0�\0f\n(.�8򋿝�Bo�@�V��� 4� q;�D@�8\03no��p<eRB ��ð40	 I�2���4Y�`���r߭��c�m����-��T��;��̼|����˝�nٰS�v�� �~��y(�������q��{��Ϩ��w��0͸��2 *\0���\r5Ql[w������޻����_|�\'Tuʒ�@H�^��b0D��@���#G���.�qAQWt\\R3 �4@\r�uS2�����|���]��\"�a�^p!�T�=�i�Q�m�mM���_�aǦ�:\0�R�05p.��\Z��d3f�hL3\n�L�(2<\nE\\W`1Ad���\0 �	\"Yh�,��I�?Ͻ`����~c�\0�s�D4DL�k�H�Dg�5�TD�V����C3Ы��K����-�Ƿ���1�	���@$w���q%�~�{q�ci��۱e��[��\Z���px9����jh6�N\'0Mܲ`�\0f%��I���K�DU��t�aD� H��3\'8��@sc�T[��2���Sn�)�\n�7a�S�qj\Z�eǯ�]�\rf�8���U^g�	�u�i��4��;w.x�>���}�+.�m�����{�>U�eς/�;Fjz�,�s���P����G^~ze���cCU5]��溅z�9����@�.��E�A��/[w�=���.O���u�	\0��\'��l�]�M��1��q��D�dq��\"2�v��a\0�&���[���Z*��kv\"��7$;H�M�8a�u&�.�S����L�\n@\02�\\�N~�h�ݫ7mZ0��͹n�gٺQ\0�nZ@7(vni�����.����dtG6X�RR(��v�Z�c 2��v|@wG��Ep�C�~}�=�=3u������0�>YM��Ĩ����_6�G����ٿm��Pu����]\'\0�����0�3���GpÕ��D����Š����p��?fDl��ç%ڣ�e)Nܶ��c�!@�.�l�t����t����\r�L��:`:l_��T�\r�I�R\\|n��*�9|���ںN�����\0d\r����M�������BpdT�wNפ���p`D�0�:�(�s��P�\"jj���W�xot.��%&jp�i��io�D��âN��[7{�9\n\n��b=���(�\n���bO��\0M��u�F�OK�-t�U�b�&aYn�c�|#�G7:���KN����zt��<\n��n\n\0��f%@E��c�@�5�@vW����#Ań	C�+����k�\0P]���\r{_����n�v)�p����0���1$㻠:��Y6���f#�\0�6:�%\0��9�[.u�X*@54~B.�Г��d�} �Z{ \Zj�@] �\"K�|t�_\\p\r얩=���vI�����p;��Yv��z�\ZjK�� ��]T<|���*()��	2�Z>F��\"^x�;;��}/��}��wO?Z�\n�h�����[ ��r4����L@�c�DC��C�n�E���Ef��?�:<�a�4�v]��?�8%��\r�)ژ.@�����\'}���]������^��z�Ǝs>}u�����at{�	�B\0E��I��eIhn�B���\n\0b7��\0X��(���R���<Z�;��S�z���w\0�i��LH�촼��		`�\0z���i��=�0M�D	H]v�R�\0�~$�ֵ�mj�16��DXID4A�1�{ ���g����z2���9������V����\"��`��3x]̛��/P�z����y8OPp+\'8\'\0L�A2�M�8�S�7@5�PS���\'<�W>|���S�`ێ�1\\t�!P�Ĵa����7���V߀a|͠Cޔ�;έ��D��0\r�8tN���ٍ��z/�y����ԝ[��<��8!\\�eq�F���cJ���0�٤*n��&��n�5ۅPe��Dp����\'���~�g�m|�`�e&�$u���(��E#y�-�8�}�L�8|�����o;t(xS}W����D!� zP�p^����1�g�lŷA� P�O�7���.�~��]=���CkDLI G␹��%R5T�e��>j<�w\'����.���T*CqS�.�N�op����g�|���ϰ�:G�h:r�_(��`\\G��e��(���%S���o���M�8L�Be���Q:���;���c���fQ�谠E@\r�\0\rD�H$��\'�D;��.ۼW�\0�8G��C(%^Dg�6����cZ;��te%�-s�-x�D�\r<~����_����7=ŷ�^�Д��b������Ƀ_�Bg`����*�$4�Aa�l��Є��o����_�c�xXK�lh��ED�$`0$�1~���	t,8��D���2~��6����<k�E9��I�O��ꎕk;�<q�Sc�|鼶�Pa$��\00c% �09��_�������{�	v������0.�RUf�p�v�B���)^��]3�t���e\0��&8��]��T���?~K�g,�����Я�z~Ys0�˖��<]!������E�z3�I��:�j�_�{s��-\rm������p��9��\\=aV����?�8לw���R��t��@�#���(����t�ح��\0�@r��X��A���,�j��ݺ����^�>�߀td���Qg��r�\n90�\Z��/���{W�񬚚V��]���^m�\0p�?����EFW�<�.,���ك��.ϻ���g}y�{�y�|ʩ�4��R�p@d	\\�@$!}@�1ӆW�ZZ::���0�Ü�#�tߩKpB�����:k�o_\rV��>���5T\r\\���p�i���.ՙ�AB�(�M�֡Ӌ7l�^1��\'�l��t�,Ē��m��e������І��D{~D��D�i�MQ!��̦���&qX�	\\y,%Ӫ��얻_|j���}rE�SXP>��:z�5\0pޥ�^��б���uԘ���Ww��9�ڞ�;m���\'�7�AX$�\Z�u+*��˽�b[X�⎹K<Y�,+$X0,�8#	(c�!�����A��g��d��|0&�o���i��L}\0\0Ս��=����Ӯ�䍝wO\ZW�:M�Z�[=C�a��q\'�1ov�ܵ�q�gM/�g�\\1����R��9$���P-?�������G���8e��\05��J�`�`�{.�����5*�����H\'N��V\0���o��{���!Kv�1\0B��ۍ�>J��s��R�ʳ7�I]k����:�3�g�nY�T@}G��-GO;��{�qjh�۟>cz(���U:�9����+�PƟ��[&��\0����9\n�l���3���l��y�����{����W�6{ty;)�	�A~ԍL���9���zn{\")$������U�y�u�k&;e�E�̓�C0���w��⮭?s݇Qw7 \' &$$A6�\0Q�俬\0f/���8w���j+�X\\�s�?�X������.TK#{G�f��R�Է��|Ok�z&sN/�<�U?-��ю��������_�\0�ey0�v��h�]&�a��\0�]�ɟ%}�Ѻ@��q(�\0��29�I��?>�\0~��Ϟ�J��B̆yqvst��uF��b���>��\r�z+�ɿ��T�J�|�K�\0�w���=����OE������c���A�s�߶��I�H�GL]gG��/r�����s\n���	�m}�Z���,��\02�Ԙ��II����I|�z����f<�;��cz�s��|�-O�#�ZF7@�m��f�͌�oZ��Qs�>D�	`�\"�E�(���\\~B.8������Z�����L:�{`�#\r\r�b�;�s�Pɽ������w�x�z�ͫ��X��7߼��l�g���1\0@�e׾���#f�=�w�GOŷ%���y�&���]�\Zn���+ꏮ����e2C�w4M\\��Skxq��$�і�&������\r/��eyKt��n��\\[p�!Iξ+i���	������~�	�<7�Ù1�Q]K������ɃU�GO�ffш1�����$��pxw��\\�z�j��eE��c�.�A+俼x�����~pg��q�q\"Y��G��ON���U{?z�\"��>3�pu_s�Ӿ�#VѰY�Y�ή���t�~����/>�J��G#�Q��\"���b�huB��?/�)��e���׶}zc��!�vhK�i�ҥ���������ڦ99��u�SpY�Co%\"��=�܈�j��7&b�� ��M��E��6׬>��+�K��0��$�Tm�Z�xv���\0�u�!��<<tp���wk+X�u��.޾���\n~k)UTC��h��\Z<���_������E���t$ 9�〥P�Դ��F ���d���I�`�J,H��2ع�x��o˓8�=58?�w7�YWJtI׼���ֆ�����w$���K��h�/8�t�gM>���ؾ�W>vw��P 93a$;@�%[�FmJ�h�p�\rs��fD)L���}��X�s�Ȳٿ`��ytÆw�=x`U�K������⏫�ֿsI���^����k�n8������W�z�c��o����+��ۉ�3����UW?����􇻺Z*�+\Z	��@$%�ɡ]�/�������,\\B��Ξ��[�?�z��W5��Y�ٯ��yi�%���\'���lk��K7aēȜ8{�\"q�v����&��\"3���<ml]���3��G�o��3� (Ѯ02ʆ��������v6���i��R,I��\0�p9%㦆�]oݽ�4w6�f�����;m�}`�`�ߡ�k���P�!Q��85����h�WO�\\S[�`�y_�(��d�3��V���g�Z��_ָ`���\rw�dAUPX\\��\0\0 \0IDATQE��Jf-=͛��U}�\":���#>r���w]t x�ȝ���,����z��ϟ^�������jC��H�����/���G_��L��uOwud������`}Mޑu���b͠I�\"���<�y��,Z�ln���]GZnk]+:�]X��2� �����L��g�u�^�ҕ�?��3���\08u�]PX����T���9�!@��g$j�/}��YA83u!�8 S�8Ĩ������~L%��+��~y8 \\�׿����ur\rv�Lp����.w]ƽ�%���ŏhқ��\Z(,��9t�U��_�*,�J�7��@�,.=�1{�5��Λ8_4,4�U�Ȫ/N߻j�\0�j7�����	w���B]�@�-�4kr��B[��)�^���(�;�߲��ܫʓ�$9=��ATT�5aT|����y��xU�p�H$�.����Ag��D,	-B�7�z��ݧ���;CGk�g�y���(BՁ������̜�H�N+l���Z3xGk��x\n�Dt�)\0�Ss���ϰ��t�j�J+ĨS.F��=���ǟ���U@��}$�sD�����P8zL\r�����w�i�����pxJ�;�#-����E-)/��������d�:�m+�\r\Z򶙌!�Km��ymB��\r�L@��2��\r�g��/13�Xg;L<	��ފ���k1d�<e�ɗ#nDWmK�jO�8{�C�����UÆ�ߦJW��\"�@�֛�lT�g\\�S/��y��U���\0�����5{ f僉����\0����*-�ol���\0̿�n������5�MC������=�f������ȩ砽v�<���C&��t�磱�\n�,��E�BW{��������d���3�[:�(�XNl,a��K�ޟ�>[�nY�DT�A��$!�� 2�����+�{��t�����˕�/c\'.{�����xϫ7�$�]��6N1՛��H����V�+�e��u%�3�%�3��VMJg-����4���o��3�Aw$P�����3�������z��{\\Z+�mhhwfLxn�IKK绹 `ʢ�b�n�E[s�//�����d�Ő����⿾�Ѹ���ATs�;��₼።G�dzs���~�UXʝ��|Șk\"Gv�Ktty]��a��Ř8s��B�\r5^WZ6�\ni>�\"�߈IH�0t�D�Cy��0\0�+��Ag_U4h��.g&�&�[�@~\Z��U��l�쥗�\'�\Z���4�ہ�/Wp�XXk\nLt^��R��CI��ߠ7�.��d������B���5�_�����s��z�r��\n��5b]����<j=�E��^�ds�����C2��/<��;�h8��jF8U\'\\�\0򇌁ە�桭-��CJ����o.��o����$�R{s��V����1%R0��[n�4���t���a�����-�+C/>�J����*�K�L8��X�!�Rp�qdv���b�;f���(�W����b�-n�����CBq�XH�� �Y>!8W׏�J;hyĢ��娝VK��g�\0,���l^v!���Kd�#ʽP9��b0b�f��ǋ�r�k�!�r�-?sB�w/��ܞ��t\0������F�P�T�\r���5\Zk�~�pw��J��	(Un��\Z�1!mpqI��b�[�|\Z�+��!�0l�)x��όZ�O�R]�(>�/	]�}}\0��;�����\"Q��e����f�Y���,2ml�^#�h�Q�#�V_�?d�)��+���\04_(L� .5ޥ8<�Y9�\0��C0`��[k\"�l17�u�Be䌝�$K��z$�n����?��d�c���0�(`q�P]�Qg6\0P���{�fl}�	D����Z4��̋�YѮ�Qe�����Aꏮ�*g;�G���S[1A��kj����mlF��I��\\y��vO(��4�@��!�u������/�kBIA��z���Fg��;�|L:�\n\0@4\Z��0�y2B�-��ڵ	�4��Z�\\\\�,6j��/:��j�Wx������%eS������Q��\\Y�� >��(_x긩\0DJH�υ#��c�S�@��(�8G�^`�?c����16�J��@R�1�2A��O��ּq\'��y�ʞ��?y�1�\'\r�6Utf�2L\n,��[�� @�����|tgz?���@�n�\0�aH�S\0��Z��z���S�It�s\n��.c�O�������&�u�\\_���z{V��[͊V~4�/��\n������-ѷZ>��Ct��m����{��\r����V7�>7�HD���(HB@�Ӟ����u�U�L#��/���	�HK�<4��ȅ&t�`�Ĕ@(�b\0� TtA��jP�S��҄x�6\0�\'��`��ϡj�\r	\019x�e�@2�Ԁ�Â �0��ʺl�A�R�aQ	��ǣ��\Z*�#]��H3����A�	�0��.�c4jA�9\0JCn �50ݠپ���*��*��rY�9�NΑ�_w�G�ՒؔC.�Q�X�4d�����u�;D�$�^� ���q\0`�: h�b2Xo��K\'�,b]\rp��mE�K��S.����$���F����uw]#���j����3zJG��Q\r�7�qeVծ�R��a]���»���ш�������i��E\\�b:\\�P��M�?E���a����,�qX�[$�\0 h��!��D��\"�h�#\r�H�\r\r���$Ƶ�L��4z�b��蔀3N�@g���g�1u�T��D/H!��0:MX�BRd$A �*�X�����pLF%���N�[q���\Z*J/�M塯�\ny�\"Ku�����)a��wQSY�dW�ܹ�����~Z���k-����k�-Y����G���)�Td\"��t/&-�	�x;6��R�����e�(+FD%��\"�p�qo���m%\0u�H&��RT��q@lV�~� !Q����$|\n&\nGϙ\06n�����^ܰ��~Y��DMIR�[���*�{�dN����Dk]\r�-�d�K�ю�vC7��U�NB�� Z:�p0	��V�?�EU䐈\nK#]��B\0��1�`�XL:�&�?c��#[\Z�,�ũU�E������-{�ڑ:5�����F�4r�DKԐQ��ӯ}�ASm�F��P�o>D��[��A��,�����k[��|���ڗ4\"��NL_rN[��ͻPWe���D<������!x��Ьn��h�ܳ߳q�;�����/��ŗ�C�OFCE5LQ�\"*{��R�~�f`��s��;��-P��M�d�e��0��b�� �DX�@�z�Ԅ��%�\"��MK��5�\rѠ����4s.�\n3��\Zݭ\r�⮉���1?��3���x���$	�R4X�	�����c-�K�-�a��.0Y!\"�spp�Nz�\\�[k�l���9���z��0�$�_|>������\r͈F�f������ԯ� n`�Թ>{>8�(���x�깷m��N���5\"�.�tɺ\Z��㿙b>�espG��8E��*$�\Z�zd$���>|��[���v�N��݄���1$c]ٺ�r���z*�H�!��Ұ;6o\r��9��^�o��j$Ԃ�-��_��I<7�EK��݋7��ğ��n���hG�a�m��׵v��jhhڕY6�:13�������q`�;�9\\��Q��!�F��ʜi8\\�	9�!���D�#����&�t�;�mo_[�tfDá��������=r,���O^x�ߕA��02,	�\'�G\"��`�h��s��YnZ�T�=h��M��ƔD�Hÿ�����@s��`1hM�h�[���*x�Y<��>x��$���IV<��ή=v�7#o���*�;T�ɋ�GCu��<�	v��a���PS�	_��7n��W=B����b$�\r��oj�y�jn��ŚQ��m��9Z�mE΄��d,6��r�T��H#�OBRH8�Pp�M����m��?\ZGm���˧nC,�Û�C�����\r{�4c�t��k���-���#�ȎX^ƀ�+�|oݿ�_��8v��V�5s�k�����	{���sE�����;�#h������Q\'t�#���Z��!}f�wE[�\Z\"\\�ݠ�D��×`��H�N[w^���a�\";\Zl:�\'\rPU �7/_�9��?��6\nQ~ޟV(q�۽\r�F��%XV�x�÷bD�ܓ1�`]G�ߒ��u�OU���g�rR\'gx�y����>	��}�(��χ��,�I[]�$��0-$[\Zatv�dȦ����׈.�����\"6�|<a �tlН�=���;��L��x�Ȃ~#g��nǚ������x��\r2x笳o������+�LBd��];�v�]����\n3_��������6`��N��⌺G������?�uWz�hKj7�eI\Z���O���;���=2��NC0Z���=��4�Q9��̈́���Q���q�C!�|�Qł�dd���-;���9\'�i\"��\" ,�Z\\�L/Hfy�o����g�G�no��ׯ�LN�W0�*�x���P��Aw��g�rx��\"S�Pe?��{]<�:)A\'D�[>|�Ppل���[��$\\�C�[UJ\n\n�U��-���;Y��0�5�d��ۈu����\r�u\"���y֨	o����b�>��Gu{m]`��]�����Ʉ�<4#���`Sw�e\0o�%q�(k\\{�I3�e��T�ꎛ�h�t�QI�GL<��a3�Z��^V^�Ui#��+|�����k<,�bFi �{��\0���_Q�+�!�M~,�R@b* D �0�B������쳅�6�Pdwo��HH$�.�\"��l�ng�A��|�\n�ϋ~�P�@Ϩ�/���$�\'���*��p��^J|�A�kzc08�2O/����L+s�ܕ���������<Fx�}�p���,�O��`I/rx��GP������L/K�p�š*C���3~��a$̂4��(Ocn@lR����vPi�y\Z�*�%B�{D�Ӳ�l��������6�]F�y\Z�\n$ձ�^S��6z�mG��r\'3�k��-�g��FiW�^i���$�E����?2x/F��YO�u�-\'�G��1�șyGM���6�d%�	�C���7Jv-QZ5�����9r�[�p8��;HKU1B���Y���@z����hLtǾ^>a�+MvO8	\\�=jؑ9����5o�`��_��!�[	�I)�ah�ف�����Y��gg`��Z��Y�;#�2F?|���ޙ�[V�w������X��*j�\n(�Q\n\nD���I��t���jԧ���N:&}LL�Q$DQ��I�8@�\n��\n�\Zo���3�y���)����\nU%������}����{�w����[ j�q�g���z̲Dw�@��RʕǏ�/?�ԏ�yz_˓d�ԅ��e�מ{�2�x!+��P��p�������V}�غ���Mmr/?��\rK.��[�X�O�-Y\'�z�����7�F��l���3���|�K�5��y��Rڎ���n?��+>I�{�+~�o��څ�G_*���>�W��	�����#�N��)����C��^>t�E[&򽯨�|���~����C��㆗5���ȶ��T�P�-i��c�����C�DsȚZ��6O}�\rO|�P���f�NZ�8&��w*�=z-��5ןv�G^{H��\"G��S�w�ݽ����%�����r���\Z���&9��\0��疼�S+�G��q�>�#CKH[# ʛ��[GW��<{��h����������G_��\"�<r~�=���2u׀�K��h�n`�7�`>�@R��yS�,;g�<���/�!->��U�ꘆvɄC�0L�7���݌й[�<����~��IZd�����?����/_���D�v7�\0e�1��bd�G�pP��Ӭ��ʦCԩwH}��3H�_@��YL�̦���*���$roU���ٻx���!�Yd�#�[����o{�Ċٿ|����[���7��eD�O){(呗��\\;��.��P}�C���<��L��h�8T�q�(�Eb���*���ra|���p�ۦ�K߸��i3���5�����֗��3N����%z$Ed�\"����:�\Z���5���l�Gt�\0U�k��8��t\"gΎһ�w�7�#�1��.�����n��_\'�w=y�wٱ�_��7P���>����RF\Z�܂�y���L��,ι�C/����3܅��xI���#�v�s�2Q4r��\Z8�\0�*�O�ZL1|2��e���ԃ���y�d�^�ɹ�~���X�Jp��n�dl���$�K���:&	{�(���,}�Sq��d���%����/!r<Ҥ��K��0�]�tJj��Va�Y��	T,Hj�n�{ѷ�1�R+�S��P(S��pUn�� �%A���J1:fN�=�l�]b䲁%e8|֣Bi�E��}��}�x�6YE\r�MH���2��-����)�\"�s�5��Ez�JI�P)*]�T�;g�%�F����\n����I1b��tJp��sY��7��	ȘY2���R��<u�Y�H���J�b^��n�t��;q��%�=R��kH��b\"��w�]w�My���G�����P{?�H�݁y��څ�@��DYb�.�=��G�5	�Ǒ�>�l���r��D�\"GHM��:Di�8h\r�)n)P�CR�(�@3�K��p��H�L��i�:-�j���*qK�LwP\04���X�F0荰0v��֯��>T��ӳ����D�\\���:TyD$R��ő����㐛���!D��<�8#tBSP�X�HQ\"�\n�(��f\n�U:���.�N)�����2��EI�v<|����{��M5ʵ��Uiݵ���jn\n�1�[A#	E�k\"\n����I����矼��m�~Fҩ��w6[W�*�ί\"�9�n�����]I3�M�a�U�+0�7|��KM�@6�Ma�aRA���ye�<Z�Z�%�h�MY����ٸ�����4�dCߚ[Z�f�\'���^a������8?�=V/&�{��SP�S�朇��O����E~����ݡx�f�)ɑEN��\"�Q��z%x���1�^��@�$ �Rk���`y\0n���V��u��C����_���2�K��{Y%(��L�Pj��~ƱcQ�6�30e�tF	�5*�h=Gg�F�K.�a�䍟8����H�(`ť�ff��h/$3\ZW&�C��\'�i��@k��J��Vg�\r�р��{@-����F�B:5k�֠�[\'7�z\0^\0N`�� � �bG!�\\�\"p]���x>�E�\'��Z�>Z0ֻg�����_o�ֳ3���$۞�һ:���~�Ba��۴���	�JB�ۗ���w��{���=R:�U��}:�B{婽��;Fi;ͮ|@�S��/�#���ԧ����ښ/TLQnI�#YM�[Ic���3\nQ1��̷�3�t��6��u�|�T�r��S��]w�>:�ͯ\r>��M\'�J���\'���^8Š�0BSy\Z�����^Dm@d B�R+��dFp��֚�;v�d2�rMzX�y@�=�����;\0^fX���/QVc���ا���`r�a���:hU���ή��߾~�E�Sv�^;��{��~�ܟg��e�\\u�Ah��l޶�-�b4�L��z�>c�ל~�/� ��e���w��{�$�*AK�f0���抺o��B\nP��-\rY	�1�$)!D��r%FW��>DR�-5)Ȍ�B�*C�B�%����r)�Zi��0�z���#�����tѝ��K<Sb���s��x��l~�e=��W��\Z�g5�n�g����7���ԍg�)��F9Zt�A2O�1��h�� SC)U%	�� |��!�(��� I\r\rOP�@`��d�,�F\"HP�!υ�T�*�.Dʐ�-�)\r�#�c�X.�G�*i4�\rL���6�J7�Yn�-N��}�sɟ�`7<�M�wT]��&�x��:��5�>��C��\rg��ls��o��7��Ro�MY�5������0�7��@�j�X`�yt-Df.J��f�����x)�硕Q�h���T�Us��Gtbh\0U�H\nt#G�U�Z1&�\"B�sL�#E��$��4�\n���^���h)�A^&�ҥ����psu�[�V�W�\0\0KIDAT����§�v$��<��G�^���0���m$�\Zh3�p/��索�2��UdZ�aZ	j����Ia�g�!���̐hA��v\rEG�P�E�,�*H0�HU�4�2�)�0��@��,���X\Z�L ](JC���p\r����7:�h��.��%�)g5�����~pK��~��?6�[�.n�������͖x�]�����%T�¾4�ڿ�c��Bt0�SJ����D:�Bg� �#r�[�\n�R*�P\n��H)�\n��(�\"C8M�(�o����\ZTiF:@�	U�qD@�F��]J�GT1e ɓ.�n7�ç��ֺe�s�^�����:X��@?���~�\\���؍5�5�������D����W�)��ʘ��I8QA��@Y��AW�)���/mR���ɅM�y\Z��u��m�M9�f9�>�]2�	;��m�P�v��)&܀�c&p�*Ǯ���@b�8�B�ǳ���\\z��s������c_��-��\r�����J<���a�A��&3eX-F����<tʒގ媘�oAՁ<?�O��6U�����˖�9���3Y*#d� Eɼ8H���1�CP����\nrk��\0\n�K��cF��0� ��Q9����XCV ]LU\"��a`0d�-K��z��#wmy�[O8�޾ˮz�5?)i���:�?��}�}����6j�u��O�z�#�q�ɡ\\~�,�;�u/����r�(Z�vYQ�t)�����^�n�)�3U�\0�.��~�e0n��\r�v�]�nY���ԗ޽nϿl�tKq��c��P9��D.�\Z�\n�*���ʮ�j����\']��٦�|�{��e����7�᥺�P�13���vEa��B�3��~)m\"���y詓i.�_�a���K׌��@�j����n�����%�y0ks���/�*�:H��C�s�G3��z�Ko���-f�K�r�с�]\r���Q@��H��Z�8���|xͥ���}>������{�����\r�ę�����I�T��\r�����\r�*�N�S��̦����c7}��_�����,n/Zy���V^�ٹ�*�dN�$ݕL壔14s���!Tfu\Zr\\mmvB�������~�p���`���0��ɿjD��rc�28���\Zi4BۜG\Z@��~)5�.ĝ�v{-Μ}�v�o�o�?~���h`�~�<�9!�����#�Lϒ5\nf�Ou��i���)�LE�W��˾�\0���y{�5����ٹ��?Ɵ氿,��#���m@?��ϧ$�u%q\r�-x��n����d�S�XX�;��p\'��Ob|�e�^|�{�p�O�h`1�!`z�+g�s�br��T��)�!�ePR�P\'��g�����Ƕ Gw�[&k�ֶ�u�o�p�|���<�Ė���O}j�������NM�Wv�bk&�2��c��c:�Eo9�$f��;��\ZX���~�Ə�s;ZX��{�Ϊ���\06�u͍�����P��e�0�\n�L\nTU1���Q��d�5w�9I��UWm�b<9}��)���{6���?��햏��݈��_��齟�j����.R�%�T �xw]]1&�LL�&�\\2g]��Y�W�43�)+�3����^�����s�b�?�	!�k^�Ʀ�:�>����nN�u�e�����9�Hҩw9�5IY�>���,3A�q��e7�5/��+�{Fv�G7��g������ym=ۊ���I���(�e˃K�t9fEE(\\�J \\CXijJS�\n������cz���n��?���}�G��~hz�{��4��������{�6ҭ��\Z���+ʹww�;m]#��YG��&Zc���1�|��ݖ���������o�{����mNm���#齯(��C\'�o/B�B/��.���hw��2��sȝ㺘,A(����� I]�D�����������-{�,��G\n�9�ň��FC��˻����\"��A\'�9vp�]���P6����ֲ���v��.��F�����4g���^38w�����ݡhd�&״^n%�6I�cI�&\r=������T#޹��ҋ�!�\\tYyW��o}�����5��o>��y����6�Em�c��NgO~`葯�<̦膣��fX]߅W���\"�]U\rz���L��Ҝu���+?9r�˾x�O�g�o�>~���;�/�ʇ�\ZfnU��Re�J	Q*�(G1�Q\Z��-�<��\'������}c���p����;\rٝ�˥�9}�?��7Z�N����b�?G�@sϭo�L�;_5&f�̇M�\\c���ܜ±wƳ��~�i�$�WdR]�}~��?Z���ǆ���ٰ���,����&�߰!/o�f���r)v�F�>\Z�����2#�ķ�!� ���b\rb��1y��#Xh�=���	W���>s�w��~�����{�O,�sȣp��_|��_<n�;G̩���NB��m%]l�~{�B��Ё��CZ[M� ]�O����_�`y:l�9��?6e��YW_(����r�W>�>`�hz%Un�\"+��Rp�M.~q^g�=H�SC�\n�\n&���;\'��7n|�!UR9����/\0���@�y������ݷ��5���W��!b��r��3T��eklO|]@��у)(�(�\nҕ/���>]���u*��5kެ��ǜ���}��al�	��G_]�ni���G��j����֌����~Bc�z��(���wD\n��L�&��Z�2M�y�I�F7���+߶�����3�E~�0�[���%��}�5��R����ui8��s���p��z��J�����c�\n��*�^�]�����S��;���Cަ�~��!��j�8v���bvq�|�����݇��37\\�����7��2�eY�ڃ/�0x�]ZlÐ)��,�.�|S�aav7d$��*�t\"��+v�^���/���&����~���W�������]L���:s\r��F��M��)q�@��@r�; j�%����\'$25��i�c���\"��\'��ޥ{c~�����q+(�1z�Nc�����z�r�V:���$�`�dV����[[W6�V%@duє�-�ն�o>&����H<Y�0��9u�c�������>�җ=t���y�b�f����M�m�������ô�B35h���n\ZQJDj�1ey\r�>\0�R��6so+�YU���wI�T���,\\�\\�˂�WR�R��C*�^I_�ӈ����n;����`���vף�.%�QKs\n/�V�1S;�x��?�=�w��h`彇q���,��͆��~��/�����丣}�W�f2R\"{4�iF=�c[^c�j�P�j�P�_��_ߋT�����>�d�XAĲկ/\'��[h�Pb�9�@ֵ�o_�7�[B@�k����I�!!)LI-M1n�tk-�1?w�o��\Z\r�9LC��g1Џ����u�Sw|�5{wәKQ�Aw���p`̰,�k[�P֬���lX�DǊ�XQ��J\r;�f�f���6/����mc��V����U�1hm�����9$~�`�l��2Pv��)R�$#kKg��������ӯ���:��,��ƿ����������\\;��AT,���|B�&�KYښ!%����W���z]��rh6(��Je9�&Ӵ�J8�g�t���?s����\n�&�\r:Ut�\Zq��\"	�g%C��JJJQ�/�V2����\\w�{^�z����_�\'X�#����]��w_�O�ѨI��9]���K.�h�T��k�L1�j��\"�@e��Th����\rl����j�֑�Th���7��}���cE\\(�t�L7qR�^U D�C�C�����o+.��Ƌ�~�a��:RX�#����>��w�uE4��-��s\'�W�t�D�(#H��&e���I<�d����<���0���PS��/o5�Rk^��@)(�\0#�t2A�6�+�,iM�2e���z�<*�*M)^.��;���dt������~Ε��fG��~�ć����E�k����jt��7���--��Uu�Ґ\n���񝒡\ZĲCᔴ4����S�%!���(2Bj�����Q�rU�e��ȌBV�*����Ikj���Ɇ�����z�9�[�X-�Y������<ob�S��Uyb��T�WHO\"��c=�\'B3U4Ht��2���\n�J��aʋ�$�tA�e,2d���k*����DT�č��)�p�������7��������g1ЏR�i�\'V-�z�E5�M���e�bUk&WE��G)~\"0\"��	�7t�IP=EYw���X���!we�����(�%o��1����:f�G\'�+o{Ջ>��p��\"�8���K��߹jeE֪��&�N�1,�f���rvUPh�*�0�P�7.��=��	%\nD��h:�02�|�w@=^t�~c��Ds�|9t�gO�?v��w����\0���JT%\0\0\0\0IEND�B`�','�PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0�\0\0\0}\0\0\0�Y~]\0\0\0sBIT|d�\0\0\0	pHYs\0\0\0\0��~�\0\0\0tEXtSoftware\0Adobe Fireworks CS6輲�\0\0\0prVWx��y T����4#˝!�S�2��+*��VK����$I{����E�^��D/JiQIO�#Z��RT�2�s�a�Ko���?~�o��=��sϷ���;g\n��^�0&��~E�7IP�qE@��$qI@��\n��oT$H�Za\0��\"nQ������$~Q�(	�E|�]�W�#)�������3����\n���/��\'>�����$.,�$.�>�r,���<h��l\' QH���H޶���s�l�a=,��������b��`8 �}�	K�-ve!�`��{�``i���\Z�\r��x�3��+�ؿL�?N���\Zi8�5��8�!�׹�\ZY�3���\"d$k 4;	ڂ����õ�i[�I�5���c�%`#OրI?�B돂]��<��a����2�.�ᐎI� I/-kX����(k�|��\Z��\Z��G��y��;�߹�2�� \r��xȻS/���o\0�����@;��w����FC k0�@*��5H������f��4������l\\� z��\"Y�d\"k����)��3���b�Eb�\\�������DQ�k����9�R�hTj_*����iɸ��@R@!j���X��Je��ɜBѣJ(ʢЈ��)P�Q�F�t*JӠ�h��B��R���0����S�wQO���X8V���`*�(UE�>!ׄ�	��0���(J�@���إ�z@Yd�{!�+��5�mA: !$&�Q���H�*\r�z\"Epݙ��\nP*Āɚ`]\0 ��ë��އN��+Q�g�F ZJ�,�y��	�\0C�:	���Ĕ�/W��4�KC��h�P2�}� \rHG|$P��,��\0��l����!�y(v��aR�:A\0]N��Ir$5�9XP��ڛ�/�������|��E��/|,@��M�.�����t�*���x�/�?U�0�pouH��1bdl��Ut�0�_�c��f��9��\Z\n�Pl4P0/E����E-��Z_8��+���EQX��R�	�r�10�hH�aC�F\0Xc����g�cli\"1�u������:wPb#�s�Ǉ�����9��;S�s��9ʈ�9��\n�b�]0C�����>H�h�	�3�Mda�ه�s�j@\0b�]*�\n�#���2��w�y@}��!����]\'��Y1���w\Z��?��$W��Sh=��H(E��0\n⌄T�=�Ρv�_�c�ꛘ�t\\���Duoe���jt�<O�C��$�b\"��Fu���ڄ���mx�{��V�0��,:Q��k����ɿ�����,􅥁<!-&�?�<�+Bc�ɢ��M-�a�).����_����u�!��\nQ�pt�?�\Z��#�jJ�/�6ĉ��H?J��`�Q�$J�8�~H�<KO��N\ZN��2O�:	�wv����Ta�v0	��z&(ӷ�iڈl*[F��Hx<�]�������	ݟH�\"^0)v�\",����苌�6���\\�n��\\3�E锸)�@���?���\\H499H���P�E�bD���Xb�w�D��D��#����_��ir<ػMGڂF2oe���}�������?���0�B�B+� 4�\"q�ퟋ߆���jb��A�E���\'���#�Ǭ\\��{^��%�H���xCԄ*\"�٪��2�{�2�# ���B�����	��\\Ú�1b�^ʟ7\'C�$<KMa[���h�o	�7�����o\r]��}��?�n\'\"���C\\��+���	����o���Gt2ɀ9���\0=2p�h�!�rq�2�����`\0X�h�G����m��x\nw��N�a3M����1��a�aW�C����9dC	އW9`\0l�p�dhQ�t�\nl\n�X�\"t-CH�1U�����}<�|�	���<�?�xa�`��R�L-��!vBp���!�CɐM��Z�;$?�i��C:��M�a�e�#�����?h`�drpv\r��\rau�<1�8Z:T�q\0�$΁g\Z��22D0z���?�#L=<.�2���BP��c\0�^����\\\\� \nƀ��柘0���`,8��c�gb�o�W*�0�*�����^Y���\0y�<�Ag20`b_�\"�^<A���ď�0�\"�4(:�Z(D�(�����^��/���a����$>�t	&hh,m��E�%�6���g�C���2��<�0�\"v�3/�\n����X�JV!#�� d!!X�k���?R�?0Q<��blD��S) _��-�%\\i��\'�c�K��܋%@`���cu�s�&�#���\'~�P>��a`	Y*E�z7~}���\'g$2�\r\Z�b�:�u�\'����bc��� 2qd�]�Y�߬�2�DƙH~Ip��ғ�F�՟Q=g�Q!4Q�G����f�!ȣ0�a�!r)�^$wE������ڨ6��� }�\0�}��l�K���_2����-����sg�G�B�\Z�U��(P��5���9~b�߹R�й��)k l��\nW�d\r~x��\0&	W�d\r�������Gt�@�??��A�?�k�}!nlߵ�e\r��1�5�b�*��)�&���K�C�������T>����?����8~�^�i���d���֨�X���,��n�7��g;��������rk�_f}G���v���U�3���mߜK�Iiz-����|�%r�c̝w��A5�q,���`粃�Que�����ִkx|�S��̋�����OR\n��m���u��>�����VVu�4�j����S=	��yQ{���Tey̶�-l�QT�hs˹}�m����{��	��Y��Z{���z����l�R�Wݳ���Om\'����L�k{����غ�Ҋ��H��u�K�\'���b�R�]jN�%�������\\lxn�G^�\"����mֻ#G��6���89m9�8[�$�L>z�����F�L=*��#��6����짟C�~����؜�5��Ȼ�j��~��5�o��FS���.eo{����S�¬��y��g�3�\ZW�e�UE���,sn�a�UW��������M��-�u�vۨ��<�I���7X,���z��U�M�ɫ��j�ޕ�j\Zg�i��{\\<T�(R���~�c�(�>S�1�����[j����s���?)n��:����-��ヾm���5��{qܲ��k�G9����c���H��-�����!�9#j纯Ҵ�-ߓ�Ҟ�k������Fw�\');�4��V*��3���Ys�W�`c�A��Nʌ�#|�7��?:�����99��.�Y��c.�.���zߠt�\'@;o��d��L����������G�b���on�5(�fq�Ԍ��5~=�Fy�D37nYt�-�eΎq4w�C�\Z\r�:��G�,ǩ�Yn���kD:7��+u<�cp��[�W��bk���g����y��˗���:`FJ^E����SOZm���dr�r�\Z�f��M�>�ܚ�˻������S�o����8�خyi��Н�۟O�rxřo����}V�|t<;祳����ꆇ�ȱ���Z�>���sÇ��[��=,~���m��gjOnr~$dx����G\\��8\"0�fDQNU1H\\�n�B^e����#��nY�;-5��;s��u\Z�~�Ʊ�.W�(�����ʣWN�QQz�58ùp����O?��wt>����ѮO۝�ݰ8}��~��<�=�Ѭ���<��KfI|�#c3\Z2��>85݅}[w�/C���M��nu��衚5AT�S�\n��EzN�-�����&ʔrAS���s�wXn��K�kr����Pe��x��?�Z���>n��r�P�#>h�����gh�iݚ=���<��r`�B�!�?\"n-L>df��*é�퓏Us7Mw#+iA��3�Y��Bk���K�����m.W�_G5�>������Y�{��/��,��}uw���KnqWb�}L�O���N7Lժ��NO#�}�Ą+N�����>��]I]�������ХOX۪-�����1&������Ir](ͻ���͇krb�6��z��1�X���\"�������g[��>9O��7�-A�g��әSu�cc��^��<�$;�=���}xԞE�7���h���/�w��P�Ӝj�n��I��4(�ݫ*q\rRY�ۛå��Ws]Z\Z��Q�4TZf;���`M��Y\r���T�\Z����{�~}��IKN�|��=֯l]��=uF\\Mdz��T��щ#��[����8Q���W�\n�27��%�3����\Zw`��ͣ�|.\\��6�і��CεU��l|�a��i��0;�cZi�^�E�oϘ�~cE˅�����{&m�\\�:���P����cV<>�f������G\n��+oMQ�T�V�φ�V�o�����~(�>����v4���;����%w7�S�]Զ9�¥�dV�|���0��%�ϴ�)�kv�ڼ�Қ�8Y�N�K,ٯ�ᆊ�Wg�]m�s�7�lV��3K�F��6�~���������͠��o?퍷[I�����V��)x�f�k��e��Z;��n�+�i����W���5U)�k�C���ļF7���KZJ4�\\d0�*��|2y�Š���V�������6e��,�fɝۧd)�x}�9�y$����W5�Z�&Ԗ=��{�@]�8p����ū�����6P�5E�>�u~�O4�l$�~\n�|���nt����&�37�Էd��M�;zPth����ҽ��\n�ͱG�ء�C�=9m�\"x@�i;6Ǻ{-���c�ãŦ5!-y�N{�nP�wۇ����%�>q�ݕU��*�1�99ˎϿv�����ηJ���\0��\ng���]3��|���������rnL��4M���0���uU�ό�Pm���/�3\"�ǫ|�uY!�4k�i���*�{zkػU�#������֎�vJ�|AS�GT�Ö�~^1nz��3�-?.���=�6I��Ռ��A��1�?��\'���������	��m��>�����Z�J|ܒ71�����ߩ�`<5J�\"�|����c&�\ZlŚ�:�lC�K�b�C�oo�Ŏp��`Y��)�_��_�67��1�Aӭ������~t�̉�NS\'\n	{���ɬ?�2bxYE��<����9��kV��;ӄ���7�\'��\"��cE�Q�����m�O�[\\��N�5�M�^�K�؅a3�|ǝ9��k��U�������)ӡG�]rJ��U�ge�_�H�I��L����M�O8���8��^���k�]f���F�7�r<�u�d�RH�nr駟X��L�r3��?��~¶�㪙ӏ5	�ԃ��n�3+�J�9Z�h�s���;��w���5W.Z��|�?��4j��.1>�U���X�t�����\0�����W��\0\0\0HmkBF����\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0)�3�\0\09mkTSx��]Ys�Ɩ��Ʊ%۲�L�y�U�L�S|�|IQRBII�r^\\ Hؚز��ė��>}Nwci6VRe�J�$��w�ӧ���nf�ó��\Z�ʹ�;hǚ�oGg��f�^S\rN{m�oh�����tK\r�F�Lӭ`�;�g\r=O���=r	��^�f�꓏���r�l(c�S�*}e���ogʇ�����${��M���=S�\"G|��1\\r���CzlL���9�^�I�}������xа����شz���+6�#v��.���nu�э�>��Z#�sD�>\Zқ����`zy�R�αv6sH��e:�6]�Q\'�N��2�!CF�Vv��+��g��i]�왬3mA̴���1�lO� �|Vޓ}W�4�b3��F�b�y	l�l<�bc���L\n�K�q)<�ǡ�8���;��8Y�?&�Y.������|\"����HX�0]��8���ne��@S�,4Ns�+��mK �[tϐ�qH1H[(�g��\0}�\00}�ʀ|�&�&�R+�R���ʭ�U�[��ܦa�a�O�_ �����ے�v�6��`�l��gɖ��z2\'a��G��2�sǲ�Uz�y��A��`�t>W`\rW�u2u�gV�F�Ш\Z�B�RhT\n�Z��!4��5��!���5U���YH�ӈ(�3�d�W�����L�S���#J��Qڒ��\\y����g!dQ�,�����Un�/��iԒ�Ea�(L.�ɥ0%��\'�\"Bĺ���5���z��*&f��>�I���\09f�}��.�dA�H��!�\"dR�L\Z�Y<�+dCy�<\",���i����T\Z��ԚJ}�<�P�\n�+��7�����l���)�wa���tS~$�?)��4Ll5�����fy��R)��\0I?+zN:^�SK�aq��MJc�-Ѝ	���(r�%�5�&�}�b�U�7\"�gpT Ӣ\0ic��x�O�yY�\nl��[�c8�̧G����y+Ԫ: {�(��l�5��g�\ro��~`�&��J�NC`1��Ȋ���>����=L��������z�c�0mʹ��vT~��&��1A�7��,e�\\��03&fa�Y]([<s�LMy$�����G�$}������� ��nc@�O�|�!�F@�Q��d�_¿JC\\�ٓ8f��a����\Z�z�NqF�(�6-,�!��_���\\c����b���Ysʜ:�j�\r�,�7�%�锲�ho7B���|A[Z%6K�f\"T�Xd�a^\n%�2t\\6�˦p�T���/c_e�1��9���q�#���G�+d1�O�$�,ؖ���u\"�*rW�T]VA�a����9	L��٤p���S]�/M�&�^)c�(+\0�g\0j��8qTi��x�aj3Pm3�=ñN��JUc`�e�_IV�@���oS��e�U��ER2rWhIޣ=7���t�1�}t��3w�=�?��v��(�j�9�E�cNid���h���U�C�S���tF�O���3���Wp�o���\Z�� ��o;�x>LX���\'L��˩#*!�!Xbe��cIM$M��A�!�{�l@5[��R?��WWF��s)n:��.���9S�3� �)z�ϡ�y���cz�h?�ˀ�/��_���0>� f8�U�H�#�Ƈy��nY��|�<�5��!�n���Z���v5��\Z�1��4�5T#��6m\n���b��<�c��PmTD��`���\n�j�	�qTS�mʙ�bu+ m2�O=�:����~К_��a��]aL\n�\n!�UE�0@��i2GӤ�\Z�[[dY*�R�����l<�l]V	���CE�eG����?͝.:��8��A҄�ab�u:��q��ˁ��0�A\0�8�)��5���5��S�0�\r2c��Yl�R;%���Q��JIKgü[��\'Ͽ�cX�k��8�Ţxݑ��0<Z\"�<�7x��*���2dA<�ͦ֖�����3���\"�K�\0\r��,���>k��\n��(+O{�Z��|l�w�+>��d��eR�$�n	m)�2i��J���d����[[*�6��E���[r�_ʶ4V����K����Y\"�K|(i��w��.ݎ�&/��\ZL\'6������}�>��a�.���l4\r���N����6l���f~�-4��`�(�:3���:�$H�\'|�s�r,��P߾�|��>�ѱ��2�D�q33\'� �����b�\Z2L=G��7Y<�d���q��.[g�\\����g�7(���%i��=�1əci��I�K�7��N��2�ПL�\';!P����F���g ��x�Â�K���M�J��#�P��=�&�����cBF~�%e}����,1#n��X�\"�l,���T��&�MT��@�Iơ%	��P:�yE�#�dH��ϙ�hbT*��;�|�>u����DXt��?��Z�b��2-_	xR�Me�T[)d/B����ʦG�Y����J�X~ԕ���\"A�h��r��I�y^�PE�>�s�R�i4�d�ٗJ�<�)��{r��xqrk�mf>����lX�v����HﱒFM�s��\"�v�<�V|.L�v��i��#����|l���02��n�{³��+[�.o�K��q�e��g�1�^&-��C��4�2�܊!�&��1R\ZC�*Q��h��WG�X�\0b��kH�fp�7�/�\'�3g�)żW1�\\�8&ۯ�e͛N�/�*>&\"ذf~(���$I�t{��Y7>�G؆��;��0��#\\0�#y����إ�ѥ�ۥ���\"�u<d0���is\nMЍGq�Cl�/DlB��{NR�T�N�D���G/H�p�	v�b�)\\���cC�`�=�\"�|����+�Q�^��|���\Z,]�Ċ����.��b���7�O]�:Z�K�]�7B$H�����3�<\"h$�0�9*��\Z�J>�&_�m1�\r@yhȢ����Jv�I�c�֥�uk�V �f(�0@\0H�,�����$c_5���fM�$��\nSo6A2�ǜ8f!��i5e+P6r�\\\\\0,*����~���\Z�,J5�&�D룻��f��,�÷��l�F�%Z�&�D�\"0�N�h�I��jDs(ќ�h���m��g��J/�<ed�q�{D5�6)I�5I+��!#i�b/�Z?�Tvʠ��\Z�<J.�&Wrm�A!H]J��=b<��F�	%ݤ&��5N�,^��$e{5�M)Ѧ5����Ѱ`l�~d|�Iƾj�)�DǞ��4U�J)�G-��q�I��j��X�ڎ������/3�kD	��I�*��<ƭ��N�x���� �YC�(MU�qFQ_Z�e1�Ǹ(�зu��q{%�_8���Ґ~�e�ꮛ��\'��;�♙h/�Fw�8��].Ǒ4,��RYrVo[�E]5�d՗���j�fC\'��!F���ɯ�^��ݩ�jɝ\r+��#�����w��7`8x��#n0e�j6L[D�Eb<q</\'�k{�T���3�\'co2Oѻ��Se�Q%��ٗ#���l�NcsGuTpw�ln����9����؜�8��4��t���&�@}�y+)�V�7���0\\gM���ܻ����F��?��L��nl�����p�=���M��\'���)j�ֺ�w�\r�Cn��F�aAՏ�\ZT��4�sNE���T牗u���I��C0���u����7�����V�c�p����F�}�j8\"EʈpX�m�)#bB���?��q�&����u��/�%|�0f̋ճ�R�Tg��w[7Y�aJ�\',i�R���	��5��T]����JC���&\Z=��n�É�����\\g�y��n�f�ۍ\r�N�����N�|�����?��>����x�٫fv�ÛY���\"ج*\\����:l�K�A����o\n�X��gʮ��u��tz�{W=�{�M�>�zV4]�ؗ����P,�]�%D6p���MZ�O��S|9�;�.�:�s<�2<�H��/�$>C��������M�u�!b��!VW^�7��a��	g����#iag=T�����=�ӻ�d��e2w�9_���/<�>�`��؟x�g���%�	�J�x���Y\'��W;P:���Qf�`�M�\n����;�	���	���!�\Zd���G6ȧF��� q׍�#�P0�36cG��ixDC��掎�(���,l�8H�.ഏ2՛2n��J8s�S�&�3�3�h��g�YǄ��Gi��{@��楠��q���EW��n�ZK�V<�	��Az�E�hE.\Z��Nzt��O��.ȶ8w�����3v��1=��Ĩ�K��\r�����~@�ZC�\Z���_���k\r}�4t̫�5t��k\r�Ukh����FCo2\r�;R�wr�w$�ut��k�5�h����FGs/:��k\r]k�ZC�\Zڨ5�������e���ڹ�εv�����S���_;ô���w��s���r�l��yʹ�Dn�ʻZg�:��u��&:���[�Ύdq�]W��\Z���ߚ��+��+�j\r]k�oECוw�GCוw���u�����ʻ����ʻZC�\Z�[��u�����u�]��k��-i����i���εv��s]y�nڹC�Z��WQ��9Z��m�(Q[/�s�%�%��TL�7!�s�\"1�\\$J�+� m&���C�ǦٰF���\n�����c�� X+�=�O�	^)�{�3`���5[��X6�����f�ۜ{�m[���]�D1~��b���L�¾�.ܡ�EW�j��ݪ}QC�;龨�Eu��~y�O\"}J4t����r�3ĥ�е���\Zz���֭5�ת��F�T�d��g	�Q7��~��mO���.[`19�Q@N\Z��$�s�1�7x3�S�A�1��Y,[`Ix����2n��{���}@9J\\My	s�@q�\'��P>��Hϳm��3���c�`�#R�ƽ%�\\���\'�}�����?��$Ǐ�&�G>A�O�F�h?9�C��\'��y�v�o��	9>��I�����GE�p�f������K����yfE߫����fuO>AM<\\W]�fYJs�(�$>!�tB��k����m�����Z�Wp��]\0��k���\'��A��)3��4��q\Z��	���:,m}�	���|B�<���Vz+��6�y��t.�W��X��T�rAB\\J�+�����$9��R��w�Gs����i֚������_���Q%�ccə��\r�q�p�f��$�}���kk.\Zv���\"G��?!���O��q_\"fW�e��-��N�Z��9�-�g���ٚ����U�;=�_�.��4M�3e=StV�gJ�S�3e�eKr�w\n{�b�3��$�%�����X�ok��bglI{�<Gֿ\rr$H�G�)r��yd�.��ŏ��V�$�->���)�TI{*�a׼H��\"�#�5�����c��\Z3L��_S\r��\Zڬ5t��k\r��i�4m��k�\r��}���^>t2���Q��Ptb���I9��2��������i�\ro�}C� ڦ[�\n_��Qn�~M�X�5s�Y�Uo�k���r��C|\rƵ��	J��y�&�<�_m���<n�I��a�m!{i�>H�7�FIeY݇�Y>�6<ٗP����os�n����̰�cǱ�B�������y�؜Jƺ�?�F&�v��r�2z%i��\\�6��T~�r@|��mfCw�ٟa�cm�d� �@932iMq�K���b�	�C�|L󨲉=:g�崊g}\"/k@T�����8��{�H	�����mɄ�$�߇������୑}>��f�r��Z�{;xG�ec��!0�#1�|������J5����c�者���Xd_�^����{+�=����+�#yr!��G�%i�~J=���u�	��pc\'<W��y�8�p���w�\r��l���O}�x�H��u`���Ve���\Zf�����|���?<?��+���!N��z��5\n���އM�o���Y�`��Q�h�),���\ZL�o<�3oK�dQ$�\rI�m�ҩ�+�᝶��������\Z�]�ٸ?Q~W`M֏kk}�lfH�f�tDf͍Qv@�l���(7>�v:Fp����t,�y����Z��3�Z܇�b���C�\'����iXC�c��fY���9���]w%}�X���u]��P�A\\�v4ʣ���Q^�N�,��3r�s�C�l���ԂGɏz�GP.q�U�Y;e혹�v,�*�X$�e��YחimkN�> O�I��ȸ��A���I���0vp�q�5�S�kkǘ����c���9:�Z��m=Dѫ��iTH�_F�k֊���RA��y��\nq����\Z8k>�~�Ë�5Ԅ3��\Z�/S�\n}~�@=߰�oȩ��߯׎�������}��	�.�����ZH;+��b��:�a�Ƶ��p���K�b6[������	�|�\Zhz�����đ��`����H��Q��z��Hr�Ͱ��y,eFyV�A5�1�տH���&Fh0����륟�ıQ�\0/���T�q\\�d�F�e���zs:�Y%|Qt��mU}�}�ʋ/���l�/���j��0\'��\Z��2�52��P�6G��y��Df��J$G������֞�&���huZŽS��~��E����t��i��~��5�2�Lp�j�V�QL��\'��;S��ϐ��}�h<�8UE�h��&\rB�VD5�2\n>m�,�����<�I�<F�Xg~4���s���y_���W�ڞ[ܠ\\��=�|�>����8�Xԟ����	Fn�s�}�����tr�i����\n]g~K���UЩ���pH�������ͬ���|_�A7��R��o���r	u�?�g?I�3��g亣�4�]l��g3��\Z�ʹ�;��!�ݷO�Sh��i�fFo��?�؞����f��O�q�`������z�)F�)F��Yß�>�\"�N�˹P�{ڿ�uG���\0�~���� ����}���o����{��C����N�!�̔ف��j�K������<�M���@���qI�K��r�[l���A���=���@ӡMo�h������~���kt�Qe�A�	��\'�X��v���C��h��#gBs����wO����м�����`��F��*4����}�\0����*��Pc��Z�ݣ67��aw���9�тv��i���ڭ����_�ÛY�;�g�K+�����:f_��)B��u�A�����J�&���	�?���o��8P�5�*���������?�Q� \Z�\0t�-xm*�=J�7�ҽ�7D�݃\r\'���פKc�\Z.�=A����6^�s���J؅K����=�W�: ���s�S�� #Eס�yft�u���Z�{�~�ao���������]��E���9t���(�s}B��IJy��:��6Ɛ�\Z���������J��M�ߥ1���.a[އ��$�j%II����O�q���`3$�t�e�h�C~�I��F�\'���b��:؃�ί�]{�}PB�Wp��!\Z��!\n]��I\'D�����!5\r�X3��(Ҧf�^��N�{}ЁYxDA��j:�ݡ?k��`xWo���؉>�Њ,����%�J�9g����Ѣ���\'���x�۴�����1u�V�\0z�:<m�:�i\rw�!��7Ҵ�F�֯ش���ul\rИ���N��\n�uD7�.o�A���ֈ^}4�79�ף����zED�X#\\H\Z.�96��j`�:]�64A!d�C���9G?�g���8�?Y%fڂ�i���c��>>�e�5gacRl�بRl</������Pl�4:�I�q)<.�ǡ�8\'��\n���p�Z�at���K1\0_0\0�iyt����q0ɅM��B�-���iYh\n��.W:Bۖ@8��!m�>b��PI��)�|�q[p�+�R,5�\\��\Z^E�u��m\ZFOF��MX�u~[r[���F�l��a� �,�R�=BO�$�2���U��X��J� :�7x6�������\n�N��̊Ш\Z�B�RhT\n�J�QB�<�&�À�fi�,��5U���YH���m��-N��qz&�)RX�%m�(mIQb�<Fwn��(BE�Z���Y�˽t\Z�d8cQ�,\n�Kar)L�`�	�i��}o�V��Ǧ(X��:��6)@�? �̰o�� �,��!�\"dR�L��I> k\"���p�l(�!��a��/��Μ�\'Ri�Rk2(�qV�,BY*|���,���CatQj�n�\"8]-��CI��\r[�(�k�Y���T�$*@�ϊ�������pXmh���etcB�s<��tI6AͲ	zE_�dU���)#�dZ m,����#/KP�-�yb\'����T�\0�<o��ZU@8�\rz��fZs�|��p�v����f]I�i,&xY�4���G�s|0��I�֜��E�VzX��A�v8h���	xi�\'ELP�\r�<K�,W�2̌�Y�vV�Ϝ2SS�>�5�?\Z$ �,��-\'��u}����\r�7ʍ�%� K��eP\Z�*Ξ\\�1�������ճt�3�FA��ia1A���=L�\Z�@��67ç-͚S��!T�l�d��9 ,�O���D{�bv�����f��C���\"��;�K��� \\�.�˦p�.��2U��e��6f�?�{�8�pD�S�(�y��,��ɑD��2^:ߡNDQ�@�ʑ��*�>�?W�#\'��P8�Ntzcp���IѤ�+eLe�}�Z,/NU��j2�d��T�Lc�p����R���B�+,�?S>K�z�mV���?���jִHJF�\n-�{���[<#��>fc�Ϧ\nF/�����h[Q��sR�<ǜ��-QѼ�{�����F�Y��&F)�4a�g)�9��r�\Z��e5�A���v�%�|��,��O.��S�SGTBLC��ʘXǒ��W��$1Mb^FE�\\�X���+#��7��O��	�˙c�	�=���P�<Vj�1=G��e�����/����	�zt\Z��J)6c��s��ݲ<�-7�2yk��;B<6D�2g��1l�2jt)5c4�;h�j�FSm�D����\'y��F��ڨ�j!=��!�R�L����T۔3���,V(@�d�z�t$�����5�0Џ�`q��B����a�G�d��I�5<�-��ȲT�j�%@�x@ٺ�.�5F�q�pG����?͝.:��8��A҄�ab�u:��q��ˁ��0�A\0�8�)��5]{��5�o�x��E������,6�����@Ȩ�������a�-\n�ѓ�_�1�U��PZ�bQ��HSn-a�<�fX�q� �f�\nk��X�e����I���%y\0��Gr�eR�5�g��q���=L-~R>\n6�.���*��0�,�bh\'1tK@hK�P�AH�U�%8&+�uƆ�\Z�R鵙�-�4t�b\\�*������%��E1��D֗�P�dl��]��M^�5�NlP�ͽ#����}*���0]�	��fZ���N����6l���f~�-4��`�(�:3���:�$H�\'|�s�r,��P߾�|���k�K�	/�Kt73s�b(Ki�!��!��s�|���M�lo��x�q&�e\n��|�|���m]����c!��9�VJa�Ժ�y�i9��(.�\r�ɔz2X��\r�5���jD����՗�mR|͉>��3�&�����cBF~�%e}����,1#n��X�\"�l,���T��&�MT��@�Iơ%	��P:�yE�#�dH��ϙ�hbT*��;�|�>u����DX�/����:�\'�i�J��Z\'m*Ӥ�J!{Z�X�V6=*��/�V����G�	�E[$E�� LrΛ𢐆*��!���jM��$sξT��yOa$ݓ������[�l3���LE�<`â��.��0DzOׅ��e��@r�j�Y+>&C�|��4�����|>6σ�i�B��=�8�2w\n����/YfǑ��B�%Ƭz��\\����p>��Cp+��_�$��LHi�~�DA~����W^b�<�I�!)��!v���p��ϜUxD:��^�trQ/�.����t�exV�1��5�C^�$$I�|�������n��n<��b~!b��s���Z�t�%��=zA��PLX�s[O�2ԕ����y.W��{E��������,�D��c+��vi|[���}����*^��\"�� A�ǌtm����Z��䋽!T _|O5��|FM�\n��b�����k�D�\nI%;��1��Rº5a+v3�K \0$n����w���\ZMJ@�&���_��	}� ��cN\n���մ��(�_..\0��lx�o?I�^�j��Um�����b��}����OR�W#Z��Qm�u��%�8�����Ո�P�95�*�)#�.����^�y��$;�$��j$mR�6k�V �CF���^�#�~8��\"�Aqk5ry�\\^M�\n���B��0��G{�x>�S�tJ�IM�,�k��4.Z�h�I��jD�R�Mk�-���a�0(�������}��S���=	�	�A� E��%b��#�?��_��\Z�C���/c��_F◙�5��äxn}��kr�\0�]��FZg�!e�����8��\n�!�e1�Ǹ(�зu��q{%�_8���Ґ~�e�ꮛ��\'��;�♙h/�Fw�8��].Ǒ4,��RYrVo[�E]5�d՗���j�fC\'��!F���ɯ�^��ݩ�jɝ\r+��#�����w��7��\"�Ϩ�#n0e�j6L[D�Eb<q</\'�k{�T���3�\'co2Oѻ��Se�Q%��ٗ#���l�NcsGuTpw�ln����9����؜�8��4��t���&�@}�y+)�V�7���0\\gM���ܻ����F��?��L��nl�����p�=���M��\'���)j�ֺ�w�\r�Cn��F�aAՏ�\ZT��4�sNE���T牗u���I��C0���u����7�����V�c�p����F�}�j8\"EʈpX�m�)#bB���?��q�&����u��/�%|�0f̋ճ�R�Tg��w[7Y�aJ�\',i�R���	��5��T]����JC���&\Z=��n�É�����\\g�y��n�f{�S�k�*X#\rY��u��?��>����x�٫f�W�೪p���eg\\,y�/���J�(���b��_V�+�.h����X�9��Ͱ�\0N��� O%��S|9�;�.�:�s<�2<�H��/�$>C��������\r_�-\"7D��W=���+��3�c��4�,Z���}$-쬇��K��ܓ�����2]�2�;�������xe0�\n~�O��3�K�����.��4���⺁{m|�5��\Z�4w��W\\k�~Y_<N�a�\r��[gU��1�G��`\nglƎ|����<���{3�G!��8�da#�Ab?t�}���ޔqK�VC�r5A����F�M<�:&t�?J��W�����PP]t���F��Dl�#o��czx;����+��u�����p?�z��k\r]k�YC۵��w\Z:�U�\Z��е���5�Vk�{��7�����;��;�:��ѵ���u�Y��{����ѵ��5t���j\rm�\Z��h�LCò��yk�\\k�Z;��Yĩ��믝aZ�y�;�ڹ��_�v�j��f�Y\"�u�]��k�}�:[[�]WޭBgG���ή+�j\r]k�oMCוw�OCוw���5�����ʻ����ʻZG�:����u�����u�]��k\r��i����h���εv���s]yw��s]yWk�Z;ڹ��[7��!G�bx��(R����6q���ѹ���o*&����9K��l.��j�6gg�![�c�lX#��t��H��y����Rj��������=�0K���-TS,��@�gq��m�=�-�mq�.z���A]1��u�`a_T�P����E���nվ�!�t_T�:Op�<�\'�>%\Z:��h����Rk�ZC�G\r���Q��\Z�k��O#}�L2u���ۨ�{?��\'�Yw�-���( \'\r�g�������ǩ����,�-�$�Tg���T�gh�>�%�����9|��G(�|����6A��I��E��)j��L.P��U����\nq��W؃ȟ��Y���J���#���h#L����!���y�<\nG;�7�Ʉ���Gʤ`��v�#��U�d3�s|���%m�C��<���U�_�Q�:��������}�,��^��M��]:!~�5��vU���}|K�?��+��{�.\0Z˵�]���� �a����u�H�8\ra��\\EE����>����s>!�	��H�\n���T��k|:�+]�d��O*B� �?.%���s�wԃf��~^)��;ᣋ�k�C�4k͇^ȇ�|��/��w�Y娒䱱�������m�\\3�\0�`��>���5��5\r;��q�#�����U�@�/����2K��~��S-}���ɳ�F�l���	R����Ǝ/~��g��晲�):��3��)홲�%��;��E1��dwϒ�MD��q�з5�?Y�3��=L�#��9��#�9H�<2NQ��G�c+V�ď�R[���i��=��0�k^�JB��K�R��1�����ӯ���B\rm�\Z��е���4t���ڵ��׾A�Y/:UMè�X(�1�g���as��	h{����׆����Mm�-�n�/���(7K�&�x,�9�,����5��f9��!�����%�ļc�y�����Pz�C�$~�ߌ����_$�i�����C�,�q��K��dc��9r7A�bbf�Ì����M!w��M�u��<VlN%c�|�r#�T;[�c��4@�k�NC*?g9 ���6��;���0ұ6R�f�O�����&�8ť�����ۡD>�yT�����rZų>���5 *��G�}�ƽU��H���dB�c���ql�}�{}���>�G3�t�GU-ҽ�#�1�����m�w���	�n`���\ZG�^��1qt�B��u,���^/P�G何���g��?���<��f��#ϒ�\\?���OҺʇ�]��1��+{�kU8�Q���6ޏ���G�$T~�:0�O\\��\\FK\r3Z���y>������X��?���vz=J�\Z�P�A��&׷�R�,R0Q���A4�V�@\r&ķ������A�(�̆��6_��̕���N�؃I��z�]}����lܟ(�+�&�ǵ��M63��3E:����(; ]6Frc�c;#8��W�~:��<��Qe���E-�CV�v����!�[�P�4�!�1�B�,M�Ɯ�������t,�PBܺ.�{�� ��J;\Z�����(�q���A���9Έ�{��\n�Uj����G�x�#(�8��ଝ�v�\\c;�G�d,���2����˴�5�y�����yd\\��}ڎ����s|;8�̸�\Z�)򋊵�c�y�I�k��1�i�^�Vz�������4*$�/��5kŊ�DUi�~P�x�5��eX�u޴�h3@6�G������@��D�ژ�r��\"�f��������0EPMf�A��H�	cM�G�l6ļ�z�g61d��֒�>f!L�Yy��nƪk�L��Eљ�5Ƶ>����_�ѹ!_�w�!�	�����G����z�a@i\r��a�>΢\'�@�]�Y�\'�\r-i[����huZ���@�G��~]tj�LOg�Y�F�+^��ᯌ6ܶ�L�<�I����g,��>��o0#���Έ*��q�{I��D�\Z8�6�BZ�U�d�$E#�S��\0����9}� �P���g��J�v�������Sy�xĈ��H�ɞG\'�S���8�y�)����\'�@IQY͍���&���UЩ�b���N��G���?�>@�9_�sf�Y�D��[�2�����+�W%�W%��J��W���uIV�2��)3�庘���O�i!=�X�3�A�4��p��k-�^Zxk^$�p����Z�����U�t�����~�cZo��[B�ٟ�OR�:����u�n����L\'�Fg3-�:x�`@�����`tں��? �BSN����כ��>9�Q�}֎���둧��t�f\rb�8r4:�.�B��i�f�=�#�{h�=|��9��8���a\\�?b�	Z����f����_;l��2SrdN؃���/���f�C��6}8�{\0�/C8�%�.�9���2l!��>\"z���`[oxM�6�!R�=<��v�Cx��7C�����!\\dDC�\Z6`�?��b�ഋǞb�G�9���^�{J.�G��͌|���\0�6\ZmT�!m�\'�c��s4T鵆\Zku�\Z�����N��\r�)<��[\'xL��\\�n��������zݑ?S_Z��O�ؖ�1��O����t����{G��:�+.:��@\"��=������k*������$��~ƀ{�AP�oa9l�P��],�q` �P��8�!$���!2����d@����[\n]&yс�I��!:��/��t���h�]�h�Wؾ�#����\r{�Q�~p�n?=��4)��)͡�-@y�4���*oNR�\Z\r�	�w�1�?�!�������J��M�ߥ1���.��v��T�H�X�7�=k݌�{u@8��=R����_s��V�i��˿���A,Д0�vt����B�2w�`�C|���>���+8�x���x���?�d[P�絚\0\0\0�mkBSx�]N��0����\0���Æ�\Z����	WM�����- �2�����*5X�|D�Z�\Z=�f��Lc��(�F?\n������h�Ҷ��B�L�r��Gp�od�g�d/�e>�f\n9��]�W��A\Z�\\��\\L�f�[xi�lϣ���Ts1�H	�Q�l�H�اE����t����(S�AZ���_Y �X\0\0<�mkBT����\0,[\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}XU��6�رbnn4�.*\" �1\Z�-�\ZŮ�wQ����{���;�T�Л��{�}�5{����K\"I�=�^����g��5k�Zkf� ցt��@:Ё���]1���1���-����rO�c�%<�/FC@������O4�@����\\sy�D�-_�����M�ҿ��4\Z�G���HT�K�d{�T~����ߠm��?�r(��PG�Z#P{c��_�ω�\Z,��u�/��S�N�v�3I����p�k�D��|J���La����؁����>bx$�&�Ψ6�,3)Tj�#9�j��\"�m˙�\"oQ����i���9@���P!�,�q(�T@��x4hA����{GD������Cɀz\ZOi<gW�N�v�,)��NP}}r̾�K\r�(�7hs�#�����H�{�8�%��}3M�U���cLs��D<%�0��˂�:��D���\'�W���ɗ��M�$H4�Xha���F���MG ��Zt�\"O{��Q����o{�<����!7`\"\Z���H��5ѽ���4��hpC��P��ˢ����Nr}�>!5����3t���;a׃HAh��\Z���h���A�Hh\"�����CY�Q�/��;C_����[�[9�.3�x]J���3u����$��aб���ߡ�s ���」�\'l0��F�� �iH�E{��\"����.�I5�K6��-���0��y���~������������(\rV@�[\'^�PK򀍉�]�b�9\n�$Q�9eҨ�\Z�\n�ѨӓF��x��ʼȱY�嬴:y������]t�C�ze).3Q�ۗhN���F|N�ѽ���Y\ni:cQ�9��P��4&��f�נpm��97嬓�l%ƭ-v��.��u�}P�M��+�܏*��hq��u�HԺuA��P䘏D��䛍B��dYI\"ߐd��84��:�1��6O�f^M:O2�su������9��̗�	��8xBc�1Ʉ���ܳ3\Zܻ���/2-G!W\"�h�h�.�B�����;�H�3u�����������\0�	Ih!{���Иh����|��^�}�)w�y�Pyg<�hG��F�HCQ?K����F����h$]�][h4�<hq����	O)�\Z�v��e=\n5���AO2픾�(M��t� ��@V�v{�D�wTx�F�Oo���O\'�o����֔���as�{D��8�k�B����h�����>���~����ދ��?���}��8ډ��>�-ܕ��{a[\\����)<��Y��N���t�F��h�{�HiB)<���r�T�}�Oe#�vYy,o���.n+b�I��et�8��߀\"ƅ�{�)9I�I�Q�b��&��ɢ�g<�]�ć��g�L�J���c ��\'�Ik$j�c��\\�5ȳ[�<�U�5׎������\n�֫���]�?���P:B6�eP\\>��t�{{>o��*d9�声,���r(.݊ʠ|�m�X}��l\nˡ�L�����q�x��Hr�Z���+�d�mt������EM����އ��pm�t��(��\'n����#3�Q��y���Qqsa�oG���(�>U\Z�Qt����Pru8�)���(���pT�P�-\n��JB!�%W�����}!�b�nP:-\n�����Q�ŗ�Gi�)M�&_��SyT~%�WP�y����k��n\rC��P�_�\'�o�B��(6��C��΋��ŝD���\Zk�r��G^�O;� 7�Hv}ّ���!9�K�\ns���&Ov�}�c�O�rS�\'�THDݓ|j���+�����z��R��5�l��ܾ60�Q�G7�X�}��H��8���3��ڃk>����� �+!Ð�uAhAW�AHҢ{c�Z��>��h���k�Od�(O\n]�tM����/^s�)]\"��S8+ˌ/3ń�Ce�S\\*�De��B�o5Y�c��r(ՐE��x�9�w�@�����7�BkDM�?��G]��j����|�l�Մubf\\S�س��0�`��n͐#+�Ǟ����b��W��a9�����q�/�8b�h�&pW�����SZ��E�%e:<*�[�\"ɀ\0�w���h>x�	-��_�I�y��ˉ\',M[>fs6���+�|O�����-��M��/>\rW�[z�i�N����q���ֹ9����[�=y��Y��+J� ǒ䃶4��$Ѩ1��G�T[�,����{ᑢ����:�]\'����}��ʸ\Z�.���촼a���b��U|y�(�ӚgpAN�����m�\r���.���Sm��a���d.�֋�;�T�+�OZ`� �s�\\��c��mA�?�9[c��}�l�3^�d��KJWC4|B���<?�������y ?V����u��T�����^���oae1?�Ӡ�{߶�N������4,��/-\\��>��ȴ\Z�\"]�j��9i4ʍ&�?�=*{�I��i�G�v��`��eb3�c��*nEz5�9����UYkr��:��N.18,��Ě��ln���LZ��\'�Dm�~>5���-�&�i���g=��\nTD�S\'��\Z]y�z��n^�:\n�����5RX5�1��\Z�N�c��W���|�F�V�w���س3��ڛ�O2;�1�1~���+�nD?���b���sV�|^|Z��ŏ�z~O�l��Ƅ\'���v�l�a��-�f��`{e\r�<H�;*jZ��o�6�y2�MILJsn����y��K/UY4����W�CH_߁q�w�	6��R�H�:�+�kQ<��r���V+-��F=uC�=K~^ǡ�4㷕��\09w�,x9r�!����Qxw�_�Ґ5(����Q\Z�9ዐ���/DV�Z�]������[���5ȿ����!?De�+Q���,�r��Ѕ�\\�����\\����Pz�;�w%չ���Q�ȋXCu,}��&��ad���#����癗4&\Z}�y���6\'}RC\r$jo}�,�h�rd����������Ѯ��Jb��*n���}zi�N�ۊ��nx�Fc��۪p�0�������Zj�t*}԰H_��I�cv�?��Yo�)O�q�R��udr��1eQYQ�bEq�bMq�b!��W�X\\�@1�$\\1�0J� ;R�8��r�3r#��+�,�P,)����勢<��}��R��\n+�P,ϊR,-��<�O�ss#���s���(���A�F)Q�J\n�ˣzs�+��ޟ⣼->� [�Y����c�y��!L�e������\Z�.H7\Z�&�q��f6�Ȧ�]#C�DM����������W�t����i��PC7o�$ǘK����R�2���CԷgn��:2�����Mwe>9�ѕ�x��)&�<h>�@]���gѕ0&=����0��4��Q���iުi���6w�s�ɢJW�삑(Лz>\"萨��{���I�-��ާX?G�P�n��z�(I�M��[;$Z���&�qfS�C��\nG����۟���\\{ÝKyb�&Y�m���\'G�⢯9�|��>��\rΊ����p��ƹ�A�O���uW�{�`�t��/P�7MZ�P�3�>�Ee�I����^���3�a��z�b�Ӈ��iY&x�k-���j���>at�u��1k���h��3�lu��������pȩ՟-�y�q��&^ގ��7�ZjJn׿$��z���ifp���]����z�/	/I?�t��ƣY_\Z�\Z�D��t��� �Tѷ�=`��V��&Lr����Oϩ��a���d� !�[���6�D������⩜E����\'{���j<�����^���f@�\r;�O�E�L�����������n��ً_����<�Ѩ0`~�(4���d�@�����Ǯ�H��yn#�mo${w�q�J<�Xk\Z�(*�NL��8&�����ہ��x��h����~�/h,义�PW���h����J��苺�x�j��u��g�8�gn�ޗ�9�t�4ơAo�tFOѶ\'�v��C<5%�(?p\Z�y�p-����Y���E��(�L1u[;��`o��6�{���lO�c�GH��B��h��X��H!��B����_�])͑0����Q�g\'[\rB����c{��e`i�U����_�Gea�ž\nx�ʯ-�u�\\�OQ�-��a�6������n��D�2����-�C,������B!m`�q�\'�wc{���Չ���u��bK7-��K5�6)�m�R�l3]�7i��������U_���g�죹hA�#�!xBz[�n��\\�A(2�F�&����U�5��\'��;�4]�d�l�|���t\Zv�K�����}q|�N����[�l7=�z��L���=���g{��;�\n�ݲT��΅�X0�f���\rP���x�9��$��~3�c/7L���s>`xf��?S�� }뇉ΓP��1�&�Lr W0ez����\r�atNV�4{��k��v�ȓ-����6Tʄ݄m�I����X��;��+\\}�d�Z�j��W��-�{���O�ej��*�����t�:���R]�0Q�0dz�\\5L�u��U��\\���?�IT�6}����6�/�3����*K�:7����ׅ��&�E�C��3��ơ�h���5��\'v9����\\�\n�z��P�G�������?��\'(��\'��>� �c?�S����h����U�g��ޥV����ۆl:�Hh�5_�z��λ�@�*�=yj�|����:���|���kx�`�#�&Huً�χ_��87.�w�%	{�a��ht�ւ�>��OQi(��qd����*��v��mU\Zw�}�{��~>B�}������>����~ߓ�_��ŏ@��!�Q\ZY\n�u&�Q�|���������k:X;�\Z$iL�P}\n�� ?� �G��GcL�hݗ����$zS�SX�����{��X��9��*��(?ޱXk����Z���vO&;�F��ǜ�ɯ�l��@WM��P�7g�DM��K�{�Jҗ K�\'�K���x�/���>�9��}��ӣ�cGIF�l?��8��O�F�}B��@t%���_\\�����:���=�Fw�E�&�K���N��!Џ�v��>�B���\Z_��8��X��q����Or�T��2��w/ErI�������3H���	��\'���kd������Dw*��Ǡ�@Z\'\'��f��ŭJRD�k���m�o��:T��;�{�ia��Z�+J_��!1���>�\'�������2�j���c׎}��]`�u����C� ӽ���4�z�Q���<#Ks��.�+6+\Z}�n��Ҏ��ֶq�otx�p���\r$��?9����4&)��*��*�=��Я���1���.��\0�}�O�:!�e*H����r�I0�� j��_�k0�\'��x��O���)�ݷ}��c��	�.�u����\"y�Џ��/�M�h����>��t�ԛ}�Kk�ޏ�k\'߄\\76��Ҽ��t��Lߐ!Y3�˞�m����4��y�M&z	��N��q]v�أ1���4X[���.�s�6X~�^���\n�����~�O�J�!G_\n�t$��/\rS��2�k{����\\g�(Ns(��)�z���������y�)�~�y�c��~��w&vSy�B�r_��_�{��gb};���$�e��ɶ���&?���t{���\\�u���{�y��v�5���S$w���s����hL��9����f��:�~Y����U(Lq�O�n\r�����LK��?)���ݱ�2��f�*ɐ,�u��!�GI�:�)���n����<����`\Z��2Lf�c�B��\n�OA����\r3M�6���Z�l^ᶹ��=��c��\"��J��2�\'+Vκ�MX�o�l��:�@��*k/�#�C������Iݕ�L����ƃ�􅄿m�0Y�-��>��om�!��F��k�@�.������/HjU�e��!^���r}����0����hm_��韞��m���K�?�^{^-qlљ���U�V�s��S�t7\Z;���a^��q���=�����Q�Ԯu���烱`�:�� }��*?�0�l�I�I���=���%�l)Lw�������Z�;�܉��B��H�������H��S��i�t���z������<��R�sDsƻ���m�@��\\����*�V-0�a��k����`�t*�$�����L~0��	�~�5KG��5:kԞ����$c嗗0�3٥����ك��ڟ�G�K����6^V�<�y�����H�+r�<=i�j\rG������?�(�� K��|_���r������j>f��iz�x|;��>��C|_���s��iz\'��o�7������w�&>��[�M�dv�)N���`ݮ�����=nO�xx=hV�H�hf��Xb����O����Tsfzz̽��w���9O��u>ݹw�����:���Q�5�z2�>���i�~�o�ת4�:�[���vS��~9�H���0�_����YL���ڐ�z�׳�l�q]�a�����Nv��o�7e�,���C�a阓͘���z�\r�K�n�\\���S���U���J\n1�;��y�S̟��\0\'זN�~@��;u\0	SK[a�@O|;s{����!��sTJ�AS��`yYQ�4{��7\n%��\"�����������cj�=��y�t�����UL��ȶ�����d{�`���VZwjG}[o���a�\'G1�+�������G����r��;S�BJ���ӅI�ض@_��҇�/�S�������칾�<qP��;ϻ�p��%�\Z<��֟/5�z\0��&��������I�������?���l�6[N����[l��ڤ������x�ɇ���#;��.����{Կ���_��~�}ZAd��t������~mv;�L��j�*�KS��u6ŉ��lV��0��ܚG��̇}��9g������铖�)��~�Z�.h%Q�H�o�9��$��B��$��~+j��_�k��7�R�����n�E��q����9�&�:q���qW ӷ�V���B�\Zw]0����f���)^;n�fސ����������e5��.)�[�v��-�s�z�rOIl٫��41��N(p�����0��/?9s�l�κ!��P��4���O���s�>G�6�.�Hn����Q�����5�UI�����1?�!��&���j<���e���o&J�T7&gIf�=Í�I�g��׺F��R�K���R�����T�lv�%����?��G6E��5dJm�5nO�\'Y\\�|2o�\Z&�8����\\�����\0�։]U,M�x���vu�lE4����od3�rI�k���?9h^� �����w҂�?��ɐ���O�W��0r���O��7�?��U�f�>G����7����e��7�,��U�EcaJo���¯!1=����tU}5c��S�g���~5�)�1M��������]�@��҄�*?(�\\�|fӽv���&N�.�\n�~�w�{��V�Q�#��F��,,�>�?f�2�^��樂C8O�7�ͯ�2=�����G�gÒ���R���̺��۹�n���\r`z�lw��m3nN�	��:�m�s�� ]o/��e�z�^;Y	&�T��b7�mߤwʺy��� �e�v���ɦ�t=��7vX\0ڵ/H���@���\r\Z�Ĺ�?�����ӓB�푨0��·��\'������6樂Y!��\"��in?���?���S���n�����IX8Zc?b{B�����[L���A:a���f�����W�ݾ���]-���}�k���$��?�?0������V���o	1Mx�J��`�����\0�S(�sL����1g�kn�ko�Ix��\n��ɋ���\Z;!�y0�R��y����}���E���\'F^;�����\rhU����������� ���7���Cݎn�&���hvݙ���ߞ����kOٶw�\n�S��f�C0�����l��a�fж���A��tk�/��B~�o`B)�5.E��4�:��A~͘�E4��%��X�-������n���$��m��n������7c\\:!�q0�H�7i�����~�g>�	�vD�Y��[{ v;��*Mh���0>j[���������]�U�C��\n�nms����a�Ɋ�����\"��Q�T�B�х��(��������֑H�ObkɝT�XR�h���7�T���_b�T�<~~��9Mb�/����&��ʛ�oɑm�c�J۵��/��:��sQ��1������`�sTG���������v=��#N�P?���4���J��}���S&���GryJ_���_ʷ��!�y�uұ�s\0��q>\\���ݘ��)Kݓ�ʃ#��[�n�g��=�`���L�����3f�Hu���us��ן���ʼ����0�3�[����;0�ׁ��宍�sj��}&ak]!�&��ޯ���N(��\Z��U��eD�d��?A<�Lrt����(���/�_\'�m��P[?��p��������ע0��s��v�ߟI�c�Ȏ\\�p�����V���v�*�%��a��#әt�l-�d9�_$�����t��]�@�ƚB��P������W�������I�¢�?�gN�a��[�9uᾁ���	Y��QJ��@��\"�or�à�4�ુ*����>dd5�ų_|o}�� ��e/A���v\'{�t�I4Ȓ=��!���o�Z�+g݄t�]d$Y@6]�}�KF�X|�J`���;�����&/V�����T&��l7�������0�qη��>V�$	��t���0�+��{;i��U%�IQ.�8ߴ�^vBa��k4�}�g$�_���_��I��\"���B��A��+n���c��;��w���\"�s+v\0z�\'�%tV���D�*A���V��fwr[�N���_\'�?R�����{vU��߇E5�Y-w�t���q_J�r{}\'�؜ؙ�-c�hNm�uɆs�fԹ�e��O�^������1��F��8�\rR�N�$��H[��T1�݇��o��nX{��pK����7��\Z��hB�j=�ݾ��F#��b�}��o~�����������ek��y���>�>��wm���5��E�f�@�*���o�6Y��d���6��6\Z\nO�sа7��Zx����Co�|a��T{vG3����+t�\n���4F������ۋA9\r����\'�^�ļWo^�{���^KZ� ���2����J��a@�_�NY���O�}���o�z�s�V��\\W4�uB3�����O�1����W1�������{_H��e	�����肧�;`�l��`���W�����>�߁?@;�ra�\r�O���B^��h���}�?v�+��{�B�������[���i,�M�������*��F��m���������~�ܟ����3|�{���^-�,D�o�=c��)���z#	d�}���r��ܒ#މ�Zqfc����~6�Y��IB����z�}�����1K	�r����!�7i���B_�从n�����Q���awg��31��7�L~�k�6酗��l��Ü�cC���:9��\r�Y��F��Ϲ\'߳��}�q;=*��z0���5�ϧ\'zx�G	��z\r��a�K*�\"����a�nqQ�wm\rR��KU�G�X����+\r׸%�s>��朻	�������;:��-6��-型S���R��1�v�I����\\g���\Z������+\'�o&��B_Z>����*�^_C����ZP䪿M)�I���8��.a�6�76&������$i�ot��	��k`yq%l�n���09<�>�/�������[	��2������PyJp�޻0�Q��mX�\Zl��E�O/��e%�_P`uMy�����j	\'��0:�-,ί0J�td��;-�\Z�k�`r��]	���H�.+���Mca�d����0P�S�u0:����ήs���1N086�g����\nX�Z��k,¼�~I���m���.�h�����G=�>����5���C������,���6Ć����\"���e��{V0R�]cxv���pO��H!�.,���u�A��S��`��z�3u�y%�p���x�҈Gw]pS��74��F��z�����nv�����W_F�z�\n4�Ak�TD9��<^�{S��-���d���w�	}��0����X�(�[���O�y���ބ��,�j�,ˆ�E؜�^9)�q��^X�.Z;PV���94(<	s�F��zX�؂˛$��Xh�*���~	ׄ���6�.ӝ&���c�PM��G�_A��B�>������\'�.���)<n����uOm.m�\Zel1?���Æ��X��EA�oM4v�X�]5�����W�et�g�!�CY�!�?���X4�����n�o�<�,=*\0N�w�������{٤ۺ鮆Ƒ9r����Ė�a�g\\��u�2t~$���D]	�b�k�v_��6\Z�L߈��t�����59��_z�-�l�v��*tX{Gu�k��_!�Q�kSAa\Z4�����$Z[���X�wO@}u.��3��:O�kvp`��7���p׋�v�f�?��3���D��Z#QN���0�����RX��롷oV\\��Q��h]��z��V%����m��rmu���wv]�z�9E��ާ`tl&L�n�C_T�碾���뒬$X�Y��Aְ���Z��)8k������m�-��6?m�q}��\Zk��ǓC���nRqYY��յ�:����G���hs���u��̮������t��čݣa|~u�P���m%4�/Co�\\���d�ܼ8h�W�}x��5����^Yؓ���6�6������ϖ$�&��{�B=�\'O��D����_O�G\"��?[�E��m��j5�O��\'ͯ�̮nX.�\\�dHs��5��.���������(ʘ�����4���Q��Tm$E; \"������T��M���k	6�;a{]����?�����Kc�YE�x(t���1h�)�Ic��>�KÜ������I������ز��3��}�B��\"���o;���G}�1�1>:�OC��u�����<H���V�:����<�[�᤹���:\Zn~W���\n9�2�Q�9A��?�Nȵ�r������,��TDM�v����R�Y*So���MZ�\\nq`��h?cX_�Xe~m��ز��-Q�p��U�xN�+e�J9��p�;\0����\'���>[��\\_������������1�^�5ٕ̀�w��7���O�e�����b��V�-�\\��-S�\"��x�oπ��5D�\nিZ�h��^c6eD�}G�[3�xuϚ�|{;�Lnq�b�z��ڑ��c�oEf��:<1�Vo��-����]��I���ŭ}3j��(OzZS�k��o� �o3�Ie�B����zuF��Tk���7��9D��5m�G�3s�pe=Jғ`wc��,U~(0�+�O�2��G�-�����O��$���8��r��<̯,���Ȍ��ʼ4��-F��eE���j���뤩z,66����&��]r������p�Z���%��g��t���5��j	rՀť��>>w�΢���������7ו�i.yj�d�Ṱ��\ZN��Y�[FzǢS���OHJ\r|�z����M�˕�O�N�S/M�x�� z4&�C����sj�ϯ���>�����B�,(\r|����]��@%�Q`6\Zu��R�Ԗ�\Z�ZԴm�mon�\r��V�W�|�(���\\A\"�\'B�/��+���֒������Ɠ�m{�R�L��qc}�{�u����J����Q�f�6��Է�J}U����ٕ�Y�\Z{�N�id��o�}3�CB}�U��������ZjòV�[{�d�{_�:�=�.������k���C�V�Iu����-������&����(��学�K������I����J�{�Lc���Wd�z>��`������.�����<q��_��x��Q�̎/y}���ʢ,����@Lb�N�x��ζ}�v�q�` \n��Q�7M�?E�ö^n������{���!z�1.:��>2	%���zmRr�q���vB��j�#n�^�4@5>#�(�WO3��M3��L3�IG[h�w�<۳7I�Ļ&�^f��Cb���|�#���I���w���g�pFZ�Ñؼ����ub��%�pk��c�Q�qaV�q��*�����	ya��������xa����[�m\rcm4��t���������O�&�Zhb�}�o����	�FJi��̏�0����Ҽ��4pc|t�dz;�R_-��oۚ�)���\"�9���|��ӕA��hT��d��[������ ~����֣��c4��_����d�1��C�?eƲ�	N[�K߼u�;�~ �\nx�\ZuՁC9~gk���c煖8����P�?��!�hB���Α�ow�<���?>�\n���}C��?�]�Jz�c4��R�/�)�u05�]�u��ia���è��\'����ϟ������E�����c��Փ���!!|$������^�� �m�H<��A��(]ܺ�\\�%�X�)#[�9�H�%>]�*�X�3�P�3$W�:?_\\ (�3�wϬĚ�;�����׋�\'G�{{��;V����;9��;畉{<�wL��Nk[��GF�����]5w��/��X��M_\\`�)��.�,���(�e��)��y~U�Ÿ/ar���t�i����\\q��?{ׯ����k%����2���\'7G�R���^�x�T������iH�����ֳC�KCﻬ\rM\r\\\Z��:4�yB����t���)~���<V�\'���O\"8��OvYG�J���S��\'z����Q��w���roc�#�m��k*���V&n�LYW��Je�����e�)A[+9/�LZ^�췵2�eQe�@�2�eEe��7�����S��Wf;�z���3Q�Ӄ;�+�Υg���o;����G�0\Z�r��hd�{��|���i>wz剾���X�ziԸvF�_W�{�C�gwT��F�G/Թ�B�GO��r���q�M��D��(tG�G�G��p�*���@��\04x�D��7�=YxO*�WG�[w�x�%[�/\ZݻS9�Q���=P��M�}(�ʠ4uޝ��E�����/;[�][�7>���h��tE��TJ�Fg\Z�\'�Fs(R��	������E���[�z׏���9�%�s�?�G��՟�x���6��³6]�y�s?�<v���9;����ag��qMn<�ؙl\r�n~<�2�5��O��s۞��g�>��Z<������<�o/�?O�Ѿ�򽦲+h.ȶ���x�%�R�Q��\Z�\\�:ۨ�n���#�g� 3@���y�g���4;C����h�����as-]��f�ѽ%��/;s�}w�)�Ұ�7*�OS��I�7�_2��<��-�n�<g�~�����}��Ǌw[��>7>�ڱr�!�Z�ƣ�P��~,ZnҜo9?=:J�]�\"��#��7��<l\Z:s}����Ʊ��{�̩\'��z�\r���g���<���q�A/d;�B�c�Rx�@��=�oK�6GyJiȤ��^�u�\\W*��dQ|�}Od��\'q�P\\>�/�:�(���ϲbq|;���Ngq�;u��>A���\\I��P�3\r�cPO<�r��j�|����|L�;׋�Wq�*=�!�P��ǯO�_vB���MF2�c��/��=���G�AH���kc�~e2t#��h�_�4��ȸ4iW�\"M��_��ۣ�Av�#u��5��H\"��knI\"���i~��#���dhNe\r�2)�&�u��]���F����_�@K�7��H�s�k�B-�Q�1M�4߳��G\"�pr��-�#3�v����n�X�p3�g3r|e�҃?/�����do�\'��D<ו���KL�A��,��F��tT\Z�\Z�Y�3��\Z�9�5��\Z��Pg4��)��K�S|5�՛OC��J7uf3Pe4\r�TV��7�5$��t:Wk�V��l*cjͦ��dj�(��tTS>�٨2���_���kTP�J��Pj5�}��yҭQoR,V�$9o�����u���6���x������Y���?��BP����w\'��s ��=���z��l�Nȳ�J��2���%�pNId%����f$�u�LvMO�w}��\Z��\Z�B�$?��u���\\�)<&���K	�{�RKC��t�G�w]�S�~���H��Զ|ɬ���pJ�\Z �e�R�RBND�hN1�5uƽ{�����Q���q9~�^E�|^��yQ!l��Bשo��?C\r�e�����L�x�����b��\n\r�PmBy���1i�����ϡ��ZJ�$x���o�ko?M��_{D��쭬�O�w!{����N���&���;�::�������x{��푭r�2��#�/0���,���@�q�)��a�8ھ����&��7<��������p�כ�ZI0owպ�@��xTi�G����o%���D�Lx7�����]�x��\'{�6���<�j����^��l�G��V��(u�KI�jLD���1�f}Ľˢ~����e�E�G��Z�y_�K&���>�W�mk�n���y�Sa~�Z��Q`�d�ȡB[�H�W�M=m�������N��aV���8�.���9ݍ{ϝ�x��y�oK����(q����ֹ3��ݐ��r�G�\'��p�ơ����%c�\'Z�d}��u��1����C��bT�L�ε��x��w�N����Cqv*�T�y{,��H#Sk\"����o ��C�	���F�q(ҕ9o���M�?_~3���u���>���G�gwn��ů�<&Y_Ar�\r��;|�LY<���ۣ��� z�D�� �i�&�Ѩ%T�F������R\'S��}�nw��C���iq�^�/A����Lw{�˯ͱ�m�>�מ�Pb���r���ш�<�Źq.�_eY�B��lT\ZNA�Ք\'9&S�s�W�L�Y)�$󩨟����,�e(���h���vݏk��t�%�?tB��?�o\"��ے�ύ�M�Y��O������9Yn�JK܌��$� R���c�?[�\r��;�ѹƟ����^�xh��<f;\rG��,�h�B����l�r�~���6%d$��O�������l��ϳ��g[+G��Ti�E����ÚR͖�=xЮs�:1�w�������uk�W��xB2!ߵ2����H��r�Ϛ\nWm�1u�;���������@<_��1�p��o0��ƣVw�u\n���>t~׷Q:�a���2�m���2̤P�)�j��x�5�zcrr�UdbB�}>z>p��*��\"��LF��*�ƠY��M-H939��/�^gDL�<vn�$�ơR4���cI�[/�J�{ujkm�{���@�.�͂F푨��9J��ef�-U�N��w�;��4�\Z����QCz^��7�CN\r�-�u�:���c]9d�\n��_4�a�f\'v0�ߠ]�Ϡ&�N�Hf��\Zq��nK��J��+�6t��@:Ёt��@�z�?�[|�G\0\0\n�mkBT����\0W�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x�흍��8FSH\ZI!)$����FRHn��w��H�Y��x3��ꇤ�\0���s�a�a�a�axI�����Ǐ��\'U�{�������o��_����ھg�W9���������������o\'�GW\r{>~����J���l�����o߾�����������)*/���N�\\��ϱ�o��v�[iZ_ձa�JΝ�/:�����6�O�-���92b?�T�����l�k�%?������_2������1�B��s��Y��5�>�:�>\0�c=1������O�w��y�^�- �ڶ,��X��z\0����u��sM�#גU]�>H_���y�Y��v�!ۉ���_m�i�Ru��s�]�X�m�_g�)YY�)�m�]�y,���m� z�1��a�a�axE�ߓG�ק��o/�Y���\\�k�6��x����j��gH������������|�y��u��.�������\\���a�æ�M&�w����k�#�ϐ�$?�]�M�o��\\��Ⱦ,�/��ڥ���Q�@��~6s?)}��,� l�����gX #�v�Q���g���B�����ٙ^��u��の�uh��m?�}{]��.~�}�v_��J;�x�o�gJ���Y]�޳�@��.�)��oqC����?}�>@��X���ߘ�\'-�\0����(�W�?�����������������	�źv�Ɣ����O�ʙ�R������v�[K?[A}�?-�w����m�Ց�}<G�c�K���1}���u��x�LzަU��0�0�Pc[��<>�g\\=��c��}�M������ggg�����	�Ǆ����-B^��k_g?��F?���� ����v0||؎��=ǧH�P���g�s��/�hؑ�I\r�t��~�{����n^�}���Z���yD������5����X���Wv����O)�\"��c0��vY������Z��|~�_%/�,��p\\��ɹyΰ�Z�/���;/x����s��_��9?��P�ܯ5ݻ\\�[��y|�����č8������g\0����ʱL{�?�0�0�_�k3���>���������z�\Z���_������\\S��|<�)�b|�����7��a�a�axn.��t�a?l��^C��vk��ؽ#����~e���)��3<3^�����k�dl�c�&�jK+���o\"e��<.�ʞ`���^(3z�����u\n���l�+6���v��<���ï�\r�k7]�/l�c[`�O����n}���򚄫��G��뎱���zt��^v��2)?;Wm�r�5��o�c����Iz�?�����O��zx��{�&��!��e�z.����������\"ѯ����\r��1������Gg���{+ҏ���l�w<�=}Gݽ��Fƨ�^�)�����zIp�G�����K�\0�֜�{�{���e����G��12��ۭ��q���iumf��>�.����}�����~�a�?�0�0��[u���+�7�Svq�����֭�y΅�\n�?ނ��}���\ZX��w�Ŷ��v�?��ߩ��D�����Zۓ�-q/�?߳�=��<��~����#�������>���Fk���\"q��z�r��Q�o	9��r�,��n�Y[;��o�:)@�-`ק-�7��({��߯�S������@�µ����K��9���֠�ɸ�>:�n�3��\n_[�_*�mt�cm��C>�q��S���L���<�?�<n��ѯn!��>=���<�6�;��ǫ�s�����a�a�a�{�xˌ�\\�ފ���px�?0׋�#�5����z��я��c�]����x^��l�򼠕��(�f���:~����٣^l�i�n�5\Z9����W��~�\\;�?v�n������6e�r������UbS~v����^��UO7O(�|;+�S��G��4|?�f������*?�r���W~�2�o�N��ٟ���S�9��~d�a�����և���mH�6��m�X�[��J����~�s.��y����m�4ٶO���|B��d�����/������b5��ɿ�y����U�?�0�0�0�0�0�0�0�.�P�~�*��1@G\\⟿��K����rKX���s2�(ߥ�纎J���8���\'>�X@▼�Q��Q�\Zb���q��wx��b�)����_�K|���v� ��1��M�6ke�e-2Ǜ��5��9��?K^�E��~�9�ϱQﱮY��F�8��N?�~;:=J<������-�t\0�ĒyNA���g��C��	\\��N��X�K�s)\'�^K�g\\~��2}�6�}Գ����)��n]O��r�^���j�~�\"��{p���29w�6��/�.�z-v�:�+�����M{�W����JY��Z���굢`%��\r�Ҥl9����ힶ�կ�#O�Uz+��U�?;���s���d�~v��N���D��7*.Y�+v:�ye;��8�}�~���|���+ÑޅN�9����}�{Bƞ#t���x��խs�Xɿk��S�V��/��uJ=o�G���<�ջL\'����L��:�D]�6�j�f���gL��z�/�+ؽ[{����r��C�M�Y�q�~��[�{�y������y\Z	c�zA��������;��w���9��z�szW���H�����V�ax3�\0��� �%�\0\0\\imkBT����\0p�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}\\��?��������v��kwݍAH)�����ݍ�J#Hw	�H����3/�u����������a�=3s��}���a\0��[+n��i^t�E恼<w��;W��_��TM(�=����w����R��P�r|w@��fȏ?E1ǡ,�rR]������e�Z�N��@���? �������1N5w�|\nBԔ$���}P�j���(-�b�b�v�ౣ0�ڊ@��h��V�(��Š�^1x��U�Q�����\r��~+��B�.���wν��ߺ��пhVx������ce��s7�{.�f\Z<�\\\0�V���<��>�\\xn;z���K�E�������0^9��3�����\r��0h=z���A��B�K�l��U�.o��Y�R��TV�yQu�ߺ��i$��1>�{��Ҳj�P�$\nM>�1:lfA?b�e7z��n)��0�Z(����Pe,\0%xM��8<@=�m��Jͅ��j��vB�����칡�z>�h��f��Ue�kܲ��,��������	�N�(����:lso��4�A+��Q֟�� �0`���y��&��K��_b��� �s�O�R�YP�:\r��\'@��$�����������̃\nA�D��X�A�9/4؉���n� ��́[��.G��:�U�E�[Us�ԧ�^������Fl�91����>(��oA�^��{�k�)��]\0�m��.����{:��M���Q0�\nOÐ�G��x�	,0�/�wn�c#��u��P����BK�xh�ʜ�������j˥�؆�lx)>跚�6B����ro.�����B��\06e�Y$���Jǵ�g\'\nOhs��v!�;/4�B�]�*U�sQ��!^�w�Hx���X�\'q�e�>ܒ����G�{�۞���|�ˤA<�i����1��_%�y���2\Z�fB��,�pZ5��d+]�s<G;�e��������5��ϼu*]֡͝]h��\"�A����?_�<�	��y?b��`L��d�7�ԍ�H�8��<{�9x��X���Ĳ>���C�E3yg\0˟�Nx�:c��$,�`�2O�\'�s��a)4X-�N��o=v����U�_V���ˡ�l���w��m��G�m;͆����5� No�ĥ?���`8Sv;�X?n�}�1��߽x�y�i\"����{�x���FzF���\0���2��òn�>�3p���,r��C��(�]���ￕ���~�Y�l�޻����l����ŏv�j�?k�H�n\"������\rb�7HpNd�Θ!�Nt>����C�3�+�?��d��c]O�xN?��7�#�c����a��zBt\0^����y���񿑖�﫮/K��.+`�v\Z��#�V��ȐD=?Z��R8��c�Ap}�2�2����?�i�	Vd�`�tH����3ev������	�\Z�	]q�5�\r��؎�\'�#�w��f/������bk:�tJ7�� ��\'�|��o#��	յ����g�?@��\0�p���E\Z��(}M�;�9��v�&�����Ě���8&��wF�#>S�#t\n4�c�����u�E!s�J���=�S�@&�4tgNf���A��b���F����=�+uќ�_��q4;�?��S�L�B��,��;����=����H������/p�m�����c<����������݈}o3n�`�?���L�6���þ��(і�������W�T���W�\Zi�`%/<��v�yV��u9\nUIF\ZYQ��Z��ĝ��	������IЁ���e<����������\\�m�����b�=<�͇6[Q(s��������l\0㳧�w���x���B�_�2}�\'x�%�(J��O>e�0�Fe��P|R�w����Wh\';Ҭ��k\Z�T���Q�\"54�)B�ù���]0S7������|��M��gdD���v�<��B�5T�͆ΐ	�Q>�φ�v�=\'�w8S�7��Bm�xyE�azc�æ�J�����?c�,\"�h�2�/��\'�yW�t\Z�A�+�G���$�YȖ�c\"\Z}���g\r��-����Pm\'\nU���E�WC�����Ρ<LW(+��]u�+��R�m(���}cu���p��X{[㑢l��D�׍���oLbZaq��=�9A{�s�������ɦ�MK��\">Ǫ��k��rC�9�9����c��;$�L�����_�)rnGE���]M�ߺ��E#��t��}�v|+�_6S�ߙ���#O+]�A��RhuX\nu�?���Z�� �L_��NhsZ\0�6��.M>��M�ʮ����q�U4ӟj���%y\'�4�Lb��/�e���(���c�`\0X��,�,lS�XX��U>��߼�f,���?������z��I�P����L\Zi���Hb�EЏ��tY΂.{n趝C͹?�-�\ng1h�o���\'2�(χr�]Q�^�Ƌ�gޒ[Wח>��L��2����w���x��s9��\"!9�n����ܝO�q���Lsvq�}������}�Yɹ��\Z�j�j��J:W�l��X�\'��k�NQ�=xb�\0:�����hBP��r�Ők%���!HY�][=�1#)O�[��z\0c�hA���݂i:_Ҧ�Q��>�z���v��y��7�(iþ�G��[�L�7���}<Viic	)	�PT\\u���rѩ�y���l6M��27�������������{�^����C#��\\���k�|�=�AW�(��GCc0\'<������TLO�mHN��r;��?�����Y0����j����bÎ>�,��c����;�Y�=z�!��O^QA��;��`aI�r붣���ϼ��r��fQ����gj������q���\0�d���f���pC���ġuzg�(*6@��\"���c�L�v2�ޝ��˞��?�ع%nJm�]��ŵ�_�}j�*\n�v���L�h�f�:�J�~gcky駕?}<����~��-�׮^s��9���dwl�Y���=3�hX����ݱx_�����f�����q8\'�G?�E�PN|(�N��I����xf�������o���KM���SWTQlv�s�ѐS��l�/ͿAIIv��������xl����+9)9X�a�ݳe&AEŧ�ݗ���9!{�[��q��YTl�>��n#\0�h��SX�\'1�S��p�\\;�#<���b�p��G⽺�F��_��j�*�M�4���Y埖�T��U�1갱u0��n���RUS�}RD�%&�ʥk�\\U5�x���+�]SQW����[��dG�@��b趞-^B�:��� ���8��+�[\'�j�郾`����WP\",�ڑ��h����f�����򦟱��ڞw�q_�vA�V���Қ����j�l��PTR{Nءgg���n!Q	8--������q�o!}�~����o���9R�y�H�H�Ho���;�1-\0�w�:[*�B��\040��b�Ü����n\n�����	��M���e��/�{�r�������q\'��1���8��IC�����k��\'�n��X�wUV�BJV�O[��=����k�\\�/�̬��0��J�c�I�}����:�PBd��l�\0��?a��w���S\"r��#�&G��6��\"r����܇	X��eq���#=L���~,�D��F�:\n�\"r�\"r�.�����6����<R\'�9�0���\\��וcyearD��Ԉ����ʇ�a�ewJ��\"��i3��P��C�͐5ėC����x�Զ�d�{%��J\"M�D��yߖ���x��8�~=��(Gcgp��q�8��|�����<\"w���������|��M[/m^9{�8��O���	�d~������\'���ŅY&<��B���\n,ACc�U��Z]6B��\Zj��y=t;m����VC��&�tƭ�J�p\\����m%t9�o<�\n:p�ut���v,�r]\rΛ���Ѝ�;o����u+��i\r��u��崊����G,_-x�^�����G��5ً�3\Z?�9\nãvx����!��^�OW/f�sTx���k���\Z�]�?�T8.����f&�B�/t[`m�\Z��@���Țji��x.��~��B(3�\r�w��B�����e<Pi�\reV���\0Ϲ�xL��:+o.�R=<f�����\\�c.���Pn5�����C����A�	?��%3��T�l��\\(����K�����#�5����P�zR�qA�s���U߮*Y�_^3��0ô�4_ߒc����k�t���}XO~��YV\r��Ӄ/E�~].X�lP���^-��H�nM٪�ʒ��uM+���s��Jvj�ۊ�s��v����B��@+M\nȚu7>��	����q�x� ����;�q��c<�g��`vh�\Z?6���X6�:��k4p@u�x��O֣A�?;4��AE����c>��\r�J<����n�7T{�A����:��=	q`���L��1:�7h��<]�?�����-Ok?�u,�J3&~;�z�m,Ƭ�/���2zfj�H�-���%��M�=�w��8r��S/$Gє��Ȭ���O=[Ŏ*w�.��zWYj�bE�gu�=����F�m����\r�Ǆg�>�MN�ɹ�G}mT�XR�n��{�b!�����\r>�E1�0��i����ח���~zL%4?�:�ߵ3 b$��w>k�Ъ\Z���g�Y�W����M˻��h��Ŀ���\n�7�>�E����Vs>���\Z�y�4^D����y����@4s��k7�2ײ=���9dmY�F��I��zh}�V9�y-�s0��^���ه���O#�ĆSk ��؇b6�F�Ms.��pHG�ڒY�Er���!��w\ZR�ـ�/&kz��q��l����G�6Ke8�c�a���E���\'L��z�z\Z�����<��a�V��p����V��͕�,�X�d}nL�z�F�\r�֗~q!�Bۧ����0Y�(,�Ѱ��xxAtB4�J�p]��f�TZUp��~����b�KoO�X^����i;�\"Um����d{�j�/��Jk�͸O\'z�̋�WU=�qȞt�\09\Z�=m�#+�_�Va�ֵ+�c/�T���&�(�lZ�}�04ےgx�q�&kC�1r�ǵ�C��2��G0sedM;Y��;�Ν�Xw�O��o �^�3�\"�8� �U<�Y��C1ڳ�{�ul��ء\\],s��f;Ȗ�ϑu$�<ē$w2�nsʯ��%k������6����{�T��wy\\x����<V^$�Znq3�Ӿ\\xNzB��gpڋf��Em6�8�5;��\'��v��Mݨ������V�1���ț��hY������Fֽ�68i??L3^�����.7#m�����I愜f���\r4��#>fk�=RK~o�v�7vʣ���\nsͦI�?m}��m�J�9xe���7��/:O��G���_{/�u-tZσ^;Q��N�\0�zqc|4ބ1q��AZ�J�(O	VA�X�3r\"tıC_\'tEO��(vh�-�Q�١#vtFL�\'a�%b2�Ep�qvx��䜞hv茝�����OF��s�v2<=XGW��焎�;|��������0N��#��lÏ��P�Ui֟���V�+��\0�0F�F�+\Zc/w��!��b�.|CzyqCU��S���~4��y�*�u<�0�b���l��X]����n����e6j�z?��3�P<S���~�*���.��\\��h���z�<5�}���I����q�r{���H`�Uo��[z�\"��n������)[M5��܊&���\n��Q�����[ڡQ�	�^�l�\ZH�2�V��u�G�ѾG��\r�v�P�(��<��W\"�dޛ<k�2��S;����OK���Ԅ.H,\nؚ��Srq�z���%�;��L.�=����9��gsrQ����M�%a[���%�����+�4�PrQ������ũ�����q{���%��mO~�%�8��z�$�$�K.ߏ��M.�?�\\�3�A���|��4�@rq���� �6xgr�׺����?4�v}>^��^_K��s���Թ��7�qj猻��\\�ވ�P��K�sP��	.��\n;J_@ZC����9,,M�Qv\\���I�~�J��\"ݕ}Jy\'i6�m0����Z��3�U+,�){y�΁��Yep��셨�w|���F�a�$m�\\X�i;��B27�5`��zג�3߽��?i�lu��b������h�\\�f�9�R��۠�{0��e������oM�O}[�Z�3��MhǸ��M���ב��H({>�?�\n��)�Zj_�|�hNN�Һ�fNZ��zP.G�7p8��q8�<�p��� �*��)��`Gqx��sn�ǝ�z�p�|�� �í\r��\n8��8<��u���e�8ˁí��#�0�û�v�����.��\rQ鸏�8������n��YH���x�Q]���~�����iXb���њK�ΰJm��)�L�w��~���\\�5���t�}a�+�ۖⴋ�q8]\n���3��O��4\n/��,�Yd���0��/^o.�����A>���g\r��2��^��ױ4�4*	���?튄�����.j�k,Ԡ���~��������I;f�+u=�{�R��ܔ�)���km_ǲx�븢lxo;tc=>�?� �&�uv��o��鋠��q������$>^$�ێ��Ԥ���K�������>�h,�7��G�.jG��N�k���N��������@6�^����t��f\n�m\rp���L#�y.�(�vyO�EJ�tν7�p51ҍ��otj���0��\\�CVh���#�_�\\�_`��a�\Z���B��]k_؏^flGh��.E9Y���������t�����r8�o���7��o��T��r���q��GK�^9Py����I�A��𨻭Y;�m*�%5�,X��ME�%hr�=泡�N���/>�Z�F�?���\ZB��|��7�?\0��E��ޘ�x8�i���Y�y�M!<�p��6n���aBe��t����A+Է>�Q��-�7�u1��\nr�k[Թ�N��a3gYo�fwK8�_s>�&�Ɲ�+�.�����W¤C�������\n\\r�����]��~�w]�E32\n�(o�P���?�{�{���+)O릣~�#.Xs�6�ޟios�ࢻ��I~��i]^�������f9Q�|�𓃡�J����k����+s�\'?���~94�`�\\QC>���	�\"+��M��1��D�����g=\n2�O�e��MZ���U�t	*�;f�s^��nau!5t����\0���}����7\"���7߈tͬ��u���w\'F  ��bj�~�#����\'����oI�_���NI/���(����\Zeˤȅw~�~��$�.ZX]S��q\'zv_K���lȬJ�.�I�!���tg��I\0�s[\Z�\\��F���M��FI.��YԚi�l�3��$\n}s��_]xa j4��̵�dΤ/���a�~.�o��?����}	�X��f���ӻ^�>�C��j><�Y]����S1|G3����>RtML�����\'m�Lτ��3�k1�Z��@�Ɛ�(��Q�|IgGDAʉo����Ӧx~(�E�/}4hv^��O��=�����c$M��[�>�Cߖֻ�HB����̅.A�p��#��,�ށ���u��u4W|��C_��f�N�J�(<E��n)�^�$��ʙj���Y��[����PIn����A7]�l�җ�CX��I��د.��Q����\Za \\O��\ZȎ��*!�3_m6��\"c�V��{\Z��1�d���~�6�35N�P��?�k�=�nWrX��W響~�SS}󑒧���O��3-!8{BDS9��߿�d$�0ߌ�>�^_�?%$[��)kRMz���]J��}9_%3逿����5hB��oK�+\0U���E+�N\Z�6�5u�J�㼯�>�y��EW�<G[��F�ר�#�𥧵\ZJ�<��tcP~����f�A�-�Le7ٽV�mck�9��߻�x #9^u�;l��J������� 檜\'l��S����\\TD���і��_��H՟�h���m�_�߇~�zWY��o����C_�Hj��IKo]�柺}��x�໷����;�b�a�k?4�}���b����*{��\"�,�C�\0�#��˄G�:�������d�o���5F 9VxY�k�skO����u�z�\'��7�l�i�\'i୴񦈇o�����X�q�5X4���N��Z�������Q���@��b(\r��A#)�o0j佬�9�٬����bR٢r�\rx�`1��OR\n�҉�Z��H�l���\nc΁�d5���\0ɉq�b��b�����/�_)1��Df�#,�ޑ� 2N�&���隆4ݿ�<��������Ar�:�4Hr��o�Ѷ�;�|\0z���S�����JS}	�NF�%��\'>C�\0�?]�\n~n�Pc�}6��@�ĳ2�+7*��m�$�����\rY�L�V\r��x�*�\"\r�ǫ�>�k���9_���n(��CyW\0�I� ���[U�����a�4ǳ{l��?_���d-�\0�4�\Z�YD9���L�������w��J]��2�v,5���@r�\n�M�WQNs	Vri�Hm��Q��5ܾ�v��5��հߚ 1EX��u/�N�S���ɚ���Æ��x����{Y�\n���4=T�6l�م��Į��X)����$�(���bN���5���̀�l8,B]/��<0���{q�#nj�|���ٵv�����_��vA}}D��$�\"֧N�_b�\Z�OT\Z\\:E{�ܑ?�T�5�`�m�Ey&���.���u*��hX7㚲�Ű�ۘ9��[yP�\Z���`}خ�ț��`1�\nl�.p��v(�&PA�Aǹ�nΜ���\\��͚U���u��c�j�*��Wsi��8\"7�\r\'���\0;�5������J3�)��(�����pP&*RI�+\"����eϮ�����`�l5`C�ͩ��	Z�V�]\ZyX�I��l�����Ie���RF{���G���(9%u�b�+g���d6�~�3���� :����&���ʅ���B�I�	�u����;�xB���_j��HΏ���e�*���5�b�O�K;��7E=��B�\'1��=9�Y�����3_Y]��ޓ3�=�+�(�U)&�q�\r� \\jxoX>���a�B{oߪ�<��B#�Ɉ�x�IHh�Bh�6��Uw��]p��z6sk��h����C��A�\0�G���-�I�l������7��.\n{q�W�s��n�ve�R��r	��\\����6�n����^\0M��P�}ᣨw����u!�����Tj��B��~��&�C��L	D��������\r��\Z�~�q<�[KN�a�����D����)Z�gw[�	Y�ғ`�L]e\':eH�pb�R�TAh���}B&|1���u�ǁ\Z�ǡ|NT��h��Q�pd����o���#�nc��l�|C�G���T��\n�>�\0��M�]]~3W~���A~h��J�9З8�zgx_<kV�+7W���/�X�䀤)�L��7�q��T�UvJ�.���`�����_�u}:�$�@���ɴ�ĮJLTA������ٝÖB3\0޷j﵇�dL	�lX���:�g����MTMbXGs|v���ZxvH��ϟ���?ʨ��TU��;=��M�\"ݓ[/m�����SЗ$�O���Q��?�9���#�<9��z[E�־\"��PI�^���B����@(3��d�z��u*��7����=�wb��L{L��,�%���8���c���0��]|�������3:/1M�M����T���(= ����K���/�Bf�|��S�)��\"X��!|�v@��㕫/���_��/[��A������ ��1y��8�(�r��Ֆsҟ\r�-��f����{bOqK�fWf��$�?�Hb�\"���8�#�����Ёv;��B#M\0\Z<��Y��ǚU����2l��ĸ7�Xt�^��;�8�w������q�@��bȿ+�S˵������Yk�q>�{c�|��&��!:\Z�����}_$��x�.�T�C]��^eX��02�rhoT����kx�����qW7�u�Km�a���5�:z�S\'���M�W�]U��ۖ5���~�4��W\r�>A�w����UC�:��+��W����i:7��~��?�9(���S/4��@��Bx��O���%����a�O�8]�(\rV bD�9)[$�.�-6�B��~�竾�cD=E� l/�H�w��u/f�<�\"���q��3.c����Jl�<U��$9�s�gW���!׼e�e����L�2�,��Bc�=�w�(�.\'w��Q�OUg�s\n��KNT��������s\">�C٭v 0�\",�x�ҧ�l����ʯ�^`=�&𰝃%��X[b��2��}\'$M�F������1���C��|h��@������;�cX�b�\'{sX��ʺ]G���#�A��u�$����R;��x�*�L�#�+3}*��$FT(>\"i�Y�3l���\n�����e�~6��ɨ{�Q�OVs<����������KQ�E��r)R�%�vI�9A���K��{����bv��	,����E�M�.a��k����x����m|`�t}#���{ԯ��Gn��@�I&���Z|�rħb��ԙ�7^��]��4��??7�-x� �4[�B�/<�I���9����������oc��X)��2�n�D�t1���^���$����!6J�xu+I.�\0��i:3Lㆻ�\\�H-6/2@>?����AJ��Eݸ�K��쮿����ad��k�gb�?�1M���-cׄU߫�y�S��lnÚ�\n�x�\n\'b��0s3��[����\r�އ�B\n�Zj\n|,g񾄷��E�j�4�����+i���5H\\Iݓ�P�W�]�e�����Cɿ\nT;.�~���6P���q��s�}��+���B|�2���a�4s6J��%F�6�grۭ�֦Q1�D�����%�`!��J?��D��2ϏJ\Zn�H���ȹ;E�.A#�w/�8���*�?��;u����.�|�_��!yF!�ߢ�9c�+Pz��{���Eg�;4(���Q������8\\ط1R�6��k��\Z�}\'�m�\'���b-:^���H�(9Ex�*��\Z���=|�3�\r�y,@���L�I�B�����AL�=����ρ�\0Z�C�;�Q#�w�b��\0�?%忄��¢�w\'V�b�5�\\�$f>j�8�7kfj:�Xf|<��k�r��Q\'��FƏ]��=*�6M`�R��v�p���g��ņ��:Wr����eC�ϥ�xv�߲�錁�O��EZhr�̜��(��k�mVE��@�P��C��6_�v���ў#+o���A�M����F_b)��Y�_g�������ذH\r�8����D��>��wY(8:|ݔ��F��1��j_����0@�?ΚU���nʟ�Or�����2�}�^\n�,�c�t��}�ÿZ�p~`����ef����$�\Z3��2�d���ʰm��j��_^{\"算;y�P5i��8N���OSD������﨟\r;�R�eJ��|K�E��\"�/�o��<Qe(���ţ���қ[��k�s/Vӫ,���0��Zqfވ�9�~�K�y�����[��|�-�w��nq�Q�C��?\'�;��\n,��c����ա��O�������I�oF���xps���)�\'n�+l�u+\r�K�ҋ�8˦+4�4�f9�\'1����9�1�\"�OTx�m�2d��>�|�:+Jz�tۙ��\"ս����%�F����\0xQ?�X��>.�S�Q�Q������#��p�.�3C]���3ϩ>�g��6���\\@}>qNU[-���w��ֿ\r;�_���L�f�<3��zE�M��������GŮ��9���*�1 S\'1�T9f^��[M�a�cBW���\nu��?��C3�^�/7�2�E������u���O�9�;�(��&K�\ZD�\r�G��M�<��M�\Zav�\"+j����W�O\"�\0�*�:U�S��R?��/�ψ���ׁw$�cU�9:\"�c�a�\rƹ]�����m��yU���C�,�P����U��#�)�>�Z���Fcן\Z��]+�{�cRX�_�iW���}��0���E������Sq�(�ՒD�(��e�$�X$W(Ll�M�a�C�=/�}�&\Z�{sC?�?���0֬r?n�����t�g���+�+��엇�C��*L��1;mh���B�̜5�W\"7�ߎe\\*T�m1�y�4纉�៾�I�ݴ\0v�_C�)�!��A�#:^\ZVp��.�a�[�r|��i��HG�N���X	�3#$Xԇ�˒��%\rG�߄I��/ȮE�7Qy�IC>-b ����YW���;���\Z\ZҰmưl\n�9\r�\'\'j3s�dL	ϑ�\Z�K���I�\\D���@���Tmj>��Ca��Y���~���j-\r�����D3��<��6��?R��N{Jϐ~R��T��i{��R�]���>�j0�=�3��$yp�	R�~p��Ry-j�Td�t���ܡ�Y��~�����2T�E�C��^|���Ќ�d���`������%FJ��v��h�g�V��7J\Z���$7��rT�o	ʞ�8��K�m�z�[�ܷ�\n���\r��5��H��ۉ:h�e�r5Z�)�DMfγ���	�q2G$I�[�&�-A��A\Z��?���<υЇ��F\\��h����&�ć������/F�%�|�̍r�|/��R��1��^��@��X�\"�ǐ8AVO!~�\"s��S���R��B��G��WY�S5N:�Ѻa9w��)d\n��>���q\"�7�\0gP�H�)D^���y.1Vz�˰�9[&��Đ�I<(I��6���>�U���j��^㰿 7��1�� 8F$I>�ch��]~h��f�&�V)��~�{|�.���7��(�Q��]�,��ɜ#��?�\r�\'�ס��o���<��G�������7W�o����\r����x�s�>�!�Vd�9�����a+�	�������N;�9���t`�-�kcO^=��C����ȯDg��¿�o�B�ׅ1���s팩���̨���$�H|\nc��ir���H�)L�B��4�N���h�����i�g�\ZS�������ۢQ��]\naf�$��!؁Z#&N��)��cG�8�8��V#�)�G��Å�t���	�(�6���2W�p�T\r-�m~�W�5@\"yQY�\Z12�6Q��T���\0c.��	B�s���}R����\\����|�\\Mo�H�;QrK�ǡ~#��\Z\'�\Z�?��!\"w4L�X*H$6�R$>�hw�s�o��y��u����h� �}T�F�U?��B]2V\n���L�E������1���X��Έ��4��P|O���C9�]�]*���Ϲ�k�u��?\\C(C�7��wYd>�3]�t���o�lL���m\0|,\'A����]�T���V���K�\'��;� �~�]��f�HlZ�HzR��\0\n}V���q4���A���F�L��A���}�n��^s�?������b����_��������\'��Pt�M5(�O�[:U]��N�������?��A��\"I|2/8V������s?�_r���7���E��Z����~0�Um�ʧ �.$M��	��m���Fy�\'�p�$��/�d��R�\'�@��J;�I���bL�z����)�/�O��2/XC>����7q|��>)��>I��0�j�^����Q������$�u�Q��+@��0<��&[a��Y/��o4s�W�;7W��o��i��e��7Yjk����vUd<��M��.n�-|���)�w\Z�{�hi�GQ�\r�>����A�]��b\n�_�yh��X�oF��E�?����h�ތ��U��c�p_إ;F),�g���OI5�4�\nB��Ql?��bia��/��T�3\\f��u#�U}��?�*]\Z��3�r`�d�?%HrlH~2��XOlb�\'�~��6�Z��ŚU��������7��\\�bպK��%�P��/b4�5-�N{�y�~.�ӬR�CP��T3iE���MȀja���z��:��N~�˻����n�mH�JV�P��3�ª�:�j�X���B}�j���Uӵ׮Y|���?�J�p����/��:��o�|		�|\n&�a���ү�n�^��s���,o���?Z�M��͋�V\\��_���B_�<�n)\0>��82��g�����:e��������h2;��/7>f��Ź��+�B��w�_r֏�;��~�\'Ow�}����M\0�75�<��O��xi�Ƕe��=���!��1�n91������mv\\�W��G���s���J5/�	dw:���c7���c�)�Gy�vK�p\n�Ի��u;��k?��憿a<��K?w%�����j%���h�Y�o[�_��������Oi���D���g_��y�9u�yi�_s��x��b��Hy����\r�g]V&��U���m�HB�bʦ����M���[!?�S�u�uv���.�-����`0�����h֬�\0n.�/_���&([�����Q��Z�[��ψ��5�A��Bxl)\r|З4�z��S��s��:��_��p�W�XF\r����og��)Dg|>��\Z�h�k�$��n�̽�i{ȹl�/=3f��߻��ߨ������>=�m�����E��\0ut~��B��b(�ᆮ0V�[X����a��#T���oE2%���ٿ��?~�W��_�����s9�I,Z��BȻ�����\r��x�����g�\Z�K�t|��u��\r/\'z��H���]���3lnH�z�Qz?��Üx�8湗�*c��|7>����9�>a���b\n2��U�J�e�s?�����e�ڟ��ly��[��b��8�${	eUF~<�.�I+�,+(�<+.���oXa�_XYF�Vf��ڌ�~хYaa��Q���ksS��T��go�z�/�\Z����S:4ۈ���}�C�?cF�V8�d�^4�p�@\'�F��Yq����{������{��SR�]���i��\n���^���pG��%]��;2���;ʈ_����g)���(%hהּ,�E� x�^�ky���eW��������>0;�.5�2)?S��墴	|����Tyk���M�Y��S���d���~w�S�wH�A~3)׋�1z��\0�j����T����5���­.��՝�ze�p_=n<W#/7�.�.��Bn)x�8�s����u�(c����pV�Zx�9>�8\\�	.Z{�m.�)������*�+�]�������i��U6�:(�+i)���������ux`��&������m��3�\n�U[�u�cp�WwuD�K�|>ֳ�\"�[}-/���!���@��x��G~��<�����F�W��X�V��ߑ��АN��{�Rg3�ӕoe��\">]���ܮ���jp���2-���z���z�tv���%p��\r��fz:����K��1�^;\n�W7A��K�kx�f[e��[Y\Z������ky��ւ�殰[1&��\\��\\H0gs��[���(8�\0���ߏ���2U��6>�:��x����������W����	�v�@�ؕN�Y{����;1�6����ciF4M���h��x?8�o����p�gݭ�e�n�j�o��ة������p{5�g\0Mc-���c�9���߽*�6:k�\ryQ�W��dop�=�$�\\J�aD�Q���u������M���`��^�ܠͱ�F�vmت�Ѯ��\"�����+��!4�\Z½��#{aj�_M�|gBg����_n�|�G���o�+yp3;��A����_<�:7�\r<-�C�����p�������_���4eȼt���j���S����UYW[�|��_�M��PVt�t�e����V޹��\ri�z����V�C�����3SϽ,lk�/rV߁r��ˋ�Az8XKI���P�v;�����s���(���\nN�{���Z*�[�tk�[ȹr�j�>�[�|�~����77��*?�/M\n�_km)_X�>����B�����p��	\\tv����!�뢽cC���g����F���fH��>���,ث�5��I�M?{�Ma\r�i<�p��) -�et�oS��>���w��f�������]����N�h�1����#뾘�<E��]![Y��s�g*B��xY��/���|d�BuT��!����z�6�=����1�\0�<h\n=)>W���D����/R�-{b��hZ�,����z4��A6r��S��xgr��G�!+5�<\rN���B�g���<��~\'�ϕ���*ۡ��ק��Қ� {irl���Q�x&.ĉ�ʲ����YG}�۫޷��=m�9��՝%-��{���oi�J��J?Br����w���]k0���(mP?���NA\\���F�Lr�`�l]}�������=�/8j�XwUx��%���^w�KF2�|�5CC���6:�o��^֗.u�Vt#G;��n��>ڇz_댆�[���C�����=N8������~W��*n�$���Ut��<��y���Pڒ��\n�k~ª� �\',��0?�ye�x<���I�����N(�w��S�Eq�ʍ�-��5���r�,���Μ@k��m�z��8s��J�����n��g�G� �����4w������O\0��>��t���n��`9ڨ���䷡��\nM�U�\\�4���A�j��A��9�ہW���ע��rm�+�e�������^� Ε�\0����eCS�On�;ة��{q����~��~�=�g��K��	�7�Cu�}�K9��W��ش��u�����~\'��^D�]��W5`(nq~�D0�9^ZކG�a��!MyU|�/-0-�y���Nv�_=d��m3��:�▷�P�����x��s���S����6�\\\06�P���(���=�}���c\\��q{������n�������������	�ev�3��j*���Ѷ��������q��[WݟNx\Z��|�W��8�r7����#�wC���pF�x��j*2�J~�]gC�;)�z�\r3�vJ�a~��?��~��8\'�����s�Rsؠ���Z偭��*�ݙd�!vJ�b����!�:��B|(�$5��o�9�xm����A6J�c~J����.ϛ?�5��)�_�z	�����k�Z����s)��o��I;��6llw�����>�~5��w7�������D��Q~�;TVQ߄��T��ۑ�P�����M�3��4)^�!����A��p/�r�o�y❟�I��ԟ�7H<jz?��든�at��A����.�����7�_#��A,o+�VN�s��sr57�|o���q�@HYRHfl�	�ʯ}�P8�s�D!M}%8��?������U��\r�MA^2��l�W�z@�4�ZV��:�_�͐]�җ�5�\0�ծ\rmf��Qk7T<L�������Pj��}C���[AV��ѧ��T�dBUI����5��Hψ]�{S��RgڏP�\01\'��-�m�Yv�f�j��������l�(����B|�`k9Ӭ`�.w�����a��u�TMI����C����{3�S���y�<UP��\nk^F:^�L�mz���N���Pt7:\Z���\0�ͭ�4��K��qH��p�����x��k��y��0:Zhu~k}����N���t�@��4e@c]!�9��{Y^<�P�������z��:䥴���ٙ��f�z�|����H��������i��n�[	@���a���|G�2t����������Pt��&�u����0��P���Y�Q��x럤l���#ΐ�@k�6;\0>&G��XJ����.���g)���Qw`=x�׵Cn��������x�y&\'���1�3<�>�)�`�����6�੷}�����(\'p3>�m��NW_��?|�F�߆>��\'>6r���pW8>f\'�����FY�9S]_��eD�|�����	�j�_>��r�y<�TŸ\Z.��\"��΂��!p�vܮ���gv�ʽ$�Kّ�Bld��\n�+c���0��8�^e���w^&>�}t�Al�Q�68Ft(���\r�VR�.��-*ya�cM��ϻ���~�I�����d�v����p?���w>��\'�C/#��3�~~�t/�Ş�v�T�~B��{��B��8ԇsP�j�e���;��;?t��߉��j@5�<�!\'��:7��&�6�&7�a�w/�:7��67��:/��:/9�:#&�:;��:/�N�\r�7�I���[���^J���s|l���sc���(ݳ+7\'�[�&y[gc\0�X|˺<���~���*٦辧uN��uV�\r��\"���\"�\0��g�������1�9)��/</���j�S�@�GVg�f��&�X�%���&��̠�����N�Q��#\'�f���#YԻ��\Z�cs#�9���r��lNFK�qn\\-\'��!;�Y� ;y�8�P6U�a����&9�!�i���rr�������j�̻`N��܄P���t���UN����U�+�ݳ�M±v�ιa��kC�N֪+��,M4K����r��Kv�͍��M�1.�	�����ϳ�P���ӷ����Ŷ>���d�E~}�{Q��\0��Ԇr{���{���7Qeq���\"\n}��Ł�鋠\'n$5D��o��Ǐ}_��Hf�=���g�WS�\0jW@���/�\n?��O�WC��|B���cG����s����[�������~%!r�B�=V���N\0��gS�\0 ���`ꁷ1�8�D�>�]��k���������A=c9�@����Ơ)�*���/��.���Q�>�����:��JK.�0˂l�ެbY2�@�$��%F�fÆr2�Y6�g7�f!��muɒeY�E.�QI�ջ�fF��i��hTG��P����?���.�$YМ���?�{����{���.C[�����˵-��+_�F\'��q�0�싱x_L%��f�?FKV�>�O���>G��64�>1l5�[b?l�����C�K��zI�N#i3�I�z�Jz��٦�tt)%��:$��vIיI��M�b$�S!Q(]�����Ւ*�ԫ$���EO0)%�n��@�Mf��A�!9�k�(�J�Ҩ��i�E�J�@��\rg%������ʗ��Ó���[N�j)�|n\\��\nh�+��*Нz\'�o�D�?�1�0f�6��E[��E[��N�@\Z}�u�+��I[�0��DO���#z*�`��[���x���>��������Տ���	���\\�(z*���b�+(��1�6�ێ��Ga�x��\\�,���_����\r�:���i�����[+��>EaZ�[�c�(m����Y���W\n���)����L�CD��N�0�{`$�se|\'�h���ϳ��1�b�(/\Z��v��?,#�q��`�뼗@c��K;��x��q����i�%�+b�0%�\\��1!c���\\4y�m�Q�\\�����9�:�L����sǩ~[��][�����n����7q�4��F��P�&b,��I���X��8�}V*�7�?�g��,\'`���i~`��.\'�P�!ٞ�)9�k	��<g�1�up9_犝a��t��-�5�c�h�r��#�U�y�y\\��r�m���g�>�����zG�\Z����ˎ�-z�_��:�8�y�M��7`:���D���`N�9���WaV���1�v�L�+��] ��Ҽ@�\"���\n���)<_Hq�>�~�?G��O�q3�b�<�geb�9\n��u�}^�PL�*�x�s��L�\n��s���eh�̕�\n���\r��t��g�\']�l%�D�����F�1CQ愈�5W(/^X�껬���t�<�?����}���-�������KϤEִ��%�C���X�K�q^�I�=6��B�兞���d��v���B��m�nhϤx\n+�����Zt��E3�wP����\'?���7h(�*��I�\\O��3��Ey�)_�ZӨ�*K��Q9E�Z�~�Ud���47�UP݊��O�셦wtfގ�����o�Jٮ����»[��5Ow�^��*5��W���f�c�J�q�J�\\e�)�6�?��_9f>�=B��+�%�K݌���]���`.�vL�8녾/L��	�^\"������߶��1�;/�R�����o���]/����[>�r4��l���hOبΞ1�B��Oy~K��,��B�����P�C��\'׾����x���io�夗���ٶ<�ߘ�	�r��f���zmm�WR���{�K2����C�u�2U�ߍu�؁��|\n�ǶCsx;S�v�(l>J�#�\'���s�Oi���a�x�KiF�v�)l�4��o!菊a+��gS>��Let��Oq����r��M�����e���K��rv�����L���H�l*�f��)m����Ѣ��-7�J\"��r�j�o�E����-��7�tT����\ZVȀ��|+�ʦx��Տ�IeQ5�Q���Q\r�Vyԙzr�_.�jTȣj�ȟO�䯮����(���y�yT����T���TSz;�)���i蠴Ӕ��\Z���f�Ci��ZJ���&\n�6RB�W����G������-e�����]p���a�\"\Z@�B����\"w����c�W�󮁭�&�o�`�\Z������,v,�����~�yÑ\'��q�Hl��`?r=.��#ξ�|M2yJ\\\'�X�������w{�/�~�%\\Hi�O���f��zc8z=̩!���\"�LxM:[I�w�	�\"���ČsLz��X��b��.��p��x֌0�;�)�0��\0}���VcBv5��z�S���˨��^�(�>/e��1��;ݮ�wZ�e���O�]�t��:���=�6H&ZCV\0��aN�#^����hO��C����IQ���ˡ����\r�Gtw���^�p�ayC��.�}��������Dl �|�E F�B`K�`�zt�]h�B��O��*A�8��>���7�O>��.�����%��X�wq٦�y�Z|�);\n�6�J|�xR���c8.\0ɡpD�\'%���qN~�`y�D�)��d����qTY�>��/=#��+l{�qSCrZ����,�\Z;������4�5z�ތ{1�{lz�a<O��wʐXn��`��7��J�>�R����Y��Z��e}��#,|英a��߸`�&��{rޘ����>��GdZ0�낞b��;z�N�$7�f�:L|�m�.����x�L�uGr:�<0�+�\rJE92�.�׍y�`*\roԟ��NGK�b�����a��2k�ۋ�?�t�r�5���D�K��H�b*�*QV�����g�y>7�z�ò�z���}�����5y���$��/�G�	�yඡ��?R�<�^�s��Խ�+u_���&`���Kc<,�7c.��	��a���c�	z&,#`ـ�X�{�����p�\n���7�mߣ,1���7�������3�]z�˜�ګL����/��\"0��3Ů����{n� \"�����mt�ߏ�=h��\rÁ`e�	Y�e��\0���zIr�_�����4,[[����L���ϴ��{�%�nk�������6po�2#���h����;��z��C]�A�m�M�o�t��o�����7۪w���Ø�v�X\\z����zJo�9��`7���rߏ;��F	3��D��\'\\0r��7`��C�4Hg*~�N����,��1�~����c����%�R?��Ɨ��w����\'���DUo��CZiL��\"���J�S/�H�<g�]���&⭮�\"��_�����n�C����5�*\\&���y���\\�����nSRq|g�x�1���k����\r-Ew�cfs�=ժ\"�&��MMgri��F5U/7u�?��y��:u�g���A��w��$ùk0Rp3F򯅃ey�x�}��b�,��������K��5�@�V����{j$&��0�SZ8�0�s\r�������:��4�/�%r�.┓g<�܋���:	�;8�a�h%��հ\\K��:�߈��1,�s�+)�+���d�8�X1����5�\\��c�{\Z<��g�H���z?)^��?^���d�O�Ĕy/F?��p�ϥ	�\r)����Do�u�g�C�&J�2d�iL.�;���gl��+��ӈ�bܬ���#�E:�~�yeg^��wͼ���i�>���	q.�;%�-Xf�����Ջ݆�t����i̞1濄სp���d�/�?�6>�l�O�8�yA�����\"-f\Z�߯p��ǃT��?�b�hAW�i˧����ĳ��ǂ<�H#��5��c^�NP����B�K�͸��=�I�k���ۂ���\r��ϛ�7a,1�1M�5�N�S�6�ڬ[�_!�\"/�}�r$�{,�qaȝ�~�x&���9�8wi����p����������/�8�ܤ��l5فФ��\'>�IA��n�6���<�`�A�/���8닱�\0�Q{��q�/���`9�=R����B��nX(�l����R�ؗ�-OT�gZ���s1���N9��x>�k��WZ���9�j3<�I��.)����`4�	���^�F��M���~�غ{�%��@Ņb&�ShwG\\ �`���}x�����q7؉���-ǼlF����|#a��[���@<� �1�pe;}������䬁��m8��c�&tҸ��}w�b�i�o,��ս�I\r^��6�o���jW[�/�Ϟ��%�>���К�W�<�>�`(>=	D���f�F��\r�!-�tO�f��!c4䚎�\0K���]s�-��t�2�V���q6�����]��\'lBl f��h.\n�x\\\0��}0�������5F�CY�5[���+�\\�����V����aKی��0�$`2���/�Ҹ����p\"ъ�`Xb�F�gǞ`��Y%���A$4�����z4��U�&X�n��=���~GL(&���ϩ�XOZ��c�#wب�u�F���=�������]]����%���ߓ����4�OZ\r����pd3рH�G}N��T�?�	O\Z�M��}��K��b�zL�xav�/&S�p���d�\'�=0�L�$&�^���B_�7��f�C�����R/��[��b��~���ma5���.{,]u���}�~�gH�����K	�pR���`��{x����H�@���� �)�Hj�%s�FX36Cu�	��t�!�t�~Sm�G���n��b���+�«Wk\r��КZfi����.z�S;�u�!��u�=�:����9�0��AS�Z*�h�)�zM]���L���+�a�k��X�����w�\"kV\"\0\0�mkBT����\0w�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��y|[Օ��8!e%N���N\'@��.Ô�	�&4t�|hg�-���i�t��Ҳ$�&�Jǉ-/��}����Y�,Y�mY��ɲ�-�ߜ�\'��g��fF	�|?�����w��I@��p�NY����.vu��|h*c�!sZ����C���C��T�A\"��R��_�vn̩}���ʹ�<�S��� XS`I���D\0�*7`AF��\\�+U\"�K��Z��k�\\{�v� 	���셅�PSw�Pz;VKE���m�\"�Io.�+z���ʹ��uZ�價���Qo��1���r/�jEX�a�t`�T��-	|a�-���˹���gO�-1\0��0҃a�m��d�H:�$��z�I[������~��k�G�:~��[\r]�^X��=}�3�a)�W�`~�<�rN����u�����zθ���s툪���*���?X1�\ZU�}X����|�2�|P�t`KeO�W�9Q�����\\;�h�y��X8�����ѳ[q��n\'�;h.����bL���Rޞ�S�7����9!�����?�lz f�aK	��X0fd�Dr���JW�x�ֆ:I�ES�O���z@~靽-U?��-b��M<��O������B�\"�7����h�X9\\/������u�a:�4���M���R� V\Z�L_\'6P?��I<�o*\Zˠo���}�6�^�U5����Z�(��Z�}�:񈾍��;��(��t\\_���&vu�o�u�G^>�U�6��\0��kr0�	���\r�\n��K${6\\es���J�9҃1�v�U�C+����i�������cct\r����&\Z���� ���c��Yg�o���0^�4�m�kzƆoC������Ib?��h��4<���ǡk�6F��0�r�ε�6\Z��[�R?�74<A��&?3K��M�=�s�:����z����W�̺SdS�1yt�\'}0]⁥:���\n��˥��2��j��_4C��b���H�f��h��sT>C�s�/aq�+vjc\'}�+�z�Hm�%ӄM\"�٘v\Z�Jǳ��\\�p��Pjc�4�,����ں�,J����y�i|S�Ȭ�����j�����Ȯ.��AQ�ZFa&%�	AM�UAfo�*�Y���m2�?$�,������Rҕ�zJ+r�ʖ��*[K��ږ��˄c6���k��u�ڻ�%j�Fc-3ݠ~W�yi>Z�ڰ�>�/;^�r6w��|E�5v�Εl�(+���t�۟��HtӅ����WaJމ���uk|\0l�aХDA�����(�D�\'���{�F�\n�\\�A��\n��2ʗQJ��TF�K,O헨�r�Pf��)����Q!���Q�\n��VO�M53�T.ԯ����!}Y�c礔l\0;^��q��h�${v�\\�\Z��4v���{�&���c��+��cZw��Z�����m=C=��C���O�/����[�M����0���Ā��$?��|`N��!=�P���`��E�6(�yA~b�ӷ�R�z򨜎{3�0��\rY�p���\\N�%S�ڲ��^PP��L\"���8i^���!j�{���{��8��B}i�Kԯ7uT4~?���݆�ǽ�i/�ݛC�x�t?t�xc0�>,�݄%�|c#=p�n7\rU|�[9�򭁉���&9��k���2���֯\Z��_�w�Fշ�C���bUߟՙ�����f���ˊ�13���a~�n,%����D?�%���_�����-o�BOy�?L&P���0C�oS��`�rS�/o�a�-?LP^�.�G�D}�H�f�}a�1�	B���\'S>�����ٹh=�gcP�H�O�S�R�Q�0��O�&=��9?��R�ϰ�yC≱���K�b�ښ�����o 6_�s7���y�b[����Wg�>����C��M��9\0��P��Pѱ�4�OQ�ґ��/�<��@��Y[���0�NMuj����±��\rP;\ZCG}T�Q����(��Q�����{Rh���\n���h�a.-��\0hȖ���r�v�kV\nk\Z�W�Tzb�*Z���n\Z*y�c����ᮟwi�_}u�)��2p7%�g\ns^�l2�>yQ��x[�$�e�\"��Z\Zw�\\\Z��-���N)��K�:z�q���/�r�7�ұ�ʛ����K�q�2i\\S�i)�i���S]�s~��j�=�u�ح�\rձs�R]+�u�qk�!ڨ�����:�Km�y�������%�%�P煑\r _�\\X��(���C{��.��S՝0W܉�ʭ+~c����Ay�u\\��>�4�1^�N��{A0��Wٚ���.��&Y��	L��|A�,�Mc��^8��Ӡ9��DX�áˊ���n��l[�:\Z�2לP%��l���tb���\r��}/�ON��X�w��!�!,��|f(�;1�\0Ù-�J6c�֒$w��Z�]����T؃)�O�9�u�� ��y��?��sY�X<Bk���P�@y��� �e���	DO��$��>��uN�kb��S���G��,fd�����y���Q���!�G�`*i7����K�|R(f�\"aJ��db8S�i�\Z��`�\r79��?��������s�lR�z|�������0,��?�Y�pѾmA&O섁�������%)�Q���13�\'��*�	�fe2ӃE�L����k�U@�x������J<�=�~���k�z��;�C;�Au��w;�{���\\1�0\'���K��ˮ=$�o���M��eW���^W�+�y�����䰽>�6�>�n�W�����\'���	u�?�˄8(�T�Gf>\"��%\"��/�|�B[1�7����������!1֣�O��@�J�}��\Za��\\�֍��۠����~��\\�����f1(1�������2��[~\n]J������М���&a���`%���y��	7m�l�b������۷���fȼ���><��{���~Eޒs���଱Z��\Zow?��=*������R<�2��9��3�:�L�����^ާ��\\�C�n�hEК�������w\\�y=\\N���������t�Y�}Y�*�u]i&J7�^偅R����B�1X�F����w|h����h$��X�&d�-�4�V\nqI+R�_���d�l��l\'�}��i��O��پGΤ�g��m�ۯ��M���ʗ4�E����hhx��LJ��|�����rN�>w?��W/5���S�b!��I�Mz\0�3�,����\'�d?�k�!�,^��ϊ0]$�D���ީ)Si��oS�^�(��kj�|Ѭ����쵄���ph~������=ݧL�m~~JYmy�%w;c���J�+.�R�I6gѵ��yވ�64ZI���I�~�9샩����`��\n[�g��R���r�;�u����M��X�S�-�C�\r���TEa��I��ros�wgoў���w*J�:5�?�j�c���6y�︦�a蚟��,����.��e�`��Q�\n�ƾk����~v~&i����+y�KY,*y�ݰ&a1)\0�����	�t����=�Ｃ\\�Ieߏ�˄�D&�hs��k�oюb!&��s���D2�s�-��b�쳰��K��X��Dm=�H}��b���8\\�&]�	1���E����Hֆ����*.����utj�S>��1�?,I�V�ՙ���h�N��b�`�q�!���f��ܙܘ�`ߙYl��ű�ܬ�F�\ne�o��Y%�q�g1�,ƙ�C�{�|&oG�0�KY�4�����}�gžo[�������B�x����)�!,9Q�;\Z���@̿	e�\n|�;Kz@����]��F���F����{\n�ł���3&+�Ud���˵���\n��d2v�GW\n:0��/�K�l-j�>W���\n�n �q��@�����ߧ��7�����<���ރ��XN��L�?	@��\0��}�̿�|���X�A�l��>��S��w�N�M�X�;�u��7�%�-`�g��l޷�b��`��U�+έ��g�@]\nEV4�ɑXLs�s���J��}q�3b0����@̦�`���6e/4�!����m0��^�+�º��jK�5��so�R�%{��\r�oZ�/�~�ڰ�6��`6��&��=�d�&�]�fhr}0H��*m7Li��N�LJ �)��~^�F��Z�[N~C�}8vݐ���(�|��}.)Ia��?e�.g���?�R�3�uO,K6`���\n��\n�V���j�띯����Rj�	�����/܊�����`h��`��n��p�p��B��L�H����\"���>�����_�t���/��ڜ>��͌�5c�S�R|�>Db*9���GB�rd.$FA}<\n�پ���u�v((՞����Bu�6���P�7���A�?.�a0>mG#�J��=O�=-��P�\'�`1>\0S�!Oڱ0rb�B#y$��1w?��bۻ_����(s�\0��X�v`:5��X$�Az�H�%�lEj�	���s�H����/9\ZʷwC��[��8��	{�?����:3��(X�#H�4f�/�G�1��7L��pl�R���܎��RM�s\"��-3�~�����o�\'����T,ـ��\'��[B0�/���X�$_2W3�a���h ��p���B�/V�}`K\'[���D?,&�a,��s��:���}�]�ϻ�������ްGK�/�H���?���ؙ������p�e�C6;��\'�h���;\ZY;�vÜ\Z3��Ί^ץ�!7�g��*j���_����5�]È,tdn������l�&~�Y����绳��=IP6�\'��F_�A�~ݧ���^�ځ��8�(�J�C!{]��\\R��vH���7zz�ίuo:�E���8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���p8���������fN\0\04=mkBT����\0~�\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��]\\U��#vDE_��`�j�1�Eb7�.�Tl(���{��ri�.��қ��{�bG�=��/ɗB�x�����9{�ݝ�ٙ�=�\\\0��p�p���(%x�\\�\\�9p�z]8��J��+���O6s!�v}8����sh�yY�$��<�e\\S�h׉�� ��D��J\0�@��HY�)��T�I�u��?@��yPj-]FK��t!t.xS��eJy�ż�ѯ3�����{\"d;.�\n{1xj�\0����N2�(@v�8`�����H�><��ސ1��8J���X����a:ʘG�ֆ�v=9����I�4��\"��y 43�C��ԙHA��2�6�u^�W2i�v]9�����(�����k\07�΅R{ahB���`.�;~eY}K쿠��G�� �_���F>C��}��>�����0��a�����Ts��ѯ7��mS�7����Q(P� /�Y������2��Pe$���L��$Nub��ם����҈�P�z�@��k�{�O��E��frA��<����s��B\"�I���l�����h��<& N�&1��#�B\rK��� �A?P�E�F~�R��h%=F�^V?X\\�$Tk�p>���������_�8������h������<i> <0@����5���X����u^s���<��I<>�zq|��҄��#6ُo(�\'ZN�/�]�1,�iH��N�\r1R���e�(O���A��R�2Y��\"�l*�֋��R�M�A���r�mY�~\n{����o�����@��ز1�t��!�Qۈϑzyp,XU��Ph.-&��`�ډ�\0y�m�.c7�|Y~O�-Wu�W.jnqLxZ�h�>F����ʺ$%h\r��������\0ʂ&d;΃r\'�p�U����q!��.�*��B��`tZ/�J�e�*{7���	�Q�]�#��#�Cy�|xFۄ��OQ&���}����c�;pT��A��\"��Z�8N�C��WU)��G�7q�ǡ��\n���\'uB�������nM��G����{1NS�,��Y-F�`�d�:��e\'ٌ�o����vU�h��=�<�k?�@/ʃ~&��nlCb��&O^(u[�&K�J<�Ol������@6ʁ҄P,\0M�S�9��Y�h\'��,n�o��M�o�Ș����x ]����lQr\Z�\\|N�Ԕ(���P�ԄP�v���P���sR�\\�/�G�}�px\0ާ�ʱ�{��d�\'���\'�b8>�����4|��q�0<���|٘GJ>c�D�l�I�\"�؟�3=��҄���AΗ����a�q��Y~9�rn	[5�!Y=��)]W.u�eh/��\0���gЇ�D��4ʬ�C��\0t��M*��B��n���M]+<�k9���~���m7�p|ư\"w��(�w���\nӖ�����c7���ðR^LҐ|�]�+��ʆӑ�*H�V��J��	�S��wA.�Xs���l��i�.+RRG��mX��Z)	fNE^�����X莠���ԏ���e���|o	b!4�[\0MF��`�\Z/�ڻ��6C��P��x_��jo.�6s|w��]���������}\r�m%�1�)��}���`J�Y�q�0N�	}�L�c~՘�7c��������z�χ>�y�t��{���,�:�Uo��O�J�1�w�����@iO�pyU��AV�NjE�fYW�f^]�����Қ�̊<������ʬ(P�mo�O���jW|RY����;�\\�*��*��(d�|Ժ2�Q_�x�w�)fs �r!dZρL�O!�l6d8͆���<���Pl��況�W�ِk��vxu�g�>��\ri�.����C�a�|����q1]��l��x9��m��$/G:�|{��t�#���̫�}6T�����i	�]\Z�Š��sxj2ڌ>�b+�Ԃ0C��Ѧ�_�������vvl9�0��dX{W�O�i{�6�a�\\͝Y��O�+��NT����65w<��������Qnc����f�cz�Q�xn�����P�@I������E��Axd0��$�p:bsvG��!�H�A�c��vGm�Py�q\'��C�A��At�����|�:�yn��͢Ӓq�i0m��1>B��z��P���Lz-�B��\0<�Z\rf���W<JH\Zm:�Y���9})��;�/\'���\"�I����O�:FWe���uV^\0�릛�o��{~���<x�����)LҒ�1����̣_���i7˴��t��I�S��E�k�3`:�A�������3��)�uh�X�I쇗�i8������4?�\r�����<��*�pz��9�G�7=.��!�[H^ď1=|6<��\Z�7mӐwD��N�I�B��b����E8&-�&�UO�.��t�6-�����\'�F���Z�\0�ب������*rc�h��>�;o��݂Ȳ�6k\r�i���w��/|�0S}/�]ڛ|��FAr������0������*}�U\Z%-��T��	���ӠaP���İ�`n�]���j�N�?�pǥ���5������1T��P�?I쐧�����P���D�a\Z��\rd������w�!4t�k��q��`����e����Y,�f�V�fej^��Ѧ�A�P�S���\n\\�Ka�}u�f�<��*�?Oy��Lcǐ�� bp�N�j�8I�6�l��r{}���|W�<ᘫ)��C��6\\g�����B�w-��(Z��@c�wP���Z#5��4����P�4���P��o�Ҙ}P�p+����4$�6h��U���~����Ƥ]P���c>�W�h����[�2j4�l���۱�]X�V|���@e�^,C�m%S�#�3��Gʟ��Ǚ��=,z� keʜP�4�n��?Vf�R1)-d������&����(?.ٙ��L\r�\"��^��:��@V5��0� \r�]:\0\\Ǥ٤=����[����oÓ�V��V�����K��\\��k�]t\\�L\"�z�6���6�%ȶ�%�V#��u��uu��9�	��5ɲ�eI�u���\"Y��\"I6�:E�e}�l}]�l1�.�$Q��x_��+�1�&Q��4Y���+��WT$ʶƤPײ�d,�䓈�&��b����r�Sd�\ZR6ǲ�g%]e��MZ�C�\"P�\Z\'�B�XB��ZOh���\"���k&mfĦ���<-�9�4�C��H��^�p/Y.ɩ�&�V/��̼&y���N�%z��;g���W$��(9�nz�r�S�� t�8���i-\r��� H�SuZk�;���bbIQƓ�y�V���_As�x��V�p���qW�M�ZK1h�X�v�\0T[����>���#`}er����Mu��],ԋ,���UVX�%=��,6M���u��wZD�N�u��+U\nv2;h�W�uX���7�4��V�<}�.���X_�����#0,��\ZXS�u(�������;��ˠ�t>4�/�*�W����z����m��q׭���������%;�2U��l��������աM&�n!��i��W�=,jo�����x�ΞO����9�c�f��	8�a�s��d�	+���]���;���ɼk\n�g�_v�~كx��A�Ͽ��z�Y�@��\'Pi�F7=3��`��=��z�c�%�=��5�]�\'�X�o2�2��g|��{r�����o�ŝ����U����h��5A+�L!�=����ؓƞ7��o�;0�ApgsEЗh��|}!��w\'kTZ-�fk�X5�b��n2�]_�?N7\'Y?�d.�W�k#ɷO���>x6ԙ~���-Fsr�-Ij{=������+�g3t��Q}�ǀ���)Pc!	=VK���c�qS�Iq�\Z��r��!�u�u�Sj\r�3�R�K��Z����r!��/^i�&4�u���cJA~NmU�A�����d�S�(u[�v���.�Z�eQ9���]W����<M�3(�0Y���z\nC��b�� T�CT��hד����;AY����E��sC��lh| �d���(���zr��`�����0)���<A����h&����V��o�z�OLhtI���(�����A�ߧ#��3#��f�<���Ջ1��w26�΅i\Z�xF��񰔅����G�x����j�aoݸY�w�Ȭ�_-s��V��\'sa\0�>2\'��\r����F:MP�[\n����h��}�x�wl������m6�W�1G#Ƚ���8��������o�	<�y�A��ѓuA�bf������ xߏ�8*o�����	��_�P�/�ThLU�/���O4ޮ�����7��oD.(�z�Wʞm��8�O�C�Rs�}(*��r�}t��$�^m��O���/|\'#ps!.\r�Y��2Bqq��1��:���;����J�#y��[��ǽc�b]V�<n�:&g\n��uAd�\Z�u\ZVL�\0��J >Q$&k��e�*>��NQ�jT���D���A�m����[e�\0�nv��V��x��ߋr��gT��SK!h�]f�F�f����o���\r�T@j�E�����\Z 5U��A����g�����`�� ��\"HOW���L-�N�.x�G�0��av���&��*,s�0_)>���HNSI,C�O$��=?^y/��Lu����34�N� �s�W�H�?��1���%~��zv�߷�����:�r����F�̈́�\0���(���3\rR���ؾ�Oa;kb{_Ķ�vF�K���>(1\r�OBLW��@z�&H�Wq�#��㎃�TŔ�G�f����:(�5O�}_܅��S�X��m�����!}�!�MAZ�aټ� ΋r��8�&��xxϫ��B�s�\Z�OU|zR�t+������|�CW�X���\r����b)��,�V��`}U|�i�~���hHADİ�$\'+c�¾Ňm;�<Ҝ��yX���cPF��iH�)�#�&����C\n鲈��Xvko�b����Nx�~�%X<�4�iΏ�7˟�2`\Z������x!5M����]��ȋb�Ab�Y,�2ŧ����Խ0�%�IjnZ�,��X����ɮbHB��d]#Y��5�-VA��h���ңM��L��!a�?�kӱ��#mg`Ǿ%:Y���v�G~΅�g�9WɊ܆�sUa�x��SI�����I�g)�E�h��O��jo9]`��ql���Z :a8������|5j��1hω�#����o�U8y\"0��#3��!�[b��؀2_r�\n�|ȓ�N�O�}�r�7t�l�GL�S+� `���+`rC��\\hF���`>4�H��-�Ѧ����1��(�I�#�g�2u%��J~����\Z��3��[�`��.������͇t��4 z�\r�cO�[uojQC�o���b��=O�u�8�S2e?�7DQ�,�9�~�[�u���?O��2����>�D�C���N����c�`)ϑr��.����5�*���������Pn%�̗B��8����oB���*�\\\'�8�P��+g\\���O����:��u�t�#��~��wV�W~�S\\�/4�W�^b�ٻ=�{�\Z��8�?�v��o�3HP���\nb[��X�{S��uW��_��A�s�UJ��B>�F��He���_%�4����!5�|��8��Ps\0�T�=\ZM�Q��F;A�����ߢxHAe�dU��T?REJV�*�\\c��4&�7���{��1��-JfHM����q�ُ����2�:���Mh{��G�}�\ZꛊD�l����o�cS� cL����*�/��uZ%�\0�Yb��ە3�����-�#<��y�o�-|,�}k?��?\Zm���Bh���_�FF���i}���E�;��_;��fß�1=���|�C��D��|i	D&�}���֫�<~��cn׃^o��\"�w�1�D\rZߟ��c��!�����h�E��F�,҅eQ_�U������ ��������2F���W��\rt�>��C��&_�D����V�����o\Z��_�]��=��������J����~��C^�:Ҝ�]���6�B[\\|��}�\'�el&;�Zyd��>��\Z�i��c6���G{Bl�b����b��lGR�V�Z��Ǡ]�KtW-�����D�Ќ\\#�;\"�����+�7A{�j����Z��Pi)���J��i��O2��� ���$�RST)_��$E��Z�����8�2�=�]���)~u����	M8\r�\\��`�8�7�[V��ڬ��\ZD��J�*�Ďס���T;Oo~�����H�/��\'��щ�~E^\"���i�\"ţb����|eɣ��ߥ?˯�]�:Y�o���_0:��A��\0�Y����գM��K��!���oa_�vی����>����������:�w��lb��i={���9rºV&���QC�U��]_;���w$Pǔ 4#><�W����6�d��-W�䏤��3���n��	DwT�}���?c�\n%���X=�]���Ń]����1�\Z��\0.(���mD��d)��E_v�i�~�o���-گ3��G��F�_�U�����w/��{�;�|�9�@�Jr���_̹h��ˍ{������Y`�8�/j\r��*�������΃RF��cFR�+5�-p\\�\n>�Bd*�/�S��������wm_zI����w���Y���&�恎���*�Pk�������w�\"1�4{�������I��6lˉS6���aI����]���\Z8�c�%�a:���N�=\r��UY\\�����W��㼵i4�l* 2I���)�o�nG��NU��-���qeDgS\\*)��#�&0��5gAџ�#�a��:�o�wsqZ�����Cܛ���B��P��Ea�������/�\Z��`u��Ѧ����)�Bz�����R�,��W�+���p��%���B�A�o�V�����u�Y��r��H|~�w/ڿ�4�\Z�MT�}�S/Ӳ���P��U��!r_������<[������&���HQ���\0y�i�,�t�k#:���\Zv��fxJ����/��\Z�Ⱦ����ו��M��K���!q��ǶO�p�}^�r��e��#��7\"�J���x\"gQf�]�xE�lA��C{Ů+$�W�^ys�*��-�fGYB��h�Ss{hSLTjG�P����H�/ᬗ4�i����J���\\��@�}�jC+�)��k���Ξ��2Y�#�Q{d�6T���kD�?q0�� ��ڼ�ߥM��E��ҟ�=�F�aħ��rġoL~�[�{�D�^�~�M�W�����R�ѵ���.��W�ͭ�값��)*�sHD �\0꟢��^��{Q���Hꯥ��|�����S��箔A\n���	�odE�H_=�hD�p�d1���pz��`���0&�C��8k}�����Yi��O����o�KϷ=���X9U�upۿ��/\nr:��~}�\'���g���6��Y�w�&(�_{oM�{�o�y��;���K�띣���_O�k\Z �Od�f�壞�~��-u��6~�\r\"<��RJ6���E���hx�e����{[�K|����)����d���Y\nC�h�����r�����ߧ�c\r����ql���S���i�a�6�q|�D�\\زX?\"kB����[D���:ᤓm��\Z�f������Ρ{Dua�TUzn\n�?�n|&��ܰ�ʍj�Z���ٯv��$�� zC��P:�����J��,�����Hی?�Y������Q���*�9��	Sg�U���à�\n�כ^��������Rӣ�?���h�)��g �������P�f(����;�����K����q\'�m<��h;����5t����VL �|4h�}��骰�[�I�Tf���8���P4�K|yx��{UzΘ�E�{�3/ �U@u��>U�����#m�����.aJ@o�G�E����2�9Њ�ׄ�����aП��?�vV����@��3�RX>,���C�����LB�����]UЧ&g\"8V��3�]0S�^���Olʹ�_Yn�|��K�.D�_�b+���\"�~���y$��d.�[����/�bh�x]i�S���\r�����$A�����F��[1M�^�˒Ɔ�����a>��<�Fho#���w�X�sT���������S�u/_ҽ���4�9C\nː�|�h�)����C���������.�[��:�\n=P���ÕBz,�:_|��bq�W�������Az�&,G9.M�i���1#�����]�q�\n|��&��U���N�����J��_�\'���U��+���Gی�í�]��W8�H_$7T{́v�������v��/9��AE������W���L����_��v�@��d]%���\"�	\"�&Úϯ��xz}&�	����M�뭫A3�����z.�aw��(3a�MX2u��d.e9Y_�O֛*Q�ȲqgAyM��\nH��F~��+Iւ� kA�k�/���5�ϴ�/��]��:}y�=л���4`4`��F�������a�_i��L�\';֙���$�y���[?���{�c�����	hϣ �c������Y�K>��2f>H���=�|\Zm\0U�h�M>߲m�����(���;�;y����ªOQ\'@ۍ�\'�D��>N���@b�\ZH�uǨ�L8�����w35��|$��q�Q=B<��,�W���P��\n$��٠�o����+��o��G�O��\"�.��\\*�|��]�eX6�0Q9z����J��Ѩbh�\ZC��*=]�Iq���#��?S��㓻���4�4����j~5j����1dm��9�uٸ�(��7��w�XzE�̶_�����ݑ]�:ç�{�qC	��f��>Pu��=?���,�G�|$3��mM�[�cvC�#\\�.��\Z�<d��:�޿������ޫFJ! \'r���R�軿^�%]���m����z��<Z��3�[�X��:�2t��[��o�ٰ���6��N��}�O���C���*v��6h�\0}��G���{4���i,\0�8��^� �?R�.}\0�_���W/aӫ��6��w�^l������cj|܎~2��盛�з/�~й���H�}�e�;�z�+D�\'��Ⱦ��?��uh�����J��K�(������[��Y��E��#��>`�d��hD��ń��9~�?AO�&v1��䬋`���\ZZ�o��:~�?r�+�\'��;>�g�c~�<~���?�=��w|���_��߈7a?<s����~����y�������~�m�R�h���g����߀���\0��c�wHyZ83/���`��(��E����&�岙�^��ra�\Z���c~����7~�a�(L\n,f�1��0s\"�\n������xdo�a��8̳<#~&��\'�{�����eą,����q� ��H�Ջr����+$�qЃ��h^�j>��5T�(�	\n�Jf�=���\"��ZjC�s������䠠�����ۚ�~�[(���.����G~7����0����RC�iI�̌�`f�#ߨ`�\'�)#��gz�����@艠���B��	���Vb`z�?�������l{��\0��\n���;����6�����P6�Q\\�*����<[�=~Ƨ���^p�����{\'�^cıl^f=��2�t}�ۜ�{R�k���)��ٹ-�>Z?�Á���&�`se8�+��E�j׻�3m�M��E�q.�k�\n�\Z߂󍝶I>���)Lv���`�]�n��Q��h�s����&oi���j��-���\Zt���E�W�F��$t�\'����&p�����g�m�n��9>��d�O���nǮ�������?���W��W��_���(��>�����3?	`}i+�\\ޮ���o��l�ַ�\\;�%!!آ.�\r�7����~���y��i~,��A�#G��/���\'�a	�{��C����-�յ�Hs���`p��>����Px��m���0>�gWAR��4UB�ٹ|Sm9~/=W�b��=��Z��1��O�B-�ܞU�$4+\"��*��AZ\Z����,���^17#B.��8_���\'���ءN`�\"5h}ϻ���(�^\nɾP��3�/˝����K~��f��?.����P���P����?��UH����`}M]u�iw3���?�wtU����8�������M����Nxgo|����n���o_a`��%���\"���4-�\\nA��-�-t7V����w�7������H�}p�0��ԏ˟�^�hk��57@��M�����q5��<�1�\0�X�j`��\0O2\"!�Q+����q��nD�H�L\n+��f���a��>q7=�[Z��HM���Ɨ��cNթ����6B��e\Zzv�`pf9t�U@eU1��mb�9���e����Ɓ��e>�Ї�\'{?c���\n�?h*\0MH�c��ߐg������<�uf|���A:���a�s��� ���y�\0�ӷ[_���ڧHo��^�w���0{h�����f���Ks��<<�v�[��Fzꀟ��>&g~^��i��P�k`���X��b^���蔨klls��\\/+@[��t��q��}}gY����,/p��\0��ׁ��`wcO��3�]{;郥�F�C�$��`������ׯ�i}�/�c�wv�������ٶ�����o�Փ�H�<�J�O��)����o�����.�񕴁㝃�1�\\�������7���E��h���q��\\���x}?��vW��ɀ��(`�An�7$F�Rm��P\0�:�BoU<��w�S�a�l�fx�����DC��6\'����\r&Z��k|`w*�B>��6x�D��e�>�������b\'Oƴ�q��/l�G ��\Zl�l��a��t���-�/ �ۀ��E9`���P���!�Ɗ�8n�_�S�pk��͑�k����z�����o���\r���a���X��wSmڎ��6��颈�1�Lc0UY����z��p;p38��t��Ɨ���I�or��Jc��F]��*�T�k�AFV$�4C��6x���ں�<lT7w��W>NOym��o2\n�;���g�?)���M9h�h�w����N��KeY`�^,����\0���^�1w�Kl�Ĵ�[k!��:���߃`�,��}�-!�A�]�U�I�?%9�p_c\r�\'�����a�wO�AOS.47W���k;<�%��~����k�/�P�Fo�Fݏ:��#(� �/�g6��R����/�\\�޷@}Q.x\Z����N|쪢;�C`��mmR��ҤP+����/�t��lo���`sq�d=���BpВ�#�-M;�=`es����vFF|���ap���(��\'�c̸���nvu����p(͊�K��<�O�G���0��:^�ގ�2Q�s_��6P�ñd��e��Fp�����9_߁z�V���D\r�E���f0C����A�K�t\n\nSc�y�T���� ��:��Ȁۍ�-^f\Z߆�q-Ĵ�X�W�2� �0j��1P�\ZM�A��\"�1T�bi�6mGD�{��~�+�p��Z\Z`{U�:�Z!���a�z��}hcx�{�r�cޗ\0��P�z\"߸��m�����.���`r��[q��+W�c઻�;������R�h\'��u���<!_�_l�N���/����:���hqV�M�k߃��^p��Wo{�phV�7�*�����q�(D��y�y�0�}��n���wC���7ΔRkyOgy��C�����ڣ�����}g\Z|녿�٦�H�?3���!sup����C;�]���_j���P�\0^��s��mL>(%{�Y,�~��Pb%�����Ѧ�H`����$#��,���<#�%�]�����r����X�f��j�O�uz�\nԲ�cm3�,M2YL�tG�t_s3���ͦ�`^���9��3B�fŦO/x9p2#��>#,d{F���\'\\[�୙Q�+5��<���|N;5\'�9����j�e����싷�/��MR��>�bG�,{�p,���&#��$3��23�F)=�ZS�c?�޼6�[z����aQ?�s�g��*��?�\0��\Z*+U��q�YJB���>i/�,`n���q��O��w��L���n3�2�\rO�OlM��E����E@�#]hẹ�{%�u���Uy}\rf��n�\Z\r��ix�b������|x��@��(u�u�,������\0U�R�n����C���yB��hח�������հ�@O�x��O���%�C�sAI�|�7���%(��B���ά�Ѯ3\'��G�<x�Ȕ��c�>�{�p]�$�s�vS!0�����܎��z������O��T��G��n�?��w�\\\\tZ��^K�4����@������=P�?�Y�d��r�8��!t��A=���,�f�Oߔ8|�3&�s��\n�\\�}_�׭�L���?/�� �!�T��d�KG^��򖓶��.�yk����v�����\rt���H��ZZ�RU�RQ�Х�\nQ�ȥ�!֥2��%\'�K^�m�<��K�C}����\\�]r�׹� �׹��}��ֹ�jISU�1�am�6?~x�t�=��������0���2�*3Q���o�z��ud|�����°&ϳ�6�dO���J?��j�E��*��*�pw���Z�O�˜��t�:�]��I[�㬷5��)T�!����� qhB;��1��#�BW�\\���?��)��`L�.&�N����.xG�C��2�>�H��A|�j�Z�B���M�BU����q�ݞ\Z�k��T������O��D�]�g��~�1����G��u�F�LΈ�O���̇���{4ߟ�gL�|�G�k����\'yF�q�.O���ُt&����^;��;�λ=�\Z�>�\nq����\\Z-��v��Az�����o�\r3l|�+=Qg�����U~�ח�i�\"�>g����=�\'�V.��\\�ދ�G;���w���[<�CZf��&��aX7٧\r�ݍ|�2��i�9^x}���i��)�Պ�^c�+r�^[d���Pl�\n�@��B�1�\r�BA��g?:m6�m�p�p�p�p�p�p�p�p�p�p�p�p�p�p�p�|����0+�\0\0�mkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x�흍�)��q ĉ8�D�^��>׻gI@���X�jjg�iЃ����`0��`0���?������ϟ|�:����s��\0e����Q����3|����ӧO|�:�2|�����.�}��;�7e��GF������O��6����_�Q�v��������]T��]\Z�^�ˮg��{>pj�z���k�u��o{�y���ye����?��{�-�������x���/D:��3D��&򈼹e�^H��y�i#/OG�z��Ϫ��߯_��~�\n:�sMe��#M��3Y�#=�2��Q�����Й���[\\s=E\Z��8�}E>�Gȩ�T���ڲ��T�g-��}������Vf���������o�SVw�zV}�.�/�>�~�<Vrv�@>�!?�U���������1����<�#������}����=�F[ ��~���QڋB�N�.�.+푹^ed���Lo+[\\�-��k���\rd�W����(}����6�q��$�#�?z�6��Bө�i����?�L���7�!�3�O_Q}Пu���o����[�=��tk�ȋ��M�����!\'}/�Ƈd��r2��_�C���ﲨ�:������`0:8�����o�=��+8-�4}�۞�c�ĥX�dq�{bU�����q��©ή��m�!�ƶ�g*Ϊ�U\\z��[��GA��=^�+ru��{��LV����	�U�?)�V>�ғ��)��x��|�Y�ҁ��gi��\\�yi�^c�U���o��*=�����!�����T���Y��?rf�g�����W��s�ʽV�n���*�V��X�#�=��F����ϫ��+[�\Z��F�~�yH�\\L�~��[���O҇��h�5�ݵ����T����o�\Z�w�|Sf����ӟ�+���)���;���F���;:x\r�������)/�OS�y��U���o��2��e�)Ve3\'w���gGg��=�J��^��`0��\nľ����u k�U,�Ks���ؑ5�nY�,��bXw{���w�&�����3�Qה��N��Qev�	�]��Ʒ���gcH��˞��i����{���A�3���I�8��h��w��d��u�w�����UI��W�q���8�����I�>�+���@��p��Qş���Gc�Z�����\\ƪ������U���ߝ�]���/�:�����3d�;ɫ:gB9�R�����|GW~����w�2��;�fz<AǏ�ߊg��_��l����y����������=����U���y3=� ��[�6_�����3]U�_�������k�]���]�ײ�2��;��j���->��t|��+�i5���n����Οg�Z�Y|<�1NyŬ|E7�k���������?����z/k���>�<���=�Α}N����΅���>�u�Wy�d�ʬ���dz��`0*��\\?W8�G������Y����:����Dg��c�g<���2+��������\'�W��6��qn؟{�r�u�\"w�<�Tk��.��\\�r���n�O����>U쏘~c�#T?��+��y��{�Q��,�,^�qF/X��v8�.֩g��3}�ȸ�OP��~n%�hU�G4���(_��sn|W}Tg&x^c���,F��������ѭ����+�<���#+}/�Uw8B�Rh_�����|�33!m�r\\7U9�m��({�ѝp���ve��w��[���x��G�������]�߱?g;�,�n�ҽ�ow8�]���ו����b�����?��OV�=��Z�_������#�ve�?��v��N_W��������r�YL���o;�����1�g�9pV^�G�~>�[_��v�NO�S��3��`0������Q����[�����	veO\\k^8\0֔��v<�Zbz����\\��\ZO�p���b�n$~�}���o�z�3�ј\rmK���vU���]^�i�N���WA��#��x�딫���j��t���q��:���E=�\rz%օ�q�)Cc��Y�E����q����yRG�-�+u(K\\�h�P�\'��*^ء��^���q�=m=y|K���vūe���\\��rȊ�4���=���{W���1����;=ݷ��x��p�;o@>���Ș�T\\Ԏ�+C��=*�ɫ|��G�JO�C��W]��x�1.��ﵠ9_E�б��\r��V�q�����)v�(��ʑ}��[G���w����Ǻ���{-�o���Sdו_˞��׃���2��;iT&�w*��w�����:�����g׭��S�O��s���j����%Z�[~_˯d�֮���+�������w]��7��`0����]��k��I�u��+e�L]���ւ�oA^���;=GR��?�\0�v쯱�;<��y�� o�$N�1紈=:ߥP�V��u��<�� <&����3K�yC��/�4��r�)i=��*/|Ύ^�]�Q�NН1q�G���w>ù{��<F������V��r�2�n��lo�؍ا�|�m�o��\'�qb���Ӌ��r�`e��ef����6\n0�lz��sA�_������x7��췣*�U}��R�%�+���C�����_�	�ڟ~I\\�Q��~�k�y��#_��jo~DyU���^���`5���p����k��o�?:��ˮ��C����w�������>?�Kv��:A���}E:���_�n+{��u��=����r����q͓�̳]>>��d�}+�����\Z|L������0���1��`0�l���e������g:��׺񶊝�`W��,3�O�?���]��\\9�P����~�[��kO��W�i�Gc~�)��-<�w��.��3q�}��\'v�u�w$V���n\Z��v��(�r������5��2���S;W����k�_�K�ϔ�8B/���h��E�ՠ�\'�9�w?K;�x:�x�<��|@��c��Ͻ����V��y���c��@ۖ�Sw�8B��q����]��=��2�l�B�e6V}e��������R�(�������	V��e��ZT��4���ad��e2ޒ�+n�Y����B�����Tq��S�����ߔ�<�����[&�=�f��[|�����s�z�P�)G������}{Zׅ�3���n7�j�p�W��wf�t��E�w���[ǽ�;�����`l?��`0��`0��`���{������~��������i`oL�y�>uo���i\\q��K�|}��\0��7��Svu9�G���쯿c¾#���>�,�jo��w{�Ն���ݲ�L��=�mW����2u_�����8د���jo�?���k��D���߱��m����w�>���#��}������E:��OۡO;<���s��y����}�ڛ�k�}~����|�M���\'8CT����o+�[W���������U����Q���r\'����\\��\'�t�TY��w��z.D�=��W|��~q=_��\0y��M������������Ǐk�t��bS=2��|�ұ�y�N�_}O��e���摽ۏ����tL��S6�q`C���jf��3�#��ܰ�?z�1���H���]������\\\"�W���]�����O;�2\'@���@~tG��:�����{��u����7m1��Q]�PW�V�2�S���z]ϥz��s������3��]v�����xwҞ��:ڗ>�y��`���$j��w�\0\0ymkBT����\0�6\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x�횉m�0]H\ZI!)$����FR�?6�c<lHٱd��t���C\"��+��RJ)��RJ��������kJ�߃��L��_SU��n7���s����s~�u�U�-U�yy9�c���������/Ju�z?��i�����>>>~�\0sm��+�v�u�Ց�νY�u�8����uN�?�WP>�1Js��WiV�����_uK�E��ϸ�/r����_�gK�W]ױ���EY�cl��,[��T�YH�T��������������}x���L#}A� ����G��V�7���^�}>�iҞ��-�����i���;}�LJ���X�&�T�P�3�T�#��ߨg���J��l e��\'�=���?�͘o���n���a�����|7��>��?ǐ�U�%�;�������/�m���N/��I����f�Qփ�z{��<�d��6�d�n�;������Q��m�{{�5�$���iѦx��g<�$�\"�^�%=����RJ)��S����t�e/�֔� ��a};k���_��y�?�9Ԛ�l�z���}m#��G��Kk!����k(�9�G��1�����z��,�Q�&�l�iV濊����#_�<���3�Ξm$�^9g\r�{9&�w�&��:˙�u��f֚��R��:ֽL+mW���W^���z%�I���2���lo���Z�f?�k4�W���-�#��	?V/�c^��!�!{u̵ʴU���\Zٷ�A�����Ge>G}�?�����v✽��3��X~j����{�zT��A�O^��ʰ�>��?s�y��|����G)�P�</1�1~2�ў׆�R/�7��\0Ӿsm�sr����\"�(�����2��c�Ϲ;�~�u-��)}����<�U�1�g���:�a�p�b�5{��3�(���k�!m\'mʞ����2��.�~[�)}G�κb��XE�L��������p�aԃ���7���7���Fy�0�@ߋL?󞕹��Khi�@=���RJ)��RJ)��RJ]M;�;����j�;��\0\0SmkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x����i�`�Qqqqq�����!��	�C�O��Ml�S�$I�$I�$I�$I�$I�$I�q��O�9˵w���O�o]�s�s������,�Խu˲<^�0��t�c�}�av���=��7����_��{V9��z�}��ٿ�^���s��_���y~�?���}e�z���۶�������������@��w��E՟�k�$I�$I�$I��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�@?\n���R�*f\0\0�mkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x���ytT�}��IpBǘE�\r$@d	��qN	5���M��MKz|NNh�6u��\r�V��\0-�I��he�X%KB�h�k��ef4�ъ����==�4紉�`�����޼�ޝ;�7��{�{2\02���u��c3�2��2��gYK�l��5�/+�f���2%�ZT�q��ed���k��+v�\ne�3Y�#O^)8�/2,|\"fcx��oE�qw9ك�C���_zg4��Wcz�q�Vv|:��xkچ����㎘\r�[c�֧�w�����{�{��E�;Z#Ӎ�d:�V��T~]ו��ݬ�%l�o�ٺ����ee֢@v]�����m�:�cJ+s��e�n�7]1��3~v�UӦ�>w�z�����}�+\']��ie���0����\'�E���0أ1pگ�6����)w��=8�?΢�v�Q8s�Y �}Xi;���R�`�����wDWd����g�,�n��6��6̵�1��x>����Z���=��o�HĚ{椭��U����r�?����ƿ�S釻j)����I�Li�pņ�qrz���oV�͖��jw����/���j);6;�Y=���>�I�w�)�����#g�:�˙�4m�^�U����\"�;<�5�A��t�I�BƝ~Aq�[�ij�I���Q8��-h��4e�B��\"(��¥�!�yHP~�&�MF�R���[W.h�R���υ�L��#W�>!�F�6�	Z�}AY�.d^�*(���>H�U�E�K�S�ʳ�Bvv� W�	��>�t�F��:��^[�kU�8s�O��ᰫ��	j�b�52�P�gi;�Y�ֳa�݌����_�����/�+ww]/Dk��e�O�3\Z�����W����������\ra�)���Qw��`x�X�w�X�{�h*!9G�&�+��X�}�h62�t��\rt�b��TF����X�w�h.��M�g����46�_0��7��f4_x�x��{ƺ�׍u��\r*:O���^~�X�<RZ��M�?j.9��������<]D�WQ������q�8�_���-�ݎ�hƭ�%i���(}�����i4)����Đ��y�cT���e���닾<�_��\\Xs��>S�+Я\\\nG��(M���P?�!ڷ*�a+�:Z(�aD#��|}�á^\nk�\n����h�R�g���1���]�8���Fy�9v�\'\\\n��Q_?)��5�v���$����#J/t�߄��PXc0\Z�֨\r7k�>���F���y���w�e�����4��zv�q���8��z�K�qq_/�Z��2�*iK�&r)M̃�u�9�y�XJs��xݥc1nz����sI�\'��b�D��OR^��B��]2I�\'��a��1���=@���� �Do�Dt(z�0���׾�7����x�����wέ���xSݎIc�i-e��]�o�\Z��.�NK��b�ǋ����xS��%t�m��r�����M�1�nF��x\r�O�u�j�?c=I��qq.WF1�H���W��y�ߧ�҆�C�%?X2�0���`j��1~������uS���x�:��4�������{T���%h��A_��/�����SN�:.��-�=J_�f��\'��t�S)�\"���\"�_�4����͔֓��l��(_���һ3}Ъ��9�(�B���;Z�X/��r^L���%����YJy}m\n���`Ԧ` 6�� �P�?��1�3��7߭��pw/TǇ\ZK`){ù����d��.=P���w������z�c������[��H�>܌�����$����#�#�D�{a�`3����xb\ZO���]\r���?:\'����$\"M\'6��MoBÉ 4Ŭ���Q�t^��>]�������[���`��]�k1\0}�pd�	�t�_��3�hM�UvC�W?��T#����y��n��9Y�{m;0C}���R>K}o���`�vL��/nzR�?m?���\'}/��\rk�~���5�Yؒ���Iߥ}JK\Z#�>Li#g�`8i���i�0��#��p������w.͖8�G�A�c?li{aK�[]wn/��麔�J�k���5������A��}�$���>���Z�_��W��:v�U�M��;�/p�}	��/��������t�g�M��`�|cn�6U\"�GG\n�{�:2�0�	-Iϛ[n���?Q���̦\"USm����D�XoPݨ+TU��*�i[��m��rn�PUA�+�)���՗о��E�&�C�&��i�TUa���ub�E���毫�/�?N�\n�����jk��~}�,jwbD��˗�>�_�<�ݪ6���*~6=��[�]�ȕM�Q��mxV����Jc��5�4�vҸ���Nwvb�í�����mX2	,�����^r�hI>��\n��y_5��??W�z+�_�����-\n����ʡ��N��;\r��]��矋���h����z	�.��Nm�31�De�߻����F˕Cs��ɗ�YN�N+�X�k��|[�COP[���H�.��m�B0�ѨM����[�r�ݿ�}�\'Itu�ߡ+7�ں�	\Z��\n������9�|���<[\\G���\nO��.G�`�Fn�3n5�R���2��������b.?�>�J�˥���/��pf柅��u��2iME\\g���3sZSvb &S���	�Mť�������H��g��\r��P�07v���xq\\�G���4W�X��r��a�{��}	,YO�=#��w�0��SA_�$�{;��L�����0����՜�\"t[1�����v~L���H���&9o���ͨ:�\r�����\rݱ���o�`�Vأ�0��]qa�Vg�.;�����g�:F>��u�����`�,���O�K�e\\��P��9��Z����\r���\0j��)���E��=�	8�a#�Ɂ�	l�(����,�����������1WE��/�zsVεuq��*���9\r�{n�4蹴��;�g�I��g_l�R�9�r~?,�1��-�wO�������Nͅ�;r�V��7�?l������l�[��PH��|&;J[�~R���U����z*��s������U���_��lˍ��m����S��T�y���|���r4N��]��� ��ı����.�Ų�w[s6���LD`(6��5c�N����R���\Zw���\'s���w#�w Ĺ����w\'�5[�R@��u��[,�������ÿ�qC���!Ɵ��.�boSϿWS\"�1A}�E�8��������z����3�G?�(;��2��Q������A�b\Z�=	K�V��C`��D㺭wjӾ���M��(3{���k�u[\'�����hJEo�6Ǆ`*z\r������\"�ҨwwY�C����݀�-�ѝ���0�	�X�7q\'-����_w]s�����!ſ#}\r��aO؂��@��^Wl0,�ΛK?�o���2���޸-�%�b4�֏֢7~Os�����Y�.{�wD�zj#�4�kM=�y��7\\���r�GW�N�&�/��<����(d�.{t�5�B�\\u�;����ea�^����.c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�c�1�e�e�˻ng\0\0M�mkBT����\0�D\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}X��7��z���v;��-��`RJo؛��nTT\ZA�i�����5��x�����?<���^3�f��{{��a\0��k+nǅ�n[t�y���O��[��U^��tm(�?������r��P���w@y�f(L<%qǡ\"�bJC����<���:cN��@���? ����덵q.u�l���ԕ%���}������,�b��������0�ً@��hs���(t�Š�QZ�P�.�R��*�9x�{a�\nł�o��s\'�����?�/�!2C�df����rP��\Z��B�Z����|xj7��A?}.<��}�����\"�s�!+np�/����Bx���A�\\�����mA��B�K:���V�/o��[�V��TN��y1\r�_���i4��11��g��ҊZ���\"\n�>xx����^���.\0]�B����*S^���\"I�k%5�P��T���=����p��R\Zl���^� ���	yɑ�l����&[!hs[^S��#7v���9�_{L�/�Pq�d��[;Jj#6�պ�A��t�y`\0e��b����͖�iPi�� �e�<P�\n��A��L(����g@e�$h�u�P��=T{~y^��}�yP�&و�-+1h��&���./hs�۞zl���Y�a�Ǫ�Э�����/�~�q�_#6�8ͪ|Þ\"?�uA�\"X/D���5<�.��]\0J���.����w&4L���10��\nO\"�\"G��(x��I,0�ϓ�wn�c��1�d���g������-T�|��C%�	��K�?���R|0`3���7z���__�����X�l�ΰJ����k��A��B��Bw^hs�*Ļ�]j<�O@�����,�^ư���9��qKʞ�v\01�Kdn�!/��S��x&\r�9O��ϱ�!<�2ϋf���������\0U.���Z��}�gh\'z�����/м��ہ�7.A��:����\n���B�>h��r��}��8�1@l_�	v�L����AR�8�3������Y<sۇ��`Y?ꃾ���b��3���P\'<C�1H�E�=�b�\no�\'�s��i)4�,����=v����SXQ���ˡ���Gy�E�����>�2(u�\r���;f4�F�^#N���x&�C�L���c�}�wĬ�����O���g�߇�>�c�X�C���x�0���x&��X��������>�u!���3*����o��o��.K5�z�]0��t�z6�����G��u�u�M�l7�G��PS���0�\"8\'3u@OܰN\':m���aY���1�2N���G{<g\0���q������1�=\":\0�yA�ES�q|�q�o�%w�k+�/A��\n�������043$Q�ρ���No�x\\����gbF��f�w��\'?����A��ōF�]��q�$��ބ��͆��Cl������7|�P���wS�Il	�5��:�!�����|���o#�{�I��Q��\0�����C��\0�p���M��(}M��as���&2Mt1��qk\"�/�8��Ŏ�L���iМ����CjR�e����)^�W~�T^�=����y�A;��H�-���X�jS�@w�4�r\"̀��X�h&O�2�\n���d���\'v\0��(���\"M@Z�w7���}t:-�b�~;����Wcޅr�&z�v#�}q̸�?�9�ğ\'�Ol0�ۈ����bD�+�D�7�8SX[BS\rޫXo�Cռ��O�5�i#(w4�)դ�h��l�SQlUQ�p��./O\\§@7ڛ~��LD��S�;����_�s\r7}��B����6:�E��Y\Z#�b�=���A�Ϟ ޽�_����~������$E��1�����Z�%~B�)����7_���H?t��\\�PW��4W��4y���\r�Q���]�woC�������VR�o�_3++�q��n����y!t��A��l�	�D��ӑ�l�o\'q�3�G2u~[$+�G�WV��78m*���i|��glX�E��Vv�E�3o�SCs�\"�\n`%��c���?ٲ�bLDcc�4����N�E�ĚjD�&x><�`��r8~#���3���\rgE;�]oC�Jׂ�c�o�}�\\�?��W\'�\'���|�$ס�5Y�Us��W��+Ӥ�X�s{�b^�^˼K���a��ris32o�H̳�)�����c�\r.h���Xz4���|<��#y�!���o���]�;��ook����o�h�#��	_�_�D�}�}?�LR]ԑ\'�nˠ�g)t8-��_���m�v���c\'t�,�>��PK�V�)�:ze׉OO���2��O�Oޞ��^�o!1����2V�Eh���	0����xV��l,�%�*E�o�S7U���Y&��ܯ=����S,��Um!�4~�v&��\"@zD�z��^Gnxh?��sJ[U�b�0� ��ğOf�Q�\r�\\{c&<�Ow̾����?s$m�ngc����d�����r��URj����\0���[_�������z\'2>��%}���RsR����5�5�uU�.�9|���O\"\"W����G3������t>h�	A%C*�C��0ܵ�U!�se<�B^�M�x*�\Z����S��\nV�������6����S5P�w��l.h�P�YOE�>\n���xgcn�1�2�ñjk;kHKJ��Ғi)��\n�������v���rA�M\\�������|���;�^�<��fԸC��\"��xO�ސ1+���PN����{������ې�\n��v�L|Z��ɣ�4h���6e\r�V�}VE^Ň�@OOOX�v\r����\nPTVR�p억�XY�ߥݸ�,���3/���f�Y5,��z�����2�K�_}��h��K9���w:.��v��I�Zq�G��9���Q�?Oc�c�\"�8���̹?LE}�e�P��`�ܞ0���������/�>\re5�6\'Ƭ�ܪef>4X�a�$ž�����i�O�m`D��[�q˫����u���>�[v���~�U2\"[��J�3nY��s[��B��F�E� �ޡ�<v8\'>�\'��$wC��|Kw\"3_O���P�7E��\nef~��i*�)��88�jʫ�P��?-�IEEv�������cg86�������,ٰ���rS������*��Ꝑ?����?�8�\Z����6A����Z/���)�R��O�s8d��̋x�X��0s���#�^C�����/�F\rE5�VK\Z}�͜ʏ�y�\"��*�t��;�]��Pn����.%*��`��5[.��~8��ޥ����������?��rc��i1<���>B�>��� �����+�[\'�j���P���뉘P�&,�ѝ��h����v����̦�֟���۟w��\\�!�Yox�`i]I݇cu6v6p��m()+�=\'�0p0�pl������W�IN�w�� �7B�>l?������~?)���P$w�b�7H���-��v\0�[�=�U�ᡅ\041ġ��c��|X7�rݎ�]oؤ�-	3�7G,{�|����;�^��>��9[*�6���ʿc�5<jJ�PP}qE��dč;��.�kT������y��|��������3;�\r]^Ew�}2��<�Op��S�OJ�N��� �� �f�T3�cbaqZT^ibT��Ԩ|���~qRT^I\n��?	�S�,�}��)x>ُ��������RGqJT�SPB���%x����`}yX^@�$�!��\'P����J,�.N����UQ�Y}?9���VyMNT�lF��\0��y���b��r������Y�*q�,SJ�,�l[QT�w��{\0��7o�ëW���r4~��gN�<�\'�l��_�l�#\n��h�m����� �ݴUz����\'\0$|l^X\\�&˫�G��|��>Y�~.!�:�~�{|[d�\Z�+��.������P�]����j��c5�8o�Wܺ��n�����=VB�3�v�cn���	��7@��z���^�����	�_\r��.׍x�:�nt���}��{]VQ��x�������mN���:hA��Q�����YZ���Us>���{�>]]��]a�Q����/1V�kt�fe^�ݠSP��ɺF��`��zmx���֋��q�_�-��PO��s����B��l�B��*��@���0�jn���\r�Fx�5^���c�x�Y}}��1��Pi�ǌ�bs�҄�/�J����I=4��t���C)�_f���B�=�6���� �|	����}���b�9\Z\Z�O�<(J�w��֊�\"ӛ5e�\n+릖g�����r����L����u����#U�u�\Z���{z�E�Hͯ�����74j�V��ܮ�XUW]6����B����#�w����*���/�ֶ=r\\}4�	BY���ա�As�x<�C8�)d\"4�O�Fܯ�-�lP�M�P��Ax<��&Q�U�L�� �\r����z4�d��p6�\n�\r�x�o\"�a��aP�ǚ��X�M�f�Z_6h\r��XgC�\'!���H��&B��\Zm<���D{��W��I����\'Xi�%ngYϷ�eø��%yX�E�N/\Z����<��$w�i���.�G��ڻb�TjM%6�p��:���ԳU�r7�b��\Z�7x��.,6S�oq����h��:W;���`tlq\\d�s3r��r�����N}�5��批/�?q���S\\����ߝ��i��~uYB_�����3a��>�]9\"&��H׳�yA�A��~FZ$���(\\����q�vfY�j�0t�{�[�^��a���!��y�(��7Ib��2י�\"qS:s-�����C�F�5odn��^����Qk��ג:�R����H�}8�N�4RNl8�2qx�}8f#k�_\'0�bI��n�yd�-��uX$g[�(�_U�qg ՝\r��|�֡���{�F��(x{Um�V��~�ﷸ�_pͽy�<#�嘆��z{+�J��ou�\n\'���o�2]Z�V-�2��U��ڔ�G��� nC��R�V�~���F�퇩zGa����ʇ�&ł����Ʌ�xn�h�UEǼg��/p�~s��������9�f��%8A��c��~�L�PFg}��D�[ѫg������RsO!�)w��丟Az�����A{�Y:W.}��XJ��˺�Գi�D�i��fO�Y��\\���g��?�%�\Z�.���h ��+#k��:׾�u�$�\"�x2�|Y\'�\"��y��9ɯ�9O#�1�ў߃�c#x�����랟�1�A�d~��� 1���a�$���1���~�L,Y�+x�<���]h��u]�)8�u��{Ѝ��Ze|��k���N�;Ah�8�c�<��>4˝n\Z�Y&��k�9p�?���[����g���,�����F_�g��@��\rD��/�6ٰ����E��a�邕.&vy��:%��N2\'�2��l�i�X+��[�{󴋡�K%��WXj�N��i�go�Ղ,�\';\r��~�u��t�\'>⼂��;��k��v�9�B�7�0�އ�q�:��;���ZU�GyB�\n!��\n=ѓ�;��c8�7v\ZtİCW�dh������S�\'j\n<���QS�3����#�\'�<�e���i�>	��Xg�T��8�A$n�����荚=����uGN�ߓ���b9���	���A4�#�\rc�qP.��&����C@�	s^������tIk��p�V9{�̺���./m���zj;�ߍ�_X�У��X�p6���\rK˅\0{��*��^f����a��3�C0M�(��3����v��-e/��=����,����*K��K7w����_��v�a\0,r�\Z��\\�=����\\��ٍX��)n�;�\r|�ݹ�Q����Ջ������\'s��)^Ѐ~t\'�[����� �΂(�c(y%�N�ɳ/R�:��jK\\��<uoZ]��䒠��ya?����G:�Z�#�$�����㩅��S+�6��$I-�ٔZ�5�4�Xji��ѻR����D�O-ޝZ�~8�븗�7�4�Pjy���{1[RKS��P�7xOjYʾ����x��Բ�C��q;S�ůM-�k�c��&�N��kCw�V��K�˼�}kG���ҫ+���rn�:w9��1N����u��w���k�k\Z�� bz\Z��t�=�p��d4Z�3����Ҫ���<���k��N#�Sկ<�w��`S�3�����������/��;�48�n�U<�T�N�}}�$;⥤�������/�#,{]v�-^���q%%T0��O��q�^O�$>p٭�����p!�M�;�#�W��~Rt�^����������o���@}<��]7�z�R��*��	eχ�\'�a���c�:V��?��������f:��ϑ��a�aO9ܽ��7<�#�8�*�9�1>�����u+�ç8ܫ�sD�+������\"���\'x]t<GdE�s%px4�r�Gs��a�n�9<�q�>7�#&����w�U����;�8��9\ZC���8�ï�R\Z�&b%K̕t�:�I�V�mp5͛)��W���o��f\nT�~�?�wg��s�Z�va6g�t�����z���u�Ȓ�Q,���En;p[H�IB`�zK��\\/�əͷ>k�Y�w�`����卐1)\0��i�$,?n�UQ[UXc�uݍ�����m�����O�1;}��1�{U���L�ަ8Sg�:�ų_%���Kxӭ������uhp����\ZG̡����O��\rD�����^]�ߝ��Q���������G�-a���w��I��O��t:�<��o��&�~#�s��/ �(v{�Cqg�3��\nr��2��K��z�J\"�s���[\'��L�㼦�Z;Nv?�3:W���7G�xօ(�|fR�l\r��c��Y�ײ����ǂ��b�t���*{��i,Hak�o��s�.[~s�A�vm�KIaGx.��(�l����������-;�t�<�sXSsʂu�*^W�IC��xl9D��c!��㩵m����a?�)|��{�c�p�R4�e����ޖ{ʞvS<Q��\Zv�����6�(\'U?�J7x���t���[�no�����q�L��\0^�X�آ��:�{Y����16{Z�Aú�!4�C�7�_�u+Ng,��!f;p���M�fP������������n��1p��Hu���������~W_�x۶\r�\Z%d�����i�d}-\rCKn�j��ߧsq�>g�7Ra.-�b��,��\'\'c����ȹ�Pר�܋x[�,����Gd-��rh�Ō�b�}>����~����0�����K���W��*��6���v	�O�t��9t$�8�UZ�yu�����\\��;�����*���_�P1��|-�Y4��F�9!H��V�@P�Å��{ܝyG�����M:�P�#�؞�%�1���>R�IT�v��u��)�o�j��EH�Y����|/�V�����O�ِ]��]�8��(�3]}�\0�oo�r�m�r\\69�g���i��Pk�ms�@��(�[�A�w�����3�6�9��`������L��:^���#�>�%���Z����}�~?\0�>����n���o�O���	̜ҳ�h�5q�s�C���5;3ʂ�@��j�kM�þ��=�G!�%=1QEi\'�v[��/O�����Q����x��u!�?���ȚG�wk��4o����}���.����jG賛�v�P�1��FQyY����\Z��n���m���<-�R�\n�tQx����Z�}�Q$+�3\'�=I�4r��n�?��B�w䃇t!��j~c��\'�c����Od��c��h�\r�p<��5t��k 7�j����r!t�-��`���X)��I4ǭ�������x��4]Kcw��/�����\\�I���}��OO�/DJ���9��gތ���IQ��,��^S��\"���G��x}����\\o��)u�]_\Z�ui��\r�U,d��2���W�u��=yw�\0�x/��I��;i�����j|���3�.���9�*�¾D�h�?=��X���kC�[�7�)n!d>$����n;{#��Q���}ă���{=a�N��ޯ�h����\0q��a�\\�j���b�*G���|J�\Z�@�E���F[��o���~�+Ի�: �6<��;�CGS����X�\Zb7����E|��Co�����=�%�|�T������M����a>�������,-�zB��s���\'} ~;\r��1�����\"[��[wfH�ÿZ�њ{pb�#p������}�F�*��x�����/�S�����K��o�\\l��J_!�Q*����=��,��й02����bF��	���ݪ�۾9nf��j�=��]	s������/�������� 0�HN�\0I.-��|�� ơ+�k;��A��U�c���9�r.E�-\"Al����mL���σ�:j����Z 0A$\'i\"_ʂ$�Z�v];�s������}\Z�wVJ�4��Ұt*����?�Y��V�Ѕ:>�[�j�x`0���^��1��0d��l�ze��z0HLT����YX<Q\r��\\�K����YtsP��ʻHLQ	ܪ��$-��\n�g�9��c?��\Z���(��yW��r �!�}�f��dU��R+���W���ݰc�)���)j�65�^D9�@x�4���y,��NN]�g�}7P;��k#�k`��Ab�<���K�O�S�=��Ֆz�ێ*=x`���{Ys�������6l���ŇĮ��x����$�(���N���%������|$,B]/��<0���{q*\"n\Z�|���ٵ#�q˃w��v���>���A�C�Ӥ�/1I�\'�-���^�ȟ�j�Z�l�.�\"��X�^�:U@`�\Z��uE��jD�m|7������a����]��7���bV5�\"xU1����P�͠��C�s�˒9��4���k �5�ԇ���5����4lռ�����	DnN��iJ 0Z	v�k����g�f�0S\r�E����LV�0�`WF��Qw�;�]3\"�	��(���\Z ��:�S��W�t��8�,�|��a��\0C��R�����H��X�iPrJ�źW�R3?��b��>g���y�@t\"i�Ml#\'��u�T�I�I�^\r����\'�;xD���_�C�HΏ���g�)���7�l�O\Zʺ��7G=��B�\'1��=�y��-G�Y����[�����K;��U&�q�\r��\0\\\Zxo%X>����B{o�h�9��B�����D�)Hh�Bh�6���t��]p��~6s��X�������E�\0�G���/�I�b���\'#�7��.7\n{q�W�sS�n�vU�R��\nI���g���6���\0��]\0���P���c�w����%�Y��T.��	Ơ�D?L�S��ѡ��\"	V�F:>��d\r�\0�4��%��1��V�g�`�4�;F,��l��)��;}e\':eX�pb�2��Ah���}Bf|q���u�ׁZ�\'�|NV���h��1�pd����o���#�ng��t�|c�GS���ԇ�J�>����u��~3W#hp�!\'~��j�9П<�zgx\"kN�;7W��g�/�\\�耤9�LR�7�q��t�Uv5J�.��	J�q��~C�ώȺ>�M F��d�AbW%&���E�?U�����?�Y\0�:t�:�b2�w6�w\Z�O�ҳB���&��0lc9>�vya=<=$f�|��O�f��eT�Ir���ŝ^�Fئў�қ�� ��4�%��S}&m�a�Ox�,�3�N���VU������2T�Š�q�X	Bm�<g�}Ѭ9�B��N�}��v9�#�N�]�i�	�O�G�D���qL0VF�������kG���K�ЅeӵA|�*U��DJ�\"?,��u>��䟐��?��4@l\Z���c_�í�D�Z���k��ekYX �׷~\\@b�w6&��G�eWm8��zN�������B:��ۈ�\'���NavU&L��sɁ$�+�h{1^IP8���)�~=�r��~\Z/4��ɛ��u_}	�9��\\^j#�N�{i�E���U��#��{��9����	T(= �����|GÈI�����磿7��\'�\0�g(�cQ�g�:���Y�O�WFʯj��Z��b(ÒĆq��W@{����`��	g����]���p@f��I���b��)JL�4V6q_2uW�i[�x&��I��K!�ZL}�|%2A\n�����@�:��+��W�+��z�~��?�����/4��@��Bx��O���5�����O�8]�(\rV bD�9�)[$�.�Pl�T����g���cD=E� l/�h�����/����,���q�ճ.b����Nl�\"U���s�gW���&�жe�E�\n���L�2�,��B�d��w� �n\'w;�Q�O�d�s\Z��KN������_����S\">�}�� 0�,�|�ҧ�l����o�7�D�{��[x���Nf�-1Yy@}����s�\"����������f>t�E��w�����q�9�1���>\"�w��l��?���Q� I���O�?V����d�xY��;=�#��2}*��$FT*=\"i�Y�7b���\n��t���~6�ϩ�{�Q�O�p>��������wKQ�E&�r)S�%�vI�9A���KL��7�x��^qX����E�M�.a��k��y���m��`�LC#���{ԯ��Gn��@�K%���F|�rħc��4��7Q��]�4��??7�ha��ڬD�:�ō��q������տ���Ļ]E�1@x��t9J7I�O��]V|��ik�A�BL4f�:���$��V�U3�]�	#]c�`���!��G�L� �F��n\\Υ�|v���_��8���31�����������kêo5,��iv7a�L%X<A����Ә����23Fx��1a�O-5>��x_��J�����b�\Z�56R�7�u���Z$���Ɍ�(�+�.׾u��y�a���_\rj��\0��;�r灡V�9�~��U��\\a��\n��d�9�K��#q��S��6K�3�W\"�FӋÒ6��v	���V��N�gG%�7g�ԍd|<]�`��	��p�Շ}m5�X��&���W��=&yF!�ߢ�9c�+Qz��;���%g�;5��q�1������8\\طq2o7�\Z����}\'�i{xGv�,�Zt�\"�ۑ�Qr�&��W�5V���;��g.�X�@���L�I�B�����&�^��D��@_\0��������Ի�0�������_��tq���+La1�\ZT�t\n3�x���5�i;�Yg}8��k�\nҁ���_#�ǮM��E�&0F��\\7�k$�{�sa�bc�E�+9C�ҍDG�����Rr>��o��t�Hݯ�\"��*�9\\f�M��TQ��6���Q��	(ݏ�!Lt������z�hϑ��`�7� ¦���o�/�m��_W�������ǰa��q8 �c;�Q�NS���Phl6�{�@����gc���(�I�a�|(�5��?��?ş�8[���3�}�^J�,�c�t��]�ÿZ�p~p����e����$�3��2�d�����m��z��_^{��i�	;yP5e��8N����PF������d�l�;�S�eJ��|K�G��\"c�ѷA^��6��Eۋ���1*pz�����#���e�;{VS~�83oD�X�\0�4�@��n~��\r�<�ڪv(��g����������\'���@\r�O�3��cΚPI�\'6��Jo~��$�7�P�뼸��\r��I7J��6ºU��B�Eq�e3��I�:\n��	��_�휗ظSQ�\'+��6}2NT�H�^��%�?=Q���JK�ھ��_��P��g��I�Nr�i�(���W�m����s8��,PW�3�D�sj�Y�ͧ�=RH3��\'Ωn���2�����7a��+�7^���LUd�P��)�������v���eX;G�X1d�$����̋�y�I� �c{L�2��ա��Gt~h#��熾HV��Xs\n}��N��C��?�)�Å�Zl�찯At��|�)�ľ+2��ԩ�fW|/B���J�9E�$���\"�S�8ի�\r�����D�)|xG��7^���#�?N�O�b��Eɸ�ݴ�	K�W�(�?��r�yI�xe�?✲�i��_l2~����߶���<&����U�vuܰ�G���\r�YN!]@J�\"w��_-I䉒+y�Lb�Er���&L�?�&t9�Rߧm��A�/7��S�x�`ͩ��\Z�����x�9��*�_�~q8)?<��ԏ�3��P�1*/���Yy%rC��XƥF�����Ms���\Z�黚<͋`\'��_���ZT=�ea���Ƅ�,�\'H��F:�t�$`93J�Es$�,ɹY�t�M�����:�|��2��\"��o�ᒆ�Ǵs��Ú�-��M�9�A��d]f��)�9�W#yI��C�#I����>�a�c9�K͇Rq�\"�v��!�v�0�8:lš)x6����Xf�_����w�gC*U��H��Oj^���2m/3Wʴ��5�}Q-��G|&ԟ$.2I����[*/�C͑�����\"|�;<0��7������;V�ʱHp�S׋O\"~�J�J�DI6�	�ď()Xb�nG��n�a6l�|cda	��)\n���@�����	OPm�^o���шu�];�0l��p]�9������6]�)Wc���Nt�T�<�8ʙ0\'sD�Լ�p.j2��!��t�	��#{Ah\'���^���o��c�_��?��o�O|X]]�`X�~�b�_��7�q��(��,�����?�%�1J�\Z��,r�x�4a�4�*3簉=%�;.u*/$�|$:y�U6]���V�N��B��;�C���\'��Pq���r@�]��g�e�H��x�����@��ă�d�\r�a��:!��xU�-`���5�5����_�\n���@��39��x����Pn&h�m�!�=�G��7F\Z�V�q|Eю���ot`�,m����l ?�����{^���`>j�?�>�h��C��B~{����b�l��{����˷23�ͩ�N���`��[��`��Hms\0���w���%���c[�WƟ�|��Z��I�ё_�� s%�)�Z�ʯc�����s��͙Q��N!��Hޑ� �(3���22vӘ����J=�5%��#B�+3��ά5��+N��-�Ecd�]�ca�$���x؉Z#&N��)��CG�8�8��V�)i\0G�Y��^:������^�+9n��g�|���ƶ����\Z����<s��w����_j�`�1:�ƃ9���>)�wn�㊿�>R���/��U��(�%��P����T��K�ן��Q8\Z!b*\"U-�uO�a�3����y��\r�]��h� �}T�F�U?��B]2^�\\��f��\"���o��?����ZgD�e�?�h(�\'���D���d�^�.�`���\\4��z��ﯠ\r���I�;�,r����/q���v�H>.���6>�� Nr���.]�OXw��h�%�Sω(qє�q��#�Q(���%:CB��g�o\Z���U`#��:S�x���� <F��!ڀR��0�|W� �)�X̯�?�W���\'��Pt�M�(�O�[:]SKz��H�|�Z6�~���W�$>��Bdnp�n�-����8��o�e�����1��LpG�B��)ȼ�E��r�ch$9uQ�:�^�q�K%Yt>�I��P$��eRc}����A���T���\'X^]���n���8��X��m���^�C�`����(x�W&��� ���GEr��JPa-Ox��^j��2��\\�U�������Ɲ�`G�㞭G��Ú��g�]��}gSy��[����H�8-�V��ao�+��(� �=�aO����j��g�+�������`�#!V䛱d}�\"�O*&8��7#kc�A\0���8ܗv��1JK�YF���cR6O�����s��ί�ZZ{���d����\'�١nA݈mD_n���*&�#~~FY������I�\r)�I���B����6�F����İ�rs��a��\ry�����t�0��C�94b����tM�S�޷�����4���)1�NY��/��3����F�[��>ouN��U�����j�7�fS���Ta�w�a�wz��K��X��f�,�w�f�]�����2R��)7�-?r_<�s�W�f�z��̤�a��ز/�n�]��e�H�YY�O��A�\"�]��(\0�.����x��Z\0��R�qd>�Ϛ����u��/������v�_nz�L��s-q����dw8J�\Z&��u�ã\'�߼�MO��&�g�Z۟m\n��o���m��ޞ��İ��`���`g�z��67!�\'70�+Y��5��b�^�\n�;��O�q����c�1)���?����mp�s�u5��uv�ݵ@�D꽗�*�`-�]@�� �z��g��mI��77���?�w��z�~n���5�dt|ɱ#D�U����\"e�]O_\"7L�uY��^8^=����	݈����Ͽ�{4#�xo���O���\"48��o����/��p���ObYsj���\\C>���1��ju\\�n r���FI?[��ݞ?#*��D[�m�k!h������;�����7���:�G:���2fx���~;��M!:�ӹ��FS];.)�|Cv���C�e��q����=&�F���G��ylÿ�l��\n\'%h��C��C�7�F�R���dͭ�X���G�|-�+�Β�������������X��l��֟�9/Ma�)�Fޅ&4�R�v�߇c��4��2;��NZ����_�Cߘ�l|1��pGF��0�\"�,�q[Sf̽����ї��%�&0ϕ���w,I��x/���:��e�E�ߍ�+�J�W[|S(�CX��P��7c�� /���w�f+�������Y|\'�%/�G(�:���u	.:a9!�9	�7�#�S\"*��t��|�f�\r�-Ή��Ό	�ʌ\\����ϧr^�={-/���W�Α�����N��<�^�7&���;v�Es�����R��=]��8��n�r��~!�n�	���38��$���Uu�֭��O�!�U�.̉t�:�ؙqA��Me�3Cf�����4���>k��gAGW�eAn���\\\n�l-Kjo~�]1x��u\'��W�A�Źu�1I����7�M��dv���{���k��&,�z����a�x��w�C�N��I�A���+�@��&�����K�Ǿ���\0.�w�����#�\r��\\���؆`��K+���s����kD�׹��9\Z\0��{�UmkCT���Ĉk�te\'���M����S�z#G���HOC�1�����>pT��줴���d��_�����u��?�c�i��+1�T\'�_�ց��a�_��m)�0��Xώ����_7c�w��n��\0�-��,�z��̃FuUG�X�Q�ߑ�wД\ZI��{�Zo3D�Uode�\">]��q#$y\\{���re[uF����?,?��*x��\0o[ip��\r��f~:-�Q�-��ܯ�˛ �4��ű�V��V�A}#�dfa�[_\0��ऽ+�F�)?�� ��������V�7;\n.���w�i+|��|Mρ�޺��f��}}�Us�b����9��Z��2irk�u�<L�c���F�+�X�KS��)�4�.�۠05�<t�U�cE�Ǧ���ajਲ਼��!�Q�#@�Zn�;n���q�?���ɻ	��:pMQ�U 3�<��<\n���d�t���s\0j� ##��2\'?ds��	x\\��\Z?B��~Սh�鿁���6p\n���H�K��(L��k�	B��w�5��������k{Z���Z��uh��BZ�Ni��ųP��<���<�耟�,�˻Y�-��i��LS��a@W\\)�p\'�3�������]���{���*Jn����\\��ޱ�;���!�x3p��\n���rRhzzb�깗����%��;P�v@ce	�ˌ[ɮ7��n�� �Q�b^��e�ޗ�E�E\0CsA{Uf{��~C{9W����}���{������\'y]�G��\0��/S���gL�/�),�2x����Mo<�/��k�}n�;6d�~�+!6�v8jo��+���K��˃��Z��ٔ�pT��Q�PU����ұA7ݟ�2�������{���?z+�gv?��=܎z�!7�j����v��B?>����S������:�~��A1��(���q���_� �O��WAuy�i��iphcC����{	��ESz��w�iEZ,8���<-Һ�(>�(��C�͡_�.�G#hjb�\0N?��Lt%�Ony9�1��mt4C C��Q��[!|�,���P��ue�1�Uִ�8ʒc{�-�B���3	a.l�P��$n���;R�^�����lO����){l�������@{kL��`pT�RC�(�߾}��:C�V�fAy����`q\nBmPn7Bv�\'�2����触:^�ٷ��Yw\'�{���7/ ����ݲR���mZh������BG����t��7bc�9;��\0O�}��~��Zg5e��S>~��/�q���,�$A�=/���C~���F�GS�^Ʊ@O�w���R���l���\'lڋ�x\"Ҝ�#\\W�0L\'B狼�X:����[p+�\0�;�^�����bh]��U���c\r6�v��j���l�z�_[PƸx�\rv��>~�Q���gxR�LN���jz����U<���w�ͬ ���I՟뢸\r��Vhm����<���nq� ��];��+����ޏ��0�+��ب/#��u��,���\0�p�����f���Z���=�Am5�Ip�w��8��6�2Q���N�~j��xY+@��R��֦���>��[����\"��2�z���k\0Cy�뽼�1�Yz�\Z�ў�4�U�i�����k��C7�U�y��u��ݬ��Ȫ��O��.\n�V���{,�O��4htG������@~�A�\'��!����V�|h���?��D]m��P\'�w>FG^��,,J�#=�~6��-܍������\0�Kg޸��t���w��|�����`�����=}�!T9W��\'�ڠ�*lW�v5���������࠲�������n?�s�����9w�����G��-��R\0�2������vg���9�N��!c\\����m��|Ȳ�(W�v港��o{߄ة���)�ގ������s�K������Zʮ�n�wh��Υ�����G]Pr\'۰	�ݽ\Zۗ�I�j�٩�v2�);!��{,��k��lw����	ec�,	7�-���\r��hgL�i2$�|M}Y��FI�>\\�P��}���\0�����?�o�x��n�;t��A�7�-�;~�\\\0]$������`˫��\rSrny����S������^��U��e������w���~�N�4W����,o�w3�^^S��#7A�ަ��1�_ɉs�ϋ�b�KW�3t&��ٵ���b;8�솪�iPv;z��5�o�����b��}�+?AU]6Ԕe��&�[���̬�U���ʭ�V���ՙA�q��²[	���i���?l�zeφ����[�n���U0�	u��49�fI>WOՕe���v��޿�7;7\r���_�3PU�%i�`���E���d�M�S�v\"/n������\\\n�F��ho}H3X��@Y�g�d�ȏ�OM����\n�ZP[���e�6�6�<��r��Co���@kI47C��ڀ����M�y*l@{k��ٮC>*��X�y�jq`���ه�L�����.�m�P��0H�\n�0����(�/0l�s!3���a?�M7����~�q�1=L�%��g~m��׾�\')[�s�D2!�V	|-��ّ�~�2�|C�}��+��iZ��U�X��s��`���^xn��#�m��I�r�O�u\n1���f$�}��:x�C�z\'�G�1?�<Lb[�@����t�/�?�跡O�瑟�ºۅ�<����	��c���Q����6�����{�,��z�~����CO�F�]�~o�5q��K߿�h_���ix<��K��X��t\'�_�(7�e���\\B}t�@p\\�QM�\0��A�ӫL4~����g�-7��6_�cD���<�n#�06HzW}I��(ǋxok2��x�5���Ïb�/\'�:�w0<^��q����3�>z�*�����g�п/����By���\n���P���������H���a�ؼ]�\'������4��$W��HG���4�� �m��X��\'���\0ۂ�@ۂ�۬�X��wۂ`:=?��</=���_|�R2=ԓ���d_p���PοC�ciW~:�Nq��O���\0���me����dZ{M�]�]oۼdۜ�k�U=%��%�YAN��I�vMw�i%��l��l�>x^#/݁���ʏ�΍���Oq�-H�t�O;��E}{aA���\\F^�&��O��w�i4��;�G3�R�E0Hٜ��*���Z^��Sn��zQn��qġ�j�#��m���83��O��:�Ѝ��fW���w���[N�I�v7�v�a4�����ej>W�+�㐟�c�b�w;�6�ߎ����P\'Y�l�fO+��dW��n�萟�gZ��mM����X`o�RAG�Аv�Mء�`�<���<��|s�u4��Έy�		���������k(��\n�y0h���]�@{���D��7��Ykc��T\\�����}a�w�B	Mz��C7�ZD�2n.��B��Y��|S�|.��Y[�ԁ����������{�IV�6Sv���#[!�	���L����H�\r\Z�����ʚ�/�޾�?\0��ѐ\r%�sa��;��6�kbf1��L�C��\0$��}���)rYdK��,���C���s�翁W�����i\Z�\0΀�z����h�h��`��?��~����zЃ�/F&*��\Z�1��-1QPI�!���ҭL�u�C�\0���3�>y��o�O��O��%ٺѭ]�%���)վ���j(۹����Mw����׫�,��}��a���,ճ�����N5h�ӻ�9!\'	eb^��&K\ne4)�96�J���MS(�%�1n��g��o{�퉴P�i�L��\Z^�M$�5��1S��P8*q�>�t�2�*oW^p.����)O̽Sdm ��F*����%�3i��~J��LY�>WKϻvP��Z�~{�W�5/k��%^��~0ڲ<}�z6~}���F_�����f�P�}���lc���d����q�H�m�p[i���6���9Wo2/�Felv��}�v��LEx.����9#��8�}2r_���o˽�ېՇO~��kp�o?,���PY��]g�{O�L�.�_�!;����������t�P��`�<�V��f,���A�宅R,�|^;�+�9x�&�ò�כ�s��t���[�9#�M�}��-���s�׿UA�P�n=�2���ZϿ\\>.��;G)y~#�^����j�n�FO�{�\n��������|��	��`�T\'l���O�sx{Q�;,�񂼗�#�\'�^�ѼsK�\\�s[��8�#����|�-q>�\"^Nr~�v8��E^��o:4:��g\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0�?���)a���\0\0*mkBT����\0��\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0x��}+��(���H,��\"�H$��\"#�X$������,�Q������ԈZs�>U{�	�.�.T��}6�\0ڳ�-��F`���p]�k\0߅~��b��\n�\nО$�wݓٱ����|s��Co\0���A+�q3��lO�x�@�(�0�a��+?�	��T,�_��7��s\\���Ϙ^Bl1)�C��+�k�(�FyN\"8��dPC�_9��>O0&l�4��Im+���n�w��G�rŰ����<Q��q	�	+����H�}����e��q���~~�[).�5c��6,�������m�uO���9p\\���<//?����N�:��Mp)� �Ĝ-�2p�\'�uKq`���_������/���6�4<~\0��77S����N��BQ�����맨�uM��{���5�%.B�NɊk:	k�N��m�9���*�u�U�|2���%;������]F�aג)��RE%HWc0Mg�>��)/tih�f���	ѸX�>����E����)��<,�6�s4����5�z�b�?��J���\\<OM%O#(7�6�:�=	����ӋYA��H\r���L�s6��M�X���BcX�&ǘJ�te�.�����	3.je(��?�<?�-1�$p�O=\0�x\Z����	]<Jt¡�Vg��`|I,<丕}�F�Qj]�o%[Pa���6�XY��<��?�Yoh\0�F��067ၭ6JF�G[��wv)��7?,�@w�\n�nM�Ǧ�m��k>?���L�j��=���%w�Z�izFTx��$��kP�8�E��m��	jAO�����ހ��>~������؆���B9���	�֤8U��KC�v�jb�L���C��y����;�mjP.� ����Dk���w��U�E�3�ܨ�����8x�U��J���s����\\���ɟ�+;}s�F�Q(KI����Xݛ�ƨ\n�1���+K����dX�];Jģ��c�x$��D�׷���X`i� ���@l̏�rn�m$���^�9΄�zBGϞ�Q=�nf�k�D���e;\n<���a��>,�⢞�j��k�0B�[p(��$�\0��Ǡ����p�4n��q`�XƓ�	�vϵ���.x�Hn���or�J���5�����H�u����뇗�f����a����[Z:><�M@J�9����$�q]�\0}=H�k��3�����鲺t�Q�=�,	7���߻����s\r�>��3�����6[��g���RL�؍����?�(�&w�.7C#~B{�]��\n��U�W�7��1jk~�e�cG��r�����D�.=��K�����@�W�ǱM�0倐�����0�\\��x��v�q�NZ�>#�\r����BE�	��)���&y�A}t�?B��Y�m(�WIp�ɱ���|�2�+���\\2�� ��)�l�8��tl�@Z.B�����e񅋍�RS��ƃm>d�I���l���\'N\ra�dĢG3�%���#�)?��$s�	_5=��Y�BR#-k\"qGP-�e�\"�f����%֩-ϓ37�����8�M9��ϊ�,���_*n;H����EBƱ��cl�~����\r˝[��/sa�g�IE2�,z�1�t�:�kL��������ș壋G)��{7�o���nd������{@r�P�>�k�w�k׽��#�kXfy��E����A��B�9�uM���4P=�_�l���gW��؇�N��#�_n��G�pp,Z��Uu�6ȓ��V��Ӱ��0EK�7*|��]�{��75F\\�Զ��zQ��z!��	uH�>���up�����T٣�o3P)���[�^�6�����` -�d&�*=�%���fY�<�^��ط`_6����|h���3ء>��2 P��q��7ώ����,Ns�j�F�=B���`�큳�C���i�U�)R鐏@L��Ү�����ǧmb<2FH�Rq��ùF�����X�i�䎲�Om�GA�����}:�*\Z��u�f�:@ʫRH�.��6���6�j���c�GOpO-\r��6H�����K��J��U���:�Jǃ�����v<gz���� ��1F*qm�-;�\rI�\07\r?��O�(Yr\r�de�\n��F�\r�	��ѥ��r��H���a���ۡ�>�\0,����3��D�Z��E��Ʈ�qq���7p�?��Ȍ�K����%ȧ$�;�?�Q�r�6�pP7`�a����^=����R�_����)m���>�D3#£�_\'\r�I��ɭu͋C��-R�ne㯄����ss���L��<ȭ/��R)|Lt_1����<u�}E\nD�zl��$H�+�N_2�scۯ-�rH�V.�����\Z���֏\'���(}�o	��:]謧�6�Fhlw���@��z�{6�P_�?�\rE����h���߹���v��K�/�B�\"M���h;������б�o��)gRm �$�5�, �E�x�(?�:�g�U뵅F�4���� 	���߹�E4��!��q?l���A����Yv��s:mR�(G��Z�y�Gq�+w0)Nz����u�Y�-�&�����\"�Y	=\'I����8��{��m�L/~�����!�����.�B�����A=���缱Y��|z��:f�#¬oh�2Xj��ǼI|1��i3A(|��vf1���\rNK���L�ͫ\Z�.����?�r�]�qBS�^#o��.l�%z�⁋\r���Y��~i�䔃P�\0�q�u&7(��U;B��l zF�x׎����M����,|PfV�֠�k��\'�N��b̔/�$EN���\nHA�i��Q=�u-/T�QAD9����g��W���%YZ�\\���aԥ��5�O�jr�����u\"9��B�zp�̬�vl��l=��ɸY���y�ܾ5t�����mE��z�+���M���>�L�k�=�rr4�����/g��E�r��~P��nB�[��\\g[{����g\Z��Y�vR�W\'��\n{Fe�m1���{�w�L��;�7�&$���x�c����0����n�����&��u�@5sC�Cձm��8H��ef���t��<PJZ��@����������4�K|��#`}a�kRN���\'�~IU!�k�W��L��Z��D�NK����̡U��������;��g��L~a(]��!Bjv�(�f�������\\��B�}�AuH�R����\0�g����\ZM��<7�O��:���[�m6u�v����;3��=���w�w�n����������3pK��M�������{�.\0t�\"��nt�\Z?��di�b�C6��=��E	�����,��ѮO�\n���0�h�v��G��;=���MV%����ʪ�r��\0���4�H\r8r���K썀�x��A�:�2\r�e�.���ݟ0N<g�����\'�����6��%��G�1�ַm}�^j�n�ҽ�S�0Cz���LX�3���U���M;^��^~Xc����a\Z�vGHu\"��\r1��kN�K�T�?,���r�=�܎�X}6CBW6ۻ\0�F��\\�3�m{4!]9�ử��J4n��5J�s�w��^�D��h����z�������8���P�]�z���1�x��~\0��J8#c�%�Ͼ��cF{d�����o��@w�0�QsP���_́� ?3yB2Đ{|��5����}�>x{q(a���тa�?����Q�%��l���4�ςxmWI׆�G���C�\Z���1���k�Q���3iJh�,�������\ZK��R����������O`���ʲ���<!�[��Nw���a�����Z���x�\\Rtv��^ZJ��a\\(��Z�PE����� 1��ޣ�h�����y0�S\0�L!�y�QP̞�#R@ӱ&4�a�9\'2��ċ�I�E�8X��Ir��\n4��*y��b��˼�\Z/#�\rx����;�2R~\0������O7���h�՘U��^�k�\r����(侠,���2���)�C�:(ِ;�Q3>��4�)�%���b6�B8�\\��\0p�����e<��S������+�js��p����%<&t{3?���|N)p7b�����?�a�i�D�Wl�����X���Z�>;u��)�ko)#W���S�n�cR�x��{[�sXv1��95�_�\Z�0K�����ՙ7�>�\0Tp�5���ٴ�l\Z3�S�\"؝�LX��睫[�5m�����Q\0=\"u}���pϘ*x�b�Չ����#iM+��@�Z!�	��Ϯ~j��Y�ݬ����$?5���mt�u�] �%�@��݅:4h8ۃ����tu�3�;�\nΑO�1A/r����\n��R*5������i�&j#Y2:�$Z(a�d�@�>\'z\n���L�����뇶��6Z���8|`�6�\"�X1�_�z\'\r�F-���я�?��X^�A:?1�;��h/K�VB\'��vOn�FS���Ƥ����Q{=kh7��M��wXQ�p�\\v�͓�O/��.����\n�N3��HKR��l�K�\"�q��^W��h��1wt��h@���3�e6�N|������I;y��?8t[�[�!����$,ήL��e�\"�z��%IކA�k��R�l!3u�8�ځy��?_�W��)�AbC����O�!rz��a��5S��n֗���#�<�43y��6\"���R����߃C��Q�&>�[��#\nB\0H�ǽ�{v�e��kO��T�lq(�UH�͵h��ݔ8�,@t�����ՂL�{p����/�*�L\"�d_y��k,4�G̖��bD>,��.ok\"�D;�|7�[.�D�C�A���#�i���l����ϟ�I֬�����D�q�]+�eE	��_�--����ڰc�����^���L��q�1~�C��C�����C�9��gN������\Z��H�8Bkh��J��#Z�-`�V�o��M�a 9r$\0�պZ-�h�kh�\n?C�$�	�^��tď��9d(�8P݅]ڶ���w[�wl��;��d��n�׆�o�K��d�H\Z�ބ(D������In�I� M���_(\0����\Z����5)6H/���Y�1�� �QR�k,n���XH��ʉ�����?>��df��&6����^EJ�m���t��{�C�����C�c`���0ʅv5��x<��\\9Y���c�����}1�06\"״!֏��9�dl:\'��1H\"�<HN�&]�5���6�9�!I�1;\"����YxA��K-�y�m|h�d\r�\"]������U�.ak�gbbw24�������j-� Q���\0Od�-���:N�	dG��˥M��������I	V�G=�W�!r6�w�H3����p\"��ۋ����#g6*x�9��k{H��<W�����BQߍO�MV��{Kh��^<�F�W\r<�L����:w$|�oY��-Q]<ʫ��!�!垹��F�q@}3f�R�%���oĿM���r�D����+�N|�Y�Y���6�j�r1�1k4��i\'X��f�\\:�e�޼� �~�P9���1�ߍ��\n��&7�8Q�ape�������5 9os�M�y�	�K-��u��u9��Bdx7H�V����&�_���!C�lgL �04���yS��}|�qٳ�k������b�s:f�\'/����㼳@!�]%���z#�=�J�s�`3�W ez<�PIG�C����0�@�4�������5�5g��x�c��T�G���U�#�R�CC�?tdx���L`�Ɓ8����dgsT�?M6},_��� �\\�k٬���lt΄l�s��:m\"2��5�be\\]\\�˛��{xa�Lo��Q�lPwK7���?M\0^a,�_�lb(��1�?�����3��݌^7���:���ރ��^�us�ϚqB�8*���h�Gx��Y�C�m5�M~�{Sg�9n�RX�C}[����hO�tC��1#W3�*��:;�&_�G�ۂ�&�H|������5�L���<4Ƀ��\\b�������D?]fM{V6*�S�<����e��0,�!��\rA��ؾ�������K��m��m���ߍ�r���O�oC������2�\n���#��p\'$�F�˿@!�{0�V��YW���oe�,��\'��H\'���`�r�1�����#�ͿMRS�\Z�Y����ZB�h�|�x��H�@\r6�YziWl�wQ��}�yqs��!`��~y#�-O�Ց����I�X���m������y�����|��*0o@��]ۓ�^(`P�q��v��ef���v�\'�OA=B����݂p��C�J#\n��֞����q��5�\rR������wV&�)ԩ��n@po��]��{3�v�:�������Y���f*aW��_�&\'\nJk0n����D�x���\\/H����D�u�qZ�\\ڌG+啵X�Z�T>z\'7�Q��q������Ɍ�#K�R.�/C��V��g�Q�Ȭ�����\\��`��?d��1y���uM�6Ƶ8ZX]8��^p��wQ�E��\r&�1frR��Ki����$G�����ݜ����Е���h3\'���������{���;;�~F��K�37�k���u<p��dʎ��+C�����R���Mz�Ə�7)n\0Ҁ���� lEGy�l��:̑�I���o�B�<A\\���\\6�d���F��q�ϡɅQ�[�1<k���N�>���S%|��Е�sTu�le���b�A}A�����ʹ�1��0�A{�K��ʘӺ�tj����dLI=r�	�PRg����_Lb�R���\rŞ�l?�␔�)!��[��F��o��wi&k^�CV(t@p�W2����{h�x�H�GRn�͉�eCb�xԉ����6G�������Q��d27\\�ثd�S��=\\�F�f*�0�ۣ\0�OP���5(r�ZߙxQ�Z>�~G�AeN-����jY��7�Ҿn;�n?ӹ\"P��x�}���\Z/�N��\0�W:݊&��׾��:x\"ꭥу;��R�펔���c䛅љ�������ElmG§a=�h�¨BG_�u���YnZ쫭FYs �U�\"zM&�:��Gn��u�.�DX�\Z��5Xn�����;�}�ԫ%XO?�~2&����Frjj���8��yA���*�W	������I�����9/��u�b)��Z�l:�s�� 8�5��J��>~�i�������I<�k��¶\r�٤�^�S�x�[����s��GD����(�\0+��\"E���HnֆA_��\\F�Z���%������?��4`���w��_{�7��\"��0�Y��@�f}�������PEj�m��v:�Q������rN��[w���z�*���5�c?�j������f�7���?K_�\ZP��\', sZ(oT\r|��Ó\\-%�蔒�h���y������\\	cK/	˧YGԻڐ����z&c\"*�(,�����y�E�q(�y�[���q`�a�7Xļ��~�����R���/��{h�h���\"�g��\Z=w���ݠ�՗���?����̶�uNh{�g��?tq���m�,�u�[�Y���ot��+�!�hf��.2]�ݹ?�&��wA�R���F�ľ붾Ue���%��d��l�i�����q��Ms&�6�X�w-&�Y���3(���G9��{cׁ�֬ǿM��;����v����n�\"���b��)�<�׾���e_�1���p����}��11��F#��YX��p�q\Z]��s��,[�%*&��@�D�f��ҹA�ٙfs���,���>��3Y�ԕ;�:#hEL�ם[ROd��^G�A�˩f�~Y!����E���n���0�~��/�A��\n�K�m���>^��WY�q�\"���<цF����*c��:\Zx�w�|�͞w��%�ehRg�������d�9��̕���v�3�v\rDg��h�>>?��3�h�YDk�gC�(ʹ�ԕ���S����Ԝ|�\r2Q��94�(�?OG�Q34�\rf�cc��PopT�Ya��W(�>��@�t�X4�`�LG�ٞp��Ʉ�a��Űl\\�[9�c�26��UM6f,����\0\'����C���4�i<D�n��#�x��г\rHz5�[�\n�_������Qt��m�vN�C_��`��x����~\rMb\rs\0�PEx���؇;���cW��*n\\��?���׿v�:O��3@f����R�&�e������m�[mٜC���5f(�M����Ni��YX�xШ���=�4\ny�HO�<�0|���3����[��B	:d1�\"Z�O$+Kx�i̒=�s��J����g���~�i[Rz\'����G�#�v��}�>�?W~p�sϠ?��k��A��K�rŵ���k@�I�|>^x�s�?�\\��`,D���̒�����5��W����^����w�D��M���Xf_8<%|\08_왉pP�1����W��lm߃���f?4����:��́�_�Ԕv ���M�;k�:p�����_���sj؎qw]$F��}���y�\r���,b\'��N���=�o�����0,\n�������~��M����\nY�R���4�6+!��}@~u�j�ct�C����P.�Y(�x�׎����z�?70�WXFܣ�o�����3z����0���c8�R��G��g�0���T�U�\Z�򄽻��w�\"/4��֏�����C�Q`[{O���c�n�]��+�{�{�����N!�3��<���V��yx�,!C\n�b�.��lf�����\'���\\ ן�����gu,μ���w-/��3ۥ����N���X(�c\r����o�MD�s��a�#�#0{c\r����%�uDWCB�Z�A��Z6�,؏��x�(Z%�����w����HbhTb2��<$��*c���nk���_�א�����#{D+B<�!���S/�g�Ï`�9��.^]��ß��C��+>��3�+��5��]�q����p�j\'\nr�9��FDȬ)~:�����9Gm��x2���-?s�raG\"yvU��pa;R�����ă� �A�\\&���\n�?�#��n	��0�ee����d~o�q嶭�!\0!ǲP^H)>�o��ȑ.�ļ�Զ=Hy�7�S�-M�\n�?���8y�c���ߧq�|�#�5\"�2Б�l�m#��U������e�Τ�V���bM���͘�jA�c7�Z\n�]>4�gb�\n����s	2WRsKg�6���\r\'s8qz�TT[�R�[w�\0�)I��9�5x���Wj��\r#�!nN+zP��ڔ�	�Kg���TE�,�����?��{�^R�Dݥ=�R�u^zîc������&D��\'i74�S�J�ߔ��&H��U�G�[���cr�ͦ��<����׿~��4}څ��h���;���lpAZ�%�X�Z;t�Q?������y��k1+Ƴu6�[������D��c4�Ɯ����*d��B#!}��e>�samh����G3c^��8u9󼵕⸈߂�U�y��B;f\"Y�i=�D�=����4��&�����|�C���3����g]�~���WgjhSIXU��\"1A5Fr4�{����A��lj�w�T����t6<�/N�� �\\����R�t���a|�i���>�T.�Wo>>�x��ϯ�Y���{緷\0m,J�{gg}�v~)�]��s!?w���X�����G�F��l!7��U��|Cn�fﳅ:.@mq%��臔����Ru?.��:��aB�ֺ��E#G�g\'yX�D��u�SW��ǊD)��21�ѵ�V��agW��P���q����Ȓ��s�?¶�@�g\")����s\\�T���{��f3g��o���^w:^�\"\0��{��d#�!φt�}�,n�yWFKv�X�4��|<��B+���8�i=�-;��X	5l=/xl��w����n�]� \n�+S�Ӽ,{՞\0�/Д�V\0���+<<\r�����o �����ԇeNp�^O������OvqR� �wHF3�݁�=o��;�`~k�R�wC�����u¦�k�jE�|��qϩ���KV,���*?���xk��}Q�x�U���/M������=��հp����=犐�^x�Bˏ���Kx���@�[���I���YB]T��➐������Kq�.ὀP��w����AG\\��W�ϋ���9���2S���A\\�Y\\��y=Ǩ�Gj������բ�M�@\Z�tԂ��vD���z�+���Bĺ\\������լ����6��k�6L��ʦ�R�_r�n�l|UAϯ<\n���|��!��;��8�_1�g�sލ��C����� >�VB�~�,����˘_�&f���jp�/W�ԍ�wa\0�O ���H3�����I`���u�����1�ͤ��������+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W��|�+_��W����ݚ�w)��\0\02iTXtXML:com.adobe.xmp\0\0\0\0\0<?xpacket begin=\"﻿\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?>\n<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"Adobe XMP Core 5.3-c011 66.145661, 2012/02/06-14:56:27        \">\n   <rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">\n      <rdf:Description rdf:about=\"\"\n            xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\">\n         <xmp:CreatorTool>Adobe Fireworks CS6 (Windows)</xmp:CreatorTool>\n         <xmp:CreateDate>2016-04-03T17:42:39Z</xmp:CreateDate>\n         <xmp:ModifyDate>2016-04-04T04:59:35Z</xmp:ModifyDate>\n      </rdf:Description>\n      <rdf:Description rdf:about=\"\"\n            xmlns:dc=\"http://purl.org/dc/elements/1.1/\">\n         <dc:format>image/png</dc:format>\n      </rdf:Description>\n   </rdf:RDF>\n</x:xmpmeta>\n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                                                                                                    \n                            \n<?xpacket end=\"w\"?>�,\0\0 \0IDATx��w�]E��?s���7��dw�H\'	%	 �ЂT�E�U@*�DPTP����Hh!!i��M�^o�������XĲ���9��<g��Ιy�y�#������}�.����`�ٰ���^�\'��^g�Xq7�q��,B)@Ѓ��S��.vY9���E\Z�J��n	�+�Mk����o�&�㾺A� ��}��3=N�}��~��L��Q=.f�}���B+A�HB�x������G�����Z:�\ZAH��[�Q4TdP��J��v��t`Y�-a�\Zh�C����}����$��!Zp�����1��HW�x�v�t��Q*$�\")�Y���V_�`�h9� �c�+�`I|<�\r.�H;\")�M�$Ua�H}�[Z�lV�:���Q_j���`{�A���@���ß:4�~�9�u��P���E��,�	�Tq4U��̈C[�@7-ҊN.�T���\0�/J>��9&��QcT��(�<�	tA�8�N�3��qҪ�1SY��]5��C�����]��0H�q�|�t��;�+f��=]�V�-�t�X��S5U`\n�����	R�BWP��L�+.Lt��ƍ0]�@(�	�\0RO�\"FoV`�:�2��8�B�ϐ�\"���^֕M�7�Փ�>��y�U�t}�m5��A�����>�\'�]\\�x��yQ]�qq�\0-ت���ݞ��Ml=�ne0T�H$M� t!�}�b l�,�9B���O��Tq%䥉�Г�q|�*��AT�`��;�8��\'��K7�k�޸�!��ڸc3��Կ��/�c@�΂��5��d&{T��Ɨ��RG��\ZYa���A1ۉ\Z�H�\Z�r\Z�|��\n~�((y�K@sA����zU\"\0��⁧���]P�v��lN��-4�\nS������\r�D���K����&?s�d����/�;w��8b�3W�o{鬲�NT��X\Z}�F�T�\"EbF+q-�bzDT���T\0G����\n�R�CE� \0�W�a�t��A\n@�\0�h@��TiMU\"��?� ���D퀼^B*jؙ�I�y�����~�cl�A��D��++��B��{>�h�hfvcD,\\ͤ��$Rm��,M��PN\02���X\Zh�R�og��j>��X�~�D�,�4v�A&�k��#�E��Ŏ�+(��0�\0J\"OP\0�,J�|F����otЧn�_������*N_���Eږ�_շ	��Y:\Z�(�,�D�X<�V\0GU7\0�+�� ��W���W�ASC�\n$�����ދ�̃���~��\r_�� T(� L�������b9F!NU��S][�WU��1g,i:���	;>ֆ�/� �?F,�۴��w�������rj)�!kc$�v�1���\\��T¹t.\03\0���\"\0�4P���@��\nj��q5O�h*膇�J��l/@Q�jD4�& !b���& �#��DA+�y���z�A��B\n�*���zUz��0ᔅk��c��^�����\'�Z�٫�ΑQJp�L\\��Rju��`+��8p@с<(��Ԫ\Z�Q��N)\"��Ux���^��b�i���W�X�iiWb(���N\'&���zd���l��RL\n�)\nxZ�\Z���o|=��t�>�f�ST�;K饖�t����������ߞ�x�Us��Wb���|X�.�k���Ϸֺ�#5�����\'�Giy;�ң(@*��Y� (�0@�Cg��킢Aѯ&�\r�qds�|j�S�O�r����{�)qR�f�/�rۨO�WO�lyF�_��\rGg4�� ������B��0+N�D%��j��@/@�_Fګ!�#��Q��!��������NS�M�������i����f���Ra��%��\Z���T�= ����B\0F$$w.��\n�E��.����w[*/8�o[ې�4�Ȏ��\0t|HSc-�Rv��߫Ǖq��ʩJY��殧1d3(�T9����C&; !Cg��A�v+Ð]I�Z�%U�Hq��_�}�w����\r:���A����-`�	�~$�/^��W�n�bHqu��k��F_2Gy�����VCg�)���[���Ƀb@�Q��\\u��H��R���D�%�F��\'���S��^)L���\n_׊+T+�����1\r�.x\Z�D;O�n�t��2_\'Z�i����3���I����}�D�_(�@\n�m���Gϟ:6���d_ۈ��b$�U)����1���3��A�P� �A�U�E�����c4�UW��tة��*m�4����6Mk���^e}����\"ŝ�ie1����8�]s�vt�����K�6zh*(L�u�_�W���:��0H��c-�+7�8Bi�`ؐ�oD�[�l�&m��+���ܭ�}�j�J&�!]ѻ�G� �^���-\"�>C9u�v+����|��~��9����t��ĩ�]^��e3+���W �$ף��9ؑi�\"WF��M���w�q�Ĩ�=��͔(��{)��$���]3릌��Gƣ�������!�<���ۙ舖�tWY�[_j:�Vr;���*q�CN���o=�J�����Yj��[e,{?�L����Z-���_0\"�E�pE�M(Bz���l^:S�>\'v��٬d/Y��n��3��A�/���x��3���9%�VL����yǃ]�#��ĊYz�a��:a��������7��!�{�\0�?@$���ʋ�_n5�_��AM��P��2���	\\���]LWG1vZq��V�$�h� �	I�+P�-R��B�9�C�=�Q��^|������*�l�q�đ3��:��Z\r��S�S�_��l��-���c�����v�mp\\gtem����O����������}�o�� ���1��\\���;Ɓ�/?���pc�y%Vt!���<a8��@:?���5Gw��n�+��;�&v6�\n%�g�����	�j�^�~a��~�b�?��ۀS����Է+&�?,Q]�k�e\"���5rZI�ؾKK�Jm2Ƥi��Zy5t�iv�� cN$#F޵>:��f�d�\Z4��!Ӕj.:z��ݻ���5��o}�s6���ڗ.�,��<x����	����략������ӽo�U�9��Q-����^�i��#��ޯ��ko]���W���ze`?wVIf�)	|p�0Զ����R���H�:�z3�-�q�\0C5H�|���U�s��Oo���5�G];������]B��\r�w�\0V���+�R�}?i��dt��2�޸�[�M2������U���\r��5���1;1�. @z�+�ZtƏ��������G�� $8���l�\r���9���1S�:����Ɔ���W��n~h��#[W��LGgw����o6e�C�\'ڱ�{ŮU����S{�>c��C�9?vޗ����S�.��v[�8��۱����N��\"$��I���J3���k�UҶk����?��҈�nBxbI�೻|���A���������a��D��Ș�xe�m����a�K�@��RMh�S �� AR�rz�m	�.��z�������@�!�6rj�	Ma�U�w�;��p�<�O����<t�c��}����y��#��:�=j�����q�sw}{.�	_�����R���w���F�r�Xq��$��4�3JBhdU�3I�i:z���%�bz\\7�1��f�wږ�K�����cg~�����`����ZYh�a�]�\'�QHD��0�� �y�&8zx����t\0V|�t�Sh��0�Лg�=z҂��P�%�z�S���ʹI�����Y�~�c����hߺ��n�0��>�?�__���\ZG\r;sw����2���X5f��7��Y;��nh���D,��CvP_����]TWnaTe����f�1��H���@ʹ�(��\'��Y\Z?�M�m$����[�,m{��UٝJ�+�P擌5Sj��$<�?<�?tU�H�?&<\"¬�<�S5��W�x�y���>P62-�=x{y��K�j����:�q�OO�o��Q���<׽���=G��׿ʦ7���?<4��sw�����V>f��Cʼ��������?��\Z)\Z�G: �0/P�/��\0S8���-�B���>���%U�]��o4�o��@�߀A��O�Y��+�����L!��B$�\'pA������_*�e�Qw]H�����#�/��l�y�h#FT�YQuDI����n��^��5��ξ�}�m�c�?��7�\rZ���T���Q5�\Ze���T�_^3��髩1�8�6Κ����G^U&���`8 �0u��t�#0D�$��A��!�Ayv\'�;��⮕g\r�m������w���x��y��7����G�	����{w=H���T��R�\r�Ύ�5ٮϖ�|2�2��Zb��t�|n5c�]W��c�1_���$�WW��^��Q~��C�j�`�����{{y�u��ٴ�b���#FL��@��J���U�;���1SƼ��o\"1�W�.n%e0�b��\'�1��7��xQ�n6o�恶�o���.��t����D\'!�<(ut��2�����\n��3ĕ<-�^T��Tv���^���_�tSF�ۗ��\nv�J\'��Jm���C�����]�� ��0��􀚆��2�vC�\r����\rrH�o�^1�69P��7@�@����C��Y�R��ο��x�5����x����u�� ^�̝cv�����߹GXec�x�k+��T=B�A ���$lUE.%d�� ��Nz!T�p�H����	�\0Eh�9)�\n ��LUA\n.��D	4� U�G:�)�t�X��͓J[�Vj��6�X��AK���QIG��ՏN�L��{]9n�ԙ5�R;-Th���<��Q�km�єn�e#��N9��%�\\��mo�;��\'��l�p���p��;~�q��|\"�����7-���z{�����M+������xN~DI�s��~w��D�|���]�r�����HW�q���RIGK\rC���7>\Z�� x�\'���w\08\r�\"�*F(���aA`�������������*�b�ˡN\0�f������\Z�~[���S/\'���n��M�.uǞ��Ԓ�͚u�E۾�4�P���\r\r6�*2=�=���hL5�14; P����T<&�T�(�j*ҵ�.X	���P�ZDq!P�\n�I�n��{��ET=��#��G�;�i(�D�9�� �	�Dz�*Q\\������\"(�f�hC�Rk�(���ӘF���1�߾59e�?�����/1b���O�5�9�$��RgN�C-��@g����D>xH$� �0��h�y��	1��bC�<;Tʉ�H(�� ��~����\n�	F2��0��`CD	�t3y�F�Q�燿�f��S�C�K��IC���$��XE�����C�n=�םُ�]�)D~ݫg�~sNej�ێ�ۘz�VC�Q�1m���n��M1#Q���K%�dt�V@D!HY���o8��RQ�dA�B\r\\����0	��(!2g�o�R��\\���̨x\"�4\\D.�0��\0?�SPt�P�x��\\�H���T�&��,?���9�ڏ��֮_~T��\\�[O�N�:O���OÔ�Hh+_�{�6唞]�]:}��ק7�n$��Q�x�����>�b5�\Z��y|e.31��y\\��ql]ӆ��bU/���\'������;��z;�Tz:�x�W.�N�,�ۅl�.�ӆ�\rk��jA���1-X���*���4�z�=�c9m|�c�\'n	�,��\\\\�/<M����m��@I!<.�d{o\r��GB5q�\0�E-}%t�F\\ȹ��A+�����\\�E�љ�Ah��P3 �i�J>\\I�J^;�u)�eZ(��C5]C�r2�\0RD|Ӊ�$�F��P��^�y���~��s��^1P�̻�}ɳ�^Y������/ie^�4Q�:m�MD��4.Z�#+TL����*��$n��4�\n���+K��I�	��\nC��>8`\n��H9_Ű��E�s,P@%�	\n��⁥�8Zx�4@ �\0U��\nPnJʬ\"�)qS�z\"�w�u��?�\\��Ǟ�}��_UP���]����)3����gu���M�����o���y�}���Ϊ(���x�7Ǌ��������Oz񪳾�U!D�����.��@���7�N��3j+��D��\r]^n���V����&_�����72�r�3��΅g�嗯��o������+/<;\Z�6���g�^�;�y_^����z�/�vn��<��c���1<����\\��/6��`\ZQ��0�������m�W]������n��e�5�{��}��y����,^Q�����s.�����������8���/�H�������X�b���]y��v\\e�ʯ�����[_�̣Ͼ�){�r���>����TלX?�>;����m�����\\�gC߈���`�CuW<;t�\0p��������\nd���\"�\0�$WT@��n�|N8��3e�Z�j����<d��V��<ZQT�<�b�%�Ru���b\n�^��1����=��ه|$#����\'�^����u�Q|#J.E��j�@MS���4]�@��$��af���,�\0�P)B����\rq�B�]5	�6(1��X���:hA��S��7�J	�^Z�f\\��\Zi+��)��\'��Sa�YW���\0������<l��Sرue���ֽj�)���W��~��7N.�|�7>����	5��~����f�)]fg\'lڵ�^J�\rOh�n�n�2����-�\'g�]8t¾�λ��Ji���!�j���e����]-��A��[�@p��3�9��Ո��+�0a�\"�5�7���%e�j��:bɳkG{��D�Z�����M�-3�=�9|�C[{��K�Z����8��g�zǆ����t������Gw<��/�\'�uh�.��m��}63>3�Ww7q�~�:����[�<]��Q]��V���m�j�n���������[�tm���m��v�����O>j��no�g�0m�Y��쨘%�]��skO%֋���Z�-QE�Ė�[l�	P@�Җ)�YP����\"��� |�\r�+d(�%U��/�sp�~Q�˂z,�Aj�����Q=���>eq��!k�iuj�d�Ĝ���b�#�İ�C/e\'�2+^9�����ӫo�6d�TַVI�Q%���d*�x3\r�&����K\\\r+t�5$�����@\r%�� BY����7!p����^�-�N�pΥ�y�n(��y����s;5��-l\'�a��+ �5q���>���O�ɻ.;�t����5F��G�t*Uxt��������5�UV�;��}�f�}g���i��#�B��Pe��_��U�(��W���S(��UUTఆ�5Ǎ;�G��}�O��+����?� �>�_��]��e[g�=a�L?�\Z�}���h}�̪�o��oy�����;�6og�SHuf\'�/�����k��wɬ��_�>j��G7��jE�v�ڝ��Jwn5o�	���a�)\\������5z�!���\"���o�5j��1��&|iΉX�f4�z)�\0S/<������8(��܇~��kk*K���zα�\0&}T�f�M�t�gv�SG\r;{��ѱ�q�urd�ۆ�y�E��<7\\�t��^�]���)8�P-\'W��n^�(�B����:�@��LA�q�q���9���NA%�����J3�\'�b�����#�����xͯ����H��K�mi�\\�_�dv��V� CQ��c6��]��P���A=�O���7�xq��!]Whd=���U<WG��E�D��&@w\r�D�5�i�԰�����6�g��T�B�IC����D� �G�a��\"j��[�C��{s��c\'p�#���o\"UL��^�د�$P��ɘ�1ol�8s�K�|��ϳ�������GOٟ��\n��V��.2\ZX�jOm{y��G�_\\��${��i�o^G���rt]�x��<j�PV���G�:�?�z[�!�PO��J�ݛ��H�u�w�T��L��}���f���O�����=y�;�\0�R�4z��׽|��+$�ch2�&�\0��\"j�z\raf1|�Z\r_����<x��3gΞ�\'��|����}f�I�{\0\0 \0IDAT亊|\'�I�Ē��p�!\'���u������b|��;���a���M[*�M����c\"�׷�����R�F�D� DO�b)%d�\"�Є %�(^�H�����H+t���S����0�(v��O�(1�4��n3E�%�(E)i�������%PK��\"�����d)|bήЉ�/����!f$E;��R\"���m#�kѴ�K�萙\'�<@t>\Z�+��E?3}y���~O�ѧ��%w�������I�=����/�xy�L��J��]S�i�\Z�f	�2^�otb��WQ�p������l�uc�%���(��2������b�:�����1J,z�,D`C���	\\%�0tT?O�� D9���e8���N��Eu�4G����\\{`&,gc�n�MK8u��+�n+-�\Zq t:j�*^ܱvJ�ؚ㏛0�k�����RkKFU�R@T�Q�\\})/wД��6}��+��X�y���p��Y�/\nlmj��7v$w��)��X�by壷>�������	[a͛F�������ߚ7�pv���}���9z��W�j�+�&U����~�}ٌ}��\'!J����64͕�F~�PG�u;�_�ZiIOP�MސdR:J󈱇���/��t_������ŖX�\"�:���y�غ��;n�D��}7iϦ���=y��~��k?���޴g�����Ouk�P���C���FF�_Eq$�\n)��U�ɚO U�X�m�hP 	�%Z?@�\n\"&����v�O`)� @>\n*A`�h�4���+��K��؝f	gS�0uR�m��p\nXV��NW#fk�F@���ny���\Z��}�����}��g���}䄈��D1I�R�F�ʷi-��RE�Pɤ���z�5�lɼŕ�ӷ=���\r�rD0�0]��܉(�F�^�1����d�.!v�	ػ;�sKP\Z��uVP������r6��P�}�x�d:D���Df9Ŋ��M��	�} �\ZJ\rh\n\"P�>N9��V`y������gA���>��蚗���Sq޹�<h��[��1���\"��C�j�-^ D���T���p伩-ź���\'�L&�y\0���j\Z1��ON�u�cf�j����sxn�K���s�Rד���Dl��w���=$\"����C����\\��|�Ʊ��A�kӋ�J��7�{\Z�n���t�ڹ_9��O�Y��{��__W�p�Ү�&t!��ϭ�z����QZ^)\0��/���plE�(QRv��܈��}�;�ye��f,�I��o</W�������Z�ZnQ�6��{n��;ͺ��v��<�a�8x�&u�eS�+{�@��lnx���=��C�����պ���x����6���\'n����roqiU.�ׄ�N=��K�����,`8e}o�f��Άc~�A�}7�蝘#2�>�t��bn�bL�\n��C�������E��K�������~b�IӡC�KO������ϧ��N?���?>���~r��?���w�Q�[��·�?���Q��Ï���.~�?��l\\|�a��f��k��杪��e-t�T�L3U������G�XdZc#kzw��u;�lY�����-�a;���M��9�=���M���ҭ2g�v@E��t[gj����GW�.���T״W>���ζ-QҸ�+�dC�Vˈ��������[���9x��h�n�s)����<�6\"��^z����-�M�7n��I����v�m]�F�N�g_d��ݺ��NH�8h�%�n+j�!\"c����c��R+V��EN������-z1HżdBߵ��<�}mf�\Z}��������k�8���Obɮ���6����8}�&�|�����3R�㛯�F�)�/�cB��Gk.���#��tP��.}r���Տ\\?�������\06�_;�k~�疽ZՋ���3R�>т�>�����~mU�l����n9��[f�Ǌ���[/�z�2vܤ���%Ɋ�Ww47,ܴjbsώ\'N�|Ƚ�6��?k�b��V��\r۞پ����וF�l������\rwE��?�q�K�M�f�T:rv�WGu���eFtބ��n�ҕ�U7I�VCΓYU�?G����W���Ԯ�����ڹ� _����z˫~��雟߶|�\r[w��tKe�,}p�\'#%e�;/f��g��Wg�b����\r\r�^�&b��Y�ӛ_���ږM�m�+�\\|Ջ��l90�e�ZV=��i����ڻ�2}��w���֍���ƪ@��<k��)u�!�\rˮ���W�X{����\r����I�?�`�J��歊���W��WN�~h�?�6<&M��k��g��S|s��X1���F��%�X�n\n��Q��:{�F�8d\0�0�?\r�oYt����˳9�h�4	�%Ģ)d�r.d\"�ȕ��ă��R	���S�\\ue�Ч̆�![�(ɝ6m�c;z�;r���WY��x�̚�S-mOΪ0����ߘ[���9\'݈[7{�~�/]S�[Z+,<o�Q�by�\r�t�K��u��Y��\'�h�R=��O\\z���f��{غ�O��ܮ������m\r	e���D��=oY)Ȝ6�п=ѥ\'M�pm!�{W��Z���u/ʭ|��ZcQ쵹O2ʾ��6ה֭ȨUKn}���}�fn��9}��e��?.��#�Z~{ޱ\'�5f�g�����a�eK�w���?aSY�^T1iI.�i��u\'.�P��Њ�#��MGΜ�v�V�����K�w��C���k;hߪ��[�~b���SV�#�>��kapR%H`y*�����~u��s�}ς�4`fɝ�__�]��D�\'jҬ+���FQu)	�����˟����W���[���\"�y���\Z�.[�ͳ>q��mϿZ�ta����Ջm%�J|+�\nC�M\r$��ң���c�t�!C�M��[G��0ܤo��K�k&R�t��z	C{����֌�I��2(���~w��{���\\��>g��Y���a����O��1��W��(O�~�@�9`DW6���)�s#A�@�J���@�D>hQ&�M|���o�\rb��H\rWu;n�_�hA��Ƿz�mO�M�e��M�{���0�����O�*��P�@E���k_��X*&��a��� �]Q9�]JlNs&�\n��(�&��`�:�]����o���V�t$�Ӈ�dU�\n���0��w���ky���:1�W�=e�lO��ӂY��* \nO�8\"h���#�=�\r�Ǿ�5�蚆�q����. eD��?2||�@�9�A�;�y��5\'S쁈BHx�(���n�\Z��3�0��g��M)�RM�h>82��8n	Y��C��⟃�Al&��K{��m�2���-?��4ä\ZE�8t��GS=��Q�\Z�ȸ��o��jh�\"�AjB]�F�5���.LT}?���Ow��Q��GϺ��U���D��J���\"�w��F7�,­ÉKQ��,^?!���Օ=���W(R>xҹ���������=r�AG�~̬�ݮh�������G-_��7{�\rY��[[��x:�C��f}���h���t�82.�1�om/�QB<x��ʒҲ�S��4���~�E3=����R?�Jh��y#����D�]�~�s?m�{b{OE�@�_�x��]��z>�����ѷ�v3�/ ���(�\0�$L!T�$�X�\Z�����S�Wm�}�Ou��8u�ƶ5+�l[�{Y�֞RMM�~�s� hF��f��ƛ��Ʉ/���Ap�M��y��?Z�n�#O�?����fP.�p��\'6�j��OϾ��kO8i�mƞw�o�����w/J�w��/�^�|]+0��p拏m���-m��⿙���m�D?�Hƥ{`�Ɣ����Κ�ܺ�u�hhXw��c��@�뺧O��Ҧt�wmh���B�ɀ�f�;������}��1�c��f}���_��A+�0�L�Mޠ�V�zfO�:Z�@�9J�jr�����}����;#1�P�A!_������,�}�3���n�����K����sN}p����`G��5v髋�E��tKt�KQ���H�ݙ���^�~��N�e�7m}���������\r;q���gT�/����Ӷ���eG+;w��������=������9{������o}���W,�x�m�lZ�1�ח�sٗo��EP\'�[�1_y���m[w�*§�\0$	�g�E��\'}TVM�1�k��$���D*�V̿;��W.?����>Ň͵��6㊫��bώ���o��-�1�q�tP�B	�ee��S=T#P���mn�����[[N=`v���|��g�\0;�f*���\'}5��Y(.	+NZ����N��`0�+���nQn�HL�-�R	H0���������/{�=������7ԯ[����ߠ��([������_���O:e ��qd�,+�܈�����P��|\'�25��u�{t������g�-�4��7�2�e*�l0����.fƼ｟r�����;�����D5�����+���]w����{���S�MR�GS\0ִ�w�X}[G{e��==,x!�?5׭��̯O�@{½�\Z�Ѳ���i���k>EC%�\rU}E����K[[�m��1���j�Ѵ͘��m�5���;���k0�t���]?]vނ��d㒦Ү\\����YR��\Z��\r�]�]\"�b�P�I���J9�x���w��~���.����O�ܞaY,�#ȅJ8:�\"	�ű������\\�Z$��/��\0W�0lQ!��B2�*�[?V���hٮ��/z|m���Zۉ��S+>9z��㎿d�c�2�-Yҍ!�\r�\nj�0gY\nt�GYU[�̸���_-l��}��x�$n%f����٬{c��{��{_�zj����RD#1$>�dIsSOM�[^�6�Oņ�]y��������=��{\'V�S�&}�l��7���L&I8��pصSȜRS�v�~m��<��Z�(:`:D�8Q�D�����/.|��e}!��Sϸt�	���}߶��?�ꑗo\\����%��a��5�DzB� (C8A(5�+B$J��D��Fز>Ů�E��Zڧ�]�u��#�S��M$d/�t��D(P�@Z����P#��/3�RR\"��I\\�@�C�i�Z\\ؖ�6�L~(��[�Re��|?�a�HtU�ck7��ʅ�2~\n3�LM�O:a\0���\nJ�_�J��=k6�-����ooڊ���a� ��W�TX�JK�%g<0���*����Q�n����U͢[��W��W�U�Gm����{��3s�\nP|D��\"X�d��w_���{t���~��\0�Oߒ>��@>fLAU4l|i\"�<ALEj�ࣩ*q��޴�ƥ[g�۳s�o��޴�g~��ϗ/�N<\ZG�\"H/\0��0T/@�\0!(\n�(�M��>R��DUBaGU�)8�U/4�,��ɋ؃g��[MBM�\'�T�$���(E1�����.8��\Zr���sHWAZE������Ae���	!x�ޕ�����8�\"�Bw)��:[���w�|�m��.1|��[p^(N�+�2�ǳՆa��1������� �PC�O�/K�xN:�ʮ�!3��(j����/�]E43�����n�[��JJ+`��O���c�h���]��Q��:N��(�#�Y*�ض��_�ܺ5�gW��0:��*�P�M\r�~���?{|�eW��ܴ#&�P3j�֊D@�\rP\nh4�j����K�����COO�}<��\\��ѿ������I3f\n�E=Q�@���L��W��}Ɲ6哇��������OL_\\S[n���0�ڴ\0I4\Z�ҭ��yޝ7?���ՙ��D~L	7�p=����P�F&�l��.E\Z-piX�Z?��a-B��g1������Y�B�ϳ��q�B�B\\^���i�����+�ٴeׁ�:�8J�̰�@7��V�Xw��=��L=a��U�:��>��ү)-��q-ֿ�����?}�?*�[�]�f{} �a%D!� �(�Y\n�Geݐ���?�}��{���J�(6���!��\0��eն���p�.=�sK�k�d��m.tLK`�΋�_0i���`Γo\\9��c��nX5�bB$��G�Qtݧ����[����^�����7�u�՚ٯӌ	B�;�xE�B�}��q��ϼ���?v�O~��s����?�5�/ϻ�~L���E��g��H@�hBg��&V.�8x_�m%b��&D�0>YM!f��7�\0���\'(��+R�� �L3T_-��z�.������Ƶ;Pu\r+�oxQtt�c��憻���/���� P��5�6(qP\"�R�[/��ޞ7ۜ�G=|�Yc�R][���8�p��<gh������6]��=���{e<��Gg�7;R�\ZH�#�\Z��B�dS��3������=Z���Ӿ��<�Xa(�\'C�]���Pز��[����=��wB͆�h���Q�p� \nN�c��߽��+j�ֽ�K����Af����FpG�ڜ���&��?{���Z\ZI(����量���@�ߜ�mguީ���������ߪ��g6Gi�\r\n���PD�$��\"���6�\\l0�L09�@�rΫ��\n+mγ���S��0�v����~�yxx$u����:�=�]t��4���uc_\Z0����AL�Z�\"��Ck}G��u\r%=��L	�r�`T�m,��4\0��p�?ְ���:�ҡ���@�e�dpZ`:�$��:1��~Z�l�ΕTГ\0,�9�\n�\rI��ڷk����w>�cŻ���~p+��d\0���a�ĉn�W\\;����,���HQ�U�M���-��h�aL�I�y���^�)W�s�L��Q��s�5��n�W<�y澵��i?z�E�v��a7҇=.�\r�y\0k^�z��]�\'>���&7c��_�l\0F��]�ԓ�����⥦\0�B}������0���O%�?�=O7Ip I��S��B�O,h����ϙ_�q�7�=3iL�Zj��I�ld�`VN�ā�\ZR����L���ES�I(��H@��\0�Ut�*�Ӿ�A�	��`��*4J�&�:�\0�;1�?�fImuk�r5��瀪ÊI)�\0�P]*�Z���mwv6E��\'�����d�n�6��i�u\0\':m��[�L��A)�x�H��������6Tg|s!��\r�o��\\�\n@2��\Z������hp~�)o\\�(R�=R�)rǎ-uy��b(���M�\0 n��� I��+j����\0�X�\'G�_H�6�$\0@�OW�	8x�9e*8\0��x�� T��w��T������y��|��z������A(��`2a��*��������3zV4q�YhF��`��	�$��G�z��Dh5$��8��qX\Z@��|V�V��Bgp��b L�9$]��	@�Y2f}�{�<Sѯ�@�C㔊\0�(��P])Vlf=fA�	:;��^}��7�P�`�G�H��)�b٬	�M��w������~h0\"�X���0�$	F2��殲�k}k8��1m��k��@$��\0K��q��q%�Os��7cy��M�6��SR� �@A`\",=�L&�Z:`9�I\n�H\Z��u㩯<��]\'4�Mvo���4\0\Z@�@�Q�֎�dT��\0��P,=\n0	��T����O���y|4\"J�h���`�`�v\0)7 �ן�����e9�-��d�\r�D�������\rW\0�}��i:`�6���\"���A}������E�s�0q��6L�:��ɽV����U��\n\Z������03�;&����t���U09(�������n�`��yO� z�h�\"�m�W�6g�O|ڞ|fف��.�t;��M0�\"W�8��\0\Z�6���\Z�n!w^���[�W���j%m�t	(*��\\��3��P��c�Ç+j�S�\'1#�8א3 �=q!�Bf�	@�\'��!�=�\'/V������j����&�j��T��mW¾f���m�%#�d2Je�U����#3͇��~r���?�=��R���E	=n�hS�(@��(�������ϗ{2|�����VXVDp&�o�v�t�aA�0����Yv<]��4�T4!j6�kB|��Q�gg��i=2bI��It�X�L��|P�;������ʮj��\0\0 \0IDATm�\nA�$�	 �\0=)a����C��{�\"����$��XA��%�z_Dx��Ϯ߷�^{9�E�p8-X��,��Mm��o�����S����$RfiI���p��&�X�e��#����:K�n\r�n�A�!��##;3Λ�<z	fy���n=�+8Z`H�Q �=\Z��3�b�%��̱�$�dН\0O��&��}�[���j�8���Drm��i����8MQ�Z�@��&�fs���V���!�񤎁�y8픱���~�c�+�_��{GE�G����(0 �$!���PUM�@P���G�)�1S̊<u$K�LOY�W�O>����F8hT�C�+�Au�\n \\��8������H�.��Ð$�(�L0�\n\n��.�@�\Z��-�g���}���\")+-�\r_��)�CU�f-�v�\n4������qX:�P�9b�Zz?쟷�\"gz\0�aGx-�>��m�P~���%m̐5�,O���\'$��\03N��i\Z\Z:����s#�K���{ՕB9l�n�a���+kZv���{�����u��-\r��o�uS; �:GV����\Z�}�LP�XX�ɿd	Ĥ���hE�9Ｕ��W/��젍*I�>1�\n��`)����/�j���U��)� ,��������~��g]�㔐M��M��S\'����ΟS�f�$:����dZ�����ӽɤB-@5SDk\"�T\0Pp��j>���&!A2����^S\0шC�8DbB\"n�D���+}u\':4�A8� ��	����R��ɽhs�ѣ�/س}�JU�(�=j@��)���.zqq�d(��pN�:Dti�}g�E�?;tRo�%�,	E`\Z)�m.ڔ��a��ϟ��{�5s�(fXLL\ZK��9!��N�����)��-�&!����:a�Ǔ�+ʴ,�y@��y���O����ڪ.��t�.SD$L\r�磤\0�xxN[0���3�>��\0P@�¡x��/��W/�N�(j9�R�|G�!����/n��pUm[�,	 $��!).��tf��[��=�.�ҳ�\"t���aڬ��H1�<�24G�ʞQ�\'eò��\"���iXv܄렄#�t;e�\'�ӥ0\'8(,H�\0KL��B	��#A3���G�w����0D��&���� �\0�m뙪]�C����s�\"�\0�EZ�cL�3񥒓�[\0`Ҝ�2F��Ms�H�rD!2%��t�YY�\n����\n1s�ij�I�Y�R9K:~>ZI�i���n�y�ͤh��\0X\Z83 ��V�8:r�#�\n\"�i���1�!8Q6,���s���7Ͻh���螡1�N@�@u1M���c@���n���ǿSFJLJ���U������x\0E��-�f$;��(�@��Óչ��Kg�@�loT�����;��<��q���\r5�u�>&pb�=��F�A�]�m�Q����,�H��$	�MV3��\"��e�]�N�=tܱ�tH&��2lv	��pQ��g}�H�;ӝu�	(�a���\'��#�N�uj�T�}���V�nd�.r�����Ӈ��FoZv�ԫ�s�������4ό\' �\0��iR�@�ּ�+��W_��wi3Ͳ�9��C��yJ����+���e/\\x�Y����lBv*+wv��\"����%�M��Ṹ��S^z���DHr�p8AL�S���$\n>�y�(�0j����F8\ZF���R*����p�����xv���t�a�^n���k/��֬����[+OY<�O�*3�J�p�B\"��=\Z�ъ��׼Y}��w���*�ή \\\0\'��RV\Z59\"�6�郖c�῕/?;����I��Np���~�	P���V .��.3�@mbFj�\"�9CB�`��lJh�#�L�U�CBB�!SS@@a�\0����!�B��u\0��K�䫊Y;�������>I� R�G��$�>\")R\0���2\r���W���9�)l�LѠX\Z�[���-�:���@��뵥&;_/2;p$� ��e�LW�Q�]u��\'w�Z���C,��\'`pp͂�rخ�\0�@6����3��p��%�z�|᫓͖U3t�C&.p!�*@\rPS����m� ����؎�����0<N\n�!�\'���s��z��_��U�ŨQ�ǯAn���2\Z���$H\"8�,�	\0Wݳ�Ζ��%�,�UJ9!�\0� D��-c��N��G��[,6�����o����*�?r���$��2A\0X6X�L��r@��ҩ�3\0�����ZnA�vM\0����Cry]��G��^v&	�\"x��\'\Z��\"0T@����-����Nt�A��\"A�,8DF\nĤj@X\0�?�x�?�qv]M�PI�Me�d��05��ۊ�4�uP��EԑyY���jn�P��)�Nm���9�����`�qG��SɄ����Q�$ �	����!��Zen�)�����\0X�ĵ�x�p\"��Z���ߠ��:��[Z[�TTpX\0W-�PU���ח��G����mh��Z:��0�v\"9�-\"�\"�6i������6�>>�&3��J�.Z��uHA���-Uξn�%CFg5#�r�\0�(Bq(ؽ�v�[Ϯ�h募O=�#�2-A�a��}p0\n`�@<&����`\\����G�²HS��h8\n*ɰS����	B����/N��qһԔ�	Ah�NnhPvr\'�G��}X�B��IP��	fov$U���������_F��.�Ƃ�z��v�mF\0�Br��)��`�D�$�%J��3(a�nd )9`\Z!|�ܞ!����2�;U��Z�@b�hs�1g��q�uY��#K�qd�:�,q�#�*��m�:�\'�*����YGm�Ҵ�?t���%�\0c~&�����z�ȿ|���_<�A?�� D���(@83@)CZ�i.|<��\n��+���p��@�\0�U�\\��ظ�r�+����q��F\'���R�$\n���v�F���x��s�(,,D4Fl��H@(8q`׎��O=�g��?��S����a/䫇8���!\Z\0�&@7ulY�?^��\'���헬����N�+9�vA@,#\0-C~�ې\r�2�٣T�ך�q��(����a���	������m:@�$D�	����Y&\0�Y���c�p|���k�+;D��\r�\0�Ni1�e/l��#�\0���$nD��M�<��V�L���P��܈O��^�����9�ѮRykj\\��ľ�kΌ;���m���-���\nP�y 2�7s7y��Κ�dn���*%+�*�H\0�\0f\n(.�8򋿝�Bo�@�V��� 4� q;�D@�8\03no��p<eRB ��ð40	 I�2���4Y�`���r߭��c�m����-��T��;��̼|����˝�nٰS�v�� �~��y(�������q��{��Ϩ��w��0͸��2 *\0���\r5Ql[w������޻����_|�\'Tuʒ�@H�^��b0D��@���#G���.�qAQWt\\R3 �4@\r�uS2�����|���]��\"�a�^p!�T�=�i�Q�m�mM���_�aǦ�:\0�R�05p.��\Z��d3f�hL3\n�L�(2<\nE\\W`1Ad���\0 �	\"Yh�,��I�?Ͻ`����~c�\0�s�D4DL�k�H�Dg�5�TD�V����C3Ы��K����-�Ƿ���1�	���@$w���q%�~�{q�ci��۱e��[��\Z���px9����jh6�N\'0Mܲ`�\0f%��I���K�DU��t�aD� H��3\'8��@sc�T[��2���Sn�)�\n�7a�S�qj\Z�eǯ�]�\rf�8���U^g�	�u�i��4��;w.x�>���}�+.�m�����{�>U�eς/�;Fjz�,�s���P����G^~ze���cCU5]��溅z�9����@�.��E�A��/[w�=���.O���u�	\0��\'��l�]�M��1��q��D�dq��\"2�v��a\0�&���[���Z*��kv\"��7$;H�M�8a�u&�.�S����L�\n@\02�\\�N~�h�ݫ7mZ0��͹n�gٺQ\0�nZ@7(vni�����.����dtG6X�RR(��v�Z�c 2��v|@wG��Ep�C�~}�=�=3u������0�>YM��Ĩ����_6�G����ٿm��Pu����]\'\0�����0�3���GpÕ��D����Š����p��?fDl��ç%ڣ�e)Nܶ��c�!@�.�l�t����t����\r�L��:`:l_��T�\r�I�R\\|n��*�9|���ںN�����\0d\r����M�������BpdT�wNפ���p`D�0�:�(�s��P�\"jj���W�xot.��%&jp�i��io�D��âN��[7{�9\n\n��b=���(�\n���bO��\0M��u�F�OK�-t�U�b�&aYn�c�|#�G7:���KN����zt��<\n��n\n\0��f%@E��c�@�5�@vW����#Ań	C�+����k�\0P]���\r{_����n�v)�p����0���1$㻠:��Y6���f#�\0�6:�%\0��9�[.u�X*@54~B.�Г��d�} �Z{ \Zj�@] �\"K�|t�_\\p\r얩=���vI�����p;��Yv��z�\ZjK�� ��]T<|���*()��	2�Z>F��\"^x�;;��}/��}��wO?Z�\n�h�����[ ��r4����L@�c�DC��C�n�E���Ef��?�:<�a�4�v]��?�8%��\r�)ژ.@�����\'}���]������^��z�Ǝs>}u�����at{�	�B\0E��I��eIhn�B���\n\0b7��\0X��(���R���<Z�;��S�z���w\0�i��LH�촼��		`�\0z���i��=�0M�D	H]v�R�\0�~$�ֵ�mj�16��DXID4A�1�{ ���g����z2���9������V����\"��`��3x]̛��/P�z����y8OPp+\'8\'\0L�A2�M�8�S�7@5�PS���\'<�W>|���S�`ێ�1\\t�!P�Ĵa����7���V߀a|͠Cޔ�;έ��D��0\r�8tN���ٍ��z/�y����ԝ[��<��8!\\�eq�F���cJ���0�٤*n��&��n�5ۅPe��Dp����\'���~�g�m|�`�e&�$u���(��E#y�-�8�}�L�8|�����o;t(xS}W����D!� zP�p^����1�g�lŷA� P�O�7���.�~��]=���CkDLI G␹��%R5T�e��>j<�w\'����.���T*CqS�.�N�op����g�|���ϰ�:G�h:r�_(��`\\G��e��(���%S���o���M�8L�Be���Q:���;���c���fQ�谠E@\r�\0\rD�H$��\'�D;��.ۼW�\0�8G��C(%^Dg�6����cZ;��te%�-s�-x�D�\r<~����_����7=ŷ�^�Д��b������Ƀ_�Bg`����*�$4�Aa�l��Є��o����_�c�xXK�lh��ED�$`0$�1~���	t,8��D���2~��6����<k�E9��I�O��ꎕk;�<q�Sc�|鼶�Pa$��\00c% �09��_�������{�	v������0.�RUf�p�v�B���)^��]3�t���e\0��&8��]��T���?~K�g,�����Я�z~Ys0�˖��<]!������E�z3�I��:�j�_�{s��-\rm������p��9��\\=aV����?�8לw���R��t��@�#���(����t�ح��\0�@r��X��A���,�j��ݺ����^�>�߀td���Qg��r�\n90�\Z��/���{W�񬚚V��]���^m�\0p�?����EFW�<�.,���ك��.ϻ���g}y�{�y�|ʩ�4��R�p@d	\\�@$!}@�1ӆW�ZZ::���0�Ü�#�tߩKpB�����:k�o_\rV��>���5T\r\\���p�i���.ՙ�AB�(�M�֡Ӌ7l�^1��\'�l��t�,Ē��m��e������І��D{~D��D�i�MQ!��̦���&qX�	\\y,%Ӫ��얻_|j���}rE�SXP>��:z�5\0pޥ�^��б���uԘ���Ww��9�ڞ�;m���\'�7�AX$�\Z�u+*��˽�b[X�⎹K<Y�,+$X0,�8#	(c�!�����A��g��d��|0&�o���i��L}\0\0Ս��=����Ӯ�䍝wO\ZW�:M�Z�[=C�a��q\'�1ov�ܵ�q�gM/�g�\\1����R��9$���P-?�������G���8e��\05��J�`�`�{.�����5*�����H\'N��V\0���o��{���!Kv�1\0B��ۍ�>J��s��R�ʳ7�I]k����:�3�g�nY�T@}G��-GO;��{�qjh�۟>cz(���U:�9����+�PƟ��[&��\0����9\n�l���3���l��y�����{����W�6{ty;)�	�A~ԍL���9���zn{\")$������U�y�u�k&;e�E�̓�C0���w��⮭?s݇Qw7 \' &$$A6�\0Q�俬\0f/���8w���j+�X\\�s�?�X������.TK#{G�f��R�Է��|Ok�z&sN/�<�U?-��ю��������_�\0�ey0�v��h�]&�a��\0�]�ɟ%}�Ѻ@��q(�\0��29�I��?>�\0~��Ϟ�J��B̆yqvst��uF��b���>��\r�z+�ɿ��T�J�|�K�\0�w���=����OE������c���A�s�߶��I�H�GL]gG��/r�����s\n���	�m}�Z���,��\02�Ԙ��II����I|�z����f<�;��cz�s��|�-O�#�ZF7@�m��f�͌�oZ��Qs�>D�	`�\"�E�(���\\~B.8������Z�����L:�{`�#\r\r�b�;�s�Pɽ������w�x�z�ͫ��X��7߼��l�g���1\0@�e׾���#f�=�w�GOŷ%���y�&���]�\Zn���+ꏮ����e2C�w4M\\��Skxq��$�і�&������\r/��eyKt��n��\\[p�!Iξ+i���	������~�	�<7�Ù1�Q]K������ɃU�GO�ffш1�����$��pxw��\\�z�j��eE��c�.�A+俼x�����~pg��q�q\"Y��G��ON���U{?z�\"��>3�pu_s�Ӿ�#VѰY�Y�ή���t�~����/>�J��G#�Q��\"���b�huB��?/�)��e���׶}zc��!�vhK�i�ҥ���������ڦ99��u�SpY�Co%\"��=�܈�j��7&b�� ��M��E��6׬>��+�K��0��$�Tm�Z�xv���\0�u�!��<<tp���wk+X�u��.޾���\n~k)UTC��h��\Z<���_������E���t$ 9�〥P�Դ��F ���d���I�`�J,H��2ع�x��o˓8�=58?�w7�YWJtI׼���ֆ�����w$���K��h�/8�t�gM>���ؾ�W>vw��P 93a$;@�%[�FmJ�h�p�\rs��fD)L���}��X�s�Ȳٿ`��ytÆw�=x`U�K������⏫�ֿsI���^����k�n8������W�z�c��o����+��ۉ�3����UW?����􇻺Z*�+\Z	��@$%�ɡ]�/�������,\\B��Ξ��[�?�z��W5��Y�ٯ��yi�%���\'���lk��K7aēȜ8{�\"q�v����&��\"3���<ml]���3��G�o��3� (Ѯ02ʆ��������v6���i��R,I��\0�p9%㦆�]oݽ�4w6�f�����;m�}`�`�ߡ�k���P�!Q��85����h�WO�\\S[�`�y_�(��d�3��V���g�Z��_ָ`���\rw�dAUPX\\��\0\0 \0IDATQE��Jf-=͛��U}�\":���#>r���w]t x�ȝ���,����z��ϟ^�������jC��H�����/���G_��L��uOwud������`}Mޑu���b͠I�\"���<�y��,Z�ln���]GZnk]+:�]X��2� �����L��g�u�^�ҕ�?��3���\08u�]PX����T���9�!@��g$j�/}��YA83u!�8 S�8Ĩ������~L%��+��~y8 \\�׿����ur\rv�Lp����.w]ƽ�%���ŏhқ��\Z(,��9t�U��_�*,�J�7��@�,.=�1{�5��Λ8_4,4�U�Ȫ/N߻j�\0�j7�����	w���B]�@�-�4kr��B[��)�^���(�;�߲��ܫʓ�$9=��ATT�5aT|����y��xU�p�H$�.����Ag��D,	-B�7�z��ݧ���;CGk�g�y���(BՁ������̜�H�N+l���Z3xGk��x\n�Dt�)\0�Ss���ϰ��t�j�J+ĨS.F��=���ǟ���U@��}$�sD�����P8zL\r�����w�i�����pxJ�;�#-����E-)/��������d�:�m+�\r\Z򶙌!�Km��ymB��\r�L@��2��\r�g��/13�Xg;L<	��ފ���k1d�<e�ɗ#nDWmK�jO�8{�C�����UÆ�ߦJW��\"�@�֛�lT�g\\�S/��y��U���\0�����5{ f僉����\0����*-�ol���\0̿�n������5�MC������=�f������ȩ砽v�<���C&��t�磱�\n�,��E�BW{��������d���3�[:�(�XNl,a��K�ޟ�>[�nY�DT�A��$!�� 2�����+�{��t�����˕�/c\'.{�����xϫ7�$�]��6N1՛��H����V�+�e��u%�3�%�3��VMJg-����4���o��3�Aw$P�����3�������z��{\\Z+�mhhwfLxn�IKK绹 `ʢ�b�n�E[s�//�����d�Ő����⿾�Ѹ���ATs�;��₼።G�dzs���~�UXʝ��|Șk\"Gv�Ktty]��a��Ř8s��B�\r5^WZ6�\ni>�\"�߈IH�0t�D�Cy��0\0�+��Ag_U4h��.g&�&�[�@~\Z��U��l�쥗�\'�\Z���4�ہ�/Wp�XXk\nLt^��R��CI��ߠ7�.��d������B���5�_�����s��z�r��\n��5b]����<j=�E��^�ds�����C2��/<��;�h8��jF8U\'\\�\0򇌁ە�桭-��CJ����o.��o����$�R{s��V����1%R0��[n�4���t���a�����-�+C/>�J����*�K�L8��X�!�Rp�qdv���b�;f���(�W����b�-n�����CBq�XH�� �Y>!8W׏�J;hyĢ��娝VK��g�\0,���l^v!���Kd�#ʽP9��b0b�f��ǋ�r�k�!�r�-?sB�w/��ܞ��t\0������F�P�T�\r���5\Zk�~�pw��J��	(Un��\Z�1!mpqI��b�[�|\Z�+��!�0l�)x��όZ�O�R]�(>�/	]�}}\0��;�����\"Q��e����f�Y���,2ml�^#�h�Q�#�V_�?d�)��+���\04_(L� .5ޥ8<�Y9�\0��C0`��[k\"�l17�u�Be䌝�$K��z$�n����?��d�c���0�(`q�P]�Qg6\0P���{�fl}�	D����Z4��̋�YѮ�Qe�����Aꏮ�*g;�G���S[1A��kj����mlF��I��\\y��vO(��4�@��!�u������/�kBIA��z���Fg��;�|L:�\n\0@4\Z��0�y2B�-��ڵ	�4��Z�\\\\�,6j��/:��j�Wx������%eS������Q��\\Y�� >��(_x긩\0DJH�υ#��c�S�@��(�8G�^`�?c����16�J��@R�1�2A��O��ּq\'��y�ʞ��?y�1�\'\r�6Utf�2L\n,��[�� @�����|tgz?���@�n�\0�aH�S\0��Z��z���S�It�s\n��.c�O�������&�u�\\_���z{V��[͊V~4�/��\n������-ѷZ>��Ct��m����{��\r����V7�>7�HD���(HB@�Ӟ����u�U�L#��/���	�HK�<4��ȅ&t�`�Ĕ@(�b\0� TtA��jP�S��҄x�6\0�\'��`��ϡj�\r	\019x�e�@2�Ԁ�Â �0��ʺl�A�R�aQ	��ǣ��\Z*�#]��H3����A�	�0��.�c4jA�9\0JCn �50ݠپ���*��*��rY�9�NΑ�_w�G�ՒؔC.�Q�X�4d�����u�;D�$�^� ���q\0`�: h�b2Xo��K\'�,b]\rp��mE�K��S.����$���F����uw]#���j����3zJG��Q\r�7�qeVծ�R��a]���»���ш�������i��E\\�b:\\�P��M�?E���a����,�qX�[$�\0 h��!��D��\"�h�#\r�H�\r\r���$Ƶ�L��4z�b��蔀3N�@g���g�1u�T��D/H!��0:MX�BRd$A �*�X�����pLF%���N�[q���\Z*J/�M塯�\ny�\"Ku�����)a��wQSY�dW�ܹ�����~Z���k-����k�-Y����G���)�Td\"��t/&-�	�x;6��R�����e�(+FD%��\"�p�qo���m%\0u�H&��RT��q@lV�~� !Q����$|\n&\nGϙ\06n�����^ܰ��~Y��DMIR�[���*�{�dN����Dk]\r�-�d�K�ю�vC7��U�NB�� Z:�p0	��V�?�EU䐈\nK#]��B\0��1�`�XL:�&�?c��#[\Z�,�ũU�E������-{�ڑ:5�����F�4r�DKԐQ��ӯ}�ASm�F��P�o>D��[��A��,�����k[��|���ڗ4\"��NL_rN[��ͻPWe���D<������!x��Ьn��h�ܳ߳q�;�����/��ŗ�C�OFCE5LQ�\"*{��R�~�f`��s��;��-P��M�d�e��0��b�� �DX�@�z�Ԅ��%�\"��MK��5�\rѠ����4s.�\n3��\Zݭ\r�⮉���1?��3���x���$	�R4X�	�����c-�K�-�a��.0Y!\"�spp�Nz�\\�[k�l���9���z��0�$�_|>������\r͈F�f������ԯ� n`�Թ>{>8�(���x�깷m��N���5\"�.�tɺ\Z��㿙b>�espG��8E��*$�\Z�zd$���>|��[���v�N��݄���1$c]ٺ�r���z*�H�!��Ұ;6o\r��9��^�o��j$Ԃ�-��_��I<7�EK��݋7��ğ��n���hG�a�m��׵v��jhhڕY6�:13�������q`�;�9\\��Q��!�F��ʜi8\\�	9�!���D�#����&�t�;�mo_[�tfDá��������=r,���O^x�ߕA��02,	�\'�G\"��`�h��s��YnZ�T�=h��M��ƔD�Hÿ�����@s��`1hM�h�[���*x�Y<��>x��$���IV<��ή=v�7#o���*�;T�ɋ�GCu��<�	v��a���PS�	_��7n��W=B����b$�\r��oj�y�jn��ŚQ��m��9Z�mE΄��d,6��r�T��H#�OBRH8�Pp�M����m��?\ZGm���˧nC,�Û�C�����\r{�4c�t��k���-���#�ȎX^ƀ�+�|oݿ�_��8v��V�5s�k�����	{���sE�����;�#h������Q\'t�#���Z��!}f�wE[�\Z\"\\�ݠ�D��×`��H�N[w^���a�\";\Zl:�\'\rPU �7/_�9��?��6\nQ~ޟV(q�۽\r�F��%XV�x�÷bD�ܓ1�`]G�ߒ��u�OU���g�rR\'gx�y����>	��}�(��χ��,�I[]�$��0-$[\Zatv�dȦ����׈.�����\"6�|<a �tlН�=���;��L��x�Ȃ~#g��nǚ������x��\r2x笳o������+�LBd��];�v�]����\n3_��������6`��N��⌺G������?�uWz�hKj7�eI\Z���O���;���=2��NC0Z���=��4�Q9��̈́���Q���q�C!�|�Qł�dd���-;���9\'�i\"��\" ,�Z\\�L/Hfy�o����g�G�no��ׯ�LN�W0�*�x���P��Aw��g�rx��\"S�Pe?��{]<�:)A\'D�[>|�Ppل���[��$\\�C�[UJ\n\n�U��-���;Y��0�5�d��ۈu����\r�u\"���y֨	o����b�>��Gu{m]`��]�����Ʉ�<4#���`Sw�e\0o�%q�(k\\{�I3�e��T�ꎛ�h�t�QI�GL<��a3�Z��^V^�Ui#��+|�����k<,�bFi �{��\0���_Q�+�!�M~,�R@b* D �0�B������쳅�6�Pdwo��HH$�.�\"��l�ng�A��|�\n�ϋ~�P�@Ϩ�/���$�\'���*��p��^J|�A�kzc08�2O/����L+s�ܕ���������<Fx�}�p���,�O��`I/rx��GP������L/K�p�š*C���3~��a$̂4��(Ocn@lR����vPi�y\Z�*�%B�{D�Ӳ�l��������6�]F�y\Z�\n$ձ�^S��6z�mG��r\'3�k��-�g��FiW�^i���$�E����?2x/F��YO�u�-\'�G��1�șyGM���6�d%�	�C���7Jv-QZ5�����9r�[�p8��;HKU1B���Y���@z����hLtǾ^>a�+MvO8	\\�=jؑ9����5o�`��_��!�[	�I)�ah�ف�����Y��gg`��Z��Y�;#�2F?|���ޙ�[V�w������X��*j�\n(�Q\n\nD���I��t���jԧ���N:&}LL�Q$DQ��I�8@�\n��\n�\Zo���3�y���)����\nU%������}����{�w����[ j�q�g���z̲Dw�@��RʕǏ�/?�ԏ�yz_˓d�ԅ��e�מ{�2�x!+��P��p�������V}�غ���Mmr/?��\rK.��[�X�O�-Y\'�z�����7�F��l���3���|�K�5��y��Rڎ���n?��+>I�{�+~�o��څ�G_*���>�W��	�����#�N��)����C��^>t�E[&򽯨�|���~����C��㆗5���ȶ��T�P�-i��c�����C�DsȚZ��6O}�\rO|�P���f�NZ�8&��w*�=z-��5ןv�G^{H��\"G��S�w�ݽ����%�����r���\Z���&9��\0��疼�S+�G��q�>�#CKH[# ʛ��[GW��<{��h����������G_��\"�<r~�=���2u׀�K��h�n`�7�`>�@R��yS�,;g�<���/�!->��U�ꘆvɄC�0L�7���݌й[�<����~��IZd�����?����/_���D�v7�\0e�1��bd�G�pP��Ӭ��ʦCԩwH}��3H�_@��YL�̦���*���$roU���ٻx���!�Yd�#�[����o{�Ċٿ|����[���7��eD�O){(呗��\\;��.��P}�C���<��L��h�8T�q�(�Eb���*���ra|���p�ۦ�K߸��i3���5�����֗��3N����%z$Ed�\"����:�\Z���5���l�Gt�\0U�k��8��t\"gΎһ�w�7�#�1��.�����n��_\'�w=y�wٱ�_��7P���>����RF\Z�܂�y���L��,ι�C/����3܅��xI���#�v�s�2Q4r��\Z8�\0�*�O�ZL1|2��e���ԃ���y�d�^�ɹ�~���X�Jp��n�dl���$�K���:&	{�(���,}�Sq��d���%����/!r<Ҥ��K��0�]�tJj��Va�Y��	T,Hj�n�{ѷ�1�R+�S��P(S��pUn�� �%A���J1:fN�=�l�]b䲁%e8|֣Bi�E��}��}�x�6YE\r�MH���2��-����)�\"�s�5��Ez�JI�P)*]�T�;g�%�F����\n����I1b��tJp��sY��7��	ȘY2���R��<u�Y�H���J�b^��n�t��;q��%�=R��kH��b\"��w�]w�My���G�����P{?�H�݁y��څ�@��DYb�.�=��G�5	�Ǒ�>�l���r��D�\"GHM��:Di�8h\r�)n)P�CR�(�@3�K��p��H�L��i�:-�j���*qK�LwP\04���X�F0荰0v��֯��>T��ӳ����D�\\���:TyD$R��ő����㐛���!D��<�8#tBSP�X�HQ\"�\n�(��f\n�U:���.�N)�����2��EI�v<|����{��M5ʵ��Uiݵ���jn\n�1�[A#	E�k\"\n����I����矼��m�~Fҩ��w6[W�*�ί\"�9�n�����]I3�M�a�U�+0�7|��KM�@6�Ma�aRA���ye�<Z�Z�%�h�MY����ٸ�����4�dCߚ[Z�f�\'���^a������8?�=V/&�{��SP�S�朇��O����E~����ݡx�f�)ɑEN��\"�Q��z%x���1�^��@�$ �Rk���`y\0n���V��u��C����_���2�K��{Y%(��L�Pj��~ƱcQ�6�30e�tF	�5*�h=Gg�F�K.�a�䍟8����H�(`ť�ff��h/$3\ZW&�C��\'�i��@k��J��Vg�\r�р��{@-����F�B:5k�֠�[\'7�z\0^\0N`�� � �bG!�\\�\"p]���x>�E�\'��Z�>Z0ֻg�����_o�ֳ3���$۞�һ:���~�Ba��۴���	�JB�ۗ���w��{���=R:�U��}:�B{婽��;Fi;ͮ|@�S��/�#���ԧ����ښ/TLQnI�#YM�[Ic���3\nQ1��̷�3�t��6��u�|�T�r��S��]w�>:�ͯ\r>��M\'�J���\'���^8Š�0BSy\Z�����^Dm@d B�R+��dFp��֚�;v�d2�rMzX�y@�=�����;\0^fX���/QVc���ا���`r�a���:hU���ή��߾~�E�Sv�^;��{��~�ܟg��e�\\u�Ah��l޶�-�b4�L��z�>c�ל~�/� ��e���w��{�$�*AK�f0���抺o��B\nP��-\rY	�1�$)!D��r%FW��>DR�-5)Ȍ�B�*C�B�%����r)�Zi��0�z���#�����tѝ��K<Sb���s��x��l~�e=��W��\Z�g5�n�g����7���ԍg�)��F9Zt�A2O�1��h�� SC)U%	�� |��!�(��� I\r\rOP�@`��d�,�F\"HP�!υ�T�*�.Dʐ�-�)\r�#�c�X.�G�*i4�\rL���6�J7�Yn�-N��}�sɟ�`7<�M�wT]��&�x��:��5�>��C��\rg��ls��o��7��Ro�MY�5������0�7��@�j�X`�yt-Df.J��f�����x)�硕Q�h���T�Us��Gtbh\0U�H\nt#G�U�Z1&�\"B�sL�#E��$��4�\n���^���h)�A^&�ҥ����psu�[�V�W�\0\0KIDAT����§�v$��<��G�^���0���m$�\Zh3�p/��索�2��UdZ�aZ	j����Ia�g�!���̐hA��v\rEG�P�E�,�*H0�HU�4�2�)�0��@��,���X\Z�L ](JC���p\r����7:�h��.��%�)g5�����~pK��~��?6�[�.n�������͖x�]�����%T�¾4�ڿ�c��Bt0�SJ����D:�Bg� �#r�[�\n�R*�P\n��H)�\n��(�\"C8M�(�o����\ZTiF:@�	U�qD@�F��]J�GT1e ɓ.�n7�ç��ֺe�s�^�����:X��@?���~�\\���؍5�5�������D����W�)��ʘ��I8QA��@Y��AW�)���/mR���ɅM�y\Z��u��m�M9�f9�>�]2�	;��m�P�v��)&܀�c&p�*Ǯ���@b�8�B�ǳ���\\z��s������c_��-��\r�����J<���a�A��&3eX-F����<tʒގ媘�oAՁ<?�O��6U�����˖�9���3Y*#d� Eɼ8H���1�CP����\nrk��\0\n�K��cF��0� ��Q9����XCV ]LU\"��a`0d�-K��z��#wmy�[O8�޾ˮz�5?)i���:�?��}�}����6j�u��O�z�#�q�ɡ\\~�,�;�u/����r�(Z�vYQ�t)�����^�n�)�3U�\0�.��~�e0n��\r�v�]�nY���ԗ޽nϿl�tKq��c��P9��D.�\Z�\n�*���ʮ�j����\']��٦�|�{��e����7�᥺�P�13���vEa��B�3��~)m\"���y詓i.�_�a���K׌��@�j����n�����%�y0ks���/�*�:H��C�s�G3��z�Ko���-f�K�r�с�]\r���Q@��H��Z�8���|xͥ���}>������{�����\r�ę�����I�T��\r�����\r�*�N�S��̦����c7}��_�����,n/Zy���V^�ٹ�*�dN�$ݕL壔14s���!Tfu\Zr\\mmvB�������~�p���`���0��ɿjD��rc�28���\Zi4BۜG\Z@��~)5�.ĝ�v{-Μ}�v�o�o�?~���h`�~�<�9!�����#�Lϒ5\nf�Ou��i���)�LE�W��˾�\0���y{�5����ٹ��?Ɵ氿,��#���m@?��ϧ$�u%q\r�-x��n����d�S�XX�;��p\'��Ob|�e�^|�{�p�O�h`1�!`z�+g�s�br��T��)�!�ePR�P\'��g�����Ƕ Gw�[&k�ֶ�u�o�p�|���<�Ė���O}j�������NM�Wv�bk&�2��c��c:�Eo9�$f��;��\ZX���~�Ə�s;ZX��{�Ϊ���\06�u͍�����P��e�0�\n�L\nTU1���Q��d�5w�9I��UWm�b<9}��)���{6���?��햏��݈��_��齟�j����.R�%�T �xw]]1&�LL�&�\\2g]��Y�W�43�)+�3����^�����s�b�?�	!�k^�Ʀ�:�>����nN�u�e�����9�Hҩw9�5IY�>���,3A�q��e7�5/��+�{Fv�G7��g������ym=ۊ���I���(�e˃K�t9fEE(\\�J \\CXijJS�\n������cz���n��?���}�G��~hz�{��4��������{�6ҭ��\Z���+ʹww�;m]#��YG��&Zc���1�|��ݖ���������o�{����mNm���#齯(��C\'�o/B�B/��.���hw��2��sȝ㺘,A(����� I]�D�����������-{�,��G\n�9�ň��FC��˻����\"��A\'�9vp�]���P6����ֲ���v��.��F�����4g���^38w�����ݡhd�&״^n%�6I�cI�&\r=������T#޹��ҋ�!�\\tYyW��o}�����5��o>��y����6�Em�c��NgO~`葯�<̦膣��fX]߅W���\"�]U\rz���L��Ҝu���+?9r�˾x�O�g�o�>~���;�/�ʇ�\ZfnU��Re�J	Q*�(G1�Q\Z��-�<��\'������}c���p����;\rٝ�˥�9}�?��7Z�N����b�?G�@sϭo�L�;_5&f�̇M�\\c���ܜ±wƳ��~�i�$�WdR]�}~��?Z���ǆ���ٰ���,����&�߰!/o�f���r)v�F�>\Z�����2#�ķ�!� ���b\rb��1y��#Xh�=���	W���>s�w��~�����{�O,�sȣp��_|��_<n�;G̩���NB��m%]l�~{�B��Ё��CZ[M� ]�O����_�`y:l�9��?6e��YW_(����r�W>�>`�hz%Un�\"+��Rp�M.~q^g�=H�SC�\n�\n&���;\'��7n|�!UR9����/\0���@�y������ݷ��5���W��!b��r��3T��eklO|]@��у)(�(�\nҕ/���>]���u*��5kެ��ǜ���}��al�	��G_]�ni���G��j����֌����~Bc�z��(���wD\n��L�&��Z�2M�y�I�F7���+߶�����3�E~�0�[���%��}�5��R����ui8��s���p��z��J�����c�\n��*�^�]�����S��;���Cަ�~��!��j�8v���bvq�|�����݇��37\\�����7��2�eY�ڃ/�0x�]ZlÐ)��,�.�|S�aav7d$��*�t\"��+v�^���/���&����~���W�������]L���:s\r��F��M��)q�@��@r�; j�%����\'$25��i�c���\"��\'��ޥ{c~�����q+(�1z�Nc�����z�r�V:���$�`�dV����[[W6�V%@duє�-�ն�o>&����H<Y�0��9u�c�������>�җ=t���y�b�f����M�m�������ô�B35h���n\ZQJDj�1ey\r�>\0�R��6so+�YU���wI�T���,\\�\\�˂�WR�R��C*�^I_�ӈ����n;����`���vף�.%�QKs\n/�V�1S;�x��?�=�w��h`彇q���,��͆��~��/�����丣}�W�f2R\"{4�iF=�c[^c�j�P�j�P�_��_ߋT�����>�d�XAĲկ/\'��[h�Pb�9�@ֵ�o_�7�[B@�k����I�!!)LI-M1n�tk-�1?w�o��\Z\r�9LC��g1Џ����u�Sw|�5{wәKQ�Aw���p`̰,�k[�P֬���lX�DǊ�XQ��J\r;�f�f���6/����mc��V����U�1hm�����9$~�`�l��2Pv��)R�$#kKg��������ӯ���:��,��ƿ����������\\;��AT,���|B�&�KYښ!%����W���z]��rh6(��Je9�&Ӵ�J8�g�t���?s����\n�&�\r:Ut�\Zq��\"	�g%C��JJJQ�/�V2����\\w�{^�z����_�\'X�#����]��w_�O�ѨI��9]���K.�h�T��k�L1�j��\"�@e��Th����\rl����j�֑�Th���7��}���cE\\(�t�L7qR�^U D�C�C�����o+.��Ƌ�~�a��:RX�#����>��w�uE4��-��s\'�W�t�D�(#H��&e���I<�d����<���0���PS��/o5�Rk^��@)(�\0#�t2A�6�+�,iM�2e���z�<*�*M)^.��;���dt������~Ε��fG��~�ć����E�k����jt��7���--��Uu�Ґ\n���񝒡\ZĲCᔴ4����S�%!���(2Bj�����Q�rU�e��ȌBV�*����Ikj���Ɇ�����z�9�[�X-�Y������<ob�S��Uyb��T�WHO\"��c=�\'B3U4Ht��2���\n�J��aʋ�$�tA�e,2d���k*����DT�č��)�p�������7��������g1ЏR�i�\'V-�z�E5�M���e�bUk&WE��G)~\"0\"��	�7t�IP=EYw���X���!we�����(�%o��1����:f�G\'�+o{Ջ>��p��\"�8���K��߹jeE֪��&�N�1,�f���rvUPh�*�0�P�7.��=��	%\nD��h:�02�|�w@=^t�~c��Ds�|9t�gO�?v��w����\0���JT%\0\0\0\0IEND�B`�',NULL,NULL,'TACOS ALVARO','POZOLERIAS Y TAQUERIAS ALVARO','PORFIRIO DIAZ 617 CENTRO OAXACA C.P. 68000','@Taquerias Alvaro','XAXXX','PORFIRIO DIAZ','','617','CENTRO','OAXACA DE JUAREZ','OAXACA DE JUAREZ','68000','OAXACA','MEXICO','1','',0,1,0,0,5,'5',0,0,'-1','','0\n\r','',1,0,0);

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
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `corte_declaracion` */

insert  into `corte_declaracion`(`id_declaracion`,`total_efectivo`,`total_tarjeta`,`total_transferencia`,`total_cheque`,`total_nota`,`id_corte`) values (1,'0.00','0.00','0.00','0.00','0.00',1),(2,'0.00','0.00','0.00','0.00','0.00',2);

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
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `corte_detalle` */

insert  into `corte_detalle`(`id_corte_detalle`,`id_corte`,`billete_20`,`billete_50`,`billete_100`,`billete_200`,`billete_500`,`billete_1000`,`moneda_1`,`moneda_2`,`moneda_5`,`moneda_10`,`moneda_50c`,`tarjeta_visa`,`tarjeta_master_card`,`tarjeta_american_express`) values (1,1,'0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00'),(2,2,'0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00','0.00');

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
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `cortes` */

insert  into `cortes`(`id_corte`,`fecha`,`id_empleado_caja`,`nombre_empleado`,`total_ventas`,`total_retiros`,`total_caja`,`body_html`) values (1,'2016-05-29 19:10:16','1','ADMINISTRADOR','1059.00','0.00','1059.00',''),(2,'2016-07-29 23:55:02','1','ADMINISTRADOR','364.00','0.00','364.00','');

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

/*Data for the table `cotizacion` */

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

/*Data for the table `cotizacion_detalle` */

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
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `depositos` */

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

/*Data for the table `detalle_pedido` */

/*Table structure for table `devoluciones` */

DROP TABLE IF EXISTS `devoluciones`;

CREATE TABLE `devoluciones` (
  `id_devolucion` int(11) NOT NULL auto_increment,
  `id_venta` int(11) default NULL,
  `fecha` datetime default NULL,
  `subtotal` decimal(11,2) default NULL,
  `total_iva` decimal(11,2) default NULL,
  `total_otros` decimal(11,2) default NULL,
  `total` decimal(11,2) default NULL,
  `tipo_devolucion` int(1) default '0',
  `id_empleado` int(11) default NULL,
  `bandera_corte_caja` int(11) default '0',
  PRIMARY KEY  (`id_devolucion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `devoluciones` */

/*Table structure for table `devoluciones_detalle` */

DROP TABLE IF EXISTS `devoluciones_detalle`;

CREATE TABLE `devoluciones_detalle` (
  `id_devolucion_detalle` int(11) NOT NULL auto_increment,
  `id_devolucion` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `descripcion` varchar(50) default NULL,
  `unidad` varchar(25) default NULL,
  `cantidad` decimal(11,2) default NULL,
  `total_porcent_iva` decimal(11,2) default NULL,
  `total_porcent_otros` decimal(11,2) default NULL,
  `importe` decimal(11,2) default NULL,
  `precio_unitario` decimal(11,2) default NULL,
  `id_almacen` int(11) default NULL,
  PRIMARY KEY  (`id_devolucion_detalle`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `devoluciones_detalle` */

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

/*Data for the table `devoluciones_proveedor` */

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

/*Data for the table `devoluciones_proveedor_detalle` */

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
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `domicilio` */

insert  into `domicilio`(`id_domicilio`,`calle`,`num_ext`,`num_int`,`colonia`,`municipio`,`cp`,`poblacion`,`estado`,`pais`) values (1,'','','','','','','','',''),(2,'CALLE','','','COLONIA','MUNICIPIO','00000','POBLACION','ESTADO','PAIS'),(3,'Conocido','0','','--','--','68000','---','',''),(4,'Conocido','0','','Centro','--','6800','Oaxaca','',''),(5,'Conocido','0','','--','--','68000','Oaxaca','Oaxaca',''),(6,'--','0','','--','--','0','--','--','-'),(7,'--','--','--','--','--','0','--','','');

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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `empleado` */

insert  into `empleado`(`id_empleado`,`curp`,`id_persona`,`id_domicilio`,`imagen`,`thumb`,`huella`,`id_puesto`,`puesto`,`fecha_alta`,`fecha_modificacion`,`id_sucursal`) values (1,'',1,1,NULL,NULL,NULL,1,'','2016-03-28 09:51:38','2016-03-28 09:51:38',1),(2,'',2,3,NULL,NULL,NULL,1,'',NULL,'2016-04-04 05:11:07',1),(3,'',3,4,NULL,NULL,NULL,2,'',NULL,'2016-04-04 05:12:54',1),(4,'',4,5,NULL,NULL,NULL,3,'',NULL,'2016-04-04 05:14:20',1);

/*Table structure for table `empleado_horario` */

DROP TABLE IF EXISTS `empleado_horario`;

CREATE TABLE `empleado_horario` (
  `id_empleado` int(11) default NULL,
  `hora_entrada` time default NULL,
  `hora_salida` time default NULL,
  `tolerancia` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `empleado_horario` */

insert  into `empleado_horario`(`id_empleado`,`hora_entrada`,`hora_salida`,`tolerancia`) values (2,'17:10:22','17:10:22',0),(3,'17:12:06','17:12:06',0),(4,'17:12:06','17:12:06',0);

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

/*Data for the table `empleado_jornada` */

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
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Data for the table `empleado_opciones` */

insert  into `empleado_opciones`(`id_empleado_opciones`,`id_empleado`,`posicion`,`id_opcion`,`opcion`,`extra`) values (1,1,1,2,'Cuentas Bancarias',''),(2,1,2,3,'Impuestos',''),(3,1,3,5,'Categorias',''),(4,1,4,6,'Sucursales',''),(5,1,5,7,'Almacenes',''),(6,1,6,8,'Directorio',''),(7,1,7,9,'Cotizaciones',''),(8,1,8,17,'Conversiones',''),(9,1,9,18,'Programación de pedidos','');

/*Table structure for table `empleado_puesto` */

DROP TABLE IF EXISTS `empleado_puesto`;

CREATE TABLE `empleado_puesto` (
  `id_puesto` int(11) NOT NULL auto_increment,
  `nombre` varchar(100) NOT NULL,
  PRIMARY KEY  (`id_puesto`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `empleado_puesto` */

insert  into `empleado_puesto`(`id_puesto`,`nombre`) values (1,'ADMINISTRADOR'),(2,'Cajero'),(3,'Encargada');

/*Table structure for table `empleado_tel` */

DROP TABLE IF EXISTS `empleado_tel`;

CREATE TABLE `empleado_tel` (
  `id_telefono` int(11) default '0',
  `id_empleado` int(11) default '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `empleado_tel` */

/*Table structure for table `empleados` */

DROP TABLE IF EXISTS `empleados`;

CREATE TABLE `empleados` (
  `id_sucursal` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  `nombre` varchar(122) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `empleados` */

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
  PRIMARY KEY  (`id_empresa`),
  KEY `FK_proveedor` (`id_domicilio`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `empresa` */

insert  into `empresa`(`id_empresa`,`razon_social`,`alias`,`id_domicilio`,`url`,`rfc`,`email`,`tel_fijo`,`tel_cel`,`whatsapp`) values (1,'PÚBLICO EN GENERAL','PÚBLICO EN GENERAL',1,'','','','','',''),(2,'San Pablo','Centro Cultural San Pablo',6,'','XAXXX','','','',''),(3,'ABARROTES LA SOLEDA','ABARROTES LA SOLEDAD',7,'','XAXXX','','','','');

/*Table structure for table `empresa_contacto` */

DROP TABLE IF EXISTS `empresa_contacto`;

CREATE TABLE `empresa_contacto` (
  `id_persona` int(11) default NULL,
  `id_empresa` int(11) default NULL,
  KEY `FK_empresa_contacto` (`id_empresa`),
  KEY `FK_empresa_contacto1` (`id_persona`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `empresa_contacto` */

/*Table structure for table `empresa_tel` */

DROP TABLE IF EXISTS `empresa_tel`;

CREATE TABLE `empresa_tel` (
  `id_empresa` int(11) default '0',
  `id_telefono` int(11) default '0'
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `empresa_tel` */

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

/*Data for the table `factura` */

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

/*Data for the table `factura_compra` */

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

/*Data for the table `factura_compra_detalle` */

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

/*Data for the table `factura_detalle` */

/*Table structure for table `factura_electronica` */

DROP TABLE IF EXISTS `factura_electronica`;

CREATE TABLE `factura_electronica` (
  `id_factura_electronica` int(10) NOT NULL auto_increment,
  `serie` varchar(50) default '',
  `fecha` datetime default NULL,
  `numero` varchar(20) default '',
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
  `id_pago_forma` int(11) default '0',
  `id_metodo_pago` int(11) default '0',
  `condiciones_pago` varchar(200) default '',
  `pago_cuenta` varchar(20) default 'No Aplica',
  `estatus_timbrado` varchar(20) default 'PENDIENTE',
  `id_factura_general` int(11) default '0',
  PRIMARY KEY  (`id_factura_electronica`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `factura_electronica` */

/*Table structure for table `factura_electronica_detalle` */

DROP TABLE IF EXISTS `factura_electronica_detalle`;

CREATE TABLE `factura_electronica_detalle` (
  `id_detalle` int(10) NOT NULL auto_increment,
  `id_factura_electronica` int(10) default NULL,
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
  KEY `FK_id_factura_electronica` (`id_factura_electronica`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `factura_electronica_detalle` */

/*Table structure for table `factura_general` */

DROP TABLE IF EXISTS `factura_general`;

CREATE TABLE `factura_general` (
  `id_factura_general` int(11) NOT NULL auto_increment,
  `descripcion` varchar(500) default '',
  PRIMARY KEY  (`id_factura_general`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `factura_general` */

/*Table structure for table `forma_pago` */

DROP TABLE IF EXISTS `forma_pago`;

CREATE TABLE `forma_pago` (
  `id_pago` int(11) default NULL,
  `descripcion` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `forma_pago` */

insert  into `forma_pago`(`id_pago`,`descripcion`) values (0,'Efectivo'),(1,'Trasferencia'),(2,'Cheque'),(3,'Nota Credito'),(4,'Tarjeta Bancaria'),(5,'Cupones');

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

/*Data for the table `id_pedido_clientes` */

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
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `impuesto` */

insert  into `impuesto`(`id_impuesto`,`id_catalogo`,`nombre`,`alias`,`porcentaje`,`fecha_alta`,`fecha_baja`) values (1,1,'IVA 16%','IVA 16%','16.00','2016-08-04 21:01:52',NULL),(2,1,'IVA 0%','IVA 0%','0.00','2016-08-04 21:01:57',NULL);

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

/*Data for the table `impuesto_catalogo` */

insert  into `impuesto_catalogo`(`id_catalogo`,`nombre`,`fecha_alta`,`fecha_baja`) values (1,'IMPUESTO AL VALOR AG','2016-08-04 21:00:42',NULL);

/*Table structure for table `mesas` */

DROP TABLE IF EXISTS `mesas`;

CREATE TABLE `mesas` (
  `id_mesa` int(11) NOT NULL auto_increment,
  `id_area` int(11) default '0',
  `nombre` varchar(15) default '',
  PRIMARY KEY  (`id_mesa`)
) ENGINE=MyISAM AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

/*Data for the table `mesas` */

insert  into `mesas`(`id_mesa`,`id_area`,`nombre`) values (1,1,'MESA 01'),(2,1,'MESA 02'),(3,1,'MESA 03'),(4,1,'MESA 04'),(5,1,'MESA 05'),(6,1,'MESA 06'),(7,1,'MESA 07'),(8,1,'MESA 08'),(9,1,'MESA 09'),(10,1,'MESA 10'),(11,1,'MESA 11'),(12,1,'MESA 12'),(13,1,'MESA 13'),(14,1,'MESA 14'),(15,1,'MESA 15'),(16,1,'MESA 16'),(17,1,'MESA 17'),(18,1,'MESA 18'),(19,1,'MESA 19'),(20,1,'MESA 20'),(21,1,'MESA 21'),(22,1,'MESA 22'),(23,1,'MESA 23'),(24,1,'MESA 24');

/*Table structure for table `meseros` */

DROP TABLE IF EXISTS `meseros`;

CREATE TABLE `meseros` (
  `id_mesero` int(11) NOT NULL auto_increment,
  `clave` varchar(20) default '',
  `nombre` varchar(20) default '',
  `contraseña` varchar(20) default '',
  `imagen` blob,
  PRIMARY KEY  (`id_mesero`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `meseros` */

insert  into `meseros`(`id_mesero`,`clave`,`nombre`,`contraseña`,`imagen`) values (1,'001','JORGE','JORGE',NULL),(2,'002','ALEJANDRO','ALEJANDRO',NULL),(3,'003','PEDRO','PEDRO',NULL),(4,'004','GEORGINA','GEORGINA',NULL);

/*Table structure for table `metodo_pago` */

DROP TABLE IF EXISTS `metodo_pago`;

CREATE TABLE `metodo_pago` (
  `id_metodo_pago` int(11) NOT NULL,
  `nombre` varchar(100) default NULL,
  PRIMARY KEY  (`id_metodo_pago`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `metodo_pago` */

insert  into `metodo_pago`(`id_metodo_pago`,`nombre`) values (0,'Pago en una sola exhibicion');

/*Table structure for table `modificadores` */

DROP TABLE IF EXISTS `modificadores`;

CREATE TABLE `modificadores` (
  `id_modificador` int(11) NOT NULL auto_increment,
  `nombre` varchar(50) default NULL,
  PRIMARY KEY  (`id_modificador`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `modificadores` */

insert  into `modificadores`(`id_modificador`,`nombre`) values (1,'TIPO'),(2,'CERVEZA'),(3,'CARNE');

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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `moneda` */

insert  into `moneda`(`id_moneda`,`nombre`,`nombre_corto`,`valor`,`siglas`,`rss`,`fecha_modificacion`) values (1,'Peso mexicano','Peso(s)','1.00','MXN',0,'2016-03-28'),(2,'Dolar estadounidense','Dolar(es)','12.50','USD',1,'2016-03-28'),(3,'Euro','Euro(s)','17.56','EUR',1,'2016-03-28');

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

/*Data for the table `moviles` */

/*Table structure for table `nota_credito` */

DROP TABLE IF EXISTS `nota_credito`;

CREATE TABLE `nota_credito` (
  `id_nota_credito` int(10) NOT NULL auto_increment,
  `serie` varchar(50) default '',
  `fecha` datetime default NULL,
  `folio` varchar(20) default '',
  `descripcion` varchar(50) default '',
  `importe` decimal(10,2) default NULL,
  `subtotal` decimal(10,2) default NULL,
  `iva` decimal(10,2) default NULL,
  `total` decimal(10,2) default NULL,
  `id_cliente` int(10) default NULL,
  `id_empleado` int(10) default NULL,
  `estatus` varchar(20) default 'PENDIENTE',
  `id_pago_forma` int(11) default '0',
  `id_metodo_pago` int(11) default '0',
  `condiciones_pago` varchar(200) default '',
  `pago_cuenta` varchar(20) default 'No Aplica',
  `estatus_timbrado` varchar(20) default 'PENDIENTE',
  PRIMARY KEY  (`id_nota_credito`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `nota_credito` */

/*Table structure for table `nota_credito_detalle` */

DROP TABLE IF EXISTS `nota_credito_detalle`;

CREATE TABLE `nota_credito_detalle` (
  `id_nota_credito_detalle` int(10) NOT NULL auto_increment,
  `id_nota_credito` int(10) default NULL,
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
  PRIMARY KEY  (`id_nota_credito_detalle`),
  KEY `FK_id_factura_electronica` (`id_nota_credito`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `nota_credito_detalle` */

insert  into `nota_credito_detalle`(`id_nota_credito_detalle`,`id_nota_credito`,`id_producto`,`descripcion`,`cantidad`,`unidad`,`total_porcent_iva`,`total_porcent_otros`,`impuesto`,`precio_venta`,`descuento`,`precio_unitario`,`importe`) values (2,1,9,'ALAMBRE\r\n','1.000','PIEZA','0.00','0.00','IVA 0%','350.00','0.00','350.00','350.00'),(3,2,8,'AGUA PARA NESCAFE\r\n','1.000','PIEZA','0.00','0.00','IVA 0%','15.00','0.00','15.00','15.00'),(4,3,10,'ATOLE\r\n','1.000','PIEZA','0.00','0.00','IVA 0%','500.00','0.00','500.00','500.00');

/*Table structure for table `nota_credito_general` */

DROP TABLE IF EXISTS `nota_credito_general`;

CREATE TABLE `nota_credito_general` (
  `id_nota_credito_general` int(11) NOT NULL auto_increment,
  `descripcion` varchar(500) default '',
  `id_nota_credito` int(11) default '0',
  PRIMARY KEY  (`id_nota_credito_general`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `nota_credito_general` */

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
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `orden_comedor` */

insert  into `orden_comedor`(`id_orden`,`id_area`,`folio`,`cuenta`,`id_mesero`,`num_personas`,`apertura`,`cierre`,`id_cliente`,`estatus`,`id_venta`) values (1,1,'','Mesa 50',1,2,'2016-05-29 09:58:31','2016-05-29 10:04:56','1','CERRADA',2),(2,1,'','Mesa25',2,3,'2016-05-29 10:09:35','2016-05-29 10:10:54','1','CERRADA',3);

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
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

/*Data for the table `orden_comedor_detalle` */

insert  into `orden_comedor_detalle`(`id_orden_comedor_detalle`,`id_orden_comedor`,`id_empleado`,`id_producto`,`descripcion`,`unidad`,`cantidad`,`precio`,`impuesto`,`importe`,`id_venta`,`total_iva`,`total_otros`,`nombre_impuestos`,`id_cliente`,`id_almacen`,`descuento`,`desc_global_porcent`,`desc_global_importe`,`observaciones`,`modificador`,`id_producto_modificador`) values (1,1,1,6,'AGUA JAMAICA','PIEZA','1.000','12.00',NULL,'12.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(2,1,1,109,'JARRA  NORMAL JAMAICA','PIEZA','1.000','60.00',NULL,'60.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(3,1,1,44,'PAY DE QUESO CON CREMA','PIEZA','1.000','36.00',NULL,'36.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(4,1,1,82,'TACO DE OREJA','PIEZA','1.000','10.00',NULL,'10.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(5,1,1,62,'QUESILLO EXTRA TACO ESPEC','PIEZA','1.000','5.00',NULL,'5.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(6,1,1,32,'MICHELADA','PIEZA','2.000','38.00',NULL,'76.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(7,1,1,75,'>>VICTORIA','PIEZA','2.000','0.00',NULL,'0.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00',NULL,1,32),(8,2,1,14,'CHAMPIÑONES EXTRA PARA PR','PIEZA','1.000','18.00',NULL,'18.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(9,2,1,74,'VEGETARIANO','PIEZA','1.000','75.00',NULL,'75.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(10,2,1,17,'CHOCOLATE DE LECHE','PIEZA','1.000','18.00',NULL,'18.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(11,2,1,122,'ORDEN CARNE 1/4 PASTOR','PIEZA','1.000','65.00',NULL,'65.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(12,2,1,111,'JARRA JUMBO JAMAICA','PIEZA','1.000','70.00',NULL,'70.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(13,2,1,101,'TOSTADA DE QUESILLO','PIEZA','1.000','30.00',NULL,'30.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(14,2,1,56,'POZOLE EMPERADOR ROJO GRA','PIEZA','1.000','65.00',NULL,'65.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(15,2,1,88,'TACO DE BISTEC','PIEZA','1.000','11.00',NULL,'11.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(16,2,1,49,'PEPSI LIGHT','PIEZA','6.000','18.00',NULL,'108.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(17,2,1,13,'CAFÉ','PIEZA','3.000','18.00',NULL,'54.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(18,2,1,94,'TORTA DE BISTEC','PIEZA','1.000','50.00',NULL,'50.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(19,2,1,32,'MICHELADA','PIEZA','5.000','38.00',NULL,'190.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(20,2,1,19,'>>CORONA LIGHT','PIEZA','5.000','0.00',NULL,'0.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00',NULL,1,32),(21,2,1,32,'MICHELADA','PIEZA','2.000','38.00',NULL,'76.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(22,2,1,35,'>>MODELO ESPECIAL','PIEZA','2.000','0.00',NULL,'0.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00',NULL,1,32),(23,2,1,99,'TOSTADA DE CABEZA','PIEZA','1.000','30.00',NULL,'30.0000',NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0);

/*Table structure for table `orden_comedor_mesa` */

DROP TABLE IF EXISTS `orden_comedor_mesa`;

CREATE TABLE `orden_comedor_mesa` (
  `id_orden_comedor_mesa` int(11) NOT NULL auto_increment,
  `id_mesa` int(11) default '0',
  `id_orden` int(11) default '0',
  PRIMARY KEY  (`id_orden_comedor_mesa`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `orden_comedor_mesa` */

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

/*Data for the table `orden_compra` */

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

/*Data for the table `orden_compra_detalle` */

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

/*Data for the table `pagos_compras` */

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
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Data for the table `pagos_ventas` */

insert  into `pagos_ventas`(`id_cobro`,`id_venta`,`importe`,`cobro`,`cambio`,`id_forma_pago`,`fecha`,`fecha_cobro`,`fecha_cancelacion`,`id_cuenta_receptor`,`banco_cliente`,`cuenta_cliente`,`banco_receptor`,`cuenta_receptor`,`num_referencia`,`num_cheque`,`num_tarjeta`,`nombre_cheque`,`status_cheque`,`num_notacredito`,`nombre_notacredito`,`id_empleado_caja`,`id_empleado_validacion`,`status`,`afecta_caja`,`es_abono`,`id_corte`) values (1,2,199.00,200.00,1.00,0,'2016-05-29 10:04:59','2016-05-29 10:04:59',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,1),(2,3,860.00,860.00,0.00,0,'2016-05-29 10:10:57','2016-05-29 10:10:57',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,1),(3,5,60.00,60.00,0.00,0,'2016-07-27 21:11:21','2016-07-27 21:11:21',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(4,6,30.00,30.00,0.00,0,'2016-07-27 21:11:33','2016-07-27 21:11:33',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(5,7,60.00,90.00,30.00,0,'2016-07-27 21:11:51','2016-07-27 21:11:51',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(6,8,18.00,20.00,2.00,0,'2016-07-27 21:19:27','2016-07-27 21:19:27',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(7,9,54.00,100.00,46.00,0,'2016-07-27 21:19:41','2016-07-27 21:19:41',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(8,10,18.00,20.00,2.00,0,'2016-07-28 23:22:09','2016-07-28 23:22:09',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(9,11,46.00,50.00,4.00,0,'2016-07-28 23:22:16','2016-07-28 23:22:16',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(10,12,60.00,90.00,30.00,0,'2016-07-29 23:54:11','2016-07-29 23:54:11',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(11,13,18.00,20.00,2.00,0,'2016-07-29 23:54:21','2016-07-29 23:54:21',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,2),(12,14,18.00,20.00,2.00,0,'2016-08-02 20:12:20','2016-08-02 20:12:20',NULL,0,NULL,NULL,NULL,NULL,NULL,0,NULL,NULL,'ACTIVO',0,NULL,1,0,'ACTIVO',1,0,0);

/*Table structure for table `paquete_modificador_producto` */

DROP TABLE IF EXISTS `paquete_modificador_producto`;

CREATE TABLE `paquete_modificador_producto` (
  `id_paquete_modificador_producto` int(11) NOT NULL auto_increment,
  `id_paquete` int(11) default NULL,
  `id_modificador` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(9,2) default NULL,
  PRIMARY KEY  (`id_paquete_modificador_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;

/*Data for the table `paquete_modificador_producto` */

insert  into `paquete_modificador_producto`(`id_paquete_modificador_producto`,`id_paquete`,`id_modificador`,`id_producto`,`cantidad`) values (1,70,1,79,'1.00'),(2,70,1,80,'1.00'),(3,70,1,81,'1.00'),(4,70,1,82,'1.00'),(5,70,1,83,'1.00'),(6,70,1,84,'1.00'),(7,70,1,85,'1.00'),(8,70,1,86,'1.00'),(9,32,2,18,'1.00'),(10,32,2,19,'1.00'),(11,32,2,35,'1.00'),(12,32,2,37,'1.00'),(13,32,2,75,'1.00'),(14,68,2,18,'1.00'),(15,68,2,75,'1.00'),(16,68,2,19,'1.00'),(17,68,2,35,'1.00'),(18,68,2,37,'1.00'),(19,52,3,134,'1.00'),(20,52,3,136,'1.00'),(21,52,3,135,'1.00'),(22,52,3,140,'1.00'),(23,58,3,134,'1.00'),(24,58,3,136,'1.00'),(25,58,3,135,'1.00'),(26,58,3,140,'1.00'),(27,53,3,137,'1.00'),(28,53,3,138,'1.00'),(29,53,3,139,'1.00'),(30,53,3,141,'1.00'),(31,57,3,137,'1.00'),(32,57,3,138,'1.00'),(33,57,3,139,'1.00'),(34,57,3,141,'1.00');

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

/*Data for the table `pedido_clientes` */

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

/*Data for the table `pedido_prog` */

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

/*Data for the table `pedido_prog_detalle` */

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
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `perfil` */

insert  into `perfil`(`id_perfil`,`nombre`,`usuarios`,`cuentas_bancarias`,`impuestos`,`productos`,`catalogo`,`sucursal`,`almacenes`,`directorio`,`directorio_soloalta`,`cotizaciones`,`compras`,`compras_rapidas`,`pedidos`,`caja`,`pagos`,`facturacion`,`punto_venta`,`cobros_creditos`,`corte_caja`,`corte_x`,`cancelar_venta`,`cancelar_pagos`,`precio_especial`,`regalias`,`cambio_precio`,`cobro_terminal`,`pago_proveedores_terminal`,`recepcion_producto_terminal`,`ajuste_inventario`,`clasificacion_productos`,`favoritos`,`conversiones`,`programacion_pedidos`,`vehiculos`,`repartidores`,`catalogo_precios`,`perfiles_impresion`,`cfg_conversiones`,`cfg_empresa`,`traspasos_env`,`traspasos_recep`,`reporteador`,`cfg_descuentos`,`cfg_godmode`,`devoluciones`,`cfg_correo`,`ajuste_conversiones`,`cancelar_apartado`) values (1,'ADMINISTRADOR',1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1),(2,'ENCARGADA',0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,1,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0),(3,'CAJA',0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);

/*Table structure for table `perfil_empleado` */

DROP TABLE IF EXISTS `perfil_empleado`;

CREATE TABLE `perfil_empleado` (
  `id_perfil_empleado` int(11) NOT NULL auto_increment,
  `id_perfil` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  PRIMARY KEY  (`id_perfil_empleado`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `perfil_empleado` */

insert  into `perfil_empleado`(`id_perfil_empleado`,`id_perfil`,`id_empleado`) values (1,1,1),(2,1,2),(3,2,4),(4,3,3);

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

/*Data for the table `perfil_impresion` */

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

/*Data for the table `perfil_impresion_campos` */

/*Table structure for table `perfil_proveedor` */

DROP TABLE IF EXISTS `perfil_proveedor`;

CREATE TABLE `perfil_proveedor` (
  `id_perfil_proveedor` int(11) NOT NULL auto_increment,
  `id_perfil` int(11) default NULL,
  `id_proveedor` int(11) default NULL,
  PRIMARY KEY  (`id_perfil_proveedor`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `perfil_proveedor` */

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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `persona` */

insert  into `persona`(`id_persona`,`titulo`,`nombre`,`ap_paterno`,`ap_materno`,`rfc`,`email`,`fecha_nacimiento`,`alias`,`tel_fijo`,`tel_cel`,`whatsapp`) values (1,'ING.','ADMINISTRADOR','SUPER','','','','2016-03-28','ADMINISTRADOR','','',''),(2,'','Anali','Acuña','Ochoa','XAXXX','',NULL,'Anali','','',''),(3,'','Jesus','--','--','XAXXX','',NULL,'Jesus','','',''),(4,'','Georgina','Maldonado','Ruiz','XAXXX','',NULL,'Georgina','','','');

/*Table structure for table `persona_tel` */

DROP TABLE IF EXISTS `persona_tel`;

CREATE TABLE `persona_tel` (
  `id_persona` int(11) default NULL,
  `id_telefono` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `persona_tel` */

/*Table structure for table `precio_nombre` */

DROP TABLE IF EXISTS `precio_nombre`;

CREATE TABLE `precio_nombre` (
  `id_nombre_precio` int(2) NOT NULL auto_increment,
  `nombre` varchar(25) default NULL,
  PRIMARY KEY  (`id_nombre_precio`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `precio_nombre` */

insert  into `precio_nombre`(`id_nombre_precio`,`nombre`) values (1,'Precio público');

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

/*Data for the table `prefactura` */

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

/*Data for the table `prefactura_detalle` */

/*Table structure for table `producto` */

DROP TABLE IF EXISTS `producto`;

CREATE TABLE `producto` (
  `id_producto` int(11) NOT NULL auto_increment,
  `nombre` text NOT NULL,
  `codigo` varchar(30) default NULL,
  `id_proveedor` int(11) default NULL,
  `medida` int(10) default NULL,
  `id_unidad` int(3) default NULL,
  `venta_peso` int(1) default '0',
  `id_categoria` int(11) default '1',
  `descripcion` text,
  `costo` decimal(10,2) default '0.00',
  `peso` decimal(10,3) default '0.000',
  `id_marca` int(5) default NULL,
  `modelo` varchar(50) default '',
  `codigo_fabricante` varchar(50) default '',
  `tiempo_entrega` int(2) default '5',
  `publicado` tinyint(1) default '0',
  `tags` text,
  `imagen` blob,
  `thumb` blob,
  `visitas` int(5) default '0',
  `id_almacen` int(11) default '0',
  `fecha_alta` datetime NOT NULL,
  `fecha_modificacion` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `favorito` int(2) unsigned NOT NULL default '0',
  `favorito_cat` int(2) default '0',
  `invalidar_intervalos` int(1) default '0',
  `paquete` int(1) default '0',
  `id_producto_talla` int(11) default '1',
  `id_producto_color` int(11) default '1',
  PRIMARY KEY  (`id_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=146 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto` */


/*Table structure for table `producto_cat_imp` */

DROP TABLE IF EXISTS `producto_cat_imp`;

CREATE TABLE `producto_cat_imp` (
  `id_producto` int(11) default NULL,
  `id_catalogo` int(11) default NULL,
  KEY `FK_prod_cat_imp` (`id_producto`),
  KEY `FK_prod_cat_imp_cat` (`id_catalogo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_cat_imp` */

/*Table structure for table `producto_color` */

DROP TABLE IF EXISTS `producto_color`;

CREATE TABLE `producto_color` (
  `id_producto_color` int(11) NOT NULL auto_increment,
  `color` varchar(100) default '',
  PRIMARY KEY  (`id_producto_color`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `producto_color` */

insert  into `producto_color`(`id_producto_color`,`color`) values (1,'NO APLICA');

/*Table structure for table `producto_compuesto` */

DROP TABLE IF EXISTS `producto_compuesto`;

CREATE TABLE `producto_compuesto` (
  `id_producto` int(11) default NULL,
  `id_articulo` int(11) default NULL,
  `num_articulo` decimal(11,2) default NULL,
  KEY `FK_producto_compuesto` (`id_producto`),
  KEY `FK_producto_compuesto1` (`id_articulo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_compuesto` */

/*Table structure for table `producto_costo` */

DROP TABLE IF EXISTS `producto_costo`;

CREATE TABLE `producto_costo` (
  `id_producto_costo` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `costo` decimal(9,2) default NULL,
  `fecha` datetime default NULL,
  PRIMARY KEY  (`id_producto_costo`)
) ENGINE=MyISAM AUTO_INCREMENT=159 DEFAULT CHARSET=utf8;

/*Data for the table `producto_costo` */

insert  into `producto_costo`(`id_producto_costo`,`id_producto`,`costo`,`fecha`) values (1,1,'30.00','2016-03-28 11:51:37'),(2,2,'5.00','2016-03-28 11:51:37'),(3,3,'5.00','2016-03-28 11:51:37'),(4,4,'20.00','2016-03-28 11:51:37'),(5,5,'16.00','2016-03-28 11:51:37'),(6,6,'12.00','2016-03-28 11:51:37'),(7,7,'18.00','2016-03-28 11:51:37'),(8,8,'15.00','2016-03-28 11:51:37'),(9,9,'70.00','2016-03-28 11:51:37'),(10,10,'23.00','2016-03-28 11:51:37'),(11,11,'18.00','2016-03-28 11:51:37'),(12,12,'28.00','2016-03-28 11:51:37'),(13,13,'18.00','2016-03-28 11:51:37'),(14,14,'18.00','2016-03-28 11:51:37'),(15,15,'15.00','2016-03-28 11:51:37'),(16,16,'18.00','2016-03-28 11:51:37'),(17,17,'18.00','2016-03-28 11:51:37'),(18,18,'28.00','2016-03-28 11:51:37'),(19,19,'28.00','2016-03-28 11:51:37'),(20,20,'32.00','2016-03-28 11:51:37'),(21,21,'50.00','2016-03-28 11:51:37'),(22,22,'18.00','2016-03-28 11:51:37'),(23,23,'70.00','2016-03-28 11:51:37'),(24,24,'60.00','2016-03-28 11:51:37'),(25,25,'18.00','2016-03-28 11:51:37'),(26,26,'15.00','2016-03-28 11:51:37'),(27,27,'15.00','2016-03-28 11:51:37'),(28,28,'15.00','2016-03-28 11:51:37'),(29,29,'18.00','2016-03-28 11:51:37'),(30,30,'18.00','2016-03-28 11:51:37'),(31,31,'70.00','2016-03-28 11:51:37'),(32,32,'38.00','2016-03-28 11:51:37'),(33,33,'18.00','2016-03-28 11:51:37'),(34,34,'18.00','2016-03-28 11:51:37'),(35,35,'33.00','2016-03-28 11:51:37'),(36,36,'70.00','2016-03-28 11:51:37'),(37,37,'33.00','2016-03-28 11:51:37'),(38,38,'260.00','2016-03-28 11:51:37'),(39,39,'15.00','2016-03-28 11:51:37'),(40,40,'10.00','2016-03-28 11:51:37'),(41,41,'10.00','2016-03-28 11:51:37'),(42,42,'36.00','2016-03-28 11:51:37'),(43,43,'18.00','2016-03-28 11:51:37'),(44,44,'36.00','2016-03-28 11:51:37'),(45,45,'36.00','2016-03-28 11:51:38'),(46,46,'36.00','2016-03-28 11:51:38'),(47,47,'18.00','2016-03-28 11:51:38'),(48,48,'18.00','2016-03-28 11:51:38'),(49,49,'18.00','2016-03-28 11:51:38'),(50,50,'70.00','2016-03-28 11:51:38'),(51,51,'20.00','2016-03-28 11:51:38'),(52,52,'55.00','2016-03-28 11:51:38'),(53,53,'45.00','2016-03-28 11:51:38'),(54,54,'65.00','2016-03-28 11:51:38'),(55,55,'55.00','2016-03-28 11:51:38'),(56,56,'65.00','2016-03-28 11:51:38'),(57,57,'55.00','2016-03-28 11:51:38'),(58,58,'55.00','2016-03-28 11:51:38'),(59,59,'45.00','2016-03-28 11:51:38'),(60,60,'26.00','2016-03-28 11:51:38'),(61,61,'5.00','2016-03-28 11:51:38'),(62,62,'4.00','2016-03-28 11:51:38'),(63,63,'50.00','2016-03-28 11:51:38'),(64,64,'55.00','2016-03-28 11:51:38'),(65,65,'18.00','2016-03-28 11:51:38'),(66,66,'18.00','2016-03-28 11:51:38'),(67,67,'18.00','2016-03-28 11:51:38'),(68,68,'1.00','2016-03-28 11:51:38'),(69,69,'70.00','2016-03-28 11:51:38'),(70,70,'1.00','2016-03-28 11:51:38'),(71,71,'18.00','2016-03-28 11:51:38'),(72,72,'1.00','2016-03-28 11:51:38'),(73,73,'1.00','2016-03-28 11:51:38'),(74,74,'70.00','2016-03-28 11:51:38'),(75,75,'28.00','2016-03-28 11:51:38'),(76,76,'130.00','2016-03-28 12:43:24'),(77,77,'65.00','2016-03-28 12:44:39'),(78,78,'195.00','2016-03-28 12:45:07'),(79,79,'1.00','2016-03-28 12:50:16'),(80,80,'1.00','2016-03-28 12:50:50'),(81,81,'1.00','2016-03-28 12:51:24'),(82,82,'1.00','2016-03-28 12:52:30'),(83,83,'1.00','2016-03-28 12:52:44'),(84,84,'1.00','2016-03-28 12:53:12'),(85,85,'1.00','2016-03-28 12:55:15'),(86,86,'1.00','2016-03-28 12:55:42'),(87,87,'10.00','2016-03-28 01:13:08'),(88,88,'10.00','2016-03-28 01:13:37'),(89,89,'50.00','2016-03-28 01:26:17'),(90,90,'0.00','2016-03-28 01:26:38'),(91,90,'50.00','2016-03-28 01:26:43'),(92,91,'50.00','2016-03-28 01:27:03'),(93,92,'50.00','2016-03-28 01:27:24'),(94,93,'50.00','2016-03-28 01:27:54'),(95,94,'50.00','2016-03-28 01:28:22'),(96,95,'0.00','2016-03-28 01:29:39'),(97,95,'50.00','2016-03-28 01:29:54'),(98,96,'50.00','2016-03-28 01:30:14'),(99,97,'0.00','2016-03-28 01:31:18'),(100,97,'50.00','2016-03-28 01:31:24'),(101,98,'30.00','2016-03-28 01:42:49'),(102,99,'30.00','2016-03-28 01:43:08'),(103,100,'30.00','2016-03-28 01:43:35'),(104,101,'30.00','2016-03-28 01:47:11'),(105,102,'30.00','2016-03-28 01:48:38'),(106,103,'30.00','2016-03-28 01:49:01'),(107,104,'30.00','2016-03-28 01:49:32'),(108,105,'30.00','2016-03-28 01:50:04'),(109,106,'30.00','2016-03-28 01:50:27'),(110,107,'12.00','2016-03-28 02:08:33'),(111,108,'0.00','2016-03-28 02:09:46'),(112,109,'60.00','2016-03-28 02:12:43'),(113,110,'60.00','2016-03-28 02:14:04'),(114,111,'70.00','2016-03-28 02:18:34'),(115,112,'70.00','2016-03-28 02:19:27'),(116,113,'30.00','2016-03-28 02:30:04'),(117,114,'30.00','2016-03-28 02:31:05'),(118,79,'10.00','2016-03-29 01:51:32'),(119,80,'10.00','2016-03-29 01:51:48'),(120,81,'10.00','2016-03-29 01:52:01'),(121,82,'10.00','2016-03-29 01:54:43'),(122,83,'10.00','2016-03-29 01:54:55'),(123,84,'10.00','2016-03-29 01:55:09'),(124,85,'10.00','2016-03-29 01:55:22'),(125,86,'10.00','2016-03-29 01:55:33'),(126,115,'23.00','2016-04-04 05:42:38'),(127,116,'18.00','2016-04-04 05:43:35'),(128,117,'55.00','2016-04-04 05:46:08'),(129,118,'55.00','2016-04-04 05:47:13'),(130,68,'38.00','2016-04-04 05:48:38'),(131,119,'32.00','2016-04-04 06:01:34'),(132,120,'32.00','2016-04-04 06:04:26'),(133,121,'32.00','2016-04-04 06:04:44'),(134,122,'65.00','2016-04-04 06:06:27'),(135,123,'130.00','2016-04-04 06:06:51'),(136,124,'230.00','2016-04-04 06:07:22'),(137,125,'65.00','2016-04-04 06:07:50'),(138,126,'130.00','2016-04-04 06:08:20'),(139,127,'230.00','2016-04-04 06:08:43'),(140,127,'260.00','2016-04-04 06:08:48'),(141,128,'65.00','2016-04-04 06:09:13'),(142,129,'130.00','2016-04-04 06:09:55'),(143,130,'260.00','2016-04-04 06:10:17'),(144,131,'65.00','2016-04-04 06:10:38'),(145,132,'130.00','2016-04-04 06:11:09'),(146,133,'260.00','2016-04-04 06:11:36'),(147,134,'0.00','2016-04-05 09:28:33'),(148,135,'0.00','2016-04-05 09:28:58'),(149,136,'0.00','2016-04-05 09:29:24'),(150,137,'0.00','2016-04-05 09:31:23'),(151,138,'0.00','2016-04-05 09:31:52'),(152,139,'0.00','2016-04-05 09:32:20'),(153,140,'0.00','2016-04-05 09:33:12'),(154,141,'0.00','2016-04-05 09:33:32'),(155,142,'0.00','2016-04-05 10:04:45'),(156,143,'0.00','2016-04-05 10:05:02'),(157,144,'0.00','2016-04-05 10:05:27'),(158,145,'0.00','2016-04-05 10:05:53');

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

/*Data for the table `producto_equivalente` */

/*Table structure for table `producto_marca` */

DROP TABLE IF EXISTS `producto_marca`;

CREATE TABLE `producto_marca` (
  `id_marca` int(5) NOT NULL auto_increment,
  `nombre` varchar(20) default NULL,
  PRIMARY KEY  (`id_marca`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_marca` */

insert  into `producto_marca`(`id_marca`,`nombre`) values (1,'');

/*Table structure for table `producto_modificador` */

DROP TABLE IF EXISTS `producto_modificador`;

CREATE TABLE `producto_modificador` (
  `id_producto_modificador` int(11) NOT NULL auto_increment,
  `id_producto` int(11) default NULL,
  `id_modificador` int(11) default NULL,
  PRIMARY KEY  (`id_producto_modificador`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `producto_modificador` */

insert  into `producto_modificador`(`id_producto_modificador`,`id_producto`,`id_modificador`) values (1,70,1),(2,32,2),(3,68,2),(4,52,3),(5,58,3),(6,53,3),(7,57,3);

/*Table structure for table `producto_paquete` */

DROP TABLE IF EXISTS `producto_paquete`;

CREATE TABLE `producto_paquete` (
  `id_producto` int(11) default NULL,
  KEY `FK_producto_paquete` (`id_producto`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_paquete` */

/*Table structure for table `producto_precio` */

DROP TABLE IF EXISTS `producto_precio`;

CREATE TABLE `producto_precio` (
  `id_precio` int(11) NOT NULL auto_increment,
  `precio` decimal(10,2) default NULL,
  `ganacia` decimal(5,2) default NULL,
  `id_nombre_precio` int(2) default NULL,
  `id_producto` int(11) default NULL,
  `fecha_alta` datetime default NULL,
  `fecha_baja` date default NULL,
  PRIMARY KEY  (`id_precio`),
  KEY `FK_producto_precio` (`id_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=282 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_precio` */

insert  into `producto_precio`(`id_precio`,`precio`,`ganacia`,`id_nombre_precio`,`id_producto`,`fecha_alta`,`fecha_baja`) values (137,'30.00','0.00',1,1,'2016-03-28 11:51:37',NULL),(138,'5.00','0.00',1,2,'2016-03-28 11:51:37',NULL),(139,'5.00','0.00',1,3,'2016-03-28 11:51:37',NULL),(140,'20.00','0.00',1,4,'2016-03-28 11:51:37',NULL),(141,'16.00','0.00',1,5,'2016-03-28 11:51:37',NULL),(142,'12.00','0.00',1,6,'2016-03-28 11:51:37',NULL),(143,'18.00','0.00',1,7,'2016-03-28 11:51:37',NULL),(144,'15.00','0.00',1,8,'2016-03-28 11:51:37',NULL),(145,'75.00','7.14',1,9,'2016-03-28 11:51:37',NULL),(146,'23.00','0.00',1,10,'2016-03-28 11:51:37',NULL),(147,'18.00','0.00',1,11,'2016-03-28 11:51:37',NULL),(148,'28.00','0.00',1,12,'2016-03-28 11:51:37',NULL),(149,'18.00','0.00',1,13,'2016-03-28 11:51:37',NULL),(150,'18.00','0.00',1,14,'2016-03-28 11:51:37',NULL),(152,'18.00','0.00',1,16,'2016-03-28 11:51:37',NULL),(153,'18.00','0.00',1,17,'2016-03-28 11:51:37',NULL),(154,'28.00','0.00',1,18,'2016-03-28 11:51:37',NULL),(155,'28.00','0.00',1,19,'2016-03-28 11:51:37',NULL),(156,'32.00','0.00',1,20,'2016-03-28 11:51:37',NULL),(157,'50.00','0.00',1,21,'2016-03-28 11:51:37',NULL),(158,'18.00','0.00',1,22,'2016-03-28 11:51:37',NULL),(159,'70.00','0.00',1,23,'2016-03-28 11:51:37',NULL),(160,'60.00','0.00',1,24,'2016-03-28 11:51:37',NULL),(161,'18.00','0.00',1,25,'2016-03-28 11:51:37',NULL),(162,'15.00','0.00',1,26,'2016-03-28 11:51:37',NULL),(165,'18.00','0.00',1,29,'2016-03-28 11:51:37',NULL),(166,'18.00','0.00',1,30,'2016-03-28 11:51:37',NULL),(167,'75.00','7.14',1,31,'2016-03-28 11:51:37',NULL),(168,'38.00','0.00',1,32,'2016-03-28 11:51:37',NULL),(169,'18.00','0.00',1,33,'2016-03-28 11:51:37',NULL),(170,'18.00','0.00',1,34,'2016-03-28 11:51:37',NULL),(171,'33.00','0.00',1,35,'2016-03-28 11:51:37',NULL),(172,'80.00','14.29',1,36,'2016-03-28 11:51:37',NULL),(173,'33.00','0.00',1,37,'2016-03-28 11:51:37',NULL),(174,'260.00','0.00',1,38,'2016-03-28 11:51:37',NULL),(175,'15.00','0.00',1,39,'2016-03-28 11:51:37',NULL),(176,'10.00','0.00',1,40,'2016-03-28 11:51:37',NULL),(177,'10.00','0.00',1,41,'2016-03-28 11:51:37',NULL),(178,'36.00','0.00',1,42,'2016-03-28 11:51:37',NULL),(179,'18.00','0.00',1,43,'2016-03-28 11:51:37',NULL),(180,'36.00','0.00',1,44,'2016-03-28 11:51:37',NULL),(181,'36.00','0.00',1,45,'2016-03-28 11:51:38',NULL),(182,'36.00','0.00',1,46,'2016-03-28 11:51:38',NULL),(183,'18.00','0.00',1,47,'2016-03-28 11:51:38',NULL),(184,'18.00','0.00',1,48,'2016-03-28 11:51:38',NULL),(185,'18.00','0.00',1,49,'2016-03-28 11:51:38',NULL),(186,'75.00','7.14',1,50,'2016-03-28 11:51:38',NULL),(187,'20.00','0.00',1,51,'2016-03-28 11:51:38',NULL),(188,'55.00','0.00',1,52,'2016-03-28 11:51:38',NULL),(189,'45.00','0.00',1,53,'2016-03-28 11:51:38',NULL),(190,'65.00','0.00',1,54,'2016-03-28 11:51:38',NULL),(191,'55.00','0.00',1,55,'2016-03-28 11:51:38',NULL),(192,'65.00','0.00',1,56,'2016-03-28 11:51:38',NULL),(193,'55.00','0.00',1,57,'2016-03-28 11:51:38',NULL),(194,'55.00','0.00',1,58,'2016-03-28 11:51:38',NULL),(195,'45.00','0.00',1,59,'2016-03-28 11:51:38',NULL),(196,'26.00','0.00',1,60,'2016-03-28 11:51:38',NULL),(197,'5.00','0.00',1,61,'2016-03-28 11:51:38',NULL),(198,'5.00','25.00',1,62,'2016-03-28 11:51:38',NULL),(199,'50.00','0.00',1,63,'2016-03-28 11:51:38',NULL),(200,'55.00','0.00',1,64,'2016-03-28 11:51:38',NULL),(201,'18.00','0.00',1,65,'2016-03-28 11:51:38',NULL),(202,'18.00','0.00',1,66,'2016-03-28 11:51:38',NULL),(203,'18.00','0.00',1,67,'2016-03-28 11:51:38',NULL),(204,'38.00','0.00',1,68,'2016-03-28 11:51:38',NULL),(205,'80.00','14.29',1,69,'2016-03-28 11:51:38',NULL),(207,'18.00','0.00',1,71,'2016-03-28 11:51:38',NULL),(210,'75.00','7.14',1,74,'2016-03-28 11:51:38',NULL),(211,'28.00','0.00',1,75,'2016-03-28 11:51:38',NULL),(212,'130.00','0.00',1,76,'2016-03-28 12:43:24',NULL),(213,'65.00','0.00',1,77,'2016-03-28 12:44:39',NULL),(214,'195.00','0.00',1,78,'2016-03-28 12:45:07',NULL),(215,'10.00','0.00',1,79,'2016-03-28 12:50:16',NULL),(216,'10.00','0.00',1,80,'2016-03-28 12:50:50',NULL),(217,'10.00','0.00',1,81,'2016-03-28 12:51:24',NULL),(218,'10.00','0.00',1,82,'2016-03-28 12:52:30',NULL),(219,'10.00','0.00',1,83,'2016-03-28 12:52:44',NULL),(220,'10.00','0.00',1,84,'2016-03-28 12:53:12',NULL),(221,'10.00','0.00',1,85,'2016-03-28 12:55:15',NULL),(222,'11.00','10.00',1,86,'2016-03-28 12:55:42',NULL),(223,'10.00','0.00',1,87,'2016-03-28 13:13:08',NULL),(224,'11.00','10.00',1,88,'2016-03-28 13:13:37',NULL),(225,'50.00','0.00',1,89,'2016-03-28 13:26:17',NULL),(226,'50.00','0.00',1,90,'2016-03-28 13:26:38',NULL),(227,'50.00','0.00',1,91,'2016-03-28 13:27:03',NULL),(228,'50.00','0.00',1,92,'2016-03-28 13:27:24',NULL),(229,'50.00','0.00',1,93,'2016-03-28 13:27:54',NULL),(230,'50.00','0.00',1,94,'2016-03-28 13:28:22',NULL),(231,'50.00','0.00',1,95,'2016-03-28 13:29:39',NULL),(232,'50.00','0.00',1,96,'2016-03-28 13:30:14',NULL),(233,'50.00','0.00',1,97,'2016-03-28 13:31:18',NULL),(234,'30.00','0.00',1,98,'2016-03-28 13:42:49',NULL),(235,'30.00','0.00',1,99,'2016-03-28 13:43:08',NULL),(236,'30.00','0.00',1,100,'2016-03-28 13:43:35',NULL),(237,'30.00','0.00',1,101,'2016-03-28 13:47:11',NULL),(238,'30.00','0.00',1,102,'2016-03-28 13:48:38',NULL),(239,'30.00','0.00',1,103,'2016-03-28 13:49:01',NULL),(240,'30.00','0.00',1,104,'2016-03-28 13:49:32',NULL),(241,'30.00','0.00',1,105,'2016-03-28 13:50:04',NULL),(242,'30.00','0.00',1,106,'2016-03-28 13:50:27',NULL),(243,'12.00','0.00',1,107,'2016-03-28 14:08:33',NULL),(244,'15.00','0.00',1,108,'2016-03-28 14:09:46',NULL),(245,'60.00','0.00',1,109,'2016-03-28 14:12:43',NULL),(246,'60.00','0.00',1,110,'2016-03-28 14:14:04',NULL),(247,'70.00','0.00',1,111,'2016-03-28 14:18:34',NULL),(248,'70.00','0.00',1,112,'2016-03-28 14:19:27',NULL),(249,'30.00','0.00',1,113,'2016-03-28 14:30:04',NULL),(250,'30.00','0.00',1,114,'2016-03-28 14:31:05',NULL),(251,'23.00','0.00',1,115,'2016-04-04 17:42:38',NULL),(252,'18.00','0.00',1,116,'2016-04-04 17:43:35',NULL),(253,'55.00','0.00',1,117,'2016-04-04 17:46:08',NULL),(254,'55.00','0.00',1,118,'2016-04-04 17:47:13',NULL),(255,'32.00','0.00',1,119,'2016-04-04 18:01:34',NULL),(256,'32.00','0.00',1,120,'2016-04-04 18:04:26',NULL),(257,'32.00','0.00',1,121,'2016-04-04 18:04:44',NULL),(258,'65.00','0.00',1,122,'2016-04-04 18:06:27',NULL),(259,'130.00','0.00',1,123,'2016-04-04 18:06:51',NULL),(260,'230.00','0.00',1,124,'2016-04-04 18:07:22',NULL),(261,'65.00','0.00',1,125,'2016-04-04 18:07:50',NULL),(262,'130.00','0.00',1,126,'2016-04-04 18:08:20',NULL),(263,'230.00','0.00',1,127,'2016-04-04 18:08:43',NULL),(264,'65.00','0.00',1,128,'2016-04-04 18:09:13',NULL),(265,'130.00','0.00',1,129,'2016-04-04 18:09:55',NULL),(266,'260.00','0.00',1,130,'2016-04-04 18:10:17',NULL),(267,'65.00','0.00',1,131,'2016-04-04 18:10:38',NULL),(268,'130.00','0.00',1,132,'2016-04-04 18:11:09',NULL),(269,'260.00','0.00',1,133,'2016-04-04 18:11:36',NULL),(270,'0.00','0.00',1,134,'2016-04-05 09:28:33',NULL),(271,'0.00','0.00',1,135,'2016-04-05 09:28:58',NULL),(272,'0.00','0.00',1,136,'2016-04-05 09:29:24',NULL),(273,'0.00','0.00',1,137,'2016-04-05 09:31:23',NULL),(274,'0.00','0.00',1,138,'2016-04-05 09:31:52',NULL),(275,'0.00','0.00',1,139,'2016-04-05 09:32:20',NULL),(276,'0.00','0.00',1,140,'2016-04-05 09:33:12',NULL),(277,'0.00','0.00',1,141,'2016-04-05 09:33:32',NULL),(278,'0.00','0.00',1,142,'2016-04-05 10:04:45',NULL),(279,'0.00','0.00',1,143,'2016-04-05 10:05:02',NULL),(280,'0.00','0.00',1,144,'2016-04-05 10:05:27',NULL),(281,'0.00','0.00',1,145,'2016-04-05 10:05:53',NULL);

/*Table structure for table `producto_recepcion` */

DROP TABLE IF EXISTS `producto_recepcion`;

CREATE TABLE `producto_recepcion` (
  `id_recepcion` int(11) NOT NULL auto_increment,
  `id_sucursal` int(11) default NULL,
  `id_empleado` int(11) default NULL,
  `id_factura_compra` int(11) default NULL,
  `fecha_recepcion` datetime default NULL,
  PRIMARY KEY  (`id_recepcion`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `producto_recepcion` */

/*Table structure for table `producto_sucursal` */

DROP TABLE IF EXISTS `producto_sucursal`;

CREATE TABLE `producto_sucursal` (
  `id_producto_sucursal` int(11) NOT NULL auto_increment,
  `id_precio` int(11) default NULL,
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
) ENGINE=MyISAM AUTO_INCREMENT=282 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_sucursal` */

insert  into `producto_sucursal`(`id_producto_sucursal`,`id_precio`,`id_producto`,`id_sucursal`,`id_almacen`,`cantidad`,`fecha_alta`,`fecha_baja`,`precio_especial`,`precio_especial_inicio`,`precio_especial_termino`,`cantidad_minima`,`cantidad_maxima`,`merma`) values (137,137,1,1,1,'-2.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(138,138,2,1,1,'-5.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(139,139,3,1,1,'-22.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(140,140,4,1,1,'-42.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,18,'0.00'),(141,141,5,1,1,'-63.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,18,'0.00'),(142,142,6,1,1,'-406.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(143,143,7,1,1,'-19.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,18,'0.00'),(144,144,8,1,1,'0.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(145,145,9,1,1,'-142.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(146,146,10,1,1,'-10.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(147,147,11,1,1,'-6.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(148,148,12,1,1,'-32.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(149,149,13,1,1,'-124.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(150,150,14,1,1,'-4.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(152,152,16,1,1,'-2.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(153,153,17,1,1,'-1.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(154,154,18,1,1,'-124.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',30,60,'0.00'),(155,155,19,1,1,'-16.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,18,'0.00'),(156,156,20,1,1,'-137.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(157,157,21,1,1,'-3.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(158,158,22,1,1,'0.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(159,159,23,1,1,'-8.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(160,160,24,1,1,'-20.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(161,161,25,1,1,'-2.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(162,162,26,1,1,'-1.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(165,165,29,1,1,'-121.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',27,48,'0.00'),(166,166,30,1,1,'-4.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',5,10,'0.00'),(167,167,31,1,1,'-10.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(168,168,32,1,1,'-45.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(169,169,33,1,1,'-83.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',27,48,'0.00'),(170,170,34,1,1,'-4.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',5,10,'0.00'),(171,171,35,1,1,'-45.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',15,24,'0.00'),(172,172,36,1,1,'-45.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(173,173,37,1,1,'-14.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(174,174,38,1,1,'0.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(175,175,39,1,1,'0.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(176,176,40,1,1,'-2.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(177,177,41,1,1,'-17.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(178,178,42,1,1,'-1.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(179,179,43,1,1,'0.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(180,180,44,1,1,'-2.000','2016-03-28 11:51:37',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(181,181,45,1,1,'-9.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(182,182,46,1,1,'-31.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(183,183,47,1,1,'-184.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',36,60,'0.00'),(184,184,48,1,1,'-3.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',5,10,'0.00'),(185,185,49,1,1,'-44.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',5,10,'0.00'),(186,186,50,1,1,'-77.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(187,187,51,1,1,'-1.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(188,188,52,1,1,'-13.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(189,189,53,1,1,'-15.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(190,190,54,1,1,'0.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(191,191,55,1,1,'-6.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(192,192,56,1,1,'-40.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(193,193,57,1,1,'-47.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(194,194,58,1,1,'-128.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(195,195,59,1,1,'-249.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(196,196,60,1,1,'-21.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(197,197,61,1,1,'-4.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(198,198,62,1,1,'-47.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(199,199,63,1,1,'0.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(200,200,64,1,1,'-4.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(201,201,65,1,1,'-176.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',36,60,'0.00'),(202,202,66,1,1,'-74.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',27,48,'0.00'),(203,203,67,1,1,'-6.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',5,10,'0.00'),(204,204,68,1,1,'-11.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(205,205,69,1,1,'-6.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(207,207,71,1,1,'0.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(210,210,74,1,1,'-28.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',10,50,'0.00'),(211,211,75,1,1,'-170.000','2016-03-28 11:51:38',NULL,'0.00','2016-03-28','2016-03-28',30,60,'0.00'),(212,212,76,1,1,'-1.000','2016-03-28 12:43:24',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(213,213,77,1,1,'-1.000','2016-03-28 12:44:39',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(214,214,78,1,1,'-1.000','2016-03-28 12:45:07',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(215,215,79,1,1,'-98.000','2016-03-28 12:50:16',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(216,216,80,1,1,'-1411.000','2016-03-28 12:50:50',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(217,217,81,1,1,'-117.000','2016-03-28 12:51:24',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(218,218,82,1,1,'-118.000','2016-03-28 12:52:30',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(219,219,83,1,1,'-57.000','2016-03-28 12:52:44',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(220,220,84,1,1,'-99.000','2016-03-28 12:53:12',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(221,221,85,1,1,'-663.000','2016-03-28 12:55:15',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(222,222,86,1,1,'-1117.000','2016-03-28 12:55:42',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(223,223,87,1,1,'-1615.000','2016-03-28 13:13:08',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(224,224,88,1,1,'-588.000','2016-03-28 13:13:37',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(225,225,89,1,1,'0.000','2016-03-28 13:26:17',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(226,226,90,1,1,'-5.000','2016-03-28 13:26:38',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(227,227,91,1,1,'0.000','2016-03-28 13:27:03',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(228,228,92,1,1,'-2.000','2016-03-28 13:27:24',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(229,229,93,1,1,'-3.000','2016-03-28 13:27:54',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(230,230,94,1,1,'-9.000','2016-03-28 13:28:22',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(231,231,95,1,1,'-1.000','2016-03-28 13:29:39',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(232,232,96,1,1,'0.000','2016-03-28 13:30:14',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(233,233,97,1,1,'0.000','2016-03-28 13:31:18',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(234,234,98,1,1,'-1.000','2016-03-28 13:42:49',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(235,235,99,1,1,'-1.000','2016-03-28 13:43:08',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(236,236,100,1,1,'-75.000','2016-03-28 13:43:35',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(237,237,101,1,1,'-12.000','2016-03-28 13:47:11',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(238,238,102,1,1,'-7.000','2016-03-28 13:48:39',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(239,239,103,1,1,'-15.000','2016-03-28 13:49:01',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(240,240,104,1,1,'-4.000','2016-03-28 13:49:32',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(241,241,105,1,1,'-20.000','2016-03-28 13:50:04',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(242,242,106,1,1,'-34.000','2016-03-28 13:50:27',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(243,243,107,1,1,'-509.000','2016-03-28 14:08:33',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(244,244,108,1,1,'-2.000','2016-03-28 14:09:46',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(245,245,109,1,1,'-21.000','2016-03-28 14:12:43',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(246,246,110,1,1,'0.000','2016-03-28 14:14:04',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(247,247,111,1,1,'-12.000','2016-03-28 14:18:34',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(248,248,112,1,1,'-1.000','2016-03-28 14:19:27',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(249,249,113,1,1,'-2.000','2016-03-28 14:30:04',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(250,250,114,1,1,'-1.000','2016-03-28 14:31:05',NULL,'0.00','2016-03-27','2016-03-27',1,10,'0.00'),(251,251,115,1,1,'-2.000','2016-04-04 17:42:38',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(252,252,116,1,1,'0.000','2016-04-04 17:43:35',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(253,253,117,1,1,'-3.000','2016-04-04 17:46:08',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(254,254,118,1,1,'-4.000','2016-04-04 17:47:13',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(255,255,119,1,1,'0.000','2016-04-04 18:01:34',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(256,256,120,1,1,'0.000','2016-04-04 18:04:26',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(257,257,121,1,1,'0.000','2016-04-04 18:04:44',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(258,258,122,1,1,'-1.000','2016-04-04 18:06:27',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(259,259,123,1,1,'0.000','2016-04-04 18:06:51',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(260,260,124,1,1,'0.000','2016-04-04 18:07:22',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(261,261,125,1,1,'0.000','2016-04-04 18:07:50',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(262,262,126,1,1,'0.000','2016-04-04 18:08:20',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(263,263,127,1,1,'0.000','2016-04-04 18:08:43',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(264,264,128,1,1,'0.000','2016-04-04 18:09:13',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(265,265,129,1,1,'0.000','2016-04-04 18:09:55',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(266,266,130,1,1,'0.000','2016-04-04 18:10:17',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(267,267,131,1,1,'0.000','2016-04-04 18:10:38',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(268,268,132,1,1,'0.000','2016-04-04 18:11:09',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(269,269,133,1,1,'-1.000','2016-04-04 18:11:36',NULL,'0.00','2016-04-03','2016-04-03',1,10,'0.00'),(270,270,134,1,1,'-5.000','2016-04-05 09:28:34',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(271,271,135,1,1,'-9.000','2016-04-05 09:28:58',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(272,272,136,1,1,'-5.000','2016-04-05 09:29:24',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(273,273,137,1,1,'0.000','2016-04-05 09:31:23',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(274,274,138,1,1,'0.000','2016-04-05 09:31:52',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(275,275,139,1,1,'-1.000','2016-04-05 09:32:20',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(276,276,140,1,1,'0.000','2016-04-05 09:33:12',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(277,277,141,1,1,'0.000','2016-04-05 09:33:32',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(278,278,142,1,1,'0.000','2016-04-05 10:04:45',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(279,279,143,1,1,'0.000','2016-04-05 10:05:02',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(280,280,144,1,1,'0.000','2016-04-05 10:05:27',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00'),(281,281,145,1,1,'0.000','2016-04-05 10:05:53',NULL,'0.00','2016-04-04','2016-04-04',1,10,'0.00');

/*Table structure for table `producto_talla` */

DROP TABLE IF EXISTS `producto_talla`;

CREATE TABLE `producto_talla` (
  `id_producto_talla` int(11) NOT NULL auto_increment,
  `talla` varchar(100) default '',
  PRIMARY KEY  (`id_producto_talla`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `producto_talla` */

insert  into `producto_talla`(`id_producto_talla`,`talla`) values (1,'NO APLICA');

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
) ENGINE=MyISAM AUTO_INCREMENT=146 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `producto_volumen` */

insert  into `producto_volumen`(`id_descuento`,`nombre`,`id_catalogo_precio`,`utilidad`,`descuento`,`id_producto`,`rango_inicial`,`rango_final`) values (1,'ESPECIAL',1,'0.11','0.00',1,1,10000000),(2,'ESPECIAL',1,'0.11','0.00',2,1,10000000),(3,'ESPECIAL',1,'0.11','0.00',3,1,10000000),(4,'ESPECIAL',1,'0.11','0.00',4,1,10000000),(5,'ESPECIAL',1,'0.11','0.00',5,1,10000000),(6,'ESPECIAL',1,'0.11','0.00',6,1,10000000),(7,'ESPECIAL',1,'0.11','0.00',7,1,10000000),(8,'ESPECIAL',1,'0.11','0.00',8,1,10000000),(9,'ESPECIAL',1,'0.11','0.00',9,1,10000000),(10,'ESPECIAL',1,'0.11','0.00',10,1,10000000),(11,'ESPECIAL',1,'0.11','0.00',11,1,10000000),(12,'ESPECIAL',1,'0.11','0.00',12,1,10000000),(13,'ESPECIAL',1,'0.11','0.00',13,1,10000000),(14,'ESPECIAL',1,'0.11','0.00',14,1,10000000),(16,'ESPECIAL',1,'0.11','0.00',16,1,10000000),(17,'ESPECIAL',1,'0.11','0.00',17,1,10000000),(18,'ESPECIAL',1,'0.11','0.00',18,1,10000000),(19,'ESPECIAL',1,'0.11','0.00',19,1,10000000),(20,'ESPECIAL',1,'0.11','0.00',20,1,10000000),(21,'ESPECIAL',1,'0.11','0.00',21,1,10000000),(22,'ESPECIAL',1,'0.11','0.00',22,1,10000000),(23,'ESPECIAL',1,'0.11','0.00',23,1,10000000),(24,'ESPECIAL',1,'0.11','0.00',24,1,10000000),(25,'ESPECIAL',1,'0.11','0.00',25,1,10000000),(26,'ESPECIAL',1,'0.11','0.00',26,1,10000000),(29,'ESPECIAL',1,'0.11','0.00',29,1,10000000),(30,'ESPECIAL',1,'0.11','0.00',30,1,10000000),(31,'ESPECIAL',1,'0.11','0.00',31,1,10000000),(32,'ESPECIAL',1,'0.11','0.00',32,1,10000000),(33,'ESPECIAL',1,'0.11','0.00',33,1,10000000),(34,'ESPECIAL',1,'0.11','0.00',34,1,10000000),(35,'ESPECIAL',1,'0.11','0.00',35,1,10000000),(36,'ESPECIAL',1,'0.11','0.00',36,1,10000000),(37,'ESPECIAL',1,'0.11','0.00',37,1,10000000),(38,'ESPECIAL',1,'0.11','0.00',38,1,10000000),(39,'ESPECIAL',1,'0.11','0.00',39,1,10000000),(40,'ESPECIAL',1,'0.11','0.00',40,1,10000000),(41,'ESPECIAL',1,'0.11','0.00',41,1,10000000),(42,'ESPECIAL',1,'0.11','0.00',42,1,10000000),(43,'ESPECIAL',1,'0.11','0.00',43,1,10000000),(44,'ESPECIAL',1,'0.11','0.00',44,1,10000000),(45,'ESPECIAL',1,'0.11','0.00',45,1,10000000),(46,'ESPECIAL',1,'0.11','0.00',46,1,10000000),(47,'ESPECIAL',1,'0.11','0.00',47,1,10000000),(48,'ESPECIAL',1,'0.11','0.00',48,1,10000000),(49,'ESPECIAL',1,'0.11','0.00',49,1,10000000),(50,'ESPECIAL',1,'0.11','0.00',50,1,10000000),(51,'ESPECIAL',1,'0.11','0.00',51,1,10000000),(52,'ESPECIAL',1,'0.11','0.00',52,1,10000000),(53,'ESPECIAL',1,'0.11','0.00',53,1,10000000),(54,'ESPECIAL',1,'0.11','0.00',54,1,10000000),(55,'ESPECIAL',1,'0.11','0.00',55,1,10000000),(56,'ESPECIAL',1,'0.11','0.00',56,1,10000000),(57,'ESPECIAL',1,'0.11','0.00',57,1,10000000),(58,'ESPECIAL',1,'0.11','0.00',58,1,10000000),(59,'ESPECIAL',1,'0.11','0.00',59,1,10000000),(60,'ESPECIAL',1,'0.11','0.00',60,1,10000000),(61,'ESPECIAL',1,'0.11','0.00',61,1,10000000),(62,'ESPECIAL',1,'0.11','0.00',62,1,10000000),(63,'ESPECIAL',1,'0.11','0.00',63,1,10000000),(64,'ESPECIAL',1,'0.11','0.00',64,1,10000000),(65,'ESPECIAL',1,'0.11','0.00',65,1,10000000),(66,'ESPECIAL',1,'0.11','0.00',66,1,10000000),(67,'ESPECIAL',1,'0.11','0.00',67,1,10000000),(68,'ESPECIAL',1,'0.11','0.00',68,1,10000000),(69,'ESPECIAL',1,'0.11','0.00',69,1,10000000),(71,'ESPECIAL',1,'0.11','0.00',71,1,10000000),(74,'ESPECIAL',1,'0.11','0.00',74,1,10000000),(75,'ESPECIAL',1,'0.11','0.00',75,1,10000000),(76,'ESPECIAL',1,'0.11','0.00',76,1,10000000),(77,'ESPECIAL',1,'0.11','0.00',77,1,10000000),(78,'ESPECIAL',1,'0.11','0.00',78,1,10000000),(79,'ESPECIAL',1,'0.11','0.00',79,1,10000000),(80,'ESPECIAL',1,'0.11','0.00',80,1,10000000),(81,'ESPECIAL',1,'0.11','0.00',81,1,10000000),(82,'ESPECIAL',1,'0.11','0.00',82,1,10000000),(83,'ESPECIAL',1,'0.11','0.00',83,1,10000000),(84,'ESPECIAL',1,'0.11','0.00',84,1,10000000),(85,'ESPECIAL',1,'0.11','0.00',85,1,10000000),(86,'ESPECIAL',1,'0.11','0.00',86,1,10000000),(87,'ESPECIAL',1,'0.11','0.00',87,1,10000000),(88,'ESPECIAL',1,'0.11','0.00',88,1,10000000),(89,'ESPECIAL',1,'0.11','0.00',89,1,10000000),(90,'ESPECIAL',1,'0.11','0.00',90,1,10000000),(91,'ESPECIAL',1,'0.11','0.00',91,1,10000000),(92,'ESPECIAL',1,'0.11','0.00',92,1,10000000),(93,'ESPECIAL',1,'0.11','0.00',93,1,10000000),(94,'ESPECIAL',1,'0.11','0.00',94,1,10000000),(95,'ESPECIAL',1,'0.11','0.00',95,1,10000000),(96,'ESPECIAL',1,'0.11','0.00',96,1,10000000),(97,'ESPECIAL',1,'0.11','0.00',97,1,10000000),(98,'ESPECIAL',1,'0.11','0.00',98,1,10000000),(99,'ESPECIAL',1,'0.11','0.00',99,1,10000000),(100,'ESPECIAL',1,'0.11','0.00',100,1,10000000),(101,'ESPECIAL',1,'0.11','0.00',101,1,10000000),(102,'ESPECIAL',1,'0.11','0.00',102,1,10000000),(103,'ESPECIAL',1,'0.11','0.00',103,1,10000000),(104,'ESPECIAL',1,'0.11','0.00',104,1,10000000),(105,'ESPECIAL',1,'0.11','0.00',105,1,10000000),(106,'ESPECIAL',1,'0.11','0.00',106,1,10000000),(107,'ESPECIAL',1,'0.11','0.00',107,1,10000000),(108,'ESPECIAL',1,'0.11','0.00',108,1,10000000),(109,'ESPECIAL',1,'0.11','0.00',109,1,10000000),(110,'ESPECIAL',1,'0.11','0.00',110,1,10000000),(111,'ESPECIAL',1,'0.11','0.00',111,1,10000000),(112,'ESPECIAL',1,'0.11','0.00',112,1,10000000),(113,'ESPECIAL',1,'0.11','0.00',113,1,10000000),(114,'ESPECIAL',1,'0.11','0.00',114,1,10000000),(115,'ESPECIAL',1,'0.11','0.00',115,1,10000000),(116,'ESPECIAL',1,'0.11','0.00',116,1,10000000),(117,'ESPECIAL',1,'0.11','0.00',117,1,10000000),(118,'ESPECIAL',1,'0.11','0.00',118,1,10000000),(119,'ESPECIAL',1,'0.11','0.00',119,1,10000000),(120,'ESPECIAL',1,'0.11','0.00',120,1,10000000),(121,'ESPECIAL',1,'0.11','0.00',121,1,10000000),(122,'ESPECIAL',1,'0.11','0.00',122,1,10000000),(123,'ESPECIAL',1,'0.11','0.00',123,1,10000000),(124,'ESPECIAL',1,'0.11','0.00',124,1,10000000),(125,'ESPECIAL',1,'0.11','0.00',125,1,10000000),(126,'ESPECIAL',1,'0.11','0.00',126,1,10000000),(127,'ESPECIAL',1,'0.11','0.00',127,1,10000000),(128,'ESPECIAL',1,'0.11','0.00',128,1,10000000),(129,'ESPECIAL',1,'0.11','0.00',129,1,10000000),(130,'ESPECIAL',1,'0.11','0.00',130,1,10000000),(131,'ESPECIAL',1,'0.11','0.00',131,1,10000000),(132,'ESPECIAL',1,'0.11','0.00',132,1,10000000),(133,'ESPECIAL',1,'0.11','0.00',133,1,10000000),(134,'ESPECIAL',1,'0.11','0.00',134,1,10000000),(135,'ESPECIAL',1,'0.11','0.00',135,1,10000000),(136,'ESPECIAL',1,'0.11','0.00',136,1,10000000),(137,'ESPECIAL',1,'0.11','0.00',137,1,10000000),(138,'ESPECIAL',1,'0.11','0.00',138,1,10000000),(139,'ESPECIAL',1,'0.11','0.00',139,1,10000000),(140,'ESPECIAL',1,'0.11','0.00',140,1,10000000),(141,'ESPECIAL',1,'0.11','0.00',141,1,10000000),(142,'ESPECIAL',1,'0.11','0.00',142,1,10000000),(143,'ESPECIAL',1,'0.11','0.00',143,1,10000000),(144,'ESPECIAL',1,'0.11','0.00',144,1,10000000),(145,'ESPECIAL',1,'0.11','0.00',145,1,10000000);

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

/*Data for the table `proveedor` */

insert  into `proveedor`(`id_proveedor`,`clave`,`id_persona`,`id_empresa`,`id_domicilio`,`fecha_alta`,`fecha_modificacion`) values (1,'',0,3,7,'2016-08-07 22:49:47','2016-08-07 22:49:47');

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

/*Data for the table `proveedor_cuenta` */

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

/*Data for the table `proveedor_productos` */

/*Table structure for table `proveedores` */

DROP TABLE IF EXISTS `proveedores`;

CREATE TABLE `proveedores` (
  `id_proveedor` int(11) default NULL,
  `rfc` varchar(15) default NULL,
  `razon_social` varchar(122) default NULL,
  `domicilio` varchar(64) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `proveedores` */

/*Table structure for table `regimen_fiscal` */

DROP TABLE IF EXISTS `regimen_fiscal`;

CREATE TABLE `regimen_fiscal` (
  `id_regimen_fiscal` int(11) NOT NULL auto_increment,
  `nombre` text,
  PRIMARY KEY  (`id_regimen_fiscal`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `regimen_fiscal` */

insert  into `regimen_fiscal`(`id_regimen_fiscal`,`nombre`) values (1,'REGIMEN DE PRUEBA');

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
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

/*Data for the table `rest_insumo` */

/*Table structure for table `rest_insumo_grupo` */

DROP TABLE IF EXISTS `rest_insumo_grupo`;

CREATE TABLE `rest_insumo_grupo` (
  `id_insumo_grupo` int(11) NOT NULL auto_increment,
  `clave` varchar(10) default '',
  `grupo` varchar(100) default '',
  PRIMARY KEY  (`id_insumo_grupo`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Data for the table `rest_insumo_grupo` */

insert  into `rest_insumo_grupo`(`id_insumo_grupo`,`clave`,`grupo`) values (1,'100','FRUTAS & VERDURAS'),(2,'200','CONDIMENTOS'),(3,'300','LACTEOS'),(4,'400','CARNES'),(5,'500','CERVEZAS'),(6,'600','REFRESCOS'),(7,'700','ADEREZO Y SALSAS'),(8,'800','PAN & TORTILLAS'),(9,'900','ABARROTES');

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
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Data for the table `rest_presentacion` */

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
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `retiros` */

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

/*Data for the table `servidores_smtp` */

insert  into `servidores_smtp`(`id_smtp`,`servidor_smtp`,`correo_smtp`,`password_smtp`,`puerto_smtp`,`habilitar_ssl`) values (1,'smtp.live.com','correo@hotmail.com','','587',1),(2,'smtp.gmail.com','correo@gmail.com','','587',1),(3,'out.izymail.com','correo@yahoo.com','','587',0);

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

/*Data for the table `solicitud_compra` */

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

/*Data for the table `solicitud_compra_detalle` */

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

/*Data for the table `sucursal` */

insert  into `sucursal`(`id_sucursal`,`id_domicilio`,`alias`,`servidor`,`servidor_usuario`,`servidor_password`) values (1,2,'MATRIZ','localhost','root','admin');

/*Table structure for table `sucursal_tel` */

DROP TABLE IF EXISTS `sucursal_tel`;

CREATE TABLE `sucursal_tel` (
  `id_sucursal` int(11) default NULL,
  `id_telefono` int(11) default NULL,
  KEY `FK_sucursal_tel` (`id_telefono`),
  KEY `FK_sucursal_tel2` (`id_sucursal`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `sucursal_tel` */

/*Table structure for table `telefono` */

DROP TABLE IF EXISTS `telefono`;

CREATE TABLE `telefono` (
  `id_telefono` int(11) NOT NULL auto_increment,
  `lada` varchar(10) default NULL,
  `numero` varchar(20) default NULL,
  PRIMARY KEY  (`id_telefono`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `telefono` */

/*Table structure for table `temp_venta` */

DROP TABLE IF EXISTS `temp_venta`;

CREATE TABLE `temp_venta` (
  `id_temp_venta` int(10) unsigned NOT NULL default '0',
  `id_empleado` int(10) unsigned default NULL,
  `id_cliente` int(10) unsigned default NULL,
  `total` decimal(10,0) default NULL,
  `codigo` int(10) unsigned default NULL,
  PRIMARY KEY  (`id_temp_venta`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='temporar para los vendedores';

/*Data for the table `temp_venta` */

/*Table structure for table `temp_venta_detalle` */

DROP TABLE IF EXISTS `temp_venta_detalle`;

CREATE TABLE `temp_venta_detalle` (
  `id_temp_venta_detalle` int(11) NOT NULL auto_increment,
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
  PRIMARY KEY  (`id_temp_venta_detalle`)
) ENGINE=MyISAM AUTO_INCREMENT=69 DEFAULT CHARSET=latin1;

/*Data for the table `temp_venta_detalle` */

insert  into `temp_venta_detalle`(`id_temp_venta_detalle`,`id_empleado`,`id_producto`,`descripcion`,`unidad`,`cantidad`,`precio`,`impuesto`,`importe`,`id_venta`,`total_iva`,`total_otros`,`nombre_impuestos`,`id_cliente`,`id_almacen`,`descuento`,`desc_global_porcent`,`desc_global_importe`,`observaciones`,`modificador`,`id_producto_modificador`) values (67,1,26,'LECHE PARA NESCAFE','PZA','1.000','15.00',NULL,NULL,NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0),(66,1,13,'CAFÉ','PZA','2.000','18.00',NULL,NULL,NULL,'0','0','',1,1,'0.00','0.00','0.00','Observaciones:',0,0);

/*Table structure for table `tipo_movil` */

DROP TABLE IF EXISTS `tipo_movil`;

CREATE TABLE `tipo_movil` (
  `id_tipomovil` int(2) NOT NULL auto_increment,
  `tipo_movil` varchar(20) default NULL,
  PRIMARY KEY  (`id_tipomovil`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `tipo_movil` */

insert  into `tipo_movil`(`id_tipomovil`,`tipo_movil`) values (1,'Bicicleta'),(2,'Motocicleta'),(3,'Automovil'),(4,'Camioneta'),(5,'Camion'),(6,'Trailer'),(7,'Trailer Semiremolque');

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

/*Data for the table `traspaso_env` */

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

/*Data for the table `traspaso_env_detalle` */

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

/*Data for the table `traspaso_recep` */

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

/*Data for the table `traspaso_recep_detalle` */

/*Table structure for table `unidad` */

DROP TABLE IF EXISTS `unidad`;

CREATE TABLE `unidad` (
  `id_unidad` int(3) NOT NULL auto_increment,
  `nombre` varchar(20) default '',
  PRIMARY KEY  (`id_unidad`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `unidad` */

insert  into `unidad`(`id_unidad`,`nombre`) values (1,'PZA'),(2,'GRAMO'),(3,'KG'),(4,'OZ'),(5,'ML'),(6,'REBANADA'),(7,'PAQUETE'),(8,'LTS'),(9,'LBS'),(10,'CAJA');

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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `usuario` */

insert  into `usuario`(`id_usuario`,`usuario`,`password`,`activo`,`id_cuenta`,`id_empleado`) values (1,'ADMIN','9062f8de21a652fc56516789d04bb21c',1,1,1),(2,'ANALI','ba480a847377b07d85697a23ca7d2967',1,0,2),(3,'JESUS','11ef121ca9d001ab8a3e897e530c4e41',1,0,3),(4,'GEORGINA','ffa6dc2ee80f1ee3d4b772981dec6879',1,0,4);

/*Table structure for table `usuario_cuenta` */

DROP TABLE IF EXISTS `usuario_cuenta`;

CREATE TABLE `usuario_cuenta` (
  `id_cuenta` int(2) NOT NULL auto_increment,
  `nombre` varchar(30) NOT NULL,
  PRIMARY KEY  (`id_cuenta`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `usuario_cuenta` */

insert  into `usuario_cuenta`(`id_cuenta`,`nombre`) values (1,'Super Adminstrador'),(2,'Adminstrador'),(3,'Vendedor'),(4,'Cliente'),(5,'Soporte');

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
  PRIMARY KEY  (`id_venta`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=latin1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `venta` */

insert  into `venta`(`id_venta`,`fecha`,`id_sucursal`,`id_empleado`,`id_empleado_caja`,`id_empleado_validacion`,`id_cliente`,`cliente_publico_alias`,`num_ticket`,`id_forma_pago`,`subtotal`,`total_iva`,`total_otros`,`total_descuento`,`total`,`codigo`,`id_factura`,`id_corte`,`desc_global_porcent`,`desc_global_importe`,`fecha_salida_almacen`,`credito`,`status`) values (3,'2016-05-29 10:10:54',1,1,1,0,1,'PUBLICO EN GENERAL',3,0,'860.00','0.00','0.00','0.00','860.00',NULL,0,1,'0.00','0.00','2016-05-29 10:10:57',0,'CERRADA'),(2,'2016-05-29 10:04:56',1,1,1,0,1,'PUBLICO EN GENERAL',2,0,'199.00','0.00','0.00','0.00','199.00',NULL,0,1,'0.00','0.00','2016-05-29 10:04:59',0,'CERRADA'),(4,'2016-06-20 21:27:43',1,1,0,0,1,'Publico en General',4,0,'68.00','0.00','0.00','0.00','68.00',NULL,0,0,'0.00','0.00',NULL,0,'REABIERTA'),(5,'2016-07-27 21:11:15',1,1,1,0,1,'Publico en General',5,0,'60.00','0.00','0.00','0.00','60.00',NULL,0,2,'0.00','0.00','2016-07-27 21:11:21',0,'CERRADA'),(6,'2016-07-27 21:11:27',1,1,1,0,1,'Publico en General',6,0,'30.00','0.00','0.00','0.00','30.00',NULL,0,2,'0.00','0.00','2016-07-27 21:11:33',0,'CERRADA'),(7,'2016-07-27 21:11:43',1,1,1,0,1,'Publico en General',7,0,'60.00','0.00','0.00','0.00','60.00',NULL,0,2,'0.00','0.00','2016-07-27 21:11:51',0,'CERRADA'),(8,'2016-07-27 21:19:24',1,1,1,0,1,'Publico en General',8,0,'18.00','0.00','0.00','0.00','18.00',NULL,0,2,'0.00','0.00','2016-07-27 21:19:27',0,'CERRADA'),(9,'2016-07-27 21:19:37',1,1,1,0,1,'Publico en General',9,0,'54.00','0.00','0.00','0.00','54.00',NULL,0,2,'0.00','0.00','2016-07-27 21:19:41',0,'CERRADA'),(10,'2016-07-27 23:57:45',1,1,1,0,1,'Publico en General',10,0,'18.00','0.00','0.00','0.00','18.00',NULL,0,2,'0.00','0.00','2016-07-28 23:22:09',0,'CERRADA'),(11,'2016-07-28 23:22:03',1,1,1,0,1,'Publico en General',11,0,'46.00','0.00','0.00','0.00','46.00',NULL,0,2,'0.00','0.00','2016-07-28 23:22:16',0,'CERRADA'),(12,'2016-07-29 23:54:08',1,1,1,0,1,'Publico en General',12,0,'60.00','0.00','0.00','0.00','60.00',NULL,0,2,'0.00','0.00','2016-07-29 23:54:11',0,'CERRADA'),(13,'2016-07-29 23:54:19',1,1,1,0,1,'Publico en General',13,0,'18.00','0.00','0.00','0.00','18.00',NULL,0,2,'0.00','0.00','2016-07-29 23:54:21',0,'CERRADA'),(14,'2016-08-02 20:12:07',1,1,1,0,1,'Publico en General',14,0,'18.00','0.00','0.00','0.00','18.00',NULL,0,0,'0.00','0.00','2016-08-02 20:12:20',0,'CERRADA');

/*Table structure for table `venta_detalle` */

DROP TABLE IF EXISTS `venta_detalle`;

CREATE TABLE `venta_detalle` (
  `id_venta_detalle` int(11) NOT NULL auto_increment,
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
  PRIMARY KEY  (`id_venta_detalle`),
  KEY `FK_venta_detalle` (`id_venta`),
  KEY `FK_venta_detalle_producto` (`id_producto`)
) ENGINE=MyISAM AUTO_INCREMENT=45 DEFAULT CHARSET=latin1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `venta_detalle` */

insert  into `venta_detalle`(`id_venta_detalle`,`id_venta`,`id_producto`,`producto_costo`,`cantidad`,`total_porcent_iva`,`total_porcent_otros`,`nombre_impuestos`,`precio`,`impuesto`,`descripcion`,`unidad`,`id_almacen`,`descuento`,`importe`,`modificador`,`id_producto_modificador`) values (19,3,111,'70.00','1.000','0.00','0.00','','70.00','0.00','JARRA JUMBO JAMAICA','PIEZA',1,'0.00','70.00',0,0),(18,3,122,'65.00','1.000','0.00','0.00','','65.00','0.00','ORDEN CARNE 1/4 PASTOR','PIEZA',1,'0.00','65.00',0,0),(17,3,17,'18.00','1.000','0.00','0.00','','18.00','0.00','CHOCOLATE DE LECHE','PIEZA',1,'0.00','18.00',0,0),(16,3,74,'70.00','1.000','0.00','0.00','','75.00','0.00','VEGETARIANO','PIEZA',1,'0.00','75.00',0,0),(15,3,14,'18.00','1.000','0.00','0.00','','18.00','0.00','CHAMPIÑONES EXTRA PARA PR','PIEZA',1,'0.00','18.00',0,0),(8,2,6,'12.00','1.000','0.00','0.00','','12.00','0.00','AGUA JAMAICA','PIEZA',1,'0.00','12.00',0,0),(9,2,109,'60.00','1.000','0.00','0.00','','60.00','0.00','JARRA  NORMAL JAMAICA','PIEZA',1,'0.00','60.00',0,0),(10,2,44,'36.00','1.000','0.00','0.00','','36.00','0.00','PAY DE QUESO CON CREMA','PIEZA',1,'0.00','36.00',0,0),(11,2,82,'10.00','1.000','0.00','0.00','','10.00','0.00','TACO DE OREJA','PIEZA',1,'0.00','10.00',0,0),(12,2,62,'4.00','1.000','0.00','0.00','','5.00','0.00','QUESILLO EXTRA TACO ESPEC','PIEZA',1,'0.00','5.00',0,0),(13,2,32,'38.00','2.000','0.00','0.00','','38.00','0.00','MICHELADA','PIEZA',1,'0.00','76.00',0,0),(14,2,75,'28.00','2.000','0.00','0.00','','0.00','0.00','>>VICTORIA','PIEZA',1,'0.00','0.00',1,32),(20,3,101,'30.00','1.000','0.00','0.00','','30.00','0.00','TOSTADA DE QUESILLO','PIEZA',1,'0.00','30.00',0,0),(21,3,56,'65.00','1.000','0.00','0.00','','65.00','0.00','POZOLE EMPERADOR ROJO GRA','PIEZA',1,'0.00','65.00',0,0),(22,3,88,'10.00','1.000','0.00','0.00','','11.00','0.00','TACO DE BISTEC','PIEZA',1,'0.00','11.00',0,0),(23,3,49,'18.00','6.000','0.00','0.00','','18.00','0.00','PEPSI LIGHT','PIEZA',1,'0.00','108.00',0,0),(24,3,13,'18.00','3.000','0.00','0.00','','18.00','0.00','CAFÉ','PIEZA',1,'0.00','54.00',0,0),(25,3,94,'50.00','1.000','0.00','0.00','','50.00','0.00','TORTA DE BISTEC','PIEZA',1,'0.00','50.00',0,0),(26,3,32,'38.00','5.000','0.00','0.00','','38.00','0.00','MICHELADA','PIEZA',1,'0.00','190.00',0,0),(27,3,19,'28.00','5.000','0.00','0.00','','0.00','0.00','>>CORONA LIGHT','PIEZA',1,'0.00','0.00',1,32),(28,3,32,'38.00','2.000','0.00','0.00','','38.00','0.00','MICHELADA','PIEZA',1,'0.00','76.00',0,0),(29,3,35,'33.00','2.000','0.00','0.00','','0.00','0.00','>>MODELO ESPECIAL','PIEZA',1,'0.00','0.00',1,32),(30,3,99,'30.00','1.000','0.00','0.00','','30.00','0.00','TOSTADA DE CABEZA','PIEZA',1,'0.00','30.00',0,0),(36,7,109,'60.00','1.000','0.00','0.00','','60.00','0.00','JARRA  NORMAL JAMAICA','PIEZA',1,'0.00','60.00',0,0),(35,6,113,'30.00','1.000','0.00','0.00','','30.00','0.00','1/2 JARRA HORCHATA','PIEZA',1,'0.00','30.00',0,0),(34,5,109,'60.00','1.000','0.00','0.00','','60.00','0.00','JARRA  NORMAL JAMAICA','PIEZA',1,'0.00','60.00',0,0),(37,8,13,'18.00','1.000','0.00','0.00','','18.00','0.00','CAFÉ','PIEZA',1,'0.00','18.00',0,0),(38,9,13,'18.00','3.000','0.00','0.00','','18.00','0.00','CAFÉ','PIEZA',1,'0.00','54.00',0,0),(39,10,13,'18.00','1.000','0.00','0.00','','18.00','0.00','CAFÉ','PIEZA',1,'0.00','18.00',0,0),(40,11,13,'18.00','1.000','0.00','0.00','','18.00','0.00','CAFÉ','PIEZA',1,'0.00','18.00',0,0),(41,11,18,'28.00','1.000','0.00','0.00','','28.00','0.00','CORONA','PIEZA',1,'0.00','28.00',0,0),(42,12,109,'60.00','1.000','0.00','0.00','','60.00','0.00','JARRA  NORMAL JAMAICA','PIEZA',1,'0.00','60.00',0,0),(43,13,13,'18.00','1.000','0.00','0.00','','18.00','0.00','CAFÉ','PIEZA',1,'0.00','18.00',0,0),(44,14,29,'18.00','1.000','0.00','0.00','','18.00','0.00','MANZANITA SOL','PIEZA',1,'0.00','18.00',0,0);

/*Table structure for table `venta_insumo` */

DROP TABLE IF EXISTS `venta_insumo`;

CREATE TABLE `venta_insumo` (
  `id_venta` int(11) default NULL,
  `id_producto` int(11) default NULL,
  `cantidad` decimal(9,2) default NULL,
  `id_insumo` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `venta_insumo` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;