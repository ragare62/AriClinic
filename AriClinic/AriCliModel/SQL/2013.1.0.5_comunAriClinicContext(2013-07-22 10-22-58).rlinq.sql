-- AriCliModel.AmendmentInvoice
CREATE TABLE `amendment_invoice` (
    `amendment_invoice_id` integer AUTO_INCREMENT NOT NULL, -- amendmentInvoiceId
    `person_id` integer NULL,               -- customer
    `invoice_date` datetime NOT NULL,       -- invoiceDate
    `invoice_key` varchar(255) NULL,        -- invoiceKey
    `invoice_number` integer NOT NULL,      -- invoiceNumber
    `invoice_id` integer NULL,              -- invoice
    `srial` varchar(255) NULL,              -- serial
    `ttal` decimal(20,10) NOT NULL,         -- total
    `yr` integer NOT NULL,                  -- year
    CONSTRAINT `pk_amendment_invoice` PRIMARY KEY (`amendment_invoice_id`)
) ENGINE = InnoDB
;

-- AriCliModel.AmendmentInvoiceLine
CREATE TABLE `amendment_invoice_line` (
    `amendment_invoice_id` integer NULL,    -- amendmentInvoice
    `amendment_invoice_line_id` integer AUTO_INCREMENT NOT NULL, -- amendmentInvoiceLineId
    `amount` decimal(20,10) NOT NULL,       -- amount
    `description` varchar(255) NULL,        -- description
    `tax_percentage` decimal(20,10) NOT NULL, -- taxPercentage
    `tax_type_id` integer NULL,             -- taxType
    `user_id` integer NULL,                 -- user
    CONSTRAINT `pk_amendment_invoice_line` PRIMARY KEY (`amendment_invoice_line_id`)
) ENGINE = InnoDB
;

-- Column was read from database as: `oft_id` integer null
-- modify column for field oftId
UPDATE `insurance_service`
   SET `oft_id` = 0
 WHERE `oft_id` IS NULL
;

ALTER TABLE `insurance_service` CHANGE COLUMN `oft_id` `oft_id` integer NOT NULL
;

ALTER TABLE `amendment_invoice` ADD CONSTRAINT `ref_amendment_invoice_customer` FOREIGN KEY `ref_amendment_invoice_customer` (`person_id`) REFERENCES `customer` (`person_id`)
;

ALTER TABLE `amendment_invoice` ADD CONSTRAINT `ref_amendment_invoice_invoice` FOREIGN KEY `ref_amendment_invoice_invoice` (`invoice_id`) REFERENCES `invoice` (`invoice_id`)
;

ALTER TABLE `amendment_invoice_line` ADD CONSTRAINT `ref_amendment_invoice_line_amendment_invoice` FOREIGN KEY `ref_amendment_invoice_line_amendment_invoice` (`amendment_invoice_id`) REFERENCES `amendment_invoice` (`amendment_invoice_id`)
;

ALTER TABLE `amendment_invoice_line` ADD CONSTRAINT `ref_amendment_invoice_line_tax_type` FOREIGN KEY `ref_amendment_invoice_line_tax_type` (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`)
;

ALTER TABLE `amendment_invoice_line` ADD CONSTRAINT `ref_amendment_invoice_line_user` FOREIGN KEY `ref_amendment_invoice_line_user` (`user_id`) REFERENCES `user` (`user_id`)
;

-- Index 'idx_amendment_invoice_person_id' was not detected in the database. It will be created
ALTER TABLE `amendment_invoice` ADD INDEX `idx_amendment_invoice_person_id`(`person_id`)
;

-- Index 'idx_amendment_invoice_invoice_id' was not detected in the database. It will be created
ALTER TABLE `amendment_invoice` ADD INDEX `idx_amendment_invoice_invoice_id`(`invoice_id`)
;

-- Index 'idx_amendment_invoice_line_user_id' was not detected in the database. It will be created
ALTER TABLE `amendment_invoice_line` ADD INDEX `idx_amendment_invoice_line_user_id`(`user_id`)
;

-- Index 'idx_amendment_invoice_line_amendment_invoice_id' was not detected in the database. It will be created
ALTER TABLE `amendment_invoice_line` ADD INDEX `idx_amendment_invoice_line_amendment_invoice_id`(`amendment_invoice_id`)
;

-- Index 'idx_amendment_invoice_line_tax_type_id' was not detected in the database. It will be created
ALTER TABLE `amendment_invoice_line` ADD INDEX `idx_amendment_invoice_line_tax_type_id`(`tax_type_id`)
;

