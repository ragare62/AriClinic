namespace AriCliReport
{
    partial class RptGPByClinic
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptGPByClinic));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.sqlGPByClinic = new Telerik.Reporting.SqlDataSource();
            this.sqlClinic = new Telerik.Reporting.SqlDataSource();
            this.group1 = new Telerik.Reporting.Group();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.clinic = new Telerik.Reporting.Group();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.paymentm = new Telerik.Reporting.Group();
            this.groupHeaderSection4 = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection4 = new Telerik.Reporting.GroupFooterSection();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.comercial_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.70866137742996216D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox17,
            this.pictureBox1,
            this.textBox1,
            this.textBox13,
            this.textBox14});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2D);
            this.detail.Name = "detail";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(2D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // sqlGPByClinic
            // 
            this.sqlGPByClinic.ConnectionString = "AriClinicContext";
            this.sqlGPByClinic.Name = "sqlGPByClinic";
            this.sqlGPByClinic.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@FDate", System.Data.DbType.Date, "=Parameters.FDate.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@TDate", System.Data.DbType.Date, "=Parameters.TDate.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Clinic", System.Data.DbType.Int32, "=Parameters.Clinic.Value")});
            this.sqlGPByClinic.SelectCommand = resources.GetString("sqlGPByClinic.SelectCommand");
            // 
            // sqlClinic
            // 
            this.sqlClinic.ConnectionString = "AriClinicContext";
            this.sqlClinic.Name = "sqlClinic";
            this.sqlClinic.SelectCommand = "SELECT        clinic_id, name\r\nFROM            clinic\r\nORDER BY name";
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Name = "group1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.27559056878089905D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox2,
            this.textBox8,
            this.textBox4,
            this.textBox5});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(2D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // clinic
            // 
            this.clinic.GroupFooter = this.groupFooterSection2;
            this.clinic.GroupHeader = this.groupHeaderSection2;
            this.clinic.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.clinic_name")});
            this.clinic.Name = "clinic";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.46045604348182678D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.comercial_nameDataTextBox,
            this.textBox9,
            this.textBox10});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(2D);
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // paymentm
            // 
            this.paymentm.GroupFooter = this.groupFooterSection4;
            this.paymentm.GroupHeader = this.groupHeaderSection4;
            this.paymentm.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.pmethod_name")});
            this.paymentm.Name = "paymentm";
            // 
            // groupHeaderSection4
            // 
            this.groupHeaderSection4.Height = Telerik.Reporting.Drawing.Unit.Inch(2D);
            this.groupHeaderSection4.Name = "groupHeaderSection4";
            // 
            // groupFooterSection4
            // 
            this.groupFooterSection4.Height = Telerik.Reporting.Drawing.Unit.Inch(2D);
            this.groupFooterSection4.Name = "groupFooterSection4";
            // 
            // textBox17
            // 
            this.textBox17.Format = "{0:dd/MM/yyyy}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.020872751250863075D), Telerik.Reporting.Drawing.Unit.Inch(0.31253933906555176D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.4000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.31863212585449219D));
            this.textBox17.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox17.Value = "= Fields.company_name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.020872751250863075D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929D), Telerik.Reporting.Drawing.Unit.Inch(0.30003929138183594D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2785201072692871D), Telerik.Reporting.Drawing.Unit.Inch(7.8757606388535351E-05D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5954561233520508D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "Informe de general de cobros";
            // 
            // textBox13
            // 
            this.textBox13.Format = "{0:dd/MM/yyyy}";
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6832351684570312D), Telerik.Reporting.Drawing.Unit.Inch(0.31253933906555176D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0866143703460693D), Telerik.Reporting.Drawing.Unit.Inch(0.31863212585449219D));
            this.textBox13.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox13.Value = "= Parameters.FDate.Value";
            // 
            // textBox14
            // 
            this.textBox14.Format = "{0:dd/MM/yyyy}";
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7874016761779785D), Telerik.Reporting.Drawing.Unit.Inch(0.31253933906555176D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0866143703460693D), Telerik.Reporting.Drawing.Unit.Inch(0.31863212585449219D));
            this.textBox14.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox14.Value = "= Parameters.TDate.Value";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.19685037434101105D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90551203489303589D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox3.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Value = "Fecha pago";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1811025142669678D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90551203489303589D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox2.Value = "Fecha nota";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8110237121582031D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99967211484909058D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox8.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox8.Value = "Importe";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1653542518615723D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2520482540130615D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox4.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox4.Value = "Paciente";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4881892204284668D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2520482540130615D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox5.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Value = "Observaciones";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.19685046374797821D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8951771259307861D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Value = "CLINICA";
            // 
            // comercial_nameDataTextBox
            // 
            this.comercial_nameDataTextBox.CanGrow = true;
            this.comercial_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.19685046374797821D), Telerik.Reporting.Drawing.Unit.Inch(0.20011822879314423D));
            this.comercial_nameDataTextBox.Name = "comercial_nameDataTextBox";
            this.comercial_nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8951771259307861D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.comercial_nameDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.comercial_nameDataTextBox.StyleName = "Data";
            this.comercial_nameDataTextBox.Value = "= Fields.clinic_name";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.534614086151123D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.276081919670105D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox9.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.Value = "Total clínica";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Format = "{0:###,##0.00}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5346126556396484D), Telerik.Reporting.Drawing.Unit.Inch(0.20007880032062531D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2760829925537109D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "= Sum(Fields.amount)";
            // 
            // RptGPByClinic
            // 
            this.DataSource = this.sqlGPByClinic;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.clinic,
            this.paymentm});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1,
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.groupHeaderSection4,
            this.groupFooterSection4});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.Name = "FDate";
            reportParameter1.Text = "Desde fecha";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter1.Visible = true;
            reportParameter2.Name = "TDate";
            reportParameter2.Text = "Hasta fecha";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Visible = true;
            reportParameter3.AvailableValues.DataSource = this.sqlClinic;
            reportParameter3.AvailableValues.DisplayMember = "= Fields.name";
            reportParameter3.AvailableValues.ValueMember = "= Fields.clinic_id";
            reportParameter3.MultiValue = true;
            reportParameter3.Name = "Clinic";
            reportParameter3.Text = "Clínica";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.8740158081054688D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sqlGPByClinic;
        private Telerik.Reporting.SqlDataSource sqlClinic;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.Group clinic;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.Group paymentm;
        private Telerik.Reporting.GroupFooterSection groupFooterSection4;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection4;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox comercial_nameDataTextBox;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
    }
}