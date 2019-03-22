using System;
using System.Windows.Forms;
using ReportGenerator.ViewModel;

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

        }

        private void GenerateReport(object sender, EventArgs e)
        {

        }
    }
}
