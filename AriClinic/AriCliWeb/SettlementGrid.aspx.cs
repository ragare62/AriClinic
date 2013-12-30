using AriCliModel;
using AriCliWeb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;

public partial class SettelmentGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Patient pat = null;
    bool notPaid = false;
    Ticket tck = null;
    Customer cus = null;
    Clinic cl = null;
    int ticketId = 0;
    int patientId = 0;
    int customerId = 0;
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
                            where p.Code == "policy"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        if (Session["Clinic"] != null)
            cl = (Clinic)Session["Clinic"];
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
        else if (type == "comprobante")
        {
            HtmlControl tt = (HtmlControl)this.FindControl("Actions");
            tt.Attributes["class"] = "ghost";
            // hide patient column
            //RadGrid1.Columns.FindByDataField("Policy.Customer.FullName").Visible = false;
            btnComp.Visible = true;
            
            lblTitle.Text = "Comprobantes";
            
            rdcbType.AutoPostBack = true;
            rdcbType.Items.Clear();
            rdcbType.Items.Add(new RadComboBoxItem("Con comprobante", "C"));
            rdcbType.Items.Add(new RadComboBoxItem("Sin comprobante", "SC"));
            
            RadGrid1.PageSize = 6;
        }
        else
        {
            //
            RadGrid1.PageSize = 6;
        }
        // translate filters
        CntWeb.TranslateRadGridFilters(RadGrid1);
        //
        LoadInsuranceCombo();
        LoadPayementFormCombo();
        LoadClinicCombo();
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
        if (!DataOk())
            RefreshGrid(false);
        else
            RefreshGrid(true);
    }
        
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            ImageButton imgb = (ImageButton)e.Item.FindControl("New");
            imgb.Visible = per.Create;
            if (pat != null)
                imgb.OnClientClick = "NewTicketRecordInTab();";
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string name = "";
            string command = "";
            GridDataItem gdi;
            string id = "";
            ArrayList selectedItems;
            
            // assign javascript function to select button
            imgb = (ImageButton)e.Item.FindControl("Select");
            gdi = (GridDataItem)e.Item;
            // payed?
                
            if (Session["selectedItems"] == null)
            {
                selectedItems = new ArrayList();
            }
            else
            {
                selectedItems = (ArrayList)Session["selectedItems"];
            }
            id = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]].ToString();
            if (selectedItems.Contains(id))
            {
                //e.Item.Selected = true;
                gdi.BackColor = Color.LightGreen;
                //gdi["Policy.Insurance.Name"].BackColor = Color.LightGreen;
            }
            else
            {
                gdi.BackColor = new Color();
                //e.Item.Selected = false;
            }
            
            //}
            //if (e.Item is GridDataItem)
            //{
            //ImageButton imgb = null;
            //string name = "";
            //string command = "";
            //GridDataItem gdi;
            //int id = 0;
            
            //id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            
            //// assign javascript function to select button
            //imgb = (ImageButton)e.Item.FindControl("Select");
            //gdi = (GridDataItem)e.Item;
            //// payed?
            
            // backgroud color for primary types
            //if (gdi["Checked"].Text == "True")
            //{
            //    //gdi["Policy.Insurance.Name"].BackColor = Color.LightGreen;
            //    gdi["Policy.Insurance.Name"].BackColor = Color.LightGreen;
            //}
            name = String.Format("{0} ({1}: {2})",
                gdi["Policy.Customer.FullName"].Text,
                gdi["Description"].Text,
                gdi["Amount"].Text);
            command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');",
                id.ToString(),
                gdi["Amount"].Text.Replace("�", ""),
                name,
                null,
                "Ticket");
            imgb.OnClientClick = command;
            if (type != "S")
                imgb.Visible = false; // not called from another form
            
            // assign javascript function to edit button
            imgb = (ImageButton)e.Item.FindControl("Edit");
            //if (pat == null)
            //    command = String.Format("return EditTicketRecord({0});", id);
            //else
            //    command = String.Format("return EditTicketRecordInTab({0});", id);
            tck = CntAriCli.GetTicket(int.Parse(id), ctx);
            if (tck.GetType() == typeof(AnestheticTicket))
            {
                command = String.Format("EditAnestheticTicketRecord({0})", id); // general ticket grid
            }
            else
            {
                command = String.Format("EditTicketRecord({0})", id); // general ticket grid
            }

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
        //lblMensaje.Visible = false;
        ArrayList selectedItems;
        if (Session["selectedItems"] == null)
        {
            selectedItems = new ArrayList();
        }
        else
        {
            selectedItems = (ArrayList)Session["selectedItems"];
        }
        if (e.CommandName == "Selecion" && e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            string idTick = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["TicketId"].ToString();
            if (!selectedItems.Contains(idTick))
            {
                selectedItems.Add(idTick);
                //e.Item.Selected = true;
                e.Item.BackColor = Color.LightGreen;
            }
            else
            {
                selectedItems.Remove(idTick);
                e.Item.BackColor = new Color();
                //e.Item.Selected = false;
            }
        
            Session["selectedItems"] = selectedItems;
        }
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
                    // new tratement (now there's more that one ticket's kind)
                    //string command = "";
                    //tck = CntAriCli.GetTicket(id, ctx);
                    //if (tck.GetType() == typeof(AnestheticTicket))
                    //{
                    //    command = String.Format("EditAnestheticTicketRecord({0})", id); // general ticket grid
                    //}
                    //else
                    //{
                    //    command = String.Format("EditTicketRecord({0})", id); // general ticket grid
                    //}
                    //RadAjaxManager1.ResponseScripts.Add(command);
                    break;
                case "Delete":
                    tck = (from t in ctx.Tickets
                           where t.TicketId == id
                           select t).FirstOrDefault<Ticket>();
                    ctx.Delete(tck);
                    ctx.SaveChanges();
                    RefreshGrid(true);
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
    }
        
    protected void RefreshGrid(bool rebind)
    {
        if (!rebind)
        {
            RadGrid1.DataSource = new List<Ticket>();
            return;
        }
        if (!DataOk())
            return;
            
        RadGrid1.DataSource = CntAriCli.GetTickets((DateTime)rddpFromDate.SelectedDate,
            (DateTime)rddpToDate.SelectedDate,
            Int32.Parse(rdcbInsurance.SelectedValue),
            rdcbType.SelectedValue,
            ctx);
        //RadGrid1.Rebind();
    }
        
    protected void RefreshGrid(bool rebind, bool comprobante)
    {
        if (!rebind)
        {
            RadGrid1.DataSource = new List<Ticket>();
            return;
        }
        if (!DataOk())
            return;
            
        RadGrid1.DataSource = CntAriCli.GetTickets((DateTime)rddpFromDate.SelectedDate,
            (DateTime)rddpToDate.SelectedDate,
            Int32.Parse(rdcbInsurance.SelectedValue),
            rdcbType.SelectedValue,
            ctx);
        //RadGrid1.Rebind();
    }
        
    protected bool DataOk()
    {
        if (rddpFromDate.SelectedDate == null || rddpToDate == null)
        {
            lblMessage.Text = Resources.GeneralResource.DateNeeded;
            return false;
        }
        if (rddpFromDate.SelectedDate > rddpToDate.SelectedDate)
        {
            lblMessage.Text = Resources.GeneralResource.FromGreatherThanTo;
            return false;
        }
        return true;
    }
        
    protected void LoadInsuranceCombo()
    {
        rdcbInsurance.Items.Clear();
        foreach (Insurance i in ctx.Insurances)
        {
            rdcbInsurance.Items.Add(new RadComboBoxItem(i.Name, i.InsuranceId.ToString()));
        }
    }
        
    protected void LoadPayementFormCombo()
    {
        rdcbPayementForm.Items.Clear();
        foreach (PaymentMethod pm in ctx.PaymentMethods)
        {
            rdcbPayementForm.Items.Add(new RadComboBoxItem(pm.Name, pm.PaymentMethodId.ToString()));
        }
    }
        
    protected void LoadClinicCombo()
    {
        rdcbClinic.Items.Clear();
        foreach (Clinic c in ctx.Clinics)
        {
            rdcbClinic.Items.Add(new RadComboBoxItem(c.Name,c.ClinicId.ToString()));
        }
        if (cl != null)
            rdcbClinic.SelectedValue = cl.ClinicId.ToString();
        rddpPayDate.SelectedDate = DateTime.Now;
    }
        
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblPaymentForm.Visible = false;
        rdcbPayementForm.Visible = false;
        btnDo.Visible = false;
        btnUnDo.Visible = false;
        lblClinic.Visible = false;
        rdcbClinic.Visible = false;
        lblPayDate.Visible = false;
        rddpPayDate.Visible = false;
        if (rdcbType.SelectedValue == "NP")
        {
            lblPaymentForm.Visible = true;
            rdcbPayementForm.Visible = true;
            lblClinic.Visible = true;
            rdcbClinic.Visible = true;
            lblPayDate.Visible = true;
            rddpPayDate.Visible = true;
            btnDo.Visible = true;
        }
        else
        {
            btnUnDo.Visible = true;
        }
        //RefreshGrid(true);
        RadGrid1.Rebind();
    }
        
    protected void DoPayments()
    {
        ArrayList selectedItems = (ArrayList)Session["selectedItems"];
        PaymentMethod pm = CntAriCli.GetPaymentMethod(Int32.Parse(rdcbPayementForm.SelectedValue), ctx);
        cl = CntAriCli.GetClinic(Int32.Parse(rdcbClinic.SelectedValue), ctx);
        DateTime pd = (DateTime)rddpPayDate.SelectedDate;
        //foreach(GridDataItem item in RadGrid1.SelectedItems)
        //{
        //    int id = Int32.Parse(item["TicketId"].Text);
        foreach (string item in selectedItems)
        {
            int id = int.Parse(item);
            Ticket tck = CntAriCli.GetTicket(id, ctx);
            // Delete previous payments
            ctx.Delete(tck.Payments);
            Payment p = new Payment();
            p.PaymentDate = pd;
            p.Clinic = cl;
            p.PaymentMethod = pm;
            p.Ticket = tck;
            p.Amount = tck.Amount;
            p.User = CntAriCli.GetUser(user.UserId, ctx);
            tck.Paid = p.Amount;
            ctx.Add(p);
            ctx.SaveChanges();
        }
        
        lblMessage.Text = Resources.GeneralResource.PaymentsDone;
        Session["selectedItems"] = new ArrayList();
        RadGrid1.Rebind();
    }
        
    protected void UnDoPayments()
    {
        ArrayList selectedItems = (ArrayList)Session["selectedItems"];
        //foreach (GridDataItem item in RadGrid1.SelectedItems)
        //{
        //    int id = Int32.Parse(item["TicketId"].Text);
        foreach (string item in selectedItems)
        {
            int id = int.Parse(item);    
            Ticket tck = CntAriCli.GetTicket(id, ctx);
            // Delete previous payments
            ctx.Delete(tck.Payments);
            tck.Paid = 0;
            ctx.SaveChanges();
        }
        
        lblMessage.Text = Resources.GeneralResource.PaymentsUnDone;
        Session["selectedItems"] = new ArrayList();
        RadGrid1.Rebind();
    }
        
    protected void btnDo_Click(object sender, EventArgs e)
    {
        DoPayments();
    }
        
    protected void btnUnDo_Click(object sender, EventArgs e)
    {
        UnDoPayments();
    }
        
    protected void chkSelec_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelec.Checked == true)
        {
            ArrayList selectedItems = selectedItems = new ArrayList();
            IList<Ticket> tick = CntAriCli.GetTickets((DateTime)rddpFromDate.SelectedDate,
                (DateTime)rddpToDate.SelectedDate,
                Int32.Parse(rdcbInsurance.SelectedValue),
                rdcbType.SelectedValue,
                ctx);
            foreach (Ticket item in tick)
            {
                selectedItems.Add(item.TicketId.ToString());
            }
            Session["selectedItems"] = selectedItems;
        }
        else
            Session["selectedItems"] = new ArrayList();

        RadGrid1.Rebind();
    }
        
    protected void btnComp_Click(object sender, EventArgs e)
    {
        ArrayList selectedItems = (ArrayList)Session["selectedItems"];
        if (selectedItems == null)
            return;
        foreach (string item in selectedItems)
        {
            int id = int.Parse(item);
            Ticket tck = CntAriCli.GetTicket(id, ctx);
                
            if (rdcbType.SelectedValue.Equals("SC"))
            {
                tck.Checked = true;
            }
            else
            {
                tck.Checked = false;
            }
        }
        Session["selectedItems"] = new ArrayList();
        ctx.SaveChanges();
        
        chkSelec.Checked = false;

        RadGrid1.Rebind();
    }
        
    protected void rdcbType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rdcbType.SelectedValue.Equals("C"))
        {
            btnComp.Text = "Desmarcar comprobante";
        }
        else
        {
            btnComp.Text = "Marcar comprobante";
        }
    }
}