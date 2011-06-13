using AriCliModel;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace AriCliWebTest
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
            ctx.Delete(ctx.AppointmentInfos);
            ctx.Delete(ctx.AppointmentTypes);
            ctx.Delete(ctx.Diaries);
            ctx.Delete(ctx.Payments);
            ctx.Delete(ctx.Tickets);
            ctx.Delete(ctx.ServiceNotes);
            ctx.Delete(ctx.Policies);
            ctx.Delete(ctx.Insurances);
            ctx.Delete(ctx.InsuranceServices);
            ctx.Delete(ctx.Professionals);
            ctx.Delete(ctx.Services);
            ctx.Delete(ctx.ServiceCategories);
            ctx.Delete(ctx.TaxTypes);
            ctx.Delete(ctx.Addresses); // eliminar direcciones.
            ctx.Delete(ctx.Emails); // eliminar correos electrónicos
            ctx.Delete(ctx.Telephones); // eliminar teléfonos.
            ctx.Delete(ctx.Policies); // eliminar las pólizas.
            ctx.Delete(ctx.PaymentMethods);

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
            return new OleDbConnection(GetConnectionString(path));
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

                // (2.1) Crear cliente
                Customer customer = new Customer();
                if (dr["NumDni"] != DBNull.Value)
                    customer.VATIN = (string)dr["NumDni"];
                customer.FullName = (string)dr["Nombre"];
                customer.ComercialName = (string)dr["Nombre"];
                customer.OftId = (int)dr["NumHis"];
                ctx.Add(customer);

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
                    if ((byte)dr["Sexo"] == 2) patient.Sex = "W";
                patient.Customer = customer;
                patient.OftId = (int)dr["NumHis"];
                ctx.Add(patient);

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
            }
            ctx.SaveChanges();
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

                ServiceNote sn = new ServiceNote();
                int id = (int)dr["NumHis"];
                sn.Customer = (from cus in ctx.Customers
                               where cus.OftId == id
                               select cus).FirstOrDefault<Customer>();
                sn.ServiceNoteDate = (DateTime)dr["Fecha"];
                decimal total = (decimal)dr["Total"];
                sn.Total = total;
                sn.Clinic = cl;
                sn.Oft_Ano = (int)dr["Ano"];
                sn.Oft_NumNota = (int)dr["NumNota"];
                ctx.Add(sn);
            }
            ctx.SaveChanges();

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
            }
            ctx.SaveChanges();
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
            foreach (DataRow dr in ds.Tables["ConPagos"].Rows)
            {
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
            foreach (DataRow dr in ds.Tables["ConTiposCita"].Rows)
            {
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
            foreach (DataRow dr in ds.Tables["ConLibrosCita"].Rows)
            {
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

            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            foreach (DataRow dr in ds.Tables["ConCitas"].Rows)
            {
                i3++;
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
            }
            ctx.SaveChanges();
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
            foreach (DataRow dr in ds.Tables["ConFacturas"].Rows)
            {
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
            }
            ctx.SaveChanges();

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
            foreach (DataRow dr in ds.Tables["ConLineasFactura"].Rows)
            {
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
                               where iv.Year == Ano
                               && iv.InvoiceNumber == NumFac
                               select iv).FirstOrDefault<Invoice>();
                il.Invoice = inv;
                il.TaxType = tx;
                il.TaxPercentage = tx.Percentage;
                il.Amount = (decimal)dr["Importe"];
                il.Description = (string)dr["Descripcion"];
                ctx.Add(il);
            }
            ctx.SaveChanges();
        }

        #region Auxiliary functions
        #region GetConnectionstring
        /// <summary>
        /// method to retrieve connection stringed in the web.config file
        /// </summary>
        /// <param name="str">Name of the connection</param>
        /// <remarks>Need a reference to the System.Configuration Namespace</remarks>
        /// <returns></returns>
        public static string GetConnectionString(string str)
        {
            //variable to hold our return value
            string conn = string.Empty;
            //check if a value was provided
            if (!string.IsNullOrEmpty(str))
            {
                //name provided so search for that connection
                conn = ConfigurationManager.ConnectionStrings[str].ConnectionString;
            }
            else
            //name not provided, get the 'default' connection
            {
                conn = ConfigurationManager.ConnectionStrings["OFT"].ConnectionString;
            }
            //return the value
            return conn;
        }
        #endregion
        #endregion
    }
}
