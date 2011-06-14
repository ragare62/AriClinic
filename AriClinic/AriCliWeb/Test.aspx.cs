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
using AriCliModel;
using System.Linq;

public partial class Test : System.Web.UI.Page 
{
    AriClinicContext ctx = new AriClinicContext("AriClinicContext");
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //RadComboBox1.DataSource = ctx.Patients;
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

    protected void RadComboBox1_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        RadComboBox combo = (RadComboBox)sender;
        var rs = from p in ctx.Patients
                 orderby p.FullName ascending
                 where p.FullName.StartsWith(e.Text)
                 select p;
        foreach (Patient pat in rs)
        {
            combo.Items.Add(new RadComboBoxItem(pat.FullName,pat.PersonId.ToString()));
        }
    }

    protected void RadComboBox1_ItemsRequested1(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.Text == "") return;
        RadComboBox combo = (RadComboBox)sender;
        var rs = from p in ctx.Patients
                 where p.FullName.StartsWith(e.Text)
                 select p;
        foreach (Patient pat in rs)
        {
            combo.Items.Add(new RadComboBoxItem(pat.FullName, pat.PersonId.ToString()));
        }
    }

}
