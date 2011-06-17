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

public partial class HealthcareCompanyForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    int hcID = 0;
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
                            where p.Code == "usergroup"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["HcId"] != null)
        {
            hcID = Int32.Parse(Request.QueryString["HcId"]);
            HealthcareCompany hc = CntAriCli.GetHealthCompany(ctx);
            LoadData(hc);
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
        if (!CreateChange())
            return;
        string command = "CancelEdit('')"; // there is not a grid behind
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
        if (hcID == 0)
        {
            HealthcareCompany hc = new HealthcareCompany();
            UnloadData(hc);
            ctx.Add(hc);
        }
        else
        {
            HealthcareCompany hc = CntAriCli.GetHealthCompany(ctx);
            UnloadData(hc);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(HealthcareCompany hc)
    {
        txtHcId.Text = hc.HcId.ToString();
        txtName.Text = hc.Name;
        txtVATIN.Text = hc.VATIN;
    }
    protected void UnloadData(HealthcareCompany hc)
    {
        hc.Name = txtName.Text;
        hc.VATIN = txtVATIN.Text;
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
