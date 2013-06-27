-- Dropping index 'idx_prfssnl_prsn_d' which is not configured in OpenAccess but exists on the database.
ALTER TABLE `professional` DROP INDEX `idx_prfssnl_prsn_d`
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `appointment` CHANGE COLUMN `comments` `comments` text NULL
;

-- add column for field baseVisitType
ALTER TABLE `base_visit` ADD COLUMN `code` varchar(255) NULL
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `base_visit` CHANGE COLUMN `comments` `comments` text NULL
;

-- AriCliModel.BaseVisitType
CREATE TABLE `base_visit_type` (
    `code` varchar(255) NOT NULL,           -- code
    `nme` varchar(255) NULL,                -- name
    CONSTRAINT `pk_base_visit_type` PRIMARY KEY (`code`)
) ENGINE = InnoDB
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `examination_assigned` CHANGE COLUMN `comments` `comments` text NULL
;

-- Column was read from database as: `name` varchar(30) null
-- modify column for field name
ALTER TABLE `healthcare_company` CHANGE COLUMN `name` `name` varchar(255) NULL
;

-- Column was read from database as: `diagnostic_details` text null
-- modify column for field OphthalmologicVisit.diagnosticDetails
ALTER TABLE `ophthalmologic_visit` CHANGE COLUMN `diagnostic_details` `diagnostic_details` varchar(255) NULL
;

-- add column for field appointmentExtension
ALTER TABLE `parameter` ADD COLUMN `appointment_extension` bit NULL
;

UPDATE `parameter` SET `appointment_extension` = 0
;

ALTER TABLE `parameter` CHANGE COLUMN `appointment_extension` `appointment_extension` bit NOT NULL
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field Patient.comments
ALTER TABLE `patient` CHANGE COLUMN `comments` `comments` longtext NULL
;

-- add column for field Patient.openDate
ALTER TABLE `patient` ADD COLUMN `open_date` datetime NULL
;

-- add column for field signMD
ALTER TABLE `prescription_glasses` ADD COLUMN `sign_MD` varchar(255) NULL
;

UPDATE `prescription_glasses` SET `sign_MD` = ' '
;

ALTER TABLE `prescription_glasses` CHANGE COLUMN `sign_MD` `sign_MD` varchar(255) NOT NULL
;

-- Column was read from database as: `comercial_name` varchar(50) null
-- modify column for field Professional.comercialName
ALTER TABLE `professional` CHANGE COLUMN `comercial_name` `comercial_name` varchar(255) NULL
;

-- Column was read from database as: `commission` decimal(5,2) null
-- modify column for field Professional.commission
ALTER TABLE `professional` CHANGE COLUMN `commission` `commission` decimal(20,10) NULL
;

-- add column for field Professional.inactive
ALTER TABLE `professional` ADD COLUMN `inactive` bit NULL
;

-- Column was read from database as: `invoice_serial` varchar(10) null
-- modify column for field Professional.invoiceSerial
ALTER TABLE `professional` CHANGE COLUMN `invoice_serial` `invoice_serial` varchar(255) NULL
;

-- Column was read from database as: `license` varchar(25) null
-- modify column for field Professional.license
ALTER TABLE `professional` CHANGE COLUMN `license` `license` varchar(255) NULL
;

-- add column for field Professional.type
ALTER TABLE `professional` ADD COLUMN `typ` varchar(255) NULL
;

-- add column for field Professional.vATIN
ALTER TABLE `professional` ADD COLUMN `v_a_t_i_n` varchar(255) NULL
;

-- dropping unknown column `vatin`
ALTER TABLE `professional` DROP COLUMN `vatin`
;

-- dropping unknown column `type`
ALTER TABLE `professional` DROP COLUMN `type`
;

-- add column for field baseVisitType
ALTER TABLE `user` ADD COLUMN `code` varchar(255) NULL
;

-- add column for field profile
ALTER TABLE `user` ADD COLUMN `profile` integer NULL
;

UPDATE `user` SET `profile` = 0
;

ALTER TABLE `user` CHANGE COLUMN `profile` `profile` integer NOT NULL
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY `ref_base_visit_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

ALTER TABLE `user` ADD CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY `ref_user_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

-- Index 'idx_base_visit_code' was not detected in the database. It will be created
ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_code`(`code`)
;

-- Index 'idx_user_code' was not detected in the database. It will be created
ALTER TABLE `user` ADD INDEX `idx_user_code`(`code`)
;

