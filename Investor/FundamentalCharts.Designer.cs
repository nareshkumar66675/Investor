using SoftwareFX.ChartFX;
using System;

namespace Investor
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class FundamentalCharts : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
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

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SoftwareFX.ChartFX.TitleDockable titleDockable1 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable2 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable3 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable4 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable5 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable6 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable13 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable7 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable8 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable9 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable10 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable11 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable12 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable14 = new SoftwareFX.ChartFX.TitleDockable();
            this.A_Stats = new System.Windows.Forms.DataGridView();
            this.A_Exp = new SoftwareFX.ChartFX.Chart();
            this.Q_Exp = new SoftwareFX.ChartFX.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.A_Book = new SoftwareFX.ChartFX.Chart();
            this.Q_Book = new SoftwareFX.ChartFX.Chart();
            this.A_Liab = new SoftwareFX.ChartFX.Chart();
            this.Q_Liab = new SoftwareFX.ChartFX.Chart();
            this.Q_Ast = new SoftwareFX.ChartFX.Chart();
            this.Q_PL = new SoftwareFX.ChartFX.Chart();
            this.Q_CFL = new SoftwareFX.ChartFX.Chart();
            this.A_CF = new SoftwareFX.ChartFX.Chart();
            this.Q_EPS = new SoftwareFX.ChartFX.Chart();
            this.A_EPS = new SoftwareFX.ChartFX.Chart();
            this.Annual_PL = new SoftwareFX.ChartFX.Chart();
            this.A_Ast = new SoftwareFX.ChartFX.Chart();
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
            this.A_Stats.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.A_Stats_CellContentClick);
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
            this.A_Exp.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable1});
            // 
            // Q_Exp
            // 
            this.Q_Exp.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Exp.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Exp.LineWidth = 2;
            this.Q_Exp.Location = new System.Drawing.Point(522, 256);
            this.Q_Exp.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Exp.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Exp.MarkerSize = ((short)(0));
            this.Q_Exp.Name = "Q_Exp";
            this.Q_Exp.NSeries = 3;
            this.Q_Exp.NValues = 10;
            this.Q_Exp.SerLegBox = true;
            this.Q_Exp.Size = new System.Drawing.Size(523, 260);
            this.Q_Exp.TabIndex = 5;
            this.Q_Exp.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable2});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.A_Book, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Q_Book, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.A_Liab, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Q_Liab, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Q_PL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Q_CFL, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.A_CF, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Q_EPS, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.A_EPS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Annual_PL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Q_Exp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.A_Exp, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Q_Ast, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.A_Ast, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 390F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 336F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1045, 2038);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // A_Book
            // 
            this.A_Book.AxisY.LabelsFormat.Decimals = 0;
            this.A_Book.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Book.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Book.LineWidth = 2;
            this.A_Book.Location = new System.Drawing.Point(0, 1789);
            this.A_Book.Margin = new System.Windows.Forms.Padding(0);
            this.A_Book.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Book.Name = "A_Book";
            this.A_Book.NSeries = 3;
            this.A_Book.NValues = 10;
            this.A_Book.SerLegBox = true;
            this.A_Book.Size = new System.Drawing.Size(522, 249);
            this.A_Book.TabIndex = 19;
            this.A_Book.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable3});
            // 
            // Q_Book
            // 
            this.Q_Book.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Book.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Book.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Book.LineWidth = 2;
            this.Q_Book.Location = new System.Drawing.Point(522, 1789);
            this.Q_Book.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Book.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Book.Name = "Q_Book";
            this.Q_Book.NSeries = 3;
            this.Q_Book.NValues = 10;
            this.Q_Book.SerLegBox = true;
            this.Q_Book.Size = new System.Drawing.Size(522, 249);
            this.Q_Book.TabIndex = 18;
            this.Q_Book.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable4});
            // 
            // A_Liab
            // 
            this.A_Liab.AxisY.LabelsFormat.Decimals = 0;
            this.A_Liab.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Liab.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Liab.LineWidth = 2;
            this.A_Liab.Location = new System.Drawing.Point(0, 1453);
            this.A_Liab.Margin = new System.Windows.Forms.Padding(0);
            this.A_Liab.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Liab.Name = "A_Liab";
            this.A_Liab.NSeries = 3;
            this.A_Liab.NValues = 10;
            this.A_Liab.SerLegBox = true;
            this.A_Liab.Size = new System.Drawing.Size(522, 335);
            this.A_Liab.TabIndex = 17;
            this.A_Liab.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable5});
            // 
            // Q_Liab
            // 
            this.Q_Liab.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Liab.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Liab.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Liab.LineWidth = 2;
            this.Q_Liab.Location = new System.Drawing.Point(522, 1453);
            this.Q_Liab.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Liab.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Liab.Name = "Q_Liab";
            this.Q_Liab.NSeries = 3;
            this.Q_Liab.NValues = 10;
            this.Q_Liab.SerLegBox = true;
            this.Q_Liab.Size = new System.Drawing.Size(523, 335);
            this.Q_Liab.TabIndex = 16;
            this.Q_Liab.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable6});
            // 
            // Q_Ast
            // 
            this.Q_Ast.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Ast.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Ast.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Ast.LineWidth = 2;
            this.Q_Ast.Location = new System.Drawing.Point(522, 1063);
            this.Q_Ast.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Ast.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_Ast.Name = "Q_Ast";
            this.Q_Ast.NSeries = 3;
            this.Q_Ast.NValues = 10;
            this.Q_Ast.SerLegBox = true;
            this.Q_Ast.Size = new System.Drawing.Size(522, 387);
            this.Q_Ast.TabIndex = 14;
            this.Q_Ast.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable13});
            // 
            // Q_PL
            // 
            this.Q_PL.AxisY.LabelsFormat.Decimals = 0;
            this.Q_PL.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_PL.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_PL.LineWidth = 2;
            this.Q_PL.Location = new System.Drawing.Point(522, 0);
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
            this.Q_PL.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable7});
            this.Q_PL.TopGap = 8;
            // 
            // Q_CFL
            // 
            this.Q_CFL.AxisY.LabelsFormat.Decimals = 0;
            this.Q_CFL.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_CFL.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_CFL.LineWidth = 2;
            this.Q_CFL.Location = new System.Drawing.Point(522, 799);
            this.Q_CFL.Margin = new System.Windows.Forms.Padding(0);
            this.Q_CFL.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_CFL.Name = "Q_CFL";
            this.Q_CFL.NSeries = 3;
            this.Q_CFL.NValues = 10;
            this.Q_CFL.SerLegBox = true;
            this.Q_CFL.Size = new System.Drawing.Size(523, 260);
            this.Q_CFL.TabIndex = 13;
            this.Q_CFL.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable8});
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
            this.A_CF.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable9});
            // 
            // Q_EPS
            // 
            this.Q_EPS.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_EPS.LineWidth = 2;
            this.Q_EPS.Location = new System.Drawing.Point(522, 517);
            this.Q_EPS.Margin = new System.Windows.Forms.Padding(0);
            this.Q_EPS.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.Q_EPS.Name = "Q_EPS";
            this.Q_EPS.NSeries = 3;
            this.Q_EPS.NValues = 10;
            this.Q_EPS.SerLegBox = true;
            this.Q_EPS.Size = new System.Drawing.Size(523, 280);
            this.Q_EPS.TabIndex = 11;
            this.Q_EPS.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable10});
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
            this.A_EPS.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable11});
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
            this.Annual_PL.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable12});
            // 
            // A_Ast
            // 
            this.A_Ast.AxisY.LabelsFormat.Decimals = 0;
            this.A_Ast.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Ast.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Ast.LineWidth = 2;
            this.A_Ast.Location = new System.Drawing.Point(0, 1063);
            this.A_Ast.Margin = new System.Windows.Forms.Padding(0);
            this.A_Ast.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.A_Ast.Name = "A_Ast";
            this.A_Ast.NSeries = 3;
            this.A_Ast.NValues = 10;
            this.A_Ast.SerLegBox = true;
            this.A_Ast.Size = new System.Drawing.Size(522, 387);
            this.A_Ast.TabIndex = 15;
            this.A_Ast.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable14});
            // 
            // FundamentalCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1064, 861);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.A_Stats);
            this.Location = new System.Drawing.Point(50, 50);
            this.Name = "FundamentalCharts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Investor";
            ((System.ComponentModel.ISupportInitialize)(this.A_Stats)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.DataGridView A_Stats;
        private SoftwareFX.ChartFX.Chart Q_Exp;
        private SoftwareFX.ChartFX.Chart A_Exp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SoftwareFX.ChartFX.Chart Annual_PL;
        private SoftwareFX.ChartFX.Chart Q_PL;
        private SoftwareFX.ChartFX.Chart A_EPS;
        private SoftwareFX.ChartFX.Chart Q_EPS;
        private SoftwareFX.ChartFX.Chart Q_CFL;
        private SoftwareFX.ChartFX.Chart A_CF;
        private Chart Q_Ast;
        private Chart A_Liab;
        private Chart Q_Liab;
        private Chart A_Book;
        private Chart Q_Book;
        private Chart A_Ast;
    }
}