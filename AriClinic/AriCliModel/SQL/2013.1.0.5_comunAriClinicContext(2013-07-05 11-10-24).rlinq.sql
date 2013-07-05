-- add column for field clinic
ALTER TABLE `request` ADD COLUMN `clinic_id` INTEGER NULL
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_clinic` FOREIGN KEY `ref_request_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`)
;

-- Index 'idx_request_clinic_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_clinic_id`(`clinic_id`)
;

