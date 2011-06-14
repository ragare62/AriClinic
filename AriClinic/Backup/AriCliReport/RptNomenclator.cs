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
    /// Summary description for RptNomenglator.
    /// </summary>
    public partial class RptNomenclator : Telerik.Reporting.Report
    {
        static string companyname;
        public RptNomenclator()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptNomenclator(AriClinicContext ctx1)
            : this()
        {
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Procedure> listProc = (from p in ctx1.Procedures select p).ToList<Procedure>();
            this.DataSource = listProc;
        }

        public static string GetCompanyName()
        {
            return companyname;
        }
    }
}