-- Column was read from database as: `anesthetic_service_note_id` INTEGER not null
-- modify column `anesthetic_service_note_id`
ALTER TABLE `anesthetic_service_note_procedures` CHANGE COLUMN `anesthetic_service_note_id` `anesthetic_service_note_id` int NOT NULL;

-- Column was read from database as: `procedure_id` INTEGER not null
-- modify column `procedure_id`
ALTER TABLE `anesthetic_service_note_procedures` CHANGE COLUMN `procedure_id` `procedure_id` int NOT NULL;

-- add column for field subject
ALTER TABLE `appointment` ADD COLUMN `subject` longtext NULL;

-- add column for field oftId
ALTER TABLE `appointment_type` ADD COLUMN `oft_id` integer NULL;
UPDATE `appointment_type` SET `oft_id` = 0;
ALTER TABLE `appointment_type` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

-- add column for field Customer.oftId
ALTER TABLE `customer` ADD COLUMN `oft_id` integer NULL;

-- add column for field oftId
ALTER TABLE `diary` ADD COLUMN `oft_id` integer NULL;
UPDATE `diary` SET `oft_id` = 0;
ALTER TABLE `diary` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

-- add column for field Patient.oftId
ALTER TABLE `patient` ADD COLUMN `oft_id` integer NULL;

-- add column for field oftId
ALTER TABLE `payment` ADD COLUMN `oft_id` integer NULL;
UPDATE `payment` SET `oft_id` = 0;
ALTER TABLE `payment` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

-- add column for field description
ALTER TABLE `payment` ADD COLUMN `description` varchar(50) NULL;

-- add column for field oftId
ALTER TABLE `payment_method` ADD COLUMN `oft_id` integer NULL;
UPDATE `payment_method` SET `oft_id` = 0;
ALTER TABLE `payment_method` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

-- add column for field Professional.oftId
ALTER TABLE `professional` ADD COLUMN `oft_id` integer NULL;

-- add column for field oftId
ALTER TABLE `service` ADD COLUMN `oft_id` integer NULL;
UPDATE `service` SET `oft_id` = 0;
ALTER TABLE `service` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

-- add column for field oftId
ALTER TABLE `service_category` ADD COLUMN `oft_id` integer NULL;
UPDATE `service_category` SET `oft_id` = 0;
ALTER TABLE `service_category` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

-- add column for field oftNumNota
ALTER TABLE `service_note` ADD COLUMN `oft_num_nota` integer NULL;
UPDATE `service_note` SET `oft_num_nota` = 0;
ALTER TABLE `service_note` CHANGE COLUMN `oft_num_nota` `oft_num_nota` integer NOT NULL;

-- add column for field oftAno
ALTER TABLE `service_note` ADD COLUMN `oft_ano` integer NULL;
UPDATE `service_note` SET `oft_ano` = 0;
ALTER TABLE `service_note` CHANGE COLUMN `oft_ano` `oft_ano` integer NOT NULL;

-- add column for field oftId
ALTER TABLE `tax_type` ADD COLUMN `oft_id` integer NULL;
UPDATE `tax_type` SET `oft_id` = 0;
ALTER TABLE `tax_type` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL;

