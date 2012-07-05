using System;
using AriCliModel;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class PreviousMedicalRecordForm : System.Web.UI.Page
{
    #region Variables declaration
    AriClinicContext ctx = null;
    Patient patient = null;
    PreviousMedicalRecord pmr = null;
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
        if (Request.QueryString["PersonId"] != null)
        {
            patient = CntAriCli.GetPatient(int.Parse(Request.QueryString["PersonId"]), ctx);

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events

    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {

    }
}
