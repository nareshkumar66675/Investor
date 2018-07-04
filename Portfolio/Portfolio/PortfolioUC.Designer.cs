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
            this.PortfolioUCPanel.AutoSize = true;
            this.PortfolioUCPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PortfolioUCPanel.BackColor = System.Drawing.Color.Silver;
            this.PortfolioUCPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PortfolioUCPanel.Controls.Add(this.PortfolioNameLbl);
            this.PortfolioUCPanel.Location = new System.Drawing.Point(3, 3);
            this.PortfolioUCPanel.MinimumSize = new System.Drawing.Size(183, 51);
            this.PortfolioUCPanel.Name = "PortfolioUCPanel";
            this.PortfolioUCPanel.Size = new System.Drawing.Size(183, 51);
            this.PortfolioUCPanel.TabIndex = 0;
            this.PortfolioUCPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PortfolioUCPanel_Paint);
            // 
            // PortfolioNameLbl
            // 
            this.PortfolioNameLbl.AutoEllipsis = true;
            this.PortfolioNameLbl.AutoSize = true;
            this.PortfolioNameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PortfolioNameLbl.Font = new System.Drawing.Font("Calibri", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortfolioNameLbl.Location = new System.Drawing.Point(29, 14);
            this.PortfolioNameLbl.MinimumSize = new System.Drawing.Size(117, 21);
            this.PortfolioNameLbl.Name = "PortfolioNameLbl";
            this.PortfolioNameLbl.Size = new System.Drawing.Size(117, 21);
            this.PortfolioNameLbl.TabIndex = 0;
            this.PortfolioNameLbl.Text = "Portfolio Name";
            this.PortfolioNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PortfolioNameLbl.Click += new System.EventHandler(this.PortfolioNameLbl_Click);
            // 
            // PortfolioUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.PortfolioUCPanel);
            this.Name = "PortfolioUC";
            this.Size = new System.Drawing.Size(189, 57);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PortfolioUC_MouseClick);
            this.PortfolioUCPanel.ResumeLayout(false);
            this.PortfolioUCPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PortfolioUCPanel;
        private System.Windows.Forms.Label PortfolioNameLbl;
    }
}
