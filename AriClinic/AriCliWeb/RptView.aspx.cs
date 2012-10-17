using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using AriCliModel;
using AriCliReport;
using AriCliWeb;
using Telerik.Web.UI;
using AriCliWeb;

public partial class RptView : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    DateTime fDate = DateTime.Now;
    DateTime tDate = DateTime.Now;
    Diary diary = null;
    BaseVisit visit = null;
    Treatment treatment = null;
    Invoice invoice = null;
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
        if (Request.QueryString["FDate"] != null)
            fDate = CntWeb.ParseUrlDate(Request.QueryString["FDate"]);
        if (Request.QueryString["TDate"] != null)
            tDate = CntWeb.ParseUrlDate(Request.QueryString["TDate"]);
        if (Request.QueryString["Diary"] != null)
            diary = CntAriCli.GetDiary(int.Parse(Request.QueryString["Diary"]),ctx);
        if (Request.QueryString["Visit"] != null)
            visit = CntAriCli.GetVisit(int.Parse(Request.QueryString["Visit"]), ctx);
        if (Request.QueryString["Treatment"] != null)
            treatment = CntAriCli.GetTreatment(int.Parse(Request.QueryString["Treatment"]), ctx);
        if (Request.QueryString["Invoice"] != null)
            invoice = CntAriCli.GetInvoice(int.Parse(Request.QueryString["Invoice"]), ctx);
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
                    case "surgeonsrv":
                        LoadSurgeonSrv();
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
                        this.Title = "Deudas de pacientes";
                        RptDebtByCustomer rptdbp = new RptDebtByCustomer();
                        ReportViewer1.Report = rptdbp;
                        break;
                    case "insurdebt":
                        LoadInsuranceDebt();
                        break;
                    case "paraminvoice":
                        LoadParamInvoice();
                        break;
                    case "professionalinvoice":
                        LoadProfessionalInvoice();
                        break;
                    case "professionalinvoices":
                        LoadProfessionalInvoices();
                        break;
                    case "bombasPCEA":
                        LoadRptBombasPCEA();
                        break;
                    case "rticketprofessional":
                        this.Title = "Tiques generales por profesional";
                        RptTicketsByProfessional rtprf = new RptTicketsByProfessional();
                        ReportViewer1.Report = rtprf;
                        break;
                    case "ranestckprof":
                        this.Title = "Tiques anestésicos por profesional";
                        ReptAnesTicketProfessional rtanesprf = new ReptAnesTicketProfessional();
                        ReportViewer1.Report = rtanesprf;
                        break;
                    case "rpca":
                        this.Title = "Informe de bombas PCEA";
                        RptPCA rpca = new RptPCA();
                        ReportViewer1.Report = rpca;
                        break;
                    case "rtcksrg":
                        this.Title = "Tiques anestésicos por cirujano";
                        RptTicketsSurgeon rtcksrg = new RptTicketsSurgeon();
                        ReportViewer1.Report = rtcksrg;
                        break;
                    case "rrisk":
                        this.Title = "Tiques con alto riesgo";
                        RptRisk rrisk = new RptRisk();
                        ReportViewer1.Report = rrisk;
                        break;
                    case "rappointmentday":
                        this.Title = "Citas diarias por agenda";
                        RptDayAppointment rdap = new RptDayAppointment();
                        rdap.ReportParameters["SDate"].Value = fDate;
                        if (diary != null)
                        {
                            rdap.ReportParameters["Diary"].MultiValue = false;
                            rdap.ReportParameters["Diary"].Value = diary.DiaryId;
                        }
                        ReportViewer1.Report = rdap;
                        break;
                    case "prescription":
                        this.Title = "Recetas";
                        RptPrescription rpres = new RptPrescription();
                        if (treatment != null)
                        {
                            rpres.ReportParameters["Treatment"].Visible = false;
                            rpres.ReportParameters["Treatment"].MultiValue = false;
                            rpres.ReportParameters["Treatment"].Value = treatment.TreatmentId;
                        }
                        if (visit != null)
                        {
                            IList<int> ltrt = new List<int>();
                            foreach (Treatment t in visit.Treatments)
                            {
                                ltrt.Add(t.TreatmentId);
                            }
                            rpres.ReportParameters["Treatment"].Visible = false;
                            rpres.ReportParameters["Treatment"].MultiValue = true;
                            rpres.ReportParameters["Treatment"].Value = ltrt;
                        }
                        ReportViewer1.Report = rpres;
                        break;
                    case "rptgpbyclinic":
                        this.Title = "Cobros generales por clínica";
                        RptGPByClinic rpt = new RptGPByClinic();
                        rpt.ReportParameters["FDate"].Value = DateTime.Now;
                        rpt.ReportParameters["TDate"].Value = DateTime.Now;
                        ReportViewer1.Report = rpt;
                        break;
                    case "rptinvoicemain":
                        this.Title = "Impresión de facturas de cliente";
                        RptInvoiceMain rptimain = new RptInvoiceMain();
                        if (invoice != null)
                        {
                            rptimain.ReportParameters["InvoiceKey"].MultiValue = false;
                            rptimain.ReportParameters["InvoiceKey"].Value = invoice.InvoiceId;
                        }
                        ReportViewer1.Report = rptimain;
                        break;
                    case "rptvatresume":
                        this.Title = "Liquidación de IVA por periodo";
                        RptVATResume rptvr = new RptVATResume();
                        ReportViewer1.Report = rptvr;
                        break;
                    case "rptpatientbysource":
                        this.Title = "Pacientes por procedencia";
                        RptPatientBySource rptpbs = new RptPatientBySource();
                        ReportViewer1.Report = rptpbs;
                        break;
                }
            }
            catch (Exception ex)
            {
                //lblMessage.Text = ex.Message;
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
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
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
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
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
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);
        string professional = Request.QueryString["Professional"];

        RptServProfessional rtck = new RptServProfessional(fromDate, toDate, professional, ctx);
        ReportViewer1.Report = rtck;
    }

    protected void LoadSurgeonSrv()
    {
        // search parameters
        if (Request.QueryString["FromDate"] == null
            || Request.QueryString["ToDate"] == null)
        {
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);
        string professional = Request.QueryString["Professional"];

        RptServSurgeon rtck = new RptServSurgeon(fromDate, toDate, professional, ctx);
        ReportViewer1.Report = rtck;
    }

    protected void LoadCategorySrv()
    {
        // search parameters
        if (Request.QueryString["FromDate"] == null
            || Request.QueryString["ToDate"] == null)
        {
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
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

    protected void LoadProfessionalInvoice()
    {
        if (Request.QueryString["Invoice"] != null)
        {
            RptProfessionalInvoice rtck = new RptProfessionalInvoice(int.Parse(Request.QueryString["Invoice"]), ctx);
            ReportViewer1.Report = rtck;
        }
    }

    protected void LoadProfessionalInvoices()
    {
        if (Request.QueryString["FromDate"] == null
            || Request.QueryString["ToDate"] == null)
        {
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);
        string professional = Request.QueryString["Professional"];

        RptProfessionalInvoices rtck = new RptProfessionalInvoices(fromDate, toDate, professional, ctx);
        ReportViewer1.Report = rtck;
        
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
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
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
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
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
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);

        //RptParamInvoices rtsc = new RptParamInvoices(fromDate, toDate, ctx);
        RptParamTickets rtsc = new RptParamTickets(fromDate, toDate, ctx);
        ReportViewer1.Report = rtsc;
    }

    private void LoadRptBombasPCEA()
    {
        if (Request.QueryString["FromDate"] == null
           || Request.QueryString["ToDate"] == null)
        {
            //lblMessage.Text = Resources.GeneralResource.ParameterError;
            return;
        }
        DateTime fromDate = DateTime.Parse(Request.QueryString["FromDate"]);
        DateTime toDate = DateTime.Parse(Request.QueryString["ToDate"]);

        RptBombaDolor rtsc = new RptBombaDolor(fromDate, toDate, ctx);
        ReportViewer1.Report = rtsc;
    }
    #endregion
}
