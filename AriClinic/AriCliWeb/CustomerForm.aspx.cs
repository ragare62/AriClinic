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

public partial class CustomerForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Customer cus = null;
    int hcID = 0;
    int patientId = 0;
    int customerId = 0;
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
            user = (User)Session["User"];
            Process proc = (from p in ctx.Processes
                            where p.Code == "patient"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["CustomerId"] != null)
        {
            customerId = Int32.Parse(Request.QueryString["CustomerId"]);
            cus = CntAriCli.GetCustomer(customerId, ctx);
            LoadData(cus);
        }
        else
        {
            LoadInsuranceCombo(null);
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
        if (cus == null)
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
        if (customerId == 0)
        {
            cus = new Customer();
            UnloadData(cus);
            ctx.Add(cus);
        }
        else
        {
            cus = CntAriCli.GetCustomer(customerId, ctx);
            UnloadData(cus);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Customer cus)
    {
        txtCustomerId.Text = cus.PersonId.ToString();
        txtComercialName.Text = cus.ComercialName;
        txtVATIN.Text = cus.VATIN;
        LoadInsuranceCombo(cus);
    }

    protected void UnloadData(Customer cus)
    {
        cus.ComercialName = txtComercialName.Text;
        cus.FullName = cus.ComercialName;
        cus.VATIN = txtVATIN.Text;
        if (cus.Policies.Count == 0)
        {
            if (rdcbIsurance.SelectedValue != "")
            {
                Policy pol = new Policy();
                Insurance ins = CntAriCli.GetInsurance(int.Parse(rdcbIsurance.SelectedValue), ctx);
                pol.Insurance = ins;
                pol.Customer = cus;
                pol.Type = "Primary";
                pol.PolicyNumber = txtPolicyNumber.Text;
                //because is a new policy we added it
                ctx.Add(pol);
            }
        }
        else
        {
            Policy pol = (from p in cus.Policies
                          where p.Type == "Primary"
                          select p).FirstOrDefault<Policy>();
            if (pol != null)
            {
                if (rdcbIsurance.SelectedValue != "")
                {
                    Insurance ins = CntAriCli.GetInsurance(int.Parse(rdcbIsurance.SelectedValue), ctx);
                    pol.Insurance = ins;
                    pol.Customer = cus;
                    pol.Type = "Primary";
                    pol.PolicyNumber = txtPolicyNumber.Text;
                }
            }
        }
    }
    protected void LoadInsuranceCombo(Customer cus)
    {
        rdcbIsurance.Items.Clear();
        foreach (Insurance ins in ctx.Insurances)
        {
            rdcbIsurance.Items.Add(new RadComboBoxItem(ins.Name, ins.InsuranceId.ToString()));
        }
        if (cus != null)
        {
            Policy pol = (from p in cus.Policies
                          where p.Type == "Primary"
                          select p).FirstOrDefault<Policy>();
            if (pol != null)
            {
                rdcbIsurance.SelectedValue = pol.Insurance.InsuranceId.ToString();
                // additionaly we show the policy number
                txtPolicyNumber.Text = pol.PolicyNumber;
            }
            else
            {
                rdcbIsurance.Items.Add(new RadComboBoxItem(" ", ""));
                rdcbIsurance.SelectedValue = "";
            }
        }
        else
        {
            rdcbIsurance.Items.Add(new RadComboBoxItem(" ",""));
            rdcbIsurance.SelectedValue = "";
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

    protected void txtVATIN_TextChanged(object sender, EventArgs e)
    {
        bool ret = false;
        // we check if the VATID is correct
        if (txtVATIN.Text == "") return; // nothing to check
        string nif = txtVATIN.Text;
        if (nif.Length == 8) nif = String.Format("{0}X",nif); // we add a dummy character 
        ret = VATControl.ValidateNif(ref nif);
        txtVATIN.Text = nif;
        if (nif.Length != 9 && ret == false)
        {
            string command = String.Format("showDialog('{0}','{1}','warning',false,0,0);"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.PossibleIncorrectVAT);
            RadAjaxManager1.ResponseScripts.Add(command);
        }
    }


}
