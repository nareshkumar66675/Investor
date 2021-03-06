﻿namespace Investor
{
    partial class MainForm
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
            this.viewChartButton = new System.Windows.Forms.Button();
            this.orOption1 = new System.Windows.Forms.RadioButton();
            this.andOption1 = new System.Windows.Forms.RadioButton();
            this.orOption2 = new System.Windows.Forms.RadioButton();
            this.andOption2 = new System.Windows.Forms.RadioButton();
            this.tickerComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.queryText3 = new System.Windows.Forms.TextBox();
            this.processLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.conjunction2 = new System.Windows.Forms.GroupBox();
            this.queryText2 = new System.Windows.Forms.TextBox();
            this.conjunction1 = new System.Windows.Forms.GroupBox();
            this.queryText1 = new System.Windows.Forms.TextBox();
            this.descriptionQueryGroup = new System.Windows.Forms.GroupBox();
            this.updateTableGroup = new System.Windows.Forms.GroupBox();
            this.updateStatus = new System.Windows.Forms.Label();
            this.updateProgressBar = new System.Windows.Forms.ProgressBar();
            this.conjunction2.SuspendLayout();
            this.conjunction1.SuspendLayout();
            this.descriptionQueryGroup.SuspendLayout();
            this.updateTableGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewChartButton
            // 
            this.viewChartButton.Location = new System.Drawing.Point(301, 366);
            this.viewChartButton.Name = "viewChartButton";
            this.viewChartButton.Size = new System.Drawing.Size(75, 23);
            this.viewChartButton.TabIndex = 7;
            this.viewChartButton.Text = "View Chart";
            this.viewChartButton.UseVisualStyleBackColor = true;
            this.viewChartButton.Click += new System.EventHandler(this.ViewChartButton_Click);
            // 
            // orOption1
            // 
            this.orOption1.AutoSize = true;
            this.orOption1.Location = new System.Drawing.Point(7, 32);
            this.orOption1.Name = "orOption1";
            this.orOption1.Size = new System.Drawing.Size(41, 17);
            this.orOption1.TabIndex = 1;
            this.orOption1.TabStop = true;
            this.orOption1.Text = "OR";
            this.orOption1.UseVisualStyleBackColor = true;
            // 
            // andOption1
            // 
            this.andOption1.AutoSize = true;
            this.andOption1.Location = new System.Drawing.Point(7, 17);
            this.andOption1.Name = "andOption1";
            this.andOption1.Size = new System.Drawing.Size(48, 17);
            this.andOption1.TabIndex = 0;
            this.andOption1.TabStop = true;
            this.andOption1.Text = "AND";
            this.andOption1.UseVisualStyleBackColor = true;
            // 
            // orOption2
            // 
            this.orOption2.AutoSize = true;
            this.orOption2.Location = new System.Drawing.Point(7, 32);
            this.orOption2.Name = "orOption2";
            this.orOption2.Size = new System.Drawing.Size(41, 17);
            this.orOption2.TabIndex = 1;
            this.orOption2.TabStop = true;
            this.orOption2.Text = "OR";
            this.orOption2.UseVisualStyleBackColor = true;
            // 
            // andOption2
            // 
            this.andOption2.AutoSize = true;
            this.andOption2.Location = new System.Drawing.Point(7, 17);
            this.andOption2.Name = "andOption2";
            this.andOption2.Size = new System.Drawing.Size(48, 17);
            this.andOption2.TabIndex = 0;
            this.andOption2.TabStop = true;
            this.andOption2.Text = "AND";
            this.andOption2.UseVisualStyleBackColor = true;
            // 
            // tickerComboBox
            // 
            this.tickerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.tickerComboBox.FormattingEnabled = true;
            this.tickerComboBox.Location = new System.Drawing.Point(277, 197);
            this.tickerComboBox.Name = "tickerComboBox";
            this.tickerComboBox.Size = new System.Drawing.Size(125, 163);
            this.tickerComboBox.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(244, 108);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // queryText3
            // 
            this.queryText3.Location = new System.Drawing.Point(467, 55);
            this.queryText3.Name = "queryText3";
            this.queryText3.Size = new System.Drawing.Size(100, 20);
            this.queryText3.TabIndex = 3;
            // 
            // processLabel
            // 
            this.processLabel.AutoSize = true;
            this.processLabel.Location = new System.Drawing.Point(98, 132);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(0, 13);
            this.processLabel.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(150, 33);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 23);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Update Tables";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // conjunction2
            // 
            this.conjunction2.Controls.Add(this.orOption2);
            this.conjunction2.Controls.Add(this.andOption2);
            this.conjunction2.Location = new System.Drawing.Point(365, 38);
            this.conjunction2.Name = "conjunction2";
            this.conjunction2.Size = new System.Drawing.Size(75, 55);
            this.conjunction2.TabIndex = 2;
            this.conjunction2.TabStop = false;
            // 
            // queryText2
            // 
            this.queryText2.Location = new System.Drawing.Point(238, 55);
            this.queryText2.Name = "queryText2";
            this.queryText2.Size = new System.Drawing.Size(100, 20);
            this.queryText2.TabIndex = 2;
            // 
            // conjunction1
            // 
            this.conjunction1.Controls.Add(this.orOption1);
            this.conjunction1.Controls.Add(this.andOption1);
            this.conjunction1.Location = new System.Drawing.Point(136, 38);
            this.conjunction1.Name = "conjunction1";
            this.conjunction1.Size = new System.Drawing.Size(75, 55);
            this.conjunction1.TabIndex = 1;
            this.conjunction1.TabStop = false;
            // 
            // queryText1
            // 
            this.queryText1.Location = new System.Drawing.Point(9, 55);
            this.queryText1.Name = "queryText1";
            this.queryText1.Size = new System.Drawing.Size(100, 20);
            this.queryText1.TabIndex = 0;
            // 
            // descriptionQueryGroup
            // 
            this.descriptionQueryGroup.Controls.Add(this.searchButton);
            this.descriptionQueryGroup.Controls.Add(this.queryText3);
            this.descriptionQueryGroup.Controls.Add(this.conjunction2);
            this.descriptionQueryGroup.Controls.Add(this.queryText2);
            this.descriptionQueryGroup.Controls.Add(this.conjunction1);
            this.descriptionQueryGroup.Controls.Add(this.queryText1);
            this.descriptionQueryGroup.Location = new System.Drawing.Point(57, 412);
            this.descriptionQueryGroup.Name = "descriptionQueryGroup";
            this.descriptionQueryGroup.Size = new System.Drawing.Size(574, 137);
            this.descriptionQueryGroup.TabIndex = 5;
            this.descriptionQueryGroup.TabStop = false;
            this.descriptionQueryGroup.Text = "Company Description Query";
            // 
            // updateTableGroup
            // 
            this.updateTableGroup.Controls.Add(this.updateStatus);
            this.updateTableGroup.Controls.Add(this.updateProgressBar);
            this.updateTableGroup.Controls.Add(this.processLabel);
            this.updateTableGroup.Controls.Add(this.updateButton);
            this.updateTableGroup.Location = new System.Drawing.Point(145, 36);
            this.updateTableGroup.Name = "updateTableGroup";
            this.updateTableGroup.Size = new System.Drawing.Size(398, 142);
            this.updateTableGroup.TabIndex = 4;
            this.updateTableGroup.TabStop = false;
            // 
            // updateStatus
            // 
            this.updateStatus.AutoSize = true;
            this.updateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateStatus.Location = new System.Drawing.Point(153, 111);
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.Size = new System.Drawing.Size(0, 16);
            this.updateStatus.TabIndex = 4;
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Location = new System.Drawing.Point(6, 75);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(386, 23);
            this.updateProgressBar.Step = 1;
            this.updateProgressBar.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 569);
            this.Controls.Add(this.viewChartButton);
            this.Controls.Add(this.tickerComboBox);
            this.Controls.Add(this.descriptionQueryGroup);
            this.Controls.Add(this.updateTableGroup);
            this.Name = "MainForm";
            this.Text = "Investor";
            this.conjunction2.ResumeLayout(false);
            this.conjunction2.PerformLayout();
            this.conjunction1.ResumeLayout(false);
            this.conjunction1.PerformLayout();
            this.descriptionQueryGroup.ResumeLayout(false);
            this.descriptionQueryGroup.PerformLayout();
            this.updateTableGroup.ResumeLayout(false);
            this.updateTableGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button viewChartButton;
        internal System.Windows.Forms.RadioButton orOption1;
        internal System.Windows.Forms.RadioButton andOption1;
        internal System.Windows.Forms.RadioButton orOption2;
        internal System.Windows.Forms.RadioButton andOption2;
        internal System.Windows.Forms.ComboBox tickerComboBox;
        internal System.Windows.Forms.Button searchButton;
        internal System.Windows.Forms.TextBox queryText3;
        internal System.Windows.Forms.Label processLabel;
        internal System.Windows.Forms.Button updateButton;
        internal System.Windows.Forms.GroupBox conjunction2;
        internal System.Windows.Forms.TextBox queryText2;
        internal System.Windows.Forms.GroupBox conjunction1;
        internal System.Windows.Forms.TextBox queryText1;
        internal System.Windows.Forms.GroupBox descriptionQueryGroup;
        internal System.Windows.Forms.GroupBox updateTableGroup;
        private System.Windows.Forms.ProgressBar updateProgressBar;
        private System.Windows.Forms.Label updateStatus;
    }
}