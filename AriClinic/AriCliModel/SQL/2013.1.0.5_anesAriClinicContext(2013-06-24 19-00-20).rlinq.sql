-- AriCliModel.Campaign
CREATE TABLE `campaign` (
    `campaign_id` integer AUTO_INCREMENT NOT NULL, -- campaignId
    `end_date` datetime NOT NULL,           -- endDate
    `nme` varchar(255) NULL,                -- name
    `start_date` datetime NOT NULL,         -- startDate
    CONSTRAINT `pk_campaign` PRIMARY KEY (`campaign_id`)
) ENGINE = InnoDB
;

-- Column was read from database as: `serial` varchar(10) null
-- modify column for field serial
UPDATE `professional_invoice`
   SET `serial` = ' '
 WHERE `serial` IS NULL
;

ALTER TABLE `professional_invoice` CHANGE COLUMN `serial` `serial` varchar NOT NULL
;

-- AriCliModel.Template
CREATE TABLE `template` (
    `content` text NULL,                    -- content
    `nme` varchar(255) NULL,                -- name
    `template_id` integer AUTO_INCREMENT NOT NULL, -- templateId
    CONSTRAINT `pk_template` PRIMARY KEY (`template_id`)
) ENGINE = InnoDB
;

-- Column was read from database as: `quantity` integer not null
-- modify column for field quantity
ALTER TABLE `treatment` CHANGE COLUMN `quantity` `quantity` decimal(20,10) NOT NULL
;

ALTER TABLE `address` ADD CONSTRAINT `ref_address_person` FOREIGN KEY `ref_address_person` (`person_id`) REFERENCES `person` (`person_id`)
;

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY `ref_base_visit_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_service_note` FOREIGN KEY `ref_ticket_service_note` (`service_note_id`) REFERENCES `service_note` (`service_note_id`)
;

ALTER TABLE `user` ADD CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY `ref_user_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`)
;

