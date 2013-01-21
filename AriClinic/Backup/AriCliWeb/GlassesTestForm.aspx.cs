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

public partial class GlassesTestForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Refractometry refractometry = null;
    GlassesTest glassesTest = null;
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
        if (Request.QueryString["GlassesTestId"] != null)
        {
            id = Int32.Parse(Request.QueryString["GlassesTestId"]);
            glassesTest = CntAriCli.GetGlassesTest(id, ctx);
            refractometry = glassesTest.Refractometry;
            LoadData(glassesTest);
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
        if (glassesTest == null)
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
        string command = "";
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
        if (glassesTest == null)
        {
            glassesTest = new GlassesTest();
            glassesTest.Refractometry = refractometry;
            UnloadData(glassesTest);
            ctx.Add(glassesTest);
        }
        else
        {
            glassesTest = CntAriCli.GetGlassesTest(glassesTest.Id, ctx);
            UnloadData(glassesTest);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                                                          , Resources.GeneralResource.Success
                                                          , Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("GlassesTestForm.aspx?GlassesTestId={0}", glassesTest.Id));
        return true;
    }

    protected void LoadData(GlassesTest gt)
    {
        txtFarAcuity.Text =  gt.FarAcuity;
        txtFarAxisLeftEye.Text =  gt.FarAxisLeftEye;
        txtFarAxisRightEye.Text =  gt.FarAxisRightEye;
        txtFarCenter.Text =  gt.FarCenters;
        txtFarCylinderLeftEye.Text =  gt.FarCylinderLeftEye;
        txtFarCylinderRightEye.Text =  gt.FarCylinderRightEye;
        txtFarPrismLeftEye.Text =  gt.FarPrismLeftEye;
        txtFarPrismRightEye.Text =  gt.FarPrimsRightEye;
        txtFarSphericityLefttEye.Text =  gt.FarSphericityLeftEye;
        txtFarSphericityRightEye.Text =  gt.FarSphericityRightEye;
        txtFarVisualAcuityLeftEye.Text =  gt.FarVisualAcuityLeftEye;
        txtFarVisualAcuityRightEye.Text =  gt.FarVisualAcuityRightEye;

        txtCloseAcuity.Text =  gt.CloseAcuity;
        txtCloseAxisLeftEye.Text =  gt.CloseAxisLeftEye;
        txtCloseAxisRightEye.Text =  gt.CloseAxisRightEye;
        txtCloseCenter.Text =  gt.CloseCenters;
        txtCloseCylinderLeftEye.Text =  gt.CloseCylinderLeftEye;
        txtCloseCylinderRightEye.Text =  gt.CloseCylinderRightEye;
        txtClosePrismLeftEye.Text =  gt.ClosePrismLeftEye;
        txtClosePrismRightEye.Text =  gt.ClosePrismRightEye;
        txtCloseSphericityLefttEye.Text =  gt.CloseSphericityLeftEye;
        txtCloseSphericityRightEye.Text =  gt.CloseSphericityRightEye;
        txtCloseVisualAcuityLeftEye.Text =  gt.CloseAcuityLeftEye;
        txtCloseVisualAcuityRightEye.Text =  gt.CloseAcuityRightEye;

        txtBothAcuity.Text =  gt.BothAcuity;
        txtBothAxisLeftEye.Text =  gt.BothAxisLeftEye;
        txtBothAxisRightEye.Text =  gt.BothAxisRightEye;
        txtBothCenter.Text =  gt.BothCenters;
        txtBothCylinderLeftEye.Text =  gt.BothCylinderLeftEye;
        txtBothCylinderRightEye.Text =  gt.BothCylinderRightEye;
        txtBothPrismLeftEye.Text =  gt.BothPrismLeftEye;
        txtBothPrismRightEye.Text =  gt.BothPrismRightEye;
        txtBothSphericityLefttEye.Text =  gt.BothSphericityLeftEye;
        txtBothSphericityRightEye.Text =  gt.BothSphericityRightEye;
        txtBothVisualAcuityLeftEye.Text =  gt.BothAcuityLeftEye;
        txtBothVisualAcuityRightEye.Text =  gt.BothAcuityRightEye;


        txtComments.Text = gt.Comments;
    }

    protected void UnloadData(GlassesTest gt)
    {
        gt.FarAcuity =  txtFarAcuity.Text;
        gt.FarAxisLeftEye =  txtFarAxisLeftEye.Text;
        gt.FarAxisRightEye =  txtFarAxisRightEye.Text;
        gt.FarCenters =  txtFarCenter.Text;
        gt.FarCylinderLeftEye =  txtFarCylinderLeftEye.Text;
        gt.FarCylinderRightEye =  txtFarCylinderRightEye.Text;
        gt.FarPrismLeftEye =  txtFarPrismLeftEye.Text;
        gt.FarPrimsRightEye =  txtFarPrismRightEye.Text;
        gt.FarSphericityLeftEye =  txtFarSphericityLefttEye.Text;
        gt.FarSphericityRightEye =  txtFarSphericityRightEye.Text;
        gt.FarVisualAcuityLeftEye =  txtFarVisualAcuityLeftEye.Text;
        gt.FarVisualAcuityRightEye =  txtFarVisualAcuityRightEye.Text;

        gt.CloseAcuity =  txtCloseAcuity.Text;
        gt.CloseAxisLeftEye =  txtCloseAxisLeftEye.Text;
        gt.CloseAxisRightEye =  txtCloseAxisRightEye.Text;
        gt.CloseCenters =  txtCloseCenter.Text;
        gt.CloseCylinderLeftEye =  txtCloseCylinderLeftEye.Text;
        gt.CloseCylinderRightEye =  txtCloseCylinderRightEye.Text;
        gt.ClosePrismLeftEye =  txtClosePrismLeftEye.Text;
        gt.ClosePrismRightEye =  txtClosePrismRightEye.Text;
        gt.CloseSphericityLeftEye =  txtCloseSphericityLefttEye.Text;
        gt.CloseSphericityRightEye =  txtCloseSphericityRightEye.Text;
        gt.CloseAcuityLeftEye =  txtCloseVisualAcuityLeftEye.Text;
        gt.CloseAcuityRightEye =  txtCloseVisualAcuityRightEye.Text;

        gt.BothAcuity =  txtBothAcuity.Text;
        gt.BothAxisLeftEye =  txtBothAxisLeftEye.Text;
        gt.BothAxisRightEye =  txtBothAxisRightEye.Text;
        gt.BothCenters =  txtBothCenter.Text;
        gt.BothCylinderLeftEye =  txtBothCylinderLeftEye.Text;
        gt.BothCylinderRightEye =  txtBothCylinderRightEye.Text;
        gt.BothPrismLeftEye =  txtBothPrismLeftEye.Text;
        gt.BothPrismRightEye =  txtBothPrismRightEye.Text;
        gt.BothSphericityLeftEye =  txtBothSphericityLefttEye.Text;
        gt.BothSphericityRightEye =  txtBothSphericityRightEye.Text;
        gt.BothAcuityLeftEye =  txtBothVisualAcuityLeftEye.Text;
        gt.BothAcuityRightEye =  txtBothVisualAcuityRightEye.Text;


        gt.Comments = txtComments.Text;
    }
    #endregion Auxiliary functions
}