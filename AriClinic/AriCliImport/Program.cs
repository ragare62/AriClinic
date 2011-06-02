using System;
using System.Web;
using System.Data;
using System.Data.OleDb;
using AriCliModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliImport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Importación OFT");
            Console.WriteLine("Base de datos a processar:{0}. /n¿Correcto?(S/N)", args[0]);
            string s = Console.ReadLine();
            if (s != "S") return;

            //
            OleDbConnection con = CntOft.GetOftConnection(args[0]);
            AriClinicContext ctx = new AriClinicContext("MIESTETIC");
            CntOft.ImportPatientCustomer(con, ctx);
            
        }
    }
}
