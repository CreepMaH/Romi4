using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Romi4
{
    public partial class FormTestReport : Form
    {
        DataTable dt1 = new DataTable();
        public FormTestReport(DataTable dt)
        {
            InitializeComponent();
            dt1 = dt;
        }

        private void FormTestReport_Load(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                this.table1TableAdapter.Insert(dr[0].ToString(), dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),
                    dr[4].ToString(),dr[5].ToString(),dr[6].ToString(),dr[7].ToString(),dr[8].ToString(),dr[9].ToString(),
                    dr[10].ToString());
            }
            this.table1TableAdapter.Fill(this.ReportBigPlanDataSet.table1);
            this.reportViewer1.RefreshReport();
        }

        private void FormTestReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            foreach (DataRow dr in this.ReportBigPlanDataSet.table1.Rows)
            {
                this.table1TableAdapter.Delete(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                    dr[10].ToString());
            }

            Cursor.Current = Cursors.Arrow;
        }
    }
}
