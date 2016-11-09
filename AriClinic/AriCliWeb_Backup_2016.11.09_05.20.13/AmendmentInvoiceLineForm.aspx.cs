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

public partial class AmendmentInvoiceLineForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Clinic cl = null;
    Policy pol = null;
    Ticket tck = null;
    AmendmentInvoice aInv = null;
    AmendmentInvoiceLine aInvl = null;
    TaxType taxt = null;
    int ticketId = 0;
    int aInvoiceId = 0;
    int aInvoiceLineId = 0;
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
        if (Request.QueryString["AmendmentInvoiceId"] != null)
        {
            aInvoiceId = Int32.Parse(Request.QueryString["AmendmentInvoiceId"]);
            aInv = CntAriCli.GetAmendementInvoice(aInvoiceId, ctx);
            LoadInvoiceData();
        }
        else
        {
            //TODO: What to do if there is not an invoice
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        // 
        if (Request.QueryString["AmendmentInvoiceLineId"] != null)
        {
            aInvoiceLineId = Int32.Parse(Request.QueryString["AmendmentInvoiceLineId"]);
            aInvl = CntAriCli.GetAmendementInvoiceLine(aInvoiceLineId, ctx);
            LoadData(aInvl);
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
            lblMessage.Text = Resources.GeneralResource.TaxTypeNeeded;
            return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (aInvl == null)
        {
            aInvl = new AmendmentInvoiceLine();
            UnloadData(aInvl);
            ctx.Add(aInvl);
        }
        else
        {
            aInvl = CntAriCli.GetAmendementInvoiceLine(aInvoiceLineId, ctx);
            UnloadData(aInvl);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(AmendmentInvoiceLine aInvl)
    {
        txtInvoiceLineId.Text = aInvl.AmendmentInvoiceLineId.ToString();
        aInv = aInvl.AmendmentInvoice;
        LoadInvoiceData();
        LoadTaxTypeCombo(aInvl.TaxType);
        txtDescription.Text = aInvl.Description;
        txtTaxPercentage.Text = String.Format("{0:##0.00}", aInvl.TaxPercentage);
        txtAmount.Text = String.Format("{0:###,##0.00}", aInvl.Amount);
    }

    protected void UnloadData(AmendmentInvoiceLine aInvl)
    {
        aInvl.AmendmentInvoice = aInv;
        taxTypeId = Int32.Parse(rdcbTaxType.SelectedValue);
        aInvl.TaxType = CntAriCli.GetTaxType(taxTypeId, ctx);
        aInvl.User = CntAriCli.GetUser(user.UserId, ctx);
        aInvl.Description = txtDescription.Text;
        aInvl.TaxPercentage = Decimal.Parse(txtTaxPercentage.Text);
        aInvl.Amount = Decimal.Parse(txtAmount.Text);
    }

    protected void LoadInvoiceData()
    {
        txtInvoiceSerial.Text = aInv.Serial;
        txtYear.Text = aInv.Year.ToString();
        txtInvoiceNumber.Text = String.Format("{0:000000}", aInv.InvoiceNumber);
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
            rdcbTaxType.Items.Add(new RadComboBoxItem(" ",""));
            rdcbTaxType.SelectedValue = "";
        }
    }
    #endregion Auxiliary functions


    #region Searching outside


    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }
    protected void LoadTicketData(Ticket tck)
    {
        taxt = tck.InsuranceService.Service.TaxType;
        LoadTaxTypeCombo(taxt);
        txtDescription.Text = tck.Description;
        txtTaxPercentage.Text = taxt.Percentage.ToString();
        txtAmount.Text = tck.Amount.ToString();
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
