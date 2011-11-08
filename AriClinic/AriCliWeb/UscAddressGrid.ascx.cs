using AriCliModel;
using System;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace AriCliWeb
{
    public partial class UscAddressGrid : System.Web.UI.UserControl
    {
        #region Variables definition
        AriClinicContext ctx = null;
        HealthcareCompany hc = null;
        Clinic cl = null;
        Patient pat = null;
        Customer cus = null;
        Professional prof = null;
        int hcId = 0;
        int clinicId = 0;
        int patientId = 0;
        int customerId = 0;
        int professionalId = 0;
        string caller = "";

        #endregion Variables definition

        #region Init Load Unload events
        protected void Page_Init(object sender, EventArgs e)
        {
            ctx = new AriClinicContext("AriClinicContext");
            // security control, it must be a user logged
            if (Session["User"] == null)
                Response.Redirect("Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // First control the type of parent page
            if (Request.QueryString["HcId"] != null)
            {
                hcId = Int32.Parse(Request.QueryString["HcId"]);
                hc = CntAriCli.GetHealthCompany(ctx);
                caller = "hccom"; // Called by a Healthcare Company
            }
            if (Request.QueryString["ClinicId"] != null)
            {
                clinicId = Int32.Parse(Request.QueryString["ClinicId"]);
                cl = CntAriCli.GetClinic(clinicId, ctx);
                caller = "clinic"; // Called by a Healthcare Company
            }
            if (Request.QueryString["PatientId"] != null)
            {
                patientId = Int32.Parse(Request.QueryString["PatientId"]);
                pat = CntAriCli.GetPatient(patientId, ctx);
                caller = "patient";
            }
            if (Request.QueryString["CustomerId"] != null)
            {
                customerId = Int32.Parse(Request.QueryString["CustomerId"]);
                cus = CntAriCli.GetCustomer(customerId, ctx);
                caller = "customer";
            }
            if (Request.QueryString["ProfessionalId"] != null)
            {
                professionalId = Int32.Parse(Request.QueryString["ProfessionalId"]);
                prof = CntAriCli.GetProfessional(professionalId, ctx);
                caller = "professional";
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
                        Address adr = (from a in ctx.Addresses
                                       where a.AddressId == id
                                       select a).FirstOrDefault<Address>();
                        ctx.Delete(adr);
                        ctx.SaveChanges();
                        RefreshGrid(true);
                        break;
                }
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
                string command = "";
                GridDataItem gdi;
                int id = 0;

                id = (int)e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex][e.Item.OwnerTableView.DataKeyNames[0]];

                // assign javascript function to select button
                gdi = (GridDataItem)e.Item;

                // backgroud color for primary types
                if (gdi["Type"].Text == "Primary")
                {
                    gdi.BackColor = Color.LightCyan;
                }
                name = gdi["Street"].Text;

                // assign javascript function to edit button
                imgb = (ImageButton)e.Item.FindControl("Edit");
                command = String.Format("return EditAddressRecord({0});", id);
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
                case "hccom":
                    RadGrid1.DataSource = hc.Addresses;
                    break;
                case "clinic":
                    RadGrid1.DataSource = cl.Addresses;
                    break;
                case "patient":
                    RadGrid1.DataSource = pat.Addresses;
                    break;
                case "customer":
                    RadGrid1.DataSource = cus.Addresses;
                    break;
                case "professional":
                    RadGrid1.DataSource = prof.Addresses;
                    break;
            }
            // I must rebind?
            if (rebind) RadGrid1.Rebind();
        }
        #endregion
    }
}