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

public partial class RequestForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Request chn = null;
    int channelId = 0;
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
                            where p.Code == "channel"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["RequestId"] != null)
        {
            channelId = Int32.Parse(Request.QueryString["RequestId"]);
            chn = CntAriCli.GetRequest(channelId, ctx);
            LoadData(chn);
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
        if (chn == null)
        {
            chn = new Request();
            UnloadData(chn);
            ctx.Add(chn);
        }
        else
        {
            chn = CntAriCli.GetRequest(channelId, ctx);
            UnloadData(chn);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Request chn)
    {
        txtRequestId.Text = chn.RequestId.ToString();
        txtName.Text = chn.Name;
    }
    protected void UnloadData(Request chn)
    {
        chn.Name = txtName.Text;
    }
    #endregion Auxiliary functions



}
