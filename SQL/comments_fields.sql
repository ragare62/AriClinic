ALTER TABLE `ariclinic_frido`.`patient` CHANGE `comments` `comments` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
ALTER TABLE `ariclinic_frido`.`appointment` CHANGE `comments` `comments` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
ALTER TABLE `ariclinic_frido`.`back_family` CHANGE `content` `content` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
ALTER TABLE `ariclinic_frido`.`diagnostic_assigned`CHANGE `comments` `comments` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
ALTER TABLE `ariclinic_frido`.`lab_test_assigned` CHANGE `comments` `comments` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
ALTER TABLE `ariclinic_frido`.`ophthalmologic_visit` CHANGE `diagnostic_details` `diagnostic_details` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
ALTER TABLE `ariclinic_frido`.`previous_medical_record` CHANGE `content` `content` LONGTEXT CHARSET latin1 COLLATE latin1_swedish_ci NULL; 
