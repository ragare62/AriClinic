-- AriCliModel.ServiceSubCategory
CREATE TABLE `service_sub_category` (
    `nme` varchar(255) NULL,                -- name
    `service_sub_category_id` integer AUTO_INCREMENT NOT NULL, -- serviceSubCategoryId
    CONSTRAINT `pk_service_sub_category` PRIMARY KEY (`service_sub_category_id`)
) ENGINE = InnoDB
;

