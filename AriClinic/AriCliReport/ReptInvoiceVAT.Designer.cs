namespace AriCliReport
{
    partial class ReptInvoiceVAT
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReptInvoiceVAT));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.amountDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.sqlInvoiceVAT = new Telerik.Reporting.SqlDataSource();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30629929900169373D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.amountDataTextBox,
            this.textBox5,
            this.textBox6,
            this.textBox7});
            this.detail.Name = "detail";
            // 
            // amountDataTextBox
            // 
            this.amountDataTextBox.CanGrow = true;
            this.amountDataTextBox.Format = "{0:##,###,##0.00 €}";
            this.amountDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3385826349258423D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.amountDataTextBox.Name = "amountDataTextBox";
            this.amountDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.amountDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.amountDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.amountDataTextBox.StyleName = "Data";
            this.amountDataTextBox.Value = "= Fields.b";
            // 
            // textBox5
            // 
            this.textBox5.CanGrow = true;
            this.textBox5.Format = "{0:##,###,##0.00 €}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6771652698516846D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox5.StyleName = "Data";
            this.textBox5.Value = "= Fields.c";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Format = "{0:##,###,##0.00 €}";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1181106567382812D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "= Fields.pvp";
            // 
            // textBox7
            // 
            this.textBox7.CanGrow = true;
            this.textBox7.Format = "{0:N2}";
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.15748031437397003D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98425215482711792D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox7.StyleName = "Data";
            this.textBox7.Value = "= Fields.pr";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.39370074868202209D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.15748031437397003D), Telerik.Reporting.Drawing.Unit.Inch(0.11811026185750961D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98425227403640747D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox1.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "IVA";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3385826349258423D), Telerik.Reporting.Drawing.Unit.Inch(0.11811026185750961D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Value = "Base";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6771652698516846D), Telerik.Reporting.Drawing.Unit.Inch(0.11811026185750961D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.Value = "Cuota";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1181106567382812D), Telerik.Reporting.Drawing.Unit.Inch(0.11811026185750961D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox4.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.Value = "Total";
            // 
            // sqlInvoiceVAT
            // 
            this.sqlInvoiceVAT.ConnectionString = "AriClinicContext";
            this.sqlInvoiceVAT.Name = "sqlInvoiceVAT";
            this.sqlInvoiceVAT.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@InvoiceIdVat", System.Data.DbType.Int32, "=Parameters.InvoiceIdVat.Value")});
            this.sqlInvoiceVAT.SelectCommand = resources.GetString("sqlInvoiceVAT.SelectCommand");
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.43307098746299744D);
            this.reportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox25,
            this.textBox8});
            this.reportFooterSection1.Name = "reportFooterSection1";
            // 
            // textBox25
            // 
            this.textBox25.Format = "{0:dd/MM/yyyy}";
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5D), Telerik.Reporting.Drawing.Unit.Inch(0.030410131439566612D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5070867538452148D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox25.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox25.Value = "Total factura:";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Format = "{0:##,###,##0.00 €}";
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1181106567382812D), Telerik.Reporting.Drawing.Unit.Inch(0.030410051345825195D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811023950576782D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "= Sum(Fields.pvp)";
            // 
            // ReptInvoiceVAT
            // 
            this.DataSource = this.sqlInvoiceVAT;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.reportHeaderSection1,
            this.reportFooterSection1});
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "InvoiceIdVat";
            reportParameter1.Text = "InvoiceIdVat";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.SqlDataSource sqlInvoiceVAT;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.ReportFooterSection reportFooterSection1;
        private Telerik.Reporting.TextBox amountDataTextBox;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox8;
    }
}