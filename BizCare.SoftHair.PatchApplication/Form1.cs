using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using ClientManage.Interfaces;

namespace BizCare.SoftHair.PatchApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PatchApplication();
            Environment.Exit(0);
        }

        private void PatchApplication()
        {
            var filename = Path.Combine(Application.StartupPath, "content.dat");
            if(!File.Exists(filename)) filename = @"c:\SoftHair\content.dat";
            var connString = string.Format(Properties.Resources.ConnectionString, filename);

            if (File.Exists(filename))
            {
                var conn = new OleDbConnection(connString);
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    ShowFailMessage("Fail connecting to database.\n\nError message:\n" + ex.Message);
                    return;
                }

                var licence = Security.GetNewLicense();
                var row = licence.License[0];

                row.cpu_id = Properties.Resources.MachineKey;
                row.from_date = Convert.ToDateTime(Properties.Resources.FromDate);
                row.to_date = Convert.ToDateTime(Properties.Resources.ToDate);
                row.last_used = row.from_date;
                row.type = Properties.Resources.Type;
                row.key = Properties.Resources.Id;

                var key = Security.SaveLicence(licence);

                var cmd = new OleDbCommand("spAddLicense", conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("prm_key", key);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ShowFailMessage("Fail adding license.\n\nError message:\n" + ex.Message);
                    return;
                }

                try { conn.Close(); }
// ReSharper disable EmptyGeneralCatchClause
                catch { }
// ReSharper restore EmptyGeneralCatchClause

                MessageBox.Show("Finish successfully", "Patch success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    filename = Path.Combine(Application.StartupPath, "SoftHair.exe");
                    if (File.Exists(filename)) System.Diagnostics.Process.Start(filename);
                    
                }
                catch
                {
                }
            }
            else
            {
                ShowFailMessage("Can't find database filename.\nRun the patch from the root of SoftHair application.");
            }
        }

        private static void ShowFailMessage(string msg)
        {
            MessageBox.Show(msg, "Patch fail...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}