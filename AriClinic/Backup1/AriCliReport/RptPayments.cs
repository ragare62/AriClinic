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
    public partial class RptPayments : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        public RptPayments()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

        }
        public RptPayments(DateTime fDate, DateTime tDate,int clinicId, AriClinicContext ctx)
            : this()
        {
            ctx = new AriClinicContext("AriClinicContext");
            fromDate = fDate; toDate = tDate;
            this.DataSource = CntAriCli.GetPayments(fDate, tDate, clinicId, ctx);
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