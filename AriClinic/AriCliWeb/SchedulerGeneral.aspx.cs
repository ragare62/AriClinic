using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Drawing;

public partial class SchedulerGeneral : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Diary diary = null;
    Professional professional = null;
    AppointmentInfo appointment = null;

    int diaryId = 0; 
    int appointmentId = 0; 
    int professionalId = 0;

    string type = "";
    Permission per = null;

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
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "scheduler"
                            select p).FirstOrDefault<Process>();
            if (proc != null) per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // Do you want to see a Diary?
        if (Request.QueryString["DiaryId"] != null)
        {
            diaryId = int.Parse(Request.QueryString["DiaryId"]);
            diary = CntAriCli.GetDiary(diaryId, ctx);
            if (diary != null)
            {
                lblTitle.Text = diary.Name;
                this.Title = diary.Name;
            }
        }
        // Do you want to see a Professional?
        if (Request.QueryString["ProfessionalId"] != null)
        {
            professionalId = int.Parse(Request.QueryString["ProfessionalId"]);
            professional = CntAriCli.GetProfessional(professionalId, ctx);
            if (professional != null)
                lblTitle.Text = professional.FullName;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SchedulerConfig();
            SchedulerLoad();
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events

    #region Auxiliary functions
    protected void SchedulerConfig()
    {
        RadScheduler1.DataKeyField = "AppointmentId";
        RadScheduler1.DataStartField = "BeginDateTime";
        RadScheduler1.DataEndField = "EndDateTime";
        RadScheduler1.DataSubjectField = "Subject";
        RadScheduler1.DataDescriptionField = "Status";
        if (diary != null)
        {
            RadScheduler1.MinutesPerRow = diary.TimeStep;
            RadScheduler1.DayStartTime = new System.TimeSpan(diary.BeginHour.Hour, diary.BeginHour.Minute, 0);
            RadScheduler1.DayEndTime = new System.TimeSpan(diary.EndHour.Hour, diary.EndHour.Minute, 0);
            RadScheduler1.WorkDayStartTime = new System.TimeSpan(diary.BeginHour.Hour, diary.BeginHour.Minute, 0);
            RadScheduler1.WorkDayEndTime = new System.TimeSpan(diary.EndHour.Hour, diary.EndHour.Minute, 0);
        }
        else // considere to substitute by parameters
        {
            RadScheduler1.MinutesPerRow = 10; // By default step 10 minutes
            RadScheduler1.DayStartTime = new System.TimeSpan(8, 0, 0);
            RadScheduler1.DayEndTime = new System.TimeSpan(22, 0, 0);
            RadScheduler1.WorkDayStartTime = new System.TimeSpan(8, 0, 0);
            RadScheduler1.WorkDayEndTime = new System.TimeSpan(22, 0, 0);
        }
    }
    protected void SchedulerLoad()
    {
        DateTime a1 = RadScheduler1.VisibleRangeStart;
        DateTime a2 = RadScheduler1.VisibleRangeEnd;
        if (professional != null)
            RadScheduler1.DataSource = CntAriCli.GetAppointments(professional, a1, a2, ctx);
        if (diary != null)
            RadScheduler1.DataSource = CntAriCli.GetAppointments(diary, a1, a2, ctx);
        if (professional == null && diary == null)
            RadScheduler1.DataSource = CntAriCli.GetAppointments(a1, a2, ctx);
        RadScheduler1.Rebind();
    }
    #region Scheduler events
    protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
        // Eliminar la cita 
        int id = (int)e.Appointment.ID;
        appointment = CntAriCli.GetAppointment(id, ctx);
        ctx.Delete(appointment);
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add("refreshScheduler();");
    }
    protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        string estado = e.Appointment.Description;
        int id = (int)e.Appointment.ID;
        appointment = CntAriCli.GetAppointment(id, ctx);
        //Modificamos la apariencia según el estado
        switch (estado)
        {
            case "0":
                // Citado dejamos el item como está
                e.Appointment.CssClass = "rsCategoryWhite";
                break;
            case "1":
                // Programada
                e.Appointment.CssClass = "rsCategoryBlue"; //rsCategoryRed
                break;
            case "2":
                // Sala de espera
                e.Appointment.CssClass = "rsCategoryPink"; //rsCategoryGreen
                break;
            case "3":
                // Atendido
                e.Appointment.CssClass = "rsCategoryGreen"; //rsCategoryYellow
                break;
            case "4":
            case "5":
                // No presentado / Sin hora?
                e.Appointment.CssClass = "rsCategoryYellow"; //rsCategoryBlue
                break;
            default:
                break;
        }
        // now we charge the new description
        e.Appointment.Description = CntAriCli.GetAppointmentDescription(appointment, ctx);
    }
    protected void RadScheduler1_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        SchedulerLoad();
    }
    #endregion
    #endregion Auxilairy funcions
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "RebindScheduler")
        {
            SchedulerLoad();
        }
    }

    protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        switch (e.Item.Value)
        {
            case "morning":
                RadScheduler1.DayStartTime = new TimeSpan(8, 0, 0);
                RadScheduler1.DayEndTime = new TimeSpan(15, 59, 0);
                RadScheduler1.Rebind();
                break;
            case "evening":
                RadScheduler1.DayStartTime = new TimeSpan(16, 0, 0);
                RadScheduler1.DayEndTime = new TimeSpan(23, 59, 0);
                RadScheduler1.Rebind();
                break;
            case "print":
                string js = String.Format("printDiary({0:yyyyMMdd}, {1});", RadScheduler1.SelectedDate, diary.DiaryId);
                RadAjaxManager1.ResponseScripts.Add(js);
                break;
        }
    }
}
