using Portfolio.Database.Portfolio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio.Portfolio
{
    public partial class AddPortfolio : Form
    {
        public DataTable PortfolioDT { get; set; }
        public AddPortfolio()
        {
            InitializeComponent();

            PortfolioDT = new DataTable();

            //PortfolioDT.Columns.Add(new DataColumn("Tickersv"));

            //PortfolioGV.DataSource = PortfolioDT;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(prtfTextBox.Text))
            {
                MessageBox.Show("Enter Portfolio Name");
                return;
            }
            var portDT = GVToDataTable();
            portDT.Columns.Add("TickerId").SetOrdinal(0);
            portDT.Columns.Add("PortfolioID",typeof(int));

            PortfolioAccess.CreatePortfolio(prtfTextBox.Text, portDT);
            this.Close();
        }

        public DataTable GVToDataTable()
        {
            DataTable dataTable = new DataTable();

            foreach (DataGridViewColumn column in PortfolioGV.Columns)
            {
                dataTable.Columns.Add(column.Name);
            }


            foreach (DataGridViewRow row in PortfolioGV.Rows)
            {
                List<string> cellValues = new List<string>();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues.Add((string)row.Cells[i].Value);
                }
                if(cellValues.Count(t=> string.IsNullOrWhiteSpace(t)) != cellValues.Count)
                    dataTable.Rows.Add(cellValues.ToArray());
            }

            return dataTable;
        }

        //public DataTable GVToDataTable()
        //{
        //    DataTable dataTable = new DataTable();

        //    foreach (DataGridViewColumn column in PortfolioGV.Columns)
        //    {
        //        dataTable.Columns.Add(column.Name);
        //    }


        //    foreach (DataGridViewRow row in PortfolioGV.Rows)
        //    {
        //        List<string> cellValues = new List<string>();
        //        for (int i = 0; i < row.Cells.Count; i++)
        //        {
        //            cellValues.Add((string)row.Cells[i].Value);
        //        }
        //        if (cellValues.Count(t => string.IsNullOrWhiteSpace(t)) != cellValues.Count)
        //            dataTable.Rows.Add(cellValues.ToArray());
        //    }

        //    return dataTable;
        //}
    }
}
