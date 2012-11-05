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
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.Drawing.FormattingRule formattingRule2 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            this.sqlClinic = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.ticket_dateDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.amountDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.sqlGPByClinic = new Telerik.Reporting.SqlDataSource();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.clinic = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.comercial_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.paymentm = new Telerik.Reporting.Group();
            this.groupFooterSection4 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection4 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlClinic
            // 
            this.sqlClinic.ConnectionString = "AriClinicContext";
            this.sqlClinic.Name = "sqlClinic";
            this.sqlClinic.SelectCommand = "SELECT        clinic_id, name\r\nFROM            clinic\r\nORDER BY name";
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
            this.textBox1.Value = "Informe general de cobros";
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
            // detail
            // 
            formattingRule1.Filters.AddRange(new Telerik.Reporting.Data.Filter[] {
            new Telerik.Reporting.Data.Filter("= Parameters.Detailed.Value", Telerik.Reporting.Data.FilterOperator.Equal, "false")});
            formattingRule1.Style.Visible = false;
            this.detail.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003938674926758D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ticket_dateDataTextBox,
            this.textBox16,
            this.amountDataTextBox,
            this.textBox18,
            this.textBox19});
            this.detail.Name = "detail";
            // 
            // ticket_dateDataTextBox
            // 
            this.ticket_dateDataTextBox.CanGrow = true;
            this.ticket_dateDataTextBox.Format = "{0:dd/MM/yyyy}";
            this.ticket_dateDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ticket_dateDataTextBox.Name = "ticket_dateDataTextBox";
            this.ticket_dateDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90551191568374634D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.ticket_dateDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.ticket_dateDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.ticket_dateDataTextBox.StyleName = "Data";
            this.ticket_dateDataTextBox.Value = "= Fields.payment_date";
            // 
            // textBox16
            // 
            this.textBox16.CanGrow = true;
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.48818826675415D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2520482540130615D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox16.StyleName = "Data";
            this.textBox16.Value = "= Fields.description";
            // 
            // amountDataTextBox
            // 
            this.amountDataTextBox.CanGrow = true;
            this.amountDataTextBox.Format = "{0:##,###,##0.00 €}";
            this.amountDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8110237121582031D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.amountDataTextBox.Name = "amountDataTextBox";
            this.amountDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99967193603515625D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.amountDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.amountDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.amountDataTextBox.StyleName = "Data";
            this.amountDataTextBox.Value = "= Fields.amount";
            // 
            // textBox18
            // 
            this.textBox18.CanGrow = true;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1174023151397705D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox18.StyleName = "Data";
            this.textBox18.Value = "= Fields.comercial_name";
            // 
            // textBox19
            // 
            this.textBox19.CanGrow = true;
            this.textBox19.Format = "{0:dd/MM/yyyy}";
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2842520475387573D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.90551191568374634D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox19.StyleName = "Data";
            this.textBox19.Value = "= Fields.service_note_date";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23622067272663117D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.textBox21,
            this.pageInfoTextBox,
            this.textBox22});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Format = "{0:d}";
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.currentTimeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // textBox21
            // 
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3813977241516113D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49261793494224548D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox21.StyleName = "PageInfo";
            this.textBox21.Value = "= PageCount";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.0376477241516113D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0831693410873413D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // textBox22
            // 
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.1418147087097168D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.23622004687786102D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox22.Value = "/";
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
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.36886820197105408D);
            this.groupFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox26,
            this.textBox25});
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            formattingRule2.Filters.AddRange(new Telerik.Reporting.Data.Filter[] {
            new Telerik.Reporting.Data.Filter("= Parameters.Detailed.Value", Telerik.Reporting.Data.FilterOperator.Equal, "false")});
            formattingRule2.Style.Visible = false;
            this.groupHeaderSection1.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule2});
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.27559056878089905D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox2,
            this.textBox8,
            this.textBox4,
            this.textBox5});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
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
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3842521905899048D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
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
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1174023151397705D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
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
            // clinic
            // 
            this.clinic.GroupFooter = this.groupFooterSection2;
            this.clinic.GroupHeader = this.groupHeaderSection2;
            this.clinic.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.clinic_name")});
            this.clinic.Name = "clinic";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.39999997615814209D);
            this.groupFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox24,
            this.textBox23,
            this.textBox20});
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.51566916704177856D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox7,
            this.comercial_nameDataTextBox,
            this.textBox9,
            this.textBox10});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
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
            this.comercial_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.19685046374797821D), Telerik.Reporting.Drawing.Unit.Inch(0.25529193878173828D));
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
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox9.Value = "Total clínica";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Format = "{0:##,###,##0.00 €}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5346126556396484D), Telerik.Reporting.Drawing.Unit.Inch(0.25529193878173828D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2760829925537109D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "= Sum(Fields.amount)";
            // 
            // paymentm
            // 
            this.paymentm.GroupFooter = this.groupFooterSection4;
            this.paymentm.GroupHeader = this.groupHeaderSection4;
            this.paymentm.Groupings.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.pmethod_name")});
            this.paymentm.Name = "paymentm";
            // 
            // groupFooterSection4
            // 
            this.groupFooterSection4.Height = Telerik.Reporting.Drawing.Unit.Inch(0.09996100515127182D);
            this.groupFooterSection4.Name = "groupFooterSection4";
            // 
            // groupHeaderSection4
            // 
            this.groupHeaderSection4.Height = Telerik.Reporting.Drawing.Unit.Inch(0.60007888078689575D);
            this.groupHeaderSection4.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox6,
            this.textBox11,
            this.textBox12,
            this.textBox15});
            this.groupHeaderSection4.Name = "groupHeaderSection4";
            // 
            // textBox6
            // 
            this.textBox6.CanGrow = true;
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Inch(0.3000788688659668D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8951771259307861D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox6.StyleName = "Data";
            this.textBox6.Value = "= Fields.pmethod_name";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D), Telerik.Reporting.Drawing.Unit.Inch(0.055291969329118729D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8951771259307861D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Value = "Forma de pago";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Format = "{0:##,###,##0.00 €}";
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5346126556396484D), Telerik.Reporting.Drawing.Unit.Inch(0.3000788688659668D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2760829925537109D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "= Sum(Fields.amount)";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.534614086151123D), Telerik.Reporting.Drawing.Unit.Inch(0.057375431060791016D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.276081919670105D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox15.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox15.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox15.Value = "Total forma pago";
            // 
            // textBox20
            // 
            this.textBox20.CanGrow = true;
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2842520475387573D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0055123567581177D), Telerik.Reporting.Drawing.Unit.Inch(0.19996075332164764D));
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox20.StyleName = "Data";
            this.textBox20.Value = "Total clínica: ";
            // 
            // textBox23
            // 
            this.textBox23.CanGrow = true;
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8951771259307861D), Telerik.Reporting.Drawing.Unit.Inch(0.19996075332164764D));
            this.textBox23.Style.Font.Bold = true;
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox23.StyleName = "Data";
            this.textBox23.Value = "= Fields.clinic_name";
            // 
            // textBox24
            // 
            this.textBox24.CanGrow = true;
            this.textBox24.Format = "{0:##,###,##0.00 €}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5346126556396484D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2760829925537109D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox24.StyleName = "Data";
            this.textBox24.Value = "= Sum(Fields.amount)";
            // 
            // textBox25
            // 
            this.textBox25.CanGrow = true;
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.4270832538604736D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7680943012237549D), Telerik.Reporting.Drawing.Unit.Inch(0.19996075332164764D));
            this.textBox25.Style.Font.Bold = true;
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox25.StyleName = "Data";
            this.textBox25.Value = "TOTAL INFORME: ";
            // 
            // textBox26
            // 
            this.textBox26.CanGrow = true;
            this.textBox26.Format = "{0:##,###,##0.00 €}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5346126556396484D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2760829925537109D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox26.StyleName = "Data";
            this.textBox26.Value = "= Sum(Fields.amount)";
            // 
            // RptGPByClinic
            // 
            this.DataSource = this.sqlGPByClinic;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.clinic,
            this.paymentm});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.groupHeaderSection4,
            this.groupFooterSection4,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
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
            reportParameter4.Name = "Detailed";
            reportParameter4.Text = "¿Con detalle?";
            reportParameter4.Type = Telerik.Reporting.ReportParameterType.Boolean;
            reportParameter4.Value = "true";
            reportParameter4.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
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
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox ticket_dateDataTextBox;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox amountDataTextBox;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
    }
}