using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using AriCliModel;

namespace RidocciConsole
{
    /// <summary>
    /// Esta clase presenta la funcionalidad necesaria para transferir los datos desde la 
    /// base de datos de OFT a la de AriClinic.
    /// Todas las operaciones y la clase es estática, no hay que instanciarlas.
    /// </summary>
    public static class CntOft
    {
        // Variables internas para manejar la conexión con la base de datos Access
        private static OleDbConnection con;
        private static OleDbCommand cmd;
        private static OleDbDataAdapter da;
        //
        private static decimal per = 0;

        public static void BigDelete(AriClinicContext ctx)
        {
            ctx.Delete(ctx.InvoiceLines);
            ctx.Delete(ctx.Invoices);
            ctx.SaveChanges();
            ctx.Delete(ctx.AppointmentInfos);
            ctx.Delete(ctx.AppointmentTypes);
            ctx.Delete(ctx.Diaries);
            ctx.SaveChanges();

            ctx.Delete(ctx.Payments);
            ctx.Delete(ctx.Tickets);
            ctx.Delete(ctx.ServiceNotes);
            ctx.Delete(ctx.Policies);
            ctx.Delete(ctx.Insurances);
            ctx.Delete(ctx.InsuranceServices);
            ctx.SaveChanges();

            ctx.Delete(ctx.Services);
            ctx.Delete(ctx.ServiceCategories);
            ctx.Delete(ctx.TaxTypes);
            ctx.Delete(ctx.Addresses); // eliminar direcciones.
            ctx.Delete(ctx.Emails); // eliminar correos electrónicos
            ctx.Delete(ctx.Telephones); // eliminar teléfonos.
            ctx.Delete(ctx.Policies); // eliminar las pólizas.
            ctx.Delete(ctx.PaymentMethods);
            ctx.SaveChanges();
        }

        public static void DeleteDiagnostics(AriClinicContext ctx)
        {
            ctx.Delete(ctx.DiagnosticAssigneds);
            ctx.Delete(ctx.Diagnostics);
            ctx.SaveChanges();
        }

        public static void DeleteProcedures(AriClinicContext ctx)
        {
            ctx.Delete(ctx.ProcedureAssigneds);
            ctx.Delete(ctx.Procedures);
            ctx.SaveChanges();
        }

        public static void DeleteVisit(AriClinicContext ctx)
        {
            ctx.Delete(ctx.OphthalmologicVisits);
            ctx.Delete(ctx.BaseVisits);
            ctx.Delete(ctx.VisitReasons);
            ctx.SaveChanges();
        }

        public static void DeleteLabTest(AriClinicContext ctx)
        {
            ctx.Delete(ctx.LabTestAssigneds);
            ctx.Delete(ctx.LabTests);
            ctx.SaveChanges();
        }

        public static void DeleteExaminations(AriClinicContext ctx)
        {
            ctx.Delete(ctx.WithoutGlassesTests);
            ctx.Delete(ctx.GlassesTests);
            ctx.Delete(ctx.ContactLensesTests);
            ctx.Delete(ctx.OpticalObjectiveExaminations);
            ctx.Delete(ctx.PrescriptionGlasses);
            ctx.Delete(ctx.Cycloplegias);
            //
            ctx.Delete(ctx.Biometries);
            ctx.Delete(ctx.Topographies);
            ctx.Delete(ctx.Paquimetries);
            //
            ctx.Delete(ctx.ExaminationAssigneds);
            ctx.Delete(ctx.Examinations);
            //
            ctx.SaveChanges();
        }

        public static void DeleteDrugTreatments(AriClinicContext ctx)
        {
            ctx.Delete(ctx.Treatments);
            ctx.Delete(ctx.Drugs);
            ctx.SaveChanges();
        }

        public static void DeletePrimaryClasses(AriClinicContext ctx)
        {
            ctx.Delete(ctx.Professionals);
            ctx.Delete(ctx.Clinics); // clínicas.
            ctx.Delete(ctx.Customers); // eliminar los clientes.
            ctx.Delete(ctx.Patients); // por último, los pacientes.
            ctx.SaveChanges();
        }

        /// <summary>
        /// Obtiene un connector para acceder a la base de datos OFT
        /// </summary>
        /// <param name="path"> Ruta completa del archivo mdb</param>
        /// <returns>OleDb connection1</returns>
        public static OleDbConnection GetOftConnection(string path)
        {
            return new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Publicacion\\OFT.mdb");
        }

        /// <summary>
        /// Traspasa los datos de los pacientes desde OFT a AriClinic
        /// </summary>
        /// <param name="con"> Connector a OFT</param>
        /// <param name="ctx"> Contexto de AriClinic</param>
        public static void ImportPatientCustomer(OleDbConnection con, AriClinicContext ctx)
        {
            // (1) Eliminar los datos que pudiera haber previamente y que serán
            // sustituidos por los nuevos.
            ctx.Delete(ctx.Addresses); // eliminar direcciones.
            ctx.Delete(ctx.Emails); // eliminar correos electrónicos
            ctx.Delete(ctx.Telephones); // eliminar teléfonos.
            ctx.Delete(ctx.Policies); // eliminar las pólizas.

            ctx.Delete(ctx.Customers); // eliminar los clientes.
            ctx.Delete(ctx.Patients); // por último, los pacientes.
            ctx.SaveChanges();

            // (1.1) Montar las procedencias
            ImportSources(con, ctx);

            // (2) Lleer todos los pacientes en OFT
            string sql = "SELECT * FROM Historiales";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConHistoriales");
            int nreg = ds.Tables["ConHistoriales"].Rows.Count;
            int reg = 0;

            // (2.0) Por cada fila lieda de la tabla, damos de alta el 
            // paciente correspondiente con sus direcciones, teléfonosç
            // y correo electrónico.
            foreach (DataRow dr in ds.Tables["ConHistoriales"].Rows)
            {
                ++reg; // un registro más (para saber por donde va)
                Console.WriteLine("registro {1:#####0} de {2:#####0} / {0}", (string)dr["Nombre"], reg, nreg);
                // (2.1) Crear cliente
                Customer customer = new Customer();
                if (dr["NumDni"] != DBNull.Value)
                    customer.VATIN = (string)dr["NumDni"];
                customer.FullName = (string)dr["Nombre"];
                customer.ComercialName = (string)dr["Nombre"];
                customer.OftId = (int)dr["NumHis"];
                ctx.Add(customer);
                ctx.SaveChanges();

                // (2.2) Crear paciente y asignarle el cliente
                Patient patient = new Patient();
                patient.Name = (string)dr["Nom"];
                patient.Surname1 = (string)dr["Apell1"];
                if (dr["Apell2"] != DBNull.Value)
                    patient.Surname2 = (string)dr["Apell2"];
                patient.FullName = (string)dr["Nombre"];
                if (dr["FechaNac"] != DBNull.Value)
                    patient.BornDate = (DateTime)dr["FechaNac"];
                patient.Sex = "M";
                if (dr["Sexo"] != DBNull.Value)
                    if ((byte)dr["Sexo"] == 2)
                        patient.Sex = "W";
                patient.Customer = customer;
                patient.OftId = (int)dr["NumHis"];
                // asignar la procedencia
                Source src = (from s in ctx.Sources
                              where s.OftId == (int)dr["IdProcMed"]
                              select s).FirstOrDefault<Source>();
                if (src != null)
                    patient.Source = src;

                ctx.Add(patient);
                ctx.SaveChanges();

                // (2.3) Crear la dirección y asignársela a cliente y paciente.
                Address address = new Address();
                address.Street = (string)dr["Direccion"];
                address.City = (string)dr["Poblacion"];
                if (dr["CodPostal"] != DBNull.Value)
                    address.PostCode = (string)dr["CodPostal"];
                address.Province = (string)dr["Provincia"];
                address.Type = "Primary";
                ctx.Add(address);
                customer.Addresses.Add(address);
                patient.Addresses.Add(address);
                ctx.SaveChanges();

                // (2.4) Lo mismo para los teléfono.
                Telephone telephone = new Telephone();
                if (dr["Tel1"] != DBNull.Value)
                {
                    telephone.Number = (string)dr["Tel1"];
                    telephone.Type = "Primary";
                    ctx.Add(telephone);
                    patient.Telephones.Add(telephone);
                    customer.Telephones.Add(telephone);
                }
                if (dr["Tel2"] != DBNull.Value)
                {
                    telephone = new Telephone();
                    telephone.Number = (string)dr["Tel2"];
                    telephone.Type = "Primary";
                    ctx.Add(telephone);
                    patient.Telephones.Add(telephone);
                    customer.Telephones.Add(telephone);
                }
                if (dr["Movil"] != DBNull.Value)
                {
                    telephone = new Telephone();
                    telephone.Number = (string)dr["Movil"];
                    telephone.Type = "Secondary";
                    ctx.Add(telephone);
                    patient.Telephones.Add(telephone);
                    customer.Telephones.Add(telephone);
                }

                // (2.5) Igual pero para correos electrónicos
                Email email = new Email();
                if (dr["Email"] != DBNull.Value)
                    email.Url = (string)dr["Email"];
                email.Type = "Primary";
                ctx.Add(email);
                patient.Emails.Add(email);
                customer.Emails.Add(email);
                ctx.SaveChanges();
            }
        }

        public static void ImportSources(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.Sources);

            // (1) Dar de alta las procedencias
            string sql = "SELECT * FROM ProcMed";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConProcMed");
            int nreg = ds.Tables["ConProcMed"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConProcMed"].Rows)
            {
                reg++;
                Console.WriteLine("Procedencias {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomProcMed"]);
                Source src = new Source();
                src.Name = (string)dr["NomProcMed"];
                src.OftId = (int)dr["IdProcMed"];
                ctx.Add(src);
                ctx.SaveChanges();
            }
        }



        /// <summary>
        /// Importa los tipos de IVA
        /// </summary>
        /// <param name="con"></param>
        /// <param name="ctx"></param>
        public static void ImportTaxTypes(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.TaxTypes);

            // (1) Dar de alta los tipos de IVA importados.
            string sql = "SELECT * FROM TiposIva";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConTiposIVA");
            int nreg = ds.Tables["ConTiposIVA"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConTiposIVA"].Rows)
            {
                reg++;
                Console.WriteLine("Tipos IVA {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomTipoIva"]);
                TaxType tt = new TaxType();
                tt.Name = (string)dr["NomTipoIva"];
                Single p = (Single)dr["Porcentaje"];
                tt.Percentage = decimal.Parse(p.ToString());
                tt.OftId = (int)dr["IdTipoIva"];
                ctx.Add(tt);
            }
            ctx.SaveChanges();
        }

        /// <summary>
        /// Traspasa los datos que corresponden a servicios y categorias de servicio
        /// </summary>
        /// <param name="con">Conector a OFT</param>
        /// <param name="ctx">Contexto de AriClinc</param>
        public static void ImportCategories(OleDbConnection con, AriClinicContext ctx)
        {
            int id = 0;

            // (0) Borrar los datos previos.
            ctx.Delete(ctx.Services);
            ctx.Delete(ctx.ServiceCategories);
            
            // (1) Dar de alta las categorias de servicio
            string sql = "SELECT * FROM TipServMed";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConServicios");
            int nreg = ds.Tables["ConServicios"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConServicios"].Rows)
            {
                reg++;
                Console.WriteLine("Categorias {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomTipServMed"]);
                ServiceCategory sc = new ServiceCategory();
                sc.Name = (string)dr["NomTipServMed"];
                sc.OftId = (int)dr["IdTipservMed"];
                ctx.Add(sc);
                ctx.SaveChanges();
            }
            // (2) Con las categorías dadas de alta  damos de alta los
            // servicios.
            sql = "SELECT * FROM ServMed";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConServ2");
            nreg = ds.Tables["ConServ2"].Rows.Count;
            reg = 0;
            foreach (DataRow dr in ds.Tables["ConServ2"].Rows)
            {
                reg++;

                Service s = new Service();
                s.Name = (string)dr["NomServMed"];
                id = (int)dr["IdTipServMed"];
                s.ServiceCategory = (from sc in ctx.ServiceCategories
                                     where sc.OftId == id
                                     select sc).FirstOrDefault<ServiceCategory>();
                s.OftId = (int)dr["IdServMed"];
                ctx.Add(s);
            }
            ctx.SaveChanges();
        }

        /// <summary>
        /// Importa losprofesionales dados de alta en OFT
        /// </summary>
        /// <param name="con">Conector con OFT</param>
        /// <param name="ctx">Contexto para AriClinic</param>
        public static void ImportProfessionals(OleDbConnection con, AriClinicContext ctx)
        {
            //(0) Borrar los professionales que existieran previamente
            ctx.Delete(ctx.Professionals);

            //(1) Leer los Médicos de OFT
            string sql = "SELECT * FROM Medicos";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConMedicos");
            int nreg = ds.Tables["ConMedicos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConMedicos"].Rows)
            {
                reg++;
                Console.WriteLine("Profesionales {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomMed"]);
                Professional p = new Professional();
                p.ComercialName = (string)dr["NomMed"];
                p.FullName = p.ComercialName;
                p.OftId = (int)dr["IdMed"];
                ctx.Add(p);
            }
            ctx.SaveChanges();
        }

        public static void ImportAssurancePolicies(OleDbConnection con, AriClinicContext ctx)
        {
            //(0) Borrar las aseguradoras y pólizas previas.
            ctx.Delete(ctx.Policies);
            ctx.Delete(ctx.Insurances);
            ctx.Delete(ctx.InsuranceServices);

            //(1) Por defecto creamos una aseguradora que es la clínica de Valencia.
            Insurance insurance = new Insurance();
            insurance.Name = "MIESTETIC (Valencia)";
            insurance.Internal = true;
            ctx.Add(insurance);

            //(2) Ahora leemos, de nuevo, todos los tipos de servicio porque en OFT
            // ellos llevan los importes y en nuestro caso son los Insurance services
            string sql = "SELECT * FROM ServMed";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConServicios");
            int nreg = ds.Tables["ConServicios"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConServicios"].Rows)
            {
                reg++;
                Console.WriteLine("Servicions {0:#####0} de {1:#####0} {2}", reg, nreg, "SERVICIO");
                int id = (int)dr["IdServMed"];
                InsuranceService ins = new InsuranceService();
                ins.Insurance = insurance;
                ins.Service = (from s in ctx.Services
                               where s.OftId == id
                               select s).FirstOrDefault<Service>();
                ins.Price = (decimal)dr["Importe"];
                ctx.Add(ins);
            }

            //(3) por último asignamos una póliza a todos los clientes que tenemos dados de alta.
            foreach (Customer cus in ctx.Customers)
            {
                Policy pol = new Policy();
                pol.Customer = cus;
                pol.Insurance = insurance;
                ctx.Add(pol);
            }
            ctx.SaveChanges();
        }

        public static void ImportServiceNote(OleDbConnection con, AriClinicContext ctx)
        {
            //(0) Borrar las notas de servicio y tickets previos
            ctx.Delete(ctx.Tickets);
            ctx.Delete(ctx.ServiceNotes);
            ctx.SaveChanges();

            // Nos hace falta una clínica, la creamos ahora
            Clinic cl = new Clinic();
            cl.Name = "Clinica Valencia";
            ctx.Add(cl);
            ctx.SaveChanges();

            //(1) Leer las notas de servicio OFT
            string sql = "SELECT * FROM NotaServicio";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConNotaServicio");
            int nreg = ds.Tables["ConNotaServicio"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConNotaServicio"].Rows)
            {
                reg++;
                Console.WriteLine("Notas de servicio {0:#####0} de {1:#####0} A:{2} N:{3}", reg, nreg,(int)dr["Ano"], (int)dr["NumNota"]);
                ServiceNote sn = new ServiceNote();
                int id = (int)dr["NumHis"];
                sn.Customer = (from cus in ctx.Customers
                               where cus.OftId == id
                               select cus).FirstOrDefault<Customer>();
                sn.ServiceNoteDate = (DateTime)dr["Fecha"];
                decimal total = (decimal)dr["Total"];
                sn.Total = total;
                sn.Clinic = cl;
                Professional prf = (from p in ctx.Professionals
                                    where p.OftId == 0
                                    select p).FirstOrDefault<Professional>();
                sn.Professional = prf;
                sn.Oft_Ano = (int)dr["Ano"];
                sn.Oft_NumNota = (int)dr["NumNota"];
                ctx.Add(sn);
                ctx.SaveChanges();
            }


            //(2) Importar la líneas de las notas de servicio
            sql = "SELECT * FROM LinNotaServicio";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConLineasServicio");
            nreg = ds.Tables["ConLineasServicio"].Rows.Count;
            reg = 0;
            foreach (DataRow dr in ds.Tables["ConLineasServicio"].Rows)
            {
                reg++;
                Console.WriteLine("Lineas de servicio {0:#####0} de {1:#####0} A:{2} N:{3}", reg, nreg, (int)dr["Ano"], (int)dr["NumNota"]);
                int idSer = (int)dr["IdServMed"];
                int idAno = (int)dr["Ano"];
                int idNumNota = (int)dr["NumNota"];
                int idProfessional = (int)dr["IdMed"];

                Ticket tk = new Ticket();
                tk.InsuranceService = (from ins in ctx.InsuranceServices
                                       where ins.Service.OftId == idSer
                                       select ins).FirstOrDefault<InsuranceService>();
                tk.ServiceNote = (from sn in ctx.ServiceNotes
                                  where sn.Oft_Ano == idAno && sn.Oft_NumNota == idNumNota
                                  select sn).FirstOrDefault<ServiceNote>();
                tk.Amount = (decimal)dr["Importe"];
                tk.Professional = (from p in ctx.Professionals
                                   where p.OftId == idProfessional
                                   select p).FirstOrDefault<Professional>();
                if (tk.ServiceNote.Professional == null)
                    tk.ServiceNote.Professional = tk.Professional;
                tk.Description = (string)dr["Descripcion"];
                tk.Clinic = cl;
                tk.TicketDate = tk.ServiceNote.ServiceNoteDate;
                // hay notas sin cliente, no deberia pero las hay
                if (tk.ServiceNote.Customer != null)
                    tk.Policy = tk.ServiceNote.Customer.Policies.FirstOrDefault<Policy>();
                ctx.Add(tk);
                ctx.SaveChanges();
            }

        }

        public static void ImportPaymentTypes(OleDbConnection con, AriClinicContext ctx)
        {
            //(1) Borrar antiguas formas de pago
            ctx.Delete(ctx.PaymentMethods);

            //(2) Lleer todos los pacientes en OFT
            string sql = "SELECT * FROM FormaPago";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConFPago");
            int nreg = ds.Tables["ConFPago"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConFPago"].Rows)
            {
                reg++;
                Console.WriteLine("Formas de pago {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomFormaPago"]);
                PaymentMethod pm = new PaymentMethod();
                pm.Name = (string)dr["NomFormaPago"];
                pm.OftId = (int)dr["IdFormaPago"];
                ctx.Add(pm);
            }
            ctx.SaveChanges();
        }

        public static void ImportPayments(OleDbConnection con, AriClinicContext ctx)
        {
            //(1) Borrar antiguos pagos
            ctx.Delete(ctx.Payments);
            foreach (Ticket tt in ctx.Tickets)
            {
                tt.Paid = 0;
            }
            ctx.SaveChanges();
            //(2) Obtener la clínica por defecto
            Clinic cl = ctx.Clinics.FirstOrDefault<Clinic>();

            //(3) Leer todos los pagos y darlos de alta.
            string sql = "SELECT * FROM LinNotaPago";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConPagos");
            int nreg = ds.Tables["ConPagos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConPagos"].Rows)
            {
                reg++;
                Console.WriteLine("Formas de pago {0:#####0} de {1:#####0} {2}", reg, nreg, "PAGOS");
                int id = (int)dr["IdFormaPago"];
                PaymentMethod pm = (from p in ctx.PaymentMethods
                                    where p.OftId == id
                                    select p).FirstOrDefault<PaymentMethod>();
                int idAno = (int)dr["Ano"];
                int idNumNota = (int)dr["NumNota"];
                ServiceNote note = (from n in ctx.ServiceNotes
                                    where n.Oft_Ano == idAno && n.Oft_NumNota == idNumNota
                                    select n).FirstOrDefault<ServiceNote>();

                bool res = CntAriCli.PayNote(pm, (decimal)dr["Importe"], (DateTime)dr["Fecha"], (string)dr["Descripcion"], note, cl, ctx);
                if (!res)
                {
                }
            }
        }

        public static void ImportAppointmentType(OleDbConnection con, AriClinicContext ctx)
        {
            //(1) Primero borrar citas y los tipos de cita anteriores
            ctx.Delete(ctx.AppointmentInfos);
            ctx.Delete(ctx.AppointmentTypes);

            //(2) Leer los tipos de OFT y darlos de alta en AriClinic
            string sql = "SELECT * FROM TiposCita";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConTiposCita");
            int nreg = ds.Tables["ConTiposCita"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConTiposCita"].Rows)
            {
                reg++;
                Console.WriteLine("Formas de pago {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomTipCit"]);
                int id = (int)dr["IdTipCit"];
                DateTime durac = (DateTime)dr["Durac"];
                AppointmentType apptype = new AppointmentType();
                apptype.Name = (string)dr["NomTipCit"];
                apptype.Duration = durac.Minute;
                apptype.OftId = id;
                ctx.Add(apptype);
            }
            ctx.SaveChanges();
        }

        public static void ImportDiary(OleDbConnection con, AriClinicContext ctx)
        {
            //(1) Borramos las agendas anteriores
            ctx.Delete(ctx.Diaries);

            //(2) Leer las agendas OFT y darlas de alta en AriClinic
            string sql = "SELECT * FROM LibrosCita";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConLibrosCita");
            int nreg = ds.Tables["ConLibrosCita"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConLibrosCita"].Rows)
            {
                reg++;
                Console.WriteLine("Formas de pago {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomLibCit"]);
                int id = (int)dr["IdLibCit"];
                Diary dia = new Diary();
                dia.BeginHour = (DateTime)dr["HrIni"];
                dia.EndHour = (DateTime)dr["HrFin"];
                dia.Name = (string)dr["NomLibCit"];
                dia.TimeStep = 10;
                dia.OftId = id;
                ctx.Add(dia);
            }
            ctx.SaveChanges();
        }

        public static void ImportAppointmentInfo(OleDbConnection con, AriClinicContext ctx)
        {
            //(1) Borramos las citas anteriores.
            ctx.Delete(ctx.AppointmentInfos);

            //(2) Leer las agendas OFT y darlas de alta en AriClinic
            string sql = "SELECT * FROM Citas";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConCitas");

            int nreg = ds.Tables["ConCitas"].Rows.Count;
            int reg = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            foreach (DataRow dr in ds.Tables["ConCitas"].Rows)
            {
                i3++;
                reg++;
                Console.WriteLine("Citas {0:#####0} de {1:#####0} {2}", reg, nreg, "CITAS");
                AppointmentInfo app = new AppointmentInfo();
                int id = (int)dr["IdTipCit"];
                app.AppointmentType = (from at in ctx.AppointmentTypes
                                       where at.OftId == id
                                       select at).FirstOrDefault<AppointmentType>();
                id = (int)dr["IdLibCit"];
                app.Diary = (from d in ctx.Diaries
                             where d.OftId == id
                             select d).FirstOrDefault<Diary>();
                id = (int)dr["NumHis"];
                app.Patient = (from p in ctx.Patients
                               where p.OftId == id
                               select p).FirstOrDefault<Patient>();
                id = (int)dr["IdMed"];
                app.Professional = (from pr in ctx.Professionals
                                    where pr.OftId == id
                                    select pr).FirstOrDefault<Professional>();

                i4++;
                DateTime dt = (DateTime)dr["Fecha"];
                DateTime ht = (DateTime)dr["Hora"];
                DateTime dd = new DateTime(dt.Year, dt.Month, dt.Day, ht.Hour, ht.Minute, ht.Second);
                app.BeginDateTime = dd;
                ht = (DateTime)dr["HrFin"];
                dd = new DateTime(dt.Year, dt.Month, dt.Day, ht.Hour, ht.Minute, ht.Second);
                app.EndDateTime = dd;
                ht = (DateTime)dr["Durac"];
                app.Duration = ht.Minute;
                if (app.Patient != null)
                {
                    i2++;
                    app.Subject = CntAriCli.GetAppointmentSubject(app);
                }
                else
                {
                    app.Subject = "SIN PACIENTE";
                }
                ctx.Add(app);
                ctx.SaveChanges();
            }

        }

        public static void ImportInvoices(OleDbConnection con, AriClinicContext ctx)
        {
            //(0) Delete previous invoices
            ctx.Delete(ctx.InvoiceLines);
            ctx.Delete(ctx.Invoices);

            //

            //(1) Read OFT invoices and import to Ariclinic
            string sql = "SELECT * FROM Factura";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConFacturas");
            int nreg = ds.Tables["ConFacturas"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConFacturas"].Rows)
            {
                reg++;
                Console.WriteLine("Facturas {0:#####0} de {1:#####0} {2}", reg, nreg, "FACTURAS 1");
                Invoice inv = new Invoice();
                inv.InvoiceDate = (DateTime)dr["Fecha"];
                inv.Year = (int)dr["Ano"];
                inv.InvoiceNumber = (int)dr["NumFactura"];
                inv.Serial = "F"; // we must to set serial parameter to "F"
                int id = (int)dr["NumHis"];
                inv.Customer = (from c in ctx.Customers
                                where c.OftId == id
                                select c).FirstOrDefault<Customer>();
                inv.Total = (decimal)dr["Total"];
                ctx.Add(inv);
                ctx.SaveChanges();
            }
            

            //(2) Importe invoice lines;
            int idTipoIva = 0;
            int idServMed = 0;
            int Ano = 0;
            int NumFac = 0;

            sql = "SELECT * FROM LinFactura";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConLineasFactura");
            nreg = ds.Tables["ConLineasFactura"].Rows.Count;
            reg = 0;
            foreach (DataRow dr in ds.Tables["ConLineasFactura"].Rows)
            {
                reg++;
                Console.WriteLine("Facturas 2 {0:#####0} de {1:#####0} {2}", reg, nreg, "FACTURAS 2");
                InvoiceLine il = new InvoiceLine();
                idTipoIva = (int)dr["IdTipoIva"];
                idServMed = (int)dr["IdServMed"];
                Ano = (int)dr["Ano"];
                NumFac = (int)dr["NumFactura"];
                TaxType tx = (from t in ctx.TaxTypes
                              where t.OftId == idTipoIva
                              select t).FirstOrDefault<TaxType>();
                Service sv = (from s in ctx.Services
                              where s.OftId == idServMed
                              select s).FirstOrDefault<Service>();
                sv.TaxType = tx;
                Invoice inv = (from iv in ctx.Invoices
                               where iv.Year == Ano && iv.InvoiceNumber == NumFac
                               select iv).FirstOrDefault<Invoice>();
                il.Invoice = inv;
                il.TaxType = tx;
                il.TaxPercentage = tx.Percentage;
                il.Amount = (decimal)dr["Importe"];
                il.Description = (string)dr["Descripcion"];
                ctx.Add(il);
                ctx.SaveChanges();
            }
            
        }

        public static void ImportVisitReasons(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.VisitReasons);

            // (1) Dar de alta los tipos de IVA importados.
            string sql = "SELECT * FROM Motivos";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConMotivos");
            int nreg = ds.Tables["ConMotivos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConMotivos"].Rows)
            {
                reg++;
                Console.WriteLine("Motivos visita {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomMot"]);
                VisitReason vr = new VisitReason();
                vr.Name = (string)dr["NomMot"];
                vr.OftId = (int)dr["IdMot"];
                ctx.Add(vr);
            }
            ctx.SaveChanges();
        }

        public static void ImportVisits(OleDbConnection con, AriClinicContext ctx)
        {
            int id = 0;
            // (0) Borra tipos previos
            ctx.Delete(ctx.MotAppends);
            ctx.Delete(ctx.AntSegments);
            ctx.Delete(ctx.Fundus);
            ctx.Delete(ctx.OphthalmologicVisits);
            ctx.Delete(ctx.BaseVisits);
            ctx.SaveChanges();

            // (1) Dar de alta las visitas importadas
            string sql = "SELECT * FROM HistVisitas";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConVisitas");
            int nreg = ds.Tables["ConVisitas"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConVisitas"].Rows)
            {
                reg++;
                Console.WriteLine("Visitas {0:#####0} de {1:#####0} {2}", reg, nreg, "VISITAS");
                BaseVisit visit = new BaseVisit();
                visit.OftRefVisita = (int)dr["RefVisita"];
                visit.VisitDate = (DateTime)dr["Fecha"];
                id = (int)dr["IdTipCit"];
                visit.AppointmentType = (from apt in ctx.AppointmentTypes
                                         where apt.OftId == id
                                         select apt).FirstOrDefault<AppointmentType>();
                id = (int)dr["IdMot"];
                visit.VisitReason = (from vr in ctx.VisitReasons
                                     where vr.OftId == id
                                     select vr).FirstOrDefault<VisitReason>();
                id = (int)dr["IdMed"];
                visit.Professional = (from p in ctx.Professionals
                                      where p.OftId == id
                                      select p).FirstOrDefault<Professional>();
                id = (int)dr["NumHis"];
                visit.Patient = (from p in ctx.Patients
                                 where p.OftId == id
                                 select p).FirstOrDefault<Patient>();
                if (dr["Observaciones"] != DBNull.Value)
                    visit.Comments = (string)dr["Observaciones"];
                if ((decimal)(float)dr["TOOD"] != 0 || (decimal)(float)dr["TOOI"] != 0)
                {
                    OphthalmologicVisit ophVisit = new OphthalmologicVisit();
                    ophVisit.OftRefVisita = visit.OftRefVisita;
                    ophVisit.AppointmentType = visit.AppointmentType;
                    ophVisit.VisitReason = visit.VisitReason;
                    ophVisit.VisitDate = visit.VisitDate;
                    ophVisit.Patient = visit.Patient;
                    ophVisit.Professional = visit.Professional;
                    ophVisit.Comments = visit.Comments;
                    ophVisit.VType = "ophvisit";
                    ctx.Add(ophVisit);
                    ctx.SaveChanges();

                    // Motilidad y anejos
                    MotAppend mot = new MotAppend();
                    if (dr["MotOcular"] != DBNull.Value)
                        mot.EyeMotility = (string)dr["MotOcular"];
                    if (dr["cejas"] != DBNull.Value)
                        mot.Eyebrows = (string)dr["Cejas"];
                    if (dr["AreaPeriocular"] != DBNull.Value)
                        mot.PeriocularArea = (string)dr["AreaPeriocular"];
                    mot.C1RE = (decimal)(float)dr["C1OD"];
                    mot.C1LE = (decimal)(float)dr["C1OI"];
                    mot.C2RE = (decimal)(float)dr["C2OD"];
                    mot.C2LE = (decimal)(float)dr["C2OI"];
                    mot.C3RE = (decimal)(float)dr["C3OD"];
                    mot.C3LE = (decimal)(float)dr["C3OI"];
                    mot.C4RE = (decimal)(float)dr["C4OD"];
                    mot.C4LE = (decimal)(float)dr["C4OI"];
                    mot.C5RE = (decimal)(float)dr["C5OD"];
                    mot.C5LE = (decimal)(float)dr["C5OI"];
                    mot.C6RE = (decimal)(float)dr["C6OD"];
                    mot.C6LE = (decimal)(float)dr["C6OI"];
                    mot.C7RE = (decimal)(float)dr["C7OD"];
                    mot.C7LE = (decimal)(float)dr["C7OI"];
                    mot.C8RE = (decimal)(float)dr["C8OD"];
                    mot.C8LE = (decimal)(float)dr["C8OI"];
                    mot.C9RE = (decimal)(float)dr["C9OD"];
                    mot.C9LE = (decimal)(float)dr["C9OI"];
                    mot.C10RE = (decimal)(float)dr["C10OD"];
                    mot.C10LE = (decimal)(float)dr["C10OI"];
                    mot.C11RE = (decimal)(float)dr["C11OD"];
                    mot.C11LE = (decimal)(float)dr["C11OI"];
                    mot.C12RE = (decimal)(float)dr["C12OD"];
                    mot.C12LE = (decimal)(float)dr["C12OI"];
                    mot.OphthalmologicVisit = ophVisit;
                    ctx.Add(mot);
                    ctx.SaveChanges();

                    // Segmento anterior
                    AntSegment ant = new AntSegment();
                    if (dr["ObsParpados"] != DBNull.Value)
                        ant.EyebrowsComments = (string)dr["ObsParpados"];
                    if (dr["Conjuntiva"].GetType() == typeof(DBNull))
                    {
                    }
                    if (dr["Conjuntiva"] != DBNull.Value)
                        ant.Conjunctiva = (string)dr["Conjuntiva"];
                    if (dr["Cornea"] != DBNull.Value)
                        ant.Cornea = (string)dr["Cornea"];
                    if (dr["Camara"] != DBNull.Value)
                        ant.Chamber = (string)dr["Camara"];
                    if (dr["Tyndall"] != DBNull.Value)
                        ant.Tyndall = (string)dr["Tyndall"];
                    if (dr["Pupila"] != DBNull.Value)
                        ant.Pupil = (string)dr["Pupila"];
                    if (dr["Cristalino"] != DBNull.Value)
                        ant.Crystalline = (string)dr["Cristalino"];
                    ant.EyestrainLE = (decimal)(float)dr["TOOI"];
                    ant.EyestrainRE = (decimal)(float)dr["TOOD"];
                    ant.OphthalmologicVisit = ophVisit;
                    ctx.Add(ant);
                    ctx.SaveChanges();

                    // Fondo de ojo
                    Fundus fundus = new Fundus();
                    if (dr["NervioOptico"] != DBNull.Value)
                        fundus.OpticNerve = (string)dr["NervioOptico"];
                    if (dr["Vasos"] != DBNull.Value)
                        fundus.Vessels = (string)dr["Vasos"];
                    if (dr["Macula"] != DBNull.Value)
                        fundus.Macula = (string)dr["Macula"];
                    if (dr["Vitreo"] != DBNull.Value)
                        fundus.Vitreous = (string)dr["Vitreo"];
                    if (dr["Periferia"] != DBNull.Value)
                        fundus.Periphery = (string)dr["Periferia"];
                    fundus.OphthalmologicVisit = ophVisit;
                    ctx.Add(fundus);
                    ctx.SaveChanges();
                }
                else
                {
                    visit.VType = "general";
                    ctx.Add(visit);
                    ctx.SaveChanges();
                }
            }
        }

        public static void ImportDiagnostics(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.DiagnosticAssigneds);
            ctx.Delete(ctx.Diagnostics);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM Diagnosticos";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConDiagnosticos");
            int nreg = ds.Tables["ConDiagnosticos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConDiagnosticos"].Rows)
            {
                reg++;
                Console.WriteLine("Diagnósticos {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomDiag"]);
                Diagnostic diag = new Diagnostic();
                diag.OftId = (int)dr["IdDiag"];
                diag.Name = (string)dr["NomDiag"];
                ctx.Add(diag);
                ctx.SaveChanges();
            }
        }

        public static void ImportDiagnosticsAssigned(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.DiagnosticAssigneds);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM HistDiag";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConDiagnosticos");
            int nreg = ds.Tables["ConDiagnosticos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConDiagnosticos"].Rows)
            {
                reg++;
                Console.WriteLine("Diagnósticos asignados {0:#####0} de {1:#####0} {2}", reg, nreg, "DG ASIGNADOS");
                DiagnosticAssigned das = new DiagnosticAssigned();
                int id = (int)dr["IdDiag"];
                Diagnostic diag = (from d in ctx.Diagnostics
                                   where d.OftId == id
                                   select d).FirstOrDefault<Diagnostic>();
                id = (int)dr["NumHis"];
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == id
                                   select p).FirstOrDefault<Patient>();
                das.Patient = patient;
                das.Diagnostic = diag;
                if ((int)dr["TipoProc"] == 1)
                {
                    id = (int)dr["ExtProc"];
                    das.BaseVisit = (from v in ctx.BaseVisits
                                     where v.OftRefVisita == id
                                     select v).FirstOrDefault<BaseVisit>();
                }
                das.DiagnosticDate = (DateTime)dr["Fecha"];
                das.Comments = (string)dr["Observa"];
                ctx.Add(das);
                ctx.SaveChanges();
            }
        }

        public static void ImportExaminations(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.WithoutGlassesTests);
            ctx.Delete(ctx.GlassesTests);
            ctx.Delete(ctx.ContactLensesTests);
            ctx.Delete(ctx.OpticalObjectiveExaminations);
            ctx.Delete(ctx.SubjectiveOpticalExaminations);
            ctx.Delete(ctx.Cycloplegias);
            ctx.Delete(ctx.PrescriptionGlasses);

            ctx.Delete(ctx.Refractometries);
            ctx.Delete(ctx.Biometries);
            ctx.Delete(ctx.Paquimetries);
            ctx.Delete(ctx.Topographies);

            ctx.Delete(ctx.ExaminationAssigneds);
            ctx.Delete(ctx.Examinations);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM Exploraciones";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConExploraciones");
            int nreg = ds.Tables["ConExploraciones"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConExploraciones"].Rows)
            {
                reg++;
                Console.WriteLine("Exploraciones {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomExEs"]);
                Examination exam = new Examination();
                exam.OftId = (int)dr["IdExEs"];
                exam.Name = (string)dr["NomExEs"];
                int tp = (int)dr["Tipo"];
                exam.ExaminationType = CntAriCli.GetExaminationType("general", ctx);
                switch (tp)
                {
                    case 1:
                        exam.ExaminationType = CntAriCli.GetExaminationType("refractometry", ctx);
                        break;
                    case 2:
                        exam.ExaminationType = CntAriCli.GetExaminationType("biometry", ctx);
                        break;
                    case 3:
                        exam.ExaminationType = CntAriCli.GetExaminationType("paquimetry", ctx);
                        break;
                    case 4:
                        exam.ExaminationType = CntAriCli.GetExaminationType("topography", ctx);
                        break;
                }
                ctx.Add(exam);
                ctx.SaveChanges();
            }
        }

        public static void ImportExaminationsAssigned(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.WithoutGlassesTests);
            ctx.Delete(ctx.GlassesTests);
            ctx.Delete(ctx.ContactLensesTests);
            ctx.Delete(ctx.OpticalObjectiveExaminations);
            ctx.Delete(ctx.SubjectiveOpticalExaminations);
            ctx.Delete(ctx.Cycloplegias);
            ctx.Delete(ctx.PrescriptionGlasses);

            ctx.Delete(ctx.Refractometries);
            ctx.Delete(ctx.Biometries);
            ctx.Delete(ctx.Paquimetries);
            ctx.Delete(ctx.Topographies);

            ctx.Delete(ctx.ExaminationAssigneds);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM HistExplor";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConExploraciones");
            int nreg = ds.Tables["ConExploraciones"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConExploraciones"].Rows)
            {
                reg++;
                Console.WriteLine("Exploraciones asignadas {0:#####0} de {1:#####0} {2}", reg, nreg, "EXPASG");
                ExaminationAssigned examas = new ExaminationAssigned();
                int id = (int)dr["NumHis"];
                examas.Patient = (from p in ctx.Patients
                                  where p.OftId == id
                                  select p).FirstOrDefault<Patient>();
                id = (int)dr["IdExEs"];
                examas.Examination = (from ex in ctx.Examinations
                                      where ex.OftId == id
                                      select ex).FirstOrDefault<Examination>();
                examas.ExaminationDate = (DateTime)dr["Fecha"];
                examas.Comments = (string)dr["Hallazgos"];
                if ((int)dr["TipoProc"] == 1)
                {
                    id = (int)dr["ExtProc"];
                    examas.BaseVisit = (from bs in ctx.BaseVisits
                                        where bs.OftRefVisita == id
                                        select bs).FirstOrDefault<BaseVisit>();
                }
                switch (examas.Examination.ExaminationType.Code)
                {
                    case "general":
                        ctx.Add(examas);
                        ctx.SaveChanges();
                        break;
                    case "refractometry":
                        Refractometry refra = new Refractometry();
                        refra.Patient = examas.Patient;
                        refra.Examination = examas.Examination;
                        refra.ExaminationDate = examas.ExaminationDate;
                        refra.BaseVisit = examas.BaseVisit;
                        refra.Comments = examas.Comments;
                        id = (int)dr["ExtExEs"];
                        ProcessRefractometry(id, refra, con, ctx);
                        ctx.Add(refra);
                        ctx.SaveChanges();
                        break;
                    case "paquimetry":
                        Paquimetry paq = new Paquimetry();
                        paq.Patient = examas.Patient;
                        paq.Examination = examas.Examination;
                        paq.ExaminationDate = examas.ExaminationDate;
                        paq.BaseVisit = examas.BaseVisit;
                        paq.Comments = examas.Comments;
                        id = (int)dr["ExtExEs"];
                        ProcessPaquimetry(id, paq, con, ctx);
                        ctx.Add(paq);
                        ctx.SaveChanges();
                        break;
                    case "biometry":
                        Biometry bio = new Biometry();
                        bio.Patient = examas.Patient;
                        bio.Examination = examas.Examination;
                        bio.ExaminationDate = examas.ExaminationDate;
                        bio.BaseVisit = examas.BaseVisit;
                        bio.Comments = examas.Comments;
                        ctx.Add(bio);
                        ctx.SaveChanges();
                        break;
                    case "topography":
                        Topography top = new Topography();
                        top.Patient = examas.Patient;
                        top.Examination = examas.Examination;
                        top.ExaminationDate = examas.ExaminationDate;
                        top.BaseVisit = examas.BaseVisit;
                        top.Comments = examas.Comments;
                        ctx.Add(top);
                        ctx.SaveChanges();
                        break;
                }
            }
        }

        public static void ProcessRefractometry(int id, Refractometry rf, OleDbConnection con, AriClinicContext ctx)
        {
            // WithoutGlasses
            string sql = String.Format("SELECT * FROM SNGRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConSNGRefracto");
            if (ds.Tables["ConSNGRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConSNGRefracto"].Rows[0];
                WithoutGlassesTest wt = new WithoutGlassesTest();
                wt.Refractometry = rf;
                if (dr["SNGLejAVisOD"] != DBNull.Value) wt.FarVisualAcuityRightEye = (string)dr["SNGLejAVisOD"];
                if (dr["SNGLejAVisOI"] != DBNull.Value) wt.FarVisualAcuityLeftEye = (string)dr["SNGLejAVisOI"];
                if (dr["SNGLejAVisAO"] != DBNull.Value) wt.FarVisualAcuityBothEyes = (string)dr["SNGLejAVisAO"];
                if (dr["SNGCerAVisOD"] != DBNull.Value) wt.CloseVisualAcuityRightEye = (string)dr["SNGCerAVisOD"];
                if (dr["SNGCerAVisOI"] != DBNull.Value) wt.CloseVisualAcuityLeftEye = (string)dr["SNGCerAVisOI"];
                if (dr["SNGCerAVisAO"] != DBNull.Value) wt.CloseVisualAcuityBothEyes = (string)dr["SNGCerAVisAO"];
                if (dr["SNGObs"] != DBNull.Value)
                    wt.Comments = (string)dr["SNGObs"];
                ctx.Add(wt);
                ctx.SaveChanges();
            }

            //Glasses Test
            sql = String.Format("SELECT * FROM SGRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConSGRefracto");
            if (ds.Tables["ConSGRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConSGRefracto"].Rows[0];
                GlassesTest gt = new GlassesTest();
                gt.Refractometry = rf;
                if (dr["SGLejAVisOD"] != DBNull.Value) gt.FarVisualAcuityRightEye = (string)dr["SGLejAVisOD"];
                if (dr["SGTuAVisOD"] != DBNull.Value) gt.BothAcuityRightEye = (string)dr["SGTuAVisOD"];
                if (dr["SGCerAVisOD"] != DBNull.Value) gt.CloseAcuityRightEye = (string)dr["SGCerAVisOD"];

                if (dr["SGLejAVisOI"] != DBNull.Value) gt.FarVisualAcuityLeftEye = (string)dr["SGLejAVisOI"];
                if (dr["SGTuAVisOI"] != DBNull.Value) gt.BothAcuityLeftEye = (string)dr["SGTuAVisOI"];
                if (dr["SGCerAVisOI"] != DBNull.Value) gt.CloseAcuityLeftEye = (string)dr["SGCerAVisOI"];

                if (dr["SGObs"] != DBNull.Value) gt.Comments = (string)dr["SGObs"];

                if (dr["SGLeEsfOD"] != DBNull.Value) gt.FarSphericityRightEye = (string)dr["SGLeEsfOD"];
                if (dr["SGLeCilOD"] != DBNull.Value) gt.FarCylinderRightEye = (string)dr["SGLeCilOD"];
                if (dr["SGLeEjeOD"] != DBNull.Value) gt.FarAxisRightEye = (string)dr["SGLeEjeOD"];
                if (dr["SGLePrisOD"] != DBNull.Value) gt.FarPrimsRightEye = (string)dr["SGLePrisOD"];

                if (dr["SGLeEsfOI"] != DBNull.Value) gt.FarSphericityLeftEye = (string)dr["SGLeEsfOI"];
                if (dr["SGLeCilOI"] != DBNull.Value) gt.FarCylinderLeftEye = (string)dr["SGLeCilOI"];
                if (dr["SGLeEjeOI"] != DBNull.Value) gt.FarAxisLeftEye = (string)dr["SGLeEjeOI"];
                if (dr["SGLePrisOI"] != DBNull.Value) gt.FarPrismLeftEye = (string)dr["SGLePrisOI"];

                if (dr["SGLeCent"] != DBNull.Value) gt.FarCenters = (string)dr["SGLeCent"];
                if (dr["SGLeAVis"] != DBNull.Value) gt.FarAcuity = (string)dr["SGLeAVis"];

                if (dr["SGTuEsfOD"] != DBNull.Value) gt.BothSphericityRightEye = (string)dr["SGTuEsfOD"];
                if (dr["SGTuCilOD"] != DBNull.Value) gt.BothCylinderRightEye = (string)dr["SGTuCilOD"];
                if (dr["SGTuEjeOD"] != DBNull.Value) gt.BothAxisRightEye = (string)dr["SGTuEjeOD"];
                if (dr["SGTuPrisOD"] != DBNull.Value) gt.BothPrismRightEye = (string)dr["SGTuPrisOD"];
                //
                if (dr["SGTuEsfOI"] != DBNull.Value) gt.BothSphericityLeftEye = (string)dr["SGTuEsfOI"];
                if (dr["SGTuCilOI"] != DBNull.Value) gt.BothCylinderLeftEye = (string)dr["SGTuCilOI"];
                if (dr["SGTuEjeOI"] != DBNull.Value) gt.BothAxisLeftEye = (string)dr["SGTuEjeOI"];
                if (dr["SGTuPrisOI"] != DBNull.Value) gt.BothPrismLeftEye = (string)dr["SGTuPrisOI"];

                if (dr["SGTuCent"] != DBNull.Value) gt.BothCenters = (string)dr["SGTuCent"];
                if (dr["SGTuAVis"] != DBNull.Value) gt.BothAcuity = (string)dr["SGTuAVis"];

                if (dr["SGCerEsfOD"] != DBNull.Value) gt.CloseSphericityRightEye = (string)dr["SGCerEsfOD"];
                if (dr["SGCerCilOD"] != DBNull.Value) gt.CloseCylinderRightEye = (string)dr["SGCerCilOD"];
                if (dr["SGCerEjeOD"] != DBNull.Value) gt.CloseAxisRightEye = (string)dr["SGCerEjeOD"];
                if (dr["SGCerPrisOD"] != DBNull.Value) gt.ClosePrismRightEye = (string)dr["SGCerEjeOD"];

                if (dr["SGCerEsfOI"] != DBNull.Value) gt.CloseSphericityLeftEye = (string)dr["SGCerEsfOI"];
                if (dr["SGCerCilOI"] != DBNull.Value) gt.CloseCylinderLeftEye = (string)dr["SGCerCilOI"];
                if (dr["SGCerEjeOI"] != DBNull.Value) gt.CloseAxisLeftEye = (string)dr["SGCerEjeOI"];
                if (dr["SGCerPrisOI"] != DBNull.Value) gt.ClosePrismLeftEye = (string)dr["SGCerEjeOI"];

                if (dr["SGCerCent"] != DBNull.Value) gt.CloseCenters = (string)dr["SGCerCent"];
                if (dr["SGCerAVis"] != DBNull.Value) gt.CloseAcuity = (string)dr["SGCerAVis"];

                ctx.Add(gt);
                ctx.SaveChanges();
            }

            // Contact Lenses test
            sql = String.Format("SELECT * FROM LCRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConSNGRefracto");
            if (ds.Tables["ConSNGRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConSNGRefracto"].Rows[0];
                ContactLensesTest lt = new ContactLensesTest();
                lt.Refractometry = rf;
                if (dr["LCLejAVisOD"] != DBNull.Value) lt.FarVisualAcuityRightEye = (string)dr["LCLejAVisOD"];
                if (dr["LCLejAVisOI"] != DBNull.Value) lt.FarVisualAcuityLeftEye = (string)dr["LCLejAVisOI"];
                if (dr["LCLejAVisAO"] != DBNull.Value) lt.FarVisualAcuityBothEyes = (string)dr["LCLejAVisAO"];
                if (dr["LCCerAVisOD"] != DBNull.Value) lt.CloseVisualAcuityRightEye = (string)dr["LCCerAVisOD"];
                if (dr["LCCerAVisOI"] != DBNull.Value) lt.CloseVisualAcuityLeftEye = (string)dr["LCCerAVisOI"];
                if (dr["LCCerAVisAO"] != DBNull.Value) lt.CloseVisualAcuityBothEyes = (string)dr["LCCerAVisAO"];
                if (dr["LCObs"] != DBNull.Value)
                    lt.Comments = (string)dr["LCObs"];
                ctx.Add(lt);
                ctx.SaveChanges();
            }

            //Objective optical examination
            sql = String.Format("SELECT * FROM OBJRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConOBJRefracto");
            if (ds.Tables["ConOBJRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConOBJRefracto"].Rows[0];
                OpticalObjectiveExamination ot = new OpticalObjectiveExamination();
                ot.Refractometry = rf;
                if (dr["OBJLejAVisOD"] != DBNull.Value) ot.FarVisualAcuityRightEye = (string)dr["OBJLejAVisOD"];
                if (dr["OBJTuAVisOD"] != DBNull.Value) ot.BothAcuityRightEye = (string)dr["OBJTuAVisOD"];
                if (dr["OBJCerAVisOD"] != DBNull.Value) ot.CloseAcuityRightEye = (string)dr["OBJCerAVisOD"];

                if (dr["OBJLejAVisOI"] != DBNull.Value) ot.FarVisualAcuityLeftEye = (string)dr["OBJLejAVisOI"];
                if (dr["OBJTuAVisOI"] != DBNull.Value) ot.BothAcuityLeftEye = (string)dr["OBJTuAVisOI"];
                if (dr["OBJCerAVisOI"] != DBNull.Value) ot.CloseAcuityLeftEye = (string)dr["OBJCerAVisOI"];

                if (dr["OBJObs"] != DBNull.Value) ot.Comments = (string)dr["OBJObs"];

                if (dr["OBJLeEsfOD"] != DBNull.Value) ot.FarSphericityRightEye = (string)dr["OBJLeEsfOD"];
                if (dr["OBJLeCilOD"] != DBNull.Value) ot.FarCylinderRightEye = (string)dr["OBJLeCilOD"];
                if (dr["OBJLeEjeOD"] != DBNull.Value) ot.FarAxisRightEye = (string)dr["OBJLeEjeOD"];
                if (dr["OBJLePrisOD"] != DBNull.Value) ot.FarPrimsRightEye = (string)dr["OBJLePrisOD"];

                if (dr["OBJLeEsfOI"] != DBNull.Value) ot.FarSphericityLeftEye = (string)dr["OBJLeEsfOI"];
                if (dr["OBJLeCilOI"] != DBNull.Value) ot.FarCylinderLeftEye = (string)dr["OBJLeCilOI"];
                if (dr["OBJLeEjeOI"] != DBNull.Value) ot.FarAxisLeftEye = (string)dr["OBJLeEjeOI"];
                if (dr["OBJLePrisOI"] != DBNull.Value) ot.FarPrismLeftEye = (string)dr["OBJLePrisOI"];

                if (dr["OBJLeCent"] != DBNull.Value) ot.FarCenters = (string)dr["OBJLeCent"];
                if (dr["OBJLeAVis"] != DBNull.Value) ot.FarAcuity = (string)dr["OBJLeAVis"];

                if (dr["OBJTuEsfOD"] != DBNull.Value) ot.BothSphericityRightEye = (string)dr["OBJTuEsfOD"];
                if (dr["OBJTuCilOD"] != DBNull.Value) ot.BothCylinderRightEye = (string)dr["OBJTuCilOD"];
                if (dr["OBJTuEjeOD"] != DBNull.Value) ot.BothAxisRightEye = (string)dr["OBJTuEjeOD"];
                if (dr["OBJTuPrisOD"] != DBNull.Value) ot.BothPrismRightEye = (string)dr["OBJTuPrisOD"];
                //
                if (dr["OBJTuEsfOI"] != DBNull.Value) ot.BothSphericityLeftEye = (string)dr["OBJTuEsfOI"];
                if (dr["OBJTuCilOI"] != DBNull.Value) ot.BothCylinderLeftEye = (string)dr["OBJTuCilOI"];
                if (dr["OBJTuEjeOI"] != DBNull.Value) ot.BothAxisLeftEye = (string)dr["OBJTuEjeOI"];
                if (dr["OBJTuPrisOI"] != DBNull.Value) ot.BothPrismLeftEye = (string)dr["OBJTuPrisOI"];

                if (dr["OBJTuCent"] != DBNull.Value) ot.BothCenters = (string)dr["OBJTuCent"];
                if (dr["OBJTuAVis"] != DBNull.Value) ot.BothAcuity = (string)dr["OBJTuAVis"];

                if (dr["OBJCerEsfOD"] != DBNull.Value) ot.CloseSphericityRightEye = (string)dr["OBJCerEsfOD"];
                if (dr["OBJCerCilOD"] != DBNull.Value) ot.CloseCylinderRightEye = (string)dr["OBJCerCilOD"];
                if (dr["OBJCerEjeOD"] != DBNull.Value) ot.CloseAxisRightEye = (string)dr["OBJCerEjeOD"];
                if (dr["OBJCerPrisOD"] != DBNull.Value) ot.ClosePrismRightEye = (string)dr["OBJCerEjeOD"];

                if (dr["OBJCerEsfOI"] != DBNull.Value) ot.CloseSphericityLeftEye = (string)dr["OBJCerEsfOI"];
                if (dr["OBJCerCilOI"] != DBNull.Value) ot.CloseCylinderLeftEye = (string)dr["OBJCerCilOI"];
                if (dr["OBJCerEjeOI"] != DBNull.Value) ot.CloseAxisLeftEye = (string)dr["OBJCerEjeOI"];
                if (dr["OBJCerPrisOI"] != DBNull.Value) ot.ClosePrismLeftEye = (string)dr["OBJCerEjeOI"];

                if (dr["OBJCerCent"] != DBNull.Value) ot.CloseCenters = (string)dr["OBJCerCent"];
                if (dr["OBJCerAVis"] != DBNull.Value) ot.CloseAcuity = (string)dr["OBJCerAVis"];

                if (dr["K1D"] != DBNull.Value) ot.K1RightEye = (string)dr["K1D"];
                if (dr["K1I"] != DBNull.Value) ot.K1LeftEye = (string)dr["K1I"];
                if (dr["K2D"] != DBNull.Value) ot.K2RightEye = (string)dr["K2D"];
                if (dr["K2I"] != DBNull.Value) ot.K2LeftEye = (string)dr["K2I"];

                ctx.Add(ot);
                ctx.SaveChanges();
            }


            //Subjective optical examination
            sql = String.Format("SELECT * FROM SUBRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConSUBRefracto");
            if (ds.Tables["ConSUBRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConSUBRefracto"].Rows[0];
                SubjectiveOpticalExamination sub = new SubjectiveOpticalExamination();
                sub.Refractometry = rf;
                if (dr["SUBLejAVisOD"] != DBNull.Value) sub.FarVisualAcuityRightEye = (string)dr["SUBLejAVisOD"];
                if (dr["SUBTuAVisOD"] != DBNull.Value) sub.BothAcuityRightEye = (string)dr["SUBTuAVisOD"];
                if (dr["SUBCerAVisOD"] != DBNull.Value) sub.CloseAcuityRightEye = (string)dr["SUBCerAVisOD"];

                if (dr["SUBLejAVisOI"] != DBNull.Value) sub.FarVisualAcuityLeftEye = (string)dr["SUBLejAVisOI"];
                if (dr["SUBTuAVisOI"] != DBNull.Value) sub.BothAcuityLeftEye = (string)dr["SUBTuAVisOI"];
                if (dr["SUBCerAVisOI"] != DBNull.Value) sub.CloseAcuityLeftEye = (string)dr["SUBCerAVisOI"];

                if (dr["SUBObs"] != DBNull.Value) sub.Comments = (string)dr["SUBObs"];

                if (dr["SUBLeEsfOD"] != DBNull.Value) sub.FarSphericityRightEye = (string)dr["SUBLeEsfOD"];
                if (dr["SUBLeCilOD"] != DBNull.Value) sub.FarCylinderRightEye = (string)dr["SUBLeCilOD"];
                if (dr["SUBLeEjeOD"] != DBNull.Value) sub.FarAxisRightEye = (string)dr["SUBLeEjeOD"];
                if (dr["SUBLePrisOD"] != DBNull.Value) sub.FarPrimsRightEye = (string)dr["SUBLePrisOD"];

                if (dr["SUBLeEsfOI"] != DBNull.Value) sub.FarSphericityLeftEye = (string)dr["SUBLeEsfOI"];
                if (dr["SUBLeCilOI"] != DBNull.Value) sub.FarCylinderLeftEye = (string)dr["SUBLeCilOI"];
                if (dr["SUBLeEjeOI"] != DBNull.Value) sub.FarAxisLeftEye = (string)dr["SUBLeEjeOI"];
                if (dr["SUBLePrisOI"] != DBNull.Value) sub.FarPrismLeftEye = (string)dr["SUBLePrisOI"];

                if (dr["SUBLeCent"] != DBNull.Value) sub.FarCenters = (string)dr["SUBLeCent"];
                if (dr["SUBLeAVis"] != DBNull.Value) sub.FarAcuity = (string)dr["SUBLeAVis"];

                if (dr["SUBTuEsfOD"] != DBNull.Value) sub.BothSphericityRightEye = (string)dr["SUBTuEsfOD"];
                if (dr["SUBTuCilOD"] != DBNull.Value) sub.BothCylinderRightEye = (string)dr["SUBTuCilOD"];
                if (dr["SUBTuEjeOD"] != DBNull.Value) sub.BothAxisRightEye = (string)dr["SUBTuEjeOD"];
                if (dr["SUBTuPrisOD"] != DBNull.Value) sub.BothPrismRightEye = (string)dr["SUBTuPrisOD"];
                //
                if (dr["SUBTuEsfOI"] != DBNull.Value) sub.BothSphericityLeftEye = (string)dr["SUBTuEsfOI"];
                if (dr["SUBTuCilOI"] != DBNull.Value) sub.BothCylinderLeftEye = (string)dr["SUBTuCilOI"];
                if (dr["SUBTuEjeOI"] != DBNull.Value) sub.BothAxisLeftEye = (string)dr["SUBTuEjeOI"];
                if (dr["SUBTuPrisOI"] != DBNull.Value) sub.BothPrismLeftEye = (string)dr["SUBTuPrisOI"];

                if (dr["SUBTuCent"] != DBNull.Value) sub.BothCenters = (string)dr["SUBTuCent"];
                if (dr["SUBTuAVis"] != DBNull.Value) sub.BothAcuity = (string)dr["SUBTuAVis"];

                if (dr["SUBCerEsfOD"] != DBNull.Value) sub.CloseSphericityRightEye = (string)dr["SUBCerEsfOD"];
                if (dr["SUBCerCilOD"] != DBNull.Value) sub.CloseCylinderRightEye = (string)dr["SUBCerCilOD"];
                if (dr["SUBCerEjeOD"] != DBNull.Value) sub.CloseAxisRightEye = (string)dr["SUBCerEjeOD"];
                if (dr["SUBCerPrisOD"] != DBNull.Value) sub.ClosePrismRightEye = (string)dr["SUBCerEjeOD"];

                if (dr["SUBCerEsfOI"] != DBNull.Value) sub.CloseSphericityLeftEye = (string)dr["SUBCerEsfOI"];
                if (dr["SUBCerCilOI"] != DBNull.Value) sub.CloseCylinderLeftEye = (string)dr["SUBCerCilOI"];
                if (dr["SUBCerEjeOI"] != DBNull.Value) sub.CloseAxisLeftEye = (string)dr["SUBCerEjeOI"];
                if (dr["SUBCerPrisOI"] != DBNull.Value) sub.ClosePrismLeftEye = (string)dr["SUBCerEjeOI"];

                if (dr["SUBCerCent"] != DBNull.Value) sub.CloseCenters = (string)dr["SUBCerCent"];
                if (dr["SUBCerAVis"] != DBNull.Value) sub.CloseAcuity = (string)dr["SUBCerAVis"];

                ctx.Add(sub);
                ctx.SaveChanges();
            }

            //Cicloplegia
            sql = String.Format("SELECT * FROM CPLRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConCPLRefracto");
            if (ds.Tables["ConCPLRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConCPLRefracto"].Rows[0];
                Cycloplegia cpl = new Cycloplegia();
                cpl.Refractometry = rf;
                if (dr["CPLLejAVisOD"] != DBNull.Value) cpl.FarVisualAcuityRightEye = (string)dr["CPLLejAVisOD"];
                if (dr["CPLTuAVisOD"] != DBNull.Value) cpl.BothAcuityRightEye = (string)dr["CPLTuAVisOD"];
                if (dr["CPLCerAVisOD"] != DBNull.Value) cpl.CloseAcuityRightEye = (string)dr["CPLCerAVisOD"];

                if (dr["CPLLejAVisOI"] != DBNull.Value) cpl.FarVisualAcuityLeftEye = (string)dr["CPLLejAVisOI"];
                if (dr["CPLTuAVisOI"] != DBNull.Value) cpl.BothAcuityLeftEye = (string)dr["CPLTuAVisOI"];
                if (dr["CPLCerAVisOI"] != DBNull.Value) cpl.CloseAcuityLeftEye = (string)dr["CPLCerAVisOI"];

                if (dr["CPLObs"] != DBNull.Value) cpl.Comments = (string)dr["CPLObs"];

                if (dr["CPLLeEsfOD"] != DBNull.Value) cpl.FarSphericityRightEye = (string)dr["CPLLeEsfOD"];
                if (dr["CPLLeCilOD"] != DBNull.Value) cpl.FarCylinderRightEye = (string)dr["CPLLeCilOD"];
                if (dr["CPLLeEjeOD"] != DBNull.Value) cpl.FarAxisRightEye = (string)dr["CPLLeEjeOD"];
                if (dr["CPLLePrisOD"] != DBNull.Value) cpl.FarPrimsRightEye = (string)dr["CPLLePrisOD"];

                if (dr["CPLLeEsfOI"] != DBNull.Value) cpl.FarSphericityLeftEye = (string)dr["CPLLeEsfOI"];
                if (dr["CPLLeCilOI"] != DBNull.Value) cpl.FarCylinderLeftEye = (string)dr["CPLLeCilOI"];
                if (dr["CPLLeEjeOI"] != DBNull.Value) cpl.FarAxisLeftEye = (string)dr["CPLLeEjeOI"];
                if (dr["CPLLePrisOI"] != DBNull.Value) cpl.FarPrismLeftEye = (string)dr["CPLLePrisOI"];

                if (dr["CPLLeCent"] != DBNull.Value) cpl.FarCenters = (string)dr["CPLLeCent"];
                if (dr["CPLLeAVis"] != DBNull.Value) cpl.FarAcuity = (string)dr["CPLLeAVis"];

                if (dr["CPLTuEsfOD"] != DBNull.Value) cpl.BothSphericityRightEye = (string)dr["CPLTuEsfOD"];
                if (dr["CPLTuCilOD"] != DBNull.Value) cpl.BothCylinderRightEye = (string)dr["CPLTuCilOD"];
                if (dr["CPLTuEjeOD"] != DBNull.Value) cpl.BothAxisRightEye = (string)dr["CPLTuEjeOD"];
                if (dr["CPLTuPrisOD"] != DBNull.Value) cpl.BothPrismRightEye = (string)dr["CPLTuPrisOD"];
                //
                if (dr["CPLTuEsfOI"] != DBNull.Value) cpl.BothSphericityLeftEye = (string)dr["CPLTuEsfOI"];
                if (dr["CPLTuCilOI"] != DBNull.Value) cpl.BothCylinderLeftEye = (string)dr["CPLTuCilOI"];
                if (dr["CPLTuEjeOI"] != DBNull.Value) cpl.BothAxisLeftEye = (string)dr["CPLTuEjeOI"];
                if (dr["CPLTuPrisOI"] != DBNull.Value) cpl.BothPrismLeftEye = (string)dr["CPLTuPrisOI"];

                if (dr["CPLTuCent"] != DBNull.Value) cpl.BothCenters = (string)dr["CPLTuCent"];
                if (dr["CPLTuAVis"] != DBNull.Value) cpl.BothAcuity = (string)dr["CPLTuAVis"];

                if (dr["CPLCerEsfOD"] != DBNull.Value) cpl.CloseSphericityRightEye = (string)dr["CPLCerEsfOD"];
                if (dr["CPLCerCilOD"] != DBNull.Value) cpl.CloseCylinderRightEye = (string)dr["CPLCerCilOD"];
                if (dr["CPLCerEjeOD"] != DBNull.Value) cpl.CloseAxisRightEye = (string)dr["CPLCerEjeOD"];
                if (dr["CPLCerPrisOD"] != DBNull.Value) cpl.ClosePrismRightEye = (string)dr["CPLCerEjeOD"];

                if (dr["CPLCerEsfOI"] != DBNull.Value) cpl.CloseSphericityLeftEye = (string)dr["CPLCerEsfOI"];
                if (dr["CPLCerCilOI"] != DBNull.Value) cpl.CloseCylinderLeftEye = (string)dr["CPLCerCilOI"];
                if (dr["CPLCerEjeOI"] != DBNull.Value) cpl.CloseAxisLeftEye = (string)dr["CPLCerEjeOI"];
                if (dr["CPLCerPrisOI"] != DBNull.Value) cpl.ClosePrismLeftEye = (string)dr["CPLCerEjeOI"];

                if (dr["CPLCerCent"] != DBNull.Value) cpl.CloseCenters = (string)dr["CPLCerCent"];
                if (dr["CPLCerAVis"] != DBNull.Value) cpl.CloseAcuity = (string)dr["CPLCerAVis"];

                ctx.Add(cpl);
                ctx.SaveChanges();
            }

            //Glasses Test
            sql = String.Format("SELECT * FROM RECRefracto WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "ConRECRefracto");
            if (ds.Tables["ConRECRefracto"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["ConRECRefracto"].Rows[0];
                PrescriptionGlasses recp = new PrescriptionGlasses();
                recp.Refractometry = rf;
                //if (dr["RECLejAVisOD"] != DBNull.Value) recp.FarVisualAcuityRightEye = (string)dr["RECLejAVisOD"];
                //if (dr["RECTuAVisOD"] != DBNull.Value) recp.BothAcuityRightEye = (string)dr["RECTuAVisOD"];
                //if (dr["RECCerAVisOD"] != DBNull.Value) recp.CloseAcuityRightEye = (string)dr["RECCerAVisOD"];

                //if (dr["RECLejAVisOI"] != DBNull.Value) recp.FarVisualAcuityLeftEye = (string)dr["RECLejAVisOI"];
                //if (dr["RECTuAVisOI"] != DBNull.Value) recp.BothAcuityLeftEye = (string)dr["RECTuAVisOI"];
                //if (dr["RECCerAVisOI"] != DBNull.Value) recp.CloseAcuityLeftEye = (string)dr["RECCerAVisOI"];

                if (dr["Observaciones"] != DBNull.Value) recp.Comments = (string)dr["Observaciones"];

                if (dr["RECLeEsfOD"] != DBNull.Value) recp.FarSphericityRightEye = (string)dr["RECLeEsfOD"];
                if (dr["RECLeCilOD"] != DBNull.Value) recp.FarCylinderRightEye = (string)dr["RECLeCilOD"];
                if (dr["RECLeEjeOD"] != DBNull.Value) recp.FarAxisRightEye = (string)dr["RECLeEjeOD"];
                if (dr["RECLePrisOD"] != DBNull.Value) recp.FarPrimsRightEye = (string)dr["RECLePrisOD"];

                if (dr["RECLeEsfOI"] != DBNull.Value) recp.FarSphericityLeftEye = (string)dr["RECLeEsfOI"];
                if (dr["RECLeCilOI"] != DBNull.Value) recp.FarCylinderLeftEye = (string)dr["RECLeCilOI"];
                if (dr["RECLeEjeOI"] != DBNull.Value) recp.FarAxisLeftEye = (string)dr["RECLeEjeOI"];
                if (dr["RECLePrisOI"] != DBNull.Value) recp.FarPrismLeftEye = (string)dr["RECLePrisOI"];

                if (dr["RECLeCent"] != DBNull.Value) recp.FarCenters = (string)dr["RECLeCent"];
                //if (dr["RECLeAVis"] != DBNull.Value) recp.FarAcuity = (string)dr["RECLeAVis"];

                if (dr["RECTuEsfOD"] != DBNull.Value) recp.BothSphericityRightEye = (string)dr["RECTuEsfOD"];
                if (dr["RECTuCilOD"] != DBNull.Value) recp.BothCylinderRightEye = (string)dr["RECTuCilOD"];
                if (dr["RECTuEjeOD"] != DBNull.Value) recp.BothAxisRightEye = (string)dr["RECTuEjeOD"];
                if (dr["RECTuPrisOD"] != DBNull.Value) recp.BothPrismRightEye = (string)dr["RECTuPrisOD"];
                //
                if (dr["RECTuEsfOI"] != DBNull.Value) recp.BothSphericityLeftEye = (string)dr["RECTuEsfOI"];
                if (dr["RECTuCilOI"] != DBNull.Value) recp.BothCylinderLeftEye = (string)dr["RECTuCilOI"];
                if (dr["RECTuEjeOI"] != DBNull.Value) recp.BothAxisLeftEye = (string)dr["RECTuEjeOI"];
                if (dr["RECTuPrisOI"] != DBNull.Value) recp.BothPrismLeftEye = (string)dr["RECTuPrisOI"];

                if (dr["RECTuCent"] != DBNull.Value) recp.BothCenters = (string)dr["RECTuCent"];
                //if (dr["RECTuAVis"] != DBNull.Value) recp.BothAcuity = (string)dr["RECTuAVis"];

                if (dr["RECCerEsfOD"] != DBNull.Value) recp.CloseSphericityRightEye = (string)dr["RECCerEsfOD"];
                if (dr["RECCerCilOD"] != DBNull.Value) recp.CloseCylinderRightEye = (string)dr["RECCerCilOD"];
                if (dr["RECCerEjeOD"] != DBNull.Value) recp.CloseAxisRightEye = (string)dr["RECCerEjeOD"];
                if (dr["RECCerPrisOD"] != DBNull.Value) recp.ClosePrismRightEye = (string)dr["RECCerEjeOD"];

                if (dr["RECCerEsfOI"] != DBNull.Value) recp.CloseSphericityLeftEye = (string)dr["RECCerEsfOI"];
                if (dr["RECCerCilOI"] != DBNull.Value) recp.CloseCylinderLeftEye = (string)dr["RECCerCilOI"];
                if (dr["RECCerEjeOI"] != DBNull.Value) recp.CloseAxisLeftEye = (string)dr["RECCerEjeOI"];
                if (dr["RECCerPrisOI"] != DBNull.Value) recp.ClosePrismLeftEye = (string)dr["RECCerEjeOI"];

                if (dr["RECCerCent"] != DBNull.Value) recp.CloseCenters = (string)dr["RECCerCent"];
                //if (dr["RECCerAVis"] != DBNull.Value) recp.CloseAcuity = (string)dr["RECCerAVis"];

                ctx.Add(recp);
                ctx.SaveChanges();
            }


        }

        public static void ProcessPaquimetry(int id, Paquimetry pq, OleDbConnection con, AriClinicContext ctx)
        {
            // WithoutGlasses
            string sql = String.Format("SELECT * FROM Paquimetria WHERE IdRef={0}", id);
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConSNGRefracto");
            DataRow dr = ds.Tables["ConSNGRefracto"].Rows[0];
            pq.RightEyeCentralC0 = (decimal)dr["CentralC0D"];
            pq.RightEyeC1 = (decimal)dr["C1D"];
            pq.RightEyeC3 = (decimal)dr["C3D"];
            pq.RightEyeC5 = (decimal)dr["C5D"];
            pq.RightEyeC7 = (decimal)dr["C7D"];
            pq.LeftEyeCentralC0 = (decimal)dr["CentralC0I"];
            pq.LeftEyeC1 = (decimal)dr["C1I"];
            pq.LeftEyeC3 = (decimal)dr["C3I"];
            pq.LeftEyeC5 = (decimal)dr["C5I"];
            pq.LeftEyeC7 = (decimal)dr["C7I"];
        }

        public static void ImportProcedures(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.ProcedureAssigneds);
            ctx.Delete(ctx.Procedures);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM Procedimientos";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConProcedimientos");
            int nreg = ds.Tables["ConProcedimientos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConProcedimientos"].Rows)
            {
                reg++;
                Console.WriteLine("Procedimientos {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomProEs"]);
                Procedure proc = new Procedure();
                proc.OftId = (int)dr["IdProEs"];
                proc.Name = (string)dr["NomProEs"];
                ctx.Add(proc);
                ctx.SaveChanges();
            }
        }

        public static void ImportProceduresAssigned(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.ProcedureAssigneds);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM HistProc";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConProcedimientos");
            int nreg = ds.Tables["ConProcedimientos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConProcedimientos"].Rows)
            {
                reg++;
                Console.WriteLine("Procedimientos {0:#####0} de {1:#####0} {2}", reg, nreg, "ASGPROCS");
                ProcedureAssigned pa = new ProcedureAssigned();
                int id = (int)dr["IdProEs"];
                Procedure pro = (from p in ctx.Procedures
                                 where p.OftId == id
                                 select p).FirstOrDefault<Procedure>();
                id = (int)dr["NumHis"];
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == id
                                   select p).FirstOrDefault<Patient>();
                pa.Patient = patient;
                pa.Procedure = pro;
                pa.ProcedureDate = (DateTime)dr["Fecha"];
                pa.Comments = (string)dr["Observa"];
                ctx.Add(pa);
                ctx.SaveChanges();
            }
        }


        public static void ImportDrugs(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.Treatments);
            ctx.SaveChanges();
            ctx.Delete(ctx.Drugs);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM Farmacos";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConFarmacos");
            int nreg = ds.Tables["ConFarmacos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConFarmacos"].Rows)
            {
                reg++;
                Console.WriteLine("Fármacos {0:#####0} de {1:#####0} {2}", reg, nreg, (string)dr["NomFarm"]);
                Drug d = new Drug();
                d.OftId = (int)dr["IdFarm"];
                d.Name = (string)dr["NomFarm"];
                ctx.Add(d);
                ctx.SaveChanges();
            }
        }

        public static void ImportTreatment(OleDbConnection con, AriClinicContext ctx)
        {
            // (0) Borra tipos previos
            ctx.Delete(ctx.Treatments);
            ctx.SaveChanges();

            // (1) Dar de alta los diferentes diagnósticos
            string sql = "SELECT * FROM HistFarm";
            cmd = new OleDbCommand(sql, con);
            da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "ConFarmacos");
            int nreg = ds.Tables["ConFarmacos"].Rows.Count;
            int reg = 0;
            foreach (DataRow dr in ds.Tables["ConFarmacos"].Rows)
            {
                reg++;
                Console.WriteLine("Tratamientos {0:#####0} de {1:#####0} {2}", reg, nreg, "TREATMENT");
                Treatment t = new Treatment();
                int id = (int)dr["IdFarm"];
                Drug dia = (from d in ctx.Drugs
                            where d.OftId == id
                            select d).FirstOrDefault<Drug>();
                id = (int)dr["NumHis"];
                Patient patient = (from p in ctx.Patients
                                   where p.OftId == id
                                   select p).FirstOrDefault<Patient>();
                t.Patient = patient;
                t.Drug = dia;
                if ((int)dr["TipoProc"] == 1)
                {
                    id = (int)dr["ExtProc"];
                    t.BaseVisit = (from v in ctx.BaseVisits
                                   where v.OftRefVisita == id
                                   select v).FirstOrDefault<BaseVisit>();
                }
                t.TreatmentDate = (DateTime)dr["Fecha"];
                t.Recommend = (string)dr["Posologia"];
                t.Quantity = (int)(float)dr["Cantidad"];
                ctx.Add(t);
                ctx.SaveChanges();
            }
        }

        #region Auxiliary functions
        #region GetConnectionstring
        /// <summary>
        /// method to retrieve connection stringed in the web.config file
        /// </summary>
        /// <param name="str">Name of the connection</param>
        /// <remarks>Need a reference to the System.Configuration Namespace</remarks>
        /// <returns></returns>
        //public static string GetConnectionString(string str)
        //{
        //    //variable to hold our return value
        //    string conn = string.Empty;
        //    //check if a value was provided
        //    if (!string.IsNullOrEmpty(str))
        //    {
        //        //name provided so search for that connection
        //        conn = ConfigurationManager.ConnectionStrings[str].ConnectionString;
        //    }
        //    else
        //    //name not provided, get the 'default' connection
        //    {
        //        conn = ConfigurationManager.ConnectionStrings["OFT"].ConnectionString;
        //    }
        //    //return the value
        //    return conn;
        //}
        #endregion
        #endregion
    }

}
