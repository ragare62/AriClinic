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

public partial class WithoutGlassesForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Refractometry refractometry = null;
    WithoutGlassesTest withoutGlasses = null;
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
        if (Request.QueryString["WithoutGlassesId"] != null)
        {
            id = Int32.Parse(Request.QueryString["WithoutGlassesId"]);
            withoutGlasses = CntAriCli.GetWithoutGlassesTest(id, ctx);
            refractometry = withoutGlasses.Refractometry;
            LoadData(withoutGlasses);
        }
        if (Request.QueryString["RefractometryId"] != null)
        {
            id = int.Parse(Request.QueryString["RefractometryId"]);
            refractometry = (Refractometry)CntAriCli.GetExaminationAssigned(id, ctx);
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
        if (withoutGlasses == null)
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
        if (withoutGlasses == null)
        {
            withoutGlasses = new WithoutGlassesTest();
            withoutGlasses.Refractometry = refractometry;
            UnloadData(withoutGlasses);
            ctx.Add(withoutGlasses);
        }
        else
        {
            withoutGlasses = CntAriCli.GetWithoutGlassesTest(withoutGlasses.Id, ctx);
            UnloadData(withoutGlasses);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                ,Resources.GeneralResource.Success
                ,Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("WithoutGlassesForm.aspx?WithoutGlassesId={0}",withoutGlasses.Id));
        return true;
    }

    protected void LoadData(WithoutGlassesTest wtg)
    {
        txtCloseAcuityBothEyes.Text = CntWeb.GetPossibleNull(wtg.CloseVisualAcuityBothEyes);
        txtCloseAcuityLeftEye.Text = CntWeb.GetPossibleNull(wtg.CloseVisualAcuityLeftEye);
        txtCloseAcuityRightEye.Text = CntWeb.GetPossibleNull(wtg.CloseVisualAcuityRightEye);

        txtFarAcuityBothEyes.Text = CntWeb.GetPossibleNull(wtg.FarVisualAcuityBothEyes);
        txtFarAcuityLeftEye.Text = CntWeb.GetPossibleNull(wtg.FarVisualAcuityLeftEye);
        txtFarAcuityRightEye.Text = CntWeb.GetPossibleNull(wtg.FarVisualAcuityRightEye);

        txtComments.Text = wtg.Comments;
    }

    protected void UnloadData(WithoutGlassesTest wtg)
    {
        wtg.CloseVisualAcuityBothEyes = CntWeb.SetPossibleNull(txtCloseAcuityBothEyes.Text);
        wtg.CloseVisualAcuityLeftEye = CntWeb.SetPossibleNull(txtCloseAcuityLeftEye.Text);
        wtg.CloseVisualAcuityRightEye = CntWeb.SetPossibleNull(txtCloseAcuityRightEye.Text);

        wtg.FarVisualAcuityBothEyes = CntWeb.SetPossibleNull(txtFarAcuityBothEyes.Text);
        wtg.FarVisualAcuityLeftEye = CntWeb.SetPossibleNull(txtFarAcuityLeftEye.Text);
        wtg.FarVisualAcuityRightEye = CntWeb.SetPossibleNull(txtFarAcuityRightEye.Text);

        wtg.Comments = txtComments.Text;
    }
    #endregion Auxiliary functions
}