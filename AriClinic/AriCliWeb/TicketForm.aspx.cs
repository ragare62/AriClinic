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

public partial class TicketForm : System.Web.UI.Page 
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
    Ticket tck = null;
    ServiceNote sn = null;
    int policyId = 0;
    int customerId = 0;
    int insuranceServiceId = 0;
    int ticketId = 0;
    int clinicId = 0;
    int insuranceId = 0;
    int professionalId = 0;
    int serviceNoteId = 0;
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
                            where p.Code == "ticket"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
            if (user.Professionals.Count > 0)
            {
                prof = user.Professionals[0];
                txtProfessionalId.Text = prof.PersonId.ToString();
                txtProfessionalName.Text = prof.FullName;
            }
        }
        // 
        if (Request.QueryString["CustomerId"] != null)
        {
            customerId = Int32.Parse(Request.QueryString["CustomerId"]);
            cus = CntAriCli.GetCustomer(customerId, ctx);
            txtCustomerId.Text = cus.PersonId.ToString();
            txtComercialName.Text = cus.FullName;
            // if a patient has been passed we can not touch it
            txtCustomerId.Enabled = false;
            txtComercialName.Enabled = false;
            btnCustomerId.Visible = false;
            LoadPolicyCombo(null);
        }
        else
        {
            LoadPolicyCombo(null);
            LoadClinicCombo(null);
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        //
        if (Request.QueryString["ServiceNoteId"] != null)
        {
            serviceNoteId = int.Parse(Request.QueryString["ServiceNoteId"]);
            sn = CntAriCli.GetServiceNote(serviceNoteId, ctx);
            // disable select fields
            cus = sn.Customer;
            txtCustomerId.Text = cus.PersonId.ToString(); txtCustomerId.Enabled = false;
            txtComercialName.Text = cus.FullName; txtComercialName.Enabled = false;
            cl = sn.Clinic;
            prof = sn.Professional;
            if (prof != null)
            {
                txtProfessionalId.Text = prof.PersonId.ToString(); txtProfessionalId.Enabled = false;
                txtProfessionalName.Text = prof.FullName; txtProfessionalName.Enabled = false;
            }
            rddpTicketDate.SelectedDate = sn.ServiceNoteDate;
        }
        // 
        if (Request.QueryString["TicketId"] != null)
        {
            ticketId = Int32.Parse(Request.QueryString["TicketId"]);
            tck = CntAriCli.GetTicket(ticketId, ctx);
            cus = tck.Policy.Customer;
            customerId = cus.PersonId;
            if (tck.ServiceNote != null)
            {
                sn = tck.ServiceNote;
                serviceNoteId = sn.ServiceNoteId;
            }
            LoadData(tck);
        }
        else
        {
            // If there isn't a ticket the default date must be today
            rddpTicketDate.SelectedDate = DateTime.Now;
            if (sn != null)
                rddpTicketDate.SelectedDate = sn.ServiceNoteDate;
            LoadPolicyCombo(null);
            LoadClinicCombo(null);
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
        if (pol == null)
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
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (tck == null)
        {
            tck = new Ticket();
            UnloadData(tck);
            ctx.Add(tck);
        }
        else
        {
            tck = CntAriCli.GetTicket(ticketId, ctx);
            UnloadData(tck);
        }
        ctx.SaveChanges();
        //
        CntAriCli.CheckConversionRequest(tck, ctx);
        return true;
    }

    protected void LoadData(Ticket tck)
    {
        txtTicketId.Text = tck.TicketId.ToString();
        txtCustomerId.Text = tck.Policy.Customer.PersonId.ToString();
        txtComercialName.Text = tck.Policy.Customer.FullName;
        rddpTicketDate.SelectedDate = tck.TicketDate;
        LoadPolicyCombo(tck);
        LoadClinicCombo(tck);
        txtInsuranceServiceId.Text = tck.InsuranceService.InsuranceServiceId.ToString();
        txtInsuranceServiceName.Text = tck.InsuranceService.Service.Name;
        txtDescription.Text = tck.Description;
        //txtAmount.Text = String.Format("{0:###,##0.00}", tck.Amount);
        txtPrice.Text = tck.Price.ToString();
        txtDiscount.Text = tck.Discount.ToString();
        txtAmount.Text = tck.Amount.ToString();
        //
        chkChecked.Checked = tck.Checked;
        if (tck.Professional != null)
        {
            txtProfessionalId.Text = tck.Professional.PersonId.ToString();
            txtProfessionalName.Text = tck.Professional.FullName;
        }
        txtComments.Text = tck.Comments;
    }

    protected void UnloadData(Ticket tck)
    {
        tck.TicketDate = (DateTime)rddpTicketDate.SelectedDate;
        policyId = Int32.Parse(rdcbPolicy.SelectedValue);
        tck.Policy = CntAriCli.GetPolicy(policyId, ctx);
        insuranceServiceId = Int32.Parse(txtInsuranceServiceId.Text);
        tck.InsuranceService = CntAriCli.GetInsuranceService(insuranceServiceId, ctx);
        if (rdcbClinic.SelectedValue != "")
        {
            clinicId = Int32.Parse(rdcbClinic.SelectedValue);
            tck.Clinic = CntAriCli.GetClinic(clinicId, ctx);
        }
        tck.User = CntAriCli.GetUser(user.UserId, ctx);
        tck.Description = txtDescription.Text;
        tck.Price = Decimal.Parse(txtPrice.Text);
        tck.Discount = Decimal.Parse(txtDiscount.Text);
        tck.Amount = Decimal.Parse(txtAmount.Text);
        tck.Checked = chkChecked.Checked;
        if (txtProfessionalId.Text != "")
        {
            professionalId = Int32.Parse(txtProfessionalId.Text);
            tck.Professional = CntAriCli.GetProfessional(professionalId, ctx);
        }
        else
        {
            tck.Professional = null;
        }
        tck.Comments = txtComments.Text;
        // Is there a service note?
        if (sn != null)
        {
            tck.ServiceNote = sn;
        }

    }

    protected void LoadPolicyCombo(Ticket tck)
    {
        string desc = "";
        rdcbPolicy.Items.Clear();
        if (tck != null)
        {
            foreach (Policy p in tck.Policy.Customer.Policies)
            {
                desc = String.Format("{0} [{1} - {2}]", p.Insurance.Name
                                     , CntAriCli.DateNullFormat(p.BeginDate)
                                     , CntAriCli.DateNullFormat(p.EndDate));
                rdcbPolicy.Items.Add(new RadComboBoxItem(desc, p.PolicyId.ToString()));
            }
            rdcbPolicy.SelectedValue = tck.Policy.PolicyId.ToString();
        }
        else
        {
            if (cus != null)
            {
                foreach (Policy p in cus.Policies)
                {
                    desc = String.Format("{0} [{1} - {2}]", p.Insurance.Name
                                         , CntAriCli.DateNullFormat(p.BeginDate)
                                         , CntAriCli.DateNullFormat(p.EndDate));
                    rdcbPolicy.Items.Add(new RadComboBoxItem(desc, p.PolicyId.ToString()));
                    if (p.Type == Resources.ConstantsResource.Primary)
                        rdcbPolicy.SelectedValue = p.PolicyId.ToString();
                }
                Policy pol = (from po in cus.Policies
                              where po.Type == "Primary"
                              select po).FirstOrDefault<Policy>();
                if (pol != null) rdcbPolicy.SelectedValue = pol.PolicyId.ToString();
            }
        }
    }

    protected void LoadClinicCombo(Ticket tck)
    {
        // clear previous items 
        rdcbClinic.Items.Clear();
        foreach (Clinic c in ctx.Clinics)
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(c.Name, c.ClinicId.ToString()));
        }
        if (tck != null && tck.Clinic != null)
        {
            rdcbClinic.SelectedValue = tck.Clinic.ClinicId.ToString();
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


    #region Searching outside
    protected void txtCustomerId_TextChanged(object sender, EventArgs e)
    {
        // search for a Customer
        customerId = Int32.Parse(txtCustomerId.Text);
        cus = CntAriCli.GetCustomer(customerId, ctx);
        if (cus != null)
        {
            txtCustomerId.Text = cus.PersonId.ToString();
            txtComercialName.Text = cus.FullName;
        }
        else
        {
            txtCustomerId.Text = "";
            txtComercialName.Text = Resources.GeneralResource.CustomerDoesNotExists;
        }
        // load policy combo
        LoadPolicyCombo(null);

    }

    protected void txtInsuranceServiceId_TextChanged(object sender, EventArgs e)
    {
        // check before go to search thats a policy selected
        if (rdcbPolicy.SelectedValue == "")
        {
            lblMessage.Text = Resources.GeneralResource.PolicyNeeded;
            return;
        }
        // insurance selected
        policyId = Int32.Parse(rdcbPolicy.SelectedValue);
        pol = CntAriCli.GetPolicy(policyId, ctx);
        insurance = pol.Insurance;
        // serach for Insurance Service
        insuranceServiceId = Int32.Parse(txtInsuranceServiceId.Text);
        insuranceService = CntAriCli.GetInsuranceService(insuranceServiceId,insurance, ctx);
        if (insuranceService != null)
        {
            txtInsuranceServiceId.Text = insuranceService.InsuranceServiceId.ToString();
            txtInsuranceServiceName.Text = insuranceService.Service.Name;
            // Solo cambiamos la descripción si no había algo previamente
            if (txtDescription.Text == "")
                txtDescription.Text = insuranceService.Service.Name;
            //txtAmount.Text = String.Format("{0:0.00}", insuranceService.Price);
            if (txtAmount.Text == "")
                txtAmount.Text = insuranceService.Price.ToString();
            // loading prices, discount is zero by default.
            txtPrice.Text = insuranceService.Price.ToString();
            txtDiscount.Text = "0";
        }
        else
        {
            txtInsuranceServiceId.Text = "";
            txtInsuranceServiceName.Text = Resources.GeneralResource.InsuranceServiceDoesNotExists;
            txtPrice.Text = "0";
            txtDiscount.Text = "0";
            txtAmount.Text = "0";
        }

    }

    protected void btnInsuranceServiceId_Click(object sender, ImageClickEventArgs e)
    {
        // check before go to search thats a policy selected
        if (rdcbPolicy.SelectedValue == "")
        {
            lblMessage.Text = Resources.GeneralResource.PolicyNeeded;
            return;
        }
        policyId = Int32.Parse(rdcbPolicy.SelectedValue);
        pol = CntAriCli.GetPolicy(policyId, ctx);
        string command = String.Format("searchInsuranceService({0});", pol.Insurance.InsuranceId);
        RadAjaxManager1.ResponseScripts.Add(command);
    }


    protected void txtProfessionalId_TextChanged(object sender, EventArgs e)
    {
        professionalId = Int32.Parse(txtProfessionalId.Text);
        prof = CntAriCli.GetProfessional(professionalId, ctx);
        if (prof != null)
        {
            txtProfessionalId.Text = prof.PersonId.ToString();
            txtProfessionalName.Text = prof.FullName;
        }
        else
        {
            txtProfessionalId.Text = "";
            txtProfessionalName.Text = Resources.GeneralResource.ProfessionalDoesNotExists;
        }
    }
    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        customerId = Int32.Parse(e.Argument);
        cus = CntAriCli.GetCustomer(customerId, ctx);
        LoadPolicyCombo(null);
    }

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        // It could be an amount or a percentage.
        //
        string campoDiscount = txtDiscount.Text;
        decimal discount = 0;
        int pos = campoDiscount.IndexOf("%");
        if (pos > 0)
        {
            string resto = campoDiscount.Substring(0, pos);
            decimal porc = 0;
            if (decimal.TryParse(resto, out porc))
            {
                discount = (decimal.Parse(txtPrice.Text) * (decimal)porc) / (decimal)100.0;
                txtDiscount.Text = String.Format("{0:0.00}", discount);
                txtAmount.Text = (decimal.Parse(txtPrice.Text) - discount).ToString();
            }
        }
        else
        {
            if (decimal.TryParse(txtDiscount.Text, out discount))
            {
                // refersh total
                txtAmount.Text = (decimal.Parse(txtPrice.Text) - discount).ToString();
            }
            else
            {
                lblMessage.Text = "Valor de descuento no válido";
            }
        }
    }




}
