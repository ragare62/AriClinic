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

public partial class VisitForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Professional professional = null;
    BaseVisit visit = null;
    Patient patient = null;
    VisitReason visitReason = null;
    AppointmentInfo app = null;
    string caller = "";
    bool fromAppointment = false;
    int professionalId = 0;
    int visitId = 0;
    int patientId = 0;
    int visitReasonId = 0;

    Permission per = null;
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
                            where p.Code == "visit"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
            if (user.Professionals.Count > 0)
            {
                professional = user.Professionals[0];
                LoadComboProfesional(professional);
            }
        }

        // 
        if (Request.QueryString["VisitId"] != null)
        {
            visitId = Int32.Parse(Request.QueryString["VisitId"]);
            visit = CntAriCli.GetVisit(visitId, ctx);
            LoadData(visit);
        }
        else
        {
            rdpVisitDate.SelectedDate = DateTime.Now;
            // load professional
            if (Session["Professional"] != null) LoadComboProfesional((Professional)Session["Professional"]);
            // called from an appointment?
            if (Request.QueryString["AppointmentId"] != null) 
            {
                app = CntAriCli.GetAppointment(int.Parse(Request.QueryString["AppointmentId"]), ctx);
                if (app != null)
                {
                    Patient pat = app.Patient;
                    rdcPatient.Items.Clear();
                    rdcPatient.Items.Add(new RadComboBoxItem(pat.FullName, pat.PersonId.ToString()));
                    rdcPatient.SelectedValue = pat.PersonId.ToString();
                    //
                    rdpVisitDate.SelectedDate = app.BeginDateTime;
                    //
                    LoadComboProfesional(app.Professional);
                    //
                    AppointmentType appt = app.AppointmentType;
                    rdcAppointmentType.Items.Clear();
                    rdcAppointmentType.Items.Add(new RadComboBoxItem(appt.Name, appt.AppointmentTypeId.ToString()));
                    rdcAppointmentType.SelectedValue = appt.AppointmentTypeId.ToString();
                    //
                    fromAppointment = true;
                }
            }
        }
        //
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
            // fix rdc with patient
            rdcPatient.Items.Clear();
            rdcPatient.Items.Add(new RadComboBoxItem(patient.FullName,patient.PersonId.ToString()));
            rdcPatient.SelectedValue = patient.PersonId.ToString();
            rdcPatient.Enabled = false;
        }
        //
        if (Request.QueryString["Type"] != null)
        {
            type = Request.QueryString["Type"];
            if (type == "InTab")
            {
                HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
                tt.Attributes["class"] = "ghost";
            }
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
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
        string command = "";
        if (visit == null)
            command = "CloseAndRebind('new')";
        else
            command = "CloseAndRebind('')";
        if (!CreateChange())
            return;
        if (Session["FromAppointment"] != null)
        {
            command = "CancelEdit();";
            Session["FromAppointment"] = null;
        }
        if (type == "InTab" && command == "CloseAndRebind('new')")
        {
            command = String.Format("parentReload('VisitTab.aspx?VisitId={0}');", visit.VisitId);
            //RadWindowManager1.RadConfirm(Resources.GeneralResource.VisitFirstAccept,"noHaceNada", null, null, null,Resources.GeneralResource.Warning);
        }
        if (caller == "Appointment")
            command = "CancelEdit();";
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
        if (rdpVisitDate.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)", Resources.GeneralResource.Warning, Resources.GeneralResource.DateNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcProfessional.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)", Resources.GeneralResource.Warning, Resources.GeneralResource.ProfessionalNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcPatient.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)", Resources.GeneralResource.Warning, Resources.GeneralResource.PatientNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (visit == null)
        {
            visit = new BaseVisit();
            if (app != null)
            {
                visit.AppointmentInfo = app;
            }
            UnloadData(visit);
            ctx.Add(visit);
        }
        else
        {
            visit = CntAriCli.GetVisit(visitId, ctx);
            UnloadData(visit);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(BaseVisit visit)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(visit.Patient.FullName, visit.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = visit.Patient.PersonId.ToString();

        // Load professional data
        rdcProfessional.Items.Clear();
        rdcProfessional.Items.Add(new RadComboBoxItem(visit.Professional.FullName, visit.Professional.PersonId.ToString()));
        rdcProfessional.SelectedValue = visit.Professional.PersonId.ToString();

        rdpVisitDate.SelectedDate = visit.VisitDate;

        // Load visit reason
        if (visit.VisitReason != null)
        {
            rdcVisitReason.Items.Clear();
            rdcVisitReason.Items.Add(new RadComboBoxItem(visit.VisitReason.Name, visit.VisitReason.VisitReasonId.ToString()));
            rdcVisitReason.SelectedValue = visit.VisitReason.VisitReasonId.ToString();
        }

        // Load appointment type
        if (visit.AppointmentType != null)
        {
            rdcAppointmentType.Items.Clear();
            rdcAppointmentType.Items.Add(new RadComboBoxItem(visit.AppointmentType.Name, visit.AppointmentType.AppointmentTypeId.ToString()));
            rdcAppointmentType.SelectedValue = visit.AppointmentType.AppointmentTypeId.ToString();
        }
        
        txtComments.Text = visit.Comments;
    }

    protected void UnloadData(BaseVisit visit)
    {
        visit.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        visit.VisitDate = (DateTime)rdpVisitDate.SelectedDate;
        visit.Patient.LastUpdate = visit.VisitDate;
        visit.Professional = CntAriCli.GetProfessional(int.Parse(rdcProfessional.SelectedValue), ctx);
        if (rdcVisitReason.SelectedValue != "")
            visit.VisitReason = CntAriCli.GetVisitReason(int.Parse(rdcVisitReason.SelectedValue), ctx);
        if (rdcAppointmentType.SelectedValue != "")
            visit.AppointmentType = CntAriCli.GetAppointmentType(int.Parse(rdcAppointmentType.SelectedValue), ctx);
        visit.Comments = txtComments.Text;
        visit.VType = "general";
    }

    #endregion Auxiliary functions

    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Patients
                 where p.FullName.StartsWith(e.Text)
                 select p;
        foreach (Patient pat in rs)
        {
            combo.Items.Add(new RadComboBoxItem(pat.FullName, pat.PersonId.ToString()));
        }
    }

    protected void rdcProfessional_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Professionals
                 where p.ComercialName.StartsWith(e.Text)
                 select p;
        foreach (Professional professional in rs)
        {
            combo.Items.Add(new RadComboBoxItem(professional.ComercialName, professional.PersonId.ToString()));
        }
    }

    protected void rdcVisitReason_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from d in ctx.VisitReasons
                 where d.Name.StartsWith(e.Text)
                 select d;
        foreach (VisitReason dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.VisitReasonId.ToString()));
        }
    }

    protected void rdcAppointmentType_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from apt in ctx.AppointmentTypes
                 where apt.Name.StartsWith(e.Text)
                 select apt;
        foreach (AppointmentType apt in rs)
        {
            combo.Items.Add(new RadComboBoxItem(apt.Name, apt.AppointmentTypeId.ToString()));
        }
    }
    protected void LoadComboProfesional(Professional professional)
    {
        if (professional == null) return; // do nothing
        rdcProfessional.Items.Clear();
        rdcProfessional.Items.Add(new RadComboBoxItem(professional.FullName, professional.PersonId.ToString()));
        rdcProfessional.SelectedValue = professional.PersonId.ToString();
    }
}