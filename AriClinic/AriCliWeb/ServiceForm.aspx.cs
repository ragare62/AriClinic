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

public partial class ServiceForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Service ser = null;
    int serviceId = 0;
    Permission per = null;
    bool newRegister = false;
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
        if (Request.QueryString["ServiceId"] != null)
        {
            serviceId = Int32.Parse(Request.QueryString["ServiceId"]);
            ser = CntAriCli.GetService(serviceId, ctx);
            LoadData(ser);
        }
        else
        {
            LoadTaxType(null);
            LoadServiceCategory(null);
            LoadServiceSubCategory(null);
            newRegister = true;
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
        if (ser == null)
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
        if (rdcbTaxType.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                ,Resources.GeneralResource.Warning
                ,Resources.GeneralResource.TaxTypeNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            //lblMessage.Text = Resources.GeneralResource.TaxTypeNeeded;
            return false;
        }
        if (rdcbServiceCategory.SelectedValue == "") 
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.ServiceCategoryNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            //lblMessage.Text = Resources.GeneralResource.ServiceCategoryNeeded;
            return false;
        }
        if (rdcServiceSubCategory.SelectedValue == "")
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
        if (ser == null)
        {
            ser = new Service();
            UnloadData(ser);
            ctx.Add(ser);
        }
        else
        {
            ser = CntAriCli.GetService(serviceId, ctx);
            UnloadData(ser);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Service ser)
    {
        txtServiceId.Text = ser.ServiceId.ToString();
        txtName.Text = ser.Name;
        LoadTaxType(ser.TaxType);
        LoadServiceCategory(ser.ServiceCategory);
        LoadServiceSubCategory(ser.ServiceSubCategory);
    }
    protected void UnloadData(Service ser)
    {
        ser.Name = txtName.Text;
        ser.TaxType = CntAriCli.GetTaxType(Int32.Parse(rdcbTaxType.SelectedValue), ctx);
        ser.ServiceCategory = CntAriCli.GetServiceCategory(Int32.Parse(rdcbServiceCategory.SelectedValue), ctx);
        ser.ServiceSubCategory = CntAriCli.GetServiceSubcategory(Int32.Parse(rdcServiceSubCategory.SelectedValue), ctx);
    }
    protected void LoadTaxType(TaxType taxt)
    {
        // clear previous items 
        rdcbTaxType.Items.Clear();
        foreach (TaxType t in ctx.TaxTypes)
        {
            rdcbTaxType.Items.Add(new RadComboBoxItem(t.Name,t.TaxTypeId.ToString()));
        }
        if (taxt != null)
        {
            rdcbTaxType.SelectedValue = taxt.TaxTypeId.ToString();
        }
        else
        {
            rdcbTaxType.Items.Add(new RadComboBoxItem(" ",""));
            rdcbTaxType.SelectedValue = "";
        }
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
    protected void LoadServiceSubCategory(ServiceSubCategory sscat)
    {
        // clear previous items 
        rdcServiceSubCategory.Items.Clear();
        foreach (ServiceSubCategory s in ctx.ServiceSubCategories)
        {
            rdcServiceSubCategory.Items.Add(new RadComboBoxItem(s.Name, s.ServiceSubCategoryId.ToString()));
        }
        if (sscat != null)
        {
            rdcServiceSubCategory.SelectedValue = sscat.ServiceSubCategoryId.ToString();
        }
        else
        {
            rdcServiceSubCategory.Items.Add(new RadComboBoxItem(" ", ""));
            rdcServiceSubCategory.SelectedValue = "";
        }
    }
    protected void LoadServiceSubCategory2(ServiceCategory scat)
    {
        // clear previous items 
        rdcServiceSubCategory.Items.Clear();
        foreach (ServiceSubCategory s in scat.ServiceSubCategories)
        {
            rdcServiceSubCategory.Items.Add(new RadComboBoxItem(s.Name, s.ServiceSubCategoryId.ToString()));
        }
    }

    #endregion Auxiliary functions

    protected void rdcbServiceCategory_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        ServiceCategory sc = CntAriCli.GetServiceCategory(int.Parse(rdcbServiceCategory.SelectedValue), ctx);
        if (sc != null)
        {
            LoadServiceSubCategory2(sc);
        }
    }



}
