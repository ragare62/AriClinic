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
    /// Summary description for RptInsuranceDebt.
    /// </summary>
    public partial class RptInsuranceDebt : Telerik.Reporting.Report
    {
        static string companyname;
        public RptInsuranceDebt()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptInsuranceDebt(AriClinicContext ctx1)
            : this()
        {
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Ticket> tickets = CntAriCli.GetTickets(true,ctx1);//.GetInvoicesByCustomer(ffin, idCustomer, ctx1);
            this.DataSource = tickets;
            //this.subReport2.ReportSource.DataSource = GetInvoideLines(invoices);

        }
        public RptInsuranceDebt(int idInsurance, AriClinicContext ctx1)
            : this()
        {
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Ticket> tickets = CntAriCli.GetTickets(true, ctx1);//.GetInvoicesByCustomer(ffin, idCustomer, ctx1);
            this.DataSource =(from tick in tickets
                              where tick.Policy.Customer.PersonId == idInsurance
                              select tick).ToList<Ticket>();
            //this.subReport2.ReportSource.DataSource = GetInvoideLines(invoices);

        }
        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}