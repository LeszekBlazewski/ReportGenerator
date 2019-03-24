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
            this.textBoxErrorLogs = new System.Windows.Forms.TextBox();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
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
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.labelClientId = new System.Windows.Forms.Label();
            this.labelLowerBound = new System.Windows.Forms.Label();
            this.labelUpperPriceInRange = new System.Windows.Forms.Label();
            this.textBoxUpperPriceInRange = new System.Windows.Forms.TextBox();
            this.textBoxLowerPriceInRange = new System.Windows.Forms.TextBox();
            this.buttonClearOrders = new System.Windows.Forms.Button();
            this.textBoxReportsResult = new System.Windows.Forms.TextBox();
            this.labelReports = new System.Windows.Forms.Label();
            this.buttonClearErrorLogs = new System.Windows.Forms.Button();
            this.buttonClearReportsLog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxErrorLogs
            // 
            this.textBoxErrorLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxErrorLogs.CausesValidation = false;
            this.textBoxErrorLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxErrorLogs.Location = new System.Drawing.Point(0, 511);
            this.textBoxErrorLogs.Multiline = true;
            this.textBoxErrorLogs.Name = "textBoxErrorLogs";
            this.textBoxErrorLogs.ReadOnly = true;
            this.textBoxErrorLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxErrorLogs.Size = new System.Drawing.Size(486, 234);
            this.textBoxErrorLogs.TabIndex = 0;
            this.textBoxErrorLogs.TabStop = false;
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
            this.clientIdDataGridViewTextBoxColumn,
            this.requestIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridViewReports.DataSource = this.orderBindingSource;
            this.dataGridViewReports.Location = new System.Drawing.Point(508, 98);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.ReadOnly = true;
            this.dataGridViewReports.RowHeadersVisible = false;
            this.dataGridViewReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewReports.Size = new System.Drawing.Size(503, 335);
            this.dataGridViewReports.TabIndex = 1;
            // 
            // clientIdDataGridViewTextBoxColumn
            // 
            this.clientIdDataGridViewTextBoxColumn.DataPropertyName = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.HeaderText = "Client ID";
            this.clientIdDataGridViewTextBoxColumn.Name = "clientIdDataGridViewTextBoxColumn";
            this.clientIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestIdDataGridViewTextBoxColumn
            // 
            this.requestIdDataGridViewTextBoxColumn.DataPropertyName = "RequestId";
            this.requestIdDataGridViewTextBoxColumn.HeaderText = "Request ID";
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
            this.labelReport.Location = new System.Drawing.Point(682, 70);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(125, 25);
            this.labelReport.TabIndex = 2;
            this.labelReport.Text = "Request list";
            // 
            // labelLogs
            // 
            this.labelLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLogs.AutoSize = true;
            this.labelLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogs.Location = new System.Drawing.Point(192, 477);
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
            this.labelLoadFile.Location = new System.Drawing.Point(9, 74);
            this.labelLoadFile.Name = "labelLoadFile";
            this.labelLoadFile.Size = new System.Drawing.Size(215, 20);
            this.labelLoadFile.TabIndex = 4;
            this.labelLoadFile.Text = "Choose file to load orders";
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonLoadFile.Location = new System.Drawing.Point(11, 107);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(256, 23);
            this.buttonLoadFile.TabIndex = 5;
            this.buttonLoadFile.Text = "Load orders";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            // 
            // openFileDialogLoadOrders
            // 
            this.openFileDialogLoadOrders.Filter = "All Files| *.json;*.JSON;*xml;*.XML*csv;*.CSV|Json files (*.json)|*.json;*.JSON|X" +
    "ml files (*.xml)|*.xml;*.XML|Csv files (*.csv)|*.csv;*.CSV";
            this.openFileDialogLoadOrders.Multiselect = true;
            this.openFileDialogLoadOrders.RestoreDirectory = true;
            this.openFileDialogLoadOrders.Title = "Select order files to load";
            // 
            // labelGenerateReports
            // 
            this.labelGenerateReports.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelGenerateReports.AutoSize = true;
            this.labelGenerateReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenerateReports.Location = new System.Drawing.Point(7, 144);
            this.labelGenerateReports.Name = "labelGenerateReports";
            this.labelGenerateReports.Size = new System.Drawing.Size(241, 20);
            this.labelGenerateReports.TabIndex = 6;
            this.labelGenerateReports.Text = "Available reports to generate";
            // 
            // comboBoxReportType
            // 
            this.comboBoxReportType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReportType.Location = new System.Drawing.Point(11, 176);
            this.comboBoxReportType.Name = "comboBoxReportType";
            this.comboBoxReportType.Size = new System.Drawing.Size(256, 21);
            this.comboBoxReportType.TabIndex = 7;
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonGenerateReport.Location = new System.Drawing.Point(11, 319);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(256, 23);
            this.buttonGenerateReport.TabIndex = 8;
            this.buttonGenerateReport.Text = "Generate report";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxClientId.Location = new System.Drawing.Point(111, 215);
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(154, 20);
            this.textBoxClientId.TabIndex = 12;
            // 
            // labelClientId
            // 
            this.labelClientId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelClientId.AutoSize = true;
            this.labelClientId.Location = new System.Drawing.Point(8, 218);
            this.labelClientId.Name = "labelClientId";
            this.labelClientId.Size = new System.Drawing.Size(50, 13);
            this.labelClientId.TabIndex = 13;
            this.labelClientId.Text = "Client ID:";
            // 
            // labelLowerBound
            // 
            this.labelLowerBound.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLowerBound.AutoSize = true;
            this.labelLowerBound.Location = new System.Drawing.Point(7, 253);
            this.labelLowerBound.Name = "labelLowerBound";
            this.labelLowerBound.Size = new System.Drawing.Size(106, 13);
            this.labelLowerBound.TabIndex = 16;
            this.labelLowerBound.Text = "Lower price in range:";
            // 
            // labelUpperPriceInRange
            // 
            this.labelUpperPriceInRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelUpperPriceInRange.AutoSize = true;
            this.labelUpperPriceInRange.Location = new System.Drawing.Point(7, 281);
            this.labelUpperPriceInRange.Name = "labelUpperPriceInRange";
            this.labelUpperPriceInRange.Size = new System.Drawing.Size(106, 13);
            this.labelUpperPriceInRange.TabIndex = 17;
            this.labelUpperPriceInRange.Text = "Upper price in range:";
            // 
            // textBoxUpperPriceInRange
            // 
            this.textBoxUpperPriceInRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxUpperPriceInRange.Location = new System.Drawing.Point(111, 278);
            this.textBoxUpperPriceInRange.Name = "textBoxUpperPriceInRange";
            this.textBoxUpperPriceInRange.Size = new System.Drawing.Size(154, 20);
            this.textBoxUpperPriceInRange.TabIndex = 19;
            // 
            // textBoxLowerPriceInRange
            // 
            this.textBoxLowerPriceInRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxLowerPriceInRange.Location = new System.Drawing.Point(111, 250);
            this.textBoxLowerPriceInRange.Name = "textBoxLowerPriceInRange";
            this.textBoxLowerPriceInRange.Size = new System.Drawing.Size(154, 20);
            this.textBoxLowerPriceInRange.TabIndex = 18;
            // 
            // buttonClearOrders
            // 
            this.buttonClearOrders.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonClearOrders.Location = new System.Drawing.Point(12, 360);
            this.buttonClearOrders.Name = "buttonClearOrders";
            this.buttonClearOrders.Size = new System.Drawing.Size(255, 23);
            this.buttonClearOrders.TabIndex = 20;
            this.buttonClearOrders.Text = "Clear orders stored in database";
            this.buttonClearOrders.UseVisualStyleBackColor = true;
            // 
            // textBoxReportsResult
            // 
            this.textBoxReportsResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxReportsResult.CausesValidation = false;
            this.textBoxReportsResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxReportsResult.Location = new System.Drawing.Point(508, 511);
            this.textBoxReportsResult.Multiline = true;
            this.textBoxReportsResult.Name = "textBoxReportsResult";
            this.textBoxReportsResult.ReadOnly = true;
            this.textBoxReportsResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReportsResult.Size = new System.Drawing.Size(503, 234);
            this.textBoxReportsResult.TabIndex = 21;
            this.textBoxReportsResult.TabStop = false;
            // 
            // labelReports
            // 
            this.labelReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReports.AutoSize = true;
            this.labelReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReports.Location = new System.Drawing.Point(711, 477);
            this.labelReports.Name = "labelReports";
            this.labelReports.Size = new System.Drawing.Size(110, 31);
            this.labelReports.TabIndex = 22;
            this.labelReports.Text = "Reports";
            // 
            // buttonClearErrorLogs
            // 
            this.buttonClearErrorLogs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonClearErrorLogs.Location = new System.Drawing.Point(13, 410);
            this.buttonClearErrorLogs.Name = "buttonClearErrorLogs";
            this.buttonClearErrorLogs.Size = new System.Drawing.Size(113, 23);
            this.buttonClearErrorLogs.TabIndex = 23;
            this.buttonClearErrorLogs.Text = "Clear error logs";
            this.buttonClearErrorLogs.UseVisualStyleBackColor = true;
            this.buttonClearErrorLogs.Click += new System.EventHandler(this.ButtonClearErrorLogs_Click);
            // 
            // buttonClearReportsLog
            // 
            this.buttonClearReportsLog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonClearReportsLog.Location = new System.Drawing.Point(149, 410);
            this.buttonClearReportsLog.Name = "buttonClearReportsLog";
            this.buttonClearReportsLog.Size = new System.Drawing.Size(118, 23);
            this.buttonClearReportsLog.TabIndex = 24;
            this.buttonClearReportsLog.Text = "Clear report logs";
            this.buttonClearReportsLog.UseVisualStyleBackColor = true;
            this.buttonClearReportsLog.Click += new System.EventHandler(this.ButtonClearReportsLog_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 745);
            this.Controls.Add(this.buttonClearReportsLog);
            this.Controls.Add(this.buttonClearErrorLogs);
            this.Controls.Add(this.labelReports);
            this.Controls.Add(this.textBoxReportsResult);
            this.Controls.Add(this.buttonClearOrders);
            this.Controls.Add(this.textBoxUpperPriceInRange);
            this.Controls.Add(this.textBoxLowerPriceInRange);
            this.Controls.Add(this.labelUpperPriceInRange);
            this.Controls.Add(this.labelLowerBound);
            this.Controls.Add(this.labelClientId);
            this.Controls.Add(this.textBoxClientId);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.comboBoxReportType);
            this.Controls.Add(this.labelGenerateReports);
            this.Controls.Add(this.buttonLoadFile);
            this.Controls.Add(this.labelLoadFile);
            this.Controls.Add(this.labelLogs);
            this.Controls.Add(this.labelReport);
            this.Controls.Add(this.dataGridViewReports);
            this.Controls.Add(this.textBoxErrorLogs);
            this.Name = "MainView";
            this.Text = "Report generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxErrorLogs;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.Label labelClientId;
        private System.Windows.Forms.Label labelLowerBound;
        private System.Windows.Forms.Label labelUpperPriceInRange;
        private System.Windows.Forms.TextBox textBoxUpperPriceInRange;
        private System.Windows.Forms.TextBox textBoxLowerPriceInRange;
        private System.Windows.Forms.Button buttonClearOrders;
        private System.Windows.Forms.TextBox textBoxReportsResult;
        private System.Windows.Forms.Label labelReports;
        private System.Windows.Forms.Button buttonClearErrorLogs;
        private System.Windows.Forms.Button buttonClearReportsLog;
    }
}

