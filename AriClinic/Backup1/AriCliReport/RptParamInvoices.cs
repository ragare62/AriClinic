namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using AriCliModel;
    using Telerik.Reporting.Charting;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Summary description for RptParamInvoices.
    /// </summary>
    public partial class RptParamInvoices : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        static string companyname;

        public RptParamInvoices()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptParamInvoices(DateTime fDate, DateTime tDate, AriClinicContext ctx1)
        : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            fromDate = fDate;
            toDate = tDate;
            //companyname = CntAriCli.GetHealthCompany(ctx1).Name;
            //if (idProfesional.Equals("0"))
            //{
            //    this.DataSource = CntAriCli.GetTickets(fromDate, toDate, ctx1);
                iniChart(ctx1);
            //}
            //else
            //    this.DataSource = CntAriCli.GetTicketsByProfessional(fromDate, toDate, idProfesional, ctx1);
        }

        public static string GetFromDate()
        {
            return String.Format("Desde: {0:dd/MM/yyyy}", fromDate);
        }

        public static string GetToDate()
        {
            return String.Format("Hasta: {0:dd/MM/yyyy}", toDate);
        }

        public static string GetCompanyName()
        {
            return companyname;
        }

        private void iniChart(AriClinicContext ctx1)
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            IList<Invoice> invoices = CntAriCli.GetInvoices(fromDate, toDate, ctx1);
            chart1.PlotArea.XAxis.AutoScale = true;
            chart1.PlotArea.XAxis.Items.Clear();
            chart1.AutoLayout = true;
            chart1.ChartTitle.TextBlock.Visible = false;
            chart1.PlotArea.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
            //chart1.PlotArea.Appearance.FillStyle.MainColor = Color.Transparent;
            ChartSeries chartSeries1 = new ChartSeries();
            chartSeries1.Type = ChartSeriesType.Bar;
            chartSeries1.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;

            ChartSeriesItem serieItem = new ChartSeriesItem();
                
            var rs = from inv in (List<Invoice>)invoices
                     where inv.InvoiceDate >= fromDate && inv.InvoiceDate <= toDate
                     group inv by new { inv.InvoiceDate.Year, inv.InvoiceDate.Month } into g
                     select new { Datos = g.Key, Total = g.Sum(inv => inv.Total) };

            foreach (var item in rs)
            {
                serieItem.YValue = (double)item.Total;
                serieItem.Name = item.Datos.Month + "/" + item.Datos.Year;
                serieItem.Label.TextBlock.Text = item.Total.ToString();
                serieItem.Appearance.Exploded = true;
                chartSeries1.Items.Add(serieItem);
            }

            chart1.Series.Clear();
            chart1.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] { chartSeries1 });
        }
    }
}