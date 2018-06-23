using SoftwareFX.ChartFX;
using System;

namespace Investor
{
    partial class FundamentalCharts : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        private void InitializeComponent()
        {
            SoftwareFX.ChartFX.TitleDockable titleDockable1 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable2 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable3 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable4 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable5 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable6 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable7 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable8 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable9 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable10 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable11 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable12 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable13 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable14 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable15 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable16 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable17 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable18 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable19 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable20 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable21 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable22 = new SoftwareFX.ChartFX.TitleDockable();
            this.A_Stats = new System.Windows.Forms.DataGridView();
            this.A_Exp = new SoftwareFX.ChartFX.Chart();
            this.Q_Exp = new SoftwareFX.ChartFX.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.A_CF2 = new SoftwareFX.ChartFX.Chart();
            this.Q_CF3 = new SoftwareFX.ChartFX.Chart();
            this.A_CF3 = new SoftwareFX.ChartFX.Chart();
            this.Q_CF2 = new SoftwareFX.ChartFX.Chart();
            this.Q_Eqt = new SoftwareFX.ChartFX.Chart();
            this.A_Eqt = new SoftwareFX.ChartFX.Chart();
            this.Q_LT = new SoftwareFX.ChartFX.Chart();
            this.A_LT = new SoftwareFX.ChartFX.Chart();
            this.A_Liab = new SoftwareFX.ChartFX.Chart();
            this.Q_Liab = new SoftwareFX.ChartFX.Chart();
            this.Q_PL = new SoftwareFX.ChartFX.Chart();
            this.Q_CF = new SoftwareFX.ChartFX.Chart();
            this.A_CF = new SoftwareFX.ChartFX.Chart();
            this.Q_EPS = new SoftwareFX.ChartFX.Chart();
            this.A_EPS = new SoftwareFX.ChartFX.Chart();
            this.Annual_PL = new SoftwareFX.ChartFX.Chart();
            this.Q_Ast = new SoftwareFX.ChartFX.Chart();
            this.A_Ast = new SoftwareFX.ChartFX.Chart();
            this.A_Book = new SoftwareFX.ChartFX.Chart();
            this.Q_Book = new SoftwareFX.ChartFX.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.A_Stats)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // A_Stats
            // 
            this.A_Stats.AllowUserToAddRows = false;
            this.A_Stats.AllowUserToDeleteRows = false;
            this.A_Stats.AllowUserToResizeColumns = false;
            this.A_Stats.AllowUserToResizeRows = false;
            this.A_Stats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.A_Stats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.A_Stats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.A_Stats.ColumnHeadersVisible = false;
            this.A_Stats.Location = new System.Drawing.Point(287, 993);
            this.A_Stats.Name = "A_Stats";
            this.A_Stats.RowHeadersVisible = false;
            this.A_Stats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.A_Stats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.A_Stats.Size = new System.Drawing.Size(522, 11);
            this.A_Stats.TabIndex = 2;
            // 
            // A_Exp
            // 
            this.A_Exp.AxisY.LabelsFormat.Decimals = 0;
            this.A_Exp.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Exp.LineWidth = 2;
            this.A_Exp.Location = new System.Drawing.Point(0, 256);
            this.A_Exp.Margin = new System.Windows.Forms.Padding(0);
            this.A_Exp.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Exp.Name = "A_Exp";
            this.A_Exp.NSeries = 3;
            this.A_Exp.NValues = 10;
            this.A_Exp.SerLegBox = true;
            this.A_Exp.Size = new System.Drawing.Size(522, 260);
            this.A_Exp.TabIndex = 3;
            titleDockable1.Text = "Annual - Expenses";
            this.A_Exp.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable1});
            // 
            // Q_Exp
            // 
            this.Q_Exp.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Exp.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Exp.LineWidth = 2;
            this.Q_Exp.Location = new System.Drawing.Point(523, 256);
            this.Q_Exp.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Exp.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Exp.MarkerSize = ((short)(0));
            this.Q_Exp.Name = "Q_Exp";
            this.Q_Exp.NSeries = 3;
            this.Q_Exp.NValues = 10;
            this.Q_Exp.SerLegBox = true;
            this.Q_Exp.Size = new System.Drawing.Size(523, 260);
            this.Q_Exp.TabIndex = 5;
            titleDockable2.Text = "Quarterly - Expenses";
            this.Q_Exp.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable2});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.A_CF2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Q_CF3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.A_CF3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Q_CF2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Q_Eqt, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.A_Eqt, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.Q_LT, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.A_LT, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.A_Liab, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.Q_Liab, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.Q_PL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Q_CF, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.A_CF, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Q_EPS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.A_EPS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Annual_PL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Q_Exp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.A_Exp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Q_Ast, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.A_Ast, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.A_Book, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.Q_Book, 1, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 257F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 339F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1046, 2879);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // A_CF2
            // 
            this.A_CF2.AxisY.LabelsFormat.Decimals = 0;
            this.A_CF2.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_CF2.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_CF2.LineWidth = 2;
            this.A_CF2.Location = new System.Drawing.Point(0, 1063);
            this.A_CF2.Margin = new System.Windows.Forms.Padding(0);
            this.A_CF2.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_CF2.Name = "A_CF2";
            this.A_CF2.NSeries = 3;
            this.A_CF2.NValues = 10;
            this.A_CF2.SerLegBox = true;
            this.A_CF2.Size = new System.Drawing.Size(522, 250);
            this.A_CF2.TabIndex = 30;
            titleDockable3.Text = "Annual - Cashflow 2";
            this.A_CF2.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable3});
            // 
            // Q_CF3
            // 
            this.Q_CF3.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_CF3.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_CF3.LineWidth = 2;
            this.Q_CF3.Location = new System.Drawing.Point(523, 1313);
            this.Q_CF3.Margin = new System.Windows.Forms.Padding(0);
            this.Q_CF3.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_CF3.Name = "Q_CF3";
            this.Q_CF3.NSeries = 3;
            this.Q_CF3.NValues = 10;
            this.Q_CF3.SerLegBox = true;
            this.Q_CF3.Size = new System.Drawing.Size(522, 250);
            this.Q_CF3.TabIndex = 29;
            titleDockable4.Text = "Quarterly - Cashflow 3";
            this.Q_CF3.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable4});
            // 
            // A_CF3
            // 
            this.A_CF3.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_CF3.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_CF3.LineWidth = 2;
            this.A_CF3.Location = new System.Drawing.Point(0, 1313);
            this.A_CF3.Margin = new System.Windows.Forms.Padding(0);
            this.A_CF3.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_CF3.Name = "A_CF3";
            this.A_CF3.NSeries = 3;
            this.A_CF3.NValues = 10;
            this.A_CF3.SerLegBox = true;
            this.A_CF3.Size = new System.Drawing.Size(522, 250);
            this.A_CF3.TabIndex = 28;
            titleDockable5.Text = "Annual - Cashflow 3";
            this.A_CF3.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable5});
            // 
            // Q_CF2
            // 
            this.Q_CF2.AxisY.LabelsFormat.Decimals = 0;
            this.Q_CF2.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_CF2.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_CF2.LineWidth = 2;
            this.Q_CF2.Location = new System.Drawing.Point(523, 1063);
            this.Q_CF2.Margin = new System.Windows.Forms.Padding(0);
            this.Q_CF2.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_CF2.Name = "Q_CF2";
            this.Q_CF2.NSeries = 3;
            this.Q_CF2.NValues = 10;
            this.Q_CF2.SerLegBox = true;
            this.Q_CF2.Size = new System.Drawing.Size(522, 250);
            this.Q_CF2.TabIndex = 27;
            titleDockable6.Text = "Quarterly - Cashflow 2";
            this.Q_CF2.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable6});
            // 
            // Q_Eqt
            // 
            this.Q_Eqt.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Eqt.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Eqt.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Eqt.LineWidth = 2;
            this.Q_Eqt.Location = new System.Drawing.Point(523, 2419);
            this.Q_Eqt.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Eqt.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Eqt.Name = "Q_Eqt";
            this.Q_Eqt.NSeries = 3;
            this.Q_Eqt.NValues = 10;
            this.Q_Eqt.SerLegBox = true;
            this.Q_Eqt.Size = new System.Drawing.Size(522, 233);
            this.Q_Eqt.TabIndex = 25;
            titleDockable7.Text = "Quarterly - Equity";
            this.Q_Eqt.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable7});
            // 
            // A_Eqt
            // 
            this.A_Eqt.AxisY.LabelsFormat.Decimals = 0;
            this.A_Eqt.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Eqt.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Eqt.LineWidth = 2;
            this.A_Eqt.Location = new System.Drawing.Point(0, 2419);
            this.A_Eqt.Margin = new System.Windows.Forms.Padding(0);
            this.A_Eqt.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Eqt.Name = "A_Eqt";
            this.A_Eqt.NSeries = 3;
            this.A_Eqt.NValues = 10;
            this.A_Eqt.SerLegBox = true;
            this.A_Eqt.Size = new System.Drawing.Size(522, 233);
            this.A_Eqt.TabIndex = 24;
            titleDockable8.Text = "Annual - Equity";
            this.A_Eqt.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable8});
            // 
            // Q_LT
            // 
            this.Q_LT.AxisY.LabelsFormat.Decimals = 0;
            this.Q_LT.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_LT.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_LT.LineWidth = 2;
            this.Q_LT.Location = new System.Drawing.Point(523, 1823);
            this.Q_LT.Margin = new System.Windows.Forms.Padding(0);
            this.Q_LT.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_LT.Name = "Q_LT";
            this.Q_LT.NSeries = 3;
            this.Q_LT.NValues = 10;
            this.Q_LT.SerLegBox = true;
            this.Q_LT.Size = new System.Drawing.Size(522, 257);
            this.Q_LT.TabIndex = 23;
            titleDockable9.Text = "Quarterly - Long Term";
            this.Q_LT.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable9});
            // 
            // A_LT
            // 
            this.A_LT.AxisY.LabelsFormat.Decimals = 0;
            this.A_LT.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_LT.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_LT.LineWidth = 2;
            this.A_LT.Location = new System.Drawing.Point(0, 1823);
            this.A_LT.Margin = new System.Windows.Forms.Padding(0);
            this.A_LT.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_LT.Name = "A_LT";
            this.A_LT.NSeries = 3;
            this.A_LT.NValues = 10;
            this.A_LT.SerLegBox = true;
            this.A_LT.Size = new System.Drawing.Size(522, 257);
            this.A_LT.TabIndex = 22;
            titleDockable10.Text = "Annual - Long Term";
            this.A_LT.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable10});
            // 
            // A_Liab
            // 
            this.A_Liab.AxisY.LabelsFormat.Decimals = 0;
            this.A_Liab.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Liab.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Liab.LineWidth = 2;
            this.A_Liab.Location = new System.Drawing.Point(0, 2080);
            this.A_Liab.Margin = new System.Windows.Forms.Padding(0);
            this.A_Liab.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Liab.Name = "A_Liab";
            this.A_Liab.NSeries = 3;
            this.A_Liab.NValues = 10;
            this.A_Liab.SerLegBox = true;
            this.A_Liab.Size = new System.Drawing.Size(522, 335);
            this.A_Liab.TabIndex = 17;
            titleDockable11.Text = "Annual - Liability";
            this.A_Liab.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable11});
            // 
            // Q_Liab
            // 
            this.Q_Liab.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Liab.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Liab.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Liab.LineWidth = 2;
            this.Q_Liab.Location = new System.Drawing.Point(523, 2080);
            this.Q_Liab.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Liab.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Liab.Name = "Q_Liab";
            this.Q_Liab.NSeries = 3;
            this.Q_Liab.NValues = 10;
            this.Q_Liab.SerLegBox = true;
            this.Q_Liab.Size = new System.Drawing.Size(522, 335);
            this.Q_Liab.TabIndex = 16;
            titleDockable12.Text = "Quarterly - Liability";
            this.Q_Liab.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable12});
            // 
            // Q_PL
            // 
            this.Q_PL.AxisY.LabelsFormat.Decimals = 0;
            this.Q_PL.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_PL.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_PL.LineWidth = 2;
            this.Q_PL.Location = new System.Drawing.Point(523, 0);
            this.Q_PL.Margin = new System.Windows.Forms.Padding(0);
            this.Q_PL.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_PL.Name = "Q_PL";
            this.Q_PL.NSeries = 3;
            this.Q_PL.NValues = 10;
            this.Q_PL.RightGap = 7;
            this.Q_PL.SerLegBox = true;
            this.Q_PL.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Near;
            this.Q_PL.Size = new System.Drawing.Size(523, 256);
            this.Q_PL.TabIndex = 9;
            titleDockable13.Text = "Quarterly - PL";
            this.Q_PL.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable13});
            this.Q_PL.TopGap = 8;
            // 
            // Q_CFL
            // 
            this.Q_CF.AxisY.LabelsFormat.Decimals = 0;
            this.Q_CF.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_CF.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_CF.LineWidth = 2;
            this.Q_CF.Location = new System.Drawing.Point(523, 799);
            this.Q_CF.Margin = new System.Windows.Forms.Padding(0);
            this.Q_CF.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_CF.Name = "Q_CFL";
            this.Q_CF.NSeries = 3;
            this.Q_CF.NValues = 10;
            this.Q_CF.SerLegBox = true;
            this.Q_CF.Size = new System.Drawing.Size(523, 260);
            this.Q_CF.TabIndex = 13;
            titleDockable14.Text = "Quarterly - Cashflow";
            this.Q_CF.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable14});
            // 
            // A_CF
            // 
            this.A_CF.AxisY.LabelsFormat.Decimals = 0;
            this.A_CF.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_CF.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_CF.LineWidth = 2;
            this.A_CF.Location = new System.Drawing.Point(0, 799);
            this.A_CF.Margin = new System.Windows.Forms.Padding(0);
            this.A_CF.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_CF.Name = "A_CF";
            this.A_CF.NSeries = 3;
            this.A_CF.NValues = 10;
            this.A_CF.SerLegBox = true;
            this.A_CF.Size = new System.Drawing.Size(522, 260);
            this.A_CF.TabIndex = 12;
            titleDockable15.Text = "Annual - Cashflow";
            this.A_CF.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable15});
            // 
            // Q_EPS
            // 
            this.Q_EPS.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_EPS.LineWidth = 2;
            this.Q_EPS.Location = new System.Drawing.Point(523, 517);
            this.Q_EPS.Margin = new System.Windows.Forms.Padding(0);
            this.Q_EPS.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_EPS.Name = "Q_EPS";
            this.Q_EPS.NSeries = 3;
            this.Q_EPS.NValues = 10;
            this.Q_EPS.SerLegBox = true;
            this.Q_EPS.Size = new System.Drawing.Size(523, 280);
            this.Q_EPS.TabIndex = 11;
            titleDockable16.Text = "Quarterly - EPS";
            this.Q_EPS.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable16});
            // 
            // A_EPS
            // 
            this.A_EPS.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_EPS.LineWidth = 2;
            this.A_EPS.Location = new System.Drawing.Point(0, 517);
            this.A_EPS.Margin = new System.Windows.Forms.Padding(0);
            this.A_EPS.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_EPS.Name = "A_EPS";
            this.A_EPS.NSeries = 3;
            this.A_EPS.NValues = 10;
            this.A_EPS.SerLegBox = true;
            this.A_EPS.Size = new System.Drawing.Size(522, 280);
            this.A_EPS.TabIndex = 10;
            titleDockable17.Text = "Annual - EPS";
            this.A_EPS.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable17});
            // 
            // Annual_PL
            // 
            this.Annual_PL.AxisY.LabelsFormat.Decimals = 0;
            this.Annual_PL.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Annual_PL.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Annual_PL.LineWidth = 2;
            this.Annual_PL.Location = new System.Drawing.Point(3, 3);
            this.Annual_PL.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Annual_PL.Name = "Annual_PL";
            this.Annual_PL.NSeries = 3;
            this.Annual_PL.NValues = 10;
            this.Annual_PL.SerLegBox = true;
            this.Annual_PL.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread;
            this.Annual_PL.Size = new System.Drawing.Size(516, 250);
            this.Annual_PL.TabIndex = 8;
            titleDockable18.Text = "Annual - PL";
            this.Annual_PL.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable18});
            // 
            // Q_Ast
            // 
            this.Q_Ast.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Ast.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Ast.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Ast.LineWidth = 2;
            this.Q_Ast.Location = new System.Drawing.Point(523, 1563);
            this.Q_Ast.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Ast.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Ast.Name = "Q_Ast";
            this.Q_Ast.NSeries = 3;
            this.Q_Ast.NValues = 10;
            this.Q_Ast.SerLegBox = true;
            this.Q_Ast.Size = new System.Drawing.Size(522, 260);
            this.Q_Ast.TabIndex = 14;
            titleDockable19.Text = "Quarterly - Asset";
            this.Q_Ast.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable19});
            // 
            // A_Ast
            // 
            this.A_Ast.AxisY.LabelsFormat.Decimals = 0;
            this.A_Ast.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Ast.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Ast.LineWidth = 2;
            this.A_Ast.Location = new System.Drawing.Point(0, 1563);
            this.A_Ast.Margin = new System.Windows.Forms.Padding(0);
            this.A_Ast.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Ast.Name = "A_Ast";
            this.A_Ast.NSeries = 3;
            this.A_Ast.NValues = 10;
            this.A_Ast.SerLegBox = true;
            this.A_Ast.Size = new System.Drawing.Size(522, 260);
            this.A_Ast.TabIndex = 15;
            titleDockable20.Text = "Annual - Asset";
            this.A_Ast.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable20});
            // 
            // A_Book
            // 
            this.A_Book.AxisY.LabelsFormat.Decimals = 0;
            this.A_Book.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Book.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Book.LineWidth = 2;
            this.A_Book.Location = new System.Drawing.Point(0, 2652);
            this.A_Book.Margin = new System.Windows.Forms.Padding(0);
            this.A_Book.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Book.Name = "A_Book";
            this.A_Book.NSeries = 3;
            this.A_Book.NValues = 10;
            this.A_Book.Size = new System.Drawing.Size(522, 227);
            this.A_Book.TabIndex = 19;
            this.A_Book.SerLegBox = true;
            titleDockable21.Text = "Annual - Book Value";
            this.A_Book.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable21});
            // 
            // Q_Book
            // 
            this.Q_Book.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Book.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Book.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Book.LineWidth = 2;
            this.Q_Book.Location = new System.Drawing.Point(523, 2652);
            this.Q_Book.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Book.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Book.Name = "Q_Book";
            this.Q_Book.NSeries = 3;
            this.Q_Book.NValues = 10;
            this.Q_Book.Size = new System.Drawing.Size(522, 227);
            this.Q_Book.TabIndex = 18;
            this.Q_Book.SerLegBox = true;
            titleDockable22.Text = "Quarterly - Book Value";
            this.Q_Book.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable22});
            // 
            // FundamentalCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1064, 865);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.A_Stats);
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "FundamentalCharts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Investor";
            ((System.ComponentModel.ISupportInitialize)(this.A_Stats)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public System.Windows.Forms.DataGridView A_Stats;
        private SoftwareFX.ChartFX.Chart Q_Exp;
        private SoftwareFX.ChartFX.Chart A_Exp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SoftwareFX.ChartFX.Chart Annual_PL;
        private SoftwareFX.ChartFX.Chart Q_PL;
        private SoftwareFX.ChartFX.Chart A_EPS;
        private SoftwareFX.ChartFX.Chart Q_EPS;
        private SoftwareFX.ChartFX.Chart Q_CF;
        private SoftwareFX.ChartFX.Chart A_CF;
        private Chart Q_Ast;
        private Chart A_Liab;
        private Chart A_Book;
        private Chart Q_Book;
        private Chart A_Ast;
        private Chart Q_Liab;
        private Chart Q_LT;
        private Chart A_LT;
        private Chart Q_Eqt;
        private Chart A_Eqt;
        private Chart A_CF2;
        private Chart Q_CF3;
        private Chart A_CF3;
        private Chart Q_CF2;
    }
}