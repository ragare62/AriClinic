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

public partial class ProfessionalForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Professional prof = null;
    TaxType taxt = null;
    TaxWithholdingType taxwt = null;
    int hcID = 0;
    int patientId = 0;
    int professionalId = 0;
    int taxTypeId = 0;
    int taxWithholdingType = 0;
    Permission per = null;
    string type = "";

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
                            where p.Code == "professional"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ProfessionalId"] != null)
        {
            professionalId = Int32.Parse(Request.QueryString["ProfessionalId"]);
            prof = CntAriCli.GetProfessional(professionalId, ctx);
            LoadData(prof);
        }
        else
        {
            LoadUserCombo(null);
            LoadTypeCombo(null);
            LoadTaxWithholdingTypeCombo(null);
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
        if (prof == null)
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
        // If type is internal some extra information
        // is needed
        if (rdcbType.SelectedValue == "E")
        {
            if (rdcbTaxWithholding.SelectedValue == "")
            {
                lblMessage.Text = Resources.GeneralResource.TaxWitholdingNeeded;
                return false;
            }
            if (txtInvoiceSerial.Text == "")
            {
                lblMessage.Text = Resources.GeneralResource.InvoiceSerialNeeded;
                return false;
            }
        }
        
        return true;
    }

    /// <summary>
    /// As its name suggest if there isn't an object
    /// it'll create it. It exists modify it.
    /// </summary>
    /// <returns></returns>
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (professionalId == 0)
        {
            prof = new Professional();
            UnloadData(prof);
            ctx.Add(prof);
        }
        else
        {
            prof = CntAriCli.GetProfessional(professionalId, ctx);
            UnloadData(prof);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Professional prof)
    {
        txtProfessionalId.Text = prof.PersonId.ToString();
        txtFullName.Text = prof.FullName;
        txtVATIN.Text = prof.VATIN;
        txtComercialName.Text = prof.ComercialName;
        LoadTypeCombo(prof);
        LoadUserCombo(prof.User);
        txtLicense.Text = prof.License;
        LoadTaxWithholdingTypeCombo(prof);
        txtCommision.Text = String.Format("{0:##0.00}", prof.Commission);
        txtInvoiceSerial.Text = prof.InvoiceSerial;
        chkInactive.Checked = prof.Inactive;
    }

    protected void UnloadData(Professional prof)
    {
        prof.FullName = txtFullName.Text;
        prof.VATIN = txtVATIN.Text;
        prof.ComercialName = txtComercialName.Text;
        prof.Type = rdcbType.SelectedValue;
        if (rdcbUser.SelectedValue != "")
        {
            int id = Int32.Parse(rdcbUser.SelectedValue);
            prof.User = CntAriCli.GetUser(id, ctx);
        }
        else
            prof.User = null;

        prof.License = txtLicense.Text;
        
        if (rdcbTaxWithholding.SelectedValue != "")
        {
            int id = Int32.Parse(rdcbTaxWithholding.SelectedValue);
            prof.TaxWithholdingType = CntAriCli.GetTaxWithholdingType(id, ctx);
        }
        
        prof.InvoiceSerial = txtInvoiceSerial.Text;
        
        if (txtCommision.Text != "")
            prof.Commission = Decimal.Parse(txtCommision.Text);
        prof.Inactive = chkInactive.Checked;
    }

    protected void LoadUserCombo(User usr)
    {
        // first clear all items
        rdcbUser.Items.Clear();
        foreach (User u in ctx.Users)
        {
            rdcbUser.Items.Add(new RadComboBoxItem(u.Name, u.UserId.ToString()));
        }
        // additional item (no user selected)
        rdcbUser.Items.Add(new RadComboBoxItem(" ",""));

        if (usr != null)
        {
            rdcbUser.SelectedValue = usr.UserId.ToString();
        }
        else
        {
            rdcbUser.SelectedValue = "";
        }
    }
    protected void LoadTypeCombo(Professional prof)
    {
        rdcbType.Items.Clear();
        rdcbType.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.Internal, "I"));
        rdcbType.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.External, "E"));
        if (prof != null)
            rdcbType.SelectedValue = prof.Type;
    }
    protected void LoadTaxWithholdingTypeCombo(Professional prof)
    {
        rdcbTaxWithholding.Items.Clear();
        foreach (TaxWithholdingType t in ctx.TaxWithholdingTypes)
        {
            rdcbTaxWithholding.Items.Add(new RadComboBoxItem(t.Name, t.TaxWithholdingTypeId.ToString()));
        }
        rdcbTaxWithholding.Items.Add(new RadComboBoxItem(" ", ""));
        if (prof != null && prof.TaxWithholdingType != null)
        {
            rdcbTaxWithholding.SelectedValue = prof.TaxWithholdingType.TaxWithholdingTypeId.ToString();
        }
        else
        {
            rdcbTaxWithholding.SelectedValue = "";
        }
    }
    #endregion Auxiliary functions

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "address":
                UscAddressGrid1.RefreshGrid(true);
                break;
            case "telephone":
                UscTelephoneGrid1.RefreshGrid(true);
                break;
            case "email":
                UscEmailGrid1.RefreshGrid(true);
                break;
        }
    }


}
