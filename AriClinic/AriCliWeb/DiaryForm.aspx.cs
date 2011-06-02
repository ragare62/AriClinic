using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using AriCliModel;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class DiaryForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    AriCliModel.Parameter parameter; // it must spccified to aboid confussion
    int agendaId = 0;
    Permission per = null;
    Diary agenda = null;
    string type = "";
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
                            where p.Code == "agenda"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        if (Request.QueryString["DiaryId"] != null)
        {
            agendaId = int.Parse(Request.QueryString["DiaryId"]);
            agenda = CntAriCli.GetDiary(agendaId, ctx);
        }
        LoadData(agenda);

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
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CloseAndRebind('new');";
        if (agenda == null)
            command = "CloseAndRebind();";
        if (!CreateChange())
            return;
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnServiceId_Click(object sender, ImageClickEventArgs e)
    {

    }
    #region Auxiliary functions
    protected bool DataOk()
    {
        // Name and Time step are controled by RadInputManage
        string command = ""; // Javascript command
        // A begin and end hour needed
        if (rdtmBeginHour.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0);"
                ,Resources.GeneralResource.Warning
                ,Resources.GeneralResource.BeginHourNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdtmEndHour.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0);"
                , Resources.GeneralResource.Warning
                , Resources.GeneralResource.EndHourNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        return true;
    }

    /// <summary>
    /// As its name suggest if there isn't an object
    /// it'll create it. If exists It modifies it.
    /// </summary>
    /// <returns></returns>
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (agenda == null)
        {
            agenda = new Diary();
            ctx.Add(agenda);
        }
        UnloadData(agenda);
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Diary agenda)
    {
        if (agenda == null) return; // There isn't any agenda to show
        txtDiaryId.Text = String.Format("{0:00000}", agenda.DiaryId);
        rdtmBeginHour.SelectedDate = agenda.BeginHour;
        rdtmEndHour.SelectedDate = agenda.EndHour;
        txtTimeStep.Text = agenda.TimeStep.ToString();
    }

    protected void UnloadData(Diary agenda)
    {
        agenda.Name = txtName.Text;
        agenda.BeginHour = (DateTime)rdtmBeginHour.SelectedDate;
        agenda.EndHour = (DateTime)rdtmEndHour.SelectedDate;
        agenda.TimeStep = int.Parse(txtTimeStep.Text);
    }


    #endregion Auxiliary functions

    #region Searching outside
    #endregion
}
