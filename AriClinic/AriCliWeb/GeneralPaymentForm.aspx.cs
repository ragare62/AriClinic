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

public partial class GeneralPaymentForm : System.Web.UI.Page 
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
    GeneralPayment gpay = null;
    PaymentMethod pm = null;
    ServiceNote snote = null;
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
                            where p.Code == "payment"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
        // 

        //
        if (Request.QueryString["ServiceNoteId"] != null)
        {
            serviceNoteId = int.Parse(Request.QueryString["ServiceNoteId"]);
            snote = CntAriCli.GetServiceNote(serviceNoteId, ctx);
            // calcute total amount and total payments
            //txtServiceNoteData.Text = String.Format("ID:{0} Fecha:{1:dd/MM/yy} Total:{2} Pagado:{3}", 
            //    snote.ServiceNoteId, 
            //    snote.ServiceNoteDate,
            //    CntAriCli.GetServiceNoteAmount(snote), 
            //    CntAriCli.GetServiceNoteAmountPay(snote));
            txtServiceNoteData.Text = String.Format("{0} ({1:dd/MM/yy}) T:{2:0.00} P:{3:0.00}", snote.Customer.ComercialName, snote.ServiceNoteDate, snote.Total, snote.Paid);
            txtAmount.Text = string.Format("{0:#.#}", CntAriCli.GetUnpaid(snote, ctx));
            SetFocus(rdcbClinic);
        }

        if (Request.QueryString["GeneralPaymentId"] != null)
        {
            paymentId = Int32.Parse(Request.QueryString["GeneralPaymentId"]);
            gpay = CntAriCli.GetGeneralPayment(paymentId, ctx);
            LoadData(gpay);
        }
        else
        {
            rddpGeneralPaymentDate.SelectedDate = DateTime.Now;
            LoadPaymentMethodCombo(null);
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
        lblMessage.Text = "[1]";
        RadAjaxManager1.ResponseScripts.Add(command);
        lblMessage.Text = "[2]";
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
        if (rddpGeneralPaymentDate.SelectedDate == null)
        {
            lblMessage.Text = Resources.GeneralResource.DateNeeded;
            return false;
        }
        if (rdcbPaymentMethod.SelectedValue == "")
        {
            lblMessage.Text = Resources.GeneralResource.PaymentMethodNeeded;
            return false;
        }
        if (rdcbClinic.SelectedValue == "")
        {
            lblMessage.Text = Resources.GeneralResource.ClinicNeeded;
            return false;
        }
        // se necesita controlar los pagos
        if (txtAmount.Text == "")
        {
            lblMessage.Text = Resources.GeneralResource.NumericNeeded;
            return false;
        }
        decimal amount = decimal.Parse(txtAmount.Text);
        if (amount > CntAriCli.GetUnpaid(snote, ctx))
        {
            lblMessage.Text = Resources.GeneralResource.TicketAmountExceeded;
            return false;
        }


        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (gpay == null)
        {
            UnloadData(gpay);
        }
        else
        {
            gpay = CntAriCli.GetGeneralPayment(paymentId, ctx);
            UnloadData(gpay);
        }
        // update payments in related ticket

        return true;
    }

    protected void LoadData(GeneralPayment pay)
    {
        LoadClinicCombo(pay);
        LoadPaymentMethodCombo(pay);
        if (pay != null)
        {
            txtGeneralPaymentId.Text = pay.GeneralPaymentId.ToString();
            txtAmount.Text = String.Format("{0:#.#}", pay.Amount);
            txtServiceNoteData.Text = String.Format("{0} ({1:dd/MM/yy})", pay.ServiceNote.Customer.ComercialName, pay.ServiceNote.ServiceNoteDate);
        }
        else
        {
            txtServiceNoteData.Text = String.Format("{0} ({1:dd/MM/yy})", snote.Customer.ComercialName, snote.ServiceNoteDate);
            txtAmount.Text = string.Format("{0:#.#}", CntAriCli.GetUnpaid(snote, ctx));
        }
    }

    protected void UnloadData(GeneralPayment pay)
    {
        if (pay != null)
        {
            snote = pay.ServiceNote;
            CntAriCli.GeneralPaymentDelete(pay, ctx);
        }
        Clinic clinic = CntAriCli.GetClinic(int.Parse(rdcbClinic.SelectedValue), ctx);
        PaymentMethod payMethod = CntAriCli.GetPaymentMethod(int.Parse(rdcbPaymentMethod.SelectedValue), ctx);
        DateTime payDate = (DateTime)rddpGeneralPaymentDate.SelectedDate;
        Decimal amount = decimal.Parse(txtAmount.Text);
        string description = txtComments.Text;
        pay = CntAriCli.GeneralPaymentNew(clinic, snote, amount, payMethod, payDate, description, ctx);
    }


    protected void LoadPaymentMethodCombo(GeneralPayment gp)
    {
        PaymentMethod pm = null;
        if (gp != null)
            pm = gp.PaymentMethod;
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
    protected void LoadClinicCombo(GeneralPayment gp)
    {
        Clinic clinic = null;
        if (gp != null) clinic = gp.Clinic;
        rdcbClinic.Items.Clear();
        foreach(Clinic c in CntAriCli.GetClinics(ctx))
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(c.Name, c.ClinicId.ToString()));
        }
        if (clinic != null)
        {
            rdcbClinic.SelectedValue = clinic.ClinicId.ToString();
        }
        else
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(" ", ""));
            rdcbClinic.SelectedValue = "";
        }
    }
    #endregion Auxiliary functions


    #region Searching outside

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
