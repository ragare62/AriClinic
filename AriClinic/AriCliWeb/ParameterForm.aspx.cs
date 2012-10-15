using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using AriCliModel;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class ParameterForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    AriCliModel.Parameter parameter; // it must spccified to aboid confussion
    int parameterId = 0;
    Permission per = null;
    string type = "";
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
                            where p.Code == "parameter"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }

        // There aren't query strings the object is read directly
        parameter = CntAriCli.GetParameter(ctx);
        LoadData(parameter);

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
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        if (!CreateChange())
            return;
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnServiceId_Click(object sender, ImageClickEventArgs e)
    {

    }
    #region Auxiliary functions
    protected bool DataOk()
    {
        if (txtServiceId.Text == "")
        {
            RadAjaxManager1.ResponseScripts.Add(String.Format("showDialog('{0}','{1}','warning',null,0,0);"
                ,Resources.GeneralResource.Warning
                ,Resources.GeneralResource.ServiceNeeded));
            return false;
        }

        return true;
    }

    /// <summary>
    /// As its name suggest if there isn't an object
    /// it'll create it. If exists It modifies it.
    /// </summary>
    /// <returns></returns>
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        parameter = CntAriCli.GetParameter(ctx);
        UnloadData(parameter);
        ctx.SaveChanges();
        return true;
    }

    protected void LoadData(AriCliModel.Parameter parameter)
    {
        if (parameter.PainPump != null)
        {
            txtServiceId.Text = parameter.PainPump.ServiceId.ToString();
            txtServiceName.Text = parameter.PainPump.Name;
        }
        chkChecked.Checked = parameter.UseNomenclator;
    }

    protected void UnloadData(AriCliModel.Parameter parameter)
    {
        Service ser = null;
        if (txtServiceId.Text != "")
            ser = CntAriCli.GetService(int.Parse(txtServiceId.Text), ctx);
        parameter.PainPump = ser;
        parameter.UseNomenclator = chkChecked.Checked;
        parameter.AppointmentExtension = chkAppointmentExtension.Checked;
    }


    #endregion Auxiliary functions

    #region Searching outside
    protected void txtServiceId_TextChanged(object sender, EventArgs e)
    {
        // search for a service
        Service ser = CntAriCli.GetService(Int32.Parse(txtServiceId.Text), ctx);
        if (ser != null)
        {
            txtServiceId.Text = ser.ServiceId.ToString();
            txtServiceName.Text = ser.Name;
        }
        else
        {
            txtServiceId.Text = "";
            txtServiceName.Text = Resources.GeneralResource.ServiceDoesNotExists;
        }
    }

    #endregion
}
