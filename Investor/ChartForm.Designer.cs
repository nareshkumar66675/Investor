using System;

namespace WindowsFormsApp1
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SoftwareFX.ChartFX.TitleDockable titleDockable1 = new SoftwareFX.ChartFX.TitleDockable();
            SoftwareFX.ChartFX.TitleDockable titleDockable2 = new SoftwareFX.ChartFX.TitleDockable();
            this.annualChart = new SoftwareFX.ChartFX.Chart();
            this.quarterlyChart = new SoftwareFX.ChartFX.Chart();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tickerLabel = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // annualChart
            // 
            this.annualChart.BorderObject = new SoftwareFX.ChartFX.DefaultBorder(SoftwareFX.ChartFX.BorderType.Color, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            this.annualChart.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.annualChart.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.annualChart.InsideColor = System.Drawing.Color.White;
            this.annualChart.Location = new System.Drawing.Point(3, 83);
            this.annualChart.MarkerSize = ((short)(4));
            this.annualChart.Name = "annualChart";
            this.annualChart.NSeries = 3;
            this.annualChart.NValues = 10;
            this.annualChart.SerLegBox = true;
            this.annualChart.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread;
            this.annualChart.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.annualChart.Size = new System.Drawing.Size(542, 470);
            this.annualChart.TabIndex = 0;
            titleDockable1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            titleDockable1.Text = "Annual Statements";
            this.annualChart.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable1});
            // 
            // quarterlyChart
            // 
            this.quarterlyChart.BorderObject = new SoftwareFX.ChartFX.DefaultBorder(SoftwareFX.ChartFX.BorderType.Color, System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))));
            this.quarterlyChart.DesignTimeData = "C:\\Program Files (x86)\\ChartFX for .NET 6.2\\Wizard\\MulltiSeries.txt";
            this.quarterlyChart.Gallery = SoftwareFX.ChartFX.Gallery.Lines;
            this.quarterlyChart.Location = new System.Drawing.Point(551, 83);
            this.quarterlyChart.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None;
            this.quarterlyChart.MarkerSize = ((short)(4));
            this.quarterlyChart.Name = "quarterlyChart";
            this.quarterlyChart.NSeries = 3;
            this.quarterlyChart.NValues = 10;
            this.quarterlyChart.SerLegBox = true;
            this.quarterlyChart.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread;
            this.quarterlyChart.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom;
            this.quarterlyChart.Size = new System.Drawing.Size(542, 470);
            this.quarterlyChart.TabIndex = 1;
            titleDockable2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titleDockable2.Text = "Quarterly Statements";
            this.quarterlyChart.Titles.AddRange(new SoftwareFX.ChartFX.TitleDockable[] {
            titleDockable2});
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.quarterlyChart, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.annualChart, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.tickerLabel, 0, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.45087F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.54913F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1096, 556);
            this.TableLayoutPanel1.TabIndex = 2;
            this.TableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.TableLayoutPanel1_Paint);
            // 
            // tickerLabel
            // 
            this.tickerLabel.AutoSize = true;
            this.tickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerLabel.Location = new System.Drawing.Point(3, 0);
            this.tickerLabel.Name = "tickerLabel";
            this.tickerLabel.Size = new System.Drawing.Size(0, 25);
            this.tickerLabel.TabIndex = 2;
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 580);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

            }
        #endregion
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label tickerLabel;
        public SoftwareFX.ChartFX.Chart annualChart;
        public SoftwareFX.ChartFX.Chart quarterlyChart;
    }
}
