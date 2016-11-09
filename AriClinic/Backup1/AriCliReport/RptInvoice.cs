namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using AriCliModel;

    /// <summary>
    /// Summary description for RptInvoice.
    /// </summary>
    public partial class RptInvoice : Telerik.Reporting.Report
    {
        static string companyname;
        static Address companyaddress;
        static Telephone companytelf;
        static Email companyemail;
        static string companynif;
        static Address customeraddress;
       
        public RptInvoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
       
        public RptInvoice(int idInvoice, AriClinicContext ctx1)
        : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            HealthcareCompany healthcare = CntAriCli.GetHealthCompany(ctx1);
            companyname = healthcare.Name;
            
            foreach (Address item in healthcare.Addresses)
            {
                if (item.Type == "Primary")
                    companyaddress = item;
            }
            
            foreach (Telephone item in healthcare.Telephones)
            {
                if (item.Type == "Primary")
                    companytelf = item;
            }
            
            foreach (Email item in healthcare.Emails)
            {
                if (item.Type == "Primary")
                    companyemail = item;
            }
            
            companynif = healthcare.VATIN;

            Invoice invoice = CntAriCli.GetInvoice(idInvoice, ctx1);

            if (invoice != null)
            {
                foreach (Address item in invoice.Customer.Addresses)
                {
                    if (item.Type == "Primary")
                        customeraddress = item;
                }
                
                this.DataSource = invoice;
                //this.subReport1.ReportSource.DataSource = invoice.InvoiceLines;
                //this.subReport2.ReportSource.DataSource = invoice.InvoiceLines;
                this.subReport1.Report.DataSource = invoice.InvoiceLines;
                this.subReport2.Report.DataSource = invoice.InvoiceLines;
            }
        }

        public static string GetCustomerAddres1()
        {
            if (customeraddress != null)
            {
                return customeraddress.Street + " ";
            }
            else
                return "";
        }

        public static string GetCustomerAddres2()
        {
            if (customeraddress != null)
            {
                return customeraddress.PostCode + " " + customeraddress.City + " (" + customeraddress.Province + ")";
            }
            else return "";
        }

        public static string GetCompanyName()
        {
            return companyname;
        }

        public static string GetCompanyAddres1()
        {
            return companyaddress.Street + " " + companyaddress.PostCode + " " + companyaddress.City + " (" + companyaddress.Province + ")";
        }
       
        public static string GetCompanycontact()
        {
            return "Teléfono:" + companytelf.Number + " - Email:" + companyemail.Url;
        }

        public static string GetCompanyNif()
        {
            return companynif;
        }
    }
}