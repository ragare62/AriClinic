-- Dropping index 'idx_prfssnl_prsn_d' which is not configured in OpenAccess but exists on the database.
ALTER TABLE `professional` DROP INDEX `idx_prfssnl_prsn_d`
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `appointment` CHANGE COLUMN `comments` `comments` text NULL
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

-- Column was read from database as: `diagnostic_details` text null
-- modify column for field OphthalmologicVisit.diagnosticDetails
ALTER TABLE `ophthalmologic_visit` CHANGE COLUMN `diagnostic_details` `diagnostic_details` varchar(255) NULL
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

-- Column was read from database as: `type` varchar(25) null
-- modify column for field Professional.type
ALTER TABLE `professional` CHANGE COLUMN `type` `type` varchar(255) NULL
;

-- Column was read from database as: `vatin` varchar(25) null
-- modify column for field Professional.vATIN
ALTER TABLE `professional` CHANGE COLUMN `vatin` `vatin` varchar(255) NULL
;

-- Column was read from database as: `serial` varchar(10) null
-- modify column for field serial
UPDATE `professional_invoice`
   SET `serial` = ' '
 WHERE `serial` IS NULL
;

ALTER TABLE `professional_invoice` CHANGE COLUMN `serial` `serial` varchar NOT NULL
;

-- AriCliModel.Template
CREATE TABLE `template` (
    `content` text NULL,                    -- content
    `nme` varchar(255) NULL,                -- name
    `template_id` integer AUTO_INCREMENT NOT NULL, -- templateId
    CONSTRAINT `pk_template` PRIMARY KEY (`template_id`)
) ENGINE = InnoDB
;

-- Column was read from database as: `quantity` integer not null
-- modify column for field quantity
ALTER TABLE `treatment` CHANGE COLUMN `quantity` `quantity` decimal(20,10) NOT NULL
;

ALTER TABLE `address` ADD CONSTRAINT `ref_address_person` FOREIGN KEY `ref_address_person` (`person_id`) REFERENCES `person` (`person_id`)
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY `ref_base_visit_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_service_note` FOREIGN KEY `ref_ticket_service_note` (`service_note_id`) REFERENCES `service_note` (`service_note_id`)
;

ALTER TABLE `user` ADD CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY `ref_user_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

