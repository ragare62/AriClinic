ALTER TABLE `base_visit` DROP FOREIGN KEY `ref_base_visit_patient`
;

ALTER TABLE `base_visit` DROP FOREIGN KEY `ref_base_visit_professional`
;

-- Column was read from database as: `comments` text null
-- modify column for field comments
UPDATE `estimate`
   SET `comments` = ' '
 WHERE `comments` IS NULL
;

ALTER TABLE `estimate` CHANGE COLUMN `comments` `comments` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_patient` FOREIGN KEY `ref_base_visit_patient` (`person_id`) REFERENCES `patient` (`person_id`)
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_professional` FOREIGN KEY `ref_base_visit_professional` (`person_id2`) REFERENCES `professional` (`person_id`)
;

