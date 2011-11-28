using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Web.UI.HtmlControls;

public partial class VisitTab : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    BaseVisit visit = null;
    int visitId = 0;
    Patient patient = null;
    int patientId = 0;
    string type = "";
    Permission per = null;
    HtmlControl frame = null;
    
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
                            where p.Code == "visit"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // read patient information
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
        }
        if (Request.QueryString["VisitId"] != null)
        {
            visitId = Int32.Parse(Request.QueryString["VisitId"]);
            visit = CntAriCli.GetVisit(visitId, ctx);
            patient = visit.Patient;
            patientId = patient.PersonId;
            string title = String.Format("{0} ({1:dd/MM/yyyy}) {2}",
                visit.VisitReason.Name,
                visit.VisitDate,
                visit.Patient.FullName);
            lblTitle.Text = title;
            this.Title = title;
        }
        else
        {
            lblTitle.Text = "Nueva visita";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            frame = (HtmlControl)this.FindControl("FrmArea");
            string url = "";
            if (visit == null)
            {
                url = String.Format("VisitForm.aspx?Type=InTab");
                if (patient != null) url = String.Format("VisitForm.aspx?Type=InTab&PatientId={0}",patientId);
                // make invisible tabs that aren't the general one
                for (int i = 1; i<=5;i++)
                {
                    RadTabStrip1.Tabs[i].Visible = false;
                }
                
            }
            else
            {
                url = String.Format("VisitForm.aspx?VisitId={0}&Type=InTab", visit.VisitId);
            }
            frame.Attributes["src"] = url;
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events

    #region Tab events
    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        if (visit == null) return;

        frame = (HtmlControl)this.FindControl("FrmArea");
        switch (e.Tab.Value)
        {
            case "general":
                frame.Attributes["src"] = String.Format("VisitForm.aspx?VisitId={0}&Type=InTab",visit.VisitId);
                break;
            case "diagnosticassigned":
                frame.Attributes["src"] = String.Format("DiagnosticAssignedGrid.aspx?VisitId={0}&Type=InTab" , visit.VisitId);
                break;
            case "treatment":
                frame.Attributes["src"] = String.Format("TreatmentGrid.aspx?VisitId={0}&Type=InTab" , visit.VisitId);
                break;
            case "examination":
                frame.Attributes["src"] = String.Format("ExaminationAssignedGrid.aspx?VisitId={0}&Type=InTab" , visit.VisitId);
                break;
            case "labtestassigned":
                frame.Attributes["src"] = String.Format("LabTestAssignedGrid.aspx?VisitId={0}&Type=InTab" , visit.VisitId);
                break;
            case "procedureassigned":
                frame.Attributes["src"] = String.Format("ProcedureAssignedGrid.aspx?VisitId={0}&Type=InTab", visit.VisitId);
                break;
        }
    }
    #endregion
}