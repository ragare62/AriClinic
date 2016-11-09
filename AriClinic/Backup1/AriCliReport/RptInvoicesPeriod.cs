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
    using System.Linq;

    /// <summary>
    /// Summary description for RptInvoicesPeriod.
    /// </summary>
    public partial class RptInvoicesPeriod : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        static String companyname;
        public RptInvoicesPeriod()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptInvoicesPeriod(DateTime fDate, DateTime tDate, AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            fromDate = fDate; toDate = tDate;
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Invoice> invoices = CntAriCli.GetInvoices(fromDate, toDate, ctx1);
            this.DataSource = invoices;
            //this.subReport2.ReportSource.DataSource = GetInvoiceLines(invoices);
            this.subReport2.Report.DataSource = GetInvoiceLines(invoices);
        }

        public static string GetCompanyName()
        {
            return companyname;
        }

        public static string GetFromDate()
        {
            return String.Format("Desde: {0:dd/MM/yyyy}", fromDate);
        }

        public static string GetToDate()
        {
            return String.Format("Hasta: {0:dd/MM/yyyy}", toDate);
        }

        public IList<InvoiceLine> GetInvoiceLines(IList<Invoice> invoices)
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