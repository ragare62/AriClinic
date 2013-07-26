namespace AriCliReport
{
    partial class RptAmendmentInvoice
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptAmendmentInvoice));
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.rptAmendmentInvoiceTaxes1 = new AriCliReport.RptAmendmentInvoiceTaxes();
            this.rptHc1 = new AriCliReport.RptHc();
            this.groupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.groupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
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
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.sqlAInvoice = new Telerik.Reporting.SqlDataSource();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.amountDataTextBox = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.sqlAmendmentInvoice = new Telerik.Reporting.SqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.rptAmendmentInvoiceTaxes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptHc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // rptAmendmentInvoiceTaxes1
            // 
            this.rptAmendmentInvoiceTaxes1.Name = "RptAmendmentInvoiceTaxes";
            // 
            // rptHc1
            // 
            this.rptHc1.Name = "RptHc";
            // 
            // groupFooterSection
            // 
            this.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3386224508285523D);
            this.groupFooterSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport1,
            this.textBox21,
            this.textBox22});
            this.groupFooterSection.Name = "groupFooterSection";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(4D), Telerik.Reporting.Drawing.Unit.Mm(2.0010001659393311D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("ATaxes", "=Fields.amendment_invoice_id"));
            instanceReportSource1.ReportDocument = this.rptAmendmentInvoiceTaxes1;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(137D), Telerik.Reporting.Drawing.Unit.Mm(14.998995780944824D));
            // 
            // textBox21
            // 
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.714724063873291D), Telerik.Reporting.Drawing.Unit.Inch(0.82677173614501953D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.984252393245697D), Telerik.Reporting.Drawing.Unit.Inch(0.25106295943260193D));
            this.textBox21.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox21.Value = "Total factura";
            // 
            // textBox22
            // 
            this.textBox22.CanGrow = true;
            this.textBox22.Format = "{0:##,###,##0.00 €}";
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8188910484313965D), Telerik.Reporting.Drawing.Unit.Inch(0.82677173614501953D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99967193603515625D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox22.StyleName = "Data";
            this.textBox22.Value = "= Fields.ttal";
            // 
            // groupHeaderSection
            // 
            this.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(3.1495668888092041D);
            this.groupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox14,
            this.textBox13,
            this.textBox15,
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
            this.textBox16,
            this.textBox19,
            this.textBox20,
            this.subReport2});
            this.groupHeaderSection.Name = "groupHeaderSection";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.149606466293335D), Telerik.Reporting.Drawing.Unit.Inch(0.27559056878089905D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.7243309020996094D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "FACTURA RECTIFICATIVA";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.149606466293335D), Telerik.Reporting.Drawing.Unit.Inch(0.57566928863525391D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6771655082702637D), Telerik.Reporting.Drawing.Unit.Inch(0.25106295943260193D));
            this.textBox2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox2.Value = "Número: {Fields.srial} - {Fields.yr} - {Fields.invoice_number}";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6768307685852051D), Telerik.Reporting.Drawing.Unit.Inch(1.0235825777053833D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1417320966720581D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox14.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Value = "NIF";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(1.0235825777053833D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8188977241516113D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox13.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox13.Value = "Cliente";
            // 
            // textBox15
            // 
            this.textBox15.Format = "{0:dd/MM/yyyy}";
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(1.2598031759262085D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8188977241516113D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox15.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox15.Value = "= Fields.comercial_name";
            // 
            // textBox3
            // 
            this.textBox3.Format = "{0:dd/MM/yyyy}";
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6768307685852051D), Telerik.Reporting.Drawing.Unit.Inch(1.2598032951354981D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1417317390441895D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Value = "= Fields.vat_in";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:dd/MM/yyyy}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(1.4902527332305908D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8188977241516113D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox4.Value = "= Fields.street";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:dd/MM/yyyy}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(1.720702052116394D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8188977241516113D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox5.Value = "({Fields.post_code}) {Fields.city}";
            // 
            // textBox6
            // 
            this.textBox6.Format = "{0:dd/MM/yyyy}";
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(1.9511514902114868D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8188977241516113D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox6.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox6.Value = "{Fields.province} ";
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(2.3324737548828125D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.535433292388916D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox7.Value = "Fact. Original";
            // 
            // textBox8
            // 
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4488191604614258D), Telerik.Reporting.Drawing.Unit.Inch(2.3324737548828125D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.369743824005127D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox8.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.Value = "Motivo de la rectificación";
            // 
            // textBox9
            // 
            this.textBox9.Format = "{0:dd/MM/yyyy}";
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4488191604614258D), Telerik.Reporting.Drawing.Unit.Inch(2.5590155124664307D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.369743824005127D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox9.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox9.Value = "= Fields.reason";
            // 
            // textBox10
            // 
            this.textBox10.Format = "{0:dd/MM/yyyy}";
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7952756881713867D), Telerik.Reporting.Drawing.Unit.Inch(2.5590155124664307D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5354337692260742D), Telerik.Reporting.Drawing.Unit.Inch(0.23037052154541016D));
            this.textBox10.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox10.Value = "= Fields.invoice_key";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8188910484313965D), Telerik.Reporting.Drawing.Unit.Inch(2.9133472442626953D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99967211484909058D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox11.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox11.Value = "Importe";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.714724063873291D), Telerik.Reporting.Drawing.Unit.Inch(2.9133472442626953D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98425227403640747D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox12.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox12.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Value = "IVA";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.15748031437397003D), Telerik.Reporting.Drawing.Unit.Inch(2.9133472442626953D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.3937010765075684D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox16.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox16.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox16.Value = "Producto / Servicio";
            // 
            // textBox19
            // 
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9287991523742676D), Telerik.Reporting.Drawing.Unit.Inch(0.57566928863525391D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.74795287847518921D), Telerik.Reporting.Drawing.Unit.Inch(0.25106295943260193D));
            this.textBox19.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox19.Value = "Fecha:";
            // 
            // textBox20
            // 
            this.textBox20.Format = "{0:dd/MM/yyyy}";
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6768307685852051D), Telerik.Reporting.Drawing.Unit.Inch(0.57566928863525391D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1417319774627686D), Telerik.Reporting.Drawing.Unit.Inch(0.25106295943260193D));
            this.textBox20.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox20.Value = "= Fields.invoice_date";
            // 
            // subReport2
            // 
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Mm(0D), Telerik.Reporting.Drawing.Unit.Mm(0.0010012307902798057D));
            this.subReport2.Name = "subReport2";
            instanceReportSource2.ReportDocument = this.rptHc1;
            this.subReport2.ReportSource = instanceReportSource2;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Mm(68D), Telerik.Reporting.Drawing.Unit.Mm(42.5572395324707D));
            // 
            // sqlAInvoice
            // 
            this.sqlAInvoice.ConnectionString = "AriClinicContext";
            this.sqlAInvoice.Name = "sqlAInvoice";
            this.sqlAInvoice.SelectCommand = "SELECT        amendment_invoice_id, concat(srial,\"-\",  yr, \"-\",invoice_number) as" +
    " clave\r\nFROM            amendment_invoice";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.15748031437397003D);
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23622067272663117D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox18,
            this.textBox17,
            this.amountDataTextBox});
            this.detail.Name = "detail";
            // 
            // textBox18
            // 
            this.textBox18.CanGrow = true;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.15748023986816406D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.3937010765075684D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox18.StyleName = "Data";
            this.textBox18.Value = "= Fields.description";
            // 
            // textBox17
            // 
            this.textBox17.CanGrow = true;
            this.textBox17.Format = "{0:N2}";
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.714724063873291D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.9842524528503418D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.StyleName = "Data";
            this.textBox17.Value = "= Fields.tax_percentage";
            // 
            // amountDataTextBox
            // 
            this.amountDataTextBox.CanGrow = true;
            this.amountDataTextBox.Format = "{0:##,###,##0.00 €}";
            this.amountDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8188910484313965D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.amountDataTextBox.Name = "amountDataTextBox";
            this.amountDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99967193603515625D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.amountDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.amountDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.amountDataTextBox.StyleName = "Data";
            this.amountDataTextBox.Value = "= Fields.amount";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23622004687786102D);
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // sqlAmendmentInvoice
            // 
            this.sqlAmendmentInvoice.ConnectionString = "AriClinicContext";
            this.sqlAmendmentInvoice.Name = "sqlAmendmentInvoice";
            this.sqlAmendmentInvoice.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@AInvoice", System.Data.DbType.Int32, "=Parameters.AInvoice.Value")});
            this.sqlAmendmentInvoice.SelectCommand = resources.GetString("sqlAmendmentInvoice.SelectCommand");
            // 
            // RptAmendmentInvoice
            // 
            this.DataSource = this.sqlAmendmentInvoice;
            group1.GroupFooter = this.groupFooterSection;
            group1.GroupHeader = this.groupHeaderSection;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.amendment_invoice_id"));
            group1.Name = "grpAmendmentInvoice";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection,
            this.groupFooterSection,
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "RptAmendmentInvoice";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D), Telerik.Reporting.Drawing.Unit.Mm(5D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            reportParameter1.AvailableValues.DataSource = this.sqlAInvoice;
            reportParameter1.AvailableValues.DisplayMember = "= Fields.clave";
            reportParameter1.AvailableValues.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.clave", Telerik.Reporting.SortDirection.Desc));
            reportParameter1.AvailableValues.ValueMember = "= Fields.amendment_invoice_id";
            reportParameter1.Name = "AInvoice";
            reportParameter1.Text = "Factura rectificativa:";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.8740158081054688D);
            ((System.ComponentModel.ISupportInitialize)(this.rptAmendmentInvoiceTaxes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptHc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SqlDataSource sqlAmendmentInvoice;
        private Telerik.Reporting.SqlDataSource sqlAInvoice;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection;
        private Telerik.Reporting.GroupFooterSection groupFooterSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox15;
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
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox amountDataTextBox;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.SubReport subReport1;
        private RptAmendmentInvoiceTaxes rptAmendmentInvoiceTaxes1;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.SubReport subReport2;
        private RptHc rptHc1;
    }
}