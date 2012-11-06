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

public partial class PrescriptionGlassesForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Refractometry refractometry = null;
    PrescriptionGlasses prescriptionGlasses = null;
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
        if (Request.QueryString["PrescriptionGlassesId"] != null)
        {
            id = Int32.Parse(Request.QueryString["PrescriptionGlassesId"]);
            prescriptionGlasses = CntAriCli.GetPrescriptionGlasses(id, ctx);
            refractometry = prescriptionGlasses.Refractometry;
            LoadData(prescriptionGlasses);
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
        if (prescriptionGlasses == null)
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
        if (prescriptionGlasses == null)
        {
            prescriptionGlasses = new PrescriptionGlasses();
            prescriptionGlasses.Refractometry = refractometry;
            UnloadData(prescriptionGlasses);
            ctx.Add(prescriptionGlasses);
        }
        else
        {
            prescriptionGlasses = CntAriCli.GetPrescriptionGlasses(prescriptionGlasses.Id, ctx);
            UnloadData(prescriptionGlasses);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                                                          , Resources.GeneralResource.Success
                                                          , Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("PrescriptionGlassesForm.aspx?PrescriptionGlassesId={0}", prescriptionGlasses.Id));
        return true;
    }

    protected void LoadData(PrescriptionGlasses pg)
    {
        txtFarAxisLeftEye.Text =  pg.FarAxisLeftEye;
        txtFarAxisRightEye.Text =  pg.FarAxisRightEye;
        txtFarCenter.Text =  pg.FarCenters;
        txtFarCylinderLeftEye.Text =  pg.FarCylinderLeftEye;
        txtFarCylinderRightEye.Text =  pg.FarCylinderRightEye;
        txtFarPrismLeftEye.Text =  pg.FarPrismLeftEye;
        txtFarPrismRightEye.Text =  pg.FarPrimsRightEye;
        txtFarSphericityLefttEye.Text =  pg.FarSphericityLeftEye;
        txtFarSphericityRightEye.Text =  pg.FarSphericityRightEye;


        txtCloseAxisLeftEye.Text =  pg.CloseAxisLeftEye;
        txtCloseAxisRightEye.Text =  pg.CloseAxisRightEye;
        txtCloseCenter.Text =  pg.CloseCenters;
        txtCloseCylinderLeftEye.Text =  pg.CloseCylinderLeftEye;
        txtCloseCylinderRightEye.Text =  pg.CloseCylinderRightEye;
        txtClosePrismLeftEye.Text =  pg.ClosePrismLeftEye;
        txtClosePrismRightEye.Text =  pg.ClosePrismRightEye;
        txtCloseSphericityLefttEye.Text =  pg.CloseSphericityLeftEye;
        txtCloseSphericityRightEye.Text =  pg.CloseSphericityRightEye;


        txtBothAxisLeftEye.Text =  pg.BothAxisLeftEye;
        txtBothAxisRightEye.Text =  pg.BothAxisRightEye;
        txtBothCenter.Text =  pg.BothCenters;
        txtBothCylinderLeftEye.Text =  pg.BothCylinderLeftEye;
        txtBothCylinderRightEye.Text =  pg.BothCylinderRightEye;
        txtBothPrismLeftEye.Text =  pg.BothPrismLeftEye;
        txtBothPrismRightEye.Text =  pg.BothPrismRightEye;
        txtBothSphericityLefttEye.Text =  pg.BothSphericityLeftEye;
        txtBothSphericityRightEye.Text =  pg.BothSphericityRightEye;

        txtComments.Text = pg.Comments;
        txtSignMD.Text = pg.SignMD;
    }

    protected void UnloadData(PrescriptionGlasses gt)
    {
        gt.FarAxisLeftEye =  txtFarAxisLeftEye.Text;
        gt.FarAxisRightEye =  txtFarAxisRightEye.Text;
        gt.FarCenters =  txtFarCenter.Text;
        gt.FarCylinderLeftEye =  txtFarCylinderLeftEye.Text;
        gt.FarCylinderRightEye =  txtFarCylinderRightEye.Text;
        gt.FarPrismLeftEye =  txtFarPrismLeftEye.Text;
        gt.FarPrimsRightEye =  txtFarPrismRightEye.Text;
        gt.FarSphericityLeftEye =  txtFarSphericityLefttEye.Text;
        gt.FarSphericityRightEye =  txtFarSphericityRightEye.Text;

        gt.CloseAxisLeftEye =  txtCloseAxisLeftEye.Text;
        gt.CloseAxisRightEye =  txtCloseAxisRightEye.Text;
        gt.CloseCenters =  txtCloseCenter.Text;
        gt.CloseCylinderLeftEye =  txtCloseCylinderLeftEye.Text;
        gt.CloseCylinderRightEye =  txtCloseCylinderRightEye.Text;
        gt.ClosePrismLeftEye =  txtClosePrismLeftEye.Text;
        gt.ClosePrismRightEye =  txtClosePrismRightEye.Text;
        gt.CloseSphericityLeftEye =  txtCloseSphericityLefttEye.Text;
        gt.CloseSphericityRightEye =  txtCloseSphericityRightEye.Text;

        gt.BothAxisLeftEye =  txtBothAxisLeftEye.Text;
        gt.BothAxisRightEye =  txtBothAxisRightEye.Text;
        gt.BothCenters =  txtBothCenter.Text;
        gt.BothCylinderLeftEye =  txtBothCylinderLeftEye.Text;
        gt.BothCylinderRightEye =  txtBothCylinderRightEye.Text;
        gt.BothPrismLeftEye =  txtBothPrismLeftEye.Text;
        gt.BothPrismRightEye =  txtBothPrismRightEye.Text;
        gt.BothSphericityLeftEye =  txtBothSphericityLefttEye.Text;
        gt.BothSphericityRightEye =  txtBothSphericityRightEye.Text;

        gt.Comments = txtComments.Text;
        gt.SignMD = txtSignMD.Text;
    }

    #endregion Auxiliary functions

    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        string js = String.Format("printPrescription({0});", prescriptionGlasses.Id);
        RadAjaxManager1.ResponseScripts.Add(js);
        RadAjaxManager1.ResponseScripts.Add("CloseAndRebind('');");
    }
}