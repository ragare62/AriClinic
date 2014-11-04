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

public partial class MainMenu : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Clinic cl = null;

    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        String strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        lblDeveloper.Text = String.Format("VRS {0} TS {1}", strVersion,Session.Timeout);
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
        User u = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
        CheckPermissions(u.UserGroup, RadMenu1.Items);
        CheckPermissions(u.UserGroup, RadToolBar1);
        CheckProfile(u);
        SetSessionValues();
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
    
    #region Auxiliary functions
    protected void SetSessionValues()
    {
        // First check if a user is logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
        user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
        lblUser.Text = user.Name;

        // Clinic
        if (Session["Clinic"] != null)
        {
            cl =CntAriCli.GetClinic((Session["Clinic"] as Clinic).ClinicId, ctx);
            lblUser.Text = String.Format("{0} ({1})", user.Name, cl.Name);
        }

        // Assign general skin
        if (Session["Skin"] != null)
            RadSkinManager1.Skin = (string)Session["Skin"];

        // Show company and user values
        if (Session["Company"] != null)
        {
            hc = CntAriCli.GetHealthCompany(ctx);
            lblHealthcareCompany.Text = hc.Name;
        }
    }
    protected void Launcher(string process)
    {
        switch (process)
        {
            case "exit":
                Response.Redirect("Default.aspx");
                break;
            case "parameter":
                RadAjaxManager1.ResponseScripts.Add("LaunchParameter();");
                break;
            case "helcom":
                HealthcareCompany hc = CntAriCli.GetHealthCompany(ctx);
                RadAjaxManager1.ResponseScripts.Add(String.Format("LaunchHc({0});", hc.HcId));
                break;
            case "usergroup":
                RadAjaxManager1.ResponseScripts.Add("LaunchUserGroup();");
                break;
            case "user":
                RadAjaxManager1.ResponseScripts.Add("LaunchUser();");
                break;
            case "process":
                RadAjaxManager1.ResponseScripts.Add("LaunchProcess();");
                break;
            case "permission":
                RadAjaxManager1.ResponseScripts.Add("LaunchPermission();");
                break;
            case "clinic":
                RadAjaxManager1.ResponseScripts.Add("LaunchClinic();");
                break;
            case "scat":
                RadAjaxManager1.ResponseScripts.Add("LaunchServiceCategory();");
                break;
            case "taxt":
                RadAjaxManager1.ResponseScripts.Add("LaunchTaxType();");
                break;
            case "taxwt":
                RadAjaxManager1.ResponseScripts.Add("LaunchTaxWithholdingType();");
                break;
            case "ser":
                RadAjaxManager1.ResponseScripts.Add("LaunchService();");
                break;
            case "ins":
                RadAjaxManager1.ResponseScripts.Add("LaunchInsurance();");
                break;
            case "paymentmethod":
                RadAjaxManager1.ResponseScripts.Add("LaunchPaymentMethod();");
                break;
            case "patient":
                RadAjaxManager1.ResponseScripts.Add("LaunchPatient();");
                break;
            case "customer":
                RadAjaxManager1.ResponseScripts.Add("LaunchCustomer();");
                break;
            case "professional":
                RadAjaxManager1.ResponseScripts.Add("LaunchProfessional();");
                break;
            case "ticket":
                RadAjaxManager1.ResponseScripts.Add("LaunchTicket();");
                break;
            case "asn":
                RadAjaxManager1.ResponseScripts.Add("LaunchAnestheticServiceNote();");
                break;
            case "servicenote":
                RadAjaxManager1.ResponseScripts.Add("LaunchServiceNote();");
                break;
            case "invoice":
                RadAjaxManager1.ResponseScripts.Add("LaunchInvoice();");
                break;
            case "payment":
                RadAjaxManager1.ResponseScripts.Add("LaunchPayment();");
                break;
            case "procedure":
                RadAjaxManager1.ResponseScripts.Add("LaunchProcedure();");
                break;
            case "settlement":
                RadAjaxManager1.ResponseScripts.Add("LaunchSettlement();");
                break;
            case "checks":
                RadAjaxManager1.ResponseScripts.Add("LaunchChecks();");
                break;
            case "rtickets":
                RadAjaxManager1.ResponseScripts.Add("LaunchRTickets();");
                break;
            case "rpayments":
                RadAjaxManager1.ResponseScripts.Add("LaunchRPayments();");
                break;
            case "rprofessionalsrv":
                RadAjaxManager1.ResponseScripts.Add("LaunchRProfessionalSrv();");
                break;
            case "rsurgeonsrv":
                RadAjaxManager1.ResponseScripts.Add("LaunchRSurgeonSrv();");
                break;
            case "rcategorysrv":
                RadAjaxManager1.ResponseScripts.Add("LaunchRCategorySrv();");
                break;
            case "rsrvcomparer":
                RadAjaxManager1.ResponseScripts.Add("LaunchRComparerPrices();");
                break;
            case "rnomenclator":
                RadAjaxManager1.ResponseScripts.Add("Launchrnomenclator();");
                break;
            case "rinvoicesPeriod":
                RadAjaxManager1.ResponseScripts.Add("LaunchRInvoicesPeriod();");
                break;
            case "rpatientdebt":
                RadAjaxManager1.ResponseScripts.Add("LaunchRPatientDebt();");
                break;
            case "rinsurancedebt":
                RadAjaxManager1.ResponseScripts.Add("LaunchRInsuranceDebt();");
                break;
            case "agenda":
                RadAjaxManager1.ResponseScripts.Add("LaunchAgenda();");
                break;
            case "apptype":
                RadAjaxManager1.ResponseScripts.Add("LaunchAppointmentType();");
                break;
            case "appointment":
                RadAjaxManager1.ResponseScripts.Add("LaunchAppointment();");
                break;
            case "docs":
                RadAjaxManager1.ResponseScripts.Add("LaunchDocuments();");
                break;
            case "diagnostic":
                RadAjaxManager1.ResponseScripts.Add("LaunchDiagnostic();");
                break;
            case "diagnosticassigned":
                RadAjaxManager1.ResponseScripts.Add("LaunchDiagnosticAssigned();");
                break;
            case "drug":
                RadAjaxManager1.ResponseScripts.Add("LaunchDrug();");
                break;
            case "treatment":
                RadAjaxManager1.ResponseScripts.Add("LaunchTreatment();");
                break;
            case "examination":
                RadAjaxManager1.ResponseScripts.Add("LaunchExamination();");
                break;
            case "examinationassigned":
                RadAjaxManager1.ResponseScripts.Add("LaunchExaminationAssigned();");
                break;
            case "unittype":
                RadAjaxManager1.ResponseScripts.Add("LaunchUnitType();");
                break;
            case "profInvoice":
                RadAjaxManager1.ResponseScripts.Add("LaunchProfiIvoice();");
                break;
            case "profInvoices":
                RadAjaxManager1.ResponseScripts.Add("LaunchProfInvoices();");
                break;
            case "rbombasPCEA":
                RadAjaxManager1.ResponseScripts.Add("LaunchbombasPCEA();");
                break;
            case "labtest":
                RadAjaxManager1.ResponseScripts.Add("LaunchLabTest();");
                break;
            case "labtestassigned":
                RadAjaxManager1.ResponseScripts.Add("LaunchLabTestAssigned();");
                break;
            case "procedureassigned":
                RadAjaxManager1.ResponseScripts.Add("LaunchProcedureAssigned();");
                break;
            case "visitreason":
                RadAjaxManager1.ResponseScripts.Add("LaunchVisitReason();");
                break;
            case "visit":
                RadAjaxManager1.ResponseScripts.Add("LaunchVisit();");
                break;
            case "source":
                RadAjaxManager1.ResponseScripts.Add("LaunchSource();");
                break;
            case "rticketprofessional":
                RadAjaxManager1.ResponseScripts.Add("LaunchRTicketProfessional();");
                break;
            case "ranestckprof":
                RadAjaxManager1.ResponseScripts.Add("LaunchRAnesTckProf();");
                break;
            case "rpca":
                RadAjaxManager1.ResponseScripts.Add("LaunchRPCA();");
                break;
            case "rtcksrg":
                RadAjaxManager1.ResponseScripts.Add("LaunchRTckSrg();");
                break;
            case "rrisk":
                RadAjaxManager1.ResponseScripts.Add("LaunchRrisk();");
                break;
            case "rappointmentday":
                RadAjaxManager1.ResponseScripts.Add("LaunchRAppointmentDay();");
                break;
            case "rptgpbyclinic":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptGPByClinic();");
                break;
            case "rptinvoicemain":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptInvoiceMain();");
                break;
            case "rptvatresume":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptVATResume();");
                break;
            case "rptvatresumecli":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptVATResumeCli();");
                break;
            case "rptvatresumecat":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptVATResumeCat();");
                break;
            case "rptpatientbysource":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptPatientBySource();");
                break;
            case "rptvisitbyreason":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptVisitByReason();");
                break;
            case "templategrid":
                RadAjaxManager1.ResponseScripts.Add("LaunchTemplate();");
                break;
            case "logaccess":
                RadAjaxManager1.ResponseScripts.Add("LaunchLogAccess();");
                break;
            case "campaign":
                RadAjaxManager1.ResponseScripts.Add("LaunchCampaign();");
                break;
            case "channel":
                RadAjaxManager1.ResponseScripts.Add("LaunchChannel();");
                break;
            case "request":
                RadAjaxManager1.ResponseScripts.Add("LaunchRequest();");
                break;
            case "estimate":
                RadAjaxManager1.ResponseScripts.Add("LaunchEstimate();");
                break;
            case "servicesubcategory":
                RadAjaxManager1.ResponseScripts.Add("LaunchServiceSubCategory();");
                break;
            case "amendmentinvoice":
                RadAjaxManager1.ResponseScripts.Add("LaunchAmendmentInvoice();");
                break;
            case "rptpricelist":
                RadAjaxManager1.ResponseScripts.Add("LaunchRptPriceList();");
                break;
            case "smsges":
                RadAjaxManager1.ResponseScripts.Add("LaunchSmsGes();");
                break;
            default:
                break;
        }

    }
    #endregion Auxiliary functions

    #region Clic events
    protected void RadMenu1_ItemClick(object sender, RadMenuEventArgs e)
    {
        Launcher(e.Item.Value);
    }
    protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        Launcher(e.Item.Value);

    }
    #endregion

    #region Permissions
    protected void CheckPermissions(UserGroup ug, RadMenuItemCollection col)
    {
        foreach (RadMenuItem i in col)
        {
            Process pr = (from p in ctx.Processes
                          where p.Code == i.Value
                          select p).FirstOrDefault<Process>();

            if (pr != null)
            {
                Permission per = CntAriCli.GetPermission(ug, pr, ctx);
                if (per != null)
                {
                    if (!per.View) i.Visible = false;
                }
                else i.Visible = false; // If no permission not show
            }
            else i.Visible = false; // If doesn't exits not show

            // recursive call if there are submenus or items in it
            if (i.Items.Count > 0)
                CheckPermissions(ug, i.Items);
        }
    }
    protected void CheckProfile(User usu)
    {
        RadToolBar1.Visible = false;
        switch (usu.Profile)
        {
            case 0:
                RadMenu1.Items[0].Visible = true;
                RadToolBar1.Visible = true;
                break;
            case 1:
                RadMenu1.Items[1].Visible = false;
                RadMenu1.Items[3].Visible = false;
                break;
            case 2:
                RadMenu1.Items[4].Visible = false;
                break;
            case 3:
                RadMenu1.Items[0].Visible = true;
                RadToolBar1.Visible = true;
                break;
        }
    }
    protected void CheckPermissions(UserGroup ug, RadToolBar rdt)
    {
        foreach (RadToolBarItem i in rdt.Items)
        {
            Process pr = (from p in ctx.Processes
                          where p.Code == i.Value
                          select p).FirstOrDefault<Process>();

            if (pr != null)
            {
                Permission per = CntAriCli.GetPermission(ug, pr, ctx);
                if (per != null)
                {
                    if (!per.View) i.Visible = false;
                }
                else i.Visible = false; // If no permission not show
            }
            else i.Visible = false; // If doesn't exits not show
        }
    }
    #endregion


   

}
