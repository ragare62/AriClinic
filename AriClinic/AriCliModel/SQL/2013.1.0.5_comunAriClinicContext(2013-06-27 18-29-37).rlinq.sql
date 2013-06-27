-- AriCliModel.EstimateLine
CREATE TABLE `estimate_line` (
    `amount` decimal(20,10) NOT NULL,       -- amount
    `description` varchar(255) NULL,        -- description
    `discount` decimal(20,10) NOT NULL,     -- discount
    `estimate_date` datetime NOT NULL,      -- estimateDate
    `estimate_line_id` integer AUTO_INCREMENT NOT NULL, -- estimateLineId
    `insurance_service_id` integer NULL,    -- insuranceService
    `request_id` integer NULL,              -- request
    CONSTRAINT `pk_estimate_line` PRIMARY KEY (`estimate_line_id`)
) ENGINE = InnoDB
;

ALTER TABLE `estimate_line` ADD CONSTRAINT `ref_estimate_line_insurance_service` FOREIGN KEY `ref_estimate_line_insurance_service` (`insurance_service_id`) REFERENCES `insurance_service` (`insurance_service_id`)
;

ALTER TABLE `estimate_line` ADD CONSTRAINT `ref_estimate_line_request` FOREIGN KEY `ref_estimate_line_request` (`request_id`) REFERENCES `request` (`request_id`)
;

-- Index 'idx_estimate_line_insurance_service_id' was not detected in the database. It will be created
ALTER TABLE `estimate_line` ADD INDEX `idx_estimate_line_insurance_service_id`(`insurance_service_id`)
;

-- Index 'idx_estimate_line_request_id' was not detected in the database. It will be created
ALTER TABLE `estimate_line` ADD INDEX `idx_estimate_line_request_id`(`request_id`)
;

