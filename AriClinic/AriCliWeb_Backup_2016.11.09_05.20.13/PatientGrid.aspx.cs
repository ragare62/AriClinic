using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Drawing;

public partial class PatientGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    string type = "";
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
                            where p.Code == "patient"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // translate filters
        CntWeb.TranslateRadGridFilters(RadGrid1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) LoadInsuranceCombo();
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events
    #region Grid treatment
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        // load grid data
        RadGrid1.DataSource = CntAriCli.GetPatients(ctx);
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            ImageButton imgb = (ImageButton)e.Item.FindControl("New");
            imgb.Visible = per.Create;
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string name = "";
            string command = "";
            GridDataItem gdi;
            int id = 0;
            
            id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            Patient patient = CntAriCli.GetPatient(id, ctx);
            gdi = (GridDataItem)e.Item;

            // modifying column content.
            System.Web.UI.Control control = gdi["INS"].FindControl("lblInsuranceData");
            Label lb = (Label)control;
            lb.Text = CntAriCli.GetInsuranceData(patient, ctx);

            // assign javascript function to select button
            imgb = (ImageButton)e.Item.FindControl("Select");
            name = gdi["FullName"].Text;
            command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');"
                                    , id.ToString()
                                    , null
                                    , name
                                    , null
                                    , "Patient");
            imgb.OnClientClick = command;
            if (type != "S") imgb.Visible = false; // not called from another form

            // assign javascript function to edit button
            imgb = (ImageButton)e.Item.FindControl("Edit");
            command = String.Format("return EditPatientRecord({0});", id);
            imgb.OnClientClick = command;

            // assign javascript to view administrative historial
            imgb = (ImageButton)e.Item.FindControl("HisAdm");
            command = String.Format("return ViewHisAdm({0});", id);
            imgb.OnClientClick = command;

            // assigning javascript functions to delete button
            imgb = (ImageButton)e.Item.FindControl("Delete");
            command = String.Format("return confirm('{0} {1}');", Resources.GeneralResource.DeleteRecordQuestion, name);
            imgb.OnClientClick = command;
            imgb.Visible = per.Create;
        }
    }

    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // weonly process commands with a datasource (our image buttons)
        if (e.CommandSource == null)
            return;
        string typeOfControl = e.CommandSource.GetType().ToString();
        if (typeOfControl.Equals("System.Web.UI.WebControls.ImageButton"))
        {
            int id = 0;
            ImageButton imgb = (ImageButton)e.CommandSource;
            if (imgb.ID != "New" && imgb.ID != "Exit")
                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            switch (imgb.ID)
            {
                case "Select":
                    break;
                case "Edit":
                    break;
                case "Delete":
                    Patient pat = CntAriCli.GetPatient(id, ctx);
                    CntAriCli.DeletePatient(pat, ctx);
                    RefreshGrid();
                    break;
            }
        }
    }
    protected void RefreshGrid()
    {
        RadGrid1.DataSource = CntAriCli.GetPatients(ctx);
        RadGrid1.Rebind();
    }
    #endregion Grid treatment

    #region AJAX
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshGrid();
        if (e.Argument == "new") 
        { 
            RadGrid1.CurrentPageIndex = RadGrid1.PageCount - 1;
            RadGrid1.Rebind();
        }
    }
    #endregion 

    #region Insurance filter
    protected void LoadInsuranceCombo()
    {
        rdcInsurance.Items.Clear();
        rdcInsurance.Items.Add(new RadComboBoxItem("All", ""));
        foreach (Insurance ins in ctx.Insurances.OrderBy(x => x.Name))
        {
            rdcInsurance.Items.Add(new RadComboBoxItem(ins.Name, ins.InsuranceId.ToString()));
        }
        rdcInsurance.SelectedValue = "";
    }
    #endregion 

    protected void rdcInsurance_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value == "")
        {
            RadGrid1.DataSource = CntAriCli.GetPatients(ctx);
        }
        else
        {
            Insurance insurance = CntAriCli.GetInsurance(int.Parse(e.Value), ctx);
            if (insurance != null)
            {
                RadGrid1.DataSource = CntAriCli.GetPatients(insurance, ctx);
            }
        }
        RadGrid1.Rebind();
    }

}
