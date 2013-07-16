-- add column for field serviceCategory
ALTER TABLE `service_sub_category` ADD COLUMN `service_category_id` integer NULL
;

ALTER TABLE `service_sub_category` ADD CONSTRAINT `ref_service_sub_category_service_category` FOREIGN KEY `ref_service_sub_category_service_category` (`service_category_id`) REFERENCES `service_category` (`service_category_id`)
;

-- Index 'idx_service_sub_category_service_category_id' was not detected in the database. It will be created
ALTER TABLE `service_sub_category` ADD INDEX `idx_service_sub_category_service_category_id`(`service_category_id`)
;

