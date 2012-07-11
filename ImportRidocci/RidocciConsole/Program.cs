using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriCliModel;
using RidocciModel;
using Telerik.OpenAccess;
using System.Data;
using System.Data.OleDb;

namespace RidocciConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- begin --");
            CargaRidocci();
            Console.WriteLine(" -- Press <ENTER> --");
            Console.ReadLine();
        }
        #region Funciones individuales (RIDOCCI)
        public static void CargaRidocci()
        {
            Console.WriteLine("RidocciConsole - START");
            Console.WriteLine("--------------------------------------------------------------");
            // begin program
            int r = 0; int numr = 0;
            // open connection
            RdcModel ctxRid = new RdcModel("Ariclinic_ridocciConnection");
            AriClinicContext ctxAri = new AriClinicContext("Ariclinic_importConnection");

            // health care company - empresa sanitaria
            LoadHealthCareCompany(ctxRid.Empresa_sanitaria.FirstOrDefault<Empresa_sanitarium>(), ctxRid, ctxAri);

            // aseguradora - insurance
            numr = ctxRid.Aseguradoras.Count(); r = 0;
            foreach (Aseguradora aseg in ctxRid.Aseguradoras)
            {
                Console.WriteLine("Insurance company -> {0} ({1}/{2})", aseg.Nom_aseguradora, ++r, numr);
                LoadInsurance(aseg, ctxRid, ctxAri);
            }
            // default service category
            ServiceCategory sc = new ServiceCategory()
            {
                ServiceCategoryId = 1,
                Name = "GENERAL"
            };
            ctxAri.Add(sc);
            ctxAri.SaveChanges();

            // procedencias
            numr = ctxRid.Procedencia.Count(); r = 0;
            foreach (Procedencium procedencia in ctxRid.Procedencia)
            {
                Console.WriteLine("Procedencia -> {0} ({1}/{2})", procedencia.Nom_procedencia, ++r, numr);
                LoadProcedencia(procedencia, ctxRid, ctxAri);
            }

            // acto medico - service
            numr = ctxRid.Acto_medicos.Count(); r = 0;
            foreach (Acto_medico amed in ctxRid.Acto_medicos)
            {
                Console.WriteLine("Service -> {0} ({1}/{2})", amed.Nom_acto_medico, ++r, numr);
                LoadService(amed, ctxRid, ctxAri, sc);
            }
            // acto medico asc - insurance services
            numr = ctxRid.Acto_medico_ascs.Count(); r = 0;
            foreach (Acto_medico_asc asc in ctxRid.Acto_medico_ascs)
            {
                Console.WriteLine("InsuranceService -> {0} ({1}/{2})", asc.Id_acto_medico_asc, ++r, numr);
                LoadInsuranceServices(asc, ctxRid, ctxAri);
            }
            // historiales - patients and customers
            numr = ctxRid.Historials.Count(); r = 0;
            foreach (Historial his in ctxRid.Historials)
            {
                Console.WriteLine("Patient -> ({1:0000000}/{2:00000000}) {0} ", his.Nombre, ++r, numr);
                LoadPatientCustomer(his, ctxRid, ctxAri);
            }


            // Profesionales - professionals
            numr = ctxRid.Profesionals.Count(); r = 0;
            foreach (Profesional p in ctxRid.Profesionals)
            {
                Console.WriteLine("Professional -> {0} ({1}/{2})", p.Nom_profesional, ++r, numr);
                Professional professional = new Professional();
                professional.OftId = p.Id_profesional;
                professional.FullName = p.Nom_profesional;
                professional.ComercialName = p.Nom_profesional;
                professional.License = p.Num_colegiado;
                ctxAri.Add(professional);
                ctxAri.SaveChanges();
            }

            // Agendas --> Diary
            numr = ctxRid.Agendas.Count(); r = 0;
            foreach (Agenda a in ctxRid.Agendas)
            {
                Console.WriteLine("Diary -> {1:000000}/{2:000000} {0}", a.Nom_agenda, ++r, numr);
                Diary d = new Diary();
                d.Name = a.Nom_agenda;
                d.OftId = a.Id_agenda;
                d.BeginHour = a.Hora_inicio;
                d.EndHour = a.Hora_fin;
                d.TimeStep = a.Tramo;
                ctxAri.Add(d);
                ctxAri.SaveChanges();
            }

            // Tipos de cita --> Appointment Type
            numr = ctxRid.Tipo_cita.Count(); r = 0;
            foreach (Tipo_citum tc in ctxRid.Tipo_cita)
            {
                Console.WriteLine("Appointment type -> {1:000000}/{2:000000} {0}", tc.Nom_tipo_cita, ++r, numr);
                AppointmentType ap = new AppointmentType();
                ap.Name = tc.Nom_tipo_cita;
                ap.OftId = tc.Id_tipo_cita;
                ap.Duration = tc.Duracion;
                ctxAri.Add(ap);
                ctxAri.SaveChanges();
            }

            // Citas --> Appointments
            numr = ctxRid.Cita.Count(); r = 0;
            foreach (Citum c in ctxRid.Cita)
            {
                Console.WriteLine("Cita -> {1:000000}/{2:000000} {0} ", c.Asunto, ++r, numr);
                AppointmentInfo ap = new AppointmentInfo();
                Professional prof = (from p in ctxAri.Professionals
                                     where p.OftId == c.Id_profesional
                                     select p).FirstOrDefault<Professional>();
                Diary diary = (from d in ctxAri.Diaries
                               where d.OftId == c.Id_agenda
                               select d).FirstOrDefault<Diary>();
                Patient patient = (from pat in ctxAri.Patients
                                   where pat.OftId == c.Id_historia
                                   select pat).FirstOrDefault<Patient>();
                AppointmentType atyp = (from at in ctxAri.AppointmentTypes
                                        where at.OftId == c.Id_tipo_cita
                                        select at).FirstOrDefault<AppointmentType>();
                ap.Patient = patient;
                ap.Diary = diary;
                ap.Professional = prof;
                ap.AppointmentType = atyp;
                ap.Status = (c.Estado + 1).ToString();
                ap.BeginDateTime = c.Fecha_hora_inicio;
                ap.EndDateTime = c.Fecha_hora_fin;
                ap.Duration = c.Duracion;
                ap.Arrival = c.Llegada;
                ap.Subject = c.Asunto;
                ap.Comments = c.Observaciones;
                ctxAri.Add(ap);
                ctxAri.SaveChanges();
            }

            LoadTicketsAndServiceNotes(ctxRid, ctxAri);

            LoadDiagnostics(ctxRid, ctxAri);

            LoadTreatments(ctxRid, ctxAri);

            LoadPreviousMedicalRecords(ctxRid, ctxAri);



            // close connections
            ctxAri.Dispose();
            ctxRid.Dispose();
            // end programa
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("RidocciConsole - END. Prees ENTER to close.");
            Console.ReadLine();

        }





        public static void LoadHealthCareCompany(Empresa_sanitarium empresa, RdcModel ctxRid, AriClinicContext ctxAri)
        {
            Console.WriteLine("Empresa - > {0}", empresa.Nom_empresa);
            HealthcareCompany hc = new HealthcareCompany() 
            { 
                Name = empresa.Nom_empresa,
            };
            ctxAri.Add(hc);
            // associated clinics
            var rs = from c in ctxRid.Clinicas
                     where c.Id_empresa == empresa.Id_empresa
                     select c;
            foreach (Clinica clinica in rs)
            {
                Clinic clinic = new Clinic()
                {
                    Name = clinica.Nom_clinica,
                    ClinicId = clinica.Id_clinica
                };
                ctxAri.Add(clinic);
                Address address = new Address()
                {
                    Street = clinica.Direccion,
                    City = clinica.Poblacion,
                    PostCode = clinica.Cod_postal,
                    Clinic = clinic
                };
                ctxAri.Add(address);
                Telephone telephone = new Telephone()
                {
                    Number = clinica.Telefono,
                    Clinic = clinic
                };
                ctxAri.Add(telephone);
            }

        }

        public static void LoadInsurance(Aseguradora aseg, RdcModel ctxRid, AriClinicContext ctxAri)
        {
            
            Insurance insurance = new Insurance();
            insurance.InsuranceId = aseg.Id_aseguradora;
            insurance.Name = aseg.Nom_aseguradora;
            insurance.OftId = aseg.Id_aseguradora;
            ctxAri.Add(insurance);
            ctxAri.SaveChanges();
        }
        public static void LoadService(Acto_medico amed, RdcModel ctxRid, AriClinicContext ctxAri, ServiceCategory sc)
        {
            
            Service s = new Service()
            {
                OftId = amed.Id_acto_medico,
                Name = amed.Nom_acto_medico,
                ServiceCategory = sc
            };
            ctxAri.Add(s);
            ctxAri.SaveChanges();
        }
        public static void LoadProcedencia(Procedencium procedencia, RdcModel ctxRid, AriClinicContext ctxAri)
        {
            Source s = new Source();
            s.SourceId = procedencia.Id_procedencia;
            s.OftId = procedencia.Id_procedencia;
            s.Name = procedencia.Nom_procedencia;
            ctxAri.Add(s);
            ctxAri.SaveChanges();
        }
        public static void LoadInsuranceServices(Acto_medico_asc asc, RdcModel ctxRid, AriClinicContext ctxAri)
        {
            Insurance insurance = (from i in ctxAri.Insurances
                                   where i.OftId == asc.Id_aseguradora
                                   select i).FirstOrDefault<Insurance>();
            Service service = (from s in ctxAri.Services
                               where s.OftId == asc.Id_acto_medico
                               select s).FirstOrDefault<Service>();
            InsuranceService ins = new InsuranceService()
            {
                OftId = asc.Id_acto_medico_asc,
                Insurance = insurance,
                Service = service,
                Price = asc.Importe
            };
            ins.Price = 1;
            ctxAri.Add(ins);
            ctxAri.SaveChanges();
        }
        public static void LoadPatientCustomer(Historial his, RdcModel ctxRid, AriClinicContext ctxAri)
        {
            
            Patient patient = new Patient()
            {
                OftId = his.Id_historia,
                Name = his.Nombre,
                Surname1 = GetSurname1(his.Apellidos),
                Surname2 = GetSurname2(his.Apellidos),
                BornDate = his.Fecha_nacimiento,
                FullName = String.Format("{0}, {1}", his.Apellidos, his.Nombre),
                Sex = his.Sexo,
                Comments = his.Observaciones,
                LastUpdate = his.Ultima_actualizacion
            };
            ctxAri.Add(patient);
            Customer customer = new Customer();
            customer.OftId = his.Id_historia;
            customer.ComercialName = patient.FullName;
            customer.FullName = patient.FullName;
            customer.VATIN = his.Nif;
            ctxAri.Add(customer);
            patient.Customer = customer;
            // direccion
            if (his.Direccion != "")
            {
                Address address = new Address()
                {
                    Street = his.Direccion,
                    PostCode = his.Cod_postal,
                    City = his.Poblacion,
                    Country = his.Pais,
                    Province = his.Provincia,
                    Type = "Primary",
                    Person = patient
                };
                ctxAri.Add(address);
            }
            if (his.Telefono1 != "")
            {
                Telephone telephone = new Telephone()
                {
                    Number = his.Telefono1,
                    Type = "Primary",
                    Person = patient
                };
                ctxAri.Add(telephone);
            }
            if (his.Telefono2 != "")
            {
                Telephone telephone = new Telephone()
                {
                    Number = his.Telefono1,
                    Type = "Secondary",
                    Person = patient
                };
                ctxAri.Add(telephone);
            }
            if (his.Movil != "")
            {
                Telephone telephone = new Telephone()
                {
                    Number = his.Movil,
                    Type = "Secondary",
                    Person = patient
                };
                ctxAri.Add(telephone);
            }
            if (his.Email != "")
            {
                Email email = new Email()
                {
                    Url = his.Email,
                    Person = patient,
                    Type = "Primary"
                };
                ctxAri.Add(email);
            }
            if (his.Id_aseguradora != null)
            {
                Insurance insurance = (from i in ctxAri.Insurances
                                       where i.OftId == his.Id_aseguradora
                                       select i).FirstOrDefault<Insurance>();
                Policy policy = new Policy()
                {
                    Insurance = insurance,
                    PolicyNumber = his.Poliza,
                    BeginDate = his.Fecha_alta_poliza,
                    EndDate = his.Fecha_caducidad_poliza,
                    Customer = customer
                };
                ctxAri.Add(policy);
            }
            if (his.Id_procedencia != null)
            {
                Source source = (from s in ctxAri.Sources
                                 where s.OftId == his.Id_procedencia
                                 select s).FirstOrDefault<Source>();
                if (source != null) patient.Source = source;
            }
            patient.Clinic = ctxAri.Clinics.FirstOrDefault<Clinic>();
            ctxAri.SaveChanges();
        }
        public static string GetSurname1(string apellidos)
        {
            string surname = apellidos;
            int pos = apellidos.IndexOf(" ");
            if (pos > 0)
            {
                surname = apellidos.Substring(0, pos);
            }
            return surname;
        }
        public static string GetSurname2(string apellidos)
        {
            string surname = "";
            int pos = apellidos.IndexOf(" ");
            if (pos > 0)
            {
                surname = apellidos.Substring(pos + 1);
            }
            return surname;
        }

        public static void LoadTicketsAndServiceNotes(RdcModel ctxRid, AriClinicContext ctx)
        {
            int numr = ctxRid.Acto_medico_asgs.Count(); int r = 0;
            
            DateTime fechaAnt = new DateTime(1, 1, 1);
            int idHistoriaAnt = 0;

            ServiceNote sn = null;

            foreach (Acto_medico_asg asg in (from ams in ctxRid.Acto_medico_asgs
                                             orderby ams.Fecha, ams.Id_historia
                                             select ams))
            {
                Console.WriteLine("Tickest & Service notes -> {1:000000}/{2:000000} {0:dd/MM/yyyy} ", asg.Fecha, ++r, numr);
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == asg.Id_historia
                                   select p).FirstOrDefault<Patient>();
                if (asg.Fecha != fechaAnt || asg.Id_historia != idHistoriaAnt)
                {
                    // al cambiar la fecha o el paciente creamos una nueva nota de servicio
                    sn = new ServiceNote();
                    sn.Customer = patient.Customer;
                    sn.ServiceNoteDate = asg.Fecha;
                    ctx.Add(sn);
                    ctx.SaveChanges();
                    fechaAnt = asg.Fecha;
                    idHistoriaAnt = (int)asg.Id_historia;
                }
                // montamos el ticket de hoy
                Ticket tck = new Ticket();
                tck.ServiceNote = sn;
                InsuranceService isrv = (from ins in ctx.InsuranceServices
                                         where ins.OftId == asg.Id_acto_medico_asc
                                         select ins).FirstOrDefault<InsuranceService>();
                tck.InsuranceService = isrv;
                tck.TicketDate = asg.Fecha;
                tck.Policy = patient.Customer.Policies.FirstOrDefault<Policy>();
                tck.Amount = 1;
                tck.Comments = asg.Observaciones;
                tck.Description = isrv.Service.Name;
                tck.Checked = asg.Comunicado;
                ctx.Add(tck);
                ctx.SaveChanges();
            }
        }
        public static void LoadDiagnostics(RdcModel ctxRid, AriClinicContext ctx)
        {
            // definiciones 
            int nr = 0, r = 0; // numero de registros, registro actual
            // primero hay que cargar los diagnosticos en general.
            nr = ctxRid.Diagnosticos.Count(); r = 0;
            foreach (Diagnostico d in ctxRid.Diagnosticos)
            {
                Console.WriteLine("Diagnostics -> {1:000000}/{2:000000} {0} ", d.Nom_diagnostico, ++r, nr);
                Diagnostic dg = new Diagnostic();
                dg.Name = d.Nom_diagnostico;
                dg.OftId = d.Id_diagnostico;
                ctx.Add(dg);
                ctx.SaveChanges();
            }
            // y ahora los asignados
            nr = ctxRid.Diagnostico_asignados.Count(); r = 0;
            foreach (Diagnostico_asignado da in ctxRid.Diagnostico_asignados)
            {
                Console.WriteLine("Diagnostics ASSIGNED -> {1:000000}/{2:000000} {0} ", da.Fecha, ++r, nr);
                DiagnosticAssigned das = new DiagnosticAssigned();
                Diagnostic d = (from dg in ctx.Diagnostics
                                where dg.OftId == da.Id_diagnostico
                                select dg).FirstOrDefault<Diagnostic>();
                das.Diagnostic = d;
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == da.Id_historia
                                   select p).FirstOrDefault<Patient>();
                das.Patient = patient;
                das.DiagnosticDate = da.Fecha;
                das.Comments = da.Observaciones;
                ctx.Add(das);
                ctx.SaveChanges();
            }
        }

        public static void LoadTreatments(RdcModel ctxRid, AriClinicContext ctx)
        {
            // definiciones 
            int nr = 0, r = 0; // numero de registros, registro actual
            // primero hay que cargar los fármacos
            nr = ctxRid.Farmacos.Count(); r = 0;
            foreach (Farmaco f in ctxRid.Farmacos)
            {
                Console.WriteLine("Drugs -> {1:000000}/{2:000000} {0} ", f.Nom_farmaco, ++r, nr);
                Drug dg = new Drug();
                dg.Name = f.Nom_farmaco;
                dg.OftId = f.Id_farmaco;
                ctx.Add(dg);
                ctx.SaveChanges();
            }
            // y ahora los asignados
            nr = ctxRid.Tratamientos.Count(); r = 0;
            foreach (Tratamiento trat in ctxRid.Tratamientos)
            {
                Console.WriteLine("Treatments -> {1:000000}/{2:000000} {0} ", trat.Fecha, ++r, nr);
                Treatment t = new Treatment();
                Drug d = (from dg in ctx.Drugs
                                where dg.OftId == trat.Id_farmaco
                                select dg).FirstOrDefault<Drug>();
                t.Drug = d;
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == trat.Id_historia
                                   select p).FirstOrDefault<Patient>();
                t.Patient = patient;
                Professional prof = (from p in ctx.Professionals
                                     where p.OftId == trat.Id_profesional
                                     select p).FirstOrDefault<Professional>();
                t.Professional = prof;
                t.TreatmentDate = trat.Fecha;
                t.Recommend = trat.Posologia;
                ctx.Add(t);
                ctx.SaveChanges();
            }
        }
        public static void LoadPreviousMedicalRecords(RdcModel ctxRid, AriClinicContext ctx)
        {
            // definiciones 
            int nr = 0, r = 0; // numero de registros, registro actual
            // primero hay que cargar los historiales anteriores
            nr = ctxRid.Historials.Count(); r = 0;
            foreach (Historial his in ctxRid.Historials)
            {
                Console.WriteLine("Previous MR -> {1:000000}/{2:000000} {0} ", his.Nombre, ++r, nr);
                PreviousMedicalRecord pmr = new PreviousMedicalRecord();
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == his.Id_historia
                                   select p).FirstOrDefault<Patient>();
                if (patient != null)
                {
                    pmr.Patient = patient;
                    pmr.Content = his.Historia_anterior;
                    ctx.Add(pmr);
                    ctx.SaveChanges();
                }
            }
        }



        #endregion
        #region Funciones individuales (OFT)
        public static void CargaOFT()
        {
            int i2 = 12;
            int i = 0;
            int i3 = 0;
            decimal per = 0;
            // open OFT connection
            OleDbConnection con = CntOft.GetOftConnection("OFT");
            // open AriClinic connection
            AriClinicContext ctx = new AriClinicContext("MIESTETIC");
            // start importing things


            #region Importaciones probadas

            //#region C1
            //// (0) Borrar todo
            //context.SecondaryValue = i.ToString();
            //context.CurrentOperationText = i.ToString() + " Borrando registros existentes... ";
            //i3 = (i / i2) * 100;
            //context.SecondaryPercent = i3.ToString();
            //CntOft.BigDelete(ctx);
            //CntOft.DeleteExaminations(ctx);
            //CntOft.DeleteDrugTreatments(ctx);
            //CntOft.DeleteLabTest(ctx);
            //CntOft.DeleteProcedures(ctx);
            //CntOft.DeleteDiagnostics(ctx);
            //CntOft.DeleteVisit(ctx);
            //CntOft.DeletePrimaryClasses(ctx);
            string r;
            //////// (1) Patients
            //Console.WriteLine("--> Import patients");
            //r = Console.ReadLine();
            //if (r == "Y")
            //    CntOft.ImportPatientCustomer(con, ctx);

            ////// (2) Tax types

            //Console.WriteLine("--> Import tax types");
            //r = Console.ReadLine();
            //if (r == "Y")
            //    CntOft.ImportTaxTypes(con, ctx);

            ////// (3) Services 
            //Console.WriteLine("--> Import categories");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportCategories(con, ctx);

            ////// (4) Porfesionales
            //Console.WriteLine("--> Import professionals");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportProfessionals(con, ctx);

            ////// (5) Aseguradoras y pólizas
            //Console.WriteLine("--> Import assurance policy");
            //r =Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportAssurancePolicies(con, ctx);

            //// (6) Notas de servicio
            Console.WriteLine("--> Import service note");
            r = Console.ReadLine();
            if (r == "Y")
                CntOft.ImportServiceNote(con, ctx);

            //// (7) Formas de pago
            Console.WriteLine("--> Import payment types");
            r = Console.ReadLine();
            if (r == "Y")
                CntOft.ImportPaymentTypes(con, ctx);

            ////(8) Pagos
            Console.WriteLine("--> Import payments");
            r = Console.ReadLine();
            if (r == "Y")
                CntOft.ImportPayments(con, ctx);

            ////// (9) Tipos de cita
            //Console.WriteLine("--> Import appointment's type");
            //r =Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportAppointmentType(con, ctx);

            ////// (10) Agendas
            //Console.WriteLine("--> Import diaries");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportDiary(con, ctx);

            ////// (11) Tipos de cita
            //Console.WriteLine("--> Import appointments");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportAppointmentInfo(con, ctx);

            ////// (12) Motivos de consulta
            //Console.WriteLine("--> Import reasons");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportVisitReasons(con, ctx);

            //// (13) Facturas
            //Console.WriteLine("--> Import invoices");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportInvoices(con, ctx);

            //// (14) Visitas
            //Console.WriteLine("--> Import visits");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportVisits(con, ctx);
            //// (15) Diagnósticos
            //Console.WriteLine("--> Import diagnostics");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportDiagnostics(con, ctx);

            //// (16) Diagnósticos asignados
            //Console.WriteLine("--> Import assigned diagnostics");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportDiagnosticsAssigned(con, ctx);

            //// (17) Exploraciones
            //Console.WriteLine("--> Import examinations");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportExaminations(con, ctx);

            //// (18) Exploraciones asignadas
            //Console.WriteLine("--> Import assigned examintions");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportExaminationsAssigned(con, ctx);

            //// (19) Procedimientos
            //Console.WriteLine("--> Import procedures");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportProcedures(con, ctx);

            //// (20) Procedimientos asignados
            //Console.WriteLine("--> Import assigned procedures");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportProceduresAssigned(con, ctx);
            //#endregion


            //#region Importaciones por probar
            //// (21) Farmacos
            //Console.WriteLine("--> Import drugs");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportDrugs(con, ctx);

            //// (22) Procedimientos asignados
            //Console.WriteLine("--> Import treatment");
            //r = Console.ReadLine();
            //if (r == "Y")
            //CntOft.ImportTreatment(con, ctx);


            #endregion
        }

        public static void FixAnestheticNotes(AriClinicContext ctx)
        {
            int i = 0;
            IList<AnestheticServiceNote> lasn = ctx.AnestheticServiceNotes.ToList<AnestheticServiceNote>();
            foreach (AnestheticServiceNote asn in lasn)
            {
                try
                {
                    i++;
                    Console.WriteLine("ASN: {0} N:{1}", asn.AnestheticServiceNoteId, i);
                    if (asn.Chk1)
                    {
                        Console.WriteLine("ASNPCA: {0}", asn.AnestheticServiceNoteId);
                        //CntAriCli.CheckAnestheticServiceNoteTickets(asn, ctx);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception es)
                {
                }
            }
        }
        #endregion
    }
}