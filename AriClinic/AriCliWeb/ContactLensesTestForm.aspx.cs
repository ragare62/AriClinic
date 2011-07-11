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

public partial class ContactLensesTestForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Refractometry refractometry = null;
    ContactLensesTest ContactLensesTest = null;
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
        if (Request.QueryString["ContactLensesTestId"] != null)
        {
            id = Int32.Parse(Request.QueryString["ContactLensesTestId"]);
            ContactLensesTest = CntAriCli.GetContactLensesTest(id, ctx);
            refractometry = ContactLensesTest.Refractometry;
            LoadData(ContactLensesTest);
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
        if (ContactLensesTest == null)
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
        if (ContactLensesTest == null)
        {
            ContactLensesTest = new ContactLensesTest();
            ContactLensesTest.Refractometry = refractometry;
            UnloadData(ContactLensesTest);
            ctx.Add(ContactLensesTest);
        }
        else
        {
            ContactLensesTest = CntAriCli.GetContactLensesTest(ContactLensesTest.Id, ctx);
            UnloadData(ContactLensesTest);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                ,Resources.GeneralResource.Success
                ,Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("ContactLensesTestForm.aspx?ContactLensesTestId={0}",ContactLensesTest.Id));
        return true;
    }

    protected void LoadData(ContactLensesTest clt)
    {
        txtCloseAcuityBothEyes.Text = CntWeb.GetPossibleNull(clt.CloseVisualAcuityBothEyes);
        txtCloseAcuityLeftEye.Text = CntWeb.GetPossibleNull(clt.CloseVisualAcuityLeftEye);
        txtCloseAcuityRightEye.Text = CntWeb.GetPossibleNull(clt.CloseVisualAcuityRightEye);

        txtFarAcuityBothEyes.Text = CntWeb.GetPossibleNull(clt.FarVisualAcuityBothEyes);
        txtFarAcuityLeftEye.Text = CntWeb.GetPossibleNull(clt.FarVisualAcuityLeftEye);
        txtFarAcuityRightEye.Text = CntWeb.GetPossibleNull(clt.FarVisualAcuityRightEye);

        txtComments.Text = clt.Comments;
    }

    protected void UnloadData(ContactLensesTest clt)
    {
        clt.CloseVisualAcuityBothEyes = CntWeb.SetPossibleNull(txtCloseAcuityBothEyes.Text);
        clt.CloseVisualAcuityLeftEye = CntWeb.SetPossibleNull(txtCloseAcuityLeftEye.Text);
        clt.CloseVisualAcuityRightEye = CntWeb.SetPossibleNull(txtCloseAcuityRightEye.Text);

        clt.FarVisualAcuityBothEyes = CntWeb.SetPossibleNull(txtFarAcuityBothEyes.Text);
        clt.FarVisualAcuityLeftEye = CntWeb.SetPossibleNull(txtFarAcuityLeftEye.Text);
        clt.FarVisualAcuityRightEye = CntWeb.SetPossibleNull(txtFarAcuityRightEye.Text);

        clt.Comments = txtComments.Text;
    }
    #endregion Auxiliary functions
}