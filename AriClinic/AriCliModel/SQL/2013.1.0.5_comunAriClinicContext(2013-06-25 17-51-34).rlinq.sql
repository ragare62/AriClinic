-- add column for field campaign
ALTER TABLE `request` ADD COLUMN `campaign_id` integer NULL
;

-- add column for field channel
ALTER TABLE `request` ADD COLUMN `channel_id` integer NULL
;

-- add column for field patient
ALTER TABLE `request` ADD COLUMN `person_id` integer NULL
;

-- add column for field service
ALTER TABLE `request` ADD COLUMN `service_id` integer NULL
;

-- add column for field source
ALTER TABLE `request` ADD COLUMN `source_id` integer NULL
;

-- add column for field user
ALTER TABLE `request` ADD COLUMN `user_id` integer NULL
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_campaign` FOREIGN KEY `ref_request_campaign` (`campaign_id`) REFERENCES `campaign` (`campaign_id`)
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_channel` FOREIGN KEY `ref_request_channel` (`channel_id`) REFERENCES `channel` (`channel_id`)
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_patient` FOREIGN KEY `ref_request_patient` (`person_id`) REFERENCES `patient` (`person_id`)
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_service` FOREIGN KEY `ref_request_service` (`service_id`) REFERENCES `service` (`service_id`)
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_source` FOREIGN KEY `ref_request_source` (`source_id`) REFERENCES `source` (`source_id`)
;

ALTER TABLE `request` ADD CONSTRAINT `ref_request_user` FOREIGN KEY `ref_request_user` (`user_id`) REFERENCES `user` (`user_id`)
;

-- Index 'idx_request_campaign_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_campaign_id`(`campaign_id`)
;

-- Index 'idx_request_channel_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_channel_id`(`channel_id`)
;

-- Index 'idx_request_person_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_person_id`(`person_id`)
;

-- Index 'idx_request_service_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_service_id`(`service_id`)
;

-- Index 'idx_request_source_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_source_id`(`source_id`)
;

-- Index 'idx_request_user_id' was not detected in the database. It will be created
ALTER TABLE `request` ADD INDEX `idx_request_user_id`(`user_id`)
;

