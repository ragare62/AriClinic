-- Column was read from database as: `comments` longtext null
-- modify column for field comments
ALTER TABLE `appointment` CHANGE COLUMN `comments` `comments` varchar(255) NULL
;

-- Column was read from database as: `content` longtext null
-- modify column for field content
ALTER TABLE `back_family` CHANGE COLUMN `content` `content` varchar(255) NULL
;

-- add column for field baseVisitType
ALTER TABLE `base_visit` ADD COLUMN `code` varchar(255) NULL
;

-- Column was read from database as: `comments` text null
-- modify column for field comments
ALTER TABLE `base_visit` CHANGE COLUMN `comments` `comments` varchar(255) NULL
;

-- AriCliModel.BaseVisitType
CREATE TABLE `base_visit_type` (
    `code` varchar(255) NOT NULL,           -- code
    `nme` varchar(255) NULL,                -- name
    CONSTRAINT `pk_base_visit_type` PRIMARY KEY (`code`)
) ENGINE = InnoDB
;

-- Column was read from database as: `comments` text null
-- modify column for field comments
ALTER TABLE `examination_assigned` CHANGE COLUMN `comments` `comments` varchar(255) NULL
;

-- Column was read from database as: `comments` longtext null
-- modify column for field comments
ALTER TABLE `lab_test_assigned` CHANGE COLUMN `comments` `comments` text NULL
;

-- Column was read from database as: `diagnostic_details` longtext null
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

-- Column was read from database as: `comments` longtext null
-- modify column for field comments
ALTER TABLE `procedure_assigned` CHANGE COLUMN `comments` `comments` text NULL
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

