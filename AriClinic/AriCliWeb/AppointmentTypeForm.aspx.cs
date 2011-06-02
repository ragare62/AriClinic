using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using AriCliModel;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class AppointmentTypeForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    AriCliModel.Parameter parameter; // it must spccified to aboid confussion
    int appTypeId = 0;
    Permission per = null;
    AppointmentType apptype = null;
    string type = "";
    #endregion Variables declarations

    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        // security control, it must be a user logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
        else
        {
            user = (User)Session["User"];
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "apptype"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        if (Request.QueryString["AppointmentTypeId"] != null)
        {
            appTypeId = int.Parse(Request.QueryString["AppointmentTypeId"]);
            apptype = CntAriCli.GetAppointmentType(appTypeId, ctx);
        }
        LoadData(apptype);

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
        string command = "CloseAndRebind('new');";
        if (apptype == null)
            command = "CloseAndRebind();";
        if (!CreateChange())
            return;
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnServiceId_Click(object sender, ImageClickEventArgs e)
    {

    }
    #region Auxiliary functions
    protected bool DataOk()
    {

        return true;
    }

    /// <summary>
    /// As its name suggest if there isn't an object
    /// it'll create it. If exists It modifies it.
    /// </summary>
    /// <returns></returns>
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (apptype == null)
        {
            apptype = new AppointmentType();
            ctx.Add(apptype);
        }
        UnloadData(apptype);
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(AppointmentType apptype)
    {
        if (apptype == null) return; // There isn't any agenda to show
        txtAppointmentTypeId.Text = String.Format("{0:00000}", apptype.AppointmentTypeId);
        txtName.Text = apptype.Name;
        txtDuration.Text = apptype.Duration.ToString();
    }

    protected void UnloadData(AppointmentType apptype)
    {
        apptype.Name = txtName.Text;
        apptype.Duration = int.Parse(txtDuration.Text);
    }


    #endregion Auxiliary functions

    #region Searching outside
    #endregion
}
