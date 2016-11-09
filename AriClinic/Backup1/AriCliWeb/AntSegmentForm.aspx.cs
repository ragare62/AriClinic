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

public partial class AntSegmentForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    OphthalmologicVisit oVisit = null;
    AntSegment atsg = null;
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
        if (Request.QueryString["AntSegmentId"] != null)
        {
            id = Int32.Parse(Request.QueryString["AntSegmentId"]);
            atsg = CntAriCli.GetAntSegment(id, ctx);
            oVisit = atsg.OphthalmologicVisit;
            LoadData(atsg);
        }
        if (Request.QueryString["OphVisitId"] != null)
        {
            id = int.Parse(Request.QueryString["OphVisitId"]);
            oVisit = (OphthalmologicVisit)CntAriCli.GetVisit(id, ctx);
            if (oVisit.AntSegments.Count > 0)
            {
                atsg = oVisit.AntSegments[0];
                LoadData(atsg);
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
        if (atsg == null)
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
        if (atsg == null)
        {
            atsg = new AntSegment();
            atsg.OphthalmologicVisit = oVisit;
            UnloadData(atsg);
            ctx.Add(atsg);
        }
        else
        {
            atsg = CntAriCli.GetAntSegment(atsg.Id, ctx);
            UnloadData(atsg);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                ,Resources.GeneralResource.Success
                ,Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("AntSegmentForm.aspx?AntSegmentId={0}",atsg.Id));
        return true;
    }

    protected void LoadData(AntSegment atsg)
    {
        txtConjunctiva.Text = atsg.Conjunctiva;
        txtCornea.Text = atsg.Cornea;
        txtChamber.Text = atsg.Chamber;
        txtTyndall.Text = atsg.Tyndall;
        txtIris.Text = atsg.Iris;
        txtPupil.Text = atsg.Pupil;
        txtCrystalline.Text = atsg.Crystalline;

        if (atsg.EyestrainRE != null) txtEyestrainRE.Value = (double)atsg.EyestrainRE;
        if (atsg.EyestrainLE != null) txtEyestrainLE.Value = (double)atsg.EyestrainLE;

    }

    protected void UnloadData(AntSegment atsg)
    {
        atsg.Conjunctiva = txtConjunctiva.Text;
        atsg.Cornea = txtCornea.Text;
        atsg.Chamber =txtChamber.Text;
        atsg.Tyndall = txtTyndall.Text ;
        atsg.Iris = txtIris.Text ;
        atsg.Pupil = txtPupil.Text ;
        atsg.Crystalline = txtCrystalline.Text ;

        if (txtEyestrainRE.Value != null) atsg.EyestrainRE = (decimal)txtEyestrainRE.Value;
        if (txtEyestrainLE.Value != null) atsg.EyestrainLE = (decimal)txtEyestrainLE.Value;

    }
    #endregion Auxiliary functions
}