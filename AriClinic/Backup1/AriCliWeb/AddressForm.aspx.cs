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

public partial class AddressForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Clinic cl = null;
    Patient pat = null;
    Customer cus = null;
    Professional prof = null;
    int addressId = 0;
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
        if (Request.QueryString["AddressId"] != null)
        {
            addressId = Int32.Parse(Request.QueryString["AddressId"]);
            Address adr = (from a in ctx.Addresses
                           where a.AddressId == addressId
                           select a).FirstOrDefault<Address>();
            LoadData(adr);
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
        string command = "CloseAndRebind('address')";
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
        Address adr = null;
        if (cl != null)
        {
            adr = (from a in ctx.Addresses
                   where a.Type == "Primary"
                         && a.Clinic.ClinicId == clinicId
                   select a).FirstOrDefault<Address>();
        }
        if (hc != null)
        {
            adr = (from a in ctx.Addresses
                   where a.Type == "Primary"
                         && a.HealthcareCompany.HcId == hcId
                   select a).FirstOrDefault<Address>();
        }
        if (pat != null)
        {
            adr = (from a in ctx.Addresses
                   where a.Type == "Primary"
                         && a.Person.PersonId == patientId
                   select a).FirstOrDefault<Address>();
        }
        if (cus != null)
        {
            adr = (from a in ctx.Addresses
                   where a.Type == "Primary"
                         && a.Person.PersonId == customerId
                   select a).FirstOrDefault<Address>();
        }
        if (prof != null)
        {
            adr = (from a in ctx.Addresses
                   where a.Type == "Primary"
                         && a.Person.PersonId == professionalId
                   select a).FirstOrDefault<Address>();
        } 
        if (adr == null)
            return false;
        else
        {
            if (adr.AddressId == addressId) return false;
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (addressId == 0)
        {
            Address adr = new Address();
            UnloadData(adr);
            ctx.Add(adr);
        }
        else
        {
            Address adr = (from a in ctx.Addresses
                           where a.AddressId == addressId
                           select a).FirstOrDefault<Address>();
            UnloadData(adr);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(Address adr)
    {
        txtAddressId.Text = adr.AddressId.ToString();
        txtStreet.Text = adr.Street;
        txtStreet2.Text = adr.Street2;
        txtPostCode.Text = adr.PostCode;
        txtCity.Text = adr.City;
        txtProvince.Text = adr.Province;
        txtCountry.Text = adr.Country;
        LoadTypeCombo(adr);
    }

    protected void UnloadData(Address adr)
    {
        adr.Street = txtStreet.Text;
        adr.Street2 = txtStreet2.Text;
        adr.PostCode = txtPostCode.Text;
        adr.City = txtCity.Text;
        adr.Province = txtProvince.Text;
        adr.Country = txtCountry.Text;
        adr.Type = ddlType.SelectedValue;
        if (hc != null)
            adr.HealthcareCompany = hc;
        if (cl != null)
            adr.Clinic = cl;
        if (pat != null)
            adr.Person = pat;
        if (cus != null)
            adr.Person = cus;
        if (prof != null)
            adr.Person = prof;
    }

    protected void LoadTypeCombo(Address adr)
    {
        ddlType.Items.Clear(); // clear all previous options
        ddlType.Items.Add(new ListItem(Resources.ConstantsResource.Primary, "Primary"));
        ddlType.Items.Add(new ListItem(Resources.ConstantsResource.Secondary, "Secondary"));

        if (adr != null)
        {
            ddlType.SelectedValue = adr.Type;
        }
    }
    #endregion Auxiliary functions
}
