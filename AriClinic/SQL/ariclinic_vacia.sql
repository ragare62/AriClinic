/*
SQLyog Community Edition- MySQL GUI v8.03 
MySQL - 5.0.51b-community-nt : Database - ariclinic_miestetic
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`ariclinic_miestetic` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `ariclinic_miestetic`;

/*Table structure for table `address` */

DROP TABLE IF EXISTS `address`;

CREATE TABLE `address` (
  `type` varchar(10) default NULL,
  `street2` varchar(100) default NULL,
  `street` varchar(50) default NULL,
  `province` varchar(255) default NULL,
  `post_code` varchar(10) default NULL,
  `hc_id` int(11) default NULL,
  `country` varchar(30) default NULL,
  `city` varchar(30) default NULL,
  `address_id` int(11) NOT NULL auto_increment,
  `clinic_id` int(11) default NULL,
  `person_id` int(11) default NULL,
  PRIMARY KEY  (`address_id`),
  KEY `idx_address_hc_id` (`hc_id`),
  KEY `idx_address_clinic_id` (`clinic_id`),
  KEY `idx_address_person_id` (`person_id`),
  CONSTRAINT `ref_address_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_address_healthcare_company` FOREIGN KEY (`hc_id`) REFERENCES `healthcare_company` (`hc_id`),
  CONSTRAINT `ref_address_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=latin1;

/*Data for the table `address` */

/*Table structure for table `anesthetic_service_note` */

DROP TABLE IF EXISTS `anesthetic_service_note`;

CREATE TABLE `anesthetic_service_note` (
  `user_id` int(11) default NULL,
  `surgeon_person_id` int(11) default NULL,
  `service_note_date` datetime NOT NULL,
  `professional_person_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  `anesthetic_service_note_id` int(11) NOT NULL auto_increment,
  `customer_person_id` int(11) default NULL,
  `total` decimal(12,2) NOT NULL,
  `chk2` bit(1) NOT NULL,
  `chk1` bit(1) NOT NULL,
  PRIMARY KEY  (`anesthetic_service_note_id`),
  KEY `idx_anesthetic_service_note_clinic_id` (`clinic_id`),
  KEY `idx_anesthetic_service_note_surgeon_person_id` (`surgeon_person_id`),
  KEY `idx_anesthetic_service_note_professional_person_id` (`professional_person_id`),
  KEY `idx_anesthetic_service_note_user_id` (`user_id`),
  KEY `idx_anesthetic_service_note_customer_id` (`customer_person_id`),
  CONSTRAINT `ref_anesthetic_service_note_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_anesthetic_service_note_customer` FOREIGN KEY (`customer_person_id`) REFERENCES `customer` (`person_id`),
  CONSTRAINT `ref_anesthetic_service_note_professional` FOREIGN KEY (`professional_person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_anesthetic_service_note_professional2` FOREIGN KEY (`surgeon_person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_anesthetic_service_note_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

/*Data for the table `anesthetic_service_note` */

/*Table structure for table `anesthetic_service_note_procedures` */

DROP TABLE IF EXISTS `anesthetic_service_note_procedures`;

CREATE TABLE `anesthetic_service_note_procedures` (
  `anesthetic_service_note_id` int(11) NOT NULL,
  `procedure_id` int(11) NOT NULL,
  PRIMARY KEY  (`anesthetic_service_note_id`,`procedure_id`),
  KEY `idx_anesthetic_service_note_procedures_procedure_id` (`procedure_id`),
  CONSTRAINT `ref_anesthetic_service_note_procedures_anesthetic_service_note` FOREIGN KEY (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`),
  CONSTRAINT `ref_anesthetic_service_note_procedures_procedure` FOREIGN KEY (`procedure_id`) REFERENCES `procedure` (`procedure_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `anesthetic_service_note_procedures` */

/*Table structure for table `anesthetic_ticket` */

DROP TABLE IF EXISTS `anesthetic_ticket`;

CREATE TABLE `anesthetic_ticket` (
  `ticket_id` int(11) NOT NULL,
  `person_id` int(11) default NULL,
  `procedure_id` int(11) default NULL,
  `anesthetic_service_note_id` int(11) default NULL,
  PRIMARY KEY  (`ticket_id`),
  KEY `idx_anesthetic_ticket_procedure_id` (`procedure_id`),
  KEY `idx_anesthetic_ticket_person_id` (`person_id`),
  KEY `idx_anesthetic_ticket_anesthetic_service_note_id` (`anesthetic_service_note_id`),
  CONSTRAINT `ref_anesthetic_ticket_anesthetic_service_note` FOREIGN KEY (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`),
  CONSTRAINT `ref_anesthetic_ticket_procedure` FOREIGN KEY (`procedure_id`) REFERENCES `procedure` (`procedure_id`),
  CONSTRAINT `ref_anesthetic_ticket_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_anesthetic_ticket_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `anesthetic_ticket` */

/*Table structure for table `appointment` */

DROP TABLE IF EXISTS `appointment`;

CREATE TABLE `appointment` (
  `user_id` int(11) default NULL,
  `status` varchar(1) default NULL,
  `recurrence` varchar(255) default NULL,
  `person_id` int(11) default NULL,
  `person_id2` int(11) default NULL,
  `father_appointment_appointment_id` int(11) default NULL,
  `end_date_time` datetime NOT NULL,
  `duration` int(11) NOT NULL,
  `diary_id` int(11) default NULL,
  `comments` longtext,
  `begin_date_time` datetime NOT NULL,
  `arrival` datetime NOT NULL,
  `appointment_type_id` int(11) default NULL,
  `appointment_id` int(11) NOT NULL auto_increment,
  `subject` longtext,
  PRIMARY KEY  (`appointment_id`),
  KEY `idx_appointment_user_id` (`user_id`),
  KEY `idx_appointment_person_id2` (`person_id2`),
  KEY `idx_appointment_person_id` (`person_id`),
  KEY `idx_appointment_father_appointment_appointment_id` (`father_appointment_appointment_id`),
  KEY `idx_appointment_diary_id` (`diary_id`),
  KEY `idx_appointment_appointment_type_id` (`appointment_type_id`),
  CONSTRAINT `ref_appointment_appointment_type` FOREIGN KEY (`appointment_type_id`) REFERENCES `appointment_type` (`appointment_type_id`),
  CONSTRAINT `ref_appointment_diary` FOREIGN KEY (`diary_id`) REFERENCES `diary` (`diary_id`),
  CONSTRAINT `ref_appointment_patient` FOREIGN KEY (`person_id2`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_appointment_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_appointment_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `appointment` */

/*Table structure for table `appointment_type` */

DROP TABLE IF EXISTS `appointment_type`;

CREATE TABLE `appointment_type` (
  `name` varchar(50) default NULL,
  `duration` int(11) NOT NULL,
  `appointment_type_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`appointment_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `appointment_type` */

/*Table structure for table `clinic` */

DROP TABLE IF EXISTS `clinic`;

CREATE TABLE `clinic` (
  `remote_ip` varchar(30) default NULL,
  `name` varchar(50) default NULL,
  `clinic_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`clinic_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `clinic` */

insert  into `clinic`(`remote_ip`,`name`,`clinic_id`) values (NULL,'Clinica Prinicpal',1);

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `comercial_name` varchar(50) default NULL,
  `person_id` int(11) NOT NULL,
  `vat_in` varchar(25) default NULL,
  PRIMARY KEY  (`person_id`),
  CONSTRAINT `ref_customer_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customer` */

/*Table structure for table `diary` */

DROP TABLE IF EXISTS `diary`;

CREATE TABLE `diary` (
  `time_step` int(11) NOT NULL,
  `nme` varchar(255) default NULL,
  `end_hour` datetime NOT NULL,
  `diary_id` int(11) NOT NULL auto_increment,
  `begin_hour` datetime NOT NULL,
  PRIMARY KEY  (`diary_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `diary` */

/*Table structure for table `email` */

DROP TABLE IF EXISTS `email`;

CREATE TABLE `email` (
  `url` varchar(50) default NULL,
  `hc_id` int(11) default NULL,
  `email_id` int(11) NOT NULL auto_increment,
  `type` varchar(10) default NULL,
  `clinic_id` int(11) default NULL,
  `person_id` int(11) default NULL,
  PRIMARY KEY  (`email_id`),
  KEY `idx_email_hc_id` (`hc_id`),
  KEY `idx_email_clinic_id` (`clinic_id`),
  KEY `idx_email_person_id` (`person_id`),
  CONSTRAINT `ref_email_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_email_healthcare_company` FOREIGN KEY (`hc_id`) REFERENCES `healthcare_company` (`hc_id`),
  CONSTRAINT `ref_email_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Data for the table `email` */

/*Table structure for table `external_invoice` */

DROP TABLE IF EXISTS `external_invoice`;

CREATE TABLE `external_invoice` (
  `invoice_id` int(11) NOT NULL,
  `person_id` int(11) default NULL,
  PRIMARY KEY  (`invoice_id`),
  KEY `idx_external_invoice_person_id` (`person_id`),
  CONSTRAINT `ref_external_invoice_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `ref_external_invoice_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `external_invoice` */

/*Table structure for table `external_invoice_line` */

DROP TABLE IF EXISTS `external_invoice_line`;

CREATE TABLE `external_invoice_line` (
  `invoice_line_id` int(11) NOT NULL,
  `invoice_id` int(11) default NULL,
  `comission_amount` decimal(20,10) default NULL,
  PRIMARY KEY  (`invoice_line_id`),
  KEY `idx_external_invoice_line_invoice_id` (`invoice_id`),
  CONSTRAINT `ref_external_invoice_line_external_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `external_invoice` (`invoice_id`),
  CONSTRAINT `ref_external_invoice_line_invoice_line` FOREIGN KEY (`invoice_line_id`) REFERENCES `invoice_line` (`invoice_line_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `external_invoice_line` */

/*Table structure for table `healthcare_company` */

DROP TABLE IF EXISTS `healthcare_company`;

CREATE TABLE `healthcare_company` (
  `vatin` varchar(20) default NULL,
  `name` varchar(30) default NULL,
  `hc_id` int(11) NOT NULL auto_increment,
  `invoice_serial` varchar(255) default NULL,
  PRIMARY KEY  (`hc_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `healthcare_company` */

insert  into `healthcare_company`(`vatin`,`name`,`hc_id`,`invoice_serial`) values ('A111111','AriCliSalud S.L.',3,'FAC');

/*Table structure for table `insurance` */

DROP TABLE IF EXISTS `insurance`;

CREATE TABLE `insurance` (
  `name` varchar(50) default NULL,
  `internal` bit(1) NOT NULL,
  `insurance_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`insurance_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `insurance` */

insert  into `insurance`(`name`,`internal`,`insurance_id`) values ('SANITAS','\0',1),('CIGNA','\0',2),('CASER','\0',3),('ADESLAS','\0',4),('MAPFRE','\0',5),('SVS','\0',6),('DIVINA PASTORA - ASMEQUIVA','\0',7),('FIATC','\0',10),('GROUPAMA','\0',11),('ASISA','\0',12),('AMEFE','\0',13),('AXA WHINTERTUR','\0',14),('AEGON','\0',15),('DKV','\0',16);

/*Table structure for table `insurance_service` */

DROP TABLE IF EXISTS `insurance_service`;

CREATE TABLE `insurance_service` (
  `price` decimal(8,2) NOT NULL,
  `insurance_service_id` int(11) NOT NULL auto_increment,
  `service_id` int(11) default NULL,
  `insurance_id` int(11) default NULL,
  PRIMARY KEY  (`insurance_service_id`),
  KEY `idx_insurance_service_insurance_id` (`insurance_id`),
  KEY `idx_insurance_service_service_id` (`service_id`),
  CONSTRAINT `ref_insurance_service_insurance` FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`),
  CONSTRAINT `ref_insurance_service_service` FOREIGN KEY (`service_id`) REFERENCES `service` (`service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=latin1;

/*Data for the table `insurance_service` */

/*Table structure for table `invoice` */

DROP TABLE IF EXISTS `invoice`;

CREATE TABLE `invoice` (
  `serial` varchar(10) default NULL,
  `invoice_number` int(11) NOT NULL,
  `invoice_id` int(11) NOT NULL auto_increment,
  `invoice_date` datetime NOT NULL,
  `year` int(11) NOT NULL,
  `customer_id` int(11) default NULL,
  `total` decimal(12,2) NOT NULL,
  `voa_class` varchar(255) default NULL,
  PRIMARY KEY  (`invoice_id`),
  KEY `idx_invoice_customer_id` (`customer_id`),
  CONSTRAINT `ref_invoice_customer` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `invoice` */

/*Table structure for table `invoice_line` */

DROP TABLE IF EXISTS `invoice_line`;

CREATE TABLE `invoice_line` (
  `ticket_id` int(11) default NULL,
  `tax_percentage` decimal(20,10) NOT NULL,
  `invoice_line_id` int(11) NOT NULL auto_increment,
  `invoice_id` int(11) default NULL,
  `description` varchar(255) default NULL,
  `amount` decimal(20,10) NOT NULL,
  `user_id` int(11) default NULL,
  `tax_type_id` int(11) default NULL,
  `voa_class` varchar(255) default NULL,
  PRIMARY KEY  (`invoice_line_id`),
  KEY `idx_invoice_line_invoice_id` (`invoice_id`),
  KEY `idx_invoice_line_ticket_id` (`ticket_id`),
  KEY `idx_invoice_line_tax_type_id` (`tax_type_id`),
  KEY `idx_invoice_line_user_id` (`user_id`),
  CONSTRAINT `ref_invoice_line_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `ref_invoice_line_tax_type` FOREIGN KEY (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`),
  CONSTRAINT `ref_invoice_line_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`),
  CONSTRAINT `ref_invoice_line_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `invoice_line` */

/*Table structure for table `log` */

DROP TABLE IF EXISTS `log`;

CREATE TABLE `log` (
  `user_id` int(11) default NULL,
  `stamp` datetime NOT NULL,
  `remote_address` varchar(255) default NULL,
  `page` varchar(255) default NULL,
  `log_id` int(11) NOT NULL auto_increment,
  `action` varchar(255) default NULL,
  PRIMARY KEY  (`log_id`),
  KEY `idx_log_user_id` (`user_id`),
  CONSTRAINT `ref_log_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=932 DEFAULT CHARSET=latin1;

/*Data for the table `log` */

insert  into `log`(`user_id`,`stamp`,`remote_address`,`page`,`log_id`,`action`) values (3,'2011-05-30 17:52:36','127.0.0.1','Default.aspx',931,'Login');

/*Table structure for table `nomenclator` */

DROP TABLE IF EXISTS `nomenclator`;

CREATE TABLE `nomenclator` (
  `id` int(11) NOT NULL auto_increment,
  `name` varchar(250) default NULL,
  `group` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2088 DEFAULT CHARSET=latin1;

/*Data for the table `nomenclator` */

/*Table structure for table `parameter` */

DROP TABLE IF EXISTS `parameter`;

CREATE TABLE `parameter` (
  `parameter_id` int(11) NOT NULL,
  `service_id` int(11) default NULL,
  `use_nomenclator` bit(1) NOT NULL,
  PRIMARY KEY  (`parameter_id`),
  KEY `idx_parameter_service_id` (`service_id`),
  CONSTRAINT `ref_parameter_service` FOREIGN KEY (`service_id`) REFERENCES `service` (`service_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `parameter` */

/*Table structure for table `patient` */

DROP TABLE IF EXISTS `patient`;

CREATE TABLE `patient` (
  `surname2` varchar(30) default NULL,
  `surname1` varchar(30) default NULL,
  `name` varchar(30) default NULL,
  `customer_id` int(11) default NULL,
  `sex` varchar(1) default NULL,
  `born_date` datetime default NULL,
  `person_id` int(11) NOT NULL,
  PRIMARY KEY  (`person_id`),
  KEY `idx_patient_customer_id` (`customer_id`),
  CONSTRAINT `ref_patient_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `patient` */

/*Table structure for table `payment` */

DROP TABLE IF EXISTS `payment`;

CREATE TABLE `payment` (
  `ticket_id` int(11) default NULL,
  `payment_method_id` int(11) default NULL,
  `payment_id` int(11) NOT NULL auto_increment,
  `payment_date` datetime NOT NULL,
  `amount` decimal(20,10) NOT NULL,
  `user_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  PRIMARY KEY  (`payment_id`),
  KEY `idx_payment_payment_method_id` (`payment_method_id`),
  KEY `idx_payment_ticket_id` (`ticket_id`),
  KEY `idx_payment_user_id` (`user_id`),
  KEY `idx_payment_clinic_id` (`clinic_id`),
  CONSTRAINT `ref_payment_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_payment_payment_method` FOREIGN KEY (`payment_method_id`) REFERENCES `payment_method` (`payment_method_id`),
  CONSTRAINT `ref_payment_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`),
  CONSTRAINT `ref_payment_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `payment` */

/*Table structure for table `payment_method` */

DROP TABLE IF EXISTS `payment_method`;

CREATE TABLE `payment_method` (
  `payment_method_id` int(11) NOT NULL auto_increment,
  `nme` varchar(255) default NULL,
  PRIMARY KEY  (`payment_method_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `payment_method` */

/*Table structure for table `permission` */

DROP TABLE IF EXISTS `permission`;

CREATE TABLE `permission` (
  `view` bit(1) NOT NULL,
  `user_group_id` int(11) default NULL,
  `process_id` int(11) default NULL,
  `permission_id` int(11) NOT NULL auto_increment,
  `modify` bit(1) NOT NULL,
  `execute` bit(1) NOT NULL,
  `create` bit(1) NOT NULL,
  PRIMARY KEY  (`permission_id`),
  KEY `idx_permission_user_group_id` (`user_group_id`),
  KEY `idx_permission_process_id` (`process_id`),
  CONSTRAINT `ref_permission_process` FOREIGN KEY (`process_id`) REFERENCES `process` (`process_id`),
  CONSTRAINT `ref_permission_user_group` FOREIGN KEY (`user_group_id`) REFERENCES `user_group` (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=latin1;

/*Data for the table `permission` */

insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',15,2,1,'\0','\0','\0'),('',15,3,2,'\0','\0','\0'),('',15,4,3,'','\0',''),('\0',15,5,4,'\0','\0','\0'),('\0',16,2,5,'\0','\0','\0'),('',16,3,6,'\0','\0','\0'),('',16,4,7,'\0','\0','\0'),('',16,5,8,'\0','\0','\0'),('',14,2,9,'','',''),('',14,3,10,'','',''),('',14,4,11,'','',''),('',14,5,12,'','',''),('',14,6,13,'','',''),('',14,7,14,'\0','\0','\0'),('\0',15,6,15,'\0','\0','\0'),('',15,7,16,'\0','\0','\0'),('',16,6,17,'\0','\0','\0'),('',16,7,18,'\0','\0','\0'),('',14,8,19,'','',''),('',15,8,20,'\0','\0','\0'),('',14,9,21,'','',''),('',15,9,22,'\0','\0','\0'),('',14,10,23,'\0','\0','\0'),('',14,11,24,'','',''),('',14,12,25,'','',''),('',14,13,26,'','',''),('',14,14,27,'','',''),('',14,15,28,'','',''),('',14,16,29,'','',''),('',14,17,30,'','',''),('',14,18,31,'','',''),('',14,19,32,'','',''),('',14,20,33,'','',''),('',14,21,34,'','',''),('',14,22,35,'','',''),('',14,23,36,'','',''),('',14,24,37,'','',''),('',14,25,38,'','',''),('',14,26,39,'','',''),('',14,27,40,'','',''),('',14,28,41,'','',''),('',14,29,42,'','',''),('',14,30,43,'','',''),('',14,31,44,'','',''),('',14,32,45,'\0','\0','\0'),('',14,33,46,'','',''),('',14,34,47,'','',''),('',14,35,48,'','',''),('',14,36,49,'','',''),('',14,37,50,'\0','\0','\0'),('',14,38,51,'','',''),('',14,39,52,'','',''),('',14,40,53,'','',''),('',14,41,54,'','',''),('',14,42,55,'','',''),('',14,43,56,'','',''),('',14,44,57,'','',''),('',14,45,58,'','',''),('',14,46,59,'','',''),('',14,47,60,'','',''),('',14,48,61,'','',''),('',14,49,62,'','','');

/*Table structure for table `person` */

DROP TABLE IF EXISTS `person`;

CREATE TABLE `person` (
  `person_id` int(11) NOT NULL auto_increment,
  `full_name` varchar(100) default NULL,
  `voa_class` varchar(255) default NULL,
  PRIMARY KEY  (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=84 DEFAULT CHARSET=latin1;

/*Data for the table `person` */

/*Table structure for table `policy` */

DROP TABLE IF EXISTS `policy`;

CREATE TABLE `policy` (
  `typ` varchar(255) default NULL,
  `policy_number` varchar(255) default NULL,
  `policy_id` int(11) NOT NULL auto_increment,
  `end_date` datetime NOT NULL,
  `begin_date` datetime NOT NULL,
  `person_id` int(11) default NULL,
  `insurance_id` int(11) default NULL,
  PRIMARY KEY  (`policy_id`),
  KEY `idx_policy_person_id` (`person_id`),
  KEY `idx_policy_insurance_id` (`insurance_id`),
  CONSTRAINT `ref_policy_customer` FOREIGN KEY (`person_id`) REFERENCES `customer` (`person_id`),
  CONSTRAINT `ref_policy_insurance` FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=latin1;

/*Data for the table `policy` */

/*Table structure for table `procedure` */

DROP TABLE IF EXISTS `procedure`;

CREATE TABLE `procedure` (
  `procedure_id` int(11) NOT NULL auto_increment,
  `name` varchar(250) default NULL,
  `service_id` int(11) default NULL,
  PRIMARY KEY  (`procedure_id`),
  KEY `idx_procedure_service_id` (`service_id`),
  CONSTRAINT `ref_procedure_service` FOREIGN KEY (`service_id`) REFERENCES `service` (`service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2089 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `procedure` */

/*Table structure for table `process` */

DROP TABLE IF EXISTS `process`;

CREATE TABLE `process` (
  `process_id` int(11) NOT NULL auto_increment,
  `name` varchar(50) default NULL,
  `description` longtext,
  `parent_process_id` int(11) default NULL,
  `code` varchar(50) default NULL,
  PRIMARY KEY  (`process_id`),
  KEY `idx_process_parent_process_id` (`parent_process_id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=latin1;

/*Data for the table `process` */

insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (2,'Administracion','Punto del menú que corresponde a administración',NULL,'admin'),(3,'Grupos de usuarios','Corresponde al mantenimiento del grupo de usuarios',2,'usergroup'),(4,'Usuarios','Corresponde  al mantenimiento de usuarios',2,'user'),(5,'Procesos','Corresponde al mantenimiento de procesos',2,'process'),(6,'Permisos','Asignación de permisos a grupos de usuarios',2,'permission'),(7,'Salir','Salir de la aplicación',NULL,'exit'),(8,'Empresa sanitaria','Mantenimiento de los datos de empresa',2,'helcom'),(9,'Clinicas','Mantenimiento de clinicas',2,'clinic'),(10,'Facturación','Representa el elemento base del menú de facturación',NULL,'invoicing'),(11,'Categorias servicio','Mantenimiento de las categorias de servicio',10,'scat'),(12,'Tipos de IVA','Mantenimiento de tipos de IVA',10,'taxt'),(13,'Servicios','Servicios médicos',10,'ser'),(14,'Aseguradoras','Aseguradoras',10,'ins'),(15,'Pacientes','Pacientes',2,'patient'),(16,'Pólizas','Pólizas',15,'policy'),(17,'Tickets','Tickets',10,'ticket'),(18,'Clientes','Clientes',10,'customer'),(19,'Facturas','Facturas',10,'invoice'),(20,'Forma de pago','Forma de pago',10,'paymentmethod'),(21,'Cobros','Cobros',10,'payment'),(22,'Informes','Informes',NULL,'reports'),(23,'Tickets','Tickets',22,'rtickets'),(24,'Informe cobros','Cobros',22,'rpayments'),(25,'Profesionales','Profesionales',2,'professional'),(26,'Tipos de retencion','Tipos de retencion',10,'taxwt'),(27,'Procedimientos','Procedimientos',2,'procedure'),(28,'Notas de servicio (anestesia)','Notas de servicio (anestesia)',10,'asn'),(29,'Parámetros','Parámetros',2,'parameter'),(30,'Notas de servicio (general)','Notas de servicio (general)',10,'servicenote'),(31,'Liquidación','Liquidación',10,'settlement'),(32,'Interna','Contiene los mecanismos de creación de permisos',2,'admint'),(33,'Nomenclator','Contiene el nombre y servicio de todos los procedimientos ofertados',22,'rnomenclator'),(34,'Informe de profesionales','Muestra los profesionales y sus servicios realizados',37,'rprofessionalsrv'),(35,'Informe de categorías de servicio','Lista las categorías con sus servicios asociados.',37,'rcategorysrv'),(36,'comparativa de precios','Muestra la comparativa de precios de servicio de todas las compañías aseguradoras que lo ofertan.',37,'rsrvcomparer'),(37,'Informes de servicios','Cantiene informes con información relevante de los servicios',22,'rservices'),(38,'Facturas emitidas','Muestra las facturas emitidas en un periodo de tiempo determinado.',39,'rinvoicesPeriod'),(39,'Informes de facturas','Recoge todos los informes que muestran detalles de la facturación.',22,'infoFacturas'),(40,'Deudas del paciente','Muestra por cada paciente los tickets impagados',41,'rpatientdebt'),(41,'Informe de impagos','Contendrá otros informes aportando datos sobre los tickets impagados.',22,'debt'),(42,'Informe de deudas por aserguradora','Muestra los tickets impagados por cada aseguradora.',41,'rinsurancedebt'),(43,'Citación','Citación',NULL,'citation'),(44,'Tipo de cita','Tipo de cita',43,'apptype'),(45,'Agenda','Agenda',43,'agenda'),(46,'Citas','Citas',43,'appointment'),(47,'Historia Clínica','Punto del menúm principal que da acceso a todo lo relativo a la historia',NULL,'clinicalrecord'),(48,'Datos básicos','Submenú que cuelga de historia y que soporta las ocpiones de mantenimeinto de datos básicos en este grupo',47,'basedata'),(49,'Documentos','Proceso que muestra los documentos de la aplicación',47,'docs');

/*Table structure for table `professional` */

DROP TABLE IF EXISTS `professional`;

CREATE TABLE `professional` (
  `person_id` int(11) NOT NULL,
  `vatin` varchar(25) default NULL,
  `user_id` int(11) default NULL,
  `type` varchar(25) default NULL,
  `tax_withholding_type_id` int(11) default NULL,
  `invoice_serial` varchar(10) default NULL,
  `commission` decimal(5,2) default NULL,
  `comercial_name` varchar(50) default NULL,
  `license` varchar(25) default NULL,
  PRIMARY KEY  (`person_id`),
  KEY `idx_professional_tax_withholding_type_id` (`tax_withholding_type_id`),
  KEY `idx_professional_user_id` (`user_id`),
  CONSTRAINT `ref_professional_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`),
  CONSTRAINT `ref_professional_tax_withholding_type` FOREIGN KEY (`tax_withholding_type_id`) REFERENCES `tax_withholding_type` (`tax_withholding_type_id`),
  CONSTRAINT `ref_professional_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `professional` */

/*Table structure for table `service` */

DROP TABLE IF EXISTS `service`;

CREATE TABLE `service` (
  `service_id` int(11) NOT NULL auto_increment,
  `name` varchar(250) default NULL,
  `tax_type_id` int(11) default NULL,
  `service_category_id` int(11) default NULL,
  PRIMARY KEY  (`service_id`),
  KEY `idx_service_service_category_id` (`service_category_id`),
  KEY `idx_service_tax_type_id` (`tax_type_id`),
  CONSTRAINT `ref_service_service_category` FOREIGN KEY (`service_category_id`) REFERENCES `service_category` (`service_category_id`),
  CONSTRAINT `ref_service_tax_type` FOREIGN KEY (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1 CHECKSUM=1 DELAY_KEY_WRITE=1 ROW_FORMAT=DYNAMIC;

/*Data for the table `service` */

/*Table structure for table `service_category` */

DROP TABLE IF EXISTS `service_category`;

CREATE TABLE `service_category` (
  `service_category_id` int(11) NOT NULL auto_increment,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`service_category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `service_category` */

/*Table structure for table `service_note` */

DROP TABLE IF EXISTS `service_note`;

CREATE TABLE `service_note` (
  `user_id` int(11) default NULL,
  `service_note_date` datetime NOT NULL,
  `professional_person_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  `service_note_id` int(11) NOT NULL auto_increment,
  `customer_person_id` int(11) default NULL,
  `total` decimal(12,2) NOT NULL,
  `invoice_id` int(11) default NULL,
  PRIMARY KEY  (`service_note_id`),
  KEY `idx_service_note_clinic_id` (`clinic_id`),
  KEY `idx_service_note_professional_person_id` (`professional_person_id`),
  KEY `idx_service_note_user_id` (`user_id`),
  KEY `idx_service_note_customer_id` (`customer_person_id`),
  KEY `idx_service_note_invoice_id` (`invoice_id`),
  CONSTRAINT `ref_service_note_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_service_note_customer` FOREIGN KEY (`customer_person_id`) REFERENCES `customer` (`person_id`),
  CONSTRAINT `ref_service_note_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `ref_service_note_professional` FOREIGN KEY (`professional_person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_service_note_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `service_note` */

/*Table structure for table `tax_type` */

DROP TABLE IF EXISTS `tax_type`;

CREATE TABLE `tax_type` (
  `tax_type_id` int(11) NOT NULL auto_increment,
  `percentage` decimal(5,2) NOT NULL,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`tax_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `tax_type` */

/*Table structure for table `tax_withholding_type` */

DROP TABLE IF EXISTS `tax_withholding_type`;

CREATE TABLE `tax_withholding_type` (
  `tax_withholding_type_id` int(11) NOT NULL auto_increment,
  `percentage` decimal(5,2) NOT NULL,
  `name` varchar(30) default NULL,
  PRIMARY KEY  (`tax_withholding_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `tax_withholding_type` */

/*Table structure for table `telephone` */

DROP TABLE IF EXISTS `telephone`;

CREATE TABLE `telephone` (
  `telephone_id` int(11) NOT NULL auto_increment,
  `number` varchar(20) default NULL,
  `hc_id` int(11) default NULL,
  `type` varchar(10) default NULL,
  `clinic_id` int(11) default NULL,
  `person_id` int(11) default NULL,
  PRIMARY KEY  (`telephone_id`),
  KEY `idx_telephone_hc_id` (`hc_id`),
  KEY `idx_telephone_clinic_id` (`clinic_id`),
  KEY `idx_telephone_person_id` (`person_id`),
  CONSTRAINT `ref_telephone_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_telephone_healthcare_company` FOREIGN KEY (`hc_id`) REFERENCES `healthcare_company` (`hc_id`),
  CONSTRAINT `ref_telephone_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

/*Data for the table `telephone` */

/*Table structure for table `ticket` */

DROP TABLE IF EXISTS `ticket`;

CREATE TABLE `ticket` (
  `ticket_id` int(11) NOT NULL auto_increment,
  `description` varchar(255) default NULL,
  `amount` decimal(20,10) NOT NULL,
  `policy_id` int(11) default NULL,
  `insurance_service_id` int(11) default NULL,
  `user_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  `paid` decimal(20,10) NOT NULL,
  `comments` longtext,
  `checked` bit(1) NOT NULL,
  `person_id` int(11) default NULL,
  `voa_class` varchar(255) default NULL,
  `ticket_date` datetime NOT NULL,
  `service_note_id` int(11) default NULL,
  PRIMARY KEY  (`ticket_id`),
  KEY `idx_ticket_insurance_service_id` (`insurance_service_id`),
  KEY `idx_ticket_policy_id` (`policy_id`),
  KEY `idx_ticket_clinic_id` (`clinic_id`),
  KEY `idx_ticket_user_id` (`user_id`),
  KEY `idx_ticket_person_id` (`person_id`),
  KEY `idx_ticket_service_note_id` (`service_note_id`),
  CONSTRAINT `ref_ticket_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_ticket_insurance_service` FOREIGN KEY (`insurance_service_id`) REFERENCES `insurance_service` (`insurance_service_id`),
  CONSTRAINT `ref_ticket_policy` FOREIGN KEY (`policy_id`) REFERENCES `policy` (`policy_id`),
  CONSTRAINT `ref_ticket_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_ticket_service_note` FOREIGN KEY (`service_note_id`) REFERENCES `service_note` (`service_note_id`),
  CONSTRAINT `ref_ticket_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

/*Data for the table `ticket` */

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL auto_increment,
  `user_group_id` int(11) default NULL,
  `password` varchar(30) NOT NULL,
  `name` varchar(50) NOT NULL,
  `login` varchar(30) NOT NULL,
  PRIMARY KEY  (`user_id`),
  KEY `idx_user_user_group_id` (`user_group_id`),
  CONSTRAINT `ref_user_user_group` FOREIGN KEY (`user_group_id`) REFERENCES `user_group` (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Data for the table `user` */

insert  into `user`(`user_id`,`user_group_id`,`password`,`name`,`login`) values (3,14,'21232F297A57A5A743894A0E4A801F','Administrador','admin');

/*Table structure for table `user_group` */

DROP TABLE IF EXISTS `user_group`;

CREATE TABLE `user_group` (
  `user_group_id` int(11) NOT NULL auto_increment,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Data for the table `user_group` */

insert  into `user_group`(`user_group_id`,`name`) values (14,'Reservado (Administradores)'),(15,'Médicos'),(16,'Administrativos');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
