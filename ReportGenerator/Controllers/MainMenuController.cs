using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportGenerator
{
    class MainMenuController
    {
        private readonly MainView view;

        public MainMenuController(MainView view)
        {
            this.view = view;
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
