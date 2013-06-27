ALTER TABLE `estimate_line` DROP FOREIGN KEY `ref_estimate_line_request`
;

-- Dropping index 'idx_estimate_line_request_id' which is not configured in OpenAccess but exists on the database.
ALTER TABLE `estimate_line` DROP INDEX `idx_estimate_line_request_id`
;

-- AriCliModel.Estimate
CREATE TABLE `estimate` (
    `estimate_date` datetime NOT NULL,      -- estimateDate
    `estimate_id` integer AUTO_INCREMENT NOT NULL, -- estimateId
    `full_name` varchar(255) NULL,          -- fullName
    `ttal` decimal(20,10) NOT NULL,         -- total
    CONSTRAINT `pk_estimate` PRIMARY KEY (`estimate_id`)
) ENGINE = InnoDB
;

-- dropping unknown column `estimate_date`
ALTER TABLE `estimate_line` DROP COLUMN `estimate_date`
;

-- dropping unknown column `request_id`
ALTER TABLE `estimate_line` DROP COLUMN `request_id`
;

