using System;
using System.Linq;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;
using AriCliWeb;
using System.Web.UI.HtmlControls;

public partial class ServiceSubCategoryGrid : System.Web.UI.Page 
{
    AriClinicContext ctx = null;
    User user = null;
    HealthcareCompany hc = null;
    string type = "";
    Permission per = null;
    int serviceId = 0;

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
        //cheks if is call from customer form tabs
        if (type == "InTab")
        {
            HtmlControl tt = (HtmlControl)this.FindControl("TitleArea");
            tt.Attributes["class"] = "ghost";
        }
        // cheks if is call from another form
        if (Request.QueryString["Type"] != null)
            type = Request.QueryString["Type"];
        // translate filters
        CntWeb.TranslateRadGridFilters(RadGrid1);
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
    #region Grid treatment
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        // load grid data
        RadGrid1.DataSource = ctx.ServiceSubCategories;
    }

    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            ImageButton imgb = (ImageButton)e.Item.FindControl("New");
            imgb.Visible = per.Create;
        }
        if (e.Item is GridDataItem)
        {
            ImageButton imgb = null;
            string name = "";
            string command = "";
            GridDataItem gdi;
            int id = 0;
            
            id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];

            // assign javascript function to select button
            imgb = (ImageButton)e.Item.FindControl("Select");
            gdi = (GridDataItem)e.Item;
            name = gdi["Name"].Text;
            command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');"
                                    , id.ToString()
                                    , null
                                    , name
                                    , null
                                    , "ServiceSubCategory");
            imgb.OnClientClick = command;
            if (type != "S") imgb.Visible = false; // not called from another form

            // assign javascript function to edit button
            imgb = (ImageButton)e.Item.FindControl("Edit");
            command = String.Format("return EditServiceSubCategoryRecord({0});", id);
            imgb.OnClientClick = command;

            // assigning javascript functions to delete button
            imgb = (ImageButton)e.Item.FindControl("Delete");
            string message = Resources.GeneralResource.DeleteRecordQuestion;
            message = String.Format("{0}<br/>{1}", message, name);
            command = String.Format("ariDialog('Subcategorias de servicios','{0}','prompt',null,0,0)", message);
            //command = String.Format("return confirm('{0} {1}');", Resources.GeneralResource.DeleteRecordQuestion, name);
            //imgb.OnClientClick = command;
            imgb.Visible = per.Create;
        }
    }

    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        // weonly process commands with a datasource (our image buttons)
        if (e.CommandSource == null)
            return;
        string typeOfControl = e.CommandSource.GetType().ToString();
        if (typeOfControl.Equals("System.Web.UI.WebControls.ImageButton"))
        {
            int id = 0;
            ImageButton imgb = (ImageButton)e.CommandSource;
            if (imgb.ID != "New" && imgb.ID != "Exit")
                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];
            switch (imgb.ID)
            {
                case "Select":
                    break;
                case "Edit":
                    break;
                case "Delete":
                    Session["DeleteId"] = id;
                    string message = Resources.GeneralResource.DeleteRecordQuestion;
                    GridDataItem gdi = (GridDataItem)e.Item;
                    message = String.Format("{0}<br/>{1}", message, gdi["Name"].Text);
                    string command = String.Format("ariDialog('Subcategorias de servicios','{0}','prompt',null,0,0)", message);
                    RadAjaxManager1.ResponseScripts.Add(command);


                    //Service ser = (from s in ctx.Services
                    //               where s.ServiceId == id
                    //               select s).FirstOrDefault<Service>();
                    //ctx.Delete(ser);
                    //ctx.SaveChanges();
                    //RefreshGrid();
                    break;
            }
        }
    }

    #endregion Grid treatment

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
            RefreshGrid();
            if (e.Argument == "new")
            {
                RadGrid1.CurrentPageIndex = RadGrid1.PageCount - 1;
                RadGrid1.Rebind();
            }
            if (e.Argument == "yes")
            {
                if (Session["DeleteId"] != null)
                {
                    try
                    {
                        serviceId = (int)Session["DeleteId"];
                        ServiceSubCategory serSub = (from s in ctx.ServiceSubCategories
                                       where s.ServiceSubCategoryId == serviceId
                                       select s).FirstOrDefault<ServiceSubCategory>();
                        ctx.Delete(serSub);
                        ctx.SaveChanges();
                        RefreshGrid();
                        Session["DeleteId"] = null;
                    }
                    catch (Exception ex)
                    {
                        Session["Exception"] = ex;
                        string command = String.Format("showDialog('Error','{0}','error',null, 0, 0)"
                            , Resources.GeneralResource.DeleteRecordFail);
                        RadAjaxManager1.ResponseScripts.Add(command);
                    }
                }
            }


    }

    protected void RefreshGrid()
    {
        RadGrid1.DataSource = ctx.ServiceSubCategories;
        RadGrid1.Rebind();
    }
}
