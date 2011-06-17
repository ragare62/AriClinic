using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using AriCliModel;
using Telerik.Web.UI;

public partial class PermissionGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    string type = "";

    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        // security control, it must be a user logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadUserGroupCombo();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events
    #region GridList  treatment
    protected void RadTreeList1_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
    {
        RefreshGrid(true);
    }

    protected void RadTreeList1_ItemCommand(object sender, TreeListCommandEventArgs e)
    {
    }

    protected void RadTreeList1_ItemDataBound(object sender, TreeListItemDataBoundEventArgs e)
    {
        if (e.Item is TreeListDataItem)
        {
            ImageButton imgb = (ImageButton)e.Item.FindControl("Edit");
            TreeListDataItem gdi = (TreeListDataItem)e.Item;
            int pId = Int32.Parse(gdi["PermissionId"].Text);
            string command = String.Format("EditPermissionRecord({0});", pId);
            imgb.OnClientClick = command;
        }
    }

    #endregion GridList treatment

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshGrid(false);
    }

    protected void RefreshGrid(bool need)
    {
        if (ddlSelectGroup.SelectedValue == "")
        {
            // no group selected
            RadTreeList1.DataSource = new List<PermissionView>();
            if (!need) RadTreeList1.Rebind();
        }
        else
        {
            // read the appropiate group
            UserGroup ug = GroupSelected();
            CntAriCli.VerifyPermissions(ug, ctx);
            RadTreeList1.DataSource = CntAriCli.GetPermissionsViews(ug);
            if (!need) RadTreeList1.Rebind();
        }
    }

    #region Auxiliary functions
    protected void LoadUserGroupCombo()
    {
        ddlSelectGroup.Items.Clear();
        foreach (UserGroup ug in ctx.UserGroups)
        {
            ddlSelectGroup.Items.Add(new ListItem(ug.Name, ug.UserGroupId.ToString()));
        }
        ddlSelectGroup.Items.Add(new ListItem(" ", ""));
        ddlSelectGroup.SelectedValue = "";
    }

    protected UserGroup GroupSelected()
    {
        UserGroup ug = null;
        if (ddlSelectGroup.SelectedValue != "")
        {
            int id = Int32.Parse(ddlSelectGroup.SelectedValue);
            ug = (from u in ctx.UserGroups
                  where u.UserGroupId == id
                  select u).First<UserGroup>();
        }
        return ug;
    }

    #endregion Auxilary functions

    protected void ddlSelectGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshGrid(false);
    }
}
