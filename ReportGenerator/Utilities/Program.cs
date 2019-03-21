using ReportGenerator.ViewModel;
using System;
using System.Windows.Forms;

namespace ReportGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            MainView view = new MainView();
            OrderViewModel viewModel = new OrderViewModel();
            MainMenuController controller = new MainMenuController(view, viewModel);

            controller.InitializeController();

            controller.RunMainMenuView();
        }
    }
}
