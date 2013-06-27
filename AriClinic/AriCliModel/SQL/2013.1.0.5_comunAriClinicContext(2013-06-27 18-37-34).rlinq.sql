-- add column for field request
ALTER TABLE `estimate` ADD COLUMN `request_id` integer NULL
;

-- add column for field estimate
ALTER TABLE `estimate_line` ADD COLUMN `estimate_id` integer NULL
;

ALTER TABLE `estimate` ADD CONSTRAINT `ref_estimate_request` FOREIGN KEY `ref_estimate_request` (`request_id`) REFERENCES `request` (`request_id`)
;

ALTER TABLE `estimate_line` ADD CONSTRAINT `ref_estimate_line_estimate` FOREIGN KEY `ref_estimate_line_estimate` (`estimate_id`) REFERENCES `estimate` (`estimate_id`)
;

-- Index 'idx_estimate_request_id' was not detected in the database. It will be created
ALTER TABLE `estimate` ADD INDEX `idx_estimate_request_id`(`request_id`)
;

-- Index 'idx_estimate_line_estimate_id' was not detected in the database. It will be created
ALTER TABLE `estimate_line` ADD INDEX `idx_estimate_line_estimate_id`(`estimate_id`)
;

