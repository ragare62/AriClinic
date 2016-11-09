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

public partial class OpticalObjectiveExaminationForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Refractometry refractometry = null;
    OpticalObjectiveExamination OpticalObjectiveExamination = null;
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
        if (Request.QueryString["OpticalObjectiveExaminationId"] != null)
        {
            id = Int32.Parse(Request.QueryString["OpticalObjectiveExaminationId"]);
            OpticalObjectiveExamination = CntAriCli.GetOpticalObjectiveExamination(id, ctx);
            refractometry = OpticalObjectiveExamination.Refractometry;
            LoadData(OpticalObjectiveExamination);
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
        if (OpticalObjectiveExamination == null)
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
        if (OpticalObjectiveExamination == null)
        {
            OpticalObjectiveExamination = new OpticalObjectiveExamination();
            OpticalObjectiveExamination.Refractometry = refractometry;
            UnloadData(OpticalObjectiveExamination);
            ctx.Add(OpticalObjectiveExamination);
        }
        else
        {
            OpticalObjectiveExamination = CntAriCli.GetOpticalObjectiveExamination(OpticalObjectiveExamination.Id, ctx);
            UnloadData(OpticalObjectiveExamination);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                                                          , Resources.GeneralResource.Success
                                                          , Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("OpticalObjectiveExaminationForm.aspx?OpticalObjectiveExaminationId={0}", OpticalObjectiveExamination.Id));
        return true;
    }

    protected void LoadData(OpticalObjectiveExamination ooex)
    {
        txtFarAcuity.Text =  ooex.FarAcuity;
        txtFarAxisLeftEye.Text =  ooex.FarAxisLeftEye;
        txtFarAxisRightEye.Text =  ooex.FarAxisRightEye;
        txtFarCenter.Text =  ooex.FarCenters;
        txtFarCylinderLeftEye.Text =  ooex.FarCylinderLeftEye;
        txtFarCylinderRightEye.Text =  ooex.FarCylinderRightEye;
        txtFarPrismLeftEye.Text =  ooex.FarPrismLeftEye;
        txtFarPrismRightEye.Text =  ooex.FarPrimsRightEye;
        txtFarSphericityLefttEye.Text =  ooex.FarSphericityLeftEye;
        txtFarSphericityRightEye.Text =  ooex.FarSphericityRightEye;
        txtFarVisualAcuityLeftEye.Text =  ooex.FarVisualAcuityLeftEye;
        txtFarVisualAcuityRightEye.Text =  ooex.FarVisualAcuityRightEye;

        txtCloseAcuity.Text =  ooex.CloseAcuity;
        txtCloseAxisLeftEye.Text =  ooex.CloseAxisLeftEye;
        txtCloseAxisRightEye.Text =  ooex.CloseAxisRightEye;
        txtCloseCenter.Text =  ooex.CloseCenters;
        txtCloseCylinderLeftEye.Text =  ooex.CloseCylinderLeftEye;
        txtCloseCylinderRightEye.Text =  ooex.CloseCylinderRightEye;
        txtClosePrismLeftEye.Text =  ooex.ClosePrismLeftEye;
        txtClosePrismRightEye.Text =  ooex.ClosePrismRightEye;
        txtCloseSphericityLefttEye.Text =  ooex.CloseSphericityLeftEye;
        txtCloseSphericityRightEye.Text =  ooex.CloseSphericityRightEye;
        txtCloseVisualAcuityLeftEye.Text =  ooex.CloseAcuityLeftEye;
        txtCloseVisualAcuityRightEye.Text =  ooex.CloseAcuityRightEye;

        txtBothAcuity.Text =  ooex.BothAcuity;
        txtBothAxisLeftEye.Text =  ooex.BothAxisLeftEye;
        txtBothAxisRightEye.Text =  ooex.BothAxisRightEye;
        txtBothCenter.Text =  ooex.BothCenters;
        txtBothCylinderLeftEye.Text =  ooex.BothCylinderLeftEye;
        txtBothCylinderRightEye.Text =  ooex.BothCylinderRightEye;
        txtBothPrismLeftEye.Text =  ooex.BothPrismLeftEye;
        txtBothPrismRightEye.Text =  ooex.BothPrismRightEye;
        txtBothSphericityLefttEye.Text =  ooex.BothSphericityLeftEye;
        txtBothSphericityRightEye.Text =  ooex.BothSphericityRightEye;
        txtBothVisualAcuityLeftEye.Text =  ooex.BothAcuityLeftEye;
        txtBothVisualAcuityRightEye.Text =  ooex.BothAcuityRightEye;

        txtK1RightEye.Text = ooex.K1RightEye;
        txtK1LeftEye.Text = ooex.K1LeftEye;
        txtK2RightEye.Text = ooex.K2RightEye;
        txtK2LeftEye.Text = ooex.K2LeftEye;


        txtComments.Text = ooex.Comments;
    }

    protected void UnloadData(OpticalObjectiveExamination ooex)
    {
        ooex.FarAcuity =  txtFarAcuity.Text;
        ooex.FarAxisLeftEye =  txtFarAxisLeftEye.Text;
        ooex.FarAxisRightEye =  txtFarAxisRightEye.Text;
        ooex.FarCenters =  txtFarCenter.Text;
        ooex.FarCylinderLeftEye =  txtFarCylinderLeftEye.Text;
        ooex.FarCylinderRightEye =  txtFarCylinderRightEye.Text;
        ooex.FarPrismLeftEye =  txtFarPrismLeftEye.Text;
        ooex.FarPrimsRightEye =  txtFarPrismRightEye.Text;
        ooex.FarSphericityLeftEye =  txtFarSphericityLefttEye.Text;
        ooex.FarSphericityRightEye =  txtFarSphericityRightEye.Text;
        ooex.FarVisualAcuityLeftEye =  txtFarVisualAcuityLeftEye.Text;
        ooex.FarVisualAcuityRightEye =  txtFarVisualAcuityRightEye.Text;

        ooex.CloseAcuity =  txtCloseAcuity.Text;
        ooex.CloseAxisLeftEye =  txtCloseAxisLeftEye.Text;
        ooex.CloseAxisRightEye =  txtCloseAxisRightEye.Text;
        ooex.CloseCenters =  txtCloseCenter.Text;
        ooex.CloseCylinderLeftEye =  txtCloseCylinderLeftEye.Text;
        ooex.CloseCylinderRightEye =  txtCloseCylinderRightEye.Text;
        ooex.ClosePrismLeftEye =  txtClosePrismLeftEye.Text;
        ooex.ClosePrismRightEye =  txtClosePrismRightEye.Text;
        ooex.CloseSphericityLeftEye =  txtCloseSphericityLefttEye.Text;
        ooex.CloseSphericityRightEye =  txtCloseSphericityRightEye.Text;
        ooex.CloseAcuityLeftEye =  txtCloseVisualAcuityLeftEye.Text;
        ooex.CloseAcuityRightEye =  txtCloseVisualAcuityRightEye.Text;

        ooex.BothAcuity =  txtBothAcuity.Text;
        ooex.BothAxisLeftEye =  txtBothAxisLeftEye.Text;
        ooex.BothAxisRightEye =  txtBothAxisRightEye.Text;
        ooex.BothCenters =  txtBothCenter.Text;
        ooex.BothCylinderLeftEye =  txtBothCylinderLeftEye.Text;
        ooex.BothCylinderRightEye =  txtBothCylinderRightEye.Text;
        ooex.BothPrismLeftEye =  txtBothPrismLeftEye.Text;
        ooex.BothPrismRightEye =  txtBothPrismRightEye.Text;
        ooex.BothSphericityLeftEye =  txtBothSphericityLefttEye.Text;
        ooex.BothSphericityRightEye =  txtBothSphericityRightEye.Text;
        ooex.BothAcuityLeftEye =  txtBothVisualAcuityLeftEye.Text;
        ooex.BothAcuityRightEye =  txtBothVisualAcuityRightEye.Text;

        ooex.K1RightEye = txtK1RightEye.Text;
        ooex.K1LeftEye = txtK1LeftEye.Text;
        ooex.K2RightEye = txtK2RightEye.Text;
        ooex.K2LeftEye = txtK2LeftEye.Text;

        ooex.Comments = txtComments.Text;
    }
    #endregion Auxiliary functions
}