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

public partial class DocumentsPatient : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    Patient patient = null;
    int patientId = 0;
    string[] paths = new string[1];
    string type;

    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
        User u = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
        u = CntAriCli.GetUser(u.UserId, ctx);
        // controla that root docs folder exists
        if (!CntDocs.DocsExists(this)) CntDocs.CreateDocs(this);
        // patient passed by url
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
        }
        // 2 possibilities 
        // patient == null (All docs)
        // patine != null (Patient's docs)
        if (patient == null)
        {
            paths[0] = "/docs";

        }
        else
        {
            if (!CntDocs.PatientFolderExists(patient,this)) CntDocs.CreatePatientFolder(patient,this);
            paths[0] = String.Format("/docs/{0}", patient.FullName);
        }
        RadFileExplorer1.Configuration.ViewPaths = paths;
        RadFileExplorer1.Configuration.DeletePaths = paths;
        RadFileExplorer1.Configuration.UploadPaths = paths;
        //
        string maxFileSize = ConfigurationManager.AppSettings["MaxFileSize"];
        if (maxFileSize != null)
            RadFileExplorer1.Configuration.MaxUploadFileSize = int.Parse(maxFileSize);
        // cheks if he's called from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        if (type == "InTab")
        {
            HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
            tt.Attributes["class"] = "ghost";
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

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }
}
