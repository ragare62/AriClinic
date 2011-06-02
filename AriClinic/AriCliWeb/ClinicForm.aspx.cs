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

public partial class ClinicForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Clinic cl = null;
    int hcID = 0;
    int clinicId = 0;
    Permission per = null;
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
            Process proc = (from p in ctx.Processes
                            where p.Code == "usergroup"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ClinicId"] != null)
        {
            clinicId = Int32.Parse(Request.QueryString["ClinicId"]);
            cl = (from c in ctx.Clinics
                  where c.ClinicId == clinicId
                  select c).FirstOrDefault<Clinic>();
            LoadData(cl);
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
    
    #region Page events (clics)
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        string command = "CloseAndRebind('')"; 
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }
    #endregion Page events (clics)

    #region Auxiliary functions
    protected bool DataOk()
    {
        return true;
    }
    /// <summary>
    /// As its name suggest if there isn't an object
    /// it'll create it. It exists modify it.
    /// </summary>
    /// <returns></returns>
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (clinicId == 0)
        {
            cl = new Clinic();
            UnloadData(cl);
            ctx.Add(cl);
        }
        else
        {
            cl = (from c in ctx.Clinics
                  where c.ClinicId == clinicId
                  select c).FirstOrDefault<Clinic>();
            UnloadData(cl);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Clinic cl)
    {
        txtClinicId.Text = cl.ClinicId.ToString();
        txtName.Text = cl.Name;
        txtRemoteIp.Text = cl.RemoteIp;
    }
    protected void UnloadData(Clinic hc)
    {
        cl.Name = txtName.Text;
        cl.RemoteIp = txtRemoteIp.Text;
    }
    #endregion Auxiliary functions

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "address":
                UscAddressGrid1.RefreshGrid(true);
                break;
            case "telephone":
                UscTelephoneGrid1.RefreshGrid(true);
                break;
            case "email":
                UscEmailGrid1.RefreshGrid(true);
                break;
        }
    }



}
