using ReportGenerator.Utilities;
using System;
using System.IO;
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
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialogLoadOrders.InitialDirectory = appPath;
        }

        public Button GetButtonLoadFile()
        {
            return buttonLoadFile;
        }

        public Button GetButtonGenerateReport()
        {
            return buttonGenerateReport;
        }

        public Button GetButtonSaveReportToFile()
        {
            return buttonSaveReportToFile;
        }

        public string GetFilenameOfOrdersToOpen()
        {
            string filePath = null;
            if (openFileDialogLoadOrders.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialogLoadOrders.FileName;
            }
            return filePath;
        }

        public void AppendLogText(string text)
        {
            textBoxLogs.AppendText(text + "\n");
        }

        public string GetFilenameToSaveReport()
        {
            return textBoxFileName.Text;
        }      
    }
}
