/* import from original database */
DELETE FROM ariclinic_miestetic_original.healthcare_company;
INSERT INTO ariclinic_miestetic.healthcare_company
SELECT * FROM ariclinic_miestetic_original.healthcare_company;

DELETE * FROM ariclinic_miestetic_original.user_group;
INSERT INTO ariclinic_miestetic.user_group
SELECT * FROM ariclinic_miestetic_original.user_group;


/* base_type */
DELETE FROM ariclinic_miestetic.base_visit_type;
INSERT INTO ariclinic_miestetic.base_visit_type
SELECT * FROM ariclinic_miestetic_original.base_visit_type;

/* user */
DELETE FROM ariclinic_miestetic.user;
INSERT INTO ariclinic_miestetic.user
SELECT * FROM ariclinic_miestetic_original.user;

/* process */
DELETE FROM ariclinic_miestetic.process;
INSERT INTO ariclinic_miestetic.process
SELECT * FROM ariclinic_miestetic_original.process;

/* permission */
DELETE FROM ariclinic_miestetic.permission;
INSERT INTO ariclinic_miestetic.permission
SELECT * FROM ariclinic_miestetic_original.permission;

/* parametersparameter */
DELETE FROM ariclinic_miestetic.parameter;
INSERT INTO ariclinic_miestetic.parameter
SELECT * FROM ariclinic_miestetic_original.parameter;

/* clinic */
DELETE FROM ariclinic_miestetic.clinic;
INSERT INTO ariclinic_miestetic.clinic
SELECT * FROM ariclinic_miestetic_original.clinic;

/* tax_type */
DELETE FROM ariclinic_miestetic.tax_type;
INSERT INTO ariclinic_miestetic.tax_type
SELECT * FROM ariclinic_miestetic_original.tax_type;

/* tax_withholding_type */
DELETE FROM ariclinic_miestetic.tax_withholding_type;
INSERT INTO ariclinic_miestetic.tax_withholding_type
SELECT * FROM ariclinic_miestetic_original.tax_withholding_type;

/* person (need for professional */
INSERT INTO ariclinic_miestetic.person
SELECT ariclinic_miestetic_original.person.* 
FROM ariclinic_miestetic_original.person, ariclinic_miestetic_original.professional
WHERE ariclinic_miestetic_original.person.person_id = ariclinic_miestetic_original.professional.person_id;


/* professional */
DELETE FROM ariclinic_miestetic.professional;
INSERT INTO ariclinic_miestetic.professional
SELECT * FROM ariclinic_miestetic_original.professional;

/* service_category */
DELETE FROM ariclinic_miestetic.service_category;
INSERT INTO ariclinic_miestetic.service_category
SELECT * FROM ariclinic_miestetic_original.service_category;

/* service */
DELETE FROM ariclinic_miestetic.service;
INSERT INTO ariclinic_miestetic.service
SELECT * FROM ariclinic_miestetic_original.service;

/* insurance */
DELETE FROM ariclinic_miestetic.insurance;
INSERT INTO ariclinic_miestetic.insurance
SELECT * FROM ariclinic_miestetic_original.insurance;

/* insurance service */
DELETE FROM ariclinic_miestetic.insurance_service;
INSERT INTO ariclinic_miestetic.insurance_service
SELECT * FROM ariclinic_miestetic_original.insurance_service;

/* service note */
DELETE FROM ariclinic_miestetic.service_note;
INSERT INTO ariclinic_miestetic.service_note
SELECT * FROM ariclinic_miestetic_original.service_note;

/* ticket */
DELETE FROM ariclinic_miestetic.ticket;
INSERT INTO ariclinic_miestetic.ticket
SELECT * FROM ariclinic_miestetic_original.ticket;
