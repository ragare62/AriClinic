namespace AriCliReport
{
    partial class SubProfessionalInvoiceLine
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.5D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.Visible = false;
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.20003955066204071D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox10,
            this.textBox12,
            this.textBox18});
            this.detail.Name = "detail";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.1998820304870605D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Value = "=Description";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.2000002861022949D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.80000019073486328D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox12.Value = "=TaxType.Name";
            // 
            // textBox18
            // 
            this.textBox18.Format = "{0:C2}";
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.0000791549682617D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.2675987482070923D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox18.Value = "=Amount";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.5D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.Visible = false;
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=ProfessionalInvoice.InvoiceId")});
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.49992117285728455D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.Style.Visible = true;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.20003938674926758D, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox11,
            this.textBox7,
            this.textBox9});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(5.0000786781311035D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.2675986289978027D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.Value = "Importe";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.1999211311340332D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Value = "Servicio";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.2000002861022949D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.800000011920929D, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985D, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.textBox9.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Value = "%IVA";
            // 
            // SubProfessionalInvoiceLine
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
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
            this.Width = new Telerik.Reporting.Drawing.Unit(15.920000076293945D, Telerik.Reporting.Drawing.UnitType.Cm);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox7;
    }
}