namespace AriCliReport
{
    partial class RptProfessionalInvoiceBases
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.sqlProfessionalInvoiceBases = new Telerik.Reporting.SqlDataSource();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.txtSubTotal = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.70000004768371582D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox4,
            this.textBox5});
            this.detail.Name = "detail";
            // 
            // sqlProfessionalInvoiceBases
            // 
            this.sqlProfessionalInvoiceBases.ConnectionString = "AriClinicContext";
            this.sqlProfessionalInvoiceBases.Name = "sqlProfessionalInvoiceBases";
            this.sqlProfessionalInvoiceBases.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@InvoiceId", System.Data.DbType.Int32, "=Parameters.InvoiceId.Value")});
            this.sqlProfessionalInvoiceBases.SelectCommand = "SELECT invoice_id, SUM(amount), tax_percentage\r\nFROM professional_invoice_line\r\nW" +
    "HERE invoice_id = @InvoiceId\r\nGROUP BY invoice_id;";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.11811026185750961D), Telerik.Reporting.Drawing.Unit.Inch(0.078740119934082031D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6377949714660645D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Value = "Base";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8346455097198486D), Telerik.Reporting.Drawing.Unit.Inch(0.078739799559116364D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70866155624389648D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox1.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Value = "IVA";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6614177227020264D), Telerik.Reporting.Drawing.Unit.Inch(0.078740119934082031D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8503931760787964D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.Value = "Cuota";
            // 
            // textBox7
            // 
            this.textBox7.Angle = 0D;
            this.textBox7.Format = "{0:N2}";
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.11811026185750961D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6377952098846436D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.Value = "= (Fields.[SUM(amount)] * 100) / (Fields.tax_percentage + 100)";
            // 
            // textBox4
            // 
            this.textBox4.Angle = 0D;
            this.textBox4.Format = "{0:0.00 %}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8346455097198486D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.70866137742996216D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.Value = "= Fields.tax_percentage";
            // 
            // textBox5
            // 
            this.textBox5.Angle = 0D;
            this.textBox5.Format = "{0:N2}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6614177227020264D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8503932952880859D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.Value = "= Fields.[SUM(amount)]-((Fields.[SUM(amount)] * 100) / (Fields.tax_percentage + 1" +
    "00))";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0000003576278687D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox1,
            this.textBox3});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(3D);
            this.reportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox13,
            this.txtSubTotal,
            this.textBox8});
            this.reportFooterSection1.Name = "reportFooterSection1";
            // 
            // textBox13
            // 
            this.textBox13.Format = "{0:###,##0.00}";
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2362208366394043D), Telerik.Reporting.Drawing.Unit.Inch(0.11811002343893051D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0998815298080444D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox13.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Style.Visible = true;
            this.textBox13.Value = "SubTotal: ";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Angle = 0D;
            this.txtSubTotal.Format = "{0:N2}";
            this.txtSubTotal.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.3361811637878418D), Telerik.Reporting.Drawing.Unit.Inch(0.11811002343893051D));
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4197241067886353D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.txtSubTotal.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtSubTotal.Value = "= SUM((Fields.[SUM(amount)] * 100) / (Fields.tax_percentage + 100))";
            // 
            // textBox8
            // 
            this.textBox8.Format = "{0:###,##0.00}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9527559280395508D), Telerik.Reporting.Drawing.Unit.Inch(0.31818899512290955D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.3833463191986084D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox8.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.Style.Visible = true;
            this.textBox8.Value = "= AriCliReport.RptProfessionalInvoiceBases.GetTaxWitholdingDesc(Parameters.TaxWit" +
    "hholding.Value)";
            // 
            // RptProfessionalInvoiceBases
            // 
            this.DataSource = this.sqlProfessionalInvoiceBases;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.reportHeaderSection1,
            this.reportFooterSection1});
            this.Name = "RptProfessionalInvoiceBases";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "InvoiceId";
            reportParameter1.Text = "InvoiceId";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter2.Name = "TaxWithholding";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Float;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(19.999898910522461D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SqlDataSource sqlProfessionalInvoiceBases;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.ReportFooterSection reportFooterSection1;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox txtSubTotal;
        private Telerik.Reporting.TextBox textBox8;
    }
}