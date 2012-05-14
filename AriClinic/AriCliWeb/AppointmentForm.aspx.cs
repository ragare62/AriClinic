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

public partial class AppointmentForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Patient pat = null;
    HealthcareCompany hc = null;
    AriCliModel.Parameter parameter; // it must spccified to aboid confussion
    int appId = 0;
    int patientId = 0;
    Permission per = null;
    AppointmentInfo app = null;
    DateTime? beginDateTime= null; DateTime? endDateTime = null;
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
            user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "appointment"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        if (Request.QueryString["DiaryId"] != null)
        {
            // Diary passed
            Diary dia = CntAriCli.GetDiary(int.Parse(Request.QueryString["DiaryId"]), ctx);
            if (dia != null)
            {
                txtDiaryId.Text = dia.DiaryId.ToString();
                txtDiaryName.Text = dia.Name;
            }
        }
        if (Request.QueryString["PatientId"] != null)
        {
            // Patient passed
            Patient pat = CntAriCli.GetPatient(int.Parse(Request.QueryString["PatientId"]), ctx);
            txtPatientId.Text = pat.PersonId.ToString();
            txtPatientName.Text = pat.FullName;
        }
        if (Request.QueryString["AppointmentId"] != null)
        {
            appId = int.Parse(Request.QueryString["AppointmentId"]);
            app = CntAriCli.GetAppointment(appId, ctx);
        }

        LoadData(app);

        // Must be check after load data.
        if (Request.QueryString["BeginDateTime"] != null)
        {
            beginDateTime = GetCorrectDateTime(Request.QueryString["BeginDateTime"]);
            rddtBeginDateTime.SelectedDate = beginDateTime;
        }
        if (Request.QueryString["EndDateTime"] != null)
        {
            endDateTime = GetCorrectDateTime(Request.QueryString["EndDateTime"]);
            rddtEndDateTime.SelectedDate = endDateTime;
            // TODO: Recalculate duration.
        }
        // Appointement moved
        if (beginDateTime != null && app != null)
        {
            DateTime bt = (DateTime)beginDateTime;
            DateTime et = bt.AddMinutes(app.Duration);
            rddtEndDateTime.SelectedDate = et;
        }
        // Appintment resized
        if (beginDateTime != null && endDateTime != null)
        {
            DateTime bt = (DateTime)beginDateTime;
            DateTime et = (DateTime)endDateTime;
            TimeSpan t = et.Subtract(bt);
            int d = t.Minutes + (t.Hours * 60);
            txtDuration.Text = d.ToString();
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
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CloseAndRebind('new');";
        if (app == null)
            command = "CloseAndRebind();";
        if (!CreateChange())
            return;
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CloseAndRebind();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }
    protected void btnMedicalRecord_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CloseAndRebind();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }
    protected void btnVisit_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CloseAndRebind();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnServiceId_Click(object sender, ImageClickEventArgs e)
    {
    }

    #region Auxiliary functions
    protected bool DataOk()
    {
        string command = "";
        // patient needed
        if (txtPatientId.Text == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.PatientNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // diary needed
        if (txtDiaryId.Text == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DiaryNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // professional needed
        if (txtProfessionalId.Text == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.ProfessionalNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // appointment type needed
        if (txtAppointmentType.Text == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.AppointmentTypeNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rddtBeginDateTime.SelectedDate == null || rddtEndDateTime.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.BeginEndDateTimeNeeded);
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
        if (app == null)
        {
            app = new AppointmentInfo();
            UnloadData(app);
            ctx.Add(app);
            ctx.SaveChanges();
        }
        else
        {
            UnloadData(app);
            ctx.SaveChanges();
        }
        return true;
    }

    protected void LoadData(AppointmentInfo app)
    {
        LoadStatusCombo(app);
        if (app == null) return; // There isn't any agenda to show
        txtAppointmentId.Text = String.Format("{0:00000000}", app.AppointmentId);
        txtPatientId.Text = app.Patient.PersonId.ToString();
        txtPatientName.Text = app.Patient.FullName;
        txtDiaryId.Text = app.Diary.DiaryId.ToString();
        txtDiaryName.Text = app.Diary.Name;
        txtAppointmentType.Text = app.AppointmentType.AppointmentTypeId.ToString();
        txtAppointmentTypeName.Text = app.AppointmentType.Name;
        txtProfessionalId.Text = app.Professional.PersonId.ToString();
        txtProfessionalName.Text = app.Professional.FullName;
        rddtBeginDateTime.SelectedDate = app.BeginDateTime;
        rddtEndDateTime.SelectedDate = app.EndDateTime;
        // arrival could be null in two different ways
        if (app.Arrival != null && !CntAriCli.NullDateTime(app.Arrival))
            rddtArrival.SelectedDate = app.Arrival;
        txtDuration.Text = app.Duration.ToString();
        txtSubject.Text = app.Subject;
        txtComments.Text = app.Comments;
        //
        string command = String.Format("return ViewHisAdm({0});", app.Patient.PersonId);
        btnMedicalRecord.OnClientClick = command;
        btnMedicalRecord.Visible = true;
        //
        command = String.Format("return CreateVisit({0});", app.AppointmentId);
        btnVisit.OnClientClick = command;
        btnVisit.Visible = true;
    }

    protected void UnloadData(AppointmentInfo app)
    {
        app.Patient = CntAriCli.GetPatient(int.Parse(txtPatientId.Text), ctx);
        app.Diary = CntAriCli.GetDiary(int.Parse(txtDiaryId.Text), ctx);
        app.Professional = CntAriCli.GetProfessional(int.Parse(txtProfessionalId.Text), ctx);
        app.AppointmentType = CntAriCli.GetAppointmentType(int.Parse(txtAppointmentType.Text), ctx);
        app.BeginDateTime = (DateTime)rddtBeginDateTime.SelectedDate;
        app.EndDateTime = (DateTime)rddtEndDateTime.SelectedDate;
        app.Duration = int.Parse(txtDuration.Text);
        app.Status = ddlStatus.SelectedValue;
        if (rddtArrival.SelectedDate != null)
            app.Arrival = (DateTime)rddtArrival.SelectedDate;
        else
            app.Arrival = DateTime.Parse("01/01/0001 00:00:00");
        app.Subject = CntAriCli.GetAppointmentSubject(app);
        app.Comments = txtComments.Text;
    }
     
    protected void LoadStatusCombo(AppointmentInfo app)
    {
        // Status are hard coded
        ddlStatus.Items.Clear(); // erase all previous codes
        ddlStatus.Items.Add(new ListItem( "Programada","1"));
        ddlStatus.Items.Add(new ListItem("Sala de espera","2"));
        ddlStatus.Items.Add(new ListItem("Atendida", "3"));
        ddlStatus.Items.Add(new ListItem("No presentado","4"));
        if (app != null)
        {
            ddlStatus.SelectedValue = app.Status;
        }
        else
        {
            // By default an appointment is scheduled
            ddlStatus.SelectedValue = "1";
        }
    }
    protected DateTime GetCorrectDateTime(string s)
    {
        return new DateTime(
            int.Parse(s.Substring(0, 4))
            , int.Parse(s.Substring(4, 2))
            , int.Parse(s.Substring(6, 2))
            , int.Parse(s.Substring(8, 2))
            , int.Parse(s.Substring(10, 2))
            , 0);

    }
    protected void TimeCalculation(AppointmentType apptype)
    {
        txtDuration.Text = apptype.Duration.ToString();
        DateTime start = (DateTime)rddtBeginDateTime.SelectedDate;
        rddtEndDateTime.SelectedDate = start.AddMinutes(apptype.Duration);
    }

    #endregion Auxiliary functions

    #region Searching outside
    protected void txtDiaryId_TextChanged(object sender, EventArgs e)
    {
        Diary dia = CntAriCli.GetDiary(int.Parse(txtDiaryId.Text), ctx);
        if (dia == null)
        {
            txtDiaryId.Text = "";
            txtDiaryName.Text = Resources.GeneralResource.DiaryDoesNotExists;
        }
        else
        {
            txtDiaryId.Text = dia.DiaryId.ToString();
            txtDiaryName.Text = dia.Name;
        }
    }

    protected void txtPatientId_TextChanged(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(txtPatientId.Text, out id)) return;
        Patient pat = CntAriCli.GetPatient(id, ctx);
        if (pat == null)
        {
            txtPatientId.Text = "";
            txtPatientName.Text = Resources.GeneralResource.PatientDoesNotExists;
        }
        else
        {
            txtPatientId.Text = pat.PersonId.ToString();
            txtPatientName.Text = pat.FullName;
        }
    }

    protected void txtAppointmentTypeId_TextChanged(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(txtAppointmentType.Text, out id)) return; 
        AppointmentType apptype = CntAriCli.GetAppointmentType(id, ctx);
        if (apptype == null)
        {
            txtAppointmentType.Text = "";
            txtAppointmentTypeName.Text = Resources.GeneralResource.AppointmentTypeDoesNotExists;
        }
        else
        {
            txtAppointmentType.Text = apptype.AppointmentTypeId.ToString();
            txtAppointmentTypeName.Text = apptype.Name;
            if (rddtBeginDateTime.SelectedDate != null)
                TimeCalculation(apptype);
        }
    }

    protected void txtProfessionalId_TextChanged(object sender, EventArgs e)
    {
        int id;
        if (!int.TryParse(txtProfessionalId.Text, out id)) return;
        Professional prof = CntAriCli.GetProfessional(id, ctx);
        if (prof == null)
        {
            txtProfessionalId.Text = "";
            txtProfessionalName.Text = Resources.GeneralResource.ProfessionalDoesNotExists;
        }
        else
        {
            txtProfessionalId.Text = prof.PersonId.ToString();
            txtProfessionalName.Text = prof.FullName;
        }
    }

    protected void txtDuration_TextChanged(object sender, EventArgs e)
    {
        // We must recalulate end date time, if there's a begin date time selected
        if (rddtBeginDateTime.SelectedDate != null)
        {
            DateTime start = (DateTime)rddtBeginDateTime.SelectedDate;
            rddtEndDateTime.SelectedDate = start.AddMinutes(int.Parse(txtDuration.Text));
        }
    }
    #endregion

    protected void rddtBeginDateTime_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        // We check if an appointment type is selected
        if (txtAppointmentType.Text != "")
        {
            AppointmentType apptype = CntAriCli.GetAppointmentType(int.Parse(txtAppointmentType.Text), ctx);
            if (apptype != null)
                TimeCalculation(apptype);
        }
    }
}
