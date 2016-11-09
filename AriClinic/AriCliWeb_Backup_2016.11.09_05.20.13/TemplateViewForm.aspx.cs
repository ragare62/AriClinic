using System;
using AriCliModel;
using AriCliReport;
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

public partial class TemplateViewForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Template template= null;
    int templateId = 0;
    Permission per = null;
    AriCliModel.Parameter parameter = null;
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
                            where p.Code == "templategrid"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["TemplateId"] != null)
        {
            templateId = Int32.Parse(Request.QueryString["TemplateId"]);
            template = CntAriCli.GetTemplate(templateId, ctx);
            LoadData(template);
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
        if (template != null)
        {
            Patient patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
            Professional professional = CntAriCli.GetProfessional(int.Parse(rdcProfessional.SelectedValue), ctx);
            IList<TemplateView> ltpw = new List<TemplateView>();
            TemplateView tpvw = new TemplateView();
            tpvw.Name = template.Name;
            string patientName = "";
            if (patient != null)
            {
                patientName = String.Format("{0} {1}, {2}", patient.Surname1, patient.Surname2, patient.Name);
            }
            string professionalName = "";
            if (professional != null)
            {
                professionalName = professional.FullName;
            }
            tpvw.Content = String.Format(template.Content, patientName, professionalName, txtCampo1.Text, txtCampo2.Text,txtCampo3.Text);
            ltpw.Add(tpvw);
            RptTemplate rpt = new RptTemplate(ltpw);
            ReportViewer1.Report = rpt;
        }
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
        return true;
    }

    protected void LoadData(Template template)
    {
        lblTitle.Text = template.Name;
    }
    protected void UnloadData(Template template)
    {
    }
    #endregion Auxiliary functions

    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
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

    protected void rdcProfessional_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "")
            return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from p in ctx.Professionals
                 where p.ComercialName.StartsWith(e.Text)
                 select p;
        foreach (Professional professional in rs)
        {
            if (!professional.Inactive)
                combo.Items.Add(new RadComboBoxItem(professional.ComercialName, professional.PersonId.ToString()));
        }
    }

    #region Searching outside

    #endregion

}
