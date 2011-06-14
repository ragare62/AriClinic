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

public partial class ServiceCategoryForm : System.Web.UI.Page 
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
            user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "scat"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ServiceCategoryId"] != null)
        {
            serviceCategoryId = Int32.Parse(Request.QueryString["ServiceCategoryId"]);
            scat = CntAriCli.GetServiceCategory(serviceCategoryId, ctx);
            LoadData(scat);
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
        string command = "CloseAndRebind('')";
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
        if (scat == null)
        {
            scat = new ServiceCategory();
            UnloadData(scat);
            ctx.Add(scat);
        }
        else
        {
            scat = CntAriCli.GetServiceCategory(serviceCategoryId, ctx);
            UnloadData(scat);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(ServiceCategory scat)
    {
        txtServiceCategoryId.Text = scat.ServiceCategoryId.ToString();
        txtName.Text = scat.Name;
    }
    protected void UnloadData(ServiceCategory scat)
    {
        scat.Name = txtName.Text;
    }
    #endregion Auxiliary functions



}
