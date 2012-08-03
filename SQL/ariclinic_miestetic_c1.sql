ALTER TABLE `anesthetic_service_note` DROP FOREIGN KEY `ref_anesthetic_service_note_invoice`;
ALTER TABLE `anesthetic_service_note` DROP INDEX `ref_anesthetic_service_note_invoice`;

ALTER TABLE `anesthetic_service_note_procedures` DROP FOREIGN KEY `ref_anesthetic_service_note_procedures_anesthetic_service_note`;
ALTER TABLE `anesthetic_service_note_procedures` DROP INDEX `ref_anesthetic_service_note_procedures_anesthetic_service_note`;

ALTER TABLE `anesthetic_service_note_procedures` DROP FOREIGN KEY `ref_anesthetic_service_note_procedures_procedure`;
ALTER TABLE `anesthetic_service_note_procedures` DROP INDEX `ref_anesthetic_service_note_procedures_procedure`;

-- add column for field chk3
ALTER TABLE `anesthetic_service_note` ADD COLUMN `chk3` BIT NULL;
UPDATE `anesthetic_service_note` SET `chk3` = 0;
ALTER TABLE `anesthetic_service_note` CHANGE COLUMN `chk3` `chk3` BIT NOT NULL;

-- Column was read from database as: `invoice_id` INTEGER not null
-- modify column for field invoice
ALTER TABLE `anesthetic_service_note` CHANGE COLUMN `invoice_id` `invoice_id` INTEGER NULL;

-- Column was read from database as: `anesthetic_service_note_id` INTEGER not null
-- modify column `anesthetic_service_note_id`
ALTER TABLE `anesthetic_service_note_procedures` CHANGE COLUMN `anesthetic_service_note_id` `anesthetic_service_note_id` INT NULL;

-- Column was read from database as: `procedure_id` INTEGER not null
-- modify column `procedure_id`
ALTER TABLE `anesthetic_service_note_procedures` CHANGE COLUMN `procedure_id` `procedure_id` INT NOT NULL;

-- AriCliModel.BackFamily
CREATE TABLE `back_family` (
    `back_family_id` INTEGER AUTO_INCREMENT NOT NULL, -- backFamilyId
    `content` VARCHAR(255) NULL,            -- content
    `person_id` INTEGER NULL,               -- patient
    CONSTRAINT `pk_back_family` PRIMARY KEY (`back_family_id`)
) ENGINE = INNODB;

-- AriCliModel.BackGinecology
CREATE TABLE `back_ginecoloy` (
    `abortions` INTEGER NOT NULL,           -- abortions
    `back_ginecoloy_id` INTEGER AUTO_INCREMENT NOT NULL, -- backGinecologyId
    `cesarean_deliveries` INTEGER NOT NULL, -- cesareanDeliveries
    `content` LONGTEXT NULL,                -- content
    `date_of_last_mestrual` DATETIME NOT NULL, -- dateOfLastMestrual
    `menarche` VARCHAR(255) NULL,           -- menarche
    `menopause` VARCHAR(255) NULL,          -- menopause
    `menstrual_formula` VARCHAR(255) NULL,  -- menstrualFormula
    `person_id` INTEGER NULL,               -- patient
    `vaginal_deliveries` INTEGER NOT NULL,  -- vaginalDeliveries
    CONSTRAINT `pk_back_ginecoloy` PRIMARY KEY (`back_ginecoloy_id`)
) ENGINE = INNODB;

-- AriCliModel.BackPersonal
CREATE TABLE `back_personal` (
    `back_personal_id` INTEGER AUTO_INCREMENT NOT NULL, -- backPersonalId
    `content` LONGTEXT NULL,                -- content
    `person_id` INTEGER NULL,               -- patient
    CONSTRAINT `pk_back_personal` PRIMARY KEY (`back_personal_id`)
) ENGINE = INNODB;

-- AriCliModel.PreviousMedicalRecord
CREATE TABLE `previous_medical_record` (
    `content` LONGTEXT NULL,                -- content
    `person_id` INTEGER NULL,               -- patient
    `previous_medical_record_id` INTEGER AUTO_INCREMENT NOT NULL, -- previousMedicalRecordId
    CONSTRAINT `pk_previous_medical_record` PRIMARY KEY (`previous_medical_record_id`)
) ENGINE = INNODB;

-- add column for field professional
ALTER TABLE `treatment` ADD COLUMN `person_id2` INTEGER NULL;

ALTER TABLE `back_family` ADD INDEX `idx_back_family_person_id`(`person_id`);

ALTER TABLE `back_ginecoloy` ADD INDEX `idx_back_ginecoloy_person_id`(`person_id`);

ALTER TABLE `back_personal` ADD INDEX `idx_back_personal_person_id`(`person_id`);

ALTER TABLE `previous_medical_record` ADD INDEX `idx_previous_medical_record_person_id`(`person_id`);

ALTER TABLE `treatment` ADD INDEX `idx_treatment_person_id2`(`person_id2`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_invoice` FOREIGN KEY `ref_anesthetic_service_note_invoice` (`invoice_id`) REFERENCES `invoice` (`invoice_id`);

ALTER TABLE `anesthetic_service_note_procedures` ADD CONSTRAINT `ref_anesthetic_service_note_procedures_anesthetic_service_note` FOREIGN KEY `ref_anesthetic_service_note_procedures_anesthetic_service_note` (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`);

ALTER TABLE `anesthetic_service_note_procedures` ADD CONSTRAINT `ref_anesthetic_service_note_procedures_procedure` FOREIGN KEY `ref_anesthetic_service_note_procedures_procedure` (`procedure_id`) REFERENCES `procedure` (`procedure_id`);

ALTER TABLE `back_family` ADD CONSTRAINT `ref_back_family_patient` FOREIGN KEY `ref_back_family_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `back_ginecoloy` ADD CONSTRAINT `ref_back_ginecoloy_patient` FOREIGN KEY `ref_back_ginecoloy_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `back_personal` ADD CONSTRAINT `ref_back_personal_patient` FOREIGN KEY `ref_back_personal_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `previous_medical_record` ADD CONSTRAINT `ref_previous_medical_record_patient` FOREIGN KEY `ref_previous_medical_record_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `treatment` ADD CONSTRAINT `ref_treatment_professional` FOREIGN KEY `ref_treatment_professional` (`person_id2`) REFERENCES `professional` (`person_id`);

