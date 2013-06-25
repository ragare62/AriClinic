-- add column for field comments
ALTER TABLE `request` ADD COLUMN `comments` text NULL
;

UPDATE `request` SET `comments` = ' '
;

ALTER TABLE `request` CHANGE COLUMN `comments` `comments` text NOT NULL
;

