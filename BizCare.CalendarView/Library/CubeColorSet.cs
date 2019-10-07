using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BizCare.Calendar.Library
{
    internal class CubeColorSet
    {
        private CubeColorSet() { }

        private Color _fromColor;
        internal Color FromColor
        {
            get { return _fromColor; }
        }

        private Color _toColor;
        internal Color ToColor
        {
            get { return _toColor; }
        }

        private Color _borderColor;
        internal Color BorderColor
        {
            get { return _borderColor; }
        }

        private Color _textColor = Color.Black;
        public Color TextColor
        {
            get { return _textColor; }
        }


        public enum ColorSetTypes { Orange = -1, Blue, Purple, Red, Green, DarkBlue, Gray, DarkGray, Cian };
        public static CubeColorSet GetColorSet(ColorSetTypes colorSet)
        {
            var cc = new CubeColorSet();

            switch (colorSet)
            {
                case ColorSetTypes.Blue:
                    cc._fromColor = Color.FromArgb(251, 252, 254);
                    cc._toColor = Color.FromArgb(192, 213, 235);
                    cc._borderColor = Color.FromArgb(93, 140, 201);
                    break;
                case ColorSetTypes.Orange:
                    cc._fromColor = Color.FromArgb(255, 230, 160);
                    cc._toColor = Color.FromArgb(255, 203, 80);
                    cc._borderColor = Color.FromArgb(145, 103, 2);
                    break;
                case ColorSetTypes.Purple:
                    cc._fromColor = Color.FromArgb(224, 190, 206);
                    cc._toColor = Color.FromArgb(196, 133, 164);
                    cc._borderColor = Color.FromArgb(129, 61, 95);
                    break;
                case ColorSetTypes.Red:
                    cc._fromColor = Color.FromArgb(241, 170, 172);
                    cc._toColor = Color.FromArgb(229, 103, 110);
                    cc._borderColor = Color.FromArgb(134, 23, 28);
                    break;
                case ColorSetTypes.Green:
                    cc._fromColor = Color.FromArgb(190, 230, 184);
                    cc._toColor = Color.FromArgb(134, 210, 125);
                    cc._borderColor = Color.FromArgb(44, 101, 36);
                    break;
                case ColorSetTypes.DarkBlue:
                    cc._fromColor = Color.FromArgb(119, 133, 160);
                    cc._toColor = Color.FromArgb(73, 88, 119);
                    cc._borderColor = Color.FromArgb(38, 46, 62);
                    cc._textColor = Color.White;
                    break;
                case ColorSetTypes.Gray:
                    cc._fromColor = Color.FromArgb(205, 205, 205);
                    cc._toColor = Color.FromArgb(167, 167, 167);
                    cc._borderColor = Color.FromArgb(64, 64, 64);
                    break;
                case ColorSetTypes.DarkGray:
                    cc._fromColor = Color.FromArgb(124, 124, 124);
                    cc._toColor = Color.FromArgb(81, 81, 81);
                    cc._borderColor = Color.FromArgb(41, 41, 41);
                    cc._textColor = Color.White;
                    break;
                case ColorSetTypes.Cian:
                    cc._fromColor = Color.FromArgb(179, 230, 215);
                    cc._toColor = Color.FromArgb(126, 211, 182);
                    cc._borderColor = Color.FromArgb(35, 101, 81);
                    break;
                default:
                    cc = null;
                    break;
            }

            return cc;
        }
    }
}
