-- add column for field serviceSubCategory
ALTER TABLE `service` ADD COLUMN `service_sub_category_id` integer NULL
;

ALTER TABLE `service` ADD CONSTRAINT `ref_service_service_sub_category` FOREIGN KEY `ref_service_service_sub_category` (`service_sub_category_id`) REFERENCES `service_sub_category` (`service_sub_category_id`)
;

-- Index 'idx_service_service_sub_category_id' was not detected in the database. It will be created
ALTER TABLE `service` ADD INDEX `idx_service_service_sub_category_id`(`service_sub_category_id`)
;

