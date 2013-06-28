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
        string command = "CloseAndRebind('')";
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
        } if (message != "")
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
        lblTotal.Text = String.Format("TOTAL: {0:###,###,#0.00}", estimate.Total);
    }
        
    protected void UnloadData(Estimate estimate)
    {
        estimate.EstimateDate = (DateTime)rdtEstimateDate.SelectedDate;
        estimate.FullName = txtFullName.Text;
        estimate.Request = req;
        estimate.User = user;
    }
    
    #endregion Auxiliary functions
            

    
    #region Special button actions
    
    
    #endregion
}