using System;
using AriCliModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class BackGinecologyForm : System.Web.UI.Page
{
    #region Variables declaration
    AriClinicContext ctx = null;
    Patient patient = null;
    BackGinecology bckg = null;
    string js = "";
    #endregion
    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        // security control, it must be a user logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
        else
        {
        }
        if (Request.QueryString["PatientId"] != null)
        {
            patient = CntAriCli.GetPatient(int.Parse(Request.QueryString["PatientId"]), ctx);
            bckg = patient.BackGinecologies.FirstOrDefault<BackGinecology>();
            // we load RadEditor with content
            LoadData(bckg);
        }
        else
        {
            // What will it happen here?
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Warned"] == null)
            RadWindowManager1.RadConfirm(Resources.GeneralResource.TwoButtonsWarning, "noHaceNada()", null, null, null, Resources.GeneralResource.Warning);
            Session["Warned"] = true;
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events

    #region Load / Unload data
    protected void LoadData(BackGinecology bckg)
    {
        if (bckg != null)
        {
            txtMenstrualFormula.Text = bckg.MenstrualFormula;
            txtVaginalDeliveries.Value = bckg.VaginalDeliveries;
            txtCesareanDeliveries.Value = bckg.CesareanDeliveries;
            txtAbortions.Value = bckg.Abortions;

            txtMenarche.Text = bckg.Menarche;
            txtMenopause.Text = bckg.Menopause;

            if (CntAriCli.IsDateNull(bckg.DateOfLastMestrual) != null)
                rdcDateOfLastMenstrual.SelectedDate = bckg.DateOfLastMestrual;
            txtContent.Content = bckg.Content;
        }
    }

    protected void UnloadData(BackGinecology bckg)
    {
        if (bckg == null)
        {
            bckg = new BackGinecology();
            bckg.Patient = patient;
            ctx.Add(bckg);
            ctx.SaveChanges();
        }
        
        bckg.MenstrualFormula = txtMenstrualFormula.Text;
        bckg.VaginalDeliveries = (int)txtVaginalDeliveries.Value;
        bckg.CesareanDeliveries = (int)txtCesareanDeliveries.Value;
        bckg.Abortions = (int)txtAbortions.Value;

        bckg.Menarche = txtMenarche.Text;
        bckg.Menopause = txtMenopause.Text;

        if (rdcDateOfLastMenstrual.SelectedDate != null)
            bckg.DateOfLastMestrual = (DateTime)rdcDateOfLastMenstrual.SelectedDate;
        bckg.Content = txtContent.Content;

        ctx.SaveChanges();
        RadWindowManager1.RadConfirm(Resources.GeneralResource.DataStoredOk, "noHaceNada()", null, null, null, Resources.GeneralResource.Warning);
    }

    #endregion 

    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        UnloadData(bckg);
    }
}