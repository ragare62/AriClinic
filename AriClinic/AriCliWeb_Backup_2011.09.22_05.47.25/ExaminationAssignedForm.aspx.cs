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

public partial class ExaminationAssignedForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Examination examination = null;
    ExaminationAssigned examinationAssigned = null;
    Patient patient = null;
    int examinationId = 0;
    int examinationAssignedId = 0;
    int patientId = 0;

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
            examinationAssigned = CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            LoadData(examinationAssigned);
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
        if (examinationAssigned == null)
        {
            examinationAssigned = new ExaminationAssigned();
            UnloadData(examinationAssigned);
            ctx.Add(examinationAssigned);
        }
        else
        {
            examination = CntAriCli.GetExamination(examinationId, ctx);
            UnloadData(examinationAssigned);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(ExaminationAssigned da)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(da.Patient.FullName, da.Patient.PersonId.ToString()));

        // Load Examination data
        rdcExamination.Items.Clear();
        rdcExamination.Items.Add(new RadComboBoxItem(da.Examination.Name, da.Examination.ExaminationId.ToString()));

        rdpExaminationDate.SelectedDate = da.ExaminationDate;
        txtComments.Text = da.Comments;
    }

    protected void UnloadData(ExaminationAssigned da)
    {
        da.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        da.ExaminationDate = (DateTime)rdpExaminationDate.SelectedDate;
        da.Examination = CntAriCli.GetExamination(int.Parse(rdcExamination.SelectedValue), ctx);
        da.Comments = txtComments.Text;
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
                 select d;
        foreach (Examination dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.ExaminationId.ToString()));
        }
    }
}
