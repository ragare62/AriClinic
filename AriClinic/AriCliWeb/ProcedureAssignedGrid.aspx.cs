using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Web.UI.HtmlControls;

public partial class ProcedureAssignedGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    string type = "";
    Permission per = null;
    ProcedureAssigned labTestAssigned = null;
    int labTestAssignedId = 0;
    Patient patient = null;
    int patientId = 0;
    BaseVisit visit = null;
    int visitId = 0;

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
                            where p.Code == "procedureassigned"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // check if grid is call from a tab 
        if (type == "InTab")
        {
            HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
            tt.Attributes["class"] = "ghost";
            // hide patient column
            RadGrid1.Columns.FindByDataField("Patient.FullName").Visible = false;
        }
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = int.Parse(Request.QueryString["PatientId"]);
            patient = CntAriCli.GetPatient(patientId, ctx);
        }
        if (Request.QueryString["VisitId"] != null)
        {
            visitId = int.Parse(Request.QueryString["VisitId"]);
            visit = CntAriCli.GetVisit(visitId, ctx);
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
        RefreshGrid(false);
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            ImageButton imgb = (ImageButton)e.Item.FindControl("New");
            imgb.Visible = per.Create;
            if (patient != null)
                imgb.OnClientClick = "NewProcedureAssignedRecordInTab();";
            if (visit != null)
                imgb.OnClientClick = "NewProcedureAssignedRecordInVisit();";
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
            name = gdi["Patient.FullName"].Text + ": " + gdi["Procedure.Name"].Text;
            command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');"
                                    , id.ToString()
                                    , null
                                    , name
                                    , null
                                    , "Procedure");
            imgb.OnClientClick = command;
            if (type != "S") imgb.Visible = false; // not called from another form

            // assign javascript function to edit button
            imgb = (ImageButton)e.Item.FindControl("Edit");
            command = String.Format("return EditProcedureAssignedRecord({0});", id);
            if (patient != null)
                command = String.Format("return EditProcedureAssignedRecordInTab({0});", id);
            if (visit != null)
                command = String.Format("return EditProcedureAssignedRecordInVisit({0});", id);
            imgb.OnClientClick = command;

            // assigning javascript functions to delete button
            imgb = (ImageButton)e.Item.FindControl("Delete");
            string message = Resources.GeneralResource.DeleteRecordQuestion;
            message = String.Format("{0}<br/>{1}", message, name);
            command = String.Format("ariDialog('Procedureos asignados','{0}','prompt',null,0,0)", message);
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
            string command = "";
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
                    Session["DeleteId"] = id;
                    string message = Resources.GeneralResource.DeleteRecordQuestion;
                    GridDataItem gdi = (GridDataItem)e.Item;
                    message = String.Format("{0}<br/>{1}: {2}", message, gdi["Patient.FullName"].Text, gdi["Procedure.Name"].Text);
                    command = String.Format("ariDialog('Servicios','{0}','prompt',null,0,0)", message);
                    RadAjaxManager1.ResponseScripts.Add(command);
                    break;
            }
        }
    }

    #endregion Grid treatment

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshGrid(true);
        if (e.Argument == "new")
        {
            RadGrid1.CurrentPageIndex = RadGrid1.PageCount - 1;
            RadGrid1.Rebind();
        }
        if (e.Argument == "yes")
        {
            if (Session["DeleteId"] != null)
            {
                try
                {
                    labTestAssignedId = (int)Session["DeleteId"];
                    labTestAssigned = (from da in ctx.ProcedureAssigneds
                                          where da.ProcedureAssignedId == labTestAssignedId
                                          select da).FirstOrDefault<ProcedureAssigned>();
                    ctx.Delete(labTestAssigned);
                    ctx.SaveChanges();
                    RefreshGrid(true);
                    Session["DeleteId"] = null;
                }
                catch (Exception ex)
                {
                    Session["Exception"] = ex;
                    string command = String.Format("showDialog('Error','{0}','error',null, 0, 0)"
                                                   , Resources.GeneralResource.DeleteRecordFail);
                    RadAjaxManager1.ResponseScripts.Add(command);
                }
            }
        }
    }

    protected void RefreshGrid(bool rebind)
    {
        if (patient == null)
            RadGrid1.DataSource = CntAriCli.GetProcedureAssigneds(ctx);
        else
            RadGrid1.DataSource = patient.ProcedureAssigneds;
        if (rebind)
            RadGrid1.Rebind();
    }
}