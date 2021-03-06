﻿namespace Portfolio.Portfolio
{
    partial class AddPortfolio
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PortfolioGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prtfTextBox = new System.Windows.Forms.TextBox();
            this.PrtfNameLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyNme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortfolioGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.PortfolioGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.17004F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.82996F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(810, 548);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PortfolioGV
            // 
            this.PortfolioGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PortfolioGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ticker,
            this.CompanyNme});
            this.tableLayoutPanel1.SetColumnSpan(this.PortfolioGV, 2);
            this.PortfolioGV.Location = new System.Drawing.Point(3, 73);
            this.PortfolioGV.Name = "PortfolioGV";
            this.PortfolioGV.Size = new System.Drawing.Size(804, 418);
            this.PortfolioGV.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.prtfTextBox);
            this.panel1.Controls.Add(this.PrtfNameLbl);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 64);
            this.panel1.TabIndex = 1;
            // 
            // prtfTextBox
            // 
            this.prtfTextBox.Font = new System.Drawing.Font("Calibri", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prtfTextBox.Location = new System.Drawing.Point(427, 19);
            this.prtfTextBox.Name = "prtfTextBox";
            this.prtfTextBox.Size = new System.Drawing.Size(361, 26);
            this.prtfTextBox.TabIndex = 1;
            // 
            // PrtfNameLbl
            // 
            this.PrtfNameLbl.AutoSize = true;
            this.PrtfNameLbl.Font = new System.Drawing.Font("Calibri", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrtfNameLbl.Location = new System.Drawing.Point(14, 21);
            this.PrtfNameLbl.Name = "PrtfNameLbl";
            this.PrtfNameLbl.Size = new System.Drawing.Size(113, 19);
            this.PrtfNameLbl.TabIndex = 0;
            this.PrtfNameLbl.Text = "Portfolio Name";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.SaveBtn);
            this.panel2.Location = new System.Drawing.Point(3, 497);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 48);
            this.panel2.TabIndex = 2;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(327, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(130, 36);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Ticker
            // 
            this.Ticker.HeaderText = "Ticker";
            this.Ticker.MinimumWidth = 25;
            this.Ticker.Name = "Ticker";
            // 
            // CompanyName
            // 
            this.CompanyNme.HeaderText = "Company Name";
            this.CompanyNme.MinimumWidth = 25;
            this.CompanyNme.Name = "CompanyName";
            this.CompanyNme.Width = 150;
            // 
            // AddPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddPortfolio";
            this.Text = "AddPortfolio";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PortfolioGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView PortfolioGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox prtfTextBox;
        private System.Windows.Forms.Label PrtfNameLbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNme;
    }
}