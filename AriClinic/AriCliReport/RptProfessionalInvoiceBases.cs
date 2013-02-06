namespace AriCliReport
{
    using System;
    using System.Collections.Generic;
    using AriCliModel;
    using Telerik.OpenAccess;
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
        
        public static decimal GetInvoiceAmount(int invoiceId)
        {
            decimal total = 0;
            using (AriClinicContext ctx = new AriClinicContext("AriClinicContext"))
            {
                ProfessionalInvoice pInvoice = CntAriCli.GetProfessionalInvoice(invoiceId, ctx);
                if (pInvoice != null) total = pInvoice.Amount;
            }
            return total;
        }

        public static decimal GetInvoiceBases(int invoiceId)
        {
            decimal totBases = 0;
            using (AriClinicContext ctx = new AriClinicContext("AriClinicContext"))
            {
                ProfessionalInvoice pInvoice = CntAriCli.GetProfessionalInvoice(invoiceId, ctx);
                if (pInvoice != null)
                {
                    foreach (ProfessionalInvoiceLine pILine in pInvoice.ProfessionalInvoiceLines)
                    {
                        totBases += (pILine.Amount * 100.0M) / (pILine.TaxPercentage + 100.0M);
                    }
                }
            }
            return totBases;
        }

        public static decimal GetTaxWithholdingAmount(int invoiceId, decimal taxWithHolding)
        {
            decimal taxAmount = 0;

            taxAmount = GetInvoiceBases(invoiceId) * ((100.0M - taxWithHolding )/100.0M);

            return taxAmount;
        }

        public static decimal GetTotalInvoiceP(int invoiceId, decimal taxWithHolding)
        {
            return GetInvoiceAmount(invoiceId) - GetTaxWithholdingAmount(invoiceId, taxWithHolding);
        }

        public static string GetTaxWihholdingText(decimal txVal)
        {
            return String.Format("Retención profesional ({0:0.00%}) ", txVal);
        }
        
    }
}