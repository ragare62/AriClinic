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

public partial class ProcedureAssignedForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Procedure procedure = null;
    ProcedureAssigned procedureAssigned = null;
    Patient patient = null;
    BaseVisit visit = null;
    int procedureId = 0;
    int procedureAssignedId = 0;
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
                            where p.Code == "procedureassigned"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["ProcedureAssignedId"] != null)
        {
            procedureAssignedId = Int32.Parse(Request.QueryString["ProcedureAssignedId"]);
            procedureAssigned = CntAriCli.GetProcedureAssigned(procedureAssignedId, ctx);
            LoadData(procedureAssigned);
        }
        else
        {
            rdpProcedureDate.SelectedDate = DateTime.Now;
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
            rdpProcedureDate.SelectedDate = visit.VisitDate;
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
        if (procedure == null)
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
        if (rdpProcedureDate.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DateNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcProcedure.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.ProcedureNeeded);
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
        // 
        procedure = CntAriCli.GetProcedure(int.Parse(rdcProcedure.SelectedValue), ctx);

        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (procedureAssigned == null)
        {
            procedureAssigned = new ProcedureAssigned();
            UnloadData(procedureAssigned);
            ctx.Add(procedureAssigned);
        }
        else
        {
            procedure = CntAriCli.GetProcedure(procedureId, ctx);
            UnloadData(procedureAssigned);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(ProcedureAssigned pra)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(pra.Patient.FullName, pra.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = pra.Patient.PersonId.ToString();

        // Load procedure data
        rdcProcedure.Items.Clear();
        rdcProcedure.Items.Add(new RadComboBoxItem(pra.Procedure.Name, pra.Procedure.ProcedureId.ToString()));
        rdcProcedure.SelectedValue = pra.Procedure.ProcedureId.ToString();

        rdpProcedureDate.SelectedDate = pra.ProcedureDate;
        txtComments.Text = pra.Comments;
    }

    protected void UnloadData(ProcedureAssigned pra)
    {
        pra.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        pra.ProcedureDate = (DateTime)rdpProcedureDate.SelectedDate;
        pra.Procedure = CntAriCli.GetProcedure(int.Parse(rdcProcedure.SelectedValue), ctx);
        if (visit != null)
            pra.BaseVisit = visit;
        pra.Comments = txtComments.Text;
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

    protected void rdcProcedure_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from d in ctx.Procedures
                 where d.Name.StartsWith(e.Text)
                 select d;
        foreach (Procedure dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.ProcedureId.ToString()));
        }
    }
}
