using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MouseMover.WindowsApp
{
    static class ApplicationMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApplicationForm());
        }
    }
}