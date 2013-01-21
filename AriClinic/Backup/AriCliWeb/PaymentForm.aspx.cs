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

public partial class PaymentForm : System.Web.UI.Page 
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
    Invoice inv = null;
    Payment pay = null;
    PaymentMethod pm = null;
    int policyId = 0;
    int patientId = 0;
    int insuranceServiceId = 0;
    int ticketId = 0;
    int clinicId = 0;
    int insuranceId = 0;
    int invoiceId = 0;
    int paymentId = 0;
    int paymentMethodId = 0;
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
                            where p.Code == "payment"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        // 
        if (Request.QueryString["PaymentId"] != null)
        {
            paymentId = Int32.Parse(Request.QueryString["PaymentId"]);
            pay = CntAriCli.GetPayment(paymentId, ctx);
            LoadData(pay);
        }
        else
        {
            rddpPaymentDate.SelectedDate = DateTime.Now;
            LoadPaymentMethodCombo(null);
        }
        //
        if (Request.QueryString["TicketId"] != null)
        {
            ticketId = int.Parse(Request.QueryString["TicketId"]);
            tck = CntAriCli.GetTicket(ticketId, ctx);
            txtTicketId.Text = tck.TicketId.ToString();
            txtTicketData.Text = String.Format("{0} ({1}: {2:C})"
                , tck.Policy.Customer.FullName
                , tck.Description
                , tck.Amount);
            decimal diff = tck.Amount - tck.Paid;
            txtAmount.Text = diff.ToString();
            SetFocus(rdcbPaymentMethod);
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
        lblMessage.Text = command;
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
        if (rddpPaymentDate.SelectedDate == null)
        {
            lblMessage.Text = Resources.GeneralResource.DateNeeded;
            return false;
        }
        if (rdcbPaymentMethod.SelectedValue == "")
        {
            lblMessage.Text = Resources.GeneralResource.PaymentMethodNeeded;
            return false;
        }
        if (txtTicketId.Text == "")
        {
            lblMessage.Text = Resources.GeneralResource.TicketNeeded;
            return false;
        }
        else
        {
            ticketId = Int32.Parse(txtTicketId.Text);
            tck = CntAriCli.GetTicket(ticketId, ctx);
            if (tck.ServiceNote != null)
            {
                lblMessage.Text = Resources.GeneralResource.PayInNote;
                return false;
            }
            if (!CntAriCli.PaymentControl(tck, pay, Decimal.Parse(txtAmount.Text)))
            {
                lblMessage.Text = Resources.GeneralResource.TicketAmountExceeded;
                return false;
            }
        }

        return true;
    }

    protected bool CreateChange()
    {
        lblMessage.Text = "OK..";
        if (!DataOk())
            return false;
        if (pay == null)
        {
            lblMessage.Text = "New..."; 
            pay = new Payment();
            UnloadData(pay);
            ctx.Add(pay);
        }
        else
        {
            lblMessage.Text = "Edit...";
            pay = CntAriCli.GetPayment(paymentId, ctx);
            UnloadData(pay);
        }
        ctx.SaveChanges();
        // update payments in related ticket
        CntAriCli.UpdateTicketPayments(pay.Ticket, ctx);
        lblMessage.Text = "Final create...";
        return true;
    }

    protected void LoadData(Payment pay)
    {
        txtPaymentId.Text = pay.PaymentId.ToString();
        rddpPaymentDate.SelectedDate = pay.PaymentDate;
        tck = pay.Ticket;
        if (tck != null)
        {
            txtTicketId.Text = tck.TicketId.ToString();
            txtTicketData.Text = String.Format("{0} ({1}: {2:###,##0.00})"
                , tck.Policy.Customer.FullName
                , tck.Description
                , tck.Amount);
        }
        LoadPaymentMethodCombo(pay.PaymentMethod);
        txtAmount.Text = String.Format("{0:###,##0.00}", pay.Amount);
    }

    protected void UnloadData(Payment pay)
    {
        pay.PaymentDate = (DateTime)rddpPaymentDate.SelectedDate;
        paymentMethodId = Int32.Parse(rdcbPaymentMethod.SelectedValue);
        pay.PaymentMethod = CntAriCli.GetPaymentMethod(paymentMethodId, ctx);
        if (txtTicketId.Text != "")
        {
            ticketId = Int32.Parse(txtTicketId.Text);
            pay.Ticket = CntAriCli.GetTicket(ticketId, ctx);
        }
        pay.User = CntAriCli.GetUser(user.UserId, ctx);
        pay.Amount = Decimal.Parse(txtAmount.Text);
    }


    protected void LoadPaymentMethodCombo(PaymentMethod pm)
    {
        // clear previous items 
        rdcbPaymentMethod.Items.Clear();
        foreach (PaymentMethod pm2 in ctx.PaymentMethods)
        {
            rdcbPaymentMethod.Items.Add(new RadComboBoxItem(pm2.Name, pm2.PaymentMethodId.ToString()));
        }
        if (pm != null)
        {
            rdcbPaymentMethod.SelectedValue = pm.PaymentMethodId.ToString();
        }
        else
        {
            rdcbPaymentMethod.Items.Add(new RadComboBoxItem(" ", ""));
            rdcbPaymentMethod.SelectedValue = "";
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
            txtAmount.Text = String.Format("{0:###,##0.00}", tck.Amount);
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
        string command = "searchTicketAll();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }


    #endregion

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        // load aditional fields when a ticket search returns
        //ticketId = Int32.Parse(e.Argument);
        //tck = CntAriCli.GetTicket(ticketId, ctx);
        //txtAmount.Text = String.Format("{0:###,##0.00}", tck.Amount);
    }


}
