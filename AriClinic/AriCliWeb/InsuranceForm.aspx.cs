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

public partial class InsuranceForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Insurance ins = null;
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
                            where p.Code == "ins"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["InsuranceId"] != null)
        {
            insuranceId = Int32.Parse(Request.QueryString["InsuranceId"]);
            ins = CntAriCli.GetInsurance(insuranceId, ctx);
            LoadData(ins);
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
        if (ins == null)
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

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (ins == null)
        {
            ins = new Insurance();
            UnloadData(ins);
            ctx.Add(ins);
        }
        else
        {
            ins = CntAriCli.GetInsurance(insuranceId, ctx);
            UnloadData(ins);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Insurance ins)
    {
        txtInsuranceId.Text = ins.InsuranceId.ToString();
        txtName.Text = ins.Name;
        chkInternal.Checked = ins.Internal;
    }

    protected void UnloadData(Insurance ins)
    {
        ins.Name = txtName.Text;
        ins.Internal = chkInternal.Checked;
    }

    #endregion Auxiliary functions

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        UscInsuranceServiceGrid1.RefreshGrid(true);
    }
}
