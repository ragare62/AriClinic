-- add column for field fullName
ALTER TABLE `request` ADD COLUMN `full_name` varchar(255) NULL
;

UPDATE `request` SET `full_name` = ' '
;

ALTER TABLE `request` CHANGE COLUMN `full_name` `full_name` varchar(255) NOT NULL
;

