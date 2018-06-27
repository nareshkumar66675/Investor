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
            this.PortfolioUCPanel = new System.Windows.Forms.Panel();
            this.OtherDtl = new System.Windows.Forms.Label();
            this.TickerListView = new System.Windows.Forms.ListView();
            this.Tickers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PortfolioNameLbl = new System.Windows.Forms.Label();
            this.PortfolioUCPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortfolioUCPanel
            // 
            this.PortfolioUCPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PortfolioUCPanel.BackColor = System.Drawing.Color.Silver;
            this.PortfolioUCPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PortfolioUCPanel.Controls.Add(this.OtherDtl);
            this.PortfolioUCPanel.Controls.Add(this.TickerListView);
            this.PortfolioUCPanel.Controls.Add(this.PortfolioNameLbl);
            this.PortfolioUCPanel.Location = new System.Drawing.Point(3, 3);
            this.PortfolioUCPanel.Name = "PortfolioUCPanel";
            this.PortfolioUCPanel.Size = new System.Drawing.Size(308, 180);
            this.PortfolioUCPanel.TabIndex = 0;
            // 
            // OtherDtl
            // 
            this.OtherDtl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.OtherDtl.Font = new System.Drawing.Font("Calibri", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OtherDtl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OtherDtl.Location = new System.Drawing.Point(179, 53);
            this.OtherDtl.Name = "OtherDtl";
            this.OtherDtl.Size = new System.Drawing.Size(112, 111);
            this.OtherDtl.TabIndex = 2;
            this.OtherDtl.Text = "Sample Space";
            this.OtherDtl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TickerListView
            // 
            this.TickerListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TickerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tickers});
            this.TickerListView.Font = new System.Drawing.Font("Calibri", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TickerListView.ForeColor = System.Drawing.Color.Gray;
            this.TickerListView.Location = new System.Drawing.Point(13, 53);
            this.TickerListView.Name = "TickerListView";
            this.TickerListView.Size = new System.Drawing.Size(151, 111);
            this.TickerListView.TabIndex = 1;
            this.TickerListView.UseCompatibleStateImageBehavior = false;
            this.TickerListView.View = System.Windows.Forms.View.List;
            // 
            // PortfolioNameLbl
            // 
            this.PortfolioNameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PortfolioNameLbl.Font = new System.Drawing.Font("Calibri", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortfolioNameLbl.Location = new System.Drawing.Point(13, 10);
            this.PortfolioNameLbl.Name = "PortfolioNameLbl";
            this.PortfolioNameLbl.Size = new System.Drawing.Size(278, 28);
            this.PortfolioNameLbl.TabIndex = 0;
            this.PortfolioNameLbl.Text = "Portfolio Name";
            this.PortfolioNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortfolioUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.PortfolioUCPanel);
            this.Name = "PortfolioUC";
            this.Size = new System.Drawing.Size(314, 186);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PortfolioUC_MouseClick);
            this.PortfolioUCPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PortfolioUCPanel;
        private System.Windows.Forms.Label OtherDtl;
        private System.Windows.Forms.ListView TickerListView;
        private System.Windows.Forms.Label PortfolioNameLbl;
        private System.Windows.Forms.ColumnHeader Tickers;
    }
}
