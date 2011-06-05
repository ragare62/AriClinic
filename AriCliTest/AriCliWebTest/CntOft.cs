using AriCliModel;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

//using AriCliModel;

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

        /// <summary>
        /// Obtiene un connector para acceder a la base de datos OFT
        /// </summary>
        /// <param name="path"> Ruta completa del archivo mdb</param>
        /// <returns>OleDb connection1</returns>
        public static OleDbConnection GetOftConnection(string path)
        {
            return new OleDbConnection(path);
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
            ctx.Delete(ctx.Addresses); // elimar direcciones.
            ctx.Delete(ctx.Emails); // eliminar correos electrónicos
            ctx.Delete(ctx.Telephones); // eliminar teléfonos.
            ctx.Delete(ctx.Customers); // eliminar los clientes.
            ctx.Delete(ctx.Patients); // por último, los pcaientes.
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
            foreach (DataRow dr in ds.Tables["ConFacturas"].Rows)
            {
                ++nreg; // un registro más (para saber por donde va)

                // (2.1) Crear cliente
                Customer customer = new Customer();
                customer.VATIN = (string)dr["NumDni"];
                customer.FullName = (string)dr["Nombre"];
                customer.ComercialName = (string)dr["Nombre"];
                ctx.Add(customer);

                // (2.2) Crear paciente y asignarle el cliente
                Patient patient = new Patient();
                patient.Name = (string)dr["Nom"];
                patient.Surname1 = (string)dr["Apell1"];
                patient.Surname2 = (string)dr["Apell2"];
                patient.FullName = (string)dr["Nombre"];
                patient.BornDate = (DateTime)dr["FechaNac"];
                patient.Customer = customer;
                ctx.Add(patient);

                // (2.3) Crear la dirección y asignársela a cliente y paciente.
                Address address = new Address();
                address.Street = (string)dr["Direccion"];
                address.City = (string)dr["Poblacion"];
                address.PostCode = (string)dr["CodPostal"];
                address.Province = (string)dr["Provincia"];
                address.Type = "Primary";
                ctx.Add(address);
                customer.Addresses.Add(address);
                patient.Addresses.Add(address);

                // (2.4) Lo mismo para los teléfono.
                Telephone telephone = new Telephone();
                if ((string)dr["Tel1"] != "")
                {
                    telephone.Number = (string)dr["Tel1"];
                    telephone.Type = "Primary";
                    ctx.Add(telephone);
                    patient.Telephones.Add(telephone);
                    customer.Telephones.Add(telephone);
                }
                if ((string)dr["Tel2"] != "")
                {
                    telephone = new Telephone();
                    telephone.Number = (string)dr["Tel2"];
                    telephone.Type = "Primary";
                    ctx.Add(telephone);
                    patient.Telephones.Add(telephone);
                    customer.Telephones.Add(telephone);
                }
                if ((string)dr["Movil"] != "")
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
                email.Url = (string)dr["Email"];
                email.Type = "Primary";
                ctx.Add(email);
                patient.Emails.Add(email);
                customer.Emails.Add(email);
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
