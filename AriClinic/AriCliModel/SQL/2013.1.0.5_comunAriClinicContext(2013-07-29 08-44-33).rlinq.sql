-- add column for field discount
ALTER TABLE `ticket` ADD COLUMN `discount` decimal(10,2) NULL
;

-- add column for field price
ALTER TABLE `ticket` ADD COLUMN `price` decimal(10,2) NULL
;

