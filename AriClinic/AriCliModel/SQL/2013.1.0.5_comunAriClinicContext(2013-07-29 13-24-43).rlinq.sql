ALTER TABLE `treatment` ADD CONSTRAINT `ref_treatment_professional` FOREIGN KEY `ref_treatment_professional` (`person_id2`) REFERENCES `professional` (`person_id`)
;

