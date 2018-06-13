<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.updateTableGroup = New System.Windows.Forms.GroupBox()
        Me.processLabel = New System.Windows.Forms.Label()
        Me.updateButton = New System.Windows.Forms.Button()
        Me.descriptionQueryGroup = New System.Windows.Forms.GroupBox()
        Me.searchButton = New System.Windows.Forms.Button()
        Me.queryText3 = New System.Windows.Forms.TextBox()
        Me.conjunction2 = New System.Windows.Forms.GroupBox()
        Me.orOption2 = New System.Windows.Forms.RadioButton()
        Me.andOption2 = New System.Windows.Forms.RadioButton()
        Me.queryText2 = New System.Windows.Forms.TextBox()
        Me.conjunction1 = New System.Windows.Forms.GroupBox()
        Me.orOption1 = New System.Windows.Forms.RadioButton()
        Me.andOption1 = New System.Windows.Forms.RadioButton()
        Me.queryText1 = New System.Windows.Forms.TextBox()
        Me.tickerComboBox = New System.Windows.Forms.ComboBox()
        Me.viewChartButton = New System.Windows.Forms.Button()
        Me.overallProgress = New System.Windows.Forms.ProgressBar()
        Me.tableProgress = New System.Windows.Forms.ProgressBar()
        Me.overallLabel = New System.Windows.Forms.Label()
        Me.tableLabel = New System.Windows.Forms.Label()
        Me.updateTableGroup.SuspendLayout()
        Me.descriptionQueryGroup.SuspendLayout()
        Me.conjunction2.SuspendLayout()
        Me.conjunction1.SuspendLayout()
        Me.SuspendLayout()
        '
        'updateTableGroup
        '
        Me.updateTableGroup.Controls.Add(Me.tableLabel)
        Me.updateTableGroup.Controls.Add(Me.overallLabel)
        Me.updateTableGroup.Controls.Add(Me.tableProgress)
        Me.updateTableGroup.Controls.Add(Me.overallProgress)
        Me.updateTableGroup.Controls.Add(Me.processLabel)
        Me.updateTableGroup.Controls.Add(Me.updateButton)
        Me.updateTableGroup.Location = New System.Drawing.Point(110, 25)
        Me.updateTableGroup.Name = "updateTableGroup"
        Me.updateTableGroup.Size = New System.Drawing.Size(398, 165)
        Me.updateTableGroup.TabIndex = 0
        Me.updateTableGroup.TabStop = False
        '
        'processLabel
        '
        Me.processLabel.AutoSize = True
        Me.processLabel.Location = New System.Drawing.Point(98, 132)
        Me.processLabel.Name = "processLabel"
        Me.processLabel.Size = New System.Drawing.Size(0, 13)
        Me.processLabel.TabIndex = 2
        '
        'updateButton
        '
        Me.updateButton.Location = New System.Drawing.Point(153, 48)
        Me.updateButton.Name = "updateButton"
        Me.updateButton.Size = New System.Drawing.Size(100, 23)
        Me.updateButton.TabIndex = 1
        Me.updateButton.Text = "Update Tables"
        Me.updateButton.UseVisualStyleBackColor = True
        '
        'descriptionQueryGroup
        '
        Me.descriptionQueryGroup.Controls.Add(Me.searchButton)
        Me.descriptionQueryGroup.Controls.Add(Me.queryText3)
        Me.descriptionQueryGroup.Controls.Add(Me.conjunction2)
        Me.descriptionQueryGroup.Controls.Add(Me.queryText2)
        Me.descriptionQueryGroup.Controls.Add(Me.conjunction1)
        Me.descriptionQueryGroup.Controls.Add(Me.queryText1)
        Me.descriptionQueryGroup.Location = New System.Drawing.Point(24, 421)
        Me.descriptionQueryGroup.Name = "descriptionQueryGroup"
        Me.descriptionQueryGroup.Size = New System.Drawing.Size(574, 137)
        Me.descriptionQueryGroup.TabIndex = 1
        Me.descriptionQueryGroup.TabStop = False
        Me.descriptionQueryGroup.Text = "Company Description Query"
        '
        'searchButton
        '
        Me.searchButton.Location = New System.Drawing.Point(244, 108)
        Me.searchButton.Name = "searchButton"
        Me.searchButton.Size = New System.Drawing.Size(75, 23)
        Me.searchButton.TabIndex = 4
        Me.searchButton.Text = "Search"
        Me.searchButton.UseVisualStyleBackColor = True
        '
        'queryText3
        '
        Me.queryText3.Location = New System.Drawing.Point(467, 55)
        Me.queryText3.Name = "queryText3"
        Me.queryText3.Size = New System.Drawing.Size(100, 20)
        Me.queryText3.TabIndex = 3
        '
        'conjunction2
        '
        Me.conjunction2.Controls.Add(Me.orOption2)
        Me.conjunction2.Controls.Add(Me.andOption2)
        Me.conjunction2.Location = New System.Drawing.Point(365, 38)
        Me.conjunction2.Name = "conjunction2"
        Me.conjunction2.Size = New System.Drawing.Size(75, 55)
        Me.conjunction2.TabIndex = 2
        Me.conjunction2.TabStop = False
        '
        'orOption2
        '
        Me.orOption2.AutoSize = True
        Me.orOption2.Location = New System.Drawing.Point(7, 32)
        Me.orOption2.Name = "orOption2"
        Me.orOption2.Size = New System.Drawing.Size(41, 17)
        Me.orOption2.TabIndex = 1
        Me.orOption2.TabStop = True
        Me.orOption2.Text = "OR"
        Me.orOption2.UseVisualStyleBackColor = True
        '
        'andOption2
        '
        Me.andOption2.AutoSize = True
        Me.andOption2.Location = New System.Drawing.Point(7, 17)
        Me.andOption2.Name = "andOption2"
        Me.andOption2.Size = New System.Drawing.Size(48, 17)
        Me.andOption2.TabIndex = 0
        Me.andOption2.TabStop = True
        Me.andOption2.Text = "AND"
        Me.andOption2.UseVisualStyleBackColor = True
        '
        'queryText2
        '
        Me.queryText2.Location = New System.Drawing.Point(238, 55)
        Me.queryText2.Name = "queryText2"
        Me.queryText2.Size = New System.Drawing.Size(100, 20)
        Me.queryText2.TabIndex = 2
        '
        'conjunction1
        '
        Me.conjunction1.Controls.Add(Me.orOption1)
        Me.conjunction1.Controls.Add(Me.andOption1)
        Me.conjunction1.Location = New System.Drawing.Point(136, 38)
        Me.conjunction1.Name = "conjunction1"
        Me.conjunction1.Size = New System.Drawing.Size(75, 55)
        Me.conjunction1.TabIndex = 1
        Me.conjunction1.TabStop = False
        '
        'orOption1
        '
        Me.orOption1.AutoSize = True
        Me.orOption1.Location = New System.Drawing.Point(7, 32)
        Me.orOption1.Name = "orOption1"
        Me.orOption1.Size = New System.Drawing.Size(41, 17)
        Me.orOption1.TabIndex = 1
        Me.orOption1.TabStop = True
        Me.orOption1.Text = "OR"
        Me.orOption1.UseVisualStyleBackColor = True
        '
        'andOption1
        '
        Me.andOption1.AutoSize = True
        Me.andOption1.Location = New System.Drawing.Point(7, 17)
        Me.andOption1.Name = "andOption1"
        Me.andOption1.Size = New System.Drawing.Size(48, 17)
        Me.andOption1.TabIndex = 0
        Me.andOption1.TabStop = True
        Me.andOption1.Text = "AND"
        Me.andOption1.UseVisualStyleBackColor = True
        '
        'queryText1
        '
        Me.queryText1.Location = New System.Drawing.Point(9, 55)
        Me.queryText1.Name = "queryText1"
        Me.queryText1.Size = New System.Drawing.Size(100, 20)
        Me.queryText1.TabIndex = 0
        '
        'tickerComboBox
        '
        Me.tickerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.tickerComboBox.FormattingEnabled = True
        Me.tickerComboBox.Location = New System.Drawing.Point(244, 206)
        Me.tickerComboBox.Name = "tickerComboBox"
        Me.tickerComboBox.Size = New System.Drawing.Size(125, 163)
        Me.tickerComboBox.TabIndex = 2
        '
        'viewChartButton
        '
        Me.viewChartButton.Location = New System.Drawing.Point(268, 375)
        Me.viewChartButton.Name = "viewChartButton"
        Me.viewChartButton.Size = New System.Drawing.Size(75, 23)
        Me.viewChartButton.TabIndex = 3
        Me.viewChartButton.Text = "View Chart"
        Me.viewChartButton.UseVisualStyleBackColor = True
        '
        'overallProgress
        '
        Me.overallProgress.Location = New System.Drawing.Point(114, 77)
        Me.overallProgress.Name = "overallProgress"
        Me.overallProgress.Size = New System.Drawing.Size(177, 13)
        Me.overallProgress.Step = 1
        Me.overallProgress.TabIndex = 3
        Me.overallProgress.Visible = False
        '
        'tableProgress
        '
        Me.tableProgress.Location = New System.Drawing.Point(114, 96)
        Me.tableProgress.Name = "tableProgress"
        Me.tableProgress.Size = New System.Drawing.Size(177, 13)
        Me.tableProgress.Step = 1
        Me.tableProgress.TabIndex = 4
        Me.tableProgress.Visible = False
        '
        'overallLabel
        '
        Me.overallLabel.AutoSize = True
        Me.overallLabel.Location = New System.Drawing.Point(65, 77)
        Me.overallLabel.Name = "overallLabel"
        Me.overallLabel.Size = New System.Drawing.Size(43, 13)
        Me.overallLabel.TabIndex = 5
        Me.overallLabel.Text = "Overall:"
        Me.overallLabel.Visible = False
        '
        'tableLabel
        '
        Me.tableLabel.AutoSize = True
        Me.tableLabel.Location = New System.Drawing.Point(65, 96)
        Me.tableLabel.Name = "tableLabel"
        Me.tableLabel.Size = New System.Drawing.Size(37, 13)
        Me.tableLabel.TabIndex = 6
        Me.tableLabel.Text = "Table:"
        Me.tableLabel.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 570)
        Me.Controls.Add(Me.viewChartButton)
        Me.Controls.Add(Me.tickerComboBox)
        Me.Controls.Add(Me.descriptionQueryGroup)
        Me.Controls.Add(Me.updateTableGroup)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.updateTableGroup.ResumeLayout(False)
        Me.updateTableGroup.PerformLayout()
        Me.descriptionQueryGroup.ResumeLayout(False)
        Me.descriptionQueryGroup.PerformLayout()
        Me.conjunction2.ResumeLayout(False)
        Me.conjunction2.PerformLayout()
        Me.conjunction1.ResumeLayout(False)
        Me.conjunction1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents updateTableGroup As System.Windows.Forms.GroupBox
    Friend WithEvents processLabel As System.Windows.Forms.Label
    Friend WithEvents updateButton As System.Windows.Forms.Button
    Friend WithEvents descriptionQueryGroup As System.Windows.Forms.GroupBox
    Friend WithEvents tickerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents queryText3 As System.Windows.Forms.TextBox
    Friend WithEvents conjunction2 As System.Windows.Forms.GroupBox
    Friend WithEvents queryText2 As System.Windows.Forms.TextBox
    Friend WithEvents conjunction1 As System.Windows.Forms.GroupBox
    Friend WithEvents queryText1 As System.Windows.Forms.TextBox
    Friend WithEvents searchButton As System.Windows.Forms.Button
    Friend WithEvents orOption2 As System.Windows.Forms.RadioButton
    Friend WithEvents andOption2 As System.Windows.Forms.RadioButton
    Friend WithEvents orOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents andOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents viewChartButton As System.Windows.Forms.Button
    Friend WithEvents overallProgress As ProgressBar
    Friend WithEvents tableLabel As Label
    Friend WithEvents overallLabel As Label
    Friend WithEvents tableProgress As ProgressBar
End Class
