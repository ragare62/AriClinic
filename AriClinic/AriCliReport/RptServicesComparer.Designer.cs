namespace AriCliReport
{
    partial class RptServicesComparer
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptServicesComparer));
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.category = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.service = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.subServiceComp1 = new AriCliReport.SubServiceComp();
            ((System.ComponentModel.ISupportInitialize)(this.subServiceComp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox5,
            this.textBox1,
            this.pictureBox1});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40000000596046448D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.2440550327301025D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox5.Value = "=GetCompanyName()";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.4000003337860107D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.15628933906555176D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.5999605655670166D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.23618102073669434D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.Font.Name = "Arial";
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(15D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "Comparativa de precios";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9339065551757812E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.2999606132507324D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.39247044920921326D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.30000004172325134D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1});
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.5D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox6});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // category
            // 
            this.category.GroupFooter = this.groupFooterSection1;
            this.category.GroupHeader = this.groupHeaderSection1;
            this.category.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("ServiceCategory.ServiceCategoryId")});
            this.category.Name = "category";
            this.category.Sortings.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("ServiceCategory.Name", Telerik.Reporting.SortDirection.Asc)});
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.1000000610947609D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.30000004172325134D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.textBox4,
            this.shape1});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.0020833015441894531D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.89791673421859741D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox7.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox7.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox7.Style.LineWidth = new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox7.Value = "Categoria:";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.90007877349853516D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.0998821258544922D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Value = "=ServiceCategory.Name";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.0020833015441894531D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.9936318397521973D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099960483610630035D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.shape1.Style.LineWidth = new Telerik.Reporting.Drawing.Unit(2D, Telerik.Reporting.Drawing.UnitType.Point);
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.90007877349853516D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.1000000610947609D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.09563684463501D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Value = "=Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.1000000610947609D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.89791673421859741D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Style.LineWidth = new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox3.Value = "Servicio:";
            // 
            // service
            // 
            this.service.GroupFooter = this.groupFooterSection2;
            this.service.GroupHeader = this.groupHeaderSection2;
            this.service.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("ServiceId")});
            this.service.Name = "service";
            this.service.Sortings.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("Name", Telerik.Reporting.SortDirection.Asc)});
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = new Telerik.Reporting.Drawing.Unit(0.1000000610947609D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = new Telerik.Reporting.Drawing.Unit(0.30000004172325134D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox3});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // textBox6
            // 
            this.textBox6.Format = "{0}";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.6521620750427246D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29996046423912048D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.34355354309082031D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Value = "= PageNumber";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.subReport1.Name = "subReport1";
            this.subReport1.Parameters.Add(new Telerik.Reporting.Parameter("ServiceId", "=ServiceId"));
            this.subReport1.ReportSource = this.subServiceComp1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.9957156181335449D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134D, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // subServiceComp1
            // 
            this.subServiceComp1.Name = "subServiceComp1";
            // 
            // RptServicesComparer
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.category,
            this.service});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(1D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.subServiceComp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.Group category;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.Group service;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.SubReport subReport1;
        private SubServiceComp subServiceComp1;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.TextBox textBox6;
    }
}