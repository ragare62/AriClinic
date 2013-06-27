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

public partial class ReplayForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Replay replay = null;
    int replayId = 0;
    Request request = null;
    int requestId = 0;
    Permission per = null;
    string caller = "";
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
                            where p.Code == "request"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        //
        if (Request.QueryString["RequestId"] != null)
        {
            requestId = Int32.Parse(Request.QueryString["RequestId"]);
            request = CntAriCli.GetRequest(requestId, ctx);
            if (request != null)
            {
                string person = "";
                if (request.Patient != null) 
                    person = request.Patient.FullName;
                else 
                    person = request.FullName;
                lblRequestPerson.Text = String.Format("INTERESADO: {0}", person);
                string service = "";
                if (request.Service != null)
                {
                    service = request.Service.Name;
                    rdcService.Items.Clear();
                    rdcService.Items.Add(new RadComboBoxItem(request.Service.Name,request.Service.ServiceId.ToString()));
                    rdcService.SelectedValue = request.Service.ServiceId.ToString();
                }
                lblRequestService.Text = String.Format("SERVICIO: {0}", service);
                lblRequestComments.Text = String.Format("OBSERVACIONES: {0}", request.Comments);
            }
        }

        // 
        if (Request.QueryString["ReplayId"] != null)
        {
            replayId = Int32.Parse(Request.QueryString["ReplayId"]);
            replay = CntAriCli.GetReplay(replayId, ctx);
            LoadData(replay);
        }
        else
        {
            // default values for a new request
            rdtReplayDate.SelectedDate = DateTime.Now;
        }
        //
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
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
        string jsCommand = "";
        if (caller == "RequestForm")
        {
            jsCommand = "CloseAndRequest();";
        }
        else
        {
            jsCommand = "window.close();";
        }
        if (jsCommand != "")
        {
            RadAjaxManager1.ResponseScripts.Add(jsCommand);
        }
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
        string message = "";
        if (rdtReplayDate.SelectedDate == null)
        {
            message += Resources.GeneralResource.DateNeeded + "<br/>";
        }
        if (rdcService.SelectedValue == "" && txtComments.Text == "")
        {
            message += Resources.GeneralResource.RequestInformationNeeded + "<br/>";
        }
        if (message != "")
        {
            lblMessage.Text = message;
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (replay == null)
        {
            replay = new Replay();
            UnloadData(replay);
            ctx.Add(replay);
        }
        else
        {
            replay = CntAriCli.GetReplay(replayId, ctx);
            UnloadData(replay);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Replay replay)
    {
        txtReplayId.Text = replay.ReplayId.ToString();
        rdtReplayDate.SelectedDate = replay.ReplayDate;
        if (replay.Channel != null)
        {
            rdcChannel.Items.Clear();
            rdcChannel.Items.Add(new RadComboBoxItem(replay.Channel.Name, replay.Channel.ChannelId.ToString()));
            rdcChannel.SelectedValue = replay.Channel.ChannelId.ToString();
        }
        if (replay.Service != null)
        {
            rdcService.Items.Clear();
            rdcService.Items.Add(new RadComboBoxItem(replay.Service.Name, replay.Service.ServiceId.ToString()));
            rdcService.SelectedValue = replay.Service.ServiceId.ToString();
        }
        txtComments.Text = replay.Comments;
    }
    protected void UnloadData(Replay chn)
    {
        // creating / editing reply
        replay.ReplayDate = (DateTime)rdtReplayDate.SelectedDate;
        if (rdcChannel.SelectedValue != "")
        {
            replay.Channel = CntAriCli.GetChannel(int.Parse(rdcChannel.SelectedValue), ctx);
        }
        if (rdcService.SelectedValue != "")
        {
            replay.Service = CntAriCli.GetService(int.Parse(rdcService.SelectedValue), ctx);
        }
        replay.Comments = txtComments.Text;
        replay.User = user;
        // changing request accordingly
        request.Status = "CONTESTADA";
        replay.Request = request;
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


    protected void RadAjaxManager1_AjaxReplay(object sender, AjaxRequestEventArgs e)
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
