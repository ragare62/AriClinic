-- AriCliModel.Request
CREATE TABLE `request` (
    `born_date` datetime NOT NULL,          -- bornDate
    `dni` varchar(255) NULL,                -- dni
    `email` varchar(255) NULL,              -- email
    `nme` varchar(255) NULL,                -- name
    `postal_code` varchar(255) NULL,        -- postalCode
    `request_date_time` datetime NOT NULL,  -- requestDateTime
    `request_id` integer AUTO_INCREMENT NOT NULL, -- requestId
    `sex` varchar(255) NULL,                -- sex
    `surname1` varchar(255) NULL,           -- surname1
    `surname2` varchar(255) NULL,           -- surname2
    `telephone` varchar(255) NULL,          -- telephone
    CONSTRAINT `pk_request` PRIMARY KEY (`request_id`)
) ENGINE = InnoDB
;

