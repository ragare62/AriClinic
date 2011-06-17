namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using AriCliModel;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptPatientInvoice.
    /// </summary>
    public partial class RptPatientInvoice : Telerik.Reporting.Report
    {
        static string companyname;
        public RptPatientInvoice()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptPatientInvoice(int idCustomer, DateTime ffin, AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Invoice> invoices = CntAriCli.GetInvoicesByCustomer(ffin, idCustomer, ctx1);
            this.DataSource = invoices;
            this.subReport2.ReportSource.DataSource = GetInvoideLines(invoices);

        }
        public RptPatientInvoice(DateTime ffin, AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Invoice> invoices = CntAriCli.GetInvoices(new DateTime(), ffin, ctx1);
            this.DataSource = invoices;
            this.subReport2.ReportSource.DataSource = GetInvoideLines(invoices);

        }
        public static string GetCompanyName()
        {
            return companyname;
        }
        public IList<InvoiceLine> GetInvoideLines(IList<Invoice> invoices)
        {
            List<InvoiceLine> InvLines = new List<InvoiceLine>();
            foreach (Invoice item in invoices)
            {
                if(item.InvoiceLines.Count>0)
                {
                    InvLines.AddRange(item.InvoiceLines);
                }
            }

            return InvLines;
        }
    }
}