using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;

public partial class RequestGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    string type = "";
    Permission per = null;
    Patient patient = null;
    int patientId = 0;

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
                            where p.Code == "channel"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
        }
        // translate filters
        CntWeb.TranslateRadGridFilters(RadGrid1);
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
    
    #region Grid treatment
        
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        // load grid data
        LoadWithStatus(rdcStatusType.SelectedValue);
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
            
            // assign javascript function to select button
            imgb = (ImageButton)e.Item.FindControl("Select");
            gdi = (GridDataItem)e.Item;
            name = gdi["RequestDateTime"].Text + "(" + gdi["Patient.FullName"].Text + gdi["FullName"].Text + ")";
            command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');",
                id.ToString(),
                null,
                name,
                null,
                "Clinic");
            imgb.OnClientClick = command;
            if (type != "S")
                imgb.Visible = false; // not called from another form
            
            // assign javascript function to edit button
            imgb = (ImageButton)e.Item.FindControl("Edit");
            command = String.Format("return EditRequestRecord({0});", id);
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
                    Request chn = (from c in ctx.Requests
                                   where c.RequestId == id
                                   select c).FirstOrDefault<Request>();
                    CntAriCli.DeleteRequest(chn, ctx);
                    RefreshGrid();
                    break;
            }
        }
    }
    
    #endregion Grid treatment
        
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshGrid();
    }
        
    protected void RefreshGrid()
    {
        LoadWithStatus(rdcStatusType.SelectedValue);
        RadGrid1.Rebind();
    }

    protected void LoadWithStatus(string status)
    {
        if (status == "TODAS")
        {
            if (patient != null)
            {
                RadGrid1.DataSource = ctx.Requests.OrderByDescending(x => x.RequestDateTime).Where(x => x.Patient.PersonId == patient.PersonId);
            }
            else
            {
                RadGrid1.DataSource = ctx.Requests.OrderByDescending(x => x.RequestDateTime);
            }
        }
        else
        {
            if (patient != null)
            {
                RadGrid1.DataSource = CntAriCli.GetRequestsByStatus(status, ctx).Where(x => x.Patient.PersonId == patient.PersonId);
            }
            else
            {
                RadGrid1.DataSource = CntAriCli.GetRequestsByStatus(status, ctx);
            }
        }
    }

    protected void rdcStatusType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        LoadWithStatus(rdcStatusType.SelectedValue);
        RadGrid1.Rebind();
    }
}