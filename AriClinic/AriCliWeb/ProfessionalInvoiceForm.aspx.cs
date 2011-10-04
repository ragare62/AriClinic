using System;
using AriCliModel;
using AriCliWeb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

namespace AriCliWeb
{
    public partial class ProfessionalInvoiceForm : System.Web.UI.Page
    {

        #region Variables declarations
        AriClinicContext ctx = null;
        User user = null;
        Clinic cl = null;
        HealthcareCompany hc = null;
        Professional prof = null;
        ProfessionalInvoice inv = null;
        int healthCareCompanyId = 0;
        int ProfessionalId = 0;
        int invoiceId = 0;
        string caller = "";
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
                user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
                Process proc = (from p in ctx.Processes
                                where p.Code == "profInvoice"
                                select p).FirstOrDefault<Process>();
                per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
                btnAccept.Visible = per.Modify;
            }
            hc = CntAriCli.GetHealthCompany(ctx);
            // 
            if (Request.QueryString["InvoiceId"] != null)
            {
                invoiceId = Int32.Parse(Request.QueryString["InvoiceId"]);
                inv = CntAriCli.GetProfessionalInvoice(invoiceId, ctx);
                LoadData(inv);
            }
            else
            {
                // deafault values
                rddpInvoiceDate.SelectedDate = DateTime.Now;
                txtYear.Text = DateTime.Now.Year.ToString();
            }
            //
            if (Request.QueryString["Caller"] != null)
                caller = Request.QueryString["Caller"];

            if (Session["Clinic"] != null)
                cl = (Clinic)Session["Clinic"];
            // always read Healt care company
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
            string command = "";
            if (inv == null)
                command = "CloseAndRebind('new')";
            else
                command = "CloseAndRebind('')";
            if (!CreateChange())
                return;
            if (caller == "sn") command = "CancelEdit();";
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
            // check date
            if (rddpInvoiceDate.SelectedDate == null)
            {
                lblMessage.Text = Resources.GeneralResource.DateNeeded;
                return false;
            }
            // check if there're invoices with older date
            if (inv == null)
            {
                if (!CntAriCli.CorrectProfessionalInvoiceDate((DateTime)rddpInvoiceDate.SelectedDate, prof))
                {
                    lblMessage.Text = Resources.GeneralResource.IncorrectInvoiceDate;
                    return false;
                }
            }
            return true;
        }

        protected bool CreateChange()
        {
            if (!DataOk())
                return false;
            if (inv == null)
            {
                inv = new ProfessionalInvoice();
                UnloadData(inv);
                ctx.Add(inv);
            }
            else
            {
                inv = CntAriCli.GetProfessionalInvoice(invoiceId, ctx);
                UnloadData(inv);
            }
            ctx.SaveChanges();
            return true;
        }

        protected void LoadData(ProfessionalInvoice inv)
        {
            txtInvoiceId.Text = inv.InvoiceId.ToString();
            txtInvoiceSerial.Text = inv.Serial;//.Serial;
            txtYear.Text = inv.Year.ToString();
            txtInvoiceNumber.Text = String.Format("{0:000000}", inv.InvoiceNumber);
            rddpInvoiceDate.SelectedDate = inv.InvoiceDate;
            txtProfessionalId.Text = inv.Professional.PersonId.ToString();
            txtProfessionalName.Text = inv.Professional.ComercialName;
            txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", inv.Total);
        }

        protected void UnloadData(ProfessionalInvoice inv)
        {
            //inv.Serial = txtInvoiceSerial.Text;
            inv.Year = Int32.Parse(txtYear.Text);
            inv.Serial = txtInvoiceSerial.Text;
            if (inv.InvoiceNumber == 0)
            {
                try
                {
                    inv.InvoiceNumber = CntAriCli.GetNextProfessionalInvoiceNumber(inv.Professional, inv.Year, ctx);
                }
                catch (NullReferenceException nre)
                {
                    inv.InvoiceNumber = 1;
                }
            }

            inv.InvoiceDate = (DateTime)rddpInvoiceDate.SelectedDate;
            ProfessionalId = Int32.Parse(txtProfessionalId.Text);
            inv.Professional = CntAriCli.GetProfessional(ProfessionalId, ctx);
            inv.Total = CntAriCli.GetProfessionalInvoiceTotal(inv);
        }

        #endregion Auxiliary functions

        #region Searching outside
        //protected void txtProfessionalId_TextChanged(object sender, EventArgs e)
        //{
        //    // search for a Professional
        //    ProfessionalId = Int32.Parse(txtProfessionalId.Text);
        //    prof = CntAriCli.GetProfessional(ProfessionalId, ctx);
        //    if (prof != null)
        //    {
        //        txtProfessionalId.Text = prof.PersonId.ToString();
        //        txtProfessionalName.Text = prof.ComercialName;
        //        txtInvoiceSerial.Text = prof.InvoiceSerial;
        //    }
        //    else
        //    {
        //        txtProfessionalId.Text = "";
        //        txtProfessionalName.Text = Resources.GeneralResource.ProfessionalDoesNotExists;
        //    }
        //}

        //protected void btnProfessionalId_Click(object sender, ImageClickEventArgs e)
        //{
        //    // We search only tickets that belongs to that Professional 
        //    // and are not invoiced
           
        //}

        #endregion

        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            UscProfessionalInvoiceLineGrid1.RefreshGrid(true);
            txtInvoiceTotal.Text = String.Format("{0:####,#0.00}", CntAriCli.GetProfessionalInvoiceTotal(inv));
        }

        protected void btnProfessioanlId_Click(object sender, ImageClickEventArgs e)
        {
            string command = "searchProfessional();";
            RadAjaxManager1.ResponseScripts.Add(command);
        }

        protected void txtProfessionalName_TextChanged(object sender, EventArgs e)
        {
            ProfessionalId = Int32.Parse(txtProfessionalId.Text);
            prof = CntAriCli.GetProfessional(ProfessionalId, ctx);
            if (prof != null)
            {
                txtProfessionalId.Text = prof.PersonId.ToString();
                txtProfessionalName.Text = prof.ComercialName;
                txtInvoiceSerial.Text = prof.InvoiceSerial;
            }
            else
            {
                txtProfessionalId.Text = "";
                txtProfessionalName.Text = Resources.GeneralResource.ProfessionalDoesNotExists;
            }
        }

    }
}