-- Column was read from database as: `comments` text not null
-- modify column for field comments
ALTER TABLE `request` CHANGE COLUMN `comments` `comments` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL
;

