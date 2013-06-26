-- add column for field Patient.fullName
ALTER TABLE `patient` ADD COLUMN `full_name` varchar(255) NULL
;

-- add column for field status
ALTER TABLE `request` ADD COLUMN `status` varchar(255) NULL
;

UPDATE `request` SET `status` = ' '
;

ALTER TABLE `request` CHANGE COLUMN `status` `status` varchar(255) NOT NULL
;

