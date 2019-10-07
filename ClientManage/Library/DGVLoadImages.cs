using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ClientManage.Library
{
    public class DgvLoadImages
    {
        private delegate void LoadImagesHandler(DataGridView dgv);

        private AsyncCallback _asyncLiCallBack;
        private LoadImagesHandler _li;
        private Thread _curTh;
        private string _picturePathColumn = "clmPicture";
        private string _imageColumn = "clmImage";
        private Image _defaultImage = Properties.Resources.no_image_small;
        private ImageList _imageList;
        private bool _loadThumbnail = true;
        private Size _thumbnailSize = new Size(64, 48);

        public Image DefaultImage
        {
            get { return _defaultImage; }
            set { _defaultImage = value; }
        }

        public bool LoadThumbnail
        {
            get { return _loadThumbnail; }
            set { _loadThumbnail = value; }
        }

        public Size ThumbnailSize
        {
            get { return _thumbnailSize; }
            set { _thumbnailSize = value; }
        }

        public string PicturePathColumn
        {
            get { return _picturePathColumn; }
            set { _picturePathColumn = value; }
        }

        public string ImageColumn
        {
            get { return _imageColumn; }
            set { _imageColumn = value; }
        }

        public ImageList ImageList
        {
            get { return _imageList; }
            set { _imageList = value; }
        }

        public void BeginLoadImages(DataGridView grid)
        {
            if (_li != null && _curTh != null)
            {
                _curTh.Abort();
                _curTh = null;
            }
            _li = new LoadImagesHandler(LoadImages);
            _asyncLiCallBack = new AsyncCallback(LoadImagesCallBack);
            _li.BeginInvoke(grid, _asyncLiCallBack, null);
        }

        private void LoadImagesCallBack(IAsyncResult ires)
        {
            _li = null;
        }

        public void LoadImages(DataGridView grid)
        {
            _curTh = Thread.CurrentThread;
            for (var i = 0; i < grid.Rows.Count; i++)
            {
                LoadSingleImage(grid, i);
            }
        }

        public void LoadSingleImage(DataGridView grid, int index)
        {
            string fn;
            Image image;
            //DataGridView grid = dgv;

            if (grid.Rows.Count <= index) return;
            try { fn = Convert.ToString(grid.Rows[index].Cells[_picturePathColumn].Value); }
            catch { return; }

            if (fn.Equals("[NO PICTURE]"))
            {
                image = Properties.Resources.no_client;
            }
            else
            {
                image = _imageList == null ? GetImageFromFile(fn) : GetImageFromImageList(fn);
            }
            if (image == null) return;

            try { grid.Rows[index].Cells[_imageColumn].Value = image; }
            catch
            {
                try { grid.Rows[index].Cells[_imageColumn].Value = image; }
                catch
                {
                    try { grid.Rows[index].Cells[_imageColumn].Value = image; }
                    catch { }
                }
            }
        }

        private Image GetImageFromFile(string path)
        {
            var image = _defaultImage;

            if (path.Length > 0)
            {
                try { image = ReadImageFile(path); }
                catch
                {
                    if (System.IO.File.Exists(path))
                    {
                        try { image = ReadImageFile(path); }
                        catch
                        {
                            try { image = ReadImageFile(path); }
                            catch { }
                        }
                    }
                }
            }

            return image;
        }

        private Image ReadImageFile(string path)
        {
            var image = Image.FromFile(path);
            if (_loadThumbnail) image = image.GetThumbnailImage(_thumbnailSize.Width, _thumbnailSize.Height, null, IntPtr.Zero);
            return image;
        }

        private Image GetImageFromImageList(string value)
        {
            var image = _defaultImage;

            try
            {
                image = _imageList.Images[Convert.ToInt32(value)];
            }
            catch { }

            return image;
        }
    }
}