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

public partial class InsuranceServiceForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    InsuranceService inser = null;
    Insurance ins = null;
    Service ser = null;
    int serviceId = 0;
    int insuranceId = 0;
    int insuranceServiceId = 0;

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
                            where p.Code == "ser"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        //
        if (Request.QueryString["InsuranceId"] != null)
        {
            insuranceId = Int32.Parse(Request.QueryString["InsuranceId"]);
            ins = CntAriCli.GetInsurance(insuranceId, ctx);
            txtInsurance.Text = ins.Name;
        }
        // 
        if (Request.QueryString["InsuranceServiceId"] != null)
        {
            insuranceServiceId = Int32.Parse(Request.QueryString["InsuranceServiceId"]);
            inser = CntAriCli.GetInsuranceService(insuranceServiceId, ctx);
            LoadData(inser);
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
        if (inser == null)
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
        if (txtServiceName.Text == "" || txtServiceName.Text == Resources.GeneralResource.ServiceDoesNotExists)
        {
            lblMessage.Text = Resources.GeneralResource.ServiceNeeded;
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (inser == null)
        {
            inser = new InsuranceService();
            UnloadData(inser);
            ctx.Add(inser);
        }
        else
        {
            inser = CntAriCli.GetInsuranceService(insuranceServiceId, ctx);
            ins = inser.Insurance;
            UnloadData(inser);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(InsuranceService inser)
    {
        txtInsuranceServiceId.Text = inser.InsuranceServiceId.ToString();
        txtInsurance.Text = inser.Insurance.Name;
        txtServiceId.Text = inser.Service.ServiceId.ToString();
        txtServiceName.Text = inser.Service.Name;
        txtPrice.Text = String.Format("{0:C}",inser.Price);
    }
    protected void UnloadData(InsuranceService inser)
    {
        serviceId = Int32.Parse(txtServiceId.Text);
        inser.Insurance = ins;
        inser.Service = CntAriCli.GetService(serviceId, ctx);
        inser.Price = Decimal.Parse(txtPrice.Text);
    }

    #endregion Auxiliary functions

    protected void txtServiceId_TextChanged(object sender, EventArgs e)
    {
        // looks up for a service with this ID
        if (txtServiceId.Text == "") return;
        serviceId = Int32.Parse(txtServiceId.Text);
        ser = CntAriCli.GetService(serviceId, ctx);
        if (ser != null)
        {
            txtServiceId.Text = ser.ServiceId.ToString();
            txtServiceName.Text = ser.Name;
        }
        else
        {
            txtServiceName.Text = Resources.GeneralResource.ServiceDoesNotExists;
        }
    }
    

}
