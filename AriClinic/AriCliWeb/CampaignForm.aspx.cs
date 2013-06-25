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

public partial class CampaignForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Campaign cpg = null;
    int campaignId = 0;
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
            user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "campaign"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["CampaignId"] != null)
        {
            campaignId = Int32.Parse(Request.QueryString["CampaignId"]);
            cpg = CntAriCli.GetCampaign(campaignId, ctx);
            LoadData(cpg);
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
        // control start / end date
        DateTime? strd = rdtStartDate.SelectedDate;
        DateTime? endd = rdtEndDate.SelectedDate;
        if (strd == null || endd == null)
        {
            lblMessage.Text = Resources.GeneralResource.BeginEndDateTimeNeeded;
            return false;
        }
        if (strd > endd)
        {
            lblMessage.Text = Resources.GeneralResource.FromGreatherThanTo;
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (cpg == null)
        {
            cpg = new Campaign();
            UnloadData(cpg);
            ctx.Add(cpg);
        }
        else
        {
            cpg = CntAriCli.GetCampaign(campaignId, ctx);
            UnloadData(cpg);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Campaign cpg)
    {
        txtCampaignId.Text = cpg.CampaignId.ToString();
        txtName.Text = cpg.Name;
        rdtStartDate.SelectedDate = cpg.StartDate;
        rdtEndDate.SelectedDate = cpg.EndDate;
    }
    protected void UnloadData(Campaign scat)
    {
        scat.Name = txtName.Text;
        cpg.StartDate = (DateTime)rdtStartDate.SelectedDate;
        cpg.EndDate = (DateTime)rdtEndDate.SelectedDate;
    }
    #endregion Auxiliary functions



}
