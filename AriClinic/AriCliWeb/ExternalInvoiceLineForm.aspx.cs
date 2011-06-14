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

public partial class ExternalInvoiceLineForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Clinic cl = null;
    Policy pol = null;
    Patient pat = null;
    InsuranceService insuranceService = null;
    Insurance insurance = null;
    Ticket tck = null;
    ExternalInvoice einv = null;
    ExternalInvoiceLine einvl = null;
    TaxType taxt = null;
    int policyId = 0;
    int patientId = 0;
    int insuranceServiceId = 0;
    int ticketId = 0;
    int clinicId = 0;
    int insuranceId = 0;
    int externalInvoiceId = 0;
    int externalInvoiceLineId = 0;
    int taxTypeId = 0;
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
                            where p.Code == "invoice"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        // 
        if (Request.QueryString["ExternalInvoiceId"] != null)
        {
            externalInvoiceId = Int32.Parse(Request.QueryString["ExternalInvoiceId"]);
            einv = (ExternalInvoice)CntAriCli.GetInvoice(externalInvoiceId, ctx);
            LoadInvoiceData();
        }
        else
        {
            //TODO: What to do if there is not an invoice
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        // 
        if (Request.QueryString["ExternalInvoiceLineId"] != null)
        {
            externalInvoiceLineId = Int32.Parse(Request.QueryString["ExternalInvoiceLineId"]);
            einvl = (ExternalInvoiceLine)CntAriCli.GetInvoiceLine(externalInvoiceLineId, ctx);
            LoadData(einvl);
        }
        else
        {
            LoadTaxTypeCombo(null);
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
        if (rdcbTaxType.SelectedValue == "")
        {
            //lblMessage.Text = Resources.GeneralResource.TaxTypeNeeded;
            return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (einvl == null)
        {
            einvl = new ExternalInvoiceLine();
            UnloadData(einvl);
            ctx.Add(einvl);
        }
        else
        {
            einvl = (ExternalInvoiceLine)CntAriCli.GetInvoiceLine(externalInvoiceLineId, ctx);
            UnloadData(einvl);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(ExternalInvoiceLine einvl)
    {
        txtInvoiceLineId.Text = einvl.InvoiceLineId.ToString();
        einv = einvl.ExternalInvoice;
        LoadInvoiceData();
        tck = einvl.Ticket;
        if (tck != null)
        {
            txtTicketId.Text = tck.TicketId.ToString();
            txtTicketData.Text = String.Format("{0} ({1}: {2:###,##0.00})"
                                               , tck.Policy.Customer.FullName
                                               , tck.Description
                                               , tck.Amount);
        }
        LoadTaxTypeCombo(einvl.TaxType);
        txtDescription.Text = einvl.Description;
        txtTaxPercentage.Text = einvl.TaxPercentage.ToString();
        txtAmount.Text = einvl.Amount.ToString();
        txtComissionAmount.Text = einvl.ComissionAmount.ToString();
    }

    protected void UnloadData(ExternalInvoiceLine einvl)
    {
        einvl.Invoice = einv;
        taxTypeId = Int32.Parse(rdcbTaxType.SelectedValue);
        einvl.TaxType = CntAriCli.GetTaxType(taxTypeId, ctx);
        if (txtTicketId.Text != "")
        {
            ticketId = Int32.Parse(txtTicketId.Text);
            einvl.Ticket = CntAriCli.GetTicket(ticketId, ctx);
        }
        einvl.User = CntAriCli.GetUser(user.UserId, ctx);
        einvl.Description = txtDescription.Text;
        einvl.TaxPercentage = Decimal.Parse(txtTaxPercentage.Text);
        einvl.Amount = Decimal.Parse(txtAmount.Text);
        einvl.ComissionAmount = Decimal.Parse(txtComissionAmount.Text);
    }

    protected void LoadInvoiceData()
    {
        txtInvoiceSerial.Text = einv.Serial;
        txtYear.Text = einv.Year.ToString();
        txtInvoiceNumber.Text = String.Format("{0:000000}", einv.InvoiceNumber);
        // if an invoice has been passed we can not touch it
        txtInvoiceSerial.Enabled = false;
        txtYear.Enabled = false;
        txtInvoiceNumber.Enabled = false;
    }

    protected void LoadTaxTypeCombo(TaxType taxt)
    {
        // clear previous items 
        rdcbTaxType.Items.Clear();
        foreach (TaxType t in ctx.TaxTypes)
        {
            rdcbTaxType.Items.Add(new RadComboBoxItem(t.Name, t.TaxTypeId.ToString()));
        }
        if (taxt != null)
        {
            rdcbTaxType.SelectedValue = taxt.TaxTypeId.ToString();
        }
        else
        {
            rdcbTaxType.Items.Add(new RadComboBoxItem(" ", ""));
            rdcbTaxType.SelectedValue = "";
        }
    }

    #endregion Auxiliary functions

    #region Searching outside
    protected void txtTicketId_TextChanged(object sender, EventArgs e)
    {
        // search for a Ticket
        ticketId = Int32.Parse(txtTicketId.Text);
        tck = CntAriCli.GetTicket(ticketId, ctx);
        if (tck != null)
        {
            txtTicketId.Text = tck.TicketId.ToString();
            txtTicketData.Text = String.Format("{0} ({1}: {2:###,##0.00})"
                                               , tck.Policy.Customer.FullName
                                               , tck.Description
                                               , tck.Amount);
            LoadTicketData(tck);
        }
        else
        {
            txtTicketId.Text = "";
            txtTicketData.Text = Resources.GeneralResource.TicketDoesNotExists;
        }
    }

    protected void btnTicketId_Click(object sender, ImageClickEventArgs e)
    {
        // We search only tickets that belongs to that customer 
        // and are not invoiced
        string command = String.Format("searchTicket({0});", einv.Customer.PersonId);
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        // load aditional fields when a ticket search returns
        ticketId = Int32.Parse(e.Argument);
        tck = CntAriCli.GetTicket(ticketId, ctx);
        LoadTicketData(tck);
    }

    protected void LoadTicketData(Ticket tck)
    {
        taxt = tck.InsuranceService.Service.TaxType;
        LoadTaxTypeCombo(taxt);
        txtDescription.Text = tck.Description;
        txtTaxPercentage.Text = taxt.Percentage.ToString();
        txtAmount.Text = tck.Amount.ToString();
        // comission
        decimal comission = tck.Amount * tck.Professional.Commission * 0.01M;
        txtComissionAmount.Text = comission.ToString();
    }

    protected void rdcbTaxType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        // load tax percentage 
        if (rdcbTaxType.SelectedValue != "")
        {
            taxTypeId = Int32.Parse(rdcbTaxType.SelectedValue);
            taxt = CntAriCli.GetTaxType(taxTypeId, ctx);
            txtTaxPercentage.Text = String.Format("{0:##0.00}", taxt.Percentage);
        }
    }
}
