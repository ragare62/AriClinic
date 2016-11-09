namespace AriCliReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
using AriCliModel;
    using System.Data;
    using System.Linq;
    using Telerik.Reporting.Charting;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for RptServProfessional.
    /// </summary>
    public partial class RptServProfessional : Telerik.Reporting.Report
    {
        static DateTime fromDate;
        static DateTime toDate;
        static string companyname;
        public RptServProfessional()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public RptServProfessional(DateTime fDate, DateTime tDate, string idProfesional,  AriClinicContext ctx1)
            : this()
        {
            ctx1 = new AriClinicContext("AriClinicContext");
            fromDate = fDate; toDate = tDate;
            companyname= CntAriCli.GetHealthCompany(ctx1).Name;
            if (idProfesional.Equals("0"))
            {
                this.DataSource = CntAriCli.GetTickets(fromDate, toDate, ctx1);
                iniChart(ctx1);
            }
            else
            {
                this.DataSource = CntAriCli.GetTicketsByProfessional(fromDate, toDate, idProfesional, ctx1);
                this.reportHeaderSection1.Visible = false;
            }
        

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
            IList<Professional> prof = CntAriCli.GetProfessionalTickets(fromDate, toDate, ctx1);
            chart1.PlotArea.XAxis.AutoScale = true;
            chart1.PlotArea.XAxis.Items.Clear();
            chart1.AutoLayout = true;
            chart1.ChartTitle.TextBlock.Visible=false;//.Text = "Servicios por profesional.";
            chart1.PlotArea.Appearance.FillStyle.FillType = Telerik.Reporting.Charting.Styles.FillType.Solid;
            chart1.PlotArea.Appearance.FillStyle.MainColor = Color.Transparent;
            ChartSeries chartSeries1 = new ChartSeries();
            chartSeries1.Type = ChartSeriesType.Pie;
            chartSeries1.Appearance.LegendDisplayMode = ChartSeriesLegendDisplayMode.ItemLabels;

            foreach (Professional item in prof)
            {
                ChartSeriesItem serieItem = new ChartSeriesItem();
                serieItem.YValue = (from tic in item.Tickets
                                    where tic.TicketDate >= fromDate && tic.TicketDate <= toDate
                                    select tic).ToList<Ticket>().Count();
                serieItem.Name = item.FullName;
                serieItem.Label.TextBlock.Text = item.Tickets.Count.ToString();
                serieItem.Appearance.Exploded = true;
                chartSeries1.Items.Add(serieItem);
            }

            chart1.Series.Clear();
            chart1.Series.AddRange(new Telerik.Reporting.Charting.ChartSeries[] { chartSeries1 });  
        }


    }
}