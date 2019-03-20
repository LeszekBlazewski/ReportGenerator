using ReportGenerator.Utilities;
using System;
using System.Transactions;
using System.Windows.Forms;
using ReportGenerator.ViewModel;
using System.IO;

namespace ReportGenerator
{
    class MainMenuController
    {
        private readonly MainView view;
       
        private OrderViewModel viewModel;

        public MainMenuController(MainView view, OrderViewModel viewModel)
        {
            this.view = view;
            this.viewModel = viewModel;
        }

        public void RunMainMenuView()
        {
            Application.Run(view);
        }

        public void InitializeController()
        {
            view.GetButtonLoadFile().Click += DisplayFileDialog;
            view.GetButtonGenerateReport().Click += GenerateReport;
        }

        private void DisplayFileDialog(object sender, EventArgs e)
        {
            string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
            view.GetOpenFileDialogLoadOrders().InitialDirectory = AppPath;
            if (view.GetOpenFileDialogLoadOrders().ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = view.GetOpenFileDialogLoadOrders().FileName;
            }
        }

        private void GenerateReport(object sender, EventArgs e)
        {

        }
    }
}
