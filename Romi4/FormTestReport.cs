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
        DataTable dtBigPlan = new DataTable();
        DataTable dtSmallPlan = new DataTable();
        List<string> listDescribe = new List<string>();
        
        public FormTestReport(DataTable dtVarBigPlan, DataTable dtVarSmallPlan, List<string> listVarDescribe)
        {
            InitializeComponent();

            dtBigPlan = dtVarBigPlan;
            dtSmallPlan = dtVarSmallPlan;
            listDescribe = listVarDescribe;
        }

        private void FormTestReport_Load(object sender, EventArgs e)
        {
            //Заполнение таблицы большого плана в БД
            foreach (DataRow dr in dtBigPlan.Rows)
            {
                table1TableAdapter.Insert(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                    dr[10].ToString());
            }

            //Заполнение таблицы малого плана в БД
            foreach (DataRow dr in dtSmallPlan.Rows)
            {
                tableSmallPlanTableAdapter.Insert(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), 
                    dr[3].ToString(), dr[4].ToString());
            }

            //Заполнение таблицы шапки в БД
            tableDescribeTableAdapter.Insert(listDescribe[0], listDescribe[1], listDescribe[2], listDescribe[3],
                 listDescribe[4], listDescribe[5], listDescribe[6], listDescribe[7], listDescribe[8], 
                 listDescribe[9], listDescribe[10], listDescribe[11], listDescribe[12], listDescribe[13], 
                 listDescribe[14]);

            table1TableAdapter.Fill(ReportBigPlanDataSet.table1);
            tableDescribeTableAdapter.Fill(ReportBigPlanDataSet.tableDescribe);
            tableSmallPlanTableAdapter.Fill(ReportBigPlanDataSet.tableSmallPlan);

            reportViewer1.RefreshReport();
        }

        private void FormTestReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            //Очистка таблиц базы данных
            foreach (DataRow dr in ReportBigPlanDataSet.table1.Rows)
            {
                table1TableAdapter.Delete(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                    dr[10].ToString());
            }
            foreach (DataRow dr in ReportBigPlanDataSet.tableSmallPlan.Rows)
            {
                tableSmallPlanTableAdapter.Delete(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString());
            }
            foreach (DataRow dr in ReportBigPlanDataSet.tableDescribe.Rows)
            {
                tableDescribeTableAdapter.Delete(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(),
                    dr[10].ToString(), dr[11].ToString(), dr[12].ToString(), dr[13].ToString(), dr[14].ToString());
            }

            Cursor.Current = Cursors.Arrow;
        }
    }
}
