using System;
using System.Windows.Forms;
using BizCare.SoftHair.UpdateVersion.Properties;

namespace BizCare.SoftHair.UpdateVersion.Library
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
            try
            {
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.FatalErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
