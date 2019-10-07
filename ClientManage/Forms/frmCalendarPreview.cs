using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;

namespace ClientManage.Forms
{
    public sealed partial class FormCalendarPreview : Form
    {
        #region Form Drop Shadow

        private const int CsDropshadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
            get
            {
                var parameters = base.CreateParams;

                if (DropShadowSupported)
                {
                    parameters.ClassStyle = (parameters.ClassStyle | CsDropshadow);
                }

                return parameters;
            }
        }

        public static bool DropShadowSupported
        {
            get { return IsWindowsXpOrAbove; }
        }

        public static bool IsWindowsXpOrAbove
        {
            get
            {
                var system = Environment.OSVersion;
                var runningNt = system.Platform == PlatformID.Win32NT;

                return runningNt && system.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
            }
        }


        #endregion

        //Image _bgImage = null;

        public FormCalendarPreview(Image bgImage)
        {
            InitializeComponent();
            this.BackgroundImage = bgImage;
            this.Width = (bgImage.Size.Width) + 2;
            this.Height = (bgImage.Size.Height) + 2;
        }

        private void FrmCalendarPreview_Paint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}