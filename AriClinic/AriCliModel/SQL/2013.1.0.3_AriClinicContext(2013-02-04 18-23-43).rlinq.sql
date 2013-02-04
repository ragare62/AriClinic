-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `appointment` CHANGE COLUMN `comments` `comments` text NULL
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `base_visit` CHANGE COLUMN `comments` `comments` text NULL
;

-- Column was read from database as: `comments` varchar(255) null
-- modify column for field comments
ALTER TABLE `examination_assigned` CHANGE COLUMN `comments` `comments` text NULL
;

