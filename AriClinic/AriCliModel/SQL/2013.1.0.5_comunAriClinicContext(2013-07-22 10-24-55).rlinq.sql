-- add column for field amendmentInvoiceSerial
ALTER TABLE `healthcare_company` ADD COLUMN `amendment_invoice_serial` varchar(255) NULL
;

UPDATE `healthcare_company` SET `amendment_invoice_serial` = ' '
;

ALTER TABLE `healthcare_company` CHANGE COLUMN `amendment_invoice_serial` `amendment_invoice_serial` varchar(255) NOT NULL
;

