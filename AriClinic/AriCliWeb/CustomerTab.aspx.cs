using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Web.UI.HtmlControls;

public partial class CustomerTab : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    Customer cus = null;
    int customerId = 0;
    string type = "";
    Permission per = null;
    HtmlControl frame = null;
    

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
                            where p.Code == "scat"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // read patient information
        if (Request.QueryString["CustomerId"] != null)
        {
            customerId = Int32.Parse(Request.QueryString["CustomerId"]);
            cus = CntAriCli.GetCustomer(customerId, ctx);
            lblTitle.Text = String.Format("Historial administrativo: {0}", cus.FullName);
            this.Title = String.Format("Historial administrativo: {0}", cus.FullName);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            frame = (HtmlControl)this.FindControl("FrmArea");
            frame.Attributes["src"] = String.Format("CustomerForm.aspx?CustomerId={0}&Type=InTab", cus.PersonId);
            
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }

    #endregion Init Load Unload events

    #region Tab events
    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        frame = (HtmlControl)this.FindControl("FrmArea");
        switch (e.Tab.Value)
        {
            case "patient":
                frame.Attributes["src"] = String.Format("CustomerForm.aspx?CustomerId={0}&Type=InTab", cus.PersonId);
                break;
            case "policy":
                frame.Attributes["src"] = String.Format("PolicyGrid.aspx?CustomerId={0}&Type=InTab", cus.PersonId);
                break;
            case "ticket":
                frame.Attributes["src"] = String.Format("TicketGrid.aspx?CustomerId={0}&Type=InTab", cus.PersonId);
                break;
            case "invoice":
                frame.Attributes["src"] = String.Format("InvoiceGrid.aspx?CustomerId={0}&Type=InTab", cus.PersonId);
                break;
            case "payment":
                frame.Attributes["src"] = String.Format("PaymentGrid.aspx?CustomerId={0}&Type=InTab", cus.PersonId);
                break;

        }
    }
    #endregion
}
