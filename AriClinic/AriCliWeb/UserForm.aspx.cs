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

public partial class UserForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    int userId = 0;
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
                            where p.Code == "user"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
            // special for this form
            ddlGroup.Enabled = per.Create;
        }
        // 
        if (Request.QueryString["UserId"] != null)
        {
            userId = Int32.Parse(Request.QueryString["UserId"]);
            User usr = (from u in ctx.Users
                        where u.UserId == userId
                        select u).FirstOrDefault<User>();
            LoadData(usr);
        }
        else
        {
            LoadGroupCombo(null);
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
        // new user needs a password
        if (userId == 0 && txtPassword1.Text == "")
        {
            lblMessage.Text = Resources.GeneralResource.UserNeedsPassword;
            return false;
        }
        // if ther's a password1 must mach with password2
        if (txtPassword1.Text != "")
        {
            if (txtPassword1.Text != txtPassword2.Text)
            {
                lblMessage.Text = Resources.GeneralResource.PassordsDoesntMach;
                return false;
            }
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (userId == 0)
        {
            User usr = new User();
            UnloadData(usr);
            ctx.Add(usr);
        }
        else
        {
            User usr = (from u in ctx.Users
                        where u.UserId == userId
                        select u).FirstOrDefault<User>();
            UnloadData(usr);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(User u)
    {
        txtUserId.Text = u.UserId.ToString();
        txtName.Text = u.Name;
        txtLogin.Text = u.Login;
        LoadGroupCombo(u);
    }

    protected void UnloadData(User u)
    {
        u.Name = txtName.Text;
        u.Login = txtLogin.Text;
        if (txtPassword2.Text != "")
            u = CntAriCli.EncryptPassword(u, txtPassword1.Text);
        int id = Int32.Parse(ddlGroup.SelectedValue);
        u.UserGroup = (from ug in ctx.UserGroups
                       where ug.UserGroupId == id
                       select ug).FirstOrDefault<UserGroup>();
    }
    protected void LoadGroupCombo(User u)
    {
        ddlGroup.Items.Clear(); // clear all previous options
        foreach (UserGroup ug in ctx.UserGroups)
        {
            ddlGroup.Items.Add(new ListItem(ug.Name,ug.UserGroupId.ToString()));
        }
        if (u != null)
        {
            ddlGroup.SelectedValue = u.UserGroup.UserGroupId.ToString();
        }
    }
    #endregion Auxiliary functions
}
