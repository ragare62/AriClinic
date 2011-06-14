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

public partial class TelephoneForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Clinic cl = null;
    Patient pat = null;
    Customer cus = null;
    Professional prof = null;
    int telephoneId = 0;
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
            user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
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
        if (Request.QueryString["TelephoneId"] != null)
        {
            telephoneId = Int32.Parse(Request.QueryString["TelephoneId"]);
            Telephone tel = (from t in ctx.Telephones
                             where t.TelephoneId == telephoneId
                             select t).FirstOrDefault<Telephone>();
            LoadData(tel);
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
        string command = "CloseAndRebind('telephone')";
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
        Telephone tel = null;
        if (hc != null)
        {
            tel = (from t in ctx.Telephones
                   where t.Type == "Primary"
                         && t.HealthcareCompany.HcId == hc.HcId
                   select t).FirstOrDefault<Telephone>();
        }
        if (cl != null)
        {
            tel = (from t in ctx.Telephones
                   where t.Type == "Primary"
                         && t.Clinic.ClinicId == clinicId
                   select t).FirstOrDefault<Telephone>();
        }
        if (pat != null)
        {
            tel = (from t in ctx.Telephones
                   where t.Type == "Primary"
                         && t.Person.PersonId == patientId
                   select t).FirstOrDefault<Telephone>();
        }
        if (cus != null)
        {
            tel = (from t in ctx.Telephones
                   where t.Type == "Primary"
                         && t.Person.PersonId == customerId
                   select t).FirstOrDefault<Telephone>();
        }
        if (prof != null)
        {
            tel = (from t in ctx.Telephones
                   where t.Type == "Primary"
                         && t.Person.PersonId == professionalId
                   select t).FirstOrDefault<Telephone>();
        }
        if (tel == null)
            return false;
        else
        {
            if (tel.TelephoneId == telephoneId) return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (telephoneId == 0)
        {
            Telephone tel = new Telephone();
            UnloadData(tel);
            ctx.Add(tel);
        }
        else
        {
            Telephone tel = (from t in ctx.Telephones
                             where t.TelephoneId == telephoneId
                             select t).FirstOrDefault<Telephone>();
            UnloadData(tel);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Telephone tel)
    {
        txtTelephoneId.Text = tel.TelephoneId.ToString();
        txtNumber.Text = tel.Number;
        LoadTypeCombo(tel);
    }

    protected void UnloadData(Telephone tel)
    {
        tel.Number = txtNumber.Text;
        tel.Type = ddlType.SelectedValue;
        if (hc != null)
            tel.HealthcareCompany = hc;
        if (cl != null)
            tel.Clinic = cl;
        if (pat != null)
            tel.Person = pat;
        if (cus != null)
            tel.Person = cus;
        if (prof != null)
            tel.Person = prof;
    }

    protected void LoadTypeCombo(Telephone tel)
    {
        ddlType.Items.Clear(); // clear all previous options
        ddlType.Items.Add(new ListItem(Resources.ConstantsResource.Primary, "Primary"));
        ddlType.Items.Add(new ListItem(Resources.ConstantsResource.Secondary, "Secondary"));

        if (tel != null)
        {
            ddlType.SelectedValue = tel.Type;
        }
    }
    #endregion Auxiliary functions
}
