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

public partial class TreatmentForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Drug drug = null;
    Treatment treatment = null;
    Patient patient = null;
    BaseVisit visit = null;
    Professional professional = null;
    int drugId = 0;
    int treatmentId = 0;
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
                            where p.Code == "treatment"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
            if (user.Professionals.Count > 0)
            {
                professional = user.Professionals[0];
                rdcProfessional.Items.Clear();
                rdcProfessional.Items.Add(new RadComboBoxItem(professional.FullName, professional.PersonId.ToString()));
                rdcProfessional.SelectedValue = professional.PersonId.ToString();
            }
        }

        // 
        if (Request.QueryString["TreatmentId"] != null)
        {
            treatmentId = Int32.Parse(Request.QueryString["TreatmentId"]);
            treatment = CntAriCli.GetTreatment(treatmentId, ctx);
            LoadData(treatment);
        }
        else
        {
            rdpTreatmentDate.SelectedDate = DateTime.Now;
            if (Session["Professional"] != null) LoadProfessionalCombo((Professional)Session["Professional"]);
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
            //
            rdpTreatmentDate.SelectedDate = visit.VisitDate;
            LoadProfessionalCombo(visit.Professional);
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
        if (drug == null)
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
        if (rdpTreatmentDate.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DateNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcDrug.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DrugNeeded);
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
        if (treatment == null)
        {
            treatment = new Treatment();
            UnloadData(treatment);
            ctx.Add(treatment);
        }
        else
        {
            drug = CntAriCli.GetDrug(drugId, ctx);
            UnloadData(treatment);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Treatment tr)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(tr.Patient.FullName, tr.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = tr.Patient.PersonId.ToString();

        // Load diagnostic data
        rdcDrug.Items.Clear();
        rdcDrug.Items.Add(new RadComboBoxItem(tr.Drug.Name, tr.Drug.DrugId.ToString()));
        rdcDrug.SelectedValue = tr.Drug.DrugId.ToString();

        // Load professional
        if (tr.Professional != null)
        {
            rdcProfessional.Items.Clear();
            rdcProfessional.Items.Add(new RadComboBoxItem(tr.Professional.FullName, tr.Professional.PersonId.ToString()));
            rdcProfessional.SelectedValue = tr.Professional.PersonId.ToString();
        }

        rdpTreatmentDate.SelectedDate = tr.TreatmentDate;
        txtRecommend.Text = tr.Recommend;
        if (tr.Quantity != 0)
            txtQuantity.Value = tr.Quantity;
    }

    protected void UnloadData(Treatment tr)
    {
        tr.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        tr.TreatmentDate = (DateTime)rdpTreatmentDate.SelectedDate;
        tr.Drug = CntAriCli.GetDrug(int.Parse(rdcDrug.SelectedValue), ctx);
        if (visit != null)
            tr.BaseVisit = visit;
        tr.Recommend = txtRecommend.Text;
        if (txtQuantity.Text != "") tr.Quantity = (int)txtQuantity.Value;
        if (rdcProfessional.SelectedValue != "")
        {
            tr.Professional = CntAriCli.GetProfessional(int.Parse(rdcProfessional.SelectedValue), ctx);
        }
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

    protected void rdcDrug_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from d in ctx.Drugs
                 where d.Name.StartsWith(e.Text)
                 select d;
        foreach (Drug dg in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dg.Name, dg.DrugId.ToString()));
        }
    }
    protected void rdcProfessional_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Professionals
                 where p.FullName.StartsWith(e.Text)
                 select p;
        foreach (Professional professional in rs)
        {
            combo.Items.Add(new RadComboBoxItem(professional.FullName, professional.PersonId.ToString()));
        }
    }

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        string js = String.Format("printPrescription({0});", treatment.TreatmentId);
        RadAjaxManager1.ResponseScripts.Add(js);
        RadAjaxManager1.ResponseScripts.Add("CloseAndRebind('');");
    }

    protected void LoadProfessionalCombo(Professional professional)
    {
        if (professional == null) return;
        rdcProfessional.Items.Clear();
        rdcProfessional.Items.Add(new RadComboBoxItem(professional.FullName, professional.PersonId.ToString()));
        rdcProfessional.SelectedValue = professional.PersonId.ToString();
    }
}
