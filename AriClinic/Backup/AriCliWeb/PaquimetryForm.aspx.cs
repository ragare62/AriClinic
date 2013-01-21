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

public partial class PaquimetryForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Examination examination = null;
    Paquimetry paquimetry = null;
    Patient patient = null;
    BaseVisit visit = null;
    int examinationId = 0;
    int examinationAssignedId = 0;
    int patientId = 0;
    int visitId = 0;
    HtmlControl frame = null;
    bool firstTime = false;

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
            user = (User)Session["User"];
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "examinationassigned"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ExaminationAssignedId"] != null)
        {
            examinationAssignedId = Int32.Parse(Request.QueryString["ExaminationAssignedId"]);
            paquimetry = (Paquimetry)CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            LoadData(paquimetry);
        }
        else
        {
            rdpExaminationDate.SelectedDate = DateTime.Now;
        }
        //
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
            // fix rdc with patient
            rdcPatient.Items.Clear();
            rdcPatient.Items.Add(new RadComboBoxItem(patient.FullName, patient.PersonId.ToString()));
            rdcPatient.SelectedValue = patient.PersonId.ToString();
            rdcPatient.Enabled = false;
        }
        //
        if (Request.QueryString["VisitId"] != null)
        {
            visitId = int.Parse(Request.QueryString["VisitId"]);
            visit = CntAriCli.GetVisit(visitId, ctx);
            patientId = visit.Patient.PersonId;
            patient = CntAriCli.GetPatient(patientId, ctx);
            // fix rdc with patient
            rdcPatient.Items.Clear();
            rdcPatient.Items.Add(new RadComboBoxItem(patient.FullName, patient.PersonId.ToString()));
            rdcPatient.SelectedValue = patient.PersonId.ToString();
            rdcPatient.Enabled = false;
            //
            rdpExaminationDate.SelectedDate = visit.VisitDate;
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
        if (paquimetry == null)
        {
            command = "CloseAndRebind('new')";
            firstTime = true;
        }
        else
        {
            command = "CloseAndRebind('')";
            firstTime = false;
        }
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
        if (rdpExaminationDate.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DateNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcExamination.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.ExaminationNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcPatient.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.PatientNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }

        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (paquimetry == null)
        {
            paquimetry = new Paquimetry();
            UnloadData(paquimetry);
            ctx.Add(paquimetry);
        }
        else
        {
            paquimetry = (Paquimetry)CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            UnloadData(paquimetry);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Paquimetry paq)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(paq.Patient.FullName, paq.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = paq.Patient.PersonId.ToString();

        // Load Examination data
        rdcExamination.Items.Clear();
        rdcExamination.Items.Add(new RadComboBoxItem(paq.Examination.Name, paq.Examination.ExaminationId.ToString()));
        rdcExamination.SelectedValue = paq.Examination.ExaminationId.ToString();

        if (paq.LeftEyeCentralC0 != null) txtCC0Left.Value = (double)paq.LeftEyeCentralC0;
        if (paq.RightEyeCentralC0 != null) txtCC0Right.Value = (double)paq.RightEyeCentralC0;
        if (paq.LeftEyeC1 != null) txtC1Left.Value = (double)paq.LeftEyeC1;
        if (paq.RightEyeC1 != null) txtC1Right.Value = (double)paq.RightEyeC1;
        if (paq.LeftEyeC3 != null) txtC3Left.Value = (double)paq.LeftEyeC3;
        if (paq.RightEyeC3 != null) txtC3Right.Value = (double)paq.RightEyeC3;
        if (paq.LeftEyeC5 != null) txtC5Left.Value = (double)paq.LeftEyeC5;
        if (paq.RightEyeC5 != null) txtC5Right.Value = (double)paq.RightEyeC5;
        if (paq.LeftEyeC7 != null) txtC7Left.Value = (double)paq.LeftEyeC7;
        if (paq.RightEyeC7 != null) txtC7Right.Value = (double)paq.RightEyeC7;        
        
        rdpExaminationDate.SelectedDate = paq.ExaminationDate;
        txtComments.Text = paq.Comments;
    }

    protected void UnloadData(Paquimetry paq)
    {
        paq.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        paq.ExaminationDate = (DateTime)rdpExaminationDate.SelectedDate;
        paq.Examination = CntAriCli.GetExamination(int.Parse(rdcExamination.SelectedValue), ctx);
        if (visit != null)
            paq.BaseVisit = visit;
        if (txtCC0Left.Value != null) paq.LeftEyeCentralC0 = (decimal)txtCC0Left.Value;
        if (txtCC0Right.Value != null) paq.RightEyeCentralC0 = (decimal)txtCC0Right.Value;
        if (txtC1Left.Value != null) paq.LeftEyeC1 = (decimal)txtC1Left.Value;
        if (txtC1Right.Value != null) paq.RightEyeC1 = (decimal)txtC1Right.Value;
        if (txtC3Left.Value != null) paq.LeftEyeC3 = (decimal)txtC3Left.Value;
        if (txtC3Right.Value != null) paq.RightEyeC3 = (decimal)txtC3Right.Value;
        if (txtC5Left.Value != null) paq.LeftEyeC5 = (decimal)txtC5Left.Value;
        if (txtC5Right.Value != null) paq.RightEyeC5 = (decimal)txtC5Right.Value;
        if (txtC7Left.Value != null) paq.LeftEyeC7 = (decimal)txtC7Left.Value;
        if (txtC7Right.Value != null) paq.RightEyeC7 = (decimal)txtC7Right.Value;
        paq.Comments = txtComments.Text;
    }

    #endregion Auxiliary functions

    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
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

    protected void rdcExamination_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from d in ctx.Examinations
                 where d.Name.StartsWith(e.Text)
                       && d.ExaminationType.Code == "paquimetry"
                 select d;
        foreach (Examination dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.ExaminationId.ToString()));
        }
    }

}