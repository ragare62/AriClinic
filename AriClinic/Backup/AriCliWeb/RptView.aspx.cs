using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using AriCliReport;
using Telerik.Web.UI;
using AriCliWeb;

public partial class RptView : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    string report = "";
    Permission per = null;

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
            Process proc = (from p in ctx.Processes
                            where p.Code == "rtickets"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Report"] != null)
            report = Request.QueryString["Report"];
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                switch (report)
                {
                    case "tickets":
                        LoadTickets("A");
                        break;
                    case "ticketspaid":
                        LoadTickets("P");
                        break;
                    case "ticketsnopaid":
                        LoadTickets("NP");
                        break;
                    case "payments":
                        LoadPayments();
                        break;
                    case "professionalsrv":
                        LoadProfessionalSrv();
                        break;
                    case "categorysrv":
                        LoadCategorySrv();
                        break;
                    case "ticket":
                        LoadTicket();
                        break;
                    case "servicenote":
                        LoadServiceNote();
                        break;
                    case "anesthesicnote":
                        LoadAnesthesicNote();
                        break;
                    case"invoice":
                        LoadInvoice();
                        break;
                    case "compprices":
                        LoadSrvComparer();
                        break;
                    case "nomenclator":
                        Loadnomenclator();
                        break;
                    case "invoicePeriod":  
                        LoadInvoicePeriod();
                        break;
                    case "patientinvoice":  
                        LoadPatientInvoice();
                        break;
                    case "patdebt":
                        LoadPatientDebt();
                        break;
                    case "insurdebt":
                        LoadInsuranceDebt();
                        break;
                    case "paraminvoice":
                        LoadParamInvoice();
                        break;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events

    #region Report loaders
    protected void LoadTickets(string type)
    {
        int noVoucher = 0;
        if (Request.QueryString["Voucher"] != null)
            noVoucher = int.Parse(Request.QueryString["Voucher"]);

        // search parameters
        if (Request.QueryString["FromDate"] == null 
            || Request.QueryString["ToDate"] == null 
            || Request.QueryString["InsuranceId"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);
        int insuranceId = Int32.Parse(Request.QueryString["InsuranceId"]);
        switch (type)
        {
            case "A":
                RptTickets rtck = new RptTickets(fromDate, toDate, insuranceId, ctx, noVoucher);
                ReportViewer1.Report = rtck;
                break;
            case "P":
                RptTicketsPaid rtckp = new RptTicketsPaid(fromDate, toDate, insuranceId, ctx);
                ReportViewer1.Report = rtckp;
                break;
            case "NP":
                RptTicketsNoPaid rtcknp = new RptTicketsNoPaid(fromDate, toDate, insuranceId, ctx);
                ReportViewer1.Report = rtcknp;
                break;
        }
    }

    protected void LoadPayments()
    {
        // search parameters
        if (Request.QueryString["FromDate"] == null
            || Request.QueryString["ToDate"] == null
            || Request.QueryString["ClinicId"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);
        int clinicId = Int32.Parse(Request.QueryString["ClinicId"]);
        RptPayments rtck = new RptPayments(fromDate, toDate, clinicId, ctx);
        ReportViewer1.Report = rtck;
    }

    protected void LoadProfessionalSrv()
    {
        // search parameters
        if (Request.QueryString["FromDate"] == null
            || Request.QueryString["ToDate"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);
        string professional = Request.QueryString["Professional"];

        RptServProfessional rtck = new RptServProfessional(fromDate, toDate, professional, ctx);
        ReportViewer1.Report = rtck;
    }

    protected void LoadCategorySrv()
    {
        // search parameters
        if (Request.QueryString["FromDate"] == null
            || Request.QueryString["ToDate"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);

        RptServCategory rtck = new RptServCategory(fromDate, toDate, ctx);
        ReportViewer1.Report = rtck;
    }

    protected void LoadTicket()
    {
        if (Request.QueryString["idTicket"] != null)
        {
            RptTicket rtck = new RptTicket(int.Parse(Request.QueryString["idTicket"]), ctx);
            ReportViewer1.Report = rtck;
        }
    }

    protected void LoadServiceNote()
    {
        if (Request.QueryString["idServNote"] != null)
        {
            RptServNote rtck = new RptServNote(int.Parse(Request.QueryString["idServNote"]), ctx);
            ReportViewer1.Report = rtck;
        }
    }

    protected void LoadAnesthesicNote()
    {
        if (Request.QueryString["idAnesNote"] != null)
        {
            RptAnesNote rtck = new RptAnesNote(int.Parse(Request.QueryString["idAnesNote"]), ctx);
            ReportViewer1.Report = rtck;
        }
    }

    protected void LoadInvoice()
    {
        if (Request.QueryString["Invoice"] != null)
        {
            RptInvoice rtck = new RptInvoice(int.Parse(Request.QueryString["Invoice"]), ctx);
            ReportViewer1.Report = rtck;
        }
    }

    private void Loadnomenclator()
    {
        RptNomenclator rtsc = new RptNomenclator(ctx);
        ReportViewer1.Report = rtsc;
    }

    private void LoadSrvComparer()
    {
        RptServicesComparer rtsc = new RptServicesComparer(ctx);
        ReportViewer1.Report = rtsc;
    }

    private void LoadInvoicePeriod()
    {
        if (Request.QueryString["FromDate"] == null
           || Request.QueryString["ToDate"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);

        RptInvoicesPeriod rtck = new RptInvoicesPeriod(fromDate, toDate, ctx);
        ReportViewer1.Report = rtck;
    }

    private void LoadPatientInvoice()
    {
        if (Request.QueryString["ToDate"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);

        RptPatientInvoice rtck = new RptPatientInvoice(toDate, ctx);
        ReportViewer1.Report = rtck;
    }
    
    private void LoadPatientDebt()
    {
        RptPatientDebt rtsc = new RptPatientDebt(ctx);
        ReportViewer1.Report = rtsc;
    }

    private void LoadInsuranceDebt()
    {
        RptInsuranceDebt rtsc = new RptInsuranceDebt(ctx);
        ReportViewer1.Report = rtsc;
    }

    private void LoadParamInvoice()
    {
        if (Request.QueryString["FromDate"] == null
           || Request.QueryString["ToDate"] == null)
        {
            lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);

        //RptParamInvoices rtsc = new RptParamInvoices(fromDate, toDate, ctx);
        RptParamTickets rtsc = new RptParamTickets(fromDate, toDate, ctx);
        ReportViewer1.Report = rtsc;
    }
    #endregion
}
