-- AriCliModel.Replay
CREATE TABLE `replay` (
    `channel_id` integer NULL,              -- channel
    `comments` text NULL,                   -- comments
    `replay_date` datetime NOT NULL,        -- replayDate
    `replay_id` integer AUTO_INCREMENT NOT NULL, -- replayId
    `request_id` integer NULL,              -- request
    `user_id` integer NULL,                 -- user
    CONSTRAINT `pk_replay` PRIMARY KEY (`replay_id`)
) ENGINE = InnoDB
;

ALTER TABLE `replay` ADD CONSTRAINT `ref_replay_channel` FOREIGN KEY `ref_replay_channel` (`channel_id`) REFERENCES `channel` (`channel_id`)
;

ALTER TABLE `replay` ADD CONSTRAINT `ref_replay_request` FOREIGN KEY `ref_replay_request` (`request_id`) REFERENCES `request` (`request_id`)
;

ALTER TABLE `replay` ADD CONSTRAINT `ref_replay_user` FOREIGN KEY `ref_replay_user` (`user_id`) REFERENCES `user` (`user_id`)
;

-- Index 'idx_replay_channel_id' was not detected in the database. It will be created
ALTER TABLE `replay` ADD INDEX `idx_replay_channel_id`(`channel_id`)
;

-- Index 'idx_replay_request_id' was not detected in the database. It will be created
ALTER TABLE `replay` ADD INDEX `idx_replay_request_id`(`request_id`)
;

-- Index 'idx_replay_user_id' was not detected in the database. It will be created
ALTER TABLE `replay` ADD INDEX `idx_replay_user_id`(`user_id`)
;

