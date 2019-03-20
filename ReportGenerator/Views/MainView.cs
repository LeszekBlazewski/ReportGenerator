using ReportGenerator.Utilities;
using System;
using System.Windows.Forms;

namespace ReportGenerator
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            comboBoxReportType.DataSource = Enum.GetValues(typeof(ReportType));
            comboBoxReportType.SelectedItem = ReportType.Number_of_orderds;
        }

        public Button GetButtonLoadFile()
        {
            return buttonLoadFile;
        }

        public Button GetButtonGenerateReport()
        {
            return buttonGenerateReport;
        }

        public OpenFileDialog GetOpenFileDialogLoadOrders()
        {
            return openFileDialogLoadOrders;
        }

        public void AppendLogText(String text)
        {
            textBoxLogs.AppendText(text + "\n");
        }
    }
}
