using System;
using System.Windows.Forms;
using ClientManage.BL;

namespace ClientManage.Forms
{
    public partial class FormMailPreview : BasePopupForm
    {
        private static bool _sendEmail;

        public FormMailPreview(ref string documentText)
        {
            InitializeComponent();
            webBrowser1.DocumentText = documentText;
        }

        public static bool SendEmail
        {
            get { return _sendEmail; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var MyPrintDialog = new PrintDialog();
            if (AppSettingsHelper.GetParamValue<bool>("APP_SHOW_PRINTER_DIALOG"))
            {
                if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
            } 
            webBrowser1.Print();

            this.Cursor = Cursors.Default;
        }

        private void tbbSend_Click(object sender, EventArgs e)
        {
            _sendEmail = true;
            this.Close();
        }

        private void frmMailPreview_RequestForClose(object sender, EventArgs e)
        {
            toolStripButton1_Click(null, null);
        }
    }
}