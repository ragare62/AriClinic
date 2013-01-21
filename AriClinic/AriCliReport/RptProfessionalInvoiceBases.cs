namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for RptProfessionalInvoiceBases.
    /// </summary>
    public partial class RptProfessionalInvoiceBases : Telerik.Reporting.Report
    {
        public RptProfessionalInvoiceBases()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public static string GetTaxWitholdingDesc(decimal v)
        {
            return String.Format("Retención profesional ({0:0.00 %})", v);
        }
        public static decimal GetRetentionValue()
        {
            return 0;
        }
    }
}