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
            this.SuspendLayout();
            // 
            // DashboardTblLyt
            // 
            this.DashboardTblLyt.AutoScroll = true;
            this.DashboardTblLyt.ColumnCount = 2;
            this.DashboardTblLyt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DashboardTblLyt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DashboardTblLyt.Location = new System.Drawing.Point(12, 12);
            this.DashboardTblLyt.Name = "DashboardTblLyt";
            this.DashboardTblLyt.RowCount = 2;
            this.DashboardTblLyt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DashboardTblLyt.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DashboardTblLyt.Size = new System.Drawing.Size(1179, 575);
            this.DashboardTblLyt.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 810);
            this.Controls.Add(this.DashboardTblLyt);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel DashboardTblLyt;
    }
}