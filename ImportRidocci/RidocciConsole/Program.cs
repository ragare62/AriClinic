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
            foreach (Empresa_sanitarium empresa in ctxRid.Empresa_sanitaria)
            {
                LoadHealthCareCompany(empresa, ctxRid, ctxAri);
            }

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
                Console.WriteLine("Patient -> {0} ({1}/{2})", his.Nombre, ++r, numr);
                LoadPatientCustomer(his, ctxRid, ctxAri);
            }

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
            patient.Customer = customer;
            ctxAri.Add(customer);
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