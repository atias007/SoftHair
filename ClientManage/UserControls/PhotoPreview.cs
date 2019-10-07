using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;

namespace ClientManage.UserControls
{
    public partial class PhotoPreview : UserControl
    {
        public event EventHandler SelectedChanged;
        private ClientPhoto _photo;
        private bool _selected = false;

        public PhotoPreview(ClientPhoto photo)
        {
            InitializeComponent();

            _photo = photo;
            lblDescription.Text = _photo.Subject;
            lblDate.Text = _photo.DateCreated.ToString("dd/MM/yyyy בשעה HH:mm");
        }

        public ClientPhoto Photo
        {
            get { return _photo; }
        }

        public void RefreshData(ClientPhoto photo)
        {
            _photo = photo;
            lblDescription.Text = _photo.Subject;
            lblDate.Text = _photo.DateCreated.ToString("dd/MM/yyyy בשעה HH:mm");
            LoadImage();
        }

        public void LoadImage()
        {
            try
            {
                picPicture.BackgroundImage = Image.FromFile(_photo.Picture);
            }
            catch
            {
                picPicture.BackgroundImage = global::ClientManage.Properties.Resources.no_photo;
            }
        }

        public bool Selected
        {
            get { return _selected; }
            set 
            {
                if (_selected != value)
                {
                    _selected = value; 
                    Refresh();
                    if (SelectedChanged != null) SelectedChanged(this, new EventArgs());
                }
            }
        }

        public override void Refresh()
        {
            Color color1, color2;
            if (_selected)
            {
                color1 = Color.FromArgb(135, 92, 0);
                color2 = Color.FromArgb(99, 55, 0);
            }
            else
            {
                color1 = Color.FromArgb(109, 115, 122);
                color2 = Color.FromArgb(69, 75, 82);
            }
            lblCap1.ForeColor = color1;
            lblCap2.ForeColor = color1;
            lblDate.ForeColor = color2;
            lblDescription.ForeColor = color2;

            base.Refresh();
        }

        private void PhotoPreview_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(3, 3, 223, 209);
            Color cFrom, cTo, cBorder;
            cFrom = Color.White;
            if (_selected)
            {
                cTo = Color.FromArgb(255, 212, 94);
                cBorder = Color.FromArgb(155, 112, 0);
            }
            else
            {
                cTo = Color.FromArgb(228, 235, 242);
                cBorder = Color.FromArgb(129, 135, 142);
            }
           
            var brush = new LinearGradientBrush(rect, cFrom, cTo, LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(brush, rect);
            e.Graphics.DrawRectangle(new Pen(cBorder), rect);

            // draw drop shadow
            Image image;
            image = global::ClientManage.Properties.Resources.shadow_top;
            e.Graphics.DrawImage(image, new Rectangle(0, 0, 232, 3));
            image = global::ClientManage.Properties.Resources.shadow_bottom;
            e.Graphics.DrawImage(image, new Rectangle(0, 213, 232, 6));
            image = global::ClientManage.Properties.Resources.shadow_left;
            e.Graphics.DrawImage(image, new Rectangle(0, 3, 3, 210));
            image = global::ClientManage.Properties.Resources.shadow_right;
            e.Graphics.DrawImage(image, new Rectangle(227, 3, 5, 210));
        }

        private void picPicture_Paint(object sender, PaintEventArgs e)
        {
            Color cBorder;
            if (_selected)
            {
                cBorder = Color.FromArgb(195, 152, 40);
            }
            else
            {
                cBorder = Color.FromArgb(169, 175, 182);
            }
            var rect = new Rectangle(0, 0, picPicture.Width - 1, picPicture.Height - 1);
            e.Graphics.DrawRectangle(new Pen(cBorder), rect);
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void Control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }
    }
}
