namespace AriCliReport
{
    partial class RptPrescriptionGlasses
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptPrescriptionGlasses));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.sqlPrescriptionGlasses = new Telerik.Reporting.SqlDataSource();
            this.group1 = new Telerik.Reporting.Group();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.comercial_nameDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.sqlSelectPrescription = new Telerik.Reporting.SqlDataSource();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox33 = new Telerik.Reporting.TextBox();
            this.textBox34 = new Telerik.Reporting.TextBox();
            this.textBox35 = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.textBox37 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox41 = new Telerik.Reporting.TextBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox48 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.2992128133773804D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox34,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox48,
            this.textBox49});
            this.detail.Name = "detail";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2784810066223145D), Telerik.Reporting.Drawing.Unit.Inch(0.05826767161488533D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5954561233520508D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBox1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(15D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox1.Value = "Receta de gafas";
            // 
            // sqlPrescriptionGlasses
            // 
            this.sqlPrescriptionGlasses.ConnectionString = "AriClinicContext";
            this.sqlPrescriptionGlasses.Name = "sqlPrescriptionGlasses";
            this.sqlPrescriptionGlasses.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@PreGlasId", System.Data.DbType.Int32, "=Parameters.PreGlasId.Value")});
            this.sqlPrescriptionGlasses.SelectCommand = resources.GetString("sqlPrescriptionGlasses.SelectCommand");
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.id")});
            this.group1.Name = "group1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.6929134130477905D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox7,
            this.comercial_nameDataTextBox,
            this.textBox6,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.9291337728500366D);
            this.groupFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox3,
            this.textBox5,
            this.textBox4});
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.PageBreak = Telerik.Reporting.PageBreak.After;
            // 
            // textBox7
            // 
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox7.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox7.Value = "Fecha";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.141732856631279D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.7000007629394531D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox2.Value = "Observaciones, recomendaciones";
            // 
            // comercial_nameDataTextBox
            // 
            this.comercial_nameDataTextBox.CanGrow = true;
            this.comercial_nameDataTextBox.Format = "{0:dd/MM/yyyy}";
            this.comercial_nameDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.70007872581481934D));
            this.comercial_nameDataTextBox.Name = "comercial_nameDataTextBox";
            this.comercial_nameDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.comercial_nameDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.comercial_nameDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.comercial_nameDataTextBox.StyleName = "Data";
            this.comercial_nameDataTextBox.Value = "= Fields.examination_date";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1000000610947609D), Telerik.Reporting.Drawing.Unit.Inch(0.34181150794029236D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.7000007629394531D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "= Fields.comments";
            // 
            // textBox4
            // 
            this.textBox4.CanGrow = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2166664600372314D), Telerik.Reporting.Drawing.Unit.Inch(1.0126323699951172D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5833339691162109D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox4.StyleName = "Data";
            this.textBox4.Value = "= Fields.sign_MD";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2166664600372314D), Telerik.Reporting.Drawing.Unit.Inch(0.7417328953742981D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5833339691162109D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox5.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox5.Value = "Médico firmante";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox6.Style.BorderColor.Default = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox6.Value = "Paciente";
            // 
            // textBox8
            // 
            this.textBox8.CanGrow = true;
            this.textBox8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.70007878541946411D));
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            this.textBox8.StyleName = "Data";
            this.textBox8.Value = "= Fields.full_name";
            // 
            // textBox9
            // 
            this.textBox9.CanGrow = true;
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D), Telerik.Reporting.Drawing.Unit.Inch(1.4173227548599243D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox9.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.StyleName = "Data";
            this.textBox9.Value = "ESF.";
            // 
            // textBox10
            // 
            this.textBox10.CanGrow = true;
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D), Telerik.Reporting.Drawing.Unit.Inch(1.1979166269302368D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0939731597900391D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.StyleName = "Data";
            this.textBox10.Value = "OJO DERECHO";
            // 
            // textBox11
            // 
            this.textBox11.CanGrow = true;
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2531067132949829D), Telerik.Reporting.Drawing.Unit.Inch(1.4173227548599243D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64330703020095825D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "Data";
            this.textBox11.Value = "CIL";
            // 
            // textBox12
            // 
            this.textBox12.CanGrow = true;
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.896492600440979D), Telerik.Reporting.Drawing.Unit.Inch(1.4173227548599243D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64330703020095825D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox12.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "Data";
            this.textBox12.Value = "EJE";
            // 
            // textBox13
            // 
            this.textBox13.CanGrow = true;
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5398788452148438D), Telerik.Reporting.Drawing.Unit.Inch(1.4173227548599243D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1540943384170532D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox13.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.StyleName = "Data";
            this.textBox13.Value = "PRISMA";
            // 
            // textBox14
            // 
            this.textBox14.CanGrow = true;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7419629096984863D), Telerik.Reporting.Drawing.Unit.Inch(1.4270833730697632D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1540943384170532D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.StyleName = "Data";
            this.textBox14.Value = "PRISMA";
            // 
            // textBox15
            // 
            this.textBox15.CanGrow = true;
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.098576545715332D), Telerik.Reporting.Drawing.Unit.Inch(1.4270833730697632D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64330703020095825D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox15.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.StyleName = "Data";
            this.textBox15.Value = "EJE";
            // 
            // textBox16
            // 
            this.textBox16.CanGrow = true;
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4551906585693359D), Telerik.Reporting.Drawing.Unit.Inch(1.4270833730697632D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64330703020095825D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox16.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.StyleName = "Data";
            this.textBox16.Value = "CIL";
            // 
            // textBox17
            // 
            this.textBox17.CanGrow = true;
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7997210025787354D), Telerik.Reporting.Drawing.Unit.Inch(1.1979166269302368D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0939731597900391D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox17.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.StyleName = "Data";
            this.textBox17.Value = "OJO IZQUIERDO";
            // 
            // textBox18
            // 
            this.textBox18.CanGrow = true;
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8020837306976318D), Telerik.Reporting.Drawing.Unit.Inch(1.4270833730697632D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox18.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.StyleName = "Data";
            this.textBox18.Value = "ESF.";
            // 
            // textBox19
            // 
            this.textBox19.CanGrow = true;
            this.textBox19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.973228931427002D), Telerik.Reporting.Drawing.Unit.Inch(1.4173226356506348D));
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82677173614501953D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox19.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.StyleName = "Data";
            this.textBox19.Value = "CENTROS";
            // 
            // textBox20
            // 
            this.textBox20.CanGrow = true;
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.078740276396274567D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5511811375617981D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox20.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.StyleName = "Data";
            this.textBox20.Value = "Lejos";
            // 
            // textBox21
            // 
            this.textBox21.CanGrow = true;
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.35433068871498108D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5511811375617981D), Telerik.Reporting.Drawing.Unit.Inch(0.39370080828666687D));
            this.textBox21.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.StyleName = "Data";
            this.textBox21.Value = "Todo Uso";
            // 
            // textBox22
            // 
            this.textBox22.CanGrow = true;
            this.textBox22.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.82677173614501953D));
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5511811375617981D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox22.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.textBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox22.StyleName = "Data";
            this.textBox22.Value = "Cerca";
            // 
            // textBox23
            // 
            this.textBox23.CanGrow = true;
            this.textBox23.Format = "{0}";
            this.textBox23.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.StyleName = "Data";
            this.textBox23.Value = "= Fields.far_sphericity_right_eye";
            // 
            // textBox24
            // 
            this.textBox24.CanGrow = true;
            this.textBox24.Format = "{0}";
            this.textBox24.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2531067132949829D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.StyleName = "Data";
            this.textBox24.Value = "= Fields.far_cylinder_right_eye";
            // 
            // textBox25
            // 
            this.textBox25.CanGrow = true;
            this.textBox25.Format = "{0}";
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5593202114105225D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1346530914306641D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.StyleName = "Data";
            this.textBox25.Value = "= Fields.far_prims_right_eye";
            // 
            // textBox26
            // 
            this.textBox26.CanGrow = true;
            this.textBox26.Format = "{0}";
            this.textBox26.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9062134027481079D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox26.StyleName = "Data";
            this.textBox26.Value = "= Fields.far_axis_right_eye";
            // 
            // sqlSelectPrescription
            // 
            this.sqlSelectPrescription.ConnectionString = "AriClinicContext";
            this.sqlSelectPrescription.Name = "sqlSelectPrescription";
            this.sqlSelectPrescription.SelectCommand = resources.GetString("sqlSelectPrescription.SelectCommand");
            // 
            // textBox27
            // 
            this.textBox27.CanGrow = true;
            this.textBox27.Format = "{0}";
            this.textBox27.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1114401817321777D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.StyleName = "Data";
            this.textBox27.Value = "= Fields.far_axis_left_eye";
            // 
            // textBox28
            // 
            this.textBox28.CanGrow = true;
            this.textBox28.Format = "{0}";
            this.textBox28.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7645468711853027D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1346530914306641D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.StyleName = "Data";
            this.textBox28.Value = "= Fields.far_prism_left_eye";
            // 
            // textBox29
            // 
            this.textBox29.CanGrow = true;
            this.textBox29.Format = "{0}";
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.4583334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox29.StyleName = "Data";
            this.textBox29.Value = "= Fields.far_cylinder_left_eye";
            // 
            // textBox30
            // 
            this.textBox30.CanGrow = true;
            this.textBox30.Format = "{0}";
            this.textBox30.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8020837306976318D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.StyleName = "Data";
            this.textBox30.Value = "= Fields.far_sphericity_left_eye";
            // 
            // textBox31
            // 
            this.textBox31.CanGrow = true;
            this.textBox31.Format = "{0}";
            this.textBox31.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.973228931427002D), Telerik.Reporting.Drawing.Unit.Inch(0.048571426421403885D));
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82677143812179565D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox31.StyleName = "Data";
            this.textBox31.Value = "= Fields.far_centers";
            // 
            // textBox32
            // 
            this.textBox32.CanGrow = true;
            this.textBox32.Format = "{0}";
            this.textBox32.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9760231971740723D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82677143812179565D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox32.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox32.StyleName = "Data";
            this.textBox32.Value = "= Fields.both_centers";
            // 
            // textBox33
            // 
            this.textBox33.CanGrow = true;
            this.textBox33.Format = "{0}";
            this.textBox33.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.809356689453125D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox33.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox33.StyleName = "Data";
            this.textBox33.Value = "= Fields.both_sphericity_left_eye";
            // 
            // textBox34
            // 
            this.textBox34.CanGrow = true;
            this.textBox34.Format = "{0}";
            this.textBox34.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.46246337890625D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox34.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox34.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox34.StyleName = "Data";
            this.textBox34.Value = "= Fields.both_cylinder_left_eye";
            // 
            // textBox35
            // 
            this.textBox35.CanGrow = true;
            this.textBox35.Format = "{0}";
            this.textBox35.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7686767578125D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1346530914306641D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox35.StyleName = "Data";
            this.textBox35.Value = "= Fields.both_prism_left_eye";
            // 
            // textBox36
            // 
            this.textBox36.CanGrow = true;
            this.textBox36.Format = "{0}";
            this.textBox36.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.115570068359375D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox36.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox36.StyleName = "Data";
            this.textBox36.Value = "= Fields.both_axis_left_eye";
            // 
            // textBox37
            // 
            this.textBox37.CanGrow = true;
            this.textBox37.Format = "{0}";
            this.textBox37.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9072366952896118D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox37.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox37.StyleName = "Data";
            this.textBox37.Value = "= Fields.both_axis_right_eye";
            // 
            // textBox38
            // 
            this.textBox38.CanGrow = true;
            this.textBox38.Format = "{0}";
            this.textBox38.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5603435039520264D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1346530914306641D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox38.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox38.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox38.StyleName = "Data";
            this.textBox38.Value = "= Fields.both_prism_right_eye";
            // 
            // textBox39
            // 
            this.textBox39.CanGrow = true;
            this.textBox39.Format = "{0}";
            this.textBox39.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2541300058364868D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox39.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox39.StyleName = "Data";
            this.textBox39.Value = "= Fields.both_cylinder_right_eye";
            // 
            // textBox40
            // 
            this.textBox40.CanGrow = true;
            this.textBox40.Format = "{0}";
            this.textBox40.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60102337598800659D), Telerik.Reporting.Drawing.Unit.Inch(0.42101225256919861D));
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox40.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox40.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox40.StyleName = "Data";
            this.textBox40.Value = "= Fields.both_sphericity_right_eye";
            // 
            // textBox41
            // 
            this.textBox41.CanGrow = true;
            this.textBox41.Format = "{0}";
            this.textBox41.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9760231971740723D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82677143812179565D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox41.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox41.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox41.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox41.StyleName = "Data";
            this.textBox41.Value = "= Fields.close_centers";
            // 
            // textBox42
            // 
            this.textBox42.CanGrow = true;
            this.textBox42.Format = "{0}";
            this.textBox42.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.809356689453125D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox42.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox42.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox42.StyleName = "Data";
            this.textBox42.Value = "= Fields.close_sphericity_left_eye";
            // 
            // textBox43
            // 
            this.textBox43.CanGrow = true;
            this.textBox43.Format = "{0}";
            this.textBox43.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.46246337890625D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox43.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox43.StyleName = "Data";
            this.textBox43.Value = "= Fields.close_cylinder_left_eye";
            // 
            // textBox44
            // 
            this.textBox44.CanGrow = true;
            this.textBox44.Format = "{0}";
            this.textBox44.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7686767578125D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1346530914306641D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.StyleName = "Data";
            this.textBox44.Value = "= Fields.close_prism_left_eye";
            // 
            // textBox45
            // 
            this.textBox45.CanGrow = true;
            this.textBox45.Format = "{0}";
            this.textBox45.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.115570068359375D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox45.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox45.StyleName = "Data";
            this.textBox45.Value = "= Fields.close_axis_left_eye";
            // 
            // textBox46
            // 
            this.textBox46.CanGrow = true;
            this.textBox46.Format = "{0}";
            this.textBox46.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9072366952896118D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox46.StyleName = "Data";
            this.textBox46.Value = "= Fields.close_axis_right_eye";
            // 
            // textBox47
            // 
            this.textBox47.CanGrow = true;
            this.textBox47.Format = "{0}";
            this.textBox47.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5603435039520264D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1346530914306641D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox47.StyleName = "Data";
            this.textBox47.Value = "= Fields.close_prism_right_eye";
            // 
            // textBox48
            // 
            this.textBox48.CanGrow = true;
            this.textBox48.Format = "{0}";
            this.textBox48.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2541300058364868D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox48.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox48.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox48.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox48.StyleName = "Data";
            this.textBox48.Value = "= Fields.close_cylinder_right_eye";
            // 
            // textBox49
            // 
            this.textBox49.CanGrow = true;
            this.textBox49.Format = "{0}";
            this.textBox49.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60102337598800659D), Telerik.Reporting.Drawing.Unit.Inch(0.79660290479660034D));
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65302783250808716D), Telerik.Reporting.Drawing.Unit.Inch(0.26033785939216614D));
            this.textBox49.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox49.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox49.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox49.StyleName = "Data";
            this.textBox49.Value = "= Fields.close_sphericity_right_eye";
            // 
            // RptPrescriptionGlasses
            // 
            this.DataSource = this.sqlPrescriptionGlasses;
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.groupHeaderSection1,
            this.groupFooterSection1});
            this.PageSettings.Landscape = true;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Mm(5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A5;
            reportParameter1.AvailableValues.DataSource = this.sqlSelectPrescription;
            reportParameter1.AvailableValues.DisplayMember = "= Fields.examination_date";
            reportParameter1.AvailableValues.ValueMember = "= Fields.id";
            reportParameter1.MultiValue = true;
            reportParameter1.Name = "PreGlasId";
            reportParameter1.Text = "Receta de la fecha";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Mm;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.8740158081054688D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.SqlDataSource sqlPrescriptionGlasses;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox comercial_nameDataTextBox;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.SqlDataSource sqlSelectPrescription;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox textBox33;
        private Telerik.Reporting.TextBox textBox34;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.TextBox textBox37;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox41;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox43;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.TextBox textBox48;
        private Telerik.Reporting.TextBox textBox49;
    }
}