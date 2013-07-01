-- add column for field comments
ALTER TABLE `estimate` ADD COLUMN `comments` text NULL
;

UPDATE `estimate` SET `comments` = ' '
;

ALTER TABLE `estimate` CHANGE COLUMN `comments` `comments` text NOT NULL
;

