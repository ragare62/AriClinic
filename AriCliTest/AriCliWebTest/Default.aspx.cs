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
        int i2 = 4;
        int i = 0;
        decimal per = 0;
        // open OFT connection
        OleDbConnection con = CntOft.GetOftConnection("OFT");
        // open AriClinic connection
        AriClinicContext ctx = new AriClinicContext("MIESTETIC");
        // start importing things
        RadProgressContext context = RadProgressContext.Current;
        context.SecondaryTotal = i2.ToString();
        // (1) Patients
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Importando pacientes... ";
        per = (i / i2) * 100;
        context.SecondaryPercent = per.ToString();
        CntOft.ImportPatientCustomer(con, ctx);

        // (2) Tax types
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Importando tipos de IVA... ";
        per = (i / i2) * 100;
        context.SecondaryPercent = per.ToString();
        CntOft.ImportTaxTypes(con, ctx);

        // (3) Services 
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() +" Importando servicios... ";
        per = (i / i2) * 100;
        context.SecondaryPercent = per.ToString();
        CntOft.ImportCategories(con, ctx);

        // (4) Porfesionales
        System.Threading.Thread.Sleep(100);
        i++;
        context.SecondaryValue = i.ToString();
        context.CurrentOperationText = i.ToString() + " Importando médicos... ";
        per = (i / i2) * 100;
        context.SecondaryPercent = per.ToString();
        CntOft.ImportProfessionals(con, ctx);

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
