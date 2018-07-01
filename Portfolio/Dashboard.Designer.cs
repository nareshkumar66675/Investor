namespace Portfolio
{
    partial class Dashboard
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
            this.DashboardTblLyt = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddNewPrtfBtn = new System.Windows.Forms.Button();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DashboardTblLyt
            // 
            this.DashboardTblLyt.AutoScroll = true;
            this.DashboardTblLyt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DashboardTblLyt.ColumnCount = 2;
            this.DashboardTblLyt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DashboardTblLyt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DashboardTblLyt.Location = new System.Drawing.Point(12, 12);
            this.DashboardTblLyt.Name = "DashboardTblLyt";
            this.DashboardTblLyt.RowCount = 1;
            this.DashboardTblLyt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.DashboardTblLyt.Size = new System.Drawing.Size(1106, 548);
            this.DashboardTblLyt.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RefreshBtn);
            this.panel1.Controls.Add(this.AddNewPrtfBtn);
            this.panel1.Location = new System.Drawing.Point(12, 566);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 78);
            this.panel1.TabIndex = 1;
            // 
            // AddNewPrtfBtn
            // 
            this.AddNewPrtfBtn.Font = new System.Drawing.Font("Calibri", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewPrtfBtn.Location = new System.Drawing.Point(464, 28);
            this.AddNewPrtfBtn.Name = "AddNewPrtfBtn";
            this.AddNewPrtfBtn.Size = new System.Drawing.Size(170, 32);
            this.AddNewPrtfBtn.TabIndex = 0;
            this.AddNewPrtfBtn.Text = "Add New Portfolio";
            this.AddNewPrtfBtn.UseVisualStyleBackColor = true;
            this.AddNewPrtfBtn.Click += new System.EventHandler(this.AddNewPrtfBtn_Click);
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Calibri", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.Location = new System.Drawing.Point(991, 28);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(91, 32);
            this.RefreshBtn.TabIndex = 1;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1130, 648);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DashboardTblLyt);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel DashboardTblLyt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddNewPrtfBtn;
        private System.Windows.Forms.Button RefreshBtn;
    }
}