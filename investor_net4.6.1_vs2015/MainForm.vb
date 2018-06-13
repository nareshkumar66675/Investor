Imports System.Data.SqlClient
Imports SoftwareFX.ChartFX
Imports System.Security.Cryptography
Imports System.Runtime.Serialization

Public Class MainForm

    'dbf connection members
    Public Const dbfDir As String = "C:\Program Files (x86)\Stock Investor\Professional\"
    Public dbfDirs(1) As String

    Public dbfToTableDict As Dictionary(Of String, String())

    Public Const dbfConnPre As String = "Provider=vfpoledb.1; Data Source="

    'sql connection members
    Public sqlConnStr As String
    Public sqlConn As SqlConnection
    Public sqlAdapter As SqlDataAdapter
    Public dataSet As DataSet

    'query constants
    Public Const tickerQuery As String = "select LTRIM(RTRIM(ticker)) as ticker from si_ci order by ticker"

    'consts
    Public Const nYears As Integer = 7
    Public Const nQuarters As Integer = 8
    Public Const TABLE_NAME_IND = 0
    Public Const PK_NAME_IND = 1
    Public Const COLSPEC_IND = 2
    Public Structure CharttInfo
        Public nSeries As Integer
        Public nvalues As Integer ' # of values in easch series
        Public colName() As String
        Public legend() As String
        Public linewidth() As Integer
        Public rgb(,) As Integer
        Public perend As String
    End Structure



    'md5 hash object
    Public md5 As MD5



    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'initialize sql db connection
        sqlConnStr = "Data Source=" & UCase(Environment.MachineName) & "\SQLEXPRESS;Initial Catalog=Investor;Integrated Security=True"
        sqlConn = New SqlConnection(sqlConnStr)
        Try
            sqlConn.Open()
        Catch ex As Exception
            sqlConnStr = "Server=" & InputBox("Enter server name/address:") & "; Database=Investor; User Id=" &
                InputBox("Enter user name:") & "; Password=" & InputBox("Enter password:") & ";"
            Try
                sqlConn = New SqlConnection(sqlConnStr)
                sqlConn.Open()
            Catch exc As InvalidOperationException
                MsgBox("Unable to connect to given server, please restart the program")
                Exit Sub
            Catch exc As SqlException
                MsgBox("Entered an invalid password or it needs to be reset. Do this and restart the program.")
                Exit Sub
            Catch exc As Exception
                MsgBox("Unknown error. Please try again.")
            End Try
        End Try

        'initialize the dbf directory names
        dbfDirs(0) = dbfDir & "Static\"
        dbfDirs(1) = dbfDir & "Dbfs\"

        'initialize the dbfToTableDict which holds an association between the dbf filename, table name, table primary key name, and SQL types for each column
        dbfToTableDict = New Dictionary(Of String, String())

        For Each line In IO.File.ReadAllLines("overall-structure.txt")
            Dim cols() As String = line.Split({vbTab}, StringSplitOptions.RemoveEmptyEntries)
            dbfToTableDict.Add(cols(0), New List(Of String)(cols).GetRange(1, cols.Length - 1).ToArray())
            ''''dict format [{key},{val}]''''
            ''''[{<dbfFileName>},{<tableName>,<primaryKeyName>,<colspec1>,<colspec2>,...,<colspecn>}]''''
        Next

        'initialize md5
        md5 = MD5.Create()

        Dim qString As String
        qString = " select " &
                        "si_ci.company, si_ci.ticker, " _
                        & "si_date.perend_q1, si_date.perend_q2, si_date.perend_q3, si_date.perend_q4, si_date.perend_q5, si_date.perend_q6, si_date.perend_q7, si_date.perend_q8, " _
                        & "si_date.perend_y1, si_date.perend_y2, si_date.perend_y3, si_date.perend_y4, si_date.perend_y5, si_date.perend_y6, si_date.perend_y7, " _
                        & "si_isq.sales_q1, si_isq.sales_q2, si_isq.sales_q3, si_isq.sales_q4, si_isq.sales_q5, si_isq.sales_q6, si_isq.sales_q7, si_isq.sales_q8, " _
                        & "si_isq.cgs_q1, si_isq.cgs_q2, si_isq.cgs_q3, si_isq.cgs_q4, si_isq.cgs_q5, si_isq.cgs_q6, si_isq.cgs_q7, si_isq.cgs_q8, " _
                        & "si_isq.totexp_q1, si_isq.totexp_q2, si_isq.totexp_q3, si_isq.totexp_q4, si_isq.totexp_q5, si_isq.totexp_q6, si_isq.totexp_q7, si_isq.totexp_q8, " _
                        & "si_isq.epsd_q1, si_isq.epsd_q2, si_isq.epsd_q3, si_isq.epsd_q4, si_isq.epsd_q5, si_isq.epsd_q6, si_isq.epsd_q7, si_isq.epsd_q8, " _
                        & "si_isq.eps_q1, si_isq.eps_q2, si_isq.eps_q3, si_isq.eps_q4, si_isq.eps_q5, si_isq.eps_q6, si_isq.eps_q7, si_isq.eps_q8, " _
                        & "si_isq.epscon_q1, si_isq.epscon_q2, si_isq.epscon_q3, si_isq.epscon_q4, si_isq.epscon_q5, si_isq.epscon_q6, si_isq.epscon_q7, si_isq.epscon_q8, " _
                        & "si_isq.epsdc_q1, si_isq.epsdc_q2, si_isq.epsdc_q3, si_isq.epsdc_q4, si_isq.epsdc_q5, si_isq.epsdc_q6, si_isq.epsdc_q7, si_isq.epsdc_q8, " _
                        & "si_isq.epsnd_q1, si_isq.epsnd_q2, si_isq.epsnd_q3, si_isq.epsnd_q4, si_isq.epsnd_q5, si_isq.epsnd_q6, si_isq.epsnd_q7, si_isq.epsnd_q8, " _
                        & "si_isq.dps_q1, si_isq.dps_q2, si_isq.dps_q3, si_isq.dps_q4, si_isq.dps_q5, si_isq.dps_q6, si_isq.dps_q7, si_isq.dps_q8, " _
                        & "si_isq.dpst_q1, si_isq.dpst_q2, si_isq.dpst_q3, si_isq.dpst_q4, si_isq.dpst_q5, si_isq.dpst_q6, si_isq.dpst_q7, si_isq.dpst_q8, " _
                        & "si_isq.ebit_q1, si_isq.ebit_q2, si_isq.ebit_q3, si_isq.ebit_q4, si_isq.ebit_q5, si_isq.ebit_q6, si_isq.ebit_q7, si_isq.ebit_q8, " _
                        & "si_isq.netinc_q1, si_isq.netinc_q2, si_isq.netinc_q3, si_isq.netinc_q4, si_isq.netinc_q5, si_isq.netinc_q6, si_isq.netinc_q7, si_isq.netinc_q8," _
                        & "si_isq.dep_q1, si_isq.dep_q2, si_isq.dep_q3, si_isq.dep_q4, si_isq.dep_q5, si_isq.dep_q6, si_isq.dep_q7, si_isq.dep_q8," _
                        & "si_isq.rd_q1, si_isq.rd_q2, si_isq.rd_q3, si_isq.rd_q4, si_isq.rd_q5, si_isq.rd_q6, si_isq.rd_q7, si_isq.rd_q8," _
                        & "si_isq.int_q1, si_isq.int_q2, si_isq.int_q3, si_isq.int_q4, si_isq.int_q5, si_isq.int_q6, si_isq.int_q7, si_isq.int_q8," _
                        & "si_isq.uninc_q1, si_isq.uninc_q2, si_isq.uninc_q3, si_isq.uninc_q4, si_isq.uninc_q5, si_isq.uninc_q6, si_isq.uninc_q7, si_isq.uninc_q8," _
                        & "si_isq.othinc_q1, si_isq.othinc_q2, si_isq.othinc_q3, si_isq.othinc_q4, si_isq.othinc_q5, si_isq.othinc_q6, si_isq.othinc_q7, si_isq.othinc_q8," _
                        & "si_isq.intno_q1, si_isq.intno_q2, si_isq.intno_q3, si_isq.intno_q4, si_isq.intno_q5, si_isq.intno_q6, si_isq.intno_q7, si_isq.intno_q8," _
                        & "si_isq.inctax_q1, si_isq.inctax_q2, si_isq.inctax_q3, si_isq.inctax_q4, si_isq.inctax_q5, si_isq.inctax_q6, si_isq.inctax_q7, si_isq.inctax_q8," _
                        & "si_isq.adjust_q1, si_isq.adjust_q2, si_isq.adjust_q3, si_isq.adjust_q4, si_isq.adjust_q5, si_isq.adjust_q6, si_isq.adjust_q7, si_isq.adjust_q8," _
                        & "si_isq.xord_q1, si_isq.xord_q2, si_isq.xord_q3, si_isq.xord_q4, si_isq.xord_q5, si_isq.xord_q6, si_isq.xord_q7, si_isq.xord_q8," _
                        & "si_isa.sales_y1, si_isa.sales_y2, si_isa.sales_y3, si_isa.sales_y4, si_isa.sales_y5, si_isa.sales_y6, si_isa.sales_y7, " _
                        & "si_isa.cgs_y1, si_isa.cgs_y2, si_isa.cgs_y3, si_isa.cgs_y4, si_isa.cgs_y5, si_isa.cgs_y6, si_isa.cgs_y7, " _
                        & "si_isa.totexp_y1, si_isa.totexp_y2, si_isa.totexp_y3, si_isa.totexp_y4, si_isa.totexp_y5, si_isa.totexp_y6, si_isa.totexp_y7, " _
                        & "si_isa.netinc_y1, si_isa.netinc_y2, si_isa.netinc_y3, si_isa.netinc_y4, si_isa.netinc_y5, si_isa.netinc_y6, si_isa.netinc_y7, " _
                        & "si_isa.epsd_y1, si_isa.epsd_y2, si_isa.epsd_y3, si_isa.epsd_y4, si_isa.epsd_y5, si_isa.epsd_y6, si_isa.epsd_y7, " _
                        & "si_isa.eps_y1, si_isa.eps_y2, si_isa.eps_y3, si_isa.eps_y4, si_isa.eps_y5, si_isa.eps_y6, si_isa.eps_y7, " _
                        & "si_isa.epscon_y1, si_isa.epscon_y2, si_isa.epscon_y3, si_isa.epscon_y4, si_isa.epscon_y5, si_isa.epscon_y6, si_isa.epscon_y7, " _
                        & "si_isa.epsdc_y1, si_isa.epsdc_y2, si_isa.epsdc_y3, si_isa.epsdc_y4, si_isa.epsdc_y5, si_isa.epsdc_y6, si_isa.epsdc_y7, " _
                        & "si_isa.epsnd_y1, si_isa.epsnd_y2, si_isa.epsnd_y3, si_isa.epsnd_y4, si_isa.epsnd_y5, si_isa.epsnd_y6, si_isa.epsnd_y7, " _
                        & "si_isa.dps_y1, si_isa.dps_y2, si_isa.dps_y3, si_isa.dps_y4, si_isa.dps_y5, si_isa.dps_y6, si_isa.dps_y7, " _
                        & "si_isa.dpst_y1, si_isa.dpst_y2, si_isa.dpst_y3, si_isa.dpst_y4, si_isa.dpst_y5, si_isa.dpst_y6, si_isa.dpst_y7, " _
                        & "si_isa.ebit_y1, si_isa.ebit_y2, si_isa.ebit_y3, si_isa.ebit_y4, si_isa.ebit_y5, si_isa.ebit_y6, si_isa.ebit_y7, " _
                        & "si_isa.dep_y1, si_isa.dep_y2, si_isa.dep_y3, si_isa.dep_y4, si_isa.dep_y5, si_isa.dep_y6, si_isa.dep_y7," _
                        & "si_isa.rd_y1, si_isa.rd_y2, si_isa.rd_y3, si_isa.rd_y4, si_isa.rd_y5, si_isa.rd_y6, si_isa.rd_y7," _
                        & "si_isa.int_y1, si_isa.int_y2, si_isa.int_y3, si_isa.int_y4, si_isa.int_y5, si_isa.int_y6, si_isa.int_y7," _
                        & "si_isa.uninc_y1, si_isa.uninc_y2, si_isa.uninc_y3, si_isa.uninc_y4, si_isa.uninc_y5, si_isa.uninc_y6, si_isa.uninc_y7," _
                        & "si_isa.othinc_y1, si_isa.othinc_y2, si_isa.othinc_y3, si_isa.othinc_y4, si_isa.othinc_y5, si_isa.othinc_y6, si_isa.othinc_y7," _
                        & "si_isa.intno_y1, si_isa.intno_y2, si_isa.intno_y3, si_isa.intno_y4, si_isa.intno_y5, si_isa.intno_y6, si_isa.intno_y7," _
                        & "si_isa.inctax_y1, si_isa.inctax_y2, si_isa.inctax_y3, si_isa.inctax_y4, si_isa.inctax_y5, si_isa.inctax_y6, si_isa.inctax_y7," _
                        & "si_isa.adjust_y1, si_isa.adjust_y2, si_isa.adjust_y3, si_isa.adjust_y4, si_isa.adjust_y5, si_isa.adjust_y6, si_isa.adjust_y7," _
                       & "si_isa.xord_y1, si_isa.xord_y2, si_isa.xord_y3, si_isa.xord_y4, si_isa.xord_y5, si_isa.xord_y6, si_isa.xord_y7 " _
                       & "from " _
                        & "si_ci join si_isq on si_ci.company_id = si_isq.company_id join " _
                        & "si_isa on si_isq.company_id = si_isa.company_id join " _
                        & "si_date on si_isa.company_id = si_date.company_id " _
                    & "order by si_ci.ticker"

        sqlAdapter = New SqlDataAdapter(qString, sqlConn)
        dataSet = New DataSet
        sqlAdapter.Fill(dataSet)

        'initialize the ticker combobox with ticker symbols ried from the DB with the sqlAdapter
        sqlAdapter = New SqlDataAdapter(tickerQuery, sqlConn)
        Dim tickerDS As DataSet
        tickerDS = New DataSet()
        sqlAdapter.Fill(tickerDS)


        tickerComboBox.DataSource = tickerDS.Tables(0)
        tickerComboBox.ValueMember = "ticker"
        tickerComboBox.DisplayMember = "ticker"


        'close sqlconn
        sqlConn.Close()

    End Sub

    Private Function getHashForRow(row As DataRow) As Byte() 'returns the computed hash value for the datarow, returns a 128-bit (16-byte) byte array
        Dim dataStr As String = ""
        'get the value of each column as a concatenated string
        For Each col In row.ItemArray
            dataStr = dataStr & col.ToString()
        Next
        'return the hash value for the string
        getHashForRow = md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(dataStr))
    End Function

    Private Sub dbfToSQLTables()

        Dim fileInfo As IO.FileInfo
        Dim fileName As String
        Dim tableName As String

        Dim threads As New Collection

        'disable buttons
        updateButton.Enabled = False

        'iterate through each directory with dbf files
        For Each dir As String In dbfDirs
            With My.Computer
                For Each file As String In .FileSystem.GetFiles(dir)
                    fileInfo = .FileSystem.GetFileInfo(file.ToString())
                    If fileInfo.Extension.ToLower() = ".dbf" Then
                        fileName = fileInfo.Name
                        tableName = fileInfo.Name.Replace(fileInfo.Extension, "")
                        'skip if file is not in the dbf spec dictionary
                        If dbfToTableDict.ContainsKey(fileName) Then
                            processLabel.Text = fileName & " transferring to " & tableName & " table, please wait..."
                            processLabel.Refresh()
                            Dim t As New Threading.Thread(Sub() dbfToSQLTable(dbfConnPre & dir, sqlConnStr, fileName))
                            t.Start()
                            t.Join()
                            'threads.Add(t)
                        End If
                    End If
                Next
            End With
        Next

        ''wait for threads to complete
        'For Each t As Threading.Thread In threads
        '    t.Join()
        'Next

        'reenable buttons
        updateButton.Enabled = True

        'remove text and alert the completion of the transfer
        processLabel.Text = ""
        MsgBox("Transfer complete")

    End Sub

    Private Sub dbfToSQLTable(dbfConnString As String, sqlConnString As String, dbfFileName As String)

        'check if table spec exists
        If (Not dbfToTableDict.ContainsKey(dbfFileName)) Then
            Console.WriteLine("Error: there is no table specification in the overall-structure.txt, tab-delimited file for dbf file: " & dbfFileName)
            Exit Sub
        End If

        'table specification from dictionary
        Dim tableSpec() As String = dbfToTableDict(dbfFileName)
        Dim table As String = tableSpec(TABLE_NAME_IND)
        Dim pk As String = tableSpec(PK_NAME_IND)
        Dim colSpec() As String = New List(Of String)(tableSpec).GetRange(COLSPEC_IND, tableSpec.Length - 2).ToArray()

        'connections
        Dim dbfC As New OleDb.OleDbConnection(dbfConnString)
        Dim sqlC As New SqlConnection(sqlConnString)

        'opem connections
        dbfC.Open()
        sqlC.Open()

        'commands
        Dim dbfCommand As New OleDb.OleDbCommand("select * from " & table, dbfC)
        Dim sqlCommand As New SqlCommand("select * from " & table, sqlC)
        Dim sqlTableExistsCommand As New SqlCommand("select * from sys.tables where name = '" & table & "' and type = 'U'", sqlC)
        Dim sqlCreateTableCommand As New SqlCommand()

        'adapters
        Dim dbfA As New OleDb.OleDbDataAdapter(dbfCommand)
        Dim sqlA As New SqlDataAdapter(sqlTableExistsCommand)

        'dataset
        Dim sqlDs As New DataSet()  'for getting records in the sql database
        Dim dbfDs As New DataSet()  'for getting records in the dbf table
        Dim ds As New DataSet()     'for generic queries

        'first fill the dataset to see if the table already exists
        sqlA.Fill(ds)

        'if the table doesn't exist, then create it
        If Not ds.Tables(0).Rows.Count > 0 Then
            Dim commStr As String = "create table " & table & " ("
            For Each col As String In colSpec
                commStr = commStr & col & ", "
            Next
            commStr = commStr & "PRIMARY KEY (" & pk & "));"

            'set the command to create the table and execute it
            sqlCreateTableCommand.CommandText = commStr
            sqlCreateTableCommand.Connection = sqlC
            sqlCreateTableCommand.ExecuteNonQuery()
            'sqlCreateTableCommand.Connection.Close()
        End If

        'clear the generic dataset
        ds.Reset()

        'change the sql adapter command
        sqlA.SelectCommand = sqlCommand

        'now create the command builder
        Dim sqlCommBuild As New SqlCommandBuilder(sqlA)

        'set the sql commands from the command builder
        sqlA.UpdateCommand = sqlCommBuild.GetUpdateCommand()
        sqlA.InsertCommand = sqlCommBuild.GetInsertCommand()
        sqlA.DeleteCommand = sqlCommBuild.GetDeleteCommand()

        'fill the schema for the sql dataset so the primary key is set
        'sqlA.FillSchema(sqlDs, SchemaType.Source, table)

        'fill the sql table schema to the dataset table schema
        sqlA.FillSchema(sqlDs, SchemaType.Source, table)

        'fill the datasets
        sqlA.Fill(sqlDs, table)
        dbfA.Fill(dbfDs)

        'for iterating through datatables
        Dim newRow As DataRow
        Dim oldRow As DataRow
        Dim colHeaders As DataColumnCollection = sqlDs.Tables(0).Columns

        'update the sqlDs to contain the data in the dbfDs dataset
        For Each rec As DataRow In dbfDs.Tables(0).Rows
            oldRow = sqlDs.Tables(0).Rows.Find(rec(pk))
            newRow = sqlDs.Tables(0).NewRow()
            If (oldRow Is Nothing) OrElse (Not BitConverter.ToString(oldRow("md5")) = BitConverter.ToString(getHashForRow(rec))) Then
                'delete the old row if exists
                If Not oldRow Is Nothing Then
                    oldRow.Delete()
                End If
                'now for each column name, copy it's data from the dbf rec to the newRow in the sql dataset
                For Each colHeader As DataColumn In colHeaders
                    'if it is the md5 column, then calculate the hash value as a 128-bit byte array (16 bytes)
                    newRow(colHeader.ColumnName) = If(colHeader.ColumnName = "md5", getHashForRow(rec), rec(colHeader.ColumnName))
                Next
                'add the new row
                sqlDs.Tables(0).Rows.Add(newRow)
            End If
        Next

        'name the ds table
        'sqlDs.Tables(0).TableName = table

        'create ds to db table mapping
        'sqlA.TableMappings.Add(table, table)

        'use dataset to update the table in the sql database
        Console.WriteLine("The number of rows updated: " & sqlA.Update(sqlDs, table))

        'close all connections
        dbfC.Close()
        sqlC.Close()

    End Sub

    Private Sub updateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updateButton.Click
        dbfToSQLTables()
    End Sub

    Private Sub viewChartButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewChartButton.Click

        Dim charttinfo As New CharttInfo
        ReDim charttinfo.colName(11)
        ReDim charttinfo.legend(11)
        ReDim charttinfo.rgb(11, 3)

        'create the chartview form
        Dim FundamentalCharts = New FundamentalCharts
        'populate charts with data from the dataset
        Dim selectedRows() As DataRow 'array of rows which will hold the row(s) selected
        'to store value of column
        Dim item As Object

        'get the dataset row with the given ticker
        selectedRows = dataSet.Tables(0).Select("ticker = '" & tickerComboBox.Text & "'")

        '   Start ChartForm ------------------------------------------------------------------------------------
        GoTo EndChartForm
        Dim chartForm As New ChartForm

        chartForm.QuarterlyChart.OpenData(COD.Values, 5, nYears)
        'set annual sales chart properties
        chartForm.QuarterlyChart.Series(0).Legend = "Sales"
        chartForm.QuarterlyChart.Series(1).Legend = "CGS"
        chartForm.QuarterlyChart.Series(2).Legend = "TotOpExp"
        chartForm.quarterlyChart.Series(3).Legend = "EBit"
        chartForm.quarterlyChart.Series(4).Legend = "NetInc"
        chartForm.QuarterlyChart.AxisY.LabelsFormat.Format = AxisFormat.Currency
        chartForm.QuarterlyChart.AxisX.TickMark = TickMark.Outside
        ' 'chartForm.QuarterlyChart.AxisX.LabelAngle = 45

        'set annualChart x-axis labels
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("perend_y" & i.ToString())
            If (Not item Is DBNull.Value AndAlso (Not i Mod 2 = 0)) Then
                chartForm.quarterlyChart.AxisX.Label(0 + (nYears - i)) = Date.Parse(item.ToString()).ToString("MM/yy")
            Else
                chartForm.QuarterlyChart.AxisX.Label(0 + (nYears - i)) = ""
            End If
        Next

        ' get sales
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("sales_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                chartForm.QuarterlyChart.Value(0, 0 + (nYears - i)) = CDbl(item)
                chartForm.QuarterlyChart.Series(0).LineWidth = 3
                chartForm.QuarterlyChart.Series(0).Color = Drawing.Color.FromArgb(50, 255, 0, 0)
                chartForm.QuarterlyChart.Series(0).LineWidth = 3
            Else
                chartForm.QuarterlyChart.Value(0, 0 + (nYears - i)) = Nothing
            End If
        Next

        'now get the annual cgs
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("cgs_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                chartForm.QuarterlyChart.Value(1, 0 + (nYears - i)) = CDbl(item)
                chartForm.QuarterlyChart.Series(1).Color = Drawing.Color.Yellow
                chartForm.QuarterlyChart.Series(1).LineWidth = 4
            Else
                chartForm.QuarterlyChart.Value(1, 0 + (nYears - i)) = Nothing
            End If
        Next

        'next the annual totextp
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("totexp_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                chartForm.QuarterlyChart.Value(2, 0 + (nYears - i)) = CDbl(item)
                chartForm.QuarterlyChart.Series(2).LineWidth = 5
            Else
                chartForm.QuarterlyChart.Value(2, 0 + (nYears - i)) = Nothing
            End If
        Next

        'next the Net Income
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("ebit_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                chartForm.QuarterlyChart.Value(3, 0 + (nYears - i)) = CDbl(item)
                chartForm.QuarterlyChart.Series(3).LineWidth = 6
            Else
                chartForm.QuarterlyChart.Value(3, 0 + (nYears - i)) = Nothing
            End If
        Next

        'next the Net Income
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("netinc_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                chartForm.QuarterlyChart.Value(4, 0 + (nYears - i)) = CDbl(item)
                chartForm.QuarterlyChart.Series(4).LineWidth = 6
            Else
                chartForm.QuarterlyChart.Value(4, 0 + (nYears - i)) = Nothing
            End If
        Next
        chartForm.quarterlyChart.CloseData(COD.Values)
EndChartForm:

        ' End ChartForm --------------------------------------------------------------------------------------------


        ' Start Annual ------------------------------------------------------------------------
        'Dim FundamentalCharts As New FundamentalCharts

        FundamentalCharts.Annual_PL.OpenData(COD.Values, 5, nYears)

        GoTo skipAnnual
        'set annual sales chart properties
        FundamentalCharts.Annual_PL.Series(0).Legend = "Sales"
        FundamentalCharts.Annual_PL.Series(1).Legend = "CGS"
        FundamentalCharts.Annual_PL.Series(2).Legend = "TotOpExp"
        FundamentalCharts.Annual_PL.Series(3).Legend = "EBit"
        FundamentalCharts.Annual_PL.Series(4).Legend = "NetInc"
        FundamentalCharts.Annual_PL.AxisY.LabelsFormat.Format = AxisFormat.Currency
        FundamentalCharts.Annual_PL.AxisX.TickMark = TickMark.Outside
        'FundamentalCharts.Annual_PL.AxisX.LabelAngle = 45
        FundamentalCharts.Annual_PL.MarkerShape = MarkerShape.None

        'set annualChart x-axis labels
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("perend_y" & i.ToString())
            If (Not item Is DBNull.Value AndAlso (Not i Mod 2 = 0)) Then
                FundamentalCharts.Annual_PL.AxisX.Label(0 + (nYears - i)) = Date.Parse(item.ToString()).ToString("MM/yy")
            Else
                FundamentalCharts.Annual_PL.AxisX.Label(0 + (nYears - i)) = ""
            End If
        Next

        ' get sales
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("sales_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Annual_PL.Value(0, 0 + (nYears - i)) = CDbl(item)
                FundamentalCharts.Annual_PL.Series(0).LineWidth = 3
                FundamentalCharts.Annual_PL.Series(0).Color = Drawing.Color.FromArgb(50, 255, 0, 0)
                FundamentalCharts.Annual_PL.Series(0).LineWidth = 3
            Else
                FundamentalCharts.Annual_PL.Value(0, 0 + (nYears - i)) = Nothing
            End If
        Next

        'now get the annual cgs
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("cgs_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Annual_PL.Value(1, 0 + (nYears - i)) = CDbl(item)
                FundamentalCharts.Annual_PL.Series(1).Color = Drawing.Color.Yellow
                FundamentalCharts.Annual_PL.Series(1).LineWidth = 4
            Else
                FundamentalCharts.Annual_PL.Value(1, 0 + (nYears - i)) = Nothing
            End If
        Next

        'next the annual totextp
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("totexp_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Annual_PL.Value(2, 0 + (nYears - i)) = CDbl(item)
                FundamentalCharts.Annual_PL.Series(2).LineWidth = 5
            Else
                FundamentalCharts.Annual_PL.Value(2, 0 + (nYears - i)) = Nothing
            End If
        Next

        'next the Net Income
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("ebit_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Annual_PL.Value(3, 0 + (nYears - i)) = CDbl(item)
                FundamentalCharts.Annual_PL.Series(3).LineWidth = 6
            Else
                FundamentalCharts.Annual_PL.Value(3, 0 + (nYears - i)) = Nothing
            End If
        Next

        'next the Net Income
        For i As Integer = nYears To 1 Step -1
            item = selectedRows(0).Item("netinc_y" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Annual_PL.Value(4, 0 + (nYears - i)) = CDbl(item)
                FundamentalCharts.Annual_PL.Series(4).LineWidth = 6
            Else
                FundamentalCharts.Annual_PL.Value(4, 0 + (nYears - i)) = Nothing
            End If
        Next
        FundamentalCharts.Annual_PL.CloseData(COD.Values)

skipAnnual:

        'End Annual ------------------------------------------------------------------------------------------------



        'Now start Quarterly Charts --------------------------------------------------------------------------------
        FundamentalCharts.Q_PL.OpenData(COD.Values, 5, nQuarters)

        GoTo skipp

        'quarterly chart properties
        FundamentalCharts.Q_PL.Series(0).Legend = "Sales"
        FundamentalCharts.Q_PL.Series(1).Legend = "CGS"
        FundamentalCharts.Q_PL.Series(2).Legend = "Totexp"
        FundamentalCharts.Q_PL.Series(3).Legend = "ebit"
        FundamentalCharts.Q_PL.Series(4).Legend = "netinc"

        FundamentalCharts.Q_PL.AxisY.LabelsFormat.Format = AxisFormat.Currency
        FundamentalCharts.Q_PL.AxisX.TickMark = TickMark.Outside
        FundamentalCharts.Q_PL.AxisX.LabelAngle = 45

        'set quarterlyChart x-axis labels

        For i As Integer = nQuarters To 1 Step -1
            item = selectedRows(0).Item("perend_q" & i.ToString())
            If (Not item Is DBNull.Value AndAlso (i Mod 2 = 0)) Then
                FundamentalCharts.Q_PL.AxisX.Label(0 + (nQuarters - i)) = Date.Parse(item.ToString()).ToString("MM/yyyy")
            Else
                FundamentalCharts.Q_PL.AxisX.Label(0 + (nQuarters - i)) = ""
            End If
        Next

        'quarterly sales
        For i As Integer = nQuarters To 1 Step -1
            item = selectedRows(0).Item("sales_q" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Q_PL.Value(0, 0 + (nQuarters - i)) = CDbl(item)
            Else
                FundamentalCharts.Q_PL.Value(0, 0 + (nQuarters - i)) = Nothing
            End If
        Next

        'quarterly cgs
        For i As Integer = nQuarters To 1 Step -1
            item = selectedRows(0).Item("cgs_q" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Q_PL.Value(1, 0 + (nQuarters - i)) = CDbl(item)
            Else
                FundamentalCharts.Q_PL.Value(1, 0 + (nQuarters - i)) = Nothing
            End If
        Next

        '  quarterly totextp
        For i As Integer = nQuarters To 1 Step -1
            item = selectedRows(0).Item("totexp_q" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Q_PL.Value(2, 0 + (nQuarters - i)) = CDbl(item)
            Else
                FundamentalCharts.Q_PL.Value(2, 0 + (nQuarters - i)) = Nothing
            End If
        Next

        '  quarterly ebit
        For i As Integer = nQuarters To 1 Step -1
            item = selectedRows(0).Item("ebit_q" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Q_PL.Value(3, 0 + (nQuarters - i)) = CDbl(item)
            Else
                FundamentalCharts.Q_PL.Value(3, 0 + (nQuarters - i)) = Nothing
            End If
        Next

        '  quarterly netinc
        For i As Integer = nQuarters To 1 Step -1
            item = selectedRows(0).Item("netinc_q" & i.ToString())
            If (Not item Is DBNull.Value) Then
                FundamentalCharts.Q_PL.Value(4, 0 + (nQuarters - i)) = CDbl(item)
            Else
                FundamentalCharts.Q_PL.Value(4, 0 + (nQuarters - i)) = Nothing
            End If
        Next

        ' FundamentalCharts.Q_PL.CloseData(COD.Values)

skipp:
        'set form title and label
        FundamentalCharts.Text = tickerComboBox.Text
        ' FundamentalCharts.tickerLabel.Text = Trim(selectedRows(0).Item("company").ToString()) & " - " & tickerComboBox.Text

        '
        'goTo temp
        'Plot Quarterly
        charttinfo.nSeries = 5 : charttinfo.nvalues = 8
        charttinfo.perend = "perend_q"
        charttinfo.colName(0) = "sales_q" : charttinfo.colName(1) = "cgs_q" : charttinfo.colName(2) = "totexp_q" : charttinfo.colName(3) = "ebit_q" : charttinfo.colName(4) = "netinc_q"
        charttinfo.rgb(0, 0) = 255 : charttinfo.rgb(0, 1) = 0 : charttinfo.rgb(0, 2) = 255 : charttinfo.rgb(0, 3) = 0
        charttinfo.rgb(1, 0) = 50 : charttinfo.rgb(1, 1) = 255 : charttinfo.rgb(1, 2) = 0 : charttinfo.rgb(1, 3) = 0
        charttinfo.rgb(2, 0) = 255 : charttinfo.rgb(2, 1) = 255 : charttinfo.rgb(2, 2) = 0 : charttinfo.rgb(2, 3) = 0
        charttinfo.rgb(3, 0) = 50 : charttinfo.rgb(3, 1) = 0 : charttinfo.rgb(3, 2) = 0 : charttinfo.rgb(3, 3) = 255
        charttinfo.rgb(4, 0) = 255 : charttinfo.rgb(4, 1) = 0 : charttinfo.rgb(4, 2) = 0 : charttinfo.rgb(4, 3) = 255
        charttinfo.legend(0) = "Sales"
        charttinfo.legend(1) = "CGS"
        charttinfo.legend(2) = "OpExp"
        charttinfo.legend(3) = "EBIT"
        charttinfo.legend(4) = "NetInc"
        PlotChart(selectedRows, FundamentalCharts.Q_PL, charttinfo)

        'Plot Annual
        charttinfo.nSeries = 5 : charttinfo.nvalues = 7
        charttinfo.perend = "perend_y"
        charttinfo.colName(0) = "sales_y" : charttinfo.colName(1) = "cgs_y" : charttinfo.colName(2) = "totexp_y" : charttinfo.colName(3) = "ebit_y" : charttinfo.colName(4) = "netinc_y"
        charttinfo.rgb(0, 0) = 255 : charttinfo.rgb(0, 1) = 0 : charttinfo.rgb(0, 2) = 255 : charttinfo.rgb(0, 3) = 0
        charttinfo.rgb(1, 0) = 50 : charttinfo.rgb(1, 1) = 255 : charttinfo.rgb(1, 2) = 0 : charttinfo.rgb(1, 3) = 0
        charttinfo.rgb(2, 0) = 255 : charttinfo.rgb(2, 1) = 255 : charttinfo.rgb(2, 2) = 0 : charttinfo.rgb(2, 3) = 0
        charttinfo.rgb(3, 0) = 50 : charttinfo.rgb(3, 1) = 0 : charttinfo.rgb(3, 2) = 0 : charttinfo.rgb(3, 3) = 255
        charttinfo.rgb(4, 0) = 255 : charttinfo.rgb(4, 1) = 0 : charttinfo.rgb(4, 2) = 0 : charttinfo.rgb(4, 3) = 255
        charttinfo.legend(0) = "Sales"
        charttinfo.legend(1) = "CGS"
        charttinfo.legend(2) = "OpExp"
        charttinfo.legend(3) = "EBIT"
        charttinfo.legend(4) = "NetInc"
        PlotChart(selectedRows, FundamentalCharts.Annual_PL, charttinfo)
temp:
        'Plot Annual Expenses
        FundamentalCharts.A_Exp.OpenData(COD.Values, 10, 7)
        charttinfo.nSeries = 7 : charttinfo.nvalues = 7
        charttinfo.perend = "perend_y"
        charttinfo.colName(0) = "eps_q" : charttinfo.colName(1) = "epscon_q" : charttinfo.colName(2) = "epsd_q" : charttinfo.colName(3) = "epsdc_q" : charttinfo.colName(4) = "epsnd_q" : charttinfo.colName(5) = "dps_q" : charttinfo.colName(6) = "dpst_q"
        charttinfo.rgb(0, 0) = 255 : charttinfo.rgb(0, 1) = 4 : charttinfo.rgb(0, 2) = 114 : charttinfo.rgb(0, 3) = 30
        charttinfo.rgb(1, 0) = 50 : charttinfo.rgb(1, 1) = 7 : charttinfo.rgb(1, 2) = 177 : charttinfo.rgb(1, 3) = 47
        charttinfo.rgb(2, 0) = 255 : charttinfo.rgb(2, 1) = 10 : charttinfo.rgb(2, 2) = 246 : charttinfo.rgb(2, 3) = 66
        charttinfo.rgb(3, 0) = 50 : charttinfo.rgb(3, 1) = 59 : charttinfo.rgb(3, 2) = 247 : charttinfo.rgb(3, 3) = 104
        charttinfo.rgb(4, 0) = 255 : charttinfo.rgb(4, 1) = 130 : charttinfo.rgb(4, 2) = 250 : charttinfo.rgb(4, 3) = 159
        charttinfo.rgb(5, 0) = 50 : charttinfo.rgb(5, 1) = 0 : charttinfo.rgb(5, 2) = 0 : charttinfo.rgb(5, 3) = 255
        charttinfo.rgb(6, 0) = 255 : charttinfo.rgb(6, 1) = 48 : charttinfo.rgb(6, 2) = 142 : charttinfo.rgb(6, 3) = 206
        charttinfo.legend(0) = "eps"
        charttinfo.legend(1) = "epsC"
        charttinfo.legend(2) = "epsD"
        charttinfo.legend(3) = "espDC"
        charttinfo.legend(4) = "espDN"
        charttinfo.legend(5) = "divT"
        charttinfo.legend(6) = "divNS"
        PlotChart(selectedRows, FundamentalCharts.A_Exp, charttinfo)
        FundamentalCharts.A_Exp.CloseData(COD.Values)

        'Plot Annual EPS
        FundamentalCharts.A_EPS.OpenData(COD.Values, 7, 7)
        charttinfo.nSeries = 7 : charttinfo.nvalues = 7
        charttinfo.perend = "perend_y"
        charttinfo.colName(0) = "eps_y" : charttinfo.colName(1) = "epscon_y" : charttinfo.colName(2) = "epsd_y" : charttinfo.colName(3) = "epsdc_y" : charttinfo.colName(4) = "epsnd_y" : charttinfo.colName(5) = "dps_y" : charttinfo.colName(6) = "dpst_y"
        charttinfo.rgb(0, 0) = 255 : charttinfo.rgb(0, 1) = 4 : charttinfo.rgb(0, 2) = 114 : charttinfo.rgb(0, 3) = 30
        charttinfo.rgb(1, 0) = 50 : charttinfo.rgb(1, 1) = 7 : charttinfo.rgb(1, 2) = 177 : charttinfo.rgb(1, 3) = 47
        charttinfo.rgb(2, 0) = 255 : charttinfo.rgb(2, 1) = 10 : charttinfo.rgb(2, 2) = 246 : charttinfo.rgb(2, 3) = 66
        charttinfo.rgb(3, 0) = 50 : charttinfo.rgb(3, 1) = 59 : charttinfo.rgb(3, 2) = 247 : charttinfo.rgb(3, 3) = 104
        charttinfo.rgb(4, 0) = 255 : charttinfo.rgb(4, 1) = 130 : charttinfo.rgb(4, 2) = 250 : charttinfo.rgb(4, 3) = 159
        charttinfo.rgb(5, 0) = 50 : charttinfo.rgb(5, 1) = 0 : charttinfo.rgb(5, 2) = 0 : charttinfo.rgb(5, 3) = 255
        charttinfo.rgb(6, 0) = 255 : charttinfo.rgb(6, 1) = 48 : charttinfo.rgb(6, 2) = 142 : charttinfo.rgb(6, 3) = 206
        charttinfo.legend(0) = "eps"
        charttinfo.legend(1) = "epsC"
        charttinfo.legend(2) = "epsD"
        charttinfo.legend(3) = "espDC"
        charttinfo.legend(4) = "espDN"
        charttinfo.legend(5) = "divT"
        charttinfo.legend(6) = "divNS"
        PlotChart(selectedRows, FundamentalCharts.A_EPS, charttinfo)
        FundamentalCharts.A_EPS.CloseData(COD.Values)

        'Plot Quarterly EPS
        FundamentalCharts.Q_EPS.OpenData(COD.Values, 7, 7)
        charttinfo.nSeries = 7 : charttinfo.nvalues = 7
        charttinfo.perend = "perend_Q"
        charttinfo.colName(0) = "eps_q" : charttinfo.colName(1) = "epscon_q" : charttinfo.colName(2) = "epsd_q" : charttinfo.colName(3) = "epsdc_q" : charttinfo.colName(4) = "epsnd_q" : charttinfo.colName(5) = "dps_q" : charttinfo.colName(6) = "dpst_q"
        charttinfo.rgb(0, 0) = 255 : charttinfo.rgb(0, 1) = 4 : charttinfo.rgb(0, 2) = 114 : charttinfo.rgb(0, 3) = 30
        charttinfo.rgb(1, 0) = 50 : charttinfo.rgb(1, 1) = 7 : charttinfo.rgb(1, 2) = 177 : charttinfo.rgb(1, 3) = 47
        charttinfo.rgb(2, 0) = 255 : charttinfo.rgb(2, 1) = 10 : charttinfo.rgb(2, 2) = 246 : charttinfo.rgb(2, 3) = 66
        charttinfo.rgb(3, 0) = 50 : charttinfo.rgb(3, 1) = 59 : charttinfo.rgb(3, 2) = 247 : charttinfo.rgb(3, 3) = 104
        charttinfo.rgb(4, 0) = 255 : charttinfo.rgb(4, 1) = 130 : charttinfo.rgb(4, 2) = 250 : charttinfo.rgb(4, 3) = 159
        charttinfo.rgb(5, 0) = 50 : charttinfo.rgb(5, 1) = 0 : charttinfo.rgb(5, 2) = 0 : charttinfo.rgb(5, 3) = 255
        charttinfo.rgb(6, 0) = 255 : charttinfo.rgb(6, 1) = 48 : charttinfo.rgb(6, 2) = 142 : charttinfo.rgb(6, 3) = 206
        charttinfo.legend(0) = "eps"
        charttinfo.legend(1) = "epsC"
        charttinfo.legend(2) = "epsD"
        charttinfo.legend(3) = "espDC"
        charttinfo.legend(4) = "espDN"
        charttinfo.legend(5) = "divT"
        charttinfo.legend(6) = "divNS"
        PlotChart(selectedRows, FundamentalCharts.Q_EPS, charttinfo)
        FundamentalCharts.Q_EPS.CloseData(COD.Values)



        FundamentalCharts.Show()
        FundamentalCharts.Q_PL.CloseData(COD.Values)

    End Sub
    Private Sub PlotChart(selectedRows() As DataRow, chart As SoftwareFX.ChartFX.Chart, charttinfo As CharttInfo)
        ' Dim selectedrows As DataRow
        Dim item As Object
        Dim ii, iii, j As Integer

        Dim file_name As String = "C:\Naresh\Projects\investor-2015\test.txt"
        Dim objwriter As New System.IO.StreamWriter(file_name)



        ii = charttinfo.nvalues
        iii = charttinfo.nSeries
        j = 1

        'set x-axis labels
        For i As Integer = ii To 1 Step -1
            item = selectedRows(0).Item(charttinfo.perend & i.ToString())
            If (Not item Is DBNull.Value AndAlso (Not i Mod 2 = 0)) Then
                chart.AxisX.Label(0 + (ii - i)) = Date.Parse(item.ToString()).ToString("MM/yy")
            Else
                chart.AxisX.Label(0 + (ii - i)) = ""
            End If
        Next
        chart.AxisY.LabelsFormat.Format = AxisFormat.Currency
        chart.AxisX.TickMark = TickMark.Outside
        chart.AxisX.LabelAngle = 0



        For j = 0 To (iii - 1)      'charttinfo.nSeries Step -1 'charttinfo.nSeries - 1  ' 2 To 2  '1 To charttinfo.nSeries
            'quarterly totextp
            For i As Integer = ii To 1 Step -1
                'stringg = charttinfo.colName(j)
                item = selectedRows(0).Item(charttinfo.colName(j) & i.ToString())
                If (Not item Is DBNull.Value) Then
                    chart.Value(j, 0 + (ii - i)) = CDbl(item)
                    objwriter.Write(item)
                Else
                    chart.Value(j, 0 + (ii - i)) = Nothing
                End If
            Next
            objwriter.Write(Environment.NewLine)
            chart.Series(j).LineWidth = 3
            chart.Series(j).Color = Drawing.Color.FromArgb(charttinfo.rgb(j, 0), charttinfo.rgb(j, 1), charttinfo.rgb(j, 2), charttinfo.rgb(j, 3))
            chart.Series(j).Legend = charttinfo.legend(j)
        Next


        ' chart.Series(0).Legend = "Sales"
        '   chart.Series(1).Legend = "CGS"
        '  chart.Series(2).Legend = "TotOpExp"
        ' chart.Series(3).Legend = "EBit"
        ' chart.Series(4).Legend = "NetInc"

        chart.MarkerShape = MarkerShape.None

        objwriter.Close()

    End Sub

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'make sure the sql connection is closed on exit
        sqlConn.Close()
    End Sub

    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles searchButton.Click

        'start creating the query and dataset
        Dim queryString As String
        queryString = "Select ticker, company, business from si_ci where business Like "
        Dim queryDS As DataSet
        queryDS = New DataSet()

        'check that there is at least some text entered in the first query box
        If (queryText1.Text = "") Then
            MsgBox("There must be text entered To search")
            Return
        End If

        'create query string
        queryString += "'%" & queryText1.Text & "%' "
        If (andOption1.Checked Or orOption1.Checked) And (Not queryText2.Text = "") Then
            queryString += If(andOption1.Checked, "and ", "or ") & "business like '%" & queryText2.Text & "%' "
        End If
        If (andOption2.Checked Or orOption2.Checked) And (Not queryText3.Text = "") Then
            queryString += If(andOption1.Checked, "and ", "or ") & "business like '%" & queryText2.Text & "%' "
        End If

        'run the query
        sqlAdapter.SelectCommand.CommandText = queryString
        sqlAdapter.Fill(queryDS)

        'now create the new query window with the gridview having the query result as the data source
        Dim queryWindow As QueryForm
        queryWindow = New QueryForm
        queryWindow.gridView.DataSource = queryDS.Tables(0)

        'update the count
        queryWindow.countLabel.Text = queryDS.Tables(0).Rows.Count

        'finally show the queryWindows
        queryWindow.Show()

        'resize columns to max width
        queryWindow.gridView.AutoResizeColumns()
    End Sub

End Class