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
                            where p.Code == "LabTest"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
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
        // check combo values
        if (txtName.Text == "")
        {
            command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
                ,Resources.GeneralResource.Warning
                ,Resources.GeneralResource.NameNeeded);
            RadAjaxManager1.ResponseScripts.Add(command);
            return false;
        }
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
    protected void LoadData(AriCliModel.LabTest LabTest)
    {
        txtLabTestId.Text = LabTest.LabTestId.ToString();
        txtName.Text = LabTest.Name;
        if (labTest.UnitType != null)
        {
            AriCliModel.UnitType unitType = labTest.UnitType;
            rdcUnitType.Items.Clear();
            rdcUnitType.Items.Add(new RadComboBoxItem(unitType.Name, unitType.UnitTypeId.ToString()));
            rdcUnitType.SelectedValue = unitType.UnitTypeId.ToString();
        }
        txtMinValue.Text = labTest.MinValue.ToString();
        txtMaxValue.Text = labTest.MaxValue.ToString();
        
    }
    protected void UnloadData(AriCliModel.LabTest LabTest)
    {
        LabTest.Name = txtName.Text;
        if (rdcUnitType.SelectedValue != "")
            labTest.UnitType = CntAriCli.GetUnitType(int.Parse(rdcUnitType.SelectedValue),ctx);
        if (txtMinValue.Text != "") labTest.MinValue = Decimal.Parse(txtMinValue.Text);
        if (txtMaxValue.Text != "") labTest.MaxValue = Decimal.Parse(txtMaxValue.Text);
    }
    #endregion Auxiliary functions

    protected void rdcUnitType_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from c in ctx.UnitTypes
                 where c.Name.StartsWith(e.Text)
                 select c;
        foreach (AriCliModel.UnitType ut in rs)
            combo.Items.Add(new RadComboBoxItem(ut.Name, ut.UnitTypeId.ToString()));
    }

    protected void rdcUnitType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
    }



}
