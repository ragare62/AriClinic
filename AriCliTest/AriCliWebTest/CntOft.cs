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
                ctx.Add(p);
            }
            ctx.SaveChanges();
        }

        public static void ImportServiceNote(OleDbConnection con, AriClinicContext ctx)
        {
            //(0) Borrar las notas de servcio previas
            ctx.Delete(ctx.ServiceNotes);

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

            }
        }

        public static void ImportDiary(OleDbConnection con, AriClinicContext ctx)
        {
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
