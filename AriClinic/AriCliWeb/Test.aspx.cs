using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class Test : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
        }
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        string title = "Confirmado";
        string message = "Silvia me está mirando?";
        string type = "success";
        string modal = "10";
        string width = "300";
        string heigth = "0";
        string command = String.Format("ariDialog('{0}','{1}','{2}',{3},{4},{5});"
                                       , title
                                       , message
                                       , type
                                       , modal
                                       , width
                                       , heigth);
        //command = "AskQuestion();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        
    }

    protected void RadToolBar1_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        var v = e.Item.Value;
    }
}
