using ClientManage.BL;
using ClientManage.Interfaces;
using ClientManage.Library;
using HardwareHelperLib;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace ClientManage.Forms
{
    public partial class FormSplash : Form
    {
        #region Form Drop Shadow

        private static bool _enableDropShadow = true;
        private string[] _devices;
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
            get { return IsWindowsXpOrAbove && _enableDropShadow; }
        }

        public static bool IsWindowsXpOrAbove
        {
            get
            {
                try
                {
                    var system = Environment.OSVersion;
                    var runningNt = system.Platform == PlatformID.Win32NT;

                    return runningNt && system.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion Form Drop Shadow

        #region Win API Declaration

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow(IntPtr hWnd, int dwTime, int dwFlag);

        #endregion Win API Declaration

        private const int AniEffect = 0x10;
        private FormMain _fMain;

        public FormSplash()
        {
            //Trace.WriteLine("7");
            InitializeComponent();
            //Trace.WriteLine("8");
        }

        private void FrmSplashLoad(object sender, EventArgs e)
        {
            //Trace.WriteLine("9");
            CheckDbConnection();
            //Trace.WriteLine("10");

            var vers = Application.ProductVersion.Split('.');
            lblVersion.Text += string.Format("{0}.{1}", vers[0], vers[1]);
            lblRevision.Text = string.Format("(תיקון {0})", vers[3]);
            lblRevision.Visible = (vers[3] != "0");
            lblClient.Text = AppSettingsHelper.GetParamValue("APP_CLIENT_NAME");
            if (vers[3] == "0") lblRevision.Visible = false;

            //Trace.WriteLine("11");

            AnimateWindow(this.Handle, 75, AniEffect);
            //Trace.WriteLine("12");

            StartLoadProcess();
            //Trace.WriteLine("13");
        }

        private void StartLoadProcess()
        {
            Application.DoEvents();

            // load the main form of the application
            _fMain = new FormMain();
            _fMain.ClosingApplication += FMainClosingApplication;

            try
            {
                CalendarHelper.InitializeGoogleService();
            }
            catch (Exception ex)
            {
                General.ShowCommunicationError(ex, this);
            }

            //#if DEBUG
            //#else
            // check program licence
            _fMain.CheckLicense(this);
            //#endif
            // set the screen resolution factor
            SetScreenResolutionFactor();

            // set input language to hebrew
            SetInputLanguage();

            // initialize tapi components
            var tapi = _fMain.InitializeTapi();

            // cache client data table
            CacheSearchDataSource();

            // start schedule tasks timers
            _fMain.InitializeScheduleTasks();

            // initialize KeyPress pipe
            _fMain.InitKeyPressPipe();

            // set all subscribers status
            SubscriberHelper.SetAllStatus();

            // check for password
            CheckPassword();

            // show the clients form
            _fMain.ShowStartupForm();

            // load the today birthday form
            if (AppSettingsHelper.GetParamValue<bool>("MAIN_SHOW_TODAY_BIRTHDAY")) _fMain.InitTodayBirthday();

            // disable hardware devices
            DisableHardware();

            // initialize tapi components
            if (!tapi) _fMain.InitializeTapi();
#if DEBUG
#else
            try
            {
                //CreateDesktopShortcut();
            }
            catch { Utils.CatchException(); }
#endif

            // show the main form of the application
            HideMe();
            _fMain.Show();
        }

        //private void CreateDesktopShortcut()
        //{
        //    const string filename = "c:\\SoftHair\\SoftHair.exe";
        //    const string linkname = "SoftHair לנהל בראש טוב.lnk";
        //    var linkFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), linkname);
        //    if (!File.Exists(linkFilename))
        //    {
        //        Utils.CreateApplicationShortcut(linkFilename, filename);
        //    }
        //}

        private void FMainClosingApplication(object sender, EventArgs e)
        {
            EnableHardware();
        }

        private static void SetScreenResolutionFactor()
        {
            if (General.ScreenResolutionFactorWidth == 0) // || General.ScreenResolutionFactorHeight == 0)
            {
                var width = Screen.PrimaryScreen.Bounds.Width;
                //var height = Screen.PrimaryScreen.Bounds.Height;

                if (width >= 1024) // && height >= 768)
                {
                    General.ScreenResolutionFactorWidth = width / 1024.0;
                    //General.ScreenResolutionFactorHeight = height / 768.0;
                }
            }
        }

        private void CheckDbConnection()
        {
            try
            {
                AppSettingsHelper.CheckDbConnection();
            }
            catch (Exception ex)
            {
                const string message = "המערכת לא הצליחה לפתוח את בסיס הנתונים\nלא ניתן להפעיל את המערכת\n\nאנא פנה אל שירות הלקוחות";
                const string caption = "שגיאה בבסיס הנתונים...";
                var msg = new MyMessageBox(message, caption, MyMessageBox.MyMessageType.Error, MyMessageBox.MyMessageButton.Ok);
                msg.Show(this);

                using (var fLogViewer = new FormLogViewer(ex))
                {
                    fLogViewer.ShowDialog(this);
                }

                Environment.Exit(-1);
            }
        }

        private static void SetInputLanguage()
        {
            try
            {
                foreach (InputLanguage il in InputLanguage.InstalledInputLanguages)
                {
                    if (il.LayoutName != null)
                        if (il.LayoutName.Equals("Hebrew"))
                        {
                            InputLanguage.CurrentInputLanguage = il;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                EventLogManager.AddErrorMessage("Error in \"SetInputLanguage\" Function", ex);
            }
        }

        private static void CacheSearchDataSource()
        {
            ClientHelper.DoCacheClientsTable();
        }

        private void DisableHardware()
        {
            var mi = new MethodInvoker(DisableHardwareInvoke);
            this.Invoke(mi);
        }

        private void DisableHardwareInvoke()
        {
            _devices = Utils.GetStringArray(AppSettingsHelper.GetParamValue<string>("APP_EXCLUDE_HARDWARE"));
            if (_devices.Length > 0)
            {
                var tmp = new string[1];
                var hwh = new HH_Lib();
                hwh.CutLooseHardwareNotifications(this.Handle);
                foreach (var device in _devices)
                {
                    if (device.Length > 0)
                    {
                        tmp[0] = device;
                        hwh.SetDeviceState(tmp, false);
                    }
                }
                hwh.HookHardwareNotifications(this.Handle, true);
            }
        }

        private void EnableHardware()
        {
            if (_devices != null && _devices.Length > 0)
            {
                var tmp = new string[1];
                var hwh = new HH_Lib();
                hwh.CutLooseHardwareNotifications(this.Handle);
                foreach (var device in _devices)
                {
                    if (device.Length > 0)
                    {
                        tmp[0] = device;
                        hwh.SetDeviceState(tmp, true);
                    }
                }
            }
        }

        private void HideMe()
        {
            _enableDropShadow = false;
            this.Hide();
            this.TopMost = false;
            this.Opacity = 0;
        }

        private void CheckPassword()
        {
            var pass = AppSettingsHelper.GetParamValue("APP_LOGIN_PASSWORD");
            if (!string.IsNullOrEmpty(pass))
            {
                const string caption = "ברוך הבא אל מערכת SoftHair\nמערכת ממוחשבת לניהול מספרות ומכוני יופי\n\nהזן סיסמת כניסה למערכת";
                var fPass = new FormPassword(pass, caption, false);
                var res = fPass.ShowDialog(this);
                if (res != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
                Application.DoEvents();
            }
        }

        private void FrmSplashVisibleChanged(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}