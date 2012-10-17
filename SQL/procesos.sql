/*
SQLyog Community v9.50 
MySQL - 5.5.19 : Database - ariclinic_miestetic
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

/*Table structure for table `procesos` */

DROP TABLE IF EXISTS `procesos`;

CREATE TABLE `procesos` (
  `process_id` INT(11) NOT NULL AUTO_INCREMENT,
  `parent_process_id` INT(11) DEFAULT NULL,
  `name` VARCHAR(50) DEFAULT NULL,
  `description` LONGTEXT,
  `code` VARCHAR(50) DEFAULT NULL,
  PRIMARY KEY (`process_id`),
  KEY `idx_process_parent_process_id` (`parent_process_id`)
) ENGINE=INNODB AUTO_INCREMENT=80 DEFAULT CHARSET=latin1;

/*Data for the table `procesos` */

INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (2,NULL,'Administracion','Punto del menú que corresponde a administración','admin');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (3,2,'Grupos de usuarios','Corresponde al mantenimiento del grupo de usuarios','usergroup');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (4,2,'Usuarios','Corresponde  al mantenimiento de usuarios','user');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (5,2,'process','Corresponde al mantenimiento de process','process');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (6,2,'Permisos','Asignación de permisos a grupos de usuarios','permission');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (7,NULL,'Salir','Salir de la aplicación','exit');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (8,2,'Empresa sanitaria','Mantenimiento de los datos de empresa','helcom');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (9,2,'Clinicas','Mantenimiento de clinicas','clinic');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (10,NULL,'Facturación','Representa el elemento base del menú de facturación','invoicing');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (11,10,'Categorias servicio','Mantenimiento de las categorias de servicio','scat');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (12,10,'Tipos de IVA','Mantenimiento de tipos de IVA','taxt');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (13,10,'Servicios','Servicios médicos','ser');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (14,10,'Aseguradoras','Aseguradoras','ins');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (15,2,'Pacientes','Pacientes','patient');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (16,15,'Pólizas','Pólizas','policy');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (17,10,'Tickets','Tickets','ticket');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (18,10,'Clientes','Clientes','customer');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (19,10,'Facturas','Facturas','invoice');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (20,10,'Forma de pago','Forma de pago','paymentmethod');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (21,10,'Cobros','Cobros','payment');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (22,NULL,'Informes','Informes','reports');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (23,22,'Tickets','Tickets','rtickets');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (24,22,'Informe cobros','Cobros','rpayments');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (25,2,'Profesionales','Profesionales','professional');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (26,10,'Tipos de retencion','Tipos de retencion','taxwt');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (27,2,'Procedimientos','Procedimientos','procedure');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (28,10,'Notas de servicio (anestesia)','Notas de servicio (anestesia)','asn');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (29,2,'Parámetros','Parámetros','parameter');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (30,10,'Notas de servicio (general)','Notas de servicio (general)','servicenote');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (31,10,'Liquidación','Liquidación','settlement');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (32,2,'Interna','Contiene los mecanismos de creación de permisos','admint');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (33,22,'Nomenclator','Contiene el nombre y servicio de todos los procedimientos ofertados','rnomenclator');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (34,37,'Informe de profesionales','Muestra los profesionales y sus servicios realizados','rprofessionalsrv');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (35,37,'Informe de categorías de servicio','Lista las categorías con sus servicios asociados.','rcategorysrv');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (36,37,'comparativa de precios','Muestra la comparativa de precios de servicio de todas las compañías aseguradoras que lo ofertan.','rsrvcomparer');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (37,22,'Informes de servicios','Cantiene informes con información relevante de los servicios','rservices');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (38,39,'Facturas emitidas','Muestra las facturas emitidas en un periodo de tiempo determinado.','rinvoicesPeriod');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (39,22,'Informes de facturas','Recoge todos los informes que muestran detalles de la facturación.','infoFacturas');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (40,41,'Deudas del paciente','Muestra por cada paciente los tickets impagados','rpatientdebt');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (41,22,'Informe de impagos','Contendrá otros informes aportando datos sobre los tickets impagados.','debt');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (42,41,'Informe de deudas por aserguradora','Muestra los tickets impagados por cada aseguradora.','rinsurancedebt');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (43,NULL,'Citación','Citación','citation');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (44,43,'Tipo de cita','Tipo de cita','apptype');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (45,43,'Agenda','Agenda','agenda');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (46,43,'Citas','Citas','appointment');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (47,NULL,'Historia Clínica','Punto del menúm principal que da acceso a todo lo relativo a la historia','clinicalrecord');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (48,47,'Datos básicos','Submenú que cuelga de historia y que soporta las ocpiones de mantenimeinto de datos básicos en este grupo','basedata');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (49,47,'Documentos','Proceso que muestra los documentos de la aplicación','docs');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (50,47,'Diagnósticos','Diagnósticos','diagnostic');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (51,47,'Diagnósticos asignados','Diagnósticos asignados','diagnosticassigned');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (52,47,'Fármacos','Fármacos','drug');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (53,47,'Exploracion','Exploracion','examination');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (54,47,'Exploraciones assignadas','Exploraciones assignadas','examinationassigned');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (55,47,'Tratamientos','Tratamientos','treatment');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (56,48,'Tipos de Unidad','Tipos de unidad de las pruebas de laboratorio','unittype');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (57,48,'Tipos pruebas laboratorio','Tipos pruebas laboratorio','labtest');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (58,10,'Facturación profesionales','Facturación profesionales','profinvoice');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (59,22,'Informe facturas profesionales','Informe facturas profesionales','profinvoices');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (60,47,'Pruebas de labotario asignadas','Pruebas de labotario asignadas','labtestassigned');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (62,47,'Visitas','Visitas','visit');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (63,47,'Procedimientos','Procedimientos','procedure');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (64,47,'Motivos de consulta','Motivos de consulta','visitreason');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (65,47,'Procedimientos asignados','Procedimientos asignados','procedureassigned');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (66,22,'Informes generales','Informes generales','rpgeneral');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (67,66,'Pacientes por procedencia','Pacientes por procedencia','rptpatientbysource');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (68,10,'Tickets por profesional','Tickets por profesional','rticketprofessional');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (69,10,'Tickets por profesional (Anestesia)','Tickets por profesional (Anestesia)','ranestckprof');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (70,10,'Tickets por cirujano (Anestesia)','Tickets por cirujano (Anestesia)','rtcksrg');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (71,10,'Tickets de alto riesgo (Anestesia)','Tickets de alto riesgo (Anestesia)','rrisk');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (72,10,'Cobros generales por clínica','Cobros generales por clínica','rptgbyclinic');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (73,10,'Liquidación de IVA','Liquidación de IVA','rptvatresumen');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (74,13,'Servicios por cirujano','Servicios por cirujano','rsurgeonsrv');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (75,22,'Informes Anestesia','Informes Anestesia','anesthetics');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (76,75,'Nomenclator','Nomenclator','rnomenclator');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (77,75,'Bombas PCA','Bombas PCA','rpca');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (78,22,'Informe Citas','Informe Citas','appointments');
INSERT  INTO `procesos`(`process_id`,`parent_process_id`,`name`,`description`,`code`) VALUES (79,78,'Citas diarias en agenda','Citas diarias en agenda','rappointmentday');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
