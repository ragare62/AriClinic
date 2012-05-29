using System;
using AriCliModel;
using System.Linq;
using Telerik.Web.UI;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class GeneralPaymentForm2 : System.Web.UI.Page
{
    #region Variable declarations
    AriClinicContext ctx;
    User user = null;
    Clinic clinic = null;
    GeneralPayment generalPayment = null;
    PaymentMethod paymentMethod = null;
    ServiceNote serviceNote = null;
    Permission permission = null;
    int generalPaymentId = 0;
    int paymentMethodId = 0;
    int serviceNoteId = 0;
    int permissionId = 0;
    #endregion

    #region Page events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        if (Session["User"] == null) Response.Redirect("Default.aspx");
        else
        {
            user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "payment"
                            select p).FirstOrDefault<Process>();
            permission = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = permission.Modify;
        }
        if (Session["Clinic"] != null)
        {
            clinic = (Clinic)Session["Clinic"];
        }
        if (Request.QueryString["ServiceNoteId"] != null)
        {
            serviceNoteId = int.Parse(Request.QueryString["ServiceNoteId"]);
            serviceNote = CntAriCli.GetServiceNote(serviceNoteId, ctx);
            txtServiceNoteData.Text = String.Format("{0} ({1:dd/MM/yy}) T:{2:0.00} P:{3:0.00}", serviceNote.Customer.ComercialName, serviceNote.ServiceNoteDate, serviceNote.Total, serviceNote.Paid);
            txtAmount.Value = (double)CntAriCli.GetUnpaid(serviceNote, ctx);
            SetFocus(rdcbClinic);
        }
        if (Request.QueryString["GeneralPaymentId"] != null)
        {
            generalPaymentId = Int32.Parse(Request.QueryString["GeneralPaymentId"]);
            generalPayment = CntAriCli.GetGeneralPayment(generalPaymentId, ctx);
            serviceNote = generalPayment.ServiceNote;
            LoadData(generalPayment);
        }
        else
        {
            rddpGeneralPaymentDate.SelectedDate = DateTime.Now;
            LoadPaymentMethodCombo(null);
            LoadClinicCombo(clinic);
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
    #endregion

    #region Page events (clics)

    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        string command = "";
        if (generalPayment== null)
            command = "CloseAndRebind('new');";
        else
            command = "CloseAndRebind('');";
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
    protected bool DataOk(GeneralPayment gpy)
    {
        decimal actValue = 0;
        decimal oldValue = 0;
        actValue = (decimal)txtAmount.Value;
        if (gpy != null) oldValue = gpy.Amount;
        if (actValue > CntAriCli.GetUnpaid(serviceNote, ctx) + oldValue)
        {
            return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk(generalPayment))
            return false;
        if (generalPayment == null)
        {
            UnloadData(generalPayment);
        }
        else
        {
            generalPayment = CntAriCli.GetGeneralPayment(generalPaymentId, ctx);
            UnloadData(generalPayment);
        }
        // update payments in related ticket

        return true;
    }

    protected void LoadData(GeneralPayment pay)
    {
        LoadClinicCombo(pay.Clinic);
        LoadPaymentMethodCombo(pay.PaymentMethod);
        rddpGeneralPaymentDate.SelectedDate = pay.PaymentDate;
        if (pay != null)
        {
            txtGeneralPaymentId.Text = pay.GeneralPaymentId.ToString();
            txtAmount.Value = (double)pay.Amount;
            txtServiceNoteData.Text = String.Format("{0} ({1:dd/MM/yy})", pay.ServiceNote.Customer.ComercialName, pay.ServiceNote.ServiceNoteDate);
        }
        else
        {
            txtServiceNoteData.Text = String.Format("{0} ({1:dd/MM/yy})", serviceNote.Customer.ComercialName, serviceNote.ServiceNoteDate);
            txtAmount.Value = (double)CntAriCli.GetUnpaid(serviceNote, ctx);
        }
        txtComments.Text = pay.Description;
    }

    protected void UnloadData(GeneralPayment pay)
    {
        if (pay != null)
        {
            serviceNote = pay.ServiceNote;
            CntAriCli.GeneralPaymentDelete(pay, ctx);
        }
        Clinic clinic = CntAriCli.GetClinic(int.Parse(rdcbClinic.SelectedValue), ctx);
        PaymentMethod payMethod = CntAriCli.GetPaymentMethod(int.Parse(rdcbPaymentMethod.SelectedValue), ctx);
        DateTime payDate = (DateTime)rddpGeneralPaymentDate.SelectedDate;
        Decimal amount = (decimal)txtAmount.Value;
        string description = txtComments.Text;
        pay = CntAriCli.GeneralPaymentNew(clinic, serviceNote, amount, payMethod, payDate, description, ctx);
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
    protected void LoadClinicCombo(Clinic clinic)
    {
        rdcbClinic.Items.Clear();
        foreach (Clinic c in CntAriCli.GetClinics(ctx))
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
    #endregion
}
