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

public partial class EstimateLineForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Estimate est = null;
    int estId = 0;
    EstimateLine estl = null;
    int estlId;
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
                            where p.Code == "Estimate"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["EstimateId"] != null)
        {
            estId = Int32.Parse(Request.QueryString["EstimateId"]);
            est = CntAriCli.GetEstimate(estId, ctx);
            
        }
        // 
        if (Request.QueryString["EstimateLineId"] != null)
        {
            estlId = Int32.Parse(Request.QueryString["EstimateLineId"]);
            estl = CntAriCli.GetEstimateLine(estlId, ctx);
            LoadData(estl);
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
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (estl == null)
        {
            est = new Estimate();
            UnloadData(estl);
            ctx.Add(estl);
        }
        else
        {
            est = CntAriCli.GetEstimate(estId, ctx);
            UnloadData(estl);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(EstimateLine estl)
    {
        txtEstimateLineId.Text = estl.EstimateLineId.ToString();
        txtDescription.Text = estl.Description;
        txtAmount.Value = (double)estl.Amount;
        txtTotal.Value = (double)(estl.Amount - estl.Discount);
    }
    protected void UnloadData(EstimateLine estl)
    {
        estl.Description = txtDescription.Text;
        estl.Amount = (decimal)txtAmount.Value;
        estl.Discount = (decimal)txtDiscount.Value;
    }
    #endregion Auxiliary functions



}
