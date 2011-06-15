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
    /// Summary description for RptTicket.
    /// </summary>
    public partial class RptTicket : Telerik.Reporting.Report
    {
        static string companyname;
        public RptTicket()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptTicket(int idticket, AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            this.DataSource = CntAriCli.GetTicket(idticket, ctx1);
        }

        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}