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
CREATE DATABASE /*!32312 IF NOT EXISTS*/`ariclinic_miestetic` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `ariclinic_miestetic`;

/*Table structure for table `permission` */

DROP TABLE IF EXISTS `permission`;

CREATE TABLE `permission` (
  `view` bit(1) NOT NULL,
  `user_group_id` int(11) DEFAULT NULL,
  `process_id` int(11) DEFAULT NULL,
  `permission_id` int(11) NOT NULL AUTO_INCREMENT,
  `modify` bit(1) NOT NULL,
  `execute` bit(1) NOT NULL,
  `create` bit(1) NOT NULL,
  PRIMARY KEY (`permission_id`),
  KEY `idx_permission_user_group_id` (`user_group_id`),
  KEY `idx_permission_process_id` (`process_id`),
  CONSTRAINT `ref_permission_process` FOREIGN KEY (`process_id`) REFERENCES `process` (`process_id`),
  CONSTRAINT `ref_permission_user_group` FOREIGN KEY (`user_group_id`) REFERENCES `user_group` (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=125 DEFAULT CHARSET=latin1;

/*Data for the table `permission` */

insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,2,1,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,3,2,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,4,3,'','\0','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('\0',15,5,4,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('\0',16,2,5,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',16,3,6,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',16,4,7,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',16,5,8,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,2,9,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,3,10,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,4,11,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,5,12,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,6,13,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,7,14,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('\0',15,6,15,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,7,16,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',16,6,17,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',16,7,18,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,8,19,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,8,20,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,9,21,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,9,22,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,10,23,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,11,24,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,12,25,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,13,26,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,14,27,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,15,28,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,16,29,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,17,30,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,18,31,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,19,32,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,20,33,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,21,34,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,22,35,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,23,36,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,24,37,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,25,38,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,26,39,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,27,40,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,28,41,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,29,42,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,30,43,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,31,44,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,32,45,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,33,46,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,34,47,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,35,48,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,36,49,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,37,50,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,38,51,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,39,52,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,40,53,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,41,54,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,42,55,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,43,56,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,44,57,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,45,58,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,46,59,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,47,60,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,48,61,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,49,62,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,50,63,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,51,64,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,52,65,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,53,66,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,54,67,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,55,68,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,56,69,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,57,70,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,10,71,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,41,72,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,42,73,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,43,74,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,44,75,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,40,76,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,38,77,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,39,78,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,36,79,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,37,80,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,35,81,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,45,82,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,47,83,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,53,84,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,54,85,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,55,86,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,46,87,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,52,88,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,50,89,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,51,90,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,48,91,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,49,92,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,34,93,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,33,94,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,32,95,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,16,96,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,17,97,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,18,98,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,19,99,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,15,100,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,13,101,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,14,102,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,11,103,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,12,104,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,20,105,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,21,106,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,22,107,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,29,108,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,30,109,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,31,110,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,28,111,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,27,112,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,26,113,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,23,114,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,24,115,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,25,116,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,56,117,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,57,118,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,58,119,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,59,120,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,60,121,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,61,122,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,62,123,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,63,124,'','','');

/*Table structure for table `process` */

DROP TABLE IF EXISTS `process`;

CREATE TABLE `process` (
  `process_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `description` longtext,
  `parent_process_id` int(11) DEFAULT NULL,
  `code` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`process_id`),
  KEY `idx_process_parent_process_id` (`parent_process_id`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=latin1;

/*Data for the table `process` */

insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (2,'Administracion','Punto del menú que corresponde a administración',NULL,'admin');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (3,'Grupos de usuarios','Corresponde al mantenimiento del grupo de usuarios',2,'usergroup');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (4,'Usuarios','Corresponde  al mantenimiento de usuarios',2,'user');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (5,'Procesos','Corresponde al mantenimiento de procesos',2,'process');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (6,'Permisos','Asignación de permisos a grupos de usuarios',2,'permission');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (7,'Salir','Salir de la aplicación',NULL,'exit');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (8,'Empresa sanitaria','Mantenimiento de los datos de empresa',2,'helcom');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (9,'Clinicas','Mantenimiento de clinicas',2,'clinic');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (10,'Facturación','Representa el elemento base del menú de facturación',NULL,'invoicing');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (11,'Categorias servicio','Mantenimiento de las categorias de servicio',10,'scat');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (12,'Tipos de IVA','Mantenimiento de tipos de IVA',10,'taxt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (13,'Servicios','Servicios médicos',10,'ser');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (14,'Aseguradoras','Aseguradoras',10,'ins');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (15,'Pacientes','Pacientes',2,'patient');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (16,'Pólizas','Pólizas',15,'policy');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (17,'Tickets','Tickets',10,'ticket');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (18,'Clientes','Clientes',10,'customer');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (19,'Facturas','Facturas',10,'invoice');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (20,'Forma de pago','Forma de pago',10,'paymentmethod');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (21,'Cobros','Cobros',10,'payment');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (22,'Informes','Informes',NULL,'reports');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (23,'Tickets','Tickets',22,'rtickets');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (24,'Informe cobros','Cobros',22,'rpayments');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (25,'Profesionales','Profesionales',2,'professional');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (26,'Tipos de retencion','Tipos de retencion',10,'taxwt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (27,'Procedimientos','Procedimientos',2,'procedure');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (28,'Notas de servicio (anestesia)','Notas de servicio (anestesia)',10,'asn');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (29,'Parámetros','Parámetros',2,'parameter');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (30,'Notas de servicio (general)','Notas de servicio (general)',10,'servicenote');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (31,'Liquidación','Liquidación',10,'settlement');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (32,'Interna','Contiene los mecanismos de creación de permisos',2,'admint');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (33,'Nomenclator','Contiene el nombre y servicio de todos los procedimientos ofertados',22,'rnomenclator');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (34,'Informe de profesionales','Muestra los profesionales y sus servicios realizados',37,'rprofessionalsrv');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (35,'Informe de categorías de servicio','Lista las categorías con sus servicios asociados.',37,'rcategorysrv');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (36,'comparativa de precios','Muestra la comparativa de precios de servicio de todas las compañías aseguradoras que lo ofertan.',37,'rsrvcomparer');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (37,'Informes de servicios','Cantiene informes con información relevante de los servicios',22,'rservices');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (38,'Facturas emitidas','Muestra las facturas emitidas en un periodo de tiempo determinado.',39,'rinvoicesPeriod');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (39,'Informes de facturas','Recoge todos los informes que muestran detalles de la facturación.',22,'infoFacturas');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (40,'Deudas del paciente','Muestra por cada paciente los tickets impagados',41,'rpatientdebt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (41,'Informe de impagos','Contendrá otros informes aportando datos sobre los tickets impagados.',22,'debt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (42,'Informe de deudas por aserguradora','Muestra los tickets impagados por cada aseguradora.',41,'rinsurancedebt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (43,'Citación','Citación',NULL,'citation');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (44,'Tipo de cita','Tipo de cita',43,'apptype');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (45,'Agenda','Agenda',43,'agenda');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (46,'Citas','Citas',43,'appointment');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (47,'Historia Clínica','Punto del menúm principal que da acceso a todo lo relativo a la historia',NULL,'clinicalrecord');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (48,'Datos básicos','Submenú que cuelga de historia y que soporta las ocpiones de mantenimeinto de datos básicos en este grupo',47,'basedata');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (49,'Documentos','Proceso que muestra los documentos de la aplicación',47,'docs');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (50,'Diagnósticos','Diagnósticos',47,'diagnostic');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (51,'Diagnósticos asignados','Diagnósticos asignados',47,'diagnosticassigned');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (52,'Fármacos','Fármacos',47,'drug');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (53,'Exploracion','Exploracion',47,'examination');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (54,'Exploraciones assignadas','Exploraciones assignadas',47,'examinationassigned');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (55,'Tratamientos','Tratamientos',47,'treatment');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (56,'Tipos de Unidad','Tipos de unidad de las pruebas de laboratorio',48,'unittype');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (57,'Tipos pruebas laboratorio','Tipos pruebas laboratorio',48,'labtest');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (58,'Facturación profesionales','Facturación profesionales',10,'profinvoice');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (59,'Informe facturas profesionales','Informe facturas profesionales',22,'profinvoices');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (60,'Pruebas de labotario asignadas','Pruebas de labotario asignadas',47,'labtestassigned');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (61,'Procedimientos asignados','Procedimientos asignados',47,'procedureassigned');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (62,'Motivos de consulta','Motivos de consulta',48,'visitreason');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (63,'Visitas','Visitas',47,'visit');

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_group_id` int(11) DEFAULT NULL,
  `password` varchar(30) NOT NULL,
  `name` varchar(50) NOT NULL,
  `login` varchar(30) NOT NULL,
  PRIMARY KEY (`user_id`),
  KEY `idx_user_user_group_id` (`user_group_id`),
  CONSTRAINT `ref_user_user_group` FOREIGN KEY (`user_group_id`) REFERENCES `user_group` (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `user` */

insert  into `user`(`user_id`,`user_group_id`,`password`,`name`,`login`) values (3,14,'21232F297A57A5A743894A0E4A801F','Administrador','admin');
insert  into `user`(`user_id`,`user_group_id`,`password`,`name`,`login`) values (4,14,'325DAA03A34823CEF2FC367C779561','Rocio','rocio');

/*Table structure for table `user_group` */

DROP TABLE IF EXISTS `user_group`;

CREATE TABLE `user_group` (
  `user_group_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `user_group` */

insert  into `user_group`(`user_group_id`,`name`) values (14,'Reservado (Administradores)');
insert  into `user_group`(`user_group_id`,`name`) values (15,'Médicos');
insert  into `user_group`(`user_group_id`,`name`) values (16,'Administrativos');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
