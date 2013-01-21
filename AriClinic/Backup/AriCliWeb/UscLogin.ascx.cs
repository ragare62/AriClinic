using System;
using AriCliModel;
using Telerik.OpenAccess;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace AriCliWeb
{
    public partial class UscLogin : System.Web.UI.UserControl
    {
        AriClinicContext ctx = null; // context for access database
        #region Init Load Unload events
        protected void Page_Init(object sender, EventArgs e)
        {
            ctx = new AriClinicContext("AriClinicContext");
            LoadClinicCombo();
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
        
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            User user = CntAriCli.Login(txtPassword.Text, txtLogin.Text, ctx);
            if (user == null)
            {
                // Bad login
                string command = String.Format("showDialog('Error','{0}','error',null,0,0)", Resources.GeneralResource.BadLogin);
                RadAjaxManager.GetCurrent(Page).ResponseScripts.Add(command);
                //lblMessage.Text = Resources.GeneralResource.BadLogin;
                return;
            }
            Session["User"] = user; // stores user in a ssesion variable.
            Clinic cl = CntAriCli.GetClinic(Int32.Parse(rdcbClinic.SelectedValue), ctx);
            Session["Clinic"] = cl;
            if (user.Professionals.Count > 0)
                Session["Professional"] = user.Professionals[0];
            // Write log
            CntAriCli.WriteLog(user, DateTime.Now, Request.ServerVariables["REMOTE_ADDR"], "Default.aspx", "Login", ctx);
            Response.Redirect("MainMenu.aspx");
        }

        protected void LoadClinicCombo()
        {
            rdcbClinic.Items.Clear();
            foreach (Clinic cl in ctx.Clinics) 
            { 
                rdcbClinic.Items.Add(new RadComboBoxItem(cl.Name,cl.ClinicId.ToString()));
                if (Request.ServerVariables["REMOTE_ADDR"] == cl.RemoteIp)
                    rdcbClinic.SelectedValue = cl.ClinicId.ToString();
            }
        }
    }
}