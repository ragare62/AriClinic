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

public partial class EmailForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Clinic cl = null;
    Patient pat = null;
    Customer cus = null;
    Professional prof = null;
    int emailId = 0;
    int hcId = 0;
    int clinicId = 0;
    int patientId = 0;
    int customerId = 0;
    int professionalId = 0;
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
        }
        //
        if (Request.QueryString["HcId"] != null)
        {
            hcId = Int32.Parse(Request.QueryString["HcId"]);
            hc = CntAriCli.GetHealthCompany(ctx);
            txtCaller.Text = hc.Name;
        }
        //
        if (Request.QueryString["ClinicId"] != null)
        {
            clinicId = Int32.Parse(Request.QueryString["ClinicId"]);
            cl = (from c in ctx.Clinics
                  where c.ClinicId == clinicId
                  select c).FirstOrDefault<Clinic>();
            txtCaller.Text = cl.Name;
        }
        //
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = Int32.Parse(Request.QueryString["PatientId"]);
            pat = CntAriCli.GetPatient(patientId, ctx);
            txtCaller.Text = pat.FullName;
        }
        //
        if (Request.QueryString["CustomerId"] != null)
        {
            customerId = Int32.Parse(Request.QueryString["CustomerId"]);
            cus = CntAriCli.GetCustomer(customerId, ctx);
            txtCaller.Text = cus.FullName;
        }
        //
        if (Request.QueryString["ProfessionalId"] != null)
        {
            professionalId = Int32.Parse(Request.QueryString["ProfessionalId"]);
            prof = CntAriCli.GetProfessional(professionalId, ctx);
            txtCaller.Text = prof.FullName;
        }
        // 
        if (Request.QueryString["EmailId"] != null)
        {
            emailId = Int32.Parse(Request.QueryString["EmailId"]);
            Email eml = (from t in ctx.Emails
                         where t.EmailId == emailId
                         select t).FirstOrDefault<Email>();
            LoadData(eml);
        }
        else
        {
            LoadTypeCombo(null);
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
        if (!CreateChange())
            return;
        string command = "CloseAndRebind('email')";
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
        // check that there's almost one primary address
        string type = ddlType.SelectedValue;
        if (type != "Primary")
        {
            if (hc != null)
            {
                if (!PrimaryExists())
                {
                    lblMessage.Text = Resources.GeneralResource.PrimaryTypeNeeded;
                    return false;
                }
            }
        }
        else
        {
            if (PrimaryExists())
            {
                lblMessage.Text = Resources.GeneralResource.AlreadyPrimary;
                return false;
            }
        }
        return true;
    }

    private bool PrimaryExists()
    {
        Email eml = null;
        if (hc != null)
        {
            eml = (from t in ctx.Emails
                   where t.Type == "Primary"
                         && t.HealthcareCompany.HcId == hc.HcId
                   select t).FirstOrDefault<Email>();
        }
        if (cl != null)
        {
            eml = (from t in ctx.Emails
                   where t.Type == "Primary"
                         && t.Clinic.ClinicId == clinicId
                   select t).FirstOrDefault<Email>();
        }
        if (pat != null)
        {
            eml = (from t in ctx.Emails
                   where t.Type == "Primary"
                         && t.Person.PersonId == patientId
                   select t).FirstOrDefault<Email>();
        }
        if (cus != null)
        {
            eml = (from t in ctx.Emails
                   where t.Type == "Primary"
                         && t.Person.PersonId == customerId
                   select t).FirstOrDefault<Email>();
        }
        if (prof != null)
        {
            eml = (from t in ctx.Emails
                   where t.Type == "Primary"
                         && t.Person.PersonId == professionalId
                   select t).FirstOrDefault<Email>();
        }
        if (eml == null)
            return false;
        else
        {
            if (eml.EmailId == emailId) return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (emailId == 0)
        {
            Email eml = new Email();
            UnloadData(eml);
            ctx.Add(eml);
        }
        else
        {
            Email eml = (from t in ctx.Emails
                         where t.EmailId == emailId
                         select t).FirstOrDefault<Email>();
            UnloadData(eml);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Email eml)
    {
        txtEmailId.Text = eml.EmailId.ToString();
        txtUrl.Text = eml.Url;
        LoadTypeCombo(eml);
    }

    protected void UnloadData(Email eml)
    {
        eml.Url = txtUrl.Text;
        eml.Type = ddlType.SelectedValue;
        if (hc != null)
            eml.HealthcareCompany = hc;
        if (cl != null)
            eml.Clinic = cl;
        if (pat != null)
            eml.Person = pat;
        if (cus != null)
            eml.Person = cus;
        if (prof != null)
            eml.Person = prof;
    }

    protected void LoadTypeCombo(Email eml)
    {
        ddlType.Items.Clear(); // clear all previous options
        ddlType.Items.Add(new ListItem(Resources.ConstantsResource.Primary, "Primary"));
        ddlType.Items.Add(new ListItem(Resources.ConstantsResource.Secondary, "Secondary"));

        if (eml != null)
        {
            ddlType.SelectedValue = eml.Type;
        }
    }
    #endregion Auxiliary functions
}
