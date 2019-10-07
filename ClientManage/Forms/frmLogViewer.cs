using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;

namespace ClientManage.Forms
{
    public partial class FormLogViewer : Form
    {
        public FormLogViewer(Exception ex)
        {
            InitializeComponent();
            textBox1.Text = Utils.GetExceptionMessage(ex);
        }
    }
}