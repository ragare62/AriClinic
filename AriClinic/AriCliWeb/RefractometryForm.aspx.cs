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

public partial class RefractometryForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Examination examination = null;
    Refractometry refractometry = null;
    Patient patient = null;
    int examinationId = 0;
    int examinationAssignedId = 0;
    int patientId = 0;
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
            refractometry = (Refractometry)CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            LoadData(refractometry);
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
        if (refractometry == null)
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
        if (firstTime)
            Response.Redirect(String.Format("RefractometryForm.aspx?ExaminationAssignedId={0}",refractometry.ExaminationAssignedId));
        else
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
        if (refractometry == null)
        {
            refractometry = new Refractometry();
            UnloadData(refractometry);
            ctx.Add(refractometry);
        }
        else
        {
            refractometry = (Refractometry)CntAriCli.GetExaminationAssigned(examinationAssignedId, ctx);
            UnloadData(refractometry);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Refractometry rf)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(rf.Patient.FullName, rf.Patient.PersonId.ToString()));

        // Load Examination data
        rdcExamination.Items.Clear();
        rdcExamination.Items.Add(new RadComboBoxItem(rf.Examination.Name, rf.Examination.ExaminationId.ToString()));

        // Now we must load tabstrip
        frame = (HtmlControl)this.FindControl("FrmArea");
        if (refractometry.WithoutGlassesTests.Count() == 0)
            frame.Attributes["src"] = String.Format("WithoutGlassesForm.aspx?RefractometryId={0}", refractometry.ExaminationAssignedId);
        else
            frame.Attributes["src"] = String.Format("WithoutGlassesForm.aspx?RefractometryId={0}&WithoutGlassesId={1}", 
                refractometry.ExaminationAssignedId, refractometry.WithoutGlassesTests[0].Id);

        rdpExaminationDate.SelectedDate = rf.ExaminationDate;
        txtComments.Text = rf.Comments;
    }

    protected void UnloadData(Refractometry rf)
    {
        rf.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        rf.ExaminationDate = (DateTime)rdpExaminationDate.SelectedDate;
        rf.Examination = CntAriCli.GetExamination(int.Parse(rdcExamination.SelectedValue), ctx);
        rf.Comments = txtComments.Text;
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
                       && d.ExaminationType.Code == "refractometry"
                 select d;
        foreach (Examination dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.ExaminationId.ToString()));
        }
    }

    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        frame = (HtmlControl)this.FindControl("FrmArea");
        switch (e.Tab.Value)
        {
            case "T1":
                if (refractometry.WithoutGlassesTests.Count() == 0)
                    frame.Attributes["src"] = String.Format("WithoutGlassesForm.aspx?RefractometryId={0}", refractometry.ExaminationAssignedId);
                else
                    frame.Attributes["src"] = String.Format("WithoutGlassesForm.aspx?RefractometryId={0}&WithoutGlassesId={1}",
                        refractometry.ExaminationAssignedId, refractometry.WithoutGlassesTests[0].Id);
                break;
            case "T2":
                if (refractometry.GlassesTests.Count() == 0)
                    frame.Attributes["src"] = String.Format("GlassesTestForm.aspx?RefractometryId={0}", refractometry.ExaminationAssignedId);
                else
                    frame.Attributes["src"] = String.Format("GlassesTestForm.aspx?RefractometryId={0}&GlassesTestId={1}",
                        refractometry.ExaminationAssignedId, refractometry.GlassesTests[0].Id);
                break;
            case "T3":
                if (refractometry.ContactLensesTests.Count() == 0)
                    frame.Attributes["src"] = String.Format("ContactLensesTestForm.aspx?RefractometryId={0}", refractometry.ExaminationAssignedId);
                else
                    frame.Attributes["src"] = String.Format("ContactLensesTestForm.aspx?RefractometryId={0}&ContactLensesTestId={1}",
                        refractometry.ExaminationAssignedId, refractometry.ContactLensesTests[0].Id);
                break;
        }
    }
}