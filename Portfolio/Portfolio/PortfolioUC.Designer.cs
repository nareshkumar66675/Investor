namespace Portfolio.Portfolio
{
    partial class PortfolioUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.OtherDtl = new System.Windows.Forms.Label();
            this.TickerListView = new System.Windows.Forms.ListView();
            this.PortfolioNameLbl = new System.Windows.Forms.Label();
            this.Tickers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.OtherDtl);
            this.panel1.Controls.Add(this.TickerListView);
            this.panel1.Controls.Add(this.PortfolioNameLbl);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 180);
            this.panel1.TabIndex = 0;
            // 
            // OtherDtl
            // 
            this.OtherDtl.Location = new System.Drawing.Point(179, 53);
            this.OtherDtl.Name = "OtherDtl";
            this.OtherDtl.Size = new System.Drawing.Size(121, 120);
            this.OtherDtl.TabIndex = 2;
            this.OtherDtl.Text = "Sample Space";
            // 
            // TickerListView
            // 
            this.TickerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tickers});
            this.TickerListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TickerListView.Location = new System.Drawing.Point(13, 53);
            this.TickerListView.Name = "TickerListView";
            this.TickerListView.Size = new System.Drawing.Size(151, 120);
            this.TickerListView.TabIndex = 1;
            this.TickerListView.UseCompatibleStateImageBehavior = false;
            this.TickerListView.View = System.Windows.Forms.View.List;
            // 
            // PortfolioNameLbl
            // 
            this.PortfolioNameLbl.AutoSize = true;
            this.PortfolioNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortfolioNameLbl.Location = new System.Drawing.Point(79, 15);
            this.PortfolioNameLbl.Name = "PortfolioNameLbl";
            this.PortfolioNameLbl.Size = new System.Drawing.Size(142, 22);
            this.PortfolioNameLbl.TabIndex = 0;
            this.PortfolioNameLbl.Text = "Portfolio Name";
            // 
            // PortfolioUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PortfolioUC";
            this.Size = new System.Drawing.Size(325, 202);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label OtherDtl;
        private System.Windows.Forms.ListView TickerListView;
        private System.Windows.Forms.Label PortfolioNameLbl;
        private System.Windows.Forms.ColumnHeader Tickers;
    }
}
