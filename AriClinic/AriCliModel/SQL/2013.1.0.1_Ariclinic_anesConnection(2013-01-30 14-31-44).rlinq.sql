-- Column was read from database as: `serial` varchar(10) null
-- modify column for field serial
UPDATE `professional_invoice`
   SET `serial` = ' '
 WHERE `serial` IS NULL
;

ALTER TABLE `professional_invoice` CHANGE COLUMN `serial` `serial` varchar NOT NULL
;

ALTER TABLE `address` ADD CONSTRAINT `ref_address_person` FOREIGN KEY `ref_address_person` (`person_id`) REFERENCES `person` (`person_id`)
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY `ref_base_visit_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_service_note` FOREIGN KEY `ref_ticket_service_note` (`service_note_id`) REFERENCES `service_note` (`service_note_id`)
;

ALTER TABLE `user` ADD CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY `ref_user_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

