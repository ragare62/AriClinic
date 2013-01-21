namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptProfessionalInvoice2.
    /// </summary>
    public partial class RptProfessionalInvoice2 : Telerik.Reporting.Report
    {
        public RptProfessionalInvoice2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public static string GetTaxDescription(decimal v)
        {
            return String.Format("Retención profesional ({0:0.00 %})", v);
        }
    }
}