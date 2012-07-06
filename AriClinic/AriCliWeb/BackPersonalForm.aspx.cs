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

public partial class BackPersonalForm : System.Web.UI.Page
{
    #region Variables declaration
    AriClinicContext ctx = null;
    Patient patient = null;
    BackPersonal bckp = null;
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
            bckp = patient.BackPersonals.FirstOrDefault<BackPersonal>();
            // we load RadEditor with content
            LoadData(bckp);
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
            RadWindowManager1.RadConfirm(Resources.GeneralResource.TwoButtonsWarning, "noHaceNada()", null, null, null, Resources.GeneralResource.Warning);
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
    protected void LoadData(BackPersonal pmr)
    {
        if (pmr != null)
        {
            RadEditor1.Content = pmr.Content;
        }
    }
    protected void UnloadData(BackPersonal pmr)
    {
        if (pmr == null)
        {
            pmr = new BackPersonal();
            pmr.Patient = patient;
            ctx.Add(pmr);
            ctx.SaveChanges();
        }
        pmr.Content = RadEditor1.Content;
        ctx.SaveChanges();
        RadWindowManager1.RadConfirm(Resources.GeneralResource.DataStoredOk, "noHaceNada()", null, null, null, Resources.GeneralResource.Warning);
    }
    #endregion 

    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        UnloadData(bckp);
    }
}
