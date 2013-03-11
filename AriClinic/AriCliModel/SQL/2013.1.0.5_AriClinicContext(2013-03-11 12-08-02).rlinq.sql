-- AriCliModel.Template
CREATE TABLE `template` (
    `content` text NULL,                    -- content
    `nme` varchar(255) NULL,                -- name
    `template_id` integer NOT NULL,         -- templateId
    CONSTRAINT `pk_template` PRIMARY KEY (`template_id`)
) ENGINE = InnoDB
;

