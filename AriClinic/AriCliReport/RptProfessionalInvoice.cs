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
    public partial class RptProfessionalInvoice : Telerik.Reporting.Report
    {
        static string companyname="";
        static Address companyaddress=new Address();
        static Telephone companytelf=new Telephone();
        static Email companyemail=new Email();
        static string companynif="";

        static string professionalname="";
        static Address professionaladdress=new Address();
        static Telephone professionaltelf=new Telephone();
        static Email professionalemail=new Email();
        static string professionalnif="";

        static ProfessionalInvoice invoice;
       
        public RptProfessionalInvoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptProfessionalInvoice(int idInvoice, AriClinicContext ctx1)
        : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");

            invoice = CntAriCli.GetProfessionalInvoice(idInvoice, ctx1);

            if (invoice != null)
            {
                this.DataSource = invoice;
                //this.subReport1.ReportSource.DataSource = invoice.ProfessionalInvoiceLines;
                //this.subReport2.ReportSource.DataSource = invoice.ProfessionalInvoiceLines;
                this.subReport1.Report.DataSource = invoice.ProfessionalInvoiceLines;
                this.subReport2.Report.DataSource = invoice.ProfessionalInvoiceLines;
                HealthcareCompanyData(ctx1);
                ProfessionalData(invoice);
            }
        }

        public static string getCodFactura()
        {
            return String.Format("{0}-{1:000000}", invoice.Serial, invoice.InvoiceNumber);
        }

        public static decimal getPorceRetencion()
        {
            decimal total = 0;
            decimal ivas = 0;
            foreach (ProfessionalInvoiceLine item in invoice.ProfessionalInvoiceLines)
            {
                total += item.Amount;
                ivas += item.Amount * item.TaxPercentage/100;
            }

            return (total - ivas) * invoice.Professional.TaxWithholdingType.Percentage/100;
        }

        public static decimal getBaseRetencion()
        {
            decimal total = 0;
            decimal ivas = 0;
            foreach (ProfessionalInvoiceLine item in invoice.ProfessionalInvoiceLines)
            {
                total += item.Amount;
                ivas += item.Amount * item.TaxPercentage / 100;
            }

            return total - ivas;
        }

        #region[Professional]
        private void ProfessionalData(ProfessionalInvoice Invoice)
        {
            Professional profesional = Invoice.Professional;
            professionalname = profesional.ComercialName;

            foreach (Address item in profesional.Addresses)
            {
                if (item.Type == "Primary")
                    professionaladdress = item;
            }            

            foreach (Telephone item in profesional.Telephones)
            {
                if (item.Type == "Primary")
                    professionaltelf = item;
            }

            foreach (Email item in profesional.Emails)
            {
                if (item.Type == "Primary")
                    professionalemail = item;
            }

            professionalnif = profesional.VATIN;
        }

        public static string GetProfessionalName()
        {
            return professionalname;
        }

        public static string GetProfessionalAddres1()
        {
            return professionaladdress.Street + " " + professionaladdress.PostCode + " " + professionaladdress.City + " (" + professionaladdress.Province + ")";
        }

        public static string GetProfessionalcontact()
        {
            return "Teléfono:" + professionaltelf.Number + " - Email:" + professionalemail.Url;
        }

        public static string GetProfessionalNif()
        {
            return professionalnif;
        }
        #endregion
       
        #region[healthCare]

        private void HealthcareCompanyData(AriClinicContext ctx1)
        {
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
        }

        public static string GetCompanyName()
        {
            return companyname;
        }

        public static string GetCompanyAddres1()
        {
            return companyaddress.Street;
        }

        public static string GetCompanyAddres2()
        {
            return companyaddress.Street2 + " " + companyaddress.PostCode + " " + companyaddress.City + " (" + companyaddress.Province + ")";
        }

        public static string GetCompanyNif()
        {
            return companynif;
        }

        #endregion
        
       
    }
}