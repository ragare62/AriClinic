-- AriCliModel.Address
CREATE TABLE `address` (
    `type` varchar(10) NULL,                -- type
    `street2` varchar(100) NULL,            -- street2
    `street` varchar(50) NULL,              -- street
    `province` varchar(255) NULL,           -- province
    `post_code` varchar(10) NULL,           -- postCode
    `person_id` integer NULL,               -- person
    `hc_id` integer NULL,                   -- healthcareCompany
    `country` varchar(30) NULL,             -- country
    `clinic_id` integer NULL,               -- clinic
    `city` varchar(30) NULL,                -- city
    `address_id` integer AUTO_INCREMENT NOT NULL, -- addressId
    CONSTRAINT `pk_address` PRIMARY KEY (`address_id`)
) ENGINE = InnoDB;

-- AriCliModel.AnestheticServiceNote
CREATE TABLE `anesthetic_service_note` (
    `user_id` integer NULL,                 -- user
    `total` decimal(12,2) NOT NULL,         -- total
    `surgeon_person_id` integer NULL,       -- professional2
    `service_note_date` datetime NOT NULL,  -- serviceNoteDate
    `professional_person_id` integer NULL,  -- professional1
    `invoice_id` integer NULL,              -- invoice
    `customer_person_id` integer NULL,      -- customer
    `clinic_id` integer NULL,               -- clinic
    `chk3` bit NOT NULL,                    -- chk3
    `chk2` bit NOT NULL,                    -- chk2
    `chk1` bit NOT NULL,                    -- chk1
    `anesthetic_service_note_id` integer AUTO_INCREMENT NOT NULL, -- anestheticServiceNoteId
    CONSTRAINT `pk_anesthetic_service_note` PRIMARY KEY (`anesthetic_service_note_id`)
) ENGINE = InnoDB;

-- System.Collections.Generic.IList`1 AriCliModel.AnestheticServiceNote.procedures
CREATE TABLE `anesthetic_service_note_procedures` (
    `anesthetic_service_note_id` int NULL,
    `procedure_id` int NOT NULL,
    CONSTRAINT `pk_anesthetic_service_note_procedures` PRIMARY KEY (`anesthetic_service_note_id`, `procedure_id`)
) ENGINE = InnoDB;

-- AriCliModel.AnestheticTicket
CREATE TABLE `anesthetic_ticket` (
    `ticket_id` integer NOT NULL,
    `person_id` integer NULL,               -- AnestheticTicket.surgeon
    `procedure_id` integer NULL,            -- AnestheticTicket.procedure
    `anesthetic_service_note_id` integer NULL, -- AnestheticTicket.anestheticServiceNote1
    CONSTRAINT `pk_anesthetic_ticket` PRIMARY KEY (`ticket_id`)
) ENGINE = InnoDB;

-- AriCliModel.AntSegment
CREATE TABLE `ant_segment` (
    `tyndall` varchar(255) NULL,            -- tyndall
    `pupil` varchar(255) NULL,              -- pupil
    `visit_id` integer NULL,                -- ophthalmologicVisit
    `iris` varchar(255) NULL,               -- iris
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `eyestrain_r_e` decimal(20,10) NOT NULL, -- eyestrainRE
    `eyestrain_l_e` decimal(20,10) NOT NULL, -- eyestrainLE
    `eyebrows_comments` varchar(255) NULL,  -- eyebrowsComments
    `crystalline` varchar(255) NULL,        -- crystalline
    `cornea` varchar(255) NULL,             -- cornea
    `conjunctiva` varchar(255) NULL,        -- conjunctiva
    `chamber` varchar(255) NULL,            -- chamber
    CONSTRAINT `pk_ant_segment` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.AppointmentInfo
CREATE TABLE `appointment` (
    `user_id` integer NULL,                 -- user
    `subject` varchar(255) NULL,            -- subject
    `status` varchar(255) NULL,             -- status
    `recurrence` varchar(255) NULL,         -- recurrence
    `person_id` integer NULL,               -- professional
    `person_id2` integer NULL,              -- patient
    `father_appointment_appointment_id` integer NULL, -- fatherAppointment
    `end_date_time` datetime NOT NULL,      -- endDateTime
    `duration` integer NOT NULL,            -- duration
    `diary_id` integer NULL,                -- diary
    `comments` text NULL,                   -- comments
    `begin_date_time` datetime NOT NULL,    -- beginDateTime
    `arrival` datetime NOT NULL,            -- arrival
    `appointment_type_id` integer NULL,     -- appointmentType
    `appointment_id` integer AUTO_INCREMENT NOT NULL, -- appointmentId
    CONSTRAINT `pk_appointment` PRIMARY KEY (`appointment_id`)
) ENGINE = InnoDB;

-- AriCliModel.AppointmentType
CREATE TABLE `appointment_type` (
    `oft_id` integer NULL,                  -- oftId
    `name` varchar(50) NULL,                -- name
    `duration` integer NOT NULL,            -- duration
    `appointment_type_id` integer AUTO_INCREMENT NOT NULL, -- appointmentTypeId
    CONSTRAINT `pk_appointment_type` PRIMARY KEY (`appointment_type_id`)
) ENGINE = InnoDB;

-- AriCliModel.BackFamily
CREATE TABLE `back_family` (
    `person_id` integer NULL,               -- patient
    `content` varchar(255) NULL,            -- content
    `back_family_id` integer AUTO_INCREMENT NOT NULL, -- backFamilyId
    CONSTRAINT `pk_back_family` PRIMARY KEY (`back_family_id`)
) ENGINE = InnoDB;

-- AriCliModel.BackGinecology
CREATE TABLE `back_ginecoloy` (
    `vaginal_deliveries` integer NOT NULL,  -- vaginalDeliveries
    `person_id` integer NULL,               -- patient
    `menstrual_formula` varchar(255) NULL,  -- menstrualFormula
    `menopause` varchar(255) NULL,          -- menopause
    `menarche` varchar(255) NULL,           -- menarche
    `date_of_last_mestrual` datetime NOT NULL, -- dateOfLastMestrual
    `content` longtext NULL,                -- content
    `cesarean_deliveries` integer NOT NULL, -- cesareanDeliveries
    `back_ginecoloy_id` integer AUTO_INCREMENT NOT NULL, -- backGinecologyId
    `abortions` integer NOT NULL,           -- abortions
    CONSTRAINT `pk_back_ginecoloy` PRIMARY KEY (`back_ginecoloy_id`)
) ENGINE = InnoDB;

-- AriCliModel.BackPersonal
CREATE TABLE `back_personal` (
    `person_id` integer NULL,               -- patient
    `content` longtext NULL,                -- content
    `back_personal_id` integer AUTO_INCREMENT NOT NULL, -- backPersonalId
    CONSTRAINT `pk_back_personal` PRIMARY KEY (`back_personal_id`)
) ENGINE = InnoDB;

-- AriCliModel.BaseVisit
CREATE TABLE `base_visit` (
    `vtype` varchar(255) NULL,              -- vType
    `visit_reason_id` integer NULL,         -- visitReason
    `visit_id` integer AUTO_INCREMENT NOT NULL, -- visitId
    `visit_date` datetime NOT NULL,         -- visitDate
    `person_id` integer NULL,               -- professional
    `person_id2` integer NULL,              -- patient
    `oft_ref_visita` integer NOT NULL,      -- oftRefVisita
    `comments` text NULL,                   -- comments
    `code` varchar(255) NULL,               -- baseVisitType
    `appointment_type_id` integer NULL,     -- appointmentType
    `appointment_id` integer NULL,          -- appointmentInfo
    `voa_class` varchar(255) NULL,          -- <internal-class-id>
    CONSTRAINT `pk_base_visit` PRIMARY KEY (`visit_id`)
) ENGINE = InnoDB;

-- AriCliModel.BaseVisitType
CREATE TABLE `base_visit_type` (
    `nme` varchar(255) NULL,                -- name
    `code` varchar(255) NOT NULL,           -- code
    CONSTRAINT `pk_base_visit_type` PRIMARY KEY (`code`)
) ENGINE = InnoDB;

-- AriCliModel.Biometry
CREATE TABLE `biometry` (
    `examination_assigned_id` integer NOT NULL,
    `lio_right_eye` numeric(20,10) NULL,    -- Biometry.lioRightEye
    `lio_left_eye` numeric(20,10) NULL,     -- Biometry.lioLeftEye
    `formula` varchar(255) NULL,            -- Biometry.formula
    `alx_right_eye` numeric(20,10) NULL,    -- Biometry.alxRightEye
    `alx_left_eye` numeric(20,10) NULL,     -- Biometry.alxLeftEye
    CONSTRAINT `pk_biometry` PRIMARY KEY (`examination_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Campaign
CREATE TABLE `campaign` (
    `start_date` datetime NOT NULL,         -- startDate
    `nme` varchar(255) NULL,                -- name
    `end_date` datetime NOT NULL,           -- endDate
    `campaign_id` integer AUTO_INCREMENT NOT NULL, -- campaignId
    CONSTRAINT `pk_campaign` PRIMARY KEY (`campaign_id`)
) ENGINE = InnoDB;

-- AriCliModel.Clinic
CREATE TABLE `clinic` (
    `remote_ip` varchar(30) NULL,           -- remoteIp
    `name` varchar(50) NULL,                -- name
    `clinic_id` INTEGER AUTO_INCREMENT NOT NULL, -- clinicId
    CONSTRAINT `pk_clinic` PRIMARY KEY (`clinic_id`)
) ENGINE = InnoDB;

-- AriCliModel.ContactLensesTest
CREATE TABLE `contact_lenses_test` (
    `examination_assigned_id` integer NULL, -- refractometry1
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_visual_acuity_both_eyes` varchar(255) NULL, -- farVisualAcuityBothEyes
    `comments` varchar(255) NULL,           -- comments
    `close_visual_acuity_right_eye` varchar(255) NULL, -- closeVisualAcuityRightEye
    `close_visual_acuity_left_eye` varchar(255) NULL, -- closeVisualAcuityLeftEye
    `close_visual_acuity_both_eyes` varchar(255) NULL, -- closeVisualAcuityBothEyes
    CONSTRAINT `pk_contact_lenses_test` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.Customer
CREATE TABLE `customer` (
    `person_id` integer NOT NULL,
    `vat_in` varchar(25) NULL,              -- Customer.vATIN
    `oft_id` integer NULL,                  -- Customer.oftId
    `comercial_name` varchar(50) NULL,      -- Customer.comercialName
    CONSTRAINT `pk_customer` PRIMARY KEY (`person_id`)
) ENGINE = InnoDB;

-- AriCliModel.Cycloplegia
CREATE TABLE `cycloplegia` (
    `examination_assigned_id` integer NULL, -- refractometry1
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_sphericity_right_eye` varchar(255) NULL, -- farSphericityRightEye
    `far_sphericity_left_eye` varchar(255) NULL, -- farSphericityLeftEye
    `far_prism_left_eye` varchar(255) NULL, -- farPrismLeftEye
    `far_prims_right_eye` varchar(255) NULL, -- farPrimsRightEye
    `far_cylinder_right_eye` varchar(255) NULL, -- farCylinderRightEye
    `far_cylinder_left_eye` varchar(255) NULL, -- farCylinderLeftEye
    `far_centers` varchar(255) NULL,        -- farCenters
    `far_axis_right_eye` varchar(255) NULL, -- farAxisRightEye
    `far_axis_left_eye` varchar(255) NULL,  -- farAxisLeftEye
    `far_acuity` varchar(255) NULL,         -- farAcuity
    `comments` varchar(255) NULL,           -- comments
    `close_sphericity_right_eye` varchar(255) NULL, -- closeSphericityRightEye
    `close_sphericity_left_eye` varchar(255) NULL, -- closeSphericityLeftEye
    `close_sphericity_centers` integer NOT NULL, -- closeSphericityCenters
    `close_prism_right_eye` varchar(255) NULL, -- closePrismRightEye
    `close_prism_left_eye` varchar(255) NULL, -- closePrismLeftEye
    `close_cylinder_right_eye` varchar(255) NULL, -- closeCylinderRightEye
    `close_cylinder_left_eye` varchar(255) NULL, -- closeCylinderLeftEye
    `close_centers` varchar(255) NULL,      -- closeCenters
    `close_axis_right_eye` varchar(255) NULL, -- closeAxisRightEye
    `close_axis_left_eye` varchar(255) NULL, -- closeAxisLeftEye
    `close_acuity_right_eye` varchar(255) NULL, -- closeAcuityRightEye
    `close_acuity_left_eye` varchar(255) NULL, -- closeAcuityLeftEye
    `close_acuity` varchar(255) NULL,       -- closeAcuity
    `both_sphericity_right_eye` varchar(255) NULL, -- bothSphericityRightEye
    `both_sphericity_left_eye` varchar(255) NULL, -- bothSphericityLeftEye
    `both_prism_right_eye` varchar(255) NULL, -- bothPrismRightEye
    `both_prism_left_eye` varchar(255) NULL, -- bothPrismLeftEye
    `both_cylinder_right_eye` varchar(255) NULL, -- bothCylinderRightEye
    `both_cylinder_left_eye` varchar(255) NULL, -- bothCylinderLeftEye
    `both_centers` varchar(255) NULL,       -- bothCenters
    `both_axis_right_eye` varchar(255) NULL, -- bothAxisRightEye
    `both_axis_left_eye` varchar(255) NULL, -- bothAxisLeftEye
    `both_acuity_right_eye` varchar(255) NULL, -- bothAcuityRightEye
    `both_acuity_left_eye` varchar(255) NULL, -- bothAcuityLeftEye
    `both_acuity` varchar(255) NULL,        -- bothAcuity
    CONSTRAINT `pk_cycloplegia` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.Diagnostic
CREATE TABLE `diagnostic` (
    `oft_id` integer NOT NULL,              -- oftId
    `name` varchar(50) NULL,                -- name
    `diagnostic_id` integer AUTO_INCREMENT NOT NULL, -- diagnosticId
    CONSTRAINT `pk_diagnostic` PRIMARY KEY (`diagnostic_id`)
) ENGINE = InnoDB;

-- AriCliModel.DiagnosticAssigned
CREATE TABLE `diagnostic_assigned` (
    `person_id` integer NULL,               -- patient
    `diagnostic_date` datetime NOT NULL,    -- diagnosticDate
    `diagnostic_assigned_id` INTEGER AUTO_INCREMENT NOT NULL, -- diagnosticAssignedId
    `diagnostic_id` integer NULL,           -- diagnostic
    `comments` longtext NULL,               -- comments
    `visit_id` integer NULL,                -- baseVisit
    CONSTRAINT `pk_diagnostic_assigned` PRIMARY KEY (`diagnostic_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Diary
CREATE TABLE `diary` (
    `time_step` integer NOT NULL,           -- timeStep
    `oft_id` integer NULL,                  -- oftId
    `nme` varchar(255) NULL,                -- name
    `end_hour` datetime NOT NULL,           -- endHour
    `diary_id` integer AUTO_INCREMENT NOT NULL, -- diaryId
    `begin_hour` datetime NOT NULL,         -- beginHour
    CONSTRAINT `pk_diary` PRIMARY KEY (`diary_id`)
) ENGINE = InnoDB;

-- AriCliModel.Drug
CREATE TABLE `drug` (
    `oft_id` integer NOT NULL,              -- oftId
    `name` varchar(50) NULL,                -- name
    `drug_id` integer AUTO_INCREMENT NOT NULL, -- drugId
    CONSTRAINT `pk_drug` PRIMARY KEY (`drug_id`)
) ENGINE = InnoDB;

-- AriCliModel.Email
CREATE TABLE `email` (
    `url` varchar(50) NULL,                 -- url
    `type` varchar(10) NULL,                -- type
    `person_id` integer NULL,               -- person
    `hc_id` integer NULL,                   -- healthcareCompany
    `email_id` integer AUTO_INCREMENT NOT NULL, -- emailId
    `clinic_id` integer NULL,               -- clinic
    CONSTRAINT `pk_email` PRIMARY KEY (`email_id`)
) ENGINE = InnoDB;

-- AriCliModel.Examination
CREATE TABLE `examination` (
    `oft_id` integer NOT NULL,              -- oftId
    `name` varchar(255) NULL,               -- name
    `code` varchar(255) NULL,               -- examinationType
    `examination_id` integer AUTO_INCREMENT NOT NULL, -- examinationId
    CONSTRAINT `pk_examination` PRIMARY KEY (`examination_id`)
) ENGINE = InnoDB;

-- AriCliModel.ExaminationAssigned
CREATE TABLE `examination_assigned` (
    `person_id` integer NULL,               -- patient
    `examination_date` datetime NOT NULL,   -- examinationDate
    `examination_assigned_id` integer AUTO_INCREMENT NOT NULL, -- examinationAssignedId
    `examination_id` integer NULL,          -- examination
    `comments` text NULL,                   -- comments
    `visit_id` integer NULL,                -- baseVisit
    `voa_class` varchar(255) NULL,          -- <internal-class-id>
    CONSTRAINT `pk_examination_assigned` PRIMARY KEY (`examination_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.ExaminationType
CREATE TABLE `examination_type` (
    `nme` varchar(255) NULL,                -- name
    `code` varchar(255) NOT NULL,           -- code
    CONSTRAINT `pk_examination_type` PRIMARY KEY (`code`)
) ENGINE = InnoDB;

-- AriCliModel.Fundus
CREATE TABLE `fundus` (
    `vitreous` text NULL,                   -- vitreous
    `vessels` text NULL,                    -- vessels
    `periphery` text NULL,                  -- periphery
    `optic_nerve` text NULL,                -- opticNerve
    `visit_id` integer NULL,                -- ophthalmologicVisit
    `macula` text NULL,                     -- macula
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    CONSTRAINT `pk_fundus` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.GeneralPayment
CREATE TABLE `general_payment` (
    `service_note_id` integer NULL,         -- serviceNote
    `payment_method_id` INTEGER NULL,       -- paymentMethod
    `payment_date` datetime NOT NULL,       -- paymentDate
    `general_payment_id` integer AUTO_INCREMENT NOT NULL, -- generalPaymentId
    `description` varchar(255) NULL,        -- description
    `clinic_id` INTEGER NULL,               -- clinic
    `amount` decimal(20,10) NOT NULL,       -- amount
    CONSTRAINT `pk_general_payment` PRIMARY KEY (`general_payment_id`)
) ENGINE = InnoDB;

-- AriCliModel.GlassesTest
CREATE TABLE `glasses_test` (
    `examination_assigned_id` integer NULL, -- refractometry1
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_sphericity_right_eye` varchar(255) NULL, -- farSphericityRightEye
    `far_sphericity_left_eye` varchar(255) NULL, -- farSphericityLeftEye
    `far_prism_left_eye` varchar(255) NULL, -- farPrismLeftEye
    `far_prims_right_eye` varchar(255) NULL, -- farPrimsRightEye
    `far_cylinder_right_eye` varchar(255) NULL, -- farCylinderRightEye
    `far_cylinder_left_eye` varchar(255) NULL, -- farCylinderLeftEye
    `far_centers` varchar(255) NULL,        -- farCenters
    `far_axis_right_eye` varchar(255) NULL, -- farAxisRightEye
    `far_axis_left_eye` varchar(255) NULL,  -- farAxisLeftEye
    `far_acuity` varchar(255) NULL,         -- farAcuity
    `comments` varchar(255) NULL,           -- comments
    `close_sphericity_right_eye` varchar(255) NULL, -- closeSphericityRightEye
    `close_sphericity_left_eye` varchar(255) NULL, -- closeSphericityLeftEye
    `close_sphericity_centers` integer NOT NULL, -- closeSphericityCenters
    `close_prism_right_eye` varchar(255) NULL, -- closePrismRightEye
    `close_prism_left_eye` varchar(255) NULL, -- closePrismLeftEye
    `close_cylinder_right_eye` varchar(255) NULL, -- closeCylinderRightEye
    `close_cylinder_left_eye` varchar(255) NULL, -- closeCylinderLeftEye
    `close_centers` varchar(255) NULL,      -- closeCenters
    `close_axis_right_eye` varchar(255) NULL, -- closeAxisRightEye
    `close_axis_left_eye` varchar(255) NULL, -- closeAxisLeftEye
    `close_acuity_right_eye` varchar(255) NULL, -- closeAcuityRightEye
    `close_acuity_left_eye` varchar(255) NULL, -- closeAcuityLeftEye
    `close_acuity` varchar(255) NULL,       -- closeAcuity
    `both_sphericity_right_eye` varchar(255) NULL, -- bothSphericityRightEye
    `both_sphericity_left_eye` varchar(255) NULL, -- bothSphericityLeftEye
    `both_prism_right_eye` varchar(255) NULL, -- bothPrismRightEye
    `both_prism_left_eye` varchar(255) NULL, -- bothPrismLeftEye
    `both_cylinder_right_eye` varchar(255) NULL, -- bothCylinderRightEye
    `both_cylinder_left_eye` varchar(255) NULL, -- bothCylinderLeftEye
    `both_centers` varchar(255) NULL,       -- bothCenters
    `both_axis_right_eye` varchar(255) NULL, -- bothAxisRightEye
    `both_axis_left_eye` varchar(255) NULL, -- bothAxisLeftEye
    `both_acuity_right_eye` varchar(255) NULL, -- bothAcuityRightEye
    `both_acuity_left_eye` varchar(255) NULL, -- bothAcuityLeftEye
    `both_acuity` varchar(255) NULL,        -- bothAcuity
    CONSTRAINT `pk_glasses_test` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.HealthcareCompany
CREATE TABLE `healthcare_company` (
    `vatin` varchar(20) NULL,               -- vATIN
    `name` varchar(255) NULL,               -- name
    `invoice_serial` varchar NULL,          -- invoiceSerial
    `hc_id` integer AUTO_INCREMENT NOT NULL, -- hcId
    CONSTRAINT `pk_healthcare_company` PRIMARY KEY (`hc_id`)
) ENGINE = InnoDB;

-- AriCliModel.Insurance
CREATE TABLE `insurance` (
    `oft_id` integer NOT NULL,              -- oftId
    `name` varchar(50) NULL,                -- name
    `internal` bit NOT NULL,                -- _internal
    `insurance_id` integer AUTO_INCREMENT NOT NULL, -- insuranceId
    CONSTRAINT `pk_insurance` PRIMARY KEY (`insurance_id`)
) ENGINE = InnoDB;

-- AriCliModel.InsuranceService
CREATE TABLE `insurance_service` (
    `service_id` integer NULL,              -- service
    `price` decimal(8,2) NOT NULL,          -- price
    `oft_id` integer NOT NULL,              -- oftId
    `insurance_service_id` integer AUTO_INCREMENT NOT NULL, -- insuranceServiceId
    `insurance_id` integer NULL,            -- insurance
    CONSTRAINT `pk_insurance_service` PRIMARY KEY (`insurance_service_id`)
) ENGINE = InnoDB;

-- AriCliModel.Invoice
CREATE TABLE `invoice` (
    `year` integer NOT NULL,                -- year
    `total` decimal(12,2) NOT NULL,         -- total
    `serial` varchar(10) NULL,              -- serial
    `invoice_number` integer NOT NULL,      -- invoiceNumber
    `invoice_key` varchar(255) NULL,        -- invoiceKey
    `invoice_id` integer AUTO_INCREMENT NOT NULL, -- invoiceId
    `invoice_date` datetime NOT NULL,       -- invoiceDate
    `customer_id` integer NULL,             -- customer
    CONSTRAINT `pk_invoice` PRIMARY KEY (`invoice_id`)
) ENGINE = InnoDB;

-- AriCliModel.InvoiceLine
CREATE TABLE `invoice_line` (
    `user_id` INTEGER NULL,                 -- user
    `ticket_id` INTEGER NULL,               -- ticket
    `tax_type_id` INTEGER NULL,             -- taxType
    `tax_percentage` decimal(20,10) NOT NULL, -- taxPercentage
    `invoice_line_id` INTEGER AUTO_INCREMENT NOT NULL, -- invoiceLineId
    `invoice_id` INTEGER NULL,              -- invoice
    `description` varchar(255) NULL,        -- description
    `amount` decimal(20,10) NOT NULL,       -- amount
    CONSTRAINT `pk_invoice_line` PRIMARY KEY (`invoice_line_id`)
) ENGINE = InnoDB;

-- AriCliModel.LabTest
CREATE TABLE `lab_test` (
    `unit_type_id` integer NULL,            -- unitType
    `nme` varchar(255) NULL,                -- name
    `min_value` decimal(20,10) NOT NULL,    -- minValue
    `max_value` decimal(20,10) NOT NULL,    -- maxValue
    `lab_test_id` integer AUTO_INCREMENT NOT NULL, -- labTestId
    `general_type` varchar(10) NULL,        -- generalType
    CONSTRAINT `pk_lab_test` PRIMARY KEY (`lab_test_id`)
) ENGINE = InnoDB;

-- AriCliModel.LabTestAssigned
CREATE TABLE `lab_test_assigned` (
    `string_value` varchar(255) NULL,       -- stringValue
    `person_id` integer NULL,               -- patient1
    `num_value` numeric(20,10) NOT NULL,    -- numValue
    `lab_test_date` datetime NOT NULL,      -- labTestDate
    `lab_test_assigned_id` integer AUTO_INCREMENT NOT NULL, -- labTestAssignedId
    `lab_test_id` integer NULL,             -- labTest
    `comments` text NULL,                   -- comments
    `visit_id` integer NULL,                -- baseVisit
    CONSTRAINT `pk_lab_test_assigned` PRIMARY KEY (`lab_test_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Log
CREATE TABLE `log` (
    `user_id` INTEGER NULL,                 -- user1
    `stamp` datetime NOT NULL,              -- stamp
    `remote_address` varchar(255) NULL,     -- remoteAddress
    `page` varchar(255) NULL,               -- page
    `log_id` INTEGER AUTO_INCREMENT NOT NULL, -- logId
    `action` varchar(255) NULL,             -- action
    CONSTRAINT `pk_lg` PRIMARY KEY (`log_id`)
) ENGINE = InnoDB;

-- AriCliModel.MotAppend
CREATE TABLE `mot_append` (
    `periocular_area` text NULL,            -- periocularArea
    `visit_id` integer NULL,                -- ophthalmologicVisit
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `eye_motility` text NULL,               -- eyeMotility
    `eyebrows` text NULL,                   -- eyebrows
    `comments` text NULL,                   -- comments
    `c9_r_e` decimal(20,10) NOT NULL,       -- c9RE
    `c9_l_e` decimal(20,10) NOT NULL,       -- c9LE
    `c8_r_e` decimal(20,10) NOT NULL,       -- c8RE
    `c8_l_e` decimal(20,10) NOT NULL,       -- c8LE
    `c7_r_e` decimal(20,10) NOT NULL,       -- c7RE
    `c7_l_e` decimal(20,10) NOT NULL,       -- c7LE
    `c6_r_e` decimal(20,10) NOT NULL,       -- c6RE
    `c6_l_e` decimal(20,10) NOT NULL,       -- c6LE
    `c5_r_e` decimal(20,10) NOT NULL,       -- c5RE
    `c5_l_e` decimal(20,10) NOT NULL,       -- c5LE
    `c4_r_e` decimal(20,10) NOT NULL,       -- c4RE
    `c4_l_e` decimal(20,10) NOT NULL,       -- c4LE
    `c3_r_e` decimal(20,10) NOT NULL,       -- c3RE
    `c3_l_e` decimal(20,10) NOT NULL,       -- c3LE
    `c2_r_e` decimal(20,10) NOT NULL,       -- c2RE
    `c2_l_e` decimal(20,10) NOT NULL,       -- c2LE
    `c1_r_e` decimal(20,10) NOT NULL,       -- c1RE
    `c1_l_e` decimal(20,10) NOT NULL,       -- c1LE
    `c12_r_e` decimal(20,10) NOT NULL,      -- c12RE
    `c12_l_e` decimal(20,10) NOT NULL,      -- c12LE
    `c11_r_e` decimal(20,10) NOT NULL,      -- c11RE
    `c11_l_e` decimal(20,10) NOT NULL,      -- c11LE
    `c10_r_e` decimal(20,10) NOT NULL,      -- c10RE
    `c10_l_e` decimal(20,10) NOT NULL,      -- c10LE
    CONSTRAINT `pk_mot_append` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.Nomenclator
CREATE TABLE `nomenclator` (
    `name` varchar(250) NULL,               -- name
    `id` INTEGER AUTO_INCREMENT NOT NULL,   -- id
    `group` INTEGER NULL,                   -- group
    CONSTRAINT `pk_nomenclator` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.OphthalmologicVisit
CREATE TABLE `ophthalmologic_visit` (
    `visit_id` integer NOT NULL,
    `diagnostic_details` varchar(255) NULL, -- OphthalmologicVisit.diagnosticDetails
    CONSTRAINT `pk_ophthalmologic_visit` PRIMARY KEY (`visit_id`)
) ENGINE = InnoDB;

-- AriCliModel.OpticalObjectiveExamination
CREATE TABLE `optical_objective_examination` (
    `examination_assigned_id` integer NULL, -- refractometry1
    `k2_right_eye` varchar(255) NULL,       -- k2RightEye
    `k2_left_eye` varchar(255) NULL,        -- k2LeftEye
    `k1_right_eye` varchar(255) NULL,       -- k1RightEye
    `k1_left_eye` varchar(255) NULL,        -- k1LeftEye
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_sphericity_right_eye` varchar(255) NULL, -- farSphericityRightEye
    `far_sphericity_left_eye` varchar(255) NULL, -- farSphericityLeftEye
    `far_prism_left_eye` varchar(255) NULL, -- farPrismLeftEye
    `far_prims_right_eye` varchar(255) NULL, -- farPrimsRightEye
    `far_cylinder_right_eye` varchar(255) NULL, -- farCylinderRightEye
    `far_cylinder_left_eye` varchar(255) NULL, -- farCylinderLeftEye
    `far_centers` varchar(255) NULL,        -- farCenters
    `far_axis_right_eye` varchar(255) NULL, -- farAxisRightEye
    `far_axis_left_eye` varchar(255) NULL,  -- farAxisLeftEye
    `far_acuity` varchar(255) NULL,         -- farAcuity
    `comments` varchar(255) NULL,           -- comments
    `close_sphericity_right_eye` varchar(255) NULL, -- closeSphericityRightEye
    `close_sphericity_left_eye` varchar(255) NULL, -- closeSphericityLeftEye
    `close_sphericity_centers` integer NOT NULL, -- closeSphericityCenters
    `close_prism_right_eye` varchar(255) NULL, -- closePrismRightEye
    `close_prism_left_eye` varchar(255) NULL, -- closePrismLeftEye
    `close_cylinder_right_eye` varchar(255) NULL, -- closeCylinderRightEye
    `close_cylinder_left_eye` varchar(255) NULL, -- closeCylinderLeftEye
    `close_centers` varchar(255) NULL,      -- closeCenters
    `close_axis_right_eye` varchar(255) NULL, -- closeAxisRightEye
    `close_axis_left_eye` varchar(255) NULL, -- closeAxisLeftEye
    `close_acuity_right_eye` varchar(255) NULL, -- closeAcuityRightEye
    `close_acuity_left_eye` varchar(255) NULL, -- closeAcuityLeftEye
    `close_acuity` varchar(255) NULL,       -- closeAcuity
    `both_sphericity_right_eye` varchar(255) NULL, -- bothSphericityRightEye
    `both_sphericity_left_eye` varchar(255) NULL, -- bothSphericityLeftEye
    `both_prism_right_eye` varchar(255) NULL, -- bothPrismRightEye
    `both_prism_left_eye` varchar(255) NULL, -- bothPrismLeftEye
    `both_cylinder_right_eye` varchar(255) NULL, -- bothCylinderRightEye
    `both_cylinder_left_eye` varchar(255) NULL, -- bothCylinderLeftEye
    `both_centers` varchar(255) NULL,       -- bothCenters
    `both_axis_right_eye` varchar(255) NULL, -- bothAxisRightEye
    `both_axis_left_eye` varchar(255) NULL, -- bothAxisLeftEye
    `both_acuity_right_eye` varchar(255) NULL, -- bothAcuityRightEye
    `both_acuity_left_eye` varchar(255) NULL, -- bothAcuityLeftEye
    `both_acuity` varchar(255) NULL,        -- bothAcuity
    CONSTRAINT `pk_optical_objective_examination` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.Paquimetry
CREATE TABLE `paquimetry` (
    `examination_assigned_id` integer NOT NULL,
    `right_eye_central_c0` numeric(20,10) NULL, -- Paquimetry.rightEyeCentralC0
    `right_eye_c7` numeric(20,10) NULL,     -- Paquimetry.rightEyeC7
    `right_eye_c5` numeric(20,10) NULL,     -- Paquimetry.rightEyeC5
    `right_eye_c3` numeric(20,10) NULL,     -- Paquimetry.rightEyeC3
    `right_eye_c1` numeric(20,10) NULL,     -- Paquimetry.rightEyeC1
    `left_eye_central_c0` numeric(20,10) NULL, -- Paquimetry.leftEyeCentralC0
    `left_eye_c7` numeric(20,10) NULL,      -- Paquimetry.leftEyeC7
    `left_eye_c5` numeric(20,10) NULL,      -- Paquimetry.leftEyeC5
    `left_eye_c3` numeric(20,10) NULL,      -- Paquimetry.leftEyeC3
    `left_eye_c1` numeric(20,10) NULL,      -- Paquimetry.leftEyeC1
    CONSTRAINT `pk_paquimetry` PRIMARY KEY (`examination_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Parameter
CREATE TABLE `parameter` (
    `use_nomenclator` bit NOT NULL,         -- useNomenclator
    `parameter_id` INTEGER NOT NULL,        -- parameterId
    `service_id` integer NULL,              -- painPump
    `appointment_extension` bit NOT NULL,   -- appointmentExtension
    CONSTRAINT `pk_parameter` PRIMARY KEY (`parameter_id`)
) ENGINE = InnoDB;

-- AriCliModel.Patient
CREATE TABLE `patient` (
    `person_id` integer NOT NULL,
    `surname2` varchar(30) NULL,            -- Patient.surname2
    `surname1` varchar(30) NULL,            -- Patient.surname1
    `sex` varchar(1) NULL,                  -- Patient.sex
    `open_date` datetime NULL,              -- Patient.openDate
    `oft_id` integer NULL,                  -- Patient.oftId
    `name` varchar(30) NULL,                -- Patient.name
    `last_update` datetime NULL,            -- Patient.lastUpdate
    `insurance_information` varchar(255) NULL, -- Patient.insuranceInformation
    `person_id2` integer NULL,              -- Patient.customer
    `comments` longtext NULL,               -- Patient.comments
    `clinic_id` INTEGER NULL,               -- Patient.clinic
    `born_date` datetime NULL,              -- Patient.bornDate
    CONSTRAINT `pk_patient` PRIMARY KEY (`person_id`)
) ENGINE = InnoDB;

-- AriCliModel.Payment
CREATE TABLE `payment` (
    `user_id` integer NULL,                 -- user
    `ticket_id` integer NULL,               -- ticket
    `payment_method_id` integer NULL,       -- paymentMethod
    `payment_id` integer AUTO_INCREMENT NOT NULL, -- paymentId
    `payment_date` datetime NOT NULL,       -- paymentDate
    `oft_id` integer NULL,                  -- oftId
    `general_payment_id` integer NULL,      -- generalPayment
    `description` varchar(50) NULL,         -- description
    `clinic_id` integer NULL,               -- clinic
    `amount` decimal(20,10) NOT NULL,       -- amount
    CONSTRAINT `pk_payment` PRIMARY KEY (`payment_id`)
) ENGINE = InnoDB;

-- AriCliModel.PaymentMethod
CREATE TABLE `payment_method` (
    `payment_method_id` INTEGER AUTO_INCREMENT NOT NULL, -- paymentMethodId
    `oft_id` INTEGER NULL,                  -- oftId
    `name` varchar(50) NULL,                -- name
    CONSTRAINT `pk_payment_method` PRIMARY KEY (`payment_method_id`)
) ENGINE = InnoDB;

-- AriCliModel.Permission
CREATE TABLE `permission` (
    `view` bit NOT NULL,                    -- view
    `user_group_id` INTEGER NULL,           -- userGroup
    `process_id` INTEGER NULL,              -- process
    `permission_id` INTEGER AUTO_INCREMENT NOT NULL, -- permissionId
    `modify` bit NOT NULL,                  -- modify
    `execute` bit NOT NULL,                 -- execute
    `create` bit NOT NULL,                  -- create
    CONSTRAINT `pk_permission` PRIMARY KEY (`permission_id`)
) ENGINE = InnoDB;

-- AriCliModel.Person
CREATE TABLE `person` (
    `source_id` integer NULL,               -- source
    `person_id` integer AUTO_INCREMENT NOT NULL, -- personId
    `full_name` varchar(100) NULL,          -- fullName
    `voa_class` varchar(255) NULL,          -- <internal-class-id>
    CONSTRAINT `pk_person` PRIMARY KEY (`person_id`)
) ENGINE = InnoDB;

-- AriCliModel.Policy
CREATE TABLE `policy` (
    `type` varchar(20) NULL,                -- type
    `policy_number` varchar(255) NULL,      -- policyNumber
    `policy_id` integer AUTO_INCREMENT NOT NULL, -- policyId
    `oft_id` integer NOT NULL,              -- oftId
    `insurance_id` integer NULL,            -- insurance1
    `end_date` datetime NOT NULL,           -- endDate
    `person_id` integer NULL,               -- customer1
    `begin_date` datetime NOT NULL,         -- beginDate
    CONSTRAINT `pk_policy` PRIMARY KEY (`policy_id`)
) ENGINE = InnoDB;

-- AriCliModel.PrescriptionGlasses
CREATE TABLE `prescription_glasses` (
    `sign_MD` varchar(255) NOT NULL,        -- signMD
    `examination_assigned_id` integer NULL, -- refractometry1
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_sphericity_right_eye` varchar(255) NULL, -- farSphericityRightEye
    `far_sphericity_left_eye` varchar(255) NULL, -- farSphericityLeftEye
    `far_prism_left_eye` varchar(255) NULL, -- farPrismLeftEye
    `far_prims_right_eye` varchar(255) NULL, -- farPrimsRightEye
    `far_cylinder_right_eye` varchar(255) NULL, -- farCylinderRightEye
    `far_cylinder_left_eye` varchar(255) NULL, -- farCylinderLeftEye
    `far_centers` varchar(255) NULL,        -- farCenters
    `far_axis_right_eye` varchar(255) NULL, -- farAxisRightEye
    `far_axis_left_eye` varchar(255) NULL,  -- farAxisLeftEye
    `far_acuity` varchar(255) NULL,         -- farAcuity
    `comments` varchar(255) NULL,           -- comments
    `close_sphericity_right_eye` varchar(255) NULL, -- closeSphericityRightEye
    `close_sphericity_left_eye` varchar(255) NULL, -- closeSphericityLeftEye
    `close_sphericity_centers` integer NOT NULL, -- closeSphericityCenters
    `close_prism_right_eye` varchar(255) NULL, -- closePrismRightEye
    `close_prism_left_eye` varchar(255) NULL, -- closePrismLeftEye
    `close_cylinder_right_eye` varchar(255) NULL, -- closeCylinderRightEye
    `close_cylinder_left_eye` varchar(255) NULL, -- closeCylinderLeftEye
    `close_centers` varchar(255) NULL,      -- closeCenters
    `close_axis_right_eye` varchar(255) NULL, -- closeAxisRightEye
    `close_axis_left_eye` varchar(255) NULL, -- closeAxisLeftEye
    `close_acuity_right_eye` varchar(255) NULL, -- closeAcuityRightEye
    `close_acuity_left_eye` varchar(255) NULL, -- closeAcuityLeftEye
    `close_acuity` varchar(255) NULL,       -- closeAcuity
    `both_sphericity_right_eye` varchar(255) NULL, -- bothSphericityRightEye
    `both_sphericity_left_eye` varchar(255) NULL, -- bothSphericityLeftEye
    `both_prism_right_eye` varchar(255) NULL, -- bothPrismRightEye
    `both_prism_left_eye` varchar(255) NULL, -- bothPrismLeftEye
    `both_cylinder_right_eye` varchar(255) NULL, -- bothCylinderRightEye
    `both_cylinder_left_eye` varchar(255) NULL, -- bothCylinderLeftEye
    `both_centers` varchar(255) NULL,       -- bothCenters
    `both_axis_right_eye` varchar(255) NULL, -- bothAxisRightEye
    `both_axis_left_eye` varchar(255) NULL, -- bothAxisLeftEye
    `both_acuity_right_eye` varchar(255) NULL, -- bothAcuityRightEye
    `both_acuity_left_eye` varchar(255) NULL, -- bothAcuityLeftEye
    `both_acuity` varchar(255) NULL,        -- bothAcuity
    CONSTRAINT `pk_prescription_glasses` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.PreviousMedicalRecord
CREATE TABLE `previous_medical_record` (
    `previous_medical_record_id` integer AUTO_INCREMENT NOT NULL, -- previousMedicalRecordId
    `person_id` integer NULL,               -- patient
    `content` longtext NULL,                -- content
    CONSTRAINT `pk_previous_medical_record` PRIMARY KEY (`previous_medical_record_id`)
) ENGINE = InnoDB;

-- AriCliModel.Procedure
CREATE TABLE `procedure` (
    `service_id` integer NULL,              -- service
    `procedure_id` integer AUTO_INCREMENT NOT NULL, -- procedureId
    `oft_id` integer NOT NULL,              -- oftId
    `name` varchar(250) NULL,               -- name
    CONSTRAINT `pk_prcedure` PRIMARY KEY (`procedure_id`)
) ENGINE = InnoDB;

-- AriCliModel.ProcedureAssigned
CREATE TABLE `procedure_assigned` (
    `procedure_date` datetime NOT NULL,     -- procedureDate
    `procedure_assigned_id` integer AUTO_INCREMENT NOT NULL, -- procedureAssignedId
    `procedure_id` integer NULL,            -- procedure
    `person_id` integer NULL,               -- patient
    `comments` text NULL,                   -- comments
    `visit_id` integer NULL,                -- baseVisit
    CONSTRAINT `pk_procedure_assigned` PRIMARY KEY (`procedure_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Process
CREATE TABLE `process` (
    `process_id` integer AUTO_INCREMENT NOT NULL, -- processId
    `parent_process_id` integer NULL,       -- parentProcess
    `name` varchar(50) NULL,                -- name
    `description` longtext NULL,            -- description
    `code` varchar(50) NULL,                -- code
    CONSTRAINT `pk_process` PRIMARY KEY (`process_id`)
) ENGINE = InnoDB;

-- AriCliModel.Professional
CREATE TABLE `professional` (
    `person_id` integer NOT NULL,
    `vatin` varchar(255) NULL,              -- Professional.vATIN
    `user_id` integer NULL,                 -- Professional.user
    `type` varchar(255) NULL,               -- Professional.type
    `tax_withholding_type_id` integer NULL, -- Professional.taxWithholdingType
    `oft_id` integer NULL,                  -- Professional.oftId
    `license` varchar(255) NULL,            -- Professional.license
    `invoice_serial` varchar(255) NULL,     -- Professional.invoiceSerial
    `inactive` bit NULL,                    -- Professional.inactive
    `commission` decimal(20,10) NULL,       -- Professional.commission
    `comercial_name` varchar(255) NULL,     -- Professional.comercialName
    CONSTRAINT `pk_professional` PRIMARY KEY (`person_id`)
) ENGINE = InnoDB;

-- AriCliModel.ProfessionalInvoice
CREATE TABLE `professional_invoice` (
    `year` integer NOT NULL,                -- year
    `tax_whith_holding_percentage` decimal(20,10) NOT NULL, -- taxWithHoldingPercentage
    `serial` varchar NOT NULL,              -- serial
    `person_id` integer NULL,               -- professional
    `invoice_number` integer NOT NULL,      -- invoiceNumber
    `invoice_key` varchar(255) NULL,        -- invoiceKey
    `invoice_id` integer AUTO_INCREMENT NOT NULL, -- invoiceId
    `invoice_date` datetime NOT NULL,       -- invoiceDate
    `total` decimal(20,10) NOT NULL,        -- amount
    CONSTRAINT `pk_professional_invoice` PRIMARY KEY (`invoice_id`)
) ENGINE = InnoDB;

-- AriCliModel.ProfessionalInvoiceLine
CREATE TABLE `professional_invoice_line` (
    `ticket_id` integer NULL,               -- ticket
    `taxtype_id` integer NOT NULL,          -- taxType
    `tax_percentage` decimal(20,10) NOT NULL, -- taxPercentage
    `invoice_id` integer NULL,              -- professionalInvoice
    `invoice_line_id` integer AUTO_INCREMENT NOT NULL, -- invoiceLineId
    `description` varchar(255) NULL,        -- description
    `amount` decimal(20,10) NOT NULL,       -- amount
    CONSTRAINT `pk_professional_invoice_line` PRIMARY KEY (`invoice_line_id`)
) ENGINE = InnoDB;

-- AriCliModel.Refractometry
CREATE TABLE `refractometry` (
    `examination_assigned_id` integer NOT NULL,
    CONSTRAINT `pk_refractometry` PRIMARY KEY (`examination_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Service
CREATE TABLE `service` (
    `tax_type_id` integer NULL,             -- taxType
    `service_id` integer AUTO_INCREMENT NOT NULL, -- serviceId
    `service_category_id` integer NULL,     -- serviceCategory
    `oft_id` integer NULL,                  -- oftId
    `name` varchar(250) NULL,               -- name
    CONSTRAINT `pk_service` PRIMARY KEY (`service_id`)
) ENGINE = InnoDB;

-- AriCliModel.ServiceCategory
CREATE TABLE `service_category` (
    `service_category_id` integer AUTO_INCREMENT NOT NULL, -- serviceCategoryId
    `oft_id` integer NULL,                  -- oftId
    `name` varchar(50) NULL,                -- name
    CONSTRAINT `pk_service_category` PRIMARY KEY (`service_category_id`)
) ENGINE = InnoDB;

-- AriCliModel.ServiceNote
CREATE TABLE `service_note` (
    `user_id` integer NULL,                 -- user
    `ttal` decimal(20,10) NULL,             -- total
    `service_note_id` integer AUTO_INCREMENT NOT NULL, -- serviceNoteId
    `service_note_date` datetime NULL,      -- serviceNoteDate
    `invoice_id` integer NULL,              -- professionalInvoice
    `person_id` integer NULL,               -- professional
    `paid` decimal(20,10) NOT NULL,         -- paid
    `oft_num_nota` integer NOT NULL,        -- oftNumNota
    `oft_ano` integer NOT NULL,             -- oftAno
    `invoice_id2` integer NULL,             -- invoice
    `person_id2` integer NULL,              -- customer
    `clinic_id` INTEGER NULL,               -- clinic
    CONSTRAINT `pk_service_note` PRIMARY KEY (`service_note_id`)
) ENGINE = InnoDB;

-- AriCliModel.Source
CREATE TABLE `source` (
    `source_id` integer AUTO_INCREMENT NOT NULL, -- sourceId
    `oft_id` integer NOT NULL,              -- oftId
    `nme` varchar(255) NULL,                -- name
    CONSTRAINT `pk_source` PRIMARY KEY (`source_id`)
) ENGINE = InnoDB;

-- AriCliModel.SubjectiveOpticalExamination
CREATE TABLE `subjective_optical_examination` (
    `examination_assigned_id` integer NULL, -- refractometry1
    `id` integer AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_sphericity_right_eye` varchar(255) NULL, -- farSphericityRightEye
    `far_sphericity_left_eye` varchar(255) NULL, -- farSphericityLeftEye
    `far_prism_left_eye` varchar(255) NULL, -- farPrismLeftEye
    `far_prims_right_eye` varchar(255) NULL, -- farPrimsRightEye
    `far_cylinder_right_eye` varchar(255) NULL, -- farCylinderRightEye
    `far_cylinder_left_eye` varchar(255) NULL, -- farCylinderLeftEye
    `far_centers` varchar(255) NULL,        -- farCenters
    `far_axis_right_eye` varchar(255) NULL, -- farAxisRightEye
    `far_axis_left_eye` varchar(255) NULL,  -- farAxisLeftEye
    `far_acuity` varchar(255) NULL,         -- farAcuity
    `comments` varchar(255) NULL,           -- comments
    `close_sphericity_right_eye` varchar(255) NULL, -- closeSphericityRightEye
    `close_sphericity_left_eye` varchar(255) NULL, -- closeSphericityLeftEye
    `close_sphericity_centers` integer NOT NULL, -- closeSphericityCenters
    `close_prism_right_eye` varchar(255) NULL, -- closePrismRightEye
    `close_prism_left_eye` varchar(255) NULL, -- closePrismLeftEye
    `close_cylinder_right_eye` varchar(255) NULL, -- closeCylinderRightEye
    `close_cylinder_left_eye` varchar(255) NULL, -- closeCylinderLeftEye
    `close_centers` varchar(255) NULL,      -- closeCenters
    `close_axis_right_eye` varchar(255) NULL, -- closeAxisRightEye
    `close_axis_left_eye` varchar(255) NULL, -- closeAxisLeftEye
    `close_acuity_right_eye` varchar(255) NULL, -- closeAcuityRightEye
    `close_acuity_left_eye` varchar(255) NULL, -- closeAcuityLeftEye
    `close_acuity` varchar(255) NULL,       -- closeAcuity
    `both_sphericity_right_eye` varchar(255) NULL, -- bothSphericityRightEye
    `both_sphericity_left_eye` varchar(255) NULL, -- bothSphericityLeftEye
    `both_prism_right_eye` varchar(255) NULL, -- bothPrismRightEye
    `both_prism_left_eye` varchar(255) NULL, -- bothPrismLeftEye
    `both_cylinder_right_eye` varchar(255) NULL, -- bothCylinderRightEye
    `both_cylinder_left_eye` varchar(255) NULL, -- bothCylinderLeftEye
    `both_centers` varchar(255) NULL,       -- bothCenters
    `both_axis_right_eye` varchar(255) NULL, -- bothAxisRightEye
    `both_axis_left_eye` varchar(255) NULL, -- bothAxisLeftEye
    `both_acuity_right_eye` varchar(255) NULL, -- bothAcuityRightEye
    `both_acuity_left_eye` varchar(255) NULL, -- bothAcuityLeftEye
    `both_acuity` varchar(255) NULL,        -- bothAcuity
    CONSTRAINT `pk_subjective_optical_examination` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

-- AriCliModel.TaxType
CREATE TABLE `tax_type` (
    `tax_type_id` integer AUTO_INCREMENT NOT NULL, -- taxTypeId
    `percentage` decimal(5,2) NOT NULL,     -- percentage
    `oft_id` integer NULL,                  -- oftId
    `name` varchar(50) NULL,                -- name
    CONSTRAINT `pk_tax_type` PRIMARY KEY (`tax_type_id`)
) ENGINE = InnoDB;

-- AriCliModel.TaxWithholdingType
CREATE TABLE `tax_withholding_type` (
    `tax_withholding_type_id` integer AUTO_INCREMENT NOT NULL, -- taxWithholdingTypeId
    `percentage` decimal(5,2) NOT NULL,     -- percentage
    `name` varchar(30) NULL,                -- name
    CONSTRAINT `pk_tax_withholding_type` PRIMARY KEY (`tax_withholding_type_id`)
) ENGINE = InnoDB;

-- AriCliModel.Telephone
CREATE TABLE `telephone` (
    `type` varchar(10) NULL,                -- type
    `telephone_id` integer AUTO_INCREMENT NOT NULL, -- telephoneId
    `person_id` integer NULL,               -- person
    `number` varchar(20) NULL,              -- number
    `hc_id` integer NULL,                   -- healthcareCompany1
    `clinic_id` integer NULL,               -- clinic
    CONSTRAINT `pk_telephone` PRIMARY KEY (`telephone_id`)
) ENGINE = InnoDB;

-- AriCliModel.Template
CREATE TABLE `template` (
    `template_id` integer AUTO_INCREMENT NOT NULL, -- templateId
    `nme` varchar(255) NULL,                -- name
    `content` text NULL,                    -- content
    CONSTRAINT `pk_template` PRIMARY KEY (`template_id`)
) ENGINE = InnoDB;

-- AriCliModel.Ticket
CREATE TABLE `ticket` (
    `user_id` integer NULL,                 -- user1
    `ticket_id` integer AUTO_INCREMENT NOT NULL, -- ticketId
    `ticket_date` datetime NULL,            -- ticketDate
    `service_note_id` integer NULL,         -- serviceNote
    `person_id` integer NULL,               -- professional1
    `policy_id` integer NULL,               -- policy1
    `paid` decimal(20,10) NULL,             -- paid
    `insurance_service_id` integer NULL,    -- insuranceService
    `description` varchar(255) NULL,        -- description
    `comments` varchar(255) NULL,           -- comments
    `clinic_id` integer NULL,               -- clinic
    `checked` bit NULL,                     -- _checked
    `amount` decimal(20,10) NULL,           -- amount
    `voa_class` varchar(255) NULL,          -- <internal-class-id>
    CONSTRAINT `pk_ticket` PRIMARY KEY (`ticket_id`)
) ENGINE = InnoDB;

-- AriCliModel.Topography
CREATE TABLE `topography` (
    `examination_assigned_id` integer NOT NULL,
    `right_eye_k2` numeric(20,10) NULL,     -- Topography.rightEyeK2
    `right_eye_k1` numeric(20,10) NULL,     -- Topography.rightEyeK1
    `right_eye_axis` numeric(20,10) NULL,   -- Topography.rightEyeAxis
    `right_eye_astig` numeric(20,10) NULL,  -- Topography.rightEyeAstig
    `left_eye_k2` numeric(20,10) NULL,      -- Topography.leftEyeK2
    `left_eye_k1` numeric(20,10) NULL,      -- Topography.leftEyeK1
    `left_eye_axis` numeric(20,10) NULL,    -- Topography.leftEyeAxis
    `left_eye_astig` numeric(20,10) NULL,   -- Topography.leftEyeAstig
    CONSTRAINT `pk_topography` PRIMARY KEY (`examination_assigned_id`)
) ENGINE = InnoDB;

-- AriCliModel.Treatment
CREATE TABLE `treatment` (
    `treatment_id` integer AUTO_INCREMENT NOT NULL, -- treatmentId
    `treatment_date` datetime NOT NULL,     -- treatmentDate
    `recommend` varchar(255) NULL,          -- recommend
    `quantity` decimal(20,10) NOT NULL,     -- quantity
    `person_id` integer NULL,               -- patient1
    `drug_id` integer NULL,                 -- drug
    `visit_id` integer NULL,                -- baseVisit
    CONSTRAINT `pk_treatment` PRIMARY KEY (`treatment_id`)
) ENGINE = InnoDB;

-- AriCliModel.UnitType
CREATE TABLE `unit_type` (
    `unit_type_id` integer AUTO_INCREMENT NOT NULL, -- unitTypeId
    `name` varchar(50) NULL,                -- name
    CONSTRAINT `pk_unit_type` PRIMARY KEY (`unit_type_id`)
) ENGINE = InnoDB;

-- AriCliModel.User
CREATE TABLE `user` (
    `user_id` integer AUTO_INCREMENT NOT NULL, -- userId
    `user_group_id` integer NULL,           -- userGroup
    `profile` integer NOT NULL,             -- profile
    `password` varchar(30) NOT NULL,        -- password
    `name` varchar(50) NOT NULL,            -- name
    `login` varchar(30) NOT NULL,           -- login
    `code` varchar(255) NULL,               -- baseVisitType
    CONSTRAINT `pk_usr` PRIMARY KEY (`user_id`)
) ENGINE = InnoDB;

-- AriCliModel.UserGroup
CREATE TABLE `user_group` (
    `user_group_id` integer AUTO_INCREMENT NOT NULL, -- userGroupId
    `name` varchar(50) NULL,                -- name
    CONSTRAINT `pk_user_group` PRIMARY KEY (`user_group_id`)
) ENGINE = InnoDB;

-- AriCliModel.VisitReason
CREATE TABLE `visit_reason` (
    `visit_reason_id` integer AUTO_INCREMENT NOT NULL, -- visitReasonId
    `oft_id` integer NOT NULL,              -- oftId
    `nme` varchar(50) NULL,                 -- name
    CONSTRAINT `pk_visit_reason` PRIMARY KEY (`visit_reason_id`)
) ENGINE = InnoDB;

-- AriCliModel.WithoutGlassesTest
CREATE TABLE `without_glasses_test` (
    `examination_assigned_id` integer NULL, -- refractometry1
    `id` INTEGER AUTO_INCREMENT NOT NULL,   -- id
    `far_visual_acuity_right_eye` varchar(255) NULL, -- farVisualAcuityRightEye
    `far_visual_acuity_left_eye` varchar(255) NULL, -- farVisualAcuityLeftEye
    `far_visual_acuity_both_eyes` varchar(255) NULL, -- farVisualAcuityBothEyes
    `comments` varchar(255) NULL,           -- comments
    `close_visual_acuity_right_eye` varchar(255) NULL, -- closeVisualAcuityRightEye
    `close_visual_acuity_left_eye` varchar(255) NULL, -- closeVisualAcuityLeftEye
    `close_visual_acuity_both_eyes` varchar(255) NULL, -- closeVisualAcuityBothEyes
    CONSTRAINT `pk_without_glasses_test` PRIMARY KEY (`id`)
) ENGINE = InnoDB;

ALTER TABLE `address` ADD INDEX `idx_address_hc_id`(`hc_id`);

ALTER TABLE `address` ADD INDEX `idx_address_clinic_id`(`clinic_id`);

ALTER TABLE `address` ADD INDEX `idx_address_person_id`(`person_id`);

ALTER TABLE `anesthetic_service_note` ADD INDEX `idx_anesthetic_service_note_user_id`(`user_id`);

ALTER TABLE `anesthetic_service_note` ADD INDEX `idx_anesthetic_service_note_surgeon_person_id`(`surgeon_person_id`);

ALTER TABLE `anesthetic_service_note` ADD INDEX `idx_anesthetic_service_note_professional_person_id`(`professional_person_id`);

ALTER TABLE `anesthetic_service_note` ADD INDEX `idx_anesthetic_service_note_customer_id`(`customer_person_id`);

ALTER TABLE `anesthetic_service_note` ADD INDEX `idx_anesthetic_service_note_clinic_id`(`clinic_id`);

ALTER TABLE `anesthetic_service_note` ADD INDEX `idx_anesthetic_service_note_invoice_id`(`invoice_id`);

ALTER TABLE `anesthetic_service_note_procedures` ADD INDEX `idx_anesthetic_service_note_procedures_procedure_id`(`procedure_id`);

ALTER TABLE `anesthetic_ticket` ADD INDEX `idx_anesthetic_ticket_anesthetic_service_note_id`(`anesthetic_service_note_id`);

ALTER TABLE `anesthetic_ticket` ADD INDEX `idx_anesthetic_ticket_procedure_id`(`procedure_id`);

ALTER TABLE `anesthetic_ticket` ADD INDEX `idx_anesthetic_ticket_person_id2`(`person_id`);

ALTER TABLE `ant_segment` ADD INDEX `idx_ant_segment_visit_id`(`visit_id`);

ALTER TABLE `appointment` ADD INDEX `idx_appointment_info_user_id`(`user_id`);

ALTER TABLE `appointment` ADD INDEX `idx_appointment_info_person_id2`(`person_id2`);

ALTER TABLE `appointment` ADD INDEX `idx_appointment_info_person_id`(`person_id`);

ALTER TABLE `appointment` ADD INDEX `idx_appointment_info_father_appointment_appointment_id`(`father_appointment_appointment_id`);

ALTER TABLE `appointment` ADD INDEX `idx_appointment_info_diary_id`(`diary_id`);

ALTER TABLE `appointment` ADD INDEX `idx_appointment_info_appointment_type_id`(`appointment_type_id`);

ALTER TABLE `back_family` ADD INDEX `idx_back_family_person_id`(`person_id`);

ALTER TABLE `back_ginecoloy` ADD INDEX `idx_back_ginecoloy_person_id`(`person_id`);

ALTER TABLE `back_personal` ADD INDEX `idx_back_personal_person_id`(`person_id`);

ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_visit_reason_id`(`visit_reason_id`);

ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_person_id2`(`person_id2`);

ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_person_id`(`person_id`);

ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_appointment_id`(`appointment_id`);

ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_appointment_type_id`(`appointment_type_id`);

ALTER TABLE `base_visit` ADD INDEX `idx_base_visit_code`(`code`);

ALTER TABLE `contact_lenses_test` ADD INDEX `idx_contact_lenses_test_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `cycloplegia` ADD INDEX `idx_cycloplegia_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `diagnostic_assigned` ADD INDEX `idx_diagnostic_assigned_person_id`(`person_id`);

ALTER TABLE `diagnostic_assigned` ADD INDEX `idx_diagnostic_assigned_diagnostic_id`(`diagnostic_id`);

ALTER TABLE `diagnostic_assigned` ADD INDEX `idx_diagnostic_assigned_visit_id`(`visit_id`);

ALTER TABLE `email` ADD INDEX `idx_email_hc_id`(`hc_id`);

ALTER TABLE `email` ADD INDEX `idx_email_clinic_id`(`clinic_id`);

ALTER TABLE `email` ADD INDEX `idx_email_person_id`(`person_id`);

ALTER TABLE `examination_assigned` ADD INDEX `idx_examination_assigned_person_id`(`person_id`);

ALTER TABLE `examination_assigned` ADD INDEX `idx_examination_assigned_visit_id`(`visit_id`);

ALTER TABLE `fundus` ADD INDEX `idx_fundus_visit_id`(`visit_id`);

ALTER TABLE `general_payment` ADD INDEX `idx_general_payment_clinic_id`(`clinic_id`);

ALTER TABLE `general_payment` ADD INDEX `idx_general_payment_payment_method_id`(`payment_method_id`);

ALTER TABLE `general_payment` ADD INDEX `idx_general_payment_service_note_id`(`service_note_id`);

ALTER TABLE `glasses_test` ADD INDEX `idx_glasses_test_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `insurance_service` ADD INDEX `idx_insurance_service_insurance_id`(`insurance_id`);

ALTER TABLE `insurance_service` ADD INDEX `idx_insurance_service_service_id`(`service_id`);

ALTER TABLE `invoice` ADD INDEX `idx_invoice_customer_id`(`customer_id`);

ALTER TABLE `invoice_line` ADD INDEX `idx_invoice_line_ticket_id`(`ticket_id`);

ALTER TABLE `invoice_line` ADD INDEX `idx_invoice_line_invoice_id`(`invoice_id`);

ALTER TABLE `invoice_line` ADD INDEX `idx_invoice_line_tax_type_id`(`tax_type_id`);

ALTER TABLE `invoice_line` ADD INDEX `idx_invoice_line_user_id`(`user_id`);

ALTER TABLE `lab_test` ADD INDEX `idx_lab_test_unit_type_id`(`unit_type_id`);

ALTER TABLE `lab_test_assigned` ADD INDEX `idx_lab_test_assigned_lab_test_id`(`lab_test_id`);

ALTER TABLE `lab_test_assigned` ADD INDEX `idx_lab_test_assigned_visit_id`(`visit_id`);

ALTER TABLE `lab_test_assigned` ADD INDEX `idx_lab_test_assigned_person_id`(`person_id`);

ALTER TABLE `log` ADD INDEX `idx_log_user_id`(`user_id`);

ALTER TABLE `mot_append` ADD INDEX `idx_mot_append_visit_id`(`visit_id`);

ALTER TABLE `optical_objective_examination` ADD INDEX `idx_optical_objective_examination_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `parameter` ADD INDEX `idx_parameter_service_id`(`service_id`);

ALTER TABLE `patient` ADD INDEX `idx_patient_clinic_id`(`clinic_id`);

ALTER TABLE `patient` ADD INDEX `idx_patient_person_id2`(`person_id2`);

ALTER TABLE `payment` ADD INDEX `idx_payment_user_id`(`user_id`);

ALTER TABLE `payment` ADD INDEX `idx_payment_ticket_id`(`ticket_id`);

ALTER TABLE `payment` ADD INDEX `idx_payment_payment_method_id`(`payment_method_id`);

ALTER TABLE `payment` ADD INDEX `idx_payment_clinic_id`(`clinic_id`);

ALTER TABLE `payment` ADD INDEX `idx_payment_general_payment_id`(`general_payment_id`);

ALTER TABLE `permission` ADD INDEX `idx_permission_user_group_id`(`user_group_id`);

ALTER TABLE `permission` ADD INDEX `idx_permission_process_id`(`process_id`);

ALTER TABLE `person` ADD INDEX `idx_person_source_id`(`source_id`);

ALTER TABLE `policy` ADD INDEX `idx_policy_person_id`(`person_id`);

ALTER TABLE `policy` ADD INDEX `idx_policy_insurance_id`(`insurance_id`);

ALTER TABLE `prescription_glasses` ADD INDEX `idx_prescription_glasses_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `previous_medical_record` ADD INDEX `idx_previous_medical_record_person_id`(`person_id`);

ALTER TABLE `procedure` ADD INDEX `idx_procedure_service_id`(`service_id`);

ALTER TABLE `procedure_assigned` ADD INDEX `idx_procedure_assigned_procedure_id`(`procedure_id`);

ALTER TABLE `procedure_assigned` ADD INDEX `idx_procedure_assigned_person_id`(`person_id`);

ALTER TABLE `procedure_assigned` ADD INDEX `idx_procedure_assigned_visit_id`(`visit_id`);

ALTER TABLE `process` ADD INDEX `idx_process_parent_process_id`(`parent_process_id`);

ALTER TABLE `professional` ADD INDEX `idx_professional_user_id`(`user_id`);

ALTER TABLE `professional` ADD INDEX `idx_professional_tax_withholding_type_id`(`tax_withholding_type_id`);

ALTER TABLE `professional_invoice` ADD INDEX `idx_professional_invoice_person_id`(`person_id`);

ALTER TABLE `professional_invoice_line` ADD INDEX `idx_professional_invoice_line_ticket_id`(`ticket_id`);

ALTER TABLE `professional_invoice_line` ADD INDEX `idx_professional_invoice_line_invoice_id`(`invoice_id`);

ALTER TABLE `professional_invoice_line` ADD INDEX `idx_professional_invoice_line_taxtype_id`(`taxtype_id`);

ALTER TABLE `service` ADD INDEX `idx_service_service_category_id`(`service_category_id`);

ALTER TABLE `service` ADD INDEX `idx_service_tax_type_id`(`tax_type_id`);

ALTER TABLE `service_note` ADD INDEX `idx_service_note_user_id`(`user_id`);

ALTER TABLE `service_note` ADD INDEX `idx_service_note_person_id2`(`person_id2`);

ALTER TABLE `service_note` ADD INDEX `idx_service_note_person_id`(`person_id`);

ALTER TABLE `service_note` ADD INDEX `idx_service_note_invoice_id2`(`invoice_id2`);

ALTER TABLE `service_note` ADD INDEX `idx_service_note_invoice_id`(`invoice_id`);

ALTER TABLE `service_note` ADD INDEX `idx_service_note_clinic_id`(`clinic_id`);

ALTER TABLE `subjective_optical_examination` ADD INDEX `idx_subjective_optical_examination_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `telephone` ADD INDEX `idx_telephone_hc_id`(`hc_id`);

ALTER TABLE `telephone` ADD INDEX `idx_telephone_clinic_id`(`clinic_id`);

ALTER TABLE `telephone` ADD INDEX `idx_telephone_person_id`(`person_id`);

ALTER TABLE `ticket` ADD INDEX `idx_ticket_user_id`(`user_id`);

ALTER TABLE `ticket` ADD INDEX `idx_ticket_service_note_id`(`service_note_id`);

ALTER TABLE `ticket` ADD INDEX `idx_ticket_policy_id`(`policy_id`);

ALTER TABLE `ticket` ADD INDEX `idx_ticket_person_id`(`person_id`);

ALTER TABLE `ticket` ADD INDEX `idx_ticket_insurance_service_id`(`insurance_service_id`);

ALTER TABLE `ticket` ADD INDEX `idx_ticket_clinic_id`(`clinic_id`);

ALTER TABLE `treatment` ADD INDEX `idx_treatment_person_id`(`person_id`);

ALTER TABLE `treatment` ADD INDEX `idx_treatment_visit_id`(`visit_id`);

ALTER TABLE `user` ADD INDEX `idx_user_code`(`code`);

ALTER TABLE `user` ADD INDEX `idx_user_user_group_id`(`user_group_id`);

ALTER TABLE `without_glasses_test` ADD INDEX `idx_without_glasses_test_examination_assigned_id`(`examination_assigned_id`);

ALTER TABLE `address` ADD CONSTRAINT `ref_address_clinic` FOREIGN KEY `ref_address_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `address` ADD CONSTRAINT `ref_address_healthcare_company` FOREIGN KEY `ref_address_healthcare_company` (`hc_id`) REFERENCES `healthcare_company` (`hc_id`);

ALTER TABLE `address` ADD CONSTRAINT `ref_address_person` FOREIGN KEY `ref_address_person` (`person_id`) REFERENCES `person` (`person_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_clinic` FOREIGN KEY `ref_anesthetic_service_note_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_customer` FOREIGN KEY `ref_anesthetic_service_note_customer` (`customer_person_id`) REFERENCES `customer` (`person_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_invoice` FOREIGN KEY `ref_anesthetic_service_note_invoice` (`invoice_id`) REFERENCES `invoice` (`invoice_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_professional` FOREIGN KEY `ref_anesthetic_service_note_professional` (`professional_person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_professional2` FOREIGN KEY `ref_anesthetic_service_note_professional2` (`surgeon_person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_professional_invoice` FOREIGN KEY `ref_anesthetic_service_note_professional_invoice` (`invoice_id`) REFERENCES `professional_invoice` (`invoice_id`);

ALTER TABLE `anesthetic_service_note` ADD CONSTRAINT `ref_anesthetic_service_note_user` FOREIGN KEY `ref_anesthetic_service_note_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `anesthetic_service_note_procedures` ADD CONSTRAINT `ref_anesthetic_service_note_procedures_anesthetic_service_note` FOREIGN KEY `ref_anesthetic_service_note_procedures_anesthetic_service_note` (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`);

ALTER TABLE `anesthetic_service_note_procedures` ADD CONSTRAINT `ref_anesthetic_service_note_procedures_procedure` FOREIGN KEY `ref_anesthetic_service_note_procedures_procedure` (`procedure_id`) REFERENCES `procedure` (`procedure_id`);

ALTER TABLE `anesthetic_ticket` ADD CONSTRAINT `ref_anesthetic_ticket_ticket` FOREIGN KEY `ref_anesthetic_ticket_ticket` (`ticket_id`) REFERENCES `ticket` (`ticket_id`);

ALTER TABLE `anesthetic_ticket` ADD CONSTRAINT `ref_anesthetic_ticket_anesthetic_service_note` FOREIGN KEY `ref_anesthetic_ticket_anesthetic_service_note` (`anesthetic_service_note_id`) REFERENCES `anesthetic_service_note` (`anesthetic_service_note_id`);

ALTER TABLE `anesthetic_ticket` ADD CONSTRAINT `ref_anesthetic_ticket_procedure` FOREIGN KEY `ref_anesthetic_ticket_procedure` (`procedure_id`) REFERENCES `procedure` (`procedure_id`);

ALTER TABLE `anesthetic_ticket` ADD CONSTRAINT `ref_anesthetic_ticket_professional` FOREIGN KEY `ref_anesthetic_ticket_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `ant_segment` ADD CONSTRAINT `ref_ant_segment_ophthalmologic_visit` FOREIGN KEY `ref_ant_segment_ophthalmologic_visit` (`visit_id`) REFERENCES `ophthalmologic_visit` (`visit_id`);

ALTER TABLE `appointment` ADD CONSTRAINT `ref_appointment_appointment_type` FOREIGN KEY `ref_appointment_appointment_type` (`appointment_type_id`) REFERENCES `appointment_type` (`appointment_type_id`);

ALTER TABLE `appointment` ADD CONSTRAINT `ref_appointment_diary` FOREIGN KEY `ref_appointment_diary` (`diary_id`) REFERENCES `diary` (`diary_id`);

ALTER TABLE `appointment` ADD CONSTRAINT `ref_appointment_patient` FOREIGN KEY `ref_appointment_patient` (`person_id2`) REFERENCES `patient` (`person_id`);

ALTER TABLE `appointment` ADD CONSTRAINT `ref_appointment_professional` FOREIGN KEY `ref_appointment_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `appointment` ADD CONSTRAINT `ref_appointment_user` FOREIGN KEY `ref_appointment_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `back_family` ADD CONSTRAINT `ref_back_family_patient` FOREIGN KEY `ref_back_family_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `back_ginecoloy` ADD CONSTRAINT `ref_back_ginecoloy_patient` FOREIGN KEY `ref_back_ginecoloy_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `back_personal` ADD CONSTRAINT `ref_back_personal_patient` FOREIGN KEY `ref_back_personal_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_appointment` FOREIGN KEY `ref_base_visit_appointment` (`appointment_id`) REFERENCES `appointment` (`appointment_id`);

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_appointment_type` FOREIGN KEY `ref_base_visit_appointment_type` (`appointment_type_id`) REFERENCES `appointment_type` (`appointment_type_id`);

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_base_visit_type` FOREIGN KEY `ref_base_visit_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`);

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_patient` FOREIGN KEY `ref_base_visit_patient` (`person_id2`) REFERENCES `patient` (`person_id`);

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_professional` FOREIGN KEY `ref_base_visit_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `base_visit` ADD CONSTRAINT `ref_base_visit_visit_reason` FOREIGN KEY `ref_base_visit_visit_reason` (`visit_reason_id`) REFERENCES `visit_reason` (`visit_reason_id`);

ALTER TABLE `biometry` ADD CONSTRAINT `ref_biometry_examination_assigned` FOREIGN KEY `ref_biometry_examination_assigned` (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`);

ALTER TABLE `contact_lenses_test` ADD CONSTRAINT `ref_contact_lenses_test_refractometry` FOREIGN KEY `ref_contact_lenses_test_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

ALTER TABLE `customer` ADD CONSTRAINT `ref_customer_person` FOREIGN KEY `ref_customer_person` (`person_id`) REFERENCES `person` (`person_id`);

ALTER TABLE `cycloplegia` ADD CONSTRAINT `ref_cycloplegia_refractometry` FOREIGN KEY `ref_cycloplegia_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

ALTER TABLE `diagnostic_assigned` ADD CONSTRAINT `ref_diagnostic_assigned_base_visit` FOREIGN KEY `ref_diagnostic_assigned_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`);

ALTER TABLE `diagnostic_assigned` ADD CONSTRAINT `ref_diagnostic_assigned_diagnostic` FOREIGN KEY `ref_diagnostic_assigned_diagnostic` (`diagnostic_id`) REFERENCES `diagnostic` (`diagnostic_id`);

ALTER TABLE `diagnostic_assigned` ADD CONSTRAINT `ref_diagnostic_assigned_patient` FOREIGN KEY `ref_diagnostic_assigned_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `email` ADD CONSTRAINT `ref_email_clinic` FOREIGN KEY `ref_email_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `email` ADD CONSTRAINT `ref_email_healthcare_company` FOREIGN KEY `ref_email_healthcare_company` (`hc_id`) REFERENCES `healthcare_company` (`hc_id`);

ALTER TABLE `email` ADD CONSTRAINT `ref_email_person` FOREIGN KEY `ref_email_person` (`person_id`) REFERENCES `person` (`person_id`);

ALTER TABLE `examination` ADD CONSTRAINT `ref_examination_examination_type` FOREIGN KEY `ref_examination_examination_type` (`code`) REFERENCES `examination_type` (`code`);

ALTER TABLE `examination_assigned` ADD CONSTRAINT `ref_examination_assigned_base_visit` FOREIGN KEY `ref_examination_assigned_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`);

ALTER TABLE `examination_assigned` ADD CONSTRAINT `ref_examination_assigned_examination` FOREIGN KEY `ref_examination_assigned_examination` (`examination_id`) REFERENCES `examination` (`examination_id`);

ALTER TABLE `examination_assigned` ADD CONSTRAINT `ref_examination_assigned_patient` FOREIGN KEY `ref_examination_assigned_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `fundus` ADD CONSTRAINT `ref_fundus_ophthalmologic_visit` FOREIGN KEY `ref_fundus_ophthalmologic_visit` (`visit_id`) REFERENCES `ophthalmologic_visit` (`visit_id`);

ALTER TABLE `general_payment` ADD CONSTRAINT `ref_general_payment_clinic` FOREIGN KEY `ref_general_payment_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `general_payment` ADD CONSTRAINT `ref_general_payment_payment_method` FOREIGN KEY `ref_general_payment_payment_method` (`payment_method_id`) REFERENCES `payment_method` (`payment_method_id`);

ALTER TABLE `general_payment` ADD CONSTRAINT `ref_general_payment_service_note` FOREIGN KEY `ref_general_payment_service_note` (`service_note_id`) REFERENCES `service_note` (`service_note_id`);

ALTER TABLE `glasses_test` ADD CONSTRAINT `ref_glasses_test_refractometry` FOREIGN KEY `ref_glasses_test_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

ALTER TABLE `insurance_service` ADD CONSTRAINT `ref_insurance_service_insurance` FOREIGN KEY `ref_insurance_service_insurance` (`insurance_id`) REFERENCES `insurance` (`insurance_id`);

ALTER TABLE `insurance_service` ADD CONSTRAINT `ref_insurance_service_service` FOREIGN KEY `ref_insurance_service_service` (`service_id`) REFERENCES `service` (`service_id`);

ALTER TABLE `invoice` ADD CONSTRAINT `ref_invoice_customer` FOREIGN KEY `ref_invoice_customer` (`customer_id`) REFERENCES `customer` (`person_id`);

ALTER TABLE `invoice_line` ADD CONSTRAINT `ref_invoice_line_invoice` FOREIGN KEY `ref_invoice_line_invoice` (`invoice_id`) REFERENCES `invoice` (`invoice_id`);

ALTER TABLE `invoice_line` ADD CONSTRAINT `ref_invoice_line_tax_type` FOREIGN KEY `ref_invoice_line_tax_type` (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`);

ALTER TABLE `invoice_line` ADD CONSTRAINT `ref_invoice_line_ticket` FOREIGN KEY `ref_invoice_line_ticket` (`ticket_id`) REFERENCES `ticket` (`ticket_id`);

ALTER TABLE `invoice_line` ADD CONSTRAINT `ref_invoice_line_user` FOREIGN KEY `ref_invoice_line_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `lab_test` ADD CONSTRAINT `ref_lab_test_unit_type` FOREIGN KEY `ref_lab_test_unit_type` (`unit_type_id`) REFERENCES `unit_type` (`unit_type_id`);

ALTER TABLE `lab_test_assigned` ADD CONSTRAINT `ref_lab_test_assigned_base_visit` FOREIGN KEY `ref_lab_test_assigned_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`);

ALTER TABLE `lab_test_assigned` ADD CONSTRAINT `ref_lab_test_assigned_lab_test` FOREIGN KEY `ref_lab_test_assigned_lab_test` (`lab_test_id`) REFERENCES `lab_test` (`lab_test_id`);

ALTER TABLE `lab_test_assigned` ADD CONSTRAINT `ref_lab_test_assigned_patient` FOREIGN KEY `ref_lab_test_assigned_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `log` ADD CONSTRAINT `ref_log_user` FOREIGN KEY `ref_log_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `mot_append` ADD CONSTRAINT `ref_mot_append_ophthalmologic_visit` FOREIGN KEY `ref_mot_append_ophthalmologic_visit` (`visit_id`) REFERENCES `ophthalmologic_visit` (`visit_id`);

ALTER TABLE `ophthalmologic_visit` ADD CONSTRAINT `ref_ophthalmologic_visit_base_visit` FOREIGN KEY `ref_ophthalmologic_visit_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`);

ALTER TABLE `optical_objective_examination` ADD CONSTRAINT `ref_optical_objective_examination_refractometry` FOREIGN KEY `ref_optical_objective_examination_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

ALTER TABLE `paquimetry` ADD CONSTRAINT `ref_paquimetry_examination_assigned` FOREIGN KEY `ref_paquimetry_examination_assigned` (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`);

ALTER TABLE `parameter` ADD CONSTRAINT `ref_parameter_service` FOREIGN KEY `ref_parameter_service` (`service_id`) REFERENCES `service` (`service_id`);

ALTER TABLE `patient` ADD CONSTRAINT `ref_patient_person` FOREIGN KEY `ref_patient_person` (`person_id`) REFERENCES `person` (`person_id`);

ALTER TABLE `patient` ADD CONSTRAINT `ref_patient_clinic` FOREIGN KEY `ref_patient_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `payment` ADD CONSTRAINT `ref_payment_clinic` FOREIGN KEY `ref_payment_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `payment` ADD CONSTRAINT `ref_payment_general_payment` FOREIGN KEY `ref_payment_general_payment` (`general_payment_id`) REFERENCES `general_payment` (`general_payment_id`);

ALTER TABLE `payment` ADD CONSTRAINT `ref_payment_payment_method` FOREIGN KEY `ref_payment_payment_method` (`payment_method_id`) REFERENCES `payment_method` (`payment_method_id`);

ALTER TABLE `payment` ADD CONSTRAINT `ref_payment_ticket` FOREIGN KEY `ref_payment_ticket` (`ticket_id`) REFERENCES `ticket` (`ticket_id`);

ALTER TABLE `payment` ADD CONSTRAINT `ref_payment_user` FOREIGN KEY `ref_payment_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `permission` ADD CONSTRAINT `ref_permission_process` FOREIGN KEY `ref_permission_process` (`process_id`) REFERENCES `process` (`process_id`);

ALTER TABLE `permission` ADD CONSTRAINT `ref_permission_user_group` FOREIGN KEY `ref_permission_user_group` (`user_group_id`) REFERENCES `user_group` (`user_group_id`);

ALTER TABLE `person` ADD CONSTRAINT `ref_person_source` FOREIGN KEY `ref_person_source` (`source_id`) REFERENCES `source` (`source_id`);

ALTER TABLE `policy` ADD CONSTRAINT `ref_policy_customer` FOREIGN KEY `ref_policy_customer` (`person_id`) REFERENCES `customer` (`person_id`);

ALTER TABLE `policy` ADD CONSTRAINT `ref_policy_insurance` FOREIGN KEY `ref_policy_insurance` (`insurance_id`) REFERENCES `insurance` (`insurance_id`);

ALTER TABLE `prescription_glasses` ADD CONSTRAINT `ref_prescription_glasses_refractometry` FOREIGN KEY `ref_prescription_glasses_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

ALTER TABLE `previous_medical_record` ADD CONSTRAINT `ref_previous_medical_record_patient` FOREIGN KEY `ref_previous_medical_record_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `procedure` ADD CONSTRAINT `ref_procedure_service` FOREIGN KEY `ref_procedure_service` (`service_id`) REFERENCES `service` (`service_id`);

ALTER TABLE `procedure_assigned` ADD CONSTRAINT `ref_procedure_assigned_base_visit` FOREIGN KEY `ref_procedure_assigned_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`);

ALTER TABLE `procedure_assigned` ADD CONSTRAINT `ref_procedure_assigned_patient` FOREIGN KEY `ref_procedure_assigned_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `procedure_assigned` ADD CONSTRAINT `ref_procedure_assigned_procedure` FOREIGN KEY `ref_procedure_assigned_procedure` (`procedure_id`) REFERENCES `procedure` (`procedure_id`);

ALTER TABLE `professional` ADD CONSTRAINT `ref_professional_person` FOREIGN KEY `ref_professional_person` (`person_id`) REFERENCES `person` (`person_id`);

ALTER TABLE `professional` ADD CONSTRAINT `ref_professional_tax_withholding_type` FOREIGN KEY `ref_professional_tax_withholding_type` (`tax_withholding_type_id`) REFERENCES `tax_withholding_type` (`tax_withholding_type_id`);

ALTER TABLE `professional` ADD CONSTRAINT `ref_professional_user` FOREIGN KEY `ref_professional_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `professional_invoice` ADD CONSTRAINT `ref_professional_invoice_professional` FOREIGN KEY `ref_professional_invoice_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `professional_invoice_line` ADD CONSTRAINT `ref_professional_invoice_line_professional_invoice` FOREIGN KEY `ref_professional_invoice_line_professional_invoice` (`invoice_id`) REFERENCES `professional_invoice` (`invoice_id`);

ALTER TABLE `professional_invoice_line` ADD CONSTRAINT `ref_professional_invoice_line_tax_type` FOREIGN KEY `ref_professional_invoice_line_tax_type` (`taxtype_id`) REFERENCES `tax_type` (`tax_type_id`);

ALTER TABLE `professional_invoice_line` ADD CONSTRAINT `ref_professional_invoice_line_ticket` FOREIGN KEY `ref_professional_invoice_line_ticket` (`ticket_id`) REFERENCES `ticket` (`ticket_id`);

ALTER TABLE `refractometry` ADD CONSTRAINT `ref_refractometry_examination_assigned` FOREIGN KEY `ref_refractometry_examination_assigned` (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`);

ALTER TABLE `service` ADD CONSTRAINT `ref_service_service_category` FOREIGN KEY `ref_service_service_category` (`service_category_id`) REFERENCES `service_category` (`service_category_id`);

ALTER TABLE `service` ADD CONSTRAINT `ref_service_tax_type` FOREIGN KEY `ref_service_tax_type` (`tax_type_id`) REFERENCES `tax_type` (`tax_type_id`);

ALTER TABLE `service_note` ADD CONSTRAINT `ref_service_note_clinic` FOREIGN KEY `ref_service_note_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `service_note` ADD CONSTRAINT `ref_service_note_customer` FOREIGN KEY `ref_service_note_customer` (`person_id2`) REFERENCES `customer` (`person_id`);

ALTER TABLE `service_note` ADD CONSTRAINT `ref_service_note_invoice` FOREIGN KEY `ref_service_note_invoice` (`invoice_id2`) REFERENCES `invoice` (`invoice_id`);

ALTER TABLE `service_note` ADD CONSTRAINT `ref_service_note_professional` FOREIGN KEY `ref_service_note_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `service_note` ADD CONSTRAINT `ref_service_note_professional_invoice` FOREIGN KEY `ref_service_note_professional_invoice` (`invoice_id`) REFERENCES `professional_invoice` (`invoice_id`);

ALTER TABLE `service_note` ADD CONSTRAINT `ref_service_note_user` FOREIGN KEY `ref_service_note_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `subjective_optical_examination` ADD CONSTRAINT `ref_subjective_optical_examination_refractometry` FOREIGN KEY `ref_subjective_optical_examination_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

ALTER TABLE `telephone` ADD CONSTRAINT `ref_telephone_clinic` FOREIGN KEY `ref_telephone_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `telephone` ADD CONSTRAINT `ref_telephone_healthcare_company` FOREIGN KEY `ref_telephone_healthcare_company` (`hc_id`) REFERENCES `healthcare_company` (`hc_id`);

ALTER TABLE `telephone` ADD CONSTRAINT `ref_telephone_person` FOREIGN KEY `ref_telephone_person` (`person_id`) REFERENCES `person` (`person_id`);

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_clinic` FOREIGN KEY `ref_ticket_clinic` (`clinic_id`) REFERENCES `clinic` (`clinic_id`);

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_insurance_service` FOREIGN KEY `ref_ticket_insurance_service` (`insurance_service_id`) REFERENCES `insurance_service` (`insurance_service_id`);

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_policy` FOREIGN KEY `ref_ticket_policy` (`policy_id`) REFERENCES `policy` (`policy_id`);

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_professional` FOREIGN KEY `ref_ticket_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_service_note` FOREIGN KEY `ref_ticket_service_note` (`service_note_id`) REFERENCES `service_note` (`service_note_id`);

ALTER TABLE `ticket` ADD CONSTRAINT `ref_ticket_user` FOREIGN KEY `ref_ticket_user` (`user_id`) REFERENCES `user` (`user_id`);

ALTER TABLE `topography` ADD CONSTRAINT `ref_topography_examination_assigned` FOREIGN KEY `ref_topography_examination_assigned` (`examination_assigned_id`) REFERENCES `examination_assigned` (`examination_assigned_id`);

ALTER TABLE `treatment` ADD CONSTRAINT `ref_treatment_base_visit` FOREIGN KEY `ref_treatment_base_visit` (`visit_id`) REFERENCES `base_visit` (`visit_id`);

ALTER TABLE `treatment` ADD CONSTRAINT `ref_treatment_drug` FOREIGN KEY `ref_treatment_drug` (`drug_id`) REFERENCES `drug` (`drug_id`);

ALTER TABLE `treatment` ADD CONSTRAINT `ref_treatment_patient` FOREIGN KEY `ref_treatment_patient` (`person_id`) REFERENCES `patient` (`person_id`);

ALTER TABLE `treatment` ADD CONSTRAINT `ref_treatment_professional` FOREIGN KEY `ref_treatment_professional` (`person_id`) REFERENCES `professional` (`person_id`);

ALTER TABLE `user` ADD CONSTRAINT `ref_user_base_visit_type` FOREIGN KEY `ref_user_base_visit_type` (`code`) REFERENCES `base_visit_type` (`code`);

ALTER TABLE `user` ADD CONSTRAINT `ref_user_user_group` FOREIGN KEY `ref_user_user_group` (`user_group_id`) REFERENCES `user_group` (`user_group_id`);

ALTER TABLE `without_glasses_test` ADD CONSTRAINT `ref_without_glasses_test_refractometry` FOREIGN KEY `ref_without_glasses_test_refractometry` (`examination_assigned_id`) REFERENCES `refractometry` (`examination_assigned_id`);

