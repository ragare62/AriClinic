using System;
using AriCliModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class PatientForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Patient pat = null;
    Customer cus = null;
    int hcID = 0;
    int patientId = 0;
    Permission per = null;
    string type = "";
    bool withRequests = false;

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
            Process proc = (from p in ctx.Processes
                            where p.Code == "patient"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = Int32.Parse(Request.QueryString["PatientId"]);
            pat = CntAriCli.GetPatient(patientId, ctx);
            LoadData(pat);
        }
        else
        {
            LoadSexCombo(null);
            LoadSourceCombo(null);
            LoadClinicCombo(null);
            txtFrn.Text = String.Format("{0:0}", CntAriCli.NextFrn(ctx));
            rdtOpenDate.SelectedDate = DateTime.Now;
        }
        // 
        if (Request.QueryString["Type"] != null)
        {
            type = Request.QueryString["Type"];
            if (type == "InTab")
            {
                HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
                tt.Attributes["class"] = "ghost";
                tt = (HtmlControl)this.FindControl("Buttons0");
                tt.Attributes["class"] = "buttonsFomat0";
                btnCancel.Visible = false;
                btnCancel0.Visible = false;
                btnAccept0.Visible = true; btnAccept0.Enabled = true;
            }
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
        bool nuevo = false;
        if (pat == null)
        {
            command = "CloseAndRebind('new')";
            nuevo = true;
        }
        else
        {
            command = "CloseAndRebind('')";
        }
        if (!CreateChange())
            return;
        if (type == "InTab")
        {
            RadAjaxManager1.Alert(Resources.GeneralResource.RecordRefreshed);
            return;
        }
        if (nuevo)
        {
            command = String.Format("PatientRecord({0});", pat.PersonId);
        }
        if (!withRequests)
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
        if (rdcbSex.SelectedValue == "")
        {
            RadAjaxManager1.Alert(Resources.GeneralResource.SexValueNeeded);
            return false;
        }
        if (rdcbClinic.SelectedValue == "")
        {
            RadAjaxManager1.Alert(Resources.GeneralResource.ClinicNeeded);
            return false;
        }
        //if (rddpBornDate.SelectedDate == null) 
        //{
        //    lblMessage.Text = Resources.GeneralResource.BornDateNeeded;
        //    return false;
        //}
        return true;
    }

    /// <summary>
    /// As its name suggest if there isn't an object
    /// it'll create it. It exists modify it.
    /// </summary>
    /// <returns></returns>
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (patientId == 0)
        {
            pat = new Patient();
            UnloadData(pat);
            ctx.Add(pat);
        }
        else
        {
            pat = CntAriCli.GetPatient(patientId, ctx);
            UnloadData(pat);
        }
        ctx.SaveChanges();
        // control possible request
        IList<Request> lr = CntAriCli.GetPossibleAssociateRequest(pat, ctx);
        if (lr.Count() > 0)
        {
            withRequests = true;
            Session["Requests"] = lr;
            Session["Patient"] = pat;
            string mes = String.Format("Hay {0} solicitudes no asociadas que podrían ser de este paciente. ¿Desea asociarlas?", lr.Count());
            RadWindowManager1.RadConfirm(mes, "associateRequest", null, null, null, "SOLICITUDES");
        }
        return true;
    }

    protected void LoadData(Patient pat)
    {
        txtPatientId.Text = pat.PersonId.ToString();
        txtName.Text = pat.Name;
        txtSurname1.Text = pat.Surname1;
        txtSurname2.Text = pat.Surname2;
        if (String.Format("{0:dd/MM/yy}",pat.BornDate) != "01/01/01")
            rddpBornDate.SelectedDate = pat.BornDate;
        txtAge.Text = CntAriCli.CalulatedAge(pat.BornDate).ToString();
        txtLastUpdate.Text = CntAriCli.DateNullFormat(pat.LastUpdate);
        LoadSexCombo(pat);
        LoadSourceCombo(pat);
        LoadClinicCombo(pat);
        txtComments.Text = pat.Comments;
        if (pat.Customer != null)
            txtVATIN.Text = pat.Customer.VATIN;
        txtFrn.Text = String.Format("{0:0}", pat.OftId);
        txtInsuranceInformation.Text = pat.InsuranceInformation;
        if (!CntAriCli.OaDateNull(pat.OpenDate))
            rdtOpenDate.SelectedDate = pat.OpenDate;
        
    }

    protected void UnloadData(Patient pat)
    {
        pat.Name = txtName.Text;
        pat.Surname1 = txtSurname1.Text;
        pat.Surname2 = txtSurname2.Text;
        pat.FullName = String.Format("{0} {1}, {2}", pat.Surname1, pat.Surname2, pat.Name);
        pat.Sex = rdcbSex.SelectedValue;
        if (rdcbProcedencia.SelectedValue != "")
            pat.Source = CntAriCli.GetSource(int.Parse(rdcbProcedencia.SelectedValue), ctx);
        if (rdcbClinic.SelectedValue != "")
            pat.Clinic = CntAriCli.GetClinic(int.Parse(rdcbClinic.SelectedValue), ctx);
        if (rddpBornDate.SelectedDate != null)
            pat.BornDate = (DateTime)rddpBornDate.SelectedDate;
        if (pat.Customer == null) 
        {
            CreateAssociatedCustomer(pat, ctx);
        }
        pat.InsuranceInformation = CntAriCli.GetInsuranceInformation(pat, ctx);
        txtInsuranceInformation.Text = pat.InsuranceInformation;
        pat.Customer.VATIN = txtVATIN.Text;
        pat.Comments = txtComments.Text;
        CntAriCli.UpdateCustomerRelatedData(pat, ctx);
        pat.OftId = int.Parse(txtFrn.Text);
        if (rdtOpenDate.SelectedDate != null)
            pat.OpenDate = (DateTime)rdtOpenDate.SelectedDate;
        //pat.LastUpdate = DateTime.Now;
    }

    protected void LoadSexCombo(Patient pat)
    {
        rdcbSex.Items.Clear();
        rdcbSex.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.Man, "M"));
        rdcbSex.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.Woman, "W"));
        rdcbSex.Items.Add(new RadComboBoxItem(Resources.ConstantsResource.Indeterminated, "I"));
        if (pat == null)
        {
            rdcbSex.Items.Add(new RadComboBoxItem(" ", ""));
            rdcbSex.SelectedValue = "";
        }
        else
        {
            rdcbSex.SelectedValue = pat.Sex;
        }
    }
    protected void LoadSourceCombo(Patient pat) 
    {
        rdcbProcedencia.Items.Clear();
        foreach (Source cl in CntAriCli.GetSources(ctx))
        {
            rdcbProcedencia.Items.Add(new RadComboBoxItem(cl.Name, cl.SourceId.ToString()));
        }
        rdcbProcedencia.Items.Add(new RadComboBoxItem(" ", ""));
        rdcbProcedencia.SelectedValue = "";
        if (pat != null && pat.Source != null)
        {
            rdcbProcedencia.SelectedValue = pat.Source.SourceId.ToString();
        }
    }

    protected void LoadClinicCombo(Patient pat)
    {
        rdcbClinic.Items.Clear();
        foreach (Clinic cl in CntAriCli.GetClinics(ctx))
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(cl.Name, cl.ClinicId.ToString()));
        }
        rdcbClinic.Items.Add(new RadComboBoxItem(" ", ""));
        rdcbClinic.SelectedValue = "";
        if (pat != null && pat.Clinic != null)
        {
            rdcbClinic.SelectedValue = pat.Clinic.ClinicId.ToString();
        }
    }

    protected void CreateAssociatedCustomer(Patient pat, AriClinicContext ctx)
    {
        Customer cus = new Customer()
        {
            FullName = pat.FullName,
        };
        ctx.Add(cus);
        pat.Customer = cus;
        CntAriCli.CheckPolicy(pat, ctx);
    }


    #endregion Auxiliary functions

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "address":
                UscAddressGrid1.RefreshGrid(true);
                break;
            case "telephone":
                UscTelephoneGrid1.RefreshGrid(true);
                break;
            case "email":
                UscEmailGrid1.RefreshGrid(true);
                break;
            case "request":
                IList<Request> lr = (IList<Request>)Session["Requests"];
                pat = (Patient)Session["Patient"];
                CntAriCli.SetRequestAssociation(pat, lr, ctx);
                Session["Requests"] = null;
                Session["Patient"] = null;
                string command = String.Format("PatientRecord({0});", pat.PersonId);
                RadAjaxManager1.ResponseScripts.Add(command);
                break;
        }
    }

    protected void btnAccept0_Click(object sender, ImageClickEventArgs e)
    {
        string command = "";
        bool nuevo = false;
        if (pat == null)
        {
            command = "CloseAndRebind('new')";
            nuevo = true;
        }
        else
        {
            command = "CloseAndRebind('')";
        }
        if (!CreateChange())
            return;
        if (type == "InTab")
        {
            RadAjaxManager1.Alert(Resources.GeneralResource.RecordRefreshed);
            return;
        }
        if (nuevo)
        {
            command = String.Format("PatientRecord({0});", pat.PersonId);
        }
        if (!withRequests)
            RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void rddpBornDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        // Calculated age when born date is introduced
        if (rddpBornDate.SelectedDate != null)
        {
            DateTime bornDate = (DateTime)rddpBornDate.SelectedDate;
            txtAge.Text = CntAriCli.CalulatedAge(bornDate).ToString();
        }

    }

}
