using System;
using System.Data.OleDb;
using AriCliModel;
using AriCliWebTest;
public partial class Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        // open OFT connection
        OleDbConnection con = CntOft.GetOftConnection("OFT");
        // open AriClinic connection
        AriClinicContext ctx = new AriClinicContext("MIESTETIC");
        // start importing things
        txtTest.Text = String.Format("{0}\n", "Importando pacientes...");
        // (1) Patients
        CntOft.ImportPatientCustomer(con, ctx);
        ctx.SaveChanges();
        txtTest.Text = "Importación de pacientes finalizada.\n";
    }
}
