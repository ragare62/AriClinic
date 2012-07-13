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
                LoadDiaryCombo(dia);
            }
        }
        if (Request.QueryString["PatientId"] != null)
        {
            // Patient passed
            Patient pat = CntAriCli.GetPatient(int.Parse(Request.QueryString["PatientId"]), ctx);
            LoadPatientCombo(pat);
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
        if (rdcPatient.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.PatientNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // diary needed
        if (rdcDiary.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DiaryNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // professional needed
        if (rdcProfessional.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}', '{1}','warning',null,0,0);"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.ProfessionalNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // appointment type needed
        if (rdcAppointmentType.SelectedValue == "")
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
        LoadPatientCombo(app.Patient);
        LoadDiaryCombo(app.Diary);
        LoadAppointmentTypeCombo(app.AppointmentType);
        LoadProfessionalCombo(app.Professional);
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
        if (app != null && app.BaseVisits.Count > 0)
        {
            command = String.Format("return EditVisit({0});", app.BaseVisits[0].VisitId);
        }
        else
        {
            command = String.Format("return CreateVisit({0});", app.AppointmentId);
        }
        btnVisit.OnClientClick = command;
        btnVisit.Visible = true;
    }

    protected void UnloadData(AppointmentInfo app)
    {
        app.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        app.Diary = CntAriCli.GetDiary(int.Parse(rdcDiary.SelectedValue), ctx);
        app.Professional = CntAriCli.GetProfessional(int.Parse(rdcProfessional.SelectedValue), ctx);
        app.AppointmentType = CntAriCli.GetAppointmentType(int.Parse(rdcAppointmentType.SelectedValue), ctx);
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
        ddlStatus.Items.Add(new ListItem("Sin hora", "5"));
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
        if (apptype == null) return;
        txtDuration.Text = apptype.Duration.ToString();
        DateTime start = (DateTime)rddtBeginDateTime.SelectedDate;
        rddtEndDateTime.SelectedDate = start.AddMinutes(apptype.Duration);
    }

    #endregion Auxiliary functions

    #region Searching outside


    protected void txtDuration_TextChanged(object sender, EventArgs e)
    {
        // We must recalulate end date time, if there's a begin date time selected
        if (rddtBeginDateTime.SelectedDate != null)
        {
            DateTime start = (DateTime)rddtBeginDateTime.SelectedDate;
            int dur = 0;
            if (txtDuration.Text != "") dur = int.Parse(txtDuration.Text);
            rddtEndDateTime.SelectedDate = start.AddMinutes(dur);
        }
    }
    #endregion

    protected void rddtBeginDateTime_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        // We check if an appointment type is selected
        if (rdcAppointmentType.SelectedValue != "")
        {
            AppointmentType apptype = CntAriCli.GetAppointmentType(int.Parse(rdcAppointmentType.SelectedValue), ctx);
            if (apptype != null)
                TimeCalculation(apptype);
        }
    }
    
    // Combo controls
    protected void LoadPatientCombo(Patient patient)
    {
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem( patient.FullName, patient.PersonId.ToString()));
        rdcPatient.SelectedValue = patient.PersonId.ToString();
    }
    protected void LoadDiaryCombo(Diary diary)
    {
        rdcDiary.Items.Clear();
        rdcDiary.Items.Add(new RadComboBoxItem(diary.Name, diary.DiaryId.ToString()));
        rdcDiary.SelectedValue = diary.DiaryId.ToString();
    }
    protected void LoadProfessionalCombo(Professional professional)
    {
        rdcProfessional.Items.Clear();
        rdcProfessional.Items.Add(new RadComboBoxItem(professional.FullName, professional.PersonId.ToString()));
        rdcProfessional.SelectedValue = professional.PersonId.ToString();
    }
    protected void LoadAppointmentTypeCombo(AppointmentType apptype)
    {
        rdcAppointmentType.Items.Clear();
        rdcAppointmentType.Items.Add(new RadComboBoxItem(apptype.Name, apptype.AppointmentTypeId.ToString()));
        rdcAppointmentType.SelectedValue = apptype.AppointmentTypeId.ToString();
    }

    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from c in ctx.Patients
                 where c.FullName.StartsWith(e.Text)
                 select c;
        foreach (Patient pat in rs)
        {
            combo.Items.Add(new RadComboBoxItem(pat.FullName, pat.PersonId.ToString()));
        }
    }

    protected void rdcDiary_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from c in ctx.Diaries
                 where c.Name.StartsWith(e.Text)
                 select c;
        foreach (Diary dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.DiaryId.ToString()));
        }
    }

    protected void rdcAppointmentType_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from c in ctx.AppointmentTypes
                 where c.Name.StartsWith(e.Text)
                 select c;
        foreach (AppointmentType apptype in rs)
        {
            combo.Items.Add(new RadComboBoxItem(apptype.Name, apptype.AppointmentTypeId.ToString()));
        }
    }

    protected void rdcProfessional_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from c in ctx.Professionals
                 where c.FullName.StartsWith(e.Text)
                 select c;
        foreach (Professional prf in rs)
        {
            combo.Items.Add(new RadComboBoxItem(prf.FullName, prf.PersonId.ToString()));
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }

    protected void rdcAppointmentType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rdcAppointmentType.SelectedValue != "")
        {
            AppointmentType apptype = CntAriCli.GetAppointmentType(int.Parse(rdcAppointmentType.SelectedValue), ctx);
            TimeCalculation(apptype);
        }
        
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue == "2")
        {
            rddtArrival.SelectedDate = DateTime.Now;
        }
    }


}
