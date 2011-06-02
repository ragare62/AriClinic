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

public partial class RptTicketsForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    ServiceCategory scat = null;
    int serviceCategoryId = 0;
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
            user = (User)Session["User"];
            Process proc = (from p in ctx.Processes
                            where p.Code == "rtickets"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        LoadInsuranceCombo();
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
        if (!DataOk()) return;
        string command;
        int voucher = 0;
        if (chkVoucher.Checked) voucher = 1;
        switch (rdcbType.SelectedValue)
        {
            case "A":
                command = String.Format("reportTickets('{0}','{1}','{2}',{3})"
                                        , rddpFromDate.SelectedDate
                                        , rddpToDate.SelectedDate
                                        , rdcbInsurance.SelectedValue
                                        , voucher);
                RadAjaxManager1.ResponseScripts.Add(command);
                break;
            case "NP":
                command = String.Format("reportTicketsNoPaid('{0}','{1}','{2}',{3})"
                                        , rddpFromDate.SelectedDate
                                        , rddpToDate.SelectedDate
                                        , rdcbInsurance.SelectedValue
                                        , voucher);
                RadAjaxManager1.ResponseScripts.Add(command);
                break;
            case "P":
                command = String.Format("reportTicketsPaid('{0}','{1}','{2}',{3})"
                                        , rddpFromDate.SelectedDate
                                        , rddpToDate.SelectedDate
                                        , rdcbInsurance.SelectedValue
                                        , voucher);
                RadAjaxManager1.ResponseScripts.Add(command);
                break;
        }
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
        if (rddpFromDate.SelectedDate == null || rddpToDate.SelectedDate == null)
        {
            //lblMessage.Text = Resources.GeneralResource.DateNeeded;
            return false;
        }
        if (rddpFromDate.SelectedDate > rddpToDate.SelectedDate)
        {
            //lblMessage.Text = Resources.GeneralResource.FromGreatherThanTo;
            return false;
        }
        return true;
    }

    protected void LoadInsuranceCombo()
    {
        rdcbInsurance.Items.Clear();
        foreach (Insurance ins in ctx.Insurances)
        {
            rdcbInsurance.Items.Add(new RadComboBoxItem(ins.Name, ins.InsuranceId.ToString()));
        }
        rdcbInsurance.Items.Add(new RadComboBoxItem(Resources.GeneralResource.All, "0"));
        rdcbInsurance.SelectedValue = "0";
    }
    #endregion Auxiliary functions
}
