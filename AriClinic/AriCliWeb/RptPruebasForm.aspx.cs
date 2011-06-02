using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AriCliModel;

namespace AriCliWeb
{
    public partial class RptPruebasForm : System.Web.UI.Page
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
             //security control, it must be a user logged
            if (Session["User"] == null)
                Response.Redirect("Default.aspx");
            else
            {
                user = (User)Session["User"];
                Process proc = (from p in ctx.Processes
                                where p.Code == "rtickets"
                                select p).FirstOrDefault<Process>();
                per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
                btnAccept.Visible = per.Modify;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion
        protected void Button1_Click(object sender, EventArgs e)
        {
            string command = String.Format("reportTicket('{0}')"
                                            ,txtIdTicket.Text);

            RadAjaxManager1.ResponseScripts.Add(command);
        }

        protected void btnServNote_Click(object sender, EventArgs e)
        {
            string command = String.Format("reportServiceNote('{0}')"
                                            , txtServNote.Text);

            RadAjaxManager1.ResponseScripts.Add(command);
        }

        protected void btnAnesNote_Click(object sender, EventArgs e)
        {
            string command = String.Format("reportAnesNote('{0}')"
                                            , txtAnesNote.Text);

            RadAjaxManager1.ResponseScripts.Add(command);
        }

        protected void BtnInvoice_Click(object sender, EventArgs e)
        {
            string command = String.Format("reportInvoice('{0}')"
                                            , txtInvoice.Text);

            RadAjaxManager1.ResponseScripts.Add(command);
        }

        protected void btnparaminvoice_Click(object sender, EventArgs e)
        {
            
            string command = String.Format("reportParamInvoice('{0}', '{1}')"
                                            , pikdesde.SelectedDate, pikhasta.SelectedDate);
            
            RadAjaxManager1.ResponseScripts.Add(command);
        }
    }
}