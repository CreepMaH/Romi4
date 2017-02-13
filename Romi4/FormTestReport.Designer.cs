namespace Romi4
{
    partial class FormTestReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestReport));
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportBigPlanDataSet = new Romi4.ReportBigPlanDataSet();
            this.tableDescribeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableSmallPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.table1TableAdapter = new Romi4.ReportBigPlanDataSetTableAdapters.table1TableAdapter();
            this.tableDescribeTableAdapter = new Romi4.ReportBigPlanDataSetTableAdapters.tableDescribeTableAdapter();
            this.tableSmallPlanTableAdapter = new Romi4.ReportBigPlanDataSetTableAdapters.tableSmallPlanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBigPlanDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDescribeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableSmallPlanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "table1";
            this.table1BindingSource.DataSource = this.ReportBigPlanDataSet;
            // 
            // ReportBigPlanDataSet
            // 
            this.ReportBigPlanDataSet.DataSetName = "ReportBigPlanDataSet";
            this.ReportBigPlanDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableDescribeBindingSource
            // 
            this.tableDescribeBindingSource.DataMember = "tableDescribe";
            this.tableDescribeBindingSource.DataSource = this.ReportBigPlanDataSet;
            // 
            // tableSmallPlanBindingSource
            // 
            this.tableSmallPlanBindingSource.DataMember = "tableSmallPlan";
            this.tableSmallPlanBindingSource.DataSource = this.ReportBigPlanDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetTable1";
            reportDataSource1.Value = this.table1BindingSource;
            reportDataSource2.Name = "DataSetTableDescribe";
            reportDataSource2.Value = this.tableDescribeBindingSource;
            reportDataSource3.Name = "DataSetTableSmallPlan";
            reportDataSource3.Value = this.tableSmallPlanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Romi4.ReportFinal.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(833, 339);
            this.reportViewer1.TabIndex = 0;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // tableDescribeTableAdapter
            // 
            this.tableDescribeTableAdapter.ClearBeforeFill = true;
            // 
            // tableSmallPlanTableAdapter
            // 
            this.tableSmallPlanTableAdapter.ClearBeforeFill = true;
            // 
            // FormTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 339);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTestReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт на печать";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTestReport_FormClosed);
            this.Load += new System.EventHandler(this.FormTestReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBigPlanDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableDescribeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableSmallPlanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private ReportBigPlanDataSet ReportBigPlanDataSet;
        private System.Windows.Forms.BindingSource tableDescribeBindingSource;
        private System.Windows.Forms.BindingSource tableSmallPlanBindingSource;
        private ReportBigPlanDataSetTableAdapters.table1TableAdapter table1TableAdapter;
        private ReportBigPlanDataSetTableAdapters.tableDescribeTableAdapter tableDescribeTableAdapter;
        private ReportBigPlanDataSetTableAdapters.tableSmallPlanTableAdapter tableSmallPlanTableAdapter;
    }
}