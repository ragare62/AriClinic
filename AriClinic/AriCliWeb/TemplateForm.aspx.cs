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

public partial class TemplateForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Template template= null;
    int templateId = 0;
    Permission per = null;
    AriCliModel.Parameter parameter = null;
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
                            where p.Code == "templategrid"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["TemplateId"] != null)
        {
            templateId = Int32.Parse(Request.QueryString["TemplateId"]);
            template = CntAriCli.GetTemplate(templateId, ctx);
            LoadData(template);
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
        string command = "CloseAndRebind('new')";
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
        if (template == null)
        {
            template = new Template();
            UnloadData(template);
            ctx.Add(template);
        }
        else
        {
            template = CntAriCli.GetTemplate(templateId, ctx);
            UnloadData(template);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Template template)
    {
        txtTemplateId.Text = template.TemplateId.ToString();
        txtName.Text = template.Name;
        txtContent.Content = template.Content;
        
    }
    protected void UnloadData(Template template)
    {
        template.Name = txtName.Text;
        template.Content = txtContent.Content;
    }
    #endregion Auxiliary functions

    #region Searching outside

    #endregion

}
