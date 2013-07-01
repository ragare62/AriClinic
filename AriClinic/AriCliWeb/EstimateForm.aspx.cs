using System;
using AriCliModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class EstimateForm : System.Web.UI.Page 
{
    #region Variables declarations
    
    AriClinicContext ctx = null;
    User user = null;
    Estimate estimate = null;
    int estimateId = 0;
    Request req = null;
    int reqId = 0;
    Permission per = null;
    string caller = "";
    
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
                            where p.Code == "estimate"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        //
        if (Request.QueryString["RequestId"] != null)
        {
            reqId = Int32.Parse(Request.QueryString["RequestId"]);
            req = CntAriCli.GetRequest(reqId, ctx);
            txtRequestRequestId.Text = req.RequestId.ToString();
            if (req.Patient != null)
            {
                txtFullName.Text = req.Patient.FullName;
            }
            else
            {
                txtFullName.Text = req.FullName;
            }
        }
        // 
        if (Request.QueryString["EstimateId"] != null)
        {
            estimateId = Int32.Parse(Request.QueryString["EstimateId"]);
            estimate = CntAriCli.GetEstimate(estimateId, ctx);
            req = estimate.Request;
            LoadData(estimate);
        }
        else
        {
            // default values for a new Estimate
            rdtEstimateDate.SelectedDate = DateTime.Now;
        }
        if (Request.QueryString["Caller"] != null)
        {
            caller = Request.QueryString["Caller"];
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
        if (!CreateChange())
            return;
        string command = "";
        if (caller == "RequestForm")
        {
            command = "CancelEdit()";
        }
        else
        {
            // should be EstimateGrid
            command = "CloseAndRebind('')";
        }
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
        string message = "";
        if (rdtEstimateDate.SelectedDate == null)
        {
            message += Resources.GeneralResource.DateNeeded + "<br/>";
        }
        if (txtFullName.Text == "")
        {
            message += Resources.GeneralResource.CustomerNeeded + "<br/>";
        }if (message != "")
        {
            lblMessage.Text = message;
            return false;
        }
        return true;
    }
    
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (estimate == null)
        {
            estimate = new Estimate();
            UnloadData(estimate);
            ctx.Add(estimate);
        }
        else
        {
            estimate = CntAriCli.GetEstimate(estimateId, ctx);
            UnloadData(estimate);
        }
        ctx.SaveChanges();
        return true;
    }
    
    protected void LoadData(Estimate estimate)
    {
        txtEstimateId.Text = estimate.EstimateId.ToString();
        rdtEstimateDate.SelectedDate = estimate.EstimateDate;
        txtFullName.Text = estimate.FullName;
        txtComments.Text = estimate.Comments;
        lblTotal.Text = String.Format("TOTAL: {0:###,###,#0.00}", estimate.Total);
    }
    
    protected void UnloadData(Estimate estimate)
    {
        estimate.EstimateDate = (DateTime)rdtEstimateDate.SelectedDate;
        estimate.FullName = txtFullName.Text;
        estimate.Comments = txtComments.Text;
        estimate.Request = req;
        estimate.User = user;
        RefreshTotal(estimate);
    }
    
    #endregion Auxiliary functions
    
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
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
                    EstimateLine estl = (from c in ctx.EstimateLines
                                         where c.EstimateLineId == id
                                         select c).FirstOrDefault<EstimateLine>();
                    ctx.Delete(estl);
                    ctx.SaveChanges();
                    RadGrid1.DataSource = estimate.EstimateLines;
                    RefreshTotal(estimate);
                    RadGrid1.Rebind();
                    break;
            }
        }
    }
    
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            ImageButton imgb = (ImageButton)e.Item.FindControl("New");
            imgb.OnClientClick = String.Format("NewEstimateLine({0})", estimate.EstimateId);
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string name = "";
            string command = "";
            GridDataItem gdi;
            int id = 0;
            
            id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            
            // assign javascript function to edit button
            imgb = (ImageButton)e.Item.FindControl("Edit");
            command = String.Format("return EditEstimateLine({0},{1});", id, estimate.EstimateId);
            imgb.OnClientClick = command;
            
            // assigning javascript functions to delete button
            imgb = (ImageButton)e.Item.FindControl("Delete");
            command = String.Format("return confirm('{0} {1}');", Resources.GeneralResource.DeleteRecordQuestion, name);
            imgb.OnClientClick = command;
            imgb.Visible = per.Create;
        }
    }
    
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (estimate == null)
        {
            RadGrid1.DataSource = new List<EstimateLine>();
        }
        else
        {
            RadGrid1.DataSource = estimate.EstimateLines;
        }
        RefreshTotal(estimate);
    }
    
    protected void RefreshTotal(Estimate est)
    {
        decimal total = 0;
        if (estimate == null)
        {
            lblTotal.Text = String.Format("TOTAL: {0:###,###,#0.00}", total);
            return;
        }
        foreach (EstimateLine estl in est.EstimateLines)
        {
            total += (estl.Amount - estl.Discount);
        }
        est.Total = total;
        lblTotal.Text = String.Format("TOTAL: {0:###,###,#0.00}", est.Total);
    }
    
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (estimate == null)
        {
            RadGrid1.DataSource = new List<EstimateLine>();
        }
        else
        {
            RadGrid1.DataSource = estimate.EstimateLines;
        }
        RefreshTotal(estimate);
    }
    
    #region Special button actions
    
    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        string js = String.Format("printEstimate({0});", estimate.EstimateId);
        RadAjaxManager1.ResponseScripts.Add(js);
        RadAjaxManager1.ResponseScripts.Add("CloseAndRebind('');");
    }

    #endregion
}