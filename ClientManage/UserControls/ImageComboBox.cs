using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ClientManage.UserControls
{
    public class ImageComboBox : ComboBox
    {
        public ImageComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 48;
        }

        private ImageList _imageList = null;

        public ImageList ImageList
        {
            get { return _imageList; }
            set { _imageList = value; }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            ImageComboBoxListItem item;
            var imageSize = _imageList == null ? new Size(0, 0) : _imageList.ImageSize;
            var bounds = e.Bounds;

            try
            {
                item = (ImageComboBoxListItem)Items[e.Index];
                if (item.ImageIndex != -1 && _imageList != null) _imageList.Draw(e.Graphics, bounds.Left + bounds.Width - imageSize.Width, bounds.Top, item.ImageIndex);
                var rect = new RectangleF(bounds.Left, bounds.Top, bounds.Width - imageSize.Width - 7, bounds.Height);
                var sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor),rect, sf);
            }
            catch
            {
                e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), bounds.Left, bounds.Top);
            }

            base.OnDrawItem(e);
        }
    }

    public class ImageComboBoxListItem
    {
        public ImageComboBoxListItem() : this("")
        {
        }

        public ImageComboBoxListItem(string text)
            : this(text, -1)
        {
        }

        public ImageComboBoxListItem(string text, int imageIndex)
        {
            _text = text;
            _imageIndex = imageIndex;
        }

        private string _text = string.Empty;
        private int _imageIndex = -1;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public int ImageIndex
        {
            get { return _imageIndex; }
            set { _imageIndex = value; }
        }

        public object Tag { get; set; }

        public override string ToString()
        {
            return _text;
        }


    }
}
