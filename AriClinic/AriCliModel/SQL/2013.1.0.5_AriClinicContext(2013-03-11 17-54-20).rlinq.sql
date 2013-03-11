-- Column was read from database as: `quantity` integer not null
-- modify column for field quantity
ALTER TABLE `treatment` CHANGE COLUMN `quantity` `quantity` decimal(20,10) NOT NULL
;

