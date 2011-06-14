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
    /// Summary description for RptTickets.
    /// </summary>
    public partial class RptTicketsNoPaid : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        public RptTicketsNoPaid()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

        }
        public RptTicketsNoPaid(DateTime fDate, DateTime tDate,int insuranceId, AriClinicContext ctx)
            : this()
        {
            fromDate = fDate; toDate = tDate;
            this.DataSource = CntAriCli.GetTickets(fDate, tDate, insuranceId, "NP", ctx);
        }
        public static string GetFromDate()
        {
            return String.Format("Desde: {0:dd/MM/yyyy}",fromDate);
        }
        public static string GetToDate()
        {
            return String.Format("Hasta: {0:dd/MM/yyyy}", toDate);
        }
    }
}