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
    Request req = null;
    int requestId = 0;
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
                            where p.Code == "request"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        
        // 
        if (Request.QueryString["RequestId"] != null)
        {
            requestId = Int32.Parse(Request.QueryString["RequestId"]);
            req = CntAriCli.GetRequest(requestId, ctx);
            LoadData(req);
        }
        else
        {
            // 
            if (Session["Clinic"] != null)
            {
                Clinic cl = (Clinic)Session["Clinic"];
                if (cl != null)
                {
                    rdcClinic.Items.Clear();
                    rdcClinic.Items.Add(new RadComboBoxItem(cl.Name, cl.ClinicId.ToString()));
                    rdcClinic.SelectedValue = cl.ClinicId.ToString();
                }
            }
            // default values for a new request
            rdtRequestDateTime.SelectedDate = DateTime.Now;
            txtStatus.Text = "PENDIENTE";
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
        string message = "";
        if (rdtRequestDateTime.SelectedDate == null)
        {
            message += Resources.GeneralResource.DateNeeded + "<br/>";
        }
        if (rdcPatient.SelectedValue == "" && txtName.Text == "")
        {
            message += Resources.GeneralResource.PatientOrCandidateNeeded + "<br/>";
        }
        if (rdcService.SelectedValue == "" && txtComments.Text == "")
        {
            message += Resources.GeneralResource.RequestInformationNeeded + "<br/>";
        }
        if (rdcPatient.SelectedValue == "" && rdcbSex.SelectedValue == "")
        {
            message += Resources.GeneralResource.SexValueNeeded + "<br/>";
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
        if (req == null)
        {
            req = new Request();
            UnloadData(req);
            ctx.Add(req);
        }
        else
        {
            req = CntAriCli.GetRequest(requestId, ctx);
            UnloadData(req);
        }
        ctx.SaveChanges();
        return true;
    }
        
    protected void LoadData(Request req)
    {
        txtRequestId.Text = req.RequestId.ToString();
        rdtRequestDateTime.SelectedDate = req.RequestDateTime;
        txtStatus.Text = req.Status;
        if (req.Campaign != null)
        {
            rdcCampaign.Items.Clear();
            rdcCampaign.Items.Add(new RadComboBoxItem(req.Campaign.Name, req.Campaign.CampaignId.ToString()));
            rdcCampaign.SelectedValue = req.Campaign.CampaignId.ToString();
        }
        if (req.Channel != null)
        {
            rdcChannel.Items.Clear();
            rdcChannel.Items.Add(new RadComboBoxItem(req.Channel.Name, req.Channel.ChannelId.ToString()));
            rdcChannel.SelectedValue = req.Channel.ChannelId.ToString();
        }
        if (req.Source != null)
        {
            rdcSource.Items.Clear();
            rdcSource.Items.Add(new RadComboBoxItem(req.Source.Name, req.Source.SourceId.ToString()));
            rdcSource.SelectedValue = req.Source.SourceId.ToString();
        }
        if (req.Patient != null)
        {
            rdcPatient.Items.Clear();
            rdcPatient.Items.Add(new RadComboBoxItem(req.Patient.FullName, req.Patient.PersonId.ToString()));
            rdcPatient.SelectedValue = req.Patient.PersonId.ToString();
        }
        if (req.Clinic != null)
        {
            rdcClinic.Items.Clear();
            rdcClinic.Items.Add(new RadComboBoxItem(req.Clinic.Name, req.Clinic.ClinicId.ToString()));
            rdcClinic.SelectedValue = req.Clinic.ClinicId.ToString();
        }
        txtSurname1.Text = req.Surname1;
        txtSurname2.Text = req.Surname2;
        txtName.Text = req.Name;
        rdcbSex.SelectedValue = req.Sex;
        if (req.BornDate != null && req.BornDate != new DateTime())
        {
            rdtBornDate.SelectedDate = req.BornDate;
        }
        txtCodPostal.Text = req.PostalCode;
        txtDni.Text = req.Dni;
        txtEmail.Text = req.Email;
        txtTelephone.Text = req.Telephone;
        if (req.Service != null)
        {
            rdcService.Items.Clear();
            rdcService.Items.Add(new RadComboBoxItem(req.Service.Name, req.Service.ServiceId.ToString()));
            rdcService.SelectedValue = req.Service.ServiceId.ToString();
        }
        txtComments.Text = req.Comments;
    }
        
    protected void UnloadData(Request chn)
    {
        req.RequestDateTime = (DateTime)rdtRequestDateTime.SelectedDate;
        req.Status = txtStatus.Text;
        if (rdcCampaign.SelectedValue != "")
        {
            req.Campaign = CntAriCli.GetCampaign(int.Parse(rdcCampaign.SelectedValue), ctx);
        }
        if (rdcChannel.SelectedValue != "")
        {
            req.Channel = CntAriCli.GetChannel(int.Parse(rdcChannel.SelectedValue), ctx);
        }
        if (rdcSource.SelectedValue != "")
        {
            req.Source = CntAriCli.GetSource(int.Parse(rdcSource.SelectedValue), ctx);
        }
        if (rdcPatient.SelectedValue != "")
        {
            req.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        }
        if (rdcClinic.SelectedValue != "")
        {
            req.Clinic = CntAriCli.GetClinic(int.Parse(rdcClinic.SelectedValue), ctx);
        }
        req.Surname1 = txtSurname1.Text;
        req.Surname2 = txtSurname2.Text;
        req.Name = txtName.Text;
        req.Sex = rdcbSex.SelectedValue;
        if (rdtBornDate.SelectedDate != null)
        {
            req.BornDate = (DateTime)rdtBornDate.SelectedDate;
        }
        req.PostalCode = txtCodPostal.Text;
        req.Dni = txtDni.Text;
        req.Email = txtEmail.Text;
        req.Telephone = txtTelephone.Text;
        if (rdcService.SelectedValue != "")
        {
            req.Service = CntAriCli.GetService(int.Parse(rdcService.SelectedValue), ctx);
        }
        req.Comments = txtComments.Text;
        req.FullName = String.Format("{0} {1}, {2}", req.Surname1, req.Surname2, req.Name);
        req.User = user;
    }
    
    #endregion Auxiliary functions
            
    #region Outside searches
        
    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
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
        if (e.Text == "")
            return;
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
        if (e.Text == "")
            return;
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
        if (e.Text == "")
            return;
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
        if (e.Text == "")
            return;
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

    protected void rdcClinic_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from x in ctx.Clinics
                 where x.Name.Contains(e.Text)
                 select x;
        foreach (Clinic cl in rs)
        {
            combo.Items.Add(new RadComboBoxItem(cl.Name, cl.ClinicId.ToString()));
        }
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
    }
    
    #endregion
    
    #region Special button actions
    
    protected void btnEstimate_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        // check if 
        string command = "";
        if (req.Estimates.Count > 0)
        {
            // There's a replay already
            Estimate est = req.Estimates[0];
            command = String.Format("EditEstimateRecord('{0}','{1}');", est.EstimateId, req.RequestId);
        }
        else
        {
            Estimate est = new Estimate();
            est.User = user;
            est.FullName = req.FullName;
            est.Request = req;
            est.EstimateDate = DateTime.Now;
            if (req.Patient != null)
                est.FullName = req.Patient.FullName;
            else
                est.FullName = req.FullName;
            ctx.Add(est);
            ctx.SaveChanges(); 
            if (req.Service != null)
            {
                if (req.Patient != null && req.Patient.Customer != null && req.Patient.Customer.Policies.Count > 0)
                {
                    Policy pol = req.Patient.Customer.Policies[0];
                    InsuranceService inss = (from i in ctx.InsuranceServices
                                             where i.Insurance == pol.Insurance
                                             && i.Service.ServiceId == req.Service.ServiceId
                                             select i).FirstOrDefault<InsuranceService>();
                    if (inss != null)
                    {
                        // estimate line
                        EstimateLine estl = new EstimateLine();
                        estl.Estimate = est;
                        estl.InsuranceService = inss;
                        estl.Amount = inss.Price;
                        estl.Discount = 0;
                        estl.Description = inss.Service.Name;
                        ctx.Add(estl);
                        est.Total = estl.Amount;
                        ctx.SaveChanges();
                    }
                }
            }
            command = String.Format("EditEstimateRecord('{0}','{1}');", est.EstimateId, req.RequestId);
        }
        // string command = "CloseAndRebind('')";
        RadAjaxManager1.ResponseScripts.Add(command);
    }
        
    protected void btnCopy_Click(object sender, ImageClickEventArgs e)
    {
    }
    
    protected void btnReply_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        //
        string command = "";
        if (req.Replays.Count > 0)
        {
            // There's a replay already
            Replay rep = req.Replays[0];
            command = String.Format("EditReplayRecord('{0}','{1}');", rep.ReplayId, req.RequestId);
        }
        else
        {
            command = String.Format("NewReplayRecord('{0}');",req.RequestId);
        }
        // string command = "CloseAndRebind('')";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    #endregion


}