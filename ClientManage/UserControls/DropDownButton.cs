using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class DropDownButton : UserControl
    {
        public DropDownButton()
        {
            InitializeComponent();
            this.BackgroundImage = global::ClientManage.Properties.Resources.ddl_reg;
        }

        private void DropDownButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.ddl_light;
        }

        private void DropDownButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.ddl_reg;
        }

        private void DropDownButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.ddl_dark;
        }

        private void DropDownButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = global::ClientManage.Properties.Resources.ddl_reg;
        }
    }
}
