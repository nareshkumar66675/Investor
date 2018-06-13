<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartForm
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
        Dim TitleDockable1 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable()
        Dim TitleDockable2 As SoftwareFX.ChartFX.TitleDockable = New SoftwareFX.ChartFX.TitleDockable()
        Me.annualChart = New SoftwareFX.ChartFX.Chart()
        Me.quarterlyChart = New SoftwareFX.ChartFX.Chart()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tickerLabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'annualChart
        '
        Me.annualChart.BorderObject = New SoftwareFX.ChartFX.DefaultBorder(SoftwareFX.ChartFX.BorderType.Color, System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)))
        Me.annualChart.DesignTimeData = "C:\Program Files (x86)\ChartFX for .NET 6.2\Wizard\MulltiSeries.txt"
        Me.annualChart.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.annualChart.InsideColor = System.Drawing.Color.White
        Me.annualChart.Location = New System.Drawing.Point(3, 83)
        Me.annualChart.MarkerSize = CType(4, Short)
        Me.annualChart.Name = "annualChart"
        Me.annualChart.NSeries = 3
        Me.annualChart.NValues = 10
        Me.annualChart.SerLegBox = True
        Me.annualChart.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread
        Me.annualChart.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.annualChart.Size = New System.Drawing.Size(542, 470)
        Me.annualChart.TabIndex = 0
        TitleDockable1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        TitleDockable1.Text = "Annual Statements"
        Me.annualChart.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable1})
        '
        'quarterlyChart
        '
        Me.quarterlyChart.BorderObject = New SoftwareFX.ChartFX.DefaultBorder(SoftwareFX.ChartFX.BorderType.Color, System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer)))
        Me.quarterlyChart.DesignTimeData = "C:\Program Files (x86)\ChartFX for .NET 6.2\Wizard\MulltiSeries.txt"
        Me.quarterlyChart.Gallery = SoftwareFX.ChartFX.Gallery.Lines
        Me.quarterlyChart.Location = New System.Drawing.Point(551, 83)
        Me.quarterlyChart.MarkerShape = SoftwareFX.ChartFX.MarkerShape.None
        Me.quarterlyChart.MarkerSize = CType(4, Short)
        Me.quarterlyChart.Name = "quarterlyChart"
        Me.quarterlyChart.NSeries = 3
        Me.quarterlyChart.NValues = 10
        Me.quarterlyChart.SerLegBox = True
        Me.quarterlyChart.SerLegBoxObj.Alignment = SoftwareFX.ChartFX.ToolAlignment.Spread
        Me.quarterlyChart.SerLegBoxObj.Docked = SoftwareFX.ChartFX.Docked.Bottom
        Me.quarterlyChart.Size = New System.Drawing.Size(542, 470)
        Me.quarterlyChart.TabIndex = 1
        TitleDockable2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TitleDockable2.Text = "Quarterly Statements"
        Me.quarterlyChart.Titles.AddRange(New SoftwareFX.ChartFX.TitleDockable() {TitleDockable2})
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.quarterlyChart, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.annualChart, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tickerLabel, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.45087!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.54913!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1096, 556)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'tickerLabel
        '
        Me.tickerLabel.AutoSize = True
        Me.tickerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tickerLabel.Location = New System.Drawing.Point(3, 0)
        Me.tickerLabel.Name = "tickerLabel"
        Me.tickerLabel.Size = New System.Drawing.Size(0, 25)
        Me.tickerLabel.TabIndex = 2
        '
        'ChartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 580)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ChartForm"
        Me.Text = "ChartForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tickerLabel As System.Windows.Forms.Label
    Public WithEvents annualChart As SoftwareFX.ChartFX.Chart
    Public WithEvents quarterlyChart As SoftwareFX.ChartFX.Chart
End Class
