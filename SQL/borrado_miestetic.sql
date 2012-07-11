# invoices
DELETE FROM invoice_line;
ALTER TABLE invoice_line AUTO_INCREMENT=1;
DELETE FROM invoice;
ALTER TABLE invoice AUTO_INCREMENT=1;

# examination
DELETE FROM `without_glasses_test`;
ALTER TABLE without_glasses_test AUTO_INCREMENT=1;
DELETE FROM `subjective_optical_examination`;
ALTER TABLE subjective_optical_examination AUTO_INCREMENT=1;
DELETE FROM `optical_objective_examination`;
ALTER TABLE optical_objective_examination AUTO_INCREMENT=1;
DELETE FROM `glasses_test`;
ALTER TABLE glasses_test AUTO_INCREMENT=1;
DELETE FROM `contact_lenses_test`;
ALTER TABLE contact_lenses_test AUTO_INCREMENT=1;
DELETE FROM `prescription_glasses`;
ALTER TABLE prescription_glasses AUTO_INCREMENT=1;
DELETE FROM `cycloplegia`;
ALTER TABLE cycloplegia AUTO_INCREMENT=1;
DELETE FROM `refractometry`;
ALTER TABLE refractometry AUTO_INCREMENT=1;
DELETE FROM examination_assigned;
ALTER TABLE examination_assigned AUTO_INCREMENT=1;
DELETE FROM examination;
#
DELETE FROM drug;
ALTER TABLE drug AUTO_INCREMENT=1;
DELETE FROM `treatment`;
ALTER TABLE treatment AUTO_INCREMENT=1;
#
DELETE FROM `ant_segment`;
ALTER TABLE ant_segment AUTO_INCREMENT=1;
DELETE FROM `fundus`;
ALTER TABLE fundus AUTO_INCREMENT=1;
DELETE FROM `mot_append`;
ALTER TABLE mot_append AUTO_INCREMENT=1;
DELETE FROM `ophthalmologic_visit`;
ALTER TABLE ophthalmologic_visit AUTO_INCREMENT=1;
#
DELETE FROM procedure_assigned;
ALTER TABLE procedure_assigned AUTO_INCREMENT=1;
DELETE FROM `procedure`;
ALTER TABLE `procedure` AUTO_INCREMENT=1;
#
DELETE FROM `diagnostic_assigned`;
ALTER TABLE diagnostic_assigned AUTO_INCREMENT=1;
DELETE FROM diagnostic;
ALTER TABLE diagnostic AUTO_INCREMENT=1;
#
DELETE FROM base_visit;
ALTER TABLE base_visit AUTO_INCREMENT=1;
DELETE FROM appointment;
ALTER TABLE appointment AUTO_INCREMENT=1;
DELETE FROM appointment_type;
ALTER TABLE appointment_type AUTO_INCREMENT=1;
DELETE FROM diary;
ALTER TABLE diary AUTO_INCREMENT=1;
DELETE FROM visit_reason;
ALTER TABLE visit_reason AUTO_INCREMENT=1;
#
DELETE FROM payment;
ALTER TABLE payment AUTO_INCREMENT=1;
DELETE FROM ticket;
ALTER TABLE ticket AUTO_INCREMENT=1;
DELETE FROM `general_payment`;
ALTER TABLE `general_payment` AUTO_INCREMENT=1;
DELETE FROM service_note;
ALTER TABLE service_note AUTO_INCREMENT=1;
#
DELETE FROM policy;
ALTER TABLE policy AUTO_INCREMENT=1;
DELETE FROM insurance_service;
ALTER TABLE insurance_service AUTO_INCREMENT=1;
DELETE FROM insurance;
ALTER TABLE insurance AUTO_INCREMENT=1;
#
DELETE FROM service;
ALTER TABLE service AUTO_INCREMENT=1;
DELETE FROM service_category;
ALTER TABLE service_category AUTO_INCREMENT=1;
#
DELETE FROM tax_type;
ALTER TABLE tax_type AUTO_INCREMENT=1;
DELETE FROM address;
ALTER TABLE address AUTO_INCREMENT=1;
DELETE FROM email;
ALTER TABLE email AUTO_INCREMENT=1;
DELETE FROM telephone;
ALTER TABLE telephone AUTO_INCREMENT=1;
#
DELETE FROM lab_test_assigned;
ALTER TABLE lab_test_assigned AUTO_INCREMENT=1;
DELETE FROM lab_test;
ALTER TABLE lab_test AUTO_INCREMENT=1;
DELETE FROM back_family;
ALTER TABLE back_family AUTO_INCREMENT=1;
DELETE FROM back_personal;
ALTER TABLE back_personal AUTO_INCREMENT=1;
DELETE FROM back_ginecoloy;
ALTER TABLE back_ginecoloy AUTO_INCREMENT=1;
DELETE FROM previous_medical_record;
ALTER TABLE previous_medical_record AUTO_INCREMENT=1;
#
DELETE FROM professional;
ALTER TABLE professional AUTO_INCREMENT=1;
DELETE FROM patient;
ALTER TABLE patient AUTO_INCREMENT=1;

DELETE FROM clinic;
ALTER TABLE clinic AUTO_INCREMENT=1;
DELETE FROM customer;
ALTER TABLE customer AUTO_INCREMENT=1;

DELETE FROM person;
ALTER TABLE person AUTO_INCREMENT=1;
DELETE FROM source;
ALTER TABLE source AUTO_INCREMENT=1;


