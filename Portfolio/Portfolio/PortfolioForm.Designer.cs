namespace Portfolio.Portfolio
{
    partial class PortfolioForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.PrtfNameLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.PrtfNameLbl);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(840, 653);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // PrtfNameLbl
            // 
            this.PrtfNameLbl.Font = new System.Drawing.Font("Calibri", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrtfNameLbl.Location = new System.Drawing.Point(3, 0);
            this.PrtfNameLbl.Name = "PrtfNameLbl";
            this.PrtfNameLbl.Size = new System.Drawing.Size(337, 48);
            this.PrtfNameLbl.TabIndex = 0;
            this.PrtfNameLbl.Text = "label1";
            this.PrtfNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortfolioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 677);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PortfolioForm";
            this.Text = "PortfolioForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label PrtfNameLbl;
    }
}