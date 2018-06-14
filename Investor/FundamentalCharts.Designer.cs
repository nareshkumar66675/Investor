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
            SoftwareFX.ChartFX.TitleDockable titleDockable7 = new SoftwareFX.ChartFX.TitleDockable();
            this.A_EPS = new SoftwareFX.ChartFX.Chart();
            this.A_Stats = new System.Windows.Forms.DataGridView();
            this.A_Exp = new SoftwareFX.ChartFX.Chart();
            this.Q_PL_Chart = new SoftwareFX.ChartFX.Chart();
            this.Q_Exp = new SoftwareFX.ChartFX.Chart();
            this.Q_EPS = new SoftwareFX.ChartFX.Chart();
            this.Annual_PL = new SoftwareFX.ChartFX.Chart();
            this.Q_CF = new SoftwareFX.ChartFX.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.A_Stats)).BeginInit();
            this.SuspendLayout();
            // 
            // A_EPS
            // 
            this.A_EPS.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_EPS.Location = new System.Drawing.Point(0, 543);
            this.A_EPS.Margin = new System.Windows.Forms.Padding(0);
            this.A_EPS.MarkerSize = ((short)(4));
            this.A_EPS.Name = "A_EPS";
            this.A_EPS.NSeries = 3;
            this.A_EPS.NValues = 10;
            this.A_EPS.SerLegBox = true;
            this.A_EPS.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.A_EPS.Size = new System.Drawing.Size(542, 277);
            this.A_EPS.TabIndex = 1;
            this.A_EPS.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable1});
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
            this.A_Stats.Location = new System.Drawing.Point(692, 820);
            this.A_Stats.Name = "A_Stats";
            this.A_Stats.RowHeadersVisible = false;
            this.A_Stats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.A_Stats.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.A_Stats.Size = new System.Drawing.Size(370, 99);
            this.A_Stats.TabIndex = 2;
            // 
            // A_Exp
            // 
            this.A_Exp.AxisY.LabelsFormat.Decimals = 0;
            this.A_Exp.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.A_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.A_Exp.Location = new System.Drawing.Point(0, 309);
            this.A_Exp.Margin = new System.Windows.Forms.Padding(0);
            this.A_Exp.MarkerSize = ((short)(0));
            this.A_Exp.Name = "A_Exp";
            this.A_Exp.NSeries = 3;
            this.A_Exp.NValues = 10;
            this.A_Exp.SerLegBox = true;
            this.A_Exp.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.A_Exp.Size = new System.Drawing.Size(542, 234);
            this.A_Exp.TabIndex = 3;
            this.A_Exp.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable2});
            // 
            // Q_PL_Chart
            // 
            this.Q_PL_Chart.AxisY.LabelsFormat.Decimals = 0;
            this.Q_PL_Chart.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_PL_Chart.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_PL_Chart.Location = new System.Drawing.Point(545, 0);
            this.Q_PL_Chart.Margin = new System.Windows.Forms.Padding(0);
            this.Q_PL_Chart.MarkerSize = ((short)(0));
            this.Q_PL_Chart.Name = "Q_PL";
            this.Q_PL_Chart.NSeries = 3;
            this.Q_PL_Chart.NValues = 10;
            this.Q_PL_Chart.RightGap = 7;
            this.Q_PL_Chart.SerLegBox = true;
            this.Q_PL_Chart.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Near;
            this.Q_PL_Chart.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.Q_PL_Chart.Size = new System.Drawing.Size(529, 309);
            this.Q_PL_Chart.TabIndex = 4;
            this.Q_PL_Chart.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable3});
            this.Q_PL_Chart.TopGap = 8;
            // 
            // Q_Exp
            // 
            this.Q_Exp.AxisY.LabelsFormat.Decimals = 0;
            this.Q_Exp.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_Exp.Location = new System.Drawing.Point(542, 309);
            this.Q_Exp.Margin = new System.Windows.Forms.Padding(0);
            this.Q_Exp.MarkerSize = ((short)(0));
            this.Q_Exp.Name = "Q_Exp";
            this.Q_Exp.NSeries = 3;
            this.Q_Exp.NValues = 10;
            this.Q_Exp.SerLegBox = true;
            this.Q_Exp.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.Q_Exp.Size = new System.Drawing.Size(532, 231);
            this.Q_Exp.TabIndex = 5;
            this.Q_Exp.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable4});
            // 
            // Q_EPS
            // 
            this.Q_EPS.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_EPS.Location = new System.Drawing.Point(551, 540);
            this.Q_EPS.Margin = new System.Windows.Forms.Padding(0);
            this.Q_EPS.MarkerSize = ((short)(0));
            this.Q_EPS.Name = "Q_EPS";
            this.Q_EPS.NSeries = 3;
            this.Q_EPS.NValues = 10;
            this.Q_EPS.SerLegBox = true;
            this.Q_EPS.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.Q_EPS.Size = new System.Drawing.Size(514, 277);
            this.Q_EPS.TabIndex = 6;
            this.Q_EPS.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable5});
            // 
            // Annual_PL
            // 
            this.Annual_PL.AxisY.LabelsFormat.Decimals = 0;
            this.Annual_PL.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Annual_PL.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Annual_PL.Location = new System.Drawing.Point(0, 0);
            this.Annual_PL.MarkerSize = ((short)(0));
            this.Annual_PL.Name = "Annual_PL";
            this.Annual_PL.NSeries = 3;
            this.Annual_PL.NValues = 10;
            this.Annual_PL.SerLegBox = true;
            this.Annual_PL.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread;
            this.Annual_PL.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.Annual_PL.Size = new System.Drawing.Size(542, 306);
            this.Annual_PL.TabIndex = 7;
            this.Annual_PL.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable6});
            // 
            // Q_CF
            // 
            this.Q_CF.AxisY.LabelsFormat.Decimals = 0;
            this.Q_CF.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.Q_CF.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.Q_CF.Location = new System.Drawing.Point(0, 0);
            this.Q_CF.MarkerSize = ((short)(0));
            this.Q_CF.Name = "Q_CF";
            this.Q_CF.NSeries = 3;
            this.Q_CF.NValues = 10;
            this.Q_CF.SerLegBox = true;
            this.Q_CF.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread;
            this.Q_CF.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.Q_CF.Size = new System.Drawing.Size(542, 306);
            this.Q_CF.TabIndex = 8;
            this.Q_CF.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable7});
            // 
            // FundamentalCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 962);
            this.Controls.Add(this.Annual_PL);
            this.Controls.Add(this.Q_EPS);
            this.Controls.Add(this.Q_Exp);
            this.Controls.Add(this.Q_PL_Chart);
            this.Controls.Add(this.A_Exp);
            this.Controls.Add(this.A_Stats);
            this.Controls.Add(this.A_EPS);
            this.Name = "FundamentalCharts";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.A_Stats)).EndInit();
            this.ResumeLayout(false);

        }
        public System.Windows.Forms.DataGridView A_Stats;
        private SoftwareFX.ChartFX.Chart Q_PL_Chart;
        private SoftwareFX.ChartFX.Chart Q_Exp;
        private SoftwareFX.ChartFX.Chart Q_EPS;
        private SoftwareFX.ChartFX.Chart Annual_PL;
        private SoftwareFX.ChartFX.Chart A_EPS;
        private SoftwareFX.ChartFX.Chart A_Exp;
        private SoftwareFX.ChartFX.Chart Q_CF;
    }
}