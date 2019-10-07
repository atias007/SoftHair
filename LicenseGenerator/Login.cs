using System;
using System.Configuration;
using System.Windows.Forms;
using BizCareAdmin.Properties;
using ClientManage.Interfaces;

namespace BizCareAdmin
{
    public partial class Login : Form
    {
        public static bool IsOk;
        public static string DbFilename;

        public Login()
        {
            InitializeComponent();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            var xml = Resources.login_key;
            var row = Crypt.DecryptXMLDataset(xml).Tables[0].Rows[0];

            if (txtUsername.Text.ToLower().Trim().Equals(row["Username"]))
            {
                if (txtPassword.Text.Equals(row["Password"]))
                {
                    IsOk = true;

                    var dialog = new OpenFileDialog
                                     {
                                         Title = "Select database file...",
                                         Filter = "Database file|*.dat",
                                         InitialDirectory = "c:\\softhair",
                                         FileName = "content.dat",
                                         CheckFileExists = true
                                     };
                    var result = dialog.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        ModifyAppConfig(dialog.FileName);
                        DbFilename = dialog.FileName;
                        this.Close();
                        return;
                    }
                 
                    txtPassword.Clear();
                    txtUsername.Select();
                    IsOk = false;
                    return;
                }
            }
            txtUsername.Select();
            IsOk = false;
            MessageBox.Show("Incorrect Username or Password", "Login...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private static void ModifyAppConfig(string filename)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = config.GetSection("connectionStrings");

            //if (!section.SectionInformation.IsProtected)
            //{
            //    section.SectionInformation.ProtectSection("DPAPIProtection");
            //}

            var strConn = string.Format(Settings.Default.data_ConnectionString, filename);
            config.ConnectionStrings.ConnectionStrings["AdminConnection"].ConnectionString = strConn;
            section.SectionInformation.ForceSave = true;

            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            IsOk = false;
            
            //_isOk = true;
            //this.Close();
            //CreateKeyFile("", "");
        }

        //private void CreateKeyFile(string userName, string password)
        //{
        //    var ds = new DataSet();
        //    var table = new DataTable();
        //    table.Columns.Add("Username", typeof(string));
        //    table.Columns.Add("Password", typeof(string));
        //    table.Rows.Add(new object[] { userName, password });
        //    ds.Tables.Add(table);

        //    var cryptDs = Crypt.EncryptDataset(ds);
        //    cryptDs.WriteXml("c:\\key.xml");
        //}
    }
}