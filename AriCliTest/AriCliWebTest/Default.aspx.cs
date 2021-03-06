using AriCliModel;
using AriCliWebTest;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web.Query.Dynamic;
using Telerik.Web.Data;
using Telerik.Web.Data.Extensions;
using Telerik.Web.UI;

public partial class Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadProgressArea1.Localization.UploadedFiles = "Pasos completos: ";
            RadProgressArea1.Localization.CurrentFileName = "Paso: ";
            RadProgressArea1.Localization.TotalFiles = "Total pasos:";
        }
    }

    protected void btnTest_Click(object sender, EventArgs e)
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
        RadProgressContext context = RadProgressContext.Current;
        context.SecondaryTotal = i2.ToString();

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
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Importando notas de servicio... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportServiceNote(con, ctx);

        //// (7) Formas de pago
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Importando formas de pago... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportPaymentTypes(con, ctx);
        
        ////(8) Pagos
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Importando pagos... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportPayments(con, ctx);

        //// (9) Tipos de cita
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Tipos de cita... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportAppointmentType(con, ctx);

        //// (10) Agendas
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Agendas.. ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportDiary(con, ctx);

        //// (11) Tipos de cita
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Citas... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportAppointmentInfo(con, ctx);

        //// (12) Motivos de consulta
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Motivos de consulta... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportVisitReasons(con, ctx);

        // (13) Facturas
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Facturas... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportInvoices(con, ctx);
        // (14) Visitas
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Visitas... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportVisits(con, ctx);
        // (15) Diagnósticos
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Diagnósticos... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportDiagnostics(con, ctx);

        // (16) Diagnósticos asignados
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Diagnósticos asignados... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportDiagnosticsAssigned(con, ctx);

        // (17) Exploraciones
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Exploraciones... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportExaminations(con, ctx);

        // (18) Exploraciones asignadas
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Exploraciones asignadas... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportExaminationsAssigned(con, ctx);
        // (19) Procedimientos
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Procedimientos... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportProcedures(con, ctx);

        // (20) Procedimientos asignados
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Procedimientos asignados... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportProceduresAssigned(con, ctx);
        #endregion


        #region Importaciones por probar
        // (21) Farmacos
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Farmacos... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportDrugs(con, ctx);

        // (22) Procedimientos asignados
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Tratamientos asignados... ";
        i3 = (i / i2) * 100;
        context.SecondaryPercent = i3.ToString();
        CntOft.ImportTreatment(con, ctx);


        #endregion



        txtTest.Text = "Proceso finalizado";
        
    }





    protected void btnProgess_Click(object sender, EventArgs e)
    {
        RadProgressContext context = RadProgressContext.Current;
        context.SecondaryTotal = "100";
        for (int i = 1; i < 100; i++)
        {
            context.SecondaryValue = i.ToString();
            context.SecondaryPercent = i.ToString();
            context.CurrentOperationText = "Doing step " + i.ToString();
            if (!Response.IsClientConnected)
            {
                //Cancel button was clicked or the browser was closed, so stop processing
                break;
            }
            // simulate a long time performing the current step
            System.Threading.Thread.Sleep(100);
        }
    }
}
