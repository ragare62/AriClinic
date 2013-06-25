-- AriCliModel.Channel
CREATE TABLE `channel` (
    `channel_id` integer AUTO_INCREMENT NOT NULL, -- channelId
    `nme` varchar(255) NULL,                -- name
    CONSTRAINT `pk_channel` PRIMARY KEY (`channel_id`)
) ENGINE = InnoDB
;

