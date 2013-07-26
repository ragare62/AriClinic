using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliReport
{
    public class VatResumeView
    {
        public DateTime InvoiceDate { get; set; }
        public string GenType { get; set; }
        public string TaxName { get; set; }
        public decimal TaxPercentage { get; set; }
        public decimal Base{ get; set; }
        public decimal Quote { get; set; }
        public decimal Amount { get; set; }
        public string Customer { get; set; }
        public string InvoiceKey { get; set; }
    }
}
