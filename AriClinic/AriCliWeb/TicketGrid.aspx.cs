using AriCliModel;
using AriCliWeb;
using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class TicketGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Patient pat = null;
    bool notPaid = false;
    Ticket tck = null;
    Customer cus = null;
    AnestheticServiceNote asn = null;
    ServiceNote sn = null;
    int ticketId = 0;
    int patientId = 0;
    int customerId = 0;
    int anestheticServiceNoteId = 0;
    int serviceNoteId = 0;
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
            user = (User)Session["User"];
            Process proc = (from p in ctx.Processes
                            where p.Code == "policy"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // read the realated patient
        if (Request.QueryString["PatientId"] != null)
        {
            patientId = Int32.Parse(Request.QueryString["PatientId"]);
            pat = CntAriCli.GetPatient(patientId, ctx);
            cus = pat.Customer;
        }
        // read passed customer if any
        if (Request.QueryString["CustomerId"] != null)
        {
            customerId = Int32.Parse(Request.QueryString["CustomerId"]);
            cus = CntAriCli.GetCustomer(customerId, ctx);
        }
        //
        if (Request.QueryString["NotPaid"] != null)
        {
            notPaid = true;
        }
        // 
        if (type == "InTab")
        {
            HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
            tt.Attributes["class"] = "ghost";
            // hide patient column
            RadGrid1.Columns.FindByDataField("Policy.Customer.FullName").Visible = false;
        }
        else
        {
            //
            RadGrid1.PageSize = 6;
        }
        if (Request.QueryString["AnestheticServiceNoteId"] != null)
        {
            anestheticServiceNoteId = Int32.Parse(Request.QueryString["AnestheticServiceNoteId"]);
            asn = CntAriCli.GetAnestheticServiceNote(anestheticServiceNoteId, ctx);
            HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
            tt.Attributes["class"] = "ghost";
            // here the fields that must be hidden
            RadGrid1.Columns.FindByDataField("TicketDate").Visible = false;
            RadGrid1.Columns.FindByDataField("Policy.Customer.FullName").Visible = false;
            RadGrid1.Columns.FindByDataField("Checked").Visible = false;
            RadGrid1.Columns.FindByDataField("Clinic.Name").Visible = false;
        }
        if (Request.QueryString["ServiceNoteId"] != null)
        {
            serviceNoteId = int.Parse(Request.QueryString["ServiceNoteId"]);
            sn = CntAriCli.GetServiceNote(serviceNoteId, ctx);
            HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
            tt.Attributes["class"] = "ghost";
            // here the fields that must be hidden
            RadGrid1.Columns.FindByDataField("TicketDate").Visible = false;
            RadGrid1.Columns.FindByDataField("Policy.Customer.FullName").Visible = false;
            RadGrid1.Columns.FindByDataField("Checked").Visible = false;
            RadGrid1.Columns.FindByDataField("Clinic.Name").Visible = false;
        }
        // translate filters
        CntWeb.TranslateRadGridFilters(RadGrid1);
        //
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
        // RadGrid1.DataSource = asn.Procedures;
        // load grid data
        RefreshGrid(false, chkPaid.Checked);
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            // There's a 3 types of call so far.
            // cus != null (call from a customer / patient tab)
            // asn != null (call from an Anesthetic serice note)
            // sn != null (call from a General service note)
            ImageButton imgb = (ImageButton)e.Item.FindControl("New");
            imgb.Visible = per.Create;
            if (cus != null)
                imgb.OnClientClick = "NewTicketRecordInTab();";
            if (sn != null)
                imgb.OnClientClick = String.Format("NewTicketRecordServiceNote({0})", sn.ServiceNoteId);
            if (asn != null) imgb.Visible = false;
            imgb = (ImageButton)e.Item.FindControl("NewAnesthetic");
            imgb.Visible = per.Create;
            if (cus != null)
                imgb.OnClientClick = "NewAnestheticTicketRecordInTab();"; // customer id implicit
            if (asn != null)
                imgb.OnClientClick = String.Format("NewAnestheticTicketRecordServiceNote({0})", asn.AnestheticServiceNoteId);
            if (sn != null)
                imgb.Visible = false;
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
            // payed?
            Ticket t = CntAriCli.GetTicket(id, ctx);
            if (t.Checked) gdi.BackColor = Color.LightGreen;
            // backgroud color for primary types
            //if (gdi["Checked"].Text == "True")
            //{
            //    //gdi["Policy.Insurance.Name"].BackColor = Color.LightGreen;
            //    gdi.BackColor = Color.LightGreen;
            //}
            name = String.Format("{0} ({1}: {2})"
                                 , gdi["Policy.Customer.FullName"].Text
                                 , gdi["Description"].Text
                                 , gdi["Amount"].Text);
            command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');"
                                    , id.ToString()
                                    , gdi["Amount"].Text.Replace("€", "")
                                    , name
                                    , null
                                    , "Ticket");
            imgb.OnClientClick = command;
            if (type != "S") imgb.Visible = false; // not called from another form
            
            // pay button
            imgb = (ImageButton)e.Item.FindControl("Pay");
            command = String.Format("OpenPaymentForm({0});", id);
            imgb.OnClientClick = command;

            // print button
            imgb = (ImageButton)e.Item.FindControl("Print");
            command = String.Format("reportTicket({0});", id);
            imgb.OnClientClick = command;

            imgb = (ImageButton)e.Item.FindControl("Delete");
            imgb.Visible = per.Create;
        }
    }

    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        string command = "";
        // weonly process commands with a datasource (our image buttons)
        if (e.CommandSource == null)
            return;
        string typeOfControl = e.CommandSource.GetType().ToString();
        if (typeOfControl.Equals("System.Web.UI.WebControls.ImageButton"))
        {
            int id = 0;
            ImageButton imgb = (ImageButton)e.CommandSource;
            if (imgb.ID != "New" && imgb.ID != "Exit" && imgb.ID != "NewAnesthetic")
                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            switch (imgb.ID)
            {
                case "Select":
                    break;
                case "Edit":
                    // new tratement (now there's more that one ticket's kind)
                    tck = CntAriCli.GetTicket(id, ctx);
                    if (tck.GetType() == typeof(AnestheticTicket))
                    {
                        if (cus == null)
                        {
                            if (asn == null)
                                command = String.Format("EditAnestheticTicketRecord({0})", id); // general ticket grid
                            else
                            // asn have only anesthetic tickets 
                                command = String.Format("EditAnestheticTicketRecordServiceNote({0},{1})"
                                                        , asn.AnestheticServiceNoteId
                                                        , id);
                        }
                        else
                            command = String.Format("EditAnestheticTicketRecordInTab({0})", id); // inside tabstrip
                    }
                    else
                    {
                        // normal ticket
                        if (cus == null)
                        {
                            if (sn == null)
                                command = String.Format("EditTicketRecord({0})", id); // general ticket grid
                            else
                                command = String.Format("EditTicketRecordServiceNote({0},{1})"
                                                        , sn.ServiceNoteId
                                                        , id);
                        }
                        else
                            command = String.Format("EditTicketRecordInTab({0})", id); // inside tabstrip
                    }
                    RadAjaxManager1.ResponseScripts.Add(command);
                    break;
                case "Delete":
                    Session["DeleteId"] = id;
                    string message = Resources.GeneralResource.DeleteRecordQuestion;
                    GridDataItem gdi = (GridDataItem)e.Item;
                    message = String.Format("{0}<br/>{1}: {2}", message, gdi["Description"].Text, gdi["Amount"].Text);
                    command = String.Format("ariDialog('{0}','{1}','prompt',null,0,0)"
                                            , Resources.GeneralResource.Question
                                            , message);
                    RadAjaxManager1.ResponseScripts.Add(command);
                    break;
            }
        }
    }

    #endregion Grid treatment

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        RefreshGrid(true,chkPaid.Checked);
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
                    ticketId = (int)Session["DeleteId"];
                    tck = CntAriCli.GetTicket(ticketId, ctx);
                    ctx.Delete(tck);
                    ctx.SaveChanges();
                    RefreshGrid(true, chkPaid.Checked);
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

    protected void RefreshGrid(bool rebind, bool notpaid)
    {
        if (asn != null)
        {
            RadGrid1.DataSource = asn.AnestheticTickets;
            // call updateTotal in caller
            RadAjaxManager1.ResponseScripts.Add("parent.updateTotal()");
        }
        else if (sn != null)
        {
            RadGrid1.DataSource = sn.Tickets;
            // call updateTotal in caller
            RadAjaxManager1.ResponseScripts.Add("parent.updateTotal()");            
        }
        else
        {
            if (pat == null && cus == null)
                RadGrid1.DataSource = CntAriCli.GetTickets(notpaid, ctx);
            else
            {
                if (pat != null)
                    RadGrid1.DataSource = CntAriCli.GeTickets(notpaid, cus, ctx);
                if (cus != null)
                    RadGrid1.DataSource = CntAriCli.GetTicketsNotInvoiced(cus, ctx);
            }
        }
        if (rebind) RadGrid1.Rebind();
    }

    protected void chkPaid_CheckedChanged(object sender, EventArgs e)
    {
        RefreshGrid(true, chkPaid.Checked);
    }
}
