using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientManage.Library;

namespace ClientManage.Forms
{
    public partial class FrmAddressList : BasePopupForm
    {
        public FrmAddressList(IEnumerable<string> list)
        {
            InitializeComponent();

            foreach (var item in list)
            {
                txtList.AppendText(item + "; ");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            txtList.Focus();
            txtList.SelectionStart = 0;
            txtList.SelectionLength = txtList.Text.Length;
            Clipboard.SetText(txtList.Text);

            var msg = new MyMessageBox("רשימת הכתובות הועתקה בהצלחה", "רשימת כתובות...", MyMessageBox.MyMessageType.Confirm, MyMessageBox.MyMessageButton.None);
            msg.Show();
        }
    }
}
