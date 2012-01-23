# invoices
DELETE FROM invoice_line;
DELETE FROM invoice;

# examination
DELETE FROM `without_glasses_test`;
DELETE FROM `subjective_optical_examination`;
DELETE FROM `optical_objective_examination`;
DELETE FROM `glasses_test`;
DELETE FROM `contact_lenses_test`;
DELETE FROM `prescription_glasses`;
DELETE FROM `cycloplegia`;
DELETE FROM `refractometry`;
DELETE FROM examination_assigned;
DELETE FROM examination;
#
DELETE FROM drug;
DELETE FROM `treatment`;
#
DELETE FROM `ant_segment`;
DELETE FROM `fundus`;
DELETE FROM `mot_append`;
DELETE FROM `ophthalmologic_visit`;
#
DELETE FROM procedure_assigned;
DELETE FROM `procedure`;
#
DELETE FROM `diagnostic_assigned`;
DELETE FROM diagnostic;
#
DELETE FROM base_visit;
DELETE FROM appointment;
DELETE FROM appointment_type;
DELETE FROM diary;
DELETE FROM visit_reason;
#
DELETE FROM payment;
DELETE FROM ticket;
DELETE FROM service_note;
#
DELETE FROM policy;
DELETE FROM insurance_service;
DELETE FROM insurance;
#
DELETE FROM service;
DELETE FROM service_category;
#
DELETE FROM tax_type;
DELETE FROM address;
DELETE FROM email;
DELETE FROM telephone;
#
DELETE FROM lab_test_assigned;
DELETE FROM lab_test;
#
DELETE FROM professional;
DELETE FROM clinic;
DELETE FROM customer;
DELETE FROM patient;


