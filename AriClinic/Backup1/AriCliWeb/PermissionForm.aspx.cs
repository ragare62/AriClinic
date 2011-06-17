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

public partial class PermissionForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    int permissionId = 0;

    #endregion Variables declarations
    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        // security control, it must be a user logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");

        // 
        if (Request.QueryString["PermissionId"] != null)
        {
            permissionId = Int32.Parse(Request.QueryString["PermissionId"]);
            Permission per = (from p in ctx.Permissions
                              where p.PermissionId == permissionId
                              select p).FirstOrDefault<Permission>();
            LoadData(per);
        }
        else
        {
            //TODO: What to do is some want to create a new permission?
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

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (permissionId == 0)
        {
            Permission per = new Permission();
            UnloadData(per);
            ctx.Add(per);
        }
        else
        {
            Permission per = (from p in ctx.Permissions
                              where p.PermissionId == permissionId
                              select p).FirstOrDefault<Permission>();
            UnloadData(per);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Permission p)
    {
        txtGroup.Text = p.UserGroup.Name;
        txtProcess.Text = p.Process.Name;
        chkView.Checked = p.View;
        chkCreate.Checked = p.Create;
        chkModify.Checked = p.Modify;
        chkExecute.Checked = p.Execute;
    }

    protected void UnloadData(Permission p)
    {
        p.View = chkView.Checked;
        p.Create = chkCreate.Checked;
        p.Modify = chkModify.Checked;
        p.Execute = chkExecute.Checked;
    }

    #endregion Auxiliary functions
}
