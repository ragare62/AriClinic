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

public partial class ExaminationForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Examination examination = null;
    int examinationId = 0;
    Permission per = null;
    ExaminationType examinationType = null;
    string examinationCode = "";
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
                            where p.Code == "examination"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ExaminationId"] != null)
        {
            examinationId = Int32.Parse(Request.QueryString["ExaminationId"]);
            examination = CntAriCli.GetExamination(examinationId, ctx);
            LoadData(examination);
        }
        LoadExaminationTypeCombo(examination);
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
        if (examination == null)
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
        if (examination == null)
        {
            examination = new Examination();
            UnloadData(examination);
            ctx.Add(examination);
        }
        else
        {
            examination = CntAriCli.GetExamination(examinationId, ctx);
            UnloadData(examination);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(Examination ex)
    {
        txtExaminationId.Text = ex.ExaminationId.ToString();
        txtName.Text = ex.Name;
    }
    protected void UnloadData(Examination ex)
    {
        ex.Name = txtName.Text;
        // Examination type treatment
        ex.ExaminationType = CntAriCli.GetExaminationType(rdcExaminationType.SelectedValue, ctx);
    }
    protected void LoadExaminationTypeCombo(Examination ex)
    {
        rdcExaminationType.Items.Clear();
        foreach (ExaminationType et in CntAriCli.GetExaminationTypes(ctx))
        {
            rdcExaminationType.Items.Add(new RadComboBoxItem(et.Name, et.Code));
        }

        // Implicity there's always a 'general' type;
        if (ex == null)
            rdcExaminationType.SelectedValue = "general";
        else
            rdcExaminationType.SelectedValue = ex.ExaminationType.Code;
    }
    #endregion Auxiliary functions



}
