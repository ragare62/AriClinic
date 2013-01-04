-- add column for field baseVisitType
ALTER TABLE `base_visit` ADD COLUMN `code` varchar(255) NULL
;

-- add column for field baseVisit
ALTER TABLE `diagnostic_assigned` ADD COLUMN `visit_id` integer NULL
;

-- add column for field baseVisit
ALTER TABLE `examination_assigned` ADD COLUMN `visit_id` integer NULL
;

-- Column was read from database as: `voa_class` integer not null
-- modify column for field <internal-class-id>
ALTER TABLE `examination_assigned` CHANGE COLUMN `voa_class` `voa_class` varchar(255) NULL
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

-- Column was read from database as: `serial` varchar(10) null
-- modify column for field serial
UPDATE `professional_invoice`
   SET `serial` = ' '
 WHERE `serial` IS NULL
;

ALTER TABLE `professional_invoice` CHANGE COLUMN `serial` `serial` varchar NOT NULL
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

ALTER TABLE `address` ADD CONSTRAINT `ref_address_person` FOREIGN KEY `ref_address_person` (`person_id`) REFERENCES `person` (`person_id`)
;

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_invoice` FOREIGN KEY `ref_anesthetic_service_note_invoice` (`invoice_id`) REFERENCES `invoice` (`invoice_id`)
;

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_professional_invoice` FOREIGN KEY `ref_anesthetic_service_note_professional_invoice` (`invoice_id`) REFERENCES `professional_invoice` (`invoice_id`)
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY `ref_base_visit_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

ALTER TABLE `diagnostic_assigned` ADD CONSTRAINT `ref_diagnostic_assigned_base_visit` FOREIGN KEY `ref_diagnostic_assigned_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`)
;

ALTER TABLE `examination_assigned` ADD CONSTRAINT `ref_examination_assigned_base_visit` FOREIGN KEY `ref_examination_assigned_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`)
;

ALTER TABLE `examination_assigned` ADD CONSTRAINT `ref_examination_assigned_examination` FOREIGN KEY `ref_examination_assigned_examination` (`examination_id`) REFERENCES `examination` (`examination_id`)
;

ALTER TABLE `examination_assigned` ADD CONSTRAINT `ref_examination_assigned_patient` FOREIGN KEY `ref_examination_assigned_patient` (`person_id`) REFERENCES `patient` (`person_id`)
;

ALTER TABLE `invoice_line` ADD CONSTRAINT `ref_invoice_line_tax_type` FOREIGN KEY `ref_invoice_line_tax_type` (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`)
;

ALTER TABLE `invoice_line` ADD CONSTRAINT `ref_invoice_line_user` FOREIGN KEY `ref_invoice_line_user` (`user_id`) REFERENCES `user` (`user_id`)
;

ALTER TABLE `professional` ADD CONSTRAINT `ref_professional_user` FOREIGN KEY `ref_professional_user` (`user_id`) REFERENCES `user` (`user_id`)
;

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_service_note` FOREIGN KEY `ref_ticket_service_note` (`service_note_id`) REFERENCES `service_note` (`service_note_id`)
;

ALTER TABLE `user` ADD CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY `ref_user_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

-- Index 'idx_base_visit_code' was not detected in the database. It will be created
ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_code`(`code`)
;

-- Index 'idx_diagnostic_assigned_visit_id' was not detected in the database. It will be created
ALTER TABLE `diagnostic_assigned` ADD INDEX `idx_diagnostic_assigned_visit_id`(`visit_id`)
;

-- Index 'idx_examination_assigned_visit_id' was not detected in the database. It will be created
ALTER TABLE `examination_assigned` ADD INDEX `idx_examination_assigned_visit_id`(`visit_id`)
;

-- Index 'idx_invoice_line_tax_type_id' was not detected in the database. It will be created
ALTER TABLE `invoice_line` ADD INDEX `idx_invoice_line_tax_type_id`(`tax_type_id`)
;

-- Index 'idx_invoice_line_user_id' was not detected in the database. It will be created
ALTER TABLE `invoice_line` ADD INDEX `idx_invoice_line_user_id`(`user_id`)
;

-- Index 'idx_professional_user_id' was not detected in the database. It will be created
ALTER TABLE `professional` ADD INDEX `idx_professional_user_id`(`user_id`)
;

-- Index 'idx_user_code' was not detected in the database. It will be created
ALTER TABLE `user` ADD INDEX `idx_user_code`(`code`)
;

