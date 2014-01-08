--
-- Create table "estimate"
--
CREATE TABLE estimate (
  user_id INT(11) DEFAULT NULL,
  ttal DECIMAL(20, 10) NOT NULL,
  request_id INT(11) DEFAULT NULL,
  full_name VARCHAR(255) DEFAULT NULL,
  estimate_id INT(11) NOT NULL AUTO_INCREMENT,
  estimate_date DATETIME NOT NULL,
  comments TEXT NOT NULL,
  PRIMARY KEY (estimate_id),
  INDEX idx_estimate_request_id (request_id),
  INDEX idx_estimate_user_id (user_id),
  CONSTRAINT ref_estimate_request FOREIGN KEY (request_id)
    REFERENCES request(request_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_estimate_user FOREIGN KEY (user_id)
    REFERENCES USER(user_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci

--
-- Create table "estimate_line"
--
CREATE TABLE estimate_line (
  insurance_service_id INT(11) DEFAULT NULL,
  estimate_line_id INT(11) NOT NULL AUTO_INCREMENT,
  estimate_id INT(11) DEFAULT NULL,
  discount DECIMAL(20, 10) NOT NULL,
  description VARCHAR(255) DEFAULT NULL,
  amount DECIMAL(20, 10) NOT NULL,
  PRIMARY KEY (estimate_line_id),
  INDEX idx_estimate_line_estimate_id (estimate_id),
  INDEX idx_estimate_line_insurance_service_id (insurance_service_id),
  CONSTRAINT ref_estimate_line_estimate FOREIGN KEY (estimate_id)
    REFERENCES estimate(estimate_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_estimate_line_insurance_service FOREIGN KEY (insurance_service_id)
    REFERENCES insurance_service(insurance_service_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;


--
-- Alter table "professional"
--
ALTER TABLE professional
  CHANGE COLUMN vatin vatin VARCHAR(255) DEFAULT NULL,
  CHANGE COLUMN TYPE TYPE VARCHAR(255) DEFAULT NULL,
  CHANGE COLUMN license license VARCHAR(255) DEFAULT NULL,
  CHANGE COLUMN invoice_serial invoice_serial VARCHAR(255) DEFAULT NULL,
  ADD COLUMN inactive BIT(1) DEFAULT NULL AFTER invoice_serial,
  CHANGE COLUMN commission commission DECIMAL(20, 10) DEFAULT NULL AFTER inactive,
  CHANGE COLUMN comercial_name comercial_name VARCHAR(255) DEFAULT NULL AFTER commission,
  CHARACTER SET utf8,
  COLLATE utf8_general_ci;

ALTER TABLE professional
  DROP FOREIGN KEY ref_professional_person;
ALTER TABLE professional
  DROP INDEX idx_prfssnl_prsn_d;
ALTER TABLE professional
  ADD CONSTRAINT ref_professional_person FOREIGN KEY (person_id)
    REFERENCES person(person_id) ON DELETE RESTRICT ON UPDATE RESTRICT;
--
-- Alter table "patient"
--
ALTER TABLE patient
  CHANGE COLUMN surname2 surname2 VARCHAR(30) DEFAULT NULL,
  CHANGE COLUMN surname1 surname1 VARCHAR(30) DEFAULT NULL,
  CHANGE COLUMN sex sex VARCHAR(1) DEFAULT NULL,
  CHANGE COLUMN NAME NAME VARCHAR(30) DEFAULT NULL AFTER oft_id,
  CHANGE COLUMN insurance_information insurance_information VARCHAR(255) DEFAULT NULL AFTER last_update,
  ADD COLUMN full_name VARCHAR(255) DEFAULT NULL AFTER insurance_information,
  CHANGE COLUMN comments comments LONGTEXT DEFAULT NULL AFTER person_id2,
  CHARACTER SET utf8,
  COLLATE utf8_general_ci;
--
-- Alter table "ticket"
--
ALTER TABLE ticket
  ADD COLUMN price DECIMAL(10, 2) DEFAULT NULL AFTER person_id,
  ADD COLUMN discount DECIMAL(10, 2) DEFAULT NULL AFTER insurance_service_id,
  CHANGE COLUMN description description VARCHAR(255) DEFAULT NULL AFTER discount,
  CHANGE COLUMN comments comments VARCHAR(255) DEFAULT NULL AFTER description,
  CHANGE COLUMN voa_class voa_class VARCHAR(255) DEFAULT NULL AFTER amount,
  CHARACTER SET utf8,
  COLLATE utf8_general_ci;
  
  -- Update price in  ticket
  UPDATE ticket SET price = amount;
