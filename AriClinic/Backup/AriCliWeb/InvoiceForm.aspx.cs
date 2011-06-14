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

public partial class InvoiceForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Clinic cl = null;
    HealthcareCompany hc = null;
    Customer cus = null;
    Invoice inv = null;
    int healthCareCompanyId = 0;
    int customerId = 0;
    int invoiceId = 0;
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
                            where p.Code == "invoice"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        hc = CntAriCli.GetHealthCompany(ctx);
        // 
        if (Request.QueryString["InvoiceId"] != null)
        {
            invoiceId = Int32.Parse(Request.QueryString["InvoiceId"]);
            inv = CntAriCli.GetInvoice(invoiceId, ctx);
            LoadData(inv);
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
        if (inv == null)
            command = "CloseAndRebind('new')";
        else
            command = "CloseAndRebind('')";
        if (!CreateChange())
            return;
        if (caller == "sn") command = "CancelEdit();";
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
        // check date
        if (rddpInvoiceDate.SelectedDate == null)
        {
            lblMessage.Text = Resources.GeneralResource.DateNeeded;
            return false;
        }
        // check if there're invoices with older date
        if (inv == null)
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
        if (inv == null)
        {
            inv = new Invoice();
            UnloadData(inv);
            ctx.Add(inv);
        }
        else
        {
            inv = CntAriCli.GetInvoice(invoiceId, ctx);
            UnloadData(inv);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Invoice inv)
    {
        txtInvoiceId.Text = inv.InvoiceId.ToString();
        txtInvoiceSerial.Text = inv.Serial;
        txtYear.Text = inv.Year.ToString();
        txtInvoiceNumber.Text = String.Format("{0:000000}", inv.InvoiceNumber);
        rddpInvoiceDate.SelectedDate = inv.InvoiceDate;
        txtCustomerId.Text = inv.Customer.PersonId.ToString();
        txtCustomerName.Text = inv.Customer.ComercialName;
        txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", inv.Total);
    }

    protected void UnloadData(Invoice inv)
    {
        inv.Serial = txtInvoiceSerial.Text;
        inv.Year = Int32.Parse(txtYear.Text);
        if (inv.InvoiceNumber == 0)
            inv.InvoiceNumber = CntAriCli.GetNextInvoiceNumber(inv.Serial, inv.Year, ctx);
        inv.InvoiceDate = (DateTime)rddpInvoiceDate.SelectedDate;
        customerId = Int32.Parse(txtCustomerId.Text);
        inv.Customer = CntAriCli.GetCustomer(customerId, ctx);
        inv.Total = CntAriCli.GetInvoiceTotal(inv);
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
        UscInvoiceLineGrid1.RefreshGrid(true);
        txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", CntAriCli.GetInvoiceTotal(inv));
    }
}
