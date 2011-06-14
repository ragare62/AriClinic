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

public partial class AnestheticTicketForm : System.Web.UI.Page 
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
    Professional srg = null;
    Procedure proc = null;
    AnestheticTicket tck = null;
    AnestheticServiceNote asn = null;
    int policyId = 0;
    int customerId = 0;
    int insuranceServiceId = 0;
    int ticketId = 0;
    int clinicId = 0;
    int insuranceId = 0;
    int professionalId = 0;
    int surgeonId = 0;
    int procedureId = 0;
    int anestheticTicketId = 0;
    int anestheticServiceNoteId = 0;
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
        if (Request.QueryString["TicketId"] != null)
        {
            ticketId = Int32.Parse(Request.QueryString["TicketId"]);
            tck = (AnestheticTicket)CntAriCli.GetTicket(ticketId, ctx);
            cus = tck.Policy.Customer;
            customerId = cus.PersonId;
            LoadData(tck);
        }
        else
        {
            // If there isn't a ticket the default date must be today
            rddpTicketDate.SelectedDate = DateTime.Now;
            LoadPolicyCombo(null);
            LoadClinicCombo(null);
        }
        //
        if (Request.QueryString["AnestheticTicketId"] != null)
        {
            anestheticTicketId = int.Parse(Request.QueryString["AnestheticTicketId"]);
            ticketId = anestheticTicketId; 
            tck = (AnestheticTicket)   CntAriCli.GetTicket(anestheticTicketId, ctx);
            rddpTicketDate.SelectedDate = tck.TicketDate;
            txtCustomerId.Text = tck.Policy.Customer.PersonId.ToString();
            cus = CntAriCli.GetCustomer(tck.Policy.Customer.PersonId, ctx);
            LoadPolicyCombo(tck);
            txtComercialName.Text = cus.ComercialName;
            chkChecked.Checked = tck.Checked;
            if (tck.Professional != null)
            {
                txtProfessionalId.Text = tck.Professional.PersonId.ToString();
                txtProfessionalName.Text = tck.Professional.FullName;
            }
            if (tck.Procedure != null)
            {
                txtProcedureId.Text = tck.Procedure.ProcedureId.ToString();
                txtProcedureName.Text = tck.Procedure.Name;
            }
            if (tck.Surgeon != null)
            {
                txtSurgeonId.Text = tck.Surgeon.PersonId.ToString(); 
                txtSurgeonName.Text = tck.Surgeon.FullName; 
            }
            //
            LoadClinicCombo(tck);
            txtInsuranceServiceId.Text = tck.InsuranceService.InsuranceServiceId.ToString();
            txtInsuranceServiceName.Text = tck.InsuranceService.Service.Name;
            txtDescription.Text = tck.Description;
            txtAmount.Text = tck.Amount.ToString();
            txtComments.Text = tck.Comments;
        }
        //
        if (Request.QueryString["AnestheticServiceNoteId"] != null)
        {
            anestheticServiceNoteId = int.Parse(Request.QueryString["AnestheticServiceNoteid"]);
            asn = CntAriCli.GetAnestheticServiceNote(anestheticServiceNoteId, ctx);
            rddpTicketDate.SelectedDate = asn.ServiceNoteDate; rddpTicketDate.Enabled = false;
            txtCustomerId.Text = asn.Customer.PersonId.ToString(); txtCustomerId.Enabled = false;
            cus = asn.Customer; LoadPolicyCombo(null);
            txtComercialName.Text = asn.Customer.ComercialName; txtComercialName.Enabled = false;
            txtProfessionalId.Text = asn.Professional.PersonId.ToString(); txtProfessionalId.Enabled = false;
            txtProfessionalName.Text = asn.Professional.FullName; txtProfessionalName.Enabled = false;
            txtProcedureId.Text = asn.Procedures[0].ProcedureId.ToString(); txtProcedureId.Enabled = false;
            txtProcedureName.Text = asn.Procedures[0].Name; txtProcedureName.Enabled = false;
            if (asn.Surgeon != null)
            {
                txtSurgeonId.Text = asn.Surgeon.PersonId.ToString(); txtSurgeonId.Enabled = false;
                txtSurgeonName.Text = asn.Surgeon.FullName; txtSurgeonName.Enabled = false;
            }
            SetFocus(FindControl("txtInsuranceServiceId"));
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
        if (txtInsuranceServiceId.Text == "")
        {
            RadAjaxManager1.ResponseScripts.Add(String.Format("dialogShow('{0}','{1}','warning',null,0,0)"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.InsuranceServiceNeeded));
            return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (tck == null)
        {
            tck = new AnestheticTicket();
            UnloadData(tck);
            ctx.Add(tck);
        }
        else
        {
            tck = (AnestheticTicket)CntAriCli.GetTicket(ticketId, ctx);
            UnloadData(tck);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(AnestheticTicket tck)
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
        txtAmount.Text = tck.Amount.ToString();
        //
        chkChecked.Checked = tck.Checked;
        if (tck.Professional != null)
        {
            txtProfessionalId.Text = tck.Professional.PersonId.ToString();
            txtProfessionalName.Text = tck.Professional.FullName;
        }
        if (tck.Surgeon != null) 
             
        {
            txtSurgeonId.Text = tck.Surgeon.PersonId.ToString();
            txtSurgeonName.Text = tck.Surgeon.FullName;
        }
        if (tck.Procedure != null)
        {
            txtProcedureId.Text = tck.Procedure.ProcedureId.ToString();
            txtProcedureName.Text = tck.Procedure.Name;
        }
        txtComments.Text = tck.Comments;
    }

    protected void UnloadData(AnestheticTicket tck)
    {
        tck.TicketDate = (DateTime)rddpTicketDate.SelectedDate;
        policyId = Int32.Parse(rdcbPolicy.SelectedValue);
        tck.Policy = CntAriCli.GetPolicy(policyId, ctx);
        insuranceServiceId = Int32.Parse(txtInsuranceServiceId.Text);
        tck.InsuranceService = CntAriCli.GetInsuranceService(insuranceServiceId, ctx);
        clinicId = Int32.Parse(rdcbClinic.SelectedValue);
        tck.Clinic = CntAriCli.GetClinic(clinicId, ctx);
        tck.User = CntAriCli.GetUser(user.UserId, ctx);
        tck.Description = txtDescription.Text;
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
        if (txtSurgeonId.Text != "")
        {
            surgeonId = Int32.Parse(txtSurgeonId.Text);
            tck.Surgeon = CntAriCli.GetProfessional(surgeonId, ctx);
        }
        else
        {
            tck.Surgeon = null;
        }
        if (txtProcedureId.Text != "")
        {
            procedureId = Int32.Parse(txtProcedureId.Text);
            tck.Procedure = CntAriCli.GetProcedure(procedureId, ctx);
        }
        else
        {
            tck.Procedure = null;
        }
        tck.Comments = txtComments.Text;
        
        // assign anesthetic note if any.
        if (asn != null)
        {
            asn = CntAriCli.GetAnestheticServiceNote(asn.AnestheticServiceNoteId, ctx);
            tck.AnestheticServiceNote = asn;
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
        if (tck != null)
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
            string command = string.Format("dialogShow('{0}','{1}','warning',null,0,0);"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.PolicyNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
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
            txtDescription.Text = insuranceService.Service.Name;
            
            //txtAmount.Text = String.Format("{0:###,##0.00}", insuranceService.Price);
            txtAmount.Text = insuranceService.Price.ToString();
        }
        else
        {
            txtInsuranceServiceId.Text = "";
            txtInsuranceServiceName.Text = Resources.GeneralResource.InsuranceServiceDoesNotExists;
        }

    }
    protected void btnInsuranceServiceId_Click(object sender, ImageClickEventArgs e)
    {
        // check before go to search thats a policy selected
        if (rdcbPolicy.SelectedValue == "")
        {
            RadAjaxManager1.ResponseScripts.Add(String.Format("dialogShow('{0}','{1}','warning',null,0,0);"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.PolicyNeeded));
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
    protected void txtSurgeonId_TextChanged(object sender, EventArgs e)
    {
        surgeonId = Int32.Parse(txtSurgeonId.Text);
        prof = CntAriCli.GetProfessional(surgeonId, ctx);
        if (prof != null)
        {
            txtSurgeonId.Text = prof.PersonId.ToString();
            txtSurgeonName.Text = prof.FullName;
        }
        else
        {
            txtSurgeonId.Text = "";
            txtSurgeonName.Text = Resources.GeneralResource.ProfessionalDoesNotExists;
        }
    }
    protected void txtProcedureId_TextChanged(object sender, EventArgs e)
    {
        procedureId = Int32.Parse(txtProcedureId.Text);
        proc = CntAriCli.GetProcedure(procedureId, ctx);
        if (proc != null)
        {
            txtProcedureId.Text = proc.ProcedureId.ToString();
            txtProcedureName.Text = proc.Name;
        }
        else
        {
            txtProcedureId.Text = "";
            txtProcedureName.Text = Resources.GeneralResource.ProcedureDoesNotExists;
        }
    }
    #endregion
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        customerId = Int32.Parse(e.Argument);
        cus = CntAriCli.GetCustomer(customerId, ctx);
        LoadPolicyCombo(null);
    }


}
