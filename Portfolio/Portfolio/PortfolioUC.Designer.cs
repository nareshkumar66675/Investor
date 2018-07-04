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
            this.PortfolioNameLbl = new System.Windows.Forms.Label();
            this.PortfolioUCPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortfolioUCPanel
            // 
            this.PortfolioUCPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PortfolioUCPanel.BackColor = System.Drawing.Color.Silver;
            this.PortfolioUCPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PortfolioUCPanel.Controls.Add(this.PortfolioNameLbl);
            this.PortfolioUCPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortfolioUCPanel.Location = new System.Drawing.Point(0, 0);
            this.PortfolioUCPanel.Name = "PortfolioUCPanel";
            this.PortfolioUCPanel.Size = new System.Drawing.Size(163, 50);
            this.PortfolioUCPanel.TabIndex = 0;
            // 
            // PortfolioNameLbl
            // 
            this.PortfolioNameLbl.AutoEllipsis = true;
            this.PortfolioNameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PortfolioNameLbl.Font = new System.Drawing.Font("Calibri", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortfolioNameLbl.Location = new System.Drawing.Point(20, 12);
            this.PortfolioNameLbl.Name = "PortfolioNameLbl";
            this.PortfolioNameLbl.Size = new System.Drawing.Size(105, 25);
            this.PortfolioNameLbl.TabIndex = 0;
            this.PortfolioNameLbl.Text = "Portfolio Name";
            this.PortfolioNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortfolioUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.PortfolioUCPanel);
            this.MaximumSize = new System.Drawing.Size(163, 50);
            this.Name = "PortfolioUC";
            this.Size = new System.Drawing.Size(163, 50);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PortfolioUC_MouseClick);
            this.PortfolioUCPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PortfolioUCPanel;
        private System.Windows.Forms.Label PortfolioNameLbl;
    }
}
