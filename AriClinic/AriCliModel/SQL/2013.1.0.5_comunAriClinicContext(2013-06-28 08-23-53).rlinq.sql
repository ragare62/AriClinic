-- add column for field user
ALTER TABLE `estimate` ADD COLUMN `user_id` integer NULL
;

ALTER TABLE `estimate` ADD CONSTRAINT `ref_estimate_user` FOREIGN KEY `ref_estimate_user` (`user_id`) REFERENCES `user` (`user_id`)
;

-- Index 'idx_estimate_user_id' was not detected in the database. It will be created
ALTER TABLE `estimate` ADD INDEX `idx_estimate_user_id`(`user_id`)
;

