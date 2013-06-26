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

public partial class RequestForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Request chn = null;
    int channelId = 0;
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
                            where p.Code == "channel"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["RequestId"] != null)
        {
            channelId = Int32.Parse(Request.QueryString["RequestId"]);
            chn = CntAriCli.GetRequest(channelId, ctx);
            LoadData(chn);
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
        if (chn == null)
        {
            chn = new Request();
            UnloadData(chn);
            ctx.Add(chn);
        }
        else
        {
            chn = CntAriCli.GetRequest(channelId, ctx);
            UnloadData(chn);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Request chn)
    {
        txtRequestId.Text = chn.RequestId.ToString();
    }
    protected void UnloadData(Request chn)
    {
    }
    #endregion Auxiliary functions


    #region Outside searches
    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Patients
                 where p.FullName.Contains(e.Text)
                 select p;
        foreach (Patient patient in rs)
        {
            combo.Items.Add(new RadComboBoxItem(patient.FullName, patient.PersonId.ToString()));
        }
    }

    protected void rdcService_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from x in ctx.Services
                 where x.Name.Contains(e.Text)
                 select x;
        foreach (Service srv in rs)
        {
            combo.Items.Add(new RadComboBoxItem(srv.Name, srv.ServiceId.ToString()));
        }
        
    }

    protected void rdcCampaign_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from x in ctx.Campaigns
                 where x.Name.Contains(e.Text)
                 select x;
        foreach (Campaign cpg in rs)
        {
            combo.Items.Add(new RadComboBoxItem(cpg.Name, cpg.CampaignId.ToString()));
        }
    }

    protected void rdcChannel_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from x in ctx.Channels
                 where x.Name.Contains(e.Text)
                 select x;
        foreach (Channel chnn in rs)
        {
            combo.Items.Add(new RadComboBoxItem(chnn.Name, chnn.ChannelId.ToString()));
        }
    }

    protected void rdcSource_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from x in ctx.Sources
                 where x.Name.Contains(e.Text)
                 select x;
        foreach (Source src in rs)
        {
            combo.Items.Add(new RadComboBoxItem(src.Name, src.SourceId.ToString()));
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }
    #endregion

    #region Special button actions
    protected void btnEstimate_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnCopy_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btnReply_Click(object sender, ImageClickEventArgs e)
    {

    }
    #endregion




}
