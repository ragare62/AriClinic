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
    using Telerik.Reporting.Charting;
    using System.Linq;
    using System.Globalization;

    /// <summary>
    /// Summary description for RptParamInvNumber.
    /// </summary>
    public partial class RptParamTickets : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        static string companyname;

        public RptParamTickets()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        
        public RptParamTickets(DateTime fDate, DateTime tDate, AriClinicContext ctx1)
        : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            fromDate = fDate;
            toDate = tDate;

            iniChartWeekProfessional(ctx1);
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

        private void iniChartMonth(AriClinicContext ctx1)
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            IList<Ticket> tickets = CntAriCli.GetTickets(fromDate, toDate, ctx1);
            chart1.PlotArea.XAxis.Items.Clear();
            chart1.PlotArea.XAxis.AutoScale = false;

            chart1.PlotArea.XAxis.AutoScale = false;
            chart1.PlotArea.XAxis.LayoutMode = Telerik.Reporting.Charting.Styles.ChartAxisLayoutMode.Inside;
            chart1.Appearance.BarWidthPercent = (decimal)5.00;

            chart1.AutoLayout = true;
            chart1.ChartTitle.TextBlock.Visible = false;
            chart1.PlotArea.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
            //chart1.PlotArea.Appearance.FillStyle.MainColor = Color.Transparent;
            ChartSeries chartSeries1 = new ChartSeries();
            chartSeries1.Type = ChartSeriesType.StackedArea;
            chartSeries1.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;

            var rs = from tick in (List<Ticket>)tickets
                     where tick.TicketDate >= fromDate && tick.TicketDate <= toDate && tick.GetType().ToString().Equals("AriCliModel.AnestheticTicket")
                     group tick by new { tick.TicketDate.Year, tick.TicketDate.Month } into g
                     select new { Datos = g.Key, Total = g.Sum(tick => tick.Amount) };

            ChartSeriesItem serieItem;
            foreach (var item in rs)
            {
                serieItem = new ChartSeriesItem();
                serieItem.YValue = (double)item.Total;
                serieItem.Name = item.Datos.Month + "/" + item.Datos.Year;
                serieItem.Label.TextBlock.Text = item.Total.ToString();
                serieItem.Appearance.Exploded = true;
                chartSeries1.AddItem(serieItem);
            }

            chart1.Series.Clear();
            chart1.Series.Add(chartSeries1);
        }

        private void iniChartWeek(AriClinicContext ctx1)
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            IList<Ticket> tickets = CntAriCli.GetTickets(fromDate, toDate, ctx1);
            chart1.PlotArea.XAxis.Items.Clear();
            chart1.Legend.Visible = false;

            chart1.PlotArea.XAxis.AutoScale = false;
            chart1.PlotArea.XAxis.LayoutMode= Telerik.Reporting.Charting.Styles.ChartAxisLayoutMode.Inside;
            chart1.Appearance.BarWidthPercent = (decimal)5.00;

            chart1.AutoLayout = true;
            chart1.ChartTitle.TextBlock.Visible = false;
            chart1.PlotArea.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
            //chart1.PlotArea.Appearance.FillStyle.MainColor = Color.Transparent;
            ChartSeries chartSeries1 = new ChartSeries();
            chartSeries1.Type = ChartSeriesType.StackedArea;
            chartSeries1.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;

            var rs = from tick in (List<Ticket>)tickets
                     where tick.TicketDate >= fromDate && tick.TicketDate <= toDate && tick.GetType().ToString().Equals("AriCliModel.AnestheticTicket")
                     group tick by new { tick.TicketDate.Year, WeekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(tick.TicketDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday) } into g
                     select new { Datos = g.Key, Total = g.Sum(tick => tick.Amount) };

            ChartSeriesItem serieItem;

            foreach (var item in rs)
            {
                serieItem = new ChartSeriesItem();
                serieItem.YValue = (double)item.Total;
                chart1.PlotArea.XAxis.AddItem(new ChartAxisItem(item.Datos.WeekNumber + "/" + item.Datos.Year));
                chart1.PlotArea.YAxis.AddItem(new ChartAxisItem(String.Format("{0:#.##}", item.Total)));
                //serieItem.Name = item.Datos.WeekNumber + "/" + item.Datos.Year;
                serieItem.Label.TextBlock.Text = String.Format("{0:#.##}", item.Total);
                serieItem.Appearance.Exploded = true;
                chartSeries1.AddItem(serieItem);

            }

            chart1.Series.Clear();
            chart1.Series.Add(chartSeries1);
        }

        private void iniChartWeekProfessional(AriClinicContext ctx1)
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            IList<Ticket> tickets = CntAriCli.GetTickets(fromDate, toDate, ctx1);
            chart1.PlotArea.XAxis.Items.Clear();
            //chart1.PlotArea.XAxis.Appearance.TextAppearance.
            chart1.Legend.Visible = true;
            //chart1.PlotArea.XAxis.AddRange(0, 1, 1);
            chart1.PlotArea.XAxis.AutoScale = false;
            chart1.PlotArea.XAxis.LayoutMode = Telerik.Reporting.Charting.Styles.ChartAxisLayoutMode.Inside;
            chart1.Appearance.BarWidthPercent = (decimal)5.00;
            chart1.AutoLayout = true;
            chart1.ChartTitle.TextBlock.Visible = false;
            chart1.PlotArea.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
            //chart1.PlotArea.Appearance.FillStyle.MainColor = Color.Transparent;
            ChartSeries chartSeries1 = new ChartSeries();
            chartSeries1.Type = ChartSeriesType.StackedBar;
            chartSeries1.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;

            var rs = from tick in (List<Ticket>)tickets
                     where tick.TicketDate >= fromDate && tick.TicketDate <= toDate && tick.GetType().ToString().Equals("AriCliModel.AnestheticTicket")
                     group tick by new { tick.TicketDate.Year, WeekNumber = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(tick.TicketDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday), tick.Professional.FullName } into g
                     select new { Datos = g.Key, Total = g.Sum(tick => tick.Amount) };

            ChartSeriesItem serieItem;
            foreach (var item in rs)
            {
                serieItem = new ChartSeriesItem();
                serieItem.YValue = (double)item.Total;
                chart1.PlotArea.XAxis.AddItem(new ChartAxisItem(item.Datos.WeekNumber + "/" + item.Datos.Year));
                chart1.PlotArea.YAxis.AddItem(new ChartAxisItem(String.Format("{0:#.##}", item.Total)));
                serieItem.Label.TextBlock.Text = String.Format("{0:#.##}", item.Total);
                serieItem.Appearance.Exploded = true;
                //serieItem.Name = item.Datos.FullName;
                chartSeries1.AddItem(serieItem);

            }

            chart1.Series.Clear();
            chart1.Series.Add(chartSeries1);
        }
    }
}