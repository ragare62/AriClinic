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

public partial class LabTestForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    LabTest labTest = null;
    int labTestId = 0;
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
                            where p.Code == "labtest"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        LoadGeneralTypeCombo();
        LoadUnitTypeCombo();
        if (Request.QueryString["LabTestId"] != null)
        {
            labTestId = Int32.Parse(Request.QueryString["LabTestId"]);
            labTest = CntAriCli.GetLabTest(labTestId, ctx);
            LoadData(labTest);
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
        if (!Page.IsValid) return;
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
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (labTest == null)
        {
            labTest = new AriCliModel.LabTest();
            UnloadData(labTest);
            ctx.Add(labTest);
        }
        else
        {
            labTest = CntAriCli.GetLabTest(labTestId, ctx);
            UnloadData(labTest);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(LabTest labTest)
    {
        txtLabTestId.Text = labTest.LabTestId.ToString();
        txtName.Text = labTest.Name;
        rdcGeneralType.SelectedValue = labTest.GeneralType;
        if (labTest.UnitType != null)
            rdcUnitType.SelectedValue = labTest.UnitType.UnitTypeId.ToString();
        else
            rdcUnitType.SelectedValue = "";
        if (labTest.GeneralType == "LBTN")
        {
            txtMinValue.Value = (double)labTest.MinValue;
            txtMaxValue.Value = (double)labTest.MaxValue;
        }
    }
    protected void UnloadData(LabTest labTest)
    {
        labTest.Name = txtName.Text;
        labTest.GeneralType = rdcGeneralType.SelectedValue;
        if (rdcUnitType.SelectedValue != "")
        {
            labTest.UnitType = CntAriCli.GetUnitType(int.Parse(rdcUnitType.SelectedValue),ctx);
        }
        if (labTest.GeneralType == "LBTN")
        {
            labTest.MinValue= (decimal)txtMinValue.Value;
            labTest.MaxValue = (decimal)txtMaxValue.Value;
        }
    }
    #endregion Auxiliary functions

    protected void valMinValue_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (rdcGeneralType.SelectedValue == "LBTA")
        {
            args.IsValid = true;
        }
        else
        {
            if (txtMinValue.Text == "") args.IsValid = false;
        }
    }
    protected void valMaxValue_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (rdcGeneralType.SelectedValue == "LBTA")
        {
            args.IsValid = true;
        }
        else
        {
            if (txtMaxValue.Text == "") args.IsValid = false;
        }
    }
    protected void LoadGeneralTypeCombo()
    {
        rdcGeneralType.Items.Clear();
        rdcGeneralType.Items.Add(new RadComboBoxItem(Resources.GeneralResource.LBTA,"LBTA"));
        rdcGeneralType.Items.Add(new RadComboBoxItem(Resources.GeneralResource.LBTN, "LBTN"));
        rdcGeneralType.SelectedValue = "LBTN"; // numeric by default.
    }
    protected void LoadUnitTypeCombo()
    {
        rdcUnitType.Items.Clear();
        foreach (AriCliModel.UnitType utype in ctx.UnitTypes)
        {
            rdcUnitType.Items.Add(new RadComboBoxItem(utype.Name, utype.UnitTypeId.ToString()));
        }
        rdcUnitType.Items.Add(new RadComboBoxItem("", ""));
    }


}
