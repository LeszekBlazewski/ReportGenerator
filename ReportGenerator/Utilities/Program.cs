using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            MainMenuController controller = new MainMenuController(view);

            controller.InitializeController();

            controller.RunMainMenuView();
        }
    }
}
