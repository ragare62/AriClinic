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

public partial class VisitReasonForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    VisitReason visitReason = null;
    int visitReasonId = 0;
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
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "visitreason"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["VisitReasonId"] != null)
        {
            visitReasonId = Int32.Parse(Request.QueryString["VisitReasonId"]);
            visitReason = CntAriCli.GetVisitReason(visitReasonId, ctx);
            LoadData(visitReason);
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
        string command = "";
        if (visitReason == null)
            command = "CloseAndRebind('new')";
        else
            command = "CloseAndRebind('')";
        if (!CreateChange())
            return;
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
        string command = "";
        // check combo values
        if (txtName.Text == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                ,Resources.GeneralResource.Warning
                ,Resources.GeneralResource.NameNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (visitReason == null)
        {
            visitReason = new VisitReason();
            UnloadData(visitReason);
            ctx.Add(visitReason);
        }
        else
        {
            visitReason = CntAriCli.GetVisitReason(visitReasonId, ctx);
            UnloadData(visitReason);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(VisitReason vr)
    {
        txtVisitReasonId.Text = vr.VisitReasonId.ToString();
        txtName.Text = vr.Name;
    }
    protected void UnloadData(VisitReason vr)
    {
        vr.Name = txtName.Text;
    }
    #endregion Auxiliary functions



}
