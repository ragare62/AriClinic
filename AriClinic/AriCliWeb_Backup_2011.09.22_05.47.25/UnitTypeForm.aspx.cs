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

public partial class UnitTypeForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    AriCliModel.UnitType unitType = null;
    int unitTypeId = 0;
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
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "UnitType"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["UnitTypeId"] != null)
        {
            unitTypeId = Int32.Parse(Request.QueryString["UnitTypeId"]);
            unitType = CntAriCli.GetUnitType(unitTypeId, ctx);
            LoadData(unitType);
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
        if (unitType == null)
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
        string command = "";
        // check combo values
        if (txtName.Text == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                ,Resources.GeneralResource.Warning
                ,Resources.GeneralResource.NameNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (unitType == null)
        {
            unitType = new AriCliModel.UnitType();
            UnloadData(unitType);
            ctx.Add(unitType);
        }
        else
        {
            unitType = CntAriCli.GetUnitType(unitTypeId, ctx);
            UnloadData(unitType);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(AriCliModel.UnitType unitType)
    {
        txtUnitTypeId.Text = unitType.UnitTypeId.ToString();
        txtName.Text = unitType.Name;
    }
    protected void UnloadData(AriCliModel.UnitType unitType)
    {
        unitType.Name = txtName.Text;
    }
    #endregion Auxiliary functions



}
