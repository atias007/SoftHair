using System;
using System.Windows.Forms;
using SoftHairQuickLanch.Forms;

namespace SoftHairQuickLanch.Library
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var cla = new CommandLineArguments(args);
            if (cla.Contains("-support"))
            {
                var fMain = new frmMain();
                fMain.OpenSupportForm(true);
                Environment.Exit(0);
            }
            else
            {
                SingleApplication.Run(new frmMain());
            }
        }
    }
}