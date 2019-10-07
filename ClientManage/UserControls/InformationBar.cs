using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientManage.UserControls
{
    public partial class InformationBar : UserControl
    {
        private Image _image = null;
        private string _text = "InformationPanel";

        public InformationBar()
        {
            InitializeComponent();
        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {
            //Pen pen = new Pen(Color.FromArgb(101, 147, 207));
            //e.Graphics.DrawLine(pen, 0, 0, 0, this.Height);
            //e.Graphics.DrawLine(pen, this.Width - 1, 0, this.Width - 1, this.Height);
            //e.Graphics.DrawLine(Pens.White, 1, 1, 1, this.Height - 2);

            if (_image != null)
            {
                e.Graphics.DrawImage(_image, 6, 6, 16, 16);
            }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; this.Refresh(); }
        }

        public Image LabelImage
        {
            get { return lblMsg.Image; }
            set { lblMsg.Image = value; }
        }

        public string LabelText
        {
            get { return lblMsg.Text; }
            set 
            { 
                lblMsg.Text = value;
                var g = this.CreateGraphics();
                lblMsg.Width = Convert.ToInt32(g.MeasureString(lblMsg.Text, lblMsg.Font).Width) + 5;
            }
        }

        public bool LabelVisible
        {
            get { return lblMsg.Visible; }
            set { lblMsg.Visible = value; }
        }

        public Color LabelForeColor
        {
            get { return lblMsg.ForeColor; }
            set { lblMsg.ForeColor = value; }
        }

        public string PanelText
        {
            get
            {
                return _text;
            }
            set
            {
                lblText.Text = value;
                _text = value;
            }
        }
        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        private void InformationBar_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.search_panel_bgblue;
        }
    }
}
