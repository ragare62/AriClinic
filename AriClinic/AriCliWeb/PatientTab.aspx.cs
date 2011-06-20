using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Web.UI.HtmlControls;

public partial class PatientTab : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Patient pat = null;
    Customer cus = null;
    int patientId = 0;
    int customerId = 0;
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
                            where p.Code == "scat"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // read patient information
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = Int32.Parse(Request.QueryString["PatientId"]);
            pat = CntAriCli.GetPatient(patientId, ctx);
            cus = pat.Customer;
            customerId = cus.PersonId;
            lblTitle.Text = String.Format("Historial: {0}", pat.FullName);
            this.Title = String.Format("Historial: {0}", pat.FullName);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            frame = (HtmlControl)this.FindControl("FrmArea");
            frame.Attributes["src"] = String.Format("PatientForm.aspx?PatientId={0}&Type=InTab", pat.PersonId);
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
        frame = (HtmlControl)this.FindControl("FrmArea");
        switch (e.Tab.Value)
        {
            case "patient":
                frame.Attributes["src"] = String.Format("PatientForm.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "policy":
                frame.Attributes["src"] = String.Format("PolicyGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "ticket":
                frame.Attributes["src"] = String.Format("TicketGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "servnote":
                frame.Attributes["src"] = String.Format("ServiceNoteGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "anesnote":
                frame.Attributes["src"] = String.Format("AnestheticServiceNoteGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "invoice":
                frame.Attributes["src"] = String.Format("InvoiceGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "payment":
                frame.Attributes["src"] = String.Format("PaymentGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "appointment":
                frame.Attributes["src"] = String.Format("AppointmentGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "docs":
                frame.Attributes["src"] = String.Format("DocumentsPatient.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "diagnosticassigned":
                frame.Attributes["src"] = String.Format("DiagnosticAssignedGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
            case "treatment":
                frame.Attributes["src"] = String.Format("TreatmentGrid.aspx?PatientId={0}&Type=InTab&CustomerId=" + customerId
                                                        , pat.PersonId);
                break;
        }
    }
    #endregion
}