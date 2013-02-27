/*
SQLyog Community v9.02 
MySQL - 5.0.45-community-nt : Database - ariclinic_miestetic
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

/*Table structure for table `address` */

DROP TABLE IF EXISTS `address`;

CREATE TABLE `address` (
  `type` varchar(10) default NULL,
  `street2` varchar(100) default NULL,
  `street` varchar(50) default NULL,
  `province` varchar(255) default NULL,
  `post_code` varchar(10) default NULL,
  `person_id` int(11) default NULL,
  `hc_id` int(11) default NULL,
  `country` varchar(30) default NULL,
  `clinic_id` int(11) default NULL,
  `city` varchar(30) default NULL,
  `address_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`address_id`),
  KEY `idx_address_hc_id` (`hc_id`),
  KEY `idx_address_clinic_id` (`clinic_id`),
  KEY `idx_address_person_id` (`person_id`),
  CONSTRAINT `ref_address_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_address_healthcare_company` FOREIGN KEY (`hc_id`) REFERENCES `healthcare_company` (`hc_id`),
  CONSTRAINT `ref_address_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=61178 DEFAULT CHARSET=latin1;

/*Table structure for table `anesthetic_service_note` */

DROP TABLE IF EXISTS `anesthetic_service_note`;

CREATE TABLE `anesthetic_service_note` (
  `user_id` int(11) default NULL,
  `total` decimal(12,2) NOT NULL,
  `surgeon_person_id` int(11) default NULL,
  `service_note_date` datetime NOT NULL,
  `professional_person_id` int(11) default NULL,
  `invoice_id` int(11) default NULL,
  `customer_person_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  `chk2` bit(1) NOT NULL,
  `chk1` bit(1) NOT NULL,
  `anesthetic_service_note_id` int(11) NOT NULL auto_increment,
  `chk3` bit(1) NOT NULL,
  PRIMARY KEY  (`anesthetic_service_note_id`),
  KEY `idx_anesthetic_service_note_user_id` (`user_id`),
  KEY `idx_anesthetic_service_note_surgeon_person_id` (`surgeon_person_id`),
  KEY `idx_anesthetic_service_note_professional_person_id` (`professional_person_id`),
  KEY `idx_anesthetic_service_note_customer_id` (`customer_person_id`),
  KEY `idx_anesthetic_service_note_clinic_id` (`clinic_id`),
  KEY `idx_anesthetic_service_note_invoice_id` (`invoice_id`),
  CONSTRAINT `ref_anesthetic_service_note_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_anesthetic_service_note_customer` FOREIGN KEY (`customer_person_id`) REFERENCES `customer` (`person_id`),
  CONSTRAINT `ref_anesthetic_service_note_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `ref_anesthetic_service_note_professional` FOREIGN KEY (`professional_person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_anesthetic_service_note_professional2` FOREIGN KEY (`surgeon_person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_anesthetic_service_note_professional_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `professional_invoice` (`invoice_id`),
  CONSTRAINT `ref_anesthetic_service_note_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `anesthetic_service_note_procedures` */

DROP TABLE IF EXISTS `anesthetic_service_note_procedures`;

CREATE TABLE `anesthetic_service_note_procedures` (
  `anesthetic_service_note_id` int(11) NOT NULL default '0',
  `procedure_id` int(11) NOT NULL,
  PRIMARY KEY  (`anesthetic_service_note_id`,`procedure_id`),
  KEY `idx_anesthetic_service_note_procedures_procedure_id` (`procedure_id`),
  CONSTRAINT `ref_anesthetic_service_note_procedures_procedure` FOREIGN KEY (`procedure_id`) REFERENCES `procedure` (`procedure_id`),
  CONSTRAINT `ref_anesthetic_service_note_procedures_anesthetic_service_note` FOREIGN KEY (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `anesthetic_ticket` */

DROP TABLE IF EXISTS `anesthetic_ticket`;

CREATE TABLE `anesthetic_ticket` (
  `ticket_id` int(11) NOT NULL,
  `person_id` int(11) default NULL,
  `procedure_id` int(11) default NULL,
  `anesthetic_service_note_id` int(11) default NULL,
  PRIMARY KEY  (`ticket_id`),
  KEY `idx_anesthetic_ticket_person_id` (`person_id`),
  KEY `idx_anesthetic_ticket_anesthetic_service_note_id` (`anesthetic_service_note_id`),
  KEY `idx_anesthetic_ticket_procedure_id` (`procedure_id`),
  CONSTRAINT `ref_anesthetic_ticket_anesthetic_service_note` FOREIGN KEY (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`),
  CONSTRAINT `ref_anesthetic_ticket_procedure` FOREIGN KEY (`procedure_id`) REFERENCES `procedure` (`procedure_id`),
  CONSTRAINT `ref_anesthetic_ticket_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_anesthetic_ticket_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ant_segment` */

DROP TABLE IF EXISTS `ant_segment`;

CREATE TABLE `ant_segment` (
  `tyndall` varchar(255) default NULL,
  `pupil` varchar(255) default NULL,
  `visit_id` int(11) default NULL,
  `iris` varchar(255) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `eyestrain_r_e` decimal(20,10) NOT NULL,
  `eyestrain_l_e` decimal(20,10) NOT NULL,
  `eyebrows_comments` varchar(255) default NULL,
  `crystalline` varchar(255) default NULL,
  `cornea` varchar(255) default NULL,
  `conjunctiva` varchar(255) default NULL,
  `chamber` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_ant_segment_visit_id` (`visit_id`),
  CONSTRAINT `ref_ant_segment_ophthalmologic_visit` FOREIGN KEY (`visit_id`) REFERENCES `ophthalmologic_visit` (`visit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=127 DEFAULT CHARSET=latin1;

/*Table structure for table `appointment` */

DROP TABLE IF EXISTS `appointment`;

CREATE TABLE `appointment` (
  `user_id` int(11) default NULL,
  `subject` varchar(255) default NULL,
  `status` varchar(255) default NULL,
  `recurrence` varchar(255) default NULL,
  `person_id` int(11) default NULL,
  `person_id2` int(11) default NULL,
  `father_appointment_appointment_id` int(11) default NULL,
  `end_date_time` datetime NOT NULL,
  `duration` int(11) NOT NULL,
  `diary_id` int(11) default NULL,
  `comments` varchar(255) default NULL,
  `begin_date_time` datetime NOT NULL,
  `arrival` datetime NOT NULL,
  `appointment_type_id` int(11) default NULL,
  `appointment_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`appointment_id`),
  KEY `idx_appointment_info_user_id` (`user_id`),
  KEY `idx_appointment_info_person_id2` (`person_id2`),
  KEY `idx_appointment_info_person_id` (`person_id`),
  KEY `idx_appointment_info_father_appointment_appointment_id` (`father_appointment_appointment_id`),
  KEY `idx_appointment_info_diary_id` (`diary_id`),
  KEY `idx_appointment_info_appointment_type_id` (`appointment_type_id`),
  CONSTRAINT `ref_appointment_appointment_type` FOREIGN KEY (`appointment_type_id`) REFERENCES `appointment_type` (`appointment_type_id`),
  CONSTRAINT `ref_appointment_diary` FOREIGN KEY (`diary_id`) REFERENCES `diary` (`diary_id`),
  CONSTRAINT `ref_appointment_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_appointment_professional` FOREIGN KEY (`person_id2`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_appointment_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19273 DEFAULT CHARSET=latin1;

/*Table structure for table `appointment_type` */

DROP TABLE IF EXISTS `appointment_type`;

CREATE TABLE `appointment_type` (
  `oft_id` int(11) default NULL,
  `name` varchar(50) default NULL,
  `duration` int(11) NOT NULL,
  `appointment_type_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`appointment_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=latin1;

/*Table structure for table `back_family` */

DROP TABLE IF EXISTS `back_family`;

CREATE TABLE `back_family` (
  `back_family_id` int(11) NOT NULL auto_increment,
  `content` varchar(255) default NULL,
  `person_id` int(11) default NULL,
  PRIMARY KEY  (`back_family_id`),
  KEY `idx_back_family_person_id` (`person_id`),
  CONSTRAINT `ref_back_family_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `back_ginecoloy` */

DROP TABLE IF EXISTS `back_ginecoloy`;

CREATE TABLE `back_ginecoloy` (
  `abortions` int(11) NOT NULL,
  `back_ginecoloy_id` int(11) NOT NULL auto_increment,
  `cesarean_deliveries` int(11) NOT NULL,
  `content` longtext,
  `date_of_last_mestrual` datetime NOT NULL,
  `menarche` varchar(255) default NULL,
  `menopause` varchar(255) default NULL,
  `menstrual_formula` varchar(255) default NULL,
  `person_id` int(11) default NULL,
  `vaginal_deliveries` int(11) NOT NULL,
  PRIMARY KEY  (`back_ginecoloy_id`),
  KEY `idx_back_ginecoloy_person_id` (`person_id`),
  CONSTRAINT `ref_back_ginecoloy_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `back_personal` */

DROP TABLE IF EXISTS `back_personal`;

CREATE TABLE `back_personal` (
  `back_personal_id` int(11) NOT NULL auto_increment,
  `content` longtext,
  `person_id` int(11) default NULL,
  PRIMARY KEY  (`back_personal_id`),
  KEY `idx_back_personal_person_id` (`person_id`),
  CONSTRAINT `ref_back_personal_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `base_visit` */

DROP TABLE IF EXISTS `base_visit`;

CREATE TABLE `base_visit` (
  `vtype` varchar(255) default NULL,
  `visit_reason_id` int(11) default NULL,
  `visit_id` int(11) NOT NULL auto_increment,
  `visit_date` datetime NOT NULL,
  `person_id` int(11) default NULL,
  `person_id2` int(11) default NULL,
  `oft_ref_visita` int(11) NOT NULL,
  `comments` varchar(255) default NULL,
  `appointment_type_id` int(11) default NULL,
  `voa_class` varchar(255) default NULL,
  `appointment_id` int(11) default NULL,
  `code` varchar(255) default NULL,
  PRIMARY KEY  (`visit_id`),
  KEY `idx_base_visit_visit_reason_id` (`visit_reason_id`),
  KEY `idx_base_visit_person_id2` (`person_id2`),
  KEY `idx_base_visit_person_id` (`person_id`),
  KEY `idx_base_visit_appointment_type_id` (`appointment_type_id`),
  KEY `idx_base_visit_appointment_id` (`appointment_id`),
  KEY `idx_base_visit_code` (`code`),
  CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY (`code`) REFERENCES `base_visit_type` (`code`),
  CONSTRAINT `ref_base_visit_appointment` FOREIGN KEY (`appointment_id`) REFERENCES `appointment` (`appointment_id`),
  CONSTRAINT `ref_base_visit_appointment_type` FOREIGN KEY (`appointment_type_id`) REFERENCES `appointment_type` (`appointment_type_id`),
  CONSTRAINT `ref_base_visit_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_base_visit_professional` FOREIGN KEY (`person_id2`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_base_visit_visit_reason` FOREIGN KEY (`visit_reason_id`) REFERENCES `visit_reason` (`visit_reason_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18162 DEFAULT CHARSET=latin1;

/*Table structure for table `base_visit_type` */

DROP TABLE IF EXISTS `base_visit_type`;

CREATE TABLE `base_visit_type` (
  `code` varchar(255) NOT NULL,
  `nme` varchar(255) default NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `biometry` */

DROP TABLE IF EXISTS `biometry`;

CREATE TABLE `biometry` (
  `examination_assigned_id` int(11) NOT NULL,
  `lio_right_eye` decimal(20,10) default NULL,
  `lio_left_eye` decimal(20,10) default NULL,
  `formula` varchar(255) default NULL,
  `alx_right_eye` decimal(20,10) default NULL,
  `alx_left_eye` decimal(20,10) default NULL,
  PRIMARY KEY  (`examination_assigned_id`),
  CONSTRAINT `ref_biometry_examination_assigned` FOREIGN KEY (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `clinic` */

DROP TABLE IF EXISTS `clinic`;

CREATE TABLE `clinic` (
  `remote_ip` varchar(30) default NULL,
  `name` varchar(50) default NULL,
  `clinic_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`clinic_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Table structure for table `contact_lenses_test` */

DROP TABLE IF EXISTS `contact_lenses_test`;

CREATE TABLE `contact_lenses_test` (
  `examination_assigned_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_visual_acuity_both_eyes` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_visual_acuity_right_eye` varchar(255) default NULL,
  `close_visual_acuity_left_eye` varchar(255) default NULL,
  `close_visual_acuity_both_eyes` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_contact_lenses_test_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_contact_lenses_test_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9369 DEFAULT CHARSET=latin1;

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `person_id` int(11) NOT NULL,
  `vat_in` varchar(25) default NULL,
  `oft_id` int(11) default NULL,
  `comercial_name` varchar(50) default NULL,
  PRIMARY KEY  (`person_id`),
  CONSTRAINT `ref_customer_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `cycloplegia` */

DROP TABLE IF EXISTS `cycloplegia`;

CREATE TABLE `cycloplegia` (
  `examination_assigned_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_sphericity_right_eye` varchar(255) default NULL,
  `far_sphericity_left_eye` varchar(255) default NULL,
  `far_prism_left_eye` varchar(255) default NULL,
  `far_prims_right_eye` varchar(255) default NULL,
  `far_cylinder_right_eye` varchar(255) default NULL,
  `far_cylinder_left_eye` varchar(255) default NULL,
  `far_centers` varchar(255) default NULL,
  `far_axis_right_eye` varchar(255) default NULL,
  `far_axis_left_eye` varchar(255) default NULL,
  `far_acuity` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_sphericity_right_eye` varchar(255) default NULL,
  `close_sphericity_left_eye` varchar(255) default NULL,
  `close_sphericity_centers` int(11) NOT NULL,
  `close_prism_right_eye` varchar(255) default NULL,
  `close_prism_left_eye` varchar(255) default NULL,
  `close_cylinder_right_eye` varchar(255) default NULL,
  `close_cylinder_left_eye` varchar(255) default NULL,
  `close_centers` varchar(255) default NULL,
  `close_axis_right_eye` varchar(255) default NULL,
  `close_axis_left_eye` varchar(255) default NULL,
  `close_acuity_right_eye` varchar(255) default NULL,
  `close_acuity_left_eye` varchar(255) default NULL,
  `close_acuity` varchar(255) default NULL,
  `both_sphericity_right_eye` varchar(255) default NULL,
  `both_sphericity_left_eye` varchar(255) default NULL,
  `both_prism_right_eye` varchar(255) default NULL,
  `both_prism_left_eye` varchar(255) default NULL,
  `both_cylinder_right_eye` varchar(255) default NULL,
  `both_cylinder_left_eye` varchar(255) default NULL,
  `both_centers` varchar(255) default NULL,
  `both_axis_right_eye` varchar(255) default NULL,
  `both_axis_left_eye` varchar(255) default NULL,
  `both_acuity_right_eye` varchar(255) default NULL,
  `both_acuity_left_eye` varchar(255) default NULL,
  `both_acuity` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_cycloplegia_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_cycloplegia_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9404 DEFAULT CHARSET=latin1;

/*Table structure for table `diagnostic` */

DROP TABLE IF EXISTS `diagnostic`;

CREATE TABLE `diagnostic` (
  `oft_id` int(11) NOT NULL,
  `name` varchar(50) default NULL,
  `diagnostic_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`diagnostic_id`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=latin1;

/*Table structure for table `diagnostic_assigned` */

DROP TABLE IF EXISTS `diagnostic_assigned`;

CREATE TABLE `diagnostic_assigned` (
  `person_id` int(11) default NULL,
  `diagnostic_date` datetime NOT NULL,
  `diagnostic_assigned_id` int(11) NOT NULL auto_increment,
  `diagnostic_id` int(11) default NULL,
  `comments` longtext,
  `visit_id` int(11) default NULL,
  PRIMARY KEY  (`diagnostic_assigned_id`),
  KEY `idx_diagnostic_assigned_person_id` (`person_id`),
  KEY `idx_diagnostic_assigned_diagnostic_id` (`diagnostic_id`),
  KEY `idx_diagnostic_assigned_visit_id` (`visit_id`),
  CONSTRAINT `ref_diagnostic_assigned_base_visit` FOREIGN KEY (`visit_id`) REFERENCES `base_visit` (`visit_id`),
  CONSTRAINT `ref_diagnostic_assigned_diagnostic` FOREIGN KEY (`diagnostic_id`) REFERENCES `diagnostic` (`diagnostic_id`),
  CONSTRAINT `ref_diagnostic_assigned_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=539 DEFAULT CHARSET=latin1;

/*Table structure for table `diary` */

DROP TABLE IF EXISTS `diary`;

CREATE TABLE `diary` (
  `time_step` int(11) NOT NULL,
  `oft_id` int(11) default NULL,
  `nme` varchar(255) default NULL,
  `end_hour` datetime NOT NULL,
  `diary_id` int(11) NOT NULL auto_increment,
  `begin_hour` datetime NOT NULL,
  PRIMARY KEY  (`diary_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Table structure for table `drug` */

DROP TABLE IF EXISTS `drug`;

CREATE TABLE `drug` (
  `oft_id` int(11) NOT NULL,
  `name` varchar(50) default NULL,
  `drug_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`drug_id`)
) ENGINE=InnoDB AUTO_INCREMENT=830 DEFAULT CHARSET=latin1;

/*Table structure for table `email` */

DROP TABLE IF EXISTS `email`;

CREATE TABLE `email` (
  `url` varchar(50) default NULL,
  `type` varchar(10) default NULL,
  `person_id` int(11) default NULL,
  `hc_id` int(11) default NULL,
  `email_id` int(11) NOT NULL auto_increment,
  `clinic_id` int(11) default NULL,
  PRIMARY KEY  (`email_id`),
  KEY `idx_email_hc_id` (`hc_id`),
  KEY `idx_email_clinic_id` (`clinic_id`),
  KEY `idx_email_person_id` (`person_id`),
  CONSTRAINT `ref_email_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_email_healthcare_company` FOREIGN KEY (`hc_id`) REFERENCES `healthcare_company` (`hc_id`),
  CONSTRAINT `ref_email_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=41846 DEFAULT CHARSET=latin1;

/*Table structure for table `examination` */

DROP TABLE IF EXISTS `examination`;

CREATE TABLE `examination` (
  `oft_id` int(11) NOT NULL,
  `name` varchar(255) default NULL,
  `code` varchar(255) default NULL,
  `examination_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`examination_id`),
  KEY `ref_examination_examination_type` (`code`),
  CONSTRAINT `ref_examination_examination_type` FOREIGN KEY (`code`) REFERENCES `examination_type` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=latin1;

/*Table structure for table `examination_assigned` */

DROP TABLE IF EXISTS `examination_assigned`;

CREATE TABLE `examination_assigned` (
  `person_id` int(11) default NULL,
  `examination_date` datetime NOT NULL,
  `examination_assigned_id` int(11) NOT NULL auto_increment,
  `examination_id` int(11) default NULL,
  `comments` varchar(255) default NULL,
  `visit_id` int(11) default NULL,
  `voa_class` varchar(255) default NULL,
  PRIMARY KEY  (`examination_assigned_id`),
  KEY `idx_examination_assigned_person_id` (`person_id`),
  KEY `idx_examination_assigned_visit_id` (`visit_id`),
  KEY `ref_examination_assigned_examination` (`examination_id`),
  CONSTRAINT `ref_examination_assigned_base_visit` FOREIGN KEY (`visit_id`) REFERENCES `base_visit` (`visit_id`),
  CONSTRAINT `ref_examination_assigned_examination` FOREIGN KEY (`examination_id`) REFERENCES `examination` (`examination_id`),
  CONSTRAINT `ref_examination_assigned_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4906 DEFAULT CHARSET=latin1;

/*Table structure for table `examination_type` */

DROP TABLE IF EXISTS `examination_type`;

CREATE TABLE `examination_type` (
  `nme` varchar(255) default NULL,
  `code` varchar(255) NOT NULL,
  PRIMARY KEY  (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

/*Table structure for table `external_invoice_line` */

DROP TABLE IF EXISTS `external_invoice_line`;

CREATE TABLE `external_invoice_line` (
  `invoice_line_id` int(11) NOT NULL,
  `invoice_id` int(11) default NULL,
  `comission_amount` decimal(20,10) default NULL,
  PRIMARY KEY  (`invoice_line_id`),
  KEY `idx_external_invoice_line_invoice_id` (`invoice_id`),
  KEY `idx_xtrnl_nvc_ln_n` (`invoice_line_id`),
  CONSTRAINT `ref_external_invoice_line_invoice_line` FOREIGN KEY (`invoice_line_id`) REFERENCES `invoice_line` (`invoice_line_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `fundus` */

DROP TABLE IF EXISTS `fundus`;

CREATE TABLE `fundus` (
  `vitreous` text,
  `vessels` text,
  `periphery` text,
  `optic_nerve` text,
  `visit_id` int(11) default NULL,
  `macula` text,
  `id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`id`),
  KEY `idx_fundus_visit_id` (`visit_id`),
  CONSTRAINT `ref_fundus_ophthalmologic_visit` FOREIGN KEY (`visit_id`) REFERENCES `ophthalmologic_visit` (`visit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=127 DEFAULT CHARSET=latin1;

/*Table structure for table `general_payment` */

DROP TABLE IF EXISTS `general_payment`;

CREATE TABLE `general_payment` (
  `amount` decimal(20,10) NOT NULL,
  `description` varchar(255) default NULL,
  `general_payment_id` int(11) NOT NULL auto_increment,
  `payment_date` datetime NOT NULL,
  `payment_method_id` int(11) default NULL,
  `service_note_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  PRIMARY KEY  (`general_payment_id`),
  KEY `idx_general_payment_payment_method_id` (`payment_method_id`),
  KEY `idx_general_payment_service_note_id` (`service_note_id`),
  KEY `idx_general_payment_clinic_id` (`clinic_id`),
  CONSTRAINT `ref_general_payment_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_general_payment_payment_method` FOREIGN KEY (`payment_method_id`) REFERENCES `payment_method` (`payment_method_id`),
  CONSTRAINT `ref_general_payment_service_note` FOREIGN KEY (`service_note_id`) REFERENCES `service_note` (`service_note_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6780 DEFAULT CHARSET=latin1;

/*Table structure for table `general_visit` */

DROP TABLE IF EXISTS `general_visit`;

CREATE TABLE `general_visit` (
  `visit_reason_id` int(11) default NULL,
  `visit_id` int(11) NOT NULL auto_increment,
  `visit_date` datetime NOT NULL,
  `person_id` int(11) default NULL,
  `person_id2` int(11) default NULL,
  `comments` varchar(255) default NULL,
  PRIMARY KEY  (`visit_id`),
  KEY `idx_general_visit_visit_reason_id` (`visit_reason_id`),
  KEY `idx_general_visit_person_id2` (`person_id2`),
  KEY `idx_general_visit_person_id` (`person_id`),
  CONSTRAINT `ref_general_visit_patient` FOREIGN KEY (`person_id2`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_general_visit_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_general_visit_visit_reason` FOREIGN KEY (`visit_reason_id`) REFERENCES `visit_reason` (`visit_reason_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `glasses_test` */

DROP TABLE IF EXISTS `glasses_test`;

CREATE TABLE `glasses_test` (
  `examination_assigned_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_sphericity_right_eye` varchar(255) default NULL,
  `far_sphericity_left_eye` varchar(255) default NULL,
  `far_prism_left_eye` varchar(255) default NULL,
  `far_prims_right_eye` varchar(255) default NULL,
  `far_cylinder_right_eye` varchar(255) default NULL,
  `far_cylinder_left_eye` varchar(255) default NULL,
  `far_centers` varchar(255) default NULL,
  `far_axis_right_eye` varchar(255) default NULL,
  `far_axis_left_eye` varchar(255) default NULL,
  `far_acuity` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_sphericity_right_eye` varchar(255) default NULL,
  `close_sphericity_left_eye` varchar(255) default NULL,
  `close_sphericity_centers` int(11) NOT NULL,
  `close_prism_right_eye` varchar(255) default NULL,
  `close_prism_left_eye` varchar(255) default NULL,
  `close_cylinder_right_eye` varchar(255) default NULL,
  `close_cylinder_left_eye` varchar(255) default NULL,
  `close_centers` varchar(255) default NULL,
  `close_axis_right_eye` varchar(255) default NULL,
  `close_axis_left_eye` varchar(255) default NULL,
  `close_acuity_right_eye` varchar(255) default NULL,
  `close_acuity_left_eye` varchar(255) default NULL,
  `close_acuity` varchar(255) default NULL,
  `both_sphericity_right_eye` varchar(255) default NULL,
  `both_sphericity_left_eye` varchar(255) default NULL,
  `both_prism_right_eye` varchar(255) default NULL,
  `both_prism_left_eye` varchar(255) default NULL,
  `both_cylinder_right_eye` varchar(255) default NULL,
  `both_cylinder_left_eye` varchar(255) default NULL,
  `both_centers` varchar(255) default NULL,
  `both_axis_right_eye` varchar(255) default NULL,
  `both_axis_left_eye` varchar(255) default NULL,
  `both_acuity_right_eye` varchar(255) default NULL,
  `both_acuity_left_eye` varchar(255) default NULL,
  `both_acuity` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_glasses_test_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_glasses_test_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9369 DEFAULT CHARSET=latin1;

/*Table structure for table `healthcare_company` */

DROP TABLE IF EXISTS `healthcare_company`;

CREATE TABLE `healthcare_company` (
  `hc_id` int(11) NOT NULL auto_increment,
  `invoice_serial` varchar(30) default NULL,
  `name` varchar(30) default NULL,
  `vatin` varchar(20) default NULL,
  PRIMARY KEY  (`hc_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `insurance` */

DROP TABLE IF EXISTS `insurance`;

CREATE TABLE `insurance` (
  `oft_id` int(11) NOT NULL,
  `name` varchar(50) default NULL,
  `internal` bit(1) NOT NULL,
  `insurance_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`insurance_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `insurance_service` */

DROP TABLE IF EXISTS `insurance_service`;

CREATE TABLE `insurance_service` (
  `service_id` int(11) default NULL,
  `price` decimal(8,2) NOT NULL,
  `oft_id` int(11) NOT NULL,
  `insurance_service_id` int(11) NOT NULL auto_increment,
  `insurance_id` int(11) default NULL,
  PRIMARY KEY  (`insurance_service_id`),
  KEY `idx_insurance_service_insurance_id` (`insurance_id`),
  KEY `idx_insurance_service_service_id` (`service_id`),
  CONSTRAINT `ref_insurance_service_insurance` FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`),
  CONSTRAINT `ref_insurance_service_service` FOREIGN KEY (`service_id`) REFERENCES `service` (`service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=87 DEFAULT CHARSET=latin1;

/*Table structure for table `invoice` */

DROP TABLE IF EXISTS `invoice`;

CREATE TABLE `invoice` (
  `year` int(11) NOT NULL,
  `total` decimal(12,2) NOT NULL,
  `serial` varchar(10) default NULL,
  `invoice_number` int(11) NOT NULL,
  `invoice_id` int(11) NOT NULL auto_increment,
  `invoice_date` datetime NOT NULL,
  `customer_id` int(11) default NULL,
  `invoice_key` varchar(255) default NULL,
  PRIMARY KEY  (`invoice_id`),
  KEY `idx_invoice_customer_id` (`customer_id`),
  CONSTRAINT `ref_invoice_customer` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=710 DEFAULT CHARSET=latin1;

/*Table structure for table `invoice_line` */

DROP TABLE IF EXISTS `invoice_line`;

CREATE TABLE `invoice_line` (
  `user_id` int(11) default NULL,
  `ticket_id` int(11) default NULL,
  `tax_type_id` int(11) default NULL,
  `tax_percentage` decimal(20,10) NOT NULL,
  `invoice_line_id` int(11) NOT NULL auto_increment,
  `invoice_id` int(11) default NULL,
  `description` varchar(255) default NULL,
  `amount` decimal(20,10) NOT NULL,
  PRIMARY KEY  (`invoice_line_id`),
  KEY `idx_invoice_line_ticket_id` (`ticket_id`),
  KEY `idx_invoice_line_invoice_id` (`invoice_id`),
  KEY `idx_invoice_line_tax_type_id` (`tax_type_id`),
  KEY `idx_invoice_line_user_id` (`user_id`),
  CONSTRAINT `ref_invoice_line_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `ref_invoice_line_tax_type` FOREIGN KEY (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`),
  CONSTRAINT `ref_invoice_line_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`),
  CONSTRAINT `ref_invoice_line_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1516 DEFAULT CHARSET=latin1;

/*Table structure for table `lab_test` */

DROP TABLE IF EXISTS `lab_test`;

CREATE TABLE `lab_test` (
  `unit_type_id` int(11) default NULL,
  `nme` varchar(255) default NULL,
  `min_value` decimal(20,10) NOT NULL,
  `max_value` decimal(20,10) NOT NULL,
  `lab_test_id` int(11) NOT NULL auto_increment,
  `general_type` varchar(10) default NULL,
  PRIMARY KEY  (`lab_test_id`),
  KEY `idx_lab_test_unit_type_id` (`unit_type_id`),
  CONSTRAINT `ref_lab_test_unit_type` FOREIGN KEY (`unit_type_id`) REFERENCES `unit_type` (`unit_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `lab_test_assigned` */

DROP TABLE IF EXISTS `lab_test_assigned`;

CREATE TABLE `lab_test_assigned` (
  `string_value` varchar(255) default NULL,
  `person_id` int(11) default NULL,
  `num_value` decimal(20,10) NOT NULL,
  `lab_test_date` datetime NOT NULL,
  `lab_test_assigned_id` int(11) NOT NULL auto_increment,
  `lab_test_id` int(11) default NULL,
  `comments` text,
  `visit_id` int(11) default NULL,
  PRIMARY KEY  (`lab_test_assigned_id`),
  KEY `idx_lab_test_assigned_lab_test_id` (`lab_test_id`),
  KEY `idx_lab_test_assigned_visit_id` (`visit_id`),
  KEY `idx_lab_test_assigned_person_id` (`person_id`),
  CONSTRAINT `ref_lab_test_assigned_base_visit` FOREIGN KEY (`visit_id`) REFERENCES `base_visit` (`visit_id`),
  CONSTRAINT `ref_lab_test_assigned_lab_test` FOREIGN KEY (`lab_test_id`) REFERENCES `lab_test` (`lab_test_id`),
  CONSTRAINT `ref_lab_test_assigned_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=1002 DEFAULT CHARSET=latin1;

/*Table structure for table `mot_append` */

DROP TABLE IF EXISTS `mot_append`;

CREATE TABLE `mot_append` (
  `periocular_area` text,
  `visit_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `eye_motility` text,
  `eyebrows` text,
  `comments` text,
  `c9_r_e` decimal(20,10) NOT NULL,
  `c9_l_e` decimal(20,10) NOT NULL,
  `c8_r_e` decimal(20,10) NOT NULL,
  `c8_l_e` decimal(20,10) NOT NULL,
  `c7_r_e` decimal(20,10) NOT NULL,
  `c7_l_e` decimal(20,10) NOT NULL,
  `c6_r_e` decimal(20,10) NOT NULL,
  `c6_l_e` decimal(20,10) NOT NULL,
  `c5_r_e` decimal(20,10) NOT NULL,
  `c5_l_e` decimal(20,10) NOT NULL,
  `c4_r_e` decimal(20,10) NOT NULL,
  `c4_l_e` decimal(20,10) NOT NULL,
  `c3_r_e` decimal(20,10) NOT NULL,
  `c3_l_e` decimal(20,10) NOT NULL,
  `c2_r_e` decimal(20,10) NOT NULL,
  `c2_l_e` decimal(20,10) NOT NULL,
  `c1_r_e` decimal(20,10) NOT NULL,
  `c1_l_e` decimal(20,10) NOT NULL,
  `c12_r_e` decimal(20,10) NOT NULL,
  `c12_l_e` decimal(20,10) NOT NULL,
  `c11_r_e` decimal(20,10) NOT NULL,
  `c11_l_e` decimal(20,10) NOT NULL,
  `c10_r_e` decimal(20,10) NOT NULL,
  `c10_l_e` decimal(20,10) NOT NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_mot_append_visit_id` (`visit_id`),
  CONSTRAINT `ref_mot_append_ophthalmologic_visit` FOREIGN KEY (`visit_id`) REFERENCES `ophthalmologic_visit` (`visit_id`)
) ENGINE=InnoDB AUTO_INCREMENT=127 DEFAULT CHARSET=latin1;

/*Table structure for table `nomenclator` */

DROP TABLE IF EXISTS `nomenclator`;

CREATE TABLE `nomenclator` (
  `name` varchar(250) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `group` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `ophthalmologic_visit` */

DROP TABLE IF EXISTS `ophthalmologic_visit`;

CREATE TABLE `ophthalmologic_visit` (
  `visit_id` int(11) NOT NULL,
  `diagnostic_details` text,
  PRIMARY KEY  (`visit_id`),
  CONSTRAINT `ref_ophthalmologic_visit_base_visit` FOREIGN KEY (`visit_id`) REFERENCES `base_visit` (`visit_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `optical_objective_examination` */

DROP TABLE IF EXISTS `optical_objective_examination`;

CREATE TABLE `optical_objective_examination` (
  `examination_assigned_id` int(11) default NULL,
  `k2_right_eye` varchar(255) default NULL,
  `k2_left_eye` varchar(255) default NULL,
  `k1_right_eye` varchar(255) default NULL,
  `k1_left_eye` varchar(255) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_sphericity_right_eye` varchar(255) default NULL,
  `far_sphericity_left_eye` varchar(255) default NULL,
  `far_prism_left_eye` varchar(255) default NULL,
  `far_prims_right_eye` varchar(255) default NULL,
  `far_cylinder_right_eye` varchar(255) default NULL,
  `far_cylinder_left_eye` varchar(255) default NULL,
  `far_centers` varchar(255) default NULL,
  `far_axis_right_eye` varchar(255) default NULL,
  `far_axis_left_eye` varchar(255) default NULL,
  `far_acuity` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_sphericity_right_eye` varchar(255) default NULL,
  `close_sphericity_left_eye` varchar(255) default NULL,
  `close_sphericity_centers` int(11) NOT NULL,
  `close_prism_right_eye` varchar(255) default NULL,
  `close_prism_left_eye` varchar(255) default NULL,
  `close_cylinder_right_eye` varchar(255) default NULL,
  `close_cylinder_left_eye` varchar(255) default NULL,
  `close_centers` varchar(255) default NULL,
  `close_axis_right_eye` varchar(255) default NULL,
  `close_axis_left_eye` varchar(255) default NULL,
  `close_acuity_right_eye` varchar(255) default NULL,
  `close_acuity_left_eye` varchar(255) default NULL,
  `close_acuity` varchar(255) default NULL,
  `both_sphericity_right_eye` varchar(255) default NULL,
  `both_sphericity_left_eye` varchar(255) default NULL,
  `both_prism_right_eye` varchar(255) default NULL,
  `both_prism_left_eye` varchar(255) default NULL,
  `both_cylinder_right_eye` varchar(255) default NULL,
  `both_cylinder_left_eye` varchar(255) default NULL,
  `both_centers` varchar(255) default NULL,
  `both_axis_right_eye` varchar(255) default NULL,
  `both_axis_left_eye` varchar(255) default NULL,
  `both_acuity_right_eye` varchar(255) default NULL,
  `both_acuity_left_eye` varchar(255) default NULL,
  `both_acuity` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_optical_objective_examination_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_optical_objective_examination_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9369 DEFAULT CHARSET=latin1;

/*Table structure for table `paquimetry` */

DROP TABLE IF EXISTS `paquimetry`;

CREATE TABLE `paquimetry` (
  `examination_assigned_id` int(11) NOT NULL,
  `right_eye_central_c0` decimal(20,10) default NULL,
  `right_eye_c7` decimal(20,10) default NULL,
  `right_eye_c5` decimal(20,10) default NULL,
  `right_eye_c3` decimal(20,10) default NULL,
  `right_eye_c1` decimal(20,10) default NULL,
  `left_eye_central_c0` decimal(20,10) default NULL,
  `left_eye_c7` decimal(20,10) default NULL,
  `left_eye_c5` decimal(20,10) default NULL,
  `left_eye_c3` decimal(20,10) default NULL,
  `left_eye_c1` decimal(20,10) default NULL,
  PRIMARY KEY  (`examination_assigned_id`),
  CONSTRAINT `ref_paquimetry_examination_assigned` FOREIGN KEY (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `parameter` */

DROP TABLE IF EXISTS `parameter`;

CREATE TABLE `parameter` (
  `use_nomenclator` bit(1) NOT NULL,
  `parameter_id` int(11) NOT NULL,
  `service_id` int(11) default NULL,
  `appointment_extension` bit(1) NOT NULL,
  PRIMARY KEY  (`parameter_id`),
  KEY `idx_parameter_service_id` (`service_id`),
  CONSTRAINT `ref_parameter_service` FOREIGN KEY (`service_id`) REFERENCES `service` (`service_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `patient` */

DROP TABLE IF EXISTS `patient`;

CREATE TABLE `patient` (
  `person_id` int(11) NOT NULL,
  `surname2` varchar(30) default NULL,
  `surname1` varchar(30) default NULL,
  `sex` varchar(1) default NULL,
  `oft_id` int(11) default NULL,
  `name` varchar(30) default NULL,
  `last_update` datetime default NULL,
  `person_id2` int(11) default NULL,
  `comments` longtext,
  `born_date` datetime default NULL,
  `clinic_id` int(11) default NULL,
  `insurance_information` varchar(255) default NULL,
  `open_date` datetime default NULL,
  PRIMARY KEY  (`person_id`),
  KEY `idx_patient_person_id2` (`person_id2`),
  KEY `idx_patient_clinic_id` (`clinic_id`),
  CONSTRAINT `ref_patient_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_patient_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `payment` */

DROP TABLE IF EXISTS `payment`;

CREATE TABLE `payment` (
  `user_id` int(11) default NULL,
  `ticket_id` int(11) default NULL,
  `payment_method_id` int(11) default NULL,
  `payment_id` int(11) NOT NULL auto_increment,
  `payment_date` datetime NOT NULL,
  `oft_id` int(11) default NULL,
  `description` varchar(50) default NULL,
  `clinic_id` int(11) default NULL,
  `amount` decimal(20,10) NOT NULL,
  `general_payment_id` int(11) default NULL,
  PRIMARY KEY  (`payment_id`),
  KEY `idx_payment_user_id` (`user_id`),
  KEY `idx_payment_ticket_id` (`ticket_id`),
  KEY `idx_payment_payment_method_id` (`payment_method_id`),
  KEY `idx_payment_clinic_id` (`clinic_id`),
  KEY `idx_payment_general_payment_id` (`general_payment_id`),
  CONSTRAINT `ref_payment_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_payment_general_payment` FOREIGN KEY (`general_payment_id`) REFERENCES `general_payment` (`general_payment_id`),
  CONSTRAINT `ref_payment_payment_method` FOREIGN KEY (`payment_method_id`) REFERENCES `payment_method` (`payment_method_id`),
  CONSTRAINT `ref_payment_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`),
  CONSTRAINT `ref_payment_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14347 DEFAULT CHARSET=latin1;

/*Table structure for table `payment_method` */

DROP TABLE IF EXISTS `payment_method`;

CREATE TABLE `payment_method` (
  `payment_method_id` int(11) NOT NULL auto_increment,
  `oft_id` int(11) default NULL,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`payment_method_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB AUTO_INCREMENT=146 DEFAULT CHARSET=latin1;

/*Table structure for table `person` */

DROP TABLE IF EXISTS `person`;

CREATE TABLE `person` (
  `source_id` int(11) default NULL,
  `person_id` int(11) NOT NULL auto_increment,
  `full_name` varchar(100) default NULL,
  `voa_class` varchar(255) default NULL,
  PRIMARY KEY  (`person_id`),
  KEY `idx_person_source_id` (`source_id`),
  CONSTRAINT `ref_person_source` FOREIGN KEY (`source_id`) REFERENCES `source` (`source_id`)
) ENGINE=InnoDB AUTO_INCREMENT=30828 DEFAULT CHARSET=latin1;

/*Table structure for table `policy` */

DROP TABLE IF EXISTS `policy`;

CREATE TABLE `policy` (
  `type` varchar(20) default NULL,
  `policy_number` varchar(255) default NULL,
  `policy_id` int(11) NOT NULL auto_increment,
  `oft_id` int(11) NOT NULL,
  `insurance_id` int(11) default NULL,
  `end_date` datetime NOT NULL,
  `person_id` int(11) default NULL,
  `begin_date` datetime NOT NULL,
  PRIMARY KEY  (`policy_id`),
  KEY `idx_policy_person_id` (`person_id`),
  KEY `idx_policy_insurance_id` (`insurance_id`),
  CONSTRAINT `ref_policy_customer` FOREIGN KEY (`person_id`) REFERENCES `customer` (`person_id`),
  CONSTRAINT `ref_policy_insurance` FOREIGN KEY (`insurance_id`) REFERENCES `insurance` (`insurance_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15351 DEFAULT CHARSET=latin1;

/*Table structure for table `prescription_glasses` */

DROP TABLE IF EXISTS `prescription_glasses`;

CREATE TABLE `prescription_glasses` (
  `examination_assigned_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_sphericity_right_eye` varchar(255) default NULL,
  `far_sphericity_left_eye` varchar(255) default NULL,
  `far_prism_left_eye` varchar(255) default NULL,
  `far_prims_right_eye` varchar(255) default NULL,
  `far_cylinder_right_eye` varchar(255) default NULL,
  `far_cylinder_left_eye` varchar(255) default NULL,
  `far_centers` varchar(255) default NULL,
  `far_axis_right_eye` varchar(255) default NULL,
  `far_axis_left_eye` varchar(255) default NULL,
  `far_acuity` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_sphericity_right_eye` varchar(255) default NULL,
  `close_sphericity_left_eye` varchar(255) default NULL,
  `close_sphericity_centers` int(11) NOT NULL,
  `close_prism_right_eye` varchar(255) default NULL,
  `close_prism_left_eye` varchar(255) default NULL,
  `close_cylinder_right_eye` varchar(255) default NULL,
  `close_cylinder_left_eye` varchar(255) default NULL,
  `close_centers` varchar(255) default NULL,
  `close_axis_right_eye` varchar(255) default NULL,
  `close_axis_left_eye` varchar(255) default NULL,
  `close_acuity_right_eye` varchar(255) default NULL,
  `close_acuity_left_eye` varchar(255) default NULL,
  `close_acuity` varchar(255) default NULL,
  `both_sphericity_right_eye` varchar(255) default NULL,
  `both_sphericity_left_eye` varchar(255) default NULL,
  `both_prism_right_eye` varchar(255) default NULL,
  `both_prism_left_eye` varchar(255) default NULL,
  `both_cylinder_right_eye` varchar(255) default NULL,
  `both_cylinder_left_eye` varchar(255) default NULL,
  `both_centers` varchar(255) default NULL,
  `both_axis_right_eye` varchar(255) default NULL,
  `both_axis_left_eye` varchar(255) default NULL,
  `both_acuity_right_eye` varchar(255) default NULL,
  `both_acuity_left_eye` varchar(255) default NULL,
  `both_acuity` varchar(255) default NULL,
  `sign_MD` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_prescription_glasses_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_prescription_glasses_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9402 DEFAULT CHARSET=latin1;

/*Table structure for table `previous_medical_record` */

DROP TABLE IF EXISTS `previous_medical_record`;

CREATE TABLE `previous_medical_record` (
  `content` longtext,
  `person_id` int(11) default NULL,
  `previous_medical_record_id` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`previous_medical_record_id`),
  KEY `idx_previous_medical_record_person_id` (`person_id`),
  CONSTRAINT `ref_previous_medical_record_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `procedure` */

DROP TABLE IF EXISTS `procedure`;

CREATE TABLE `procedure` (
  `service_id` int(11) default NULL,
  `procedure_id` int(11) NOT NULL auto_increment,
  `oft_id` int(11) NOT NULL,
  `name` varchar(250) default NULL,
  PRIMARY KEY  (`procedure_id`),
  KEY `idx_procedure_service_id` (`service_id`),
  CONSTRAINT `ref_procedure_service` FOREIGN KEY (`service_id`) REFERENCES `service` (`service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=latin1;

/*Table structure for table `procedure_assigned` */

DROP TABLE IF EXISTS `procedure_assigned`;

CREATE TABLE `procedure_assigned` (
  `procedure_date` datetime NOT NULL,
  `procedure_assigned_id` int(11) NOT NULL auto_increment,
  `procedure_id` int(11) default NULL,
  `person_id` int(11) default NULL,
  `comments` text,
  `visit_id` int(11) default NULL,
  PRIMARY KEY  (`procedure_assigned_id`),
  KEY `idx_procedure_assigned_procedure_id` (`procedure_id`),
  KEY `idx_procedure_assigned_person_id` (`person_id`),
  KEY `idx_procedure_assigned_visit_id` (`visit_id`),
  CONSTRAINT `ref_procedure_assigned_base_visit` FOREIGN KEY (`visit_id`) REFERENCES `base_visit` (`visit_id`),
  CONSTRAINT `ref_procedure_assigned_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_procedure_assigned_procedure` FOREIGN KEY (`procedure_id`) REFERENCES `procedure` (`procedure_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1024 DEFAULT CHARSET=latin1;

/*Table structure for table `procesos` */

DROP TABLE IF EXISTS `procesos`;

CREATE TABLE `procesos` (
  `process_id` int(11) NOT NULL auto_increment,
  `parent_process_id` int(11) default NULL,
  `name` varchar(50) default NULL,
  `description` longtext,
  `code` varchar(50) default NULL,
  PRIMARY KEY  (`process_id`),
  KEY `idx_process_parent_process_id` (`parent_process_id`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=latin1;

/*Table structure for table `process` */

DROP TABLE IF EXISTS `process`;

CREATE TABLE `process` (
  `process_id` int(11) NOT NULL auto_increment,
  `parent_process_id` int(11) default NULL,
  `name` varchar(50) default NULL,
  `description` longtext,
  `code` varchar(50) default NULL,
  PRIMARY KEY  (`process_id`),
  KEY `idx_process_parent_process_id` (`parent_process_id`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=latin1;

/*Table structure for table `professional` */

DROP TABLE IF EXISTS `professional`;

CREATE TABLE `professional` (
  `person_id` int(11) NOT NULL,
  `vatin` varchar(25) default NULL,
  `user_id` int(11) default NULL,
  `type` varchar(25) default NULL,
  `tax_withholding_type_id` int(11) default NULL,
  `oft_id` int(11) default NULL,
  `license` varchar(25) default NULL,
  `invoice_serial` varchar(10) default NULL,
  `commission` decimal(5,2) default NULL,
  `comercial_name` varchar(50) default NULL,
  PRIMARY KEY  (`person_id`),
  KEY `idx_professional_tax_withholding_type_id` (`tax_withholding_type_id`),
  KEY `idx_prfssnl_prsn_d` (`person_id`),
  KEY `idx_professional_user_id` (`user_id`),
  CONSTRAINT `ref_professional_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`),
  CONSTRAINT `ref_professional_tax_withholding_type` FOREIGN KEY (`tax_withholding_type_id`) REFERENCES `tax_withholding_type` (`tax_withholding_type_id`),
  CONSTRAINT `ref_professional_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `professional_invoice` */

DROP TABLE IF EXISTS `professional_invoice`;

CREATE TABLE `professional_invoice` (
  `total` decimal(20,10) NOT NULL,
  `invoice_date` datetime NOT NULL,
  `invoice_id` int(11) NOT NULL auto_increment,
  `invoice_number` int(11) NOT NULL,
  `person_id` int(11) default NULL,
  `serial` varchar(30) NOT NULL,
  `tax_whith_holding_percentage` decimal(20,10) NOT NULL,
  `year` int(11) NOT NULL,
  `invoice_key` varchar(255) default NULL,
  PRIMARY KEY  (`invoice_id`),
  KEY `idx_professional_invoice_person_id` (`person_id`),
  CONSTRAINT `ref_professional_invoice_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `professional_invoice_line` */

DROP TABLE IF EXISTS `professional_invoice_line`;

CREATE TABLE `professional_invoice_line` (
  `ticket_id` int(11) default NULL,
  `taxtype_id` int(11) NOT NULL,
  `tax_percentage` decimal(20,10) NOT NULL,
  `invoice_id` int(11) default NULL,
  `invoice_line_id` int(11) NOT NULL auto_increment,
  `description` varchar(255) default NULL,
  `amount` decimal(20,10) NOT NULL,
  PRIMARY KEY  (`invoice_line_id`),
  KEY `idx_professional_invoice_line_ticket_id` (`ticket_id`),
  KEY `idx_professional_invoice_line_invoice_id` (`invoice_id`),
  KEY `idx_professional_invoice_line_taxtype_id` (`taxtype_id`),
  CONSTRAINT `ref_professional_invoice_line_professional_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `professional_invoice` (`invoice_id`),
  CONSTRAINT `ref_professional_invoice_line_tax_type` FOREIGN KEY (`taxtype_id`) REFERENCES `tax_type` (`tax_type_id`),
  CONSTRAINT `ref_professional_invoice_line_ticket` FOREIGN KEY (`ticket_id`) REFERENCES `ticket` (`ticket_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `prt_last_update` */

DROP TABLE IF EXISTS `prt_last_update`;

CREATE TABLE `prt_last_update` (
  `person_id` int(11) default NULL,
  `max_visit_date` datetime default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `refractometry` */

DROP TABLE IF EXISTS `refractometry`;

CREATE TABLE `refractometry` (
  `examination_assigned_id` int(11) NOT NULL,
  PRIMARY KEY  (`examination_assigned_id`),
  CONSTRAINT `ref_refractometry_examination_assigned` FOREIGN KEY (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `service` */

DROP TABLE IF EXISTS `service`;

CREATE TABLE `service` (
  `tax_type_id` int(11) default NULL,
  `service_id` int(11) NOT NULL auto_increment,
  `service_category_id` int(11) default NULL,
  `oft_id` int(11) default NULL,
  `name` varchar(250) default NULL,
  PRIMARY KEY  (`service_id`),
  KEY `idx_service_service_category_id` (`service_category_id`),
  KEY `idx_service_tax_type_id` (`tax_type_id`),
  CONSTRAINT `ref_service_service_category` FOREIGN KEY (`service_category_id`) REFERENCES `service_category` (`service_category_id`),
  CONSTRAINT `ref_service_tax_type` FOREIGN KEY (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;

/*Table structure for table `service_category` */

DROP TABLE IF EXISTS `service_category`;

CREATE TABLE `service_category` (
  `service_category_id` int(11) NOT NULL auto_increment,
  `oft_id` int(11) default NULL,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`service_category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `service_note` */

DROP TABLE IF EXISTS `service_note`;

CREATE TABLE `service_note` (
  `user_id` int(11) default NULL,
  `ttal` decimal(20,10) default NULL,
  `service_note_id` int(11) NOT NULL auto_increment,
  `service_note_date` datetime default NULL,
  `invoice_id` int(11) default NULL,
  `person_id` int(11) default NULL,
  `oft_num_nota` int(11) NOT NULL,
  `oft_ano` int(11) NOT NULL,
  `invoice_id2` int(11) default NULL,
  `person_id2` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  `paid` decimal(20,10) NOT NULL,
  PRIMARY KEY  (`service_note_id`),
  KEY `idx_service_note_user_id` (`user_id`),
  KEY `idx_service_note_person_id2` (`person_id2`),
  KEY `idx_service_note_person_id` (`person_id`),
  KEY `idx_service_note_invoice_id2` (`invoice_id2`),
  KEY `idx_service_note_invoice_id` (`invoice_id`),
  KEY `idx_service_note_clinic_id` (`clinic_id`),
  CONSTRAINT `ref_service_note_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_service_note_customer` FOREIGN KEY (`person_id`) REFERENCES `customer` (`person_id`),
  CONSTRAINT `ref_service_note_invoice` FOREIGN KEY (`invoice_id`) REFERENCES `invoice` (`invoice_id`),
  CONSTRAINT `ref_service_note_professional` FOREIGN KEY (`person_id2`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_service_note_professional_invoice` FOREIGN KEY (`invoice_id2`) REFERENCES `professional_invoice` (`invoice_id`),
  CONSTRAINT `ref_service_note_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6135 DEFAULT CHARSET=latin1;

/*Table structure for table `source` */

DROP TABLE IF EXISTS `source`;

CREATE TABLE `source` (
  `source_id` int(11) NOT NULL auto_increment,
  `oft_id` int(11) NOT NULL,
  `nme` varchar(255) default NULL,
  PRIMARY KEY  (`source_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

/*Table structure for table `subjective_optical_examination` */

DROP TABLE IF EXISTS `subjective_optical_examination`;

CREATE TABLE `subjective_optical_examination` (
  `examination_assigned_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_sphericity_right_eye` varchar(255) default NULL,
  `far_sphericity_left_eye` varchar(255) default NULL,
  `far_prism_left_eye` varchar(255) default NULL,
  `far_prims_right_eye` varchar(255) default NULL,
  `far_cylinder_right_eye` varchar(255) default NULL,
  `far_cylinder_left_eye` varchar(255) default NULL,
  `far_centers` varchar(255) default NULL,
  `far_axis_right_eye` varchar(255) default NULL,
  `far_axis_left_eye` varchar(255) default NULL,
  `far_acuity` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_sphericity_right_eye` varchar(255) default NULL,
  `close_sphericity_left_eye` varchar(255) default NULL,
  `close_sphericity_centers` int(11) NOT NULL,
  `close_prism_right_eye` varchar(255) default NULL,
  `close_prism_left_eye` varchar(255) default NULL,
  `close_cylinder_right_eye` varchar(255) default NULL,
  `close_cylinder_left_eye` varchar(255) default NULL,
  `close_centers` varchar(255) default NULL,
  `close_axis_right_eye` varchar(255) default NULL,
  `close_axis_left_eye` varchar(255) default NULL,
  `close_acuity_right_eye` varchar(255) default NULL,
  `close_acuity_left_eye` varchar(255) default NULL,
  `close_acuity` varchar(255) default NULL,
  `both_sphericity_right_eye` varchar(255) default NULL,
  `both_sphericity_left_eye` varchar(255) default NULL,
  `both_prism_right_eye` varchar(255) default NULL,
  `both_prism_left_eye` varchar(255) default NULL,
  `both_cylinder_right_eye` varchar(255) default NULL,
  `both_cylinder_left_eye` varchar(255) default NULL,
  `both_centers` varchar(255) default NULL,
  `both_axis_right_eye` varchar(255) default NULL,
  `both_axis_left_eye` varchar(255) default NULL,
  `both_acuity_right_eye` varchar(255) default NULL,
  `both_acuity_left_eye` varchar(255) default NULL,
  `both_acuity` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_subjective_optical_examination_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_subjective_optical_examination_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9369 DEFAULT CHARSET=latin1;

/*Table structure for table `tax_type` */

DROP TABLE IF EXISTS `tax_type`;

CREATE TABLE `tax_type` (
  `tax_type_id` int(11) NOT NULL auto_increment,
  `percentage` decimal(5,2) NOT NULL,
  `oft_id` int(11) default NULL,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`tax_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Table structure for table `tax_withholding_type` */

DROP TABLE IF EXISTS `tax_withholding_type`;

CREATE TABLE `tax_withholding_type` (
  `tax_withholding_type_id` int(11) NOT NULL auto_increment,
  `percentage` decimal(5,2) NOT NULL,
  `name` varchar(30) default NULL,
  PRIMARY KEY  (`tax_withholding_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `telephone` */

DROP TABLE IF EXISTS `telephone`;

CREATE TABLE `telephone` (
  `type` varchar(10) default NULL,
  `telephone_id` int(11) NOT NULL auto_increment,
  `person_id` int(11) default NULL,
  `number` varchar(20) default NULL,
  `hc_id` int(11) default NULL,
  `clinic_id` int(11) default NULL,
  PRIMARY KEY  (`telephone_id`),
  KEY `idx_telephone_hc_id` (`hc_id`),
  KEY `idx_telephone_clinic_id` (`clinic_id`),
  KEY `idx_telephone_person_id` (`person_id`),
  CONSTRAINT `ref_telephone_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_telephone_healthcare_company` FOREIGN KEY (`hc_id`) REFERENCES `healthcare_company` (`hc_id`),
  CONSTRAINT `ref_telephone_person` FOREIGN KEY (`person_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=102938 DEFAULT CHARSET=latin1;

/*Table structure for table `ticket` */

DROP TABLE IF EXISTS `ticket`;

CREATE TABLE `ticket` (
  `user_id` int(11) default NULL,
  `ticket_id` int(11) NOT NULL auto_increment,
  `ticket_date` datetime default NULL,
  `service_note_id` int(11) default NULL,
  `person_id` int(11) default NULL,
  `policy_id` int(11) default NULL,
  `paid` decimal(20,10) default NULL,
  `insurance_service_id` int(11) default NULL,
  `description` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `clinic_id` int(11) default NULL,
  `checked` bit(1) default NULL,
  `amount` decimal(20,10) default NULL,
  `voa_class` varchar(255) default NULL,
  PRIMARY KEY  (`ticket_id`),
  KEY `idx_ticket_user_id` (`user_id`),
  KEY `idx_ticket_service_note_id` (`service_note_id`),
  KEY `idx_ticket_policy_id` (`policy_id`),
  KEY `idx_ticket_person_id` (`person_id`),
  KEY `idx_ticket_insurance_service_id` (`insurance_service_id`),
  KEY `idx_ticket_clinic_id` (`clinic_id`),
  CONSTRAINT `ref_ticket_clinic` FOREIGN KEY (`clinic_id`) REFERENCES `clinic` (`clinic_id`),
  CONSTRAINT `ref_ticket_insurance_service` FOREIGN KEY (`insurance_service_id`) REFERENCES `insurance_service` (`insurance_service_id`),
  CONSTRAINT `ref_ticket_policy` FOREIGN KEY (`policy_id`) REFERENCES `policy` (`policy_id`),
  CONSTRAINT `ref_ticket_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_ticket_service_note` FOREIGN KEY (`service_note_id`) REFERENCES `service_note` (`service_note_id`),
  CONSTRAINT `ref_ticket_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6896 DEFAULT CHARSET=latin1;

/*Table structure for table `topography` */

DROP TABLE IF EXISTS `topography`;

CREATE TABLE `topography` (
  `examination_assigned_id` int(11) NOT NULL,
  `right_eye_k2` decimal(20,10) default NULL,
  `right_eye_k1` decimal(20,10) default NULL,
  `right_eye_axis` decimal(20,10) default NULL,
  `right_eye_astig` decimal(20,10) default NULL,
  `left_eye_k2` decimal(20,10) default NULL,
  `left_eye_k1` decimal(20,10) default NULL,
  `left_eye_axis` decimal(20,10) default NULL,
  `left_eye_astig` decimal(20,10) default NULL,
  PRIMARY KEY  (`examination_assigned_id`),
  CONSTRAINT `ref_topography_examination_assigned` FOREIGN KEY (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `treatment` */

DROP TABLE IF EXISTS `treatment`;

CREATE TABLE `treatment` (
  `treatment_id` int(11) NOT NULL auto_increment,
  `treatment_date` datetime NOT NULL,
  `recommend` varchar(255) default NULL,
  `quantity` int(11) NOT NULL,
  `person_id` int(11) default NULL,
  `drug_id` int(11) default NULL,
  `visit_id` int(11) default NULL,
  `person_id2` int(11) default NULL,
  PRIMARY KEY  (`treatment_id`),
  KEY `idx_treatment_person_id` (`person_id`),
  KEY `idx_treatment_visit_id` (`visit_id`),
  KEY `ref_treatment_drug` (`drug_id`),
  KEY `idx_treatment_person_id2` (`person_id2`),
  CONSTRAINT `ref_treatment_base_visit` FOREIGN KEY (`visit_id`) REFERENCES `base_visit` (`visit_id`),
  CONSTRAINT `ref_treatment_drug` FOREIGN KEY (`drug_id`) REFERENCES `drug` (`drug_id`),
  CONSTRAINT `ref_treatment_patient` FOREIGN KEY (`person_id`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_treatment_professional` FOREIGN KEY (`person_id2`) REFERENCES `professional` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=30859 DEFAULT CHARSET=latin1;

/*Table structure for table `unit_type` */

DROP TABLE IF EXISTS `unit_type`;

CREATE TABLE `unit_type` (
  `unit_type_id` int(11) NOT NULL auto_increment,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`unit_type_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `user_id` int(11) NOT NULL auto_increment,
  `user_group_id` int(11) default NULL,
  `password` varchar(30) NOT NULL,
  `name` varchar(50) NOT NULL,
  `login` varchar(30) NOT NULL,
  `profile` int(11) NOT NULL,
  `code` varchar(255) default NULL,
  PRIMARY KEY  (`user_id`),
  KEY `idx_user_user_group_id` (`user_group_id`),
  KEY `idx_user_code` (`code`),
  CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY (`code`) REFERENCES `base_visit_type` (`code`),
  CONSTRAINT `ref_user_user_group` FOREIGN KEY (`user_group_id`) REFERENCES `user_group` (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

/*Table structure for table `user_group` */

DROP TABLE IF EXISTS `user_group`;

CREATE TABLE `user_group` (
  `user_group_id` int(11) NOT NULL auto_increment,
  `name` varchar(50) default NULL,
  PRIMARY KEY  (`user_group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

/*Table structure for table `visit` */

DROP TABLE IF EXISTS `visit`;

CREATE TABLE `visit` (
  `visit_reason_id` int(11) default NULL,
  `visit_id` int(11) NOT NULL auto_increment,
  `visit_date` datetime NOT NULL,
  `person_id` int(11) default NULL,
  `person_id2` int(11) default NULL,
  `comments` varchar(255) default NULL,
  `appointment_id` int(11) default NULL,
  PRIMARY KEY  (`visit_id`),
  KEY `idx_visit_visit_reason_id` (`visit_reason_id`),
  KEY `idx_visit_person_id2` (`person_id2`),
  KEY `idx_visit_person_id` (`person_id`),
  KEY `idx_visit_appointment_id` (`appointment_id`),
  CONSTRAINT `ref_visit_appointment` FOREIGN KEY (`appointment_id`) REFERENCES `appointment` (`appointment_id`),
  CONSTRAINT `ref_visit_patient` FOREIGN KEY (`person_id2`) REFERENCES `patient` (`person_id`),
  CONSTRAINT `ref_visit_professional` FOREIGN KEY (`person_id`) REFERENCES `professional` (`person_id`),
  CONSTRAINT `ref_visit_visit_reason` FOREIGN KEY (`visit_reason_id`) REFERENCES `visit_reason` (`visit_reason_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `visit_reason` */

DROP TABLE IF EXISTS `visit_reason`;

CREATE TABLE `visit_reason` (
  `visit_reason_id` int(11) NOT NULL auto_increment,
  `oft_id` int(11) NOT NULL,
  `nme` varchar(50) default NULL,
  PRIMARY KEY  (`visit_reason_id`)
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=latin1;

/*Table structure for table `without_glasses_test` */

DROP TABLE IF EXISTS `without_glasses_test`;

CREATE TABLE `without_glasses_test` (
  `examination_assigned_id` int(11) default NULL,
  `id` int(11) NOT NULL auto_increment,
  `far_visual_acuity_right_eye` varchar(255) default NULL,
  `far_visual_acuity_left_eye` varchar(255) default NULL,
  `far_visual_acuity_both_eyes` varchar(255) default NULL,
  `comments` varchar(255) default NULL,
  `close_visual_acuity_right_eye` varchar(255) default NULL,
  `close_visual_acuity_left_eye` varchar(255) default NULL,
  `close_visual_acuity_both_eyes` varchar(255) default NULL,
  PRIMARY KEY  (`id`),
  KEY `idx_without_glasses_test_examination_assigned_id` (`examination_assigned_id`),
  CONSTRAINT `ref_without_glasses_test_refractometry` FOREIGN KEY (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9369 DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
