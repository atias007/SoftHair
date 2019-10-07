using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class PhonebookButton : UserControl
    {
        private string _text = string.Empty;
        public event EventHandler ButtonClick;
        
        public PhonebookButton()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get { return _text; }
            set { _text = value; lblText.Text = value; }
        }

        private void lblText_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.ph_button1;
        }

        private void lblText_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.ph_button2;
        }

        private void lblText_Click(object sender, EventArgs e)
        {
            if (ButtonClick != null) ButtonClick(this, e);
        }
    }
}
