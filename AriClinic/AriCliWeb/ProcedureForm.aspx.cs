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

public partial class ProcedureForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Procedure proc= null;
    int procedureId = 0;
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
                            where p.Code == "procedure"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ProcedureId"] != null)
        {
            procedureId = Int32.Parse(Request.QueryString["ProcedureId"]);
            proc = CntAriCli.GetProcedure(procedureId, ctx);
            LoadData(proc);
        }
        // Allways read parameter
        parameter = CntAriCli.GetParameter(ctx);
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
        if (proc == null)
        {
            proc = new Procedure();
            UnloadData(proc);
            ctx.Add(proc);
        }
        else
        {
            proc = CntAriCli.GetProcedure(procedureId, ctx);
            UnloadData(proc);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Procedure proc)
    {
        txtProcedureId.Text = proc.ProcedureId.ToString();
        txtName.Text = proc.Name;
        if (proc.Service != null)
        {
            txtServiceId.Text = proc.Service.ServiceId.ToString();
            txtServiceName.Text = proc.Service.Name;
        }
        
    }
    protected void UnloadData(Procedure proc)
    {
        proc.Name = txtName.Text;
        if (txtServiceId.Text != "")
        {
            proc.Service = CntAriCli.GetService(int.Parse(txtServiceId.Text), ctx);
        }
    }
    #endregion Auxiliary functions

    #region Searching outside
    protected void txtServiceId_TextChanged(object sender, EventArgs e)
    {
        // search for a service
        Service ser = CntAriCli.GetService(Int32.Parse(txtServiceId.Text), ctx);
        if (ser != null)
        {
            txtServiceId.Text = ser.ServiceId.ToString();
            txtServiceName.Text = ser.Name;
        }
        else
        {
            txtServiceId.Text = "";
            txtServiceName.Text = Resources.GeneralResource.ServiceDoesNotExists;
        }
    }

    #endregion

}
