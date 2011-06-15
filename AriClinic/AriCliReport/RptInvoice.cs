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
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            Invoice invoice = CntAriCli.GetInvoice(idInvoice, ctx1);
            if (invoice != null)
            {
                this.DataSource = invoice;
                this.subReport1.ReportSource.DataSource = invoice.InvoiceLines;
                this.subReport2.ReportSource.DataSource = invoice.InvoiceLines;
            }
        }

        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}