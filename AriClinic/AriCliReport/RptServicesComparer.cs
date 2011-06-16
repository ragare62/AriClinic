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

    /// <summary>
    /// Summary description for RptServicesComparer.
    /// </summary>
    public partial class RptServicesComparer : Telerik.Reporting.Report
    {
        static string companyname;
        public RptServicesComparer()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptServicesComparer(AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            IList<Service> insServ = CntAriCli.GetServices(ctx1);
            this.DataSource = insServ;
            subReport1.ReportSource.DataSource = getInsuranceServices(insServ);
            
        }

        public static string GetCompanyName()
        {
            return companyname;
        }

        private List<InsuranceService> getInsuranceServices(IList<Service> services)
        {
            List<InsuranceService> insserv = new List<InsuranceService>();

            foreach (Service item in services)
            {
                insserv.AddRange(item.InsuranceServices);
            }

            return insserv;
        }
    }
}