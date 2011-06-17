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

public partial class ProcessForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    int processId = 0;

    #endregion Variables declarations
    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        // security control, it must be a user logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");

        // 
        if (Request.QueryString["ProcessId"] != null)
        {
            processId = Int32.Parse(Request.QueryString["ProcessId"]);
            Process pr = (from p in ctx.Processes
                          where p.ProcessId == processId
                          select p).FirstOrDefault<Process>();
            LoadData(pr);
        }
        else
        {
            LoadParentProcessCombo(null);
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
        if (processId == 0)
        {
            Process pr = new Process();
            UnloadData(pr);
            ctx.Add(pr);
        }
        else
        {
            Process pr = (from p in ctx.Processes
                        where p.ProcessId == processId
                        select p).FirstOrDefault<Process>();
            UnloadData(pr);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Process p)
    {
        txtProcessId.Text = p.ProcessId.ToString();
        txtCode.Text = p.Code;
        txtName.Text = p.Name;
        txtDescription.Text = p.Description;
        LoadParentProcessCombo(p);
    }

    protected void UnloadData(Process p)
    {
        p.Code = txtCode.Text;
        p.Name = txtName.Text;
        p.Description = txtDescription.Text;
        if (ddlParentProcess.SelectedValue != "")
        {
            int id = Int32.Parse(ddlParentProcess.SelectedValue);
            p.ParentProcess = (from pr in ctx.Processes
                               where pr.ProcessId == id
                               select pr).First<Process>();
        }

    }
    protected void LoadParentProcessCombo(Process pr)
    {
        // first clear all previous option
        ddlParentProcess.Items.Clear();
        // in principle all processes are candidate for parents
        foreach (Process p in ctx.Processes)
        {
            ddlParentProcess.Items.Add(new ListItem(p.Name,p.ProcessId.ToString()));
        }
        // a blank option to represent no parent
        ddlParentProcess.Items.Add(new ListItem(" ",""));
        ddlParentProcess.SelectedValue = "";
        // check if there is parent process
        if (pr != null)
        {
            if (pr.ParentProcess != null)
            {
                ddlParentProcess.SelectedValue = pr.ParentProcess.ProcessId.ToString();
            }
        }
    }
    #endregion Auxiliary functions
}
