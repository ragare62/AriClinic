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
    public partial class RptBombaDolor : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        static String companyname;
        public RptBombaDolor()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptBombaDolor(DateTime fDate, DateTime tDate, AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            fromDate = fDate; toDate = tDate;
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            List<AnestheticTicket> tickets = CntAriCli.GetAnestheticServiceTicketsBomba(fDate, tDate, ctx1);
            this.DataSource = tickets;

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
    }
}