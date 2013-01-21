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

public partial class DiagnosticAssignedForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Diagnostic diagnostic = null;
    DiagnosticAssigned diagnosticAssigned = null;
    Patient patient = null;
    BaseVisit visit = null;
    int diagnosticId = 0;
    int diagnosticAssignedId = 0;
    int patientId = 0;
    int visitId = 0;

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
                            where p.Code == "diagnosticassigned"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["DiagnosticAssignedId"] != null)
        {
            diagnosticAssignedId = Int32.Parse(Request.QueryString["DiagnosticAssignedId"]);
            diagnosticAssigned = CntAriCli.GetDiagnosticAssigned(diagnosticAssignedId, ctx);
            LoadData(diagnosticAssigned);
        }
        else
        {
            rdpDiagnosticDate.SelectedDate = DateTime.Now;
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
            // by default disgnostic assigned date is the visit date
            rdpDiagnosticDate.SelectedDate = visit.VisitDate;
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
        if (diagnostic == null)
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
        if (rdpDiagnosticDate.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DateNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcDiagnostic.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DiagnosticNeeded);
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
        if (diagnosticAssigned == null)
        {
            diagnosticAssigned = new DiagnosticAssigned();
            UnloadData(diagnosticAssigned);
            ctx.Add(diagnosticAssigned);
        }
        else
        {
            diagnostic = CntAriCli.GetDiagnostic(diagnosticId, ctx);
            UnloadData(diagnosticAssigned);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(DiagnosticAssigned da)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(da.Patient.FullName, da.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = da.Patient.PersonId.ToString();

        // Load diagnostic data
        rdcDiagnostic.Items.Clear();
        rdcDiagnostic.Items.Add(new RadComboBoxItem(da.Diagnostic.Name, da.Diagnostic.DiagnosticId.ToString()));
        rdcDiagnostic.SelectedValue = da.Diagnostic.DiagnosticId.ToString();


        rdpDiagnosticDate.SelectedDate = da.DiagnosticDate;
        txtComments.Text = da.Comments;
    }

    protected void UnloadData(DiagnosticAssigned da)
    {
        da.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        da.DiagnosticDate = (DateTime)rdpDiagnosticDate.SelectedDate;
        da.Diagnostic = CntAriCli.GetDiagnostic(int.Parse(rdcDiagnostic.SelectedValue), ctx);
        if (visit != null)
            da.BaseVisit = visit;
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

    protected void rdcDiagnostic_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from d in ctx.Diagnostics
                 where d.Name.StartsWith(e.Text)
                 select d;
        foreach (Diagnostic dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.DiagnosticId.ToString()));
        }
    }
}
