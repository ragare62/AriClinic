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
        txtFarAcuity.Text = CntWeb.GetPossibleNull(gt.FarAcuity);
        txtFarAxisLeftEye.Text = CntWeb.GetPossibleNull(gt.FarAxisLeftEye);
        txtFarAxisRightEye.Text = CntWeb.GetPossibleNull(gt.FarAxisRightEye);
        txtFarCenter.Text = CntWeb.GetPossibleNull(gt.FarCenters);
        txtFarCylinderLeftEye.Text = CntWeb.GetPossibleNull(gt.FarCylinderLeftEye);
        txtFarCylinderRightEye.Text = CntWeb.GetPossibleNull(gt.FarCylinderRightEye);
        txtFarPrismLeftEye.Text = CntWeb.GetPossibleNull(gt.FarPrismLeftEye);
        txtFarPrismRightEye.Text = CntWeb.GetPossibleNull(gt.FarPrimsRightEye);
        txtFarSphericityLefttEye.Text = CntWeb.GetPossibleNull(gt.FarSphericityLeftEye);
        txtFarSphericityRightEye.Text = CntWeb.GetPossibleNull(gt.FarSphericityRightEye);
        txtFarVisualAcuityLeftEye.Text = CntWeb.GetPossibleNull(gt.FarVisualAcuityLeftEye);
        txtFarVisualAcuityRightEye.Text = CntWeb.GetPossibleNull(gt.FarVisualAcuityRightEye);

        txtCloseAcuity.Text = CntWeb.GetPossibleNull(gt.CloseAcuity);
        txtCloseAxisLeftEye.Text = CntWeb.GetPossibleNull(gt.CloseAxisLeftEye);
        txtCloseAxisRightEye.Text = CntWeb.GetPossibleNull(gt.CloseAxisRightEye);
        txtCloseCenter.Text = CntWeb.GetPossibleNull(gt.CloseCenters);
        txtCloseCylinderLeftEye.Text = CntWeb.GetPossibleNull(gt.CloseCylinderLeftEye);
        txtCloseCylinderRightEye.Text = CntWeb.GetPossibleNull(gt.CloseCylinderRightEye);
        txtClosePrismLeftEye.Text = CntWeb.GetPossibleNull(gt.ClosePrismLeftEye);
        txtClosePrismRightEye.Text = CntWeb.GetPossibleNull(gt.ClosePrismRightEye);
        txtCloseSphericityLefttEye.Text = CntWeb.GetPossibleNull(gt.CloseSphericityLeftEye);
        txtCloseSphericityRightEye.Text = CntWeb.GetPossibleNull(gt.CloseSphericityRightEye);
        txtCloseVisualAcuityLeftEye.Text = CntWeb.GetPossibleNull(gt.CloseAcuityLeftEye);
        txtCloseVisualAcuityRightEye.Text = CntWeb.GetPossibleNull(gt.CloseAcuityRightEye);

        txtBothAcuity.Text = CntWeb.GetPossibleNull(gt.BothAcuity);
        txtBothAxisLeftEye.Text = CntWeb.GetPossibleNull(gt.BothAxisLeftEye);
        txtBothAxisRightEye.Text = CntWeb.GetPossibleNull(gt.BothAxisRightEye);
        txtBothCenter.Text = CntWeb.GetPossibleNull(gt.BothCenters);
        txtBothCylinderLeftEye.Text = CntWeb.GetPossibleNull(gt.BothCylinderLeftEye);
        txtBothCylinderRightEye.Text = CntWeb.GetPossibleNull(gt.BothCylinderRightEye);
        txtBothPrismLeftEye.Text = CntWeb.GetPossibleNull(gt.BothPrismLeftEye);
        txtBothPrismRightEye.Text = CntWeb.GetPossibleNull(gt.BothPrismRightEye);
        txtBothSphericityLefttEye.Text = CntWeb.GetPossibleNull(gt.BothSphericityLeftEye);
        txtBothSphericityRightEye.Text = CntWeb.GetPossibleNull(gt.BothSphericityRightEye);
        txtBothVisualAcuityLeftEye.Text = CntWeb.GetPossibleNull(gt.BothAcuityLeftEye);
        txtBothVisualAcuityRightEye.Text = CntWeb.GetPossibleNull(gt.BothAcuityRightEye);


        txtComments.Text = gt.Comments;
    }

    protected void UnloadData(GlassesTest gt)
    {
        gt.FarAcuity = CntWeb.SetPossibleNull(txtFarAcuity.Text);
        gt.FarAxisLeftEye = CntWeb.SetPossibleNull(txtFarAxisLeftEye.Text);
        gt.FarAxisRightEye = CntWeb.SetPossibleNull(txtFarAxisRightEye.Text);
        gt.FarCenters = CntWeb.SetPossibleNull(txtFarCenter.Text);
        gt.FarCylinderLeftEye = CntWeb.SetPossibleNull(txtFarCylinderLeftEye.Text);
        gt.FarCylinderRightEye = CntWeb.SetPossibleNull(txtFarCylinderRightEye.Text);
        gt.FarPrismLeftEye = CntWeb.SetPossibleNull(txtFarPrismLeftEye.Text);
        gt.FarPrimsRightEye = CntWeb.SetPossibleNull(txtFarPrismRightEye.Text);
        gt.FarSphericityLeftEye = CntWeb.SetPossibleNull(txtFarSphericityLefttEye.Text);
        gt.FarSphericityRightEye = CntWeb.SetPossibleNull(txtFarSphericityRightEye.Text);
        gt.FarVisualAcuityLeftEye = CntWeb.SetPossibleNull(txtFarVisualAcuityLeftEye.Text);
        gt.FarVisualAcuityRightEye = CntWeb.SetPossibleNull(txtFarVisualAcuityRightEye.Text);

        gt.CloseAcuity = CntWeb.SetPossibleNull(txtCloseAcuity.Text);
        gt.CloseAxisLeftEye = CntWeb.SetPossibleNull(txtCloseAxisLeftEye.Text);
        gt.CloseAxisRightEye = CntWeb.SetPossibleNull(txtCloseAxisRightEye.Text);
        gt.CloseCenters = CntWeb.SetPossibleNull(txtCloseCenter.Text);
        gt.CloseCylinderLeftEye = CntWeb.SetPossibleNull(txtCloseCylinderLeftEye.Text);
        gt.CloseCylinderRightEye = CntWeb.SetPossibleNull(txtCloseCylinderRightEye.Text);
        gt.ClosePrismLeftEye = CntWeb.SetPossibleNull(txtClosePrismLeftEye.Text);
        gt.ClosePrismRightEye = CntWeb.SetPossibleNull(txtClosePrismRightEye.Text);
        gt.CloseSphericityLeftEye = CntWeb.SetPossibleNull(txtCloseSphericityLefttEye.Text);
        gt.CloseSphericityRightEye = CntWeb.SetPossibleNull(txtCloseSphericityRightEye.Text);
        gt.CloseAcuityLeftEye = CntWeb.SetPossibleNull(txtCloseVisualAcuityLeftEye.Text);
        gt.CloseAcuityRightEye = CntWeb.SetPossibleNull(txtCloseVisualAcuityRightEye.Text);

        gt.BothAcuity = CntWeb.SetPossibleNull(txtBothAcuity.Text);
        gt.BothAxisLeftEye = CntWeb.SetPossibleNull(txtBothAxisLeftEye.Text);
        gt.BothAxisRightEye = CntWeb.SetPossibleNull(txtBothAxisRightEye.Text);
        gt.BothCenters = CntWeb.SetPossibleNull(txtBothCenter.Text);
        gt.BothCylinderLeftEye = CntWeb.SetPossibleNull(txtBothCylinderLeftEye.Text);
        gt.BothCylinderRightEye = CntWeb.SetPossibleNull(txtBothCylinderRightEye.Text);
        gt.BothPrismLeftEye = CntWeb.SetPossibleNull(txtBothPrismLeftEye.Text);
        gt.BothPrismRightEye = CntWeb.SetPossibleNull(txtBothPrismRightEye.Text);
        gt.BothSphericityLeftEye = CntWeb.SetPossibleNull(txtBothSphericityLefttEye.Text);
        gt.BothSphericityRightEye = CntWeb.SetPossibleNull(txtBothSphericityRightEye.Text);
        gt.BothAcuityLeftEye = CntWeb.SetPossibleNull(txtBothVisualAcuityLeftEye.Text);
        gt.BothAcuityRightEye = CntWeb.SetPossibleNull(txtBothVisualAcuityRightEye.Text);


        gt.Comments = txtComments.Text;
    }
    #endregion Auxiliary functions
}