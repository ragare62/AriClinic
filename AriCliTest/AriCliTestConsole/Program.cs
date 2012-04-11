using System;
using AriCliModel;
using System.Data.OleDb;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Begin program --");
            // open OFT connection
            OleDbConnection con = CntOft.GetOftConnection("OFT");
            // open AriClinic connection
            AriClinicContext ctx = new AriClinicContext("MIESTETIC");
            CntOft.ImportServiceNote(con, ctx);
            Console.WriteLine("-- End program --");
            Console.ReadLine();
        }
        static void Procesar()
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

            ////// (1) Patients
            //System.Threading.Thread.Sleep(100);
            //i++;
            //context.SecondaryValue = i.ToString();
            //context.CurrentOperationText = i.ToString() + " Importando pacientes... ";
            //i3 = (i / i2) * 100;
            //context.SecondaryPercent = i3.ToString();
            //CntOft.ImportPatientCustomer(con, ctx);

            ////// (2) Tax types
            //System.Threading.Thread.Sleep(100);
            //i++;
            //context.SecondaryValue = i.ToString();
            //context.CurrentOperationText = i.ToString() + " Importando tipos de IVA... ";
            //i3 = (i / i2) * 100;
            //context.SecondaryPercent = i3.ToString();
            //CntOft.ImportTaxTypes(con, ctx);

            ////// (3) Services 
            //System.Threading.Thread.Sleep(100);
            //i++;
            //context.SecondaryValue = i.ToString();
            //context.CurrentOperationText = i.ToString() + " Importando servicios... ";
            //i3 = (i / i2) * 100;
            //context.SecondaryPercent = i3.ToString();
            //CntOft.ImportCategories(con, ctx);

            ////// (4) Porfesionales
            //System.Threading.Thread.Sleep(100);
            //i++;
            //context.SecondaryValue = i.ToString();
            //context.CurrentOperationText = i.ToString() + " Importando médicos... ";
            //i3 = (i / i2) * 100;
            //context.SecondaryPercent = i3.ToString();
            //CntOft.ImportProfessionals(con, ctx);

            ////// (5) Aseguradoras y pólizas
            //System.Threading.Thread.Sleep(100);
            //i++;
            //context.SecondaryValue = i.ToString();
            //context.CurrentOperationText = i.ToString() + " Importando aseguradoras y pólizas... ";
            //i3 = (i / i2) * 100;
            //context.SecondaryPercent = i3.ToString();
            //CntOft.ImportAssurancePolicies(con, ctx);

            //// (6) Notas de servicio
            CntOft.ImportServiceNote(con, ctx);

            //// (7) Formas de pago
            CntOft.ImportPaymentTypes(con, ctx);

            ////(8) Pagos
            CntOft.ImportPayments(con, ctx);

            //// (9) Tipos de cita
            CntOft.ImportAppointmentType(con, ctx);

            //// (10) Agendas
            CntOft.ImportDiary(con, ctx);

            //// (11) Tipos de cita
            CntOft.ImportAppointmentInfo(con, ctx);

            //// (12) Motivos de consulta
            CntOft.ImportVisitReasons(con, ctx);

            // (13) Facturas
            CntOft.ImportInvoices(con, ctx);
            // (14) Visitas
            CntOft.ImportVisits(con, ctx);
            // (15) Diagnósticos
            CntOft.ImportDiagnostics(con, ctx);

            // (16) Diagnósticos asignados
            CntOft.ImportDiagnosticsAssigned(con, ctx);

            // (17) Exploraciones
            CntOft.ImportExaminations(con, ctx);

            // (18) Exploraciones asignadas
            CntOft.ImportExaminationsAssigned(con, ctx);
            // (19) Procedimientos
            CntOft.ImportProcedures(con, ctx);

            // (20) Procedimientos asignados
            CntOft.ImportProceduresAssigned(con, ctx);
            #endregion


            #region Importaciones por probar
            // (21) Farmacos
            CntOft.ImportDrugs(con, ctx);

            // (22) Procedimientos asignados
            CntOft.ImportTreatment(con, ctx);


            #endregion

        }
    }
}
