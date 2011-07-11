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

public partial class AnestheticServiceNoteForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx;// = null;
    User user = null;
    Clinic cl = null;
    Policy pol = null;
    Customer cus = null;
    InsuranceService insuranceService = null;
    Insurance insurance = null;
    Professional prof = null;
    Professional srg = null;
    Procedure proc = null;
    AnestheticServiceNote asn = null;
    bool firstTime;
    int policyId = 0;
    int customerId = 0;
    int insuranceServiceId = 0;
    int ticketId = 0;
    int clinicId = 0;
    int insuranceId = 0;
    int professionalId = 0;
    int surgeonId = 0;
    int procedureId = 0;
    int anestheticServiceNoteId = 0;
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

       
            if (Request.QueryString["CustomerId"] != null)
            {
                customerId = Int32.Parse(Request.QueryString["CustomerId"]);
                cus = CntAriCli.GetCustomer(customerId, ctx);
                //txtCustomerId.Text = cus.PersonId.ToString();

                rdcComercialName.Items.Clear();
                rdcComercialName.Items.Add(new RadComboBoxItem(cus.FullName, cus.PersonId.ToString()));
                rdcComercialName.SelectedValue = cus.PersonId.ToString();
                rdcComercialName.Enabled = false;

                btnCustomerId.Visible = false;
            }
            else
            {
                LoadClinicCombo(null);
            }
            if (Session["Clinic"] != null)
                cl = (Clinic)Session["Clinic"];
            // 
            if (Request.QueryString["AnestheticServiceNoteId"] != null)
            {
                anestheticServiceNoteId = Int32.Parse(Request.QueryString["AnestheticServiceNoteId"]);
                asn = CntAriCli.GetAnestheticServiceNote(anestheticServiceNoteId, ctx);
                cus = asn.Customer;
                customerId = cus.PersonId;
                if(!IsPostBack)
                    LoadData(asn);
                // Load internal frame
                HtmlControl frm = (HtmlControl)this.FindControl("ifTickets");
                frm.Attributes["src"] = String.Format("TicketGrid.aspx?AnestheticServiceNoteId={0}", anestheticServiceNoteId);
            }
            else
            {
                // If there isn't a ticket the default date must be today
                rddpServiceNoteDate.SelectedDate = DateTime.Now;
                LoadClinicCombo(null);
                //HtmlControl frm = (HtmlControl)this.FindControl("ifTickets");
                //frm.Attributes["src"] = "TicketGrid.aspx?AnestheticServiceNoteId=0";
            }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Add("procedurechanged", false);
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
        command = "CloseAndRebind('')";

        if (!DataOk())
            return;
        
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
        if (rdcProcedureName1.SelectedValue == "")
            errorMessage += Resources.GeneralResource.ProcedureNeeded + "<br/>";

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
        if (asn == null)
        {
            firstTime = true;
            asn = new AnestheticServiceNote();
            UnloadData(asn);
            ctx.Add(asn);
        }
        else
        { 
            asn = CntAriCli.GetAnestheticServiceNote(anestheticServiceNoteId, ctx);
            bool procedurechanged = false;
            if(Session["procedurechanged"]!=null)
                procedurechanged = (bool)Session["procedurechanged"];
            if (procedurechanged )
            {
                firstTime = true;
                Session["procedurechanged"] = null;

                asn.AnestheticTickets.Clear();
                asn.Procedures.Clear();
            }
            UnloadData(asn);
        }
        ctx.SaveChanges();
        
        return UpdateRelatedTickets(asn);
    }

    protected bool UpdateRelatedTickets(AnestheticServiceNote asn)
    {
        try
        {
            if (firstTime)
            {
                CntAriCli.CheckAnestheticServiceNoteTickets(asn, ctx);
                firstTime = false;
                Response.Redirect(String.Format("AnestheticServiceNoteForm.aspx?AnestheticServiceNoteId={0}", asn.AnestheticServiceNoteId));
            }
        }
        catch (AriCliException ex)
        {
            string message = "";
            switch (ex.Number)
            {
                case 1:
                    message = Resources.GeneralResource.NoPrimaryPolicy;
                    break;
                case 2:
                    message = Resources.GeneralResource.NoPainPump;
                    break;
                case 3:
                    message = Resources.GeneralResource.NoNomenclatorService;
                    break;
                default:
                    message = ex.Message;
                    break;
            }
            string command = String.Format("showDialog('{0}','{1}','warning',null,0,0);"
                                           , Resources.GeneralResource.Warning
                                           , message);
            RadAjaxManager1.ResponseScripts.Add(command);
            Session["LinkId"] = asn.AnestheticServiceNoteId;
            return false;
        }
        return true;
    }

    protected void LoadData(AnestheticServiceNote asn)
    {
        txtAnestheticServiceNoteId.Text = asn.AnestheticServiceNoteId.ToString();
        //txtCustomerId.Text = asn.Customer.PersonId.ToString();
        rdcComercialName.Items.Clear();
        rdcComercialName.Items.Add(new RadComboBoxItem(asn.Customer.FullName, asn.Customer.PersonId.ToString()));
        rdcComercialName.SelectedValue = asn.Customer.PersonId.ToString();
        rddpServiceNoteDate.SelectedDate = asn.ServiceNoteDate;
        LoadClinicCombo(asn);
        txtTotal.Text = asn.Total.ToString();
        //
        chkChecked.Checked = asn.Chk1;
        chkCkecked2.Checked = asn.Chk2;
        if (asn.Professional != null)
        {
            //txtProfessionalId.Text = asn.Professional.PersonId.ToString();
            rdcProfessionalName.Items.Clear();
            rdcProfessionalName.Items.Add(new RadComboBoxItem(asn.Professional.FullName, asn.Professional.PersonId.ToString()));
            rdcProfessionalName.SelectedValue = asn.Professional.PersonId.ToString();
        }
        if (asn.Surgeon != null) 
        {
            //txtSurgeonId.Text = asn.Surgeon.PersonId.ToString();
            rdcSurgeonName.Items.Clear();
            rdcSurgeonName.Items.Add(new RadComboBoxItem(asn.Surgeon.FullName, asn.Surgeon.PersonId.ToString()));
            rdcSurgeonName.SelectedValue = asn.Surgeon.PersonId.ToString();
            //txtSurgeonName.Text = asn.Surgeon.FullName;
        }
        if (asn.Procedures[0] != null)
        {
            //txtProcedureId1.Text = asn.Procedures[0].ProcedureId.ToString();
            rdcProcedureName1.Items.Clear();
            rdcProcedureName1.Items.Add(new RadComboBoxItem(asn.Procedures[0].Name, asn.Procedures[0].ProcedureId.ToString()));
            rdcProcedureName1.SelectedValue = asn.Procedures[0].ProcedureId.ToString();
            //txtProcedureName1.Text = asn.Procedures[0].Name;
        }
        if (asn.Procedures.Count > 1)
        {
            if (asn.Procedures[1] != null)
            {
                //txtProcedureId2.Text = asn.Procedures[1].ProcedureId.ToString();
                //txtProcedureName2.Text = asn.Procedures[1].Name;
                rdcProcedureName2.Items.Clear();
                rdcProcedureName2.Items.Add(new RadComboBoxItem(asn.Procedures[1].Name, asn.Procedures[1].ProcedureId.ToString()));
                rdcProcedureName2.SelectedValue = asn.Procedures[1].ProcedureId.ToString();
            }
        }
        if (asn.Procedures.Count > 2)
        {
            if (asn.Procedures[2] != null)
            {
                //txtProcedureId3.Text = asn.Procedures[2].ProcedureId.ToString();
                //txtProcedureName3.Text = asn.Procedures[2].Name;
                rdcProcedureName3.Items.Clear();
                rdcProcedureName3.Items.Add(new RadComboBoxItem(asn.Procedures[2].Name, asn.Procedures[2].ProcedureId.ToString()));
                rdcProcedureName3.SelectedValue = asn.Procedures[2].ProcedureId.ToString();
            }
        }
    }

    protected void UnloadData(AnestheticServiceNote asn)
    {
        asn.ServiceNoteDate = (DateTime)rddpServiceNoteDate.SelectedDate;
        clinicId = Int32.Parse(rdcbClinic.SelectedValue);
        asn.Clinic = CntAriCli.GetClinic(clinicId, ctx);
        asn.User = CntAriCli.GetUser(user.UserId, ctx);
        //
        decimal tt = 0;
        decimal.TryParse(txtTotal.Text, out tt);
        asn.Total = tt;
        //
        asn.Chk1 = chkChecked.Checked;
        asn.Chk2 = chkCkecked2.Checked;
        //customerId = Int32.Parse(txtCustomerId.Text);
        asn.Customer = CntAriCli.GetCustomer(int.Parse(rdcComercialName.SelectedValue), ctx);
        if (rdcProfessionalName.SelectedValue != "")
        {
            professionalId = Int32.Parse(rdcProfessionalName.SelectedValue);
            asn.Professional = CntAriCli.GetProfessional(professionalId, ctx);
        }
        else
        {
            asn.Professional = null;
        }
        if (rdcSurgeonName.SelectedValue != "")
        {
            surgeonId = Int32.Parse(rdcSurgeonName.SelectedValue);
            asn.Surgeon = CntAriCli.GetProfessional(surgeonId, ctx);
        }
        else
        {
            asn.Surgeon = null;
        }

        asn.Procedures.Clear();
        if (rdcProcedureName1.SelectedValue != "")
        {
            procedureId = Int32.Parse(rdcProcedureName1.SelectedValue);
            asn.Procedures.Add(CntAriCli.GetProcedure(procedureId, ctx));
        }
        if (rdcProcedureName2.SelectedValue != "")
        {
            procedureId = Int32.Parse(rdcProcedureName2.SelectedValue);
            asn.Procedures.Add(CntAriCli.GetProcedure(procedureId, ctx));
        }
        if (rdcProcedureName3.SelectedValue != "")
        {
            procedureId = Int32.Parse(rdcProcedureName3.SelectedValue);
            asn.Procedures.Add(CntAriCli.GetProcedure(procedureId, ctx));
        }
    }

    protected void LoadClinicCombo(AnestheticServiceNote asn)
    {
        // clear previous items 
        rdcbClinic.Items.Clear();
        foreach (Clinic c in ctx.Clinics)
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(c.Name, c.ClinicId.ToString()));
        }
        if (asn != null)
        {
            rdcbClinic.SelectedValue = asn.Clinic.ClinicId.ToString();
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
                if (asn != null)
                {
                    foreach (AnestheticTicket at in asn.AnestheticTickets)
                    {
                        tot += at.Amount;
                    }
                }
                txtTotal.Text = String.Format("{0:0.00}", tot);
                asn.Total = tot;
                ctx.SaveChanges();
                break;
            case "yes":
                break;
            case "no":
                Response.Redirect(String.Format("AnestheticServiceNoteForm.aspx?AnestheticServiceNoteId={0}", Session["LinkId"]));
                break;
        }
    }

    #region Searching outside
    
    //protected void txtProcedureId1_TextChanged(object sender, EventArgs e)
    //{
    //    procedurechanged = true;
    //    Procedure proc = CntAriCli.GetProcedure(int.Parse(txtProcedureId1.Text), ctx);
    //    if (proc != null)
    //    {
    //        //txtProcedureId1.Text = proc.ProcedureId.ToString();
    //        txtProcedureName1.Text = proc.Name;
    //    }
    //    else
    //    {
    //        txtProcedureId1.Text = "";
    //        txtProcedureName1.Text = Resources.GeneralResource.ProcedureDoesNotExists;
    //    }
    //}

    //protected void txtProcedureId2_TextChanged(object sender, EventArgs e)
    //{
    //    procedurechanged = true;
    //    Procedure proc = CntAriCli.GetProcedure(int.Parse(txtProcedureId2.Text), ctx);
    //    if (proc != null)
    //    {
    //        txtProcedureId2.Text = proc.ProcedureId.ToString();
    //        txtProcedureName2.Text = proc.Name;
    //    }
    //    else
    //    {
    //        txtProcedureId2.Text = "";
    //        txtProcedureName2.Text = Resources.GeneralResource.ProcedureDoesNotExists;
    //    }
    //}

    //protected void txtProcedureId3_TextChanged(object sender, EventArgs e)
    //{
    //    procedurechanged = true;
    //    Procedure proc = CntAriCli.GetProcedure(int.Parse(txtProcedureId3.Text), ctx);
    //    if (proc != null)
    //    {
    //        txtProcedureId3.Text = proc.ProcedureId.ToString();
    //        txtProcedureName3.Text = proc.Name;
    //    }
    //    else
    //    {
    //        txtProcedureId3.Text = "";
    //        txtProcedureName3.Text = Resources.GeneralResource.ProcedureDoesNotExists;
    //    }
    //}
    #endregion

    #region [inteligence search events]
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

    protected void rdcProcedureName_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Procedures
                 where p.Name.StartsWith(e.Text)
                 select p;
        foreach (Procedure proc in rs)
        {
            combo.Items.Add(new RadComboBoxItem(proc.Name, proc.ProcedureId.ToString()));
        }
    }
    #endregion
    
    protected void rdcProcedureName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Session.Add("procedurechanged", true);
        CreateChange();       
    }

    protected void btnInvoice_Click(object sender, ImageClickEventArgs e)
    {
        if (asn == null) return;
        if (asn.Invoice == null)
        {
            if (CntAriCli.ContainsAnesthesicTicketsInvoiced(asn, ctx))
            {
                RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','error',null,0,0);"
                                   , Resources.GeneralResource.Error
                                   , Resources.GeneralResource.ContainsTicketsInvoiced));
                return;
            }
            int invoiceId = CntAriCli.InvoiceAnesthesicServiceNote(asn, ctx);
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
            RadAjaxManager1.ResponseScripts.Add(String.Format("EditInvoiceRecord({0});", asn.Invoice.InvoiceId));
        }
    }
}