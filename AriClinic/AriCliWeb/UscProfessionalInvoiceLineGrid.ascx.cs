using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AriCliModel;
using Telerik.Web.UI;

namespace AriCliWeb
{
    public partial class UscProfessionalInvoiceLineGrid : System.Web.UI.UserControl
    {

        #region Variables definition
        AriClinicContext ctx = null;
        ProfessionalInvoice inv = null;
        ProfessionalInvoiceLine invl = null;
        int invoiceId = 0;
        int invoiceLineId = 0;

        User user = null;
        string caller = "";
        string type = "";

        #endregion Variables definition

        #region Init Load Unload events
        protected void Page_Init(object sender, EventArgs e)
        {
            ctx = new AriClinicContext("AriClinicContext");
            // security control, it must be a user logged
            if (Session["User"] == null)
                Response.Redirect("Default.aspx");
            // 
            if (Request.QueryString["Type"] != null)
            {
                type = Request.QueryString["Type"];
            }
            // translate filters
            CntWeb.TranslateRadGridFilters(RadGrid1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // First control the type of parent page
            if (Request.QueryString["InvoiceId"] != null)
            {
                invoiceId = Int32.Parse(Request.QueryString["InvoiceId"]);
                inv = CntAriCli.GetProfessionalInvoice(invoiceId, ctx);
                caller = "invoice"; // Called by Insurance
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // close context to release resources
            if (ctx != null)
                ctx.Dispose();
        }

        #endregion Init Load Unload events
        #region Grid events
        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                // we only process commands with a datasource (our image buttons)
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
                            invl = CntAriCli.GetProfessionalInvoiceLine(id, ctx);
                            ctx.Delete(invl);
                            ctx.SaveChanges();
                            RefreshGrid(true);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Label lbl = (Label)this.Parent.FindControl("lblMessage");
                lbl.Text = ex.Message;

            }
        }

        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RefreshGrid(false);
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                ImageButton imgb = null;
                string name = "";
                string price = "";
                string command = "";
                GridDataItem gdi;
                int id = 0;

                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];

                // assign javascript function to select button
                gdi = (GridDataItem)e.Item;
                imgb = (ImageButton)e.Item.FindControl("Select");
                name = gdi["Description"].Text;
                price = gdi["Amount"].Text.Replace("€", "");
                command = String.Format("return Selection('{0}','{1}','{2}','{3}','{4}');"
                                        , id.ToString()
                                        , price
                                        , name
                                        , null
                                        , "InsuranceService");
                imgb.OnClientClick = command;
                if (type != "S") imgb.Visible = false; // not called from another form

                // assign javascript function to edit button
                imgb = (ImageButton)e.Item.FindControl("Edit");
                command = String.Format("return EditInvoiceLineRecord({0});", id);
                imgb.OnClientClick = command;

                // assigning javascript functions to delete button
                imgb = (ImageButton)e.Item.FindControl("Delete");
                command = String.Format("return confirm('{0} {1}');"
                                        , Resources.GeneralResource.DeleteRecordQuestion
                                        , name);
                imgb.OnClientClick = command;
            }
        }

        #endregion

        #region Auxliary functions
        public void RefreshGrid(bool rebind)
        {
            // Who is the caller?
            switch (caller)
            {
                case "invoice":
                    RadGrid1.DataSource = inv.ProfessionalInvoiceLines;
                    break;
            }
            // I must rebind?
            if (rebind) RadGrid1.Rebind();
        }
        #endregion
    }
}