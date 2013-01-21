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

public partial class MotAppendForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    OphthalmologicVisit oVisit = null;
    MotAppend mot = null;
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
        if (Request.QueryString["MotAppendId"] != null)
        {
            id = Int32.Parse(Request.QueryString["MotAppendId"]);
            mot = CntAriCli.GetMotAppend(id, ctx);
            oVisit = mot.OphthalmologicVisit;
            LoadData(mot);
        }
        if (Request.QueryString["OphVisitId"] != null)
        {
            id = int.Parse(Request.QueryString["OphVisitId"]);
            oVisit = (OphthalmologicVisit)CntAriCli.GetVisit(id, ctx);
            if (oVisit.MotAppends.Count > 0)
            {
                mot = oVisit.MotAppends[0];
                LoadData(mot);
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
        if (mot == null)
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
        if (mot == null)
        {
            mot = new MotAppend();
            mot.OphthalmologicVisit = oVisit;
            UnloadData(mot);
            ctx.Add(mot);
        }
        else
        {
            mot = CntAriCli.GetMotAppend(mot.Id, ctx);
            UnloadData(mot);
        }
        ctx.SaveChanges();
        RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','success',null,0,0)"
                ,Resources.GeneralResource.Success
                ,Resources.GeneralResource.CorrectlyStored));
        Response.Redirect(String.Format("MotAppendForm.aspx?MotAppendId={0}",mot.Id));
        return true;
    }

    protected void LoadData(MotAppend mot)
    {
        txtEyeMotility.Text = mot.EyeMotility;
        txtEyebrows.Text = mot.Eyebrows;
        txtPeriocularArea.Text = mot.PeriocularArea;
        txtComments.Text = mot.Comments;
        if (mot.C1RE != null) txtC1RE.Value = (double)mot.C1RE;
        if (mot.C1LE != null) txtC1LE.Value = (double)mot.C1LE;
        if (mot.C2RE != null) txtC2RE.Value = (double)mot.C2RE;
        if (mot.C2LE != null) txtC2LE.Value = (double)mot.C2LE;
        if (mot.C3RE != null) txtC3RE.Value = (double)mot.C3RE;
        if (mot.C3LE != null) txtC3LE.Value = (double)mot.C3LE;
        if (mot.C4RE != null) txtC4RE.Value = (double)mot.C4RE;
        if (mot.C4LE != null) txtC4LE.Value = (double)mot.C4LE;
        if (mot.C5RE != null) txtC5RE.Value = (double)mot.C5RE;
        if (mot.C5LE != null) txtC5LE.Value = (double)mot.C5LE;
        if (mot.C6RE != null) txtC6RE.Value = (double)mot.C6RE;
        if (mot.C6LE != null) txtC6LE.Value = (double)mot.C6LE;
        if (mot.C7RE != null) txtC7RE.Value = (double)mot.C7RE;
        if (mot.C7LE != null) txtC7LE.Value = (double)mot.C7LE;
        if (mot.C8RE != null) txtC8RE.Value = (double)mot.C8RE;
        if (mot.C8LE != null) txtC8LE.Value = (double)mot.C8LE;
        if (mot.C9RE != null) txtC9RE.Value = (double)mot.C9RE;
        if (mot.C9LE != null) txtC9LE.Value = (double)mot.C9LE;
        if (mot.C10RE != null) txtC10RE.Value = (double)mot.C10RE;
        if (mot.C10LE != null) txtC10LE.Value = (double)mot.C10LE;
        if (mot.C11RE != null) txtC11RE.Value = (double)mot.C11RE;
        if (mot.C11LE != null) txtC11LE.Value = (double)mot.C11LE;
        if (mot.C12RE != null) txtC12RE.Value = (double)mot.C12RE;
        if (mot.C12LE != null) txtC12LE.Value = (double)mot.C12LE;
    }

    protected void UnloadData(MotAppend mot)
    {
        mot.EyeMotility = txtEyeMotility.Text ;
        mot.Eyebrows = txtEyebrows.Text;
        mot.PeriocularArea = txtPeriocularArea.Text;
        mot.Comments = txtComments.Text;
        if (txtC1RE.Value != null) mot.C1RE = (decimal)txtC1RE.Value;
        if (txtC1LE.Value != null) mot.C1LE = (decimal)txtC1LE.Value;
        if (txtC2RE.Value != null) mot.C2RE = (decimal)txtC2RE.Value;
        if (txtC2LE.Value != null) mot.C2LE = (decimal)txtC2LE.Value;
        if (txtC3RE.Value != null) mot.C3RE = (decimal)txtC3RE.Value;
        if (txtC3LE.Value != null) mot.C3LE = (decimal)txtC3LE.Value;
        if (txtC4RE.Value != null) mot.C4RE = (decimal)txtC4RE.Value;
        if (txtC4LE.Value != null) mot.C4LE = (decimal)txtC4LE.Value;
        if (txtC5RE.Value != null) mot.C5RE = (decimal)txtC5RE.Value;
        if (txtC5LE.Value != null) mot.C5LE = (decimal)txtC5LE.Value;
        if (txtC6RE.Value != null) mot.C6RE = (decimal)txtC6RE.Value;
        if (txtC6LE.Value != null) mot.C6LE = (decimal)txtC6LE.Value;
        if (txtC7RE.Value != null) mot.C7RE = (decimal)txtC7RE.Value;
        if (txtC7LE.Value != null) mot.C7LE = (decimal)txtC7LE.Value;
        if (txtC8RE.Value != null) mot.C8RE = (decimal)txtC8RE.Value;
        if (txtC8LE.Value != null) mot.C8LE = (decimal)txtC8LE.Value;
        if (txtC9RE.Value != null) mot.C9RE = (decimal)txtC9RE.Value;
        if (txtC9LE.Value != null) mot.C9LE = (decimal)txtC9LE.Value;
        if (txtC10RE.Value != null) mot.C10RE = (decimal)txtC10RE.Value;
        if (txtC10LE.Value != null) mot.C10LE = (decimal)txtC10LE.Value;
        if (txtC11RE.Value != null) mot.C11RE = (decimal)txtC11RE.Value;
        if (txtC11LE.Value != null) mot.C11LE = (decimal)txtC11LE.Value;
        if (txtC12RE.Value != null) mot.C12RE = (decimal)txtC12RE.Value;
        if (txtC12LE.Value != null) mot.C12LE = (decimal)txtC12LE.Value;
    }
    #endregion Auxiliary functions
}