-- add column for field service
ALTER TABLE `replay` ADD COLUMN `service_id` integer NULL
;

ALTER TABLE `replay` ADD CONSTRAINT `ref_replay_service` FOREIGN KEY `ref_replay_service` (`service_id`) REFERENCES `service` (`service_id`)
;

-- Index 'idx_replay_service_id' was not detected in the database. It will be created
ALTER TABLE `replay` ADD INDEX `idx_replay_service_id`(`service_id`)
;

