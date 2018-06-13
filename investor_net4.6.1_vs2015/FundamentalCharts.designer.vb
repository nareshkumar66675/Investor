<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FundamentalCharts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TitleDockable1 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable
        Dim TitleDockable2 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable
        Dim TitleDockable3 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable
        Dim TitleDockable4 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable
        Dim TitleDockable5 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable
        Dim TitleDockable6 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable
        Me.A_EPS = New SoftwareFX.ChartFX.Chart
        Me.A_Stats = New System.Windows.Forms.DataGridView
        Me.A_Exp = New SoftwareFX.ChartFX.Chart
        Me.Q_PL = New SoftwareFX.ChartFX.Chart
        Me.Q_Exp = New SoftwareFX.ChartFX.Chart
        Me.Q_EPS = New SoftwareFX.ChartFX.Chart
        Me.Annual_PL = New SoftwareFX.ChartFX.Chart
        CType(Me.A_Stats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'A_EPS
        '
        Me.A_EPS.DesignTimeData = "C:\Program Files (x86)\Chart FX DevStudio\ChartFX for .NET\Wizard\MulltiSeries.tx" & _
            "t"
        Me.A_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.A_EPS.Location = New System.Drawing.Point(0, 543)
        Me.A_EPS.Margin = New System.Windows.Forms.Padding(0)
        Me.A_EPS.MarkerSize = CType(4, Short)
        Me.A_EPS.Name = "A_EPS"
        Me.A_EPS.NSeries = 3
        Me.A_EPS.NValues = 10
        Me.A_EPS.SerLegBox = True
        Me.A_EPS.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.A_EPS.Size = New System.Drawing.Size(542, 277)
        Me.A_EPS.TabIndex = 1
        Me.A_EPS.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable1})
        '
        'A_Stats
        '
        Me.A_Stats.AllowUserToAddRows = False
        Me.A_Stats.AllowUserToDeleteRows = False
        Me.A_Stats.AllowUserToResizeColumns = False
        Me.A_Stats.AllowUserToResizeRows = False
        Me.A_Stats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.A_Stats.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.A_Stats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.A_Stats.ColumnHeadersVisible = False
        Me.A_Stats.Location = New System.Drawing.Point(611, 820)
        Me.A_Stats.Name = "A_Stats"
        Me.A_Stats.RowHeadersVisible = False
        Me.A_Stats.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.A_Stats.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.A_Stats.Size = New System.Drawing.Size(370, 99)
        Me.A_Stats.TabIndex = 2
        '
        'A_Exp
        '
        Me.A_Exp.AxisY.LabelsFormat.Decimals = 0
        Me.A_Exp.DesignTimeData = "C:\Program Files (x86)\Chart FX DevStudio\ChartFX for .NET\Wizard\MulltiSeries.tx" & _
            "t"
        Me.A_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.A_Exp.Location = New System.Drawing.Point(0, 309)
        Me.A_Exp.Margin = New System.Windows.Forms.Padding(0)
        Me.A_Exp.MarkerSize = CType(0, Short)
        Me.A_Exp.Name = "A_Exp"
        Me.A_Exp.NSeries = 3
        Me.A_Exp.NValues = 10
        Me.A_Exp.SerLegBox = True
        Me.A_Exp.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.A_Exp.Size = New System.Drawing.Size(542, 234)
        Me.A_Exp.TabIndex = 3
        Me.A_Exp.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable2})
        '
        'Q_PL
        '
        Me.Q_PL.AxisY.LabelsFormat.Decimals = 0
        Me.Q_PL.DesignTimeData = "C:\Program Files (x86)\Chart FX DevStudio\ChartFX for .NET\Wizard\MulltiSeries.tx" & _
            "t"
        Me.Q_PL.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.Q_PL.Location = New System.Drawing.Point(545, 0)
        Me.Q_PL.Margin = New System.Windows.Forms.Padding(0)
        Me.Q_PL.MarkerSize = CType(0, Short)
        Me.Q_PL.Name = "Q_PL"
        Me.Q_PL.NSeries = 3
        Me.Q_PL.NValues = 10
        Me.Q_PL.RightGap = 7
        Me.Q_PL.SerLegBox = True
        Me.Q_PL.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Near
        Me.Q_PL.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.Q_PL.Size = New System.Drawing.Size(529, 309)
        Me.Q_PL.TabIndex = 4
        Me.Q_PL.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable3})
        Me.Q_PL.TopGap = 8
        '
        'Q_Exp
        '
        Me.Q_Exp.AxisY.LabelsFormat.Decimals = 0
        Me.Q_Exp.DesignTimeData = "C:\Program Files (x86)\Chart FX DevStudio\ChartFX for .NET\Wizard\MulltiSeries.tx" & _
            "t"
        Me.Q_Exp.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.Q_Exp.Location = New System.Drawing.Point(542, 309)
        Me.Q_Exp.Margin = New System.Windows.Forms.Padding(0)
        Me.Q_Exp.MarkerSize = CType(0, Short)
        Me.Q_Exp.Name = "Q_Exp"
        Me.Q_Exp.NSeries = 3
        Me.Q_Exp.NValues = 10
        Me.Q_Exp.SerLegBox = True
        Me.Q_Exp.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.Q_Exp.Size = New System.Drawing.Size(532, 231)
        Me.Q_Exp.TabIndex = 5
        Me.Q_Exp.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable4})
        '
        'Q_EPS
        '
        Me.Q_EPS.DesignTimeData = "C:\Program Files (x86)\Chart FX DevStudio\ChartFX for .NET\Wizard\MulltiSeries.tx" & _
            "t"
        Me.Q_EPS.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.Q_EPS.Location = New System.Drawing.Point(551, 540)
        Me.Q_EPS.Margin = New System.Windows.Forms.Padding(0)
        Me.Q_EPS.MarkerSize = CType(0, Short)
        Me.Q_EPS.Name = "Q_EPS"
        Me.Q_EPS.NSeries = 3
        Me.Q_EPS.NValues = 10
        Me.Q_EPS.SerLegBox = True
        Me.Q_EPS.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.Q_EPS.Size = New System.Drawing.Size(514, 277)
        Me.Q_EPS.TabIndex = 6
        Me.Q_EPS.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable5})
        '
        'Annual_PL
        '
        Me.Annual_PL.AxisY.LabelsFormat.Decimals = 0
        Me.Annual_PL.DesignTimeData = "C:\Program Files (x86)\Chart FX DevStudio\ChartFX for .NET\Wizard\MulltiSeries.tx" & _
            "t"
        Me.Annual_PL.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.Annual_PL.Location = New System.Drawing.Point(0, 0)
        Me.Annual_PL.MarkerSize = CType(0, Short)
        Me.Annual_PL.Name = "Annual_PL"
        Me.Annual_PL.NSeries = 3
        Me.Annual_PL.NValues = 10
        Me.Annual_PL.SerLegBox = True
        Me.Annual_PL.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread
        Me.Annual_PL.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.Annual_PL.Size = New System.Drawing.Size(542, 306)
        Me.Annual_PL.TabIndex = 7
        Me.Annual_PL.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable6})
        '
        'FundamentalCharts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1074, 931)
        Me.Controls.Add(Me.Annual_PL)
        Me.Controls.Add(Me.Q_EPS)
        Me.Controls.Add(Me.Q_Exp)
        Me.Controls.Add(Me.Q_PL)
        Me.Controls.Add(Me.A_Exp)
        Me.Controls.Add(Me.A_Stats)
        Me.Controls.Add(Me.A_EPS)
        Me.Name = "FundamentalCharts"
        Me.Text = "Form1"
        CType(Me.A_Stats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents A_EPS As SoftwareFX.ChartFX.Chart
    Friend WithEvents A_Stats As System.Windows.Forms.DataGridView
    Friend WithEvents A_Exp As SoftwareFX.ChartFX.Chart
    Friend WithEvents Q_PL As SoftwareFX.ChartFX.Chart
    Friend WithEvents Q_Exp As SoftwareFX.ChartFX.Chart
    Friend WithEvents Q_EPS As SoftwareFX.ChartFX.Chart
    Friend WithEvents Annual_PL As SoftwareFX.ChartFX.Chart

End Class
