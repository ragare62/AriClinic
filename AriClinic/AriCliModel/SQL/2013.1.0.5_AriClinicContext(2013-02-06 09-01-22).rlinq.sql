-- Column was read from database as: `name` varchar(30) null
-- modify column for field name
ALTER TABLE `healthcare_company` CHANGE COLUMN `name` `name` varchar(255) NULL
;

