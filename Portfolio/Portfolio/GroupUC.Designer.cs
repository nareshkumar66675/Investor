namespace Portfolio.Portfolio
{
    partial class GroupUC
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
            this.GrpBox = new System.Windows.Forms.GroupBox();
            this.GrpTblLyt = new System.Windows.Forms.TableLayoutPanel();
            this.GrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox
            // 
            this.GrpBox.AutoSize = true;
            this.GrpBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpBox.Controls.Add(this.GrpTblLyt);
            this.GrpBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBox.Location = new System.Drawing.Point(0, 0);
            this.GrpBox.Name = "GrpBox";
            this.GrpBox.Size = new System.Drawing.Size(6, 26);
            this.GrpBox.TabIndex = 0;
            this.GrpBox.TabStop = false;
            this.GrpBox.Text = "groupBox";
            // 
            // GrpTblLyt
            // 
            this.GrpTblLyt.AutoSize = true;
            this.GrpTblLyt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GrpTblLyt.ColumnCount = 1;
            this.GrpTblLyt.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.GrpTblLyt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpTblLyt.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpTblLyt.Location = new System.Drawing.Point(3, 23);
            this.GrpTblLyt.Name = "GrpTblLyt";
            this.GrpTblLyt.RowCount = 1;
            this.GrpTblLyt.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.GrpTblLyt.Size = new System.Drawing.Size(0, 0);
            this.GrpTblLyt.TabIndex = 0;
            // 
            // GroupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.GrpBox);
            this.Name = "GroupUC";
            this.Size = new System.Drawing.Size(6, 26);
            this.GrpBox.ResumeLayout(false);
            this.GrpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox;
        private System.Windows.Forms.TableLayoutPanel GrpTblLyt;
    }
}
