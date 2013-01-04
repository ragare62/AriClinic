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
    /// Summary description for RptAnesNote.
    /// </summary>
    public partial class RptAnesNote : Telerik.Reporting.Report
    {
        static string companyname;
        public RptAnesNote()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptAnesNote(int idanesnote, AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            AnestheticServiceNote aneNote = CntAriCli.GetAnestheticServiceNote(idanesnote, ctx1);
            if (aneNote != null)
            {
                this.DataSource = aneNote;
                //this.subReport1.ReportSource.DataSource = aneNote.AnestheticTickets;
                this.subReport1.Report.DataSource = aneNote.AnestheticTickets;
            }
        }

        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}