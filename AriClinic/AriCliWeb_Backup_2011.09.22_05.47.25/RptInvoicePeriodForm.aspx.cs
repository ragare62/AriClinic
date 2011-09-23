using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AriCliModel;

namespace AriCliWeb
{
    public partial class RptInvoicePeriodForm : System.Web.UI.Page
    {
        #region Variables declarations
        AriClinicContext ctx = null;
        User user = null;
        ServiceCategory scat = null;
        int serviceCategoryId = 0;
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
                //user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
                //Process proc = (from p in ctx.Processes
                //                where p.Code == "rtickets"
                //                select p).FirstOrDefault<Process>();
                //per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
                //btnAccept.Visible = per.Modify;
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
            if (!DataOk()) return;

            string command = String.Format("reportInvoicePeriod('{0}','{1}')"
                                           , rddpFromDate.SelectedDate
                                           , rddpToDate.SelectedDate);

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
            if (rddpFromDate.SelectedDate == null || rddpToDate.SelectedDate == null)
            {
                lblMessage.Text = Resources.GeneralResource.DateNeeded;
                return false;
            }
            if (rddpFromDate.SelectedDate > rddpToDate.SelectedDate)
            {
                lblMessage.Text = Resources.GeneralResource.FromGreatherThanTo;
                return false;
            }
            return true;
        }
        #endregion Auxiliary functions
    }
}