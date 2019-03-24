using Equin.ApplicationFramework;
using ReportGenerator.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReportGenerator
{
    public partial class MainView : Form
    {
        private decimal lowerBound,upperBound;

        public decimal GetLowerBound() => lowerBound;

        public decimal GetUpperBound() => upperBound;

        public MainView()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializeFileDialog();
        }

        private void InitializeComboBox()
        {
            // set combobox default model
            comboBoxReportType.DataSource = Enum.GetValues(typeof(ReportType));
            comboBoxReportType.SelectedItem = ReportType.Number_of_orders;
        }

        private void InitializeFileDialog()
        {
            // set file dialogs options
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialogLoadOrders.InitialDirectory = appPath;
        }

        public string[] GetFilenamesOfOrdersToOpen()
        {
            string[] filenames=null;

            if (openFileDialogLoadOrders.ShowDialog() == DialogResult.OK)
                filenames = openFileDialogLoadOrders.FileNames;

            return filenames;
        }

        public void AppendErrorToLogs(string text)
        {
            textBoxErrorLogs.AppendText(text + "\n");
        }

        public void AppendErrorsToLogs(List<string> errorList)
        {
            errorList.ForEach(error => AppendErrorToLogs(error));
        }

        public void AppendReportResultToLog(string reportResult)
        {
            textBoxReportsResult.AppendText(reportResult + "\n");
        }

        public void UpdateDataGriedView(List<Order> orders)
        {
            orderBindingSource.Clear();
            BindingListView<Order> ordersToDisplay = new BindingListView<Order>(orders);
            dataGridViewReports.DataSource = ordersToDisplay;
        }

        public bool ValidateClientID(string clienId)
        {
            var clientIdRegex = new Regex(@"^[\p{L}0-9]{1,6}$");

            if (!clientIdRegex.IsMatch(clienId))
                return false;

            return true;
        }

        public bool ValidateDecimalBounds()
        {
            if (!decimal.TryParse(textBoxLowerPriceInRange.Text, out lowerBound) || !decimal.TryParse(textBoxUpperPriceInRange.Text, out upperBound))
            {
                MessageBox.Show("Please input a valid price range !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ButtonClearErrorLogs_Click(object sender, EventArgs e)
        {
            textBoxErrorLogs.Text = "";
        }

        private void ButtonClearReportsLog_Click(object sender, EventArgs e)
        {
            textBoxReportsResult.Text = "";
        }

        public Button GetButtonLoadFile()
        {
            return buttonLoadFile;
        }

        public ReportType GetReportTypeToGenerate()
        {
            Enum.TryParse(comboBoxReportType.Text, out ReportType reportType);

            return reportType;
        }

        public string GetClientID()
        {
            return textBoxClientId.Text;
        }

        public Button GetButtonGenerateReport()
        {
            return buttonGenerateReport;
        }

        public Button GetButtonClearOrdersInDatabase()
        {
            return buttonClearOrders;
        }
    }
}
