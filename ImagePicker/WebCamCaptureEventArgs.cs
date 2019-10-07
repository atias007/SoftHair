using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ImagePicker
{
    public class WebCamCaptureEventArgs : EventArgs
    {
        private readonly Image _captureImage = null;

        public WebCamCaptureEventArgs(Image captureImage)
        {
            _captureImage = captureImage;
        }

        public Image CaptureImage
        {
            get { return _captureImage; }
        }
    }
}
