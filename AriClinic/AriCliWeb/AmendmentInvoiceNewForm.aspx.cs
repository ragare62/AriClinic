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

public partial class AmendmentInvoiceNewForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    ServiceCategory scat = null;
    int serviceCategoryId = 0;
    Permission per = null;
    AmendmentInvoice aInv = null;
    Invoice inv = null;
    string serial;
    int year;
    int invoiceNumber;
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
        // invoice date today
        rddpInvoiceDate.SelectedDate = DateTime.Now;
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
        // loading data from form
        serial = txtInvoiceSerial.Text;
        year = int.Parse(txtYear.Text);
        invoiceNumber = int.Parse(txtInvoiceNumber.Text);
        // check if there's an invoice with these data
        inv = CntAriCli.GetInvoice(serial, year, invoiceNumber, ctx);
        if (inv == null)
        {
            lblMessage.Text = "NO existe una factura con estos datos";
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        //
        DateTime myDate = (DateTime)rddpInvoiceDate.SelectedDate;
        string reason = txtReason.Text;
        // create amendment invoice
        aInv = CntAriCli.CreateAmendmentInvoice(inv, myDate, reason, ctx);
        if (aInv == null)
        {
            lblMessage.Text = "No se ha podido crear la factura rectificativa, seguramente ya se ha generado otra contra esta factura";
            return false;
        }
        return true;
    }
    #endregion Auxiliary functions



}
