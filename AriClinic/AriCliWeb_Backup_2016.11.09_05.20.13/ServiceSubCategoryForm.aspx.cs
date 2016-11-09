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

public partial class ServiceSubCategoryForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    ServiceSubCategory serSub = null;
    int serviceSubCategoryId = 0;
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
                            where p.Code == "servicesubcategory"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ServiceSubCategoryId"] != null)
        {
            serviceSubCategoryId = Int32.Parse(Request.QueryString["ServiceSubCategoryId"]);
            serSub = CntAriCli.GetServiceSubcategory(serviceSubCategoryId, ctx);
            LoadData(serSub);
        }
        else
        {
            LoadServiceCategory(null);
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
        if (serSub == null)
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
        if (rdcbServiceCategory.SelectedValue == "") 
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.ServiceCategoryNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            //lblMessage.Text = Resources.GeneralResource.ServiceCategoryNeeded;
            return false;
        }
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (serSub == null)
        {
            serSub = new ServiceSubCategory();
            UnloadData(serSub);
            ctx.Add(serSub);
        }
        else
        {
            serSub = CntAriCli.GetServiceSubcategory(serviceSubCategoryId, ctx);
            UnloadData(serSub);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(ServiceSubCategory serSub)
    {
        txtServiceSubCategoryId.Text = serSub.ServiceSubCategoryId.ToString();
        txtName.Text = serSub.Name;
        LoadServiceCategory(serSub.ServiceCategory);
    }
    protected void UnloadData(ServiceSubCategory ser)
    {
        ser.Name = txtName.Text;
        ser.ServiceCategory = CntAriCli.GetServiceCategory(Int32.Parse(rdcbServiceCategory.SelectedValue), ctx);
    }
    protected void LoadServiceCategory(ServiceCategory scat)
    {
        // clear previous items 
        rdcbServiceCategory.Items.Clear();
        foreach (ServiceCategory s in ctx.ServiceCategories)
        {
            rdcbServiceCategory.Items.Add(new RadComboBoxItem(s.Name, s.ServiceCategoryId.ToString()));
        }
        if (scat != null)
        {
            rdcbServiceCategory.SelectedValue = scat.ServiceCategoryId.ToString();
        }
        else
        {
            rdcbServiceCategory.Items.Add(new RadComboBoxItem(" ", ""));
            rdcbServiceCategory.SelectedValue = "";
        }
    }
    #endregion Auxiliary functions



}
