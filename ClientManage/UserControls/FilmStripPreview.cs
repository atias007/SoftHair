using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClientManage.Interfaces;
using System.Drawing.Drawing2D;

namespace ClientManage.UserControls
{
    public partial class FilmstripPreview : UserControl
    {
        public event EventHandler SelectedChanged;
        private ClientPhoto _photo = null;
        private bool _selected = false;

        public FilmstripPreview(ClientPhoto photo)
        {
            InitializeComponent();
            _photo = photo;
        }

        public ClientPhoto Photo
        {
            get { return _photo; }
        }

        public void RefreshData(ClientPhoto photo)
        {
            _photo = photo;
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

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void Control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        private void FilmStripPreview_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Color cTo, cBorder;
            if (_selected)
            {
                cTo = Color.FromArgb(235, 192, 74);
                cBorder = Color.FromArgb(135, 92, 0);
                e.Graphics.FillRectangle(new SolidBrush(cTo), rect);
                e.Graphics.DrawRectangle(new Pen(cBorder), rect);
            }
        }
    }
}
