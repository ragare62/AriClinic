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
    public partial class RptTickets : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        static Boolean nVoucher;
        static string companyname;
        public RptTickets()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
        }

        public RptTickets(DateTime fDate, DateTime tDate, int insuranceId, AriClinicContext ctx, int noVoucher)
        : this()
        {
            ctx = new AriClinicContext("AriClinicContext");
            companyname = CntAriCli.GetHealthCompany(ctx).Name;

            fromDate = fDate;
            toDate = tDate;

            if (noVoucher == 0)
            {
                this.DataSource = CntAriCli.GetTickets(fDate, tDate, insuranceId, ctx);
                nVoucher = false;
            }
            else
            {
                this.DataSource = CntAriCli.GetTickets(fDate, tDate, insuranceId, ctx, 1);
                nVoucher = true;
            }
        }

        public static string GetFromDate()
        {
            return String.Format("Desde: {0:dd/MM/yyyy}", fromDate);
        }

        public static string GetToDate()
        {
            return String.Format("Hasta: {0:dd/MM/yyyy}", toDate);
        }
        public static string GetVoucher()
        {
            if (nVoucher)
                return "Sólo tickets sin comprobante";
            else
                return "";
        }

        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}