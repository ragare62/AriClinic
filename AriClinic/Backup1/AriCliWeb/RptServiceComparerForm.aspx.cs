using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AriCliWeb
{
    public partial class RptServiceComparerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click(object sender, ImageClickEventArgs e)
        {

            string command = String.Format("reportServiceComp()");

            RadAjaxManager1.ResponseScripts.Add(command);

        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            string command = "CancelEdit();";
            RadAjaxManager1.ResponseScripts.Add(command);
        }
    }
}