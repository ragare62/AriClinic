/* import from original database */
DELETE FROM ariclinic_miestetic.healthcare_company;
INSERT INTO ariclinic_miestetic.healthcare_company
SELECT * FROM ariclinic_miestetic_original.healthcare_company;

DELETE FROM ariclinic_miestetic.user_group;
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

/* parameters */
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

/* examination_type */
DELETE FROM ariclinic_miestetic.examination_type;
INSERT INTO ariclinic_miestetic.examination_type
SELECT * FROM ariclinic_miestetic_original.examination_type;
