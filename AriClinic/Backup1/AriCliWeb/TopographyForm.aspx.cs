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

public partial class TopographyForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Examination examination = null;
    Topography topography = null;
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
            topography = (Topography)CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            LoadData(topography);
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
        if (topography == null)
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
        if (topography == null)
        {
            topography = new Topography();
            UnloadData(topography);
            ctx.Add(topography);
        }
        else
        {
            topography = (Topography)CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            UnloadData(topography);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Topography topo)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(topo.Patient.FullName, topo.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = topo.Patient.PersonId.ToString();

        // Load Examination data
        rdcExamination.Items.Clear();
        rdcExamination.Items.Add(new RadComboBoxItem(topo.Examination.Name, topo.Examination.ExaminationId.ToString()));
        rdcExamination.SelectedValue = topo.Examination.ExaminationId.ToString();
        if (topo.LeftEyeK1 != null) txtK1Left.Value = (double)topo.LeftEyeK1;
        if (topo.RightEyeK1 != null) txtK1Right.Value = (double)topo.RightEyeK1;
        if (topo.LeftEyeK2 != null) txtK2Left.Value = (double)topo.LeftEyeK2;
        if (topo.RightEyeK2 != null) txtK2Right.Value = (double)topo.RightEyeK2;
        if (topo.LeftEyeAstig != null) txtAstigLeft.Value = (double)topo.LeftEyeAstig;
        if (topo.RightEyeAstig != null) txtAstigRight.Value = (double)topo.RightEyeAstig;
        if (topo.LeftEyeAxis != null) txtAxisLeft.Value = (double)topo.LeftEyeAxis;
        if (topo.RightEyeAxis != null) txtAxisRight.Value = (double)topo.RightEyeAxis;

       
        
        rdpExaminationDate.SelectedDate = topo.ExaminationDate;
        txtComments.Text = topo.Comments;
    }

    protected void UnloadData(Topography topo)
    {
        topo.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        topo.ExaminationDate = (DateTime)rdpExaminationDate.SelectedDate;
        topo.Examination = CntAriCli.GetExamination(int.Parse(rdcExamination.SelectedValue), ctx);
        if (visit != null)
            topo.BaseVisit = visit;
        if (txtK1Left.Value != null) topo.LeftEyeK1 = (decimal)txtK1Left.Value;
        if (txtK1Right.Value != null) topo.RightEyeK1 = (decimal)txtK1Right.Value;
        if (txtK2Left.Value != null) topo.LeftEyeK2 = (decimal)txtK2Left.Value;
        if (txtK2Right.Value != null) topo.RightEyeK2 = (decimal)txtK2Right.Value;
        if (txtAstigLeft.Value != null) topo.LeftEyeAstig = (decimal)txtAstigLeft.Value;
        if (txtAstigRight.Value != null) topo.RightEyeAstig = (decimal)txtAstigRight.Value;
        if (txtAxisLeft.Value != null) topo.LeftEyeAxis = (decimal)txtAxisLeft.Value;
        if (txtAxisRight.Value != null) topo.RightEyeAxis = (decimal)txtAxisRight.Value;
        topo.Comments = txtComments.Text;
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
                       && d.ExaminationType.Code == "topography"
                 select d;
        foreach (Examination dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.ExaminationId.ToString()));
        }
    }

}