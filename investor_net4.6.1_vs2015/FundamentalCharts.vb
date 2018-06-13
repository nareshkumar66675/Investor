Public Class FundamentalCharts

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim info(4, 2) As String

        For i As Integer = 0 To 3
            dt.Columns.Add("")
        Next

        info(0, 0) = "mktcap"
        info(0, 1) = "1234"
        info(1, 0) = "prcSales"
        info(1, 1) = "1234"
        info(2, 0) = "eps"
        info(2, 1) = "1234"
        info(3, 0) = "outshares"
        info(3, 1) = "1234"

        dr = dt.NewRow()
        dr(0) = info(0, 0)
        dr(1) = info(0, 1)
        dr(2) = info(3, 0)
        dr(3) = info(3, 1)

        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = info(1, 0)
        dr(1) = info(1, 1)

        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = info(2, 0)
        dr(1) = info(2, 1)

        dt.Rows.Add(dr)

        A_Stats.DataSource = dt

        A_Stats.Width = dt.Columns.Count * A_Stats.Columns(0).Width
        A_Stats.Height = dt.Rows.Count * A_Stats.Rows(0).Height        


    End Sub

    Private Sub Annual_EPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles A_EPS.Load

    End Sub
End Class
