namespace ReportGenerator
{
    partial class MainView
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
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelReport = new System.Windows.Forms.Label();
            this.labelLogs = new System.Windows.Forms.Label();
            this.labelLoadFile = new System.Windows.Forms.Label();
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.openFileDialogLoadOrders = new System.Windows.Forms.OpenFileDialog();
            this.labelGenerateReports = new System.Windows.Forms.Label();
            this.comboBoxReportType = new System.Windows.Forms.ComboBox();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonSaveReportToFile = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.CausesValidation = false;
            this.textBoxLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxLogs.Location = new System.Drawing.Point(0, 507);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(1014, 138);
            this.textBoxLogs.TabIndex = 0;
            this.textBoxLogs.TabStop = false;
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.AllowUserToAddRows = false;
            this.dataGridViewReports.AllowUserToDeleteRows = false;
            this.dataGridViewReports.AllowUserToOrderColumns = true;
            this.dataGridViewReports.AllowUserToResizeColumns = false;
            this.dataGridViewReports.AllowUserToResizeRows = false;
            this.dataGridViewReports.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dataGridViewReports.AutoGenerateColumns = false;
            this.dataGridViewReports.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.clientIdDataGridViewTextBoxColumn,
            this.requestIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridViewReports.DataSource = this.orderBindingSource;
            this.dataGridViewReports.Location = new System.Drawing.Point(381, 76);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.RowHeadersVisible = false;
            this.dataGridViewReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewReports.Size = new System.Drawing.Size(621, 259);
            this.dataGridViewReports.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientIdDataGridViewTextBoxColumn
            // 
            this.clientIdDataGridViewTextBoxColumn.DataPropertyName = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.HeaderText = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.Name = "clientIdDataGridViewTextBoxColumn";
            this.clientIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestIdDataGridViewTextBoxColumn
            // 
            this.requestIdDataGridViewTextBoxColumn.DataPropertyName = "RequestId";
            this.requestIdDataGridViewTextBoxColumn.HeaderText = "RequestId";
            this.requestIdDataGridViewTextBoxColumn.Name = "requestIdDataGridViewTextBoxColumn";
            this.requestIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(ReportGenerator.Utilities.Order);
            this.orderBindingSource.Sort = "";
            // 
            // labelReport
            // 
            this.labelReport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelReport.AutoSize = true;
            this.labelReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReport.Location = new System.Drawing.Point(644, 48);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(99, 25);
            this.labelReport.TabIndex = 2;
            this.labelReport.Text = "Order list";
            // 
            // labelLogs
            // 
            this.labelLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelLogs.AutoSize = true;
            this.labelLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogs.Location = new System.Drawing.Point(466, 473);
            this.labelLogs.Name = "labelLogs";
            this.labelLogs.Size = new System.Drawing.Size(73, 31);
            this.labelLogs.TabIndex = 3;
            this.labelLogs.Text = "Logs";
            // 
            // labelLoadFile
            // 
            this.labelLoadFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLoadFile.AutoSize = true;
            this.labelLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoadFile.Location = new System.Drawing.Point(21, 76);
            this.labelLoadFile.Name = "labelLoadFile";
            this.labelLoadFile.Size = new System.Drawing.Size(215, 20);
            this.labelLoadFile.TabIndex = 4;
            this.labelLoadFile.Text = "Choose file to load orders";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonLoadFile.Location = new System.Drawing.Point(25, 108);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(237, 23);
            this.buttonLoadFile.TabIndex = 5;
            this.buttonLoadFile.Text = "Choose file";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            // 
            // openFileDialogLoadOrders
            // 
            this.openFileDialogLoadOrders.Filter = "\"Json files (*.json)|*.json|Xml files (*.xml)|*.xml|Csv files (*.csv)|*.csv\"";
            // 
            // labelGenerateReports
            // 
            this.labelGenerateReports.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelGenerateReports.AutoSize = true;
            this.labelGenerateReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenerateReports.Location = new System.Drawing.Point(21, 154);
            this.labelGenerateReports.Name = "labelGenerateReports";
            this.labelGenerateReports.Size = new System.Drawing.Size(241, 20);
            this.labelGenerateReports.TabIndex = 6;
            this.labelGenerateReports.Text = "Available reports to generate";
            // 
            // comboBoxReportType
            // 
            this.comboBoxReportType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReportType.Location = new System.Drawing.Point(25, 186);
            this.comboBoxReportType.Name = "comboBoxReportType";
            this.comboBoxReportType.Size = new System.Drawing.Size(237, 21);
            this.comboBoxReportType.TabIndex = 7;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonGenerateReport.Location = new System.Drawing.Point(25, 231);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(237, 23);
            this.buttonGenerateReport.TabIndex = 8;
            this.buttonGenerateReport.Text = "Generate report";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
          
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxFileName.Location = new System.Drawing.Point(162, 280);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFileName.TabIndex = 9;
            this.textBoxFileName.Text = "Filename.txt";
            // 
            // buttonSaveReportToFile
            // 
            this.buttonSaveReportToFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSaveReportToFile.Location = new System.Drawing.Point(25, 278);
            this.buttonSaveReportToFile.Name = "buttonSaveReportToFile";
            this.buttonSaveReportToFile.Size = new System.Drawing.Size(131, 23);
            this.buttonSaveReportToFile.TabIndex = 10;
            this.buttonSaveReportToFile.Text = "Save report to file";
            this.buttonSaveReportToFile.UseVisualStyleBackColor = true;
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(159, 264);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(93, 13);
            this.labelFileName.TabIndex = 11;
            this.labelFileName.Text = "File name to save:";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 645);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonSaveReportToFile);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.comboBoxReportType);
            this.Controls.Add(this.labelGenerateReports);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.labelLoadFile);
            this.Controls.Add(this.labelLogs);
            this.Controls.Add(this.labelReport);
            this.Controls.Add(this.dataGridViewReports);
            this.Controls.Add(this.textBoxLogs);
            this.Name = "MainView";
            this.Text = "Report generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Label labelReport;
        private System.Windows.Forms.Label labelLogs;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.Label labelLoadFile;
        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.Label labelGenerateReports;
        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadOrders;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonSaveReportToFile;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}

