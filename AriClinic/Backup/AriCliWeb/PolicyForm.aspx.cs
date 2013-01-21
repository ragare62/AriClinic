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

public partial class PolicyForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Policy pol = null;
    Customer pat = null;
    Insurance ins = null;
    int policyId = 0;
    int patientId = 0;
    int insuranceId = 0;
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
                            where p.Code == "policy"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        // 
        if (Request.QueryString["CustomerId"] != null)
        {
            patientId = Int32.Parse(Request.QueryString["CustomerId"]);
            pat = CntAriCli.GetCustomer(patientId, ctx);
            txtCustomer.Text = pat.FullName;
        }
        // 
        if (Request.QueryString["PolicyId"] != null)
        {
            policyId = Int32.Parse(Request.QueryString["PolicyId"]);
            pol = CntAriCli.GetPolicy(policyId, ctx);
            LoadData(pol);
        }
        else
        {
            LoadTypeCombo(null);
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
        // check that there's almost one primary address
        string type = rdcbType.SelectedValue;
        if (type != "Primary")
        {
            if (!PrimaryExists())
            {
                lblMessage.Text = Resources.GeneralResource.PrimaryTypeNeeded;
                return false;
            }
        }
        else
        {
            if (PrimaryExists())
            {
                lblMessage.Text = Resources.GeneralResource.AlreadyPrimary;
                return false;
            }
        }
        // check that is an insurance selected
        if (rdcbInsurance.SelectedValue == "")
        {
            lblMessage.Text = "";
            return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (pol == null)
        {
            pol = new Policy();
            UnloadData(pol);
            ctx.Add(pol);
        }
        else
        {
            pol = CntAriCli.GetPolicy(policyId, ctx);
            UnloadData(pol);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Policy pol)
    {
        txtPolicyId.Text = pol.PolicyId.ToString();
        txtCustomer.Text = pol.Customer.FullName;
        rddpBeginDate.SelectedDate = CntAriCli.IsDateNull(pol.BeginDate);
        rddpEndDate.SelectedDate = CntAriCli.IsDateNull(pol.EndDate);
        txtPolicyNumber.Text = pol.PolicyNumber;
        LoadTypeCombo(pol);
        LoadInsuranceCombo(pol);
    }

    protected void UnloadData(Policy pol)
    {
        pol.Customer = pat;
        pol.Type = rdcbType.SelectedValue;
        pol.PolicyNumber = txtPolicyNumber.Text;
        insuranceId = Int32.Parse(rdcbInsurance.SelectedValue);
        pol.Insurance = CntAriCli.GetInsurance(insuranceId, ctx);
        if (rddpBeginDate.SelectedDate != null)
            pol.BeginDate = (DateTime)rddpBeginDate.SelectedDate;
        if (rddpEndDate.SelectedDate != null)
            pol.EndDate = (DateTime)rddpEndDate.SelectedDate;
    }

    protected void LoadTypeCombo(Policy pol)
    {
        rdcbType.Items.Clear(); // clear all previous options
        rdcbType.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.Primary, "Primary"));
        rdcbType.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.Secondary, "Secondary"));

        if (pol != null)
        {
            rdcbType.SelectedValue = pol.Type;
        }
    }

    protected void LoadInsuranceCombo(Policy pol)
    {
        // clear previous items 
        rdcbInsurance.Items.Clear();
        foreach (Insurance s in ctx.Insurances)
        {
            rdcbInsurance.Items.Add(new RadComboBoxItem(s.Name, s.InsuranceId.ToString()));
        }
        if (pol != null)
        {
            rdcbInsurance.SelectedValue = pol.Insurance.InsuranceId.ToString();
        }
        else
        {
            rdcbInsurance.Items.Add(new RadComboBoxItem(" ", ""));
            rdcbInsurance.SelectedValue = "";
        }
    }

    private bool PrimaryExists()
    {
        Policy pol = null;
        if (pat != null)
        {
            pol = (from p in ctx.Policies
                   where p.Type == "Primary"
                         && p.Customer.PersonId == pat.PersonId
                   select p).FirstOrDefault<Policy>();
        }
        if (pol == null)
            return false;
        else
        {
            if (pol.PolicyId == policyId) return false;
        }
        return true;
    }
    #endregion Auxiliary functions
}
