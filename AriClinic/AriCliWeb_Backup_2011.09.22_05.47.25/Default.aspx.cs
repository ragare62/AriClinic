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

public partial class Default : System.Web.UI.Page 
{
    AriClinicContext ctx = null; // context for access database
    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Set default values
        if (!IsPostBack)
        {
            RadSkinManager1.Skin = "Outlook";
            Session["Skin"] = "Outlook";
            HealthcareCompany hc = CntAriCli.GetHealthCompany(ctx);
            lblHealthcareCompany.Text = hc.Name;
            Session["Company"] = hc;
            String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblApplication.Text = String.Format("AriClinic VRS {0}", strVersion);
        }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion Init Load Unload events
}
