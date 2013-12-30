USE ariclinic_frido;

SET FOREIGN_KEY_CHECKS = 0;
--
-- Create table "amendment_invoice"
--
CREATE TABLE amendment_invoice (
  yr INT(11) NOT NULL,
  ttal DECIMAL(20, 10) NOT NULL,
  srial VARCHAR(255) DEFAULT NULL,
  reason TEXT DEFAULT NULL,
  invoice_id INT(11) DEFAULT NULL,
  invoice_number INT(11) NOT NULL,
  invoice_key VARCHAR(255) DEFAULT NULL,
  invoice_date DATETIME NOT NULL,
  person_id INT(11) DEFAULT NULL,
  amendment_invoice_id INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (amendment_invoice_id),
  INDEX idx_amendment_invoice_invoice_id (invoice_id),
  INDEX idx_amendment_invoice_person_id (person_id),
  CONSTRAINT ref_amendment_invoice_customer FOREIGN KEY (person_id)
    REFERENCES customer(person_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_amendment_invoice_invoice FOREIGN KEY (invoice_id)
    REFERENCES invoice(invoice_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Create table "amendment_invoice_line"
--
CREATE TABLE amendment_invoice_line (
  user_id INT(11) DEFAULT NULL,
  tax_type_id INT(11) DEFAULT NULL,
  tax_percentage DECIMAL(20, 10) NOT NULL,
  description VARCHAR(255) DEFAULT NULL,
  amount DECIMAL(20, 10) NOT NULL,
  amendment_invoice_line_id INT(11) NOT NULL AUTO_INCREMENT,
  amendment_invoice_id INT(11) DEFAULT NULL,
  PRIMARY KEY (amendment_invoice_line_id),
  INDEX idx_amendment_invoice_line_amendment_invoice_id (amendment_invoice_id),
  INDEX idx_amendment_invoice_line_tax_type_id (tax_type_id),
  INDEX idx_amendment_invoice_line_user_id (user_id),
  CONSTRAINT ref_amendment_invoice_line_amendment_invoice FOREIGN KEY (amendment_invoice_id)
    REFERENCES amendment_invoice(amendment_invoice_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_amendment_invoice_line_tax_type FOREIGN KEY (tax_type_id)
    REFERENCES tax_type(tax_type_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_amendment_invoice_line_user FOREIGN KEY (user_id)
    REFERENCES user(user_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Create table "campaign"
--
CREATE TABLE campaign (
  start_date DATETIME NOT NULL,
  nme VARCHAR(255) DEFAULT NULL,
  end_date DATETIME NOT NULL,
  campaign_id INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (campaign_id)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Create table "channel"
--
CREATE TABLE channel (
  nme VARCHAR(255) DEFAULT NULL,
  channel_id INT(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (channel_id)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

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
    REFERENCES user(user_id) ON DELETE RESTRICT ON UPDATE RESTRICT
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
-- Create table "replay"
--
CREATE TABLE replay (
  user_id INT(11) DEFAULT NULL,
  service_id INT(11) DEFAULT NULL,
  request_id INT(11) DEFAULT NULL,
  replay_id INT(11) NOT NULL AUTO_INCREMENT,
  replay_date DATETIME NOT NULL,
  comments TEXT DEFAULT NULL,
  channel_id INT(11) DEFAULT NULL,
  PRIMARY KEY (replay_id),
  INDEX idx_replay_channel_id (channel_id),
  INDEX idx_replay_request_id (request_id),
  INDEX idx_replay_service_id (service_id),
  INDEX idx_replay_user_id (user_id),
  CONSTRAINT ref_replay_channel FOREIGN KEY (channel_id)
    REFERENCES channel(channel_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_replay_request FOREIGN KEY (request_id)
    REFERENCES request(request_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_replay_service FOREIGN KEY (service_id)
    REFERENCES service(service_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_replay_user FOREIGN KEY (user_id)
    REFERENCES user(user_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Create table "request"
--
CREATE TABLE request (
  user_id INT(11) DEFAULT NULL,
  telephone VARCHAR(255) DEFAULT NULL,
  surname2 VARCHAR(255) DEFAULT NULL,
  surname1 VARCHAR(255) DEFAULT NULL,
  status VARCHAR(255) NOT NULL,
  source_id INT(11) DEFAULT NULL,
  sex VARCHAR(255) DEFAULT NULL,
  service_id INT(11) DEFAULT NULL,
  request_id INT(11) NOT NULL AUTO_INCREMENT,
  request_date_time DATETIME NOT NULL,
  postal_code VARCHAR(255) DEFAULT NULL,
  person_id INT(11) DEFAULT NULL,
  nme VARCHAR(255) DEFAULT NULL,
  full_name VARCHAR(255) NOT NULL,
  email VARCHAR(255) DEFAULT NULL,
  dni VARCHAR(255) DEFAULT NULL,
  comments TEXT DEFAULT NULL,
  clinic_id INT(11) DEFAULT NULL,
  channel_id INT(11) DEFAULT NULL,
  campaign_id INT(11) DEFAULT NULL,
  born_date DATETIME NOT NULL,
  PRIMARY KEY (request_id),
  INDEX idx_request_campaign_id (campaign_id),
  INDEX idx_request_channel_id (channel_id),
  INDEX idx_request_clinic_id (clinic_id),
  INDEX idx_request_person_id (person_id),
  INDEX idx_request_service_id (service_id),
  INDEX idx_request_source_id (source_id),
  INDEX idx_request_user_id (user_id),
  CONSTRAINT ref_request_campaign FOREIGN KEY (campaign_id)
    REFERENCES campaign(campaign_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_request_channel FOREIGN KEY (channel_id)
    REFERENCES channel(channel_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_request_clinic FOREIGN KEY (clinic_id)
    REFERENCES clinic(clinic_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_request_patient FOREIGN KEY (person_id)
    REFERENCES patient(person_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_request_service FOREIGN KEY (service_id)
    REFERENCES service(service_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_request_source FOREIGN KEY (source_id)
    REFERENCES source(source_id) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT ref_request_user FOREIGN KEY (user_id)
    REFERENCES user(user_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Create table "service_sub_category"
--
CREATE TABLE service_sub_category (
  service_sub_category_id INT(11) NOT NULL AUTO_INCREMENT,
  service_category_id INT(11) DEFAULT NULL,
  nme VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (service_sub_category_id),
  INDEX idx_service_sub_category_service_category_id (service_category_id),
  CONSTRAINT ref_service_sub_category_service_category FOREIGN KEY (service_category_id)
    REFERENCES service_category(service_category_id) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Create table "tarifario"
--
CREATE TABLE tarifario (
  tratamiento VARCHAR(255) DEFAULT NULL,
  categoria VARCHAR(255) DEFAULT NULL,
  subcategoria VARCHAR(255) DEFAULT NULL,
  importe DECIMAL(10, 2) DEFAULT NULL,
  tipoiva VARCHAR(255) DEFAULT NULL,
  category_id INT(11) DEFAULT NULL,
  sub_category_id INT(11) DEFAULT NULL,
  service_id INT(11) DEFAULT NULL,
  insurance_service_id INT(11) DEFAULT NULL,
  tax_type_id INT(11) DEFAULT NULL,
  insurance_id INT(11) DEFAULT NULL,
  old_insurance_id INT(11) DEFAULT NULL
)
ENGINE = INNODB
CHARACTER SET latin1
COLLATE latin1_swedish_ci;

--
-- Create table "template"
--
CREATE TABLE template (
  template_id INT(11) NOT NULL AUTO_INCREMENT,
  nme VARCHAR(255) DEFAULT NULL,
  content TEXT DEFAULT NULL,
  PRIMARY KEY (template_id)
)
ENGINE = INNODB
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Alter table "healthcare_company"
--
ALTER TABLE healthcare_company
  CHANGE COLUMN vatin vatin VARCHAR(20) DEFAULT NULL,
  CHANGE COLUMN NAME NAME VARCHAR(255) DEFAULT NULL,
  CHANGE COLUMN invoice_serial invoice_serial VARCHAR(30) DEFAULT NULL AFTER NAME,
  ADD COLUMN amendment_invoice_serial VARCHAR(255) NOT NULL AFTER hc_id,
  CHARACTER SET utf8,
  COLLATE utf8_general_ci;

--
-- Alter table "service"
--
ALTER TABLE service
  ADD COLUMN service_sub_category_id INT(11) DEFAULT NULL AFTER tax_type_id,
  CHANGE COLUMN name name VARCHAR(250) DEFAULT NULL AFTER oft_id,
  ROW_FORMAT = COMPACT,
  CHECKSUM = 0,
  DELAY_KEY_WRITE = 0,
  CHARACTER SET utf8,
  COLLATE utf8_general_ci;

ALTER TABLE service
  ADD INDEX idx_service_service_sub_category_id (service_sub_category_id);

ALTER TABLE service
  ADD CONSTRAINT ref_service_service_sub_category FOREIGN KEY (service_sub_category_id)
    REFERENCES service_sub_category(service_sub_category_id) ON DELETE RESTRICT ON UPDATE RESTRICT;
--
-- Alter table "parameter"
--
ALTER TABLE parameter
  ADD COLUMN sms_clave VARCHAR(255) DEFAULT NULL AFTER appointment_extension,
  ADD COLUMN sms_email VARCHAR(255) DEFAULT NULL AFTER sms_clave,
  ADD COLUMN sms_remitente VARCHAR(255) DEFAULT NULL AFTER sms_email,
  CHARACTER SET utf8,
  COLLATE utf8_general_ci;


SET FOREIGN_KEY_CHECKS = 1;
