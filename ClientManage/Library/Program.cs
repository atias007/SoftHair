using System;
using System.Diagnostics;
using System.Windows.Forms;
using ClientManage.Forms;
using ClientManage.Interfaces;
using System.Configuration;
using System.IO;
using System.Text;

namespace ClientManage.Library
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Trace.WriteLine("1");
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //Trace.WriteLine("2");
            General.StartupPath = Application.StartupPath;
            //Trace.WriteLine("3");
            try
            {
                ModifyAppConfig();
            }
            catch { }
            //Trace.WriteLine("4");
            Application.EnableVisualStyles();
            //Trace.WriteLine("5");
            Application.SetCompatibleTextRenderingDefault(false);
            //Trace.WriteLine("6");
            SingleApplication.Run(new FormSplash());

            // Stop the application and all the threads in suspended state.
            Environment.Exit(-1);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = new Exception();
            try { ex = (e.ExceptionObject is Exception ? (Exception)e.ExceptionObject : new Exception(e.ExceptionObject.ToString())); } catch (Exception) { }
            try { General.WriteExceptionToFile(ex); } catch (Exception) { }
            try { EventLogManager.AddErrorMessage("[UnhandledException] " + ex.Message, ex); } catch (Exception) { }
        }

        private static void ModifyAppConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = config.GetSection("connectionStrings");

            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("DPAPIProtection");
            }

            var strConn = string.Format(Properties.Resources.connection_string, Path.Combine(General.StartupPath, Utils.DataFilename));
            General.ConnectionString = strConn;
            config.ConnectionStrings.ConnectionStrings["SoftHairAppConnStr"].ConnectionString = strConn;
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
            Properties.Settings.Default.Reload();
        }
    }
}