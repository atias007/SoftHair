using System;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Renderers;
using System.Diagnostics;

namespace SoftHairQuickLanch.Forms
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int FlashWindow(IntPtr hwnd, bool revert);

        private const int Htcaption = 0x0002;
        private const int WmNclbuttondown = 0xA1;
        private XmlDocument _doc;
        private XmlNode _node;

        private FrmSupport2 _fSupport;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            toolStrip1.Renderer = new WindowsVistaRenderer(70);
            toolStrip2.Renderer = new WindowsVistaRenderer(22);

            ReadXmlDocument();
            GetLocation();
            HookKeyPress.KeyPress += HookKeyPress_KeyPress;
            HookKeyPress.StartHook();

            try
            {
                File.Copy("rescue.app", "SoftHair.exe.config", true);
            }
            catch { }
        }

        void HookKeyPress_KeyPress(Keys key)
        {
            switch (key)
            {
                case Keys.F12:
                    this.TopMost = true;
                    FocusWindow(this.Handle, false);
                    this.TopMost = false;
                    tbbSoftHair_Click(null, null);
                    break;

                case Keys.F11:
                    this.TopMost = true;
                    FocusWindow(this.Handle, false);
                    this.TopMost = false;
                    tbbRemote_Click(null, null);
                    break;
            }
        }

        private void TbbSoftHairMouseEnter(object sender, EventArgs e)
        {
            tsLabel.Text = ((ToolStripButton)sender).Text;
        }

        private void TbbSoftHairMouseLeave(object sender, EventArgs e)
        {
            tsLabel.Text = tbbSoftHair.Text;
        }

        private void ToolStripLabel1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragForm();
            }
        }

        private void DragForm()
        {
            this.Cursor = Cursors.SizeAll;
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, Htcaption, 0);
            this.Cursor = Cursors.Default;
            SetLocation();
        }

        private void ToolStrip1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragForm();
            }
        }

        private void TsLabelMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragForm();
            }
        }

        private void ToolStrip2MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DragForm();
            }
        }

        private void toolStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void toolStrip1_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }

        private void toolStrip2_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void toolStrip2_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }

        private void ReadXmlDocument()
        {
            XmlTextReader reader = null;

            try
            {
                var filename = Path.Combine(Application.StartupPath, "QuickLaunch.xml");
                reader = new XmlTextReader(filename);
                _doc = new XmlDocument();
                _doc.Load(reader);
            }
            catch //(Exception ex)
            { 
                _doc = null;
                //EventLogManager.AddErrorMessage("Error in function ReadXMLDocument()", "SoftHairQuickLanch", ex);
            }
            finally
            {
                if(reader != null) reader.Close();
            }
        }

        private void SetLocation()
        {
            if (_doc != null)
            {
                try
                {
                    _node = _doc.DocumentElement;
                    if (_node.Name == "QuickLaunchSettings")
                    {
                        _node = _node["Location"];
                        _node["X"].ChildNodes[0].Value = this.Left.ToString();
                        _node["Y"].ChildNodes[0].Value = this.Top.ToString();
                        var filename = Path.Combine(Application.StartupPath, "QuickLaunch.xml");
                        _doc.Save(filename);
                    }
                }
                catch { }
            }
        }

        private void GetLocation()
        {
            if (_doc == null)
            {
                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 8;
                this.Top = 8;
            }
            else
            {
                var location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width - 8, 8);
                try
                {
                    _node = _doc.DocumentElement;
                    if (_node != null)
                    {
                        if (_node.Name == "QuickLaunchSettings")
                        {
                            _node = _node["Location"];
                            if (_node != null)
                            {
                                location.X = Convert.ToInt32(_node["X"].ChildNodes[0].Value);
                                location.Y = Convert.ToInt32(_node["Y"].ChildNodes[0].Value);
                            }
                        }
                    }
                }
                catch { }

                if (location.X + this.Width < 0) location.X = 0;
                if (location.X >= Screen.PrimaryScreen.Bounds.Width) location.X = Screen.PrimaryScreen.Bounds.Width - this.Width - 8;
                if (location.Y + this.Height < 0) location.Y = 0;
                if (location.Y >= Screen.PrimaryScreen.Bounds.Height) location.Y = Screen.PrimaryScreen.Bounds.Height - this.Height - 8;

                this.Location = location;
            }
        }

        private static void StartProc(string name)
        {
            try
            {
                if (name.StartsWith("http://") || File.Exists(name)) Process.Start(name);
                else MessageBox.Show("קובץ היעד לא נמצא\n" + name, "שגיאת הפעלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("שגיאה בהפעלת הקובץ\n" + name, "\n\nתיאור השגיאה:\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbbSoftHair_Click(object sender, EventArgs e)
        {
            StartProc(Path.Combine(Application.StartupPath, "SoftHair.exe"));
        }

        private void tbbWebSite_Click(object sender, EventArgs e)
        {
            StartProc("http://www.softhair.co.il");
        }

        private void tbbOnlineUpdate_Click(object sender, EventArgs e)
        {
            StartProc(Path.Combine(Application.StartupPath, "OnlineUpdate.exe"));
        }

        private void tbbRemote_Click(object sender, EventArgs e)
        {
            OpenSupportForm(false);
        }

        public void OpenSupportForm(bool isDialog)
        {
            ReadXmlDocument();
            if (!(_fSupport == null || _fSupport.IsDisposed)) _fSupport.Close();
            _fSupport = null;
            _fSupport = new FrmSupport2();

            if (isDialog)
            {
                _fSupport.ShowDialog(this);
            }
            else
            {
                _fSupport.Show(this);
            }
        }

        private void tbbContact_Click(object sender, EventArgs e)
        {
            StartProc("http://www.softhair.co.il/ContactUs.aspx");
        }

        public void FocusWindow(IntPtr hwnd, bool flash)
        {
            this.Select();
            this.Activate();
            SetForegroundWindow(hwnd);
            if (flash) FlashWindow(hwnd, false);
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            FocusWindow(this.Handle, false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void tbbClientForm_Click(object sender, EventArgs e)
        {
            StartProc(Path.Combine(Application.StartupPath, "Media\\Client Register.pdf"));
        }

        private void tbbTeam_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("TeamViewerQS.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("קובץ חלון התמיכה לא נמצא\n" + ex.Message, "שגיאה...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}