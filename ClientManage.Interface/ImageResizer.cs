using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ClientManage.Interfaces
{
    public class ImageResizer
    {
        public enum AnchorPosition { Top, Bottom, Center, Left, Right }

        public static Image ResizeImage(Image image, int width, int height)
        {
            return ResizeImage(image, width, height, InterpolationMode.HighQualityBicubic);
        }
        public static Image ResizeImage(Image image, int width, int height, InterpolationMode interpolation)
        {
            var sourceWidth = image.Width;
            var sourceHeight = image.Height;
            int sourceX = 0, sourceY = 0;
            int destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((height - (sourceHeight * nPercent)) / 2);
            }

            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var bmPhoto = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            var grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode = interpolation;

            grPhoto.DrawImage(image, new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        public static Image ResizeImagePercent(Image image, int percent)
        {
            return ResizeImagePercent(image, percent, InterpolationMode.HighQualityBicubic);
        }
        public static Image ResizeImagePercent(Image image, int percent, InterpolationMode interpolation)
        {
            var nPercent = ((float)percent / 100);

            var sourceWidth = image.Width;
            var sourceHeight = image.Height;
            var sourceX = 0;
            var sourceY = 0;

            var destX = 0;
            var destY = 0;
            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            var grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = interpolation;

            grPhoto.DrawImage(image, new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        public static Image ResizeImageCrop(Image image, int width, int height, AnchorPosition anchor)
        {
            return ResizeImageCrop(image, width, height, anchor, InterpolationMode.HighQualityBicubic);
        }
        public static Image ResizeImageCrop(Image image, int width, int height, AnchorPosition anchor, InterpolationMode interpolation)
        {
            var sourceWidth = image.Width;
            var sourceHeight = image.Height;
            var sourceX = 0;
            var sourceY = 0;
            var destX = 0;
            var destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);

            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;
                switch (anchor)
                {
                    case AnchorPosition.Top:
                        destY = 0;
                        break;
                    case AnchorPosition.Bottom:
                        destY = (int)
                            (height - (sourceHeight * nPercent));
                        break;
                    default:
                        destY = (int)
                            ((height - (sourceHeight * nPercent)) / 2);
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (anchor)
                {
                    case AnchorPosition.Left:
                        destX = 0;
                        break;
                    case AnchorPosition.Right:
                        destX = (int)
                          (width - (sourceWidth * nPercent));
                        break;
                    default:
                        destX = (int)
                          ((width - (sourceWidth * nPercent)) / 2);
                        break;
                }
            }

            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var bmPhoto = new Bitmap(width,
                    height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            var grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = interpolation;

            grPhoto.DrawImage(image, new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}