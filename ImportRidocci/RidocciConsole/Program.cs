using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriCliModel;
using RidocciModel;
using Telerik.OpenAccess;

namespace RidocciConsole
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("Insurance company -> {0} ({1}/{2})", aseg.Nom_aseguradora,++r,numr);
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
        #region Funciones individuales
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
    }
}