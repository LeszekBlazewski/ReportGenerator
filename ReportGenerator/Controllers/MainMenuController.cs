using ReportGenerator.Utilities;
using System;
using System.Transactions;
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
            //view.GetButtonClickMe().Click += DisplayMessage;
        }

        private void DisplayMessage(object sender, EventArgs e)
        {
            MessageBox.Show("Oh noes!", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
