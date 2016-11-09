namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using AriCliModel;
    using AriCliReport;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptVatResume2.
    /// </summary>
    public partial class RptVatResume2 : Telerik.Reporting.Report
    {
        public RptVatResume2()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void RptVatResume2_NeedDataSource(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)sender;
            DateTime dFecha = (DateTime)report.Parameters["DFecha"].Value;
            DateTime hFecha = (DateTime)report.Parameters["HFecha"].Value;
            using (AriClinicContext ctx = new AriClinicContext())
            {
                IList<VatResumeView> lvr = new List<VatResumeView>();
                // normal invoices
                var rs = (from il in ctx.InvoiceLines
                          where il.Invoice.InvoiceDate >= dFecha
                          && il.Invoice.InvoiceDate <= hFecha
                          select il);
                foreach (InvoiceLine i in rs)
                {
                    VatResumeView vr = new VatResumeView();
                    vr.InvoiceDate = i.Invoice.InvoiceDate;
                    vr.GenType = "NORMAL";
                    vr.TaxName = i.TaxType.Name;
                    vr.TaxPercentage = i.TaxPercentage;
                    vr.Amount = i.Amount;
                    vr.Base = (100M * i.Amount) / (100M + vr.TaxPercentage);
                    vr.Quote = vr.Amount - vr.Base;
                    vr.InvoiceKey = String.Format("{0}-{1}-{2:000000}", i.Invoice.Serial, i.Invoice.Year, i.Invoice.InvoiceNumber);
                    vr.Customer = i.Invoice.Customer.ComercialName;
                    lvr.Add(vr);
                }
                // amendment invoices
                var rs2 = (from ial in ctx.AmendmentInvoiceLines
                           where ial.AmendmentInvoice.InvoiceDate >= dFecha
                           && ial.AmendmentInvoice.InvoiceDate <= hFecha
                           select ial);
                foreach (AmendmentInvoiceLine ail in rs2)
                {
                    VatResumeView vr = new VatResumeView();
                    vr.InvoiceDate = ail.AmendmentInvoice.InvoiceDate;
                    vr.GenType = "RECTIF";
                    vr.TaxName = ail.TaxType.Name;
                    vr.TaxPercentage = ail.TaxPercentage;
                    vr.Amount = ail.Amount;
                    vr.Base = (100M * ail.Amount) / (100M + vr.TaxPercentage);
                    vr.Quote = vr.Amount - vr.Base;
                    vr.InvoiceKey = String.Format("{0}-{1}-{2:000000}", ail.AmendmentInvoice.Serial, ail.AmendmentInvoice.Year, ail.AmendmentInvoice.InvoiceNumber);
                    vr.Customer = ail.AmendmentInvoice.Customer.ComercialName;
                    lvr.Add(vr);
                }
                this.DataSource = lvr;
            }

        }
    }
}