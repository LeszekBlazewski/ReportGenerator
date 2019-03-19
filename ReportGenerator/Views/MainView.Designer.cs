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
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.dataGridViewReports = new System.Windows.Forms.DataGridView();
            this.labelCurrentReport = new System.Windows.Forms.Label();
            this.labelLogs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.CausesValidation = false;
            this.textBoxLogs.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxLogs.Location = new System.Drawing.Point(0, 429);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(800, 138);
            this.textBoxLogs.TabIndex = 0;
            this.textBoxLogs.TabStop = false;
            // 
            // dataGridViewReports
            // 
            this.dataGridViewReports.AllowUserToOrderColumns = true;
            this.dataGridViewReports.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dataGridViewReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReports.Location = new System.Drawing.Point(300, 37);
            this.dataGridViewReports.Name = "dataGridViewReports";
            this.dataGridViewReports.Size = new System.Drawing.Size(488, 259);
            this.dataGridViewReports.TabIndex = 1;
            // 
            // labelCurrentReport
            // 
            this.labelCurrentReport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCurrentReport.AutoSize = true;
            this.labelCurrentReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentReport.Location = new System.Drawing.Point(415, 9);
            this.labelCurrentReport.Name = "labelCurrentReport";
            this.labelCurrentReport.Size = new System.Drawing.Size(280, 25);
            this.labelCurrentReport.TabIndex = 2;
            this.labelCurrentReport.Text = "Current report file (data.csv)";
            // 
            // labelLogs
            // 
            this.labelLogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelLogs.AutoSize = true;
            this.labelLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogs.Location = new System.Drawing.Point(359, 395);
            this.labelLogs.Name = "labelLogs";
            this.labelLogs.Size = new System.Drawing.Size(73, 31);
            this.labelLogs.TabIndex = 3;
            this.labelLogs.Text = "Logs";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 567);
            this.Controls.Add(this.labelLogs);
            this.Controls.Add(this.labelCurrentReport);
            this.Controls.Add(this.dataGridViewReports);
            this.Controls.Add(this.textBoxLogs);
            this.Name = "MainView";
            this.Text = "Report generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.DataGridView dataGridViewReports;
        private System.Windows.Forms.Label labelCurrentReport;
        private System.Windows.Forms.Label labelLogs;
    }
}

