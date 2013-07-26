using System;
using AriCliModel;
using AriCliWeb;
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

public partial class AmendmentInvoiceForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Clinic cl = null;
    HealthcareCompany hc = null;
    Customer cus = null;
    AmendmentInvoice aInv = null;
    int customerId = 0;
    int amendmentInvoiceId = 0;
    string caller = "";
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
                            where p.Code == "amendmentinvoice"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        hc = CntAriCli.GetHealthCompany(ctx);
        // 
        if (Request.QueryString["AmendmentInvoiceId"] != null)
        {
            amendmentInvoiceId = Int32.Parse(Request.QueryString["AmendmentInvoiceId"]);
            aInv = CntAriCli.GetAmendementInvoice(amendmentInvoiceId, ctx);
            LoadData(aInv);
        }
        else
        {
            // deafault values
            rddpInvoiceDate.SelectedDate = DateTime.Now;
            txtYear.Text = DateTime.Now.Year.ToString();
            txtInvoiceSerial.Text = hc.InvoiceSerial;
        }
        //
        if (Request.QueryString["Caller"] != null)
            caller = Request.QueryString["Caller"];

        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        // always read Healt care company
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
        if (aInv == null)
            command = "CloseAndRebind('new')";
        else
            command = "CloseAndRebind('')";
        if (!CreateChange())
            return;
        if (caller == "sn") command = "CancelEdit();";
        if (command == "CloseAndRebind('new')")
        {
            // recharges invoice.
            Response.Redirect(String.Format("AmendmentInvoiceForm.aspx?InvoiceId={0}", aInv.AmendmentInvoiceId));
        }
        else
        {
            RadAjaxManager1.ResponseScripts.Add(command);
        }
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        string js = String.Format("printAmendmentInvoice({0});", aInv.AmendmentInvoiceId);
        RadAjaxManager1.ResponseScripts.Add(js);
        RadAjaxManager1.ResponseScripts.Add("CloseAndRebind('');");
    }
    #endregion Page events (clics)

    #region Auxiliary functions
    protected bool DataOk()
    {
        // check date
        if (rddpInvoiceDate.SelectedDate == null)
        {
            lblMessage.Text = Resources.GeneralResource.DateNeeded;
            return false;
        }
        // check if there're invoices with older date
        if (aInv == null)
        {
            if (!CntAriCli.CorrectInvoiceDate((DateTime)rddpInvoiceDate.SelectedDate, ctx))
            {
                lblMessage.Text = Resources.GeneralResource.IncorrectInvoiceDate;
                return false;
            }
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (aInv == null)
        {
            aInv = new AmendmentInvoice();
            UnloadData(aInv);
            ctx.Add(aInv);
        }
        else
        {
            aInv = CntAriCli.GetAmendementInvoice(amendmentInvoiceId, ctx);
            UnloadData(aInv);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(AmendmentInvoice aInv)
    {
        lblOriginalInvoice.Text = String.Format("Factura original:{0}-{1}-{2}  Fecha:{3:dd/MM/yyyy}",
            aInv.OriginalInvoice.Serial,
            aInv.OriginalInvoice.Year,
            aInv.OriginalInvoice.InvoiceNumber,
            aInv.OriginalInvoice.InvoiceDate);
        txtInvoiceId.Text = aInv.AmendmentInvoiceId.ToString();
        txtInvoiceSerial.Text = aInv.Serial;
        txtYear.Text = aInv.Year.ToString();
        txtInvoiceNumber.Text = String.Format("{0:000000}", aInv.InvoiceNumber);
        rddpInvoiceDate.SelectedDate = aInv.InvoiceDate;
        txtCustomerId.Text = aInv.Customer.PersonId.ToString();
        txtCustomerName.Text = aInv.Customer.ComercialName;
        txtReason.Text = aInv.Reason;
        txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", aInv.Total);
    }

    protected void UnloadData(AmendmentInvoice aInv)
    {
        aInv.Serial = txtInvoiceSerial.Text;
        aInv.Year = Int32.Parse(txtYear.Text);
        if (aInv.InvoiceNumber == 0)
            aInv.InvoiceNumber = CntAriCli.GetNextInvoiceNumber(aInv.Serial, aInv.Year, ctx);
        aInv.InvoiceDate = (DateTime)rddpInvoiceDate.SelectedDate;
        customerId = Int32.Parse(txtCustomerId.Text);
        aInv.Customer = CntAriCli.GetCustomer(customerId, ctx);
        aInv.Reason = txtReason.Text;
        aInv.Total = CntAriCli.GetAmendmentInvoiceTotal(aInv);
        txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", aInv.Total);
        aInv.InvoiceKey = String.Format("{0}-{1:000000}-{2}", aInv.Year, aInv.InvoiceNumber, aInv.Serial);
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
            txtCustomerName.Text = cus.ComercialName;
        }
        else
        {
            txtCustomerId.Text = "";
            txtCustomerName.Text = Resources.GeneralResource.CustomerDoesNotExists;
        }
    }

    protected void btnCustomerId_Click(object sender, ImageClickEventArgs e)
    {
        // We search only tickets that belongs to that customer 
        // and are not invoiced
        string command = "searchCustomer();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        UscAmendmentInvoiceLineGrid1.RefreshGrid(true);
        txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", CntAriCli.GetAmendmentInvoiceTotal(aInv));
    }


}
