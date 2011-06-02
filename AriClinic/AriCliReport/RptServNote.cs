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
    /// Summary description for RptServNote.
    /// </summary>
    public partial class RptServNote : Telerik.Reporting.Report
    {
        static string companyname;
        public RptServNote()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptServNote(int idservnote, AriClinicContext ctx1)
            : this()
        {
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            ServiceNote servNote = CntAriCli.GetServiceNote(idservnote, ctx1);
            this.DataSource = servNote;
            this.subReport1.ReportSource.DataSource = servNote.Tickets;
        }

        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}