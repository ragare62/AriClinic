namespace AriCliReport
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Summary description for RptTemplate.
    /// </summary>
    public partial class RptTemplate : Telerik.Reporting.Report
    {
        public RptTemplate()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public RptTemplate(IList<TemplateView> lista)
        {
            InitializeComponent();
            this.DataSource = lista;
        }
    }
}