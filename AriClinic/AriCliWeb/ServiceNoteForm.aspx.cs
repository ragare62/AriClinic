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

public partial class ServiceNoteForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Clinic cl = null;
    Policy pol = null;
    Customer cus = null;
    InsuranceService insuranceService = null;
    Insurance insurance = null;
    Professional prof = null;
    ServiceNote sn = null;
    bool firstTime = false;
    int policyId = 0;
    int customerId = 0;
    int insuranceServiceId = 0;
    int ticketId = 0;
    int clinicId = 0;
    int insuranceId = 0;
    int professionalId = 0;
    int serviceNoteId = 0;
    Permission per = null;
    HtmlControl frame = null;

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
                            where p.Code == "ticket"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        // 
        if (Request.QueryString["CustomerId"] != null)
        {
            customerId = Int32.Parse(Request.QueryString["CustomerId"]);
            cus = CntAriCli.GetCustomer(customerId, ctx);
            //txtCustomerId.Text = cus.PersonId.ToString();

            rdcComercialName.Items.Clear();
            rdcComercialName.Items.Add(new RadComboBoxItem(cus.FullName, cus.PersonId.ToString()));
            rdcComercialName.SelectedValue = cus.PersonId.ToString();
            //txtComercialName.Text = cus.FullName;
            // if a patient has been passed we can not touch it
            //txtCustomerId.Enabled = false;
            btnCustomerId.Visible = false;
        }
        else
        {
            LoadClinicCombo(null);
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        // 
        if (Request.QueryString["ServiceNoteId"] != null)
        {
            serviceNoteId = Int32.Parse(Request.QueryString["ServiceNoteId"]);
            sn = CntAriCli.GetServiceNote(serviceNoteId, ctx);
            cus = sn.Customer;
            customerId = cus.PersonId;
            LoadData(sn);
            // Load internal frame
            HtmlControl frm = (HtmlControl)this.FindControl("ifTickets");
            frm.Attributes["src"] = String.Format("TicketGrid.aspx?ServiceNoteId={0}", serviceNoteId);
        }
        else
        {
            // If there isn't a ticket the default date must be today
            rddpServiceNoteDate.SelectedDate = DateTime.Now;
            LoadClinicCombo(null);
            firstTime = true;
            btnInvoice.Visible = false;
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
        if (sn == null)
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
        string errorMessage = "";
        if (rdcComercialName.SelectedValue == "")
            errorMessage += Resources.GeneralResource.CustomerNeeded + "<br/>";
        if (rdcProfessionalName.SelectedValue == "")
            errorMessage += Resources.GeneralResource.ProfessionalNeeded + "<br/>";
        if (errorMessage != "")
        {
            string command = String.Format("showDialog('{0}','{1}','warning',null,0,0);"
                                           , Resources.GeneralResource.Warning
                                           , errorMessage);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        else
            return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (sn == null)
        {
            firstTime = true;
            sn = new ServiceNote();
            UnloadData(sn);
            ctx.Add(sn);
        }
        else
        {
            sn = CntAriCli.GetServiceNote(serviceNoteId, ctx);
            UnloadData(sn);
        }
        ctx.SaveChanges();
        // control that this note have lines
        if (firstTime && sn.Tickets.Count() == 0)
        {
            firstTime = false;
            string command = String.Format("ariDialog('{0}','{1}','warning',null,0,0);"
                                           , Resources.GeneralResource.Warning
                                           , Resources.GeneralResource.ServiceNoteLinesNedeed);
            RadAjaxManager1.ResponseScripts.Add(command);
            Session["LinkId"] = sn.ServiceNoteId;
            return false;
        }
        return true;
    }

    protected void LoadData(ServiceNote sn)
    {
        txtServiceNoteId.Text = sn.ServiceNoteId.ToString();
        //txtCustomerId.Text = sn.Customer.PersonId.ToString();

        rdcComercialName.Items.Clear();
        rdcComercialName.Items.Add(new RadComboBoxItem(sn.Customer.FullName, sn.Customer.PersonId.ToString()));
        rdcComercialName.SelectedValue = sn.Customer.PersonId.ToString();
        //txtComercialName.Text = sn.Customer.FullName;
        rddpServiceNoteDate.SelectedDate = sn.ServiceNoteDate;
        LoadClinicCombo(sn);
        txtTotal.Text = sn.Total.ToString();
        if (sn.Professional != null)
        {
            //txtProfessionalId.Text = sn.Professional.PersonId.ToString();
            rdcProfessionalName.Items.Clear();
            rdcProfessionalName.Items.Add(new RadComboBoxItem(sn.Professional.FullName, sn.Professional.PersonId.ToString()));
            rdcProfessionalName.SelectedValue = sn.Professional.PersonId.ToString();
            //txtProfessionalName.Text = sn.Professional.FullName;
        }
    }

    protected void UnloadData(ServiceNote sn)
    {
        sn.ServiceNoteDate = (DateTime)rddpServiceNoteDate.SelectedDate;
        clinicId = Int32.Parse(rdcbClinic.SelectedValue);
        sn.Clinic = CntAriCli.GetClinic(clinicId, ctx);
        sn.User = CntAriCli.GetUser(user.UserId, ctx);
        //
        decimal tt = 0;
        decimal.TryParse(txtTotal.Text, out tt);
        sn.Total = tt;
        //
        customerId = Int32.Parse(rdcComercialName.SelectedValue);
        sn.Customer = CntAriCli.GetCustomer(customerId, ctx);
        if (rdcProfessionalName.SelectedValue != "")
        {
            professionalId = Int32.Parse(rdcProfessionalName.SelectedValue);
            sn.Professional = CntAriCli.GetProfessional(professionalId, ctx);
        }
        else
        {
            sn.Professional = null;
        }
    }

    protected void LoadClinicCombo(ServiceNote sn)
    {
        // clear previous items 
        rdcbClinic.Items.Clear();
        foreach (Clinic c in ctx.Clinics)
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(c.Name, c.ClinicId.ToString()));
        }
        if (sn != null)
        {
            rdcbClinic.SelectedValue = sn.Clinic.ClinicId.ToString();
        }
        else
        {
            if (cl != null)
            {
                rdcbClinic.SelectedValue = cl.ClinicId.ToString();
            }
            else
            {
                rdcbClinic.Items.Add(new RadComboBoxItem(" ", ""));
                rdcbClinic.SelectedValue = "";
            }
        }
    }

    #endregion Auxiliary functions

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "updateTotal":
                decimal tot = 0;
                if (sn != null)
                {
                    foreach (Ticket t in sn.Tickets)
                    {
                        tot += t.Amount;
                    }
                }
                txtTotal.Text = String.Format("{0:0.00}", tot);
                break;
            case "yes":
                break;
            case "no":
                Response.Redirect(String.Format("ServiceNoteForm.aspx?ServiceNoteId={0}", Session["LinkId"]));
                break;
        }
    }
    #region Searching outside
    
    #endregion

    protected void btnInvoice_Click(object sender, ImageClickEventArgs e)
    {
        if (sn == null) return;
        if (sn.Invoice == null)
        {
            if (CntAriCli.ContainsTicketsInvoiced(sn,ctx))
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','error',null,0,0);"
                                   , Resources.GeneralResource.Error
                                   , Resources.GeneralResource.ContainsTicketsInvoiced));
                return;
            }
            int invoiceId = CntAriCli.InvoiceServiceNote(sn, ctx);
            Invoice i = CntAriCli.GetInvoice(invoiceId, ctx);
            if (i != null)
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("EditInvoiceRecord({0});", i.InvoiceId));
            }
            else
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','error',null,0,0);"
                                   , Resources.GeneralResource.Error
                                   , Resources.GeneralResource.InvoiceError));
            }
        }
        else
        {
            RadAjaxManager1.ResponseScripts.Add(String.Format("EditInvoiceRecord({0});", sn.Invoice.InvoiceId));
        }
    }

    protected void rdctxtProfessionalName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Professionals
                 where p.FullName.StartsWith(e.Text)
                 select p;
        foreach (Professional prof in rs)
        {
            combo.Items.Add(new RadComboBoxItem(prof.FullName, prof.PersonId.ToString()));
        }
    }

    protected void rdcComercialName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from c in ctx.Customers
                 where c.FullName.StartsWith(e.Text)
                 select c;
        foreach (Customer cus in rs)
        {
            combo.Items.Add(new RadComboBoxItem(cus.FullName, cus.PersonId.ToString()));
        }
    }


}
