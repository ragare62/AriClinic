namespace AriCliReport
{
    partial class RptInvoiceMain
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptInvoiceMain));
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.rptInvoiceLine1 = new AriCliReport.RptInvoiceLine();
            this.reptInvoiceVAT1 = new AriCliReport.ReptInvoiceVAT();
            this.sqlInvoiceFilter = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.sqlInvoice = new Telerik.Reporting.SqlDataSource();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.subReport2 = new Telerik.Reporting.SubReport();
            ((System.ComponentModel.ISupportInitialize)(this.rptInvoiceLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reptInvoiceVAT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // rptInvoiceLine1
            // 
            this.rptInvoiceLine1.Name = "rptInvoiceLine1";
            // 
            // reptInvoiceVAT1
            // 
            this.reptInvoiceVAT1.Name = "reptInvoiceVAT1";
            // 
            // sqlInvoiceFilter
            // 
            this.sqlInvoiceFilter.ConnectionString = "AriClinicContext";
            this.sqlInvoiceFilter.Name = "sqlInvoiceFilter";
            this.sqlInvoiceFilter.SelectCommand = "SELECT invoice_id, CONCAT(YEAR,\"-\",RIGHT(CONCAT(\"000000\",invoice_number),6),\"-\",S" +
    "ERIAL) AS keyid \r\nFROM invoice ORDER BY 2 DESC;";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23622052371501923D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19685046374797821D);
            this.detail.Name = "detail";
            this.detail.Style.Visible = false;
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // sqlInvoice
            // 
            this.sqlInvoice.ConnectionString = "AriClinicContext";
            this.sqlInvoice.Name = "sqlInvoice";
            this.sqlInvoice.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@InvoiceKey", System.Data.DbType.Int32, "=Parameters.InvoiceKey.Value")});
            this.sqlInvoice.SelectCommand = resources.GetString("sqlInvoice.SelectCommand");
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.10315004736185074D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.PageBreak = Telerik.Reporting.PageBreak.None;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(4.7637796401977539D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox17,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox18,
            this.textBox19,
            this.subReport1,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.subReport2});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3228347301483154D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox1.Value = "FACTURA";
            // 
            // textBox17
            // 
            this.textBox17.Format = "{0:dd/MM/yyyy}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.0377197265625D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.4000003337860107D), Telerik.Reporting.Drawing.Unit.Inch(0.31863212585449219D));
            this.textBox17.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox17.Value = "= Fields.company_name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(0.0010012307902798057D), Telerik.Reporting.Drawing.Unit.Mm(9.0533351898193359D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(12.998998641967773D), Telerik.Reporting.Drawing.Unit.Mm(8.0932559967041016D));
            this.textBox2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox2.Value = "CIF:";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:dd/MM/yyyy}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.5118897557258606D), Telerik.Reporting.Drawing.Unit.Inch(0.3564305305480957D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8881103992462158D), Telerik.Reporting.Drawing.Unit.Inch(0.31863212585449219D));
            this.textBox3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox3.Value = "= Fields.company_vat";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:dd/MM/yyyy}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.67514133453369141D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.3307089805603027D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Value = "= Fields.street";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:dd/MM/yyyy}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.9055907130241394D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2204328775405884D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Value = "= Fields.post_code";
            // 
            // textBox6
            // 
            this.textBox6.Format = "{0:dd/MM/yyyy}";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2205511331558228D), Telerik.Reporting.Drawing.Unit.Inch(0.9055907130241394D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1101577281951904D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox6.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Value = "= Fields.city";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.3000786304473877D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66929197311401367D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Value = "Serie";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9086613655090332D), Telerik.Reporting.Drawing.Unit.Inch(0.3000786304473877D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78740197420120239D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox8.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox8.Value = "Año";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7748031616210938D), Telerik.Reporting.Drawing.Unit.Inch(0.30007871985435486D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.74803179502487183D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox9.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Value = "Número";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:dd/MM/yyyy}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.500157356262207D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66929179430007935D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox10.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Value = "= Fields.serial";
            // 
            // textBox11
            // 
            this.textBox11.Format = "{0:0000}";
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9086613655090332D), Telerik.Reporting.Drawing.Unit.Inch(0.500157356262207D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78740185499191284D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox11.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Value = "= Fields.year";
            // 
            // textBox12
            // 
            this.textBox12.Format = "{0:000000}";
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7748031616210938D), Telerik.Reporting.Drawing.Unit.Inch(0.50015741586685181D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.748030960559845D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox12.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Value = "= Fields.invoice_number";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6929134130477905D), Telerik.Reporting.Drawing.Unit.Inch(1.6141732931137085D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6456694602966309D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox13.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox13.Value = "Cliente";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(1.6141732931137085D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1417320966720581D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox14.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Value = "NIF";
            // 
            // textBox15
            // 
            this.textBox15.Format = "{0:dd/MM/yyyy}";
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6929134130477905D), Telerik.Reporting.Drawing.Unit.Inch(1.8503937721252441D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6456694602966309D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox15.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.Value = "= Fields.cus_name";
            // 
            // textBox16
            // 
            this.textBox16.Format = "{0:dd/MM/yyyy}";
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(1.8503937721252441D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.141731858253479D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox16.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.Value = "= Fields.cus_vat";
            // 
            // textBox18
            // 
            this.textBox18.Format = "{0:dd/MM/yyyy}";
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.1360400915145874D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7559053897857666D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox18.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox18.Value = "= Fields.province";
            // 
            // textBox19
            // 
            this.textBox19.Format = "{0:dd/MM/yyyy}";
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.8346455097198486D), Telerik.Reporting.Drawing.Unit.Inch(1.1360400915145874D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.496063232421875D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox19.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox19.Value = "= Fields.country";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(5.0799989700317383D), Telerik.Reporting.Drawing.Unit.Mm(72.740005493164062D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("InvoiceId", "=Fields.invoice_id"));
            instanceReportSource1.ReportDocument = this.rptInvoiceLine1;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(186.99998474121094D), Telerik.Reporting.Drawing.Unit.Mm(16D));
            this.subReport1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(132.08000183105469D), Telerik.Reporting.Drawing.Unit.Mm(21.940000534057617D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(17.00001335144043D), Telerik.Reporting.Drawing.Unit.Mm(5.9225873947143555D));
            this.textBox20.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox20.Value = "Fecha:";
            // 
            // textBox21
            // 
            this.textBox21.Format = "{0:dd/MM/yyyy}";
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8693709373474121D), Telerik.Reporting.Drawing.Unit.Inch(0.86658173799514771D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6534633636474609D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox21.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox21.Value = "= Fields.invoice_date";
            // 
            // textBox22
            // 
            this.textBox22.Format = "{0:dd/MM/yyyy}";
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6929134130477905D), Telerik.Reporting.Drawing.Unit.Inch(2.0808432102203369D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6456694602966309D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox22.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox22.Value = "= Fields.cus_address";
            // 
            // textBox23
            // 
            this.textBox23.Format = "{0:dd/MM/yyyy}";
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6929134130477905D), Telerik.Reporting.Drawing.Unit.Inch(2.3112924098968506D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6070867776870728D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox23.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox23.Value = "= Fields.cus_postcode";
            // 
            // textBox24
            // 
            this.textBox24.Format = "{0:dd/MM/yyyy}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3000791072845459D), Telerik.Reporting.Drawing.Unit.Inch(2.3112924098968506D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0385036468505859D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox24.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox24.Value = "= Fields.cus_city";
            // 
            // textBox25
            // 
            this.textBox25.Format = "{0:dd/MM/yyyy}";
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6929134130477905D), Telerik.Reporting.Drawing.Unit.Inch(2.5417418479919434D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5070867538452148D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox25.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox25.Value = "= Fields.cus_province";
            // 
            // textBox26
            // 
            this.textBox26.Format = "{0:dd/MM/yyyy}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000789642333984D), Telerik.Reporting.Drawing.Unit.Inch(2.5417418479919434D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1385030746459961D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox26.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox26.Value = "= Fields.cus_country";
            // 
            // subReport2
            // 
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(5.0799989700317383D), Telerik.Reporting.Drawing.Unit.Mm(93.05999755859375D));
            this.subReport2.Name = "subReport2";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("InvoiceIdVat", "=Fields.invoice_id"));
            instanceReportSource2.ReportDocument = this.reptInvoiceVAT1;
            this.subReport2.ReportSource = instanceReportSource2;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(186.99998474121094D), Telerik.Reporting.Drawing.Unit.Mm(21.000001907348633D));
            // 
            // RptInvoiceMain
            // 
            this.DataSource = this.sqlInvoice;
            group1.GroupFooter = this.groupFooterSection1;
            group1.GroupHeader = this.groupHeaderSection1;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.invoice_id"));
            group1.Name = "invoiceId";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "RptInvoiceMain";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AvailableValues.DataSource = this.sqlInvoiceFilter;
            reportParameter1.AvailableValues.DisplayMember = "= Fields.keyid";
            reportParameter1.AvailableValues.ValueMember = "= Fields.invoice_id";
            reportParameter1.MultiValue = true;
            reportParameter1.Name = "InvoiceKey";
            reportParameter1.Text = "Factura ";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.7559056282043457D);
            ((System.ComponentModel.ISupportInitialize)(this.rptInvoiceLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reptInvoiceVAT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sqlInvoice;
        private Telerik.Reporting.SqlDataSource sqlInvoiceFilter;
        private Telerik.Reporting.Group invoiceId;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.SubReport subReport1;
        private RptInvoiceLine rptInvoiceLine1;
        private Telerik.Reporting.SubReport subReport2;
        private ReptInvoiceVAT reptInvoiceVAT1;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
    }
}