using System;
using AriCliModel;
using AriCliWeb;
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

public partial class FundusForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    OphthalmologicVisit oVisit = null;
    Fundus fundus = null;
    int id = 0;
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
                            where p.Code == "examinationassigned"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // 
        if (Request.QueryString["FundusId"] != null)
        {
            id = Int32.Parse(Request.QueryString["FundusId"]);
            fundus = CntAriCli.GetFundus(id, ctx);
            oVisit = fundus.OphthalmologicVisit;
            LoadData(fundus);
        }
        if (Request.QueryString["OphVisitId"] != null)
        {
            id = int.Parse(Request.QueryString["OphVisitId"]);
            oVisit = (OphthalmologicVisit)CntAriCli.GetVisit(id, ctx);
            if (oVisit.Fundus.Count > 0)
            {
                fundus = oVisit.Fundus[0];
                LoadData(fundus);
            }
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
        if (fundus == null)
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
        //string command = "";
        // check combo values
        //if (txtName.Text == "")
        //{
        //    command = String.Format("showDialog('{0}','{1}','warning',null,0,0)"
        //        ,Resources.GeneralResource.Warning
        //        ,Resources.GeneralResource.NameNeeded);
        //    RadAjaxManager1.ResponseScripts.Add(command);
        //    return false;
        //}
        return true;
    }

    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (fundus == null)
        {
            fundus = new Fundus();
            fundus.OphthalmologicVisit = oVisit;
            UnloadData(fundus);
            ctx.Add(fundus);
        }
        else
        {
            fundus = CntAriCli.GetFundus(fundus.Id, ctx);
            UnloadData(fundus);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)", Resources.GeneralResource.Success, Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("FundusForm.aspx?FundusId={0}", fundus.Id));
        return true;
    }

    protected void LoadData(Fundus fundus)
    {
        txtOpticalNerve.Text = fundus.OpticNerve;
        txtVessels.Text = fundus.Vessels;
        txtMacula.Text = fundus.Macula;
        txtVitreous.Text = fundus.Vitreous;
        txtPeriphery.Text = fundus.Periphery;
    }

    protected void UnloadData(Fundus fundus)
    {
        fundus.OpticNerve = txtOpticalNerve.Text ;
        fundus.Vessels = txtVessels.Text ;
        fundus.Macula = txtMacula.Text ;
        fundus.Vitreous = txtVitreous.Text ;
        fundus.Periphery = txtPeriphery.Text ;
    }
    #endregion Auxiliary functions
}