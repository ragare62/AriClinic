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

public partial class LabTestAssignedForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    LabTest labTest = null;
    LabTestAssigned labTestAssigned = null;
    Patient patient = null;
    int labTestId = 0;
    int labTestcAssignedId = 0;
    int patientId = 0;

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
            user = CntAriCli.GetUser(user.UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "labtestassigned"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["LabTestAssignedId"] != null)
        {
            labTestcAssignedId = Int32.Parse(Request.QueryString["LabTestAssignedId"]);
            labTestAssigned = CntAriCli.GetLabTestAssigned(labTestcAssignedId, ctx);
            LoadData(labTestAssigned);
        }
        else
        {
            rdpLabTestDate.SelectedDate = DateTime.Now;
        }
        //
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
            // fix rdc with patient
            rdcPatient.Items.Clear();
            rdcPatient.Items.Add(new RadComboBoxItem(patient.FullName,patient.PersonId.ToString()));
            rdcPatient.SelectedValue = patient.PersonId.ToString();
            rdcPatient.Enabled = false;
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
        if (labTest == null)
            command = "CloseAndRebind('new')";
        else
            command = "CloseAndRebind('')";
        if (!CreateChange())
            return;
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
        string command = "";
        if (rdpLabTestDate.SelectedDate == null)
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.DateNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcLabTest.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.LabTestNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (rdcPatient.SelectedValue == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.PatientNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        if (txtValue.Text == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                                    , Resources.GeneralResource.Warning
                                    , Resources.GeneralResource.ValueNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
        // 
        labTest = CntAriCli.GetLabTest(int.Parse(rdcLabTest.SelectedValue), ctx);
        if (labTest.GeneralType == "LBTN")
        {
            decimal v;
            if (!Decimal.TryParse(txtValue.Text, out v))
            {
                command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                        , Resources.GeneralResource.Warning
                        , Resources.GeneralResource.NumericNeeded);
                RadAjaxManager1.ResponseScripts.Add(command);
                return false;
            }
        }
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (labTestAssigned == null)
        {
            labTestAssigned = new LabTestAssigned();
            UnloadData(labTestAssigned);
            ctx.Add(labTestAssigned);
        }
        else
        {
            labTest = CntAriCli.GetLabTest(labTestId, ctx);
            UnloadData(labTestAssigned);
        }
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(LabTestAssigned lta)
    {
        // Load patient data
        rdcPatient.Items.Clear();
        rdcPatient.Items.Add(new RadComboBoxItem(lta.Patient.FullName, lta.Patient.PersonId.ToString()));
        rdcPatient.SelectedValue = lta.Patient.PersonId.ToString();

        // Load diagnostic data
        rdcLabTest.Items.Clear();
        rdcLabTest.Items.Add(new RadComboBoxItem(lta.LabTest.Name, lta.LabTest.LabTestId.ToString()));
        rdcLabTest.SelectedValue = lta.LabTest.LabTestId.ToString();

        rdpLabTestDate.SelectedDate = lta.LabTestDate;
        if (lta.LabTest.GeneralType == "LBTN")
        {
            txtValue.Text = lta.NumValue.ToString();
        }
        else 
        {
            txtValue.Text = lta.StringValue;
        }
        txtComments.Text = lta.Comments;
    }

    protected void UnloadData(LabTestAssigned lta)
    {
        lta.Patient = CntAriCli.GetPatient(int.Parse(rdcPatient.SelectedValue), ctx);
        lta.LabTestDate = (DateTime)rdpLabTestDate.SelectedDate;
        lta.LabTest = CntAriCli.GetLabTest(int.Parse(rdcLabTest.SelectedValue), ctx);
        if (lta.LabTest.GeneralType == "LBTN")
        {
            lta.NumValue = decimal.Parse(txtValue.Text);
        }
        else
        {
            lta.StringValue = txtValue.Text;
        }
        lta.Comments = txtComments.Text;
    }

    #endregion Auxiliary functions

    protected void rdcPatient_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
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

    protected void rdcLabTest_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from d in ctx.LabTests
                 where d.Name.StartsWith(e.Text)
                 select d;
        foreach (LabTest dia in rs)
        {
            combo.Items.Add(new RadComboBoxItem(dia.Name, dia.LabTestId.ToString()));
        }
    }
}
