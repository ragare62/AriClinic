namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using AriCliModel;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptPatientDebt.
    /// </summary>
    public partial class RptPatientDebt : Telerik.Reporting.Report
    {
        static String companyname;
        public RptPatientDebt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
         public RptPatientDebt(AriClinicContext ctx1)
            : this()
        {
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Ticket> tickets = CntAriCli.GetTickets(true,ctx1);//.GetInvoicesByCustomer(ffin, idCustomer, ctx1);
            this.DataSource = tickets;
            //this.subReport2.ReportSource.DataSource = GetInvoideLines(invoices);

        }
         public RptPatientDebt(int idCustomer, AriClinicContext ctx1)
            : this()
        {
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Ticket> tickets = CntAriCli.GetTickets(true, ctx1);//.GetInvoicesByCustomer(ffin, idCustomer, ctx1);
            this.DataSource =(from tick in tickets
                            where tick.Policy.Customer.PersonId == idCustomer
                            select tick).ToList<Ticket>();
            //this.subReport2.ReportSource.DataSource = GetInvoideLines(invoices);

        }
        public static string GetCompanyName()
        {
            return companyname;
        }
        //public IList<InvoiceLine> GetInvoideLines(IList<Invoice> invoices)
        //{
        //    List<InvoiceLine> InvLines = new List<InvoiceLine>();
        //    foreach (Invoice item in invoices)
        //    {
        //        if(item.InvoiceLines.Count>0)
        //        {
        //            InvLines.AddRange(item.InvoiceLines);
        //        }
        //    }

        //    return InvLines;
        //}
    }
}